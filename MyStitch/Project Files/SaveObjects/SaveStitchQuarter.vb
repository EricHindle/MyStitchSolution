' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class SaveStitchQuarter
    Private _blockQuarter As BlockQuarter
    Private _strandCount As Integer
    Private _threadId As Integer
    Public Property ThreadId() As Integer
        Get
            Return _threadId
        End Get
        Set(ByVal value As Integer)
            _threadId = value
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
        _strandCount = 2
        _threadId = -1
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pQtr As BlockQuarter, pStrandCt As Integer, pThreadId As Integer)
        _blockQuarter = pQtr
        _strandCount = pStrandCt
        _threadId = pThreadId
    End Sub
    Public Function ToSaveString() As String
        Dim _sb As New StringBuilder
        _sb.Append(CStr(_threadId)).Append("/") _
            .Append(_blockQuarter).Append("/") _
            .Append(CStr(_strandCount))
        Return _sb.ToString
    End Function

End Class
