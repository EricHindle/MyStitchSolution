' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmPrintOptions
#Region "variables"
    Private isComponentInitialized As Boolean
#End Region
#Region "form control handlers"
    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading Print Options", MyBase.Name)
        GetFormPos(Me, My.Settings.PrintOptionsFormPos)
        LoadOptions()
        isComponentInitialized = True
        AdjustImage()
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        LogUtil.Info("Saving Print Options", MyBase.Name)
        SaveOptions()
        Close()
    End Sub
    Private Sub FrmPrintOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.PrintOptionsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnTitleFont_Click(sender As Object, e As EventArgs) Handles BtnTitleFont.Click
        FontDialog1.Font = BtnTitleFont.Font
        FontDialog1.ShowDialog()
        BtnTitleFont.Font = FontDialog1.Font
    End Sub
    Private Sub BtnTextFont_Click(sender As Object, e As EventArgs) Handles BtnTextFont.Click
        FontDialog1.Font = BtnTextFont.Font
        FontDialog1.ShowDialog()
        BtnTextFont.Font = FontDialog1.Font
    End Sub
    Private Sub BtnFooterFont_Click(sender As Object, e As EventArgs) Handles BtnFooterFont.Click
        FontDialog1.Font = BtnFooterFont.Font
        FontDialog1.ShowDialog()
        BtnFooterFont.Font = FontDialog1.Font
    End Sub
    Private Sub CbColour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid1Colour.SelectedIndexChanged,
                                                                                        CbGrid5Colour.SelectedIndexChanged,
                                                                                        CbGrid10Colour.SelectedIndexChanged
        Dim comboBox As ComboBox = CType(sender, ComboBox)
        Select Case comboBox.Name
            Case CbGrid1Colour.Name
                SetGridColour(comboBox, PicGrid1Colour)
            Case CbGrid5Colour.Name
                SetGridColour(comboBox, PicGrid5Colour)
            Case CbGrid10Colour.Name
                SetGridColour(comboBox, PicGrid10Colour)
        End Select
    End Sub
    Private Sub PicColour_Click(sender As Object, e As EventArgs) Handles PicGrid1Colour.Click,
                                                                          PicGrid5Colour.Click,
                                                                          PicGrid10Colour.Click
        Dim pic As PictureBox = CType(sender, PictureBox)
        Dim _old As Color = pic.BackColor
        Dim _new As Color = SelectColor(pic.BackColor)
        If _old <> _new Then
            pic.BackColor = _new
            Select Case pic.Name
                Case PicGrid1Colour.Name
                    CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1
                Case PicGrid5Colour.Name
                    CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1
                Case PicGrid10Colour.Name
                    CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1
            End Select
        End If
    End Sub
    Private Sub NudTopMargin_ValueChanged(sender As Object, e As EventArgs) Handles NudTopMargin.ValueChanged,
                                                                                    NudLeftMargin.ValueChanged,
                                                                                    NudRightMargin.ValueChanged,
                                                                                    NudBottomMargin.ValueChanged,
                                                                                    ChkPrintFooter.CheckedChanged,
                                                                                    ChkPrintHeader.CheckedChanged,
                                                                                    ChkPrintGrid.CheckedChanged
        AdjustImage()
    End Sub
    Private Sub PicCentreLineColour_Click(sender As Object, e As EventArgs) Handles PicCentreLineColour.Click
        PicCentreLineColour.BackColor = SelectColor(PicCentreLineColour.BackColor)
    End Sub
#End Region
#Region "subroutines"
    Private Sub AdjustImage()
        Dim ppi As Decimal = PnlOuter.Width / 8.3
        Dim lMargin As Decimal = NudLeftMargin.Value
        Dim rMargin As Decimal = NudRightMargin.Value
        Dim tMargin As Decimal = NudTopMargin.Value
        Dim bMargin As Decimal = NudBottomMargin.Value
        Dim lPix As Integer = lMargin * ppi
        Dim rPix As Integer = rMargin * ppi
        Dim tPix As Integer = tMargin * ppi
        Dim bPix As Integer = bMargin * ppi
        If isComponentInitialized Then
            PnlInner.Width = PnlOuter.Width - lPix - rPix - 2
            PnlInner.Height = PnlOuter.Height - tPix - bPix - 2
            PnlInner.Location = New Point(lPix, tPix)
            If ChkPrintHeader.Checked Then
                PnlGrid.Dock = DockStyle.None
                PnlGrid.Location = New Point(0, PnlTitle.Height)
            Else
                PnlGrid.Dock = DockStyle.Top
            End If
            PnlGrid.Height = PnlInner.Height - If(ChkPrintHeader.Checked, PnlTitle.Height, 0) - If(ChkPrintFooter.Checked, PnlFooter.Height, 0)
            PnlGrid.Width = PnlInner.Width
            PnlTitle.Visible = ChkPrintHeader.Checked
            PnlFooter.Visible = ChkPrintFooter.Checked
            PnlGrid.Visible = ChkPrintGrid.Checked
        End If
    End Sub
    Private Sub SaveOptions()
        My.Settings.CopyrightBy = TxtCopyright.Text
        My.Settings.DesignBy = TxtDesignBy.Text
        My.Settings.OverlapShading = CbShading.SelectedIndex
        My.Settings.PrintKeyOrder = CbKeyOrder.SelectedIndex
        My.Settings.PrintMarginBottom = NudBottomMargin.Value
        My.Settings.PrintMarginLeft = NudLeftMargin.Value
        My.Settings.PrintMarginRight = NudRightMargin.Value
        My.Settings.PrintMarginTop = NudTopMargin.Value
        My.Settings.PrintSquaresPerInch = NudSqrPerInch.Value
        My.Settings.TilingOverlap = NudOverlap.Value
        My.Settings.isPrintKey = ChkPrintKey.Checked
        My.Settings.isShowPageOrder = ChkShowPageOrder.Checked
        My.Settings.isPrintHeader = ChkPrintHeader.Checked
        My.Settings.isPrintFooter = ChkPrintFooter.Checked
        My.Settings.PrintGrid = ChkPrintGrid.Checked
        My.Settings.PrintCentreMarks = ChkCentreMarks.Checked
        My.Settings.PrintCentreLines = ChkCentreLines.Checked
        My.Settings.PrintFooterFont = BtnFooterFont.Font
        My.Settings.PrintTextFont = BtnTextFont.Font
        My.Settings.PrintTitleFont = BtnTitleFont.Font
        My.Settings.PrintRowNumbers = ChkRowNumbers.Checked
        My.Settings.PrintColumnNumbers = ChkColumnNumbers.Checked
        My.Settings.PrintCentreLineColour = PicCentreLineColour.BackColor
        My.Settings.PrintCentreLineThickness = NudCentreLineWidth.Value
        My.Settings.PrintGrid1Colour = If(CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1, PicGrid1Colour.BackColor.ToArgb, CbGrid1Colour.SelectedIndex + 1)
        My.Settings.PrintGrid5Colour = If(CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1, PicGrid5Colour.BackColor.ToArgb, CbGrid5Colour.SelectedIndex + 1)
        My.Settings.PrintGrid10Colour = If(CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1, PicGrid10Colour.BackColor.ToArgb, CbGrid10Colour.SelectedIndex + 1)
        My.Settings.PrintBorderThickness = NudBorderThickness.Value
        My.Settings.Save()
    End Sub
    Private Sub LoadOptions()
        CbKeyOrder.SelectedIndex = My.Settings.PrintKeyOrder
        CbShading.SelectedIndex = My.Settings.OverlapShading
        ChkPrintKey.Checked = My.Settings.isPrintKey
        ChkShowPageOrder.Checked = My.Settings.isShowPageOrder
        ChkPrintHeader.Checked = My.Settings.isPrintHeader
        ChkPrintFooter.Checked = My.Settings.isPrintFooter
        NudBottomMargin.Value = My.Settings.PrintMarginBottom
        NudLeftMargin.Value = My.Settings.PrintMarginLeft
        NudOverlap.Value = My.Settings.TilingOverlap
        NudRightMargin.Value = My.Settings.PrintMarginRight
        NudSqrPerInch.Value = My.Settings.PrintSquaresPerInch
        NudTopMargin.Value = My.Settings.PrintMarginTop
        TxtCopyright.Text = My.Settings.CopyrightBy
        TxtDesignBy.Text = My.Settings.DesignBy
        ChkPrintGrid.Checked = My.Settings.PrintGrid
        ChkCentreMarks.Checked = My.Settings.PrintCentreMarks
        ChkCentreLines.Checked = My.Settings.PrintCentreLines
        BtnTitleFont.Font = My.Settings.PrintTitleFont
        BtnTextFont.Font = My.Settings.PrintTextFont
        BtnFooterFont.Font = My.Settings.PrintFooterFont
        ChkRowNumbers.Checked = My.Settings.PrintRowNumbers
        ChkColumnNumbers.Checked = My.Settings.PrintColumnNumbers
        PicCentreLineColour.BackColor = My.Settings.PrintCentreLineColour
        NudCentreLineWidth.Value = My.Settings.PrintCentreLineThickness
        NudBorderThickness.Value = My.Settings.PrintBorderThickness
        SetLineColour(PicGrid10Colour, CbGrid10Colour, My.Settings.PrintGrid10Colour)
        SetLineColour(PicGrid1Colour, CbGrid1Colour, My.Settings.PrintGrid1Colour)
        SetLineColour(PicGrid5Colour, CbGrid5Colour, My.Settings.PrintGrid5Colour)
    End Sub
#End Region
End Class