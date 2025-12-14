' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Text
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects

Public Class FrmText
#Region "constants"
    Private INITIAL_FONT_SIZE As Integer = 18
    Private INITIAL_FONT_FAMILY As String = "Verdana"
    Private INITIAL_FONT_STYLE As FontStyle = FontStyle.Bold
#End Region
#Region "properties"
    Private _selectedProject As Project
    Private _selectedThread As ProjectThread
    Private _textBlock As TextBlock
    Friend ReadOnly Property TextBlock() As TextBlock
        Get
            Return _textBlock
        End Get
    End Property
    Friend Property SelectedThread() As ProjectThread
        Get
            Return _selectedThread
        End Get
        Set(ByVal value As ProjectThread)
            _selectedThread = value
        End Set
    End Property
    Friend Property SelectedProject() As Project
        Get
            Return _selectedProject
        End Get
        Set(ByVal value As Project)
            _selectedProject = value
        End Set
    End Property
#End Region
#Region "variables"
    Private isComponentInitialized As Boolean
    Private isLoading As Boolean
    Private oTextBitmap As Bitmap
    Private oTextGraphics As Graphics
    Private oStitchBitmap As Bitmap
    Private oStitchGraphics As Graphics
    Private oTextFont As Font
    Private oTextColour As Color
    Private oTextBackColour As Color
    Private oStitches As New List(Of BlockStitch)
    Private iWidth As Integer
    Private iHeight As Integer
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
        iHeight = RemoveBlankRows()
        iWidth = RemoveBlankColumns()
        _textBlock = New TextBlock(oStitches, iWidth, iHeight)
        Me.Close()
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        _textBlock = Nothing
        Close()
    End Sub
    Private Sub FrmStitchDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing...", MyBase.Name)
        My.Settings.TextFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub PicText_Paint(sender As Object, e As PaintEventArgs) Handles PicText.Paint
        If oTextBitmap Is Nothing Then Exit Sub
        Try
            e.Graphics.DrawImage(oTextBitmap, New Point(0, 0))
        Catch ex As Exception
            Throw New ApplicationException("Cannot display the image:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TxtText_TextChanged(sender As Object, e As EventArgs) Handles TxtText.TextChanged
        PlaceText(TxtText.Text)
    End Sub
    Private Sub PicStitches_SizeChanged(sender As Object, e As EventArgs) Handles PicStitches.SizeChanged
        PlaceText(TxtText.Text)
    End Sub
    Private Sub TbPixelsPerCell_ValueChanged(sender As Object, e As EventArgs) Handles TbPixelsPerCell.ValueChanged
        AlterPixelsPerCell(TbPixelsPerCell.Value)
    End Sub
    Private Sub NudPixelsPerCell_ValueChanged(sender As Object, e As EventArgs) Handles NudPixelsPerCell.ValueChanged
        AlterPixelsPerCell(NudPixelsPerCell.Value)
    End Sub
    Private Sub TbFontSize_ValueChanged(sender As Object, e As EventArgs) Handles TbFontSize.ValueChanged
        AlterFontSize(TbFontSize.Value)
    End Sub
    Private Sub NudTextSize_ValueChanged(sender As Object, e As EventArgs) Handles NudTextSize.ValueChanged
        AlterFontSize(NudTextSize.Value)
    End Sub

#End Region
#Region "subroutine"
    Private Sub InitialiseForm()
        isComponentInitialized = True
        isLoading = True
        oStitches = New List(Of BlockStitch)
        oTextFont = New Font(INITIAL_FONT_FAMILY, INITIAL_FONT_SIZE, INITIAL_FONT_STYLE)
        If My.Settings.LastTextFont IsNot Nothing Then
            oTextFont = My.Settings.LastTextFont
        End If
        oTextColour = _selectedThread.Thread.Colour
        oTextBackColour = Color.Transparent
        LblColour.ForeColor = oTextColour
        LblColour.BackColor = GetColourFromProject(_selectedProject.FabricColour, oFabricColourList)
        ApplySelectedFont()
        isLoading = False
    End Sub
    Private Sub PlaceText(pText As String)
        Dim oBackGroundColour As Color = Color.White
        oStitches = New List(Of BlockStitch)
        oTextBitmap = New Bitmap(PicText.Width, PicText.Height)
        For Each _x As Integer In Enumerable.Range(0, oTextBitmap.Width)
            For Each _y As Integer In Enumerable.Range(0, oTextBitmap.Height)
                oTextBitmap.SetPixel(_x, _y, oBackGroundColour)
            Next
        Next
        oTextGraphics = Graphics.FromImage(oTextBitmap)
        oTextGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit
        oTextGraphics.DrawString(pText, oTextFont, New SolidBrush(oTextColour), New Point(0, 0))
        PicText.Invalidate()
        oStitchBitmap = New Bitmap(PicStitches.Width, PicStitches.Height)
        oStitchGraphics = Graphics.FromImage(oStitchBitmap)
        For Each _x As Integer In Enumerable.Range(0, oTextBitmap.Width)
            For Each _y As Integer In Enumerable.Range(0, oTextBitmap.Height)
                Dim _pixelColour As Color = oTextBitmap.GetPixel(_x, _y)
                Dim _argb As Integer = _pixelColour.ToArgb
                If _pixelColour.ToArgb <> oBackGroundColour.ToArgb Then
                    Dim _stitch As Stitch = StitchBuilder.AStitch.StartingWithNothing _
                        .WithProjectId(_selectedProject.ProjectId) _
                        .WithStitchType(BlockStitchType.Full) _
                        .WithThreadId(_selectedThread.ThreadId) _
                        .Build
                    Dim oQuarters As New List(Of BlockStitchQuarter) From {
                    New BlockStitchQuarter(BlockQuarter.TopLeft, 2, _selectedThread.ThreadId),
                    New BlockStitchQuarter(BlockQuarter.TopRight, 2, _selectedThread.ThreadId),
                    New BlockStitchQuarter(BlockQuarter.BottomLeft, 2, _selectedThread.ThreadId),
                    New BlockStitchQuarter(BlockQuarter.BottomRight, 2, _selectedThread.ThreadId)
                    }
                    Dim _blockStitch As BlockStitch = BlockStitchBuilder.ABlockStitch.StartingWith(_stitch) _
                        .WithPosition(New Point(_x, _y)) _
                        .WithQuarters(oQuarters) _
                        .Build
                    oStitches.Add(_blockStitch)
                End If
            Next
        Next
        DrawDesign()
        PicStitches.Invalidate()
    End Sub
    Private Sub DrawDesign()
        DrawStitches()
        DrawTextGrid()
    End Sub
    Private Sub DrawStitches()
        For Each _blockstitch In oStitches
            DrawTextBlockStitch(_blockstitch, oStitchGraphics)
        Next
    End Sub
    Private Sub DrawTextGrid()
        Dim _widthInColumns As Integer = PicStitches.Width / oTextPixelsPerCell
        Dim _heightInRows As Integer = PicStitches.Height / oTextPixelsPerCell
        oGrid1Pen = New Pen(oGrid1Brush, oGrid1width)
        For x = 0 To _widthInColumns
            oStitchGraphics.DrawLine(oGrid1Pen, New Point(oTextPixelsPerCell * x, 0), New Point(oTextPixelsPerCell * x, Math.Min(oTextPixelsPerCell * _heightInRows, PicStitches.Height)))
        Next
        For y = 0 To _heightInRows
            oStitchGraphics.DrawLine(oGrid1Pen, New Point(0, oTextPixelsPerCell * y), New Point(Math.Min(oTextPixelsPerCell * _widthInColumns, PicStitches.Width), oTextPixelsPerCell * y))
        Next
    End Sub
    Public Sub DrawTextBlockStitch(pBlockStitch As BlockStitch, ByRef pDesignGraphics As Graphics)
        Dim pX As Integer = pBlockStitch.BlockPosition.X * oTextPixelsPerCell
        Dim pY As Integer = pBlockStitch.BlockPosition.Y * oTextPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + oTextPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + oTextPixelsPerCell)
        Dim _br As New Point(pX + oTextPixelsPerCell, pY + oTextPixelsPerCell)
        Dim _size As New Size(oTextPixelsPerCell, oTextPixelsPerCell)

        Dim _crossPen As New Pen(New SolidBrush(oTextColour), oTextPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        pDesignGraphics.DrawLine(_crossPen, _tl, _br)
        pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        _crossPen.Dispose()
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
        isLoading = True
        FontDialog1.Font = oTextFont
        FontDialog1.ShowDialog()
        oTextFont = FontDialog1.Font
        ApplySelectedFont()
        My.Settings.LastTextFont = oTextFont
        isLoading = False
    End Sub

    Private Sub ApplySelectedFont()
        TbFontSize.Value = oTextFont.Size
        NudTextSize.Value = oTextFont.Size
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
    Private Sub AlterPixelsPerCell(pNewValue As Integer)
        If isComponentInitialized AndAlso Not isLoading Then
            isLoading = True
            oTextPixelsPerCell = pNewValue
            NudPixelsPerCell.Value = pNewValue
            oTextPenWidth = Math.Max(2, oTextPixelsPerCell / 8)
            PlaceText(TxtText.Text)
            isLoading = False
        End If
    End Sub
    Private Sub AlterFontSize(pNewValue As Integer)
        If isComponentInitialized AndAlso Not isLoading Then
            isLoading = True
            oTextFont = New Font(oTextFont.FontFamily, pNewValue, oTextFont.Style)
            NudTextSize.Value = pNewValue
            SetFontText()
            PlaceText(TxtText.Text)
            My.Settings.LastTextFont = oTextFont
            isLoading = False
        End If
    End Sub
    Private Function RemoveBlankColumns() As Integer
        Dim iFirstX As Integer
        Dim iLastX As Integer
        If oStitches.Count > 0 Then
            iFirstX = oStitches(0).BlockPosition.X
            iLastX = oStitches(0).BlockPosition.X
            For Each _stitch As BlockStitch In oStitches
                iFirstX = Math.Min(iFirstX, _stitch.BlockPosition.X)
                iLastX = Math.Max(iLastX, _stitch.BlockPosition.X)
            Next
            For Each _stitch As BlockStitch In oStitches
                _stitch.BlockPosition = New Point(_stitch.BlockPosition.X - iFirstX, _stitch.BlockPosition.Y)
            Next
        End If
        Return iLastX - iFirstX + 1
    End Function
    Private Function RemoveBlankRows() As Integer
        Dim iFirstY As Integer
        Dim iLastY As Integer
        If oStitches.Count > 0 Then
            iFirstY = oStitches(0).BlockPosition.Y
            iLastY = oStitches(0).BlockPosition.Y
            For Each _stitch As BlockStitch In oStitches
                iFirstY = Math.Min(iFirstY, _stitch.BlockPosition.Y)
                iLastY = Math.Max(iLastY, _stitch.BlockPosition.Y)
            Next
            For Each _stitch As BlockStitch In oStitches
                _stitch.BlockPosition = New Point(_stitch.BlockPosition.X, _stitch.BlockPosition.Y - iFirstY)
            Next
        End If
        Return iLastY - iFirstY + 1
    End Function
#End Region
End Class