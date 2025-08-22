' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Objects
Imports MyStitch.Domain
Public Class FrmDesignInfo
#Region "properties"
    Private _selectedProject As Project
    Private _projectDesign As ProjectDesign
    Public Property Design() As ProjectDesign
        Get
            Return _projectDesign
        End Get
        Set(ByVal value As ProjectDesign)
            _projectDesign = value
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
#Region "variables"
    Private isLoading As Boolean
    Private isShowStock As Boolean
    Private iBlockCount As Integer
    Private iBackCount As Integer
    Private iKnotCount As Integer
    Private iBeadCount As Integer
    Private iFullCount As Integer
    Private iHalfCount As Integer
    Private iQuarterCount As Integer
    Private iMixedCount As Integer
    Private iThreeQuarterCount As Integer
    Private iTotalBackStitchLength As Double
    Private FABRIC_COUNT As Integer
#End Region
#Region "control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmDesignInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.DesignInfoFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub FrmDesignInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("ProjectThread maintenence", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.DesignInfoFormPos)
        ChkShowStock.Checked = My.Settings.isShowStockLevels
        isShowStock = ChkShowStock.Checked
        FABRIC_COUNT = My.Settings.DefaultFabricCount
        If _selectedProject.IsLoaded Then
            LoadProjectDetails()
            LoadThreadList()
            If _projectDesign IsNot Nothing Then
                SortStitches(_projectDesign)
                LoadBlockStitchList(_projectDesign.BlockStitches)
                LoadBackStitchList(_projectDesign.BackStitches)
                LoadKnotList(_projectDesign.Knots)
                LblBlockCount.Text = CStr(iBlockCount)
                LblBackCount.Text = CStr(iBackCount)
                LblKnotCount.Text = CStr(iKnotCount)
                LblBeadCount.Text = CStr(iBeadCount)
                LblFullCount.Text = CStr(iFullCount)
                LblHalfCount.Text = CStr(iHalfCount)
                LblQtrCount.Text = CStr(iQuarterCount)
                LblThreeQtrCount.Text = CStr(iThreeQuarterCount)
                LblMixedCount.Text = CStr(iMixedCount)
                LblBackLength.Text = String.Format(LblBackLength.Text, iTotalBackStitchLength)
            Else

            End If
        End If
    End Sub

    Private Sub LoadBlockStitchList(pBlockStitches As List(Of BlockStitch))
        For Each _stitch As BlockStitch In pBlockStitches
            NewBlockstitchRow(_stitch)
            Dim oThreadRow As DataGridViewRow = FindThreadRow(_stitch.ThreadId)
            If oThreadRow IsNot Nothing Then
                oThreadRow.Cells(threadblockcount.Name).Value += 1
            End If
            iBlockCount += 1
            Select Case _stitch.StitchType
                Case BlockStitchType.Full
                    iFullCount += 1
                Case BlockStitchType.Half
                    iHalfCount += 1
                Case BlockStitchType.Quarter
                    iQuarterCount += 1
                Case BlockStitchType.ThreeQuarter
                    iThreeQuarterCount += 1
                Case BlockStitchType.Mixed
                    iMixedCount += 1
            End Select
        Next
    End Sub
    Private Sub LoadBackStitchList(pBackStitches As List(Of BackStitch))

        For Each _stitch As BackStitch In pBackStitches
            NewBackstitchRow(_stitch)
            Dim oThreadRow As DataGridViewRow = FindThreadRow(_stitch.ThreadId)
            If oThreadRow IsNot Nothing Then
                oThreadRow.Cells(threadbackcount.Name).Value += 1
            End If
            iBackCount += 1
            iTotalBackStitchLength += Math.Sqrt(Math.Pow(_stitch.ToBlockPosition.X - _stitch.FromBlockPosition.X, 2) + Math.Pow(_stitch.ToBlockPosition.Y - _stitch.FromBlockPosition.Y, 2)) / FABRIC_COUNT
        Next
    End Sub
    Private Sub LoadKnotList(pKnots As List(Of Knot))
        For Each _stitch As Knot In pKnots
            NewKnotRow(_stitch)
            Dim oThreadRow As DataGridViewRow = FindThreadRow(_stitch.ThreadId)
            If oThreadRow IsNot Nothing Then
                oThreadRow.Cells(threadknotcount.Name).Value += 1
            End If
            If _stitch.IsBead Then
                iBeadCount += 1
            Else
                iKnotCount += 1
            End If
        Next
    End Sub
    Private Sub LoadProjectDetails()
        With _selectedProject
            FABRIC_COUNT = .FabricCount
            LblName.Text = .ProjectName
            LblDesignHeight.Text = .DesignHeight
            LblDesignWidth.Text = .DesignWidth
            LblCentreX.Text = .OriginX
            LblCentreY.Text = .OriginY
            LblFabricHeight.Text = .FabricHeight
            LblFabricWidth.Text = .FabricWidth
            LblFabricCount.Text = .FabricCount
            Select Case .FabricColour
                Case 1 To 4
                    LblFabricColour.Text = oFabricColourList(.FabricColour - 1).Name
                Case Else
                    LblFabricColour.Text = .FabricColour.ToString()
            End Select
            UpdateProjectTime()
        End With
    End Sub
    Private Sub UpdateProjectTime()
        Dim _workList As List(Of ProjectWorkTime) = GetWorkPeriodsForProject(_selectedProject.ProjectId)
        Dim _startDate As DateTime = Date.MinValue
        Dim _endDate As DateTime = Date.MinValue
        Dim _timeElapsed As TimeSpan = TimeSpan.FromMinutes(_selectedProject.TotalMinutes)
        If _workList.Count > 0 Then
            _startDate = _workList.First.TimeStarted
            _endDate = _workList.Last.TimeEnded
        End If
        LblStarted.Text = If(_startDate > Date.MinValue, Format(_startDate, "dd MMM yyyy"), String.Empty)
        LblFinished.Text = If(_startDate > Date.MinValue, Format(_endDate, "dd MMM yyyy"), String.Empty)
        LblTotalTime.Text = _timeElapsed.Hours.ToString("D2") & ":" & _timeElapsed.Minutes.ToString("D2")
    End Sub
    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load ProjectThread list", MyBase.Name)
        DgvThreads.Rows.Clear()
        For Each oThread As ProjectThread In GetProjectThreads(_selectedProject.ProjectId).Threads
            NewProjectThreadRow(oThread, isShowStock)
        Next
        DgvThreads.Sort(DgvThreads.Columns(threadSortNumber.Name), ListSortDirection.Ascending)
        DgvThreads.ClearSelection()
    End Sub
    Private Function NewProjectThreadRow(pThread As ProjectThread, pIsShowStock As Boolean) As DataGridViewRow
        Dim oRow As DataGridViewRow = DgvThreads.Rows(DgvThreads.Rows.Add())
        With pThread.Thread
            oRow.Cells(threadId.Name).Value = .ThreadId
            oRow.Cells(threadName.Name).Value = .ColourName
            LoadColourCell(DgvThreads, oRow, threadColour.Name, pThread.Thread, pIsShowStock)
            oRow.Cells(threadSortNumber.Name).Value = .SortNumber
            oRow.Cells(ThreadNo.Name).Value = .ThreadNo
        End With
        Return oRow
    End Function
    Private Function NewBlockstitchRow(pStitch As BlockStitch) As DataGridViewRow
        Dim oRow As DataGridViewRow = DgvBlock.Rows(DgvBlock.Rows.Add())
        With pStitch
            oRow.Cells(block_pos_x.Name).Value = .BlockPosition.X
            oRow.Cells(block_pos_y.Name).Value = .BlockPosition.Y
            oRow.Cells(block_thread_id.Name).Value = .ThreadId
            oRow.Cells(block_thread_no.Name).Value = .ProjThread.Thread.ThreadNo
            oRow.Cells(block_symbol_id.Name).Value = .ProjThread.SymbolId
            oRow.Cells(block_type.Name).Value = .StitchType.ToString()
        End With
        Return oRow
    End Function
    Private Function NewBackstitchRow(pStitch As BackStitch) As DataGridViewRow
        Dim oRow As DataGridViewRow = DgvBack.Rows(DgvBack.Rows.Add())
        With pStitch
            oRow.Cells(back_from_x.Name).Value = .FromBlockPosition.X
            oRow.Cells(back_from_y.Name).Value = .FromBlockPosition.Y
            oRow.Cells(back_to_x.Name).Value = .ToBlockPosition.X
            oRow.Cells(back_to_y.Name).Value = .ToBlockPosition.Y
            oRow.Cells(back_thread_id.Name).Value = .ThreadId
            oRow.Cells(back_thread_no.Name).Value = .ProjThread.Thread.ThreadNo
            oRow.Cells(back_strands.Name).Value = .Strands

        End With
        Return oRow
    End Function
    Private Function NewKnotRow(pStitch As Knot) As DataGridViewRow
        Dim oRow As DataGridViewRow = DgvKnot.Rows(DgvKnot.Rows.Add())
        With pStitch
            oRow.Cells(knot_pos_x.Name).Value = .BlockPosition.X
            oRow.Cells(knot_pos_y.Name).Value = .BlockPosition.Y
            oRow.Cells(knot_thread_id.Name).Value = .ThreadId
            oRow.Cells(knot_thread_no.Name).Value = .ProjThread.Thread.ThreadNo
            oRow.Cells(knot_type.Name).Value = If(.IsBead, "Bead", "Knot")
            oRow.Cells(knot_strands.Name).Value = .Strands

        End With
        Return oRow
    End Function
    Private Function FindThreadRow(pThreadId As Integer) As DataGridViewRow
        For Each oRow As DataGridViewRow In DgvThreads.Rows
            If oRow.Cells(threadId.Name).Value = pThreadId Then
                Return oRow
            End If
        Next
        Return Nothing
    End Function

    Private Sub ChkShowStock_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowStock.CheckedChanged
        isShowStock = ChkShowStock.Checked
        LoadThreadList()
    End Sub
#End Region
End Class