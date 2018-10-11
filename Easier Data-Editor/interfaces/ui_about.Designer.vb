<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_about
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_about))
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.rtb_story = New System.Windows.Forms.RichTextBox()
        Me.lbl_creator = New System.Windows.Forms.Label()
        Me.lbl_libraries = New System.Windows.Forms.Label()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.lbl_creator_value = New System.Windows.Forms.Label()
        Me.lbl_version_value = New System.Windows.Forms.Label()
        Me.lblLink_cookiesoft = New System.Windows.Forms.LinkLabel()
        Me.lblLink_library1 = New System.Windows.Forms.LinkLabel()
        Me.lblLink_library2 = New System.Windows.Forms.LinkLabel()
        Me.btn_okay = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(35, 253)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(205, 25)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Easier Data-Editor"
        Me.lbl_title.Visible = False
        '
        'rtb_story
        '
        Me.rtb_story.BackColor = System.Drawing.SystemColors.Control
        Me.rtb_story.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtb_story.Location = New System.Drawing.Point(40, 78)
        Me.rtb_story.Name = "rtb_story"
        Me.rtb_story.ReadOnly = True
        Me.rtb_story.Size = New System.Drawing.Size(566, 70)
        Me.rtb_story.TabIndex = 2
        Me.rtb_story.Text = resources.GetString("rtb_story.Text")
        '
        'lbl_creator
        '
        Me.lbl_creator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_creator.AutoSize = True
        Me.lbl_creator.Location = New System.Drawing.Point(37, 153)
        Me.lbl_creator.Name = "lbl_creator"
        Me.lbl_creator.Size = New System.Drawing.Size(44, 13)
        Me.lbl_creator.TabIndex = 3
        Me.lbl_creator.Text = "Creator:"
        '
        'lbl_libraries
        '
        Me.lbl_libraries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_libraries.AutoSize = True
        Me.lbl_libraries.Location = New System.Drawing.Point(37, 179)
        Me.lbl_libraries.Name = "lbl_libraries"
        Me.lbl_libraries.Size = New System.Drawing.Size(49, 13)
        Me.lbl_libraries.TabIndex = 4
        Me.lbl_libraries.Text = "Libraries:"
        '
        'lbl_version
        '
        Me.lbl_version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_version.AutoSize = True
        Me.lbl_version.Location = New System.Drawing.Point(37, 205)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(45, 13)
        Me.lbl_version.TabIndex = 5
        Me.lbl_version.Text = "Version:"
        '
        'lbl_creator_value
        '
        Me.lbl_creator_value.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_creator_value.AutoSize = True
        Me.lbl_creator_value.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_creator_value.Location = New System.Drawing.Point(112, 151)
        Me.lbl_creator_value.Name = "lbl_creator_value"
        Me.lbl_creator_value.Size = New System.Drawing.Size(65, 16)
        Me.lbl_creator_value.TabIndex = 6
        Me.lbl_creator_value.Text = "Luigi600"
        '
        'lbl_version_value
        '
        Me.lbl_version_value.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_version_value.AutoSize = True
        Me.lbl_version_value.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_version_value.Location = New System.Drawing.Point(112, 203)
        Me.lbl_version_value.Name = "lbl_version_value"
        Me.lbl_version_value.Size = New System.Drawing.Size(114, 16)
        Me.lbl_version_value.TabIndex = 8
        Me.lbl_version_value.Text = "1.0.0.0 (STM93)"
        '
        'lblLink_cookiesoft
        '
        Me.lblLink_cookiesoft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLink_cookiesoft.AutoSize = True
        Me.lblLink_cookiesoft.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLink_cookiesoft.Location = New System.Drawing.Point(205, 153)
        Me.lblLink_cookiesoft.Name = "lblLink_cookiesoft"
        Me.lblLink_cookiesoft.Size = New System.Drawing.Size(154, 13)
        Me.lblLink_cookiesoft.TabIndex = 9
        Me.lblLink_cookiesoft.TabStop = True
        Me.lblLink_cookiesoft.Text = "http://cookiesoft.lui-studio.net/"
        '
        'lblLink_library1
        '
        Me.lblLink_library1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLink_library1.AutoSize = True
        Me.lblLink_library1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLink_library1.Location = New System.Drawing.Point(112, 177)
        Me.lblLink_library1.Name = "lblLink_library1"
        Me.lblLink_library1.Size = New System.Drawing.Size(179, 16)
        Me.lblLink_library1.TabIndex = 10
        Me.lblLink_library1.TabStop = True
        Me.lblLink_library1.Text = "ICSharpCode.AvalonEdit"
        '
        'lblLink_library2
        '
        Me.lblLink_library2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLink_library2.AutoSize = True
        Me.lblLink_library2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLink_library2.Location = New System.Drawing.Point(310, 177)
        Me.lblLink_library2.Name = "lblLink_library2"
        Me.lblLink_library2.Size = New System.Drawing.Size(230, 16)
        Me.lblLink_library2.TabIndex = 11
        Me.lblLink_library2.TabStop = True
        Me.lblLink_library2.Text = "WeifenLuo.WinFormsUI.Docking"
        '
        'btn_okay
        '
        Me.btn_okay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_okay.Location = New System.Drawing.Point(439, 233)
        Me.btn_okay.Name = "btn_okay"
        Me.btn_okay.Size = New System.Drawing.Size(167, 30)
        Me.btn_okay.TabIndex = 12
        Me.btn_okay.Text = "Good type, this ""STM93"""
        Me.btn_okay.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Easier_Data_Editor.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(40, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(235, 35)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'ui_about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 288)
        Me.Controls.Add(Me.btn_okay)
        Me.Controls.Add(Me.lblLink_library2)
        Me.Controls.Add(Me.lblLink_library1)
        Me.Controls.Add(Me.lblLink_cookiesoft)
        Me.Controls.Add(Me.lbl_version_value)
        Me.Controls.Add(Me.lbl_creator_value)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.lbl_libraries)
        Me.Controls.Add(Me.lbl_creator)
        Me.Controls.Add(Me.rtb_story)
        Me.Controls.Add(Me.lbl_title)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ui_about"
        Me.Padding = New System.Windows.Forms.Padding(32, 32, 32, 22)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_title As Label
    Friend WithEvents rtb_story As RichTextBox
    Friend WithEvents lbl_creator As Label
    Friend WithEvents lbl_libraries As Label
    Friend WithEvents lbl_version As Label
    Friend WithEvents lbl_creator_value As Label
    Friend WithEvents lbl_version_value As Label
    Friend WithEvents lblLink_cookiesoft As LinkLabel
    Friend WithEvents lblLink_library1 As LinkLabel
    Friend WithEvents lblLink_library2 As LinkLabel
    Friend WithEvents btn_okay As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
