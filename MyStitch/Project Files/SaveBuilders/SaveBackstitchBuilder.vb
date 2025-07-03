' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class SaveBackstitchBuilder
    Inherits StitchBuilder
    Private _toBlockLoc As Point
    Private _toBlockQtr As BlockQuarter

    Public Shared Function ASaveBackStitch() As SaveBackstitchBuilder
        Return New SaveBackstitchBuilder
    End Function
    Public Overloads Function StartingWithNothing() As SaveBackstitchBuilder
        Initialise()
        _toBlockLoc = New Point(0, 0)
        _toBlockQtr = BlockQuarter.TopRight
        Return Me
    End Function
    Public Overloads Function StartingWith(pBackStitch As BackStitch) As SaveBackstitchBuilder
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

    Public Function WithFromBlockLocation(pLoc As Point) As SaveBackstitchBuilder
        _blockPos = pLoc
        Return Me
    End Function
    Public Function WithToBlockLocation(pLoc As Point) As SaveBackstitchBuilder
        _toBlockLoc = pLoc
        Return Me
    End Function
    Public Function WithFromQuarter(pQtr As BlockQuarter) As SaveBackstitchBuilder
        _blockQtr = pQtr
        Return Me
    End Function
    Public Function WithToQuarter(pQtr As BlockQuarter) As SaveBackstitchBuilder
        _toBlockQtr = pQtr
        Return Me
    End Function

    Public Overloads Function Build() As SaveBackstitch
        Return New SaveBackstitch(_blockPos, _blockQtr, _toBlockLoc, _toBlockQtr, _strands, _threadId, _projectId)
    End Function

End Class
