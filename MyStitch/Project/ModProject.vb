' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Reflection
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Module ModProject
    Public Const PROJECT_ID_FLD As Integer = 1
    Public Const PROJECT_NAME_FLD As Integer = 2
    Public Const DATE_STARTED_FLD As Integer = 3
    Public Const DATE_ENDED_FLD As Integer = 4
    Public Const DESIGN_WIDTH_FLD As Integer = 5
    Public Const DESIGN_HEIGHT_FLD As Integer = 6
    Public Const FABRIC_WIDTH_FLD As Integer = 7
    Public Const FABRIC_HEIGHT_FLD As Integer = 8
    Public Const FABRIC_COLOUR_FLD As Integer = 9
    Public Const FABRIC_COUNT_FLD As Integer = 10
    Public Const DESIGN_FILE_NAME_FLD As Integer = 11
    Public Const ORIGIN_X_FLD As Integer = 12
    Public Const ORIGIN_Y_FLD As Integer = 13
    Public Const TOTAL_MINUTES_FLD As Integer = 14

    Public MIN_DATE As New DateTime(2001, 1, 1)
    Public oTimerForm As FrmProjectTimer
    Public isSaved As Boolean = True
    Public isLoading As Boolean
    Public oFileProject As Project
    Public oFileProjectDesign As ProjectDesign
    Public oFileProjectThreadCollection As ProjectThreadCollection

    Public Function SaveDesign() As String
        Dim _reply As String
        If oProject.IsLoaded Then
            If String.IsNullOrEmpty(oProject.DesignFileName) Then
                oProject.DesignFileName = MakeFilename(oProject)
                AmendProject(oProject)
            End If
            _reply = SaveDesignToFile(oProject.DesignFileName)
        Else
            _reply = "No project selected"
            Beep()
        End If
        Return _reply
    End Function
    Public Function SaveDesignToFile(pFilename As String) As String
        Dim _reply As String = String.Empty
        LogUtil.Info("Saving design", MethodBase.GetCurrentMethod.Name)
        If My.Settings.isAutoArchiveOnSave Then
            If Not ArchiveExistingFile(pFilename, oDesignFolderName, DESIGN_ZIP_EXT, oDesignArchiveFolderName, DESIGN_ARC_EXT) Then
                _reply = "Error archiving existing file"
                Beep()
                Return _reply
            End If
        End If
        SaveDesignDelimited(oProject, oProjectDesign, oProjectThreads, pFilename)
        isSaved = True
        LogUtil.LogInfo("Design saved to " & pFilename, MethodBase.GetCurrentMethod.Name)
        _reply = "Save complete"
        Return _reply
    End Function
    Public Sub LoadProject(pDgv As DataGridView)
        LoadProjectTable(pDgv)
        UpdateThreadsFromDesign(oFileProjectDesign, oFileProjectThreadCollection)
        InsertProjectThreadCollection(oFileProjectThreadCollection)
        SelectProjectInList(pDgv, oFileProject.ProjectId)
        oProject = oFileProject
        oProjectDesign = oFileProjectDesign
        oProjectThreads = oFileProjectThreadCollection
        SaveDesign()
    End Sub

    Private Sub UpdateThreadsFromDesign(oFileProjectDesign As ProjectDesign, oFileProjectThreadCollection As ProjectThreadCollection)
        LogUtil.LogInfo("Updating threads from design", MethodBase.GetCurrentMethod.Name)
        For Each _stitch As Stitch In oFileProjectDesign.BlockStitches
            UpdateThreadDatabaseTable(_stitch.ProjThread, oFileProjectThreadCollection)
        Next
        For Each _stitch As Stitch In oFileProjectDesign.BackStitches
            UpdateThreadDatabaseTable(_stitch.ProjThread, oFileProjectThreadCollection)
        Next
        For Each _stitch As Stitch In oFileProjectDesign.Knots
            UpdateThreadDatabaseTable(_stitch.ProjThread, oFileProjectThreadCollection)
        Next
    End Sub
    Private Sub UpdateThreadDatabaseTable(ByRef pProjectThread As ProjectThread, pFileProjectThreadCollection As ProjectThreadCollection)
        Dim _thread As Thread = FindThreadByNumber(pProjectThread.Thread.ThreadNo)
        If _thread.IsLoaded Then
            If _thread.ThreadId <> pProjectThread.ThreadId Then
                LogUtil.LogInfo("DMC" & pProjectThread.Thread.ThreadNo & " id different", MethodBase.GetCurrentMethod.Name)
                pProjectThread.ThreadId = _thread.ThreadId
            End If
        Else
            LogUtil.LogInfo("New thread DMC" & pProjectThread.Thread.ThreadNo & " found", MethodBase.GetCurrentMethod.Name)
            Dim _newThreadId As Integer = AddNewThread(_thread)
            pProjectThread.ThreadId = _newThreadId
        End If
        AddMissingProjectThread(pProjectThread, pFileProjectThreadCollection)
    End Sub

    Private Sub AddMissingProjectThread(pThread As ProjectThread, pFileProjectThreadCollection As ProjectThreadCollection)
        Dim _foundThread As ProjectThread = CType(oFileProjectThreadCollection.Threads.Find(Function(p) p.Thread.ThreadId = pThread.ThreadId), ProjectThread)
        If oFileProjectThreadCollection.Threads.Find(Function(p) p.Thread.ThreadId = pThread.ThreadId) Is Nothing Then
            LogUtil.LogInfo("Adding project thread to collection", MethodBase.GetCurrentMethod.Name)
            oFileProjectThreadCollection.Threads.Add(pThread)
        End If
    End Sub
    Public Sub SelectProjectInList(pDgv As DataGridView, _projectId As Integer)
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells("projectId").Value = _projectId Then
                orow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Public Sub LoadProjectTable(pDgv As DataGridView)
        isLoading = True
        LoadProjectList(pDgv, MethodBase.GetCurrentMethod.Name)
        isLoading = False
    End Sub
    Public Sub OpenProjectFromFile(_filename As String, pDgv As DataGridView, pStatus As ToolStripStatusLabel)
        ModProject.OpenProjectFile(_filename, pStatus)
        If oFileProject IsNot Nothing AndAlso oFileProject.IsLoaded Then
            LogUtil.ShowStatus("Project file opened: " & _filename, pStatus, MethodBase.GetCurrentMethod.Name)
            Dim _existingProject As Project = FindProjectById(oFileProject.ProjectId)
            If _existingProject.IsLoaded Then
                If MsgBox("Project already exists. Do you want to update the existing project?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Update Project") = MsgBoxResult.Yes Then
                    AmendProject(oFileProject)
                    LoadProject(pDgv)
                Else
                    LogUtil.ShowStatus("Project not updated: " & _existingProject.ProjectName, pStatus, MethodBase.GetCurrentMethod.Name)
                End If
            Else
                LogUtil.LogInfo("New project found: " & oFileProject.ProjectName, MethodBase.GetCurrentMethod.Name)
                Dim _newId As Integer = AddNewProject(oFileProject)
                SetNewProjectId(_newId, oFileProject, oFileProjectDesign, oFileProjectThreadCollection)
                LoadProject(pDgv)
            End If
        End If
    End Sub
    Public Sub OpenProjectFile(pFilename As String, ByRef pStatus As ToolStripStatusLabel)
        If Not String.IsNullOrEmpty(pFilename) Then
            LogUtil.ShowStatus("Opening project file " & pFilename, pStatus, MethodBase.GetCurrentMethod.Name)
            If My.Computer.FileSystem.FileExists(pFilename) = True Then
                CreateProjectArtifactsFromFileContents(pFilename, pStatus)
                LogUtil.ShowStatus("Project Loaded OK", pStatus, MethodBase.GetCurrentMethod.Name)
            Else
                LogUtil.ShowStatus("Project file not found", pStatus, MethodBase.GetCurrentMethod.Name)
            End If
        Else
            LogUtil.ShowStatus("No project file selected", pStatus)
        End If
    End Sub

    Private Sub CreateProjectArtifactsFromFileContents(pFilename As String, ByRef pStatus As ToolStripStatusLabel)
        Dim _projectStrings As List(Of String) = ExtractDesignStrings(pFilename)
        For Each _string As String In _projectStrings
            Select Case True
                Case _string.StartsWith(PROJECT_HDR)
                    Dim _projectValues As String() = _string.Split(DESIGN_DELIM)
                    oFileProject = ProjectBuilder.AProject.StartingWith(_projectValues).Build
                    If Not oFileProject.IsLoaded Then
                        LogUtil.ShowStatus("Project not loaded", pStatus, MethodBase.GetCurrentMethod.Name)
                        Exit For
                    End If
                Case _string.StartsWith(DESIGN_HDR)
                    Dim _designValues As String() = _string.Split(DESIGN_DELIM)
                    oFileProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(_designValues).Build
                    If Not oFileProjectDesign.IsLoaded Then
                        LogUtil.ShowStatus("Design not loaded", pStatus, MethodBase.GetCurrentMethod.Name)
                        Exit For
                    End If
                Case _string.StartsWith(PROJECT_THREADS_HDR)
                    Dim _threadStrings As String() = _string.Trim(BLOCK_DELIM).Split(BLOCK_DELIM)
                    oFileProjectThreadCollection = ProjectThreadCollectionBuilder.AProjectThreadCollection.StartingWith(_threadStrings).Build
                    If oFileProjectThreadCollection Is Nothing OrElse oFileProjectThreadCollection.Count = 0 Then
                        LogUtil.ShowStatus("No threads loaded", pStatus, MethodBase.GetCurrentMethod.Name)
                        Exit For
                    End If
                Case Else
                    LogUtil.ShowStatus("Unknown data in project file", pStatus, MethodBase.GetCurrentMethod.Name)
            End Select
        Next
    End Sub

    Public Sub SetNewProjectId(pId As Integer, ByRef pProject As Project, ByRef pProjectDesign As ProjectDesign, ByRef pProjectThreadCollection As ProjectThreadCollection)
        pProject.ProjectId = pId
        pProjectDesign.ProjectId = pId
        For Each _stitch As Stitch In pProjectDesign.BackStitches
            _stitch._projectId = pId
        Next
        For Each _stitch As Stitch In pProjectDesign.BlockStitches
            _stitch._projectId = pId
        Next
        For Each _stitch As Stitch In pProjectDesign.Knots
            _stitch._projectId = pId
        Next
        For Each _thread As ProjectThread In pProjectThreadCollection.Threads
            _thread.ProjectId = pId
        Next
    End Sub
    Public Sub InsertProjectThreadCollection(pThreadCollection As ProjectThreadCollection)
        For Each _thread As ProjectThread In pThreadCollection.Threads
            If Not FindProjectThread(_thread.ProjectId, _thread.ThreadId).IsLoaded Then
                AddNewProjectThread(_thread)
            End If
        Next
    End Sub
    Public Sub LoadProjectList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.LogInfo("Load project list", pBaseName)
        pDgv.Rows.Clear()
        For Each oProject As Project In GetProjectList()
            AddProjectRow(pDgv, oProject)
        Next
        pDgv.ClearSelection()
    End Sub

    Private Sub AddProjectRow(ByRef pDgv As DataGridView, oProject As Project)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        oRow.Cells(pDgv.Columns(0).Name).Value = oProject.ProjectId
        oRow.Cells(pDgv.Columns(1).Name).Value = oProject.ProjectName
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
    Public Function StartProjectTimer(pProject As Project) As String
        Dim _rtnMsg As String
        If pProject.IsLoaded Then
            If oTimerForm Is Nothing OrElse oTimerForm.IsDisposed Then
                oTimerForm = New FrmProjectTimer
            End If
            oTimerForm.Project = pProject
            oTimerForm.Show()
            oTimerForm.TopMost = True
            _rtnMsg = "Timer started"
        Else
            _rtnMsg = "No project selected"
        End If
        Return _rtnMsg
    End Function
    Public Sub CloseTimer()
        If oTimerForm IsNot Nothing AndAlso Not oTimerForm.IsDisposed Then
            oTimerForm.Close()
        End If
    End Sub
End Module