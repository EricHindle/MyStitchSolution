' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrintProject
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintProject))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PicDesign = New System.Windows.Forms.PictureBox()
        Me.BtnPrintPage = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CbDisplayStyle = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkCentreMarks = New System.Windows.Forms.CheckBox()
        Me.ChkPrintGrid = New System.Windows.Forms.CheckBox()
        Me.LblPageCt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblOnePage = New System.Windows.Forms.Label()
        Me.NudSqrPerInch = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.NudLeftMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudRightMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudBottomMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudTopMargin = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtCopyright = New System.Windows.Forms.TextBox()
        Me.TxtDesignBy = New System.Windows.Forms.TextBox()
        Me.ChkPrintFooter = New System.Windows.Forms.CheckBox()
        Me.ChkPrintHeader = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.BtnSaveSettings = New System.Windows.Forms.Button()
        Me.PnlDesignPicture = New System.Windows.Forms.Panel()
        Me.CmbInstalledPrinters = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnFooterFont = New System.Windows.Forms.Button()
        Me.BtnTextFont = New System.Windows.Forms.Button()
        Me.BtnTitleFont = New System.Windows.Forms.Button()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.BtnPrintAll = New System.Windows.Forms.Button()
        Me.ChkCentreLines = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.PnlDesignPicture.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 675)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(738, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(353, 23)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(376, 51)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(368, 22)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Page1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PicDesign
        '
        Me.PicDesign.BackColor = System.Drawing.Color.White
        Me.PicDesign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicDesign.Location = New System.Drawing.Point(3, 4)
        Me.PicDesign.Margin = New System.Windows.Forms.Padding(4)
        Me.PicDesign.Name = "PicDesign"
        Me.PicDesign.Size = New System.Drawing.Size(370, 523)
        Me.PicDesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicDesign.TabIndex = 0
        Me.PicDesign.TabStop = False
        '
        'BtnPrintPage
        '
        Me.BtnPrintPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrintPage.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnPrintPage.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnPrintPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrintPage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintPage.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPrintPage.Location = New System.Drawing.Point(378, 620)
        Me.BtnPrintPage.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnPrintPage.Name = "BtnPrintPage"
        Me.BtnPrintPage.Size = New System.Drawing.Size(77, 46)
        Me.BtnPrintPage.TabIndex = 7
        Me.BtnPrintPage.Text = "Print Page"
        Me.BtnPrintPage.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(647, 620)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(77, 46)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkCentreLines)
        Me.GroupBox1.Controls.Add(Me.CbDisplayStyle)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ChkCentreMarks)
        Me.GroupBox1.Controls.Add(Me.ChkPrintGrid)
        Me.GroupBox1.Controls.Add(Me.LblPageCt)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblOnePage)
        Me.GroupBox1.Controls.Add(Me.NudSqrPerInch)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkKeySeparate)
        Me.GroupBox1.Controls.Add(Me.CbKeyOrder)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ChkPrintKey)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(299, 248)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'CbDisplayStyle
        '
        Me.CbDisplayStyle.FormattingEnabled = True
        Me.CbDisplayStyle.Items.AddRange(New Object() {"Black/White Symbols", "Coloured Symbols", "Blocks With Symbols"})
        Me.CbDisplayStyle.Location = New System.Drawing.Point(97, 219)
        Me.CbDisplayStyle.Name = "CbDisplayStyle"
        Me.CbDisplayStyle.Size = New System.Drawing.Size(121, 22)
        Me.CbDisplayStyle.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 14)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "DisplayStyle"
        '
        'ChkCentreMarks
        '
        Me.ChkCentreMarks.AutoSize = True
        Me.ChkCentreMarks.Location = New System.Drawing.Point(7, 125)
        Me.ChkCentreMarks.Name = "ChkCentreMarks"
        Me.ChkCentreMarks.Size = New System.Drawing.Size(126, 18)
        Me.ChkCentreMarks.TabIndex = 18
        Me.ChkCentreMarks.Text = "Print Centre Marks"
        Me.ChkCentreMarks.UseVisualStyleBackColor = True
        '
        'ChkPrintGrid
        '
        Me.ChkPrintGrid.AutoSize = True
        Me.ChkPrintGrid.Location = New System.Drawing.Point(7, 101)
        Me.ChkPrintGrid.Name = "ChkPrintGrid"
        Me.ChkPrintGrid.Size = New System.Drawing.Size(72, 18)
        Me.ChkPrintGrid.TabIndex = 17
        Me.ChkPrintGrid.Text = "PrintGrid"
        Me.ChkPrintGrid.UseVisualStyleBackColor = True
        '
        'LblPageCt
        '
        Me.LblPageCt.AutoSize = True
        Me.LblPageCt.Location = New System.Drawing.Point(131, 196)
        Me.LblPageCt.Name = "LblPageCt"
        Me.LblPageCt.Size = New System.Drawing.Size(14, 14)
        Me.LblPageCt.TabIndex = 16
        Me.LblPageCt.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Number of pages:"
        '
        'LblOnePage
        '
        Me.LblOnePage.AutoSize = True
        Me.LblOnePage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOnePage.Location = New System.Drawing.Point(95, 177)
        Me.LblOnePage.Name = "LblOnePage"
        Me.LblOnePage.Size = New System.Drawing.Size(109, 13)
        Me.LblOnePage.TabIndex = 14
        Me.LblOnePage.Text = "(fit to one page: {0})"
        '
        'NudSqrPerInch
        '
        Me.NudSqrPerInch.Location = New System.Drawing.Point(98, 150)
        Me.NudSqrPerInch.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudSqrPerInch.Name = "NudSqrPerInch"
        Me.NudSqrPerInch.Size = New System.Drawing.Size(62, 22)
        Me.NudSqrPerInch.TabIndex = 6
        Me.NudSqrPerInch.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(166, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 14)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "squares per inch"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Printout Size"
        '
        'ChkKeySeparate
        '
        Me.ChkKeySeparate.AutoSize = True
        Me.ChkKeySeparate.Location = New System.Drawing.Point(7, 75)
        Me.ChkKeySeparate.Name = "ChkKeySeparate"
        Me.ChkKeySeparate.Size = New System.Drawing.Size(146, 18)
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
        Me.CbKeyOrder.Size = New System.Drawing.Size(140, 22)
        Me.CbKeyOrder.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Key order"
        '
        'ChkPrintKey
        '
        Me.ChkPrintKey.AutoSize = True
        Me.ChkPrintKey.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPrintKey.Location = New System.Drawing.Point(7, 23)
        Me.ChkPrintKey.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPrintKey.Name = "ChkPrintKey"
        Me.ChkPrintKey.Size = New System.Drawing.Size(75, 18)
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 267)
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
        Me.NudOverlap.Value = New Decimal(New Integer() {2, 0, 0, 0})
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
        Me.GroupBox3.Controls.Add(Me.NudLeftMargin)
        Me.GroupBox3.Controls.Add(Me.NudRightMargin)
        Me.GroupBox3.Controls.Add(Me.NudBottomMargin)
        Me.GroupBox3.Controls.Add(Me.NudTopMargin)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(199, 267)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(143, 169)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Margins in inches"
        '
        'NudLeftMargin
        '
        Me.NudLeftMargin.DecimalPlaces = 2
        Me.NudLeftMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudLeftMargin.Location = New System.Drawing.Point(11, 85)
        Me.NudLeftMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudLeftMargin.Name = "NudLeftMargin"
        Me.NudLeftMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudLeftMargin.TabIndex = 0
        '
        'NudRightMargin
        '
        Me.NudRightMargin.DecimalPlaces = 2
        Me.NudRightMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudRightMargin.Location = New System.Drawing.Point(78, 85)
        Me.NudRightMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudRightMargin.Name = "NudRightMargin"
        Me.NudRightMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudRightMargin.TabIndex = 2
        '
        'NudBottomMargin
        '
        Me.NudBottomMargin.DecimalPlaces = 2
        Me.NudBottomMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudBottomMargin.Location = New System.Drawing.Point(43, 135)
        Me.NudBottomMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudBottomMargin.Name = "NudBottomMargin"
        Me.NudBottomMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudBottomMargin.TabIndex = 3
        '
        'NudTopMargin
        '
        Me.NudTopMargin.DecimalPlaces = 2
        Me.NudTopMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudTopMargin.Location = New System.Drawing.Point(43, 40)
        Me.NudTopMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudTopMargin.Name = "NudTopMargin"
        Me.NudTopMargin.Size = New System.Drawing.Size(48, 20)
        Me.NudTopMargin.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(90, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Right"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(47, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Bottom"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Left"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(55, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Top"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.TxtCopyright)
        Me.GroupBox5.Controls.Add(Me.TxtDesignBy)
        Me.GroupBox5.Controls.Add(Me.ChkPrintFooter)
        Me.GroupBox5.Controls.Add(Me.ChkPrintHeader)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.TxtTitle)
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 413)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(180, 162)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Design Information"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 107)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Copyright"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Design By"
        '
        'TxtCopyright
        '
        Me.TxtCopyright.Location = New System.Drawing.Point(75, 104)
        Me.TxtCopyright.Name = "TxtCopyright"
        Me.TxtCopyright.Size = New System.Drawing.Size(100, 20)
        Me.TxtCopyright.TabIndex = 4
        '
        'TxtDesignBy
        '
        Me.TxtDesignBy.Location = New System.Drawing.Point(75, 72)
        Me.TxtDesignBy.Name = "TxtDesignBy"
        Me.TxtDesignBy.Size = New System.Drawing.Size(100, 20)
        Me.TxtDesignBy.TabIndex = 3
        '
        'ChkPrintFooter
        '
        Me.ChkPrintFooter.AutoSize = True
        Me.ChkPrintFooter.Location = New System.Drawing.Point(19, 136)
        Me.ChkPrintFooter.Name = "ChkPrintFooter"
        Me.ChkPrintFooter.Size = New System.Drawing.Size(110, 17)
        Me.ChkPrintFooter.TabIndex = 1
        Me.ChkPrintFooter.Text = "Print Page Footer"
        Me.ChkPrintFooter.UseVisualStyleBackColor = True
        '
        'ChkPrintHeader
        '
        Me.ChkPrintHeader.AutoSize = True
        Me.ChkPrintHeader.Location = New System.Drawing.Point(18, 45)
        Me.ChkPrintHeader.Name = "ChkPrintHeader"
        Me.ChkPrintHeader.Size = New System.Drawing.Size(113, 17)
        Me.ChkPrintHeader.TabIndex = 1
        Me.ChkPrintHeader.Text = "Print Page Header"
        Me.ChkPrintHeader.UseVisualStyleBackColor = True
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
        Me.BtnSaveSettings.Location = New System.Drawing.Point(121, 635)
        Me.BtnSaveSettings.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSaveSettings.Name = "BtnSaveSettings"
        Me.BtnSaveSettings.Size = New System.Drawing.Size(135, 35)
        Me.BtnSaveSettings.TabIndex = 6
        Me.BtnSaveSettings.Text = "Save Settings"
        Me.BtnSaveSettings.UseVisualStyleBackColor = False
        '
        'PnlDesignPicture
        '
        Me.PnlDesignPicture.Controls.Add(Me.PicDesign)
        Me.PnlDesignPicture.Location = New System.Drawing.Point(353, 74)
        Me.PnlDesignPicture.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.PnlDesignPicture.Name = "PnlDesignPicture"
        Me.PnlDesignPicture.Size = New System.Drawing.Size(376, 530)
        Me.PnlDesignPicture.TabIndex = 9
        '
        'CmbInstalledPrinters
        '
        Me.CmbInstalledPrinters.FormattingEnabled = True
        Me.CmbInstalledPrinters.Location = New System.Drawing.Point(12, 603)
        Me.CmbInstalledPrinters.Name = "CmbInstalledPrinters"
        Me.CmbInstalledPrinters.Size = New System.Drawing.Size(181, 24)
        Me.CmbInstalledPrinters.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 586)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 14)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Select printer"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnFooterFont)
        Me.GroupBox4.Controls.Add(Me.BtnTextFont)
        Me.GroupBox4.Controls.Add(Me.BtnTitleFont)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(199, 442)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(149, 133)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fonts"
        '
        'BtnFooterFont
        '
        Me.BtnFooterFont.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnFooterFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFooterFont.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFooterFont.Location = New System.Drawing.Point(12, 95)
        Me.BtnFooterFont.Name = "BtnFooterFont"
        Me.BtnFooterFont.Size = New System.Drawing.Size(131, 28)
        Me.BtnFooterFont.TabIndex = 18
        Me.BtnFooterFont.Text = "Footer Font"
        Me.BtnFooterFont.UseVisualStyleBackColor = False
        '
        'BtnTextFont
        '
        Me.BtnTextFont.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnTextFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTextFont.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTextFont.Location = New System.Drawing.Point(12, 58)
        Me.BtnTextFont.Name = "BtnTextFont"
        Me.BtnTextFont.Size = New System.Drawing.Size(131, 28)
        Me.BtnTextFont.TabIndex = 17
        Me.BtnTextFont.Text = "Text Font"
        Me.BtnTextFont.UseVisualStyleBackColor = False
        '
        'BtnTitleFont
        '
        Me.BtnTitleFont.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnTitleFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTitleFont.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTitleFont.Location = New System.Drawing.Point(12, 21)
        Me.BtnTitleFont.Name = "BtnTitleFont"
        Me.BtnTitleFont.Size = New System.Drawing.Size(131, 28)
        Me.BtnTitleFont.TabIndex = 16
        Me.BtnTitleFont.Text = "Title Font"
        Me.BtnTitleFont.UseVisualStyleBackColor = False
        '
        'BtnPrintAll
        '
        Me.BtnPrintAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrintAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnPrintAll.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnPrintAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrintAll.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintAll.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPrintAll.Location = New System.Drawing.Point(503, 620)
        Me.BtnPrintAll.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnPrintAll.Name = "BtnPrintAll"
        Me.BtnPrintAll.Size = New System.Drawing.Size(77, 46)
        Me.BtnPrintAll.TabIndex = 15
        Me.BtnPrintAll.Text = "Print All"
        Me.BtnPrintAll.UseVisualStyleBackColor = False
        '
        'ChkCentreLines
        '
        Me.ChkCentreLines.AutoSize = True
        Me.ChkCentreLines.Location = New System.Drawing.Point(140, 125)
        Me.ChkCentreLines.Name = "ChkCentreLines"
        Me.ChkCentreLines.Size = New System.Drawing.Size(123, 18)
        Me.ChkCentreLines.TabIndex = 21
        Me.ChkCentreLines.Text = "Print Centre Lines"
        Me.ChkCentreLines.UseVisualStyleBackColor = True
        '
        'FrmPrintProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 697)
        Me.Controls.Add(Me.BtnPrintAll)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbInstalledPrinters)
        Me.Controls.Add(Me.PnlDesignPicture)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BtnSaveSettings)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnPrintPage)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(754, 702)
        Me.Name = "FrmPrintProject"
        Me.Text = "Print Project"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.PnlDesignPicture.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents PicDesign As PictureBox
    Friend WithEvents BtnPrintPage As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ChkPrintKey As CheckBox
    Friend WithEvents ChkKeySeparate As CheckBox
    Friend WithEvents CbKeyOrder As ComboBox
    Friend WithEvents NudSqrPerInch As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblPageCt As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblOnePage As Label
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
    Friend WithEvents NudLeftMargin As NumericUpDown
    Friend WithEvents NudRightMargin As NumericUpDown
    Friend WithEvents NudBottomMargin As NumericUpDown
    Friend WithEvents NudTopMargin As NumericUpDown
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents ChkPrintHeader As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtCopyright As TextBox
    Friend WithEvents TxtDesignBy As TextBox
    Friend WithEvents BtnSaveSettings As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents PnlDesignPicture As Panel
    Friend WithEvents ChkCentreMarks As CheckBox
    Friend WithEvents ChkPrintGrid As CheckBox
    Friend WithEvents CmbInstalledPrinters As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnTextFont As Button
    Friend WithEvents BtnTitleFont As Button
    Friend WithEvents BtnFooterFont As Button
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents BtnPrintAll As Button
    Friend WithEvents ChkPrintFooter As CheckBox
    Friend WithEvents CbDisplayStyle As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ChkCentreLines As CheckBox
End Class
