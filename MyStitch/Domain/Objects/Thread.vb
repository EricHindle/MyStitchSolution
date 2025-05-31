' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Namespace Domain.Objects
    Public Class Thread

#Region "properties"
        Private _threadId As Integer
        Private _threadNo As String
        Private _colourName As String
        Private _colour As Color
        Private _sortNumber As Integer
        Private _stock_level As Integer
        Public Property StockLevel() As Integer
            Get
                Return _stock_level
            End Get
            Set(ByVal value As Integer)
                _stock_level = value
            End Set
        End Property
        Public Property SortNumber() As Integer
            Get
                Return _sortNumber
            End Get
            Set(ByVal value As Integer)
                _sortNumber = value
            End Set
        End Property
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
        Public Property ThreadNo() As String
            Get
                Return _threadNo
            End Get
            Set(ByVal value As String)
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
            _threadNo = String.Empty
            _colourName = String.Empty
            _colour = Color.White
            _sortNumber = -1
            _stock_level = 0
        End Sub
        Public Sub New()
            InitialiseThread()
        End Sub
        Public Sub New(pId As Integer,
                       pNo As String,
                       pColourName As String,
                       pColour As Color,
                       pStock As Integer)
            _threadId = pId
            _threadNo = pNo
            _colourName = pColourName
            _colour = pColour
            _sortNumber = MakeSortNumber(pNo, pId)
            _stock_level = pStock
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _threadId > -1
        End Function
        Public Overrides Function ToString() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
        '
        ' Create a number that can be used to sort threads by the thread number in a list
        '
        Public Shared Function MakeSortNumber(pNo As String, pId As Integer) As Integer
            Dim _int As Integer
            Dim _intNo As Integer
            Dim isInteger As Boolean = Integer.TryParse(pNo, _intNo)
            If isInteger Then
                _int = _intNo
            Else
                Dim _onlynumbers As Integer
                Dim _numbers As String = Regex.Replace(pNo, "[^\d]", "")
                If String.IsNullOrWhiteSpace(_numbers) Then
                    _int = pId + 990000
                Else
                    Dim isOnlyNumbers As Boolean = Integer.TryParse(_numbers, _onlynumbers)
                    _int = _onlynumbers
                End If
            End If
            Return _int
        End Function
#End Region
    End Class
End Namespace
