<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorList))
        Me.Pal_menu_top = New System.Windows.Forms.Panel()
        Me.Lv_errors = New System.Windows.Forms.ListView()
        Me.Col_line = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_message = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_file = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Pal_menu_top
        '
        Me.Pal_menu_top.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pal_menu_top.Location = New System.Drawing.Point(0, 0)
        Me.Pal_menu_top.Name = "Pal_menu_top"
        Me.Pal_menu_top.Size = New System.Drawing.Size(575, 31)
        Me.Pal_menu_top.TabIndex = 0
        Me.Pal_menu_top.Visible = False
        '
        'Lv_errors
        '
        Me.Lv_errors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_line, Me.Col_message, Me.Col_file})
        Me.Lv_errors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lv_errors.ForeColor = System.Drawing.Color.DarkRed
        Me.Lv_errors.FullRowSelect = True
        Me.Lv_errors.GridLines = True
        Me.Lv_errors.HideSelection = False
        Me.Lv_errors.Location = New System.Drawing.Point(0, 31)
        Me.Lv_errors.Name = "Lv_errors"
        Me.Lv_errors.Size = New System.Drawing.Size(575, 305)
        Me.Lv_errors.TabIndex = 1
        Me.Lv_errors.UseCompatibleStateImageBehavior = False
        Me.Lv_errors.View = System.Windows.Forms.View.Details
        '
        'Col_line
        '
        Me.Col_line.Name = "Col_line"
        Me.Col_line.Tag = "Col_line"
        Me.Col_line.Text = "Line"
        Me.Col_line.Width = 71
        '
        'Col_message
        '
        Me.Col_message.Name = "Col_message"
        Me.Col_message.Tag = "Col_message"
        Me.Col_message.Text = "Message"
        Me.Col_message.Width = 284
        '
        'Col_file
        '
        Me.Col_file.Name = "Col_file"
        Me.Col_file.Tag = "Col_file"
        Me.Col_file.Text = "File"
        Me.Col_file.Width = 191
        '
        'ErrorList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 336)
        Me.Controls.Add(Me.Lv_errors)
        Me.Controls.Add(Me.Pal_menu_top)
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ErrorList"
        Me.ShowIcon = False
        Me.Text = "Error List"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pal_menu_top As Panel
    Friend WithEvents Lv_errors As ListView
    Friend WithEvents Col_line As ColumnHeader
    Friend WithEvents Col_message As ColumnHeader
    Friend WithEvents Col_file As ColumnHeader
End Class
