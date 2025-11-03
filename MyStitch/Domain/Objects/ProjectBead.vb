' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects

    Public Class ProjectBead
        Inherits ProjectThread

#Region "properties"
        Private _bead As Bead

        Public Property BeadId() As Integer
            Get
                Return _threadId
            End Get
            Set(ByVal value As Integer)
                _threadId = value
            End Set
        End Property

        Public ReadOnly Property Bead() As Bead
            Get
                If _bead Is Nothing Then
                    _bead = FindBeadById(_threadId)
                End If
                Return _bead
            End Get
        End Property
        Public Overrides ReadOnly Property Thread() As Thread
            Get
                If _thread Is Nothing Then
                    _thread = FindBeadById(_threadId)
                End If
                Return _thread
            End Get
        End Property

#End Region
#Region "constructors"
        Private Sub InitialiseProjectThread()
            _bead = Nothing
            _projectId = -1
            _threadId = -1
            _isUsed = False
        End Sub
        Public Sub New()
            InitialiseProjectThread()
        End Sub
        Public Sub New(pProjectId As Integer,
                           pThreadId As Integer,
                           pIsUsed As Boolean)
            InitialiseProjectThread()
            _projectId = pProjectId
            _threadId = pThreadId
            _isUsed = pIsUsed
        End Sub
#End Region
#Region "methods"
        Public Overrides Function ToString() As String
            Dim _sb As New StringBuilder
            _sb.Append("ProjectThread=[") _
                    .Append("ProjectId=[").Append(CStr(_projectId)).Append("], ") _
                    .Append(Bead.ToString).Append(", ") _
                    .Append("Is used=[").Append(_isUsed).Append("]") _
                    .Append("]")
            Return _sb.ToString()
        End Function
#End Region

    End Class
End Namespace

