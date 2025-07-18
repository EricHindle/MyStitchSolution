﻿' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Text
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
    Public Sub New()
        Initialise()
        _quarters = New List(Of BlockStitchQuarter)
    End Sub
    Public Sub New(pPosition As Point, pQtr As BlockQuarter, pQuarters As List(Of BlockStitchQuarter), pStrands As Integer, pThreadId As Integer, pStitchType As BlockStitchType, pProjectId As Integer)
        _blockPos = pPosition
        _quarters = pQuarters
        _strands = pStrands
        _threadId = pThreadId
        _projectId = pProjectId
        _stitchType = pStitchType
        _blockQtr = pQtr
        _thread = Nothing
        '     Dim _string As String = Me.ToString
        '    LogUtil.LogInfo(_string, "Blockstitch")
    End Sub
    Public Function IsLoaded() As Boolean
        Return _quarters IsNot Nothing AndAlso _quarters.Count > 0
    End Function
    Public Overrides Function ToString() As String
        Dim _sb As New StringBuilder
        _sb.Append("Blockstitch=[") _
            .Append("ProjectId=[").Append(CStr(_projectId)).Append("], ") _
            .Append("ThreadId =[").Append(CStr(_threadId)).Append("], ") _
            .Append("StitchType =[").Append(_stitchType.ToString).Append("], ") _
            .Append("BlockPosition =[").Append(CStr(_blockPos.X)).Append(",").Append(CStr(_blockPos.Y)).Append("], ") _
            .Append("BlockQuarter =[").Append(_blockQtr.ToString).Append("], ") _
            .Append("Strands =[").Append(CStr(_strands)).Append("], ") _
            .Append("Quarters = [")
        For Each _qtr As BlockStitchQuarter In _quarters
            _sb.Append(_qtr.ToString).Append(",")
        Next
        _sb.Append("], ")
        If ProjThread IsNot Nothing Then
            _sb.Append(ProjThread.ToString)
        Else
            _sb.Append("ProjectThread = [nothing]")
        End If

        _sb.Append("]")
        Return _sb.ToString()
    End Function
    Public Function ToSaveString() As String
        Dim _sb As New StringBuilder
        _sb _
            .Append(ToStitchString).Append(BLOCK_DELIM)
        For Each _qtr As BlockStitchQuarter In _quarters
            _sb.Append(_qtr.ToSaveString).Append(STITCH_DELIM)
        Next
        Return _sb.ToString.TrimEnd(STITCH_DELIM)
    End Function
End Class
