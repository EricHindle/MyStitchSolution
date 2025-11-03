' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Text
Namespace Domain.Objects

    Public Class BackStitch
        Inherits Stitch
        Private _toBlockPos As Point
        Private _toBlockQtr As BlockQuarter
        Public Property ToBlockPosition() As Point
            Get
                Return _toBlockPos
            End Get
            Set(ByVal value As Point)
                _toBlockPos = value
            End Set
        End Property
        Public Property FromBlockPosition() As Point
            Get
                Return _blockPos
            End Get
            Set(ByVal value As Point)
                _blockPos = value
            End Set
        End Property
        Public Property ToBlockLocation() As Point
            Get
                Return _toBlockPos
            End Get
            Set(ByVal value As Point)
                _toBlockPos = value
            End Set
        End Property
        Public Property FromBlockLocation() As Point
            Get
                Return _blockPos
            End Get
            Set(ByVal value As Point)
                _blockPos = value
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
            _toBlockPos = New Point(0, 0)
            _toBlockQtr = BlockQuarter.TopLeft
        End Sub
        Public Sub New(pFromPos As Point, pFromQtr As BlockQuarter, pToPos As Point, pToQtr As BlockQuarter, pStrands As Integer, pThreadId As Integer, pProjectId As Integer)
            _blockPos = pFromPos
            _blockQtr = pFromQtr
            _toBlockPos = pToPos
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
            .Append("BeadId =[").Append(CStr(_threadId)).Append("], ") _
            .Append("StitchType =[").Append(_stitchType.ToString).Append("], ") _
            .Append("FromBlockPosition =[").Append(CStr(_blockPos.X)).Append(",").Append(CStr(_blockPos.Y)).Append("], ") _
            .Append("FromBlockQuarter =[").Append(_blockQtr.ToString).Append("], ") _
            .Append("ToBlockPosition =[").Append(CStr(_toBlockPos.X)).Append(",").Append(CStr(_toBlockPos.Y)).Append("], ") _
            .Append("ToBlockQuarter =[").Append(_toBlockQtr.ToString).Append("], ") _
            .Append("Strands =[").Append(CStr(_strands)).Append("], ") _
            .Append("ProjectThread = [").Append(ProjThread.ToString).Append("]") _
            .Append("]")
            Return _sb.ToString()
        End Function
        Public Function ToSaveString() As String
            Dim _sb As New StringBuilder
            _sb _
        .Append(ToStitchString).Append(BLOCK_DELIM) _
        .Append(_toBlockPos.X).Append("/").Append(_toBlockPos.Y).Append(BLOCK_DELIM) _
        .Append(_toBlockQtr)
            Return _sb.ToString
        End Function
    End Class
End Namespace