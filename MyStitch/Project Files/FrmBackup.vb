' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Imports MyStitch.Domain.Objects
Public Class FrmBackup
#Region "properties"

#End Region
#Region "constants"

#End Region
#Region "variables"
    Private backupPath As String
    Private dbBackupPath As String
    Private dataPath As String
    Private optionsPath As String
    Private designPath As String
    Private designArchivePath As String
    Private imagePath As String
    Private oProjectList As List(Of Project)
    Private isFormInitialised As Boolean
    Private tableCheckCount As Integer
    Private docCheckCount As Integer
    Private imageCheckCount As Integer
    Private isParentCheck As Boolean
#End Region
#Region "form control handlers"
    Private Sub FrmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddProgress("Backup")
        isFormInitialised = True
        InitialiseData()
        GetFormPos(Me, My.Settings.BackUpFormPos)
        PbCopyProgress.Visible = False
        ApplySettings()
        AddProgress("Selecting Data", 1, 1)
        LoadTables()
        LoadImages()
        LoadDesigns()
        KeyPreview = True
    End Sub

    Friend Sub ApplySettings()
        TxtBackupPath.Text = My.Settings.BackupPath
        chkAddDate.Checked = My.Settings.BackupAddDate
        ChkArchive.Checked = My.Settings.BackupArchive
        ChkIncludeDb.Checked = My.Settings.BackUpDb
        ChkRevision.Checked = My.Settings.BackupRevision
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub TreeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvDatatables.AfterCheck, TvDesigns.AfterCheck, TvImages.AfterCheck

        Dim node As TreeNode = e.Node
        If node.Name.StartsWith(TABLE_TAG) Then
            tableCheckCount += If(node.Checked, 1, -1)
        End If
        If node.Name.StartsWith(DOC_TAG) Then
            docCheckCount += If(node.Checked, 1, -1)
        End If
        If node.Name.StartsWith(IMAGE_TAG) Then
            imageCheckCount += If(node.Checked, 1, -1)
        End If
        If node.Checked AndAlso node.Parent IsNot Nothing AndAlso Not node.Parent.Checked Then
            isParentCheck = True
            node.Parent.Checked = True
            isParentCheck = False
        End If
        Dim ischecked As Boolean = node.Checked
        If Not isParentCheck Then
            For Each subNode As TreeNode In node.Nodes
                If Not subNode.Checked = ischecked Then
                    subNode.Checked = ischecked
                End If
            Next
        End If
        LblCounts.Text = String.Format("T:{0} D:{1} I:{2}", CStr(tableCheckCount), CStr(docCheckCount), CStr(imageCheckCount))
        StatusStrip1.Refresh()
    End Sub
    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        If tableCheckCount + imageCheckCount > 0 Or ChkIncludeDb.Checked Then
            Dim isOKToBackup As Boolean = CheckPaths()
            If isOKToBackup Then
                AddProgress("Backup started", 1, 1)
                AddProgress("Backing up to " & backupPath, 2)
                If ChkIncludeDb.Checked Then
                    DbBackup()
                End If
                If CountCheckedTableNodes() > 0 Then
                    DataTableBackup()
                End If
                If imageCheckCount > 0 Then
                    ImagesBackup()
                End If
                If CountCheckedDesignNodes() > 0 Then
                    DesignsBackup()
                End If
                OptionsBackup()
                AddProgress("Backup complete", 1, 1)
            End If
        Else
            AddProgress("Nothing Selected", 1, 1)
        End If
        ClearAll()
    End Sub
    Private Sub BtnSavePath_Click(sender As Object, e As EventArgs) Handles BtnSavePath.Click
        My.Settings.BackupPath = TxtBackupPath.Text
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectPath_Click(sender As Object, e As EventArgs) Handles BtnSelectPath.Click
        SelectPath()
    End Sub
    Private Sub FrmBackup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.BackUpFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectAll_Click(sender As Object, e As EventArgs) Handles BtnSelectAll.Click
        SelectAll()
    End Sub

    Private Sub MnuClear_Click(sender As Object, e As EventArgs) Handles MnuClear.Click
        rtbProgress.Text = ""
    End Sub
    Private Sub ChkArchive_CheckedChanged(sender As Object, e As EventArgs) Handles ChkArchive.CheckedChanged
        If isFormInitialised Then
            LoadDesigns()
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Function CountCheckedTableNodes() As Integer
        Dim _tablesnode As TreeNode = TvDatatables.Nodes(0)
        Return CountCheckedNodes(_tablesnode, TABLE_TAG)
    End Function
    Private Function CountCheckedDesignNodes() As Integer
        Dim oArcNode As TreeNode = Nothing
        For Each _node As TreeNode In TvDesigns.Nodes(0).Nodes
            If _node.Name.StartsWith(ARC_TAG) Then
                oArcNode = _node
            End If
        Next
        Dim _designCt As Integer = CountCheckedNodes(TvDesigns.Nodes(0), DOC_TAG)
        Dim _archiveCt As Integer = 0
        If oArcNode IsNot Nothing Then
            _archiveCt = CountCheckedNodes(oArcNode, DOC_TAG)
        End If
        Return _designCt + _archiveCt
    End Function
    Private Function CountCheckedImageNodes() As Integer
        Dim _imagenode As TreeNode = TvImages.Nodes(0).Nodes(0)
        Return CountCheckedNodes(_imagenode, IMAGE_TAG)
    End Function
    Private Function CountCheckedNodes(pNode As TreeNode, pTag As String) As Integer
        Dim checkedNodeCount As Integer = 0
        For Each _subnode As TreeNode In pNode.Nodes
            If _subnode.Checked Then
                If _subnode.Name.StartsWith(pTag) Then
                    checkedNodeCount += 1
                End If
            End If
        Next
        Return checkedNodeCount
    End Function
    Private Sub LoadTables()
        AddProgress("Filling dB Table Tree", 2)
        FillTableTree(TvDatatables)
        tableCheckCount = 0
        TvDatatables.ExpandAll()
    End Sub
    Private Sub LoadImages()
        AddProgress("Filling Image Tree", 2)
        FillImageTree()
        TvImages.ExpandAll()
    End Sub
    Private Sub LoadDesigns()
        AddProgress("Filling Design Tree", 2)
        FillDesignTree()
        TvDesigns.ExpandAll()
    End Sub

    Private Sub ExpandDocumentTree()
        For Each _booknode As TreeNode In TvDesigns.Nodes
            _booknode.Expand()
            For Each _typenode As TreeNode In _booknode.Nodes
                _typenode.Expand()
                For Each _docnode As TreeNode In _typenode.Nodes
                    _docnode.Expand()
                Next
            Next
        Next
    End Sub

    Friend Sub SelectPath()
        Using fbd As New FolderBrowserDialog
            fbd.RootFolder = Environment.SpecialFolder.MyComputer
            If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                fbd.SelectedPath = TxtBackupPath.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtBackupPath.Text = fbd.SelectedPath
            End If
        End Using
    End Sub
    Friend Sub SelectAll()
        TvDatatables.Nodes(0).Checked = True
        TvDesigns.Nodes(0).Checked = True
        TvImages.Nodes(0).Checked = True
    End Sub
    Friend Sub ClearAll()
        TvDatatables.Nodes(0).Checked = False
        TvDesigns.Nodes(0).Checked = False
        TvImages.Nodes(0).Checked = False
    End Sub

    Private Sub FillImageTree()
        TvImages.Nodes.Clear()
        imageCheckCount = 0
        TvImages.Nodes.Add("Images")
        Dim _SourceImagePath As String = My.Settings.ImagePath
        Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(_SourceImagePath)
        For Each _filename As String In fileList
            Dim _fname As String = Path.GetFileName(_filename)
            TvImages.Nodes(0).Nodes.Add(IMAGE_TAG & _filename, _fname)

        Next
    End Sub
    Private Sub FillDesignTree()
        TvDesigns.Nodes.Clear()
        docCheckCount = 0
        Dim _designNode As TreeNode = TvDesigns.Nodes.Add("Design files")
        Dim _filepath As String = My.Settings.DesignFilePath
        Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(_filepath)
        For Each _filename As String In fileList
            Dim _fname As String = Path.GetFileName(_filename)
            Dim _fileNode As TreeNode = _designNode.Nodes.Add(DOC_TAG & _filename, _fname)
        Next
        If ChkArchive.Checked Then
            Dim _archiveNode As TreeNode = _designNode.Nodes.Add(ARC_TAG & "Archive", "Archive files")
            _filepath = Path.Combine(My.Settings.DesignFilePath, "archive")
            fileList = My.Computer.FileSystem.GetFiles(_filepath)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                Dim _fileNode As TreeNode = _archiveNode.Nodes.Add(DOC_TAG & _filename, _fname)
            Next
        End If
    End Sub
    Private Function CheckPaths() As Boolean
        AddProgress("Checking paths", 1, 1)
        Dim isOKToBackup As Boolean = True
        If Not TxtBackupPath.Text.Contains(":") Then
            AddProgress("No drive specified")
            isOKToBackup = False
        Else
            Dim _driveLetter As String = Split(TxtBackupPath.Text, ":", 2)(0)
            If Not My.Computer.FileSystem.DirectoryExists(_driveLetter & ":\") Then
                AddProgress("Drive does not exist.")
                isOKToBackup = False
            Else
                If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                    backupPath = If(chkAddDate.Checked, Path.Combine(TxtBackupPath.Text.Trim, Format(Today, "yyyyMMdd")), TxtBackupPath.Text.Trim)
                    imagePath = Path.Combine(backupPath, "images")
                    designPath = Path.Combine(backupPath, "designs")
                    designArchivePath = Path.Combine(designPath, "archive")
                    If Not CheckPathExists(backupPath) Then isOKToBackup = False
                    If ChkIncludeDb.Checked Then
                        dbBackupPath = Path.Combine(backupPath, "MSSQL")
                        If Not CheckPathExists(dbBackupPath) Then isOKToBackup = False
                    End If
                    If CountCheckedTableNodes() > 0 Then
                        dataPath = Path.Combine(backupPath, "data")
                        If Not CheckPathExists(dataPath) Then isOKToBackup = False
                    End If

                    If Not CheckPathExists(imagePath) Then isOKToBackup = False

                    If Not CheckPathExists(designPath) Then isOKToBackup = False
                    If ChkArchive.Checked Then
                        If Not CheckPathExists(designArchivePath) Then isOKToBackup = False
                    End If
                Else
                    AddProgress("No destination. No backup.")
                    isOKToBackup = False
                End If
            End If
        End If
        Return isOKToBackup
    End Function
    Private Function CheckPathExists(_path As String) As Boolean
        Dim isOK As Boolean = True
        Try
            If Not My.Computer.FileSystem.DirectoryExists(_path) Then
                AddProgress("Creating folder " & _path, 2)
                My.Computer.FileSystem.CreateDirectory(_path)
            End If
        Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                 Or TypeOf ex Is PathTooLongException _
                                 Or TypeOf ex Is NotSupportedException _
                                 Or TypeOf ex Is IOException _
                                 Or TypeOf ex Is UnauthorizedAccessException)
            LogUtil.DisplayException(ex, "File creation", MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        End Try
        Return isOK
    End Function
    Private Sub ImageBackup()
        AddProgress("Image backup", 4, 2)
        For Each oNode As TreeNode In TvImages.Nodes(0).Nodes
            If oNode.Checked Then
                Dim _filename As String = oNode.Text
                Dim _fullname As String = oNode.Name.Replace(IMAGE_TAG, "")
                Dim destination As String = Path.Combine(imagePath, _filename)
                Dim _overwritten As String = ""
                If My.Computer.FileSystem.FileExists(destination) Then
                    _overwritten = " (*)"
                End If
                My.Computer.FileSystem.CopyFile(_fullname, destination, True)
                AddProgress(_filename & " copied" & _overwritten, 5)
                PbCopyProgress.PerformStep()
                StatusStrip1.Refresh()
                oNode.Checked = False
            End If
        Next
        PbCopyProgress.Visible = False
        TvImages.Nodes(0).Checked = False
    End Sub
    Private Sub DbBackup()
        AddProgress("dB backup", 2, 2)
        Dim _initBackup As String = If(My.Settings.AppendDbBackup, "NOINIT", "INIT")
        Dim _dbName As String = "MyStitch"
        Dim _bakFileName As String = Path.Combine(dbBackupPath, _dbName & "_" & Format(Today, "yyyyMMdd") & ".bak")
        Dim _commandSQL As New StringBuilder
        _commandSQL.Append("BACKUP DATABASE [") _
            .Append(_dbName) _
            .Append("] TO  DISK = N'") _
            .Append(_bakFileName) _
            .Append("' WITH NOFORMAT, ") _
            .Append(_initBackup) _
            .Append(",  NAME = N'") _
            .Append(_dbName) _
            .Append("-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10")
        Dim _command As New Global.System.Data.SqlClient.SqlCommand With {
            .Connection = New Global.System.Data.SqlClient.SqlConnection With {
            .ConnectionString = Global.MyStitch.My.MySettings.Default.MyStitchConnectionString
        },
            .CommandText = _commandSQL.ToString,
            .CommandType = Global.System.Data.CommandType.Text
        }
        Dim previousConnectionState As Global.System.Data.ConnectionState = _command.Connection.State
        If ((_command.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
            AddProgress("Opening dB connection to " & _dbName, 4)
            _command.Connection.Open()
        End If
        Dim returnValue As Integer
        Try
            AddProgress("Executing SQL", 4)
            returnValue = _command.ExecuteNonQuery
        Catch ex As InvalidCastException
            LogUtil.DisplayException(ex, "Backup SQL", MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As SqlClient.SqlException
            LogUtil.DisplayException(ex, "Backup SQL", MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As IOException
            LogUtil.DisplayException(ex, "Backup SQL", MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As InvalidOperationException
            LogUtil.DisplayException(ex, "Backup SQL", MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Finally
            If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                AddProgress("Closing dB connection", 4)
                _command.Connection.Close()
            End If
        End Try
    End Sub
    Private Sub ImagesBackup()
        AddProgress("Images backup", 2, 2)
        imagePath = Path.Combine(backupPath, "images")
        ImageBackup()

    End Sub
    Private Sub DesignsBackup()
        AddProgress("Designs backup", 2, 2)
        designPath = Path.Combine(backupPath, "designs")
        DesignBackup()
    End Sub

    Private Sub DesignBackup()
        For Each oDesignNode As TreeNode In TvDesigns.Nodes
            DisplayProgressBar(oDesignNode)
            AddProgress(oDesignNode.Text, 3, 2)
            For Each oNode As TreeNode In oDesignNode.Nodes
                If oNode.Checked Then
                    If oNode.Name.StartsWith(DOC_TAG) Then
                        oNode = BackupDocFile(oNode, False)
                    ElseIf oNode.Name.StartsWith(ARC_TAG) Then
                        AddProgress(oNode.Text, 3, 2)
                        For Each aNode As TreeNode In oNode.Nodes
                            If aNode.Checked Then
                                If aNode.Name.StartsWith(DOC_TAG) Then
                                    aNode = BackupDocFile(aNode, True)
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            oDesignNode.Checked = False
        Next
        PbCopyProgress.Visible = False
    End Sub

    Private Function BackupDocFile(oNode As TreeNode, pIsArchive As Boolean) As TreeNode
        Dim _filename As String = oNode.Text
        Dim _fullname As String = oNode.Name.Replace(DOC_TAG, "")
        Dim _destFilename As String = Path.GetFileNameWithoutExtension(_filename)
        Dim _destExtention As String = Path.GetExtension(_filename)
        Dim _destVersion As String = String.Empty
        If My.Computer.FileSystem.FileExists(_fullname) Then
            Dim filenameWithVersion As String = _destFilename & _destVersion & _destExtention
            Dim destination As String = Path.Combine(If(pIsArchive, designArchivePath, designPath), filenameWithVersion)
            Dim _overwritten As String = ""
            If My.Computer.FileSystem.FileExists(destination) Then
                _overwritten = " (*)"
            End If
            TryCopyFile(_fullname, destination, True)
            AddProgress(_filename & " copied" & _overwritten, 6)
            PbCopyProgress.PerformStep()
            StatusStrip1.Refresh()
            oNode.Checked = False
        Else
            AddProgress("!!!! Error :" & oNode.Text & " does not exist !!!!")
        End If

        Return oNode
    End Function

    Private Sub OptionsBackup()

    End Sub
    Private Sub DisplayProgressBar(pNode As TreeNode)
        PbCopyProgress.Value = 0
        Dim _selct As Integer = 0
        For Each oNode As TreeNode In pNode.Nodes
            If oNode.Checked Then
                _selct += 1
            End If
        Next
        PbCopyProgress.Maximum = _selct
        PbCopyProgress.Visible = True
    End Sub
    Private Sub DataTableBackup()
        Dim _itemList As New List(Of String)
        AddProgress("Data backup", 2, 2)
        DisplayProgressBar(TvDatatables.Nodes(0))
        For Each oNode As TreeNode In TvDatatables.Nodes(0).Nodes
            If oNode.Checked Then
                Dim _table As String = oNode.Text.Replace(TABLE_TAG, "")
                AddProgress(_table, 3)
                Dim _isTableSaved As Boolean = False
                Select Case _table
                    Case "Projects"
                        _itemList.Add(BackupTable(GetProjectTable))
                        _isTableSaved = True
                    Case "Threads"
                        _itemList.Add(BackupTable(GetThreadTable))
                        _isTableSaved = True
                    Case "ProjectThreadCards"
                        _itemList.Add(BackupTable(GetProjectThreadCardsTable))
                        _isTableSaved = True
                    Case "ProjectThreads"
                        _itemList.Add(BackupTable(GetProjectThreadsTable))
                        _isTableSaved = True
                    Case "ProjectCardThread"
                        _itemList.Add(BackupTable(GetProjectCardThreadTable))
                        _isTableSaved = True
                    Case "Symbols"
                        _itemList.Add(BackupTable(GetSymbolsTable))
                        _isTableSaved = True
                    Case "Settings"
                        _itemList.Add(BackupTable(GetSettingsTable))
                        _isTableSaved = True
                    Case "ProjectWorkTimes"
                        _itemList.Add(BackupTable(GetProjectWorkTimesTable))
                        _isTableSaved = True
                End Select
                If _isTableSaved Then
                    oNode.Checked = False
                Else
                    AddProgress(_table & " unrecognised. Not backed up.", 12, 4)
                End If
            End If
        Next
        PbCopyProgress.Visible = False
        TvDatatables.Nodes(0).Checked = False
    End Sub
    Private Sub AddProgress(pText As String, Optional pTextLevel As Integer = 0, Optional pHeadingLevel As Integer = 0)
        Dim _padchar As Char = " "
        Select Case pHeadingLevel
            Case 1
                _padchar = "="c
            Case 2
                _padchar = "-"c
            Case 4
                _padchar = "!"c
        End Select
        LogUtil.Info(pText, MyBase.Name)
        pText = pText.PadLeft(pText.Length + pTextLevel, " "c)
        rtbProgress.Text &= vbCrLf & pText
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        rtbProgress.ScrollToCaret()
        rtbProgress.Refresh()
    End Sub
    Private Function BackupTable(backupDataTable As DataTable) As String
        Dim sTableName As String = backupDataTable.TableName
        Dim sDbFullPath As String = dataPath
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        backupDataTable.WriteXml(sBackupFile, XmlWriteMode.WriteSchema)
        AddProgress(sBackupFile & " complete", 12)
        PbCopyProgress.PerformStep()
        StatusStrip1.Refresh()
        Return sTableName
    End Function

#End Region
End Class