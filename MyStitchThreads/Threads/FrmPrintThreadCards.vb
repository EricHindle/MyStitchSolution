' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports Microsoft.VisualBasic.Devices

Public Class FrmPrintThreadCards

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
        LogUtil.Info("Thread Card Generation", MyBase.Name)
        GetFormPos(Me, My.Settings.PrintThreadCardsFormPos)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub InitialiseForm()
        sourceBitmap = New Bitmap(3508, 2480)
        sourceBitmap.SetResolution(300.0F, 300.0F)

        leftmargin = myPrintDoc.DefaultPageSettings.HardMarginX * 3
        topmargin = myPrintDoc.DefaultPageSettings.HardMarginY * 3
        SetPictureWidth()
        LoadProjectList()
    End Sub
    Private Sub LoadProjectList()
        LogUtil.LogInfo("Load project list", MyBase.Name)
        DgvProjects.Rows.Clear()
        For Each oproject As Project In GetProjects()
            AddProjectRow(oproject)
        Next
        DgvProjects.ClearSelection()
    End Sub
    Private Sub LoadCardList(pProjectId As Integer)
        LogUtil.LogInfo("Load card list", MyBase.Name)
        isCardsLoading = True

        LbCards.Items.Clear()

        Dim _list As List(Of ProjectThreadCard) = GetProjectThreadCards(pProjectId)
        For Each oProjectCard As ProjectThreadCard In _list
            LbCards.Items.Add(oProjectCard.CardNo)
        Next

        isCardsLoading = False
    End Sub
    Private Sub AddProjectRow(oProject As Project)
        Dim oRow As DataGridViewRow = DgvProjects.Rows(DgvProjects.Rows.Add())
        oRow.Cells(projectId.Name).Value = oProject.ProjectId
        oRow.Cells(projectName.Name).Value = oProject.ProjectName
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        Dim _pen1 As New Pen(Brushes.Black, 1)
        sourceBitmap = New Bitmap(3508, 2480)
        sourceBitmap.SetResolution(300.0F, 300.0F)
        _cardGraphics = Graphics.FromImage(sourceBitmap)

        _cardGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))

        Dim colCt As Integer = NudColCt.Value
        Dim colWidth As Integer = 3508 / colCt
        Dim holeradius As Integer = 35
        Dim holeinset As Integer = 107
        Dim _pt1x As Integer
        Dim _pt2x As Integer
        Dim _pt1y As Integer
        Dim _pt2y As Integer
        For _col = 1 To colCt - 1
            _pt1x = colWidth * _col
            _pt2x = _pt1x
            _pt1y = 0
            _pt2y = sourceBitmap.Height
            _cardGraphics.DrawLine(_pen1, New Point(_pt1x, _pt1y), New Point(_pt2x, _pt2y))
        Next
        Dim _holegap As Integer = 236
        Dim _rowct As Integer = 10
        Dim _top As Integer = (sourceBitmap.Height - (_holegap * (_rowct - 1))) / 2
        For _row As Integer = 0 To _rowct - 1
            _pt1y = _top + (_holegap * _row)
            _cardGraphics.DrawLine(_pen1, New Point(0, _pt1y), New Point(sourceBitmap.Width, _pt1y))
            For _col As Integer = 0 To colCt - 1
                Dim _holetop As Integer = _top + (_holegap * _row) - holeradius
                Dim _holeleft As Integer = ((colWidth * _col) + holeinset)
                Dim _texttop As Integer = _top + (_holegap * _row) - (holeradius * 2)
                Dim _textleft As Integer = ((colWidth * _col) + holeinset + 200)
                Dim _textwidth As Integer = holeradius * 50
                Dim _textheight As Integer = holeradius * 4
                Dim _textrect As New Rectangle(New Point(_textleft, _texttop), New Size(holeradius * 8, holeradius * 4))
                Dim _holerect As New Rectangle(New Point(_holeleft, _holetop), New Size(holeradius * 2, holeradius * 2))
                _cardGraphics.FillEllipse(Brushes.White, _holerect)
                _cardGraphics.DrawEllipse(_pen1, _holerect)
                _cardGraphics.FillRectangle(Brushes.White, _textrect)
                _cardGraphics.DrawString("1234", New Font("arial", 24, FontStyle.Regular), Brushes.Navy, New Point(_textleft, _texttop))
            Next
        Next
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Refresh()
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
            Dim _paperKind As PaperKind = PaperKind.A4
            myPrintDoc = New PrintDocument
            For Each ps As Printing.PaperSize In myPrintDoc.PrinterSettings.PaperSizes
                If ps.RawKind = _paperKind Then
                    myPrintDoc.DefaultPageSettings.PaperSize = ps
                    Exit For
                End If
            Next
            AddHandler myPrintDoc.PrintPage, AddressOf OnPrintImage
            myPrintDoc.DefaultPageSettings.Landscape = True
            myPrintDoc.DefaultPageSettings.Margins.Left = 0
            myPrintDoc.DefaultPageSettings.Margins.Right = 0
            myPrintDoc.DefaultPageSettings.Margins.Top = 0
            myPrintDoc.DefaultPageSettings.Margins.Bottom = 0
            myPrintDoc.Print()
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True)
        End If
    End Sub

#End Region
#Region "subroutines"
    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        'print options
        ' 0 = print to fill available space
        ' 1 =
        ' 2 = print maximum size retaining aspect ratio
        ' 3 = print into half the available space
        ' 4 = print actual size

        ' DRAW THE IMAGE scaled to the print area

        leftmargin = e.PageSettings.HardMarginX * 3
        topmargin = e.PageSettings.HardMarginY * 3
        Dim targetWidth As Integer = sourceBitmap.Width - leftmargin
        Dim targetHeight As Integer = sourceBitmap.Height - topmargin
        e.Graphics.DrawImage(sourceBitmap, 0, 0, New Rectangle(leftmargin, topmargin, targetWidth, targetHeight), GraphicsUnit.Document)
    End Sub

    Private Sub DgvProjects_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        PrepareNewImage()
    End Sub

    Private Sub PrepareNewImage()
        If Not isLoading Then
            If DgvProjects.SelectedRows.Count > 0 Then
                Dim oRow As DataGridViewRow = DgvProjects.SelectedRows(0)
                Dim _projectId As Integer = oRow.Cells(projectId.Name).Value
                oSelectedProject = GetProjectById(_projectId)
                LoadCardList(_projectId)
                InitialiseImage(oSelectedProject.ProjectName)
            End If
        End If
    End Sub

    Private Sub InitialiseImage(projectName As String)
        Dim _pen1 As New Pen(Brushes.Black, 1)
        sourceBitmap = New Bitmap(3508, 2480)
        sourceBitmap.SetResolution(300.0F, 300.0F)
        _cardGraphics = Graphics.FromImage(sourceBitmap)
        _cardGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))
        Dim _projectNameFontSize As Integer = 9
        Dim _textheight As Integer = (_projectNameFontSize * 300 / 72) * 1.2
        Dim colCt As Integer = NudColCt.Value
        Dim colWidth As Integer = 3508 / colCt
        Dim holeradius As Integer = 35
        Dim holeinset As Integer = 107
        Dim _pt1x As Integer
        Dim _pt2x As Integer
        Dim _pt1y As Integer
        Dim _pt2y As Integer
        For _col As Integer = 1 To colCt
            _pt1x = (colWidth * (_col - 1)) + leftmargin
            _pt1y = topmargin
            _cardGraphics.DrawString(oSelectedProject.ProjectName, New Font("arial", _projectNameFontSize, FontStyle.Regular), Brushes.DimGray, New Point(_pt1x, _pt1y))

        Next
        For _col = 1 To colCt - 1
            _pt1x = colWidth * _col
            _pt2x = _pt1x
            _pt1y = 0
            _pt2y = sourceBitmap.Height
            _cardGraphics.DrawLine(_pen1, New Point(_pt1x, _pt1y), New Point(_pt2x, _pt2y))
        Next
        Dim _holegap As Integer = 236
        Dim _rowct As Integer = 10
        Dim _top As Integer = (sourceBitmap.Height - (_holegap * (_rowct - 1))) / 2
        For _row As Integer = 0 To _rowct - 1
            _pt1y = _top + (_holegap * _row)
            _cardGraphics.DrawLine(_pen1, New Point(0, _pt1y), New Point(sourceBitmap.Width, _pt1y))
            For _col As Integer = 0 To colCt - 1
                Dim _holetop As Integer = _top + (_holegap * _row) - holeradius
                Dim _holeleft As Integer = ((colWidth * _col) + holeinset)
                Dim _holerect As New Rectangle(New Point(_holeleft, _holetop), New Size(holeradius * 2, holeradius * 2))
                _cardGraphics.FillEllipse(Brushes.White, _holerect)
                _cardGraphics.DrawEllipse(_pen1, _holerect)
            Next
        Next
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Refresh()
        _nextCol = 0
    End Sub

    Private Sub LbCards_SelectedValueChanged(sender As Object, e As EventArgs) Handles LbCards.SelectedIndexChanged
        If Not isCardsLoading Then

        End If
    End Sub
    Private Sub AddCardToImage(pList As List(Of Thread))
        Dim _rowct As Integer = 10
        Dim colCt As Integer = NudColCt.Value
        Dim colWidth As Integer = 3508 / colCt
        Dim _holegap As Integer = 236
        Dim _top As Integer = (sourceBitmap.Height - (_holegap * (_rowct - 1))) / 2

        Dim holeradius As Integer = 35
        Dim holeinset As Integer = 107

        Dim _pt1x As Integer
        Dim _pt1y As Integer
        Dim _pen1 As New Pen(Brushes.Black, 1)
        Dim _row As Integer = 0
        For Each _thread As Thread In pList
            Dim _col As Integer = _nextCol
            _pt1y = _top + (_holegap * _row)
            _pt1x = (colWidth * _col) + holeinset + (holeradius * 5)
            Dim _numberFontSize = 18
            Dim _nameFontSize = 10
            Dim _textheight As Integer = (_numberFontSize * 300 / 72) * 1.2
            Dim _textwidth As Integer = _textheight * 2.5
            Dim _texttop As Integer = _pt1y - (_textheight / 2)
            Dim _textleft As Integer = _pt1x + holeradius
            Dim _colourtop As Integer = _pt1y - _textheight * 0.8
            Dim _colourleft As Integer = _pt1x
            Dim _colourheight As Integer = _textheight * 1.6
            Dim _colourwidth As Integer = _textwidth * 1.3
            Dim _nametop As Integer = _pt1y + _textheight * 0.8
            Dim _nameleft As Integer = _pt1x
            Dim _nameheight As Integer = _textheight * _nameFontSize / _numberFontSize
            Dim _namewidth As Integer = _colourwidth
            Dim _symboltop As Integer = _colourtop
            Dim _symbolheight As Integer = _colourheight
            Dim _symbolwidth As Integer = _colourheight
            '      Dim _symbolleft As Integer = _colourleft + _colourwidth + 50
            Dim _symbolleft As Integer = _pt1x + _colourwidth + (colWidth * (_col + 1) - _pt1x - _colourwidth - _symbolwidth) / 2
            Dim _textrect As New Rectangle(New Point(_textleft, _texttop), New Size(_textwidth, _textheight))
            Dim _colourRect As New Rectangle(New Point(_colourleft, _colourtop), New Size(_colourwidth, _colourheight))
            Dim _symbolRect As New Rectangle(New Point(_symbolleft, _symboltop), New Size(_symbolwidth, _symbolheight))

            Dim _brush As Brush = New SolidBrush(_thread.Colour)
            _cardGraphics.FillRectangle(_brush, _colourRect)
            _cardGraphics.FillRectangle(Brushes.White, _textrect)
            _cardGraphics.DrawString(_thread.ThreadNo, New Font("arial", _numberFontSize, FontStyle.Regular), Brushes.Navy, New Point(_textleft, _texttop))
            _cardGraphics.DrawString(_thread.ColourName, New Font("arial", _nameFontSize, FontStyle.Regular), Brushes.DimGray, New Point(_nameleft, _nametop))
            _cardGraphics.FillRectangle(Brushes.White, _symbolRect)
            _cardGraphics.DrawRectangle(_pen1, _symbolRect)
            _row += 1
        Next
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Refresh()
    End Sub

    Private Sub BtnAddCard_Click(sender As Object, e As EventArgs) Handles BtnAddCard.Click
        If LbCards.SelectedIndex > -1 Then
            Dim _cardNo As Integer = CInt(LbCards.SelectedItem)
            Dim _list As List(Of Thread) = GetThreadCardThreads(oSelectedProject.ProjectId, _cardNo)
            AddCardToImage(_list)
            _nextCol += 1
        End If
    End Sub

    Private Sub NudColCt_ValueChanged(sender As Object, e As EventArgs) Handles NudColCt.ValueChanged
        PrepareNewImage()
    End Sub

    Private Sub BtnResetImage_Click(sender As Object, e As EventArgs) Handles BtnResetImage.Click
        PrepareNewImage()
    End Sub

#End Region
End Class
