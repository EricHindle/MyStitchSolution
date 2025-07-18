﻿' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.Domain.Objects

Public Class StitchBuilder
    Friend _blockPos As Point
    Friend _blockQtr As BlockQuarter
    Friend _thread As ProjectThread
    Friend _strands As Integer
    Friend _stitchType As BlockStitchType
    Friend _threadId As Integer
    Friend _projectId As Integer

    Friend Sub Initialise()
        _blockPos = New Point(0, 0)
        _blockQtr = BlockQuarter.TopLeft
        _strands = 1
        _threadId = -1
        _projectId = -1
        _stitchType = BlockStitchType.none
        _thread = Nothing
    End Sub
    Public Shared Function AStitch() As StitchBuilder
        Return New StitchBuilder
    End Function
    Public Function StartingWithNothing() As StitchBuilder
        Initialise()
        Return Me
    End Function
    Public Function StartingWith(pStitch As Stitch) As StitchBuilder
        With pStitch
            _blockPos = .BlockPosition
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
            _stitchType = .StitchType
        End With
        Return Me
    End Function
    Public Function StartingWith(pStitchString As String) As StitchBuilder
        Dim _parts As String() = pStitchString.Split(STITCH_DELIM)
        If _parts.Length > 0 Then
            _projectId = _parts(0)
            _threadId = _parts(1)
            Dim _Pos As String() = _parts(2).Split(POINT_DELIM)
            _blockPos = New Point(_Pos(0), _Pos(1))
            _blockQtr = _parts(3)
            _stitchType = _parts(4)
            _strands = _parts(5)
        End If
        Return Me
    End Function
    Public Function WithBlockLocation(pLoc As Point) As StitchBuilder
        _blockPos = pLoc
        Return Me
    End Function
    Public Function WithQuarter(pQtr As BlockQuarter) As StitchBuilder
        _blockQtr = pQtr
        Return Me
    End Function
    Public Function WithStitchType(pType As BlockStitchType) As StitchBuilder
        _stitchType = pType
        Return Me
    End Function
    Public Function WithStrandCount(pStrands As Integer) As StitchBuilder
        _strands = pStrands
        Return Me
    End Function
    Public Function WithThreadId(pThreadId As Integer) As StitchBuilder
        _threadId = pThreadId
        Return Me
    End Function
    Public Function WithProjectId(pProjectId As Integer) As StitchBuilder
        _projectId = pProjectId
        Return Me
    End Function
    Public Function Build() As Stitch
        Return New Stitch(_blockPos, _stitchType, _blockQtr, _strands, _threadId, _projectId)
    End Function

End Class
