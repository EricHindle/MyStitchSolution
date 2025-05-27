' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.IO.Compression

Module ModDesign
    Public Const JSON_EXT As String = ".json"
    Public Const XML_EXT As String = ".xml"
    Public Const ZIP_EXT As String = ".hsz"

    Public Function SaveDesignJson(pDesign As ProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
        Dim _designFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & JSON_EXT)
        Dim _zipFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & ZIP_EXT)
        If Not My.Computer.FileSystem.FileExists(_zipFile) Then
            Using _fs As New FileStream(_zipFile, FileMode.Create)
            End Using
        End If
        Using zipToOpen As New FileStream(_zipFile, FileMode.Open)
            Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                Dim designEntry As ZipArchiveEntry = archive.CreateEntry(pDesignFileName & JSON_EXT)
                Using _output As New StreamWriter(designEntry.Open())
                    _output.WriteLine(pDesign.SerializeJson)
                End Using
            End Using
        End Using
        Return isOK
    End Function
    Public Function SaveDesignXML(pDesign As ProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
        Dim _designFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & XML_EXT)
        Dim _zipFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & ZIP_EXT)
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(ProjectDesign))
        If Not My.Computer.FileSystem.FileExists(_zipFile) Then
            Using _fs As New FileStream(_zipFile, FileMode.Create)
            End Using
        End If
        Using zipToOpen As New FileStream(_zipFile, FileMode.Open)
            Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                Dim designEntry As ZipArchiveEntry = archive.CreateEntry(pDesignFileName & XML_EXT)
                Using _output As New StreamWriter(designEntry.Open())
                    writer.Serialize(_output, pDesign)
                End Using
            End Using
        End Using

        Return isOK
    End Function

    Public Function OpenDesignXML(pDesignPathName As String, pDesignFileName As String) As ProjectDesign
        Dim _zipFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & ZIP_EXT)
        Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(ProjectDesign))
        Dim _projectDesign As New ProjectDesign
        If My.Computer.FileSystem.FileExists(_zipFile) Then
            Using _chapterFile As ZipArchive = ZipFile.OpenRead(_zipFile)
                For Each _entry As ZipArchiveEntry In _chapterFile.Entries
                    If _entry.Name.EndsWith(XML_EXT) Then
                        Using _input As New StreamReader(_entry.Open())
                            _projectDesign = CType(serializer.Deserialize(_input), ProjectDesign)
                        End Using
                    End If
                Next
            End Using
        End If
        Return _projectDesign
    End Function
End Module
