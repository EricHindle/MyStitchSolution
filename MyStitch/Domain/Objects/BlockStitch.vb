' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports Newtonsoft.Json

Public Class BlockStitch
    Inherits Stitch
    Private _quarters As List(Of BlockStitchQuarter)
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
    Public Function IsLoaded() As Boolean
        Return _quarters IsNot Nothing AndAlso _quarters.Count > 0
    End Function
    Public Overrides Function ToString() As String
        Return JsonConvert.SerializeObject(Me)
    End Function
End Class
