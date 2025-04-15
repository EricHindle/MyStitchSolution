' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ProjectThread
#Region "properties"
    Private _project As Project
    Private _thread As Thread
    Private _cardNo As Integer
    Private _cardSeq As Integer
    Public Property CardSeq() As Integer
        Get
            Return _cardSeq
        End Get
        Set(ByVal value As Integer)
            _cardSeq = value
        End Set
    End Property
    Public Property CardNo() As Integer
        Get
            Return _cardNo
        End Get
        Set(ByVal value As Integer)
            _cardNo = value
        End Set
    End Property
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
        _cardNo = -1
        _cardSeq = -1
    End Sub
    Public Sub New()
        Initialiseproject()
    End Sub
    Public Sub New(pProjectId As Integer,
             pThreadId As Integer, pCardNo As Integer, pCardSeq As Integer)
        _project = GetProjectById(pProjectId)
        _thread = GetThreadById(pThreadId)
        _cardNo = pCardNo
        _cardSeq = pCardSeq
    End Sub
    Public Function IsLoaded() As Boolean
        Return _project IsNot Nothing AndAlso _project.ProjectId > -1
    End Function
#End Region
#Region "methods"
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("ProjectThread=[") _
            .Append(_project.ToString) _
            .Append(_thread.ToString) _
            .Append(", CardNo=[") _
            .Append(CStr(_cardNo)) _
            .Append("], CardSeq=[") _
            .Append(CStr(_cardSeq)) _
            .Append("]]")
        Return sb.ToString
    End Function
#End Region

End Class
