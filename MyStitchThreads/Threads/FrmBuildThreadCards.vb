' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmBuildThreadCards
    Private isLoading As Boolean
    Private oSelectedProject As Project
    Private oSelectedCardNo As Integer = -1
    Private oNextCardNo As Integer
    Private oCardList As New List(Of ProjectThreadCard)
    Private isCardsLoading As Boolean
    Private _selectedProject As Project
    Public Property SelectedProject() As Project
        Get
            Return _selectedProject
        End Get
        Set(ByVal value As Project)
            _selectedProject = value
        End Set
    End Property
    Private Sub FrmBuildThreadCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Thread maintenence", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
        If _selectedProject IsNot Nothing AndAlso SelectedProject.IsLoaded Then
            SelectProjectInList(DgvProjects, projectId.Name, _selectedProject.ProjectId)
        End If
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
        PnlCardThreads.Visible = False
        oSelectedCardNo = -1
        oNextCardNo = 1
        If Not isLoading Then
            If DgvProjects.SelectedRows.Count = 1 Then
                oSelectedProject = GetProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
                PnlThreads.Visible = True
                oNextCardNo = LoadCardList(oSelectedProject.ProjectId, LbCards, MyBase.Name) + 1
            Else
                oSelectedProject = ProjectBuilder.AProject.StartingWithNothing.Build
                PnlThreads.Visible = False
            End If
            LoadProjectThreadList(DgvThreads, oSelectedProject.ProjectId, MyBase.Name)
        End If
    End Sub

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
            LblCardNo.Text = CStr(oSelectedCardNo)
            LoadCardThreadList(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)
            PnlCardThreads.Visible = True
        Else
            LblCardNo.Text = String.Empty
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
            oNextCardNo = LoadCardList(oSelectedProject.ProjectId, LbCards, MyBase.Name) + 1
            oSelectedCardNo = -1
        End If
    End Sub

    Private Sub WriteProjectThreadCard(pSelectedProject As Project, pNextCardNo As Integer, pCardThreadList As List(Of ProjectThread))
        Dim _newProjectCard As ProjectThreadCard = ProjectThreadCardBuilder.AProjectThreadCard.StartingWithNothing _
            .WithProject(pSelectedProject) _
            .WithCardNo(pNextCardNo) _
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

        UpdateProjectThreadCard(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)

    End Sub

    Private Sub BtnRemoveThread_Click(sender As Object, e As EventArgs) Handles BtnRemoveThread.Click
        If DgvCardThreads.SelectedRows.Count > 0 Then
            Dim oRow As DataGridViewRow = DgvCardThreads.SelectedRows(0)
            DgvCardThreads.Rows.Remove(oRow)
            UpdateProjectThreadCard(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)

        End If
    End Sub

    Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles BtnUp.Click
        If DgvCardThreads.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvCardThreads.SelectedRows(0)
            If oRow.Index > 0 Then
                Dim _newRow As DataGridViewRow = oRow.Clone
                For Each _col As DataGridViewColumn In DgvCardThreads.Columns
                    _newRow.Cells(_col.Index).Value = oRow.Cells(_col.Index).Value
                Next
                DgvCardThreads.Rows.Insert(oRow.Index - 1, _newRow)
                DgvCardThreads.Rows.Remove(oRow)
                DgvCardThreads.ClearSelection()
                UpdateProjectThreadCard(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)
                SelectCardThreadInList(_newRow)
            End If
        End If
    End Sub

    Private Sub SelectCardThreadInList(_newRow As DataGridViewRow)
        For Each _row As DataGridViewRow In DgvCardThreads.Rows
            Dim _colindex As Integer = cardthreadid.Index
            If _row.Cells(_colindex).Value = _newRow.Cells(_colindex).Value Then
                _row.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles BtnDown.Click
        If DgvCardThreads.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvCardThreads.SelectedRows(0)
            If oRow.Index < DgvCardThreads.Rows(DgvCardThreads.Rows.Count - 1).Index Then
                Dim _newRow As DataGridViewRow = oRow.Clone
                For Each _col As DataGridViewColumn In DgvCardThreads.Columns
                    _newRow.Cells(_col.Index).Value = oRow.Cells(_col.Index).Value
                Next
                DgvCardThreads.Rows.Insert(oRow.Index + 2, _newRow)
                DgvCardThreads.Rows.Remove(oRow)
                DgvCardThreads.ClearSelection()
                UpdateProjectThreadCard(DgvCardThreads, oSelectedProject.ProjectId, oSelectedCardNo, MyBase.Name)
                SelectCardThreadInList(_newRow)

            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If oSelectedProject IsNot Nothing AndAlso oSelectedProject.IsLoaded Then
            WriteProjectThreadCard(oSelectedProject, oNextCardNo, New List(Of ProjectThread))
            LblCardNo.Text = CStr(oNextCardNo)
            oNextCardNo += 1
            LoadCardList(oSelectedProject.ProjectId, LbCards, MyBase.Name)
            DgvCardThreads.Rows.Clear()
            oSelectedCardNo = -1
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If oSelectedProject IsNot Nothing AndAlso oSelectedProject.IsLoaded Then
            If oSelectedCardNo > 0 Then
                DeleteThreadsForProjectCard(oSelectedProject.ProjectId, oSelectedCardNo)
                DeleteProjectThreadCard(oSelectedProject.ProjectId, oSelectedCardNo)
                PnlCardThreads.Visible = False
                LblCardNo.Text = String.Empty
                LoadCardList(oSelectedProject.ProjectId, LbCards, MyBase.Name)
            End If
        End If
    End Sub

End Class