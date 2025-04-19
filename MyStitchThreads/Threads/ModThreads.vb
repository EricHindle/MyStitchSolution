' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Imports System.Threading
Imports HindlewareLib.Logging
Imports ZstdSharp.Unsafe

Module ModThreads
    Public Sub LoadThreadList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.LogInfo("Load Thread list", pBaseName)
        pDgv.Rows.Clear()
        For Each oThread As Thread In GetThreads()
            AddThreadRow(pDgv, oThread)
        Next
        pDgv.Sort(pDgv.Columns("threadSortNumber"), ListSortDirection.Ascending)
        pDgv.ClearSelection()
    End Sub
    Public Sub LoadProjectThreadList(ByRef pDgv As DataGridView, pProjectId As Integer, pBaseName As String)
        LogUtil.LogInfo("Load Thread list", pBaseName)
        Dim _threadList As List(Of Thread) = GetProjectThreads(pProjectId)
        pDgv.Rows.Clear()
        For Each oThread As Thread In _threadList
            AddThreadRow(pDgv, oThread, False)
        Next
        pDgv.Sort(pDgv.Columns("threadSortNumber"), ListSortDirection.Ascending)
        pDgv.ClearSelection()
    End Sub
    Public Sub LoadCardThreadList(ByRef pDgv As DataGridView, pProjectId As Integer, pCardNo As Integer, pBaseName As String)
        pDgv.Rows.Clear()
        Dim threadList As List(Of ProjectCardThread) = GetProjectCardThreadsByProjectCard(pProjectId, pCardNo)
        For Each oThread As ProjectCardThread In threadList
            AddCardThreadRow(pDgv, oThread)
        Next
        pDgv.Sort(pDgv.Columns("cardThreadSeq"), ListSortDirection.Ascending)
        pDgv.ClearSelection()

    End Sub

    Public Function SelectThreadInList(ByRef pDgv As DataGridView, pColName As String, pThreadId As Integer, pRowNo As Integer) As Integer
        Dim _index As Integer = 0
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells(pColName).Value = pThreadId Then
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
    Public Function AddThreadRow(ByRef pDgv As DataGridView, pThread As Thread) As Integer
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        oRow.Cells("threadId").Value = pThread.ThreadId
        oRow.Cells("threadName").Value = pThread.ColourName
        LoadColourCell(pDgv, oRow, "threadColour", pThread)
        oRow.Cells("threadSortNumber").Value = pThread.SortNumber
        oRow.Cells("threadNo").Value = pThread.ThreadNo
        Return oRow.Index
    End Function
    Public Function AddThreadRow(ByRef pDgv As DataGridView, pThread As Thread, isUsed As Boolean) As Integer
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        oRow.Cells("threadId").Value = pThread.ThreadId
        oRow.Cells("threadName").Value = pThread.ColourName
        LoadColourCell(pDgv, oRow, "threadColour", pThread)
        oRow.Cells("threadSortNumber").Value = pThread.SortNumber
        oRow.Cells("threadNo").Value = pThread.ThreadNo
        oRow.Cells("threadSelected").Value = isUsed
        Return oRow.Index
    End Function
    Public Sub AddCardThreadRow(pDgv As DataGridView, oThread As ProjectCardThread)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With oThread
            oRow.Cells("cardthreadid").Value = .Thread.ThreadId
            oRow.Cells("cardthreadname").Value = .Thread.ColourName
            LoadColourCell(pDgv, oRow, "cardthreadcolour", .Thread)
            oRow.Cells("cardthreadno").Value = .Thread.ThreadNo
            oRow.Cells("cardThreadSeq").Value = .CardSeq
        End With
    End Sub
    Public Sub LoadColourCell(ByRef pDgv As DataGridView, pRow As DataGridViewRow, pColName As String, pThread As Thread)
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
        If _levelWidth < _cellWidth Then
            For x = _levelWidth To _cellWidth - 1
                For y = 0 To _cellHeight - 1
                    _image.SetPixel(x, y, Color.White)
                Next
            Next
        End If

        _imageCell.Value = _image
    End Sub
End Module
