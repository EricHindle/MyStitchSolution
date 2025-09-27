' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCriticalError
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.LblError = New System.Windows.Forms.Label()
        Me.BtnDetail = New System.Windows.Forms.Button()
        Me.LblDetails = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MyStitch.My.Resources.Resources.critical
        Me.PictureBox1.Location = New System.Drawing.Point(14, 9)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Critical Error :"
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(749, 142)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(53, 26)
        Me.BtnClose.TabIndex = 128
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'LblError
        '
        Me.LblError.AutoSize = True
        Me.LblError.Location = New System.Drawing.Point(177, 17)
        Me.LblError.Name = "LblError"
        Me.LblError.Size = New System.Drawing.Size(39, 17)
        Me.LblError.TabIndex = 129
        Me.LblError.Text = "Error"
        '
        'BtnDetail
        '
        Me.BtnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDetail.BackColor = System.Drawing.Color.Green
        Me.BtnDetail.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDetail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDetail.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDetail.Location = New System.Drawing.Point(644, 12)
        Me.BtnDetail.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnDetail.Name = "BtnDetail"
        Me.BtnDetail.Size = New System.Drawing.Size(85, 26)
        Me.BtnDetail.TabIndex = 130
        Me.BtnDetail.Text = "Show Detail"
        Me.BtnDetail.UseVisualStyleBackColor = False
        '
        'LblDetails
        '
        Me.LblDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDetails.Location = New System.Drawing.Point(115, 65)
        Me.LblDetails.Name = "LblDetails"
        Me.LblDetails.Size = New System.Drawing.Size(587, 103)
        Me.LblDetails.TabIndex = 131
        '
        'FrmCriticalError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblDetails)
        Me.Controls.Add(Me.BtnDetail)
        Me.Controls.Add(Me.LblError)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmCriticalError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents LblError As Label
    Friend WithEvents BtnDetail As Button
    Friend WithEvents LblDetails As Label
End Class
