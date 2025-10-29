' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Text
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmPrintProject
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
    Private gap As Integer
    Private isComponentInitialised As Boolean
    Private isPagesLoaded As Boolean = False
    Private isPrintKey As Boolean
    Private isPrintLoading As Boolean = False
    Private oFormImage As Bitmap
    Private oOverlapBrush As SolidBrush
    Private oPageList As List(Of Page)
    Private oPrintBitmap As Bitmap
    Private oPrintBorderBrush As Brush = Brushes.Black
    Private oPrintBorderPen = New Pen(oPrintBorderBrush, oPrintBorderwidth)
    Private oPrintBorderwidth As Integer = 5
    Private oPrintCentreBrush As Brush = Brushes.Red
    Private oPrintCentrePen = New Pen(oPrintCentreBrush, oPrintCentrewidth)
    Private oPrintCentrewidth As Integer = 3
    Private oPrintGraphics As Graphics
    Private oPrintGrid10Brush As Brush = Brushes.Black
    Private oPrintGrid10width As Integer = 2
    Private oPrintGrid10Pen As New Pen(oPrintGrid10Brush, oPrintGrid10width)
    Private oPrintGrid1Brush As Brush = Brushes.DarkGray
    Private oPrintGrid1width As Integer = 1
    Private oPrintGrid1Pen As New Pen(oPrintGrid1Brush, oPrintGrid1width)
    Private oPrintKeyBrush As Brush = Brushes.Black
    Private oPrintKeyPen As New Pen(oPrintKeyBrush, 1)
    Private oPrintGrid5Brush As Brush = Brushes.DimGray
    Private oPrintGrid5width As Integer = 1
    Private oPrintGrid5Pen As New Pen(oPrintGrid5Brush, oPrintGrid5width)
    Private oSelectedPage As New Page
    Private oTextBrush As Brush = Brushes.Black
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
        LogUtil.LogInfo("Closing...", MyBase.Name)
        My.Settings.PrintFormPos = SetFormPos(Me)
        My.Settings.Save()
        PenDispose()
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
            If isPrintKey Then
                CreateKeyBitmap()
                oPrintDoc.Print()
            End If
        End If
    End Sub
    Private Sub BtnPrintKey_Click(sender As Object, e As EventArgs) Handles BtnPrintKey.Click
        LogUtil.ShowStatus("Printing key", LblStatus, MyBase.Name)
        InitialisePrintDocument()
        oPrintDoc.PrinterSettings.PrinterName = CmbInstalledPrinters.SelectedItem
        ' Set handler to print image 
        AddHandler oPrintDoc.PrintPage, AddressOf OnPrintImage
        CreateKeyBitmap()
        ' Print the image (calls PrintPage handler (see above))
        oPrintDoc.Print()
    End Sub
    Private Sub BtnFont_Click(sender As Object, e As EventArgs) Handles BtnTitleFont.Click,
                                                                        BtnTextFont.Click,
                                                                        BtnFooterFont.Click
        Dim _button As Button = CType(sender, Button)
        SelectFont(_button)
    End Sub
    Private Sub BtnMoreSettings_Click(sender As Object, e As EventArgs) Handles BtnMoreSettings.Click
        ShowPrintSettingsForm()
    End Sub
    Private Sub BtnSaveSettings_Click(sender As Object, e As EventArgs) Handles BtnSaveSettings.Click
        SaveSettings()
    End Sub
    Private Sub ParameterValueChanged(sender As Object, e As EventArgs) Handles NudSqrPerInch.ValueChanged,
                                                                                ChkPrintGrid.CheckedChanged,
                                                                                ChkCentreMarks.CheckedChanged,
                                                                                ChkCentreLines.CheckedChanged,
                                                                                CbDisplayStyle.SelectedIndexChanged,
                                                                                NudBottomMargin.ValueChanged,
                                                                                NudLeftMargin.ValueChanged,
                                                                                NudRightMargin.ValueChanged,
                                                                                NudOverlap.ValueChanged,
                                                                                ChkPrintHeader.CheckedChanged,
                                                                                ChkPrintFooter.CheckedChanged,
                                                                                CbShading.SelectedIndexChanged,
                                                                                ChkShowPageOrder.CheckedChanged
        If isComponentInitialised And Not isPrintLoading Then
            LoadFormPages()
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isPrintLoading = True
        LoadInstalledPrinters()
        InitialisePrintDocument()
        oPageToFormRatio = Math.Ceiling(A4_WIDTH / PicDesign.Width)
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
    Private Sub LoadFormFromSettings()
        BtnFooterFont.Font = My.Settings.PrintFooterFont
        BtnTextFont.Font = My.Settings.PrintTextFont
        BtnTitleFont.Font = My.Settings.PrintTitleFont
        CbKeyOrder.SelectedIndex = My.Settings.PrintKeyOrder
        CbShading.SelectedIndex = My.Settings.OverlapShading
        ChkCentreLines.Checked = My.Settings.PrintCentreLines
        ChkCentreMarks.Checked = My.Settings.PrintCentreMarks
        ChkPrintFooter.Checked = My.Settings.isPrintFooter
        ChkPrintGrid.Checked = My.Settings.PrintGrid
        ChkPrintHeader.Checked = My.Settings.isPrintHeader
        ChkPrintKey.Checked = My.Settings.isPrintKey
        isPrintKey = My.Settings.isPrintKey
        ChkShowPageOrder.Checked = My.Settings.isShowPageOrder
        NudBottomMargin.Value = My.Settings.PrintMarginBottom
        NudLeftMargin.Value = My.Settings.PrintMarginLeft
        NudOverlap.Value = My.Settings.TilingOverlap
        NudRightMargin.Value = My.Settings.PrintMarginRight
        NudSqrPerInch.Value = My.Settings.PrintSquaresPerInch
        NudTopMargin.Value = My.Settings.PrintMarginTop
        TxtCopyright.Text = My.Settings.CopyrightBy
        TxtDesignBy.Text = My.Settings.DesignBy
        isPrintColumnNumbers = My.Settings.PrintColumnNumbers
        isPrintRowNumbers = My.Settings.PrintRowNumbers
        SetPens()
    End Sub
    Private Sub SetPens()
        oPrintBorderBrush = Brushes.Black
        oPrintBorderwidth = My.Settings.PrintBorderThickness
        oPrintBorderPen = New Pen(oPrintBorderBrush, oPrintBorderwidth)
        oPrintCentreBrush = New SolidBrush(My.Settings.PrintCentreLineColour)
        oPrintCentrewidth = My.Settings.PrintCentreLineThickness
        oPrintCentrePen = New Pen(oPrintCentreBrush, oPrintCentrewidth)
        oPrintGrid1Brush = New SolidBrush(GetColourFromProject(My.Settings.PrintGrid1Colour, oGridColourList))
        oPrintGrid1width = 1
        oPrintGrid1Pen = New Pen(oPrintGrid1Brush, oPrintGrid1width)
        oPrintGrid5Brush = New SolidBrush(GetColourFromProject(My.Settings.PrintGrid5Colour, oGridColourList))
        oPrintGrid5width = 1
        oPrintGrid5Pen = New Pen(oPrintGrid5Brush, oPrintGrid5width)
        oPrintGrid10Brush = New SolidBrush(GetColourFromProject(My.Settings.PrintGrid10Colour, oGridColourList))
        oPrintGrid10width = 2
        oPrintGrid10Pen = New Pen(oPrintGrid10Brush, oPrintGrid10width)
    End Sub
    Private Sub SaveSettings()
        My.Settings.isPrintKey = ChkPrintKey.Checked
        My.Settings.PrintKeyOrder = CbKeyOrder.SelectedIndex
        My.Settings.PrintSquaresPerInch = NudSqrPerInch.Value
        My.Settings.TilingOverlap = NudOverlap.Value
        My.Settings.OverlapShading = CbShading.SelectedIndex
        My.Settings.isShowPageOrder = ChkShowPageOrder.Checked
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
    Private Sub SelectFont(ByRef pButton As Button)
        FontDialog1.Font = pButton.Font
        FontDialog1.ShowDialog()
        pButton.Font = FontDialog1.Font
        SetPrintFonts()
        LoadFormPages()
    End Sub
    Private Sub PenDispose()
        oPrintBorderPen.dispose
        oPrintCentrePen.dispose
        oPrintGrid10Pen.dispose
        oPrintGrid1Pen.Dispose
        oPrintGrid5Pen.Dispose()
        oPrintKeyPen.Dispose()
    End Sub
    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.DrawImage(oPrintBitmap, New Point(0, 0))
        LogUtil.ShowStatus("Printing done", LblStatus, MyBase.Name)
    End Sub
    Private Sub LoadFormPages()
        isPagesLoaded = False
        isPrintHeader = ChkPrintHeader.Checked
        isPrintFooter = ChkPrintFooter.Checked
        oPagePixelsPerCell = Math.Floor(PRINT_DPI / NudSqrPerInch.Value)
        SetPrintPageMargins(NudLeftMargin.Value, NudRightMargin.Value, NudTopMargin.Value, NudBottomMargin.Value)
        CalculatePrintGridSpace(New Size(oPrintProject.DesignWidth, oPrintProject.DesignHeight))
        oOverlapBrush = New SolidBrush(oOverlapColourList(CbShading.SelectedIndex))
        LblOnePage.Text = String.Format(LblOnePage.Text, oOnePageSqPerInch)
        InitialisePageLists()
        isPagesLoaded = True
    End Sub
    Private Sub SetPrintFonts()
        oPrintTitlefont = New Font(BtnTitleFont.Font.FontFamily, BtnTitleFont.Font.SizeInPoints, BtnTitleFont.Font.Style, GraphicsUnit.Point)
        oPrintTextfont = New Font(BtnTextFont.Font.FontFamily, BtnTextFont.Font.SizeInPoints, BtnTextFont.Font.Style, GraphicsUnit.Point)
        oPrintFooterfont = New Font(BtnFooterFont.Font.FontFamily, BtnFooterFont.Font.SizeInPoints, BtnFooterFont.Font.Style, GraphicsUnit.Point)
    End Sub
    Private Sub CreatePageGraphics(pPage As Page, ByRef pPageGraphics As Graphics, pSize As Size, pPixelsPerCell As Integer)
        oPagePixelsPerCell = pPixelsPerCell
        gap = oPagePixelsPerCell
        Dim _footerText As String = BuildFooter(pPage, ChkShowPageOrder.Checked)
        pPageGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        pPageGraphics.Clear(Color.White)
        If NudOverlap.Value > 0 Then
            PrintOverlapShade(pPage, pPageGraphics)
        End If
        For Each _blockstitch In oProjectDesign.BlockStitches
            Dim _actualPosition As New Point(_blockstitch.BlockPosition.X + oPrintProject.OriginX, _blockstitch.BlockPosition.Y + oPrintProject.OriginY)
            If _actualPosition.X >= pPage.TopLeft.X _
            And _actualPosition.X < pPage.BottomRight.X _
            And _actualPosition.Y >= pPage.TopLeft.Y _
            And _actualPosition.Y < pPage.BottomRight.Y Then
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
                Dim _actualFromPosition As New Point(_backstitch.FromBlockPosition.X + oPrintProject.OriginX, _backstitch.FromBlockPosition.Y + oPrintProject.OriginY)
                Dim _actualtoPosition As New Point(_backstitch.ToBlockPosition.X + oPrintProject.OriginX, _backstitch.ToBlockPosition.Y + oPrintProject.OriginY)
                If (_actualFromPosition.X >= pPage.TopLeft.X _
                    And _actualFromPosition.X <= pPage.BottomRight.X _
                    And _actualFromPosition.Y >= pPage.TopLeft.Y _
                    And _actualFromPosition.Y < pPage.BottomRight.Y) _
                Or
                        (_actualtoPosition.X >= pPage.TopLeft.X _
                    And _actualtoPosition.X <= pPage.BottomRight.X _
                    And _actualtoPosition.Y >= pPage.TopLeft.Y _
                    And _actualtoPosition.Y < pPage.BottomRight.Y) Then
                    PrintBackstitch(_backstitch, pPageGraphics, pPage)
                End If
            Next
        End If
        If My.Settings.IsShowKnots Then
            For Each _knot As Knot In oProjectDesign.Knots
                Dim _actualPosition As New Point(_knot.BlockPosition.X + oPrintProject.OriginX, _knot.BlockPosition.Y + oPrintProject.OriginY)
                If _actualPosition.X >= pPage.TopLeft.X _
            And _actualPosition.X <= pPage.BottomRight.X _
            And _actualPosition.Y >= pPage.TopLeft.Y _
            And _actualPosition.Y < pPage.BottomRight.Y Then
                    PrintKnot(_knot, pPageGraphics, pPage)
                End If
            Next
        End If
        ClearMargins(pPage, pPageGraphics)
        PrintHeaderFooter(pPageGraphics, pSize, _footerText)
        PrintRowColumnNumbers(pPage, pPageGraphics)
    End Sub
    Private Sub CreateKeyGraphics(pPageGraphics As Graphics, pSize As Size)
        Dim oThreadCollection As New ProjectThreadCollection(oProjectThreads.Threads)
        If My.Settings.PrintKeyOrder = 2 Then
            oThreadCollection.Threads.Sort(Function(x As ProjectThread, y As ProjectThread) x.Thread.SortNumber.CompareTo(y.Thread.SortNumber))
        Else
            oThreadCollection.Threads.Sort(Function(x As ProjectThread, y As ProjectThread) x.Thread.ColourName.CompareTo(y.Thread.ColourName))
        End If
        Dim oTableWidth As Integer = oAvailablePixelWidth / 2
        Dim oRowHeight As Integer = oPageTextHeight + 40
        Dim oTableHeight As Integer = oRowHeight * (oThreadCollection.Threads.Count + 1)
        Dim oColumn1Width As Integer = oTableWidth / 8
        Dim oColumn2Width As Integer = oTableWidth * 4 / 8
        Dim oColumn3Width As Integer = oTableWidth * 1 / 8
        Dim oSymbolWidth As Integer = oRowHeight * 0.75
        Dim oBoxWidth As Integer = osymbolwidth + 4
        Dim _footerText As String = BuildFooter(Nothing, False)
        pPageGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        pPageGraphics.Clear(Color.White)
        Dim _currentTopLeft As New Point(oLeftMargin, oTopMargin)
        DrawKeyTable(pPageGraphics, oTableWidth, oRowHeight, oTableHeight, oColumn1Width, oColumn2Width, oColumn3Width, _currentTopLeft)
        _currentTopLeft = New Point(_currentTopLeft.X, _currentTopLeft.Y + oRowHeight)
        For Each _thread As ProjectThread In oThreadCollection.Threads
            Dim oColourBrush As Brush = New SolidBrush(_thread.Thread.Colour)
            Dim _symbol As Bitmap = ImageUtil.ResizeImage(_thread.Symbol, oSymbolWidth, oSymbolWidth)
            _symbol.SetResolution(PRINT_DPI, PRINT_DPI)
            pPageGraphics.DrawImage(_symbol, New Point(_currentTopLeft.X + ((oColumn1Width - oSymbolWidth) / 2), _currentTopLeft.Y + (oRowHeight - oSymbolWidth) / 2))
            pPageGraphics.DrawRectangle(oPrintKeyPen, New Rectangle(New Point(_currentTopLeft.X + ((oColumn1Width - oBoxWidth) / 2), _currentTopLeft.Y + (oRowHeight - oBoxWidth) / 2), New Size(oBoxWidth, oBoxWidth)))
            pPageGraphics.DrawString(_thread.Thread.ColourName, oPrintTextfont, oPrintKeyBrush, New Point(_currentTopLeft.X + 3 + oColumn1Width, _currentTopLeft.Y + 3))
            pPageGraphics.FillRectangle(oColourBrush, New Rectangle(New Point(_currentTopLeft.X + oColumn1Width + oColumn2Width + ((oColumn3Width - oBoxWidth) / 2), _currentTopLeft.Y + (oRowHeight - oBoxWidth) / 2), New Size(oBoxWidth, oBoxWidth)))
            pPageGraphics.DrawString(_thread.Thread.ThreadNo, oPrintTextfont, oPrintKeyBrush, New Point(_currentTopLeft.X + 3 + oColumn1Width + oColumn2Width + oColumn3Width, _currentTopLeft.Y + 3))
            If _currentTopLeft.Y + oRowHeight < pSize.Height - oBottomMargin Then
                _currentTopLeft = New Point(_currentTopLeft.X, _currentTopLeft.Y + oRowHeight)
            Else
                _currentTopLeft = New Point(_currentTopLeft.X + oTableWidth, oTopMargin)
                DrawKeyTable(pPageGraphics, oTableWidth, oRowHeight, oTableHeight, oColumn1Width, oColumn2Width, oColumn3Width, _currentTopLeft)
                _currentTopLeft = New Point(_currentTopLeft.X, _currentTopLeft.Y + oRowHeight)
            End If
            pPageGraphics.DrawLine(oPrintKeyPen, New Point(_currentTopLeft.X, _currentTopLeft.Y), New Point(_currentTopLeft.X + oTableWidth, _currentTopLeft.Y))
        Next
        PrintHeaderFooter(pPageGraphics, pSize, _footerText)
    End Sub
    Private Sub DrawKeyTable(pPageGraphics As Graphics, oTableWidth As Integer, oRowHeight As Integer, oTableHeight As Integer, oColumn1Width As Integer, oColumn2Width As Integer, oColumn3Width As Integer, _currentTopLeft As Point)
        pPageGraphics.DrawLine(oPrintKeyPen, _currentTopLeft, New Point(_currentTopLeft.X + oTableWidth, _currentTopLeft.Y))
        pPageGraphics.DrawLine(oPrintKeyPen, _currentTopLeft, New Point(_currentTopLeft.X, _currentTopLeft.Y + oTableHeight))
        pPageGraphics.DrawLine(oPrintKeyPen, New Point(_currentTopLeft.X + oTableWidth, oTopMargin), New Point(_currentTopLeft.X + oTableWidth, _currentTopLeft.Y + oTableHeight))
        pPageGraphics.DrawLine(oPrintKeyPen, New Point(_currentTopLeft.X, oTopMargin + oTableHeight), New Point(_currentTopLeft.X + oTableWidth, _currentTopLeft.Y + oTableHeight))
        pPageGraphics.DrawLine(oPrintKeyPen, New Point(_currentTopLeft.X, oTopMargin + oRowHeight), New Point(_currentTopLeft.X + oTableWidth, _currentTopLeft.Y + oRowHeight))
        pPageGraphics.DrawLine(oPrintKeyPen, New Point(_currentTopLeft.X + oColumn1Width, _currentTopLeft.Y), New Point(_currentTopLeft.X + oColumn1Width, _currentTopLeft.Y + oTableHeight))
        pPageGraphics.DrawLine(oPrintKeyPen, New Point(_currentTopLeft.X + oColumn1Width + oColumn2Width, _currentTopLeft.Y), New Point(_currentTopLeft.X + oColumn1Width + oColumn2Width, _currentTopLeft.Y + oTableHeight))
        pPageGraphics.DrawLine(oPrintKeyPen, New Point(_currentTopLeft.X + oColumn1Width + oColumn2Width + oColumn3Width, _currentTopLeft.Y), New Point(_currentTopLeft.X + oColumn1Width + oColumn2Width + oColumn3Width, _currentTopLeft.Y + oTableHeight))
        pPageGraphics.DrawString("Key", oPrintTextfont, oPrintKeyBrush, New Point(_currentTopLeft.X + 3, _currentTopLeft.Y + 3))
        pPageGraphics.DrawString("Colour Name", oPrintTextfont, oPrintKeyBrush, New Point(_currentTopLeft.X + 3 + oColumn1Width, _currentTopLeft.Y + 3))
        pPageGraphics.DrawString("DMC code", oPrintTextfont, oPrintKeyBrush, New Point(_currentTopLeft.X + 3 + oColumn1Width + oColumn2Width + oColumn3Width, _currentTopLeft.Y + 3))
    End Sub
    Private Function BuildFooter(pPage As Page, pIsShowPageOrder As Boolean) As String
        Dim _footerText As New StringBuilder
        _footerText.Append("Design By ") _
        .Append(TxtDesignBy.Text) _
        .Append(vbTab) _
        .Append(Chr(169) & " ") _
        .Append(TxtCopyright.Text) _
        .Append(vbTab)
        If pIsShowPageOrder Then
            _footerText.Append("Page ") _
            .Append(pPage.PageNo) _
            .Append(" of ") _
            .Append(CStr(oPageList.Count)) _
            .Append(" ") _
            .Append(vbTab) _
            .Append("Row ") _
            .Append(pPage.PagePosition.Y + 1) _
            .Append(" Column ") _
            .Append(pPage.PagePosition.X + 1)
        End If
        Return _footerText.ToString
    End Function
    Private Sub PrintHeaderFooter(pPageGraphics As Graphics, pSize As Size, pFooterText As String)
        If isPrintHeader Then
            pPageGraphics.DrawString(TxtTitle.Text, oPrintTitlefont, oTextBrush, New Point(oLeftMargin, oPageTopMargin))
        End If
        If isPrintFooter Then
            Dim oFooterPos As Integer = pSize.Height - oBottomMargin
            If isPrintColumnNumbers Then
                oFooterPos += oPageFooterHeight
            End If
            pPageGraphics.DrawString(pFooterText, oPrintFooterfont, oTextBrush, New Point(oLeftMargin, oFooterPos))
        End If
    End Sub
    Private Sub PrintRowColumnNumbers(pPage As Page, pPageGraphics As Graphics)
        Dim _widthInColumns As Integer = pPage.BottomRight.X - pPage.TopLeft.X
        Dim _heightInRows As Integer = pPage.BottomRight.Y - pPage.TopLeft.Y
        If isPrintRowNumbers Then
            For _row = 0 To _heightInRows
                If Math.IEEERemainder(_row + 1 + pPage.TopLeft.Y, 5) = 0 And _row < _heightInRows Then
                    pPageGraphics.DrawString(CStr(_row + 1 + pPage.TopLeft.Y), oPrintFooterfont, oTextBrush, New Point(oLeftMargin + (gap * _widthInColumns), oTopMargin + (gap * (_row))))
                End If
            Next
        End If
        If isPrintColumnNumbers Then
            For _column = 0 To _widthInColumns
                If Math.IEEERemainder(_column + 1 + pPage.TopLeft.X, 5) = 0 And _column < _widthInColumns Then
                    pPageGraphics.DrawString(CStr(_column + 1 + pPage.TopLeft.X), oPrintFooterfont, oTextBrush, New Point(oLeftMargin + (gap * (_column)), oTopMargin + (gap * _heightInRows)))
                End If
            Next
        End If
    End Sub
    Friend Sub PrintFullBlockStitch(pBlockStitch As BlockStitch, ByRef pDesignGraphics As Graphics, pStitchDisplayStyle As Integer, pPage As Page)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockStitch.BlockPosition.X + oPrintProject.OriginX - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockStitch.BlockPosition.Y + oPrintProject.OriginY - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        Dim _size As New Size(oPagePixelsPerCell, oPagePixelsPerCell)
        Dim _symImage As Image = MakePrintImage(pBlockStitch)
        SetStitchPenWidth(pBlockStitch.Strands, isBackstitchWidthVariable, iPixelsPerCell)

        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        If pStitchDisplayStyle = 2 Then
            pDesignGraphics.FillRectangle(New SolidBrush(_threadColour), New Rectangle(_tl, _size))
        End If

        If pStitchDisplayStyle = 1 Then
            Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(pBlockStitch.ProjThread.Thread)
            pDesignGraphics.DrawImage(_symImage, New Rectangle(_tl, _size), 0, 0, _symImage.Width, _symImage.Height, GraphicsUnit.Pixel, _imageAttributes)
        Else
            pDesignGraphics.DrawImage(_symImage, pX, pY, oPagePixelsPerCell, oPagePixelsPerCell)
        End If
        _crossPen.Dispose()
    End Sub
    Friend Function MakePrintImage(pBlockStitch As BlockStitch) As Image
        Return MakeImage(pBlockStitch, oPagePixelsPerCell)
    End Function

    Public Function MakeImage(pBlockStitch As BlockStitch, pPixels As Integer) As Image

        Dim _image As Image = New Bitmap(1, 1)
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Threads.Find(Function(p) p.ThreadId = pBlockStitch.ProjThread.ThreadId), ProjectThread)
        If _projectThread Is Nothing Then
            LogUtil.DisplayStatusMessage("Thread missing from project :" & vbCrLf & pBlockStitch.ProjThread.Thread.ToString, Nothing, "MakeImage", False)
        Else
            Dim _symbol As Symbol = FindSymbolById(_projectThread.SymbolId)
            _image = ImageUtil.ResizeImage(_symbol.SymbolImage, pPixels, pPixels)
        End If
        Return _image
    End Function
    Friend Sub PrintHalfBlockStitch(pBlockStitch As BlockStitch, pIsBack As Boolean, ByRef pDesignGraphics As Graphics, pPage As Page)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = ((pBlockStitch.BlockPosition.X + oPrintProject.OriginX - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockStitch.BlockPosition.Y + oPrintProject.OriginY - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        SetStitchPenWidth(pBlockStitch.Strands, isBackstitchWidthVariable, iPixelsPerCell)
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
        Dim pX As Integer = ((pBlockstitch.BlockPosition.X + oPrintProject.OriginX - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockstitch.BlockPosition.Y + oPrintProject.OriginY - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        SetStitchPenWidth(pBlockstitch.Strands, isBackstitchWidthVariable, iPixelsPerCell)

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
        Dim pX As Integer = ((pBlockstitch.BlockPosition.X + oPrintProject.OriginX - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim pY As Integer = ((pBlockstitch.BlockPosition.Y + oPrintProject.OriginY - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin

        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oPagePixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oPagePixelsPerCell)
        Dim _br As New Point(pX + oPagePixelsPerCell, pY + oPagePixelsPerCell)
        SetStitchPenWidth(pBlockstitch.Strands, isBackstitchWidthVariable, iPixelsPerCell)
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
        'If isBackstitchWidthVariable Then
        '    oStitchPenWidth = Math.Max(2, oPagePixelsPerCell / oVariableWidthFraction)
        'Else
        '    oStitchPenWidth = oBackstitchPenDefaultWidth
        'End If
        SetStitchPenWidth(pBackstitch.Strands, isBackstitchWidthVariable, iPixelsPerCell)

        Dim _fromCellLocation_x As Integer = ((pBackstitch.FromBlockPosition.X + oPrintProject.OriginX - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim _fromCellLocation_y As Integer = ((pBackstitch.FromBlockPosition.Y + oPrintProject.OriginY - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _toCellLocation_x As Integer = ((pBackstitch.ToBlockPosition.X + oPrintProject.OriginX - pPage.TopLeft.X) * oPagePixelsPerCell) + oLeftMargin
        Dim _toCellLocation_y As Integer = ((pBackstitch.ToBlockPosition.Y + oPrintProject.OriginY - pPage.TopLeft.Y) * oPagePixelsPerCell) + oTopMargin
        Dim _pen As New Pen(pBackstitch.ProjThread.Thread.Colour, oStitchPenWidth) With {
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
        Dim _knotlocation_x As Integer = ((pKnot.BlockPosition.X + oPrintProject.OriginX - pPage.TopLeft.X) * oPagePixelsPerCell) - (oPagePixelsPerCell / 4) + oLeftMargin
        Dim _knotlocation_y As Integer = ((pKnot.BlockPosition.Y + oPrintProject.OriginY - pPage.TopLeft.Y) * oPagePixelsPerCell) - (oPagePixelsPerCell / 4) + oTopMargin
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
        LblPageCt.Text = CStr(_pagesTotal)
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
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, 0), New Size(oPrintablePageWidth, oTopMargin - 2)))
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, oBottomGapY), New Size(oPrintablePageWidth, oPrintablePageHeight - oBottomGapY - 2)))
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, 0), New Size(oLeftMargin - 2, oPrintablePageHeight)))
        pPageGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(oRightGapX, 0), New Size(oPrintablePageWidth - oRightGapX - 2, A4_HEIGHT)))
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
            Next
            For _row = 0 To _heightInRows
                DrawGridHorizontalLine(pPageGraphics, oPrintGrid1Pen, _row, _widthInPixels)
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
        pPageGraphics.DrawLine(pPen, New Point(oLeftMargin + (gap * pColumn), oTopMargin), New Point(oLeftMargin + (gap * pColumn), oTopMargin + pGridHeightInpixels))
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
    Private Sub CreatePrintBitmap()
        SetPrintFonts()
        oPrintBitmap = New Bitmap(oPrintablePageWidth, oPrintablePageHeight)
        oPrintBitmap.SetResolution(PRINT_DPI, PRINT_DPI)
        oPrintGraphics = Graphics.FromImage(oPrintBitmap)
        CreatePageGraphics(oSelectedPage, oPrintGraphics, oPrintBitmap.Size, oPagePixelsPerCell)
    End Sub
    Private Sub CreateKeyBitmap()
        SetPrintFonts()
        oPrintBitmap = New Bitmap(oPrintablePageWidth, oPrintablePageHeight)
        oPrintBitmap.SetResolution(PRINT_DPI, PRINT_DPI)
        oPrintGraphics = Graphics.FromImage(oPrintBitmap)
        CreateKeyGraphics(oPrintGraphics, oPrintBitmap.Size)
    End Sub
    Private Sub ChkPrintKey_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPrintKey.CheckedChanged
        isPrintKey = ChkPrintKey.Checked
    End Sub
#End Region
End Class