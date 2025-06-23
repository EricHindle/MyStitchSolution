' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class BackstitchBuilder
    Inherits StitchBuilder
    Private _toBlockLoc As Point
    Private _toBlockQtr As BlockQuarter

    Public Shared Function ABackStitch() As BackstitchBuilder
        Return New BackstitchBuilder
    End Function
    Public Overloads Function StartingWithNothing() As BackstitchBuilder
        Initialise()
        _toBlockLoc = New Point(0, 0)
        _toBlockQtr = BlockQuarter.TopRight
        Return Me
    End Function
    Public Overloads Function StartingWith(pBackStitch As BackStitch) As BackstitchBuilder
        With pBackStitch
            _blockPos = .FromBlockPosition
            _toBlockLoc = .ToBlockPosition
            _blockQtr = .FromBlockQuarter
            _toBlockQtr = .ToBlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
        End With
        Return Me
    End Function

    Public Function WithFromBlockLocation(pLoc As Point) As BackstitchBuilder
        _blockPos = pLoc
        Return Me
    End Function
    Public Function WithToBlockLocation(pLoc As Point) As BackstitchBuilder
        _toBlockLoc = pLoc
        Return Me
    End Function
    Public Function WithFromQuarter(pQtr As BlockQuarter) As BackstitchBuilder
        _blockQtr = pQtr
        Return Me
    End Function
    Public Function WithToQuarter(pQtr As BlockQuarter) As BackstitchBuilder
        _toBlockQtr = pQtr
        Return Me
    End Function

    Public Overloads Function Build() As BackStitch
        Return New BackStitch(_blockPos, _blockQtr, _toBlockLoc, _toBlockQtr, _strands, _threadId, _projectId)
    End Function
End Class
