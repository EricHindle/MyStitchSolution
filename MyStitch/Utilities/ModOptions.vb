' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Module ModOptions
    Friend Sub SetGridColour(ByRef comboBox As ComboBox, ByRef PicGridColour As PictureBox)
        If comboBox.SelectedIndex > -1 And comboBox.SelectedIndex < comboBox.Items.Count - 1 Then
            PicGridColour.BackColor = oGridColourList(comboBox.SelectedIndex)
        End If
    End Sub
    Friend Sub SetLineColour(pPic As PictureBox, pComboBox As ComboBox, pColourSetting As Integer)
        pPic.BackColor = GetColourFromProject(pColourSetting, oGridColourList)
        Select Case pColourSetting
            Case 1 To 4
                pComboBox.SelectedIndex = pColourSetting - 1
            Case Else
                pComboBox.SelectedIndex = pComboBox.Items.Count - 1
        End Select
    End Sub
End Module
