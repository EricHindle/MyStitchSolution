' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBrands
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBrands))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblId = New System.Windows.Forms.Label()
        Me.DgvBrands = New System.Windows.Forms.DataGridView()
        Me.brandId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brandName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.PnlForm = New System.Windows.Forms.Panel()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgvBrands, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 265)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(610, 22)
        Me.StatusStrip1.TabIndex = 151
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Felix Titling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(113, 3)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 23)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "BRANDS"
        '
        'BtnClear
        '
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClear.Location = New System.Drawing.Point(16, 205)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(80, 40)
        Me.BtnClear.TabIndex = 148
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNew.Location = New System.Drawing.Point(16, 8)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(80, 40)
        Me.BtnNew.TabIndex = 145
        Me.BtnNew.Text = "Add"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(17, 86)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(253, 27)
        Me.TxtName.TabIndex = 106
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(17, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 19)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Name"
        '
        'LblId
        '
        Me.LblId.AutoSize = True
        Me.LblId.BackColor = System.Drawing.SystemColors.Control
        Me.LblId.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblId.Location = New System.Drawing.Point(13, 19)
        Me.LblId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(24, 19)
        Me.LblId.TabIndex = 108
        Me.LblId.Text = "Id"
        '
        'DgvBrands
        '
        Me.DgvBrands.AllowUserToAddRows = False
        Me.DgvBrands.AllowUserToDeleteRows = False
        Me.DgvBrands.AllowUserToResizeRows = False
        Me.DgvBrands.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvBrands.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvBrands.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvBrands.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBrands.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.brandId, Me.brandName})
        Me.DgvBrands.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgvBrands.Location = New System.Drawing.Point(117, 30)
        Me.DgvBrands.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvBrands.MultiSelect = False
        Me.DgvBrands.Name = "DgvBrands"
        Me.DgvBrands.ReadOnly = True
        Me.DgvBrands.RowHeadersVisible = False
        Me.DgvBrands.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DgvBrands.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DgvBrands.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
        Me.DgvBrands.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.DgvBrands.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvBrands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvBrands.Size = New System.Drawing.Size(198, 215)
        Me.DgvBrands.TabIndex = 147
        '
        'brandId
        '
        Me.brandId.HeaderText = "Id"
        Me.brandId.Name = "brandId"
        Me.brandId.ReadOnly = True
        Me.brandId.Visible = False
        '
        'brandName
        '
        Me.brandName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.brandName.HeaderText = "Name"
        Me.brandName.Name = "brandName"
        Me.brandName.ReadOnly = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(517, 218)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 152
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete.Location = New System.Drawing.Point(16, 128)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 40)
        Me.BtnDelete.TabIndex = 146
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'PnlForm
        '
        Me.PnlForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlForm.Controls.Add(Me.TxtName)
        Me.PnlForm.Controls.Add(Me.Label1)
        Me.PnlForm.Controls.Add(Me.LblId)
        Me.PnlForm.Location = New System.Drawing.Point(323, 30)
        Me.PnlForm.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlForm.Name = "PnlForm"
        Me.PnlForm.Size = New System.Drawing.Size(274, 150)
        Me.PnlForm.TabIndex = 150
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnUpdate.Location = New System.Drawing.Point(16, 68)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(80, 40)
        Me.BtnUpdate.TabIndex = 144
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'FrmBrands
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 287)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.DgvBrands)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.PnlForm)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmBrands"
        Me.Text = "Brands"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgvBrands, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlForm.ResumeLayout(False)
        Me.PnlForm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnNew As Button
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblId As Label
    Friend WithEvents DgvBrands As DataGridView
    Friend WithEvents brandId As DataGridViewTextBoxColumn
    Friend WithEvents brandName As DataGridViewTextBoxColumn
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents PnlForm As Panel
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
