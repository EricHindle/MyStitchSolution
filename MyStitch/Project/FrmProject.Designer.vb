' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProject
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProject))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.DgvProjects = New System.Windows.Forms.DataGridView()
        Me.projectId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.projectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnlForm = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NudOriginY = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NudOriginX = New System.Windows.Forms.NumericUpDown()
        Me.CbGrid10Colour = New System.Windows.Forms.ComboBox()
        Me.PicGrid10Colour = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CbGrid5Colour = New System.Windows.Forms.ComboBox()
        Me.PicGrid5Colour = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CbGrid1Colour = New System.Windows.Forms.ComboBox()
        Me.PicGrid1Colour = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CbFabricColour = New System.Windows.Forms.ComboBox()
        Me.PicFabricColour = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NudFabricHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NudFabricWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NudDesignHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudDesignWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblSelectedProject = New System.Windows.Forms.Label()
        Me.LblProjectId = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.BtnProjectThreads = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.BtnDesign = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpenDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuResizeDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuThreads = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuShowLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDebugOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuUndoOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblStartTime = New System.Windows.Forms.Label()
        Me.LblEndTime = New System.Windows.Forms.Label()
        Me.LblElapsedTime = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlForm.SuspendLayout()
        CType(Me.NudOriginY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudOriginX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid10Colour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid5Colour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid1Colour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFabricColour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 553)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(709, 22)
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
        'BtnClear
        '
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(17, 290)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(80, 40)
        Me.BtnClear.TabIndex = 117
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete.Location = New System.Drawing.Point(17, 217)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 40)
        Me.BtnDelete.TabIndex = 116
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNew.Location = New System.Drawing.Point(17, 104)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(80, 40)
        Me.BtnNew.TabIndex = 114
        Me.BtnNew.Text = "Add"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnUpdate.Location = New System.Drawing.Point(17, 160)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(80, 40)
        Me.BtnUpdate.TabIndex = 115
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(117, 39)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(86, 19)
        Me.Label44.TabIndex = 125
        Me.Label44.Text = "PROJECTS"
        '
        'DgvProjects
        '
        Me.DgvProjects.AllowUserToAddRows = False
        Me.DgvProjects.AllowUserToDeleteRows = False
        Me.DgvProjects.AllowUserToResizeRows = False
        Me.DgvProjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgvProjects.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvProjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProjects.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.projectId, Me.projectName})
        Me.DgvProjects.GridColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.DgvProjects.Location = New System.Drawing.Point(121, 62)
        Me.DgvProjects.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvProjects.MultiSelect = False
        Me.DgvProjects.Name = "DgvProjects"
        Me.DgvProjects.ReadOnly = True
        Me.DgvProjects.RowHeadersVisible = False
        Me.DgvProjects.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.DgvProjects.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgvProjects.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.DgvProjects.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.DgvProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProjects.Size = New System.Drawing.Size(265, 423)
        Me.DgvProjects.TabIndex = 124
        '
        'projectId
        '
        Me.projectId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.projectId.HeaderText = "Id"
        Me.projectId.Name = "projectId"
        Me.projectId.ReadOnly = True
        Me.projectId.Visible = False
        Me.projectId.Width = 50
        '
        'projectName
        '
        Me.projectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.projectName.HeaderText = "Name"
        Me.projectName.Name = "projectName"
        Me.projectName.ReadOnly = True
        '
        'PnlForm
        '
        Me.PnlForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlForm.Controls.Add(Me.Label15)
        Me.PnlForm.Controls.Add(Me.LblElapsedTime)
        Me.PnlForm.Controls.Add(Me.LblEndTime)
        Me.PnlForm.Controls.Add(Me.LblStartTime)
        Me.PnlForm.Controls.Add(Me.Label14)
        Me.PnlForm.Controls.Add(Me.Label12)
        Me.PnlForm.Controls.Add(Me.NudOriginY)
        Me.PnlForm.Controls.Add(Me.Label13)
        Me.PnlForm.Controls.Add(Me.NudOriginX)
        Me.PnlForm.Controls.Add(Me.CbGrid10Colour)
        Me.PnlForm.Controls.Add(Me.PicGrid10Colour)
        Me.PnlForm.Controls.Add(Me.Label11)
        Me.PnlForm.Controls.Add(Me.CbGrid5Colour)
        Me.PnlForm.Controls.Add(Me.PicGrid5Colour)
        Me.PnlForm.Controls.Add(Me.Label10)
        Me.PnlForm.Controls.Add(Me.CbGrid1Colour)
        Me.PnlForm.Controls.Add(Me.PicGrid1Colour)
        Me.PnlForm.Controls.Add(Me.Label9)
        Me.PnlForm.Controls.Add(Me.CbFabricColour)
        Me.PnlForm.Controls.Add(Me.PicFabricColour)
        Me.PnlForm.Controls.Add(Me.Label8)
        Me.PnlForm.Controls.Add(Me.Label7)
        Me.PnlForm.Controls.Add(Me.NudFabricHeight)
        Me.PnlForm.Controls.Add(Me.Label6)
        Me.PnlForm.Controls.Add(Me.NudFabricWidth)
        Me.PnlForm.Controls.Add(Me.Label5)
        Me.PnlForm.Controls.Add(Me.NudDesignHeight)
        Me.PnlForm.Controls.Add(Me.Label4)
        Me.PnlForm.Controls.Add(Me.NudDesignWidth)
        Me.PnlForm.Controls.Add(Me.Label3)
        Me.PnlForm.Controls.Add(Me.Label2)
        Me.PnlForm.Controls.Add(Me.LblSelectedProject)
        Me.PnlForm.Controls.Add(Me.LblProjectId)
        Me.PnlForm.Controls.Add(Me.Label1)
        Me.PnlForm.Controls.Add(Me.TxtName)
        Me.PnlForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PnlForm.Location = New System.Drawing.Point(394, 35)
        Me.PnlForm.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlForm.Name = "PnlForm"
        Me.PnlForm.Size = New System.Drawing.Size(302, 450)
        Me.PnlForm.TabIndex = 126
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(48, 250)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 14)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "Centre Y co-ord"
        '
        'NudOriginY
        '
        Me.NudOriginY.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudOriginY.Location = New System.Drawing.Point(195, 246)
        Me.NudOriginY.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudOriginY.Name = "NudOriginY"
        Me.NudOriginY.Size = New System.Drawing.Size(74, 22)
        Me.NudOriginY.TabIndex = 155
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(48, 222)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 14)
        Me.Label13.TabIndex = 154
        Me.Label13.Text = "Centre X co-ord"
        '
        'NudOriginX
        '
        Me.NudOriginX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudOriginX.Location = New System.Drawing.Point(195, 218)
        Me.NudOriginX.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudOriginX.Name = "NudOriginX"
        Me.NudOriginX.Size = New System.Drawing.Size(74, 22)
        Me.NudOriginX.TabIndex = 153
        '
        'CbGrid10Colour
        '
        Me.CbGrid10Colour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGrid10Colour.FormattingEnabled = True
        Me.CbGrid10Colour.Items.AddRange(New Object() {"Light Grey", "Mid Grey", "Dark Gray", "Black", "Other"})
        Me.CbGrid10Colour.Location = New System.Drawing.Point(195, 421)
        Me.CbGrid10Colour.Name = "CbGrid10Colour"
        Me.CbGrid10Colour.Size = New System.Drawing.Size(79, 22)
        Me.CbGrid10Colour.TabIndex = 152
        '
        'PicGrid10Colour
        '
        Me.PicGrid10Colour.BackColor = System.Drawing.Color.White
        Me.PicGrid10Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicGrid10Colour.Location = New System.Drawing.Point(166, 421)
        Me.PicGrid10Colour.Name = "PicGrid10Colour"
        Me.PicGrid10Colour.Size = New System.Drawing.Size(23, 23)
        Me.PicGrid10Colour.TabIndex = 151
        Me.PicGrid10Colour.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(48, 425)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 14)
        Me.Label11.TabIndex = 150
        Me.Label11.Text = "Grid 10 Colour"
        '
        'CbGrid5Colour
        '
        Me.CbGrid5Colour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGrid5Colour.FormattingEnabled = True
        Me.CbGrid5Colour.Items.AddRange(New Object() {"Light Grey", "Mid Grey", "Dark Gray", "Black", "Other"})
        Me.CbGrid5Colour.Location = New System.Drawing.Point(195, 394)
        Me.CbGrid5Colour.Name = "CbGrid5Colour"
        Me.CbGrid5Colour.Size = New System.Drawing.Size(79, 22)
        Me.CbGrid5Colour.TabIndex = 149
        '
        'PicGrid5Colour
        '
        Me.PicGrid5Colour.BackColor = System.Drawing.Color.White
        Me.PicGrid5Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicGrid5Colour.Location = New System.Drawing.Point(166, 394)
        Me.PicGrid5Colour.Name = "PicGrid5Colour"
        Me.PicGrid5Colour.Size = New System.Drawing.Size(23, 23)
        Me.PicGrid5Colour.TabIndex = 148
        Me.PicGrid5Colour.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(48, 398)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 14)
        Me.Label10.TabIndex = 147
        Me.Label10.Text = "Grid 5 Colour"
        '
        'CbGrid1Colour
        '
        Me.CbGrid1Colour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGrid1Colour.FormattingEnabled = True
        Me.CbGrid1Colour.Items.AddRange(New Object() {"Light Grey", "Mid Grey", "Dark Gray", "Black", "Other"})
        Me.CbGrid1Colour.Location = New System.Drawing.Point(195, 367)
        Me.CbGrid1Colour.Name = "CbGrid1Colour"
        Me.CbGrid1Colour.Size = New System.Drawing.Size(79, 22)
        Me.CbGrid1Colour.TabIndex = 146
        '
        'PicGrid1Colour
        '
        Me.PicGrid1Colour.BackColor = System.Drawing.Color.White
        Me.PicGrid1Colour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicGrid1Colour.Location = New System.Drawing.Point(166, 367)
        Me.PicGrid1Colour.Name = "PicGrid1Colour"
        Me.PicGrid1Colour.Size = New System.Drawing.Size(23, 23)
        Me.PicGrid1Colour.TabIndex = 145
        Me.PicGrid1Colour.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(48, 371)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 14)
        Me.Label9.TabIndex = 144
        Me.Label9.Text = "Grid 1 Colour"
        '
        'CbFabricColour
        '
        Me.CbFabricColour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbFabricColour.FormattingEnabled = True
        Me.CbFabricColour.Items.AddRange(New Object() {"White", "Cream", "Blue", "Pink", "Other"})
        Me.CbFabricColour.Location = New System.Drawing.Point(195, 340)
        Me.CbFabricColour.Name = "CbFabricColour"
        Me.CbFabricColour.Size = New System.Drawing.Size(79, 22)
        Me.CbFabricColour.TabIndex = 143
        '
        'PicFabricColour
        '
        Me.PicFabricColour.BackColor = System.Drawing.Color.White
        Me.PicFabricColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicFabricColour.Location = New System.Drawing.Point(166, 340)
        Me.PicFabricColour.Name = "PicFabricColour"
        Me.PicFabricColour.Size = New System.Drawing.Size(23, 23)
        Me.PicFabricColour.TabIndex = 142
        Me.PicFabricColour.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 344)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = "Fabric Colour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(48, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 14)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Fabric Height"
        '
        'NudFabricHeight
        '
        Me.NudFabricHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricHeight.Location = New System.Drawing.Point(195, 302)
        Me.NudFabricHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudFabricHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFabricHeight.Name = "NudFabricHeight"
        Me.NudFabricHeight.Size = New System.Drawing.Size(74, 22)
        Me.NudFabricHeight.TabIndex = 139
        Me.NudFabricHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(48, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 14)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "Fabric Width"
        '
        'NudFabricWidth
        '
        Me.NudFabricWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricWidth.Location = New System.Drawing.Point(195, 274)
        Me.NudFabricWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudFabricWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFabricWidth.Name = "NudFabricWidth"
        Me.NudFabricWidth.Size = New System.Drawing.Size(74, 22)
        Me.NudFabricWidth.TabIndex = 137
        Me.NudFabricWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(48, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 14)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Design Height"
        '
        'NudDesignHeight
        '
        Me.NudDesignHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignHeight.Location = New System.Drawing.Point(195, 190)
        Me.NudDesignHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudDesignHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDesignHeight.Name = "NudDesignHeight"
        Me.NudDesignHeight.Size = New System.Drawing.Size(74, 22)
        Me.NudDesignHeight.TabIndex = 135
        Me.NudDesignHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Design Width"
        '
        'NudDesignWidth
        '
        Me.NudDesignWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignWidth.Location = New System.Drawing.Point(195, 162)
        Me.NudDesignWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudDesignWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDesignWidth.Name = "NudDesignWidth"
        Me.NudDesignWidth.Size = New System.Drawing.Size(74, 22)
        Me.NudDesignWidth.TabIndex = 133
        Me.NudDesignWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(48, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Finished"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 14)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Started"
        '
        'LblSelectedProject
        '
        Me.LblSelectedProject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSelectedProject.AutoEllipsis = True
        Me.LblSelectedProject.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectedProject.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSelectedProject.Location = New System.Drawing.Point(47, 6)
        Me.LblSelectedProject.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSelectedProject.Name = "LblSelectedProject"
        Me.LblSelectedProject.Size = New System.Drawing.Size(252, 29)
        Me.LblSelectedProject.TabIndex = 124
        Me.LblSelectedProject.Text = "No selected project"
        '
        'LblProjectId
        '
        Me.LblProjectId.AutoSize = True
        Me.LblProjectId.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProjectId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.LblProjectId.Location = New System.Drawing.Point(7, 4)
        Me.LblProjectId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblProjectId.Name = "LblProjectId"
        Me.LblProjectId.Size = New System.Drawing.Size(24, 19)
        Me.LblProjectId.TabIndex = 12
        Me.LblProjectId.Text = "Id"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
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
        Me.TxtName.Location = New System.Drawing.Point(81, 42)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(216, 27)
        Me.TxtName.TabIndex = 1
        '
        'BtnProjectThreads
        '
        Me.BtnProjectThreads.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnProjectThreads.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnProjectThreads.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnProjectThreads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProjectThreads.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProjectThreads.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnProjectThreads.Location = New System.Drawing.Point(156, 493)
        Me.BtnProjectThreads.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProjectThreads.Name = "BtnProjectThreads"
        Me.BtnProjectThreads.Size = New System.Drawing.Size(75, 53)
        Me.BtnProjectThreads.TabIndex = 128
        Me.BtnProjectThreads.Text = "Project Threads"
        Me.BtnProjectThreads.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(616, 499)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 127
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnDesign
        '
        Me.BtnDesign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDesign.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDesign.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDesign.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDesign.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDesign.Location = New System.Drawing.Point(295, 493)
        Me.BtnDesign.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDesign.Name = "BtnDesign"
        Me.BtnDesign.Size = New System.Drawing.Size(75, 53)
        Me.BtnDesign.TabIndex = 129
        Me.BtnDesign.Text = "Design"
        Me.BtnDesign.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuButton})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(709, 28)
        Me.MenuStrip1.TabIndex = 130
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuButton
        '
        Me.MnuButton.AutoSize = False
        Me.MnuButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDesign, Me.MnuThreads, Me.MnuSymbols, Me.ToolStripSeparator3, Me.MnuLogging, Me.BackupToolStripMenuItem, Me.MnuOptions, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.MnuButton.Image = CType(resources.GetObject("MnuButton.Image"), System.Drawing.Image)
        Me.MnuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MnuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuButton.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.MnuButton.Name = "MnuButton"
        Me.MnuButton.Padding = New System.Windows.Forms.Padding(0)
        Me.MnuButton.Size = New System.Drawing.Size(122, 28)
        '
        'MnuDesign
        '
        Me.MnuDesign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuOpenDesign, Me.MnuResizeDesign})
        Me.MnuDesign.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuDesign.Name = "MnuDesign"
        Me.MnuDesign.Size = New System.Drawing.Size(157, 22)
        Me.MnuDesign.Text = "Design"
        '
        'MnuOpenDesign
        '
        Me.MnuOpenDesign.Name = "MnuOpenDesign"
        Me.MnuOpenDesign.Size = New System.Drawing.Size(106, 22)
        Me.MnuOpenDesign.Text = "Open"
        '
        'MnuResizeDesign
        '
        Me.MnuResizeDesign.Name = "MnuResizeDesign"
        Me.MnuResizeDesign.Size = New System.Drawing.Size(106, 22)
        Me.MnuResizeDesign.Text = "Resize"
        '
        'MnuThreads
        '
        Me.MnuThreads.Name = "MnuThreads"
        Me.MnuThreads.Size = New System.Drawing.Size(157, 22)
        Me.MnuThreads.Text = "Threads"
        '
        'MnuSymbols
        '
        Me.MnuSymbols.Name = "MnuSymbols"
        Me.MnuSymbols.Size = New System.Drawing.Size(157, 22)
        Me.MnuSymbols.Text = "Symbols"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(154, 6)
        '
        'MnuLogging
        '
        Me.MnuLogging.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuShowLog, Me.MnuDebugOn})
        Me.MnuLogging.Name = "MnuLogging"
        Me.MnuLogging.Size = New System.Drawing.Size(157, 22)
        Me.MnuLogging.Text = "Logging"
        '
        'MnuShowLog
        '
        Me.MnuShowLog.Name = "MnuShowLog"
        Me.MnuShowLog.Size = New System.Drawing.Size(128, 22)
        Me.MnuShowLog.Text = "Show Log"
        '
        'MnuDebugOn
        '
        Me.MnuDebugOn.CheckOnClick = True
        Me.MnuDebugOn.Name = "MnuDebugOn"
        Me.MnuDebugOn.Size = New System.Drawing.Size(128, 22)
        Me.MnuDebugOn.Text = "Debug On"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuBackup, Me.MnuRestore})
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.BackupToolStripMenuItem.Text = "Backup/Restore"
        '
        'MnuBackup
        '
        Me.MnuBackup.Name = "MnuBackup"
        Me.MnuBackup.Size = New System.Drawing.Size(113, 22)
        Me.MnuBackup.Text = "Backup"
        '
        'MnuRestore
        '
        Me.MnuRestore.Name = "MnuRestore"
        Me.MnuRestore.Size = New System.Drawing.Size(113, 22)
        Me.MnuRestore.Text = "Restore"
        '
        'MnuOptions
        '
        Me.MnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPreferences, Me.ToolStripSeparator2, Me.MnuUndoOn})
        Me.MnuOptions.Name = "MnuOptions"
        Me.MnuOptions.Size = New System.Drawing.Size(157, 22)
        Me.MnuOptions.Text = "Preferences"
        '
        'MnuPreferences
        '
        Me.MnuPreferences.Name = "MnuPreferences"
        Me.MnuPreferences.Size = New System.Drawing.Size(135, 22)
        Me.MnuPreferences.Text = "Preferences"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(132, 6)
        '
        'MnuUndoOn
        '
        Me.MnuUndoOn.CheckOnClick = True
        Me.MnuUndoOn.Name = "MnuUndoOn"
        Me.MnuUndoOn.Size = New System.Drawing.Size(135, 22)
        Me.MnuUndoOn.Text = "Undo On"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(154, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(48, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 14)
        Me.Label14.TabIndex = 157
        Me.Label14.Text = "Total work time"
        '
        'LblStartTime
        '
        Me.LblStartTime.AutoSize = True
        Me.LblStartTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartTime.ForeColor = System.Drawing.Color.SeaGreen
        Me.LblStartTime.Location = New System.Drawing.Point(148, 83)
        Me.LblStartTime.Name = "LblStartTime"
        Me.LblStartTime.Size = New System.Drawing.Size(76, 17)
        Me.LblStartTime.TabIndex = 158
        Me.LblStartTime.Text = "not started"
        '
        'LblEndTime
        '
        Me.LblEndTime.AutoSize = True
        Me.LblEndTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndTime.ForeColor = System.Drawing.Color.Maroon
        Me.LblEndTime.Location = New System.Drawing.Point(148, 105)
        Me.LblEndTime.Name = "LblEndTime"
        Me.LblEndTime.Size = New System.Drawing.Size(76, 17)
        Me.LblEndTime.TabIndex = 159
        Me.LblEndTime.Text = "not started"
        '
        'LblElapsedTime
        '
        Me.LblElapsedTime.AutoSize = True
        Me.LblElapsedTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblElapsedTime.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblElapsedTime.Location = New System.Drawing.Point(148, 127)
        Me.LblElapsedTime.Name = "LblElapsedTime"
        Me.LblElapsedTime.Size = New System.Drawing.Size(45, 17)
        Me.LblElapsedTime.TabIndex = 160
        Me.LblElapsedTime.Text = "00:00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(199, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 14)
        Me.Label15.TabIndex = 161
        Me.Label15.Text = "hh:mm"
        '
        'FrmProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 575)
        Me.Controls.Add(Me.BtnDesign)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.PnlForm)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.DgvProjects)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.BtnProjectThreads)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmProject"
        Me.Text = "Projects"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlForm.ResumeLayout(False)
        Me.PnlForm.PerformLayout()
        CType(Me.NudOriginY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudOriginX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid10Colour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid5Colour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid1Colour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFabricColour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnNew As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents Label44 As Label
    Friend WithEvents DgvProjects As DataGridView
    Friend WithEvents PnlForm As Panel
    Friend WithEvents LblSelectedProject As Label
    Friend WithEvents LblProjectId As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtName As TextBox
    Friend WithEvents BtnClose As Button
    Friend WithEvents projectId As DataGridViewTextBoxColumn
    Friend WithEvents projectName As DataGridViewTextBoxColumn
    Friend WithEvents BtnProjectThreads As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NudFabricHeight As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents NudFabricWidth As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NudDesignHeight As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents NudDesignWidth As NumericUpDown
    Friend WithEvents CbFabricColour As ComboBox
    Friend WithEvents PicFabricColour As PictureBox
    Friend WithEvents CbGrid10Colour As ComboBox
    Friend WithEvents PicGrid10Colour As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CbGrid5Colour As ComboBox
    Friend WithEvents PicGrid5Colour As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CbGrid1Colour As ComboBox
    Friend WithEvents PicGrid1Colour As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents BtnDesign As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents NudOriginY As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents NudOriginX As NumericUpDown
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MnuButton As ToolStripMenuItem
    Friend WithEvents MnuLogging As ToolStripMenuItem
    Friend WithEvents MnuOptions As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuDesign As ToolStripMenuItem
    Friend WithEvents MnuShowLog As ToolStripMenuItem
    Friend WithEvents MnuDebugOn As ToolStripMenuItem
    Friend WithEvents MnuUndoOn As ToolStripMenuItem
    Friend WithEvents MnuPreferences As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MnuSymbols As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents MnuThreads As ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuBackup As ToolStripMenuItem
    Friend WithEvents MnuRestore As ToolStripMenuItem
    Friend WithEvents MnuOpenDesign As ToolStripMenuItem
    Friend WithEvents MnuResizeDesign As ToolStripMenuItem
    Friend WithEvents Label14 As Label
    Friend WithEvents LblElapsedTime As Label
    Friend WithEvents LblEndTime As Label
    Friend WithEvents LblStartTime As Label
    Friend WithEvents Label15 As Label
End Class
