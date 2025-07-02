' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class SaveBackstitch
    Inherits SaveStitch
    Private _toBlockPos As Point
    Private _toBlockQtr As BlockQuarter

    Public Property ToBlockPosition() As Point
        Get
            Return _toBlockPos
        End Get
        Set(ByVal value As Point)
            _toBlockPos = value
        End Set
    End Property
    Public Property FromBlockPosition() As Point
        Get
            Return _blockPos
        End Get
        Set(ByVal value As Point)
            _blockPos = value
        End Set
    End Property
    Public Property ToBlockLocation() As Point
        Get
            Return _toBlockPos
        End Get
        Set(ByVal value As Point)
            _toBlockPos = value
        End Set
    End Property
    Public Property FromBlockLocation() As Point
        Get
            Return _blockPos
        End Get
        Set(ByVal value As Point)
            _blockPos = value
        End Set
    End Property
    Public Property FromBlockQuarter() As BlockQuarter
        Get
            Return _blockQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _blockQtr = value
        End Set
    End Property
    Public Property ToBlockQuarter() As BlockQuarter
        Get
            Return _toBlockQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _toBlockQtr = value
        End Set
    End Property

    Public Sub New()
        Initialise()
        _toBlockPos = New Point(0, 0)
        _toBlockQtr = BlockQuarter.TopLeft
    End Sub
    Public Sub New(pFromPos As Point, pFromQtr As BlockQuarter, pToPos As Point, pToQtr As BlockQuarter, pStrands As Integer, pThreadId As Integer, pProjectId As Integer)
        _blockPos = pFromPos
        _blockQtr = pFromQtr
        _toBlockPos = pToPos
        _toBlockQtr = pToQtr
        _strands = pStrands
        _threadId = pThreadId
        _projectId = pProjectId
    End Sub

End Class
