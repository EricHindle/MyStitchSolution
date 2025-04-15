' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu
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
        Me.BtnThreads = New System.Windows.Forms.Button()
        Me.Version = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnPrintCards = New System.Windows.Forms.Button()
        Me.BtnProjects = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(55, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10)
        Me.Label1.Size = New System.Drawing.Size(231, 49)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Cross Stitch Projects"
        '
        'BtnThreads
        '
        Me.BtnThreads.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThreads.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnThreads.Location = New System.Drawing.Point(185, 127)
        Me.BtnThreads.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnThreads.Name = "BtnThreads"
        Me.BtnThreads.Size = New System.Drawing.Size(151, 49)
        Me.BtnThreads.TabIndex = 32
        Me.BtnThreads.Text = "Threads"
        Me.BtnThreads.UseVisualStyleBackColor = True
        '
        'Version
        '
        Me.Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Version.AutoSize = True
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Version.Location = New System.Drawing.Point(18, 315)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(156, 17)
        Me.Version.TabIndex = 31
        Me.Version.Text = "Version {0}.{1}.{2}.{3}"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(188, 260)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(151, 49)
        Me.BtnClose.TabIndex = 30
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnPrintCards
        '
        Me.BtnPrintCards.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintCards.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPrintCards.Location = New System.Drawing.Point(11, 195)
        Me.BtnPrintCards.Name = "BtnPrintCards"
        Me.BtnPrintCards.Size = New System.Drawing.Size(151, 49)
        Me.BtnPrintCards.TabIndex = 29
        Me.BtnPrintCards.Text = "Print Cards"
        Me.BtnPrintCards.UseVisualStyleBackColor = True
        '
        'BtnProjects
        '
        Me.BtnProjects.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProjects.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnProjects.Location = New System.Drawing.Point(11, 127)
        Me.BtnProjects.Name = "BtnProjects"
        Me.BtnProjects.Size = New System.Drawing.Size(151, 49)
        Me.BtnProjects.TabIndex = 28
        Me.BtnProjects.Text = "Projects"
        Me.BtnProjects.UseVisualStyleBackColor = True
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(352, 347)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnThreads)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnPrintCards)
        Me.Controls.Add(Me.BtnProjects)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BtnThreads As Button
    Friend WithEvents Version As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnPrintCards As Button
    Friend WithEvents BtnProjects As Button
End Class
