<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits Translation.TranslatableForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MS_Icons = New System.Windows.Forms.MenuStrip()
        Me.TSMI_icon_new = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_open = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_saveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_undo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_icon_redo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSComb_frames = New System.Windows.Forms.ToolStripComboBox()
        Me.TSComb_lf = New System.Windows.Forms.ToolStripComboBox()
        Me.TSMI_run = New System.Windows.Forms.ToolStripMenuItem()
        Me.SS_Infos = New System.Windows.Forms.StatusStrip()
        Me.TSSL_textLength = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_textLengthVal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_textLines = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_textLinesVal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_copyright = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Link_Cookiesoft = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DockPan_Main = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.MS_Main = New System.Windows.Forms.MenuStrip()
        Me.TSMI_file = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_new = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_open = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_recentFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_saveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_saveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_export = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_closeAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_quit = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEBUG_DO_ERRORS = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_undo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_redo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_pasteCool = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_selectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_expand = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_collapse = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_search = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_find = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_findAgain = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_findAgainReverse = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_replace = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_replaceAgain = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_replaceAgainReverse = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_12 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_mark = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_findMulti = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_10 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_goTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_goToLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_goToFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_11 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_bookmark = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_toggleBookmark = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_nextBookmark = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_previousBookmark = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_clearBookmarks = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_cutBookmarkedLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_copyBookmarkedLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_pasteBookmarkedLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_removeBookmarkedLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_removeUnmarkedLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_inverseBookmark = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_view = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_lineNumbers = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_markLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_whitespaces = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_hSplit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_vSplit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_wrap = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSComb_WrapMode = New System.Windows.Forms.ToolStripComboBox()
        Me.TSMI_windows = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_frameViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_unusedIDs = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_errorList = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_framesReformatting = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_mirrorFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_tagAdder = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_IDChanger = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_sort = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_setOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_8 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_equation_center = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_bodies = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_itrs = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_bpoi = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_cpoi = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_opoi = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_wpoi = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_wait = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_state = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_next = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_equation_hit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_9 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_equation_apply = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_hidden_tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_hT_frameViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEBUG_BeginUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEBUG_EndUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_toggleBSprite = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ofd_Data = New System.Windows.Forms.OpenFileDialog()
        Me.Sfd_HTML = New System.Windows.Forms.SaveFileDialog()
        Me.TSMI_hT_nextFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_hT_previousFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_Icons.SuspendLayout()
        Me.SS_Infos.SuspendLayout()
        Me.MS_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'MS_Icons
        '
        Me.MS_Icons.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.MS_Icons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_icon_new, Me.TSMI_icon_open, Me.TSMI_icon_save, Me.TSMI_icon_saveAll, Me.TSMI_icon_close, Me.TSMI_icon_undo, Me.TSMI_icon_redo, Me.TSComb_frames, Me.TSComb_lf, Me.TSMI_run})
        Me.MS_Icons.Location = New System.Drawing.Point(0, 24)
        Me.MS_Icons.Name = "MS_Icons"
        Me.MS_Icons.Size = New System.Drawing.Size(1054, 27)
        Me.MS_Icons.TabIndex = 0
        Me.MS_Icons.Text = "Icons"
        '
        'TSMI_icon_new
        '
        Me.TSMI_icon_new.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_new
        Me.TSMI_icon_new.Name = "TSMI_icon_new"
        Me.TSMI_icon_new.Size = New System.Drawing.Size(28, 23)
        '
        'TSMI_icon_open
        '
        Me.TSMI_icon_open.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_open
        Me.TSMI_icon_open.Name = "TSMI_icon_open"
        Me.TSMI_icon_open.Size = New System.Drawing.Size(28, 23)
        '
        'TSMI_icon_save
        '
        Me.TSMI_icon_save.Enabled = False
        Me.TSMI_icon_save.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_save
        Me.TSMI_icon_save.Name = "TSMI_icon_save"
        Me.TSMI_icon_save.Size = New System.Drawing.Size(28, 23)
        '
        'TSMI_icon_saveAll
        '
        Me.TSMI_icon_saveAll.Enabled = False
        Me.TSMI_icon_saveAll.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_save_all
        Me.TSMI_icon_saveAll.Name = "TSMI_icon_saveAll"
        Me.TSMI_icon_saveAll.Size = New System.Drawing.Size(28, 23)
        '
        'TSMI_icon_close
        '
        Me.TSMI_icon_close.Enabled = False
        Me.TSMI_icon_close.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_close
        Me.TSMI_icon_close.Name = "TSMI_icon_close"
        Me.TSMI_icon_close.Size = New System.Drawing.Size(28, 23)
        '
        'TSMI_icon_undo
        '
        Me.TSMI_icon_undo.Enabled = False
        Me.TSMI_icon_undo.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_undo
        Me.TSMI_icon_undo.Name = "TSMI_icon_undo"
        Me.TSMI_icon_undo.Size = New System.Drawing.Size(28, 23)
        '
        'TSMI_icon_redo
        '
        Me.TSMI_icon_redo.Enabled = False
        Me.TSMI_icon_redo.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_redo
        Me.TSMI_icon_redo.Name = "TSMI_icon_redo"
        Me.TSMI_icon_redo.Size = New System.Drawing.Size(28, 23)
        '
        'TSComb_frames
        '
        Me.TSComb_frames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TSComb_frames.Name = "TSComb_frames"
        Me.TSComb_frames.Size = New System.Drawing.Size(130, 23)
        '
        'TSComb_lf
        '
        Me.TSComb_lf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TSComb_lf.Margin = New System.Windows.Forms.Padding(32, 0, 1, 0)
        Me.TSComb_lf.Name = "TSComb_lf"
        Me.TSComb_lf.Size = New System.Drawing.Size(200, 23)
        '
        'TSMI_run
        '
        Me.TSMI_run.Enabled = False
        Me.TSMI_run.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_start
        Me.TSMI_run.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TSMI_run.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TSMI_run.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.TSMI_run.Name = "TSMI_run"
        Me.TSMI_run.Padding = New System.Windows.Forms.Padding(20, 0, 10, 0)
        Me.TSMI_run.Size = New System.Drawing.Size(85, 23)
        Me.TSMI_run.Text = "   Run"
        '
        'SS_Infos
        '
        Me.SS_Infos.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.SS_Infos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_textLength, Me.TSSL_textLengthVal, Me.TSSL_textLines, Me.TSSL_textLinesVal, Me.TSSL_copyright, Me.Link_Cookiesoft})
        Me.SS_Infos.Location = New System.Drawing.Point(0, 527)
        Me.SS_Infos.Name = "SS_Infos"
        Me.SS_Infos.Size = New System.Drawing.Size(1054, 22)
        Me.SS_Infos.TabIndex = 1
        '
        'TSSL_textLength
        '
        Me.TSSL_textLength.Name = "TSSL_textLength"
        Me.TSSL_textLength.Size = New System.Drawing.Size(738, 17)
        Me.TSSL_textLength.Spring = True
        Me.TSSL_textLength.Text = "Text Length:"
        Me.TSSL_textLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TSSL_textLengthVal
        '
        Me.TSSL_textLengthVal.Name = "TSSL_textLengthVal"
        Me.TSSL_textLengthVal.Padding = New System.Windows.Forms.Padding(0, 0, 24, 0)
        Me.TSSL_textLengthVal.Size = New System.Drawing.Size(37, 17)
        Me.TSSL_textLengthVal.Text = "0"
        Me.TSSL_textLengthVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSL_textLines
        '
        Me.TSSL_textLines.Name = "TSSL_textLines"
        Me.TSSL_textLines.Size = New System.Drawing.Size(37, 17)
        Me.TSSL_textLines.Text = "Lines:"
        '
        'TSSL_textLinesVal
        '
        Me.TSSL_textLinesVal.Name = "TSSL_textLinesVal"
        Me.TSSL_textLinesVal.Size = New System.Drawing.Size(13, 17)
        Me.TSSL_textLinesVal.Text = "0"
        '
        'TSSL_copyright
        '
        Me.TSSL_copyright.AutoSize = False
        Me.TSSL_copyright.Name = "TSSL_copyright"
        Me.TSSL_copyright.Size = New System.Drawing.Size(150, 17)
        Me.TSSL_copyright.Text = "Copyright of:"
        Me.TSSL_copyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Link_Cookiesoft
        '
        Me.Link_Cookiesoft.IsLink = True
        Me.Link_Cookiesoft.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.Link_Cookiesoft.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Link_Cookiesoft.Name = "Link_Cookiesoft"
        Me.Link_Cookiesoft.Size = New System.Drawing.Size(64, 17)
        Me.Link_Cookiesoft.Text = "Cookiesoft"
        Me.Link_Cookiesoft.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'DockPan_Main
        '
        Me.DockPan_Main.AllowDrop = True
        Me.DockPan_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPan_Main.Location = New System.Drawing.Point(0, 51)
        Me.DockPan_Main.Name = "DockPan_Main"
        Me.DockPan_Main.Size = New System.Drawing.Size(1054, 476)
        Me.DockPan_Main.TabIndex = 2
        '
        'MS_Main
        '
        Me.MS_Main.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.MS_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_file, Me.TSMI_edit, Me.TSMI_search, Me.TSMI_view, Me.TSMI_windows, Me.TSMI_tools, Me.TSMI_settings, Me.TSMI_about, Me.TSMI_hidden_tools})
        Me.MS_Main.Location = New System.Drawing.Point(0, 0)
        Me.MS_Main.Name = "MS_Main"
        Me.MS_Main.Size = New System.Drawing.Size(1054, 24)
        Me.MS_Main.TabIndex = 4
        Me.MS_Main.Text = "Menu Strip Main"
        '
        'TSMI_file
        '
        Me.TSMI_file.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_new, Me.TSS_1, Me.TSMI_open, Me.TSMI_recentFiles, Me.TSS_2, Me.TSMI_save, Me.TSMI_saveAll, Me.TSMI_saveAs, Me.TSMI_export, Me.TSS_3, Me.TSMI_close, Me.TSMI_closeAll, Me.TSS_4, Me.TSMI_quit, Me.DEBUG_DO_ERRORS})
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
        'TSMI_export
        '
        Me.TSMI_export.Enabled = False
        Me.TSMI_export.Name = "TSMI_export"
        Me.TSMI_export.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_export.Text = "Export to HTML"
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
        'TSMI_closeAll
        '
        Me.TSMI_closeAll.Name = "TSMI_closeAll"
        Me.TSMI_closeAll.Size = New System.Drawing.Size(248, 22)
        Me.TSMI_closeAll.Text = "Close All Files"
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
        'DEBUG_DO_ERRORS
        '
        Me.DEBUG_DO_ERRORS.Name = "DEBUG_DO_ERRORS"
        Me.DEBUG_DO_ERRORS.Size = New System.Drawing.Size(248, 22)
        Me.DEBUG_DO_ERRORS.Text = "Throw Error"
        '
        'TSMI_edit
        '
        Me.TSMI_edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_undo, Me.TSMI_redo, Me.TSS_5, Me.TSMI_cut, Me.TSMI_copy, Me.TSMI_paste, Me.TSMI_pasteCool, Me.TSMI_delete, Me.TSMI_selectAll, Me.TSS_7, Me.TSMI_expand, Me.TSMI_collapse})
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
        Me.TSMI_undo.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_undo.Text = "Undo"
        '
        'TSMI_redo
        '
        Me.TSMI_redo.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_redo
        Me.TSMI_redo.Name = "TSMI_redo"
        Me.TSMI_redo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.TSMI_redo.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_redo.Text = "Redo"
        '
        'TSS_5
        '
        Me.TSS_5.Name = "TSS_5"
        Me.TSS_5.Size = New System.Drawing.Size(292, 6)
        '
        'TSMI_cut
        '
        Me.TSMI_cut.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_cut
        Me.TSMI_cut.Name = "TSMI_cut"
        Me.TSMI_cut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.TSMI_cut.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_cut.Text = "Cut"
        '
        'TSMI_copy
        '
        Me.TSMI_copy.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_copy
        Me.TSMI_copy.Name = "TSMI_copy"
        Me.TSMI_copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.TSMI_copy.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_copy.Text = "Copy"
        '
        'TSMI_paste
        '
        Me.TSMI_paste.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste
        Me.TSMI_paste.Name = "TSMI_paste"
        Me.TSMI_paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.TSMI_paste.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_paste.Text = "Paste"
        '
        'TSMI_pasteCool
        '
        Me.TSMI_pasteCool.AutoToolTip = True
        Me.TSMI_pasteCool.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste_cool
        Me.TSMI_pasteCool.Name = "TSMI_pasteCool"
        Me.TSMI_pasteCool.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.TSMI_pasteCool.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_pasteCool.Text = "Paste && Adapt IDs"
        Me.TSMI_pasteCool.ToolTipText = "While pasting it changes the frame IDs to available IDs. Also changes the ""next"" " &
    "values."
        '
        'TSMI_delete
        '
        Me.TSMI_delete.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_delete
        Me.TSMI_delete.Name = "TSMI_delete"
        Me.TSMI_delete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.TSMI_delete.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_delete.Text = "Delete"
        '
        'TSMI_selectAll
        '
        Me.TSMI_selectAll.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_select_all
        Me.TSMI_selectAll.Name = "TSMI_selectAll"
        Me.TSMI_selectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.TSMI_selectAll.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_selectAll.Text = "Select All"
        '
        'TSS_7
        '
        Me.TSS_7.Name = "TSS_7"
        Me.TSS_7.Size = New System.Drawing.Size(292, 6)
        '
        'TSMI_expand
        '
        Me.TSMI_expand.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_expand
        Me.TSMI_expand.Name = "TSMI_expand"
        Me.TSMI_expand.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_expand.Text = "Expand All Foldings"
        '
        'TSMI_collapse
        '
        Me.TSMI_collapse.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_collapse
        Me.TSMI_collapse.Name = "TSMI_collapse"
        Me.TSMI_collapse.Size = New System.Drawing.Size(295, 22)
        Me.TSMI_collapse.Text = "Collapse All Foldings"
        '
        'TSMI_search
        '
        Me.TSMI_search.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_find, Me.TSMI_findAgain, Me.TSMI_findAgainReverse, Me.TSS_6, Me.TSMI_replace, Me.TSMI_replaceAgain, Me.TSMI_replaceAgainReverse, Me.TSS_12, Me.TSMI_mark, Me.TSMI_findMulti, Me.TSS_10, Me.TSMI_goTo, Me.TSMI_goToLine, Me.TSMI_goToFrame, Me.TSS_11, Me.TSMI_bookmark})
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
        'TSMI_findAgain
        '
        Me.TSMI_findAgain.Name = "TSMI_findAgain"
        Me.TSMI_findAgain.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.TSMI_findAgain.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_findAgain.Text = "Find again"
        '
        'TSMI_findAgainReverse
        '
        Me.TSMI_findAgainReverse.Name = "TSMI_findAgainReverse"
        Me.TSMI_findAgainReverse.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.TSMI_findAgainReverse.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_findAgainReverse.Text = "Find again (reverse)"
        '
        'TSS_6
        '
        Me.TSS_6.Name = "TSS_6"
        Me.TSS_6.Size = New System.Drawing.Size(276, 6)
        '
        'TSMI_replace
        '
        Me.TSMI_replace.Name = "TSMI_replace"
        Me.TSMI_replace.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.TSMI_replace.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_replace.Text = "Replace..."
        '
        'TSMI_replaceAgain
        '
        Me.TSMI_replaceAgain.Name = "TSMI_replaceAgain"
        Me.TSMI_replaceAgain.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_replaceAgain.Text = "Replace again"
        '
        'TSMI_replaceAgainReverse
        '
        Me.TSMI_replaceAgainReverse.Name = "TSMI_replaceAgainReverse"
        Me.TSMI_replaceAgainReverse.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_replaceAgainReverse.Text = "Replace again (reverse)"
        '
        'TSS_12
        '
        Me.TSS_12.Name = "TSS_12"
        Me.TSS_12.Size = New System.Drawing.Size(276, 6)
        '
        'TSMI_mark
        '
        Me.TSMI_mark.Name = "TSMI_mark"
        Me.TSMI_mark.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_mark.Text = "Mark"
        '
        'TSMI_findMulti
        '
        Me.TSMI_findMulti.Name = "TSMI_findMulti"
        Me.TSMI_findMulti.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_findMulti.Text = "Multi Find and Replace"
        Me.TSMI_findMulti.Visible = False
        '
        'TSS_10
        '
        Me.TSS_10.Name = "TSS_10"
        Me.TSS_10.Size = New System.Drawing.Size(276, 6)
        '
        'TSMI_goTo
        '
        Me.TSMI_goTo.Name = "TSMI_goTo"
        Me.TSMI_goTo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.TSMI_goTo.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_goTo.Text = "Go to..."
        '
        'TSMI_goToLine
        '
        Me.TSMI_goToLine.Name = "TSMI_goToLine"
        Me.TSMI_goToLine.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.TSMI_goToLine.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_goToLine.Text = "Go to Line..."
        '
        'TSMI_goToFrame
        '
        Me.TSMI_goToFrame.Name = "TSMI_goToFrame"
        Me.TSMI_goToFrame.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_goToFrame.Text = "Go to Frame..."
        '
        'TSS_11
        '
        Me.TSS_11.Name = "TSS_11"
        Me.TSS_11.Size = New System.Drawing.Size(276, 6)
        '
        'TSMI_bookmark
        '
        Me.TSMI_bookmark.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_toggleBookmark, Me.TSMI_nextBookmark, Me.TSMI_previousBookmark, Me.TSMI_clearBookmarks, Me.TSMI_cutBookmarkedLines, Me.TSMI_copyBookmarkedLines, Me.TSMI_pasteBookmarkedLines, Me.TSMI_removeBookmarkedLines, Me.TSMI_removeUnmarkedLines, Me.TSMI_inverseBookmark})
        Me.TSMI_bookmark.Name = "TSMI_bookmark"
        Me.TSMI_bookmark.Size = New System.Drawing.Size(279, 22)
        Me.TSMI_bookmark.Text = "Bookmark"
        '
        'TSMI_toggleBookmark
        '
        Me.TSMI_toggleBookmark.Name = "TSMI_toggleBookmark"
        Me.TSMI_toggleBookmark.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
        Me.TSMI_toggleBookmark.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_toggleBookmark.Text = "Toggle Bookmark"
        '
        'TSMI_nextBookmark
        '
        Me.TSMI_nextBookmark.Name = "TSMI_nextBookmark"
        Me.TSMI_nextBookmark.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.TSMI_nextBookmark.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_nextBookmark.Text = "Next Bookmark"
        '
        'TSMI_previousBookmark
        '
        Me.TSMI_previousBookmark.Name = "TSMI_previousBookmark"
        Me.TSMI_previousBookmark.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
        Me.TSMI_previousBookmark.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_previousBookmark.Text = "Previous Bookmark"
        '
        'TSMI_clearBookmarks
        '
        Me.TSMI_clearBookmarks.Name = "TSMI_clearBookmarks"
        Me.TSMI_clearBookmarks.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_clearBookmarks.Text = "Clear All Bookmarks"
        '
        'TSMI_cutBookmarkedLines
        '
        Me.TSMI_cutBookmarkedLines.Name = "TSMI_cutBookmarkedLines"
        Me.TSMI_cutBookmarkedLines.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_cutBookmarkedLines.Text = "Cut Bookmarked Lines"
        '
        'TSMI_copyBookmarkedLines
        '
        Me.TSMI_copyBookmarkedLines.Name = "TSMI_copyBookmarkedLines"
        Me.TSMI_copyBookmarkedLines.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_copyBookmarkedLines.Text = "Copy Bookmarked Lines"
        '
        'TSMI_pasteBookmarkedLines
        '
        Me.TSMI_pasteBookmarkedLines.Name = "TSMI_pasteBookmarkedLines"
        Me.TSMI_pasteBookmarkedLines.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_pasteBookmarkedLines.Text = "Paste to (Replace) Bookmarked Lines"
        '
        'TSMI_removeBookmarkedLines
        '
        Me.TSMI_removeBookmarkedLines.Name = "TSMI_removeBookmarkedLines"
        Me.TSMI_removeBookmarkedLines.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_removeBookmarkedLines.Text = "Remove Bookmarked Lines"
        '
        'TSMI_removeUnmarkedLines
        '
        Me.TSMI_removeUnmarkedLines.Name = "TSMI_removeUnmarkedLines"
        Me.TSMI_removeUnmarkedLines.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_removeUnmarkedLines.Text = "Remove Unmarked Lines"
        '
        'TSMI_inverseBookmark
        '
        Me.TSMI_inverseBookmark.Name = "TSMI_inverseBookmark"
        Me.TSMI_inverseBookmark.Size = New System.Drawing.Size(278, 22)
        Me.TSMI_inverseBookmark.Text = "Inverse Bookmark"
        '
        'TSMI_view
        '
        Me.TSMI_view.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_lineNumbers, Me.TSMI_markLine, Me.TSMI_whitespaces, Me.TSMI_hSplit, Me.TSMI_vSplit, Me.TSMI_wrap})
        Me.TSMI_view.Enabled = False
        Me.TSMI_view.Name = "TSMI_view"
        Me.TSMI_view.Size = New System.Drawing.Size(44, 20)
        Me.TSMI_view.Text = "View"
        '
        'TSMI_lineNumbers
        '
        Me.TSMI_lineNumbers.CheckOnClick = True
        Me.TSMI_lineNumbers.Name = "TSMI_lineNumbers"
        Me.TSMI_lineNumbers.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_lineNumbers.Text = "Show Line Numbers"
        '
        'TSMI_markLine
        '
        Me.TSMI_markLine.CheckOnClick = True
        Me.TSMI_markLine.Name = "TSMI_markLine"
        Me.TSMI_markLine.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_markLine.Text = "Mark Current Line"
        '
        'TSMI_whitespaces
        '
        Me.TSMI_whitespaces.CheckOnClick = True
        Me.TSMI_whitespaces.Name = "TSMI_whitespaces"
        Me.TSMI_whitespaces.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_whitespaces.Text = "Show Whitespaces"
        '
        'TSMI_hSplit
        '
        Me.TSMI_hSplit.CheckOnClick = True
        Me.TSMI_hSplit.Name = "TSMI_hSplit"
        Me.TSMI_hSplit.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_hSplit.Text = "Split View (<->)"
        '
        'TSMI_vSplit
        '
        Me.TSMI_vSplit.CheckOnClick = True
        Me.TSMI_vSplit.Name = "TSMI_vSplit"
        Me.TSMI_vSplit.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_vSplit.Text = "Split View"
        '
        'TSMI_wrap
        '
        Me.TSMI_wrap.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSComb_WrapMode})
        Me.TSMI_wrap.Name = "TSMI_wrap"
        Me.TSMI_wrap.Size = New System.Drawing.Size(180, 22)
        Me.TSMI_wrap.Text = "Wrap"
        '
        'TSComb_WrapMode
        '
        Me.TSComb_WrapMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TSComb_WrapMode.DropDownWidth = 230
        Me.TSComb_WrapMode.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.TSComb_WrapMode.Items.AddRange(New Object() {"None", "Word", "Char", "Whitespace"})
        Me.TSComb_WrapMode.Name = "TSComb_WrapMode"
        Me.TSComb_WrapMode.Size = New System.Drawing.Size(180, 23)
        '
        'TSMI_windows
        '
        Me.TSMI_windows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_frameViewer, Me.TSMI_unusedIDs, Me.TSMI_errorList})
        Me.TSMI_windows.Name = "TSMI_windows"
        Me.TSMI_windows.Size = New System.Drawing.Size(63, 20)
        Me.TSMI_windows.Text = "Window"
        '
        'TSMI_frameViewer
        '
        Me.TSMI_frameViewer.Enabled = False
        Me.TSMI_frameViewer.Name = "TSMI_frameViewer"
        Me.TSMI_frameViewer.Size = New System.Drawing.Size(145, 22)
        Me.TSMI_frameViewer.Text = "Frame Viewer"
        '
        'TSMI_unusedIDs
        '
        Me.TSMI_unusedIDs.CheckOnClick = True
        Me.TSMI_unusedIDs.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_free
        Me.TSMI_unusedIDs.Name = "TSMI_unusedIDs"
        Me.TSMI_unusedIDs.Size = New System.Drawing.Size(145, 22)
        Me.TSMI_unusedIDs.Text = "Unused IDs"
        '
        'TSMI_errorList
        '
        Me.TSMI_errorList.CheckOnClick = True
        Me.TSMI_errorList.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_error
        Me.TSMI_errorList.Name = "TSMI_errorList"
        Me.TSMI_errorList.Size = New System.Drawing.Size(145, 22)
        Me.TSMI_errorList.Text = "Error List"
        '
        'TSMI_tools
        '
        Me.TSMI_tools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_framesReformatting, Me.TSMI_mirrorFrame, Me.TSMI_tagAdder, Me.TSMI_IDChanger, Me.TSMI_sort, Me.TSMI_equation})
        Me.TSMI_tools.Name = "TSMI_tools"
        Me.TSMI_tools.Size = New System.Drawing.Size(46, 20)
        Me.TSMI_tools.Text = "Tools"
        '
        'TSMI_framesReformatting
        '
        Me.TSMI_framesReformatting.Name = "TSMI_framesReformatting"
        Me.TSMI_framesReformatting.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.TSMI_framesReformatting.Size = New System.Drawing.Size(327, 22)
        Me.TSMI_framesReformatting.Text = "Frames Reformatting"
        '
        'TSMI_mirrorFrame
        '
        Me.TSMI_mirrorFrame.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_mirror
        Me.TSMI_mirrorFrame.Name = "TSMI_mirrorFrame"
        Me.TSMI_mirrorFrame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.TSMI_mirrorFrame.Size = New System.Drawing.Size(327, 22)
        Me.TSMI_mirrorFrame.Text = "Mirror Frame (with data)"
        '
        'TSMI_tagAdder
        '
        Me.TSMI_tagAdder.Name = "TSMI_tagAdder"
        Me.TSMI_tagAdder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.TSMI_tagAdder.Size = New System.Drawing.Size(327, 22)
        Me.TSMI_tagAdder.Text = "Tag Adder (Frames must selected)"
        Me.TSMI_tagAdder.ToolTipText = "Adds to all selected frames a custom tag."
        '
        'TSMI_IDChanger
        '
        Me.TSMI_IDChanger.Name = "TSMI_IDChanger"
        Me.TSMI_IDChanger.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.TSMI_IDChanger.Size = New System.Drawing.Size(327, 22)
        Me.TSMI_IDChanger.Text = "Auto ID Changer (Frames must selected)"
        '
        'TSMI_sort
        '
        Me.TSMI_sort.Name = "TSMI_sort"
        Me.TSMI_sort.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.TSMI_sort.Size = New System.Drawing.Size(327, 22)
        Me.TSMI_sort.Text = "Sort Frames by Frame ID"
        '
        'TSMI_equation
        '
        Me.TSMI_equation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_equation_setOptions, Me.TSS_8, Me.TSMI_equation_center, Me.TSMI_equation_bodies, Me.TSMI_equation_itrs, Me.TSMI_equation_bpoi, Me.TSMI_equation_cpoi, Me.TSMI_equation_opoi, Me.TSMI_equation_wpoi, Me.TSMI_equation_wait, Me.TSMI_equation_state, Me.TSMI_equation_next, Me.TSMI_equation_hit, Me.TSS_9, Me.TSMI_equation_apply})
        Me.TSMI_equation.Name = "TSMI_equation"
        Me.TSMI_equation.Size = New System.Drawing.Size(327, 22)
        Me.TSMI_equation.Text = "Set Values to All Frames with Same Pic ID"
        '
        'TSMI_equation_setOptions
        '
        Me.TSMI_equation_setOptions.Enabled = False
        Me.TSMI_equation_setOptions.Name = "TSMI_equation_setOptions"
        Me.TSMI_equation_setOptions.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_setOptions.Text = "Set Options"
        '
        'TSS_8
        '
        Me.TSS_8.Name = "TSS_8"
        Me.TSS_8.Size = New System.Drawing.Size(228, 6)
        '
        'TSMI_equation_center
        '
        Me.TSMI_equation_center.Checked = True
        Me.TSMI_equation_center.CheckOnClick = True
        Me.TSMI_equation_center.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_equation_center.Name = "TSMI_equation_center"
        Me.TSMI_equation_center.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_center.Text = "Center X/Y"
        '
        'TSMI_equation_bodies
        '
        Me.TSMI_equation_bodies.Checked = True
        Me.TSMI_equation_bodies.CheckOnClick = True
        Me.TSMI_equation_bodies.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_equation_bodies.Name = "TSMI_equation_bodies"
        Me.TSMI_equation_bodies.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_bodies.Text = "Bodies"
        '
        'TSMI_equation_itrs
        '
        Me.TSMI_equation_itrs.Checked = True
        Me.TSMI_equation_itrs.CheckOnClick = True
        Me.TSMI_equation_itrs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_equation_itrs.Name = "TSMI_equation_itrs"
        Me.TSMI_equation_itrs.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_itrs.Text = "Itrs"
        '
        'TSMI_equation_bpoi
        '
        Me.TSMI_equation_bpoi.Checked = True
        Me.TSMI_equation_bpoi.CheckOnClick = True
        Me.TSMI_equation_bpoi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_equation_bpoi.Name = "TSMI_equation_bpoi"
        Me.TSMI_equation_bpoi.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_bpoi.Text = "BPoint"
        '
        'TSMI_equation_cpoi
        '
        Me.TSMI_equation_cpoi.Checked = True
        Me.TSMI_equation_cpoi.CheckOnClick = True
        Me.TSMI_equation_cpoi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_equation_cpoi.Name = "TSMI_equation_cpoi"
        Me.TSMI_equation_cpoi.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_cpoi.Text = "CPoint"
        '
        'TSMI_equation_opoi
        '
        Me.TSMI_equation_opoi.Checked = True
        Me.TSMI_equation_opoi.CheckOnClick = True
        Me.TSMI_equation_opoi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_equation_opoi.Name = "TSMI_equation_opoi"
        Me.TSMI_equation_opoi.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_opoi.Text = "OPoint"
        '
        'TSMI_equation_wpoi
        '
        Me.TSMI_equation_wpoi.Checked = True
        Me.TSMI_equation_wpoi.CheckOnClick = True
        Me.TSMI_equation_wpoi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TSMI_equation_wpoi.Name = "TSMI_equation_wpoi"
        Me.TSMI_equation_wpoi.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_wpoi.Text = "WPoint"
        '
        'TSMI_equation_wait
        '
        Me.TSMI_equation_wait.CheckOnClick = True
        Me.TSMI_equation_wait.Name = "TSMI_equation_wait"
        Me.TSMI_equation_wait.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_wait.Text = "Wait"
        '
        'TSMI_equation_state
        '
        Me.TSMI_equation_state.CheckOnClick = True
        Me.TSMI_equation_state.Name = "TSMI_equation_state"
        Me.TSMI_equation_state.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_state.Text = "State"
        '
        'TSMI_equation_next
        '
        Me.TSMI_equation_next.CheckOnClick = True
        Me.TSMI_equation_next.Name = "TSMI_equation_next"
        Me.TSMI_equation_next.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_next.Text = "Next"
        '
        'TSMI_equation_hit
        '
        Me.TSMI_equation_hit.CheckOnClick = True
        Me.TSMI_equation_hit.Name = "TSMI_equation_hit"
        Me.TSMI_equation_hit.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_hit.Text = "Hit_"
        Me.TSMI_equation_hit.Visible = False
        '
        'TSS_9
        '
        Me.TSS_9.Name = "TSS_9"
        Me.TSS_9.Size = New System.Drawing.Size(228, 6)
        '
        'TSMI_equation_apply
        '
        Me.TSMI_equation_apply.Name = "TSMI_equation_apply"
        Me.TSMI_equation_apply.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.TSMI_equation_apply.Size = New System.Drawing.Size(231, 22)
        Me.TSMI_equation_apply.Text = "Apply"
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
        Me.TSMI_hidden_tools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_hT_frameViewer, Me.DEBUG_BeginUndo, Me.DEBUG_EndUndo, Me.TSMI_toggleBSprite, Me.TSMI_hT_nextFrame, Me.TSMI_hT_previousFrame})
        Me.TSMI_hidden_tools.Name = "TSMI_hidden_tools"
        Me.TSMI_hidden_tools.Size = New System.Drawing.Size(88, 20)
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
        'DEBUG_BeginUndo
        '
        Me.DEBUG_BeginUndo.Enabled = False
        Me.DEBUG_BeginUndo.Name = "DEBUG_BeginUndo"
        Me.DEBUG_BeginUndo.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.DEBUG_BeginUndo.Size = New System.Drawing.Size(315, 22)
        Me.DEBUG_BeginUndo.Text = "BeginUndo"
        '
        'DEBUG_EndUndo
        '
        Me.DEBUG_EndUndo.Enabled = False
        Me.DEBUG_EndUndo.Name = "DEBUG_EndUndo"
        Me.DEBUG_EndUndo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.DEBUG_EndUndo.Size = New System.Drawing.Size(315, 22)
        Me.DEBUG_EndUndo.Text = "EndUndo"
        '
        'TSMI_toggleBSprite
        '
        Me.TSMI_toggleBSprite.Name = "TSMI_toggleBSprite"
        Me.TSMI_toggleBSprite.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.TSMI_toggleBSprite.Size = New System.Drawing.Size(315, 22)
        Me.TSMI_toggleBSprite.Text = "B-Sprite Toggle"
        '
        'Ofd_Data
        '
        Me.Ofd_Data.Filter = "Files|*.dat;*.txt|LF2-Data File|*.dat|Text Files|*.txt"
        Me.Ofd_Data.Multiselect = True
        '
        'Sfd_HTML
        '
        Me.Sfd_HTML.Filter = "HTML-File|*.html;*.htm"
        '
        'TSMI_hT_nextFrame
        '
        Me.TSMI_hT_nextFrame.Name = "TSMI_hT_nextFrame"
        Me.TSMI_hT_nextFrame.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)
        Me.TSMI_hT_nextFrame.Size = New System.Drawing.Size(315, 22)
        Me.TSMI_hT_nextFrame.Text = "Next Frame Text Editor"
        '
        'TSMI_hT_previousFrame
        '
        Me.TSMI_hT_previousFrame.Name = "TSMI_hT_previousFrame"
        Me.TSMI_hT_previousFrame.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)
        Me.TSMI_hT_previousFrame.Size = New System.Drawing.Size(315, 22)
        Me.TSMI_hT_previousFrame.Text = "Previous Frame Text Editor"
        '
        'Main
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 549)
        Me.Controls.Add(Me.DockPan_Main)
        Me.Controls.Add(Me.SS_Infos)
        Me.Controls.Add(Me.MS_Icons)
        Me.Controls.Add(Me.MS_Main)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MS_Icons
        Me.MinimumSize = New System.Drawing.Size(748, 394)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MS_Icons.ResumeLayout(False)
        Me.MS_Icons.PerformLayout()
        Me.SS_Infos.ResumeLayout(False)
        Me.SS_Infos.PerformLayout()
        Me.MS_Main.ResumeLayout(False)
        Me.MS_Main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MS_Icons As MenuStrip
    Friend WithEvents SS_Infos As StatusStrip
    Friend WithEvents DockPan_Main As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents MS_Main As MenuStrip
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
    Friend WithEvents Ofd_Data As OpenFileDialog
    Friend WithEvents TSMI_frameViewer As ToolStripMenuItem
    Friend WithEvents TSMI_undo As ToolStripMenuItem
    Friend WithEvents TSMI_redo As ToolStripMenuItem
    Friend WithEvents TSS_5 As ToolStripSeparator
    Friend WithEvents TSMI_cut As ToolStripMenuItem
    Friend WithEvents TSMI_copy As ToolStripMenuItem
    Friend WithEvents TSMI_paste As ToolStripMenuItem
    Friend WithEvents TSMI_delete As ToolStripMenuItem
    Friend WithEvents TSMI_selectAll As ToolStripMenuItem
    Friend WithEvents TSMI_unusedIDs As ToolStripMenuItem
    Friend WithEvents TSMI_errorList As ToolStripMenuItem
    Friend WithEvents TSMI_settings As ToolStripMenuItem
    Friend WithEvents TSMI_find As ToolStripMenuItem
    Friend WithEvents TSMI_findAgain As ToolStripMenuItem
    Friend WithEvents TSMI_findAgainReverse As ToolStripMenuItem
    Friend WithEvents TSMI_goToLine As ToolStripMenuItem
    Friend WithEvents TSMI_goToFrame As ToolStripMenuItem
    Friend WithEvents TSS_6 As ToolStripSeparator
    Friend WithEvents TSMI_goTo As ToolStripMenuItem
    Friend WithEvents TSMI_tools As ToolStripMenuItem
    Friend WithEvents TSMI_framesReformatting As ToolStripMenuItem
    Friend WithEvents TSMI_mirrorFrame As ToolStripMenuItem
    Friend WithEvents TSSL_copyright As ToolStripStatusLabel
    Friend WithEvents Link_Cookiesoft As ToolStripStatusLabel
    Friend WithEvents TSS_7 As ToolStripSeparator
    Friend WithEvents TSMI_expand As ToolStripMenuItem
    Friend WithEvents TSMI_collapse As ToolStripMenuItem
    Friend WithEvents TSMI_pasteCool As ToolStripMenuItem
    Friend WithEvents TSMI_hidden_tools As ToolStripMenuItem
    Friend WithEvents TSMI_hT_frameViewer As ToolStripMenuItem
    Friend WithEvents TSMI_tagAdder As ToolStripMenuItem
    Friend WithEvents TSMI_IDChanger As ToolStripMenuItem
    Friend WithEvents TSComb_frames As ToolStripComboBox
    Friend WithEvents TSComb_lf As ToolStripComboBox
    Friend WithEvents TSMI_run As ToolStripMenuItem
    Friend WithEvents TSMI_findMulti As ToolStripMenuItem
    Friend WithEvents TSS_10 As ToolStripSeparator
    Friend WithEvents TSMI_export As ToolStripMenuItem
    Friend WithEvents Sfd_HTML As SaveFileDialog
    Friend WithEvents DEBUG_DO_ERRORS As ToolStripMenuItem
    Friend WithEvents TSMI_closeAll As ToolStripMenuItem
    Friend WithEvents TSMI_view As ToolStripMenuItem
    Friend WithEvents TSMI_lineNumbers As ToolStripMenuItem
    Friend WithEvents TSMI_markLine As ToolStripMenuItem
    Friend WithEvents TSMI_hSplit As ToolStripMenuItem
    Friend WithEvents TSMI_vSplit As ToolStripMenuItem
    Friend WithEvents TSMI_sort As ToolStripMenuItem
    Friend WithEvents TSMI_equation As ToolStripMenuItem
    Friend WithEvents TSMI_equation_center As ToolStripMenuItem
    Friend WithEvents TSMI_equation_bodies As ToolStripMenuItem
    Friend WithEvents TSMI_equation_itrs As ToolStripMenuItem
    Friend WithEvents TSMI_equation_bpoi As ToolStripMenuItem
    Friend WithEvents TSMI_equation_cpoi As ToolStripMenuItem
    Friend WithEvents TSMI_equation_opoi As ToolStripMenuItem
    Friend WithEvents TSMI_equation_wpoi As ToolStripMenuItem
    Friend WithEvents TSMI_equation_next As ToolStripMenuItem
    Friend WithEvents TSMI_equation_hit As ToolStripMenuItem
    Friend WithEvents TSMI_wrap As ToolStripMenuItem
    Friend WithEvents TSMI_equation_setOptions As ToolStripMenuItem
    Friend WithEvents TSS_8 As ToolStripSeparator
    Friend WithEvents TSComb_WrapMode As ToolStripComboBox
    Friend WithEvents TSS_9 As ToolStripSeparator
    Friend WithEvents TSMI_equation_apply As ToolStripMenuItem
    Friend WithEvents TSMI_equation_wait As ToolStripMenuItem
    Friend WithEvents TSMI_equation_state As ToolStripMenuItem
    Friend WithEvents TSMI_whitespaces As ToolStripMenuItem
    Friend WithEvents TSMI_mark As ToolStripMenuItem
    Friend WithEvents TSSL_textLength As ToolStripStatusLabel
    Friend WithEvents TSSL_textLengthVal As ToolStripStatusLabel
    Friend WithEvents TSSL_textLines As ToolStripStatusLabel
    Friend WithEvents TSSL_textLinesVal As ToolStripStatusLabel
    Friend WithEvents DEBUG_BeginUndo As ToolStripMenuItem
    Friend WithEvents DEBUG_EndUndo As ToolStripMenuItem
    Friend WithEvents TSS_11 As ToolStripSeparator
    Friend WithEvents TSMI_bookmark As ToolStripMenuItem
    Friend WithEvents TSMI_toggleBookmark As ToolStripMenuItem
    Friend WithEvents TSMI_nextBookmark As ToolStripMenuItem
    Friend WithEvents TSMI_previousBookmark As ToolStripMenuItem
    Friend WithEvents TSMI_clearBookmarks As ToolStripMenuItem
    Friend WithEvents TSMI_cutBookmarkedLines As ToolStripMenuItem
    Friend WithEvents TSMI_copyBookmarkedLines As ToolStripMenuItem
    Friend WithEvents TSMI_pasteBookmarkedLines As ToolStripMenuItem
    Friend WithEvents TSMI_removeBookmarkedLines As ToolStripMenuItem
    Friend WithEvents TSMI_removeUnmarkedLines As ToolStripMenuItem
    Friend WithEvents TSMI_inverseBookmark As ToolStripMenuItem
    Friend WithEvents TSMI_replace As ToolStripMenuItem
    Friend WithEvents TSMI_replaceAgain As ToolStripMenuItem
    Friend WithEvents TSMI_replaceAgainReverse As ToolStripMenuItem
    Friend WithEvents TSS_12 As ToolStripSeparator
    Friend WithEvents TSMI_toggleBSprite As ToolStripMenuItem
    Friend WithEvents TSMI_hT_nextFrame As ToolStripMenuItem
    Friend WithEvents TSMI_hT_previousFrame As ToolStripMenuItem
End Class
