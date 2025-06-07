' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSymbols
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSymbols))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.FlpSymbols = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnImageSel = New System.Windows.Forms.Button()
        Me.TxtFilename = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 563)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(755, 22)
        Me.StatusStrip1.TabIndex = 153
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(6, 17)
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(651, 514)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 31)
        Me.BtnClose.TabIndex = 159
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'FlpSymbols
        '
        Me.FlpSymbols.Location = New System.Drawing.Point(26, 26)
        Me.FlpSymbols.Name = "FlpSymbols"
        Me.FlpSymbols.Size = New System.Drawing.Size(200, 462)
        Me.FlpSymbols.TabIndex = 162
        '
        'BtnImageSel
        '
        Me.BtnImageSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImageSel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnImageSel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnImageSel.FlatAppearance.BorderSize = 0
        Me.BtnImageSel.ForeColor = System.Drawing.Color.SaddleBrown
        Me.BtnImageSel.Location = New System.Drawing.Point(448, 23)
        Me.BtnImageSel.Name = "BtnImageSel"
        Me.BtnImageSel.Size = New System.Drawing.Size(32, 26)
        Me.BtnImageSel.TabIndex = 164
        Me.BtnImageSel.UseVisualStyleBackColor = True
        '
        'TxtFilename
        '
        Me.TxtFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFilename.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilename.Location = New System.Drawing.Point(267, 26)
        Me.TxtFilename.Name = "TxtFilename"
        Me.TxtFilename.Size = New System.Drawing.Size(175, 24)
        Me.TxtFilename.TabIndex = 163
        '
        'FrmSymbols
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 585)
        Me.Controls.Add(Me.BtnImageSel)
        Me.Controls.Add(Me.TxtFilename)
        Me.Controls.Add(Me.FlpSymbols)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSymbols"
        Me.Text = "Symbols"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents BtnClose As Button
    Friend WithEvents FlpSymbols As FlowLayoutPanel
    Friend WithEvents BtnImageSel As Button
    Friend WithEvents TxtFilename As TextBox
End Class
