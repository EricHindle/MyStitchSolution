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
    Private Const STOCK_NONE As Integer = 0
    Private Const STOCK_NOTMUCH As Integer = 25
    Private Const STOCK_SOME As Integer = 50
    Private Const STOCK_ENOUGH As Integer = 75
    Private Const STOCK_PLENTY As Integer = 100

#End Region
#Region "variables"
    Private _selectedThread As New Thread
    Private isLoading As Boolean
    Private _colrCap As New FrmColourCapture
    Private isShowStock As Boolean
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
        If _colrCap IsNot Nothing AndAlso Not _colrCap.IsDisposed Then
            _colrCap.Close()
        End If
        My.Settings.ThreadFormPos = SetFormPos(Me)
        My.Settings.Save()

    End Sub

    Private Sub DgvThreads_SelectionChanged(sender As Object, e As EventArgs) Handles DgvThreads.SelectionChanged
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
        isShowStock = ChkShowStock.Checked
        LoadThreadList(DgvThreads, isShowStock, MyBase.Name)
        ClearThreadForm()
    End Sub
    Private Sub ClearThreadForm()
        DgvThreads.ClearSelection()
        LblId.Text = _selectedThread.ThreadId
        TxtName.Text = ""
        TxtNumber.Text = ""
        TxtR.Text = String.Empty
        TxtG.Text = String.Empty
        TxtB.Text = String.Empty
        Dim _colour As Color = Color.White
        LblColour.BackColor = _colour
    End Sub

    Private Sub LoadThreadForm(oThread As Thread)
        _selectedThread = oThread
        LblId.Text = _selectedThread.ThreadId
        TxtName.Text = oThread.ColourName
        TxtNumber.Text = CStr(oThread.ThreadNo)
        Dim _colour As Color = oThread.Colour
        Select Case oThread.StockLevel
            Case < STOCK_NOTMUCH
                RbNone.Checked = True
            Case < STOCK_SOME
                RbNotMuch.Checked = True
            Case < STOCK_ENOUGH
                RbSome.Checked = True
            Case < STOCK_PLENTY
                RbEnough.Checked = True
            Case Else
                RbPlenty.Checked = True
        End Select
        SetFormColour(_colour)
    End Sub

    Private Sub SetFormColour(_colour As Color)
        LblColour.BackColor = _colour
        TxtR.Text = CStr(_colour.R)
        TxtG.Text = CStr(_colour.G)
        TxtB.Text = CStr(_colour.B)
    End Sub

    Private Function BuildThreadFromForm(pId As Integer) As Thread
        Dim _Thread As Thread = ThreadBuilder.AThread.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                    .WithColour(LblColour.BackColor) _
                                                    .WithNumber(TxtNumber.Text) _
                                                    .WithStockLevel(CalcStock) _
                                                    .Build()
        Return _Thread
    End Function
    Private Function CalcStock() As Integer
        Dim _level As Integer
        Select Case True
            Case RbNone.Checked
                _level = STOCK_NONE
            Case RbNotMuch.Checked
                _level = STOCK_NOTMUCH
            Case RbSome.Checked
                _level = STOCK_SOME
            Case RbEnough.Checked
                _level = STOCK_ENOUGH
            Case RbPlenty.Checked
                _level = STOCK_PLENTY
        End Select
        Return _level

    End Function

    Private Sub InsertNewThread()
        LogUtil.LogInfo("New Thread", MyBase.Name)
        Dim _existingthread As Thread = GetThreadbyNumber(TxtNumber.Text.Trim)
        If _existingthread.ThreadId > 0 Then
            LogUtil.DisplayStatus("Thread with this number already exists.", LblStatus, "Insert New Thread", True)
        Else
            Dim _Thread As Thread = BuildThreadFromForm(_selectedThread.ThreadId)
            _Thread.ThreadId = InsertThread(_Thread)
            LoadThreadList(DgvThreads, isShowStock, MyBase.Name)
            LogUtil.ShowStatus("Thread Added", LblStatus, MyBase.Name)
        End If
    End Sub
    Private Sub UpdateSelectedThread()
        If _selectedThread.ThreadId >= 0 Then
            LogUtil.LogInfo("Updating Thread", MyBase.Name)
            Dim _rowNo As Integer = DgvThreads.SelectedRows(0).Index - DgvThreads.FirstDisplayedCell.RowIndex
            Dim _Thread As Thread = BuildThreadFromForm(_selectedThread.ThreadId)
            UpdateThread(_Thread)
            LoadThreadList(DgvThreads, isShowStock, MyBase.Name)
            SelectThreadInList(DgvThreads, threadId.Name, _Thread.ThreadId, _rowNo)
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
            LoadThreadList(DgvThreads, isShowStock, MyBase.Name)
        Else
            LogUtil.ShowStatus("No Thread selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub

    Private Sub RGB_ValueChanged(sender As Object, e As EventArgs) Handles TxtR.TextChanged, TxtG.TextChanged, TxtB.TextChanged
        If IsNumeric(TxtR.Text) AndAlso IsNumeric(TxtG.Text) AndAlso IsNumeric(TxtB.Text) Then
            Dim _newColor As Color = Color.FromArgb(CInt(TxtR.Text), CInt(TxtG.Text), CInt(TxtB.Text))
            LblColour.BackColor = _newColor
        End If
    End Sub

    Private Sub BtnColourCapture_Click(sender As Object, e As EventArgs) Handles BtnColourCapture.Click
        If _colrCap Is Nothing OrElse _colrCap.IsDisposed Then
            _colrCap = New FrmColourCapture
        End If
        _colrCap.Show()
    End Sub

    Private Sub BtnGetColour_Click(sender As Object, e As EventArgs) Handles BtnGetColour.Click
        Dim _color As Color = _colrCap.SelectedColour
        SetFormColour(_color)
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        SelectThreadInList(DgvThreads, ThreadNo.Name, TxtNumber.Text)
    End Sub

    Private Sub ChkShowStock_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowStock.CheckedChanged
        isShowStock = ChkShowStock.Checked
        LoadThreadList(DgvThreads, isShowStock, MyBase.Name)
    End Sub

#End Region

End Class