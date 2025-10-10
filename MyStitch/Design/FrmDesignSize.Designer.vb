' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesignSize
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
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.LblRows = New System.Windows.Forms.Label()
        Me.LblColumns = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NudTop = New System.Windows.Forms.NumericUpDown()
        Me.NudBottom = New System.Windows.Forms.NumericUpDown()
        Me.NudLeft = New System.Windows.Forms.NumericUpDown()
        Me.NudRight = New System.Windows.Forms.NumericUpDown()
        CType(Me.NudTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.BackColor = System.Drawing.Color.MistyRose
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(210, 154)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(60, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackColor = System.Drawing.Color.Honeydew
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(92, 154)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(60, 23)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'LblRows
        '
        Me.LblRows.AutoSize = True
        Me.LblRows.Location = New System.Drawing.Point(12, 9)
        Me.LblRows.Name = "LblRows"
        Me.LblRows.Size = New System.Drawing.Size(150, 17)
        Me.LblRows.TabIndex = 6
        Me.LblRows.Text = "Number of rows to add"
        '
        'LblColumns
        '
        Me.LblColumns.AutoSize = True
        Me.LblColumns.Location = New System.Drawing.Point(12, 80)
        Me.LblColumns.Name = "LblColumns"
        Me.LblColumns.Size = New System.Drawing.Size(172, 17)
        Me.LblColumns.TabIndex = 7
        Me.LblColumns.Text = "Number of columns to add"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Top"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Bottom"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Left"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(156, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Right"
        '
        'NudTop
        '
        Me.NudTop.Location = New System.Drawing.Point(76, 35)
        Me.NudTop.Name = "NudTop"
        Me.NudTop.Size = New System.Drawing.Size(54, 24)
        Me.NudTop.TabIndex = 12
        '
        'NudBottom
        '
        Me.NudBottom.Location = New System.Drawing.Point(216, 35)
        Me.NudBottom.Name = "NudBottom"
        Me.NudBottom.Size = New System.Drawing.Size(54, 24)
        Me.NudBottom.TabIndex = 13
        '
        'NudLeft
        '
        Me.NudLeft.Location = New System.Drawing.Point(76, 111)
        Me.NudLeft.Name = "NudLeft"
        Me.NudLeft.Size = New System.Drawing.Size(54, 24)
        Me.NudLeft.TabIndex = 14
        '
        'NudRight
        '
        Me.NudRight.Location = New System.Drawing.Point(216, 111)
        Me.NudRight.Name = "NudRight"
        Me.NudRight.Size = New System.Drawing.Size(54, 24)
        Me.NudRight.TabIndex = 15
        '
        'FrmDesignSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(280, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.NudRight)
        Me.Controls.Add(Me.NudLeft)
        Me.Controls.Add(Me.NudBottom)
        Me.Controls.Add(Me.NudTop)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblColumns)
        Me.Controls.Add(Me.LblRows)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmDesignSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Extend Design"
        CType(Me.NudTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents LblRows As Label
    Friend WithEvents LblColumns As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents NudTop As NumericUpDown
    Friend WithEvents NudBottom As NumericUpDown
    Friend WithEvents NudLeft As NumericUpDown
    Friend WithEvents NudRight As NumericUpDown
End Class
