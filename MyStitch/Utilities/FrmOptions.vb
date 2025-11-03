' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public NotInheritable Class FrmOptions
#Region "properties"
    Private _originForm As Form
    Public Property OriginForm() As Form
        Get
            Return _originForm
        End Get
        Set(ByVal value As Form)
            _originForm = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading Option settings", MyBase.Name)
        GetFormPos(Me, My.Settings.OptionsFormPos)
        LoadOptions()
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        LogUtil.Info("Saving Option settings", MyBase.Name)
        SaveOptions()
        Close()
    End Sub
    'Private Sub BtnGlobalSettings_Click(sender As Object, e As EventArgs) Handles BtnGlobalSettings.Click
    '    Hide()
    '    OpenGlobalSettingsForm()
    '    Show()
    'End Sub
    Private Sub FrmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.OptionsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        OpenBackupForm()
    End Sub
    Private Sub BtnHousekeeping_Click(sender As Object, e As EventArgs) Handles BtnHousekeeping.Click
        RunHousekeeping()
    End Sub
    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles PicCentreLineColour.Click,
                                                                           PicSelectionBorderColour.Click
        Dim _picBox As PictureBox = CType(sender, PictureBox)
        _picBox.BackColor = SelectColor(_picBox.BackColor)
    End Sub
    Private Sub BtnPrintSettings_Click(sender As Object, e As EventArgs) Handles BtnPrintSettings.Click
        LogUtil.Info("Print Settings", MyBase.Name)
        Hide()
        Using _printSettings As New FrmPrintOptions
            _printSettings.ShowDialog()
        End Using
        Show()
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
#End Region
#Region "subroutines"
    Private Sub SaveOptions()
        My.Settings.ApplicationPath = TxtAppPath.Text
        My.Settings.BackupAddDate = ChkBackupAddDate.Checked
        My.Settings.BackupPath = TxtBackupPath.Text
        My.Settings.CentrelineColour = PicCentreLineColour.BackColor
        My.Settings.CentrelineWidth = NudCentreLineWidth.Value
        My.Settings.DataFilePath = TxtDataPath.Text
        My.Settings.DebugOn = ChkDebugOn.Checked
        My.Settings.DefaultFabricCount = NudFabricCount.Value
        My.Settings.DesignFilePath = TxtDesignFilePath.Text
        My.Settings.FileRetentionCopies = NudRetentionCopies.Value
        My.Settings.FileRetentionPeriod = NudRetentionDays.Value
        My.Settings.Grid10Colour = If(CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1, PicGrid10Colour.BackColor.ToArgb, CbGrid10Colour.SelectedIndex + 1)
        My.Settings.Grid10Thickness = NudGrid10Thickness.Value
        My.Settings.Grid1Colour = If(CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1, PicGrid1Colour.BackColor.ToArgb, CbGrid1Colour.SelectedIndex + 1)
        My.Settings.Grid1Thickness = NudGrid1Thickness.Value
        My.Settings.Grid5Colour = If(CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1, PicGrid5Colour.BackColor.ToArgb, CbGrid5Colour.SelectedIndex + 1)
        My.Settings.Grid5Thickness = NudGrid5Thickness.Value
        My.Settings.ImagePath = TxtImagePath.Text
        My.Settings.IsCentreOn = ChkCentreOn.Checked
        My.Settings.LogFolder = TxtLogFilePath.Text
        My.Settings.LogZoomOn = ChkLogZoom.Checked
        My.Settings.LogZoomValue = NudZoomValue.Value
        My.Settings.SelectionBorderColour = PicSelectionBorderColour.BackColor
        My.Settings.isAutoArchiveOnSave = ChkArchiveOnSave.Checked
        My.Settings.isAutoRunHousekeeping = ChkAutoRunHousekeeping.Checked
        My.Settings.isBackstitchWidthVariable = ChkBackstitchWidth.Checked
        My.Settings.isCentreMarksOn = ChkCentreMarks.Checked
        My.Settings.isGridOn = ChkGridOn.Checked
        My.Settings.isHousekeepData = ChkDataArchive.Checked
        My.Settings.isHousekeepDesigns = ChkDesignArchive.Checked
        My.Settings.isHousekeepLogs = ChkLogs.Checked
        My.Settings.isShowStockLevels = ChkShowStock.Checked
        My.Settings.isTimerAutoSave = ChkTimerAutoSave.Checked
        My.Settings.isTimerAutoStart = ChkTimerAutoStart.Checked
        My.Settings.DesignStitchDisplay = CbDesignStitchDisplay.SelectedIndex
        My.Settings.PaletteStitchDisplay = CbPaletteStitchDisplay.SelectedIndex
        My.Settings.Save()
        LogUtil.Info("Options saved", MyBase.Name)
    End Sub
    Private Sub LoadOptions()
        ChkArchiveOnSave.Checked = My.Settings.isAutoArchiveOnSave
        ChkAutoRunHousekeeping.Checked = My.Settings.isAutoRunHousekeeping
        ChkBackstitchWidth.Checked = My.Settings.isBackstitchWidthVariable
        ChkBackupAddDate.Checked = My.Settings.BackupAddDate
        ChkCentreMarks.Checked = My.Settings.isCentreMarksOn
        ChkCentreOn.Checked = My.Settings.IsCentreOn
        ChkDataArchive.Checked = My.Settings.isHousekeepData
        ChkDebugOn.Checked = My.Settings.DebugOn
        ChkDesignArchive.Checked = My.Settings.isHousekeepDesigns
        ChkGridOn.Checked = My.Settings.isGridOn
        ChkLogZoom.Checked = My.Settings.LogZoomOn
        ChkLogs.Checked = My.Settings.isHousekeepLogs
        ChkShowStock.Checked = My.Settings.isShowStockLevels
        ChkTimerAutoSave.Checked = My.Settings.isTimerAutoSave
        ChkTimerAutoStart.Checked = My.Settings.isTimerAutoStart
        NudCentreLineWidth.Value = My.Settings.CentrelineWidth
        NudFabricCount.Value = My.Settings.DefaultFabricCount
        NudGrid10Thickness.Value = My.Settings.Grid10Thickness
        NudGrid1Thickness.Value = My.Settings.Grid1Thickness
        NudGrid5Thickness.Value = My.Settings.Grid5Thickness
        NudRetentionCopies.Value = My.Settings.FileRetentionCopies
        NudRetentionDays.Value = My.Settings.FileRetentionPeriod
        NudZoomValue.Value = My.Settings.LogZoomValue
        PicCentreLineColour.BackColor = My.Settings.CentrelineColour
        PicSelectionBorderColour.BackColor = My.Settings.SelectionBorderColour
        SetLineColour(PicGrid10Colour, CbGrid10Colour, My.Settings.Grid10Colour)
        SetLineColour(PicGrid1Colour, CbGrid1Colour, My.Settings.Grid1Colour)
        SetLineColour(PicGrid5Colour, CbGrid5Colour, My.Settings.Grid5Colour)
        TxtAppPath.Text = My.Settings.ApplicationPath
        TxtBackupPath.Text = My.Settings.BackupPath
        TxtDataPath.Text = My.Settings.DataFilePath
        TxtDesignFilePath.Text = My.Settings.DesignFilePath
        TxtImagePath.Text = My.Settings.ImagePath
        TxtLogFilePath.Text = My.Settings.LogFolder
        CbDesignStitchDisplay.SelectedIndex = My.Settings.DesignStitchDisplay
        CbPaletteStitchDisplay.SelectedIndex = My.Settings.PaletteStitchDisplay
    End Sub
#End Region
End Class