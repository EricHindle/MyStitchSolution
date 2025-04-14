' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Printing
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports HindlewareLib.Utilities

Public Class FrmThreadCards

#Region "variables"
    Private _cardGraphics As Graphics
    Private oImageUtil As New HindlewareLib.Imaging.ImageUtil
    Private sourceBitmap As Bitmap


#End Region
#Region "handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmThreadCards_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", Name)
        My.Settings.ThreadCardsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub FrmThreadCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Thread Card Generation", MyBase.Name)
        GetFormPos(Me, My.Settings.ThreadCardsFormPos)
        sourceBitmap = New Bitmap(3508, 2480)
        sourceBitmap.SetResolution(300.0F, 300.0F)
        SetPictureWidth()

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        Dim _pen1 As New Pen(Brushes.Black, 1)
        sourceBitmap = New Bitmap(3508, 2480)
        sourceBitmap.SetResolution(300.0F, 300.0F)
        _cardGraphics = Graphics.FromImage(sourceBitmap)

        _cardGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))

        Dim colCt As Integer = 4
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

    Private Sub PicThreadCard_SizeChanged(sender As Object, e As EventArgs) Handles PicThreadCard.SizeChanged
        SetPictureWidth()
    End Sub

    Private Sub SetPictureWidth()
        If sourceBitmap IsNot Nothing Then
            PicThreadCard.Width = PicThreadCard.Height * sourceBitmap.Width / sourceBitmap.Height
        End If
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Location = New Point((Width - PicThreadCard.Width) / 2, PicThreadCard.Top)
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

        Dim _paperKind As PaperKind = PaperKind.A4
        Dim myPrintDoc = New Printing.PrintDocument

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

        Dim leftmargin As Integer = e.PageSettings.HardMarginX * 3
        Dim topmargin As Integer = e.PageSettings.HardMarginY * 3
        Dim targetWidth As Integer = sourceBitmap.Width - leftmargin
        Dim targetHeight As Integer = sourceBitmap.Height - topmargin
        e.Graphics.DrawImage(sourceBitmap, 0, 0, New Rectangle(leftmargin, topmargin, targetWidth, targetHeight), GraphicsUnit.Document)
    End Sub

#End Region
End Class
