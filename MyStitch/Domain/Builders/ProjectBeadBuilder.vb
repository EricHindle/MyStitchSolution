' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class ProjectBeadBuilder
        Private _project As Project
        Private _bead As Bead
        Private _projectId As Integer
        Private _beadId As Integer
        Private _isUsed As Boolean
        Public Shared Function AProjectBead() As ProjectBeadBuilder
            Return New ProjectBeadBuilder
        End Function
        Public Function StartingWithNothing() As ProjectBeadBuilder
            _project = Nothing
            _Bead = Nothing
            _beadId = -1
            _projectId = -1
            _isUsed = False
            Return Me
        End Function
        Public Function StartingWith(ByRef pBead As ProjectBead) As ProjectBeadBuilder
            StartingWithNothing()
            If pBead IsNot Nothing Then
                With pBead
                    _projectId = .ProjectId
                    _BeadId = .BeadId
                    _isUsed = .IsUsed
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As ProjectBeadsRow) As ProjectBeadBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _project = Nothing
                    _Bead = Nothing
                    _projectId = .project_id
                    _BeadId = .bead_id
                    _isUsed = .is_used
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(oString As String) As ProjectBeadBuilder
            StartingWithNothing()
            Dim _values As String() = oString.Split(DESIGN_DELIM)
            _project = Nothing
            _Bead = Nothing
            If _values.Length > 0 Then _projectId = _values(0)
            If _values.Length > 1 Then _BeadId = _values(1)
            If _values.Length > 2 Then
                If Not Boolean.TryParse(_values(2), _isUsed) Then
                    _isUsed = False
                End If
            End If
            Return Me
        End Function
        Public Function WithBeadId(pId As Integer) As ProjectBeadBuilder
            _BeadId = pId
            Return Me
        End Function
        Public Function WithProjectId(pId As Integer) As ProjectBeadBuilder
            _projectId = pId
            Return Me
        End Function
        Public Function WithIsUsed(pIsUsed As Boolean) As ProjectBeadBuilder
            _isUsed = pIsUsed
            Return Me
        End Function
        Public Function Build() As ProjectBead
            Return New ProjectBead(_projectId, _beadId, _isUsed)
        End Function
    End Class
End Namespace