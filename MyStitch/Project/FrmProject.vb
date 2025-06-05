' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmProject
#Region "properties"

#End Region
#Region "constants"
#End Region
#Region "variables"
    Private _selectedProject As New Project
    Private isLoading As Boolean
    Private oFabricColour As List(Of Color) = {Color.White, Color.Linen, Color.AliceBlue, Color.MistyRose}.ToList
    Private oGridColour As List(Of Color) = {Color.LightGray, Color.DarkGray, Color.DimGray, Color.Black}.ToList
#End Region
#Region "handlers"
    Private Sub FrmProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialiseSettings()

        InitialiseLogging()
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
                NudDesignHeight.Enabled = False
                NudDesignWidth.Enabled = False
                NudOriginX.Enabled = False
                NudOriginY.Enabled = False
            Else
                _selectedProject = ProjectBuilder.AProject.StartingWithNothing.Build
                NudDesignHeight.Enabled = True
                NudDesignWidth.Enabled = True
                NudOriginX.Enabled = True
                NudOriginY.Enabled = True
            End If
            LoadProjectForm(_selectedProject)
        End If
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
        LoadProjectList(DgvProjects, MyBase.Name)
    End Sub
    Private Sub ClearProjectForm()
        DgvProjects.ClearSelection()

    End Sub

    Private Sub LoadProjectForm(oProject As Project)
        _selectedProject = oProject
        With _selectedProject
            LblProjectId.Text = .ProjectId
            LblSelectedProject.Text = .ProjectName
            LblProjectId.Visible = True
            TxtName.Text = .ProjectName
            DtpStart.Value = .DateStarted
            DtpEnd.Value = .DateEnded
            NudDesignHeight.Value = .DesignHeight
            NudDesignWidth.Value = .DesignWidth
            NudOriginX.Value = .OriginX
            NudOriginY.Value = .OriginY
            NudFabricHeight.Value = .FabricHeight
            NudFabricWidth.Value = .FabricWidth
            Select Case .FabricColour
                Case 1 To 4
                    PicFabricColour.BackColor = oFabricColour(.FabricColour - 1)
                    CbFabricColour.SelectedIndex = .FabricColour - 1
                Case Else
                    PicFabricColour.BackColor = Color.FromArgb(.FabricColour)
                    CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1
            End Select
            Select Case .Grid1Colour
                Case 1 To 4
                    PicGrid1Colour.BackColor = oGridColour(.Grid1Colour - 1)
                    CbGrid1Colour.SelectedIndex = .Grid1Colour - 1
                Case Else
                    PicGrid1Colour.BackColor = Color.FromArgb(.Grid1Colour)
                    CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1
            End Select
            Select Case .Grid5Colour
                Case 1 To 4
                    PicGrid5Colour.BackColor = oGridColour(.Grid5Colour - 1)
                    CbGrid5Colour.SelectedIndex = .Grid5Colour - 1
                Case Else
                    PicGrid5Colour.BackColor = Color.FromArgb(.Grid5Colour)
                    CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1
            End Select
            Select Case .Grid10Colour
                Case 1 To 4
                    PicGrid10Colour.BackColor = oGridColour(.Grid10Colour - 1)
                    CbGrid10Colour.SelectedIndex = .Grid10Colour - 1
                Case Else
                    PicGrid10Colour.BackColor = Color.FromArgb(.Grid10Colour)
                    CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1
            End Select

        End With
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
        Dim _fcolr As Integer = If(CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1, PicFabricColour.BackColor.ToArgb, CbFabricColour.SelectedIndex + 1)
        Dim _g1colr As Integer = If(CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1, PicGrid1Colour.BackColor.ToArgb, CbGrid1Colour.SelectedIndex + 1)
        Dim _g5colr As Integer = If(CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1, PicGrid5Colour.BackColor.ToArgb, CbGrid5Colour.SelectedIndex + 1)
        Dim _g10colr As Integer = If(CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1, PicGrid10Colour.BackColor.ToArgb, CbGrid10Colour.SelectedIndex + 1)
        Dim _project As Project = ProjectBuilder.AProject.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                    .WithStarted(DtpStart.Value) _
                                                    .WithEnded(DtpEnd.Value) _
                                                    .WithDesignHeight(NudDesignHeight.Value) _
                                                    .WithDesignWidth(NudDesignWidth.Value) _
                                                    .WithFabricHeight(NudFabricHeight.Value) _
                                                    .WithFabricWidth(NudFabricWidth.Value) _
                                                    .WithFabricColour(_fcolr) _
                                                    .WithGrid1Colour(_g1colr) _
                                                     .WithGrid5Colour(_g5colr) _
                                                     .WithGrid10Colour(_g10colr) _
                                                 .Build()
        Return _project
    End Function

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
        LoadProjectTable()
        SelectProjectInList(_project.ProjectId)
        LogUtil.ShowStatus("project Added", LblStatus, MyBase.Name)
    End Sub
    Private Sub UpdateSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Updating project", MyBase.Name)
            Dim _project As Project = BuildProjectFromForm(_selectedProject.ProjectId)
            UpdateProject(_project)
            LoadProjectTable()
            SelectProjectInList(_selectedProject.ProjectId)
            LogUtil.ShowStatus("Project updated", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Private Sub LoadProjectTable()
        isLoading = True
        LoadProjectList(DgvProjects, MyBase.Name)
        isLoading = False
    End Sub
    Friend Sub DeleteSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Delete project", MyBase.Name)
            RemoveExistingProjectCards(_selectedProject.ProjectId)
            DeleteProjectThreadsForProject(_selectedProject.ProjectId)
            DeleteProject(_selectedProject)
            ClearProjectForm()
            LoadProjectList(DgvProjects, MyBase.Name)
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub

    Private Sub BtnProjectThreads_Click(sender As Object, e As EventArgs) Handles BtnProjectThreads.Click
        If _selectedProject.ProjectId > 0 Then
            LogUtil.Info("Opening Project Threads form", MyBase.Name)
            Using _projthreads As New FrmProjectThreads
                _projthreads.SelectedProject = _selectedProject
                _projthreads.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PicFabricColour_Click(sender As Object, e As EventArgs) Handles PicFabricColour.Click
        PicFabricColour.BackColor = SelectColor(PicFabricColour.BackColor)
        CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1
    End Sub

    Private Sub PicGrid1Colour_Click(sender As Object, e As EventArgs) Handles PicGrid1Colour.Click
        PicGrid1Colour.BackColor = SelectColor(PicGrid1Colour.BackColor)
        CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1
    End Sub
    Private Sub PicGrid5Colour_Click(sender As Object, e As EventArgs) Handles PicGrid5Colour.Click
        PicGrid5Colour.BackColor = SelectColor(PicGrid5Colour.BackColor)
        CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1
    End Sub
    Private Sub PicGrid10Colour_Click(sender As Object, e As EventArgs) Handles PicGrid10Colour.Click
        PicGrid10Colour.BackColor = SelectColor(PicGrid10Colour.BackColor)
        CbGrid10Colour.SelectedIndex = CbGrid10Colour.Items.Count - 1
    End Sub
    Private Sub CbFabricColour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbFabricColour.SelectedIndexChanged
        Select Case CbFabricColour.SelectedIndex
            Case 0 To CbFabricColour.Items.Count - 2
                PicFabricColour.BackColor = oFabricColour(CbFabricColour.SelectedIndex)
                'Case Else
                '    PicFabricColour.BackColor = SelectColor(PicFabricColour.BackColor)
        End Select
    End Sub
    Private Sub CbGrid1Colour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid1Colour.SelectedIndexChanged
        Select Case CbGrid1Colour.SelectedIndex
            Case 0 To CbGrid1Colour.Items.Count - 2
                PicGrid1Colour.BackColor = oGridColour(CbGrid1Colour.SelectedIndex)
                'Case Else
                '    PicGrid1Colour.BackColor = SelectColor(PicGrid1Colour.BackColor)
        End Select
    End Sub

    Private Sub CbGrid5Colour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid5Colour.SelectedIndexChanged
        Select Case CbGrid5Colour.SelectedIndex
            Case 0 To CbGrid5Colour.Items.Count - 2
                PicGrid5Colour.BackColor = oGridColour(CbGrid5Colour.SelectedIndex)
                'Case Else
                '    PicGrid5Colour.BackColor = SelectColor(PicGrid5Colour.BackColor)
        End Select
    End Sub

    Private Sub CbGrid10Colour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid10Colour.SelectedIndexChanged
        Select Case CbGrid10Colour.SelectedIndex
            Case 0 To CbGrid10Colour.Items.Count - 2
                PicGrid10Colour.BackColor = oGridColour(CbGrid10Colour.SelectedIndex)
                'Case Else
                '    PicGrid10Colour.BackColor = SelectColor(PicGrid10Colour.BackColor)
        End Select
    End Sub

    Private Sub BtnDesign_Click(sender As Object, e As EventArgs) Handles BtnDesign.Click
        Using _design As New FrmStitchDesign
            If _selectedProject IsNot Nothing AndAlso _selectedProject.IsLoaded Then
                _design.ProjectId = _selectedProject.ProjectId
                _design.ShowDialog()
            Else
            End If
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub MnuShowLog_Click(sender As Object, e As EventArgs) Handles MnuShowLog.Click

    End Sub

    Private Sub MnuUndoOn_Click(sender As Object, e As EventArgs) Handles MnuUndoOn.Click

    End Sub

    Private Sub MnuDuplicate_Click(sender As Object, e As EventArgs) Handles MnuDuplicate.Click

    End Sub

    Private Sub MnuCrop_Click(sender As Object, e As EventArgs) Handles MnuCrop.Click

    End Sub

    Private Sub MnuExtend_Click(sender As Object, e As EventArgs) Handles MnuExtend.Click

    End Sub



#End Region

End Class