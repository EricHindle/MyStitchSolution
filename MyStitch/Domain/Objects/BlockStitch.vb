' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports MyStitch.Domain.Objects

Public Class BlockStitch
    Public Enum BlockStitchType
        Full
        Half
        Quarter
        ThreeQuarter
    End Enum
    Public Enum BlockQuarter
        TopLeft
        TopRight
        BottomLeft
        BottomRight
    End Enum
    Private _blockLoc As Point
    Private _quarters As List(Of BlockStitchQuarter)
    Public Property BlockLocation() As Point
        Get
            Return _blockLoc
        End Get
        Set(ByVal value As Point)
            _blockLoc = value
        End Set
    End Property
    Public Property Quarters() As List(Of BlockStitchQuarter)
        Get
            Return _quarters
        End Get
        Set(ByVal value As List(Of BlockStitchQuarter))
            _quarters = value
        End Set
    End Property
    Private Sub Initialise()
        _blockLoc = New Point(0, 0)
        _quarters = New List(Of BlockStitchQuarter)
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pLocation As Point, pQuarters As List(Of BlockStitchQuarter))
        _blockLoc = pLocation
        _quarters = pQuarters
    End Sub
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("Blockstitch=[") _
            .Append("Location=[X=") _
            .Append(_blockLoc.X) _
            .Append(", Y=") _
            .Append(_blockLoc.Y) _
            .Append("], Quarters=[")
        For Each _qtr As BlockStitchQuarter In _quarters
            sb.Append(_qtr.ToString)
        Next
        sb.Append("]]")
        Return sb.ToString()

    End Function
End Class
