' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Objects
Public Class FrmDesignSize
#Region "properties"
    Private _isExtend As Boolean
    Private _project As Project
    Private _projectDesign As ProjectDesign
    Private _isChanged As Boolean
    Public ReadOnly Property IsChanged() As Boolean
        Get
            Return _isChanged
        End Get
    End Property
    Public Property ProjectDesign() As ProjectDesign
        Get
            Return _projectDesign
        End Get
        Set(ByVal value As ProjectDesign)
            _projectDesign = value
        End Set
    End Property
    Public Property Project() As Project
        Get
            Return _project
        End Get
        Set(ByVal value As Project)
            _project = value
        End Set
    End Property
    Public Property IsExtend() As Boolean
        Get
            Return _isExtend
        End Get
        Set(ByVal value As Boolean)
            _isExtend = value
        End Set
    End Property
#End Region
#Region "constants"
    Private Const ADD_ROWS As String = "Number of rows to add"
    Private Const REMOVE_ROWS As String = "Number of rows to remove"
    Private Const ADD_COLUMNS As String = "Number of columns to add"
    Private Const REMOVE_COLUMNS As String = "Number of columns to remove"
#End Region
#Region "Form control handlers"
    Private Sub FrmDesignSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.DesignSizeFormPos)
        If IsExtend Then
            LblColumns.Text = ADD_COLUMNS
            LblRows.Text = ADD_ROWS
        Else
            NudLeft.Maximum = _project.DesignWidth - 1
            NudRight.Maximum = _project.DesignWidth - 1
            NudTop.Maximum = _project.DesignHeight - 1
            NudBottom.Maximum = _project.DesignHeight - 1
            LblColumns.Text = REMOVE_COLUMNS
            LblRows.Text = REMOVE_ROWS
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim isOKToClose As Boolean
        If NudBottom.Value + NudTop.Value + NudLeft.Value + NudRight.Value = 0 Then
            _isChanged = False
            isOKToClose = True
            LogUtil.LogInfo("No size alteration", MyBase.Name)
        Else
            If IsExtend Then
                LogUtil.LogInfo("Extending design", MyBase.Name)
                _project.DesignWidth += NudLeft.Value + NudRight.Value
                _project.FabricWidth += NudLeft.Value + NudRight.Value
                _project.DesignHeight += NudTop.Value + NudBottom.Value
                _project.FabricHeight += NudTop.Value + NudBottom.Value
                _project.OriginX += NudLeft.Value
                _project.OriginY += NudTop.Value
                _projectDesign.Rows = oProject.DesignHeight
                _projectDesign.Columns = oProject.DesignWidth
                _isChanged = True
                isOKToClose = True
            Else
                Dim _newDesignHeight As Integer = _project.DesignHeight - NudTop.Value - NudBottom.Value
                Dim _newDesignWidth As Integer = _project.DesignWidth - NudLeft.Value - NudRight.Value
                If _newDesignHeight > 1 AndAlso _newDesignWidth > 1 Then
                    LogUtil.LogInfo("Cropping design", MyBase.Name)
                    _project.OriginX -= NudLeft.Value
                    _project.OriginY -= NudTop.Value
                    _project.DesignWidth -= (NudLeft.Value + NudRight.Value)
                    _project.FabricWidth -= (NudLeft.Value + NudRight.Value)
                    _project.DesignHeight -= (NudTop.Value + NudBottom.Value)
                    _project.FabricHeight -= (NudTop.Value + NudBottom.Value)
                    _projectDesign.Rows = oProject.DesignHeight
                    _projectDesign.Columns = oProject.DesignWidth
                    RemoveCellsFromDesign(_project, _projectDesign)
                    _isChanged = True
                    isOKToClose = True
                Else
                    MsgBox("Design not large enough to crop", MsgBoxStyle.Exclamation, "Error")
                    isOKToClose = False
                End If
            End If
        End If
        If isOKToClose Then
            Close()
        End If
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        _isChanged = False
        Close()
    End Sub
    Private Sub FrmDesignSize_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.DesignSizeFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
#End Region
#Region "subroutines"
    Private Sub RemoveCellsFromDesign(ByRef pProject As Project, ByRef pProjectDesign As ProjectDesign)
        Dim _newBackStitches As New List(Of BackStitch)
        Dim _newKnots As New List(Of Knot)
        Dim _newBlockStitches As New List(Of BlockStitch)
        For Each _backStitch As BackStitch In pProjectDesign.BackStitches
            If _backStitch.FromBlockLocation.X + pProject.OriginX >= 0 _
                AndAlso _backStitch.FromBlockLocation.X + pProject.OriginX < pProject.DesignWidth _
                AndAlso _backStitch.FromBlockLocation.Y + pProject.OriginY >= 0 _
                AndAlso _backStitch.FromBlockLocation.Y + pProject.OriginY < pProject.DesignHeight _
                AndAlso _backStitch.ToBlockLocation.X + pProject.OriginX >= 0 _
                AndAlso _backStitch.ToBlockLocation.X + pProject.OriginX < pProject.DesignWidth _
                AndAlso _backStitch.ToBlockLocation.Y + pProject.OriginY >= 0 _
                AndAlso _backStitch.ToBlockLocation.Y + pProject.OriginY < pProject.DesignHeight Then
                _newBackStitches.Add(_backStitch)
            End If
        Next
        For Each _blockstitch As BlockStitch In pProjectDesign.BlockStitches
            If _blockstitch.BlockLocation.X + pProject.OriginX >= 0 _
                AndAlso _blockstitch.BlockLocation.X + pProject.OriginX < pProject.DesignWidth _
                AndAlso _blockstitch.BlockLocation.Y + pProject.OriginY >= 0 _
                AndAlso _blockstitch.BlockLocation.Y + pProject.OriginY < pProject.DesignHeight Then
                _newBlockStitches.Add(_blockstitch)
            End If
        Next
        For Each _knot As Knot In pProjectDesign.Knots
            If _knot.BlockLocation.X + pProject.OriginX >= 0 _
                AndAlso _knot.BlockLocation.X + pProject.OriginX < pProject.DesignWidth _
                AndAlso _knot.BlockLocation.Y + pProject.OriginY >= 0 _
                AndAlso _knot.BlockLocation.Y + pProject.OriginY < pProject.DesignHeight Then
                _newKnots.Add(_knot)
            End If
        Next
        pProjectDesign.BackStitches = _newBackStitches
        pProjectDesign.BlockStitches = _newBlockStitches
        pProjectDesign.Knots = _newKnots
    End Sub
#End Region
End Class