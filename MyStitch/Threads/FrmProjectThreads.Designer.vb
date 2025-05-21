' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProjectThreads
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProjectThreads))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.DgvProjects = New System.Windows.Forms.DataGridView()
        Me.projectId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.projectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.DgvThreads = New System.Windows.Forms.DataGridView()
        Me.threadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThreadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.threadselected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnAddThreads = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnGenerateCards = New System.Windows.Forms.Button()
        Me.PnlThreads = New System.Windows.Forms.Panel()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkShowStock = New System.Windows.Forms.CheckBox()
        Me.TxtPaletteList = New System.Windows.Forms.TextBox()
        Me.BtnPaletteList = New System.Windows.Forms.Button()
        Me.BtnCopy = New System.Windows.Forms.Button()
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.BtnSelAll = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnImport = New System.Windows.Forms.Button()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.PnlThreads.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(9, 10)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 23)
        Me.Label7.TabIndex = 145
        Me.Label7.Text = "THREADS"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(13, 21)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(100, 23)
        Me.Label44.TabIndex = 144
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProjects.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvProjects.GridColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.DgvProjects.Location = New System.Drawing.Point(17, 53)
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
        Me.DgvProjects.Size = New System.Drawing.Size(265, 308)
        Me.DgvProjects.TabIndex = 143
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
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(570, 538)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 31)
        Me.BtnClose.TabIndex = 142
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
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
        Me.DgvThreads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.threadId, Me.threadName, Me.ThreadNo, Me.threadSortNumber, Me.threadColour, Me.threadselected})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvThreads.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvThreads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvThreads.Location = New System.Drawing.Point(13, 41)
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
        Me.DgvThreads.Size = New System.Drawing.Size(340, 416)
        Me.DgvThreads.TabIndex = 140
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
        'ThreadNo
        '
        Me.ThreadNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ThreadNo.HeaderText = "No."
        Me.ThreadNo.Name = "ThreadNo"
        Me.ThreadNo.ReadOnly = True
        Me.ThreadNo.Width = 50
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
        'BtnUpdate
        '
        Me.BtnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnUpdate.Location = New System.Drawing.Point(17, 431)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(200, 40)
        Me.BtnUpdate.TabIndex = 137
        Me.BtnUpdate.Text = "Update Project"
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 578)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(663, 22)
        Me.StatusStrip1.TabIndex = 146
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'BtnAddThreads
        '
        Me.BtnAddThreads.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnAddThreads.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddThreads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddThreads.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddThreads.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnAddThreads.Location = New System.Drawing.Point(177, 7)
        Me.BtnAddThreads.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAddThreads.Name = "BtnAddThreads"
        Me.BtnAddThreads.Size = New System.Drawing.Size(158, 29)
        Me.BtnAddThreads.TabIndex = 147
        Me.BtnAddThreads.Text = "Add Missing Threads"
        Me.BtnAddThreads.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(17, 378)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(86, 42)
        Me.BtnClear.TabIndex = 148
        Me.BtnClear.Text = "Clear Thread Selections"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnGenerateCards
        '
        Me.BtnGenerateCards.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerateCards.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnGenerateCards.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnGenerateCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGenerateCards.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerateCards.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnGenerateCards.Location = New System.Drawing.Point(17, 486)
        Me.BtnGenerateCards.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGenerateCards.Name = "BtnGenerateCards"
        Me.BtnGenerateCards.Size = New System.Drawing.Size(200, 40)
        Me.BtnGenerateCards.TabIndex = 149
        Me.BtnGenerateCards.Text = "Build Project Cards"
        Me.BtnGenerateCards.UseVisualStyleBackColor = False
        '
        'PnlThreads
        '
        Me.PnlThreads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlThreads.Controls.Add(Me.BtnAddThreads)
        Me.PnlThreads.Controls.Add(Me.DgvThreads)
        Me.PnlThreads.Controls.Add(Me.Label7)
        Me.PnlThreads.Location = New System.Drawing.Point(285, 12)
        Me.PnlThreads.Name = "PnlThreads"
        Me.PnlThreads.Size = New System.Drawing.Size(365, 461)
        Me.PnlThreads.TabIndex = 150
        Me.PnlThreads.Visible = False
        '
        'TxtNumber
        '
        Me.TxtNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtNumber.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.Location = New System.Drawing.Point(547, 480)
        Me.TxtNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(73, 27)
        Me.TxtNumber.TabIndex = 151
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(507, 486)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Find"
        '
        'ChkShowStock
        '
        Me.ChkShowStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkShowStock.AutoSize = True
        Me.ChkShowStock.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkShowStock.Location = New System.Drawing.Point(285, 486)
        Me.ChkShowStock.Name = "ChkShowStock"
        Me.ChkShowStock.Size = New System.Drawing.Size(118, 18)
        Me.ChkShowStock.TabIndex = 153
        Me.ChkShowStock.Text = "Show stock level"
        Me.ChkShowStock.UseVisualStyleBackColor = True
        '
        'TxtPaletteList
        '
        Me.TxtPaletteList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtPaletteList.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaletteList.Location = New System.Drawing.Point(17, 554)
        Me.TxtPaletteList.Name = "TxtPaletteList"
        Me.TxtPaletteList.Size = New System.Drawing.Size(394, 20)
        Me.TxtPaletteList.TabIndex = 155
        '
        'BtnPaletteList
        '
        Me.BtnPaletteList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPaletteList.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnPaletteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPaletteList.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPaletteList.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPaletteList.Location = New System.Drawing.Point(203, 378)
        Me.BtnPaletteList.Name = "BtnPaletteList"
        Me.BtnPaletteList.Size = New System.Drawing.Size(75, 42)
        Me.BtnPaletteList.TabIndex = 156
        Me.BtnPaletteList.Text = "Create palette list"
        Me.BtnPaletteList.UseVisualStyleBackColor = False
        '
        'BtnCopy
        '
        Me.BtnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCopy.FlatAppearance.BorderSize = 0
        Me.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCopy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '  Me.BtnCopy.Image = Global.MyStitchThreads.My.Resources.Resources.copyicon
        Me.BtnCopy.Location = New System.Drawing.Point(415, 549)
        Me.BtnCopy.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(28, 28)
        Me.BtnCopy.TabIndex = 157
        Me.BtnCopy.UseVisualStyleBackColor = True
        '
        'BtnPaste
        '
        Me.BtnPaste.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPaste.FlatAppearance.BorderSize = 0
        Me.BtnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPaste.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '   Me.BtnPaste.Image = Global.MyStitchThreads.My.Resources.Resources.paste
        Me.BtnPaste.Location = New System.Drawing.Point(445, 549)
        Me.BtnPaste.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(28, 28)
        Me.BtnPaste.TabIndex = 158
        Me.BtnPaste.UseVisualStyleBackColor = True
        '
        'BtnSelAll
        '
        Me.BtnSelAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSelAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnSelAll.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelAll.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelAll.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSelAll.Location = New System.Drawing.Point(119, 378)
        Me.BtnSelAll.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelAll.Name = "BtnSelAll"
        Me.BtnSelAll.Size = New System.Drawing.Size(68, 42)
        Me.BtnSelAll.TabIndex = 159
        Me.BtnSelAll.Text = "Select All Threads"
        Me.BtnSelAll.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 538)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Palette List"
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImport.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImport.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnImport.Location = New System.Drawing.Point(285, 521)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(126, 27)
        Me.BtnImport.TabIndex = 161
        Me.BtnImport.Text = "Import palette list"
        Me.BtnImport.UseVisualStyleBackColor = False
        '
        'FrmProjectThreads
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 600)
        Me.Controls.Add(Me.BtnImport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnSelAll)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.BtnCopy)
        Me.Controls.Add(Me.BtnPaletteList)
        Me.Controls.Add(Me.TxtPaletteList)
        Me.Controls.Add(Me.ChkShowStock)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.PnlThreads)
        Me.Controls.Add(Me.BtnGenerateCards)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.DgvProjects)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmProjectThreads"
        Me.Text = "Project Threads"
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PnlThreads.ResumeLayout(False)
        Me.PnlThreads.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents DgvProjects As DataGridView
    Friend WithEvents projectId As DataGridViewTextBoxColumn
    Friend WithEvents projectName As DataGridViewTextBoxColumn
    Friend WithEvents BtnClose As Button
    Friend WithEvents DgvThreads As DataGridView
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BtnAddThreads As Button
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnGenerateCards As Button
    Friend WithEvents PnlThreads As Panel
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents threadId As DataGridViewTextBoxColumn
    Friend WithEvents threadName As DataGridViewTextBoxColumn
    Friend WithEvents ThreadNo As DataGridViewTextBoxColumn
    Friend WithEvents threadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents threadColour As DataGridViewImageColumn
    Friend WithEvents threadselected As DataGridViewCheckBoxColumn
    Friend WithEvents ChkShowStock As CheckBox
    Friend WithEvents TxtPaletteList As TextBox
    Friend WithEvents BtnPaletteList As Button
    Friend WithEvents BtnCopy As Button
    Friend WithEvents BtnPaste As Button
    Friend WithEvents BtnSelAll As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnImport As Button
End Class
