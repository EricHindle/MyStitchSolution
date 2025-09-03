' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Printing
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
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
#Region "variables"
    Private prtXOffset As Integer
    Private prtYOffset As Integer
    Private prtDesignBitmap As Bitmap
    Private prtProjectThreads As ProjectThreadCollection
    Private prtProjectDesign As ProjectDesign
    Private prtDesignGraphics As Graphics
    Private prtPixelsPerCell As Integer
    Private isLoading As Boolean = False
    Private isComponentInitialised As Boolean
    Private myPrintDoc As New Printing.PrintDocument
    Private leftmargin As Integer
    Private topmargin As Integer
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
            DisplayPrintImage(prtDesignBitmap, prtXOffset, prtYOffset, e)
        Catch ex As ApplicationException
            LogUtil.ShowException(ex, "DisplayImage", LblStatus, MyBase.Name)
        End Try
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isLoading = True
        BtnPrint.Enabled = False
        'Make panel same ratio as A4
        PnlPageImage.Width = PnlPageImage.Height / 297 * 210
        LoadFormFromSettings()
        prtPixelsPerCell = PnlPageImage.Width / (NudSqrPerInch.Value * 8.3)
        If oPrintProject IsNot Nothing AndAlso oPrintProject.IsLoaded Then
            LoadFormFromProject()
        End If
        isLoading = False
    End Sub
    Private Sub LoadFormFromSettings()
        ChkPrintKey.Checked = My.Settings.isPrintKey
        CbKeyOrder.SelectedIndex = My.Settings.PrintKeyOrder
        ChkKeySeparate.Checked = My.Settings.isKeySeparate
        ChkPrintGrid.Checked = My.Settings.isPrintGrid
        ChkCentreLines.Checked = My.Settings.isPrintCentreLines
        isPrintCentreOn = My.Settings.isPrintCentreLines
        isPrintGridOn = My.Settings.isPrintGrid
        ChkBlankBorder.Checked = My.Settings.isBlankBorder
        NudBlankBorder.Value = My.Settings.BlankBorderSize
        CbPrintStitchDisplay.SelectedIndex = My.Settings.DesignStitchDisplay
        NudSqrPerInch.Value = My.Settings.PrintSquaresPerInch
        NudOverlap.Value = My.Settings.TilingOverlap
        CbShading.SelectedIndex = My.Settings.OverlapShading
        ChkShowPageOrder.Checked = My.Settings.isShowPageOrder
        CbAbbrKey.SelectedIndex = My.Settings.AbbrevKey
        NudTopMargin.Value = My.Settings.PrintMarginTop
        NudBottomMargin.Value = My.Settings.PrintMarginBottom
        NudLeftMargin.Value = My.Settings.PrintMarginLeft
        NudRightMargin.Value = My.Settings.PrintMarginRight
        NudGrid1Lines.Value = My.Settings.PrintGrid1Lines
        NudGrid5Lines.Value = My.Settings.PrintGrid5Lines
        NudGrid10Lines.Value = My.Settings.PrintGrid10Lines
        NudBackstitchLines.Value = My.Settings.PrintBackstitchLines
        ChkTitleAboveGrid.Checked = My.Settings.isTitleAboveGrid
        ChkTitleAboveKey.Checked = My.Settings.isTitleAboveKey
        TxtDesignBy.Text = My.Settings.DesignBy
        TxtCopyright.Text = My.Settings.CopyrightBy
    End Sub
    Private Sub BtnSaveSettings_Click(sender As Object, e As EventArgs) Handles BtnSaveSettings.Click
        My.Settings.isPrintKey = ChkPrintKey.Checked
        My.Settings.PrintKeyOrder = CbKeyOrder.SelectedIndex
        My.Settings.isKeySeparate = ChkKeySeparate.Checked
        My.Settings.isPrintGrid = ChkPrintGrid.Checked
        My.Settings.isPrintCentreLines = ChkCentreLines.Checked
        My.Settings.isBlankBorder = ChkBlankBorder.Checked
        My.Settings.BlankBorderSize = NudBlankBorder.Value
        My.Settings.DesignStitchDisplay = CbPrintStitchDisplay.SelectedIndex
        My.Settings.PrintSquaresPerInch = NudSqrPerInch.Value
        My.Settings.TilingOverlap = NudOverlap.Value
        My.Settings.OverlapShading = CbShading.SelectedIndex
        My.Settings.isShowPageOrder = ChkShowPageOrder.Checked
        My.Settings.AbbrevKey = CbAbbrKey.SelectedIndex
        My.Settings.PrintMarginTop = NudTopMargin.Value
        My.Settings.PrintMarginBottom = NudBottomMargin.Value
        My.Settings.PrintMarginLeft = NudLeftMargin.Value
        My.Settings.PrintMarginRight = NudRightMargin.Value
        My.Settings.PrintGrid1Lines = NudGrid1Lines.Value
        My.Settings.PrintGrid5Lines = NudGrid5Lines.Value
        My.Settings.PrintGrid10Lines = NudGrid10Lines.Value
        My.Settings.PrintBackstitchLines = NudBackstitchLines.Value
        My.Settings.isTitleAboveGrid = ChkTitleAboveGrid.Checked
        My.Settings.isTitleAboveKey = ChkTitleAboveKey.Checked
        My.Settings.DesignBy = TxtDesignBy.Text
        My.Settings.CopyrightBy = TxtCopyright.Text
        My.Settings.Save()
    End Sub
    Private Sub LoadFormFromProject()
        TxtTitle.Text = oPrintProject.ProjectName
        prtProjectThreads = GetProjectThreads(oPrintProject.ProjectId)
        LoadPrintDesignFromFile(oPrintProject, PicDesign, isPrintGridOn, isPrintCentreOn)
    End Sub
    Public Function LoadPrintDesignFromFile(pProject As Project, pPictureBox As PictureBox, pIsGridOn As Boolean, pIsCentreOn As Boolean)
        Dim oDesignString As List(Of String) = OpenDesignFile(oDesignFolderName, MakeFilename(pProject) & ZIP_EXT)
        prtProjectDesign = New ProjectDesign
        For Each oLine As String In oDesignString
            If Not String.IsNullOrEmpty(oLine) Then
                If oLine.StartsWith(DESIGN_HDR) Then
                    Dim _designValues As String() = oLine.Split(DESIGN_DELIM)
                    prtProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(_designValues).Build
                    Exit For
                End If
            End If
        Next
        prtProjectDesign.ProjectId = pProject.ProjectId
        If Not oProjectDesign.IsLoaded Then
            oProjectDesign.Rows = pProject.DesignHeight
            oProjectDesign.Columns = pProject.DesignWidth
        End If

        oGrid1width = NudGrid1Lines.Value
        oGrid5width = NudGrid5Lines.Value
        oGrid10width = NudGrid10Lines.Value
        oGrid1Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid1Colour, oGridColourList))
        oGrid5Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid5Colour, oGridColourList))
        oGrid10Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid10Colour, oGridColourList))
        oCentrePenWidth = NudCentreLines.Value
        oCentrePenColor = My.Settings.CentrelineColour
        oCentrePen = New Pen(oCentrePenColor, oCentrePenWidth)
        DrawPrintDesign(pPictureBox, True, pIsGridOn, pIsCentreOn)
        Return prtProjectDesign
    End Function
    Private Sub ChkPrintGrid_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPrintGrid.CheckedChanged
        isPrintGridOn = Not isPrintGridOn
        If isComponentInitialised AndAlso Not isLoading Then
            DrawPrintDesign(PicDesign, False, isPrintGridOn, isPrintCentreOn)
        End If
    End Sub
    Private Sub ChkCentreLines_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCentreLines.CheckedChanged
        isPrintCentreOn = Not isPrintCentreOn
        If isComponentInitialised AndAlso Not isLoading Then
            DrawPrintDesign(PicDesign, False, isPrintGridOn, isPrintCentreOn)
        End If
    End Sub
    Private Sub CbDesignStitchDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbPrintStitchDisplay.SelectedIndexChanged
        oStitchDisplayStyle = CbPrintStitchDisplay.SelectedIndex
        If isComponentInitialised AndAlso Not isLoading Then
            DrawPrintDesign(PicDesign, False, isPrintGridOn, isPrintCentreOn)
        End If
    End Sub
    Private Sub PnlPageImage_SizeChanged(sender As Object, e As EventArgs) Handles PnlPageImage.SizeChanged
        If isComponentInitialised Then
            PnlPageImage.Width = PnlPageImage.Height / 297 * 210
            prtPixelsPerCell = PnlPageImage.Width / (NudSqrPerInch.Value * 8.3)
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        LogUtil.ShowStatus("Printing design", LblStatus, MyBase.Name)
        oGrid1width = NudGrid1Lines.Value
        oGrid5width = NudGrid5Lines.Value
        oGrid10width = NudGrid10Lines.Value
        oCentrePenWidth = NudCentreLines.Value
        Dim _paperKind As PaperKind = PaperKind.A4
        myPrintDoc = New PrintDocument
        ' Set default paper size
        For Each ps As Printing.PaperSize In myPrintDoc.PrinterSettings.PaperSizes
            If ps.RawKind = _paperKind Then
                myPrintDoc.DefaultPageSettings.PaperSize = ps
                Exit For
            End If
        Next
        ' Set handler to print image 
        AddHandler myPrintDoc.PrintPage, AddressOf OnPrintImage
        ' Set default page settings
        myPrintDoc.DefaultPageSettings.Landscape = True
        myPrintDoc.DefaultPageSettings.Margins.Left = 0
        myPrintDoc.DefaultPageSettings.Margins.Right = 0
        myPrintDoc.DefaultPageSettings.Margins.Top = 0
        myPrintDoc.DefaultPageSettings.Margins.Bottom = 0
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
        leftmargin = e.PageSettings.HardMarginX * 3
        topmargin = e.PageSettings.HardMarginY * 3
        'Dim targetWidth As Integer = sourceBitmap.Width - leftmargin
        'Dim targetHeight As Integer = sourceBitmap.Height - topmargin

        '' Print the image, cutting off the left and top parts that the printer cannot print
        'e.Graphics.DrawImage(sourceBitmap, 0, 0, New Rectangle(leftmargin, topmargin, targetWidth, targetHeight), GraphicsUnit.Document)
        LogUtil.ShowStatus("Printing done", LblStatus, MyBase.Name)
    End Sub
    Public Sub DrawPrintDesign(pPicturebox As PictureBox, pIsReCentre As Boolean, pIsGridOn As Boolean, pIsCentreOn As Boolean)
        ' Create image the size of the design
        prtDesignBitmap = New Bitmap(CInt(prtProjectDesign.Columns * prtPixelsPerCell), CInt(prtProjectDesign.Rows * prtPixelsPerCell))
        If pIsReCentre Then
            '       CalculateOffsetForCentre(oDesignBitmap, pPicturebox)
        End If
        'Draw grid onto graphics
        'Create graphics from image
        prtDesignGraphics = Graphics.FromImage(prtDesignBitmap)
        prtDesignGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        FillBeforeGrid(prtProjectDesign)
        DrawGrid(prtProjectDesign, pIsGridOn, pIsCentreOn)
        FillAfterGrid()
        pPicturebox.Invalidate()
    End Sub
    Public Sub DisplayPrintImage(pImage As Bitmap, pX As Integer, pY As Integer, e As PaintEventArgs)
        If pImage Is Nothing Then Exit Sub
        Dim rect As Rectangle
        Dim picx As Single = prtPixelsPerCell * topcorner.X
        Dim picy As Single = prtPixelsPerCell * topcorner.Y
        Dim picw As Single = prtDesignBitmap.Width - picx
        Dim pich As Single = prtDesignBitmap.Height - picy
        Dim atX As Single = pX * prtPixelsPerCell
        Dim atY As Single = pY * prtPixelsPerCell
        rect = New Rectangle(picx, picy, picw, pich)
        Try
            e.Graphics.DrawImage(pImage, atX, atY, rect, GraphicsUnit.Pixel)
        Catch ex As Exception
            Throw New ApplicationException("Cannot display the image:" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
End Class