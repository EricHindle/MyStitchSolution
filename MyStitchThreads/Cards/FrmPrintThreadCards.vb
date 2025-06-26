﻿' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Printing
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmPrintThreadCards
    Private Const A4_WIDTH_PIXELS As Integer = 3508
    Private Const A4_HEIGHT_PIXELS As Integer = 2480
    ' image dots per inch
    Private Const DPI As Single = 300.0F
    ' font points per inch
    Private Const PPI As Integer = 72
    Private Const PROJECT_NAME_FONT_SIZE As Integer = 9
    Private Const THREAD_NAME_FONT_SIZE As Integer = 10
    Private Const THREAD_NUMBER_FONT_SIZE As Integer = 18
    Private Const HOLEPUNCH_HOLE_RADIUS As Integer = 35
    Private Const HOLEPUNCH_HOLE_INSET As Integer = 107
    Private Const HOLEPUNCH_HOLE_GAP As Integer = 236
    Private Const FAMILY_NAME As String = "arial"
    Private PROJECT_NAME_BRUSH As Brush = Brushes.Gray
    Private THREAD_NUMBER_BRUSH As Brush = Brushes.Navy
    Private THREAD_NAME_BRUSH As Brush = Brushes.DimGray
    Private LINE_PEN As New Pen(Brushes.Black, 1)
    Private CARD_COLOUR As Brush = Brushes.White
#Region "variables"
    Private _cardGraphics As Graphics
    Private oImageUtil As New HindlewareLib.Imaging.ImageUtil
    Private sourceBitmap As Bitmap
    Private oSelectedProject As Project
    Private isLoading As Boolean
    Private isCardsLoading As Boolean
    Private _nextCol As Integer
    Private leftmargin As Integer
    Private topmargin As Integer
    Private myPrintDoc As New Printing.PrintDocument
#End Region
#Region "handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmPrintThreadCards_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", Name)
        My.Settings.PrintThreadCardsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub FrmPrintThreadCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Printing ProjectThread Cards", MyBase.Name)
        GetFormPos(Me, My.Settings.PrintThreadCardsFormPos)
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
        LoadProjectList(DgvProjects, MyBase.Name)
        LogUtil.ShowStatus("Select a project", LblStatus)
    End Sub
    Private Sub AddProjectRow(oProject As Project)
        Dim oRow As DataGridViewRow = DgvProjects.Rows(DgvProjects.Rows.Add())
        oRow.Cells(projectId.Name).Value = oProject.ProjectId
        oRow.Cells(projectName.Name).Value = oProject.ProjectName
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        Dim _imagefile As String = SaveSourceImage(sourceBitmap)
    End Sub
    Private Sub PnlCardImage_SizeChanged(sender As Object, e As EventArgs) Handles PnlCardImage.SizeChanged
        SetPictureWidth()
    End Sub
    Private Sub SetPictureWidth()
        If sourceBitmap IsNot Nothing Then
            If PnlCardImage.Width > PnlCardImage.Height Then
                PicThreadCard.Width = PicThreadCard.Height * sourceBitmap.Width / sourceBitmap.Height
            Else
                PicThreadCard.Height = PicThreadCard.Width * sourceBitmap.Height / sourceBitmap.Width
            End If
        End If
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Location = New Point((PnlCardImage.Width - PicThreadCard.Width) / 2, PicThreadCard.Top)
    End Sub
    Private Function SaveSourceImage(pImage As Image) As String
        Dim _path As String = My.Settings.ImagePath
        Return SaveSourceImage(pImage, _path, Nothing)
    End Function
    Private Function SaveSourceImage(pImage As Image, pPath As String, pFilename As String) As String
        Dim imageFileName As String = Nothing
        Try
            LogUtil.ShowStatus("Saving image", LblStatus)
            If pImage IsNot Nothing Then
                imageFileName = ImageUtil.SaveImage(pImage, pPath, pFilename, HindlewareLib.Imaging.ImageUtil.ImageType.JPEG)
                LogUtil.ShowStatus("Saved " & imageFileName, LblStatus)
            Else
                LogUtil.ShowStatus("NOT saved image", LblStatus)
            End If
        Catch ex As ArgumentException
            LogUtil.ShowStatus("NOT saved image", LblStatus)
        End Try
        Return imageFileName
    End Function
    Private Function SavePictureBoxImage(ByRef _pictureBox As PictureBox, _width As Integer, _height As Integer) As String
        Dim imageFile As String = Nothing
        Try
            Dim _path As String = "D:/netwyrks/MyStitch/Images/"
            Dim _filename As String = "TestCard.jpg"
            Dim imageFileName As String = HindlewareLib.Imaging.ImageUtil.GetImageFileName(HindlewareLib.Imaging.ImageUtil.OpenOrSave.Save, HindlewareLib.Imaging.ImageUtil.ImageType.JPEG, _path, _filename)
            If Not String.IsNullOrEmpty(imageFileName) Then
                LogUtil.ShowStatus("Saving image from picture box", LblStatus)
                If _pictureBox.Image IsNot Nothing Then
                    oImageUtil.SaveImageFromPictureBox(_pictureBox, _width, _height, imageFileName, HindlewareLib.Imaging.ImageUtil.ImageType.JPEG)
                End If
                imageFile = imageFileName
                LogUtil.ShowStatus("Saved " & imageFileName, LblStatus)
            Else
                LogUtil.ShowStatus("NOT saved image", LblStatus)
            End If
        Catch ex As ArgumentException
            LogUtil.ShowStatus("NOT saved image", LblStatus)
        End Try
        Return imageFile
    End Function
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If oSelectedProject IsNot Nothing Then
            LogUtil.ShowStatus("Printing card", LblStatus, MyBase.Name)
            Dim _paperKind As PaperKind = PaperKind.A4
            myPrintDoc = New PrintDocument
            ' Set default paper size
            For Each ps As Printing.PaperSize In myPrintDoc.PrinterSettings.PaperSizes
                If ps.RawKind = _paperKind Then
                    myPrintDoc.DefaultPageSettings.PaperSize = ps
                    Exit For
                End If
            Next
            ' Set handler to print image 
            AddHandler myPrintDoc.PrintPage, AddressOf OnPrintImage
            ' Set default page settings
            myPrintDoc.DefaultPageSettings.Landscape = True
            myPrintDoc.DefaultPageSettings.Margins.Left = 0
            myPrintDoc.DefaultPageSettings.Margins.Right = 0
            myPrintDoc.DefaultPageSettings.Margins.Top = 0
            myPrintDoc.DefaultPageSettings.Margins.Bottom = 0
            ' Print the image (calls PrintPage handler (see above))
            myPrintDoc.Print()
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True)
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        LogUtil.ShowStatus("Sending card to printer", LblStatus, MyBase.Name)
        'print options
        ' 0 = print to fill available space
        ' 1 =
        ' 2 = print maximum size retaining aspect ratio
        ' 3 = print into half the available space
        ' 4 = print actual size

        ' DRAW THE IMAGE scaled to the print area

        ' Set margins to allow for printers hard margins
        leftmargin = e.PageSettings.HardMarginX * 3
        topmargin = e.PageSettings.HardMarginY * 3
        Dim targetWidth As Integer = sourceBitmap.Width - leftmargin
        Dim targetHeight As Integer = sourceBitmap.Height - topmargin

        ' Print the image, cutting off the left and top parts that the printer cannot print
        e.Graphics.DrawImage(sourceBitmap, 0, 0, New Rectangle(leftmargin, topmargin, targetWidth, targetHeight), GraphicsUnit.Document)
        LogUtil.ShowStatus("Printing done", LblStatus, MyBase.Name)
    End Sub
    Private Sub DgvProjects_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        If Not isLoading Then
            PrepareNewImage()
        End If
    End Sub
    Private Sub PrepareNewImage()
        PrepareNewImage(4)
    End Sub
    Private Sub PrepareNewImage(pColCt As Integer)

        If DgvProjects.SelectedRows.Count > 0 Then
            Dim oRow As DataGridViewRow = DgvProjects.SelectedRows(0)
            Dim _projectId As Integer = oRow.Cells(projectId.Name).Value
            oSelectedProject = GetProjectById(_projectId)
            LoadCardList(_projectId, LbCards, MyBase.Name)
            LogUtil.ShowStatus("Select a card", LblStatus)
            If _LbCards.Items.Count < 4 Then
                NudColCt.Value = 3
            Else
                NudColCt.Value = pColCt
            End If
            InitialiseImage(oSelectedProject.ProjectName)
        End If
    End Sub
    Private Sub InitialiseImage(projectName As String)
        '   Dim _pen1 As New Pen(Brushes.Black, 1)
        sourceBitmap = New Bitmap(A4_WIDTH_PIXELS, A4_HEIGHT_PIXELS)
        sourceBitmap.SetResolution(DPI, DPI)
        _cardGraphics = Graphics.FromImage(sourceBitmap)
        _cardGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))
        ' Dim _projectNameFontSize As Integer = PROJECT_NAME_FONT_SIZE
        '    Dim _textheight As Integer = (PROJECT_NAME_FONT_SIZE * DPI / PPI) * 1.2
        Dim colCt As Integer = NudColCt.Value
        Dim colWidth As Integer = A4_WIDTH_PIXELS / colCt
        '   Dim holeradius As Integer = HOLEPUNCH_HOLE_RADIUS
        '  Dim holeinset As Integer = HOLEPUNCH_HOLE_INSET
        Dim _left_x As Integer
        Dim _right_x As Integer
        Dim _top_y As Integer
        Dim _bottom_y As Integer
        ' Project Name
        For _col As Integer = 1 To colCt
            _left_x = (colWidth * (_col - 1)) + leftmargin
            _top_y = topmargin
            _cardGraphics.DrawString(oSelectedProject.ProjectName, New Font(FAMILY_NAME, PROJECT_NAME_FONT_SIZE, FontStyle.Regular), PROJECT_NAME_BRUSH, New Point(_left_x, _top_y))
        Next
        ' Vertical lines
        _top_y = 0
        _bottom_y = sourceBitmap.Height
        For _col = 1 To colCt - 1
            _left_x = colWidth * _col
            _right_x = _left_x
            _cardGraphics.DrawLine(LINE_PEN, New Point(_left_x, _top_y), New Point(_right_x, _bottom_y))
        Next
        Dim _rowct As Integer = 10
        _left_x = 0
        _right_x = sourceBitmap.Width
        ' Horizontal lines
        Dim _top As Integer = (sourceBitmap.Height - (HOLEPUNCH_HOLE_GAP * (_rowct - 1))) / 2
        For _row As Integer = 0 To _rowct - 1
            _top_y = _top + (HOLEPUNCH_HOLE_GAP * _row)
            _cardGraphics.DrawLine(LINE_PEN, New Point(_left_x, _top_y), New Point(_right_x, _top_y))
            ' Holepunch hole circles
            For _col As Integer = 0 To colCt - 1
                Dim _holetop As Integer = _top + (HOLEPUNCH_HOLE_GAP * (_row)) - HOLEPUNCH_HOLE_RADIUS
                Dim _holeleft As Integer = ((colWidth * _col) + HOLEPUNCH_HOLE_INSET)
                Dim _holerectangle As New Rectangle(New Point(_holeleft, _holetop), New Size(HOLEPUNCH_HOLE_RADIUS * 2, HOLEPUNCH_HOLE_RADIUS * 2))
                _cardGraphics.FillEllipse(CARD_COLOUR, _holerectangle)
                _cardGraphics.DrawEllipse(LINE_PEN, _holerectangle)
            Next
        Next
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Refresh()
        _nextCol = 0
    End Sub
    Private Sub LbCards_SelectedValueChanged(sender As Object, e As EventArgs) Handles LbCards.SelectedIndexChanged
        LogUtil.ClearStatus(LblStatus)
    End Sub
    Private Sub AddCardToImage(pList As List(Of ProjectCardThread))
        Dim oRowCt As Integer = 10
        Dim oColCt As Integer = NudColCt.Value
        Dim oColWidth As Integer = A4_WIDTH_PIXELS / oColCt
        Dim _topMargin As Integer = (sourceBitmap.Height - (HOLEPUNCH_HOLE_GAP * (oRowCt - 1))) / 2
        Dim _left_x As Integer
        Dim _line_y As Integer
        Dim _row As Integer = 0
        For Each _thread As ProjectCardThread In pList
            Dim _projectThread As ProjectThread = GetProjectThread(_thread.Project.ProjectId, _thread.Thread.ThreadId)
            Dim _col As Integer = _nextCol
            _line_y = _topMargin + (HOLEPUNCH_HOLE_GAP * _row)
            _left_x = (oColWidth * _col) + HOLEPUNCH_HOLE_INSET + (HOLEPUNCH_HOLE_RADIUS * 5)
            Dim _textheight As Integer = (THREAD_NUMBER_FONT_SIZE * DPI / PPI) * 1.2
            Dim _textwidth As Integer = _textheight * 2.5
            Dim _textbottom_y As Integer = _line_y - (_textheight / 2)
            Dim _textleft As Integer = _left_x + HOLEPUNCH_HOLE_RADIUS
            Dim _colourbottom_y As Integer = _line_y - _textheight * 0.8
            Dim _colourleft As Integer = _left_x
            Dim _colourheight As Integer = _textheight * 1.6
            Dim _colourwidth As Integer = _textwidth * 1.3
            Dim _nametop As Integer = _line_y + _textheight * 0.8
            Dim _nameleft As Integer = _left_x
            Dim _nameheight As Integer = _textheight * THREAD_NAME_FONT_SIZE / THREAD_NUMBER_FONT_SIZE
            Dim _namewidth As Integer = _colourwidth
            Dim _symboltop As Integer = _colourbottom_y
            Dim _symbolheight As Integer = _colourheight
            Dim _symbolwidth As Integer = _colourheight
            Dim _symbolleft As Integer = _left_x + _colourwidth + (oColWidth * (_col + 1) - _left_x - _colourwidth - _symbolwidth) / 2
            Dim _textrect As New Rectangle(New Point(_textleft, _textbottom_y), New Size(_textwidth, _textheight))
            Dim _colourRect As New Rectangle(New Point(_colourleft, _colourbottom_y), New Size(_colourwidth, _colourheight))
            Dim _symbolBorderRect As New Rectangle(New Point(_symbolleft, _symboltop), New Size(_symbolwidth, _symbolheight))
            Dim _symbolRect As New Rectangle(New Point(_symbolleft + (_symbolwidth / 4), _symboltop + (_symbolwidth / 4)), New Size(_symbolwidth / 2, _symbolheight / 2))

            Dim _brush As Brush = New SolidBrush(_thread.Thread.Colour)
            _cardGraphics.FillRectangle(_brush, _colourRect)
            _cardGraphics.FillRectangle(CARD_COLOUR, _textrect)
            _cardGraphics.DrawString(_thread.Thread.ThreadNo, New Font(FAMILY_NAME, THREAD_NUMBER_FONT_SIZE, FontStyle.Regular), THREAD_NUMBER_BRUSH, New Point(_textleft, _textbottom_y))
            _cardGraphics.DrawString(_thread.Thread.ColourName, New Font(FAMILY_NAME, THREAD_NAME_FONT_SIZE, FontStyle.Regular), THREAD_NAME_BRUSH, New Point(_nameleft, _nametop))
            _cardGraphics.FillRectangle(CARD_COLOUR, _symbolBorderRect)
            _cardGraphics.DrawRectangle(LINE_PEN, _symbolBorderRect)
            _cardGraphics.DrawImage(_projectThread.Symbol, _symbolRect)
            _row += 1
        Next
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Refresh()
    End Sub
    Private Sub BtnAddCard_Click(sender As Object, e As EventArgs) Handles BtnAddCard.Click
        If LbCards.SelectedIndex > -1 Then
            Dim _cardNo As Integer = CInt(LbCards.SelectedItem)
            Dim _threadList As List(Of ProjectCardThread) = GetProjectCardThreadsByProjectCard(oSelectedProject.ProjectId, _cardNo)
            AddCardToImage(_threadList)
            _nextCol += 1
        End If
    End Sub
    Private Sub NudColCt_ValueChanged(sender As Object, e As EventArgs) Handles NudColCt.ValueChanged
        PrepareNewImage(NudColCt.Value)
    End Sub
    Private Sub BtnResetImage_Click(sender As Object, e As EventArgs) Handles BtnResetImage.Click
        PrepareNewImage()
    End Sub
#End Region
End Class
