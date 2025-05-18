' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports MyStitch.BlockStitch
Imports MyStitch.Domain.Objects

Public Class Knot
    Private _blockLoc As Point
    Private _blockQtr As BlockQuarter
    Private _thread As Thread
    Private _strands As Integer
    Private _isBead As Boolean
    Public Property IsBead() As Boolean
        Get
            Return _isBead
        End Get
        Set(ByVal value As Boolean)
            _isBead = value
        End Set
    End Property

    Public Property BlockLocation() As Point
        Get
            Return _blockLoc
        End Get
        Set(ByVal value As Point)
            _blockLoc = value
        End Set
    End Property
    Public Property BlockQuarter() As BlockQuarter
        Get
            Return _blockQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _blockQtr = value
        End Set
    End Property
    Public Property Strands() As Integer
        Get
            Return _strands
        End Get
        Set(ByVal value As Integer)
            _strands = value
        End Set
    End Property
    Public Property Thread() As Thread
        Get
            Return _thread
        End Get
        Set(ByVal value As Thread)
            _thread = value
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
        Dim sb As New StringBuilder
        sb _
            .Append("Backstitch=[") _
            .Append("FromLocation=[X=") _
            .Append(_blockLoc.X) _
            .Append(", Y=") _
            .Append(_blockLoc.Y) _
            .Append("], Quarter=[") _
            .Append(_blockQtr.ToString) _
            .Append("], Strands=[") _
            .Append(CStr(_strands)) _
            .Append("], ") _
            .Append(_thread.ToString) _
            .Append(", Is bead=[") _
            .Append(_isBead) _
            .Append("]]")
        Return sb.ToString()

    End Function
End Class
