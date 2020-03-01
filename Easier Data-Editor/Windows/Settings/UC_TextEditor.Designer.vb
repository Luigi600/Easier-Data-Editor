<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_TextEditor
    Inherits Translation.TranslatableUserControl

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
        Me.Lbl_fontFamily = New System.Windows.Forms.Label()
        Me.Txt_fontFamily = New System.Windows.Forms.TextBox()
        Me.Nud_fontSize = New System.Windows.Forms.NumericUpDown()
        Me.Lbl_fontSize = New System.Windows.Forms.Label()
        Me.Cb_autocompletion = New System.Windows.Forms.CheckBox()
        Me.Cb_folding = New System.Windows.Forms.CheckBox()
        Me.Lbl_autocompletion = New System.Windows.Forms.Label()
        Me.Lbl_folding = New System.Windows.Forms.Label()
        Me.Lbl_lineNumbers = New System.Windows.Forms.Label()
        Me.Cb_lineNumbers = New System.Windows.Forms.CheckBox()
        Me.Lbl_currentLine = New System.Windows.Forms.Label()
        Me.Cb_markCurrentLine = New System.Windows.Forms.CheckBox()
        Me.Lbl_whitespaces = New System.Windows.Forms.Label()
        Me.Cb_whitespaces = New System.Windows.Forms.CheckBox()
        Me.Lbl_bookmarks = New System.Windows.Forms.Label()
        Me.Cb_bookmarks = New System.Windows.Forms.CheckBox()
        Me.Lbl_syncID = New System.Windows.Forms.Label()
        Me.Cb_changeBar = New System.Windows.Forms.CheckBox()
        Me.Lbl_lineColor = New System.Windows.Forms.Label()
        Me.Comb_wrapMode = New System.Windows.Forms.ComboBox()
        Me.Lbl_wrapMode = New System.Windows.Forms.Label()
        Me.TLP_main = New System.Windows.Forms.TableLayoutPanel()
        Me.TLP_lineColor = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_changeLineColor = New System.Windows.Forms.Button()
        Me.Pic_currentLine = New System.Windows.Forms.PictureBox()
        Me.TLP_fontFamily = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_changeFontFamily = New System.Windows.Forms.Button()
        Me.Lbl_changeBar = New System.Windows.Forms.Label()
        Me.Lbl_subfolding = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Cb_subfolding = New System.Windows.Forms.CheckBox()
        Me.Lbl_subfoldingInformation = New System.Windows.Forms.Label()
        Me.Lbl_foldingInformation = New System.Windows.Forms.Label()
        Me.Lbl_autoJumpBySyncID = New System.Windows.Forms.Label()
        Me.Lbl_indention = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Cb_autoJumpBySyncID = New System.Windows.Forms.CheckBox()
        Me.Cb_syncID = New System.Windows.Forms.CheckBox()
        Me.Lbl_scrollbarAnnotations = New System.Windows.Forms.Label()
        Me.Cb_indention = New System.Windows.Forms.CheckBox()
        Me.Cb_scrollbarAnnotations = New System.Windows.Forms.CheckBox()
        Me.FD_fontFamily = New System.Windows.Forms.FontDialog()
        Me.CD_lineColor = New System.Windows.Forms.ColorDialog()
        CType(Me.Nud_fontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TLP_main.SuspendLayout()
        Me.TLP_lineColor.SuspendLayout()
        CType(Me.Pic_currentLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TLP_fontFamily.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_fontFamily
        '
        Me.Lbl_fontFamily.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_fontFamily.AutoSize = True
        Me.Lbl_fontFamily.Location = New System.Drawing.Point(3, 8)
        Me.Lbl_fontFamily.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_fontFamily.Name = "Lbl_fontFamily"
        Me.Lbl_fontFamily.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_fontFamily.TabIndex = 0
        Me.Lbl_fontFamily.Text = "Font Family:"
        '
        'Txt_fontFamily
        '
        Me.Txt_fontFamily.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_fontFamily.Location = New System.Drawing.Point(3, 4)
        Me.Txt_fontFamily.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Txt_fontFamily.Name = "Txt_fontFamily"
        Me.Txt_fontFamily.ReadOnly = True
        Me.Txt_fontFamily.Size = New System.Drawing.Size(140, 20)
        Me.Txt_fontFamily.TabIndex = 1
        '
        'Nud_fontSize
        '
        Me.Nud_fontSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nud_fontSize.Location = New System.Drawing.Point(183, 33)
        Me.Nud_fontSize.Name = "Nud_fontSize"
        Me.Nud_fontSize.Size = New System.Drawing.Size(174, 20)
        Me.Nud_fontSize.TabIndex = 2
        '
        'Lbl_fontSize
        '
        Me.Lbl_fontSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_fontSize.AutoSize = True
        Me.Lbl_fontSize.Location = New System.Drawing.Point(3, 36)
        Me.Lbl_fontSize.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_fontSize.Name = "Lbl_fontSize"
        Me.Lbl_fontSize.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_fontSize.TabIndex = 0
        Me.Lbl_fontSize.Text = "Font Size:"
        '
        'Cb_autocompletion
        '
        Me.Cb_autocompletion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_autocompletion.AutoSize = True
        Me.Cb_autocompletion.Enabled = False
        Me.Cb_autocompletion.Location = New System.Drawing.Point(183, 176)
        Me.Cb_autocompletion.Name = "Cb_autocompletion"
        Me.Cb_autocompletion.Size = New System.Drawing.Size(174, 14)
        Me.Cb_autocompletion.TabIndex = 3
        Me.Cb_autocompletion.UseVisualStyleBackColor = True
        '
        'Cb_folding
        '
        Me.Cb_folding.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_folding.AutoSize = True
        Me.Cb_folding.Location = New System.Drawing.Point(183, 196)
        Me.Cb_folding.Name = "Cb_folding"
        Me.Cb_folding.Size = New System.Drawing.Size(174, 14)
        Me.Cb_folding.TabIndex = 4
        Me.Cb_folding.UseVisualStyleBackColor = True
        '
        'Lbl_autocompletion
        '
        Me.Lbl_autocompletion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_autocompletion.AutoSize = True
        Me.Lbl_autocompletion.Enabled = False
        Me.Lbl_autocompletion.Location = New System.Drawing.Point(3, 176)
        Me.Lbl_autocompletion.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_autocompletion.Name = "Lbl_autocompletion"
        Me.Lbl_autocompletion.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_autocompletion.TabIndex = 0
        Me.Lbl_autocompletion.Text = "Autocompletion:"
        '
        'Lbl_folding
        '
        Me.Lbl_folding.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_folding.AutoSize = True
        Me.Lbl_folding.Location = New System.Drawing.Point(3, 196)
        Me.Lbl_folding.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_folding.Name = "Lbl_folding"
        Me.Lbl_folding.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_folding.TabIndex = 0
        Me.Lbl_folding.Text = "Folding:"
        '
        'Lbl_lineNumbers
        '
        Me.Lbl_lineNumbers.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_lineNumbers.AutoSize = True
        Me.Lbl_lineNumbers.Location = New System.Drawing.Point(3, 59)
        Me.Lbl_lineNumbers.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_lineNumbers.Name = "Lbl_lineNumbers"
        Me.Lbl_lineNumbers.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_lineNumbers.TabIndex = 0
        Me.Lbl_lineNumbers.Text = "Show Line Numbers:"
        '
        'Cb_lineNumbers
        '
        Me.Cb_lineNumbers.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_lineNumbers.AutoSize = True
        Me.Cb_lineNumbers.Location = New System.Drawing.Point(183, 59)
        Me.Cb_lineNumbers.Name = "Cb_lineNumbers"
        Me.Cb_lineNumbers.Size = New System.Drawing.Size(174, 14)
        Me.Cb_lineNumbers.TabIndex = 4
        Me.Cb_lineNumbers.UseVisualStyleBackColor = True
        '
        'Lbl_currentLine
        '
        Me.Lbl_currentLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_currentLine.AutoSize = True
        Me.Lbl_currentLine.Location = New System.Drawing.Point(3, 99)
        Me.Lbl_currentLine.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_currentLine.Name = "Lbl_currentLine"
        Me.Lbl_currentLine.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_currentLine.TabIndex = 0
        Me.Lbl_currentLine.Text = "Mark Current Line:"
        '
        'Cb_markCurrentLine
        '
        Me.Cb_markCurrentLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_markCurrentLine.AutoSize = True
        Me.Cb_markCurrentLine.Location = New System.Drawing.Point(183, 99)
        Me.Cb_markCurrentLine.Name = "Cb_markCurrentLine"
        Me.Cb_markCurrentLine.Size = New System.Drawing.Size(174, 14)
        Me.Cb_markCurrentLine.TabIndex = 4
        Me.Cb_markCurrentLine.UseVisualStyleBackColor = True
        '
        'Lbl_whitespaces
        '
        Me.Lbl_whitespaces.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_whitespaces.AutoSize = True
        Me.Lbl_whitespaces.Location = New System.Drawing.Point(3, 79)
        Me.Lbl_whitespaces.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_whitespaces.Name = "Lbl_whitespaces"
        Me.Lbl_whitespaces.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_whitespaces.TabIndex = 0
        Me.Lbl_whitespaces.Text = "Show Whitespaces:"
        '
        'Cb_whitespaces
        '
        Me.Cb_whitespaces.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_whitespaces.AutoSize = True
        Me.Cb_whitespaces.Location = New System.Drawing.Point(183, 79)
        Me.Cb_whitespaces.Name = "Cb_whitespaces"
        Me.Cb_whitespaces.Size = New System.Drawing.Size(174, 14)
        Me.Cb_whitespaces.TabIndex = 4
        Me.Cb_whitespaces.UseVisualStyleBackColor = True
        '
        'Lbl_bookmarks
        '
        Me.Lbl_bookmarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_bookmarks.AutoSize = True
        Me.Lbl_bookmarks.Location = New System.Drawing.Point(3, 256)
        Me.Lbl_bookmarks.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_bookmarks.Name = "Lbl_bookmarks"
        Me.Lbl_bookmarks.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_bookmarks.TabIndex = 0
        Me.Lbl_bookmarks.Text = "Bookmarks:"
        '
        'Cb_bookmarks
        '
        Me.Cb_bookmarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_bookmarks.AutoSize = True
        Me.Cb_bookmarks.Location = New System.Drawing.Point(183, 255)
        Me.Cb_bookmarks.Name = "Cb_bookmarks"
        Me.Cb_bookmarks.Size = New System.Drawing.Size(174, 14)
        Me.Cb_bookmarks.TabIndex = 4
        Me.Cb_bookmarks.UseVisualStyleBackColor = True
        '
        'Lbl_syncID
        '
        Me.Lbl_syncID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_syncID.AutoSize = True
        Me.Lbl_syncID.Location = New System.Drawing.Point(3, 358)
        Me.Lbl_syncID.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_syncID.Name = "Lbl_syncID"
        Me.Lbl_syncID.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_syncID.TabIndex = 0
        Me.Lbl_syncID.Text = "Synchronization of Selected ID:"
        '
        'Cb_changeBar
        '
        Me.Cb_changeBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_changeBar.AutoSize = True
        Me.Cb_changeBar.Location = New System.Drawing.Point(183, 283)
        Me.Cb_changeBar.Name = "Cb_changeBar"
        Me.Cb_changeBar.Size = New System.Drawing.Size(174, 14)
        Me.Cb_changeBar.TabIndex = 4
        Me.Cb_changeBar.UseVisualStyleBackColor = True
        '
        'Lbl_lineColor
        '
        Me.Lbl_lineColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_lineColor.AutoSize = True
        Me.Lbl_lineColor.Location = New System.Drawing.Point(3, 124)
        Me.Lbl_lineColor.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_lineColor.Name = "Lbl_lineColor"
        Me.Lbl_lineColor.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_lineColor.TabIndex = 0
        Me.Lbl_lineColor.Text = "Current Line Color:"
        '
        'Comb_wrapMode
        '
        Me.Comb_wrapMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_wrapMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comb_wrapMode.FormattingEnabled = True
        Me.Comb_wrapMode.Location = New System.Drawing.Point(183, 149)
        Me.Comb_wrapMode.Name = "Comb_wrapMode"
        Me.Comb_wrapMode.Size = New System.Drawing.Size(174, 21)
        Me.Comb_wrapMode.TabIndex = 6
        '
        'Lbl_wrapMode
        '
        Me.Lbl_wrapMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_wrapMode.AutoSize = True
        Me.Lbl_wrapMode.Location = New System.Drawing.Point(3, 153)
        Me.Lbl_wrapMode.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_wrapMode.Name = "Lbl_wrapMode"
        Me.Lbl_wrapMode.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_wrapMode.TabIndex = 0
        Me.Lbl_wrapMode.Text = "Wrap Mode:"
        '
        'TLP_main
        '
        Me.TLP_main.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TLP_main.AutoSize = True
        Me.TLP_main.ColumnCount = 3
        Me.TLP_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TLP_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TLP_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TLP_main.Controls.Add(Me.TLP_lineColor, 1, 5)
        Me.TLP_main.Controls.Add(Me.Comb_wrapMode, 1, 6)
        Me.TLP_main.Controls.Add(Me.Lbl_fontFamily, 0, 0)
        Me.TLP_main.Controls.Add(Me.Lbl_fontSize, 0, 1)
        Me.TLP_main.Controls.Add(Me.Cb_folding, 1, 8)
        Me.TLP_main.Controls.Add(Me.Lbl_wrapMode, 0, 6)
        Me.TLP_main.Controls.Add(Me.Cb_autocompletion, 1, 7)
        Me.TLP_main.Controls.Add(Me.Nud_fontSize, 1, 1)
        Me.TLP_main.Controls.Add(Me.Lbl_folding, 0, 8)
        Me.TLP_main.Controls.Add(Me.Lbl_lineNumbers, 0, 2)
        Me.TLP_main.Controls.Add(Me.Lbl_autocompletion, 0, 7)
        Me.TLP_main.Controls.Add(Me.Lbl_lineColor, 0, 5)
        Me.TLP_main.Controls.Add(Me.Cb_markCurrentLine, 1, 4)
        Me.TLP_main.Controls.Add(Me.Cb_whitespaces, 1, 3)
        Me.TLP_main.Controls.Add(Me.Cb_lineNumbers, 1, 2)
        Me.TLP_main.Controls.Add(Me.Lbl_whitespaces, 0, 3)
        Me.TLP_main.Controls.Add(Me.Lbl_currentLine, 0, 4)
        Me.TLP_main.Controls.Add(Me.TLP_fontFamily, 1, 0)
        Me.TLP_main.Controls.Add(Me.Lbl_changeBar, 0, 11)
        Me.TLP_main.Controls.Add(Me.Lbl_bookmarks, 0, 10)
        Me.TLP_main.Controls.Add(Me.Lbl_subfolding, 0, 9)
        Me.TLP_main.Controls.Add(Me.Cb_changeBar, 1, 11)
        Me.TLP_main.Controls.Add(Me.Cb_bookmarks, 1, 10)
        Me.TLP_main.Controls.Add(Me.PictureBox1, 2, 10)
        Me.TLP_main.Controls.Add(Me.Cb_subfolding, 1, 9)
        Me.TLP_main.Controls.Add(Me.Lbl_subfoldingInformation, 2, 9)
        Me.TLP_main.Controls.Add(Me.Lbl_foldingInformation, 2, 8)
        Me.TLP_main.Controls.Add(Me.Lbl_autoJumpBySyncID, 0, 15)
        Me.TLP_main.Controls.Add(Me.Lbl_syncID, 0, 14)
        Me.TLP_main.Controls.Add(Me.Lbl_indention, 0, 13)
        Me.TLP_main.Controls.Add(Me.PictureBox2, 2, 13)
        Me.TLP_main.Controls.Add(Me.Cb_autoJumpBySyncID, 1, 15)
        Me.TLP_main.Controls.Add(Me.Cb_syncID, 1, 14)
        Me.TLP_main.Controls.Add(Me.Lbl_scrollbarAnnotations, 0, 12)
        Me.TLP_main.Controls.Add(Me.Cb_indention, 1, 13)
        Me.TLP_main.Controls.Add(Me.Cb_scrollbarAnnotations, 1, 12)
        Me.TLP_main.Location = New System.Drawing.Point(19, 19)
        Me.TLP_main.Margin = New System.Windows.Forms.Padding(16, 16, 16, 0)
        Me.TLP_main.Name = "TLP_main"
        Me.TLP_main.RowCount = 17
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLP_main.Size = New System.Drawing.Size(542, 425)
        Me.TLP_main.TabIndex = 7
        '
        'TLP_lineColor
        '
        Me.TLP_lineColor.AutoSize = True
        Me.TLP_lineColor.ColumnCount = 2
        Me.TLP_lineColor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP_lineColor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_lineColor.Controls.Add(Me.Btn_changeLineColor, 1, 0)
        Me.TLP_lineColor.Controls.Add(Me.Pic_currentLine, 0, 0)
        Me.TLP_lineColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP_lineColor.Location = New System.Drawing.Point(181, 117)
        Me.TLP_lineColor.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.TLP_lineColor.Name = "TLP_lineColor"
        Me.TLP_lineColor.RowCount = 1
        Me.TLP_lineColor.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_lineColor.Size = New System.Drawing.Size(179, 29)
        Me.TLP_lineColor.TabIndex = 14
        '
        'Btn_changeLineColor
        '
        Me.Btn_changeLineColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_changeLineColor.Location = New System.Drawing.Point(146, 3)
        Me.Btn_changeLineColor.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.Btn_changeLineColor.Name = "Btn_changeLineColor"
        Me.Btn_changeLineColor.Size = New System.Drawing.Size(31, 23)
        Me.Btn_changeLineColor.TabIndex = 10
        Me.Btn_changeLineColor.Text = "..."
        Me.Btn_changeLineColor.UseVisualStyleBackColor = True
        '
        'Pic_currentLine
        '
        Me.Pic_currentLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_currentLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pic_currentLine.Location = New System.Drawing.Point(3, 3)
        Me.Pic_currentLine.Name = "Pic_currentLine"
        Me.Pic_currentLine.Size = New System.Drawing.Size(137, 23)
        Me.Pic_currentLine.TabIndex = 11
        Me.Pic_currentLine.TabStop = False
        '
        'TLP_fontFamily
        '
        Me.TLP_fontFamily.AutoSize = True
        Me.TLP_fontFamily.ColumnCount = 2
        Me.TLP_fontFamily.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP_fontFamily.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_fontFamily.Controls.Add(Me.Btn_changeFontFamily, 1, 0)
        Me.TLP_fontFamily.Controls.Add(Me.Txt_fontFamily, 0, 0)
        Me.TLP_fontFamily.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP_fontFamily.Location = New System.Drawing.Point(181, 1)
        Me.TLP_fontFamily.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.TLP_fontFamily.Name = "TLP_fontFamily"
        Me.TLP_fontFamily.RowCount = 1
        Me.TLP_fontFamily.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_fontFamily.Size = New System.Drawing.Size(179, 29)
        Me.TLP_fontFamily.TabIndex = 16
        '
        'Btn_changeFontFamily
        '
        Me.Btn_changeFontFamily.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_changeFontFamily.Location = New System.Drawing.Point(146, 3)
        Me.Btn_changeFontFamily.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.Btn_changeFontFamily.Name = "Btn_changeFontFamily"
        Me.Btn_changeFontFamily.Size = New System.Drawing.Size(31, 23)
        Me.Btn_changeFontFamily.TabIndex = 10
        Me.Btn_changeFontFamily.Text = "..."
        Me.Btn_changeFontFamily.UseVisualStyleBackColor = True
        '
        'Lbl_changeBar
        '
        Me.Lbl_changeBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_changeBar.AutoSize = True
        Me.Lbl_changeBar.Location = New System.Drawing.Point(3, 283)
        Me.Lbl_changeBar.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_changeBar.Name = "Lbl_changeBar"
        Me.Lbl_changeBar.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_changeBar.TabIndex = 15
        Me.Lbl_changeBar.Text = "Show ""Change Bar"":"
        '
        'Lbl_subfolding
        '
        Me.Lbl_subfolding.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_subfolding.AutoSize = True
        Me.Lbl_subfolding.Location = New System.Drawing.Point(3, 222)
        Me.Lbl_subfolding.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_subfolding.Name = "Lbl_subfolding"
        Me.Lbl_subfolding.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_subfolding.TabIndex = 23
        Me.Lbl_subfolding.Text = "Subfolding:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Easier_Data_Editor.My.Resources.Resources.manual_bookmark
        Me.PictureBox1.Location = New System.Drawing.Point(363, 248)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Cb_subfolding
        '
        Me.Cb_subfolding.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_subfolding.AutoSize = True
        Me.Cb_subfolding.Location = New System.Drawing.Point(183, 222)
        Me.Cb_subfolding.Name = "Cb_subfolding"
        Me.Cb_subfolding.Size = New System.Drawing.Size(174, 14)
        Me.Cb_subfolding.TabIndex = 24
        Me.Cb_subfolding.UseVisualStyleBackColor = True
        '
        'Lbl_subfoldingInformation
        '
        Me.Lbl_subfoldingInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_subfoldingInformation.AutoSize = True
        Me.Lbl_subfoldingInformation.Location = New System.Drawing.Point(363, 216)
        Me.Lbl_subfoldingInformation.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_subfoldingInformation.Name = "Lbl_subfoldingInformation"
        Me.Lbl_subfoldingInformation.Size = New System.Drawing.Size(176, 26)
        Me.Lbl_subfoldingInformation.TabIndex = 25
        Me.Lbl_subfoldingInformation.Text = "Includes bdy/itr/b-, c-, o-, wpoint/phases"
        '
        'Lbl_foldingInformation
        '
        Me.Lbl_foldingInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_foldingInformation.AutoSize = True
        Me.Lbl_foldingInformation.Location = New System.Drawing.Point(363, 196)
        Me.Lbl_foldingInformation.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_foldingInformation.Name = "Lbl_foldingInformation"
        Me.Lbl_foldingInformation.Size = New System.Drawing.Size(176, 14)
        Me.Lbl_foldingInformation.TabIndex = 26
        Me.Lbl_foldingInformation.Text = "Needs more loading time!"
        '
        'Lbl_autoJumpBySyncID
        '
        Me.Lbl_autoJumpBySyncID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_autoJumpBySyncID.AutoSize = True
        Me.Lbl_autoJumpBySyncID.Location = New System.Drawing.Point(20, 378)
        Me.Lbl_autoJumpBySyncID.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Lbl_autoJumpBySyncID.Name = "Lbl_autoJumpBySyncID"
        Me.Lbl_autoJumpBySyncID.Size = New System.Drawing.Size(157, 13)
        Me.Lbl_autoJumpBySyncID.TabIndex = 21
        Me.Lbl_autoJumpBySyncID.Text = "Sync Frame Selection:"
        '
        'Lbl_indention
        '
        Me.Lbl_indention.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_indention.AutoSize = True
        Me.Lbl_indention.Location = New System.Drawing.Point(3, 331)
        Me.Lbl_indention.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_indention.Name = "Lbl_indention"
        Me.Lbl_indention.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_indention.TabIndex = 18
        Me.Lbl_indention.Text = "Indention:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Easier_Data_Editor.My.Resources.Resources.indention
        Me.PictureBox2.Location = New System.Drawing.Point(363, 323)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(117, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 20
        Me.PictureBox2.TabStop = False
        '
        'Cb_autoJumpBySyncID
        '
        Me.Cb_autoJumpBySyncID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_autoJumpBySyncID.AutoSize = True
        Me.Cb_autoJumpBySyncID.Location = New System.Drawing.Point(183, 378)
        Me.Cb_autoJumpBySyncID.Name = "Cb_autoJumpBySyncID"
        Me.Cb_autoJumpBySyncID.Size = New System.Drawing.Size(174, 14)
        Me.Cb_autoJumpBySyncID.TabIndex = 22
        Me.Cb_autoJumpBySyncID.UseVisualStyleBackColor = True
        '
        'Cb_syncID
        '
        Me.Cb_syncID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_syncID.AutoSize = True
        Me.Cb_syncID.Location = New System.Drawing.Point(183, 358)
        Me.Cb_syncID.Name = "Cb_syncID"
        Me.Cb_syncID.Size = New System.Drawing.Size(174, 14)
        Me.Cb_syncID.TabIndex = 4
        Me.Cb_syncID.UseVisualStyleBackColor = True
        '
        'Lbl_scrollbarAnnotations
        '
        Me.Lbl_scrollbarAnnotations.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_scrollbarAnnotations.AutoSize = True
        Me.Lbl_scrollbarAnnotations.Location = New System.Drawing.Point(3, 303)
        Me.Lbl_scrollbarAnnotations.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_scrollbarAnnotations.Name = "Lbl_scrollbarAnnotations"
        Me.Lbl_scrollbarAnnotations.Size = New System.Drawing.Size(174, 13)
        Me.Lbl_scrollbarAnnotations.TabIndex = 27
        Me.Lbl_scrollbarAnnotations.Text = "Scrollbar Annotations:"
        '
        'Cb_indention
        '
        Me.Cb_indention.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_indention.AutoSize = True
        Me.Cb_indention.Location = New System.Drawing.Point(183, 330)
        Me.Cb_indention.Name = "Cb_indention"
        Me.Cb_indention.Size = New System.Drawing.Size(174, 14)
        Me.Cb_indention.TabIndex = 19
        Me.Cb_indention.UseVisualStyleBackColor = True
        '
        'Cb_scrollbarAnnotations
        '
        Me.Cb_scrollbarAnnotations.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_scrollbarAnnotations.AutoSize = True
        Me.Cb_scrollbarAnnotations.Location = New System.Drawing.Point(183, 303)
        Me.Cb_scrollbarAnnotations.Name = "Cb_scrollbarAnnotations"
        Me.Cb_scrollbarAnnotations.Size = New System.Drawing.Size(174, 14)
        Me.Cb_scrollbarAnnotations.TabIndex = 28
        Me.Cb_scrollbarAnnotations.UseVisualStyleBackColor = True
        '
        'FD_fontFamily
        '
        Me.FD_fontFamily.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        '
        'UC_TextEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.Controls.Add(Me.TLP_main)
        Me.Name = "UC_TextEditor"
        Me.Padding = New System.Windows.Forms.Padding(16, 16, 16, 0)
        Me.Size = New System.Drawing.Size(580, 444)
        CType(Me.Nud_fontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TLP_main.ResumeLayout(False)
        Me.TLP_main.PerformLayout()
        Me.TLP_lineColor.ResumeLayout(False)
        CType(Me.Pic_currentLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TLP_fontFamily.ResumeLayout(False)
        Me.TLP_fontFamily.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_fontFamily As Label
    Friend WithEvents Txt_fontFamily As TextBox
    Friend WithEvents Nud_fontSize As NumericUpDown
    Friend WithEvents Lbl_fontSize As Label
    Friend WithEvents Cb_autocompletion As CheckBox
    Friend WithEvents Cb_folding As CheckBox
    Friend WithEvents Lbl_autocompletion As Label
    Friend WithEvents Lbl_folding As Label
    Friend WithEvents Lbl_lineNumbers As Label
    Friend WithEvents Cb_lineNumbers As CheckBox
    Friend WithEvents Lbl_currentLine As Label
    Friend WithEvents Cb_markCurrentLine As CheckBox
    Friend WithEvents Lbl_whitespaces As Label
    Friend WithEvents Cb_whitespaces As CheckBox
    Friend WithEvents Lbl_bookmarks As Label
    Friend WithEvents Cb_bookmarks As CheckBox
    Friend WithEvents Lbl_syncID As Label
    Friend WithEvents Cb_changeBar As CheckBox
    Friend WithEvents Lbl_lineColor As Label
    Friend WithEvents Comb_wrapMode As ComboBox
    Friend WithEvents Lbl_wrapMode As Label
    Friend WithEvents TLP_main As TableLayoutPanel
    Friend WithEvents TLP_lineColor As TableLayoutPanel
    Friend WithEvents Btn_changeLineColor As Button
    Friend WithEvents Lbl_changeBar As Label
    Friend WithEvents Cb_syncID As CheckBox
    Friend WithEvents TLP_fontFamily As TableLayoutPanel
    Friend WithEvents Btn_changeFontFamily As Button
    Friend WithEvents FD_fontFamily As FontDialog
    Friend WithEvents Pic_currentLine As PictureBox
    Friend WithEvents CD_lineColor As ColorDialog
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Lbl_indention As Label
    Friend WithEvents Cb_indention As CheckBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Lbl_autoJumpBySyncID As Label
    Friend WithEvents Cb_autoJumpBySyncID As CheckBox
    Friend WithEvents Lbl_subfolding As Label
    Friend WithEvents Cb_subfolding As CheckBox
    Friend WithEvents Lbl_subfoldingInformation As Label
    Friend WithEvents Lbl_foldingInformation As Label
    Friend WithEvents Lbl_scrollbarAnnotations As Label
    Friend WithEvents Cb_scrollbarAnnotations As CheckBox
End Class
