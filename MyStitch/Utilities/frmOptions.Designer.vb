<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOptions))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TxtBackupPath = New System.Windows.Forms.TextBox()
        Me.TxtImagePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDesignFilePath = New System.Windows.Forms.TextBox()
        Me.Version = New System.Windows.Forms.Label()
        Me.BtnResetForms = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtLogFilePath = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnGlobalSettings = New System.Windows.Forms.Button()
        Me.BtnBackup = New System.Windows.Forms.Button()
        Me.BtnHousekeeping = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.NudRetention = New System.Windows.Forms.NumericUpDown()
        Me.ChkDebugOn = New System.Windows.Forms.CheckBox()
        Me.ChkGridOn = New System.Windows.Forms.CheckBox()
        Me.ChkBackupArchive = New System.Windows.Forms.CheckBox()
        Me.ChkBackupDb = New System.Windows.Forms.CheckBox()
        Me.ChkBackupRevision = New System.Windows.Forms.CheckBox()
        Me.ChkAppendDbBackup = New System.Windows.Forms.CheckBox()
        Me.ChkBackupAddDate = New System.Windows.Forms.CheckBox()
        Me.ChkLogZoom = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NudZoomValue = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkArchiveOnSave = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.NudCentreThick = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PicCentreColour = New System.Windows.Forms.PictureBox()
        Me.ChkCentreOn = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ChkTimerAutoSave = New System.Windows.Forms.CheckBox()
        Me.ChkTimerAutoStart = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ChkShowStock = New System.Windows.Forms.CheckBox()
        Me.BtnPrintSettings = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NudRetention, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudZoomValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NudCentreThick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCentreColour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnCancel.Location = New System.Drawing.Point(590, 537)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 41)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSave.Location = New System.Drawing.Point(381, 537)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 41)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'TxtBackupPath
        '
        Me.TxtBackupPath.Location = New System.Drawing.Point(172, 77)
        Me.TxtBackupPath.Name = "TxtBackupPath"
        Me.TxtBackupPath.Size = New System.Drawing.Size(333, 22)
        Me.TxtBackupPath.TabIndex = 2
        '
        'TxtImagePath
        '
        Me.TxtImagePath.Location = New System.Drawing.Point(172, 49)
        Me.TxtImagePath.Name = "TxtImagePath"
        Me.TxtImagePath.Size = New System.Drawing.Size(333, 22)
        Me.TxtImagePath.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Image Path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Backup Path"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Design File Path"
        '
        'TxtDesignFilePath
        '
        Me.TxtDesignFilePath.Location = New System.Drawing.Point(172, 21)
        Me.TxtDesignFilePath.Name = "TxtDesignFilePath"
        Me.TxtDesignFilePath.Size = New System.Drawing.Size(333, 22)
        Me.TxtDesignFilePath.TabIndex = 6
        '
        'Version
        '
        Me.Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Version.Location = New System.Drawing.Point(12, 559)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(214, 28)
        Me.Version.TabIndex = 8
        Me.Version.Text = "Version {0}.{1}.{2}.{3}"
        '
        'BtnResetForms
        '
        Me.BtnResetForms.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnResetForms.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResetForms.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnResetForms.Location = New System.Drawing.Point(18, 442)
        Me.BtnResetForms.Name = "BtnResetForms"
        Me.BtnResetForms.Size = New System.Drawing.Size(86, 60)
        Me.BtnResetForms.TabIndex = 9
        Me.BtnResetForms.Text = "Reset Form Positions"
        Me.BtnResetForms.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtLogFilePath)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TxtDesignFilePath)
        Me.GroupBox1.Controls.Add(Me.TxtBackupPath)
        Me.GroupBox1.Controls.Add(Me.TxtImagePath)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 144)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Paths"
        '
        'TxtLogFilePath
        '
        Me.TxtLogFilePath.Location = New System.Drawing.Point(172, 105)
        Me.TxtLogFilePath.Name = "TxtLogFilePath"
        Me.TxtLogFilePath.Size = New System.Drawing.Size(333, 22)
        Me.TxtLogFilePath.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 14)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Log File Path"
        '
        'BtnGlobalSettings
        '
        Me.BtnGlobalSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGlobalSettings.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGlobalSettings.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGlobalSettings.Location = New System.Drawing.Point(123, 442)
        Me.BtnGlobalSettings.Name = "BtnGlobalSettings"
        Me.BtnGlobalSettings.Size = New System.Drawing.Size(86, 60)
        Me.BtnGlobalSettings.TabIndex = 20
        Me.BtnGlobalSettings.Text = "Global Settings"
        Me.BtnGlobalSettings.UseVisualStyleBackColor = True
        '
        'BtnBackup
        '
        Me.BtnBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBackup.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBackup.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBackup.Location = New System.Drawing.Point(333, 442)
        Me.BtnBackup.Name = "BtnBackup"
        Me.BtnBackup.Size = New System.Drawing.Size(86, 60)
        Me.BtnBackup.TabIndex = 25
        Me.BtnBackup.Text = "Backup"
        Me.BtnBackup.UseVisualStyleBackColor = True
        '
        'BtnHousekeeping
        '
        Me.BtnHousekeeping.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnHousekeeping.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHousekeeping.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnHousekeeping.Location = New System.Drawing.Point(24, 80)
        Me.BtnHousekeeping.Name = "BtnHousekeeping"
        Me.BtnHousekeeping.Size = New System.Drawing.Size(86, 35)
        Me.BtnHousekeeping.TabIndex = 26
        Me.BtnHousekeeping.Text = "Run now"
        Me.BtnHousekeeping.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.NudRetention)
        Me.GroupBox4.Controls.Add(Me.BtnHousekeeping)
        Me.GroupBox4.Location = New System.Drawing.Point(548, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(133, 133)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Housekeeping"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 14)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Retention period"
        '
        'NudRetention
        '
        Me.NudRetention.Location = New System.Drawing.Point(40, 46)
        Me.NudRetention.Name = "NudRetention"
        Me.NudRetention.Size = New System.Drawing.Size(54, 22)
        Me.NudRetention.TabIndex = 27
        '
        'ChkDebugOn
        '
        Me.ChkDebugOn.AutoSize = True
        Me.ChkDebugOn.Location = New System.Drawing.Point(23, 45)
        Me.ChkDebugOn.Name = "ChkDebugOn"
        Me.ChkDebugOn.Size = New System.Drawing.Size(82, 18)
        Me.ChkDebugOn.TabIndex = 28
        Me.ChkDebugOn.Text = "Debug On"
        Me.ChkDebugOn.UseVisualStyleBackColor = True
        '
        'ChkGridOn
        '
        Me.ChkGridOn.AutoSize = True
        Me.ChkGridOn.Location = New System.Drawing.Point(16, 25)
        Me.ChkGridOn.Name = "ChkGridOn"
        Me.ChkGridOn.Size = New System.Drawing.Size(67, 18)
        Me.ChkGridOn.TabIndex = 29
        Me.ChkGridOn.Text = "Grid On"
        Me.ChkGridOn.UseVisualStyleBackColor = True
        '
        'ChkBackupArchive
        '
        Me.ChkBackupArchive.AutoSize = True
        Me.ChkBackupArchive.Location = New System.Drawing.Point(219, 21)
        Me.ChkBackupArchive.Name = "ChkBackupArchive"
        Me.ChkBackupArchive.Size = New System.Drawing.Size(109, 18)
        Me.ChkBackupArchive.TabIndex = 30
        Me.ChkBackupArchive.Text = "Backup Archive"
        Me.ChkBackupArchive.UseVisualStyleBackColor = True
        '
        'ChkBackupDb
        '
        Me.ChkBackupDb.AutoSize = True
        Me.ChkBackupDb.Location = New System.Drawing.Point(23, 21)
        Me.ChkBackupDb.Name = "ChkBackupDb"
        Me.ChkBackupDb.Size = New System.Drawing.Size(119, 18)
        Me.ChkBackupDb.TabIndex = 31
        Me.ChkBackupDb.Text = "Backup Database"
        Me.ChkBackupDb.UseVisualStyleBackColor = True
        '
        'ChkBackupRevision
        '
        Me.ChkBackupRevision.AutoSize = True
        Me.ChkBackupRevision.Location = New System.Drawing.Point(219, 45)
        Me.ChkBackupRevision.Name = "ChkBackupRevision"
        Me.ChkBackupRevision.Size = New System.Drawing.Size(112, 18)
        Me.ChkBackupRevision.TabIndex = 32
        Me.ChkBackupRevision.Text = "Backup Revision"
        Me.ChkBackupRevision.UseVisualStyleBackColor = True
        '
        'ChkAppendDbBackup
        '
        Me.ChkAppendDbBackup.AutoSize = True
        Me.ChkAppendDbBackup.Location = New System.Drawing.Point(23, 45)
        Me.ChkAppendDbBackup.Name = "ChkAppendDbBackup"
        Me.ChkAppendDbBackup.Size = New System.Drawing.Size(166, 18)
        Me.ChkAppendDbBackup.TabIndex = 33
        Me.ChkAppendDbBackup.Text = "Append Database Backup"
        Me.ChkAppendDbBackup.UseVisualStyleBackColor = True
        '
        'ChkBackupAddDate
        '
        Me.ChkBackupAddDate.AutoSize = True
        Me.ChkBackupAddDate.Location = New System.Drawing.Point(23, 69)
        Me.ChkBackupAddDate.Name = "ChkBackupAddDate"
        Me.ChkBackupAddDate.Size = New System.Drawing.Size(158, 18)
        Me.ChkBackupAddDate.TabIndex = 34
        Me.ChkBackupAddDate.Text = "Backup Add Date Folder"
        Me.ChkBackupAddDate.UseVisualStyleBackColor = True
        '
        'ChkLogZoom
        '
        Me.ChkLogZoom.AutoSize = True
        Me.ChkLogZoom.Location = New System.Drawing.Point(23, 21)
        Me.ChkLogZoom.Name = "ChkLogZoom"
        Me.ChkLogZoom.Size = New System.Drawing.Size(101, 18)
        Me.ChkLogZoom.TabIndex = 35
        Me.ChkLogZoom.Text = "Log Zoom On"
        Me.ChkLogZoom.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NudZoomValue)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ChkLogZoom)
        Me.GroupBox2.Controls.Add(Me.ChkDebugOn)
        Me.GroupBox2.Location = New System.Drawing.Point(279, 162)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logging"
        '
        'NudZoomValue
        '
        Me.NudZoomValue.DecimalPlaces = 2
        Me.NudZoomValue.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.NudZoomValue.Location = New System.Drawing.Point(96, 69)
        Me.NudZoomValue.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudZoomValue.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NudZoomValue.Name = "NudZoomValue"
        Me.NudZoomValue.Size = New System.Drawing.Size(58, 22)
        Me.NudZoomValue.TabIndex = 37
        Me.NudZoomValue.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Zoom value"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkArchiveOnSave)
        Me.GroupBox3.Controls.Add(Me.ChkBackupDb)
        Me.GroupBox3.Controls.Add(Me.ChkAppendDbBackup)
        Me.GroupBox3.Controls.Add(Me.ChkBackupArchive)
        Me.GroupBox3.Controls.Add(Me.ChkBackupAddDate)
        Me.GroupBox3.Controls.Add(Me.ChkBackupRevision)
        Me.GroupBox3.Location = New System.Drawing.Point(279, 268)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(399, 107)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Backup"
        '
        'ChkArchiveOnSave
        '
        Me.ChkArchiveOnSave.AutoSize = True
        Me.ChkArchiveOnSave.Location = New System.Drawing.Point(219, 69)
        Me.ChkArchiveOnSave.Name = "ChkArchiveOnSave"
        Me.ChkArchiveOnSave.Size = New System.Drawing.Size(145, 18)
        Me.ChkArchiveOnSave.TabIndex = 35
        Me.ChkArchiveOnSave.Text = "Auto Archive on Save"
        Me.ChkArchiveOnSave.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.NudCentreThick)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.PicCentreColour)
        Me.GroupBox5.Controls.Add(Me.ChkCentreOn)
        Me.GroupBox5.Controls.Add(Me.ChkGridOn)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 162)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(245, 160)
        Me.GroupBox5.TabIndex = 38
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Design"
        '
        'NudCentreThick
        '
        Me.NudCentreThick.Location = New System.Drawing.Point(143, 104)
        Me.NudCentreThick.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudCentreThick.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCentreThick.Name = "NudCentreThick"
        Me.NudCentreThick.Size = New System.Drawing.Size(36, 22)
        Me.NudCentreThick.TabIndex = 155
        Me.NudCentreThick.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 14)
        Me.Label5.TabIndex = 154
        Me.Label5.Text = "Centre line thickness"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 14)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Centre line colour"
        '
        'PicCentreColour
        '
        Me.PicCentreColour.BackColor = System.Drawing.Color.White
        Me.PicCentreColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicCentreColour.Location = New System.Drawing.Point(143, 73)
        Me.PicCentreColour.Name = "PicCentreColour"
        Me.PicCentreColour.Size = New System.Drawing.Size(23, 23)
        Me.PicCentreColour.TabIndex = 152
        Me.PicCentreColour.TabStop = False
        '
        'ChkCentreOn
        '
        Me.ChkCentreOn.AutoSize = True
        Me.ChkCentreOn.Location = New System.Drawing.Point(16, 49)
        Me.ChkCentreOn.Name = "ChkCentreOn"
        Me.ChkCentreOn.Size = New System.Drawing.Size(83, 18)
        Me.ChkCentreOn.TabIndex = 30
        Me.ChkCentreOn.Text = "Centre On"
        Me.ChkCentreOn.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ChkTimerAutoSave)
        Me.GroupBox6.Controls.Add(Me.ChkTimerAutoStart)
        Me.GroupBox6.Location = New System.Drawing.Point(16, 328)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox6.TabIndex = 39
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Project Timer"
        '
        'ChkTimerAutoSave
        '
        Me.ChkTimerAutoSave.AutoSize = True
        Me.ChkTimerAutoSave.Location = New System.Drawing.Point(16, 53)
        Me.ChkTimerAutoSave.Name = "ChkTimerAutoSave"
        Me.ChkTimerAutoSave.Size = New System.Drawing.Size(161, 18)
        Me.ChkTimerAutoSave.TabIndex = 31
        Me.ChkTimerAutoSave.Text = "Auto Save on form close"
        Me.ChkTimerAutoSave.UseVisualStyleBackColor = True
        '
        'ChkTimerAutoStart
        '
        Me.ChkTimerAutoStart.AutoSize = True
        Me.ChkTimerAutoStart.Location = New System.Drawing.Point(16, 29)
        Me.ChkTimerAutoStart.Name = "ChkTimerAutoStart"
        Me.ChkTimerAutoStart.Size = New System.Drawing.Size(163, 18)
        Me.ChkTimerAutoStart.TabIndex = 30
        Me.ChkTimerAutoStart.Text = "Auto Start on form open"
        Me.ChkTimerAutoStart.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ChkShowStock)
        Me.GroupBox7.Location = New System.Drawing.Point(485, 162)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(192, 100)
        Me.GroupBox7.TabIndex = 40
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Threads"
        '
        'ChkShowStock
        '
        Me.ChkShowStock.AutoSize = True
        Me.ChkShowStock.Location = New System.Drawing.Point(13, 27)
        Me.ChkShowStock.Name = "ChkShowStock"
        Me.ChkShowStock.Size = New System.Drawing.Size(129, 18)
        Me.ChkShowStock.TabIndex = 0
        Me.ChkShowStock.Text = "Show Stock Levels"
        Me.ChkShowStock.UseVisualStyleBackColor = True
        '
        'BtnPrintSettings
        '
        Me.BtnPrintSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPrintSettings.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintSettings.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPrintSettings.Location = New System.Drawing.Point(228, 442)
        Me.BtnPrintSettings.Name = "BtnPrintSettings"
        Me.BtnPrintSettings.Size = New System.Drawing.Size(86, 60)
        Me.BtnPrintSettings.TabIndex = 41
        Me.BtnPrintSettings.Text = "Print Settings"
        Me.BtnPrintSettings.UseVisualStyleBackColor = True
        '
        'FrmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(690, 590)
        Me.Controls.Add(Me.BtnPrintSettings)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.BtnBackup)
        Me.Controls.Add(Me.BtnGlobalSettings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnResetForms)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmOptions"
        Me.Text = "Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NudRetention, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudZoomValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NudCentreThick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCentreColour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents TxtBackupPath As System.Windows.Forms.TextBox
    Friend WithEvents TxtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtDesignFilePath As TextBox
    Friend WithEvents Version As Label
    Friend WithEvents BtnResetForms As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnGlobalSettings As Button
    Friend WithEvents TxtLogFilePath As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents BtnBackup As Button
    Friend WithEvents BtnHousekeeping As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents NudRetention As NumericUpDown
    Friend WithEvents ChkDebugOn As CheckBox
    Friend WithEvents ChkGridOn As CheckBox
    Friend WithEvents ChkBackupArchive As CheckBox
    Friend WithEvents ChkBackupDb As CheckBox
    Friend WithEvents ChkBackupRevision As CheckBox
    Friend WithEvents ChkAppendDbBackup As CheckBox
    Friend WithEvents ChkBackupAddDate As CheckBox
    Friend WithEvents ChkLogZoom As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ChkCentreOn As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PicCentreColour As PictureBox
    Friend WithEvents NudCentreThick As NumericUpDown
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents ChkTimerAutoStart As CheckBox
    Friend WithEvents ChkTimerAutoSave As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents ChkShowStock As CheckBox
    Friend WithEvents NudZoomValue As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents ChkArchiveOnSave As CheckBox
    Friend WithEvents BtnPrintSettings As Button
End Class
