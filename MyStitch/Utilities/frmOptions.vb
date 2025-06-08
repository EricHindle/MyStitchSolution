' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text
Imports HindlewareLib.Logging

Public NotInheritable Class FrmOptions

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
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

        My.Settings.Save()
    End Sub

    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        LoadOptions()
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
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

    End Sub

    Private Sub BtnResetForms_Click(sender As Object, e As EventArgs) Handles BtnResetForms.Click

        My.Settings.Save()
    End Sub

    Private Sub BtnGlobalSettings_Click(sender As Object, e As EventArgs) Handles BtnGlobalSettings.Click
        Hide()

        Using _settings As New FrmGlobalSettings
            _settings.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub FrmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub

    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
    End Sub

    Private Sub BtnHousekeeping_Click(sender As Object, e As EventArgs) Handles BtnHousekeeping.Click
        Dim logFolder As String = My.Settings.LogFolder
        Dim retentionPeriod As Integer = My.Settings.FileRetentionPeriod
        TidyFiles(logFolder, "*.*", retentionPeriod)
        MsgBox("Tidy complete", MsgBoxStyle.Information, "Housekeeping")
    End Sub
    Public Sub TidyFiles(ByVal sFolder As String, ByVal sPattern As String, ByVal iRetain As Integer, Optional ByVal bSubfolders As Boolean = False)
        Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(sFolder)
        LogUtil.Info("Tidying files in " & sFolder & " older than " & iRetain & " days", "TidyFiles")
        Try
            Dim oFileList As FileInfo() = oDirInfo.GetFiles(sPattern, If(bSubfolders, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly))
            For Each oFileInfo As FileInfo In oFileList
                If (oFileInfo.Attributes And FileAttributes.ReadOnly) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.Hidden) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.System) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.Directory) = 0 Then
                    Dim oDate As Date = oFileInfo.LastWriteTime
                    Dim iDaysOld As Integer = DateDiff("d", oDate, Now)
                    If iDaysOld >= iRetain Then
                        Try
                            My.Computer.FileSystem.DeleteFile(oFileInfo.FullName)
                            LogUtil.Info(oFileInfo.Name & " - " & iDaysOld & " days old - deleted", "TidyFiles")
                        Catch ex As Exception
                            LogUtil.Exception("Unable to remove " & oFileInfo.FullName, ex, "TidyFiles")
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            LogUtil.Exception("Problem tidying files", ex, "TidyFiles")
        End Try
    End Sub
End Class