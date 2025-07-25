' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmPrintOptions
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
    Private Sub SaveOptions()
        My.Settings.AbbrevKey = CbAbbrKey.SelectedIndex
        My.Settings.BlankBorderSize = NudBlankBorder.Value
        My.Settings.CopyrightBy = TxtCopyright.Text
        My.Settings.DesignBy = TxtDesignBy.Text
        My.Settings.DesignStitchDisplay = CbDesignStitchDisplay.SelectedIndex
        My.Settings.OverlapShading = CbShading.SelectedIndex
        My.Settings.PrintBackstitchLines = NudBackstitchLines.Value
        My.Settings.PrintCentreLineThickness = NudCentreLines.Value
        My.Settings.PrintCentrelineColour = If(CbCentrelineColour.SelectedIndex = CbCentrelineColour.Items.Count - 1, PicCentrelineColour.BackColor.ToArgb, CbCentrelineColour.SelectedIndex + 1)
        My.Settings.PrintGrid10Colour = If(CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1, PicGrid10Colour.BackColor.ToArgb, CbGrid10Colour.SelectedIndex + 1)
        My.Settings.PrintGrid10Lines = NudGrid10Lines.Value
        My.Settings.PrintGrid1Colour = If(CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1, PicGrid1Colour.BackColor.ToArgb, CbGrid1Colour.SelectedIndex + 1)
        My.Settings.PrintGrid1Lines = NudGrid1Lines.Value
        My.Settings.PrintGrid5Colour = If(CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1, PicGrid5Colour.BackColor.ToArgb, CbGrid5Colour.SelectedIndex + 1)
        My.Settings.PrintGrid5Lines = NudGrid5Lines.Value
        My.Settings.PrintKeyOrder = CbKeyOrder.SelectedIndex
        My.Settings.PrintMarginBottom = NudBottomMargin.Value
        My.Settings.PrintMarginLeft = NudLeftMargin.Value
        My.Settings.PrintMarginRight = NudRightMargin.Value
        My.Settings.PrintMarginTop = NudTopMargin.Value
        My.Settings.PrintSquaresPerInch = NudSqrPerInch.Value
        My.Settings.TilingOverlap = NudOverlap.Value
        My.Settings.isBlankBorder = ChkBlankBorder.Checked
        My.Settings.isKeySeparate = ChkKeySeparate.Checked
        My.Settings.isPrintCentreLines = ChkCentreLines.Checked
        My.Settings.isPrintGrid = ChkPrintGrid.Checked
        My.Settings.isPrintKey = ChkPrintKey.Checked
        My.Settings.isShowPageOrder = ChkShowPageOrder.Checked
        My.Settings.isTitleAboveGrid = ChkTitleAboveGrid.Checked
        My.Settings.isTitleAboveKey = ChkTitleAboveKey.Checked
        My.Settings.Save()
    End Sub
    Private Sub PicColour_Click(sender As Object, e As EventArgs) Handles PicGrid1Colour.Click,
                                                                            PicGrid5Colour.Click,
                                                                            PicGrid10Colour.Click,
                                                                            PicCentrelineColour.Click
        Dim pic As PictureBox = CType(sender, PictureBox)
        pic.BackColor = SelectColor(pic.BackColor)
        Select Case pic.Name
            Case "PicGrid1Colour"
                CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1
            Case "PicGrid5Colour"
                CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1
            Case "PicGrid10Colour"
                CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1
            Case "PicCentrelineColour"
                CbCentrelineColour.SelectedIndex = CbCentrelineColour.Items.Count - 1
        End Select
    End Sub
    Private Sub CbColour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid1Colour.SelectedIndexChanged,
                                                                            CbGrid5Colour.SelectedIndexChanged,
                                                                            CbGrid10Colour.SelectedIndexChanged,
                                                                            CbCentrelineColour.SelectedIndexChanged
        Dim comboBox As ComboBox = CType(sender, ComboBox)
        Select Case comboBox.SelectedIndex
            Case 0 To comboBox.Items.Count - 2
                Dim pic As PictureBox = Nothing
                Select Case comboBox.Name
                    Case "CbGrid1Colour"
                        pic = PicGrid1Colour
                        pic.BackColor = oGridColourList(comboBox.SelectedIndex)
                    Case "CbGrid5Colour"
                        pic = PicGrid5Colour
                        pic.BackColor = oGridColourList(comboBox.SelectedIndex)
                    Case "CbGrid10Colour"
                        pic = PicGrid10Colour
                        pic.BackColor = oGridColourList(comboBox.SelectedIndex)
                    Case "CbCentrelineColour"
                        pic = PicCentrelineColour
                        pic.BackColor = oCentreColourList(comboBox.SelectedIndex)
                End Select
        End Select
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
        CbDesignStitchDisplay.SelectedIndex = My.Settings.DesignStitchDisplay
        CbKeyOrder.SelectedIndex = My.Settings.PrintKeyOrder
        CbShading.SelectedIndex = My.Settings.OverlapShading
        ChkBlankBorder.Checked = My.Settings.isBlankBorder
        ChkCentreLines.Checked = My.Settings.isPrintCentreLines
        ChkKeySeparate.Checked = My.Settings.isKeySeparate
        ChkPrintGrid.Checked = My.Settings.isPrintGrid
        ChkPrintKey.Checked = My.Settings.isPrintKey
        ChkShowPageOrder.Checked = My.Settings.isShowPageOrder
        ChkTitleAboveGrid.Checked = My.Settings.isTitleAboveGrid
        ChkTitleAboveKey.Checked = My.Settings.isTitleAboveKey
        NudBackstitchLines.Value = My.Settings.PrintBackstitchLines
        NudBlankBorder.Value = My.Settings.BlankBorderSize
        NudBottomMargin.Value = My.Settings.PrintMarginBottom
        NudCentreLines.Value = My.Settings.PrintCentreLineThickness
        NudGrid10Lines.Value = My.Settings.PrintGrid10Lines
        NudGrid1Lines.Value = My.Settings.PrintGrid1Lines
        NudGrid5Lines.Value = My.Settings.PrintGrid5Lines
        NudLeftMargin.Value = My.Settings.PrintMarginLeft
        NudOverlap.Value = My.Settings.TilingOverlap
        NudRightMargin.Value = My.Settings.PrintMarginRight
        NudSqrPerInch.Value = My.Settings.PrintSquaresPerInch
        NudTopMargin.Value = My.Settings.PrintMarginTop
        SetLineColour(PicCentrelineColour, CbCentrelineColour, My.Settings.PrintCentrelineColour)
        SetLineColour(PicGrid10Colour, CbGrid10Colour, My.Settings.PrintGrid10Colour)
        SetLineColour(PicGrid1Colour, CbGrid1Colour, My.Settings.PrintGrid1Colour)
        SetLineColour(PicGrid5Colour, CbGrid5Colour, My.Settings.PrintGrid5Colour)
        TxtCopyright.Text = My.Settings.CopyrightBy
        TxtDesignBy.Text = My.Settings.DesignBy
    End Sub
End Class