' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Imaging.ImageUtil
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmThreadSymbols
#Region "properties"
    Private _selectedProject As Project
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
    Private iSelectedSymbolId As Integer
    Private oSelectedSymbol As Symbol

#End Region
#Region "form handlers"
    Private Sub FrmThreadSymbols_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Project thread symbols", MyBase.Name)
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.ProjectThreadSymbolsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub DgvThreads_SelectionChanged(sender As Object, e As EventArgs) Handles DgvThreads.SelectionChanged
        If DgvThreads.SelectedRows.Count > 0 Then
            Dim _row As DataGridViewRow = DgvThreads.SelectedRows(0)
            Dim _thread As Thread = GetThreadById(_row.Cells(threadId.Name).Value)
            Dim _symbolPicbox As PictureBox = FindSymbolInTable(_thread.ThreadId)
            If _symbolPicbox IsNot Nothing Then
                _symbolPicbox.BackColor = Color.LightGreen
            End If
        End If
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        For Each _row As DataGridViewRow In DgvThreads.Rows
            Dim _threadId As Integer = _row.Cells(threadId.Name).Value
            Dim _symbolId As Integer = _row.Cells(threadsymbolid.Name).Value
            If _symbolId > 0 Then
                UpdateProjectThreadSymbolId(_selectedProject.ProjectId, _threadId, _symbolId)
            ElseIf _symbolId = 0 Then
                UpdateProjectThreadSymbolId(_selectedProject.ProjectId, _threadId, -1)
            End If
        Next
    End Sub
    Private Sub BtnClearSymbol_Click(sender As Object, e As EventArgs) Handles BtnClearSymbol.Click
        If DgvThreads.SelectedRows.Count > 0 Then
            Dim _row As DataGridViewRow = DgvThreads.SelectedRows(0)
            Dim _symbolId As Integer = _row.Cells(threadsymbolid.Name).Value
            _row.Cells(threadsymbolid.Name).Value = 0
            _row.Cells(threadsymbol.Name).Value = New Bitmap(1, 1)
            SetSymbolColours()
        End If
    End Sub
#End Region
#Region "functions"
    Private Sub InitialiseForm()
        isLoading = True
        GetFormPos(Me, My.Settings.ProjectThreadSymbolsFormPos)
        LblProjectName.Text = _selectedProject.ProjectName
        LoadSymbols(FlpSymbols)
        LoadThreadList()
        isLoading = False

    End Sub
    Private Sub LoadSymbols(ByRef pFlp As FlowLayoutPanel)
        ClearSymbolTable(pFlp)
        Dim _symbols As List(Of Symbol) = GetAllSymbols()
        For Each _symbol As Symbol In _symbols
            Dim _picBox As PictureBox = AddSymbolToTable(pFlp, _symbol)
            AddHandler _picBox.Click, AddressOf Symbol_Click
        Next
    End Sub
    Private Sub Symbol_Click(sender As Object, e As EventArgs)
        Dim _picBox As PictureBox = CType(sender, PictureBox)
        iSelectedSymbolId = CInt(_picBox.Name)
        oSelectedSymbol = GetSymbolById(iSelectedSymbolId)
        _picBox.BackColor = Color.LightGreen
        If DgvThreads.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvThreads.SelectedRows(0)
            Dim symcell As DataGridViewImageCell = CType(oRow.Cells(threadsymbol.Name), DataGridViewImageCell)
            Dim _symbol As Symbol = GetSymbolById(iSelectedSymbolId)
            symcell.Value = ResizeImage(_symbol.SymbolImage, symcell.Size.Height, symcell.Size.Height)
            oRow.Cells(threadsymbolid.Name).Value = iSelectedSymbolId
            SetSymbolColours()
        End If
    End Sub
    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load ProjectThread list", MyBase.Name)
        Dim _usedThreadList As List(Of ProjectThread) = GetProjectThreads(_selectedProject.ProjectId)
        _usedThreadList.Sort(Function(x As ProjectThread, y As ProjectThread) x.Thread.SortNumber.CompareTo(y.Thread.SortNumber))
        DgvThreads.Rows.Clear()
        For Each oThread As ProjectThread In _usedThreadList
            Dim _index = AddProjectThreadSymbolRow(DgvThreads, oThread)
            Dim _symbolBox As PictureBox = FindSymbolInTable(oThread.SymbolId)
            If _symbolBox IsNot Nothing Then
                If _symbolBox.BackColor = Color.LightGreen Then
                    _symbolBox.BackColor = Color.Red
                Else
                    _symbolBox.BackColor = Color.LightGreen
                End If
            End If
        Next
        DgvThreads.ClearSelection()
    End Sub
    Private Function AddProjectThreadSymbolRow(ByRef pDgv As DataGridView, pThread As ProjectThread) As Integer
        Dim oRow As DataGridViewRow = NewProjectThreadSymbolRow(pDgv, pThread)
        Return oRow.Index
    End Function
    Private Function NewProjectThreadSymbolRow(pDgv As DataGridView, pThread As ProjectThread) As DataGridViewRow
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread.Thread
            oRow.Cells(threadId.Name).Value = .ThreadId
            oRow.Cells(threadName.Name).Value = .ColourName
            LoadColourCell(pDgv, oRow, threadColour.Name, pThread.Thread, False)
            oRow.Cells(threadSortNumber.Name).Value = .SortNumber
            oRow.Cells(ThreadNo.Name).Value = .ThreadNo
            SetThreadImageInRow(pThread.SymbolId, oRow)
        End With
        Return oRow
    End Function

    Private Sub SetThreadImageInRow(pSymbolId As Integer, ByRef pRow As DataGridViewRow)
        Dim symcell As DataGridViewImageCell = CType(pRow.Cells(threadsymbol.Name), DataGridViewImageCell)
        Dim _symbol As Symbol = GetSymbolById(pSymbolId)
        symcell.Style.Padding = New Padding(1)
        symcell.Value = ResizeImage(_symbol.SymbolImage, symcell.Size.Height, symcell.Size.Height)
        pRow.Cells(threadsymbolid.Name).Value = pSymbolId
    End Sub

    Private Function FindSymbolInTable(pSymbolId As Integer) As PictureBox
        Dim _foundSymbol As PictureBox = Nothing
        For Each _ctrl As Control In FlpSymbols.Controls
            Dim _picBox As PictureBox = TryCast(_ctrl, PictureBox)
            If _picBox IsNot Nothing AndAlso _picBox.Name = CStr(pSymbolId) Then
                _foundSymbol = _picBox
                Exit For
            End If
        Next
        Return _foundSymbol
    End Function
    Private Sub SetSymbolColours()
        For Each _ctrl As Control In FlpSymbols.Controls
            Dim _picBox As PictureBox = TryCast(_ctrl, PictureBox)
            If _picBox IsNot Nothing Then
                _picBox.BackColor = Color.White
            End If
        Next
        For Each _row As DataGridViewRow In DgvThreads.Rows
            Dim _symbolId = _row.Cells(threadsymbolid.Name).Value
            If _symbolId > 0 Then
                Dim _controls As Control() = FlpSymbols.Controls.Find(CStr(_symbolId), False)
                If _controls.Length > 0 Then
                    Dim _symbolBox As PictureBox = TryCast(_controls(0), PictureBox)
                    If _symbolBox IsNot Nothing Then
                        If _symbolBox.BackColor = Color.LightGreen Then
                            _symbolBox.BackColor = Color.Red
                        Else
                            _symbolBox.BackColor = Color.LightGreen
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub BtnAuto_Click(sender As Object, e As EventArgs) Handles BtnAuto.Click
        Randomize()
        For Each _row As DataGridViewRow In DgvThreads.Rows
            Dim _symbolId = _row.Cells(threadsymbolid.Name).Value
            If _symbolId <= 0 Then
                _symbolId = FindRandomAvailableSymbol()
                _row.Cells(threadsymbolid.Name).Value = _symbolId
                SetThreadImageInRow(_symbolId, _row)
                SetSymbolColours()
            End If
        Next
    End Sub

    Private Function FindRandomAvailableSymbol() As Integer
        Dim _list As List(Of PictureBox) = GetAvailableSymbols()
        Dim index As Integer = CInt(Math.Floor((_list.Count) * Rnd()))
        Return CInt(_list(index).Name)
    End Function

    Private Function GetAvailableSymbols() As List(Of PictureBox)
        Dim _list As New List(Of PictureBox)
        For Each _ctrl As Control In FlpSymbols.Controls
            Dim _picBox As PictureBox = TryCast(_ctrl, PictureBox)
            If _picBox IsNot Nothing Then
                If _picBox.BackColor = Color.White Then
                    _list.Add(_picBox)
                End If
            End If
        Next
        Return _list
    End Function
#End Region
End Class