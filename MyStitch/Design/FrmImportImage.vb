' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Runtime.InteropServices
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmImportImage
    Private _imageSize As New Size(1, 1)
    Private oSelectedImage As Image
    Private oTargetImage As Bitmap
    Private Const MAX_SIZE As Integer = 5000
    Private isSizeChanging As Boolean = False
    Private oImportDesign As ProjectDesign
    Private oThreadList As List(Of Thread)
    Private iPaletteId As Integer
    Private oPaletteList As List(Of Thread)
    Private Sub FrmImportImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening import form", MyBase.Name)
        GetFormPos(Me, My.Settings.ImportFormPos)
        InitialiseForm()
    End Sub

    Private Sub InitialiseForm()
        LoadThreads()
        oPaletteList = New List(Of Thread)
        oProjectDesign = Nothing
        oImportDesign = Nothing
        oDesignBitmap = Nothing
        oDesignGraphics = Nothing
        topcorner = New Point(0, 0)
    End Sub

    Private Sub LoadThreads()
        oThreadList = New List(Of Thread)
        For Each _thread As Thread In GetThreads()
            If _thread.StockLevel > 0 Then
                oThreadList.Add(_thread)
            End If
        Next
    End Sub

    Private Function GetNearestThread(pColor As Color) As Thread
        Dim _minDiff As Integer = Integer.MaxValue
        Dim _nearestThread As Thread = Nothing
        For Each _thread As Thread In oThreadList
            Dim _diff As Integer
            Dim _red = Math.Pow(Convert.ToDouble(_thread.Colour.R) - Convert.ToDouble(pColor.R), 2)
            Dim _green = Math.Pow(Convert.ToDouble(_thread.Colour.G) - Convert.ToDouble(pColor.G), 2)
            Dim _blue = Math.Pow(Convert.ToDouble(_thread.Colour.B) - Convert.ToDouble(pColor.B), 2)
            _diff = Convert.ToInt32(Math.Sqrt(_red + _green + _blue))
            If _diff < _minDiff Then
                _minDiff = _diff
                _nearestThread = _thread
            End If
        Next
        Return _nearestThread
    End Function

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.ImportFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        _imageSize = New Size(1, 1)
        TxtImagePath.Text = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open, ImageUtil.ImageType.ALL)
        If Not String.IsNullOrEmpty(TxtImagePath.Text) AndAlso My.Computer.FileSystem.FileExists(TxtImagePath.Text) Then
            oSelectedImage = Image.FromFile(TxtImagePath.Text)
            PicImagePreview.Image = oSelectedImage
            _imageSize = oSelectedImage.Size
            LblSize.Text = String.Format("Image size {0} pLocX {1}", _imageSize.Width, _imageSize.Height)
            isSizeChanging = True
            CalculateScaleSize()
            isSizeChanging = False
            NudFabricHeight.Value = NudDesignHeight.Value
            NudFabricWidth.Value = NudDesignWidth.Value
        End If
    End Sub

    Private Sub NudScaleFactor_ValueChanged(sender As Object, e As EventArgs) Handles NudScaleFactor.ValueChanged
        If Not isSizeChanging Then
            isSizeChanging = True
            CalculateScaleSize()
            isSizeChanging = False
        End If
    End Sub
    Private Sub CalculateScaleSize()
        If _imageSize.Height > 0 AndAlso _imageSize.Width > 0 Then
            Dim _scaleHeight As Decimal = Math.Ceiling(_imageSize.Height / NudScaleFactor.Value)
            Dim _scaleWidth As Decimal = Math.Ceiling(_imageSize.Width / NudScaleFactor.Value)
            If _scaleHeight > MAX_SIZE OrElse _scaleWidth > MAX_SIZE Then
                MessageBox.Show("Design size exceeds maximum of MAX_SIZE stitches in either direction", "Size error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If _scaleWidth > _scaleHeight Then
                    _scaleWidth = MAX_SIZE
                    _scaleHeight = (_imageSize.Height * _scaleWidth) / _imageSize.Width
                Else
                    _scaleHeight = MAX_SIZE
                    _scaleWidth = (_imageSize.Width * _scaleHeight) / _imageSize.Height
                End If
                NudScaleFactor.Value = Math.Max(_imageSize.Height / _scaleHeight, _imageSize.Width / _scaleWidth)
            Else
                NudDesignHeight.Value = _scaleHeight
                NudDesignWidth.Value = _scaleWidth
            End If
        End If
    End Sub

    Private Sub NudDesignWidth_ValueChanged(sender As Object, e As EventArgs) Handles NudDesignWidth.ValueChanged
        If Not isSizeChanging Then
            If _imageSize.Height > 0 AndAlso _imageSize.Width > 0 Then
                isSizeChanging = True
                Dim _scaleWidth As Integer = Math.Min(MAX_SIZE, NudDesignWidth.Value)
                Dim _sidesratio As Double = _imageSize.Width / _imageSize.Height
                NudDesignHeight.Value = Math.Ceiling(_scaleWidth * _sidesratio)
                NudScaleFactor.Value = Math.Max(1, _imageSize.Width / _scaleWidth)
                isSizeChanging = False
            End If
        End If
    End Sub

    Private Sub NudDesignHeight_ValueChanged(sender As Object, e As EventArgs) Handles NudDesignHeight.ValueChanged
        If Not isSizeChanging Then
            If _imageSize.Height > 0 AndAlso _imageSize.Width > 0 Then
                isSizeChanging = True
                Dim _scaleHeight As Decimal = Math.Min(MAX_SIZE, NudDesignHeight.Value)
                Dim _sidesratio As Double = _imageSize.Height / _imageSize.Width
                NudDesignWidth.Value = Math.Ceiling(_scaleHeight * _sidesratio)
                NudScaleFactor.Value = Math.Max(1, _imageSize.Height / _scaleHeight)
                isSizeChanging = False
            End If
        End If
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        If oSelectedImage IsNot Nothing Then
            iPixelsPerCell = PIXELS_PER_CELL
            oTargetImage = ImageUtil.ResizeImage(oSelectedImage, NudDesignWidth.Value, NudDesignHeight.Value)
            Dim _width As Integer = NudDesignWidth.Value * iPixelsPerCell
            Dim _height As Integer = NudDesignHeight.Value * iPixelsPerCell

            oDesignBitmap = New Bitmap(_width, _height)
            oDesignGraphics = Graphics.FromImage(oDesignBitmap)
            oImportDesign = ProjectDesignBuilder.AProjectDesign().StartingWithNothing.WithRows(NudDesignHeight.Value).WithColumns(NudDesignWidth.Value).Build
            DrawGrid(oImportDesign, True, True)
            PicDesign.Invalidate()
            For Each y As Integer In Enumerable.Range(0, oTargetImage.Size.Height)
                For Each x As Integer In Enumerable.Range(0, oTargetImage.Size.Width)
                    Dim _cellColor As Color = oTargetImage.GetPixel(x, y)
                    Dim _thread As Thread = GetNearestThread(_cellColor)
                    Dim _qtrs As List(Of BlockStitchQuarter) = GenerateStitchQuarters(_thread)
                    Dim _blockstitch As BlockStitch = GenerateBlockstitchForThread(x, y, _thread, _qtrs)
                    AddBlockstitchToDesign(_blockstitch, oImportDesign)
                    DrawImportBlockStitch(_blockstitch)
                Next
                PicDesign.Invalidate()
                Application.DoEvents()
            Next
        End If
    End Sub

    Private Sub AddBlockstitchToDesign(pBlockstitch As BlockStitch, pImportDesign As ProjectDesign)
        pImportDesign.BlockStitches.Add(pBlockstitch)
        If Not oPaletteList.Exists(Function(x As Thread) x.ThreadId = pBlockstitch.ThreadId) Then
            Dim _paletteThread As Thread = GetThreadById(pBlockstitch.ThreadId)
            oPaletteList.Add(_paletteThread)
            AddThreadToPalette(_paletteThread)
        End If
    End Sub
    Private Sub AddThreadToPalette(pThread As Thread)
        Dim _picSize As Integer = PALETTE_COLOUR_SIZE
        Dim _picThread As New PictureBox()
        With _picThread
            .Name = CStr(pThread.ThreadId)
            .Size = New Size(_picSize, _picSize)
            .BorderStyle = BorderStyle.None
            .SizeMode = PictureBoxSizeMode.Zoom
            .BackColor = pThread.Colour
            Dim tt As New ToolTip
            tt.SetToolTip(_picThread, pThread.ColourName & " " & pThread.ThreadNo)
        End With
        ThreadLayoutPanel.Controls.Add(_picThread)
    End Sub

    Private Shared Function GenerateBlockstitchForThread(pLocX As Integer, pLocY As Integer, pThread As Thread, pQuarters As List(Of BlockStitchQuarter)) As BlockStitch
        Dim _stitch As Stitch = BlockStitchBuilder.ABlockStitch().StartingWithNothing _
            .WithBlockLocation(New Point(pLocX, pLocY)) _
            .WithStitchType(BlockStitchType.Full) _
            .WithProjectId(999) _
            .WithThreadId(pThread.ThreadId) _
            .Build
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch().StartingWith(_stitch) _
            .WithQuarters(pQuarters) _
            .Build
        Return _blockstitch
    End Function

    Private Shared Function GenerateStitchQuarters(_thread As Thread) As List(Of BlockStitchQuarter)
        Dim _qtrs As New List(Of BlockStitchQuarter) From {
            New BlockStitchQuarter(BlockQuarter.TopLeft, 2, _thread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.TopRight, 2, _thread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomLeft, 2, _thread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomRight, 2, _thread.ThreadId)
        }
        Return _qtrs
    End Function

    Private Sub FillStitches(pProjectDesign As ProjectDesign)
        For Each _blockstitch In pProjectDesign.BlockStitches
            If _blockstitch.IsLoaded Then
                DrawImportBlockStitch(_blockstitch)
            End If
        Next

    End Sub

    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        If oDesignBitmap IsNot Nothing Then
            DisplayImage(oDesignBitmap, 0, 0, e)
        End If
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
        oDesignGraphics.FillRectangle(New SolidBrush(_threadColour), New Rectangle(_tl, _size))

        'oDesignGraphics.DrawLine(_crossPen, _tl, _br)
        'oDesignGraphics.DrawLine(_crossPen, _tr, _bl)

        _crossPen.Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        InsertNewProject()
    End Sub

    Private Sub InsertNewProject()
        LogUtil.LogInfo("New project", MyBase.Name)
        Dim _project As Project = BuildProjectFromForm(-1)
        If _project IsNot Nothing Then
            _project.ProjectId = InsertProject(_project)
            oProject = _project
            For Each _blockStitch In oImportDesign.BlockStitches
                _blockStitch.ProjectId = _project.ProjectId
            Next
            SavePalette()
            oProjectDesign = oImportDesign
            SaveDesign()
        End If
        LogUtil.ShowStatus("Project Added", LblStatus, MyBase.Name)
    End Sub
    Private Function BuildProjectFromForm(pId As Integer) As Project
        Dim _project As Project
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
            '_project.DesignFileName = MakeFilename(_project)
        Else
            MessageBox.Show("Please enter a project name", "Name required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            _project = Nothing
        End If

        Return _project
    End Function

    Private Sub BtnSavePalette_Click(sender As Object, e As EventArgs) Handles BtnSavePalette.Click
        If Not String.IsNullOrEmpty(TxtName.Text) Then
            Dim _paletteId As Integer = SavePalette()
            SavePaletteThreads(_paletteId)
        Else
            MessageBox.Show("Please enter a project name", "Name required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function SavePalette() As Integer
        Return InsertPalette(TxtName.Text)
    End Function

    Private Sub SavePaletteThreads(pPaletteId As Integer)
        For Each _thread In oPaletteList
            Dim _paletteThread As PaletteThread = PaletteThreadBuilder.APaletteThread.StartingWithNothing _
                .WithThreadId(_thread.ThreadId) _
                .WithPaletteId(pPaletteId) _
                .Build
            ' _paletteThread.SymbolId = GetRandomAvailableSymbolId()
            InsertPaletteThread(_paletteThread)
        Next
    End Sub
End Class