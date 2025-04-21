' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class ProjectThread
#Region "properties"
    Private _project As Project
    Private _thread As Thread
    Public Property Project() As Project
        Get
            Return _project
        End Get
        Set(ByVal value As Project)
            _project = value
        End Set
    End Property
    Public Property Thread() As Thread
        Get
            Return _thread
        End Get
        Set(ByVal value As Thread)
            _thread = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialiseproject()
        _project = New Project
        _thread = New Thread
    End Sub
    Public Sub New()
        Initialiseproject()
    End Sub
    Public Sub New(pProjectId As Integer,
             pThreadId As Integer)
        _project = GetProjectById(pProjectId)
        _thread = GetThreadById(pThreadId)
    End Sub
#End Region
#Region "methods"
    Public Function IsLoaded() As Boolean
        Return _project IsNot Nothing AndAlso _project.ProjectId > -1
    End Function
    Public Function Key() As String
        Return CStr(_project.ProjectId) & ":" & CStr(_thread.ThreadId)
    End Function
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("ProjectThread=[") _
            .Append(_project.ToString) _
            .Append(_thread.ToString) _
            .Append("]]")
        Return sb.ToString
    End Function
#End Region

End Class
