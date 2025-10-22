' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Printing

Module ModPrint
#Region "constants"
    Public Const PRINT_DPI As Integer = 300.0F
    '   Public Const FONT_POINTS_PER_INCH As Integer = 72
    Public Const A4_WIDTH As Integer = 2480
    Public Const A4_HEIGHT As Integer = 3508
#End Region
#Region "variables"
    Friend oPrinterHardMarginX As Integer
    Friend oPrinterHardMarginY As Integer
    Friend oPrintDoc As New Printing.PrintDocument
    Friend oPageSettings As PageSettings
    Friend oLeftMargin As Integer
    Friend oRightMargin As Integer
    Friend oTopMargin As Integer
    Friend oBottomMargin As Integer
    Friend oFormLeftMargin As Integer
    Friend oFormRightMargin As Integer
    Friend oFormTopMargin As Integer
    Friend oFormBottomMargin As Integer
    Friend oFormTitleHeight As Integer
    Friend oFormFooterHeight As Integer
    Friend oPageTitleHeight As Integer
    Friend oPageFooterHeight As Integer
    Friend oPageLeftMargin As Integer
    Friend oPageRightMargin As Integer
    Friend oPageTopMargin As Integer
    Friend oPageBottomMargin As Integer
    Friend oAvailableGridWidth As Integer
    Friend oAvailableGridHeight As Integer
    Friend oAvailablePixelWidth As Integer
    Friend oAvailablePixelHeight As Integer
    Friend oAvailableCellsWidth As Integer
    Friend oAvailableCellsHeight As Integer
    Friend oOnePageSqPerInch As Integer
    Friend oTitleHeight As Integer
    Friend oFooterHeight As Integer
    Friend oPrintGridOrigin As Point
    Friend oPageToFormRatio As Decimal
    Friend oTitlefont As Font
    Friend oTextfont As Font
    Friend oFooterfont As Font
    Friend oPrintTitlefont As Font
    Friend oPrintTextfont As Font
    Friend oPrintFooterfont As Font
    Friend oFormTitleFont As Font
    Friend oFormTextFont As Font
    Friend oFormFooterFont As Font
    Friend oPagePixelsPerCell As Decimal
    Friend oPrintPixelsPerCell As Decimal
    Friend oFormPixelsPerCell As Decimal
    Friend isPrintHeader As Boolean
    Friend isPrintFooter As Boolean
    Friend oGraphicsUnit As GraphicsUnit
#End Region
#Region "subroutines"
    Friend Sub SetPrintPageMargins(pLeftMargin As Single, pRightMargin As Single, pTopMargin As Single, pBottomMargin As Single)
        ' Set print margins in dots
        oPageTitleHeight = If(isPrintHeader, oPrintTitlefont.Height, 0)
        oPageFooterHeight = If(isPrintFooter, oPrintFooterfont.Height, 0)
        oPageLeftMargin = Math.Max(pLeftMargin * PRINT_DPI, oPrinterHardMarginX)
        oPageRightMargin = Math.Max(pRightMargin * PRINT_DPI, oPrinterHardMarginX)
        oPageTopMargin = Math.Max(pTopMargin * PRINT_DPI, oPrinterHardMarginY)
        oPageBottomMargin = Math.Max(pBottomMargin * PRINT_DPI, oPrinterHardMarginY)
    End Sub

    Friend Sub CalculatePrintGridSpace(pCellsPerInch As Integer, pPixelsPerCell As Integer, pDesignSize As Size)
        oAvailablePixelWidth = A4_WIDTH - oPageLeftMargin - oPageRightMargin
        oAvailablePixelHeight = A4_HEIGHT - oPageTopMargin - oPageBottomMargin - oPageTitleHeight - oPageFooterHeight
        iPixelsPerCell = PRINT_DPI / pCellsPerInch
        oAvailableCellsWidth = oAvailablePixelWidth / pPixelsPerCell
        oAvailableCellsHeight = oAvailablePixelHeight / pPixelsPerCell
        oPrintGridOrigin = New Point(oPageLeftMargin, oPageTopMargin + oPageTitleHeight)
        Dim dotspercell_w As Integer = Math.Floor(oAvailablePixelWidth / pDesignSize.Width)
        Dim dotspercell_h As Integer = Math.Floor(oAvailablePixelHeight / pDesignSize.Height)
        oOnePageSqPerInch = Math.Ceiling(PRINT_DPI / Math.Min(dotspercell_w, dotspercell_h))
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
        oPrintDoc.DefaultPageSettings.Landscape = False
        oPrintDoc.DefaultPageSettings.Margins.Left = 0
        oPrintDoc.DefaultPageSettings.Margins.Right = 0
        oPrintDoc.DefaultPageSettings.Margins.Top = 0
        oPrintDoc.DefaultPageSettings.Margins.Bottom = 0
    End Sub
#End Region
End Module
