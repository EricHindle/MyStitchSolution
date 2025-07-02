' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class SaveBlockstitch
    Inherits SaveStitch
    Private _quarters As List(Of SaveStitchQuarter)
    Public Property Quarters() As List(Of SaveStitchQuarter)
        Get
            Return _quarters
        End Get
        Set(ByVal value As List(Of SaveStitchQuarter))
            _quarters = value
        End Set
    End Property
    Public Sub New()
        Initialise()
        _quarters = New List(Of SaveStitchQuarter)
    End Sub
    Public Sub New(pPosition As Point, pQtr As BlockQuarter, pQuarters As List(Of SaveStitchQuarter), pStrands As Integer, pThreadId As Integer, pStitchType As BlockStitchType, pProjectId As Integer)
        _blockPos = pPosition
        _quarters = pQuarters
        _strands = pStrands
        _threadId = pThreadId
        _projectId = pProjectId
        _stitchType = pStitchType
        _blockQtr = pQtr
    End Sub
    Public Function IsLoaded() As Boolean
        Return _quarters IsNot Nothing AndAlso _quarters.Count > 0
    End Function

End Class
