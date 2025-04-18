' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports HindlewareLib.Logging
Imports MySql.Data.MySqlClient

Module ModDataFunctions
#Region "constants"
    '   Private Const MODULE_NAME As String = "DataFunctions"
    Friend Const BOOK_TAG As String = "B~"
    Friend Const TABLE_TAG As String = "T~"
    Friend Const DOC_TAG As String = "D~"
    Friend Const IMAGE_TAG As String = "I~"
    Friend Const REV_TAG As String = "R~"
#End Region
#Region "enum"
    Public Enum Tables
        Projects
        ProjectThreadCards
        ProjectThreads
        Threads
        ProjectCardThread
    End Enum
#End Region
#Region "dataset"
    Private ReadOnly oProjectTable As New MyStitchDataSet.ProjectsDataTable
    Private ReadOnly oProjectTa As New MyStitchDataSetTableAdapters.ProjectsTableAdapter
    Private ReadOnly oThreadTable As New MyStitchDataSet.ThreadsDataTable
    Private ReadOnly oThreadTa As New MyStitchDataSetTableAdapters.ThreadsTableAdapter
    Private ReadOnly oProjectThreadTable As New MyStitchDataSet.ProjectThreadsDataTable
    Private ReadOnly oProjectThreadTa As New MyStitchDataSetTableAdapters.ProjectThreadsTableAdapter
    Private ReadOnly oProjectThreadCardTable As New MyStitchDataSet.ProjectThreadCardsDataTable
    Private ReadOnly oProjectThreadCardTa As New MyStitchDataSetTableAdapters.ProjectThreadCardsTableAdapter
    Private ReadOnly oProjectCardThreadTable As New MyStitchDataSet.ProjectCardThreadDataTable
    Private ReadOnly oProjectCardThreadTa As New MyStitchDataSetTableAdapters.ProjectCardThreadTableAdapter

#End Region
#Region "variables"
    Public tableList As New List(Of String)
#End Region
#Region "common"
    Public Sub SetConnectionString(pDatabase As String)
        My.Settings.Item("mynovelConnectionString") = "server=localhost;user id=ehindle;password=dkk.mysql;persistsecurityinfo=True;database=" & pDatabase
    End Sub
    Public Sub InitialiseData()
        LogUtil.LogInfo("Initialising data", MethodBase.GetCurrentMethod.Name)
        Dim _enumArray As Array
        _enumArray = [Enum].GetValues(GetType(Tables))
        For Each _enum In _enumArray
            tableList.Add(_enum.ToString)
        Next
    End Sub
    Public Sub FillTableTree(ByRef tvtables As TreeView)
        tvtables.Nodes.Clear()
        tvtables.Nodes.Add("Tables")
        For Each oTable As String In tableList
            If Not oTable.Equals("Files") Then
                tvtables.Nodes(0).Nodes.Add(TABLE_TAG & oTable, oTable)
            End If
        Next
    End Sub
    Public Sub BackupDataTable(backupDataTable As DataTable, datapath As String)
        Dim sTableName As String = backupDataTable.TableName
        Dim sDbFullPath As String = datapath
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        backupDataTable.WriteXml(sBackupFile, XmlWriteMode.WriteSchema)
    End Sub
    Public Function RestoreDataTable(tableType As String, datapath As String) As Integer
        Return RestoreDataTable(tableType, datapath, False)
    End Function
    Public Function RestoreDataTable(tableType As String, datapath As String, isSuppressMessage As Boolean) As Integer
        Dim rowCount As Integer = 0
        Try
            Select Case tableType
                Case "Projects"
                    If RecreateTable(oProjectTable, datapath, isSuppressMessage) Then
                        oProjectTa.TruncateProjects()
                        For Each _row As MyStitchDataSet.ProjectsRow In oProjectTable.Rows
                            Dim _project As Project = ProjectBuilder.AProject.StartingWith(_row).Build
                            InsertProject(_project, _project.ProjectId)
                        Next
                        'oprojectTa.RestoreAI()
                        rowCount = oProjectTa.GetData().Rows.Count
                    End If
                Case "Threads"
                    If RecreateTable(oThreadTable, datapath, isSuppressMessage) Then
                        oThreadTa.TruncateThreads()
                        For Each _row As MyStitchDataSet.ThreadsRow In oThreadTable.Rows
                            Dim _thread As Thread = ThreadBuilder.AThread.StartingWith(_row).Build
                            InsertThread(_thread, _thread.ThreadId)
                        Next
                        rowCount = oThreadTa.GetData().Rows.Count
                    End If
                Case "ProjectThreads"
                    If RecreateTable(oProjectThreadTable, datapath, isSuppressMessage) Then
                        oProjectThreadTa.TruncateProjectThreads()
                        For Each _row As MyStitchDataSet.ProjectThreadsRow In oProjectThreadTable.Rows
                            Dim _ProjectThread As ProjectThread = ProjectThreadBuilder.AProjectThread.StartingWith(_row).Build
                            InsertProjectThread(_ProjectThread)
                        Next
                        rowCount = oProjectThreadTa.GetData().Rows.Count
                    End If
                Case "ProjectThreadCards"
                    If RecreateTable(oProjectThreadCardTable, datapath, isSuppressMessage) Then
                        oProjectThreadCardTa.TruncateProjectThreadCards()
                        For Each _row As MyStitchDataSet.ProjectThreadCardsRow In oProjectThreadCardTable.Rows
                            Dim _ProjectThreadCard As ProjectThreadCard = ProjectThreadCardBuilder.AProjectThreadCard.StartingWith(_row).Build
                            InsertProjectThreadCard(_ProjectThreadCard)
                        Next
                        rowCount = oProjectThreadCardTa.GetData().Rows.Count
                    End If
                Case "ProjectCardThread"
                    If RecreateTable(oProjectCardThreadTable, datapath, isSuppressMessage) Then
                        oProjectCardThreadTa.TruncateProjectCardThread()
                        For Each _row As MyStitchDataSet.ProjectCardThreadRow In oProjectCardThreadTable.Rows
                            Dim _ProjectCardThread As ProjectCardThread = ProjectCardThreadBuilder.AProjectCardThread.StartingWith(_row).Build
                            InsertProjectCardThread(_ProjectCardThread)
                        Next
                        rowCount = oProjectCardThreadTa.GetData().Rows.Count
                    End If

            End Select
        Catch ex As Exception
            MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
        End Try
        Return rowCount
    End Function
    Private Function RecreateTable(ByRef restoredDataTable As DataTable, datapath As String) As Boolean
        Return RecreateTable(restoredDataTable, datapath, False)
    End Function
    Private Function RecreateTable(ByRef restoredDataTable As DataTable, datapath As String, isSuppressMessage As Boolean) As Boolean
        Dim isTableOK As Boolean = False
        Dim sTableName As String = restoredDataTable.TableName
        Dim sBackupFile As String = Path.Combine(datapath, sTableName & ".xml")
        If My.Computer.FileSystem.FileExists(sBackupFile) Then
            Try
                restoredDataTable.Clear()
                restoredDataTable.ReadXml(sBackupFile)
                Dim rowCount As Integer = restoredDataTable.Rows.Count
                If isSuppressMessage Then
                    isTableOK = True
                Else
                    If MsgBox(CStr(rowCount) & " records recovered. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Continue") = MsgBoxResult.Yes Then
                        isTableOK = True
                    End If
                End If
            Catch ex As Exception
                MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
        Return isTableOK
    End Function
    Private Function GetMessage(ex As Exception) As String
        Return If(ex Is Nothing, "", "Exception:  " & ex.Message & vbCrLf & If(ex.InnerException Is Nothing, "", ex.InnerException.Message))
    End Function
#End Region
#Region "projects"
    Public Function GetProjectTable() As MyStitchDataSet.ProjectsDataTable
        LogUtil.Info("Getting project table", MethodBase.GetCurrentMethod.Name)
        Return oProjectTa.GetData()
    End Function
    Public Function GetProjects() As List(Of Project)
        LogUtil.Debug("Getting all projects", MethodBase.GetCurrentMethod.Name)
        Dim oProjects As New List(Of Project)
        Try
            oProjectTa.Fill(oProjectTable)
            For Each orow As MyStitchDataSet.ProjectsRow In oProjectTable.Rows
                oProjects.Add(ProjectBuilder.AProject.StartingWith(orow).Build)
            Next
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return oProjects
    End Function
    Public Function GetProjectById(pProjectId As Integer) As Project
        Dim oProject As New Project
        Try
            oProjectTa.FillById(oProjectTable, pProjectId)
            If oProjectTable.Rows.Count > 0 Then
                Dim oRow As MyStitchDataSet.ProjectsRow = oProjectTable.Rows(0)
                oProject = ProjectBuilder.AProject.StartingWith(oRow).Build
            End If
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return oProject
    End Function
    Public Function InsertProject(ByRef project As Project) As Integer
        Return InsertProject(project, -1)
    End Function
    Public Function InsertProject(ByRef oProject As Project, projectId As Integer)
        LogUtil.LogInfo("Inserting " & oProject.ProjectName, MethodBase.GetCurrentMethod.Name)
        Dim newId As Integer = -1
        Try
            With oProject
                If projectId < 0 Then
                    newId = oProjectTa.InsertProject(.ProjectName)
                Else
                    newId = oProjectTa.InsertProjectWithId(projectId, .ProjectName)
                End If
            End With
        Catch ex As SqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return newId
    End Function

    Public Sub UpdateProject(oProject As Project)
        LogUtil.Info("Updating " & oProject.ProjectName, MethodBase.GetCurrentMethod.Name)
        Try
            oProjectTa.UpdateProject(oProject.ProjectName, oProject.ProjectId)
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
    Public Sub DeleteProject(oProject As Project)
        LogUtil.Info("Deleting " & oProject.ProjectName, MethodBase.GetCurrentMethod.Name)
        Try
            oProjectTa.DeleteProject(oProject.ProjectId)
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
#End Region
#Region "threads"
    Public Function GetThreadTable() As MyStitchDataSet.ThreadsDataTable
        LogUtil.Info("Getting Thread table", MethodBase.GetCurrentMethod.Name)
        Return oThreadTa.GetData()
    End Function
    Public Function GetThreads() As List(Of Thread)
        LogUtil.Debug("Getting all Threads", MethodBase.GetCurrentMethod.Name)
        Dim oThreads As New List(Of Thread)
        Try
            oThreadTa.Fill(oThreadTable)
            For Each orow As MyStitchDataSet.ThreadsRow In oThreadTable.Rows
                oThreads.Add(ThreadBuilder.AThread.StartingWith(orow).Build)
            Next
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return oThreads
    End Function
    Public Function GetThreadbyNumber(pNumber As String) As Thread
        Dim oThread As New Thread
        Try
            oThreadTa.FillByNumber(oThreadTable, pNumber)
            If oThreadTable.Rows.Count > 0 Then
                Dim oRow As MyStitchDataSet.ThreadsRow = oThreadTable.Rows(0)
                oThread = ThreadBuilder.AThread.StartingWith(oRow).Build
            End If
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return oThread
    End Function
    Public Sub UpdateThread(oThread As Thread)
        LogUtil.Info("Updating " & oThread.ColourName, MethodBase.GetCurrentMethod.Name)
        Try
            With oThread
                oThreadTa.UpdateThread(.ThreadNo, .ColourName, .Colour.ToArgb, .ThreadId)
            End With

        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
    Public Sub DeleteThread(oThread As Thread)
        LogUtil.Info("Deleting " & oThread.ColourName, MethodBase.GetCurrentMethod.Name)
        Try
            oThreadTa.DeleteThread(oThread.ThreadId)
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Public Function GetThreadById(pThreadId As Integer) As Thread
        LogUtil.Debug("Get thread " & pThreadId, MethodBase.GetCurrentMethod.Name)
        Dim othread As New Thread
        Try
            oThreadTa.FillById(oThreadTable, pThreadId)
            If oThreadTable.Rows.Count > 0 Then
                Dim oRow As MyStitchDataSet.ThreadsRow = oThreadTable.Rows(0)
                othread = ThreadBuilder.AThread.StartingWith(oRow).Build
            End If
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return othread
    End Function
    Public Function InsertThread(ByRef thread As Thread) As Integer
        Return InsertThread(thread, -1)
    End Function
    Public Function InsertThread(ByRef oThread As Thread, threadId As Integer)
        LogUtil.LogInfo("Inserting thread " & oThread.ThreadNo, MethodBase.GetCurrentMethod.Name)
        Dim newId As Integer = -1
        Try
            With oThread
                If threadId < 0 Then
                    newId = oThreadTa.InsertThread(.ThreadNo, .ColourName, .Colour.ToArgb)
                Else
                    newId = oThreadTa.InsertThreadWithId(threadId, .ThreadNo, .ColourName, .Colour.ToArgb)
                End If
            End With
        Catch ex As SqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return newId
    End Function

#End Region
#Region "projectthreadcards"
    Public Sub DeleteProjectThread(pProjectThread As ProjectThread)
        LogUtil.Info("Deleting " & pProjectThread.Project.ProjectName & ":" & pProjectThread.Thread.ThreadNo, MethodBase.GetCurrentMethod.Name)
        Try
            oProjectThreadTa.DeleteProjectThreadByKey(pProjectThread.Project.ProjectId, pProjectThread.Thread.ThreadId)
        Catch ex As MySqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
    Public Function GetProjectThreadCardsTable() As MyStitchDataSet.ProjectThreadCardsDataTable
        LogUtil.Info("Getting project thread cards table", MethodBase.GetCurrentMethod.Name)
        Return oProjectThreadCardTa.GetData()
    End Function
    Public Function GetProjectThreadCards(pProjectId) As List(Of ProjectThreadCard)
        Dim _listOfCards As New List(Of ProjectThreadCard)
        Try
            oProjectThreadCardTa.FillByProject(oProjectThreadCardTable, pProjectId)
            For Each oRow As MyStitchDataSet.ProjectThreadCardsRow In oProjectThreadCardTable.Rows
                _listOfCards.Add(ProjectThreadCardBuilder.AProjectThreadCard.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return _listOfCards
    End Function
    Public Function InsertProjectThreadCard(ByRef oThreadCard As ProjectThreadCard) As Integer
        LogUtil.LogInfo("Inserting thread card " & oThreadCard.Project.ProjectName & ":" & CStr(oThreadCard.CardNo), MethodBase.GetCurrentMethod.Name)
        Dim newId As Integer = -1
        Try
            With oThreadCard
                newId = oProjectThreadCardTa.InsertProjectThreadCard(.Project.ProjectId, .CardNo)
            End With
        Catch ex As SqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return newId
    End Function
    Public Function GetThreadCardThreads(pProjectId As Integer, pCardNo As Integer) As List(Of ProjectThread)
        Dim _listOfThreads As New List(Of ProjectThread)
        Try
            oProjectThreadTa.FillByProjectCard(oProjectThreadTable, pProjectId, pCardNo)
            For Each oRow As MyStitchDataSet.ProjectThreadsRow In oProjectThreadTable.Rows
                _listOfThreads.Add(ProjectThreadBuilder.AProjectThread.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return _listOfThreads
    End Function
    Public Sub RemoveExistingProjectCards(pProjectId As Integer)
        Try
            oProjectThreadTa.ResetCardsForProject(pProjectId)
            oProjectThreadCardTa.DeleteCardsByProject(pProjectId)
            oProjectCardThreadTa.DeleteCardThreadsForProject(pProjectId)
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

#End Region
#Region "projectthreads"
    Public Function GetProjectThreadsTable() As MyStitchDataSet.ProjectThreadsDataTable
        LogUtil.Info("Getting project threads table", MethodBase.GetCurrentMethod.Name)
        Return oProjectThreadTa.GetData()
    End Function
    Public Function InsertProjectThread(ByRef oProjectThread As ProjectThread)
        LogUtil.LogInfo("Inserting project thread" & oProjectThread.Project.ProjectName & ":" & CStr(oProjectThread.Thread.ThreadId), MethodBase.GetCurrentMethod.Name)
        Dim newId As Integer = -1
        Try
            With oProjectThread
                newId = oProjectThreadTa.InsertProjectThread(.Project.ProjectId, .Thread.ThreadId, .CardNo, .CardSeq)
            End With
        Catch ex As SqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return newId
    End Function

    Public Function GetProjectThreads(pProjectId) As List(Of Thread)
        Dim _list As New List(Of Thread)
        Try
            oProjectThreadTa.FillByProject(oProjectThreadTable, pProjectId)
            For Each oRow As MyStitchDataSet.ProjectThreadsRow In oProjectThreadTable.Rows
                _list.Add(GetThreadById(oRow.thread_id))
            Next
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)

        End Try

        Return _list

    End Function

    Public Function GetProjectThread(pProjectId As Integer, pThreadId As Integer) As ProjectThread
        Dim _projectThread As New ProjectThread
        Try
            oProjectThreadTa.FillByKey(oProjectThreadTable, pProjectId, pThreadId)
            If oProjectThreadTable.Rows.Count = 1 Then
                _projectThread = ProjectThreadBuilder.AProjectThread.StartingWith(oProjectThreadTable.Rows(0)).Build
            End If
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return _projectThread
    End Function
    Public Function UpdateProjectThread(pProjectThread As ProjectThread) As Integer
        Dim _resp As Integer = 0
        Try
            With pProjectThread
                _resp = oProjectThreadTa.UpdateProjectThread(.CardNo, .CardSeq, .Project.ProjectId, .Thread.ThreadId)
            End With
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return _resp
    End Function

    Public Function DeleteProjectThreadsForProject(pProjectId As Integer)
        Dim response As Integer
        Try
            oProjectThreadTa.DeleteProjectThreadsByProject(pProjectId)
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
#End Region
#Region "projectcardthreads"
    Public Function GetProjectThreadCardThreadTable() As MyStitchDataSet.ProjectCardThreadDataTable
        LogUtil.Info("Getting project card thread table", MethodBase.GetCurrentMethod.Name)
        Return oProjectCardThreadTa.GetData()
    End Function
    Public Function InsertProjectCardThread(ByRef oProjectCardThread As ProjectCardThread)
        LogUtil.LogInfo("Inserting project card thread" & oProjectCardThread.Project.ProjectName & ":" & CStr(oProjectCardThread.Thread.ThreadId), MethodBase.GetCurrentMethod.Name)
        Dim _resp As Integer
        Try
            With oProjectCardThread
                _resp = oProjectCardThreadTa.InsertProjectCardThread(.Project.ProjectId, .Thread.ThreadId, .CardNo, .CardSeq)
            End With
        Catch ex As SqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return _resp
    End Function
    Public Function InsertProjectCardThread(ByRef oProjectThread As ProjectThread)
        LogUtil.LogInfo("Inserting project card thread", MethodBase.GetCurrentMethod.Name)
        Dim _resp As Integer
        Try
            With oProjectThread
                _resp = oProjectCardThreadTa.InsertProjectCardThread(.Project.ProjectId, .Thread.ThreadId, .CardNo, .CardSeq)
            End With
        Catch ex As SqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return _resp
    End Function
    Public Function DeleteProjectCardThread(pProjectCardThread As ProjectCardThread)
        Dim response As Integer
        Try
            With pProjectCardThread
                oProjectCardThreadTa.DeleteProjectCardThread(.Project.ProjectId, .Thread.ThreadId, .CardNo, .CardSeq)
            End With
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
    Public Function DeleteThreadsForProjectCard(pProjectId As Integer, pCardNo As Integer)
        Dim response As Integer
        Try
            oProjectCardThreadTa.DeleteThreadsForProjectCard(pProjectId, pCardNo)
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
    Public Function GetProjectCardThreadsByProjectCard(pProjectId As Integer, pCardNo As Integer) As List(Of ProjectCardThread)
        Dim _list As New List(Of ProjectCardThread)
        Try
            oProjectCardThreadTa.FillByProjectCard(oProjectCardThreadTable, pProjectId, pCardNo)
            For Each oRow As MyStitchDataSet.ProjectCardThreadRow In oProjectCardThreadTable.Rows
                Dim _cardThread As ProjectCardThread = ProjectCardThreadBuilder.AProjectCardThread.StartingWith(oRow).Build
                _list.Add(_cardThread)
            Next
        Catch ex As Exception
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return _list
    End Function
#End Region
End Module
