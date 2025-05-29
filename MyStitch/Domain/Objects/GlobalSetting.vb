' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects
    Public Class GlobalSetting
#Region "properties"
        Private _name As String
        Private _type As String
        Private _value As String

        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property
        Public Property Type() As String
            Get
                Return _type
            End Get
            Set(ByVal value As String)
                _type = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub Initialise()
            _name = ""
            _type = ""
            _value = ""
        End Sub
        Public Sub New()
            Initialise()
        End Sub
        Public Sub New(pName As String, pType As String, pValue As String)
            _name = pName
            _type = pType
            _value = pValue
        End Sub
#End Region
#Region "methods"
        Public Overrides Function ToString() As String
            Dim sb As New StringBuilder
            sb _
            .Append("GlobalSetting=[") _
            .Append("Name=[") _
            .Append(_name) _
            .Append("], Type=[") _
            .Append(_type) _
            .Append("], Value=[") _
            .Append(_value) _
            .Append("]]")
            Return sb.ToString
        End Function
#End Region
    End Class
End Namespace