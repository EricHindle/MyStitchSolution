' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
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
#Region "constants"
        Public Const TABLE_TAG As String = "T~"
        Public Const DESIGN_TAG As String = "D~"
        Public Const IMAGE_TAG As String = "I~"
        Public MIN_DATE As New DateTime(2001, 1, 1)
#End Region
#Region "enum"
        Public Enum Tables
            Projects
            Threads
            ProjectThreads
            ProjectThreadCards
            ProjectCardThread
            Settings
            Symbols
            ProjectWorkTimes
            Palettes
            PaletteThreads
            Beads
            ProjectBeads
            Brands
        End Enum
#End Region
#Region "variables"
        ' List of dB tables used in backup and restore
        Public tableList As New List(Of String)
#End Region
#Region "tables"
        Private ReadOnly oProjectDataTable As New ProjectsDataTable
        Private ReadOnly oThreadDataTable As New ThreadsDataTable
        Private ReadOnly oProjectThreadDataTable As New ProjectThreadsDataTable
        Private ReadOnly oProjectThreadCardDataTable As New ProjectThreadCardsDataTable
        Private ReadOnly oProjectCardThreadDataTable As New ProjectCardThreadDataTable
        Private ReadOnly oSettingsDataTable As New SettingsDataTable
        Private ReadOnly oSymbolsDataTable As New SymbolsDataTable
        Private ReadOnly oProjectWorkTimesDataTable As New ProjectWorkTimesDataTable
        Private ReadOnly oPalettesDataTable As New PalettesDataTable
        Private ReadOnly oPaletteThreadsDataTable As New PaletteThreadsDataTable
        Private ReadOnly oBeadDataTable As New BeadsDataTable
        Private ReadOnly oProjectBeadDataTable As New ProjectBeadsDataTable
        Private ReadOnly oBrandDataTable As New BrandsDataTable

#End Region
#Region "Data Tables"
#Region "Load"
        Public Sub InitialiseData()
            LogUtil.LogInfo("Initialising data", MethodBase.GetCurrentMethod.Name)
            FillTableListFromTableEnum()
        End Sub
        Public Sub FillTableListFromTableEnum()
            tableList.Clear()
            Dim _enumArray As Array = [Enum].GetValues(GetType(Tables))
            For Each _enum In _enumArray
                tableList.Add(_enum.ToString)
            Next
        End Sub
        Public Sub LoadDataTables()
            LogUtil.LogInfo("Loading Data Tables", MethodBase.GetCurrentMethod.Name)
            Try
                FillTableListFromTableEnum()
                For Each oTable As String In tableList
                    LoadDataTableFromXml(oTable)
                Next
                LogUtil.LogInfo("Data Loaded OK", MethodBase.GetCurrentMethod.Name)
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
            LogUtil.Debug("Loading table " & otable, MethodBase.GetCurrentMethod.Name)
            Dim oXmlFileName As String
            Select Case otable
                Case "Projects"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectDataTable.Clear()
                        oProjectDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Projects data file missing.")
                    End If
                Case "Threads"
                    oXmlFileName = Path.Combine(oDataFolderName, oThreadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oThreadDataTable.Clear()
                        oThreadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Threads data file missing.")
                    End If
                Case "ProjectThreadCards"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectThreadCardDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectThreadCardDataTable.Clear()
                        oProjectThreadCardDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Bead Card data file missing.")
                    End If
                Case "ProjectThreads"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectThreadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectThreadDataTable.Clear()
                        oProjectThreadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Bead data file missing.")
                    End If
                Case "ProjectCardThread"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectCardThreadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectCardThreadDataTable.Clear()
                        oProjectCardThreadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Card Bead data file missing.")
                    End If
                Case "Symbols"
                    oXmlFileName = Path.Combine(oDataFolderName, oSymbolsDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oSymbolsDataTable.Clear()
                        oSymbolsDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Symbols data file missing.")
                    End If
                Case "Settings"
                    oXmlFileName = Path.Combine(oDataFolderName, oSettingsDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oSettingsDataTable.Clear()
                        oSettingsDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Settings data file missing.")
                    End If
                Case "ProjectWorkTimes"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectWorkTimesDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectWorkTimesDataTable.Clear()
                        oProjectWorkTimesDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Work Times data file missing.")
                    End If
                Case "Palettes"
                    oXmlFileName = Path.Combine(oDataFolderName, oPalettesDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oPalettesDataTable.Clear()
                        oPalettesDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Palettes file missing.")
                    End If
                Case "PaletteThreads"
                    oXmlFileName = Path.Combine(oDataFolderName, oPaletteThreadsDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oPaletteThreadsDataTable.Clear()
                        oPaletteThreadsDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Palette Threads data file missing.")
                    End If
                Case "Beads"
                    oXmlFileName = Path.Combine(oDataFolderName, oBeadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oBeadDataTable.Clear()
                        oBeadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Bead data file missing.")
                    End If
                Case "ProjectBeads"
                    oXmlFileName = Path.Combine(oDataFolderName, oProjectBeadDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oProjectBeadDataTable.Clear()
                        oProjectBeadDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Project Bead data file missing.")
                    End If
                Case "Brands"
                    oXmlFileName = Path.Combine(oDataFolderName, oBrandDataTable.TableName & DATA_EXT)
                    If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                        oBrandDataTable.Clear()
                        oBrandDataTable.ReadXml(oXmlFileName)
                    Else
                        Throw New ApplicationException("Brand data file missing.")
                    End If
                Case Else
                    LogUtil.LogInfo("Unknown table " & otable & " cannot be loaded", MethodBase.GetCurrentMethod.Name)
            End Select
        End Sub
#End Region
#Region "Save"
        Public Sub SaveDataTables()
            FillTableListFromTableEnum()
            Dim _fullZipFileName As String = Path.Combine(oDataFolderName, DATA_FILE_NAME & DATA_ZIP_EXT)
            ' Create new zip file
            Try
                RemoveFile(_fullZipFileName)
                Using _zipfile As New FileStream(_fullZipFileName, FileMode.Create)
                End Using
            Catch ex As Exception When TypeOf ex Is ApplicationException _
                                OrElse TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is Security.SecurityException _
                                OrElse TypeOf ex Is UnauthorizedAccessException
                LogUtil.LogException(ex, "Exception initialising archive file " & _fullZipFileName, MethodBase.GetCurrentMethod.Name)
            End Try
            AddTablesToArchive(_fullZipFileName)
        End Sub
        Private Sub AddTablesToArchive(pFullZipFileName As String)
            LogUtil.Debug("Opening data zip file " & pFullZipFileName, MethodBase.GetCurrentMethod.Name)
            Using oZipFile As New FileStream(pFullZipFileName, FileMode.Open)
                Using oZipArchive As New ZipArchive(oZipFile, ZipArchiveMode.Update)
                    For Each oTable As String In tableList
                        Dim oXmlFileName As String
                        Dim oDataTable As DataTable = Nothing
                        Select Case oTable
                            Case "Projects"
                                oDataTable = oProjectDataTable
                            Case "Threads"
                                oDataTable = oThreadDataTable
                            Case "ProjectThreadCards"
                                oDataTable = oProjectThreadCardDataTable
                            Case "ProjectThreads"
                                oDataTable = oProjectThreadDataTable
                            Case "ProjectCardThread"
                                oDataTable = oProjectCardThreadDataTable
                            Case "Symbols"
                                oDataTable = oSymbolsDataTable
                            Case "Settings"
                                oDataTable = oSettingsDataTable
                            Case "ProjectWorkTimes"
                                oDataTable = oProjectWorkTimesDataTable
                            Case "Palettes"
                                oDataTable = oPalettesDataTable
                            Case "PaletteThreads"
                                oDataTable = oPaletteThreadsDataTable
                            Case "Beads"
                                oDataTable = oBeadDataTable
                            Case "ProjectBeads"
                                oDataTable = oProjectBeadDataTable
                            Case "Brands"
                                oDataTable = oBrandDataTable
                        End Select
                        If oDataTable IsNot Nothing Then
                            Try
                                LogUtil.LogInfo("Saving table " & oDataTable.TableName, MethodBase.GetCurrentMethod.Name)
                                oXmlFileName = WriteXmlFromTable(oDataTable)
                                Dim fileText As String = My.Computer.FileSystem.ReadAllText(oXmlFileName)
                                Dim _projectEntryName As String = Path.GetFileName(oXmlFileName)
                                Dim projectEntry As ZipArchiveEntry = oZipArchive.CreateEntry(_projectEntryName)
                                Using _output As New StreamWriter(projectEntry.Open())
                                    _output.WriteLine(fileText)
                                    _output.Close()
                                End Using
                                LogUtil.Debug("  Table file added to archive", MethodBase.GetCurrentMethod.Name)
                            Catch ex As Exception When TypeOf ex Is ApplicationException _
                                                OrElse TypeOf ex Is NotSupportedException _
                                                OrElse TypeOf ex Is OutOfMemoryException _
                                                OrElse TypeOf ex Is IOException _
                                                OrElse TypeOf ex Is ArgumentException _
                                                OrElse TypeOf ex Is ObjectDisposedException _
                                                OrElse TypeOf ex Is InvalidDataException
                                LogUtil.Problem("Problem saving table " & oDataTable.TableName & " to archive", MethodBase.GetCurrentMethod.Name)
                            End Try
                        Else
                            LogUtil.Problem("Expected table " & oTable.ToString & " not found", MethodBase.GetCurrentMethod.Name)
                        End If
                    Next
                End Using
            End Using
        End Sub
        Private Function WriteXmlFromTable(pDataTable As DataTable) As String
            Dim sTableName As String = pDataTable.TableName
            LogUtil.Debug("Writing XML file", MethodBase.GetCurrentMethod.Name)
            Dim sTableFile As String
            Try
                sTableFile = Path.Combine(oDataFolderName, sTableName & DATA_EXT)
                pDataTable.WriteXml(sTableFile, XmlWriteMode.WriteSchema)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                 OrElse TypeOf ex Is InvalidOperationException)
                LogUtil.HandleStatus("Error saving " & sTableName, ex, False, Nothing, Nothing, True, MethodBase.GetCurrentMethod.Name, TraceEventType.Critical, "", 3, False, False, True)
                Throw New ApplicationException("Problem writing XML file for " & sTableName, ex)
            End Try
            Return sTableFile
        End Function
#End Region
#End Region
#Region "projects"
        Public Function GetProjectList() As List(Of Project)
            Dim oProjectList As New List(Of Project)
            For Each oRow As ProjectsRow In oProjectDataTable.Rows
                oProjectList.Add(ProjectBuilder.AProject.StartingWith(oRow).Build)
            Next
            Return oProjectList
        End Function
        Public Function FindProjectById(pProjectId As Integer) As Project
            Dim oProject As New Project
            Try
                Dim oProjectRow As ProjectsRow = GetProjectRow(pProjectId)
                If oProjectRow IsNot Nothing Then
                    oProject = ProjectBuilder.AProject.StartingWith(oProjectRow).Build
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "Finding project", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oProject
        End Function
        Public Function GetProjectRow(pProjectId As Integer) As ProjectsRow
            Dim oProjectRow As ProjectsRow = Nothing
            Try
                Dim oProjectRows = From _project In oProjectDataTable.AsEnumerable()
                                   Select _project
                                   Where _project.project_id = pProjectId
                If oProjectRows.Count = 1 Then
                    oProjectRow = oProjectRows.First
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return oProjectRow
        End Function
        Public Function AddNewProject(pProject As Project) As Integer
            LogUtil.LogInfo("Adding new project", MethodBase.GetCurrentMethod.Name)
            Dim oProjectRow As ProjectsRow = oProjectDataTable.NewRow
            pProject.ProjectId = oProjectRow.project_id
            If pProject IsNot Nothing Then
                Try
                    oProjectRow = SetProjectRowValues(pProject, oProjectRow)
                    oProjectDataTable.Rows.Add(oProjectRow)
                    WriteXmlFromTable(oProjectDataTable)
                Catch ex As Exception When TypeOf (ex) Is ArgumentException _
                                    OrElse TypeOf (ex) Is ConstraintException _
                                    OrElse TypeOf (ex) Is NoNullAllowedException _
                                    OrElse TypeOf (ex) Is InvalidOperationException
                    LogUtil.DisplayException(ex, "New Project", MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to add null project", MethodBase.GetCurrentMethod.Name)
            End If
            Return oProjectRow.project_id
        End Function
        Private Function SetProjectRowValues(pProject As Project, pProjectRow As ProjectsRow) As ProjectsRow
            With pProject
                If Not String.IsNullOrEmpty(.ProjectName) Then
                    pProjectRow.project_name = CType(.ProjectName, String)
                Else
                    Throw New Global.System.ArgumentNullException("projectname")
                End If
                pProjectRow.date_started = .DateStarted
                pProjectRow.date_ended = .DateEnded
                pProjectRow.design_width = .DesignWidth
                pProjectRow.design_height = .DesignHeight
                pProjectRow.fabric_width = .FabricWidth
                pProjectRow.fabric_height = .FabricHeight
                pProjectRow.fabric_colour = .FabricColour
                If Not String.IsNullOrEmpty(.DesignFileName) Then
                    pProjectRow.design_file = CType(.DesignFileName, String)
                Else
                    pProjectRow.design_file = MakeFilename(pProject)
                End If
                pProjectRow.origin_x = CType(.OriginX, Integer)
                pProjectRow.origin_y = CType(.OriginY, Integer)
                pProjectRow.total_minutes = CType(.TotalMinutes, Integer)
                pProjectRow.fabric_count = CType(.FabricCount, Integer)
            End With
            Return pProjectRow
        End Function
        Public Function AmendProject(pProject As Project) As Boolean
            LogUtil.LogInfo("Amending project", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            Dim oProjectRow As ProjectsRow = GetProjectRow(pProject.ProjectId)
            If oProjectRow IsNot Nothing Then
                Try
                    SetProjectRowValues(pProject, oProjectRow)
                    WriteXmlFromTable(oProjectDataTable)
                    isUpdated = True
                Catch ex As Exception When TypeOf (ex) Is ArgumentException _
                                    OrElse TypeOf (ex) Is ConstraintException _
                                    OrElse TypeOf (ex) Is NoNullAllowedException _
                                    OrElse TypeOf (ex) Is InvalidOperationException
                    LogUtil.DisplayException(ex, "Amend Project", MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to amend null project", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Public Sub AmendDesignFilename(pProjectId As Integer, pFilename As String)
            LogUtil.LogInfo("Changing design filename", MethodBase.GetCurrentMethod.Name)
            Dim oProjectRow As ProjectsRow = GetProjectRow(pProjectId)
            If oProjectRow IsNot Nothing Then
                If pFilename Is Nothing Then
                    Throw New Global.System.ArgumentNullException("designfilename")
                Else
                    Try
                        oProjectRow.design_file = CType(pFilename, String)
                        WriteXmlFromTable(oProjectDataTable)
                    Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                        OrElse TypeOf ex Is InvalidOperationException)
                        LogUtil.DisplayException(ex, "Amend Design Filename", MethodBase.GetCurrentMethod.Name)
                    End Try
                End If
            Else
                LogUtil.Problem("Trying to amend null project", MethodBase.GetCurrentMethod.Name)
            End If
        End Sub
        Public Sub AmendProjectTotalTime(pProject As Project)
            LogUtil.LogInfo("Amending project total time", MethodBase.GetCurrentMethod.Name)
            If pProject IsNot Nothing Then
                Dim oProjectRow As ProjectsRow = GetProjectRow(pProject.ProjectId)
                If oProjectRow IsNot Nothing Then
                    Try
                        With pProject
                            oProjectRow.total_minutes = CType(.TotalMinutes, Integer)
                            oProjectRow.date_started = .DateStarted
                            oProjectRow.date_ended = .DateEnded
                            WriteXmlFromTable(oProjectDataTable)
                        End With
                    Catch ex As Exception
                        LogUtil.DisplayException(ex, "Amend Project Time", MethodBase.GetCurrentMethod.Name)
                    End Try
                Else
                    LogUtil.Problem("Trying to amend null project", MethodBase.GetCurrentMethod.Name)
                End If
            End If
        End Sub
        Public Sub RemoveProject(pProject As Project)
            LogUtil.LogInfo("Removing project", MethodBase.GetCurrentMethod.Name)
            Dim oProjectRow As ProjectsRow = GetProjectRow(pProject.ProjectId)
            Try
                oProjectDataTable.Rows.Remove(oProjectRow)
                WriteXmlFromTable(oProjectDataTable)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                 OrElse TypeOf ex Is InvalidOperationException)
                LogUtil.DisplayException(ex, "Remove Project", MethodBase.GetCurrentMethod.Name)
            End Try
        End Sub
#End Region
#Region "Threads"
        Public Function GetThreadsList() As List(Of Thread)
            Dim oThreadList As New List(Of Thread)
            For Each oRow As ThreadsRow In oThreadDataTable.Rows
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
                    oThread = ThreadBuilder.AThread.StartingWith(oThreadRows.First).Build
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThread
        End Function
        Public Function GetThreadRow(pThreadId As Integer) As ThreadsRow
            Dim oThreadRow As ThreadsRow = Nothing
            Try
                Dim oThreadRows = From Thread In oThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.thread_id = pThreadId
                If oThreadRows.Count = 1 Then
                    oThreadRow = oThreadRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThreadRow
        End Function
        Public Function AmendThread(pThread As Thread) As Boolean
            LogUtil.LogInfo("Amending thread", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pThread IsNot Nothing Then
                Dim oThreadRow As ThreadsRow = GetThreadRow(pThread.ThreadId)
                If oThreadRow IsNot Nothing Then
                    SetThreadRowValues(pThread, oThreadRow)
                    isUpdated = True
                End If
            Else
                LogUtil.Problem("Trying to amend null thread", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Private Function SetThreadRowValues(pThread As Thread, pThreadRow As ThreadsRow) As ThreadsRow
            With pThread
                If (.ThreadNo Is Nothing) Then
                    Throw New Global.System.ArgumentNullException("Threadno")
                Else
                    pThreadRow.thread_no = CType(.ThreadNo, String)
                End If
                pThreadRow.thread_colour = .Colour.ToArgb
                pThreadRow.thread_colour_name = If(.ColourName, "")
                pThreadRow.stock_level = .StockLevel
                pThreadRow.brand_id = .BrandId
            End With
            Return pThreadRow
        End Function
        Public Sub RemoveThread(pThread As Thread)
            LogUtil.LogInfo("Removing thread", MethodBase.GetCurrentMethod.Name)
            If pThread IsNot Nothing Then
                Dim oThreadRow As ThreadsRow = GetThreadRow(pThread.ThreadId)
                oThreadDataTable.Rows.Remove(oThreadRow)
            Else
                LogUtil.Problem("Trying to remove null thread", MethodBase.GetCurrentMethod.Name)
            End If
        End Sub
        Public Function AddNewThread(pThread As Thread) As Boolean
            LogUtil.LogInfo("Adding new thread", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pThread IsNot Nothing Then
                Dim oThreadRow As ThreadsRow = oThreadDataTable.NewRow
                oThreadRow = SetThreadRowValues(pThread, oThreadRow)
                oThreadDataTable.Rows.Add(oThreadRow)
            Else
                LogUtil.Problem("Trying to add null thread", MethodBase.GetCurrentMethod.Name)
                isOK = False
            End If
            Return isOK
        End Function
#End Region
#Region "Project Threads"
        Public Sub RemoveProjectThread(ByRef pProjectThread As ProjectThread)
            LogUtil.LogInfo("Removing project thread", MethodBase.GetCurrentMethod.Name)
            If pProjectThread IsNot Nothing Then
                Dim oThreadRow As ProjectThreadsRow = GetProjectThreadByKey(pProjectThread.ProjectId, pProjectThread.Thread.ThreadId)
                If oThreadRow IsNot Nothing Then
                    oProjectThreadDataTable.Rows.Remove(oThreadRow)
                End If
            Else
                LogUtil.Problem("Trying to remove null project thread", MethodBase.GetCurrentMethod.Name)
            End If
        End Sub
        Private Function GetProjectThreadByKey(pProjectId As Integer, pThreadId As Integer) As ProjectThreadsRow
            Dim oThreadRow As ProjectThreadsRow = Nothing
            Try
                Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.thread_id = pThreadId And Thread.project_id = pProjectId
                If oThreadRows.Count = 1 Then
                    oThreadRow = oThreadRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThreadRow
        End Function
        Public Function AddNewProjectThread(pProjectThread As ProjectThread) As Boolean
            LogUtil.LogInfo("Adding new project thread", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pProjectThread IsNot Nothing Then
                Dim oProjectThreadRow As ProjectThreadsRow = oProjectThreadDataTable.NewRow
                oProjectThreadRow = SetProjectThreadRowValues(pProjectThread, oProjectThreadRow)
                oProjectThreadDataTable.Rows.Add(oProjectThreadRow)
            Else
                LogUtil.Problem("Trying to add null project thread", MethodBase.GetCurrentMethod.Name)
                isOK = False
            End If
            Return isOK
        End Function
        Private Function SetProjectThreadRowValues(pProjectThread As ProjectThread, pProjectThreadRow As ProjectThreadsRow) As ProjectThreadsRow
            With pProjectThread
                pProjectThreadRow.project_id = .ProjectId
                pProjectThreadRow.thread_id = .ThreadId
                pProjectThreadRow.symbol_id = .SymbolId
                pProjectThreadRow.knot_count = 0
                pProjectThreadRow.backstitch_count = 0
                pProjectThreadRow.blockstitch_count = 0
                pProjectThreadRow.is_used = If(.IsUsed, 1, 0)
            End With
            Return pProjectThreadRow
        End Function
        Public Function FindThreads() As List(Of Thread)
            Dim oThreads As New List(Of Thread)
            Dim oThreadRows = From Thread In oThreadDataTable.AsEnumerable()
                              Select Thread
            For Each oRow As ThreadsRow In oThreadRows
                oThreads.Add(ThreadBuilder.AThread.StartingWith(oRow).Build)
            Next
            Return oThreads
        End Function
        Public Function FindProjectThreads(pProjectId As Integer) As ProjectThreadCollection
            Dim oProjectThreadCollection As New ProjectThreadCollection
            Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId
            For Each oRow As ProjectThreadsRow In oThreadRows
                oProjectThreadCollection.Add(ProjectThreadBuilder.AProjectThread.StartingWith(oRow).Build)
            Next
            Return oProjectThreadCollection
        End Function
        Public Function FindThreadsForProject(pProjectId As Integer) As List(Of Thread)
            Dim oThreadList As New List(Of Thread)
            Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId
            For Each oRow As ProjectThreadsRow In oThreadRows
                oThreadList.Add(FindThreadById(oRow.thread_id))
            Next
            Return oThreadList
        End Function
        Public Function FindUsedThreadsForProject(pProjectId As Integer, pIsUsed As Boolean) As List(Of Integer)
            Dim _list As New List(Of Integer)
            Dim oThreadRows = From Thread In oProjectThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId And Thread.is_used = If(pIsUsed, 1, 0)
            For Each oRow As ProjectThreadsRow In oThreadRows
                _list.Add(oRow.thread_id)
            Next
            Return _list
        End Function
        Public Function FindProjectThread(pProjectId As Integer, pThreadId As Integer) As ProjectThread
            Return ProjectThreadBuilder.AProjectThread.StartingWith(GetProjectThreadByKey(pProjectId, pThreadId)).Build
        End Function
        Public Function AmendProjectThreadSymbolId(pProjectId As Integer, pThreadId As Integer, pSymbolId As Integer) As Boolean
            LogUtil.LogInfo("Changing project thread symbol", MethodBase.GetCurrentMethod.Name)
            Dim oRow As ProjectThreadsRow = GetProjectThreadByKey(pProjectId, pThreadId)
            Dim isOk As Boolean = True
            If oRow IsNot Nothing Then
                oRow.symbol_id = pSymbolId
            Else
                LogUtil.Problem("Cannot find project thread", MethodBase.GetCurrentMethod.Name)
                isOk = True
            End If
            Return isOk
        End Function
        Public Function AmendProjectThreadIsUsed(pThread As ProjectThread) As Boolean
            '           LogUtil.LogInfo("Changing project thread is used", MethodBase.GetCurrentMethod.Name)
            Dim oRow As ProjectThreadsRow = GetProjectThreadByKey(pThread.ProjectId, pThread.ThreadId)
            Dim isOk As Boolean = True
            If oRow IsNot Nothing Then
                oRow.is_used = If(pThread.IsUsed, 1, 0)
            Else
                LogUtil.Problem("Cannot find project thread", MethodBase.GetCurrentMethod.Name)
                isOk = False
            End If
            Return isOk
        End Function
        Public Sub RemoveProjectThreadsForProject(pProjectId As Integer)
            LogUtil.LogInfo("Removing all project threads for project " & CStr(pProjectId), MethodBase.GetCurrentMethod.Name)
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
            For Each oRow As ProjectThreadCardsRow In oThreadRows
                oProjectThreadCardList.Add(ProjectThreadCardBuilder.AProjectThreadCard.StartingWith(oRow).Build)
            Next
            Return oProjectThreadCardList
        End Function
        Public Function AddNewProjectThreadCard(pProjectThreadCard As ProjectThreadCard) As Boolean
            LogUtil.LogInfo("Adding a new project thread card", MethodBase.GetCurrentMethod.Name)
            Dim isOk = True
            If pProjectThreadCard IsNot Nothing Then
                Dim oProjectThreadCardRow As ProjectThreadCardsRow = oProjectThreadCardDataTable.NewRow
                oProjectThreadCardRow = SetProjectThreadCardRowValues(pProjectThreadCard, oProjectThreadCardRow)
                oProjectThreadCardDataTable.Rows.Add(oProjectThreadCardRow)
            Else
                LogUtil.Problem("Trying to add null project thread card", MethodBase.GetCurrentMethod.Name)
            End If
            Return isOk
        End Function
        Private Function SetProjectThreadCardRowValues(pProjectThreadCard As ProjectThreadCard, pProjectThreadCardRow As ProjectThreadCardsRow) As ProjectThreadCardsRow
            With pProjectThreadCard
                pProjectThreadCardRow.thread_card_no = .CardNo
                pProjectThreadCardRow.project_id = .Project.ProjectId
            End With
            Return pProjectThreadCardRow
        End Function
        Public Sub RemoveProjectCards(pProjectId As Integer)
            LogUtil.LogInfo("Removing project cards", MethodBase.GetCurrentMethod.Name)
            Try
                RemoveProjectCardThreads(pProjectId)
                RemoveCardsForProject(pProjectId)
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
        End Sub
        Public Sub RemoveCardsForProject(pProjectId As Integer)
            LogUtil.LogInfo("Removing cards for project " & CStr(pProjectId), MethodBase.GetCurrentMethod.Name)
            Dim oCardRows = From Card In oProjectThreadCardDataTable.AsEnumerable()
                            Select Card
                            Where Card.project_id = pProjectId
            For Each oRow As ProjectThreadCardsRow In oCardRows
                oProjectThreadCardDataTable.Rows.Remove(oRow)
            Next
        End Sub
        Public Sub RemoveThreadcard(pProjectId As Integer, pCardNo As Integer)
            LogUtil.LogInfo("Removing Threadcard", MethodBase.GetCurrentMethod.Name)
            Dim oThreadcardRow As ProjectThreadCardsRow = GetprojectThreadcardRow(pProjectId, pCardNo)
            oProjectThreadCardDataTable.Rows.Remove(oThreadcardRow)
        End Sub
        Public Function GetprojectThreadcardRow(pProjectId As Integer, pCardNo As Integer) As ProjectThreadCardsRow
            Dim oprojectThreadcardRow As ProjectThreadCardsRow = Nothing
            Try
                Dim oProjectThreadcardRows = From projectThreadcard In oProjectThreadCardDataTable.AsEnumerable()
                                             Select projectThreadcard
                                             Where projectThreadcard.project_id = pProjectId And projectThreadcard.thread_card_no = pCardNo
                If oProjectThreadcardRows.Count = 1 Then
                    oprojectThreadcardRow = oProjectThreadcardRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oprojectThreadcardRow
        End Function
#End Region
#Region "ProjectCardThreads"
        Public Function AddNewCardThread(ByRef pProjectCardThread As ProjectCardThread) As Boolean
            LogUtil.LogInfo("Adding new card thread", MethodBase.GetCurrentMethod.Name)
            If pProjectCardThread IsNot Nothing Then
                Dim oThreadRow As ProjectCardThreadRow = oProjectCardThreadDataTable.NewRow
                oThreadRow = SetProjectCardThreadRowValues(pProjectCardThread, oThreadRow)
                oProjectCardThreadDataTable.Rows.Add(oThreadRow)
            Else
                LogUtil.Problem("Trying to add null card thread", MethodBase.GetCurrentMethod.Name)
            End If
            Return True
        End Function
        Private Function SetProjectCardThreadRowValues(pThread As ProjectCardThread, pThreadRow As ProjectCardThreadRow) As ProjectCardThreadRow
            With pThread
                pThreadRow.project_id = .Project.ProjectId
                pThreadRow.thread_id = .Thread.ThreadId
                pThreadRow.thread_card_no = .CardNo
                pThreadRow.thread_card_seq = .CardSeq
            End With
            Return pThreadRow
        End Function
        Public Sub RemoveProjectCardThread(pThread As ProjectCardThread)
            LogUtil.LogInfo("Removing card thread", MethodBase.GetCurrentMethod.Name)
            If pThread IsNot Nothing Then
                With pThread
                    Dim oThreadRow As ProjectCardThreadRow = GetProjectCardThreadRow(.Project.ProjectId, .Thread.ThreadId, .CardNo, .CardSeq)
                    oProjectCardThreadDataTable.Rows.Remove(oThreadRow)
                End With
            Else
                LogUtil.Problem("Trying to remove null project card thread", MethodBase.GetCurrentMethod.Name)
            End If
        End Sub
        Private Function GetProjectCardThreadRow(pProjectId As Integer, pThreadId As Integer, pCardNo As Integer, pCardSeq As Integer) As ProjectCardThreadRow
            Dim oThreadRow As ProjectCardThreadRow = Nothing
            Try
                Dim oThreadRows = From Thread In oProjectCardThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.thread_id = pThreadId _
                                  And Thread.project_id = pProjectId _
                                  And Thread.thread_card_no = pCardNo _
                                  And Thread.thread_card_seq = pCardSeq
                If oThreadRows.Count = 1 Then
                    oThreadRow = oThreadRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThreadRow
        End Function
        Public Sub RemoveProjectCardThreads(pProjectId As Integer)
            LogUtil.LogInfo("Remove card threads for project " & CStr(pProjectId), MethodBase.GetCurrentMethod.Name)
            Dim oThreadRows = From Thread In oProjectCardThreadDataTable.AsEnumerable()
                              Select Thread
                              Where Thread.project_id = pProjectId
            For Each oRow As ProjectCardThreadRow In oThreadRows
                oProjectCardThreadDataTable.Rows.Remove(oRow)
            Next
        End Sub
        Public Sub RemoveThreadsForProjectCard(pProjectId As Integer, pCardNo As Integer)
            LogUtil.LogInfo("Removing threads for project card " & pProjectId & ":" & pCardNo, MethodBase.GetCurrentMethod.Name)
            Try
                Dim oThreadRows = From Thread In oProjectCardThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.project_id = pProjectId _
                                  And Thread.thread_card_no = pCardNo
                For Each oThreadRow As ProjectCardThreadRow In oThreadRows
                    oProjectThreadCardDataTable.Rows.Remove(oThreadRow)
                Next
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
        End Sub
        Public Function FindProjectCardThreadsByProjectCard(pProjectId As Integer, pCardNo As Integer) As List(Of ProjectCardThread)
            Dim _list As New List(Of ProjectCardThread)
            Try
                Dim oThreadRows = From Thread In oProjectCardThreadDataTable.AsEnumerable()
                                  Select Thread
                                  Where Thread.project_id = pProjectId And Thread.thread_card_no = pCardNo
                For Each oRow As MyStitchDataSet.ProjectCardThreadRow In oThreadRows
                    Dim _cardThread As ProjectCardThread = ProjectCardThreadBuilder.AProjectCardThread.StartingWith(oRow).Build
                    _list.Add(_cardThread)
                Next
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return _list
        End Function
#End Region
#Region "settings"
        Public Function FindSettingByName(settingName As String) As GlobalSetting
            Return FindSettingByName(settingName, "", "")
        End Function
        Public Function FindSettingByName(settingName As String, defaultValue As String, defaultType As String) As GlobalSetting
            LogUtil.Info("Get setting " & settingName, MethodBase.GetCurrentMethod.Name)
            Dim rtnValue As GlobalSetting = GlobalSettingBuilder.AGlobalSetting.StartingWithNothing _
                                                                            .WithName(settingName) _
                                                                            .WithValue(defaultValue) _
                                                                            .WithType(defaultType).Build
            Try
                Dim oSettings = From GlobalSetting In oSettingsDataTable.AsEnumerable()
                                Select GlobalSetting
                                Where GlobalSetting.pKey = settingName
                If oSettings.Count > 0 Then
                    Dim oRow As SettingsRow = oSettings.First
                    rtnValue = GlobalSettingBuilder.AGlobalSetting.StartingWith(oRow).Build
                End If
            Catch ex As Exception
                LogUtil.Exception("Exception getting setting " & settingName, ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return rtnValue
        End Function
        Public Function AmendSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String) As Boolean
            LogUtil.Info("Changing setting " & settingName, MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean
            Try
                Dim oSettings = From GlobalSetting In oSettingsDataTable.AsEnumerable()
                                Select GlobalSetting
                                Where GlobalSetting.pKey = settingName
                If oSettings.Count > 0 Then
                    Dim orow As SettingsRow = oSettings.First
                    orow.pType = settingType
                    orow.pValue = settingValue
                    isOK = True
                End If
            Catch ex As DbException
                isOK = False
            End Try
            Return isOK
        End Function
        Public Function AddNewSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String) As Boolean
            LogUtil.Info("Adding new setting " & settingName, MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean
            Try
                Dim oRow As SettingsRow = oSettingsDataTable.NewRow
                oRow.pType = settingType
                oRow.pValue = settingValue
                oSettingsDataTable.Rows.Add(oRow)
                isOK = True
            Catch ex As DbException
                isOK = False
            End Try
            Return isOK
        End Function
        Public Function FillSettingsTable(ByRef pSettingsTable As MyStitchDataSet.SettingsDataTable) As MyStitchDataSet.SettingsDataTable
            For Each _row As MyStitchDataSet.SettingsRow In oSettingsDataTable.Rows
                Dim newRow As MyStitchDataSet.SettingsRow = pSettingsTable.NewSettingsRow
                newRow.pKey = _row.pKey
                newRow.pValue = _row.pValue
                newRow.pType = _row.pType
                pSettingsTable.Rows.Add(newRow)
            Next
            Return pSettingsTable
        End Function
#End Region
#Region "symbols"
        Public Function GetSymbolsList() As List(Of Symbol)
            Dim oSymbolList As New List(Of Symbol)
            For Each oRow As SymbolsRow In oSymbolsDataTable.Rows
                oSymbolList.Add(SymbolBuilder.ASymbol.StartingWith(oRow).Build)
            Next
            Return oSymbolList
        End Function
        Public Function FindSymbolById(pSymbolId As Integer) As Symbol
            Return SymbolBuilder.ASymbol.StartingWith(GetSymbolRow(pSymbolId)).Build
        End Function
        Public Function FindSymbolImage(pSymbolId As Integer) As Image
            Dim _image As Image = SymbolBuilder.ASymbol.StartingWith(GetSymbolRow(pSymbolId)).Build.SymbolImage
            Return _image
        End Function
        Public Function GetSymbolRow(pSymbolId As Integer) As SymbolsRow
            Dim oSymbolRow As SymbolsRow = Nothing
            Try
                Dim oSymbolRows = From Symbol In oSymbolsDataTable.AsEnumerable()
                                  Select Symbol
                                  Where Symbol.symbol_id = pSymbolId
                If oSymbolRows.Count = 1 Then
                    oSymbolRow = oSymbolRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oSymbolRow
        End Function
        Public Function AmendSymbol(pSymbol As Symbol) As Boolean
            LogUtil.LogInfo("Changing symbol " & CStr(pSymbol.SymbolId), MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pSymbol IsNot Nothing Then
                Dim oSymbolRow As SymbolsRow = GetSymbolRow(pSymbol.SymbolId)
                If oSymbolRow IsNot Nothing Then
                    SetSymbolRowValues(pSymbol, oSymbolRow)
                    isUpdated = True
                End If
            Else
                LogUtil.Problem("Trying to change null symbol", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Private Function SetSymbolRowValues(pSymbol As Symbol, pSymbolRow As SymbolsRow) As SymbolsRow
            With pSymbol
                pSymbolRow.symbol_id = .SymbolId
                pSymbolRow.symbol = .SymbolBytes
            End With
            Return pSymbolRow
        End Function
        Public Sub RemoveSymbol(pSymbolId As Integer)
            LogUtil.LogInfo("Removing symbol " & CStr(pSymbolId), MethodBase.GetCurrentMethod.Name)
            Dim oSymbolRow As SymbolsRow = GetSymbolRow(pSymbolId)
            oSymbolsDataTable.Rows.Remove(oSymbolRow)
        End Sub
        Public Function AddNewSymbol(pSymbol As Symbol) As Boolean
            LogUtil.LogInfo("Adding new symbol", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pSymbol IsNot Nothing Then
                Dim oSymbolRow As SymbolsRow = oSymbolsDataTable.NewRow
                oSymbolRow = SetSymbolRowValues(pSymbol, oSymbolRow)
                oSymbolsDataTable.Rows.Add(oSymbolRow)
            Else
                isOK = False
                LogUtil.Problem("Trying to add null symbol", MethodBase.GetCurrentMethod.Name)
            End If
            Return isOK
        End Function
#End Region
#Region "projectworktimes"
        Public Function FindWorkPeriodsForProject(pProjectId As Integer) As List(Of ProjectWorkTime)
            Dim oPeriods As New List(Of ProjectWorkTime)
            Try
                Dim oPeriodRows = From ProjectWorkTime In oProjectWorkTimesDataTable.AsEnumerable()
                                  Select ProjectWorkTime
                                  Where ProjectWorkTime.project_id = pProjectId
                For Each oRow As ProjectWorkTimesRow In oPeriodRows
                    oPeriods.Add(ProjectWorkTimeBuilder.AProjectWorkTime.StartingWith(oRow).Build)
                Next
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oPeriods
        End Function
        Public Function AddNewProjectWorktime(pProjectWorktime As ProjectWorkTime) As Boolean
            LogUtil.LogInfo("Adding new work time", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pProjectWorktime IsNot Nothing Then
                Dim oProjectWorktimeRow As ProjectWorkTimesRow = oProjectWorkTimesDataTable.NewRow
                oProjectWorktimeRow = SetProjectWorktimeRowValues(pProjectWorktime, oProjectWorktimeRow)
                oProjectWorkTimesDataTable.Rows.Add(oProjectWorktimeRow)
            Else
                LogUtil.Problem("Trying to add null work time", MethodBase.GetCurrentMethod.Name)
                isOK = False
            End If
            Return isOK
        End Function
        Private Function SetProjectWorktimeRowValues(pProjectWorktime As ProjectWorkTime, pProjectWorktimeRow As ProjectWorkTimesRow) As ProjectWorkTimesRow
            With pProjectWorktime
                pProjectWorktimeRow.project_id = .ProjectId
                pProjectWorktimeRow.start_date = .TimeStarted
                pProjectWorktimeRow.end_date = .TimeEnded
                pProjectWorktimeRow.minutes = .Minutes
            End With
            Return pProjectWorktimeRow
        End Function
        Public Function UpdateProjectWorkTime(pProjectWorkTime As ProjectWorkTime) As Boolean
            LogUtil.LogInfo("Updating project work time", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pProjectWorkTime IsNot Nothing Then
                Dim oProjectWorktimeRow As ProjectWorkTimesRow = GetProjectWorktimeRow(pProjectWorkTime)
                If oProjectWorktimeRow IsNot Nothing Then
                    SetProjectWorktimeRowValues(pProjectWorkTime, oProjectWorktimeRow)
                Else
                    LogUtil.Problem("Work time not found", MethodBase.GetCurrentMethod.Name)
                End If
            Else
                LogUtil.Problem("Trying to update null work time", MethodBase.GetCurrentMethod.Name)
                isOK = False
            End If
            Return isOK
        End Function
        Private Function GetProjectWorktimeRow(pProjectWorktime As ProjectWorkTime) As ProjectWorkTimesRow
            Dim oProjectWorktimeRow As ProjectWorkTimesRow = Nothing
            Try
                Dim oProjectWorktimeRows = From ProjectWorktime In oProjectWorkTimesDataTable.AsEnumerable()
                                           Select ProjectWorktime
                                           Where ProjectWorktime.project_id = pProjectWorktime.ProjectId And ProjectWorktime.start_date = pProjectWorktime.TimeStarted
                If oProjectWorktimeRows.Count = 1 Then
                    oProjectWorktimeRow = oProjectWorktimeRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oProjectWorktimeRow
        End Function
#End Region
#Region "palettes"
        Public Function GetPaletteList() As List(Of Palette)
            Dim oPaletteList As New List(Of Palette)
            For Each oRow As PalettesRow In oPalettesDataTable.Rows
                oPaletteList.Add(PaletteBuilder.APalette.StartingWith(oRow).Build)
            Next
            Return oPaletteList
        End Function
        Public Function AddNewPalette(pPalette As String) As Boolean
            LogUtil.LogInfo("Adding new palette", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pPalette IsNot Nothing Then
                Dim oPaletteRow As PalettesRow = oPalettesDataTable.NewRow
                oPaletteRow = SetPaletteRowValues(pPalette, oPaletteRow)
                oPalettesDataTable.Rows.Add(oPaletteRow)
            Else
                LogUtil.Problem("Trying to add null palette", MethodBase.GetCurrentMethod.Name)
            End If
            Return isOK
        End Function
        Private Function SetPaletteRowValues(pPalette As String, pPaletteRow As PalettesRow) As PalettesRow
            pPaletteRow.palette_name = pPalette
            Return pPaletteRow
        End Function
        Public Function AddNewPaletteThread(pPaletteThread As PaletteThread) As Boolean
            LogUtil.LogInfo("Adding new palette thread", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pPaletteThread IsNot Nothing Then
                Dim oPaletteThreadRow As PaletteThreadsRow = oPaletteThreadsDataTable.NewRow
                oPaletteThreadRow = SetPaletteThreadRowValues(pPaletteThread, oPaletteThreadRow)
                oPaletteThreadsDataTable.Rows.Add(oPaletteThreadRow)
            Else
                LogUtil.Problem("Trying to add null palette thread", MethodBase.GetCurrentMethod.Name)
            End If
            Return isOK
        End Function
        Private Function SetPaletteThreadRowValues(pPaletteThread As PaletteThread, pPaletteThreadRow As PaletteThreadsRow) As PaletteThreadsRow
            With pPaletteThread
                pPaletteThreadRow.palette_id = .PaletteId
                pPaletteThreadRow.thread_id = .ThreadId
                pPaletteThreadRow.symbol_id = .SymbolId
                pPaletteThreadRow.isbead = If(.IsBead, 1, 0)
            End With
            Return pPaletteThreadRow
        End Function
        Public Function FindPaletteThreadsByPaletteId(pPaletteId As Integer) As List(Of PaletteThread)
            Dim oThreads As New List(Of PaletteThread)
            Try
                Dim oPaletteThreadRows = From PaletteThread In oPaletteThreadsDataTable.AsEnumerable()
                                         Select PaletteThread
                                         Where PaletteThread.palette_id = pPaletteId
                For Each oRow As PaletteThreadsRow In oPaletteThreadRows
                    oThreads.Add(PaletteThreadBuilder.APaletteThread.StartingWith(oRow).Build)
                Next
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oThreads
        End Function
#End Region
#Region "Beads"
        Public Function GetBeadsList() As List(Of Bead)
            Dim oBeadList As New List(Of Bead)
            For Each oRow As BeadsRow In oBeadDataTable.Rows
                oBeadList.Add(BeadBuilder.ABead.StartingWith(oRow).Build)
            Next
            Return oBeadList
        End Function
        Public Function FindBeads() As List(Of Bead)
            Dim oBeads As New List(Of Bead)
            Dim oBeadRows = From Bead In oBeadDataTable.AsEnumerable()
                            Select Bead
            For Each oRow As BeadsRow In oBeadRows
                oBeads.Add(BeadBuilder.ABead.StartingWith(oRow).Build)
            Next
            Return oBeads
        End Function
        Public Function FindBeadById(pProjectId As Integer) As Bead
            Return BeadBuilder.ABead.StartingWith(GetBeadRow(pProjectId)).Build
        End Function
        Public Function FindBeadByNumber(pBeadNumber As String) As Bead
            Dim oBead As New Bead
            Try
                Dim oBeadRows = From Bead In oBeadDataTable.AsEnumerable()
                                Select Bead
                                Where Bead.bead_no = pBeadNumber
                If oBeadRows.Count > 0 Then
                    oBead = BeadBuilder.ABead.StartingWith(oBeadRows.First).Build
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oBead
        End Function
        Public Function GetBeadRow(pBeadId As Integer) As BeadsRow
            Dim oBeadRow As BeadsRow = Nothing
            Try
                Dim oBeadRows = From Bead In oBeadDataTable.AsEnumerable()
                                Select Bead
                                Where Bead.bead_id = pBeadId
                If oBeadRows.Count = 1 Then
                    oBeadRow = oBeadRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oBeadRow
        End Function
        Public Function AmendBead(pBead As Bead) As Boolean
            LogUtil.LogInfo("Amending Bead", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pBead IsNot Nothing Then
                Dim oBeadRow As BeadsRow = GetBeadRow(pBead.beadId)
                If oBeadRow IsNot Nothing Then
                    SetBeadRowValues(pBead, oBeadRow)
                    isUpdated = True
                End If
            Else
                LogUtil.Problem("Trying to amend null Bead", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Private Function SetBeadRowValues(pBead As Bead, pBeadRow As BeadsRow) As BeadsRow
            With pBead
                If (.beadNo Is Nothing) Then
                    Throw New Global.System.ArgumentNullException("Beadno")
                Else
                    pBeadRow.bead_no = CType(.beadNo, String)
                End If
                pBeadRow.bead_colour = .Colour.ToArgb
                pBeadRow.bead_colour_name = If(.ColourName, "")
                pBeadRow.stock_level = .StockLevel
                pBeadRow.brand_id = .BrandId
            End With
            Return pBeadRow
        End Function
        Public Sub RemoveBead(pBead As Bead)
            LogUtil.LogInfo("Removing Bead", MethodBase.GetCurrentMethod.Name)
            If pBead IsNot Nothing Then
                Dim oBeadRow As BeadsRow = GetBeadRow(pBead.beadId)
                oBeadDataTable.Rows.Remove(oBeadRow)
            Else
                LogUtil.Problem("Trying to remove null Bead", MethodBase.GetCurrentMethod.Name)
            End If
        End Sub
        Public Function AddNewBead(pBead As Bead) As Boolean
            LogUtil.LogInfo("Adding new Bead", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pBead IsNot Nothing Then
                Dim oBeadRow As BeadsRow = oBeadDataTable.NewRow
                oBeadRow = SetBeadRowValues(pBead, oBeadRow)
                oBeadDataTable.Rows.Add(oBeadRow)
            Else
                LogUtil.Problem("Trying to add null Bead", MethodBase.GetCurrentMethod.Name)
                isOK = False
            End If
            Return isOK
        End Function
#End Region
#Region "Project Beads"
        Public Sub RemoveProjectBead(ByRef pProjectBead As ProjectBead)
            LogUtil.LogInfo("Removing project Bead", MethodBase.GetCurrentMethod.Name)
            If pProjectBead IsNot Nothing Then
                Dim oBeadRow As ProjectBeadsRow = GetProjectBeadByKey(pProjectBead.ProjectId, pProjectBead.Bead.BeadId)
                If oBeadRow IsNot Nothing Then
                    oProjectBeadDataTable.Rows.Remove(oBeadRow)
                End If
            Else
                LogUtil.Problem("Trying to remove null project Bead", MethodBase.GetCurrentMethod.Name)
            End If
        End Sub
        Private Function GetProjectBeadByKey(pProjectId As Integer, pBeadId As Integer) As ProjectBeadsRow
            Dim oBeadRow As ProjectBeadsRow = Nothing
            Try
                Dim oBeadRows = From Bead In oProjectBeadDataTable.AsEnumerable()
                                Select Bead
                                Where Bead.bead_id = pBeadId And Bead.project_id = pProjectId
                If oBeadRows.Count = 1 Then
                    oBeadRow = oBeadRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oBeadRow
        End Function
        Public Function AddNewProjectBead(pProjectBead As ProjectBead) As Boolean
            LogUtil.LogInfo("Adding new project Bead", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pProjectBead IsNot Nothing Then
                Dim oProjectBeadRow As ProjectBeadsRow = oProjectBeadDataTable.NewRow
                oProjectBeadRow = SetProjectBeadRowValues(pProjectBead, oProjectBeadRow)
                Try
                    oProjectBeadDataTable.Rows.Add(oProjectBeadRow)
                Catch ex As ConstraintException
                    LogUtil.LogException(ex, "Error adding project bead", MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to add null project Bead", MethodBase.GetCurrentMethod.Name)
                isOK = False
            End If
            Return isOK
        End Function
        Private Function SetProjectBeadRowValues(pProjectBead As ProjectBead, pProjectBeadRow As ProjectBeadsRow) As ProjectBeadsRow
            With pProjectBead
                pProjectBeadRow.project_id = .ProjectId
                pProjectBeadRow.bead_id = .BeadId
                pProjectBeadRow.is_used = If(.IsUsed, 1, 0)
            End With
            Return pProjectBeadRow
        End Function
        'Public Function FindBeads() As List(Of Bead)
        '    Dim oBeads As New List(Of Bead)
        '    Dim oBeadRows = From Bead In oBeadDataTable.AsEnumerable()
        '                    Select Bead
        '    For Each oRow As BeadsRow In oBeadRows
        '        oBeads.Add(BeadBuilder.ABead.StartingWith(oRow).Build)
        '    Next
        '    Return oBeads
        'End Function
        Public Function FindProjectBeads(pProjectId As Integer) As ProjectBeadCollection
            Dim oProjectBeadCollection As New ProjectBeadCollection
            Dim oBeadRows = From Bead In oProjectBeadDataTable.AsEnumerable()
                            Select Bead
                            Where Bead.project_id = pProjectId
            For Each oRow As ProjectBeadsRow In oBeadRows
                oProjectBeadCollection.Add(ProjectBeadBuilder.AProjectBead.StartingWith(oRow).Build)
            Next
            Return oProjectBeadCollection
        End Function
        Public Function FindBeadsForProject(pProjectId As Integer) As List(Of Bead)
            Dim oBeadList As New List(Of Bead)
            Dim oBeadRows = From Bead In oProjectBeadDataTable.AsEnumerable()
                            Select Bead
                            Where Bead.project_id = pProjectId
            For Each oRow As ProjectBeadsRow In oBeadRows
                oBeadList.Add(FindBeadById(oRow.bead_id))
            Next
            Return oBeadList
        End Function
        Public Function FindUsedBeadsForProject(pProjectId As Integer, pIsUsed As Boolean) As List(Of Integer)
            Dim _list As New List(Of Integer)
            Dim oBeadRows = From Bead In oProjectBeadDataTable.AsEnumerable()
                            Select Bead
                            Where Bead.project_id = pProjectId And Bead.is_used = If(pIsUsed, 1, 0)
            For Each oRow As ProjectBeadsRow In oBeadRows
                _list.Add(oRow.bead_id)
            Next
            Return _list
        End Function
        Public Function FindProjectBead(pProjectId As Integer, pBeadId As Integer) As ProjectBead
            Return ProjectBeadBuilder.AProjectBead.StartingWith(GetProjectBeadByKey(pProjectId, pBeadId)).Build
        End Function
        Public Function AmendProjectBeadIsUsed(pBead As ProjectBead) As Boolean
            '           LogUtil.LogInfo("Changing project Bead is used", MethodBase.GetCurrentMethod.Name)
            Dim oRow As ProjectBeadsRow = GetProjectBeadByKey(pBead.ProjectId, pBead.BeadId)
            Dim isOk As Boolean = True
            If oRow IsNot Nothing Then
                oRow.is_used = If(pBead.IsUsed, 1, 0)
            Else
                LogUtil.Problem("Cannot find project Bead", MethodBase.GetCurrentMethod.Name)
                isOk = False
            End If
            Return isOk
        End Function
        Public Sub RemoveProjectBeadsForProject(pProjectId As Integer)
            LogUtil.LogInfo("Removing all project Beads for project " & CStr(pProjectId), MethodBase.GetCurrentMethod.Name)
            For Each _projectBead As ProjectBead In FindProjectBeads(pProjectId).Beads
                RemoveProjectBead(_projectBead)
            Next
        End Sub
#End Region

#Region "Brands"
        Public Function GetBrandsList() As List(Of Brand)
            Dim oBrandList As New List(Of Brand)
            For Each oRow As BrandsRow In oBrandDataTable.Rows
                oBrandList.Add(BrandBuilder.ABrand.StartingWith(oRow).Build)
            Next
            Return oBrandList
        End Function
        Public Function AddNewBrand(pBrand As String) As Boolean
            LogUtil.LogInfo("Adding new brand", MethodBase.GetCurrentMethod.Name)
            Dim isOK As Boolean = True
            If pBrand IsNot Nothing Then
                Dim oBrandRow As BrandsRow = oBrandDataTable.NewRow
                oBrandRow = SetBrandRowValues(pBrand, oBrandRow)
                oBrandDataTable.Rows.Add(oBrandRow)
            Else
                LogUtil.Problem("Trying to add null palette", MethodBase.GetCurrentMethod.Name)
            End If
            Return isOK
        End Function
        Private Function SetBrandRowValues(pBrand As String, pBrandRow As BrandsRow) As BrandsRow
            pBrandRow.brand_name = pBrand
            Return pBrandRow
        End Function
        Public Function AmendBrand(pBrand As Brand) As Boolean
            LogUtil.LogInfo("Amending Brand", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pBrand IsNot Nothing Then
                Dim oBrandRow As BrandsRow = GetBrandRow(pBrand.BrandId)
                If oBrandRow IsNot Nothing Then
                    SetBrandRowValues(pBrand, oBrandRow)
                    isUpdated = True
                End If
            Else
                LogUtil.Problem("Trying to amend null Brand", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Private Function SetBrandRowValues(pBrand As Brand, pBrandRow As BrandsRow) As BrandsRow
            With pBrand
                If (.BrandName Is Nothing) Then
                    Throw New Global.System.ArgumentNullException("Brandno")
                Else
                    pBrandRow.brand_name = .BrandName
                End If
            End With
            Return pBrandRow
        End Function
        Public Function GetBrandRow(pBrandId As Integer) As BrandsRow
            Dim oBrandRow As BrandsRow = Nothing
            Try
                Dim oBrandRows = From Brand In oBrandDataTable.AsEnumerable()
                                 Select Brand
                                 Where Brand.brand_id = pBrandId
                If oBrandRows.Count = 1 Then
                    oBrandRow = oBrandRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oBrandRow
        End Function
        Public Sub RemoveBrand(pBrand As Brand)
            LogUtil.LogInfo("Removing Brand", MethodBase.GetCurrentMethod.Name)
            If pBrand IsNot Nothing Then
                Dim oBrandRow As BrandsRow = GetBrandRow(pBrand.BrandId)
                oBrandDataTable.Rows.Remove(oBrandRow)
            Else
                LogUtil.Problem("Trying to remove null Brand", MethodBase.GetCurrentMethod.Name)
            End If
        End Sub
        Public Function FindBrandById(pBrandId As Integer) As Brand
            Return BrandBuilder.ABrand.StartingWith(GetBrandRow(pBrandId)).Build
        End Function
        Public Function FindBrandByName(pBrandName As String) As Brand
            Dim oBrand As New Brand
            Try
                Dim oBrandRows = From Brand In oBrandDataTable.AsEnumerable()
                                 Select Brand
                                 Where Brand.brand_name = pBrandName
                If oBrandRows.Count > 0 Then
                    oBrand = BrandBuilder.ABrand.StartingWith(oBrandRows.First).Build
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oBrand
        End Function
        Public Function FindBrands() As List(Of Brand)
            Dim oBrands As New List(Of Brand)
            Dim oBrandRows = From Brand In oBrandDataTable.AsEnumerable()
                             Select Brand
            For Each oRow As BrandsRow In oBrandRows
                oBrands.Add(BrandBuilder.ABrand.StartingWith(oRow).Build)
            Next
            Return oBrands
        End Function
#End Region
    End Module
End Namespace
