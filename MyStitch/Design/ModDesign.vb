' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.IO.Compression
Imports Newtonsoft.Json

Module ModDesign
#Region "constants"

    Public Const JSON_EXT As String = ".json"
    Public Const XML_EXT As String = ".xml"
    Public Const ZIP_EXT As String = ".hsz"
    Public Const ARC_EXT As String = ".hsa"
    Public oFabricColour As List(Of Color) = {Color.White, Color.Linen, Color.AliceBlue, Color.MistyRose}.ToList
    Public oGridColour As List(Of Color) = {Color.LightGray, Color.DarkGray, Color.DimGray, Color.Black}.ToList
#End Region
#Region "enum"
    Public Enum StitchDisplayStyle
        Crosses
        Blocks
        ColouredSymbols
        Strokes
        BlackWhiteSymbols
        BlocksWithSymbols
    End Enum
#End Region
#Region "variables"
    Friend iXOffset As Integer
    Friend iYOffset As Integer
    Friend iPpc As Integer
    Friend topcorner As New Point(0, 0)
#End Region
#Region "functions"
    Public Function FindCellFromClickLocation(e As MouseEventArgs) As Cell
        Dim pCellBuilder As CellBuilder = CellBuilder.ACell.StartingWithNothing
        Dim pos_x As Integer = Math.Floor(e.X / iPpc) - iXOffset + topcorner.X
        Dim pos_y As Integer = Math.Floor(e.Y / iPpc) - iYOffset + topcorner.Y
        Dim loc_x As Integer = (pos_x) * iPpc
        Dim loc_y As Integer = (pos_y) * iPpc

        pCellBuilder.WithPosition(New Point(pos_x, pos_y))
        pCellBuilder.WithLocation(New Point(loc_x, loc_y))

        Dim _xrmd As Integer = e.X Mod iPpc
        Dim _yrmd As Integer = e.Y Mod iPpc
        Dim _qtr As BlockQuarter
        Dim _qtrLoc As New Point(loc_x, loc_y)
        Dim _qtrPos As New Point(pos_x, pos_y)
        Select Case True
            Case (_xrmd >= 0 AndAlso _xrmd < iPpc / 2) AndAlso (_yrmd >= 0 AndAlso _yrmd < iPpc / 2)
                _qtrLoc = New Point(loc_x, loc_y)
                _qtr = BlockQuarter.TopLeft
            Case _xrmd > iPpc / 2 AndAlso _yrmd > iPpc / 2
                _qtrLoc = New Point(loc_x + (iPpc / 2), loc_y + (iPpc / 2))
                _qtr = BlockQuarter.BottomRight
            Case (_xrmd >= 0 AndAlso _xrmd < iPpc / 2) AndAlso _yrmd > iPpc / 2
                _qtrLoc = New Point(loc_x, loc_y + (iPpc / 2))
                _qtr = BlockQuarter.BottomLeft
            Case _xrmd > iPpc / 2 AndAlso (_yrmd >= 0 AndAlso _yrmd < iPpc / 2)
                _qtrLoc = New Point(loc_x + (iPpc / 2), loc_y)
                _qtr = BlockQuarter.TopRight
        End Select
        pCellBuilder.WithStitchQtr(_qtr).WithStitchQtrLoc(_qtrLoc)
        If _yrmd >= 0 And _yrmd < iPpc / 4 Then
            If _xrmd >= 0 And _xrmd < iPpc / 4 Then
                _qtr = BlockQuarter.TopLeft
            End If
            If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
                _qtr = BlockQuarter.TopRight
            End If
            If _xrmd >= iPpc * 3 / 4 Then
                _qtr = BlockQuarter.TopLeft
                _qtrPos.X += 1
            End If
        End If

        If _yrmd >= iPpc / 4 And _yrmd < iPpc * 3 / 4 Then
            If _xrmd >= 0 And _xrmd < iPpc / 4 Then
                _qtr = BlockQuarter.BottomLeft
            End If
            If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
                _qtr = BlockQuarter.BottomRight
            End If
            If _xrmd >= iPpc * 3 / 4 Then
                _qtr = BlockQuarter.BottomLeft
                _qtrPos.X += 1
            End If
        End If

        If _yrmd >= iPpc * 3 / 4 Then
            If _xrmd >= 0 And _xrmd < iPpc / 4 Then
                _qtr = BlockQuarter.TopLeft
                _qtrPos.Y += 1
            End If
            If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
                _qtr = BlockQuarter.TopRight
                _qtrPos.Y += 1
            End If
            If _xrmd >= iPpc * 3 / 4 Then
                _qtr = BlockQuarter.TopLeft
                _qtrPos.Y += 1
                _qtrPos.X += 1
            End If
        End If

        Select Case _qtr
            Case BlockQuarter.TopRight
                _qtrLoc.X += Math.Floor(iPpc / 2)
            Case BlockQuarter.BottomLeft
                _qtrLoc.Y += Math.Floor(iPpc / 2)
            Case BlockQuarter.BottomRight
                _qtrLoc.X += Math.Floor(iPpc / 2)
                _qtrLoc.Y += Math.Floor(iPpc / 2)
        End Select

        pCellBuilder.WithKnotQuarter(_qtr).WithKnotCellPos(_qtrPos).WithKnotQtrLoc(_qtrLoc)
        Return pCellBuilder.Build
    End Function
    Public Function GetColourFromProject(pProjectColour As Integer, pColours As List(Of Color)) As Color
        Dim _color As Color
        Select Case pProjectColour
            Case 1 To pColours.Count - 1
                _color = pColours(pProjectColour - 1)
            Case Else
                _color = Color.FromArgb(pProjectColour)
        End Select
        Return _color
    End Function
    Public Function SaveDesignJson(pDesign As ProjectDesign, pDesignPathName As String, pDesignFileName As String) As Boolean
        Dim isOK As Boolean
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
    Public Function OpenDesignJSON(pDesignPathName As String, pDesignFileName As String) As ProjectDesign
        Dim _zipFile As String = Path.Combine(pDesignPathName.Replace("%applicationpath%", My.Application.Info.DirectoryPath), pDesignFileName & ZIP_EXT)
        Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(ProjectDesign))
        Dim _projectDesign As New ProjectDesign
        If My.Computer.FileSystem.FileExists(_zipFile) Then
            Using _chapterFile As ZipArchive = ZipFile.OpenRead(_zipFile)
                For Each _entry As ZipArchiveEntry In _chapterFile.Entries
                    If _entry.Name.EndsWith(JSON_EXT) Then
                        Using _input As New StreamReader(_entry.Open())
                            Dim _jsonText As String = _input.ReadLine()
                            _projectDesign = JsonConvert.DeserializeObject(Of ProjectDesign)(_jsonText)
                        End Using
                    End If
                Next
            End Using
        End If
        Return _projectDesign
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

#End Region

End Module
