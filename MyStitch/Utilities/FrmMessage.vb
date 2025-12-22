' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Public Class FrmMessage
#Region "variables"
    Private isDetailShown As Boolean = False
#End Region
#Region "properties"
    Private _messageText As String
    Private _source As String
    Private _isShowClose As Boolean
    Private _isLogged As Boolean
    Public WriteOnly Property IsLogged() As Boolean
        Set(ByVal value As Boolean)
            _isLogged = value
        End Set
    End Property
    Public WriteOnly Property IsShowClose() As Boolean
        Set(ByVal value As Boolean)
            _isShowClose = value
        End Set
    End Property
    Public WriteOnly Property MessageText() As String
        Set(ByVal value As String)
            _messageText = value
        End Set
    End Property
    Public WriteOnly Property Source() As String
        Set(ByVal value As String)
            _source = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub FrmMessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TopMost = True
        BtnClose.Visible = _isShowClose
        LblMessage.Text = _messageText
        If _isLogged Then
            LogUtil.LogInfo(_messageText, _source)
        End If
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
#End Region
End Class