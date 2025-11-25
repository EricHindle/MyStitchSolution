' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPaletteMaint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPaletteMaint))
        Me.Label44 = New System.Windows.Forms.Label()
        Me.DgvPalettes = New System.Windows.Forms.DataGridView()
        Me.paletteId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paletteName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PnlThreads = New System.Windows.Forms.Panel()
        Me.DgvThreads = New System.Windows.Forms.DataGridView()
        Me.threadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.threadselected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PnlBeads = New System.Windows.Forms.Panel()
        Me.DgvBeads = New System.Windows.Forms.DataGridView()
        Me.BeadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.beadSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnDeleteThreads = New System.Windows.Forms.Button()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DgvPalettes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PnlThreads.SuspendLayout()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBeads.SuspendLayout()
        CType(Me.DgvBeads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(132, 11)
        Me.Label44.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(94, 23)
        Me.Label44.TabIndex = 19
        Me.Label44.Text = "PALETTES"
        '
        'DgvPalettes
        '
        Me.DgvPalettes.AllowUserToAddRows = False
        Me.DgvPalettes.AllowUserToDeleteRows = False
        Me.DgvPalettes.AllowUserToResizeRows = False
        Me.DgvPalettes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgvPalettes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvPalettes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvPalettes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvPalettes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPalettes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.paletteId, Me.paletteName})
        Me.DgvPalettes.GridColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.DgvPalettes.Location = New System.Drawing.Point(136, 44)
        Me.DgvPalettes.Margin = New System.Windows.Forms.Padding(5)
        Me.DgvPalettes.MultiSelect = False
        Me.DgvPalettes.Name = "DgvPalettes"
        Me.DgvPalettes.ReadOnly = True
        Me.DgvPalettes.RowHeadersVisible = False
        Me.DgvPalettes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.DgvPalettes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgvPalettes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.DgvPalettes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.DgvPalettes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPalettes.Size = New System.Drawing.Size(191, 301)
        Me.DgvPalettes.TabIndex = 20
        '
        'paletteId
        '
        Me.paletteId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.paletteId.HeaderText = "Id"
        Me.paletteId.Name = "paletteId"
        Me.paletteId.ReadOnly = True
        Me.paletteId.Visible = False
        Me.paletteId.Width = 50
        '
        'paletteName
        '
        Me.paletteName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.paletteName.HeaderText = "Name"
        Me.paletteName.Name = "paletteName"
        Me.paletteName.ReadOnly = True
        '
        'BtnClear
        '
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(15, 370)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(93, 49)
        Me.BtnClear.TabIndex = 152
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNew.Location = New System.Drawing.Point(15, 44)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(93, 49)
        Me.BtnNew.TabIndex = 150
        Me.BtnNew.Text = "Add"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete.Location = New System.Drawing.Point(15, 192)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(93, 49)
        Me.BtnDelete.TabIndex = 151
        Me.BtnDelete.Text = "Delete Palette"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnUpdate.Location = New System.Drawing.Point(15, 118)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(93, 49)
        Me.BtnUpdate.TabIndex = 149
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(15, 471)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(93, 38)
        Me.BtnClose.TabIndex = 153
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 523)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(641, 22)
        Me.StatusStrip1.TabIndex = 154
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(335, 74)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(294, 444)
        Me.SplitContainer1.SplitterDistance = 321
        Me.SplitContainer1.TabIndex = 23
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
        Me.PnlThreads.Size = New System.Drawing.Size(284, 311)
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvThreads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
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
        Me.DgvThreads.Size = New System.Drawing.Size(270, 266)
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
        'PnlBeads
        '
        Me.PnlBeads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlBeads.Controls.Add(Me.DgvBeads)
        Me.PnlBeads.Controls.Add(Me.Label4)
        Me.PnlBeads.Location = New System.Drawing.Point(3, 3)
        Me.PnlBeads.Name = "PnlBeads"
        Me.PnlBeads.Size = New System.Drawing.Size(284, 109)
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvBeads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
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
        Me.DgvBeads.Size = New System.Drawing.Size(270, 64)
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
        'BtnDeleteThreads
        '
        Me.BtnDeleteThreads.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDeleteThreads.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDeleteThreads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDeleteThreads.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDeleteThreads.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDeleteThreads.Location = New System.Drawing.Point(15, 267)
        Me.BtnDeleteThreads.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnDeleteThreads.Name = "BtnDeleteThreads"
        Me.BtnDeleteThreads.Size = New System.Drawing.Size(93, 49)
        Me.BtnDeleteThreads.TabIndex = 155
        Me.BtnDeleteThreads.Text = "Delete Threads"
        Me.BtnDeleteThreads.UseVisualStyleBackColor = False
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(442, 44)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(178, 24)
        Me.TxtName.TabIndex = 156
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(337, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Palette Name"
        '
        'FrmPaletteMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 545)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.BtnDeleteThreads)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.DgvPalettes)
        Me.Controls.Add(Me.Label44)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPaletteMaint"
        Me.Text = "Palettes"
        CType(Me.DgvPalettes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label44 As Label
    Friend WithEvents DgvPalettes As DataGridView
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnNew As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PnlThreads As Panel
    Friend WithEvents DgvThreads As DataGridView
    Friend WithEvents threadId As DataGridViewTextBoxColumn
    Friend WithEvents threadName As DataGridViewTextBoxColumn
    Friend WithEvents threadNo As DataGridViewTextBoxColumn
    Friend WithEvents threadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents threadColour As DataGridViewImageColumn
    Friend WithEvents threadselected As DataGridViewCheckBoxColumn
    Friend WithEvents Label7 As Label
    Friend WithEvents PnlBeads As Panel
    Friend WithEvents DgvBeads As DataGridView
    Friend WithEvents BeadId As DataGridViewTextBoxColumn
    Friend WithEvents BeadName As DataGridViewTextBoxColumn
    Friend WithEvents BeadNo As DataGridViewTextBoxColumn
    Friend WithEvents BeadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents BeadColour As DataGridViewImageColumn
    Friend WithEvents beadSelected As DataGridViewCheckBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents paletteId As DataGridViewTextBoxColumn
    Friend WithEvents paletteName As DataGridViewTextBoxColumn
    Friend WithEvents BtnDeleteThreads As Button
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label1 As Label
End Class
