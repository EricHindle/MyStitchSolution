' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports HindlewareLib.Logging
Imports HindlewareLib.Utilities
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
#End Region
#Region "handlers"
    Private Sub FrmProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("MyStitch Projects", MyBase.Name)
        LoadProjectSettings()
        isLoading = True
        Try
            LoadDataTables(LblStatus)
        Catch ex As ApplicationException
            ShowCriticalError("A problem has occurred. Application cannot continue.", ex, MyBase.Name)
            Close()
            Exit Sub
        End Try
        LogUtil.ShowStatus("Data loaded OK", LblStatus)
        InitialiseForm()
        isLoading = False
        KeyPreview = True
        Dim _projectFile As String = CheckRunTimeParameters()
        If _projectFile IsNot Nothing Then
            OpenProjectFromFile(_projectFile, DgvProjects, LblStatus)
            If oFileProject.IsLoaded Then
                SelectProjectInList(DgvProjects, oFileProject.ProjectId)
                OpenProjectDesign()
            End If
        End If
    End Sub
    Private Function CheckRunTimeParameters() As String
        Dim _params As String() = System.Environment.GetCommandLineArgs
        Dim _filename As String = Nothing
        ' Check if a project file is passed as a parameter
        If _params.Length > 1 Then
            LogUtil.LogInfo("Runtime parameter found : " & _params(1), MyBase.Name)
            If My.Computer.FileSystem.FileExists(_params(1)) Then
                Try
                    Dim _suffix As String = Path.GetExtension(_params(1)).ToLower
                    If _suffix = DESIGN_ARC_EXT Or _suffix = DESIGN_ZIP_EXT Then
                        _filename = _params(1)
                    End If
                Catch ex As ArgumentException
                    LogUtil.ShowException(ex, "Runtime parameter exception", LblStatus, MyBase.Name)
                End Try
            Else
                LogUtil.LogInfo("File not found: " & _params(1), MyBase.Name)
            End If
        End If
        Return _filename
    End Function
    Private Sub MyBase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        KeyHandler(Me, FormType.Project, e)
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        oGrid1Pen.Dispose()
        oGrid5Pen.Dispose()
        oGrid10Pen.Dispose()
        oCentrePen.Dispose()
        SaveData()
        My.Settings.ProjectFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub DgvProjects_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        LogUtil.ClearStatus(LblStatus)
        If Not isLoading Then
            If DgvProjects.SelectedRows.Count = 1 Then
                _selectedProject = FindProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
                _selectedProject = ModDataTableAdapter.FindProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
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
                oProjectDesign = New ProjectDesign
                oProjectThreads = New ProjectThreadCollection
                oDesignBitmap = New Bitmap(1, 1)
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
    Private Sub BtnProjectThreads_Click(sender As Object, e As EventArgs) Handles BtnProjectThreads.Click
        If _selectedProject.ProjectId > 0 Then
            LogUtil.Info("Opening Project Threads form", MyBase.Name)
            Using _projthreads As New FrmProjectThreads
                _projthreads.SelectedProject = _selectedProject
                _projthreads.UsedThreads = FindUsedThreadsForProject(_selectedProject.ProjectId, True)
                _projthreads.ShowDialog()
            End Using
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True)
        End If
    End Sub
    Private Sub PicFabricColour_Click(sender As Object, e As EventArgs) Handles PicFabricColour.Click
        PicFabricColour.BackColor = SelectColor(PicFabricColour.BackColor)
        CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1
    End Sub
    Private Sub CbFabricColour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbFabricColour.SelectedIndexChanged
        Select Case CbFabricColour.SelectedIndex
            Case 0 To CbFabricColour.Items.Count - 2
                PicFabricColour.BackColor = oFabricColourList(CbFabricColour.SelectedIndex)
        End Select
    End Sub
    Private Sub BtnDesign_Click(sender As Object, e As EventArgs) Handles BtnDesign.Click
        OpenProjectDesign()
    End Sub
    Private Sub MnuExit_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
        Close()
    End Sub
    Private Sub MnuShowLog_Click(sender As Object, e As EventArgs) Handles MnuShowLog.Click
        ShowLog()
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
    Private Sub MnuBackup_Click(sender As Object, e As EventArgs) Handles MnuBackup.Click
        OpenBackupForm()
    End Sub
    Private Sub MnuRestore_Click(sender As Object, e As EventArgs) Handles MnuRestore.Click
        OpenRestoreForm()
    End Sub
    Private Sub MnuPreferences_Click(sender As Object, e As EventArgs) Handles MnuPreferences.Click
        OpenPreferencesForm(Me)
    End Sub
    Private Sub DgvProjects_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvProjects.CellDoubleClick
        Dim _row As DataGridViewRow = DgvProjects.Rows(e.RowIndex)
        Dim _projectId As Integer = _row.Cells(projectId.Name).Value
        _selectedProject = FindProjectById(_projectId)
        NudDesignHeight.Enabled = False
        NudDesignWidth.Enabled = False
        NudOriginX.Enabled = False
        NudOriginY.Enabled = False
        OpenProjectDesign()

    End Sub
    Private Sub MnuFullThreadList_Click(sender As Object, e As EventArgs) Handles MnuFullThreadList.Click
        OpenThreadListForm()
    End Sub
    Private Sub MnuProjectThreadSymbols_Click(sender As Object, e As EventArgs) Handles MnuProjectThreadSymbols.Click
        OpenProjectThreadSymbolForm()
    End Sub
    Private Sub MnuProjectThreads_Click(sender As Object, e As EventArgs) Handles MnuProjectThreads.Click
        OpenProjectThreadListForm()
    End Sub
    Private Sub MaintainSymbolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuMaintainSymbols.Click
        OpenSymbolsForm()
    End Sub
    Private Sub MnuProjectSymbols_Click(sender As Object, e As EventArgs) Handles MnuProjectSymbols.Click
        OpenProjectThreadSymbolForm()
    End Sub
    Private Sub MnuBuildCards_Click(sender As Object, e As EventArgs) Handles MnuBuildCards.Click
        OpenBuildCardsForm(_selectedProject)
    End Sub
    Private Sub MnuPrintCards_Click(sender As Object, e As EventArgs) Handles MnuPrintCards.Click
        OpenPrintCardsForm()
    End Sub
    Private Sub MnuPrintSettings_Click(sender As Object, e As EventArgs) Handles MnuPrintSettings.Click
        ShowPrintSettingsForm()
    End Sub
    Private Sub MnuOpenSelectedProject_Click(sender As Object, e As EventArgs) Handles MnuOpenSelectedProject.Click
        '      OpenProjectFile(oProject.ProjectId)
    End Sub
    Private Sub MnuOpenProjectFile_Click(sender As Object, e As EventArgs) Handles MnuOpenProjectFile.Click
        Dim _filename As String = FileUtil.GetFileName(FileUtil.OpenOrSave.Open, FileUtil.FileType.HSZ, oDesignFolderName)
        OpenProjectFromFile(_filename, DgvProjects, LblStatus)
        OpenProjectDesign()
    End Sub
    Private Sub MnuImportImage_Click(sender As Object, e As EventArgs) Handles MnuImportImage.Click
        ShowImportImageForm()
    End Sub
    Private Sub MnuTest_Click(sender As Object, e As EventArgs) Handles MnuTest.Click
        '
        '   Test code here
        '
        Dim oProject As Project = ProjectBuilder.AProject.StartingWithNothing.WithName("Testing").Build
        AddNewProject(oProject)
        MsgBox("Test complete", MsgBoxStyle.Information, "Test")
    End Sub

#End Region
#Region "functions"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.ProjectFormPos)
        LoadProjectList(DgvProjects, MyBase.Name)
        oProject = New Project
        oProjectDesign = New ProjectDesign
    End Sub
    Friend Sub LoadProjectSettings()
        MnuDebugOn.Checked = My.Settings.isDebugOn
    End Sub
    Private Sub ClearProjectForm()
        DgvProjects.ClearSelection()
    End Sub
    Private Sub LoadProjectForm(pProject As Project)
        _selectedProject = pProject
        With _selectedProject
            LblProjectId.Text = .ProjectId
            LblSelectedProject.Text = .ProjectName
            LblProjectId.Visible = True
            LblFilename.Text = .DesignFileName
            TxtName.Text = .ProjectName
            NudDesignHeight.Value = .DesignHeight
            NudDesignWidth.Value = .DesignWidth
            NudOriginX.Value = .OriginX
            NudOriginY.Value = .OriginY
            NudFabricHeight.Value = .FabricHeight
            NudFabricWidth.Value = .FabricWidth
            NudFabricCount.Value = .FabricCount
            PicFabricColour.BackColor = GetColourFromProject(.FabricColour, oFabricColourList)
            Select Case .FabricColour
                Case 1 To 4
                    CbFabricColour.SelectedIndex = .FabricColour - 1
                Case Else
                    CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1
            End Select
            UpdateProjectTime()
        End With
    End Sub
    Private Function BuildProjectFromForm(pId As Integer) As Project
        Dim _fcolr As Integer = If(CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1, PicFabricColour.BackColor.ToArgb, CbFabricColour.SelectedIndex + 1)
        Dim _project As Project = ProjectBuilder.AProject.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                    .WithDesignHeight(NudDesignHeight.Value) _
                                                    .WithDesignWidth(NudDesignWidth.Value) _
                                                    .WithFabricHeight(NudFabricHeight.Value) _
                                                    .WithFabricWidth(NudFabricWidth.Value) _
                                                    .WithFabricColour(_fcolr) _
                                                    .WithFabricCount(NudFabricCount.Value) _
                                                    .WithOriginX(NudOriginX.Value) _
                                                    .WithOriginY(NudOriginY.Value) _
                                                    .WithTotalMinutes(0) _
                                                    .WithStarted(DateTime.Now) _
                                                    .WithEnded(DateTime.Now) _
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
        Dim _project As Project = BuildProjectFromForm(-1)
        _project.ProjectId = AddNewProject(_project)
        LoadProjectTable(DgvProjects)
        SelectProjectInList(DgvProjects, _project.ProjectId)
        oProject = _selectedProject
        SaveDesign()
        LogUtil.ShowStatus("Project Added", LblStatus, MyBase.Name)
    End Sub
    Private Sub UpdateSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Updating project", MyBase.Name)
            Dim _previousProject As Project = _selectedProject
            Dim _newProject As Project = BuildProjectFromForm(_selectedProject.ProjectId)
            AmendProject(_newProject)
            SaveDesign()
            LoadProjectTable(DgvProjects)
            SelectProjectInList(DgvProjects, _selectedProject.ProjectId)
            If _previousProject.DesignFileName <> _selectedProject.DesignFileName Then
                If MsgBox("Rename Project File?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Rename") = MsgBoxResult.Yes Then
                    RenameProjectFile(_selectedProject, _previousProject)
                End If
            End If
            LogUtil.ShowStatus("Project updated", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Private Sub RenameProjectFile(pSelectedProject As Project, pPreviousProject As Project)
        Dim _exceptionText As String = "Exception renaming project design file"
        Dim _existingDesignFile As String = MakeFilename(pPreviousProject) & DESIGN_EXT
        Dim _existingZipFile As String = MakeFullFileName(pPreviousProject, DESIGN_ZIP_EXT)
        If My.Computer.FileSystem.FileExists(_existingZipFile) Then
            Dim _newDesignFile As String = MakeFilename(pSelectedProject) & DESIGN_EXT
            Dim _newZipFile As String = MakeFullFileName(pSelectedProject, DESIGN_ZIP_EXT)
            Try
                LogUtil.ShowStatus("Renaming " & _existingDesignFile & " to " & _newDesignFile, LblStatus, True, MyBase.Name, False)
                Using sourceArchive As ZipArchive = ZipFile.OpenRead(_existingZipFile)
                    Dim entry As ZipArchiveEntry = sourceArchive.GetEntry(_existingDesignFile)
                    Using destArchive As ZipArchive = ZipFile.Open(_newZipFile, ZipArchiveMode.Update)
                        Using existingFileStream As Stream = entry.Open()
                            Dim newFile As ZipArchiveEntry = destArchive.CreateEntry(_newDesignFile)
                            Using newFileStream As Stream = newFile.Open()
                                existingFileStream.CopyTo(newFileStream)
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is PathTooLongException _
                                OrElse TypeOf ex Is DirectoryNotFoundException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException _
                                OrElse TypeOf ex Is InvalidDataException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is ObjectDisposedException)
                LogUtil.DisplayException(ex, _exceptionText, MethodBase.GetCurrentMethod.Name)
            End Try
        Else
            LogUtil.ShowStatus("No project design file found", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Friend Sub DeleteSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Delete project", MyBase.Name)
            RemoveProjectCards(_selectedProject.ProjectId)
            RemoveProjectThreadsForProject(_selectedProject.ProjectId)
            RemoveProject(_selectedProject)
            ClearProjectForm()
            LoadProjectList(DgvProjects, MyBase.Name)
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Private Shared Sub OpenThreadListForm()
        Using _threads As New FrmThread
            _threads.ShowDialog()
        End Using
    End Sub
    Private Sub OpenProjectDesign()
        If _selectedProject IsNot Nothing AndAlso _selectedProject.IsLoaded Then
            Using _design As New FrmStitchDesign
                _design.ProjectId = _selectedProject.ProjectId
                _design.ShowDialog()
            End Using
            _selectedProject = FindProjectById(_selectedProject.ProjectId)
            UpdateProjectTime()
        Else
            LogUtil.ShowStatus("No Project selected", LblStatus, True)
        End If
    End Sub
    Private Sub UpdateProjectTime()
        Dim _workList As List(Of ProjectWorkTime) = FindWorkPeriodsForProject(_selectedProject.ProjectId)
        Dim _startDate As DateTime = Date.MinValue
        Dim _endDate As DateTime = Date.MinValue
        Dim _timeElapsed As TimeSpan = TimeSpan.FromMinutes(_selectedProject.TotalMinutes)
        If _workList.Count > 0 Then
            _startDate = _workList.First.TimeStarted
            _endDate = _workList.Last.TimeEnded
        End If
        LblStartTime.Text = If(_startDate > Date.MinValue, Format(_startDate, "dd MMM yyyy HH:mm"), String.Empty)
        LblEndTime.Text = If(_startDate > Date.MinValue, Format(_endDate, "dd MMM yyyy HH:mm"), String.Empty)
        LblElapsedTime.Text = _timeElapsed.Hours.ToString("D2") & ":" & _timeElapsed.Minutes.ToString("D2")
    End Sub
    Private Sub OpenProjectThreadListForm()
        Using _threads As New FrmProjectThreads
            _threads.SelectedProject = _selectedProject
            _threads.UsedThreads = findUsedThreadsForProject(_selectedProject.ProjectId, True)
            _threads.ShowDialog()
        End Using
    End Sub
    Private Sub OpenProjectThreadSymbolForm()
        If _selectedProject IsNot Nothing AndAlso _selectedProject.IsLoaded Then
            Using _threads As New FrmThreadSymbols
                _threads.SelectedProject = _selectedProject
                _threads.ShowDialog()
            End Using
        Else
            LogUtil.ShowStatus("No Project selected", LblStatus, True)
        End If
    End Sub
    Private Shared Sub OpenRestoreForm()
        Using _restore As New FrmRestore
            _restore.ShowDialog()
        End Using
    End Sub
    Private Sub ShowPrintSettingsForm()
        Using _printSettings As New FrmPrintOptions
            _printSettings.ShowDialog()
        End Using
    End Sub
    Private Sub ShowImportImageForm()
        Using _import As New FrmImportImage
            _import.ShowDialog()
        End Using
    End Sub
    Private Sub SaveData()
        LogUtil.ShowStatus("Saving MyStitch tables", LblStatus, MethodBase.GetCurrentMethod.Name)
        Try
            SaveDataTables()
        Catch ex As Exception

        End Try
        Try
            RemoveOldDailyArchives()
            CopyArchiveToDailyFolder()
            CopyArchiveToArchiveFolder()
        Catch ex As Exception

        End Try

    End Sub
#End Region
End Class