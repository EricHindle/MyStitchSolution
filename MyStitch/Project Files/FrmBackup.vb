' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Reflection
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
    Private dataArchivePath As String
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
        If tableCheckCount + imageCheckCount > 0 Then
            Dim isOKToBackup As Boolean = CheckPaths()
            If isOKToBackup Then
                AddProgress("Backup started", 1, 1)
                AddProgress("Backing up to " & backupPath, 2)
                If CountCheckedTableNodes() > 0 Then
                    DataTablesBackup()
                End If
                If imageCheckCount > 0 Then
                    ImagesBackup()
                End If
                If CountCheckedDesignNodes() > 0 Then
                    DesignsBackup()
                End If
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
            LoadTables()
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
        FillTableTree()
        tableCheckCount = 0
        TvDatatables.ExpandAll()
    End Sub
    Private Sub LoadImages()
        AddProgress("Filling Image Tree", 2)
        FillImageTree()
        imageCheckCount = 0
        TvImages.ExpandAll()
    End Sub
    Private Sub LoadDesigns()
        AddProgress("Filling Design Tree", 2)
        FillDesignTree()
        docCheckCount = 0
        TvDesigns.ExpandAll()
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
    Public Sub FillTableTree()
        LogUtil.LogInfo("Filling table tree", MethodBase.GetCurrentMethod.Name)
        TvDatatables.Nodes.Clear()
        Dim _dataNode As TreeNode = TvDatatables.Nodes.Add("Tables")
        Dim _filepath As String = My.Settings.DataFilePath
        Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(_filepath)
        For Each _filename As String In fileList
            Dim _fname As String = Path.GetFileName(_filename)
            Dim _fileNode As TreeNode = _dataNode.Nodes.Add(TABLE_TAG & _filename, _fname)
        Next
        If ChkArchive.Checked Then
            Dim _archiveNode As TreeNode = _dataNode.Nodes.Add(ARC_TAG & "Archive", "Archive files")
            fileList = My.Computer.FileSystem.GetFiles(oDataArchiveFolderName)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                Dim _fileNode As TreeNode = _archiveNode.Nodes.Add(TABLE_TAG & _filename, _fname)
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
                    dataPath = Path.Combine(backupPath, "data")
                    dataArchivePath = Path.Combine(dataPath, "archive")
                    If Not CheckPathExists(backupPath) Then isOKToBackup = False
                    If Not CheckPathExists(dataPath) Then isOKToBackup = False
                    If Not CheckPathExists(imagePath) Then isOKToBackup = False
                    If Not CheckPathExists(designPath) Then isOKToBackup = False
                    If ChkArchive.Checked Then
                        If Not CheckPathExists(designArchivePath) Then isOKToBackup = False
                        If Not CheckPathExists(dataArchivePath) Then isOKToBackup = False
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
    Private Sub ImagesBackup()
        AddProgress("Images backup", 2, 2)
        ImageBackup()

    End Sub
    Private Sub DesignsBackup()
        AddProgress("Designs backup", 2, 2)
        DesignBackup()
    End Sub
    Private Sub DataTablesBackup()
        AddProgress("Data backup", 2, 2)
        DataBackup()
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
    Private Sub DataBackup()
        For Each oDataNode As TreeNode In TvDatatables.Nodes
            DisplayProgressBar(oDataNode)
            AddProgress(oDataNode.Text, 3, 2)
            For Each oNode As TreeNode In oDataNode.Nodes
                If oNode.Checked Then
                    If oNode.Name.StartsWith(TABLE_TAG) Then
                        oNode = BackupDataFile(oNode, False)
                    ElseIf oNode.Name.StartsWith(ARC_TAG) Then
                        AddProgress(oNode.Text, 3, 2)
                        For Each aNode As TreeNode In oNode.Nodes
                            If aNode.Checked Then
                                If aNode.Name.StartsWith(TABLE_TAG) Then
                                    aNode = BackupDataFile(aNode, True)
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            oDataNode.Checked = False
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
    Private Function BackupDataFile(oNode As TreeNode, pIsArchive As Boolean) As TreeNode
        Dim _filename As String = oNode.Text
        Dim _fullname As String = oNode.Name.Replace(TABLE_TAG, "")
        Dim _destFilename As String = Path.GetFileNameWithoutExtension(_filename)
        Dim _destExtention As String = Path.GetExtension(_filename)
        Dim _destVersion As String = String.Empty
        If My.Computer.FileSystem.FileExists(_fullname) Then
            Dim filenameWithVersion As String = _destFilename & _destVersion & _destExtention
            Dim destination As String = Path.Combine(If(pIsArchive, dataArchivePath, dataPath), filenameWithVersion)
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

#End Region
End Class