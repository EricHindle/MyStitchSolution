' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects

Namespace Domain.Builders
    Public Class ProjectThreadCollectionBuilder
        Private _threads As List(Of ProjectThread)
        Public Shared Function AProjectThreadCollection() As ProjectThreadCollectionBuilder
            Return New ProjectThreadCollectionBuilder
        End Function
        Public Function StartingWithNothing() As ProjectThreadCollectionBuilder
            _threads = New List(Of ProjectThread)
            Return Me
        End Function
        Public Function StartingWith(ByRef pThreads As List(Of ProjectThread)) As ProjectThreadCollectionBuilder
            _threads = New List(Of ProjectThread)(pThreads)
            Return Me
        End Function
        Public Function StartingWith(ByRef pThreadStrings As String()) As ProjectThreadCollectionBuilder
            StartingWithNothing()
            Dim _threadList As List(Of String) = pThreadStrings.ToList
            If _threadList.Count > 0 Then
                If _threadList(0) = PROJECT_THREADS_HDR Then
                    _threadList.RemoveAt(0)
                    For Each _threadString As String In _threadList
                        Dim _projThread As ProjectThread = ProjectThreadBuilder.AProjectThread.StartingWith(_threadString).Build
                        '         If _projThread.ProjectId > 0 Then
                        _threads.Add(_projThread)
                        '         End If
                    Next
                End If
            End If
            Return Me
        End Function
        Public Function Build() As ProjectThreadCollection
            Return New ProjectThreadCollection(_threads)
        End Function
    End Class
End Namespace
