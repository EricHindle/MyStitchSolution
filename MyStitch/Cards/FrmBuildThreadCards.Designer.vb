' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBuildThreadCards
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuildThreadCards))
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnAuto = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.DgvProjects = New System.Windows.Forms.DataGridView()
        Me.projectId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.projectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NudMaxThreads = New System.Windows.Forms.NumericUpDown()
        Me.LblMaxThreads = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LbCards = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgvCardThreads = New System.Windows.Forms.DataGridView()
        Me.cardthreadid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cardthreadname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cardthreadno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cardThreadSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cardthreadcolour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.DgvThreads = New System.Windows.Forms.DataGridView()
        Me.threadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.threadselected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LblCardNo = New System.Windows.Forms.Label()
        Me.PnlThreads = New System.Windows.Forms.Panel()
        Me.PnlCardThreads = New System.Windows.Forms.Panel()
        Me.BtnRemoveThread = New System.Windows.Forms.Button()
        Me.BtnAddThread = New System.Windows.Forms.Button()
        Me.BtnDown = New System.Windows.Forms.Button()
        Me.BtnUp = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkShowStock = New System.Windows.Forms.CheckBox()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMaxThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvCardThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlThreads.SuspendLayout()
        Me.PnlCardThreads.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete.Location = New System.Drawing.Point(19, 220)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 55)
        Me.BtnDelete.TabIndex = 124
        Me.BtnDelete.Text = "Delete Card"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnAuto
        '
        Me.BtnAuto.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnAuto.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAuto.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAuto.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnAuto.Location = New System.Drawing.Point(19, 36)
        Me.BtnAuto.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAuto.Name = "BtnAuto"
        Me.BtnAuto.Size = New System.Drawing.Size(80, 40)
        Me.BtnAuto.TabIndex = 123
        Me.BtnAuto.Text = "Auto"
        Me.BtnAuto.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(881, 496)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 133
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
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
        Me.DgvProjects.Location = New System.Drawing.Point(117, 49)
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
        Me.DgvProjects.Size = New System.Drawing.Size(265, 212)
        Me.DgvProjects.TabIndex = 134
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
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(123, 22)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(100, 23)
        Me.Label44.TabIndex = 135
        Me.Label44.Text = "PROJECTS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(4, 10)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 23)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "PALETTE THREADS"
        '
        'NudMaxThreads
        '
        Me.NudMaxThreads.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudMaxThreads.Location = New System.Drawing.Point(563, 494)
        Me.NudMaxThreads.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NudMaxThreads.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMaxThreads.Name = "NudMaxThreads"
        Me.NudMaxThreads.Size = New System.Drawing.Size(46, 26)
        Me.NudMaxThreads.TabIndex = 137
        Me.NudMaxThreads.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'LblMaxThreads
        '
        Me.LblMaxThreads.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblMaxThreads.AutoSize = True
        Me.LblMaxThreads.Location = New System.Drawing.Point(400, 496)
        Me.LblMaxThreads.Name = "LblMaxThreads"
        Me.LblMaxThreads.Size = New System.Drawing.Size(156, 18)
        Me.LblMaxThreads.TabIndex = 138
        Me.LblMaxThreads.Text = "Max Threads per Card"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(123, 273)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 23)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "CARDS"
        '
        'LbCards
        '
        Me.LbCards.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LbCards.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.LbCards.FormattingEnabled = True
        Me.LbCards.ItemHeight = 18
        Me.LbCards.Location = New System.Drawing.Point(127, 308)
        Me.LbCards.Name = "LbCards"
        Me.LbCards.Size = New System.Drawing.Size(84, 130)
        Me.LbCards.TabIndex = 149
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(32, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 23)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "CARD THREADS"
        '
        'DgvCardThreads
        '
        Me.DgvCardThreads.AllowUserToAddRows = False
        Me.DgvCardThreads.AllowUserToDeleteRows = False
        Me.DgvCardThreads.AllowUserToResizeRows = False
        Me.DgvCardThreads.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgvCardThreads.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvCardThreads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvCardThreads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvCardThreads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCardThreads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cardthreadid, Me.cardthreadname, Me.cardthreadno, Me.cardThreadSeq, Me.cardthreadcolour})
        Me.DgvCardThreads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvCardThreads.Location = New System.Drawing.Point(36, 33)
        Me.DgvCardThreads.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvCardThreads.Name = "DgvCardThreads"
        Me.DgvCardThreads.ReadOnly = True
        Me.DgvCardThreads.RowHeadersVisible = False
        Me.DgvCardThreads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.DgvCardThreads.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvCardThreads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvCardThreads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DgvCardThreads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvCardThreads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCardThreads.Size = New System.Drawing.Size(245, 411)
        Me.DgvCardThreads.TabIndex = 151
        '
        'cardthreadid
        '
        Me.cardthreadid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cardthreadid.HeaderText = "Id"
        Me.cardthreadid.Name = "cardthreadid"
        Me.cardthreadid.ReadOnly = True
        Me.cardthreadid.Visible = False
        '
        'cardthreadname
        '
        Me.cardthreadname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cardthreadname.HeaderText = "Name"
        Me.cardthreadname.Name = "cardthreadname"
        Me.cardthreadname.ReadOnly = True
        '
        'cardthreadno
        '
        Me.cardthreadno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cardthreadno.HeaderText = "No."
        Me.cardthreadno.Name = "cardthreadno"
        Me.cardthreadno.ReadOnly = True
        Me.cardthreadno.Width = 50
        '
        'cardThreadSeq
        '
        Me.cardThreadSeq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cardThreadSeq.HeaderText = "Seq"
        Me.cardThreadSeq.Name = "cardThreadSeq"
        Me.cardThreadSeq.ReadOnly = True
        Me.cardThreadSeq.Visible = False
        Me.cardThreadSeq.Width = 30
        '
        'cardthreadcolour
        '
        Me.cardthreadcolour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cardthreadcolour.HeaderText = "Colour"
        Me.cardthreadcolour.Name = "cardthreadcolour"
        Me.cardthreadcolour.ReadOnly = True
        Me.cardthreadcolour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cardthreadcolour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cardthreadcolour.Width = 60
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnAdd.Location = New System.Drawing.Point(19, 118)
        Me.BtnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(80, 52)
        Me.BtnAdd.TabIndex = 153
        Me.BtnAdd.Text = "New Card"
        Me.BtnAdd.UseVisualStyleBackColor = False
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvThreads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvThreads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvThreads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.threadId, Me.threadName, Me.threadNo, Me.threadSortNumber, Me.threadColour, Me.threadselected})
        Me.DgvThreads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvThreads.Location = New System.Drawing.Point(4, 37)
        Me.DgvThreads.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvThreads.MultiSelect = False
        Me.DgvThreads.Name = "DgvThreads"
        Me.DgvThreads.RowHeadersVisible = False
        Me.DgvThreads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DgvThreads.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvThreads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvThreads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DgvThreads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvThreads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvThreads.Size = New System.Drawing.Size(260, 415)
        Me.DgvThreads.TabIndex = 154
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
        Me.threadSortNumber.HeaderText = "sort"
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
        'LblCardNo
        '
        Me.LblCardNo.AutoSize = True
        Me.LblCardNo.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCardNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.LblCardNo.Location = New System.Drawing.Point(216, 6)
        Me.LblCardNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCardNo.Name = "LblCardNo"
        Me.LblCardNo.Size = New System.Drawing.Size(21, 23)
        Me.LblCardNo.TabIndex = 155
        Me.LblCardNo.Text = "0"
        '
        'PnlThreads
        '
        Me.PnlThreads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlThreads.Controls.Add(Me.PnlCardThreads)
        Me.PnlThreads.Controls.Add(Me.Label7)
        Me.PnlThreads.Controls.Add(Me.DgvThreads)
        Me.PnlThreads.Location = New System.Drawing.Point(399, 12)
        Me.PnlThreads.Name = "PnlThreads"
        Me.PnlThreads.Size = New System.Drawing.Size(563, 455)
        Me.PnlThreads.TabIndex = 156
        '
        'PnlCardThreads
        '
        Me.PnlCardThreads.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlCardThreads.Controls.Add(Me.BtnRemoveThread)
        Me.PnlCardThreads.Controls.Add(Me.BtnAddThread)
        Me.PnlCardThreads.Controls.Add(Me.BtnDown)
        Me.PnlCardThreads.Controls.Add(Me.BtnUp)
        Me.PnlCardThreads.Controls.Add(Me.DgvCardThreads)
        Me.PnlCardThreads.Controls.Add(Me.LblCardNo)
        Me.PnlCardThreads.Controls.Add(Me.Label2)
        Me.PnlCardThreads.Location = New System.Drawing.Point(275, 4)
        Me.PnlCardThreads.Name = "PnlCardThreads"
        Me.PnlCardThreads.Size = New System.Drawing.Size(285, 448)
        Me.PnlCardThreads.TabIndex = 155
        '
        'BtnRemoveThread
        '
        Me.BtnRemoveThread.BackgroundImage = Global.MyStitch.My.Resources.Resources.left24
        Me.BtnRemoveThread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRemoveThread.Location = New System.Drawing.Point(6, 217)
        Me.BtnRemoveThread.Name = "BtnRemoveThread"
        Me.BtnRemoveThread.Size = New System.Drawing.Size(26, 26)
        Me.BtnRemoveThread.TabIndex = 159
        Me.ToolTip1.SetToolTip(Me.BtnRemoveThread, "Remove thread")
        Me.BtnRemoveThread.UseVisualStyleBackColor = True
        '
        'BtnAddThread
        '
        Me.BtnAddThread.BackgroundImage = Global.MyStitch.My.Resources.Resources.right24
        Me.BtnAddThread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAddThread.Location = New System.Drawing.Point(6, 185)
        Me.BtnAddThread.Name = "BtnAddThread"
        Me.BtnAddThread.Size = New System.Drawing.Size(26, 26)
        Me.BtnAddThread.TabIndex = 158
        Me.ToolTip1.SetToolTip(Me.BtnAddThread, "Add ProjectThread")
        Me.BtnAddThread.UseVisualStyleBackColor = True
        '
        'BtnDown
        '
        Me.BtnDown.BackgroundImage = Global.MyStitch.My.Resources.Resources.down24
        Me.BtnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnDown.Location = New System.Drawing.Point(6, 116)
        Me.BtnDown.Name = "BtnDown"
        Me.BtnDown.Size = New System.Drawing.Size(26, 26)
        Me.BtnDown.TabIndex = 157
        Me.ToolTip1.SetToolTip(Me.BtnDown, "Move thread down")
        Me.BtnDown.UseVisualStyleBackColor = True
        '
        'BtnUp
        '
        Me.BtnUp.BackgroundImage = Global.MyStitch.My.Resources.Resources.up24
        Me.BtnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnUp.Location = New System.Drawing.Point(6, 84)
        Me.BtnUp.Name = "BtnUp"
        Me.BtnUp.Size = New System.Drawing.Size(26, 26)
        Me.BtnUp.TabIndex = 156
        Me.ToolTip1.SetToolTip(Me.BtnUp, "Move thread up")
        Me.BtnUp.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(974, 22)
        Me.StatusStrip1.TabIndex = 157
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'ChkShowStock
        '
        Me.ChkShowStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkShowStock.AutoSize = True
        Me.ChkShowStock.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkShowStock.Location = New System.Drawing.Point(259, 308)
        Me.ChkShowStock.Name = "ChkShowStock"
        Me.ChkShowStock.Size = New System.Drawing.Size(123, 18)
        Me.ChkShowStock.TabIndex = 158
        Me.ChkShowStock.Text = "Show stock levels"
        Me.ChkShowStock.UseVisualStyleBackColor = True
        '
        'FrmBuildThreadCards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 562)
        Me.Controls.Add(Me.ChkShowStock)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PnlThreads)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LbCards)
        Me.Controls.Add(Me.LblMaxThreads)
        Me.Controls.Add(Me.NudMaxThreads)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.DgvProjects)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnAuto)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmBuildThreadCards"
        Me.Text = "Build ProjectThread Cards"
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMaxThreads, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvCardThreads, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlThreads.ResumeLayout(False)
        Me.PnlThreads.PerformLayout()
        Me.PnlCardThreads.ResumeLayout(False)
        Me.PnlCardThreads.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnAuto As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents DgvProjects As DataGridView
    Friend WithEvents projectId As DataGridViewTextBoxColumn
    Friend WithEvents projectName As DataGridViewTextBoxColumn
    Friend WithEvents Label44 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NudMaxThreads As NumericUpDown
    Friend WithEvents LblMaxThreads As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LbCards As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DgvCardThreads As DataGridView
    Friend WithEvents BtnAdd As Button
    Friend WithEvents DgvThreads As DataGridView
    Friend WithEvents LblCardNo As Label
    Friend WithEvents PnlThreads As Panel
    Friend WithEvents PnlCardThreads As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BtnRemoveThread As Button
    Friend WithEvents BtnAddThread As Button
    Friend WithEvents BtnDown As Button
    Friend WithEvents BtnUp As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents threadId As DataGridViewTextBoxColumn
    Friend WithEvents threadName As DataGridViewTextBoxColumn
    Friend WithEvents threadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents threadColour As DataGridViewImageColumn
    Friend WithEvents threadselected As DataGridViewCheckBoxColumn
    Friend WithEvents cardthreadid As DataGridViewTextBoxColumn
    Friend WithEvents cardthreadname As DataGridViewTextBoxColumn
    Friend WithEvents cardthreadno As DataGridViewTextBoxColumn
    Friend WithEvents cardThreadSeq As DataGridViewTextBoxColumn
    Friend WithEvents cardthreadcolour As DataGridViewImageColumn
    Friend WithEvents ChkShowStock As CheckBox
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents threadNo As DataGridViewTextBoxColumn
End Class
