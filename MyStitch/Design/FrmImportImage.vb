' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.ModDataFunctions
Imports MyStitch.Domain.Objects
Public Class FrmImportImage
#Region "variables"
    Private _imageSize As New Size(1, 1)
    Private oSelectedImage As Image
    Private oTargetImage As Bitmap
    Private Const MAX_SIZE As Integer = 500
    Private isSizeChanging As Boolean = False
    Private isLoading As Boolean = False
    Private oThreadList As New List(Of Thread)
    Private iPaletteId As Integer
    Private oPaletteList As New List(Of PaletteThread)
    Private oSymbolList As New List(Of Symbol)
    Private Const PALETTE_BOX_SIZE As Integer = 24
#End Region
#Region "form control handling"
    Private Sub FrmImportImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening import form", MyBase.Name)
        GetFormPos(Me, My.Settings.ImportFormPos)
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.ImportFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        LogUtil.LogInfo("Selecting image", MyBase.Name)
        _imageSize = New Size(1, 1)
        ClearForm()
        TxtImagePath.Text = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open, ImageUtil.ImageType.ALL)
        If Not String.IsNullOrEmpty(TxtImagePath.Text) AndAlso My.Computer.FileSystem.FileExists(TxtImagePath.Text) Then
            Try
                oSelectedImage = Image.FromFile(TxtImagePath.Text)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is FileNotFoundException _
                                OrElse TypeOf ex Is OutOfMemoryException)
                LogUtil.ShowException(ex, "ImageFromFile", LblStatus, MethodBase.GetCurrentMethod.Name)
            End Try
            PicImagePreview.Image = oSelectedImage
            _imageSize = oSelectedImage.Size
            LblSize.Text = String.Format("Image size {0} x {1}", _imageSize.Width, _imageSize.Height)
            isSizeChanging = True
            CalculateScaleSize()
            isSizeChanging = False
            NudFabricHeight.Value = NudDesignHeight.Value
            NudFabricWidth.Value = NudDesignWidth.Value
            LogUtil.ShowStatus("Image selected " & Path.GetFileName(TxtImagePath.Text), LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No image selected", LblStatus, MyBase.Name)
        End If
    End Sub
    Private Sub NudScaleFactor_ValueChanged(sender As Object, e As EventArgs) Handles NudScaleFactor.ValueChanged
        If Not isSizeChanging AndAlso _imageSize.Height > 0 AndAlso _imageSize.Width > 0 Then
            isSizeChanging = True
            CalculateScaleSize()
            isSizeChanging = False
        End If
    End Sub
    Private Sub NudDesignWidth_ValueChanged(sender As Object, e As EventArgs) Handles NudDesignWidth.ValueChanged
        If Not isSizeChanging AndAlso _imageSize.Height > 0 AndAlso _imageSize.Width > 0 Then
            isSizeChanging = True
            Dim _scaleWidth As Integer = Math.Min(MAX_SIZE, NudDesignWidth.Value)
            Dim _sidesratio As Double = _imageSize.Height / _imageSize.Width
            NudDesignHeight.Value = Math.Ceiling(_sidesratio * _scaleWidth)
            NudScaleFactor.Value = Math.Max(1, _imageSize.Width / _scaleWidth)
            isSizeChanging = False
        End If
    End Sub
    Private Sub NudDesignHeight_ValueChanged(sender As Object, e As EventArgs) Handles NudDesignHeight.ValueChanged
        If Not isSizeChanging AndAlso _imageSize.Height > 0 AndAlso _imageSize.Width > 0 Then
            isSizeChanging = True
            Dim _scaleHeight As Decimal = Math.Min(MAX_SIZE, NudDesignHeight.Value)
            Dim _sidesratio As Double = _imageSize.Height / _imageSize.Width
            NudDesignWidth.Value = Math.Ceiling(_scaleHeight / _sidesratio)
            NudScaleFactor.Value = Math.Max(1, _imageSize.Height / _scaleHeight)
            isSizeChanging = False
        End If
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        LogUtil.LogInfo("Importing image", MyBase.Name)
        If oPaletteList.Count = 0 AndAlso ChkPaletteOnly.Checked Then
            LogUtil.ShowStatus("No palette loaded", LblStatus, True)
        Else
            If oSelectedImage IsNot Nothing Then
                '         ClearPalette()
                oTargetImage = ImageUtil.ResizeImage(oSelectedImage, NudDesignWidth.Value, NudDesignHeight.Value)
                iPixelsPerCell = Math.Min(PicDesign.Width / NudDesignWidth.Value, PicDesign.Height / NudDesignHeight.Value)
                Dim _width As Integer = NudDesignWidth.Value * iPixelsPerCell
                Dim _height As Integer = NudDesignHeight.Value * iPixelsPerCell
                oDesignBitmap = New Bitmap(_width, _height)
                oDesignGraphics = Graphics.FromImage(oDesignBitmap)
                oProjectDesign = ProjectDesignBuilder.AProjectDesign().StartingWithNothing.WithRows(NudDesignHeight.Value).WithColumns(NudDesignWidth.Value).Build
                DrawGrid(oProjectDesign, True, True)
                PicDesign.Invalidate()
                For Each y As Integer In Enumerable.Range(0, oTargetImage.Size.Height)
                    For Each x As Integer In Enumerable.Range(0, oTargetImage.Size.Width)
                        Dim _cellColor As Color = oTargetImage.GetPixel(x, y)
                        Dim _thread As Thread = GetNearestThread(_cellColor)
                        Dim _blockstitch As BlockStitch = GenerateBlockstitchForThread(x, y, _thread)
                        AddBlockstitchToDesign(_blockstitch, oProjectDesign)
                        DrawImportBlockStitch(_blockstitch)
                    Next
                    LogUtil.ShowStatus(String.Format("Importing row {0} of {1}", y + 1, oTargetImage.Size.Height), LblStatus)
                    PicDesign.Invalidate()
                    Application.DoEvents()
                Next
                LogUtil.ShowStatus("Image import complete", LblStatus)
            Else
                LogUtil.ShowStatus("No image selected", LblStatus, True)
            End If
        End If
    End Sub
    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        If oDesignBitmap IsNot Nothing Then
            Try
                DisplayImage(oDesignBitmap, 0, 0, e)
            Catch ex As ApplicationException
                LogUtil.ShowException(ex, "DisplayImage", LblStatus, MethodBase.GetCurrentMethod.Name)
            End Try
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        InsertImportedProject()
    End Sub
    Private Sub BtnSavePalette_Click(sender As Object, e As EventArgs) Handles BtnSavePalette.Click
        LogUtil.ShowStatus("Saving palette", LblStatus, MyBase.Name)
        If Not String.IsNullOrEmpty(TxtName.Text) Then
            Dim _paletteId As Integer = SavePalette()
            SavePaletteThreads(_paletteId)
            LogUtil.ShowStatus("Palette saved", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No project name entered", LblStatus, True)
        End If
    End Sub
    Private Sub BtnClearForm_Click(sender As Object, e As EventArgs) Handles BtnClearForm.Click
        ClearForm()
        ClearPalette()
    End Sub
#End Region
#Region "functions"
    Private Function GetNearestThread(pColor As Color) As Thread
        Dim _minDiff As Integer = Integer.MaxValue
        Dim _nearestThread As Thread = Nothing
        If ChkPaletteOnly.Checked Then
            If oPaletteList.Count = 0 Then
                LogUtil.ShowStatus("No palette loaded", LblStatus, True)
                Return Nothing
            Else
                For Each _thread As PaletteThread In oPaletteList
                    _nearestThread = GetNearerThread(pColor, _minDiff, _nearestThread, _thread.Thread)
                Next
            End If
        Else
            For Each _thread As Thread In oThreadList
                _nearestThread = GetNearerThread(pColor, _minDiff, _nearestThread, _thread)
            Next
        End If
        Return _nearestThread
    End Function

    Private Shared Function GetNearerThread(pColor As Color, ByRef _minDiff As Integer, ByRef _currentNearestThread As Thread, _thread As Thread) As Thread
        Dim _nearerThread As Thread = _currentNearestThread
        Dim _diff As Integer
        Dim _red = Math.Pow(Convert.ToDouble(_thread.Colour.R) - Convert.ToDouble(pColor.R), 2)
        Dim _green = Math.Pow(Convert.ToDouble(_thread.Colour.G) - Convert.ToDouble(pColor.G), 2)
        Dim _blue = Math.Pow(Convert.ToDouble(_thread.Colour.B) - Convert.ToDouble(pColor.B), 2)
        _diff = Convert.ToInt32(Math.Sqrt(_red + _green + _blue))
        If _diff < _minDiff Then
            _minDiff = _diff
            _nearerThread = _thread
        End If
        Return _nearerThread
    End Function

    Private Function GenerateBlockstitchForThread(pLocX As Integer, pLocY As Integer, pThread As Thread) As BlockStitch
        Dim _stitch As Stitch = BlockStitchBuilder.ABlockStitch() _
            .StartingWithNothing _
            .WithProjectId(999) _
            .WithBlockLocation(New Point(pLocX, pLocY)) _
            .WithStitchType(BlockStitchType.Full) _
            .WithThreadId(pThread.ThreadId) _
            .Build
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch() _
            .StartingWith(_stitch) _
            .WithQuarters(GenerateStitchQuarters(pThread)) _
            .Build
        Return _blockstitch
    End Function
    Private Function GenerateStitchQuarters(_thread As Thread) As List(Of BlockStitchQuarter)
        Dim _qtrs As New List(Of BlockStitchQuarter) From {
            New BlockStitchQuarter(BlockQuarter.TopLeft, 2, _thread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.TopRight, 2, _thread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomLeft, 2, _thread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomRight, 2, _thread.ThreadId)
        }
        Return _qtrs
    End Function
    Private Function BuildProjectFromForm(pId As Integer) As Project
        Dim _project As Project = Nothing
        If Not String.IsNullOrWhiteSpace(TxtName.Text) Then
            _project = ProjectBuilder.AProject.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                    .WithDesignHeight(NudDesignHeight.Value) _
                                                    .WithDesignWidth(NudDesignWidth.Value) _
                                                    .WithFabricHeight(NudFabricHeight.Value) _
                                                    .WithFabricWidth(NudFabricWidth.Value) _
                                                    .WithFabricColour(0) _
                                                    .WithFabricCount(NudFabricCount.Value) _
                                                    .WithOriginX(NudOriginX.Value) _
                                                    .WithOriginY(NudOriginY.Value) _
                                                    .WithTotalMinutes(0) _
                                                    .WithStarted(DateTime.Now) _
                                                    .WithEnded(DateTime.Now) _
                                                    .Build()
        Else
            LogUtil.ShowStatus("No project name entered", LblStatus, True)
        End If
        Return _project
    End Function
    Private Function SavePalette() As Integer
        Return InsertPalette(TxtName.Text)
    End Function
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isLoading = True
        LoadThreads()
        ClearForm()
        ClearPalette()
        isLoading = False
    End Sub
    Private Sub LoadThreads()
        LogUtil.ShowStatus("Loading threads", LblStatus, MyBase.Name)
        oThreadList.Clear()
        For Each _thread As Thread In GetThreads()
            If Not ChkStockOnly.Checked OrElse _thread.StockLevel > 0 Then
                oThreadList.Add(_thread)
            End If
        Next
    End Sub
    Private Sub CalculateScaleSize()
        If _imageSize.Height > 0 AndAlso _imageSize.Width > 0 Then
            Dim _scaleHeight As Decimal = Math.Ceiling(_imageSize.Height / NudScaleFactor.Value)
            Dim _scaleWidth As Decimal = Math.Ceiling(_imageSize.Width / NudScaleFactor.Value)
            If _scaleHeight > MAX_SIZE OrElse _scaleWidth > MAX_SIZE Then
                MessageBox.Show("Design size exceeds maximum of " & MAX_SIZE & " stitches in either direction", "Size error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If _scaleWidth > _scaleHeight Then
                    _scaleWidth = MAX_SIZE
                    _scaleHeight = (_imageSize.Height * _scaleWidth) / _imageSize.Width
                Else
                    _scaleHeight = MAX_SIZE
                    _scaleWidth = (_imageSize.Width * _scaleHeight) / _imageSize.Height
                End If
                NudScaleFactor.Value = Math.Max(_imageSize.Height / _scaleHeight, _imageSize.Width / _scaleWidth)
            End If
            NudDesignHeight.Value = _scaleHeight
            NudDesignWidth.Value = _scaleWidth
        End If
    End Sub
    Private Sub AddBlockstitchToDesign(pBlockstitch As BlockStitch, pImportDesign As ProjectDesign)
        pImportDesign.BlockStitches.Add(pBlockstitch)
        If Not oPaletteList.Exists(Function(x As PaletteThread) x.ThreadId = pBlockstitch.ThreadId) Then
            Dim _paletteThread As PaletteThread = PaletteThreadBuilder.APaletteThread.StartingWithNothing _
                .WithThreadId(pBlockstitch.ThreadId) _
                .Build
            oPaletteList.Add(_paletteThread)
            AddThreadToPalette(_paletteThread)
        End If
    End Sub
    Private Sub AddThreadToPalette(pPaletteThread As PaletteThread)
        Dim _thread As Thread = pPaletteThread.Thread
        Dim _picSize As Integer = PALETTE_BOX_SIZE
        Dim _picThread As New PictureBox()
        With _picThread
            .Name = CStr(_thread.ThreadId)
            .Size = New Size(_picSize, _picSize)
            .BorderStyle = BorderStyle.None
            .SizeMode = PictureBoxSizeMode.Zoom
            .BackColor = _thread.Colour
            .Image = pPaletteThread.Symbol
            Dim tt As New ToolTip
            tt.SetToolTip(_picThread, _thread.ColourName & " " & _thread.ThreadNo)
        End With
        ThreadLayoutPanel.Controls.Add(_picThread)
    End Sub
    Public Sub DrawImportBlockStitch(pBlockStitch As BlockStitch)
        Dim _threadColour As Color = GetThreadById(pBlockStitch.ThreadId).Colour
        Dim pX As Integer = pBlockStitch.BlockPosition.X * iPixelsPerCell
        Dim pY As Integer = pBlockStitch.BlockPosition.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        Dim _size As New Size(iPixelsPerCell, iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        If RbCrosses.Checked Then
            oDesignGraphics.DrawLine(_crossPen, _tl, _br)
            oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        Else
            oDesignGraphics.FillRectangle(New SolidBrush(_threadColour), New Rectangle(_tl, _size))
        End If
        _crossPen.Dispose()
    End Sub
    Private Sub InsertImportedProject()
        LogUtil.LogInfo("Saving imported project", MyBase.Name)
        Dim _project As Project = BuildProjectFromForm(-1)
        If _project IsNot Nothing Then
            _project.ProjectId = InsertProject(_project)
            oProject = _project
            For Each _blockStitch In oProjectDesign.BlockStitches
                _blockStitch.ProjectId = _project.ProjectId
            Next
            SaveProjectThreads(_project.ProjectId)
            SaveDesign()
        End If
        LogUtil.ShowStatus("Project Added", LblStatus, MyBase.Name)
    End Sub
    Private Sub SaveProjectThreads(pProjectId As Integer)
        Randomize()
        oSymbolList = GetAllAvailableSymbols()
        For Each _thread As PaletteThread In oPaletteList
            If _thread.SymbolId < 0 Then
                _thread.SymbolId = GetRandomAvailableSymbolId()
            End If
            Dim _projectThread As ProjectThread = ProjectThreadBuilder.AProjectThread.StartingWithNothing _
                .WithProjectId(pProjectId) _
                .WithThreadId(_thread.ThreadId) _
                .WithSymbolId(_thread.SymbolId) _
                .WithIsUsed(True) _
                .Build
            InsertProjectThread(_projectThread)
        Next
    End Sub
    Private Function GetAllAvailableSymbols() As List(Of Symbol)
        Dim _allSymbols As List(Of Symbol) = GetAllSymbols()
        Dim _usedSymbolIds As New List(Of Integer)
        For Each _thread As PaletteThread In oPaletteList
            If _thread.SymbolId > -1 Then
                _usedSymbolIds.Add(_thread.SymbolId)
            End If
        Next
        Return _allSymbols.Where(Function(x) Not _usedSymbolIds.Contains(x.SymbolId)).ToList()
    End Function

    Private Sub SavePaletteThreads(pPaletteId As Integer)
        Randomize()
        oSymbolList = GetAllAvailableSymbols()
        For Each _thread In oPaletteList
            If _thread.SymbolId < 0 Then
                _thread.SymbolId = GetRandomAvailableSymbolId()
            End If
            Dim _paletteThread As PaletteThread = PaletteThreadBuilder.APaletteThread.StartingWithNothing _
                .WithThreadId(_thread.ThreadId) _
                .WithPaletteId(pPaletteId) _
                .WithSymbolId(GetRandomAvailableSymbolId()) _
                .Build
            InsertPaletteThread(_paletteThread)
        Next
    End Sub
    Private Function GetRandomAvailableSymbolId() As Integer
        If oSymbolList.Count = 0 Then
            LogUtil.ShowStatus("No more symbols available", LblStatus, True, MyBase.Name, True)
        End If
        Dim index As Integer = CInt(Math.Floor((oSymbolList.Count) * Rnd()))
        Dim _selectedSymbolId As Integer = oSymbolList(index).SymbolId
        oSymbolList.RemoveAt(index)
        Return _selectedSymbolId
    End Function

    Private Sub ClearForm()
        isSizeChanging = True
        Try
            FillPaletteList(CbPalettes)
        Catch ex As ApplicationException
            LogUtil.ShowException(ex, ex.Message, LblStatus, "FillPaletteList")
        End Try
        oProjectDesign = Nothing
        oDesignBitmap = Nothing
        oDesignGraphics = Nothing
        topcorner = New Point(0, 0)
        PicImagePreview.Image = Nothing
        TxtName.Text = String.Empty
        TxtImagePath.Text = String.Empty
        NudScaleFactor.Value = 1
        NudDesignHeight.Value = 1
        NudDesignWidth.Value = 1
        NudFabricHeight.Value = 1
        NudFabricWidth.Value = 1
        NudFabricCount.Value = My.Settings.DefaultFabricCount
        NudOriginX.Value = 0
        NudOriginY.Value = 0
        LblSize.Text = "Image size"
        PicDesign.Invalidate()
        isSizeChanging = False
        ChkPaletteOnly.Checked = False
        ChkStockOnly.Checked = False
        LogUtil.ClearStatus(LblStatus)
    End Sub
    Private Sub ClearPalette()
        oPaletteList.Clear()
        ThreadLayoutPanel.Controls.Clear()
    End Sub

    Private Sub ChkStockOnly_CheckedChanged(sender As Object, e As EventArgs) Handles ChkStockOnly.CheckedChanged
        If Not isLoading Then
            LoadThreads()
        End If
    End Sub

    Private Sub BtnLoadPalette_Click(sender As Object, e As EventArgs) Handles BtnLoadPalette.Click
        If CbPalettes.SelectedValue IsNot Nothing Then
            LogUtil.ShowStatus("Loading Palette", LblStatus, MyBase.Name)
            ClearPalette()
            LoadPalette(CbPalettes.SelectedValue)
        End If
    End Sub

    Private Sub LoadPalette(selectedValue As Object)
        oPaletteList = GetPaletteThreadsByPaletteId(selectedValue)
        For Each _thread As PaletteThread In oPaletteList
            AddThreadToPalette(_thread)
        Next
    End Sub
#End Region

End Class