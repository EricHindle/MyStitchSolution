' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class SymbolBuilder
        Private _SymbolId As Integer
        Private _SymbolBytes As Byte()
        Public Shared Function ASymbol() As SymbolBuilder
            Return New SymbolBuilder
        End Function
        Public Function StartingWithNothing() As SymbolBuilder
            _SymbolId = -1
            _SymbolBytes = Nothing

            Return Me
        End Function
        Public Function StartingWith(ByRef pSymbol As Symbol) As SymbolBuilder
            StartingWithNothing()
            If pSymbol IsNot Nothing Then
                With pSymbol
                    _SymbolId = .SymbolId
                    _SymbolBytes = .SymbolBytes
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As SymbolsRow) As SymbolBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                _SymbolId = oRow.symbol_id
                _SymbolBytes = If(oRow.IssymbolNull, Nothing, oRow.symbol)
            End If
            Return Me
        End Function
        Public Function WithId(pId As Integer) As SymbolBuilder
            _SymbolId = pId
            Return Me
        End Function

        Public Function WithSymbolBytes(pSymbol As Byte()) As SymbolBuilder
            _SymbolBytes = pSymbol
            Return Me
        End Function

        Public Function Build() As Symbol
            Return New Symbol(_SymbolId, _SymbolBytes)
        End Function

    End Class
End Namespace

