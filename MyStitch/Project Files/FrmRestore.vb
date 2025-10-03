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
#End Region
#Region "variables"
    Private backupPath As String
    Private dataPath As String
    Private isParentCheck As Boolean
    Private isCheckInProgress As Boolean = False
#End Region
#Region "form control handlers"
    Private Sub FrmRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Restore", MyBase.Name)
        GetFormPos(Me, My.Settings.RestoreFormPos)
        TxtBackupPath.Text = My.Settings.BackupPath
        isCheckInProgress = False
        FillAllTrees()

    End Sub

    Private Sub FillAllTrees()
        FillDataTree()
        TvDataSets.ExpandAll()
        FillImageTree()
        TvImages.ExpandAll()
        FillDesignTree()
        '    TvDesigns.ExpandAll()
    End Sub
    Private Sub FillDataTree()
        Dim _SourceImagePath As String = Path.Combine(TxtBackupPath.Text.Trim, "data")
        If My.Computer.FileSystem.DirectoryExists(_SourceImagePath) Then
            TvDataSets.Nodes.Clear()
            TvDataSets.Nodes.Add("Images")
            Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(_SourceImagePath)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                TvImages.Nodes(0).Nodes.Add(IMAGE_TAG & _filename, _fname)
            Next
        End If
    End Sub
    Private Sub FillImageTree()
        Dim _SourceImagePath As String = Path.Combine(TxtBackupPath.Text.Trim, "images")
        If My.Computer.FileSystem.DirectoryExists(_SourceImagePath) Then
            TvImages.Nodes.Clear()
            TvImages.Nodes.Add("Images")
            Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(_SourceImagePath)
            Dim oFileList As List(Of FileInfo) = oDirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).ToList
            oFileList.Sort(Function(x As FileInfo, y As FileInfo) x.Name.CompareTo(y.Name))
            For Each _fileinfo As FileInfo In oFileList
                Dim _fname As String = Path.GetFileName(_fileinfo.Name)
                TvImages.Nodes(0).Nodes.Add(IMAGE_TAG & _fileinfo.FullName, _fname)
            Next
        End If
    End Sub
    Private Sub FillDesignTree()
        TvDesigns.Nodes.Clear()
        Dim _topNode As TreeNode = TvDesigns.Nodes.Add("Designs")
        Dim oFileList As New List(Of FileInfo)
        If My.Computer.FileSystem.DirectoryExists(oDesignArchiveFolderName) Then
            Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(oDesignArchiveFolderName)
            oFileList = oDirInfo.GetFiles("*" & DESIGN_ARC_EXT, SearchOption.TopDirectoryOnly).ToList
            oFileList.Sort(Function(x As FileInfo, y As FileInfo) x.Name.CompareTo(y.Name))
            Dim _archiveNode As TreeNode = _topNode.Nodes.Add(DESIGN_TAG & "Archive", "Archive")
            For Each _fileinfo As FileInfo In oFileList
                Dim _fname As String = _fileinfo.Name
                _archiveNode.Nodes.Add(DESIGN_TAG & _fileinfo.FullName, _fname)
            Next
            _archiveNode.Expand()
        End If
        Dim _backupPath As String = Path.Combine(TxtBackupPath.Text.Trim)
        If My.Computer.FileSystem.DirectoryExists(_backupPath) Then
            Dim _backupNode As TreeNode = _topNode.Nodes.Add(DESIGN_TAG & "Backup", "Backup")
            Dim _dirList As List(Of String) = My.Computer.FileSystem.GetDirectories(_backupPath).ToList
            _dirList.Sort(Function(x As String, y As String) x.CompareTo(y))
            For Each _dir As String In _dirList
                Dim _dirName As String = Path.GetFileName(_dir)
                If IsNumeric(_dirName) Then
                    Dim _dirDate As Date = Date.ParseExact(_dirName, "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim _dirDateString As String = Format(_dirDate, "dd MMM yyyy")
                    Dim _dateNode As TreeNode = _backupNode.Nodes.Add(DESIGN_TAG & CStr(_dirDate), _dirDateString)
                    Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(Path.Combine(_dir, "designs"))
                    If My.Computer.FileSystem.DirectoryExists(oDirInfo.FullName) Then
                        oFileList = oDirInfo.GetFiles("*", SearchOption.TopDirectoryOnly).ToList
                        oFileList.Sort(Function(x As FileInfo, y As FileInfo) x.Name.CompareTo(y.Name))
                        For Each _fileinfo As FileInfo In oFileList
                            Dim _fname As String = _fileinfo.Name
                            _dateNode.Nodes.Add(DESIGN_TAG & _fileinfo.FullName, _fname)
                        Next
                    End If
                End If
            Next
            _backupNode.Expand()
        End If
        _topNode.Expand()
    End Sub
    Private Sub TvDatatables_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvDataSets.AfterCheck
        Dim node As TreeNode = e.Node
        Dim ischecked As Boolean = node.Checked
        For Each subNode As TreeNode In node.Nodes
            subNode.Checked = ischecked
        Next
    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Dim isOKToBackup As Boolean = CheckPaths(True)
        If isOKToBackup Then
            AddProgress("Restore started -------------------------")
            'DataTableRestore()
            AddProgress("Restore complete -------------------------")
        End If
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
    Private Sub BtnSelectAll_Click(sender As Object, e As EventArgs)
        TvDataSets.Nodes(0).Checked = True
    End Sub
#End Region
#Region "subroutines"
    Private Sub AddProgress(pText As String)
        LogUtil.Info(pText, MyBase.Name)
        rtbProgress.Text &= vbCrLf & pText
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        rtbProgress.ScrollToCaret()
        rtbProgress.Refresh()
    End Sub
    'Private Sub DataTableRestore()
    '    AddProgress("Data restore ======")
    '    For Each oNode As TreeNode In TvDatatables.Nodes(0).Nodes
    '        If oNode.Checked Then
    '            AddProgress("Restoring " & oNode.Text)
    '            Dim rowCount As Integer = RestoreDataTable(oNode.Text, dataPath)
    '            If rowCount > 0 Then
    '                AddProgress(oNode.Text & " Restore complete ")
    '                AddProgress(rowCount & " records")
    '            Else
    '                AddProgress("No rows restored")
    '            End If
    '            oNode.Checked = False
    '        End If
    '    Next
    '    TvDatatables.Nodes(0).Checked = False
    'End Sub
    Private Function CheckPaths(isOKToBackup As Boolean) As Boolean
        If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
            backupPath = TxtBackupPath.Text.Trim
            dataPath = Path.Combine(backupPath, "data")
            If Not My.Computer.FileSystem.DirectoryExists(dataPath) Then
                AddProgress("No source folder. No restore.")
                isOKToBackup = False
            End If
        Else
            AddProgress("No source folder. No restore.")
            isOKToBackup = False
        End If
        Return isOKToBackup
    End Function

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()

    End Sub

    Private Sub TxtBackupPath_TextChanged(sender As Object, e As EventArgs) Handles TxtBackupPath.TextChanged
        If My.Computer.FileSystem.DirectoryExists(TxtBackupPath.Text) Then
            FillAllTrees()
        End If
    End Sub

    Private Sub TreeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvImages.AfterCheck, TvDataSets.AfterCheck, TvDesigns.AfterCheck
        Dim node As TreeNode = e.Node
        If Not isCheckInProgress Then
            isCheckInProgress = True
            CheckSubNodes(node)
            CheckParentNode(node)
            isCheckInProgress = False
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