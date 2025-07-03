' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Runtime.InteropServices

Public Class SaveBlockstitchBuilder
    Inherits SaveStitchBuilder
    Private _quarters As List(Of SaveStitchQuarter)
    Public Shared Function ASaveBlockStitch() As SaveBlockstitchBuilder
        Return New SaveBlockstitchBuilder
    End Function
    Public Overloads Function StartingWithNothing() As SaveBlockstitchBuilder
        Initialise()
        _quarters = New List(Of SaveStitchQuarter)
        Return Me
    End Function
    Public Overloads Function StartingWith(pStitch As Stitch) As SaveBlockstitchBuilder
        With pStitch
            _blockPos = .BlockPosition
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
            _stitchType = .StitchType
        End With
        Return Me
    End Function
    Public Overloads Function StartingWith(pBlockstitch As BlockStitch) As SaveBlockstitchBuilder
        With pBlockstitch
            _blockPos = .BlockPosition
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
            _quarters = New List(Of SaveStitchQuarter)
            For Each _qtr As BlockStitchQuarter In .Quarters
                _quarters.Add(SaveStitchQuarterBuilder.ASaveStitchQuarter.StartingWith(_qtr).Build)
            Next
            _stitchType = .StitchType
        End With
        Return Me
    End Function
    Public Function WithPosition(pPos As Point) As SaveBlockstitchBuilder
        _blockPos = pPos
        Return Me
    End Function
    Public Function WithQuarters(pQtrs As List(Of SaveStitchQuarter)) As SaveBlockstitchBuilder
        _quarters = pQtrs
        Return Me
    End Function
    Public Overloads Function Build() As SaveBlockstitch
        Return New SaveBlockstitch(_blockPos, _blockQtr, _quarters, _strands, _threadId, _stitchType, _projectId)
    End Function

End Class
