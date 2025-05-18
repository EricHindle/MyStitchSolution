' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects
    Public Class Project
#Region "properties"
        Private _projectId As Integer
        Private _projectName As String
        Private _dateStarted As DateTime
        Private _dateEnded As DateTime
        Private _designWidth As Integer
        Private _designHeight As Integer
        Private _fabricWidth As Integer
        Private _fabricHeight As Integer
        Private _fabricColour As Integer
        Private _grid1Colour As Integer
        Private _grid5Colour As Integer
        Private _grid10Colour As Integer
        Public Property Grid10Colour() As Integer
            Get
                Return _grid10Colour
            End Get
            Set(ByVal value As Integer)
                _grid10Colour = value
            End Set
        End Property
        Public Property Grid5Colour() As Integer
            Get
                Return _grid5Colour
            End Get
            Set(ByVal value As Integer)
                _grid5Colour = value
            End Set
        End Property
        Public Property Grid1Colour() As Integer
            Get
                Return _grid1Colour
            End Get
            Set(ByVal value As Integer)
                _grid1Colour = value
            End Set
        End Property
        Public Property FabricColour() As Integer
            Get
                Return _fabricColour
            End Get
            Set(ByVal value As Integer)
                _fabricColour = value
            End Set
        End Property
        Public Property FabricHeight() As Integer
            Get
                Return _fabricHeight
            End Get
            Set(ByVal value As Integer)
                _fabricHeight = value
            End Set
        End Property
        Public Property FabricWidth() As Integer
            Get
                Return _fabricWidth
            End Get
            Set(ByVal value As Integer)
                _fabricWidth = value
            End Set
        End Property
        Public Property DesignHeight() As Integer
            Get
                Return _designHeight
            End Get
            Set(ByVal value As Integer)
                _designHeight = value
            End Set
        End Property
        Public Property DesignWidth() As Integer
            Get
                Return _designWidth
            End Get
            Set(ByVal value As Integer)
                _designWidth = value
            End Set
        End Property
        Public Property DateEnded() As DateTime
            Get
                Return _dateEnded
            End Get
            Set(ByVal value As DateTime)
                _dateEnded = value
            End Set
        End Property
        Public Property DateStarted() As DateTime
            Get
                Return _dateStarted
            End Get
            Set(ByVal value As DateTime)
                _dateStarted = value
            End Set
        End Property
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
            _dateStarted = MIN_DATE
            _dateEnded = MIN_DATE
            _designHeight = 0
            _designWidth = 0
            _fabricWidth = 0
            _fabricHeight = 0
            _fabricColour = Color.Black.ToArgb
        End Sub
        Public Sub New()
            Initialiseproject()
        End Sub
        Public Sub New(pId As Integer,
                 pProjectName As String)
            Initialiseproject()
            _projectId = pId
            _projectName = pProjectName
        End Sub
        Public Sub New(pId As Integer,
                       pProjectName As String,
                       pStarted As DateTime,
                       pEnded As DateTime,
                       pDesignWidth As Integer,
                       pDesignHeight As Integer,
                       pFabricWidth As Integer,
                       pFabricHeight As Integer,
                       pFabricColour As Integer,
                       pGrid1Colour As Integer,
                       pGrid5Colour As Integer,
                       pGrid10Colour As Integer)
            Initialiseproject()
            _projectId = pId
            _projectName = pProjectName
            _dateStarted = pStarted
            _dateEnded = pEnded
            _designWidth = pDesignWidth
            _designHeight = pDesignHeight
            _fabricWidth = pFabricWidth
            _fabricHeight = pFabricHeight
            _fabricColour = pFabricColour
            _grid1Colour = pGrid1Colour
            _grid5Colour = pGrid5Colour
            _grid10Colour = pGrid10Colour
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _projectId > -1
        End Function
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
End Namespace
