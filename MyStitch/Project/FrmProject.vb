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
    End Sub
#End Region
#Region "functions"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.ProjectFormPos)
        MnuDebugOn.Checked = My.Settings.isDebugOn
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
            PicFabricColour.BackColor = GetColourFromProject(.FabricColour, oFabricColour)
            PicGrid1Colour.BackColor = GetColourFromProject(.Grid1Colour, oGridColour)
            PicGrid5Colour.BackColor = GetColourFromProject(.Grid5Colour, oGridColour)
            PicGrid10Colour.BackColor = GetColourFromProject(.Grid10Colour, oGridColour)
            Select Case .FabricColour
                Case 1 To 4
                    CbFabricColour.SelectedIndex = .FabricColour - 1
                Case Else
                    CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1
            End Select
            Select Case .Grid1Colour
                Case 1 To 4
                    CbGrid1Colour.SelectedIndex = .Grid1Colour - 1
                Case Else
                    CbGrid1Colour.SelectedIndex = CbGrid1Colour.Items.Count - 1
            End Select
            Select Case .Grid5Colour
                Case 1 To 4
                    CbGrid5Colour.SelectedIndex = .Grid5Colour - 1
                Case Else
                    CbGrid5Colour.SelectedIndex = CbGrid5Colour.Items.Count - 1
            End Select
            Select Case .Grid10Colour
                Case 1 To 4
                    CbGrid10Colour.SelectedIndex = .Grid10Colour - 1
                Case Else
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
        End Select
    End Sub
    Private Sub CbGrid1Colour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid1Colour.SelectedIndexChanged
        Select Case CbGrid1Colour.SelectedIndex
            Case 0 To CbGrid1Colour.Items.Count - 2
                PicGrid1Colour.BackColor = oGridColour(CbGrid1Colour.SelectedIndex)
        End Select
    End Sub

    Private Sub CbGrid5Colour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid5Colour.SelectedIndexChanged
        Select Case CbGrid5Colour.SelectedIndex
            Case 0 To CbGrid5Colour.Items.Count - 2
                PicGrid5Colour.BackColor = oGridColour(CbGrid5Colour.SelectedIndex)
        End Select
    End Sub

    Private Sub CbGrid10Colour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbGrid10Colour.SelectedIndexChanged
        Select Case CbGrid10Colour.SelectedIndex
            Case 0 To CbGrid10Colour.Items.Count - 2
                PicGrid10Colour.BackColor = oGridColour(CbGrid10Colour.SelectedIndex)
        End Select
    End Sub

    Private Sub BtnDesign_Click(sender As Object, e As EventArgs) Handles BtnDesign.Click
        OpenProjectDesign()
    End Sub

    Private Sub OpenProjectDesign()
        If _selectedProject IsNot Nothing AndAlso _selectedProject.IsLoaded Then
            Using _design As New FrmStitchDesign
                _design.ProjectId = _selectedProject.ProjectId
                _design.ShowDialog()
            End Using
        Else
            LogUtil.ShowStatus("No Project selected", LblStatus, True)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub MnuShowLog_Click(sender As Object, e As EventArgs) Handles MnuShowLog.Click
        ShowLog()
    End Sub

    Private Sub MnuUndoOn_Click(sender As Object, e As EventArgs) Handles MnuUndoOn.Click

    End Sub

    Private Sub MnuSymbols_Click(sender As Object, e As EventArgs) Handles MnuSymbols.Click
        OpenSymbolsForm()
    End Sub

    Private Shared Sub OpenSymbolsForm()
        Using _symbols As New FrmSymbols
            _symbols.ShowDialog()
        End Using
    End Sub

    Private Sub MnuThreads_Click(sender As Object, e As EventArgs) Handles MnuThreads.Click
        OpenThreadListForm
    End Sub
    Private Shared Sub OpenThreadListForm()
        Using _threads As New FrmThread
            _threads.ShowDialog()
        End Using
    End Sub

    Private Sub MnuOpenDesign_Click(sender As Object, e As EventArgs) Handles MnuOpenDesign.Click
        OpenProjectDesign()
    End Sub

    Private Sub MnuResizeDesign_Click(sender As Object, e As EventArgs) Handles MnuResizeDesign.Click

    End Sub

    Private Sub MnuDebugOn_Click(sender As Object, e As EventArgs) Handles MnuDebugOn.Click
        My.Settings.isDebugOn = Not My.Settings.isDebugOn
        LogUtil.IsDebugOn = My.Settings.isDebugOn
        MnuDebugOn.Checked = My.Settings.isDebugOn
        My.Settings.Save()
        LogUtil.LogInfo("Debugging is " & If(My.Settings.isDebugOn, "ON", "OFF"), MyBase.Name)
    End Sub

    Private Shared Sub OpenBackupForm()
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
    End Sub
    Private Shared Sub OpenRestoreForm()
        Using _restore As New FrmRestore
            _restore.ShowDialog()
        End Using
    End Sub

    Private Sub MnuBackup_Click(sender As Object, e As EventArgs) Handles MnuBackup.Click
        OpenBackupForm()
    End Sub

    Private Sub MnuRestore_Click(sender As Object, e As EventArgs) Handles MnuRestore.Click
        OpenRestoreForm()
    End Sub

    Private Sub MnuPreferences_Click(sender As Object, e As EventArgs) Handles MnuPreferences.Click
        OpenPreferencesForm()
    End Sub
    Private Sub OpenPreferencesForm()
        Using _options As New FrmOptions
            _options.ShowDialog()
        End Using
    End Sub

    Private Sub DgvProjects_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvProjects.CellDoubleClick
        Dim _row As DataGridViewRow = DgvProjects.Rows(e.RowIndex)
        Dim _projectId As Integer = _row.Cells(projectId.Name).Value
        _selectedProject = GetProjectById(_projectId)
        NudDesignHeight.Enabled = False
        NudDesignWidth.Enabled = False
        NudOriginX.Enabled = False
        NudOriginY.Enabled = False
        OpenProjectDesign()

    End Sub

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) 
        If _selectedProject IsNot Nothing AndAlso _selectedProject.IsLoaded Then
            Using _design As New FrmStitchDesign
                _design.ProjectId = _selectedProject.ProjectId
                _design.ShowDialog()
            End Using
        Else
            LogUtil.ShowStatus("No Project selected", LblStatus, True)
        End If
    End Sub

#End Region

End Class