' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmThreadCards

#Region "variables"

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

    End Sub

#End Region
#Region "subroutines"

#End Region
End Class


