' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports Newtonsoft.Json

Public Class Cell
    Private _position As Point
    Private _location As Point
    Private _stitchQtr As BlockQuarter
    Private _knotQtr As BlockQuarter
    Private _knotCellPos As Point
    Private _knotQtrLoc As Point
    Private _stitchQtrLoc As Point
    Public Property StitchQtrLoc() As Point
        Get
            Return _stitchQtrLoc
        End Get
        Set(ByVal value As Point)
            _stitchQtrLoc = value
        End Set
    End Property

    Public Property KnotQtrLoc() As Point
        Get
            Return _knotQtrLoc
        End Get
        Set(ByVal value As Point)
            _knotQtrLoc = value
        End Set
    End Property
    Public Property KnotCellPos() As Point
        Get
            Return _knotCellPos
        End Get
        Set(ByVal value As Point)
            _knotCellPos = value
        End Set
    End Property
    Public Property KnotQtr() As BlockQuarter
        Get
            Return _knotQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _knotQtr = value
        End Set
    End Property
    Public Property StitchQuarter() As BlockQuarter
        Get
            Return _stitchQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _stitchQtr = value
        End Set
    End Property
    Public Property Location() As Point
        Get
            Return _location
        End Get
        Set(ByVal value As Point)
            _location = value
        End Set
    End Property
    Public Property Position() As Point
        Get
            Return _position
        End Get
        Set(ByVal value As Point)
            _position = value
        End Set
    End Property
    Private Sub Initialise()
        _position = New Point(0, 0)
        _location = New Point(0, 0)
        _stitchQtr = BlockQuarter.TopLeft
        _knotQtr = BlockQuarter.TopLeft
        _knotCellPos = New Point(0, 0)
        _knotQtrLoc = New Point(0, 0)
        _stitchQtrLoc = New Point(0, 0)
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pPosition As Point,
                   pLocation As Point,
                   pStitchQtr As BlockQuarter,
                   pStitchQtrLoc As Point,
                   pKnotQtr As BlockQuarter,
                   pKnotCellPos As Point,
                   pKnotQtrLoc As Point)
        _position = pPosition
        _location = pLocation
        _stitchQtr = pStitchQtr
        _stitchQtrLoc = pStitchQtrLoc
        _knotQtr = pKnotQtr
        _knotCellPos = pKnotCellPos
        _knotQtrLoc = pKnotQtrLoc
        '    LogUtil.Info(Me.ToString, "Cell")
    End Sub
    Public Overrides Function ToString() As String
        Return JsonConvert.SerializeObject(Me)
    End Function
End Class
