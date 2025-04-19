' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmProjectThreads
#Region "properties"
    Private _selectedProject As Project
    Public Property SelectedProject() As Project
        Get
            Return _selectedProject
        End Get
        Set(ByVal value As Project)
            _selectedProject = value
        End Set
    End Property
#End Region
#Region "constants"
#End Region
#Region "variables"
    Private isLoading As Boolean

#End Region
#Region "handlers"
    Private Sub FrmProjectThreads_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Project threads", MyBase.Name)

        InitialiseForm()

    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.ProjectThreadsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub DgvProjects_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        If Not isLoading Then
            If DgvProjects.SelectedRows.Count = 1 Then
                _selectedProject = GetProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
                PnlThreads.Visible = True
            Else
                _selectedProject = ProjectBuilder.AProject.StartingWithNothing.Build
                PnlThreads.Visible = False
            End If
            LoadThreadList()
        End If
    End Sub

    Private Sub SelectProjectThreads()
        If _selectedProject IsNot Nothing AndAlso _selectedProject.ProjectId > 0 Then
            Dim oSelectedThreads As List(Of Thread) = GetProjectThreads(_selectedProject.ProjectId)
            For Each _thread As Thread In oSelectedThreads
                CheckThreadInList(_thread)
            Next
        End If
    End Sub

#End Region
#Region "functions"
    Private Sub InitialiseForm()
        isLoading = True
        GetFormPos(Me, My.Settings.ProjectThreadsFormPos)
        PnlThreads.Visible = False
        LoadProjectList(DgvProjects, MyBase.Name)
        DgvProjects.ClearSelection()
        isLoading = False
        If _selectedProject IsNot Nothing AndAlso _selectedProject.ProjectId > 0 Then
            PnlThreads.Visible = True
            SelectProjectInList()
        End If
    End Sub

    Private Sub SelectProjectInList()
        For Each orow As DataGridViewRow In DgvProjects.Rows
            If orow.Cells(projectId.Name).Value = _selectedProject.ProjectId Then
                orow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Private Sub CheckThreadInList(pThread As Thread)
        Dim _rowNo As Integer = DgvThreads.SelectedRows(0).Index - DgvThreads.FirstDisplayedCell.RowIndex
        SelectThreadInList(DgvThreads, threadId.Name, pThread.ThreadId, _rowNo)
        For Each orow As DataGridViewRow In DgvThreads.Rows
            If orow.Cells(threadId.Name).Value = pThread.ThreadId Then
                Dim _chkCell As DataGridViewCheckBoxCell = orow.Cells(threadselected.Name)
                _chkCell.Value = True
                Exit For
            End If
        Next
    End Sub
    Private Sub ClearProjectForm()
        DgvProjects.ClearSelection()

    End Sub

    'Private Sub LoadProjectList()
    '    LogUtil.LogInfo("Load project list", MyBase.Name)
    '    DgvProjects.Rows.Clear()
    '    For Each oproject As Project In GetProjects()
    '        AddProjectRow(oproject)
    '    Next
    '    DgvProjects.ClearSelection()
    'End Sub
    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load Thread list", MyBase.Name)
        Dim _usedThreadList As List(Of Thread) = GetProjectThreads(_selectedProject.ProjectId)
        Dim _threads As List(Of Thread) = GetThreads()
        Dim _unusedThreads As New List(Of Thread)
        For Each oThread As Thread In _threads
            If Not _usedThreadList.Exists(Function(aThread As Thread) aThread.ThreadId = oThread.ThreadId) Then
                _unusedThreads.Add(oThread)
            End If
        Next
        DgvThreads.Rows.Clear()
        _usedThreadList.Sort(Function(x As Thread, y As Thread) x.SortNumber.CompareTo(y.SortNumber))
        _unusedThreads.Sort(Function(x As Thread, y As Thread) x.SortNumber.CompareTo(y.SortNumber))
        For Each oThread As Thread In _usedThreadList
            Dim _index = AddThreadRow(DgvThreads, oThread)
            DgvThreads.Rows(_index).Cells(threadselected.Name).Value = True
        Next
        For Each oThread As Thread In _unusedThreads
            Dim _index = AddThreadRow(DgvThreads, oThread)
            DgvThreads.Rows(_index).Cells(threadselected.Name).Value = False
        Next
        DgvThreads.ClearSelection()
    End Sub
    'Private Sub LoadColourCell(oThread As Thread, oRow As DataGridViewRow)
    '    Dim _imageCell As DataGridViewImageCell = oRow.Cells(threadColour.Name)
    '    Dim _cellHeight As Integer = oRow.Height
    '    Dim _cellWidth As Integer = DgvThreads.Columns(oRow.Cells(threadColour.Name).ColumnIndex).Width
    '    Dim _image As New Bitmap(_cellWidth, _cellHeight)
    '    For x = 0 To _cellWidth - 1
    '        For y = 0 To _cellHeight - 1
    '            _image.SetPixel(x, y, oThread.Colour)
    '        Next
    '    Next
    '    _imageCell.Value = _image
    'End Sub

    Private Sub SelectProjectInList(_projectId As Integer)
        For Each orow As DataGridViewRow In DgvProjects.Rows
            If orow.Cells(projectId.Name).Value = _projectId Then
                orow.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub AddProjectRow(oProject As Project)
        Dim oRow As DataGridViewRow = DgvProjects.Rows(DgvProjects.Rows.Add())
        oRow.Cells(projectId.Name).Value = oProject.ProjectId
        oRow.Cells(projectName.Name).Value = oProject.ProjectName
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearThreadSelections()
    End Sub
    Private Sub ClearThreadSelections()
        For Each oRow As DataGridViewRow In DgvThreads.Rows
            Dim _ChkCell As DataGridViewCheckBoxCell = oRow.Cells(threadselected.Name)
            _ChkCell.Value = False
        Next
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        LogUtil.ShowStatus("Updating Project Threads", LblStatus, True, MyBase.Name, False)
        If _selectedProject Is Nothing OrElse Not _selectedProject.IsLoaded Then
            LogUtil.ShowStatus("No project selected", LblStatus, False, MyBase.Name, True)
        Else
            Dim _usedThreadsBefore As List(Of Thread) = GetProjectThreads(_selectedProject.ProjectId)
            Dim _usedThreadsAfter As New List(Of Thread)
            For Each oRow As DataGridViewRow In DgvThreads.Rows
                Dim _ChkCell As DataGridViewCheckBoxCell = oRow.Cells(threadselected.Name)
                If _ChkCell.Value = True Then
                    Dim _thread As Thread = GetThreadById(oRow.Cells(threadId.Name).Value)
                    _usedThreadsAfter.Add(_thread)
                End If
            Next
            For Each oThread As Thread In _usedThreadsAfter
                If Not _usedThreadsBefore.Exists(Function(aThread As Thread) aThread.ThreadId = oThread.ThreadId) Then
                    Dim _projectThread As ProjectThread = ProjectThreadBuilder _
                                                                .AProjectThread _
                                                                .StartingWithNothing _
                                                                .WithProject(_selectedProject) _
                                                                .WithThread(oThread) _
                                                                .Build
                    InsertProjectThread(_projectThread)
                End If
            Next
            For Each oThread As Thread In _usedThreadsBefore
                If Not _usedThreadsAfter.Exists(Function(aThread As Thread) aThread.ThreadId = oThread.ThreadId) Then
                    Dim _projectThread As ProjectThread = ProjectThreadBuilder _
                                                                .AProjectThread _
                                                                .StartingWithNothing _
                                                                .WithProject(_selectedProject) _
                                                                .WithThread(oThread) _
                                                                .Build
                    DeleteProjectThread(_projectThread)
                End If
            Next
            LoadThreadList()
        End If
    End Sub

    Private Sub BtnGenerateCards_Click(sender As Object, e As EventArgs) Handles BtnGenerateCards.Click
        If _selectedProject Is Nothing OrElse Not _selectedProject.IsLoaded Then
            LogUtil.ShowStatus("No project selected", LblStatus, False, MyBase.Name, True)
        Else
            Using _print As New FrmBuildThreadCards
                LogUtil.Info("Opening Build Cards Form", MyBase.Name)
                _print.SelectedProject = _selectedProject
                _print.ShowDialog()
            End Using
            LoadThreadList()
        End If
    End Sub

    Private Sub BtnAddThreads_Click(sender As Object, e As EventArgs) Handles BtnAddThreads.Click
        LogUtil.Info("Opening Threads form", MyBase.Name)
        Using _threads As New FrmThread
            _threads.ShowDialog()
        End Using
    End Sub

    Private Sub TxtNumber_TextChanged(sender As Object, e As EventArgs) Handles TxtNumber.TextChanged
        If Not String.IsNullOrWhiteSpace(TxtNumber.Text) Then
            SelectThreadInList(DgvThreads, ThreadNo.Name, TxtNumber.Text)
        End If
    End Sub

#End Region

End Class