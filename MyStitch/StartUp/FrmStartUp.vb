' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Environment
Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports HindlewareLib.Logging
Public NotInheritable Class FrmStartUp
#Region "variables"
    Private oInstallationLogFolder As String
#End Region
#Region "form control handlers"
    Private Sub FrmStartUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        Copyright.Text = My.Application.Info.Copyright
        InitialiseSettings()
        If My.Settings.isInstallationComplete Then
            PnlSplash.Location = New Point(1, 1)
            PnlSplash.BorderStyle = BorderStyle.None
            Size = New Drawing.Size(PnlSplash.Size.Width + 2, PnlSplash.Size.Height + 2)
            InitialiseApplication()
            Timer1.Enabled = True
        Else
            CompleteInstallation()
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            SaveFolderSettings()
            LoadPathSettings()
            CheckAppPaths()
            Dim oFromFolder As String = Path.Combine(My.Application.Info.DirectoryPath, "Data")
            Dim oToFolder As String = My.Settings.DataFilePath
            InstallDataArchive(oFromFolder, oToFolder)
            My.Settings.isInstallationComplete = True
            My.Settings.Save()
            LogUtil.LogInfo("Installation complete", MethodBase.GetCurrentMethod.Name)
            LogUtil.StopLogging()
            InitialiseApplication()
            EnterApplication()
        Catch ex As ArgumentException
            LogUtil.DisplayException(ex, "Installation Error", MyBase.Name)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, ex.ParamName & " error")
        End Try
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Close()
    End Sub
    Private Sub FrmStartUp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.isInstallationComplete Then
            LogUtil.LogInfo("Application closing", MyBase.Name)
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        EnterApplication()
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseApplication()
        LoadSettings(Me)
        LoadPathSettings()
        InitialiseLogging()
        Try
            CheckAppPaths()
        Catch ex As ApplicationException
            ShowCriticalError("A problem has occurred. Application cannot continue.", ex, MyBase.Name)
            Close()
            Exit Sub
        End Try
        If My.Settings.isAutoRunHousekeeping Then
            RunHousekeeping()
        End If
    End Sub
    Public Sub CompleteInstallation()
        oInstallationLogFolder = GetFolderPath(SpecialFolder.DesktopDirectory)
        LogUtil.LogFolder = oInstallationLogFolder
        LogUtil.StartLogging()
        LogUtil.LogInfo("Completing installation", MethodBase.GetCurrentMethod.Name)
        Dim UserDataPath As String = Path.Combine(GetFolderPath(SpecialFolder.CommonApplicationData), My.Application.Info.AssemblyName)
        '    LoadDefaultPaths
        TxtBackupPath.Text = Path.Combine(UserDataPath, "Backup")
        TxtDataPath.Text = Path.Combine(UserDataPath, "Data")
        TxtDesignFilePath.Text = Path.Combine(UserDataPath, "Designs")
        TxtImagePath.Text = Path.Combine(UserDataPath, "Images")
        TxtLogFilePath.Text = Path.Combine(UserDataPath, "Logs")
        BtnExit.Enabled = True
        btnSave.Enabled = True
    End Sub
    Private Sub InstallDataArchive(pFromFolder As String, pToFolder As String)
        LogUtil.LogInfo("Unpacking Data File", MethodBase.GetCurrentMethod.Name)
        Dim oDataFileName As String = Path.Combine(pFromFolder, DATA_FILE_NAME & DATA_ZIP_EXT)
        If My.Computer.FileSystem.FileExists(oDataFileName) = True Then
            Try
                Using _archiveFile As ZipArchive = ZipFile.OpenRead(oDataFileName)
                    For Each _entry As ZipArchiveEntry In _archiveFile.Entries
                        If _entry.Name.EndsWith(DATA_EXT) Then
                            _entry.ExtractToFile(Path.Combine(pToFolder, _entry.Name), True)
                            LogUtil.LogInfo("Installed " & _entry.Name, MethodBase.GetCurrentMethod.Name)
                        End If
                    Next
                End Using
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is PathTooLongException _
                                OrElse TypeOf ex Is DirectoryNotFoundException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException _
                                OrElse TypeOf ex Is InvalidDataException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is ObjectDisposedException)
                ShowCriticalError("A problem has occurred. Application cannot continue.", New ApplicationException("Data file not installed."), MyBase.Name)
                Throw New ApplicationException("Error unpacking MyStitch application data archive." & vbCrLf _
                                               & "Check for " & oDataFileName & " and re-install if necessary.")
            End Try
        Else
            ShowCriticalError("A problem has occurred. Application cannot continue.", New ApplicationException("Expected data archive not found."), MyBase.Name)
            Throw New ApplicationException("MyStitch application data archive file does not exist." & vbCrLf _
                                               & "Check for " & oDataFileName & " and re-install if necessary.")
        End If
    End Sub
    Private Sub EnterApplication()
        Hide()
        Using _projects As New FrmProject
            _projects.ShowDialog()
        End Using
        Close()
    End Sub
    Private Sub SaveFolderSettings()
        LogUtil.LogInfo("Saving folder settings", MethodBase.GetCurrentMethod.Name)
        If Not String.IsNullOrWhiteSpace(TxtDataPath.Text) Then
            My.Settings.DataFilePath = TxtDataPath.Text
        Else
            Throw New ArgumentException("You must provide a Data Folder name", "Data Folder")
        End If
        If Not String.IsNullOrWhiteSpace(TxtImagePath.Text) Then
            My.Settings.ImagePath = TxtImagePath.Text
        Else
            Throw New ArgumentException("You must provide an Image Folder name", "Image Folder")
        End If
        If Not String.IsNullOrWhiteSpace(TxtDesignFilePath.Text) Then
            My.Settings.DesignFilePath = TxtDesignFilePath.Text
        Else
            Throw New ArgumentException("You must provide a Design Folder name", "Design Folder")
        End If
        If Not String.IsNullOrWhiteSpace(TxtBackupPath.Text) Then
            My.Settings.BackupPath = TxtBackupPath.Text
        Else
            Throw New ArgumentException("You must provide a BackUp Folder name", "BackUp Folder")
        End If
        If Not String.IsNullOrWhiteSpace(TxtLogFilePath.Text) Then
            My.Settings.LogFolder = TxtLogFilePath.Text
        Else
            Throw New ArgumentException("You must provide a Log File Folder name", "Log File Folder")
        End If
        My.Settings.Save()
    End Sub
#End Region
End Class
