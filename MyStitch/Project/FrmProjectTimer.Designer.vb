' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProjectTimer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProjectTimer))
        Me.LblElapsedTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.LblTotalElapsedTime = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblElapsedTime
        '
        Me.LblElapsedTime.AutoSize = True
        Me.LblElapsedTime.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblElapsedTime.Location = New System.Drawing.Point(28, 9)
        Me.LblElapsedTime.Name = "LblElapsedTime"
        Me.LblElapsedTime.Size = New System.Drawing.Size(75, 19)
        Me.LblElapsedTime.TabIndex = 9
        Me.LblElapsedTime.Text = "00:00:00"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'BtnStart
        '
        Me.BtnStart.BackgroundImage = Global.MyStitch.My.Resources.Resources.starttimer
        Me.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnStart.FlatAppearance.BorderSize = 0
        Me.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStart.Location = New System.Drawing.Point(12, 61)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(35, 35)
        Me.BtnStart.TabIndex = 10
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.BackgroundImage = Global.MyStitch.My.Resources.Resources.stoptimer
        Me.BtnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnStop.FlatAppearance.BorderSize = 0
        Me.BtnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStop.Location = New System.Drawing.Point(84, 61)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(35, 35)
        Me.BtnStop.TabIndex = 11
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.BtnCancel.FlatAppearance.BorderSize = 0
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(35, 102)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(60, 20)
        Me.BtnCancel.TabIndex = 12
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'LblTotalElapsedTime
        '
        Me.LblTotalElapsedTime.AutoSize = True
        Me.LblTotalElapsedTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalElapsedTime.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblTotalElapsedTime.Location = New System.Drawing.Point(32, 35)
        Me.LblTotalElapsedTime.Name = "LblTotalElapsedTime"
        Me.LblTotalElapsedTime.Size = New System.Drawing.Size(66, 17)
        Me.LblTotalElapsedTime.TabIndex = 13
        Me.LblTotalElapsedTime.Text = "00:00:00"
        '
        'FrmProjectTimer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(131, 129)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblTotalElapsedTime)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.LblElapsedTime)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmProjectTimer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Project Timer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblElapsedTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents LblTotalElapsedTime As Label
End Class
