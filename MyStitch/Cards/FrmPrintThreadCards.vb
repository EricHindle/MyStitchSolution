' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmPrintThreadCards
#Region "constants"
    ' image dots per inch

    ' font points per inch
    Private Const PPI As Integer = 72
    Private Const PROJECT_NAME_FONT_SIZE As Integer = 9
    Private Const THREAD_NAME_FONT_SIZE As Integer = 10
    Private Const THREAD_NUMBER_FONT_SIZE As Integer = 18
    Private Const HOLEPUNCH_HOLE_RADIUS As Integer = 35
    Private Const HOLEPUNCH_HOLE_INSET As Integer = 107
    Private Const HOLEPUNCH_HOLE_GAP As Integer = 236
    Private Const FAMILY_NAME As String = "arial"
    Private PROJECT_NAME_BRUSH As Brush = Brushes.Gray
    Private THREAD_NUMBER_BRUSH As Brush = Brushes.Navy
    Private THREAD_NAME_BRUSH As Brush = Brushes.DimGray
    Private LINE_PEN As New Pen(Brushes.Black, 1)
    Private CARD_COLOUR As Brush = Brushes.White
    Private Const PANEL_MAX_WIDTH As Integer = 325
    Private Const COLUMNS_FULL As String = "All columns full"
#End Region
#Region "properties"
    Private _selectedProject As Project
    Public Property SelectedProject() As Project
        Get
            Return _selectedProject
        End Get
        Set(ByVal value As Project)
            _selectedProject = value
        End Set
    End Property
#End Region
#Region "variables"
    Private _cardGraphics As Graphics
    Private oImageUtil As New ImageUtil
    Private sourceBitmap As Bitmap
    Private oSelectedProject As Project
    Private isLoading As Boolean
    Private isCardsLoading As Boolean
    Private _nextCol As Integer
    Private leftmargin As Integer
    Private topmargin As Integer
#End Region
#Region "form control handlers"
    Private Sub FrmPrintThreadCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Printing Thread Cards", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
        If _selectedProject IsNot Nothing AndAlso SelectedProject.IsLoaded Then
            SelectProjectInList(DgvProjects, _selectedProject.ProjectId)
            AddInstruction(SELECT_CARD)
        End If
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmPrintThreadCards_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", Name)
        My.Settings.PrintThreadCardsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        Dim _imagefile As String = SaveSourceImage(sourceBitmap)
    End Sub
    Private Sub PnlCardImage_SizeChanged(sender As Object, e As EventArgs) Handles PnlCardImage.SizeChanged
        SetPictureWidth()
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If oSelectedProject IsNot Nothing Then
            LogUtil.ShowStatus("Printing card", LblStatus, MyBase.Name)
            InitialisePrintDocument()
            ' Set handler to print image 
            AddHandler oPrintDoc.PrintPage, AddressOf OnPrintImage
            ' Print the image (calls PrintPage handler (see above))
            oPrintDoc.Print()
        Else
            LogUtil.ShowStatus("No project selected", LblStatus, True)
        End If
    End Sub
    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        LogUtil.ShowStatus("Sending card to printer", LblStatus, MyBase.Name)
        'print options
        ' 0 = print to fill available space
        ' 1 =
        ' 2 = print maximum size retaining aspect ratio
        ' 3 = print into half the available space
        ' 4 = print actual size

        ' DRAW THE IMAGE scaled to the print area

        ' Set margins to allow for printers hard margins
        leftmargin = e.PageSettings.HardMarginX * 3
        topmargin = e.PageSettings.HardMarginY * 3
        Dim targetWidth As Integer = sourceBitmap.Width - leftmargin
        Dim targetHeight As Integer = sourceBitmap.Height - topmargin

        ' Print the image, cutting off the left and top parts that the printer cannot print
        e.Graphics.DrawImage(sourceBitmap, 0, 0, New Rectangle(leftmargin, topmargin, targetWidth, targetHeight), GraphicsUnit.Document)
        LogUtil.ShowStatus("Printing done", LblStatus, MyBase.Name)
    End Sub
    Private Sub DgvProjects_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProjects.SelectionChanged
        If Not isLoading Then
            PrepareNewImage()
        End If
    End Sub
    Private Sub BtnAddCard_Click(sender As Object, e As EventArgs) Handles BtnAddCard.Click
        AddSelectedCard()
    End Sub
    Private Sub NudColCt_ValueChanged(sender As Object, e As EventArgs) Handles NudColCt.ValueChanged
        PrepareNewImage(NudColCt.Value)
    End Sub
    Private Sub BtnResetImage_Click(sender As Object, e As EventArgs) Handles BtnResetImage.Click
        PrepareNewImage()
    End Sub
    Private Sub LbCards_DoubleClick(sender As Object, e As EventArgs) Handles LbCards.DoubleClick
        AddSelectedCard()
    End Sub
    Private Sub LbCards_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LbCards.SelectedIndexChanged
        If _nextCol <= NudColCt.Value - 1 Then
            AddInstruction(ADD_CARD)
        Else
            AddInstruction(COLUMNS_FULL)
        End If
        LogUtil.ClearStatus(LblStatus)
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.PrintThreadCardsFormPos)
        iPanelMax = PANEL_MAX_WIDTH
        sourceBitmap = New Bitmap(A4_WIDTH_PIXELS, A4_HEIGHT_PIXELS)
        sourceBitmap.SetResolution(PRINT_DPI, PRINT_DPI)
        leftmargin = oPrintDoc.DefaultPageSettings.HardMarginX * 3
        topmargin = oPrintDoc.DefaultPageSettings.HardMarginY * 3
        SetPictureWidth()
        LoadProjectList(DgvProjects, MyBase.Name)
        AddInstruction(SELECT_PROJECT)
    End Sub
    Private Sub SetPictureWidth()
        If sourceBitmap IsNot Nothing Then
            If PnlCardImage.Width > PnlCardImage.Height Then
                PicThreadCard.Width = PicThreadCard.Height * sourceBitmap.Width / sourceBitmap.Height
            Else
                PicThreadCard.Height = PicThreadCard.Width * sourceBitmap.Height / sourceBitmap.Width
            End If
        End If
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Location = New Point((PnlCardImage.Width - PicThreadCard.Width) / 2, PicThreadCard.Top)
    End Sub
    Private Sub AddProjectRow(oProject As Project)
        Dim oRow As DataGridViewRow = DgvProjects.Rows(DgvProjects.Rows.Add())
        oRow.Cells(projectId.Name).Value = oProject.ProjectId
        oRow.Cells(projectName.Name).Value = oProject.ProjectName
    End Sub
    Private Function SaveSourceImage(pImage As Image) As String
        Dim _path As String = My.Settings.ImagePath
        Return SaveSourceImage(pImage, _path, Nothing)
    End Function
    Private Function SaveSourceImage(pImage As Image, pPath As String, pFilename As String) As String
        Dim imageFileName As String = Nothing
        Try
            LogUtil.ShowStatus("Saving image", LblStatus)
            If pImage IsNot Nothing Then
                imageFileName = ImageUtil.SaveImage(pImage, pPath, pFilename, ImageUtil.ImageType.JPEG)
                LogUtil.ShowStatus("Saved " & imageFileName, LblStatus)
            Else
                LogUtil.ShowStatus("NOT saved image", LblStatus)
            End If
        Catch ex As ArgumentException
            LogUtil.ShowStatus("NOT saved image", LblStatus)
        End Try
        Return imageFileName
    End Function
    Private Sub PrepareNewImage()
        PrepareNewImage(4)
    End Sub
    Private Sub PrepareNewImage(pColCt As Integer)
        If DgvProjects.SelectedRows.Count > 0 Then
            Dim oRow As DataGridViewRow = DgvProjects.SelectedRows(0)
            Dim _projectId As Integer = oRow.Cells(projectId.Name).Value
            oSelectedProject = FindProjectById(_projectId)
            LoadCardList(_projectId, LbCards, MyBase.Name)
            If _LbCards.Items.Count < 4 Then
                NudColCt.Value = 3
            Else
                NudColCt.Value = pColCt
            End If
            InitialiseImage(oSelectedProject.ProjectName)
        End If
    End Sub
    Private Sub InitialiseImage(projectName As String)
        sourceBitmap = New Bitmap(A4_WIDTH_PIXELS, A4_HEIGHT_PIXELS)
        sourceBitmap.SetResolution(PRINT_DPI, PRINT_DPI)
        _cardGraphics = Graphics.FromImage(sourceBitmap)
        _cardGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height))
        Dim colCt As Integer = NudColCt.Value
        Dim colWidth As Integer = A4_WIDTH_PIXELS / colCt
        Dim _left_x As Integer
        Dim _right_x As Integer
        Dim _top_y As Integer
        Dim _bottom_y As Integer
        ' Project Name
        For _col As Integer = 1 To colCt
            _left_x = (colWidth * (_col - 1)) + leftmargin
            _top_y = topmargin
            _cardGraphics.DrawString(oSelectedProject.ProjectName, New Font(FAMILY_NAME, PROJECT_NAME_FONT_SIZE, FontStyle.Regular), PROJECT_NAME_BRUSH, New Point(_left_x, _top_y))
        Next
        ' Vertical lines
        _top_y = 0
        _bottom_y = sourceBitmap.Height
        For _col = 1 To colCt - 1
            _left_x = colWidth * _col
            _right_x = _left_x
            _cardGraphics.DrawLine(LINE_PEN, New Point(_left_x, _top_y), New Point(_right_x, _bottom_y))
        Next
        Dim _rowct As Integer = 10
        _left_x = 0
        _right_x = sourceBitmap.Width
        ' Horizontal lines
        Dim _top As Integer = (sourceBitmap.Height - (HOLEPUNCH_HOLE_GAP * (_rowct - 1))) / 2
        For _row As Integer = 0 To _rowct - 1
            _top_y = _top + (HOLEPUNCH_HOLE_GAP * _row)
            _cardGraphics.DrawLine(LINE_PEN, New Point(_left_x, _top_y), New Point(_right_x, _top_y))
            ' Holepunch hole circles
            For _col As Integer = 0 To colCt - 1
                Dim _holetop As Integer = _top + (HOLEPUNCH_HOLE_GAP * (_row)) - HOLEPUNCH_HOLE_RADIUS
                Dim _holeleft As Integer = ((colWidth * _col) + HOLEPUNCH_HOLE_INSET)
                Dim _holerectangle As New Rectangle(New Point(_holeleft, _holetop), New Size(HOLEPUNCH_HOLE_RADIUS * 2, HOLEPUNCH_HOLE_RADIUS * 2))
                _cardGraphics.FillEllipse(CARD_COLOUR, _holerectangle)
                _cardGraphics.DrawEllipse(LINE_PEN, _holerectangle)
            Next
        Next
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Refresh()
        _nextCol = 0
    End Sub
    Private Sub AddCardToImage(pList As List(Of ProjectCardThread))
        Dim oRowCt As Integer = 10
        Dim oColCt As Integer = NudColCt.Value
        Dim oColWidth As Integer = A4_WIDTH_PIXELS / oColCt
        Dim _topMargin As Integer = (sourceBitmap.Height - (HOLEPUNCH_HOLE_GAP * (oRowCt - 1))) / 2
        Dim _left_x As Integer
        Dim _line_y As Integer
        Dim _row As Integer = 0
        For Each _thread As ProjectCardThread In pList
            Dim _projectThread As ProjectThread = FindProjectThread(_thread.Project.ProjectId, _thread.Thread.ThreadId)
            Dim _col As Integer = _nextCol
            _line_y = _topMargin + (HOLEPUNCH_HOLE_GAP * _row)
            _left_x = (oColWidth * _col) + HOLEPUNCH_HOLE_INSET + (HOLEPUNCH_HOLE_RADIUS * 5)
            Dim _textheight As Integer = (THREAD_NUMBER_FONT_SIZE * PRINT_DPI / PPI) * 1.2
            Dim _textwidth As Integer = _textheight * 2.5
            Dim _textbottom_y As Integer = _line_y - (_textheight / 2)
            Dim _textleft As Integer = _left_x + HOLEPUNCH_HOLE_RADIUS
            Dim _colourbottom_y As Integer = _line_y - _textheight * 0.8
            Dim _colourleft As Integer = _left_x
            Dim _colourheight As Integer = _textheight * 1.6
            Dim _colourwidth As Integer = _textwidth * 1.3
            Dim _nametop As Integer = _line_y + _textheight * 0.8
            Dim _nameleft As Integer = _left_x
            Dim _nameheight As Integer = _textheight * THREAD_NAME_FONT_SIZE / THREAD_NUMBER_FONT_SIZE
            Dim _namewidth As Integer = _colourwidth
            Dim _symboltop As Integer = _colourbottom_y
            Dim _symbolheight As Integer = _colourheight
            Dim _symbolwidth As Integer = _colourheight
            Dim _symbolleft As Integer = _left_x + _colourwidth + (oColWidth * (_col + 1) - _left_x - _colourwidth - _symbolwidth) / 2
            Dim _textrect As New Rectangle(New Point(_textleft, _textbottom_y), New Size(_textwidth, _textheight))
            Dim _colourRect As New Rectangle(New Point(_colourleft, _colourbottom_y), New Size(_colourwidth, _colourheight))
            Dim _symbolBorderRect As New Rectangle(New Point(_symbolleft, _symboltop), New Size(_symbolwidth, _symbolheight))
            Dim _symbolRect As New Rectangle(New Point(_symbolleft + (_symbolwidth / 4), _symboltop + (_symbolwidth / 4)), New Size(_symbolwidth / 2, _symbolheight / 2))

            Dim _brush As Brush = New SolidBrush(_thread.Thread.Colour)
            _cardGraphics.FillRectangle(_brush, _colourRect)
            _cardGraphics.FillRectangle(CARD_COLOUR, _textrect)
            _cardGraphics.DrawString(_thread.Thread.ThreadNo, New Font(FAMILY_NAME, THREAD_NUMBER_FONT_SIZE, FontStyle.Regular), THREAD_NUMBER_BRUSH, New Point(_textleft, _textbottom_y))
            _cardGraphics.DrawString(_thread.Thread.ColourName, New Font(FAMILY_NAME, THREAD_NAME_FONT_SIZE, FontStyle.Regular), THREAD_NAME_BRUSH, New Point(_nameleft, _nametop))
            _cardGraphics.FillRectangle(CARD_COLOUR, _symbolBorderRect)
            _cardGraphics.DrawRectangle(LINE_PEN, _symbolBorderRect)
            _cardGraphics.DrawImage(_projectThread.Symbol, _symbolRect)
            _row += 1
        Next
        PicThreadCard.Image = sourceBitmap
        PicThreadCard.Refresh()
    End Sub
    Private Sub AddSelectedCard()
        If LbCards.SelectedIndex > -1 Then
            If _nextCol <= NudColCt.Value - 1 Then
                Dim _cardNo As Integer = CInt(LbCards.SelectedItem)
                Dim _threadList As List(Of ProjectCardThread) = FindProjectCardThreadsByProjectCard(oSelectedProject.ProjectId, _cardNo)
                AddCardToImage(_threadList)
                _nextCol += 1
                AddInstruction(SELECT_CARD)
            Else
                AddInstruction(COLUMNS_FULL)
            End If
        End If
    End Sub
    Private Sub AddInstruction(pText As String)
        AddInstruction(pText, False)
    End Sub
    Private Sub AddInstruction(pText As String, pIsLogged As Boolean)
        ModCommon.AddInstruction(pText, LblInstruction, PnlInstruction, pIsLogged, String.Empty)
    End Sub
#End Region
End Class
