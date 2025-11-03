' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmProjectThreads
#Region "properties"
    Private _selectedProject As Project
    Private _usedThreads As List(Of Integer)
    Private _usedBeads As List(Of Integer)
    Public Property UsedBeads() As List(Of Integer)
        Get
            Return _usedBeads
        End Get
        Set(ByVal value As List(Of Integer))
            _usedBeads = value
        End Set
    End Property
    Public Property UsedThreads() As List(Of Integer)
        Get
            Return _usedThreads
        End Get
        Set(ByVal value As List(Of Integer))
            _usedThreads = value
        End Set
    End Property
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
    Private isShowStock As Boolean
#End Region
#Region "handlers"
    Private Sub FrmProjectThreads_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Project threads", MyBase.Name)
        isShowStock = ChkShowStock.Checked
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
                _selectedProject = FindProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
                UsedThreads = FindUsedThreadsForProject(_selectedProject.ProjectId, True)
                UsedBeads = FindUsedBeadsForProject(_selectedProject.ProjectId, True)
                PnlThreads.Visible = True
                PnlBeads.Visible = True
            Else
                _selectedProject = ProjectBuilder.AProject.StartingWithNothing.Build
                PnlThreads.Visible = False
                PnlBeads.Visible = False
            End If
            LoadThreadList()
            LoadBeadList()
        End If
    End Sub

    Private Sub SelectProjectThreads()
        If _selectedProject IsNot Nothing AndAlso _selectedProject.ProjectId > 0 Then
            Dim oSelectedThreads As List(Of Thread) = FindThreadsForProject(_selectedProject.ProjectId)
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
        Try
            FillPaletteList(CbPalettes)
        Catch ex As Exception
            LogUtil.ShowException(ex, ex.Message, LblStatus, "FillPaletteList")
        End Try
        ChkShowStock.Checked = My.Settings.isShowStockLevels
        isLoading = False
        If _selectedProject IsNot Nothing AndAlso _selectedProject.ProjectId > 0 Then
            PnlThreads.Visible = True
            SelectProjectInList(DgvProjects, _selectedProject.ProjectId)
        End If
    End Sub

    Private Sub CheckThreadInList(pThread As Thread)
        Dim _rowNo As Integer = DgvThreads.SelectedRows(0).Index - DgvThreads.FirstDisplayedCell.RowIndex
        SelectItemInList(DgvThreads, threadId.Name, pThread.ThreadId, _rowNo)
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

    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load ProjectThread list", MyBase.Name)
        Dim _paletteThreadList As List(Of Thread) = FindThreadsForProject(_selectedProject.ProjectId)
        Dim _threads As List(Of Thread) = FindThreads()
        Dim _unselectedThreads As New List(Of Thread)
        For Each oThread As Thread In _threads
            If Not _paletteThreadList.Exists(Function(aThread As Thread) aThread.ThreadId = oThread.ThreadId) Then
                _unselectedThreads.Add(oThread)
            End If
        Next
        DgvThreads.Rows.Clear()
        _paletteThreadList.Sort(Function(x As Thread, y As Thread) x.SortNumber.CompareTo(y.SortNumber))
        _unselectedThreads.Sort(Function(x As Thread, y As Thread) x.SortNumber.CompareTo(y.SortNumber))
        For Each oThread As Thread In _paletteThreadList
            Dim _isUsedThread As Boolean = UsedThreads.Exists(Function(p) p = oThread.ThreadId)
            Dim _index = AddProjectThreadRow(DgvThreads, oThread, True, isShowStock, _isUsedThread)
            '       DgvThreads.Rows(_index).Cells(threadselected.Name).Value = True
        Next
        For Each oThread As Thread In _unselectedThreads
            Dim _index = AddProjectThreadRow(DgvThreads, oThread, False, isShowStock, False)
            '       DgvThreads.Rows(_index).Cells(threadselected.Name).Value = False
        Next
        DgvThreads.ClearSelection()
    End Sub
    Private Sub LoadBeadList()
        LogUtil.LogInfo("Load ProjectBead list", MyBase.Name)
        Dim _paletteBeadList As List(Of Bead) = FindBeadsForProject(_selectedProject.ProjectId)
        Dim _Beads As List(Of Bead) = FindBeads()
        Dim _unselectedBeads As New List(Of Bead)
        For Each oBead As Bead In _Beads
            If Not _paletteBeadList.Exists(Function(aBead As Bead) aBead.BeadId = oBead.BeadId) Then
                _unselectedBeads.Add(oBead)
            End If
        Next
        DgvBeads.Rows.Clear()
        _paletteBeadList.Sort(Function(x As Bead, y As Bead) x.SortNumber.CompareTo(y.SortNumber))
        _unselectedBeads.Sort(Function(x As Bead, y As Bead) x.SortNumber.CompareTo(y.SortNumber))
        For Each oBead As Bead In _paletteBeadList
            Dim _isUsedBead As Boolean = UsedBeads.Exists(Function(p) p = oBead.BeadId)
            Dim _index = AddProjectBeadRow(DgvBeads, oBead, True, isShowStock, _isUsedBead)
            '       DgvBeads.Rows(_index).Cells(Beadselected.Name).Value = True
        Next
        For Each oBead As Bead In _unselectedBeads
            Dim _index = AddProjectBeadRow(DgvBeads, oBead, False, isShowStock, False)
            '       DgvBeads.Rows(_index).Cells(Beadselected.Name).Value = False
        Next
        DgvBeads.ClearSelection()
    End Sub
    Private Sub AddProjectRow(oProject As Project)
        Dim oRow As DataGridViewRow = DgvProjects.Rows(DgvProjects.Rows.Add())
        oRow.Cells(projectId.Name).Value = oProject.ProjectId
        oRow.Cells(projectName.Name).Value = oProject.ProjectName
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        SetAllThreadSelections(False)
    End Sub
    Private Sub SetAllThreadSelections(pIsSelected As Boolean)
        For Each oRow As DataGridViewRow In DgvThreads.Rows
            Dim _ChkCell As DataGridViewCheckBoxCell = oRow.Cells(threadselected.Name)
            _ChkCell.Value = pIsSelected
        Next
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        LogUtil.ShowStatus("Updating Project Threads", LblStatus, True, MyBase.Name, False)
        If _selectedProject Is Nothing OrElse Not _selectedProject.IsLoaded Then
            LogUtil.ShowStatus("No project selected", LblStatus, False, MyBase.Name, True)
        Else
            UpdateThreadList()
            UpdateBeadList
            LoadThreadList()
            LoadBeadList()
        End If
    End Sub

    Private Sub UpdateThreadList()
        Dim _usedThreadsBefore As List(Of Thread) = FindThreadsForProject(_selectedProject.ProjectId)
        Dim _usedThreadsAfter As New List(Of Thread)
        For Each oRow As DataGridViewRow In DgvThreads.Rows
            Dim _ChkCell As DataGridViewCheckBoxCell = oRow.Cells(threadselected.Name)
            If _ChkCell.Value = True Then
                Dim _thread As Thread = FindThreadById(oRow.Cells(threadId.Name).Value)
                _usedThreadsAfter.Add(_thread)
            End If
        Next
        For Each oThread As Thread In _usedThreadsAfter
            If Not _usedThreadsBefore.Exists(Function(aThread As Thread) aThread.ThreadId = oThread.ThreadId) Then
                Dim _projectThread As ProjectThread = ProjectThreadBuilder _
                                                            .AProjectThread _
                                                            .StartingWithNothing _
                                                            .WithProjectId(_selectedProject.ProjectId) _
                                                            .WithThreadId(oThread.ThreadId) _
                                                            .Build
                AddNewProjectThread(_projectThread)
            End If
        Next
        For Each oThread As Thread In _usedThreadsBefore
            If Not _usedThreadsAfter.Exists(Function(aThread As Thread) aThread.ThreadId = oThread.ThreadId) Then
                Dim _isUsed As Boolean = False
                For Each _threadId As Integer In UsedThreads
                    If _threadId = oThread.ThreadId Then
                        _isUsed = True
                        Exit For
                    End If
                Next
                If _isUsed Then
                    MsgBox("Thread [" & oThread.ColourName & "] to be removed is used in the design. No action.", MsgBoxStyle.Information, "Used thread")
                Else
                    Dim _projectThread As ProjectThread = ProjectThreadBuilder _
                                                                .AProjectThread _
                                                                .StartingWithNothing _
                                                                .WithProjectId(_selectedProject.ProjectId) _
                                                                .WithThreadId(oThread.ThreadId) _
                                                                .Build
                    RemoveProjectThread(_projectThread)
                End If
            End If
        Next
    End Sub
    Private Sub UpdateBeadList()
        Dim _usedBeadsBefore As List(Of Bead) = FindBeadsForProject(_selectedProject.ProjectId)
        Dim _usedBeadsAfter As New List(Of Bead)
        For Each oRow As DataGridViewRow In DgvBeads.Rows
            Dim _ChkCell As DataGridViewCheckBoxCell = oRow.Cells(beadSelected.Name)
            If _ChkCell.Value = True Then
                Dim _Bead As Bead = FindBeadById(oRow.Cells(BeadId.Name).Value)
                _usedBeadsAfter.Add(_Bead)
            End If
        Next
        For Each oBead As Bead In _usedBeadsAfter
            If Not _usedBeadsBefore.Exists(Function(aBead As Bead) aBead.BeadId = oBead.BeadId) Then
                Dim _projectBead As ProjectBead = ProjectBeadBuilder _
                                                            .AProjectBead _
                                                            .StartingWithNothing _
                                                            .WithProjectId(_selectedProject.ProjectId) _
                                                            .WithBeadId(oBead.BeadId) _
                                                            .Build
                AddNewProjectBead(_projectBead)
            End If
        Next
        For Each oBead As Bead In _usedBeadsBefore
            If Not _usedBeadsAfter.Exists(Function(aBead As Bead) aBead.BeadId = oBead.BeadId) Then
                Dim _isUsed As Boolean = False
                For Each _BeadId As Integer In UsedBeads
                    If _BeadId = oBead.BeadId Then
                        _isUsed = True
                        Exit For
                    End If
                Next
                If _isUsed Then
                    MsgBox("Bead [" & oBead.ColourName & "] to be removed is used in the design. No action.", MsgBoxStyle.Information, "Used Bead")
                Else
                    Dim _projectBead As ProjectBead = ProjectBeadBuilder _
                                                                .AProjectBead _
                                                                .StartingWithNothing _
                                                                .WithProjectId(_selectedProject.ProjectId) _
                                                                .WithBeadId(oBead.BeadId) _
                                                                .Build
                    RemoveProjectBead(_projectBead)
                End If
            End If
        Next
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

    'Private Sub BtnAddThreads_Click(sender As Object, e As EventArgs) Handles BtnAddThreads.Click
    '    LogUtil.Info("Opening Threads form", MyBase.Name)
    '    Using _threads As New FrmThread
    '        _threads.ShowDialog()
    '    End Using
    'End Sub

    Private Sub TxtNumber_TextChanged(sender As Object, e As EventArgs) Handles TxtNumber.TextChanged
        If Not String.IsNullOrWhiteSpace(TxtNumber.Text) Then
            SelectThreadInList(DgvThreads, ThreadNo.Name, TxtNumber.Text)
        End If
    End Sub

    Private Sub ChkShowStock_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowStock.CheckedChanged
        isShowStock = ChkShowStock.Checked
        If Not isLoading Then
            LoadThreadList()
            LoadBeadList()
        End If
    End Sub

    Private Sub BtnPaletteList_Click(sender As Object, e As EventArgs) Handles BtnPaletteList.Click
        Dim _threadText As New StringBuilder
        Dim _threadList As List(Of Thread) = FindThreadsForProject(_selectedProject.ProjectId)
        _threadList.Sort(Function(x As Thread, y As Thread) x.SortNumber.CompareTo(y.SortNumber))
        For Each oThread As Thread In _threadList
            _threadText.Append(oThread.ThreadNo).Append(",")
        Next
        TxtPaletteList.Text = _threadText.ToString.Trim(",")
    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        If Not String.IsNullOrEmpty(TxtPaletteList.Text) Then
            My.Computer.Clipboard.SetText(TxtPaletteList.Text)
        Else
            My.Computer.Clipboard.Clear()
        End If
    End Sub

    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        TxtPaletteList.Text = My.Computer.Clipboard.GetText()
    End Sub

    Private Sub BtnSelAll_Click(sender As Object, e As EventArgs) Handles BtnSelAll.Click
        SetAllThreadSelections(True)
    End Sub

    Private Sub BtnLoadThreadList_Click(sender As Object, e As EventArgs) Handles BtnLoadThreadList.Click
        Dim _importThreads As List(Of Thread) = CreateListOfThreadsFromThreadList()
    End Sub

    Private Function CreateListOfThreadsFromThreadList() As List(Of Thread)
        Dim _threads As New List(Of Thread)
        Dim _numberList As String() = TxtPaletteList.Text.Split(",")
        For Each _number As String In _numberList
            SelectThreadInTable(DgvThreads, _number)
        Next
        Return _threads
    End Function
    Private Sub SelectThreadInTable(pDgv As DataGridView, pThreadNo As String)
        Dim _isFound As Boolean = False
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells(ThreadNo.Name).Value = pThreadNo Then
                _isFound = True
                orow.Cells(threadselected.Name).Value = True
            End If
        Next
        If Not _isFound Then
            MsgBox("Bead " & pThreadNo & " not found", MsgBoxStyle.Information, "Missing thread")
        End If
    End Sub

    Private Sub BtnAssignSymbols_Click(sender As Object, e As EventArgs) Handles BtnAssignSymbols.Click
        Using _symbols As New FrmThreadSymbols
            _symbols.SelectedProject = _selectedProject
            _symbols.ShowDialog()
        End Using
    End Sub

    Private Sub BtnLoadPalette_Click(sender As Object, e As EventArgs) Handles BtnLoadPalette.Click
        If CbPalettes.SelectedIndex >= 0 Then
            Dim _threads As List(Of PaletteThread) = FindPaletteThreadsByPaletteId(CbPalettes.SelectedValue)
            If _threads IsNot Nothing AndAlso _threads.Count > 0 Then
                SetAllThreadSelections(False)
                For Each oThread As PaletteThread In _threads
                    SelectThreadInTable(DgvThreads, oThread.Thread.ThreadNo)
                Next
            Else
                LogUtil.ShowStatus("No threads in palette", LblStatus, True)
            End If
        Else
            LogUtil.ShowStatus("No palette selected", LblStatus, True)
        End If
    End Sub

#End Region

End Class