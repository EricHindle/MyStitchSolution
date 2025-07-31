' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Namespace Domain.Builders
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
        Public Overloads Function StartingWith(pStitch As Stitch) As KnotBuilder
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
        Public Overloads Function StartingWith(pKnot As Knot) As KnotBuilder
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
        Public Overloads Function StartingWith(pKnotString As String) As KnotBuilder
            Dim _stitchStrings As String() = pKnotString.Split(BLOCK_DELIM)
            If _stitchStrings.Length = 2 Then
                Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWith(_stitchStrings(0)).Build
                StartingWith(_stitch)
                _isBead = CBool(_stitchStrings(1))
            End If
            Return Me
        End Function
        Public Function WithIsBead(pIsBead As Boolean) As KnotBuilder
            _isBead = pIsBead
            Return Me
        End Function
        Public Function WithKnotLocation(pLoc As Point) As KnotBuilder
            _blockPos = pLoc
            Return Me
        End Function
        Public Overloads Function Build() As Knot
            Return New Knot(_blockPos, _blockQtr, _strands, _threadId, _projectId, _isBead)
        End Function

    End Class
End Namespace