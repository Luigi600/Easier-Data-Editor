<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_tag_adder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_tag_adder))
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.lbl_descripition = New System.Windows.Forms.Label()
        Me.gb_input = New System.Windows.Forms.GroupBox()
        Me.btn_apply = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(27, 24)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(121, 25)
        Me.lbl_title.TabIndex = 1
        Me.lbl_title.Text = "Tag Adder"
        '
        'lbl_descripition
        '
        Me.lbl_descripition.AutoSize = True
        Me.lbl_descripition.Location = New System.Drawing.Point(27, 57)
        Me.lbl_descripition.Name = "lbl_descripition"
        Me.lbl_descripition.Size = New System.Drawing.Size(200, 13)
        Me.lbl_descripition.TabIndex = 2
        Me.lbl_descripition.Text = "Adds a custom tag to all selected frames."
        '
        'gb_input
        '
        Me.gb_input.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb_input.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_input.Location = New System.Drawing.Point(27, 92)
        Me.gb_input.Name = "gb_input"
        Me.gb_input.Padding = New System.Windows.Forms.Padding(10)
        Me.gb_input.Size = New System.Drawing.Size(530, 301)
        Me.gb_input.TabIndex = 3
        Me.gb_input.TabStop = False
        Me.gb_input.Text = "Input (Tag)"
        '
        'btn_apply
        '
        Me.btn_apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_apply.Location = New System.Drawing.Point(457, 410)
        Me.btn_apply.Name = "btn_apply"
        Me.btn_apply.Size = New System.Drawing.Size(100, 25)
        Me.btn_apply.TabIndex = 4
        Me.btn_apply.Text = "Apply"
        Me.btn_apply.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_close.Location = New System.Drawing.Point(27, 410)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(100, 25)
        Me.btn_close.TabIndex = 5
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'ui_tag_adder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 462)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_apply)
        Me.Controls.Add(Me.gb_input)
        Me.Controls.Add(Me.lbl_descripition)
        Me.Controls.Add(Me.lbl_title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ui_tag_adder"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor - Tag Adder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_title As Label
    Friend WithEvents lbl_descripition As Label
    Friend WithEvents gb_input As GroupBox
    Friend WithEvents btn_apply As Button
    Friend WithEvents btn_close As Button
End Class
