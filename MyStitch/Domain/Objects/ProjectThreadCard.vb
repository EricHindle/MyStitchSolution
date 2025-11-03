' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects
    Public Class ProjectThreadCard
#Region "properties"
        Private _project As Project
        Private _cardNo As Integer

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
#End Region
#Region "constructors"
        Private Sub Initialiseproject()
            _project = New Project
            _cardNo = -1
        End Sub
        Public Sub New()
            Initialiseproject()
        End Sub
        Public Sub New(pProjectId As Integer,
                       pCardNo As Integer)
            _project = FindProjectById(pProjectId)
            _cardNo = pCardNo
            '      LogUtil.Info(Me.ToString, "ProjectThreadCard")
        End Sub
        Public Function IsLoaded() As Boolean
            Return _project IsNot Nothing AndAlso _project.ProjectId > -1
        End Function
#End Region
#Region "methods"
        Public Overrides Function ToString() As String
            Dim _sb As New StringBuilder
            _sb.Append("Project Bead Card=[") _
                .Append("ProjectId=[").Append(CStr(_project.ProjectId)).Append("], ") _
                .Append("CardNo=[").Append(CStr(_cardNo)).Append("]]")
            Return _sb.ToString()
        End Function
#End Region

    End Class
End Namespace
