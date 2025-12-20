' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Public Class FrmBeads
#Region "properties"
#End Region

#Region "variables"
    Private _selectedBead As New Bead
    Private isLoading As Boolean
    Private _colrCap As New FrmColourCapture
    Private isShowStock As Boolean
#End Region
#Region "handlers"
    Private Sub FrmBead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("ProjectBead maintenence", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmBead_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        If _colrCap IsNot Nothing AndAlso Not _colrCap.IsDisposed Then
            _colrCap.Close()
        End If
        My.Settings.BeadFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub DgvBeads_SelectionChanged(sender As Object, e As EventArgs) Handles DgvBeads.SelectionChanged
        If Not isLoading Then
            If DgvBeads.SelectedRows.Count = 1 Then
                _selectedBead = FindBeadById(DgvBeads.SelectedRows(0).Cells(BeadId.Name).Value)
            Else
                _selectedBead = BeadBuilder.ABead.StartingWithNothing.Build
            End If
            LoadBeadForm(_selectedBead)
        End If
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        InsertNewBead()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        UpdateSelectedBead()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelectedBead()
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearBeadForm()
        DgvBeads.ClearSelection()
    End Sub
#End Region
#Region "functions"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.BeadFormPos)
        isLoading = True
        ChkShowStock.Checked = My.Settings.isShowStockLevels
        LoadBeadList(DgvBeads, isShowStock, MyBase.Name)
        LoadBrandList(CbBrand)
        ClearBeadForm()
        isLoading = False
    End Sub
    Private Sub ClearBeadForm()
        DgvBeads.ClearSelection()
        LblId.Text = _selectedBead.BeadId
        LblId.Visible = False
        TxtName.Text = ""
        TxtNumber.Text = ""
        TxtR.Text = String.Empty
        TxtG.Text = String.Empty
        TxtB.Text = String.Empty
        Dim _colour As Color = Color.White
        LblColour.BackColor = _colour
        CbBrand.SelectedIndex = -1
    End Sub
    Private Sub LoadBeadForm(oBead As Bead)
        _selectedBead = oBead
        LblId.Text = _selectedBead.BeadId
        LblId.Visible = True
        TxtName.Text = oBead.ColourName
        TxtNumber.Text = CStr(oBead.beadNo)
        Dim _colour As Color = oBead.Colour
        CbBrand.SelectedValue = oBead.BrandId
        Select Case oBead.StockLevel
            Case < STOCK_NOTMUCH
                RbNone.Checked = True
            Case < STOCK_SOME
                RbNotMuch.Checked = True
            Case < STOCK_ENOUGH
                RbSome.Checked = True
            Case < STOCK_PLENTY
                RbEnough.Checked = True
            Case Else
                RbPlenty.Checked = True
        End Select
        SetFormColour(_colour)
    End Sub
    Friend Sub SetFormColour(_colour As Color)
        LblColour.BackColor = _colour
        TxtR.Text = CStr(_colour.R)
        TxtG.Text = CStr(_colour.G)
        TxtB.Text = CStr(_colour.B)
    End Sub
    Private Function BuildBeadFromForm(pId As Integer) As Bead
        Dim _Bead As Bead = BeadBuilder.ABead.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                    .WithColour(LblColour.BackColor) _
                                                    .WithNumber(TxtNumber.Text) _
                                                    .WithStockLevel(CalcStock) _
                                                    .WithBrandId(CbBrand.SelectedValue) _
                                                    .Build()
        Return _Bead
    End Function
    Private Function CalcStock() As Integer
        Dim _level As Integer
        Select Case True
            Case RbNone.Checked
                _level = STOCK_NONE
            Case RbNotMuch.Checked
                _level = STOCK_NOTMUCH
            Case RbSome.Checked
                _level = STOCK_SOME
            Case RbEnough.Checked
                _level = STOCK_ENOUGH
            Case RbPlenty.Checked
                _level = STOCK_PLENTY
        End Select
        Return _level
    End Function
    Private Sub InsertNewBead()
        LogUtil.LogInfo("New ProjectBead", MyBase.Name)
        Dim _existingBead As Bead = FindBeadByNumber(TxtNumber.Text.Trim)
        If _existingBead.beadId > 0 Then
            LogUtil.DisplayStatus("ProjectBead with this number already exists.", LblStatus, "Insert New ProjectBead", True)
        Else
            Dim _Bead As Bead = BuildBeadFromForm(_selectedBead.beadId)
            _Bead.beadId = AddNewBead(_Bead)
            LoadBeadList(DgvBeads, isShowStock, MyBase.Name)
            LogUtil.ShowStatus("ProjectBead Added", LblStatus, MyBase.Name)
        End If
    End Sub
    Private Sub UpdateSelectedBead()
        If _selectedBead.beadId >= 0 Then
            LogUtil.LogInfo("Updating ProjectBead", MyBase.Name)
            Dim _rowNo As Integer = DgvBeads.SelectedRows(0).Index - DgvBeads.FirstDisplayedCell.RowIndex
            Dim _Bead As Bead = BuildBeadFromForm(_selectedBead.beadId)
            AmendBead(_Bead)
            LoadBeadList(DgvBeads, isShowStock, MyBase.Name)
            SelectItemInList(DgvBeads, beadId.Name, _Bead.beadId, _rowNo)
            LogUtil.ShowStatus("ProjectBead updated", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No ProjectBead selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Friend Sub DeleteSelectedBead()
        If _selectedBead.beadId >= 0 Then
            LogUtil.LogInfo("Delete ProjectBead", MyBase.Name)

            RemoveBead(_selectedBead)
            ClearBeadForm()
            LoadBeadList(DgvBeads, isShowStock, MyBase.Name)
        Else
            LogUtil.ShowStatus("No ProjectBead selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Private Sub RGB_ValueChanged(sender As Object, e As EventArgs) Handles TxtR.TextChanged, TxtG.TextChanged, TxtB.TextChanged
        If IsNumeric(TxtR.Text) AndAlso IsNumeric(TxtG.Text) AndAlso IsNumeric(TxtB.Text) Then
            Dim _newColor As Color = Color.FromArgb(CInt(TxtR.Text), CInt(TxtG.Text), CInt(TxtB.Text))
            LblColour.BackColor = _newColor
        End If
    End Sub
    Private Sub BtnColourCapture_Click(sender As Object, e As EventArgs) Handles BtnColourCapture.Click
        If _colrCap Is Nothing OrElse _colrCap.IsDisposed Then
            _colrCap = New FrmColourCapture
        End If
        _colrCap.BeadForm = Me
        _colrCap.Show()
    End Sub
    Private Sub BtnGetColour_Click(sender As Object, e As EventArgs)
        Dim _color As Color = _colrCap.SelectedColour
        SetFormColour(_color)
    End Sub
    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        SelectThreadInList(DgvBeads, beadNo.Name, TxtNumber.Text)
    End Sub
    Private Sub ChkShowStock_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowStock.CheckedChanged
        isShowStock = ChkShowStock.Checked
        If Not isLoading Then
            LoadBeadList(DgvBeads, isShowStock, MyBase.Name)
        End If
    End Sub
    Private Sub BtnPasteFromImage_Click(sender As Object, e As EventArgs) Handles BtnPasteFromImage.Click
        If Clipboard.ContainsImage Then
            Dim _bitmap As Bitmap = Clipboard.GetImage
            SetFormColour(_bitmap.GetPixel(0, 0))
        End If
    End Sub
#End Region
End Class