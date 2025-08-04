' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects
    Public Class ProjectThread
#Region "properties"
        Private _thread As Thread
        Private _symbolId As Integer
        Private _projectId As Integer
        Private _threadId As Integer
        Private _symbol As Image
        Public Property ThreadId() As Integer
            Get
                Return _threadId
            End Get
            Set(ByVal value As Integer)
                _threadId = value
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

        Public Property SymbolId() As Integer
            Get
                Return _symbolId
            End Get
            Set(ByVal value As Integer)
                _symbolId = value
            End Set
        End Property
        Public ReadOnly Property Thread() As Thread
            Get
                If _thread Is Nothing Then
                    _thread = GetThreadById(_threadId)
                End If
                Return _thread
            End Get
        End Property
        Public ReadOnly Property Symbol() As Image
            Get
                If _symbol Is Nothing Then
                    _symbol = GetSymbolImage(_symbolId)
                End If
                Return _symbol
            End Get
        End Property

#End Region
#Region "constructors"
        Private Sub InitialiseProjectThread()
            _thread = Nothing
            _symbolId = -1
            _projectId = -1
            _threadId = -1
            _symbol = Nothing
        End Sub
        Public Sub New()
            InitialiseProjectThread()
        End Sub
        Public Sub New(pProjectId As Integer,
                       pThreadId As Integer,
                       pSymbolId As Integer)
            _projectId = pProjectId
            _threadId = pThreadId
            _symbolId = pSymbolId
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _projectId > -1 And _threadId > -1
        End Function
        Public Function Key() As String
            Return CStr(_projectId) & ":" & CStr(_threadId)
        End Function
        Public Overrides Function ToString() As String
            Dim _sb As New StringBuilder
            _sb.Append("ProjectThread=[") _
                .Append("ProjectId=[").Append(CStr(_projectId)).Append("], ") _
                .Append(Thread.ToString).Append(", ") _
                .Append("SymbolId=[").Append(CStr(_symbolId)).Append("]") _
                .Append("]")
            Return _sb.ToString()
        End Function
        Public Function ToSaveString() As String
            Dim _sb As New StringBuilder
            _sb _
            .Append(CStr(_projectId)).Append(DESIGN_DELIM) _
            .Append(CStr(_threadId)).Append(DESIGN_DELIM) _
            .Append(CStr(_symbolId)).Append(DESIGN_DELIM) _
            .Append(Thread.ToSaveString)
            Return _sb.ToString()
        End Function
#End Region

    End Class
End Namespace