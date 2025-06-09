' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.Domain.Objects
Imports Newtonsoft.Json

Public Class Knot
    Inherits Stitch
    Private _isBead As Boolean
    Public Property IsBead() As Boolean
        Get
            Return _isBead
        End Get
        Set(ByVal value As Boolean)
            _isBead = value
        End Set
    End Property

    Private Sub Initialise()
        _blockLoc = New Point(0, 0)
        _blockQtr = BlockQuarter.TopLeft
        _strands = 2
        _thread = New Thread
        _isBead = False
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pLoc As Point, pQtr As BlockQuarter, pStrands As Integer, pThread As Thread, pIsBead As Boolean)
        _blockLoc = pLoc
        _blockQtr = pQtr
        _strands = pStrands
        _thread = pThread
        _isBead = pIsBead
    End Sub
    Public Overrides Function ToString() As String
        Return JsonConvert.SerializeObject(Me)
    End Function
End Class
