' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.Domain.Objects

Public Class SaveStitchBuilder
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
    Public Shared Function AStitch() As SaveStitchBuilder
        Return New SaveStitchBuilder
    End Function
    Public Function StartingWithNothing() As SaveStitchBuilder
        Initialise()
        Return Me
    End Function
    Public Function StartingWith(pStitch As Stitch) As SaveStitchBuilder
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

    Public Function WithBlockLocation(pLoc As Point) As SaveStitchBuilder
        _blockPos = pLoc
        Return Me
    End Function
    Public Function WithQuarter(pQtr As BlockQuarter) As SaveStitchBuilder
        _blockQtr = pQtr
        Return Me
    End Function
    Public Function WithStitchType(pType As BlockStitchType) As SaveStitchBuilder
        _stitchType = pType
        Return Me
    End Function
    Public Function WithStrandCount(pStrands As Integer) As SaveStitchBuilder
        _strands = pStrands
        Return Me
    End Function
    Public Function WithThreadId(pThreadId As Integer) As SaveStitchBuilder
        _threadId = pThreadId
        Return Me
    End Function
    Public Function WithProjectId(pProjectId As Integer) As SaveStitchBuilder
        _projectId = pProjectId
        Return Me
    End Function
    Public Function Build() As Stitch
        Return New Stitch(_blockPos, _stitchType, _blockQtr, _strands, _threadId, _projectId)
    End Function

End Class
