' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Namespace Domain.Objects
    Module ModMyStitchClasses
#Region "enum"
        Friend Enum UndoAction
            Add
            Remove
            ChangeThread
        End Enum
#End Region
#Region "classes"
        Friend Class StitchAction
            Private _subjectStitch As Stitch
            Private _doneAction As UndoAction
            Private _newThread As ProjectThread
            Public Property DoneAction() As UndoAction
                Get
                    Return _doneAction
                End Get
                Set(ByVal value As UndoAction)
                    _doneAction = value
                End Set
            End Property
            Public Property Stitch() As Stitch
                Get
                    Return _subjectStitch
                End Get
                Set(ByVal value As Stitch)
                    _subjectStitch = value
                End Set
            End Property
            Public Property NewThread() As ProjectThread
                Get
                    Return _newThread
                End Get
                Set(ByVal value As ProjectThread)
                    _newThread = value
                End Set
            End Property
            Public Sub New(pStitch As Stitch, pAction As UndoAction, pThread As ProjectThread)
                _subjectStitch = pStitch
                _doneAction = pAction
                _newThread = pThread
            End Sub
            Public Overrides Function ToString() As String
                Dim _sb As New StringBuilder
                _sb _
        .Append(_subjectStitch.ToStitchString) _
        .Append(STITCH_DELIM) _
        .Append(CStr(_doneAction))
                Return _sb.ToString
            End Function
        End Class
        Friend Class Page
            Private _topLeft As Point
            Private _bottomRight As Point
            Private _pagePosition As Point
            Private _midCol As Integer
            Private _midRow As Integer
            Private _borders As Boolean()    'top,right,bottom,left
            Private _pageNo As String
            Public Property PageNo() As String
                Get
                    Return _pageNo
                End Get
                Set(ByVal value As String)
                    _pageNo = value
                End Set
            End Property
            Public Property BottomRight() As Point
                Get
                    Return _bottomRight
                End Get
                Set(ByVal value As Point)
                    _bottomRight = value
                End Set
            End Property
            Public Property TopLeft() As Point
                Get
                    Return _topLeft
                End Get
                Set(ByVal value As Point)
                    _topLeft = value
                End Set
            End Property
            Public Property Borders() As Boolean()
                Get
                    Return _borders
                End Get
                Set(ByVal value As Boolean())
                    _borders = value
                End Set
            End Property
            Public Property MidRow() As Integer
                Get
                    Return _midRow
                End Get
                Set(ByVal value As Integer)
                    _midRow = value
                End Set
            End Property
            Public Property MidCol() As Integer
                Get
                    Return _midCol
                End Get
                Set(ByVal value As Integer)
                    _midCol = value
                End Set
            End Property
            Public Property PagePosition() As Point
                Get
                    Return _pagePosition
                End Get
                Set(ByVal value As Point)
                    _pagePosition = value
                End Set
            End Property
            Public Sub New()
                Initialise()
            End Sub
            Private Sub Initialise()
                _topLeft = New Point(0, 0)
                _bottomRight = New Point(0, 0)
                _pagePosition = New Point(0, 0)
                _midCol = -1
                _midRow = -1
                _borders = {False, False, False, False}
            End Sub
            Public Function Clone() As Page
                Dim _clone As New Page
                With _clone
                    .TopLeft = _topLeft
                    .BottomRight = _bottomRight
                    .PagePosition = _pagePosition
                    .MidCol = _midCol
                    .MidRow = _midRow
                    .Borders = _borders
                    .PageNo = _pageNo
                End With
                Return _clone
            End Function
        End Class

#End Region
    End Module
End Namespace
