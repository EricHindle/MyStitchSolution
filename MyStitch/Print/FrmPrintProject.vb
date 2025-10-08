' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
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
            Dim x As Integer = Math.Floor(oLeftMargin / PageToFormRatio)
            Dim y As Integer = Math.Floor(oTopMargin / PageToFormRatio)
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
        BtnPrint.Enabled = False
        PageToFormRatio = Math.Ceiling(A4_WIDTH / PicDesign.Width)
        InitialisePrintDocument()
        ' Set handler to print image 
        AddHandler myPrintDoc.PrintPage, AddressOf OnPrintImage
        LoadFormFromSettings()
        'ModDesign.RedrawDesign(PicDesign, oDesignBitmap, oProjectDesign, oDesignGraphics, False, ChkPrintGrid.Checked, False, ChkCentreMarks.Checked)
        'oPagePixelsPerCell = DPI / NudSqrPerInch.Value
        LoadFormFromProject()
        '        oPageImage = New Bitmap(A4_WIDTH, A4_HEIGHT)
        ' oPageGraphics = Graphics.FromImage(oPageImage)
        isLoading = False
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
        CreatePageImage()
    End Sub

    Private Sub CreatePageImage()
        oPagePixelsPerCell = DPI / NudSqrPerInch.Value
        CalculateMargins(NudLeftMargin.Value, NudRightMargin.Value, NudTopMargin.Value, NudBottomMargin.Value)
        CalculateGridSpace(NudSqrPerInch.Value)
        ModDesign.RedrawDesign(PicDesign, oSourceImage, oProjectDesign, oDesignGraphics, False, ChkPrintGrid.Checked, False, ChkCentreMarks.Checked)
        oPageImage = ImageUtil.ResizeImage(oSourceImage, oProject.DesignWidth * oPagePixelsPerCell, oProject.DesignHeight * oPagePixelsPerCell)
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
        'Dim targetWidth As Integer = sourceBitmap.Width - leftmargin
        'Dim targetHeight As Integer = sourceBitmap.Height - topmargin

        '' Print the image, cutting off the left and top parts that the printer cannot print
        'e.Graphics.DrawImage(sourceBitmap, 0, 0, New Rectangle(leftmargin, topmargin, targetWidth, targetHeight), GraphicsUnit.Document)
        LogUtil.ShowStatus("Printing done", LblStatus, MyBase.Name)
    End Sub

    Private Sub NudTopMargin_ValueChanged(sender As Object, e As EventArgs) Handles NudTopMargin.ValueChanged,
                                                                                    NudLeftMargin.ValueChanged,
                                                                                    NudRightMargin.ValueChanged,
                                                                                    NudBottomMargin.ValueChanged,
                                                                                    ChkPrintGrid.CheckedChanged,
                                                                                    ChkCentreMarks.CheckedChanged,
                                                                                    NudSqrPerInch.ValueChanged
        If isComponentInitialised Then
            CreatePageImage()
        End If
    End Sub
#End Region
End Class