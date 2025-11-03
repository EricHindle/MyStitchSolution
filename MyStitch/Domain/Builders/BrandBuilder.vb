' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class BrandBuilder
        Private _BrandId As Integer
        Private _BrandName As String

        Public Shared Function ABrand() As BrandBuilder
            Return New BrandBuilder
        End Function
        Public Function StartingWithNothing() As BrandBuilder
            _BrandId = -1
            _BrandName = String.Empty
            Return Me
        End Function
        Public Function StartingWith(ByRef pBrand As Brand) As BrandBuilder
            StartingWithNothing()
            If pBrand IsNot Nothing Then
                With pBrand
                    _BrandId = .BrandId
                    _BrandName = pBrand.BrandName
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As BrandsRow) As BrandBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                _BrandId = oRow.brand_id
                _BrandName = oRow.brand_name
            End If
            Return Me
        End Function
        Public Function WithId(pId As Integer) As BrandBuilder
            _BrandId = pId
            Return Me
        End Function
        Public Function WithName(pBrandName As String) As BrandBuilder
            _BrandName = pBrandName
            Return Me
        End Function
        Public Function Build() As Brand
            Return New Brand(_BrandId, _BrandName)
        End Function

    End Class
End Namespace
