' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Imports HindlewareLib.Logging

Public Class FrmBuildThreadCards
    Private isLoading As Boolean
    Private oSelectedProject As Project
    Private oSelectedCardNo As Integer = -1
    Private oNextCardNo As Integer
    Private oCardList As New List(Of ProjectThreadCard)
    Private isCardsLoading As Boolean

    Private Sub FrmBuildThreadCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Thread maintenence", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmBuildThreadCards_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)

        My.Settings.BuildCardsFormPos = SetFormPos(Me)
        My.Settings.Save()

    End Sub
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.BuildCardsFormPos)
        LoadProjectList(DgvProjects, MyBase.Name)
        PnlThreads.Visible = False
        PnlCardThreads.Visible = False
    End Sub

    Private Sub DgvProjects_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        LbCards.Items.Clear()
        DgvCardThreads.Rows.Clear()
        DgvThreads.Rows.Clear()
        oNextCardNo = 1
        If Not isLoading Then
            If DgvProjects.SelectedRows.Count = 1 Then
                oSelectedProject = GetProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
                PnlThreads.Visible = True
                LoadCardList(oSelectedProject.ProjectId)
            Else
                oSelectedProject = ProjectBuilder.AProject.StartingWithNothing.Build
                PnlThreads.Visible = False
            End If
            LoadProjectThreadList(DgvThreads, oSelectedProject.ProjectId, MyBase.Name)
        End If
    End Sub
    Private Sub LoadCardList(pProjectId As Integer)
        LogUtil.LogInfo("Load card list", MyBase.Name)
        oNextCardNo = 1
        isCardsLoading = True
        LbCards.Items.Clear()
        DgvCardThreads.Rows.Clear()
        Dim _list As List(Of ProjectThreadCard) = GetProjectThreadCards(pProjectId)
        For Each oProjectCard As ProjectThreadCard In _list
            LbCards.Items.Add(oProjectCard.CardNo)
        Next
        If _list.Count > 0 Then
            oNextCardNo = _list.Last.CardNo + 1
        End If
        isCardsLoading = False
    End Sub
    'Private Sub LoadThreadList()
    '    LogUtil.LogInfo("Load Thread list", MyBase.Name)
    '    Dim _threadList As List(Of Thread) = GetProjectThreads(oSelectedProject.ProjectId)
    '    DgvThreads.Rows.Clear()
    '    For Each oThread As Thread In _threadList
    '        AddThreadRow(oThread, False)
    '    Next
    '    DgvThreads.Sort(DgvThreads.Columns(ThreadNo.Name), ListSortDirection.Ascending)
    '    DgvThreads.ClearSelection()
    'End Sub
    Private Sub AddThreadRow(oThread As Thread, isUsed As Boolean)
        Dim oRow As DataGridViewRow = DgvThreads.Rows(DgvThreads.Rows.Add())
        oRow.Cells(threadId.Name).Value = oThread.ThreadId
        oRow.Cells(threadName.Name).Value = oThread.ColourName
        LoadColourCell(oThread, DgvThreads, oRow, threadColour.Name)
        oRow.Cells(ThreadNo.Name).Value = If(IsNumeric(oThread.ThreadNo), CInt(oThread.ThreadNo), CInt("999" & oThread.ThreadId))
        oRow.Cells(threadselected.Name).Value = isUsed
    End Sub
    Private Sub LoadColourCell(oThread As Thread, ByRef oDgv As DataGridView, oRow As DataGridViewRow, oCellName As String)
        Dim _imageCell As DataGridViewImageCell = oRow.Cells(oCellName)
        Dim _cellHeight As Integer = oRow.Height
        Dim _cellWidth As Integer = oDgv.Columns(oRow.Cells(oCellName).ColumnIndex).Width
        Dim _image As New Bitmap(_cellWidth, _cellHeight)
        For x = 0 To _cellWidth - 1
            For y = 0 To _cellHeight - 1
                _image.SetPixel(x, y, oThread.Colour)
            Next
        Next
        _imageCell.Value = _image
    End Sub

    Private Sub LbCards_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LbCards.SelectedIndexChanged
        DgvCardThreads.Rows.Clear()
        oSelectedCardNo = -1
        If LbCards.SelectedIndex > -1 Then
            oSelectedCardNo = CInt(LbCards.SelectedItem)
            LoadCardThreadList(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)
            PnlCardThreads.Visible = True
        Else
            PnlCardThreads.Visible = False
        End If
    End Sub

    'Private Sub LoadCardThreadList(pThreadList As List(Of Thread))
    '    DgvCardThreads.Rows.Clear()
    '    For Each oThread As Thread In pThreadList
    '        AddCardThreadRow(DgvCardThreads, oThread)

    '    Next

    '    DgvCardThreads.ClearSelection()
    'End Sub


    Private Sub BtnAuto_Click(sender As Object, e As EventArgs) Handles BtnAuto.Click
        Dim _resp As MsgBoxResult = MsgBox("Replace existing cards?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Overwrite")
        If Not _resp = MsgBoxResult.Cancel Then
            Dim isRemoveExisting As Boolean = _resp = MsgBoxResult.Yes
            If isRemoveExisting Then
                RemoveExistingProjectCards(oSelectedProject.ProjectId)
                oNextCardNo = 1
            End If
            Dim oCardThreadList As New List(Of ProjectThread)
            Dim _totalThreadCount As Integer = DgvThreads.Rows.Count
            Dim _newCardCt As Integer = Math.Ceiling(_totalThreadCount / 10)
            NudMaxThreads.Value = Math.Ceiling(_totalThreadCount / _newCardCt)
            For Each oRow As DataGridViewRow In DgvThreads.Rows
                Dim _threadId As Integer = oRow.Cells(threadId.Name).Value
                Dim _projectThread As ProjectThread = ProjectThreadBuilder.AProjectThread.StartingWithNothing _
                    .WithProject(oSelectedProject) _
                    .WithThreadId(_threadId) _
                    .Build
                oCardThreadList.Add(_projectThread)
                If oCardThreadList.Count = NudMaxThreads.Value Then
                    WriteProjectThreadCard(oSelectedProject, oNextCardNo, oCardThreadList)
                    oNextCardNo += 1
                    oCardThreadList.Clear()
                    End If
                Next
            If oCardThreadList.Count > 0 Then
                WriteProjectThreadCard(oSelectedProject, oNextCardNo, oCardThreadList)
            End If
            LoadCardList(oSelectedProject.ProjectId)
        End If
    End Sub

    Private Sub WriteProjectThreadCard(pSelectedProject As Project, pNextCardNo As Integer, pCardThreadList As List(Of ProjectThread))
        Dim _newProjectCard As ProjectThreadCard = ProjectThreadCardBuilder.AProjectThreadCard.StartingWithNothing _
            .WithProject(pSelectedProject) _
            .WithCardNo(pNextCardNo) _
            .WithThreadList(pCardThreadList) _
            .Build
        InsertProjectThreadCard(_newProjectCard)
        Dim _seq As Integer = 1
        For Each _projectThread As ProjectThread In pCardThreadList
            _projectThread.CardNo = pNextCardNo
            _projectThread.CardSeq = _seq
            InsertProjectCardThread(_projectThread)
            _seq += 1
        Next
    End Sub

    Private Sub BtnAddThread_Click(sender As Object, e As EventArgs) Handles BtnAddThread.Click
        For Each oRow As DataGridViewRow In DgvThreads.Rows
            Dim _cell As DataGridViewCheckBoxCell = oRow.Cells(threadselected.Name)
            If _cell.Value = True Then
                Dim oThread As ProjectCardThread = ProjectCardThreadBuilder.AProjectCardThread.StartingWithNothing _
                    .WithProject(oSelectedProject) _
                    .WithThreadId(oRow.Cells(threadId.Name).Value) _
                    .WithCardNo(oSelectedCardNo) _
                    .Build

                AddCardThreadRow(DgvCardThreads, oThread)
                _cell.Value = False
            End If
        Next
        DeleteThreadsForProjectCard(oSelectedProject.ProjectId, oSelectedCardNo)
        SaveCardThreads(DgvCardThreads)
        LoadCardThreadList(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)


    End Sub

    Private Sub BtnRemoveThread_Click(sender As Object, e As EventArgs) Handles BtnRemoveThread.Click
        Dim oRow As DataGridViewRow = DgvCardThreads.SelectedRows(0)
        DgvCardThreads.Rows.Remove(oRow)
        DeleteThreadsForProjectCard(oSelectedProject.ProjectId, oSelectedCardNo)
        SaveCardThreads(DgvCardThreads)
        LoadCardThreadList(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)
    End Sub
    Private Sub SaveCardThreads(pDgv As DataGridView)
        Dim _seq As Integer = 1
        For Each oRow As DataGridViewRow In pDgv.Rows
            Dim _cardThread As ProjectCardThread = ProjectCardThreadBuilder.AProjectCardThread.StartingWithNothing _
                .WithProject(oSelectedProject) _
                .WithThreadId(oRow.Cells(cardthreadid.Name).Value) _
                .WithCardNo(oSelectedCardNo) _
                .WithCardseq(_seq) _
                .Build
            InsertProjectCardThread(_cardThread)
            _seq += 1
        Next
    End Sub


    Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles BtnUp.Click

    End Sub

    Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles BtnDown.Click

    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click

    End Sub

    Private Sub BtnClearCardThreads_Click(sender As Object, e As EventArgs) Handles BtnClearCardThreads.Click

    End Sub
End Class