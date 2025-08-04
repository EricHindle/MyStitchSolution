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
    Public MIN_DATE As New DateTime(2001, 1, 1)
    Public oTimerForm As FrmProjectTimer
    Public isSaved As Boolean = True
    Public oFileProject As Project
    Public oFileProjectDesign As ProjectDesign
    Public oFileProjectThreadCollection As ProjectThreadCollection

    Public Function SaveDesign() As String
        Dim _reply As String
        If oProject.IsLoaded Then
            If String.IsNullOrEmpty(oProject.DesignFileName) Then
                oProject.DesignFileName = MakeFilename(oProject)
                UpdateProject(oProject)
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
            If Not ArchiveExistingFile(pFilename) Then
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
    Public Sub OpenProjectFile(pFilename As String, ByRef pStatus As ToolStripStatusLabel)
        LogUtil.LogInfo("Opening project file " & pFilename, MethodBase.GetCurrentMethod.Name)
        If Not String.IsNullOrEmpty(pFilename) Then
            If My.Computer.FileSystem.FileExists(pFilename) = True Then
                Dim _projectStrings As List(Of String) = ExtractDesignStrings(pFilename)
                For Each _string As String In _projectStrings
                    Select Case True
                        Case _string.StartsWith(PROJECT_HDR)
                            Dim _projectValues As String() = _string.Split(DESIGN_DELIM)
                            oFileProject = ProjectBuilder.AProject.StartingWith(_projectValues).Build
                            If Not oFileProject.IsLoaded Then
                                LogUtil.ShowStatus("Project not loaded", pStatus)
                                Exit For
                            End If
                        Case _string.StartsWith(DESIGN_HDR)
                            Dim _designValues As String() = _string.Split(DESIGN_DELIM)
                            oFileProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(_designValues).Build
                            If Not oFileProjectDesign.IsLoaded Then
                                LogUtil.ShowStatus("Design not loaded", pStatus)
                                Exit For
                            End If
                        Case _string.StartsWith(PROJECT_THREADS_HDR)
                            Dim _threadStrings As String() = _string.Trim(BLOCK_DELIM).Split(BLOCK_DELIM)
                            oFileProjectThreadCollection = ProjectThreadCollectionBuilder.AProjectThreadCollection.StartingWith(_threadStrings).Build
                            If oFileProjectThreadCollection Is Nothing OrElse oFileProjectThreadCollection.Count = 0 Then
                                LogUtil.ShowStatus("No threads loaded", pStatus)
                                Exit For
                            End If
                        Case Else
                            LogUtil.ShowStatus("Unknown data in project file", pStatus)
                    End Select
                Next
                LogUtil.ShowStatus("Project Loaded OK", pStatus)
            Else
                LogUtil.ShowStatus("Project file not found", pStatus)
            End If
        Else
            LogUtil.ShowStatus("No project file selected", pStatus)
        End If
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
    Public Sub InsertThreadCollection(pThreadCollection As ProjectThreadCollection)
        For Each _thread As ProjectThread In pThreadCollection.Threads
            InsertProjectThread(_thread)
        Next
    End Sub
    Public Sub LoadProjectList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.LogInfo("Load project list", pBaseName)
        pDgv.Rows.Clear()
        For Each oproject As Project In GetProjects()
            AddProjectRow(pDgv, oproject)
        Next
        pDgv.ClearSelection()
    End Sub
    Public Sub SelectProjectInList(pDgv As DataGridView, pProjectId As Integer)
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells("projectId").Value = pProjectId Then
                orow.Selected = True
                Exit For
            End If
        Next
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