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
        CreatePalette()
    End Sub
    Private Sub BtnDeleteThreads_Click(sender As Object, e As EventArgs) Handles BtnDeleteThreads.Click
        DgvPaletteBeads.Rows.Clear()
        DgvPaletteThreads.Rows.Clear()
    End Sub
    Private Sub BtnRemoveThread_Click(sender As Object, e As EventArgs) Handles BtnRemoveThread.Click
        For Each oRow As DataGridViewRow In DgvPaletteThreads.SelectedRows
            DgvPaletteThreads.Rows.Remove(oRow)
        Next
        DgvPaletteThreads.ClearSelection()
    End Sub
    Private Sub BtnRemoveBead_Click(sender As Object, e As EventArgs) Handles BtnRemoveBead.Click
        For Each oRow As DataGridViewRow In DgvPaletteBeads.SelectedRows
            DgvPaletteBeads.Rows.Remove(oRow)
        Next
        DgvPaletteBeads.ClearSelection()
    End Sub
    Private Sub TxtThreadNumber_TextChanged(sender As Object, e As EventArgs) Handles TxtThreadNumber.TextChanged
        If Not String.IsNullOrWhiteSpace(TxtThreadNumber.Text) Then
            SelectThreadInList(DgvThreadList, ListThreadNo.Name, TxtThreadNumber.Text)
        End If
    End Sub
    Private Sub TxtBeadNumber_TextChanged(sender As Object, e As EventArgs) Handles TxtBeadNumber.TextChanged
        If Not String.IsNullOrWhiteSpace(TxtBeadNumber.Text) Then
            SelectThreadInList(DgvBeadList, ListBeadNo.Name, TxtBeadNumber.Text)
        End If
    End Sub
    Private Sub DgvPaletteThreads_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPaletteThreads.CellDoubleClick
        Dim oRow As DataGridViewRow = DgvPaletteThreads.Rows(e.RowIndex)
        DgvPaletteThreads.Rows.Remove(oRow)
    End Sub
    Private Sub DgvPaletteBeads_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPaletteBeads.CellDoubleClick
        Dim oRow As DataGridViewRow = DgvPaletteBeads.Rows(e.RowIndex)
        DgvPaletteBeads.Rows.Remove(oRow)
    End Sub
    Private Sub DgvThreadList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvThreadList.CellDoubleClick
        Dim oRow As DataGridViewRow = DgvThreadList.Rows(e.RowIndex)
        AddThreadToPaletteList(DgvPaletteThreads, ListThreadId.Name, oRow)
        DgvThreadList.ClearSelection()
    End Sub
    Private Sub DgvBeadList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvBeadList.CellDoubleClick
        Dim oRow As DataGridViewRow = DgvBeadList.Rows(e.RowIndex)
        AddBeadToPaletteList(DgvPaletteBeads, ListBeadId.Name, oRow)
        DgvBeadList.ClearSelection()
    End Sub
    Private Sub BtnAddThread_Click(sender As Object, e As EventArgs) Handles BtnAddThread.Click
        For Each oRow As DataGridViewRow In DgvThreadList.Rows
            If oRow.Cells(listthreadsel.Name).Value Then
                AddThreadToPaletteList(DgvPaletteThreads, ListThreadId.Name, oRow)
                oRow.Cells(listthreadsel.Name).Value = False
            End If
        Next
        DgvThreadList.ClearSelection()
    End Sub
    Private Sub BtnAddBead_Click(sender As Object, e As EventArgs) Handles BtnAddBead.Click
        For Each oRow As DataGridViewRow In DgvBeadList.Rows
            If oRow.Cells(listbeadsel.Name).Value Then
                AddBeadToPaletteList(DgvPaletteBeads, ListBeadId.Name, oRow)
                oRow.Cells(listbeadsel.Name).Value = False
            End If
        Next
        DgvBeadList.ClearSelection()
    End Sub
#End Region
#Region "functions"
    Private Sub InitialiseForm()
        RestoreFormLayout()
        isLoading = True
        LoadPaletteList(DgvPalettes, MyBase.Name)
        ShowSelectedPalette()
        isLoading = False
    End Sub
    Private Sub SaveFormLayout()
        If SplitContainer1.SplitterDistance > 0 Then My.Settings.SplitDistPalette1 = SplitContainer1.SplitterDistance
        If SplitContainer2.SplitterDistance > 0 Then My.Settings.SplitDistPalette2 = SplitContainer2.SplitterDistance
        If SplitContainer3.SplitterDistance > 0 Then My.Settings.SplitDistPalette3 = SplitContainer3.SplitterDistance
        My.Settings.PaletteFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub RestoreFormLayout()
        GetFormPos(Me, My.Settings.PaletteFormPos)
        SplitContainer1.SplitterDistance = My.Settings.SplitDistPalette1
        SplitContainer2.SplitterDistance = My.Settings.SplitDistPalette2
        SplitContainer3.SplitterDistance = My.Settings.SplitDistPalette3
    End Sub
    Private Sub LoadThreadList()
        LogUtil.Debug("Load thread lists", MyBase.Name)
        Dim _paletteThreadList As List(Of PaletteThread) = FindPaletteThreadsByPaletteId(_selectedPalette.PaletteId)
        Dim _fullThreadList As List(Of Thread) = FindThreads()
        Dim _fullBeadList As List(Of Bead) = FindBeads()
        DgvThreadList.Rows.Clear()
        DgvBeadList.Rows.Clear()
        DgvPaletteBeads.Rows.Clear()
        DgvPaletteThreads.Rows.Clear()
        _paletteThreadList.Sort(Function(x As PaletteThread, y As PaletteThread) x.Thread.SortNumber.CompareTo(y.Thread.SortNumber))
        _fullThreadList.Sort(Function(x As Thread, y As Thread) x.SortNumber.CompareTo(y.SortNumber))
        _fullBeadList.Sort(Function(x As Bead, y As Bead) x.SortNumber.CompareTo(y.SortNumber))
        For Each oThread As PaletteThread In _paletteThreadList
            If oThread.IsBead Then
                AddBeadRowFromPaletteThread(DgvPaletteBeads, oThread)
            Else
                AddThreadRowFromPaletteThread(DgvPaletteThreads, oThread)
            End If
        Next
        For Each oThread As Thread In _fullThreadList
            AddThreadListRow(DgvThreadList, oThread)
        Next
        For Each oBead As Bead In _fullBeadList
            AddBeadListRow(DgvBeadList, oBead)
        Next
        DgvPaletteThreads.ClearSelection()
        DgvPaletteBeads.ClearSelection()
        DgvThreadList.ClearSelection()
        DgvBeadList.ClearSelection()
    End Sub
    Private Sub ShowSelectedPalette()
        If DgvPalettes.SelectedRows.Count = 1 Then
            _selectedPalette = FindPaletteById(DgvPalettes.SelectedRows(0).Cells(paletteId.Name).Value)
            LblPaletteName.Text = _selectedPalette.PaletteName
        Else
            _selectedPalette = PaletteBuilder.APalette.StartingWithNothing.Build
            LblPaletteName.Text = String.Empty
        End If
        LoadThreadList()
        LogUtil.ClearStatus(LblStatus)
    End Sub
    Private Sub AddPalette(pName As String)
        Dim _paletteId As Integer = AddNewPalette(pName.Trim)
        For Each oRow As DataGridViewRow In DgvPaletteThreads.Rows
            Dim _paletteThread As PaletteThread = PaletteThreadBuilder.APaletteThread.StartingWithNothing _
                                    .WithThreadId(oRow.Cells(palettethreadid.Name).Value) _
                                    .WithPaletteId(_paletteId) _
                                    .WithIsBead(False) _
                                    .Build
            AddNewPaletteThread(_paletteThread)
        Next
        For Each oRow As DataGridViewRow In DgvPaletteBeads.Rows
            Dim _paletteThread As PaletteThread = PaletteThreadBuilder.APaletteThread.StartingWithNothing _
                                    .WithThreadId(oRow.Cells(PaletteBeadId.Name).Value) _
                                    .WithPaletteId(_paletteId) _
                                    .WithIsBead(True) _
                                    .Build
            AddNewPaletteThread(_paletteThread)
        Next
    End Sub
    Private Sub CreatePalette()
        If DgvPaletteThreads.Rows.Count > 0 OrElse DgvPaletteBeads.Rows.Count > 0 Then
            Dim _name As String = GetPaletteName(String.Empty)
            If Not String.IsNullOrEmpty(_name) Then
                LogUtil.ShowStatus("Adding new Palette", LblStatus)
                InsertPalette(_name)
            Else
                LogUtil.ShowStatus("Palette name missing. Palette not added.", LblStatus, True)
            End If
        Else
            LogUtil.ShowStatus("No threads selected. Palette not added.", LblStatus, True)
        End If
    End Sub
    Private Sub InsertPalette(pName As String)
        AddPalette(pName)
        LoadPaletteList(DgvPalettes, MyBase.Name)
        LogUtil.ShowStatus("Palette added", LblStatus, MyBase.Name)
    End Sub
    Private Sub UpdateSelectedPalette()
        If _selectedPalette.PaletteId >= 0 Then
            If DgvPaletteThreads.Rows.Count > 0 OrElse DgvPaletteBeads.Rows.Count > 0 Then
                LogUtil.LogInfo("Updating Palette", MyBase.Name)
                RemovePalette(_selectedPalette)
                InsertPalette(_selectedPalette.PaletteName)
            Else
                LogUtil.ShowStatus("No threads selected. Palette not updated.", LblStatus, True)
            End If
        Else
            LogUtil.ShowStatus("No Palette selected", LblStatus, True)
        End If
    End Sub
    Private Sub DeleteSelectedPalette()
        If _selectedPalette.PaletteId >= 0 Then
            LogUtil.LogInfo("Deleting Palette", MyBase.Name)
            RemovePalette(_selectedPalette)
            LoadPaletteList(DgvPalettes, MyBase.Name)
            LogUtil.ShowStatus("Palette removed", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No Palette selected", LblStatus, True)
        End If
    End Sub
    Private Sub LoadPaletteList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.Debug("Load palette list", pBaseName)
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
    Private Sub AddThreadRowFromPaletteThread(ByRef pDgv As DataGridView, pThread As PaletteThread)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells(palettethreadid.Name).Value = .ThreadId
            oRow.Cells(palettethreadname.Name).Value = .Thread.ColourName
            LoadColourCell(pDgv, oRow, palettethreadcolour.Name, .Thread, False)
            oRow.Cells(paletteThreadSeq.Name).Value = .Thread.SortNumber
            oRow.Cells(palettethreadno.Name).Value = .Thread.ThreadNo
        End With
    End Sub
    Private Sub AddBeadRowFromPaletteThread(ByRef pDgv As DataGridView, pThread As PaletteThread)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells(PaletteBeadId.Name).Value = .ThreadId
            oRow.Cells(PaletteBeadName.Name).Value = .Thread.ColourName
            LoadColourCell(pDgv, oRow, PaletteBeadColour.Name, .Thread, False)
            oRow.Cells(PaletteBeadSeq.Name).Value = .Thread.SortNumber
            oRow.Cells(PaletteBeadNo.Name).Value = .Thread.ThreadNo
        End With
    End Sub
    Private Sub AddThreadListRow(ByRef pDgv As DataGridView, pThread As Thread)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells(ListThreadId.Name).Value = .ThreadId
            oRow.Cells(ListThreadName.Name).Value = .ColourName
            LoadColourCell(pDgv, oRow, ListThreadColour.Name, pThread, False)
            oRow.Cells(ListThreadSeq.Name).Value = .SortNumber
            oRow.Cells(ListThreadNo.Name).Value = .ThreadNo
        End With
    End Sub
    Private Sub AddBeadListRow(ByRef pDgv As DataGridView, pThread As Thread)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells(ListBeadId.Name).Value = .ThreadId
            oRow.Cells(ListBeadName.Name).Value = .ColourName
            LoadColourCell(pDgv, oRow, ListBeadColour.Name, pThread, False)
            oRow.Cells(ListBeadSeq.Name).Value = .SortNumber
            oRow.Cells(ListBeadNo.Name).Value = .ThreadNo
        End With
    End Sub
    Private Sub AddThreadToPaletteList(pDgv As DataGridView, pColName As String, pRow As DataGridViewRow)
        If FindThreadInPaletteList(pDgv, palettethreadid.Name, pRow.Cells(pColName).Value) < 0 Then
            AddPaletteRowFromThreadRow(pDgv, pRow)
        End If
    End Sub
    Private Sub AddBeadToPaletteList(pDgv As DataGridView, pColName As String, pRow As DataGridViewRow)
        If FindThreadInPaletteList(pDgv, PaletteBeadId.Name, pRow.Cells(pColName).Value) < 0 Then
            AddPaletteRowFromBeadRow(pDgv, pRow)
        End If
    End Sub
    Private Sub AddPaletteRowFromThreadRow(pDgv As DataGridView, pRow As DataGridViewRow)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pRow
            oRow.Cells(palettethreadid.Name).Value = .Cells(ListThreadId.Name).Value
            oRow.Cells(palettethreadname.Name).Value = .Cells(ListThreadName.Name).Value
            oRow.Cells(palettethreadcolour.Name).Value = .Cells(ListThreadColour.Name).Value
            oRow.Cells(paletteThreadSeq.Name).Value = .Cells(ListThreadSeq.Name).Value
            oRow.Cells(palettethreadno.Name).Value = .Cells(ListThreadNo.Name).Value
        End With
    End Sub
    Private Sub AddPaletteRowFromBeadRow(pDgv As DataGridView, pRow As DataGridViewRow)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pRow
            oRow.Cells(PaletteBeadId.Name).Value = .Cells(ListBeadId.Name).Value
            oRow.Cells(PaletteBeadName.Name).Value = .Cells(ListBeadName.Name).Value
            oRow.Cells(PaletteBeadColour.Name).Value = .Cells(ListBeadColour.Name).Value
            oRow.Cells(PaletteBeadSeq.Name).Value = .Cells(ListBeadSeq.Name).Value
            oRow.Cells(PaletteBeadNo.Name).Value = .Cells(ListBeadNo.Name).Value
        End With
    End Sub

#End Region
End Class