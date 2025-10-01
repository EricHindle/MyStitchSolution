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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmColourCapture))
        Me.Piccolour = New System.Windows.Forms.PictureBox()
        Me.TxtB = New System.Windows.Forms.TextBox()
        Me.TxtG = New System.Windows.Forms.TextBox()
        Me.TxtR = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblColour = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSaveImage = New System.Windows.Forms.Button()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnPasteImage = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Piccolour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Piccolour
        '
        Me.Piccolour.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Piccolour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Piccolour.Location = New System.Drawing.Point(13, 13)
        Me.Piccolour.Margin = New System.Windows.Forms.Padding(4)
        Me.Piccolour.Name = "Piccolour"
        Me.Piccolour.Size = New System.Drawing.Size(448, 368)
        Me.Piccolour.TabIndex = 0
        Me.Piccolour.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Piccolour, "Double left click to paste image" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right click to select colour")
        '
        'TxtB
        '
        Me.TxtB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtB.Location = New System.Drawing.Point(73, 140)
        Me.TxtB.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtB.Name = "TxtB"
        Me.TxtB.Size = New System.Drawing.Size(55, 25)
        Me.TxtB.TabIndex = 136
        '
        'TxtG
        '
        Me.TxtG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtG.Location = New System.Drawing.Point(73, 105)
        Me.TxtG.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtG.Name = "TxtG"
        Me.TxtG.Size = New System.Drawing.Size(55, 25)
        Me.TxtG.TabIndex = 135
        '
        'TxtR
        '
        Me.TxtR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtR.Location = New System.Drawing.Point(73, 70)
        Me.TxtR.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtR.Name = "TxtR"
        Me.TxtR.Size = New System.Drawing.Size(55, 25)
        Me.TxtR.TabIndex = 134
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 143)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 18)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Blue"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 108)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 18)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "Green"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 73)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 18)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Red"
        '
        'LblColour
        '
        Me.LblColour.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblColour.Location = New System.Drawing.Point(83, 12)
        Me.LblColour.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblColour.Name = "LblColour"
        Me.LblColour.Size = New System.Drawing.Size(45, 45)
        Me.LblColour.TabIndex = 130
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 19)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Colour"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 442)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(643, 22)
        Me.StatusStrip1.TabIndex = 140
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(550, 389)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 40)
        Me.BtnClose.TabIndex = 141
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnSaveImage
        '
        Me.BtnSaveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnSaveImage.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveImage.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSaveImage.Location = New System.Drawing.Point(360, 389)
        Me.BtnSaveImage.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSaveImage.Name = "BtnSaveImage"
        Me.BtnSaveImage.Size = New System.Drawing.Size(101, 40)
        Me.BtnSaveImage.TabIndex = 142
        Me.BtnSaveImage.Text = "Save Image"
        Me.BtnSaveImage.UseVisualStyleBackColor = False
        '
        'BtnLoad
        '
        Me.BtnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnLoad.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoad.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoad.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLoad.Location = New System.Drawing.Point(146, 389)
        Me.BtnLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(101, 40)
        Me.BtnLoad.TabIndex = 143
        Me.BtnLoad.Text = "Load Image"
        Me.BtnLoad.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(468, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 72)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "Load or paste an image" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold the right button" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Point to a colour " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Release to sel" &
    "ect"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtB)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LblColour)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtR)
        Me.Panel1.Controls.Add(Me.TxtG)
        Me.Panel1.Location = New System.Drawing.Point(471, 105)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(148, 194)
        Me.Panel1.TabIndex = 145
        '
        'BtnPasteImage
        '
        Me.BtnPasteImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnPasteImage.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnPasteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPasteImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPasteImage.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPasteImage.Location = New System.Drawing.Point(24, 389)
        Me.BtnPasteImage.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnPasteImage.Name = "BtnPasteImage"
        Me.BtnPasteImage.Size = New System.Drawing.Size(102, 40)
        Me.BtnPasteImage.TabIndex = 146
        Me.BtnPasteImage.Text = "Paste Image"
        Me.BtnPasteImage.UseVisualStyleBackColor = False
        '
        'FrmColourCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 464)
        Me.Controls.Add(Me.BtnPasteImage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLoad)
        Me.Controls.Add(Me.BtnSaveImage)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Piccolour)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmColourCapture"
        Me.Text = "Colour Capture"
        CType(Me.Piccolour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Piccolour As PictureBox
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
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnPasteImage As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
