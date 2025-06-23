' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports MyStitch.Domain.Objects

Public Class Knot
    Inherits Stitch
    Private _isBead As Boolean
    Public Property IsBead() As Boolean
        Get
            Return _isBead
        End Get
        Set(ByVal value As Boolean)
            _isBead = value
        End Set
    End Property
    Public Sub New()
        Initialise()
        _isBead = False
    End Sub
    Public Sub New(pLoc As Point, pQtr As BlockQuarter, pStrands As Integer, pThreadId As Integer, pProjectId As Integer, pIsBead As Boolean)
        _blockPos = pLoc
        _blockQtr = pQtr
        _strands = pStrands
        _threadId = pThreadId
        _projectId = pProjectId
        _thread = Nothing
        _isBead = pIsBead
        '    LogUtil.Info(Me.ToString, "Knot")
    End Sub
    Public Overrides Function ToString() As String
        Dim _sb As New StringBuilder
        _sb.Append(If(_isBead, "Bead", "Knot")).Append("=[") _
            .Append("ProjectId=[").Append(CStr(_projectId)).Append("], ") _
            .Append("ThreadId =[").Append(CStr(_threadId)).Append("], ") _
            .Append("StitchType =[").Append(_stitchType.ToString).Append("], ") _
            .Append("BlockPosition =[").Append(CStr(_blockPos.X)).Append(",").Append(CStr(_blockPos.Y)).Append("], ") _
            .Append("BlockQuarter =[").Append(_blockQtr.ToString).Append("], ") _
            .Append("Strands =[").Append(CStr(_strands)).Append("], ") _
            .Append("ProjectThread = [").Append(ProjThread.ToString).Append("]") _
            .Append("]")
        Return _sb.ToString()
    End Function
End Class
