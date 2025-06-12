' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports HindlewareLib.Utilities
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmStitchDesign
#Region "constants"
    Private Const PIXELS_PER_CELL As Integer = 8
    Private Const MAG_STEP As Decimal = 1.3
    Private Const A4_WIDTH_PIXELS As Integer = 3508
    Private Const A4_HEIGHT_PIXELS As Integer = 2480
    ' image dots per inch
    Private Const DPI As Single = 300.0F
    ' font points per inch
    Private Const PPI As Integer = 72
    Private LINE_PEN As New Pen(Brushes.Black, 1)
    Private oStitchPenWidth As Single = 2
    Private oSelectionPenWidth As Single = 2
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
    Private oDesignGraphicsOverlay As Graphics
    Private oProjectDesign As ProjectDesign

    Private isLoading As Boolean
    Private leftmargin As Integer
    Private topmargin As Integer
    Private myPrintDoc As New Printing.PrintDocument

    Private magnification As Decimal

    Private iOneToOneSize As Size

    Private oCurrentAction As DesignAction
    Private oCurrentSelection(-1) As Point
    Private oCurrentSelectedBlockStitch As New List(Of BlockStitch)
    Private oCurrentSelectedKnot As New List(Of Knot)
    Private oCurrentSelectedBackstitch As New List(Of BackStitch)

    Private isBlockstitchAction As Boolean
    Private isBackstitchAction As Boolean
    Private isKnotAction As Boolean
    Private oCurrentThread As New Thread
    Private oProjectThreads As List(Of Thread)

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
    Private oNearestBackstitches As New List(Of BackStitch)
    Private oSelectedBackstitchIndex As Integer
    Private oSelectedBackstitchThread As Thread

    Dim _bsPen As New Pen(Brushes.Black)
    Dim _selPen As New Pen(Brushes.Black)
    Dim _fromCellLocation_x As Integer
    Dim _fromCellLocation_y As Integer
    Dim _toCellLocation_x As Integer
    Dim _toCellLocation_y As Integer
#End Region
#Region "enum"
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
        none
    End Enum
#End Region
#Region "form handlers"
    Private Sub FrmStitchDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening design", MyBase.Name)
        GetFormPos(Me, My.Settings.DesignFormPos)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _bsPen.Dispose()
        My.Settings.DesignFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmStitchDesign_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub
    Private Sub PicGrid_Click(sender As Object, e As EventArgs) Handles PicGrid.Click
        ToggleGrid()
    End Sub
    Private Sub Palette_Click(sender As Object, e As EventArgs)
        For Each _control As Control In FlowLayoutPanel1.Controls

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
        Dim _thread As Thread = CType(oProjectThreads.Find(Function(p) p.ThreadId = CInt(pPicBox.Name)), Thread)
        oCurrentThread = _thread
        PnlColor.BackColor = oCurrentThread.Colour
        LblCurrentColour.Text = oCurrentThread.ColourName & " : DMC " & CStr(oCurrentThread.ThreadNo)
    End Sub

    Private Sub MouseDownLeft(e As MouseEventArgs, pCell As Cell)
        If isSelectionInProgress Then
            '       MouseDownLeftSelecting(e, pCell)
        ElseIf isMoveInProgress Then
            MouseDownLeftMoving(e, pCell)
        Else
            MouseDownLeftNotSelecting(e, pCell)
        End If
    End Sub
    Private Sub MouseDownRight(e As MouseEventArgs, pCell As Cell)
        If isSelectionInProgress Or isMoveInProgress Then
            MouseDownRightSelecting()
        Else
        End If
    End Sub
    Private Sub MouseMoveLeft(e As MouseEventArgs, pCell As Cell)
        If isSelectionInProgress Then
            oInProgressTerminus = pCell.Position
            DrawSelectionInProgress(pCell.Position)
        End If
        If isMoveInProgress Then
            DrawSelectionInProgress(pCell.Position)
        End If
    End Sub
    Private Sub MouseMoveNone(e As MouseEventArgs, pCell As Cell)
        oPasteDestination = pCell.Position
        Dim _width As Integer = oInProgressTerminus.X - oInProgressAnchor.X - 1
        Dim _height As Integer = oInProgressTerminus.Y - oInProgressAnchor.Y - 1
        oSelectionPenWidth = Math.Max(2, iPpc / 16)
        _fromCellLocation_x = (oPasteDestination.X + iXOffset - topcorner.X) * iPpc
        _fromCellLocation_y = (oPasteDestination.Y + iYOffset - topcorner.Y) * iPpc
        _toCellLocation_x = (oPasteDestination.X + _width + iXOffset - topcorner.X) * iPpc
        _toCellLocation_y = (oPasteDestination.Y + _height + iYOffset - topcorner.Y) * iPpc
        Dim _selPenColour As Color = Color.Black
        _selPen = New Pen(_selPenColour, oStitchPenWidth)
        PicDesign.Invalidate()
    End Sub

    Private Sub MouseDownLeftNotSelecting(e As MouseEventArgs, pCell As Cell)
        Select Case oCurrentAction
            Case DesignAction.Copy
                StartSelection(pCell.Position)
            Case DesignAction.Paste
            Case DesignAction.Move
                StartSelection(pCell.Position)
            Case DesignAction.Cut
                StartSelection(pCell.Position)
        End Select
    End Sub

    Private Sub MouseDownLeftMoving(e As MouseEventArgs, pCell As Cell)
        Select Case oCurrentAction
            Case DesignAction.Copy
                EndCopy(pCell.Position)
            Case DesignAction.Paste
            Case DesignAction.Move
                RemoveSelectedCells()
                EndCopy(pCell.Position)
            Case DesignAction.Cut

        End Select
    End Sub
    Private Sub MouseDownRightSelecting()
        Select Case oCurrentAction
            Case DesignAction.Copy
                ClearSelection()
                oCurrentAction = DesignAction.none
            Case DesignAction.Paste
            Case DesignAction.Move
                ClearSelection()
                oCurrentAction = DesignAction.none
            Case DesignAction.Cut
        End Select
    End Sub
    Private Sub MouseUpLeftSelecting(e As MouseEventArgs, pCell As Cell)
        Select Case oCurrentAction
            Case DesignAction.Copy
                EndCopySelection(pCell.Position)
                StartMoveSelection()
            Case DesignAction.Paste
            Case DesignAction.Move
                EndCopySelection(pCell.Position)
                StartMoveSelection()
            Case DesignAction.Cut
                EndCopySelection(pCell.Position)
                RemoveSelectedCells()
                ClearSelection()
        End Select
    End Sub
    Private Sub MouseUpRightSelecting()
        Select Case oCurrentAction
            Case DesignAction.Copy
                ClearSelection()
                oCurrentAction = DesignAction.none
            Case DesignAction.Paste
            Case DesignAction.Move
            Case DesignAction.Cut
        End Select
    End Sub
    Private Sub EndCopySelection(pCellPosition As Point)
        oInProgressTerminus = pCellPosition
        oCurrentSelection = New Point() {oInProgressAnchor, oInProgressTerminus}
        GetSelectedCells()
        isSelectionInProgress = False
        SelectionMessage("Selection complete")
    End Sub
    Private Sub StartMoveSelection()
        isMoveInProgress = True
        SelectionMessage("Move in progress")
    End Sub
    Private Sub EndCopy(pCellPosition As Point)
        isMoveInProgress = False
        PasteSelectedCells(pCellPosition)
        ClearSelection()
        oCurrentAction = DesignAction.none
        DrawGrid(oProject, oProjectDesign)
        DisplayImage(oDesignBitmap)
    End Sub

    Private Sub RemoveSelectedCells()
        If oCurrentSelectedBlockStitch.Count > 0 Then
            For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                RemoveExistingBlockStitch(_bs.BlockLocation, oProjectDesign)
            Next
        End If
        If oCurrentSelectedKnot.Count > 0 Then
            For Each _knot As Knot In oCurrentSelectedKnot
                RemoveExistingKnot(_knot.BlockLocation, _knot.BlockQuarter, oProjectDesign)
            Next
        End If
        If oCurrentSelectedBackstitch.Count > 0 Then
            For Each _bkst As BackStitch In oCurrentSelectedBackstitch
                RemoveExistingBackStitch(_bkst.FromBlockLocation, _bkst.ToBlockLocation, oProjectDesign)
            Next
        End If
        DrawGrid(oProject, oProjectDesign)
        DisplayImage(oDesignBitmap)

    End Sub

    Private Sub PasteSelectedCells(pPosition As Point)
        Dim _xChange As Integer = pPosition.X - oInProgressAnchor.X
        Dim _yChange As Integer = pPosition.Y - oInProgressAnchor.Y
        Dim _newProjectDesign As ProjectDesign = oProjectDesign
        If oCurrentSelectedBlockStitch.Count > 0 Then
            For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                Dim _newBs As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_bs).WithLocation(New Point(_bs.BlockLocation.X + _xChange, _bs.BlockLocation.Y + _yChange)).Build
                AddBlockStitch(_newProjectDesign, _newBs)
            Next
        End If
        If oCurrentSelectedKnot.Count > 0 Then
            For Each _knot As Knot In oCurrentSelectedKnot
                Dim _newKnot As Knot = KnotBuilder.AKnot.StartingWith(_knot).WithBlockLocation(New Point(_knot.BlockLocation.X + _xChange, _knot.BlockLocation.Y + _yChange)).Build
                AddKnot(_newProjectDesign, _newKnot)
            Next
        End If
        If oCurrentSelectedBackstitch.Count > 0 Then
            For Each _bkst As BackStitch In oCurrentSelectedBackstitch
                Dim _newBkst As BackStitch = BackstitchBuilder.ABackStitch.StartingWith(_bkst) _
                        .WithFromBlockLocation(New Point(_bkst.FromBlockLocation.X + _xChange, _bkst.FromBlockLocation.Y + _yChange)) _
                        .WithToBlockLocation(New Point(_bkst.ToBlockLocation.X + _xChange, _bkst.ToBlockLocation.Y + _yChange)) _
                        .Build
                AddBackStitch(_newProjectDesign, _newBkst)
            Next
        End If
        oProjectDesign = _newProjectDesign
        DrawGrid(oProject, oProjectDesign)
        DisplayImage(oDesignBitmap)

    End Sub
    Private Sub PicDesign_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseDown
        Dim isImageChanged As Boolean = False
        Dim _cell As Cell = FindCellFromClickLocation(e)
        Select Case e.Button
            Case MouseButtons.Left
                MouseDownLeft(e, _cell)
            Case MouseButtons.Right
                MouseDownRight(e, _cell)
        End Select

        '======================================================================================
        Dim isRemove As Boolean = e.Button = MouseButtons.Right
        If isRemove Then
            LogUtil.Debug("Remove stitch", MyBase.Name)
            If isKnotAction Then
                LogUtil.Debug("Removing knot/bead", MyBase.Name)
                Dim _exists As Knot = FindKnot(_cell.KnotCellPos, _cell.KnotQtr)
                If _exists IsNot Nothing Then
                    oProjectDesign.Knots.Remove(_exists)
                    isImageChanged = True
                End If
            ElseIf isBackstitchAction Then

                If isBackstitchInProgress Then
                    LogUtil.Debug("Backstitch ending", MyBase.Name)
                    isBackstitchInProgress = False
                    oBackstitchInProgress = Nothing
                Else
                    LogUtil.Debug("Selecting backstitch to remove", MyBase.Name)
                    If isRemoveBackstitchInProgress Then

                    Else
                        isRemoveBackstitchInProgress = True
                        oNearestBackstitches = FindBackstitches(_cell.Position)
                        If oNearestBackstitches.Count > 0 Then
                            oSelectedBackstitchIndex = 0
                            oBackstitchInProgress = BackstitchBuilder.ABackStitch.StartingWith(oNearestBackstitches(oSelectedBackstitchIndex)).WithThread(oSelectedBackstitchThread).Build
                            DrawBackstitchInProgress(oBackstitchInProgress.ToBlockLocation, oBackstitchInProgress.ToBlockQuarter, True, True)
                        Else
                            oSelectedBackstitchIndex = -1
                        End If
                    End If
                End If
            ElseIf isBlockstitchAction Then
                LogUtil.Debug("Removing blockstitch", MyBase.Name)
                Dim _exists As BlockStitch = FindBlockstitch(_cell.Position)
                If _exists.IsLoaded Then
                    oProjectDesign.BlockStitches.Remove(_exists)
                    isImageChanged = True
                End If
            End If
        Else
            LogUtil.Debug("Create stitch", MyBase.Name)

            Select Case oCurrentAction
                Case DesignAction.BackstitchFullThick
                    BackstitchMouseDown(_cell.KnotCellPos, False, True)
                Case DesignAction.BackStitchFullThin
                    BackstitchMouseDown(_cell.KnotCellPos, False, False)
                Case DesignAction.BackstitchHalfThin
                    BackstitchMouseDown(_cell.KnotCellPos, _cell.KnotQtr, True, False)
                Case DesignAction.BackStitchHalfThick
                    BackstitchMouseDown(_cell.KnotCellPos, _cell.KnotQtr, True, True)
                Case DesignAction.Bead
                    AddKnot(_cell.KnotCellPos, _cell.KnotQtr, True)
                    isImageChanged = True
                Case DesignAction.Knot
                    AddKnot(_cell.KnotCellPos, _cell.KnotQtr, False)
                    isImageChanged = True
                Case DesignAction.FullBlockstitch
                    AddFullBlockStitch(_cell.Position)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchBack
                    AddHalfBlockBackStitch(_cell.Position)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchForward
                    AddHalfBlockForwardStitch(_cell.Position)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottomRight
                    AddQuarterBlockstitch(_cell.Position, BlockQuarter.BottomRight)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottonLeft
                    AddQuarterBlockstitch(_cell.Position, BlockQuarter.BottomLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopLeft
                    AddQuarterBlockstitch(_cell.Position, BlockQuarter.TopLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopRight
                    AddQuarterBlockstitch(_cell.Position, BlockQuarter.TopRight)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                    Add3QtrStitchBL(_cell.Position)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomRight
                    Add3QtrStitchBR(_cell.Position)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopLeft
                    Add3QtrStitchTL(_cell.Position)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopRight
                    Add3QtrStitchTR(_cell.Position)
                    isImageChanged = True
                Case DesignAction.BlockstitchQuarters
                    AddQuarterBlockstitch(_cell.Position, _cell.StitchQuarter)
                    isImageChanged = True
            End Select
        End If
        If isImageChanged Then
            DrawGrid(oProject, oProjectDesign)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
        End If
    End Sub
    Private Sub PicDesign_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseMove
        Dim _cell As Cell = FindCellFromClickLocation(e)

        Select Case e.Button
            Case MouseButtons.Left
                MouseMoveLeft(e, _cell)
            Case MouseButtons.None
                MouseMoveNone(e, _cell)
        End Select

        '==================================================================
        Dim isImageChanged As Boolean = False

        Dim _cellPos As Point = _cell.Position
        Dim _cellLocation As Point = _cell.Location
        Dim _cellQtr As BlockQuarter = _cell.StitchQuarter
        Dim _knotqtr As BlockQuarter = _cell.KnotQtr
        Dim _knotPos As Point = _cell.KnotCellPos

        LblCursorPos.Text = "X:" & CStr(_cellPos.X + 1) & ", Y:" & CStr(_cellPos.Y + 1)
        PnlPixelColour.BackColor = GetPixelColour(e)
        Dim _isColourFound As Boolean
        Dim _colourName As String = String.Empty
        For Each _thread As Thread In oProjectThreads
            If _thread.Colour = PnlPixelColour.BackColor Then
                _colourName = _thread.ColourName & " : DMC " & CStr(_thread.ThreadNo)
                _isColourFound = True
                Exit For
            End If
        Next

        LblPixelColourName.Text = _colourName
        If e.Button = MouseButtons.Right Then
            If oCurrentAction = DesignAction.Bead Or oCurrentAction = DesignAction.Knot Then
                LogUtil.Debug("Remove knot on the move", MyBase.Name)
                Dim _exists As Knot = FindKnot(_knotPos, _knotqtr)
                If _exists IsNot Nothing Then
                    oProjectDesign.Knots.Remove(_exists)
                    isImageChanged = True
                End If
            Else
                LogUtil.Debug("Remove blockstitch on the move", MyBase.Name)
                Dim _exists As BlockStitch = FindBlockstitch(_cellPos)
                If _exists.IsLoaded Then
                    oProjectDesign.BlockStitches.Remove(_exists)
                    isImageChanged = True
                End If
            End If
        End If

        If e.Button = MouseButtons.Left Then
            LogUtil.Debug("Adding stitch on the move", MyBase.Name)
            Select Case oCurrentAction
                Case DesignAction.Bead
                    AddKnot(_knotPos, _knotqtr, True)
                    isImageChanged = True
                Case DesignAction.Knot
                    AddKnot(_knotPos, _knotqtr, False)
                    isImageChanged = True
                Case DesignAction.FullBlockstitch
                    AddFullBlockStitch(_cellPos)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchBack
                    AddHalfBlockBackStitch(_cellPos)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchForward
                    AddHalfBlockForwardStitch(_cellPos)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottomRight
                    AddQuarterBlockstitch(_cellPos, BlockQuarter.BottomRight)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottonLeft
                    AddQuarterBlockstitch(_cellPos, BlockQuarter.BottomLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopLeft
                    AddQuarterBlockstitch(_cellPos, BlockQuarter.TopLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopRight
                    AddQuarterBlockstitch(_cellPos, BlockQuarter.TopRight)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                    Add3QtrStitchBL(_cellPos)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomRight
                    Add3QtrStitchBR(_cellPos)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopLeft
                    Add3QtrStitchTL(_cellPos)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopRight
                    Add3QtrStitchTR(_cellPos)
                    isImageChanged = True
                Case DesignAction.BlockstitchQuarters
                    AddQuarterBlockstitch(_cellPos, _cellQtr)
                    isImageChanged = True
            End Select

        End If
        If e.Button = MouseButtons.None Then
            If isSelectionInProgress Then
                DrawSelectionInProgress(_cellPos)
            End If
            If isBackstitchInProgress Then
                Select Case oCurrentAction
                    Case DesignAction.BackstitchFullThick
                        DrawBackstitchInProgress(_knotPos, BlockQuarter.TopLeft, False)

                    Case DesignAction.BackStitchFullThin
                        DrawBackstitchInProgress(_knotPos, BlockQuarter.TopLeft, False)

                    Case DesignAction.BackstitchHalfThin
                        DrawBackstitchInProgress(_knotPos, _knotqtr, True)

                    Case DesignAction.BackStitchHalfThick
                        DrawBackstitchInProgress(_knotPos, _knotqtr, True)

                End Select
            End If
        End If
        If isImageChanged Then
            LogUtil.Debug("Drawing changes after move", MyBase.Name)
            DrawGrid(oProject, oProjectDesign)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
        End If
    End Sub
    Private Sub PicDesign_SizeChanged(sender As Object, e As EventArgs) Handles PicDesign.SizeChanged
        If Not isLoading Then
            If oProject IsNot Nothing AndAlso oProjectDesign IsNot Nothing AndAlso oProject.IsLoaded AndAlso oProjectDesign.IsLoaded Then
                DisplayImage(oDesignBitmap)
            End If
        End If
    End Sub
    Private Sub PicDesign_Paint(sender As Object, e As PaintEventArgs) Handles PicDesign.Paint
        Dim rect As Rectangle
        Dim picx As Single = iPpc * topcorner.X
        Dim picy As Single = iPpc * topcorner.Y
        Dim picw As Single = oDesignBitmap.Width - picx
        Dim pich As Single = oDesignBitmap.Height - picy
        Dim atX As Single = iXOffset * iPpc
        Dim atY As Single = iYOffset * iPpc
        rect = New Rectangle(picx, picy, picw, pich)

        e.Graphics.DrawImage(oDesignBitmap, atX, atY, rect, GraphicsUnit.Pixel)
        If isBackstitchInProgress Then
            e.Graphics.DrawLine(_bsPen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
        End If
        If isSelectionInProgress Or isMoveInProgress Then
            Dim _width As Integer = _toCellLocation_x - _fromCellLocation_x + iPpc
            Dim _height As Integer = _toCellLocation_y - _fromCellLocation_y + iPpc
            e.Graphics.DrawRectangle(_selPen, _fromCellLocation_x, _fromCellLocation_y, _width, _height)
        End If

    End Sub
    Private Sub HScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        If Not isLoading Then
            Dim _h_change As Integer = (iOldHScrollbarValue - HScrollBar1.Value)
            Dim _newOff_x As Integer = iXOffset + _h_change - topcorner.X
            SetValuesAfterHorizontalChange(_newOff_x)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
            iOldHScrollbarValue = HScrollBar1.Value
        End If
    End Sub
    Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        If Not isLoading Then

            Dim _v_change As Integer = (iOldVScrollbarValue - VScrollBar1.Value)
            Dim _newOff_y As Integer = iYOffset + _v_change - topcorner.Y

            SetValuesAfterVerticalChange(_newOff_y)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
            iOldVScrollbarValue = VScrollBar1.Value

        End If
    End Sub
    Private Sub MnuZoomIn_Click(sender As Object, e As EventArgs) Handles MnuZoomIn.Click
        IncreaseMagnification()
    End Sub
    Private Sub MnuStitchDisplayStyle_Click(sender As Object, e As EventArgs) Handles MnuStitchDisplayStyle.Click
        Using _stitchStyle As New FrmStitchDisplayStyle
            _stitchStyle.ShowDialog()
        End Using
        RedrawDesign()
        InitialisePalette()
    End Sub

#End Region
#Region "thread buttons"
    Private Sub BtnFullStitch_Click(sender As Object, e As EventArgs) Handles BtnFullStitch.Click
        SelectFullBlockstitch()
    End Sub

    Private Sub SelectFullBlockstitch()
        oCurrentAction = DesignAction.FullBlockstitch
        StitchButtonSelected()
        BtnFullStitch.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.fullcross
    End Sub

    Private Sub Btn3QtrsTL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTL.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchTopLeft
        StitchButtonSelected()
        Btn3QtrsTL.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources._3qtrstl

    End Sub

    Private Sub Btn3QtrsTR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTR.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchTopRight
        StitchButtonSelected()
        Btn3QtrsTR.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources._3qtrstr
    End Sub

    Private Sub Btn3QtrsBR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBR.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchBottomRight
        StitchButtonSelected()
        Btn3QtrsBR.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources._3qtrsbr
    End Sub

    Private Sub Btn3QtrsBL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBL.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchBottomLeft
        StitchButtonSelected()
        Btn3QtrsBL.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources._3qtrsbl
    End Sub

    Private Sub BtnHalfForward_Click(sender As Object, e As EventArgs) Handles BtnHalfForward.Click
        oCurrentAction = DesignAction.HalfBlockstitchForward
        StitchButtonSelected()
        BtnHalfForward.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.halffwd
    End Sub

    Private Sub BtnHalfBack_Click(sender As Object, e As EventArgs) Handles BtnHalfBack.Click
        oCurrentAction = DesignAction.HalfBlockstitchBack
        StitchButtonSelected()
        BtnHalfBack.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.halfback
    End Sub

    Private Sub BtnQtrTL_Click(sender As Object, e As EventArgs) Handles BtnQtrTL.Click
        oCurrentAction = DesignAction.QuarterBlockstitchTopLeft
        StitchButtonSelected()
        BtnQtrTL.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.qtrtl
    End Sub

    Private Sub BtnQWtrTR_Click(sender As Object, e As EventArgs) Handles BtnQtrTR.Click
        oCurrentAction = DesignAction.QuarterBlockstitchTopRight
        StitchButtonSelected()
        BtnQtrTR.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.qtrtr
    End Sub

    Private Sub BtnQtrBR_Click(sender As Object, e As EventArgs) Handles BtnQtrBR.Click
        oCurrentAction = DesignAction.QuarterBlockstitchBottomRight
        StitchButtonSelected()
        BtnQtrBR.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.qtrbr
    End Sub

    Private Sub BtnQtrBL_Click(sender As Object, e As EventArgs) Handles BtnQtrBL.Click
        oCurrentAction = DesignAction.QuarterBlockstitchBottonLeft
        StitchButtonSelected()
        BtnQtrBL.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.qtrbl
    End Sub

    Private Sub BtnQuarters_Click(sender As Object, e As EventArgs) Handles BtnQuarters.Click
        oCurrentAction = DesignAction.BlockstitchQuarters
        StitchButtonSelected()
        BtnQuarters.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.quarters
    End Sub

    Private Sub BtnFullBackstitchThin_Click(sender As Object, e As EventArgs) Handles BtnFullBackstitchThin.Click
        oCurrentAction = DesignAction.BackStitchFullThin
        StitchButtonSelected()
        BtnFullBackstitchThin.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.fullthinbs
    End Sub

    Private Sub BtnHalfBackStitchThin_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThin.Click
        oCurrentAction = DesignAction.BackstitchHalfThin
        StitchButtonSelected()
        BtnHalfBackStitchThin.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.halfthinbs
    End Sub

    Private Sub BtnFullBackStitchThick_Click(sender As Object, e As EventArgs) Handles BtnFullBackStitchThick.Click
        oCurrentAction = DesignAction.BackstitchFullThick
        StitchButtonSelected()
        BtnFullBackStitchThick.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.fullthickbs
    End Sub

    Private Sub BtnHalfBackStitchThick_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThick.Click
        oCurrentAction = DesignAction.BackStitchHalfThick
        StitchButtonSelected()
        BtnHalfBackStitchThick.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.halfthickbs
    End Sub

    Private Sub BtnKnot_Click(sender As Object, e As EventArgs) Handles BtnKnot.Click
        oCurrentAction = DesignAction.Knot
        StitchButtonSelected()
        BtnKnot.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.knot
    End Sub

    Private Sub BtnBead_Click(sender As Object, e As EventArgs) Handles BtnBead.Click
        oCurrentAction = DesignAction.Bead
        StitchButtonSelected()
        BtnBead.BackgroundImage = My.Resources.BtnBkgrdDown
        PicStitch.Image = My.Resources.Bead
    End Sub
#End Region
#Region "action buttons"
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim _filename As String = MakeFilename(oProject)
        SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        BeginCopy()
    End Sub

    Private Sub BtnCut_Click(sender As Object, e As EventArgs) Handles BtnCut.Click
        oCurrentAction = DesignAction.Cut
    End Sub

    Private Sub BtnMove_Click(sender As Object, e As EventArgs) Handles BtnMove.Click
        oCurrentAction = DesignAction.Move
    End Sub

    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        LblSelectMessage.Text = "Select location to paste"
        oCurrentAction = DesignAction.Paste
    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles BtnUndo.Click

    End Sub

    Private Sub BtnRedo_Click(sender As Object, e As EventArgs) Handles BtnRedo.Click

    End Sub

    Private Sub BtnZoom_Click(sender As Object, e As EventArgs) Handles BtnZoom.Click

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
        isLoading = False
    End Sub
    Private Sub BtnHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeight.Click
        isLoading = True
        ChangeMagnification(1)
        Dim _newPpc As Decimal = PicDesign.Height / oProjectDesign.Rows
        Dim _heightRatio As Decimal = _newPpc / PIXELS_PER_CELL
        ChangeMagnification(_heightRatio)
        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
        '     DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub
    Private Sub BtnWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWidth.Click
        isLoading = True
        ChangeMagnification(1)
        Dim _newPpc As Decimal = PicDesign.Width / oProjectDesign.Columns
        Dim _widthRatio As Decimal = _newPpc / PIXELS_PER_CELL
        ChangeMagnification(_widthRatio)
        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
        '      DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub
#End Region
#Region "menus"
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuSaveDesign.Click
        Dim _filename As String = MakeFilename(oProject)
        LogUtil.Info("Saving design", MyBase.Name)
        SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
        LogUtil.Info("Design saved to " & _filename, MyBase.Name)
    End Sub

    Private Sub MnuOpenDesign_Click(sender As Object, e As EventArgs) Handles MnuOpenDesign.Click

    End Sub
    Private Sub MnuThreads_Click(sender As Object, e As EventArgs) Handles MnuThreads.Click
        If oProject.ProjectId > 0 Then
            LogUtil.Info("Opening Project Threads form", MyBase.Name)
            Using _projthreads As New FrmProjectThreads
                _projthreads.SelectedProject = oProject
                _projthreads.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub MnuThreadSymbols_Click(sender As Object, e As EventArgs) Handles MnuThreadSymbols.Click
        If oProject.ProjectId > 0 Then
            LogUtil.Info("Opening Project Thread Symbols form", MyBase.Name)
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

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
        Close()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuSaveDesignAs.Click
        LogUtil.Info("Getting filename for save", MyBase.Name)
        Dim _filename As String = FileUtil.GetFileName(FileUtil.OpenOrSave.Save, FileUtil.FileType.HSZ, My.Settings.DesignFilePath)
        If Not String.IsNullOrEmpty(_filename) Then
            LogUtil.Info("Saving design", MyBase.Name)
            SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
            LogUtil.Info("Design saved to " & _filename, MyBase.Name)
        End If
    End Sub

    Private Sub MnuSelectPaletteColours_Click(sender As Object, e As EventArgs) Handles MnuSelectPaletteColours.Click

    End Sub

    Private Sub MnuRemoveUnusedColours_Click(sender As Object, e As EventArgs) Handles MnuRemoveUnusedColours.Click

    End Sub

    Private Sub MnuCreateThreadCards_Click(sender As Object, e As EventArgs) Handles MnuCreateThreadCards.Click

    End Sub

    Private Sub MnuPrintThreadCards_Click(sender As Object, e As EventArgs) Handles MnuPrintThreadCards.Click

    End Sub

    Private Sub MnuCopySelection_Click(sender As Object, e As EventArgs) Handles MnuCopySelection.Click
        BeginCopy()
    End Sub

    Private Sub MnuMoveSelection_Click(sender As Object, e As EventArgs) Handles MnuMoveSelection.Click
        oCurrentAction = DesignAction.Move
    End Sub

    Private Sub MnuCutSelection_Click(sender As Object, e As EventArgs) Handles MnuCutSelection.Click
        oCurrentAction = DesignAction.Cut
    End Sub

    Private Sub MnuPaste_Click(sender As Object, e As EventArgs) Handles MnuPaste.Click
        LblSelectMessage.Text = "Select location to paste"
        oCurrentAction = DesignAction.Paste
    End Sub

    Private Sub FlipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuFlipSelection.Click

    End Sub

    Private Sub MirrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuMirrorSelection.Click

    End Sub

    Private Sub RotateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuRotate.Click

    End Sub

    Private Sub ClearAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuClearArea.Click

    End Sub

    Private Sub DrawShapeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuDrawShape.Click

    End Sub

    Private Sub DrawFilledShapeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuDrawFilledShape.Click

    End Sub

    Private Sub FloodFillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuFloodFill.Click

    End Sub

    Private Sub RedrawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuRedraw.Click
        RedrawDesign()
    End Sub

    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuZoom.Click

    End Sub

    Private Sub CropToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuCropDesign.Click

    End Sub

    Private Sub ExtendToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuExtendDesign.Click

    End Sub

    Private Sub MnuShowDesignStats_Click(sender As Object, e As EventArgs) Handles MnuShowDesignStats.Click

    End Sub

    Private Sub MnuOptions_Click(sender As Object, e As EventArgs) Handles MnuOptions.Click
        Using _options As New FrmOptions
            _options.ShowDialog()
        End Using
    End Sub

#End Region
#Region "subroutines"
    '   Initialise
    Private Sub InitialiseForm()
        oProject = GetProjectById(oProjectId)
        SetGridImage()
        oSelectedBackstitchThread = ThreadBuilder.AThread.StartingWithNothing.WithColour(Color.Black).Build
        SelectFullBlockstitch()
        SetCurrentActionClass()
        PnlColor.BackColor = SystemColors.Control
        If oProject.IsLoaded Then
            oProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(My.Settings.DesignFilePath, MakeFilename(oProject)).Build
            If Not oProjectDesign.IsLoaded Then
                oProjectDesign.Rows = oProject.DesignHeight
                oProjectDesign.Columns = oProject.DesignWidth
            End If
            InitialisePalette()
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

            'Draw grid onto graphics
            DrawGrid(oProject, oProjectDesign)
            CalculateOffsetForCentre(oDesignBitmap)

            iOldHScrollbarValue = HScrollBar1.Value
            iOldVScrollbarValue = VScrollBar1.Value

        Else
            MsgBox("No project found", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If

    End Sub
    Private Sub SetCurrentActionClass()

        isKnotAction = oCurrentAction = DesignAction.Knot Or
                        oCurrentAction = DesignAction.Bead
        isBackstitchAction = oCurrentAction = DesignAction.BackStitchFullThin Or
                                oCurrentAction = DesignAction.BackstitchFullThick Or
                                oCurrentAction = DesignAction.BackstitchHalfThin Or
                                oCurrentAction = DesignAction.BackStitchHalfThick
        isBlockstitchAction = oCurrentAction = DesignAction.FullBlockstitch Or
                                oCurrentAction = DesignAction.HalfBlockstitchBack Or
                                oCurrentAction = DesignAction.HalfBlockstitchForward Or
                                oCurrentAction = DesignAction.QuarterBlockstitchBottomRight Or
                                oCurrentAction = DesignAction.QuarterBlockstitchBottonLeft Or
                                oCurrentAction = DesignAction.QuarterBlockstitchTopLeft Or
                                oCurrentAction = DesignAction.QuarterBlockstitchTopRight Or
                                oCurrentAction = DesignAction.ThreeQuarterBlockstitchBottomLeft Or
                                oCurrentAction = DesignAction.ThreeQuarterBlockstitchBottomRight Or
                                oCurrentAction = DesignAction.ThreeQuarterBlockstitchTopLeft Or
                                oCurrentAction = DesignAction.ThreeQuarterBlockstitchTopRight Or
                                oCurrentAction = DesignAction.BlockstitchQuarters
    End Sub
    Private Sub InitialisePalette()
        FlowLayoutPanel1.Controls.Clear()
        Dim _projectThreads As List(Of ProjectThread) = GetProjectThreads(oProject.ProjectId)
        _projectThreads.Sort(Function(x As ProjectThread, y As ProjectThread) x.Thread.SortNumber.CompareTo(y.Thread.SortNumber))
        oProjectThreads = New List(Of Thread)
        Dim _firstPicThread As PictureBox = Nothing
        For Each _projectThread As ProjectThread In _projectThreads
            Dim _thread As Thread = _projectThread.Thread
            oProjectThreads.Add(_thread)
            Dim _picThread As New PictureBox()
            With _picThread
                .Name = CStr(_thread.ThreadId)
                .Size = New Size(50, 50)
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
            FlowLayoutPanel1.Controls.Add(_picThread)
            _firstPicThread = If(_firstPicThread, _picThread)
        Next
        SelectPaletteColour(_firstPicThread)
    End Sub
    ' Scrollbars
    Private Sub CalculateScrollBarValues()
        HScrollBar1.Value = oProjectDesign.Columns - 1 + iXOffset - topcorner.X
        VScrollBar1.Value = oProjectDesign.Rows - 1 + iYOffset - topcorner.Y
    End Sub
    Private Sub CalculateScrollBarMaximumValues()
        HScrollBar1.Maximum = (PicDesign.Width / iPpc) + (oProjectDesign.Columns) + 7
        VScrollBar1.Maximum = (PicDesign.Height / iPpc) + (oProjectDesign.Rows) + 7
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
        magnification = pNewValue
        iPpc = Math.Floor(PIXELS_PER_CELL * magnification)
        iOneToOneSize = New Size(oProjectDesign.Columns * iPpc, oProjectDesign.Rows * iPpc)
        CalculateScrollBarMaximumValues()
    End Sub
    Private Sub IncreaseMagnification()
        isLoading = True
        ChangeMagnification(Math.Round(magnification * MAG_STEP, 2, MidpointRounding.AwayFromZero))
        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
    End Sub
    Private Sub DecreaseMagnification()
        isLoading = True
        ChangeMagnification(Math.Round(magnification / MAG_STEP, 2, MidpointRounding.AwayFromZero))

        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
    End Sub
    Private Sub CalculateOffsetForCentre(pDesignBitmap)
        Dim x As Integer = (PicDesign.Width - pDesignBitmap.Width) / (2 * iPpc)
        Dim y As Integer = (PicDesign.Height - pDesignBitmap.Height) / (2 * iPpc)
        SetValuesAfterHorizontalChange(x)
        SetValuesAfterVerticalChange(y)
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
        CalculateScrollBarValues()
        iOldHScrollbarValue = HScrollBar1.Value
        iOldVScrollbarValue = VScrollBar1.Value
    End Sub
    Private Sub RedrawDesign()
        DrawGrid(oProject, oProjectDesign)
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub
    Private Sub DrawGrid(ByRef pProject As Project, ByRef pProjectDesign As ProjectDesign)

        ' Create image the size of the design

        oDesignBitmap = New Bitmap(CInt(oProjectDesign.Columns * iPpc), CInt(oProjectDesign.Rows * iPpc))
        '   oDesignBitmap.SetResolution(DPI, DPI)

        'Create graphics from image
        oDesignGraphics = Graphics.FromImage(oDesignBitmap)
        oDesignGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim _widthInColumns As Integer = pProjectDesign.Columns
        Dim _heightInRows As Integer = pProjectDesign.Rows
        Dim gap As Integer = iPpc
        Dim wct As Integer = oDesignBitmap.Width / gap
        Dim _fabricColour As Color = Color.FromArgb(pProject.FabricColour)
        Dim _fabricBrush As New SolidBrush(_fabricColour)
        Dim _designBorderPen As New Pen(Brushes.Black, 2)

        oDesignGraphics.FillRectangle(_fabricBrush, New Rectangle(0, 0, oDesignBitmap.Width, oDesignBitmap.Height))
        If My.Settings.isGridOn Then
            Dim _penWidth As Integer
            Dim _penColor As Brush
            For x = 0 To _widthInColumns
                _penWidth = 1
                _penColor = Brushes.LightGray
                oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 0 To _heightInRows
                _penWidth = 1
                _penColor = Brushes.LightGray
                oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
            For x = 5 To _widthInColumns Step 10
                _penWidth = 1
                _penColor = Brushes.DarkGray
                oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 5 To _heightInRows Step 10
                _penWidth = 1
                _penColor = Brushes.DarkGray
                oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
            For x = 10 To _widthInColumns Step 10
                _penWidth = 1
                _penColor = Brushes.Black
                oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 10 To _heightInRows Step 10
                _penWidth = 1
                _penColor = Brushes.Black
                oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
        End If
        oDesignGraphics.DrawRectangle(_designBorderPen, New Rectangle(0, 0, Math.Min(gap * _widthInColumns, oDesignBitmap.Width), Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
        If oCurrentSelection.Length > 0 Then
            Dim _width As Integer = (oCurrentSelection(1).X - oCurrentSelection(0).X) * iPpc
            Dim _height As Integer = (oCurrentSelection(1).Y - oCurrentSelection(0).Y) * iPpc
            oDesignGraphics.DrawRectangle(_selPen, oCurrentSelection(0).X * iPpc, oCurrentSelection(0).Y * iPpc, _width, _height)
        End If
        FillGrid()
    End Sub
    Private Sub FillGrid()
        For Each _blockstitch In oProjectDesign.BlockStitches
            DrawBlockStitch(_blockstitch)
        Next
        For Each _backstitch In oProjectDesign.BackStitches
            DrawBackstitch(_backstitch)
        Next
        For Each _knot As Knot In oProjectDesign.Knots
            DrawKnot(_knot)
        Next
    End Sub
    Private Sub ToggleGrid()
        My.Settings.isGridOn = Not My.Settings.isGridOn
        My.Settings.Save()
        SetGridImage()
        DrawGrid(oProject, oProjectDesign)
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub
    Private Sub SetGridImage()
        MnuGridOn.Checked = My.Settings.isGridOn
        If My.Settings.isGridOn Then
            PicGrid.Image = My.Resources.gridon
        Else
            PicGrid.Image = My.Resources.gridoff
        End If
    End Sub
    Private Sub DisplayImage(pImage As Bitmap)
        DisplayImage(pImage, 0, 0)
    End Sub
    Private Sub DisplayImage(pImage As Bitmap, pX As Integer, pY As Integer)

        Dim rect As Rectangle
        Dim picx As Single = iPpc * topcorner.X
        Dim picy As Single = iPpc * topcorner.Y
        Dim picw As Single = oDesignBitmap.Width - picx
        Dim pich As Single = oDesignBitmap.Height - picy
        Dim atX As Single = pX * iPpc
        Dim atY As Single = pY * iPpc

        rect = New Rectangle(picx, picy, picw, pich)
        Dim myfg As Graphics = PicDesign.CreateGraphics
        myfg.Clear(PicDesign.BackColor)

        Try
            myfg.DrawImage(pImage, atX, atY, rect, GraphicsUnit.Pixel)
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
        SetCurrentActionClass()
        BtnFullStitch.BackgroundImage = My.Resources.BtnBkgrd
        BtnHalfBack.BackgroundImage = My.Resources.BtnBkgrd
        BtnHalfForward.BackgroundImage = My.Resources.BtnBkgrd
        Btn3QtrsBL.BackgroundImage = My.Resources.BtnBkgrd
        Btn3QtrsBR.BackgroundImage = My.Resources.BtnBkgrd
        Btn3QtrsTL.BackgroundImage = My.Resources.BtnBkgrd
        Btn3QtrsTR.BackgroundImage = My.Resources.BtnBkgrd
        BtnQtrBL.BackgroundImage = My.Resources.BtnBkgrd
        BtnQtrBR.BackgroundImage = My.Resources.BtnBkgrd
        BtnQtrTL.BackgroundImage = My.Resources.BtnBkgrd
        BtnQtrTR.BackgroundImage = My.Resources.BtnBkgrd
        BtnQuarters.BackgroundImage = My.Resources.BtnBkgrd
        BtnFullBackstitchThin.BackgroundImage = My.Resources.BtnBkgrd
        BtnFullBackStitchThick.BackgroundImage = My.Resources.BtnBkgrd
        BtnHalfBackStitchThick.BackgroundImage = My.Resources.BtnBkgrd
        BtnHalfBackStitchThin.BackgroundImage = My.Resources.BtnBkgrd
        BtnKnot.BackgroundImage = My.Resources.BtnBkgrd
        BtnBead.BackgroundImage = My.Resources.BtnBkgrd

    End Sub

    'Mouse Down
    Private Sub CopySelectMouseDown(pPosition As Point)
        If isSelectionInProgress Then
            LogUtil.Debug("MouseDown selection in progress", MyBase.Name)
            EndSelection(pPosition)
        Else
            LogUtil.Debug("MouseDown selection NOT in progress", MyBase.Name)
            StartSelection(pPosition)
        End If
    End Sub
    Private Sub CutSelectMouseDown(pPosition As Point)
        If isSelectionInProgress Then
            LogUtil.Debug("MouseDown selection in progress", MyBase.Name)
            EndSelection(pPosition)
        Else
            LogUtil.Debug("MouseDown selection NOT in progress", MyBase.Name)
            StartSelection(pPosition)
        End If
    End Sub
    Private Sub PasteMouseDown(pPosition As Point)
        If oCurrentSelection.Length > 0 Then
            Dim _xChange As Integer = pPosition.X - oCurrentSelection(0).X
            Dim _yChange As Integer = pPosition.Y - oCurrentSelection(0).Y
            Dim _newProjectDesign As ProjectDesign = oProjectDesign
            If oCurrentSelectedBlockStitch.Count > 0 Then
                For Each _bs As BlockStitch In oCurrentSelectedBlockStitch
                    Dim _newBs As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_bs).WithLocation(New Point(_bs.BlockLocation.X + _xChange, _bs.BlockLocation.Y + _yChange)).Build
                    AddBlockStitch(_newProjectDesign, _newBs)
                Next
            End If
            If oCurrentSelectedKnot.Count > 0 Then
                For Each _knot As Knot In oCurrentSelectedKnot
                    Dim _newKnot As Knot = KnotBuilder.AKnot.StartingWith(_knot).WithBlockLocation(New Point(_knot.BlockLocation.X + _xChange, _knot.BlockLocation.Y + _yChange)).Build
                    AddKnot(_newProjectDesign, _newKnot)
                Next
            End If
            If oCurrentSelectedBackstitch.Count > 0 Then
                For Each _bkst As BackStitch In oCurrentSelectedBackstitch
                    Dim _newBkst As BackStitch = BackstitchBuilder.ABackStitch.StartingWith(_bkst) _
                        .WithFromBlockLocation(New Point(_bkst.FromBlockLocation.X + _xChange, _bkst.FromBlockLocation.Y + _yChange)) _
                        .WithToBlockLocation(New Point(_bkst.ToBlockLocation.X + _xChange, _bkst.ToBlockLocation.Y + _yChange)) _
                        .Build
                    AddBackStitch(_newProjectDesign, _newBkst)
                Next
            End If
            oProjectDesign = _newProjectDesign
            DrawGrid(oProject, oProjectDesign)
            DisplayImage(oDesignBitmap)
        End If
        oCurrentAction = DesignAction.none
    End Sub

    ' Cell selection
    Private Sub StartSelection(pCellLocation As Point)
        LogUtil.Debug("Starting selection", MyBase.Name)
        oInProgressAnchor = pCellLocation
        oInProgressTerminus = New Point(pCellLocation.X, pCellLocation.Y)
        isSelectionInProgress = True
        SelectionMessage("Selection in progress")
        LogUtil.Debug("Backstitch IS in progress", MyBase.Name)
    End Sub
    Private Sub SelectionMessage(pText As String)
        LblSelectMessage.Text = pText
        If pText = String.Empty Then
            LblSelection.Text = String.Empty
        Else
            LblSelection.Text = "From " & oInProgressAnchor.X & "," & oInProgressAnchor.Y & "  To " & oInProgressTerminus.X & "," & oInProgressTerminus.Y
        End If
    End Sub
    Private Sub EndSelection(pCellLocation As Point)
        LogUtil.Debug("Ending selection", MyBase.Name)
        If isSelectionInProgress Then
            If oCurrentAction = DesignAction.Cut Then
                '      CutCells(oCurrentSelectedCells)
            End If
            If oCurrentAction = DesignAction.Paste Then
                '        PasteCells(oCurrentSelectedCells, oInProgressAnchor)
            End If
            oInProgressTerminus = pCellLocation
            oCurrentSelection = New Point() {oInProgressAnchor, oInProgressTerminus}
            GetSelectedCells()
            isSelectionInProgress = False
            SelectionMessage("Selection complete")
            oCurrentAction = DesignAction.none
        Else
            LogUtil.Debug("Ending backstitch - error not in progress", MyBase.Name)
        End If
    End Sub
    Private Sub DrawSelectionInProgress(pCell As Point)
        oInProgressTerminus = New Point(pCell.X - 1, pCell.Y - 1)
        oSelectionPenWidth = Math.Max(2, iPpc / 16)
        _fromCellLocation_x = (oInProgressAnchor.X + iXOffset - topcorner.X) * iPpc
        _fromCellLocation_y = (oInProgressAnchor.Y + iYOffset - topcorner.Y) * iPpc
        _toCellLocation_x = (oInProgressTerminus.X + iXOffset - topcorner.X) * iPpc
        _toCellLocation_y = (oInProgressTerminus.Y + iYOffset - topcorner.Y) * iPpc
        Dim _selPenColour As Color = Color.Black
        _selPen = New Pen(_selPenColour, oStitchPenWidth)
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
    Private Sub BeginCopy()
        oCurrentAction = DesignAction.Copy
        LblSelectMessage.Text = "Select area to copy"
    End Sub
#End Region
#Region "stitch subroutines"
    '
    '   Add stitches to design
    '
    Private Sub Add3QtrStitchTR(celLocation As Point)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
    End Sub
    Private Sub Add3QtrStitchTL(celLocation As Point)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    End Sub
    Private Sub Add3QtrStitchBR(celLocation As Point)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    End Sub
    Private Sub Add3QtrStitchBL(celLocation As Point)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    End Sub
    Private Sub AddHalfBlockForwardStitch(celLocation As Point)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    End Sub
    Private Sub AddHalfBlockBackStitch(celLocation As Point)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
    End Sub
    Private Sub AddFullBlockStitch(celLocation As Point)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
        AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
    End Sub
    Private Sub AddBlockStitch(pDesign As ProjectDesign, pStitch As BlockStitch)
        RemoveExistingBlockStitch(pStitch.BlockLocation, pDesign)
        pDesign.BlockStitches.Add(pStitch)
    End Sub
    Private Sub AddKnot(pDesign As ProjectDesign, pKnot As Knot)
        RemoveExistingKnot(pKnot.BlockLocation, pKnot.BlockQuarter, pDesign)
        pDesign.Knots.Add(pKnot)
    End Sub
    Private Sub AddBackStitch(pDesign As ProjectDesign, pStitch As BackStitch)
        RemoveExistingBackStitch(pStitch.FromBlockLocation, pStitch.ToBlockLocation, pDesign)
        pDesign.BackStitches.Add(pStitch)
    End Sub

    Private Sub AddQuarterBlockstitch(pActionPoint As Point, pQtr As BlockQuarter)
        Dim _existing As BlockStitch = FindBlockstitch(pActionPoint)
        Dim _blockStitchQtrList As New List(Of BlockStitchQuarter)
        For Each _bsq As BlockStitchQuarter In _existing.Quarters
            If Not _bsq.BlockQuarter = pQtr Then
                _blockStitchQtrList.Add(_bsq)
            End If
        Next
        _blockStitchQtrList.Add(New BlockStitchQuarter(pQtr, BlockStitchType.Quarter, 2, oCurrentThread))
        _existing.Quarters = _blockStitchQtrList
    End Sub
    Private Sub AddKnot(pActionPoint As Point, pQtr As BlockQuarter, pIsBead As Boolean)
        Dim _exists = FindKnot(pActionPoint, pQtr)
        If _exists IsNot Nothing Then
            oProjectDesign.Knots.Remove(_exists)
        End If
        Dim newBead As New Knot(pActionPoint, pQtr, 1, oCurrentThread, True)
        oProjectDesign.Knots.Add(newBead)
    End Sub

    Private Function BackstitchMouseDown(pCellLocation As Point, pIsHalf As Boolean, pIsThick As Boolean) As Boolean
        Return BackstitchMouseDown(pCellLocation, BlockQuarter.TopLeft, pIsHalf, pIsThick)
    End Function
    Private Function BackstitchMouseDown(pCellLocation As Point, pQtr As BlockQuarter, pIsHalf As Boolean, pIsThick As Boolean) As Boolean
        Dim isEnded As Boolean = False
        If isBackstitchInProgress Then
            LogUtil.Debug("MouseDown backstitch in progress", MyBase.Name)
            EndBackstitch(pCellLocation, pQtr)
            isEnded = True
        Else
            LogUtil.Debug("MouseDown backstitch NOT in progress", MyBase.Name)
            StartBackstitch(pCellLocation, pQtr, pIsHalf, pIsThick)
        End If
        Return isEnded
    End Function
    Private Sub StartBackstitch(pCellLocation As Point, pIsHalf As Boolean, pIsThick As Boolean)
        StartBackstitch(pCellLocation, BlockQuarter.TopLeft, pIsHalf, pIsThick)
    End Sub
    Private Sub StartBackstitch(pCellLocation As Point, pQtr As BlockQuarter, pIsHalf As Boolean, pIsThick As Boolean)
        LogUtil.Debug("Starting backstitch", MyBase.Name)
        oBackstitchInProgress = New BackStitch(pCellLocation, pQtr, pCellLocation, pQtr, If(pIsThick, 2, 1), oCurrentThread)
        isBackstitchInProgress = True
        LogUtil.Debug("Backstitch IS in progress", MyBase.Name)
    End Sub
    Private Sub EndBackstitch(pCellLocation As Point)
        EndBackstitch(pCellLocation, BlockQuarter.TopLeft)
    End Sub
    Private Sub EndBackstitch(pCellLocation As Point, pQtr As BlockQuarter)
        LogUtil.Debug("Ending backstitch", MyBase.Name)
        If isBackstitchInProgress Then
            oBackstitchInProgress.ToBlockQuarter = pQtr
            oBackstitchInProgress.ToBlockLocation = pCellLocation
            oProjectDesign.BackStitches.Add(BackstitchBuilder.ABackStitch.StartingWith(oBackstitchInProgress).Build)
            oBackstitchInProgress.FromBlockQuarter = pQtr
            oBackstitchInProgress.FromBlockLocation = pCellLocation
            DrawGrid(oProject, oProjectDesign)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
        Else
            LogUtil.Debug("Ending backstitch - error not in progress", MyBase.Name)
        End If
    End Sub

    '
    '   Draw stitches
    '
    Private Sub DrawBlockStitch(pBlockStitch As BlockStitch)
        oStitchPenWidth = Math.Max(2, iPpc / 8)
        Dim _cellLocation_x As Integer = (pBlockStitch.BlockLocation.X * iPpc)
        Dim _cellLocation_y As Integer = (pBlockStitch.BlockLocation.Y * iPpc)
        For Each _blockQtr As BlockStitchQuarter In pBlockStitch.Quarters
            DrawQtrBlockStitch(_blockQtr, _cellLocation_x, _cellLocation_y)
        Next
    End Sub
    Private Sub DrawQtrBlockStitch(pBlockQtr As BlockStitchQuarter, pX As Integer, pY As Integer)

        Dim _crossPen As New Pen(New SolidBrush(pBlockQtr.Thread.Colour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Dim _blockPen As New Pen(New SolidBrush(pBlockQtr.Thread.Colour), 1)
        Dim _brush As New SolidBrush(pBlockQtr.Thread.Colour)
        Dim _rectSize As Integer = Math.Floor(iPpc / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay
        If _stitchDisplayStyle = StitchDisplayStyle.Crosses Then
            Select Case pBlockQtr.BlockQuarter
                Case BlockQuarter.TopLeft
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY)
                Case BlockQuarter.TopRight
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + iPpc, pY)
                Case BlockQuarter.BottomLeft
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY + iPpc)
                Case BlockQuarter.BottomRight
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + iPpc, pY + iPpc)
            End Select
        End If
        If _stitchDisplayStyle = StitchDisplayStyle.Blocks Or _stitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then

            Select Case pBlockQtr.BlockQuarter
                Case BlockQuarter.TopLeft

                    oDesignGraphics.DrawRectangle(_blockPen, pX, pY, _rectSize, _rectSize)
                    oDesignGraphics.FillRectangle(_brush, pX, pY, _rectSize, _rectSize)
                Case BlockQuarter.TopRight
                    oDesignGraphics.DrawRectangle(_blockPen, pX + _rectSize, pY, _rectSize, _rectSize)
                    oDesignGraphics.FillRectangle(_brush, pX + _rectSize, pY, _rectSize, _rectSize)
                Case BlockQuarter.BottomLeft
                    oDesignGraphics.DrawRectangle(_blockPen, pX, pY + _rectSize, _rectSize, _rectSize)
                    oDesignGraphics.FillRectangle(_brush, pX, pY + _rectSize, _rectSize, _rectSize)
                Case BlockQuarter.BottomRight
                    oDesignGraphics.DrawRectangle(_blockPen, pX + _rectSize, pY + _rectSize, _rectSize, _rectSize)
                    oDesignGraphics.FillRectangle(_brush, pX + _rectSize, pY + _rectSize, _rectSize, _rectSize)
            End Select
        End If
        _crossPen.Dispose()
    End Sub

    Private Sub DrawBackstitch(pBackstitch As BackStitch)
        oStitchPenWidth = Math.Max(2, iPpc / 16)
        Dim _fromCellLocation_x As Integer = (pBackstitch.FromBlockLocation.X * iPpc)
        Dim _fromCellLocation_y As Integer = (pBackstitch.FromBlockLocation.Y * iPpc)
        Dim _toCellLocation_x As Integer = (pBackstitch.ToBlockLocation.X * iPpc)
        Dim _toCellLocation_y As Integer = (pBackstitch.ToBlockLocation.Y * iPpc)
        Dim _pen As New Pen(pBackstitch.Thread.Colour, oStitchPenWidth * pBackstitch.Strands) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Select Case pBackstitch.FromBlockQuarter
            Case BlockQuarter.TopRight
                _fromCellLocation_x += iPpc / 2
            Case BlockQuarter.BottomLeft
                _fromCellLocation_y += iPpc / 2
            Case BlockQuarter.BottomRight
                _fromCellLocation_x += iPpc / 2
                _fromCellLocation_y += iPpc / 2
        End Select
        Select Case pBackstitch.ToBlockQuarter
            Case BlockQuarter.TopRight
                _toCellLocation_x += iPpc / 2
            Case BlockQuarter.BottomLeft
                _toCellLocation_y += iPpc / 2
            Case BlockQuarter.BottomRight
                _toCellLocation_x += iPpc / 2
                _toCellLocation_y += iPpc / 2
        End Select
        oDesignGraphics.DrawLine(_pen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)

    End Sub
    Private Sub DrawBackstitchInProgress(pCell As Point, pCellQtr As BlockQuarter, pIsHalfStitch As Boolean)
        DrawBackstitchInProgress(pCell, pCellQtr, pIsHalfStitch, False)
    End Sub
    Private Sub DrawBackstitchInProgress(pCell As Point, pCellQtr As BlockQuarter, pIsHalfStitch As Boolean, pIsUseSelectColour As Boolean)
        LogUtil.Debug("Drawing backstitch in progress", MyBase.Name)
        Dim _qtrLocationAdjust As Integer = If(pIsHalfStitch, iPpc / 2, iPpc)
        oBackstitchInProgress.ToBlockQuarter = pCellQtr
        oBackstitchInProgress.ToBlockLocation = pCell
        oStitchPenWidth = Math.Max(2, iPpc / 16)
        _fromCellLocation_x = (oBackstitchInProgress.FromBlockLocation.X + iXOffset - topcorner.X) * iPpc
        _fromCellLocation_y = (oBackstitchInProgress.FromBlockLocation.Y + iYOffset - topcorner.Y) * iPpc
        _toCellLocation_x = (oBackstitchInProgress.ToBlockLocation.X + iXOffset - topcorner.X) * iPpc
        _toCellLocation_y = (oBackstitchInProgress.ToBlockLocation.Y + iYOffset - topcorner.Y) * iPpc
        Dim _bsPenColour As Color = If(pIsUseSelectColour, oSelectedBackstitchThread.Colour, oBackstitchInProgress.Thread.Colour)
        _bsPen = New Pen(oBackstitchInProgress.Thread.Colour, oStitchPenWidth * oBackstitchInProgress.Strands) With {
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

    Private Sub DrawKnot(pKnot As Knot)
        Dim _knotlocation_x As Integer = (pKnot.BlockLocation.X * iPpc) - (iPpc / 4)
        Dim _knotlocation_y As Integer = (pKnot.BlockLocation.Y * iPpc) - (iPpc / 4)
        Select Case pKnot.BlockQuarter
            Case BlockQuarter.BottomLeft
                _knotlocation_y += iPpc / 2
            Case BlockQuarter.BottomRight
                _knotlocation_y += iPpc / 2
                _knotlocation_x += iPpc / 2
            Case BlockQuarter.TopRight
                _knotlocation_x += iPpc / 2
        End Select
        Dim _rect As New Rectangle(_knotlocation_x, _knotlocation_y, iPpc / 2, iPpc / 2)

        oDesignGraphics.FillEllipse(New SolidBrush(pKnot.Thread.Colour), _rect)
    End Sub

#End Region
#Region "functions"
    Private Function FindKnot(pActionPoint As Point, pQtr As BlockQuarter) As Knot
        Dim _exists As Knot = Nothing
        For Each _knot As Knot In oProjectDesign.Knots
            If _knot.BlockLocation = pActionPoint AndAlso _knot.BlockQuarter = pQtr Then
                _exists = _knot
            End If
        Next
        Return _exists
    End Function

    Private Function FindBlockstitch(pActionPoint As Point) As BlockStitch
        Dim _found As BlockStitch = Nothing
        For Each _blockStitch As BlockStitch In oProjectDesign.BlockStitches
            If _blockStitch.BlockLocation = pActionPoint Then
                _found = _blockStitch
                Exit For
            End If
        Next
        If _found Is Nothing Then
            _found = New BlockStitch(pActionPoint, New List(Of BlockStitchQuarter))
            oProjectDesign.BlockStitches.Add(_found)
        End If
        Return _found
    End Function
    Private Sub RemoveExistingBlockStitch(pActionPoint As Point, pDesign As ProjectDesign)
        For Each _blockStitch As BlockStitch In pDesign.BlockStitches
            If _blockStitch.BlockLocation = pActionPoint Then
                pDesign.BlockStitches.Remove(_blockStitch)
                Exit For
            End If
        Next
    End Sub
    Private Sub RemoveExistingBackStitch(pActionFromPoint As Point, pActionToPoint As Point, pDesign As ProjectDesign)
        For Each _backStitch As BackStitch In pDesign.BackStitches
            If _backStitch.FromBlockLocation = pActionFromPoint And _backStitch.ToBlockLocation = pActionToPoint Then
                pDesign.BackStitches.Remove(_backStitch)
                Exit For
            End If
        Next
    End Sub
    Private Sub RemoveExistingKnot(pActionPoint As Point, pQtr As BlockQuarter, pDesign As ProjectDesign)
        For Each _knot As Knot In pDesign.Knots
            If _knot.BlockLocation = pActionPoint And _knot.BlockQuarter = pQtr Then
                pDesign.Knots.Remove(_knot)
                Exit For
            End If
        Next
    End Sub

    Private Function FindBackstitches(pActionPoint As Point) As List(Of BackStitch)
        Dim _list As New List(Of BackStitch)
        For Each _backStitch As BackStitch In oProjectDesign.BackStitches
            If _backStitch.FromBlockLocation = pActionPoint Or _backStitch.ToBlockLocation = pActionPoint Then
                _list.Add(_backStitch)
            End If
        Next
        Return _list
    End Function
    Private Function GetPixelColour(e As MouseEventArgs) As Color
        Dim start_x As Integer = Math.Floor(e.X) + (topcorner.X - iXOffset) * iPpc
        Dim start_y As Integer = Math.Floor(e.Y) + (topcorner.Y - iYOffset) * iPpc
        Dim _colour As Color = Color.FromArgb(oProject.FabricColour)
        If start_x > 0 AndAlso start_x < oDesignBitmap.Width AndAlso start_y > 0 AndAlso start_y < oDesignBitmap.Height Then
            _colour = oDesignBitmap.GetPixel(start_x, start_y)
        End If
        Return _colour
    End Function
    Private Function FindQtrFromClickLocation(e As MouseEventArgs, ByRef pQtr As BlockQuarter) As Point
        Dim start_x As Integer = Math.Floor(e.X / iPpc) - iXOffset + topcorner.X
        Dim start_y As Integer = Math.Floor(e.Y / iPpc) - iYOffset + topcorner.Y

        Dim cel_x As Integer = (start_x) * iPpc

        Dim cel_y As Integer = (start_y) * iPpc

        Dim celLocation As New Point(cel_x, cel_y)

        Dim _xrmd As Integer = e.X Mod iPpc
        Dim _yrmd As Integer = e.Y Mod iPpc
        Select Case True
            Case (_xrmd >= 0 AndAlso _xrmd < iPpc / 2) AndAlso (_yrmd >= 0 AndAlso _yrmd < iPpc / 2)
                '    celLocation = New Point(cel_x, cel_y)
                pQtr = BlockQuarter.TopLeft
            Case _xrmd > iPpc / 2 AndAlso _yrmd > iPpc / 2
                '     celLocation = New Point(cel_x + (iPpc / 2), cel_y + (iPpc / 2))
                pQtr = BlockQuarter.BottomRight
            Case (_xrmd >= 0 AndAlso _xrmd < iPpc / 2) AndAlso _yrmd > iPpc / 2
                '     celLocation = New Point(cel_x, cel_y + (iPpc / 2))
                pQtr = BlockQuarter.TopRight
            Case _xrmd > iPpc / 2 AndAlso (_yrmd >= 0 AndAlso _yrmd < iPpc / 2)
                '      celLocation = New Point(cel_x + (iPpc / 2), cel_y)
                pQtr = BlockQuarter.BottomLeft
        End Select

        Return celLocation
    End Function

    Private Sub MnuClearSelection_Click(sender As Object, e As EventArgs) Handles MnuClearSelection.Click
        ClearSelection()
        DrawGrid(oProject, oProjectDesign)
        DisplayImage(oDesignBitmap)

    End Sub

    Private Sub ClearSelection()
        isSelectionInProgress = False
        isMoveInProgress = False
        oInProgressAnchor = New Point(0, 0)
        oInProgressTerminus = New Point(0, 0)
        oCurrentSelection = New Point() {}
        SelectionMessage(String.Empty)
    End Sub

    Private Sub PicDesign_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseUp
        Dim _cell As Cell = FindCellFromClickLocation(e)
        If isSelectionInProgress Then
            MouseUpLeftSelecting(e, _cell)
        Else
            ' MouseUpLeftNotSelecting(e, _cell)
        End If
    End Sub

#End Region
End Class
