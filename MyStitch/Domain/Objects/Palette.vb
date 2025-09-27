' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Namespace Domain.Objects
    Public Class Palette
#Region "properties"
        Private _PaletteId As Integer
        Private _PaletteName As String

        Public Property PaletteName() As String
            Get
                Return _PaletteName
            End Get
            Set(ByVal value As String)
                _PaletteName = value
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
#End Region
#Region "constructors"
        Private Sub InitialisePalette()
            _PaletteId = -1
            _PaletteName = String.Empty

        End Sub
        Public Sub New()
            InitialisePalette()
        End Sub
        Public Sub New(pId As Integer,
                 pPaletteName As String)
            InitialisePalette()
            _PaletteId = pId
            _PaletteName = pPaletteName
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _PaletteId > -1
        End Function

#End Region

    End Class
End Namespace
