' Hindleware
' Copyright (c) 2023-24 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text
Imports HindlewareLib.Logging

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
    Private docPath As String
    Private imagePath As String
    Private oBooklist As List(Of Book)
    Private isFormInitialised As Boolean
    Private tableCheckCount As Integer
    Private docCheckCount As Integer
    Private imageCheckCount As Integer
#End Region
#Region "form control handlers"
    Private Sub FrmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddProgress("Backup")
        isFormInitialised = True
        GetFormPos(Me, My.Settings.BackupFormPos)
        PbCopyProgress.Visible = False
        ApplySettings()
        AddProgress("Selecting Data", 1, 1)
        AddProgress("Filling dB Table Tree", 2)
        FillTableTree(TvDatatables)
        tableCheckCount = 0
        TvDatatables.ExpandAll()
        LoadBooks()
        KeyPreview = True
    End Sub

    Friend Sub ApplySettings()
        RbCurrentBook.Checked = My.Settings.BackupCurrentBookOnly
        TxtBackupPath.Text = My.Settings.BackupPath
        chkAddDate.Checked = My.Settings.BackupAddDate
        ChkArchive.Checked = My.Settings.BackupArchive
        ChkIncludeDb.Checked = My.Settings.BackUpDb
        ChkRevision.Checked = My.Settings.BackUpRevision
    End Sub

    Private Sub MyBase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        KeyHandler(Me, FormType.Backup, e)
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub TreeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvDatatables.AfterCheck, TvDocuments.AfterCheck, TvImages.AfterCheck
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
        Dim ischecked As Boolean = node.Checked
        For Each subNode As TreeNode In node.Nodes
            If Not subNode.Checked = ischecked Then
                subNode.Checked = ischecked
            End If
        Next
        LblCounts.Text = String.Format("T:{0} D:{1} I:{2}", CStr(tableCheckCount), CStr(docCheckCount), CStr(imageCheckCount))
        StatusStrip1.Refresh()
    End Sub
    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        If tableCheckCount + docCheckCount + imageCheckCount > 0 Or ChkIncludeDb.Checked Then
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
                If docCheckCount + imageCheckCount > 0 Then
                    BooksBackup()
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
        My.Settings.BackupFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectAll_Click(sender As Object, e As EventArgs) Handles BtnSelectAll.Click
        SelectAll()
    End Sub
    Private Sub RbAllBooks_CheckedChanged(sender As Object, e As EventArgs) Handles RbAllBooks.CheckedChanged
        If isFormInitialised Then
            LoadBooks()
        End If
    End Sub
    Private Sub MnuClear_Click(sender As Object, e As EventArgs) Handles MnuClear.Click
        rtbProgress.Text = ""
    End Sub
    Private Sub ChkArchive_CheckedChanged(sender As Object, e As EventArgs) Handles ChkArchive.CheckedChanged
        If isFormInitialised Then
            LoadBooks()
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Function CountCheckedTableNodes() As Integer
        Dim _tablesnode As TreeNode = TvDatatables.Nodes(0)
        Return CountCheckedNodes(_tablesnode)
    End Function
    Private Function CountCheckedDocumentNodesForBook(pBook As Book) As Integer
        Dim bookCheckedNodesCount As Integer = 0
        Dim _booknode As TreeNode = TvDocuments.Nodes(0).Nodes.Find(BOOK_TAG & pBook.Id, False)(0)
        For Each _node As TreeNode In _booknode.Nodes
            bookCheckedNodesCount += CountCheckedNodes(_node)
        Next
        Return bookCheckedNodesCount
    End Function
    Private Function CountCheckedImageNodesForBook(pBook As Book) As Integer
        Dim _booknode As TreeNode = TvImages.Nodes(0).Nodes.Find(BOOK_TAG & pBook.Id, False)(0)
        Return CountCheckedNodes(_booknode)
    End Function
    Private Function CountCheckedNodes(pNode As TreeNode) As Integer
        Dim checkedNodeCount As Integer = 0
        For Each _subnode As TreeNode In pNode.Nodes
            If _subnode.Checked Then
                checkedNodeCount += 1
            End If
        Next
        Return checkedNodeCount
    End Function
    Private Sub LoadBooks()
        AddProgress("Selecting Files", 1, 1)
        oBooklist = New List(Of Book)
        If RbCurrentBook.Checked Then
            oBooklist.Add(myCurrentBook)
        Else
            oBooklist = GetBooks()
        End If
        AddProgress("Filling Document Tree", 2)
        FillDocumentTree()
        ExpandDocumentTree()
        AddProgress("Filling Image Tree", 2)
        FillImageTree()
        TvImages.ExpandAll()
    End Sub

    Private Sub ExpandDocumentTree()
        For Each _booknode As TreeNode In TvDocuments.Nodes
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
        TvDocuments.Nodes(0).Checked = True
        TvImages.Nodes(0).Checked = True
    End Sub
    Friend Sub ClearAll()
        TvDatatables.Nodes(0).Checked = False
        TvDocuments.Nodes(0).Checked = False
        TvImages.Nodes(0).Checked = False
    End Sub
    Private Sub AddBackupDiaryEntry(pType As String)
        AddBackupDiaryEntry(pType, New List(Of String))
    End Sub
    Private Sub AddBackupDiaryEntry(pType As String, pItemList As List(Of String))
        Dim _body As New StringBuilder("Backup folder :")
        _body.Append(backupPath)
        If pItemList.Count > 0 Then
            _body.Append(vbCrLf).Append("Items backed up:")
            For Each _item In pItemList
                _body.Append(vbCrLf).Append(_item)
            Next
        End If
        Dim _date As DateTime = Now
        Dim _diaryEntry As DiaryEntry = DiaryEntryBuilder.ADiaryEntry.StartingWithNothing _
                                                .WithIsAuditEntry(False) _
                                                .WithReminderDate(_date) _
                                                .WithSubject(pType & " BACKUP") _
                                                .WithEndDate(_date) _
                                                .WithBody(_body.ToString) _
                                                .WithBook(myCurrentBook.Id) _
                                                .WithBrush(New SolidBrush(Color.Plum)) _
                                                .Build
        InsertDiaryEntry(_diaryEntry)
    End Sub
    Private Sub FillImageTree()
        TvImages.Nodes.Clear()
        imageCheckCount = 0
        TvImages.Nodes.Add("Images")
        For Each _book In oBooklist
            Dim _SourceImagePath As String = GetGlobalSetting("ImageFilePath").Replace("%bookname%", _book.Name)
            Dim _booknode As TreeNode = TvImages.Nodes(0).Nodes.Add(BOOK_TAG & _book.Id, _book.Name)
            Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(_SourceImagePath)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                _booknode.Nodes.Add(IMAGE_TAG & _filename, _fname)
            Next
        Next
    End Sub
    Private Sub FillDocumentTree()
        TvDocuments.Nodes.Clear()
        docCheckCount = 0
        TvDocuments.Nodes.Add("Document files")
        For Each _book In oBooklist
            Dim _booknode As TreeNode = TvDocuments.Nodes(0).Nodes.Add(BOOK_TAG & _book.Id, _book.Name)
            Dim _chapterNode As TreeNode = _booknode.Nodes.Add("Chapter files")
            Dim _filepath As String = GetGlobalSetting("ChapterFilePath").Replace("%bookname%", _book.Name)
            Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(_filepath)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                Dim _fileNode As TreeNode = _chapterNode.Nodes.Add(DOC_TAG & _filename, _fname)
                Dim oChapters As List(Of Chapter) = GetChaptersByChapterFilename(_fname)
                If ChkRevision.Checked Then
                    Dim _draft As String = String.Empty
                    For Each _chapter As Chapter In oChapters
                        If Not _chapter.IsDeleted AndAlso _chapter.IsStarted Then
                            _draft = _chapter.Draft & "." & _chapter.Revision
                            _fileNode.Nodes.Add(REV_TAG & _draft, _draft)
                        End If
                    Next
                End If
            Next
            _filepath = GetGlobalSetting("SoundFilePath").Replace("%bookname%", _book.Name)
            Dim _soundNode As TreeNode = _booknode.Nodes.Add("Sound files")
            fileList = My.Computer.FileSystem.GetFiles(_filepath)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                _soundNode.Nodes.Add(DOC_TAG & _filename, _fname)
            Next
            _filepath = GetGlobalSetting("TextFilePath").Replace("%bookname%", _book.Name)
            Dim _textNode As TreeNode = _booknode.Nodes.Add("Text files")
            fileList = My.Computer.FileSystem.GetFiles(_filepath)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                _textNode.Nodes.Add(DOC_TAG & _filename, _fname)
            Next
            If ChkArchive.Checked Then
                _filepath = GetGlobalSetting("ArchiveFilePath").Replace("%bookname%", _book.Name)
                Dim _archiveNode As TreeNode = _booknode.Nodes.Add("Archived files")
                fileList = My.Computer.FileSystem.GetFiles(_filepath)
                For Each _filename As String In fileList
                    Dim _fname As String = Path.GetFileName(_filename)
                    _archiveNode.Nodes.Add(DOC_TAG & _filename, _fname)
                Next
            End If
        Next
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
                    If Not CheckPathExists(backupPath) Then isOKToBackup = False
                    If ChkIncludeDb.Checked Then
                        dbBackupPath = Path.Combine(backupPath, "MSSQL")
                        If Not CheckPathExists(dbBackupPath) Then isOKToBackup = False
                    End If
                    If CountCheckedTableNodes() > 0 Then
                        dataPath = Path.Combine(backupPath, "data")
                        If Not CheckPathExists(dataPath) Then isOKToBackup = False
                    End If
                    '    optionsPath = Path.Combine(backupPath, "options")
                    '    If Not CheckPathExists(optionsPath) Then isOKToBackup = False
                    For Each _book As Book In oBooklist
                        Dim _bookBackupPath As String = Path.Combine(backupPath, _book.Name)
                        docPath = Path.Combine(_bookBackupPath, "documents")
                        imagePath = Path.Combine(_bookBackupPath, "images")
                        If CountCheckedDocumentNodesForBook(_book) Then
                            If Not CheckPathExists(docPath) Then isOKToBackup = False
                        End If
                        If CountCheckedImageNodesForBook(_book) Then
                            If Not CheckPathExists(imagePath) Then isOKToBackup = False
                        End If
                    Next
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
        Catch ex As ArgumentException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As PathTooLongException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As NotSupportedException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As IOException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As UnauthorizedAccessException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        End Try
        Return isOK
    End Function
    Private Sub ImageBackup(_book As Book, ByRef _itemList As List(Of String))
        AddProgress("Image backup", 4, 2)
        Dim _booknode As TreeNode = TvImages.Nodes(0).Nodes.Find(BOOK_TAG & _book.Id, False)(0)
        DisplayProgressBar(_booknode)
        For Each oNode As TreeNode In _booknode.Nodes
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
                _itemList.Add("  " & _filename)
                PbCopyProgress.PerformStep()
                StatusStrip1.Refresh()
                oNode.Checked = False
            End If
        Next
        PbCopyProgress.Visible = False
        _booknode.Checked = False
        TvImages.Nodes(0).Checked = False
    End Sub
    Private Sub DbBackup()
        AddProgress("dB backup", 2, 2)
        Dim _initBackup As String = If(My.Settings.AppendDbBackup, "NOINIT", "INIT")
        Dim _dbName As String = GetGlobalSetting("DbName", "MyNovel", "string")
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
            .ConnectionString = Global.MyNovel.My.MySettings.Default.MyNovelConnectionString1
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
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As SqlClient.SqlException
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As IOException
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As InvalidOperationException
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Finally
            If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                AddProgress("Closing dB connection", 4)
                _command.Connection.Close()
                AddBackupDiaryEntry("DB")
            End If
        End Try
    End Sub
    Private Sub BooksBackup()
        AddProgress("Book backup", 2, 2)
        Dim _itemList As New List(Of String)
        For Each _book As Book In oBooklist
            AddProgress("Book: " & _book.Name, 3)
            Dim _bookBackupPath As String = Path.Combine(backupPath, _book.Name)
            Dim _docCount As Integer = CountCheckedDocumentNodesForBook(_book)
            Dim _imageCount As Integer = CountCheckedImageNodesForBook(_book)
            If _imageCount + _docCount > 0 Then _itemList.Add(_book.Name)
            If _docCount > 0 Then
                _itemList.Add(" Documents:")
                docPath = Path.Combine(_bookBackupPath, "documents")
                DocumentsBackup(_book, _itemList)
            End If
            If _imageCount > 0 Then
                _itemList.Add(" Images:")
                imagePath = Path.Combine(_bookBackupPath, "images")
                ImageBackup(_book, _itemList)
            End If
        Next
        If _itemList.Count > 0 Then
            AddBackupDiaryEntry("BOOK", _itemList)
        End If
    End Sub
    Private Sub DocumentsBackup(_book As Book, ByRef _itemList As List(Of String))
        AddProgress("Document backup", 4, 2)
        Dim _booknode As TreeNode = TvDocuments.Nodes(0).Nodes.Find(BOOK_TAG & _book.Id, False)(0)
        For Each oTypeNode As TreeNode In _booknode.Nodes
            DisplayProgressBar(oTypeNode)
            AddProgress(oTypeNode.Text, 5, 2)
            For Each oNode As TreeNode In oTypeNode.Nodes
                If oNode.Checked Then
                    Dim _filename As String = oNode.Text
                    Dim _fullname As String = oNode.Name.Replace(DOC_TAG, "")
                    Dim _destFilename As String = Path.GetFileNameWithoutExtension(_filename)
                    Dim _destExtention As String = Path.GetExtension(_filename)
                    Dim _destVersion As String = String.Empty
                    If oNode.Nodes.Count > 0 Then
                        _destVersion = "#" & oNode.Nodes(0).Text
                    End If
                    If My.Computer.FileSystem.FileExists(_fullname) Then
                        Dim filenameWithVersion As String = _destFilename & _destVersion & _destExtention
                        Dim destination As String = Path.Combine(docPath, filenameWithVersion)
                        Dim _overwritten As String = ""
                        If My.Computer.FileSystem.FileExists(destination) Then
                            _overwritten = " (*)"
                        End If
                        My.Computer.FileSystem.CopyFile(_fullname, destination, True)
                        AddProgress(_filename & " copied" & _overwritten, 6)
                        _itemList.Add("  " & _filename)
                        PbCopyProgress.PerformStep()
                        StatusStrip1.Refresh()
                        oNode.Checked = False
                    Else
                        AddProgress("!!!! Error :" & oNode.Text & " does not exist !!!!")
                    End If
                End If
            Next
            oTypeNode.Checked = False
        Next
        PbCopyProgress.Visible = False
        _booknode.Checked = False
    End Sub
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
                    Case "People"
                        _itemList.Add(BackupTable(GetPeopleTable))
                        _isTableSaved = True
                    Case "Events"
                        _itemList.Add(BackupTable(GetEventTable))
                        _isTableSaved = True
                    Case "Places"
                        _itemList.Add(BackupTable(GetPlaceTable))
                        _isTableSaved = True
                    Case "Books"
                        _itemList.Add(BackupTable(GetBookTable))
                        _isTableSaved = True
                    Case "BookPeople"
                        _itemList.Add(BackupTable(GetBookPeopleTable))
                        _isTableSaved = True
                    Case "BookEvents"
                        _itemList.Add(BackupTable(GetBookEventsTable))
                        _isTableSaved = True
                    Case "BookPlaces"
                        _itemList.Add(BackupTable(GetBookPlaceTable))
                        _isTableSaved = True
                    Case "BeatSheetIndex"
                        _itemList.Add(BackupTable(GetBeatSheetIndexTable))
                        _isTableSaved = True
                    Case "BeatSheet"
                        _itemList.Add(BackupTable(GetBeatSheetTable))
                        _isTableSaved = True
                    Case "BeatActs"
                        _itemList.Add(BackupTable(GetBeatActsTable))
                        _isTableSaved = True
                    Case "BookBeat"
                        _itemList.Add(BackupTable(GetBookBeatTable))
                        _isTableSaved = True
                    Case "Authors"
                        _itemList.Add(BackupTable(GetAuthorsTable))
                        _isTableSaved = True
                    Case "StoryArc"
                        _itemList.Add(BackupTable(GetStoryArcTable))
                        _isTableSaved = True
                    Case "Sources"
                        _itemList.Add(BackupTable(GetSourcesTable))
                        _isTableSaved = True
                    Case "Settings"
                        _itemList.Add(BackupTable(GetSettingsTable))
                        _isTableSaved = True
                    Case "Users"
                        _itemList.Add(BackupTable(GetUsersTable))
                        _isTableSaved = True
                    Case "Family"
                        _itemList.Add(BackupTable(GetFamilyTable))
                        _isTableSaved = True
                    Case "FamilyMember"
                        _itemList.Add(BackupTable(GetFamilyMemberTable))
                        _isTableSaved = True
                    Case "CharacterDevelopment"
                        _itemList.Add(BackupTable(GetCharacterDevelopmentTable))
                        _isTableSaved = True
                    Case "StickyNotes"
                        _itemList.Add(BackupTable(GetStickyNotesTable))
                        _isTableSaved = True
                    Case "HotKey"
                        _itemList.Add(BackupTable(GetHotKeyTable))
                        _isTableSaved = True
                    Case "Diary"
                        _itemList.Add(BackupTable(GetDiaryTable))
                        _isTableSaved = True
                    Case "Audit"
                        _itemList.Add(BackupTable(GetAuditTable))
                        _isTableSaved = True
                    Case "Parts"
                        _itemList.Add(BackupTable(GetPartsTable))
                        _isTableSaved = True
                    Case "Chapters"
                        _itemList.Add(BackupTable(GetChaptersTable))
                        _isTableSaved = True
                    Case "ChapterHistory"
                        _itemList.Add(BackupTable(GetChapterHistoryTable))
                        _isTableSaved = True
                    Case "BookHistory"
                        _itemList.Add(BackupTable(GetBookHistoryTable))
                        _isTableSaved = True
                    Case "Relationships"
                        _itemList.Add(BackupTable(GetRelationshipsTable))
                        _isTableSaved = True
                    Case "RelationshipTypes"
                        _itemList.Add(BackupTable(GetRelationshipTypesTable))
                        _isTableSaved = True
                    Case "PlannerTasks"
                        _itemList.Add(BackupTable(GetPlannerTasksTable))
                        _isTableSaved = True
                    Case "Threads"
                        _itemList.Add(BackupTable(GetThreadsTable))
                        _isTableSaved = True
                    Case "ColorPairs"
                        _itemList.Add(BackupTable(GetColorPairsTable))
                        _isTableSaved = True
                End Select
                If _isTableSaved Then
                    oNode.Checked = False
                Else
                    AddProgress(_table & " unrecognised. Not backed up.", 12, 4)
                End If
            End If
        Next
        If _itemList.Count > 0 Then
            AddBackupDiaryEntry("DATA", _itemList)
        End If
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

    Private Sub ChkRevision_CheckedChanged(sender As Object, e As EventArgs) Handles ChkRevision.CheckedChanged
        FillDocumentTree()
        ExpandDocumentTree()
    End Sub

#End Region
End Class