' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Module ModCards
    Public isCardsLoading As Boolean
    Public Sub OpenBuildCardsForm(pProject As Project)
        Using _buildCards As New FrmBuildThreadCards
            _buildCards.SelectedProject = pProject
            _buildCards.ShowDialog()
        End Using
    End Sub
    Public Sub OpenPrintCardsForm()
        Using _PrintCards As New FrmPrintThreadCards
            _PrintCards.ShowDialog()
        End Using
    End Sub
    Public Function LoadCardList(pProjectId As Integer, ByRef pListBox As ListBox, pBasename As String) As Integer
        LogUtil.LogInfo("Load card list", pBasename)
        isCardsLoading = True
        Dim oLastCardNo As Integer = 0
        pListBox.Items.Clear()
        Dim _list As List(Of ProjectThreadCard) = GetProjectThreadCardsList(pProjectId)
        For Each oProjectCard As ProjectThreadCard In _list
            pListBox.Items.Add(oProjectCard.CardNo)
            If oProjectCard.CardNo > oLastCardNo Then oLastCardNo = oProjectCard.CardNo
        Next
        isCardsLoading = False
        Return oLastCardNo
    End Function

End Module
