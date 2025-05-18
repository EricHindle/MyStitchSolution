' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.BlockStitch
Imports MyStitch.Domain.Objects

Public Class BlockStitchQuarterBuilder
    Private _blockQuarter As BlockQuarter
    Private _stitchType As BlockStitchType
    Private _strandCount As Integer
    Private _thread As Thread
    Public Shared Function ABlockStitchQuarter() As BlockStitchQuarterBuilder
        Return New BlockStitchQuarterBuilder
    End Function
    Public Function StartingWithNothing() As BlockStitchQuarterBuilder
        _blockQuarter = BlockQuarter.TopRight
        _stitchType = BlockStitchType.Full
        _strandCount = 2
        _thread = New Thread
        Return Me
    End Function
    Public Function WithQuarter(pQtr As BlockQuarter) As BlockStitchQuarterBuilder
        _blockQuarter = pQtr
        Return Me
    End Function
    Public Function WithStitchType(pType As BlockStitchType) As BlockStitchQuarterBuilder
        _stitchType = pType
        Return Me
    End Function
    Public Function WithStrandCount(pStrands As Integer) As BlockStitchQuarterBuilder
        _strandCount = pStrands
        Return Me
    End Function
    Public Function WithThread(pThread As Thread) As BlockStitchQuarterBuilder
        _thread = pThread
        Return Me
    End Function
    Public Function Build() As BlockStitchQuarter
        Return New BlockStitchQuarter(_blockQuarter, _stitchType, _strandCount, _thread)
    End Function

End Class
