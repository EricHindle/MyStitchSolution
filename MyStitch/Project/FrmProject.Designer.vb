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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.LblOrigin = New System.Windows.Forms.Label()
        Me.LblFilename = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnProjectThreads = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NudFabricCount = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblElapsedTime = New System.Windows.Forms.Label()
        Me.LblEndTime = New System.Windows.Forms.Label()
        Me.LblStartTime = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
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
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.BtnDesign = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpenProjectFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpenSelectedProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpenDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuResizeDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuThreads = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFullThreadList = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProjectThreads = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProjectThreadSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBeadList = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBrandList = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMaintainSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProjectSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThreadCardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBuildCards = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPrintCards = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuImportImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuShowLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDebugOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPrintSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGlobalSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuTest = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlButtons = New System.Windows.Forms.Panel()
        Me.LblInstruction = New System.Windows.Forms.Label()
        Me.PnlInstruction = New System.Windows.Forms.Panel()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlForm.SuspendLayout()
        CType(Me.NudFabricCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFabricColour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.PnlButtons.SuspendLayout()
        Me.PnlInstruction.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 631)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(695, 22)
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
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(11, 450)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(80, 41)
        Me.BtnClear.TabIndex = 117
        Me.BtnClear.Text = "Clear the form"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete.Location = New System.Drawing.Point(1, 162)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 74)
        Me.BtnDelete.TabIndex = 116
        Me.BtnDelete.Text = "Remove the Project"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNew.Location = New System.Drawing.Point(18, 79)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(80, 74)
        Me.BtnNew.TabIndex = 114
        Me.BtnNew.Text = "Add a New Project"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnUpdate.Location = New System.Drawing.Point(1, 1)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(80, 74)
        Me.BtnUpdate.TabIndex = 115
        Me.BtnUpdate.Text = "Update the Project"
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProjects.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
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
        Me.DgvProjects.Size = New System.Drawing.Size(265, 495)
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
        Me.PnlForm.Controls.Add(Me.LblOrigin)
        Me.PnlForm.Controls.Add(Me.LblFilename)
        Me.PnlForm.Controls.Add(Me.Label10)
        Me.PnlForm.Controls.Add(Me.BtnProjectThreads)
        Me.PnlForm.Controls.Add(Me.Label9)
        Me.PnlForm.Controls.Add(Me.NudFabricCount)
        Me.PnlForm.Controls.Add(Me.Label15)
        Me.PnlForm.Controls.Add(Me.BtnClear)
        Me.PnlForm.Controls.Add(Me.LblElapsedTime)
        Me.PnlForm.Controls.Add(Me.LblEndTime)
        Me.PnlForm.Controls.Add(Me.LblStartTime)
        Me.PnlForm.Controls.Add(Me.Label14)
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
        Me.PnlForm.Location = New System.Drawing.Point(394, 62)
        Me.PnlForm.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlForm.Name = "PnlForm"
        Me.PnlForm.Size = New System.Drawing.Size(288, 495)
        Me.PnlForm.TabIndex = 126
        '
        'LblOrigin
        '
        Me.LblOrigin.AutoSize = True
        Me.LblOrigin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigin.Location = New System.Drawing.Point(48, 408)
        Me.LblOrigin.Name = "LblOrigin"
        Me.LblOrigin.Size = New System.Drawing.Size(88, 14)
        Me.LblOrigin.TabIndex = 166
        Me.LblOrigin.Text = "Origin  {0},{1}"
        '
        'LblFilename
        '
        Me.LblFilename.AutoEllipsis = True
        Me.LblFilename.AutoSize = True
        Me.LblFilename.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilename.ForeColor = System.Drawing.Color.Black
        Me.LblFilename.Location = New System.Drawing.Point(64, 181)
        Me.LblFilename.Name = "LblFilename"
        Me.LblFilename.Size = New System.Drawing.Size(58, 14)
        Me.LblFilename.TabIndex = 165
        Me.LblFilename.Text = "unknown"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(46, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 14)
        Me.Label10.TabIndex = 164
        Me.Label10.Text = "Design Filename"
        '
        'BtnProjectThreads
        '
        Me.BtnProjectThreads.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnProjectThreads.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnProjectThreads.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnProjectThreads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProjectThreads.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProjectThreads.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnProjectThreads.Location = New System.Drawing.Point(195, 450)
        Me.BtnProjectThreads.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProjectThreads.Name = "BtnProjectThreads"
        Me.BtnProjectThreads.Size = New System.Drawing.Size(80, 41)
        Me.BtnProjectThreads.TabIndex = 128
        Me.BtnProjectThreads.Text = "Select Threads"
        Me.BtnProjectThreads.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(48, 368)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 14)
        Me.Label9.TabIndex = 163
        Me.Label9.Text = "Fabric Count per inch"
        '
        'NudFabricCount
        '
        Me.NudFabricCount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricCount.Location = New System.Drawing.Point(195, 364)
        Me.NudFabricCount.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NudFabricCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFabricCount.Name = "NudFabricCount"
        Me.NudFabricCount.Size = New System.Drawing.Size(74, 22)
        Me.NudFabricCount.TabIndex = 162
        Me.NudFabricCount.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(199, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 14)
        Me.Label15.TabIndex = 161
        Me.Label15.Text = "hh:mm"
        '
        'LblElapsedTime
        '
        Me.LblElapsedTime.AutoSize = True
        Me.LblElapsedTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblElapsedTime.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblElapsedTime.Location = New System.Drawing.Point(148, 124)
        Me.LblElapsedTime.Name = "LblElapsedTime"
        Me.LblElapsedTime.Size = New System.Drawing.Size(45, 17)
        Me.LblElapsedTime.TabIndex = 160
        Me.LblElapsedTime.Text = "00:00"
        '
        'LblEndTime
        '
        Me.LblEndTime.AutoSize = True
        Me.LblEndTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndTime.ForeColor = System.Drawing.Color.Maroon
        Me.LblEndTime.Location = New System.Drawing.Point(148, 102)
        Me.LblEndTime.Name = "LblEndTime"
        Me.LblEndTime.Size = New System.Drawing.Size(76, 17)
        Me.LblEndTime.TabIndex = 159
        Me.LblEndTime.Text = "not started"
        '
        'LblStartTime
        '
        Me.LblStartTime.AutoSize = True
        Me.LblStartTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartTime.ForeColor = System.Drawing.Color.SeaGreen
        Me.LblStartTime.Location = New System.Drawing.Point(148, 80)
        Me.LblStartTime.Name = "LblStartTime"
        Me.LblStartTime.Size = New System.Drawing.Size(76, 17)
        Me.LblStartTime.TabIndex = 158
        Me.LblStartTime.Text = "not started"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(48, 125)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 14)
        Me.Label14.TabIndex = 157
        Me.Label14.Text = "Total work time"
        '
        'CbFabricColour
        '
        Me.CbFabricColour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbFabricColour.FormattingEnabled = True
        Me.CbFabricColour.Items.AddRange(New Object() {"White", "Cream", "Blue", "Pink", "Other"})
        Me.CbFabricColour.Location = New System.Drawing.Point(195, 333)
        Me.CbFabricColour.Name = "CbFabricColour"
        Me.CbFabricColour.Size = New System.Drawing.Size(79, 22)
        Me.CbFabricColour.TabIndex = 143
        '
        'PicFabricColour
        '
        Me.PicFabricColour.BackColor = System.Drawing.Color.White
        Me.PicFabricColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicFabricColour.Location = New System.Drawing.Point(166, 333)
        Me.PicFabricColour.Name = "PicFabricColour"
        Me.PicFabricColour.Size = New System.Drawing.Size(23, 23)
        Me.PicFabricColour.TabIndex = 142
        Me.PicFabricColour.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 336)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = "Fabric Colour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(48, 309)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 14)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Fabric Height"
        '
        'NudFabricHeight
        '
        Me.NudFabricHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricHeight.Location = New System.Drawing.Point(195, 305)
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
        Me.Label6.Location = New System.Drawing.Point(48, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 14)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "Fabric Width"
        '
        'NudFabricWidth
        '
        Me.NudFabricWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricWidth.Location = New System.Drawing.Point(195, 277)
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
        Me.Label5.Location = New System.Drawing.Point(46, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 14)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Design Height"
        '
        'NudDesignHeight
        '
        Me.NudDesignHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignHeight.Location = New System.Drawing.Point(193, 232)
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
        Me.Label4.Location = New System.Drawing.Point(46, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Design Width"
        '
        'NudDesignWidth
        '
        Me.NudDesignWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignWidth.Location = New System.Drawing.Point(193, 204)
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
        Me.Label3.Location = New System.Drawing.Point(48, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Finished"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 81)
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
        Me.LblSelectedProject.Size = New System.Drawing.Size(238, 29)
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
        Me.TxtName.Size = New System.Drawing.Size(202, 27)
        Me.TxtName.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(602, 577)
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
        Me.BtnDesign.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDesign.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDesign.Location = New System.Drawing.Point(0, 311)
        Me.BtnDesign.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDesign.Name = "BtnDesign"
        Me.BtnDesign.Size = New System.Drawing.Size(80, 66)
        Me.BtnDesign.TabIndex = 129
        Me.BtnDesign.Text = "Open the Design"
        Me.BtnDesign.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuButton})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(695, 28)
        Me.MenuStrip1.TabIndex = 130
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuButton
        '
        Me.MnuButton.AutoSize = False
        Me.MnuButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuOpenProjectFile, Me.MnuOpenSelectedProject, Me.MnuDesign, Me.MnuThreads, Me.MnuSymbols, Me.ThreadCardsToolStripMenuItem, Me.ToolStripSeparator2, Me.MnuImportImage, Me.ToolStripSeparator3, Me.MnuLogging, Me.BackupToolStripMenuItem, Me.MnuOptions, Me.ToolStripSeparator4, Me.MnuTest, Me.ToolStripSeparator1, Me.MnuExit})
        Me.MnuButton.Image = CType(resources.GetObject("MnuButton.Image"), System.Drawing.Image)
        Me.MnuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MnuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuButton.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.MnuButton.Name = "MnuButton"
        Me.MnuButton.Padding = New System.Windows.Forms.Padding(0)
        Me.MnuButton.Size = New System.Drawing.Size(122, 28)
        '
        'MnuOpenProjectFile
        '
        Me.MnuOpenProjectFile.Name = "MnuOpenProjectFile"
        Me.MnuOpenProjectFile.Size = New System.Drawing.Size(211, 22)
        Me.MnuOpenProjectFile.Text = "Open Project File"
        '
        'MnuOpenSelectedProject
        '
        Me.MnuOpenSelectedProject.Name = "MnuOpenSelectedProject"
        Me.MnuOpenSelectedProject.Size = New System.Drawing.Size(211, 22)
        Me.MnuOpenSelectedProject.Text = "Open Selected Project File"
        '
        'MnuDesign
        '
        Me.MnuDesign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuOpenDesign, Me.MnuResizeDesign})
        Me.MnuDesign.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuDesign.Name = "MnuDesign"
        Me.MnuDesign.Size = New System.Drawing.Size(211, 22)
        Me.MnuDesign.Text = "Design"
        '
        'MnuOpenDesign
        '
        Me.MnuOpenDesign.Name = "MnuOpenDesign"
        Me.MnuOpenDesign.Size = New System.Drawing.Size(142, 22)
        Me.MnuOpenDesign.Text = "Open Design"
        '
        'MnuResizeDesign
        '
        Me.MnuResizeDesign.Name = "MnuResizeDesign"
        Me.MnuResizeDesign.Size = New System.Drawing.Size(142, 22)
        Me.MnuResizeDesign.Text = "Resize"
        '
        'MnuThreads
        '
        Me.MnuThreads.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFullThreadList, Me.MnuProjectThreads, Me.MnuProjectThreadSymbols, Me.MnuBeadList, Me.MnuBrandList})
        Me.MnuThreads.Name = "MnuThreads"
        Me.MnuThreads.Size = New System.Drawing.Size(211, 22)
        Me.MnuThreads.Text = "Threads/Beads"
        '
        'MnuFullThreadList
        '
        Me.MnuFullThreadList.Name = "MnuFullThreadList"
        Me.MnuFullThreadList.Size = New System.Drawing.Size(199, 22)
        Me.MnuFullThreadList.Text = "Thread List"
        '
        'MnuProjectThreads
        '
        Me.MnuProjectThreads.Name = "MnuProjectThreads"
        Me.MnuProjectThreads.Size = New System.Drawing.Size(199, 22)
        Me.MnuProjectThreads.Text = "Project Threads"
        '
        'MnuProjectThreadSymbols
        '
        Me.MnuProjectThreadSymbols.Name = "MnuProjectThreadSymbols"
        Me.MnuProjectThreadSymbols.Size = New System.Drawing.Size(199, 22)
        Me.MnuProjectThreadSymbols.Text = "Project Thread Symbols"
        '
        'MnuBeadList
        '
        Me.MnuBeadList.Name = "MnuBeadList"
        Me.MnuBeadList.Size = New System.Drawing.Size(199, 22)
        Me.MnuBeadList.Text = "Bead List"
        '
        'MnuBrandList
        '
        Me.MnuBrandList.Name = "MnuBrandList"
        Me.MnuBrandList.Size = New System.Drawing.Size(199, 22)
        Me.MnuBrandList.Text = "Brand List"
        '
        'MnuSymbols
        '
        Me.MnuSymbols.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMaintainSymbols, Me.MnuProjectSymbols})
        Me.MnuSymbols.Name = "MnuSymbols"
        Me.MnuSymbols.Size = New System.Drawing.Size(211, 22)
        Me.MnuSymbols.Text = "Symbols"
        '
        'MnuMaintainSymbols
        '
        Me.MnuMaintainSymbols.Name = "MnuMaintainSymbols"
        Me.MnuMaintainSymbols.Size = New System.Drawing.Size(199, 22)
        Me.MnuMaintainSymbols.Text = "Maintain Symbols"
        '
        'MnuProjectSymbols
        '
        Me.MnuProjectSymbols.Name = "MnuProjectSymbols"
        Me.MnuProjectSymbols.Size = New System.Drawing.Size(199, 22)
        Me.MnuProjectSymbols.Text = "Project Thread Symbols"
        '
        'ThreadCardsToolStripMenuItem
        '
        Me.ThreadCardsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuBuildCards, Me.MnuPrintCards})
        Me.ThreadCardsToolStripMenuItem.Name = "ThreadCardsToolStripMenuItem"
        Me.ThreadCardsToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ThreadCardsToolStripMenuItem.Text = "Thread Cards"
        '
        'MnuBuildCards
        '
        Me.MnuBuildCards.Name = "MnuBuildCards"
        Me.MnuBuildCards.Size = New System.Drawing.Size(134, 22)
        Me.MnuBuildCards.Text = "Build Cards"
        '
        'MnuPrintCards
        '
        Me.MnuPrintCards.Name = "MnuPrintCards"
        Me.MnuPrintCards.Size = New System.Drawing.Size(134, 22)
        Me.MnuPrintCards.Text = "Print Cards"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(208, 6)
        '
        'MnuImportImage
        '
        Me.MnuImportImage.Name = "MnuImportImage"
        Me.MnuImportImage.Size = New System.Drawing.Size(211, 22)
        Me.MnuImportImage.Text = "Import Image"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(208, 6)
        '
        'MnuLogging
        '
        Me.MnuLogging.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuShowLog, Me.MnuDebugOn})
        Me.MnuLogging.Name = "MnuLogging"
        Me.MnuLogging.Size = New System.Drawing.Size(211, 22)
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
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
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
        Me.MnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPreferences, Me.MnuPrintSettings, Me.MnuGlobalSettings})
        Me.MnuOptions.Name = "MnuOptions"
        Me.MnuOptions.Size = New System.Drawing.Size(211, 22)
        Me.MnuOptions.Text = "Preferences"
        '
        'MnuPreferences
        '
        Me.MnuPreferences.Name = "MnuPreferences"
        Me.MnuPreferences.Size = New System.Drawing.Size(153, 22)
        Me.MnuPreferences.Text = "Preferences"
        '
        'MnuPrintSettings
        '
        Me.MnuPrintSettings.Name = "MnuPrintSettings"
        Me.MnuPrintSettings.Size = New System.Drawing.Size(153, 22)
        Me.MnuPrintSettings.Text = "Print Settings"
        '
        'MnuGlobalSettings
        '
        Me.MnuGlobalSettings.Name = "MnuGlobalSettings"
        Me.MnuGlobalSettings.Size = New System.Drawing.Size(153, 22)
        Me.MnuGlobalSettings.Text = "Global Settings"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(208, 6)
        '
        'MnuTest
        '
        Me.MnuTest.Name = "MnuTest"
        Me.MnuTest.Size = New System.Drawing.Size(211, 22)
        Me.MnuTest.Text = "Test"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(208, 6)
        '
        'MnuExit
        '
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.Size = New System.Drawing.Size(211, 22)
        Me.MnuExit.Text = "Exit"
        '
        'PnlButtons
        '
        Me.PnlButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PnlButtons.Controls.Add(Me.BtnUpdate)
        Me.PnlButtons.Controls.Add(Me.BtnDesign)
        Me.PnlButtons.Controls.Add(Me.BtnDelete)
        Me.PnlButtons.Location = New System.Drawing.Point(16, 176)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(82, 381)
        Me.PnlButtons.TabIndex = 131
        '
        'LblInstruction
        '
        Me.LblInstruction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblInstruction.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstruction.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblInstruction.Location = New System.Drawing.Point(4, 10)
        Me.LblInstruction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblInstruction.Name = "LblInstruction"
        Me.LblInstruction.Size = New System.Drawing.Size(537, 19)
        Me.LblInstruction.TabIndex = 132
        Me.LblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlInstruction
        '
        Me.PnlInstruction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlInstruction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlInstruction.Controls.Add(Me.LblInstruction)
        Me.PnlInstruction.Location = New System.Drawing.Point(18, 577)
        Me.PnlInstruction.Name = "PnlInstruction"
        Me.PnlInstruction.Size = New System.Drawing.Size(549, 40)
        Me.PnlInstruction.TabIndex = 133
        '
        'FrmProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 653)
        Me.Controls.Add(Me.PnlInstruction)
        Me.Controls.Add(Me.PnlButtons)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.PnlForm)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.DgvProjects)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(711, 692)
        Me.Name = "FrmProject"
        Me.Text = "Projects"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlForm.ResumeLayout(False)
        Me.PnlForm.PerformLayout()
        CType(Me.NudFabricCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFabricColour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PnlButtons.ResumeLayout(False)
        Me.PnlInstruction.ResumeLayout(False)
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
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents BtnDesign As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MnuButton As ToolStripMenuItem
    Friend WithEvents MnuLogging As ToolStripMenuItem
    Friend WithEvents MnuOptions As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MnuExit As ToolStripMenuItem
    Friend WithEvents MnuDesign As ToolStripMenuItem
    Friend WithEvents MnuShowLog As ToolStripMenuItem
    Friend WithEvents MnuDebugOn As ToolStripMenuItem
    Friend WithEvents MnuPreferences As ToolStripMenuItem
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
    Friend WithEvents MnuFullThreadList As ToolStripMenuItem
    Friend WithEvents MnuProjectThreads As ToolStripMenuItem
    Friend WithEvents MnuProjectThreadSymbols As ToolStripMenuItem
    Friend WithEvents MnuMaintainSymbols As ToolStripMenuItem
    Friend WithEvents MnuProjectSymbols As ToolStripMenuItem
    Friend WithEvents ThreadCardsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuBuildCards As ToolStripMenuItem
    Friend WithEvents MnuPrintCards As ToolStripMenuItem
    Friend WithEvents MnuGlobalSettings As ToolStripMenuItem
    Friend WithEvents MnuPrintSettings As ToolStripMenuItem
    Friend WithEvents MnuOpenProjectFile As ToolStripMenuItem
    Friend WithEvents MnuOpenSelectedProject As ToolStripMenuItem
    Friend WithEvents Label9 As Label
    Friend WithEvents NudFabricCount As NumericUpDown
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MnuImportImage As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents MnuTest As ToolStripMenuItem
    Friend WithEvents Label10 As Label
    Friend WithEvents LblFilename As Label
    Friend WithEvents PnlButtons As Panel
    Friend WithEvents LblInstruction As Label
    Friend WithEvents PnlInstruction As Panel
    Friend WithEvents LblOrigin As Label
    Friend WithEvents MnuBeadList As ToolStripMenuItem
    Friend WithEvents MnuBrandList As ToolStripMenuItem
End Class
