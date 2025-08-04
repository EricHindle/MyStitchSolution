' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Text

Namespace Domain.Objects
    Public Class ProjectThreadCollection
#Region "properties"
        Private _threads As List(Of ProjectThread)
        Public Property Threads() As List(Of ProjectThread)
            Get
                Return _threads
            End Get
            Set(ByVal value As List(Of ProjectThread))
                _threads = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub InitialiseProjectThreads()
            _threads = New List(Of ProjectThread)
        End Sub
        Public Sub New()
            InitialiseProjectThreads()
        End Sub
        Public Sub New(pThreads As List(Of ProjectThread))
            _threads = New List(Of ProjectThread)(pThreads)
        End Sub
#End Region
#Region "methods"
        Public Sub Add(pThread As ProjectThread)
            _threads.Add(pThread)
        End Sub
        Public Sub AddRange(pThreads As IEnumerable(Of ProjectThread))
            _threads.AddRange(pThreads)
        End Sub
        Public Function Count() As Integer
            Return _threads.Count
        End Function
        Public Function ToSaveString() As String
            Dim _sb As New StringBuilder
            _sb _
                .Append(PROJECT_THREADS_HDR).Append(BLOCK_DELIM)
            For Each _thread As ProjectThread In _threads
                _sb.Append(_thread.ToSaveString).Append(BLOCK_DELIM)
            Next
            Return _sb.ToString
        End Function
#End Region
    End Class
End Namespace
