' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.IO
Imports HindlewareLib.Imaging.ImageUtil
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Objects
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Public Class FrmSymbols
#Region "properties"

#End Region
#Region "constants"
#End Region
#Region "variables"
    Private isLoading As Boolean
    Private isSourceSymbolLoaded As Boolean
    Private oLoadedSymbol As Image
    Private iSelectedSymbolId As Integer
    Private oSelectedSymbol As New Symbol
#End Region
#Region "handlers"
    Private fullFilename As String

    Private Sub BtnImageSel_Click(sender As Object, e As EventArgs) Handles BtnImageSel.Click

        TxtFilename.Text = Path.GetFileName(GetImageFileName(OpenOrSave.Open, ImageType.ALL, My.Settings.ImagePath))
        LoadSourceImage(TxtFilename.Text, PicSymbolSource)
    End Sub

    Public Sub LoadSourceImage(pFilename As String, ByRef pPicBox As PictureBox)
        isSourceSymbolLoaded = False
        If String.IsNullOrEmpty(pFilename) Then
            pPicBox.Image = Nothing
        Else
            Dim fullFilename As String = Path.Combine(My.Settings.ImagePath, pFilename)
            LogUtil.Info("Finding Image " & fullFilename, MyBase.Name)
            If My.Computer.FileSystem.FileExists(fullFilename) Then
                oLoadedSymbol = Image.FromFile(fullFilename)
                pPicBox.Image = oLoadedSymbol
                isSourceSymbolLoaded = True
            Else
                LogUtil.Info("File " & fullFilename & " does not exist", MyBase.Name)
            End If
        End If
        SetButtons()
    End Sub


    Private Sub FrmSymbols_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Symbols", MyBase.Name)
        InitialiseForm()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmSymbols_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.SymbolsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

#End Region
#Region "functions"
    Private Sub InitialiseForm()
        isLoading = True
        GetFormPos(Me, My.Settings.SymbolsFormPos)
        LoadSymbols()
        SetButtons()
        isLoading = False
    End Sub


    Private Sub SetButtons()

        BtnAddSymbol.Enabled = isSourceSymbolLoaded
        BtnRemove.Enabled = oSelectedSymbol.IsLoaded
        BtnReplace.Enabled = oSelectedSymbol.IsLoaded AndAlso isSourceSymbolLoaded

    End Sub

    Private Sub LoadSymbols()
        ClearSymbolTable()
        Dim _symbols As List(Of Symbol) = GetAllSymbols()
        For Each _symbol As Symbol In _symbols
            AddSymbolToTable(_symbol)
        Next
    End Sub

    Private Sub AddSymbolToTable(_symbol As Symbol)
        Dim _picSymbol As New PictureBox()
        With _picSymbol
            .Name = CStr(_symbol.SymbolId)
            .Size = New Size(28, 28)
            .BackColor = Color.White
            .BorderStyle = BorderStyle.FixedSingle
            .Image = _symbol.SymbolImage
            .SizeMode = PictureBoxSizeMode.Zoom
            AddHandler .Click, AddressOf Symbol_Click
        End With
        FlpSymbols.Controls.Add(_picSymbol)
    End Sub
    Private Sub ClearSymbolTable()
        FlpSymbols.Controls.Clear()
    End Sub

    Private Sub BtnAddSymbol_Click(sender As Object, e As EventArgs) Handles BtnAddSymbol.Click
        If isSourceSymbolLoaded Then
            Dim _newSymbol As Symbol = SymbolBuilder.ASymbol.StartingWithNothing.WithSymbolBytes(ConvertImageToBytes(oLoadedSymbol)).Build
            Dim _symbolId As Integer = InsertSymbol(_newSymbol)
            _newSymbol.SymbolId = _symbolId
            AddSymbolToTable(_newSymbol)
            ClearForm()
        End If
    End Sub

    Private Sub ClearForm()
        ClearLoadedSymbol()
        ClearSelectedSymbol()
    End Sub

    Private Sub ClearLoadedSymbol()
        isSourceSymbolLoaded = False
        oLoadedSymbol = Nothing
        TxtFilename.Text = String.Empty
        PicSymbolSource.Image = Nothing
        SetButtons()
    End Sub

    Private Sub ClearSelectedSymbol()
        iSelectedSymbolId = -1
        oSelectedSymbol = New Symbol
        LblImageId.Text = String.Empty
        PicSelectedSymbol.Image = Nothing
        SetButtons()
    End Sub

    Private Sub Symbol_Click(sender As Object, e As EventArgs)
        Dim _picBox As PictureBox = CType(sender, PictureBox)
        iSelectedSymbolId = CInt(_picBox.Name)
        oSelectedSymbol = GetSymbolById(iSelectedSymbolId)
        PicSelectedSymbol.Image = oSelectedSymbol.SymbolImage
        LblImageId.Text = CStr(oSelectedSymbol.SymbolId)
        SetButtons()
    End Sub

    Private Sub BtnClearSelected_Click(sender As Object, e As EventArgs) Handles BtnClearSelected.Click
        ClearSelectedSymbol()
    End Sub

    Private Sub BtnClearLoaded_Click(sender As Object, e As EventArgs) Handles BtnClearLoaded.Click
        ClearLoadedSymbol()
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If iSelectedSymbolId > 0 Then
            DeleteSymbol(iSelectedSymbolId)
            LoadSymbols()
            ClearSelectedSymbol()
        End If
    End Sub

    Private Sub BtnReplace_Click(sender As Object, e As EventArgs) Handles BtnReplace.Click
        If isSourceSymbolLoaded And iSelectedSymbolId > 0 Then
            Dim _newSymbol As Symbol = SymbolBuilder.ASymbol.StartingWith(oSelectedSymbol).WithSymbolBytes(ConvertImageToBytes(oLoadedSymbol)).Build
            UpdateSymbol(_newSymbol)
            LoadSymbols()
            ClearForm()
        End If

    End Sub


#End Region
End Class