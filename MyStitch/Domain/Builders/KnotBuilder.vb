' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.BlockStitch
Imports MyStitch.Domain.Objects

Public Class KnotBuilder
    Private _blockLoc As Point
    Private _blockQtr As BlockQuarter
    Private _thread As Thread
    Private _strands As Integer
    Private _isBead As Boolean
    Public Shared Function AKnot() As KnotBuilder
        Return New KnotBuilder
    End Function
    Public Function StartingWithNothing() As KnotBuilder
        _blockLoc = New Point(0, 0)
        _blockQtr = BlockQuarter.TopRight
        _strands = 1
        _thread = New Thread
        Return Me
    End Function
    Public Function StartingWith(pKnot As Knot) As KnotBuilder
        With pKnot
            _blockLoc = .BlockLocation
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _thread = .Thread
            _isBead = .IsBead
        End With
        Return Me
    End Function
    Public Function WithBlockLocation(pLoc As Point) As KnotBuilder
        _blockLoc = pLoc
        Return Me
    End Function
    Public Function WithBlockQuarter(pQtr As BlockQuarter) As KnotBuilder
        _blockQtr = pQtr
        Return Me
    End Function
    Public Function WithStrandCount(pStrands As Integer) As KnotBuilder
        _strands = pStrands
        Return Me
    End Function
    Public Function WithThread(pThread As Thread) As KnotBuilder
        _thread = pThread
        Return Me
    End Function
    Public Function Build() As Knot
        Return New Knot(_blockLoc, _blockQtr, _strands, _thread, _isBead)
    End Function

End Class
