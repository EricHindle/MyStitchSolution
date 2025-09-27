<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmStitchDesign
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStitchDesign))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ThreadLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnlPaletteName = New System.Windows.Forms.Panel()
        Me.BtnCancelPalette = New System.Windows.Forms.Button()
        Me.BtnSavePalette = New System.Windows.Forms.Button()
        Me.TxtPaletteName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicDesign = New System.Windows.Forms.PictureBox()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCopy = New System.Windows.Forms.ToolStripButton()
        Me.BtnCut = New System.Windows.Forms.ToolStripButton()
        Me.BtnPaste = New System.Windows.Forms.ToolStripButton()
        Me.BtnMove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnMirror = New System.Windows.Forms.ToolStripButton()
        Me.BtnFlip = New System.Windows.Forms.ToolStripButton()
        Me.BtnRotate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnUndo = New System.Windows.Forms.ToolStripButton()
        Me.BtnRedo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnFill = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnZoom = New System.Windows.Forms.ToolStripButton()
        Me.BtnShrink = New System.Windows.Forms.ToolStripButton()
        Me.BtnEnlarge = New System.Windows.Forms.ToolStripButton()
        Me.BtnWidth = New System.Windows.Forms.ToolStripButton()
        Me.BtnHeight = New System.Windows.Forms.ToolStripButton()
        Me.BtnCentre = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnTimer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSingleColour = New System.Windows.Forms.ToolStripButton()
        Me.BtnClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BtnFullStitch = New System.Windows.Forms.ToolStripButton()
        Me.Btn3QtrsTL = New System.Windows.Forms.ToolStripButton()
        Me.Btn3QtrsTR = New System.Windows.Forms.ToolStripButton()
        Me.Btn3QtrsBR = New System.Windows.Forms.ToolStripButton()
        Me.Btn3QtrsBL = New System.Windows.Forms.ToolStripButton()
        Me.BtnHalfForward = New System.Windows.Forms.ToolStripButton()
        Me.BtnHalfBack = New System.Windows.Forms.ToolStripButton()
        Me.BtnQtrTL = New System.Windows.Forms.ToolStripButton()
        Me.BtnQtrTR = New System.Windows.Forms.ToolStripButton()
        Me.BtnQtrBR = New System.Windows.Forms.ToolStripButton()
        Me.BtnQtrBL = New System.Windows.Forms.ToolStripButton()
        Me.BtnQuarters = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnFullBackstitchThin = New System.Windows.Forms.ToolStripButton()
        Me.BtnHalfBackStitchThin = New System.Windows.Forms.ToolStripButton()
        Me.BtnFullBackStitchThick = New System.Windows.Forms.ToolStripButton()
        Me.BtnHalfBackStitchThick = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnKnot = New System.Windows.Forms.ToolStripButton()
        Me.BtnBead = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PicCentreLines = New System.Windows.Forms.PictureBox()
        Me.LblPixelColourName = New System.Windows.Forms.Label()
        Me.PicGrid = New System.Windows.Forms.PictureBox()
        Me.PicStitch = New System.Windows.Forms.PictureBox()
        Me.PnlSelectedColor = New System.Windows.Forms.Panel()
        Me.LblCurrentColour = New System.Windows.Forms.Label()
        Me.LblCursorPos = New System.Windows.Forms.Label()
        Me.PnlPixelColour = New System.Windows.Forms.Panel()
        Me.LblSelectMessage = New System.Windows.Forms.Label()
        Me.LblSelection = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpenDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaveDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaveDesignAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPalette = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSelectColours = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRemoveUnused = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSavePalette = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuThreadSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuThreadCards = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPrintCards = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuThreads = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPickColour = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuChangeColour = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDeleteColour = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCopySelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMoveSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCutSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFlipSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMirrorSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDraw = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDrawShape = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEllipse = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRectangle = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDrawFilledShape = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFilledEllipse = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFilledRecangle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFloodFill = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClearArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRedraw = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuZoomIn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuZoomOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuZoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuGridOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCentreOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSingleColour = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuStitchDisplayStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuStitchTypes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBlockStitches = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBackStitches = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuKnots = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCropDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuExtendDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCentreMarks = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlPaletteName.SuspendLayout()
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PicCentreLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicStitch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ThreadLayoutPanel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(851, 470)
        Me.SplitContainer1.SplitterDistance = 128
        Me.SplitContainer1.TabIndex = 137
        '
        'ThreadLayoutPanel
        '
        Me.ThreadLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ThreadLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThreadLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.ThreadLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.ThreadLayoutPanel.Name = "ThreadLayoutPanel"
        Me.ThreadLayoutPanel.Size = New System.Drawing.Size(124, 466)
        Me.ThreadLayoutPanel.TabIndex = 131
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PnlPaletteName)
        Me.Panel1.Controls.Add(Me.PicDesign)
        Me.Panel1.Controls.Add(Me.HScrollBar1)
        Me.Panel1.Controls.Add(Me.VScrollBar1)
        Me.Panel1.Location = New System.Drawing.Point(6, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(706, 400)
        Me.Panel1.TabIndex = 137
        '
        'PnlPaletteName
        '
        Me.PnlPaletteName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPaletteName.Controls.Add(Me.BtnCancelPalette)
        Me.PnlPaletteName.Controls.Add(Me.BtnSavePalette)
        Me.PnlPaletteName.Controls.Add(Me.TxtPaletteName)
        Me.PnlPaletteName.Controls.Add(Me.Label1)
        Me.PnlPaletteName.Location = New System.Drawing.Point(103, 103)
        Me.PnlPaletteName.Name = "PnlPaletteName"
        Me.PnlPaletteName.Size = New System.Drawing.Size(200, 76)
        Me.PnlPaletteName.TabIndex = 136
        Me.PnlPaletteName.Visible = False
        '
        'BtnCancelPalette
        '
        Me.BtnCancelPalette.BackColor = System.Drawing.Color.MistyRose
        Me.BtnCancelPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelPalette.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelPalette.Location = New System.Drawing.Point(6, 45)
        Me.BtnCancelPalette.Name = "BtnCancelPalette"
        Me.BtnCancelPalette.Size = New System.Drawing.Size(60, 23)
        Me.BtnCancelPalette.TabIndex = 3
        Me.BtnCancelPalette.Text = "Cancel"
        Me.BtnCancelPalette.UseVisualStyleBackColor = False
        '
        'BtnSavePalette
        '
        Me.BtnSavePalette.BackColor = System.Drawing.Color.Honeydew
        Me.BtnSavePalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSavePalette.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSavePalette.Location = New System.Drawing.Point(135, 45)
        Me.BtnSavePalette.Name = "BtnSavePalette"
        Me.BtnSavePalette.Size = New System.Drawing.Size(60, 23)
        Me.BtnSavePalette.TabIndex = 2
        Me.BtnSavePalette.Text = "Save"
        Me.BtnSavePalette.UseVisualStyleBackColor = False
        '
        'TxtPaletteName
        '
        Me.TxtPaletteName.Location = New System.Drawing.Point(6, 17)
        Me.TxtPaletteName.Name = "TxtPaletteName"
        Me.TxtPaletteName.Size = New System.Drawing.Size(189, 22)
        Me.TxtPaletteName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Palette Name"
        '
        'PicDesign
        '
        Me.PicDesign.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicDesign.BackColor = System.Drawing.Color.White
        Me.PicDesign.Location = New System.Drawing.Point(3, 3)
        Me.PicDesign.Name = "PicDesign"
        Me.PicDesign.Size = New System.Drawing.Size(672, 367)
        Me.PicDesign.TabIndex = 133
        Me.PicDesign.TabStop = False
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.Location = New System.Drawing.Point(3, 376)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(672, 20)
        Me.HScrollBar1.TabIndex = 135
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.Location = New System.Drawing.Point(678, 3)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(20, 367)
        Me.VScrollBar1.TabIndex = 134
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSave, Me.BtnPrint, Me.ToolStripSeparator1, Me.BtnCopy, Me.BtnCut, Me.BtnPaste, Me.BtnMove, Me.ToolStripSeparator4, Me.BtnMirror, Me.BtnFlip, Me.BtnRotate, Me.ToolStripSeparator3, Me.BtnUndo, Me.BtnRedo, Me.ToolStripSeparator7, Me.BtnFill, Me.ToolStripSeparator5, Me.BtnZoom, Me.BtnShrink, Me.BtnEnlarge, Me.BtnWidth, Me.BtnHeight, Me.BtnCentre, Me.ToolStripSeparator14, Me.BtnTimer, Me.ToolStripSeparator15, Me.BtnSingleColour, Me.BtnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(6, 5)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(2, 1, 1, 1)
        Me.ToolStrip1.Size = New System.Drawing.Size(700, 26)
        Me.ToolStrip1.TabIndex = 135
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnSave
        '
        Me.BtnSave.AutoSize = False
        Me.BtnSave.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnSave.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSave.Image = Global.MyStitch.My.Resources.Resources.save
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(23, 24)
        Me.BtnSave.Text = "ToolStripButton1"
        Me.BtnSave.ToolTipText = "Save Design"
        '
        'BtnPrint
        '
        Me.BtnPrint.AutoSize = False
        Me.BtnPrint.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnPrint.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrint.Image = Global.MyStitch.My.Resources.Resources.print
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(23, 24)
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.ToolTipText = "Save Design"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'BtnCopy
        '
        Me.BtnCopy.AutoSize = False
        Me.BtnCopy.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnCopy.BackgroundImage = CType(resources.GetObject("BtnCopy.BackgroundImage"), System.Drawing.Image)
        Me.BtnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCopy.Image = Global.MyStitch.My.Resources.Resources.copy
        Me.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCopy.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(23, 24)
        Me.BtnCopy.Text = "ToolStripButton3"
        Me.BtnCopy.ToolTipText = "Copy Selection"
        '
        'BtnCut
        '
        Me.BtnCut.AutoSize = False
        Me.BtnCut.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnCut.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCut.Image = Global.MyStitch.My.Resources.Resources.cut
        Me.BtnCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCut.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnCut.Name = "BtnCut"
        Me.BtnCut.Size = New System.Drawing.Size(23, 24)
        Me.BtnCut.Text = "ToolStripButton2"
        Me.BtnCut.ToolTipText = "Cut Selection"
        '
        'BtnPaste
        '
        Me.BtnPaste.AutoSize = False
        Me.BtnPaste.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnPaste.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPaste.Image = Global.MyStitch.My.Resources.Resources.paste2
        Me.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPaste.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(23, 24)
        Me.BtnPaste.Text = "ToolStripButton1"
        Me.BtnPaste.ToolTipText = "Paste Selection"
        '
        'BtnMove
        '
        Me.BtnMove.AutoSize = False
        Me.BtnMove.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnMove.BackgroundImage = CType(resources.GetObject("BtnMove.BackgroundImage"), System.Drawing.Image)
        Me.BtnMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnMove.Image = Global.MyStitch.My.Resources.Resources.move
        Me.BtnMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnMove.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnMove.Name = "BtnMove"
        Me.BtnMove.Size = New System.Drawing.Size(23, 24)
        Me.BtnMove.Text = "ToolStripButton1"
        Me.BtnMove.ToolTipText = "Move Selection"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 24)
        '
        'BtnMirror
        '
        Me.BtnMirror.AutoSize = False
        Me.BtnMirror.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnMirror.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMirror.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnMirror.Image = Global.MyStitch.My.Resources.Resources.mirror
        Me.BtnMirror.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnMirror.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnMirror.Name = "BtnMirror"
        Me.BtnMirror.Size = New System.Drawing.Size(23, 24)
        Me.BtnMirror.Text = "ToolStripButton1"
        '
        'BtnFlip
        '
        Me.BtnFlip.AutoSize = False
        Me.BtnFlip.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnFlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnFlip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFlip.Image = Global.MyStitch.My.Resources.Resources.flip
        Me.BtnFlip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFlip.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnFlip.Name = "BtnFlip"
        Me.BtnFlip.Size = New System.Drawing.Size(23, 24)
        Me.BtnFlip.Text = "ToolStripButton2"
        '
        'BtnRotate
        '
        Me.BtnRotate.AutoSize = False
        Me.BtnRotate.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRotate.Image = Global.MyStitch.My.Resources.Resources.rotate
        Me.BtnRotate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRotate.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnRotate.Name = "BtnRotate"
        Me.BtnRotate.Size = New System.Drawing.Size(23, 24)
        Me.BtnRotate.Text = "ToolStripButton2"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 24)
        '
        'BtnUndo
        '
        Me.BtnUndo.AutoSize = False
        Me.BtnUndo.BackgroundImage = CType(resources.GetObject("BtnUndo.BackgroundImage"), System.Drawing.Image)
        Me.BtnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnUndo.Image = Global.MyStitch.My.Resources.Resources.undo
        Me.BtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnUndo.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.Size = New System.Drawing.Size(23, 24)
        Me.BtnUndo.Text = "ToolStripButton1"
        Me.BtnUndo.ToolTipText = "Undo change"
        '
        'BtnRedo
        '
        Me.BtnRedo.AutoSize = False
        Me.BtnRedo.BackgroundImage = CType(resources.GetObject("BtnRedo.BackgroundImage"), System.Drawing.Image)
        Me.BtnRedo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRedo.Image = Global.MyStitch.My.Resources.Resources.redo
        Me.BtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRedo.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnRedo.Name = "BtnRedo"
        Me.BtnRedo.Size = New System.Drawing.Size(23, 24)
        Me.BtnRedo.Text = "BtnRedo"
        Me.BtnRedo.ToolTipText = "Redo Change"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.BackColor = System.Drawing.Color.AliceBlue
        Me.ToolStripSeparator7.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 24)
        '
        'BtnFill
        '
        Me.BtnFill.AutoSize = False
        Me.BtnFill.BackgroundImage = CType(resources.GetObject("BtnFill.BackgroundImage"), System.Drawing.Image)
        Me.BtnFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFill.Image = Global.MyStitch.My.Resources.Resources.flood
        Me.BtnFill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFill.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(23, 24)
        Me.BtnFill.Text = "ToolStripButton1"
        Me.BtnFill.ToolTipText = "Fill"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.BackColor = System.Drawing.Color.AliceBlue
        Me.ToolStripSeparator5.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 24)
        '
        'BtnZoom
        '
        Me.BtnZoom.AutoSize = False
        Me.BtnZoom.BackgroundImage = CType(resources.GetObject("BtnZoom.BackgroundImage"), System.Drawing.Image)
        Me.BtnZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnZoom.Image = Global.MyStitch.My.Resources.Resources.zoom
        Me.BtnZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnZoom.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnZoom.Name = "BtnZoom"
        Me.BtnZoom.Size = New System.Drawing.Size(23, 24)
        Me.BtnZoom.Text = "ToolStripButton1"
        '
        'BtnShrink
        '
        Me.BtnShrink.AutoSize = False
        Me.BtnShrink.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnShrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnShrink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnShrink.Image = Global.MyStitch.My.Resources.Resources.shrink
        Me.BtnShrink.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnShrink.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnShrink.Name = "BtnShrink"
        Me.BtnShrink.Size = New System.Drawing.Size(23, 24)
        Me.BtnShrink.Text = "ToolStripButton1"
        Me.BtnShrink.ToolTipText = "Shrink Image"
        '
        'BtnEnlarge
        '
        Me.BtnEnlarge.AutoSize = False
        Me.BtnEnlarge.BackgroundImage = CType(resources.GetObject("BtnEnlarge.BackgroundImage"), System.Drawing.Image)
        Me.BtnEnlarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnEnlarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEnlarge.Image = Global.MyStitch.My.Resources.Resources.enlarge
        Me.BtnEnlarge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEnlarge.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnEnlarge.Name = "BtnEnlarge"
        Me.BtnEnlarge.Size = New System.Drawing.Size(23, 24)
        Me.BtnEnlarge.Text = "ToolStripButton1"
        Me.BtnEnlarge.ToolTipText = "Enlarge Image"
        '
        'BtnWidth
        '
        Me.BtnWidth.AutoSize = False
        Me.BtnWidth.BackgroundImage = CType(resources.GetObject("BtnWidth.BackgroundImage"), System.Drawing.Image)
        Me.BtnWidth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnWidth.Image = Global.MyStitch.My.Resources.Resources.width
        Me.BtnWidth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnWidth.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnWidth.Name = "BtnWidth"
        Me.BtnWidth.Size = New System.Drawing.Size(23, 24)
        Me.BtnWidth.Text = "ToolStripButton1"
        Me.BtnWidth.ToolTipText = "Fit Image to Width"
        '
        'BtnHeight
        '
        Me.BtnHeight.AutoSize = False
        Me.BtnHeight.BackgroundImage = CType(resources.GetObject("BtnHeight.BackgroundImage"), System.Drawing.Image)
        Me.BtnHeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnHeight.Image = Global.MyStitch.My.Resources.Resources.height
        Me.BtnHeight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHeight.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnHeight.Name = "BtnHeight"
        Me.BtnHeight.Size = New System.Drawing.Size(23, 24)
        Me.BtnHeight.Text = "ToolStripButton1"
        Me.BtnHeight.ToolTipText = "Fit Image To Height"
        '
        'BtnCentre
        '
        Me.BtnCentre.AutoSize = False
        Me.BtnCentre.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnCentre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnCentre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCentre.Image = Global.MyStitch.My.Resources.Resources.centre
        Me.BtnCentre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCentre.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnCentre.Name = "BtnCentre"
        Me.BtnCentre.Size = New System.Drawing.Size(23, 24)
        Me.BtnCentre.Text = "ToolStripButton1"
        Me.BtnCentre.ToolTipText = "Cente Image"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 24)
        '
        'BtnTimer
        '
        Me.BtnTimer.AutoSize = False
        Me.BtnTimer.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnTimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnTimer.Image = Global.MyStitch.My.Resources.Resources.timer
        Me.BtnTimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnTimer.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnTimer.Name = "BtnTimer"
        Me.BtnTimer.Size = New System.Drawing.Size(23, 24)
        Me.BtnTimer.Text = "ToolStripButton1"
        Me.BtnTimer.ToolTipText = "Start Project Timer"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 24)
        '
        'BtnSingleColour
        '
        Me.BtnSingleColour.AutoSize = False
        Me.BtnSingleColour.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnSingleColour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnSingleColour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSingleColour.Image = Global.MyStitch.My.Resources.Resources.singlecolour
        Me.BtnSingleColour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSingleColour.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnSingleColour.Name = "BtnSingleColour"
        Me.BtnSingleColour.Size = New System.Drawing.Size(23, 24)
        Me.BtnSingleColour.ToolTipText = "Display Single Colour"
        '
        'BtnClose
        '
        Me.BtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.BackgroundImage = CType(resources.GetObject("BtnClose.BackgroundImage"), System.Drawing.Image)
        Me.BtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(46, 24)
        Me.BtnClose.Text = "Close"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.Color.AliceBlue
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnFullStitch, Me.Btn3QtrsTL, Me.Btn3QtrsTR, Me.Btn3QtrsBR, Me.Btn3QtrsBL, Me.BtnHalfForward, Me.BtnHalfBack, Me.BtnQtrTL, Me.BtnQtrTR, Me.BtnQtrBR, Me.BtnQtrBL, Me.BtnQuarters, Me.ToolStripSeparator2, Me.BtnFullBackstitchThin, Me.BtnHalfBackStitchThin, Me.BtnFullBackStitchThick, Me.BtnHalfBackStitchThick, Me.ToolStripSeparator6, Me.BtnKnot, Me.BtnBead})
        Me.ToolStrip2.Location = New System.Drawing.Point(6, 31)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(2, 1, 1, 1)
        Me.ToolStrip2.Size = New System.Drawing.Size(700, 26)
        Me.ToolStrip2.TabIndex = 136
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'BtnFullStitch
        '
        Me.BtnFullStitch.AutoSize = False
        Me.BtnFullStitch.BackgroundImage = CType(resources.GetObject("BtnFullStitch.BackgroundImage"), System.Drawing.Image)
        Me.BtnFullStitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnFullStitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFullStitch.Image = Global.MyStitch.My.Resources.Resources.fullcross
        Me.BtnFullStitch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFullStitch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFullStitch.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnFullStitch.Name = "BtnFullStitch"
        Me.BtnFullStitch.Size = New System.Drawing.Size(23, 22)
        Me.BtnFullStitch.Text = "ToolStripButton1"
        Me.BtnFullStitch.ToolTipText = "Full Stitch"
        '
        'Btn3QtrsTL
        '
        Me.Btn3QtrsTL.AutoSize = False
        Me.Btn3QtrsTL.BackgroundImage = CType(resources.GetObject("Btn3QtrsTL.BackgroundImage"), System.Drawing.Image)
        Me.Btn3QtrsTL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn3QtrsTL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btn3QtrsTL.Image = Global.MyStitch.My.Resources.Resources._3qtrstl
        Me.Btn3QtrsTL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn3QtrsTL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn3QtrsTL.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.Btn3QtrsTL.Name = "Btn3QtrsTL"
        Me.Btn3QtrsTL.Size = New System.Drawing.Size(23, 22)
        Me.Btn3QtrsTL.Text = "ToolStripButton2"
        Me.Btn3QtrsTL.ToolTipText = "Three-quarter Top Left"
        '
        'Btn3QtrsTR
        '
        Me.Btn3QtrsTR.AutoSize = False
        Me.Btn3QtrsTR.BackgroundImage = CType(resources.GetObject("Btn3QtrsTR.BackgroundImage"), System.Drawing.Image)
        Me.Btn3QtrsTR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn3QtrsTR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btn3QtrsTR.Image = Global.MyStitch.My.Resources.Resources._3qtrstr
        Me.Btn3QtrsTR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn3QtrsTR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn3QtrsTR.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.Btn3QtrsTR.Name = "Btn3QtrsTR"
        Me.Btn3QtrsTR.Size = New System.Drawing.Size(23, 22)
        Me.Btn3QtrsTR.Text = "ToolStripButton3"
        Me.Btn3QtrsTR.ToolTipText = "Three-quarter Top Right"
        '
        'Btn3QtrsBR
        '
        Me.Btn3QtrsBR.AutoSize = False
        Me.Btn3QtrsBR.BackgroundImage = CType(resources.GetObject("Btn3QtrsBR.BackgroundImage"), System.Drawing.Image)
        Me.Btn3QtrsBR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn3QtrsBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btn3QtrsBR.Image = Global.MyStitch.My.Resources.Resources._3qtrsbr
        Me.Btn3QtrsBR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn3QtrsBR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn3QtrsBR.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.Btn3QtrsBR.Name = "Btn3QtrsBR"
        Me.Btn3QtrsBR.Size = New System.Drawing.Size(23, 22)
        Me.Btn3QtrsBR.Text = "ToolStripButton1"
        Me.Btn3QtrsBR.ToolTipText = "Three-quarter Bottom Right"
        '
        'Btn3QtrsBL
        '
        Me.Btn3QtrsBL.AutoSize = False
        Me.Btn3QtrsBL.BackgroundImage = CType(resources.GetObject("Btn3QtrsBL.BackgroundImage"), System.Drawing.Image)
        Me.Btn3QtrsBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn3QtrsBL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btn3QtrsBL.Image = Global.MyStitch.My.Resources.Resources._3qtrsbl
        Me.Btn3QtrsBL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn3QtrsBL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn3QtrsBL.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.Btn3QtrsBL.Name = "Btn3QtrsBL"
        Me.Btn3QtrsBL.Size = New System.Drawing.Size(23, 22)
        Me.Btn3QtrsBL.Text = "ToolStripButton1"
        Me.Btn3QtrsBL.ToolTipText = "Three-quarter Bottom Left"
        '
        'BtnHalfForward
        '
        Me.BtnHalfForward.AutoSize = False
        Me.BtnHalfForward.BackgroundImage = CType(resources.GetObject("BtnHalfForward.BackgroundImage"), System.Drawing.Image)
        Me.BtnHalfForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnHalfForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnHalfForward.Image = Global.MyStitch.My.Resources.Resources.halffwd
        Me.BtnHalfForward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnHalfForward.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHalfForward.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnHalfForward.Name = "BtnHalfForward"
        Me.BtnHalfForward.Size = New System.Drawing.Size(23, 22)
        Me.BtnHalfForward.Text = "ToolStripButton1"
        Me.BtnHalfForward.ToolTipText = "Half Forward"
        '
        'BtnHalfBack
        '
        Me.BtnHalfBack.AutoSize = False
        Me.BtnHalfBack.BackgroundImage = CType(resources.GetObject("BtnHalfBack.BackgroundImage"), System.Drawing.Image)
        Me.BtnHalfBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnHalfBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnHalfBack.Image = Global.MyStitch.My.Resources.Resources.halfback
        Me.BtnHalfBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnHalfBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHalfBack.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnHalfBack.Name = "BtnHalfBack"
        Me.BtnHalfBack.Size = New System.Drawing.Size(23, 22)
        Me.BtnHalfBack.Text = "ToolStripButton1"
        Me.BtnHalfBack.ToolTipText = "Half Back"
        '
        'BtnQtrTL
        '
        Me.BtnQtrTL.AutoSize = False
        Me.BtnQtrTL.BackgroundImage = CType(resources.GetObject("BtnQtrTL.BackgroundImage"), System.Drawing.Image)
        Me.BtnQtrTL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnQtrTL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnQtrTL.Image = Global.MyStitch.My.Resources.Resources.qtrtl
        Me.BtnQtrTL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnQtrTL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnQtrTL.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnQtrTL.Name = "BtnQtrTL"
        Me.BtnQtrTL.Size = New System.Drawing.Size(23, 22)
        Me.BtnQtrTL.Text = "ToolStripButton1"
        Me.BtnQtrTL.ToolTipText = "Quarter Top Left"
        '
        'BtnQtrTR
        '
        Me.BtnQtrTR.AutoSize = False
        Me.BtnQtrTR.BackgroundImage = CType(resources.GetObject("BtnQtrTR.BackgroundImage"), System.Drawing.Image)
        Me.BtnQtrTR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnQtrTR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnQtrTR.Image = Global.MyStitch.My.Resources.Resources.qtrtr
        Me.BtnQtrTR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnQtrTR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnQtrTR.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnQtrTR.Name = "BtnQtrTR"
        Me.BtnQtrTR.Size = New System.Drawing.Size(23, 22)
        Me.BtnQtrTR.Text = "ToolStripButton1"
        Me.BtnQtrTR.ToolTipText = "Quarter Top Right"
        '
        'BtnQtrBR
        '
        Me.BtnQtrBR.AutoSize = False
        Me.BtnQtrBR.BackgroundImage = CType(resources.GetObject("BtnQtrBR.BackgroundImage"), System.Drawing.Image)
        Me.BtnQtrBR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnQtrBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnQtrBR.Image = Global.MyStitch.My.Resources.Resources.qtrbr
        Me.BtnQtrBR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnQtrBR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnQtrBR.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnQtrBR.Name = "BtnQtrBR"
        Me.BtnQtrBR.Size = New System.Drawing.Size(23, 22)
        Me.BtnQtrBR.Text = "ToolStripButton1"
        Me.BtnQtrBR.ToolTipText = "Quarter Bottom Right"
        '
        'BtnQtrBL
        '
        Me.BtnQtrBL.AutoSize = False
        Me.BtnQtrBL.BackgroundImage = CType(resources.GetObject("BtnQtrBL.BackgroundImage"), System.Drawing.Image)
        Me.BtnQtrBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnQtrBL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnQtrBL.Image = Global.MyStitch.My.Resources.Resources.qtrbl
        Me.BtnQtrBL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnQtrBL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnQtrBL.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnQtrBL.Name = "BtnQtrBL"
        Me.BtnQtrBL.Size = New System.Drawing.Size(23, 22)
        Me.BtnQtrBL.Text = "ToolStripButton1"
        Me.BtnQtrBL.ToolTipText = "Quarter Bottom Left"
        '
        'BtnQuarters
        '
        Me.BtnQuarters.AutoSize = False
        Me.BtnQuarters.BackgroundImage = CType(resources.GetObject("BtnQuarters.BackgroundImage"), System.Drawing.Image)
        Me.BtnQuarters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnQuarters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnQuarters.Image = Global.MyStitch.My.Resources.Resources.quarters
        Me.BtnQuarters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnQuarters.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnQuarters.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnQuarters.Name = "BtnQuarters"
        Me.BtnQuarters.Size = New System.Drawing.Size(23, 22)
        Me.BtnQuarters.Text = "ToolStripButton1"
        Me.BtnQuarters.ToolTipText = "Quarters"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'BtnFullBackstitchThin
        '
        Me.BtnFullBackstitchThin.AutoSize = False
        Me.BtnFullBackstitchThin.BackgroundImage = CType(resources.GetObject("BtnFullBackstitchThin.BackgroundImage"), System.Drawing.Image)
        Me.BtnFullBackstitchThin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnFullBackstitchThin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFullBackstitchThin.Image = Global.MyStitch.My.Resources.Resources.fullthinbs
        Me.BtnFullBackstitchThin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFullBackstitchThin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFullBackstitchThin.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnFullBackstitchThin.Name = "BtnFullBackstitchThin"
        Me.BtnFullBackstitchThin.Size = New System.Drawing.Size(23, 22)
        Me.BtnFullBackstitchThin.Text = "ToolStripButton1"
        Me.BtnFullBackstitchThin.ToolTipText = "Thin Full Backstitch"
        '
        'BtnHalfBackStitchThin
        '
        Me.BtnHalfBackStitchThin.AutoSize = False
        Me.BtnHalfBackStitchThin.BackgroundImage = CType(resources.GetObject("BtnHalfBackStitchThin.BackgroundImage"), System.Drawing.Image)
        Me.BtnHalfBackStitchThin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnHalfBackStitchThin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnHalfBackStitchThin.Image = Global.MyStitch.My.Resources.Resources.halfthinbs
        Me.BtnHalfBackStitchThin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnHalfBackStitchThin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHalfBackStitchThin.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnHalfBackStitchThin.Name = "BtnHalfBackStitchThin"
        Me.BtnHalfBackStitchThin.Size = New System.Drawing.Size(23, 22)
        Me.BtnHalfBackStitchThin.Text = "ToolStripButton1"
        Me.BtnHalfBackStitchThin.ToolTipText = "Thin Half Backstitch"
        '
        'BtnFullBackStitchThick
        '
        Me.BtnFullBackStitchThick.AutoSize = False
        Me.BtnFullBackStitchThick.BackgroundImage = CType(resources.GetObject("BtnFullBackStitchThick.BackgroundImage"), System.Drawing.Image)
        Me.BtnFullBackStitchThick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnFullBackStitchThick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFullBackStitchThick.Image = Global.MyStitch.My.Resources.Resources.fullthickbs
        Me.BtnFullBackStitchThick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFullBackStitchThick.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFullBackStitchThick.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnFullBackStitchThick.Name = "BtnFullBackStitchThick"
        Me.BtnFullBackStitchThick.Size = New System.Drawing.Size(23, 22)
        Me.BtnFullBackStitchThick.Text = "ToolStripButton1"
        Me.BtnFullBackStitchThick.ToolTipText = "Thick Full Backstitch"
        '
        'BtnHalfBackStitchThick
        '
        Me.BtnHalfBackStitchThick.AutoSize = False
        Me.BtnHalfBackStitchThick.BackgroundImage = CType(resources.GetObject("BtnHalfBackStitchThick.BackgroundImage"), System.Drawing.Image)
        Me.BtnHalfBackStitchThick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnHalfBackStitchThick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnHalfBackStitchThick.Image = Global.MyStitch.My.Resources.Resources.halfthickbs
        Me.BtnHalfBackStitchThick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnHalfBackStitchThick.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHalfBackStitchThick.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnHalfBackStitchThick.Name = "BtnHalfBackStitchThick"
        Me.BtnHalfBackStitchThick.Size = New System.Drawing.Size(23, 22)
        Me.BtnHalfBackStitchThick.Text = "ToolStripButton1"
        Me.BtnHalfBackStitchThick.ToolTipText = "Thick Half Backstitch"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 24)
        '
        'BtnKnot
        '
        Me.BtnKnot.AutoSize = False
        Me.BtnKnot.BackgroundImage = CType(resources.GetObject("BtnKnot.BackgroundImage"), System.Drawing.Image)
        Me.BtnKnot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnKnot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnKnot.Image = Global.MyStitch.My.Resources.Resources.knot
        Me.BtnKnot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnKnot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnKnot.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnKnot.Name = "BtnKnot"
        Me.BtnKnot.Size = New System.Drawing.Size(23, 22)
        Me.BtnKnot.Text = "ToolStripButton1"
        Me.BtnKnot.ToolTipText = "Knot"
        '
        'BtnBead
        '
        Me.BtnBead.AutoSize = False
        Me.BtnBead.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnBead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnBead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnBead.Image = Global.MyStitch.My.Resources.Resources.Bead
        Me.BtnBead.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnBead.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBead.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnBead.Name = "BtnBead"
        Me.BtnBead.Size = New System.Drawing.Size(23, 22)
        Me.BtnBead.Text = "ToolStripButton1"
        Me.BtnBead.ToolTipText = "Bead"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222!))
        Me.TableLayoutPanel1.Controls.Add(Me.PicCentreLines, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblPixelColourName, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PicGrid, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PicStitch, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PnlSelectedColor, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LblCurrentColour, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LblCursorPos, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PnlPixelColour, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LblSelectMessage, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblSelection, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblStatus, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 503)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(865, 50)
        Me.TableLayoutPanel1.TabIndex = 138
        '
        'PicCentreLines
        '
        Me.PicCentreLines.BackColor = System.Drawing.Color.AliceBlue
        Me.PicCentreLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicCentreLines.Location = New System.Drawing.Point(26, 26)
        Me.PicCentreLines.Margin = New System.Windows.Forms.Padding(0)
        Me.PicCentreLines.Name = "PicCentreLines"
        Me.PicCentreLines.Size = New System.Drawing.Size(20, 21)
        Me.PicCentreLines.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicCentreLines.TabIndex = 10
        Me.PicCentreLines.TabStop = False
        '
        'LblPixelColourName
        '
        Me.LblPixelColourName.AutoSize = True
        Me.LblPixelColourName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPixelColourName.Location = New System.Drawing.Point(513, 6)
        Me.LblPixelColourName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblPixelColourName.Name = "LblPixelColourName"
        Me.LblPixelColourName.Size = New System.Drawing.Size(119, 14)
        Me.LblPixelColourName.TabIndex = 6
        Me.LblPixelColourName.Text = "No colour selected"
        Me.LblPixelColourName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PicGrid
        '
        Me.PicGrid.BackColor = System.Drawing.Color.AliceBlue
        Me.PicGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicGrid.Location = New System.Drawing.Point(3, 3)
        Me.PicGrid.Margin = New System.Windows.Forms.Padding(0)
        Me.PicGrid.Name = "PicGrid"
        Me.PicGrid.Size = New System.Drawing.Size(20, 20)
        Me.PicGrid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicGrid.TabIndex = 0
        Me.PicGrid.TabStop = False
        '
        'PicStitch
        '
        Me.PicStitch.Location = New System.Drawing.Point(3, 26)
        Me.PicStitch.Margin = New System.Windows.Forms.Padding(0)
        Me.PicStitch.Name = "PicStitch"
        Me.PicStitch.Size = New System.Drawing.Size(20, 21)
        Me.PicStitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicStitch.TabIndex = 1
        Me.PicStitch.TabStop = False
        '
        'PnlSelectedColor
        '
        Me.PnlSelectedColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlSelectedColor.Location = New System.Drawing.Point(26, 3)
        Me.PnlSelectedColor.Margin = New System.Windows.Forms.Padding(0)
        Me.PnlSelectedColor.Name = "PnlSelectedColor"
        Me.PnlSelectedColor.Size = New System.Drawing.Size(20, 20)
        Me.PnlSelectedColor.TabIndex = 2
        '
        'LblCurrentColour
        '
        Me.LblCurrentColour.AutoSize = True
        Me.LblCurrentColour.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentColour.Location = New System.Drawing.Point(52, 6)
        Me.LblCurrentColour.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblCurrentColour.Name = "LblCurrentColour"
        Me.LblCurrentColour.Size = New System.Drawing.Size(119, 14)
        Me.LblCurrentColour.TabIndex = 3
        Me.LblCurrentColour.Text = "No colour selected"
        Me.LblCurrentColour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCursorPos
        '
        Me.LblCursorPos.AutoSize = True
        Me.LblCursorPos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCursorPos.Location = New System.Drawing.Point(690, 6)
        Me.LblCursorPos.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblCursorPos.Name = "LblCursorPos"
        Me.LblCursorPos.Size = New System.Drawing.Size(58, 14)
        Me.LblCursorPos.TabIndex = 4
        Me.LblCursorPos.Text = "X:0 , Y:0"
        Me.LblCursorPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlPixelColour
        '
        Me.PnlPixelColour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlPixelColour.Location = New System.Drawing.Point(487, 3)
        Me.PnlPixelColour.Margin = New System.Windows.Forms.Padding(0)
        Me.PnlPixelColour.Name = "PnlPixelColour"
        Me.PnlPixelColour.Size = New System.Drawing.Size(20, 20)
        Me.PnlPixelColour.TabIndex = 5
        '
        'LblSelectMessage
        '
        Me.LblSelectMessage.AutoSize = True
        Me.LblSelectMessage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectMessage.Location = New System.Drawing.Point(513, 29)
        Me.LblSelectMessage.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblSelectMessage.Name = "LblSelectMessage"
        Me.LblSelectMessage.Size = New System.Drawing.Size(106, 14)
        Me.LblSelectMessage.TabIndex = 7
        Me.LblSelectMessage.Text = "No cells selected"
        Me.LblSelectMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSelection
        '
        Me.LblSelection.AutoSize = True
        Me.LblSelection.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelection.Location = New System.Drawing.Point(690, 29)
        Me.LblSelection.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblSelection.Name = "LblSelection"
        Me.LblSelection.Size = New System.Drawing.Size(104, 14)
        Me.LblSelection.TabIndex = 8
        Me.LblSelection.Text = "From 0,0 To 0,0"
        Me.LblSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Location = New System.Drawing.Point(52, 29)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(28, 14)
        Me.LblStatus.TabIndex = 9
        Me.LblStatus.Text = "xxx"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImage = CType(resources.GetObject("MenuStrip1.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDesign, Me.MnuPalette, Me.MnuThreads, Me.MnuEdit, Me.MnuDraw, Me.MnuText, Me.ViewToolStripMenuItem, Me.MnuTools})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(865, 24)
        Me.MenuStrip1.TabIndex = 139
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuDesign
        '
        Me.MnuDesign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuOpenDesign, Me.MnuSaveDesign, Me.MnuSaveDesignAs, Me.ToolStripSeparator10, Me.MnuPrint, Me.ToolStripSeparator8, Me.MnuExit})
        Me.MnuDesign.Name = "MnuDesign"
        Me.MnuDesign.Size = New System.Drawing.Size(55, 20)
        Me.MnuDesign.Text = "Design"
        '
        'MnuOpenDesign
        '
        Me.MnuOpenDesign.Name = "MnuOpenDesign"
        Me.MnuOpenDesign.Size = New System.Drawing.Size(123, 22)
        Me.MnuOpenDesign.Text = "Open"
        '
        'MnuSaveDesign
        '
        Me.MnuSaveDesign.Name = "MnuSaveDesign"
        Me.MnuSaveDesign.Size = New System.Drawing.Size(123, 22)
        Me.MnuSaveDesign.Text = "Save"
        '
        'MnuSaveDesignAs
        '
        Me.MnuSaveDesignAs.Name = "MnuSaveDesignAs"
        Me.MnuSaveDesignAs.Size = New System.Drawing.Size(123, 22)
        Me.MnuSaveDesignAs.Text = "Save As..."
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(120, 6)
        '
        'MnuPrint
        '
        Me.MnuPrint.Name = "MnuPrint"
        Me.MnuPrint.Size = New System.Drawing.Size(123, 22)
        Me.MnuPrint.Text = "Print"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(120, 6)
        '
        'MnuExit
        '
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.Size = New System.Drawing.Size(123, 22)
        Me.MnuExit.Text = "Exit"
        '
        'MnuPalette
        '
        Me.MnuPalette.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSelectColours, Me.MnuRemoveUnused, Me.MnuSavePalette, Me.ToolStripSeparator19, Me.MnuSymbols, Me.MnuThreadSymbols, Me.ToolStripSeparator16, Me.MnuThreadCards, Me.MnuPrintCards})
        Me.MnuPalette.Name = "MnuPalette"
        Me.MnuPalette.Size = New System.Drawing.Size(55, 20)
        Me.MnuPalette.Text = "Palette"
        '
        'MnuSelectColours
        '
        Me.MnuSelectColours.Name = "MnuSelectColours"
        Me.MnuSelectColours.Size = New System.Drawing.Size(230, 22)
        Me.MnuSelectColours.Text = "Select Colours"
        '
        'MnuRemoveUnused
        '
        Me.MnuRemoveUnused.Name = "MnuRemoveUnused"
        Me.MnuRemoveUnused.Size = New System.Drawing.Size(230, 22)
        Me.MnuRemoveUnused.Text = "Remove Unused Colours"
        '
        'MnuSavePalette
        '
        Me.MnuSavePalette.Name = "MnuSavePalette"
        Me.MnuSavePalette.Size = New System.Drawing.Size(230, 22)
        Me.MnuSavePalette.Text = "Save Palette"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(227, 6)
        '
        'MnuSymbols
        '
        Me.MnuSymbols.Name = "MnuSymbols"
        Me.MnuSymbols.Size = New System.Drawing.Size(230, 22)
        Me.MnuSymbols.Text = "Design Symbols"
        '
        'MnuThreadSymbols
        '
        Me.MnuThreadSymbols.Name = "MnuThreadSymbols"
        Me.MnuThreadSymbols.Size = New System.Drawing.Size(230, 22)
        Me.MnuThreadSymbols.Text = "Select ProjectThread Symbols"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(227, 6)
        '
        'MnuThreadCards
        '
        Me.MnuThreadCards.Name = "MnuThreadCards"
        Me.MnuThreadCards.Size = New System.Drawing.Size(230, 22)
        Me.MnuThreadCards.Text = "Create ProjectThread Cards"
        '
        'MnuPrintCards
        '
        Me.MnuPrintCards.Name = "MnuPrintCards"
        Me.MnuPrintCards.Size = New System.Drawing.Size(230, 22)
        Me.MnuPrintCards.Text = "Print ProjectThread Cards"
        '
        'MnuThreads
        '
        Me.MnuThreads.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPickColour, Me.MnuChangeColour, Me.MnuDeleteColour})
        Me.MnuThreads.Name = "MnuThreads"
        Me.MnuThreads.Size = New System.Drawing.Size(101, 20)
        Me.MnuThreads.Text = "Project Threads"
        '
        'MnuPickColour
        '
        Me.MnuPickColour.Name = "MnuPickColour"
        Me.MnuPickColour.Size = New System.Drawing.Size(194, 22)
        Me.MnuPickColour.Text = "Pick colour from stitch"
        '
        'MnuChangeColour
        '
        Me.MnuChangeColour.Name = "MnuChangeColour"
        Me.MnuChangeColour.Size = New System.Drawing.Size(194, 22)
        Me.MnuChangeColour.Text = "Change colour"
        '
        'MnuDeleteColour
        '
        Me.MnuDeleteColour.Name = "MnuDeleteColour"
        Me.MnuDeleteColour.Size = New System.Drawing.Size(194, 22)
        Me.MnuDeleteColour.Text = "Delete colour"
        '
        'MnuEdit
        '
        Me.MnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCopySelection, Me.MnuMoveSelection, Me.MnuCutSelection, Me.MnuPaste, Me.ToolStripSeparator9, Me.MnuFlipSelection, Me.MnuMirrorSelection, Me.MnuRotate})
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.MnuEdit.Text = "Edit"
        '
        'MnuCopySelection
        '
        Me.MnuCopySelection.Name = "MnuCopySelection"
        Me.MnuCopySelection.Size = New System.Drawing.Size(108, 22)
        Me.MnuCopySelection.Text = "Copy"
        '
        'MnuMoveSelection
        '
        Me.MnuMoveSelection.Name = "MnuMoveSelection"
        Me.MnuMoveSelection.Size = New System.Drawing.Size(108, 22)
        Me.MnuMoveSelection.Text = "Move"
        '
        'MnuCutSelection
        '
        Me.MnuCutSelection.Name = "MnuCutSelection"
        Me.MnuCutSelection.Size = New System.Drawing.Size(108, 22)
        Me.MnuCutSelection.Text = "Cut"
        '
        'MnuPaste
        '
        Me.MnuPaste.Name = "MnuPaste"
        Me.MnuPaste.Size = New System.Drawing.Size(108, 22)
        Me.MnuPaste.Text = "Paste"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(105, 6)
        '
        'MnuFlipSelection
        '
        Me.MnuFlipSelection.Name = "MnuFlipSelection"
        Me.MnuFlipSelection.Size = New System.Drawing.Size(108, 22)
        Me.MnuFlipSelection.Text = "Flip"
        '
        'MnuMirrorSelection
        '
        Me.MnuMirrorSelection.Name = "MnuMirrorSelection"
        Me.MnuMirrorSelection.Size = New System.Drawing.Size(108, 22)
        Me.MnuMirrorSelection.Text = "Mirror"
        '
        'MnuRotate
        '
        Me.MnuRotate.Name = "MnuRotate"
        Me.MnuRotate.Size = New System.Drawing.Size(108, 22)
        Me.MnuRotate.Text = "Rotate"
        '
        'MnuDraw
        '
        Me.MnuDraw.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDrawShape, Me.MnuDrawFilledShape, Me.ToolStripSeparator11, Me.MnuFloodFill, Me.MnuClearArea})
        Me.MnuDraw.Name = "MnuDraw"
        Me.MnuDraw.Size = New System.Drawing.Size(46, 20)
        Me.MnuDraw.Text = "Draw"
        '
        'MnuDrawShape
        '
        Me.MnuDrawShape.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEllipse, Me.MnuRectangle})
        Me.MnuDrawShape.Name = "MnuDrawShape"
        Me.MnuDrawShape.Size = New System.Drawing.Size(167, 22)
        Me.MnuDrawShape.Text = "Draw Shape"
        '
        'MnuEllipse
        '
        Me.MnuEllipse.Name = "MnuEllipse"
        Me.MnuEllipse.Size = New System.Drawing.Size(126, 22)
        Me.MnuEllipse.Text = "Ellipse"
        '
        'MnuRectangle
        '
        Me.MnuRectangle.Name = "MnuRectangle"
        Me.MnuRectangle.Size = New System.Drawing.Size(126, 22)
        Me.MnuRectangle.Text = "Rectangle"
        '
        'MnuDrawFilledShape
        '
        Me.MnuDrawFilledShape.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFilledEllipse, Me.MnuFilledRecangle})
        Me.MnuDrawFilledShape.Name = "MnuDrawFilledShape"
        Me.MnuDrawFilledShape.Size = New System.Drawing.Size(167, 22)
        Me.MnuDrawFilledShape.Text = "Draw Filled Shape"
        '
        'MnuFilledEllipse
        '
        Me.MnuFilledEllipse.Name = "MnuFilledEllipse"
        Me.MnuFilledEllipse.Size = New System.Drawing.Size(126, 22)
        Me.MnuFilledEllipse.Text = "Ellipse"
        '
        'MnuFilledRecangle
        '
        Me.MnuFilledRecangle.Name = "MnuFilledRecangle"
        Me.MnuFilledRecangle.Size = New System.Drawing.Size(126, 22)
        Me.MnuFilledRecangle.Text = "Rectangle"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(164, 6)
        '
        'MnuFloodFill
        '
        Me.MnuFloodFill.Name = "MnuFloodFill"
        Me.MnuFloodFill.Size = New System.Drawing.Size(167, 22)
        Me.MnuFloodFill.Text = "Flood Fill"
        '
        'MnuClearArea
        '
        Me.MnuClearArea.Name = "MnuClearArea"
        Me.MnuClearArea.Size = New System.Drawing.Size(167, 22)
        Me.MnuClearArea.Text = "Clear Area"
        '
        'MnuText
        '
        Me.MnuText.Name = "MnuText"
        Me.MnuText.Size = New System.Drawing.Size(40, 20)
        Me.MnuText.Text = "Text"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRedraw, Me.MnuZoomIn, Me.MnuZoomOut, Me.MnuZoom, Me.ToolStripSeparator12, Me.MnuGridOn, Me.MnuCentreOn, Me.MnuCentreMarks, Me.MnuSingleColour, Me.MnuStitchDisplayStyle, Me.MnuStitchTypes})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'MnuRedraw
        '
        Me.MnuRedraw.Name = "MnuRedraw"
        Me.MnuRedraw.Size = New System.Drawing.Size(180, 22)
        Me.MnuRedraw.Text = "Redraw"
        '
        'MnuZoomIn
        '
        Me.MnuZoomIn.Name = "MnuZoomIn"
        Me.MnuZoomIn.Size = New System.Drawing.Size(180, 22)
        Me.MnuZoomIn.Text = "Zoom In"
        '
        'MnuZoomOut
        '
        Me.MnuZoomOut.Name = "MnuZoomOut"
        Me.MnuZoomOut.Size = New System.Drawing.Size(180, 22)
        Me.MnuZoomOut.Text = "Zoom Out"
        '
        'MnuZoom
        '
        Me.MnuZoom.Name = "MnuZoom"
        Me.MnuZoom.Size = New System.Drawing.Size(180, 22)
        Me.MnuZoom.Text = "Zoom"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(177, 6)
        '
        'MnuGridOn
        '
        Me.MnuGridOn.Name = "MnuGridOn"
        Me.MnuGridOn.Size = New System.Drawing.Size(180, 22)
        Me.MnuGridOn.Text = "Grid"
        '
        'MnuCentreOn
        '
        Me.MnuCentreOn.CheckOnClick = True
        Me.MnuCentreOn.Name = "MnuCentreOn"
        Me.MnuCentreOn.Size = New System.Drawing.Size(180, 22)
        Me.MnuCentreOn.Text = "Centre Lines"
        '
        'MnuSingleColour
        '
        Me.MnuSingleColour.CheckOnClick = True
        Me.MnuSingleColour.Name = "MnuSingleColour"
        Me.MnuSingleColour.Size = New System.Drawing.Size(180, 22)
        Me.MnuSingleColour.Text = "Single Colour"
        '
        'MnuStitchDisplayStyle
        '
        Me.MnuStitchDisplayStyle.Name = "MnuStitchDisplayStyle"
        Me.MnuStitchDisplayStyle.Size = New System.Drawing.Size(180, 22)
        Me.MnuStitchDisplayStyle.Text = "Stitch Display Style"
        '
        'MnuStitchTypes
        '
        Me.MnuStitchTypes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuBlockStitches, Me.MnuBackStitches, Me.MnuKnots})
        Me.MnuStitchTypes.Name = "MnuStitchTypes"
        Me.MnuStitchTypes.Size = New System.Drawing.Size(180, 22)
        Me.MnuStitchTypes.Text = "Stitch Types"
        '
        'MnuBlockStitches
        '
        Me.MnuBlockStitches.Checked = True
        Me.MnuBlockStitches.CheckOnClick = True
        Me.MnuBlockStitches.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MnuBlockStitches.Name = "MnuBlockStitches"
        Me.MnuBlockStitches.Size = New System.Drawing.Size(161, 22)
        Me.MnuBlockStitches.Text = "Block Stitches"
        '
        'MnuBackStitches
        '
        Me.MnuBackStitches.Checked = True
        Me.MnuBackStitches.CheckOnClick = True
        Me.MnuBackStitches.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MnuBackStitches.Name = "MnuBackStitches"
        Me.MnuBackStitches.Size = New System.Drawing.Size(161, 22)
        Me.MnuBackStitches.Text = "Back Stitches"
        '
        'MnuKnots
        '
        Me.MnuKnots.Checked = True
        Me.MnuKnots.CheckOnClick = True
        Me.MnuKnots.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MnuKnots.Name = "MnuKnots"
        Me.MnuKnots.Size = New System.Drawing.Size(161, 22)
        Me.MnuKnots.Text = "Knots and Beads"
        '
        'MnuTools
        '
        Me.MnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCropDesign, Me.MnuExtendDesign, Me.ToolStripSeparator13, Me.MnuOptions, Me.MnuShow})
        Me.MnuTools.Name = "MnuTools"
        Me.MnuTools.Size = New System.Drawing.Size(47, 20)
        Me.MnuTools.Text = "Tools"
        '
        'MnuCropDesign
        '
        Me.MnuCropDesign.Name = "MnuCropDesign"
        Me.MnuCropDesign.Size = New System.Drawing.Size(116, 22)
        Me.MnuCropDesign.Text = "Crop"
        '
        'MnuExtendDesign
        '
        Me.MnuExtendDesign.Name = "MnuExtendDesign"
        Me.MnuExtendDesign.Size = New System.Drawing.Size(116, 22)
        Me.MnuExtendDesign.Text = "Extend"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(113, 6)
        '
        'MnuOptions
        '
        Me.MnuOptions.Name = "MnuOptions"
        Me.MnuOptions.Size = New System.Drawing.Size(116, 22)
        Me.MnuOptions.Text = "Options"
        '
        'MnuShow
        '
        Me.MnuShow.Name = "MnuShow"
        Me.MnuShow.Size = New System.Drawing.Size(116, 22)
        Me.MnuShow.Text = "Info"
        '
        'MnuCentreMarks
        '
        Me.MnuCentreMarks.CheckOnClick = True
        Me.MnuCentreMarks.Name = "MnuCentreMarks"
        Me.MnuCentreMarks.Size = New System.Drawing.Size(180, 22)
        Me.MnuCentreMarks.Text = "CentreMarks"
        '
        'FrmStitchDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(865, 553)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmStitchDesign"
        Me.Text = "Stitch Design"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PnlPaletteName.ResumeLayout(False)
        Me.PnlPaletteName.PerformLayout()
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PicCentreLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicStitch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ThreadLayoutPanel As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PicDesign As PictureBox
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BtnCopy As ToolStripButton
    Friend WithEvents BtnCut As ToolStripButton
    Friend WithEvents BtnMove As ToolStripButton
    Friend WithEvents BtnPaste As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BtnMirror As ToolStripButton
    Friend WithEvents BtnFlip As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BtnUndo As ToolStripButton
    Friend WithEvents BtnRedo As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents BtnFill As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents BtnZoom As ToolStripButton
    Friend WithEvents BtnEnlarge As ToolStripButton
    Friend WithEvents BtnShrink As ToolStripButton
    Friend WithEvents BtnWidth As ToolStripButton
    Friend WithEvents BtnHeight As ToolStripButton
    Friend WithEvents BtnCentre As ToolStripButton
    Friend WithEvents BtnClose As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents BtnFullStitch As ToolStripButton
    Friend WithEvents Btn3QtrsTL As ToolStripButton
    Friend WithEvents Btn3QtrsTR As ToolStripButton
    Friend WithEvents Btn3QtrsBR As ToolStripButton
    Friend WithEvents Btn3QtrsBL As ToolStripButton
    Friend WithEvents BtnHalfForward As ToolStripButton
    Friend WithEvents BtnHalfBack As ToolStripButton
    Friend WithEvents BtnQtrTL As ToolStripButton
    Friend WithEvents BtnQtrTR As ToolStripButton
    Friend WithEvents BtnQtrBR As ToolStripButton
    Friend WithEvents BtnQtrBL As ToolStripButton
    Friend WithEvents BtnQuarters As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BtnFullBackstitchThin As ToolStripButton
    Friend WithEvents BtnHalfBackStitchThin As ToolStripButton
    Friend WithEvents BtnFullBackStitchThick As ToolStripButton
    Friend WithEvents BtnHalfBackStitchThick As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents BtnKnot As ToolStripButton
    Friend WithEvents BtnBead As ToolStripButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LblPixelColourName As Label
    Friend WithEvents PicGrid As PictureBox
    Friend WithEvents PicStitch As PictureBox
    Friend WithEvents PnlSelectedColor As Panel
    Friend WithEvents LblCurrentColour As Label
    Friend WithEvents LblCursorPos As Label
    Friend WithEvents PnlPixelColour As Panel
    Friend WithEvents LblSelectMessage As Label
    Friend WithEvents LblSelection As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MnuDesign As ToolStripMenuItem
    Friend WithEvents MnuOpenDesign As ToolStripMenuItem
    Friend WithEvents MnuSaveDesign As ToolStripMenuItem
    Friend WithEvents MnuSaveDesignAs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents MnuExit As ToolStripMenuItem
    Friend WithEvents MnuThreads As ToolStripMenuItem
    Friend WithEvents MnuPalette As ToolStripMenuItem
    Friend WithEvents MnuSymbols As ToolStripMenuItem
    Friend WithEvents MnuThreadSymbols As ToolStripMenuItem
    Friend WithEvents MnuEdit As ToolStripMenuItem
    Friend WithEvents MnuCopySelection As ToolStripMenuItem
    Friend WithEvents MnuMoveSelection As ToolStripMenuItem
    Friend WithEvents MnuCutSelection As ToolStripMenuItem
    Friend WithEvents MnuPaste As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents MnuFlipSelection As ToolStripMenuItem
    Friend WithEvents MnuMirrorSelection As ToolStripMenuItem
    Friend WithEvents MnuRotate As ToolStripMenuItem
    Friend WithEvents MnuDraw As ToolStripMenuItem
    Friend WithEvents MnuDrawShape As ToolStripMenuItem
    Friend WithEvents MnuDrawFilledShape As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents MnuFloodFill As ToolStripMenuItem
    Friend WithEvents MnuText As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuRedraw As ToolStripMenuItem
    Friend WithEvents MnuZoomIn As ToolStripMenuItem
    Friend WithEvents MnuZoomOut As ToolStripMenuItem
    Friend WithEvents MnuZoom As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents MnuGridOn As ToolStripMenuItem
    Friend WithEvents MnuStitchDisplayStyle As ToolStripMenuItem
    Friend WithEvents MnuStitchTypes As ToolStripMenuItem
    Friend WithEvents MnuBlockStitches As ToolStripMenuItem
    Friend WithEvents MnuBackStitches As ToolStripMenuItem
    Friend WithEvents MnuKnots As ToolStripMenuItem
    Friend WithEvents MnuTools As ToolStripMenuItem
    Friend WithEvents MnuCropDesign As ToolStripMenuItem
    Friend WithEvents MnuExtendDesign As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents MnuOptions As ToolStripMenuItem
    Friend WithEvents LblStatus As Label
    Friend WithEvents PicCentreLines As PictureBox
    Friend WithEvents MnuCentreOn As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents BtnTimer As ToolStripButton
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents BtnSingleColour As ToolStripButton
    Friend WithEvents MnuSingleColour As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents MnuPrint As ToolStripMenuItem
    Friend WithEvents BtnSave As ToolStripButton
    Friend WithEvents BtnPrint As ToolStripButton
    Friend WithEvents BtnRotate As ToolStripButton
    Friend WithEvents MnuClearArea As ToolStripMenuItem
    Friend WithEvents MnuEllipse As ToolStripMenuItem
    Friend WithEvents MnuRectangle As ToolStripMenuItem
    Friend WithEvents MnuFilledEllipse As ToolStripMenuItem
    Friend WithEvents MnuFilledRecangle As ToolStripMenuItem
    Friend WithEvents MnuShow As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As ToolStripSeparator
    Friend WithEvents MnuSelectColours As ToolStripMenuItem
    Friend WithEvents MnuRemoveUnused As ToolStripMenuItem
    Friend WithEvents MnuThreadCards As ToolStripMenuItem
    Friend WithEvents MnuPrintCards As ToolStripMenuItem
    Friend WithEvents MnuPickColour As ToolStripMenuItem
    Friend WithEvents MnuChangeColour As ToolStripMenuItem
    Friend WithEvents MnuDeleteColour As ToolStripMenuItem
    Friend WithEvents MnuSavePalette As ToolStripMenuItem
    Friend WithEvents PnlPaletteName As Panel
    Friend WithEvents BtnCancelPalette As Button
    Friend WithEvents BtnSavePalette As Button
    Friend WithEvents TxtPaletteName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MnuCentreMarks As ToolStripMenuItem
End Class
