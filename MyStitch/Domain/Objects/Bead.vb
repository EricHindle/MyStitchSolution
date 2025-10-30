' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports System.Text.RegularExpressions
Namespace Domain.Objects
    Public Class Bead

#Region "properties"
        Private _beadId As Integer
        Private _beadNo As String
        Private _colourName As String
        Private _colour As Color
        Private _sortNumber As Integer
        Private _stock_level As Integer
        Private _brandId As Integer
        Public Property BrandId() As Integer
            Get
                Return _brandId
            End Get
            Set(ByVal value As Integer)
                _brandId = value
            End Set
        End Property
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
        Public Property beadNo() As String
            Get
                Return _beadNo
            End Get
            Set(ByVal value As String)
                _beadNo = value
            End Set
        End Property
        Public Property beadId() As Integer
            Get
                Return _beadId
            End Get
            Set(ByVal value As Integer)
                _beadId = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub InitialiseBead()
            _beadId = -1
            _beadNo = String.Empty
            _colourName = String.Empty
            _colour = Color.White
            _sortNumber = -1
            _stock_level = 0
            _brandId = -1
        End Sub
        Public Sub New()
            Initialisebead()
        End Sub
        Public Sub New(pId As Integer,
                       pNo As String,
                       pColourName As String,
                       pColour As Color,
                       pStock As Integer,
                       pBrandId As Integer)
            _beadId = pId
            _beadNo = pNo
            _colourName = pColourName
            _colour = pColour
            _sortNumber = MakeSortNumber(pNo, pId)
            _stock_level = pStock
            _brandId = pBrandId
            '          LogUtil.Info(Me.ToString, "bead")
        End Sub
#End Region
#Region "methods"
        Public Function IsLoaded() As Boolean
            Return _beadId > -1
        End Function
        Public Overrides Function ToString() As String
            Dim _sb As New StringBuilder
            _sb.Append("bead=[") _
                .Append("beadId=[").Append(CStr(_beadId)).Append("], ") _
                .Append("beadNo =[").Append(_beadNo).Append("], ") _
                .Append("Colour name =[").Append(_colourName).Append("], ") _
                .Append("Sort number =[").Append(_sortNumber).Append("], ") _
                .Append("Stock level =[").Append(CStr(_stock_level)) _
                .Append("Brand id =[").Append(CStr(_brandId)) _
                .Append("]]")
            Return _sb.ToString()
        End Function
        '
        ' Create a number that can be used to sort beads by the bead number in a list
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
        Public Function ToSaveString() As String
            Dim _sb As New StringBuilder
            _sb _
                .Append(CStr(_beadId)).Append(STITCH_DELIM) _
                .Append(_beadNo).Append(STITCH_DELIM) _
                .Append(_colourName).Append(STITCH_DELIM) _
                .Append(CStr(_colour.ToArgb)).Append(STITCH_DELIM) _
                .Append(CStr(_sortNumber)).Append(STITCH_DELIM) _
                .Append(CStr(_stock_level)).Append(STITCH_DELIM) _
                .Append(CStr(_brandId))
            Return _sb.ToString()
        End Function
#End Region
    End Class
End Namespace

