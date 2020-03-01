<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GoToWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoToWindow))
        Me.Rb_line = New System.Windows.Forms.RadioButton()
        Me.Rb_frame = New System.Windows.Forms.RadioButton()
        Me.Lbl_target = New System.Windows.Forms.Label()
        Me.Nud_val = New System.Windows.Forms.NumericUpDown()
        Me.Btn_goo = New System.Windows.Forms.Button()
        Me.Btn_cancel = New System.Windows.Forms.Button()
        Me.Lbl_current = New System.Windows.Forms.Label()
        Me.Lbl_currentValue = New System.Windows.Forms.Label()
        Me.Lbl_maximumValue = New System.Windows.Forms.Label()
        Me.Lbl_maximum = New System.Windows.Forms.Label()
        CType(Me.Nud_val, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Rb_line
        '
        Me.Rb_line.AutoSize = True
        Me.Rb_line.Location = New System.Drawing.Point(27, 27)
        Me.Rb_line.Name = "Rb_line"
        Me.Rb_line.Size = New System.Drawing.Size(45, 17)
        Me.Rb_line.TabIndex = 2
        Me.Rb_line.Text = "Line"
        Me.Rb_line.UseVisualStyleBackColor = True
        '
        'Rb_frame
        '
        Me.Rb_frame.AutoSize = True
        Me.Rb_frame.Checked = True
        Me.Rb_frame.Location = New System.Drawing.Point(145, 27)
        Me.Rb_frame.Name = "Rb_frame"
        Me.Rb_frame.Size = New System.Drawing.Size(54, 17)
        Me.Rb_frame.TabIndex = 3
        Me.Rb_frame.TabStop = True
        Me.Rb_frame.Text = "Frame"
        Me.Rb_frame.UseVisualStyleBackColor = True
        '
        'Lbl_target
        '
        Me.Lbl_target.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_target.AutoSize = True
        Me.Lbl_target.Location = New System.Drawing.Point(27, 110)
        Me.Lbl_target.Name = "Lbl_target"
        Me.Lbl_target.Size = New System.Drawing.Size(41, 13)
        Me.Lbl_target.TabIndex = 0
        Me.Lbl_target.Text = "Target:"
        '
        'Nud_val
        '
        Me.Nud_val.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nud_val.Location = New System.Drawing.Point(145, 108)
        Me.Nud_val.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Nud_val.Name = "Nud_val"
        Me.Nud_val.Size = New System.Drawing.Size(196, 20)
        Me.Nud_val.TabIndex = 1
        Me.Nud_val.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Btn_goo
        '
        Me.Btn_goo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_goo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_goo.Location = New System.Drawing.Point(347, 106)
        Me.Btn_goo.Name = "Btn_goo"
        Me.Btn_goo.Size = New System.Drawing.Size(100, 23)
        Me.Btn_goo.TabIndex = 4
        Me.Btn_goo.Text = "Go to"
        Me.Btn_goo.UseVisualStyleBackColor = True
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_cancel.Location = New System.Drawing.Point(347, 136)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(100, 23)
        Me.Btn_cancel.TabIndex = 5
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'Lbl_current
        '
        Me.Lbl_current.AutoSize = True
        Me.Lbl_current.Location = New System.Drawing.Point(27, 82)
        Me.Lbl_current.Name = "Lbl_current"
        Me.Lbl_current.Size = New System.Drawing.Size(44, 13)
        Me.Lbl_current.TabIndex = 0
        Me.Lbl_current.Text = "Current:"
        '
        'Lbl_currentValue
        '
        Me.Lbl_currentValue.AutoSize = True
        Me.Lbl_currentValue.Location = New System.Drawing.Point(145, 82)
        Me.Lbl_currentValue.Name = "Lbl_currentValue"
        Me.Lbl_currentValue.Size = New System.Drawing.Size(13, 13)
        Me.Lbl_currentValue.TabIndex = 0
        Me.Lbl_currentValue.Text = "0"
        '
        'Lbl_maximumValue
        '
        Me.Lbl_maximumValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_maximumValue.AutoSize = True
        Me.Lbl_maximumValue.Location = New System.Drawing.Point(145, 141)
        Me.Lbl_maximumValue.Name = "Lbl_maximumValue"
        Me.Lbl_maximumValue.Size = New System.Drawing.Size(13, 13)
        Me.Lbl_maximumValue.TabIndex = 0
        Me.Lbl_maximumValue.Text = "0"
        '
        'Lbl_maximum
        '
        Me.Lbl_maximum.AutoSize = True
        Me.Lbl_maximum.Location = New System.Drawing.Point(27, 141)
        Me.Lbl_maximum.Name = "Lbl_maximum"
        Me.Lbl_maximum.Size = New System.Drawing.Size(54, 13)
        Me.Lbl_maximum.TabIndex = 0
        Me.Lbl_maximum.Text = "Maximum:"
        '
        'GoToWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 186)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.Btn_goo)
        Me.Controls.Add(Me.Nud_val)
        Me.Controls.Add(Me.Lbl_maximumValue)
        Me.Controls.Add(Me.Lbl_currentValue)
        Me.Controls.Add(Me.Lbl_maximum)
        Me.Controls.Add(Me.Lbl_current)
        Me.Controls.Add(Me.Lbl_target)
        Me.Controls.Add(Me.Rb_frame)
        Me.Controls.Add(Me.Rb_line)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GoToWindow"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Go To..."
        CType(Me.Nud_val, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Rb_line As RadioButton
    Friend WithEvents Rb_frame As RadioButton
    Friend WithEvents Lbl_target As Label
    Friend WithEvents Nud_val As NumericUpDown
    Friend WithEvents Btn_goo As Button
    Friend WithEvents Btn_cancel As Button
    Friend WithEvents Lbl_current As Label
    Friend WithEvents Lbl_currentValue As Label
    Friend WithEvents Lbl_maximumValue As Label
    Friend WithEvents Lbl_maximum As Label
End Class
