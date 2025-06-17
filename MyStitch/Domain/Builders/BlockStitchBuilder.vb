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
    Public Overloads Function StartingWith(pBlockstitch As BlockStitch) As BlockStitchBuilder
        With pBlockstitch
            _blockLoc = .BlockLocation
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _threadId = .ThreadId
            _projectId = .ProjectId
            _quarters = .Quarters
            _stitchType = .StitchType
        End With
        Return Me
    End Function
    Public Function WithLocation(pLoc As Point) As BlockStitchBuilder
        _blockLoc = pLoc
        Return Me
    End Function
    Public Function WithQuarters(pQtrs As List(Of BlockStitchQuarter)) As BlockStitchBuilder
        _quarters = pQtrs
        Return Me
    End Function
    Public Overloads Function Build() As BlockStitch
        Return New BlockStitch(_blockLoc, _quarters, _strands, _threadId, _stitchType, _projectId)
    End Function
End Class
