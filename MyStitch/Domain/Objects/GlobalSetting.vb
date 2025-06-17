' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports Newtonsoft.Json
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
            '       LogUtil.Info(Me.ToString, "GlobalSetting")
        End Sub
#End Region
#Region "methods"
        Public Overrides Function ToString() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
#End Region
    End Class
End Namespace