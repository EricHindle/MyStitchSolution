' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Imaging
Namespace Domain.Objects
    Public Class Symbol

#Region "properties"
        Private _SymbolId As Integer
        Private _SymbolBytes As Byte()

        Public ReadOnly Property SymbolImage As Bitmap
            Get
                Dim _bitmap As New Bitmap(64, 64)
                If _SymbolBytes IsNot Nothing Then
                    _bitmap = ImageUtil.ConvertBytesToImage(_SymbolBytes)
                End If
                Return _bitmap
            End Get
        End Property
        Public Property SymbolBytes() As Byte()
            Get
                Return _SymbolBytes
            End Get
            Set(ByVal value As Byte())
                _SymbolBytes = value
            End Set
        End Property
        Public Property SymbolId() As Integer
            Get
                Return _SymbolId
            End Get
            Set(ByVal value As Integer)
                _SymbolId = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub InitialiseSymbol()
            _SymbolId = -1
            _SymbolBytes = Nothing
        End Sub
        Public Sub New()
            InitialiseSymbol()
        End Sub
        Public Sub New(pId As Integer,
                       pSymbol As Byte())
            _SymbolId = pId
            _SymbolBytes = pSymbol
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _SymbolId > -1
        End Function

#End Region
    End Class
End Namespace

