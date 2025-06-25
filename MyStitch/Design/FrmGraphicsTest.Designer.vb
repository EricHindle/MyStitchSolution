<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGraphicsTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGraphicsTest))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ThreadLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PicDesign = New System.Windows.Forms.PictureBox()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCopy = New System.Windows.Forms.ToolStripButton()
        Me.BtnCut = New System.Windows.Forms.ToolStripButton()
        Me.BtnMove = New System.Windows.Forms.ToolStripButton()
        Me.BtnPaste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnMirror = New System.Windows.Forms.ToolStripButton()
        Me.BtnFlip = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnUndo = New System.Windows.Forms.ToolStripButton()
        Me.BtnRedo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnFill = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnZoom = New System.Windows.Forms.ToolStripButton()
        Me.BtnEnlarge = New System.Windows.Forms.ToolStripButton()
        Me.BtnShrink = New System.Windows.Forms.ToolStripButton()
        Me.BtnWidth = New System.Windows.Forms.ToolStripButton()
        Me.BtnHeight = New System.Windows.Forms.ToolStripButton()
        Me.BtnCentre = New System.Windows.Forms.ToolStripButton()
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
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuThreads = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPalette = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProjectPalette = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSelectPaletteColours = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRemoveUnusedColours = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCreateThreadCards = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPrintThreadCards = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuThreadSymbols = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCopySelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMoveSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCutSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFlipSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMirrorSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuClearArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClearSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDraw = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDrawShape = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDrawFilledShape = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFloodFill = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRedraw = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuZoomIn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuZoomOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuZoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuGridOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuStitchDisplayStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuStitchTypes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBlockStitches = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBackStitches = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuKnots = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCropDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuExtendDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuShowDesignStats = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.PicDesign)
        Me.Panel1.Controls.Add(Me.HScrollBar1)
        Me.Panel1.Controls.Add(Me.VScrollBar1)
        Me.Panel1.Location = New System.Drawing.Point(6, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(706, 400)
        Me.Panel1.TabIndex = 137
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
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSave, Me.ToolStripSeparator1, Me.BtnCopy, Me.BtnCut, Me.BtnMove, Me.BtnPaste, Me.ToolStripSeparator4, Me.BtnMirror, Me.BtnFlip, Me.ToolStripSeparator3, Me.BtnUndo, Me.BtnRedo, Me.ToolStripSeparator7, Me.BtnFill, Me.ToolStripSeparator5, Me.BtnZoom, Me.BtnEnlarge, Me.BtnShrink, Me.BtnWidth, Me.BtnHeight, Me.BtnCentre, Me.BtnClose})
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
        Me.BtnSave.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSave.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSave.Image = Global.MyStitch.My.Resources.Resources.save
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(23, 22)
        Me.BtnSave.Text = "ToolStripButton1"
        Me.BtnSave.ToolTipText = "Save Design"
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
        Me.BtnCopy.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCopy.BackgroundImage = CType(resources.GetObject("BtnCopy.BackgroundImage"), System.Drawing.Image)
        Me.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCopy.Image = Global.MyStitch.My.Resources.Resources.copy
        Me.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCopy.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(23, 22)
        Me.BtnCopy.Text = "ToolStripButton3"
        Me.BtnCopy.ToolTipText = "Copy Selection"
        '
        'BtnCut
        '
        Me.BtnCut.AutoSize = False
        Me.BtnCut.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCut.BackgroundImage = CType(resources.GetObject("BtnCut.BackgroundImage"), System.Drawing.Image)
        Me.BtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCut.Image = Global.MyStitch.My.Resources.Resources.cut
        Me.BtnCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCut.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnCut.Name = "BtnCut"
        Me.BtnCut.Size = New System.Drawing.Size(23, 22)
        Me.BtnCut.Text = "ToolStripButton2"
        Me.BtnCut.ToolTipText = "Cut Selection"
        '
        'BtnMove
        '
        Me.BtnMove.AutoSize = False
        Me.BtnMove.BackColor = System.Drawing.SystemColors.Control
        Me.BtnMove.BackgroundImage = CType(resources.GetObject("BtnMove.BackgroundImage"), System.Drawing.Image)
        Me.BtnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnMove.Image = Global.MyStitch.My.Resources.Resources.move
        Me.BtnMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnMove.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnMove.Name = "BtnMove"
        Me.BtnMove.Size = New System.Drawing.Size(23, 22)
        Me.BtnMove.Text = "ToolStripButton1"
        Me.BtnMove.ToolTipText = "Move Selection"
        '
        'BtnPaste
        '
        Me.BtnPaste.AutoSize = False
        Me.BtnPaste.BackColor = System.Drawing.SystemColors.Control
        Me.BtnPaste.BackgroundImage = Global.MyStitch.My.Resources.Resources.BtnBkgrd
        Me.BtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPaste.Image = Global.MyStitch.My.Resources.Resources.paste2
        Me.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPaste.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(23, 22)
        Me.BtnPaste.Text = "ToolStripButton1"
        Me.BtnPaste.ToolTipText = "Paste Selection"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 24)
        '
        'BtnMirror
        '
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 24)
        '
        'BtnUndo
        '
        Me.BtnUndo.AutoSize = False
        Me.BtnUndo.BackColor = System.Drawing.SystemColors.Control
        Me.BtnUndo.BackgroundImage = CType(resources.GetObject("BtnUndo.BackgroundImage"), System.Drawing.Image)
        Me.BtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnUndo.Image = Global.MyStitch.My.Resources.Resources.undo
        Me.BtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnUndo.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.Size = New System.Drawing.Size(23, 22)
        Me.BtnUndo.Text = "ToolStripButton1"
        Me.BtnUndo.ToolTipText = "Undo change"
        '
        'BtnRedo
        '
        Me.BtnRedo.AutoSize = False
        Me.BtnRedo.BackColor = System.Drawing.SystemColors.Control
        Me.BtnRedo.BackgroundImage = CType(resources.GetObject("BtnRedo.BackgroundImage"), System.Drawing.Image)
        Me.BtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRedo.Image = Global.MyStitch.My.Resources.Resources.redo
        Me.BtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRedo.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnRedo.Name = "BtnRedo"
        Me.BtnRedo.Size = New System.Drawing.Size(23, 22)
        Me.BtnRedo.Text = "BtnRedo"
        Me.BtnRedo.ToolTipText = "Redo Change"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 24)
        '
        'BtnFill
        '
        Me.BtnFill.AutoSize = False
        Me.BtnFill.BackColor = System.Drawing.SystemColors.Control
        Me.BtnFill.BackgroundImage = CType(resources.GetObject("BtnFill.BackgroundImage"), System.Drawing.Image)
        Me.BtnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFill.Image = Global.MyStitch.My.Resources.Resources.flood
        Me.BtnFill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFill.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(23, 22)
        Me.BtnFill.Text = "ToolStripButton1"
        Me.BtnFill.ToolTipText = "Fill"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 24)
        '
        'BtnZoom
        '
        Me.BtnZoom.AutoSize = False
        Me.BtnZoom.BackColor = System.Drawing.SystemColors.Control
        Me.BtnZoom.BackgroundImage = CType(resources.GetObject("BtnZoom.BackgroundImage"), System.Drawing.Image)
        Me.BtnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnZoom.Image = Global.MyStitch.My.Resources.Resources.zoom
        Me.BtnZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnZoom.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnZoom.Name = "BtnZoom"
        Me.BtnZoom.Size = New System.Drawing.Size(23, 22)
        Me.BtnZoom.Text = "ToolStripButton1"
        '
        'BtnEnlarge
        '
        Me.BtnEnlarge.AutoSize = False
        Me.BtnEnlarge.BackColor = System.Drawing.SystemColors.Control
        Me.BtnEnlarge.BackgroundImage = CType(resources.GetObject("BtnEnlarge.BackgroundImage"), System.Drawing.Image)
        Me.BtnEnlarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEnlarge.Image = Global.MyStitch.My.Resources.Resources.enlarge
        Me.BtnEnlarge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEnlarge.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnEnlarge.Name = "BtnEnlarge"
        Me.BtnEnlarge.Size = New System.Drawing.Size(23, 22)
        Me.BtnEnlarge.Text = "ToolStripButton1"
        Me.BtnEnlarge.ToolTipText = "Enlarge Image"
        '
        'BtnShrink
        '
        Me.BtnShrink.AutoSize = False
        Me.BtnShrink.BackColor = System.Drawing.SystemColors.Control
        Me.BtnShrink.BackgroundImage = CType(resources.GetObject("BtnShrink.BackgroundImage"), System.Drawing.Image)
        Me.BtnShrink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnShrink.Image = Global.MyStitch.My.Resources.Resources.shrink
        Me.BtnShrink.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnShrink.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnShrink.Name = "BtnShrink"
        Me.BtnShrink.Size = New System.Drawing.Size(23, 22)
        Me.BtnShrink.Text = "ToolStripButton1"
        Me.BtnShrink.ToolTipText = "Shrink Image"
        '
        'BtnWidth
        '
        Me.BtnWidth.AutoSize = False
        Me.BtnWidth.BackColor = System.Drawing.SystemColors.Control
        Me.BtnWidth.BackgroundImage = CType(resources.GetObject("BtnWidth.BackgroundImage"), System.Drawing.Image)
        Me.BtnWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnWidth.Image = Global.MyStitch.My.Resources.Resources.width
        Me.BtnWidth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnWidth.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnWidth.Name = "BtnWidth"
        Me.BtnWidth.Size = New System.Drawing.Size(23, 22)
        Me.BtnWidth.Text = "ToolStripButton1"
        Me.BtnWidth.ToolTipText = "Fit Image to Width"
        '
        'BtnHeight
        '
        Me.BtnHeight.AutoSize = False
        Me.BtnHeight.BackColor = System.Drawing.SystemColors.Control
        Me.BtnHeight.BackgroundImage = CType(resources.GetObject("BtnHeight.BackgroundImage"), System.Drawing.Image)
        Me.BtnHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnHeight.Image = Global.MyStitch.My.Resources.Resources.height
        Me.BtnHeight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHeight.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnHeight.Name = "BtnHeight"
        Me.BtnHeight.Size = New System.Drawing.Size(23, 22)
        Me.BtnHeight.Text = "ToolStripButton1"
        Me.BtnHeight.ToolTipText = "Fit Image To Height"
        '
        'BtnCentre
        '
        Me.BtnCentre.AutoSize = False
        Me.BtnCentre.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCentre.BackgroundImage = CType(resources.GetObject("BtnCentre.BackgroundImage"), System.Drawing.Image)
        Me.BtnCentre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCentre.Image = Global.MyStitch.My.Resources.Resources.centre
        Me.BtnCentre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCentre.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnCentre.Name = "BtnCentre"
        Me.BtnCentre.Size = New System.Drawing.Size(23, 22)
        Me.BtnCentre.Text = "ToolStripButton1"
        Me.BtnCentre.ToolTipText = "Cente Image"
        '
        'BtnClose
        '
        Me.BtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnClose.AutoSize = False
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.BtnClose.BackgroundImage = CType(resources.GetObject("BtnClose.BackgroundImage"), System.Drawing.Image)
        Me.BtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(46, 22)
        Me.BtnClose.Text = "Close"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnFullStitch, Me.Btn3QtrsTL, Me.Btn3QtrsTR, Me.Btn3QtrsBR, Me.Btn3QtrsBL, Me.BtnHalfForward, Me.BtnHalfBack, Me.BtnQtrTL, Me.BtnQtrTR, Me.BtnQtrBR, Me.BtnQtrBL, Me.BtnQuarters, Me.ToolStripSeparator2, Me.BtnFullBackstitchThin, Me.BtnHalfBackStitchThin, Me.BtnFullBackStitchThick, Me.BtnHalfBackStitchThick, Me.ToolStripSeparator6, Me.BtnKnot, Me.BtnBead})
        Me.ToolStrip2.Location = New System.Drawing.Point(6, 31)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(2, 1, 2, 2)
        Me.ToolStrip2.Size = New System.Drawing.Size(700, 26)
        Me.ToolStrip2.TabIndex = 136
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'BtnFullStitch
        '
        Me.BtnFullStitch.AutoSize = False
        Me.BtnFullStitch.BackColor = System.Drawing.SystemColors.Control
        Me.BtnFullStitch.BackgroundImage = CType(resources.GetObject("BtnFullStitch.BackgroundImage"), System.Drawing.Image)
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
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'BtnFullBackstitchThin
        '
        Me.BtnFullBackstitchThin.AutoSize = False
        Me.BtnFullBackstitchThin.BackgroundImage = CType(resources.GetObject("BtnFullBackstitchThin.BackgroundImage"), System.Drawing.Image)
        Me.BtnFullBackstitchThin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFullBackstitchThin.Image = CType(resources.GetObject("BtnFullBackstitchThin.Image"), System.Drawing.Image)
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
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'BtnKnot
        '
        Me.BtnKnot.AutoSize = False
        Me.BtnKnot.BackgroundImage = CType(resources.GetObject("BtnKnot.BackgroundImage"), System.Drawing.Image)
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
        Me.PicGrid.BackColor = System.Drawing.SystemColors.Control
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDesign, Me.MnuThreads, Me.MnuPalette, Me.MnuEdit, Me.MnuDraw, Me.MnuText, Me.ViewToolStripMenuItem, Me.MnuTools})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(865, 24)
        Me.MenuStrip1.TabIndex = 139
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuDesign
        '
        Me.MnuDesign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuOpenDesign, Me.MnuSaveDesign, Me.MnuSaveDesignAs, Me.ToolStripSeparator8, Me.MnuExit})
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
        'MnuThreads
        '
        Me.MnuThreads.Name = "MnuThreads"
        Me.MnuThreads.Size = New System.Drawing.Size(61, 20)
        Me.MnuThreads.Text = "Threads"
        '
        'MnuPalette
        '
        Me.MnuPalette.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuProjectPalette, Me.MnuSymbols, Me.MnuThreadSymbols})
        Me.MnuPalette.Name = "MnuPalette"
        Me.MnuPalette.Size = New System.Drawing.Size(55, 20)
        Me.MnuPalette.Text = "Palette"
        '
        'MnuProjectPalette
        '
        Me.MnuProjectPalette.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSelectPaletteColours, Me.MnuRemoveUnusedColours, Me.MnuCreateThreadCards, Me.MnuPrintThreadCards})
        Me.MnuProjectPalette.Name = "MnuProjectPalette"
        Me.MnuProjectPalette.Size = New System.Drawing.Size(196, 22)
        Me.MnuProjectPalette.Text = "Project Palette"
        '
        'MnuSelectPaletteColours
        '
        Me.MnuSelectPaletteColours.Name = "MnuSelectPaletteColours"
        Me.MnuSelectPaletteColours.Size = New System.Drawing.Size(218, 22)
        Me.MnuSelectPaletteColours.Text = "Select Colours"
        '
        'MnuRemoveUnusedColours
        '
        Me.MnuRemoveUnusedColours.Name = "MnuRemoveUnusedColours"
        Me.MnuRemoveUnusedColours.Size = New System.Drawing.Size(218, 22)
        Me.MnuRemoveUnusedColours.Text = "Remove Unused Colours"
        '
        'MnuCreateThreadCards
        '
        Me.MnuCreateThreadCards.Name = "MnuCreateThreadCards"
        Me.MnuCreateThreadCards.Size = New System.Drawing.Size(218, 22)
        Me.MnuCreateThreadCards.Text = "Create ProjectThread Cards"
        '
        'MnuPrintThreadCards
        '
        Me.MnuPrintThreadCards.Name = "MnuPrintThreadCards"
        Me.MnuPrintThreadCards.Size = New System.Drawing.Size(218, 22)
        Me.MnuPrintThreadCards.Text = "Print ProjectThread Cards"
        '
        'MnuSymbols
        '
        Me.MnuSymbols.Name = "MnuSymbols"
        Me.MnuSymbols.Size = New System.Drawing.Size(196, 22)
        Me.MnuSymbols.Text = "Symbols"
        '
        'MnuThreadSymbols
        '
        Me.MnuThreadSymbols.Name = "MnuThreadSymbols"
        Me.MnuThreadSymbols.Size = New System.Drawing.Size(196, 22)
        Me.MnuThreadSymbols.Text = "ProjectThread Symbols"
        '
        'MnuEdit
        '
        Me.MnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCopySelection, Me.MnuMoveSelection, Me.MnuCutSelection, Me.MnuPaste, Me.ToolStripSeparator9, Me.MnuFlipSelection, Me.MnuMirrorSelection, Me.MnuRotate, Me.ToolStripSeparator10, Me.MnuClearArea, Me.MnuClearSelection})
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.MnuEdit.Text = "Edit"
        '
        'MnuCopySelection
        '
        Me.MnuCopySelection.Name = "MnuCopySelection"
        Me.MnuCopySelection.Size = New System.Drawing.Size(152, 22)
        Me.MnuCopySelection.Text = "Copy"
        '
        'MnuMoveSelection
        '
        Me.MnuMoveSelection.Name = "MnuMoveSelection"
        Me.MnuMoveSelection.Size = New System.Drawing.Size(152, 22)
        Me.MnuMoveSelection.Text = "Move"
        '
        'MnuCutSelection
        '
        Me.MnuCutSelection.Name = "MnuCutSelection"
        Me.MnuCutSelection.Size = New System.Drawing.Size(152, 22)
        Me.MnuCutSelection.Text = "Cut"
        '
        'MnuPaste
        '
        Me.MnuPaste.Name = "MnuPaste"
        Me.MnuPaste.Size = New System.Drawing.Size(152, 22)
        Me.MnuPaste.Text = "Paste"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(149, 6)
        '
        'MnuFlipSelection
        '
        Me.MnuFlipSelection.Name = "MnuFlipSelection"
        Me.MnuFlipSelection.Size = New System.Drawing.Size(152, 22)
        Me.MnuFlipSelection.Text = "Flip"
        '
        'MnuMirrorSelection
        '
        Me.MnuMirrorSelection.Name = "MnuMirrorSelection"
        Me.MnuMirrorSelection.Size = New System.Drawing.Size(152, 22)
        Me.MnuMirrorSelection.Text = "Mirror"
        '
        'MnuRotate
        '
        Me.MnuRotate.Name = "MnuRotate"
        Me.MnuRotate.Size = New System.Drawing.Size(152, 22)
        Me.MnuRotate.Text = "Rotate"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(149, 6)
        '
        'MnuClearArea
        '
        Me.MnuClearArea.Name = "MnuClearArea"
        Me.MnuClearArea.Size = New System.Drawing.Size(152, 22)
        Me.MnuClearArea.Text = "Clear Area"
        '
        'MnuClearSelection
        '
        Me.MnuClearSelection.Name = "MnuClearSelection"
        Me.MnuClearSelection.Size = New System.Drawing.Size(152, 22)
        Me.MnuClearSelection.Text = "Clear Selection"
        '
        'MnuDraw
        '
        Me.MnuDraw.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDrawShape, Me.MnuDrawFilledShape, Me.ToolStripSeparator11, Me.MnuFloodFill})
        Me.MnuDraw.Name = "MnuDraw"
        Me.MnuDraw.Size = New System.Drawing.Size(46, 20)
        Me.MnuDraw.Text = "Draw"
        '
        'MnuDrawShape
        '
        Me.MnuDrawShape.Name = "MnuDrawShape"
        Me.MnuDrawShape.Size = New System.Drawing.Size(167, 22)
        Me.MnuDrawShape.Text = "Draw Shape"
        '
        'MnuDrawFilledShape
        '
        Me.MnuDrawFilledShape.Name = "MnuDrawFilledShape"
        Me.MnuDrawFilledShape.Size = New System.Drawing.Size(167, 22)
        Me.MnuDrawFilledShape.Text = "Draw Filled Shape"
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
        'MnuText
        '
        Me.MnuText.Name = "MnuText"
        Me.MnuText.Size = New System.Drawing.Size(40, 20)
        Me.MnuText.Text = "Text"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRedraw, Me.MnuZoomIn, Me.MnuZoomOut, Me.MnuZoom, Me.ToolStripSeparator12, Me.MnuGridOn, Me.MnuStitchDisplayStyle, Me.MnuStitchTypes})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'MnuRedraw
        '
        Me.MnuRedraw.Name = "MnuRedraw"
        Me.MnuRedraw.Size = New System.Drawing.Size(173, 22)
        Me.MnuRedraw.Text = "Redraw"
        '
        'MnuZoomIn
        '
        Me.MnuZoomIn.Name = "MnuZoomIn"
        Me.MnuZoomIn.Size = New System.Drawing.Size(173, 22)
        Me.MnuZoomIn.Text = "Zoom In"
        '
        'MnuZoomOut
        '
        Me.MnuZoomOut.Name = "MnuZoomOut"
        Me.MnuZoomOut.Size = New System.Drawing.Size(173, 22)
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
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(170, 6)
        '
        'MnuGridOn
        '
        Me.MnuGridOn.Name = "MnuGridOn"
        Me.MnuGridOn.Size = New System.Drawing.Size(173, 22)
        Me.MnuGridOn.Text = "Grid"
        '
        'MnuStitchDisplayStyle
        '
        Me.MnuStitchDisplayStyle.Name = "MnuStitchDisplayStyle"
        Me.MnuStitchDisplayStyle.Size = New System.Drawing.Size(173, 22)
        Me.MnuStitchDisplayStyle.Text = "Stitch Display Style"
        '
        'MnuStitchTypes
        '
        Me.MnuStitchTypes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuBlockStitches, Me.MnuBackStitches, Me.MnuKnots})
        Me.MnuStitchTypes.Name = "MnuStitchTypes"
        Me.MnuStitchTypes.Size = New System.Drawing.Size(173, 22)
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
        Me.MnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCropDesign, Me.MnuExtendDesign, Me.ToolStripSeparator13, Me.MnuShowDesignStats, Me.MnuOptions})
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
        'MnuShowDesignStats
        '
        Me.MnuShowDesignStats.Name = "MnuShowDesignStats"
        Me.MnuShowDesignStats.Size = New System.Drawing.Size(116, 22)
        Me.MnuShowDesignStats.Text = "Show"
        '
        'MnuOptions
        '
        Me.MnuOptions.Name = "MnuOptions"
        Me.MnuOptions.Size = New System.Drawing.Size(116, 22)
        Me.MnuOptions.Text = "Options"
        '
        'FrmGraphicsTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 553)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmGraphicsTest"
        Me.Text = "FrmGraphicsTest"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PicDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
    Friend WithEvents BtnSave As ToolStripButton
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
    Friend WithEvents MnuProjectPalette As ToolStripMenuItem
    Friend WithEvents MnuSelectPaletteColours As ToolStripMenuItem
    Friend WithEvents MnuRemoveUnusedColours As ToolStripMenuItem
    Friend WithEvents MnuCreateThreadCards As ToolStripMenuItem
    Friend WithEvents MnuPrintThreadCards As ToolStripMenuItem
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
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents MnuClearArea As ToolStripMenuItem
    Friend WithEvents MnuClearSelection As ToolStripMenuItem
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
    Friend WithEvents MnuShowDesignStats As ToolStripMenuItem
    Friend WithEvents MnuOptions As ToolStripMenuItem
    Friend WithEvents LblStatus As Label
End Class
