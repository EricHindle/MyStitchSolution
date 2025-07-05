' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports HindlewareLib.Logging
Module ModCommon
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture

    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
    Public Function GetFormPos(ByRef oForm As Form, ByVal sPos As String) As Boolean
        LogUtil.Info("Getting form position for " & oForm.Name, "GetFormPos")
        Dim isOK As Boolean = True
        If sPos = "max" Then
            oForm.WindowState = FormWindowState.Maximized
        ElseIf sPos = "min" Then
            oForm.WindowState = FormWindowState.Minimized
        Else
            Dim pos As String() = sPos.Split("~")
            If pos.Length = 4 Then
                oForm.Top = CInt(pos(0))
                oForm.Left = CInt(pos(1))
                oForm.Height = CInt(pos(2))
                oForm.Width = CInt(pos(3))
            Else
                isOK = False
            End If
        End If
        Return isOK
    End Function
    Public Function SetFormPos(ByRef oForm As Form) As String
        Dim sPos As String
        If oForm.WindowState = FormWindowState.Maximized Then
            sPos = "max"
        ElseIf oForm.WindowState = FormWindowState.Minimized Then
            sPos = "min"
        Else
            sPos = oForm.Top & "~" & oForm.Left & "~" & oForm.Height & "~" & oForm.Width
        End If
        LogUtil.Debug("Generated form position: " & sPos, "SetFormPos")
        Return sPos
    End Function
    Public Sub TryCopyFile(pFullname As String, pDestination As String, pOverwrite As Boolean)
        Try
            My.Computer.FileSystem.CopyFile(pFullname, pDestination, pOverwrite)
        Catch ex As Exception When (TypeOf ex Is ArgumentException _
                        OrElse TypeOf ex Is FileNotFoundException _
                        OrElse TypeOf ex Is IOException _
                        OrElse TypeOf ex Is NotSupportedException _
                        OrElse TypeOf ex Is PathTooLongException _
                        OrElse TypeOf ex Is UnauthorizedAccessException _
                        OrElse TypeOf ex Is Security.SecurityException)
            LogUtil.DisplayException(ex, "Archive file", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
End Module
