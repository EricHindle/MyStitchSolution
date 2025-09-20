' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports HindlewareLib.Logging
Imports MyStitch.Domain.Builders
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain
    Module ModDataTableAdapter
#Region "tables"
        Private ReadOnly oProjectDataTable As New MyStitchDataSet.ProjectsDataTable
        Private ReadOnly oThreadDataTable As New MyStitchDataSet.ThreadsDataTable
        Private ReadOnly oProjectThreadDataTable As New MyStitchDataSet.ProjectThreadsDataTable
        Private ReadOnly oProjectThreadCardDataTable As New MyStitchDataSet.ProjectThreadCardsDataTable
        Private ReadOnly oProjectCardThreadDataTable As New MyStitchDataSet.ProjectCardThreadDataTable
        Private ReadOnly oSettingsDataTable As New MyStitchDataSet.SettingsDataTable
        Private ReadOnly oSymbolsDataTable As New MyStitchDataSet.SymbolsDataTable
        Private ReadOnly oProjectWorkTimesDataTable As New MyStitchDataSet.ProjectWorkTimesDataTable
        Private ReadOnly oPalettesDataTable As New MyStitchDataSet.PalettesDataTable
        Private ReadOnly oPaletteThreadsDataTable As New MyStitchDataSet.PaletteThreadsDataTable
        Private ReadOnly oPaletteThreadsTable As New MyStitchDataSet.PaletteThreadsDataTable
#End Region
#Region "Data Tables"
#Region "Load"
        Public Sub LoadDataTables(pStatus As ToolStripStatusLabel)
            LogUtil.LogInfo("Loading Data Tables", MethodBase.GetCurrentMethod.Name)
            Try
                UnpackDataFile(pStatus)
                FillTableListFromTableEnum()
                For Each oTable As String In tableList
                    LoadDataTableFromXml(oTable)
                Next
                LogUtil.ShowStatus("Data Loaded OK", pStatus, MethodBase.GetCurrentMethod.Name)
            Catch ex As ApplicationException
                Throw ex
            End Try
        End Sub
        Private Sub UnpackDataFile(pStatus As ToolStripStatusLabel)
            LogUtil.ShowStatus("Unpacking Data File", pStatus, MethodBase.GetCurrentMethod.Name)
            Dim oDataFileName As String = Path.Combine(oDataFolderName, DATA_FILE_NAME & DATA_ZIP_EXT)
            If My.Computer.FileSystem.FileExists(oDataFileName) = True Then
                Try
                    Using _archiveFile As ZipArchive = ZipFile.OpenRead(oDataFileName)
                        For Each _entry As ZipArchiveEntry In _archiveFile.Entries
                            If _entry.Name.EndsWith(DATA_EXT) Then
                                _entry.ExtractToFile(Path.Combine(oDataFolderName, _entry.Name), True)
                            End If
                        Next
                    End Using
                Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is PathTooLongException _
                                OrElse TypeOf ex Is DirectoryNotFoundException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException _
                                OrElse TypeOf ex Is InvalidDataException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is ObjectDisposedException)
                    Throw ex
                End Try
            Else
                Throw New ApplicationException("MyStitch application data file does not exist." & vbCrLf _
                                               & "Check for " & oDataFileName & " and re-install if necessary.")
            End If
        End Sub
        Public Sub LoadDataTableFromXml(otable As String)
            LogUtil.LogInfo("Loading table " & otable, MethodBase.GetCurrentMethod.Name)
            Dim oXmlFileName As String
            Select Case otable
                Case "Projects"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Projects data file missing.")
                    End If
                Case "Threads"
                    oXmlFileName = Path.Combine(oDataFolderName, oThreadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oThreadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Threads data file missing.")
                    End If
                Case "ProjectThreadCards"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectThreadCardDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectThreadCardDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Thread Card data file missing.")
                    End If
                Case "ProjectThreads"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectThreadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectThreadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Thread data file missing.")
                    End If
                Case "ProjectCardThread"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectCardThreadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectCardThreadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Card Thread data file missing.")
                    End If
                Case "Symbols"
                    oXmlFileName = Path.Combine(oDataFolderName, oSymbolsDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then

                        oSymbolsDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Symbols data file missing.")
                    End If
                Case "Settings"
                    oXmlFileName = Path.Combine(oDataFolderName, oSettingsDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oSettingsDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Settings data file missing.")
                    End If
                Case "ProjectWorkTimes"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectWorkTimesDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectWorkTimesDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Work Times data file missing.")
                    End If
                Case "Palettes"
                    oXmlFileName = Path.Combine(oDataFolderName, oPalettesDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oPalettesDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Palettes file missing.")
                    End If
                Case "PaletteThreads"
                    oXmlFileName = Path.Combine(oDataFolderName, oPaletteThreadsTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oPaletteThreadsTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Palette Threads data file missing.")
                    End If
                Case Else
                    LogUtil.LogInfo("Unknown table " & otable & " cannot be loaded", MethodBase.GetCurrentMethod.Name)
            End Select
        End Sub

#End Region
#Region "Save"

        Public Sub SaveDataTables(pStatus As ToolStripStatusLabel)
            LogUtil.ShowStatus("Saving MyStitch data", pStatus, MethodBase.GetCurrentMethod.Name)
            FillTableListFromTableEnum()
            ArchiveExistingFile(DATA_FILE_NAME, oDataFolderName, DATA_ZIP_EXT, oDataArchiveFolderName, DATA_ARC_EXT)
            AddTablesToArchive(oDataFolderName, DATA_FILE_NAME, DATA_ZIP_EXT)
        End Sub

        Private Sub AddTablesToArchive(pPath As String, pZipFileName As String, pExtension As String)
            Dim _zipFile As String = Path.Combine(pPath, pZipFileName & pExtension)
            If Not My.Computer.FileSystem.FileExists(_zipFile) Then
                LogUtil.LogInfo("Creating new zip file " & _zipFile, MethodBase.GetCurrentMethod.Name)
                Using _fs As New FileStream(_zipFile, FileMode.Create)
                End Using
            End If
            LogUtil.LogInfo("Opening data zip file " & _zipFile, MethodBase.GetCurrentMethod.Name)
            Using ZipToOpen As New FileStream(_zipFile, FileMode.Open)
                Using archive As New ZipArchive(ZipToOpen, ZipArchiveMode.Update)
                    For Each oTable As String In tableList
                        Dim oXmlFileName As String
                        Dim oDataTable As DataTable = Nothing
                        Select Case oTable
                            Case "Projects"
                                oDataTable = GetProjectTable()
                             '   oDataTable = oProjectTable
                            Case "Threads"
                                oDataTable = GetThreadTable()
                              '  oDataTable = oThreadTable
                            Case "ProjectThreadCards"
                                oDataTable = GetProjectThreadCardsTable()
                             '   oDataTable = oProjectThreadCardTable
                            Case "ProjectThreads"
                                oDataTable = GetProjectThreadsTable()
                               ' oDataTable = oProjectThreadTable
                            Case "ProjectCardThread"
                                oDataTable = GetProjectCardThreadTable()
                              '  oDataTable = oProjectCardThreadTable
                            Case "Symbols"
                                oDataTable = GetSymbolsTable()
                              '  oDataTable = oSymbolsTable
                            Case "Settings"
                                oDataTable = GetSettingsTable()
                              '  oDataTable = oSettingsTable
                            Case "ProjectWorkTimes"
                                oDataTable = GetProjectWorkTimesTable()
                             '   oDataTable = oProjectWorkTimesTable
                            Case "Palettes"
                                oDataTable = GetPalettesTable()
                             '   oDataTable = oPalettesTable
                            Case "PaletteThreads"
                                oDataTable = GetPaletteThreadsTable()
                                '    oDataTable = oPaletteThreadsTable
                        End Select
                        If oDataTable IsNot Nothing Then
                            oXmlFileName = WriteXmlFromTable(oDataTable)
                            Dim fileText As String = My.Computer.FileSystem.ReadAllText(oXmlFileName)
                            Dim _projectEntryName As String = Path.GetFileNameWithoutExtension(oXmlFileName) & DATA_EXT
                            Dim projectEntry As ZipArchiveEntry = archive.CreateEntry(_projectEntryName)
                            Using _output As New StreamWriter(projectEntry.Open())
                                _output.WriteLine(fileText)
                                _output.Close()
                            End Using
                            RemoveFile(oXmlFileName)
                        End If
                    Next
                End Using
            End Using
        End Sub
        Private Function WriteXmlFromTable(backupDataTable As DataTable) As String
            Dim sTableName As String = backupDataTable.TableName
            Dim sTableFile As String
            Try
                sTableFile = Path.Combine(oDataFolderName, sTableName & ".xml")
                backupDataTable.WriteXml(sTableFile, XmlWriteMode.WriteSchema)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                 OrElse TypeOf ex Is InvalidOperationException)
                Throw ex
                LogUtil.HandleStatus("Error saving " & sTableName, ex, False, Nothing, Nothing, True, MethodBase.GetCurrentMethod.Name, TraceEventType.Critical, "", 3, False, False, True)
            End Try
            Return sTableFile
        End Function
#End Region

#End Region
#Region "projects"
        Public Function GetProjectList() As List(Of Project)
            Dim oProjectList As New List(Of Project)
            For Each oRow As MyStitchDataSet.ProjectsRow In oProjectDataTable.Rows
                oProjectList.Add(ProjectBuilder.AProject.StartingWith(oRow).Build)
            Next
            Return oProjectList
        End Function
        Public Function FindProjectById(pProjectId As Integer) As Project
            Dim oProject As New Project
            Try
                Dim oProjectRow As MyStitchDataSet.ProjectsRow = GetProjectRow(pProjectId)
                If oProjectRow IsNot Nothing Then
                    oProject = ProjectBuilder.AProject.StartingWith(oProjectRow).Build
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oProject
        End Function
        Public Function GetProjectRow(pProjectId As Integer) As MyStitchDataSet.ProjectsRow
            Dim oProjectRow As MyStitchDataSet.ProjectsRow = Nothing
            Try
                Dim oProjectRows = From project In oProjectDataTable.AsEnumerable()
                                   Select project
                                   Where project.project_id = pProjectId
                If oProjectRows.Count = 1 Then
                    oProjectRow = oProjectRows(0)
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oProjectRow
        End Function
        Public Function AddNewProject(pProject As Project) As Boolean
            Dim oProjectRow As MyStitchDataSet.ProjectsRow = oProjectDataTable.NewRow
            oProjectRow = SetProjectRowValues(pProject, oProjectRow)
            oProjectDataTable.Rows.Add(oProjectRow)
            Return True
        End Function

        Private Function SetProjectRowValues(pProject As Project, pProjectRow As MyStitchDataSet.ProjectsRow) As MyStitchDataSet.ProjectsRow
            With pProject
                If (.ProjectName Is Nothing) Then
                    Throw New Global.System.ArgumentNullException("projectname")
                Else
                    pProjectRow.project_name = CType(.ProjectName, String)
                End If
                pProjectRow.date_started = .DateStarted
                pProjectRow.date_ended = .DateEnded
                pProjectRow.design_width = .DesignWidth
                pProjectRow.design_height = .DesignHeight
                pProjectRow.fabric_width = .FabricWidth
                pProjectRow.fabric_colour = .FabricColour
                If (.DesignFileName Is Nothing) Then
                    Throw New Global.System.ArgumentNullException("designfile")
                Else
                    pProjectRow.design_file = CType(.DesignFileName, String)
                End If
                pProjectRow.origin_x = CType(.OriginX, Integer)
                pProjectRow.origin_y = CType(.OriginY, Integer)
                pProjectRow.total_minutes = CType(.TotalMinutes, Integer)
                pProjectRow.fabric_count = CType(.FabricCount, Integer)
            End With
            Return pProjectRow
        End Function
        Public Function AmendProject(pProject As Project) As Boolean
            Dim isUpdated As Boolean = False
            Dim oProjectRow As MyStitchDataSet.ProjectsRow = GetProjectRow(pProject.ProjectId)
            If oProjectRow IsNot Nothing Then
                SetProjectRowValues(pProject, oProjectRow)
                isUpdated = True
            End If
            Return isUpdated
        End Function
        Public Sub AmendDesignFilename(pProjectId As Integer, pFilename As String)
            Dim oProjectRow As MyStitchDataSet.ProjectsRow = GetProjectRow(pProjectId)
            If oProjectRow IsNot Nothing Then
                If (pFilename Is Nothing) Then
                    Throw New Global.System.ArgumentNullException("designfile")
                Else
                    oProjectRow.design_file = CType(pFilename, String)
                End If
            End If
        End Sub
        Public Sub AmendProjectTotalTime(pProject As Project)
            Dim oProjectRow As MyStitchDataSet.ProjectsRow = GetProjectRow(pProject.ProjectId)
            If oProjectRow IsNot Nothing Then
                With pProject
                    oProjectRow.total_minutes = CType(.TotalMinutes, Integer)
                    oProjectRow.date_started = .DateStarted
                    oProjectRow.date_ended = .DateEnded
                End With
            End If
        End Sub
        Public Sub RemoveProject(pProject As Project)
            Dim oProjectRow As MyStitchDataSet.ProjectsRow = GetProjectRow(pProject.ProjectId)
            oProjectDataTable.Rows.Remove(oProjectRow)
        End Sub
#End Region
#Region "Threads"
        Public Function GetThreadsList() As List(Of Thread)
            Dim oThreadList As New List(Of Thread)
            For Each oRow As MyStitchDataSet.ThreadsRow In oThreadDataTable.Rows
                oThreadList.Add(ThreadBuilder.AThread.StartingWith(oRow).Build)
            Next
            Return oThreadList
        End Function
        Public Function FindThreadById(pProjectId As Integer) As Thread
            Return ThreadBuilder.AThread.StartingWith(GetThreadRow(pProjectId)).Build
        End Function
        Public Function FindThreadByNumber(pThreadNumber As String) As Thread
            Dim oThread As New Thread
            Try
                Dim oThreadRows = From Thread In oThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.thread_no = pThreadNumber
                If oThreadRows.Count > 0 Then
                    oThread = ThreadBuilder.AThread.StartingWith(oThreadRows(0)).Build
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThread
        End Function
        Public Function GetThreadRow(pThreadId As Integer) As MyStitchDataSet.ThreadsRow
            Dim oThreadRow As MyStitchDataSet.ThreadsRow = Nothing
            Try
                Dim oThreadRows = From Thread In oThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.thread_id = pThreadId
                If oThreadRows.Count = 1 Then
                    oThreadRow = oThreadRows(0)
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThreadRow
        End Function
        Public Function AmendThread(pThread As Thread) As Boolean
            Dim isUpdated As Boolean = False
            Dim oThreadRow As MyStitchDataSet.ThreadsRow = GetThreadRow(pThread.ThreadId)
            If oThreadRow IsNot Nothing Then
                SetThreadRowValues(pThread, oThreadRow)
                isUpdated = True
            End If
            Return isUpdated
        End Function
        Private Function SetThreadRowValues(pThread As Thread, pThreadRow As MyStitchDataSet.ThreadsRow) As MyStitchDataSet.ThreadsRow
            With pThread
                If (.ThreadNo Is Nothing) Then
                    Throw New Global.System.ArgumentNullException("Threadno")
                Else
                    pThreadRow.thread_no = CType(.ThreadNo, String)
                End If
                pThreadRow.thread_colour = .Colour.ToArgb
                pThreadRow.thread_colour_name = If(.ColourName, "")
                pThreadRow.stock_level = .StockLevel
            End With
            Return pThreadRow
        End Function
        Public Sub RemoveThread(pThread As Thread)
            Dim oThreadRow As MyStitchDataSet.ThreadsRow = GetThreadRow(pThread.ThreadId)
            oThreadDataTable.Rows.Remove(oThreadRow)
        End Sub
        Public Function AddNewThread(pThread As Thread) As Boolean
            Dim oThreadRow As MyStitchDataSet.ThreadsRow = oThreadDataTable.NewRow
            oThreadRow = SetThreadRowValues(pThread, oThreadRow)
            oThreadDataTable.Rows.Add(oThreadRow)
            Return True
        End Function
#End Region
#Region "Project Threads"
        Public Sub RemoveProjectThread(ByRef pProjectThread As ProjectThread)
            Dim oThreadRow As MyStitchDataSet.ProjectThreadsRow = GetProjectThreadByKey(pProjectThread.ProjectId, pProjectThread.Thread.ThreadId)
            If oThreadRow IsNot Nothing Then
                oProjectThreadDataTable.Rows.Remove(oThreadRow)
            End If
        End Sub

        Private Function GetProjectThreadByKey(pProjectId As Integer, pThreadId As Integer) As ProjectThreadsRow
            Dim oThreadRow As MyStitchDataSet.ProjectThreadsRow = Nothing
            Try
                Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.thread_id = pThreadId And Thread.project_id = pProjectId
                If oThreadRows.Count = 1 Then
                    oThreadRow = oThreadRows(0)
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThreadRow
        End Function
        Public Function AddNewProjectThread(pProjectThread As ProjectThread) As Boolean
            Dim oProjectThreadRow As MyStitchDataSet.ProjectThreadsRow = oProjectThreadDataTable.NewRow
            oProjectThreadRow = SetProjectThreadRowValues(pProjectThread, oProjectThreadRow)
            oProjectThreadDataTable.Rows.Add(oProjectThreadRow)
            Return True
        End Function

        Private Function SetProjectThreadRowValues(pProjectThread As ProjectThread, pProjectThreadRow As ProjectThreadsRow) As ProjectThreadsRow
            With pProjectThread
                pProjectThreadRow.project_id = .ProjectId
                pProjectThreadRow.thread_id = .ThreadId
                pProjectThreadRow.symbol_id = .SymbolId
                pProjectThreadRow.is_used = If(.IsUsed, 1, 0)
            End With
            Return pProjectThreadRow
        End Function
        Public Function FindProjectThreads(pProjectId As Integer) As ProjectThreadCollection
            Dim oProjectThreadCollection As New ProjectThreadCollection
            Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId
            For Each oRow As MyStitchDataSet.ProjectThreadsRow In oThreadRows
                oProjectThreadCollection.Add(ProjectThreadBuilder.AProjectThread.StartingWith(oRow).Build)
            Next
            Return oProjectThreadCollection
        End Function
        Public Function FindThreadsForProject(pProjectId As Integer) As List(Of Thread)
            Dim oThreadList As New List(Of Thread)
            Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId
            For Each oRow As MyStitchDataSet.ProjectThreadsRow In oThreadRows
                oThreadList.Add(FindThreadById(pProjectId))
            Next
            Return oThreadList
        End Function
        Public Function FindUsedThreadsForProject(pProjectId As Integer, pIsUsed As Boolean) As List(Of Integer)
            Dim _list As New List(Of Integer)
            Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId And Thread.is_used = If(pIsUsed, 1, 0)
            For Each oRow As MyStitchDataSet.ProjectThreadsRow In oThreadRows
                _list.Add(oRow.thread_id)
            Next
            Return _list
        End Function
        Public Function FindProjectThread(pProjectId As Integer, pThreadId As Integer) As ProjectThread
            Return ProjectThreadBuilder.AProjectThread.StartingWith(GetProjectThreadByKey(pProjectId, pThreadId)).Build
        End Function
        Public Function AmendProjectThreadSymbolId(pProjectId As Integer, pThreadId As Integer, pSymbolId As Integer) As Boolean
            Dim oRow As MyStitchDataSet.ProjectThreadsRow = GetProjectThreadByKey(pProjectId, pThreadId)
            Dim isOk As Boolean = False
            If oRow IsNot Nothing Then
                oRow.symbol_id = pSymbolId
                isOk = True
            End If
            Return isOk
        End Function
        Public Function AmendProjectThreadIsUsedSymbolId(pThread As ProjectThread) As Boolean
            Dim oRow As MyStitchDataSet.ProjectThreadsRow = GetProjectThreadByKey(pThread.ProjectId, pThread.ThreadId)
            Dim isOk As Boolean = False
            If oRow IsNot Nothing Then
                oRow.is_used = If(pThread.IsUsed, 1, 0)
                isOk = True
            End If
            Return isOk
        End Function

        Public Sub RemoveProjectThreadsForProject(pProjectId As Integer)
            LogUtil.LogInfo("Deleting threads for project " & CStr(pProjectId), MethodBase.GetCurrentMethod.Name)
            For Each _projectThread As ProjectThread In FindProjectThreads(pProjectId).Threads
                RemoveProjectThread(_projectThread)
            Next
        End Sub

#End Region
#Region "Project Thread Cards"
        Public Function GetProjectThreadCardsList(pProjectId As Integer) As List(Of ProjectThreadCard)
            Dim oProjectThreadCardList As New List(Of ProjectThreadCard)
            Dim oThreadRows = From Thread In oProjectThreadCardDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId
            For Each oRow As MyStitchDataSet.ProjectThreadCardsRow In oThreadRows
                oProjectThreadCardList.Add(ProjectThreadCardBuilder.AProjectThreadCard.StartingWith(oRow).Build)
            Next
            Return oProjectThreadCardList
        End Function
        Public Function AddNewProjectThreadCard(pProjectThreadCard As ProjectThreadCard) As Boolean
            Dim oProjectThreadCardRow As MyStitchDataSet.ProjectThreadCardsRow = oProjectThreadCardDataTable.NewRow
            oProjectThreadCardRow = SetProjectThreadCardRowValues(pProjectThreadCard, oProjectThreadCardRow)
            oProjectThreadCardDataTable.Rows.Add(oProjectThreadCardRow)
            Return True
        End Function
        Private Function SetProjectThreadCardRowValues(pProjectThreadCard As ProjectThreadCard, pProjectThreadCardRow As MyStitchDataSet.ProjectThreadCardsRow) As MyStitchDataSet.ProjectThreadCardsRow
            With pProjectThreadCard
                pProjectThreadCardRow.thread_card_no = .CardNo
                pProjectThreadCardRow.project_id = .Project.ProjectId
            End With
            Return pProjectThreadCardRow
        End Function

        Public Sub RemoveProjectCards(pProjectId As Integer)
            Try
                RemoveProjectCardThreads(pProjectId)
                RemoveCardsForProject(pProjectId)
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
        End Sub

        Public Sub RemoveCardsForProject(pProjectId As Integer)
            Dim oCardRows = From Card In oProjectThreadCardDataTable.AsEnumerable()
                            Select Card
                            Where Card.project_id = pProjectId
            For Each oRow As MyStitchDataSet.ProjectThreadCardsRow In oCardRows
                oProjectThreadCardDataTable.Rows.Remove(oRow)
            Next
        End Sub
#End Region

#Region "ProjectCardThreads"
        Public Sub RemoveProjectCardThreads(pProjectId As Integer)
            Dim oThreadRows = From Thread In oProjectCardThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId
            For Each oRow As MyStitchDataSet.ProjectCardThreadRow In oThreadRows
                oProjectCardThreadDataTable.Rows.Remove(oRow)
            Next
        End Sub
#End Region
    End Module
End Namespace
