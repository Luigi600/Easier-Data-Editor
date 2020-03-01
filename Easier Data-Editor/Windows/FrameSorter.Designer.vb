<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrameSorter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrameSorter))
        Me.Btn_doIt = New System.Windows.Forms.Button()
        Me.Btn_close = New System.Windows.Forms.Button()
        Me.Lv_files = New System.Windows.Forms.ListView()
        Me.Col_file = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lbl_title = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btn_doIt
        '
        Me.Btn_doIt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_doIt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_doIt.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_doIt.Location = New System.Drawing.Point(665, 354)
        Me.Btn_doIt.Name = "Btn_doIt"
        Me.Btn_doIt.Size = New System.Drawing.Size(125, 30)
        Me.Btn_doIt.TabIndex = 11
        Me.Btn_doIt.Text = "Sort"
        Me.Btn_doIt.UseVisualStyleBackColor = True
        '
        'Btn_close
        '
        Me.Btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_close.Location = New System.Drawing.Point(26, 354)
        Me.Btn_close.Name = "Btn_close"
        Me.Btn_close.Size = New System.Drawing.Size(125, 30)
        Me.Btn_close.TabIndex = 10
        Me.Btn_close.Text = "Close"
        Me.Btn_close.UseVisualStyleBackColor = True
        '
        'Lv_files
        '
        Me.Lv_files.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lv_files.CheckBoxes = True
        Me.Lv_files.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_file, Me.Col_path})
        Me.Lv_files.FullRowSelect = True
        Me.Lv_files.GridLines = True
        Me.Lv_files.HideSelection = False
        Me.Lv_files.Location = New System.Drawing.Point(27, 58)
        Me.Lv_files.Name = "Lv_files"
        Me.Lv_files.Size = New System.Drawing.Size(762, 290)
        Me.Lv_files.TabIndex = 9
        Me.Lv_files.UseCompatibleStateImageBehavior = False
        Me.Lv_files.View = System.Windows.Forms.View.Details
        '
        'Col_file
        '
        Me.Col_file.Name = "Col_file"
        Me.Col_file.Text = "File Name"
        Me.Col_file.Width = 182
        '
        'Col_path
        '
        Me.Col_path.Name = "Col_path"
        Me.Col_path.Text = "Path"
        Me.Col_path.Width = 382
        '
        'Lbl_title
        '
        Me.Lbl_title.AutoSize = True
        Me.Lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_title.Location = New System.Drawing.Point(27, 24)
        Me.Lbl_title.Name = "Lbl_title"
        Me.Lbl_title.Size = New System.Drawing.Size(292, 25)
        Me.Lbl_title.TabIndex = 13
        Me.Lbl_title.Text = "Numeric Sorting of Frames"
        '
        'FrameSorter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 411)
        Me.Controls.Add(Me.Lv_files)
        Me.Controls.Add(Me.Lbl_title)
        Me.Controls.Add(Me.Btn_doIt)
        Me.Controls.Add(Me.Btn_close)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(425, 340)
        Me.Name = "FrameSorter"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sort Frames"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_doIt As Button
    Friend WithEvents Btn_close As Button
    Friend WithEvents Lv_files As ListView
    Friend WithEvents Col_file As ColumnHeader
    Friend WithEvents Col_path As ColumnHeader
    Friend WithEvents Lbl_title As Label
End Class
