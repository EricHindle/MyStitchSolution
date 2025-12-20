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
    Private Const SELECT_OR_ADD As String = "SELECT A PROJECT FROM THE LIST OR ADD A NEW PROJECT"
    Private Const INVALID_PROJECT As String = "PROJECT DETAILS MISSING OR INVALID"
    Private Const INVALID_PROJECT_NAME As String = "PROJECT NAME MISSING"
    Private Const INVALID_WIDTH As String = "INVALID WIDTH"
    Private Const INVALID_HEIGHT As String = "INVALID HEIGHT"
    Private Const UNEXPECTED_ERROR As String = "UNEXPECTED ERROR - SEE LOG"
    Private Const PROJECT_NOT_UPDATED As String = "Project NOT Updated"
    Private Const NO_PROJECT_SELECTED As String = "No Project Selected"
    Private Const DESIGN_NOT_FOUND As String = "Design File not found"
#End Region
#Region "variables"
    Private _selectedProject As New Project
    Private isRestartRequired As Boolean = False
#End Region
#Region "handlers"
    Private Sub FrmProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("MyStitch Projects", MyBase.Name)
        LoadProjectSettings()
        AddInstruction(SELECT_OR_ADD)
        InitialiseProjects()
        SetEnabledButtons(False)
        KeyPreview = True
        Dim _projectFile As String = CheckRunTimeParameters()
        If _projectFile IsNot Nothing Then
            Try
                ModProject.OpenProjectFile(_projectFile, LblStatus)
                If oFileProject IsNot Nothing AndAlso oFileProject.IsLoaded Then
                    Dim _path As String = Path.GetDirectoryName(_projectFile)
                    If _path = oDesignFolderName AndAlso IsProjectInList(oFileProject) Then
                        OpenProjectDesign()
                    Else
                        If ImportProject(_projectFile) Then
                            LoadProjectList(DgvProjects, MyBase.Name)
                            SelectProjectInList(DgvProjects, oFileProject.ProjectId)
                            OpenProjectDesign()
                        End If
                    End If
                End If
            Catch ex As ApplicationException
                LogUtil.DisplayException(ex, "Error importing design file", MethodBase.GetCurrentMethod.Name)
            End Try
        End If
    End Sub
    Private Sub SetEnabledButtons(pIsEnabled)
        PnlButtons.Enabled = pIsEnabled
        BtnProjectThreads.Enabled = pIsEnabled
    End Sub
    Private Sub InitialiseProjects()
        isProjectLoading = True
        Try
            LoadDataTables()
        Catch ex As ApplicationException
            ShowCriticalError("A problem has occurred. Application cannot continue.", ex, MyBase.Name)
            Close()
            Exit Sub
        End Try
        InitialiseForm()
        isProjectLoading = False
    End Sub
    Private Function CheckRunTimeParameters() As String
        Dim _params As String() = System.Environment.GetCommandLineArgs
        Dim _filename As String = Nothing
        ' Check if a project file is passed as a parameter
        If _params.Length > 1 Then
            Dim _firstParameter As String = _params(1)
            LogUtil.LogInfo("Runtime parameter found : " & _firstParameter, MyBase.Name)
            If My.Computer.FileSystem.FileExists(_firstParameter) Then
                Try
                    Dim _suffix As String = Path.GetExtension(_firstParameter).ToLower
                    If _suffix = DESIGN_ARC_EXT Or _suffix = DESIGN_ZIP_EXT Then
                        _filename = _firstParameter
                    End If
                Catch ex As ArgumentException
                    LogUtil.LogException(ex, "Runtime parameter exception", MyBase.Name)
                End Try
            Else
                LogUtil.LogInfo("File not found: " & _firstParameter, MyBase.Name)
            End If
        End If
        Return _filename
    End Function
    Private Function IsProjectInList(pProject As Project) As Boolean
        Dim isProjectFound As Boolean = False
        For Each oRow In DgvProjects.Rows
            If oRow.cells(projectId.Name).value = pProject.ProjectId And oRow.cells(projectName.Name).value = pProject.ProjectName Then
                isProjectFound = True
                oRow.selected = True
                Exit For
            End If
        Next
        Return isProjectFound
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
        My.Settings.ProjectFormPos = SetFormPos(Me)
        My.Settings.Save()
        If Not isRestartRequired Then
            SaveData()
        End If
    End Sub
    Private Sub DgvProjects_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        If Not isProjectLoading Then
            If DgvProjects.SelectedRows.Count = 1 Then
                _selectedProject = FindProjectById(DgvProjects.SelectedRows(0).Cells(projectId.Name).Value)
                'NudDesignHeight.Enabled = False
                'NudDesignWidth.Enabled = False
                SetEnabledButtons(True)
                AddInstruction(String.Empty)
            Else
                _selectedProject = ProjectBuilder.AProject.StartingWithNothing.Build
                'NudDesignHeight.Enabled = True
                'NudDesignWidth.Enabled = True
                oProjectDesign = New ProjectDesign
                oProjectThreads = New ProjectThreadCollection
                oProjectBeads = New ProjectBeadCollection
                oDesignBitmap = New Bitmap(1, 1)
                SetEnabledButtons(False)
                AddInstruction(SELECT_OR_ADD)
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
            AddInstruction(NO_PROJECT_SELECTED)
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
    Private Sub MnuDebugOn_Click(sender As Object, e As EventArgs) Handles MnuDebug.Click
        My.Settings.isDebugOn = Not My.Settings.isDebugOn
        LogUtil.IsDebugOn = My.Settings.isDebugOn
        MnuDebug.Checked = My.Settings.isDebugOn
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
        'NudDesignHeight.Enabled = False
        'NudDesignWidth.Enabled = False
        OpenProjectDesign()
    End Sub
    Private Sub MnuFullThreadList_Click(sender As Object, e As EventArgs) Handles MnuThreadList.Click
        OpenThreadListForm()
    End Sub
    Private Sub MnuBeadList_Click(sender As Object, e As EventArgs) Handles MnuBeads.Click
        OpenBeadListForm()
    End Sub
    Private Sub MnuProjectThreads_Click(sender As Object, e As EventArgs) Handles MnuProjectThreads.Click
        OpenProjectThreadListForm()
    End Sub
    Private Sub MaintainSymbolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuSymbols.Click
        OpenSymbolsForm()
    End Sub
    Private Sub MnuProjectSymbols_Click(sender As Object, e As EventArgs) Handles MnuThreadSymbols.Click
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
        '    Dim _filename As String = FileUtil.GetFileName(FileUtil.OpenOrSave.Open, FileUtil.FileType.HSZ, oDesignFolderName)
         '   OpenProjectFromFile(_filename, DgvProjects, LblStatus)
        '    OpenProjectDesign()
    End Sub
    Private Sub MnuImportImage_Click(sender As Object, e As EventArgs) Handles MnuImportImage.Click
        ShowImportImageForm()
        LoadProjectTable(DgvProjects)
    End Sub
    Private Sub MnuTest_Click(sender As Object, e As EventArgs) Handles MnuTest.Click
        '
        '   Test code here
        '

    End Sub
    Private Sub MnuProjectThreadSymbols_Click(sender As Object, e As EventArgs) Handles MnuProjectThreadSymbols.Click
        OpenProjectThreadSymbolForm()
    End Sub
    Private Sub MnuBrands_Click(sender As Object, e As EventArgs) Handles MnuBrands.Click
        OpenBrandListForm()
    End Sub
    Private Sub MnuPalettes_Click(sender As Object, e As EventArgs) Handles MnuPalettes.Click
        OpenPaletteForm()
    End Sub

#End Region
#Region "functions"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.ProjectFormPos)
        LoadProjectList(DgvProjects, MyBase.Name)
        LoadProjectForm(_selectedProject)
        oProject = New Project
        oProjectDesign = New ProjectDesign
        LblProjectId.Visible = False
    End Sub
    Friend Sub LoadProjectSettings()
        MnuDebug.Checked = My.Settings.isDebugOn
    End Sub
    Private Sub ClearProjectForm()
        DgvProjects.ClearSelection()
        LblProjectId.Visible = False
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
            NudFabricHeight.Value = .FabricHeight
            NudFabricWidth.Value = .FabricWidth
            NudFabricCount.Value = .FabricCount
            PicFabricColour.BackColor = GetColourFromProject(.FabricColour, oFabricColourList)
            LblOrigin.Text = String.Format("Origin {0},{1}", .OriginX, .OriginY)
            Select Case .FabricColour
                Case 1 To 4
                    CbFabricColour.SelectedIndex = .FabricColour - 1
                Case Else
                    CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1
            End Select
            UpdateProjectTime()
        End With
    End Sub
    Private Sub AddInstruction(pText As String)
        AddInstruction(pText, False)
    End Sub
    Private Sub AddInstruction(pText As String, pIsLogged As Boolean)
        If Not String.IsNullOrWhiteSpace(pText) Then
            LblInstruction.Text = pText
            PnlInstruction.Visible = True
            If pIsLogged Then
                LogUtil.LogInfo(pText, MyBase.Name)
            End If
        Else
            LblInstruction.Text = String.Empty
            PnlInstruction.Visible = False
        End If
    End Sub
    Private Function BuildProjectFromForm(pProject As Project) As Project
        Dim _fcolr As Integer = If(CbFabricColour.SelectedIndex = CbFabricColour.Items.Count - 1, PicFabricColour.BackColor.ToArgb, CbFabricColour.SelectedIndex + 1)
        Dim _project As Project = ProjectBuilder.AProject.StartingWithNothing _
                                                    .WithId(pProject.ProjectId) _
                                                    .WithName(TxtName.Text) _
                                                    .WithDesignHeight(NudDesignHeight.Value) _
                                                    .WithDesignWidth(NudDesignWidth.Value) _
                                                    .WithFabricHeight(NudFabricHeight.Value) _
                                                    .WithFabricWidth(NudFabricWidth.Value) _
                                                    .WithFabricColour(_fcolr) _
                                                    .WithFabricCount(NudFabricCount.Value) _
                                                    .WithTotalMinutes(0) _
                                                    .WithStarted(DateTime.Now) _
                                                    .WithEnded(DateTime.Now) _
                                                    .WithOriginX(pProject.OriginX) _
                                                    .WithOriginY(pProject.OriginY) _
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
        LogUtil.LogInfo("New project", MethodBase.GetCurrentMethod.Name)
        Dim _project As Project = BuildProjectFromForm(New Project)
        If IsValidProject() Then
            _project.OriginX = (_project.FabricWidth - _project.DesignWidth) / 2
            _project.OriginY = (_project.FabricHeight - _project.DesignHeight) / 2
            _project.ProjectId = AddNewProject(_project)
            LoadProjectTable(DgvProjects)
            SelectProjectInList(DgvProjects, _project.ProjectId)
            oProject = _selectedProject
            SaveDesign()
            AddInstruction(PROJECT_ADDED, True)
        End If
    End Sub
    Private Sub UpdateSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Updating project " & CStr(_selectedProject.ProjectId), MethodBase.GetCurrentMethod.Name)
            Dim _previousProject As Project = _selectedProject
            Dim _newProject As Project = BuildProjectFromForm(_selectedProject)
            If IsValidProject() Then
                Dim iFabricWidthChange As Integer = _newProject.FabricWidth - _previousProject.FabricWidth
                Dim iFabricHeightChange As Integer = _newProject.FabricHeight - _previousProject.FabricHeight
                _newProject.OriginX += iFabricWidthChange
                _newProject.OriginY += iFabricHeightChange
                '_newProject.OriginX = 0
                '_newProject.OriginY = 0
                If AmendProject(_newProject) Then
                    '                    SaveDesign()
                    LoadProjectTable(DgvProjects)
                    SelectProjectInList(DgvProjects, _selectedProject.ProjectId)
                    If _previousProject.DesignFileName <> _selectedProject.DesignFileName Then
                        If MsgBox("Rename Project File?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Rename") = MsgBoxResult.Yes Then
                            RenameProjectFile(_selectedProject, _previousProject)
                        End If
                    End If
                    AddInstruction(PROJECT_UPDATED, True)
                Else
                    AddInstruction(PROJECT_NOT_UPDATED, True)
                End If
            End If
        Else
            AddInstruction(NO_PROJECT_SELECTED, True)
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
                LogUtil.LogInfo("Renaming " & _existingDesignFile & " to " & _newDesignFile, MyBase.Name)
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
            AddInstruction(DESIGN_NOT_FOUND, True)
            Beep()
        End If
    End Sub
    Friend Sub DeleteSelectedProject()
        If _selectedProject.ProjectId >= 0 Then
            LogUtil.LogInfo("Deleting project " & CStr(_selectedProject.ProjectId), MethodBase.GetCurrentMethod.Name)
            If MsgBox("The project will be removed permanently. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                RemoveProjectCards(_selectedProject.ProjectId)
                RemoveProjectThreadsForProject(_selectedProject.ProjectId)
                RemoveProject(_selectedProject)
                If MsgBox("Retain Design File?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Design File") = MsgBoxResult.No Then
                    RemoveDesignFile(_selectedProject)
                End If
                ClearProjectForm()
                LoadProjectList(DgvProjects, MyBase.Name)
                AddInstruction(PROJECT_REMOVED, True)
            Else
                LogUtil.LogInfo("Deletion cancelled", MethodBase.GetCurrentMethod.Name)
            End If
        Else
            AddInstruction(NO_PROJECT_SELECTED, True)
        End If
    End Sub
    Private Shared Sub OpenThreadListForm()
        Using _threads As New FrmThread
            _threads.ShowDialog()
        End Using
    End Sub
    Private Shared Sub OpenBeadListForm()
        Using _beads As New FrmBeads
            _beads.ShowDialog()
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
            SelectProjectInList(DgvProjects, _selectedProject.ProjectId)
            LoadProjectForm(_selectedProject)
            AddInstruction(String.Empty)
        Else
            AddInstruction(NO_PROJECT_SELECTED, True)
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
            _threads.UsedThreads = FindUsedThreadsForProject(_selectedProject.ProjectId, True)
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
            AddInstruction(NO_PROJECT_SELECTED)
        End If
    End Sub
    Private Sub OpenRestoreForm()
        Using _restore As New FrmRestore
            _restore.IsRestartRequired = False
            _restore.ShowDialog()
            If _restore.IsRestartRequired Then
                isRestartRequired = True
                MsgBox("Data files have been restored. MyStitch will now be restarted.", MsgBoxStyle.Information, "Restart")
                LogUtil.LogInfo("Restarting MyStitch >>>>>>>>>>>>>", MethodBase.GetCurrentMethod.Name)
                Application.Restart()
            ElseIf _restore.IsReloadDataRequired Then
                InitialiseProjects()
            End If
        End Using
    End Sub
    Private Function ImportProject(pFilename As String) As Boolean
        Dim isImported As Boolean
        Using _importProject As New FrmImportProject
            _importProject.ProjectFilename = pFilename
            _importProject.IsDuplicateProject = IsProjectInList(oFileProject)
            _importProject.ShowDialog()
            isImported = _importProject.IsImportComplete
        End Using
        Return isImported
    End Function
    Private Sub ShowImportImageForm()
        Using _import As New FrmImportImage
            _import.ShowDialog()
        End Using
    End Sub
    Private Function IsValidProject() As Boolean
        Dim isValid As Boolean = True
        If TxtName.TextLength = 0 Then
            AddInstruction(INVALID_PROJECT_NAME)
            isValid = False
        End If
        If NudFabricWidth.Value < NudDesignWidth.Value Then
            AddInstruction(INVALID_WIDTH)
            isValid = False
        End If
        If NudFabricHeight.Value < NudDesignHeight.Value Then
            AddInstruction(INVALID_HEIGHT)
            isValid = False
        End If
        Return isValid
    End Function
    Private Sub SaveData()
        LogUtil.LogInfo("Saving MyStitch tables", MethodBase.GetCurrentMethod.Name)
        Try
            SaveDataTables()
        Catch ex As Exception
            AddInstruction(UNEXPECTED_ERROR, True)
            Beep()
        End Try
        Try
            RemoveOldDailyArchives()
            CopyArchiveToDailyFolder()
            CopyArchiveToArchiveFolder()
        Catch ex As Exception
            AddInstruction(UNEXPECTED_ERROR, True)
            LogUtil.Problem(ex.Message)
            LogUtil.Problem(ex.InnerException.Message)
            Beep()
        End Try
    End Sub

    Private Sub NudDesignWidth_ValueChanged(sender As Object, e As EventArgs) Handles NudDesignWidth.ValueChanged
        NudFabricWidth.Value = Math.Max(NudFabricWidth.Value, NudDesignWidth.Value)
    End Sub

    Private Sub NudDesignHeight_ValueChanged(sender As Object, e As EventArgs) Handles NudDesignHeight.ValueChanged
        NudFabricHeight.Value = Math.Max(NudFabricHeight.Value, NudDesignHeight.Value)
    End Sub

#End Region
End Class