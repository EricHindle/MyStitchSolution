' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Namespace Domain.Builders
    Public Class ProjectBeadCollectionBuilder
        Private _Beads As List(Of ProjectBead)
        Public Shared Function AProjectBeadCollection() As ProjectBeadCollectionBuilder
            Return New ProjectBeadCollectionBuilder
        End Function
        Public Function StartingWithNothing() As ProjectBeadCollectionBuilder
            _Beads = New List(Of ProjectBead)
            Return Me
        End Function
        Public Function StartingWith(ByRef pBeads As List(Of ProjectBead)) As ProjectBeadCollectionBuilder
            _Beads = New List(Of ProjectBead)(pBeads)
            Return Me
        End Function
        Public Function StartingWith(ByRef pBeadStrings As String()) As ProjectBeadCollectionBuilder
            StartingWithNothing()
            Dim _BeadList As List(Of String) = pBeadStrings.ToList
            If _BeadList.Count > 0 Then
                If _BeadList(0) = PROJECT_BEADS_HDR Then
                    _BeadList.RemoveAt(0)
                    For Each _BeadString As String In _BeadList
                        Dim _projBead As ProjectBead = ProjectBeadBuilder.AProjectBead.StartingWith(_BeadString).Build
                        '         If _projBead.ProjectId > 0 Then
                        _Beads.Add(_projBead)
                        '         End If
                    Next
                End If
            End If
            Return Me
        End Function
        Public Function Build() As ProjectBeadCollection
            Return New ProjectBeadCollection(_Beads)
        End Function
    End Class
End Namespace
