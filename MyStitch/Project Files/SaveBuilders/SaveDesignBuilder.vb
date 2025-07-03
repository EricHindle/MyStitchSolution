' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class SaveDesignBuilder
    Private _projectId As Integer
    Private _blockStitches As List(Of SaveBlockstitch)
    Private _backStitches As List(Of SaveBackstitch)
    Private _knots As List(Of SaveKnot)
    Private _rows As Integer
    Private _columns As Integer
    Public Shared Function ASaveDesign() As SaveDesignBuilder
        Return New SaveDesignBuilder
    End Function
    Public Function StartingWithNothing() As SaveDesignBuilder
        _projectId = -1
        _blockStitches = New List(Of SaveBlockstitch)
        _backStitches = New List(Of SaveBackstitch)
        _knots = New List(Of SaveKnot)
        _rows = 0
        _columns = 0
        Return Me
    End Function
    Public Function StartingWith(pProjectDesign As ProjectDesign) As SaveDesignBuilder
        _projectId = pProjectDesign.ProjectId
        _blockStitches = New List(Of SaveBlockstitch)
        For Each _blockstitch In pProjectDesign.BlockStitches
            _blockStitches.Add(SaveBlockstitchbuilder.aSaveBlockstitch.startingWith(_blockstitch).build)
        Next
        _backStitches = New List(Of SaveBackstitch)
        For Each _backstitch In pProjectDesign.BackStitches
            _backStitches.Add(SaveBackstitchBuilder.ASaveBackStitch.StartingWith(_backstitch).Build)
        Next
        _knots = New List(Of SaveKnot)
        For Each _knot In pProjectDesign.Knots
            _knots.Add(SaveKnotBuilder.ASaveKnot.StartingWith(_knot).Build)
        Next
        _rows = pProjectDesign.Rows
        _columns = pProjectDesign.Columns
        Return Me
    End Function
    Public Function WithBlockStitches(pBlockstitches As List(Of SaveBlockstitch)) As SaveDesignBuilder
        _blockStitches = pBlockstitches
        Return Me
    End Function
    Public Function WithBackStitches(pBackstitches As List(Of SaveBackstitch)) As SaveDesignBuilder
        _backStitches = pBackstitches
        Return Me
    End Function
    Public Function WithKnots(pKnots As List(Of SaveKnot)) As SaveDesignBuilder
        _knots = pKnots
        Return Me
    End Function
    Public Function WithProjectId(pProjectId As Integer) As SaveDesignBuilder
        _projectId = pProjectId
        Return Me
    End Function
    Public Function WithRows(pRows As Integer) As SaveDesignBuilder
        _rows = pRows
        Return Me
    End Function
    Public Function WithColumns(pColumns As Integer) As SaveDesignBuilder
        _columns = pColumns
        Return Me
    End Function

    Public Function Build() As SaveProjectDesign
        Return New SaveProjectDesign(_projectId, _blockStitches, _backStitches, _knots, _rows, _columns)
    End Function

End Class
