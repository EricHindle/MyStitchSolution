' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain.Objects
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain
Public Class FrmStitchDesign
    Private Const PIXELS_PER_CELL As Integer = 64
    Private Const A4_WIDTH_PIXELS As Integer = 3508
    Private Const A4_HEIGHT_PIXELS As Integer = 2480
    ' image dots per inch
    Private Const DPI As Single = 300.0F
    ' font points per inch
    Private Const PPI As Integer = 72
    Private LINE_PEN As New Pen(Brushes.Black, 1)

    Private _cardGraphics As Graphics
    Private oImageUtil As New HindlewareLib.Imaging.ImageUtil
    Private sourceBitmap As Bitmap
    Private isLoading As Boolean
    Private leftmargin As Integer
    Private topmargin As Integer
    Private myPrintDoc As New Printing.PrintDocument
    Private _designGraphics As Graphics
    Private _projectDesign As ProjectDesign
    Private _project As Project
    Private _projectId As Integer
    Public WriteOnly Property ProjectId() As Integer
        Set(ByVal value As Integer)
            _projectId = value
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
        _project = GetProjectById(_projectId)
        If _project.IsLoaded Then
            _projectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(My.Settings.DesignFilePath, _project.DesignFileName).Build
            If Not _projectDesign.IsLoaded Then
                _projectDesign.Rows = _project.DesignHeight
                _projectDesign.Columns = _project.DesignWidth
            End If
            sourceBitmap = New Bitmap(_projectDesign.Columns * PIXELS_PER_CELL, _projectDesign.Rows * PIXELS_PER_CELL)
            sourceBitmap.SetResolution(DPI, DPI)
            'leftmargin = myPrintDoc.DefaultPageSettings.HardMarginX * 3
            'topmargin = myPrintDoc.DefaultPageSettings.HardMarginY * 3
            'SetPictureWidth()
            DrawGrid(_projectDesign.Columns, _projectDesign.Rows)
        Else
            MsgBox("No project found", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If
    End Sub

    Private Sub GenTestDesign()
        _projectDesign = New ProjectDesign

        For x = 1 To 10
            Dim _quarters As New List(Of BlockStitchQuarter)
            _projectDesign.BlockStitches.Add(New BlockStitch(New Point(1, 1), _quarters))
            _projectDesign.BackStitches.Add(New BackStitch)
            _projectDesign.Knots.Add(New Knot)
        Next
        _projectDesign.Rows = 10
        _projectDesign.Columns = 15
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
    Private Sub DrawGrid(pWidth As Integer, pHeight As Integer)
        Dim gap As Integer = PIXELS_PER_CELL * magnificationLevel
        Dim wct As Integer = sourceBitmap.Width / gap
        _designGraphics = Graphics.FromImage(sourceBitmap)
        _designGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))
        _designGraphics.DrawRectangle(New Pen(Brushes.Black, 2), New Rectangle(0, 0, Math.Min(gap * pWidth, sourceBitmap.Width), Math.Min(gap * pHeight, sourceBitmap.Height)))

        For x = 0 To pWidth
            Dim penwidth As Integer = 1
            If x Mod 5 = 0 Then
                penwidth = 2
            End If

            If x Mod 10 = 0 Then
                penwidth = 4
            End If
            _designGraphics.DrawLine(New Pen(Brushes.Black, penwidth), New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * pHeight, sourceBitmap.Height)))

        Next
        For y = 0 To pHeight
            Dim penwidth As Integer = 1
            Dim pencolor As Brush = Brushes.LightGray
            If y Mod 5 = 0 Then
                penwidth = 2
                pencolor = Brushes.DarkGray
            End If

            If y Mod 10 = 0 Then
                penwidth = 4
                pencolor = Brushes.Black
            End If
            _designGraphics.DrawLine(New Pen(Brushes.Black, penwidth), New Point(0, gap * y), New Point(Math.Min(gap * pWidth, sourceBitmap.Width), gap * y))
        Next

        PicDesign.Image = sourceBitmap
        PicDesign.Refresh()
    End Sub

    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.DesignFormPos = SetFormPos(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SaveDesignJson(_projectDesign, My.Settings.DesignFilePath, "TestDesign")
        SaveDesignXML(_projectDesign, My.Settings.DesignFilePath, "TestDesign")

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

    Private Sub BtnFill_Click(sender As Object, e As EventArgs) Handles BtnFill.Click

    End Sub

    Private Sub BtnZoom_Click(sender As Object, e As EventArgs) Handles BtnZoom.Click

    End Sub

    Private Sub BtnEnlarge_Click(sender As Object, e As EventArgs) Handles BtnEnlarge.Click
        magnificationLevel *= 1.2
        DrawGrid(_projectDesign.Columns, _projectDesign.Rows)
    End Sub

    Private Sub BtnShrink_Click(sender As Object, e As EventArgs) Handles BtnShrink.Click
        magnificationLevel /= 1.2
        DrawGrid(_projectDesign.Columns, _projectDesign.Rows)
    End Sub

    Private Sub BtnFit_Click(sender As Object, e As EventArgs) Handles BtnFit.Click

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
End Class
