' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintOptions))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtCopyright = New System.Windows.Forms.TextBox()
        Me.TxtDesignBy = New System.Windows.Forms.TextBox()
        Me.ChkTitleAboveKey = New System.Windows.Forms.CheckBox()
        Me.ChkTitleAboveGrid = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.NudBackstitchLines = New System.Windows.Forms.NumericUpDown()
        Me.NudGrid10Lines = New System.Windows.Forms.NumericUpDown()
        Me.NudGrid1Lines = New System.Windows.Forms.NumericUpDown()
        Me.NudGrid5Lines = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.NudLeftMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudRightMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudBottomMargin = New System.Windows.Forms.NumericUpDown()
        Me.NudTopMargin = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CbAbbrKey = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NudOverlap = New System.Windows.Forms.NumericUpDown()
        Me.CbShading = New System.Windows.Forms.ComboBox()
        Me.ChkShowPageOrder = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbDesignStitchDisplay = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudBlankBorder = New System.Windows.Forms.NumericUpDown()
        Me.ChkBlankBorder = New System.Windows.Forms.CheckBox()
        Me.ChkCentreLines = New System.Windows.Forms.CheckBox()
        Me.ChkPrintGrid = New System.Windows.Forms.CheckBox()
        Me.ChkKeySeparate = New System.Windows.Forms.CheckBox()
        Me.CbKeyOrder = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkPrintKey = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudSqrPerInch = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NudBackstitchLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGrid10Lines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGrid1Lines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGrid5Lines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudBlankBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSave.Location = New System.Drawing.Point(416, 354)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 50)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnCancel.Location = New System.Drawing.Point(660, 352)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 50)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.TxtCopyright)
        Me.GroupBox5.Controls.Add(Me.TxtDesignBy)
        Me.GroupBox5.Controls.Add(Me.ChkTitleAboveKey)
        Me.GroupBox5.Controls.Add(Me.ChkTitleAboveGrid)
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(350, 21)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(210, 165)
        Me.GroupBox5.TabIndex = 163
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Design Information"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 105)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Copyright"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 81)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Design By"
        '
        'TxtCopyright
        '
        Me.TxtCopyright.Location = New System.Drawing.Point(86, 102)
        Me.TxtCopyright.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCopyright.Name = "TxtCopyright"
        Me.TxtCopyright.Size = New System.Drawing.Size(116, 20)
        Me.TxtCopyright.TabIndex = 5
        '
        'TxtDesignBy
        '
        Me.TxtDesignBy.Location = New System.Drawing.Point(86, 78)
        Me.TxtDesignBy.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDesignBy.Name = "TxtDesignBy"
        Me.TxtDesignBy.Size = New System.Drawing.Size(116, 20)
        Me.TxtDesignBy.TabIndex = 4
        '
        'ChkTitleAboveKey
        '
        Me.ChkTitleAboveKey.AutoSize = True
        Me.ChkTitleAboveKey.Location = New System.Drawing.Point(12, 53)
        Me.ChkTitleAboveKey.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkTitleAboveKey.Name = "ChkTitleAboveKey"
        Me.ChkTitleAboveKey.Size = New System.Drawing.Size(101, 17)
        Me.ChkTitleAboveKey.TabIndex = 3
        Me.ChkTitleAboveKey.Text = "Title Above Key"
        Me.ChkTitleAboveKey.UseVisualStyleBackColor = True
        '
        'ChkTitleAboveGrid
        '
        Me.ChkTitleAboveGrid.AutoSize = True
        Me.ChkTitleAboveGrid.Location = New System.Drawing.Point(12, 25)
        Me.ChkTitleAboveGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkTitleAboveGrid.Name = "ChkTitleAboveGrid"
        Me.ChkTitleAboveGrid.Size = New System.Drawing.Size(102, 17)
        Me.ChkTitleAboveGrid.TabIndex = 2
        Me.ChkTitleAboveGrid.Text = "Title Above Grid"
        Me.ChkTitleAboveGrid.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.NudBackstitchLines)
        Me.GroupBox4.Controls.Add(Me.NudGrid10Lines)
        Me.GroupBox4.Controls.Add(Me.NudGrid1Lines)
        Me.GroupBox4.Controls.Add(Me.NudGrid5Lines)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(350, 201)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(210, 140)
        Me.GroupBox4.TabIndex = 162
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Line Thickness"
        '
        'NudBackstitchLines
        '
        Me.NudBackstitchLines.Location = New System.Drawing.Point(138, 106)
        Me.NudBackstitchLines.Margin = New System.Windows.Forms.Padding(4)
        Me.NudBackstitchLines.Name = "NudBackstitchLines"
        Me.NudBackstitchLines.Size = New System.Drawing.Size(56, 20)
        Me.NudBackstitchLines.TabIndex = 158
        '
        'NudGrid10Lines
        '
        Me.NudGrid10Lines.Location = New System.Drawing.Point(138, 78)
        Me.NudGrid10Lines.Margin = New System.Windows.Forms.Padding(4)
        Me.NudGrid10Lines.Name = "NudGrid10Lines"
        Me.NudGrid10Lines.Size = New System.Drawing.Size(56, 20)
        Me.NudGrid10Lines.TabIndex = 157
        '
        'NudGrid1Lines
        '
        Me.NudGrid1Lines.Location = New System.Drawing.Point(138, 22)
        Me.NudGrid1Lines.Margin = New System.Windows.Forms.Padding(4)
        Me.NudGrid1Lines.Name = "NudGrid1Lines"
        Me.NudGrid1Lines.Size = New System.Drawing.Size(56, 20)
        Me.NudGrid1Lines.TabIndex = 156
        '
        'NudGrid5Lines
        '
        Me.NudGrid5Lines.Location = New System.Drawing.Point(138, 50)
        Me.NudGrid5Lines.Margin = New System.Windows.Forms.Padding(4)
        Me.NudGrid5Lines.Name = "NudGrid5Lines"
        Me.NudGrid5Lines.Size = New System.Drawing.Size(56, 20)
        Me.NudGrid5Lines.TabIndex = 155
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(26, 108)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 154
        Me.Label18.Text = "Backstitch lines"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(26, 80)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 153
        Me.Label15.Text = "Grid 10 lines"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(26, 52)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 152
        Me.Label16.Text = "Grid 5 lines"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(26, 24)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 13)
        Me.Label17.TabIndex = 151
        Me.Label17.Text = "Grid 1 lines"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.NudLeftMargin)
        Me.GroupBox3.Controls.Add(Me.NudRightMargin)
        Me.GroupBox3.Controls.Add(Me.NudBottomMargin)
        Me.GroupBox3.Controls.Add(Me.NudTopMargin)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(568, 201)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(194, 140)
        Me.GroupBox3.TabIndex = 161
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Margins"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(49, 109)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 153
        Me.Label14.Text = "Measurements in mm"
        '
        'NudLeftMargin
        '
        Me.NudLeftMargin.Location = New System.Drawing.Point(44, 34)
        Me.NudLeftMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudLeftMargin.Name = "NudLeftMargin"
        Me.NudLeftMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudLeftMargin.TabIndex = 152
        '
        'NudRightMargin
        '
        Me.NudRightMargin.Location = New System.Drawing.Point(44, 80)
        Me.NudRightMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudRightMargin.Name = "NudRightMargin"
        Me.NudRightMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudRightMargin.TabIndex = 151
        '
        'NudBottomMargin
        '
        Me.NudBottomMargin.Location = New System.Drawing.Point(117, 80)
        Me.NudBottomMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudBottomMargin.Name = "NudBottomMargin"
        Me.NudBottomMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudBottomMargin.TabIndex = 150
        '
        'NudTopMargin
        '
        Me.NudTopMargin.Location = New System.Drawing.Point(117, 34)
        Me.NudTopMargin.Margin = New System.Windows.Forms.Padding(4)
        Me.NudTopMargin.Name = "NudTopMargin"
        Me.NudTopMargin.Size = New System.Drawing.Size(56, 20)
        Me.NudTopMargin.TabIndex = 149
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(56, 63)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Right"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(125, 63)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Bottom"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(59, 17)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Left"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(133, 17)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Top"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CbAbbrKey)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.NudOverlap)
        Me.GroupBox2.Controls.Add(Me.CbShading)
        Me.GroupBox2.Controls.Add(Me.ChkShowPageOrder)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(568, 21)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(194, 165)
        Me.GroupBox2.TabIndex = 160
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tiling"
        '
        'CbAbbrKey
        '
        Me.CbAbbrKey.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbAbbrKey.FormattingEnabled = True
        Me.CbAbbrKey.Items.AddRange(New Object() {"<none>", "colour name", "DMC"})
        Me.CbAbbrKey.Location = New System.Drawing.Point(44, 119)
        Me.CbAbbrKey.Margin = New System.Windows.Forms.Padding(4)
        Me.CbAbbrKey.Name = "CbAbbrKey"
        Me.CbAbbrKey.Size = New System.Drawing.Size(92, 21)
        Me.CbAbbrKey.TabIndex = 150
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 102)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(167, 13)
        Me.Label9.TabIndex = 149
        Me.Label9.Text = "Abbreviated key on design pages"
        '
        'NudOverlap
        '
        Me.NudOverlap.Location = New System.Drawing.Point(114, 20)
        Me.NudOverlap.Margin = New System.Windows.Forms.Padding(4)
        Me.NudOverlap.Name = "NudOverlap"
        Me.NudOverlap.Size = New System.Drawing.Size(72, 20)
        Me.NudOverlap.TabIndex = 148
        '
        'CbShading
        '
        Me.CbShading.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbShading.FormattingEnabled = True
        Me.CbShading.Items.AddRange(New Object() {"Light Grey", "Mid Grey", "Dark Gray"})
        Me.CbShading.Location = New System.Drawing.Point(94, 48)
        Me.CbShading.Margin = New System.Windows.Forms.Padding(4)
        Me.CbShading.Name = "CbShading"
        Me.CbShading.Size = New System.Drawing.Size(92, 22)
        Me.CbShading.TabIndex = 147
        '
        'ChkShowPageOrder
        '
        Me.ChkShowPageOrder.AutoSize = True
        Me.ChkShowPageOrder.Location = New System.Drawing.Point(8, 78)
        Me.ChkShowPageOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkShowPageOrder.Name = "ChkShowPageOrder"
        Me.ChkShowPageOrder.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkShowPageOrder.Size = New System.Drawing.Size(110, 17)
        Me.ChkShowPageOrder.TabIndex = 2
        Me.ChkShowPageOrder.Text = "Show Page Order"
        Me.ChkShowPageOrder.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 52)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Shading"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 22)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Overlap"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NudSqrPerInch)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CbDesignStitchDisplay)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NudBlankBorder)
        Me.GroupBox1.Controls.Add(Me.ChkBlankBorder)
        Me.GroupBox1.Controls.Add(Me.ChkCentreLines)
        Me.GroupBox1.Controls.Add(Me.ChkPrintGrid)
        Me.GroupBox1.Controls.Add(Me.ChkKeySeparate)
        Me.GroupBox1.Controls.Add(Me.CbKeyOrder)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ChkPrintKey)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(327, 327)
        Me.GroupBox1.TabIndex = 164
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 260)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Printout Size"
        '
        'CbDesignStitchDisplay
        '
        Me.CbDesignStitchDisplay.FormattingEnabled = True
        Me.CbDesignStitchDisplay.Items.AddRange(New Object() {"Crosses", "Blocks", "Coloured Symbols", "Strokes", "Black/White Symbols", "Blocks With Symbols"})
        Me.CbDesignStitchDisplay.Location = New System.Drawing.Point(175, 213)
        Me.CbDesignStitchDisplay.Margin = New System.Windows.Forms.Padding(4)
        Me.CbDesignStitchDisplay.Name = "CbDesignStitchDisplay"
        Me.CbDesignStitchDisplay.Size = New System.Drawing.Size(140, 24)
        Me.CbDesignStitchDisplay.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 216)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Printout Stitch Display"
        '
        'NudBlankBorder
        '
        Me.NudBlankBorder.Location = New System.Drawing.Point(243, 164)
        Me.NudBlankBorder.Margin = New System.Windows.Forms.Padding(4)
        Me.NudBlankBorder.Name = "NudBlankBorder"
        Me.NudBlankBorder.Size = New System.Drawing.Size(72, 24)
        Me.NudBlankBorder.TabIndex = 8
        '
        'ChkBlankBorder
        '
        Me.ChkBlankBorder.AutoSize = True
        Me.ChkBlankBorder.Location = New System.Drawing.Point(9, 165)
        Me.ChkBlankBorder.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkBlankBorder.Name = "ChkBlankBorder"
        Me.ChkBlankBorder.Size = New System.Drawing.Size(198, 21)
        Me.ChkBlankBorder.TabIndex = 7
        Me.ChkBlankBorder.Text = "Blank Border Around Design"
        Me.ChkBlankBorder.UseVisualStyleBackColor = True
        '
        'ChkCentreLines
        '
        Me.ChkCentreLines.AutoSize = True
        Me.ChkCentreLines.Location = New System.Drawing.Point(9, 136)
        Me.ChkCentreLines.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCentreLines.Name = "ChkCentreLines"
        Me.ChkCentreLines.Size = New System.Drawing.Size(134, 21)
        Me.ChkCentreLines.TabIndex = 6
        Me.ChkCentreLines.Text = "Print Centre Lines"
        Me.ChkCentreLines.UseVisualStyleBackColor = True
        '
        'ChkPrintGrid
        '
        Me.ChkPrintGrid.AutoSize = True
        Me.ChkPrintGrid.Location = New System.Drawing.Point(11, 107)
        Me.ChkPrintGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPrintGrid.Name = "ChkPrintGrid"
        Me.ChkPrintGrid.Size = New System.Drawing.Size(83, 21)
        Me.ChkPrintGrid.TabIndex = 4
        Me.ChkPrintGrid.Text = "Print Grid"
        Me.ChkPrintGrid.UseVisualStyleBackColor = True
        '
        'ChkKeySeparate
        '
        Me.ChkKeySeparate.AutoSize = True
        Me.ChkKeySeparate.Location = New System.Drawing.Point(11, 77)
        Me.ChkKeySeparate.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkKeySeparate.Name = "ChkKeySeparate"
        Me.ChkKeySeparate.Size = New System.Drawing.Size(160, 21)
        Me.ChkKeySeparate.TabIndex = 3
        Me.ChkKeySeparate.Text = "Key on separate page"
        Me.ChkKeySeparate.UseVisualStyleBackColor = True
        '
        'CbKeyOrder
        '
        Me.CbKeyOrder.FormattingEnabled = True
        Me.CbKeyOrder.Items.AddRange(New Object() {"<none>", "colour name", "DMC"})
        Me.CbKeyOrder.Location = New System.Drawing.Point(106, 44)
        Me.CbKeyOrder.Margin = New System.Windows.Forms.Padding(5)
        Me.CbKeyOrder.Name = "CbKeyOrder"
        Me.CbKeyOrder.Size = New System.Drawing.Size(163, 24)
        Me.CbKeyOrder.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Key order"
        '
        'ChkPrintKey
        '
        Me.ChkPrintKey.AutoSize = True
        Me.ChkPrintKey.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPrintKey.Location = New System.Drawing.Point(11, 21)
        Me.ChkPrintKey.Margin = New System.Windows.Forms.Padding(5)
        Me.ChkPrintKey.Name = "ChkPrintKey"
        Me.ChkPrintKey.Size = New System.Drawing.Size(82, 21)
        Me.ChkPrintKey.TabIndex = 0
        Me.ChkPrintKey.Text = "Print Key"
        Me.ChkPrintKey.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(178, 260)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "squares per inch"
        '
        'NudSqrPerInch
        '
        Me.NudSqrPerInch.Location = New System.Drawing.Point(98, 258)
        Me.NudSqrPerInch.Margin = New System.Windows.Forms.Padding(4)
        Me.NudSqrPerInch.Name = "NudSqrPerInch"
        Me.NudSqrPerInch.Size = New System.Drawing.Size(72, 24)
        Me.NudSqrPerInch.TabIndex = 13
        '
        'FrmPrintOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(780, 417)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPrintOptions"
        Me.Text = "Print Options"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NudBackstitchLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGrid10Lines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGrid1Lines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGrid5Lines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NudLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudRightMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBottomMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudTopMargin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudOverlap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudBlankBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudSqrPerInch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtCopyright As TextBox
    Friend WithEvents TxtDesignBy As TextBox
    Friend WithEvents ChkTitleAboveKey As CheckBox
    Friend WithEvents ChkTitleAboveGrid As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents NudBackstitchLines As NumericUpDown
    Friend WithEvents NudGrid10Lines As NumericUpDown
    Friend WithEvents NudGrid1Lines As NumericUpDown
    Friend WithEvents NudGrid5Lines As NumericUpDown
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents NudLeftMargin As NumericUpDown
    Friend WithEvents NudRightMargin As NumericUpDown
    Friend WithEvents NudBottomMargin As NumericUpDown
    Friend WithEvents NudTopMargin As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CbAbbrKey As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents NudOverlap As NumericUpDown
    Friend WithEvents CbShading As ComboBox
    Friend WithEvents ChkShowPageOrder As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CbDesignStitchDisplay As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NudBlankBorder As NumericUpDown
    Friend WithEvents ChkBlankBorder As CheckBox
    Friend WithEvents ChkCentreLines As CheckBox
    Friend WithEvents ChkPrintGrid As CheckBox
    Friend WithEvents ChkKeySeparate As CheckBox
    Friend WithEvents CbKeyOrder As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ChkPrintKey As CheckBox
    Friend WithEvents NudSqrPerInch As NumericUpDown
    Friend WithEvents Label4 As Label
End Class
