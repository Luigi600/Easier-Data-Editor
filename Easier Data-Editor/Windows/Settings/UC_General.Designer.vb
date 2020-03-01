<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_General
    Inherits Translation.TranslatableUserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.Lbl_recentFiles = New System.Windows.Forms.Label()
        Me.Nud_recentFiles = New System.Windows.Forms.NumericUpDown()
        Me.Lbl_saveSession = New System.Windows.Forms.Label()
        Me.Cb_saveSession = New System.Windows.Forms.CheckBox()
        Me.Cb_multipleOpening = New System.Windows.Forms.CheckBox()
        Me.Lbl_multipleOpening = New System.Windows.Forms.Label()
        Me.Lbl_fvK = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_lang = New System.Windows.Forms.Label()
        Me.Comb_lang = New System.Windows.Forms.ComboBox()
        Me.Btn_langDir = New System.Windows.Forms.Button()
        Me.Lbl_lineChar = New System.Windows.Forms.Label()
        Me.Comb_newline = New System.Windows.Forms.ComboBox()
        CType(Me.Nud_recentFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_recentFiles
        '
        Me.Lbl_recentFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_recentFiles.AutoSize = True
        Me.Lbl_recentFiles.Location = New System.Drawing.Point(3, 35)
        Me.Lbl_recentFiles.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_recentFiles.Name = "Lbl_recentFiles"
        Me.Lbl_recentFiles.Size = New System.Drawing.Size(155, 13)
        Me.Lbl_recentFiles.TabIndex = 0
        Me.Lbl_recentFiles.Text = "Recent Files Capacity:"
        Me.Lbl_recentFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Nud_recentFiles
        '
        Me.Nud_recentFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nud_recentFiles.Location = New System.Drawing.Point(164, 32)
        Me.Nud_recentFiles.Name = "Nud_recentFiles"
        Me.Nud_recentFiles.Size = New System.Drawing.Size(155, 20)
        Me.Nud_recentFiles.TabIndex = 1
        '
        'Lbl_saveSession
        '
        Me.Lbl_saveSession.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_saveSession.AutoSize = True
        Me.Lbl_saveSession.Location = New System.Drawing.Point(3, 58)
        Me.Lbl_saveSession.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_saveSession.Name = "Lbl_saveSession"
        Me.Lbl_saveSession.Size = New System.Drawing.Size(155, 13)
        Me.Lbl_saveSession.TabIndex = 0
        Me.Lbl_saveSession.Text = "Save Session:"
        Me.Lbl_saveSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cb_saveSession
        '
        Me.Cb_saveSession.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_saveSession.AutoSize = True
        Me.Cb_saveSession.Location = New System.Drawing.Point(164, 58)
        Me.Cb_saveSession.Name = "Cb_saveSession"
        Me.Cb_saveSession.Size = New System.Drawing.Size(155, 14)
        Me.Cb_saveSession.TabIndex = 2
        Me.Cb_saveSession.UseVisualStyleBackColor = True
        '
        'Cb_multipleOpening
        '
        Me.Cb_multipleOpening.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_multipleOpening.AutoSize = True
        Me.Cb_multipleOpening.Location = New System.Drawing.Point(164, 78)
        Me.Cb_multipleOpening.Name = "Cb_multipleOpening"
        Me.Cb_multipleOpening.Size = New System.Drawing.Size(155, 14)
        Me.Cb_multipleOpening.TabIndex = 2
        Me.Cb_multipleOpening.UseVisualStyleBackColor = True
        '
        'Lbl_multipleOpening
        '
        Me.Lbl_multipleOpening.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_multipleOpening.AutoSize = True
        Me.Lbl_multipleOpening.Location = New System.Drawing.Point(3, 78)
        Me.Lbl_multipleOpening.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_multipleOpening.Name = "Lbl_multipleOpening"
        Me.Lbl_multipleOpening.Size = New System.Drawing.Size(155, 13)
        Me.Lbl_multipleOpening.TabIndex = 0
        Me.Lbl_multipleOpening.Text = "Multiple Opening:"
        Me.Lbl_multipleOpening.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_fvK
        '
        Me.Lbl_fvK.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_fvK.AutoSize = True
        Me.Lbl_fvK.Location = New System.Drawing.Point(3, 98)
        Me.Lbl_fvK.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_fvK.Name = "Lbl_fvK"
        Me.Lbl_fvK.Size = New System.Drawing.Size(155, 26)
        Me.Lbl_fvK.TabIndex = 0
        Me.Lbl_fvK.Text = "Change Frame Viewer to appropriate data file:"
        Me.Lbl_fvK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox3
        '
        Me.CheckBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(164, 104)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(155, 14)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_lang, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_fvK, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_multipleOpening, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_saveSession, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_recentFiles, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Comb_lang, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox3, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Cb_multipleOpening, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Cb_saveSession, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Nud_recentFiles, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_langDir, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_lineChar, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Comb_newline, 1, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(19, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(484, 154)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Lbl_lang
        '
        Me.Lbl_lang.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_lang.AutoSize = True
        Me.Lbl_lang.Location = New System.Drawing.Point(3, 8)
        Me.Lbl_lang.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_lang.Name = "Lbl_lang"
        Me.Lbl_lang.Size = New System.Drawing.Size(155, 13)
        Me.Lbl_lang.TabIndex = 3
        Me.Lbl_lang.Text = "Language:"
        '
        'Comb_lang
        '
        Me.Comb_lang.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comb_lang.FormattingEnabled = True
        Me.Comb_lang.Location = New System.Drawing.Point(164, 4)
        Me.Comb_lang.Name = "Comb_lang"
        Me.Comb_lang.Size = New System.Drawing.Size(155, 21)
        Me.Comb_lang.TabIndex = 4
        '
        'Btn_langDir
        '
        Me.Btn_langDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_langDir.Location = New System.Drawing.Point(325, 3)
        Me.Btn_langDir.Name = "Btn_langDir"
        Me.Btn_langDir.Size = New System.Drawing.Size(156, 23)
        Me.Btn_langDir.TabIndex = 5
        Me.Btn_langDir.Text = "Open Directory"
        Me.Btn_langDir.UseVisualStyleBackColor = True
        '
        'Lbl_lineChar
        '
        Me.Lbl_lineChar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_lineChar.AutoSize = True
        Me.Lbl_lineChar.Location = New System.Drawing.Point(3, 134)
        Me.Lbl_lineChar.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_lineChar.Name = "Lbl_lineChar"
        Me.Lbl_lineChar.Size = New System.Drawing.Size(155, 13)
        Me.Lbl_lineChar.TabIndex = 6
        Me.Lbl_lineChar.Text = "Newline Char:"
        '
        'Comb_newline
        '
        Me.Comb_newline.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_newline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comb_newline.FormattingEnabled = True
        Me.Comb_newline.Items.AddRange(New Object() {"LF (=Line Feed ; Linux etc)", "CR (=Carriage Return ; Mac OS)", "CR LF (CR & LF ; Windows)"})
        Me.Comb_newline.Location = New System.Drawing.Point(164, 130)
        Me.Comb_newline.Name = "Comb_newline"
        Me.Comb_newline.Size = New System.Drawing.Size(155, 21)
        Me.Comb_newline.TabIndex = 7
        '
        'UC_General
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UC_General"
        Me.Padding = New System.Windows.Forms.Padding(16)
        Me.Size = New System.Drawing.Size(522, 192)
        CType(Me.Nud_recentFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_recentFiles As Label
    Friend WithEvents Nud_recentFiles As NumericUpDown
    Friend WithEvents Lbl_saveSession As Label
    Friend WithEvents Cb_saveSession As CheckBox
    Friend WithEvents Cb_multipleOpening As CheckBox
    Friend WithEvents Lbl_multipleOpening As Label
    Friend WithEvents Lbl_fvK As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Lbl_lang As Label
    Friend WithEvents Comb_lang As ComboBox
    Friend WithEvents Btn_langDir As Button
    Friend WithEvents Lbl_lineChar As Label
    Friend WithEvents Comb_newline As ComboBox
End Class
