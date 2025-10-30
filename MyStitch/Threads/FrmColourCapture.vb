' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging

Public Class FrmColourCapture
    Private _selectedColour As Color = Color.White
    Private isLoading As Boolean
    Private isSelectingColour As Boolean = False
    Private _threadForm As FrmThread
    Private _beadForm As FrmBeads
    Private IsThread As Boolean
    Public Property BeadForm() As FrmBeads
        Get
            Return _beadForm
        End Get
        Set(ByVal value As FrmBeads)
            _beadForm = value
            IsThread = False
        End Set
    End Property
    Public Property ThreadForm() As FrmThread
        Get
            Return _threadForm
        End Get
        Set(ByVal value As FrmThread)
            _threadForm = value
            IsThread = True
        End Set
    End Property
    Public Property SelectedColour() As Color
        Get
            Return _selectedColour
        End Get
        Set(ByVal value As Color)
            _selectedColour = value
        End Set
    End Property
    Private Sub PictureBox1_DoubleClick(sender As Object, e As MouseEventArgs) Handles Piccolour.DoubleClick
        If e.Button = MouseButtons.Left Then
            If Clipboard.ContainsImage Then
                Piccolour.Image = Clipboard.GetImage
            End If
        End If
    End Sub
    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles Piccolour.MouseUp
        If e.Button = MouseButtons.Right Then
            ShowColourUnderPointer(sender, e)
            isSelectingColour = False
            If IsThread Then
                _threadForm.SetFormColour(_selectedColour)
            Else
                _beadForm.SetFormColour(_selectedColour)
            End If
        End If
    End Sub
    Private Sub ShowColourUnderPointer(sender As Object, e As MouseEventArgs)
        Dim picBox As PictureBox = CType(sender, PictureBox)
        If picBox.Image IsNot Nothing Then
            If e.Button = MouseButtons.Right Then
                Dim _bitmap As Bitmap = picBox.Image
                If e.X >= 0 AndAlso e.Y >= 0 AndAlso e.X < _bitmap.Width AndAlso e.Y < _bitmap.Height Then
                    Dim _color As Color = _bitmap.GetPixel(e.X, e.Y)
                    TxtR.Text = CStr(_color.R)
                    TxtG.Text = CStr(_color.G)
                    TxtB.Text = CStr(_color.B)
                    _selectedColour = _color
                    LblColour.BackColor = _selectedColour
                Else
                    ClearColourDetails()
                End If
            End If
        End If
    End Sub
    Private Sub ClearColourDetails()
        TxtR.Text = String.Empty
        TxtG.Text = String.Empty
        TxtB.Text = String.Empty
        LblColour.BackColor = SystemColors.Control
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        ImageUtil.SaveImage(Piccolour.Image, My.Settings.ImagePath, "")
    End Sub
    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Dim pFilename As String = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open,, My.Settings.ImagePath)
        If Not String.IsNullOrWhiteSpace(pFilename) Then
            Try
                Piccolour.Image = Image.FromFile(pFilename)
            Catch ex As Exception
                LogUtil.ShowStatus("No Filename selected", lblStatus, True)
            End Try
        Else
            LogUtil.ShowStatus("No Filename selected", lblStatus)
        End If
    End Sub
    Private Sub FrmColourCapture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Colour Capture", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.ColourCaptureFormPos)
    End Sub
    Private Sub FrmColourCapture_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)

        My.Settings.ColourCaptureFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub Piccolour_MouseMove(sender As Object, e As MouseEventArgs) Handles Piccolour.MouseMove
        If isSelectingColour Then
            ShowColourUnderPointer(sender, e)
        End If
    End Sub
    Private Sub Piccolour_MouseDown(sender As Object, e As MouseEventArgs) Handles Piccolour.MouseDown
        If e.Button = MouseButtons.Right Then
            isSelectingColour = True
        End If
    End Sub
    Private Sub BtnPasteImage_Click(sender As Object, e As EventArgs) Handles BtnPasteImage.Click
        If Clipboard.ContainsImage Then
            Piccolour.Image = Clipboard.GetImage
        End If
    End Sub
End Class