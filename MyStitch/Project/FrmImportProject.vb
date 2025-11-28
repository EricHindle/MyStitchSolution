' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Net.Mime.MediaTypeNames
Imports System.Reflection
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Imports MyStitch.Domain
Imports System.IO
Public Class FrmImportProject
#Region "properties"
    Private _projectFilename As String
    Private _isImportComplete As Boolean
    Private _isDuplicateProject As Boolean
    Public Property IsDuplicateProject() As Boolean
        Get
            Return _isDuplicateProject
        End Get
        Set(ByVal value As Boolean)
            _isDuplicateProject = value
        End Set
    End Property
    Public Property IsImportComplete() As Boolean
        Get
            Return _isImportComplete
        End Get
        Set(ByVal value As Boolean)
            _isImportComplete = value
        End Set
    End Property
    Public Property ProjectFilename() As String
        Get
            Return _projectFilename
        End Get
        Set(ByVal value As String)
            _projectFilename = value
        End Set
    End Property
#End Region
#Region "variables"
    Private isLoading As Boolean
#End Region
#Region "form control handlers"
    Private Sub FrmProjectThreads_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Project threads", MyBase.Name)
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        SaveFormLayout()
    End Sub

#End Region
#Region "functions"
    Private Sub InitialiseForm()
        RestoreFormLayout()
        isLoading = True
        BtnReplace.Visible = False
        With oFileProject
            TxtFilename.Text = _projectFilename
            LblSelectedProject.Text = .ProjectName
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
            If _isDuplicateProject Then
                LblInstruction.Text = "Project" & vbCrLf & .ProjectId & vbCrLf & "<<" & .ProjectName & ">>" & vbCrLf & "already exists"
                BtnReplace.Visible = True
                LogUtil.LogInfo(LblInstruction.Text, MyBase.Name)
            Else
                LblInstruction.Text = "Importing new project " & .ProjectName
            End If

        End With
        LoadThreadList()
        LoadBeadList()

        _isImportComplete = False
        isLoading = False
    End Sub
    Private Sub SaveFormLayout()
        If SplitContainer1.SplitterDistance > 0 Then My.Settings.SplitDistImportDesign1 = SplitContainer1.SplitterDistance
        My.Settings.ImportDesignFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub RestoreFormLayout()
        GetFormPos(Me, My.Settings.ImportDesignFormPos)
        SplitContainer1.SplitterDistance = My.Settings.SplitDistImportDesign1
    End Sub
    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load ProjectThread list", MyBase.Name)
        DgvThreads.Rows.Clear()
        For Each oThread As ProjectThread In oFileProjectThreadCollection.Threads
            AddProjectThreadRow(DgvThreads, oThread.Thread, False, False, False)
        Next
        DgvThreads.ClearSelection()
    End Sub
    Private Sub LoadBeadList()
        LogUtil.LogInfo("Load ProjectBead list", MyBase.Name)
        DgvBeads.Rows.Clear()
        For Each oBead As ProjectBead In oFileProjectBeadCollection.Beads
            AddProjectBeadRow(DgvBeads, oBead.Thread, False, False, False)
        Next
        DgvBeads.ClearSelection()
    End Sub

    Private Sub BtnImportNew_Click(sender As Object, e As EventArgs) Handles BtnImportNew.Click
        InsertNewProject()
        IsImportComplete = True
        Close()
    End Sub

    Private Sub BtnReplace_Click(sender As Object, e As EventArgs) Handles BtnReplace.Click
        AddProjectThreads()
        AddProjectBeads()
        AmendProject(oFileProject)
        TryCopyFile(_projectFilename, Path.Combine(oDesignFolderName, oFileProject.DesignFileName & DESIGN_ZIP_EXT), True)
        Close()
    End Sub

    Private Sub InsertNewProject()
        LogUtil.LogInfo("New project", MethodBase.GetCurrentMethod.Name)
        oProject = BuildProject(oFileProject)
        oProject.ProjectId = AddNewProject(oProject)
        oProjectDesign = ReplaceDesignProjectId(oFileProjectDesign, oProject.ProjectId)
        oProjectThreads = ReplaceThreadsProjectId(oFileProjectThreadCollection, oProject.ProjectId)
        oProjectBeads = ReplaceBeadsProjectId(oFileProjectBeadCollection, oProject.ProjectId)
        AddProjectThreads()
        AddProjectBeads()
        SaveDesign()
        LblInstruction.Text = PROJECT_ADDED
    End Sub

    Private Sub AddProjectBeads()
        For Each oBead As ProjectBead In oFileProjectBeadCollection.Beads
            Dim _bead As ProjectBead = FindProjectBead(oBead.ProjectId, oBead.BeadId)
            If Not _bead.IsLoaded Then
                AddNewProjectBead(oBead)
            End If
        Next
    End Sub

    Private Sub AddProjectThreads()
        For Each oThread As ProjectThread In oFileProjectThreadCollection.Threads
            Dim _thread As ProjectThread = FindProjectThread(oThread.ProjectId, oThread.ThreadId)
            If Not _thread.IsLoaded Then
                AddNewProjectThread(oThread)
            End If
        Next
    End Sub

    Private Function ReplaceBeadsProjectId(pFileProjectBeadCollection As ProjectBeadCollection, pProjectId As Integer) As ProjectBeadCollection
        For Each _bead As ProjectBead In pFileProjectBeadCollection.Beads
            _bead.ProjectId = pProjectId
        Next
        Return pFileProjectBeadCollection
    End Function

    Private Function ReplaceThreadsProjectId(pFileProjectThreadCollection As ProjectThreadCollection, pProjectId As Integer) As ProjectThreadCollection
        For Each _thread As ProjectThread In pFileProjectThreadCollection.Threads
            _thread.ProjectId = pProjectId
        Next
        Return pFileProjectThreadCollection
    End Function

    Private Function ReplaceDesignProjectId(pFileProjectDesign As ProjectDesign, pProjectId As Integer) As ProjectDesign
        For Each _backstitch As BackStitch In pFileProjectDesign.BackStitches
            _backstitch.ProjectId = pProjectId
        Next
        For Each _blockstitch As BlockStitch In pFileProjectDesign.BlockStitches
            _blockstitch.ProjectId = pProjectId
        Next
        For Each _knot As Knot In pFileProjectDesign.Knots
            _knot.ProjectId = pProjectId
        Next
        Return pFileProjectDesign
    End Function

    Private Function BuildProject(pProject As Project) As Project
        Dim _project As Project = ProjectBuilder.AProject.StartingWith(pProject) _
                                                    .WithDesignFilename(String.Empty) _
                                                    .WithTotalMinutes(0) _
                                                    .WithStarted(DateTime.Now) _
                                                    .WithEnded(DateTime.Now) _
                                                    .Build()
        Return _project
    End Function



#End Region
End Class