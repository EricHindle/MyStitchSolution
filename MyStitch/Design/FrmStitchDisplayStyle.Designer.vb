' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStitchDisplayStyle
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbDesignStitchDisplay = New System.Windows.Forms.ComboBox()
        Me.CbPaletteStitchDisplay = New System.Windows.Forms.ComboBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Design Stitch Display"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Palette Stitch Display"
        '
        'CbDesignStitchDisplay
        '
        Me.CbDesignStitchDisplay.FormattingEnabled = True
        Me.CbDesignStitchDisplay.Items.AddRange(New Object() {"Crosses", "Blocks", "Coloured Symbols", "Black/White Symbols", "Blocks With Symbols"})
        Me.CbDesignStitchDisplay.Location = New System.Drawing.Point(151, 18)
        Me.CbDesignStitchDisplay.Name = "CbDesignStitchDisplay"
        Me.CbDesignStitchDisplay.Size = New System.Drawing.Size(121, 22)
        Me.CbDesignStitchDisplay.TabIndex = 2
        '
        'CbPaletteStitchDisplay
        '
        Me.CbPaletteStitchDisplay.FormattingEnabled = True
        Me.CbPaletteStitchDisplay.Items.AddRange(New Object() {"Crosses", "Blocks", "Coloured Symbols", "Black/White Symbols", "Blocks With Symbols"})
        Me.CbPaletteStitchDisplay.Location = New System.Drawing.Point(151, 51)
        Me.CbPaletteStitchDisplay.Name = "CbPaletteStitchDisplay"
        Me.CbPaletteStitchDisplay.Size = New System.Drawing.Size(121, 22)
        Me.CbPaletteStitchDisplay.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Location = New System.Drawing.Point(214, 95)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(58, 25)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOK.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnOK.Location = New System.Drawing.Point(76, 95)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(58, 25)
        Me.BtnOK.TabIndex = 5
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'FrmStitchDisplayStyle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 128)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.CbPaletteStitchDisplay)
        Me.Controls.Add(Me.CbDesignStitchDisplay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmStitchDisplayStyle"
        Me.Text = "Stitch Display Style"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CbDesignStitchDisplay As ComboBox
    Friend WithEvents CbPaletteStitchDisplay As ComboBox
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnOK As Button
End Class
