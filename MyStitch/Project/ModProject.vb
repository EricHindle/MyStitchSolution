' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Module ModProject
    Public MIN_DATE As New DateTime(2001, 1, 1)
    Public Sub LoadProjectList(ByRef pDgv As DataGridView, pBaseName As String)
        LogUtil.LogInfo("Load project list", pBaseName)
        pDgv.Rows.Clear()
        For Each oproject As Project In GetProjects()
            AddProjectRow(pDgv, oproject)
        Next
        pDgv.ClearSelection()
    End Sub
    Private Sub AddProjectRow(ByRef pDgv As DataGridView, oProject As Project)
        Dim oRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
        oRow.Cells(pDgv.Columns(0).Name).Value = oProject.ProjectId
        oRow.Cells(pDgv.Columns(1).Name).Value = oProject.ProjectName
    End Sub
    Public Function SelectProjectInList(ByRef pDgv As DataGridView, pColName As String, pProjectId As Integer) As Integer
        Dim _index As Integer = 0
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells(pColName).Value = pProjectId Then
                orow.Selected = True
                pDgv.FirstDisplayedScrollingRowIndex = orow.Index
                _index = orow.Index
                Exit For
            End If
        Next
        Return _index
    End Function
    Public Function MakeFilename(pProject As Project) As String
        Dim _filename As String = pProject.DesignFileName
        If String.IsNullOrEmpty(_filename) Then
            _filename = Replace(pProject.ProjectName, " ", "_").ToLower
        End If
        Return _filename
    End Function

    Public Function MakeFullFileName(pProject As Project, pFileType As String) As String
        Dim _baseFilename As String = MakeFilename(pProject) & pFileType
        Dim _designFilePath As String = My.Settings.DesignFilePath.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        Dim _fullFilename As String = Path.Combine(_designFilePath, _baseFilename)
        Return _fullFilename
    End Function
End Module