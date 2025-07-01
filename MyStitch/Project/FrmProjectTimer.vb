' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmProjectTimer
    Private oStartTime As DateTime
    Private oPrevMinutes As Integer
    Private oEndTime As DateTime
    Private oProject As Project
    Private IsSaveTime As Boolean
    Public Property Project() As Project
        Get
            Return oProject
        End Get
        Set(ByVal value As Project)
            oProject = value
        End Set
    End Property
    Private Sub FrmProjectTimer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Opening timer", MyBase.Name)
        GetFormPos(Me, My.Settings.ProjectTimerFormPos)
        If oProject.IsLoaded Then
            oPrevMinutes = oProject.TotalMinutes
        End If
        If My.Settings.isTimerAutoStart Then
            Timer1.Enabled = True
            oStartTime = Now
            BtnStart.Enabled = False
            IsSaveTime = My.Settings.isTimerAutoSave
        Else
            BtnStart.Enabled = True
        End If
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        IsSaveTime = False
        Close()
    End Sub

    Private Sub FrmProjectTimer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oEndTime = Now
        If IsSaveTime Then
            SaveTime()
        End If
        My.Settings.ProjectTimerFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub SaveTime()
        Dim _minutesAdded As Integer = Math.Ceiling(oEndTime.Subtract(oStartTime).TotalMinutes)
        Dim _workPeriod As ProjectWorkTime = ProjectWorkTimeBuilder.AProjectWorkTime.StartingWithNothing _
            .WithProjectId(oProject.ProjectId) _
            .WithStarted(oStartTime) _
            .WithEnded(oEndTime) _
            .WithMinutes(_minutesAdded) _
            .Build
        InsertProjectWorkTime(_workPeriod)
        oProject.TotalMinutes += _minutesAdded
        oProject.DateEnded = oEndTime
        If oProject.DateStarted = Date.MinValue Then
            oProject.DateStarted = oStartTime
        End If
        UpdateProjectTotalTime(oProject)
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        Timer1.Enabled = True
        oStartTime = Now
        BtnStart.Enabled = False
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        Timer1.Enabled = False
        BtnStart.Enabled = True
        IsSaveTime = True
        Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim elapsedTime As TimeSpan = Now.Subtract(oStartTime)
        Dim totalElapsedTime As TimeSpan = elapsedTime.Add(TimeSpan.FromMinutes(oPrevMinutes))
        LblElapsedTime.Text = elapsedTime.Hours.ToString("D2") & ":" & elapsedTime.Minutes.ToString("D2") & ":" & elapsedTime.Seconds.ToString("D2")
        LblTotalElapsedTime.Text = totalElapsedTime.Hours.ToString("D2") & ":" & totalElapsedTime.Minutes.ToString("D2") & ":" & totalElapsedTime.Seconds.ToString("D2")

    End Sub

End Class