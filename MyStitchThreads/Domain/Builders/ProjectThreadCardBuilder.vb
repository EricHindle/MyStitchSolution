' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ProjectThreadCardBuilder
    Private _project As Project
    Private _cardNo As Integer
    Private _threadList As List(Of ProjectThread)

    Public Shared Function AProjectThreadCard() As ProjectThreadCardBuilder
        Return New ProjectThreadCardBuilder
    End Function
    Public Function StartingWithNothing() As ProjectThreadCardBuilder
        _project = New Project()
        _cardNo = -1
        _threadList = New List(Of ProjectThread)
        Return Me
    End Function
    Public Function StartingWith(ByRef pThreadCard As ProjectThreadCard) As ProjectThreadCardBuilder
        StartingWithNothing()
        If pThreadCard IsNot Nothing Then
            _project = pThreadCard.Project
            _cardNo = pThreadCard.CardNo
            _threadList = pThreadCard.ThreadList
        End If
        Return Me
    End Function
    Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectThreadCardsRow) As ProjectThreadCardBuilder
        StartingWithNothing()
        If oRow IsNot Nothing Then
            _project = GetProjectById(oRow.project_id)
            _cardNo = oRow.thread_card_no
        End If
        Return Me
    End Function

    Public Function WithProject(pProject As Project) As ProjectThreadCardBuilder
        _project = pProject
        Return Me
    End Function
    Public Function WithProjectId(pId As Integer) As ProjectThreadCardBuilder
        _project = GetProjectById(pId)
        Return Me
    End Function
    Public Function WithCardNo(pCardNo As Integer) As ProjectThreadCardBuilder
        _cardNo = pCardNo
        Return Me
    End Function
    Public Function WithThreadList(pThreadList As List(Of ProjectThread)) As ProjectThreadCardBuilder
        _threadList = pThreadList
        Return Me
    End Function
    Public Function Build() As ProjectThreadCard
        Return New ProjectThreadCard(_project.ProjectId, _cardNo)
    End Function

End Class
