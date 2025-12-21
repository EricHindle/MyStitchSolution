' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging
Public Class FrmCriticalError
#Region "variables"
    Private isDetailShown As Boolean = False
#End Region
#Region "properties"
    Private _errorText As String
    Private _source As String
    Private _exception As ApplicationException
    Public Property Exception() As ApplicationException
        Get
            Return _exception
        End Get
        Set(ByVal value As ApplicationException)
            _exception = value
        End Set
    End Property
    Public Property Source() As String
        Get
            Return _source
        End Get
        Set(ByVal value As String)
            _source = value
        End Set
    End Property
    Public Property ErrorText() As String
        Get
            Return _errorText
        End Get
        Set(ByVal value As String)
            _errorText = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub FrmCriticalError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = If(isDetailShown, 200, 70)
        Me.TopMost = True
        LblError.Text = _errorText
        LblDetails.Text = _exception.Message & vbCrLf & If(_exception.InnerException IsNot Nothing, _exception.InnerException.Message, "")
        LogUtil.LogStatus(_errorText & " : " & LblDetails.Text, _source, TraceEventType.Critical)
        Beep()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnDetail_Click(sender As Object, e As EventArgs) Handles BtnDetail.Click
        isDetailShown = Not isDetailShown
        Me.Height = If(isDetailShown, 200, 70)
        BtnDetail.Text = If(isDetailShown, "Hide Detail ", "Show Detail")
    End Sub
#End Region
End Class