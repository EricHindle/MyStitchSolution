' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class PaletteThreadBuilder
        Private _symbolId As Integer
        Private _PaletteId As Integer
        Private _threadId As Integer
        Private _isBead As Boolean
        Public Shared Function APaletteThread() As PaletteThreadBuilder
            Return New PaletteThreadBuilder
        End Function
        Public Function StartingWithNothing() As PaletteThreadBuilder
            _symbolId = -1
            _threadId = -1
            _PaletteId = -1
            _isBead = False
            Return Me
        End Function
        Public Function StartingWith(ByRef pThread As PaletteThread) As PaletteThreadBuilder
            StartingWithNothing()
            If pThread IsNot Nothing Then
                With pThread
                    _PaletteId = .PaletteId
                    _threadId = .ThreadId
                    _symbolId = .SymbolId
                    _isBead = .IsBead
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As PaletteThreadsRow) As PaletteThreadBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    '_Palette = Nothing
                    '_thread = Nothing
                    _PaletteId = .palette_id
                    _threadId = .thread_id
                    _symbolId = .symbol_id
                    _isBead = (.isbead = 1)
                End With
            End If
            Return Me
        End Function
        Public Function WithThreadId(pId As Integer) As PaletteThreadBuilder
            _threadId = pId
            Return Me
        End Function
        Public Function WithPaletteId(pId As Integer) As PaletteThreadBuilder
            _PaletteId = pId
            Return Me
        End Function
        Public Function WithSymbolId(pSymbolId As Integer) As PaletteThreadBuilder
            _symbolId = pSymbolId
            Return Me
        End Function
        Public Function WithSIsBead(pIsBead As Boolean) As PaletteThreadBuilder
            _isBead = pIsBead
            Return Me
        End Function
        Public Function Build() As PaletteThread
            Return New PaletteThread(_PaletteId, _threadId, _symbolId, _isBead)
        End Function
    End Class
End Namespace