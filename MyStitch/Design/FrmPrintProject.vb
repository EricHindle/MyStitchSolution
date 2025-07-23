' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain.Objects
Imports MyStitch.Domain
Public Class FrmPrintProject
#Region "properties"
    Private oProjectId As Integer
    Public WriteOnly Property ProjectId() As Integer
        Set(ByVal value As Integer)
            oProjectId = value
        End Set
    End Property

#End Region
#Region "variables"
    Private isLoading As Boolean = False
    Private isComponentInitialised As Boolean
#End Region
#Region "form control handlers"
    Private Sub FrmPrintProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening print", MyBase.Name)
        GetFormPos(Me, My.Settings.PrintFormPos)
        PnlPageImage.Width = PnlPageImage.Height / 297 * 210
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oDesignBitmap = Nothing
        My.Settings.PrintFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        DisplayImage(oDesignBitmap, iXOffset, iYOffset, e)
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isLoading = True
        oProject = GetProjectById(oProjectId)
        BtnPrint.Enabled = False
        LoadFormFromSettings()
        If oProject IsNot Nothing AndAlso oProject.IsLoaded Then
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
        TxtTitle.Text = oProject.ProjectName
        oProjectThreads = GetProjectThreads(oProject.ProjectId)
        LoadProjectDesignFromFile(oProject, PicDesign, isPrintGridOn, isPrintCentreOn)
        AdjustMagnification()
    End Sub

    Private Sub AdjustMagnification()
        isLoading = True
        Dim _xOffset As Integer = 0
        Dim _yOffset As Integer = 0
        If ChkBlankBorder.Checked Then
            _xOffset = NudBlankBorder.Value
            _yOffset = NudBlankBorder.Value
        End If
        _xOffset += NudLeftMargin.Value
        _yOffset += NudTopMargin.Value
        Dim totalcellsavailable As Integer = NudSqrPerInch.Value * 8.27
        totalcellsavailable = totalcellsavailable - _xOffset - NudRightMargin.Value - NudLeftMargin.Value
        iPixelsPerCell = PicDesign.Width / totalcellsavailable
        dMagnification = iPixelsPerCell / PIXELS_PER_CELL
        CalculateOffsetAfterChange_NoScrollBars(_xOffset, _yOffset)
        RedrawDesign(PicDesign, False, isPrintGridOn, isPrintCentreOn)
        isLoading = False
    End Sub
    Private Sub ChkPrintGrid_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPrintGrid.CheckedChanged
        isPrintGridOn = Not isPrintGridOn
        If isComponentInitialised AndAlso Not isLoading Then
            RedrawDesign(PicDesign, isPrintGridOn, isPrintCentreOn)
        End If
    End Sub

    Private Sub ChkCentreLines_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCentreLines.CheckedChanged
        isPrintCentreOn = Not isPrintCentreOn
        If isComponentInitialised AndAlso Not isLoading Then
            RedrawDesign(PicDesign, isPrintGridOn, isPrintCentreOn)
        End If
    End Sub

    Private Sub CbDesignStitchDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbPrintStitchDisplay.SelectedIndexChanged
        oStitchDisplayStyle = CbPrintStitchDisplay.SelectedIndex
        If isComponentInitialised AndAlso Not isLoading Then
            RedrawDesign(PicDesign, isPrintGridOn, isPrintCentreOn)
        End If
    End Sub

    Private Sub PnlPageImage_SizeChanged(sender As Object, e As EventArgs) Handles PnlPageImage.SizeChanged

        PnlPageImage.Width = PnlPageImage.Height / 297 * 210
    End Sub
#End Region
End Class