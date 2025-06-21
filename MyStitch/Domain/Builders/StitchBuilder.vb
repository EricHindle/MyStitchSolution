' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.Domain.Objects

Public Class StitchBuilder
    Friend _blockLoc As Point
    Friend _blockQtr As BlockQuarter
    Friend _thread As ProjectThread
    Friend _strands As Integer
    Friend _stitchType As BlockStitchType
    Friend _threadId As Integer
    Friend _projectId As Integer

    Friend Sub Initialise()
        _blockLoc = New Point(0, 0)
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
            _blockLoc = .BlockLocation
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
            _stitchType = .StitchType
        End With
        Return Me
    End Function

    Public Function WithBlockLocation(pLoc As Point) As StitchBuilder
        _blockLoc = pLoc
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
        Return New Stitch(_blockLoc, _blockQtr, _strands, _threadId, _projectId)
    End Function

End Class
