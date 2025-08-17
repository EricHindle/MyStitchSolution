' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesignInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDesignInfo))
        Me.LblName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DgvThreads = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ChkShowStock = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblTotalTime = New System.Windows.Forms.Label()
        Me.LblCentreY = New System.Windows.Forms.Label()
        Me.LblCentreX = New System.Windows.Forms.Label()
        Me.LblFabricColour = New System.Windows.Forms.Label()
        Me.LblFabricHeight = New System.Windows.Forms.Label()
        Me.LblFabricWidth = New System.Windows.Forms.Label()
        Me.LblDesignHeight = New System.Windows.Forms.Label()
        Me.LblDesignWidth = New System.Windows.Forms.Label()
        Me.LblFinished = New System.Windows.Forms.Label()
        Me.LblStarted = New System.Windows.Forms.Label()
        Me.DgvBlock = New System.Windows.Forms.DataGridView()
        Me.threadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThreadNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadSortNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadColour = New System.Windows.Forms.DataGridViewImageColumn()
        Me.threadblockcount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadbackcount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.threadknotcount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvBack = New System.Windows.Forms.DataGridView()
        Me.DgvKnot = New System.Windows.Forms.DataGridView()
        Me.block_pos_x = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.block_pos_y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.block_thread_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.block_thread_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.block_symbol_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.block_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.back_from_x = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.back_from_y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.back_to_x = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.back_to_y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.back_thread_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.back_thread_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.back_strands = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.knot_pos_x = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.knot_pos_y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.knot_thread_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.knot_thread_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.knot_strands = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.knot_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DgvBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvKnot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.BackColor = System.Drawing.SystemColors.Control
        Me.LblName.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.LblName.Location = New System.Drawing.Point(15, 10)
        Me.LblName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(152, 23)
        Me.LblName.TabIndex = 136
        Me.LblName.Text = "PROJECT NAME"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(5, 2)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 19)
        Me.Label7.TabIndex = 155
        Me.Label7.Text = "PROJECT THREADS"
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvThreads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvThreads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvThreads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.threadId, Me.threadName, Me.ThreadNo, Me.threadSortNumber, Me.threadColour, Me.threadblockcount, Me.threadbackcount, Me.threadknotcount})
        Me.DgvThreads.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvThreads.Location = New System.Drawing.Point(9, 25)
        Me.DgvThreads.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DgvThreads.MultiSelect = False
        Me.DgvThreads.Name = "DgvThreads"
        Me.DgvThreads.ReadOnly = True
        Me.DgvThreads.RowHeadersVisible = False
        Me.DgvThreads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DgvThreads.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvThreads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvThreads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DgvThreads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvThreads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvThreads.Size = New System.Drawing.Size(518, 129)
        Me.DgvThreads.TabIndex = 156
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 19)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "BlockStitches"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 19)
        Me.Label2.TabIndex = 158
        Me.Label2.Text = "BACKSTITCHES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(5, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "KNOTS"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(19, 36)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkShowStock)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvThreads)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(574, 690)
        Me.SplitContainer1.SplitterDistance = 162
        Me.SplitContainer1.TabIndex = 160
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DgvBlock)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(574, 524)
        Me.SplitContainer2.SplitterDistance = 191
        Me.SplitContainer2.TabIndex = 0
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
        Me.SplitContainer3.Panel1.Controls.Add(Me.DgvBack)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.DgvKnot)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer3.Size = New System.Drawing.Size(574, 329)
        Me.SplitContainer3.SplitterDistance = 192
        Me.SplitContainer3.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(798, 686)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 161
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'ChkShowStock
        '
        Me.ChkShowStock.AutoSize = True
        Me.ChkShowStock.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkShowStock.Location = New System.Drawing.Point(314, 4)
        Me.ChkShowStock.Name = "ChkShowStock"
        Me.ChkShowStock.Size = New System.Drawing.Size(123, 18)
        Me.ChkShowStock.TabIndex = 159
        Me.ChkShowStock.Text = "Show stock levels"
        Me.ChkShowStock.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(684, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 14)
        Me.Label14.TabIndex = 171
        Me.Label14.Text = "Total work time"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(683, 190)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 14)
        Me.Label12.TabIndex = 170
        Me.Label12.Text = "Centre Y co-ord"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(684, 162)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 14)
        Me.Label13.TabIndex = 169
        Me.Label13.Text = "Centre X co-ord"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(702, 273)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 168
        Me.Label8.Text = "Fabric Colour"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(700, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 14)
        Me.Label4.TabIndex = 167
        Me.Label4.Text = "Fabric Height"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(703, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 14)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "Fabric Width"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(695, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 14)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Design Height"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(698, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 14)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "Design Width"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(728, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 14)
        Me.Label10.TabIndex = 163
        Me.Label10.Text = "Finished"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(730, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.TabIndex = 162
        Me.Label11.Text = "Started"
        '
        'LblTotalTime
        '
        Me.LblTotalTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalTime.AutoSize = True
        Me.LblTotalTime.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalTime.Location = New System.Drawing.Point(787, 80)
        Me.LblTotalTime.Name = "LblTotalTime"
        Me.LblTotalTime.Size = New System.Drawing.Size(94, 14)
        Me.LblTotalTime.TabIndex = 181
        Me.LblTotalTime.Text = "Total work time"
        '
        'LblCentreY
        '
        Me.LblCentreY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCentreY.AutoSize = True
        Me.LblCentreY.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCentreY.Location = New System.Drawing.Point(787, 190)
        Me.LblCentreY.Name = "LblCentreY"
        Me.LblCentreY.Size = New System.Drawing.Size(95, 14)
        Me.LblCentreY.TabIndex = 180
        Me.LblCentreY.Text = "Centre Y co-ord"
        '
        'LblCentreX
        '
        Me.LblCentreX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCentreX.AutoSize = True
        Me.LblCentreX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCentreX.Location = New System.Drawing.Point(787, 162)
        Me.LblCentreX.Name = "LblCentreX"
        Me.LblCentreX.Size = New System.Drawing.Size(94, 14)
        Me.LblCentreX.TabIndex = 179
        Me.LblCentreX.Text = "Centre X co-ord"
        '
        'LblFabricColour
        '
        Me.LblFabricColour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFabricColour.AutoSize = True
        Me.LblFabricColour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFabricColour.Location = New System.Drawing.Point(787, 273)
        Me.LblFabricColour.Name = "LblFabricColour"
        Me.LblFabricColour.Size = New System.Drawing.Size(76, 14)
        Me.LblFabricColour.TabIndex = 178
        Me.LblFabricColour.Text = "Fabric Colour"
        '
        'LblFabricHeight
        '
        Me.LblFabricHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFabricHeight.AutoSize = True
        Me.LblFabricHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFabricHeight.Location = New System.Drawing.Point(787, 246)
        Me.LblFabricHeight.Name = "LblFabricHeight"
        Me.LblFabricHeight.Size = New System.Drawing.Size(78, 14)
        Me.LblFabricHeight.TabIndex = 177
        Me.LblFabricHeight.Text = "Fabric Height"
        '
        'LblFabricWidth
        '
        Me.LblFabricWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFabricWidth.AutoSize = True
        Me.LblFabricWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFabricWidth.Location = New System.Drawing.Point(787, 218)
        Me.LblFabricWidth.Name = "LblFabricWidth"
        Me.LblFabricWidth.Size = New System.Drawing.Size(75, 14)
        Me.LblFabricWidth.TabIndex = 176
        Me.LblFabricWidth.Text = "Fabric Width"
        '
        'LblDesignHeight
        '
        Me.LblDesignHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblDesignHeight.AutoSize = True
        Me.LblDesignHeight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesignHeight.Location = New System.Drawing.Point(787, 134)
        Me.LblDesignHeight.Name = "LblDesignHeight"
        Me.LblDesignHeight.Size = New System.Drawing.Size(83, 14)
        Me.LblDesignHeight.TabIndex = 175
        Me.LblDesignHeight.Text = "Design Height"
        '
        'LblDesignWidth
        '
        Me.LblDesignWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblDesignWidth.AutoSize = True
        Me.LblDesignWidth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesignWidth.Location = New System.Drawing.Point(787, 106)
        Me.LblDesignWidth.Name = "LblDesignWidth"
        Me.LblDesignWidth.Size = New System.Drawing.Size(80, 14)
        Me.LblDesignWidth.TabIndex = 174
        Me.LblDesignWidth.Text = "Design Width"
        '
        'LblFinished
        '
        Me.LblFinished.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFinished.AutoSize = True
        Me.LblFinished.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFinished.Location = New System.Drawing.Point(787, 58)
        Me.LblFinished.Name = "LblFinished"
        Me.LblFinished.Size = New System.Drawing.Size(50, 14)
        Me.LblFinished.TabIndex = 173
        Me.LblFinished.Text = "Finished"
        '
        'LblStarted
        '
        Me.LblStarted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblStarted.AutoSize = True
        Me.LblStarted.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStarted.Location = New System.Drawing.Point(787, 36)
        Me.LblStarted.Name = "LblStarted"
        Me.LblStarted.Size = New System.Drawing.Size(48, 14)
        Me.LblStarted.TabIndex = 172
        Me.LblStarted.Text = "Started"
        '
        'DgvBlock
        '
        Me.DgvBlock.AllowUserToAddRows = False
        Me.DgvBlock.AllowUserToDeleteRows = False
        Me.DgvBlock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvBlock.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvBlock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBlock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.block_pos_x, Me.block_pos_y, Me.block_thread_id, Me.block_thread_no, Me.block_symbol_id, Me.block_type})
        Me.DgvBlock.Location = New System.Drawing.Point(9, 32)
        Me.DgvBlock.Name = "DgvBlock"
        Me.DgvBlock.ReadOnly = True
        Me.DgvBlock.RowHeadersVisible = False
        Me.DgvBlock.Size = New System.Drawing.Size(558, 152)
        Me.DgvBlock.TabIndex = 158
        '
        'threadId
        '
        Me.threadId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadId.HeaderText = "Id"
        Me.threadId.Name = "threadId"
        Me.threadId.ReadOnly = True
        Me.threadId.Width = 50
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
        'threadblockcount
        '
        Me.threadblockcount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadblockcount.HeaderText = "Block Count"
        Me.threadblockcount.Name = "threadblockcount"
        Me.threadblockcount.ReadOnly = True
        Me.threadblockcount.Width = 50
        '
        'threadbackcount
        '
        Me.threadbackcount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadbackcount.HeaderText = "Back Count"
        Me.threadbackcount.Name = "threadbackcount"
        Me.threadbackcount.ReadOnly = True
        Me.threadbackcount.Width = 50
        '
        'threadknotcount
        '
        Me.threadknotcount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.threadknotcount.HeaderText = "Knot Count"
        Me.threadknotcount.Name = "threadknotcount"
        Me.threadknotcount.ReadOnly = True
        Me.threadknotcount.Width = 50
        '
        'DgvBack
        '
        Me.DgvBack.AllowUserToAddRows = False
        Me.DgvBack.AllowUserToDeleteRows = False
        Me.DgvBack.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvBack.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvBack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBack.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.back_from_x, Me.back_from_y, Me.back_to_x, Me.back_to_y, Me.back_thread_id, Me.back_thread_no, Me.back_strands})
        Me.DgvBack.Location = New System.Drawing.Point(9, 32)
        Me.DgvBack.Name = "DgvBack"
        Me.DgvBack.ReadOnly = True
        Me.DgvBack.RowHeadersVisible = False
        Me.DgvBack.Size = New System.Drawing.Size(558, 153)
        Me.DgvBack.TabIndex = 159
        '
        'DgvKnot
        '
        Me.DgvKnot.AllowUserToAddRows = False
        Me.DgvKnot.AllowUserToDeleteRows = False
        Me.DgvKnot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvKnot.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvKnot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvKnot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.knot_pos_x, Me.knot_pos_y, Me.knot_thread_id, Me.knot_thread_no, Me.knot_strands, Me.knot_type})
        Me.DgvKnot.Location = New System.Drawing.Point(9, 33)
        Me.DgvKnot.Name = "DgvKnot"
        Me.DgvKnot.ReadOnly = True
        Me.DgvKnot.RowHeadersVisible = False
        Me.DgvKnot.Size = New System.Drawing.Size(558, 93)
        Me.DgvKnot.TabIndex = 160
        '
        'block_pos_x
        '
        Me.block_pos_x.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.block_pos_x.HeaderText = "X"
        Me.block_pos_x.Name = "block_pos_x"
        Me.block_pos_x.ReadOnly = True
        Me.block_pos_x.Width = 50
        '
        'block_pos_y
        '
        Me.block_pos_y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.block_pos_y.HeaderText = "Y"
        Me.block_pos_y.Name = "block_pos_y"
        Me.block_pos_y.ReadOnly = True
        Me.block_pos_y.Width = 50
        '
        'block_thread_id
        '
        Me.block_thread_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.block_thread_id.HeaderText = "Thread Id"
        Me.block_thread_id.Name = "block_thread_id"
        Me.block_thread_id.ReadOnly = True
        Me.block_thread_id.Width = 90
        '
        'block_thread_no
        '
        Me.block_thread_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.block_thread_no.HeaderText = "Thread No"
        Me.block_thread_no.Name = "block_thread_no"
        Me.block_thread_no.ReadOnly = True
        Me.block_thread_no.Width = 90
        '
        'block_symbol_id
        '
        Me.block_symbol_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.block_symbol_id.HeaderText = "Symbol Id"
        Me.block_symbol_id.Name = "block_symbol_id"
        Me.block_symbol_id.ReadOnly = True
        Me.block_symbol_id.Width = 90
        '
        'block_type
        '
        Me.block_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.block_type.HeaderText = "Type"
        Me.block_type.Name = "block_type"
        Me.block_type.ReadOnly = True
        '
        'back_from_x
        '
        Me.back_from_x.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.back_from_x.HeaderText = "From X"
        Me.back_from_x.Name = "back_from_x"
        Me.back_from_x.ReadOnly = True
        Me.back_from_x.Width = 70
        '
        'back_from_y
        '
        Me.back_from_y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.back_from_y.HeaderText = "From Y"
        Me.back_from_y.Name = "back_from_y"
        Me.back_from_y.ReadOnly = True
        Me.back_from_y.Width = 70
        '
        'back_to_x
        '
        Me.back_to_x.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.back_to_x.HeaderText = "To X"
        Me.back_to_x.Name = "back_to_x"
        Me.back_to_x.ReadOnly = True
        Me.back_to_x.Width = 70
        '
        'back_to_y
        '
        Me.back_to_y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.back_to_y.HeaderText = "To Y"
        Me.back_to_y.Name = "back_to_y"
        Me.back_to_y.ReadOnly = True
        Me.back_to_y.Width = 70
        '
        'back_thread_id
        '
        Me.back_thread_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.back_thread_id.HeaderText = "Thread Id"
        Me.back_thread_id.Name = "back_thread_id"
        Me.back_thread_id.ReadOnly = True
        Me.back_thread_id.Width = 90
        '
        'back_thread_no
        '
        Me.back_thread_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.back_thread_no.HeaderText = "Thread No"
        Me.back_thread_no.Name = "back_thread_no"
        Me.back_thread_no.ReadOnly = True
        Me.back_thread_no.Width = 90
        '
        'back_strands
        '
        Me.back_strands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.back_strands.HeaderText = "Strands"
        Me.back_strands.Name = "back_strands"
        Me.back_strands.ReadOnly = True
        Me.back_strands.Width = 60
        '
        'knot_pos_x
        '
        Me.knot_pos_x.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.knot_pos_x.HeaderText = "X"
        Me.knot_pos_x.Name = "knot_pos_x"
        Me.knot_pos_x.ReadOnly = True
        Me.knot_pos_x.Width = 50
        '
        'knot_pos_y
        '
        Me.knot_pos_y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.knot_pos_y.HeaderText = "Y"
        Me.knot_pos_y.Name = "knot_pos_y"
        Me.knot_pos_y.ReadOnly = True
        Me.knot_pos_y.Width = 50
        '
        'knot_thread_id
        '
        Me.knot_thread_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.knot_thread_id.HeaderText = "Thread Id"
        Me.knot_thread_id.Name = "knot_thread_id"
        Me.knot_thread_id.ReadOnly = True
        Me.knot_thread_id.Width = 90
        '
        'knot_thread_no
        '
        Me.knot_thread_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.knot_thread_no.HeaderText = "Thread No"
        Me.knot_thread_no.Name = "knot_thread_no"
        Me.knot_thread_no.ReadOnly = True
        Me.knot_thread_no.Width = 90
        '
        'knot_strands
        '
        Me.knot_strands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.knot_strands.HeaderText = "Strands"
        Me.knot_strands.Name = "knot_strands"
        Me.knot_strands.ReadOnly = True
        Me.knot_strands.Width = 60
        '
        'knot_type
        '
        Me.knot_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.knot_type.HeaderText = "Type"
        Me.knot_type.Name = "knot_type"
        Me.knot_type.ReadOnly = True
        Me.knot_type.Width = 90
        '
        'FrmDesignInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 738)
        Me.Controls.Add(Me.LblTotalTime)
        Me.Controls.Add(Me.LblCentreY)
        Me.Controls.Add(Me.LblCentreX)
        Me.Controls.Add(Me.LblFabricColour)
        Me.Controls.Add(Me.LblFabricHeight)
        Me.Controls.Add(Me.LblFabricWidth)
        Me.Controls.Add(Me.LblDesignHeight)
        Me.Controls.Add(Me.LblDesignWidth)
        Me.Controls.Add(Me.LblFinished)
        Me.Controls.Add(Me.LblStarted)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.LblName)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmDesignInfo"
        Me.Text = "Design Information"
        CType(Me.DgvThreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DgvBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvKnot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblName As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DgvThreads As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents BtnClose As Button
    Friend WithEvents ChkShowStock As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblTotalTime As Label
    Friend WithEvents LblCentreY As Label
    Friend WithEvents LblCentreX As Label
    Friend WithEvents LblFabricColour As Label
    Friend WithEvents LblFabricHeight As Label
    Friend WithEvents LblFabricWidth As Label
    Friend WithEvents LblDesignHeight As Label
    Friend WithEvents LblDesignWidth As Label
    Friend WithEvents LblFinished As Label
    Friend WithEvents LblStarted As Label
    Friend WithEvents DgvBlock As DataGridView
    Friend WithEvents threadId As DataGridViewTextBoxColumn
    Friend WithEvents threadName As DataGridViewTextBoxColumn
    Friend WithEvents ThreadNo As DataGridViewTextBoxColumn
    Friend WithEvents threadSortNumber As DataGridViewTextBoxColumn
    Friend WithEvents threadColour As DataGridViewImageColumn
    Friend WithEvents threadblockcount As DataGridViewTextBoxColumn
    Friend WithEvents threadbackcount As DataGridViewTextBoxColumn
    Friend WithEvents threadknotcount As DataGridViewTextBoxColumn
    Friend WithEvents DgvBack As DataGridView
    Friend WithEvents DgvKnot As DataGridView
    Friend WithEvents block_pos_x As DataGridViewTextBoxColumn
    Friend WithEvents block_pos_y As DataGridViewTextBoxColumn
    Friend WithEvents block_thread_id As DataGridViewTextBoxColumn
    Friend WithEvents block_thread_no As DataGridViewTextBoxColumn
    Friend WithEvents block_symbol_id As DataGridViewTextBoxColumn
    Friend WithEvents block_type As DataGridViewTextBoxColumn
    Friend WithEvents back_from_x As DataGridViewTextBoxColumn
    Friend WithEvents back_from_y As DataGridViewTextBoxColumn
    Friend WithEvents back_to_x As DataGridViewTextBoxColumn
    Friend WithEvents back_to_y As DataGridViewTextBoxColumn
    Friend WithEvents back_thread_id As DataGridViewTextBoxColumn
    Friend WithEvents back_thread_no As DataGridViewTextBoxColumn
    Friend WithEvents back_strands As DataGridViewTextBoxColumn
    Friend WithEvents knot_pos_x As DataGridViewTextBoxColumn
    Friend WithEvents knot_pos_y As DataGridViewTextBoxColumn
    Friend WithEvents knot_thread_id As DataGridViewTextBoxColumn
    Friend WithEvents knot_thread_no As DataGridViewTextBoxColumn
    Friend WithEvents knot_strands As DataGridViewTextBoxColumn
    Friend WithEvents knot_type As DataGridViewTextBoxColumn
End Class
