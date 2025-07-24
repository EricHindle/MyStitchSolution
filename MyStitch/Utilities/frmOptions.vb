' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports HindlewareLib.Logging

Public NotInheritable Class FrmOptions
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
    Private Sub SaveOptions()
        My.Settings.ImagePath = TxtImagePath.Text
        My.Settings.DesignFilePath = TxtDesignFilePath.Text
        My.Settings.BackupPath = TxtBackupPath.Text
        My.Settings.LogFolder = TxtLogFilePath.Text
        My.Settings.FileRetentionPeriod = NudRetention.Value
        My.Settings.isGridOn = ChkGridOn.Checked
        My.Settings.LogZoomOn = ChkLogZoom.Checked
        My.Settings.DebugOn = ChkDebugOn.Checked
        My.Settings.BackupDb = ChkBackupDb.Checked
        My.Settings.AppendDbBackup = ChkAppendDbBackup.Checked
        My.Settings.BackupArchive = ChkBackupArchive.Checked
        My.Settings.BackupAddDate = ChkBackupAddDate.Checked
        My.Settings.BackupRevision = ChkBackupRevision.Checked
        My.Settings.IsCentreOn = ChkCentreOn.Checked
        My.Settings.CentrelineColour = PicCentreColour.BackColor
        My.Settings.CentrelineThickness = NudCentreThick.Value
        My.Settings.isTimerAutoStart = ChkTimerAutoStart.Checked
        My.Settings.isTimerAutoSave = ChkTimerAutoSave.Checked
        My.Settings.isShowStockLevels = ChkShowStock.Checked
        My.Settings.LogZoomValue = NudZoomValue.Value
        My.Settings.isAutoArchiveOnSave = ChkArchiveOnSave.Checked
        My.Settings.isAutoRunHousekeeping = ChkAutoRunHousekeeping.Checked
        My.Settings.Save()
        LogUtil.Info("Options saved", MyBase.Name)
    End Sub

    Private Sub LoadOptions()
        TxtLogFilePath.Text = My.Settings.LogFolder
        TxtBackupPath.Text = My.Settings.BackupPath
        TxtImagePath.Text = My.Settings.ImagePath
        TxtDesignFilePath.Text = My.Settings.DesignFilePath
        NudRetention.Value = My.Settings.FileRetentionPeriod
        ChkGridOn.Checked = My.Settings.isGridOn
        ChkLogZoom.Checked = My.Settings.LogZoomOn
        ChkDebugOn.Checked = My.Settings.DebugOn
        ChkBackupDb.Checked = My.Settings.BackupDb
        ChkAppendDbBackup.Checked = My.Settings.AppendDbBackup
        ChkBackupArchive.Checked = My.Settings.BackupArchive
        ChkBackupAddDate.Checked = My.Settings.BackupAddDate
        ChkBackupRevision.Checked = My.Settings.BackupRevision
        ChkCentreOn.Checked = My.Settings.IsCentreOn
        PicCentreColour.BackColor = My.Settings.CentrelineColour
        NudCentreThick.Value = My.Settings.CentrelineThickness
        ChkTimerAutoStart.Checked = My.Settings.isTimerAutoStart
        ChkTimerAutoSave.Checked = My.Settings.isTimerAutoSave
        ChkShowStock.Checked = My.Settings.isShowStockLevels
        NudZoomValue.Value = My.Settings.LogZoomValue
        ChkArchiveOnSave.Checked = My.Settings.isAutoArchiveOnSave
        ChkAutoRunHousekeeping.Checked = My.Settings.isAutoRunHousekeeping
    End Sub
    Private Sub BtnGlobalSettings_Click(sender As Object, e As EventArgs) Handles BtnGlobalSettings.Click
        Hide()
        OpenGlobalSettingsForm()
        Show()
    End Sub


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

    Private Sub PicCentreColour_Click(sender As Object, e As EventArgs) Handles PicCentreColour.Click
        LogUtil.Info("Selecting centre lines colour", MyBase.Name)
        PicCentreColour.BackColor = SelectColor(PicCentreColour.BackColor)
    End Sub
    Private Sub BtnPrintSettings_Click(sender As Object, e As EventArgs) Handles BtnPrintSettings.Click
        LogUtil.Info("Print Settings", MyBase.Name)
        Hide()
        Using _printSettings As New FrmPrintOptions
            _printSettings.ShowDialog()
        End Using
        Show()
    End Sub
End Class