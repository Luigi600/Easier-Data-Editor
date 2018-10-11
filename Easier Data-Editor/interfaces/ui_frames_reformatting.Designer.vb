<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ui_frames_reformatting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ui_frames_reformatting))
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.gb_frame = New System.Windows.Forms.GroupBox()
        Me.gb_substructure = New System.Windows.Forms.GroupBox()
        Me.pal_sub_menu = New System.Windows.Forms.Panel()
        Me.comb_substructure = New System.Windows.Forms.ComboBox()
        Me.lbl_sub_description = New System.Windows.Forms.Label()
        Me.lbl_description = New System.Windows.Forms.Label()
        Me.btn_abort = New System.Windows.Forms.Button()
        Me.btn_doIt = New System.Windows.Forms.Button()
        Me.lbl_description_1 = New System.Windows.Forms.Label()
        Me.lbl_important_info = New System.Windows.Forms.Label()
        Me.splitCon_main = New System.Windows.Forms.SplitContainer()
        Me.lbl_description_2 = New System.Windows.Forms.Label()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.splitCon_main_2 = New System.Windows.Forms.SplitContainer()
        Me.lv_files = New System.Windows.Forms.ListView()
        Me.col_file = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rtb_eg_1 = New System.Windows.Forms.RichTextBox()
        Me.rtb_eg_2 = New System.Windows.Forms.RichTextBox()
        Me.gb_substructure.SuspendLayout()
        Me.pal_sub_menu.SuspendLayout()
        CType(Me.splitCon_main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitCon_main.Panel1.SuspendLayout()
        Me.splitCon_main.Panel2.SuspendLayout()
        Me.splitCon_main.SuspendLayout()
        CType(Me.splitCon_main_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitCon_main_2.Panel1.SuspendLayout()
        Me.splitCon_main_2.Panel2.SuspendLayout()
        Me.splitCon_main_2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(24, 24)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(231, 25)
        Me.lbl_title.TabIndex = 1
        Me.lbl_title.Text = "Frames Reformatting"
        '
        'gb_frame
        '
        Me.gb_frame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_frame.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_frame.Location = New System.Drawing.Point(0, 0)
        Me.gb_frame.Name = "gb_frame"
        Me.gb_frame.Padding = New System.Windows.Forms.Padding(10)
        Me.gb_frame.Size = New System.Drawing.Size(350, 215)
        Me.gb_frame.TabIndex = 4
        Me.gb_frame.TabStop = False
        Me.gb_frame.Text = "Frame"
        '
        'gb_substructure
        '
        Me.gb_substructure.Controls.Add(Me.pal_sub_menu)
        Me.gb_substructure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_substructure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_substructure.Location = New System.Drawing.Point(0, 0)
        Me.gb_substructure.Name = "gb_substructure"
        Me.gb_substructure.Padding = New System.Windows.Forms.Padding(10)
        Me.gb_substructure.Size = New System.Drawing.Size(301, 215)
        Me.gb_substructure.TabIndex = 5
        Me.gb_substructure.TabStop = False
        Me.gb_substructure.Text = "Substructure"
        '
        'pal_sub_menu
        '
        Me.pal_sub_menu.Controls.Add(Me.comb_substructure)
        Me.pal_sub_menu.Controls.Add(Me.lbl_sub_description)
        Me.pal_sub_menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_sub_menu.Location = New System.Drawing.Point(10, 25)
        Me.pal_sub_menu.Name = "pal_sub_menu"
        Me.pal_sub_menu.Size = New System.Drawing.Size(281, 63)
        Me.pal_sub_menu.TabIndex = 4
        '
        'comb_substructure
        '
        Me.comb_substructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comb_substructure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comb_substructure.FormattingEnabled = True
        Me.comb_substructure.Items.AddRange(New Object() {"Body", "Itr", "Blood Point", "Weapon Point", "Catch Point", "Object Point"})
        Me.comb_substructure.Location = New System.Drawing.Point(0, 27)
        Me.comb_substructure.Name = "comb_substructure"
        Me.comb_substructure.Size = New System.Drawing.Size(277, 21)
        Me.comb_substructure.TabIndex = 10
        '
        'lbl_sub_description
        '
        Me.lbl_sub_description.AutoSize = True
        Me.lbl_sub_description.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sub_description.Location = New System.Drawing.Point(3, 4)
        Me.lbl_sub_description.Name = "lbl_sub_description"
        Me.lbl_sub_description.Size = New System.Drawing.Size(178, 13)
        Me.lbl_sub_description.TabIndex = 9
        Me.lbl_sub_description.Text = "Substructure is body, itr, wpoint, etc."
        '
        'lbl_description
        '
        Me.lbl_description.AutoSize = True
        Me.lbl_description.Location = New System.Drawing.Point(27, 55)
        Me.lbl_description.Name = "lbl_description"
        Me.lbl_description.Size = New System.Drawing.Size(179, 13)
        Me.lbl_description.TabIndex = 6
        Me.lbl_description.Text = "A tool to edit format of all frames. Eg:"
        '
        'btn_abort
        '
        Me.btn_abort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_abort.Location = New System.Drawing.Point(27, 509)
        Me.btn_abort.Name = "btn_abort"
        Me.btn_abort.Size = New System.Drawing.Size(125, 30)
        Me.btn_abort.TabIndex = 7
        Me.btn_abort.Text = "Abort"
        Me.btn_abort.UseVisualStyleBackColor = True
        '
        'btn_doIt
        '
        Me.btn_doIt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_doIt.Location = New System.Drawing.Point(549, 509)
        Me.btn_doIt.Name = "btn_doIt"
        Me.btn_doIt.Size = New System.Drawing.Size(125, 30)
        Me.btn_doIt.TabIndex = 8
        Me.btn_doIt.Text = "Change"
        Me.btn_doIt.UseVisualStyleBackColor = True
        '
        'lbl_description_1
        '
        Me.lbl_description_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_description_1.AutoSize = True
        Me.lbl_description_1.Location = New System.Drawing.Point(27, 446)
        Me.lbl_description_1.Name = "lbl_description_1"
        Me.lbl_description_1.Size = New System.Drawing.Size(344, 52)
        Me.lbl_description_1.TabIndex = 9
        Me.lbl_description_1.Text = resources.GetString("lbl_description_1.Text")
        '
        'lbl_important_info
        '
        Me.lbl_important_info.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_important_info.AutoSize = True
        Me.lbl_important_info.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_important_info.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_important_info.Location = New System.Drawing.Point(504, 484)
        Me.lbl_important_info.Name = "lbl_important_info"
        Me.lbl_important_info.Size = New System.Drawing.Size(170, 13)
        Me.lbl_important_info.TabIndex = 10
        Me.lbl_important_info.Text = "All %..% are case sensitive!!!"
        '
        'splitCon_main
        '
        Me.splitCon_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCon_main.Location = New System.Drawing.Point(0, 0)
        Me.splitCon_main.Name = "splitCon_main"
        '
        'splitCon_main.Panel1
        '
        Me.splitCon_main.Panel1.Controls.Add(Me.gb_frame)
        Me.splitCon_main.Panel1MinSize = 200
        '
        'splitCon_main.Panel2
        '
        Me.splitCon_main.Panel2.Controls.Add(Me.gb_substructure)
        Me.splitCon_main.Panel2MinSize = 200
        Me.splitCon_main.Size = New System.Drawing.Size(655, 215)
        Me.splitCon_main.SplitterDistance = 350
        Me.splitCon_main.TabIndex = 11
        '
        'lbl_description_2
        '
        Me.lbl_description_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_description_2.AutoSize = True
        Me.lbl_description_2.Location = New System.Drawing.Point(474, 446)
        Me.lbl_description_2.Name = "lbl_description_2"
        Me.lbl_description_2.Size = New System.Drawing.Size(200, 26)
        Me.lbl_description_2.TabIndex = 12
        Me.lbl_description_2.Text = "Substructure: if he not found the attribute" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "then he appends at %others%"
        Me.lbl_description_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btn_reset
        '
        Me.btn_reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_reset.Location = New System.Drawing.Point(158, 509)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(125, 30)
        Me.btn_reset.TabIndex = 13
        Me.btn_reset.Text = "Reset Structures"
        Me.btn_reset.UseVisualStyleBackColor = True
        '
        'splitCon_main_2
        '
        Me.splitCon_main_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitCon_main_2.Location = New System.Drawing.Point(27, 106)
        Me.splitCon_main_2.Name = "splitCon_main_2"
        Me.splitCon_main_2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitCon_main_2.Panel1
        '
        Me.splitCon_main_2.Panel1.Controls.Add(Me.lv_files)
        '
        'splitCon_main_2.Panel2
        '
        Me.splitCon_main_2.Panel2.Controls.Add(Me.splitCon_main)
        Me.splitCon_main_2.Size = New System.Drawing.Size(655, 333)
        Me.splitCon_main_2.SplitterDistance = 114
        Me.splitCon_main_2.TabIndex = 14
        '
        'lv_files
        '
        Me.lv_files.CheckBoxes = True
        Me.lv_files.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_file, Me.col_path})
        Me.lv_files.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_files.FullRowSelect = True
        Me.lv_files.GridLines = True
        Me.lv_files.HideSelection = False
        Me.lv_files.Location = New System.Drawing.Point(0, 0)
        Me.lv_files.Name = "lv_files"
        Me.lv_files.Size = New System.Drawing.Size(655, 114)
        Me.lv_files.TabIndex = 0
        Me.lv_files.UseCompatibleStateImageBehavior = False
        Me.lv_files.View = System.Windows.Forms.View.Details
        '
        'col_file
        '
        Me.col_file.Text = "File Name"
        Me.col_file.Width = 182
        '
        'col_path
        '
        Me.col_path.Text = "Path"
        Me.col_path.Width = 382
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.rtb_eg_2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rtb_eg_1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(24, 73)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(661, 25)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(313, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "to:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtb_eg_1
        '
        Me.rtb_eg_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_eg_1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb_eg_1.Location = New System.Drawing.Point(3, 3)
        Me.rtb_eg_1.Name = "rtb_eg_1"
        Me.rtb_eg_1.ReadOnly = True
        Me.rtb_eg_1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtb_eg_1.Size = New System.Drawing.Size(304, 19)
        Me.rtb_eg_1.TabIndex = 1
        Me.rtb_eg_1.Text = "pic: 0 centerx: 39 centery: 40 dvx: 0 dvy: 10 dvz: 0"
        '
        'rtb_eg_2
        '
        Me.rtb_eg_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_eg_2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb_eg_2.Location = New System.Drawing.Point(353, 3)
        Me.rtb_eg_2.Name = "rtb_eg_2"
        Me.rtb_eg_2.ReadOnly = True
        Me.rtb_eg_2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtb_eg_2.Size = New System.Drawing.Size(305, 19)
        Me.rtb_eg_2.TabIndex = 2
        Me.rtb_eg_2.Text = "dvx: 0 dvy: 10 dvz: 0 centery: 40 centerx: 39 pic: 0"
        '
        'ui_frames_reformatting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 566)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.splitCon_main_2)
        Me.Controls.Add(Me.btn_reset)
        Me.Controls.Add(Me.lbl_description_2)
        Me.Controls.Add(Me.lbl_important_info)
        Me.Controls.Add(Me.lbl_description_1)
        Me.Controls.Add(Me.btn_doIt)
        Me.Controls.Add(Me.btn_abort)
        Me.Controls.Add(Me.lbl_description)
        Me.Controls.Add(Me.lbl_title)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(717, 573)
        Me.Name = "ui_frames_reformatting"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easier Data-Editor (STM93 Version) - Frames Reformatting"
        Me.gb_substructure.ResumeLayout(False)
        Me.pal_sub_menu.ResumeLayout(False)
        Me.pal_sub_menu.PerformLayout()
        Me.splitCon_main.Panel1.ResumeLayout(False)
        Me.splitCon_main.Panel2.ResumeLayout(False)
        CType(Me.splitCon_main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitCon_main.ResumeLayout(False)
        Me.splitCon_main_2.Panel1.ResumeLayout(False)
        Me.splitCon_main_2.Panel2.ResumeLayout(False)
        CType(Me.splitCon_main_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitCon_main_2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_title As Label
    Friend WithEvents gb_frame As GroupBox
    Friend WithEvents gb_substructure As GroupBox
    Friend WithEvents lbl_description As Label
    Friend WithEvents btn_abort As Button
    Friend WithEvents btn_doIt As Button
    Friend WithEvents pal_sub_menu As Panel
    Friend WithEvents comb_substructure As ComboBox
    Friend WithEvents lbl_sub_description As Label
    Friend WithEvents lbl_description_1 As Label
    Friend WithEvents lbl_important_info As Label
    Friend WithEvents splitCon_main As SplitContainer
    Friend WithEvents lbl_description_2 As Label
    Friend WithEvents btn_reset As Button
    Friend WithEvents splitCon_main_2 As SplitContainer
    Friend WithEvents lv_files As ListView
    Friend WithEvents col_file As ColumnHeader
    Friend WithEvents col_path As ColumnHeader
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents rtb_eg_2 As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rtb_eg_1 As RichTextBox
End Class
