' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports MyStitch.BlockStitch
Imports MyStitch.Domain.Objects

Public Class BlockStitchQuarter
    Private _blockQuarter As BlockQuarter
    Private _stitchType As BlockStitchType
    Private _strandCount As Integer
    Private _thread As Thread
    Public Property Thread() As Thread
        Get
            Return _thread
        End Get
        Set(ByVal value As Thread)
            _thread = value
        End Set
    End Property
    Public Property StrandCount() As Integer
        Get
            Return _strandCount
        End Get
        Set(ByVal value As Integer)
            _strandCount = value
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
    Public Property BlockQuarter() As BlockQuarter
        Get
            Return _blockQuarter
        End Get
        Set(ByVal value As BlockQuarter)
            _blockQuarter = value
        End Set
    End Property
    Private Sub Initialise()
        _blockQuarter = BlockQuarter.TopRight
        _stitchType = BlockStitchType.Full
        _strandCount = 2
        _thread = New Thread
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pQtr As BlockQuarter, pType As BlockStitchType, pStrandCt As Integer, pThread As Thread)
        _blockQuarter = pQtr
        _stitchType = pType
        _strandCount = pStrandCt
        _thread = pThread
    End Sub
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("BlockStitchQuarter=[") _
            .Append(_blockQuarter.ToString) _
            .Append("=[Type=[") _
            .Append(_stitchType.ToString) _
            .Append("], Strand count=[") _
            .Append(CStr(_strandCount)) _
            .Append("], ") _
            .Append(_thread.ToString) _
            .Append("]")
        Return sb.ToString()

    End Function
End Class
