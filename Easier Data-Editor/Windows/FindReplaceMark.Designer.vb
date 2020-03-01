<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindReplaceMark
    Inherits Translation.TranslatableForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindReplaceMark))
        Me.SS_info = New System.Windows.Forms.StatusStrip()
        Me.TabC_mode = New System.Windows.Forms.TabControl()
        Me.Tabp_find = New System.Windows.Forms.TabPage()
        Me.Btn_close = New System.Windows.Forms.Button()
        Me.Btn_count = New System.Windows.Forms.Button()
        Me.Btn_find_reverse = New System.Windows.Forms.Button()
        Me.Btn_find = New System.Windows.Forms.Button()
        Me.Tabp_replace = New System.Windows.Forms.TabPage()
        Me.Btn_close_1 = New System.Windows.Forms.Button()
        Me.Btn_replaceAll = New System.Windows.Forms.Button()
        Me.Btn_replace = New System.Windows.Forms.Button()
        Me.Btn_find_reverse_1 = New System.Windows.Forms.Button()
        Me.Btn_find_1 = New System.Windows.Forms.Button()
        Me.Tabp_findInFiles = New System.Windows.Forms.TabPage()
        Me.Comb_directory = New System.Windows.Forms.ComboBox()
        Me.Comb_filters = New System.Windows.Forms.ComboBox()
        Me.Cb_hiddenFolders = New System.Windows.Forms.CheckBox()
        Me.Cb_subfolders = New System.Windows.Forms.CheckBox()
        Me.Btn_directory = New System.Windows.Forms.Button()
        Me.Lbl_directory = New System.Windows.Forms.Label()
        Me.Btn_close_2 = New System.Windows.Forms.Button()
        Me.Btn_replaceInFiles = New System.Windows.Forms.Button()
        Me.Btn_searchInFiles = New System.Windows.Forms.Button()
        Me.Lbl_filters = New System.Windows.Forms.Label()
        Me.Tabp_mark = New System.Windows.Forms.TabPage()
        Me.Cb_clearBookmarks = New System.Windows.Forms.CheckBox()
        Me.Cb_bookmark = New System.Windows.Forms.CheckBox()
        Me.Btn_close_3 = New System.Windows.Forms.Button()
        Me.Btn_clearMarks = New System.Windows.Forms.Button()
        Me.Btn_mark = New System.Windows.Forms.Button()
        Me.Pal_searchMode = New System.Windows.Forms.Panel()
        Me.Cb_transparency = New System.Windows.Forms.CheckBox()
        Me.Gb_transparency = New System.Windows.Forms.GroupBox()
        Me.Pal_hrFake = New System.Windows.Forms.Panel()
        Me.Trackb_transparency = New System.Windows.Forms.TrackBar()
        Me.Rb_trans_always = New System.Windows.Forms.RadioButton()
        Me.Rb_trans_losing = New System.Windows.Forms.RadioButton()
        Me.Gb_searchMode = New System.Windows.Forms.GroupBox()
        Me.Rb_search_regex = New System.Windows.Forms.RadioButton()
        Me.Rb_search_extended = New System.Windows.Forms.RadioButton()
        Me.Rb_search_normal = New System.Windows.Forms.RadioButton()
        Me.Pal_matchSettings = New System.Windows.Forms.Panel()
        Me.Cb_selections = New System.Windows.Forms.CheckBox()
        Me.Cb_wrapAround = New System.Windows.Forms.CheckBox()
        Me.Cb_case = New System.Windows.Forms.CheckBox()
        Me.Cb_wholeWord = New System.Windows.Forms.CheckBox()
        Me.Pal_find_replace = New System.Windows.Forms.Panel()
        Me.Comb_replace = New System.Windows.Forms.ComboBox()
        Me.Comb_find = New System.Windows.Forms.ComboBox()
        Me.Lbl_replace = New System.Windows.Forms.Label()
        Me.Lbl_find = New System.Windows.Forms.Label()
        Me.TabC_mode.SuspendLayout()
        Me.Tabp_find.SuspendLayout()
        Me.Tabp_replace.SuspendLayout()
        Me.Tabp_findInFiles.SuspendLayout()
        Me.Tabp_mark.SuspendLayout()
        Me.Pal_searchMode.SuspendLayout()
        Me.Gb_transparency.SuspendLayout()
        CType(Me.Trackb_transparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_searchMode.SuspendLayout()
        Me.Pal_matchSettings.SuspendLayout()
        Me.Pal_find_replace.SuspendLayout()
        Me.SuspendLayout()
        '
        'SS_info
        '
        Me.SS_info.Location = New System.Drawing.Point(0, 349)
        Me.SS_info.Name = "SS_info"
        Me.SS_info.Size = New System.Drawing.Size(734, 22)
        Me.SS_info.TabIndex = 0
        '
        'TabC_mode
        '
        Me.TabC_mode.Controls.Add(Me.Tabp_find)
        Me.TabC_mode.Controls.Add(Me.Tabp_replace)
        Me.TabC_mode.Controls.Add(Me.Tabp_findInFiles)
        Me.TabC_mode.Controls.Add(Me.Tabp_mark)
        Me.TabC_mode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabC_mode.Location = New System.Drawing.Point(0, 0)
        Me.TabC_mode.Name = "TabC_mode"
        Me.TabC_mode.Padding = New System.Drawing.Point(10, 6)
        Me.TabC_mode.SelectedIndex = 0
        Me.TabC_mode.Size = New System.Drawing.Size(734, 349)
        Me.TabC_mode.TabIndex = 1
        '
        'Tabp_find
        '
        Me.Tabp_find.Controls.Add(Me.Btn_close)
        Me.Tabp_find.Controls.Add(Me.Btn_count)
        Me.Tabp_find.Controls.Add(Me.Btn_find_reverse)
        Me.Tabp_find.Controls.Add(Me.Btn_find)
        Me.Tabp_find.Location = New System.Drawing.Point(4, 28)
        Me.Tabp_find.Name = "Tabp_find"
        Me.Tabp_find.Padding = New System.Windows.Forms.Padding(6)
        Me.Tabp_find.Size = New System.Drawing.Size(726, 317)
        Me.Tabp_find.TabIndex = 0
        Me.Tabp_find.Text = "Find"
        Me.Tabp_find.UseVisualStyleBackColor = True
        '
        'Btn_close
        '
        Me.Btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_close.Location = New System.Drawing.Point(575, 65)
        Me.Btn_close.Name = "Btn_close"
        Me.Btn_close.Size = New System.Drawing.Size(142, 23)
        Me.Btn_close.TabIndex = 9
        Me.Btn_close.Text = "Close"
        Me.Btn_close.UseVisualStyleBackColor = True
        '
        'Btn_count
        '
        Me.Btn_count.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_count.Location = New System.Drawing.Point(575, 36)
        Me.Btn_count.Name = "Btn_count"
        Me.Btn_count.Size = New System.Drawing.Size(142, 23)
        Me.Btn_count.TabIndex = 8
        Me.Btn_count.Text = "Count"
        Me.Btn_count.UseVisualStyleBackColor = True
        '
        'Btn_find_reverse
        '
        Me.Btn_find_reverse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_find_reverse.Location = New System.Drawing.Point(575, 7)
        Me.Btn_find_reverse.Name = "Btn_find_reverse"
        Me.Btn_find_reverse.Size = New System.Drawing.Size(70, 23)
        Me.Btn_find_reverse.TabIndex = 7
        Me.Btn_find_reverse.Text = "< Find"
        Me.Btn_find_reverse.UseVisualStyleBackColor = True
        '
        'Btn_find
        '
        Me.Btn_find.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_find.Location = New System.Drawing.Point(647, 7)
        Me.Btn_find.Name = "Btn_find"
        Me.Btn_find.Size = New System.Drawing.Size(70, 23)
        Me.Btn_find.TabIndex = 6
        Me.Btn_find.Text = "Find >"
        Me.Btn_find.UseVisualStyleBackColor = True
        '
        'Tabp_replace
        '
        Me.Tabp_replace.Controls.Add(Me.Btn_close_1)
        Me.Tabp_replace.Controls.Add(Me.Btn_replaceAll)
        Me.Tabp_replace.Controls.Add(Me.Btn_replace)
        Me.Tabp_replace.Controls.Add(Me.Btn_find_reverse_1)
        Me.Tabp_replace.Controls.Add(Me.Btn_find_1)
        Me.Tabp_replace.Location = New System.Drawing.Point(4, 28)
        Me.Tabp_replace.Name = "Tabp_replace"
        Me.Tabp_replace.Padding = New System.Windows.Forms.Padding(6)
        Me.Tabp_replace.Size = New System.Drawing.Size(726, 317)
        Me.Tabp_replace.TabIndex = 1
        Me.Tabp_replace.Text = "Replace"
        Me.Tabp_replace.UseVisualStyleBackColor = True
        '
        'Btn_close_1
        '
        Me.Btn_close_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_close_1.Location = New System.Drawing.Point(575, 94)
        Me.Btn_close_1.Name = "Btn_close_1"
        Me.Btn_close_1.Size = New System.Drawing.Size(142, 23)
        Me.Btn_close_1.TabIndex = 18
        Me.Btn_close_1.Text = "Close"
        Me.Btn_close_1.UseVisualStyleBackColor = True
        '
        'Btn_replaceAll
        '
        Me.Btn_replaceAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_replaceAll.Location = New System.Drawing.Point(575, 65)
        Me.Btn_replaceAll.Name = "Btn_replaceAll"
        Me.Btn_replaceAll.Size = New System.Drawing.Size(142, 23)
        Me.Btn_replaceAll.TabIndex = 17
        Me.Btn_replaceAll.Text = "Replace All"
        Me.Btn_replaceAll.UseVisualStyleBackColor = True
        '
        'Btn_replace
        '
        Me.Btn_replace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_replace.Location = New System.Drawing.Point(575, 36)
        Me.Btn_replace.Name = "Btn_replace"
        Me.Btn_replace.Size = New System.Drawing.Size(142, 23)
        Me.Btn_replace.TabIndex = 16
        Me.Btn_replace.Text = "Replace"
        Me.Btn_replace.UseVisualStyleBackColor = True
        '
        'Btn_find_reverse_1
        '
        Me.Btn_find_reverse_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_find_reverse_1.Location = New System.Drawing.Point(575, 7)
        Me.Btn_find_reverse_1.Name = "Btn_find_reverse_1"
        Me.Btn_find_reverse_1.Size = New System.Drawing.Size(70, 23)
        Me.Btn_find_reverse_1.TabIndex = 15
        Me.Btn_find_reverse_1.Text = "< Find"
        Me.Btn_find_reverse_1.UseVisualStyleBackColor = True
        '
        'Btn_find_1
        '
        Me.Btn_find_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_find_1.Location = New System.Drawing.Point(647, 7)
        Me.Btn_find_1.Name = "Btn_find_1"
        Me.Btn_find_1.Size = New System.Drawing.Size(70, 23)
        Me.Btn_find_1.TabIndex = 14
        Me.Btn_find_1.Text = "Find >"
        Me.Btn_find_1.UseVisualStyleBackColor = True
        '
        'Tabp_findInFiles
        '
        Me.Tabp_findInFiles.Controls.Add(Me.Comb_directory)
        Me.Tabp_findInFiles.Controls.Add(Me.Comb_filters)
        Me.Tabp_findInFiles.Controls.Add(Me.Cb_hiddenFolders)
        Me.Tabp_findInFiles.Controls.Add(Me.Cb_subfolders)
        Me.Tabp_findInFiles.Controls.Add(Me.Btn_directory)
        Me.Tabp_findInFiles.Controls.Add(Me.Lbl_directory)
        Me.Tabp_findInFiles.Controls.Add(Me.Btn_close_2)
        Me.Tabp_findInFiles.Controls.Add(Me.Btn_replaceInFiles)
        Me.Tabp_findInFiles.Controls.Add(Me.Btn_searchInFiles)
        Me.Tabp_findInFiles.Controls.Add(Me.Lbl_filters)
        Me.Tabp_findInFiles.Location = New System.Drawing.Point(4, 28)
        Me.Tabp_findInFiles.Name = "Tabp_findInFiles"
        Me.Tabp_findInFiles.Padding = New System.Windows.Forms.Padding(6)
        Me.Tabp_findInFiles.Size = New System.Drawing.Size(726, 317)
        Me.Tabp_findInFiles.TabIndex = 2
        Me.Tabp_findInFiles.Text = "Find in Files"
        Me.Tabp_findInFiles.UseVisualStyleBackColor = True
        '
        'Comb_directory
        '
        Me.Comb_directory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_directory.FormattingEnabled = True
        Me.Comb_directory.Location = New System.Drawing.Point(115, 92)
        Me.Comb_directory.Name = "Comb_directory"
        Me.Comb_directory.Size = New System.Drawing.Size(405, 21)
        Me.Comb_directory.TabIndex = 36
        '
        'Comb_filters
        '
        Me.Comb_filters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_filters.FormattingEnabled = True
        Me.Comb_filters.Location = New System.Drawing.Point(115, 66)
        Me.Comb_filters.Name = "Comb_filters"
        Me.Comb_filters.Size = New System.Drawing.Size(454, 21)
        Me.Comb_filters.TabIndex = 35
        '
        'Cb_hiddenFolders
        '
        Me.Cb_hiddenFolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_hiddenFolders.AutoSize = True
        Me.Cb_hiddenFolders.Location = New System.Drawing.Point(575, 119)
        Me.Cb_hiddenFolders.Name = "Cb_hiddenFolders"
        Me.Cb_hiddenFolders.Size = New System.Drawing.Size(104, 17)
        Me.Cb_hiddenFolders.TabIndex = 33
        Me.Cb_hiddenFolders.Text = "In hidden folders"
        Me.Cb_hiddenFolders.UseVisualStyleBackColor = True
        '
        'Cb_subfolders
        '
        Me.Cb_subfolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_subfolders.AutoSize = True
        Me.Cb_subfolders.Location = New System.Drawing.Point(575, 95)
        Me.Cb_subfolders.Name = "Cb_subfolders"
        Me.Cb_subfolders.Size = New System.Drawing.Size(102, 17)
        Me.Cb_subfolders.TabIndex = 32
        Me.Cb_subfolders.Text = "In all sub-folders"
        Me.Cb_subfolders.UseVisualStyleBackColor = True
        '
        'Btn_directory
        '
        Me.Btn_directory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_directory.Location = New System.Drawing.Point(526, 91)
        Me.Btn_directory.Name = "Btn_directory"
        Me.Btn_directory.Size = New System.Drawing.Size(43, 23)
        Me.Btn_directory.TabIndex = 31
        Me.Btn_directory.Text = "..."
        Me.Btn_directory.UseVisualStyleBackColor = True
        '
        'Lbl_directory
        '
        Me.Lbl_directory.Location = New System.Drawing.Point(9, 91)
        Me.Lbl_directory.Name = "Lbl_directory"
        Me.Lbl_directory.Size = New System.Drawing.Size(100, 23)
        Me.Lbl_directory.TabIndex = 29
        Me.Lbl_directory.Text = "Dir&ectory:"
        Me.Lbl_directory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Btn_close_2
        '
        Me.Btn_close_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_close_2.Location = New System.Drawing.Point(575, 65)
        Me.Btn_close_2.Name = "Btn_close_2"
        Me.Btn_close_2.Size = New System.Drawing.Size(142, 23)
        Me.Btn_close_2.TabIndex = 28
        Me.Btn_close_2.Text = "Close"
        Me.Btn_close_2.UseVisualStyleBackColor = True
        '
        'Btn_replaceInFiles
        '
        Me.Btn_replaceInFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_replaceInFiles.Location = New System.Drawing.Point(575, 36)
        Me.Btn_replaceInFiles.Name = "Btn_replaceInFiles"
        Me.Btn_replaceInFiles.Size = New System.Drawing.Size(142, 23)
        Me.Btn_replaceInFiles.TabIndex = 27
        Me.Btn_replaceInFiles.Text = "Replace in all Files"
        Me.Btn_replaceInFiles.UseVisualStyleBackColor = True
        '
        'Btn_searchInFiles
        '
        Me.Btn_searchInFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_searchInFiles.Location = New System.Drawing.Point(575, 7)
        Me.Btn_searchInFiles.Name = "Btn_searchInFiles"
        Me.Btn_searchInFiles.Size = New System.Drawing.Size(142, 23)
        Me.Btn_searchInFiles.TabIndex = 26
        Me.Btn_searchInFiles.Text = "Search All"
        Me.Btn_searchInFiles.UseVisualStyleBackColor = True
        '
        'Lbl_filters
        '
        Me.Lbl_filters.Location = New System.Drawing.Point(9, 65)
        Me.Lbl_filters.Name = "Lbl_filters"
        Me.Lbl_filters.Size = New System.Drawing.Size(100, 23)
        Me.Lbl_filters.TabIndex = 24
        Me.Lbl_filters.Text = "Filters:"
        Me.Lbl_filters.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tabp_mark
        '
        Me.Tabp_mark.Controls.Add(Me.Cb_clearBookmarks)
        Me.Tabp_mark.Controls.Add(Me.Cb_bookmark)
        Me.Tabp_mark.Controls.Add(Me.Btn_close_3)
        Me.Tabp_mark.Controls.Add(Me.Btn_clearMarks)
        Me.Tabp_mark.Controls.Add(Me.Btn_mark)
        Me.Tabp_mark.Location = New System.Drawing.Point(4, 28)
        Me.Tabp_mark.Name = "Tabp_mark"
        Me.Tabp_mark.Padding = New System.Windows.Forms.Padding(6)
        Me.Tabp_mark.Size = New System.Drawing.Size(726, 317)
        Me.Tabp_mark.TabIndex = 3
        Me.Tabp_mark.Text = "Mark"
        Me.Tabp_mark.UseVisualStyleBackColor = True
        '
        'Cb_clearBookmarks
        '
        Me.Cb_clearBookmarks.AutoSize = True
        Me.Cb_clearBookmarks.Location = New System.Drawing.Point(17, 97)
        Me.Cb_clearBookmarks.Name = "Cb_clearBookmarks"
        Me.Cb_clearBookmarks.Size = New System.Drawing.Size(237, 17)
        Me.Cb_clearBookmarks.TabIndex = 25
        Me.Cb_clearBookmarks.Text = "Purge for each search (includes bookmarks!)"
        Me.Cb_clearBookmarks.UseVisualStyleBackColor = True
        '
        'Cb_bookmark
        '
        Me.Cb_bookmark.AutoSize = True
        Me.Cb_bookmark.Location = New System.Drawing.Point(17, 74)
        Me.Cb_bookmark.Name = "Cb_bookmark"
        Me.Cb_bookmark.Size = New System.Drawing.Size(93, 17)
        Me.Cb_bookmark.TabIndex = 24
        Me.Cb_bookmark.Text = "Bookmark line"
        Me.Cb_bookmark.UseVisualStyleBackColor = True
        '
        'Btn_close_3
        '
        Me.Btn_close_3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_close_3.Location = New System.Drawing.Point(575, 65)
        Me.Btn_close_3.Name = "Btn_close_3"
        Me.Btn_close_3.Size = New System.Drawing.Size(142, 23)
        Me.Btn_close_3.TabIndex = 23
        Me.Btn_close_3.Text = "Close"
        Me.Btn_close_3.UseVisualStyleBackColor = True
        '
        'Btn_clearMarks
        '
        Me.Btn_clearMarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_clearMarks.Location = New System.Drawing.Point(575, 36)
        Me.Btn_clearMarks.Name = "Btn_clearMarks"
        Me.Btn_clearMarks.Size = New System.Drawing.Size(142, 23)
        Me.Btn_clearMarks.TabIndex = 22
        Me.Btn_clearMarks.Text = "Clear all marks"
        Me.Btn_clearMarks.UseVisualStyleBackColor = True
        '
        'Btn_mark
        '
        Me.Btn_mark.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_mark.Location = New System.Drawing.Point(575, 7)
        Me.Btn_mark.Name = "Btn_mark"
        Me.Btn_mark.Size = New System.Drawing.Size(142, 23)
        Me.Btn_mark.TabIndex = 21
        Me.Btn_mark.Text = "Mark All"
        Me.Btn_mark.UseVisualStyleBackColor = True
        '
        'Pal_searchMode
        '
        Me.Pal_searchMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pal_searchMode.BackColor = System.Drawing.Color.White
        Me.Pal_searchMode.Controls.Add(Me.Cb_transparency)
        Me.Pal_searchMode.Controls.Add(Me.Gb_transparency)
        Me.Pal_searchMode.Controls.Add(Me.Gb_searchMode)
        Me.Pal_searchMode.Location = New System.Drawing.Point(4, 241)
        Me.Pal_searchMode.Name = "Pal_searchMode"
        Me.Pal_searchMode.Size = New System.Drawing.Size(726, 94)
        Me.Pal_searchMode.TabIndex = 2
        '
        'Cb_transparency
        '
        Me.Cb_transparency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_transparency.AutoSize = True
        Me.Cb_transparency.Location = New System.Drawing.Point(535, 0)
        Me.Cb_transparency.Name = "Cb_transparency"
        Me.Cb_transparency.Size = New System.Drawing.Size(91, 17)
        Me.Cb_transparency.TabIndex = 3
        Me.Cb_transparency.Text = "Transparency"
        Me.Cb_transparency.UseVisualStyleBackColor = True
        '
        'Gb_transparency
        '
        Me.Gb_transparency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gb_transparency.Controls.Add(Me.Pal_hrFake)
        Me.Gb_transparency.Controls.Add(Me.Trackb_transparency)
        Me.Gb_transparency.Controls.Add(Me.Rb_trans_always)
        Me.Gb_transparency.Controls.Add(Me.Rb_trans_losing)
        Me.Gb_transparency.Location = New System.Drawing.Point(541, 1)
        Me.Gb_transparency.Name = "Gb_transparency"
        Me.Gb_transparency.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Gb_transparency.Size = New System.Drawing.Size(176, 90)
        Me.Gb_transparency.TabIndex = 1
        Me.Gb_transparency.TabStop = False
        Me.Gb_transparency.Text = "Transparency"
        '
        'Pal_hrFake
        '
        Me.Pal_hrFake.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Pal_hrFake.Location = New System.Drawing.Point(3, 88)
        Me.Pal_hrFake.Name = "Pal_hrFake"
        Me.Pal_hrFake.Size = New System.Drawing.Size(171, 1)
        Me.Pal_hrFake.TabIndex = 2
        '
        'Trackb_transparency
        '
        Me.Trackb_transparency.LargeChange = 10
        Me.Trackb_transparency.Location = New System.Drawing.Point(9, 64)
        Me.Trackb_transparency.Maximum = 100
        Me.Trackb_transparency.Minimum = 5
        Me.Trackb_transparency.Name = "Trackb_transparency"
        Me.Trackb_transparency.Size = New System.Drawing.Size(158, 45)
        Me.Trackb_transparency.SmallChange = 5
        Me.Trackb_transparency.TabIndex = 1
        Me.Trackb_transparency.TickFrequency = 10
        Me.Trackb_transparency.TickStyle = System.Windows.Forms.TickStyle.None
        Me.Trackb_transparency.Value = 30
        '
        'Rb_trans_always
        '
        Me.Rb_trans_always.AutoSize = True
        Me.Rb_trans_always.Location = New System.Drawing.Point(9, 42)
        Me.Rb_trans_always.Name = "Rb_trans_always"
        Me.Rb_trans_always.Size = New System.Drawing.Size(58, 17)
        Me.Rb_trans_always.TabIndex = 0
        Me.Rb_trans_always.TabStop = True
        Me.Rb_trans_always.Text = "Always"
        Me.Rb_trans_always.UseVisualStyleBackColor = True
        '
        'Rb_trans_losing
        '
        Me.Rb_trans_losing.AutoSize = True
        Me.Rb_trans_losing.Location = New System.Drawing.Point(9, 19)
        Me.Rb_trans_losing.Name = "Rb_trans_losing"
        Me.Rb_trans_losing.Size = New System.Drawing.Size(98, 17)
        Me.Rb_trans_losing.TabIndex = 0
        Me.Rb_trans_losing.TabStop = True
        Me.Rb_trans_losing.Text = "On losing focus"
        Me.Rb_trans_losing.UseVisualStyleBackColor = True
        '
        'Gb_searchMode
        '
        Me.Gb_searchMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Gb_searchMode.Controls.Add(Me.Rb_search_regex)
        Me.Gb_searchMode.Controls.Add(Me.Rb_search_extended)
        Me.Gb_searchMode.Controls.Add(Me.Rb_search_normal)
        Me.Gb_searchMode.Location = New System.Drawing.Point(8, 1)
        Me.Gb_searchMode.Name = "Gb_searchMode"
        Me.Gb_searchMode.Padding = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.Gb_searchMode.Size = New System.Drawing.Size(226, 90)
        Me.Gb_searchMode.TabIndex = 0
        Me.Gb_searchMode.TabStop = False
        Me.Gb_searchMode.Text = "Search Mode"
        '
        'Rb_search_regex
        '
        Me.Rb_search_regex.AutoSize = True
        Me.Rb_search_regex.Checked = True
        Me.Rb_search_regex.Location = New System.Drawing.Point(8, 42)
        Me.Rb_search_regex.Name = "Rb_search_regex"
        Me.Rb_search_regex.Size = New System.Drawing.Size(115, 17)
        Me.Rb_search_regex.TabIndex = 0
        Me.Rb_search_regex.TabStop = True
        Me.Rb_search_regex.Text = "Regular expression"
        Me.Rb_search_regex.UseVisualStyleBackColor = True
        '
        'Rb_search_extended
        '
        Me.Rb_search_extended.AutoSize = True
        Me.Rb_search_extended.Location = New System.Drawing.Point(69, 42)
        Me.Rb_search_extended.Name = "Rb_search_extended"
        Me.Rb_search_extended.Size = New System.Drawing.Size(151, 17)
        Me.Rb_search_extended.TabIndex = 0
        Me.Rb_search_extended.Text = "Extended (\n, \r, \t, \0, \x)"
        Me.Rb_search_extended.UseVisualStyleBackColor = True
        Me.Rb_search_extended.Visible = False
        '
        'Rb_search_normal
        '
        Me.Rb_search_normal.AutoSize = True
        Me.Rb_search_normal.Location = New System.Drawing.Point(9, 19)
        Me.Rb_search_normal.Name = "Rb_search_normal"
        Me.Rb_search_normal.Size = New System.Drawing.Size(58, 17)
        Me.Rb_search_normal.TabIndex = 0
        Me.Rb_search_normal.Text = "Normal"
        Me.Rb_search_normal.UseVisualStyleBackColor = True
        '
        'Pal_matchSettings
        '
        Me.Pal_matchSettings.BackColor = System.Drawing.Color.White
        Me.Pal_matchSettings.Controls.Add(Me.Cb_selections)
        Me.Pal_matchSettings.Controls.Add(Me.Cb_wrapAround)
        Me.Pal_matchSettings.Controls.Add(Me.Cb_case)
        Me.Pal_matchSettings.Controls.Add(Me.Cb_wholeWord)
        Me.Pal_matchSettings.Location = New System.Drawing.Point(4, 148)
        Me.Pal_matchSettings.Name = "Pal_matchSettings"
        Me.Pal_matchSettings.Size = New System.Drawing.Size(333, 94)
        Me.Pal_matchSettings.TabIndex = 3
        '
        'Cb_selections
        '
        Me.Cb_selections.AutoSize = True
        Me.Cb_selections.Location = New System.Drawing.Point(17, 72)
        Me.Cb_selections.Name = "Cb_selections"
        Me.Cb_selections.Size = New System.Drawing.Size(113, 17)
        Me.Cb_selections.TabIndex = 1
        Me.Cb_selections.Text = "In selection(s) only"
        Me.Cb_selections.UseVisualStyleBackColor = True
        '
        'Cb_wrapAround
        '
        Me.Cb_wrapAround.AutoSize = True
        Me.Cb_wrapAround.Location = New System.Drawing.Point(17, 49)
        Me.Cb_wrapAround.Name = "Cb_wrapAround"
        Me.Cb_wrapAround.Size = New System.Drawing.Size(88, 17)
        Me.Cb_wrapAround.TabIndex = 0
        Me.Cb_wrapAround.Text = "Wrap around"
        Me.Cb_wrapAround.UseVisualStyleBackColor = True
        '
        'Cb_case
        '
        Me.Cb_case.AutoSize = True
        Me.Cb_case.Location = New System.Drawing.Point(17, 26)
        Me.Cb_case.Name = "Cb_case"
        Me.Cb_case.Size = New System.Drawing.Size(82, 17)
        Me.Cb_case.TabIndex = 0
        Me.Cb_case.Text = "Match case"
        Me.Cb_case.UseVisualStyleBackColor = True
        '
        'Cb_wholeWord
        '
        Me.Cb_wholeWord.AutoSize = True
        Me.Cb_wholeWord.Location = New System.Drawing.Point(17, 3)
        Me.Cb_wholeWord.Name = "Cb_wholeWord"
        Me.Cb_wholeWord.Size = New System.Drawing.Size(135, 17)
        Me.Cb_wholeWord.TabIndex = 0
        Me.Cb_wholeWord.Text = "Match whole word only"
        Me.Cb_wholeWord.UseVisualStyleBackColor = True
        '
        'Pal_find_replace
        '
        Me.Pal_find_replace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pal_find_replace.BackColor = System.Drawing.Color.White
        Me.Pal_find_replace.Controls.Add(Me.Comb_replace)
        Me.Pal_find_replace.Controls.Add(Me.Comb_find)
        Me.Pal_find_replace.Controls.Add(Me.Lbl_replace)
        Me.Pal_find_replace.Controls.Add(Me.Lbl_find)
        Me.Pal_find_replace.Location = New System.Drawing.Point(5, 29)
        Me.Pal_find_replace.Name = "Pal_find_replace"
        Me.Pal_find_replace.Size = New System.Drawing.Size(568, 63)
        Me.Pal_find_replace.TabIndex = 11
        '
        'Comb_replace
        '
        Me.Comb_replace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_replace.FormattingEnabled = True
        Me.Comb_replace.Location = New System.Drawing.Point(114, 36)
        Me.Comb_replace.Name = "Comb_replace"
        Me.Comb_replace.Size = New System.Drawing.Size(454, 21)
        Me.Comb_replace.TabIndex = 39
        '
        'Comb_find
        '
        Me.Comb_find.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_find.FormattingEnabled = True
        Me.Comb_find.Location = New System.Drawing.Point(114, 7)
        Me.Comb_find.Name = "Comb_find"
        Me.Comb_find.Size = New System.Drawing.Size(454, 21)
        Me.Comb_find.TabIndex = 38
        '
        'Lbl_replace
        '
        Me.Lbl_replace.Location = New System.Drawing.Point(8, 35)
        Me.Lbl_replace.Name = "Lbl_replace"
        Me.Lbl_replace.Size = New System.Drawing.Size(100, 23)
        Me.Lbl_replace.TabIndex = 36
        Me.Lbl_replace.Text = "Replace with:"
        Me.Lbl_replace.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_find
        '
        Me.Lbl_find.Location = New System.Drawing.Point(8, 6)
        Me.Lbl_find.Name = "Lbl_find"
        Me.Lbl_find.Size = New System.Drawing.Size(100, 23)
        Me.Lbl_find.TabIndex = 37
        Me.Lbl_find.Text = "Find what:"
        Me.Lbl_find.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FindReplaceHighlighting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 371)
        Me.Controls.Add(Me.Pal_matchSettings)
        Me.Controls.Add(Me.Pal_searchMode)
        Me.Controls.Add(Me.Pal_find_replace)
        Me.Controls.Add(Me.TabC_mode)
        Me.Controls.Add(Me.SS_info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(100000, 410)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(550, 410)
        Me.Name = "FindReplaceMark"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find / Replace / Mark"
        Me.TabC_mode.ResumeLayout(False)
        Me.Tabp_find.ResumeLayout(False)
        Me.Tabp_replace.ResumeLayout(False)
        Me.Tabp_findInFiles.ResumeLayout(False)
        Me.Tabp_findInFiles.PerformLayout()
        Me.Tabp_mark.ResumeLayout(False)
        Me.Tabp_mark.PerformLayout()
        Me.Pal_searchMode.ResumeLayout(False)
        Me.Pal_searchMode.PerformLayout()
        Me.Gb_transparency.ResumeLayout(False)
        Me.Gb_transparency.PerformLayout()
        CType(Me.Trackb_transparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_searchMode.ResumeLayout(False)
        Me.Gb_searchMode.PerformLayout()
        Me.Pal_matchSettings.ResumeLayout(False)
        Me.Pal_matchSettings.PerformLayout()
        Me.Pal_find_replace.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SS_info As StatusStrip
    Friend WithEvents TabC_mode As TabControl
    Friend WithEvents Tabp_find As TabPage
    Friend WithEvents Tabp_replace As TabPage
    Friend WithEvents Tabp_findInFiles As TabPage
    Friend WithEvents Tabp_mark As TabPage
    Friend WithEvents Pal_searchMode As Panel
    Friend WithEvents Btn_close As Button
    Friend WithEvents Btn_count As Button
    Friend WithEvents Btn_find_reverse As Button
    Friend WithEvents Btn_find As Button
    Friend WithEvents Btn_close_1 As Button
    Friend WithEvents Btn_replaceAll As Button
    Friend WithEvents Btn_replace As Button
    Friend WithEvents Btn_find_reverse_1 As Button
    Friend WithEvents Btn_find_1 As Button
    Friend WithEvents Btn_close_3 As Button
    Friend WithEvents Btn_clearMarks As Button
    Friend WithEvents Btn_mark As Button
    Friend WithEvents Cb_hiddenFolders As CheckBox
    Friend WithEvents Cb_subfolders As CheckBox
    Friend WithEvents Btn_directory As Button
    Friend WithEvents Lbl_directory As Label
    Friend WithEvents Btn_close_2 As Button
    Friend WithEvents Btn_replaceInFiles As Button
    Friend WithEvents Btn_searchInFiles As Button
    Friend WithEvents Lbl_filters As Label
    Friend WithEvents Cb_clearBookmarks As CheckBox
    Friend WithEvents Cb_bookmark As CheckBox
    Friend WithEvents Pal_matchSettings As Panel
    Friend WithEvents Gb_searchMode As GroupBox
    Friend WithEvents Rb_search_regex As RadioButton
    Friend WithEvents Rb_search_extended As RadioButton
    Friend WithEvents Rb_search_normal As RadioButton
    Friend WithEvents Cb_wrapAround As CheckBox
    Friend WithEvents Cb_case As CheckBox
    Friend WithEvents Cb_wholeWord As CheckBox
    Friend WithEvents Comb_filters As ComboBox
    Friend WithEvents Comb_directory As ComboBox
    Friend WithEvents Gb_transparency As GroupBox
    Friend WithEvents Trackb_transparency As TrackBar
    Friend WithEvents Rb_trans_always As RadioButton
    Friend WithEvents Rb_trans_losing As RadioButton
    Friend WithEvents Pal_hrFake As Panel
    Friend WithEvents Cb_transparency As CheckBox
    Friend WithEvents Pal_find_replace As Panel
    Friend WithEvents Comb_replace As ComboBox
    Friend WithEvents Comb_find As ComboBox
    Friend WithEvents Lbl_replace As Label
    Friend WithEvents Lbl_find As Label
    Friend WithEvents Cb_selections As CheckBox
End Class
