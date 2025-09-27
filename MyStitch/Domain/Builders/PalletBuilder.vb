' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Namespace Domain.Builders
    Public Class PalletBuilder

        Private _palletId As Integer
        Private _palletName As String
        Public Shared Function APallet() As PalletBuilder
            Return New PalletBuilder
        End Function
        Public Function StartingWithNothing() As PalletBuilder
            _PalletId = -1
            _PalletName = String.Empty
            Return Me
        End Function
        Public Function StartingWith(ByRef pPallet As Pallet) As PalletBuilder
            StartingWithNothing()
            If pPallet IsNot Nothing Then
                With pPallet
                    _palletId = .PalletId
                    _palletName = .PalletName
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As MyStitchDataSet.PalletsRow) As PalletBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _PalletId = .pallet_id
                    _PalletName = .pallet_name
                End With
            End If
            Return Me
        End Function
        Public Function WithId(pId As Integer) As PalletBuilder
            _PalletId = pId
            Return Me
        End Function
        Public Function WithName(pPalletname As String) As PalletBuilder
            _PalletName = pPalletname
            Return Me
        End Function
        Public Function Build() As Pallet
            Return New Pallet(_palletId,
                               _palletName)
        End Function

    End Class
    End Namespace
