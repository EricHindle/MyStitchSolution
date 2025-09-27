' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects
    Public Class PaletteThread
#Region "properties"
        Private _thread As Thread
        Private _symbolId As Integer
        Private _PaletteId As Integer
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
        Public Property PaletteId() As Integer
            Get
                Return _PaletteId
            End Get
            Set(ByVal value As Integer)
                _PaletteId = value
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
                    _thread = FindThreadById(_threadId)
                End If
                Return _thread
            End Get
        End Property
        Public ReadOnly Property Symbol() As Image
            Get
                If _symbol Is Nothing Then
                    _symbol = FindSymbolImage(_symbolId)
                End If
                Return _symbol
            End Get
        End Property

#End Region
#Region "constructors"
        Private Sub InitialisePaletteThread()
            _thread = Nothing
            _symbolId = -1
            _PaletteId = -1
            _threadId = -1
            _symbol = Nothing
        End Sub
        Public Sub New()
            InitialisePaletteThread()
        End Sub
        Public Sub New(pPaletteId As Integer,
                       pThreadId As Integer,
                       pSymbolId As Integer)
            InitialisePaletteThread()
            _PaletteId = pPaletteId
            _threadId = pThreadId
            _symbolId = pSymbolId
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _PaletteId > -1 And _threadId > -1
        End Function
        Public Function Key() As String
            Return CStr(_PaletteId) & ":" & CStr(_threadId)
        End Function
        Public Overrides Function ToString() As String
            Dim _sb As New StringBuilder
            _sb.Append("PaletteThread=[") _
                .Append("PaletteId=[").Append(CStr(_PaletteId)).Append("], ") _
                .Append(Thread.ToString).Append(", ") _
                .Append("SymbolId=[").Append(CStr(_symbolId)).Append("]") _
                .Append("]")
            Return _sb.ToString()
        End Function
#End Region

    End Class
End Namespace