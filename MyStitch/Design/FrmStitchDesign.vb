' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Drawing.Imaging
Imports System.Reflection
Imports HindlewareLib.Logging
Imports HindlewareLib.Utilities
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmStitchDesign
#Region "constants"

#End Region
#Region "properties"
    Private oProjectId As Integer
    Public WriteOnly Property ProjectId() As Integer
        Set(ByVal value As Integer)
            oProjectId = value
        End Set
    End Property
#End Region
#Region "variables"
    Private oCurrentUndoList As New List(Of StitchAction)
    Private oUndoList As New List(Of List(Of StitchAction))
    Private oRedoList As New List(Of List(Of StitchAction))
    Private isLoading As Boolean
    Private isLoadComplete As Boolean

    Private isComponentInitialised As Boolean
    Private oCurrentAction As DesignAction = DesignAction.none
    Private oCurrentStitchType As DesignAction = DesignAction.none
    Private oCurrentShapeType As ShapeType = ShapeType.None
    Private oCurrentSelection(-1) As Point
    Private oCurrentSelectedBlockStitch As New List(Of BlockStitch)
    Private oCurrentSelectedKnot As New List(Of Knot)
    Private oCurrentSelectedBackstitch As New List(Of BackStitch)

    Private isBlockstitchAction As Boolean
    Private isBackstitchAction As Boolean
    Private isKnotAction As Boolean

    Private iOldHScrollbarValue As Integer = 0
    Private iOldVScrollbarValue As Integer = 0

    Private isSelectionInProgress As Boolean
    Private isMoveInProgress As Boolean
    Private isBackstitchInProgress As Boolean
    Private isRemoveBackstitchInProgress As Boolean

    Private oInProgressAnchor As New Point(0, 0)
    Private oInProgressTerminus As New Point(0, 0)
    Private oPasteDestination As New Point(0, 0)

    Private oBackstitchInProgress As New BackStitch
    Private oRemoveBackstitch As New BackStitch
    Private oNearestBackstitches As New List(Of BackStitch)
    Private oSelectedBackstitchIndex As Integer

    Private _backstitchPen As New Pen(Brushes.Black)

    Private _fromCellLocation_x As Integer
    Private _fromCellLocation_y As Integer
    Private _toCellLocation_x As Integer
    Private _toCellLocation_y As Integer

    Private aTimer As System.Timers.Timer
    Private isThreadOn As Boolean

#End Region
#Region "form control event handlers"
#Region "form events"
    Private Sub FrmStitchDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening design", MyBase.Name)
        GetFormPos(Me, My.Settings.DesignFormPos)
        InitialiseForm()
        If My.Settings.isTimerAutoStart Then
            StartProjectTimer(oProject)
        End If
        KeyPreview = True
    End Sub
    Private Sub MyBase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        KeyHandler(Me, FormType.Design, e)
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing design", MyBase.Name)
        If Not isSaved Then
            Dim _result As DialogResult = MsgBox("Save changes to design?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, "Confirm")
            If _result = DialogResult.Yes Then
                SaveDesign()
            ElseIf _result = DialogResult.Cancel Then
                e.Cancel = True
                Return
            End If
        End If
        _backstitchPen.Dispose()
        oSelectionPen.Dispose()
        oFabricPen.Dispose()
        oDesignBitmap = Nothing
        CloseTimer()
        My.Settings.DesignFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub PicGrid_Click(sender As Object, e As EventArgs) Handles PicGrid.Click
        ToggleGrid()
    End Sub
    Private Sub PicCentreLines_Click(sender As Object, e As EventArgs) Handles PicCentreLines.Click
        ToggleCentre()
    End Sub
    Private Sub PicDesign_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseDown
        Dim _cell As Cell = FindCellFromClickLocation(e)
        Dim isLeftButton As Boolean = e.Button = MouseButtons.Left
        If oCurrentAction = DesignAction.none Then
            ' Drawing stitches
            If isBackstitchAction And My.Settings.IsShowBackstitches Then
                ' Placing a backstitch
                If isLeftButton Then
                    If isBackstitchInProgress Then
                        Select Case oCurrentStitchType
                            Case DesignAction.BackStitchFullThin
                                PlaceBackstitch(_cell.KnotCellPos, False, RbDouble.Checked)
                            Case DesignAction.BackstitchHalfThin
                                PlaceBackstitch(_cell.KnotCellPos, _cell.KnotQtr, True, RbDouble.Checked)
                        End Select
                    Else
                        If isRemoveBackstitchInProgress Then
                            RemoveBackstitch()
                        Else
                            Select Case oCurrentStitchType
                                Case DesignAction.BackStitchFullThin
                                    StartBackstitch(_cell.KnotCellPos, False, RbDouble.Checked)
                                Case DesignAction.BackstitchHalfThin
                                    StartBackstitch(_cell.KnotCellPos, _cell.KnotQtr, True, RbDouble.Checked)
                            End Select
                        End If
                    End If
                Else        ' Right Button
                    If isBackstitchInProgress Then
                        CancelBackstitch()
                    Else
                        If isRemoveBackstitchInProgress Then
                            NextBackstitchToRemove()
                        Else
                            BeginBackstitchRemove(_cell)
                        End If
                    End If
                End If
            Else
                ' Placing a stitch or knot
                If isLeftButton Then
                    ' Add a stitch or knot
                    If isKnotAction And My.Settings.IsShowKnots Then
                        AddKnot(_cell, oCurrentStitchType = DesignAction.Bead, RbDouble.Checked)
                    End If
                    If isBlockstitchAction And My.Settings.IsShowBlockstitches Then
                        Select Case oCurrentStitchType
                            Case DesignAction.FullBlockstitch
                                AddFullBlockStitch(_cell, RbDouble.Checked)
                            Case DesignAction.HalfBlockstitchBack
                                AddHalfBlockStitch(_cell, True, RbDouble.Checked)
                            Case DesignAction.HalfBlockstitchForward
                                AddHalfBlockStitch(_cell, False, RbDouble.Checked)
                            Case DesignAction.QuarterBlockstitchBottomRight
                                AddQuarterBlockstitch(_cell, BlockQuarter.BottomRight, RbDouble.Checked)
                            Case DesignAction.QuarterBlockstitchBottonLeft
                                AddQuarterBlockstitch(_cell, BlockQuarter.BottomLeft, RbDouble.Checked)
                            Case DesignAction.QuarterBlockstitchTopLeft
                                AddQuarterBlockstitch(_cell, BlockQuarter.TopLeft, RbDouble.Checked)
                            Case DesignAction.QuarterBlockstitchTopRight
                                AddQuarterBlockstitch(_cell, BlockQuarter.TopRight, RbDouble.Checked)
                            Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                                AddThreeQuarterStitch(_cell, BlockQuarter.BottomLeft, RbDouble.Checked)
                            Case DesignAction.ThreeQuarterBlockstitchBottomRight
                                AddThreeQuarterStitch(_cell, BlockQuarter.BottomRight, RbDouble.Checked)
                            Case DesignAction.ThreeQuarterBlockstitchTopLeft
                                AddThreeQuarterStitch(_cell, BlockQuarter.TopLeft, RbDouble.Checked)
                            Case DesignAction.ThreeQuarterBlockstitchTopRight
                                AddThreeQuarterStitch(_cell, BlockQuarter.TopRight, RbDouble.Checked)
                            Case DesignAction.BlockstitchQuarters
                                AddQuarterBlockstitch(_cell, _cell.StitchQuarter, RbDouble.Checked)
                        End Select
                    End If
                Else
                    ' Remove a stitch or knot
                    If isKnotAction And My.Settings.IsShowKnots Then
                        RemoveExistingKnot(_cell)
                    ElseIf isBlockstitchAction And My.Settings.IsShowBlockstitches Then
                        RemoveExistingBlockStitch(_cell.Position)
                    End If
                End If
            End If
        Else
            ' Doing action
            If isLeftButton Then
                If isMoveInProgress Then
                    Select Case oCurrentAction
                        Case DesignAction.Copy
                            EndCopy(_cell)
                        Case DesignAction.Paste
                            EndPaste(_cell)
                        Case DesignAction.Move
                            RemoveSelectedCells()
                            EndCopy(_cell)
                        Case DesignAction.Rotate
                            RemoveSelectedCells(True, False, False)
                            EndRotate(_cell)
                        Case DesignAction.Text
                            EndPaste(_cell)
                    End Select
                    ClearSelection()
                Else
                    Select Case oCurrentAction
                        Case DesignAction.Copy,
                                 DesignAction.Cut,
                                 DesignAction.Flip,
                                 DesignAction.Mirror,
                                 DesignAction.Move,
                                 DesignAction.Zoom,
                                 DesignAction.Rotate,
                                 DesignAction.DrawShape

                            StartSelection(_cell)
                    End Select
                End If
            Else
                Select Case oCurrentAction
                    Case DesignAction.Copy, DesignAction.Move, DesignAction.Paste, DesignAction.Rotate
                        ClearSelection()

                End Select
            End If
        End If
        PicDesign.Invalidate()
    End Sub
    Private Sub PicDesign_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseUp
        Dim _cell As Cell = FindCellFromClickLocation(e)
        If isSelectionInProgress Then
            EndSelectionAndContinueAction(e, _cell)
        End If
        Select Case oCurrentAction
            Case DesignAction.PickColour
                Dim _blockstitch As BlockStitch = FindBlockstitch(_cell.Position)
                If _blockstitch IsNot Nothing Then
                    Dim _projectThread As ProjectThread = _blockstitch.ProjThread
                    If _projectThread IsNot Nothing Then
                        For Each _control As Control In ThreadLayoutPanel.Controls
                            Dim _colourBox As PictureBox = TryCast(_control, PictureBox)
                            If _colourBox IsNot Nothing Then
                                _colourBox.BorderStyle = BorderStyle.None
                                _colourBox.BackgroundImage = Nothing
                                If CInt(_colourBox.Name) = _projectThread.ThreadId Then
                                    SelectThreadPaletteColour(_colourBox)
                                End If
                            End If
                        Next
                    End If
                End If
                ClearSelection()
            Case DesignAction.DeleteColour
                Dim _bsrem As New List(Of BlockStitch)
                Dim _knotrem As New List(Of Knot)
                Dim _backstitchrem As New List(Of BackStitch)

                Dim _stitch As Stitch = If(FindBlockstitch(_cell.Position), FindKnot(_cell))
                If _stitch IsNot Nothing Then
                    Dim _projectThread As ProjectThread = _stitch.ProjThread
                    If _projectThread IsNot Nothing Then
                        For Each _blockstitch As BlockStitch In oProjectDesign.BlockStitches
                            If _blockstitch.ProjThread.Thread.ThreadNo = _projectThread.Thread.ThreadNo Then
                                _bsrem.Add(_blockstitch)
                            End If
                        Next
                        For Each _knot As Knot In oProjectDesign.Knots
                            If _knot.ProjThread.Thread.ThreadNo = _projectThread.Thread.ThreadNo Then
                                _knotrem.Add(_knot)
                            End If
                        Next
                        For Each _backstitch As BackStitch In oProjectDesign.BackStitches
                            If _backstitch.ProjThread.Thread.ThreadNo = _projectThread.Thread.ThreadNo Then
                                _backstitchrem.Add(_backstitch)
                            End If
                        Next
                        For Each _blockstitch As BlockStitch In _bsrem
                            RemoveBlockStitchFromDesign(_blockstitch)
                        Next
                        For Each _knot As Knot In _knotrem
                            RemoveKnotFromDesign(_knot)
                        Next
                        For Each _backstitch As BackStitch In _backstitchrem
                            RemoveBackStitchFromDesign(_backstitch)
                        Next
                    End If
                    isSaved = False
                End If
                ClearSelection()
            Case DesignAction.ChangeColour
                Dim _stitch As Stitch = If(FindBlockstitch(_cell.Position), FindKnot(_cell))
                If _stitch IsNot Nothing Then
                    Dim _projectThread As ProjectThread = _stitch.ProjThread
                    If _projectThread IsNot Nothing Then
                        For Each _blockstitch As BlockStitch In oProjectDesign.BlockStitches
                            If _blockstitch.ProjThread.ThreadId = _projectThread.ThreadId Then
                                AddToCurrentUndoList(BlockStitchBuilder.ABlockStitch.StartingWith(_blockstitch).Build(), UndoAction.ChangeThread, oCurrentThread)
                                _blockstitch.ThreadId = oCurrentThread.ThreadId
                                _blockstitch.ProjThread = Nothing
                                For Each _qtr As BlockStitchQuarter In _blockstitch.Quarters
                                    If _qtr.ThreadId = _projectThread.Thread.ThreadId Then
                                        _qtr.ThreadId = oCurrentThread.ThreadId
                                    End If
                                Next
                            End If
                        Next
                        For Each _knot As Knot In oProjectDesign.Knots
                            If _knot.ProjThread.Thread.ThreadNo = _projectThread.Thread.ThreadNo Then
                                AddToCurrentUndoList(KnotBuilder.AKnot.StartingWith(_knot).Build, UndoAction.ChangeThread, oCurrentThread)
                                _knot.ProjThread = ProjectThreadBuilder.AProjectThread.StartingWith(oCurrentThread).Build
                            End If
                        Next
                        For Each _backstitch As BackStitch In oProjectDesign.BackStitches
                            If _backstitch.ProjThread.Thread.ThreadNo = _projectThread.Thread.ThreadNo Then
                                AddToCurrentUndoList(BackstitchBuilder.ABackStitch.StartingWith(_backstitch).Build, UndoAction.ChangeThread, oCurrentThread)
                                _backstitch.ProjThread = ProjectThreadBuilder.AProjectThread.StartingWith(oCurrentThread).Build
                            End If
                        Next
                    End If
                    isSaved = False
                End If
                ClearSelection()
                RedrawDesign(False)
            Case DesignAction.Fill
                FloodFill(_cell, oCurrentThread.Thread, oCurrentStitchType)
                ClearSelection()
            Case DesignAction.Clear
                FloodFill(_cell, Nothing, oCurrentStitchType)
                ClearSelection()
        End Select
        DetermineUsedThreads()
        If oCurrentUndoList.Count > 0 Then
            AddActionsToUndoList(oCurrentUndoList)
            oCurrentUndoList.Clear()
            oRedoList.Clear()
            BtnRedo.Enabled = False
            BtnUndo.Enabled = True
        End If
    End Sub
    Private Sub PicDesign_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseMove
        Dim _cell As Cell = FindCellFromClickLocation(e)
        Dim isImageChanged As Boolean = False
        Dim _cellPos As Point = _cell.Position
        Dim _cellLocation As Point = _cell.Location
        Dim _cellQtr As BlockQuarter = _cell.StitchQuarter
        Dim _knotqtr As BlockQuarter = _cell.KnotQtr
        Dim _knotPos As Point = _cell.KnotCellPos
        LblCursorPos.Text = "X:" & CStr(_cellPos.X + 1) & ", Y:" & CStr(_cellPos.Y + 1)
        PnlPixelColour.BackColor = GetPixelColour(e)
        Dim _colourName As String = String.Empty
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Threads.Find(Function(p) p.Thread.Colour = PnlPixelColour.BackColor), ProjectThread)
        Dim _projectbead As ProjectBead = CType(oProjectBeads.Beads.Find(Function(p) p.Bead.Colour = PnlPixelColour.BackColor), ProjectBead)
        If _projectThread IsNot Nothing Then
            _colourName = _projectThread.Thread.ColourName & " : " & _projectThread.Thread.Brand.BrandName & " " & _projectThread.Thread.ThreadNo
        End If
        If _projectbead IsNot Nothing Then
            Dim _brand As Brand = _projectbead.Bead.Brand
            _colourName = _projectbead.Bead.ColourName & " : " & _projectbead.Bead.Brand.BrandName & " " & _projectbead.Bead.BeadNo
        End If
        LblPixelColourName.Text = _colourName
        Dim isLeftButton As Boolean = e.Button = MouseButtons.Left
        Dim isRightButton As Boolean = e.Button = MouseButtons.Right
        Dim isNoButton As Boolean = e.Button = MouseButtons.None
        If oCurrentAction = DesignAction.none Then

            If isRightButton Then
                If isKnotAction Then
                    Dim _exists As Knot = FindKnot(_cell)
                    If _exists IsNot Nothing Then
                        RemoveKnotFromDesign(_exists)
                    End If
                ElseIf isBlockstitchAction Then
                    LogUtil.Debug("Remove blockstitch on the move", MyBase.Name)
                    Dim _exists As BlockStitch = FindBlockstitch(_cellPos)
                    If _exists IsNot Nothing Then
                        RemoveBlockStitchFromDesign(_exists)
                    End If
                End If
            End If

            If isLeftButton Then
                LogUtil.Debug("Adding stitch on the move", MyBase.Name)
                Select Case oCurrentStitchType
                    Case DesignAction.Bead
                        AddKnot(_cell, True, RbDouble.Checked)
                    Case DesignAction.Knot
                        AddKnot(_cell, False, RbDouble.Checked)
                    Case DesignAction.FullBlockstitch
                        AddFullBlockStitch(_cell, RbDouble.Checked)
                    Case DesignAction.HalfBlockstitchBack
                        AddHalfBlockStitch(_cell, True, RbDouble.Checked)
                    Case DesignAction.HalfBlockstitchForward
                        AddHalfBlockStitch(_cell, False, RbDouble.Checked)
                    Case DesignAction.QuarterBlockstitchBottomRight
                        AddQuarterBlockstitch(_cell, BlockQuarter.BottomRight, RbDouble.Checked)
                    Case DesignAction.QuarterBlockstitchBottonLeft
                        AddQuarterBlockstitch(_cell, BlockQuarter.BottomLeft, RbDouble.Checked)
                    Case DesignAction.QuarterBlockstitchTopLeft
                        AddQuarterBlockstitch(_cell, BlockQuarter.TopLeft, RbDouble.Checked)
                    Case DesignAction.QuarterBlockstitchTopRight
                        AddQuarterBlockstitch(_cell, BlockQuarter.TopRight, RbDouble.Checked)
                    Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                        AddThreeQuarterStitch(_cell, BlockQuarter.BottomLeft, RbDouble.Checked)
                    Case DesignAction.ThreeQuarterBlockstitchBottomRight
                        AddThreeQuarterStitch(_cell, BlockQuarter.BottomRight, RbDouble.Checked)
                    Case DesignAction.ThreeQuarterBlockstitchTopLeft
                        AddThreeQuarterStitch(_cell, BlockQuarter.TopLeft, RbDouble.Checked)
                    Case DesignAction.ThreeQuarterBlockstitchTopRight
                        AddThreeQuarterStitch(_cell, BlockQuarter.TopRight, RbDouble.Checked)
                    Case DesignAction.BlockstitchQuarters
                        AddQuarterBlockstitch(_cell, _cellQtr, RbDouble.Checked)
                End Select
            End If
            If isBackstitchInProgress Then
                Select Case oCurrentStitchType
                    Case DesignAction.BackStitchFullThin
                        DrawBackstitchInProgress(_knotPos, BlockQuarter.TopLeft, False)
                    Case DesignAction.BackstitchHalfThin
                        DrawBackstitchInProgress(_knotPos, _knotqtr, True)
                End Select
            End If
        Else
            If isLeftButton Then
                'area definition
                SelectionInProgress(e, _cell)
            End If
            If isNoButton Then
                If isMoveInProgress Then
                    'paste positioning
                    SetPasteDestination(e, _cell)
                End If
            End If
        End If
        PicDesign.Invalidate()
    End Sub
    Private Sub PicDesign_MouseWheel(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseWheel
        ' Update the drawing based upon the mouse wheel scrolling.
        Dim numberOfTextLinesToMove As Integer = CInt(e.Delta * SystemInformation.MouseWheelScrollLines / 120)
        VScrollBar1.Value = Math.Max(0, Math.Min(VScrollBar1.Maximum, VScrollBar1.Value - numberOfTextLinesToMove * VScrollBar1.SmallChange))
    End Sub
    Private Sub HScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        If Not isLoading Then
            Dim _h_change As Integer = (iOldHScrollbarValue - HScrollBar1.Value)
            Dim _newOff_x As Integer = iXOffset + _h_change - topcorner.X
            SetValuesAfterHorizontalChange(_newOff_x)
            PicDesign.Invalidate()
            iOldHScrollbarValue = HScrollBar1.Value
        End If
    End Sub
    Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        If Not isLoading Then
            Dim _v_change As Integer = (iOldVScrollbarValue - VScrollBar1.Value)
            Dim _newOff_y As Integer = iYOffset + _v_change - topcorner.Y
            SetValuesAfterVerticalChange(_newOff_y)
            PicDesign.Invalidate()
            iOldVScrollbarValue = VScrollBar1.Value
        End If
    End Sub
    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        BtnPrint.Enabled = False
        Try
            DisplayImage(oDesignBitmap, iXOffset, iYOffset, e)
        Catch ex As ApplicationException

            LogUtil.LogException(ex, "Error displaying design image", MethodBase.GetCurrentMethod.Name)
        End Try
        If isBackstitchInProgress Then
            e.Graphics.DrawLine(_backstitchPen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
        End If
        If isRemoveBackstitchInProgress Then
            e.Graphics.DrawLine(_backstitchPen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
        End If
        If isSelectionInProgress Or isMoveInProgress Then
            Dim _width As Integer = _toCellLocation_x - _fromCellLocation_x + iPixelsPerCell
            Dim _height As Integer = _toCellLocation_y - _fromCellLocation_y + iPixelsPerCell
            e.Graphics.DrawRectangle(oSelectionPen, _fromCellLocation_x, _fromCellLocation_y, _width, _height)
        End If
        BtnPrint.Enabled = True
    End Sub
    Private Sub FlowLayoutPanel1_SizeChanged(sender As Object, e As EventArgs) Handles ThreadLayoutPanel.SizeChanged,
                                                                                        BeadLayoutPanel.SizeChanged
        If isComponentInitialised Then
            InitialisePalette()
        End If
    End Sub
    Private Sub Stitches_CheckedChanged(sender As Object, e As EventArgs) Handles MnuBlockStitches.CheckedChanged,
                                                                                 MnuKnots.CheckedChanged,
                                                                                 MnuBackStitches.CheckedChanged
        SetStitchTypesSettings()
        If isComponentInitialised AndAlso Not isLoading Then
            RedrawDesign(False)
        End If
    End Sub
    Private Sub Thread_Palette_Click(sender As Object, e As EventArgs)
        ResetPaletteBorders(ThreadLayoutPanel)
        Dim _picBox As PictureBox = CType(sender, PictureBox)
        SelectThreadPaletteColour(_picBox)
    End Sub

    Private Sub ResetPaletteBorders(pPanel As FlowLayoutPanel)
        For Each _control As Control In pPanel.Controls
            Dim _colourBox As PictureBox = TryCast(_control, PictureBox)
            If _colourBox IsNot Nothing Then
                _colourBox.BorderStyle = BorderStyle.None
                _colourBox.BackgroundImage = Nothing
            End If
        Next
    End Sub

    Private Sub Bead_Palette_Click(sender As Object, e As EventArgs)
        ResetPaletteBorders(BeadLayoutPanel)
        Dim _picBox As PictureBox = CType(sender, PictureBox)
        SelectBeadPaletteColour(_picBox)
    End Sub
    Private Sub BtnCancelPalette_Click(sender As Object, e As EventArgs) Handles BtnCancelPalette.Click
        PnlPaletteName.Visible = False
    End Sub
    Private Sub BtnSavePalette_Click(sender As Object, e As EventArgs) Handles BtnSavePalette.Click
        SaveProjectThreadsAsPalette()
        PnlPaletteName.Visible = False
    End Sub
#End Region
#Region "menus"
    Private Sub MnuOpenDesign_Click(sender As Object, e As EventArgs) Handles MnuOpenDesign.Click
        If MsgBox("Re-open design and replace work-in-progress?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Dim _filename As String = FileUtil.GetFileName(FileUtil.OpenOrSave.Open, FileUtil.FileType.HSA, oDesignArchiveFolderName)
            Dim _designString As List(Of String) = OpenDesignFile(oDesignArchiveFolderName, _filename)
            For Each _line As String In _designString
                If Not String.IsNullOrEmpty(_line) Then
                    If _line.StartsWith(DESIGN_HDR) Then
                        Dim _designValues As String() = _line.Split(DESIGN_DELIM)
                        oProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(_designValues).Build()
                        Exit For
                    End If
                End If
            Next
            RedrawDesign(False)
        End If
    End Sub
    Private Sub MnuSaveDesign_Click(sender As Object, e As EventArgs) Handles MnuSaveDesign.Click
        SaveDesign()
    End Sub
    Private Sub MnuSaveDesignAs_Click(sender As Object, e As EventArgs) Handles MnuSaveDesignAs.Click
        Dim _filename As String = FileUtil.GetFileName(FileUtil.OpenOrSave.Save, FileUtil.FileType.HSZ, My.Settings.DesignFilePath)
        If Not String.IsNullOrEmpty(_filename) Then
            SaveDesignToFile(_filename)
        End If
    End Sub
    Private Sub MnuExit_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
        Close()
    End Sub
    Private Sub MnuThreadSymbols_Click(sender As Object, e As EventArgs) Handles MnuThreadSymbols.Click
        If oProject.ProjectId > 0 Then
            LogUtil.Info("Opening Project ProjectThread Symbols form", MyBase.Name)
            Using _threadsymbols As New FrmThreadSymbols
                _threadsymbols.SelectedProject = oProject
                _threadsymbols.ShowDialog()
            End Using
            InitialisePalette()
        End If
    End Sub
    Private Sub MnuZoomOut_Click(sender As Object, e As EventArgs) Handles MnuZoomOut.Click
        DecreaseMagnification()
    End Sub
    Private Sub MnuGridOn_Click(sender As Object, e As EventArgs) Handles MnuGridOn.Click
        ToggleGrid()
    End Sub
    Private Sub MnuCopySelection_Click(sender As Object, e As EventArgs) Handles MnuCopySelection.Click
        BeginCopy()
    End Sub
    Private Sub MnuMoveSelection_Click(sender As Object, e As EventArgs) Handles MnuMoveSelection.Click
        BeginMove()
    End Sub
    Private Sub MnuCutSelection_Click(sender As Object, e As EventArgs) Handles MnuCutSelection.Click
        BeginCut()
    End Sub
    Private Sub MnuPaste_Click(sender As Object, e As EventArgs) Handles MnuPaste.Click
        BeginPaste()
    End Sub
    Private Sub MnuFlipSelection_Click(sender As Object, e As EventArgs) Handles MnuFlipSelection.Click
        BeginFlip()
    End Sub
    Private Sub MnuMirrorSelection_Click(sender As Object, e As EventArgs) Handles MnuMirrorSelection.Click
        BeginMirror()
    End Sub
    Private Sub MnuRotate_Click(sender As Object, e As EventArgs) Handles MnuRotate.Click
        BeginRotate()
    End Sub
    Private Sub MnuFloodFill_Click(sender As Object, e As EventArgs) Handles MnuFloodFill.Click
        BeginFloodFill()
    End Sub
    Private Sub MnuClearArea_Click(sender As Object, e As EventArgs) Handles MnuClearArea.Click
        BeginClearArea()
    End Sub
    Private Sub MnuRedraw_Click(sender As Object, e As EventArgs) Handles MnuRedraw.Click
        oProjectDesign = SortStitches(oProjectDesign)
        RedrawDesign(False)
    End Sub
    Private Sub MnuZoom_Click(sender As Object, e As EventArgs) Handles MnuZoom.Click
        BeginZoom()
    End Sub
    Private Sub MnuCropDesign_Click(sender As Object, e As EventArgs) Handles MnuCropDesign.Click
        ShowDesignSizeForm(False)
    End Sub
    Private Sub MnuExtendDesign_Click(sender As Object, e As EventArgs) Handles MnuExtendDesign.Click
        ShowDesignSizeForm(True)
    End Sub
    Private Sub ShowDesignSizeForm(pIsExtend)
        Using _designSize As New FrmDesignSize
            _designSize.Project = oProject
            _designSize.ProjectDesign = oProjectDesign
            _designSize.IsExtend = pIsExtend
            _designSize.ShowDialog()
            If _designSize.IsChanged = True Then
                AmendProject(oProject)
                LblStatus.Text = SaveDesign()
                iOriginX = oProject.OriginX
                iOriginY = oProject.OriginY
                oUndoList = New List(Of List(Of StitchAction))
                oRedoList = New List(Of List(Of StitchAction))
                BtnUndo.Enabled = False
                BtnRedo.Enabled = False
                RedrawDesign(False)
            End If
        End Using
    End Sub
    Private Sub MnuShowDesignStats_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub MnuOptions_Click(sender As Object, e As EventArgs) Handles MnuOptions.Click
        OpenPreferencesForm(Me)
    End Sub
    Private Sub MnuZoomIn_Click(sender As Object, e As EventArgs) Handles MnuZoomIn.Click
        IncreaseMagnification()
    End Sub
    Private Sub MnuStitchDisplayStyle_Click(sender As Object, e As EventArgs) Handles MnuStitchDisplayStyle.Click
        Using _stitchStyle As New FrmStitchDisplayStyle
            _stitchStyle.ShowDialog()
        End Using
        oStitchDisplayStyle = My.Settings.DesignStitchDisplay
        RedrawDesign(False)
        InitialisePalette()
    End Sub
    Private Sub MnuSingleColour_Click(sender As Object, e As EventArgs) Handles MnuSingleColour.Click
        ToggleSingleColour()
    End Sub
    Private Sub MnuCentreOn_Click(sender As Object, e As EventArgs) Handles MnuCentreOn.Click
        ToggleCentre()
    End Sub
    Private Sub MnuPrint_Click(sender As Object, e As EventArgs) Handles MnuPrint.Click
        ShowPrintForm()
    End Sub
    Private Sub MnuPickColour_Click(sender As Object, e As EventArgs) Handles MnuPickColour.Click
        BeginPickColour()
    End Sub
    Private Sub MnuChangeColour_Click(sender As Object, e As EventArgs) Handles MnuChangeColour.Click
        BeginChangeColour()
    End Sub
    Private Sub MnuDeleteColour_Click(sender As Object, e As EventArgs) Handles MnuDeleteColour.Click
        BeginDeleteColour()
    End Sub
    Private Sub MnuEllipse_Click(sender As Object, e As EventArgs) Handles MnuEllipse.Click
        BeginDrawShape(ShapeType.Ellipse)
    End Sub
    Private Sub MnuRectangle_Click(sender As Object, e As EventArgs) Handles MnuRectangle.Click
        BeginDrawShape(ShapeType.Rectangle)
    End Sub
    Private Sub MnuFilledEllipse_Click(sender As Object, e As EventArgs) Handles MnuFilledEllipse.Click
        BeginDrawShape(ShapeType.FilledEllipse)
    End Sub
    Private Sub MnuFilledRecangle_Click(sender As Object, e As EventArgs) Handles MnuFilledRecangle.Click
        BeginDrawShape(ShapeType.FilledRectangle)
    End Sub
    Private Sub MnuSymbols_Click(sender As Object, e As EventArgs) Handles MnuSymbols.Click
        OpenSymbolsForm()
        InitialisePalette()
    End Sub
    Private Sub MnuShow_Click(sender As Object, e As EventArgs) Handles MnuShow.Click
        ShowDesignInfo()
    End Sub
    Private Sub MnuSelectColours_Click(sender As Object, e As EventArgs) Handles MnuSelectColours.Click
        OpenProjectThreadsForm()
    End Sub
    Private Sub MnuRemoveUnused_Click(sender As Object, e As EventArgs) Handles MnuRemoveUnused.Click
        RemoveUnusedThreads()
        InitialisePalette()
    End Sub
    Private Sub MnuSavePalette_Click(sender As Object, e As EventArgs) Handles MnuSavePalette.Click
        GetPaletteName()
    End Sub
    Private Sub MnuThreadCards_Click(sender As Object, e As EventArgs) Handles MnuThreadCards.Click

        OpenBuildCardsForm(oProject)
    End Sub
    Private Sub MnuPrintCards_Click(sender As Object, e As EventArgs) Handles MnuPrintCards.Click
        OpenPrintCardsForm()
    End Sub
    Private Sub MnuCentreMarks_Click(sender As Object, e As EventArgs) Handles MnuCentreMarks.Click
        ToggleCentreMarks()
    End Sub
    Private Sub MnuText_Click(sender As Object, e As EventArgs) Handles MnuText.Click
        BeginText()
    End Sub
#End Region
#Region "stitch buttons"
    Private Sub BtnFullStitch_Click(sender As Object, e As EventArgs) Handles BtnFullStitch.Click
        SelectFullBlockstitch()
    End Sub
    Private Sub Btn3QtrsTL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTL.Click
        oCurrentStitchType = DesignAction.ThreeQuarterBlockstitchTopLeft
        StitchButtonSelected(Btn3QtrsTL)
    End Sub
    Private Sub Btn3QtrsTR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTR.Click
        oCurrentStitchType = DesignAction.ThreeQuarterBlockstitchTopRight
        StitchButtonSelected(Btn3QtrsTR)
    End Sub
    Private Sub Btn3QtrsBR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBR.Click
        oCurrentStitchType = DesignAction.ThreeQuarterBlockstitchBottomRight
        StitchButtonSelected(Btn3QtrsBR)
    End Sub
    Private Sub Btn3QtrsBL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBL.Click
        oCurrentStitchType = DesignAction.ThreeQuarterBlockstitchBottomLeft
        StitchButtonSelected(Btn3QtrsBL)
    End Sub
    Private Sub BtnHalfForward_Click(sender As Object, e As EventArgs) Handles BtnHalfForward.Click
        oCurrentStitchType = DesignAction.HalfBlockstitchForward
        StitchButtonSelected(BtnHalfForward)
    End Sub
    Private Sub BtnHalfBack_Click(sender As Object, e As EventArgs) Handles BtnHalfBack.Click
        oCurrentStitchType = DesignAction.HalfBlockstitchBack
        StitchButtonSelected(BtnHalfBack)
    End Sub
    Private Sub BtnQtrTL_Click(sender As Object, e As EventArgs) Handles BtnQtrTL.Click
        oCurrentStitchType = DesignAction.QuarterBlockstitchTopLeft
        StitchButtonSelected(BtnQtrTL)
    End Sub
    Private Sub BtnQWtrTR_Click(sender As Object, e As EventArgs) Handles BtnQtrTR.Click
        oCurrentStitchType = DesignAction.QuarterBlockstitchTopRight
        StitchButtonSelected(BtnQtrTR)
    End Sub
    Private Sub BtnQtrBR_Click(sender As Object, e As EventArgs) Handles BtnQtrBR.Click
        oCurrentStitchType = DesignAction.QuarterBlockstitchBottomRight
        StitchButtonSelected(BtnQtrBR)
    End Sub
    Private Sub BtnQtrBL_Click(sender As Object, e As EventArgs) Handles BtnQtrBL.Click
        oCurrentStitchType = DesignAction.QuarterBlockstitchBottonLeft
        StitchButtonSelected(BtnQtrBL)
    End Sub
    Private Sub BtnQuarters_Click(sender As Object, e As EventArgs) Handles BtnQuarters.Click
        oCurrentStitchType = DesignAction.BlockstitchQuarters
        StitchButtonSelected(BtnQuarters)
    End Sub
    Private Sub BtnFullBackstitchThin_Click(sender As Object, e As EventArgs) Handles BtnFullBackstitch.Click
        oCurrentStitchType = DesignAction.BackStitchFullThin
        StitchButtonSelected(BtnFullBackstitch)
    End Sub
    Private Sub BtnHalfBackStitchThin_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitch.Click
        oCurrentStitchType = DesignAction.BackstitchHalfThin
        StitchButtonSelected(BtnHalfBackStitch)
    End Sub
    Private Sub BtnKnot_Click(sender As Object, e As EventArgs) Handles BtnKnot.Click
        oCurrentStitchType = DesignAction.Knot
        StitchButtonSelected(BtnKnot)
    End Sub
    Private Sub BtnBead_Click(sender As Object, e As EventArgs) Handles BtnBead.Click
        If oProjectBeads.Count > 0 Then
            oCurrentStitchType = DesignAction.Bead
            StitchButtonSelected(BtnBead)
        Else
            MsgBox("Add beads to the palette to use beads in the design", MsgBoxStyle.Exclamation, "Function no available")
            LogUtil.ShowStatus("No beads on the palette", LblStatus)
        End If
    End Sub
    Private Sub SelectFullBlockstitch()
        oCurrentStitchType = DesignAction.FullBlockstitch
        StitchButtonSelected(BtnFullStitch)
    End Sub
    Private Sub StitchButtonSelected()
        StitchButtonSelected(Nothing)
    End Sub
    Private Sub StitchButtonSelected(pButton As ToolStripButton)
        SetCurrentActionClass()
        For Each _item As Object In ToolStrip2.Items
            Dim _button As ToolStripButton = TryCast(_item, ToolStripButton)
            If _button IsNot Nothing Then
                _button.BackgroundImage = My.Resources.BtnBkgrd
            End If
        Next
        If pButton IsNot Nothing Then
            pButton.BackgroundImage = My.Resources.BtnBkgrdDown
            PicStitch.Image = pButton.Image
        Else
            PicStitch.Image = Nothing
        End If
        If oCurrentStitchType = DesignAction.Bead Then
            If oCurrentBead IsNot Nothing Then
                LblCurrentColour.Text = oCurrentBead.Bead.ColourName & " : " & oCurrentBead.Bead.Brand.BrandName & " " & CStr(oCurrentBead.Bead.ThreadNo)
            End If
        Else
            If oCurrentThread IsNot Nothing Then
                LblCurrentColour.Text = oCurrentThread.Thread.ColourName & " : " & oCurrentThread.Thread.Brand.BrandName & " " & CStr(oCurrentThread.Thread.ThreadNo)
            End If
        End If

    End Sub
#End Region
#Region "action buttons"
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        LblStatus.Text = SaveDesign()
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        ShowPrintForm()
    End Sub
    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        BeginCopy()
    End Sub
    Private Sub BtnCut_Click(sender As Object, e As EventArgs) Handles BtnCut.Click
        BeginCut()
    End Sub
    Private Sub BtnMove_Click(sender As Object, e As EventArgs) Handles BtnMove.Click
        BeginMove()
    End Sub
    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        BeginPaste()
    End Sub
    Private Sub BtnMirror_Click(sender As Object, e As EventArgs) Handles BtnMirror.Click
        BeginMirror()
    End Sub
    Private Sub BtnFlip_Click(sender As Object, e As EventArgs) Handles BtnFlip.Click
        BeginFlip()
    End Sub
    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles BtnUndo.Click
        UndoLastAction()
    End Sub
    Private Sub BtnRedo_Click(sender As Object, e As EventArgs) Handles BtnRedo.Click
        RedoLastUndo()
    End Sub
    Private Sub BtnZoom_Click(sender As Object, e As EventArgs) Handles BtnZoom.Click
        BeginZoom()
    End Sub
    Private Sub BtnEnlarge_Click(sender As Object, e As EventArgs) Handles BtnEnlarge.Click
        IncreaseMagnification()
    End Sub
    Private Sub BtnShrink_Click(sender As Object, e As EventArgs) Handles BtnShrink.Click
        DecreaseMagnification()
    End Sub
    Private Sub BtnCentre_Click(sender As Object, e As EventArgs) Handles BtnCentre.Click
        isLoading = True
        CalculateOffsetForCentre(oDesignBitmap)
        PicDesign.Invalidate()
        isLoading = False
    End Sub
    Private Sub BtnHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeight.Click
        isLoading = True
        Dim _newPpc As Decimal = PicDesign.Height / oProjectDesign.Rows
        Dim _heightRatio As Decimal = _newPpc / PIXELS_PER_CELL
        ChangeMagnification(_heightRatio)
        CalculateOffsetAfterChange(0, 0)
        RedrawDesign(False)
        isLoading = False
    End Sub
    Private Sub BtnWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWidth.Click
        isLoading = True
        Dim _newPpc As Decimal = PicDesign.Width / oProjectDesign.Columns
        Dim _widthRatio As Decimal = _newPpc / PIXELS_PER_CELL
        ChangeMagnification(_widthRatio)
        CalculateOffsetAfterChange(0, 0)
        RedrawDesign(False)
        isLoading = False
    End Sub
    Private Sub BtnTimer_Click(sender As Object, e As EventArgs) Handles BtnTimer.Click
        StartProjectTimer(oProject)
    End Sub
    Private Sub BtnSingleColour_Click(sender As Object, e As EventArgs) Handles BtnSingleColour.Click
        ToggleSingleColour()
    End Sub
    Private Sub BtnRotate_Click(sender As Object, e As EventArgs) Handles BtnRotate.Click
        BeginRotate()
    End Sub
    Private Sub BtnText_Click(sender As Object, e As EventArgs) Handles BtnText.Click
        BeginText()
    End Sub

#Region "begin actions"
    Private Sub BeginCopy()
        oCurrentAction = DesignAction.Copy
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select area to copy")
    End Sub
    Private Sub BeginZoom()
        oCurrentAction = DesignAction.Zoom
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select area to zoom into")
    End Sub
    Private Sub BeginMove()
        oCurrentAction = DesignAction.Move
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select area to move")
    End Sub
    Private Sub BeginCut()
        oCurrentAction = DesignAction.Cut
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select area to cut")
    End Sub
    Private Sub BeginPaste()
        oCurrentAction = DesignAction.Paste
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select location to paste")
        isMoveInProgress = True
    End Sub
    Private Sub BeginFlip()
        oCurrentAction = DesignAction.Flip
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select area to flip")
    End Sub
    Private Sub BeginMirror()
        oCurrentAction = DesignAction.Mirror
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select area to mirror")
    End Sub
    Private Sub BeginRotate()
        oCurrentAction = DesignAction.Rotate
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Select area to rotate")
    End Sub
    Private Sub BeginDrawShape(pShape As ShapeType)
        oCurrentAction = DesignAction.DrawShape
        oCurrentStitchType = DesignAction.none
        oCurrentShapeType = pShape
        StitchButtonSelected()
        SelectionMessage("Select location for shape")
    End Sub
    Private Sub BeginDeleteColour()
        oCurrentAction = DesignAction.DeleteColour
        SelectionMessage("Click on stitch to delete colour")
    End Sub
    Private Sub BeginPickColour()
        oCurrentAction = DesignAction.PickColour
        SelectionMessage("Click on stitch to select colour")
    End Sub
    Private Sub BeginChangeColour()
        oCurrentAction = DesignAction.ChangeColour
        SelectionMessage("Click on stitch to change colour")
    End Sub
    Private Sub BeginFloodFill()
        oCurrentAction = DesignAction.Fill
        SelectionMessage("Click in area to fill")
    End Sub
    Private Sub BeginClearArea()
        oCurrentAction = DesignAction.Clear
        SelectionMessage("Click in area to clear")
    End Sub
#End Region
#End Region
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isLoading = True
        PicDesign.Enabled = False
        oDesignBitmap = Nothing
        Refresh()
        LoadSettings(Me)
        oProject = FindProjectById(oProjectId)
        iOriginX = oProject.OriginX
        iOriginY = oProject.OriginY
        oCurrentUndoList = New List(Of StitchAction)
        oUndoList = New List(Of List(Of StitchAction))
        oRedoList = New List(Of List(Of StitchAction))
        BtnUndo.Enabled = False
        BtnRedo.Enabled = False
        BtnPrint.Enabled = False
        oStitchDisplayStyle = My.Settings.DesignStitchDisplay
        SetIsGridOn()
        SetIsCentreOn()
        SetShowStitchTypesMenu()
        SelectFullBlockstitch()
        PnlSelectedColor.BackColor = Me.BackColor
        If oProject.IsLoaded Then
            InitialisePalette()
            LblStatus.Text = "Loading..."
            LblStatus.Refresh()
            Dim _isPaletteChanged As Boolean
            LoadProjectDesignFromFile(oProject, PicDesign, isGridOn, isCentreOn, _isPaletteChanged, isCentreMarksOn)
            If _isPaletteChanged Then
                InitialisePalette()
            End If
            CalculateScrollBarMaximumValues()
            LblStatus.Text = String.Empty
        Else
            MsgBox("No project found", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If
        PicDesign.Enabled = True
        InitialiseTimer()
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
    End Sub
    Friend Sub LoadDesignSettings()
        SetIsCentreOn()
        SetIsGridOn()
        SetIsCentreMarks()

        If Not isLoading Then
            RedrawDesign(False)
        End If
    End Sub
    Private Function InitialisePalette() As Boolean
        LogUtil.LogInfo("Initialising palette", MyBase.Name)
        Dim isOK As Boolean = True
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.PaletteStitchDisplay
        If isComponentInitialised Then
            LoadThreadPalette(_stitchDisplayStyle)
            LoadBeadPalette
        End If
        Return isOK
    End Function

    Private Sub LoadThreadPalette(_stitchDisplayStyle As StitchDisplayStyle)
        ThreadLayoutPanel.Controls.Clear()
        oProjectThreads = FindProjectThreads(oProject.ProjectId)
        If IsProjectHasThreads() Then
            oProjectThreads.Threads.Sort(Function(x As ProjectThread, y As ProjectThread) x.Thread.SortNumber.CompareTo(y.Thread.SortNumber))
            Dim _panelWidth As Integer = ThreadLayoutPanel.Width
            Dim _panelHeight As Integer = ThreadLayoutPanel.Height
            Dim _threadCt As Integer = oProjectThreads.Count
            Dim _picSize As Integer = ShrinkPic(ThreadLayoutPanel, _threadCt)
            Dim _firstPicThread As PictureBox = Nothing

            For Each _projectThread As ProjectThread In oProjectThreads.Threads
                Dim _thread As Thread = _projectThread.Thread
                Dim _picThread As New PictureBox()
                Dim _image As Image = New Bitmap(_picSize, _picSize)
                Dim _pen As New Pen(_thread.Colour, _picSize / 8) With {
                                                .StartCap = Drawing2D.LineCap.Round,
                                                .EndCap = Drawing2D.LineCap.Round
                                            }
                With _picThread
                    .Name = CStr(_thread.ThreadId)
                    .Size = New Size(_picSize, _picSize)
                    .BorderStyle = BorderStyle.None
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .BackColor = Color.White
                    Select Case _stitchDisplayStyle
                        Case StitchDisplayStyle.Blocks
                            .BackColor = _thread.Colour
                        Case StitchDisplayStyle.BlocksWithSymbols
                            .BackColor = _thread.Colour
                            If _projectThread.SymbolId > 0 Then
                                _image = FindSymbolById(_projectThread.SymbolId).SymbolImage
                            End If
                        Case StitchDisplayStyle.Crosses
                            Using _graphics As Graphics = Graphics.FromImage(_image)
                                _graphics.DrawLine(_pen, 2, 2, _picSize - 2, _picSize - 2)
                                _graphics.DrawLine(_pen, _picSize - 2, 2, 2, _picSize - 2)
                            End Using
                        Case StitchDisplayStyle.BlackWhiteSymbols
                            If _projectThread.SymbolId > 0 Then
                                _image = FindSymbolById(_projectThread.SymbolId).SymbolImage
                            End If
                        Case StitchDisplayStyle.ColouredSymbols
                            If _projectThread.SymbolId > 0 Then
                                _image = FindSymbolById(_projectThread.SymbolId).SymbolImage
                                If _image IsNot Nothing Then
                                    Dim _symbolColour As Color = _thread.Colour
                                    Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(_thread)
                                    Using _graphics As Graphics = Graphics.FromImage(_image)
                                        _graphics.DrawImage(_image, New Rectangle(New Point(0, 0), _image.Size), 0, 0, _image.Width, _image.Height, GraphicsUnit.Pixel, _imageAttributes)
                                    End Using
                                End If
                            End If
                    End Select
                    If _projectThread.IsUsed Then
                        Using _graphics As Graphics = Graphics.FromImage(_image)
                            Dim _points As Point() = {New Point(0, 0), New Point(0, 8), New Point(8, 0)}
                            _graphics.FillPolygon(New SolidBrush(ThreadLayoutPanel.BackColor), _points)
                        End Using
                    End If
                    Dim tt As New ToolTip
                    tt.SetToolTip(_picThread, _thread.ColourName & " " & _thread.ThreadNo)
                    AddHandler .Click, AddressOf Thread_Palette_Click
                    .Image = _image
                    _pen.Dispose()
                End With
                ThreadLayoutPanel.Controls.Add(_picThread)
                _firstPicThread = If(_firstPicThread, _picThread)
            Next
            If _firstPicThread IsNot Nothing Then
                SelectThreadPaletteColour(_firstPicThread)
            End If
        End If
    End Sub
    Private Sub LoadBeadPalette()
        BeadLayoutPanel.Controls.Clear()
        oProjectBeads = FindProjectBeads(oProject.ProjectId)
        If oProjectBeads.Count > 0 Then
            oProjectBeads.Beads.Sort(Function(x As ProjectBead, y As ProjectBead) x.Bead.SortNumber.CompareTo(y.Bead.SortNumber))
            Dim _panelWidth As Integer = BeadLayoutPanel.Width
            Dim _panelHeight As Integer = BeadLayoutPanel.Height
            Dim _BeadCt As Integer = oProjectBeads.Count
            Dim _picSize As Integer = ShrinkPic(BeadLayoutPanel, _BeadCt)
            Dim _firstPicBead As PictureBox = Nothing

            For Each _projectBead As ProjectBead In oProjectBeads.Beads
                Dim _Bead As Bead = _projectBead.Bead
                Dim _picBead As New PictureBox()
                Dim _image As Image = New Bitmap(_picSize, _picSize)
                Dim _pen As New Pen(_Bead.Colour, 3)
                With _picBead
                    .Name = CStr(_Bead.BeadId)
                    .Size = New Size(_picSize, _picSize)
                    .BorderStyle = BorderStyle.None
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .BackColor = Color.White
                    Using _graphics As Graphics = Graphics.FromImage(_image)
                        _graphics.FillEllipse(New SolidBrush(_Bead.Colour), New Rectangle(3, 3, _picSize - 6, _picSize - 6))
                        _graphics.DrawEllipse(New Pen(Brushes.Black), New Rectangle(3, 3, _picSize - 6, _picSize - 6))
                    End Using

                    If _projectBead.IsUsed Then
                        Using _graphics As Graphics = Graphics.FromImage(_image)
                            Dim _points As Point() = {New Point(0, 0), New Point(0, 8), New Point(8, 0)}
                            _graphics.FillPolygon(New SolidBrush(Color.Black), _points)
                        End Using
                    End If
                    Dim tt As New ToolTip
                    tt.SetToolTip(_picBead, _Bead.ColourName & " " & _Bead.BeadNo)
                    AddHandler .Click, AddressOf Bead_Palette_Click
                    .Image = _image
                    _pen.Dispose()
                End With
                BeadLayoutPanel.Controls.Add(_picBead)
                _firstPicBead = If(_firstPicBead, _picBead)
            Next
            If _firstPicBead IsNot Nothing Then
                SelectBeadPaletteColour(_firstPicBead)
            End If
        End If

    End Sub

    Private Sub SelectThreadPaletteColour(pPicBox As PictureBox)
        If isSingleColour Then
            ToggleSingleColour()
        End If
        pPicBox.BorderStyle = BorderStyle.Fixed3D
        pPicBox.BackgroundImage = My.Resources.ColrBtnDown
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Threads.Find(Function(p) p.Thread.ThreadId = CInt(pPicBox.Name)), ProjectThread)
        Dim _thread As Thread = _projectThread.Thread
        oCurrentThread = _projectThread
        PnlSelectedColor.BackColor = _thread.Colour
        LblCurrentColour.Text = _thread.ColourName & " : " & _thread.Brand.BrandName & " " & CStr(_thread.ThreadNo)
    End Sub
    Private Sub SelectBeadPaletteColour(pPicBox As PictureBox)
        If isSingleColour Then
            ToggleSingleColour()
        End If
        pPicBox.BorderStyle = BorderStyle.Fixed3D
        pPicBox.BackgroundImage = My.Resources.ColrBtnDown
        Dim _projectBead As ProjectBead = CType(oProjectBeads.Beads.Find(Function(p) p.Bead.BeadId = CInt(pPicBox.Name)), ProjectBead)
        Dim _Bead As Bead = _projectBead.Bead
        oCurrentBead = _projectBead
        PnlSelectedColor.BackColor = _Bead.Colour
        LblCurrentColour.Text = _Bead.ColourName & " : " & _Bead.Brand.BrandName & " " & CStr(_Bead.BeadNo)
    End Sub
    Private Sub OpenProjectThreadsForm()
        If oProject.ProjectId > 0 Then
            LogUtil.Info("Opening Project Threads form", MyBase.Name)
            Using _projthreads As New FrmProjectThreads
                _projthreads.SelectedProject = oProject
                _projthreads.UsedThreads = DetermineUsedThreads()
                _projthreads.ShowDialog()
            End Using
            InitialisePalette()
        End If
    End Sub
    Private Sub SetInitialMagnification()
        ChangeMagnification(1)
        Dim _widthRatio As Decimal = Math.Round(PicDesign.Width / iOneToOneSize.Width, 2, MidpointRounding.AwayFromZero)
        Dim _heightRatio As Decimal = Math.Round(PicDesign.Height / iOneToOneSize.Height, 2, MidpointRounding.AwayFromZero)
        If iOneToOneSize.Width <= PicDesign.Width Then
            If iOneToOneSize.Height > PicDesign.Height Then
                ChangeMagnification(_heightRatio)
            End If
        Else
            If iOneToOneSize.Height > PicDesign.Height Then
                If _widthRatio < _heightRatio Then
                    ChangeMagnification(_widthRatio)
                Else
                    ChangeMagnification(_heightRatio)
                End If
            Else
                ChangeMagnification(_widthRatio)
            End If
        End If
    End Sub
    Private Function IsProjectHasThreads() As Boolean
        Dim isHasThreads As Boolean = True
        Do While oProjectThreads.Count = 0
            If MsgBox("Select threads to continue with the project?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "No Project Threads") = MsgBoxResult.Cancel Then
                isHasThreads = False
                Close()
                Return isHasThreads
                Exit Function
            End If
            OpenProjectThreadsForm()
            oProjectThreads = FindProjectThreads(oProject.ProjectId)
        Loop
        Return isHasThreads
    End Function
    Private Sub SetShowStitchTypesMenu()
        MnuBackStitches.Checked = My.Settings.IsShowBackstitches
        MnuBlockStitches.Checked = My.Settings.IsShowBlockstitches
        MnuKnots.Checked = My.Settings.IsShowKnots
    End Sub
    Private Sub SetStitchTypesSettings()
        My.Settings.IsShowBackstitches = MnuBackStitches.Checked
        My.Settings.IsShowBlockstitches = MnuBlockStitches.Checked
        My.Settings.IsShowKnots = MnuKnots.Checked
        My.Settings.Save()
    End Sub
    Private Sub SetCurrentActionClass()
        isKnotAction = False
        isBackstitchAction = False
        isBlockstitchAction = False
        Select Case oCurrentStitchType
            Case DesignAction.Knot,
                 DesignAction.Bead
                isKnotAction = True
            Case DesignAction.BackStitchFullThin,
                 DesignAction.BackstitchHalfThin
                isBackstitchAction = True
            Case DesignAction.FullBlockstitch,
                 DesignAction.HalfBlockstitchBack,
                 DesignAction.HalfBlockstitchForward,
                 DesignAction.QuarterBlockstitchBottomRight,
                 DesignAction.QuarterBlockstitchBottonLeft,
                 DesignAction.QuarterBlockstitchTopLeft,
                 DesignAction.QuarterBlockstitchTopRight,
                 DesignAction.ThreeQuarterBlockstitchBottomLeft,
                 DesignAction.ThreeQuarterBlockstitchBottomRight,
                 DesignAction.ThreeQuarterBlockstitchTopLeft,
                 DesignAction.ThreeQuarterBlockstitchTopRight,
                 DesignAction.BlockstitchQuarters
                isBlockstitchAction = True
        End Select
    End Sub
    Private Sub SelectionMessage(pText As String)
        SelectionMessage(pText, 0)
    End Sub
    Private Sub SelectionMessage(pText As String, pSelType As Integer)
        LblSelectMessage.Text = pText
        If pText = String.Empty Then
            LblSelection.Text = String.Empty
        Else
            Select Case pSelType
                Case 0
                    LblSelection.Text = "From " & oInProgressAnchor.X & "," & oInProgressAnchor.Y & "  To " & oInProgressTerminus.X & "," & oInProgressTerminus.Y
                Case 1
                    LblSelection.Text = "Click to place..."
                Case 9
                    LblSelection.Text = String.Empty
            End Select
        End If
    End Sub
    Private Sub ShowPrintForm()
        OpenPrintForm(Me, oProject)
    End Sub
    Private Sub GetPaletteName()
        PnlPaletteName.Location = New Point(PicDesign.Location.X + 100, PicDesign.Location.Y + 100)
        TxtPaletteName.Text = oProject.ProjectName
        PnlPaletteName.Visible = True
    End Sub
    Private Sub SaveProjectThreadsAsPalette()
        LogUtil.ShowStatus("Saving palette", LblStatus, MyBase.Name)
        If Not String.IsNullOrEmpty(TxtPaletteName.Text.Trim) Then
            Dim _paletteId As Integer = AddNewPalette(TxtPaletteName.Text.Trim)
            SavePaletteThreads(_paletteId)
        Else
            LogUtil.ShowStatus("No palette name", LblStatus, MyBase.Name)
        End If
    End Sub
    Private Sub SavePaletteThreads(pPaletteId As Integer)
        For Each _thread As ProjectThread In oProjectThreads.Threads
            Dim _paletteThread As PaletteThread = PaletteThreadBuilder.APaletteThread.StartingWithNothing _
                .WithThreadId(_thread.ThreadId) _
                .WithPaletteId(pPaletteId) _
                .WithSymbolId(_thread.SymbolId) _
                .Build
            AddNewPaletteThread(_paletteThread)
        Next
        For Each _bead As ProjectBead In oProjectBeads.Beads
            Dim _paletteThread As PaletteThread = PaletteThreadBuilder.APaletteThread.StartingWithNothing _
                .WithThreadId(_bead.ThreadId) _
                .WithPaletteId(pPaletteId) _
                .WithSymbolId(-1) _
                .Build
            AddNewPaletteThread(_paletteThread)
        Next
    End Sub
#Region "mouse action"
    Private Sub StartSelection(pCell As Cell)
        pCell = AdjustCellOntoDesign(pCell)
        Dim x As Integer = Math.Max(pCell.Position.X, 0)
        Dim y As Integer = Math.Max(pCell.Position.Y, 0)
        x = Math.Min(x, oProjectDesign.Columns - 1)
        y = Math.Min(y, oProjectDesign.Rows - 1)
        oInProgressAnchor = pCell.Position
        oInProgressTerminus = New Point(x + 1, y + 1)
        '   oInProgressTerminus = pCell.Position
        isSelectionInProgress = True
        SelectionMessage("Selection in progress")
    End Sub
    Private Sub SelectionInProgress(e As MouseEventArgs, pCell As Cell)
        If isSelectionInProgress Then
            pCell = AdjustCellOntoDesign(pCell)
            DrawSelectionInProgress(pCell.Position)
            SelectionMessage("Selection in progress")
        End If
        'If isMoveInProgress Then
        '    DrawSelectionInProgress(pCell.Position)
        '    SelectionMessage("Relocation in progress")
        'End If
    End Sub
    Private Sub SetPasteDestination(e As MouseEventArgs, pCell As Cell)
        oPasteDestination = pCell.Position
        SelectionMessage("Select destination for " & oCurrentAction.ToString, 1)
        If oPasteDestination.X + iOriginX >= 0 AndAlso oPasteDestination.Y + iOriginY >= 0 AndAlso
            oPasteDestination.X + iOriginX < oProject.DesignWidth AndAlso oPasteDestination.Y + iOriginY < oProject.DesignHeight Then
            Dim _width As Integer = oInProgressTerminus.X - oInProgressAnchor.X - 1
            Dim _height As Integer = oInProgressTerminus.Y - oInProgressAnchor.Y - 1
            If oCurrentAction = DesignAction.Rotate Then
                _width = oInProgressTerminus.Y - oInProgressAnchor.Y - 1
                _height = oInProgressTerminus.X - oInProgressAnchor.X - 1
            End If
            If oCurrentAction = DesignAction.Paste And oCurrentSelection.Length > 1 Then
                _width = oCurrentSelection(1).X - oCurrentSelection(0).X - 1
                _height = oCurrentSelection(1).Y - oCurrentSelection(0).Y - 1
            End If
            If _width > -1 And _height > -1 Then
                If isSelectionWidthVariable Then
                    oSelectionPenWidth = Math.Max(2, iPixelsPerCell / oVariableWidthFraction)
                Else
                    oSelectionPenWidth = oSelectionPenDefaultWidth
                End If
                oSelectionPen = New Pen(oSelectionPenColour, oSelectionPenWidth)
                _fromCellLocation_x = (oPasteDestination.X + iOriginX + iXOffset - topcorner.X) * iPixelsPerCell
                _fromCellLocation_y = (oPasteDestination.Y + iOriginY + iYOffset - topcorner.Y) * iPixelsPerCell
                _toCellLocation_x = (oPasteDestination.X + iOriginX + _width + iXOffset - topcorner.X) * iPixelsPerCell
                _toCellLocation_y = (oPasteDestination.Y + iOriginY + _height + iYOffset - topcorner.Y) * iPixelsPerCell
                PicDesign.Invalidate()
            End If
        End If
    End Sub
    Private Sub EndSelectionAndContinueAction(e As MouseEventArgs, pCell As Cell)
        EndCopySelection(pCell)
        Select Case oCurrentAction
            Case DesignAction.Copy
                StartMoveSelection()
            Case DesignAction.Move
                StartMoveSelection()
            Case DesignAction.Cut
                RemoveSelectedCells()
                ClearSelection()
            Case DesignAction.Flip
                RemoveSelectedCells()
                FlipSelectedCells()
                PasteSelectedCells(oCurrentSelection(0))
                ClearSelection()
            Case DesignAction.Mirror
                RemoveSelectedCells()
                MirrorSelectedCells()
                PasteSelectedCells(oCurrentSelection(0))
                ClearSelection()
            Case DesignAction.Rotate
                StartMoveSelection()
            Case DesignAction.Zoom
                ResizeImageForSelectedCells()
                ClearSelection()
            Case DesignAction.DrawShape
                PlaceShape(oCurrentShapeType, oInProgressAnchor, oInProgressTerminus)
                ClearSelection()
        End Select
    End Sub
    Private Sub PlaceShape(oCurrentShapeType As ShapeType, oInProgressAnchor As Point, oInProgressTerminus As Point)
        Dim _tempBitmap As New Bitmap(oCurrentSelection(1).X - oCurrentSelection(0).X, oCurrentSelection(1).Y - oCurrentSelection(0).Y)
        Using _graphics As Graphics = Graphics.FromImage(_tempBitmap)
            Select Case oCurrentShapeType
                Case ShapeType.Rectangle
                    _graphics.DrawRectangle(New Pen(oCurrentThread.Thread.Colour), 0, 0, _tempBitmap.Width - 1, _tempBitmap.Height - 1)
                Case ShapeType.Ellipse
                    _graphics.DrawEllipse(New Pen(oCurrentThread.Thread.Colour), 0, 0, _tempBitmap.Width - 1, _tempBitmap.Height - 1)
                Case ShapeType.FilledRectangle
                    _graphics.FillRectangle(New SolidBrush(oCurrentThread.Thread.Colour), -1, -1, _tempBitmap.Width + 1, _tempBitmap.Height + 1)
                Case ShapeType.FilledEllipse
                    _graphics.FillEllipse(New SolidBrush(oCurrentThread.Thread.Colour), -1, -1, _tempBitmap.Width + 1, _tempBitmap.Height + 1)
            End Select
            For Each _x As Integer In Enumerable.Range(0, _tempBitmap.Width)
                For Each _y As Integer In Enumerable.Range(0, _tempBitmap.Height)
                    Dim _pixelColour As Color = _tempBitmap.GetPixel(_x, _y)
                    If _pixelColour = oCurrentThread.Thread.Colour Then
                        AddBlockStitch(oProject, oProjectDesign, New Point(oInProgressAnchor.X + _x, oInProgressAnchor.Y + _y), oCurrentThread.Thread, BlockStitchType.Full)
                    End If
                Next
            Next
        End Using
        PicDesign.Invalidate()
    End Sub
    Private Sub EndCopySelection(pCell As Cell)
        pCell = AdjustCellOntoDesign(pCell)
        oInProgressTerminus = pCell.Position
        oCurrentSelection = New Point() {oInProgressAnchor, oInProgressTerminus}
        GetSelectedCells()
        isSelectionInProgress = False
        SelectionMessage("Selection complete")
    End Sub
    Private Sub StartMoveSelection()
        isMoveInProgress = True
        SelectionMessage("Move in progress")
    End Sub
    Private Sub EndCopy(pCell As Cell)
        PasteSelectedCells(pCell.Position)
    End Sub
    Private Sub EndPaste(pCell As Cell)
        PasteSelectedCells(pCell.Position)
    End Sub
    Private Sub EndRotate(pCell As Cell)
        RotateAndPasteSelectedCells(pCell.Position)
    End Sub
    Private Sub RemoveSelectedCells()
        RemoveSelectedCells(True, True, True)
    End Sub
    Private Sub RemoveSelectedCells(pIsRemoveBlockstitch As Boolean, pIsRemoveKnots As Boolean, pIsRemoveBackstitch As Boolean)
        If pIsRemoveBlockstitch AndAlso oCurrentSelectedBlockStitch.Count > 0 Then
            For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                RemoveBlockStitchFromDesign(_bs)
            Next
        End If
        If pIsRemoveKnots AndAlso oCurrentSelectedKnot.Count > 0 Then
            For Each _knot As Knot In oCurrentSelectedKnot
                RemoveKnotFromDesign(_knot)
            Next
        End If
        If pIsRemoveBackstitch AndAlso oCurrentSelectedBackstitch.Count > 0 Then
            For Each _bkst As BackStitch In oCurrentSelectedBackstitch
                RemoveBackStitchFromDesign(_bkst)
            Next
            RedrawDesign(False)
        End If
    End Sub
    Private Function AdjustCellOntoDesign(pCell As Cell) As Cell
        Dim pos_x As Integer = Math.Max(pCell.Position.X, -iOriginX)
        Dim pos_y As Integer = Math.Max(pCell.Position.Y, -iOriginY)
        pos_x = Math.Min(pos_x, oProjectDesign.Columns - 1)
        pos_y = Math.Min(pos_y, oProjectDesign.Rows - 1)
        Dim loc_x As Integer = (pos_x + iXOffset - topcorner.X) * iPixelsPerCell
        Dim loc_y As Integer = (pos_y + iYOffset - topcorner.Y) * iPixelsPerCell
        pCell.Position = New Point(pos_x, pos_y)
        pCell.Location = New Point(loc_x, loc_y)
        Return pCell
    End Function
    Private Sub ClearSelection()
        isSelectionInProgress = False
        isMoveInProgress = False
        isBackstitchInProgress = False
        isRemoveBackstitchInProgress = False
        oInProgressAnchor = New Point(0, 0)
        oInProgressTerminus = New Point(0, 0)
        oBackstitchInProgress = Nothing
        SelectionMessage(String.Empty)
        oCurrentAction = DesignAction.none
    End Sub
    Private Sub EndSelection(pCell As Cell)
        If isSelectionInProgress Then
            oInProgressTerminus = pCell.Position
            oCurrentSelection = New Point() {oInProgressAnchor, oInProgressTerminus}
            GetSelectedCells()
            ClearSelection()
        Else
            LogUtil.Debug("Ending selection - error not in progress", MyBase.Name)
        End If
    End Sub
    Private Function GetPixelColour(e As MouseEventArgs) As Color
        Dim start_x As Integer = Math.Floor(e.X) + (topcorner.X - iXOffset) * iPixelsPerCell
        Dim start_y As Integer = Math.Floor(e.Y) + (topcorner.Y - iYOffset) * iPixelsPerCell
        Dim _colour As Color = Color.FromArgb(oProject.FabricColour)
        If oDesignBitmap IsNot Nothing Then
            If start_x > 0 AndAlso start_x < oDesignBitmap.Width AndAlso start_y > 0 AndAlso start_y < oDesignBitmap.Height Then
                _colour = oDesignBitmap.GetPixel(start_x, start_y)
            End If
        End If
        Return _colour
    End Function
    Private Sub DrawSelectionInProgress(pCell As Point)
        oInProgressTerminus = New Point(pCell.X - 1, pCell.Y - 1)
        If isSelectionWidthVariable Then
            oSelectionPenWidth = Math.Max(2, iPixelsPerCell / oVariableWidthFraction)
        Else
            oSelectionPenWidth = oSelectionPenDefaultWidth
        End If
        oSelectionPen = New Pen(oSelectionPenColour, oSelectionPenWidth)
        _fromCellLocation_x = (oInProgressAnchor.X + iOriginX + iXOffset - topcorner.X) * iPixelsPerCell
        _fromCellLocation_y = (oInProgressAnchor.Y + iOriginY + iYOffset - topcorner.Y) * iPixelsPerCell
        _toCellLocation_x = (oInProgressTerminus.X + iOriginX + iXOffset - topcorner.X) * iPixelsPerCell
        _toCellLocation_y = (oInProgressTerminus.Y + iOriginY + iYOffset - topcorner.Y) * iPixelsPerCell
        PicDesign.Invalidate()
    End Sub
    Private Sub GetSelectedCells()
        Dim _from_x As Integer = oCurrentSelection(0).X
        Dim _from_y As Integer = oCurrentSelection(0).Y
        Dim _to_x As Integer = oCurrentSelection(1).X
        Dim _to_y As Integer = oCurrentSelection(1).Y
        oCurrentSelectedBlockStitch = New List(Of BlockStitch)
        For Each _bs As BlockStitch In oProjectDesign.BlockStitches
            If _bs.BlockLocation.X >= _from_x And _bs.BlockLocation.X < _to_x _
                And _bs.BlockLocation.Y >= _from_y And _bs.BlockLocation.Y < _to_y Then
                oCurrentSelectedBlockStitch.Add(_bs)
            End If
        Next
        oCurrentSelectedKnot = New List(Of Knot)
        For Each _knot In oProjectDesign.Knots
            If _knot.BlockLocation.X >= _from_x And _knot.BlockLocation.X <= _to_x _
                And _knot.BlockLocation.Y >= _from_y And _knot.BlockLocation.Y <= _to_y Then
                oCurrentSelectedKnot.Add(_knot)
            End If
        Next
        oCurrentSelectedBackstitch = New List(Of BackStitch)
        For Each _bkst As BackStitch In oProjectDesign.BackStitches
            If _bkst.FromBlockLocation.X >= _from_x And _bkst.FromBlockLocation.X <= _to_x _
                And _bkst.FromBlockLocation.Y >= _from_y And _bkst.FromBlockLocation.Y <= _to_y Then
                oCurrentSelectedBackstitch.Add(_bkst)
            End If
        Next

    End Sub
#End Region
#Region "drawing image"
    Private Sub RedrawDesign()
        ModDesign.RedrawDesign(PicDesign, isGridOn, isCentreOn, isCentreMarksOn)
    End Sub
    Private Sub RedrawDesign(pIsReCentre As Boolean)
        ModDesign.RedrawDesign(PicDesign, pIsReCentre, isGridOn, isCentreOn, isCentreMarksOn)
    End Sub
    Private Sub ResizeImageForSelectedCells()
        isLoading = True
        Dim _selwidth As Integer = (oCurrentSelection(1).X - oCurrentSelection(0).X) * PIXELS_PER_CELL
        Dim _selheight As Integer = (oCurrentSelection(1).Y - oCurrentSelection(0).Y) * PIXELS_PER_CELL
        Dim _widthRatio As Decimal = Math.Round(PicDesign.Width / _selwidth, 2, MidpointRounding.AwayFromZero)
        Dim _heightRatio As Decimal = Math.Round(PicDesign.Height / _selheight, 2, MidpointRounding.AwayFromZero)
        ChangeMagnification(Math.Min(_widthRatio, _heightRatio))
        topcorner = oCurrentSelection(0)
        iXOffset = 0
        iYOffset = 0
        HScrollBar1.Value = HScrollBar1.Maximum - oProjectDesign.Columns + topcorner.X - 8
        VScrollBar1.Value = VScrollBar1.Maximum - oProjectDesign.Rows + topcorner.Y - 8
        iOldHScrollbarValue = HScrollBar1.Value
        iOldVScrollbarValue = VScrollBar1.Value
        RedrawDesign(False)
        isLoading = False
    End Sub
    Private Sub ToggleSingleColour()
        isSingleColour = Not isSingleColour
        BtnSingleColour.BackgroundImage = If(isSingleColour, My.Resources.BtnBkgrdDown, My.Resources.BtnBkgrd)
        MnuSingleColour.Checked = isSingleColour
        RedrawDesign(False)
    End Sub
    Private Function ShrinkPic(pFlp As FlowLayoutPanel, pThreadCt As Integer) As Integer
        Dim _panelWidth As Integer = pFlp.Width
        Dim _panelHeight As Integer = pFlp.Height
        Dim _picSize As Integer = PALETTE_COLOUR_SIZE
        Dim _maxthreadsPerColumn As Integer
        Dim _maxthreadsPerRow As Integer
        Dim _maxThreads As Integer
        Do
            _picSize -= 5
            _maxthreadsPerColumn = Math.Floor(_panelHeight / (_picSize + 6))
            _maxthreadsPerRow = Math.Floor(_panelWidth / (_picSize + 6))
            _maxThreads = _maxthreadsPerColumn * _maxthreadsPerRow
        Loop While _maxThreads < pThreadCt
        Return _picSize
    End Function
    Private Sub CalculateScrollBarMaximumValues()
        HScrollBar1.Maximum = (PicDesign.Width / iPixelsPerCell) + (oProjectDesign.Columns) + 7
        VScrollBar1.Maximum = (PicDesign.Height / iPixelsPerCell) + (oProjectDesign.Rows) + 7
    End Sub
    Private Sub SetValuesAfterHorizontalChange(_newOff_x As Integer)
        Dim _newTc_x As Integer
        If _newOff_x < 0 Then
            _newTc_x = _newOff_x * -1
        Else
            _newTc_x = 0
        End If
        If _newOff_x < 0 Then _newOff_x = 0
        iXOffset = _newOff_x
        topcorner = New Point(_newTc_x, topcorner.Y)
    End Sub
    Private Sub SetValuesAfterVerticalChange(_newOff_y As Integer)
        Dim _newTc_y As Integer
        If _newOff_y < 0 Then
            _newTc_y = _newOff_y * -1
        Else
            _newTc_y = 0
        End If
        If _newOff_y < 0 Then _newOff_y = 0
        iYOffset = _newOff_y
        topcorner = New Point(topcorner.X, _newTc_y)
    End Sub
    Private Sub ChangeMagnification(pNewValue As Decimal)
        dMagnification = pNewValue
        iPixelsPerCell = Math.Floor(PIXELS_PER_CELL * dMagnification)
        iOneToOneSize = New Size(oProjectDesign.Columns * iPixelsPerCell, oProjectDesign.Rows * iPixelsPerCell)
        CalculateScrollBarMaximumValues()
    End Sub
    Friend Sub IncreaseMagnification()
        isLoading = True
        ChangeMagnification(Math.Round(dMagnification * MAGNIFICATION_STEP, 2, MidpointRounding.AwayFromZero))
        Dim xChange As Integer = (iXOffset * (MAGNIFICATION_STEP / 2)) - topcorner.X
        Dim yChange As Integer = (iYOffset * (MAGNIFICATION_STEP / 2)) - topcorner.Y
        CalculateOffsetAfterChange(xChange, yChange)
        RedrawDesign(False)
        isLoading = False
    End Sub
    Friend Sub DecreaseMagnification()
        isLoading = True
        ChangeMagnification(Math.Round(dMagnification / MAGNIFICATION_STEP, 2, MidpointRounding.AwayFromZero))
        Dim xChange As Integer = (iXOffset / (MAGNIFICATION_STEP / 2)) - topcorner.X
        Dim yChange As Integer = (iYOffset / (MAGNIFICATION_STEP / 2)) - topcorner.Y
        CalculateOffsetAfterChange(xChange, yChange)
        RedrawDesign(False)
        isLoading = False
    End Sub
    Private Sub CalculateOffsetForCentre(pDesignBitmap As Bitmap)
        Dim x As Integer = (PicDesign.Width - pDesignBitmap.Width) / (2 * iPixelsPerCell)
        Dim y As Integer = (PicDesign.Height - pDesignBitmap.Height) / (2 * iPixelsPerCell)
        CalculateOffsetAfterChange(x, y)
    End Sub
    Private Sub CalculateOffsetAfterChange(pNewX As Integer, pNewY As Integer)
        SetValuesAfterHorizontalChange(pNewX)
        SetValuesAfterVerticalChange(pNewY)
        HScrollBar1.Value = Math.Max(Math.Min(HScrollBar1.Maximum - oProjectDesign.Columns - iXOffset + topcorner.X - 8, HScrollBar1.Maximum), HScrollBar1.Minimum)
        VScrollBar1.Value = Math.Max(Math.Min(VScrollBar1.Maximum - oProjectDesign.Rows - iYOffset + topcorner.Y - 8, VScrollBar1.Maximum), VScrollBar1.Minimum)
        iOldHScrollbarValue = HScrollBar1.Value
        iOldVScrollbarValue = VScrollBar1.Value
    End Sub
    Private Sub ToggleGrid()
        isGridOn = Not isGridOn
        My.Settings.isGridOn = isGridOn
        My.Settings.Save()
        SetIsGridOn()
        RedrawDesign(False)
    End Sub
    Private Sub ToggleCentre()
        isCentreOn = Not isCentreOn
        My.Settings.IsCentreOn = isCentreOn
        My.Settings.Save()
        SetIsCentreOn()
        RedrawDesign(False)
    End Sub
    Private Sub ToggleCentreMarks()
        isCentreMarksOn = Not isCentreMarksOn
        My.Settings.isCentreMarksOn = isCentreMarksOn
        My.Settings.Save()
        SetIsCentreMarks()
        RedrawDesign(False)
    End Sub
    Private Sub SetIsGridOn()
        MnuGridOn.Checked = isGridOn
        If isGridOn Then
            PicGrid.Image = My.Resources.gridon
        Else
            PicGrid.Image = My.Resources.gridoff
        End If
    End Sub
    Private Sub SetIsCentreOn()
        MnuCentreOn.Checked = isCentreOn
        If isCentreOn Then
            PicCentreLines.Image = My.Resources.centreon
        Else
            PicCentreLines.Image = My.Resources.centreoff
        End If
    End Sub
    Private Sub SetIsCentreMarks()
        MnuCentreMarks.Checked = isCentreMarksOn
        'If isCentreMarksOn Then
        '    PicCentreLines.Image = My.Resources.centreon
        'Else
        '    PicCentreLines.Image = My.Resources.centreoff
        'End If
    End Sub
#End Region
#Region "actions"
    Private Sub BeginText()
        oCurrentAction = DesignAction.Text
        oCurrentStitchType = DesignAction.none
        StitchButtonSelected()
        SelectionMessage("Create text")
        Dim oTextBlock As TextBlock = OpenTextForm(Me, oProject)
        If oTextBlock IsNot Nothing Then
            oCurrentSelectedBlockStitch = oTextBlock.Stitches
            oInProgressAnchor = New Point(0, 0)
            oInProgressTerminus = New Point(oTextBlock.Width, oTextBlock.Height)
            oCurrentSelection = New Point() {oInProgressAnchor, oInProgressTerminus}
            StartMoveSelection()
        Else

        End If
    End Sub
    Private Sub FlipSelectedCells()
        If oCurrentSelection.Length > 0 Then
            Dim _sum As Integer = oCurrentSelection(1).Y + oCurrentSelection(0).Y - 1
            If oCurrentSelectedBlockStitch.Count > 0 Then
                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                    _bs.BlockLocation = New Point(_bs.BlockLocation.X, _sum - _bs.BlockLocation.Y)
                Next
            End If
            If oCurrentSelectedKnot.Count > 0 Then
                For Each _knot As Knot In oCurrentSelectedKnot
                    If _knot.BlockQuarter = BlockQuarter.BottomLeft Or _knot.BlockQuarter = BlockQuarter.BottomRight Then
                        _knot.BlockLocation = New Point(_knot.BlockLocation.X, _sum - _knot.BlockLocation.Y)
                    Else
                        _knot.BlockLocation = New Point(_knot.BlockLocation.X, _sum - _knot.BlockLocation.Y + 1)
                    End If
                Next
            End If
        End If
        oCurrentAction = DesignAction.none
    End Sub
    Private Sub MirrorSelectedCells()
        If oCurrentSelection.Length > 0 Then
            Dim _sum As Integer = oCurrentSelection(1).X + oCurrentSelection(0).X - 1
            If oCurrentSelectedBlockStitch.Count > 0 Then
                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                    _bs.BlockLocation = New Point(_sum - _bs.BlockLocation.X, _bs.BlockLocation.Y)
                Next
            End If
            If oCurrentSelectedKnot.Count > 0 Then
                For Each _knot As Knot In oCurrentSelectedKnot
                    If _knot.BlockQuarter = BlockQuarter.TopLeft Or _knot.BlockQuarter = BlockQuarter.BottomLeft Then
                        _knot.BlockLocation = New Point(_sum - _knot.BlockLocation.X + 1, _knot.BlockLocation.Y)
                    Else
                        _knot.BlockLocation = New Point(_sum - _knot.BlockLocation.X, _knot.BlockLocation.Y)
                    End If
                Next
            End If
        End If
        oCurrentAction = DesignAction.none
    End Sub
    Private Sub RotateAndPasteSelectedCells(pCellPosition As Point)
        If oCurrentSelection.Length > 0 Then
            If oCurrentSelectedBlockStitch.Count > 0 Then
                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                    Dim _newY As Integer = pCellPosition.Y + _bs.BlockLocation.X - oCurrentSelection(0).X
                    Dim _newX As Integer = pCellPosition.X - _bs.BlockLocation.Y + oCurrentSelection(1).Y - 1
                    Dim _newPastePos As New Point(_newX, _newY)
                    Dim _newBs As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_bs) _
                        .WithPosition(_newPastePos) _
                        .Build
                    RemoveAndAddBlockstitch(_newBs)
                Next
            End If
            PicDesign.Invalidate()
        End If
    End Sub
    Private Sub PasteSelectedCells(pCellPosition As Point)
        If oCurrentSelection.Length > 0 Then
            Dim _xChange As Integer = pCellPosition.X - oCurrentSelection(0).X
            Dim _yChange As Integer = pCellPosition.Y - oCurrentSelection(0).Y
            If oCurrentSelectedBlockStitch.Count > 0 Then
                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                    Dim _newPastePos As New Point(_bs.BlockLocation.X + _xChange, _bs.BlockLocation.Y + _yChange)
                    Dim _newBs As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_bs) _
                        .WithPosition(_newPastePos) _
                        .Build
                    RemoveAndAddBlockstitch(_newBs)
                Next
            End If
            If oCurrentSelectedKnot.Count > 0 Then
                For Each _knot As Knot In oCurrentSelectedKnot
                    Dim _newKnot As Knot = KnotBuilder.AKnot.StartingWith(_knot).WithKnotLocation(New Point(_knot.BlockLocation.X + _xChange, _knot.BlockLocation.Y + _yChange)).Build
                    AddKnotToDesign(_newKnot)
                    DrawKnot(_newKnot)
                Next
            End If
            If oCurrentSelectedBackstitch.Count > 0 Then
                For Each _bkst As BackStitch In oCurrentSelectedBackstitch
                    Dim _newBkst As BackStitch = BackstitchBuilder.ABackStitch.StartingWith(_bkst) _
                        .WithFromBlockLocation(New Point(_bkst.FromBlockLocation.X + _xChange, _bkst.FromBlockLocation.Y + _yChange)) _
                        .WithToBlockLocation(New Point(_bkst.ToBlockLocation.X + _xChange, _bkst.ToBlockLocation.Y + _yChange)) _
                        .Build
                    AddBackStitchToDesign(_newBkst)
                    DrawBackstitch(_newBkst)
                Next
            End If
            PicDesign.Invalidate()
        End If
    End Sub
    Private Sub RemoveAndAddBlockstitch(_newBs As BlockStitch)
        RemoveExistingBlockStitch(_newBs.BlockPosition)
        AddBlockStitchToDesign(_newBs)
        Select Case _newBs.StitchType
            Case BlockStitchType.Full
                DrawFullBlockStitch(_newBs)
                'Case BlockStitchType.Half
                '    DrawHalfBlockStitch(_newBs, True)
                'Case BlockStitchType.Quarter
                '    DrawQuarterBlockStitch(_newBs)
                'Case BlockStitchType.ThreeQuarter
                '    DrawThreeQuarterBlockStitch(_newBs)
            Case Else
                DrawQuarterBlockStitches(_newBs, oDesignGraphics)
        End Select
    End Sub
#End Region
#Region "backstitch"
    Private Sub AddBackStitchToDesign(pBackstitch As BackStitch)
        Dim _backstitch As BackStitch = BackstitchBuilder.ABackStitch.StartingWith(pBackstitch).Build
        oProjectDesign.BackStitches.Add(pBackstitch)
        AddToCurrentUndoList(_backstitch, UndoAction.Add)
        isSaved = False
    End Sub
    Private Sub RemoveBackStitchFromDesign(pBackstitch As BackStitch)
        Dim _backstitch As BackStitch = BackstitchBuilder.ABackStitch.StartingWith(pBackstitch).Build
        oProjectDesign.BackStitches.Remove(pBackstitch)
        AddToCurrentUndoList(_backstitch, UndoAction.Remove)
        isSaved = False
        '      RedrawDesign()
    End Sub
    Private Function FindBackstitches(pActionPoint As Point) As List(Of BackStitch)
        Dim _list As List(Of BackStitch) = oProjectDesign.BackStitches.FindAll(Function(p) p.FromBlockLocation = pActionPoint _
                                                                                        Or p.ToBlockLocation = pActionPoint)
        Return _list
    End Function
    Private Function FindBackstitch(pActionFromPoint As Point, pActionToPoint As Point) As BackStitch
        Dim _backstitch As BackStitch = oProjectDesign.BackStitches.Find(Function(p) p.FromBlockLocation = pActionFromPoint _
                                                                                 And p.ToBlockLocation = pActionToPoint)
        Return _backstitch
    End Function
    Private Sub RemoveExistingBackStitch(pActionFromPoint As Point, pActionToPoint As Point)
        Dim _backstitch As BackStitch = FindBackstitch(pActionFromPoint, pActionToPoint)
        RemoveBackStitchFromDesign(_backstitch)
    End Sub
    Private Sub PlaceBackstitch(pCellPosition As Point, pIsHalf As Boolean, pIsThick As Boolean)
        PlaceBackstitch(pCellPosition, BlockQuarter.TopLeft, pIsHalf, pIsThick)
    End Sub
    Private Sub PlaceBackstitch(pCellPosition As Point, pQtr As BlockQuarter, pIsHalf As Boolean, pIsThick As Boolean)
        If isBackstitchInProgress Then
            EndBackstitch(pCellPosition, pQtr)
            SelectionMessage("Backstitch Complete")
        Else
            SelectionMessage("Backstitch In Progress")
            StartBackstitch(pCellPosition, pQtr, pIsHalf, pIsThick)
        End If
    End Sub
    Private Sub StartBackstitch(pCellLocation As Point, pIsHalf As Boolean, pIsThick As Boolean)
        StartBackstitch(pCellLocation, BlockQuarter.TopLeft, pIsHalf, pIsThick)
    End Sub
    Private Sub StartBackstitch(pCellLocation As Point, pQtr As BlockQuarter, pIsHalf As Boolean, pIsThick As Boolean)
        oInProgressAnchor = pCellLocation
        oInProgressTerminus = New Point(pCellLocation.X, pCellLocation.Y)
        isBackstitchInProgress = True
        SelectionMessage("Backstitch in progress")
        oBackstitchInProgress = New BackStitch(pCellLocation, pQtr, pCellLocation, pQtr, If(pIsThick, 2, 1), oCurrentThread.ThreadId, oProject.ProjectId)
    End Sub
    Private Sub EndBackstitch(pCellLocation As Point)
        EndBackstitch(pCellLocation, BlockQuarter.TopLeft)
    End Sub
    Private Sub EndBackstitch(pCellLocation As Point, pQtr As BlockQuarter)
        If isBackstitchInProgress Then
            oBackstitchInProgress.ToBlockQuarter = pQtr
            oBackstitchInProgress.ToBlockLocation = pCellLocation
            AddBackStitchToDesign(BackstitchBuilder.ABackStitch.StartingWith(oBackstitchInProgress).Build)
            DrawBackstitch(oBackstitchInProgress)
            PicDesign.Invalidate()
            oBackstitchInProgress.FromBlockQuarter = pQtr
            oBackstitchInProgress.FromBlockLocation = pCellLocation
        Else
            LogUtil.Debug("Ending backstitch - error not in progress", MyBase.Name)
        End If
    End Sub
    Private Sub EndRemoveBackStitch()
        LogUtil.LogInfo("Ending remove backstich", MyBase.Name)
        isRemoveBackstitchInProgress = False
        PicDesign.Invalidate()
    End Sub
    Private Sub DrawBackstitchInProgress(pCell As Point, pCellQtr As BlockQuarter, pIsHalfStitch As Boolean)
        DrawBackstitchInProgress(pCell, pCellQtr, pIsHalfStitch, False)
    End Sub
    Private Sub DrawBackstitchInProgress(pCell As Point, pCellQtr As BlockQuarter, pIsHalfStitch As Boolean, pIsUseSelectColour As Boolean)
        LogUtil.Debug("Drawing backstitch in progress", MyBase.Name)
        Dim _qtrLocationAdjust As Integer = If(pIsHalfStitch, iPixelsPerCell / 2, iPixelsPerCell)
        oBackstitchInProgress.ToBlockQuarter = pCellQtr
        oBackstitchInProgress.ToBlockLocation = pCell
        SetStitchPenWidth(RbDouble.Checked, iPixelsPerCell)
        _fromCellLocation_x = (oBackstitchInProgress.FromBlockLocation.X + iOriginX + iXOffset - topcorner.X) * iPixelsPerCell
        _fromCellLocation_y = (oBackstitchInProgress.FromBlockLocation.Y + iOriginY + iYOffset - topcorner.Y) * iPixelsPerCell
        _toCellLocation_x = (oBackstitchInProgress.ToBlockLocation.X + iOriginX + iXOffset - topcorner.X) * iPixelsPerCell
        _toCellLocation_y = (oBackstitchInProgress.ToBlockLocation.Y + iOriginX + iYOffset - topcorner.Y) * iPixelsPerCell
        Dim _bsPenColour As Color = If(pIsUseSelectColour, Color.Black, oBackstitchInProgress.ProjThread.Thread.Colour)
        _backstitchPen = New Pen(oBackstitchInProgress.ProjThread.Thread.Colour, oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Select Case oBackstitchInProgress.FromBlockQuarter
            Case BlockQuarter.TopRight
                _fromCellLocation_x += _qtrLocationAdjust
            Case BlockQuarter.BottomLeft
                _fromCellLocation_y += _qtrLocationAdjust
            Case BlockQuarter.BottomRight
                _fromCellLocation_x += _qtrLocationAdjust
                _fromCellLocation_y += _qtrLocationAdjust
        End Select
        Select Case oBackstitchInProgress.ToBlockQuarter
            Case BlockQuarter.TopRight
                _toCellLocation_x += _qtrLocationAdjust
            Case BlockQuarter.BottomLeft
                _toCellLocation_y += _qtrLocationAdjust
            Case BlockQuarter.BottomRight
                _toCellLocation_x += _qtrLocationAdjust
                _toCellLocation_y += _qtrLocationAdjust
        End Select

        PicDesign.Invalidate()
    End Sub
    Private Sub RemoveBackstitch()
        StopTimer()
        RemoveExistingBackStitch(oRemoveBackstitch.FromBlockLocation,
                               oRemoveBackstitch.ToBlockLocation)
        oSelectedBackstitchIndex = -1
        ClearSelection()
        RedrawDesign(False)
    End Sub
    Private Sub NextBackstitchToRemove()
        LogUtil.LogInfo("Stopping timer", MyBase.Name)
        StopTimer()
        oSelectedBackstitchIndex += 1
        If oSelectedBackstitchIndex < 0 OrElse oSelectedBackstitchIndex >= oNearestBackstitches.Count Then
            LogUtil.LogInfo("No more threads", MyBase.Name)
            EndRemoveBackStitch()
            oSelectedBackstitchIndex = -1
        Else
            LogUtil.LogInfo("Next backstitch", MyBase.Name)
            oRemoveBackstitch = BackstitchBuilder.ABackStitch.StartingWith(oNearestBackstitches(oSelectedBackstitchIndex)).Build
            StartTimer()
        End If
    End Sub
    Private Sub BeginBackstitchRemove(pCell As Cell)
        LogUtil.LogInfo("Start remove backstitch", MyBase.Name)
        oNearestBackstitches = FindBackstitches(pCell.Position)
        If oNearestBackstitches.Count > 0 Then
            oSelectedBackstitchIndex = 0
            oRemoveBackstitch = BackstitchBuilder.ABackStitch.StartingWith(oNearestBackstitches(oSelectedBackstitchIndex)).Build
            StartTimer()
            isRemoveBackstitchInProgress = True
        Else
            ClearSelection()
        End If
    End Sub
    Private Sub CancelBackstitch()
        ClearSelection()
    End Sub
#End Region
#Region "blockstitch"
    Private Sub AddBlockStitch(pProject As Project, pDesign As ProjectDesign, pCellPosition As Point, pThread As Thread, pBlockStitchType As BlockStitchType)
        Dim _strands As Integer = If(RbDouble.Checked, 2, 1)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
        .WithStitchType(pBlockStitchType) _
        .WithProjectId(pProject.ProjectId) _
        .WithThreadId(pThread.ThreadId) _
        .WithStrandCount(_strands) _
        .WithBlockLocation(pCellPosition).Build
        Dim _quarters As New List(Of BlockStitchQuarter) From {
            New BlockStitchQuarter(BlockQuarter.TopLeft, _strands, pThread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.TopRight, _strands, pThread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomLeft, _strands, pThread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomRight, _strands, pThread.ThreadId)
        }
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch) _
            .WithQuarters(_quarters).Build
        RemoveExistingBlockStitch(pCellPosition)
        AddBlockStitchToDesign(_blockstitch)
        DrawFullBlockStitch(_blockstitch)
    End Sub
    Private Sub AddBlockStitchToDesign(pBlockstitch As BlockStitch)
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(pBlockstitch).Build
        oProjectDesign.BlockStitches.Add(pBlockstitch)
        AddToCurrentUndoList(_blockstitch, UndoAction.Add)
        isSaved = False
    End Sub
    Private Sub RemoveBlockStitchFromDesign(pBlockstitch As BlockStitch)
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(pBlockstitch).Build
        oProjectDesign.BlockStitches.Remove(pBlockstitch)
        RemoveBlockStitchFromImage(pBlockstitch)
        AddToCurrentUndoList(_blockstitch, UndoAction.Remove)
        isSaved = False
    End Sub
    Private Sub RemoveBlockStitchFromImage(pBlockStitch As BlockStitch)
        RemoveBlockStitchFromImage(pBlockStitch, oDesignGraphics)
    End Sub
    Private Sub RemoveBlockStitchFromImage(pBlockStitch As BlockStitch, pDesignGraphics As Graphics)
        Dim pX As Integer = (pBlockStitch.BlockPosition.X + iOriginX) * iPixelsPerCell
        Dim pY As Integer = (pBlockStitch.BlockPosition.Y + iOriginY) * iPixelsPerCell
        Dim _halfWidth As Integer = Math.Ceiling(iPixelsPerCell / 2)
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + _halfWidth, pY)
        Dim _bl As New Point(pX, pY + _halfWidth)
        Dim _br As New Point(pX + _halfWidth, pY + _halfWidth)
        Dim _size As New Size(_halfWidth, _halfWidth)
        For Each _qtr As BlockStitchQuarter In pBlockStitch.Quarters
            Select Case _qtr.BlockQuarter
                Case BlockQuarter.TopLeft
                    pDesignGraphics.FillRectangle(New SolidBrush(oFabricColour), New Rectangle(_tl, _size))
                Case BlockQuarter.TopRight
                    pDesignGraphics.FillRectangle(New SolidBrush(oFabricColour), New Rectangle(_tr, _size))
                Case BlockQuarter.BottomLeft
                    pDesignGraphics.FillRectangle(New SolidBrush(oFabricColour), New Rectangle(_bl, _size))
                Case BlockQuarter.BottomRight
                    pDesignGraphics.FillRectangle(New SolidBrush(oFabricColour), New Rectangle(_br, _size))
            End Select
        Next
    End Sub
    Private Sub AddThreeQuarterStitch(pcell As Cell, pQtr As BlockQuarter, pIsDouble As Boolean)
        Dim _strands As Integer = If(pIsDouble, 2, 1)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing.WithStitchType(BlockStitchType.ThreeQuarter).WithProjectId(oProject.ProjectId).WithThreadId(oCurrentThread.ThreadId).WithStrandCount(2).WithBlockLocation(pcell.Position).WithQuarter(pQtr).Build
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch).Build

        Dim _blockStitchQtrList As New List(Of BlockStitchQuarter)

        Select Case pQtr
            Case BlockQuarter.TopLeft
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopLeft, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopRight, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomLeft, _strands, oCurrentThread.ThreadId))
            Case BlockQuarter.TopRight
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopLeft, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopRight, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomRight, _strands, oCurrentThread.ThreadId))
            Case BlockQuarter.BottomLeft
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopLeft, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomRight, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomLeft, _strands, oCurrentThread.ThreadId))
            Case BlockQuarter.BottomRight
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomRight, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopRight, _strands, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomLeft, _strands, oCurrentThread.ThreadId))
        End Select
        _blockstitch.Quarters = _blockStitchQtrList
        AddBlockStitchToDesign(_blockstitch)
        DrawQuarterBlockStitches(_blockstitch, oDesignGraphics)

    End Sub
    Private Sub AddHalfBlockStitch(pCell As Cell, isBack As Boolean, pIsDouble As Boolean)
        Dim _strands As Integer = If(pIsDouble, 2, 1)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
            .WithStitchType(BlockStitchType.Half) _
            .WithProjectId(oProject.ProjectId) _
            .WithThreadId(oCurrentThread.ThreadId) _
            .WithStrandCount(_strands) _
            .WithBlockLocation(pCell.Position).Build
        Dim _quarters As New List(Of BlockStitchQuarter)
        If isBack Then
            _quarters.Add(New BlockStitchQuarter(BlockQuarter.TopLeft, _strands, oCurrentThread.ThreadId))
            _quarters.Add(New BlockStitchQuarter(BlockQuarter.BottomRight, _strands, oCurrentThread.ThreadId))
        Else
            _quarters.Add(New BlockStitchQuarter(BlockQuarter.TopRight, _strands, oCurrentThread.ThreadId))
            _quarters.Add(New BlockStitchQuarter(BlockQuarter.BottomLeft, _strands, oCurrentThread.ThreadId))
        End If
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch) _
            .WithQuarters(_quarters).Build
        RemoveExistingBlockStitch(pCell.Position)
        AddBlockStitchToDesign(_blockstitch)
        DrawQuarterBlockStitches(_blockstitch, oDesignGraphics)
    End Sub
    Private Sub AddFullBlockStitch(pCell As Cell, pIsDouble As Boolean)
        Dim _strands As Integer = If(pIsDouble, 2, 1)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
        .WithStitchType(BlockStitchType.Full) _
        .WithProjectId(oProject.ProjectId) _
        .WithThreadId(oCurrentThread.ThreadId) _
        .WithStrandCount(_strands) _
        .WithBlockLocation(pCell.Position).Build
        Dim _quarters As New List(Of BlockStitchQuarter) From {
            New BlockStitchQuarter(BlockQuarter.TopLeft, _strands, oCurrentThread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.TopRight, _strands, oCurrentThread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomLeft, _strands, oCurrentThread.ThreadId),
            New BlockStitchQuarter(BlockQuarter.BottomRight, _strands, oCurrentThread.ThreadId)
        }
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch) _
            .WithQuarters(_quarters).Build
        RemoveExistingBlockStitch(pCell.Position)
        AddBlockStitchToDesign(_blockstitch)
        DrawFullBlockStitch(_blockstitch)
    End Sub
    Private Sub AddQuarterBlockstitch(pCell As Cell, pQtr As BlockQuarter, pIsDouble As Boolean)
        Dim _strands As Integer = If(pIsDouble, 2, 1)

        Dim _existingBlockstitch As BlockStitch = FindBlockstitch(pCell.Position)
        Dim _blockStitchQtrList As New List(Of BlockStitchQuarter)
        If _existingBlockstitch IsNot Nothing Then
            For Each _bsq As BlockStitchQuarter In _existingBlockstitch.Quarters
                If Not _bsq.BlockQuarter = pQtr Then
                    _blockStitchQtrList.Add(_bsq)
                End If
            Next
        Else
            Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
                .WithStitchType(BlockStitchType.Quarter) _
                .WithProjectId(oProject.ProjectId) _
                .WithThreadId(oCurrentThread.ThreadId) _
                .WithStrandCount(_strands) _
                .WithBlockLocation(pCell.Position).Build
            _existingBlockstitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch).Build
            oProjectDesign.BlockStitches.Add(_existingBlockstitch)
            AddToCurrentUndoList(_existingBlockstitch, UndoAction.Add)
        End If
        _blockStitchQtrList.Add(New BlockStitchQuarter(pQtr, _strands, oCurrentThread.ThreadId))
        _existingBlockstitch.Quarters = _blockStitchQtrList
        _existingBlockstitch.StitchType = BlockStitchType.Mixed
        DrawQuarterBlockStitches(_existingBlockstitch, oDesignGraphics)
        isSaved = False
    End Sub
    Private Function FindBlockstitch(pCellPosition As Point) As BlockStitch
        Dim _blockstitch As BlockStitch = CType(oProjectDesign.BlockStitches.Find(Function(p) p.BlockPosition = pCellPosition), BlockStitch)
        Return _blockstitch
    End Function
    Private Function RemoveExistingBlockStitch(pCellPosition As Point) As BlockStitch
        LogUtil.Debug("Removing blockstitch", MyBase.Name)
        Dim _existingBlockstitch As BlockStitch = FindBlockstitch(pCellPosition)
        If _existingBlockstitch IsNot Nothing Then
            RemoveBlockStitchFromDesign(_existingBlockstitch)
        End If
        Return _existingBlockstitch
    End Function
#End Region
#Region "knots"
    Private Sub AddKnot(pCell As Cell, pIsBead As Boolean, pIsDouble As Boolean)
        Dim _strands As Integer = If(pIsDouble, 2, 1)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
            .WithStitchType(BlockStitchType.none) _
            .WithProjectId(oProject.ProjectId) _
            .WithThreadId(If(pIsBead, oCurrentBead.BeadId, oCurrentThread.ThreadId)) _
            .WithStrandCount(_strands) _
            .WithQuarter(pCell.KnotQtr).Build
        Dim _bead As Knot = KnotBuilder.AKnot.StartingWith(_stitch) _
            .WithKnotLocation(pCell.KnotCellPos) _
            .WithIsBead(pIsBead) _
            .Build
        RemoveExistingKnot(pCell)
        AddKnotToDesign(_bead)
        DrawKnot(_bead)
    End Sub
    Private Sub AddKnotToDesign(pKnot As Knot)
        Dim _knot As Knot = KnotBuilder.AKnot.StartingWith(pKnot).Build
        oProjectDesign.Knots.Add(pKnot)
        AddToCurrentUndoList(_knot, UndoAction.Add)
    End Sub
    Private Function RemoveExistingKnot(pCell As Cell) As Knot
        LogUtil.Debug("Removing knot/bead", MyBase.Name)
        Dim _existingKnot As Knot = FindKnot(pCell)
        If _existingKnot IsNot Nothing Then
            RemoveKnotFromDesign(_existingKnot)
        End If
        Return _existingKnot
    End Function
    Private Sub RemoveKnotFromDesign(pKnot As Knot)
        Dim _knot As Knot = KnotBuilder.AKnot.StartingWith(pKnot).Build
        oProjectDesign.Knots.Remove(pKnot)
        RemoveKnotFromImage(pKnot)
        AddToCurrentUndoList(_knot, UndoAction.Remove)
        isSaved = False
    End Sub
    Private Function FindKnot(pCell As Cell) As Knot
        Return CType(oProjectDesign.Knots.Find(Function(p) p.BlockPosition = pCell.KnotCellPos AndAlso p.BlockQuarter = pCell.KnotQtr), Knot)
    End Function
    Private Function FindKnot(pKnot As Knot) As Knot
        Return CType(oProjectDesign.Knots.Find(Function(p) p.BlockPosition = pKnot.BlockPosition AndAlso p.BlockQuarter = pKnot.BlockQuarter), Knot)
    End Function
    Private Sub RemoveKnotFromImage(pKnot As Knot)
        DrawKnot(pKnot, True)
    End Sub
#End Region
#Region "timer"
    Private Sub InitialiseTimer()
        ' Create a timer with a fifth second interval.
        aTimer = New System.Timers.Timer(200)
        StopTimer()
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
        aTimer.AutoReset = True
    End Sub
    Private Sub StartTimer()
        aTimer.Enabled = True
    End Sub
    Private Sub StopTimer()
        aTimer.Enabled = False
    End Sub
    Private Sub OnTimedEvent()
        isThreadOn = Not isThreadOn
        _fromCellLocation_x = (oRemoveBackstitch.FromBlockLocation.X + iOriginX + iXOffset - topcorner.X) * iPixelsPerCell
        _fromCellLocation_y = (oRemoveBackstitch.FromBlockLocation.Y + iOriginY + iYOffset - topcorner.Y) * iPixelsPerCell
        _toCellLocation_x = (oRemoveBackstitch.ToBlockLocation.X + iOriginX + iXOffset - topcorner.X) * iPixelsPerCell
        _toCellLocation_y = (oRemoveBackstitch.ToBlockLocation.Y + iOriginY + iYOffset - topcorner.Y) * iPixelsPerCell
        Dim _adjust As Integer = Math.Floor(iPixelsPerCell / 2)
        Select Case oRemoveBackstitch.FromBlockQuarter
            Case BlockQuarter.TopRight
                _fromCellLocation_x += _adjust
            Case BlockQuarter.BottomLeft
                _fromCellLocation_y += _adjust
            Case BlockQuarter.BottomRight
                _fromCellLocation_x += _adjust
                _fromCellLocation_y += _adjust
        End Select
        Select Case oRemoveBackstitch.ToBlockQuarter
            Case BlockQuarter.TopRight
                _toCellLocation_x += _adjust
            Case BlockQuarter.BottomLeft
                _toCellLocation_y += _adjust
            Case BlockQuarter.BottomRight
                _toCellLocation_x += _adjust
                _toCellLocation_y += _adjust
        End Select
        SetStitchPenWidth(oRemoveBackstitch.Strands, iPixelsPerCell)
        _backstitchPen = New Pen(Color.White, oStitchPenWidth)
        If isThreadOn Then
            _backstitchPen = New Pen(oRemoveBackstitch.ProjThread.Thread.Colour, oStitchPenWidth * oRemoveBackstitch.Strands)
        End If
        PicDesign.Invalidate()
    End Sub
#End Region
#Region "floodfill"
    Private Function FindColourFromCellPosition(pCellPosition As Point) As Color
        Dim _blockStitch As BlockStitch = FindBlockstitch(pCellPosition)
        If _blockStitch IsNot Nothing Then
            Return _blockStitch.ProjThread.Thread.Colour
        Else
            Return Color.Transparent
        End If
    End Function
    Private Sub DepthFirstSearch(pCellPosition As Point, pOldColour As Color, pNewThread As Thread, pBlockStitchType As BlockStitchType)
        Dim _cellColour As Color = FindColourFromCellPosition(pCellPosition)
        If pCellPosition.X < 0 OrElse pCellPosition.Y < 0 _
            OrElse pCellPosition.X >= oProject.DesignWidth _
            OrElse pCellPosition.Y >= oProject.DesignHeight _
            OrElse _cellColour <> pOldColour Then
            Return
        End If
        If pNewThread Is Nothing Then
            RemoveExistingBlockStitch(pCellPosition)
        Else
            AddBlockStitch(oProject, oProjectDesign, pCellPosition, pNewThread, pBlockStitchType)
        End If
        DepthFirstSearch(New Point(pCellPosition.X - 1, pCellPosition.Y), pOldColour, pNewThread, pBlockStitchType) ' Left
        DepthFirstSearch(New Point(pCellPosition.X + 1, pCellPosition.Y), pOldColour, pNewThread, pBlockStitchType) ' Right
        DepthFirstSearch(New Point(pCellPosition.X, pCellPosition.Y - 1), pOldColour, pNewThread, pBlockStitchType) ' Up
        DepthFirstSearch(New Point(pCellPosition.X, pCellPosition.Y + 1), pOldColour, pNewThread, pBlockStitchType) ' Down
    End Sub
    Private Sub FloodFill(pCell As Cell, pThread As Thread, pBlockStitchType As BlockStitchType)
        Dim _existingColour As Color = FindColourFromCellPosition(pCell.Position)
        If pThread Is Nothing Then
            If _existingColour <> Color.Transparent Then
                DepthFirstSearch(pCell.Position, _existingColour, pThread, pBlockStitchType)
            End If
        Else
            If _existingColour <> pThread.Colour Then
                DepthFirstSearch(pCell.Position, _existingColour, pThread, pBlockStitchType)
            End If
        End If
    End Sub
    Private Sub BtnFill_Click(sender As Object, e As EventArgs) Handles BtnFill.Click
        BeginFloodFill()
    End Sub
#End Region
#Region "Undo/Redo"
    Private Sub UndoLastAction()
        If oUndoList.Count > 0 Then
            Dim _stitchActions As List(Of StitchAction) = oUndoList.Last
            Dim _redoList As New List(Of StitchAction)
            Do While _stitchActions.Count > 0
                Dim _stitchAction As StitchAction = _stitchActions.Last
                _redoList.Add(New StitchAction(_stitchAction.Stitch, _stitchAction.DoneAction, _stitchAction.NewThread))
                Select Case _stitchAction.DoneAction
                    Case UndoAction.Add
                        If TypeOf _stitchAction.Stitch Is Knot Then
                            Dim _knot As Knot = CType(_stitchAction.Stitch, Knot)
                            oProjectDesign.Knots.Remove(FindKnot(_knot))
                        ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
                            oProjectDesign.BlockStitches.Remove(FindBlockstitch(_stitchAction.Stitch.BlockPosition))
                        ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
                            Dim _stitch As BackStitch = CType(_stitchAction.Stitch, BackStitch)
                            oProjectDesign.BackStitches.Remove(FindBackstitch(_stitch.FromBlockPosition, _stitch.ToBlockPosition))
                        End If
                    Case UndoAction.Remove
                        If TypeOf _stitchAction.Stitch Is Knot Then
                            oProjectDesign.Knots.Add(_stitchAction.Stitch)
                        ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
                            oProjectDesign.BlockStitches.Add(_stitchAction.Stitch)
                        ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
                            oProjectDesign.BackStitches.Add(_stitchAction.Stitch)
                        End If
                    Case UndoAction.ChangeThread
                        If TypeOf _stitchAction.Stitch Is Knot Then
                            Dim _knot As Knot = CType(_stitchAction.Stitch, Knot)
                            Dim _existingknot As Knot = FindKnot(_knot)
                            If _existingknot IsNot Nothing Then
                                _existingknot.ProjThread = _knot.ProjThread
                            End If
                        ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
                            Dim _blockStitch As BlockStitch = CType(_stitchAction.Stitch, BlockStitch)
                            Dim _existingBlockStitch As BlockStitch = FindBlockstitch(_blockStitch.BlockPosition)
                            If _existingBlockStitch IsNot Nothing Then
                                _existingBlockStitch.ProjThread = _blockStitch.ProjThread
                            End If
                        ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
                            Dim _backStitch As BackStitch = CType(_stitchAction.Stitch, BackStitch)
                            Dim _existingBackStitch As BackStitch = FindBackstitch(_backStitch.FromBlockLocation, _backStitch.ToBlockLocation)
                            If _existingBackStitch IsNot Nothing Then
                                _existingBackStitch.ProjThread = _backStitch.ProjThread
                            End If
                        End If
                End Select
                _stitchActions.Remove(_stitchAction)
            Loop
            isSaved = False
            If _redoList.Count > 0 Then
                oRedoList.Add(_redoList)
            End If
            oUndoList.Remove(_stitchActions)
            If oUndoList.Count = 0 Then
                BtnUndo.Enabled = False
            End If
            BtnRedo.Enabled = True
            RedrawDesign(False)
        End If
    End Sub
    Private Sub RedoLastUndo()
        If oRedoList.Count > 0 Then
            Dim _stitchActions As List(Of StitchAction) = oRedoList.Last
            Dim _undoList As New List(Of StitchAction)
            Do While _stitchActions.Count > 0
                Dim _stitchAction As StitchAction = _stitchActions.Last
                _undoList.Add(New StitchAction(_stitchAction.Stitch, _stitchAction.DoneAction, _stitchAction.NewThread))
                Select Case _stitchAction.DoneAction
                    Case UndoAction.Add
                        If TypeOf _stitchAction.Stitch Is Knot Then
                            oProjectDesign.Knots.Add(_stitchAction.Stitch)
                        ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
                            oProjectDesign.BlockStitches.Add(_stitchAction.Stitch)
                        ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
                            oProjectDesign.BackStitches.Add(_stitchAction.Stitch)
                        End If
                    Case UndoAction.Remove
                        If TypeOf _stitchAction.Stitch Is Knot Then
                            oProjectDesign.Knots.Remove(_stitchAction.Stitch)
                        ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
                            oProjectDesign.BlockStitches.Remove(_stitchAction.Stitch)
                        ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
                            oProjectDesign.BackStitches.Remove(_stitchAction.Stitch)
                        End If
                    Case UndoAction.ChangeThread
                        If TypeOf _stitchAction.Stitch Is Knot Then
                            Dim _knot As Knot = CType(_stitchAction.Stitch, Knot)
                            Dim _existingknot As Knot = FindKnot(_knot)
                            If _existingknot IsNot Nothing Then
                                _existingknot.ProjThread = _stitchAction.NewThread
                            End If
                        ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
                            Dim _blockStitch As BlockStitch = CType(_stitchAction.Stitch, BlockStitch)
                            Dim _existingBlockStitch As BlockStitch = FindBlockstitch(_blockStitch.BlockPosition)
                            If _existingBlockStitch IsNot Nothing Then
                                _existingBlockStitch.ProjThread = _stitchAction.NewThread
                            End If
                        ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
                            Dim _backStitch As BackStitch = CType(_stitchAction.Stitch, BackStitch)
                            Dim _existingBackStitch As BackStitch = FindBackstitch(_backStitch.FromBlockLocation, _backStitch.ToBlockLocation)
                            If _existingBackStitch IsNot Nothing Then
                                _existingBackStitch.ProjThread = _stitchAction.NewThread
                            End If
                        End If
                End Select
                _stitchActions.Remove(_stitchAction)
            Loop
            isSaved = False
            If _undoList.Count > 0 Then
                oUndoList.Add(_undoList)
            End If
            oRedoList.Remove(_stitchActions)
            If oRedoList.Count = 0 Then
                BtnRedo.Enabled = False
            End If
            BtnUndo.Enabled = True
            RedrawDesign(False)
        End If
    End Sub
    Private Sub AddToCurrentUndoList(pStitch As Stitch, pAction As UndoAction)
        Dim _action As New StitchAction(pStitch, pAction, Nothing)
        oCurrentUndoList.Add(_action)
    End Sub
    Private Sub AddToCurrentUndoList(pStitch As Stitch, pAction As UndoAction, pNewThread As ProjectThread)
        oCurrentUndoList.Add(New StitchAction(pStitch, pAction, pNewThread))
    End Sub
    Private Sub AddActionsToUndoList(pCurrentList As List(Of StitchAction))
        Dim _newList As New List(Of StitchAction)
        For Each _action In pCurrentList
            _newList.Add(New StitchAction(_action.Stitch, _action.DoneAction, _action.NewThread))
        Next
        oUndoList.Add(_newList)
    End Sub
#End Region
#End Region
End Class