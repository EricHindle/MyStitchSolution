' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'


Imports MyStitch.Domain.Objects
Public Enum BlockStitchType
    Full
    Half
    Quarter
    ThreeQuarter
    Mixed
End Enum
Public Enum BlockQuarter
    TopLeft
    TopRight
    BottomLeft
    BottomRight
End Enum
Public Class Stitch
    Friend _blockLoc As Point
    Friend _blockQtr As BlockQuarter
    Friend _thread As Thread
    Friend _strands As Integer
    Friend _stitchType As BlockStitchType
    Public Property StitchType() As BlockStitchType
        Get
            Return _stitchType
        End Get
        Set(ByVal value As BlockStitchType)
            _stitchType = value
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
        _stitchType = BlockStitchType.Mixed
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pLoc As Point, pQtr As BlockQuarter, pStrands As Integer, pThread As Thread, pStitchType As BlockStitchType)
        _blockLoc = pLoc
        _blockQtr = pQtr
        _strands = pStrands
        _thread = pThread
    End Sub
End Class
