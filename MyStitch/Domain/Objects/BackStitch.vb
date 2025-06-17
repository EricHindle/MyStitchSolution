' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class BackStitch
    Inherits Stitch
    Private _toBlockLoc As Point
    Private _toBlockQtr As BlockQuarter

    Public Property ToBlockLocation() As Point
        Get
            Return _toBlockLoc
        End Get
        Set(ByVal value As Point)
            _toBlockLoc = value
        End Set
    End Property
    Public Property FromBlockLocation() As Point
        Get
            Return _blockLoc
        End Get
        Set(ByVal value As Point)
            _blockLoc = value
        End Set
    End Property
    Public Property FromBlockQuarter() As BlockQuarter
        Get
            Return _blockQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _blockQtr = value
        End Set
    End Property
    Public Property ToBlockQuarter() As BlockQuarter
        Get
            Return _toBlockQtr
        End Get
        Set(ByVal value As BlockQuarter)
            _toBlockQtr = value
        End Set
    End Property

    Public Sub New()
        Initialise()
        _toBlockLoc = New Point(0, 0)
        _toBlockQtr = BlockQuarter.TopLeft
    End Sub
    Public Sub New(pFromLoc As Point, pFromQtr As BlockQuarter, pToloc As Point, pToQtr As BlockQuarter, pStrands As Integer, pThreadId As Integer, pProjectId As Integer)
        _blockLoc = pFromLoc
        _blockQtr = pFromQtr
        _toBlockLoc = pToloc
        _toBlockQtr = pToQtr
        _strands = pStrands
        _threadId = pThreadId
        _projectId = pProjectId
        '    LogUtil.Info(Me.ToString, "Backstitch")
    End Sub

    Public Overrides Function ToString() As String
        Dim _sb As New StringBuilder
        _sb.Append("Backstitch=[") _
            .Append("ProjectId=[").Append(CStr(_projectId)).Append("], ") _
            .Append("ThreadId =[").Append(CStr(_threadId)).Append("], ") _
            .Append("StitchType =[").Append(_stitchType.ToString).Append("], ") _
            .Append("FromBlockLocation =[").Append(CStr(_blockLoc.X)).Append(",").Append(CStr(_blockLoc.Y)).Append("], ") _
            .Append("FromBlockQuarter =[").Append(_blockQtr.ToString).Append("], ") _
            .Append("ToBlockLocation =[").Append(CStr(_toBlockLoc.X)).Append(",").Append(CStr(_toBlockLoc.Y)).Append("], ") _
            .Append("ToBlockQuarter =[").Append(_toBlockQtr.ToString).Append("], ") _
            .Append("Strands =[").Append(CStr(_strands)).Append("], ") _
            .Append("ProjectThread = [").Append(ProjThread.ToString).Append("]") _
            .Append("]")
        Return _sb.ToString()
    End Function
End Class
