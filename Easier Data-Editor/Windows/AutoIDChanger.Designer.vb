<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoIDChanger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoIDChanger))
        Me.Lbl_title = New System.Windows.Forms.Label()
        Me.Lbl_descripition = New System.Windows.Forms.Label()
        Me.Btn_close = New System.Windows.Forms.Button()
        Me.Btn_apply = New System.Windows.Forms.Button()
        Me.Lbl_index = New System.Windows.Forms.Label()
        Me.Nud_index = New System.Windows.Forms.NumericUpDown()
        Me.Gb_options = New System.Windows.Forms.GroupBox()
        Me.Rb_add = New System.Windows.Forms.RadioButton()
        Me.Rb_set = New System.Windows.Forms.RadioButton()
        Me.Cb_hit = New System.Windows.Forms.CheckBox()
        Me.Cb_pic = New System.Windows.Forms.CheckBox()
        CType(Me.Nud_index, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_options.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_title
        '
        Me.Lbl_title.AutoSize = True
        Me.Lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_title.Location = New System.Drawing.Point(27, 24)
        Me.Lbl_title.Name = "Lbl_title"
        Me.Lbl_title.Size = New System.Drawing.Size(241, 25)
        Me.Lbl_title.TabIndex = 2
        Me.Lbl_title.Text = "Automatic ID Changer"
        '
        'Lbl_descripition
        '
        Me.Lbl_descripition.AutoSize = True
        Me.Lbl_descripition.Location = New System.Drawing.Point(29, 57)
        Me.Lbl_descripition.Name = "Lbl_descripition"
        Me.Lbl_descripition.Size = New System.Drawing.Size(514, 13)
        Me.Lbl_descripition.TabIndex = 3
        Me.Lbl_descripition.Text = "This tool changes the IDs, next-values, (optional) pic-values and (optional) hit_" &
    "-values of all selected frames."
        '
        'Btn_close
        '
        Me.Btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_close.Location = New System.Drawing.Point(27, 248)
        Me.Btn_close.Name = "Btn_close"
        Me.Btn_close.Size = New System.Drawing.Size(100, 25)
        Me.Btn_close.TabIndex = 7
        Me.Btn_close.Text = "Close"
        Me.Btn_close.UseVisualStyleBackColor = True
        '
        'Btn_apply
        '
        Me.Btn_apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_apply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_apply.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_apply.Location = New System.Drawing.Point(432, 248)
        Me.Btn_apply.Name = "Btn_apply"
        Me.Btn_apply.Size = New System.Drawing.Size(100, 25)
        Me.Btn_apply.TabIndex = 6
        Me.Btn_apply.Text = "Apply"
        Me.Btn_apply.UseVisualStyleBackColor = True
        '
        'Lbl_index
        '
        Me.Lbl_index.AutoSize = True
        Me.Lbl_index.Location = New System.Drawing.Point(29, 88)
        Me.Lbl_index.Name = "Lbl_index"
        Me.Lbl_index.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_index.TabIndex = 8
        Me.Lbl_index.Text = "Value:"
        '
        'Nud_index
        '
        Me.Nud_index.Location = New System.Drawing.Point(81, 86)
        Me.Nud_index.Maximum = New Decimal(New Integer() {398, 0, 0, 0})
        Me.Nud_index.Minimum = New Decimal(New Integer() {398, 0, 0, -2147483648})
        Me.Nud_index.Name = "Nud_index"
        Me.Nud_index.Size = New System.Drawing.Size(120, 20)
        Me.Nud_index.TabIndex = 9
        '
        'Gb_options
        '
        Me.Gb_options.Controls.Add(Me.Rb_add)
        Me.Gb_options.Controls.Add(Me.Rb_set)
        Me.Gb_options.Controls.Add(Me.Cb_hit)
        Me.Gb_options.Controls.Add(Me.Cb_pic)
        Me.Gb_options.Location = New System.Drawing.Point(27, 123)
        Me.Gb_options.Name = "Gb_options"
        Me.Gb_options.Padding = New System.Windows.Forms.Padding(9)
        Me.Gb_options.Size = New System.Drawing.Size(505, 110)
        Me.Gb_options.TabIndex = 10
        Me.Gb_options.TabStop = False
        Me.Gb_options.Text = "Options"
        '
        'Rb_add
        '
        Me.Rb_add.AutoSize = True
        Me.Rb_add.Location = New System.Drawing.Point(12, 47)
        Me.Rb_add.Name = "Rb_add"
        Me.Rb_add.Size = New System.Drawing.Size(287, 17)
        Me.Rb_add.TabIndex = 1
        Me.Rb_add.Text = "Adds ""value"" to all selected frames IDs and next-values"
        Me.Rb_add.UseVisualStyleBackColor = True
        '
        'Rb_set
        '
        Me.Rb_set.AutoSize = True
        Me.Rb_set.Checked = True
        Me.Rb_set.Location = New System.Drawing.Point(12, 25)
        Me.Rb_set.Name = "Rb_set"
        Me.Rb_set.Size = New System.Drawing.Size(326, 17)
        Me.Rb_set.TabIndex = 1
        Me.Rb_set.TabStop = True
        Me.Rb_set.Text = "Sets ""value"" to the first selected frame and counts up automatic"
        Me.Rb_set.UseVisualStyleBackColor = True
        '
        'Cb_hit
        '
        Me.Cb_hit.AutoSize = True
        Me.Cb_hit.Location = New System.Drawing.Point(12, 82)
        Me.Cb_hit.Name = "Cb_hit"
        Me.Cb_hit.Size = New System.Drawing.Size(105, 17)
        Me.Cb_hit.TabIndex = 0
        Me.Cb_hit.Text = "too ""hit_""-values"
        Me.Cb_hit.UseVisualStyleBackColor = True
        '
        'Cb_pic
        '
        Me.Cb_pic.AutoSize = True
        Me.Cb_pic.Location = New System.Drawing.Point(177, 82)
        Me.Cb_pic.Name = "Cb_pic"
        Me.Cb_pic.Size = New System.Drawing.Size(102, 17)
        Me.Cb_pic.TabIndex = 0
        Me.Cb_pic.Text = "too ""pic""-values"
        Me.Cb_pic.UseVisualStyleBackColor = True
        '
        'AutoIDChanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 300)
        Me.Controls.Add(Me.Gb_options)
        Me.Controls.Add(Me.Nud_index)
        Me.Controls.Add(Me.Lbl_index)
        Me.Controls.Add(Me.Btn_close)
        Me.Controls.Add(Me.Btn_apply)
        Me.Controls.Add(Me.Lbl_descripition)
        Me.Controls.Add(Me.Lbl_title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoIDChanger"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Automatic ID Changer"
        CType(Me.Nud_index, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_options.ResumeLayout(False)
        Me.Gb_options.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_title As Label
    Friend WithEvents Lbl_descripition As Label
    Friend WithEvents Btn_close As Button
    Friend WithEvents Btn_apply As Button
    Friend WithEvents Lbl_index As Label
    Friend WithEvents Nud_index As NumericUpDown
    Friend WithEvents Gb_options As GroupBox
    Friend WithEvents Rb_add As RadioButton
    Friend WithEvents Rb_set As RadioButton
    Friend WithEvents Cb_hit As CheckBox
    Friend WithEvents Cb_pic As CheckBox
End Class
