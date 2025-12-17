' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Module ModPalettes
    Friend Function GetPaletteName(pProjectName) As String
        Dim _result As DialogResult
        Dim _newName As String = pProjectName
        Using _paletteName As New FrmPaletteName
            _paletteName.PaletteName = _newName
            _result = _paletteName.ShowDialog()
            If _result = DialogResult.OK Then
                _newName = _paletteName.PaletteName
            End If
        End Using
        Return _newName
    End Function
    Friend Function FindThreadInPaletteList(pDgv As DataGridView, pColName As String, pValue As Integer) As Integer
        Dim _index As Integer = -1
        For Each orow As DataGridViewRow In pDgv.Rows
            If orow.Cells(pColName).Value = pValue Then
                _index = orow.Index
                Exit For
            End If
        Next
        Return _index
    End Function
End Module
