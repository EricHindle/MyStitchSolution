' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Class FrmPaletteMaint
#Region "variables"
    Private isLoading As Boolean
    Private _selectedPalette As Palette
#End Region
#Region "handlers"
    Private Sub FrmPalettes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Palettes", MyBase.Name)
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmPalette_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        SaveFormLayout()
    End Sub
    Private Sub DgvPalettes_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPalettes.SelectionChanged
        If Not isLoading Then
            ShowSelectedPalette()
        End If
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        UpdateSelectedPalette()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelectedPalette()
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        DgvPalettes.ClearSelection()
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click

    End Sub
    Private Sub BtnDeleteThreads_Click(sender As Object, e As EventArgs) Handles BtnDeleteThreads.Click
        If _selectedPalette IsNot Nothing Then
            For Each oRow As DataGridViewRow In DgvThreads.Rows
                Dim _check As DataGridViewCheckBoxCell = oRow.Cells(threadselected.Name)
                If _check.Value Then
                    RemovePaletteThread(_selectedPalette.PaletteId, oRow.Cells(threadId.Name).Value, 0)
                End If
            Next
            For Each orow As DataGridViewRow In DgvBeads.Rows
                Dim _check As DataGridViewCheckBoxCell = orow.Cells(beadSelected.Name)
                If _check.Value Then
                    RemovePaletteThread(_selectedPalette.PaletteId, orow.Cells(BeadId.Name).Value, 1)
                End If
            Next
            SavePaletteThreadsTable()
            ShowSelectedPalette()
        End If
    End Sub

#End Region
#Region "functions"
    Private Sub InitialiseForm()
        RestoreFormLayout()
        isLoading = True
        LoadPaletteList(DgvPalettes, MyBase.Name)
        isLoading = False
    End Sub
    Private Sub SaveFormLayout()
        If SplitContainer1.SplitterDistance > 0 Then My.Settings.SplitDistPalette1 = SplitContainer1.SplitterDistance
        My.Settings.PaletteFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub RestoreFormLayout()
        GetFormPos(Me, My.Settings.PaletteFormPos)
        SplitContainer1.SplitterDistance = My.Settings.SplitDistPalette1
    End Sub
    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load Palette list", MyBase.Name)
        Dim _paletteThreadList As List(Of PaletteThread) = FindPaletteThreadsByPaletteId(_selectedPalette.PaletteId)
        DgvThreads.Rows.Clear()
        DgvBeads.Rows.Clear()
        _paletteThreadList.Sort(Function(x As PaletteThread, y As PaletteThread) x.Thread.SortNumber.CompareTo(y.Thread.SortNumber))
        For Each oThread As PaletteThread In _paletteThreadList
            If oThread.IsBead Then
                AddPaletteBeadRow(DgvBeads, oThread)
            Else
                AddPaletteThreadRow(DgvThreads, oThread)
            End If
        Next
        DgvThreads.ClearSelection()
        DgvBeads.ClearSelection()
    End Sub
    Private Sub ShowSelectedPalette()
        If DgvPalettes.SelectedRows.Count = 1 Then
            _selectedPalette = FindPaletteById(DgvPalettes.SelectedRows(0).Cells(paletteId.Name).Value)
            TxtName.Text = _selectedPalette.PaletteName
        Else
            _selectedPalette = PaletteBuilder.APalette.StartingWithNothing.Build
            TxtName.Text = String.Empty
        End If
        LoadThreadList()
    End Sub
    Private Sub UpdateSelectedPalette()
        If _selectedPalette.PaletteId >= 0 Then
            LogUtil.LogInfo("Updating Palette", MyBase.Name)
            If Not String.IsNullOrWhiteSpace(TxtName.Text) Then
                _selectedPalette.PaletteName = TxtName.Text
                AmendPalette(_selectedPalette)
                LoadPaletteList(DgvPalettes, MyBase.Name)
                LogUtil.ShowStatus("Palette name updated", LblStatus, MyBase.Name)
            End If
        Else
            LogUtil.ShowStatus("No Palette selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Private Sub DeleteSelectedPalette()
        If _selectedPalette.PaletteId >= 0 Then
            LogUtil.LogInfo("Deleting Palette", MyBase.Name)
            RemovePalette(_selectedPalette)
            LoadPaletteList(DgvPalettes, MyBase.Name)
        Else
            LogUtil.ShowStatus("No ProjectPalette selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Private Sub LoadPaletteList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.LogInfo("Load palette list", pBaseName)
        pDgv.Rows.Clear()
        For Each oPalette As Palette In GetPaletteList()
            AddPaletteRow(pDgv, oPalette)
        Next
        pDgv.ClearSelection()
    End Sub
    Private Sub AddPaletteRow(ByRef pDgv As DataGridView, oPalette As Palette)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        oRow.Cells(paletteId.Name).Value = oPalette.PaletteId
        oRow.Cells(paletteName.Name).Value = oPalette.PaletteName
    End Sub
    Private Sub AddPaletteThreadRow(ByRef pDgv As DataGridView, pThread As PaletteThread)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells("threadId").Value = .ThreadId
            oRow.Cells("threadName").Value = .Thread.ColourName
            LoadColourCell(pDgv, oRow, threadColour.Name, .Thread, False)
            oRow.Cells("threadSortNumber").Value = .Thread.SortNumber
            oRow.Cells("threadNo").Value = .Thread.ThreadNo
        End With
    End Sub
    Private Sub AddPaletteBeadRow(ByRef pDgv As DataGridView, pThread As PaletteThread)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells(BeadId.Name).Value = .ThreadId
            oRow.Cells(BeadName.Name).Value = .Thread.ColourName
            LoadColourCell(pDgv, oRow, BeadColour.Name, .Thread, False)
            oRow.Cells(BeadSortNumber.Name).Value = .Thread.SortNumber
            oRow.Cells(BeadNo.Name).Value = .Thread.ThreadNo
        End With
    End Sub
#End Region
End Class