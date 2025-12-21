' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
''' <summary>
''' Options and settings to be used by all users
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class GlobalSettings
    Private Shared ReadOnly oTable As New MyStitchDataSet.SettingsDataTable

    ''' <summary>
    ''' Get a setting
    ''' </summary>
    ''' <param name="settingName">Name of setting to be returned</param>
    ''' <returns>Value of setting</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSetting(ByVal settingName As String) As Object
        Dim rtnValue As Object = Nothing
        Try
            Dim _setting As GlobalSetting = FindSettingByName(settingName)
            Dim value As String = _setting.Value
            Try
                Select Case _setting.Type.ToLower(myCultureInfo)
                    Case "string"
                        rtnValue = value
                    Case "integer"
                        rtnValue = CInt(value)
                    Case "date"
                        rtnValue = CDate(value)
                    Case "boolean"
                        rtnValue = CBool(value)
                    Case "decimal"
                        rtnValue = CDec(value)
                    Case "char"
                        rtnValue = CChar(value)
                End Select
            Catch ex As ArgumentNullException

            End Try

        Catch ex As Exception
            Throw
        End Try
        Return rtnValue
    End Function
    Public Shared Function GetBooleanSetting(ByVal settingName As String) As Boolean
        Dim rtnBooleanValue As Boolean = False
        Dim rtnValue As Object = GetSetting(settingName)
        If rtnValue Is Nothing Then
            LogUtil.Problem("Missing Global value " & settingName, "GetBooleanSetting")
        Else
            rtnBooleanValue = CBool(rtnValue)
        End If
        Return rtnBooleanValue
    End Function
    Public Shared Function GetIntegerSetting(ByVal settingName As String) As Integer
        Dim rtnIntegerValue As Integer = 0
        Dim rtnValue As Object = GetSetting(settingName)
        If rtnValue Is Nothing Then
            LogUtil.Problem("Missing Global value " & settingName, "GetIntegerSetting")
        Else
            rtnIntegerValue = CInt(rtnValue)
        End If
        Return rtnIntegerValue
    End Function

    Public Shared Function SetSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String) As Boolean
        Return AmendSetting(settingName, settingType, settingValue)
    End Function

    Public Shared Function NewSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String) As Boolean
        Return AddNewSetting(settingName, settingValue, settingType)
    End Function

    Public Shared Sub LoadGlobalSettings()
        My.Settings.Save()
    End Sub

End Class
