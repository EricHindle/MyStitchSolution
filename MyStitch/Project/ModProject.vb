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
    Public Function OpenProjectFile(pFilename As String) As String
        Dim oReply As String = "Project Loaded OK"
        LogUtil.LogInfo("Opening project file " & pFilename, MethodBase.GetCurrentMethod.Name)
        If Not String.IsNullOrEmpty(pFilename) Then
            If My.Computer.FileSystem.FileExists(pFilename) = True Then
                Dim _projectStrings As List(Of String) = ExtractDesignStrings(pFilename)
                For Each _string As String In _projectStrings
                    Select Case True
                        Case _string.StartsWith(PROJECT_HDR)
                            oProject = ProjectBuilder.AProject.StartingWith(_string.Split(DESIGN_DELIM)).Build
                            If Not oProject.IsLoaded Then
                                oReply = "Project not loaded"
                                Exit For
                            End If
                        Case _string.StartsWith(DESIGN_HDR)
                            oProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(_string).Build
                            If Not oProjectDesign.IsLoaded Then
                                oReply = "Design not loaded"
                                Exit For
                            End If
                        Case _string.StartsWith(PROJECT_THREADS_HDR)
                            Dim _threadStrings As String() = _string.Trim(BLOCK_DELIM).Split(BLOCK_DELIM)
                            oProjectThreads = ProjectThreadCollectionBuilder.AProjectThreadCollection.StartingWith(_threadStrings).Build
                            If oProjectThreads Is Nothing OrElse oProjectThreads.Count = 0 Then
                                oReply = "No threads loaded"
                                Exit For
                            End If
                        Case Else
                            oReply = "Unknown data in project file"
                    End Select
                Next
            Else
                oReply = "Project file not found"
            End If
        Else
            oReply = "No project file selected"
        End If
        Return oReply
    End Function
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