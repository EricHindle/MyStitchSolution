' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain.Objects

Public Class FrmPrintProject
#Region "properties"

    Private _selectedProject As Project
    Public Property SelectedProject() As Project
        Get
            Return _selectedProject
        End Get
        Set(ByVal value As Project)
            _selectedProject = value
        End Set
    End Property
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
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        LoadProjectList(DgvProjects, MyBase.Name)
        If _selectedProject IsNot Nothing AndAlso _selectedProject.ProjectId > 0 Then
            SelectProjectInList(DgvProjects, _selectedProject.ProjectId)
        End If
        LoadFormFromSettings
    End Sub

    Private Sub LoadFormFromSettings()
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
        TxtTitle.Text = _selectedProject.ProjectName
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
        My.Settings.isTitleAboveGrid = ChkTitleAboveGrid.Checked
        My.Settings.isTitleAboveKey = ChkTitleAboveKey.Checked
        My.Settings.DesignBy = TxtDesignBy.Text
        My.Settings.CopyrightBy = TxtCopyright.Text
        My.Settings.Save()
    End Sub
#End Region
End Class