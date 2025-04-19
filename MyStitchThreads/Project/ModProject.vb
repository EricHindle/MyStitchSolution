' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Module ModProject
    Public isCardsLoading As Boolean
    Public Sub LoadProjectList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.LogInfo("Load project list", pBaseName)
        pDgv.Rows.Clear()
        For Each oproject As Project In GetProjects()
            AddProjectRow(pDgv, oproject)
        Next
        pDgv.ClearSelection()
    End Sub
    Private Sub AddProjectRow(ByRef pDgv As DataGridView, oProject As Project)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        oRow.Cells(pDgv.Columns(0).Name).Value = oProject.ProjectId
        oRow.Cells(pDgv.Columns(1).Name).Value = oProject.ProjectName
    End Sub
    Public Function LoadCardList(pProjectId As Integer, ByRef pListBox As ListBox, pBasename As String) As Integer
        LogUtil.LogInfo("Load card list", pBasename)
        isCardsLoading = True
        Dim oLastCardNo As Integer = 0

        pListBox.Items.Clear()
        Dim _list As List(Of ProjectThreadCard) = GetProjectThreadCards(pProjectId)
        For Each oProjectCard As ProjectThreadCard In _list
            pListBox.Items.Add(oProjectCard.CardNo)
            If oProjectCard.CardNo > oLastCardNo Then oLastCardNo = oProjectCard.CardNo
        Next
        isCardsLoading = False
        Return oLastCardNo
    End Function
    Public Sub SaveCardThreads(pDgv As DataGridView, pProjectId As Integer, pCardNo As Integer)
        Dim _seq As Integer = 1
        For Each oRow As DataGridViewRow In pDgv.Rows
            Dim _cardThread As ProjectCardThread = ProjectCardThreadBuilder.AProjectCardThread.StartingWithNothing _
                .WithProjectId(pProjectId) _
                .WithThreadId(oRow.Cells("cardthreadid").Value) _
                .WithCardNo(pCardNo) _
                .WithCardseq(_seq) _
                .Build
            InsertProjectCardThread(_cardThread)
            _seq += 1
        Next
    End Sub
    Public Sub UpdateProjectThreadCard(ByRef pDgv As DataGridView, pProjectId As Integer, pCardNo As Integer, pBaseName As String)
        DeleteThreadsForProjectCard(pProjectId, pCardNo)
        SaveCardThreads(pDgv, pProjectId, pCardNo)
        LoadCardThreadList(pDgv, pProjectId, pCardNo, pBaseName)
    End Sub
    Public Function SelectProjectInList(ByRef pDgv As DataGridView, pColName As String, pProjectId As Integer) As Integer
        Dim _index As Integer = 0
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells(pColName).Value = pProjectId Then
                orow.Selected = True
                pDgv.FirstDisplayedScrollingRowIndex = orow.Index
                _index = orow.Index
                Exit For
            End If
        Next
        Return _index
    End Function
End Module
