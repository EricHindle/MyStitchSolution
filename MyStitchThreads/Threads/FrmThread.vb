' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging


Public Class FrmThread
#Region "properties"

#End Region
#Region "constants"
#End Region
#Region "variables"
    Private _selectedThread As New Thread
    Private isLoading As Boolean
#End Region
#Region "handlers"
    Private Sub FrmThread_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Thread maintenence", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmThread_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)

        My.Settings.ThreadFormPos = SetFormPos(Me)
        My.Settings.Save()

    End Sub

    Private Sub DgvBooks_SelectionChanged(sender As Object, e As EventArgs) Handles DgvThreads.SelectionChanged
        If Not isLoading Then
            If DgvThreads.SelectedRows.Count = 1 Then
                _selectedThread = GetThreadById(DgvThreads.SelectedRows(0).Cells(threadId.Name).Value)
            Else
                _selectedThread = ThreadBuilder.AThread.StartingWithNothing.Build
            End If
            LoadThreadForm(_selectedThread)
        End If
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        InsertNewThread()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        UpdateSelectedThread()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelectedThread()
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearThreadForm()
        DgvThreads.ClearSelection()
    End Sub
#End Region
#Region "functions"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.ThreadFormPos)
        LoadThreadList()
        ClearThreadForm()
    End Sub
    Private Sub ClearThreadForm()
        DgvThreads.ClearSelection()
        LblId.Text = _selectedThread.ThreadId
        TxtName.Text = ""
        TxtNumber.Text = ""
        NudR.Value = 0
        NudG.Value = 0
        NudB.Value = 0
        Dim _colour As Color = Color.White
        LblColour.BackColor = _colour
    End Sub

    Private Sub LoadThreadForm(oThread As Thread)
        _selectedThread = oThread
        LblId.Text = _selectedThread.ThreadId
        TxtName.Text = oThread.ColourName
        TxtNumber.Text = CStr(oThread.ThreadNo)
        Dim _colour As Color = oThread.Colour
        LblColour.BackColor = _colour
        NudR.Value = _colour.R
        NudG.Value = _colour.G
        NudB.Value = _colour.B
    End Sub

    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load Thread list", MyBase.Name)
        DgvThreads.Rows.Clear()
        For Each oThread As Thread In GetThreads()
            AddThreadRow(oThread)
        Next
        DgvThreads.ClearSelection()
    End Sub
    Private Sub SelectThreadInList(_ThreadId As Integer)
        For Each orow As DataGridViewRow In DgvThreads.Rows
            If orow.Cells(threadId.Name).Value = _ThreadId Then
                orow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Private Function BuildThreadFromForm(pId As Integer) As Thread
        Dim _Thread As Thread = ThreadBuilder.AThread.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                    .WithColour(LblColour.BackColor) _
                                                    .WithNumber(CStr(TxtNumber.Text)) _
                                                    .Build()
        Return _Thread
    End Function
    Private Sub AddThreadRow(oThread As Thread)
        Dim oRow As DataGridViewRow = DgvThreads.Rows(DgvThreads.Rows.Add())
        oRow.Cells(threadId.Name).Value = oThread.ThreadId
        oRow.Cells(threadName.Name).Value = oThread.ColourName
        oRow.Cells(threadColour.Name).Style.BackColor = oThread.Colour
        oRow.Cells(ThreadNo.Name).Value = oThread.ThreadNo
    End Sub
    Friend Sub SaveThread()
        If _selectedThread.ThreadId >= 0 Then
            UpdateSelectedThread()
        Else
            InsertNewThread()
        End If
    End Sub
    Private Sub InsertNewThread()
        LogUtil.LogInfo("New Thread", MyBase.Name)
        Dim _Thread As Thread = BuildThreadFromForm(_selectedThread.ThreadId)
        _Thread.ThreadId = InsertThread(_Thread)
        LoadThreadList()
        '     SelectThreadInList(_Thread.ThreadId)
        LogUtil.ShowStatus("Thread Added", LblStatus, MyBase.Name)
    End Sub
    Private Sub UpdateSelectedThread()
        If _selectedThread.ThreadId >= 0 Then
            LogUtil.LogInfo("Updating Thread", MyBase.Name)
            Dim _Thread As Thread = BuildThreadFromForm(_selectedThread.ThreadId)
            UpdateThread(_Thread)
            LoadThreadList()
            SelectThreadInList(_selectedThread.ThreadId)
            LogUtil.ShowStatus("Thread updated", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No Thread selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Friend Sub DeleteSelectedThread()
        If _selectedThread.ThreadId >= 0 Then
            LogUtil.LogInfo("Delete Thread", MyBase.Name)

            DeleteThread(_selectedThread)
            ClearThreadForm()
            LoadThreadList()
        Else
            LogUtil.ShowStatus("No Thread selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub

    Private Sub RGB_ValueChanged(sender As Object, e As EventArgs) Handles NudR.ValueChanged, NudG.ValueChanged, NudB.ValueChanged,
             NudR.TextChanged, NudG.TextChanged, NudB.TextChanged

        Dim _newColor As Color = Color.FromArgb(NudR.Value, NudG.Value, NudB.Value)
        LblColour.BackColor = _newColor
    End Sub



#End Region

End Class