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

Public Class FrmBrands
#Region "properties"
#End Region

#Region "variables"
    Private _selectedBrand As New Brand
    Private isLoading As Boolean
#End Region
#Region "handlers"
    Private Sub FrmBrand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Brand maintenence", MyBase.Name)
        isLoading = True
        InitialiseForm()
        isLoading = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmBrand_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.BrandFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub DgvBrands_SelectionChanged(sender As Object, e As EventArgs) Handles DgvBrands.SelectionChanged
        If Not isLoading Then
            If DgvBrands.SelectedRows.Count = 1 Then
                _selectedBrand = FindBrandById(DgvBrands.SelectedRows(0).Cells(brandId.Name).Value)
            Else
                _selectedBrand = BrandBuilder.ABrand.StartingWithNothing.Build
            End If
            LoadBrandForm(_selectedBrand)
        End If
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        InsertNewBrand()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        UpdateSelectedBrand()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelectedBrand()
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearBrandForm()
        DgvBrands.ClearSelection()
    End Sub
#End Region
#Region "functions"
    Private Sub InitialiseForm()
        GetFormPos(Me, My.Settings.BrandFormPos)
        ClearBrandForm()
        LoadBrandList(DgvBrands, MyBase.Name)
    End Sub
    Private Sub ClearBrandForm()
        DgvBrands.ClearSelection()
        LblId.Text = _selectedBrand.BrandId
        TxtName.Text = ""
    End Sub
    Private Sub LoadBrandForm(oBrand As Brand)
        _selectedBrand = oBrand
        LblId.Text = _selectedBrand.BrandId
        TxtName.Text = oBrand.BrandName
    End Sub
    Private Function BuildBrandFromForm(pId As Integer) As Brand
        Dim _Brand As Brand = BrandBuilder.ABrand.StartingWithNothing _
                                                    .WithId(pId) _
                                                    .WithName(TxtName.Text) _
                                                    .Build()
        Return _Brand
    End Function
    Private Sub InsertNewBrand()
        LogUtil.LogInfo("New Brand", MyBase.Name)
        Dim _existingBrand As Brand = FindBrandByName(TxtName.Text.Trim)
        If _existingBrand.BrandId > 0 Then
            LogUtil.DisplayStatus("Brand with this name already exists.", LblStatus, "Insert New Brand", True)
        Else
            Dim _Brand As Brand = BuildBrandFromForm(_selectedBrand.BrandId)
            _Brand.BrandId = AddNewBrand(_Brand.BrandName)
            LoadBrandList(DgvBrands, MyBase.Name)
            LogUtil.ShowStatus("Brand Added", LblStatus, MyBase.Name)
        End If
    End Sub
    Private Sub UpdateSelectedBrand()
        If _selectedBrand.BrandId >= 0 Then
            LogUtil.LogInfo("Updating ProjectBrand", MyBase.Name)
            Dim _rowNo As Integer = DgvBrands.SelectedRows(0).Index - DgvBrands.FirstDisplayedCell.RowIndex
            Dim _Brand As Brand = BuildBrandFromForm(_selectedBrand.BrandId)
            AmendBrand(_Brand)
            LoadBrandList(DgvBrands, MyBase.Name)
            SelectItemInList(DgvBrands, brandId.Name, _Brand.BrandId, _rowNo)
            LogUtil.ShowStatus("Brand updated", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No Brand selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
    Friend Sub DeleteSelectedBrand()
        If _selectedBrand.BrandId >= 0 Then
            LogUtil.LogInfo("Delete ProjectBrand", MyBase.Name)

            RemoveBrand(_selectedBrand)
            ClearBrandForm()
            LoadBrandList(DgvBrands, MyBase.Name)
        Else
            LogUtil.ShowStatus("No ProjectBrand selected", LblStatus, True, MyBase.Name, True)
        End If
    End Sub
#End Region
End Class