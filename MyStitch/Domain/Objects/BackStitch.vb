' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.BlockStitch
Imports MyStitch.Domain.Objects
Imports Newtonsoft.Json

Public Class BackStitch
    Inherits Stitch
    Private _toBlockLoc As Point
    Private _toBlockQtr As BlockQuarter

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
            Return _blockLoc
        End Get
        Set(ByVal value As Point)
            _blockLoc = value
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

    Private Sub Initialise()
        _blockLoc = New Point(0, 0)
        _toBlockLoc = New Point(0, 0)
        _blockQtr = BlockQuarter.TopLeft
        _toBlockQtr = BlockQuarter.TopLeft
        _strands = 1
        _thread = New Thread
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pFromLoc As Point, pFromQtr As BlockQuarter, pToloc As Point, pToQtr As BlockQuarter, pStrands As Integer, pThread As Thread)
        _blockLoc = pFromLoc
        _blockQtr = pFromQtr
        _toBlockLoc = pToloc
        _toBlockQtr = pToQtr
        _strands = pStrands
        _thread = pThread
    End Sub

    Public Overrides Function ToString() As String
        Return JsonConvert.SerializeObject(Me)
    End Function
End Class
