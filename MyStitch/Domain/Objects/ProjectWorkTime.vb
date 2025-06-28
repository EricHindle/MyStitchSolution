' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports Newtonsoft.Json
Namespace Domain.Objects
    Public Class ProjectWorkTime
#Region "properties"
        Private _projectId As Integer
        Private _timeStarted As DateTime
        Private _timeEnded As DateTime
        Private _minutes As Integer
        Public Property Minutes() As Integer
            Get
                Return _minutes
            End Get
            Set(ByVal value As Integer)
                _minutes = value
            End Set
        End Property
        Public Property TimeEnded() As DateTime
            Get
                Return _timeEnded
            End Get
            Set(ByVal value As DateTime)
                _timeEnded = value
            End Set
        End Property
        Public Property TimeStarted() As DateTime
            Get
                Return _timeStarted
            End Get
            Set(ByVal value As DateTime)
                _timeStarted = value
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
            _timeStarted = MIN_DATE
            _timeEnded = MIN_DATE
            _minutes = 0
        End Sub
        Public Sub New()
            Initialiseproject()
        End Sub
        Public Sub New(pId As Integer,
                       pStarted As DateTime,
                       pEnded As DateTime,
                       pMinutes As Integer)
            Initialiseproject()
            _projectId = pId
            _timeStarted = pStarted
            _timeEnded = pEnded
            _minutes = pMinutes
        End Sub
#End Region
#Region "methods"
        Public Overrides Function ToString() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
#End Region

    End Class
End Namespace
