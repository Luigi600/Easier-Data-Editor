<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrameViewer
    Inherits Translation.TranslatableDockContent

    Protected Overrides Function GetPersistString() As String
        Return "FV;" & ID.ToString 'fixed name, if i had the idea to change the name of this class...
    End Function

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrameViewer))
        Me.TSMI_wHitbox = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_opoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_cpoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_shadow = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_center_xy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_Fill = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pal_charView = New System.Windows.Forms.Panel()
        Me.Flp_main = New System.Windows.Forms.FlowLayoutPanel()
        Me.Flp_char_view = New System.Windows.Forms.FlowLayoutPanel()
        Me.Cb_bodies = New System.Windows.Forms.CheckBox()
        Me.Cb_itrs = New System.Windows.Forms.CheckBox()
        Me.Cb_wpoint = New System.Windows.Forms.CheckBox()
        Me.Cb_weapon = New System.Windows.Forms.CheckBox()
        Me.Cb_wHitbox = New System.Windows.Forms.CheckBox()
        Me.Cb_bpoint = New System.Windows.Forms.CheckBox()
        Me.Cb_opoint = New System.Windows.Forms.CheckBox()
        Me.Cb_cpoint = New System.Windows.Forms.CheckBox()
        Me.Cb_shadow = New System.Windows.Forms.CheckBox()
        Me.Cb_center_xy = New System.Windows.Forms.CheckBox()
        Me.Cb_Fill = New System.Windows.Forms.CheckBox()
        Me.Pal_bg = New System.Windows.Forms.Panel()
        Me.Gb_bsprite = New System.Windows.Forms.GroupBox()
        Me.Lbl_bspriteStart = New System.Windows.Forms.Label()
        Me.Nud_bspriteIndex = New System.Windows.Forms.NumericUpDown()
        Me.Flp_view = New System.Windows.Forms.FlowLayoutPanel()
        Me.Cb_showScales = New System.Windows.Forms.CheckBox()
        Me.Cb_axis = New System.Windows.Forms.CheckBox()
        Me.Pal_opacity = New System.Windows.Forms.Panel()
        Me.Lbl_opacity = New System.Windows.Forms.Label()
        Me.TB_Opacity = New System.Windows.Forms.TrackBar()
        Me.Cd_bg = New System.Windows.Forms.ColorDialog()
        Me.Tim_drawer = New System.Windows.Forms.Timer(Me.components)
        Me.TSMI_bpoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tim_animation = New System.Windows.Forms.Timer(Me.components)
        Me.TSMI_weapon = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_options = New System.Windows.Forms.MenuStrip()
        Me.TSMI_view = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_showScales = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_axis = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_background = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_bg_image = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_bg_color = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_bg_col_set = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_mirrorFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_mirrorFrame_data = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_auto_bdy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_resetView = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_charView = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_bodies = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_itrs = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_itr_3d = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_wpoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_specials = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_opacity = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_drawBSprite = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_number = New System.Windows.Forms.ToolStripMenuItem()
        Me.Preview = New System.Windows.Forms.PictureBox()
        Me.Cb_drawBSprite = New System.Windows.Forms.CheckBox()
        Me.Pal_charView.SuspendLayout()
        Me.Flp_main.SuspendLayout()
        Me.Flp_char_view.SuspendLayout()
        Me.Pal_bg.SuspendLayout()
        Me.Gb_bsprite.SuspendLayout()
        CType(Me.Nud_bspriteIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flp_view.SuspendLayout()
        Me.Pal_opacity.SuspendLayout()
        CType(Me.TB_Opacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MS_options.SuspendLayout()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TSMI_wHitbox
        '
        Me.TSMI_wHitbox.Checked = True
        Me.TSMI_wHitbox.CheckOnClick = True
        Me.TSMI_wHitbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_wHitbox.Name = "TSMI_wHitbox"
        Me.TSMI_wHitbox.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_wHitbox.Text = "Hitbox"
        '
        'TSMI_opoint
        '
        Me.TSMI_opoint.Checked = True
        Me.TSMI_opoint.CheckOnClick = True
        Me.TSMI_opoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_opoint.Name = "TSMI_opoint"
        Me.TSMI_opoint.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_opoint.Text = "O-Point"
        '
        'TSMI_cpoint
        '
        Me.TSMI_cpoint.Checked = True
        Me.TSMI_cpoint.CheckOnClick = True
        Me.TSMI_cpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_cpoint.Name = "TSMI_cpoint"
        Me.TSMI_cpoint.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_cpoint.Text = "C-Point"
        '
        'TSMI_shadow
        '
        Me.TSMI_shadow.Checked = True
        Me.TSMI_shadow.CheckOnClick = True
        Me.TSMI_shadow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_shadow.Name = "TSMI_shadow"
        Me.TSMI_shadow.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_shadow.Text = "Shadow"
        '
        'TSMI_center_xy
        '
        Me.TSMI_center_xy.Checked = True
        Me.TSMI_center_xy.CheckOnClick = True
        Me.TSMI_center_xy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_center_xy.Name = "TSMI_center_xy"
        Me.TSMI_center_xy.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_center_xy.Text = "Center X/Y"
        '
        'TSS_1
        '
        Me.TSS_1.Name = "TSS_1"
        Me.TSS_1.Size = New System.Drawing.Size(234, 6)
        '
        'TSMI_Fill
        '
        Me.TSMI_Fill.Checked = True
        Me.TSMI_Fill.CheckOnClick = True
        Me.TSMI_Fill.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_Fill.Name = "TSMI_Fill"
        Me.TSMI_Fill.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_Fill.Text = "Fill Rectangles (Bodies and Itrs)"
        '
        'DebugTestToolStripMenuItem
        '
        Me.DebugTestToolStripMenuItem.Name = "DebugTestToolStripMenuItem"
        Me.DebugTestToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.DebugTestToolStripMenuItem.Text = "Debug Test"
        Me.DebugTestToolStripMenuItem.Visible = False
        '
        'Pal_charView
        '
        Me.Pal_charView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Pal_charView.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Pal_charView.Controls.Add(Me.Flp_main)
        Me.Pal_charView.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pal_charView.Location = New System.Drawing.Point(0, 24)
        Me.Pal_charView.Name = "Pal_charView"
        Me.Pal_charView.Padding = New System.Windows.Forms.Padding(6)
        Me.Pal_charView.Size = New System.Drawing.Size(698, 101)
        Me.Pal_charView.TabIndex = 9
        '
        'Flp_main
        '
        Me.Flp_main.AutoScroll = True
        Me.Flp_main.Controls.Add(Me.Flp_char_view)
        Me.Flp_main.Controls.Add(Me.Pal_bg)
        Me.Flp_main.Controls.Add(Me.Pal_opacity)
        Me.Flp_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_main.Location = New System.Drawing.Point(6, 6)
        Me.Flp_main.Name = "Flp_main"
        Me.Flp_main.Size = New System.Drawing.Size(686, 89)
        Me.Flp_main.TabIndex = 6
        '
        'Flp_char_view
        '
        Me.Flp_char_view.Controls.Add(Me.Cb_bodies)
        Me.Flp_char_view.Controls.Add(Me.Cb_itrs)
        Me.Flp_char_view.Controls.Add(Me.Cb_wpoint)
        Me.Flp_char_view.Controls.Add(Me.Cb_weapon)
        Me.Flp_char_view.Controls.Add(Me.Cb_wHitbox)
        Me.Flp_char_view.Controls.Add(Me.Cb_bpoint)
        Me.Flp_char_view.Controls.Add(Me.Cb_opoint)
        Me.Flp_char_view.Controls.Add(Me.Cb_cpoint)
        Me.Flp_char_view.Controls.Add(Me.Cb_shadow)
        Me.Flp_char_view.Controls.Add(Me.Cb_center_xy)
        Me.Flp_char_view.Controls.Add(Me.Cb_Fill)
        Me.Flp_char_view.Location = New System.Drawing.Point(3, 3)
        Me.Flp_char_view.Name = "Flp_char_view"
        Me.Flp_char_view.Size = New System.Drawing.Size(361, 80)
        Me.Flp_char_view.TabIndex = 0
        '
        'Cb_bodies
        '
        Me.Cb_bodies.AutoSize = True
        Me.Cb_bodies.Checked = True
        Me.Cb_bodies.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_bodies.Location = New System.Drawing.Point(3, 3)
        Me.Cb_bodies.Name = "Cb_bodies"
        Me.Cb_bodies.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_bodies.Size = New System.Drawing.Size(62, 21)
        Me.Cb_bodies.TabIndex = 0
        Me.Cb_bodies.Text = "Bodies"
        Me.Cb_bodies.UseVisualStyleBackColor = False
        '
        'Cb_itrs
        '
        Me.Cb_itrs.AutoSize = True
        Me.Cb_itrs.Checked = True
        Me.Cb_itrs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_itrs.Location = New System.Drawing.Point(71, 3)
        Me.Cb_itrs.Name = "Cb_itrs"
        Me.Cb_itrs.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_itrs.Size = New System.Drawing.Size(44, 21)
        Me.Cb_itrs.TabIndex = 0
        Me.Cb_itrs.Text = "Itrs"
        Me.Cb_itrs.UseVisualStyleBackColor = False
        '
        'Cb_wpoint
        '
        Me.Cb_wpoint.AutoSize = True
        Me.Cb_wpoint.Checked = True
        Me.Cb_wpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_wpoint.Location = New System.Drawing.Point(121, 3)
        Me.Cb_wpoint.Name = "Cb_wpoint"
        Me.Cb_wpoint.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_wpoint.Size = New System.Drawing.Size(68, 21)
        Me.Cb_wpoint.TabIndex = 0
        Me.Cb_wpoint.Text = "W-Point"
        Me.Cb_wpoint.UseVisualStyleBackColor = False
        '
        'Cb_weapon
        '
        Me.Cb_weapon.AutoSize = True
        Me.Cb_weapon.Checked = True
        Me.Cb_weapon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_weapon.Location = New System.Drawing.Point(195, 3)
        Me.Cb_weapon.Name = "Cb_weapon"
        Me.Cb_weapon.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_weapon.Size = New System.Drawing.Size(71, 21)
        Me.Cb_weapon.TabIndex = 0
        Me.Cb_weapon.Text = "Weapon"
        Me.Cb_weapon.UseVisualStyleBackColor = False
        Me.Cb_weapon.Visible = False
        '
        'Cb_wHitbox
        '
        Me.Cb_wHitbox.AutoSize = True
        Me.Cb_wHitbox.Checked = True
        Me.Cb_wHitbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_wHitbox.Location = New System.Drawing.Point(3, 30)
        Me.Cb_wHitbox.Name = "Cb_wHitbox"
        Me.Cb_wHitbox.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_wHitbox.Size = New System.Drawing.Size(104, 21)
        Me.Cb_wHitbox.TabIndex = 1
        Me.Cb_wHitbox.Text = "Weapon Hitbox"
        Me.Cb_wHitbox.UseVisualStyleBackColor = False
        '
        'Cb_bpoint
        '
        Me.Cb_bpoint.AutoSize = True
        Me.Cb_bpoint.Checked = True
        Me.Cb_bpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_bpoint.Location = New System.Drawing.Point(113, 30)
        Me.Cb_bpoint.Name = "Cb_bpoint"
        Me.Cb_bpoint.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_bpoint.Size = New System.Drawing.Size(64, 21)
        Me.Cb_bpoint.TabIndex = 0
        Me.Cb_bpoint.Text = "B-Point"
        Me.Cb_bpoint.UseVisualStyleBackColor = False
        '
        'Cb_opoint
        '
        Me.Cb_opoint.AutoSize = True
        Me.Cb_opoint.Checked = True
        Me.Cb_opoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_opoint.Location = New System.Drawing.Point(183, 30)
        Me.Cb_opoint.Name = "Cb_opoint"
        Me.Cb_opoint.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_opoint.Size = New System.Drawing.Size(65, 21)
        Me.Cb_opoint.TabIndex = 0
        Me.Cb_opoint.Text = "O-Point"
        Me.Cb_opoint.UseVisualStyleBackColor = False
        '
        'Cb_cpoint
        '
        Me.Cb_cpoint.AutoSize = True
        Me.Cb_cpoint.Checked = True
        Me.Cb_cpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_cpoint.Location = New System.Drawing.Point(254, 30)
        Me.Cb_cpoint.Name = "Cb_cpoint"
        Me.Cb_cpoint.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_cpoint.Size = New System.Drawing.Size(64, 21)
        Me.Cb_cpoint.TabIndex = 0
        Me.Cb_cpoint.Text = "C-Point"
        Me.Cb_cpoint.UseVisualStyleBackColor = False
        '
        'Cb_shadow
        '
        Me.Cb_shadow.AutoSize = True
        Me.Cb_shadow.Checked = True
        Me.Cb_shadow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_shadow.Location = New System.Drawing.Point(3, 57)
        Me.Cb_shadow.Name = "Cb_shadow"
        Me.Cb_shadow.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_shadow.Size = New System.Drawing.Size(69, 21)
        Me.Cb_shadow.TabIndex = 0
        Me.Cb_shadow.Text = "Shadow"
        Me.Cb_shadow.UseVisualStyleBackColor = False
        '
        'Cb_center_xy
        '
        Me.Cb_center_xy.AutoSize = True
        Me.Cb_center_xy.Checked = True
        Me.Cb_center_xy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_center_xy.Location = New System.Drawing.Point(78, 57)
        Me.Cb_center_xy.Name = "Cb_center_xy"
        Me.Cb_center_xy.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_center_xy.Size = New System.Drawing.Size(83, 21)
        Me.Cb_center_xy.TabIndex = 0
        Me.Cb_center_xy.Text = "Center X/Y"
        Me.Cb_center_xy.UseVisualStyleBackColor = False
        '
        'Cb_Fill
        '
        Me.Cb_Fill.AutoSize = True
        Me.Cb_Fill.Checked = True
        Me.Cb_Fill.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_Fill.Location = New System.Drawing.Point(167, 57)
        Me.Cb_Fill.Name = "Cb_Fill"
        Me.Cb_Fill.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_Fill.Size = New System.Drawing.Size(157, 21)
        Me.Cb_Fill.TabIndex = 2
        Me.Cb_Fill.Text = "Fill Rectangles (bodies/itrs)"
        Me.Cb_Fill.UseVisualStyleBackColor = False
        '
        'Pal_bg
        '
        Me.Pal_bg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pal_bg.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Pal_bg.Controls.Add(Me.Gb_bsprite)
        Me.Pal_bg.Controls.Add(Me.Flp_view)
        Me.Pal_bg.Location = New System.Drawing.Point(370, 3)
        Me.Pal_bg.Name = "Pal_bg"
        Me.Pal_bg.Size = New System.Drawing.Size(269, 80)
        Me.Pal_bg.TabIndex = 10
        '
        'Gb_bsprite
        '
        Me.Gb_bsprite.Controls.Add(Me.Lbl_bspriteStart)
        Me.Gb_bsprite.Controls.Add(Me.Nud_bspriteIndex)
        Me.Gb_bsprite.Location = New System.Drawing.Point(6, 32)
        Me.Gb_bsprite.Name = "Gb_bsprite"
        Me.Gb_bsprite.Size = New System.Drawing.Size(171, 45)
        Me.Gb_bsprite.TabIndex = 12
        Me.Gb_bsprite.TabStop = False
        Me.Gb_bsprite.Text = "B-Sprite Option:"
        '
        'Lbl_bspriteStart
        '
        Me.Lbl_bspriteStart.AutoSize = True
        Me.Lbl_bspriteStart.Location = New System.Drawing.Point(6, 21)
        Me.Lbl_bspriteStart.Name = "Lbl_bspriteStart"
        Me.Lbl_bspriteStart.Size = New System.Drawing.Size(61, 13)
        Me.Lbl_bspriteStart.TabIndex = 12
        Me.Lbl_bspriteStart.Text = "Index Start:"
        '
        'Nud_bspriteIndex
        '
        Me.Nud_bspriteIndex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nud_bspriteIndex.Location = New System.Drawing.Point(69, 19)
        Me.Nud_bspriteIndex.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Nud_bspriteIndex.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.Nud_bspriteIndex.Name = "Nud_bspriteIndex"
        Me.Nud_bspriteIndex.Size = New System.Drawing.Size(96, 20)
        Me.Nud_bspriteIndex.TabIndex = 11
        '
        'Flp_view
        '
        Me.Flp_view.Controls.Add(Me.Cb_showScales)
        Me.Flp_view.Controls.Add(Me.Cb_axis)
        Me.Flp_view.Location = New System.Drawing.Point(3, 3)
        Me.Flp_view.Margin = New System.Windows.Forms.Padding(3, 32, 3, 3)
        Me.Flp_view.Name = "Flp_view"
        Me.Flp_view.Size = New System.Drawing.Size(153, 25)
        Me.Flp_view.TabIndex = 1
        '
        'Cb_showScales
        '
        Me.Cb_showScales.AutoSize = True
        Me.Cb_showScales.Checked = True
        Me.Cb_showScales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_showScales.Location = New System.Drawing.Point(3, 3)
        Me.Cb_showScales.Name = "Cb_showScales"
        Me.Cb_showScales.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_showScales.Size = New System.Drawing.Size(92, 21)
        Me.Cb_showScales.TabIndex = 0
        Me.Cb_showScales.Text = "Show Scales"
        Me.Cb_showScales.UseVisualStyleBackColor = False
        '
        'Cb_axis
        '
        Me.Cb_axis.AutoSize = True
        Me.Cb_axis.Checked = True
        Me.Cb_axis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_axis.Location = New System.Drawing.Point(101, 3)
        Me.Cb_axis.Name = "Cb_axis"
        Me.Cb_axis.Padding = New System.Windows.Forms.Padding(2)
        Me.Cb_axis.Size = New System.Drawing.Size(49, 21)
        Me.Cb_axis.TabIndex = 0
        Me.Cb_axis.Text = "Axis"
        Me.Cb_axis.UseVisualStyleBackColor = False
        '
        'Pal_opacity
        '
        Me.Pal_opacity.Controls.Add(Me.Lbl_opacity)
        Me.Pal_opacity.Controls.Add(Me.TB_Opacity)
        Me.Pal_opacity.Location = New System.Drawing.Point(3, 89)
        Me.Pal_opacity.Name = "Pal_opacity"
        Me.Pal_opacity.Size = New System.Drawing.Size(190, 49)
        Me.Pal_opacity.TabIndex = 6
        '
        'Lbl_opacity
        '
        Me.Lbl_opacity.AutoSize = True
        Me.Lbl_opacity.Location = New System.Drawing.Point(12, 3)
        Me.Lbl_opacity.Name = "Lbl_opacity"
        Me.Lbl_opacity.Size = New System.Drawing.Size(95, 13)
        Me.Lbl_opacity.TabIndex = 6
        Me.Lbl_opacity.Text = "Character Opacity:"
        '
        'TB_Opacity
        '
        Me.TB_Opacity.LargeChange = 20
        Me.TB_Opacity.Location = New System.Drawing.Point(6, 15)
        Me.TB_Opacity.Maximum = 100
        Me.TB_Opacity.Minimum = 20
        Me.TB_Opacity.Name = "TB_Opacity"
        Me.TB_Opacity.Size = New System.Drawing.Size(183, 45)
        Me.TB_Opacity.SmallChange = 10
        Me.TB_Opacity.TabIndex = 5
        Me.TB_Opacity.TickFrequency = 10
        Me.TB_Opacity.Value = 100
        '
        'Tim_drawer
        '
        Me.Tim_drawer.Interval = 20
        '
        'TSMI_bpoint
        '
        Me.TSMI_bpoint.Checked = True
        Me.TSMI_bpoint.CheckOnClick = True
        Me.TSMI_bpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_bpoint.Name = "TSMI_bpoint"
        Me.TSMI_bpoint.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_bpoint.Text = "B-Point"
        '
        'Tim_animation
        '
        Me.Tim_animation.Interval = 33
        '
        'TSMI_weapon
        '
        Me.TSMI_weapon.Checked = True
        Me.TSMI_weapon.CheckOnClick = True
        Me.TSMI_weapon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_weapon.Name = "TSMI_weapon"
        Me.TSMI_weapon.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_weapon.Text = "Weapon"
        '
        'MS_options
        '
        Me.MS_options.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.MS_options.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_view, Me.TSMI_charView, Me.DebugTestToolStripMenuItem, Me.TSMI_specials})
        Me.MS_options.Location = New System.Drawing.Point(0, 0)
        Me.MS_options.Name = "MS_options"
        Me.MS_options.Size = New System.Drawing.Size(698, 24)
        Me.MS_options.TabIndex = 7
        '
        'TSMI_view
        '
        Me.TSMI_view.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_showScales, Me.TSMI_axis, Me.TSMI_background, Me.TSMI_mirrorFrame, Me.TSMI_mirrorFrame_data, Me.TSMI_auto_bdy, Me.TSS_2, Me.TSMI_resetView})
        Me.TSMI_view.Name = "TSMI_view"
        Me.TSMI_view.Size = New System.Drawing.Size(44, 20)
        Me.TSMI_view.Text = "View"
        '
        'TSMI_showScales
        '
        Me.TSMI_showScales.Checked = True
        Me.TSMI_showScales.CheckOnClick = True
        Me.TSMI_showScales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_showScales.Name = "TSMI_showScales"
        Me.TSMI_showScales.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_showScales.Text = "Show Scales"
        '
        'TSMI_axis
        '
        Me.TSMI_axis.Checked = True
        Me.TSMI_axis.CheckOnClick = True
        Me.TSMI_axis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_axis.Name = "TSMI_axis"
        Me.TSMI_axis.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_axis.Text = "Axis"
        '
        'TSMI_background
        '
        Me.TSMI_background.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_bg_image, Me.TSMI_bg_color})
        Me.TSMI_background.Name = "TSMI_background"
        Me.TSMI_background.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_background.Text = "Background"
        '
        'TSMI_bg_image
        '
        Me.TSMI_bg_image.Checked = True
        Me.TSMI_bg_image.CheckOnClick = True
        Me.TSMI_bg_image.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_bg_image.Name = "TSMI_bg_image"
        Me.TSMI_bg_image.Size = New System.Drawing.Size(107, 22)
        Me.TSMI_bg_image.Text = "Image"
        '
        'TSMI_bg_color
        '
        Me.TSMI_bg_color.CheckOnClick = True
        Me.TSMI_bg_color.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_bg_col_set})
        Me.TSMI_bg_color.Name = "TSMI_bg_color"
        Me.TSMI_bg_color.Size = New System.Drawing.Size(107, 22)
        Me.TSMI_bg_color.Text = "Color"
        '
        'TSMI_bg_col_set
        '
        Me.TSMI_bg_col_set.Name = "TSMI_bg_col_set"
        Me.TSMI_bg_col_set.Size = New System.Drawing.Size(90, 22)
        Me.TSMI_bg_col_set.Text = "Set"
        '
        'TSMI_mirrorFrame
        '
        Me.TSMI_mirrorFrame.CheckOnClick = True
        Me.TSMI_mirrorFrame.Name = "TSMI_mirrorFrame"
        Me.TSMI_mirrorFrame.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_mirrorFrame.Text = "Mirror Frame (only View)"
        '
        'TSMI_mirrorFrame_data
        '
        Me.TSMI_mirrorFrame_data.Name = "TSMI_mirrorFrame_data"
        Me.TSMI_mirrorFrame_data.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_mirrorFrame_data.Text = "Mirror Frame (with data)"
        '
        'TSMI_auto_bdy
        '
        Me.TSMI_auto_bdy.Name = "TSMI_auto_bdy"
        Me.TSMI_auto_bdy.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_auto_bdy.Text = "Body auto creating"
        '
        'TSS_2
        '
        Me.TSS_2.Name = "TSS_2"
        Me.TSS_2.Size = New System.Drawing.Size(234, 6)
        '
        'TSMI_resetView
        '
        Me.TSMI_resetView.Name = "TSMI_resetView"
        Me.TSMI_resetView.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad0), System.Windows.Forms.Keys)
        Me.TSMI_resetView.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_resetView.Text = "Reset Position"
        '
        'TSMI_charView
        '
        Me.TSMI_charView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_bodies, Me.TSMI_itrs, Me.TSMI_wpoint, Me.TSMI_bpoint, Me.TSMI_opoint, Me.TSMI_cpoint, Me.TSMI_shadow, Me.TSMI_center_xy, Me.TSS_1, Me.TSMI_Fill})
        Me.TSMI_charView.Name = "TSMI_charView"
        Me.TSMI_charView.Size = New System.Drawing.Size(98, 20)
        Me.TSMI_charView.Text = "Character View"
        '
        'TSMI_bodies
        '
        Me.TSMI_bodies.Checked = True
        Me.TSMI_bodies.CheckOnClick = True
        Me.TSMI_bodies.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_bodies.Name = "TSMI_bodies"
        Me.TSMI_bodies.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_bodies.Text = "Bodies"
        '
        'TSMI_itrs
        '
        Me.TSMI_itrs.Checked = True
        Me.TSMI_itrs.CheckOnClick = True
        Me.TSMI_itrs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_itrs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_itr_3d})
        Me.TSMI_itrs.Name = "TSMI_itrs"
        Me.TSMI_itrs.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_itrs.Text = "Itrs"
        '
        'TSMI_itr_3d
        '
        Me.TSMI_itr_3d.Checked = True
        Me.TSMI_itr_3d.CheckOnClick = True
        Me.TSMI_itr_3d.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_itr_3d.Name = "TSMI_itr_3d"
        Me.TSMI_itr_3d.Size = New System.Drawing.Size(162, 22)
        Me.TSMI_itr_3d.Text = "3D (with zWidth)"
        '
        'TSMI_wpoint
        '
        Me.TSMI_wpoint.Checked = True
        Me.TSMI_wpoint.CheckOnClick = True
        Me.TSMI_wpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_wpoint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_weapon, Me.TSMI_wHitbox})
        Me.TSMI_wpoint.Name = "TSMI_wpoint"
        Me.TSMI_wpoint.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_wpoint.Text = "W-Point"
        '
        'TSMI_specials
        '
        Me.TSMI_specials.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_opacity, Me.TSMI_drawBSprite})
        Me.TSMI_specials.Name = "TSMI_specials"
        Me.TSMI_specials.Size = New System.Drawing.Size(61, 20)
        Me.TSMI_specials.Text = "Specials"
        '
        'TSMI_opacity
        '
        Me.TSMI_opacity.Name = "TSMI_opacity"
        Me.TSMI_opacity.Size = New System.Drawing.Size(191, 22)
        Me.TSMI_opacity.Text = "Character Opacity"
        '
        'TSMI_drawBSprite
        '
        Me.TSMI_drawBSprite.CheckOnClick = True
        Me.TSMI_drawBSprite.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_number})
        Me.TSMI_drawBSprite.Name = "TSMI_drawBSprite"
        Me.TSMI_drawBSprite.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.TSMI_drawBSprite.Size = New System.Drawing.Size(191, 22)
        Me.TSMI_drawBSprite.Text = "Draw B-Sprite"
        '
        'TSMI_number
        '
        Me.TSMI_number.Enabled = False
        Me.TSMI_number.Name = "TSMI_number"
        Me.TSMI_number.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_number.Text = "Number:"
        '
        'Preview
        '
        Me.Preview.BackgroundImage = Global.Easier_Data_Editor.My.Resources.Resources.bg_transparent
        Me.Preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview.Location = New System.Drawing.Point(0, 125)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(698, 207)
        Me.Preview.TabIndex = 8
        Me.Preview.TabStop = False
        '
        'Cb_drawBSprite
        '
        Me.Cb_drawBSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_drawBSprite.Location = New System.Drawing.Point(584, 309)
        Me.Cb_drawBSprite.Name = "Cb_drawBSprite"
        Me.Cb_drawBSprite.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cb_drawBSprite.Size = New System.Drawing.Size(110, 20)
        Me.Cb_drawBSprite.TabIndex = 12
        Me.Cb_drawBSprite.Text = ":Draw B-Sprite"
        Me.Cb_drawBSprite.UseVisualStyleBackColor = True
        '
        'FrameViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 332)
        Me.Controls.Add(Me.Cb_drawBSprite)
        Me.Controls.Add(Me.Preview)
        Me.Controls.Add(Me.Pal_charView)
        Me.Controls.Add(Me.MS_options)
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrameViewer"
        Me.Text = "FrameViewer"
        Me.Pal_charView.ResumeLayout(False)
        Me.Flp_main.ResumeLayout(False)
        Me.Flp_char_view.ResumeLayout(False)
        Me.Flp_char_view.PerformLayout()
        Me.Pal_bg.ResumeLayout(False)
        Me.Gb_bsprite.ResumeLayout(False)
        Me.Gb_bsprite.PerformLayout()
        CType(Me.Nud_bspriteIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flp_view.ResumeLayout(False)
        Me.Flp_view.PerformLayout()
        Me.Pal_opacity.ResumeLayout(False)
        Me.Pal_opacity.PerformLayout()
        CType(Me.TB_Opacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MS_options.ResumeLayout(False)
        Me.MS_options.PerformLayout()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TSMI_wHitbox As ToolStripMenuItem
    Friend WithEvents TSMI_opoint As ToolStripMenuItem
    Friend WithEvents TSMI_cpoint As ToolStripMenuItem
    Friend WithEvents TSMI_shadow As ToolStripMenuItem
    Friend WithEvents TSMI_center_xy As ToolStripMenuItem
    Friend WithEvents TSS_1 As ToolStripSeparator
    Friend WithEvents TSMI_Fill As ToolStripMenuItem
    Friend WithEvents DebugTestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Pal_charView As Panel
    Friend WithEvents Flp_main As FlowLayoutPanel
    Friend WithEvents Flp_char_view As FlowLayoutPanel
    Friend WithEvents Cb_bodies As CheckBox
    Friend WithEvents Cb_itrs As CheckBox
    Friend WithEvents Cb_wpoint As CheckBox
    Friend WithEvents Cb_weapon As CheckBox
    Friend WithEvents Cb_wHitbox As CheckBox
    Friend WithEvents Cb_bpoint As CheckBox
    Friend WithEvents Cb_opoint As CheckBox
    Friend WithEvents Cb_cpoint As CheckBox
    Friend WithEvents Cb_shadow As CheckBox
    Friend WithEvents Cb_center_xy As CheckBox
    Friend WithEvents Cb_Fill As CheckBox
    Friend WithEvents Flp_view As FlowLayoutPanel
    Friend WithEvents Cb_showScales As CheckBox
    Friend WithEvents Cb_axis As CheckBox
    Friend WithEvents Cd_bg As ColorDialog
    Friend WithEvents TB_Opacity As TrackBar
    Friend WithEvents Pal_bg As Panel
    Friend WithEvents Tim_drawer As Timer
    Friend WithEvents TSMI_bpoint As ToolStripMenuItem
    Friend WithEvents Tim_animation As Timer
    Friend WithEvents TSMI_weapon As ToolStripMenuItem
    Friend WithEvents MS_options As MenuStrip
    Friend WithEvents TSMI_view As ToolStripMenuItem
    Friend WithEvents TSMI_showScales As ToolStripMenuItem
    Friend WithEvents TSMI_axis As ToolStripMenuItem
    Friend WithEvents TSMI_background As ToolStripMenuItem
    Friend WithEvents TSMI_bg_image As ToolStripMenuItem
    Friend WithEvents TSMI_bg_color As ToolStripMenuItem
    Friend WithEvents TSMI_bg_col_set As ToolStripMenuItem
    Friend WithEvents TSMI_mirrorFrame As ToolStripMenuItem
    Friend WithEvents TSMI_mirrorFrame_data As ToolStripMenuItem
    Friend WithEvents TSMI_auto_bdy As ToolStripMenuItem
    Friend WithEvents TSMI_resetView As ToolStripMenuItem
    Friend WithEvents TSMI_charView As ToolStripMenuItem
    Friend WithEvents TSMI_bodies As ToolStripMenuItem
    Friend WithEvents TSMI_itrs As ToolStripMenuItem
    Friend WithEvents TSMI_itr_3d As ToolStripMenuItem
    Friend WithEvents TSMI_wpoint As ToolStripMenuItem
    Friend WithEvents Preview As PictureBox
    Friend WithEvents Nud_bspriteIndex As NumericUpDown
    Friend WithEvents TSS_2 As ToolStripSeparator
    Friend WithEvents TSMI_specials As ToolStripMenuItem
    Friend WithEvents TSMI_opacity As ToolStripMenuItem
    Friend WithEvents TSMI_drawBSprite As ToolStripMenuItem
    Friend WithEvents TSMI_number As ToolStripMenuItem
    Friend WithEvents Pal_opacity As Panel
    Friend WithEvents Cb_drawBSprite As CheckBox
    Friend WithEvents Lbl_opacity As Label
    Friend WithEvents Gb_bsprite As GroupBox
    Friend WithEvents Lbl_bspriteStart As Label
End Class