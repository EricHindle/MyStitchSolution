' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public NotInheritable Class FrmOptions
    Private _originForm As Form
    Public Property OriginForm() As Form
        Get
            Return _originForm
        End Get
        Set(ByVal value As Form)
            _originForm = value
        End Set
    End Property
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
        My.Settings.CentrelineColour = PicCentreLineColour.BackColor
        My.Settings.CentrelineWidth = NudCentreLineWidth.Value
        My.Settings.isTimerAutoStart = ChkTimerAutoStart.Checked
        My.Settings.isTimerAutoSave = ChkTimerAutoSave.Checked
        My.Settings.isShowStockLevels = ChkShowStock.Checked
        My.Settings.LogZoomValue = NudZoomValue.Value
        My.Settings.isAutoArchiveOnSave = ChkArchiveOnSave.Checked
        My.Settings.isAutoRunHousekeeping = ChkAutoRunHousekeeping.Checked
        My.Settings.Grid10Colour = If(CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1, PicGrid10Colour.BackColor.ToArgb, CbGrid10Colour.SelectedIndex + 1)
        My.Settings.Grid10Thickness = NudGrid10Thickness.Value
        My.Settings.Grid1Colour = If(CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1, PicGrid1Colour.BackColor.ToArgb, CbGrid1Colour.SelectedIndex + 1)
        My.Settings.Grid1Thickness = NudGrid1Thickness.Value
        My.Settings.Grid5Colour = If(CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1, PicGrid5Colour.BackColor.ToArgb, CbGrid5Colour.SelectedIndex + 1)
        My.Settings.Grid5Thickness = NudGrid5Thickness.Value
        My.Settings.SelectionBorderColour = PicSelectionBorderColour.BackColor
        My.Settings.ApplicationPath = TxtAppPath.Text
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
        PicCentreLineColour.BackColor = My.Settings.CentrelineColour
        NudCentreLineWidth.Value = My.Settings.CentrelineWidth
        ChkTimerAutoStart.Checked = My.Settings.isTimerAutoStart
        ChkTimerAutoSave.Checked = My.Settings.isTimerAutoSave
        ChkShowStock.Checked = My.Settings.isShowStockLevels
        NudZoomValue.Value = My.Settings.LogZoomValue
        ChkArchiveOnSave.Checked = My.Settings.isAutoArchiveOnSave
        ChkAutoRunHousekeeping.Checked = My.Settings.isAutoRunHousekeeping
        SetLineColour(PicGrid10Colour, CbGrid10Colour, My.Settings.Grid10Colour)
        SetLineColour(PicGrid1Colour, CbGrid1Colour, My.Settings.Grid1Colour)
        SetLineColour(PicGrid5Colour, CbGrid5Colour, My.Settings.Grid5Colour)
        NudGrid10Thickness.Value = My.Settings.Grid10Thickness
        NudGrid1Thickness.Value = My.Settings.Grid1Thickness
        NudGrid5Thickness.Value = My.Settings.Grid5Thickness
        PicSelectionBorderColour.BackColor = My.Settings.SelectionBorderColour
        TxtAppPath.Text = My.Settings.ApplicationPath
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
    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles PicCentreLineColour.Click, PicSelectionBorderColour.Click
        LogUtil.Info("Selecting centre lines colour", MyBase.Name)
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
        pic.BackColor = SelectColor(pic.BackColor)
        Select Case pic.Name
            Case "PicGrid1Colour"
                CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1
            Case "PicGrid5Colour"
                CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1
            Case "PicGrid10Colour"
                CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1
        End Select
    End Sub
    Private Sub CbColour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid1Colour.SelectedIndexChanged,
                                                                        CbGrid5Colour.SelectedIndexChanged,
                                                                        CbGrid10Colour.SelectedIndexChanged
        Dim comboBox As ComboBox = CType(sender, ComboBox)
        Select Case comboBox.SelectedIndex
            Case 0 To comboBox.Items.Count - 2
                Dim pic As PictureBox
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

End Class