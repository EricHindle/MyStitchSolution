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
        Private _symbolId As Integer
        Private _projectId As Integer
        Private _threadId As Integer
        Public Shared Function AProjectThread() As ProjectThreadBuilder
            Return New ProjectThreadBuilder
        End Function
        Public Function StartingWithNothing() As ProjectThreadBuilder
            _project = Nothing
            _thread = Nothing
            _symbolId = -1
            _threadId = -1
            _projectId = -1
            Return Me
        End Function
        Public Function StartingWith(ByRef pThread As ProjectThread) As ProjectThreadBuilder
            StartingWithNothing()
            If pThread IsNot Nothing Then
                With pThread
                    _projectid = .ProjectId
                    _threadid = .ThreadId
                    _symbolId = .SymbolId
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectThreadsRow) As ProjectThreadBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _project = Nothing
                    _thread = Nothing
                    _projectId = .project_id
                    _threadId = .thread_id
                    _symbolId = .symbol_id
                End With
            End If
            Return Me
        End Function
        Public Function WithThreadId(pId As Integer) As ProjectThreadBuilder
            _threadId = pId
            Return Me
        End Function
        Public Function WithProjectId(pId As Integer) As ProjectThreadBuilder
            _projectId = pId
            Return Me
        End Function
        Public Function WithSymbolId(pSymbolId As Integer) As ProjectThreadBuilder
            _symbolId = pSymbolId
            Return Me
        End Function
        Public Function Build() As ProjectThread
            Return New ProjectThread(_projectId, _threadId, _symbolId)
        End Function
    End Class
End Namespace