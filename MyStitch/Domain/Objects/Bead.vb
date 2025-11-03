' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Namespace Domain.Objects
    Public Class Bead
        Inherits Thread

#Region "properties"

        Public Property BeadNo() As String
            Get
                Return _threadNo
            End Get
            Set(ByVal value As String)
                _threadNo = value
            End Set
        End Property
        Public Property BeadId() As Integer
            Get
                Return _threadId
            End Get
            Set(ByVal value As Integer)
                _threadId = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub InitialiseBead()
            _threadId = -1
            _threadNo = String.Empty
            _colourName = String.Empty
            _colour = Color.White
            _sortNumber = -1
            _stock_level = 0
            _brandId = -1
        End Sub
        Public Sub New()
            InitialiseBead()
        End Sub
        Public Sub New(pId As Integer,
                       pNo As String,
                       pColourName As String,
                       pColour As Color,
                       pStock As Integer,
                       pBrandId As Integer)
            _threadId = pId
            _threadNo = pNo
            _colourName = pColourName
            _colour = pColour
            _sortNumber = MakeSortNumber(pNo, pId)
            _stock_level = pStock
            _brandId = pBrandId
            '          LogUtil.Info(Me.ToString, "bead")
        End Sub
#End Region
#Region "methods"
#End Region
    End Class
End Namespace

