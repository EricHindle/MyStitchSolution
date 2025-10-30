' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchData
Namespace Domain.Builders
    Public Class BeadBuilder
        Private _BeadId As Integer
        Private _BeadNo As String
        Private _colourName As String
        Private _colour As Color
        Private _sortNumber As Integer
        Private _stock_level As Integer
        Private _brandId As Integer
        Public Shared Function ABead() As BeadBuilder
            Return New BeadBuilder
        End Function
        Public Function StartingWithNothing() As BeadBuilder
            _BeadId = -1
            _BeadNo = String.Empty
            _colourName = String.Empty
            _colour = Color.White
            _sortNumber = -1
            _stock_level = 0
            _brandId = -1
            Return Me
        End Function
        Public Function StartingWith(ByRef pBead As Bead) As BeadBuilder
            StartingWithNothing()
            If pBead IsNot Nothing Then
                With pBead
                    _BeadId = .beadId
                    _BeadNo = pBead.beadNo
                    _colourName = .ColourName
                    _colour = .Colour
                    _sortNumber = .SortNumber
                    _stock_level = .StockLevel
                    _brandId = .BrandId
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As BeadsRow) As BeadBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                _BeadId = oRow.bead_id
                _BeadNo = oRow.bead_no
                _colourName = oRow.bead_colour_name
                _colour = Color.FromArgb(oRow.bead_colour)
                _sortNumber = Bead.MakeSortNumber(_BeadNo, _BeadId)
                _stock_level = oRow.stock_level
                _brandId = oRow.brand_id
            End If
            Return Me
        End Function
        Public Function WithId(pId As Integer) As BeadBuilder
            _BeadId = pId
            Return Me
        End Function
        Public Function WithName(pColourname As String) As BeadBuilder
            _colourName = pColourname
            Return Me
        End Function
        Public Function WithNumber(pBeadNo As String) As BeadBuilder
            _BeadNo = pBeadNo
            _sortNumber = Bead.MakeSortNumber(_BeadNo, _BeadId)
            Return Me
        End Function
        Public Function WithColour(pColour As Color) As BeadBuilder
            _colour = pColour
            Return Me
        End Function
        Public Function WithStockLevel(pStock As Integer) As BeadBuilder
            _stock_level = pStock
            Return Me
        End Function
        Public Function WithBrandId(pBrandId As Integer) As BeadBuilder
            _brandId = pBrandId
            Return Me
        End Function
        Public Function Build() As Bead
            Return New Bead(_BeadId, _BeadNo, _colourName, _colour, _stock_level, _brandId)
        End Function

    End Class
End Namespace
