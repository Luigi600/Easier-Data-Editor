<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsF
    Inherits Translation.TranslatableForm
    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If

            OwnDispose()
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Text Editor")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Frame Viewer")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsF))
        Me.TreeV_settings = New System.Windows.Forms.TreeView()
        Me.Pal_hr = New System.Windows.Forms.Panel()
        Me.Btn_save = New System.Windows.Forms.Button()
        Me.Btn_apply = New System.Windows.Forms.Button()
        Me.Btn_cancel = New System.Windows.Forms.Button()
        Me.Btn_reset = New System.Windows.Forms.Button()
        Me.Pal_settingPage = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'TreeV_settings
        '
        Me.TreeV_settings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeV_settings.FullRowSelect = True
        Me.TreeV_settings.HideSelection = False
        Me.TreeV_settings.Location = New System.Drawing.Point(12, 12)
        Me.TreeV_settings.Name = "TreeV_settings"
        TreeNode1.Name = "Node_general"
        TreeNode1.Text = "General"
        TreeNode2.Name = "Node_textEditor"
        TreeNode2.Text = "Text Editor"
        TreeNode3.Name = "Node_frameViewer"
        TreeNode3.Text = "Frame Viewer"
        Me.TreeV_settings.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.TreeV_settings.Size = New System.Drawing.Size(200, 353)
        Me.TreeV_settings.TabIndex = 0
        '
        'Pal_hr
        '
        Me.Pal_hr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pal_hr.BackColor = System.Drawing.Color.Gainsboro
        Me.Pal_hr.Location = New System.Drawing.Point(12, 374)
        Me.Pal_hr.Name = "Pal_hr"
        Me.Pal_hr.Size = New System.Drawing.Size(760, 1)
        Me.Pal_hr.TabIndex = 1
        '
        'Btn_save
        '
        Me.Btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_save.Location = New System.Drawing.Point(576, 384)
        Me.Btn_save.Name = "Btn_save"
        Me.Btn_save.Size = New System.Drawing.Size(95, 25)
        Me.Btn_save.TabIndex = 2
        Me.Btn_save.Text = "Save && Close"
        Me.Btn_save.UseVisualStyleBackColor = True
        '
        'Btn_apply
        '
        Me.Btn_apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_apply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_apply.Location = New System.Drawing.Point(677, 384)
        Me.Btn_apply.Name = "Btn_apply"
        Me.Btn_apply.Size = New System.Drawing.Size(95, 25)
        Me.Btn_apply.TabIndex = 2
        Me.Btn_apply.Text = "Apply"
        Me.Btn_apply.UseVisualStyleBackColor = True
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_cancel.Location = New System.Drawing.Point(475, 384)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(95, 25)
        Me.Btn_cancel.TabIndex = 2
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'Btn_reset
        '
        Me.Btn_reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_reset.Location = New System.Drawing.Point(12, 384)
        Me.Btn_reset.Name = "Btn_reset"
        Me.Btn_reset.Size = New System.Drawing.Size(125, 25)
        Me.Btn_reset.TabIndex = 2
        Me.Btn_reset.Text = "Reset ALL Settings"
        Me.Btn_reset.UseVisualStyleBackColor = True
        '
        'Pal_settingPage
        '
        Me.Pal_settingPage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pal_settingPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pal_settingPage.Location = New System.Drawing.Point(218, 12)
        Me.Pal_settingPage.Name = "Pal_settingPage"
        Me.Pal_settingPage.Size = New System.Drawing.Size(554, 353)
        Me.Pal_settingPage.TabIndex = 3
        '
        'SettingsF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 421)
        Me.Controls.Add(Me.Pal_settingPage)
        Me.Controls.Add(Me.Btn_reset)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.Btn_apply)
        Me.Controls.Add(Me.Btn_save)
        Me.Controls.Add(Me.Pal_hr)
        Me.Controls.Add(Me.TreeV_settings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "SettingsF"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeV_settings As TreeView
    Friend WithEvents Pal_hr As Panel
    Friend WithEvents Btn_save As Button
    Friend WithEvents Btn_apply As Button
    Friend WithEvents Btn_cancel As Button
    Friend WithEvents Btn_reset As Button
    Friend WithEvents Pal_settingPage As Panel
End Class
