' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.BlockStitch
Imports MyStitch.Domain.Objects

Public Class BackstitchBuilder
    Private _fromBlockLoc As Point
    Private _toBlockLoc As Point
    Private _fromBlockQtr As BlockQuarter
    Private _toBlockQtr As BlockQuarter
    Private _thread As Thread
    Private _strands As Integer
    Public Shared Function ABackStitch() As BackstitchBuilder
        Return New BackstitchBuilder
    End Function
    Public Function StartingWithNothing() As BackstitchBuilder
        _fromBlockLoc = New Point(0, 0)
        _toBlockLoc = New Point(0, 0)
        _fromBlockQtr = BlockQuarter.TopRight
        _toBlockQtr = BlockQuarter.TopRight
        _strands = 1
        _thread = New Thread
        Return Me
    End Function
    Public Function StartingWith(pBackStitch As BackStitch) As BackstitchBuilder
        With pBackStitch
            _fromBlockLoc = .FromBlockLocation
            _toBlockLoc = .ToBlockLocation
            _fromBlockQtr = .FromBlockQuarter
            _toBlockQtr = .ToBlockQuarter
            _strands = .Strands
            _thread = .Thread
        End With
        Return Me
    End Function

    Public Function WithFromBlockLocation(pLoc As Point) As BackstitchBuilder
        _fromBlockLoc = pLoc
        Return Me
    End Function
    Public Function WithToBlockLocation(pLoc As Point) As BackstitchBuilder
        _toBlockLoc = pLoc
        Return Me
    End Function
    Public Function WithFromQuarter(pQtr As BlockQuarter) As BackstitchBuilder
        _fromBlockQtr = pQtr
        Return Me
    End Function
    Public Function WithToQuarter(pQtr As BlockQuarter) As BackstitchBuilder
        _toBlockQtr = pQtr
        Return Me
    End Function
    Public Function WithStrandCount(pStrands As Integer) As BackstitchBuilder
        _strands = pStrands
        Return Me
    End Function
    Public Function WithThread(pThread As Thread) As BackstitchBuilder
        _thread = pThread
        Return Me
    End Function
    Public Function Build() As BackStitch
        Return New BackStitch(_fromBlockLoc, _fromBlockQtr, _toBlockLoc, _toBlockQtr, _strands, _thread)
    End Function
End Class
