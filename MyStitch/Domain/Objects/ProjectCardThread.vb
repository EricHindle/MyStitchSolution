' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects
    Public Class ProjectCardThread
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
        Private Sub Initialise()
            _project = New Project
            _thread = New Thread
            _cardNo = -1
            _cardSeq = -1
        End Sub
        Public Sub New()
            Initialise()
        End Sub
        Public Sub New(pProjectId As Integer,
                 pThreadId As Integer, pCardNo As Integer, pCardSeq As Integer)
            _project = GetProjectById(pProjectId)
            _thread = GetThreadById(pThreadId)
            _cardNo = pCardNo
            _cardSeq = pCardSeq
            '       LogUtil.Info(Me.ToString, "ProjectCardThread")
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _project IsNot Nothing AndAlso _project.ProjectId > -1
        End Function
        Public Function Key() As String
            Return CStr(_project.ProjectId) & ":" & CStr(_cardNo) & ":" & CStr(_thread.ThreadId)
        End Function
        Public Overrides Function ToString() As String
            Dim _sb As New StringBuilder
            _sb.Append("Project Card Thread=[") _
                .Append("ProjectId=[").Append(CStr(_project.ProjectId)).Append("], ") _
                .Append("CardNo=[").Append(CStr(_cardNo)).Append("], ") _
                .Append("CardSeq=[").Append(CStr(_cardSeq)).Append("], ") _
                .Append("ThreadId=[").Append(CStr(_thread.ThreadId)).Append("]]")
            Return _sb.ToString()
        End Function
#End Region
    End Class
End Namespace
