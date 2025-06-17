' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports HindlewareLib.Logging
Imports Newtonsoft.Json

Public Class ProjectDesign
    Private _projectId As Integer
    Private _blockStitches As List(Of BlockStitch)
    Private _backStitches As List(Of BackStitch)
    Private _knots As List(Of Knot)
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
    Public Property Knots() As List(Of Knot)
        Get
            Return _knots
        End Get
        Set(ByVal value As List(Of Knot))
            _knots = value
        End Set
    End Property
    Public Property BackStitches() As List(Of BackStitch)
        Get
            Return _backStitches
        End Get
        Set(ByVal value As List(Of BackStitch))
            _backStitches = value
        End Set
    End Property
    Public Property BlockStitches() As List(Of BlockStitch)
        Get
            Return _blockStitches
        End Get
        Set(ByVal value As List(Of BlockStitch))
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
        _blockStitches = New List(Of BlockStitch)
        _backStitches = New List(Of BackStitch)
        _knots = New List(Of Knot)
        _rows = 0
        _columns = 0
    End Sub
    Public Sub New(pProjectId As Integer, pBlockStitches As List(Of BlockStitch), pBackStitches As List(Of BackStitch), pKnots As List(Of Knot), pRows As Integer, pColumns As Integer)
        _projectId = pProjectId
        _blockStitches = pBlockStitches
        _backStitches = pBackStitches
        _knots = pKnots
        _rows = pRows
        _columns = pColumns
        '     LogUtil.Info(Me.ToString, "ProjectDesign")
    End Sub
    Public Function SerializeJson() As String
        Return JsonConvert.SerializeObject(Me)
    End Function
    Public Function IsLoaded() As Boolean
        Dim _isOk As Boolean = False
        If _rows > 0 AndAlso _columns > 0 Then
            _isOk = True
        End If
        Return _isOk
    End Function
    Public Overrides Function ToString() As String
        Dim _sb As New StringBuilder
        _sb.Append("Project Design=[") _
            .Append("ProjectId=[").Append(CStr(_projectId)).Append("], ") _
            .Append("BlockStitches=[")
        For Each _blst As BlockStitch In _blockStitches
            _sb.Append(_blst.ToString).Append(", ")
        Next
        _sb.Append("], BackStitches=[")
        For Each _bkst As BackStitch In _backStitches
            _sb.Append(_bkst.ToString).Append(", ")
        Next
        _sb.Append("], Knots =[")
        For Each _knot As Knot In _knots
            _sb.Append(_knot.ToString).Append(", ")
        Next
        _sb.Append("], ") _
              .Append("Rows=[").Append(CStr(_rows)).Append("], ") _
              .Append("Columns=[").Append(CStr(_columns)) _
              .Append("]]")
        Return _sb.ToString()
    End Function
End Class
