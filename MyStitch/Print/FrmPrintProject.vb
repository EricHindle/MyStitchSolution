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
#Region "classes"
    Friend Class Page
        Private _topLeft As Point
        Private _bottomRight As Point
        Private _pagePosition As Point
        Private _midCol As Integer
        Private _midRow As Integer
        Private _borders As Boolean()    'top,right,bottom,left
        Public Property BottomRight() As Point
            Get
                Return _bottomRight
            End Get
            Set(ByVal value As Point)
                _bottomRight = value
            End Set
        End Property
        Public Property TopLeft() As Point
            Get
                Return _topLeft
            End Get
            Set(ByVal value As Point)
                _topLeft = value
            End Set
        End Property

        Public Property Borders() As Boolean()
            Get
                Return _borders
            End Get
            Set(ByVal value As Boolean())
                _borders = value
            End Set
        End Property
        Public Property MidRow() As Integer
            Get
                Return _midRow
            End Get
            Set(ByVal value As Integer)
                _midRow = value
            End Set
        End Property
        Public Property MidCol() As Integer
            Get
                Return _midCol
            End Get
            Set(ByVal value As Integer)
                _midCol = value
            End Set
        End Property
        Public Property PagePosition() As Point
            Get
                Return _pagePosition
            End Get
            Set(ByVal value As Point)
                _pagePosition = value
            End Set
        End Property
        Public Sub New()
            Initialise()
        End Sub

        Private Sub Initialise()
            _topLeft = New Point(0, 0)
            _bottomRight = New Point(0, 0)
            _pagePosition = New Point(0, 0)
            _midCol = 0
            _midRow = 0
            _borders = {False, False, False, False}
        End Sub

        Public Function Clone() As Page
            Dim _clone As New Page
            With _clone
                .TopLeft = _topLeft
                .BottomRight = _bottomRight
                .PagePosition = _pagePosition
                .MidCol =
                .MidRow = _midRow
                .Borders = _borders
            End With
            Return _clone
        End Function
    End Class
#End Region
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
#Region "enum"
    Private Enum Borders
        Top
        Right
        Bottom
        Left
    End Enum
#End Region
#Region "variables"
    Private isComponentInitialised As Boolean
    Private oPageToFormRatio As Decimal

    Private gap As Integer
    Private _printBorderPen As New Pen(Brushes.Black, 2)

    Private oFormImage As Bitmap
    Private isPrintLoading As Boolean = False
    Private isPagesLoaded As Boolean = False
    'Private myPageSetUp As PageSetupDialog
    'Private myStringFormat As StringFormat
    'Private myFont As Font

    'Private oSourceImage As Image

    Private oPrintBitmap As Bitmap
    Private oPrintGraphics As Graphics
    Private oPageList As List(Of Page)
    Private oSelectedPage As New Page
    'Private isPrintGrid As Boolean
    'Private isPrintCentreLines As Boolean
    Friend oPrintGrid1width As Integer = 1
    Friend oPrintGrid1Brush As Brush = Brushes.Black
    Friend oPrintGrid1Pen = New Pen(oPrintGrid1Brush, oPrintGrid1width)
    Friend oPrintGrid5width As Integer = 1
    Friend oPrintGrid5Brush As Brush = Brushes.Black
    Friend oPrintGrid5Pen = New Pen(oPrintGrid5Brush, oPrintGrid5width)
    Friend oPrintGrid10width As Integer = 2
    Friend oPrintGrid10Brush As Brush = Brushes.Black
    Friend oPrintGrid10Pen = New Pen(oPrintGrid10Brush, oPrintGrid10width)
    'Friend oPrintCentrewidth As Integer = 2
    'Friend oPrintCentreBrush As Brush = Brushes.Black
    'Friend oPrintCentrePen = New Pen(oPrintCentreBrush, oPrintCentrewidth)
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
    Private Sub CmbInstalledPrinters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbInstalledPrinters.SelectedIndexChanged
        If Not isPrintLoading AndAlso oPrintDoc IsNot Nothing Then
            oPrintDoc.PrinterSettings.PrinterName = CmbInstalledPrinters.SelectedItem
        End If
    End Sub
    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        oPagePixelsPerCell = Math.Floor((DPI / NudSqrPerInch.Value) / oPageToFormRatio)
        CreatePageGraphics(oSelectedPage, e.Graphics, PicDesign.Size)

        'Try
        '    Dim x As Integer = Math.Floor((oLeftMargin + oPrinterHardMarginX) / PageToFormRatio)
        '    Dim y As Integer = Math.Floor((oTopMargin + oPrinterHardMarginY) / PageToFormRatio)
        '    Dim w As Integer = Math.Floor(oPageImage.Width / PageToFormRatio)
        '    Dim h As Integer = Math.Floor(oPageImage.Height / PageToFormRatio)
        '    Dim w2 As Integer = Math.Floor(oAvailableGridWidth / PageToFormRatio)
        '    Dim h2 As Integer = Math.Floor(oAvailableGridHeight / PageToFormRatio)
        '    oFormImage = New Bitmap(New ImageUtil().ExtractCroppedAreaFromImage(oPageImage, oAvailableCellsWidth * oPagePixelsPerCell, oAvailableCellsHeight * oPagePixelsPerCell, 0, 0), w2, h2)
        '    e.Graphics.DrawImage(oFormImage, x, y, New Rectangle(0, 0, w2, h2), GraphicsUnit.Pixel)
        'Catch ex As ApplicationException
        '    LogUtil.ShowException(ex, "DisplayImage", LblStatus, MyBase.Name)
        'End Try
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isPrintLoading = True
        oPageToFormRatio = Math.Ceiling(A4_WIDTH / PicDesign.Width)
        InitialisePrintDocument()
        LoadInstalledPrinters()
        ' Set handler to print image 
        AddHandler oPrintDoc.PrintPage, AddressOf OnPrintImage
        LoadFormFromSettings()
        isPrintLoading = False
        LoadFormFromProject()
    End Sub
    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
    Private Sub LoadFormFromSettings()
        ChkPrintKey.Checked = My.Settings.isPrintKey
        CbKeyOrder.SelectedIndex = My.Settings.PrintKeyOrder
        ChkKeySeparate.Checked = My.Settings.isKeySeparate
        NudSqrPerInch.Value = My.Settings.PrintSquaresPerInch
        NudOverlap.Value = My.Settings.TilingOverlap
        CbShading.SelectedIndex = My.Settings.OverlapShading
        ChkShowPageOrder.Checked = My.Settings.isShowPageOrder
        CbAbbrKey.SelectedIndex = My.Settings.AbbrevKey
        NudTopMargin.Minimum = oPageSettings.HardMarginY / 100
        NudTopMargin.Value = Math.Max(My.Settings.PrintMarginTop, NudTopMargin.Minimum)
        NudBottomMargin.Minimum = oPageSettings.HardMarginY / 100
        NudBottomMargin.Value = Math.Max(My.Settings.PrintMarginBottom, NudBottomMargin.Minimum)
        NudLeftMargin.Minimum = oPageSettings.HardMarginX / 100
        NudLeftMargin.Value = Math.Max(My.Settings.PrintMarginLeft, NudLeftMargin.Minimum)
        NudRightMargin.Minimum = oPageSettings.HardMarginX / 100
        NudRightMargin.Value = Math.Max(My.Settings.PrintMarginRight, NudRightMargin.Minimum)
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
        oPrintProjectThreads = FindProjectThreads(oProject.ProjectId)
        CalculateMargins(NudLeftMargin.Value, NudRightMargin.Value, NudTopMargin.Value, NudBottomMargin.Value)
        oPagePixelsPerCell = Math.Floor(DPI / NudSqrPerInch.Value)
        CalculateGridSpace(NudSqrPerInch.Value)
        InitialisePageLists()
        '    CreatePrintBitmaps()
        'CreatePageImage()
    End Sub
    Private Sub CreatePageGraphics(pPage As Page, ByRef pPageGraphics As Graphics, pSize As Size)
        gap = oPagePixelsPerCell
        pPageGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        For Each _blockstitch In oProjectDesign.BlockStitches
            If _blockstitch.BlockPosition.X >= pPage.TopLeft.X _
            And _blockstitch.BlockPosition.X <= pPage.BottomRight.X _
            And _blockstitch.BlockPosition.Y >= pPage.TopLeft.Y _
            And _blockstitch.BlockPosition.Y < pPage.BottomRight.Y Then
                If _blockstitch.IsLoaded Then
                    Select Case _blockstitch.StitchType
                        Case BlockStitchType.Full
                            PrintFullBlockStitch(_blockstitch, pPageGraphics, oStitchDisplayStyle, pPage)
                        Case BlockStitchType.Half
                            PrintHalfBlockStitch(_blockstitch, True, pPageGraphics, pPage)
                        Case BlockStitchType.Quarter
                            PrintQuarterBlockStitch(_blockstitch, pPageGraphics, pPage)
                        Case BlockStitchType.ThreeQuarter
                            PrintThreeQuarterBlockStitch(_blockstitch, pPageGraphics, pPage)
                        Case Else
                            PrintQuarterBlockStitch(_blockstitch, pPageGraphics, pPage)
                    End Select
                End If
            End If
        Next
        PrintGrid(pPage, pPageGraphics, pSize)
        If My.Settings.IsShowBackstitches Then
            For Each _backstitch In oProjectDesign.BackStitches
                If (_backstitch.FromBlockPosition.X >= pPage.TopLeft.X _
                    And _backstitch.FromBlockPosition.X <= pPage.BottomRight.X _
                    And _backstitch.FromBlockPosition.Y >= pPage.TopLeft.Y _
                    And _backstitch.FromBlockPosition.Y < pPage.BottomRight.Y) _
                Or
                        (_backstitch.ToBlockPosition.X >= pPage.TopLeft.X _
                    And _backstitch.ToBlockPosition.X <= pPage.BottomRight.X _
                    And _backstitch.ToBlockPosition.Y >= pPage.TopLeft.Y _
                    And _backstitch.ToBlockPosition.Y < pPage.BottomRight.Y) Then
                    PrintBackstitch(_backstitch, pPageGraphics, pPage)
                End If
            Next
        End If
        If My.Settings.IsShowKnots Then
            For Each _knot As Knot In oProjectDesign.Knots
                If _knot.BlockPosition.X >= pPage.TopLeft.X _
            And _knot.BlockPosition.X <= pPage.BottomRight.X _
            And _knot.BlockPosition.Y >= pPage.TopLeft.Y _
            And _knot.BlockPosition.Y < pPage.BottomRight.Y Then
                    PrintKnot(_knot, pPageGraphics, pPage)
                End If
            Next
        End If
    End Sub
    'Private Sub CreatePrintBitmaps()
    '    gap = oPagePixelsPerCell

    '    '   For Each _pageList As List(Of Page) In oPageList
    '    For Each _page As Page In oPageList
    '        _page.PageBitmap = New Bitmap(A4_WIDTH, A4_HEIGHT)
    '        Dim _pageGraphics As Graphics = Graphics.FromImage(_page.PageBitmap)
    '        _pageGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '        For Each _blockstitch In oProjectDesign.BlockStitches
    '            If _blockstitch.IsLoaded Then
    '                Select Case _blockstitch.StitchType
    '                    Case BlockStitchType.Full
    '                        PrintFullBlockStitch(_blockstitch, _pageGraphics, oStitchDisplayStyle)
    '                    Case BlockStitchType.Half
    '                        PrintHalfBlockStitch(_blockstitch, True, _pageGraphics)
    '                    Case BlockStitchType.Quarter
    '                        PrintQuarterBlockStitch(_blockstitch, _pageGraphics)
    '                    Case BlockStitchType.ThreeQuarter
    '                        PrintThreeQuarterBlockStitch(_blockstitch, _pageGraphics)
    '                    Case Else
    '                        PrintQuarterBlockStitch(_blockstitch, _pageGraphics)
    '                End Select
    '            End If
    '        Next
    '        PrintGrid()
    '        If My.Settings.IsShowBackstitches Then
    '            For Each _backstitch In oProjectDesign.BackStitches
    '                PrintBackstitch(_backstitch, _pageGraphics)
    '            Next
    '        End If
    '        If My.Settings.IsShowKnots Then
    '            For Each _knot As Knot In oProjectDesign.Knots
    '                PrintKnot(_knot, _pageGraphics)
    '            Next
    '        End If
    '    Next
    '    '  Next
    'End Sub
    Friend Sub PrintFullBlockStitch(pBlockStitch As BlockStitch, ByRef pDesignGraphics As Graphics, pStitchDisplayStyle As StitchDisplayStyle, pPage As Page)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockStitch.BlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockStitch.BlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        Dim _size As New Size(oPagePixelsPerCell, oPagePixelsPerCell)
        oStitchPenWidth = Math.Max(2, oPagePixelsPerCell / 8)
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
            pDesignGraphics.DrawImage(MakePrintImage(pBlockStitch), New Rectangle(_tl, _size), 0, 0, oPagePixelsPerCell, oPagePixelsPerCell, GraphicsUnit.Pixel)
        End If
        If pStitchDisplayStyle = StitchDisplayStyle.ColouredSymbols Then
            Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(pBlockStitch.ProjThread.Thread)
            pDesignGraphics.DrawImage(MakePrintImage(pBlockStitch), New Rectangle(_tl, _size), 0, 0, oPagePixelsPerCell, oPagePixelsPerCell, GraphicsUnit.Pixel, _imageAttributes)
        End If
        _crossPen.Dispose()
    End Sub
    Friend Function MakePrintImage(pBlockStitch As BlockStitch) As Image
        Dim _image As Image = New Bitmap(1, 1)
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Threads.Find(Function(p) p.ThreadId = pBlockStitch.ProjThread.ThreadId), ProjectThread)
        If _projectThread Is Nothing Then
            LogUtil.DisplayStatusMessage("Thread missing from project :" & vbCrLf & pBlockStitch.ProjThread.Thread.ToString, Nothing, "MakeImage", False)
        Else
            Dim _symbol As Symbol = FindSymbolById(_projectThread.SymbolId)
            _image = ImageUtil.ResizeImage(_symbol.SymbolImage, oPagePixelsPerCell, oPagePixelsPerCell)
        End If
        Return _image
    End Function
    Friend Sub PrintHalfBlockStitch(pBlockStitch As BlockStitch, pIsBack As Boolean, ByRef pDesignGraphics As Graphics, pPage As Page)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockStitch.BlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockStitch.BlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        oStitchPenWidth = Math.Max(2, oPagePixelsPerCell / 8)
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
    Friend Sub PrintThreeQuarterBlockStitch(pBlockstitch As BlockStitch, ByRef pDesignGraphics As Graphics, pPage As Page)
        Dim _threadColour As Color = pBlockstitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockstitch.BlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockstitch.BlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        oStitchPenWidth = Math.Max(2, oPagePixelsPerCell / 8)

        Dim _cellLocation As New Point(pX, pY)

        Dim _rectSize As Integer = Math.Floor(oPagePixelsPerCell / 2)
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

    Friend Sub PrintQuarterBlockStitch(pBlockstitch As BlockStitch, ByRef pDesignGraphics As Graphics, pPage As Page)
        Dim pX As Integer = ((pBlockstitch.BlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockstitch.BlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        oStitchPenWidth = Math.Max(2, oPagePixelsPerCell / 8)
        Dim _cellLocation As New Point(pX, pY)
        Dim _rectSize As Integer = Math.Floor(oPagePixelsPerCell / 2)
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
                    pDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + oPagePixelsPerCell, pY)
                Case BlockQuarter.BottomLeft
                    pDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY + oPagePixelsPerCell)
                Case BlockQuarter.BottomRight
                    pDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
            End Select
            _crossPen.Dispose()
        Next
    End Sub

    Friend Sub PrintBackstitch(pBackstitch As BackStitch, ByRef pDesignGraphics As Graphics, pPage As Page)
        If isBackstitchWidthVariable Then
            oStitchPenWidth = Math.Max(2, oPagePixelsPerCell / oVariableWidthFraction)
        Else
            oStitchPenWidth = oBackstitchPenDefaultWidth
        End If
        Dim _fromCellLocation_x As Integer = ((pBackstitch.FromBlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim _fromCellLocation_y As Integer = ((pBackstitch.FromBlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _toCellLocation_x As Integer = ((pBackstitch.ToBlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim _toCellLocation_y As Integer = ((pBackstitch.ToBlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _pen As New Pen(pBackstitch.ProjThread.Thread.Colour, oStitchPenWidth * pBackstitch.Strands) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Select Case pBackstitch.FromBlockQuarter
            Case BlockQuarter.TopRight
                _fromCellLocation_x += oPagePixelsPerCell / 2
            Case BlockQuarter.BottomLeft
                _fromCellLocation_y += oPagePixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _fromCellLocation_x += oPagePixelsPerCell / 2
                _fromCellLocation_y += oPagePixelsPerCell / 2
        End Select
        Select Case pBackstitch.ToBlockQuarter
            Case BlockQuarter.TopRight
                _toCellLocation_x += oPagePixelsPerCell / 2
            Case BlockQuarter.BottomLeft
                _toCellLocation_y += oPagePixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _toCellLocation_x += oPagePixelsPerCell / 2
                _toCellLocation_y += oPagePixelsPerCell / 2
        End Select
        pDesignGraphics.DrawLine(_pen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
    End Sub

    Friend Sub PrintKnot(pKnot As Knot, pDesignGraphics As Graphics, pPage As Page)
        Dim _knotlocation_x As Integer = ((pKnot.BlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) - (oPagePixelsPerCell / 4) + oLeftMargin
        Dim _knotlocation_y As Integer = ((pKnot.BlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) - (oPagePixelsPerCell / 4) + oTopMargin
        Select Case pKnot.BlockQuarter
            Case BlockQuarter.BottomLeft
                _knotlocation_y += oPagePixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _knotlocation_y += oPagePixelsPerCell / 2
                _knotlocation_x += oPagePixelsPerCell / 2
            Case BlockQuarter.TopRight
                _knotlocation_x += oPagePixelsPerCell / 2
        End Select
        Dim _rect As New Rectangle(_knotlocation_x, _knotlocation_y, oPagePixelsPerCell / 2, oPagePixelsPerCell / 2)
        Dim _brush As New SolidBrush(pKnot.ProjThread.Thread.Colour)
        pDesignGraphics.FillEllipse(_brush, _rect)
    End Sub
    Public Sub InitialisePageLists()
        oPageList = New List(Of Page)
        Dim _designMiddleColumn As Integer = Math.Floor(oProjectDesign.Columns / 2)
        Dim _designMiddleRow As Integer = Math.Floor(oProjectDesign.Rows / 2)
        Dim _pagesAcross As Integer
        Dim _pagesDown As Integer = 0
        Dim _pagesTotal As Integer = 0
        Dim _pageTopLeft As New Point(0, 0)
        Dim _rowsLeft As Integer = oProjectDesign.Rows
        Dim _colsLeft As Integer
        Dim _overlap As Integer = NudOverlap.Value
        Dim _newPage As New Page
        Do Until _rowsLeft <= 0
            _colsLeft = oProjectDesign.Columns
            _pagesAcross = 0
            Dim _pageRows As Integer
            If _pagesDown = 0 Then
                _pageRows = Math.Min(oAvailableCellsHeight, _rowsLeft)
                _rowsLeft -= oAvailableCellsHeight
            Else
                Math.Min(oAvailableCellsHeight - _overlap, _rowsLeft)
                _pageRows += _overlap
                _rowsLeft -= oAvailableCellsHeight
                _rowsLeft += _overlap
            End If

            Do Until _colsLeft <= 0
                _newPage = New Page
                Dim _pageColumns As Integer
                If _pagesAcross = 0 Then
                    _pageColumns = Math.Min(oAvailableCellsWidth, _colsLeft)
                    _colsLeft -= oAvailableCellsWidth
                    _newPage.Borders(Borders.Left) = True
                Else
                    Math.Min(oAvailableCellsWidth - _overlap, _colsLeft)
                    _pageColumns += _overlap
                    _colsLeft -= oAvailableCellsWidth
                    _colsLeft += _overlap
                End If
                If _colsLeft <= 0 Then
                    _newPage.Borders(Borders.Right) = True
                End If
                _newPage.PagePosition = New Point(_pagesAcross, _pagesDown)
                If _pagesDown = 0 Then
                    _newPage.Borders(Borders.Top) = True
                End If
                If _rowsLeft <= 0 Then
                    _newPage.Borders(Borders.Bottom) = True
                End If
                _pagesTotal += 1
                If _pagesTotal > 1 Then
                    TabControl1.TabPages.Add("Page " & CStr(_pagesTotal))
                End If
                _newPage.TopLeft = _pageTopLeft
                _newPage.BottomRight = New Point(_pageTopLeft.X + _pageColumns, _pageTopLeft.Y + _pageRows)
                Dim _page As Page = _newPage.Clone
                oPageList.Add(_page)
                _pageTopLeft = New Point(_pageTopLeft.X + _pageColumns + 1, _pageTopLeft.Y)
                _pagesAcross += 1
            Loop
            _pageTopLeft = New Point(0, _pageTopLeft.Y + _pageRows + 1)
            _pagesDown += 1
        Loop
        isPagesLoaded = True
        DisplayPageImage()
    End Sub
    Private Sub PrintGrid(pPage As Page, ByRef pPageGraphics As Graphics, pSize As Size)
        Dim _widthInColumns As Integer = pPage.BottomRight.X - pPage.TopLeft.X
        Dim _heightInRows As Integer = pPage.BottomRight.Y - pPage.TopLeft.Y

        If ChkPrintGrid.Checked Then
            For x = 0 To _widthInColumns
                pPageGraphics.DrawLine(oPrintGrid1Pen, New Point((gap * x) + oLeftMargin, oTopMargin), New Point(gap * x + oLeftMargin, Math.Min(gap * _heightInRows, pSize.Height) + oTopMargin))
            Next
            For y = 0 To _heightInRows
                pPageGraphics.DrawLine(oPrintGrid1Pen, New Point(oLeftMargin, gap * y + oTopMargin), New Point(Math.Min(gap * _widthInColumns, pSize.Width) + oLeftMargin, (gap * y) + oTopMargin))
            Next
            For x = 5 To _widthInColumns Step 10
                pPageGraphics.DrawLine(oPrintGrid5Pen, New Point((gap * x) + oLeftMargin, oTopMargin), New Point(gap * x + oLeftMargin, Math.Min(gap * _heightInRows, pSize.Height) + oTopMargin))
            Next
            For y = 5 To _heightInRows Step 10
                pPageGraphics.DrawLine(oPrintGrid5Pen, New Point(oLeftMargin, gap * y + oTopMargin), New Point(Math.Min(gap * _widthInColumns, pSize.Width) + oLeftMargin, (gap * y) + oTopMargin))
            Next
            For x = 10 To _widthInColumns Step 10
                pPageGraphics.DrawLine(oPrintGrid10Pen, New Point((gap * x) + oLeftMargin, oTopMargin), New Point(gap * x + oLeftMargin, Math.Min(gap * _heightInRows, pSize.Height) + oTopMargin))
            Next
            For y = 10 To _heightInRows Step 10
                pPageGraphics.DrawLine(oPrintGrid10Pen, New Point(oLeftMargin, gap * y + oTopMargin), New Point(Math.Min(gap * _widthInColumns, pSize.Width) + oLeftMargin, (gap * y) + oTopMargin))
            Next
        End If
        'Dim _markHalfWidth As Integer = Math.Max(8, Math.Ceiling(PRINT_PIXELS_PER_CELL * 0.5))
        'Dim _markHeight As Integer = Math.Max(12, Math.Ceiling(PRINT_PIXELS_PER_CELL * 0.75))
        'Dim _middleColumnPos As Integer = (gap * _middleColumn) + oLeftMargin
        'Dim _middleRowPos As Integer = (gap * _middleRow) + oTopMargin
        'Dim _gridHeight As Integer = gap * _heightInRows
        'Dim _gridWidth As Integer = gap * _widthInColumns
        'Dim _topMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, gap - _markHeight + oTopMargin),
        '                                 New Point(_middleColumnPos + _markHalfWidth, gap - _markHeight + oTopMargin),
        '                                 New Point(_middleColumnPos, gap + oTopMargin)}
        'Dim _leftMarkPoints As Point() = {New Point(gap - _markHeight + oLeftMargin, _middleRowPos - _markHalfWidth),
        '                                  New Point(gap - _markHeight + oLeftMargin, _middleRowPos + _markHalfWidth),
        '                                  New Point(gap + oLeftMargin, _middleRowPos)}
        'Dim _bottomMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, _gridHeight - gap + _markHeight + oTopMargin),
        '                                    New Point(_middleColumnPos + _markHalfWidth, _gridHeight - gap + _markHeight + oTopMargin),
        '                                    New Point(_middleColumnPos, _gridHeight - gap + oTopMargin)}
        'Dim _rightMarkPoints As Point() = {New Point(_gridWidth - gap + _markHeight + oLeftMargin, (_middleRowPos - _markHalfWidth)),
        '                                   New Point(_gridWidth - gap + _markHeight + oLeftMargin, _middleRowPos + _markHalfWidth),
        '                                   New Point(_gridWidth - gap + oLeftMargin, _middleRowPos)}
        'If ChkCentreMarks.Checked Then
        '    oPrintGraphics.DrawLine(oPrintCentrePen, New Point(oLeftMargin, (gap * _middleRow) + oTopMargin), New Point(Math.Min(gap * _widthInColumns, oPrintBitmap.Width) + oLeftMargin, (gap * _middleRow) + oTopMargin))
        '    oPrintGraphics.DrawLine(oPrintCentrePen, New Point((gap * _middleColumn) + oLeftMargin, oTopMargin), New Point((gap * _middleColumn) + oLeftMargin, Math.Min(gap * _heightInRows, oPrintBitmap.Height) + oTopMargin))
        '    oPrintGraphics.FillPolygon(oPrintCentreBrush, _topMarkPoints)
        '    oPrintGraphics.FillPolygon(oPrintCentreBrush, _leftMarkPoints)
        '    oPrintGraphics.FillPolygon(oPrintCentreBrush, _bottomMarkPoints)
        '    oPrintGraphics.FillPolygon(oPrintCentreBrush, _rightMarkPoints)
        'End If

        'oPrintGraphics.DrawRectangle(_printBorderPen, New Rectangle(oLeftMargin, oTopMargin, Math.Min(gap * _widthInColumns, oPrintBitmap.Width - oLeftMargin), Math.Min(gap * _heightInRows, oPrintBitmap.Height - oTopMargin)))
        '_printBorderPen.Dispose()

    End Sub
    'Private Sub CreatePageImage()

    '    Dim _tw As Integer = oPrintBitmap.Width - oLeftMargin
    '    Dim _th As Integer = oPrintBitmap.Height - oTopMargin
    '    Dim cropped As Image = New ImageUtil().ExtractCroppedAreaFromImage(oPrintBitmap, _tw, _th, oLeftMargin, oTopMargin)
    '    oPageImage = ImageUtil.ResizeImage(cropped, oProject.DesignWidth * oPagePixelsPerCell, oProject.DesignHeight * oPagePixelsPerCell)
    '    PicTest.Image = oPageImage
    '    PicDesign.Invalidate()
    'End Sub

    'Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
    '    LogUtil.ShowStatus("Printing design", LblStatus, MyBase.Name)
    '    ' create images to be printed
    '    ' Print the image (calls PrintPage handler (see above))
    '    oPrintDoc.Print()

    'End Sub

    'Private Sub NudTopMargin_ValueChanged(sender As Object, e As EventArgs) Handles NudTopMargin.ValueChanged,
    '                                                                                NudLeftMargin.ValueChanged,
    '                                                                                NudRightMargin.ValueChanged,
    '                                                                                NudBottomMargin.ValueChanged,
    '                                                                                ChkPrintGrid.CheckedChanged,
    '                                                                                ChkCentreMarks.CheckedChanged,
    '                                                                                NudSqrPerInch.ValueChanged
    '    If isComponentInitialised And Not isLoading Then
    '        LoadFormFromProject()
    '    End If
    'End Sub

    Private Sub LoadInstalledPrinters()
        For Each _installedPrinter As String In PrinterSettings.InstalledPrinters
            CmbInstalledPrinters.Items.Add(_installedPrinter)
            If (oPrintDoc.PrinterSettings.IsDefaultPrinter()) Then
                CmbInstalledPrinters.Text = oPrintDoc.PrinterSettings.PrinterName
            End If
        Next
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        DisplayPageImage()
    End Sub

    Private Sub DisplayPageImage()
        If isPagesLoaded Then
            oSelectedPage = oPageList(TabControl1.SelectedIndex)
            PicDesign.Invalidate()
        End If
    End Sub

#End Region
End Class