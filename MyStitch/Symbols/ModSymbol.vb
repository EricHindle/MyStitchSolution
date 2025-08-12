' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects

Module ModSymbol
    Public Sub OpenSymbolsForm()
        Using _symbols As New FrmSymbols
            _symbols.ShowDialog()
        End Using
    End Sub
    Public Sub ClearSymbolTable(ByRef pFlp As FlowLayoutPanel)
        pFlp.Controls.Clear()
    End Sub
    Public Function AddSymbolToTable(pFlp As FlowLayoutPanel, _symbol As Symbol) As PictureBox
        Dim _picSymbol As New PictureBox()
        With _picSymbol
            .Name = CStr(_symbol.SymbolId)
            .Size = New Size(28, 28)
            .BackColor = Color.White
            .BorderStyle = BorderStyle.FixedSingle
            .Image = _symbol.SymbolImage
            .SizeMode = PictureBoxSizeMode.Zoom
        End With
        pFlp.Controls.Add(_picSymbol)
        Return _picSymbol
    End Function

End Module
