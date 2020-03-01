<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.Rtb_story = New System.Windows.Forms.RichTextBox()
        Me.Lbl_creator = New System.Windows.Forms.Label()
        Me.Lbl_libraries = New System.Windows.Forms.Label()
        Me.Lbl_version = New System.Windows.Forms.Label()
        Me.Lbl_creator_value = New System.Windows.Forms.Label()
        Me.Lbl_version_value = New System.Windows.Forms.Label()
        Me.LblLink_cookiesoft = New System.Windows.Forms.LinkLabel()
        Me.Link_library1 = New System.Windows.Forms.LinkLabel()
        Me.Link_library2 = New System.Windows.Forms.LinkLabel()
        Me.Btn_okay = New System.Windows.Forms.Button()
        Me.Pic_Logo = New System.Windows.Forms.PictureBox()
        Me.Lbl_version_value2 = New System.Windows.Forms.Label()
        CType(Me.Pic_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Rtb_story
        '
        Me.Rtb_story.BackColor = System.Drawing.SystemColors.Control
        Me.Rtb_story.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rtb_story.Location = New System.Drawing.Point(40, 78)
        Me.Rtb_story.Name = "Rtb_story"
        Me.Rtb_story.ReadOnly = True
        Me.Rtb_story.Size = New System.Drawing.Size(566, 70)
        Me.Rtb_story.TabIndex = 2
        Me.Rtb_story.Text = resources.GetString("Rtb_story.Text")
        '
        'Lbl_creator
        '
        Me.Lbl_creator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_creator.AutoSize = True
        Me.Lbl_creator.Location = New System.Drawing.Point(37, 170)
        Me.Lbl_creator.Name = "Lbl_creator"
        Me.Lbl_creator.Size = New System.Drawing.Size(44, 13)
        Me.Lbl_creator.TabIndex = 3
        Me.Lbl_creator.Text = "Creator:"
        '
        'Lbl_libraries
        '
        Me.Lbl_libraries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_libraries.AutoSize = True
        Me.Lbl_libraries.Location = New System.Drawing.Point(37, 196)
        Me.Lbl_libraries.Name = "Lbl_libraries"
        Me.Lbl_libraries.Size = New System.Drawing.Size(49, 13)
        Me.Lbl_libraries.TabIndex = 4
        Me.Lbl_libraries.Text = "Libraries:"
        '
        'Lbl_version
        '
        Me.Lbl_version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_version.AutoSize = True
        Me.Lbl_version.Location = New System.Drawing.Point(37, 222)
        Me.Lbl_version.Name = "Lbl_version"
        Me.Lbl_version.Size = New System.Drawing.Size(45, 13)
        Me.Lbl_version.TabIndex = 5
        Me.Lbl_version.Text = "Version:"
        '
        'Lbl_creator_value
        '
        Me.Lbl_creator_value.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_creator_value.AutoSize = True
        Me.Lbl_creator_value.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_creator_value.Location = New System.Drawing.Point(112, 168)
        Me.Lbl_creator_value.Name = "Lbl_creator_value"
        Me.Lbl_creator_value.Size = New System.Drawing.Size(65, 16)
        Me.Lbl_creator_value.TabIndex = 6
        Me.Lbl_creator_value.Text = "Luigi600"
        '
        'Lbl_version_value
        '
        Me.Lbl_version_value.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_version_value.AutoSize = True
        Me.Lbl_version_value.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_version_value.Location = New System.Drawing.Point(112, 220)
        Me.Lbl_version_value.Name = "Lbl_version_value"
        Me.Lbl_version_value.Size = New System.Drawing.Size(114, 16)
        Me.Lbl_version_value.TabIndex = 8
        Me.Lbl_version_value.Text = "1.0.0.0 (STM93)"
        '
        'LblLink_cookiesoft
        '
        Me.LblLink_cookiesoft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblLink_cookiesoft.AutoSize = True
        Me.LblLink_cookiesoft.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblLink_cookiesoft.Location = New System.Drawing.Point(205, 170)
        Me.LblLink_cookiesoft.Name = "LblLink_cookiesoft"
        Me.LblLink_cookiesoft.Size = New System.Drawing.Size(154, 13)
        Me.LblLink_cookiesoft.TabIndex = 9
        Me.LblLink_cookiesoft.TabStop = True
        Me.LblLink_cookiesoft.Text = "http://cookiesoft.lui-studio.net/"
        '
        'Link_library1
        '
        Me.Link_library1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Link_library1.AutoSize = True
        Me.Link_library1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_library1.Location = New System.Drawing.Point(112, 194)
        Me.Link_library1.Name = "Link_library1"
        Me.Link_library1.Size = New System.Drawing.Size(94, 16)
        Me.Link_library1.TabIndex = 10
        Me.Link_library1.TabStop = True
        Me.Link_library1.Text = "ScintillaNET"
        '
        'Link_library2
        '
        Me.Link_library2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Link_library2.AutoSize = True
        Me.Link_library2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_library2.Location = New System.Drawing.Point(247, 194)
        Me.Link_library2.Name = "Link_library2"
        Me.Link_library2.Size = New System.Drawing.Size(230, 16)
        Me.Link_library2.TabIndex = 11
        Me.Link_library2.TabStop = True
        Me.Link_library2.Text = "WeifenLuo.WinFormsUI.Docking"
        '
        'Btn_okay
        '
        Me.Btn_okay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_okay.Location = New System.Drawing.Point(439, 250)
        Me.Btn_okay.Name = "Btn_okay"
        Me.Btn_okay.Size = New System.Drawing.Size(167, 30)
        Me.Btn_okay.TabIndex = 12
        Me.Btn_okay.Text = "Good type, this ""STM93"""
        Me.Btn_okay.UseVisualStyleBackColor = True
        '
        'Pic_Logo
        '
        Me.Pic_Logo.Image = Global.Easier_Data_Editor.My.Resources.Resources.logo
        Me.Pic_Logo.Location = New System.Drawing.Point(40, 35)
        Me.Pic_Logo.Name = "Pic_Logo"
        Me.Pic_Logo.Size = New System.Drawing.Size(235, 35)
        Me.Pic_Logo.TabIndex = 13
        Me.Pic_Logo.TabStop = False
        '
        'Lbl_version_value2
        '
        Me.Lbl_version_value2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_version_value2.AutoSize = True
        Me.Lbl_version_value2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_version_value2.Location = New System.Drawing.Point(113, 236)
        Me.Lbl_version_value2.Name = "Lbl_version_value2"
        Me.Lbl_version_value2.Size = New System.Drawing.Size(112, 13)
        Me.Lbl_version_value2.TabIndex = 8
        Me.Lbl_version_value2.Text = "1.0.0.0 (Build Number)"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 305)
        Me.Controls.Add(Me.Btn_okay)
        Me.Controls.Add(Me.Link_library2)
        Me.Controls.Add(Me.Link_library1)
        Me.Controls.Add(Me.LblLink_cookiesoft)
        Me.Controls.Add(Me.Lbl_version_value2)
        Me.Controls.Add(Me.Lbl_version_value)
        Me.Controls.Add(Me.Lbl_creator_value)
        Me.Controls.Add(Me.Lbl_version)
        Me.Controls.Add(Me.Lbl_libraries)
        Me.Controls.Add(Me.Lbl_creator)
        Me.Controls.Add(Me.Rtb_story)
        Me.Controls.Add(Me.Pic_Logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.Padding = New System.Windows.Forms.Padding(32, 32, 32, 22)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Pic_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Rtb_story As RichTextBox
    Friend WithEvents Lbl_creator As Label
    Friend WithEvents Lbl_libraries As Label
    Friend WithEvents Lbl_version As Label
    Friend WithEvents Lbl_creator_value As Label
    Friend WithEvents Lbl_version_value As Label
    Friend WithEvents LblLink_cookiesoft As LinkLabel
    Friend WithEvents Link_library1 As LinkLabel
    Friend WithEvents Link_library2 As LinkLabel
    Friend WithEvents Btn_okay As Button
    Friend WithEvents Pic_Logo As PictureBox
    Friend WithEvents Lbl_version_value2 As Label
End Class
