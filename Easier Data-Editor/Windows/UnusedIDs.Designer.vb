<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnusedIDs
    Inherits Translation.TranslatableDockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnusedIDs))
        Me.Lv_unused = New System.Windows.Forms.ListView()
        Me.Col_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Lv_unused
        '
        Me.Lv_unused.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_id})
        Me.Lv_unused.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lv_unused.FullRowSelect = True
        Me.Lv_unused.GridLines = True
        Me.Lv_unused.HideSelection = False
        Me.Lv_unused.Location = New System.Drawing.Point(0, 0)
        Me.Lv_unused.Name = "Lv_unused"
        Me.Lv_unused.Size = New System.Drawing.Size(222, 289)
        Me.Lv_unused.TabIndex = 0
        Me.Lv_unused.UseCompatibleStateImageBehavior = False
        Me.Lv_unused.View = System.Windows.Forms.View.Details
        '
        'col_id
        '
        Me.Col_id.Text = "ID"
        Me.Col_id.Width = 134
        Me.Col_id.Name = "Col_id"
        '
        'UnusedIDs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(222, 289)
        Me.Controls.Add(Me.Lv_unused)
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UnusedIDs"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unused IDs"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lv_unused As ListView
    Friend WithEvents Col_id As ColumnHeader
End Class
