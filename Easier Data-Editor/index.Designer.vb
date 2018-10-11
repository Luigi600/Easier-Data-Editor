<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class index
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(index))
        Me.ms_icons = New System.Windows.Forms.MenuStrip()
        Me.TSMI_icon_new = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_open = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_saveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_undo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_redo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ss_infos = New System.Windows.Forms.StatusStrip()
        Me.TSSL_copyright = New System.Windows.Forms.ToolStripStatusLabel()
        Me.link_cookiesoft = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dockpan_main = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.ms_main = New System.Windows.Forms.MenuStrip()
        Me.TSMI_file = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_new = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_open = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_recentFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_saveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_saveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_quit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_undo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_redo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_paste_cool = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_selectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_expand = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_collapse = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_search = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_find = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_find_replace = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_find_again = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_find_again_reverse = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_jump_to = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_jump = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_jump_frame = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_windows = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_frameViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_unused_frames = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_error_list = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_framesReformatting = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_mirrorFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_tag_adder = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ID_changer = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_hidden_tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_hT_frameViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofd_data = New System.Windows.Forms.OpenFileDialog()
        Me.ms_icons.SuspendLayout()
        Me.ss_infos.SuspendLayout()
        Me.ms_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'ms_icons
        '
        Me.ms_icons.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ms_icons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_icon_new, Me.TSMI_icon_open, Me.TSMI_icon_save, Me.TSMI_icon_saveAll, Me.TSMI_icon_close, Me.TSMI_icon_undo, Me.TSMI_icon_redo})
        Me.ms_icons.Location = New System.Drawing.Point(0, 24)
        Me.ms_icons.Name = "ms_icons"
        Me.ms_icons.Size = New System.Drawing.Size(1054, 24)
        Me.ms_icons.TabIndex = 0
        Me.ms_icons.Text = "Icons"
        '
        'TSMI_icon_new
        '
        Me.TSMI_icon_new.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_new
        Me.TSMI_icon_new.Name = "TSMI_icon_new"
        Me.TSMI_icon_new.Size = New System.Drawing.Size(28, 20)
        '
        'TSMI_icon_open
        '
        Me.TSMI_icon_open.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_open
        Me.TSMI_icon_open.Name = "TSMI_icon_open"
        Me.TSMI_icon_open.Size = New System.Drawing.Size(28, 20)
        '
        'TSMI_icon_save
        '
        Me.TSMI_icon_save.Enabled = False
        Me.TSMI_icon_save.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_save
        Me.TSMI_icon_save.Name = "TSMI_icon_save"
        Me.TSMI_icon_save.Size = New System.Drawing.Size(28, 20)
        '
        'TSMI_icon_saveAll
        '
        Me.TSMI_icon_saveAll.Enabled = False
        Me.TSMI_icon_saveAll.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_save_all
        Me.TSMI_icon_saveAll.Name = "TSMI_icon_saveAll"
        Me.TSMI_icon_saveAll.Size = New System.Drawing.Size(28, 20)
        '
        'TSMI_icon_close
        '
        Me.TSMI_icon_close.Enabled = False
        Me.TSMI_icon_close.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_close
        Me.TSMI_icon_close.Name = "TSMI_icon_close"
        Me.TSMI_icon_close.Size = New System.Drawing.Size(28, 20)
        '
        'TSMI_icon_undo
        '
        Me.TSMI_icon_undo.Enabled = False
        Me.TSMI_icon_undo.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_undo
        Me.TSMI_icon_undo.Name = "TSMI_icon_undo"
        Me.TSMI_icon_undo.Size = New System.Drawing.Size(28, 20)
        '
        'TSMI_icon_redo
        '
        Me.TSMI_icon_redo.Enabled = False
        Me.TSMI_icon_redo.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_redo
        Me.TSMI_icon_redo.Name = "TSMI_icon_redo"
        Me.TSMI_icon_redo.Size = New System.Drawing.Size(28, 20)
        '
        'ss_infos
        '
        Me.ss_infos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_copyright, Me.link_cookiesoft})
        Me.ss_infos.Location = New System.Drawing.Point(0, 527)
        Me.ss_infos.Name = "ss_infos"
        Me.ss_infos.Size = New System.Drawing.Size(1054, 22)
        Me.ss_infos.TabIndex = 1
        '
        'TSSL_copyright
        '
        Me.TSSL_copyright.Name = "TSSL_copyright"
        Me.TSSL_copyright.Size = New System.Drawing.Size(975, 17)
        Me.TSSL_copyright.Spring = True
        Me.TSSL_copyright.Text = "Copyright of:"
        Me.TSSL_copyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'link_cookiesoft
        '
        Me.link_cookiesoft.IsLink = True
        Me.link_cookiesoft.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.link_cookiesoft.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.link_cookiesoft.Name = "link_cookiesoft"
        Me.link_cookiesoft.Size = New System.Drawing.Size(64, 17)
        Me.link_cookiesoft.Text = "Cookiesoft"
        Me.link_cookiesoft.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'dockpan_main
        '
        Me.dockpan_main.AllowDrop = True
        Me.dockpan_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockpan_main.Location = New System.Drawing.Point(0, 48)
        Me.dockpan_main.Name = "dockpan_main"
        Me.dockpan_main.Size = New System.Drawing.Size(1054, 479)
        Me.dockpan_main.TabIndex = 2
        '
        'ms_main
        '
        Me.ms_main.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ms_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_file, Me.TSMI_edit, Me.TSMI_search, Me.TSMI_windows, Me.TSMI_tools, Me.TSMI_settings, Me.TSMI_about, Me.TSMI_hidden_tools})
        Me.ms_main.Location = New System.Drawing.Point(0, 0)
        Me.ms_main.Name = "ms_main"
        Me.ms_main.Size = New System.Drawing.Size(1054, 24)
        Me.ms_main.TabIndex = 4
        Me.ms_main.Text = "Menu Strip Main"
        '
        'TSMI_file
        '
        Me.TSMI_file.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_new, Me.TSS_1, Me.TSMI_open, Me.TSMI_recentFiles, Me.TSS_2, Me.TSMI_save, Me.TSMI_saveAll, Me.TSMI_saveAs, Me.TSS_3, Me.TSMI_close, Me.TSS_4, Me.TSMI_quit})
        Me.TSMI_file.Name = "TSMI_file"
        Me.TSMI_file.Size = New System.Drawing.Size(37, 20)
        Me.TSMI_file.Text = "File"
        '
        'TSMI_new
        '
        Me.TSMI_new.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_new
        Me.TSMI_new.Name = "TSMI_new"
        Me.TSMI_new.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.TSMI_new.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_new.Text = "New"
        '
        'TSS_1
        '
        Me.TSS_1.Name = "TSS_1"
        Me.TSS_1.Size = New System.Drawing.Size(245, 6)
        '
        'TSMI_open
        '
        Me.TSMI_open.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_open
        Me.TSMI_open.Name = "TSMI_open"
        Me.TSMI_open.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.TSMI_open.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_open.Text = "Open"
        '
        'TSMI_recentFiles
        '
        Me.TSMI_recentFiles.Enabled = False
        Me.TSMI_recentFiles.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_recent
        Me.TSMI_recentFiles.Name = "TSMI_recentFiles"
        Me.TSMI_recentFiles.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_recentFiles.Text = "Recent Files"
        '
        'TSS_2
        '
        Me.TSS_2.Name = "TSS_2"
        Me.TSS_2.Size = New System.Drawing.Size(245, 6)
        '
        'TSMI_save
        '
        Me.TSMI_save.Enabled = False
        Me.TSMI_save.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_save
        Me.TSMI_save.Name = "TSMI_save"
        Me.TSMI_save.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.TSMI_save.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_save.Text = "Save"
        '
        'TSMI_saveAll
        '
        Me.TSMI_saveAll.Enabled = False
        Me.TSMI_saveAll.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_save_all
        Me.TSMI_saveAll.Name = "TSMI_saveAll"
        Me.TSMI_saveAll.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_saveAll.Text = "Save All"
        '
        'TSMI_saveAs
        '
        Me.TSMI_saveAs.Enabled = False
        Me.TSMI_saveAs.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_save
        Me.TSMI_saveAs.Name = "TSMI_saveAs"
        Me.TSMI_saveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.TSMI_saveAs.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_saveAs.Text = "Save As..."
        '
        'TSS_3
        '
        Me.TSS_3.Name = "TSS_3"
        Me.TSS_3.Size = New System.Drawing.Size(245, 6)
        '
        'TSMI_close
        '
        Me.TSMI_close.Enabled = False
        Me.TSMI_close.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_close
        Me.TSMI_close.Name = "TSMI_close"
        Me.TSMI_close.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.TSMI_close.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_close.Text = "Close File"
        '
        'TSS_4
        '
        Me.TSS_4.Name = "TSS_4"
        Me.TSS_4.Size = New System.Drawing.Size(245, 6)
        '
        'TSMI_quit
        '
        Me.TSMI_quit.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_quit
        Me.TSMI_quit.Name = "TSMI_quit"
        Me.TSMI_quit.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_quit.Text = "Quit"
        '
        'TSMI_edit
        '
        Me.TSMI_edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_undo, Me.TSMI_redo, Me.TSS_5, Me.TSMI_cut, Me.TSMI_copy, Me.TSMI_paste, Me.TSMI_paste_cool, Me.TSMI_delete, Me.TSMI_selectAll, Me.TSS_7, Me.TSMI_expand, Me.TSMI_collapse})
        Me.TSMI_edit.Enabled = False
        Me.TSMI_edit.Name = "TSMI_edit"
        Me.TSMI_edit.Size = New System.Drawing.Size(39, 20)
        Me.TSMI_edit.Text = "Edit"
        '
        'TSMI_undo
        '
        Me.TSMI_undo.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_undo
        Me.TSMI_undo.Name = "TSMI_undo"
        Me.TSMI_undo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.TSMI_undo.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_undo.Text = "Undo"
        '
        'TSMI_redo
        '
        Me.TSMI_redo.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_redo
        Me.TSMI_redo.Name = "TSMI_redo"
        Me.TSMI_redo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.TSMI_redo.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_redo.Text = "Redo"
        '
        'TSS_5
        '
        Me.TSS_5.Name = "TSS_5"
        Me.TSS_5.Size = New System.Drawing.Size(297, 6)
        '
        'TSMI_cut
        '
        Me.TSMI_cut.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_cut
        Me.TSMI_cut.Name = "TSMI_cut"
        Me.TSMI_cut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.TSMI_cut.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_cut.Text = "Cut"
        '
        'TSMI_copy
        '
        Me.TSMI_copy.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_copy
        Me.TSMI_copy.Name = "TSMI_copy"
        Me.TSMI_copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.TSMI_copy.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_copy.Text = "Copy"
        '
        'TSMI_paste
        '
        Me.TSMI_paste.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste
        Me.TSMI_paste.Name = "TSMI_paste"
        Me.TSMI_paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.TSMI_paste.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_paste.Text = "Paste"
        '
        'TSMI_paste_cool
        '
        Me.TSMI_paste_cool.AutoToolTip = True
        Me.TSMI_paste_cool.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste_cool
        Me.TSMI_paste_cool.Name = "TSMI_paste_cool"
        Me.TSMI_paste_cool.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.TSMI_paste_cool.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_paste_cool.Text = "Paste && Adapts IDs"
        Me.TSMI_paste_cool.ToolTipText = "While pasting it changes the frame IDs to available IDs. Also changes the ""next"" " &
    "values."
        '
        'TSMI_delete
        '
        Me.TSMI_delete.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_delete
        Me.TSMI_delete.Name = "TSMI_delete"
        Me.TSMI_delete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.TSMI_delete.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_delete.Text = "Delete"
        '
        'TSMI_selectAll
        '
        Me.TSMI_selectAll.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_select_all
        Me.TSMI_selectAll.Name = "TSMI_selectAll"
        Me.TSMI_selectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.TSMI_selectAll.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_selectAll.Text = "Select All"
        '
        'TSS_7
        '
        Me.TSS_7.Name = "TSS_7"
        Me.TSS_7.Size = New System.Drawing.Size(297, 6)
        '
        'TSMI_expand
        '
        Me.TSMI_expand.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_expand
        Me.TSMI_expand.Name = "TSMI_expand"
        Me.TSMI_expand.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_expand.Text = "Expand All Foldings"
        '
        'TSMI_collapse
        '
        Me.TSMI_collapse.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_collapse
        Me.TSMI_collapse.Name = "TSMI_collapse"
        Me.TSMI_collapse.Size = New System.Drawing.Size(300, 22)
        Me.TSMI_collapse.Text = "Collapse All Foldings"
        '
        'TSMI_search
        '
        Me.TSMI_search.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_find, Me.TSMI_find_replace, Me.TSMI_find_again, Me.TSMI_find_again_reverse, Me.TSS_6, Me.TSMI_jump_to, Me.TSMI_jump, Me.TSMI_jump_frame})
        Me.TSMI_search.Enabled = False
        Me.TSMI_search.Name = "TSMI_search"
        Me.TSMI_search.Size = New System.Drawing.Size(54, 20)
        Me.TSMI_search.Text = "Search"
        '
        'TSMI_find
        '
        Me.TSMI_find.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_search
        Me.TSMI_find.Name = "TSMI_find"
        Me.TSMI_find.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.TSMI_find.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_find.Text = "Find..."
        '
        'TSMI_find_replace
        '
        Me.TSMI_find_replace.Name = "TSMI_find_replace"
        Me.TSMI_find_replace.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.TSMI_find_replace.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_find_replace.Text = "Find and replace..."
        '
        'TSMI_find_again
        '
        Me.TSMI_find_again.Name = "TSMI_find_again"
        Me.TSMI_find_again.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.TSMI_find_again.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_find_again.Text = "Find again"
        '
        'TSMI_find_again_reverse
        '
        Me.TSMI_find_again_reverse.Name = "TSMI_find_again_reverse"
        Me.TSMI_find_again_reverse.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.TSMI_find_again_reverse.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_find_again_reverse.Text = "Find again (reverse)"
        '
        'TSS_6
        '
        Me.TSS_6.Name = "TSS_6"
        Me.TSS_6.Size = New System.Drawing.Size(276, 6)
        '
        'TSMI_jump_to
        '
        Me.TSMI_jump_to.Name = "TSMI_jump_to"
        Me.TSMI_jump_to.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.TSMI_jump_to.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_jump_to.Text = "Jump to..."
        '
        'TSMI_jump
        '
        Me.TSMI_jump.Name = "TSMI_jump"
        Me.TSMI_jump.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.TSMI_jump.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_jump.Text = "Jump to Line..."
        Me.TSMI_jump.Visible = False
        '
        'TSMI_jump_frame
        '
        Me.TSMI_jump_frame.Name = "TSMI_jump_frame"
        Me.TSMI_jump_frame.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_jump_frame.Text = "Jump to Frame..."
        Me.TSMI_jump_frame.Visible = False
        '
        'TSMI_windows
        '
        Me.TSMI_windows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_frameViewer, Me.TSMI_unused_frames, Me.TSMI_error_list})
        Me.TSMI_windows.Name = "TSMI_windows"
        Me.TSMI_windows.Size = New System.Drawing.Size(63, 20)
        Me.TSMI_windows.Text = "Window"
        '
        'TSMI_frameViewer
        '
        Me.TSMI_frameViewer.Enabled = False
        Me.TSMI_frameViewer.Name = "TSMI_frameViewer"
        Me.TSMI_frameViewer.Size = New System.Drawing.Size(155, 22)
        Me.TSMI_frameViewer.Text = "Frame Viewer"
        '
        'TSMI_unused_frames
        '
        Me.TSMI_unused_frames.CheckOnClick = True
        Me.TSMI_unused_frames.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_free
        Me.TSMI_unused_frames.Name = "TSMI_unused_frames"
        Me.TSMI_unused_frames.Size = New System.Drawing.Size(155, 22)
        Me.TSMI_unused_frames.Text = "Unused Frames"
        '
        'TSMI_error_list
        '
        Me.TSMI_error_list.CheckOnClick = True
        Me.TSMI_error_list.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_error
        Me.TSMI_error_list.Name = "TSMI_error_list"
        Me.TSMI_error_list.Size = New System.Drawing.Size(155, 22)
        Me.TSMI_error_list.Text = "Error List"
        '
        'TSMI_tools
        '
        Me.TSMI_tools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_framesReformatting, Me.TSMI_mirrorFrame, Me.TSMI_tag_adder, Me.TSMI_ID_changer})
        Me.TSMI_tools.Name = "TSMI_tools"
        Me.TSMI_tools.Size = New System.Drawing.Size(47, 20)
        Me.TSMI_tools.Text = "Tools"
        '
        'TSMI_framesReformatting
        '
        Me.TSMI_framesReformatting.Name = "TSMI_framesReformatting"
        Me.TSMI_framesReformatting.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.TSMI_framesReformatting.Size = New System.Drawing.Size(287, 22)
        Me.TSMI_framesReformatting.Text = "Frames Reformatting"
        '
        'TSMI_mirrorFrame
        '
        Me.TSMI_mirrorFrame.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_mirror
        Me.TSMI_mirrorFrame.Name = "TSMI_mirrorFrame"
        Me.TSMI_mirrorFrame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.TSMI_mirrorFrame.Size = New System.Drawing.Size(287, 22)
        Me.TSMI_mirrorFrame.Text = "Mirror Frame (with data)"
        '
        'TSMI_tag_adder
        '
        Me.TSMI_tag_adder.Name = "TSMI_tag_adder"
        Me.TSMI_tag_adder.Size = New System.Drawing.Size(287, 22)
        Me.TSMI_tag_adder.Text = "Tag Adder (Frames must selected)"
        Me.TSMI_tag_adder.ToolTipText = "Adds to all selected frames a custom tag."
        '
        'TSMI_ID_changer
        '
        Me.TSMI_ID_changer.Name = "TSMI_ID_changer"
        Me.TSMI_ID_changer.Size = New System.Drawing.Size(287, 22)
        Me.TSMI_ID_changer.Text = "Auto ID Changer (Frames must selected)"
        '
        'TSMI_settings
        '
        Me.TSMI_settings.Name = "TSMI_settings"
        Me.TSMI_settings.Size = New System.Drawing.Size(61, 20)
        Me.TSMI_settings.Text = "Settings"
        '
        'TSMI_about
        '
        Me.TSMI_about.Name = "TSMI_about"
        Me.TSMI_about.Size = New System.Drawing.Size(52, 20)
        Me.TSMI_about.Text = "About"
        '
        'TSMI_hidden_tools
        '
        Me.TSMI_hidden_tools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_hT_frameViewer})
        Me.TSMI_hidden_tools.Name = "TSMI_hidden_tools"
        Me.TSMI_hidden_tools.Size = New System.Drawing.Size(89, 20)
        Me.TSMI_hidden_tools.Text = "Hidden Tools"
        Me.TSMI_hidden_tools.Visible = False
        '
        'TSMI_hT_frameViewer
        '
        Me.TSMI_hT_frameViewer.Name = "TSMI_hT_frameViewer"
        Me.TSMI_hT_frameViewer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.TSMI_hT_frameViewer.Size = New System.Drawing.Size(315, 22)
        Me.TSMI_hT_frameViewer.Text = "Show Frame Viewer from Current File"
        '
        'ofd_data
        '
        Me.ofd_data.Filter = "LF2-Data File|*.dat"
        Me.ofd_data.Multiselect = True
        '
        'index
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 549)
        Me.Controls.Add(Me.dockpan_main)
        Me.Controls.Add(Me.ss_infos)
        Me.Controls.Add(Me.ms_icons)
        Me.Controls.Add(Me.ms_main)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.ms_icons
        Me.MinimumSize = New System.Drawing.Size(750, 400)
        Me.Name = "index"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor (STM93 Version)"
        Me.ms_icons.ResumeLayout(False)
        Me.ms_icons.PerformLayout()
        Me.ss_infos.ResumeLayout(False)
        Me.ss_infos.PerformLayout()
        Me.ms_main.ResumeLayout(False)
        Me.ms_main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ms_icons As MenuStrip
    Friend WithEvents ss_infos As StatusStrip
    Friend WithEvents dockpan_main As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents ms_main As MenuStrip
    Friend WithEvents TSMI_file As ToolStripMenuItem
    Friend WithEvents TSMI_edit As ToolStripMenuItem
    Friend WithEvents TSMI_search As ToolStripMenuItem
    Friend WithEvents TSMI_windows As ToolStripMenuItem
    Friend WithEvents TSMI_about As ToolStripMenuItem
    Friend WithEvents TSMI_new As ToolStripMenuItem
    Friend WithEvents TSS_1 As ToolStripSeparator
    Friend WithEvents TSMI_open As ToolStripMenuItem
    Friend WithEvents TSMI_recentFiles As ToolStripMenuItem
    Friend WithEvents TSS_2 As ToolStripSeparator
    Friend WithEvents TSMI_save As ToolStripMenuItem
    Friend WithEvents TSMI_saveAll As ToolStripMenuItem
    Friend WithEvents TSMI_saveAs As ToolStripMenuItem
    Friend WithEvents TSS_3 As ToolStripSeparator
    Friend WithEvents TSMI_close As ToolStripMenuItem
    Friend WithEvents TSS_4 As ToolStripSeparator
    Friend WithEvents TSMI_quit As ToolStripMenuItem
    Friend WithEvents TSMI_icon_new As ToolStripMenuItem
    Friend WithEvents TSMI_icon_open As ToolStripMenuItem
    Friend WithEvents TSMI_icon_save As ToolStripMenuItem
    Friend WithEvents TSMI_icon_saveAll As ToolStripMenuItem
    Friend WithEvents TSMI_icon_undo As ToolStripMenuItem
    Friend WithEvents TSMI_icon_redo As ToolStripMenuItem
    Friend WithEvents TSMI_icon_close As ToolStripMenuItem
    Friend WithEvents ofd_data As OpenFileDialog
    Friend WithEvents TSMI_frameViewer As ToolStripMenuItem
    Friend WithEvents TSMI_undo As ToolStripMenuItem
    Friend WithEvents TSMI_redo As ToolStripMenuItem
    Friend WithEvents TSS_5 As ToolStripSeparator
    Friend WithEvents TSMI_cut As ToolStripMenuItem
    Friend WithEvents TSMI_copy As ToolStripMenuItem
    Friend WithEvents TSMI_paste As ToolStripMenuItem
    Friend WithEvents TSMI_delete As ToolStripMenuItem
    Friend WithEvents TSMI_selectAll As ToolStripMenuItem
    Friend WithEvents TSMI_unused_frames As ToolStripMenuItem
    Friend WithEvents TSMI_error_list As ToolStripMenuItem
    Friend WithEvents TSMI_settings As ToolStripMenuItem
    Friend WithEvents TSMI_find As ToolStripMenuItem
    Friend WithEvents TSMI_find_replace As ToolStripMenuItem
    Friend WithEvents TSMI_find_again As ToolStripMenuItem
    Friend WithEvents TSMI_find_again_reverse As ToolStripMenuItem
    Friend WithEvents TSMI_jump As ToolStripMenuItem
    Friend WithEvents TSMI_jump_frame As ToolStripMenuItem
    Friend WithEvents TSS_6 As ToolStripSeparator
    Friend WithEvents TSMI_jump_to As ToolStripMenuItem
    Friend WithEvents TSMI_tools As ToolStripMenuItem
    Friend WithEvents TSMI_framesReformatting As ToolStripMenuItem
    Friend WithEvents TSMI_mirrorFrame As ToolStripMenuItem
    Friend WithEvents TSSL_copyright As ToolStripStatusLabel
    Friend WithEvents link_cookiesoft As ToolStripStatusLabel
    Friend WithEvents TSS_7 As ToolStripSeparator
    Friend WithEvents TSMI_expand As ToolStripMenuItem
    Friend WithEvents TSMI_collapse As ToolStripMenuItem
    Friend WithEvents TSMI_paste_cool As ToolStripMenuItem
    Friend WithEvents TSMI_hidden_tools As ToolStripMenuItem
    Friend WithEvents TSMI_hT_frameViewer As ToolStripMenuItem
    Friend WithEvents TSMI_tag_adder As ToolStripMenuItem
    Friend WithEvents TSMI_ID_changer As ToolStripMenuItem
End Class
