' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class BlockStitchBuilder
    Private _blockLoc As Point
    Private _quarters As List(Of BlockStitchQuarter)
    Public Shared Function ABlockStitch() As BlockStitchBuilder
        Return New BlockStitchBuilder
    End Function
    Public Function StartingWithNothing() As BlockStitchBuilder
        _blockLoc = New Point(0, 0)
        _quarters = New List(Of BlockStitchQuarter)
        Return Me
    End Function
    Public Function StartingWith(pBs As BlockStitch) As BlockStitchBuilder
        With pBs
            _blockLoc = .BlockLocation
            _quarters = .Quarters
        End With
        Return Me
    End Function
    Public Function WithLocation(pLoc As Point) As BlockStitchBuilder
        _blockLoc = pLoc
        Return Me
    End Function
    Public Function WithQuarters(pQtrs As List(Of BlockStitchQuarter)) As BlockStitchBuilder
        _quarters = pQtrs
        Return Me
    End Function
    Public Function Build() As BlockStitch
        Return New BlockStitch(_blockLoc, _quarters)
    End Function
End Class
