' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSymbols
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSymbols))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.FlpSymbols = New System.Windows.Forms.FlowLayoutPanel()
        Me.TxtFilename = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicSymbolSource = New System.Windows.Forms.PictureBox()
        Me.BtnImageSel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnAddSymbol = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PicSymbolSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 456)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(939, 22)
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
        Me.BtnClose.Location = New System.Drawing.Point(839, 411)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 31)
        Me.BtnClose.TabIndex = 159
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'FlpSymbols
        '
        Me.FlpSymbols.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlpSymbols.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FlpSymbols.Location = New System.Drawing.Point(13, 13)
        Me.FlpSymbols.Margin = New System.Windows.Forms.Padding(4)
        Me.FlpSymbols.Name = "FlpSymbols"
        Me.FlpSymbols.Size = New System.Drawing.Size(520, 416)
        Me.FlpSymbols.TabIndex = 162
        '
        'TxtFilename
        '
        Me.TxtFilename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFilename.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilename.Location = New System.Drawing.Point(627, 34)
        Me.TxtFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFilename.Name = "TxtFilename"
        Me.TxtFilename.Size = New System.Drawing.Size(221, 24)
        Me.TxtFilename.TabIndex = 163
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(542, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "Image File"
        '
        'PicSymbolSource
        '
        Me.PicSymbolSource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicSymbolSource.BackColor = System.Drawing.Color.White
        Me.PicSymbolSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicSymbolSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicSymbolSource.Location = New System.Drawing.Point(627, 75)
        Me.PicSymbolSource.Name = "PicSymbolSource"
        Me.PicSymbolSource.Size = New System.Drawing.Size(64, 64)
        Me.PicSymbolSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSymbolSource.TabIndex = 166
        Me.PicSymbolSource.TabStop = False
        '
        'BtnImageSel
        '
        Me.BtnImageSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImageSel.BackgroundImage = Global.MyStitch.My.Resources.Resources.imageselect
        Me.BtnImageSel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnImageSel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnImageSel.FlatAppearance.BorderSize = 0
        Me.BtnImageSel.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnImageSel.Location = New System.Drawing.Point(856, 25)
        Me.BtnImageSel.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnImageSel.Name = "BtnImageSel"
        Me.BtnImageSel.Size = New System.Drawing.Size(37, 40)
        Me.BtnImageSel.TabIndex = 164
        Me.BtnImageSel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(542, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = "Image"
        '
        'BtnAddSymbol
        '
        Me.BtnAddSymbol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddSymbol.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnAddSymbol.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddSymbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddSymbol.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddSymbol.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnAddSymbol.Location = New System.Drawing.Point(743, 75)
        Me.BtnAddSymbol.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAddSymbol.Name = "BtnAddSymbol"
        Me.BtnAddSymbol.Size = New System.Drawing.Size(80, 31)
        Me.BtnAddSymbol.TabIndex = 168
        Me.BtnAddSymbol.Text = "Add"
        Me.BtnAddSymbol.UseVisualStyleBackColor = False
        '
        'FrmSymbols
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 478)
        Me.Controls.Add(Me.BtnAddSymbol)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PicSymbolSource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnImageSel)
        Me.Controls.Add(Me.TxtFilename)
        Me.Controls.Add(Me.FlpSymbols)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmSymbols"
        Me.Text = "Symbols"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PicSymbolSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents BtnClose As Button
    Friend WithEvents FlpSymbols As FlowLayoutPanel
    Friend WithEvents BtnImageSel As Button
    Friend WithEvents TxtFilename As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PicSymbolSource As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnAddSymbol As Button
End Class
