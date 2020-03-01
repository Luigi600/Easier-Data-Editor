<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TextEditor
    Inherits Translation.TranslatableDockContent

    Protected Overrides Function GetPersistString() As String
        Return "TE;" & Path & ";" & ID & ";" & Scintilla1.FirstVisibleLine & ";" & String.Join(",", Scintilla1.GetBookmarkedLinesIndices()) 'fixed name, if i had the idea to change the name of this class...
    End Function

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextEditor))
        Me.CMS_actions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_paste_cool = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_selectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_frameViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_split = New System.Windows.Forms.Button()
        Me.Splitter = New System.Windows.Forms.SplitContainer()
        Me.Pic_scrollbarAnnotations = New System.Windows.Forms.PictureBox()
        Me.Scintilla1 = New Easier_Data_Editor.CustomScintilla()
        Me.Tim_annotations = New System.Windows.Forms.Timer(Me.components)
        Me.CMS_actions.SuspendLayout()
        CType(Me.Splitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Splitter.Panel1.SuspendLayout()
        Me.Splitter.SuspendLayout()
        CType(Me.Pic_scrollbarAnnotations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMS_actions
        '
        Me.CMS_actions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_cut, Me.TSMI_copy, Me.TSMI_paste, Me.TSMI_paste_cool, Me.TSMI_delete, Me.TSMI_selectAll, Me.TSS_1, Me.TSMI_frameViewer})
        Me.CMS_actions.Name = "CMS_actions"
        Me.CMS_actions.Size = New System.Drawing.Size(170, 164)
        '
        'TSMI_cut
        '
        Me.TSMI_cut.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_cut
        Me.TSMI_cut.Name = "TSMI_cut"
        Me.TSMI_cut.Size = New System.Drawing.Size(169, 22)
        Me.TSMI_cut.Text = "Cut"
        '
        'TSMI_copy
        '
        Me.TSMI_copy.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_copy
        Me.TSMI_copy.Name = "TSMI_copy"
        Me.TSMI_copy.Size = New System.Drawing.Size(169, 22)
        Me.TSMI_copy.Text = "Copy"
        '
        'TSMI_paste
        '
        Me.TSMI_paste.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste
        Me.TSMI_paste.Name = "TSMI_paste"
        Me.TSMI_paste.Size = New System.Drawing.Size(169, 22)
        Me.TSMI_paste.Text = "Paste"
        '
        'TSMI_paste_cool
        '
        Me.TSMI_paste_cool.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_paste_cool
        Me.TSMI_paste_cool.Name = "TSMI_paste_cool"
        Me.TSMI_paste_cool.Size = New System.Drawing.Size(169, 22)
        Me.TSMI_paste_cool.Text = "Paste && Adapt IDs"
        '
        'TSMI_delete
        '
        Me.TSMI_delete.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_delete1
        Me.TSMI_delete.Name = "TSMI_delete"
        Me.TSMI_delete.Size = New System.Drawing.Size(169, 22)
        Me.TSMI_delete.Text = "Delete"
        '
        'TSMI_selectAll
        '
        Me.TSMI_selectAll.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_select_all
        Me.TSMI_selectAll.Name = "TSMI_selectAll"
        Me.TSMI_selectAll.Size = New System.Drawing.Size(169, 22)
        Me.TSMI_selectAll.Text = "Select All"
        '
        'TSS_1
        '
        Me.TSS_1.Name = "TSS_1"
        Me.TSS_1.Size = New System.Drawing.Size(166, 6)
        '
        'TSMI_frameViewer
        '
        Me.TSMI_frameViewer.CheckOnClick = True
        Me.TSMI_frameViewer.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_character
        Me.TSMI_frameViewer.Name = "TSMI_frameViewer"
        Me.TSMI_frameViewer.Size = New System.Drawing.Size(169, 22)
        Me.TSMI_frameViewer.Text = "Frame Viewer"
        '
        'Btn_split
        '
        Me.Btn_split.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_split.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_split.Image = Global.Easier_Data_Editor.My.Resources.Resources.icon_splitH
        Me.Btn_split.Location = New System.Drawing.Point(376, -1)
        Me.Btn_split.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_split.Name = "Btn_split"
        Me.Btn_split.Size = New System.Drawing.Size(19, 19)
        Me.Btn_split.TabIndex = 4
        Me.Btn_split.UseVisualStyleBackColor = True
        '
        'Splitter
        '
        Me.Splitter.AllowDrop = True
        Me.Splitter.BackColor = System.Drawing.Color.Silver
        Me.Splitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Splitter.Location = New System.Drawing.Point(0, 0)
        Me.Splitter.Margin = New System.Windows.Forms.Padding(2)
        Me.Splitter.Name = "Splitter"
        Me.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Splitter.Panel1
        '
        Me.Splitter.Panel1.Controls.Add(Me.Pic_scrollbarAnnotations)
        Me.Splitter.Panel1.Controls.Add(Me.Scintilla1)
        Me.Splitter.Panel1MinSize = 0
        '
        'Splitter.Panel2
        '
        Me.Splitter.Panel2Collapsed = True
        Me.Splitter.Panel2MinSize = 0
        Me.Splitter.Size = New System.Drawing.Size(409, 186)
        Me.Splitter.SplitterDistance = 161
        Me.Splitter.SplitterWidth = 3
        Me.Splitter.TabIndex = 5
        '
        'Pic_scrollbarAnnotations
        '
        Me.Pic_scrollbarAnnotations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic_scrollbarAnnotations.BackColor = System.Drawing.Color.White
        Me.Pic_scrollbarAnnotations.Location = New System.Drawing.Point(386, 17)
        Me.Pic_scrollbarAnnotations.Name = "Pic_scrollbarAnnotations"
        Me.Pic_scrollbarAnnotations.Size = New System.Drawing.Size(9, 135)
        Me.Pic_scrollbarAnnotations.TabIndex = 2
        Me.Pic_scrollbarAnnotations.TabStop = False
        '
        'Scintilla1
        '
        Me.Scintilla1.AdditionalSelectionTyping = True
        Me.Scintilla1.AllowDrop = True
        Me.Scintilla1.BlockUndoRedoActions = False
        Me.Scintilla1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Scintilla1.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Scintilla1.CaretLineVisible = True
        Me.Scintilla1.ContextMenuStrip = Me.CMS_actions
        Me.Scintilla1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla1.Location = New System.Drawing.Point(0, 0)
        Me.Scintilla1.Margin = New System.Windows.Forms.Padding(2)
        Me.Scintilla1.MouseSelectionRectangularSwitch = True
        Me.Scintilla1.MultiPaste = ScintillaNET.MultiPaste.[Each]
        Me.Scintilla1.MultipleSelection = True
        Me.Scintilla1.Name = "Scintilla1"
        Me.Scintilla1.ScrollWidth = 100
        Me.Scintilla1.Size = New System.Drawing.Size(409, 186)
        Me.Scintilla1.SuppressFoldingCheck = False
        Me.Scintilla1.TabIndex = 1
        Me.Scintilla1.VirtualSpaceOptions = ScintillaNET.VirtualSpace.RectangularSelection
        Me.Scintilla1.WhitespaceSize = 3
        '
        'Tim_annotations
        '
        Me.Tim_annotations.Interval = 400
        '
        'TextEditor
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 186)
        Me.Controls.Add(Me.Btn_split)
        Me.Controls.Add(Me.Splitter)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TextEditor"
        Me.Text = "New File *"
        Me.CMS_actions.ResumeLayout(False)
        Me.Splitter.Panel1.ResumeLayout(False)
        CType(Me.Splitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Splitter.ResumeLayout(False)
        CType(Me.Pic_scrollbarAnnotations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CMS_actions As ContextMenuStrip
    Friend WithEvents TSMI_cut As ToolStripMenuItem
    Friend WithEvents TSMI_copy As ToolStripMenuItem
    Friend WithEvents TSMI_paste As ToolStripMenuItem
    Friend WithEvents TSMI_paste_cool As ToolStripMenuItem
    Friend WithEvents TSMI_delete As ToolStripMenuItem
    Friend WithEvents TSMI_selectAll As ToolStripMenuItem
    Friend WithEvents TSS_1 As ToolStripSeparator
    Friend WithEvents TSMI_frameViewer As ToolStripMenuItem
    Friend WithEvents Btn_split As Button
    Friend WithEvents Splitter As SplitContainer
    Friend WithEvents Scintilla1 As CustomScintilla
    Friend WithEvents Pic_scrollbarAnnotations As PictureBox
    Friend WithEvents Tim_annotations As Timer
End Class
