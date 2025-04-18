' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ThreadBuilder
    Private _threadId As Integer
    Private _threadNo As String
    Private _colourName As String
    Private _colour As Color
    Private _sortNumber As Integer
    Public Shared Function AThread() As ThreadBuilder
        Return New ThreadBuilder
    End Function
    Public Function StartingWithNothing() As ThreadBuilder
        _threadId = -1
        _threadNo = String.Empty
        _colourName = String.Empty
        _colour = Color.White
        _sortNumber = -1
        Return Me
    End Function
    Public Function StartingWith(ByRef pThread As Thread) As ThreadBuilder
        StartingWithNothing()
        If pThread IsNot Nothing Then
            With pThread
                _threadId = .ThreadId
                _threadNo = pThread.ThreadNo
                _colourName = .ColourName
                _colour = .Colour
                _sortNumber = .SortNumber
            End With
        End If
        Return Me
    End Function
    Public Function StartingWith(ByRef oRow As MyStitchDataSet.ThreadsRow) As ThreadBuilder
        StartingWithNothing()
        If oRow IsNot Nothing Then
            _threadId = oRow.thread_id
            _threadNo = oRow.thread_no
            _colourName = oRow.thread_colour_name
            _colour = Color.FromArgb(oRow.thread_colour)
            _sortNumber = Thread.MakeSortNumber(_threadNo, _threadId)
        End If
        Return Me
    End Function
    Public Function WithId(pId As Integer) As ThreadBuilder
        _threadId = pId
        Return Me
    End Function
    Public Function WithName(pColourname As String) As ThreadBuilder
        _colourName = pColourname
        Return Me
    End Function
    Public Function WithNumber(pThreadNo As String) As ThreadBuilder
        _threadNo = pThreadNo
        _sortNumber = Thread.MakeSortNumber(_threadNo, _threadId)
        Return Me
    End Function
    Public Function WithColour(pColour As Color) As ThreadBuilder
        _colour = pColour
        Return Me
    End Function
    Public Function Build() As Thread
        Return New Thread(_threadId, _threadNo, _colourName, _colour)
    End Function

End Class
