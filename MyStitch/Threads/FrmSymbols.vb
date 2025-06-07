' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.IO
Imports HindlewareLib.Imaging.ImageUtil
Imports HindlewareLib.Logging
Public Class FrmSymbols
    Private fullFilename As String
    Private Sub Xxx()

        If My.Computer.FileSystem.FileExists(fullFilename) Then
            Dim _imageBytes As Byte() = ConvertImageToBytes(fullFilename)
        End If
    End Sub
    Private Sub BtnImageSel_Click(sender As Object, e As EventArgs) Handles BtnImageSel.Click

    End Sub
    Public Sub LoadSourceImage(pFilename As String, ByRef pPicBox As PictureBox, ByRef pSplitContainer As SplitContainer)
        If String.IsNullOrEmpty(pFilename) Then
            pPicBox.ImageLocation = Nothing
            pSplitContainer.Panel2Collapsed = True
        Else
            pSplitContainer.Panel2Collapsed = False
            Dim fullFilename As String = Path.Combine(My.Settings.ImagePath, pFilename)
            LogUtil.Info("Finding Image " & fullFilename, "ModSources")
            If My.Computer.FileSystem.FileExists(fullFilename) Then
                pPicBox.ImageLocation = fullFilename
            Else
                LogUtil.Info("File " & fullFilename & " does not exist", "ModSources")
            End If
        End If
    End Sub
End Class