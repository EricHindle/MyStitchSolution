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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProjectThreads))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.DgvProjects = New System.Windows.Forms.DataGridView()
        Me.projectId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.projectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.DgvThreads = New System.Windows.Forms.DataGridView()
        Me.threadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.threadselected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.BtnLoadThreadList = New System.Windows.Forms.Button()
        Me.BtnAssignSymbols = New System.Windows.Forms.Button()
        Me.CbPalettes = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnLoadPalette = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PnlBeads = New System.Windows.Forms.Panel()
        Me.DgvBeads = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BeadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.beadSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.PnlThreads.SuspendLayout()
        Me.PnlBeads.SuspendLayout()
        CType(Me.DgvBeads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.Label7.TabIndex = 0
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
        Me.Label44.TabIndex = 18
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
        Me.DgvProjects.Size = New System.Drawing.Size(265, 259)
        Me.DgvProjects.TabIndex = 17
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
        Me.BtnClose.Location = New System.Drawing.Point(570, 561)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 31)
        Me.BtnClose.TabIndex = 15
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
        Me.DgvThreads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.threadId, Me.threadName, Me.threadNo, Me.threadSortNumber, Me.threadColour, Me.threadselected})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvThreads.DefaultCellStyle = DataGridViewCellStyle4
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
        Me.DgvThreads.Size = New System.Drawing.Size(338, 275)
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
        'BtnUpdate
        '
        Me.BtnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnUpdate.Location = New System.Drawing.Point(17, 511)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(161, 37)
        Me.BtnUpdate.TabIndex = 12
        Me.BtnUpdate.Text = "Update Project"
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 601)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(663, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(17, 320)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(86, 42)
        Me.BtnClear.TabIndex = 1
        Me.BtnClear.Text = "Clear Selections"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnGenerateCards
        '
        Me.BtnGenerateCards.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerateCards.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnGenerateCards.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnGenerateCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGenerateCards.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerateCards.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnGenerateCards.Location = New System.Drawing.Point(391, 511)
        Me.BtnGenerateCards.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGenerateCards.Name = "BtnGenerateCards"
        Me.BtnGenerateCards.Size = New System.Drawing.Size(161, 37)
        Me.BtnGenerateCards.TabIndex = 14
        Me.BtnGenerateCards.Text = "Build Project Cards"
        Me.BtnGenerateCards.UseVisualStyleBackColor = False
        '
        'PnlThreads
        '
        Me.PnlThreads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlThreads.Controls.Add(Me.DgvThreads)
        Me.PnlThreads.Controls.Add(Me.Label7)
        Me.PnlThreads.Location = New System.Drawing.Point(3, 3)
        Me.PnlThreads.Name = "PnlThreads"
        Me.PnlThreads.Size = New System.Drawing.Size(352, 320)
        Me.PnlThreads.TabIndex = 0
        Me.PnlThreads.Visible = False
        '
        'TxtNumber
        '
        Me.TxtNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNumber.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.Location = New System.Drawing.Point(547, 469)
        Me.TxtNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(73, 27)
        Me.TxtNumber.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(507, 475)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Find"
        '
        'ChkShowStock
        '
        Me.ChkShowStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkShowStock.AutoSize = True
        Me.ChkShowStock.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkShowStock.Location = New System.Drawing.Point(299, 474)
        Me.ChkShowStock.Name = "ChkShowStock"
        Me.ChkShowStock.Size = New System.Drawing.Size(118, 18)
        Me.ChkShowStock.TabIndex = 10
        Me.ChkShowStock.Text = "Show stock level"
        Me.ChkShowStock.UseVisualStyleBackColor = True
        '
        'TxtPaletteList
        '
        Me.TxtPaletteList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtPaletteList.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaletteList.Location = New System.Drawing.Point(17, 397)
        Me.TxtPaletteList.Name = "TxtPaletteList"
        Me.TxtPaletteList.Size = New System.Drawing.Size(178, 20)
        Me.TxtPaletteList.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtPaletteList, "Comma separated list of numbers")
        '
        'BtnPaletteList
        '
        Me.BtnPaletteList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPaletteList.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnPaletteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPaletteList.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPaletteList.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPaletteList.Location = New System.Drawing.Point(203, 320)
        Me.BtnPaletteList.Name = "BtnPaletteList"
        Me.BtnPaletteList.Size = New System.Drawing.Size(75, 42)
        Me.BtnPaletteList.TabIndex = 3
        Me.BtnPaletteList.Text = "Create thread list"
        Me.BtnPaletteList.UseVisualStyleBackColor = False
        '
        'BtnCopy
        '
        Me.BtnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCopy.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCopy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopy.Image = CType(resources.GetObject("BtnCopy.Image"), System.Drawing.Image)
        Me.BtnCopy.Location = New System.Drawing.Point(141, 374)
        Me.BtnCopy.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(21, 21)
        Me.BtnCopy.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.BtnCopy, "Copy list of numbers")
        Me.BtnCopy.UseVisualStyleBackColor = True
        '
        'BtnPaste
        '
        Me.BtnPaste.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPaste.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.BtnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPaste.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPaste.Image = Global.MyStitch.My.Resources.Resources.paste
        Me.BtnPaste.Location = New System.Drawing.Point(164, 374)
        Me.BtnPaste.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(21, 21)
        Me.BtnPaste.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.BtnPaste, "Paste list of numbers")
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
        Me.BtnSelAll.Location = New System.Drawing.Point(119, 320)
        Me.BtnSelAll.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelAll.Name = "BtnSelAll"
        Me.BtnSelAll.Size = New System.Drawing.Size(68, 42)
        Me.BtnSelAll.TabIndex = 2
        Me.BtnSelAll.Text = "Select All Threads"
        Me.BtnSelAll.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 381)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Bead Numbers"
        '
        'BtnLoadThreadList
        '
        Me.BtnLoadThreadList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnLoadThreadList.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnLoadThreadList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoadThreadList.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadThreadList.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLoadThreadList.Location = New System.Drawing.Point(201, 393)
        Me.BtnLoadThreadList.Name = "BtnLoadThreadList"
        Me.BtnLoadThreadList.Size = New System.Drawing.Size(81, 27)
        Me.BtnLoadThreadList.TabIndex = 5
        Me.BtnLoadThreadList.Text = "Add threads"
        Me.BtnLoadThreadList.UseVisualStyleBackColor = False
        '
        'BtnAssignSymbols
        '
        Me.BtnAssignSymbols.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAssignSymbols.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnAssignSymbols.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAssignSymbols.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAssignSymbols.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAssignSymbols.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnAssignSymbols.Location = New System.Drawing.Point(204, 511)
        Me.BtnAssignSymbols.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAssignSymbols.Name = "BtnAssignSymbols"
        Me.BtnAssignSymbols.Size = New System.Drawing.Size(161, 37)
        Me.BtnAssignSymbols.TabIndex = 13
        Me.BtnAssignSymbols.Text = "Assign Symbols"
        Me.BtnAssignSymbols.UseVisualStyleBackColor = False
        '
        'CbPalettes
        '
        Me.CbPalettes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CbPalettes.FormattingEnabled = True
        Me.CbPalettes.Location = New System.Drawing.Point(18, 444)
        Me.CbPalettes.Name = "CbPalettes"
        Me.CbPalettes.Size = New System.Drawing.Size(177, 21)
        Me.CbPalettes.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 428)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Palettes"
        '
        'BtnLoadPalette
        '
        Me.BtnLoadPalette.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnLoadPalette.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnLoadPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoadPalette.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadPalette.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLoadPalette.Location = New System.Drawing.Point(201, 440)
        Me.BtnLoadPalette.Name = "BtnLoadPalette"
        Me.BtnLoadPalette.Size = New System.Drawing.Size(81, 27)
        Me.BtnLoadPalette.TabIndex = 9
        Me.BtnLoadPalette.Text = "Load Palette"
        Me.BtnLoadPalette.UseVisualStyleBackColor = False
        '
        'PnlBeads
        '
        Me.PnlBeads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlBeads.Controls.Add(Me.DgvBeads)
        Me.PnlBeads.Controls.Add(Me.Label4)
        Me.PnlBeads.Location = New System.Drawing.Point(3, 3)
        Me.PnlBeads.Name = "PnlBeads"
        Me.PnlBeads.Size = New System.Drawing.Size(352, 112)
        Me.PnlBeads.TabIndex = 22
        Me.PnlBeads.Visible = False
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvBeads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvBeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBeads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BeadId, Me.BeadName, Me.BeadNo, Me.BeadSortNumber, Me.BeadColour, Me.beadSelected})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvBeads.DefaultCellStyle = DataGridViewCellStyle6
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
        Me.DgvBeads.Size = New System.Drawing.Size(338, 67)
        Me.DgvBeads.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(9, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 23)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "BEADS"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(289, 12)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(362, 456)
        Me.SplitContainer1.SplitterDistance = 330
        Me.SplitContainer1.TabIndex = 23
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
        'FrmProjectThreads
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 623)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BtnLoadPalette)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CbPalettes)
        Me.Controls.Add(Me.BtnAssignSymbols)
        Me.Controls.Add(Me.BtnLoadThreadList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnSelAll)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.BtnCopy)
        Me.Controls.Add(Me.BtnPaletteList)
        Me.Controls.Add(Me.TxtPaletteList)
        Me.Controls.Add(Me.ChkShowStock)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNumber)
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
        Me.PnlBeads.ResumeLayout(False)
        Me.PnlBeads.PerformLayout()
        CType(Me.DgvBeads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
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
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnGenerateCards As Button
    Friend WithEvents PnlThreads As Panel
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents threadId As DataGridViewTextBoxColumn
    Friend WithEvents threadName As DataGridViewTextBoxColumn
    Friend WithEvents threadNo As DataGridViewTextBoxColumn
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
    Friend WithEvents BtnLoadThreadList As Button
    Friend WithEvents BtnAssignSymbols As Button
    Friend WithEvents CbPalettes As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnLoadPalette As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PnlBeads As Panel
    Friend WithEvents DgvBeads As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BeadId As DataGridViewTextBoxColumn
    Friend WithEvents BeadName As DataGridViewTextBoxColumn
    Friend WithEvents BeadNo As DataGridViewTextBoxColumn
    Friend WithEvents BeadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents BeadColour As DataGridViewImageColumn
    Friend WithEvents beadSelected As DataGridViewCheckBoxColumn
End Class
