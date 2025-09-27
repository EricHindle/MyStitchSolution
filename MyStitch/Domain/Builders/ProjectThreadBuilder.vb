' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchData
Namespace Domain.Builders
    Public Class ProjectThreadBuilder
        Private _project As Project
        Private _thread As Thread
        Private _symbolId As Integer
        Private _projectId As Integer
        Private _threadId As Integer
        Private _isUsed As Boolean
        Public Shared Function AProjectThread() As ProjectThreadBuilder
            Return New ProjectThreadBuilder
        End Function
        Public Function StartingWithNothing() As ProjectThreadBuilder
            _project = Nothing
            _thread = Nothing
            _symbolId = -1
            _threadId = -1
            _projectId = -1
            _isUsed = False
            Return Me
        End Function
        Public Function StartingWith(ByRef pThread As ProjectThread) As ProjectThreadBuilder
            StartingWithNothing()
            If pThread IsNot Nothing Then
                With pThread
                    _projectid = .ProjectId
                    _threadid = .ThreadId
                    _symbolId = .SymbolId
                    _isUsed = .IsUsed
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As ProjectThreadsRow) As ProjectThreadBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _project = Nothing
                    _thread = Nothing
                    _projectId = .project_id
                    _threadId = .thread_id
                    _symbolId = .symbol_id
                    _isUsed = .is_used
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(oString As String) As ProjectThreadBuilder
            StartingWithNothing()
            Dim _values As String() = oString.Split(DESIGN_DELIM)
            _project = Nothing
            _thread = Nothing
            If _values.Length > 0 Then _projectId = _values(0)
            If _values.Length > 1 Then _threadId = _values(1)
            If _values.Length > 2 Then _symbolId = _values(2)
            If _values.Length > 3 Then
                If Not Boolean.TryParse(_values(3), _isUsed) Then
                    _isUsed = False
                End If
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
        Public Function WithIsUsed(pIsUsed As Boolean) As ProjectThreadBuilder
            _isUsed = pIsUsed
            Return Me
        End Function
        Public Function Build() As ProjectThread
            Return New ProjectThread(_projectId, _threadId, _symbolId, _isUsed)
        End Function
    End Class
End Namespace