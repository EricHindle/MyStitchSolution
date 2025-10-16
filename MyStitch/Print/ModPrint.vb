' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Printing
Imports MyStitch.Domain.Objects

Module ModPrint
#Region "constants"
    Public Const DPI As Integer = 300.0F
    Public Const A4_WIDTH As Integer = 2480
    Public Const A4_HEIGHT As Integer = 3508
#End Region
#Region "variables"
    Friend prtProjectThreads As ProjectThreadCollection
    Friend oPrinterHardMarginX As Integer
    Friend oPrinterHardMarginY As Integer
    Friend oPrintDoc As New Printing.PrintDocument
    Friend oPageSettings As PageSettings
    Friend oLeftMargin As Integer
    Friend oRightMargin As Integer
    Friend oTopMargin As Integer
    Friend oBottomMargin As Integer
    Friend oAvailableGridWidth As Integer
    Friend oAvailableGridHeight As Integer
    Friend oAvailableCellsWidth As Integer
    Friend oAvailableCellsHeight As Integer
    Friend oGridOrigin As Point
    Friend oPageImage As Bitmap
    Friend oPageGraphics As Graphics
    Friend oPicBoxGraphics As Graphics
    Friend oPagePixelsPerCell As Decimal

#End Region
#Region "subroutines"
    Friend Sub CalculateMargins(pLeftMargin As Single, pRightMargin As Single, pTopMargin As Single, pBottomMargin As Single)
        oPrinterHardMarginX = oPageSettings.HardMarginX / 100 * DPI
        oPrinterHardMarginY = oPageSettings.HardMarginY / 100 * DPI
        Dim _leftmargin As Integer = pLeftMargin * DPI
        Dim _rightmargin As Integer = pRightMargin * DPI
        Dim _topmargin As Integer = pTopMargin * DPI
        Dim _bottommargin As Integer = pBottomMargin * DPI
        oLeftMargin = If(_leftmargin > oPrinterHardMarginX, _leftmargin - oPrinterHardMarginX, 0)
        oRightMargin = If(_rightmargin > oPrinterHardMarginX, _rightmargin - oPrinterHardMarginX, 0)
        oTopMargin = If(_topmargin > oPrinterHardMarginY, _topmargin - oPrinterHardMarginY, 0)
        oBottomMargin = If(_bottommargin > oPrinterHardMarginY, _bottommargin - oPrinterHardMarginY, 0)
    End Sub
    Friend Sub CalculateGridSpace(pCellsPerInch)
        oAvailableGridWidth = A4_WIDTH - oLeftMargin - oRightMargin - (2 * oPrinterHardMarginX)
        oAvailableGridHeight = A4_HEIGHT - oTopMargin - oBottomMargin - (2 * oPrinterHardMarginY)
        Dim _widthInches As Decimal = oAvailableGridWidth / DPI
        Dim _heightInches As Decimal = oAvailableGridHeight / DPI
        oAvailableCellsWidth = _widthInches * pCellsPerInch
        oAvailableCellsHeight = _heightInches * pCellsPerInch
        oGridOrigin = New Point(oLeftMargin, oTopMargin)
    End Sub
    Friend Sub InitialisePrintDocument()
        Dim _paperKind As PaperKind = PaperKind.A4
        oPrintDoc = New PrintDocument
        oPageSettings = oPrintDoc.DefaultPageSettings
        ' Set default paper size
        For Each ps As Printing.PaperSize In oPrintDoc.PrinterSettings.PaperSizes
            If ps.RawKind = _paperKind Then
                oPrintDoc.DefaultPageSettings.PaperSize = ps
                Exit For
            End If
        Next
        ' Set default page settings
        oPrintDoc.DefaultPageSettings.Landscape = True
        oPrintDoc.DefaultPageSettings.Margins.Left = 0
        oPrintDoc.DefaultPageSettings.Margins.Right = 0
        oPrintDoc.DefaultPageSettings.Margins.Top = 0
        oPrintDoc.DefaultPageSettings.Margins.Bottom = 0
    End Sub
#End Region
#Region "functions"

#End Region
End Module
