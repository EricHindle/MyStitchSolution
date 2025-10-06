' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports HindlewareLib.Logging
Imports MyStitch.Domain
Public Class FrmRestore
#Region "properties"
    Private _isRestartRequired As Boolean
    Private _isReloadDataRequired As Boolean
    Public Property IsReloadDataRequired() As Boolean
        Get
            Return _isReloadDataRequired
        End Get
        Set(ByVal value As Boolean)
            _isReloadDataRequired = value
        End Set
    End Property
    Public Property IsRestartRequired() As Boolean
        Get
            Return _isRestartRequired
        End Get
        Set(ByVal value As Boolean)
            _isRestartRequired = value
        End Set
    End Property
#End Region
#Region "variables"
    Private backupPath As String
    Private dataPath As String
    Private isParentCheck As Boolean
    Private isCheckInProgress As Boolean = False
    Private oSourceDataPath As String
    Private oSourceImagePath As String
    Private oSourceDesignPath As String
    Private isInitialiseComplete As Boolean
    Private isLoading As Boolean

#End Region
#Region "form control handlers"
    Private Sub FrmRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Restore", MyBase.Name)
        GetFormPos(Me, My.Settings.RestoreFormPos)
        TxtBackupPath.Text = My.Settings.BackupPath
        _isRestartRequired = False
        _isReloadDataRequired = False
        isCheckInProgress = False
        isInitialiseComplete = True
        isLoading = True
        SetSourcePaths()
        FillAllTrees()
        isLoading = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Try
            SetTargetPaths()
            AddProgress("Restore started -------------------------")
            Dim result As MsgBoxResult = MsgBox("Restored files will overwrite files with the same name." & vbCrLf &
                                                "This could result in the loss of newer data." & vbCrLf &
                                                "You should run a backup before restoring old files." & vbCrLf & vbCrLf &
                                                "Do you want to continue?",
                                                MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo,
                                                "Warning")
            If result = MsgBoxResult.Yes Then
                ImageRestore()
                DesignRestore
                If DataTableRestore > 0 Then
                    IsRestartRequired = True
                    Close()
                End If
                AddProgress("Restore complete -------------------------")
            Else
                AddProgress("Restore abandoned ------------------------")
            End If
        Catch ex As ApplicationException
            ShowRestoreFailed(ex)
        End Try
    End Sub

    Private Sub ShowRestoreFailed(ex As ApplicationException)
        AddProgress("A problem has occurred during the restore.")
        AddProgress(ex.Message)
        AddProgress(ex.InnerException.Message)
        AddProgress("Restore failed ---------------------------")
    End Sub

    Private Sub BtnSelectPath_Click(sender As Object, e As EventArgs) Handles BtnSelectPath.Click
        Using fbd As New FolderBrowserDialog
            If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                fbd.SelectedPath = TxtBackupPath.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtBackupPath.Text = fbd.SelectedPath
            End If
        End Using
    End Sub
    Private Sub FrmRestore_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.RestoreFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub TxtBackupPath_TextChanged(sender As Object, e As EventArgs) Handles TxtBackupPath.TextChanged
        If isInitialiseComplete AndAlso Not isLoading Then
            If My.Computer.FileSystem.DirectoryExists(TxtBackupPath.Text) Then
                SetSourcePaths()
                FillAllTrees()
            End If
        End If
    End Sub
    Private Sub TreeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvImages.AfterCheck,
                                                                                    TvDataSets.AfterCheck,
                                                                                    TvDesigns.AfterCheck
        Dim node As TreeNode = e.Node
        If Not isCheckInProgress Then
            isCheckInProgress = True
            CheckSubNodes(node)
            CheckParentNode(node)
            isCheckInProgress = False
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub SetSourcePaths()
        oSourceImagePath = Path.Combine(TxtBackupPath.Text.Trim, "images")
        oSourceDataPath = Path.Combine(TxtBackupPath.Text.Trim, "data")
        oSourceDesignPath = Path.Combine(TxtBackupPath.Text.Trim, "designs")
    End Sub
    Private Sub SetTargetPaths()
        oDataFolderName = My.Settings.DataFilePath
        oDesignFolderName = My.Settings.DesignFilePath
        oImageFolderName = My.Settings.ImagePath
        AddProgress("Checking folders")
        Try
            CreateFolder(oDataFolderName, True)
            CreateFolder(oDesignFolderName, True)
            CreateFolder(oImageFolderName, True)
        Catch ex As ApplicationException
            Throw ex
        End Try
    End Sub
    Private Sub FillAllTrees()
        FillDataTree()
        FillDesignTree()
        FillImageTree()
    End Sub
    Private Sub FillDataTree()
        Dim _topNode As TreeNode = Nothing
        If My.Computer.FileSystem.DirectoryExists(oSourceDataPath) Then
            TvDataSets.Nodes.Clear()
            _topNode = TvDataSets.Nodes.Add("Data")
            LoadTree(TvDataSets, TABLE_TAG, oSourceDataPath, DATA_EXT)
            _topNode.Expand()
        End If
    End Sub
    Private Sub LoadTree(pTree As TreeView, pTag As String, pBackupSource As String, pExt As String)
        Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(pBackupSource)
        Dim oFolderList As List(Of DirectoryInfo) = oDirInfo.GetDirectories("*", SearchOption.AllDirectories).ToList
        oFolderList.Sort(Function(x As DirectoryInfo, y As DirectoryInfo) x.Name.CompareTo(y.Name))
        For Each _folderinfo As DirectoryInfo In oFolderList
            Try
                Dim _dirDate As Date = Date.ParseExact(_folderinfo.Name, "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Dim _dirDateString As String = Format(_dirDate, "dd MMM yyyy")
                Dim _foldername As String = _folderinfo.Name
                Dim _dateNode As TreeNode = pTree.Nodes(0).Nodes.Add(pTag & _foldername, _dirDateString)
                Dim _dirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(_folderinfo.FullName)
                Dim oFileList As List(Of FileInfo) = _dirInfo.GetFiles("*" & pExt, SearchOption.TopDirectoryOnly).ToList
                oFileList.Sort(Function(x As FileInfo, y As FileInfo) x.Name.CompareTo(y.Name))
                For Each _fileinfo As FileInfo In oFileList
                    Dim _fname As String = Path.GetFileNameWithoutExtension(_fileinfo.Name)
                    If pExt = DESIGN_ZIP_EXT Then
                        Dim f As String() = Split(_fname, "_", 2)
                        _fname = f.First & " : " & f.Last.Replace("_", " ")
                    End If
                    _dateNode.Nodes.Add(pTag & _fileinfo.FullName, _fname)
                Next
            Catch ex As FormatException
            End Try
        Next
    End Sub
    Private Sub FillImageTree()
        Dim _topNode As TreeNode = Nothing
        If My.Computer.FileSystem.DirectoryExists(oSourceImagePath) Then
            TvImages.Nodes.Clear()
            _topNode = TvImages.Nodes.Add("Images")
            Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(oSourceImagePath)
            Dim oFileList As List(Of FileInfo) = oDirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).ToList
            oFileList.Sort(Function(x As FileInfo, y As FileInfo) x.Name.CompareTo(y.Name))
            For Each _fileinfo As FileInfo In oFileList
                Dim _fname As String = Path.GetFileName(_fileinfo.Name)
                TvImages.Nodes(0).Nodes.Add(IMAGE_TAG & _fileinfo.FullName, _fname)
            Next
            _topNode.Expand()
        End If
    End Sub
    Private Sub FillDesignTree()
        Dim _topNode As TreeNode = Nothing
        If My.Computer.FileSystem.DirectoryExists(oSourceDesignPath) Then
            TvDesigns.Nodes.Clear()
            _topNode = TvDesigns.Nodes.Add("Designs")
            LoadTree(TvDesigns, DESIGN_TAG, oSourceDesignPath, DESIGN_ZIP_EXT)
            _topNode.Expand()
        End If
    End Sub
    Private Sub AddProgress(pText As String)
        LogUtil.Info(pText, MyBase.Name)
        rtbProgress.Text &= vbCrLf & pText
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        rtbProgress.ScrollToCaret()
        rtbProgress.Refresh()
    End Sub
    Private Sub ImageRestore()
        Dim _imgCt As Integer = 0
        For Each oNode As TreeNode In TvImages.Nodes(0).Nodes
            If oNode.Checked Then
                _imgCt += 1
            End If
        Next
        If _imgCt > 0 Then
            AddProgress("Image restore (" & CStr(_imgCt) & " images)")
            For Each oNode As TreeNode In TvImages.Nodes(0).Nodes
                RestoreFile(oNode, IMAGE_TAG, oImageFolderName)
            Next
            AddProgress("Image restore complete")
        End If
    End Sub
    Private Function DataTableRestore() As Integer
        Dim _tableCt As Integer = 0
        For Each oDateNode As TreeNode In TvDataSets.Nodes(0).Nodes
            For Each oNode As TreeNode In oDateNode.Nodes
                If oNode.Checked Then
                    _tableCt += 1
                End If
            Next
        Next
        If _tableCt > 0 Then
            AddProgress("Table restore (" & CStr(_tableCt) & " tables)")
            For Each oDateNode As TreeNode In TvDataSets.Nodes(0).Nodes
                For Each oNode As TreeNode In oDateNode.Nodes
                    RestoreFile(oNode, TABLE_TAG, oDataFolderName)
                Next
            Next
            AddProgress("Table restore complete")
        End If
        Return _tableCt
    End Function
    Private Function DesignRestore() As Integer
        Dim _designCt As Integer = 0
        For Each oDateNode As TreeNode In TvDesigns.Nodes(0).Nodes
            For Each oNode As TreeNode In oDateNode.Nodes
                If oNode.Checked Then
                    _designCt += 1
                End If
            Next
        Next
        If _designCt > 0 Then
            AddProgress("Design restore (" & CStr(_designCt) & " designs)")
            For Each oDateNode As TreeNode In TvDesigns.Nodes(0).Nodes
                For Each oNode As TreeNode In oDateNode.Nodes
                    RestoreFile(oNode, DESIGN_TAG, oDesignFolderName)
                Next
            Next
            AddProgress("Design restore complete")
        End If
        Return _designCt
    End Function
    Private Sub RestoreFile(pNode As TreeNode, pTag As String, pDestination As String)
        If pNode.Checked Then
            Try
                Dim _sourceFile As String = pNode.Name.Replace(pTag, "")
                TryCopyFile(_sourceFile, Path.Combine(pDestination, Path.GetFileName(_sourceFile)), True)
                AddProgress("File restored : " & pNode.Text)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                 OrElse TypeOf ex Is ApplicationException)
                AddProgress("File NOT restored : " & pNode.Text)
            End Try
            pNode.Checked = False
        End If
    End Sub
    Private Sub CheckSubNodes(pNode As TreeNode)
        Dim ischecked As Boolean = pNode.Checked
        For Each subNode As TreeNode In pNode.Nodes
            If Not subNode.Checked = ischecked Then
                subNode.Checked = ischecked
                CheckSubNodes(subNode)
            End If
        Next
    End Sub
    Private Sub CheckParentNode(pNode As TreeNode)
        Dim ischecked As Boolean = pNode.Checked
        If pNode.Checked AndAlso pNode.Parent IsNot Nothing AndAlso Not pNode.Parent.Checked Then
            pNode.Parent.Checked = True
            CheckParentNode(pNode.Parent)
        End If
    End Sub

#End Region
End Class