' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ProjectThreadBuilder
    Private _project As Project
    Private _thread As Thread
    Private _cardNo As Integer
    Private _cardSeq As Integer
    Public Shared Function AProjectThread() As ProjectThreadBuilder
        Return New ProjectThreadBuilder
    End Function
    Public Function StartingWithNothing() As ProjectThreadBuilder
        _project = New Project()
        _thread = New Thread()
        _cardNo = -1
        _cardSeq = -1
        Return Me
    End Function
    Public Function StartingWith(ByRef pThread As ProjectThread) As ProjectThreadBuilder
        StartingWithNothing()
        If pThread IsNot Nothing Then
            _project = ProjectBuilder.AProject.StartingWith(pThread.Project).Build
            _thread = ThreadBuilder.AThread.StartingWith(pThread.Thread).Build
            _cardNo = pThread.CardNo
            _cardSeq = pThread.CardSeq
        End If
        Return Me
    End Function
    Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectThreadsRow) As ProjectThreadBuilder
        StartingWithNothing()
        If oRow IsNot Nothing Then
            _project = GetProjectById(oRow.project_id)
            _thread = GetthreadById(oRow.thread_id)
            _cardNo = oRow.thread_card_no
            _cardSeq = oRow.thread_card_seq
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
    Public Function WithCardNo(pCardNo As Integer) As ProjectThreadBuilder
        _cardNo = pCardNo
        Return Me
    End Function
    Public Function WithCardseq(pCardSeq As Integer) As ProjectThreadBuilder
        _cardSeq = pCardSeq
        Return Me
    End Function
    Public Function Build() As ProjectThread
        Return New ProjectThread(_project.ProjectId, _thread.ThreadId, _cardNo, _cardSeq)
    End Function
End Class
