<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_FrameViewer
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
        Me.Cb_ms = New System.Windows.Forms.CheckBox()
        Me.TLP_main = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_defaultBG = New System.Windows.Forms.Label()
        Me.Lbl_ms = New System.Windows.Forms.Label()
        Me.Lbl_globalView = New System.Windows.Forms.Label()
        Me.Lbl_fulLRestore = New System.Windows.Forms.Label()
        Me.Cb_fullRestore = New System.Windows.Forms.CheckBox()
        Me.Cb_globalView = New System.Windows.Forms.CheckBox()
        Me.TLP_defaultBG = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_defaultBG = New System.Windows.Forms.Button()
        Me.Pic_defaultBG = New System.Windows.Forms.PictureBox()
        Me.Btn_image = New System.Windows.Forms.Button()
        Me.TLP_weaponData = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_weaponData = New System.Windows.Forms.TextBox()
        Me.Btn_changePathWeaponData = New System.Windows.Forms.Button()
        Me.TLP_weaponSprite = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_weaponSprite = New System.Windows.Forms.TextBox()
        Me.Btn_changePathWeaponSprite = New System.Windows.Forms.Button()
        Me.TLP_hweaponData = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_hweaponData = New System.Windows.Forms.TextBox()
        Me.Btn_changePathHWeaponData = New System.Windows.Forms.Button()
        Me.TLP_hweaponSprite = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_hweaponSprite = New System.Windows.Forms.TextBox()
        Me.Btn_changePathHWeaponSprite = New System.Windows.Forms.Button()
        Me.Lbl_hweaponSprite = New System.Windows.Forms.Label()
        Me.Lbl_hweaponData = New System.Windows.Forms.Label()
        Me.Lbl_weaponSprite = New System.Windows.Forms.Label()
        Me.Lbl_weaponData = New System.Windows.Forms.Label()
        Me.Lbl_hwSpriteFound = New System.Windows.Forms.Label()
        Me.Lbl_hwdataFound = New System.Windows.Forms.Label()
        Me.Lbl_wspriteFound = New System.Windows.Forms.Label()
        Me.Lbl_direct = New System.Windows.Forms.Label()
        Me.Cb_direct = New System.Windows.Forms.CheckBox()
        Me.Lbl_wdataFound = New System.Windows.Forms.Label()
        Me.Lbl_directInformation = New System.Windows.Forms.Label()
        Me.OFD_sprite = New System.Windows.Forms.OpenFileDialog()
        Me.OFD_data = New System.Windows.Forms.OpenFileDialog()
        Me.CD_defaultBG = New System.Windows.Forms.ColorDialog()
        Me.TLP_main.SuspendLayout()
        Me.TLP_defaultBG.SuspendLayout()
        CType(Me.Pic_defaultBG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TLP_weaponData.SuspendLayout()
        Me.TLP_weaponSprite.SuspendLayout()
        Me.TLP_hweaponData.SuspendLayout()
        Me.TLP_hweaponSprite.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cb_ms
        '
        Me.Cb_ms.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_ms.AutoSize = True
        Me.Cb_ms.Location = New System.Drawing.Point(205, 3)
        Me.Cb_ms.Name = "Cb_ms"
        Me.Cb_ms.Size = New System.Drawing.Size(196, 14)
        Me.Cb_ms.TabIndex = 0
        Me.Cb_ms.UseVisualStyleBackColor = True
        '
        'TLP_main
        '
        Me.TLP_main.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TLP_main.AutoSize = True
        Me.TLP_main.ColumnCount = 3
        Me.TLP_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TLP_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TLP_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TLP_main.Controls.Add(Me.Lbl_defaultBG, 0, 1)
        Me.TLP_main.Controls.Add(Me.Lbl_ms, 0, 0)
        Me.TLP_main.Controls.Add(Me.Cb_ms, 1, 0)
        Me.TLP_main.Controls.Add(Me.Lbl_globalView, 0, 2)
        Me.TLP_main.Controls.Add(Me.Lbl_fulLRestore, 0, 3)
        Me.TLP_main.Controls.Add(Me.Cb_fullRestore, 1, 3)
        Me.TLP_main.Controls.Add(Me.Cb_globalView, 1, 2)
        Me.TLP_main.Controls.Add(Me.TLP_defaultBG, 1, 1)
        Me.TLP_main.Controls.Add(Me.TLP_weaponData, 1, 5)
        Me.TLP_main.Controls.Add(Me.TLP_weaponSprite, 1, 6)
        Me.TLP_main.Controls.Add(Me.TLP_hweaponData, 1, 7)
        Me.TLP_main.Controls.Add(Me.TLP_hweaponSprite, 1, 8)
        Me.TLP_main.Controls.Add(Me.Lbl_hweaponSprite, 0, 8)
        Me.TLP_main.Controls.Add(Me.Lbl_hweaponData, 0, 7)
        Me.TLP_main.Controls.Add(Me.Lbl_weaponSprite, 0, 6)
        Me.TLP_main.Controls.Add(Me.Lbl_weaponData, 0, 5)
        Me.TLP_main.Controls.Add(Me.Lbl_hwSpriteFound, 2, 8)
        Me.TLP_main.Controls.Add(Me.Lbl_hwdataFound, 2, 7)
        Me.TLP_main.Controls.Add(Me.Lbl_wspriteFound, 2, 6)
        Me.TLP_main.Controls.Add(Me.Lbl_direct, 0, 4)
        Me.TLP_main.Controls.Add(Me.Cb_direct, 1, 4)
        Me.TLP_main.Controls.Add(Me.Lbl_wdataFound, 2, 5)
        Me.TLP_main.Controls.Add(Me.Lbl_directInformation, 2, 4)
        Me.TLP_main.Location = New System.Drawing.Point(19, 19)
        Me.TLP_main.Name = "TLP_main"
        Me.TLP_main.RowCount = 9
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_main.Size = New System.Drawing.Size(607, 224)
        Me.TLP_main.TabIndex = 1
        '
        'Lbl_defaultBG
        '
        Me.Lbl_defaultBG.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_defaultBG.AutoSize = True
        Me.Lbl_defaultBG.Location = New System.Drawing.Point(3, 25)
        Me.Lbl_defaultBG.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_defaultBG.Name = "Lbl_defaultBG"
        Me.Lbl_defaultBG.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_defaultBG.TabIndex = 1
        Me.Lbl_defaultBG.Text = "Default Background Color:"
        Me.Lbl_defaultBG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_ms
        '
        Me.Lbl_ms.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_ms.AutoSize = True
        Me.Lbl_ms.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_ms.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_ms.Name = "Lbl_ms"
        Me.Lbl_ms.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_ms.TabIndex = 0
        Me.Lbl_ms.Text = "Menu Strip:"
        Me.Lbl_ms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_globalView
        '
        Me.Lbl_globalView.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_globalView.AutoSize = True
        Me.Lbl_globalView.Location = New System.Drawing.Point(3, 47)
        Me.Lbl_globalView.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_globalView.Name = "Lbl_globalView"
        Me.Lbl_globalView.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_globalView.TabIndex = 3
        Me.Lbl_globalView.Text = "Global View:"
        Me.Lbl_globalView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_fulLRestore
        '
        Me.Lbl_fulLRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_fulLRestore.AutoSize = True
        Me.Lbl_fulLRestore.Location = New System.Drawing.Point(3, 67)
        Me.Lbl_fulLRestore.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_fulLRestore.Name = "Lbl_fulLRestore"
        Me.Lbl_fulLRestore.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_fulLRestore.TabIndex = 4
        Me.Lbl_fulLRestore.Text = "Full Restore:"
        Me.Lbl_fulLRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cb_fullRestore
        '
        Me.Cb_fullRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_fullRestore.AutoSize = True
        Me.Cb_fullRestore.Location = New System.Drawing.Point(205, 67)
        Me.Cb_fullRestore.Name = "Cb_fullRestore"
        Me.Cb_fullRestore.Size = New System.Drawing.Size(196, 14)
        Me.Cb_fullRestore.TabIndex = 7
        Me.Cb_fullRestore.UseVisualStyleBackColor = True
        '
        'Cb_globalView
        '
        Me.Cb_globalView.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_globalView.AutoSize = True
        Me.Cb_globalView.Location = New System.Drawing.Point(205, 47)
        Me.Cb_globalView.Name = "Cb_globalView"
        Me.Cb_globalView.Size = New System.Drawing.Size(196, 14)
        Me.Cb_globalView.TabIndex = 6
        Me.Cb_globalView.UseVisualStyleBackColor = True
        '
        'TLP_defaultBG
        '
        Me.TLP_defaultBG.AutoSize = True
        Me.TLP_defaultBG.ColumnCount = 3
        Me.TLP_defaultBG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP_defaultBG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_defaultBG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_defaultBG.Controls.Add(Me.Btn_defaultBG, 1, 0)
        Me.TLP_defaultBG.Controls.Add(Me.Pic_defaultBG, 0, 0)
        Me.TLP_defaultBG.Controls.Add(Me.Btn_image, 2, 0)
        Me.TLP_defaultBG.Location = New System.Drawing.Point(203, 21)
        Me.TLP_defaultBG.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.TLP_defaultBG.Name = "TLP_defaultBG"
        Me.TLP_defaultBG.RowCount = 1
        Me.TLP_defaultBG.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_defaultBG.Size = New System.Drawing.Size(201, 23)
        Me.TLP_defaultBG.TabIndex = 11
        '
        'Btn_defaultBG
        '
        Me.Btn_defaultBG.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_defaultBG.AutoSize = True
        Me.Btn_defaultBG.Location = New System.Drawing.Point(95, 0)
        Me.Btn_defaultBG.Margin = New System.Windows.Forms.Padding(3, 0, 2, 0)
        Me.Btn_defaultBG.Name = "Btn_defaultBG"
        Me.Btn_defaultBG.Size = New System.Drawing.Size(31, 23)
        Me.Btn_defaultBG.TabIndex = 10
        Me.Btn_defaultBG.Text = "..."
        Me.Btn_defaultBG.UseVisualStyleBackColor = True
        '
        'Pic_defaultBG
        '
        Me.Pic_defaultBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_defaultBG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pic_defaultBG.Location = New System.Drawing.Point(2, 0)
        Me.Pic_defaultBG.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.Pic_defaultBG.Name = "Pic_defaultBG"
        Me.Pic_defaultBG.Size = New System.Drawing.Size(90, 23)
        Me.Pic_defaultBG.TabIndex = 11
        Me.Pic_defaultBG.TabStop = False
        '
        'Btn_image
        '
        Me.Btn_image.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_image.AutoSize = True
        Me.Btn_image.Location = New System.Drawing.Point(131, 0)
        Me.Btn_image.Margin = New System.Windows.Forms.Padding(3, 0, 2, 0)
        Me.Btn_image.Name = "Btn_image"
        Me.Btn_image.Size = New System.Drawing.Size(68, 23)
        Me.Btn_image.TabIndex = 12
        Me.Btn_image.Text = "No Color"
        Me.Btn_image.UseVisualStyleBackColor = True
        '
        'TLP_weaponData
        '
        Me.TLP_weaponData.AutoSize = True
        Me.TLP_weaponData.ColumnCount = 2
        Me.TLP_weaponData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP_weaponData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_weaponData.Controls.Add(Me.Txt_weaponData, 0, 0)
        Me.TLP_weaponData.Controls.Add(Me.Btn_changePathWeaponData, 1, 0)
        Me.TLP_weaponData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP_weaponData.Location = New System.Drawing.Point(203, 105)
        Me.TLP_weaponData.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.TLP_weaponData.Name = "TLP_weaponData"
        Me.TLP_weaponData.RowCount = 1
        Me.TLP_weaponData.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_weaponData.Size = New System.Drawing.Size(201, 29)
        Me.TLP_weaponData.TabIndex = 13
        '
        'Txt_weaponData
        '
        Me.Txt_weaponData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_weaponData.Location = New System.Drawing.Point(3, 4)
        Me.Txt_weaponData.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Txt_weaponData.Name = "Txt_weaponData"
        Me.Txt_weaponData.Size = New System.Drawing.Size(162, 20)
        Me.Txt_weaponData.TabIndex = 9
        '
        'Btn_changePathWeaponData
        '
        Me.Btn_changePathWeaponData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_changePathWeaponData.AutoSize = True
        Me.Btn_changePathWeaponData.Location = New System.Drawing.Point(168, 3)
        Me.Btn_changePathWeaponData.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.Btn_changePathWeaponData.Name = "Btn_changePathWeaponData"
        Me.Btn_changePathWeaponData.Size = New System.Drawing.Size(31, 23)
        Me.Btn_changePathWeaponData.TabIndex = 10
        Me.Btn_changePathWeaponData.Text = "..."
        Me.Btn_changePathWeaponData.UseVisualStyleBackColor = True
        '
        'TLP_weaponSprite
        '
        Me.TLP_weaponSprite.AutoSize = True
        Me.TLP_weaponSprite.ColumnCount = 2
        Me.TLP_weaponSprite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP_weaponSprite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_weaponSprite.Controls.Add(Me.Txt_weaponSprite, 0, 0)
        Me.TLP_weaponSprite.Controls.Add(Me.Btn_changePathWeaponSprite, 1, 0)
        Me.TLP_weaponSprite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP_weaponSprite.Location = New System.Drawing.Point(203, 135)
        Me.TLP_weaponSprite.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.TLP_weaponSprite.Name = "TLP_weaponSprite"
        Me.TLP_weaponSprite.RowCount = 1
        Me.TLP_weaponSprite.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_weaponSprite.Size = New System.Drawing.Size(201, 29)
        Me.TLP_weaponSprite.TabIndex = 12
        '
        'Txt_weaponSprite
        '
        Me.Txt_weaponSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_weaponSprite.Location = New System.Drawing.Point(3, 4)
        Me.Txt_weaponSprite.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Txt_weaponSprite.Name = "Txt_weaponSprite"
        Me.Txt_weaponSprite.Size = New System.Drawing.Size(162, 20)
        Me.Txt_weaponSprite.TabIndex = 9
        '
        'Btn_changePathWeaponSprite
        '
        Me.Btn_changePathWeaponSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_changePathWeaponSprite.AutoSize = True
        Me.Btn_changePathWeaponSprite.Location = New System.Drawing.Point(168, 3)
        Me.Btn_changePathWeaponSprite.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.Btn_changePathWeaponSprite.Name = "Btn_changePathWeaponSprite"
        Me.Btn_changePathWeaponSprite.Size = New System.Drawing.Size(31, 23)
        Me.Btn_changePathWeaponSprite.TabIndex = 10
        Me.Btn_changePathWeaponSprite.Text = "..."
        Me.Btn_changePathWeaponSprite.UseVisualStyleBackColor = True
        '
        'TLP_hweaponData
        '
        Me.TLP_hweaponData.AutoSize = True
        Me.TLP_hweaponData.ColumnCount = 2
        Me.TLP_hweaponData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP_hweaponData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_hweaponData.Controls.Add(Me.Txt_hweaponData, 0, 0)
        Me.TLP_hweaponData.Controls.Add(Me.Btn_changePathHWeaponData, 1, 0)
        Me.TLP_hweaponData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP_hweaponData.Location = New System.Drawing.Point(203, 165)
        Me.TLP_hweaponData.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.TLP_hweaponData.Name = "TLP_hweaponData"
        Me.TLP_hweaponData.RowCount = 1
        Me.TLP_hweaponData.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_hweaponData.Size = New System.Drawing.Size(201, 29)
        Me.TLP_hweaponData.TabIndex = 17
        '
        'Txt_hweaponData
        '
        Me.Txt_hweaponData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_hweaponData.Location = New System.Drawing.Point(3, 4)
        Me.Txt_hweaponData.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Txt_hweaponData.Name = "Txt_hweaponData"
        Me.Txt_hweaponData.Size = New System.Drawing.Size(162, 20)
        Me.Txt_hweaponData.TabIndex = 9
        '
        'Btn_changePathHWeaponData
        '
        Me.Btn_changePathHWeaponData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_changePathHWeaponData.AutoSize = True
        Me.Btn_changePathHWeaponData.Location = New System.Drawing.Point(168, 3)
        Me.Btn_changePathHWeaponData.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.Btn_changePathHWeaponData.Name = "Btn_changePathHWeaponData"
        Me.Btn_changePathHWeaponData.Size = New System.Drawing.Size(31, 23)
        Me.Btn_changePathHWeaponData.TabIndex = 10
        Me.Btn_changePathHWeaponData.Text = "..."
        Me.Btn_changePathHWeaponData.UseVisualStyleBackColor = True
        '
        'TLP_hweaponSprite
        '
        Me.TLP_hweaponSprite.AutoSize = True
        Me.TLP_hweaponSprite.ColumnCount = 2
        Me.TLP_hweaponSprite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP_hweaponSprite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLP_hweaponSprite.Controls.Add(Me.Txt_hweaponSprite, 0, 0)
        Me.TLP_hweaponSprite.Controls.Add(Me.Btn_changePathHWeaponSprite, 1, 0)
        Me.TLP_hweaponSprite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP_hweaponSprite.Location = New System.Drawing.Point(203, 195)
        Me.TLP_hweaponSprite.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.TLP_hweaponSprite.Name = "TLP_hweaponSprite"
        Me.TLP_hweaponSprite.RowCount = 1
        Me.TLP_hweaponSprite.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_hweaponSprite.Size = New System.Drawing.Size(201, 29)
        Me.TLP_hweaponSprite.TabIndex = 18
        '
        'Txt_hweaponSprite
        '
        Me.Txt_hweaponSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_hweaponSprite.Location = New System.Drawing.Point(3, 4)
        Me.Txt_hweaponSprite.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Txt_hweaponSprite.Name = "Txt_hweaponSprite"
        Me.Txt_hweaponSprite.Size = New System.Drawing.Size(162, 20)
        Me.Txt_hweaponSprite.TabIndex = 9
        '
        'Btn_changePathHWeaponSprite
        '
        Me.Btn_changePathHWeaponSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_changePathHWeaponSprite.AutoSize = True
        Me.Btn_changePathHWeaponSprite.Location = New System.Drawing.Point(168, 3)
        Me.Btn_changePathHWeaponSprite.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.Btn_changePathHWeaponSprite.Name = "Btn_changePathHWeaponSprite"
        Me.Btn_changePathHWeaponSprite.Size = New System.Drawing.Size(31, 23)
        Me.Btn_changePathHWeaponSprite.TabIndex = 10
        Me.Btn_changePathHWeaponSprite.Text = "..."
        Me.Btn_changePathHWeaponSprite.UseVisualStyleBackColor = True
        '
        'Lbl_hweaponSprite
        '
        Me.Lbl_hweaponSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_hweaponSprite.AutoSize = True
        Me.Lbl_hweaponSprite.Location = New System.Drawing.Point(3, 202)
        Me.Lbl_hweaponSprite.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_hweaponSprite.Name = "Lbl_hweaponSprite"
        Me.Lbl_hweaponSprite.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_hweaponSprite.TabIndex = 14
        Me.Lbl_hweaponSprite.Text = "Heavy Weapon Sprite:"
        Me.Lbl_hweaponSprite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_hweaponData
        '
        Me.Lbl_hweaponData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_hweaponData.AutoSize = True
        Me.Lbl_hweaponData.Location = New System.Drawing.Point(3, 172)
        Me.Lbl_hweaponData.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_hweaponData.Name = "Lbl_hweaponData"
        Me.Lbl_hweaponData.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_hweaponData.TabIndex = 16
        Me.Lbl_hweaponData.Text = "Heavy Weapon Data:"
        Me.Lbl_hweaponData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_weaponSprite
        '
        Me.Lbl_weaponSprite.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_weaponSprite.AutoSize = True
        Me.Lbl_weaponSprite.Location = New System.Drawing.Point(3, 142)
        Me.Lbl_weaponSprite.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_weaponSprite.Name = "Lbl_weaponSprite"
        Me.Lbl_weaponSprite.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_weaponSprite.TabIndex = 9
        Me.Lbl_weaponSprite.Text = "Weapon Sprite:"
        Me.Lbl_weaponSprite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_weaponData
        '
        Me.Lbl_weaponData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_weaponData.AutoSize = True
        Me.Lbl_weaponData.Location = New System.Drawing.Point(3, 112)
        Me.Lbl_weaponData.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_weaponData.Name = "Lbl_weaponData"
        Me.Lbl_weaponData.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_weaponData.TabIndex = 5
        Me.Lbl_weaponData.Text = "Weapon Data:"
        Me.Lbl_weaponData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_hwSpriteFound
        '
        Me.Lbl_hwSpriteFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_hwSpriteFound.AutoSize = True
        Me.Lbl_hwSpriteFound.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl_hwSpriteFound.Location = New System.Drawing.Point(407, 202)
        Me.Lbl_hwSpriteFound.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_hwSpriteFound.Name = "Lbl_hwSpriteFound"
        Me.Lbl_hwSpriteFound.Size = New System.Drawing.Size(197, 13)
        Me.Lbl_hwSpriteFound.TabIndex = 21
        Me.Lbl_hwSpriteFound.Text = "File not found!"
        '
        'Lbl_hwdataFound
        '
        Me.Lbl_hwdataFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_hwdataFound.AutoSize = True
        Me.Lbl_hwdataFound.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl_hwdataFound.Location = New System.Drawing.Point(407, 172)
        Me.Lbl_hwdataFound.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_hwdataFound.Name = "Lbl_hwdataFound"
        Me.Lbl_hwdataFound.Size = New System.Drawing.Size(197, 13)
        Me.Lbl_hwdataFound.TabIndex = 21
        Me.Lbl_hwdataFound.Text = "File not found!"
        '
        'Lbl_wspriteFound
        '
        Me.Lbl_wspriteFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_wspriteFound.AutoSize = True
        Me.Lbl_wspriteFound.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl_wspriteFound.Location = New System.Drawing.Point(407, 142)
        Me.Lbl_wspriteFound.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_wspriteFound.Name = "Lbl_wspriteFound"
        Me.Lbl_wspriteFound.Size = New System.Drawing.Size(197, 13)
        Me.Lbl_wspriteFound.TabIndex = 20
        Me.Lbl_wspriteFound.Text = "File not found!"
        '
        'Lbl_direct
        '
        Me.Lbl_direct.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_direct.AutoSize = True
        Me.Lbl_direct.Location = New System.Drawing.Point(3, 87)
        Me.Lbl_direct.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_direct.Name = "Lbl_direct"
        Me.Lbl_direct.Size = New System.Drawing.Size(196, 13)
        Me.Lbl_direct.TabIndex = 5
        Me.Lbl_direct.Text = "Real Time Edit:"
        Me.Lbl_direct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cb_direct
        '
        Me.Cb_direct.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_direct.AutoSize = True
        Me.Cb_direct.Location = New System.Drawing.Point(205, 87)
        Me.Cb_direct.Name = "Cb_direct"
        Me.Cb_direct.Size = New System.Drawing.Size(196, 14)
        Me.Cb_direct.TabIndex = 7
        Me.Cb_direct.UseVisualStyleBackColor = True
        '
        'Lbl_wdataFound
        '
        Me.Lbl_wdataFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_wdataFound.AutoSize = True
        Me.Lbl_wdataFound.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl_wdataFound.Location = New System.Drawing.Point(407, 112)
        Me.Lbl_wdataFound.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_wdataFound.Name = "Lbl_wdataFound"
        Me.Lbl_wdataFound.Size = New System.Drawing.Size(197, 13)
        Me.Lbl_wdataFound.TabIndex = 19
        Me.Lbl_wdataFound.Text = "File not found!"
        '
        'Lbl_directInformation
        '
        Me.Lbl_directInformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_directInformation.AutoSize = True
        Me.Lbl_directInformation.Location = New System.Drawing.Point(407, 87)
        Me.Lbl_directInformation.Margin = New System.Windows.Forms.Padding(3)
        Me.Lbl_directInformation.Name = "Lbl_directInformation"
        Me.Lbl_directInformation.Size = New System.Drawing.Size(197, 13)
        Me.Lbl_directInformation.TabIndex = 5
        Me.Lbl_directInformation.Text = "Perhaps long undo/redo duration!"
        Me.Lbl_directInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OFD_sprite
        '
        Me.OFD_sprite.Filter = "Sprite sheet|*.bmp"
        Me.OFD_sprite.Title = "Select a sprite sheet..."
        '
        'OFD_data
        '
        Me.OFD_data.Filter = "Data|*.dat"
        Me.OFD_data.Title = "Select a data file..."
        '
        'UC_FrameViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.Controls.Add(Me.TLP_main)
        Me.Name = "UC_FrameViewer"
        Me.Padding = New System.Windows.Forms.Padding(16)
        Me.Size = New System.Drawing.Size(628, 262)
        Me.TLP_main.ResumeLayout(False)
        Me.TLP_main.PerformLayout()
        Me.TLP_defaultBG.ResumeLayout(False)
        Me.TLP_defaultBG.PerformLayout()
        CType(Me.Pic_defaultBG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TLP_weaponData.ResumeLayout(False)
        Me.TLP_weaponData.PerformLayout()
        Me.TLP_weaponSprite.ResumeLayout(False)
        Me.TLP_weaponSprite.PerformLayout()
        Me.TLP_hweaponData.ResumeLayout(False)
        Me.TLP_hweaponData.PerformLayout()
        Me.TLP_hweaponSprite.ResumeLayout(False)
        Me.TLP_hweaponSprite.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cb_ms As CheckBox
    Friend WithEvents TLP_main As TableLayoutPanel
    Friend WithEvents Lbl_ms As Label
    Friend WithEvents Lbl_globalView As Label
    Friend WithEvents Lbl_fulLRestore As Label
    Friend WithEvents Lbl_weaponData As Label
    Friend WithEvents Lbl_weaponSprite As Label
    Friend WithEvents Cb_globalView As CheckBox
    Friend WithEvents Cb_fullRestore As CheckBox
    Friend WithEvents TLP_weaponData As TableLayoutPanel
    Friend WithEvents Txt_weaponData As TextBox
    Friend WithEvents Btn_changePathWeaponData As Button
    Friend WithEvents TLP_weaponSprite As TableLayoutPanel
    Friend WithEvents Txt_weaponSprite As TextBox
    Friend WithEvents Btn_changePathWeaponSprite As Button
    Friend WithEvents Lbl_hweaponData As Label
    Friend WithEvents TLP_hweaponData As TableLayoutPanel
    Friend WithEvents Txt_hweaponData As TextBox
    Friend WithEvents Btn_changePathHWeaponData As Button
    Friend WithEvents Lbl_hweaponSprite As Label
    Friend WithEvents TLP_hweaponSprite As TableLayoutPanel
    Friend WithEvents Txt_hweaponSprite As TextBox
    Friend WithEvents Btn_changePathHWeaponSprite As Button
    Friend WithEvents OFD_sprite As OpenFileDialog
    Friend WithEvents OFD_data As OpenFileDialog
    Friend WithEvents Lbl_wdataFound As Label
    Friend WithEvents Lbl_wspriteFound As Label
    Friend WithEvents Lbl_hwdataFound As Label
    Friend WithEvents Lbl_hwSpriteFound As Label
    Friend WithEvents CD_defaultBG As ColorDialog
    Friend WithEvents Lbl_defaultBG As Label
    Friend WithEvents TLP_defaultBG As TableLayoutPanel
    Friend WithEvents Btn_defaultBG As Button
    Friend WithEvents Pic_defaultBG As PictureBox
    Friend WithEvents Btn_image As Button
    Friend WithEvents Lbl_direct As Label
    Friend WithEvents Cb_direct As CheckBox
    Friend WithEvents Lbl_directInformation As Label
End Class
