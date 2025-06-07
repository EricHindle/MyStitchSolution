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
    Private SYMBOL_WIDTH As Integer = 32
    Private SYMBOL_HEIGHT As Integer = 32
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
#End Region
#Region "functions"
    Private Sub InitialiseForm()
        isLoading = True
        GetFormPos(Me, My.Settings.ProjectThreadsFormPos)
        PnlThreads.Visible = False
        LoadThreadList()
        DgvThreads.ClearSelection()
        isLoading = False

    End Sub
    Private Sub LoadThreadList()
        LogUtil.LogInfo("Load Thread list", MyBase.Name)
        Dim _usedThreadList As List(Of ProjectThread) = GetProjectThreads(_selectedProject.ProjectId)

        DgvThreads.Rows.Clear()

        For Each oThread As ProjectThread In _usedThreadList
            Dim _index = AddProjectThreadSymbolRow(DgvThreads, oThread)
        Next

        DgvThreads.ClearSelection()
    End Sub
    Public Function AddProjectThreadSymbolRow(ByRef pDgv As DataGridView, pThread As ProjectThread) As Integer
        Dim oRow As DataGridViewRow = NewProjectThreadSymbolRow(pDgv, pThread)
        Return oRow.Index
    End Function
    Private Function NewProjectThreadSymbolRow(pDgv As DataGridView, pThread As ProjectThread) As DataGridViewRow
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        With pThread.Thread
            oRow.Cells("threadId").Value = .ThreadId
            oRow.Cells("threadName").Value = .ColourName
            LoadColourCell(pDgv, oRow, "threadColour", pThread.Thread, False)
            oRow.Cells("threadSortNumber").Value = .SortNumber
            oRow.Cells("threadNo").Value = .ThreadNo
            Dim symcell As DataGridViewImageCell = CType(oRow.Cells("threadimage"), DataGridViewImageCell)
            Dim _symbol As Symbol = GetSymbolById(pThread.SymbolId)
            symcell.Value = ResizeImage(_symbol.SymbolImage, SYMBOL_WIDTH, SYMBOL_HEIGHT)
        End With
        Return oRow
    End Function
#End Region
End Class