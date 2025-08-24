' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Namespace Domain.Objects
    Public Class Pallet
#Region "properties"
        Private _palletId As Integer
        Private _palletName As String

        Public Property PalletName() As String
            Get
                Return _palletName
            End Get
            Set(ByVal value As String)
                _palletName = value
            End Set
        End Property
        Public Property PalletId() As Integer
            Get
                Return _palletId
            End Get
            Set(ByVal value As Integer)
                _palletId = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub InitialisePallet()
            _palletId = -1
            _palletName = String.Empty

        End Sub
        Public Sub New()
            InitialisePallet()
        End Sub
        Public Sub New(pId As Integer,
                 pPalletName As String)
            InitialisePallet()
            _palletId = pId
            _palletName = pPalletName
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _palletId > -1
        End Function

#End Region

    End Class
End Namespace
