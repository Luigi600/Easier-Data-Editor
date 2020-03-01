<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FramesReformatting
    Inherits Translation.TranslatableForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FramesReformatting))
        Me.Lbl_title = New System.Windows.Forms.Label()
        Me.Gb_frame = New System.Windows.Forms.GroupBox()
        Me.Scintilla_Frame = New Easier_Data_Editor.CustomScintilla()
        Me.Gb_substructure = New System.Windows.Forms.GroupBox()
        Me.Scintilla_Substructure = New Easier_Data_Editor.CustomScintilla()
        Me.Pal_sub_menu = New System.Windows.Forms.Panel()
        Me.Comb_substructure = New System.Windows.Forms.ComboBox()
        Me.Lbl_sub_description = New System.Windows.Forms.Label()
        Me.Btn_close = New System.Windows.Forms.Button()
        Me.Btn_doIt = New System.Windows.Forms.Button()
        Me.Lbl_important_info = New System.Windows.Forms.Label()
        Me.SplitCon_main = New System.Windows.Forms.SplitContainer()
        Me.Btn_reset = New System.Windows.Forms.Button()
        Me.SplitCon_main_2 = New System.Windows.Forms.SplitContainer()
        Me.Lv_files = New System.Windows.Forms.ListView()
        Me.Col_file = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cb_removeEmptyLines = New System.Windows.Forms.CheckBox()
        Me.SplitContainer_Instruction = New System.Windows.Forms.SplitContainer()
        Me.Pal_ScrollFunction = New System.Windows.Forms.Panel()
        Me.Rtb_Commands = New Easier_Data_Editor.ScrollableRTB()
        Me.Pal_space = New System.Windows.Forms.Panel()
        Me.Btn_math_test = New System.Windows.Forms.Button()
        Me.Pic_Demo = New System.Windows.Forms.PictureBox()
        Me.Rtb_information = New Easier_Data_Editor.ScrollableRTB()
        Me.Btn_hideShow_Panel = New System.Windows.Forms.Button()
        Me.Btn_doIt_selected = New System.Windows.Forms.Button()
        Me.Gb_frame.SuspendLayout()
        Me.Gb_substructure.SuspendLayout()
        Me.Pal_sub_menu.SuspendLayout()
        CType(Me.SplitCon_main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitCon_main.Panel1.SuspendLayout()
        Me.SplitCon_main.Panel2.SuspendLayout()
        Me.SplitCon_main.SuspendLayout()
        CType(Me.SplitCon_main_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitCon_main_2.Panel1.SuspendLayout()
        Me.SplitCon_main_2.Panel2.SuspendLayout()
        Me.SplitCon_main_2.SuspendLayout()
        CType(Me.SplitContainer_Instruction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Instruction.Panel1.SuspendLayout()
        Me.SplitContainer_Instruction.Panel2.SuspendLayout()
        Me.SplitContainer_Instruction.SuspendLayout()
        Me.Pal_ScrollFunction.SuspendLayout()
        CType(Me.Pic_Demo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_title
        '
        Me.Lbl_title.AutoSize = True
        Me.Lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_title.Location = New System.Drawing.Point(27, 24)
        Me.Lbl_title.Name = "Lbl_title"
        Me.Lbl_title.Size = New System.Drawing.Size(231, 25)
        Me.Lbl_title.TabIndex = 1
        Me.Lbl_title.Text = "Frames Reformatting"
        '
        'Gb_frame
        '
        Me.Gb_frame.Controls.Add(Me.Scintilla_Frame)
        Me.Gb_frame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gb_frame.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gb_frame.Location = New System.Drawing.Point(0, 0)
        Me.Gb_frame.Name = "Gb_frame"
        Me.Gb_frame.Padding = New System.Windows.Forms.Padding(10)
        Me.Gb_frame.Size = New System.Drawing.Size(489, 263)
        Me.Gb_frame.TabIndex = 4
        Me.Gb_frame.TabStop = False
        Me.Gb_frame.Text = "Frame"
        '
        'Scintilla_Frame
        '
        Me.Scintilla_Frame.AdditionalSelectionTyping = True
        Me.Scintilla_Frame.BlockUndoRedoActions = False
        Me.Scintilla_Frame.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Scintilla_Frame.CaretLineVisible = True
        Me.Scintilla_Frame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla_Frame.Location = New System.Drawing.Point(10, 29)
        Me.Scintilla_Frame.Margin = New System.Windows.Forms.Padding(2)
        Me.Scintilla_Frame.MouseSelectionRectangularSwitch = True
        Me.Scintilla_Frame.MultipleSelection = True
        Me.Scintilla_Frame.Name = "Scintilla_Frame"
        Me.Scintilla_Frame.ScrollWidth = 10
        Me.Scintilla_Frame.Size = New System.Drawing.Size(469, 224)
        Me.Scintilla_Frame.SuppressFoldingCheck = False
        Me.Scintilla_Frame.TabIndex = 0
        Me.Scintilla_Frame.VirtualSpaceOptions = ScintillaNET.VirtualSpace.RectangularSelection
        Me.Scintilla_Frame.WhitespaceSize = 3
        '
        'Gb_substructure
        '
        Me.Gb_substructure.Controls.Add(Me.Scintilla_Substructure)
        Me.Gb_substructure.Controls.Add(Me.Pal_sub_menu)
        Me.Gb_substructure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gb_substructure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gb_substructure.Location = New System.Drawing.Point(6, 0)
        Me.Gb_substructure.Name = "Gb_substructure"
        Me.Gb_substructure.Padding = New System.Windows.Forms.Padding(10)
        Me.Gb_substructure.Size = New System.Drawing.Size(430, 263)
        Me.Gb_substructure.TabIndex = 5
        Me.Gb_substructure.TabStop = False
        Me.Gb_substructure.Text = "Substructure"
        '
        'Scintilla_Substructure
        '
        Me.Scintilla_Substructure.AdditionalSelectionTyping = True
        Me.Scintilla_Substructure.BlockUndoRedoActions = False
        Me.Scintilla_Substructure.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Scintilla_Substructure.CaretLineVisible = True
        Me.Scintilla_Substructure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla_Substructure.Location = New System.Drawing.Point(10, 88)
        Me.Scintilla_Substructure.Margin = New System.Windows.Forms.Padding(2)
        Me.Scintilla_Substructure.MouseSelectionRectangularSwitch = True
        Me.Scintilla_Substructure.MultipleSelection = True
        Me.Scintilla_Substructure.Name = "Scintilla_Substructure"
        Me.Scintilla_Substructure.ScrollWidth = 10
        Me.Scintilla_Substructure.Size = New System.Drawing.Size(410, 165)
        Me.Scintilla_Substructure.SuppressFoldingCheck = False
        Me.Scintilla_Substructure.TabIndex = 5
        Me.Scintilla_Substructure.VirtualSpaceOptions = ScintillaNET.VirtualSpace.RectangularSelection
        Me.Scintilla_Substructure.WhitespaceSize = 3
        '
        'Pal_sub_menu
        '
        Me.Pal_sub_menu.Controls.Add(Me.Comb_substructure)
        Me.Pal_sub_menu.Controls.Add(Me.Lbl_sub_description)
        Me.Pal_sub_menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pal_sub_menu.Location = New System.Drawing.Point(10, 25)
        Me.Pal_sub_menu.Name = "Pal_sub_menu"
        Me.Pal_sub_menu.Size = New System.Drawing.Size(410, 63)
        Me.Pal_sub_menu.TabIndex = 4
        '
        'Comb_substructure
        '
        Me.Comb_substructure.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comb_substructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comb_substructure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comb_substructure.FormattingEnabled = True
        Me.Comb_substructure.Items.AddRange(New Object() {"Body", "Itr", "Blood Point", "Weapon Point", "Catch Point", "Object Point"})
        Me.Comb_substructure.Location = New System.Drawing.Point(0, 27)
        Me.Comb_substructure.Name = "Comb_substructure"
        Me.Comb_substructure.Size = New System.Drawing.Size(410, 21)
        Me.Comb_substructure.TabIndex = 10
        '
        'Lbl_sub_description
        '
        Me.Lbl_sub_description.AutoSize = True
        Me.Lbl_sub_description.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_sub_description.Location = New System.Drawing.Point(3, 4)
        Me.Lbl_sub_description.Name = "Lbl_sub_description"
        Me.Lbl_sub_description.Size = New System.Drawing.Size(178, 13)
        Me.Lbl_sub_description.TabIndex = 9
        Me.Lbl_sub_description.Text = "Substructure is body, itr, wpoint, etc."
        '
        'Btn_close
        '
        Me.Btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_close.Location = New System.Drawing.Point(24, 536)
        Me.Btn_close.Name = "Btn_close"
        Me.Btn_close.Size = New System.Drawing.Size(125, 30)
        Me.Btn_close.TabIndex = 7
        Me.Btn_close.Text = "Close"
        Me.Btn_close.UseVisualStyleBackColor = True
        '
        'Btn_doIt
        '
        Me.Btn_doIt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_doIt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_doIt.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_doIt.Location = New System.Drawing.Point(837, 536)
        Me.Btn_doIt.Name = "Btn_doIt"
        Me.Btn_doIt.Size = New System.Drawing.Size(125, 30)
        Me.Btn_doIt.TabIndex = 8
        Me.Btn_doIt.Text = "Apply"
        Me.Btn_doIt.UseVisualStyleBackColor = True
        '
        'Lbl_important_info
        '
        Me.Lbl_important_info.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_important_info.AutoSize = True
        Me.Lbl_important_info.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_important_info.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl_important_info.Location = New System.Drawing.Point(1411, 882)
        Me.Lbl_important_info.Name = "Lbl_important_info"
        Me.Lbl_important_info.Size = New System.Drawing.Size(170, 13)
        Me.Lbl_important_info.TabIndex = 10
        Me.Lbl_important_info.Text = "All %..% are case sensitive!!!"
        '
        'SplitCon_main
        '
        Me.SplitCon_main.BackColor = System.Drawing.Color.LightGray
        Me.SplitCon_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitCon_main.Location = New System.Drawing.Point(0, 0)
        Me.SplitCon_main.Name = "SplitCon_main"
        '
        'SplitCon_main.Panel1
        '
        Me.SplitCon_main.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitCon_main.Panel1.Controls.Add(Me.Gb_frame)
        Me.SplitCon_main.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.SplitCon_main.Panel1MinSize = 200
        '
        'SplitCon_main.Panel2
        '
        Me.SplitCon_main.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitCon_main.Panel2.Controls.Add(Me.Gb_substructure)
        Me.SplitCon_main.Panel2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.SplitCon_main.Panel2MinSize = 200
        Me.SplitCon_main.Size = New System.Drawing.Size(935, 263)
        Me.SplitCon_main.SplitterDistance = 495
        Me.SplitCon_main.TabIndex = 11
        '
        'Btn_reset
        '
        Me.Btn_reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_reset.Location = New System.Drawing.Point(158, 536)
        Me.Btn_reset.Name = "Btn_reset"
        Me.Btn_reset.Size = New System.Drawing.Size(125, 30)
        Me.Btn_reset.TabIndex = 13
        Me.Btn_reset.Text = "Reset Structures"
        Me.Btn_reset.UseVisualStyleBackColor = True
        '
        'SplitCon_main_2
        '
        Me.SplitCon_main_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitCon_main_2.BackColor = System.Drawing.Color.LightGray
        Me.SplitCon_main_2.Location = New System.Drawing.Point(27, 65)
        Me.SplitCon_main_2.Name = "SplitCon_main_2"
        Me.SplitCon_main_2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitCon_main_2.Panel1
        '
        Me.SplitCon_main_2.Panel1.Controls.Add(Me.Lv_files)
        '
        'SplitCon_main_2.Panel2
        '
        Me.SplitCon_main_2.Panel2.Controls.Add(Me.SplitCon_main)
        Me.SplitCon_main_2.Size = New System.Drawing.Size(935, 404)
        Me.SplitCon_main_2.SplitterDistance = 137
        Me.SplitCon_main_2.TabIndex = 14
        '
        'Lv_files
        '
        Me.Lv_files.CheckBoxes = True
        Me.Lv_files.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_file, Me.Col_path})
        Me.Lv_files.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lv_files.FullRowSelect = True
        Me.Lv_files.GridLines = True
        Me.Lv_files.HideSelection = False
        Me.Lv_files.Location = New System.Drawing.Point(0, 0)
        Me.Lv_files.Name = "Lv_files"
        Me.Lv_files.Size = New System.Drawing.Size(935, 137)
        Me.Lv_files.TabIndex = 0
        Me.Lv_files.UseCompatibleStateImageBehavior = False
        Me.Lv_files.View = System.Windows.Forms.View.Details
        '
        'Col_file
        '
        Me.Col_file.Name = "Col_file"
        Me.Col_file.Text = "File Name"
        Me.Col_file.Width = 182
        '
        'Col_path
        '
        Me.Col_path.Name = "Col_path"
        Me.Col_path.Text = "Path"
        Me.Col_path.Width = 382
        '
        'Cb_removeEmptyLines
        '
        Me.Cb_removeEmptyLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cb_removeEmptyLines.AutoSize = True
        Me.Cb_removeEmptyLines.Location = New System.Drawing.Point(27, 447)
        Me.Cb_removeEmptyLines.Name = "Cb_removeEmptyLines"
        Me.Cb_removeEmptyLines.Size = New System.Drawing.Size(116, 17)
        Me.Cb_removeEmptyLines.TabIndex = 16
        Me.Cb_removeEmptyLines.Text = "remove empty lines"
        Me.Cb_removeEmptyLines.UseVisualStyleBackColor = True
        '
        'SplitContainer_Instruction
        '
        Me.SplitContainer_Instruction.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer_Instruction.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer_Instruction.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Instruction.Name = "SplitContainer_Instruction"
        '
        'SplitContainer_Instruction.Panel1
        '
        Me.SplitContainer_Instruction.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer_Instruction.Panel1.Controls.Add(Me.Lbl_title)
        Me.SplitContainer_Instruction.Panel1.Controls.Add(Me.SplitCon_main_2)
        Me.SplitContainer_Instruction.Panel1.Padding = New System.Windows.Forms.Padding(24)
        '
        'SplitContainer_Instruction.Panel2
        '
        Me.SplitContainer_Instruction.Panel2.AutoScroll = True
        Me.SplitContainer_Instruction.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer_Instruction.Panel2.Controls.Add(Me.Pal_ScrollFunction)
        Me.SplitContainer_Instruction.Panel2.Controls.Add(Me.Lbl_important_info)
        Me.SplitContainer_Instruction.Panel2.Padding = New System.Windows.Forms.Padding(10, 12, 12, 0)
        Me.SplitContainer_Instruction.Panel2Collapsed = True
        Me.SplitContainer_Instruction.Panel2MinSize = 100
        Me.SplitContainer_Instruction.Size = New System.Drawing.Size(989, 496)
        Me.SplitContainer_Instruction.SplitterDistance = 25
        Me.SplitContainer_Instruction.TabIndex = 17
        '
        'Pal_ScrollFunction
        '
        Me.Pal_ScrollFunction.AutoScroll = True
        Me.Pal_ScrollFunction.Controls.Add(Me.Rtb_Commands)
        Me.Pal_ScrollFunction.Controls.Add(Me.Pal_space)
        Me.Pal_ScrollFunction.Controls.Add(Me.Btn_math_test)
        Me.Pal_ScrollFunction.Controls.Add(Me.Pic_Demo)
        Me.Pal_ScrollFunction.Controls.Add(Me.Rtb_information)
        Me.Pal_ScrollFunction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pal_ScrollFunction.Location = New System.Drawing.Point(10, 12)
        Me.Pal_ScrollFunction.Name = "Pal_ScrollFunction"
        Me.Pal_ScrollFunction.Padding = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.Pal_ScrollFunction.Size = New System.Drawing.Size(74, 88)
        Me.Pal_ScrollFunction.TabIndex = 16
        '
        'Rtb_Commands
        '
        Me.Rtb_Commands.BackColor = System.Drawing.SystemColors.Control
        Me.Rtb_Commands.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rtb_Commands.Dock = System.Windows.Forms.DockStyle.Top
        Me.Rtb_Commands.Location = New System.Drawing.Point(0, 396)
        Me.Rtb_Commands.Name = "Rtb_Commands"
        Me.Rtb_Commands.ReadOnly = True
        Me.Rtb_Commands.Size = New System.Drawing.Size(51, 646)
        Me.Rtb_Commands.TabIndex = 15
        Me.Rtb_Commands.Text = resources.GetString("Rtb_Commands.Text")
        '
        'Pal_space
        '
        Me.Pal_space.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pal_space.Location = New System.Drawing.Point(0, 381)
        Me.Pal_space.Name = "Pal_space"
        Me.Pal_space.Size = New System.Drawing.Size(51, 15)
        Me.Pal_space.TabIndex = 17
        Me.Pal_space.Visible = False
        '
        'Btn_math_test
        '
        Me.Btn_math_test.Dock = System.Windows.Forms.DockStyle.Top
        Me.Btn_math_test.Location = New System.Drawing.Point(0, 342)
        Me.Btn_math_test.Name = "Btn_math_test"
        Me.Btn_math_test.Size = New System.Drawing.Size(51, 39)
        Me.Btn_math_test.TabIndex = 16
        Me.Btn_math_test.Text = "Test Mathematical Operations Validity"
        Me.Btn_math_test.UseVisualStyleBackColor = True
        Me.Btn_math_test.Visible = False
        '
        'Pic_Demo
        '
        Me.Pic_Demo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pic_Demo.Image = Global.Easier_Data_Editor.My.Resources.Resources.instruction_function
        Me.Pic_Demo.Location = New System.Drawing.Point(0, 45)
        Me.Pic_Demo.Name = "Pic_Demo"
        Me.Pic_Demo.Size = New System.Drawing.Size(51, 297)
        Me.Pic_Demo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pic_Demo.TabIndex = 14
        Me.Pic_Demo.TabStop = False
        '
        'Rtb_information
        '
        Me.Rtb_information.BackColor = System.Drawing.SystemColors.Control
        Me.Rtb_information.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rtb_information.Dock = System.Windows.Forms.DockStyle.Top
        Me.Rtb_information.Location = New System.Drawing.Point(0, 0)
        Me.Rtb_information.Name = "Rtb_information"
        Me.Rtb_information.ReadOnly = True
        Me.Rtb_information.Size = New System.Drawing.Size(51, 45)
        Me.Rtb_information.TabIndex = 13
        Me.Rtb_information.Text = "This tool changes the structure of all your data files with one click."
        '
        'Btn_hideShow_Panel
        '
        Me.Btn_hideShow_Panel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_hideShow_Panel.Location = New System.Drawing.Point(24, 496)
        Me.Btn_hideShow_Panel.Name = "Btn_hideShow_Panel"
        Me.Btn_hideShow_Panel.Size = New System.Drawing.Size(259, 30)
        Me.Btn_hideShow_Panel.TabIndex = 18
        Me.Btn_hideShow_Panel.Text = "Open Instruction/Commands"
        Me.Btn_hideShow_Panel.UseVisualStyleBackColor = True
        '
        'Btn_doIt_selected
        '
        Me.Btn_doIt_selected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_doIt_selected.Location = New System.Drawing.Point(659, 536)
        Me.Btn_doIt_selected.Name = "Btn_doIt_selected"
        Me.Btn_doIt_selected.Size = New System.Drawing.Size(147, 30)
        Me.Btn_doIt_selected.TabIndex = 19
        Me.Btn_doIt_selected.Text = "Change Only Selected Text"
        Me.Btn_doIt_selected.UseVisualStyleBackColor = True
        '
        'FramesReformatting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 593)
        Me.Controls.Add(Me.Btn_doIt_selected)
        Me.Controls.Add(Me.Btn_hideShow_Panel)
        Me.Controls.Add(Me.SplitContainer_Instruction)
        Me.Controls.Add(Me.Cb_removeEmptyLines)
        Me.Controls.Add(Me.Btn_reset)
        Me.Controls.Add(Me.Btn_doIt)
        Me.Controls.Add(Me.Btn_close)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(715, 567)
        Me.Name = "FramesReformatting"
        Me.Padding = New System.Windows.Forms.Padding(24)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frames Reformatting"
        Me.Gb_frame.ResumeLayout(False)
        Me.Gb_substructure.ResumeLayout(False)
        Me.Pal_sub_menu.ResumeLayout(False)
        Me.Pal_sub_menu.PerformLayout()
        Me.SplitCon_main.Panel1.ResumeLayout(False)
        Me.SplitCon_main.Panel2.ResumeLayout(False)
        CType(Me.SplitCon_main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitCon_main.ResumeLayout(False)
        Me.SplitCon_main_2.Panel1.ResumeLayout(False)
        Me.SplitCon_main_2.Panel2.ResumeLayout(False)
        CType(Me.SplitCon_main_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitCon_main_2.ResumeLayout(False)
        Me.SplitContainer_Instruction.Panel1.ResumeLayout(False)
        Me.SplitContainer_Instruction.Panel1.PerformLayout()
        Me.SplitContainer_Instruction.Panel2.ResumeLayout(False)
        Me.SplitContainer_Instruction.Panel2.PerformLayout()
        CType(Me.SplitContainer_Instruction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Instruction.ResumeLayout(False)
        Me.Pal_ScrollFunction.ResumeLayout(False)
        CType(Me.Pic_Demo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_title As Label
    Friend WithEvents Gb_frame As GroupBox
    Friend WithEvents Gb_substructure As GroupBox
    Friend WithEvents Btn_close As Button
    Friend WithEvents Btn_doIt As Button
    Friend WithEvents Pal_sub_menu As Panel
    Friend WithEvents Comb_substructure As ComboBox
    Friend WithEvents Lbl_sub_description As Label
    Friend WithEvents Lbl_important_info As Label
    Friend WithEvents SplitCon_main As SplitContainer
    Friend WithEvents Btn_reset As Button
    Friend WithEvents SplitCon_main_2 As SplitContainer
    Friend WithEvents Lv_files As ListView
    Friend WithEvents Col_file As ColumnHeader
    Friend WithEvents Col_path As ColumnHeader
    Friend WithEvents Scintilla_Frame As CustomScintilla
    Friend WithEvents Scintilla_Substructure As CustomScintilla
    Friend WithEvents Cb_removeEmptyLines As CheckBox
    Friend WithEvents SplitContainer_Instruction As SplitContainer
    Friend WithEvents Btn_hideShow_Panel As Button
    Friend WithEvents Rtb_information As ScrollableRTB
    Friend WithEvents Pic_Demo As PictureBox
    Friend WithEvents Rtb_Commands As ScrollableRTB
    Friend WithEvents Pal_ScrollFunction As Panel
    Friend WithEvents Btn_doIt_selected As Button
    Friend WithEvents Pal_space As Panel
    Friend WithEvents Btn_math_test As Button
End Class