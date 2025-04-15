' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class Project
#Region "properties"
    Private _projectId As Integer
    Private _projectName As String
    Public Property ProjectName() As String
        Get
            Return _projectName
        End Get
        Set(ByVal value As String)
            _projectName = value
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
#End Region
#Region "constructors"
    Private Sub Initialiseproject()
        _projectId = -1
        _projectName = String.Empty
    End Sub
    Public Sub New()
        Initialiseproject()
    End Sub
    Public Sub New(pId As Integer,
             pProjectName As String)
        _projectId = pId
        _projectName = pProjectName
    End Sub
    Public Function IsLoaded() As Boolean
        Return _projectId > -1
    End Function
#End Region
#Region "methods"
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("project=[") _
            .Append("Id=[") _
            .Append(CStr(_projectId)) _
            .Append("], project name=[") _
            .Append(_projectName) _
            .Append("]]")
        Return sb.ToString
    End Function
#End Region

End Class
