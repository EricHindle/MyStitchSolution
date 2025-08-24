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
        Me.ThreadLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.TxtImagePath = New System.Windows.Forms.TextBox()
        Me.BtnSavePalette = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
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
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlForm
        '
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
        Me.PnlForm.Size = New System.Drawing.Size(243, 353)
        Me.PnlForm.TabIndex = 127
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
        Me.NudScaleFactor.TabIndex = 164
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
        Me.NudFabricCount.TabIndex = 162
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
        Me.NudOriginY.TabIndex = 155
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
        Me.NudOriginX.TabIndex = 153
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
        Me.NudFabricHeight.TabIndex = 139
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
        Me.NudFabricWidth.TabIndex = 137
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
        Me.NudDesignHeight.TabIndex = 135
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
        Me.NudDesignWidth.TabIndex = 133
        Me.NudDesignWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 21)
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
        Me.TxtName.Location = New System.Drawing.Point(74, 17)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(157, 27)
        Me.TxtName.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 667)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 22, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1230, 22)
        Me.StatusStrip1.TabIndex = 128
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
        Me.PicDesign.Size = New System.Drawing.Size(519, 540)
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
        Me.BtnClose.Location = New System.Drawing.Point(1122, 582)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(93, 62)
        Me.BtnClose.TabIndex = 134
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
        Me.BtnSelect.Location = New System.Drawing.Point(18, 582)
        Me.BtnSelect.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(93, 62)
        Me.BtnSelect.TabIndex = 135
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
        Me.BtnImport.Location = New System.Drawing.Point(182, 582)
        Me.BtnImport.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(93, 62)
        Me.BtnImport.TabIndex = 136
        Me.BtnImport.Text = "Import Image"
        Me.BtnImport.UseVisualStyleBackColor = False
        '
        'PicImagePreview
        '
        Me.PicImagePreview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicImagePreview.Location = New System.Drawing.Point(269, 55)
        Me.PicImagePreview.Margin = New System.Windows.Forms.Padding(4)
        Me.PicImagePreview.Name = "PicImagePreview"
        Me.PicImagePreview.Size = New System.Drawing.Size(291, 313)
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
        Me.BtnSave.Location = New System.Drawing.Point(351, 582)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(93, 62)
        Me.BtnSave.TabIndex = 138
        Me.BtnSave.Text = "Save Design"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(14, 377)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 182)
        Me.Panel1.TabIndex = 139
        '
        'ThreadLayoutPanel
        '
        Me.ThreadLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ThreadLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThreadLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.ThreadLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.ThreadLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ThreadLayoutPanel.Name = "ThreadLayoutPanel"
        Me.ThreadLayoutPanel.Size = New System.Drawing.Size(121, 540)
        Me.ThreadLayoutPanel.TabIndex = 140
        '
        'TxtImagePath
        '
        Me.TxtImagePath.Location = New System.Drawing.Point(268, 17)
        Me.TxtImagePath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtImagePath.Name = "TxtImagePath"
        Me.TxtImagePath.Size = New System.Drawing.Size(291, 24)
        Me.TxtImagePath.TabIndex = 141
        '
        'BtnSavePalette
        '
        Me.BtnSavePalette.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSavePalette.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnSavePalette.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSavePalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSavePalette.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSavePalette.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSavePalette.Location = New System.Drawing.Point(521, 582)
        Me.BtnSavePalette.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSavePalette.Name = "BtnSavePalette"
        Me.BtnSavePalette.Size = New System.Drawing.Size(93, 62)
        Me.BtnSavePalette.TabIndex = 142
        Me.BtnSavePalette.Text = "Save Palette"
        Me.BtnSavePalette.UseVisualStyleBackColor = False
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.PicDesign)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ThreadLayoutPanel)
        Me.SplitContainer1.Size = New System.Drawing.Size(652, 544)
        Me.SplitContainer1.SplitterDistance = 523
        Me.SplitContainer1.TabIndex = 143
        '
        'FrmImportImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1230, 689)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BtnSavePalette)
        Me.Controls.Add(Me.TxtImagePath)
        Me.Controls.Add(Me.Panel1)
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
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
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
End Class
