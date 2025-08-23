' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Namespace Domain.Builders
    Public Class ProjectDesignBuilder
        Private _projectId As Integer
        Private _blockStitches As List(Of BlockStitch)
        Private _backStitches As List(Of BackStitch)
        Private _knots As List(Of Knot)
        Private _rows As Integer
        Private _columns As Integer
        Public Shared Function AProjectDesign() As ProjectDesignBuilder
            Return New ProjectDesignBuilder
        End Function
        Public Function StartingWithNothing() As ProjectDesignBuilder
            _projectId = -1
            _blockStitches = New List(Of BlockStitch)
            _backStitches = New List(Of BackStitch)
            _knots = New List(Of Knot)
            _rows = 0
            _columns = 0
            Return Me
        End Function
        Public Function StartingWith(pDesignString As String()) As ProjectDesignBuilder
            If pDesignString.Length > 0 Then
                If pDesignString(HDR_FLD) = DESIGN_HDR Then
                    _projectId = CInt(pDesignString(PROJ_ID))
                    _blockStitches = New List(Of BlockStitch)
                    _backStitches = New List(Of BackStitch)
                    _knots = New List(Of Knot)
                    Dim _blocksStrings As String() = pDesignString(BLOCK_FLD).Split(LIST_DELIM)
                    Dim _backsStrings As String() = pDesignString(BACKSTITCH_FLD).Split(LIST_DELIM)
                    Dim _knotsStrings As String() = pDesignString(KNOTS_FLD).Split(LIST_DELIM)
                    If _blocksStrings.Length > 0 Then
                        For Each _blockString As String In _blocksStrings
                            If Not String.IsNullOrWhiteSpace(_blockString) Then
                                Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_blockString).Build
                                If _blockstitch.IsLoaded Then
                                    _blockStitches.Add(_blockstitch)
                                End If
                            End If
                        Next
                    End If
                    If _backsStrings.Length > 0 Then
                        For Each _bas As String In _backsStrings
                            If Not String.IsNullOrWhiteSpace(_bas) Then
                                _backStitches.Add(BackstitchBuilder.ABackStitch.StartingWith(_bas).Build)
                            End If
                        Next
                    End If
                    If _knotsStrings.Length > 0 Then
                        For Each _knot As String In _knotsStrings
                            If Not String.IsNullOrWhiteSpace(_knot) Then
                                _knots.Add(KnotBuilder.AKnot.StartingWith(_knot).Build)
                            End If
                        Next
                    End If
                    _rows = pDesignString(ROWS_FLD)
                    _columns = pDesignString(COLS_FLD)
                End If
            End If

            Return Me
        End Function
        Public Function StartingWith(pDesign As ProjectDesign) As ProjectDesignBuilder
            With pDesign
                _projectId = .ProjectId
                _blockStitches = .BlockStitches
                _backStitches = .BackStitches
                _knots = .Knots
                _rows = .Rows
                _columns = .Columns
            End With
            Return Me
        End Function
        Public Function WithRows(pRows As Integer) As ProjectDesignBuilder
            _rows = pRows
            Return Me
        End Function
        Public Function WithColumns(pColumns As Integer) As ProjectDesignBuilder
            _columns = pColumns
            Return Me
        End Function
        Public Function Build() As ProjectDesign
            Return New ProjectDesign(_projectId, _blockStitches, _backStitches, _knots, _rows, _columns)
        End Function
    End Class
End Namespace