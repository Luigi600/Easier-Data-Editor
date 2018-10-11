<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ui_frameViewer
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_frameViewer))
        Me.cb_bodies = New System.Windows.Forms.CheckBox()
        Me.cb_itrs = New System.Windows.Forms.CheckBox()
        Me.cb_wpoint = New System.Windows.Forms.CheckBox()
        Me.cb_opoint = New System.Windows.Forms.CheckBox()
        Me.cb_weapon = New System.Windows.Forms.CheckBox()
        Me.cb_cpoint = New System.Windows.Forms.CheckBox()
        Me.cb_bpoint = New System.Windows.Forms.CheckBox()
        Me.ms_options = New System.Windows.Forms.MenuStrip()
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
        Me.TSMI_resetView = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_charView = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_bodies = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_itrs = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_wpoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_weapon = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_wHitbox = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_bpoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_opoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_cpoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_shadow = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_center_xy = New System.Windows.Forms.ToolStripMenuItem()
        Me.pic_preview = New System.Windows.Forms.PictureBox()
        Me.pal_charView = New System.Windows.Forms.Panel()
        Me.flp_main = New System.Windows.Forms.FlowLayoutPanel()
        Me.flp_char_view = New System.Windows.Forms.FlowLayoutPanel()
        Me.cb_wHitbox = New System.Windows.Forms.CheckBox()
        Me.cb_shadow = New System.Windows.Forms.CheckBox()
        Me.cb_center_xy = New System.Windows.Forms.CheckBox()
        Me.flp_view = New System.Windows.Forms.FlowLayoutPanel()
        Me.cb_showScales = New System.Windows.Forms.CheckBox()
        Me.cb_axis = New System.Windows.Forms.CheckBox()
        Me.cd_bg = New System.Windows.Forms.ColorDialog()
        Me.background_drawer = New System.ComponentModel.BackgroundWorker()
        Me.ms_options.SuspendLayout()
        CType(Me.pic_preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pal_charView.SuspendLayout()
        Me.flp_main.SuspendLayout()
        Me.flp_char_view.SuspendLayout()
        Me.flp_view.SuspendLayout()
        Me.SuspendLayout()
        '
        'cb_bodies
        '
        Me.cb_bodies.AutoSize = True
        Me.cb_bodies.Checked = True
        Me.cb_bodies.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_bodies.Location = New System.Drawing.Point(3, 3)
        Me.cb_bodies.Name = "cb_bodies"
        Me.cb_bodies.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_bodies.Size = New System.Drawing.Size(62, 21)
        Me.cb_bodies.TabIndex = 0
        Me.cb_bodies.Text = "Bodies"
        Me.cb_bodies.UseVisualStyleBackColor = False
        '
        'cb_itrs
        '
        Me.cb_itrs.AutoSize = True
        Me.cb_itrs.Checked = True
        Me.cb_itrs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_itrs.Location = New System.Drawing.Point(71, 3)
        Me.cb_itrs.Name = "cb_itrs"
        Me.cb_itrs.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_itrs.Size = New System.Drawing.Size(44, 21)
        Me.cb_itrs.TabIndex = 0
        Me.cb_itrs.Text = "Itrs"
        Me.cb_itrs.UseVisualStyleBackColor = False
        '
        'cb_wpoint
        '
        Me.cb_wpoint.AutoSize = True
        Me.cb_wpoint.Checked = True
        Me.cb_wpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_wpoint.Location = New System.Drawing.Point(121, 3)
        Me.cb_wpoint.Name = "cb_wpoint"
        Me.cb_wpoint.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_wpoint.Size = New System.Drawing.Size(68, 21)
        Me.cb_wpoint.TabIndex = 0
        Me.cb_wpoint.Text = "W-Point"
        Me.cb_wpoint.UseVisualStyleBackColor = False
        '
        'cb_opoint
        '
        Me.cb_opoint.AutoSize = True
        Me.cb_opoint.Checked = True
        Me.cb_opoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_opoint.Location = New System.Drawing.Point(183, 30)
        Me.cb_opoint.Name = "cb_opoint"
        Me.cb_opoint.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_opoint.Size = New System.Drawing.Size(65, 21)
        Me.cb_opoint.TabIndex = 0
        Me.cb_opoint.Text = "O-Point"
        Me.cb_opoint.UseVisualStyleBackColor = False
        '
        'cb_weapon
        '
        Me.cb_weapon.AutoSize = True
        Me.cb_weapon.Checked = True
        Me.cb_weapon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_weapon.Location = New System.Drawing.Point(195, 3)
        Me.cb_weapon.Name = "cb_weapon"
        Me.cb_weapon.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_weapon.Size = New System.Drawing.Size(71, 21)
        Me.cb_weapon.TabIndex = 0
        Me.cb_weapon.Text = "Weapon"
        Me.cb_weapon.UseVisualStyleBackColor = False
        Me.cb_weapon.Visible = False
        '
        'cb_cpoint
        '
        Me.cb_cpoint.AutoSize = True
        Me.cb_cpoint.Checked = True
        Me.cb_cpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_cpoint.Location = New System.Drawing.Point(254, 30)
        Me.cb_cpoint.Name = "cb_cpoint"
        Me.cb_cpoint.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_cpoint.Size = New System.Drawing.Size(64, 21)
        Me.cb_cpoint.TabIndex = 0
        Me.cb_cpoint.Text = "C-Point"
        Me.cb_cpoint.UseVisualStyleBackColor = False
        '
        'cb_bpoint
        '
        Me.cb_bpoint.AutoSize = True
        Me.cb_bpoint.Checked = True
        Me.cb_bpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_bpoint.Location = New System.Drawing.Point(113, 30)
        Me.cb_bpoint.Name = "cb_bpoint"
        Me.cb_bpoint.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_bpoint.Size = New System.Drawing.Size(64, 21)
        Me.cb_bpoint.TabIndex = 0
        Me.cb_bpoint.Text = "B-Point"
        Me.cb_bpoint.UseVisualStyleBackColor = False
        '
        'ms_options
        '
        Me.ms_options.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ms_options.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_view, Me.TSMI_charView})
        Me.ms_options.Location = New System.Drawing.Point(0, 0)
        Me.ms_options.Name = "ms_options"
        Me.ms_options.Size = New System.Drawing.Size(541, 24)
        Me.ms_options.TabIndex = 1
        '
        'TSMI_view
        '
        Me.TSMI_view.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_showScales, Me.TSMI_axis, Me.TSMI_background, Me.TSMI_mirrorFrame, Me.TSMI_mirrorFrame_data, Me.TSMI_auto_bdy, Me.TSMI_resetView})
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
        Me.TSMI_bg_image.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_bg_image.Text = "Image"
        '
        'TSMI_bg_color
        '
        Me.TSMI_bg_color.CheckOnClick = True
        Me.TSMI_bg_color.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_bg_col_set})
        Me.TSMI_bg_color.Name = "TSMI_bg_color"
        Me.TSMI_bg_color.Size = New System.Drawing.Size(180, 22)
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
        'TSMI_resetView
        '
        Me.TSMI_resetView.Name = "TSMI_resetView"
        Me.TSMI_resetView.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad0), System.Windows.Forms.Keys)
        Me.TSMI_resetView.Size = New System.Drawing.Size(237, 22)
        Me.TSMI_resetView.Text = "Reset Position"
        '
        'TSMI_charView
        '
        Me.TSMI_charView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_bodies, Me.TSMI_itrs, Me.TSMI_wpoint, Me.TSMI_bpoint, Me.TSMI_opoint, Me.TSMI_cpoint, Me.TSMI_shadow, Me.TSMI_center_xy})
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
        Me.TSMI_bodies.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_bodies.Text = "Bodies"
        '
        'TSMI_itrs
        '
        Me.TSMI_itrs.Checked = True
        Me.TSMI_itrs.CheckOnClick = True
        Me.TSMI_itrs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_itrs.Name = "TSMI_itrs"
        Me.TSMI_itrs.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_itrs.Text = "Itrs"
        '
        'TSMI_wpoint
        '
        Me.TSMI_wpoint.Checked = True
        Me.TSMI_wpoint.CheckOnClick = True
        Me.TSMI_wpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_wpoint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_weapon, Me.TSMI_wHitbox})
        Me.TSMI_wpoint.Name = "TSMI_wpoint"
        Me.TSMI_wpoint.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_wpoint.Text = "W-Point"
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
        'TSMI_wHitbox
        '
        Me.TSMI_wHitbox.Checked = True
        Me.TSMI_wHitbox.CheckOnClick = True
        Me.TSMI_wHitbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_wHitbox.Name = "TSMI_wHitbox"
        Me.TSMI_wHitbox.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_wHitbox.Text = "Hitbox"
        '
        'TSMI_bpoint
        '
        Me.TSMI_bpoint.Checked = True
        Me.TSMI_bpoint.CheckOnClick = True
        Me.TSMI_bpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_bpoint.Name = "TSMI_bpoint"
        Me.TSMI_bpoint.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_bpoint.Text = "B-Point"
        '
        'TSMI_opoint
        '
        Me.TSMI_opoint.Checked = True
        Me.TSMI_opoint.CheckOnClick = True
        Me.TSMI_opoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_opoint.Name = "TSMI_opoint"
        Me.TSMI_opoint.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_opoint.Text = "O-Point"
        '
        'TSMI_cpoint
        '
        Me.TSMI_cpoint.Checked = True
        Me.TSMI_cpoint.CheckOnClick = True
        Me.TSMI_cpoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_cpoint.Name = "TSMI_cpoint"
        Me.TSMI_cpoint.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_cpoint.Text = "C-Point"
        '
        'TSMI_shadow
        '
        Me.TSMI_shadow.Checked = True
        Me.TSMI_shadow.CheckOnClick = True
        Me.TSMI_shadow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_shadow.Name = "TSMI_shadow"
        Me.TSMI_shadow.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_shadow.Text = "Shadow"
        '
        'TSMI_center_xy
        '
        Me.TSMI_center_xy.Checked = True
        Me.TSMI_center_xy.CheckOnClick = True
        Me.TSMI_center_xy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_center_xy.Name = "TSMI_center_xy"
        Me.TSMI_center_xy.Size = New System.Drawing.Size(131, 22)
        Me.TSMI_center_xy.Text = "Center X/Y"
        '
        'pic_preview
        '
        Me.pic_preview.BackgroundImage = Global.Easier_Data_Editor.My.Resources.Resources.bg_transparent
        Me.pic_preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pic_preview.Location = New System.Drawing.Point(0, 125)
        Me.pic_preview.Name = "pic_preview"
        Me.pic_preview.Size = New System.Drawing.Size(541, 207)
        Me.pic_preview.TabIndex = 2
        Me.pic_preview.TabStop = False
        '
        'pal_charView
        '
        Me.pal_charView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pal_charView.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pal_charView.Controls.Add(Me.flp_main)
        Me.pal_charView.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_charView.Location = New System.Drawing.Point(0, 24)
        Me.pal_charView.Name = "pal_charView"
        Me.pal_charView.Padding = New System.Windows.Forms.Padding(6)
        Me.pal_charView.Size = New System.Drawing.Size(541, 101)
        Me.pal_charView.TabIndex = 4
        '
        'flp_main
        '
        Me.flp_main.AutoScroll = True
        Me.flp_main.Controls.Add(Me.flp_char_view)
        Me.flp_main.Controls.Add(Me.flp_view)
        Me.flp_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp_main.Location = New System.Drawing.Point(6, 6)
        Me.flp_main.Name = "flp_main"
        Me.flp_main.Size = New System.Drawing.Size(529, 89)
        Me.flp_main.TabIndex = 6
        '
        'flp_char_view
        '
        Me.flp_char_view.Controls.Add(Me.cb_bodies)
        Me.flp_char_view.Controls.Add(Me.cb_itrs)
        Me.flp_char_view.Controls.Add(Me.cb_wpoint)
        Me.flp_char_view.Controls.Add(Me.cb_weapon)
        Me.flp_char_view.Controls.Add(Me.cb_wHitbox)
        Me.flp_char_view.Controls.Add(Me.cb_bpoint)
        Me.flp_char_view.Controls.Add(Me.cb_opoint)
        Me.flp_char_view.Controls.Add(Me.cb_cpoint)
        Me.flp_char_view.Controls.Add(Me.cb_shadow)
        Me.flp_char_view.Controls.Add(Me.cb_center_xy)
        Me.flp_char_view.Location = New System.Drawing.Point(3, 3)
        Me.flp_char_view.Name = "flp_char_view"
        Me.flp_char_view.Size = New System.Drawing.Size(361, 80)
        Me.flp_char_view.TabIndex = 0
        '
        'cb_wHitbox
        '
        Me.cb_wHitbox.AutoSize = True
        Me.cb_wHitbox.Checked = True
        Me.cb_wHitbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_wHitbox.Location = New System.Drawing.Point(3, 30)
        Me.cb_wHitbox.Name = "cb_wHitbox"
        Me.cb_wHitbox.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_wHitbox.Size = New System.Drawing.Size(104, 21)
        Me.cb_wHitbox.TabIndex = 1
        Me.cb_wHitbox.Text = "Weapon Hitbox"
        Me.cb_wHitbox.UseVisualStyleBackColor = False
        '
        'cb_shadow
        '
        Me.cb_shadow.AutoSize = True
        Me.cb_shadow.Checked = True
        Me.cb_shadow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_shadow.Location = New System.Drawing.Point(3, 57)
        Me.cb_shadow.Name = "cb_shadow"
        Me.cb_shadow.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_shadow.Size = New System.Drawing.Size(69, 21)
        Me.cb_shadow.TabIndex = 0
        Me.cb_shadow.Text = "Shadow"
        Me.cb_shadow.UseVisualStyleBackColor = False
        '
        'cb_center_xy
        '
        Me.cb_center_xy.AutoSize = True
        Me.cb_center_xy.Checked = True
        Me.cb_center_xy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_center_xy.Location = New System.Drawing.Point(78, 57)
        Me.cb_center_xy.Name = "cb_center_xy"
        Me.cb_center_xy.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_center_xy.Size = New System.Drawing.Size(83, 21)
        Me.cb_center_xy.TabIndex = 0
        Me.cb_center_xy.Text = "Center X/Y"
        Me.cb_center_xy.UseVisualStyleBackColor = False
        '
        'flp_view
        '
        Me.flp_view.Controls.Add(Me.cb_showScales)
        Me.flp_view.Controls.Add(Me.cb_axis)
        Me.flp_view.Location = New System.Drawing.Point(370, 3)
        Me.flp_view.Name = "flp_view"
        Me.flp_view.Size = New System.Drawing.Size(153, 25)
        Me.flp_view.TabIndex = 1
        '
        'cb_showScales
        '
        Me.cb_showScales.AutoSize = True
        Me.cb_showScales.Checked = True
        Me.cb_showScales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_showScales.Location = New System.Drawing.Point(3, 3)
        Me.cb_showScales.Name = "cb_showScales"
        Me.cb_showScales.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_showScales.Size = New System.Drawing.Size(92, 21)
        Me.cb_showScales.TabIndex = 0
        Me.cb_showScales.Text = "Show Scales"
        Me.cb_showScales.UseVisualStyleBackColor = False
        '
        'cb_axis
        '
        Me.cb_axis.AutoSize = True
        Me.cb_axis.Checked = True
        Me.cb_axis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_axis.Location = New System.Drawing.Point(101, 3)
        Me.cb_axis.Name = "cb_axis"
        Me.cb_axis.Padding = New System.Windows.Forms.Padding(2)
        Me.cb_axis.Size = New System.Drawing.Size(49, 21)
        Me.cb_axis.TabIndex = 0
        Me.cb_axis.Text = "Axis"
        Me.cb_axis.UseVisualStyleBackColor = False
        '
        'background_drawer
        '
        Me.background_drawer.WorkerReportsProgress = True
        Me.background_drawer.WorkerSupportsCancellation = True
        '
        'ui_frameViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(541, 332)
        Me.Controls.Add(Me.pic_preview)
        Me.Controls.Add(Me.pal_charView)
        Me.Controls.Add(Me.ms_options)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.ms_options
        Me.Name = "ui_frameViewer"
        Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight
        Me.Text = "Frame Viewer"
        Me.ms_options.ResumeLayout(False)
        Me.ms_options.PerformLayout()
        CType(Me.pic_preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pal_charView.ResumeLayout(False)
        Me.flp_main.ResumeLayout(False)
        Me.flp_char_view.ResumeLayout(False)
        Me.flp_char_view.PerformLayout()
        Me.flp_view.ResumeLayout(False)
        Me.flp_view.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cb_bodies As CheckBox
    Friend WithEvents cb_itrs As CheckBox
    Friend WithEvents cb_wpoint As CheckBox
    Friend WithEvents cb_opoint As CheckBox
    Friend WithEvents cb_weapon As CheckBox
    Friend WithEvents cb_cpoint As CheckBox
    Friend WithEvents cb_bpoint As CheckBox
    Friend WithEvents ms_options As MenuStrip
    Friend WithEvents TSMI_charView As ToolStripMenuItem
    Friend WithEvents TSMI_bodies As ToolStripMenuItem
    Friend WithEvents TSMI_itrs As ToolStripMenuItem
    Friend WithEvents TSMI_wpoint As ToolStripMenuItem
    Friend WithEvents TSMI_opoint As ToolStripMenuItem
    Friend WithEvents TSMI_cpoint As ToolStripMenuItem
    Friend WithEvents TSMI_bpoint As ToolStripMenuItem
    Friend WithEvents pic_preview As PictureBox
    Friend WithEvents TSMI_view As ToolStripMenuItem
    Friend WithEvents TSMI_showScales As ToolStripMenuItem
    Friend WithEvents TSMI_resetView As ToolStripMenuItem
    Friend WithEvents TSMI_weapon As ToolStripMenuItem
    Friend WithEvents pal_charView As Panel
    Friend WithEvents cb_showScales As CheckBox
    Friend WithEvents flp_main As FlowLayoutPanel
    Friend WithEvents flp_char_view As FlowLayoutPanel
    Friend WithEvents flp_view As FlowLayoutPanel
    Friend WithEvents TSMI_shadow As ToolStripMenuItem
    Friend WithEvents TSMI_center_xy As ToolStripMenuItem
    Friend WithEvents cb_shadow As CheckBox
    Friend WithEvents cb_center_xy As CheckBox
    Friend WithEvents TSMI_axis As ToolStripMenuItem
    Friend WithEvents cb_axis As CheckBox
    Friend WithEvents TSMI_background As ToolStripMenuItem
    Friend WithEvents TSMI_bg_image As ToolStripMenuItem
    Friend WithEvents TSMI_bg_color As ToolStripMenuItem
    Friend WithEvents cd_bg As ColorDialog
    Friend WithEvents TSMI_bg_col_set As ToolStripMenuItem
    Friend WithEvents TSMI_auto_bdy As ToolStripMenuItem
    Friend WithEvents background_drawer As System.ComponentModel.BackgroundWorker
    Friend WithEvents TSMI_mirrorFrame As ToolStripMenuItem
    Friend WithEvents TSMI_mirrorFrame_data As ToolStripMenuItem
    Friend WithEvents cb_wHitbox As CheckBox
    Friend WithEvents TSMI_wHitbox As ToolStripMenuItem
End Class
