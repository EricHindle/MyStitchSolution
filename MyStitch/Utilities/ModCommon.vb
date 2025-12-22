' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Globalization
Imports System.IO
Imports HindlewareLib.Logging

Friend Module ModCommon
#Region "constants"
    Public Const DATA_FILE_NAME As String = "MyStitchData"
    Public Const SELECT_PROJECT As String = "Select a Project"
    Public Const SELECT_CARD As String = "Select a Card"
    Public Const ADD_CARD As String = "Add card to page"
#End Region
#Region "variables"
    Public oDataFolderName As String
    Public oDataArchiveFolderName As String
    Public oDesignFolderName As String
    Public oDesignArchiveFolderName As String
    Public oImageFolderName As String
    Public oBackupFolderName As String
    Public oBackupArchiveFolderName As String
    Public oDailyArchivePath As String
    Public oLogFolderName As String
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public isUpgradedSettings As Boolean = False
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
    Public iPanelMax As Integer = 370
    Private _messageForm As FrmMessage

#End Region
#Region "enum"
    Public Enum FormType
        Project
        Design
    End Enum
#End Region
#Region "subroutines"
    Public Sub InitialiseSettings()
        If My.Settings.CallUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.CallUpgrade = 1
            My.Settings.Save()
            isUpgradedSettings = True
        End If
    End Sub
    Public Sub InitialiseLogging()
        If String.IsNullOrEmpty(oLogFolderName) Then
            oLogFolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyStitchLogs")
        End If
        CreateFolder(oLogFolderName, True)
        LogUtil.LogFolder = oLogFolderName
        LogUtil.IsDebugOn = My.Settings.isDebugOn
        LogUtil.StartLogging()
        LogUtil.LogInfo("Settings " & If(isUpgradedSettings, "", "not ") & "upgraded ", "InitialiseLogging")
    End Sub
    Public Sub ShowCriticalError(pText As String, pEx As ApplicationException, pSource As String)
        Using _error As New FrmCriticalError
            _error.ErrorText = pText
            _error.Exception = pEx
            _error.Source = pSource
            _error.ShowDialog()
        End Using
    End Sub
    Public Sub ShowLog()
        Using _logView As New FrmLogViewer
            _logView.FormPosition = My.Settings.LogViewPos
            _logView.ZoomValue = My.Settings.LogZoomValue
            _logView.IsZoomOn = My.Settings.LogZoomOn
            _logView.ShowDialog()
            My.Settings.LogViewPos = _logView.FormPosition
            My.Settings.LogZoomValue = _logView.ZoomValue
            My.Settings.LogZoomOn = _logView.IsZoomOn
            My.Settings.Save()
        End Using
    End Sub
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
    Public Sub KeyHandler(ByRef _form As Form, pFormType As FormType, ByRef e As System.Windows.Forms.KeyEventArgs)
        ' Handle key events for the form
        Dim _designForm As FrmStitchDesign = Nothing
        '      Dim _projectForm As FrmProject = Nothing
        Select Case pFormType
            Case FormType.Design
                _designForm = TryCast(_form, FrmStitchDesign)
            Case FormType.Project
                '            _projectForm = TryCast(_form, FrmProject)
        End Select
        If e.Control Then
            ' Handle control key combinations
            Dim _hotkey As Keys = e.KeyCode
            Select Case _hotkey
                Case Keys.L
                    ' Open Log View form
                    ShowLog()
                    e.Handled = True
                Case Keys.B
                    ' Open Backup form
                    OpenBackupForm()
                    e.Handled = True
                Case Keys.O
                    ' Open Options form
                    OpenPreferencesForm(_form)
                    e.Handled = True
                'Case Keys.G
                '    ' Open Global Settings form
                '    OpenGlobalSettingsForm()
                '    e.Handled = True
                Case Keys.H
                    ' Run housekeeping process
                    RunHousekeeping()
                    e.Handled = True
                Case Keys.X
                    _form.Close()
                    e.Handled = True
                Case Keys.S
                    If pFormType = FormType.Design Then
                        ' Save Design
                        If TypeOf _form Is FrmStitchDesign Then
                            SaveDesign()
                        End If
                        e.Handled = True
                    End If
                Case Keys.D
                    If pFormType = FormType.Design Then
                        Using _designInfo As New FrmDesignInfo()
                            _designInfo.SelectedProject = oProject
                            _designInfo.Design = oProjectDesign
                            _designInfo.ShowDialog()
                        End Using
                        e.Handled = True
                    End If
                Case Keys.P
                    ' Print
                    If pFormType = FormType.Design Then
                        OpenPrintForm(_form, oProject)
                        e.Handled = True
                    End If
                Case Keys.I
                    If pFormType = FormType.Project Then
                        ' Import Image
                        Using _import As New FrmImportImage
                            _import.ShowDialog()
                        End Using
                        e.Handled = True
                    End If
                Case Keys.F
                    ' Fill
                    If pFormType = FormType.Design Then
                        _designForm.BeginFloodFill()
                    End If
                    e.Handled = True
                Case Keys.Z
                    ' Undo
                    If pFormType = FormType.Design Then
                        _designForm.UndoLastAction()
                    End If
                    e.Handled = True
                Case Keys.Y
                    ' Redo
                    If pFormType = FormType.Design Then
                        _designForm.RedoLastUndo()
                    End If
                    e.Handled = True
                Case Keys.Add
                    If pFormType = FormType.Design Then
                        _designForm.IncreaseMagnification()
                        e.Handled = True
                    End If
                Case Keys.Subtract
                    If pFormType = FormType.Design Then
                        _designForm.DecreaseMagnification()
                        e.Handled = True
                    End If
            End Select
        End If
    End Sub
    Public Sub OpenPreferencesForm(pForm As Form)
        Using _options As New FrmOptions
            _options.ShowDialog()
            _options.OriginForm = pForm
        End Using
        LoadSettings(pForm)
    End Sub
    Public Sub LoadSettings(pForm As Form)
        oCentrePenColor = My.Settings.CentrelineColour
        oCentrePenDefaultWidth = My.Settings.CentrelineWidth
        oCentrePen = New Pen(oCentrePenColor, oCentrePenDefaultWidth)
        oCentreBrush = New SolidBrush(oCentrePenColor)
        oSelectionPenColour = My.Settings.SelectionBorderColour
        oSelectionPenDefaultWidth = My.Settings.SelectionBorderWidth
        oSelectionPen = New Pen(oSelectionPenColour, oSelectionPenDefaultWidth)
        oGrid1width = My.Settings.Grid1Thickness
        oGrid5width = My.Settings.Grid5Thickness
        oGrid10width = My.Settings.Grid10Thickness
        oGrid1Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid1Colour, oGridColourList))
        oGrid5Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid5Colour, oGridColourList))
        oGrid10Brush = New SolidBrush(GetColourFromProject(My.Settings.Grid10Colour, oGridColourList))
        oGrid1Pen = New Pen(oGrid1Brush, oGrid1width)
        oGrid5Pen = New Pen(oGrid5Brush, oGrid5width)
        oGrid10Pen = New Pen(oGrid10Brush, oGrid10width)
        oBackstitchPenDefaultWidth = My.Settings.BackstitchWidth
        oVariableWidthFraction = My.Settings.VariableFraction
        isSelectionWidthVariable = My.Settings.isSelectionWidthVariable
        isBackstitchWidthVariable = My.Settings.isBackstitchWidthVariable
        isCentreWidthVariable = My.Settings.isCentrelineWidthVariable
        isGridOn = My.Settings.isGridOn
        isCentreOn = My.Settings.IsCentreOn
        isCentreMarksOn = My.Settings.isCentreMarksOn
        If TypeOf pForm Is FrmStitchDesign Then
            Dim pDesignForm As FrmStitchDesign = CType(pForm, FrmStitchDesign)
            pDesignForm.LoadDesignSettings()
        End If
        If TypeOf pForm Is FrmProject Then
            Dim pProjectForm As FrmProject = CType(pForm, FrmProject)
            pProjectForm.LoadProjectSettings()
        End If
    End Sub
    Public Sub LoadPathSettings()
        ' Load the application paths from settings
        oDataFolderName = My.Settings.DataFilePath
        oDataArchiveFolderName = Path.Combine(oDataFolderName, "Archive")
        oDailyArchivePath = Path.Combine(oDataArchiveFolderName, "DailyDataHistory")
        oDesignFolderName = My.Settings.DesignFilePath
        oDesignArchiveFolderName = Path.Combine(oDesignFolderName, "Archive")
        oImageFolderName = My.Settings.ImagePath
        oBackupFolderName = My.Settings.BackupPath
        oBackupArchiveFolderName = Path.Combine(oBackupFolderName, "Archive")
        oLogFolderName = My.Settings.LogFolder
    End Sub
    Public Sub OpenBackupForm()
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
    End Sub

    'Public Sub OpenGlobalSettingsForm()
    '    LogUtil.Info("Global Options", MethodBase.GetCurrentMethod.Name)
    '    Using _settings As New FrmGlobalSettings
    '        _settings.ShowDialog()
    '    End Using
    'End Sub

    Friend Sub AddInstruction(pText As String, pLabel As Label, pPanel As Panel, pIsLogged As Boolean, pOrigin As String)
        If Not String.IsNullOrWhiteSpace(pText) Then
            pLabel.Text = pText
            pPanel.Visible = True
            If pIsLogged Then
                LogUtil.LogInfo(pText, pOrigin)
            End If
        Else
            pLabel.Text = String.Empty
            pPanel.Visible = False
        End If
        pPanel.Width = Math.Max(iPanelMax, pLabel.Width + 17)
    End Sub

    Public Sub ShowMessage(pMessageText As String, pSource As String)
        ShowMessage(pMessageText, False, True, pSource)
    End Sub
    Public Sub ShowMessage(pMessageText As String, pIsShowclose As Boolean, pIsLogged As Boolean, pSource As String)
        _messageForm = New FrmMessage With {
                                .MessageText = pMessageText,
                                .IsShowClose = pIsShowclose,
                                .IsLogged = pIsLogged,
                                .Source = pSource
            }
        _messageForm.Show()
    End Sub
    Public Sub RemoveMessage()
        If _messageForm IsNot Nothing AndAlso _messageForm.IsDisposed = False Then
            _messageForm.Close()
            _messageForm.Dispose()
        End If
    End Sub
#End Region
End Module
