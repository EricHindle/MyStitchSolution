' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.IO.Compression
Imports MyStitch.Domain

Module ModFileHandling
    Public Sub SaveDesign(pProjectDesign As ProjectDesign)
        Dim oSaveDesign As SaveProjectDesign = SaveDesignBuilder.ASaveDesign.StartingWith(pProjectDesign).Build
        Dim _filename As String = MakeFilename(GetProjectById(pProjectDesign.ProjectId))
        SaveDesignJson(oSaveDesign, My.Settings.DesignFilePath, "json_" & _filename)
    End Sub
    Public Function SaveDesignXML(pDesign As SaveProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
        Dim _pathname As String = pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        Dim _entryName As String = pDesignFileName & XML_EXT
        Dim _designFile As String = Path.Combine(_pathname, _entryName)
        Dim _zipFile As String = Path.Combine(_pathname, pDesignFileName & ZIP_EXT)
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(SaveProjectDesign))
        If Not My.Computer.FileSystem.FileExists(_zipFile) Then
            Using _fs As New FileStream(_zipFile, FileMode.Create)
            End Using
        End If
        Using zipToOpen As New FileStream(_zipFile, FileMode.Open)
            Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                Dim designEntry As ZipArchiveEntry = archive.CreateEntry(_entryName)
                Using _output As New StreamWriter(designEntry.Open())
                    writer.Serialize(_output, pDesign)
                End Using
            End Using
        End Using
        Return isOK
    End Function
    Public Function SaveDesignJson(pDesign As SaveProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
        pDesign = SortStitches(pDesign)
        Dim _designFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & JSON_EXT)
        Dim _zipFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & ZIP_EXT)
        '  If Not My.Computer.FileSystem.FileExists(_zipFile) Then
        Using _fs As New FileStream(_zipFile, FileMode.Create)
        End Using
        '  End If
        Using zipToOpen As New FileStream(_zipFile, FileMode.Create)
            Using archive As New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                Dim designEntry As ZipArchiveEntry = archive.CreateEntry(pDesignFileName & JSON_EXT)
                Using _output As New StreamWriter(designEntry.Open())
                    _output.WriteLine(pDesign.SerializeJson)
                End Using
            End Using
        End Using
        Return isOK
    End Function
    Public Function SortStitches(pDesign As SaveProjectDesign) As SaveProjectDesign
        pDesign.BlockStitches.Sort(Function(pStitch1 As SaveBlockstitch, pStitch2 As SaveBlockstitch)
                                       Dim Pos1 As Integer = pStitch1.BlockPosition.Y + (pStitch1.BlockPosition.X * pDesign.Rows)
                                       Dim Pos2 As Integer = pStitch2.BlockPosition.Y + (pStitch2.BlockPosition.X * pDesign.Rows)
                                       Return Pos1.CompareTo(Pos2)
                                   End Function)
        pDesign.Knots.Sort(Function(pStitch1 As SaveKnot, pStitch2 As SaveKnot)
                               Dim Pos1 As Integer = pStitch1.BlockPosition.Y + (pStitch1.BlockPosition.X * pDesign.Rows)
                               Dim Pos2 As Integer = pStitch2.BlockPosition.Y + (pStitch2.BlockPosition.X * pDesign.Rows)
                               Return Pos1.CompareTo(Pos2)
                           End Function)
        pDesign.BackStitches.Sort(Function(pStitch1 As SaveBackstitch, pStitch2 As SaveBackstitch)
                                      Dim Pos1 As Integer = pStitch1.FromBlockLocation.Y + (pStitch1.FromBlockLocation.X * pDesign.Rows)
                                      Dim Pos2 As Integer = pStitch2.FromBlockLocation.Y + (pStitch2.FromBlockLocation.X * pDesign.Rows)
                                      Return Pos1.CompareTo(Pos2)
                                  End Function)
        Return pDesign
    End Function
End Module
