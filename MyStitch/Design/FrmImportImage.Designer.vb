' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportImage))
        Me.PnlForm = New System.Windows.Forms.Panel()
        Me.BtnClearForm = New System.Windows.Forms.Button()
        Me.LblSize = New System.Windows.Forms.Label()
        Me.NudScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NudFabricCount = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NudOriginY = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NudOriginX = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NudFabricHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NudFabricWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NudDesignHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudDesignWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PicDesign = New System.Windows.Forms.PictureBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.PicImagePreview = New System.Windows.Forms.PictureBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClearPalette = New System.Windows.Forms.Button()
        Me.CbPalettes = New System.Windows.Forms.ComboBox()
        Me.BtnLoadPalette = New System.Windows.Forms.Button()
        Me.BtnSavePalette = New System.Windows.Forms.Button()
        Me.ChkStockOnly = New System.Windows.Forms.CheckBox()
        Me.ChkPaletteOnly = New System.Windows.Forms.CheckBox()
        Me.ThreadLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.TxtImagePath = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbCrosses = New System.Windows.Forms.RadioButton()
        Me.RbBlocks = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NudMaxThreads = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PnlForm.SuspendLayout()
        CType(Me.NudScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudOriginY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudOriginX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudMaxThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlForm
        '
        Me.PnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlForm.Controls.Add(Me.BtnClearForm)
        Me.PnlForm.Controls.Add(Me.LblSize)
        Me.PnlForm.Controls.Add(Me.NudScaleFactor)
        Me.PnlForm.Controls.Add(Me.Label2)
        Me.PnlForm.Controls.Add(Me.Label9)
        Me.PnlForm.Controls.Add(Me.NudFabricCount)
        Me.PnlForm.Controls.Add(Me.Label12)
        Me.PnlForm.Controls.Add(Me.NudOriginY)
        Me.PnlForm.Controls.Add(Me.Label13)
        Me.PnlForm.Controls.Add(Me.NudOriginX)
        Me.PnlForm.Controls.Add(Me.Label7)
        Me.PnlForm.Controls.Add(Me.NudFabricHeight)
        Me.PnlForm.Controls.Add(Me.Label6)
        Me.PnlForm.Controls.Add(Me.NudFabricWidth)
        Me.PnlForm.Controls.Add(Me.Label5)
        Me.PnlForm.Controls.Add(Me.NudDesignHeight)
        Me.PnlForm.Controls.Add(Me.Label4)
        Me.PnlForm.Controls.Add(Me.NudDesignWidth)
        Me.PnlForm.Controls.Add(Me.Label1)
        Me.PnlForm.Controls.Add(Me.TxtName)
        Me.PnlForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PnlForm.Location = New System.Drawing.Point(15, 15)
        Me.PnlForm.Margin = New System.Windows.Forms.Padding(5)
        Me.PnlForm.Name = "PnlForm"
        Me.PnlForm.Size = New System.Drawing.Size(243, 394)
        Me.PnlForm.TabIndex = 0
        '
        'BtnClearForm
        '
        Me.BtnClearForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClearForm.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClearForm.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearForm.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClearForm.Location = New System.Drawing.Point(11, 354)
        Me.BtnClearForm.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClearForm.Name = "BtnClearForm"
        Me.BtnClearForm.Size = New System.Drawing.Size(93, 29)
        Me.BtnClearForm.TabIndex = 9
        Me.BtnClearForm.Text = "Clear Form"
        Me.BtnClearForm.UseVisualStyleBackColor = False
        '
        'LblSize
        '
        Me.LblSize.AutoSize = True
        Me.LblSize.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.LblSize.Location = New System.Drawing.Point(10, 87)
        Me.LblSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSize.Name = "LblSize"
        Me.LblSize.Size = New System.Drawing.Size(66, 14)
        Me.LblSize.TabIndex = 142
        Me.LblSize.Text = "Image Size"
        '
        'NudScaleFactor
        '
        Me.NudScaleFactor.DecimalPlaces = 2
        Me.NudScaleFactor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NudScaleFactor.Location = New System.Drawing.Point(164, 57)
        Me.NudScaleFactor.Margin = New System.Windows.Forms.Padding(4)
        Me.NudScaleFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudScaleFactor.Name = "NudScaleFactor"
        Me.NudScaleFactor.Size = New System.Drawing.Size(66, 22)
        Me.NudScaleFactor.TabIndex = 1
        Me.NudScaleFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(10, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 17)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Scale"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 321)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 14)
        Me.Label9.TabIndex = 163
        Me.Label9.Text = "Fabric Count per inch"
        '
        'NudFabricCount
        '
        Me.NudFabricCount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricCount.Location = New System.Drawing.Point(164, 319)
        Me.NudFabricCount.Margin = New System.Windows.Forms.Padding(4)
        Me.NudFabricCount.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NudFabricCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFabricCount.Name = "NudFabricCount"
        Me.NudFabricCount.Size = New System.Drawing.Size(66, 22)
        Me.NudFabricCount.TabIndex = 8
        Me.NudFabricCount.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 223)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 14)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "Centre Y co-ord"
        '
        'NudOriginY
        '
        Me.NudOriginY.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudOriginY.Location = New System.Drawing.Point(164, 220)
        Me.NudOriginY.Margin = New System.Windows.Forms.Padding(4)
        Me.NudOriginY.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudOriginY.Name = "NudOriginY"
        Me.NudOriginY.Size = New System.Drawing.Size(66, 22)
        Me.NudOriginY.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 188)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 14)
        Me.Label13.TabIndex = 154
        Me.Label13.Text = "Centre X co-ord"
        '
        'NudOriginX
        '
        Me.NudOriginX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudOriginX.Location = New System.Drawing.Point(164, 186)
        Me.NudOriginX.Margin = New System.Windows.Forms.Padding(4)
        Me.NudOriginX.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudOriginX.Name = "NudOriginX"
        Me.NudOriginX.Size = New System.Drawing.Size(66, 22)
        Me.NudOriginX.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 292)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 14)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Fabric Height"
        '
        'NudFabricHeight
        '
        Me.NudFabricHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricHeight.Location = New System.Drawing.Point(164, 289)
        Me.NudFabricHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.NudFabricHeight.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NudFabricHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFabricHeight.Name = "NudFabricHeight"
        Me.NudFabricHeight.Size = New System.Drawing.Size(66, 22)
        Me.NudFabricHeight.TabIndex = 7
        Me.NudFabricHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 257)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 14)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "Fabric Width"
        '
        'NudFabricWidth
        '
        Me.NudFabricWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricWidth.Location = New System.Drawing.Point(164, 255)
        Me.NudFabricWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.NudFabricWidth.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NudFabricWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFabricWidth.Name = "NudFabricWidth"
        Me.NudFabricWidth.Size = New System.Drawing.Size(66, 22)
        Me.NudFabricWidth.TabIndex = 6
        Me.NudFabricWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 154)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 14)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Design Height"
        '
        'NudDesignHeight
        '
        Me.NudDesignHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignHeight.Location = New System.Drawing.Point(164, 151)
        Me.NudDesignHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.NudDesignHeight.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NudDesignHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDesignHeight.Name = "NudDesignHeight"
        Me.NudDesignHeight.Size = New System.Drawing.Size(66, 22)
        Me.NudDesignHeight.TabIndex = 3
        Me.NudDesignHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Design Width"
        '
        'NudDesignWidth
        '
        Me.NudDesignWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignWidth.Location = New System.Drawing.Point(164, 117)
        Me.NudDesignWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.NudDesignWidth.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NudDesignWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDesignWidth.Name = "NudDesignWidth"
        Me.NudDesignWidth.Size = New System.Drawing.Size(66, 22)
        Me.NudDesignWidth.TabIndex = 2
        Me.NudDesignWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 19)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Name"
        '
        'TxtName
        '
        Me.TxtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(75, 17)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(155, 27)
        Me.TxtName.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 552)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 22, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1230, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(2, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(9, 17)
        '
        'PicDesign
        '
        Me.PicDesign.BackColor = System.Drawing.Color.White
        Me.PicDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicDesign.Location = New System.Drawing.Point(0, 0)
        Me.PicDesign.Margin = New System.Windows.Forms.Padding(4)
        Me.PicDesign.Name = "PicDesign"
        Me.PicDesign.Size = New System.Drawing.Size(483, 470)
        Me.PicDesign.TabIndex = 133
        Me.PicDesign.TabStop = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(1125, 499)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(93, 48)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnSelect
        '
        Me.BtnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSelect.Location = New System.Drawing.Point(15, 499)
        Me.BtnSelect.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(93, 48)
        Me.BtnSelect.TabIndex = 3
        Me.BtnSelect.Text = "Select Image"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnImport.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImport.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImport.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnImport.Location = New System.Drawing.Point(142, 499)
        Me.BtnImport.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(93, 48)
        Me.BtnImport.TabIndex = 4
        Me.BtnImport.Text = "Import Image"
        Me.BtnImport.UseVisualStyleBackColor = False
        '
        'PicImagePreview
        '
        Me.PicImagePreview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicImagePreview.Location = New System.Drawing.Point(269, 47)
        Me.PicImagePreview.Margin = New System.Windows.Forms.Padding(4)
        Me.PicImagePreview.Name = "PicImagePreview"
        Me.PicImagePreview.Size = New System.Drawing.Size(291, 362)
        Me.PicImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImagePreview.TabIndex = 137
        Me.PicImagePreview.TabStop = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSave.Location = New System.Drawing.Point(269, 499)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(93, 48)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "Save Design"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.BtnClearPalette)
        Me.Panel1.Controls.Add(Me.CbPalettes)
        Me.Panel1.Controls.Add(Me.BtnLoadPalette)
        Me.Panel1.Controls.Add(Me.BtnSavePalette)
        Me.Panel1.Location = New System.Drawing.Point(4, 358)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 108)
        Me.Panel1.TabIndex = 1
        '
        'BtnClearPalette
        '
        Me.BtnClearPalette.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClearPalette.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClearPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClearPalette.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearPalette.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClearPalette.Location = New System.Drawing.Point(42, 50)
        Me.BtnClearPalette.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClearPalette.Name = "BtnClearPalette"
        Me.BtnClearPalette.Size = New System.Drawing.Size(63, 24)
        Me.BtnClearPalette.TabIndex = 3
        Me.BtnClearPalette.Text = "Clear"
        Me.BtnClearPalette.UseVisualStyleBackColor = False
        '
        'CbPalettes
        '
        Me.CbPalettes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbPalettes.FormattingEnabled = True
        Me.CbPalettes.Location = New System.Drawing.Point(5, 77)
        Me.CbPalettes.Name = "CbPalettes"
        Me.CbPalettes.Size = New System.Drawing.Size(136, 24)
        Me.CbPalettes.TabIndex = 2
        '
        'BtnLoadPalette
        '
        Me.BtnLoadPalette.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnLoadPalette.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnLoadPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoadPalette.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadPalette.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLoadPalette.Location = New System.Drawing.Point(5, 6)
        Me.BtnLoadPalette.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnLoadPalette.Name = "BtnLoadPalette"
        Me.BtnLoadPalette.Size = New System.Drawing.Size(63, 40)
        Me.BtnLoadPalette.TabIndex = 1
        Me.BtnLoadPalette.Text = "Load Palette"
        Me.BtnLoadPalette.UseVisualStyleBackColor = False
        '
        'BtnSavePalette
        '
        Me.BtnSavePalette.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnSavePalette.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSavePalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSavePalette.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSavePalette.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSavePalette.Location = New System.Drawing.Point(78, 5)
        Me.BtnSavePalette.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSavePalette.Name = "BtnSavePalette"
        Me.BtnSavePalette.Size = New System.Drawing.Size(63, 40)
        Me.BtnSavePalette.TabIndex = 0
        Me.BtnSavePalette.Text = "Save Palette"
        Me.BtnSavePalette.UseVisualStyleBackColor = False
        '
        'ChkStockOnly
        '
        Me.ChkStockOnly.AutoSize = True
        Me.ChkStockOnly.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkStockOnly.Location = New System.Drawing.Point(6, 46)
        Me.ChkStockOnly.Name = "ChkStockOnly"
        Me.ChkStockOnly.Size = New System.Drawing.Size(157, 18)
        Me.ChkStockOnly.TabIndex = 1
        Me.ChkStockOnly.Text = "Threads with stock only"
        Me.ChkStockOnly.UseVisualStyleBackColor = True
        '
        'ChkPaletteOnly
        '
        Me.ChkPaletteOnly.AutoSize = True
        Me.ChkPaletteOnly.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPaletteOnly.Location = New System.Drawing.Point(6, 21)
        Me.ChkPaletteOnly.Name = "ChkPaletteOnly"
        Me.ChkPaletteOnly.Size = New System.Drawing.Size(136, 18)
        Me.ChkPaletteOnly.TabIndex = 0
        Me.ChkPaletteOnly.Text = "Palette threads only"
        Me.ChkPaletteOnly.UseVisualStyleBackColor = True
        '
        'ThreadLayoutPanel
        '
        Me.ThreadLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ThreadLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ThreadLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.ThreadLayoutPanel.Location = New System.Drawing.Point(4, 4)
        Me.ThreadLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ThreadLayoutPanel.Name = "ThreadLayoutPanel"
        Me.ThreadLayoutPanel.Size = New System.Drawing.Size(150, 346)
        Me.ThreadLayoutPanel.TabIndex = 0
        '
        'TxtImagePath
        '
        Me.TxtImagePath.Location = New System.Drawing.Point(269, 15)
        Me.TxtImagePath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtImagePath.Name = "TxtImagePath"
        Me.TxtImagePath.Size = New System.Drawing.Size(291, 24)
        Me.TxtImagePath.TabIndex = 8
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(566, 15)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ThreadLayoutPanel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PicDesign)
        Me.SplitContainer1.Size = New System.Drawing.Size(652, 474)
        Me.SplitContainer1.SplitterDistance = 161
        Me.SplitContainer1.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RbCrosses)
        Me.GroupBox1.Controls.Add(Me.RbBlocks)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 417)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(89, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Display Style"
        '
        'RbCrosses
        '
        Me.RbCrosses.AutoSize = True
        Me.RbCrosses.Location = New System.Drawing.Point(9, 45)
        Me.RbCrosses.Name = "RbCrosses"
        Me.RbCrosses.Size = New System.Drawing.Size(65, 18)
        Me.RbCrosses.TabIndex = 1
        Me.RbCrosses.Text = "Crosses"
        Me.RbCrosses.UseVisualStyleBackColor = True
        '
        'RbBlocks
        '
        Me.RbBlocks.AutoSize = True
        Me.RbBlocks.Checked = True
        Me.RbBlocks.Location = New System.Drawing.Point(9, 21)
        Me.RbBlocks.Name = "RbBlocks"
        Me.RbBlocks.Size = New System.Drawing.Size(58, 18)
        Me.RbBlocks.TabIndex = 0
        Me.RbBlocks.TabStop = True
        Me.RbBlocks.Text = "Blocks"
        Me.RbBlocks.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.NudMaxThreads)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ChkPaletteOnly)
        Me.GroupBox2.Controls.Add(Me.ChkStockOnly)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(116, 417)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(342, 72)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thread selection"
        '
        'NudMaxThreads
        '
        Me.NudMaxThreads.Location = New System.Drawing.Point(253, 39)
        Me.NudMaxThreads.Name = "NudMaxThreads"
        Me.NudMaxThreads.Size = New System.Drawing.Size(57, 22)
        Me.NudMaxThreads.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(164, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Maximum number of threads"
        '
        'FrmImportImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1230, 574)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TxtImagePath)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.PicImagePreview)
        Me.Controls.Add(Me.BtnImport)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PnlForm)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmImportImage"
        Me.Text = "Import Image"
        Me.PnlForm.ResumeLayout(False)
        Me.PnlForm.PerformLayout()
        CType(Me.NudScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudOriginY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudOriginX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudMaxThreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlForm As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents NudFabricCount As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents NudOriginY As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents NudOriginX As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents NudFabricHeight As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents NudFabricWidth As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NudDesignHeight As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents NudDesignWidth As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtName As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents PicDesign As PictureBox
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSelect As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents PicImagePreview As PictureBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ThreadLayoutPanel As FlowLayoutPanel
    Friend WithEvents TxtImagePath As TextBox
    Friend WithEvents LblSize As Label
    Friend WithEvents NudScaleFactor As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnSavePalette As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BtnClearForm As Button
    Friend WithEvents BtnLoadPalette As Button
    Friend WithEvents ChkPaletteOnly As CheckBox
    Friend WithEvents ChkStockOnly As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RbCrosses As RadioButton
    Friend WithEvents RbBlocks As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CbPalettes As ComboBox
    Friend WithEvents NudMaxThreads As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnClearPalette As Button
End Class
