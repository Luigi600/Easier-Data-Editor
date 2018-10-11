<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_id_changer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_id_changer))
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.lbl_descripition = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_apply = New System.Windows.Forms.Button()
        Me.lbl_index = New System.Windows.Forms.Label()
        Me.nud_index = New System.Windows.Forms.NumericUpDown()
        Me.gb_options = New System.Windows.Forms.GroupBox()
        Me.rb_add = New System.Windows.Forms.RadioButton()
        Me.rb_set = New System.Windows.Forms.RadioButton()
        Me.cb_hit = New System.Windows.Forms.CheckBox()
        Me.cb_pic = New System.Windows.Forms.CheckBox()
        CType(Me.nud_index, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_options.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(27, 24)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(185, 25)
        Me.lbl_title.TabIndex = 2
        Me.lbl_title.Text = "Auto ID Changer"
        '
        'lbl_descripition
        '
        Me.lbl_descripition.AutoSize = True
        Me.lbl_descripition.Location = New System.Drawing.Point(29, 57)
        Me.lbl_descripition.Name = "lbl_descripition"
        Me.lbl_descripition.Size = New System.Drawing.Size(485, 13)
        Me.lbl_descripition.TabIndex = 3
        Me.lbl_descripition.Text = "Select a index to start. Frame IDs, next-values, (optional) pic-values, (optional" &
    ") hit_-values will change."
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_close.Location = New System.Drawing.Point(27, 248)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(100, 25)
        Me.btn_close.TabIndex = 7
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_apply
        '
        Me.btn_apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_apply.Location = New System.Drawing.Point(421, 248)
        Me.btn_apply.Name = "btn_apply"
        Me.btn_apply.Size = New System.Drawing.Size(100, 25)
        Me.btn_apply.TabIndex = 6
        Me.btn_apply.Text = "Apply"
        Me.btn_apply.UseVisualStyleBackColor = True
        '
        'lbl_index
        '
        Me.lbl_index.AutoSize = True
        Me.lbl_index.Location = New System.Drawing.Point(29, 87)
        Me.lbl_index.Name = "lbl_index"
        Me.lbl_index.Size = New System.Drawing.Size(60, 13)
        Me.lbl_index.TabIndex = 8
        Me.lbl_index.Text = "Start index:"
        '
        'nud_index
        '
        Me.nud_index.Location = New System.Drawing.Point(132, 85)
        Me.nud_index.Maximum = New Decimal(New Integer() {398, 0, 0, 0})
        Me.nud_index.Minimum = New Decimal(New Integer() {398, 0, 0, -2147483648})
        Me.nud_index.Name = "nud_index"
        Me.nud_index.Size = New System.Drawing.Size(120, 20)
        Me.nud_index.TabIndex = 9
        '
        'gb_options
        '
        Me.gb_options.Controls.Add(Me.rb_add)
        Me.gb_options.Controls.Add(Me.rb_set)
        Me.gb_options.Controls.Add(Me.cb_hit)
        Me.gb_options.Controls.Add(Me.cb_pic)
        Me.gb_options.Location = New System.Drawing.Point(27, 123)
        Me.gb_options.Name = "gb_options"
        Me.gb_options.Padding = New System.Windows.Forms.Padding(9)
        Me.gb_options.Size = New System.Drawing.Size(278, 110)
        Me.gb_options.TabIndex = 10
        Me.gb_options.TabStop = False
        Me.gb_options.Text = "Options"
        '
        'rb_add
        '
        Me.rb_add.AutoSize = True
        Me.rb_add.Location = New System.Drawing.Point(123, 25)
        Me.rb_add.Name = "rb_add"
        Me.rb_add.Size = New System.Drawing.Size(141, 17)
        Me.rb_add.TabIndex = 1
        Me.rb_add.Text = "Add index to existing IDs"
        Me.rb_add.UseVisualStyleBackColor = True
        '
        'rb_set
        '
        Me.rb_set.AutoSize = True
        Me.rb_set.Checked = True
        Me.rb_set.Location = New System.Drawing.Point(12, 25)
        Me.rb_set.Name = "rb_set"
        Me.rb_set.Size = New System.Drawing.Size(69, 17)
        Me.rb_set.TabIndex = 1
        Me.rb_set.TabStop = True
        Me.rb_set.Text = "Set index"
        Me.rb_set.UseVisualStyleBackColor = True
        '
        'cb_hit
        '
        Me.cb_hit.AutoSize = True
        Me.cb_hit.Location = New System.Drawing.Point(12, 84)
        Me.cb_hit.Name = "cb_hit"
        Me.cb_hit.Size = New System.Drawing.Size(109, 17)
        Me.cb_hit.TabIndex = 0
        Me.cb_hit.Text = "with ""hit_""-values"
        Me.cb_hit.UseVisualStyleBackColor = True
        '
        'cb_pic
        '
        Me.cb_pic.AutoSize = True
        Me.cb_pic.Location = New System.Drawing.Point(12, 61)
        Me.cb_pic.Name = "cb_pic"
        Me.cb_pic.Size = New System.Drawing.Size(106, 17)
        Me.cb_pic.TabIndex = 0
        Me.cb_pic.Text = "with ""pic""-values"
        Me.cb_pic.UseVisualStyleBackColor = True
        '
        'ui_id_changer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 300)
        Me.Controls.Add(Me.gb_options)
        Me.Controls.Add(Me.nud_index)
        Me.Controls.Add(Me.lbl_index)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_apply)
        Me.Controls.Add(Me.lbl_descripition)
        Me.Controls.Add(Me.lbl_title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ui_id_changer"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor - Auto ID Changer"
        CType(Me.nud_index, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_options.ResumeLayout(False)
        Me.gb_options.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_title As Label
    Friend WithEvents lbl_descripition As Label
    Friend WithEvents btn_close As Button
    Friend WithEvents btn_apply As Button
    Friend WithEvents lbl_index As Label
    Friend WithEvents nud_index As NumericUpDown
    Friend WithEvents gb_options As GroupBox
    Friend WithEvents rb_add As RadioButton
    Friend WithEvents rb_set As RadioButton
    Friend WithEvents cb_hit As CheckBox
    Friend WithEvents cb_pic As CheckBox
End Class
