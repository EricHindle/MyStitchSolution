' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports System.Text
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports Newtonsoft.Json

Module ModFileHandling
    'Public Const JSON_EXT As String = ".json"
    'Public Const XML_EXT As String = ".xml"
    Public Const ZIP_EXT As String = ".zip"
    Public Const HSZ_EXT As String = ".hsz"
    Public Const ARC_EXT As String = ".hsa"
    Public Const DEL_EXT As String = ".hsd"
    Public Const DESIGN_DELIM As String = "^"
    Public Const LIST_DELIM As String = "|"
    Public Const BLOCK_DELIM As String = "~"
    Public Const STITCH_DELIM As String = "]"
    Public Const POINT_DELIM As String = "/"
    Public Const DESIGN_HDR As String = "Design:"
    Public Function OpenDesignFile(pDesignPathName As String, pDesignFileName As String) As String
        Dim _exceptionText As String = "Exception reading project design file"
        Dim _zipFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & HSZ_EXT)
        Dim _designText As String = String.Empty

        Try
            If My.Computer.FileSystem.FileExists(_zipFile) Then
                Using _archiveFile As ZipArchive = ZipFile.OpenRead(_zipFile)
                    For Each _entry As ZipArchiveEntry In _archiveFile.Entries
                        If _entry.Name.EndsWith(DEL_EXT) Then
                            Using _input As New StreamReader(_entry.Open())
                                _designText = _input.ReadLine()

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
        Return _designText
    End Function
    Public Function SaveDesignDelimited(pDesign As ProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
        Dim _pathname As String = pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        Dim _entryName As String = pDesignFileName & DEL_EXT
        Dim _designFile As String = Path.Combine(_pathname, _entryName)
        Dim _zipFile As String = Path.Combine(_pathname, pDesignFileName & HSZ_EXT)

        If Not My.Computer.FileSystem.FileExists(_zipFile) Then
            Using _fs As New FileStream(_zipFile, FileMode.Create)
            End Using
        End If
        Using zipToOpen As New FileStream(_zipFile, FileMode.Open)
            Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                Dim designEntry As ZipArchiveEntry = archive.CreateEntry(_entryName)
                Using _output As New StreamWriter(designEntry.Open())
                    _output.WriteLine(pDesign.ToSaveString)
                    _output.Close()
                End Using
            End Using
        End Using
        Return isOK
    End Function
    'Public Function SaveDesignXML(pDesign As SaveProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
    '    Dim isOK As Boolean
    '    Dim _pathname As String = pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
    '    Dim _entryName As String = pDesignFileName & XML_EXT
    '    Dim _designFile As String = Path.Combine(_pathname, _entryName)
    '    Dim _zipFile As String = Path.Combine(_pathname, pDesignFileName & ZIP_EXT)
    '    Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(SaveProjectDesign))
    '    If Not My.Computer.FileSystem.FileExists(_zipFile) Then
    '        Using _fs As New FileStream(_zipFile, FileMode.Create)
    '        End Using
    '    End If
    '    Using zipToOpen As New FileStream(_zipFile, FileMode.Open)
    '        Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
    '            Dim designEntry As ZipArchiveEntry = archive.CreateEntry(_entryName)
    '            Using _output As New StreamWriter(designEntry.Open())
    '                writer.Serialize(_output, pDesign)
    '            End Using
    '        End Using
    '    End Using
    '    Return isOK
    'End Function
    'Public Function SaveDesignJson(pDesign As SaveProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
    '    Dim isOK As Boolean
    '    pDesign = SortStitches(pDesign)
    '    Dim _pathname As String = pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
    '    Dim _entryName As String = pDesignFileName & JSON_EXT
    '    Dim _designFile As String = Path.Combine(_pathname, _entryName)
    '    Dim _zipFile As String = Path.Combine(_pathname, pDesignFileName & ZIP_EXT)
    '    Using _fs As New FileStream(_zipFile, FileMode.Create)
    '    End Using
    '    Using zipToOpen As New FileStream(_zipFile, FileMode.Create)
    '        Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
    '            Dim designEntry As ZipArchiveEntry = archive.CreateEntry(_entryName)
    '            Using _output As New StreamWriter(designEntry.Open())
    '                _output.WriteLine(pDesign.SerializeJson)
    '            End Using
    '        End Using
    '    End Using
    '    Return isOK
    'End Function
    Public Function SortStitches(pDesign As ProjectDesign) As ProjectDesign
        pDesign.BlockStitches.Sort(Function(pStitch1 As BlockStitch, pStitch2 As BlockStitch)
                                       Dim Pos1 As Integer = pStitch1.BlockPosition.Y + (pStitch1.BlockPosition.X * pDesign.Rows)
                                       Dim Pos2 As Integer = pStitch2.BlockPosition.Y + (pStitch2.BlockPosition.X * pDesign.Rows)
                                       Return Pos1.CompareTo(Pos2)
                                   End Function)
        pDesign.Knots.Sort(Function(pStitch1 As Knot, pStitch2 As Knot)
                               Dim Pos1 As Integer = pStitch1.BlockPosition.Y + (pStitch1.BlockPosition.X * pDesign.Rows)
                               Dim Pos2 As Integer = pStitch2.BlockPosition.Y + (pStitch2.BlockPosition.X * pDesign.Rows)
                               Return Pos1.CompareTo(Pos2)
                           End Function)
        pDesign.BackStitches.Sort(Function(pStitch1 As BackStitch, pStitch2 As BackStitch)
                                      Dim Pos1 As Integer = pStitch1.FromBlockLocation.Y + (pStitch1.FromBlockLocation.X * pDesign.Rows)
                                      Dim Pos2 As Integer = pStitch2.FromBlockLocation.Y + (pStitch2.FromBlockLocation.X * pDesign.Rows)
                                      Return Pos1.CompareTo(Pos2)
                                  End Function)
        Return pDesign
    End Function

End Module
