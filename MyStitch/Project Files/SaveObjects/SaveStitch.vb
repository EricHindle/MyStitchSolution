' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports MyStitch.Domain.Objects

Public Class SaveStitch
    Friend _blockPos As Point
    Friend _blockQtr As BlockQuarter
    Friend _strands As Integer
    Friend _stitchType As BlockStitchType
    Friend _threadId As Integer
    Friend _projectId As Integer
    Public Property ProjectId() As Integer
        Get
            Return _projectId
        End Get
        Set(ByVal value As Integer)
            _projectId = value
        End Set
    End Property
    Public Property ThreadId() As Integer
        Get
            Return _threadId
        End Get
        Set(ByVal value As Integer)
            _threadId = value
        End Set
    End Property
    Public Property StitchType() As BlockStitchType
        Get
            Return _stitchType
        End Get
        Set(ByVal value As BlockStitchType)
            _stitchType = value
        End Set
    End Property
    Public Property BlockPosition() As Point
        Get
            Return _blockPos
        End Get
        Set(ByVal value As Point)
            _blockPos = value
        End Set
    End Property
    Public Property BlockLocation() As Point
        Get
            Return _blockPos
        End Get
        Set(ByVal value As Point)
            _blockPos = value
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
    Friend Sub Initialise()
        _blockPos = New Point(0, 0)
        _blockQtr = BlockQuarter.TopLeft
        _strands = 2
        _stitchType = BlockStitchType.none
        _threadId = -1
        _projectId = -1
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pPos As Point, pType As BlockStitchType, pQtr As BlockQuarter, pStrands As Integer, pThreadId As Integer, pProjectId As Integer)
        _blockPos = pPos
        _stitchType = pType
        _blockQtr = pQtr
        _strands = pStrands
        _threadId = pThreadId
        _projectId = pProjectId
    End Sub
    Public Function ToStitchString() As String
        Dim _sb As New StringBuilder
        _sb _
        .Append(_threadId).Append("]") _
        .Append(_blockPos.X).Append("/") _
        .Append(_blockPos.Y).Append("]") _
        .Append(_blockQtr).Append("]") _
        .Append(_strands)
        Return _sb.ToString
    End Function
End Class
