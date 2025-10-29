' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmStitchDisplayStyle
    Private Sub FrmStitchDisplayStyle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening design", MyBase.Name)
        GetFormPos(Me, My.Settings.StitchDisplayStyleFormPos)
        CbDesignStitchDisplay.SelectedIndex = My.Settings.DesignStitchDisplay
        CbPaletteStitchDisplay.SelectedIndex = My.Settings.PaletteStitchDisplay
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        My.Settings.DesignStitchDisplay = CbDesignStitchDisplay.SelectedIndex
        My.Settings.PaletteStitchDisplay = CbPaletteStitchDisplay.SelectedIndex
        My.Settings.Save()
        Close()
    End Sub
    Private Sub FrmStitchDisplayStyle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.StitchDisplayStyleFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
End Class