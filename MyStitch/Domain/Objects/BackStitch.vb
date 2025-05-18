' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports MyStitch.BlockStitch
Imports MyStitch.Domain.Objects

Public Class BackStitch
    Private _fromBlockLoc As Point
    Private _toBlockLoc As Point
    Private _fromBlockQtr As BlockQuarter
    Private _toBlockQtr As BlockQuarter
    Private _thread As Thread
    Private _strands As Integer

    Public Property ToBlockLocation() As Point
        Get
            Return _toBlockLoc
        End Get
        Set(ByVal value As Point)
            _toBlockLoc = value
        End Set
    End Property
    Public Property FromBlockLocation() As Point
        Get
            Return _fromBlockLoc
        End Get
        Set(ByVal value As Point)
            _fromBlockLoc = value
        End Set
    End Property
    Public Property FromBlockPosition() As BlockQuarter
        Get
            Return _fromBlockQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _fromBlockQtr = value
        End Set
    End Property
    Public Property ToBlockPosition() As BlockQuarter
        Get
            Return _toBlockQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _toBlockQtr = value
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
        _fromBlockLoc = New Point(0, 0)
        _toBlockLoc = New Point(0, 0)
        _fromBlockQtr = BlockQuarter.TopLeft
        _toBlockQtr = BlockQuarter.TopLeft
        _strands = 1
        _thread = New Thread
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pFromLoc As Point, pFromQtr As BlockQuarter, pToloc As Point, pToQtr As BlockQuarter, pStrands As Integer, pThread As Thread)
        _fromBlockLoc = pFromLoc
        _fromBlockQtr = pFromQtr
        _toBlockLoc = pToloc
        _toBlockQtr = pToQtr
        _strands = pStrands
        _thread = pThread
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("Backstitch=[") _
            .Append("FromLocation=[X=") _
            .Append(_fromBlockLoc.X) _
            .Append(", Y=") _
            .Append(_fromBlockLoc.Y) _
            .Append("], ") _
            .Append("ToLocation=[X=") _
            .Append(_toBlockLoc.X) _
            .Append(", Y=") _
            .Append(_toBlockLoc.Y) _
            .Append("], Strands=[") _
            .Append(CStr(_strands)) _
            .Append("], ") _
            .Append(_thread.ToString) _
            .Append("]]")
        Return sb.ToString()

    End Function
End Class
