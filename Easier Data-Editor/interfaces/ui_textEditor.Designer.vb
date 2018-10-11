<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_textEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_textEditor))
        Me.tim_ErrorChecker = New System.Windows.Forms.Timer()
        Me.tim_UnusedFrames = New System.Windows.Forms.Timer()
        Me.cms_ = New System.Windows.Forms.ContextMenuStrip()
        Me.TSMI_selectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_frameViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_paste_cool = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms_.SuspendLayout()
        Me.SuspendLayout()
        '
        'tim_ErrorChecker
        '
        Me.tim_ErrorChecker.Interval = 500
        '
        'tim_UnusedFrames
        '
        Me.tim_UnusedFrames.Interval = 500
        '
        'cms_
        '
        Me.cms_.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_cut, Me.TSMI_copy, Me.TSMI_paste, Me.TSMI_paste_cool, Me.TSMI_delete, Me.TSMI_selectAll, Me.TSS_1, Me.TSMI_frameViewer})
        Me.cms_.Name = "cms_"
        Me.cms_.Size = New System.Drawing.Size(175, 164)
        '
        'TSMI_selectAll
        '
        Me.TSMI_selectAll.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_select_all
        Me.TSMI_selectAll.Name = "TSMI_selectAll"
        Me.TSMI_selectAll.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_selectAll.Text = "Select All"
        '
        'TSS_1
        '
        Me.TSS_1.Name = "TSS_1"
        Me.TSS_1.Size = New System.Drawing.Size(171, 6)
        '
        'TSMI_frameViewer
        '
        Me.TSMI_frameViewer.CheckOnClick = True
        Me.TSMI_frameViewer.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_character
        Me.TSMI_frameViewer.Name = "TSMI_frameViewer"
        Me.TSMI_frameViewer.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_frameViewer.Text = "Frame Viewer"
        '
        'TSMI_cut
        '
        Me.TSMI_cut.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_cut
        Me.TSMI_cut.Name = "TSMI_cut"
        Me.TSMI_cut.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_cut.Text = "Cut"
        '
        'TSMI_copy
        '
        Me.TSMI_copy.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_copy
        Me.TSMI_copy.Name = "TSMI_copy"
        Me.TSMI_copy.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_copy.Text = "Copy"
        '
        'TSMI_paste
        '
        Me.TSMI_paste.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste
        Me.TSMI_paste.Name = "TSMI_paste"
        Me.TSMI_paste.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_paste.Text = "Paste"
        '
        'TSMI_paste_cool
        '
        Me.TSMI_paste_cool.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste_cool
        Me.TSMI_paste_cool.Name = "TSMI_paste_cool"
        Me.TSMI_paste_cool.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_paste_cool.Text = "Paste && Adapts IDs"
        '
        'TSMI_delete
        '
        Me.TSMI_delete.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_delete1
        Me.TSMI_delete.Name = "TSMI_delete"
        Me.TSMI_delete.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_delete.Text = "Delete"
        '
        'ui_textEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(398, 189)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ui_textEditor"
        Me.Text = "New File"
        Me.cms_.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tim_ErrorChecker As Timer
    Friend WithEvents tim_UnusedFrames As Timer
    Friend WithEvents cms_ As ContextMenuStrip
    Friend WithEvents TSMI_cut As ToolStripMenuItem
    Friend WithEvents TSMI_copy As ToolStripMenuItem
    Friend WithEvents TSMI_paste As ToolStripMenuItem
    Friend WithEvents TSMI_delete As ToolStripMenuItem
    Friend WithEvents TSMI_selectAll As ToolStripMenuItem
    Friend WithEvents TSMI_paste_cool As ToolStripMenuItem
    Friend WithEvents TSS_1 As ToolStripSeparator
    Friend WithEvents TSMI_frameViewer As ToolStripMenuItem
End Class
