' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintOptions))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ChkPrintFooter = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtCopyright = New System.Windows.Forms.TextBox()
        Me.TxtDesignBy = New System.Windows.Forms.TextBox()
        Me.ChkPrintHeader = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NudLeftMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudRightMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudBottomMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudTopMargin = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NudOverlap = New System.Windows.Forms.NumericUpDown()
        Me.CbShading = New System.Windows.Forms.ComboBox()
        Me.ChkShowPageOrder = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NudSqrPerInch = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbKeyOrder = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkPrintKey = New System.Windows.Forms.CheckBox()
        Me.ChkColumnNumbers = New System.Windows.Forms.CheckBox()
        Me.ChkRowNumbers = New System.Windows.Forms.CheckBox()
        Me.ChkCentreLines = New System.Windows.Forms.CheckBox()
        Me.ChkPrintGrid = New System.Windows.Forms.CheckBox()
        Me.ChkCentreMarks = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnFooterFont = New System.Windows.Forms.Button()
        Me.BtnTextFont = New System.Windows.Forms.Button()
        Me.BtnTitleFont = New System.Windows.Forms.Button()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.NudCentreLineWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CbGrid10Colour = New System.Windows.Forms.ComboBox()
        Me.PicGrid10Colour = New System.Windows.Forms.PictureBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbGrid5Colour = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PicGrid5Colour = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CbGrid1Colour = New System.Windows.Forms.ComboBox()
        Me.PicGrid1Colour = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PicCentreLineColour = New System.Windows.Forms.PictureBox()
        Me.PnlOuter = New System.Windows.Forms.Panel()
        Me.PnlInner = New System.Windows.Forms.Panel()
        Me.PnlGrid = New System.Windows.Forms.Panel()
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.PnlTitle = New System.Windows.Forms.Panel()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.NudCentreLineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid10Colour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid5Colour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid1Colour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCentreLineColour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlOuter.SuspendLayout()
        Me.PnlInner.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSave.Location = New System.Drawing.Point(239, 616)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 50)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnCancel.Location = New System.Drawing.Point(444, 616)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 50)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ChkPrintFooter
        '
        Me.ChkPrintFooter.AutoSize = True
        Me.ChkPrintFooter.Location = New System.Drawing.Point(198, 108)
        Me.ChkPrintFooter.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPrintFooter.Name = "ChkPrintFooter"
        Me.ChkPrintFooter.Size = New System.Drawing.Size(122, 18)
        Me.ChkPrintFooter.TabIndex = 8
        Me.ChkPrintFooter.Text = "Print Page Footer"
        Me.ChkPrintFooter.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(131, 52)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 14)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Copyright"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(131, 22)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 14)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Design By"
        '
        'TxtCopyright
        '
        Me.TxtCopyright.Location = New System.Drawing.Point(198, 49)
        Me.TxtCopyright.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCopyright.Name = "TxtCopyright"
        Me.TxtCopyright.Size = New System.Drawing.Size(139, 22)
        Me.TxtCopyright.TabIndex = 5
        '
        'TxtDesignBy
        '
        Me.TxtDesignBy.Location = New System.Drawing.Point(198, 19)
        Me.TxtDesignBy.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDesignBy.Name = "TxtDesignBy"
        Me.TxtDesignBy.Size = New System.Drawing.Size(139, 22)
        Me.TxtDesignBy.TabIndex = 4
        '
        'ChkPrintHeader
        '
        Me.ChkPrintHeader.AutoSize = True
        Me.ChkPrintHeader.Location = New System.Drawing.Point(198, 83)
        Me.ChkPrintHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPrintHeader.Name = "ChkPrintHeader"
        Me.ChkPrintHeader.Size = New System.Drawing.Size(125, 18)
        Me.ChkPrintHeader.TabIndex = 2
        Me.ChkPrintHeader.Text = "Print Page Header"
        Me.ChkPrintHeader.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PnlOuter)
        Me.GroupBox3.Controls.Add(Me.NudLeftMargin)
        Me.GroupBox3.Controls.Add(Me.NudRightMargin)
        Me.GroupBox3.Controls.Add(Me.NudBottomMargin)
        Me.GroupBox3.Controls.Add(Me.NudTopMargin)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(13, 350)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(155, 316)
        Me.GroupBox3.TabIndex = 161
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Margins in inches"
        '
        'NudLeftMargin
        '
        Me.NudLeftMargin.DecimalPlaces = 2
        Me.NudLeftMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudLeftMargin.Location = New System.Drawing.Point(8, 84)
        Me.NudLeftMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudLeftMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudLeftMargin.Name = "NudLeftMargin"
        Me.NudLeftMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudLeftMargin.TabIndex = 152
        '
        'NudRightMargin
        '
        Me.NudRightMargin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NudRightMargin.DecimalPlaces = 2
        Me.NudRightMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudRightMargin.Location = New System.Drawing.Point(91, 84)
        Me.NudRightMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudRightMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudRightMargin.Name = "NudRightMargin"
        Me.NudRightMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudRightMargin.TabIndex = 151
        '
        'NudBottomMargin
        '
        Me.NudBottomMargin.DecimalPlaces = 2
        Me.NudBottomMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudBottomMargin.Location = New System.Drawing.Point(49, 128)
        Me.NudBottomMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudBottomMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudBottomMargin.Name = "NudBottomMargin"
        Me.NudBottomMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudBottomMargin.TabIndex = 150
        '
        'NudTopMargin
        '
        Me.NudTopMargin.DecimalPlaces = 2
        Me.NudTopMargin.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudTopMargin.Location = New System.Drawing.Point(49, 40)
        Me.NudTopMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudTopMargin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudTopMargin.Name = "NudTopMargin"
        Me.NudTopMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudTopMargin.TabIndex = 149
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(102, 67)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Right"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(57, 112)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Bottom"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 67)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Left"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 23)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Top"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NudOverlap)
        Me.GroupBox2.Controls.Add(Me.CbShading)
        Me.GroupBox2.Controls.Add(Me.ChkShowPageOrder)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(350, 14)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(194, 117)
        Me.GroupBox2.TabIndex = 160
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tiling"
        '
        'NudOverlap
        '
        Me.NudOverlap.Location = New System.Drawing.Point(114, 20)
        Me.NudOverlap.Margin = New System.Windows.Forms.Padding(4)
        Me.NudOverlap.Name = "NudOverlap"
        Me.NudOverlap.Size = New System.Drawing.Size(72, 20)
        Me.NudOverlap.TabIndex = 148
        Me.NudOverlap.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'CbShading
        '
        Me.CbShading.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbShading.FormattingEnabled = True
        Me.CbShading.Items.AddRange(New Object() {"Light Grey", "Mid Grey", "Dark Gray"})
        Me.CbShading.Location = New System.Drawing.Point(94, 48)
        Me.CbShading.Margin = New System.Windows.Forms.Padding(4)
        Me.CbShading.Name = "CbShading"
        Me.CbShading.Size = New System.Drawing.Size(92, 22)
        Me.CbShading.TabIndex = 147
        '
        'ChkShowPageOrder
        '
        Me.ChkShowPageOrder.AutoSize = True
        Me.ChkShowPageOrder.Location = New System.Drawing.Point(8, 78)
        Me.ChkShowPageOrder.Margin = New System.Windows.Forms.Padding(4)
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
        Me.Label8.Location = New System.Drawing.Point(8, 52)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Shading"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 22)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Overlap"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NudSqrPerInch)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CbKeyOrder)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ChkPrintKey)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(327, 95)
        Me.GroupBox1.TabIndex = 164
        Me.GroupBox1.TabStop = False
        '
        'NudSqrPerInch
        '
        Me.NudSqrPerInch.Location = New System.Drawing.Point(100, 52)
        Me.NudSqrPerInch.Margin = New System.Windows.Forms.Padding(4)
        Me.NudSqrPerInch.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudSqrPerInch.Name = "NudSqrPerInch"
        Me.NudSqrPerInch.Size = New System.Drawing.Size(72, 22)
        Me.NudSqrPerInch.TabIndex = 13
        Me.NudSqrPerInch.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(180, 56)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 14)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "squares per inch"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Printout Size"
        '
        'CbKeyOrder
        '
        Me.CbKeyOrder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbKeyOrder.FormattingEnabled = True
        Me.CbKeyOrder.Items.AddRange(New Object() {"<none>", "colour name", "DMC"})
        Me.CbKeyOrder.Location = New System.Drawing.Point(204, 23)
        Me.CbKeyOrder.Margin = New System.Windows.Forms.Padding(5)
        Me.CbKeyOrder.Name = "CbKeyOrder"
        Me.CbKeyOrder.Size = New System.Drawing.Size(113, 22)
        Me.CbKeyOrder.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(134, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Key order"
        '
        'ChkPrintKey
        '
        Me.ChkPrintKey.AutoSize = True
        Me.ChkPrintKey.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPrintKey.Location = New System.Drawing.Point(11, 25)
        Me.ChkPrintKey.Margin = New System.Windows.Forms.Padding(5)
        Me.ChkPrintKey.Name = "ChkPrintKey"
        Me.ChkPrintKey.Size = New System.Drawing.Size(75, 18)
        Me.ChkPrintKey.TabIndex = 0
        Me.ChkPrintKey.Text = "Print Key"
        Me.ChkPrintKey.UseVisualStyleBackColor = True
        '
        'ChkColumnNumbers
        '
        Me.ChkColumnNumbers.AutoSize = True
        Me.ChkColumnNumbers.Location = New System.Drawing.Point(198, 156)
        Me.ChkColumnNumbers.Name = "ChkColumnNumbers"
        Me.ChkColumnNumbers.Size = New System.Drawing.Size(147, 18)
        Me.ChkColumnNumbers.TabIndex = 169
        Me.ChkColumnNumbers.Text = "Print Column Numbers"
        Me.ChkColumnNumbers.UseVisualStyleBackColor = True
        '
        'ChkRowNumbers
        '
        Me.ChkRowNumbers.AutoSize = True
        Me.ChkRowNumbers.Location = New System.Drawing.Point(198, 132)
        Me.ChkRowNumbers.Name = "ChkRowNumbers"
        Me.ChkRowNumbers.Size = New System.Drawing.Size(131, 18)
        Me.ChkRowNumbers.TabIndex = 168
        Me.ChkRowNumbers.Text = "Print Row Numbers"
        Me.ChkRowNumbers.UseVisualStyleBackColor = True
        '
        'ChkCentreLines
        '
        Me.ChkCentreLines.AutoSize = True
        Me.ChkCentreLines.Location = New System.Drawing.Point(8, 86)
        Me.ChkCentreLines.Name = "ChkCentreLines"
        Me.ChkCentreLines.Size = New System.Drawing.Size(123, 18)
        Me.ChkCentreLines.TabIndex = 167
        Me.ChkCentreLines.Text = "Print Centre Lines"
        Me.ChkCentreLines.UseVisualStyleBackColor = True
        '
        'ChkPrintGrid
        '
        Me.ChkPrintGrid.AutoSize = True
        Me.ChkPrintGrid.Location = New System.Drawing.Point(8, 28)
        Me.ChkPrintGrid.Name = "ChkPrintGrid"
        Me.ChkPrintGrid.Size = New System.Drawing.Size(72, 18)
        Me.ChkPrintGrid.TabIndex = 164
        Me.ChkPrintGrid.Text = "PrintGrid"
        Me.ChkPrintGrid.UseVisualStyleBackColor = True
        '
        'ChkCentreMarks
        '
        Me.ChkCentreMarks.AutoSize = True
        Me.ChkCentreMarks.Location = New System.Drawing.Point(8, 57)
        Me.ChkCentreMarks.Name = "ChkCentreMarks"
        Me.ChkCentreMarks.Size = New System.Drawing.Size(126, 18)
        Me.ChkCentreMarks.TabIndex = 165
        Me.ChkCentreMarks.Text = "Print Centre Marks"
        Me.ChkCentreMarks.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.ChkPrintFooter)
        Me.GroupBox4.Controls.Add(Me.ChkColumnNumbers)
        Me.GroupBox4.Controls.Add(Me.TxtCopyright)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.ChkRowNumbers)
        Me.GroupBox4.Controls.Add(Me.BtnFooterFont)
        Me.GroupBox4.Controls.Add(Me.BtnTextFont)
        Me.GroupBox4.Controls.Add(Me.TxtDesignBy)
        Me.GroupBox4.Controls.Add(Me.BtnTitleFont)
        Me.GroupBox4.Controls.Add(Me.ChkPrintHeader)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(175, 350)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(351, 190)
        Me.GroupBox4.TabIndex = 166
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Text"
        '
        'BtnFooterFont
        '
        Me.BtnFooterFont.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnFooterFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFooterFont.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFooterFont.Location = New System.Drawing.Point(14, 95)
        Me.BtnFooterFont.Name = "BtnFooterFont"
        Me.BtnFooterFont.Size = New System.Drawing.Size(104, 28)
        Me.BtnFooterFont.TabIndex = 18
        Me.BtnFooterFont.Text = "Footer Font"
        Me.BtnFooterFont.UseVisualStyleBackColor = False
        '
        'BtnTextFont
        '
        Me.BtnTextFont.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnTextFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTextFont.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTextFont.Location = New System.Drawing.Point(14, 58)
        Me.BtnTextFont.Name = "BtnTextFont"
        Me.BtnTextFont.Size = New System.Drawing.Size(104, 28)
        Me.BtnTextFont.TabIndex = 17
        Me.BtnTextFont.Text = "Text Font"
        Me.BtnTextFont.UseVisualStyleBackColor = False
        '
        'BtnTitleFont
        '
        Me.BtnTitleFont.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnTitleFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTitleFont.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTitleFont.Location = New System.Drawing.Point(14, 21)
        Me.BtnTitleFont.Name = "BtnTitleFont"
        Me.BtnTitleFont.Size = New System.Drawing.Size(104, 28)
        Me.BtnTitleFont.TabIndex = 16
        Me.BtnTitleFont.Text = "Title Font"
        Me.BtnTitleFont.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.NudCentreLineWidth)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Controls.Add(Me.CbGrid10Colour)
        Me.GroupBox7.Controls.Add(Me.PicGrid10Colour)
        Me.GroupBox7.Controls.Add(Me.ChkCentreLines)
        Me.GroupBox7.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox7.Controls.Add(Me.ChkPrintGrid)
        Me.GroupBox7.Controls.Add(Me.ChkCentreMarks)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.CbGrid5Colour)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.PicGrid5Colour)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.CbGrid1Colour)
        Me.GroupBox7.Controls.Add(Me.PicGrid1Colour)
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.PicCentreLineColour)
        Me.GroupBox7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(12, 138)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(389, 205)
        Me.GroupBox7.TabIndex = 165
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Grid"
        '
        'NudCentreLineWidth
        '
        Me.NudCentreLineWidth.Location = New System.Drawing.Point(297, 57)
        Me.NudCentreLineWidth.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudCentreLineWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCentreLineWidth.Name = "NudCentreLineWidth"
        Me.NudCentreLineWidth.Size = New System.Drawing.Size(36, 22)
        Me.NudCentreLineWidth.TabIndex = 173
        Me.NudCentreLineWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(171, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 14)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Centre line thickness"
        '
        'CbGrid10Colour
        '
        Me.CbGrid10Colour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGrid10Colour.FormattingEnabled = True
        Me.CbGrid10Colour.Items.AddRange(New Object() {"Light Grey", "Dark Grey", "Dim Grey", "Black", "Other"})
        Me.CbGrid10Colour.Location = New System.Drawing.Point(297, 140)
        Me.CbGrid10Colour.Name = "CbGrid10Colour"
        Me.CbGrid10Colour.Size = New System.Drawing.Size(79, 22)
        Me.CbGrid10Colour.TabIndex = 166
        '
        'PicGrid10Colour
        '
        Me.PicGrid10Colour.BackColor = System.Drawing.Color.White
        Me.PicGrid10Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicGrid10Colour.Location = New System.Drawing.Point(265, 140)
        Me.PicGrid10Colour.Name = "PicGrid10Colour"
        Me.PicGrid10Colour.Size = New System.Drawing.Size(23, 23)
        Me.PicGrid10Colour.TabIndex = 172
        Me.PicGrid10Colour.TabStop = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(297, 27)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(4)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(46, 22)
        Me.NumericUpDown1.TabIndex = 13
        Me.NumericUpDown1.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(171, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "Grid 10 Colour"
        '
        'CbGrid5Colour
        '
        Me.CbGrid5Colour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGrid5Colour.FormattingEnabled = True
        Me.CbGrid5Colour.Items.AddRange(New Object() {"Light Grey", "Dark Grey", "Dim Grey", "Black", "Other"})
        Me.CbGrid5Colour.Location = New System.Drawing.Point(297, 112)
        Me.CbGrid5Colour.Name = "CbGrid5Colour"
        Me.CbGrid5Colour.Size = New System.Drawing.Size(79, 22)
        Me.CbGrid5Colour.TabIndex = 165
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(171, 31)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 14)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Border thickness"
        '
        'PicGrid5Colour
        '
        Me.PicGrid5Colour.BackColor = System.Drawing.Color.White
        Me.PicGrid5Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicGrid5Colour.Location = New System.Drawing.Point(265, 112)
        Me.PicGrid5Colour.Name = "PicGrid5Colour"
        Me.PicGrid5Colour.Size = New System.Drawing.Size(23, 23)
        Me.PicGrid5Colour.TabIndex = 170
        Me.PicGrid5Colour.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(171, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 169
        Me.Label6.Text = "Grid 5 Colour"
        '
        'CbGrid1Colour
        '
        Me.CbGrid1Colour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGrid1Colour.FormattingEnabled = True
        Me.CbGrid1Colour.Items.AddRange(New Object() {"Light Grey", "Dark Grey", "Dim Grey", "Black", "Other"})
        Me.CbGrid1Colour.Location = New System.Drawing.Point(297, 84)
        Me.CbGrid1Colour.Name = "CbGrid1Colour"
        Me.CbGrid1Colour.Size = New System.Drawing.Size(79, 22)
        Me.CbGrid1Colour.TabIndex = 164
        '
        'PicGrid1Colour
        '
        Me.PicGrid1Colour.BackColor = System.Drawing.Color.White
        Me.PicGrid1Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicGrid1Colour.Location = New System.Drawing.Point(265, 84)
        Me.PicGrid1Colour.Name = "PicGrid1Colour"
        Me.PicGrid1Colour.Size = New System.Drawing.Size(23, 23)
        Me.PicGrid1Colour.TabIndex = 168
        Me.PicGrid1Colour.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(171, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 14)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "Grid 1 Colour"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 14)
        Me.Label2.TabIndex = 155
        Me.Label2.Text = "Centre line colour"
        '
        'PicCentreLineColour
        '
        Me.PicCentreLineColour.BackColor = System.Drawing.Color.White
        Me.PicCentreLineColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicCentreLineColour.Location = New System.Drawing.Point(297, 170)
        Me.PicCentreLineColour.Name = "PicCentreLineColour"
        Me.PicCentreLineColour.Size = New System.Drawing.Size(23, 23)
        Me.PicCentreLineColour.TabIndex = 154
        Me.PicCentreLineColour.TabStop = False
        '
        'PnlOuter
        '
        Me.PnlOuter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlOuter.BackColor = System.Drawing.Color.LightGray
        Me.PnlOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlOuter.Controls.Add(Me.PnlInner)
        Me.PnlOuter.Location = New System.Drawing.Point(28, 162)
        Me.PnlOuter.Name = "PnlOuter"
        Me.PnlOuter.Size = New System.Drawing.Size(99, 140)
        Me.PnlOuter.TabIndex = 167
        '
        'PnlInner
        '
        Me.PnlInner.BackColor = System.Drawing.Color.White
        Me.PnlInner.Controls.Add(Me.PnlGrid)
        Me.PnlInner.Controls.Add(Me.PnlFooter)
        Me.PnlInner.Controls.Add(Me.PnlTitle)
        Me.PnlInner.Location = New System.Drawing.Point(3, 3)
        Me.PnlInner.Name = "PnlInner"
        Me.PnlInner.Size = New System.Drawing.Size(91, 132)
        Me.PnlInner.TabIndex = 0
        '
        'PnlGrid
        '
        Me.PnlGrid.BackgroundImage = Global.MyStitch.My.Resources.Resources.grid
        Me.PnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlGrid.Location = New System.Drawing.Point(3, 10)
        Me.PnlGrid.Name = "PnlGrid"
        Me.PnlGrid.Size = New System.Drawing.Size(65, 98)
        Me.PnlGrid.TabIndex = 2
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.DarkGray
        Me.PnlFooter.BackgroundImage = Global.MyStitch.My.Resources.Resources.footertextimage
        Me.PnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 124)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(91, 8)
        Me.PnlFooter.TabIndex = 1
        '
        'PnlTitle
        '
        Me.PnlTitle.BackColor = System.Drawing.Color.DarkGray
        Me.PnlTitle.BackgroundImage = Global.MyStitch.My.Resources.Resources.titletextImage
        Me.PnlTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.PnlTitle.Name = "PnlTitle"
        Me.PnlTitle.Size = New System.Drawing.Size(91, 8)
        Me.PnlTitle.TabIndex = 0
        '
        'FrmPrintOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(551, 679)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPrintOptions"
        Me.Text = "Print Options"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.NudCentreLineWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid10Colour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid5Colour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid1Colour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCentreLineColour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlOuter.ResumeLayout(False)
        Me.PnlInner.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtCopyright As TextBox
    Friend WithEvents TxtDesignBy As TextBox
    Friend WithEvents ChkPrintHeader As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents NudLeftMargin As NumericUpDown
    Friend WithEvents NudRightMargin As NumericUpDown
    Friend WithEvents NudBottomMargin As NumericUpDown
    Friend WithEvents NudTopMargin As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents NudOverlap As NumericUpDown
    Friend WithEvents CbShading As ComboBox
    Friend WithEvents ChkShowPageOrder As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CbKeyOrder As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ChkPrintKey As CheckBox
    Friend WithEvents NudSqrPerInch As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents ChkCentreMarks As CheckBox
    Friend WithEvents ChkPrintGrid As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnFooterFont As Button
    Friend WithEvents BtnTextFont As Button
    Friend WithEvents BtnTitleFont As Button
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ChkPrintFooter As CheckBox
    Friend WithEvents ChkCentreLines As CheckBox
    Friend WithEvents ChkColumnNumbers As CheckBox
    Friend WithEvents ChkRowNumbers As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PicCentreLineColour As PictureBox
    Friend WithEvents CbGrid10Colour As ComboBox
    Friend WithEvents PicGrid10Colour As PictureBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents CbGrid5Colour As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents PicGrid5Colour As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CbGrid1Colour As ComboBox
    Friend WithEvents PicGrid1Colour As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents NudCentreLineWidth As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents PnlOuter As Panel
    Friend WithEvents PnlInner As Panel
    Friend WithEvents PnlFooter As Panel
    Friend WithEvents PnlTitle As Panel
    Friend WithEvents PnlGrid As Panel
End Class
