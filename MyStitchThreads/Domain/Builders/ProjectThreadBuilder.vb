' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ProjectThreadBuilder
    Private _project As Project
    Private _thread As Thread

    Public Shared Function AProjectThread() As ProjectThreadBuilder
        Return New ProjectThreadBuilder
    End Function
    Public Function StartingWithNothing() As ProjectThreadBuilder
        _project = New Project()
        _thread = New Thread()

        Return Me
    End Function
    Public Function StartingWith(ByRef pThread As ProjectThread) As ProjectThreadBuilder
        StartingWithNothing()
        If pThread IsNot Nothing Then
            _project = ProjectBuilder.AProject.StartingWith(pThread.Project).Build
            _thread = ThreadBuilder.AThread.StartingWith(pThread.Thread).Build

        End If
        Return Me
    End Function
    Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectThreadsRow) As ProjectThreadBuilder
        StartingWithNothing()
        If oRow IsNot Nothing Then
            _project = GetProjectById(oRow.project_id)
            _thread = GetthreadById(oRow.thread_id)

        End If
        Return Me
    End Function
    Public Function WithThread(pThread As Thread) As ProjectThreadBuilder
        _thread = pThread
        Return Me
    End Function
    Public Function WithThreadId(pId As Integer) As ProjectThreadBuilder
        _thread = GetThreadById(pId)
        Return Me
    End Function
    Public Function WithProject(pProject As Project) As ProjectThreadBuilder
        _project = pProject
        Return Me
    End Function
    Public Function WithProject(pId As Integer) As ProjectThreadBuilder
        _project = GetProjectById(pId)
        Return Me
    End Function

    Public Function Build() As ProjectThread
        Return New ProjectThread(_project.ProjectId, _thread.ThreadId)
    End Function
End Class
