' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class BlockStitchBuilder
    Inherits StitchBuilder
    Private _quarters As List(Of BlockStitchQuarter)
    Public Shared Function ABlockStitch() As BlockStitchBuilder
        Return New BlockStitchBuilder
    End Function
    Public Overloads Function StartingWithNothing() As BlockStitchBuilder
        Initialise()
        _quarters = New List(Of BlockStitchQuarter)
        Return Me
    End Function
    Public Overloads Function StartingWith(pStitch As Stitch) As BlockStitchBuilder
        With pStitch
            _blockPos = .BlockPosition
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
            _stitchType = .StitchType
        End With
        Return Me
    End Function
    Public Overloads Function StartingWith(pBlockString As String) As BlockStitchBuilder
        Dim _stitchStrings As String() = pBlockString.Split(BLOCK_DELIM)
        _quarters = New List(Of BlockStitchQuarter)
        If _stitchStrings.Length = 2 Then
            Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWith(_stitchStrings(0)).Build
            StartingWith(_stitch)
            Dim _qtrs As String() = _stitchStrings(1).Split(STITCH_DELIM)
            For Each _qtr As String In _qtrs
                If Not String.IsNullOrWhiteSpace(_qtr) Then
                    _quarters.Add(BlockStitchQuarterBuilder.ABlockStitchQuarter.StartingWith(_qtr).Build)
                End If
            Next
        End If
        Return Me
    End Function
    Public Overloads Function StartingWith(pBlockstitch As BlockStitch) As BlockStitchBuilder
        With pBlockstitch
            _blockPos = .BlockPosition
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
            _quarters = .Quarters
            _stitchType = .StitchType
        End With
        Return Me
    End Function
    Public Function WithPosition(pPos As Point) As BlockStitchBuilder
        _blockPos = pPos
        Return Me
    End Function
    Public Function WithQuarters(pQtrs As List(Of BlockStitchQuarter)) As BlockStitchBuilder
        _quarters = pQtrs
        Return Me
    End Function
    Public Overloads Function Build() As BlockStitch
        Return New BlockStitch(_blockPos, _blockQtr, _quarters, _strands, _threadId, _stitchType, _projectId)
    End Function
End Class
