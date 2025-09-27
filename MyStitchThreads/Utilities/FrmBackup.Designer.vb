<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBackup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBackup))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TvDatatables = New System.Windows.Forms.TreeView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TvDesigns = New System.Windows.Forms.TreeView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TvImages = New System.Windows.Forms.TreeView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PbCopyProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.LblCounts = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBackupPath = New System.Windows.Forms.TextBox()
        Me.BtnBackup = New System.Windows.Forms.Button()
        Me.rtbProgress = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.BtnSavePath = New System.Windows.Forms.Button()
        Me.BtnSelectPath = New System.Windows.Forms.Button()
        Me.chkAddDate = New System.Windows.Forms.CheckBox()
        Me.BtnSelectAll = New System.Windows.Forms.Button()
        Me.ChkArchive = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ChkRevision = New System.Windows.Forms.CheckBox()
        Me.ChkIncludeDb = New System.Windows.Forms.CheckBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TvDatatables)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 214)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data"
        '
        'TvDatatables
        '
        Me.TvDatatables.BackColor = System.Drawing.Color.LightGray
        Me.TvDatatables.CheckBoxes = True
        Me.TvDatatables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TvDatatables.Location = New System.Drawing.Point(3, 21)
        Me.TvDatatables.Name = "TvDatatables"
        Me.TvDatatables.Size = New System.Drawing.Size(453, 190)
        Me.TvDatatables.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TvDesigns)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(459, 272)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Designs"
        '
        'TvDesigns
        '
        Me.TvDesigns.BackColor = System.Drawing.Color.LightGray
        Me.TvDesigns.CheckBoxes = True
        Me.TvDesigns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TvDesigns.Location = New System.Drawing.Point(3, 21)
        Me.TvDesigns.Name = "TvDesigns"
        Me.TvDesigns.Size = New System.Drawing.Size(453, 248)
        Me.TvDesigns.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TvImages)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(490, 211)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Images"
        '
        'TvImages
        '
        Me.TvImages.BackColor = System.Drawing.Color.LightGray
        Me.TvImages.CheckBoxes = True
        Me.TvImages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TvImages.Location = New System.Drawing.Point(3, 21)
        Me.TvImages.Name = "TvImages"
        Me.TvImages.Size = New System.Drawing.Size(484, 187)
        Me.TvImages.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus, Me.PbCopyProgress, Me.LblCounts})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 599)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(985, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(10, 19)
        '
        'PbCopyProgress
        '
        Me.PbCopyProgress.Name = "PbCopyProgress"
        Me.PbCopyProgress.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.PbCopyProgress.Size = New System.Drawing.Size(306, 18)
        Me.PbCopyProgress.Step = 1
        '
        'LblCounts
        '
        Me.LblCounts.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.LblCounts.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblCounts.ForeColor = System.Drawing.Color.Black
        Me.LblCounts.Name = "LblCounts"
        Me.LblCounts.Size = New System.Drawing.Size(62, 19)
        Me.LblCounts.Text = "T:0 D:0 I:0"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 543)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Destination Folder"
        '
        'TxtBackupPath
        '
        Me.TxtBackupPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBackupPath.Location = New System.Drawing.Point(125, 537)
        Me.TxtBackupPath.Name = "TxtBackupPath"
        Me.TxtBackupPath.Size = New System.Drawing.Size(185, 25)
        Me.TxtBackupPath.TabIndex = 6
        '
        'BtnBackup
        '
        Me.BtnBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBackup.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBackup.ForeColor = System.Drawing.Color.Black
        Me.BtnBackup.Location = New System.Drawing.Point(791, 540)
        Me.BtnBackup.Name = "BtnBackup"
        Me.BtnBackup.Size = New System.Drawing.Size(87, 41)
        Me.BtnBackup.TabIndex = 7
        Me.BtnBackup.Text = "Backup"
        Me.BtnBackup.UseVisualStyleBackColor = True
        '
        'rtbProgress
        '
        Me.rtbProgress.BackColor = System.Drawing.Color.Black
        Me.rtbProgress.ContextMenuStrip = Me.ContextMenuStrip1
        Me.rtbProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbProgress.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbProgress.ForeColor = System.Drawing.Color.White
        Me.rtbProgress.Location = New System.Drawing.Point(3, 21)
        Me.rtbProgress.Name = "rtbProgress"
        Me.rtbProgress.Size = New System.Drawing.Size(484, 251)
        Me.rtbProgress.TabIndex = 8
        Me.rtbProgress.Text = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuClear})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(102, 26)
        '
        'MnuClear
        '
        Me.MnuClear.Name = "MnuClear"
        Me.MnuClear.Size = New System.Drawing.Size(101, 22)
        Me.MnuClear.Text = "Clear"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rtbProgress)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(490, 275)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Progress"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(961, 498)
        Me.SplitContainer1.SplitterDistance = 463
        Me.SplitContainer1.TabIndex = 10
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(463, 498)
        Me.SplitContainer2.SplitterDistance = 218
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
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer3.Size = New System.Drawing.Size(494, 498)
        Me.SplitContainer3.SplitterDistance = 215
        Me.SplitContainer3.TabIndex = 0
        '
        'BtnSavePath
        '
        Me.BtnSavePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSavePath.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSavePath.ForeColor = System.Drawing.Color.Black
        Me.BtnSavePath.Location = New System.Drawing.Point(223, 566)
        Me.BtnSavePath.Name = "BtnSavePath"
        Me.BtnSavePath.Size = New System.Drawing.Size(87, 25)
        Me.BtnSavePath.TabIndex = 11
        Me.BtnSavePath.Text = "Save path"
        Me.BtnSavePath.UseVisualStyleBackColor = True
        '
        'BtnSelectPath
        '
        Me.BtnSelectPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSelectPath.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectPath.ForeColor = System.Drawing.Color.Black
        Me.BtnSelectPath.Location = New System.Drawing.Point(125, 566)
        Me.BtnSelectPath.Name = "BtnSelectPath"
        Me.BtnSelectPath.Size = New System.Drawing.Size(87, 25)
        Me.BtnSelectPath.TabIndex = 12
        Me.BtnSelectPath.Text = "Select path"
        Me.BtnSelectPath.UseVisualStyleBackColor = True
        '
        'chkAddDate
        '
        Me.chkAddDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAddDate.AutoSize = True
        Me.chkAddDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddDate.ForeColor = System.Drawing.Color.Black
        Me.chkAddDate.Location = New System.Drawing.Point(316, 542)
        Me.chkAddDate.Name = "chkAddDate"
        Me.chkAddDate.Size = New System.Drawing.Size(77, 18)
        Me.chkAddDate.TabIndex = 13
        Me.chkAddDate.Text = "Add date"
        Me.chkAddDate.UseVisualStyleBackColor = True
        '
        'BtnSelectAll
        '
        Me.BtnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSelectAll.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectAll.ForeColor = System.Drawing.Color.Black
        Me.BtnSelectAll.Location = New System.Drawing.Point(698, 536)
        Me.BtnSelectAll.Name = "BtnSelectAll"
        Me.BtnSelectAll.Size = New System.Drawing.Size(87, 48)
        Me.BtnSelectAll.TabIndex = 14
        Me.BtnSelectAll.Text = "Select All Items"
        Me.BtnSelectAll.UseVisualStyleBackColor = True
        '
        'ChkArchive
        '
        Me.ChkArchive.AutoSize = True
        Me.ChkArchive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkArchive.ForeColor = System.Drawing.Color.Black
        Me.ChkArchive.Location = New System.Drawing.Point(6, 15)
        Me.ChkArchive.Name = "ChkArchive"
        Me.ChkArchive.Size = New System.Drawing.Size(110, 18)
        Me.ChkArchive.TabIndex = 17
        Me.ChkArchive.Text = "Include Archive"
        Me.ChkArchive.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.ChkRevision)
        Me.GroupBox6.Controls.Add(Me.ChkIncludeDb)
        Me.GroupBox6.Controls.Add(Me.ChkArchive)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(399, 511)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(134, 80)
        Me.GroupBox6.TabIndex = 18
        Me.GroupBox6.TabStop = False
        '
        'ChkRevision
        '
        Me.ChkRevision.AutoSize = True
        Me.ChkRevision.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkRevision.ForeColor = System.Drawing.Color.Black
        Me.ChkRevision.Location = New System.Drawing.Point(6, 59)
        Me.ChkRevision.Name = "ChkRevision"
        Me.ChkRevision.Size = New System.Drawing.Size(108, 18)
        Me.ChkRevision.TabIndex = 19
        Me.ChkRevision.Text = "Add Revision #"
        Me.ChkRevision.UseVisualStyleBackColor = True
        '
        'ChkIncludeDb
        '
        Me.ChkIncludeDb.AutoSize = True
        Me.ChkIncludeDb.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkIncludeDb.ForeColor = System.Drawing.Color.Black
        Me.ChkIncludeDb.Location = New System.Drawing.Point(6, 37)
        Me.ChkIncludeDb.Name = "ChkIncludeDb"
        Me.ChkIncludeDb.Size = New System.Drawing.Size(120, 18)
        Me.ChkIncludeDb.TabIndex = 18
        Me.ChkIncludeDb.Text = "Include Database"
        Me.ChkIncludeDb.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(891, 540)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 142
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'FrmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 623)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.BtnSelectAll)
        Me.Controls.Add(Me.chkAddDate)
        Me.Controls.Add(Me.BtnSelectPath)
        Me.Controls.Add(Me.BtnSavePath)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BtnBackup)
        Me.Controls.Add(Me.TxtBackupPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmBackup"
        Me.ShowIcon = False
        Me.Text = "Backup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TvDatatables As TreeView
    Friend WithEvents TvDesigns As TreeView
    Friend WithEvents TvImages As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtBackupPath As TextBox
    Friend WithEvents BtnBackup As Button
    Friend WithEvents rtbProgress As RichTextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents BtnSavePath As Button
    Friend WithEvents BtnSelectPath As Button
    Friend WithEvents chkAddDate As CheckBox
    Friend WithEvents BtnSelectAll As Button
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents PbCopyProgress As ToolStripProgressBar
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MnuClear As ToolStripMenuItem
    Friend WithEvents ChkArchive As CheckBox
    Friend WithEvents LblCounts As ToolStripStatusLabel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents ChkIncludeDb As CheckBox
    Friend WithEvents ChkRevision As CheckBox
    Friend WithEvents BtnClose As Button
End Class
