<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_unused_frames
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_unused_frames))
        Me.lv_unused = New System.Windows.Forms.ListView()
        Me.col_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lv_unused
        '
        Me.lv_unused.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_id})
        Me.lv_unused.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_unused.FullRowSelect = True
        Me.lv_unused.GridLines = True
        Me.lv_unused.HideSelection = False
        Me.lv_unused.Location = New System.Drawing.Point(0, 0)
        Me.lv_unused.Name = "lv_unused"
        Me.lv_unused.Size = New System.Drawing.Size(222, 289)
        Me.lv_unused.TabIndex = 0
        Me.lv_unused.UseCompatibleStateImageBehavior = False
        Me.lv_unused.View = System.Windows.Forms.View.Details
        '
        'col_id
        '
        Me.col_id.Text = "ID"
        Me.col_id.Width = 134
        '
        'ui_unused_frames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(222, 289)
        Me.Controls.Add(Me.lv_unused)
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ui_unused_frames"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unused Frames"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lv_unused As ListView
    Friend WithEvents col_id As ColumnHeader
End Class
