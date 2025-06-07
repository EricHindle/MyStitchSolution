' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports Newtonsoft.Json
Namespace Domain.Objects
    Public Class ProjectThread
#Region "properties"
        Private _project As Project
        Private _thread As Thread
        Private _backstitchCount As Integer
        Private _blockstitchCount As Integer
        Private _knotCount As Integer
        Private _symbolId As Integer
        Public Property SymbolId() As Integer
            Get
                Return _symbolId
            End Get
            Set(ByVal value As Integer)
                _symbolId = value
            End Set
        End Property
        Public Property KnotCount() As Integer
            Get
                Return _knotCount
            End Get
            Set(ByVal value As Integer)
                _knotCount = value
            End Set
        End Property
        Public Property BlockstitchCount() As Integer
            Get
                Return _blockstitchCount
            End Get
            Set(ByVal value As Integer)
                _blockstitchCount = value
            End Set
        End Property
        Public Property BackstitchCount() As Integer
            Get
                Return _backstitchCount
            End Get
            Set(ByVal value As Integer)
                _backstitchCount = value
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
        Private Sub InitialiseProjectThread()
            _project = New Project
            _thread = New Thread
            _blockstitchCount = 0
            _backstitchCount = 0
            _knotCount = 0
            _symbolId = -1
        End Sub
        Public Sub New()
            InitialiseProjectThread()
        End Sub
        Public Sub New(pProjectId As Integer,
                       pThreadId As Integer,
                       pBackstitchCount As Integer,
                       pBlockstitchCount As Integer,
                       pKnotCount As Integer,
                       pSymbolId As Integer)
            _project = GetProjectById(pProjectId)
            _thread = GetThreadById(pThreadId)
            _blockstitchCount = pBlockstitchCount
            _backstitchCount = pBackstitchCount
            _knotCount = pKnotCount
            _symbolId = pSymbolId
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
            Return JsonConvert.SerializeObject(Me)
        End Function
#End Region

    End Class
End Namespace