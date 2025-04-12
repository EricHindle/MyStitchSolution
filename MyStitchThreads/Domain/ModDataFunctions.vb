' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Module ModDataFunctions
#Region "enum"
    Public Enum Tables
        Projects
        ProjectThreadCards
        ProjectThreads
        Threads
    End Enum
#End Region
#Region "dataset"
    Private ReadOnly oProjectTable As New MyStitchDataSet.ProjectsDataTable
    Private ReadOnly oProjectTa As New MyStitchDataSetTableAdapters.ProjectsTableAdapter
#End Region
End Module
