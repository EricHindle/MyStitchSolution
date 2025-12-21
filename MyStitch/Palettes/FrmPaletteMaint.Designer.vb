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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPaletteMaint))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.BtnAddThread = New System.Windows.Forms.Button()
        Me.BtnRemoveThread = New System.Windows.Forms.Button()
        Me.BtnRemoveBead = New System.Windows.Forms.Button()
        Me.BtnAddBead = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PnlPaletteThreads = New System.Windows.Forms.Panel()
        Me.DgvPaletteThreads = New System.Windows.Forms.DataGridView()
        Me.palettethreadid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.palettethreadname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.palettethreadno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paletteThreadSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.palettethreadcolour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BtnDeleteThreads = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DgvPaletteBeads = New System.Windows.Forms.DataGridView()
        Me.PaletteBeadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaletteBeadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaletteBeadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaletteBeadSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaletteBeadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlThreadList = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtThreadNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgvThreadList = New System.Windows.Forms.DataGridView()
        Me.ListThreadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListThreadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListThreadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListThreadSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListThreadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.listthreadsel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtBeadNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DgvBeadList = New System.Windows.Forms.DataGridView()
        Me.ListBeadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListBeadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListBeadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListBeadSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListBeadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.listbeadsel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LblPaletteName = New System.Windows.Forms.Label()
        CType(Me.DgvPalettes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PnlPaletteThreads.SuspendLayout()
        CType(Me.DgvPaletteThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvPaletteBeads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlThreadList.SuspendLayout()
        CType(Me.DgvThreadList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DgvBeadList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(119, 9)
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
        Me.DgvPalettes.Location = New System.Drawing.Point(123, 42)
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
        Me.DgvPalettes.Size = New System.Drawing.Size(191, 374)
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
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(221, 426)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(93, 28)
        Me.BtnClear.TabIndex = 152
        Me.BtnClear.Text = "Reset Form"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNew.Location = New System.Drawing.Point(15, 44)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(93, 49)
        Me.BtnNew.TabIndex = 150
        Me.BtnNew.Text = "Add New"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete.Location = New System.Drawing.Point(15, 192)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(93, 49)
        Me.BtnDelete.TabIndex = 151
        Me.BtnDelete.Text = "Remove"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(14, 429)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 472)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(905, 22)
        Me.StatusStrip1.TabIndex = 154
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'BtnAddThread
        '
        Me.BtnAddThread.BackgroundImage = CType(resources.GetObject("BtnAddThread.BackgroundImage"), System.Drawing.Image)
        Me.BtnAddThread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAddThread.Location = New System.Drawing.Point(3, 95)
        Me.BtnAddThread.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnAddThread.Name = "BtnAddThread"
        Me.BtnAddThread.Size = New System.Drawing.Size(26, 26)
        Me.BtnAddThread.TabIndex = 159
        Me.ToolTip1.SetToolTip(Me.BtnAddThread, "Add to Palette")
        Me.BtnAddThread.UseVisualStyleBackColor = True
        '
        'BtnRemoveThread
        '
        Me.BtnRemoveThread.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemoveThread.BackgroundImage = CType(resources.GetObject("BtnRemoveThread.BackgroundImage"), System.Drawing.Image)
        Me.BtnRemoveThread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRemoveThread.Location = New System.Drawing.Point(248, 67)
        Me.BtnRemoveThread.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnRemoveThread.Name = "BtnRemoveThread"
        Me.BtnRemoveThread.Size = New System.Drawing.Size(26, 26)
        Me.BtnRemoveThread.TabIndex = 158
        Me.ToolTip1.SetToolTip(Me.BtnRemoveThread, "Remove from Palette")
        Me.BtnRemoveThread.UseVisualStyleBackColor = True
        '
        'BtnRemoveBead
        '
        Me.BtnRemoveBead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemoveBead.BackgroundImage = CType(resources.GetObject("BtnRemoveBead.BackgroundImage"), System.Drawing.Image)
        Me.BtnRemoveBead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRemoveBead.Location = New System.Drawing.Point(248, 67)
        Me.BtnRemoveBead.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnRemoveBead.Name = "BtnRemoveBead"
        Me.BtnRemoveBead.Size = New System.Drawing.Size(26, 26)
        Me.BtnRemoveBead.TabIndex = 158
        Me.ToolTip1.SetToolTip(Me.BtnRemoveBead, "Remove from Palette")
        Me.BtnRemoveBead.UseVisualStyleBackColor = True
        '
        'BtnAddBead
        '
        Me.BtnAddBead.BackgroundImage = CType(resources.GetObject("BtnAddBead.BackgroundImage"), System.Drawing.Image)
        Me.BtnAddBead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAddBead.Location = New System.Drawing.Point(3, 94)
        Me.BtnAddBead.Margin = New System.Windows.Forms.Padding(1)
        Me.BtnAddBead.Name = "BtnAddBead"
        Me.BtnAddBead.Size = New System.Drawing.Size(26, 26)
        Me.BtnAddBead.TabIndex = 159
        Me.ToolTip1.SetToolTip(Me.BtnAddBead, "Add to Palette")
        Me.BtnAddBead.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PnlPaletteThreads)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(279, 412)
        Me.SplitContainer1.SplitterDistance = 264
        Me.SplitContainer1.TabIndex = 23
        '
        'PnlPaletteThreads
        '
        Me.PnlPaletteThreads.Controls.Add(Me.DgvPaletteThreads)
        Me.PnlPaletteThreads.Controls.Add(Me.BtnRemoveThread)
        Me.PnlPaletteThreads.Controls.Add(Me.BtnDeleteThreads)
        Me.PnlPaletteThreads.Controls.Add(Me.Label2)
        Me.PnlPaletteThreads.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlPaletteThreads.Location = New System.Drawing.Point(0, 0)
        Me.PnlPaletteThreads.Name = "PnlPaletteThreads"
        Me.PnlPaletteThreads.Size = New System.Drawing.Size(275, 260)
        Me.PnlPaletteThreads.TabIndex = 155
        '
        'DgvPaletteThreads
        '
        Me.DgvPaletteThreads.AllowUserToAddRows = False
        Me.DgvPaletteThreads.AllowUserToDeleteRows = False
        Me.DgvPaletteThreads.AllowUserToResizeRows = False
        Me.DgvPaletteThreads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvPaletteThreads.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvPaletteThreads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvPaletteThreads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvPaletteThreads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPaletteThreads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.palettethreadid, Me.palettethreadname, Me.palettethreadno, Me.paletteThreadSeq, Me.palettethreadcolour})
        Me.DgvPaletteThreads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvPaletteThreads.Location = New System.Drawing.Point(4, 33)
        Me.DgvPaletteThreads.Margin = New System.Windows.Forms.Padding(1)
        Me.DgvPaletteThreads.Name = "DgvPaletteThreads"
        Me.DgvPaletteThreads.RowHeadersVisible = False
        Me.DgvPaletteThreads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.DgvPaletteThreads.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvPaletteThreads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvPaletteThreads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DgvPaletteThreads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvPaletteThreads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPaletteThreads.Size = New System.Drawing.Size(243, 221)
        Me.DgvPaletteThreads.TabIndex = 151
        '
        'palettethreadid
        '
        Me.palettethreadid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.palettethreadid.HeaderText = "Id"
        Me.palettethreadid.Name = "palettethreadid"
        Me.palettethreadid.Visible = False
        '
        'palettethreadname
        '
        Me.palettethreadname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.palettethreadname.HeaderText = "Name"
        Me.palettethreadname.Name = "palettethreadname"
        '
        'palettethreadno
        '
        Me.palettethreadno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.palettethreadno.HeaderText = "No."
        Me.palettethreadno.Name = "palettethreadno"
        Me.palettethreadno.Width = 50
        '
        'paletteThreadSeq
        '
        Me.paletteThreadSeq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.paletteThreadSeq.HeaderText = "Seq"
        Me.paletteThreadSeq.Name = "paletteThreadSeq"
        Me.paletteThreadSeq.Visible = False
        Me.paletteThreadSeq.Width = 30
        '
        'palettethreadcolour
        '
        Me.palettethreadcolour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.palettethreadcolour.HeaderText = "Colour"
        Me.palettethreadcolour.Name = "palettethreadcolour"
        Me.palettethreadcolour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.palettethreadcolour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.palettethreadcolour.Width = 60
        '
        'BtnDeleteThreads
        '
        Me.BtnDeleteThreads.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDeleteThreads.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDeleteThreads.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDeleteThreads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDeleteThreads.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDeleteThreads.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDeleteThreads.Location = New System.Drawing.Point(182, 4)
        Me.BtnDeleteThreads.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnDeleteThreads.Name = "BtnDeleteThreads"
        Me.BtnDeleteThreads.Size = New System.Drawing.Size(62, 23)
        Me.BtnDeleteThreads.TabIndex = 155
        Me.BtnDeleteThreads.Text = "Clear"
        Me.BtnDeleteThreads.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 19)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "PALETTE THREADS"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DgvPaletteBeads)
        Me.Panel1.Controls.Add(Me.BtnRemoveBead)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(275, 140)
        Me.Panel1.TabIndex = 156
        '
        'DgvPaletteBeads
        '
        Me.DgvPaletteBeads.AllowUserToAddRows = False
        Me.DgvPaletteBeads.AllowUserToDeleteRows = False
        Me.DgvPaletteBeads.AllowUserToResizeRows = False
        Me.DgvPaletteBeads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvPaletteBeads.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvPaletteBeads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvPaletteBeads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvPaletteBeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPaletteBeads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PaletteBeadId, Me.PaletteBeadName, Me.PaletteBeadNo, Me.PaletteBeadSeq, Me.PaletteBeadColour})
        Me.DgvPaletteBeads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvPaletteBeads.Location = New System.Drawing.Point(4, 33)
        Me.DgvPaletteBeads.Margin = New System.Windows.Forms.Padding(1)
        Me.DgvPaletteBeads.Name = "DgvPaletteBeads"
        Me.DgvPaletteBeads.RowHeadersVisible = False
        Me.DgvPaletteBeads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.DgvPaletteBeads.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvPaletteBeads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvPaletteBeads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DgvPaletteBeads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvPaletteBeads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPaletteBeads.Size = New System.Drawing.Size(243, 101)
        Me.DgvPaletteBeads.TabIndex = 151
        '
        'PaletteBeadId
        '
        Me.PaletteBeadId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PaletteBeadId.HeaderText = "Id"
        Me.PaletteBeadId.Name = "PaletteBeadId"
        Me.PaletteBeadId.Visible = False
        '
        'PaletteBeadName
        '
        Me.PaletteBeadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PaletteBeadName.HeaderText = "Name"
        Me.PaletteBeadName.Name = "PaletteBeadName"
        '
        'PaletteBeadNo
        '
        Me.PaletteBeadNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PaletteBeadNo.HeaderText = "No."
        Me.PaletteBeadNo.Name = "PaletteBeadNo"
        Me.PaletteBeadNo.Width = 50
        '
        'PaletteBeadSeq
        '
        Me.PaletteBeadSeq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PaletteBeadSeq.HeaderText = "Seq"
        Me.PaletteBeadSeq.Name = "PaletteBeadSeq"
        Me.PaletteBeadSeq.Visible = False
        Me.PaletteBeadSeq.Width = 30
        '
        'PaletteBeadColour
        '
        Me.PaletteBeadColour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PaletteBeadColour.HeaderText = "Colour"
        Me.PaletteBeadColour.Name = "PaletteBeadColour"
        Me.PaletteBeadColour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PaletteBeadColour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PaletteBeadColour.Width = 60
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 19)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "PALETTE BEADS"
        '
        'PnlThreadList
        '
        Me.PnlThreadList.Controls.Add(Me.Label5)
        Me.PnlThreadList.Controls.Add(Me.TxtThreadNumber)
        Me.PnlThreadList.Controls.Add(Me.BtnAddThread)
        Me.PnlThreadList.Controls.Add(Me.Label3)
        Me.PnlThreadList.Controls.Add(Me.DgvThreadList)
        Me.PnlThreadList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlThreadList.Location = New System.Drawing.Point(0, 0)
        Me.PnlThreadList.Name = "PnlThreadList"
        Me.PnlThreadList.Size = New System.Drawing.Size(284, 259)
        Me.PnlThreadList.TabIndex = 158
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(186, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 14)
        Me.Label5.TabIndex = 161
        Me.Label5.Text = "Find"
        '
        'TxtThreadNumber
        '
        Me.TxtThreadNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtThreadNumber.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtThreadNumber.Location = New System.Drawing.Point(222, 5)
        Me.TxtThreadNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtThreadNumber.Name = "TxtThreadNumber"
        Me.TxtThreadNumber.Size = New System.Drawing.Size(58, 22)
        Me.TxtThreadNumber.TabIndex = 160
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(37, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 19)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "THREAD LIST"
        '
        'DgvThreadList
        '
        Me.DgvThreadList.AllowUserToAddRows = False
        Me.DgvThreadList.AllowUserToDeleteRows = False
        Me.DgvThreadList.AllowUserToResizeRows = False
        Me.DgvThreadList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvThreadList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvThreadList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvThreadList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvThreadList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvThreadList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ListThreadId, Me.ListThreadName, Me.ListThreadNo, Me.ListThreadSeq, Me.ListThreadColour, Me.listthreadsel})
        Me.DgvThreadList.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvThreadList.Location = New System.Drawing.Point(31, 30)
        Me.DgvThreadList.Margin = New System.Windows.Forms.Padding(1)
        Me.DgvThreadList.Name = "DgvThreadList"
        Me.DgvThreadList.RowHeadersVisible = False
        Me.DgvThreadList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DgvThreadList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvThreadList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvThreadList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DgvThreadList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvThreadList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvThreadList.Size = New System.Drawing.Size(252, 221)
        Me.DgvThreadList.TabIndex = 154
        '
        'ListThreadId
        '
        Me.ListThreadId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ListThreadId.HeaderText = "Id"
        Me.ListThreadId.Name = "ListThreadId"
        Me.ListThreadId.ReadOnly = True
        Me.ListThreadId.Visible = False
        '
        'ListThreadName
        '
        Me.ListThreadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ListThreadName.HeaderText = "Name"
        Me.ListThreadName.Name = "ListThreadName"
        Me.ListThreadName.ReadOnly = True
        '
        'ListThreadNo
        '
        Me.ListThreadNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ListThreadNo.HeaderText = "No."
        Me.ListThreadNo.Name = "ListThreadNo"
        Me.ListThreadNo.ReadOnly = True
        Me.ListThreadNo.Width = 50
        '
        'ListThreadSeq
        '
        Me.ListThreadSeq.HeaderText = "Seq"
        Me.ListThreadSeq.Name = "ListThreadSeq"
        Me.ListThreadSeq.ReadOnly = True
        Me.ListThreadSeq.Visible = False
        '
        'ListThreadColour
        '
        Me.ListThreadColour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ListThreadColour.HeaderText = "Colour"
        Me.ListThreadColour.Name = "ListThreadColour"
        Me.ListThreadColour.ReadOnly = True
        Me.ListThreadColour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListThreadColour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ListThreadColour.Width = 60
        '
        'listthreadsel
        '
        Me.listthreadsel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.listthreadsel.HeaderText = ""
        Me.listthreadsel.Name = "listthreadsel"
        Me.listthreadsel.Width = 30
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Location = New System.Drawing.Point(322, 42)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(571, 412)
        Me.SplitContainer2.SplitterDistance = 279
        Me.SplitContainer2.TabIndex = 159
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.PnlThreadList)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer3.Size = New System.Drawing.Size(288, 412)
        Me.SplitContainer3.SplitterDistance = 263
        Me.SplitContainer3.TabIndex = 159
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtBeadNumber)
        Me.Panel2.Controls.Add(Me.BtnAddBead)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.DgvBeadList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(284, 141)
        Me.Panel2.TabIndex = 159
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(186, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 14)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Find"
        '
        'TxtBeadNumber
        '
        Me.TxtBeadNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBeadNumber.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBeadNumber.Location = New System.Drawing.Point(222, 6)
        Me.TxtBeadNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBeadNumber.Name = "TxtBeadNumber"
        Me.TxtBeadNumber.Size = New System.Drawing.Size(58, 22)
        Me.TxtBeadNumber.TabIndex = 162
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(37, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 19)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = "BEAD LIST"
        '
        'DgvBeadList
        '
        Me.DgvBeadList.AllowUserToAddRows = False
        Me.DgvBeadList.AllowUserToDeleteRows = False
        Me.DgvBeadList.AllowUserToResizeRows = False
        Me.DgvBeadList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvBeadList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvBeadList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvBeadList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvBeadList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBeadList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ListBeadId, Me.ListBeadName, Me.ListBeadNo, Me.ListBeadSeq, Me.ListBeadColour, Me.listbeadsel})
        Me.DgvBeadList.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvBeadList.Location = New System.Drawing.Point(31, 30)
        Me.DgvBeadList.Margin = New System.Windows.Forms.Padding(1)
        Me.DgvBeadList.Name = "DgvBeadList"
        Me.DgvBeadList.RowHeadersVisible = False
        Me.DgvBeadList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DgvBeadList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvBeadList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvBeadList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DgvBeadList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvBeadList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvBeadList.Size = New System.Drawing.Size(252, 103)
        Me.DgvBeadList.TabIndex = 154
        '
        'ListBeadId
        '
        Me.ListBeadId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ListBeadId.HeaderText = "Id"
        Me.ListBeadId.Name = "ListBeadId"
        Me.ListBeadId.ReadOnly = True
        Me.ListBeadId.Visible = False
        '
        'ListBeadName
        '
        Me.ListBeadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ListBeadName.HeaderText = "Name"
        Me.ListBeadName.Name = "ListBeadName"
        Me.ListBeadName.ReadOnly = True
        '
        'ListBeadNo
        '
        Me.ListBeadNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ListBeadNo.HeaderText = "No."
        Me.ListBeadNo.Name = "ListBeadNo"
        Me.ListBeadNo.ReadOnly = True
        Me.ListBeadNo.Width = 50
        '
        'ListBeadSeq
        '
        Me.ListBeadSeq.HeaderText = "Seq"
        Me.ListBeadSeq.Name = "ListBeadSeq"
        Me.ListBeadSeq.ReadOnly = True
        Me.ListBeadSeq.Visible = False
        '
        'ListBeadColour
        '
        Me.ListBeadColour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ListBeadColour.HeaderText = "Colour"
        Me.ListBeadColour.Name = "ListBeadColour"
        Me.ListBeadColour.ReadOnly = True
        Me.ListBeadColour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListBeadColour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ListBeadColour.Width = 60
        '
        'listbeadsel
        '
        Me.listbeadsel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.listbeadsel.HeaderText = ""
        Me.listbeadsel.Name = "listbeadsel"
        Me.listbeadsel.Width = 30
        '
        'LblPaletteName
        '
        Me.LblPaletteName.AutoSize = True
        Me.LblPaletteName.BackColor = System.Drawing.SystemColors.Control
        Me.LblPaletteName.Font = New System.Drawing.Font("Felix Titling", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaletteName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.LblPaletteName.Location = New System.Drawing.Point(321, 16)
        Me.LblPaletteName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LblPaletteName.Name = "LblPaletteName"
        Me.LblPaletteName.Size = New System.Drawing.Size(109, 16)
        Me.LblPaletteName.TabIndex = 160
        Me.LblPaletteName.Text = "PALETTE NAME"
        '
        'FrmPaletteMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 494)
        Me.Controls.Add(Me.LblPaletteName)
        Me.Controls.Add(Me.SplitContainer2)
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
        Me.Text = "Stored Palettes"
        CType(Me.DgvPalettes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PnlPaletteThreads.ResumeLayout(False)
        Me.PnlPaletteThreads.PerformLayout()
        CType(Me.DgvPaletteThreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgvPaletteBeads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlThreadList.ResumeLayout(False)
        Me.PnlThreadList.PerformLayout()
        CType(Me.DgvThreadList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DgvBeadList, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents paletteId As DataGridViewTextBoxColumn
    Friend WithEvents paletteName As DataGridViewTextBoxColumn
    Friend WithEvents BtnDeleteThreads As Button
    Friend WithEvents PnlThreadList As Panel
    Friend WithEvents PnlPaletteThreads As Panel
    Friend WithEvents BtnAddThread As Button
    Friend WithEvents BtnRemoveThread As Button
    Friend WithEvents DgvPaletteThreads As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DgvThreadList As DataGridView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DgvPaletteBeads As DataGridView
    Friend WithEvents BtnRemoveBead As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnAddBead As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DgvBeadList As DataGridView
    Friend WithEvents LblPaletteName As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtThreadNumber As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtBeadNumber As TextBox
    Friend WithEvents palettethreadid As DataGridViewTextBoxColumn
    Friend WithEvents palettethreadname As DataGridViewTextBoxColumn
    Friend WithEvents palettethreadno As DataGridViewTextBoxColumn
    Friend WithEvents paletteThreadSeq As DataGridViewTextBoxColumn
    Friend WithEvents palettethreadcolour As DataGridViewImageColumn
    Friend WithEvents PaletteBeadId As DataGridViewTextBoxColumn
    Friend WithEvents PaletteBeadName As DataGridViewTextBoxColumn
    Friend WithEvents PaletteBeadNo As DataGridViewTextBoxColumn
    Friend WithEvents PaletteBeadSeq As DataGridViewTextBoxColumn
    Friend WithEvents PaletteBeadColour As DataGridViewImageColumn
    Friend WithEvents ListThreadId As DataGridViewTextBoxColumn
    Friend WithEvents ListThreadName As DataGridViewTextBoxColumn
    Friend WithEvents ListThreadNo As DataGridViewTextBoxColumn
    Friend WithEvents ListThreadSeq As DataGridViewTextBoxColumn
    Friend WithEvents ListThreadColour As DataGridViewImageColumn
    Friend WithEvents listthreadsel As DataGridViewCheckBoxColumn
    Friend WithEvents ListBeadId As DataGridViewTextBoxColumn
    Friend WithEvents ListBeadName As DataGridViewTextBoxColumn
    Friend WithEvents ListBeadNo As DataGridViewTextBoxColumn
    Friend WithEvents ListBeadSeq As DataGridViewTextBoxColumn
    Friend WithEvents ListBeadColour As DataGridViewImageColumn
    Friend WithEvents listbeadsel As DataGridViewCheckBoxColumn
End Class
