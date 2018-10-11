<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_error_list
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_error_list))
        Me.pal_menu_top = New System.Windows.Forms.Panel()
        Me.lv_errors = New System.Windows.Forms.ListView()
        Me.col_line = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_message = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_file = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'pal_menu_top
        '
        Me.pal_menu_top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_menu_top.Location = New System.Drawing.Point(0, 0)
        Me.pal_menu_top.Name = "pal_menu_top"
        Me.pal_menu_top.Size = New System.Drawing.Size(575, 31)
        Me.pal_menu_top.TabIndex = 0
        Me.pal_menu_top.Visible = False
        '
        'lv_errors
        '
        Me.lv_errors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_line, Me.col_message, Me.col_file})
        Me.lv_errors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_errors.ForeColor = System.Drawing.Color.DarkRed
        Me.lv_errors.FullRowSelect = True
        Me.lv_errors.GridLines = True
        Me.lv_errors.HideSelection = False
        Me.lv_errors.Location = New System.Drawing.Point(0, 31)
        Me.lv_errors.Name = "lv_errors"
        Me.lv_errors.Size = New System.Drawing.Size(575, 305)
        Me.lv_errors.TabIndex = 1
        Me.lv_errors.UseCompatibleStateImageBehavior = False
        Me.lv_errors.View = System.Windows.Forms.View.Details
        '
        'col_line
        '
        Me.col_line.Text = "Line"
        Me.col_line.Width = 71
        '
        'col_message
        '
        Me.col_message.Text = "Message"
        Me.col_message.Width = 284
        '
        'col_file
        '
        Me.col_file.Text = "File"
        Me.col_file.Width = 191
        '
        'ui_error_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 336)
        Me.Controls.Add(Me.lv_errors)
        Me.Controls.Add(Me.pal_menu_top)
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ui_error_list"
        Me.ShowIcon = False
        Me.Text = "Error List"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pal_menu_top As Panel
    Friend WithEvents lv_errors As ListView
    Friend WithEvents col_line As ColumnHeader
    Friend WithEvents col_message As ColumnHeader
    Friend WithEvents col_file As ColumnHeader
End Class
