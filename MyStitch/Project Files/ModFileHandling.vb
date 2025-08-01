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
    Public Const ZIP_EXT As String = ".hsz"
    Public Const ARC_EXT As String = ".hsa"
    Public Const DESIGN_EXT As String = ".hsd"
    Public Const PROJECT_EXT As String = ".hsp"
    Public Const DESIGN_DELIM As String = "^"
    Public Const LIST_DELIM As String = "|"
    Public Const BLOCK_DELIM As String = "~"
    Public Const STITCH_DELIM As String = "]"
    Public Const POINT_DELIM As String = "/"
    Public Const DESIGN_HDR As String = "Design:"
    Public Const PROJECT_HDR As String = "Project:"
    Public Function MakeFilename(pProject As Project) As String
        Dim _filename As String = pProject.DesignFileName
        If String.IsNullOrEmpty(_filename) Then
            _filename = CStr(pProject.ProjectId) & "_" & Replace(pProject.ProjectName, " ", "_").ToLower
        End If
        Return _filename
    End Function
    Public Function MakeFullFileName(pProject As Project, pFileType As String) As String
        Dim _baseFilename As String = MakeFilename(pProject) & pFileType
        Dim _designFilePath As String = My.Settings.DesignFilePath.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        Dim _fullFilename As String = Path.Combine(_designFilePath, _baseFilename)
        Return _fullFilename
    End Function
    Public Function OpenDesignFile(pDesignPathName As String, pDesignFileName As String) As List(Of String)
        Return OpenDesignFile(Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName))
    End Function
    Public Function OpenDesignFile(pDesignFullName As String) As List(Of String)
        Dim _projectText As New List(Of String)
        Dim _exceptionText As String = "Exception reading project design file"
        Dim _zipFile As String = pDesignFullName
        Try
            If My.Computer.FileSystem.FileExists(_zipFile) Then
                Using _archiveFile As ZipArchive = ZipFile.OpenRead(_zipFile)
                    For Each _entry As ZipArchiveEntry In _archiveFile.Entries
                        If _entry.Name.EndsWith(DESIGN_EXT) Then
                            Using _input As New StreamReader(_entry.Open())
                                _projectText.Add(_input.ReadLine())
                            End Using
                        End If
                        If _entry.Name.EndsWith(PROJECT_EXT) Then
                            Using _input As New StreamReader(_entry.Open())
                                _projectText.Add(_input.ReadLine())
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
        Return _projectText
    End Function
    Public Function SaveDesignDelimited(pProject As Project, pDesign As ProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
        Dim _pathname As String = pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        Dim _designEntryName As String = pDesignFileName & DESIGN_EXT
        Dim _designFile As String = Path.Combine(_pathname, _designEntryName)
        Dim _projectEntryName As String = pDesignFileName & PROJECT_EXT
        Dim _projectFile As String = Path.Combine(_pathname, _projectEntryName)
        Dim _zipFile As String = Path.Combine(_pathname, pDesignFileName & ZIP_EXT)

        If Not My.Computer.FileSystem.FileExists(_zipFile) Then
            LogUtil.LogInfo("Creating new zip file " & _zipFile, MethodBase.GetCurrentMethod.Name)
            Using _fs As New FileStream(_zipFile, FileMode.Create)
            End Using
        End If
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
            End Using
        End Using
        Return isOK
    End Function
    Public Function ArchiveExistingFile(pFilename As String) As Boolean
        Dim isMovedOK As Boolean = True
        Dim _pathname As String = My.Settings.DesignFilePath.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        Dim _archivePathname As String = Path.Combine(_pathname, "archive")
        Dim _existingFilename As String = Path.Combine(_pathname, pFilename & ZIP_EXT)
        If My.Computer.FileSystem.FileExists(_existingFilename) Then
            LogUtil.LogInfo("Archiving design before save", MethodBase.GetCurrentMethod.Name)
            Dim _destinationFilename As String = Path.Combine(_archivePathname, pFilename & "_" & Format(Now, "yyyyMMdd_HHmmss") & ARC_EXT)
            isMovedOK = TryMoveFile(_existingFilename, _destinationFilename, True)
        End If
        Return isMovedOK
    End Function


End Module
