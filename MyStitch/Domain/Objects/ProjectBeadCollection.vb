' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Namespace Domain.Objects
    Public Class ProjectBeadCollection
#Region "properties"
        Private _Beads As List(Of ProjectBead)
        Public Property Beads() As List(Of ProjectBead)
            Get
                Return _Beads
            End Get
            Set(ByVal value As List(Of ProjectBead))
                _Beads = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub InitialiseProjectBeads()
            _Beads = New List(Of ProjectBead)
        End Sub
        Public Sub New()
            InitialiseProjectBeads()
        End Sub
        Public Sub New(pBeads As List(Of ProjectBead))
            _Beads = New List(Of ProjectBead)(pBeads)
        End Sub
#End Region
#Region "methods"
        Public Function Find(pBeadId As Integer) As ProjectBead
            Return _Beads.Find(Function(p) p.Bead.BeadId = pBeadId)
        End Function
        Public Function Exists(pBeadId As Integer) As Boolean
            Return _Beads.Exists(Function(p) p.Bead.BeadId = pBeadId)
        End Function
        Public Sub Remove(pBeadId As Integer)
            Dim _BeadToRemove As ProjectBead = Find(pBeadId)
            If _BeadToRemove IsNot Nothing Then
                _Beads.Remove(_BeadToRemove)
            End If
        End Sub
        Public Function IsBeadUsed(pBeadId As Integer) As Boolean
            Dim _foundBead As ProjectBead = Find(pBeadId)
            Dim _isUsed As Boolean = False
            If _foundBead IsNot Nothing Then
                _isUsed = _foundBead.IsUsed
            End If
            Return _isUsed
        End Function
        Public Sub Add(pBead As ProjectBead)
            _Beads.Add(pBead)
        End Sub
        Public Sub AddRange(pBeads As IEnumerable(Of ProjectBead))
            _Beads.AddRange(pBeads)
        End Sub
        Public Function Count() As Integer
            Return _Beads.Count
        End Function
        Public Function ToSaveString() As String
            Dim _sb As New StringBuilder
            _sb _
                .Append(PROJECT_BEADS_HDR).Append(BLOCK_DELIM)
            For Each _Bead As ProjectBead In _Beads
                _sb.Append(_Bead.ToSaveString).Append(BLOCK_DELIM)
            Next
            Return _sb.ToString
        End Function
#End Region
    End Class
End Namespace

