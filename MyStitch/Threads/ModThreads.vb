' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Module ModThreads
#Region "constants"
    Friend Const STOCK_NONE As Integer = 0
    Friend Const STOCK_NOTMUCH As Integer = 25
    Friend Const STOCK_SOME As Integer = 50
    Friend Const STOCK_ENOUGH As Integer = 75
    Friend Const STOCK_PLENTY As Integer = 100
#End Region
    Public Sub LoadThreadList(ByRef pDgv As DataGridView, pBaseName As String)
        LoadThreadList(pDgv, False, pBaseName)
    End Sub
    Public Sub LoadThreadList(ByRef pDgv As DataGridView, pIsShowStock As Boolean, pBaseName As String)
        LogUtil.LogInfo("Load ProjectThread list", pBaseName)
        pDgv.Rows.Clear()
        For Each oThread As Thread In FindThreads()
            AddProjectThreadRow(pDgv, oThread, pIsShowStock)
        Next
        pDgv.Sort(pDgv.Columns("threadSortNumber"), ListSortDirection.Ascending)
        pDgv.ClearSelection()
    End Sub
    Friend Sub LoadBrandList(pBrandList As ComboBox)
        pBrandList.DataSource = GetBrandsList()
        pBrandList.DisplayMember = "BrandName"
        pBrandList.ValueMember = "BrandId"
        pBrandList.SelectedIndex = -1
    End Sub
    Public Sub LoadBeadList(ByRef pDgv As DataGridView, pIsShowStock As Boolean, pBaseName As String)
        LogUtil.LogInfo("Load ProjectBead list", pBaseName)
        pDgv.Rows.Clear()
        For Each oBead As Bead In FindBeads()
            AddBeadRow(pDgv, oBead, pIsShowStock)
        Next
        pDgv.Sort(pDgv.Columns("BeadSortNumber"), ListSortDirection.Ascending)
        pDgv.ClearSelection()
    End Sub
    Public Function AddBeadRow(ByRef pDgv As DataGridView, pBead As Bead, pIsShowStock As Boolean) As Integer
        Dim oRow As DataGridViewRow = NewBeadRow(pDgv, pBead, pIsShowStock)
        Return oRow.Index
    End Function
    Private Function NewBeadRow(pDgv As DataGridView, pBead As Bead, pIsShowStock As Boolean) As DataGridViewRow
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pBead
            oRow.Cells("BeadId").Value = .beadId
            oRow.Cells("BeadName").Value = .ColourName
            LoadColourCell(pDgv, oRow, "beadColour", pBead, pIsShowStock)
            oRow.Cells("beadSortNumber").Value = .SortNumber
            oRow.Cells("beadNo").Value = .BeadNo
        End With
        Return oRow
    End Function
    Public Sub LoadBrandList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.LogInfo("Load Brand list", pBaseName)
        pDgv.Rows.Clear()
        For Each oBrand As Brand In FindBrands()
            AddBrandRow(pDgv, oBrand)
        Next
        pDgv.ClearSelection()
    End Sub
    Public Function AddBrandRow(ByRef pDgv As DataGridView, pBrand As Brand) As Integer
        Dim oRow As DataGridViewRow = NewBrandRow(pDgv, pBrand)
        Return oRow.Index
    End Function
    Private Function NewBrandRow(pDgv As DataGridView, pBrand As Brand) As DataGridViewRow
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pBrand
            oRow.Cells("BrandId").Value = .BrandId
            oRow.Cells("BrandName").Value = .BrandName
        End With
        Return oRow
    End Function
    Public Sub LoadProjectThreadList(ByRef pDgv As DataGridView, pProjectId As Integer, pShowStock As Boolean, pBaseName As String)
        LogUtil.LogInfo("Load ProjectThread list", pBaseName)
        Dim _threadList As List(Of Thread) = FindThreadsForProject(pProjectId)
        pDgv.Rows.Clear()
        For Each oThread As Thread In _threadList
            AddProjectThreadRow(pDgv, oThread, False, pShowStock, False)
        Next
        pDgv.Sort(pDgv.Columns("threadSortNumber"), ListSortDirection.Ascending)
        pDgv.ClearSelection()
    End Sub

    Public Function SelectItemInList(ByRef pDgv As DataGridView, pColName As String, pItemId As Integer, pRowNo As Integer) As Integer
        Dim _index As Integer = 0
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells(pColName).Value = pItemId Then
                orow.Selected = True
                pDgv.FirstDisplayedScrollingRowIndex = Math.Max(0, orow.Index - pRowNo)
                _index = orow.Index
                Exit For
            End If
        Next
        Return _index
    End Function
    Public Function SelectThreadInList(ByRef pDgv As DataGridView, pColName As String, pThreadNo As String) As Integer
        Dim _index As Integer = 0
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells(pColName).Value = pThreadNo Then
                orow.Selected = True
                _index = orow.Index
                pDgv.FirstDisplayedScrollingRowIndex = _index
                Exit For
            End If
        Next
        Return _index
    End Function
    Private Function NewProjectThreadRow(pDgv As DataGridView, pThread As Thread, pIsShowStock As Boolean) As DataGridViewRow
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells("threadId").Value = .ThreadId
            oRow.Cells("threadName").Value = .ColourName
            LoadColourCell(pDgv, oRow, "threadColour", pThread, pIsShowStock)
            oRow.Cells("threadSortNumber").Value = .SortNumber
            oRow.Cells("threadNo").Value = .ThreadNo
        End With
        Return oRow
    End Function
    Private Function NewProjectBeadRow(pDgv As DataGridView, pBead As Bead, pIsShowStock As Boolean) As DataGridViewRow
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pBead
            oRow.Cells("BeadId").Value = .BeadId
            oRow.Cells("BeadName").Value = .ColourName
            LoadColourCell(pDgv, oRow, "BeadColour", pBead, pIsShowStock)
            oRow.Cells("BeadSortNumber").Value = .SortNumber
            oRow.Cells("BeadNo").Value = .BeadNo
        End With
        Return oRow
    End Function
    Private Function NewCardThreadRow(pDgv As DataGridView, pThread As ProjectCardThread, pIsShowStock As Boolean) As DataGridViewRow
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread
            oRow.Cells("cardthreadid").Value = .Thread.ThreadId
            oRow.Cells("cardthreadname").Value = .Thread.ColourName
            LoadColourCell(pDgv, oRow, "cardthreadcolour", .Thread, pIsShowStock)
            oRow.Cells("cardthreadno").Value = .Thread.ThreadNo
            oRow.Cells("cardThreadSeq").Value = .CardSeq
        End With
        Return oRow
    End Function
    Public Function AddProjectThreadRow(ByRef pDgv As DataGridView, pThread As Thread) As Integer
        Return AddProjectThreadRow(pDgv, pThread, False)
    End Function
    Public Function AddProjectThreadRow(ByRef pDgv As DataGridView, pThread As Thread, pIsShowStock As Boolean) As Integer
        Dim oRow As DataGridViewRow = NewProjectThreadRow(pDgv, pThread, pIsShowStock)
        Return oRow.Index
    End Function
    Public Function AddProjectThreadRow(ByRef pDgv As DataGridView, pThread As Thread, pIsPaletteThread As Boolean, pIsShowStock As Boolean, pIsUsedThread As Boolean) As Integer
        Dim oRow As DataGridViewRow = NewProjectThreadRow(pDgv, pThread, pIsShowStock)
        oRow.Cells("threadSelected").Value = pIsPaletteThread
        oRow.Cells("threadSelected").ReadOnly = pIsUsedThread
        Return oRow.Index
    End Function
    Public Function AddProjectBeadRow(ByRef pDgv As DataGridView, pBead As Bead, pIsPaletteBead As Boolean, pIsShowStock As Boolean, pIsUsedBead As Boolean) As Integer
        Dim oRow As DataGridViewRow = NewProjectBeadRow(pDgv, pBead, pIsShowStock)
        oRow.Cells("BeadSelected").Value = pIsPaletteBead
        oRow.Cells("BeadSelected").ReadOnly = pIsUsedBead
        Return oRow.Index
    End Function

    Public Sub AddCardThreadRow(pDgv As DataGridView, oThread As ProjectCardThread)
        AddCardThreadRow(pDgv, oThread, False)
    End Sub
    Public Sub AddCardThreadRow(pDgv As DataGridView, oThread As ProjectCardThread, pIsShowStock As Boolean)
        NewCardThreadRow(pDgv, oThread, pIsShowStock)
    End Sub

    Public Sub LoadColourCell(ByRef pDgv As DataGridView, pRow As DataGridViewRow, pColName As String, pThread As Thread, pIsShowStock As Boolean)
        Dim _imageCell As DataGridViewImageCell = pRow.Cells(pColName)
        Dim _cellHeight As Integer = pRow.Height
        Dim _cellWidth As Integer = pDgv.Columns(pRow.Cells(pColName).ColumnIndex).Width
        Dim _levelWidth As Integer = _cellWidth * Math.Min(1, (pThread.StockLevel + 10) / 100)
        Dim _image As New Bitmap(_cellWidth, _cellHeight)
        For x = 0 To _cellWidth - 1
            For y = 0 To _cellHeight - 1
                _image.SetPixel(x, y, pThread.Colour)
            Next
        Next
        If pIsShowStock Then
            If _levelWidth < _cellWidth Then
                For x = _levelWidth To _cellWidth - 1
                    For y = 0 To _cellHeight - 1
                        _image.SetPixel(x, y, Color.White)
                    Next
                Next
            End If
        End If
        _imageCell.Value = _image
    End Sub
    Public Function SelectColor(pCurrentColor As Color) As Color
        Dim _selectedColor As Color = pCurrentColor
        Using _colorDialog As New ColorDialog
            _colorDialog.AllowFullOpen = True
            _colorDialog.CustomColors = New Integer() {pCurrentColor.ToArgb}
            _colorDialog.Color = pCurrentColor
            If _colorDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                _selectedColor = _colorDialog.Color
            End If
        End Using
        Return _selectedColor
    End Function
End Module
