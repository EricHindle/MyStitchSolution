' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmPrintOptions
    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        LoadOptions()
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveOptions()
        Close()
    End Sub

    Private Sub SaveOptions()
        My.Settings.isPrintKey = ChkPrintKey.Checked
        My.Settings.PrintKeyOrder = CbKeyOrder.SelectedIndex
        My.Settings.isKeySeparate = ChkKeySeparate.Checked
        My.Settings.isPrintGrid = ChkPrintGrid.Checked
        My.Settings.isPrintCentreMarks = ChkPrintCentre.Checked
        My.Settings.isPrintCentreLines = ChkCentreLines.Checked
        My.Settings.isBlankBorder = ChkBlankBorder.Checked
        My.Settings.BlankBorderSize = NudBlankBorder.Value
        My.Settings.DesignStitchDisplay = CbDesignStitchDisplay.SelectedIndex
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
        My.Settings.isTitleAboveKey = ChkTitleAboveKey.Checked
        My.Settings.isTitleAboveGrid = ChkTitleAboveGrid.Checked
        My.Settings.DesignBy = TxtDesignBy.Text
        My.Settings.CopyrightBy = TxtCopyright.Text
        My.Settings.Save()
    End Sub
    Private Sub LoadOptions()
        ChkPrintKey.Checked = My.Settings.isPrintKey
        CbKeyOrder.SelectedIndex = My.Settings.PrintKeyOrder
        ChkKeySeparate.Checked = My.Settings.isKeySeparate
        ChkPrintGrid.Checked = My.Settings.isPrintGrid
        ChkPrintCentre.Checked = My.Settings.isPrintCentreMarks
        ChkCentreLines.Checked = My.Settings.isPrintCentreLines
        ChkBlankBorder.Checked = My.Settings.isBlankBorder
        NudBlankBorder.Value = My.Settings.BlankBorderSize
        CbDesignStitchDisplay.SelectedIndex = My.Settings.DesignStitchDisplay
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
        ChkTitleAboveKey.Checked = My.Settings.isTitleAboveKey
        ChkTitleAboveGrid.Checked = My.Settings.isTitleAboveGrid
        TxtDesignBy.Text = My.Settings.DesignBy
        TxtCopyright.Text = My.Settings.CopyrightBy
    End Sub


End Class