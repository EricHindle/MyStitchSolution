' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects

Namespace Domain.Builders
    Public Class ProjectThreadBuilder
        Private _project As Project
        Private _thread As Thread
        Private _backstitchCount As Integer
        Private _blockstitchCount As Integer
        Private _knotCount As Integer
        Private _symbolId As Integer

        Public Shared Function AProjectThread() As ProjectThreadBuilder
            Return New ProjectThreadBuilder
        End Function
        Public Function StartingWithNothing() As ProjectThreadBuilder
            _project = New Project()
            _thread = New Thread()
            _backstitchCount = 0
            _blockstitchCount = 0
            _knotCount = 0
            _symbolId = 0
            Return Me
        End Function
        Public Function StartingWith(ByRef pThread As ProjectThread) As ProjectThreadBuilder
            StartingWithNothing()
            If pThread IsNot Nothing Then
                With pThread
                    _project = ProjectBuilder.AProject.StartingWith(.Project).Build
                    _thread = ThreadBuilder.AThread.StartingWith(.Thread).Build
                    _backstitchCount = .BackstitchCount
                    _blockstitchCount = .BlockstitchCount
                    _knotCount = .KnotCount
                    _symbolId = .SymbolId
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectThreadsRow) As ProjectThreadBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _project = GetProjectById(.project_id)
                    _thread = GetThreadById(.thread_id)
                    _backstitchCount = .backstitch_count
                    _blockstitchCount = .blockstitch_count
                    _knotCount = .knot_count
                    _symbolId = .symbol_id
                End With
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
        Public Function WithBackstitchCount(pCount As Integer) As ProjectThreadBuilder
            _backstitchCount = pCount
            Return Me
        End Function
        Public Function WithBlockstitchCount(pCount As Integer) As ProjectThreadBuilder
            _blockstitchCount = pCount
            Return Me
        End Function
        Public Function WithKnotCount(pCount As Integer) As ProjectThreadBuilder
            _knotCount = pCount
            Return Me
        End Function
        Public Function WithSymbolId(pSymbolId As Integer) As ProjectThreadBuilder
            _symbolId = pSymbolId
            Return Me
        End Function
        Public Function Build() As ProjectThread
            Return New ProjectThread(_project.ProjectId, _thread.ThreadId, _backstitchCount, _blockstitchCount, _knotCount, _symbolId)
        End Function
    End Class
End Namespace