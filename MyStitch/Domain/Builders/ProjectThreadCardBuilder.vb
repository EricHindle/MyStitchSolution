' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class ProjectThreadCardBuilder
        Private _project As Project
        Private _cardNo As Integer

        Public Shared Function AProjectThreadCard() As ProjectThreadCardBuilder
            Return New ProjectThreadCardBuilder
        End Function
        Public Function StartingWithNothing() As ProjectThreadCardBuilder
            _project = New Project()
            _cardNo = -1
            Return Me
        End Function
        Public Function StartingWith(ByRef pThreadCard As ProjectThreadCard) As ProjectThreadCardBuilder
            StartingWithNothing()
            If pThreadCard IsNot Nothing Then
                _project = pThreadCard.Project
                _cardNo = pThreadCard.CardNo
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As ProjectThreadCardsRow) As ProjectThreadCardBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                _project = FindProjectById(oRow.project_id)
                _cardNo = oRow.thread_card_no
            End If
            Return Me
        End Function
        Public Function WithProject(pProject As Project) As ProjectThreadCardBuilder
            _project = pProject
            Return Me
        End Function
        Public Function WithProjectId(pId As Integer) As ProjectThreadCardBuilder
            _project = FindProjectById(pId)
            Return Me
        End Function
        Public Function WithCardNo(pCardNo As Integer) As ProjectThreadCardBuilder
            _cardNo = pCardNo
            Return Me
        End Function
        Public Function Build() As ProjectThreadCard
            Return New ProjectThreadCard(_project.ProjectId, _cardNo)
        End Function

    End Class
End Namespace