<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRestore))
        Me.BtnSelectAll = New System.Windows.Forms.Button()
        Me.BtnSelectPath = New System.Windows.Forms.Button()
        Me.BtnRestore = New System.Windows.Forms.Button()
        Me.TxtBackupPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TvDatatables = New System.Windows.Forms.TreeView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rtbProgress = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSelectAll
        '
        Me.BtnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelectAll.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectAll.ForeColor = System.Drawing.Color.Black
        Me.BtnSelectAll.Location = New System.Drawing.Point(555, 408)
        Me.BtnSelectAll.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelectAll.Name = "BtnSelectAll"
        Me.BtnSelectAll.Size = New System.Drawing.Size(108, 45)
        Me.BtnSelectAll.TabIndex = 22
        Me.BtnSelectAll.Text = "Select All"
        Me.BtnSelectAll.UseVisualStyleBackColor = False
        '
        'BtnSelectPath
        '
        Me.BtnSelectPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSelectPath.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSelectPath.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelectPath.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectPath.ForeColor = System.Drawing.Color.Black
        Me.BtnSelectPath.Location = New System.Drawing.Point(411, 415)
        Me.BtnSelectPath.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelectPath.Name = "BtnSelectPath"
        Me.BtnSelectPath.Size = New System.Drawing.Size(116, 35)
        Me.BtnSelectPath.TabIndex = 20
        Me.BtnSelectPath.Text = "Select path"
        Me.BtnSelectPath.UseVisualStyleBackColor = False
        '
        'BtnRestore
        '
        Me.BtnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRestore.BackColor = System.Drawing.SystemColors.Control
        Me.BtnRestore.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRestore.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRestore.ForeColor = System.Drawing.Color.Black
        Me.BtnRestore.Location = New System.Drawing.Point(699, 408)
        Me.BtnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnRestore.Name = "BtnRestore"
        Me.BtnRestore.Size = New System.Drawing.Size(108, 45)
        Me.BtnRestore.TabIndex = 18
        Me.BtnRestore.Text = "Restore"
        Me.BtnRestore.UseVisualStyleBackColor = False
        '
        'TxtBackupPath
        '
        Me.TxtBackupPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBackupPath.Location = New System.Drawing.Point(120, 419)
        Me.TxtBackupPath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBackupPath.Name = "TxtBackupPath"
        Me.TxtBackupPath.Size = New System.Drawing.Size(283, 25)
        Me.TxtBackupPath.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 422)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 18)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Backup Folder"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnCancel.Image = Global.MyNovel.My.Resources.Resources.StdDock1
        Me.btnCancel.Location = New System.Drawing.Point(902, 409)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(44, 44)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 465)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(963, 22)
        Me.StatusStrip1.TabIndex = 23
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(10, 17)
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer3.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer3.Size = New System.Drawing.Size(939, 381)
        Me.SplitContainer3.SplitterDistance = 318
        Me.SplitContainer3.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TvDatatables)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(314, 377)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tables"
        '
        'TvDatatables
        '
        Me.TvDatatables.BackColor = System.Drawing.Color.LightGray
        Me.TvDatatables.CheckBoxes = True
        Me.TvDatatables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TvDatatables.ForeColor = System.Drawing.Color.Black
        Me.TvDatatables.Location = New System.Drawing.Point(3, 21)
        Me.TvDatatables.Name = "TvDatatables"
        Me.TvDatatables.Size = New System.Drawing.Size(308, 353)
        Me.TvDatatables.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rtbProgress)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(613, 377)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Progress"
        '
        'rtbProgress
        '
        Me.rtbProgress.BackColor = System.Drawing.Color.Black
        Me.rtbProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbProgress.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbProgress.ForeColor = System.Drawing.Color.White
        Me.rtbProgress.Location = New System.Drawing.Point(3, 21)
        Me.rtbProgress.Name = "rtbProgress"
        Me.rtbProgress.Size = New System.Drawing.Size(607, 353)
        Me.rtbProgress.TabIndex = 8
        Me.rtbProgress.Text = ""
        '
        'FrmRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(963, 487)
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSelectAll)
        Me.Controls.Add(Me.BtnSelectPath)
        Me.Controls.Add(Me.BtnRestore)
        Me.Controls.Add(Me.TxtBackupPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmRestore"
        Me.ShowIcon = False
        Me.Text = "Restore"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSelectAll As Button
    Friend WithEvents BtnSelectPath As Button
    Friend WithEvents BtnRestore As Button
    Friend WithEvents TxtBackupPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TvDatatables As TreeView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rtbProgress As RichTextBox
    Friend WithEvents LblStatus As ToolStripStatusLabel
End Class
