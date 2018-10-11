<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_settings))
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.lbl_recentFiles = New System.Windows.Forms.Label()
        Me.nud_maxRecentFiles = New System.Windows.Forms.NumericUpDown()
        Me.lbl_lastSession = New System.Windows.Forms.Label()
        Me.cb_saveSession = New System.Windows.Forms.CheckBox()
        Me.cb_ms = New System.Windows.Forms.CheckBox()
        Me.txt_fontFamily = New System.Windows.Forms.TextBox()
        Me.lbl_fontFamily = New System.Windows.Forms.Label()
        Me.nud_fontSize = New System.Windows.Forms.NumericUpDown()
        Me.lbl_fontSize = New System.Windows.Forms.Label()
        Me.lbl_ms = New System.Windows.Forms.Label()
        Me.lbl_default_bg_col = New System.Windows.Forms.Label()
        Me.pal_bg_color = New System.Windows.Forms.Panel()
        Me.btn_select_color = New System.Windows.Forms.Button()
        Me.gb_frameViewer = New System.Windows.Forms.GroupBox()
        Me.cb_auto_viewer = New System.Windows.Forms.CheckBox()
        Me.lbl_auto_viewer = New System.Windows.Forms.Label()
        Me.cb_globalSettings = New System.Windows.Forms.CheckBox()
        Me.lbl_globalSettings = New System.Windows.Forms.Label()
        Me.lbl_directresult = New System.Windows.Forms.Label()
        Me.cb_directResult = New System.Windows.Forms.CheckBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_abort = New System.Windows.Forms.Button()
        Me.btn_selectFont = New System.Windows.Forms.Button()
        Me.cd_default = New System.Windows.Forms.ColorDialog()
        Me.fd_editor = New System.Windows.Forms.FontDialog()
        Me.cb_allow_double = New System.Windows.Forms.CheckBox()
        Me.lbl_doubleOpen = New System.Windows.Forms.Label()
        Me.cb_maximized = New System.Windows.Forms.CheckBox()
        Me.lbl_maximized = New System.Windows.Forms.Label()
        Me.cb_autocomplete = New System.Windows.Forms.CheckBox()
        Me.lbl_autocomplete = New System.Windows.Forms.Label()
        Me.lbl_info = New System.Windows.Forms.Label()
        Me.cb_folding = New System.Windows.Forms.CheckBox()
        Me.lbl_folding = New System.Windows.Forms.Label()
        CType(Me.nud_maxRecentFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_fontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_frameViewer.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(27, 24)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(98, 25)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Settings"
        '
        'lbl_recentFiles
        '
        Me.lbl_recentFiles.AutoSize = True
        Me.lbl_recentFiles.Location = New System.Drawing.Point(29, 63)
        Me.lbl_recentFiles.Name = "lbl_recentFiles"
        Me.lbl_recentFiles.Size = New System.Drawing.Size(110, 13)
        Me.lbl_recentFiles.TabIndex = 1
        Me.lbl_recentFiles.Text = "Maximal Recent Files:"
        '
        'nud_maxRecentFiles
        '
        Me.nud_maxRecentFiles.Location = New System.Drawing.Point(185, 61)
        Me.nud_maxRecentFiles.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nud_maxRecentFiles.Name = "nud_maxRecentFiles"
        Me.nud_maxRecentFiles.Size = New System.Drawing.Size(163, 20)
        Me.nud_maxRecentFiles.TabIndex = 2
        '
        'lbl_lastSession
        '
        Me.lbl_lastSession.AutoSize = True
        Me.lbl_lastSession.Location = New System.Drawing.Point(29, 93)
        Me.lbl_lastSession.Name = "lbl_lastSession"
        Me.lbl_lastSession.Size = New System.Drawing.Size(94, 13)
        Me.lbl_lastSession.TabIndex = 3
        Me.lbl_lastSession.Text = "Save last Session:"
        '
        'cb_saveSession
        '
        Me.cb_saveSession.AutoSize = True
        Me.cb_saveSession.Location = New System.Drawing.Point(185, 93)
        Me.cb_saveSession.Name = "cb_saveSession"
        Me.cb_saveSession.Size = New System.Drawing.Size(15, 14)
        Me.cb_saveSession.TabIndex = 4
        Me.cb_saveSession.UseVisualStyleBackColor = True
        '
        'cb_ms
        '
        Me.cb_ms.AutoSize = True
        Me.cb_ms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_ms.Location = New System.Drawing.Point(168, 31)
        Me.cb_ms.Name = "cb_ms"
        Me.cb_ms.Size = New System.Drawing.Size(15, 14)
        Me.cb_ms.TabIndex = 14
        Me.cb_ms.UseVisualStyleBackColor = True
        '
        'txt_fontFamily
        '
        Me.txt_fontFamily.Location = New System.Drawing.Point(185, 117)
        Me.txt_fontFamily.Name = "txt_fontFamily"
        Me.txt_fontFamily.ReadOnly = True
        Me.txt_fontFamily.Size = New System.Drawing.Size(126, 20)
        Me.txt_fontFamily.TabIndex = 6
        '
        'lbl_fontFamily
        '
        Me.lbl_fontFamily.AutoSize = True
        Me.lbl_fontFamily.Location = New System.Drawing.Point(29, 120)
        Me.lbl_fontFamily.Name = "lbl_fontFamily"
        Me.lbl_fontFamily.Size = New System.Drawing.Size(63, 13)
        Me.lbl_fontFamily.TabIndex = 5
        Me.lbl_fontFamily.Text = "Font Family:"
        '
        'nud_fontSize
        '
        Me.nud_fontSize.DecimalPlaces = 1
        Me.nud_fontSize.Location = New System.Drawing.Point(185, 148)
        Me.nud_fontSize.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nud_fontSize.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nud_fontSize.Name = "nud_fontSize"
        Me.nud_fontSize.Size = New System.Drawing.Size(163, 20)
        Me.nud_fontSize.TabIndex = 9
        Me.nud_fontSize.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lbl_fontSize
        '
        Me.lbl_fontSize.AutoSize = True
        Me.lbl_fontSize.Location = New System.Drawing.Point(29, 150)
        Me.lbl_fontSize.Name = "lbl_fontSize"
        Me.lbl_fontSize.Size = New System.Drawing.Size(54, 13)
        Me.lbl_fontSize.TabIndex = 8
        Me.lbl_fontSize.Text = "Font Size:"
        '
        'lbl_ms
        '
        Me.lbl_ms.AutoSize = True
        Me.lbl_ms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ms.Location = New System.Drawing.Point(21, 31)
        Me.lbl_ms.Name = "lbl_ms"
        Me.lbl_ms.Size = New System.Drawing.Size(96, 13)
        Me.lbl_ms.TabIndex = 13
        Me.lbl_ms.Text = "Shows Menu Strip:"
        '
        'lbl_default_bg_col
        '
        Me.lbl_default_bg_col.AutoSize = True
        Me.lbl_default_bg_col.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_default_bg_col.Location = New System.Drawing.Point(20, 57)
        Me.lbl_default_bg_col.Name = "lbl_default_bg_col"
        Me.lbl_default_bg_col.Size = New System.Drawing.Size(132, 13)
        Me.lbl_default_bg_col.TabIndex = 15
        Me.lbl_default_bg_col.Text = "Default Background Color:"
        '
        'pal_bg_color
        '
        Me.pal_bg_color.Location = New System.Drawing.Point(168, 52)
        Me.pal_bg_color.Name = "pal_bg_color"
        Me.pal_bg_color.Size = New System.Drawing.Size(77, 23)
        Me.pal_bg_color.TabIndex = 16
        '
        'btn_select_color
        '
        Me.btn_select_color.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_select_color.Location = New System.Drawing.Point(251, 52)
        Me.btn_select_color.Name = "btn_select_color"
        Me.btn_select_color.Size = New System.Drawing.Size(50, 23)
        Me.btn_select_color.TabIndex = 17
        Me.btn_select_color.Text = "..."
        Me.btn_select_color.UseVisualStyleBackColor = True
        '
        'gb_frameViewer
        '
        Me.gb_frameViewer.Controls.Add(Me.cb_auto_viewer)
        Me.gb_frameViewer.Controls.Add(Me.lbl_auto_viewer)
        Me.gb_frameViewer.Controls.Add(Me.cb_globalSettings)
        Me.gb_frameViewer.Controls.Add(Me.lbl_globalSettings)
        Me.gb_frameViewer.Controls.Add(Me.lbl_directresult)
        Me.gb_frameViewer.Controls.Add(Me.cb_directResult)
        Me.gb_frameViewer.Controls.Add(Me.btn_select_color)
        Me.gb_frameViewer.Controls.Add(Me.pal_bg_color)
        Me.gb_frameViewer.Controls.Add(Me.cb_ms)
        Me.gb_frameViewer.Controls.Add(Me.lbl_default_bg_col)
        Me.gb_frameViewer.Controls.Add(Me.lbl_ms)
        Me.gb_frameViewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_frameViewer.Location = New System.Drawing.Point(27, 287)
        Me.gb_frameViewer.Name = "gb_frameViewer"
        Me.gb_frameViewer.Padding = New System.Windows.Forms.Padding(18)
        Me.gb_frameViewer.Size = New System.Drawing.Size(324, 175)
        Me.gb_frameViewer.TabIndex = 12
        Me.gb_frameViewer.TabStop = False
        Me.gb_frameViewer.Text = "Frame Viewer"
        '
        'cb_auto_viewer
        '
        Me.cb_auto_viewer.AutoSize = True
        Me.cb_auto_viewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_auto_viewer.Location = New System.Drawing.Point(168, 143)
        Me.cb_auto_viewer.Name = "cb_auto_viewer"
        Me.cb_auto_viewer.Size = New System.Drawing.Size(15, 14)
        Me.cb_auto_viewer.TabIndex = 23
        Me.cb_auto_viewer.UseVisualStyleBackColor = True
        '
        'lbl_auto_viewer
        '
        Me.lbl_auto_viewer.AutoSize = True
        Me.lbl_auto_viewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_auto_viewer.Location = New System.Drawing.Point(21, 137)
        Me.lbl_auto_viewer.Name = "lbl_auto_viewer"
        Me.lbl_auto_viewer.Size = New System.Drawing.Size(102, 26)
        Me.lbl_auto_viewer.TabIndex = 22
        Me.lbl_auto_viewer.Text = "Opens automatically" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when File Opening:"
        '
        'cb_globalSettings
        '
        Me.cb_globalSettings.AutoSize = True
        Me.cb_globalSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_globalSettings.Location = New System.Drawing.Point(168, 112)
        Me.cb_globalSettings.Name = "cb_globalSettings"
        Me.cb_globalSettings.Size = New System.Drawing.Size(15, 14)
        Me.cb_globalSettings.TabIndex = 21
        Me.cb_globalSettings.UseVisualStyleBackColor = True
        '
        'lbl_globalSettings
        '
        Me.lbl_globalSettings.AutoSize = True
        Me.lbl_globalSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_globalSettings.Location = New System.Drawing.Point(21, 112)
        Me.lbl_globalSettings.Name = "lbl_globalSettings"
        Me.lbl_globalSettings.Size = New System.Drawing.Size(117, 13)
        Me.lbl_globalSettings.TabIndex = 20
        Me.lbl_globalSettings.Text = "Enable Global Settings:"
        '
        'lbl_directresult
        '
        Me.lbl_directresult.AutoSize = True
        Me.lbl_directresult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_directresult.Location = New System.Drawing.Point(21, 86)
        Me.lbl_directresult.Name = "lbl_directresult"
        Me.lbl_directresult.Size = New System.Drawing.Size(110, 13)
        Me.lbl_directresult.TabIndex = 19
        Me.lbl_directresult.Text = "Direct Text Changing:"
        '
        'cb_directResult
        '
        Me.cb_directResult.AutoSize = True
        Me.cb_directResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_directResult.Location = New System.Drawing.Point(168, 86)
        Me.cb_directResult.Name = "cb_directResult"
        Me.cb_directResult.Size = New System.Drawing.Size(130, 17)
        Me.cb_directResult.TabIndex = 18
        Me.cb_directResult.Text = " (more undo and redo)"
        Me.cb_directResult.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Location = New System.Drawing.Point(226, 475)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(125, 30)
        Me.btn_save.TabIndex = 19
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_abort
        '
        Me.btn_abort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_abort.Location = New System.Drawing.Point(27, 475)
        Me.btn_abort.Name = "btn_abort"
        Me.btn_abort.Size = New System.Drawing.Size(125, 30)
        Me.btn_abort.TabIndex = 18
        Me.btn_abort.Text = "Abort"
        Me.btn_abort.UseVisualStyleBackColor = True
        '
        'btn_selectFont
        '
        Me.btn_selectFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectFont.Location = New System.Drawing.Point(317, 115)
        Me.btn_selectFont.Name = "btn_selectFont"
        Me.btn_selectFont.Size = New System.Drawing.Size(34, 23)
        Me.btn_selectFont.TabIndex = 7
        Me.btn_selectFont.Text = "..."
        Me.btn_selectFont.UseVisualStyleBackColor = True
        '
        'cb_allow_double
        '
        Me.cb_allow_double.AutoSize = True
        Me.cb_allow_double.Location = New System.Drawing.Point(185, 179)
        Me.cb_allow_double.Name = "cb_allow_double"
        Me.cb_allow_double.Size = New System.Drawing.Size(15, 14)
        Me.cb_allow_double.TabIndex = 11
        Me.cb_allow_double.UseVisualStyleBackColor = True
        '
        'lbl_doubleOpen
        '
        Me.lbl_doubleOpen.AutoSize = True
        Me.lbl_doubleOpen.Location = New System.Drawing.Point(29, 179)
        Me.lbl_doubleOpen.Name = "lbl_doubleOpen"
        Me.lbl_doubleOpen.Size = New System.Drawing.Size(115, 13)
        Me.lbl_doubleOpen.TabIndex = 10
        Me.lbl_doubleOpen.Text = "Allow Double Opening:"
        '
        'cb_maximized
        '
        Me.cb_maximized.AutoSize = True
        Me.cb_maximized.Location = New System.Drawing.Point(185, 204)
        Me.cb_maximized.Name = "cb_maximized"
        Me.cb_maximized.Size = New System.Drawing.Size(15, 14)
        Me.cb_maximized.TabIndex = 20
        Me.cb_maximized.UseVisualStyleBackColor = True
        '
        'lbl_maximized
        '
        Me.lbl_maximized.AutoSize = True
        Me.lbl_maximized.Location = New System.Drawing.Point(29, 204)
        Me.lbl_maximized.Name = "lbl_maximized"
        Me.lbl_maximized.Size = New System.Drawing.Size(78, 13)
        Me.lbl_maximized.TabIndex = 21
        Me.lbl_maximized.Text = "Start Maximize:"
        '
        'cb_autocomplete
        '
        Me.cb_autocomplete.AutoSize = True
        Me.cb_autocomplete.Location = New System.Drawing.Point(185, 233)
        Me.cb_autocomplete.Name = "cb_autocomplete"
        Me.cb_autocomplete.Size = New System.Drawing.Size(15, 14)
        Me.cb_autocomplete.TabIndex = 20
        Me.cb_autocomplete.UseVisualStyleBackColor = True
        '
        'lbl_autocomplete
        '
        Me.lbl_autocomplete.AutoSize = True
        Me.lbl_autocomplete.Location = New System.Drawing.Point(29, 233)
        Me.lbl_autocomplete.Name = "lbl_autocomplete"
        Me.lbl_autocomplete.Size = New System.Drawing.Size(75, 13)
        Me.lbl_autocomplete.TabIndex = 21
        Me.lbl_autocomplete.Text = "Autocomplete:"
        '
        'lbl_info
        '
        Me.lbl_info.AutoSize = True
        Me.lbl_info.Location = New System.Drawing.Point(206, 242)
        Me.lbl_info.Name = "lbl_info"
        Me.lbl_info.Size = New System.Drawing.Size(108, 13)
        Me.lbl_info.TabIndex = 22
        Me.lbl_info.Text = "(program must reload)"
        '
        'cb_folding
        '
        Me.cb_folding.AutoSize = True
        Me.cb_folding.Location = New System.Drawing.Point(185, 253)
        Me.cb_folding.Name = "cb_folding"
        Me.cb_folding.Size = New System.Drawing.Size(15, 14)
        Me.cb_folding.TabIndex = 20
        Me.cb_folding.UseVisualStyleBackColor = True
        '
        'lbl_folding
        '
        Me.lbl_folding.AutoSize = True
        Me.lbl_folding.Location = New System.Drawing.Point(29, 253)
        Me.lbl_folding.Name = "lbl_folding"
        Me.lbl_folding.Size = New System.Drawing.Size(44, 13)
        Me.lbl_folding.TabIndex = 21
        Me.lbl_folding.Text = "Folding:"
        '
        'ui_settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 532)
        Me.Controls.Add(Me.lbl_folding)
        Me.Controls.Add(Me.lbl_info)
        Me.Controls.Add(Me.cb_folding)
        Me.Controls.Add(Me.lbl_autocomplete)
        Me.Controls.Add(Me.cb_autocomplete)
        Me.Controls.Add(Me.lbl_maximized)
        Me.Controls.Add(Me.cb_maximized)
        Me.Controls.Add(Me.cb_allow_double)
        Me.Controls.Add(Me.lbl_doubleOpen)
        Me.Controls.Add(Me.btn_selectFont)
        Me.Controls.Add(Me.btn_abort)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.gb_frameViewer)
        Me.Controls.Add(Me.lbl_fontSize)
        Me.Controls.Add(Me.lbl_fontFamily)
        Me.Controls.Add(Me.txt_fontFamily)
        Me.Controls.Add(Me.cb_saveSession)
        Me.Controls.Add(Me.lbl_lastSession)
        Me.Controls.Add(Me.nud_fontSize)
        Me.Controls.Add(Me.nud_maxRecentFiles)
        Me.Controls.Add(Me.lbl_recentFiles)
        Me.Controls.Add(Me.lbl_title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ui_settings"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor (STM93 Version) - Settings"
        CType(Me.nud_maxRecentFiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_fontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_frameViewer.ResumeLayout(False)
        Me.gb_frameViewer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_title As Label
    Friend WithEvents lbl_recentFiles As Label
    Friend WithEvents nud_maxRecentFiles As NumericUpDown
    Friend WithEvents lbl_lastSession As Label
    Friend WithEvents cb_saveSession As CheckBox
    Friend WithEvents cb_ms As CheckBox
    Friend WithEvents txt_fontFamily As TextBox
    Friend WithEvents lbl_fontFamily As Label
    Friend WithEvents nud_fontSize As NumericUpDown
    Friend WithEvents lbl_fontSize As Label
    Friend WithEvents lbl_ms As Label
    Friend WithEvents lbl_default_bg_col As Label
    Friend WithEvents pal_bg_color As Panel
    Friend WithEvents btn_select_color As Button
    Friend WithEvents gb_frameViewer As GroupBox
    Friend WithEvents btn_save As Button
    Friend WithEvents btn_abort As Button
    Friend WithEvents btn_selectFont As Button
    Friend WithEvents cd_default As ColorDialog
    Friend WithEvents fd_editor As FontDialog
    Friend WithEvents cb_allow_double As CheckBox
    Friend WithEvents lbl_doubleOpen As Label
    Friend WithEvents lbl_directresult As Label
    Friend WithEvents cb_directResult As CheckBox
    Friend WithEvents cb_globalSettings As CheckBox
    Friend WithEvents lbl_globalSettings As Label
    Friend WithEvents cb_maximized As CheckBox
    Friend WithEvents lbl_maximized As Label
    Friend WithEvents cb_autocomplete As CheckBox
    Friend WithEvents lbl_autocomplete As Label
    Friend WithEvents lbl_info As Label
    Friend WithEvents cb_folding As CheckBox
    Friend WithEvents lbl_folding As Label
    Friend WithEvents cb_auto_viewer As CheckBox
    Friend WithEvents lbl_auto_viewer As Label
End Class
