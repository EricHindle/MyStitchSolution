' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ProjectCardThreadBuilder
    Private _project As Project
    Private _thread As Thread
    Private _cardNo As Integer
    Private _cardSeq As Integer
    Public Shared Function AProjectCardThread() As ProjectCardThreadBuilder
        Return New ProjectCardThreadBuilder
    End Function
    Public Function StartingWithNothing() As ProjectCardThreadBuilder
        _project = New Project()
        _thread = New Thread()
        _cardNo = -1
        _cardSeq = -1
        Return Me
    End Function
    Public Function StartingWith(ByRef pCardThread As ProjectCardThread) As ProjectCardThreadBuilder
        StartingWithNothing()
        If pCardThread IsNot Nothing Then
            _project = ProjectBuilder.AProject.StartingWith(pCardThread.Project).Build
            _thread = ThreadBuilder.AThread.StartingWith(pCardThread.Thread).Build
            _cardNo = pCardThread.CardNo
            _cardSeq = pCardThread.CardSeq
        End If
        Return Me
    End Function
    Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectCardThreadRow) As ProjectCardThreadBuilder
        StartingWithNothing()
        If oRow IsNot Nothing Then
            _project = GetProjectById(oRow.project_id)
            _thread = GetThreadById(oRow.thread_id)
            _cardNo = oRow.thread_card_no
            _cardSeq = oRow.thread_card_seq
        End If
        Return Me
    End Function
    Public Function WithThread(pThread As Thread) As ProjectCardThreadBuilder
        _thread = pThread
        Return Me
    End Function
    Public Function WithThreadId(pId As Integer) As ProjectCardThreadBuilder
        _thread = GetThreadById(pId)
        Return Me
    End Function
    Public Function WithProject(pProject As Project) As ProjectCardThreadBuilder
        _project = pProject
        Return Me
    End Function
    Public Function WithProject(pId As Integer) As ProjectCardThreadBuilder
        _project = GetProjectById(pId)
        Return Me
    End Function
    Public Function WithCardNo(pCardNo As Integer) As ProjectCardThreadBuilder
        _cardNo = pCardNo
        Return Me
    End Function
    Public Function WithCardseq(pCardSeq As Integer) As ProjectCardThreadBuilder
        _cardSeq = pCardSeq
        Return Me
    End Function
    Public Function Build() As ProjectCardThread
        Return New ProjectCardThread(_project.ProjectId, _thread.ThreadId, _cardNo, _cardSeq)
    End Function
End Class
