' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Imports HindlewareLib.Logging

Module ModCards
    Public isCardsLoading As Boolean

    Public Function LoadCardList(pProjectId As Integer, ByRef pListBox As ListBox, pBasename As String) As Integer
        LogUtil.LogInfo("Load card list", pBasename)
        isCardsLoading = True
        Dim oLastCardNo As Integer = 0
        pListBox.Items.Clear()
        Dim _list As List(Of ProjectThreadCard) = GetProjectThreadCards(pProjectId)
        For Each oProjectCard As ProjectThreadCard In _list
            pListBox.Items.Add(oProjectCard.CardNo)
            If oProjectCard.CardNo > oLastCardNo Then oLastCardNo = oProjectCard.CardNo
        Next
        isCardsLoading = False
        Return oLastCardNo
    End Function

End Module
