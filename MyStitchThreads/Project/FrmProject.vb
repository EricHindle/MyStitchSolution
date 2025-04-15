' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmProject
#Region "properties"

#End Region
#Region "constants"
#End Region
#Region "variables"
    Private _selectedProject As New Project
    Private isLoading As Boolean

#End Region
#Region "handlers"
    Private Sub FrmProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Project maintenence", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)

        My.Settings.ProjectFormPos = SetFormPos(Me)
        My.Settings.Save()

    End Sub

    Private Sub DgvBooks_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        If Not isLoading Then
            If DgvProjects.SelectedRows.Count = 1 Then
                _selectedProject = GetProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
            Else
                _selectedProject = ProjectBuilder.AProject.StartingWithNothing.Build
            End If
            LoadProjectForm(_selectedProject)
        End If
        Debug.Print(DgvProjects.ColumnHeadersDefaultCellStyle.BackColor.ToString)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        InsertNewProject()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        UpdateSelectedProject()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelectedProject()
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearProjectForm()
        DgvProjects.ClearSelection()
    End Sub
#End Region
#Region "functions"
    Private Sub InitialiseForm()

        GetFormPos(Me, My.Settings.ProjectFormPos)

        LoadProjectList()

    End Sub
    Private Sub ClearProjectForm()
        DgvProjects.ClearSelection()

    End Sub

    Private Sub LoadProjectForm(oProject As Project)
        _selectedProject = oProject
        LblProjectId.Text = _selectedProject.ProjectId
        LblSelectedProject.Text = _selectedProject.ProjectName
        LblProjectId.Visible = True
        TxtName.Text = oProject.ProjectName
    End Sub

    Private Sub LoadProjectList()
        LogUtil.LogInfo("Load project list", MyBase.Name)
        DgvProjects.Rows.Clear()
        For Each oproject As Project In GetProjects()
            AddProjectRow(oproject)
        Next
        DgvProjects.ClearSelection()
    End Sub
    Private Sub SelectProjectInList(_projectId As Integer)
        For Each orow As DataGridViewRow In DgvProjects.Rows
            If orow.Cells(projectId.Name).Value = _projectId Then
                orow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Private Function BuildProjectFromForm(pId As Integer) As Project
        Dim _project As Project = ProjectBuilder.AProject.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                   .Build()
        Return _project
    End Function
    Private Sub AddProjectRow(oProject As Project)
        Dim oRow As DataGridViewRow = DgvProjects.Rows(DgvProjects.Rows.Add())
        oRow.Cells(projectId.Name).Value = oProject.ProjectId
        oRow.Cells(projectName.Name).Value = oProject.ProjectName
    End Sub
    Friend Sub SaveProject()
        If _selectedProject.ProjectId >= 0 Then
            UpdateSelectedProject()
        Else
            InsertNewProject()
        End If
    End Sub
    Private Sub InsertNewProject()
        LogUtil.LogInfo("New project", MyBase.Name)
        Dim _project As Project = BuildProjectFromForm(_selectedProject.ProjectId)
        _project.ProjectId = InsertProject(_project)
        LoadProjectList()
        SelectProjectInList(_project.ProjectId)
        LogUtil.ShowStatus("project Added", LblStatus, MyBase.Name)
    End Sub
    Private Sub UpdateSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Updating project", MyBase.Name)
            Dim _project As Project = BuildProjectFromForm(_selectedProject.ProjectId)

            Updateproject(_project)
            LoadProjectList()
            SelectProjectInList(_selectedProject.ProjectId)
            LogUtil.ShowStatus("Project updated", LblStatus, MyBase.Name)

        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Friend Sub DeleteSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Delete project", MyBase.Name)

            DeleteProject(_selectedProject)
            ClearProjectForm()
            LoadProjectList()
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
#End Region

End Class