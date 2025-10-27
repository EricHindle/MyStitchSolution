' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmText))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PicText = New System.Windows.Forms.PictureBox()
        Me.TxtText = New System.Windows.Forms.TextBox()
        Me.BtnFont = New System.Windows.Forms.Button()
        Me.TbFont = New System.Windows.Forms.TrackBar()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.LblFont = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblColour = New System.Windows.Forms.Label()
        Me.PicStitches = New System.Windows.Forms.PictureBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PicText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbFont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicStitches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 410)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 25, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(922, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(2, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(9, 17)
        '
        'PicText
        '
        Me.PicText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicText.BackColor = System.Drawing.Color.White
        Me.PicText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicText.Location = New System.Drawing.Point(13, 17)
        Me.PicText.Margin = New System.Windows.Forms.Padding(4)
        Me.PicText.Name = "PicText"
        Me.PicText.Size = New System.Drawing.Size(596, 87)
        Me.PicText.TabIndex = 2
        Me.PicText.TabStop = False
        '
        'TxtText
        '
        Me.TxtText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtText.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtText.Location = New System.Drawing.Point(617, 266)
        Me.TxtText.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtText.Multiline = True
        Me.TxtText.Name = "TxtText"
        Me.TxtText.Size = New System.Drawing.Size(293, 102)
        Me.TxtText.TabIndex = 3
        '
        'BtnFont
        '
        Me.BtnFont.BackColor = System.Drawing.Color.White
        Me.BtnFont.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFont.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFont.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnFont.Location = New System.Drawing.Point(80, 86)
        Me.BtnFont.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnFont.Name = "BtnFont"
        Me.BtnFont.Size = New System.Drawing.Size(117, 36)
        Me.BtnFont.TabIndex = 4
        Me.BtnFont.Text = "Select Font"
        Me.BtnFont.UseVisualStyleBackColor = False
        '
        'TbFont
        '
        Me.TbFont.AutoSize = False
        Me.TbFont.Location = New System.Drawing.Point(97, 180)
        Me.TbFont.Name = "TbFont"
        Me.TbFont.Size = New System.Drawing.Size(191, 25)
        Me.TbFont.TabIndex = 5
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(831, 372)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(77, 33)
        Me.BtnClose.TabIndex = 9
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'LblFont
        '
        Me.LblFont.Location = New System.Drawing.Point(18, 26)
        Me.LblFont.Name = "LblFont"
        Me.LblFont.Size = New System.Drawing.Size(258, 50)
        Me.LblFont.TabIndex = 10
        Me.LblFont.Text = "Label1"
        Me.LblFont.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Design Size"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblColour)
        Me.GroupBox1.Controls.Add(Me.LblFont)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TbFont)
        Me.GroupBox1.Controls.Add(Me.BtnFont)
        Me.GroupBox1.Location = New System.Drawing.Point(616, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 211)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Font"
        '
        'LblColour
        '
        Me.LblColour.BackColor = System.Drawing.Color.White
        Me.LblColour.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblColour.ForeColor = System.Drawing.Color.Black
        Me.LblColour.Location = New System.Drawing.Point(24, 126)
        Me.LblColour.Name = "LblColour"
        Me.LblColour.Size = New System.Drawing.Size(229, 40)
        Me.LblColour.TabIndex = 13
        Me.LblColour.Text = "Sample"
        Me.LblColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PicStitches
        '
        Me.PicStitches.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicStitches.BackColor = System.Drawing.Color.White
        Me.PicStitches.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicStitches.Location = New System.Drawing.Point(13, 112)
        Me.PicStitches.Margin = New System.Windows.Forms.Padding(4)
        Me.PicStitches.Name = "PicStitches"
        Me.PicStitches.Size = New System.Drawing.Size(596, 256)
        Me.PicStitches.TabIndex = 13
        Me.PicStitches.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(717, 244)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Type Text"
        '
        'FrmText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 432)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicStitches)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.TxtText)
        Me.Controls.Add(Me.PicText)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmText"
        Me.Text = "Text"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PicText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbFont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicStitches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents PicText As PictureBox
    Friend WithEvents TxtText As TextBox
    Friend WithEvents BtnFont As Button
    Friend WithEvents TbFont As TrackBar
    Friend WithEvents BtnClose As Button
    Friend WithEvents LblFont As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PicStitches As PictureBox
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents LblColour As Label
    Friend WithEvents Label1 As Label
End Class
