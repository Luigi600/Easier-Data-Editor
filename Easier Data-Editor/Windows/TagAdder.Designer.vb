<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagAdder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TagAdder))
        Me.Lbl_title = New System.Windows.Forms.Label()
        Me.Lbl_descripition = New System.Windows.Forms.Label()
        Me.Gb_input = New System.Windows.Forms.GroupBox()
        Me.Scintilla1 = New Easier_Data_Editor.CustomScintilla()
        Me.Btn_apply = New System.Windows.Forms.Button()
        Me.Btn_close = New System.Windows.Forms.Button()
        Me.Gb_input.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_title
        '
        Me.Lbl_title.AutoSize = True
        Me.Lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_title.Location = New System.Drawing.Point(27, 24)
        Me.Lbl_title.Name = "Lbl_title"
        Me.Lbl_title.Size = New System.Drawing.Size(121, 25)
        Me.Lbl_title.TabIndex = 1
        Me.Lbl_title.Text = "Tag Adder"
        '
        'Lbl_descripition
        '
        Me.Lbl_descripition.AutoSize = True
        Me.Lbl_descripition.Location = New System.Drawing.Point(27, 57)
        Me.Lbl_descripition.Name = "Lbl_descripition"
        Me.Lbl_descripition.Size = New System.Drawing.Size(200, 13)
        Me.Lbl_descripition.TabIndex = 2
        Me.Lbl_descripition.Text = "Adds a custom tag to all selected frames."
        '
        'Gb_input
        '
        Me.Gb_input.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gb_input.Controls.Add(Me.Scintilla1)
        Me.Gb_input.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gb_input.Location = New System.Drawing.Point(27, 92)
        Me.Gb_input.Name = "Gb_input"
        Me.Gb_input.Padding = New System.Windows.Forms.Padding(10)
        Me.Gb_input.Size = New System.Drawing.Size(530, 301)
        Me.Gb_input.TabIndex = 3
        Me.Gb_input.TabStop = False
        Me.Gb_input.Text = "Input (Tag)"
        '
        'Scintilla1
        '
        Me.Scintilla1.AdditionalSelectionTyping = True
        Me.Scintilla1.BlockUndoRedoActions = False
        Me.Scintilla1.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Scintilla1.CaretLineVisible = True
        Me.Scintilla1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla1.Location = New System.Drawing.Point(10, 25)
        Me.Scintilla1.Margin = New System.Windows.Forms.Padding(2)
        Me.Scintilla1.MouseSelectionRectangularSwitch = True
        Me.Scintilla1.MultipleSelection = True
        Me.Scintilla1.Name = "Scintilla1"
        Me.Scintilla1.ScrollWidth = 10
        Me.Scintilla1.Size = New System.Drawing.Size(510, 266)
        Me.Scintilla1.SuppressFoldingCheck = False
        Me.Scintilla1.TabIndex = 0
        Me.Scintilla1.VirtualSpaceOptions = ScintillaNET.VirtualSpace.RectangularSelection
        Me.Scintilla1.WhitespaceSize = 3
        '
        'Btn_apply
        '
        Me.Btn_apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_apply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_apply.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_apply.Location = New System.Drawing.Point(457, 410)
        Me.Btn_apply.Name = "Btn_apply"
        Me.Btn_apply.Size = New System.Drawing.Size(100, 25)
        Me.Btn_apply.TabIndex = 4
        Me.Btn_apply.Text = "Apply"
        Me.Btn_apply.UseVisualStyleBackColor = True
        '
        'Btn_close
        '
        Me.Btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_close.Location = New System.Drawing.Point(27, 410)
        Me.Btn_close.Name = "Btn_close"
        Me.Btn_close.Size = New System.Drawing.Size(100, 25)
        Me.Btn_close.TabIndex = 5
        Me.Btn_close.Text = "Close"
        Me.Btn_close.UseVisualStyleBackColor = True
        '
        'TagAdder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 462)
        Me.Controls.Add(Me.Btn_close)
        Me.Controls.Add(Me.Btn_apply)
        Me.Controls.Add(Me.Gb_input)
        Me.Controls.Add(Me.Lbl_descripition)
        Me.Controls.Add(Me.Lbl_title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TagAdder"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tag Adder"
        Me.Gb_input.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_title As Label
    Friend WithEvents Lbl_descripition As Label
    Friend WithEvents Gb_input As GroupBox
    Friend WithEvents Btn_apply As Button
    Friend WithEvents Btn_close As Button
    Friend WithEvents Scintilla1 As CustomScintilla
End Class
