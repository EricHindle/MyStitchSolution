' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ProjectDesignBuilder
    Private _projectId As Integer
    Private _blockStitches As List(Of BlockStitch)
    Private _backStitches As List(Of BackStitch)
    Private _knots As List(Of Knot)
    Private _rows As Integer
    Private _columns As Integer
    Public Shared Function AProjectDesign() As ProjectDesignBuilder
        Return New ProjectDesignBuilder
    End Function
    Public Function StartingWithNothing() As ProjectDesignBuilder
        _projectId = -1
        _blockStitches = New List(Of BlockStitch)
        _backStitches = New List(Of BackStitch)
        _knots = New List(Of Knot)
        _rows = 0
        _columns = 0
        Return Me
    End Function
    Public Function StartingWith(pPath As String, pFilename As String) As ProjectDesignBuilder
        StartingWith(OpenDesignJSON(pPath, pFilename))
        Return Me
    End Function
    Public Function StartingWith(pDesign As ProjectDesign) As ProjectDesignBuilder
        With pDesign
            _projectId = .ProjectId
            _blockStitches = .BlockStitches
            _backStitches = .BackStitches
            _knots = .Knots
            _rows = .Rows
            _columns = .Columns
        End With
        Return Me
    End Function
    Public Function Build() As ProjectDesign
        Return New ProjectDesign(_projectId, _blockStitches, _backStitches, _knots, _rows, _columns)
    End Function
End Class
