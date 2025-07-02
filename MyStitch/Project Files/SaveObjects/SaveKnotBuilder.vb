' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class SaveKnotBuilder
    Inherits StitchBuilder
    Private _isBead As Boolean
    Public Shared Function ASaveKnot() As SaveKnotBuilder
        Return New SaveKnotBuilder
    End Function
    Public Overloads Function StartingWithNothing() As SaveKnotBuilder
        Initialise()
        _isBead = False
        Return Me
    End Function
    Public Overloads Function StartingWith(pStitch As Stitch) As SaveKnotBuilder
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
    Public Overloads Function StartingWith(pKnot As Knot) As SaveKnotBuilder
        With pKnot
            _blockPos = .BlockPosition
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _thread = Nothing
            _isBead = .IsBead
            _threadId = .ThreadId
            _projectId = .ProjectId
        End With
        Return Me
    End Function
    Public Function WithIsBead(pIsBead As Boolean) As SaveKnotBuilder
        _isBead = pIsBead
        Return Me
    End Function
    Public Function WithKnotLocation(pLoc As Point) As SaveKnotBuilder
        _blockPos = pLoc
        Return Me
    End Function
    Public Overloads Function Build() As SaveKnot
        Return New SaveKnot(_blockPos, _blockQtr, _strands, _threadId, _projectId, _isBead)
    End Function

End Class
