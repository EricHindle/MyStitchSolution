' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Text
Namespace Domain.Objects
    Public Class Brand

#Region "properties"
        Private _BrandId As Integer
        Private _brandName As String
        Public Property BrandName() As String
            Get
                Return _brandName
            End Get
            Set(ByVal value As String)
                _brandName = value
            End Set
        End Property
        Public Property BrandId() As Integer
            Get
                Return _BrandId
            End Get
            Set(ByVal value As Integer)
                _BrandId = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub InitialiseBrand()
            _BrandId = -1
            _brandName = String.Empty
        End Sub
        Public Sub New()
            InitialiseBrand()
        End Sub
        Public Sub New(pId As Integer,
                       pName As String)
            _BrandId = pId
            _brandName = pName
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _BrandId > -1
        End Function
        Public Overrides Function ToString() As String
            Dim _sb As New StringBuilder
            _sb.Append("Brand=[") _
                .Append("BrandId=[").Append(CStr(_BrandId)).Append("], ") _
                .Append("BrandName =[").Append(_brandName).Append("], ") _
                .Append("]]")
            Return _sb.ToString()
        End Function
        Public Function ToSaveString() As String
            Dim _sb As New StringBuilder
            _sb _
                .Append(CStr(_BrandId)).Append(STITCH_DELIM) _
                .Append(_brandName).Append(STITCH_DELIM)
            Return _sb.ToString()
        End Function
#End Region

    End Class
End Namespace