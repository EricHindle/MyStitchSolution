' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Imaging
Imports System.Reflection
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Module ModDesign
#Region "constants"
    Public oFabricColourList As List(Of Color) = {Color.White, Color.Linen, Color.AliceBlue, Color.MistyRose}.ToList
    Public oGridColourList As List(Of Color) = {Color.LightGray, Color.DarkGray, Color.DimGray, Color.Black}.ToList
    Public oCentreColourList As List(Of Color) = {Color.Red, Color.Green, Color.Blue, Color.Black}.ToList
    Public oOverlapColourList As List(Of Color) = {Color.Gainsboro, Color.Silver, Color.Gray}.ToList
    Public Const PIXELS_PER_CELL As Integer = 8
    Public Const PRINT_PIXELS_PER_CELL As Integer = 64
    Public Const MAGNIFICATION_STEP As Decimal = 1.3
    Public BLACK_THREAD As New Thread(0, "BLACK", "Black", Color.Black, 0, -1)
    Public PALETTE_COLOUR_SIZE As Integer = 55
    Public BEAD_COLOUR_SIZE As Integer = 40
    Public Const A4_WIDTH_PIXELS As Integer = 3508
    Public Const A4_HEIGHT_PIXELS As Integer = 2480
    Public Const HDR_FLD As Integer = 0
    Public Const PROJ_ID As Integer = 1
    Public Const BLOCK_FLD As Integer = 3
    Public Const BACKSTITCH_FLD As Integer = 5
    Public Const KNOTS_FLD As Integer = 7
    Public Const ROWS_FLD As Integer = 8
    Public Const COLS_FLD As Integer = 9
#End Region
#Region "enum"
    Public Enum StitchDisplayStyle
        Crosses
        Blocks
        ColouredSymbols
        BlackWhiteSymbols
        BlocksWithSymbols
    End Enum
    Public Enum ShapeType
        Ellipse
        Rectangle
        FilledEllipse
        FilledRectangle
        None
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
        DrawShape
        Text
        none
    End Enum
#End Region
#Region "variables"
    Friend oProject As Project
    Friend oProjectDesign As ProjectDesign
    Friend oDesignBitmap As Bitmap
    Friend oDesignGraphics As Graphics
    Friend oCurrentThread As ProjectThread
    Friend oCurrentBead As ProjectBead

    Friend oProjectThreads As ProjectThreadCollection
    Friend oProjectBeads As ProjectBeadCollection

    Friend iXOffset As Integer
    Friend iYOffset As Integer

    Friend iOriginX As Integer
    Friend iOriginY As Integer

    Friend iPixelsPerCell As Integer
    Friend topcorner As New Point(0, 0)
    Friend dMagnification As Decimal = 1
    Friend oStitchPenWidth As Single = 2
    Friend iOneToOneSize As Size
    Friend iOldHScrollbarValue As Integer = 0
    Friend iOldVScrollbarValue As Integer = 0
    Friend oFabricColour As Color
    Friend oFabricBrush As SolidBrush
    Friend oFabricPen As Pen
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
    Friend isBlocksOn As Boolean
    Friend isBackStitchOn As Boolean
    Friend isKnotsOn As Boolean
    Friend isCentreOn As Boolean
    Friend isCentreMarksOn As Boolean
    Friend isGridOn As Boolean
    Friend isPrintCentreOn As Boolean
    Friend isPrintGridOn As Boolean
    Friend oStitchDisplayStyle As StitchDisplayStyle
#End Region
#Region "functions"
    Friend Function SetStitchPenWidth(pIsDouble As Boolean, pPixelCellWidth As Integer) As Integer
        Return SetStitchPenWidth(If(pIsDouble, 2, 1), pPixelCellWidth)
    End Function
    Friend Function SetStitchPenWidth(pStrands As Integer, pPixelCellWidth As Integer) As Integer
        oStitchPenWidth = Math.Max(2, Math.Floor(pPixelCellWidth) / 10) * pStrands
        Return oStitchPenWidth
    End Function
    Public Function SortStitches(pDesign As ProjectDesign) As ProjectDesign
        pDesign.BlockStitches.Sort(Function(pStitch1 As BlockStitch, pStitch2 As BlockStitch)
                                       Dim Pos1 As Integer = pStitch1.BlockPosition.Y + (pStitch1.BlockPosition.X * pDesign.Rows)
                                       Dim Pos2 As Integer = pStitch2.BlockPosition.Y + (pStitch2.BlockPosition.X * pDesign.Rows)
                                       Return Pos1.CompareTo(Pos2)
                                   End Function)
        pDesign.Knots.Sort(Function(pStitch1 As Knot, pStitch2 As Knot)
                               Dim Pos1 As Integer = pStitch1.BlockPosition.Y + (pStitch1.BlockPosition.X * pDesign.Rows)
                               Dim Pos2 As Integer = pStitch2.BlockPosition.Y + (pStitch2.BlockPosition.X * pDesign.Rows)
                               Return Pos1.CompareTo(Pos2)
                           End Function)
        pDesign.BackStitches.Sort(Function(pStitch1 As BackStitch, pStitch2 As BackStitch)
                                      Dim Pos1 As Integer = pStitch1.FromBlockLocation.Y + (pStitch1.FromBlockLocation.X * pDesign.Rows)
                                      Dim Pos2 As Integer = pStitch2.FromBlockLocation.Y + (pStitch2.FromBlockLocation.X * pDesign.Rows)
                                      Return Pos1.CompareTo(Pos2)
                                  End Function)
        Return pDesign
    End Function
    Public Sub DisplayImage(pImage As Bitmap, pX As Integer, pY As Integer, e As PaintEventArgs)
        If pImage Is Nothing Then Exit Sub
        Dim rect As Rectangle
        Dim picx As Single = iPixelsPerCell * topcorner.X
        Dim picy As Single = iPixelsPerCell * topcorner.Y
        Dim picw As Single = pImage.Width - picx
        Dim pich As Single = pImage.Height - picy
        Dim atX As Single = pX * iPixelsPerCell
        Dim atY As Single = pY * iPixelsPerCell
        rect = New Rectangle(picx, picy, picw, pich)
        Try
            e.Graphics.DrawImage(pImage, atX, atY, rect, GraphicsUnit.Pixel)
        Catch ex As Exception
            Throw New ApplicationException("Cannot display the image:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub ShowDesignInfo()
        Using _designInfo As New FrmDesignInfo()
            _designInfo.SelectedProject = oProject
            _designInfo.Design = oProjectDesign
            _designInfo.ShowDialog()
        End Using
    End Sub
    Public Function LoadProjectDesignFromFile(ByRef pProject As Project, ByRef pPictureBox As PictureBox, pIsGridOn As Boolean, pIsCentreOn As Boolean, ByRef pIsPaletteChanged As Boolean, pIsCentreMarks As Boolean) As ProjectDesign
        Return LoadProjectDesignFromFile(pProject, oProjectDesign, pPictureBox, pIsGridOn, pIsCentreOn, pIsPaletteChanged, pIsCentreMarks)
    End Function
    Public Function LoadProjectDesignFromFile(ByRef pProject As Project, ByRef pProjectDesign As ProjectDesign, pPictureBox As PictureBox, pIsGridOn As Boolean, pIsCentreOn As Boolean, ByRef pIsPaletteChanged As Boolean, pIsCentreMarks As Boolean) As ProjectDesign
        oFabricColour = GetColourFromProject(pProject.FabricColour, oFabricColourList)
        oFabricBrush = New SolidBrush(oFabricColour)
        oFabricPen = New Pen(oFabricBrush, 1)
        Dim oDesignString As List(Of String) = OpenDesignFile(oDesignFolderName, MakeFilename(pProject) & DESIGN_ZIP_EXT)
        pProjectDesign = New ProjectDesign
        For Each oLine As String In oDesignString
            If Not String.IsNullOrEmpty(oLine) Then
                If oLine.StartsWith(DESIGN_HDR) Then
                    Dim _designValues As String() = oLine.Split(DESIGN_DELIM)
                    pProjectDesign = ProjectDesignBuilder.AProjectDesign.StartingWith(_designValues).Build
                    Exit For
                End If
            End If
        Next
        pIsPaletteChanged = CheckPalette()
        DetermineUsedThreads()
        pProjectDesign.ProjectId = pProject.ProjectId
        '     If Not pProjectDesign.IsLoaded Then
        pProjectDesign.Rows = pProject.DesignHeight
        pProjectDesign.Columns = pProject.DesignWidth
        '     End If
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
        RedrawDesign(pPictureBox, pIsGridOn, pIsCentreOn, pIsCentreMarks)
        Return pProjectDesign
    End Function
    Private Sub SetInitialMagnification(pPictureBox As PictureBox)
        SetInitialMagnification(pPictureBox, oProjectDesign)
    End Sub
    Private Sub SetInitialMagnification(pPictureBox As PictureBox, pProjectDesign As ProjectDesign)
        ChangeMagnification(1, pProjectDesign)
        Dim _widthRatio As Decimal = Math.Round(pPictureBox.Width / iOneToOneSize.Width, 2, MidpointRounding.AwayFromZero)
        Dim _heightRatio As Decimal = Math.Round(pPictureBox.Height / iOneToOneSize.Height, 2, MidpointRounding.AwayFromZero)
        If iOneToOneSize.Width <= pPictureBox.Width Then
            If iOneToOneSize.Height > pPictureBox.Height Then
                ChangeMagnification(_heightRatio, pProjectDesign)
            End If
        Else
            If iOneToOneSize.Height > pPictureBox.Height Then
                If _widthRatio < _heightRatio Then
                    ChangeMagnification(_widthRatio, pProjectDesign)
                Else
                    ChangeMagnification(_heightRatio, pProjectDesign)
                End If
            Else
                ChangeMagnification(_widthRatio, pProjectDesign)
            End If
        End If
    End Sub
    Public Sub ChangeMagnification(pNewValue As Decimal)
        ChangeMagnification(pNewValue, oProjectDesign)
    End Sub
    Public Sub ChangeMagnification(pNewValue As Decimal, pProjectDesign As ProjectDesign)
        dMagnification = pNewValue
        iPixelsPerCell = Math.Floor(PIXELS_PER_CELL * dMagnification)
        iOneToOneSize = New Size(pProjectDesign.Columns * iPixelsPerCell, pProjectDesign.Rows * iPixelsPerCell)
    End Sub
    Public Sub RedrawDesign(pPicturebox As PictureBox, pIsGridOn As Boolean, pIsCentreOn As Boolean, pIsCentreMarks As Boolean)
        RedrawDesign(pPicturebox, True, pIsGridOn, pIsCentreOn, pIsCentreMarks)
    End Sub
    Public Sub RedrawDesign(pPicturebox As PictureBox, pIsReCentre As Boolean, pIsGridOn As Boolean, pIsCentreOn As Boolean, pIsCentreMarks As Boolean)
        RedrawDesign(pPicturebox, oDesignBitmap, oProjectDesign, oDesignGraphics, pIsReCentre, pIsGridOn, pIsCentreOn, pIsCentreMarks)
    End Sub
    Public Sub RedrawDesign(ByRef pPicturebox As PictureBox, ByRef pDesignBitmap As Bitmap, ByRef pProjectDesign As ProjectDesign, ByRef pDesignGraphics As Graphics, pIsReCentre As Boolean, pIsGridOn As Boolean, pIsCentreOn As Boolean, pIsCentreMarks As Boolean)
        ' Create image the size of the design
        pDesignBitmap = New Bitmap(CInt(pProjectDesign.Columns * iPixelsPerCell), CInt(pProjectDesign.Rows * iPixelsPerCell))
        If pIsReCentre Then
            CalculateOffsetForCentre(pDesignBitmap, pPicturebox)
        End If
        'Draw grid onto graphics
        'Create graphics from image
        pDesignGraphics = Graphics.FromImage(pDesignBitmap)
        pDesignGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        pDesignGraphics.FillRectangle(oFabricBrush, New Rectangle(0, 0, pDesignBitmap.Width, pDesignBitmap.Height))
        FillBeforeGrid(pProjectDesign)
        DrawGrid(pProjectDesign, pIsGridOn, pIsCentreOn, pIsCentreMarks)
        FillAfterGrid()
        pPicturebox.Invalidate()
    End Sub
    Public Sub FillBeforeGrid(pProjectDesign As ProjectDesign)
        FillBeforeGrid(pProjectDesign, oDesignGraphics, isSingleColour)
    End Sub
    Public Sub FillBeforeGrid(pProjectDesign As ProjectDesign, pDesignGraphics As Graphics, pIsSingleColour As Boolean)
        If My.Settings.IsShowBlockstitches Then
            For Each _blockstitch In pProjectDesign.BlockStitches
                If _blockstitch.IsLoaded Then
                    If Not pIsSingleColour OrElse _blockstitch.ProjThread.Thread.Colour.ToArgb = oCurrentThread.Thread.Colour.ToArgb Then
                        Select Case _blockstitch.StitchType
                            Case BlockStitchType.Full
                                DrawFullBlockStitch(_blockstitch, pDesignGraphics, oStitchDisplayStyle)
                            Case Else
                                DrawQuarterBlockStitches(_blockstitch, pDesignGraphics)
                        End Select
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub FillAfterGrid()
        FillAfterGrid(oProjectDesign, isSingleColour)
    End Sub
    Public Sub FillAfterGrid(ByRef pProjectDesign As ProjectDesign, pIsSingleColour As Boolean)
        If My.Settings.IsShowBackstitches Then
            For Each _backstitch In pProjectDesign.BackStitches
                If Not pIsSingleColour OrElse _backstitch.ProjThread.Thread.Colour = oCurrentThread.Thread.Colour Then
                    DrawBackstitch(_backstitch)
                End If
            Next
        End If
        If My.Settings.IsShowKnots Then
            For Each _knot As Knot In pProjectDesign.Knots
                If _knot.IsBead Then
                Else

                End If
                If Not pIsSingleColour OrElse _knot.ProjThread.Thread.Colour = oCurrentThread.Thread.Colour Then
                    DrawKnot(_knot)
                End If
            Next
        End If
    End Sub
    Public Sub DrawGrid(ByRef pProjectDesign As ProjectDesign, pIsGridOn As Boolean, pIsCentreOn As Boolean, pIsCentreMarksOn As Boolean)
        DrawGrid(pProjectDesign, oDesignBitmap, oDesignGraphics, pIsGridOn, pIsCentreOn, pIsCentreMarksOn)
    End Sub
    Public Sub DrawGrid(ByRef pProjectDesign As ProjectDesign, ByRef pBitmap As Bitmap, pGraphics As Graphics, pIsGridOn As Boolean, pIsCentreOn As Boolean, pIsCentreMarksOn As Boolean)
        Dim _widthInColumns As Integer = pProjectDesign.Columns
        Dim _heightInRows As Integer = pProjectDesign.Rows
        Dim gap As Integer = iPixelsPerCell
        Dim _designBorderPen As New Pen(Brushes.Black, 2)
        Dim _middleColumn As Integer = Math.Floor(_widthInColumns / 2)
        Dim _middleRow As Integer = Math.Floor(_heightInRows / 2)

        If pIsGridOn Then
            MakeGridPens()
            For x = 0 To _widthInColumns
                pGraphics.DrawLine(oGrid1Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, pBitmap.Height)))
            Next
            For y = 0 To _heightInRows
                pGraphics.DrawLine(oGrid1Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, pBitmap.Width), gap * y))
            Next
            For x = 5 To _widthInColumns Step 10
                pGraphics.DrawLine(oGrid5Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, pBitmap.Height)))
            Next
            For y = 5 To _heightInRows Step 10
                pGraphics.DrawLine(oGrid5Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, pBitmap.Width), gap * y))
            Next
            For x = 10 To _widthInColumns Step 10
                pGraphics.DrawLine(oGrid10Pen, New Point(gap * x, 0), New Point(gap * x, Math.Min(gap * _heightInRows, pBitmap.Height)))
            Next
            For y = 10 To _heightInRows Step 10
                pGraphics.DrawLine(oGrid10Pen, New Point(0, gap * y), New Point(Math.Min(gap * _widthInColumns, pBitmap.Width), gap * y))
            Next
        End If
        Dim _markHalfWidth As Integer = Math.Max(4, Math.Ceiling(iPixelsPerCell * 0.5))
        Dim _markHeight As Integer = Math.Max(6, Math.Ceiling(iPixelsPerCell * 0.75))
        Dim _middleColumnPos As Integer = gap * _middleColumn
        Dim _middleRowPos As Integer = gap * _middleRow
        Dim _gridHeight As Integer = gap * _heightInRows
        Dim _gridWidth As Integer = gap * _widthInColumns
        Dim _topMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, gap - _markHeight),
                                         New Point(_middleColumnPos + _markHalfWidth, gap - _markHeight),
                                         New Point(_middleColumnPos, gap)}
        Dim _leftMarkPoints As Point() = {New Point(gap - _markHeight, _middleRowPos - _markHalfWidth),
                                          New Point(gap - _markHeight, _middleRowPos + _markHalfWidth),
                                          New Point(gap, _middleRowPos)}
        Dim _bottomMarkPoints As Point() = {New Point(_middleColumnPos - _markHalfWidth, _gridHeight - gap + _markHeight),
                                            New Point(_middleColumnPos + _markHalfWidth, _gridHeight - gap + _markHeight),
                                            New Point(_middleColumnPos, _gridHeight - gap)}
        Dim _rightMarkPoints As Point() = {New Point(_gridWidth - gap + _markHeight, (_middleRowPos - _markHalfWidth)),
                                           New Point(_gridWidth - gap + _markHeight, _middleRowPos + _markHalfWidth),
                                           New Point(_gridWidth - gap, _middleRowPos)}
        If pIsCentreOn Then
            If isCentreWidthVariable Then
                oCentrePenWidth = Math.Max(2, iPixelsPerCell / oVariableWidthFraction)
            Else
                oCentrePenWidth = oCentrePenDefaultWidth
            End If
            oCentrePen = New Pen(oCentrePenColor, oCentrePenWidth)
            pGraphics.DrawLine(oCentrePen, New Point(0, gap * _middleRow), New Point(Math.Min(gap * _widthInColumns, pBitmap.Width), gap * _middleRow))
            pGraphics.DrawLine(oCentrePen, New Point(gap * _middleColumn, 0), New Point(gap * _middleColumn, Math.Min(gap * _heightInRows, pBitmap.Height)))
        End If
        If pIsCentreMarksOn Then
            pGraphics.FillPolygon(oCentreBrush, _topMarkPoints)
            pGraphics.FillPolygon(oCentreBrush, _leftMarkPoints)
            pGraphics.FillPolygon(oCentreBrush, _bottomMarkPoints)
            pGraphics.FillPolygon(oCentreBrush, _rightMarkPoints)
        End If
        '   FillAfterGrid()
        pGraphics.DrawRectangle(_designBorderPen, New Rectangle(0, 0, Math.Min(gap * _widthInColumns, pBitmap.Width), Math.Min(gap * _heightInRows, pBitmap.Height)))
        _designBorderPen.Dispose()

    End Sub
    Private Sub MakeGridPens()
        oGrid1Pen = New Pen(oGrid1Brush, oGrid1width)
        oGrid5Pen = New Pen(oGrid5Brush, oGrid5width)
        oGrid10Pen = New Pen(oGrid10Brush, oGrid10width)
        oCentrePen = New Pen(oCentrePenColor, oCentrePenWidth)
    End Sub
    Public Sub DrawFullBlockStitch(pBlockStitch As BlockStitch)
        DrawFullBlockStitch(pBlockStitch, oDesignGraphics, oStitchDisplayStyle)
    End Sub
    Public Sub DrawFullBlockStitch(pBlockStitch As BlockStitch, ByRef pDesignGraphics As Graphics, pStitchDisplayStyle As StitchDisplayStyle)
        Dim _threadColour As Color = pBlockStitch.ProjThread.Thread.Colour
        Dim pX As Integer = (pBlockStitch.BlockPosition.X + iOriginX) * iPixelsPerCell
        Dim pY As Integer = (pBlockStitch.BlockPosition.Y + iOriginY) * iPixelsPerCell
        FullBlockStitch(pBlockStitch, pDesignGraphics, iPixelsPerCell, pStitchDisplayStyle, _threadColour, pX, pY)
    End Sub
    Friend Sub FullBlockStitch(pBlockStitch As BlockStitch, pDesignGraphics As Graphics, pPixelsPerCell As Integer, pStitchDisplayStyle As StitchDisplayStyle, _threadColour As Color, pX As Integer, pY As Integer)

        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(pX + pPixelsPerCell, pY)
        Dim _bl As New Point(pX, pY + pPixelsPerCell)
        Dim _br As New Point(pX + pPixelsPerCell, pY + pPixelsPerCell)
        Dim _size As New Size(pPixelsPerCell, pPixelsPerCell)
        SetStitchPenWidth(pBlockStitch.Strands, pPixelsPerCell)
        Dim _crossPen As New Pen(New SolidBrush(_threadColour), oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        If pStitchDisplayStyle = StitchDisplayStyle.Blocks Or pStitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
            pDesignGraphics.FillRectangle(New SolidBrush(_threadColour), New Rectangle(_tl, _size))
        End If
        If pStitchDisplayStyle = StitchDisplayStyle.Crosses Then
            pDesignGraphics.DrawLine(_crossPen, _tl, _br)
            pDesignGraphics.DrawLine(_crossPen, _tr, _bl)
        End If

        If pStitchDisplayStyle = StitchDisplayStyle.ColouredSymbols Then
            Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(pBlockStitch.ProjThread.Thread)
            DrawSymbol(pBlockStitch, pDesignGraphics, _tl, pPixelsPerCell, _imageAttributes)
        End If
        If pStitchDisplayStyle = StitchDisplayStyle.BlackWhiteSymbols Or pStitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
            DrawSymbol(pBlockStitch, pDesignGraphics, _tl, pPixelsPerCell, New ImageAttributes)
        End If
        _crossPen.Dispose()
    End Sub

    Friend Sub DrawSymbol(pBlockstitch As BlockStitch, pDesignGraphics As Graphics, _tl As Point, pSize As Integer, pImageAttributes As ImageAttributes)
        pDesignGraphics.DrawImage(MakeImage(pBlockstitch, pSize), New Rectangle(_tl, New Size(pSize, pSize)), 0, 0, pSize, pSize, GraphicsUnit.Pixel, pImageAttributes)
    End Sub
    Public Sub DrawQuarterBlockStitches(pBlockstitch As BlockStitch, ByRef pDesignGraphics As Graphics)
        Dim pX As Integer = (pBlockstitch.BlockPosition.X + iOriginX) * iPixelsPerCell
        Dim pY As Integer = (pBlockstitch.BlockPosition.Y + iOriginY) * iPixelsPerCell
        QuarterBlockStitches(pBlockstitch, pDesignGraphics, iPixelsPerCell, My.Settings.DesignStitchDisplay, pX, pY)
    End Sub

    Friend Sub QuarterBlockStitches(pBlockstitch As BlockStitch, pDesignGraphics As Graphics, pPixelsPerCell As Integer, pStitchDisplayStyle As StitchDisplayStyle, pX As Integer, pY As Integer)
        Dim _rectSize As Integer = Math.Floor(pPixelsPerCell / 2)
        Dim _middleX As Integer = CInt(pX + _rectSize)
        Dim _middleY As Integer = CInt(pY + _rectSize)
        Dim _tl As New Point(pX, pY)
        Dim _tr As New Point(_middleX, pY)
        Dim _bl As New Point(pX, _middleY)
        Dim _br As New Point(_middleX, _middleY)
        SetStitchPenWidth(pBlockstitch.Strands, pPixelsPerCell)
        Dim _cellLocation As New Point(pX, pY)
        Dim _stitchDisplayStyle As StitchDisplayStyle = pStitchDisplayStyle
        For Each _qtr As BlockStitchQuarter In pBlockstitch.Quarters
            Dim _threadColour As Color = _qtr.Thread.Colour
            Dim _qtrBrush As New SolidBrush(_threadColour)
            Dim _qtrPen As New Pen(_qtrBrush, oStitchPenWidth) With {
                                            .StartCap = Drawing2D.LineCap.Round,
                                            .EndCap = Drawing2D.LineCap.Round
                                        }
            If _stitchDisplayStyle = StitchDisplayStyle.Blocks Or _stitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
                Select Case _qtr.BlockQuarter
                    Case BlockQuarter.TopLeft
                        pDesignGraphics.FillRectangle(_qtrBrush, pX, pY, _rectSize, _rectSize)
                    Case BlockQuarter.TopRight
                        pDesignGraphics.FillRectangle(_qtrBrush, _middleX, pY, _rectSize, _rectSize)
                    Case BlockQuarter.BottomLeft
                        pDesignGraphics.FillRectangle(_qtrBrush, pX, _middleY, _rectSize, _rectSize)
                    Case BlockQuarter.BottomRight
                        pDesignGraphics.FillRectangle(_qtrBrush, _middleX, _middleY, _rectSize, _rectSize)
                End Select
            End If
            If _stitchDisplayStyle = StitchDisplayStyle.Crosses Then
                Select Case _qtr.BlockQuarter
                    Case BlockQuarter.TopLeft
                        pDesignGraphics.DrawLine(_qtrPen, _middleX, _middleY, pX, pY)
                    Case BlockQuarter.TopRight
                        pDesignGraphics.DrawLine(_qtrPen, _middleX, _middleY, pX + pPixelsPerCell, pY)
                    Case BlockQuarter.BottomLeft
                        pDesignGraphics.DrawLine(_qtrPen, _middleX, _middleY, pX, pY + pPixelsPerCell)
                    Case BlockQuarter.BottomRight
                        pDesignGraphics.DrawLine(_qtrPen, _middleX, _middleY, pX + pPixelsPerCell, pY + pPixelsPerCell)
                End Select
            End If
            If _stitchDisplayStyle = StitchDisplayStyle.BlackWhiteSymbols Or _stitchDisplayStyle = StitchDisplayStyle.BlocksWithSymbols Then
                Dim _imageAttributes As New ImageAttributes()
                Select Case _qtr.BlockQuarter
                    Case BlockQuarter.TopLeft
                        DrawSymbol(pBlockstitch, pDesignGraphics, _tl, _rectSize, _imageAttributes)
                    Case BlockQuarter.TopRight
                        DrawSymbol(pBlockstitch, pDesignGraphics, _tr, _rectSize, _imageAttributes)
                    Case BlockQuarter.BottomLeft
                        DrawSymbol(pBlockstitch, pDesignGraphics, _bl, _rectSize, _imageAttributes)
                    Case BlockQuarter.BottomRight
                        DrawSymbol(pBlockstitch, pDesignGraphics, _br, _rectSize, _imageAttributes)
                End Select
            End If
            If _stitchDisplayStyle = StitchDisplayStyle.ColouredSymbols Then
                Dim _imageAttributes As ImageAttributes = MakeColourChangeAttributes(pBlockstitch.ProjThread.Thread)
                Select Case _qtr.BlockQuarter
                    Case BlockQuarter.TopLeft
                        DrawSymbol(pBlockstitch, pDesignGraphics, _tl, _rectSize, _imageAttributes)
                    Case BlockQuarter.TopRight
                        DrawSymbol(pBlockstitch, pDesignGraphics, _tr, _rectSize, _imageAttributes)
                    Case BlockQuarter.BottomLeft
                        DrawSymbol(pBlockstitch, pDesignGraphics, _bl, _rectSize, _imageAttributes)
                    Case BlockQuarter.BottomRight
                        DrawSymbol(pBlockstitch, pDesignGraphics, _br, _rectSize, _imageAttributes)
                End Select
            End If
            _qtrPen.Dispose()
        Next
    End Sub

    Public Sub DrawBackstitch(pBackstitch As BackStitch)
        DrawBackstitch(pBackstitch, oDesignGraphics)
    End Sub
    Public Sub DrawBackstitch(pBackstitch As BackStitch, ByRef pDesignGraphics As Graphics)
        SetStitchPenWidth(pBackstitch.Strands, iPixelsPerCell)

        Dim _fromCellLocation_x As Integer = ((pBackstitch.FromBlockPosition.X + iOriginX) * iPixelsPerCell)
        Dim _fromCellLocation_y As Integer = ((pBackstitch.FromBlockPosition.Y + iOriginY) * iPixelsPerCell)
        Dim _toCellLocation_x As Integer = ((pBackstitch.ToBlockPosition.X + iOriginX) * iPixelsPerCell)
        Dim _toCellLocation_y As Integer = ((pBackstitch.ToBlockPosition.Y + iOriginY) * iPixelsPerCell)
        Backstitch(pBackstitch, pDesignGraphics, iPixelsPerCell, _fromCellLocation_x, _fromCellLocation_y, _toCellLocation_x, _toCellLocation_y)
    End Sub

    Friend Sub Backstitch(pBackstitch As BackStitch, pDesignGraphics As Graphics, ppixelspercell As Integer, ByRef pFromCellLocation_x As Integer, ByRef pFromCellLocation_y As Integer, ByRef pToCellLocation_x As Integer, ByRef pToCellLocation_y As Integer)
        Dim _pen As New Pen(pBackstitch.ProjThread.Thread.Colour, oStitchPenWidth) With {
            .StartCap = Drawing2D.LineCap.Round,
            .EndCap = Drawing2D.LineCap.Round
        }
        Select Case pBackstitch.FromBlockQuarter
            Case BlockQuarter.TopRight
                pFromCellLocation_x += ppixelspercell / 2
            Case BlockQuarter.BottomLeft
                pFromCellLocation_y += ppixelspercell / 2
            Case BlockQuarter.BottomRight
                pFromCellLocation_x += ppixelspercell / 2
                pFromCellLocation_y += ppixelspercell / 2
        End Select
        Select Case pBackstitch.ToBlockQuarter
            Case BlockQuarter.TopRight
                pToCellLocation_x += ppixelspercell / 2
            Case BlockQuarter.BottomLeft
                pToCellLocation_y += ppixelspercell / 2
            Case BlockQuarter.BottomRight
                pToCellLocation_x += ppixelspercell / 2
                pToCellLocation_y += ppixelspercell / 2
        End Select
        pDesignGraphics.DrawLine(_pen, pFromCellLocation_x, pFromCellLocation_y, pToCellLocation_x, pToCellLocation_y)
    End Sub

    Public Sub DrawKnot(pKnot As Knot)
        DrawKnot(pKnot, False)
    End Sub
    Public Sub DrawKnot(pKnot As Knot, isRemove As Boolean)
        DrawKnot(pKnot, oDesignGraphics, isRemove)
    End Sub
    Public Sub DrawKnot(pKnot As Knot, pDesignGraphics As Graphics, isRemove As Boolean)
        Dim _size As Integer = Math.Floor(iPixelsPerCell / 2)
        If Not pKnot.IsBead And pKnot.Strands = 1 Then
            _size = Math.Floor(iPixelsPerCell / 2.5)
        End If
        Dim _knotlocation_x As Integer = ((pKnot.BlockPosition.X + iOriginX) * iPixelsPerCell) - (_size / 2)
        Dim _knotlocation_y As Integer = ((pKnot.BlockPosition.Y + iOriginY) * iPixelsPerCell) - (_size / 2)
        Select Case pKnot.BlockQuarter
            Case BlockQuarter.BottomLeft
                _knotlocation_y += iPixelsPerCell / 2
            Case BlockQuarter.BottomRight
                _knotlocation_y += iPixelsPerCell / 2
                _knotlocation_x += iPixelsPerCell / 2
            Case BlockQuarter.TopRight
                _knotlocation_x += iPixelsPerCell / 2
        End Select
        Dim _rect As New Rectangle(_knotlocation_x, _knotlocation_y, _size, _size)
        Dim _brush As New SolidBrush(pKnot.ProjThread.Thread.Colour)
        Dim _pen As New Pen(Brushes.Black, 1)

        If isRemove Then
            pDesignGraphics.FillEllipse(oFabricBrush, _rect)
            pDesignGraphics.DrawEllipse(oFabricPen, _rect)
        Else
            pDesignGraphics.FillEllipse(_brush, _rect)
            If pKnot.IsBead Then
                pDesignGraphics.DrawEllipse(_pen, _rect)
            End If
        End If
        _pen.Dispose()
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
    Public Function MakeImage(pBlockStitch As BlockStitch, pPixels As Integer) As Image
        Dim _image As Image = New Bitmap(1, 1)
        Dim _projectThread As ProjectThread = CType(oProjectThreads.Threads.Find(Function(p) p.ThreadId = pBlockStitch.ProjThread.ThreadId), ProjectThread)
        If _projectThread Is Nothing Then
            LogUtil.DisplayStatusMessage("Bead missing from project :" & vbCrLf & pBlockStitch.ProjThread.Thread.ToString, Nothing, "MakeImage", False)
        Else
            Dim _symbol As Symbol = FindSymbolById(_projectThread.SymbolId)
            _image = ImageUtil.ResizeImage(_symbol.SymbolImage, pPixels, pPixels)
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
        'pos = cell index
        'loc = cell physical position
        Dim pos_x As Integer = Math.Floor(e.X / iPixelsPerCell) - iXOffset + topcorner.X - iOriginX
        Dim pos_y As Integer = Math.Floor(e.Y / iPixelsPerCell) - iYOffset + topcorner.Y - iOriginY
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
    Public Function DetermineUsedThreads() As List(Of Integer)
        Return DetermineUsedThreads(oProjectDesign, oProjectThreads, oProjectBeads, False)
    End Function
    Public Function DetermineUsedThreads(pIsRemoveUnused As Boolean) As List(Of Integer)
        Return DetermineUsedThreads(oProjectDesign, oProjectThreads, oProjectBeads, pIsRemoveUnused)
    End Function
    Public Function DetermineUsedThreads(ByRef pProjectDesign As ProjectDesign, ByRef pProjectThreads As ProjectThreadCollection, ByRef pProjectBeads As ProjectBeadCollection, pIsRemoveUnused As Boolean) As List(Of Integer)
        LogUtil.LogInfo("Determining unused threads", MethodBase.GetCurrentMethod.Name)
        Dim _usedThreads As New List(Of Integer)
        Dim _removeThreads As New List(Of Integer)
        For Each _thread As ProjectThread In pProjectThreads.Threads
            _thread.IsUsed = False
            Dim _blockstitch As BlockStitch = pProjectDesign.BlockStitches.Find(Function(p) p.ThreadId = _thread.ThreadId)
            If _blockstitch IsNot Nothing Then
                _usedThreads.Add(_thread.ThreadId)
                _thread.IsUsed = True
                Continue For
            End If
            Dim _backstitch As BackStitch = pProjectDesign.BackStitches.Find(Function(p) p.ThreadId = _thread.ThreadId)
            If _backstitch IsNot Nothing Then
                _usedThreads.Add(_thread.ThreadId)
                _thread.IsUsed = True
                Continue For
            End If
            Dim _knot As Knot = pProjectDesign.Knots.Find(Function(p) p.ThreadId = _thread.ThreadId)
            If _knot IsNot Nothing Then
                _usedThreads.Add(_thread.ThreadId)
                _thread.IsUsed = True
                Continue For
            End If
            If pIsRemoveUnused And Not _thread.IsUsed Then
                RemoveProjectThread(_thread)
                _removeThreads.Add(_thread.ThreadId)
            End If
        Next
        For Each _bead As ProjectBead In pProjectBeads.Beads
            Dim _knot As Knot = pProjectDesign.Knots.Find(Function(p) p.ThreadId = _bead.ThreadId)
            If _knot IsNot Nothing Then
                _usedThreads.Add(_bead.ThreadId)
                _bead.IsUsed = True
                Continue For
            End If
            If pIsRemoveUnused And Not _bead.IsUsed Then
                RemoveProjectBead(_bead)
                _removeThreads.Add(_bead.ThreadId)
            End If
        Next
        For Each _rmv As Integer In _removeThreads
            pProjectThreads.Remove(_rmv)
        Next
        For Each _thread As ProjectThread In pProjectThreads.Threads
            AmendProjectThreadIsUsed(_thread)
        Next
        For Each _bead As ProjectBead In pProjectBeads.Beads
            AmendProjectBeadIsUsed(_bead)
        Next
        _usedThreads.Sort()
        Return _usedThreads
    End Function
    Public Sub RemoveUnusedThreads()
        LogUtil.LogInfo("Removing unused threads", MethodBase.GetCurrentMethod.Name)
        DetermineUsedThreads(True)
    End Sub
    Public Sub FillPaletteList(pPaletteList As ComboBox)
        pPaletteList.DataSource = GetPaletteList()
        pPaletteList.DisplayMember = "palettename"
        pPaletteList.ValueMember = "paletteid"
        pPaletteList.SelectedIndex = -1
    End Sub
    Public Function CheckPalette() As Boolean
        Return CheckPalette(oProjectDesign, oProjectThreads, oProjectBeads)
    End Function
    Public Function CheckPalette(ByRef pProjectDesign As ProjectDesign, ByRef pProjectThreads As ProjectThreadCollection, ByRef pProjectBeads As ProjectBeadCollection) As Boolean
        LogUtil.LogInfo("Checking palette", MethodBase.GetCurrentMethod.Name)
        Dim _isAdded As Boolean
        For Each _blockstitch As BlockStitch In pProjectDesign.BlockStitches
            If Not pProjectThreads.Exists(_blockstitch.ThreadId) Then
                AddThreadToPalette(pProjectDesign.ProjectId, _blockstitch.ThreadId)
                _isAdded = True
            End If
            For Each _qtr As BlockStitchQuarter In _blockstitch.Quarters
                If Not pProjectThreads.Exists(_qtr.ThreadId) Then
                    AddThreadToPalette(pProjectDesign.ProjectId, _qtr.ThreadId)
                    _isAdded = True
                End If
            Next
        Next
        For Each _backstitch As BackStitch In pProjectDesign.BackStitches
            If Not pProjectThreads.Exists(_backstitch.ThreadId) Then
                AddThreadToPalette(pProjectDesign.ProjectId, _backstitch.ThreadId)
                _isAdded = True
            End If
        Next
        For Each _knot As Knot In pProjectDesign.Knots
            Dim _isExists As Boolean
            If _knot.IsBead Then
                _isExists = pProjectBeads.Exists(_knot.ThreadId)
                If Not _isExists Then
                    AddBeadToPalette(pProjectDesign.ProjectId, _knot.ThreadId)
                    _isAdded = True
                End If
            Else
                _isExists = pProjectThreads.Exists(_knot.ThreadId)
                If Not _isExists Then
                    AddThreadToPalette(pProjectDesign.ProjectId, _knot.ThreadId)
                    _isAdded = True
                End If
            End If
        Next
        Return _isAdded
    End Function
    Private Sub AddThreadToPalette(pProjectId As Integer, pThreadId As Integer)
        LogUtil.LogInfo("Adding missing thread to palette. ProjectId:" & CStr(pProjectId) & " BeadId:" & CStr(pThreadId), MethodBase.GetCurrentMethod.Name)
        Dim _pt As ProjectThread = ProjectThreadBuilder.AProjectThread.StartingWithNothing _
            .WithProjectId(pProjectId) _
            .WithThreadId(pThreadId) _
            .WithIsUsed(True) _
            .Build
        AddNewProjectThread(_pt)
    End Sub
    Private Sub AddBeadToPalette(pProjectId As Integer, pBeadId As Integer)
        LogUtil.LogInfo("Adding missing Bead to palette. ProjectId:" & CStr(pProjectId) & " BeadId:" & CStr(pBeadId), MethodBase.GetCurrentMethod.Name)
        Dim _pt As ProjectBead = ProjectBeadBuilder.AProjectBead.StartingWithNothing _
            .WithProjectId(pProjectId) _
            .WithBeadId(pBeadId) _
            .WithIsUsed(True) _
            .Build
        AddNewProjectBead(_pt)
    End Sub
    Public Sub OpenPrintForm(pForm As Form, pProject As Project)
        If pProject.IsLoaded Then
            pForm.Hide()
            Using _printDialog As New FrmPrintProject
                _printDialog.PrintProject = pProject
                _printDialog.ShowDialog()
            End Using
            pForm.Show()
        End If
    End Sub
    Public Function OpenTextForm(pForm As Form, pProject As Project) As TextBlock
        Dim _textBlock As TextBlock = Nothing
        If pProject.IsLoaded Then
            pForm.Hide()
            Using _textDialog As New FrmText
                _textDialog.SelectedProject = pProject
                _textDialog.SelectedThread = oCurrentThread
                _textDialog.ShowDialog()
                _textBlock = _textDialog.TextBlock
            End Using
            pForm.Show()
        End If
        Return _textBlock
    End Function
#End Region
End Module
