' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmPrintOptions
#Region "form control handlers"
    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading Print Options", MyBase.Name)
        GetFormPos(Me, My.Settings.PrintOptionsFormPos)
        LoadOptions()
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
#End Region
#Region "subroutines"
    Private Sub SaveOptions()
        My.Settings.AbbrevKey = CbAbbrKey.SelectedIndex
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

        My.Settings.Save()
    End Sub
    Private Sub SetLineColour(pPic As PictureBox, pComboBox As ComboBox, pColourSetting As Integer)
        pPic.BackColor = GetColourFromProject(pColourSetting, oGridColourList)
        Select Case pColourSetting
            Case 1 To 4
                pComboBox.SelectedIndex = pColourSetting - 1
            Case Else
                pComboBox.SelectedIndex = pComboBox.Items.Count - 1
        End Select
    End Sub
    Private Sub LoadOptions()
        CbAbbrKey.SelectedIndex = My.Settings.AbbrevKey
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
    End Sub

#End Region
End Class