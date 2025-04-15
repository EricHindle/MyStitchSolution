' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ProjectBuilder
    Private _projectId As Integer
    Private _projectName As String
    Public Shared Function AProject() As ProjectBuilder
        Return New ProjectBuilder
    End Function
    Public Function StartingWithNothing() As ProjectBuilder
        _projectId = -1
        _projectName = String.Empty
        Return Me
    End Function
    Public Function StartingWith(ByRef pproject As Project) As ProjectBuilder
        StartingWithNothing()
        If pproject IsNot Nothing Then
            _projectId = pproject.ProjectId
            _projectName = pproject.ProjectName
        End If
        Return Me
    End Function
    Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectsRow) As ProjectBuilder
        StartingWithNothing()
        If oRow IsNot Nothing Then
            _projectId = oRow.project_id
            _projectName = oRow.project_name
        End If
        Return Me
    End Function
    Public Function WithId(pId As Integer) As ProjectBuilder
        _projectId = pId
        Return Me
    End Function
    Public Function WithName(pprojectname As String) As ProjectBuilder
        _projectName = pprojectname
        Return Me
    End Function
    Public Function Build() As Project
        Return New Project(_projectId, _projectName)
    End Function

End Class
