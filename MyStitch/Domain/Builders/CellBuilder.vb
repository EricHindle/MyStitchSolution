' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Namespace Domain.Builders

    Public Class CellBuilder
        Private _position As Point
        Private _location As Point
        Private _stitchQtr As BlockQuarter
        Private _knotQtr As BlockQuarter
        Private _knotCellPos As Point
        Private _knotQtrLoc As Point
        Private _stitchQtrLoc As Point

        Private Sub Initialise()
            _position = New Point(0, 0)
            _location = New Point(0, 0)
            _stitchQtr = BlockQuarter.TopLeft
            _knotQtr = BlockQuarter.TopLeft
            _knotCellPos = New Point(0, 0)
            _knotQtrLoc = New Point(0, 0)

        End Sub
        Public Shared Function ACell() As CellBuilder
            Return New CellBuilder
        End Function
        Public Function StartingWithNothing() As CellBuilder
            Initialise()
            Return Me
        End Function
        Public Function WithLocation(pLoc As Point) As CellBuilder
            _location = pLoc
            Return Me
        End Function
        Public Function WithStitchQtr(pQtr As BlockQuarter) As CellBuilder
            _stitchQtr = pQtr
            Return Me
        End Function
        Public Function WithStitchQtrLoc(pLoc As Point) As CellBuilder
            _stitchQtrLoc = pLoc
            Return Me
        End Function
        Public Function WithKnotQuarter(pQtr As BlockQuarter) As CellBuilder
            _knotQtr = pQtr
            Return Me
        End Function
        Public Function WithPosition(pPos As Point) As CellBuilder
            _position = pPos
            Return Me
        End Function
        Public Function WithKnotCellPos(pPos As Point) As CellBuilder
            _knotCellPos = pPos
            Return Me
        End Function
        Public Function WithKnotQtrLoc(pLoc As Point) As CellBuilder
            _knotQtrLoc = pLoc
            Return Me
        End Function
        Public Function Build() As Cell
            Return New Cell(_position, _location, _stitchQtr, _stitchQtrLoc, _knotQtr, _knotCellPos, _knotQtrLoc)
        End Function

    End Class
End Namespace