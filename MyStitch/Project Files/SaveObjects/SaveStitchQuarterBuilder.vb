' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class SaveStitchQuarterBuilder
    Private _blockQuarter As BlockQuarter
    Private _strandCount As Integer
    Private _threadid As Integer
    Public Shared Function ASaveStitchQuarter() As SaveStitchQuarterBuilder
        Return New SaveStitchQuarterBuilder
    End Function
    Public Function StartingWith(pBlockStitchQuarter As BlockStitchQuarter) As SaveStitchQuarterBuilder
        _blockQuarter = pBlockStitchQuarter.BlockQuarter
        _strandCount = pBlockStitchQuarter.StrandCount
        _threadid = pBlockStitchQuarter.ThreadId
        Return Me
    End Function
    Public Function WithQuarter(pQtr As BlockQuarter) As SaveStitchQuarterBuilder
        _blockQuarter = pQtr
        Return Me
    End Function
    Public Function WithStrandCount(pStrands As Integer) As SaveStitchQuarterBuilder
        _strandCount = pStrands
        Return Me
    End Function
    Public Function WithThreadId(pThreadId As Integer) As SaveStitchQuarterBuilder
        _threadid = pThreadId
        Return Me
    End Function
    Public Function Build() As SaveStitchQuarter
        Return New SaveStitchQuarter(_blockQuarter, _strandCount, _threadid)
    End Function


End Class
