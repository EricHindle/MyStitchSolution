' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Imaging

Public Class FrmColourCapture
    Private _selectedColour As Color = Color.White
    Public Property SelectedColour() As Color
        Get
            Return _selectedColour
        End Get
        Set(ByVal value As Color)
            _selectedColour = value
        End Set
    End Property

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles Piccolour.DoubleClick
        If Clipboard.ContainsImage Then
            Piccolour.Image = Clipboard.GetImage
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles Piccolour.MouseUp
        Dim picBox As PictureBox = CType(sender, PictureBox)

        If e.Button = MouseButtons.Right Then
            Dim _bitmap As Bitmap = picBox.Image
            Dim _color As Color = _bitmap.GetPixel(e.X, e.Y)
            TxtR.Text = CStr(_color.R)
            TxtG.Text = CStr(_color.G)
            TxtB.Text = CStr(_color.B)
            _selectedColour = _color
            LblColour.BackColor = _selectedColour
        End If
    End Sub


    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        ImageUtil.SaveImage(Piccolour.Image, My.Settings.ImagePath, "")
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Dim pFilename As String = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open,, My.Settings.ImagePath)
        Piccolour.Image = Image.FromFile(pFilename)
    End Sub
End Class