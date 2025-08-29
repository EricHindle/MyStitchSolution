' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintProject
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintProject))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnlPageImage = New System.Windows.Forms.Panel()
        Me.PicDesign = New System.Windows.Forms.PictureBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblPageCt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NudSqrPerInch = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbPrintStitchDisplay = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudBlankBorder = New System.Windows.Forms.NumericUpDown()
        Me.ChkBlankBorder = New System.Windows.Forms.CheckBox()
        Me.ChkCentreLines = New System.Windows.Forms.CheckBox()
        Me.ChkPrintGrid = New System.Windows.Forms.CheckBox()
        Me.ChkKeySeparate = New System.Windows.Forms.CheckBox()
        Me.CbKeyOrder = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkPrintKey = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CbAbbrKey = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NudOverlap = New System.Windows.Forms.NumericUpDown()
        Me.CbShading = New System.Windows.Forms.ComboBox()
        Me.ChkShowPageOrder = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.NudLeftMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudRightMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudBottomMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudTopMargin = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.NudCentreLines = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.NudBackstitchLines = New System.Windows.Forms.NumericUpDown()
        Me.NudGrid10Lines = New System.Windows.Forms.NumericUpDown()
        Me.NudGrid1Lines = New System.Windows.Forms.NumericUpDown()
        Me.NudGrid5Lines = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtCopyright = New System.Windows.Forms.TextBox()
        Me.TxtDesignBy = New System.Windows.Forms.TextBox()
        Me.ChkTitleAboveKey = New System.Windows.Forms.CheckBox()
        Me.ChkTitleAboveGrid = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.BtnSaveSettings = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.PnlPageImage.SuspendLayout()
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBlankBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NudCentreLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBackstitchLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGrid10Lines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGrid1Lines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGrid5Lines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 628)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(959, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'PnlPageImage
        '
        Me.PnlPageImage.Controls.Add(Me.PicDesign)
        Me.PnlPageImage.Location = New System.Drawing.Point(536, 6)
        Me.PnlPageImage.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlPageImage.Name = "PnlPageImage"
        Me.PnlPageImage.Size = New System.Drawing.Size(410, 562)
        Me.PnlPageImage.TabIndex = 5
        '
        'PicDesign
        '
        Me.PicDesign.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicDesign.BackColor = System.Drawing.Color.White
        Me.PicDesign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicDesign.Location = New System.Drawing.Point(4, 4)
        Me.PicDesign.Margin = New System.Windows.Forms.Padding(4)
        Me.PicDesign.Name = "PicDesign"
        Me.PicDesign.Size = New System.Drawing.Size(402, 553)
        Me.PicDesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicDesign.TabIndex = 0
        Me.PicDesign.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPrint.Location = New System.Drawing.Point(740, 577)
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(77, 46)
        Me.BtnPrint.TabIndex = 7
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(865, 577)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(77, 46)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblPageCt)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.NudSqrPerInch)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CbPrintStitchDisplay)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NudBlankBorder)
        Me.GroupBox1.Controls.Add(Me.ChkBlankBorder)
        Me.GroupBox1.Controls.Add(Me.ChkCentreLines)
        Me.GroupBox1.Controls.Add(Me.ChkPrintGrid)
        Me.GroupBox1.Controls.Add(Me.ChkKeySeparate)
        Me.GroupBox1.Controls.Add(Me.CbKeyOrder)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ChkPrintKey)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(299, 400)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'LblPageCt
        '
        Me.LblPageCt.AutoSize = True
        Me.LblPageCt.Location = New System.Drawing.Point(149, 343)
        Me.LblPageCt.Name = "LblPageCt"
        Me.LblPageCt.Size = New System.Drawing.Size(16, 17)
        Me.LblPageCt.TabIndex = 16
        Me.LblPageCt.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 343)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Number of pages:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(113, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "(fit to one page: nn)"
        '
        'NudSqrPerInch
        '
        Me.NudSqrPerInch.Location = New System.Drawing.Point(116, 273)
        Me.NudSqrPerInch.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudSqrPerInch.Name = "NudSqrPerInch"
        Me.NudSqrPerInch.Size = New System.Drawing.Size(62, 24)
        Me.NudSqrPerInch.TabIndex = 6
        Me.NudSqrPerInch.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(184, 275)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "squares per inch"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 275)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Printout Size"
        '
        'CbPrintStitchDisplay
        '
        Me.CbPrintStitchDisplay.FormattingEnabled = True
        Me.CbPrintStitchDisplay.Items.AddRange(New Object() {"Crosses", "Blocks", "Coloured Symbols", "Strokes", "Black/White Symbols", "Blocks With Symbols"})
        Me.CbPrintStitchDisplay.Location = New System.Drawing.Point(152, 236)
        Me.CbPrintStitchDisplay.Name = "CbPrintStitchDisplay"
        Me.CbPrintStitchDisplay.Size = New System.Drawing.Size(121, 24)
        Me.CbPrintStitchDisplay.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Printout Stitch Display"
        '
        'NudBlankBorder
        '
        Me.NudBlankBorder.Location = New System.Drawing.Point(211, 193)
        Me.NudBlankBorder.Name = "NudBlankBorder"
        Me.NudBlankBorder.Size = New System.Drawing.Size(62, 24)
        Me.NudBlankBorder.TabIndex = 4
        '
        'ChkBlankBorder
        '
        Me.ChkBlankBorder.AutoSize = True
        Me.ChkBlankBorder.Location = New System.Drawing.Point(7, 194)
        Me.ChkBlankBorder.Name = "ChkBlankBorder"
        Me.ChkBlankBorder.Size = New System.Drawing.Size(198, 21)
        Me.ChkBlankBorder.TabIndex = 7
        Me.ChkBlankBorder.Text = "Blank Border Around Design"
        Me.ChkBlankBorder.UseVisualStyleBackColor = True
        '
        'ChkCentreLines
        '
        Me.ChkCentreLines.AutoSize = True
        Me.ChkCentreLines.Location = New System.Drawing.Point(7, 141)
        Me.ChkCentreLines.Name = "ChkCentreLines"
        Me.ChkCentreLines.Size = New System.Drawing.Size(134, 21)
        Me.ChkCentreLines.TabIndex = 3
        Me.ChkCentreLines.Text = "Print Centre Lines"
        Me.ChkCentreLines.UseVisualStyleBackColor = True
        '
        'ChkPrintGrid
        '
        Me.ChkPrintGrid.AutoSize = True
        Me.ChkPrintGrid.Location = New System.Drawing.Point(7, 113)
        Me.ChkPrintGrid.Name = "ChkPrintGrid"
        Me.ChkPrintGrid.Size = New System.Drawing.Size(83, 21)
        Me.ChkPrintGrid.TabIndex = 2
        Me.ChkPrintGrid.Text = "Print Grid"
        Me.ChkPrintGrid.UseVisualStyleBackColor = True
        '
        'ChkKeySeparate
        '
        Me.ChkKeySeparate.AutoSize = True
        Me.ChkKeySeparate.Location = New System.Drawing.Point(7, 75)
        Me.ChkKeySeparate.Name = "ChkKeySeparate"
        Me.ChkKeySeparate.Size = New System.Drawing.Size(160, 21)
        Me.ChkKeySeparate.TabIndex = 1
        Me.ChkKeySeparate.Text = "Key on separate page"
        Me.ChkKeySeparate.UseVisualStyleBackColor = True
        '
        'CbKeyOrder
        '
        Me.CbKeyOrder.FormattingEnabled = True
        Me.CbKeyOrder.Items.AddRange(New Object() {"<none>", "colour name", "DMC"})
        Me.CbKeyOrder.Location = New System.Drawing.Point(86, 44)
        Me.CbKeyOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.CbKeyOrder.Name = "CbKeyOrder"
        Me.CbKeyOrder.Size = New System.Drawing.Size(140, 24)
        Me.CbKeyOrder.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Key order"
        '
        'ChkPrintKey
        '
        Me.ChkPrintKey.AutoSize = True
        Me.ChkPrintKey.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPrintKey.Location = New System.Drawing.Point(7, 23)
        Me.ChkPrintKey.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPrintKey.Name = "ChkPrintKey"
        Me.ChkPrintKey.Size = New System.Drawing.Size(82, 21)
        Me.ChkPrintKey.TabIndex = 0
        Me.ChkPrintKey.Text = "Print Key"
        Me.ChkPrintKey.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CbAbbrKey)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.NudOverlap)
        Me.GroupBox2.Controls.Add(Me.CbShading)
        Me.GroupBox2.Controls.Add(Me.ChkShowPageOrder)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(349, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 140)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tiling"
        '
        'CbAbbrKey
        '
        Me.CbAbbrKey.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbAbbrKey.FormattingEnabled = True
        Me.CbAbbrKey.Items.AddRange(New Object() {"<none>", "colour name", "DMC"})
        Me.CbAbbrKey.Location = New System.Drawing.Point(47, 107)
        Me.CbAbbrKey.Name = "CbAbbrKey"
        Me.CbAbbrKey.Size = New System.Drawing.Size(79, 21)
        Me.CbAbbrKey.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(167, 13)
        Me.Label9.TabIndex = 149
        Me.Label9.Text = "Abbreviated key on design pages"
        '
        'NudOverlap
        '
        Me.NudOverlap.Location = New System.Drawing.Point(98, 14)
        Me.NudOverlap.Name = "NudOverlap"
        Me.NudOverlap.Size = New System.Drawing.Size(62, 20)
        Me.NudOverlap.TabIndex = 0
        '
        'CbShading
        '
        Me.CbShading.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbShading.FormattingEnabled = True
        Me.CbShading.Items.AddRange(New Object() {"Light Grey", "Mid Grey", "Dark Gray"})
        Me.CbShading.Location = New System.Drawing.Point(81, 40)
        Me.CbShading.Name = "CbShading"
        Me.CbShading.Size = New System.Drawing.Size(79, 22)
        Me.CbShading.TabIndex = 1
        '
        'ChkShowPageOrder
        '
        Me.ChkShowPageOrder.AutoSize = True
        Me.ChkShowPageOrder.Location = New System.Drawing.Point(6, 65)
        Me.ChkShowPageOrder.Name = "ChkShowPageOrder"
        Me.ChkShowPageOrder.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkShowPageOrder.Size = New System.Drawing.Size(110, 17)
        Me.ChkShowPageOrder.TabIndex = 2
        Me.ChkShowPageOrder.Text = "Show Page Order"
        Me.ChkShowPageOrder.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Shading"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Overlap"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.NudLeftMargin)
        Me.GroupBox3.Controls.Add(Me.NudRightMargin)
        Me.GroupBox3.Controls.Add(Me.NudBottomMargin)
        Me.GroupBox3.Controls.Add(Me.NudTopMargin)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(349, 158)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 128)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Margins"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(41, 105)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 153
        Me.Label14.Text = "Measurements in mm"
        '
        'NudLeftMargin
        '
        Me.NudLeftMargin.Location = New System.Drawing.Point(38, 32)
        Me.NudLeftMargin.Name = "NudLeftMargin"
        Me.NudLeftMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudLeftMargin.TabIndex = 0
        '
        'NudRightMargin
        '
        Me.NudRightMargin.Location = New System.Drawing.Point(38, 75)
        Me.NudRightMargin.Name = "NudRightMargin"
        Me.NudRightMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudRightMargin.TabIndex = 2
        '
        'NudBottomMargin
        '
        Me.NudBottomMargin.Location = New System.Drawing.Point(100, 75)
        Me.NudBottomMargin.Name = "NudBottomMargin"
        Me.NudBottomMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudBottomMargin.TabIndex = 3
        '
        'NudTopMargin
        '
        Me.NudTopMargin.Location = New System.Drawing.Point(100, 32)
        Me.NudTopMargin.Name = "NudTopMargin"
        Me.NudTopMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudTopMargin.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(46, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Right"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(104, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Bottom"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(49, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Left"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(112, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Top"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.NudCentreLines)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.NudBackstitchLines)
        Me.GroupBox4.Controls.Add(Me.NudGrid10Lines)
        Me.GroupBox4.Controls.Add(Me.NudGrid1Lines)
        Me.GroupBox4.Controls.Add(Me.NudGrid5Lines)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(346, 297)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(180, 158)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Line Thickness"
        '
        'NudCentreLines
        '
        Me.NudCentreLines.Location = New System.Drawing.Point(115, 127)
        Me.NudCentreLines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCentreLines.Name = "NudCentreLines"
        Me.NudCentreLines.Size = New System.Drawing.Size(48, 20)
        Me.NudCentreLines.TabIndex = 4
        Me.NudCentreLines.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(22, 129)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 13)
        Me.Label22.TabIndex = 159
        Me.Label22.Text = "Centre lines"
        '
        'NudBackstitchLines
        '
        Me.NudBackstitchLines.Location = New System.Drawing.Point(115, 100)
        Me.NudBackstitchLines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudBackstitchLines.Name = "NudBackstitchLines"
        Me.NudBackstitchLines.Size = New System.Drawing.Size(48, 20)
        Me.NudBackstitchLines.TabIndex = 3
        Me.NudBackstitchLines.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudGrid10Lines
        '
        Me.NudGrid10Lines.Location = New System.Drawing.Point(115, 73)
        Me.NudGrid10Lines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudGrid10Lines.Name = "NudGrid10Lines"
        Me.NudGrid10Lines.Size = New System.Drawing.Size(48, 20)
        Me.NudGrid10Lines.TabIndex = 2
        Me.NudGrid10Lines.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudGrid1Lines
        '
        Me.NudGrid1Lines.Location = New System.Drawing.Point(115, 19)
        Me.NudGrid1Lines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudGrid1Lines.Name = "NudGrid1Lines"
        Me.NudGrid1Lines.Size = New System.Drawing.Size(48, 20)
        Me.NudGrid1Lines.TabIndex = 0
        Me.NudGrid1Lines.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudGrid5Lines
        '
        Me.NudGrid5Lines.Location = New System.Drawing.Point(115, 46)
        Me.NudGrid5Lines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudGrid5Lines.Name = "NudGrid5Lines"
        Me.NudGrid5Lines.Size = New System.Drawing.Size(48, 20)
        Me.NudGrid5Lines.TabIndex = 1
        Me.NudGrid5Lines.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(22, 102)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 154
        Me.Label18.Text = "Backstitch lines"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(22, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 153
        Me.Label15.Text = "Grid 10 lines"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(22, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 152
        Me.Label16.Text = "Grid 5 lines"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(22, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 13)
        Me.Label17.TabIndex = 151
        Me.Label17.Text = "Grid 1 lines"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.TxtCopyright)
        Me.GroupBox5.Controls.Add(Me.TxtDesignBy)
        Me.GroupBox5.Controls.Add(Me.ChkTitleAboveKey)
        Me.GroupBox5.Controls.Add(Me.ChkTitleAboveGrid)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.TxtTitle)
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(346, 461)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(180, 162)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Design Information"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 137)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Copyright"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 105)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Design By"
        '
        'TxtCopyright
        '
        Me.TxtCopyright.Location = New System.Drawing.Point(74, 134)
        Me.TxtCopyright.Name = "TxtCopyright"
        Me.TxtCopyright.Size = New System.Drawing.Size(100, 20)
        Me.TxtCopyright.TabIndex = 4
        '
        'TxtDesignBy
        '
        Me.TxtDesignBy.Location = New System.Drawing.Point(74, 102)
        Me.TxtDesignBy.Name = "TxtDesignBy"
        Me.TxtDesignBy.Size = New System.Drawing.Size(100, 20)
        Me.TxtDesignBy.TabIndex = 3
        '
        'ChkTitleAboveKey
        '
        Me.ChkTitleAboveKey.AutoSize = True
        Me.ChkTitleAboveKey.Location = New System.Drawing.Point(18, 70)
        Me.ChkTitleAboveKey.Name = "ChkTitleAboveKey"
        Me.ChkTitleAboveKey.Size = New System.Drawing.Size(101, 17)
        Me.ChkTitleAboveKey.TabIndex = 2
        Me.ChkTitleAboveKey.Text = "Title Above Key"
        Me.ChkTitleAboveKey.UseVisualStyleBackColor = True
        '
        'ChkTitleAboveGrid
        '
        Me.ChkTitleAboveGrid.AutoSize = True
        Me.ChkTitleAboveGrid.Location = New System.Drawing.Point(18, 47)
        Me.ChkTitleAboveGrid.Name = "ChkTitleAboveGrid"
        Me.ChkTitleAboveGrid.Size = New System.Drawing.Size(102, 17)
        Me.ChkTitleAboveGrid.TabIndex = 1
        Me.ChkTitleAboveGrid.Text = "Title Above Grid"
        Me.ChkTitleAboveGrid.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Title"
        '
        'TxtTitle
        '
        Me.TxtTitle.Location = New System.Drawing.Point(74, 19)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(100, 20)
        Me.TxtTitle.TabIndex = 0
        '
        'BtnSaveSettings
        '
        Me.BtnSaveSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnSaveSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveSettings.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveSettings.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSaveSettings.Location = New System.Drawing.Point(612, 577)
        Me.BtnSaveSettings.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSaveSettings.Name = "BtnSaveSettings"
        Me.BtnSaveSettings.Size = New System.Drawing.Size(77, 46)
        Me.BtnSaveSettings.TabIndex = 6
        Me.BtnSaveSettings.Text = "Save Settings"
        Me.BtnSaveSettings.UseVisualStyleBackColor = False
        '
        'FrmPrintProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 650)
        Me.Controls.Add(Me.BtnSaveSettings)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.PnlPageImage)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPrintProject"
        Me.Text = "Print Project"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PnlPageImage.ResumeLayout(False)
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBlankBorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NudCentreLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBackstitchLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGrid10Lines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGrid1Lines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGrid5Lines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents PnlPageImage As Panel
    Friend WithEvents PicDesign As PictureBox
    Friend WithEvents BtnPrint As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ChkPrintKey As CheckBox
    Friend WithEvents ChkPrintGrid As CheckBox
    Friend WithEvents ChkKeySeparate As CheckBox
    Friend WithEvents CbKeyOrder As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NudBlankBorder As NumericUpDown
    Friend WithEvents ChkBlankBorder As CheckBox
    Friend WithEvents ChkCentreLines As CheckBox
    Friend WithEvents CbPrintStitchDisplay As ComboBox
    Friend WithEvents NudSqrPerInch As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblPageCt As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ChkShowPageOrder As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents NudOverlap As NumericUpDown
    Friend WithEvents CbShading As ComboBox
    Friend WithEvents CbAbbrKey As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents NudLeftMargin As NumericUpDown
    Friend WithEvents NudRightMargin As NumericUpDown
    Friend WithEvents NudBottomMargin As NumericUpDown
    Friend WithEvents NudTopMargin As NumericUpDown
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents NudBackstitchLines As NumericUpDown
    Friend WithEvents NudGrid10Lines As NumericUpDown
    Friend WithEvents NudGrid1Lines As NumericUpDown
    Friend WithEvents NudGrid5Lines As NumericUpDown
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents ChkTitleAboveKey As CheckBox
    Friend WithEvents ChkTitleAboveGrid As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtCopyright As TextBox
    Friend WithEvents TxtDesignBy As TextBox
    Friend WithEvents BtnSaveSettings As Button
    Friend WithEvents NudCentreLines As NumericUpDown
    Friend WithEvents Label22 As Label
End Class
