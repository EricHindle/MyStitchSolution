' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports Newtonsoft.Json

Public Class SaveProjectDesign
    Private _projectId As Integer
    Private _blockStitches As List(Of SaveBlockstitch)
    Private _backStitches As List(Of SaveBackstitch)
    Private _knots As List(Of SaveKnot)
    Private _rows As Integer
    Private _columns As Integer
    Public Property Columns() As Integer
        Get
            Return _columns
        End Get
        Set(ByVal value As Integer)
            _columns = value
        End Set
    End Property
    Public Property Rows() As Integer
        Get
            Return _rows
        End Get
        Set(ByVal value As Integer)
            _rows = value
        End Set
    End Property
    Public Property Knots() As List(Of SaveKnot)
        Get
            Return _knots
        End Get
        Set(ByVal value As List(Of SaveKnot))
            _knots = value
        End Set
    End Property
    Public Property BackStitches() As List(Of SaveBackstitch)
        Get
            Return _backStitches
        End Get
        Set(ByVal value As List(Of SaveBackstitch))
            _backStitches = value
        End Set
    End Property
    Public Property BlockStitches() As List(Of SaveBlockstitch)
        Get
            Return _blockStitches
        End Get
        Set(ByVal value As List(Of SaveBlockstitch))
            _blockStitches = value
        End Set
    End Property
    Public Property ProjectId() As Integer
        Get
            Return _projectId
        End Get
        Set(ByVal value As Integer)
            _projectId = value
        End Set
    End Property
    Public Sub New()
        _projectId = -1
        _blockStitches = New List(Of SaveBlockstitch)
        _backStitches = New List(Of SaveBackstitch)
        _knots = New List(Of SaveKnot)
        _rows = 0
        _columns = 0
    End Sub
    Public Sub New(pProjectId As Integer, pBlockStitches As List(Of SaveBlockstitch), pBackStitches As List(Of SaveBackstitch), pKnots As List(Of SaveKnot), pRows As Integer, pColumns As Integer)
        _projectId = pProjectId
        _blockStitches = pBlockStitches
        _backStitches = pBackStitches
        _knots = pKnots
        _rows = pRows
        _columns = pColumns
    End Sub
    Public Function SerializeJson() As String
        Return JsonConvert.SerializeObject(Me)
    End Function
    Public Function ToSaveString() As String
        Dim _sb As New StringBuilder
        _sb _
        .Append("Design^") _
        .Append(CStr(_projectId)).Append("^") _
        .Append("Blockstitch^")
        For Each _bls As SaveBlockstitch In _blockStitches
            _sb.Append(_bls.ToSaveString).Append("|")
        Next
        _sb.Append("^") _
        .Append("Backstitch^")
        For Each _bas As SaveBackstitch In _backStitches
            _sb.Append(_bas.ToSaveString).Append("|")
        Next
        _sb.Append("^") _
        .Append("Knot^")
        For Each _knot As SaveKnot In _knots
            _sb.Append(_knot.ToSaveString).Append("|")
        Next
        _sb.Append("^")
        _sb.Append(_rows).Append("^")
        _sb.Append(_columns).Append("^")
        Return _sb.ToString
    End Function
End Class
