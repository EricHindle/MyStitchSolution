' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class BlockStitchQuarter
    Private _blockQuarter As BlockQuarter
    Private _strandCount As Integer
    Private _thread As Thread
    Private _threadId As Integer
    Public Property ThreadId() As Integer
        Get
            Return _threadId
        End Get
        Set(ByVal value As Integer)
            _threadId = value
        End Set
    End Property
    Public ReadOnly Property Thread() As Thread
        Get
            If _thread Is Nothing Then
                _thread = GetThreadById(_threadId)
            End If
            Return _thread
        End Get
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
        _thread = Nothing
        _threadId = -1
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pQtr As BlockQuarter, pStrandCt As Integer, pThreadId As Integer)
        _blockQuarter = pQtr
        _strandCount = pStrandCt
        _threadId = pThreadId
        _thread = Nothing
        '    LogUtil.Info(Me.ToString, "Stitch Quarter")
    End Sub
    Public Overrides Function ToString() As String
        Dim _sb As New StringBuilder
        _sb.Append("BlockQuarter=[") _
            .Append("Quarter =[").Append(_blockQuarter.ToString).Append("], ") _
            .Append("Strands =[").Append(CStr(_strandCount)).Append("], ") _
            .Append("Thread = [").Append(Thread.ToString).Append("]") _
            .Append("]")
        Return _sb.ToString()
    End Function
    Public Function ToSaveString() As String
        Dim _sb As New StringBuilder
        _sb.Append(CStr(_threadId)).Append("/") _
            .Append(_blockQuarter).Append("/") _
            .Append(CStr(_strandCount))
        Return _sb.ToString
    End Function
End Class
