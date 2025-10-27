' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Drawing.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects

Public Class FrmText
#Region "properties"
    Private _selectedProject As Project
    Private _selectedThread As ProjectThread
    Private _stitches As List(Of BlockStitch)
    Public ReadOnly Property Stitches() As List(Of BlockStitch)
        Get
            Return _stitches
        End Get
    End Property
    Public Property SelectedThread() As ProjectThread
        Get
            Return _selectedThread
        End Get
        Set(ByVal value As ProjectThread)
            _selectedThread = value
        End Set
    End Property
    Public Property SelectedProject() As Project
        Get
            Return _selectedProject
        End Get
        Set(ByVal value As Project)
            _selectedProject = value
        End Set
    End Property
#End Region
#Region "variables"
    Private oTextBitmap As Bitmap
    Private oTextGraphics As Graphics
    Private oStitchBitmap As Bitmap
    Private oStitchGraphics As Graphics
    Private oTextFont As Font
    Private oTextColour As Color
    Private oTextBackColour As Color
    Private oStitches As New List(Of BlockStitch)
    Private oTextPenWidth As Integer = 2
    Private oTextPixelsPerCell As Integer = 8
#End Region
#Region "formcontrol handlers"
    Private Sub FrmText_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening print", MyBase.Name)
        GetFormPos(Me, My.Settings.TextFormPos)
        If _selectedProject Is Nothing Then
            LogUtil.Problem("No selected project")
            Close()
        End If
        If _selectedThread Is Nothing Then
            LogUtil.Problem("No selected thread")
            Close()
        End If
        InitialiseForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        _stitches = oStitches
        Me.Close()
    End Sub
    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing...", MyBase.Name)
        My.Settings.TextFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
#End Region
#Region "subroutine"
    Private Sub InitialiseForm()
        _stitches = New List(Of BlockStitch)
        oTextFont = LblFont.Font
        oTextColour = _selectedThread.Thread.Colour
        oTextBackColour = Color.Transparent
        LblColour.ForeColor = oTextColour
        LblColour.BackColor = GetColourFromProject(_selectedProject.FabricColour, oFabricColourList)
        SetFontText()
    End Sub
    Private Sub PlaceText(pText As String)
        oStitches = New List(Of BlockStitch)
        oTextBitmap = New Bitmap(PicText.Width, PicText.Height)
        oTextGraphics = Graphics.FromImage(oTextBitmap)
        oTextGraphics.DrawString(pText, oTextFont, New SolidBrush(LblColour.ForeColor), New Point(0, 0))
        PicText.Invalidate()
        oStitchBitmap = New Bitmap(PicStitches.Width, PicStitches.Height)
        oStitchGraphics = Graphics.FromImage(oStitchBitmap)
        For Each _x As Integer In Enumerable.Range(0, oTextBitmap.Width)
            For Each _y As Integer In Enumerable.Range(0, oTextBitmap.Height)
                Dim _pixelColour As Color = oTextBitmap.GetPixel(_x, _y)
                Dim _argb As Integer = _pixelColour.ToArgb
                If _pixelColour.ToArgb = oTextColour.ToArgb Or _pixelColour.ToArgb = Color.Black.ToArgb Then
                    Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
                    .WithProjectId(_selectedProject.ProjectId) _
                    .WithStitchType(BlockStitchType.Full) _
                    .WithThreadId(_selectedThread.ThreadId) _
                    .Build
                    Dim _blockStitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch) _
                    .WithPosition(New Point(_x, _y)) _
                    .Build
                    oStitches.Add(_blockStitch)
                End If
            Next
        Next
        DrawDesign()
        PicStitches.Invalidate()
    End Sub

    Private Sub DrawDesign()
        DrawStitches
        DrawTextGrid()
    End Sub

    Private Sub DrawStitches()
        For Each _blockstitch In oStitches
            DrawTextBlockStitch(_blockstitch, oStitchGraphics)
        Next
    End Sub

    Private Sub DrawTextGrid()

    End Sub
    Public Sub DrawTextBlockStitch(pBlockStitch As BlockStitch, ByRef pDesignGraphics As Graphics)
        Dim pX As Integer = pBlockStitch.BlockPosition.X * oTextPixelsPerCell
        Dim pY As Integer = pBlockStitch.BlockPosition.Y * oTextPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        Dim _size As New Size(iPixelsPerCell, iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)
        Dim _crossPen As New Pen(New SolidBrush(oTextColour), oTextPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        pDesignGraphics.DrawLine(_crossPen, _tl, _br)
        pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        _crossPen.Dispose()
    End Sub
    Private Sub PicText_Paint(sender As Object, e As PaintEventArgs) Handles PicText.Paint
        If oTextBitmap Is Nothing Then Exit Sub
        Try
            e.Graphics.DrawImage(oTextBitmap, New Point(0, 0))
        Catch ex As Exception
            Throw New ApplicationException("Cannot display the image:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PicStitches_Paint(sender As Object, e As PaintEventArgs) Handles PicStitches.Paint
        If oStitchBitmap Is Nothing Then Exit Sub
        Try
            e.Graphics.DrawImage(oStitchBitmap, New Point(0, 0))
        Catch ex As Exception
            Throw New ApplicationException("Cannot display the image:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub BtnFont_Click(sender As Object, e As EventArgs) Handles BtnFont.Click
        FontDialog1.Font = BtnFont.Font
        FontDialog1.ShowDialog()
        oTextFont = FontDialog1.Font
        SetFontText()
        PlaceText(TxtText.Text)
    End Sub

    Private Sub SetFontText()
        LblFont.Text = oTextFont.FontFamily.Name & ", " & oTextFont.Size & "pt."
        Dim _fontStyles As New List(Of String)
        If oTextFont.Bold Then
            _fontStyles.Add("Bold")
        End If
        If oTextFont.Italic Then
            _fontStyles.Add("Italic")
        End If
        If oTextFont.Strikeout Then
            _fontStyles.Add("Strikeout")
        End If
        If oTextFont.Underline Then
            _fontStyles.Add("Underline")
        End If
        If _fontStyles.Count > 0 Then
            LblFont.Text &= vbCrLf & "Style: " & Join(_fontStyles.ToArray, ", ")
        End If
        LblColour.Font = New Font(oTextFont.FontFamily, 20, oTextFont.Style)
    End Sub
    Private Sub TxtText_TextChanged(sender As Object, e As EventArgs) Handles TxtText.TextChanged
        PlaceText(TxtText.Text)
    End Sub


#End Region
End Class