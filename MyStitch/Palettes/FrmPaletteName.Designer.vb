' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPaletteName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPaletteName))
        Me.BtnCancelPalette = New System.Windows.Forms.Button()
        Me.BtnSavePalette = New System.Windows.Forms.Button()
        Me.TxtPaletteName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblProjectName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnCancelPalette
        '
        Me.BtnCancelPalette.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelPalette.BackColor = System.Drawing.Color.MistyRose
        Me.BtnCancelPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelPalette.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelPalette.Location = New System.Drawing.Point(17, 122)
        Me.BtnCancelPalette.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCancelPalette.Name = "BtnCancelPalette"
        Me.BtnCancelPalette.Size = New System.Drawing.Size(70, 28)
        Me.BtnCancelPalette.TabIndex = 3
        Me.BtnCancelPalette.Text = "Cancel"
        Me.BtnCancelPalette.UseVisualStyleBackColor = False
        '
        'BtnSavePalette
        '
        Me.BtnSavePalette.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSavePalette.BackColor = System.Drawing.Color.Honeydew
        Me.BtnSavePalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSavePalette.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSavePalette.Location = New System.Drawing.Point(166, 122)
        Me.BtnSavePalette.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSavePalette.Name = "BtnSavePalette"
        Me.BtnSavePalette.Size = New System.Drawing.Size(67, 28)
        Me.BtnSavePalette.TabIndex = 2
        Me.BtnSavePalette.Text = "Save"
        Me.BtnSavePalette.UseVisualStyleBackColor = False
        '
        'TxtPaletteName
        '
        Me.TxtPaletteName.Location = New System.Drawing.Point(17, 85)
        Me.TxtPaletteName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPaletteName.Name = "TxtPaletteName"
        Me.TxtPaletteName.Size = New System.Drawing.Size(220, 23)
        Me.TxtPaletteName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 65)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Give the Palette a Name"
        '
        'LblProjectName
        '
        Me.LblProjectName.AutoSize = True
        Me.LblProjectName.BackColor = System.Drawing.SystemColors.Control
        Me.LblProjectName.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProjectName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblProjectName.Location = New System.Drawing.Point(9, 9)
        Me.LblProjectName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblProjectName.Name = "LblProjectName"
        Me.LblProjectName.Size = New System.Drawing.Size(78, 19)
        Me.LblProjectName.TabIndex = 19
        Me.LblProjectName.Text = "PROJECT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Felix Titling", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(45, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "SAVING THE PALETTE"
        '
        'FrmPaletteName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 163)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblProjectName)
        Me.Controls.Add(Me.BtnSavePalette)
        Me.Controls.Add(Me.BtnCancelPalette)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPaletteName)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPaletteName"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancelPalette As Button
    Friend WithEvents BtnSavePalette As Button
    Friend WithEvents TxtPaletteName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblProjectName As Label
    Friend WithEvents Label2 As Label
End Class
