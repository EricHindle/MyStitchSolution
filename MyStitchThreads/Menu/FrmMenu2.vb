' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmMenu2
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnProjects_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Hide()
        Using _backupForm As New FrmBackup
            LogUtil.LogInfo("Opening Backup form", MyBase.Name)
            _backupForm.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        InitialiseApplication()
    End Sub

    Private Sub FrmMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)

    End Sub

#End Region
#Region "subroutines"
    Private Sub InitialiseApplication()
        If My.Settings.callUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.callUpgrade = 1
            My.Settings.Save()
        End If
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.StartLogging()
        Dim sConnection As String() = Split(My.Settings.MyStitchConnectionString, ";")
        Dim serverName As String = ""
        Dim dbName As String = ""
        For Each oConn As String In sConnection
            Dim nvp As String() = Split(oConn, "=")
            If nvp.GetUpperBound(0) = 1 Then
                Select Case nvp(0)
                    Case "Data Source"
                        serverName = nvp(1)
                    Case "Initial Catalog"
                        dbName = nvp(1)
                End Select
            End If
        Next
        Dim _runtime As List(Of String) = {My.Application.Info.Title & " version " & My.Application.Info.Version.ToString,
                                            "Computer name : " & My.Computer.Name,
                                            "Data connection: ",
                                            "   server=" & serverName,
                                            "   database=" & dbName,
                                            "Application path is " & My.Application.Info.DirectoryPath}.ToList
        For Each _rt As String In _runtime
            LogUtil.Info(_rt, MyBase.Name)
        Next

    End Sub

    Private Sub BtnBuildCards_Click(sender As Object, e As EventArgs)
        Hide()
        Using _build As New FrmBuildThreadCards
            LogUtil.Info("Opening Build Cards Form", MyBase.Name)
            _build.ShowDialog()
        End Using
        Show()
    End Sub

#End Region
End Class