<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ui_search
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_search))
        Me.btn_find = New System.Windows.Forms.Button()
        Me.txt_find = New System.Windows.Forms.TextBox()
        Me.gb_direction = New System.Windows.Forms.GroupBox()
        Me.rb_backward = New System.Windows.Forms.RadioButton()
        Me.rb_forward = New System.Windows.Forms.RadioButton()
        Me.gb_options = New System.Windows.Forms.GroupBox()
        Me.cb_match_case = New System.Windows.Forms.CheckBox()
        Me.cb_matchwholeword = New System.Windows.Forms.CheckBox()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.lbl_replace = New System.Windows.Forms.Label()
        Me.txt_replace = New System.Windows.Forms.TextBox()
        Me.btn_replace = New System.Windows.Forms.Button()
        Me.gb_start = New System.Windows.Forms.GroupBox()
        Me.rb_cursor = New System.Windows.Forms.RadioButton()
        Me.rb_file_beginning = New System.Windows.Forms.RadioButton()
        Me.btn_find_reverse = New System.Windows.Forms.Button()
        Me.btn_find_beginning = New System.Windows.Forms.Button()
        Me.btn_replace_all = New System.Windows.Forms.Button()
        Me.lbl_find = New System.Windows.Forms.Label()
        Me.gb_direction.SuspendLayout()
        Me.gb_options.SuspendLayout()
        Me.gb_start.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_find
        '
        Me.btn_find.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_find.Location = New System.Drawing.Point(495, 23)
        Me.btn_find.Name = "btn_find"
        Me.btn_find.Size = New System.Drawing.Size(50, 23)
        Me.btn_find.TabIndex = 4
        Me.btn_find.Text = "Find >"
        Me.btn_find.UseVisualStyleBackColor = True
        '
        'txt_find
        '
        Me.txt_find.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_find.Location = New System.Drawing.Point(100, 25)
        Me.txt_find.Name = "txt_find"
        Me.txt_find.Size = New System.Drawing.Size(340, 20)
        Me.txt_find.TabIndex = 1
        '
        'gb_direction
        '
        Me.gb_direction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gb_direction.Controls.Add(Me.rb_backward)
        Me.gb_direction.Controls.Add(Me.rb_forward)
        Me.gb_direction.Location = New System.Drawing.Point(164, 100)
        Me.gb_direction.Name = "gb_direction"
        Me.gb_direction.Padding = New System.Windows.Forms.Padding(6)
        Me.gb_direction.Size = New System.Drawing.Size(135, 73)
        Me.gb_direction.TabIndex = 9
        Me.gb_direction.TabStop = False
        Me.gb_direction.Text = "Direction"
        '
        'rb_backward
        '
        Me.rb_backward.AutoSize = True
        Me.rb_backward.Location = New System.Drawing.Point(9, 45)
        Me.rb_backward.Name = "rb_backward"
        Me.rb_backward.Size = New System.Drawing.Size(73, 17)
        Me.rb_backward.TabIndex = 1
        Me.rb_backward.TabStop = True
        Me.rb_backward.Text = "Backward"
        Me.rb_backward.UseVisualStyleBackColor = True
        '
        'rb_forward
        '
        Me.rb_forward.AutoSize = True
        Me.rb_forward.Location = New System.Drawing.Point(9, 22)
        Me.rb_forward.Name = "rb_forward"
        Me.rb_forward.Size = New System.Drawing.Size(63, 17)
        Me.rb_forward.TabIndex = 0
        Me.rb_forward.TabStop = True
        Me.rb_forward.Text = "Forward"
        Me.rb_forward.UseVisualStyleBackColor = True
        '
        'gb_options
        '
        Me.gb_options.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gb_options.Controls.Add(Me.cb_match_case)
        Me.gb_options.Controls.Add(Me.cb_matchwholeword)
        Me.gb_options.Location = New System.Drawing.Point(305, 100)
        Me.gb_options.Name = "gb_options"
        Me.gb_options.Padding = New System.Windows.Forms.Padding(6)
        Me.gb_options.Size = New System.Drawing.Size(135, 73)
        Me.gb_options.TabIndex = 10
        Me.gb_options.TabStop = False
        Me.gb_options.Text = "Options"
        '
        'cb_match_case
        '
        Me.cb_match_case.AutoSize = True
        Me.cb_match_case.Location = New System.Drawing.Point(9, 23)
        Me.cb_match_case.Name = "cb_match_case"
        Me.cb_match_case.Size = New System.Drawing.Size(83, 17)
        Me.cb_match_case.TabIndex = 0
        Me.cb_match_case.Text = "Match Case"
        Me.cb_match_case.UseVisualStyleBackColor = True
        '
        'cb_matchwholeword
        '
        Me.cb_matchwholeword.AutoSize = True
        Me.cb_matchwholeword.Location = New System.Drawing.Point(9, 46)
        Me.cb_matchwholeword.Name = "cb_matchwholeword"
        Me.cb_matchwholeword.Size = New System.Drawing.Size(119, 17)
        Me.cb_matchwholeword.TabIndex = 1
        Me.cb_matchwholeword.Text = "Match Whole Word"
        Me.cb_matchwholeword.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel.Location = New System.Drawing.Point(446, 150)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(100, 23)
        Me.btn_cancel.TabIndex = 11
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'lbl_replace
        '
        Me.lbl_replace.AutoSize = True
        Me.lbl_replace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_replace.Location = New System.Drawing.Point(23, 57)
        Me.lbl_replace.Name = "lbl_replace"
        Me.lbl_replace.Size = New System.Drawing.Size(71, 13)
        Me.lbl_replace.TabIndex = 2
        Me.lbl_replace.Text = "       Replace:"
        Me.lbl_replace.Visible = False
        '
        'txt_replace
        '
        Me.txt_replace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_replace.Location = New System.Drawing.Point(100, 54)
        Me.txt_replace.Name = "txt_replace"
        Me.txt_replace.Size = New System.Drawing.Size(340, 20)
        Me.txt_replace.TabIndex = 3
        Me.txt_replace.Visible = False
        '
        'btn_replace
        '
        Me.btn_replace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_replace.Location = New System.Drawing.Point(446, 52)
        Me.btn_replace.Name = "btn_replace"
        Me.btn_replace.Size = New System.Drawing.Size(99, 23)
        Me.btn_replace.TabIndex = 7
        Me.btn_replace.Text = "Replace Next"
        Me.btn_replace.UseVisualStyleBackColor = True
        Me.btn_replace.Visible = False
        '
        'gb_start
        '
        Me.gb_start.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gb_start.Controls.Add(Me.rb_cursor)
        Me.gb_start.Controls.Add(Me.rb_file_beginning)
        Me.gb_start.Location = New System.Drawing.Point(23, 100)
        Me.gb_start.Name = "gb_start"
        Me.gb_start.Padding = New System.Windows.Forms.Padding(6)
        Me.gb_start.Size = New System.Drawing.Size(135, 73)
        Me.gb_start.TabIndex = 8
        Me.gb_start.TabStop = False
        Me.gb_start.Text = "Start"
        '
        'rb_cursor
        '
        Me.rb_cursor.AutoSize = True
        Me.rb_cursor.Location = New System.Drawing.Point(9, 45)
        Me.rb_cursor.Name = "rb_cursor"
        Me.rb_cursor.Size = New System.Drawing.Size(55, 17)
        Me.rb_cursor.TabIndex = 1
        Me.rb_cursor.TabStop = True
        Me.rb_cursor.Text = "Cursor"
        Me.rb_cursor.UseVisualStyleBackColor = True
        '
        'rb_file_beginning
        '
        Me.rb_file_beginning.AutoSize = True
        Me.rb_file_beginning.Location = New System.Drawing.Point(9, 22)
        Me.rb_file_beginning.Name = "rb_file_beginning"
        Me.rb_file_beginning.Size = New System.Drawing.Size(91, 17)
        Me.rb_file_beginning.TabIndex = 0
        Me.rb_file_beginning.TabStop = True
        Me.rb_file_beginning.Text = "File Beginning"
        Me.rb_file_beginning.UseVisualStyleBackColor = True
        '
        'btn_find_reverse
        '
        Me.btn_find_reverse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_find_reverse.Location = New System.Drawing.Point(446, 23)
        Me.btn_find_reverse.Name = "btn_find_reverse"
        Me.btn_find_reverse.Size = New System.Drawing.Size(50, 23)
        Me.btn_find_reverse.TabIndex = 5
        Me.btn_find_reverse.Text = "< Find"
        Me.btn_find_reverse.UseVisualStyleBackColor = True
        '
        'btn_find_beginning
        '
        Me.btn_find_beginning.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_find_beginning.Location = New System.Drawing.Point(446, 23)
        Me.btn_find_beginning.Name = "btn_find_beginning"
        Me.btn_find_beginning.Size = New System.Drawing.Size(99, 23)
        Me.btn_find_beginning.TabIndex = 6
        Me.btn_find_beginning.Text = "Find"
        Me.btn_find_beginning.UseVisualStyleBackColor = True
        '
        'btn_replace_all
        '
        Me.btn_replace_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_replace_all.Location = New System.Drawing.Point(446, 81)
        Me.btn_replace_all.Name = "btn_replace_all"
        Me.btn_replace_all.Size = New System.Drawing.Size(99, 23)
        Me.btn_replace_all.TabIndex = 12
        Me.btn_replace_all.Text = "Replace All"
        Me.btn_replace_all.UseVisualStyleBackColor = True
        Me.btn_replace_all.Visible = False
        '
        'lbl_find
        '
        Me.lbl_find.AutoSize = True
        Me.lbl_find.Image = Global.Easier_Data_Editor.My.Resources.Resources.arrow_bottom
        Me.lbl_find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_find.Location = New System.Drawing.Point(23, 28)
        Me.lbl_find.Name = "lbl_find"
        Me.lbl_find.Size = New System.Drawing.Size(51, 13)
        Me.lbl_find.TabIndex = 0
        Me.lbl_find.Text = "       Find:"
        '
        'ui_search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 196)
        Me.Controls.Add(Me.btn_replace_all)
        Me.Controls.Add(Me.btn_find_reverse)
        Me.Controls.Add(Me.gb_start)
        Me.Controls.Add(Me.btn_replace)
        Me.Controls.Add(Me.txt_replace)
        Me.Controls.Add(Me.lbl_replace)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.gb_options)
        Me.Controls.Add(Me.gb_direction)
        Me.Controls.Add(Me.txt_find)
        Me.Controls.Add(Me.btn_find)
        Me.Controls.Add(Me.lbl_find)
        Me.Controls.Add(Me.btn_find_beginning)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1585, 235)
        Me.MinimumSize = New System.Drawing.Size(585, 235)
        Me.Name = "ui_search"
        Me.Opacity = 0.2R
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor (STM93 Version) - Search"
        Me.gb_direction.ResumeLayout(False)
        Me.gb_direction.PerformLayout()
        Me.gb_options.ResumeLayout(False)
        Me.gb_options.PerformLayout()
        Me.gb_start.ResumeLayout(False)
        Me.gb_start.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_find As Label
    Friend WithEvents btn_find As Button
    Friend WithEvents txt_find As TextBox
    Friend WithEvents gb_direction As GroupBox
    Friend WithEvents gb_options As GroupBox
    Friend WithEvents btn_cancel As Button
    Friend WithEvents lbl_replace As Label
    Friend WithEvents txt_replace As TextBox
    Friend WithEvents btn_replace As Button
    Friend WithEvents rb_backward As RadioButton
    Friend WithEvents rb_forward As RadioButton
    Friend WithEvents cb_matchwholeword As CheckBox
    Friend WithEvents cb_match_case As CheckBox
    Friend WithEvents gb_start As GroupBox
    Friend WithEvents rb_cursor As RadioButton
    Friend WithEvents rb_file_beginning As RadioButton
    Friend WithEvents btn_find_reverse As Button
    Friend WithEvents btn_find_beginning As Button
    Friend WithEvents btn_replace_all As Button
End Class
