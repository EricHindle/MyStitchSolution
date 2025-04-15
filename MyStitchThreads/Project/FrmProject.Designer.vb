' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProject
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
        Me.LblSelectedProject = New System.Windows.Forms.Label()
        Me.LblProjectId = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnProjectThreads = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 267)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(698, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'BtnClear
        '
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(12, 208)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(80, 40)
        Me.BtnClear.TabIndex = 117
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete.Location = New System.Drawing.Point(12, 128)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 40)
        Me.BtnDelete.TabIndex = 116
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNew.Location = New System.Drawing.Point(12, 13)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(80, 40)
        Me.BtnNew.TabIndex = 114
        Me.BtnNew.Text = "Add"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnUpdate.Location = New System.Drawing.Point(13, 70)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(80, 40)
        Me.BtnUpdate.TabIndex = 115
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(117, 9)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(100, 23)
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
        Me.DgvProjects.Location = New System.Drawing.Point(121, 36)
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
        Me.PnlForm.Controls.Add(Me.BtnProjectThreads)
        Me.PnlForm.Controls.Add(Me.LblSelectedProject)
        Me.PnlForm.Controls.Add(Me.LblProjectId)
        Me.PnlForm.Controls.Add(Me.Label1)
        Me.PnlForm.Controls.Add(Me.TxtName)
        Me.PnlForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PnlForm.Location = New System.Drawing.Point(394, 36)
        Me.PnlForm.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlForm.Name = "PnlForm"
        Me.PnlForm.Size = New System.Drawing.Size(291, 151)
        Me.PnlForm.TabIndex = 126
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
        Me.LblSelectedProject.Size = New System.Drawing.Size(241, 29)
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
        Me.Label1.Location = New System.Drawing.Point(7, 57)
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
        Me.TxtName.Location = New System.Drawing.Point(81, 53)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(205, 27)
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
        Me.BtnClose.Location = New System.Drawing.Point(605, 208)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 127
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnProjectThreads
        '
        Me.BtnProjectThreads.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnProjectThreads.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnProjectThreads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProjectThreads.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProjectThreads.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnProjectThreads.Location = New System.Drawing.Point(81, 103)
        Me.BtnProjectThreads.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProjectThreads.Name = "BtnProjectThreads"
        Me.BtnProjectThreads.Size = New System.Drawing.Size(127, 29)
        Me.BtnProjectThreads.TabIndex = 128
        Me.BtnProjectThreads.Text = "Project Threads"
        Me.BtnProjectThreads.UseVisualStyleBackColor = False
        '
        'FrmProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 289)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.PnlForm)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.DgvProjects)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmProject"
        Me.Text = "Projects"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgvProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlForm.ResumeLayout(False)
        Me.PnlForm.PerformLayout()
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
End Class
