' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmStitchDesign
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

    Private _projectId As Integer
    Public WriteOnly Property ProjectId() As Integer
        Set(ByVal value As Integer)
            _projectId = value
        End Set
    End Property

    Private Sub FrmStitchDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Printing Thread Cards", MyBase.Name)
        GetFormPos(Me, My.Settings.DesignFormPos)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub InitialiseForm()
        sourceBitmap = New Bitmap(A4_WIDTH_PIXELS, A4_HEIGHT_PIXELS)
        sourceBitmap.SetResolution(DPI, DPI)
        leftmargin = myPrintDoc.DefaultPageSettings.HardMarginX * 3
        topmargin = myPrintDoc.DefaultPageSettings.HardMarginY * 3
        SetPictureWidth()
        DrawGrid
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
    Private Sub DrawGrid()
        Dim gap As Integer = sourceBitmap.Height / 100
        Dim wct As Integer = sourceBitmap.Width / gap
        _designGraphics = Graphics.FromImage(sourceBitmap)
        _designGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))
        _designGraphics.DrawRectangle(New Pen(Brushes.Black, 2), New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))
        For x = 0 To wct
            Dim penwidth As Integer = 1
            If x Mod 5 = 0 Then
                penwidth = 2
            End If

            If x Mod 10 = 0 Then
                penwidth = 4
            End If
            _designGraphics.DrawLine(New Pen(Brushes.Black, penwidth), New Point(gap * x, 0), New Point(gap * x, sourceBitmap.Height))

        Next
        For y = 0 To 100
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
            _designGraphics.DrawLine(New Pen(Brushes.Black, penwidth), New Point(0, gap * y), New Point(sourceBitmap.Width, gap * y))
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
End Class
