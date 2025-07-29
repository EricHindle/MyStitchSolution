' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Imaging
Imports System.Windows
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Module ModDesign
#Region "constants"
    Public oFabricColourList As List(Of Color) = {Color.White, Color.Linen, Color.AliceBlue, Color.MistyRose}.ToList
    Public oGridColourList As List(Of Color) = {Color.LightGray, Color.DarkGray, Color.DimGray, Color.Black}.ToList
    Public oCentreColourList As List(Of Color) = {Color.Red, Color.Green, Color.Blue, Color.Black}.ToList
    Public Const PIXELS_PER_CELL As Integer = 8
    Public Const MAGNIFICATION_STEP As Decimal = 1.3
    Public BLACK_THREAD As New Thread(0, "BLACK", "Black", Color.Black, 0)
    Public PALETTE_COLOUR_SIZE As Integer = 55
    Public Const A4_WIDTH_PIXELS As Integer = 3508
    Public Const A4_HEIGHT_PIXELS As Integer = 2480
#End Region
#Region "enum"
    Public Enum StitchDisplayStyle
        Crosses
        Blocks
        ColouredSymbols
        Strokes
        BlackWhiteSymbols
        BlocksWithSymbols
    End Enum
    Public Enum DesignAction
        FullBlockstitch
        HalfBlockstitchForward
        HalfBlockstitchBack
        QuarterBlockstitchTopLeft
        QuarterBlockstitchTopRight
        QuarterBlockstitchBottomRight
        QuarterBlockstitchBottonLeft
        ThreeQuarterBlockstitchTopLeft
        ThreeQuarterBlockstitchTopRight
        ThreeQuarterBlockstitchBottomRight
        ThreeQuarterBlockstitchBottomLeft
        BlockstitchQuarters
        BackStitchFullThin
        BackstitchHalfThin
        BackstitchFullThick
        BackStitchHalfThick
        Knot
        Bead
        Copy
        Cut
        Move
        Paste
        Flip
        Mirror
        Zoom
        Fill
        PickColour
        ChangeColour
        DeleteColour
        Rotate
        Clear
        none
    End Enum
#End Region
#Region "variables"
    Friend oProject As Project
    Friend oProjectDesign As ProjectDesign
    Friend oDesignBitmap As Bitmap
    Friend oDesignGraphics As Graphics
    Friend oCurrentThread As ProjectThread
    Friend oProjectThreads As New List(Of ProjectThread)

    Friend iXOffset As Integer
    Friend iYOffset As Integer
    Friend iPixelsPerCell As Integer
    Friend topcorner As New Point(0, 0)
    Friend dMagnification As Decimal = 1
    Friend oStitchPenWidth As Single = 2
    Friend iOneToOneSize As Size
    Friend iOldHScrollbarValue As Integer = 0
    Friend iOldVScrollbarValue As Integer = 0
    Friend oFabricColour As Color
    Friend oFabricBrush As SolidBrush
    Friend oSelectionPenColour As Color
    Friend oSelectionPenWidth As Single
    Friend oSelectionPenDefaultWidth As Single
    Friend oSelectionPen As Pen
    Friend oGrid1width As Integer = 1
    Friend oGrid1Brush As Brush = Brushes.LightGray
    Friend oGrid1Pen = New Pen(oGrid1Brush, oGrid1width)
    Friend oGrid5width As Integer = 1
    Friend oGrid5Brush As Brush = Brushes.DarkGray
    Friend oGrid5Pen = New Pen(oGrid5Brush, oGrid5width)
    Friend oGrid10width As Integer = 1
    Friend oGrid10Brush As Brush = Brushes.Black
    Friend oGrid10Pen = New Pen(oGrid10Brush, oGrid10width)
    Friend oCentrePenWidth As Integer
    Friend oCentrePenDefaultWidth As Integer
    Friend oCentrePenColor As Color
    Friend oCentrePen As Pen
    Friend oCentreBrush As SolidBrush
    Friend oBackstitchWidth As Integer
    Friend oBackstitchPenDefaultWidth As Integer
    Friend isBackstitchWidthVariable As Boolean
    Friend isCentreWidthVariable As Boolean
    Friend isSelectionWidthVariable As Boolean
    Friend oVariableWidthFraction As Integer
    Friend isSingleColour As Boolean

    Friend isCentreOn As Boolean
    Friend isGridOn As Boolean
    Friend isPrintCentreOn As Boolean
    Friend isPrintGridOn As Boolean
    Friend oStitchDisplayStyle As StitchDisplayStyle
#End Region
#Region "functions"
    Public Sub DisplayImage(pImage As Bitmap, pX As Integer, pY As Integer, e As PaintEventArgs)
        If oDesignBitmap Is Nothing Then Exit Sub
        Dim rect As Rectangle
        Dim picx As Single = iPixelsPerCell * topcorner.X
        Dim picy As Single = iPixelsPerCell * topcorner.Y
        Dim picw As Single = oDesignBitmap.Width - picx
        Dim pich As Single = oDesignBitmap.Height - picy
        Dim atX As Single = pX * iPixelsPerCell
        Dim atY As Single = pY * iPixelsPerCell

        rect = New Rectangle(picx, picy, picw, pich)

        Try
            e.Graphics.DrawImage(pImage, atX, atY, rect, GraphicsUnit.Pixel)
        Catch ex As Exception
            Throw New ApplicationException("Cannot draw the coupon:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function LoadProjectDesignFromFile(pProject As Project, pPictureBox As PictureBox, pIsGridOn As Boolean, pIsCentreOn As Boolean)
        oFabricColour = GetColourFromProject(oProject.FabricColour, oFabricColourList)
        oFabricBrush = New SolidBrush(oFabricColour)
        Dim oDesignString As String = OpenDesignFile(My.Settings.DesignFilePath, MakeFilename(pProject))
        If String.IsNullOrEmpty(oDesignString) Then
            oProjectDesign = New ProjectDesign
        Else
            oProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(oDesignString).Build
        End If
        oProjectDesign.ProjectId = pProject.ProjectId
        If Not oProjectDesign.IsLoaded Then
            oProjectDesign.Rows = pProject.DesignHeight
            oProjectDesign.Columns = pProject.DesignWidth
        End If
        SetInitialMagnification(pPictureBox)
        oGrid1width = My.Settings.Grid1Thickness
        oGrid5width = My.Settings.Grid5Thickness
        oGrid10width = My.Settings.Grid10Thickness
        oGrid1Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid1Colour, oGridColourList))
        oGrid5Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid5Colour, oGridColourList))
        oGrid10Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid10Colour, oGridColourList))
        oCentrePenWidth = My.Settings.CentrelineWidth
        oCentrePenColor = My.Settings.CentrelineColour
        oCentrePen = New Pen(oCentrePenColor, oCentrePenWidth)
        RedrawDesign(pPictureBox, pIsGridOn, pIsCentreOn)
        Return oProjectDesign
    End Function
    Private Sub SetInitialMagnification(pPictureBox As PictureBox)
        ChangeMagnification(1)
        Dim _widthRatio As Decimal = Math.Round(pPictureBox.Width / iOneToOneSize.Width, 2, MidpointRounding.AwayFromZero)
        Dim _heightRatio As Decimal = Math.Round(pPictureBox.Height / iOneToOneSize.Height, 2, MidpointRounding.AwayFromZero)
        If iOneToOneSize.Width <= pPictureBox.Width Then
            If iOneToOneSize.Height > pPictureBox.Height Then
                ChangeMagnification(_heightRatio)
            End If
        Else
            If iOneToOneSize.Height > pPictureBox.Height Then
                If _widthRatio < _heightRatio Then
                    ChangeMagnification(_widthRatio)
                Else
                    ChangeMagnification(_heightRatio)
                End If
            Else
                ChangeMagnification(_widthRatio)
            End If
        End If
    End Sub
    Public Sub ChangeMagnification(pNewValue As Decimal)
        dMagnification = pNewValue
        iPixelsPerCell = Math.Floor(PIXELS_PER_CELL * dMagnification)
        iOneToOneSize = New Size(oProjectDesign.Columns * iPixelsPerCell, oProjectDesign.Rows * iPixelsPerCell)
    End Sub
    Public Sub RedrawDesign(pPicturebox As PictureBox, pIsGridOn As Boolean, pIsCentreOn As Boolean)
        RedrawDesign(pPicturebox, True, pIsGridOn, pIsCentreOn)
    End Sub
    Public Sub RedrawDesign(pPicturebox As PictureBox, pIsReCentre As Boolean, pIsGridOn As Boolean, pIsCentreOn As Boolean)
        ' Create image the size of the design
        oDesignBitmap = New Bitmap(CInt(oProjectDesign.Columns * iPixelsPerCell), CInt(oProjectDesign.Rows * iPixelsPerCell))
        If pIsReCentre Then
            CalculateOffsetForCentre(oDesignBitmap, pPicturebox)
        End If
        'Draw grid onto graphics
        'Create graphics from image
        oDesignGraphics = Graphics.FromImage(oDesignBitmap)
        oDesignGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        oDesignGraphics.FillRectangle(oFabricBrush, New Rectangle(0, 0, oDesignBitmap.Width, oDesignBitmap.Height))
        FillBeforeGrid()
        DrawGrid(oProjectDesign, pIsGridOn, pIsCentreOn)
        FillAfterGrid()
        pPicturebox.Invalidate()
    End Sub
    Public Sub FillBeforeGrid()
        If My.Settings.IsShowBlockstitches Then
            For Each _blockstitch In oProjectDesign.BlockStitches
                If _blockstitch.IsLoaded Then
                    If Not isSingleColour OrElse _blockstitch.ProjThread.Thread.Colour.ToArgb = oCurrentThread.Thread.Colour.ToArgb Then
                        Select Case _blockstitch.StitchType
                            Case BlockStitchType.Full
                                DrawFullBlockStitch(_blockstitch)
                            Case BlockStitchType.Half
                                DrawHalfBlockStitch(_blockstitch, True)
                            Case BlockStitchType.Quarter
                                DrawQuarterBlockStitch(_blockstitch)
                            Case BlockStitchType.ThreeQuarter
                                DrawThreeQuarterBlockStitch(_blockstitch)
                            Case Else
                                DrawQuarterBlockStitch(_blockstitch)
                        End Select
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub FillAfterGrid()
        If My.Settings.IsShowBackstitches Then
            For Each _backstitch In oProjectDesign.BackStitches
                If Not isSingleColour OrElse _backstitch.ProjThread.Thread.Colour = oCurrentThread.Thread.Colour Then
                    DrawBackstitch(_backstitch)
                End If
            Next
        End If
        If My.Settings.IsShowKnots Then
            For Each _knot As Knot In oProjectDesign.Knots
                If Not isSingleColour OrElse _knot.ProjThread.Thread.Colour = oCurrentThread.Thread.Colour Then
                    DrawKnot(_knot)
                End If
            Next
        End If
    End Sub
    Public Sub DrawGrid(ByRef pProjectDesign As ProjectDesign, pIsGridOn As Boolean, pIsCentreOn As Boolean)
        Dim _widthInColumns As Integer = pProjectDesign.Columns
        Dim _heightInRows As Integer = pProjectDesign.Rows
        Dim gap As Integer = iPixelsPerCell
        Dim wct As Integer = oDesignBitmap.Width / gap

        Dim _designBorderPen As New Pen(Brushes.Black, 2)

        Dim _halfColumn As Integer = Math.Floor(_widthInColumns / 2)
        Dim _halfRow As Integer = Math.Floor(_heightInRows / 2)

        If pIsGridOn Then
            MakeGridPens()

            For x = 0 To _widthInColumns
                oDesignGraphics.DrawLine(oGrid1Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 0 To _heightInRows
                oDesignGraphics.DrawLine(oGrid1Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
            For x = 5 To _widthInColumns Step 10
                oDesignGraphics.DrawLine(oGrid5Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 5 To _heightInRows Step 10
                oDesignGraphics.DrawLine(oGrid5Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
            For x = 10 To _widthInColumns Step 10
                oDesignGraphics.DrawLine(oGrid10Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
            Next
            For y = 10 To _heightInRows Step 10
                oDesignGraphics.DrawLine(oGrid10Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * y))
            Next
            If pIsCentreOn Then
                Dim _triwidth As Integer = Math.Max(4, Math.Ceiling(iPixelsPerCell / 2))
                Dim _triPointsTop As Point() = {New Point((gap * _halfColumn) - _triwidth, 0), New Point((gap * _halfColumn) + _triwidth, 0), New Point((gap * _halfColumn), _triwidth)}
                Dim _triPointsSide As Point() = {New Point(0, (gap * _halfRow) - _triwidth), New Point(0, (gap * _halfRow) + _triwidth), New Point(_triwidth, (gap * _halfRow))}
                oDesignGraphics.FillPolygon(oCentreBrush, _triPointsTop)
                oDesignGraphics.FillPolygon(oCentreBrush, _triPointsSide)
            End If
        End If
        If pIsCentreOn Then
            If isCentreWidthVariable Then
                oCentrePenWidth = Math.Max(2, iPixelsPerCell / oVariableWidthFraction)
            Else
                oCentrePenWidth = oCentrePenDefaultWidth
            End If
            oCentrePen = New Pen(oCentrePenColor, oCentrePenWidth)
            oDesignGraphics.DrawLine(oCentrePen, New Point(0, gap * _halfRow), New Point(Math.Min(gap * _widthInColumns, oDesignBitmap.Width), gap * _halfRow))
            oDesignGraphics.DrawLine(oCentrePen, New Point(gap * _halfColumn, 0), New Point(gap * _halfColumn, Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
        End If

        '   FillAfterGrid()
        oDesignGraphics.DrawRectangle(_designBorderPen, New Rectangle(0, 0, Math.Min(gap * _widthInColumns, oDesignBitmap.Width), Math.Min(gap * _heightInRows, oDesignBitmap.Height)))
        _designBorderPen.Dispose()

    End Sub
    Private Sub MakeGridPens()
        oGrid1Pen = New Pen(oGrid1Brush, oGrid1width)
        oGrid5Pen = New Pen(oGrid5Brush, oGrid5width)
        oGrid10Pen = New Pen(oGrid10Brush, oGrid10width)
        oCentrePen = New Pen(oCentrePenColor, oCentrePenWidth)
    End Sub
    Public Sub DrawFullBlockStitch(pBlockStitch As BlockStitch)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = pBlockStitch.BlockPosition.X * iPixelsPerCell
        Dim pY As Integer = pBlockStitch.BlockPosition.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        Dim _size As New Size(iPixelsPerCell, iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }

        Dim _stitchDisplayStyle As StitchDisplayStyle = oStitchDisplayStyle

        If _stitchDisplayStyle = StitchDisplayStyle.Blocks Or _stitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
            oDesignGraphics.FillRectangle(New SolidBrush(_threadColour), New Rectangle(_tl, _size))
        End If
        If _stitchDisplayStyle = StitchDisplayStyle.Crosses Then
            oDesignGraphics.DrawLine(_crossPen, _tl, _br)
            oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If
        If _stitchDisplayStyle = StitchDisplayStyle.Strokes Then
            oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If
        If _stitchDisplayStyle = StitchDisplayStyle.BlackWhiteSymbols Or _stitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
            oDesignGraphics.DrawImage(MakeImage(pBlockStitch), _tl)
        End If
        If _stitchDisplayStyle = StitchDisplayStyle.ColouredSymbols Then
            Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(pBlockStitch.ProjThread.Thread)
            oDesignGraphics.DrawImage(MakeImage(pBlockStitch), New Rectangle(_tl, _size), 0, 0, iPixelsPerCell, iPixelsPerCell, GraphicsUnit.Pixel, _imageAttributes)
        End If
        _crossPen.Dispose()
    End Sub
    Public Sub DrawHalfBlockStitch(pBlockStitch As BlockStitch, pIsBack As Boolean)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = pBlockStitch.BlockPosition.X * iPixelsPerCell
        Dim pY As Integer = pBlockStitch.BlockPosition.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }

        Dim _cellLocation As New Point(pX, pY)
        If pIsBack Then
            oDesignGraphics.DrawLine(_crossPen, _tl, _br)
        Else
            oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If
        _crossPen.Dispose()

    End Sub
    Public Sub DrawThreeQuarterBlockStitch(pBlockstitch As BlockStitch)
        Dim _threadColour As Color = pBlockstitch.ProjThread.Thread.Colour
        Dim pX As Integer = pBlockstitch.BlockPosition.X * iPixelsPerCell
        Dim pY As Integer = pBlockstitch.BlockPosition.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)

        Dim _cellLocation As New Point(pX, pY)

        Dim _rectSize As Integer = Math.Floor(iPixelsPerCell / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _middlePoint As New Point(_middleX, _middleY)
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay
        'If _stitchDisplayStyle = StitchDisplayStyle.Crosses Then

        '     For Each _qtr As BlockStitchQuarter In pBlockstitch.Quarters

        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
        .StartCap = Drawing2D.LineCap.Round,
        .EndCap = Drawing2D.LineCap.Round
    }
        Select Case pBlockstitch.BlockQuarter
            Case BlockQuarter.TopLeft
                oDesignGraphics.DrawLine(_crossPen, _tl, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
            Case BlockQuarter.TopRight
                oDesignGraphics.DrawLine(_crossPen, _tr, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tl, _br)
            Case BlockQuarter.BottomLeft
                oDesignGraphics.DrawLine(_crossPen, _bl, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tl, _br)
            Case BlockQuarter.BottomRight
                oDesignGraphics.DrawLine(_crossPen, _br, _middlePoint)
                oDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End Select
        _crossPen.Dispose()
        '  Next

    End Sub
    Public Sub DrawQuarterBlockStitch(pBlockstitch As BlockStitch)
        Dim pX As Integer = pBlockstitch.BlockPosition.X * iPixelsPerCell
        Dim pY As Integer = pBlockstitch.BlockPosition.Y * iPixelsPerCell
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + iPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + iPixelsPerCell)
        Dim _br As New Point(pX + iPixelsPerCell, pY + iPixelsPerCell)
        oStitchPenWidth = Math.Max(2, iPixelsPerCell / 8)
        Dim _cellLocation As New Point(pX, pY)
        Dim _rectSize As Integer = Math.Floor(iPixelsPerCell / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _stitchDisplayStyle As StitchDisplayStyle = My.Settings.DesignStitchDisplay

        For Each _qtr As BlockStitchQuarter In pBlockstitch.Quarters
            Dim _threadColour As Color = _qtr.Thread.Colour
            Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
            Select Case _qtr.BlockQuarter
                Case BlockQuarter.TopLeft
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY)
                Case BlockQuarter.TopRight
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + iPixelsPerCell, pY)
                Case BlockQuarter.BottomLeft
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX, pY + iPixelsPerCell)
                Case BlockQuarter.BottomRight
                    oDesignGraphics.DrawLine(_crossPen, _middleX, _middleY, pX + iPixelsPerCell, pY + iPixelsPerCell)
            End Select
            _crossPen.Dispose()
        Next

    End Sub
    Public Sub DrawBackstitch(pBackstitch As BackStitch)
        If isBackstitchWidthVariable Then
            oStitchPenWidth = Math.Max(2, iPixelsPerCell / oVariableWidthFraction)
        Else
            oStitchPenWidth = oBackstitchPenDefaultWidth
        End If
        Dim _fromCellLocation_x As Integer = (pBackstitch.FromBlockPosition.X * iPixelsPerCell)
        Dim _fromCellLocation_y As Integer = (pBackstitch.FromBlockPosition.Y * iPixelsPerCell)
        Dim _toCellLocation_x As Integer = (pBackstitch.ToBlockPosition.X * iPixelsPerCell)
        Dim _toCellLocation_y As Integer = (pBackstitch.ToBlockPosition.Y * iPixelsPerCell)
        Dim _pen As New Pen(pBackstitch.ProjThread.Thread.Colour, oStitchPenWidth * pBackstitch.Strands) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Select Case pBackstitch.FromBlockQuarter
            Case BlockQuarter.TopRight
                _fromCellLocation_x += iPixelsPerCell / 2
            Case BlockQuarter.BottomLeft
                _fromCellLocation_y += iPixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _fromCellLocation_x += iPixelsPerCell / 2
                _fromCellLocation_y += iPixelsPerCell / 2
        End Select
        Select Case pBackstitch.ToBlockQuarter
            Case BlockQuarter.TopRight
                _toCellLocation_x += iPixelsPerCell / 2
            Case BlockQuarter.BottomLeft
                _toCellLocation_y += iPixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _toCellLocation_x += iPixelsPerCell / 2
                _toCellLocation_y += iPixelsPerCell / 2
        End Select
        oDesignGraphics.DrawLine(_pen, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)

    End Sub
    Public Sub DrawKnot(pKnot As Knot)
        DrawKnot(pKnot, False)
    End Sub
    Public Sub DrawKnot(pKnot As Knot, isRemove As Boolean)
        Dim _knotlocation_x As Integer = (pKnot.BlockPosition.X * iPixelsPerCell) - (iPixelsPerCell / 4)
        Dim _knotlocation_y As Integer = (pKnot.BlockPosition.Y * iPixelsPerCell) - (iPixelsPerCell / 4)
        Select Case pKnot.BlockQuarter
            Case BlockQuarter.BottomLeft
                _knotlocation_y += iPixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _knotlocation_y += iPixelsPerCell / 2
                _knotlocation_x += iPixelsPerCell / 2
            Case BlockQuarter.TopRight
                _knotlocation_x += iPixelsPerCell / 2
        End Select
        Dim _rect As New Rectangle(_knotlocation_x, _knotlocation_y, iPixelsPerCell / 2, iPixelsPerCell / 2)
        Dim _brush As New SolidBrush(pKnot.ProjThread.Thread.Colour)
        If isRemove Then
            _brush = oFabricBrush
        End If
        oDesignGraphics.FillEllipse(_brush, _rect)
    End Sub
    Public Function MakeColourChangeAttributes(pThread As Thread) As ImageAttributes
        Dim _thread As Thread = pThread
        Dim red As Single = _thread.Colour.R / 255.0F
        Dim green As Single = _thread.Colour.G / 255.0F
        Dim blue As Single = _thread.Colour.B / 255.0F
        Dim _imageAttributes As New ImageAttributes()
        _imageAttributes.SetColorMatrix(New ColorMatrix(New Single()() {
            New Single() {1, 0, 0, 0, 0},
            New Single() {0, 1, 0, 0, 0},
            New Single() {0, 0, 1, 0, 0},
            New Single() {0, 0, 0, 1, 0},
            New Single() {red, green, blue, 0, 1}
        }))
        Return _imageAttributes
    End Function
    Public Function MakeImage(pBlockStitch As BlockStitch) As Image
        Dim _image As Image = New Bitmap(1, 1)
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Find(Function(p) p.ThreadId = pBlockStitch.ProjThread.ThreadId), ProjectThread)
        If _projectThread Is Nothing Then
            LogUtil.DisplayStatusMessage("Thread missing from project :" & vbCrLf & pBlockStitch.ProjThread.Thread.ToString, Nothing, "MakeImage", False)
        Else
            Dim _symbol As Symbol = GetSymbolById(_projectThread.SymbolId)
            _image = ImageUtil.ResizeImage(_symbol.SymbolImage, iPixelsPerCell, iPixelsPerCell)
        End If
        Return _image
    End Function
    Private Sub CalculateOffsetForCentre(pDesignBitmap As Bitmap, pPictureBox As PictureBox)
        Dim x As Integer = (pPictureBox.Width - pDesignBitmap.Width) / (2 * iPixelsPerCell)
        Dim y As Integer = (pPictureBox.Height - pDesignBitmap.Height) / (2 * iPixelsPerCell)
        CalculateOffsetAfterChange_NoScrollBars(x, y)
    End Sub
    Public Sub CalculateOffsetAfterChange_NoScrollBars(pNewX As Integer, pNewY As Integer)
        SetValuesAfterHorizontalChange(pNewX)
        SetValuesAfterVerticalChange(pNewY)
    End Sub
    Private Sub SetValuesAfterHorizontalChange(_newOff_x As Integer)
        Dim _newTc_x As Integer
        If _newOff_x < 0 Then
            _newTc_x = _newOff_x * -1
        Else
            _newTc_x = 0
        End If
        If _newOff_x < 0 Then _newOff_x = 0
        iXOffset = _newOff_x
        topcorner = New Point(_newTc_x, topcorner.Y)
    End Sub
    Private Sub SetValuesAfterVerticalChange(_newOff_y As Integer)
        Dim _newTc_y As Integer
        If _newOff_y < 0 Then
            _newTc_y = _newOff_y * -1
        Else
            _newTc_y = 0
        End If
        If _newOff_y < 0 Then _newOff_y = 0
        iYOffset = _newOff_y
        topcorner = New Point(topcorner.X, _newTc_y)
    End Sub
    Public Function FindCellFromClickLocation(e As MouseEventArgs) As Cell
        Dim pCellBuilder As CellBuilder = CellBuilder.ACell.StartingWithNothing
        Dim pos_x As Integer = Math.Floor(e.X / iPixelsPerCell) - iXOffset + topcorner.X
        Dim pos_y As Integer = Math.Floor(e.Y / iPixelsPerCell) - iYOffset + topcorner.Y
        Dim loc_x As Integer = (pos_x) * iPixelsPerCell
        Dim loc_y As Integer = (pos_y) * iPixelsPerCell

        pCellBuilder.WithPosition(New Point(pos_x, pos_y))
        pCellBuilder.WithLocation(New Point(loc_x, loc_y))

        Dim _xrmd As Integer = e.X Mod iPixelsPerCell
        Dim _yrmd As Integer = e.Y Mod iPixelsPerCell
        Dim _qtr As BlockQuarter
        Dim _qtrLoc As New Point(loc_x, loc_y)
        Dim _qtrPos As New Point(pos_x, pos_y)
        Select Case True
            Case (_xrmd >= 0 AndAlso _xrmd < iPixelsPerCell / 2) AndAlso (_yrmd >= 0 AndAlso _yrmd < iPixelsPerCell / 2)
                _qtrLoc = New Point(loc_x, loc_y)
                _qtr = BlockQuarter.TopLeft
            Case _xrmd > iPixelsPerCell / 2 AndAlso _yrmd > iPixelsPerCell / 2
                _qtrLoc = New Point(loc_x + (iPixelsPerCell / 2), loc_y + (iPixelsPerCell / 2))
                _qtr = BlockQuarter.BottomRight
            Case (_xrmd >= 0 AndAlso _xrmd < iPixelsPerCell / 2) AndAlso _yrmd > iPixelsPerCell / 2
                _qtrLoc = New Point(loc_x, loc_y + (iPixelsPerCell / 2))
                _qtr = BlockQuarter.BottomLeft
            Case _xrmd > iPixelsPerCell / 2 AndAlso (_yrmd >= 0 AndAlso _yrmd < iPixelsPerCell / 2)
                _qtrLoc = New Point(loc_x + (iPixelsPerCell / 2), loc_y)
                _qtr = BlockQuarter.TopRight
        End Select
        pCellBuilder.WithStitchQtr(_qtr).WithStitchQtrLoc(_qtrLoc)
        If _yrmd >= 0 And _yrmd < iPixelsPerCell / 4 Then
            If _xrmd >= 0 And _xrmd < iPixelsPerCell / 4 Then
                _qtr = BlockQuarter.TopLeft
            End If
            If _xrmd >= iPixelsPerCell / 4 And _xrmd < iPixelsPerCell * 3 / 4 Then
                _qtr = BlockQuarter.TopRight
            End If
            If _xrmd >= iPixelsPerCell * 3 / 4 Then
                _qtr = BlockQuarter.TopLeft
                _qtrPos.X += 1
            End If
        End If

        If _yrmd >= iPixelsPerCell / 4 And _yrmd < iPixelsPerCell * 3 / 4 Then
            If _xrmd >= 0 And _xrmd < iPixelsPerCell / 4 Then
                _qtr = BlockQuarter.BottomLeft
            End If
            If _xrmd >= iPixelsPerCell / 4 And _xrmd < iPixelsPerCell * 3 / 4 Then
                _qtr = BlockQuarter.BottomRight
            End If
            If _xrmd >= iPixelsPerCell * 3 / 4 Then
                _qtr = BlockQuarter.BottomLeft
                _qtrPos.X += 1
            End If
        End If

        If _yrmd >= iPixelsPerCell * 3 / 4 Then
            If _xrmd >= 0 And _xrmd < iPixelsPerCell / 4 Then
                _qtr = BlockQuarter.TopLeft
                _qtrPos.Y += 1
            End If
            If _xrmd >= iPixelsPerCell / 4 And _xrmd < iPixelsPerCell * 3 / 4 Then
                _qtr = BlockQuarter.TopRight
                _qtrPos.Y += 1
            End If
            If _xrmd >= iPixelsPerCell * 3 / 4 Then
                _qtr = BlockQuarter.TopLeft
                _qtrPos.Y += 1
                _qtrPos.X += 1
            End If
        End If

        Select Case _qtr
            Case BlockQuarter.TopRight
                _qtrLoc.X += Math.Floor(iPixelsPerCell / 2)
            Case BlockQuarter.BottomLeft
                _qtrLoc.Y += Math.Floor(iPixelsPerCell / 2)
            Case BlockQuarter.BottomRight
                _qtrLoc.X += Math.Floor(iPixelsPerCell / 2)
                _qtrLoc.Y += Math.Floor(iPixelsPerCell / 2)
        End Select

        pCellBuilder.WithKnotQuarter(_qtr).WithKnotCellPos(_qtrPos).WithKnotQtrLoc(_qtrLoc)
        Return pCellBuilder.Build
    End Function
    Public Function GetColourFromProject(pProjectColour As Integer, pColours As List(Of Color)) As Color
        Dim _color As Color
        Select Case pProjectColour
            Case 1 To pColours.Count
                _color = pColours(pProjectColour - 1)
            Case Else
                _color = Color.FromArgb(pProjectColour)
        End Select
        Return _color
    End Function
#End Region
End Module
