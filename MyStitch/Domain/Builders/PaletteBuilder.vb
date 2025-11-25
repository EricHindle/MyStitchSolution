' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class PaletteBuilder

        Private _PaletteId As Integer
        Private _PaletteName As String
        Public Shared Function APalette() As PaletteBuilder
            Return New PaletteBuilder
        End Function
        Public Function StartingWithNothing() As PaletteBuilder
            _PaletteId = -1
            _PaletteName = String.Empty
            Return Me
        End Function
        Public Function StartingWith(ByRef pPalette As Palette) As PaletteBuilder
            StartingWithNothing()
            If pPalette IsNot Nothing Then
                With pPalette
                    _PaletteId = .PaletteId
                    _PaletteName = .PaletteName
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As PalettesRow) As PaletteBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _PaletteId = .palette_id
                    _PaletteName = .palette_name
                End With
            End If
            Return Me
        End Function
        Public Function WithId(pId As Integer) As PaletteBuilder
            _PaletteId = pId
            Return Me
        End Function
        Public Function WithName(pPalettename As String) As PaletteBuilder
            _PaletteName = pPalettename
            Return Me
        End Function
        Public Function Build() As Palette
            Return New Palette(_PaletteId,
                               _PaletteName)
        End Function

    End Class
End Namespace
