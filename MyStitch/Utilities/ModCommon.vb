' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports HindlewareLib.Logging

Module ModCommon
    Public DesignFolderName As String = My.Settings.DesignFilePath
    Public DesignArchiveFolderName As String = Path.Combine(DesignFolderName, "Archive")
    Public ImageFolderName As String = My.Settings.ImagePath
    Public BackupFolderName As String = My.Settings.BackupPath
    Public BackupArchiveFolderName As String = Path.Combine(BackupFolderName, "Archive")
    Public LogFolderName As String = My.Settings.LogFolder
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public isUpgradedSettings As Boolean = False
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
    Public Sub InitialiseSettings()
        If My.Settings.CallUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.CallUpgrade = 1
            My.Settings.Save()
            isUpgradedSettings = True
        End If
    End Sub
    Public Sub InitialiseLogging()
        If String.IsNullOrEmpty(LogFolderName) Then
            LogFolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyStitchLogs")
        End If
        CreateFolder(LogFolderName, True)
        LogUtil.LogFolder = LogFolderName
        LogUtil.IsDebugOn = My.Settings.isDebugOn
        LogUtil.StartLogging(My.Settings.MyStitchConnectionString)
        LogUtil.LogInfo("Settings " & If(isUpgradedSettings, "", "not ") & "upgraded ", "InitialiseLogging")
    End Sub
    Public Sub CheckAppPaths()
        LogUtil.LogInfo("Checking folders", MethodBase.GetCurrentMethod.Name)
        CreateFolder(DesignFolderName)
        CreateFolder(DesignArchiveFolderName)
        CreateFolder(ImageFolderName)
        CreateFolder(BackupFolderName)
        CreateFolder(BackupArchiveFolderName)
    End Sub
    Public Sub RunHousekeeping()
        LogUtil.Info("Housekeeping started", MethodBase.GetCurrentMethod.Name)
        Dim retentionPeriod As Integer = My.Settings.FileRetentionPeriod
        LogUtil.Info("Tidying log files", MethodBase.GetCurrentMethod.Name)
        TidyLogFiles(LogFolderName, "*.*", retentionPeriod)
        LogUtil.Info("Tidying Design archive files", MethodBase.GetCurrentMethod.Name)
        TidyLogFiles(DesignArchiveFolderName, "*.*", retentionPeriod)
        LogUtil.Info("Housekeeping complete", MethodBase.GetCurrentMethod.Name)
    End Sub
    Public Sub TidyLogFiles(ByVal sFolder As String, ByVal sPattern As String, ByVal iRetain As Integer, Optional ByVal bSubfolders As Boolean = False)
        Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(sFolder)
        LogUtil.Info("Tidying files in " & sFolder & " older than " & iRetain & " days", "TidyLogFiles")
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
                            LogUtil.Info(oFileInfo.Name & " - " & iDaysOld & " days old - deleted", "TidyLogFiles")
                        Catch ex As Exception
                            LogUtil.Exception("Unable to remove " & oFileInfo.FullName, ex, "TidyLogFiles")
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            LogUtil.Exception("Problem tidying files", ex, "TidyLogFiles")
        End Try
    End Sub
    Public Sub CreateFolder(pFoldername As String)
        CreateFolder(pFoldername, False)
    End Sub
    Public Sub CreateFolder(pFoldername As String, pIsSilent As Boolean)
        If Not My.Computer.FileSystem.DirectoryExists(pFoldername) Then
            If Not pIsSilent Then LogUtil.LogInfo("Creating " & pFoldername, MethodBase.GetCurrentMethod.Name)
            Try
                My.Computer.FileSystem.CreateDirectory(pFoldername)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is IO.PathTooLongException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException)
                If Not pIsSilent Then LogUtil.DisplayException(ex, "Create Directory", MethodBase.GetCurrentMethod.Name)
            End Try
        End If
    End Sub
    Public Sub ShowLog()
        Using _logView As New FrmLogViewer
            _logView.FormPosition = My.Settings.LogViewPos
            _logView.ZoomValue = My.Settings.LogZoomValue
            _logView.IsZoomOn = My.Settings.LogZoomOn
            _logView.ShowDialog()
            My.Settings.LogViewPos = _logView.FormPosition
            My.Settings.LogZoomValue = _logView.ZoomValue
            My.Settings.LogZoomOn = _logView.IsZoomOn
            My.Settings.Save()
        End Using
    End Sub
    Public Function GetFormPos(ByRef oForm As Form, ByVal sPos As String) As Boolean
        LogUtil.Info("Getting form position for " & oForm.Name, "GetFormPos")
        Dim isOK As Boolean = True
        If sPos = "max" Then
            oForm.WindowState = FormWindowState.Maximized
        ElseIf sPos = "min" Then
            oForm.WindowState = FormWindowState.Minimized
        Else
            Dim pos As String() = sPos.Split("~")
            If pos.Length = 4 Then
                oForm.Top = CInt(pos(0))
                oForm.Left = CInt(pos(1))
                oForm.Height = CInt(pos(2))
                oForm.Width = CInt(pos(3))
            Else
                isOK = False
            End If
        End If
        Return isOK
    End Function
    Public Function SetFormPos(ByRef oForm As Form) As String
        Dim sPos As String
        If oForm.WindowState = FormWindowState.Maximized Then
            sPos = "max"
        ElseIf oForm.WindowState = FormWindowState.Minimized Then
            sPos = "min"
        Else
            sPos = oForm.Top & "~" & oForm.Left & "~" & oForm.Height & "~" & oForm.Width
        End If
        LogUtil.Debug("Generated form position: " & sPos, "SetFormPos")
        Return sPos
    End Function
    Public Sub TryCopyFile(pFullname As String, pDestination As String, pOverwrite As Boolean)
        Try
            My.Computer.FileSystem.CopyFile(pFullname, pDestination, pOverwrite)
        Catch ex As Exception When (TypeOf ex Is ArgumentException _
                        OrElse TypeOf ex Is FileNotFoundException _
                        OrElse TypeOf ex Is IOException _
                        OrElse TypeOf ex Is NotSupportedException _
                        OrElse TypeOf ex Is PathTooLongException _
                        OrElse TypeOf ex Is UnauthorizedAccessException _
                        OrElse TypeOf ex Is Security.SecurityException)
            LogUtil.DisplayException(ex, "Archive file", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
    Public Sub KeyHandler(ByRef _form As Form, ByRef e As System.Windows.Forms.KeyEventArgs)
        If e.Control Then
            ' Handle control key combinations
            Dim _hotkey As Keys = e.KeyCode
            Select Case _hotkey
                Case Keys.L
                    ' Open Log View form
                    ShowLog()
                    e.Handled = True
                Case Keys.B
                    ' Open Backup form
                    OpenBackupForm()
                    e.Handled = True
                Case Keys.O
                    ' Open Options form
                    OpenPreferencesForm()
                    e.Handled = True
                Case Keys.G
                    ' Open Global Settings form
                    OpenGlobalSettingsForm()
                    e.Handled = True
                Case Keys.H
                    ' Run housekeeping process
                    RunHousekeeping()
                    e.Handled = True
            End Select
        End If
    End Sub
    Public Sub OpenPreferencesForm()
        Using _options As New FrmOptions
            _options.ShowDialog()
        End Using
    End Sub
    Public Sub OpenBackupForm()
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
    End Sub
    Public Sub OpenGlobalSettingsForm()
        LogUtil.Info("Global Options", MethodBase.GetCurrentMethod.Name)
        Using _settings As New FrmGlobalSettings
            _settings.ShowDialog()
        End Using
    End Sub
End Module
