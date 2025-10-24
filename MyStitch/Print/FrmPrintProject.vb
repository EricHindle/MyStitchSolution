' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Text
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
        Private _pageNo As String
        Public Property PageNo() As String
            Get
                Return _pageNo
            End Get
            Set(ByVal value As String)
                _pageNo = value
            End Set
        End Property
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
            _midCol = -1
            _midRow = -1
            _borders = {False, False, False, False}
        End Sub

        Public Function Clone() As Page
            Dim _clone As New Page
            With _clone
                .TopLeft = _topLeft
                .BottomRight = _bottomRight
                .PagePosition = _pagePosition
                .MidCol = _midCol
                .MidRow = _midRow
                .Borders = _borders
                .PageNo = _pageNo
            End With
            Return _clone
        End Function
    End Class
#End Region
#Region "properties"
    Private oPrintProject As Project
    Public WriteOnly Property PrintProject() As Project
        Set(ByVal value As Project)
            oPrintProject = value
        End Set
    End Property

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

    Private gap As Integer

    Private oFormImage As Bitmap
    Private isPrintLoading As Boolean = False
    Private isPagesLoaded As Boolean = False

    Private oPrintBitmap As Bitmap
    Private oPrintGraphics As Graphics
    Private oPageList As List(Of Page)
    Private oSelectedPage As New Page
    Private oTextBrush As Brush = Brushes.Black

    Friend oPrintGrid1width As Integer = 1
    Friend oPrintGrid1Brush As Brush = Brushes.DarkGray
    Friend oPrintGrid1Pen = New Pen(oPrintGrid1Brush, oPrintGrid1width)
    Friend oPrintGrid5width As Integer = 1
    Friend oPrintGrid5Brush As Brush = Brushes.DimGray
    Friend oPrintGrid5Pen = New Pen(oPrintGrid5Brush, oPrintGrid5width)
    Friend oPrintGrid10width As Integer = 2
    Friend oPrintGrid10Brush As Brush = Brushes.Black
    Friend oPrintGrid10Pen = New Pen(oPrintGrid10Brush, oPrintGrid10width)
    Friend oPrintBorderwidth As Integer = 5
    Friend oPrintBorderBrush As Brush = Brushes.Black
    Friend oPrintBorderPen = New Pen(oPrintBorderBrush, oPrintBorderwidth)
    Friend oOverlapBrush As SolidBrush
    Friend oPrintCentrewidth As Integer = 3
    Friend oPrintCentreBrush As Brush = Brushes.Red
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

    Private Sub PenDispose()
        oPrintBorderPen.dispose
        oPrintCentrePen.dispose
        oPrintGrid10Pen.dispose
        oPrintGrid1Pen.dispose
        oPrintGrid5Pen.dispose
    End Sub

    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.PrintFormPos = SetFormPos(Me)
        My.Settings.Save()
        PenDispose()
    End Sub
    Private Sub BtnTitleFont_Click(sender As Object, e As EventArgs) Handles BtnTitleFont.Click
        FontDialog1.Font = BtnTitleFont.Font
        FontDialog1.ShowDialog()
        BtnTitleFont.Font = FontDialog1.Font
        SetPrintFonts()
        LoadFormPages()
    End Sub
    Private Sub BtnTextFont_Click(sender As Object, e As EventArgs) Handles BtnTextFont.Click
        FontDialog1.Font = BtnTextFont.Font
        FontDialog1.ShowDialog()
        BtnTextFont.Font = FontDialog1.Font
        SetPrintFonts()
        LoadFormPages()
    End Sub
    Private Sub BtnFooterFont_Click(sender As Object, e As EventArgs) Handles BtnFooterFont.Click
        FontDialog1.Font = BtnFooterFont.Font
        FontDialog1.ShowDialog()
        BtnFooterFont.Font = FontDialog1.Font
        SetPrintFonts()
        LoadFormPages()
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isPrintLoading = True
        oPageToFormRatio = Math.Ceiling(A4_WIDTH / PicDesign.Width)
        LoadInstalledPrinters()
        InitialisePrintDocument()
        LoadFormFromSettings()
        SetPrintFonts()
        Select Case oStitchDisplayStyle
            Case StitchDisplayStyle.BlackWhiteSymbols
                CbDisplayStyle.SelectedIndex = 0
            Case StitchDisplayStyle.ColouredSymbols
                CbDisplayStyle.SelectedIndex = 1
            Case StitchDisplayStyle.BlocksWithSymbols
                CbDisplayStyle.SelectedIndex = 2
            Case Else
                CbDisplayStyle.SelectedIndex = 0
        End Select
        TxtTitle.Text = oPrintProject.ProjectName
        isPrintLoading = False
        LoadFormPages()
    End Sub
    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim targetWidth As Integer = oPrintBitmap.Width - oLeftMargin
        Dim targetHeight As Integer = oPrintBitmap.Height - oTopMargin
        e.Graphics.DrawImage(oPrintBitmap, 0, 0, New Rectangle(0, 0, targetWidth, targetHeight), GraphicsUnit.Document)
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
        ChkPrintHeader.Checked = My.Settings.isPrintHeader
        ChkPrintFooter.Checked = My.Settings.isPrintFooter
        TxtDesignBy.Text = My.Settings.DesignBy
        TxtCopyright.Text = My.Settings.CopyrightBy
        ChkPrintGrid.Checked = My.Settings.PrintGrid
        ChkCentreMarks.Checked = My.Settings.PrintCentreMarks
        ChkCentreLines.Checked = My.Settings.PrintCentreLines
        BtnTitleFont.Font = My.Settings.PrintTitleFont
        BtnTextFont.Font = My.Settings.PrintTextFont
        BtnFooterFont.Font = My.Settings.PrintFooterFont
        isPrintRowNumbers = My.Settings.PrintRowNumbers
        isPrintColumnNumbers = My.Settings.PrintColumnNumbers
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
        My.Settings.isPrintHeader = ChkPrintHeader.Checked
        My.Settings.DesignBy = TxtDesignBy.Text
        My.Settings.CopyrightBy = TxtCopyright.Text
        My.Settings.PrintGrid = ChkPrintGrid.Checked
        My.Settings.PrintCentreMarks = ChkCentreMarks.Checked
        My.Settings.PrintCentreLines = ChkCentreLines.Checked
        My.Settings.PrintTitleFont = BtnTitleFont.Font
        My.Settings.PrintTextFont = BtnTextFont.Font
        My.Settings.PrintFooterFont = BtnFooterFont.Font
        My.Settings.Save()
    End Sub
    Private Sub LoadFormPages()
        isPagesLoaded = False
        isPrintHeader = ChkPrintHeader.Checked
        isPrintFooter = ChkPrintFooter.Checked
        oPrinterHardMarginX = oPageSettings.HardMarginX / 100 * PRINT_DPI
        oPrinterHardMarginY = oPageSettings.HardMarginY / 100 * PRINT_DPI
        SetPrintPageMargins(NudLeftMargin.Value, NudRightMargin.Value, NudTopMargin.Value, NudBottomMargin.Value)
        oOverlapBrush = New SolidBrush(oOverlapColourList(CbShading.SelectedIndex))
        oPrintPixelsPerCell = Math.Floor(PRINT_DPI / NudSqrPerInch.Value)
        CalculatePrintGridSpace(NudSqrPerInch.Value, oPrintPixelsPerCell, New Size(oPrintProject.DesignWidth, oPrintProject.DesignHeight))
        LblOnePage.Text = String.Format(LblOnePage.Text, oOnePageSqPerInch)
        InitialisePageLists()
        isPagesLoaded = True
    End Sub
    Private Sub SetPrintFonts()
        oPrintTitlefont = New Font(BtnTitleFont.Font.FontFamily, BtnTitleFont.Font.SizeInPoints, BtnTitleFont.Font.Style, GraphicsUnit.Point)
        oPrintTextfont = New Font(BtnTextFont.Font.FontFamily, BtnTextFont.Font.SizeInPoints, BtnTextFont.Font.Style, GraphicsUnit.Point)
        oPrintFooterfont = New Font(BtnFooterFont.Font.FontFamily, BtnFooterFont.Font.SizeInPoints, BtnFooterFont.Font.Style, GraphicsUnit.Point)
    End Sub
    Private Sub SetFonts()
        oTitlefont = oPrintTitlefont
        oTextfont = oPrintTextfont
        oFooterfont = oPrintFooterfont
    End Sub
    Private Sub CreatePageGraphics(pPage As Page, ByRef pPageGraphics As Graphics, pSize As Size, pPixelsPerCell As Integer)
        oPagePixelsPerCell = pPixelsPerCell
        gap = oPagePixelsPerCell
        Dim _footerText As New StringBuilder
        _footerText.Append("Design By ") _
        .Append(TxtDesignBy.Text) _
        .Append(vbTab) _
        .Append(Chr(169) & " ") _
        .Append(TxtCopyright.Text) _
        .Append(vbTab) _
        .Append("Page ") _
        .Append(pPage.PageNo) _
        .Append(" of ") _
        .Append(CStr(oPageList.Count)) _
        .Append(" ")
        pPageGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        pPageGraphics.Clear(Color.White)
        If NudOverlap.Value > 0 Then
            PrintOverlapShade(pPage, pPageGraphics)
        End If
        For Each _blockstitch In oProjectDesign.BlockStitches
            If _blockstitch.BlockPosition.X >= pPage.TopLeft.X _
            And _blockstitch.BlockPosition.X < pPage.BottomRight.X _
            And _blockstitch.BlockPosition.Y >= pPage.TopLeft.Y _
            And _blockstitch.BlockPosition.Y < pPage.BottomRight.Y Then
                If _blockstitch.IsLoaded Then
                    Select Case _blockstitch.StitchType
                        Case BlockStitchType.Full
                            PrintFullBlockStitch(_blockstitch, pPageGraphics, CbDisplayStyle.SelectedIndex, pPage)
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
        '      ClearMargins(pPage, pPageGraphics)
        If isPrintHeader Then
            pPageGraphics.DrawString(TxtTitle.Text, oTitlefont, oTextBrush, New Point(oLeftMargin, oPageTopMargin))
        End If
        If isPrintFooter Then
            Dim oFooterPos As Integer = oBottomMargin - 20
            If isPrintColumnNumbers Then
                oFooterPos = oFooterPos - oPageFooterHeight - 20
            End If
            pPageGraphics.DrawString(_footerText.ToString, oFooterfont, oTextBrush, New Point(oLeftMargin, pSize.Height - oFooterPos))
        End If
    End Sub
    Friend Sub PrintFullBlockStitch(pBlockStitch As BlockStitch, ByRef pDesignGraphics As Graphics, pStitchDisplayStyle As Integer, pPage As Page)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockStitch.BlockPosition.X - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockStitch.BlockPosition.Y - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        Dim _size As New Size(oPagePixelsPerCell, oPagePixelsPerCell)
        Dim _symImage As Image = MakePrintImage(pBlockStitch)
        oStitchPenWidth = Math.Max(2, oPagePixelsPerCell / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        If pStitchDisplayStyle = 2 Then
            pDesignGraphics.FillRectangle(New SolidBrush(_threadColour), New Rectangle(_tl, _size))
        End If

        If pStitchDisplayStyle = 1 Then
            Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(pBlockStitch.ProjThread.Thread)
            pDesignGraphics.DrawImage(MakePrintImage(pBlockStitch), New Rectangle(_tl, _size), 0, 0, _symImage.Width, _symImage.Height, GraphicsUnit.Pixel, _imageAttributes)
        Else
            pDesignGraphics.DrawImage(_symImage, pX, pY, oPagePixelsPerCell, oPagePixelsPerCell)
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
        isPrintLoading = True
        TabControl1.TabPages.Clear()
        isPrintLoading = False
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
        Dim _newPage As Page
        Do Until _rowsLeft <= 0
            _colsLeft = oProjectDesign.Columns
            _pagesAcross = 0
            Dim _pageRows As Integer
            If _pagesDown = 0 Then
                _pageRows = Math.Min(oAvailableCellsHeight, _rowsLeft)
                _rowsLeft -= oAvailableCellsHeight
            Else
                _pageRows = Math.Min(oAvailableCellsHeight - _overlap, _rowsLeft)
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
                    _pageColumns = Math.Min(oAvailableCellsWidth - _overlap, _colsLeft)
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
                _newPage.PageNo = CStr(_pagesTotal)
                TabControl1.TabPages.Add("Page " & CStr(_pagesTotal))
                _newPage.TopLeft = _pageTopLeft
                _newPage.BottomRight = New Point(_pageTopLeft.X + _pageColumns, _pageTopLeft.Y + _pageRows)
                If _designMiddleRow >= _newPage.TopLeft.Y AndAlso _designMiddleRow <= _newPage.BottomRight.Y Then
                    _newPage.MidRow = _designMiddleRow
                End If
                If _designMiddleColumn >= _newPage.TopLeft.X AndAlso _designMiddleColumn <= _newPage.BottomRight.X Then
                    _newPage.MidCol = _designMiddleColumn
                End If
                Dim _page As Page = _newPage.Clone
                oPageList.Add(_page)
                _pageTopLeft = New Point(_pageTopLeft.X + _pageColumns - _overlap, _pageTopLeft.Y)
                _pagesAcross += 1
            Loop
            _pageTopLeft = New Point(0, _pageTopLeft.Y + _pageRows - _overlap)
            _pagesDown += 1
        Loop
        isPagesLoaded = True
        TabControl1.SelectedIndex = 0
        DisplayPageImage()
    End Sub
    Private Sub PrintOverlapShade(pPage As Page, pPageGraphics As Graphics)
        Dim _widthInColumns As Integer = pPage.BottomRight.X - pPage.TopLeft.X
        Dim _heightInRows As Integer = pPage.BottomRight.Y - pPage.TopLeft.Y
        Dim tl As New Point(oLeftMargin, oTopMargin)
        If pPage.Borders(Borders.Top) = False Then
            pPageGraphics.FillRectangle(oOverlapBrush, New RectangleF(tl, New Size(_widthInColumns * gap, NudOverlap.Value * gap)))
        End If
        If pPage.Borders(Borders.Left) = False Then
            pPageGraphics.FillRectangle(oOverlapBrush, New RectangleF(tl, New Size(NudOverlap.Value * gap, _heightInRows * gap)))
        End If
    End Sub
    Private Sub ClearMargins(pPage As Page, pPageGraphics As Graphics)
        Dim oBottomGapY As Integer = oTopMargin + ((pPage.BottomRight.Y - pPage.TopLeft.Y) * oPagePixelsPerCell)
        Dim oRightGapX As Integer = oLeftMargin + ((pPage.BottomRight.X - pPage.TopLeft.X) * oPagePixelsPerCell)
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, 0), New Size(A4_WIDTH, oTopMargin - 2)))
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, oBottomGapY), New Size(A4_WIDTH, A4_HEIGHT - oBottomGapY - 2)))
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, 0), New Size(oLeftMargin - 2, A4_HEIGHT)))
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(oRightGapX, 0), New Size(A4_WIDTH - oRightGapX - 2, A4_HEIGHT)))
    End Sub
    Private Sub PrintGrid(pPage As Page, ByRef pPageGraphics As Graphics, pSize As Size)
        Dim _widthInColumns As Integer = pPage.BottomRight.X - pPage.TopLeft.X
        Dim _heightInRows As Integer = pPage.BottomRight.Y - pPage.TopLeft.Y
        Dim _widthInPixels As Integer = Math.Min(gap * _widthInColumns, pSize.Width)
        Dim _heightInPixels As Integer = Math.Min(gap * _heightInRows, pSize.Height)
        Dim i5ColStart As Integer = 5
        Dim i10ColStart As Integer = 10
        If pPage.TopLeft.X > 0 Then
            Math.DivRem(pPage.TopLeft.X, 5, i5ColStart)
            i5ColStart = 5 - i5ColStart
            Math.DivRem(pPage.TopLeft.X, 10, i10ColStart)
            i10ColStart = 10 - i10ColStart
        End If
        Dim i5rowStart As Integer = 5
        Dim i10rowStart As Integer = 10
        If pPage.TopLeft.Y > 0 Then
            Math.DivRem(pPage.TopLeft.Y, 5, i5rowStart)
            i5rowStart = 5 - i5rowStart
            Math.DivRem(pPage.TopLeft.Y, 10, i10rowStart)
            i10rowStart = 10 - i10rowStart
        End If
        If ChkPrintGrid.Checked Then
            ' grid
            For _column = 0 To _widthInColumns
                DrawGridVerticalLine(pPageGraphics, oPrintGrid1Pen, _column, _heightInPixels)
                If isPrintColumnNumbers Then
                    If Math.IEEERemainder(_column + 1 + pPage.TopLeft.X, 5) = 0 And _column < _widthInColumns Then
                        pPageGraphics.DrawString(CStr(_column + 1 + pPage.TopLeft.X), oPrintFooterfont, oTextBrush, New Point(oLeftMargin + (gap * (_column)), oTopMargin + (gap * _heightInRows)))
                    End If
                End If
            Next
            For _row = 0 To _heightInRows
                DrawGridHorizontalLine(pPageGraphics, oPrintGrid1Pen, _row, _widthInPixels)
                If isPrintRowNumbers Then
                    If Math.IEEERemainder(_row + 1 + pPage.TopLeft.Y, 5) = 0 And _row < _heightInRows Then
                        pPageGraphics.DrawString(CStr(_row + 1 + pPage.TopLeft.Y), oPrintFooterfont, oTextBrush, New Point(oLeftMargin + (gap * _widthInColumns), oTopMargin + (gap * (_row))))
                    End If
                End If
            Next
            For _column = i5ColStart To _widthInColumns Step 10
                DrawGridVerticalLine(pPageGraphics, oPrintGrid5Pen, _column, _heightInPixels)
            Next
            For _row = i5rowStart To _heightInRows Step 10
                DrawGridHorizontalLine(pPageGraphics, oPrintGrid5Pen, _row, _widthInPixels)
            Next
            For _column = i10ColStart To _widthInColumns Step 10
                DrawGridVerticalLine(pPageGraphics, oPrintGrid10Pen, _column, _heightInPixels)
            Next
            For _row = i10rowStart To _heightInRows Step 10
                DrawGridHorizontalLine(pPageGraphics, oPrintGrid10Pen, _row, _widthInPixels)
            Next
        End If
        ' Centre lines and marks
        If ChkCentreMarks.Checked Or ChkCentreLines.Checked Then
            Dim _markHalfWidth As Integer = Math.Max(8, Math.Ceiling(oPagePixelsPerCell * 0.5))
            Dim _markHeight As Integer = Math.Max(12, Math.Ceiling(oPagePixelsPerCell * 0.75))
            Dim _middleRow As Integer = pPage.MidRow - pPage.TopLeft.Y
            Dim _middleColumn As Integer = pPage.MidCol - pPage.TopLeft.X
            Dim _middleColumnPos As Integer = (gap * _middleColumn) + oLeftMargin
            Dim _middleRowPos As Integer = (gap * _middleRow) + oTopMargin
            If pPage.MidRow > -1 Then
                If ChkCentreLines.Checked Then
                    DrawGridHorizontalLine(pPageGraphics, oPrintCentrePen, _middleRow, _widthInPixels)
                End If
                If ChkCentreMarks.Checked Then
                    Dim _leftMarkPoints As Point() = {New Point(gap - _markHeight + oLeftMargin, _middleRowPos - _markHalfWidth),
                                                      New Point(gap - _markHeight + oLeftMargin, _middleRowPos + _markHalfWidth),
                                                      New Point(gap + oLeftMargin, _middleRowPos)}

                    Dim _rightMarkPoints As Point() = {New Point(_widthInPixels - gap + _markHeight + oLeftMargin, (_middleRowPos - _markHalfWidth)),
                                                       New Point(_widthInPixels - gap + _markHeight + oLeftMargin, _middleRowPos + _markHalfWidth),
                                                       New Point(_widthInPixels - gap + oLeftMargin, _middleRowPos)}
                    oPrintGraphics.FillPolygon(oPrintCentreBrush, _leftMarkPoints)
                    oPrintGraphics.FillPolygon(oPrintCentreBrush, _rightMarkPoints)
                End If
            End If
            If pPage.MidCol > -1 Then
                If ChkCentreLines.Checked Then
                    DrawGridVerticalLine(pPageGraphics, oPrintCentrePen, _middleColumn, _heightInPixels)
                End If
                If ChkCentreMarks.Checked Then
                    Dim _topMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, gap - _markHeight + oTopMargin),
                                                 New Point(_middleColumnPos + _markHalfWidth, gap - _markHeight + oTopMargin),
                                                 New Point(_middleColumnPos, gap + oTopMargin)}
                    Dim _bottomMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, _heightInPixels - gap + _markHeight + oTopMargin),
                                                    New Point(_middleColumnPos + _markHalfWidth, _heightInPixels - gap + _markHeight + oTopMargin),
                                                    New Point(_middleColumnPos, _heightInPixels - gap + oTopMargin)}
                    oPrintGraphics.FillPolygon(oPrintCentreBrush, _topMarkPoints)
                    oPrintGraphics.FillPolygon(oPrintCentreBrush, _bottomMarkPoints)
                End If
            End If
        End If
        ' Borders
        If pPage.Borders(Borders.Top) = True Then
            DrawGridHorizontalLine(pPageGraphics, oPrintBorderPen, 0, _widthInPixels)
        End If
        If pPage.Borders(Borders.Bottom) = True Then
            DrawGridHorizontalLine(pPageGraphics, oPrintBorderPen, _heightInRows, _widthInPixels)
        End If
        If pPage.Borders(Borders.Left) = True Then
            DrawGridVerticalLine(pPageGraphics, oPrintBorderPen, 0, _heightInPixels)
        End If
        If pPage.Borders(Borders.Right) = True Then
            DrawGridVerticalLine(pPageGraphics, oPrintBorderPen, _widthInColumns, _heightInPixels)
        End If
    End Sub
    Private Sub DrawGridHorizontalLine(ByRef pPageGraphics As Graphics, pPen As Pen, pRow As Integer, pGridWidthInPixels As Integer)
        pPageGraphics.DrawLine(pPen, New Point(oLeftMargin, oTopMargin + (gap * pRow)), New Point(oLeftMargin + pGridWidthInPixels, oTopMargin + (gap * pRow)))
    End Sub
    Private Sub DrawGridVerticalLine(ByRef pPageGraphics As Graphics, pPen As Pen, pColumn As Integer, pGridHeightInpixels As Integer)
        pPageGraphics.DrawLine(pPen, New Point(oLeftMargin + (gap * pColumn), oTopMargin), New Point(oLeftMargin + (gap * pColumn),oTopMargin + pGridHeightInpixels ))
    End Sub
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
            CreatePrintBitmap()
            PicDesign.Image = oPrintBitmap
        End If
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrintPage.Click
        LogUtil.ShowStatus("Printing page", LblStatus, MyBase.Name)
        InitialisePrintDocument()
        oPrintDoc.PrinterSettings.PrinterName = CmbInstalledPrinters.SelectedItem
        ' Set handler to print image 
        AddHandler oPrintDoc.PrintPage, AddressOf OnPrintImage
        ' Print the image (calls PrintPage handler (see above))
        oPrintDoc.Print()
    End Sub
    Private Sub CreatePrintBitmap()
        SetPrintFonts()
        oPrintBitmap = New Bitmap(A4_WIDTH, A4_HEIGHT)
        oPrintBitmap.SetResolution(PRINT_DPI, PRINT_DPI)
        oPrintGraphics = Graphics.FromImage(oPrintBitmap)
        ' Set handler to print image 
        oLeftMargin = oPageLeftMargin
        oRightMargin = oPageRightMargin
        If isPrintRowNumbers Then
            oRightMargin += oPageFooterHeight + 20
        End If
        oTopMargin = oPageTopMargin + oPageTitleHeight + 20
        oBottomMargin = oPageBottomMargin + oPageFooterHeight + 20
        If isPrintColumnNumbers Then
            oBottomMargin += oPageFooterHeight + 20
        End If
        oTitleHeight = oPageTitleHeight
        oFooterHeight = oPageFooterHeight
        SetFonts()
        CreatePageGraphics(oSelectedPage, oPrintGraphics, oPrintBitmap.Size, oPrintPixelsPerCell)
    End Sub
    Private Sub ParameterValueChanged(sender As Object, e As EventArgs) Handles NudTopMargin.ValueChanged,
                                                                                    NudBottomMargin.ValueChanged,
                                                                                    NudLeftMargin.ValueChanged,
                                                                                    NudRightMargin.ValueChanged,
                                                                                    NudSqrPerInch.ValueChanged,
                                                                                    ChkPrintGrid.CheckedChanged,
                                                                                    NudOverlap.ValueChanged,
                                                                                    TxtCopyright.LostFocus,
                                                                                    TxtDesignBy.LostFocus,
                                                                                    TxtTitle.LostFocus,
                                                                                    ChkPrintHeader.CheckedChanged,
                                                                                    ChkPrintFooter.CheckedChanged,
                                                                                    CbShading.SelectedIndexChanged,
                                                                                    CbDisplayStyle.SelectedIndexChanged,
                                                                                    ChkCentreLines.CheckedChanged,
                                                                                    ChkCentreMarks.CheckedChanged
        If isComponentInitialised And Not isPrintLoading Then
            LoadFormPages()
        End If
    End Sub

    Private Sub BtnPrintAll_Click(sender As Object, e As EventArgs) Handles BtnPrintAll.Click
        If isPagesLoaded Then
            LogUtil.ShowStatus("Printing all pages", LblStatus, MyBase.Name)
            InitialisePrintDocument()
            oPrintDoc.PrinterSettings.PrinterName = CmbInstalledPrinters.SelectedItem
            AddHandler oPrintDoc.PrintPage, AddressOf OnPrintImage
            For Each _page As Page In oPageList
                oSelectedPage = _page
                CreatePrintBitmap()
                oPrintDoc.Print()
            Next
        End If
    End Sub

#End Region
End Class