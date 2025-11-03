' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class GlobalSettingBuilder
#Region "variables"
        Private _name As String
        Private _type As String
        Private _value As String
#End Region
#Region "functions"

        Public Shared Function AGlobalSetting() As GlobalSettingBuilder
            Return New GlobalSettingBuilder
        End Function
        Public Function StartingWithNothing() As GlobalSettingBuilder
            _name = ""
            _type = ""
            _value = ""
            Return Me
        End Function
        Public Function StartingWith(pRow As SettingsRow) As GlobalSettingBuilder
            StartingWithNothing()
            If pRow IsNot Nothing Then
                _name = pRow.pKey
                _type = pRow.pType
                _value = pRow.pValue
            End If
            Return Me
        End Function
        Public Function StartingWith(pSetting As GlobalSetting) As GlobalSettingBuilder
            _name = pSetting.Name
            _type = pSetting.Type
            _value = pSetting.Value
            Return Me
        End Function
        Public Function WithName(ByVal pName As String) As GlobalSettingBuilder
            _name = pName
            Return Me
        End Function
        Public Function WithType(ByVal pType As String) As GlobalSettingBuilder
            _type = pType
            Return Me
        End Function
        Public Function WithValue(ByVal pValue As String) As GlobalSettingBuilder
            _value = pValue
            Return Me
        End Function
        Public Function Build() As GlobalSetting
            Return New GlobalSetting(_name, _type, _value)
        End Function
#End Region

    End Class
End Namespace
