' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Imports HindlewareLib.Logging
Imports MyStitch.BlockStitch
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmStitchDesign
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

    Private oImageUtil As New HindlewareLib.Imaging.ImageUtil

    Private oProjectId As Integer
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
    Private topcorner As Point = New Point(0, 0)
    Private iOneToOneSize As Size
    Private oViewer As ImageViewer = New ImageViewer

    Private oCurrentAction As DesignAction
    Private oCurrentThread As New Thread
    Private _threads As List(Of Thread)
    Private iXOffset As Integer
    Private iYOffset As Integer
    Private iOldHScrollbarValue As Integer = 0
    Private iOldVScrollbarValue As Integer = 0
    Private iBackstitchInProgress As New BackStitch
    Private isBackstitchInProgress As Boolean
    Private oBackstitchInProgressGraphics As Graphics
    Private iPpc As Integer

    Dim _bsPen As New Pen(Brushes.Black)
    Dim _fromCellLocation_x As Integer
    Dim _fromCellLocation_y As Integer
    Dim _toCellLocation_x As Integer
    Dim _toCellLocation_y As Integer
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
    End Enum

    Public WriteOnly Property ProjectId() As Integer
        Set(ByVal value As Integer)
            oProjectId = value
        End Set
    End Property

    Private Sub FrmStitchDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening design", MyBase.Name)
        GetFormPos(Me, My.Settings.DesignFormPos)
        LogUtil.IsDebugOn = True
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub InitialiseForm()
        oProject = GetProjectById(oProjectId)
        If oProject.IsLoaded Then
            oProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(My.Settings.DesignFilePath, MakeFilename(oProject)).Build
            If Not oProjectDesign.IsLoaded Then
                oProjectDesign.Rows = oProject.DesignHeight
                oProjectDesign.Columns = oProject.DesignWidth
            End If
            InitialisePalette()
            'Create ImageViewer
            oViewer = New ImageViewer(PicDesign, HScrollBar1, VScrollBar1, ZoomTrackBar, LblPct)
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

            CalculateScrollBarMaximumValues()
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

    Private Sub InitialisePalette()
        _threads = GetProjectThreads(oProject.ProjectId)
        For Each _thread As Thread In _threads
            Dim _picThread As New PictureBox()
            With _picThread
                .Name = CStr(_thread.ThreadId)
                .Size = New Size(50, 50)
                .BackColor = _thread.Colour
                .BorderStyle = BorderStyle.Fixed3D
                AddHandler .Click, AddressOf Palette_Click

            End With
            FlowLayoutPanel1.Controls.Add(_picThread)
        Next

    End Sub

    Private Sub Palette_Click(sender As Object, e As EventArgs)
        Dim _picBox As PictureBox = CType(sender, PictureBox)
        _picBox.BorderStyle = BorderStyle.FixedSingle

        Dim _thread As Thread = CType(_threads.Find(Function(p) p.ThreadId = CInt(_picBox.Name)), Thread)
        oCurrentThread = _thread
    End Sub

    Private Sub CalculateScrollBarMaximumValues()
        HScrollBar1.Maximum = (PicDesign.Width / iPpc) + (oProjectDesign.Columns) + 7
        VScrollBar1.Maximum = (PicDesign.Height / iPpc) + (oProjectDesign.Rows) + 7
    End Sub

    Private Sub CalculateScrollBarValues()
        HScrollBar1.Value = oProjectDesign.Columns - 1 + iXOffset - topcorner.X
        VScrollBar1.Value = oProjectDesign.Rows - 1 + iYOffset - topcorner.Y
    End Sub

    Private Sub ChangeMagnification(pNewValue As Decimal)
        magnification = pNewValue
        iPpc = Math.Floor(PIXELS_PER_CELL * magnification)
        iOneToOneSize = New Size(oProjectDesign.Columns * iPpc, oProjectDesign.Rows * iPpc)

        CalculateScrollBarMaximumValues()

        LblPct.Text = CStr(magnification)
        LblPpc.Text = CStr(iPpc)
    End Sub
    Private Sub CalculateOffsetForCentre(pDesignBitmap)
        Dim x As Integer = (PicDesign.Width - pDesignBitmap.Width) / (2 * iPpc)
        Dim y As Integer = (PicDesign.Height - pDesignBitmap.Height) / (2 * iPpc)
        SetValuesAfterHorizontalChange(x)
        SetValuesAfterVerticalChange(y)
        DisplayImage(oDesignBitmap)
        CalculateScrollBarValues()
        iOldHScrollbarValue = HScrollBar1.Value
        iOldVScrollbarValue = VScrollBar1.Value
    End Sub

    Private Sub GenTestDesign()
        oProjectDesign = New ProjectDesign

        For x = 1 To 10
            Dim _quarters As New List(Of BlockStitchQuarter)
            oProjectDesign.BlockStitches.Add(New BlockStitch(New Point(1, 1), _quarters))
            oProjectDesign.BackStitches.Add(New BackStitch)
            oProjectDesign.Knots.Add(New Knot)
        Next
        oProjectDesign.Rows = 10
        oProjectDesign.Columns = 15
    End Sub

    Private Sub SetPictureWidth()
        'If sourceBitmap IsNot Nothing Then
        '    If PnlCardImage.Width > PnlCardImage.Height Then
        '        PicThreadCard.Width = PicThreadCard.Height * sourceBitmap.Width / sourceBitmap.Height
        '    Else
        '        PicThreadCard.Height = PicThreadCard.Width * sourceBitmap.Height / sourceBitmap.Width
        '    End If
        'End If
        'PicThreadCard.Image = sourceBitmap
        'PicThreadCard.Location = New Point((PnlCardImage.Width - PicThreadCard.Width) / 2, PicThreadCard.Top)
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
        oDesignGraphics.DrawRectangle(_designBorderPen, New Rectangle(0, 0, Math.Min(gap * _widthInColumns, oDesignBitmap.Width), Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
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
    Private Sub DrawBlockStitch(pBlockStitch As BlockStitch)
        oStitchPenWidth = Math.Max(2, iPpc / 8)
        Dim _cellLocation_x As Integer = (pBlockStitch.BlockLocation.X * iPpc)
        Dim _cellLocation_y As Integer = (pBlockStitch.BlockLocation.Y * iPpc)
        For Each _blockQtr As BlockStitchQuarter In pBlockStitch.Quarters
            DrawQtrBlockStitch(_blockQtr, _cellLocation_x, _cellLocation_y)
        Next

    End Sub

    'Private Sub DrawFullBlockStitch(pBlockQtr As BlockStitchQuarter, pX As Integer, pY As Integer)
    '    ' Remove when thread colour set correctly
    '    pBlockQtr.Thread.Colour = Color.Black
    '    Dim _pen As New Pen(New SolidBrush(pBlockQtr.Thread.Colour), 2)

    '    If pBlockQtr.StitchType = BlockStitchType.Full _
    '        Or (pBlockQtr.StitchType = BlockStitchType.Half _
    '        And pBlockQtr.BlockQuarter = BlockQuarter.TopLeft) Then
    '        oDesignGraphics.DrawLine(_pen, pX, pY, pX + iPpc, pY + iPpc)
    '    End If
    '    If pBlockQtr.StitchType = BlockStitchType.Full _
    '        Or (pBlockQtr.StitchType = BlockStitchType.Half _
    '    And pBlockQtr.BlockQuarter = BlockQuarter.TopRight) Then
    '        oDesignGraphics.DrawLine(_pen, pX + iPpc, pY, pX, pY + iPpc)
    '    End If

    'End Sub

    Private Sub DrawQtrBlockStitch(pBlockQtr As BlockStitchQuarter, pX As Integer, pY As Integer)

        '    Dim l As Single = CSng(Math.Round(Math.Sqrt(iPpc * iPpc / 2) / oStitchPenWidth, 1))

        Dim _pen As New Pen(New SolidBrush(pBlockQtr.Thread.Colour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }

        Dim _middleX As Integer = CInt(pX + (iPpc / 2))
        Dim _middleY As Integer = CInt(pY + (iPpc / 2))
        Select Case pBlockQtr.BlockQuarter
            Case BlockQuarter.TopLeft
                oDesignGraphics.DrawLine(_pen, _middleX, _middleY, pX, pY)
            Case BlockQuarter.TopRight
                oDesignGraphics.DrawLine(_pen, _middleX, _middleY, pX + iPpc, pY)
            Case BlockQuarter.BottomLeft
                oDesignGraphics.DrawLine(_pen, _middleX, _middleY, pX, pY + iPpc)
            Case BlockQuarter.BottomRight
                oDesignGraphics.DrawLine(_pen, _middleX, _middleY, pX + iPpc, pY + iPpc)

        End Select

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

    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _bsPen.Dispose()
        My.Settings.DesignFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim _filename As String = MakeFilename(oProject)
        SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
        ' SaveDesignXML(oProjectDesign, My.Settings.DesignFilePath, _filename)

    End Sub

    Private Function MakeFilename(pProject As Project) As String
        Dim _filename As String = oProject.DesignFileName
        If String.IsNullOrEmpty(_filename) Then
            _filename = Replace(oProject.ProjectName, " ", "_").ToLower
        End If
        Return _filename
    End Function

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click

    End Sub

    Private Sub BtnCut_Click(sender As Object, e As EventArgs) Handles BtnCut.Click

    End Sub

    Private Sub BtnMove_Click(sender As Object, e As EventArgs) Handles BtnMove.Click

    End Sub

    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click

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

    Private Sub IncreaseMagnification()
        isLoading = True
        ChangeMagnification(Math.Round(magnification * MAG_STEP, 2, MidpointRounding.AwayFromZero))
        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub

    Private Sub BtnShrink_Click(sender As Object, e As EventArgs) Handles BtnShrink.Click
        DecreaseMagnification()

    End Sub

    Private Sub DecreaseMagnification()
        isLoading = True
        ChangeMagnification(Math.Round(magnification / MAG_STEP, 2, MidpointRounding.AwayFromZero))

        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub

    Private Sub BtnFullStitch_Click(sender As Object, e As EventArgs) Handles BtnFullStitch.Click
        oCurrentAction = DesignAction.FullBlockstitch
        ClearButtonSelect()
        BtnFullStitch.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub Btn3QtrsTL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTL.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchTopLeft
        ClearButtonSelect()
        Btn3QtrsTL.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub Btn3QtrsTR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTR.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchTopRight
        ClearButtonSelect()
        Btn3QtrsTR.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub Btn3QtrsBR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBR.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchBottomRight
        ClearButtonSelect()
        Btn3QtrsBR.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub Btn3QtrsBL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBL.Click
        oCurrentAction = DesignAction.ThreeQuarterBlockstitchBottomLeft
        ClearButtonSelect()
        Btn3QtrsBL.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnHalfForward_Click(sender As Object, e As EventArgs) Handles BtnHalfForward.Click
        oCurrentAction = DesignAction.HalfBlockstitchForward
        ClearButtonSelect()
        BtnHalfForward.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnHalfBack_Click(sender As Object, e As EventArgs) Handles BtnHalfBack.Click
        oCurrentAction = DesignAction.HalfBlockstitchBack
        ClearButtonSelect()
        BtnHalfBack.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnQtrTL_Click(sender As Object, e As EventArgs) Handles BtnQtrTL.Click
        oCurrentAction = DesignAction.QuarterBlockstitchTopLeft
        ClearButtonSelect()
        BtnQtrTL.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnQWtrTR_Click(sender As Object, e As EventArgs) Handles BtnQtrTR.Click
        oCurrentAction = DesignAction.QuarterBlockstitchTopRight
        ClearButtonSelect()
        BtnQtrTR.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnQtrBR_Click(sender As Object, e As EventArgs) Handles BtnQtrBR.Click
        oCurrentAction = DesignAction.QuarterBlockstitchBottomRight
        ClearButtonSelect()
        BtnQtrBR.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnQtrBL_Click(sender As Object, e As EventArgs) Handles BtnQtrBL.Click
        oCurrentAction = DesignAction.QuarterBlockstitchBottonLeft
        ClearButtonSelect()
        BtnQtrBL.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnQuarters_Click(sender As Object, e As EventArgs) Handles BtnQuarters.Click
        oCurrentAction = DesignAction.BlockstitchQuarters
        ClearButtonSelect()
        BtnQuarters.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnFullBackstitchThin_Click(sender As Object, e As EventArgs) Handles BtnFullBackstitchThin.Click
        oCurrentAction = DesignAction.BackStitchFullThin
        ClearButtonSelect()
        BtnFullBackstitchThin.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnHalfBackStitchThin_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThin.Click
        oCurrentAction = DesignAction.BackstitchHalfThin
        ClearButtonSelect()
        BtnHalfBackStitchThin.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnFullBackStitchThick_Click(sender As Object, e As EventArgs) Handles BtnFullBackStitchThick.Click
        oCurrentAction = DesignAction.BackstitchFullThick
        ClearButtonSelect()
        BtnFullBackStitchThick.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnHalfBackStitchThick_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThick.Click
        oCurrentAction = DesignAction.BackStitchHalfThick
        ClearButtonSelect()
        BtnHalfBackStitchThick.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnKnot_Click(sender As Object, e As EventArgs) Handles BtnKnot.Click
        oCurrentAction = DesignAction.Knot
        ClearButtonSelect()
        BtnKnot.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub

    Private Sub BtnBead_Click(sender As Object, e As EventArgs) Handles BtnBead.Click
        oCurrentAction = DesignAction.Bead
        ClearButtonSelect()
        BtnBead.BackgroundImage = My.Resources.BtnBkgrdDown
    End Sub
    Private Sub ClearButtonSelect()
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub
    Private Sub HScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        If Not isLoading Then
            Dim _h_change As Integer = (HScrollBar1.Value - iOldHScrollbarValue)
            Dim _newOff_x As Integer = iXOffset + _h_change - topcorner.X
            SetValuesAfterHorizontalChange(_newOff_x)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
            iOldHScrollbarValue = HScrollBar1.Value
        End If
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

    Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        If Not isLoading Then

            Dim _v_change As Integer = (VScrollBar1.Value - iOldVScrollbarValue)
            Dim _newOff_y As Integer = iYOffset + _v_change - topcorner.Y

            SetValuesAfterVerticalChange(_newOff_y)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
            iOldVScrollbarValue = VScrollBar1.Value

        End If
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

    Private Sub BtnHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeight.Click

    End Sub

    Private Sub BtnWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWidth.Click

    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click

    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click

    End Sub

    Private Sub ZoomTrackBar_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ZoomTrackBar.ValueChanged

    End Sub

    Private Sub PicDesign_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseDown
        Dim isImageChanged As Boolean = False
        Dim cel_x As Integer = Math.Floor(e.X / iPpc) - iXOffset + topcorner.X
        Dim cel_y As Integer = Math.Floor(e.Y / iPpc) - iYOffset + topcorner.Y

        Dim _xrmd As Integer = e.X Mod iPpc
        Dim _yrmd As Integer = e.Y Mod iPpc

        Dim _knotQtr As BlockQuarter
        Dim _stitchQtr As BlockQuarter

        Select Case True
            Case _xrmd < iPpc / 2 AndAlso _yrmd < iPpc / 2
                _stitchQtr = BlockQuarter.TopLeft
            Case _xrmd >= iPpc / 2 AndAlso _yrmd >= iPpc / 2
                _stitchQtr = BlockQuarter.BottomRight
            Case _xrmd < iPpc / 2 AndAlso _yrmd >= iPpc / 2
                _stitchQtr = BlockQuarter.BottomLeft
            Case _xrmd >= iPpc / 2 AndAlso _yrmd < iPpc / 2
                _stitchQtr = BlockQuarter.TopRight
        End Select

        If _yrmd >= 0 And _yrmd < iPpc / 4 Then
            If _xrmd >= 0 And _xrmd < iPpc / 4 Then
                _knotQtr = BlockQuarter.TopLeft
            End If
            If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
                _knotQtr = BlockQuarter.TopRight
            End If
            If _xrmd >= iPpc * 3 / 4 Then
                _knotQtr = BlockQuarter.TopLeft
                cel_x += 1
            End If
        End If

        If _yrmd >= iPpc / 4 And _yrmd < iPpc * 3 / 4 Then
            If _xrmd >= 0 And _xrmd < iPpc / 4 Then
                _knotQtr = BlockQuarter.BottomLeft
            End If
            If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
                _knotQtr = BlockQuarter.BottomRight
            End If
            If _xrmd >= iPpc * 3 / 4 Then
                _knotQtr = BlockQuarter.BottomLeft
                cel_x += 1
            End If
        End If

        If _yrmd >= iPpc * 3 / 4 Then
            If _xrmd >= 0 And _xrmd < iPpc / 4 Then
                _knotQtr = BlockQuarter.TopLeft
                cel_y += 1
            End If
            If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
                _knotQtr = BlockQuarter.TopRight
                cel_y += 1
            End If
            If _xrmd >= iPpc * 3 / 4 Then
                _knotQtr = BlockQuarter.TopLeft
                cel_y += 1
                cel_x += 1
            End If
        End If

        Dim celLocation As New Point(cel_x, cel_y)

        Dim isRemove As Boolean = e.Button = MouseButtons.Right

        If isRemove Then
            LogUtil.Debug("Remove stitch", MyBase.Name)
            If oCurrentAction = DesignAction.Bead Or oCurrentAction = DesignAction.Knot Then
                LogUtil.Debug("Removing knot/bead", MyBase.Name)
                Dim _exists As Knot = FindKnot(celLocation, _knotQtr)
                If _exists IsNot Nothing Then
                    oProjectDesign.Knots.Remove(_exists)
                    isImageChanged = True
                End If
            Else

                If isBackstitchInProgress Then
                    LogUtil.Debug("Backstitch ending", MyBase.Name)
                    isBackstitchInProgress = False
                    oBackstitchInProgressGraphics.Dispose()
                    iBackstitchInProgress = Nothing
                Else
                    LogUtil.Debug("Removing blockstitch", MyBase.Name)
                    Dim _exists As BlockStitch = FindBlockstitch(celLocation)
                    If _exists.IsLoaded Then
                        oProjectDesign.BlockStitches.Remove(_exists)
                        isImageChanged = True
                    End If
                End If
            End If
        Else
            LogUtil.Debug("Create stitch", MyBase.Name)
            Label1.Text = CStr(cel_x)
            Label2.Text = CStr(cel_y)

            Dim _adjustX As Integer = 0
            Dim _adjustY As Integer = 0

            If _xrmd > iPpc / 2 Then
                _adjustX += iPpc / 2
            End If
            If _yrmd > iPpc / 2 Then
                _adjustY += iPpc / 2
            End If

            Dim _actionPoint As New Point((cel_x * iPpc) + _adjustX, (cel_y * iPpc) + _adjustY)

            Select Case oCurrentAction
                Case DesignAction.BackstitchFullThick
                    isImageChanged = BackstitchMouseDown(celLocation, False, True)
                Case DesignAction.BackStitchFullThin
                    isImageChanged = BackstitchMouseDown(celLocation, False, False)
                Case DesignAction.BackstitchHalfThin
                    isImageChanged = BackstitchMouseDown(celLocation, _stitchQtr, True, False)
                Case DesignAction.BackStitchHalfThick
                    isImageChanged = BackstitchMouseDown(celLocation, _stitchQtr, True, True)
                Case DesignAction.Bead
                    AddKnot(celLocation, _knotQtr, True)
                    isImageChanged = True
                Case DesignAction.Knot
                    AddKnot(celLocation, _knotQtr, False)
                    isImageChanged = True
                Case DesignAction.FullBlockstitch
                    AddFullBlockStitch(celLocation)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchBack
                    AddHalfBlockBackStitch(celLocation)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchForward
                    AddHalfBlockForwardStitch(celLocation)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottomRight
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottonLeft
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopLeft
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopRight
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                    Add3QtrStitchBL(celLocation)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomRight
                    Add3QtrStitchBR(celLocation)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopLeft
                    Add3QtrStitchTL(celLocation)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopRight
                    Add3QtrStitchTR(celLocation)
                    isImageChanged = True
                Case DesignAction.BlockstitchQuarters
                    AddQuarterBlockstitch(celLocation, _stitchQtr)
                    isImageChanged = True
            End Select
        End If
        If isImageChanged Then
            DrawGrid(oProject, oProjectDesign)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
        End If
    End Sub

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
    Private Sub PicDesign_SizeChanged(sender As Object, e As EventArgs) Handles PicDesign.SizeChanged
        If Not isLoading Then
            If oProject IsNot Nothing AndAlso oProjectDesign IsNot Nothing AndAlso oProject.IsLoaded AndAlso oProjectDesign.IsLoaded Then
                DisplayImage(oDesignBitmap)
            End If
        End If
    End Sub

    Private Sub PicDesign_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseMove
        Dim isImageChanged As Boolean = False
        Dim cellQtr As BlockQuarter = BlockQuarter.TopLeft
        Dim cell As New Point(0, 0)
        Dim cellLocation As Point = FindCellFromClickLocation(e, cell, cellQtr)
        If e.Button = MouseButtons.Right Then
            If oCurrentAction = DesignAction.Bead Or oCurrentAction = DesignAction.Knot Then
                LogUtil.Debug("Remove knot on the move", MyBase.Name)
                Dim _exists As Knot = FindKnot(cell, cellQtr)
                If _exists IsNot Nothing Then
                    oProjectDesign.Knots.Remove(_exists)
                    isImageChanged = True
                End If
            Else
                LogUtil.Debug("Remove blockstitch on the move", MyBase.Name)
                Dim _exists As BlockStitch = FindBlockstitch(cell)
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
                    AddKnot(cell, cellQtr, True)
                    isImageChanged = True
                Case DesignAction.Knot
                    AddKnot(cell, cellQtr, False)
                    isImageChanged = True
                Case DesignAction.FullBlockstitch
                    AddFullBlockStitch(cell)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchBack
                    AddHalfBlockBackStitch(cell)
                    isImageChanged = True
                Case DesignAction.HalfBlockstitchForward
                    AddHalfBlockForwardStitch(cell)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottomRight
                    AddQuarterBlockstitch(cell, BlockQuarter.BottomRight)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchBottonLeft
                    AddQuarterBlockstitch(cell, BlockQuarter.BottomLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopLeft
                    AddQuarterBlockstitch(cell, BlockQuarter.TopLeft)
                    isImageChanged = True
                Case DesignAction.QuarterBlockstitchTopRight
                    AddQuarterBlockstitch(cell, BlockQuarter.TopRight)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                    Add3QtrStitchBL(cell)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchBottomRight
                    Add3QtrStitchBR(cell)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopLeft
                    Add3QtrStitchTL(cell)
                    isImageChanged = True
                Case DesignAction.ThreeQuarterBlockstitchTopRight
                    Add3QtrStitchTR(cell)
                    isImageChanged = True
                Case DesignAction.BlockstitchQuarters
                    AddQuarterBlockstitch(cell, cellQtr)
                    isImageChanged = True
            End Select

        End If
        If e.Button = MouseButtons.None Then
            If isBackstitchInProgress Then
                Select Case oCurrentAction
                    Case DesignAction.BackstitchFullThick
                        DrawBackstitchInProgress(cell, cellQtr)

                    Case DesignAction.BackStitchFullThin
                        DrawBackstitchInProgress(cell, cellQtr)

                    Case DesignAction.BackstitchHalfThin
                        DrawBackstitchInProgress(cell, cellQtr)

                    Case DesignAction.BackStitchHalfThick
                        DrawBackstitchInProgress(cell, cellQtr)

                End Select
            End If
        End If
        If isImageChanged Then
            LogUtil.Debug("Drawing changes after move", MyBase.Name)
            DrawGrid(oProject, oProjectDesign)
            DisplayImage(oDesignBitmap, iXOffset, iYOffset)
        End If
    End Sub

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
    Private Function FindCellFromClickLocation(e As MouseEventArgs, ByRef pCell As Point, ByRef pQtr As BlockQuarter) As Point
        Dim start_x As Integer = Math.Floor(e.X / iPpc) - iXOffset + topcorner.X
        Dim start_y As Integer = Math.Floor(e.Y / iPpc) - iYOffset + topcorner.Y
        pCell = New Point(start_x, start_y)
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
                pQtr = BlockQuarter.BottomLeft
            Case _xrmd > iPpc / 2 AndAlso (_yrmd >= 0 AndAlso _yrmd < iPpc / 2)
                '      celLocation = New Point(cel_x + (iPpc / 2), cel_y)
                pQtr = BlockQuarter.TopRight
        End Select

        Return celLocation
    End Function
    'Private Sub PicDesign_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseUp
    '    Dim cel_x As Integer = Math.Floor(e.X / iPpc) - iXOffset + topcorner.X
    '    Dim cel_y As Integer = Math.Floor(e.Y / iPpc) - iYOffset + topcorner.Y

    '    Dim _xrmd As Integer = e.X Mod iPpc
    '    Dim _yrmd As Integer = e.Y Mod iPpc

    '    Dim _backstitchQtr As BlockQuarter
    '    Select Case True
    '        Case _xrmd < iPpc / 2 AndAlso _yrmd < iPpc / 2

    '        Case _xrmd >= iPpc / 2 AndAlso _yrmd >= iPpc / 2
    '            cel_x += 1
    '            cel_y += 1
    '        Case _xrmd < iPpc / 2 AndAlso _yrmd >= iPpc / 2
    '            cel_y += 1
    '        Case _xrmd >= iPpc / 2 AndAlso _yrmd < iPpc / 2
    '            cel_x += 1
    '    End Select
    '    If _yrmd >= 0 And _yrmd < iPpc / 4 Then
    '        If _xrmd >= 0 And _xrmd < iPpc / 4 Then
    '            _backstitchQtr = BlockQuarter.TopLeft
    '        End If
    '        If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
    '            _backstitchQtr = BlockQuarter.TopRight
    '        End If
    '        If _xrmd >= iPpc * 3 / 4 Then
    '            _backstitchQtr = BlockQuarter.TopLeft
    '            cel_x += 1
    '        End If
    '    End If

    '    If _yrmd >= iPpc / 4 And _yrmd < iPpc * 3 / 4 Then
    '        If _xrmd >= 0 And _xrmd < iPpc / 4 Then
    '            _backstitchQtr = BlockQuarter.BottomLeft
    '        End If
    '        If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
    '            _backstitchQtr = BlockQuarter.BottomRight
    '        End If
    '        If _xrmd >= iPpc * 3 / 4 Then
    '            _backstitchQtr = BlockQuarter.BottomLeft
    '            cel_x += 1
    '        End If
    '    End If

    '    If _yrmd >= iPpc * 3 / 4 Then
    '        If _xrmd >= 0 And _xrmd < iPpc / 4 Then
    '            _backstitchQtr = BlockQuarter.TopLeft
    '            cel_y += 1
    '        End If
    '        If _xrmd >= iPpc / 4 And _xrmd < iPpc * 3 / 4 Then
    '            _backstitchQtr = BlockQuarter.TopRight
    '            cel_y += 1
    '        End If
    '        If _xrmd >= iPpc * 3 / 4 Then
    '            _backstitchQtr = BlockQuarter.TopLeft
    '            cel_y += 1
    '            cel_x += 1
    '        End If
    '    End If
    '    Dim celLocation As New Point(cel_x, cel_y)
    '    Select Case oCurrentAction
    '        Case DesignAction.BackstitchFullThick
    '            EndBackstitch(celLocation)
    '        Case DesignAction.BackStitchFullThin
    '            EndBackstitch(celLocation)
    '        Case DesignAction.BackstitchHalfThin
    '            EndBackstitch(celLocation, _backstitchQtr)
    '        Case DesignAction.BackStitchHalfThick
    '            EndBackstitch(celLocation, _backstitchQtr)
    '    End Select
    '    DrawGrid(oProject, oProjectDesign)
    '    DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    'End Sub
    Private Sub DrawBackstitchInProgress(pCell As Point, pCellQtr As BlockQuarter)
        LogUtil.Debug("Drawing backstitch in progress", MyBase.Name)
        iBackstitchInProgress.ToBlockQuarter = pCellQtr
        iBackstitchInProgress.ToBlockLocation = pCell
        oStitchPenWidth = Math.Max(2, iPpc / 16)
        _fromCellLocation_x = (iBackstitchInProgress.FromBlockLocation.X + iXOffset - topcorner.X) * iPpc
        _fromCellLocation_y = (iBackstitchInProgress.FromBlockLocation.Y + iYOffset - topcorner.Y) * iPpc
        _toCellLocation_x = (iBackstitchInProgress.ToBlockLocation.X + iXOffset - topcorner.X) * iPpc
        _toCellLocation_y = (iBackstitchInProgress.ToBlockLocation.Y + iYOffset - topcorner.Y) * iPpc
        _bsPen = New Pen(iBackstitchInProgress.Thread.Colour, oStitchPenWidth * iBackstitchInProgress.Strands) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Select Case iBackstitchInProgress.FromBlockQuarter
            Case BlockQuarter.TopRight
                _fromCellLocation_x += iPpc / 2
            Case BlockQuarter.BottomLeft
                _fromCellLocation_y += iPpc / 2
            Case BlockQuarter.BottomRight
                _fromCellLocation_x += iPpc / 2
                _fromCellLocation_y += iPpc / 2
        End Select
        Select Case iBackstitchInProgress.ToBlockQuarter
            Case BlockQuarter.TopRight
                _toCellLocation_x += iPpc / 2
            Case BlockQuarter.BottomLeft
                _toCellLocation_y += iPpc / 2
            Case BlockQuarter.BottomRight
                _toCellLocation_x += iPpc / 2
                _toCellLocation_y += iPpc / 2
        End Select
        PicDesign.Invalidate()
        '       LogUtil.Debug(CStr(_fromCellLocation_x) & "," & CStr(_fromCellLocation_y) & " to " & CStr(_toCellLocation_x) & "," & CStr(_toCellLocation_y), MyBase.Name)
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
        e.Graphics.DrawLine(_bsPen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)

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
        iBackstitchInProgress = New BackStitch(pCellLocation, pQtr, pCellLocation, pQtr, If(pIsThick, 2, 1), oCurrentThread)
        isBackstitchInProgress = True
        LogUtil.Debug("Backstitch IS in progress", MyBase.Name)
    End Sub
    Private Sub EndBackstitch(pCellLocation As Point)
        EndBackstitch(pCellLocation, BlockQuarter.TopLeft)
    End Sub
    Private Sub EndBackstitch(pCellLocation As Point, pQtr As BlockQuarter)
        LogUtil.Debug("Ending backstitch", MyBase.Name)
        If isBackstitchInProgress Then
            iBackstitchInProgress.ToBlockQuarter = pQtr
            iBackstitchInProgress.ToBlockLocation = pCellLocation
            oProjectDesign.BackStitches.Add(iBackstitchInProgress)
            iBackstitchInProgress = Nothing
            isBackstitchInProgress = False
        Else
            LogUtil.Debug("Ending backstitch - error not in progress", MyBase.Name)
        End If
    End Sub

    Private Sub BtnCentre_Click(sender As Object, e As EventArgs) Handles BtnCentre.Click
        isLoading = True
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
    End Sub

    Private Sub FrmStitchDesign_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub StitchDisplayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StitchDisplayToolStripMenuItem.Click
        Using _display As New FrmStitchDisplayStyle
            _display.ShowDialog()
        End Using
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomInToolStripMenuItem.Click
        IncreaseMagnification()

    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        DecreaseMagnification()

    End Sub



    'Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
    '    Dim start_x As Integer = Math.Floor(testX / iPpc) - iXOffset
    '    Dim start_y As Integer = Math.Floor(testY / iPpc) - iYOffset

    '    Dim xoffset As Integer = iXOffset + topcorner.X
    '    Dim yoffset As Integer = iYOffset + topcorner.Y

    '    For xjump As Integer = 0 To 5
    '        Dim cel_x As Integer = (start_x + xjump) * iPpc
    '        For yjump As Integer = 0 To 5
    '            Dim cel_y As Integer = (start_y + yjump) * iPpc
    '            Dim celLocation As New Point(cel_x, cel_y)
    '            Dim _xrmd As Integer = testX Mod iPpc
    '            Dim _yrmd As Integer = testY Mod iPpc

    '            Dim _stitchQtr As BlockQuarter

    '            Select Case True
    '                Case (_xrmd >= 0 AndAlso _xrmd < iPpc / 2) AndAlso (_yrmd >= 0 AndAlso _yrmd < iPpc / 2)
    '                    _stitchQtr = BlockQuarter.TopLeft
    '                    celLocation = New Point(cel_x, cel_y)
    '                Case _xrmd > iPpc / 2 AndAlso _yrmd > iPpc / 2
    '                    _stitchQtr = BlockQuarter.BottomRight
    '                    celLocation = New Point(cel_x + (iPpc / 2), cel_y + (iPpc / 2))

    '                Case (_xrmd >= 0 AndAlso _xrmd < iPpc / 2) AndAlso _yrmd > iPpc / 2
    '                    _stitchQtr = BlockQuarter.BottomLeft
    '                    celLocation = New Point(cel_x, cel_y + (iPpc / 2))

    '                Case _xrmd > iPpc / 2 AndAlso (_yrmd >= 0 AndAlso _yrmd < iPpc / 2)
    '                    _stitchQtr = BlockQuarter.TopRight
    '                    celLocation = New Point(cel_x + (iPpc / 2), cel_y)

    '            End Select

    '            oDesignGraphicsOverlay.DrawRectangle(New Pen(Color.DarkGray, 1), New Rectangle(celLocation, New Size(iPpc / 2, iPpc / 2)))
    '            oDesignGraphicsOverlay.DrawString(CStr(xjump) & "," & CStr(yjump), New Font("Arial", 7), Brushes.Black, celLocation)
    '        Next
    '    Next
    '    DisplayImage(oDesignBitmap, iXOffset, iYOffset)

    'End Sub
End Class
