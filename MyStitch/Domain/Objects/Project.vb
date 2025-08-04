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
        Private _design As ProjectDesign
        Private _designFileName As String
        Private _originX As Integer
        Private _originY As Integer
        Private _totalMinutes As Integer
        Public Property TotalMinutes() As Integer
            Get
                Return _totalMinutes
            End Get
            Set(ByVal value As Integer)
                _totalMinutes = value
            End Set
        End Property
        Public ReadOnly Property Origin As Point
            Get
                Return New Point(_originX, _originY)
            End Get
        End Property
        Public Property OriginY() As Integer
            Get
                Return _originY
            End Get
            Set(ByVal value As Integer)
                _originY = value
            End Set
        End Property
        Public Property OriginX() As Integer
            Get
                Return _originX
            End Get
            Set(ByVal value As Integer)
                _originX = value
            End Set
        End Property
        Public Property DesignFileName() As String
            Get
                Return _designFileName
            End Get
            Set(ByVal value As String)
                _designFileName = value
            End Set
        End Property
        Public Property Design() As ProjectDesign
            Get
                Return _design
            End Get
            Set(ByVal value As ProjectDesign)
                _design = value
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
            _designHeight = 1
            _designWidth = 1
            _fabricWidth = 1
            _fabricHeight = 1
            _fabricColour = Color.White.ToArgb
            _design = New ProjectDesign
            _designFileName = String.Empty
            _originX = 0
            _originY = 0
            _totalMinutes = 0
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
                       pDesign As ProjectDesign,
                       pDesignFilename As String,
                       pOriginX As Integer,
                       pOriginY As Integer,
                       pTotalMinutes As Integer)
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
            _design = pDesign
            _designFileName = pDesignFilename
            _originX = pOriginX
            _originY = pOriginY
            _totalMinutes = pTotalMinutes
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _projectId > -1
        End Function
        Public Function ToSaveString() As String
            Dim _sb As New StringBuilder
            _sb _
            .Append(PROJECT_HDR).Append(DESIGN_DELIM) _
            .Append(CStr(_projectId)).Append(DESIGN_DELIM) _
            .Append(_projectName).Append(DESIGN_DELIM) _
            .Append(_dateStarted.ToString("yyyy-MM-dd HH:mm:ss")).Append(DESIGN_DELIM) _
            .Append(_dateEnded.ToString("yyyy-MM-dd HH:mm:ss")).Append(DESIGN_DELIM) _
            .Append(CStr(_designWidth)).Append(DESIGN_DELIM) _
            .Append(CStr(_designHeight)).Append(DESIGN_DELIM) _
            .Append(CStr(_fabricWidth)).Append(DESIGN_DELIM) _
            .Append(CStr(_fabricHeight)).Append(DESIGN_DELIM) _
            .Append(CStr(_fabricColour)).Append(DESIGN_DELIM) _
            .Append(_designFileName).Append(DESIGN_DELIM) _
            .Append(CStr(_originX)).Append(DESIGN_DELIM) _
            .Append(CStr(_originY)).Append(DESIGN_DELIM) _
            .Append(CStr(_totalMinutes))
            Return _sb.ToString
        End Function
#End Region

    End Class
End Namespace
