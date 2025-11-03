' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects
Imports MyStitch.MyStitchDataSet
Namespace Domain.Builders
    Public Class ProjectWorkTimeBuilder
        Private _projectId As Integer
        Private _timeStarted As DateTime
        Private _timeEnded As DateTime
        Private _minutes As Integer
        Public Shared Function AProjectWorkTime() As ProjectWorkTimeBuilder
            Return New ProjectWorkTimeBuilder
        End Function
        Public Function StartingWithNothing() As ProjectWorkTimeBuilder
            _projectId = -1
            _timeStarted = MIN_DATE
            _timeEnded = MIN_DATE
            _minutes = 0
            Return Me
        End Function
        Public Function StartingWith(ByRef pProjectTime As ProjectWorkTime) As ProjectWorkTimeBuilder
            StartingWithNothing()
            If pProjectTime IsNot Nothing Then
                With pProjectTime
                    _projectId = .ProjectId
                    _timeStarted = .TimeStarted
                    _timeEnded = .TimeEnded
                    _minutes = .Minutes
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As ProjectWorkTimesRow) As ProjectWorkTimeBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _projectId = .project_id
                    _timeStarted = .start_date
                    _timeEnded = .end_date
                    _minutes = .minutes
                End With
            End If
            Return Me
        End Function
        Public Function WithProjectId(pId As Integer) As ProjectWorkTimeBuilder
            _projectId = pId
            Return Me
        End Function
        Public Function WithStarted(pTimeStarted As DateTime) As ProjectWorkTimeBuilder
            _timeStarted = pTimeStarted
            Return Me
        End Function
        Public Function WithEnded(ptimeEnded As DateTime) As ProjectWorkTimeBuilder
            _timeEnded = ptimeEnded
            Return Me
        End Function
        Public Function WithMinutes(pMinutes As Integer) As ProjectWorkTimeBuilder
            _minutes = pMinutes
            Return Me
        End Function
        Public Function Build() As ProjectWorkTime
            Return New ProjectWorkTime(_projectId,
                               _timeStarted,
                               _timeEnded,
                               _minutes)
        End Function

    End Class
End Namespace
