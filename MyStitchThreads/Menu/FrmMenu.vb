' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmMenu
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnProjects_Click(sender As Object, e As EventArgs) Handles BtnProjects.Click
        Hide()
        Using _projects As New FrmProject
            LogUtil.LogInfo("Opening projects form", MyBase.Name)
            _projects.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnPrintCards_Click(sender As Object, e As EventArgs) Handles BtnPrintCards.Click
        Hide()
        Using _print As New FrmPrintThreadCards
            LogUtil.Info("Opening Print Form", MyBase.Name)
            _print.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnThreads_Click(sender As Object, e As EventArgs) Handles BtnThreads.Click
        Hide()
        LogUtil.Info("Opening Threads form", MyBase.Name)
        Using _threads As New FrmThread
            _threads.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnProjectThreads_Click(sender As Object, e As EventArgs) Handles BtnProjectThreads.Click
        Hide()
        LogUtil.Info("Opening Project Threads form", MyBase.Name)
        Using _projthreads As New FrmProjectThreads
            _projthreads.ShowDialog()
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

#End Region
End Class