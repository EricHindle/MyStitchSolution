' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Objects

Module ModFileHandling
    Public Enum AddDateTime
        AddNone
        AddDate
        AddDateAndTime
    End Enum
    Public Const DESIGN_ARC_EXT As String = ".hsa"
    Public Const DESIGN_ZIP_EXT As String = ".hsz"
    Public Const DESIGN_EXT As String = ".hsd"
    Public Const PROJECT_EXT As String = ".hsp"
    Public Const PROJECT_THREADS_EXT As String = ".hst"
    Public Const DATA_ARC_EXT As String = ".hsg"
    Public Const DATA_ZIP_EXT As String = ".hsf"
    Public Const DATA_EXT As String = ".hsx"
    Public Const DESIGN_DELIM As String = "^"
    Public Const LIST_DELIM As String = "|"
    Public Const BLOCK_DELIM As String = "~"
    Public Const STITCH_DELIM As String = "]"
    Public Const POINT_DELIM As String = "/"
    Public Const DESIGN_HDR As String = "Design:"
    Public Const PROJECT_HDR As String = "Project:"
    Public Const PROJECT_THREADS_HDR As String = "Project Threads:"
    Public Const PROJECT_BEADS_HDR As String = "Project Beads:"
    Public Sub CheckAppPaths()
        LogUtil.LogInfo("Checking folders", MethodBase.GetCurrentMethod.Name)
        Try
            CreateFolder(oDataFolderName, True)
            CreateFolder(oDesignFolderName, True)
            CreateFolder(oDesignArchiveFolderName, True)
            CreateFolder(oImageFolderName, True)
            CreateFolder(oBackupFolderName, True)
            CreateFolder(oBackupArchiveFolderName, True)
            CreateFolder(oDataArchiveFolderName, True)
            CreateFolder(oDailyArchivePath, True)
        Catch ex As ApplicationException
            Throw ex
        End Try
    End Sub
    Public Sub RunHousekeeping()
        LogUtil.Info("Housekeeping started", MethodBase.GetCurrentMethod.Name)
        Dim retentionPeriod As Integer = My.Settings.FileRetentionPeriod
        If My.Settings.isHousekeepLogs Then
            LogUtil.Info("Tidying log files", MethodBase.GetCurrentMethod.Name)
            TidyFiles(oLogFolderName, "*.log")
        End If
        If My.Settings.isHousekeepDesigns Then
            LogUtil.Info("Tidying Design files", MethodBase.GetCurrentMethod.Name)
            TidyFiles(oDesignArchiveFolderName, "*" & DESIGN_ARC_EXT)
        End If
        If My.Settings.isHousekeepData Then
            LogUtil.Info("Tidying Data files", MethodBase.GetCurrentMethod.Name)
            TidyFiles(oDataArchiveFolderName, "*" & DATA_ARC_EXT)
        End If
        LogUtil.Info("Housekeeping complete", MethodBase.GetCurrentMethod.Name)
    End Sub
    Public Sub TidyFiles(ByVal sFolder As String, ByVal sPattern As String)
        TidyFiles(sFolder, sPattern, False)
    End Sub
    Public Sub TidyFiles(ByVal sFolder As String, ByVal sPattern As String, ByVal bSubfolders As Boolean)
        If My.Computer.FileSystem.DirectoryExists(sFolder) Then
            Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(sFolder)
            Dim iRetentionPeriod As Integer = My.Settings.FileRetentionPeriod
            LogUtil.Info("Tidying files in " & sFolder & " older than " & iRetentionPeriod & " days", MethodBase.GetCurrentMethod.Name)
            Try
                Dim oFileInfoList As List(Of FileInfo) = oDirInfo.GetFiles(sPattern, If(bSubfolders, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly)).ToList
                Dim oFileList As New List(Of FileInfo)
                For Each oFileInfo As FileInfo In oFileInfoList
                    Dim _attributes As Integer = oFileInfo.Attributes And
                        (FileAttributes.ReadOnly _
                        Or FileAttributes.Hidden _
                        Or FileAttributes.System _
                        Or FileAttributes.Directory)
                    If _attributes = 0 Then
                        oFileList.Add(oFileInfo)
                    End If
                Next
                Dim iCopiesToKeep As Integer = Math.Min(oFileList.Count, My.Settings.FileRetentionCopies)
                oFileList.Sort(Function(x As FileInfo, y As FileInfo) x.CreationTime.CompareTo(y.CreationTime))
                If iCopiesToKeep > 0 Then
                    oFileList.RemoveRange(oFileList.Count - iCopiesToKeep, iCopiesToKeep)
                End If
                For Each oFileInfo As FileInfo In oFileList
                    Dim oDate As Date = oFileInfo.LastWriteTime
                    Dim iDaysOld As Integer = DateDiff("d", oDate, Now)
                    If iDaysOld >= iRetentionPeriod Then
                        LogUtil.Info(oFileInfo.Name & " - " & iDaysOld & " days old - deleted", MethodBase.GetCurrentMethod.Name)
                        Try
                            RemoveFile(oFileInfo.FullName)
                        Catch ex As ApplicationException
                            LogUtil.Exception("Unable to remove " & oFileInfo.FullName, ex, MethodBase.GetCurrentMethod.Name)
                        End Try
                    End If
                Next
            Catch ex As Exception
                LogUtil.Exception("Problem tidying files", ex, MethodBase.GetCurrentMethod.Name)
            End Try
        Else
            LogUtil.Problem("Folder " & sFolder & " does NOT exist. Housekeeping Failed.", MethodBase.GetCurrentMethod.Name)
        End If
    End Sub
    Public Sub CreateFolder(pFoldername As String, pAllowLogging As Boolean)
        If Not My.Computer.FileSystem.DirectoryExists(pFoldername) Then
            If pAllowLogging Then
                LogUtil.LogInfo("Creating " & pFoldername, MethodBase.GetCurrentMethod.Name)
            End If
            Try
                My.Computer.FileSystem.CreateDirectory(pFoldername)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is IO.PathTooLongException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException)
                If pAllowLogging Then
                    LogUtil.DisplayException(ex, "Create Folder", MethodBase.GetCurrentMethod.Name)
                End If
                Throw New ApplicationException("CreateDirectory Failed for " & pFoldername, ex)
            End Try
        End If
    End Sub
    Public Function MakeFilename(pProject As Project) As String
        Dim _filename As String = pProject.DesignFileName
        If String.IsNullOrEmpty(_filename) Then
            Dim _projectName As String = String.Empty
            If Not String.IsNullOrEmpty(pProject.ProjectName) Then
                _projectName = (Replace(pProject.ProjectName, " ", "_").ToLower)
            End If
            _filename = CStr(pProject.ProjectId) & "_" & _projectName
        End If
        Return _filename
    End Function
    Public Function MakeFullFileName(pProject As Project, pFileType As String) As String
        Dim _baseFilename As String = MakeFilename(pProject) & pFileType
        Dim _fullFilename As String = Path.Combine(oDesignFolderName, _baseFilename)
        Return _fullFilename
    End Function
    Public Sub TryMoveFile(pFullname As String, pDestination As String, pOverwrite As Boolean)
        ' Move a file to a new location, overwriting if necessary
        Try
            My.Computer.FileSystem.MoveFile(pFullname, pDestination, pOverwrite)
        Catch ex As Exception When (TypeOf ex Is ArgumentException _
                        OrElse TypeOf ex Is IOException _
                        OrElse TypeOf ex Is NotSupportedException _
                        OrElse TypeOf ex Is UnauthorizedAccessException _
                        OrElse TypeOf ex Is Security.SecurityException)
            LogUtil.DisplayException(ex, "Moving file", MethodBase.GetCurrentMethod.Name)
            Throw New ApplicationException("Move file failed for " & pFullname, ex)
        End Try
    End Sub
    Public Sub TryCopyFile(pFullname As String, pDestination As String, pOverwrite As Boolean)
        Try
            My.Computer.FileSystem.CopyFile(pFullname, pDestination, pOverwrite)
        Catch ex As Exception When (TypeOf ex Is ArgumentException _
                        OrElse TypeOf ex Is IOException _
                        OrElse TypeOf ex Is NotSupportedException _
                        OrElse TypeOf ex Is UnauthorizedAccessException _
                        OrElse TypeOf ex Is Security.SecurityException)
            LogUtil.DisplayException(ex, "Copying file", MethodBase.GetCurrentMethod.Name)
            Throw New ApplicationException("Copy file failed for " & pFullname, ex)
        End Try
    End Sub
    Public Function OpenDesignFile(pDesignPathName As String, pDesignFileName As String) As List(Of String)
        Return ExtractDesignStrings(Path.Combine(pDesignPathName, pDesignFileName))
    End Function
    Public Function ExtractDesignStrings(pDesignFullName As String) As List(Of String)
        Dim _projectStrings As New List(Of String)
        Dim _exceptionText As String = "Exception reading project file"
        Dim _zipFile As String = pDesignFullName
        Try
            If My.Computer.FileSystem.FileExists(_zipFile) Then
                Using _archiveFile As ZipArchive = ZipFile.OpenRead(_zipFile)
                    For Each _entry As ZipArchiveEntry In _archiveFile.Entries
                        If _entry.Name.EndsWith(DESIGN_EXT) Then
                            Using _input As New StreamReader(_entry.Open())
                                _projectStrings.Add(_input.ReadLine())
                            End Using
                        End If
                        If _entry.Name.EndsWith(PROJECT_EXT) Then
                            Using _input As New StreamReader(_entry.Open())
                                _projectStrings.Add(_input.ReadLine())
                            End Using
                        End If
                        If _entry.Name.EndsWith(PROJECT_THREADS_EXT) Then
                            Using _input As New StreamReader(_entry.Open())
                                _projectStrings.Add(_input.ReadLine())
                            End Using
                        End If
                    Next
                End Using
            End If
        Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is PathTooLongException _
                                OrElse TypeOf ex Is DirectoryNotFoundException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException _
                                OrElse TypeOf ex Is InvalidDataException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is ObjectDisposedException)
            LogUtil.DisplayException(ex, _exceptionText, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _projectStrings
    End Function
    Public Function SaveDesignDelimited(pProject As Project, pDesign As ProjectDesign, pThreads As ProjectThreadCollection, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
        Dim _designEntryName As String = pDesignFileName & DESIGN_EXT
        Dim _designFile As String = Path.Combine(oDesignFolderName, _designEntryName)
        Dim _projectEntryName As String = pDesignFileName & PROJECT_EXT
        Dim _projectFile As String = Path.Combine(oDesignFolderName, _projectEntryName)
        Dim _projectThreadsEntryName As String = pDesignFileName & PROJECT_THREADS_EXT
        Dim _projectThreadsFile As String = Path.Combine(oDesignFolderName, _projectThreadsEntryName)
        Dim _zipFile As String = Path.Combine(oDesignFolderName, pDesignFileName & DESIGN_ZIP_EXT)

        Try
            RemoveFile(_zipFile)
            Using _fs As New FileStream(_zipFile, FileMode.Create)
            End Using
        Catch ex As Exception When TypeOf ex Is ApplicationException _
                                OrElse TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is Security.SecurityException _
                                OrElse TypeOf ex Is UnauthorizedAccessException
            LogUtil.LogException(ex, "Exception initialising archive file " & _zipFile, MethodBase.GetCurrentMethod.Name)
        End Try
        LogUtil.LogInfo("Opening zip file " & _zipFile, MethodBase.GetCurrentMethod.Name)
        Using zipToOpen As New FileStream(_zipFile, FileMode.Open)
            Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                ' Save the project file
                LogUtil.LogInfo("Saving project to " & _projectEntryName, MethodBase.GetCurrentMethod.Name)
                Dim projectEntry As ZipArchiveEntry = archive.CreateEntry(_projectEntryName)
                Using _output As New StreamWriter(projectEntry.Open())
                    _output.WriteLine(pProject.ToSaveString)
                    _output.Close()
                End Using
                ' Save the design file
                LogUtil.LogInfo("Saving design to " & _designEntryName, MethodBase.GetCurrentMethod.Name)
                Dim designEntry As ZipArchiveEntry = archive.CreateEntry(_designEntryName)
                Using _output As New StreamWriter(designEntry.Open())
                    _output.WriteLine(pDesign.ToSaveString)
                    _output.Close()
                End Using
                ' Save the threads file
                If pThreads IsNot Nothing AndAlso pThreads.Count > 0 Then
                    LogUtil.LogInfo("Saving project threads to " & _projectThreadsEntryName, MethodBase.GetCurrentMethod.Name)
                    Dim threadsEntry As ZipArchiveEntry = archive.CreateEntry(_projectThreadsEntryName)
                    Using _output As New StreamWriter(threadsEntry.Open())
                        _output.WriteLine(pThreads.ToSaveString)
                        _output.Close()
                    End Using
                End If
            End Using
        End Using
        Return isOK
    End Function
    Public Function RemoveDesignFile(pProject As Project)
        Dim isOK As Boolean
        Dim _zipFile As String = Path.Combine(oDesignFolderName, pProject.DesignFileName & DESIGN_ZIP_EXT)
        Try
            RemoveFile(_zipFile)
        Catch ex As Exception When TypeOf ex Is ApplicationException
            LogUtil.LogException(ex, "Exception removing design file " & _zipFile, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOK
    End Function
    Public Sub ArchiveExistingFile(pFilename As String, pSourceFolder As String, pSourceExt As String, pTargetFolder As String, pTargetExt As String)
        ArchiveExistingFile(pFilename, pSourceFolder, pSourceExt, pTargetFolder, pTargetExt, AddDateTime.AddNone)
    End Sub
    Public Sub ArchiveExistingFile(pFilename As String, pSourceFolder As String, pSourceExt As String, pTargetFolder As String, pTargetExt As String, pAddDate As AddDateTime)
        Dim _existingFilename As String = Path.Combine(pSourceFolder, pFilename & pSourceExt)
        If My.Computer.FileSystem.FileExists(_existingFilename) Then
            LogUtil.LogInfo("Archiving data", MethodBase.GetCurrentMethod.Name)
            Dim _newFilename As String = pFilename
            If pAddDate = AddDateTime.AddDate Then
                _newFilename &= "_" & Format(Now, "yyyyMMdd")
            End If
            If pAddDate = AddDateTime.AddDateAndTime Then
                _newFilename &= "_" & Format(Now, "yyyyMMdd_HHmmss")
            End If
            Dim _destinationFilename As String = Path.Combine(pTargetFolder, _newFilename & pTargetExt)
            Try
                TryCopyFile(_existingFilename, _destinationFilename, True)
            Catch ex As ApplicationException
                Throw ex
            End Try
        End If
    End Sub
    Public Sub RemoveFile(pFileName As String)
        If My.Computer.FileSystem.FileExists(pFileName) Then
            Try
                My.Computer.FileSystem.DeleteFile(pFileName)
            Catch ex As Exception When (TypeOf ex Is ArgumentException) _
                                        OrElse (TypeOf ex Is NotSupportedException) _
                                        OrElse (TypeOf ex Is IOException) _
                                        OrElse (TypeOf ex Is Security.SecurityException) _
                                        OrElse (TypeOf ex Is UnauthorizedAccessException)
                Throw New ApplicationException("Delete file failed", ex)
            End Try
        End If
    End Sub
    Public Sub RemoveOldDailyArchives()
        LogUtil.LogInfo("Removing previous daily archives", MethodBase.GetCurrentMethod.Name)
        Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(oDailyArchivePath)
        Try
            Dim oFileList As List(Of FileInfo) = oDirInfo.GetFiles("*" & DATA_ZIP_EXT, SearchOption.TopDirectoryOnly).ToList
            For Each oFileInfo As FileInfo In oFileList
                If (oFileInfo.Attributes And FileAttributes.ReadOnly) = 0 _
                           And (oFileInfo.Attributes And FileAttributes.Hidden) = 0 _
                           And (oFileInfo.Attributes And FileAttributes.System) = 0 _
                           And (oFileInfo.Attributes And FileAttributes.Directory) = 0 Then
                    Dim oNameParts As String() = oFileInfo.FullName.Split("_")
                    If oNameParts.Count = 3 Then
                        Dim oDate As Date = Date.ParseExact(oNameParts(1), "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        If DateDiff("d", oDate, Now) > 0 Then
                            Try
                                RemoveFile(oFileInfo.FullName)
                            Catch ex As ApplicationException
                                LogUtil.Exception("Unable to remove " & oFileInfo.FullName, ex, MethodBase.GetCurrentMethod.Name)
                            End Try
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            LogUtil.Exception("Problem removing old daily archives", ex, MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
    Public Sub CopyArchiveToDailyFolder()
        LogUtil.LogInfo("Copying archive to daily folder", MethodBase.GetCurrentMethod.Name)
        ArchiveExistingFile(DATA_FILE_NAME, oDataFolderName, DATA_ZIP_EXT, oDailyArchivePath, DATA_ZIP_EXT, AddDateTime.AddDateAndTime)
    End Sub
    Public Sub CopyArchiveToArchiveFolder()
        LogUtil.LogInfo("Copying archive to archive folder", MethodBase.GetCurrentMethod.Name)
        ArchiveExistingFile(DATA_FILE_NAME, oDataFolderName, DATA_ZIP_EXT, oDataArchiveFolderName, DATA_ZIP_EXT, AddDateTime.AddDate)
    End Sub
End Module
