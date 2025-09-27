' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetUp))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtDataPath = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtAppPath = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtLogFilePath = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDesignFilePath = New System.Windows.Forms.TextBox()
        Me.TxtBackupPath = New System.Windows.Forms.TextBox()
        Me.TxtImagePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDataPath)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.TxtAppPath)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.TxtLogFilePath)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TxtDesignFilePath)
        Me.GroupBox1.Controls.Add(Me.TxtBackupPath)
        Me.GroupBox1.Controls.Add(Me.TxtImagePath)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 42)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(608, 249)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Paths"
        '
        'TxtDataPath
        '
        Me.TxtDataPath.Location = New System.Drawing.Point(200, 62)
        Me.TxtDataPath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDataPath.Name = "TxtDataPath"
        Me.TxtDataPath.Size = New System.Drawing.Size(388, 24)
        Me.TxtDataPath.TabIndex = 15
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 65)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(69, 17)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "Data Path"
        '
        'TxtAppPath
        '
        Me.TxtAppPath.Location = New System.Drawing.Point(200, 26)
        Me.TxtAppPath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAppPath.Name = "TxtAppPath"
        Me.TxtAppPath.Size = New System.Drawing.Size(388, 24)
        Me.TxtAppPath.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 30)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 17)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Application Path"
        '
        'TxtLogFilePath
        '
        Me.TxtLogFilePath.Location = New System.Drawing.Point(200, 204)
        Me.TxtLogFilePath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogFilePath.Name = "TxtLogFilePath"
        Me.TxtLogFilePath.Size = New System.Drawing.Size(388, 24)
        Me.TxtLogFilePath.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 208)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 17)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Log File Path"
        '
        'TxtDesignFilePath
        '
        Me.TxtDesignFilePath.Location = New System.Drawing.Point(200, 97)
        Me.TxtDesignFilePath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDesignFilePath.Name = "TxtDesignFilePath"
        Me.TxtDesignFilePath.Size = New System.Drawing.Size(388, 24)
        Me.TxtDesignFilePath.TabIndex = 1
        '
        'TxtBackupPath
        '
        Me.TxtBackupPath.Location = New System.Drawing.Point(200, 169)
        Me.TxtBackupPath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBackupPath.Name = "TxtBackupPath"
        Me.TxtBackupPath.Size = New System.Drawing.Size(388, 24)
        Me.TxtBackupPath.TabIndex = 3
        '
        'TxtImagePath
        '
        Me.TxtImagePath.Location = New System.Drawing.Point(200, 133)
        Me.TxtImagePath.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtImagePath.Name = "TxtImagePath"
        Me.TxtImagePath.Size = New System.Drawing.Size(388, 24)
        Me.TxtImagePath.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 137)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Image Path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 172)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Backup Path"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 101)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Design File Path"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSave.Location = New System.Drawing.Point(520, 303)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 48)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(303, 19)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Select or confirm application file locations"
        '
        'FrmSetUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 364)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmSetUp"
        Me.Text = "Set up"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtDataPath As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtAppPath As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TxtLogFilePath As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtDesignFilePath As TextBox
    Friend WithEvents TxtBackupPath As TextBox
    Friend WithEvents TxtImagePath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Label4 As Label
End Class
