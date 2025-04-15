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
    Public Shared Function AThread() As ThreadBuilder
        Return New ThreadBuilder
    End Function
    Public Function StartingWithNothing() As ThreadBuilder
        _threadId = -1
        _threadNo = String.Empty
        _colourName = String.Empty
        _colour = Color.White
        Return Me
    End Function
    Public Function StartingWith(ByRef pThread As Thread) As ThreadBuilder
        StartingWithNothing()
        If pThread IsNot Nothing Then
            _threadId = pThread.ThreadId
            _threadNo = pThread.ThreadNo
            _colourName = pThread.ColourName
            _colour = pThread.Colour
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
