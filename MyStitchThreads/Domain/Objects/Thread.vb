' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class Thread

#Region "properties"
    Private _threadId As Integer
    Private _threadNo As Integer
    Private _colourName As String
    Private _colour As Color
    Public Property Colour() As Color
        Get
            Return _colour
        End Get
        Set(ByVal value As Color)
            _colour = value
        End Set
    End Property
    Public Property ColourName() As String
        Get
            Return _colourName
        End Get
        Set(ByVal value As String)
            _colourName = value
        End Set
    End Property
    Public Property ThreadNo() As Integer
        Get
            Return _threadNo
        End Get
        Set(ByVal value As Integer)
            _threadNo = value
        End Set
    End Property
    Public Property ThreadId() As Integer
        Get
            Return _threadId
        End Get
        Set(ByVal value As Integer)
            _threadId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub InitialiseThread()
        _threadId = -1
        _threadNo = -1
        _colourName = String.Empty
        _colour = Color.White
    End Sub
    Public Sub New()
        InitialiseThread()
    End Sub
    Public Sub New(pId As Integer,
                   pNo As Integer,
                   pColourName As String,
                   pColour As Color)
        _threadId = pId
        _threadNo = pNo
        _colourName = pColourName
        _colour = pColour

    End Sub
    Public Function IsLoaded() As Boolean
        Return _threadId > -1
    End Function
#End Region
#Region "methods"
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("Thread=[") _
            .Append("Id=[") _
            .Append(CStr(_threadId)) _
            .Append("Number=[") _
            .Append(CStr(_threadNo)) _
            .Append("], Colour name=[") _
            .Append(_colourName) _
            .Append("]]")
        Return sb.ToString
    End Function
#End Region
End Class
