' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class KnotBuilder
    Inherits StitchBuilder
    Private _isBead As Boolean
    Public Shared Function AKnot() As KnotBuilder
        Return New KnotBuilder
    End Function
    Public Overloads Function StartingWithNothing() As KnotBuilder
        Initialise()
        _isBead = False
        Return Me
    End Function
    Public Overloads Function StartingWith(pKnot As Knot) As KnotBuilder
        With pKnot
            _blockLoc = .BlockLocation
            _blockQtr = .BlockQuarter
            _strands = .Strands
            _thread = .ProjThread
            _isBead = .IsBead
        End With
        Return Me
    End Function
    Public Overloads Function Build() As Knot
        Return New Knot(_blockLoc, _blockQtr, _strands, _threadId, _projectId, _isBead)
    End Function

End Class
