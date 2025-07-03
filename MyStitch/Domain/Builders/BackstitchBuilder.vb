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
    Public Overloads Function StartingWith(pBlockString As String) As BackstitchBuilder
        Dim _stitchStrings As String() = pBlockString.Split(BLOCK_DELIM)
        If _stitchStrings.Length >= 3 Then
            Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWith(_stitchStrings(0)).Build
            StartingWith(_stitch)
            Dim _Pos As String() = _stitchStrings(1).Split(POINT_DELIM)
            _toBlockLoc = New Point(_Pos(0), _Pos(1))
            _toBlockQtr = _stitchStrings(2)
        End If
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
