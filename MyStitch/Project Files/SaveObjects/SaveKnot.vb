' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class SaveKnot
    Inherits SaveStitch
    Private _isBead As Boolean
    Public Property IsBead() As Boolean
        Get
            Return _isBead
        End Get
        Set(ByVal value As Boolean)
            _isBead = value
        End Set
    End Property
    Public Sub New()
        Initialise()
        _isBead = False
    End Sub
    Public Sub New(pLoc As Point, pQtr As BlockQuarter, pStrands As Integer, pThreadId As Integer, pProjectId As Integer, pIsBead As Boolean)
        _blockPos = pLoc
        _blockQtr = pQtr
        _strands = pStrands
        _threadId = pThreadId
        _projectId = pProjectId
        _isBead = pIsBead
    End Sub

End Class
