' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmPaletteName
    Private _paletteName As String
    Public Property PaletteName() As String
        Get
            Return _paletteName
        End Get
        Set(ByVal value As String)
            _paletteName = value
        End Set
    End Property
    Private Sub BtnCancelPalette_Click(sender As Object, e As EventArgs) Handles BtnCancelPalette.Click
        _paletteName = String.Empty
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub BtnSavePalette_Click(sender As Object, e As EventArgs) Handles BtnSavePalette.Click
        _paletteName = TxtPaletteName.Text
        DialogResult = DialogResult.OK
    End Sub

    Private Sub FrmPaletteName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPaletteName.Text = _paletteName
    End Sub
End Class