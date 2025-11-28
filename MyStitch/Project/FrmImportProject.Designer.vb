' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportProject
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportProject))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtFilename = New System.Windows.Forms.TextBox()
        Me.PnlForm = New System.Windows.Forms.Panel()
        Me.LblOrigin = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NudFabricCount = New System.Windows.Forms.NumericUpDown()
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
        Me.LblSelectedProject = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PnlThreads = New System.Windows.Forms.Panel()
        Me.DgvThreads = New System.Windows.Forms.DataGridView()
        Me.threadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.threadselected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnlBeads = New System.Windows.Forms.Panel()
        Me.DgvBeads = New System.Windows.Forms.DataGridView()
        Me.BeadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.beadSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnImportNew = New System.Windows.Forms.Button()
        Me.BtnReplace = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblInstruction = New System.Windows.Forms.Label()
        Me.PnlForm.SuspendLayout()
        CType(Me.NudFabricCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFabricColour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PnlThreads.SuspendLayout()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBeads.SuspendLayout()
        CType(Me.DgvBeads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project file to import"
        '
        'TxtFilename
        '
        Me.TxtFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFilename.Location = New System.Drawing.Point(163, 22)
        Me.TxtFilename.Name = "TxtFilename"
        Me.TxtFilename.Size = New System.Drawing.Size(553, 24)
        Me.TxtFilename.TabIndex = 1
        '
        'PnlForm
        '
        Me.PnlForm.Controls.Add(Me.LblOrigin)
        Me.PnlForm.Controls.Add(Me.Label9)
        Me.PnlForm.Controls.Add(Me.NudFabricCount)
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
        Me.PnlForm.Controls.Add(Me.LblSelectedProject)
        Me.PnlForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PnlForm.Location = New System.Drawing.Point(27, 66)
        Me.PnlForm.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlForm.Name = "PnlForm"
        Me.PnlForm.Size = New System.Drawing.Size(251, 301)
        Me.PnlForm.TabIndex = 127
        '
        'LblOrigin
        '
        Me.LblOrigin.AutoSize = True
        Me.LblOrigin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigin.Location = New System.Drawing.Point(15, 251)
        Me.LblOrigin.Name = "LblOrigin"
        Me.LblOrigin.Size = New System.Drawing.Size(88, 14)
        Me.LblOrigin.TabIndex = 166
        Me.LblOrigin.Text = "Origin  {0},{1}"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 211)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 14)
        Me.Label9.TabIndex = 163
        Me.Label9.Text = "Fabric Count per inch"
        '
        'NudFabricCount
        '
        Me.NudFabricCount.Enabled = False
        Me.NudFabricCount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricCount.Location = New System.Drawing.Point(162, 207)
        Me.NudFabricCount.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NudFabricCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFabricCount.Name = "NudFabricCount"
        Me.NudFabricCount.Size = New System.Drawing.Size(74, 22)
        Me.NudFabricCount.TabIndex = 162
        Me.NudFabricCount.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'CbFabricColour
        '
        Me.CbFabricColour.Enabled = False
        Me.CbFabricColour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbFabricColour.FormattingEnabled = True
        Me.CbFabricColour.Items.AddRange(New Object() {"White", "Cream", "Blue", "Pink", "Other"})
        Me.CbFabricColour.Location = New System.Drawing.Point(162, 176)
        Me.CbFabricColour.Name = "CbFabricColour"
        Me.CbFabricColour.Size = New System.Drawing.Size(79, 22)
        Me.CbFabricColour.TabIndex = 143
        '
        'PicFabricColour
        '
        Me.PicFabricColour.BackColor = System.Drawing.Color.White
        Me.PicFabricColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicFabricColour.Enabled = False
        Me.PicFabricColour.Location = New System.Drawing.Point(133, 176)
        Me.PicFabricColour.Name = "PicFabricColour"
        Me.PicFabricColour.Size = New System.Drawing.Size(23, 23)
        Me.PicFabricColour.TabIndex = 142
        Me.PicFabricColour.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = "Fabric Colour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 14)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Fabric Height"
        '
        'NudFabricHeight
        '
        Me.NudFabricHeight.Enabled = False
        Me.NudFabricHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricHeight.Location = New System.Drawing.Point(162, 148)
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
        Me.Label6.Location = New System.Drawing.Point(15, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 14)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "Fabric Width"
        '
        'NudFabricWidth
        '
        Me.NudFabricWidth.Enabled = False
        Me.NudFabricWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFabricWidth.Location = New System.Drawing.Point(162, 120)
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
        Me.Label5.Location = New System.Drawing.Point(13, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 14)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Design Height"
        '
        'NudDesignHeight
        '
        Me.NudDesignHeight.Enabled = False
        Me.NudDesignHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignHeight.Location = New System.Drawing.Point(160, 75)
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
        Me.Label4.Location = New System.Drawing.Point(13, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Design Width"
        '
        'NudDesignWidth
        '
        Me.NudDesignWidth.Enabled = False
        Me.NudDesignWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudDesignWidth.Location = New System.Drawing.Point(160, 47)
        Me.NudDesignWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudDesignWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDesignWidth.Name = "NudDesignWidth"
        Me.NudDesignWidth.Size = New System.Drawing.Size(74, 22)
        Me.NudDesignWidth.TabIndex = 133
        Me.NudDesignWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblSelectedProject
        '
        Me.LblSelectedProject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSelectedProject.AutoEllipsis = True
        Me.LblSelectedProject.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectedProject.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSelectedProject.Location = New System.Drawing.Point(12, 15)
        Me.LblSelectedProject.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSelectedProject.Name = "LblSelectedProject"
        Me.LblSelectedProject.Size = New System.Drawing.Size(201, 20)
        Me.LblSelectedProject.TabIndex = 124
        Me.LblSelectedProject.Text = "PROJECT NAME"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(302, 66)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PnlThreads)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PnlBeads)
        Me.SplitContainer1.Size = New System.Drawing.Size(317, 507)
        Me.SplitContainer1.SplitterDistance = 365
        Me.SplitContainer1.TabIndex = 128
        '
        'PnlThreads
        '
        Me.PnlThreads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlThreads.Controls.Add(Me.DgvThreads)
        Me.PnlThreads.Controls.Add(Me.Label2)
        Me.PnlThreads.Location = New System.Drawing.Point(3, 3)
        Me.PnlThreads.Name = "PnlThreads"
        Me.PnlThreads.Size = New System.Drawing.Size(308, 355)
        Me.PnlThreads.TabIndex = 0
        '
        'DgvThreads
        '
        Me.DgvThreads.AllowUserToAddRows = False
        Me.DgvThreads.AllowUserToDeleteRows = False
        Me.DgvThreads.AllowUserToResizeRows = False
        Me.DgvThreads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvThreads.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvThreads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvThreads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvThreads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvThreads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.threadId, Me.threadName, Me.threadNo, Me.threadSortNumber, Me.threadColour, Me.threadselected})
        Me.DgvThreads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvThreads.Location = New System.Drawing.Point(10, 41)
        Me.DgvThreads.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvThreads.MultiSelect = False
        Me.DgvThreads.Name = "DgvThreads"
        Me.DgvThreads.RowHeadersVisible = False
        Me.DgvThreads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DgvThreads.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvThreads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvThreads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvThreads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvThreads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvThreads.Size = New System.Drawing.Size(293, 310)
        Me.DgvThreads.TabIndex = 2
        '
        'threadId
        '
        Me.threadId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadId.HeaderText = "Id"
        Me.threadId.Name = "threadId"
        Me.threadId.ReadOnly = True
        Me.threadId.Visible = False
        '
        'threadName
        '
        Me.threadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.threadName.HeaderText = "Name"
        Me.threadName.Name = "threadName"
        Me.threadName.ReadOnly = True
        '
        'threadNo
        '
        Me.threadNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadNo.HeaderText = "No."
        Me.threadNo.Name = "threadNo"
        Me.threadNo.ReadOnly = True
        Me.threadNo.Width = 50
        '
        'threadSortNumber
        '
        Me.threadSortNumber.HeaderText = "Sort"
        Me.threadSortNumber.Name = "threadSortNumber"
        Me.threadSortNumber.ReadOnly = True
        Me.threadSortNumber.Visible = False
        '
        'threadColour
        '
        Me.threadColour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadColour.HeaderText = "Colour"
        Me.threadColour.Name = "threadColour"
        Me.threadColour.ReadOnly = True
        Me.threadColour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.threadColour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.threadColour.Width = 60
        '
        'threadselected
        '
        Me.threadselected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadselected.HeaderText = ""
        Me.threadselected.Name = "threadselected"
        Me.threadselected.Width = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "THREADS"
        '
        'PnlBeads
        '
        Me.PnlBeads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlBeads.Controls.Add(Me.DgvBeads)
        Me.PnlBeads.Controls.Add(Me.Label3)
        Me.PnlBeads.Location = New System.Drawing.Point(3, 3)
        Me.PnlBeads.Name = "PnlBeads"
        Me.PnlBeads.Size = New System.Drawing.Size(308, 128)
        Me.PnlBeads.TabIndex = 22
        '
        'DgvBeads
        '
        Me.DgvBeads.AllowUserToAddRows = False
        Me.DgvBeads.AllowUserToDeleteRows = False
        Me.DgvBeads.AllowUserToResizeRows = False
        Me.DgvBeads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvBeads.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvBeads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvBeads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvBeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBeads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BeadId, Me.BeadName, Me.BeadNo, Me.BeadSortNumber, Me.BeadColour, Me.beadSelected})
        Me.DgvBeads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvBeads.Location = New System.Drawing.Point(10, 41)
        Me.DgvBeads.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvBeads.MultiSelect = False
        Me.DgvBeads.Name = "DgvBeads"
        Me.DgvBeads.RowHeadersVisible = False
        Me.DgvBeads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DgvBeads.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvBeads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvBeads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvBeads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvBeads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvBeads.Size = New System.Drawing.Size(293, 83)
        Me.DgvBeads.TabIndex = 2
        '
        'BeadId
        '
        Me.BeadId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BeadId.HeaderText = "Id"
        Me.BeadId.Name = "BeadId"
        Me.BeadId.ReadOnly = True
        Me.BeadId.Visible = False
        '
        'BeadName
        '
        Me.BeadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BeadName.HeaderText = "Name"
        Me.BeadName.Name = "BeadName"
        Me.BeadName.ReadOnly = True
        '
        'BeadNo
        '
        Me.BeadNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BeadNo.HeaderText = "No."
        Me.BeadNo.Name = "BeadNo"
        Me.BeadNo.ReadOnly = True
        Me.BeadNo.Width = 50
        '
        'BeadSortNumber
        '
        Me.BeadSortNumber.HeaderText = "Sort"
        Me.BeadSortNumber.Name = "BeadSortNumber"
        Me.BeadSortNumber.ReadOnly = True
        Me.BeadSortNumber.Visible = False
        '
        'BeadColour
        '
        Me.BeadColour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BeadColour.HeaderText = "Colour"
        Me.BeadColour.Name = "BeadColour"
        Me.BeadColour.ReadOnly = True
        Me.BeadColour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BeadColour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BeadColour.Width = 60
        '
        'beadSelected
        '
        Me.beadSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.beadSelected.HeaderText = ""
        Me.beadSelected.Name = "beadSelected"
        Me.beadSelected.Width = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(9, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "BEADS"
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(636, 537)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 31)
        Me.BtnClose.TabIndex = 129
        Me.BtnClose.Text = "Cancel"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnImportNew
        '
        Me.BtnImportNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnImportNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnImportNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImportNew.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImportNew.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnImportNew.Location = New System.Drawing.Point(636, 88)
        Me.BtnImportNew.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnImportNew.Name = "BtnImportNew"
        Me.BtnImportNew.Size = New System.Drawing.Size(80, 76)
        Me.BtnImportNew.TabIndex = 130
        Me.BtnImportNew.Text = "Import as new Project"
        Me.BtnImportNew.UseVisualStyleBackColor = False
        '
        'BtnReplace
        '
        Me.BtnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReplace.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnReplace.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReplace.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReplace.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnReplace.Location = New System.Drawing.Point(636, 182)
        Me.BtnReplace.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnReplace.Name = "BtnReplace"
        Me.BtnReplace.Size = New System.Drawing.Size(80, 76)
        Me.BtnReplace.TabIndex = 131
        Me.BtnReplace.Text = "Replace existing Project"
        Me.BtnReplace.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.LblInstruction)
        Me.Panel1.Location = New System.Drawing.Point(27, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(251, 100)
        Me.Panel1.TabIndex = 132
        '
        'LblInstruction
        '
        Me.LblInstruction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblInstruction.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstruction.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblInstruction.Location = New System.Drawing.Point(4, 7)
        Me.LblInstruction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblInstruction.Name = "LblInstruction"
        Me.LblInstruction.Size = New System.Drawing.Size(239, 83)
        Me.LblInstruction.TabIndex = 133
        Me.LblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmImportProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 585)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnReplace)
        Me.Controls.Add(Me.BtnImportNew)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PnlForm)
        Me.Controls.Add(Me.TxtFilename)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmImportProject"
        Me.Text = "Import a Project"
        Me.PnlForm.ResumeLayout(False)
        Me.PnlForm.PerformLayout()
        CType(Me.NudFabricCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFabricColour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFabricWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDesignWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PnlThreads.ResumeLayout(False)
        Me.PnlThreads.PerformLayout()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBeads.ResumeLayout(False)
        Me.PnlBeads.PerformLayout()
        CType(Me.DgvBeads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtFilename As TextBox
    Friend WithEvents PnlForm As Panel
    Friend WithEvents LblOrigin As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents NudFabricCount As NumericUpDown
    Friend WithEvents CbFabricColour As ComboBox
    Friend WithEvents PicFabricColour As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NudFabricHeight As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents NudFabricWidth As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NudDesignHeight As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents NudDesignWidth As NumericUpDown
    Friend WithEvents LblSelectedProject As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PnlThreads As Panel
    Friend WithEvents DgvThreads As DataGridView
    Friend WithEvents threadId As DataGridViewTextBoxColumn
    Friend WithEvents threadName As DataGridViewTextBoxColumn
    Friend WithEvents threadNo As DataGridViewTextBoxColumn
    Friend WithEvents threadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents threadColour As DataGridViewImageColumn
    Friend WithEvents threadselected As DataGridViewCheckBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents PnlBeads As Panel
    Friend WithEvents DgvBeads As DataGridView
    Friend WithEvents BeadId As DataGridViewTextBoxColumn
    Friend WithEvents BeadName As DataGridViewTextBoxColumn
    Friend WithEvents BeadNo As DataGridViewTextBoxColumn
    Friend WithEvents BeadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents BeadColour As DataGridViewImageColumn
    Friend WithEvents beadSelected As DataGridViewCheckBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnImportNew As Button
    Friend WithEvents BtnReplace As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblInstruction As Label
End Class
