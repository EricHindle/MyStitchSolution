' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmGraphicsTest
#Region "classes"
    Private Class StitchAction
        Private _subjectStitch As Stitch
        Private _doneAction As UndoAction
        Public Property DoneAction() As UndoAction
            Get
                Return _doneAction
            End Get
            Set(ByVal value As UndoAction)
                _doneAction = value
            End Set
        End Property
        Public Property Stitch() As Stitch
            Get
                Return _subjectStitch
            End Get
            Set(ByVal value As Stitch)
                _subjectStitch = value
            End Set
        End Property
        Public Sub New(pStitch As Stitch, pAction As UndoAction)
            _subjectStitch = pStitch
            _doneAction = pAction
        End Sub
    End Class
#End Region
#Region "constants"
    Private Const PIXELS_PER_CELL As Integer = 8
    'Private Const MAG_STEP As Decimal = 1.3
    'Private Const A4_WIDTH_PIXELS As Integer = 3508
    'Private Const A4_HEIGHT_PIXELS As Integer = 2480
    '' image dots per inch
    'Private Const DPI As Single = 300.0F
    '' font points per inch
    'Private Const PPI As Integer = 72
    'Private LINE_PEN As New Pen(Brushes.Black, 1)
    Private oStitchPenWidth As Single = 2
    'Private oSelectionPenWidth As Single = 2
    Private _blackThread As New Thread(0, "BLACK", "Black", Color.Black, 0)
    Private PALETTE_COLOUR_SIZE As Integer = 55


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
    Private oProject As Project
    Private oDesignBitmap As Bitmap
    Private oDesignGraphics As Graphics
    'Private oDesignGraphicsOverlay As Graphics
    Private oProjectDesign As ProjectDesign

    Private oUndoList As New List(Of StitchAction)
    Private oRedoList As New List(Of StitchAction)

    Private isLoading As Boolean
    Private isComponentInitialised As Boolean
    'Private leftmargin As Integer
    'Private topmargin As Integer
    'Private myPrintDoc As New Printing.PrintDocument

    Private dMagnification As Decimal

    Private iOneToOneSize As Size

    Private oCurrentAction As DesignAction = DesignAction.none
    Private oCurrentStitchType As DesignAction = DesignAction.none

    'Private oCurrentSelection(-1) As Point
    'Private oCurrentSelectedBlockStitch As New List(Of BlockStitch)
    'Private oCurrentSelectedKnot As New List(Of Knot)
    'Private oCurrentSelectedBackstitch As New List(Of BackStitch)

    Private isBlockstitchAction As Boolean
    Private isBackstitchAction As Boolean
    Private isKnotAction As Boolean
    Private oCurrentThread As ProjectThread
    Private oProjectThreads As New List(Of ProjectThread)

    Private iOldHScrollbarValue As Integer = 0
    Private iOldVScrollbarValue As Integer = 0

    Dim _grid1width As Integer = 1
    Dim _grid1Brush As Brush = Brushes.LightGray
    Dim _grid1Pen = New Pen(_grid1Brush, _grid1width)
    Dim _grid5width As Integer = 1
    Dim _grid5Brush As Brush = Brushes.DarkGray
    Dim _grid5Pen = New Pen(_grid5Brush, _grid5width)
    Dim _grid10width As Integer = 1
    Dim _grid10Brush As Brush = Brushes.Black
    Dim _grid10Pen = New Pen(_grid10Brush, _grid10width)

    'Private isSelectionInProgress As Boolean
    'Private isMoveInProgress As Boolean
    'Private isBackstitchInProgress As Boolean
    'Private isRemoveBackstitchInProgress As Boolean

    'Private oInProgressAnchor As New Point(0, 0)
    'Private oInProgressTerminus As New Point(0, 0)
    'Private oPasteDestination As New Point(0, 0)

    'Private oBackstitchInProgress As New BackStitch
    'Private oRemoveBackstitch As New BackStitch
    'Private oNearestBackstitches As New List(Of BackStitch)
    'Private oSelectedBackstitchIndex As Integer

    Dim _backstitchPen As New Pen(Brushes.Black)
    'Dim _selPen As New Pen(Brushes.Black)
    'Dim _fromCellLocation_x As Integer
    'Dim _fromCellLocation_y As Integer
    'Dim _toCellLocation_x As Integer
    'Dim _toCellLocation_y As Integer

    'Private aTimer As System.Timers.Timer
    'Private isThreadOn As Boolean
#End Region
#Region "enum"
    Private Enum UndoAction
        Add
        Remove
    End Enum
    Private Enum DesignAction
        FullBlockstitch
        HalfBlockstitchForward
        HalfBlockstitchBack
        QuarterBlockstitchTopLeft
        QuarterBlockstitchTopRight
        QuarterBlockstitchBottomRight
        QuarterBlockstitchBottonLeft
        ThreeQuarterBlockstitchTopLeft
        ThreeQuarterBlockstitchTopRight
        ThreeQuarterBlockstitchBottomRight
        ThreeQuarterBlockstitchBottomLeft
        BlockstitchQuarters
        BackStitchFullThin
        BackstitchHalfThin
        BackstitchFullThick
        BackStitchHalfThick
        Knot
        Bead
        Copy
        Cut
        Move
        Paste
        Flip
        Mirror
        none
    End Enum
#End Region
#Region "form handlers"
    Private Sub FrmStitchDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening design", MyBase.Name)
        GetFormPos(Me, My.Settings.DesignFormPos)
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _backstitchPen.Dispose()
        _grid1Pen.Dispose()
        _grid5Pen.Dispose()
        _grid10Pen.Dispose()
        My.Settings.DesignFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    'Private Sub FrmStitchDesign_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    '    DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    'End Sub
    'Private Sub PicGrid_Click(sender As Object, e As EventArgs) Handles PicGrid.Click
    '    ToggleGrid()
    'End Sub
    Private Sub Palette_Click(sender As Object, e As EventArgs)
        For Each _control As Control In ThreadLayoutPanel.Controls
            Dim _colourBox As PictureBox = TryCast(_control, PictureBox)
            If _colourBox IsNot Nothing Then
                _colourBox.BorderStyle = BorderStyle.None
                _colourBox.BackgroundImage = Nothing
            End If
        Next
        Dim _picBox As PictureBox = CType(sender, PictureBox)
        SelectPaletteColour(_picBox)
    End Sub

    Private Sub SelectPaletteColour(pPicBox As PictureBox)
        pPicBox.BorderStyle = BorderStyle.Fixed3D
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Find(Function(p) p.Thread.ThreadId = CInt(pPicBox.Name)), ProjectThread)
        Dim _thread As Thread = _projectThread.Thread
        oCurrentThread = _projectThread
        PnlSelectedColor.BackColor = _thread.Colour
        LblCurrentColour.Text = _thread.ColourName & " : DMC " & CStr(_thread.ThreadNo)
    End Sub

    'Private Sub MouseDownLeft(e As MouseEventArgs, pCell As Cell)
    '    If isSelectionInProgress Then

    '    ElseIf isMoveInProgress Then
    '        MouseDownLeftMoving(e, pCell)
    '    Else
    '        MouseDownLeftNotSelecting(e, pCell)
    '    End If
    'End Sub
    'Private Sub MouseDownRight(e As MouseEventArgs, pCell As Cell)
    '    If isSelectionInProgress Or isMoveInProgress Then
    '        MouseDownRightSelecting()
    '    Else
    '    End If
    'End Sub
    'Private Sub MouseMoveLeft(e As MouseEventArgs, pCell As Cell)
    '    If isSelectionInProgress Then
    '        oInProgressTerminus = pCell.Position
    '        DrawSelectionInProgress(pCell.Position)
    '    End If
    '    If isMoveInProgress Then
    '        DrawSelectionInProgress(pCell.Position)
    '    End If
    'End Sub
    'Private Sub MouseMoveNone(e As MouseEventArgs, pCell As Cell)
    '    oPasteDestination = pCell.Position
    '    If oCurrentStitchType = DesignAction.BackStitchFullThin Then Exit Sub
    '    If oPasteDestination.X >= 0 AndAlso oPasteDestination.Y >= 0 AndAlso
    '        oPasteDestination.X < oProject.DesignWidth AndAlso oPasteDestination.Y < oProject.DesignHeight Then
    '        Dim _width As Integer = oInProgressTerminus.X - oInProgressAnchor.X - 1
    '        Dim _height As Integer = oInProgressTerminus.Y - oInProgressAnchor.Y - 1
    '        If oCurrentAction = DesignAction.Paste And oCurrentSelection.Length > 1 Then
    '            _width = oCurrentSelection(1).X - oCurrentSelection(0).X - 1
    '            _height = oCurrentSelection(1).Y - oCurrentSelection(0).Y - 1
    '        End If
    '        If _width > -1 And _height > -1 Then
    '            oSelectionPenWidth = Math.Max(2, iPixelsPerCell / 16)
    '            _fromCellLocation_x = (oPasteDestination.X + iXOffset - topcorner.X) * iPixelsPerCell
    '            _fromCellLocation_y = (oPasteDestination.Y + iYOffset - topcorner.Y) * iPixelsPerCell
    '            _toCellLocation_x = (oPasteDestination.X + _width + iXOffset - topcorner.X) * iPixelsPerCell
    '            _toCellLocation_y = (oPasteDestination.Y + _height + iYOffset - topcorner.Y) * iPixelsPerCell
    '            Dim _selPenColour As Color = Color.Black
    '            _selPen = New Pen(_selPenColour, oStitchPenWidth)
    '            PicDesign.Invalidate()
    '        End If
    '    End If
    'End Sub

    'Private Sub MouseDownLeftNotSelecting(e As MouseEventArgs, pCell As Cell)
    '    Select Case oCurrentAction
    '        Case DesignAction.Copy
    '            StartSelection(pCell.Position)
    '        Case DesignAction.Paste
    '        Case DesignAction.Move
    '            StartSelection(pCell.Position)
    '        Case DesignAction.Cut
    '            StartSelection(pCell.Position)
    '        Case DesignAction.Flip
    '            StartSelection(pCell.Position)
    '        Case DesignAction.Mirror
    '            StartSelection(pCell.Position)
    '    End Select
    'End Sub

    'Private Sub MouseDownLeftMoving(e As MouseEventArgs, pCell As Cell)
    '    Select Case oCurrentAction
    '        Case DesignAction.Copy
    '            EndCopy(pCell.Position)
    '        Case DesignAction.Paste
    '            EndPaste(pCell.Position)
    '        Case DesignAction.Move
    '            RemoveSelectedCells()
    '            EndCopy(pCell.Position)
    '        Case DesignAction.Cut
    '            RemoveSelectedCells()
    '    End Select
    'End Sub
    'Private Sub MouseDownRightSelecting()
    '    Select Case oCurrentAction
    '        Case DesignAction.Copy
    '            ClearSelection()
    '            oCurrentAction = DesignAction.none
    '        Case DesignAction.Paste
    '        Case DesignAction.Move
    '            ClearSelection()
    '            oCurrentAction = DesignAction.none
    '        Case DesignAction.Cut
    '    End Select
    '    PicDesign.Invalidate()
    'End Sub
    'Private Sub MouseUpLeftSelecting(e As MouseEventArgs, pCell As Cell)
    '    Select Case oCurrentAction
    '        Case DesignAction.Copy
    '            EndCopySelection(pCell.Position)
    '            StartMoveSelection()
    '        Case DesignAction.Move
    '            EndCopySelection(pCell.Position)
    '            StartMoveSelection()
    '        Case DesignAction.Cut
    '            EndCopySelection(pCell.Position)
    '            RemoveSelectedCells()
    '            ClearSelection()
    '            oCurrentAction = DesignAction.none
    '        Case DesignAction.Flip
    '            EndCopySelection(pCell.Position)
    '            EndFlip(pCell.Position)
    '            ClearSelection()
    '        Case DesignAction.Mirror
    '            EndCopySelection(pCell.Position)
    '            EndMirror(pCell.Position)
    '            ClearSelection()
    '    End Select
    'End Sub
    'Private Sub MouseUpRightSelecting()
    '    Select Case oCurrentAction
    '        Case DesignAction.Copy
    '            ClearSelection()
    '            oCurrentAction = DesignAction.none
    '        Case DesignAction.Paste
    '        Case DesignAction.Move
    '        Case DesignAction.Cut
    '    End Select
    'End Sub
    'Private Sub EndCopySelection(pCellPosition As Point)
    '    oInProgressTerminus = pCellPosition
    '    oCurrentSelection = New Point() {oInProgressAnchor, oInProgressTerminus}
    '    GetSelectedCells()
    '    isSelectionInProgress = False
    '    SelectionMessage("Selection complete")
    'End Sub
    'Private Sub StartMoveSelection()
    '    isMoveInProgress = True
    '    SelectionMessage("Move in progress")
    'End Sub
    'Private Sub EndCopy(pCellPosition As Point)
    '    PasteSelectedCells(pCellPosition)
    '    ClearSelection()
    '    oCurrentAction = DesignAction.none
    'End Sub
    'Private Sub EndPaste(pCellPosition As Point)
    '    isMoveInProgress = False
    '    PasteMouseDown(pCellPosition)
    'End Sub
    'Private Sub EndFlip(pCellPosition As Point)
    '    FlipMouseDown(pCellPosition)
    'End Sub
    'Private Sub EndMirror(pCellPosition As Point)
    '    MirrorMouseDown(pCellPosition)
    'End Sub
    'Private Sub RemoveSelectedCells()
    '    If oCurrentSelectedBlockStitch.Count > 0 Then
    '        For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
    '            RemoveExistingBlockStitch(_bs.BlockLocation, oProjectDesign)
    '        Next
    '    End If
    '    If oCurrentSelectedKnot.Count > 0 Then
    '        For Each _knot As Knot In oCurrentSelectedKnot
    '            RemoveExistingKnot(_knot.BlockLocation, _knot.BlockQuarter, oProjectDesign)
    '        Next
    '    End If
    '    If oCurrentSelectedBackstitch.Count > 0 Then
    '        For Each _bkst As BackStitch In oCurrentSelectedBackstitch
    '            RemoveExistingBackStitch(_bkst.FromBlockLocation, _bkst.ToBlockLocation, oProjectDesign)
    '        Next
    '    End If
    '    DrawGrid(oProject, oProjectDesign)
    '    DisplayImage(oDesignBitmap, iXOffset, iYOffset)

    'End Sub

    'Private Sub PasteSelectedCells(pPosition As Point)
    '    Dim _xChange As Integer = pPosition.X - oInProgressAnchor.X
    '    Dim _yChange As Integer = pPosition.Y - oInProgressAnchor.Y
    '    Dim _newProjectDesign As ProjectDesign = oProjectDesign
    '    If oCurrentSelectedBlockStitch.Count > 0 Then
    '        For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
    '            Dim _newBs As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_bs).WithLocation(New Point(_bs.BlockLocation.X + _xChange, _bs.BlockLocation.Y + _yChange)).Build
    '            AddBlockStitch(_newProjectDesign, _newBs)
    '        Next
    '    End If
    '    If oCurrentSelectedKnot.Count > 0 Then
    '        For Each _knot As Knot In oCurrentSelectedKnot
    '            Dim _newKnot As Knot = KnotBuilder.AKnot.StartingWith(_knot).WithKnotLocation(New Point(_knot.BlockLocation.X + _xChange, _knot.BlockLocation.Y + _yChange)).Build
    '            AddKnot(_newProjectDesign, _newKnot)
    '        Next
    '    End If
    '    If oCurrentSelectedBackstitch.Count > 0 Then
    '        For Each _bkst As BackStitch In oCurrentSelectedBackstitch
    '            Dim _newBkst As BackStitch = BackstitchBuilder.ABackStitch.StartingWith(_bkst) _
    '                    .WithFromBlockLocation(New Point(_bkst.FromBlockLocation.X + _xChange, _bkst.FromBlockLocation.Y + _yChange)) _
    '                    .WithToBlockLocation(New Point(_bkst.ToBlockLocation.X + _xChange, _bkst.ToBlockLocation.Y + _yChange)) _
    '                    .Build
    '            AddBackStitch(_newProjectDesign, _newBkst)
    '        Next
    '    End If
    '    oProjectDesign = _newProjectDesign
    '    DrawGrid(oProject, oProjectDesign)
    '    DisplayImage(oDesignBitmap, iXOffset, iYOffset)

    'End Sub
    'Private Sub PicDesign_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseUp
    '    Dim _cell As Cell = FindCellFromClickLocation(e)
    '    If isSelectionInProgress Then
    '        MouseUpLeftSelecting(e, _cell)
    '    Else
    '        ' MouseUpLeftNotSelecting(e, _cell)
    '    End If
    'End Sub

    Private Sub PicDesign_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseDown
        Dim isImageChanged As Boolean = False
        Dim _cell As Cell = FindCellFromClickLocation(e)
        '    '======================================================================================
        '    If oCurrentAction = DesignAction.none Then
        '        Dim isRemove As Boolean = e.Button = MouseButtons.Right
        '        If isRemove Or isRemoveBackstitchInProgress Then
        '            LogUtil.Debug("Remove stitch", MyBase.Name)
        '            If isKnotAction Then
        '                LogUtil.Debug("Removing knot/bead", MyBase.Name)
        '                Dim _exists As Knot = FindKnot(_cell.KnotCellPos, _cell.KnotQtr)
        '                If _exists IsNot Nothing Then
        '                    RemoveKnotFromDesign(oProjectDesign, _exists)
        '                    isImageChanged = True
        '                End If
        '            ElseIf isBackstitchAction Then

        '                If isBackstitchInProgress Then
        '                    LogUtil.Debug("Backstitch ending", MyBase.Name)
        '                    isBackstitchInProgress = False
        '                    oBackstitchInProgress = Nothing
        '                Else
        '                    LogUtil.Debug("Selecting backstitch to remove", MyBase.Name)
        '                    If isRemoveBackstitchInProgress Then
        '                        LogUtil.LogInfo("Stopping timer", MyBase.Name)
        '                        StopTimer()
        '                        If e.Button = MouseButtons.Left Then
        '                            RemoveExistingBackStitch(oNearestBackstitches(oSelectedBackstitchIndex).FromBlockLocation,
        '                                                 oNearestBackstitches(oSelectedBackstitchIndex).ToBlockLocation,
        '                                                 oProjectDesign)
        '                            oSelectedBackstitchIndex = -1
        '                        Else
        '                            oSelectedBackstitchIndex += 1
        '                        End If

        '                        If oSelectedBackstitchIndex < 0 OrElse oSelectedBackstitchIndex >= oNearestBackstitches.Count Then
        '                            LogUtil.LogInfo("No more threads", MyBase.Name)
        '                            EndRemoveBackStitch()
        '                            oSelectedBackstitchIndex = -1
        '                        Else
        '                            LogUtil.LogInfo("Next backstitch", MyBase.Name)
        '                            oRemoveBackstitch = BackstitchBuilder.ABackStitch.StartingWith(oNearestBackstitches(oSelectedBackstitchIndex)).Build
        '                            StartTimer()
        '                        End If
        '                    Else
        '                        LogUtil.LogInfo("Start remove backstitch", MyBase.Name)
        '                        isRemoveBackstitchInProgress = True
        '                        oNearestBackstitches = FindBackstitches(_cell.Position)
        '                        If oNearestBackstitches.Count > 0 Then
        '                            oSelectedBackstitchIndex = 0
        '                            oRemoveBackstitch = BackstitchBuilder.ABackStitch.StartingWith(oNearestBackstitches(oSelectedBackstitchIndex)).Build
        '                            StartTimer()
        '                        Else
        '                            EndRemoveBackStitch()
        '                        End If
        '                    End If
        '                End If
        '            ElseIf isBlockstitchAction Then
        '                LogUtil.Debug("Removing blockstitch", MyBase.Name)
        '                Dim _exists As BlockStitch = FindBlockstitch(_cell.Position)
        '                If _exists.IsLoaded Then
        '                    RemoveBlockStitchFromDesign(oProjectDesign, _exists)
        '                    isImageChanged = True
        '                End If
        '            End If
        '        Else
        '            LogUtil.Debug("Create stitch", MyBase.Name)

        Select Case oCurrentStitchType
    '                Case DesignAction.BackstitchFullThick
    '                    BackstitchMouseDown(_cell.KnotCellPos, False, True)
    '                Case DesignAction.BackStitchFullThin
    '                    BackstitchMouseDown(_cell.KnotCellPos, False, False)
    '                Case DesignAction.BackstitchHalfThin
    '                    BackstitchMouseDown(_cell.KnotCellPos, _cell.KnotQtr, True, False)
    '                Case DesignAction.BackStitchHalfThick
    '                    BackstitchMouseDown(_cell.KnotCellPos, _cell.KnotQtr, True, True)
            Case DesignAction.Bead
                AddKnot(_cell, True)
            Case DesignAction.Knot
                AddKnot(_cell, False)
            Case DesignAction.FullBlockstitch
                AddFullBlockStitch(_cell)
            Case DesignAction.HalfBlockstitchBack
                AddHalfBlockStitch(_cell, True)
            Case DesignAction.HalfBlockstitchForward
                AddHalfBlockStitch(_cell, False)
            Case DesignAction.QuarterBlockstitchBottomRight
                AddQuarterBlockstitch(_cell, BlockQuarter.BottomRight)
            Case DesignAction.QuarterBlockstitchBottonLeft
                AddQuarterBlockstitch(_cell, BlockQuarter.BottomLeft)
            Case DesignAction.QuarterBlockstitchTopLeft
                AddQuarterBlockstitch(_cell, BlockQuarter.TopLeft)
            Case DesignAction.QuarterBlockstitchTopRight
                AddQuarterBlockstitch(_cell, BlockQuarter.TopRight)
            Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                AddThreeQuarterStitch(_cell, BlockQuarter.BottomLeft)
                '                    isImageChanged = True
            Case DesignAction.ThreeQuarterBlockstitchBottomRight
                AddThreeQuarterStitch(_cell, BlockQuarter.BottomRight)
                '                    isImageChanged = True
            Case DesignAction.ThreeQuarterBlockstitchTopLeft
                AddThreeQuarterStitch(_cell, BlockQuarter.TopLeft)
                '                    isImageChanged = True
            Case DesignAction.ThreeQuarterBlockstitchTopRight
                AddThreeQuarterStitch(_cell, BlockQuarter.TopRight)
                '                    isImageChanged = True
                '                Case DesignAction.BlockstitchQuarters
                '                    AddQuarterBlockstitch(_cell.Position, _cell.StitchQuarter)
                '                    isImageChanged = True
        End Select
        '        End If
        '    Else
        'Select Case e.Button
        '    Case MouseButtons.Left
        '        MouseDownLeft(e, _cell)
        '    Case MouseButtons.Right
        '        MouseDownRight(e, _cell)
        'End Select
        '    End If
        PicDesign.Invalidate()
        'If isImageChanged Then
        '        DrawGrid(oProject, oProjectDesign)
        '        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
        'End If
    End Sub

    '    Private Sub PicDesign_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseMove
    '        Dim _cell As Cell = FindCellFromClickLocation(e)

    '        Dim isImageChanged As Boolean = False
    '        Dim _cellPos As Point = _cell.Position
    '        Dim _cellLocation As Point = _cell.Location
    '        Dim _cellQtr As BlockQuarter = _cell.StitchQuarter
    '        Dim _knotqtr As BlockQuarter = _cell.KnotQtr
    '        Dim _knotPos As Point = _cell.KnotCellPos
    '        LblCursorPos.Text = "X:" & CStr(_cellPos.X + 1) & ", Y:" & CStr(_cellPos.Y + 1)
    '        PnlPixelColour.BackColor = GetPixelColour(e)
    '        Dim _isColourFound As Boolean
    '        Dim _colourName As String = String.Empty
    '        For Each _projectThread As ProjectThread In oProjectThreads
    '            If _projectThread.Thread.Colour = PnlPixelColour.BackColor Then
    '                _colourName = _projectThread.Thread.ColourName & " : DMC " & CStr(_projectThread.Thread.ThreadNo)
    '                _isColourFound = True
    '                Exit For
    '            End If
    '        Next
    '        LblPixelColourName.Text = _colourName
    '        '==================================================================
    '        If oCurrentAction = DesignAction.none Then

    '            If e.Button = MouseButtons.Right Then
    '                If oCurrentStitchType = DesignAction.Bead Or oCurrentStitchType = DesignAction.Knot Then
    '                    LogUtil.Debug("Remove knot on the move", MyBase.Name)
    '                    Dim _exists As Knot = FindKnot(_knotPos, _knotqtr)
    '                    If _exists IsNot Nothing Then
    '                        RemoveKnotFromDesign(oProjectDesign, _exists)
    '                        isImageChanged = True
    '                    End If
    '                Else
    '                    LogUtil.Debug("Remove blockstitch on the move", MyBase.Name)
    '                    Dim _exists As BlockStitch = FindBlockstitch(_cellPos)
    '                    If _exists.IsLoaded Then
    '                        RemoveBlockStitchFromDesign(oProjectDesign, _exists)
    '                        isImageChanged = True
    '                    End If
    '                End If
    '            End If

    '            If e.Button = MouseButtons.Left Then
    '                LogUtil.Debug("Adding stitch on the move", MyBase.Name)
    '                Select Case oCurrentStitchType
    '                    Case DesignAction.Bead
    '                        AddKnot(_knotPos, _knotqtr, True)
    '                        isImageChanged = True
    '                    Case DesignAction.Knot
    '                        AddKnot(_knotPos, _knotqtr, False)
    '                        isImageChanged = True
    '                    Case DesignAction.FullBlockstitch
    '                        AddFullBlockStitch(_cellPos)
    '                        isImageChanged = True
    '                    Case DesignAction.HalfBlockstitchBack
    '                        AddHalfBlockBackStitch(_cellPos)
    '                        isImageChanged = True
    '                    Case DesignAction.HalfBlockstitchForward
    '                        AddHalfBlockForwardStitch(_cellPos)
    '                        isImageChanged = True
    '                    Case DesignAction.QuarterBlockstitchBottomRight
    '                        AddQuarterBlockstitch(_cellPos, BlockQuarter.BottomRight)
    '                        isImageChanged = True
    '                    Case DesignAction.QuarterBlockstitchBottonLeft
    '                        AddQuarterBlockstitch(_cellPos, BlockQuarter.BottomLeft)
    '                        isImageChanged = True
    '                    Case DesignAction.QuarterBlockstitchTopLeft
    '                        AddQuarterBlockstitch(_cellPos, BlockQuarter.TopLeft)
    '                        isImageChanged = True
    '                    Case DesignAction.QuarterBlockstitchTopRight
    '                        AddQuarterBlockstitch(_cellPos, BlockQuarter.TopRight)
    '                        isImageChanged = True
    '                    Case DesignAction.ThreeQuarterBlockstitchBottomLeft
    '                        Add3QtrStitchBL(_cellPos)
    '                        isImageChanged = True
    '                    Case DesignAction.ThreeQuarterBlockstitchBottomRight
    '                        Add3QtrStitchBR(_cellPos)
    '                        isImageChanged = True
    '                    Case DesignAction.ThreeQuarterBlockstitchTopLeft
    '                        Add3QtrStitchTL(_cellPos)
    '                        isImageChanged = True
    '                    Case DesignAction.ThreeQuarterBlockstitchTopRight
    '                        Add3QtrStitchTR(_cellPos)
    '                        isImageChanged = True
    '                    Case DesignAction.BlockstitchQuarters
    '                        AddQuarterBlockstitch(_cellPos, _cellQtr)
    '                        isImageChanged = True
    '                End Select

    '            End If
    '            If e.Button = MouseButtons.None Then
    '                'If isSelectionInProgress Then
    '                '    DrawSelectionInProgress(_cellPos)
    '                'End If
    '                If isBackstitchInProgress Then
    '                    Select Case oCurrentStitchType
    '                        Case DesignAction.BackstitchFullThick
    '                            DrawBackstitchInProgress(_knotPos, BlockQuarter.TopLeft, False)

    '                        Case DesignAction.BackStitchFullThin
    '                            DrawBackstitchInProgress(_knotPos, BlockQuarter.TopLeft, False)

    '                        Case DesignAction.BackstitchHalfThin
    '                            DrawBackstitchInProgress(_knotPos, _knotqtr, True)

    '                        Case DesignAction.BackStitchHalfThick
    '                            DrawBackstitchInProgress(_knotPos, _knotqtr, True)

    '                    End Select
    '                End If
    '            End If
    '        Else
    '            Select Case e.Button
    '                Case MouseButtons.Left
    '                    'area definition
    '                    MouseMoveLeft(e, _cell)
    '                Case MouseButtons.None
    '                    'paste positioning
    '                    MouseMoveNone(e, _cell)
    '            End Select
    '        End If
    '        If isImageChanged Then
    '            LogUtil.Debug("Drawing changes after move", MyBase.Name)
    '            DrawGrid(oProject, oProjectDesign)
    '            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '        End If
    '    End Sub
    '    Private Sub PicDesign_SizeChanged(sender As Object, e As EventArgs) Handles PicDesign.SizeChanged
    '        If Not isLoading Then
    '            If oProject IsNot Nothing AndAlso oProjectDesign IsNot Nothing AndAlso oProject.IsLoaded AndAlso oProjectDesign.IsLoaded Then
    '                DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '            End If
    '        End If
    '    End Sub
    '    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
    '        If oDesignBitmap Is Nothing Then Exit Sub
    '        Dim rect As Rectangle
    '        Dim picx As Single = iPixelsPerCell * topcorner.X
    '        Dim picy As Single = iPixelsPerCell * topcorner.Y
    '        Dim picw As Single = oDesignBitmap.Width - picx
    '        Dim pich As Single = oDesignBitmap.Height - picy
    '        Dim atX As Single = iXOffset * iPixelsPerCell
    '        Dim atY As Single = iYOffset * iPixelsPerCell
    '        rect = New Rectangle(picx, picy, picw, pich)

    '        e.Graphics.DrawImage(oDesignBitmap, atX, atY, rect, GraphicsUnit.Pixel)
    '        If isBackstitchInProgress Then
    '            e.Graphics.DrawLine(_bsPen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
    '        End If
    '        If isRemoveBackstitchInProgress Then
    '            e.Graphics.DrawLine(_bsPen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
    '        End If
    '        If isSelectionInProgress Or isMoveInProgress Then
    '            Dim _width As Integer = _toCellLocation_x - _fromCellLocation_x + iPixelsPerCell
    '            Dim _height As Integer = _toCellLocation_y - _fromCellLocation_y + iPixelsPerCell
    '            e.Graphics.DrawRectangle(_selPen, _fromCellLocation_x, _fromCellLocation_y, _width, _height)
    '        End If

    '    End Sub
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
    '    Private Sub MnuZoomIn_Click(sender As Object, e As EventArgs) Handles MnuZoomIn.Click
    '        IncreaseMagnification()
    '    End Sub
    '    Private Sub MnuStitchDisplayStyle_Click(sender As Object, e As EventArgs) Handles MnuStitchDisplayStyle.Click
    '        Using _stitchStyle As New FrmStitchDisplayStyle
    '            _stitchStyle.ShowDialog()
    '        End Using
    '        RedrawDesign()
    '        InitialisePalette()
    '    End Sub

    '#End Region
    '#Region "thread buttons"
    Private Sub BtnFullStitch_Click(sender As Object, e As EventArgs) Handles BtnFullStitch.Click
        SelectFullBlockstitch()
    End Sub

    Private Sub SelectFullBlockstitch()
        oCurrentStitchType = DesignAction.FullBlockstitch
        StitchButtonSelected(BtnFullStitch)
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

    Private Sub BtnFullBackstitchThin_Click(sender As Object, e As EventArgs) Handles BtnFullBackstitchThin.Click
        oCurrentStitchType = DesignAction.BackStitchFullThin
        StitchButtonSelected(BtnFullBackstitchThin)
    End Sub

    Private Sub BtnHalfBackStitchThin_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThin.Click
        oCurrentStitchType = DesignAction.BackstitchHalfThin
        StitchButtonSelected(BtnHalfBackStitchThin)
    End Sub

    Private Sub BtnFullBackStitchThick_Click(sender As Object, e As EventArgs) Handles BtnFullBackStitchThick.Click
        oCurrentStitchType = DesignAction.BackstitchFullThick
        StitchButtonSelected(BtnFullBackStitchThick)
    End Sub

    Private Sub BtnHalfBackStitchThick_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThick.Click
        oCurrentStitchType = DesignAction.BackStitchHalfThick
        StitchButtonSelected(BtnHalfBackStitchThick)
    End Sub

    Private Sub BtnKnot_Click(sender As Object, e As EventArgs) Handles BtnKnot.Click
        oCurrentStitchType = DesignAction.Knot
        StitchButtonSelected(BtnKnot)
    End Sub

    Private Sub BtnBead_Click(sender As Object, e As EventArgs) Handles BtnBead.Click
        oCurrentStitchType = DesignAction.Bead
        StitchButtonSelected(BtnBead)
    End Sub
    '#End Region
    '#Region "action buttons"
    '    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
    '        Dim _filename As String = MakeFilename(oProject)
    '        SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
    '    End Sub

    '    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
    '        BeginCopy()
    '    End Sub

    '    Private Sub BtnCut_Click(sender As Object, e As EventArgs) Handles BtnCut.Click
    '        BeginCut()
    '    End Sub

    '    Private Sub BtnMove_Click(sender As Object, e As EventArgs) Handles BtnMove.Click
    '        BeginMove()
    '    End Sub

    '    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
    '        BeginPaste()

    '    End Sub
    '    Private Sub BtnMirror_Click(sender As Object, e As EventArgs) Handles BtnMirror.Click
    '        BeginMirror()
    '    End Sub

    '    Private Sub BtnFlip_Click(sender As Object, e As EventArgs) Handles BtnFlip.Click
    '        BeginFlip()
    '    End Sub
    '    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles BtnUndo.Click
    '        UndoLastAction()
    '    End Sub

    '    Private Sub BtnRedo_Click(sender As Object, e As EventArgs) Handles BtnRedo.Click
    '        RedoLastUndo()
    '    End Sub

    '    Private Sub BtnZoom_Click(sender As Object, e As EventArgs) Handles BtnZoom.Click

    '    End Sub

    '    Private Sub BtnEnlarge_Click(sender As Object, e As EventArgs) Handles BtnEnlarge.Click
    '        IncreaseMagnification()
    '    End Sub

    '    Private Sub BtnShrink_Click(sender As Object, e As EventArgs) Handles BtnShrink.Click
    '        DecreaseMagnification()

    '    End Sub
    Private Sub BtnCentre_Click(sender As Object, e As EventArgs) Handles BtnCentre.Click
        isLoading = True
        CalculateOffsetForCentre(oDesignBitmap)
        PicDesign.Invalidate()
        isLoading = False
    End Sub
    '    Private Sub BtnHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeight.Click
    '        isLoading = True
    '        ChangeMagnification(1)
    '        Dim _newPpc As Decimal = PicDesign.Height / oProjectDesign.Rows
    '        Dim _heightRatio As Decimal = _newPpc / PIXELS_PER_CELL
    '        ChangeMagnification(_heightRatio)
    '        DrawGrid(oProject, oProjectDesign)
    '        CalculateOffsetForCentre(oDesignBitmap)
    '        isLoading = False
    '        '     DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '    End Sub
    '    Private Sub BtnWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWidth.Click
    '        isLoading = True
    '        ChangeMagnification(1)
    '        Dim _newPpc As Decimal = PicDesign.Width / oProjectDesign.Columns
    '        Dim _widthRatio As Decimal = _newPpc / PIXELS_PER_CELL
    '        ChangeMagnification(_widthRatio)
    '        DrawGrid(oProject, oProjectDesign)
    '        CalculateOffsetForCentre(oDesignBitmap)
    '        isLoading = False
    '        '      DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '    End Sub
    '#End Region
    '#Region "menus"
    '    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuSaveDesign.Click
    '        Dim _filename As String = MakeFilename(oProject)
    '        LogUtil.Info("Saving design", MyBase.Name)
    '        SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
    '        LogUtil.Info("Design saved to " & _filename, MyBase.Name)
    '    End Sub

    '    Private Sub MnuOpenDesign_Click(sender As Object, e As EventArgs) Handles MnuOpenDesign.Click

    '    End Sub

    Private Sub MnuThreads_Click(sender As Object, e As EventArgs) Handles MnuThreads.Click
        OpenProjectThreadsForm()
    End Sub

    Private Sub OpenProjectThreadsForm()
        If oProject.ProjectId > 0 Then
            LogUtil.Info("Opening Project Threads form", MyBase.Name)
            Using _projthreads As New FrmProjectThreads
                _projthreads.SelectedProject = oProject
                _projthreads.ShowDialog()
            End Using
        End If
    End Sub

    '    Private Sub MnuThreadSymbols_Click(sender As Object, e As EventArgs) Handles MnuThreadSymbols.Click
    '        If oProject.ProjectId > 0 Then
    '            LogUtil.Info("Opening Project ProjectThread Symbols form", MyBase.Name)
    '            Using _threadsymbols As New FrmThreadSymbols
    '                _threadsymbols.SelectedProject = oProject
    '                _threadsymbols.ShowDialog()
    '            End Using
    '            InitialisePalette()
    '        End If
    '    End Sub

    '    Private Sub MnuZoomOut_Click(sender As Object, e As EventArgs) Handles MnuZoomOut.Click
    '        DecreaseMagnification()

    '    End Sub

    '    Private Sub MnuGridOn_Click(sender As Object, e As EventArgs) Handles MnuGridOn.Click
    '        ToggleGrid()
    '    End Sub

    '    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
    '        Close()
    '    End Sub

    '    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuSaveDesignAs.Click
    '        LogUtil.Info("Getting filename for save", MyBase.Name)
    '        Dim _filename As String = FileUtil.GetFileName(FileUtil.OpenOrSave.Save, FileUtil.FileType.HSZ, My.Settings.DesignFilePath)
    '        If Not String.IsNullOrEmpty(_filename) Then
    '            LogUtil.Info("Saving design", MyBase.Name)
    '            SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
    '            LogUtil.Info("Design saved to " & _filename, MyBase.Name)
    '        End If
    '    End Sub

    '    Private Sub MnuSelectPaletteColours_Click(sender As Object, e As EventArgs) Handles MnuSelectPaletteColours.Click
    '        OpenProjectThreadsForm()
    '    End Sub

    '    Private Sub MnuRemoveUnusedColours_Click(sender As Object, e As EventArgs) Handles MnuRemoveUnusedColours.Click

    '    End Sub

    '    Private Sub MnuCreateThreadCards_Click(sender As Object, e As EventArgs) Handles MnuCreateThreadCards.Click

    '    End Sub

    '    Private Sub MnuPrintThreadCards_Click(sender As Object, e As EventArgs) Handles MnuPrintThreadCards.Click

    '    End Sub

    '    Private Sub MnuCopySelection_Click(sender As Object, e As EventArgs) Handles MnuCopySelection.Click
    '        BeginCopy()
    '    End Sub

    '    Private Sub MnuMoveSelection_Click(sender As Object, e As EventArgs) Handles MnuMoveSelection.Click
    '        BeginMove()
    '    End Sub

    '    Private Sub MnuCutSelection_Click(sender As Object, e As EventArgs) Handles MnuCutSelection.Click
    '        BeginCut()
    '    End Sub

    '    Private Sub MnuPaste_Click(sender As Object, e As EventArgs) Handles MnuPaste.Click
    '        BeginPaste()
    '    End Sub

    '    Private Sub FlipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuFlipSelection.Click
    '        BeginFlip()
    '    End Sub

    '    Private Sub MirrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuMirrorSelection.Click
    '        BeginMirror()
    '    End Sub

    '    Private Sub RotateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuRotate.Click

    '    End Sub

    '    Private Sub ClearAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuClearArea.Click

    '    End Sub

    '    Private Sub DrawShapeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuDrawShape.Click

    '    End Sub

    '    Private Sub DrawFilledShapeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuDrawFilledShape.Click

    '    End Sub

    '    Private Sub FloodFillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuFloodFill.Click

    '    End Sub

    '    Private Sub RedrawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuRedraw.Click
    '        RedrawDesign()
    '    End Sub

    '    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuZoom.Click

    '    End Sub

    '    Private Sub CropToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuCropDesign.Click

    '    End Sub

    '    Private Sub ExtendToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuExtendDesign.Click

    '    End Sub

    '    Private Sub MnuShowDesignStats_Click(sender As Object, e As EventArgs) Handles MnuShowDesignStats.Click

    '    End Sub

    '    Private Sub MnuOptions_Click(sender As Object, e As EventArgs) Handles MnuOptions.Click
    '        Using _options As New FrmOptions
    '            _options.ShowDialog()
    '        End Using
    '    End Sub

    '#End Region
    '#Region "subroutines"
    '    '   Initialise
    Private Sub InitialiseForm()
        isComponentInitialised = True
        isLoading = True
        PicDesign.Enabled = False
        oProject = GetProjectById(oProjectId)
        oUndoList = New List(Of StitchAction)
        oRedoList = New List(Of StitchAction)
        BtnUndo.Enabled = False
        BtnRedo.Enabled = False
        SetIsGridOn()
        SetShowStitchTypesMenu()
        SelectFullBlockstitch()
        PnlSelectedColor.BackColor = SystemColors.Control
        If oProject.IsLoaded Then
            oProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(My.Settings.DesignFilePath, MakeFilename(oProject)).Build
            If Not oProjectDesign.IsLoaded Then
                oProjectDesign.Rows = oProject.DesignHeight
                oProjectDesign.Columns = oProject.DesignWidth
            End If
            InitialisePalette()
            SetInitialMagnification()
            ' Create image the size of the design
            oDesignBitmap = New Bitmap(CInt(oProjectDesign.Columns * iPixelsPerCell), CInt(oProjectDesign.Rows * iPixelsPerCell))
            CalculateOffsetForCentre(oDesignBitmap)
            iOldHScrollbarValue = HScrollBar1.Value
            iOldVScrollbarValue = VScrollBar1.Value
            'Draw grid onto graphics
            'Create graphics from image
            Dim _fabricColour As Color = GetColourFromProject(oProject.FabricColour, oFabricColour)
            Dim _fabricBrush As New SolidBrush(_fabricColour)
            oDesignGraphics = Graphics.FromImage(oDesignBitmap)
            oDesignGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            oDesignGraphics.FillRectangle(_fabricBrush, New Rectangle(0, 0, oDesignBitmap.Width, oDesignBitmap.Height))

            FillBeforeGrid()
            DrawGrid(oProject, oProjectDesign)
            PicDesign.Invalidate()
        Else
            MsgBox("No project found", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If
        PicDesign.Enabled = True
        isLoading = False
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
        Dim isNoThreads As Boolean = True
        Do While oProjectThreads.Count = 0
            If MsgBox("Select threads to continue with the project?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "No Project Threads") = MsgBoxResult.Cancel Then
                isNoThreads = False
                Close()
                Return isNoThreads
                Exit Function
            End If
            OpenProjectThreadsForm()
            oProjectThreads = GetProjectThreads(oProject.ProjectId)
        Loop
        Return isNoThreads
    End Function
    Private Sub SetShowStitchTypesMenu()
        MnuBackStitches.Checked = My.Settings.IsShowBackstitches
        MnuBlockStitches.Checked = My.Settings.IsShowBlockstitches
        MnuKnots.Checked = My.Settings.IsShowKnots
    End Sub
    '    Private Sub SetStitchTypesSettings()
    '        My.Settings.IsShowBackstitches = MnuBackStitches.Checked
    '        My.Settings.IsShowBlockstitches = MnuBlockStitches.Checked
    '        My.Settings.IsShowKnots = MnuKnots.Checked
    '        My.Settings.Save()
    '    End Sub

    Private Sub SetCurrentActionClass()
        Select Case oCurrentStitchType
            Case DesignAction.Knot,
                 DesignAction.Bead
                isKnotAction = True
            Case DesignAction.BackStitchFullThin,
                 DesignAction.BackstitchFullThick,
                 DesignAction.BackstitchHalfThin,
                 DesignAction.BackStitchHalfThick
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
    Private Function InitialisePalette() As Boolean
        Dim isOK As Boolean = True
        If isComponentInitialised Then
            ThreadLayoutPanel.Controls.Clear()
            oProjectThreads = GetProjectThreads(oProject.ProjectId)
            If IsProjectHasThreads() Then
                oProjectThreads.Sort(Function(x As ProjectThread, y As ProjectThread) x.Thread.SortNumber.CompareTo(y.Thread.SortNumber))
                Dim _panelWidth As Integer = ThreadLayoutPanel.Width
                Dim _panelHeight As Integer = ThreadLayoutPanel.Height
                Dim _threadCt As Integer = oProjectThreads.Count
                Dim _picSize As Integer = ShrinkPic(ThreadLayoutPanel, _threadCt)
                Dim _firstPicThread As PictureBox = Nothing
                For Each _projectThread As ProjectThread In oProjectThreads
                    Dim _thread As Thread = _projectThread.Thread
                    Dim _picThread As New PictureBox()
                    With _picThread
                        .Name = CStr(_thread.ThreadId)
                        .Size = New Size(_picSize, _picSize)
                        .BackColor = _thread.Colour
                        .BorderStyle = BorderStyle.None
                        Dim tt As New ToolTip
                        tt.SetToolTip(_picThread, _thread.ColourName & " " & _thread.ThreadNo)
                        AddHandler .Click, AddressOf Palette_Click
                        If _projectThread.SymbolId > 0 Then
                            If My.Settings.PaletteStitchDisplay = StitchDisplayStyle.BlocksWithSymbols Then
                                .Image = GetSymbolById(_projectThread.SymbolId).SymbolImage
                                .SizeMode = PictureBoxSizeMode.Zoom
                            End If
                        End If
                    End With
                    ThreadLayoutPanel.Controls.Add(_picThread)
                    _firstPicThread = If(_firstPicThread, _picThread)
                Next
                If _firstPicThread IsNot Nothing Then
                    SelectPaletteColour(_firstPicThread)
                End If
            End If
        End If
        Return isOK
    End Function
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

    ' Scrollbars
    Private Sub CalculateScrollBarValues()
        HScrollBar1.Value = oProjectDesign.Columns - 1 + iXOffset - topcorner.X
        VScrollBar1.Value = oProjectDesign.Rows - 1 + iYOffset - topcorner.Y
    End Sub
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
    '    Private Sub IncreaseMagnification()
    '        isLoading = True
    '        ChangeMagnification(Math.Round(dMagnification * MAG_STEP, 2, MidpointRounding.AwayFromZero))
    '        DrawGrid(oProject, oProjectDesign)
    '        CalculateOffsetForCentre(oDesignBitmap)
    '        isLoading = False
    '    End Sub
    '    Private Sub DecreaseMagnification()
    '        isLoading = True
    '        ChangeMagnification(Math.Round(dMagnification / MAG_STEP, 2, MidpointRounding.AwayFromZero))

    '        DrawGrid(oProject, oProjectDesign)
    '        CalculateOffsetForCentre(oDesignBitmap)
    '        isLoading = False
    '    End Sub
    Private Sub CalculateOffsetForCentre(pDesignBitmap)
        Dim x As Integer = (PicDesign.Width - pDesignBitmap.Width) / (2 * iPixelsPerCell)
        Dim y As Integer = (PicDesign.Height - pDesignBitmap.Height) / (2 * iPixelsPerCell)
        SetValuesAfterHorizontalChange(x)
        SetValuesAfterVerticalChange(y)
        CalculateScrollBarValues()
        iOldHScrollbarValue = HScrollBar1.Value
        iOldVScrollbarValue = VScrollBar1.Value
    End Sub
    '    Private Sub RedrawDesign()
    '        DrawGrid(oProject, oProjectDesign)
    '        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '    End Sub
    Private Sub DrawGrid(ByRef pProject As Project, ByRef pProjectDesign As ProjectDesign)
        Dim _widthInColumns As Integer = pProjectDesign.Columns
        Dim _heightInRows As Integer = pProjectDesign.Rows
        Dim gap As Integer = iPixelsPerCell
        Dim wct As Integer = oDesignBitmap.Width / gap

        Dim _designBorderPen As New Pen(Brushes.Black, 2)
        '   oDesignGraphics.FillRectangle(_fabricBrush, New Rectangle(0, 0, oDesignBitmap.Width, oDesignBitmap.Height))
        '  FillBeforeGrid()
        If My.Settings.isGridOn Then
            For x = 0 To _widthInColumns
                oDesignGraphics.DrawLine(_grid1Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 0 To _heightInRows
                oDesignGraphics.DrawLine(_grid1Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
            For x = 5 To _widthInColumns Step 10
                oDesignGraphics.DrawLine(_grid5Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 5 To _heightInRows Step 10
                oDesignGraphics.DrawLine(_grid5Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
            For x = 10 To _widthInColumns Step 10
                oDesignGraphics.DrawLine(_grid10Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 10 To _heightInRows Step 10
                oDesignGraphics.DrawLine(_grid10Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
        End If
        '   FillAfterGrid()
        oDesignGraphics.DrawRectangle(_designBorderPen, New Rectangle(0, 0, Math.Min(gap * _widthInColumns, oDesignBitmap.Width), Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
        _designBorderPen.Dispose()

    End Sub
    Private Sub FillBeforeGrid()
        If My.Settings.IsShowBlockstitches Then
            For Each _blockstitch In oProjectDesign.BlockStitches
                If _blockstitch.IsLoaded Then
                    Select Case _blockstitch.StitchType
                        Case BlockStitchType.Full
                            DrawFullBlockStitch(_blockstitch)
                        Case BlockStitchType.Half
                            DrawHalfBlockStitch(_blockstitch, True)
                        Case BlockStitchType.Quarter
                            DrawQuarterBlockStitch(_blockstitch)
                        Case Else
                            DrawQuarterBlockStitch(_blockstitch)
                    End Select
                End If
            Next
        End If
    End Sub
    Private Sub FillAfterGrid()
        '        If My.Settings.IsShowBackstitches Then
        '            For Each _backstitch In oProjectDesign.BackStitches
        '                DrawBackstitch(_backstitch)
        '            Next
        '        End If
        If My.Settings.IsShowKnots Then
            For Each _knot As Knot In oProjectDesign.Knots
                DrawKnot(_knot)
            Next
        End If
    End Sub
    'Private Sub ToggleGrid()
    '    My.Settings.isGridOn = Not My.Settings.isGridOn
    '    My.Settings.Save()
    '    SetIsGridOn()
    '    DrawGrid(oProject, oProjectDesign)
    '    DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    'End Sub
    Private Sub SetIsGridOn()
        MnuGridOn.Checked = My.Settings.isGridOn
        If My.Settings.isGridOn Then
            PicGrid.Image = My.Resources.gridon
        Else
            PicGrid.Image = My.Resources.gridoff
        End If
    End Sub
    '    Private Sub DisplayImage(pImage As Bitmap)
    '        DisplayImage(pImage, 0, 0)
    '    End Sub

    Private Sub DisplayImage(pImage As Bitmap, pX As Integer, pY As Integer, e As PaintEventArgs)
        If oDesignBitmap Is Nothing Then Exit Sub
        Dim rect As Rectangle
        Dim picx As Single = iPixelsPerCell * topcorner.X
        Dim picy As Single = iPixelsPerCell * topcorner.Y
        Dim picw As Single = oDesignBitmap.Width - picx
        Dim pich As Single = oDesignBitmap.Height - picy
        Dim atX As Single = pX * iPixelsPerCell
        Dim atY As Single = pY * iPixelsPerCell

        rect = New Rectangle(picx, picy, picw, pich)
        '  Dim myfg As Graphics = PicDesign.CreateGraphics
        '        '       myfg.Clear(PicDesign.BackColor)

        Try
            e.Graphics.DrawImage(pImage, atX, atY, rect, GraphicsUnit.Pixel)
        Catch ex As Exception
            Throw New ApplicationException("Cannot draw the coupon:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function MakeFilename(pProject As Project) As String
        Dim _filename As String = oProject.DesignFileName
        If String.IsNullOrEmpty(_filename) Then
            _filename = Replace(oProject.ProjectName, " ", "_").ToLower
        End If
        Return _filename
    End Function
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
    End Sub

    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        DisplayImage(oDesignBitmap, iXOffset, iYOffset, e)
    End Sub

    '    Private Sub UndoLastAction()
    '        If oUndoList.Count > 0 Then
    '            Dim _stitchAction As StitchAction = oUndoList.Last
    '            oRedoList.Add(_stitchAction)
    '            BtnRedo.Enabled = True
    '            If _stitchAction.DoneAction = UndoAction.Add Then
    '                If TypeOf _stitchAction.Stitch Is Knot Then
    '                    oProjectDesign.Knots.Remove(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
    '                    oProjectDesign.BlockStitches.Remove(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
    '                    oProjectDesign.BackStitches.Remove(_stitchAction.Stitch)
    '                End If
    '            Else
    '                If TypeOf _stitchAction.Stitch Is Knot Then
    '                    oProjectDesign.Knots.Add(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
    '                    oProjectDesign.BlockStitches.Add(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
    '                    oProjectDesign.BackStitches.Add(_stitchAction.Stitch)
    '                End If
    '            End If
    '            oUndoList.Remove(_stitchAction)
    '            If oUndoList.Count = 0 Then
    '                BtnUndo.Enabled = False
    '            End If
    '            DrawGrid(oProject, oProjectDesign)
    '            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '        End If
    '    End Sub
    '    Private Sub RedoLastUndo()
    '        If oRedoList.Count > 0 Then
    '            Dim _stitchAction As StitchAction = oRedoList.Last
    '            oUndoList.Add(_stitchAction)
    '            BtnUndo.Enabled = True
    '            If _stitchAction.DoneAction = UndoAction.Add Then
    '                If TypeOf _stitchAction.Stitch Is Knot Then
    '                    oProjectDesign.Knots.Add(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
    '                    oProjectDesign.BlockStitches.Add(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
    '                    oProjectDesign.BackStitches.Add(_stitchAction.Stitch)
    '                End If
    '            Else
    '                If TypeOf _stitchAction.Stitch Is Knot Then
    '                    oProjectDesign.Knots.Remove(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BlockStitch Then
    '                    oProjectDesign.BlockStitches.Remove(_stitchAction.Stitch)
    '                ElseIf TypeOf _stitchAction.Stitch Is BackStitch Then
    '                    oProjectDesign.BackStitches.Remove(_stitchAction.Stitch)
    '                End If
    '            End If
    '            oRedoList.Remove(_stitchAction)
    '            If oRedoList.Count = 0 Then
    '                BtnRedo.Enabled = False
    '            End If
    '            DrawGrid(oProject, oProjectDesign)
    '            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '        End If
    '    End Sub

    '    'Mouse Down
    '    Private Sub CopySelectMouseDown(pPosition As Point)
    '        If isSelectionInProgress Then
    '            LogUtil.Debug("MouseDown selection in progress", MyBase.Name)
    '            EndSelection(pPosition)
    '        Else
    '            LogUtil.Debug("MouseDown selection NOT in progress", MyBase.Name)
    '            StartSelection(pPosition)
    '        End If
    '    End Sub
    '    Private Sub CutSelectMouseDown(pPosition As Point)
    '        If isSelectionInProgress Then
    '            LogUtil.Debug("MouseDown selection in progress", MyBase.Name)
    '            EndSelection(pPosition)
    '        Else
    '            LogUtil.Debug("MouseDown selection NOT in progress", MyBase.Name)
    '            StartSelection(pPosition)
    '        End If
    '    End Sub
    '    Private Sub FlipMouseDown(pPosition As Point)
    '        If oCurrentSelection.Length > 0 Then
    '            Dim _sum As Integer = oCurrentSelection(1).Y + oCurrentSelection(0).Y - 1
    '            If oCurrentSelectedBlockStitch.Count > 0 Then
    '                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
    '                    _bs.BlockLocation = New Point(_bs.BlockLocation.X, _sum - _bs.BlockLocation.Y)
    '                Next
    '            End If
    '            If oCurrentSelectedKnot.Count > 0 Then
    '                For Each _knot As Knot In oCurrentSelectedKnot
    '                    If _knot.BlockQuarter = BlockQuarter.BottomLeft Or _knot.BlockQuarter = BlockQuarter.BottomRight Then
    '                        _knot.BlockLocation = New Point(_knot.BlockLocation.X, _sum - _knot.BlockLocation.Y)
    '                    Else
    '                        _knot.BlockLocation = New Point(_knot.BlockLocation.X, _sum - _knot.BlockLocation.Y + 1)
    '                    End If
    '                Next
    '            End If
    '            'If oCurrentSelectedBackstitch.Count > 0 Then
    '            '    For Each _bkst As BackStitch In oCurrentSelectedBackstitch

    '            '    Next
    '            'End If
    '            DrawGrid(oProject, oProjectDesign)
    '            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '        End If
    '        oCurrentAction = DesignAction.none

    '    End Sub
    '    Private Sub MirrorMouseDown(pPosition As Point)
    '        If oCurrentSelection.Length > 0 Then
    '            Dim _sum As Integer = oCurrentSelection(1).X + oCurrentSelection(0).X - 1
    '            If oCurrentSelectedBlockStitch.Count > 0 Then
    '                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
    '                    _bs.BlockLocation = New Point(_sum - _bs.BlockLocation.X, _bs.BlockLocation.Y)
    '                Next
    '            End If
    '            If oCurrentSelectedKnot.Count > 0 Then
    '                For Each _knot As Knot In oCurrentSelectedKnot
    '                    If _knot.BlockQuarter = BlockQuarter.TopLeft Or _knot.BlockQuarter = BlockQuarter.BottomLeft Then
    '                        _knot.BlockLocation = New Point(_sum - _knot.BlockLocation.X + 1, _knot.BlockLocation.Y)
    '                    Else
    '                        _knot.BlockLocation = New Point(_sum - _knot.BlockLocation.X, _knot.BlockLocation.Y)
    '                    End If
    '                Next
    '            End If
    '            DrawGrid(oProject, oProjectDesign)
    '            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '        End If
    '        oCurrentAction = DesignAction.none

    '    End Sub
    '    Private Sub PasteMouseDown(pPosition As Point)
    '        If oCurrentSelection.Length > 0 Then
    '            Dim _xChange As Integer = pPosition.X - oCurrentSelection(0).X
    '            Dim _yChange As Integer = pPosition.Y - oCurrentSelection(0).Y
    '            Dim _newProjectDesign As ProjectDesign = oProjectDesign
    '            If oCurrentSelectedBlockStitch.Count > 0 Then
    '                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
    '                    Dim _newBs As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_bs).WithLocation(New Point(_bs.BlockLocation.X + _xChange, _bs.BlockLocation.Y + _yChange)).Build
    '                    AddBlockStitch(_newProjectDesign, _newBs)
    '                Next
    '            End If
    '            If oCurrentSelectedKnot.Count > 0 Then
    '                For Each _knot As Knot In oCurrentSelectedKnot
    '                    Dim _newKnot As Knot = KnotBuilder.AKnot.StartingWith(_knot).WithKnotLocation(New Point(_knot.BlockLocation.X + _xChange, _knot.BlockLocation.Y + _yChange)).Build
    '                    AddKnot(_newProjectDesign, _newKnot)
    '                Next
    '            End If
    '            If oCurrentSelectedBackstitch.Count > 0 Then
    '                For Each _bkst As BackStitch In oCurrentSelectedBackstitch
    '                    Dim _newBkst As BackStitch = BackstitchBuilder.ABackStitch.StartingWith(_bkst) _
    '                        .WithFromBlockLocation(New Point(_bkst.FromBlockLocation.X + _xChange, _bkst.FromBlockLocation.Y + _yChange)) _
    '                        .WithToBlockLocation(New Point(_bkst.ToBlockLocation.X + _xChange, _bkst.ToBlockLocation.Y + _yChange)) _
    '                        .Build
    '                    AddBackStitch(_newProjectDesign, _newBkst)
    '                Next
    '            End If
    '            oProjectDesign = _newProjectDesign
    '            DrawGrid(oProject, oProjectDesign)
    '            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '        End If
    '        oCurrentAction = DesignAction.none
    '    End Sub

    '    ' Cell selection
    '    Private Sub StartSelection(pCellLocation As Point)
    '        LogUtil.Debug("Starting selection", MyBase.Name)
    '        oInProgressAnchor = pCellLocation
    '        oInProgressTerminus = New Point(pCellLocation.X, pCellLocation.Y)
    '        isSelectionInProgress = True
    '        SelectionMessage("Selection in progress")
    '        LogUtil.Debug("Backstitch IS in progress", MyBase.Name)
    '    End Sub
    '    Private Sub SelectionMessage(pText As String)
    '        LblSelectMessage.Text = pText
    '        If pText = String.Empty Then
    '            LblSelection.Text = String.Empty
    '        Else
    '            LblSelection.Text = "From " & oInProgressAnchor.X & "," & oInProgressAnchor.Y & "  To " & oInProgressTerminus.X & "," & oInProgressTerminus.Y
    '        End If
    '    End Sub
    '    Private Sub EndSelection(pCellLocation As Point)
    '        LogUtil.Debug("Ending selection", MyBase.Name)
    '        If isSelectionInProgress Then
    '            If oCurrentAction = DesignAction.Cut Then
    '                '      CutCells(oCurrentSelectedCells)
    '            End If
    '            If oCurrentAction = DesignAction.Paste Then
    '                '       PasteCells(oCurrentSelectedCells, oInProgressAnchor)
    '            End If
    '            oInProgressTerminus = pCellLocation
    '            '        oCurrentSelection = New Point() {oInProgressAnchor, oInProgressTerminus}
    '            GetSelectedCells()
    '            isSelectionInProgress = False
    '            SelectionMessage("Selection complete")
    '            oCurrentAction = DesignAction.none
    '        Else
    '            LogUtil.Debug("Ending backstitch - error not in progress", MyBase.Name)
    '        End If
    '    End Sub
    '    Private Sub DrawSelectionInProgress(pCell As Point)
    '        oInProgressTerminus = New Point(pCell.X - 1, pCell.Y - 1)
    '        oSelectionPenWidth = Math.Max(2, iPixelsPerCell / 16)
    '        _fromCellLocation_x = (oInProgressAnchor.X + iXOffset - topcorner.X) * iPixelsPerCell
    '        _fromCellLocation_y = (oInProgressAnchor.Y + iYOffset - topcorner.Y) * iPixelsPerCell
    '        _toCellLocation_x = (oInProgressTerminus.X + iXOffset - topcorner.X) * iPixelsPerCell
    '        _toCellLocation_y = (oInProgressTerminus.Y + iYOffset - topcorner.Y) * iPixelsPerCell
    '        Dim _selPenColour As Color = Color.Black
    '        _selPen = New Pen(_selPenColour, oStitchPenWidth)
    '        PicDesign.Invalidate()
    '    End Sub

    '    Private Sub GetSelectedCells()
    '        Dim _from_x As Integer = oCurrentSelection(0).X
    '        Dim _from_y As Integer = oCurrentSelection(0).Y
    '        Dim _to_x As Integer = oCurrentSelection(1).X
    '        Dim _to_y As Integer = oCurrentSelection(1).Y
    '        oCurrentSelectedBlockStitch = New List(Of BlockStitch)
    '        For Each _bs As BlockStitch In oProjectDesign.BlockStitches
    '            If _bs.BlockLocation.X >= _from_x And _bs.BlockLocation.X < _to_x _
    '                And _bs.BlockLocation.Y >= _from_y And _bs.BlockLocation.Y < _to_y Then
    '                oCurrentSelectedBlockStitch.Add(_bs)
    '            End If
    '        Next
    '        oCurrentSelectedKnot = New List(Of Knot)
    '        For Each _knot In oProjectDesign.Knots
    '            If _knot.BlockLocation.X >= _from_x And _knot.BlockLocation.X <= _to_x _
    '                And _knot.BlockLocation.Y >= _from_y And _knot.BlockLocation.Y <= _to_y Then
    '                oCurrentSelectedKnot.Add(_knot)
    '            End If
    '        Next
    '        oCurrentSelectedBackstitch = New List(Of BackStitch)
    '        For Each _bkst As BackStitch In oProjectDesign.BackStitches
    '            If _bkst.FromBlockLocation.X >= _from_x And _bkst.FromBlockLocation.X <= _to_x _
    '                And _bkst.FromBlockLocation.Y >= _from_y And _bkst.FromBlockLocation.Y <= _to_y Then
    '                oCurrentSelectedBackstitch.Add(_bkst)
    '            End If
    '        Next

    '    End Sub
    '    Private Sub BeginCopy()
    '        oCurrentAction = DesignAction.Copy
    '        oCurrentStitchType = DesignAction.none
    '        StitchButtonSelected()
    '        LblSelectMessage.Text = "Select area to copy"
    '    End Sub
    '    Private Sub BeginMove()
    '        oCurrentAction = DesignAction.Move
    '        oCurrentStitchType = DesignAction.none
    '        StitchButtonSelected()
    '        LblSelectMessage.Text = "Select area to move"
    '    End Sub
    '    Private Sub BeginCut()
    '        oCurrentAction = DesignAction.Cut
    '        oCurrentStitchType = DesignAction.none
    '        StitchButtonSelected()
    '        LblSelectMessage.Text = "Select area to cut"
    '    End Sub
    '    Private Sub BeginPaste()
    '        oCurrentAction = DesignAction.Paste
    '        oCurrentStitchType = DesignAction.none
    '        StitchButtonSelected()
    '        LblSelectMessage.Text = "Select location to paste"
    '        isMoveInProgress = True
    '    End Sub
    '    Private Sub BeginFlip()
    '        oCurrentAction = DesignAction.Flip
    '        oCurrentStitchType = DesignAction.none
    '        StitchButtonSelected()
    '        LblSelectMessage.Text = "Select area to flip"
    '    End Sub
    '    Private Sub BeginMirror()
    '        oCurrentAction = DesignAction.Mirror
    '        oCurrentStitchType = DesignAction.none
    '        StitchButtonSelected()
    '        LblSelectMessage.Text = "Select area to mirror"
    '    End Sub
    '    Private Sub StartTimer()
    '        ' Create a timer with a two second interval.
    '        aTimer = New System.Timers.Timer(200)
    '        ' Hook up the Elapsed event for the timer. 
    '        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
    '        aTimer.AutoReset = True
    '        aTimer.Enabled = True
    '    End Sub
    '    Private Sub StopTimer()
    '        aTimer.Enabled = False
    '    End Sub
    '    Private Sub OnTimedEvent()
    '        isThreadOn = Not isThreadOn
    '        _fromCellLocation_x = (oRemoveBackstitch.FromBlockLocation.X + iXOffset - topcorner.X) * iPixelsPerCell
    '        _fromCellLocation_y = (oRemoveBackstitch.FromBlockLocation.Y + iYOffset - topcorner.Y) * iPixelsPerCell
    '        _toCellLocation_x = (oRemoveBackstitch.ToBlockLocation.X + iXOffset - topcorner.X) * iPixelsPerCell
    '        _toCellLocation_y = (oRemoveBackstitch.ToBlockLocation.Y + iYOffset - topcorner.Y) * iPixelsPerCell

    '        _bsPen = New Pen(Color.White, oStitchPenWidth * oRemoveBackstitch.Strands)
    '        If isThreadOn Then
    '            _bsPen = New Pen(oRemoveBackstitch.ProjThread.Thread.Colour, oStitchPenWidth * oRemoveBackstitch.Strands)
    '        End If
    '        PicDesign.Invalidate()
    '    End Sub
    '#End Region
    '#Region "stitch subroutines"
    '    '
    '    '   Add stitches to design
    '    '
    '    Private Sub Add3QtrStitchTR(celLocation As Point)
    '        Dim _blockstitch As BlockStitch = AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
    '        _blockstitch.StitchType = BlockStitchType.ThreeQuarter
    '        _blockstitch.ThreadId = oCurrentThread.ThreadId
    '        _blockstitch.ProjectId = oProject.ProjectId
    '    End Sub
    '    Private Sub Add3QtrStitchTL(celLocation As Point)
    '        Dim _blockstitch As BlockStitch = AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    '        _blockstitch.StitchType = BlockStitchType.ThreeQuarter
    '        _blockstitch.ThreadId = oCurrentThread.ThreadId
    '        _blockstitch.ProjectId = oProject.ProjectId
    '    End Sub
    '    Private Sub Add3QtrStitchBR(celLocation As Point)
    '        Dim _blockstitch As BlockStitch = AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    '        _blockstitch.StitchType = BlockStitchType.ThreeQuarter
    '        _blockstitch.ThreadId = oCurrentThread.ThreadId
    '        _blockstitch.ProjectId = oProject.ProjectId
    '    End Sub
    Private Sub AddThreeQuarterStitch(pcell As Cell, pQtr As BlockQuarter)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing.WithStitchType(BlockStitchType.ThreeQuarter).WithProjectId(oProject.ProjectId).WithThreadId(oCurrentThread.ThreadId).WithStrandCount(2).WithBlockLocation(pcell.Position).WithQuarter(pQtr).Build
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch).Build

        'Dim _existing As BlockStitch = FindBlockstitch(pActionPoint)
        Dim _blockStitchQtrList As New List(Of BlockStitchQuarter)
        'For Each _bsq As BlockStitchQuarter In _existing.Quarters
        '    If Not _bsq.BlockQuarter = pQtr Then
        '        _blockStitchQtrList.Add(_bsq)
        '    End If
        'Next
        Select Case pQtr
            Case BlockQuarter.TopLeft
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopLeft, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopRight, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomLeft, 2, oCurrentThread.ThreadId))
            Case BlockQuarter.TopRight
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopLeft, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopRight, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomRight, 2, oCurrentThread.ThreadId))
            Case BlockQuarter.BottomLeft
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopLeft, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomRight, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomLeft, 2, oCurrentThread.ThreadId))
            Case BlockQuarter.BottomRight
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomRight, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.TopRight, 2, oCurrentThread.ThreadId))
                _blockStitchQtrList.Add(New BlockStitchQuarter(BlockQuarter.BottomLeft, 2, oCurrentThread.ThreadId))
        End Select
        _blockstitch.Quarters = _blockStitchQtrList
        DrawThreeQuarterBlockStitch(_blockstitch)

        'Dim _blockstitch As BlockStitch = AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        'AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
        'AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
        '_blockstitch.StitchType = BlockStitchType.ThreeQuarter
        '_blockstitch.ThreadId = oCurrentThread.ThreadId
        '_blockstitch.ProjectId = oProject.ProjectId
    End Sub
    '    Private Sub AddHalfBlockForwardStitch(celLocation As Point)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
    '        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    '    End Sub

    Private Sub AddHalfBlockStitch(pCell As Cell, isBack As Boolean)
        'AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        'AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing.WithStitchType(BlockStitchType.Half).WithProjectId(oProject.ProjectId).WithThreadId(oCurrentThread.ThreadId).WithStrandCount(2).WithBlockLocation(pCell.Position).Build
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch).Build

        DrawHalfBlockStitch(_blockstitch, isBack)
    End Sub
    Private Sub AddFullBlockStitch(pCell As Cell)
        '        Dim _existingStitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(FindBlockstitch(celLocation)).Build
        '        If _existingStitch.IsLoaded Then
        '            AddToUndoList(_existingStitch, UndoAction.Remove)
        '        End If
        '        Dim _blockstitch As BlockStitch = AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        '        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
        '        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
        '        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
        '        _blockstitch.StitchType = BlockStitchType.Full
        '        _blockstitch.ProjThread = Nothing
        '        _blockstitch.ThreadId = oCurrentThread.ThreadId
        '        _blockstitch.ProjectId = oProject.ProjectId
        '        AddToUndoList(_blockstitch, UndoAction.Add)
        '        BtnUndo.Enabled = True
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing.WithStitchType(BlockStitchType.Full).WithProjectId(oProject.ProjectId).WithThreadId(oCurrentThread.ThreadId).WithStrandCount(2).WithBlockLocation(pCell.Position).Build
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch).Build

        DrawFullBlockStitch(_blockstitch)
    End Sub
    Private Sub AddKnot(pCell As Cell, pIsBead As Boolean)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
            .WithStitchType(BlockStitchType.none) _
            .WithProjectId(oProject.ProjectId) _
            .WithThreadId(oCurrentThread.ThreadId) _
            .WithStrandCount(2) _
            .WithQuarter(pCell.KnotQtr).Build

        Dim _bead As Knot = KnotBuilder.AKnot.StartingWith(_stitch).WithKnotLocation(pCell.KnotCellPos) _
            .WithIsBead(pIsBead) _
            .Build
        DrawKnot(_bead)
    End Sub

    '    Private Sub AddBlockStitch(pDesign As ProjectDesign, pStitch As BlockStitch)
    '        RemoveExistingBlockStitch(pStitch.BlockLocation, pDesign)
    '        AddBlockStitchToDesign(pDesign, pStitch)
    '    End Sub
    '    Private Sub AddKnot(pDesign As ProjectDesign, pKnot As Knot)
    '        RemoveExistingKnot(pKnot.BlockLocation, pKnot.BlockQuarter, pDesign)
    '        AddKnotToDesign(pDesign, pKnot)
    '    End Sub
    '    Private Sub AddBackStitch(pDesign As ProjectDesign, pStitch As BackStitch)
    '        RemoveExistingBackStitch(pStitch.FromBlockLocation, pStitch.ToBlockLocation, pDesign)
    '        AddBackStitchToDesign(pDesign, pStitch)
    '    End Sub

    Private Sub AddQuarterBlockstitch(pCell As Cell, pQtr As BlockQuarter)
        Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing.WithStitchType(BlockStitchType.Quarter).WithProjectId(oProject.ProjectId).WithThreadId(oCurrentThread.ThreadId).WithStrandCount(2).WithBlockLocation(pCell.Position).Build
        Dim _blockstitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch).Build

        'Dim _existing As BlockStitch = FindBlockstitch(pActionPoint)
        Dim _blockStitchQtrList As New List(Of BlockStitchQuarter)
        'For Each _bsq As BlockStitchQuarter In _existing.Quarters
        '    If Not _bsq.BlockQuarter = pQtr Then
        '        _blockStitchQtrList.Add(_bsq)
        '    End If
        'Next

        _blockStitchQtrList.Add(New BlockStitchQuarter(pQtr, 2, oCurrentThread.ThreadId))
        _blockstitch.Quarters = _blockStitchQtrList
        DrawQuarterBlockStitch(_blockstitch)
    End Sub
    '    Private Sub AddKnot(pActionPoint As Point, pQtr As BlockQuarter, pIsBead As Boolean)
    '        Dim _exists = FindKnot(pActionPoint, pQtr)
    '        If _exists IsNot Nothing Then
    '            RemoveKnotFromDesign(oProjectDesign, _exists)
    '        End If
    '        Dim newBead As New Knot(pActionPoint, pQtr, 1, oCurrentThread.ThreadId, oProject.ProjectId, pIsBead)
    '        AddKnotToDesign(oProjectDesign, newBead)
    '    End Sub

    '    Private Function BackstitchMouseDown(pCellLocation As Point, pIsHalf As Boolean, pIsThick As Boolean) As Boolean
    '        Return BackstitchMouseDown(pCellLocation, BlockQuarter.TopLeft, pIsHalf, pIsThick)
    '    End Function
    '    Private Function BackstitchMouseDown(pCellLocation As Point, pQtr As BlockQuarter, pIsHalf As Boolean, pIsThick As Boolean) As Boolean
    '        Dim isEnded As Boolean = False
    '        If isBackstitchInProgress Then
    '            LogUtil.Debug("MouseDown backstitch in progress", MyBase.Name)
    '            EndBackstitch(pCellLocation, pQtr)
    '            isEnded = True
    '        Else
    '            LogUtil.Debug("MouseDown backstitch NOT in progress", MyBase.Name)
    '            StartBackstitch(pCellLocation, pQtr, pIsHalf, pIsThick)
    '        End If
    '        Return isEnded
    '    End Function
    '    Private Sub StartBackstitch(pCellLocation As Point, pIsHalf As Boolean, pIsThick As Boolean)
    '        StartBackstitch(pCellLocation, BlockQuarter.TopLeft, pIsHalf, pIsThick)
    '    End Sub
    '    Private Sub StartBackstitch(pCellLocation As Point, pQtr As BlockQuarter, pIsHalf As Boolean, pIsThick As Boolean)
    '        LogUtil.Debug("Starting backstitch", MyBase.Name)
    '        oBackstitchInProgress = New BackStitch(pCellLocation, pQtr, pCellLocation, pQtr, If(pIsThick, 2, 1), oCurrentThread.ThreadId, oProject.ProjectId)
    '        isBackstitchInProgress = True
    '        LogUtil.Debug("Backstitch IS in progress", MyBase.Name)
    '    End Sub
    '    Private Sub EndBackstitch(pCellLocation As Point)
    '        EndBackstitch(pCellLocation, BlockQuarter.TopLeft)
    '    End Sub
    '    Private Sub EndBackstitch(pCellLocation As Point, pQtr As BlockQuarter)
    '        LogUtil.Debug("Ending backstitch", MyBase.Name)
    '        If isBackstitchInProgress Then
    '            oBackstitchInProgress.ToBlockQuarter = pQtr
    '            oBackstitchInProgress.ToBlockLocation = pCellLocation
    '            AddBackStitchToDesign(oProjectDesign, BackstitchBuilder.ABackStitch.StartingWith(oBackstitchInProgress).Build)
    '            oBackstitchInProgress.FromBlockQuarter = pQtr
    '            oBackstitchInProgress.FromBlockLocation = pCellLocation
    '            DrawGrid(oProject, oProjectDesign)
    '            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '        Else
    '            LogUtil.Debug("Ending backstitch - error not in progress", MyBase.Name)
    '        End If
    '    End Sub
    '    Private Sub EndRemoveBackStitch()
    '        LogUtil.LogInfo("Ending remove backstich", MyBase.Name)
    '        isRemoveBackstitchInProgress = False
    '        DrawGrid(oProject, oProjectDesign)
    '        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    '    End Sub
    '    '
    '    '   Draw stitches
    '    '
    Private Sub DrawFullBlockStitch(pBlockStitch As BlockStitch)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = pBlockStitch.BlockLocation.X * iPixelsPerCell
        Dim pY As Integer = pBlockStitch.BlockLocation.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }

        Dim _cellLocation As New Point(pX, pY)
        oDesignGraphics.DrawLine(_crossPen, _tl, _br)
        oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        'Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay
        'If _stitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Or _stitchDisplayStyle = StitchDisplayStyle.BlackWhiteSymbols Then
        '    If pBlockStitch.StitchType = BlockStitchType.Full Then
        '        oDesignGraphics.DrawImage(MakeImage(pBlockStitch), _cellLocation)
        '    End If
        'End If
        _crossPen.Dispose()

    End Sub
    Private Sub DrawHalfBlockStitch(pBlockStitch As BlockStitch, pIsBack As Boolean)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = pBlockStitch.BlockLocation.X * iPixelsPerCell
        Dim pY As Integer = pBlockStitch.BlockLocation.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }

        Dim _cellLocation As New Point(pX, pY)
        If pIsBack Then
            oDesignGraphics.DrawLine(_crossPen, _tl, _br)
        Else
            oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If
        _crossPen.Dispose()

    End Sub
    Private Function MakeImage(pBlockStitch As BlockStitch) As Image
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Find(Function(p) p.Thread.ThreadId = pBlockStitch.ProjThread.ThreadId), ProjectThread)
        Dim _symbol As Symbol = GetSymbolById(_projectThread.SymbolId)
        Dim _image As Image = ImageUtil.ResizeImage(_symbol.SymbolImage, iPixelsPerCell, iPixelsPerCell)
        Return _image
    End Function

    Private Sub DrawThreeQuarterBlockStitch(pBlockstitch As BlockStitch)
        Dim _threadColour As Color = pBlockstitch.ProjThread.Thread.Colour
        Dim pX As Integer = pBlockstitch.BlockLocation.X * iPixelsPerCell
        Dim pY As Integer = pBlockstitch.BlockLocation.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)

        Dim _cellLocation As New Point(pX, pY)

        Dim _rectSize As Integer = Math.Floor(iPixelsPerCell / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _middlePoint As New Point(_middleX, _middleY)
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay
        'If _stitchDisplayStyle = StitchDisplayStyle.Crosses Then

        '     For Each _qtr As BlockStitchQuarter In pBlockstitch.Quarters

        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
        .StartCap = Drawing2D.LineCap.Round,
        .EndCap = Drawing2D.LineCap.Round
    }
        Select Case pBlockstitch.BlockQuarter
            Case BlockQuarter.TopLeft
                oDesignGraphics.DrawLine(_crossPen, _tl, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tr, _bl)

            Case BlockQuarter.TopRight
                oDesignGraphics.DrawLine(_crossPen, _tr, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tl, _br)
            Case BlockQuarter.BottomLeft
                oDesignGraphics.DrawLine(_crossPen, _bl, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tl, _br)
            Case BlockQuarter.BottomRight
                oDesignGraphics.DrawLine(_crossPen, _br, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End Select
        _crossPen.Dispose()
        '  Next

    End Sub


    Private Sub DrawQuarterBlockStitch(pBlockstitch As BlockStitch)
        Dim pX As Integer = pBlockstitch.BlockLocation.X * iPixelsPerCell
        Dim pY As Integer = pBlockstitch.BlockLocation.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)


        Dim _cellLocation As New Point(pX, pY)

        Dim _rectSize As Integer = Math.Floor(iPixelsPerCell / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay
        'If _stitchDisplayStyle = StitchDisplayStyle.Crosses Then

        For Each _qtr As BlockStitchQuarter In pBlockstitch.Quarters
            Dim _threadColour As Color = _qtr.Thread.Colour
            Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
            Select Case _qtr.BlockQuarter
                Case BlockQuarter.TopLeft
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY)
                Case BlockQuarter.TopRight
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + iPixelsPerCell, pY)
                Case BlockQuarter.BottomLeft
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY + iPixelsPerCell)
                Case BlockQuarter.BottomRight
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + iPixelsPerCell, pY + iPixelsPerCell)
            End Select
            _crossPen.Dispose()
        Next
        'End If
        'If _stitchDisplayStyle = StitchDisplayStyle.Blocks Or _stitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then

        '    Select Case pBlockQtr.BlockQuarter
        '        Case BlockQuarter.TopLeft

        '            oDesignGraphics.DrawRectangle(_blockPen, pX, pY, _rectSize, _rectSize)
        '            oDesignGraphics.FillRectangle(_brush, pX, pY, _rectSize, _rectSize)
        '        Case BlockQuarter.TopRight
        '            oDesignGraphics.DrawRectangle(_blockPen, pX + _rectSize, pY, _rectSize, _rectSize)
        '            oDesignGraphics.FillRectangle(_brush, pX + _rectSize, pY, _rectSize, _rectSize)
        '        Case BlockQuarter.BottomLeft
        '            oDesignGraphics.DrawRectangle(_blockPen, pX, pY + _rectSize, _rectSize, _rectSize)
        '            oDesignGraphics.FillRectangle(_brush, pX, pY + _rectSize, _rectSize, _rectSize)
        '        Case BlockQuarter.BottomRight
        '            oDesignGraphics.DrawRectangle(_blockPen, pX + _rectSize, pY + _rectSize, _rectSize, _rectSize)
        '            oDesignGraphics.FillRectangle(_brush, pX + _rectSize, pY + _rectSize, _rectSize, _rectSize)
        '    End Select
        'End If


    End Sub

    '    Private Sub DrawBackstitch(pBackstitch As BackStitch)
    '        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 16)
    '        Dim _fromCellLocation_x As Integer = (pBackstitch.FromBlockLocation.X * iPixelsPerCell)
    '        Dim _fromCellLocation_y As Integer = (pBackstitch.FromBlockLocation.Y * iPixelsPerCell)
    '        Dim _toCellLocation_x As Integer = (pBackstitch.ToBlockLocation.X * iPixelsPerCell)
    '        Dim _toCellLocation_y As Integer = (pBackstitch.ToBlockLocation.Y * iPixelsPerCell)
    '        Dim _pen As New Pen(pBackstitch.ProjThread.Thread.Colour, oStitchPenWidth * pBackstitch.Strands) With {
    '            .StartCap = Drawing2D.LineCap.Round,
    '            .EndCap = Drawing2D.LineCap.Round
    '        }
    '        Select Case pBackstitch.FromBlockQuarter
    '            Case BlockQuarter.TopRight
    '                _fromCellLocation_x += iPixelsPerCell / 2
    '            Case BlockQuarter.BottomLeft
    '                _fromCellLocation_y += iPixelsPerCell / 2
    '            Case BlockQuarter.BottomRight
    '                _fromCellLocation_x += iPixelsPerCell / 2
    '                _fromCellLocation_y += iPixelsPerCell / 2
    '        End Select
    '        Select Case pBackstitch.ToBlockQuarter
    '            Case BlockQuarter.TopRight
    '                _toCellLocation_x += iPixelsPerCell / 2
    '            Case BlockQuarter.BottomLeft
    '                _toCellLocation_y += iPixelsPerCell / 2
    '            Case BlockQuarter.BottomRight
    '                _toCellLocation_x += iPixelsPerCell / 2
    '                _toCellLocation_y += iPixelsPerCell / 2
    '        End Select
    '        oDesignGraphics.DrawLine(_pen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)

    '    End Sub
    '    Private Sub DrawBackstitchInProgress(pCell As Point, pCellQtr As BlockQuarter, pIsHalfStitch As Boolean)
    '        DrawBackstitchInProgress(pCell, pCellQtr, pIsHalfStitch, False)
    '    End Sub
    '    Private Sub DrawBackstitchInProgress(pCell As Point, pCellQtr As BlockQuarter, pIsHalfStitch As Boolean, pIsUseSelectColour As Boolean)
    '        LogUtil.Debug("Drawing backstitch in progress", MyBase.Name)
    '        Dim _qtrLocationAdjust As Integer = If(pIsHalfStitch, iPixelsPerCell / 2, iPixelsPerCell)
    '        oBackstitchInProgress.ToBlockQuarter = pCellQtr
    '        oBackstitchInProgress.ToBlockLocation = pCell
    '        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 16)
    '        _fromCellLocation_x = (oBackstitchInProgress.FromBlockLocation.X + iXOffset - topcorner.X) * iPixelsPerCell
    '        _fromCellLocation_y = (oBackstitchInProgress.FromBlockLocation.Y + iYOffset - topcorner.Y) * iPixelsPerCell
    '        _toCellLocation_x = (oBackstitchInProgress.ToBlockLocation.X + iXOffset - topcorner.X) * iPixelsPerCell
    '        _toCellLocation_y = (oBackstitchInProgress.ToBlockLocation.Y + iYOffset - topcorner.Y) * iPixelsPerCell
    '        Dim _bsPenColour As Color = If(pIsUseSelectColour, Color.Black, oBackstitchInProgress.ProjThread.Thread.Colour)
    '        _bsPen = New Pen(oBackstitchInProgress.ProjThread.Thread.Colour, oStitchPenWidth * oBackstitchInProgress.Strands) With {
    '            .StartCap = Drawing2D.LineCap.Round,
    '            .EndCap = Drawing2D.LineCap.Round
    '        }

    '        Select Case oBackstitchInProgress.FromBlockQuarter
    '            Case BlockQuarter.TopRight
    '                _fromCellLocation_x += _qtrLocationAdjust
    '            Case BlockQuarter.BottomLeft
    '                _fromCellLocation_y += _qtrLocationAdjust
    '            Case BlockQuarter.BottomRight
    '                _fromCellLocation_x += _qtrLocationAdjust
    '                _fromCellLocation_y += _qtrLocationAdjust
    '        End Select
    '        Select Case oBackstitchInProgress.ToBlockQuarter
    '            Case BlockQuarter.TopRight
    '                _toCellLocation_x += _qtrLocationAdjust
    '            Case BlockQuarter.BottomLeft
    '                _toCellLocation_y += _qtrLocationAdjust
    '            Case BlockQuarter.BottomRight
    '                _toCellLocation_x += _qtrLocationAdjust
    '                _toCellLocation_y += _qtrLocationAdjust
    '        End Select

    '        PicDesign.Invalidate()
    '    End Sub

    Private Sub DrawKnot(pKnot As Knot)
        Dim _knotlocation_x As Integer = (pKnot.BlockLocation.X * iPixelsPerCell) - (iPixelsPerCell / 4)
        Dim _knotlocation_y As Integer = (pKnot.BlockLocation.Y * iPixelsPerCell) - (iPixelsPerCell / 4)
        Select Case pKnot.BlockQuarter
            Case BlockQuarter.BottomLeft
                _knotlocation_y += iPixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _knotlocation_y += iPixelsPerCell / 2
                _knotlocation_x += iPixelsPerCell / 2
            Case BlockQuarter.TopRight
                _knotlocation_x += iPixelsPerCell / 2
        End Select
        Dim _rect As New Rectangle(_knotlocation_x, _knotlocation_y, iPixelsPerCell / 2, iPixelsPerCell / 2)

        oDesignGraphics.FillEllipse(New SolidBrush(pKnot.ProjThread.Thread.Colour), _rect)
    End Sub

    '    Private Sub RemoveKnotFromDesign(ByRef pDesign As ProjectDesign, pKnot As Knot)
    '        pDesign.Knots.Remove(pKnot)
    '        AddToUndoList(pKnot, UndoAction.Remove)
    '    End Sub
    '    Private Sub RemoveBlockStitchFromDesign(ByRef pDesign As ProjectDesign, pBlockstitch As BlockStitch)
    '        pDesign.BlockStitches.Remove(pBlockstitch)
    '        AddToUndoList(pBlockstitch, UndoAction.Remove)
    '    End Sub
    '    Private Sub RemoveBackStitchFromDesign(ByRef pDesign As ProjectDesign, pBackstitch As BackStitch)
    '        pDesign.BackStitches.Remove(pBackstitch)
    '        AddToUndoList(pBackstitch, UndoAction.Remove)
    '    End Sub
    '    Private Sub AddKnotToDesign(ByRef pDesign As ProjectDesign, pKnot As Knot)
    '        pDesign.Knots.Add(pKnot)
    '        AddToUndoList(pKnot, UndoAction.Add)
    '    End Sub
    '    Private Sub AddBlockStitchToDesign(ByRef pDesign As ProjectDesign, pBlockstitch As BlockStitch)
    '        pDesign.BlockStitches.Add(pBlockstitch)
    '        AddToUndoList(pBlockstitch, UndoAction.Add)
    '    End Sub
    '    Private Sub AddBackStitchToDesign(ByRef pDesign As ProjectDesign, pBackstitch As BackStitch)
    '        pDesign.BackStitches.Add(pBackstitch)
    '        AddToUndoList(pBackstitch, UndoAction.Add)
    '    End Sub
    '    Private Sub AddToUndoList(pStitch As Stitch, pAction As UndoAction)
    '        LogUtil.LogInfo("Add to undo for " & pStitch.ToString & " : " & pAction.ToString, MyBase.Name)
    '        oUndoList.Add(New StitchAction(pStitch, pAction))
    '        oRedoList.Clear()
    '        BtnUndo.Enabled = True
    '        BtnRedo.Enabled = False
    '    End Sub
    '#End Region
    '#Region "functions"
    '    Private Function FindKnot(pActionPoint As Point, pQtr As BlockQuarter) As Knot
    '        Dim _exists As Knot = Nothing
    '        For Each _knot As Knot In oProjectDesign.Knots
    '            If _knot.BlockLocation = pActionPoint AndAlso _knot.BlockQuarter = pQtr Then
    '                _exists = _knot
    '            End If
    '        Next
    '        Return _exists
    '    End Function

    '    Private Function FindBlockstitch(pActionPoint As Point) As BlockStitch
    '        Dim _found As BlockStitch = Nothing
    '        For Each _blockStitch As BlockStitch In oProjectDesign.BlockStitches
    '            If _blockStitch.BlockLocation = pActionPoint Then
    '                _found = _blockStitch
    '                Exit For
    '            End If
    '        Next
    '        If _found Is Nothing Then
    '            _found = BlockStitchBuilder.ABlockStitch.StartingWithNothing _
    '            .WithLocation(pActionPoint) _
    '            .WithQuarters(New List(Of BlockStitchQuarter)) _
    '            .Build
    '            AddBlockStitchToDesign(oProjectDesign, _found)
    '        End If
    '        Return _found
    '    End Function
    '    Private Sub RemoveExistingBlockStitch(pActionPoint As Point, pDesign As ProjectDesign)
    '        For Each _blockStitch As BlockStitch In pDesign.BlockStitches
    '            If _blockStitch.BlockLocation = pActionPoint Then
    '                RemoveBlockStitchFromDesign(pDesign, _blockStitch)
    '                Exit For
    '            End If
    '        Next
    '    End Sub
    '    Private Sub RemoveExistingBackStitch(pActionFromPoint As Point, pActionToPoint As Point, pDesign As ProjectDesign)
    '        For Each _backStitch As BackStitch In pDesign.BackStitches
    '            If _backStitch.FromBlockLocation = pActionFromPoint And _backStitch.ToBlockLocation = pActionToPoint Then
    '                RemoveBackStitchFromDesign(pDesign, _backStitch)
    '                Exit For
    '            End If
    '        Next
    '    End Sub
    '    Private Sub RemoveExistingKnot(pActionPoint As Point, pQtr As BlockQuarter, pDesign As ProjectDesign)
    '        For Each _knot As Knot In pDesign.Knots
    '            If _knot.BlockLocation = pActionPoint And _knot.BlockQuarter = pQtr Then
    '                RemoveKnotFromDesign(pDesign, _knot)
    '                Exit For
    '            End If
    '        Next
    '    End Sub

    '    Private Function FindBackstitches(pActionPoint As Point) As List(Of BackStitch)
    '        Dim _list As New List(Of BackStitch)
    '        For Each _backStitch As BackStitch In oProjectDesign.BackStitches
    '            If _backStitch.FromBlockLocation = pActionPoint Or _backStitch.ToBlockLocation = pActionPoint Then
    '                _list.Add(_backStitch)
    '            End If
    '        Next
    '        Return _list
    '    End Function
    '    Private Function GetPixelColour(e As MouseEventArgs) As Color
    '        Dim start_x As Integer = Math.Floor(e.X) + (topcorner.X - iXOffset) * iPixelsPerCell
    '        Dim start_y As Integer = Math.Floor(e.Y) + (topcorner.Y - iYOffset) * iPixelsPerCell
    '        Dim _colour As Color = Color.FromArgb(oProject.FabricColour)
    '        If start_x > 0 AndAlso start_x < oDesignBitmap.Width AndAlso start_y > 0 AndAlso start_y < oDesignBitmap.Height Then
    '            _colour = oDesignBitmap.GetPixel(start_x, start_y)
    '        End If
    '        Return _colour
    '    End Function
    '    Private Function FindQtrFromClickLocation(e As MouseEventArgs, ByRef pQtr As BlockQuarter) As Point
    '        Dim start_x As Integer = Math.Floor(e.X / iPixelsPerCell) - iXOffset + topcorner.X
    '        Dim start_y As Integer = Math.Floor(e.Y / iPixelsPerCell) - iYOffset + topcorner.Y

    '        Dim cel_x As Integer = (start_x) * iPixelsPerCell

    '        Dim cel_y As Integer = (start_y) * iPixelsPerCell

    '        Dim celLocation As New Point(cel_x, cel_y)

    '        Dim _xrmd As Integer = e.X Mod iPixelsPerCell
    '        Dim _yrmd As Integer = e.Y Mod iPixelsPerCell
    '        Select Case True
    '            Case (_xrmd >= 0 AndAlso _xrmd < iPixelsPerCell / 2) AndAlso (_yrmd >= 0 AndAlso _yrmd < iPixelsPerCell / 2)
    '                '    celLocation = New Point(cel_x, cel_y)
    '                pQtr = BlockQuarter.TopLeft
    '            Case _xrmd > iPixelsPerCell / 2 AndAlso _yrmd > iPixelsPerCell / 2
    '                '     celLocation = New Point(cel_x + (iPixelsPerCell / 2), cel_y + (iPixelsPerCell / 2))
    '                pQtr = BlockQuarter.BottomRight
    '            Case (_xrmd >= 0 AndAlso _xrmd < iPixelsPerCell / 2) AndAlso _yrmd > iPixelsPerCell / 2
    '                '     celLocation = New Point(cel_x, cel_y + (iPixelsPerCell / 2))
    '                pQtr = BlockQuarter.TopRight
    '            Case _xrmd > iPixelsPerCell / 2 AndAlso (_yrmd >= 0 AndAlso _yrmd < iPixelsPerCell / 2)
    '                '      celLocation = New Point(cel_x + (iPixelsPerCell / 2), cel_y)
    '                pQtr = BlockQuarter.BottomLeft
    '        End Select

    '        Return celLocation
    '    End Function

    '    Private Sub MnuClearSelection_Click(sender As Object, e As EventArgs) Handles MnuClearSelection.Click
    '        ClearSelection()
    '        DrawGrid(oProject, oProjectDesign)
    '        DisplayImage(oDesignBitmap, iXOffset, iYOffset)

    '    End Sub

    '    Private Sub ClearSelection()
    '        isSelectionInProgress = False
    '        isMoveInProgress = False
    '        oInProgressAnchor = New Point(0, 0)
    '        oInProgressTerminus = New Point(0, 0)
    '        '   oCurrentSelection = New Point() {}
    '        SelectionMessage(String.Empty)
    '    End Sub

    '    Private Sub FlowLayoutPanel1_SizeChanged(sender As Object, e As EventArgs) Handles ThreadLayoutPanel.SizeChanged
    '        InitialisePalette()
    '    End Sub

    '    Private Sub Stitches_CheckedChanged(sender As Object, e As EventArgs) Handles MnuBlockStitches.CheckedChanged,
    '                                                                                 MnuKnots.CheckedChanged,
    '                                                                                 MnuBackStitches.CheckedChanged
    '        SetStitchTypesSettings()
    '        If isInitialised AndAlso Not isLoading Then
    '            RedrawDesign()
    '        End If
    '    End Sub

#End Region

End Class