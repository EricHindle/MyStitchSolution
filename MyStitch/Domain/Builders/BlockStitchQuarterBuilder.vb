' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class BlockStitchQuarterBuilder
    Private _blockQuarter As BlockQuarter
    Private _strandCount As Integer
    Private _threadid As Integer
    Public Shared Function ABlockStitchQuarter() As BlockStitchQuarterBuilder
        Return New BlockStitchQuarterBuilder
    End Function
    Public Function StartingWithNothing() As BlockStitchQuarterBuilder
        _blockQuarter = BlockQuarter.TopRight
        _strandCount = 2
        _threadid = -1
        Return Me
    End Function
    Public Function StartingWith(pQuarterString As String) As BlockStitchQuarterBuilder
        Dim _parts As String() = pQuarterString.Split(POINT_DELIM)
        _threadid = _parts(0)
        _blockQuarter = _parts(1)
        _strandCount = _parts(2)
        Return Me
    End Function
    Public Function WithQuarter(pQtr As BlockQuarter) As BlockStitchQuarterBuilder
        _blockQuarter = pQtr
        Return Me
    End Function
    Public Function WithStrandCount(pStrands As Integer) As BlockStitchQuarterBuilder
        _strandCount = pStrands
        Return Me
    End Function
    Public Function WithThreadId(pThreadId As Integer) As BlockStitchQuarterBuilder
        _threadid = pThreadId
        Return Me
    End Function
    Public Function Build() As BlockStitchQuarter
        Return New BlockStitchQuarter(_blockQuarter, _strandCount, _threadid)
    End Function

End Class
