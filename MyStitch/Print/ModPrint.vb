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
    Public Const FONT_PPI As Integer = 72.0F
    Public Const A4_WIDTH As Integer = 2480
    Public Const A4_HEIGHT As Integer = 3508
#End Region
#Region "variables"
    Friend oPagesize As Size
    Friend isLandscape As Boolean
    Friend oWidthHeightDifference As Integer
    Friend oPrinterHardMarginX As Integer
    Friend oPrinterHardMarginY As Integer
    Friend oPrintablePageWidth As Integer
    Friend oPrintablePageHeight As Integer
    Friend oPrintDoc As New Printing.PrintDocument
    Friend oPageSettings As PageSettings
    Friend oLeftMargin As Integer                   ' Page adjusted left margin
    Friend oRightMargin As Integer                  ' Page adjusted right margin
    Friend oTopMargin As Integer                    ' Page adjusted top margin
    Friend oBottomMargin As Integer                 ' Page adjusted bottom margin
    Friend oPageTitleHeight As Integer
    Friend oPageTextHeight As Integer
    Friend oPageFooterHeight As Integer
    Friend oPageLeftMargin As Integer               ' Page minimum left margin
    Friend oPageRightMargin As Integer              ' Page minimum right margin
    Friend oPageTopMargin As Integer                ' Page minimum top margin
    Friend oPageBottomMargin As Integer             ' Page minimum bottom margin
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
    Friend oPagePixelsPerCell As Integer
    Friend isPrintHeader As Boolean
    Friend isPrintFooter As Boolean
    Friend isPrintRowNumbers As Boolean
    Friend isPrintColumnNumbers As Boolean
#End Region
#Region "subroutines"
    Friend Sub SetPrintPageMargins(pLeftMargin As Single, pRightMargin As Single, pTopMargin As Single, pBottomMargin As Single)
        ' Set print margins in dots
        oPageTitleHeight = If(isPrintHeader, (oPrintTitlefont.Size * PRINT_DPI) / FONT_PPI, 0) + 20
        oPageTextHeight = (oPrintTextfont.Size * PRINT_DPI) / FONT_PPI
        oPageFooterHeight = If(isPrintFooter, (oPrintFooterfont.Size * PRINT_DPI) / FONT_PPI, 0) + 20
        oPageLeftMargin = Math.Max((pLeftMargin * PRINT_DPI) - oPrinterHardMarginX, 0)
        oPageRightMargin = Math.Max((pRightMargin * PRINT_DPI) - oPrinterHardMarginX, 0)
        oPageTopMargin = Math.Max((pTopMargin * PRINT_DPI) - oPrinterHardMarginY, 0)
        oPageBottomMargin = Math.Max((pBottomMargin * PRINT_DPI) - oPrinterHardMarginY, 0)
        oLeftMargin = oPageLeftMargin
        oRightMargin = oPageRightMargin
        If isPrintRowNumbers Then
            oRightMargin += oPageFooterHeight
        End If
        oTopMargin = oPageTopMargin + oPageTitleHeight
        oBottomMargin = oPageBottomMargin + oPageFooterHeight
        If isPrintColumnNumbers Then
            oBottomMargin += oPageFooterHeight
        End If
        oTitleHeight = oPageTitleHeight
        oFooterHeight = oPageFooterHeight
    End Sub
    Friend Sub CalculatePrintGridSpace(pDesignSize As Size)
        oAvailablePixelWidth = oPrintablePageWidth - oLeftMargin - oRightMargin
        oAvailablePixelHeight = oPrintablePageHeight - oTopMargin - oBottomMargin
        oAvailableCellsWidth = oAvailablePixelWidth / oPagePixelsPerCell
        oAvailableCellsHeight = oAvailablePixelHeight / oPagePixelsPerCell
        oPrintGridOrigin = New Point(oPageLeftMargin, oPageTopMargin + oPageTitleHeight)
        Dim dotspercell_w As Integer = Math.Floor(oAvailablePixelWidth / pDesignSize.Width)
        Dim dotspercell_h As Integer = Math.Floor(oAvailablePixelHeight / pDesignSize.Height)
        oOnePageSqPerInch = Math.Ceiling(PRINT_DPI / Math.Min(dotspercell_w, dotspercell_h))
    End Sub
    Friend Sub InitialisePrintDocument()
        Dim _paperKind As PaperKind = PaperKind.A4
        oPrintDoc = New PrintDocument
        ' Set default paper size
        For Each ps As Printing.PaperSize In oPrintDoc.PrinterSettings.PaperSizes
            If ps.RawKind = _paperKind Then
                oPrintDoc.DefaultPageSettings.PaperSize = ps
                Exit For
            End If
        Next
        oPageSettings = oPrintDoc.DefaultPageSettings
        ' Set default page settings
        oPrintDoc.DefaultPageSettings.Landscape = isLandscape
        oPrintDoc.DefaultPageSettings.Margins.Left = 0
        oPrintDoc.DefaultPageSettings.Margins.Right = 0
        oPrintDoc.DefaultPageSettings.Margins.Top = 0
        oPrintDoc.DefaultPageSettings.Margins.Bottom = 0
        oPrinterHardMarginX = oPageSettings.HardMarginX / 100 * PRINT_DPI
        oPrinterHardMarginY = oPageSettings.HardMarginY / 100 * PRINT_DPI
        oPrintablePageWidth = oPagesize.Width - (oPrinterHardMarginX * 2)
        oPrintablePageHeight = oPagesize.Height - (oPrinterHardMarginY * 2)
    End Sub
#End Region
End Module
