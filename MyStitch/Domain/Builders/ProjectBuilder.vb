' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports MyStitch.Domain.Objects

Namespace Domain.Builders
    Public Class ProjectBuilder
        Private _projectId As Integer
        Private _projectName As String
        Private _dateStarted As DateTime
        Private _dateEnded As DateTime
        Private _designWidth As Integer
        Private _designHeight As Integer
        Private _fabricWidth As Integer
        Private _fabricHeight As Integer
        Private _fabricColour As Integer
        Private _design As ProjectDesign
        Private _designFileName As String
        Private _originX As Integer
        Private _originY As Integer
        Private _totalMinutes As Integer
        Public Shared Function AProject() As ProjectBuilder
            Return New ProjectBuilder
        End Function
        Public Function StartingWithNothing() As ProjectBuilder
            _projectId = -1
            _projectName = String.Empty
            _dateStarted = MIN_DATE
            _dateEnded = MIN_DATE
            _designHeight = 1
            _designWidth = 1
            _fabricWidth = 1
            _fabricHeight = 1
            _fabricColour = 1
            _design = New ProjectDesign
            _designFileName = String.Empty
            _originX = 0
            _originY = 0
            _totalMinutes = 0
            Return Me
        End Function
        Public Function StartingWith(ByRef pProject As Project) As ProjectBuilder
            StartingWithNothing()
            If pProject IsNot Nothing Then
                With pProject
                    _projectId = .ProjectId
                    _projectName = .ProjectName
                    _dateStarted = .DateStarted
                    _dateEnded = .DateEnded
                    _designHeight = .DesignHeight
                    _designWidth = .DesignWidth
                    _fabricWidth = .FabricWidth
                    _fabricHeight = .FabricHeight
                    _fabricColour = .FabricColour
                    _design = .Design
                    _designFileName = .DesignFileName
                    _originX = .OriginX
                    _originY = .OriginY
                    _totalMinutes = .TotalMinutes
                End With
            End If
            Return Me
        End Function
        Public Function StartingWith(ByRef oRow As MyStitchDataSet.ProjectsRow) As ProjectBuilder
            StartingWithNothing()
            If oRow IsNot Nothing Then
                With oRow
                    _projectId = .project_id
                    _projectName = .project_name
                    _dateStarted = .date_started
                    _dateEnded = .date_ended
                    _designHeight = .design_height
                    _designWidth = .design_width
                    _fabricWidth = .fabric_width
                    _fabricHeight = .fabric_height
                    _fabricColour = .fabric_colour
                    _designFileName = .design_file
                    _originX = .origin_x
                    _originY = .origin_y
                    _totalMinutes = .total_minutes
                End With
            End If
            Return Me
        End Function
        Public Function WithId(pId As Integer) As ProjectBuilder
            _projectId = pId
            Return Me
        End Function
        Public Function WithName(pprojectname As String) As ProjectBuilder
            _projectName = pprojectname
            Return Me
        End Function
        Public Function WithStarted(pDateStarted As DateTime) As ProjectBuilder
            _dateStarted = pDateStarted
            Return Me
        End Function
        Public Function WithEnded(pDateEnded As DateTime) As ProjectBuilder
            _dateEnded = pDateEnded
            Return Me
        End Function
        Public Function WithDesignWidth(pDesignWidth As Integer) As ProjectBuilder
            _designWidth = pDesignWidth
            Return Me
        End Function
        Public Function WithDesignHeight(pDesignHeight As Integer) As ProjectBuilder
            _designHeight = pDesignHeight
            Return Me
        End Function
        Public Function WithFabricWidth(pFabricWidth As Integer) As ProjectBuilder
            _fabricWidth = pFabricWidth
            Return Me
        End Function
        Public Function WithFabricHeight(pFabricHeight As Integer) As ProjectBuilder
            _fabricHeight = pFabricHeight
            Return Me
        End Function
        Public Function WithFabricColour(pFabricColour As Integer) As ProjectBuilder
            _fabricColour = pFabricColour
            Return Me
        End Function
        Public Function WithDesign(pDesign As ProjectDesign) As ProjectBuilder
            _design = pDesign
            Return Me
        End Function
        Public Function WithDesignFilename(pFilename As String) As ProjectBuilder
            _designFileName = pFilename
            Return Me
        End Function
        Public Function WithOriginX(pOriginX As Integer) As ProjectBuilder
            _originX = pOriginX
            Return Me
        End Function
        Public Function WithOriginY(pOriginY As Integer) As ProjectBuilder
            _originY = pOriginY
            Return Me
        End Function
        Public Function WithOrigin(pOrigin As Point) As ProjectBuilder
            _originX = pOrigin.X
            _originY = pOrigin.Y
            Return Me
        End Function
        Public Function WithTotalMinutes(pTotalMinutes As Integer) As ProjectBuilder
            _totalMinutes = pTotalMinutes
            Return Me
        End Function
        Public Function Build() As Project
            Return New Project(_projectId,
                               _projectName,
                               _dateStarted,
                               _dateEnded,
                               _designWidth,
                               _designHeight,
                               _fabricWidth,
                               _fabricHeight,
                               _fabricColour,
                               _design,
                               _designFileName,
                               _originX,
                               _originY,
                               _totalMinutes)
        End Function

    End Class
End Namespace