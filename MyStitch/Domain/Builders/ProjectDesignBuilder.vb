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
        Public Function StartingWith(pSavedDesign As String) As ProjectDesignBuilder
            Dim _designString As String() = pSavedDesign.Split(DESIGN_DELIM)
            If _designString.Length > 0 Then
                If _designString(0) = DESIGN_HDR Then
                    _projectId = CInt(_designString(1))
                    _blockStitches = New List(Of BlockStitch)
                    _backStitches = New List(Of BackStitch)
                    _knots = New List(Of Knot)
                    Dim _blocksStrings As String() = _designString(3).Split(LIST_DELIM)
                    Dim _backsStrings As String() = _designString(5).Split(LIST_DELIM)
                    Dim _knotsStrings As String() = _designString(7).Split(LIST_DELIM)
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
                    _rows = _designString(8)
                    _columns = _designString(9)
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
        Public Function Build() As ProjectDesign
            Return New ProjectDesign(_projectId, _blockStitches, _backStitches, _knots, _rows, _columns)
        End Function
    End Class
End Namespace