<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_go_to
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_go_to))
        Me.rb_line = New System.Windows.Forms.RadioButton()
        Me.rb_frame = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nud_val = New System.Windows.Forms.NumericUpDown()
        Me.btn_goo = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        CType(Me.nud_val, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rb_line
        '
        Me.rb_line.AutoSize = True
        Me.rb_line.Location = New System.Drawing.Point(27, 27)
        Me.rb_line.Name = "rb_line"
        Me.rb_line.Size = New System.Drawing.Size(45, 17)
        Me.rb_line.TabIndex = 2
        Me.rb_line.Text = "Line"
        Me.rb_line.UseVisualStyleBackColor = True
        '
        'rb_frame
        '
        Me.rb_frame.AutoSize = True
        Me.rb_frame.Checked = True
        Me.rb_frame.Location = New System.Drawing.Point(145, 27)
        Me.rb_frame.Name = "rb_frame"
        Me.rb_frame.Size = New System.Drawing.Size(54, 17)
        Me.rb_frame.TabIndex = 3
        Me.rb_frame.TabStop = True
        Me.rb_frame.Text = "Frame"
        Me.rb_frame.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Target:"
        '
        'nud_val
        '
        Me.nud_val.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nud_val.Location = New System.Drawing.Point(145, 76)
        Me.nud_val.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nud_val.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nud_val.Name = "nud_val"
        Me.nud_val.Size = New System.Drawing.Size(196, 20)
        Me.nud_val.TabIndex = 1
        Me.nud_val.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btn_goo
        '
        Me.btn_goo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_goo.Location = New System.Drawing.Point(347, 74)
        Me.btn_goo.Name = "btn_goo"
        Me.btn_goo.Size = New System.Drawing.Size(100, 23)
        Me.btn_goo.TabIndex = 4
        Me.btn_goo.Text = "Go to"
        Me.btn_goo.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel.Location = New System.Drawing.Point(347, 104)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(100, 23)
        Me.btn_cancel.TabIndex = 5
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'ui_go_to
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 154)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_goo)
        Me.Controls.Add(Me.nud_val)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rb_frame)
        Me.Controls.Add(Me.rb_line)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ui_go_to"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor (STM93 Version) - Go To"
        CType(Me.nud_val, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rb_line As RadioButton
    Friend WithEvents rb_frame As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents nud_val As NumericUpDown
    Friend WithEvents btn_goo As Button
    Friend WithEvents btn_cancel As Button
End Class
