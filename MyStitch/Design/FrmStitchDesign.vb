' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Net.Mime.MediaTypeNames
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmStitchDesign
    Private PIXELS_PER_CELL As Integer = 8
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

    Private magnification As Decimal = 1.25
    Private topcorner As Point = New Point(0, 0)

    Private oViewer As ImageViewer = New ImageViewer
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
            oProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(My.Settings.DesignFilePath, oProject.DesignFileName).Build
            If Not oProjectDesign.IsLoaded Then
                oProjectDesign.Rows = oProject.DesignHeight
                oProjectDesign.Columns = oProject.DesignWidth
            End If

            'Create ImageViewer
            oViewer = New ImageViewer(PicDesign, HScrollBar1, VScrollBar1, ZoomTrackBar, LblPct)
            magnification = 1
            'Draw grid onto graphics
            DrawGrid(oProject, oProjectDesign)

            DisplayImage(oDesignBitmap)

        Else
            MsgBox("No project found", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If
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
        Dim ppc As Integer = PIXELS_PER_CELL * magnification
        oDesignBitmap = New Bitmap(CInt(oProjectDesign.Columns * ppc), CInt(oProjectDesign.Rows * ppc))
        '   oDesignBitmap.SetResolution(DPI, DPI)

        'Create graphics from image
        oDesignGraphics = Graphics.FromImage(oDesignBitmap)

        Dim _widthInColumns As Integer = pProjectDesign.Columns
        Dim _heightInRows As Integer = pProjectDesign.Rows
        Dim gap As Integer = ppc
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
            _penWidth = 2
            _penColor = Brushes.DarkGray
            oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
        Next
        For y = 5 To _heightInRows Step 10
            _penWidth = 2
            _penColor = Brushes.DarkGray
            oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
        Next
        For x = 10 To _widthInColumns Step 10
            _penWidth = 2
            _penColor = Brushes.Black
            oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
        Next
        For y = 10 To _heightInRows Step 10
            _penWidth = 2
            _penColor = Brushes.Black
            oDesignGraphics.DrawLine(New Pen(_penColor, _penWidth), New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
        Next
        oDesignGraphics.DrawRectangle(_designBorderPen, New Rectangle(0, 0, Math.Min(gap * _widthInColumns, oDesignBitmap.Width), Math.Min(gap * _heightInRows, oDesignBitmap.Height)))

    End Sub
    Private Sub DisplayImage(pImage As Bitmap)

        Dim ppc As Integer = PIXELS_PER_CELL * magnification
        Dim rect As Rectangle
        Dim picx As Single = ppc * topcorner.X
        Dim picy As Single = ppc * topcorner.Y
        Dim picw As Single = oDesignBitmap.Width - picx
        Dim pich As Single = oDesignBitmap.Height - picy
        rect = New Rectangle(picx, picy, picw, pich)
        Dim myfg As Graphics = PicDesign.CreateGraphics
        myfg.Clear(PicDesign.BackColor)

        Try
            myfg.DrawImage(pImage, 0, 0, rect, GraphicsUnit.Pixel)
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
        SaveDesignJson(oProjectDesign, My.Settings.DesignFilePath, "TestDesign")
        SaveDesignXML(oProjectDesign, My.Settings.DesignFilePath, "TestDesign")

    End Sub

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
        magnification *= 1.2
        DrawGrid(oProject, oProjectDesign)

        DisplayImage(oDesignBitmap)

    End Sub

    Private Sub BtnShrink_Click(sender As Object, e As EventArgs) Handles BtnShrink.Click
        magnification /= 1.2
        DrawGrid(oProject, oProjectDesign)

        DisplayImage(oDesignBitmap)

    End Sub

    Private Sub BtnFullStitch_Click(sender As Object, e As EventArgs) Handles BtnFullStitch.Click

    End Sub

    Private Sub Btn3QtrsTL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTL.Click

    End Sub

    Private Sub Btn3QtrsTR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsTR.Click

    End Sub

    Private Sub Btn3QtrsBR_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBR.Click

    End Sub

    Private Sub Btn3QtrsBL_Click(sender As Object, e As EventArgs) Handles Btn3QtrsBL.Click

    End Sub

    Private Sub BtnHalfForward_Click(sender As Object, e As EventArgs) Handles BtnHalfForward.Click

    End Sub

    Private Sub BtnHalfBack_Click(sender As Object, e As EventArgs) Handles BtnHalfBack.Click

    End Sub

    Private Sub BtnQtrTL_Click(sender As Object, e As EventArgs) Handles BtnQtrTL.Click

    End Sub

    Private Sub BtnQWtrTR_Click(sender As Object, e As EventArgs) Handles BtnQWtrTR.Click

    End Sub

    Private Sub BtnQtrBR_Click(sender As Object, e As EventArgs) Handles BtnQtrBR.Click

    End Sub

    Private Sub BtnQtrBL_Click(sender As Object, e As EventArgs) Handles BtnQtrBL.Click

    End Sub

    Private Sub BtnQuarters_Click(sender As Object, e As EventArgs) Handles BtnQuarters.Click

    End Sub

    Private Sub BtnFullBackstitchThin_Click(sender As Object, e As EventArgs) Handles BtnFullBackstitchThin.Click

    End Sub

    Private Sub BtnHalfBackStitchThin_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThin.Click

    End Sub

    Private Sub BtnFullBcakStitchThick_Click(sender As Object, e As EventArgs) Handles BtnFullBcakStitchThick.Click

    End Sub

    Private Sub BtnHalfBackStitchThick_Click(sender As Object, e As EventArgs) Handles BtnHalfBackStitchThick.Click

    End Sub

    Private Sub BtnKnot_Click(sender As Object, e As EventArgs) Handles BtnKnot.Click

    End Sub

    Private Sub BtnBead_Click(sender As Object, e As EventArgs) Handles BtnBead.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub
    Private Sub HScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        topcorner = New Point(HScrollBar1.Value, topcorner.Y)
        DisplayImage(oDesignBitmap)

    End Sub

    Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        topcorner = New Point(topcorner.X, VScrollBar1.Value)
        DisplayImage(oDesignBitmap)

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
        Dim ppc As Integer = PIXELS_PER_CELL * magnification
        Dim cel_x As Integer = Math.Floor(e.X / ppc) + topcorner.X
        Dim cel_y As Integer = Math.Floor(e.Y / ppc) + topcorner.Y
        Label1.Text = CStr(cel_x)
        Label2.Text = CStr(cel_y)
    End Sub

    Private Sub PicDesign_SizeChanged(sender As Object, e As EventArgs) Handles PicDesign.SizeChanged
        If Not isLoading Then
            If oProject IsNot Nothing AndAlso oProjectDesign IsNot Nothing AndAlso oProject.IsLoaded AndAlso oProjectDesign.IsLoaded Then
                DisplayImage(oDesignBitmap)
            End If
        End If
    End Sub
End Class
