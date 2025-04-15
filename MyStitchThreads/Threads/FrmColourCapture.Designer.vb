' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmColourCapture
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Piccolour = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtB = New System.Windows.Forms.TextBox()
        Me.TxtG = New System.Windows.Forms.TextBox()
        Me.TxtR = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblColour = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSaveImage = New System.Windows.Forms.Button()
        Me.BtnLoad = New System.Windows.Forms.Button()
        CType(Me.Piccolour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Piccolour
        '
        Me.Piccolour.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Piccolour.Location = New System.Drawing.Point(16, 17)
        Me.Piccolour.Margin = New System.Windows.Forms.Padding(4)
        Me.Piccolour.Name = "Piccolour"
        Me.Piccolour.Size = New System.Drawing.Size(1044, 339)
        Me.Piccolour.TabIndex = 0
        Me.Piccolour.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(857, 402)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(184, 24)
        Me.Label9.TabIndex = 139
        Me.Label9.Text = "Right-Click to select colour"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(630, 402)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 24)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Double-click to paste image"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtB
        '
        Me.TxtB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtB.Location = New System.Drawing.Point(275, 447)
        Me.TxtB.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtB.Name = "TxtB"
        Me.TxtB.Size = New System.Drawing.Size(55, 25)
        Me.TxtB.TabIndex = 136
        '
        'TxtG
        '
        Me.TxtG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtG.Location = New System.Drawing.Point(212, 447)
        Me.TxtG.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtG.Name = "TxtG"
        Me.TxtG.Size = New System.Drawing.Size(55, 25)
        Me.TxtG.TabIndex = 135
        '
        'TxtR
        '
        Me.TxtR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtR.Location = New System.Drawing.Point(149, 447)
        Me.TxtR.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtR.Name = "TxtR"
        Me.TxtR.Size = New System.Drawing.Size(55, 25)
        Me.TxtR.TabIndex = 134
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(272, 427)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 18)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "B"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(210, 427)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 18)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "G"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 427)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 18)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "R"
        '
        'LblColour
        '
        Me.LblColour.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblColour.Location = New System.Drawing.Point(85, 427)
        Me.LblColour.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblColour.Name = "LblColour"
        Me.LblColour.Size = New System.Drawing.Size(45, 45)
        Me.LblColour.TabIndex = 130
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(20, 447)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 19)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Colour"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 485)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1073, 22)
        Me.StatusStrip1.TabIndex = 140
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(980, 432)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 141
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnSaveImage
        '
        Me.BtnSaveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnSaveImage.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveImage.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSaveImage.Location = New System.Drawing.Point(849, 432)
        Me.BtnSaveImage.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSaveImage.Name = "BtnSaveImage"
        Me.BtnSaveImage.Size = New System.Drawing.Size(101, 40)
        Me.BtnSaveImage.TabIndex = 142
        Me.BtnSaveImage.Text = "Save Image"
        Me.BtnSaveImage.UseVisualStyleBackColor = False
        '
        'BtnLoad
        '
        Me.BtnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnLoad.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoad.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoad.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLoad.Location = New System.Drawing.Point(713, 432)
        Me.BtnLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(101, 40)
        Me.BtnLoad.TabIndex = 143
        Me.BtnLoad.Text = "Load Image"
        Me.BtnLoad.UseVisualStyleBackColor = False
        '
        'FrmColourCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 507)
        Me.Controls.Add(Me.BtnLoad)
        Me.Controls.Add(Me.BtnSaveImage)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtB)
        Me.Controls.Add(Me.TxtG)
        Me.Controls.Add(Me.TxtR)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblColour)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Piccolour)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmColourCapture"
        Me.Text = "Colour Capture"
        CType(Me.Piccolour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Piccolour As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtB As TextBox
    Friend WithEvents TxtG As TextBox
    Friend WithEvents TxtR As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblColour As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSaveImage As Button
    Friend WithEvents BtnLoad As Button
End Class
