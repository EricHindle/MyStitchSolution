' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmPrintProject
#Region "properties"
    'Private oPrintProject As Project
    'Private oSourceBitmap As Bitmap
    'Public Property SourceBitmap() As Bitmap
    '    Get
    '        Return oSourceBitMap
    '    End Get
    '    Set(ByVal value As Bitmap)
    '        oSourceBitmap = value
    '    End Set
    'End Property
    'Public WriteOnly Property PrintProject() As Project
    '    Set(ByVal value As Project)
    '        oPrintProject = value
    '    End Set
    'End Property

#End Region
#Region "constants"
#End Region
#Region "variables"
    Private PageToFormRatio As Decimal
    Private oFormImage As Bitmap
    Private isLoading As Boolean = False
    Private isComponentInitialised As Boolean
    Private myPrintDoc As New Printing.PrintDocument
    Private oSourceImage As Image

    Private oPrintBitmap As Bitmap
    Private oPrintGraphics As Graphics
    Private isPrintGrid As Boolean
    Private isPrintCentreLines As Boolean
    Friend oPrintGrid1width As Integer = 1
    Friend oPrintGrid1Brush As Brush = Brushes.Black
    Friend oPrintGrid1Pen = New Pen(oPrintGrid1Brush, oPrintGrid1width)
    Friend oPrintGrid5width As Integer = 1
    Friend oPrintGrid5Brush As Brush = Brushes.Black
    Friend oPrintGrid5Pen = New Pen(oPrintGrid5Brush, oPrintGrid5width)
    Friend oPrintGrid10width As Integer = 2
    Friend oPrintGrid10Brush As Brush = Brushes.Black
    Friend oPrintGrid10Pen = New Pen(oPrintGrid10Brush, oPrintGrid10width)
    Friend oPrintCentrewidth As Integer = 2
    Friend oPrintCentreBrush As Brush = Brushes.Black
    Friend oPrintCentrePen = New Pen(oPrintCentreBrush, oPrintCentrewidth)
#End Region
#Region "form control handlers"
    Private Sub FrmPrintProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening print", MyBase.Name)
        GetFormPos(Me, My.Settings.PrintFormPos)
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.PrintFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        Try
            Dim x As Integer = Math.Floor((oLeftMargin + oPrinterHardMarginX) / PageToFormRatio)
            Dim y As Integer = Math.Floor((oTopMargin + oPrinterHardMarginY) / PageToFormRatio)
            Dim w As Integer = Math.Floor(oPageImage.Width / PageToFormRatio)
            Dim h As Integer = Math.Floor(oPageImage.Height / PageToFormRatio)
            Dim w2 As Integer = Math.Floor(oAvailableGridWidth / PageToFormRatio)
            Dim h2 As Integer = Math.Floor(oAvailableGridHeight / PageToFormRatio)
            oFormImage = New Bitmap(New ImageUtil().ExtractCroppedAreaFromImage(oPageImage, oAvailableCellsWidth * oPagePixelsPerCell, oAvailableCellsHeight * oPagePixelsPerCell, 0, 0), w2, h2)
            e.Graphics.DrawImage(oFormImage, x, y, New Rectangle(0, 0, w2, h2), GraphicsUnit.Pixel)
        Catch ex As ApplicationException
            LogUtil.ShowException(ex, "DisplayImage", LblStatus, MyBase.Name)
        End Try
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isLoading = True
        '      BtnPrint.Enabled = False
        PageToFormRatio = Math.Ceiling(A4_WIDTH / PicDesign.Width)
        InitialisePrintDocument()
        ' Set handler to print image 
        AddHandler myPrintDoc.PrintPage, AddressOf OnPrintImage
        LoadFormFromSettings()
        isLoading = False
        LoadFormFromProject()
    End Sub
    Private Sub LoadFormFromSettings()
        ChkPrintKey.Checked = My.Settings.isPrintKey
        CbKeyOrder.SelectedIndex = My.Settings.PrintKeyOrder
        ChkKeySeparate.Checked = My.Settings.isKeySeparate
        NudSqrPerInch.Value = My.Settings.PrintSquaresPerInch
        NudOverlap.Value = My.Settings.TilingOverlap
        CbShading.SelectedIndex = My.Settings.OverlapShading
        ChkShowPageOrder.Checked = My.Settings.isShowPageOrder
        CbAbbrKey.SelectedIndex = My.Settings.AbbrevKey
        NudTopMargin.Value = My.Settings.PrintMarginTop
        NudBottomMargin.Value = My.Settings.PrintMarginBottom
        NudLeftMargin.Value = My.Settings.PrintMarginLeft
        NudRightMargin.Value = My.Settings.PrintMarginRight
        ChkTitleAboveGrid.Checked = My.Settings.isTitleAboveGrid
        ChkTitleAboveKey.Checked = My.Settings.isTitleAboveKey
        TxtDesignBy.Text = My.Settings.DesignBy
        TxtCopyright.Text = My.Settings.CopyrightBy
        ChkPrintGrid.Checked = My.Settings.PrintGrid
        ChkCentreMarks.Checked = My.Settings.PrintCentreMarks
    End Sub
    Private Sub BtnSaveSettings_Click(sender As Object, e As EventArgs) Handles BtnSaveSettings.Click
        My.Settings.isPrintKey = ChkPrintKey.Checked
        My.Settings.PrintKeyOrder = CbKeyOrder.SelectedIndex
        My.Settings.isKeySeparate = ChkKeySeparate.Checked
        My.Settings.PrintSquaresPerInch = NudSqrPerInch.Value
        My.Settings.TilingOverlap = NudOverlap.Value
        My.Settings.OverlapShading = CbShading.SelectedIndex
        My.Settings.isShowPageOrder = ChkShowPageOrder.Checked
        My.Settings.AbbrevKey = CbAbbrKey.SelectedIndex
        My.Settings.PrintMarginTop = NudTopMargin.Value
        My.Settings.PrintMarginBottom = NudBottomMargin.Value
        My.Settings.PrintMarginLeft = NudLeftMargin.Value
        My.Settings.PrintMarginRight = NudRightMargin.Value
        My.Settings.isTitleAboveGrid = ChkTitleAboveGrid.Checked
        My.Settings.isTitleAboveKey = ChkTitleAboveKey.Checked
        My.Settings.DesignBy = TxtDesignBy.Text
        My.Settings.CopyrightBy = TxtCopyright.Text
        My.Settings.PrintGrid = ChkPrintGrid.Checked
        My.Settings.PrintCentreMarks = ChkCentreMarks.Checked
        My.Settings.Save()
    End Sub
    Private Sub LoadFormFromProject()
        TxtTitle.Text = oProject.ProjectName
        prtProjectThreads = FindProjectThreads(oProject.ProjectId)
        CalculateMargins(NudLeftMargin.Value, NudRightMargin.Value, NudTopMargin.Value, NudBottomMargin.Value)
        CreatePrintBitmap()
        CreatePageImage()
    End Sub

    Private Sub CreatePrintBitmap()
        '     oPrintBitmap = New Bitmap(A4_WIDTH_PIXELS, A4_HEIGHT_PIXELS)
        oPrintBitmap = New Bitmap(CInt(oProjectDesign.Columns * PRINT_PIXELS_PER_CELL) + oLeftMargin, CInt(oProjectDesign.Rows * PRINT_PIXELS_PER_CELL) + oTopMargin)
        oPrintGraphics = Graphics.FromImage(oPrintBitmap)
        oPrintGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        For Each _blockstitch In oProjectDesign.BlockStitches
            If _blockstitch.IsLoaded Then
                Select Case _blockstitch.StitchType
                    Case BlockStitchType.Full
                        PrintFullBlockStitch(_blockstitch, oPrintGraphics, oStitchDisplayStyle)
                    Case BlockStitchType.Half
                        PrintHalfBlockStitch(_blockstitch, True, oPrintGraphics)
                    Case BlockStitchType.Quarter
                        PrintQuarterBlockStitch(_blockstitch, oPrintGraphics)
                    Case BlockStitchType.ThreeQuarter
                        PrintThreeQuarterBlockStitch(_blockstitch, oPrintGraphics)
                    Case Else
                        PrintQuarterBlockStitch(_blockstitch, oPrintGraphics)
                End Select
            End If
        Next
        PrintGrid()
        If My.Settings.IsShowBackstitches Then
            For Each _backstitch In oProjectDesign.BackStitches
                PrintBackstitch(_backstitch, oPrintGraphics)
            Next
        End If
        If My.Settings.IsShowKnots Then
            For Each _knot As Knot In oProjectDesign.Knots
                PrintKnot(_knot, oPrintGraphics)
            Next
        End If
    End Sub
    Private Sub PrintFullBlockStitch(pBlockStitch As BlockStitch, ByRef pDesignGraphics As Graphics, pStitchDisplayStyle As StitchDisplayStyle)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockStitch.BlockPosition.X + iOriginX) * PRINT_PIXELS_PER_CELL) + oLeftMargin
        Dim pY As Integer = ((pBlockStitch.BlockPosition.Y + iOriginY) * PRINT_PIXELS_PER_CELL) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + PRINT_PIXELS_PER_CELL, pY)
        Dim _bl As New Point(pX, pY + PRINT_PIXELS_PER_CELL)
        Dim _br As New Point(pX + PRINT_PIXELS_PER_CELL, pY + PRINT_PIXELS_PER_CELL)
        Dim _size As New Size(PRINT_PIXELS_PER_CELL, PRINT_PIXELS_PER_CELL)
        oStitchPenWidth = Math.Max(2, PRINT_PIXELS_PER_CELL / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        If pStitchDisplayStyle = StitchDisplayStyle.Blocks Or pStitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
            pDesignGraphics.FillRectangle(New SolidBrush(_threadColour), New Rectangle(_tl, _size))
        End If
        If pStitchDisplayStyle = StitchDisplayStyle.Crosses Then
            pDesignGraphics.DrawLine(_crossPen, _tl, _br)
            pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If
        If pStitchDisplayStyle = StitchDisplayStyle.Strokes Then
            pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If
        If pStitchDisplayStyle = StitchDisplayStyle.BlackWhiteSymbols Or pStitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
            pDesignGraphics.DrawImage(MakePrintImage(pBlockStitch), New Rectangle(_tl, _size), 0, 0, PRINT_PIXELS_PER_CELL, PRINT_PIXELS_PER_CELL, GraphicsUnit.Pixel)
        End If
        If pStitchDisplayStyle = StitchDisplayStyle.ColouredSymbols Then
            Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(pBlockStitch.ProjThread.Thread)
            pDesignGraphics.DrawImage(MakePrintImage(pBlockStitch), New Rectangle(_tl, _size), 0, 0, PRINT_PIXELS_PER_CELL, PRINT_PIXELS_PER_CELL, GraphicsUnit.Pixel, _imageAttributes)
        End If
        _crossPen.Dispose()
    End Sub
    Public Function MakePrintImage(pBlockStitch As BlockStitch) As Image
        Dim _image As Image = New Bitmap(1, 1)
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Threads.Find(Function(p) p.ThreadId = pBlockStitch.ProjThread.ThreadId), ProjectThread)
        If _projectThread Is Nothing Then
            LogUtil.DisplayStatusMessage("Thread missing from project :" & vbCrLf & pBlockStitch.ProjThread.Thread.ToString, Nothing, "MakeImage", False)
        Else
            Dim _symbol As Symbol = FindSymbolById(_projectThread.SymbolId)
            _image = ImageUtil.ResizeImage(_symbol.SymbolImage, PRINT_PIXELS_PER_CELL, PRINT_PIXELS_PER_CELL)
        End If
        Return _image
    End Function
    Public Sub PrintHalfBlockStitch(pBlockStitch As BlockStitch, pIsBack As Boolean, ByRef pDesignGraphics As Graphics)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockStitch.BlockPosition.X + iOriginX) * PRINT_PIXELS_PER_CELL) + oLeftMargin
        Dim pY As Integer = ((pBlockStitch.BlockPosition.Y + iOriginY) * PRINT_PIXELS_PER_CELL) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + PRINT_PIXELS_PER_CELL, pY)
        Dim _bl As New Point(pX, pY + PRINT_PIXELS_PER_CELL)
        Dim _br As New Point(pX + PRINT_PIXELS_PER_CELL, pY + PRINT_PIXELS_PER_CELL)
        oStitchPenWidth = Math.Max(2, PRINT_PIXELS_PER_CELL / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Dim _cellLocation As New Point(pX, pY)
        If pIsBack Then
            pDesignGraphics.DrawLine(_crossPen, _tl, _br)
        Else
            pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If
        _crossPen.Dispose()

    End Sub
    Public Sub PrintThreeQuarterBlockStitch(pBlockstitch As BlockStitch, ByRef pDesignGraphics As Graphics)
        Dim _threadColour As Color = pBlockstitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockstitch.BlockPosition.X + iOriginX) * PRINT_PIXELS_PER_CELL) + oLeftMargin
        Dim pY As Integer = ((pBlockstitch.BlockPosition.Y + iOriginY) * PRINT_PIXELS_PER_CELL) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + PRINT_PIXELS_PER_CELL, pY)
        Dim _bl As New Point(pX, pY + PRINT_PIXELS_PER_CELL)
        Dim _br As New Point(pX + PRINT_PIXELS_PER_CELL, pY + PRINT_PIXELS_PER_CELL)
        oStitchPenWidth = Math.Max(2, PRINT_PIXELS_PER_CELL / 8)

        Dim _cellLocation As New Point(pX, pY)

        Dim _rectSize As Integer = Math.Floor(PRINT_PIXELS_PER_CELL / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _middlePoint As New Point(_middleX, _middleY)
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay

        '     For Each _qtr As BlockStitchQuarter In pBlockstitch.Quarters

        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
        .StartCap = Drawing2D.LineCap.Round,
        .EndCap = Drawing2D.LineCap.Round
    }
        Select Case pBlockstitch.BlockQuarter
            Case BlockQuarter.TopLeft
                pDesignGraphics.DrawLine(_crossPen, _tl, _middlePoint)
                pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
            Case BlockQuarter.TopRight
                pDesignGraphics.DrawLine(_crossPen, _tr, _middlePoint)
                pDesignGraphics.DrawLine(_crossPen, _tl, _br)
            Case BlockQuarter.BottomLeft
                pDesignGraphics.DrawLine(_crossPen, _bl, _middlePoint)
                pDesignGraphics.DrawLine(_crossPen, _tl, _br)
            Case BlockQuarter.BottomRight
                pDesignGraphics.DrawLine(_crossPen, _br, _middlePoint)
                pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End Select
        _crossPen.Dispose()

    End Sub

    Public Sub PrintQuarterBlockStitch(pBlockstitch As BlockStitch, ByRef pDesignGraphics As Graphics)
        Dim pX As Integer = ((pBlockstitch.BlockPosition.X + iOriginX) * PRINT_PIXELS_PER_CELL) + oLeftMargin
        Dim pY As Integer = ((pBlockstitch.BlockPosition.Y + iOriginY) * PRINT_PIXELS_PER_CELL) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + PRINT_PIXELS_PER_CELL, pY)
        Dim _bl As New Point(pX, pY + PRINT_PIXELS_PER_CELL)
        Dim _br As New Point(pX + PRINT_PIXELS_PER_CELL, pY + PRINT_PIXELS_PER_CELL)
        oStitchPenWidth = Math.Max(2, PRINT_PIXELS_PER_CELL / 8)
        Dim _cellLocation As New Point(pX, pY)
        Dim _rectSize As Integer = Math.Floor(PRINT_PIXELS_PER_CELL / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay
        For Each _qtr As BlockStitchQuarter In pBlockstitch.Quarters
            Dim _threadColour As Color = _qtr.Thread.Colour
            Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
            Select Case _qtr.BlockQuarter
                Case BlockQuarter.TopLeft
                    pDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY)
                Case BlockQuarter.TopRight
                    pDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + PRINT_PIXELS_PER_CELL, pY)
                Case BlockQuarter.BottomLeft
                    pDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY + PRINT_PIXELS_PER_CELL)
                Case BlockQuarter.BottomRight
                    pDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + PRINT_PIXELS_PER_CELL, pY + PRINT_PIXELS_PER_CELL)
            End Select
            _crossPen.Dispose()
        Next
    End Sub

    Public Sub PrintBackstitch(pBackstitch As BackStitch, ByRef pDesignGraphics As Graphics)
        If isBackstitchWidthVariable Then
            oStitchPenWidth = Math.Max(2, PRINT_PIXELS_PER_CELL / oVariableWidthFraction)
        Else
            oStitchPenWidth = oBackstitchPenDefaultWidth
        End If
        Dim _fromCellLocation_x As Integer = ((pBackstitch.FromBlockPosition.X + iOriginX) * PRINT_PIXELS_PER_CELL) + oLeftMargin
        Dim _fromCellLocation_y As Integer = ((pBackstitch.FromBlockPosition.Y + iOriginY) * PRINT_PIXELS_PER_CELL) + oTopMargin
        Dim _toCellLocation_x As Integer = ((pBackstitch.ToBlockPosition.X + iOriginX) * PRINT_PIXELS_PER_CELL) + oLeftMargin
        Dim _toCellLocation_y As Integer = ((pBackstitch.ToBlockPosition.Y + iOriginY) * PRINT_PIXELS_PER_CELL) + oTopMargin
        Dim _pen As New Pen(pBackstitch.ProjThread.Thread.Colour, oStitchPenWidth * pBackstitch.Strands) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Select Case pBackstitch.FromBlockQuarter
            Case BlockQuarter.TopRight
                _fromCellLocation_x += PRINT_PIXELS_PER_CELL / 2
            Case BlockQuarter.BottomLeft
                _fromCellLocation_y += PRINT_PIXELS_PER_CELL / 2
            Case BlockQuarter.BottomRight
                _fromCellLocation_x += PRINT_PIXELS_PER_CELL / 2
                _fromCellLocation_y += PRINT_PIXELS_PER_CELL / 2
        End Select
        Select Case pBackstitch.ToBlockQuarter
            Case BlockQuarter.TopRight
                _toCellLocation_x += PRINT_PIXELS_PER_CELL / 2
            Case BlockQuarter.BottomLeft
                _toCellLocation_y += PRINT_PIXELS_PER_CELL / 2
            Case BlockQuarter.BottomRight
                _toCellLocation_x += PRINT_PIXELS_PER_CELL / 2
                _toCellLocation_y += PRINT_PIXELS_PER_CELL / 2
        End Select
        pDesignGraphics.DrawLine(_pen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
    End Sub

    Public Sub PrintKnot(pKnot As Knot, pDesignGraphics As Graphics)
        Dim _knotlocation_x As Integer = ((pKnot.BlockPosition.X + iOriginX) * PRINT_PIXELS_PER_CELL) - (PRINT_PIXELS_PER_CELL / 4) + oLeftMargin
        Dim _knotlocation_y As Integer = ((pKnot.BlockPosition.Y + iOriginY) * PRINT_PIXELS_PER_CELL) - (PRINT_PIXELS_PER_CELL / 4) + oTopMargin
        Select Case pKnot.BlockQuarter
            Case BlockQuarter.BottomLeft
                _knotlocation_y += PRINT_PIXELS_PER_CELL / 2
            Case BlockQuarter.BottomRight
                _knotlocation_y += PRINT_PIXELS_PER_CELL / 2
                _knotlocation_x += PRINT_PIXELS_PER_CELL / 2
            Case BlockQuarter.TopRight
                _knotlocation_x += PRINT_PIXELS_PER_CELL / 2
        End Select
        Dim _rect As New Rectangle(_knotlocation_x, _knotlocation_y, PRINT_PIXELS_PER_CELL / 2, PRINT_PIXELS_PER_CELL / 2)
        Dim _brush As New SolidBrush(pKnot.ProjThread.Thread.Colour)
        pDesignGraphics.FillEllipse(_brush, _rect)
    End Sub




    Public Sub PrintGrid()
        Dim _widthInColumns As Integer = oProjectDesign.Columns
        Dim _heightInRows As Integer = oProjectDesign.Rows
        Dim gap As Integer = PRINT_PIXELS_PER_CELL
        Dim _printBorderPen As New Pen(Brushes.Black, 2)
        Dim _middleColumn As Integer = Math.Floor(_widthInColumns / 2)
        Dim _middleRow As Integer = Math.Floor(_heightInRows / 2)

        If ChkPrintGrid.Checked Then
            For x = 0 To _widthInColumns
                oPrintGraphics.DrawLine(oPrintGrid1Pen, New Point((gap * x) + oLeftMargin, oTopMargin), New Point(gap * x + oLeftMargin, Math.Min(gap * _heightInRows, oPrintBitmap.Height) + oTopMargin))
            Next
            For y = 0 To _heightInRows
                oPrintGraphics.DrawLine(oPrintGrid1Pen, New Point(oLeftMargin, gap * y + oTopMargin), New Point(Math.Min(gap * _widthInColumns, oPrintBitmap.Width) + oLeftMargin, (gap * y) + oTopMargin))
            Next
            For x = 5 To _widthInColumns Step 10
                oPrintGraphics.DrawLine(oPrintGrid5Pen, New Point((gap * x) + oLeftMargin, oTopMargin), New Point(gap * x + oLeftMargin, Math.Min(gap * _heightInRows, oPrintBitmap.Height) + oTopMargin))
            Next
            For y = 5 To _heightInRows Step 10
                oPrintGraphics.DrawLine(oPrintGrid5Pen, New Point(oLeftMargin, gap * y + oTopMargin), New Point(Math.Min(gap * _widthInColumns, oPrintBitmap.Width) + oLeftMargin, (gap * y) + oTopMargin))
            Next
            For x = 10 To _widthInColumns Step 10
                oPrintGraphics.DrawLine(oPrintGrid10Pen, New Point((gap * x) + oLeftMargin, oTopMargin), New Point(gap * x + oLeftMargin, Math.Min(gap * _heightInRows, oPrintBitmap.Height) + oTopMargin))
            Next
            For y = 10 To _heightInRows Step 10
                oPrintGraphics.DrawLine(oPrintGrid10Pen, New Point(oLeftMargin, gap * y + oTopMargin), New Point(Math.Min(gap * _widthInColumns, oPrintBitmap.Width) + oLeftMargin, (gap * y) + oTopMargin))
            Next
        End If
        Dim _markHalfWidth As Integer = Math.Max(8, Math.Ceiling(PRINT_PIXELS_PER_CELL * 0.5))
        Dim _markHeight As Integer = Math.Max(12, Math.Ceiling(PRINT_PIXELS_PER_CELL * 0.75))
        Dim _middleColumnPos As Integer = (gap * _middleColumn) + oLeftMargin
        Dim _middleRowPos As Integer = (gap * _middleRow) + oTopMargin
        Dim _gridHeight As Integer = gap * _heightInRows
        Dim _gridWidth As Integer = gap * _widthInColumns
        Dim _topMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, gap - _markHeight + oTopMargin),
                                         New Point(_middleColumnPos + _markHalfWidth, gap - _markHeight + oTopMargin),
                                         New Point(_middleColumnPos, gap + oTopMargin)}
        Dim _leftMarkPoints As Point() = {New Point(gap - _markHeight + oLeftMargin, _middleRowPos - _markHalfWidth),
                                          New Point(gap - _markHeight + oLeftMargin, _middleRowPos + _markHalfWidth),
                                          New Point(gap + oLeftMargin, _middleRowPos)}
        Dim _bottomMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, _gridHeight - gap + _markHeight + oTopMargin),
                                            New Point(_middleColumnPos + _markHalfWidth, _gridHeight - gap + _markHeight + oTopMargin),
                                            New Point(_middleColumnPos, _gridHeight - gap + oTopMargin)}
        Dim _rightMarkPoints As Point() = {New Point(_gridWidth - gap + _markHeight + oLeftMargin, (_middleRowPos - _markHalfWidth)),
                                           New Point(_gridWidth - gap + _markHeight + oLeftMargin, _middleRowPos + _markHalfWidth),
                                           New Point(_gridWidth - gap + oLeftMargin, _middleRowPos)}
        If ChkCentreMarks.Checked Then
            oPrintGraphics.DrawLine(oPrintCentrePen, New Point(oLeftMargin, (gap * _middleRow) + oTopMargin), New Point(Math.Min(gap * _widthInColumns, oPrintBitmap.Width) + oLeftMargin, (gap * _middleRow) + oTopMargin))
            oPrintGraphics.DrawLine(oPrintCentrePen, New Point((gap * _middleColumn) + oLeftMargin, oTopMargin), New Point((gap * _middleColumn) + oLeftMargin, Math.Min(gap * _heightInRows, oPrintBitmap.Height) + oTopMargin))
            oPrintGraphics.FillPolygon(oPrintCentreBrush, _topMarkPoints)
            oPrintGraphics.FillPolygon(oPrintCentreBrush, _leftMarkPoints)
            oPrintGraphics.FillPolygon(oPrintCentreBrush, _bottomMarkPoints)
            oPrintGraphics.FillPolygon(oPrintCentreBrush, _rightMarkPoints)
        End If

        oPrintGraphics.DrawRectangle(_printBorderPen, New Rectangle(oLeftMargin, oTopMargin, Math.Min(gap * _widthInColumns, oPrintBitmap.Width - oleftmargin), Math.Min(gap * _heightInRows, oPrintBitmap.Height - otopmargin)))
        _printBorderPen.Dispose()

    End Sub
    Private Sub CreatePageImage()
        oPagePixelsPerCell = Math.Floor(DPI / NudSqrPerInch.Value)
        CalculateGridSpace(NudSqrPerInch.Value)
        Dim _tw As Integer = oPrintBitmap.Width - oLeftMargin
        Dim _th As Integer = oPrintBitmap.Height - oTopMargin
        Dim cropped As Image = New ImageUtil().ExtractCroppedAreaFromImage(oPrintBitmap, _tw, _th, oLeftMargin, oTopMargin)
        oPageImage = ImageUtil.ResizeImage(cropped, oProject.DesignWidth * oPagePixelsPerCell, oProject.DesignHeight * oPagePixelsPerCell)
        PicTest.Image = oPageImage
        PicDesign.Invalidate()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        LogUtil.ShowStatus("Printing design", LblStatus, MyBase.Name)
        ' create images to be printed
        ' Print the image (calls PrintPage handler (see above))
        myPrintDoc.Print()

    End Sub
    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        LogUtil.ShowStatus("Sending card to printer", LblStatus, MyBase.Name)
        'print options
        ' 0 = print to fill available space
        ' 1 =
        ' 2 = print maximum size retaining aspect ratio
        ' 3 = print into half the available space
        ' 4 = print actual size

        ' DRAW THE IMAGE scaled to the print area

        ' Set margins to allow for printers hard margins
        'leftmargin = e.PageSettings.HardMarginX * 3
        'topmargin = e.PageSettings.HardMarginY * 3



        Dim targetWidth As Integer = Math.Min(oAvailableGridWidth, oPrintBitmap.Width) - oLeftMargin
        Dim targetHeight As Integer = Math.Min(oAvailableGridHeight, oPrintBitmap.Height) - oTopMargin

        Dim _croppedImage As Image = New ImageUtil().ExtractCroppedAreaFromImage(oPrintBitmap, targetWidth, targetHeight, oLeftMargin, oTopMargin)
        PicTest.Image = _croppedImage
        ' Print the image, cutting off the left and top parts that the printer cannot print
        ' e.Graphics.DrawImage(_croppedImage, 0, 0, New Rectangle(oLeftMargin, oTopMargin, targetWidth, targetHeight), GraphicsUnit.Document)
        '   e.Graphics.DrawImage(_croppedImage, 0, 0)
        e.Graphics.DrawImage(oPrintBitmap, 0, 0, New Rectangle(oLeftMargin, oTopMargin, targetWidth, targetHeight), GraphicsUnit.Pixel)

        LogUtil.ShowStatus("Printing done", LblStatus, MyBase.Name)
    End Sub

    Private Sub NudTopMargin_ValueChanged(sender As Object, e As EventArgs) Handles NudTopMargin.ValueChanged,
                                                                                    NudLeftMargin.ValueChanged,
                                                                                    NudRightMargin.ValueChanged,
                                                                                    NudBottomMargin.ValueChanged,
                                                                                    ChkPrintGrid.CheckedChanged,
                                                                                    ChkCentreMarks.CheckedChanged,
                                                                                    NudSqrPerInch.ValueChanged
        If isComponentInitialised And Not isLoading Then
            LoadFormFromProject()
        End If
    End Sub
#End Region
End Class