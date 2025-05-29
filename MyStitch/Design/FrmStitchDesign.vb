' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

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

    Private oImageUtil As New HindlewareLib.Imaging.ImageUtil

    Private oProjectId As Integer
    Private oProject As Project
    Private oDesignBitmap As Bitmap
    Private oDesignGraphics As Graphics
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

    Private iXOffset As Integer
    Private iYOffset As Integer
    Private iOldHScrollbarValue As Integer = 0
    Private iOldVScrollbarValue As Integer = 0

    Private iPpc As Integer
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

            'HScrollBar1.Maximum = PicDesign.Width / iPpc
            'HScrollBar1.Value = iXOffset / iPpc

            'VScrollBar1.Maximum = PicDesign.Height / iPpc
            'VScrollBar1.Value = iYOffset / iPpc
            iOldHScrollbarValue = HScrollBar1.Value
            iOldVScrollbarValue = VScrollBar1.Value

        Else
            MsgBox("No project found", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If

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

        Next
        For Each _knot As Knot In oProjectDesign.Knots
            DrawKnot(_knot)
        Next
    End Sub
    Private Sub DrawBlockStitch(pBlockStitch As BlockStitch)
        Dim _cellLocation_x As Integer = (pBlockStitch.BlockLocation.X * iPpc)
        Dim _cellLocation_y As Integer = (pBlockStitch.BlockLocation.Y * iPpc)
        For Each _blockQtr As BlockStitchQuarter In pBlockStitch.Quarters
            Select Case _blockQtr.StitchType
                Case BlockStitchType.Full
                    DrawFullBlockStitch(_blockQtr, _cellLocation_x, _cellLocation_y)
                Case BlockStitchType.Half
                    DrawFullBlockStitch(_blockQtr, _cellLocation_x, _cellLocation_y)
                Case BlockStitchType.ThreeQuarter
                Case BlockStitchType.Quarter
                    DrawQtrBlockStitch(_blockQtr, _cellLocation_x, _cellLocation_y)
            End Select

        Next

    End Sub

    Private Sub DrawFullBlockStitch(pBlockQtr As BlockStitchQuarter, pX As Integer, pY As Integer)
        ' Remove when thread colour set correctly
        pBlockQtr.Thread.Colour = Color.Black
        Dim _pen As New Pen(New SolidBrush(pBlockQtr.Thread.Colour), 2)

        If pBlockQtr.StitchType = BlockStitchType.Full _
            Or (pBlockQtr.StitchType = BlockStitchType.Half _
            And pBlockQtr.BlockQuarter = BlockQuarter.TopLeft) Then
            oDesignGraphics.DrawLine(_pen, pX, pY, pX + iPpc, pY + iPpc)
        End If
        If pBlockQtr.StitchType = BlockStitchType.Full _
            Or (pBlockQtr.StitchType = BlockStitchType.Half _
        And pBlockQtr.BlockQuarter = BlockQuarter.TopRight) Then
            oDesignGraphics.DrawLine(_pen, pX + iPpc, pY, pX, pY + iPpc)
        End If

    End Sub

    Private Sub DrawQtrBlockStitch(pBlockQtr As BlockStitchQuarter, pX As Integer, pY As Integer)
        ' Remove when thread colour set correctly
        pBlockQtr.Thread.Colour = Color.Red
        Dim _pen As New Pen(New SolidBrush(pBlockQtr.Thread.Colour), 2)

        Dim _middleX As Integer = CInt(pX + (iPpc / 2))
        Dim _middleY As Integer = CInt(pY + (iPpc / 2))
        Select Case pBlockQtr.BlockQuarter
            Case BlockQuarter.TopLeft

                oDesignGraphics.DrawLine(_pen, pX, pY, _middleX, _middleY)
            Case BlockQuarter.TopRight
                oDesignGraphics.DrawLine(_pen, pX + iPpc, pY, _middleX, _middleY)
            Case BlockQuarter.BottomLeft
                oDesignGraphics.DrawLine(_pen, pX, pY + iPpc, _middleX, _middleY)
            Case BlockQuarter.BottomRight
                oDesignGraphics.DrawLine(_pen, pX + iPpc, pY + iPpc, _middleX, _middleY)
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
        ' Remove when thread colour set correctly
        pKnot.Thread.Colour = Color.Fuchsia
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
        My.Settings.DesignFormPos = SetFormPos(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim _filename As String = MakeFilename(oProject)
        SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, _filename)
        SaveDesignXML(oProjectDesign, My.Settings.DesignFilePath, _filename)

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
        isLoading = True
        ChangeMagnification(Math.Round(magnification * MAG_STEP, 2, MidpointRounding.AwayFromZero))

        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
        ' DisplayImage(oDesignBitmap)

    End Sub

    Private Sub BtnShrink_Click(sender As Object, e As EventArgs) Handles BtnShrink.Click
        isLoading = True
        ChangeMagnification(Math.Round(magnification / MAG_STEP, 2, MidpointRounding.AwayFromZero))

        DrawGrid(oProject, oProjectDesign)
        CalculateOffsetForCentre(oDesignBitmap)
        isLoading = False
        '     DisplayImage(oDesignBitmap)

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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

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

        Dim cel_x As Integer = Math.Floor(e.X / iPpc) - iXOffset + topcorner.X
        Dim cel_y As Integer = Math.Floor(e.Y / iPpc) - iYOffset + topcorner.Y
        Dim celLocation As New Point(cel_x, cel_y)
        Dim _xrmd As Integer = e.X Mod iPpc
        Dim _yrmd As Integer = e.Y Mod iPpc

        Dim _qtr As BlockQuarter

        Select Case True
            Case _xrmd > iPpc / 2 AndAlso _yrmd > iPpc / 2
                _qtr = BlockQuarter.BottomRight
                Label3.Text = "BR"
            Case _xrmd > iPpc / 2 AndAlso _yrmd <= iPpc / 2
                _qtr = BlockQuarter.TopRight
                Label3.Text = "TR"
            Case _xrmd <= iPpc / 2 AndAlso _yrmd > iPpc / 2
                _qtr = BlockQuarter.BottomLeft
                Label3.Text = "BL"
            Case _xrmd <= iPpc / 2 AndAlso _yrmd <= iPpc / 2
                _qtr = BlockQuarter.TopLeft
                Label3.Text = "TL"
        End Select

        Dim isRemove As Boolean = e.Button = MouseButtons.Right

        If isRemove Then


            If oCurrentAction = DesignAction.Bead Or oCurrentAction = DesignAction.Knot Then
                Dim _exists As Knot = FindKnot(celLocation, _qtr)
                If _exists IsNot Nothing Then
                    oProjectDesign.Knots.Remove(_exists)
                End If
            Else
                Dim _exists As BlockStitch = FindBlockstitch(celLocation)
                If _exists.IsLoaded Then
                    oProjectDesign.BlockStitches.Remove(_exists)
                End If
            End If



        Else

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
                    StartBackstitch()
                Case DesignAction.BackStitchFullThin
                    StartBackstitch()
                Case DesignAction.BackstitchHalfThin
                    StartBackstitch()
                Case DesignAction.BackStitchHalfThick
                    StartBackstitch()
                Case DesignAction.Bead
                    AddKnot(celLocation, _qtr, True, isRemove)
                Case DesignAction.Knot
                    AddKnot(celLocation, _qtr, False, isRemove)
                Case DesignAction.FullBlockstitch
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
                Case DesignAction.HalfBlockstitchBack
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
                Case DesignAction.HalfBlockstitchForward
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
                Case DesignAction.QuarterBlockstitchBottomRight
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomRight)
                Case DesignAction.QuarterBlockstitchBottonLeft
                    AddQuarterBlockstitch(celLocation, BlockQuarter.BottomLeft)
                Case DesignAction.QuarterBlockstitchTopLeft
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopLeft)
                Case DesignAction.QuarterBlockstitchTopRight
                    AddQuarterBlockstitch(celLocation, BlockQuarter.TopRight)
                Case DesignAction.ThreeQuarterBlockstitchBottomLeft
                Case DesignAction.ThreeQuarterBlockstitchBottomRight
                Case DesignAction.ThreeQuarterBlockstitchTopLeft
                Case DesignAction.ThreeQuarterBlockstitchTopRight
                Case DesignAction.BlockstitchQuarters
            End Select
        End If
        DrawGrid(oProject, oProjectDesign)
        DisplayImage(oDesignBitmap, iXOffset, iYOffset)
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

    Private Sub AddKnot(pActionPoint As Point, pQtr As BlockQuarter, pIsBead As Boolean, pIsRemove As Boolean)
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

        Select Case oCurrentAction
            Case DesignAction.BackstitchFullThick
                DrawBackstitch()
            Case DesignAction.BackStitchFullThin
                DrawBackstitch()
            Case DesignAction.BackstitchHalfThin
                DrawBackstitch()
            Case DesignAction.BackStitchHalfThick
                DrawBackstitch()
            Case DesignAction.Bead

            Case DesignAction.Knot

            Case DesignAction.FullBlockstitch

            Case DesignAction.HalfBlockstitchBack
            Case DesignAction.HalfBlockstitchForward
            Case DesignAction.QuarterBlockstitchBottomRight
            Case DesignAction.QuarterBlockstitchBottonLeft
            Case DesignAction.QuarterBlockstitchTopLeft
            Case DesignAction.QuarterBlockstitchTopRight
            Case DesignAction.ThreeQuarterBlockstitchBottomLeft
            Case DesignAction.ThreeQuarterBlockstitchBottomRight
            Case DesignAction.ThreeQuarterBlockstitchTopLeft
            Case DesignAction.ThreeQuarterBlockstitchTopRight
            Case DesignAction.BlockstitchQuarters

        End Select
    End Sub

    Private Sub PicDesign_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDesign.MouseUp
        Select Case oCurrentAction
            Case DesignAction.BackstitchFullThick
                EndBackstitch()
            Case DesignAction.BackStitchFullThin
                EndBackstitch()
            Case DesignAction.BackstitchHalfThin
                EndBackstitch()
            Case DesignAction.BackStitchHalfThick
                EndBackstitch()
        End Select

    End Sub
    Private Sub DrawBackstitch()

    End Sub
    Private Sub StartBackstitch()

    End Sub
    Private Sub EndBackstitch()

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
End Class
