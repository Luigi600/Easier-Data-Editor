Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports ICSharpCode.AvalonEdit.Search
Imports WeifenLuo.WinFormsUI.Docking

Public Class index

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = class_singleInstance.WM_SETTEXT Then 'm.Msg = &H400
            Dim file As String = Marshal.PtrToStringAuto(m.LParam)
            If IO.File.Exists(file) Then
                OpenFile(file)

                Me.Show()
                Me.BringToFront()
                Me.Focus()
                Me.Activate()
                class_singleInstance.SetForegroundWindow(Me.Handle)
                If WindowState = FormWindowState.Minimized Then
                    class_singleInstance.ShowWindow(Me.Handle, class_singleInstance.SW_RESTORE)
                End If
                Exit Sub 'damit myBase nicht ausgerufen wird
            End If
        End If

        MyBase.WndProc(m)
    End Sub

    Public Sub New()
        InitializeComponent()
        dockpan_main.Theme = New VS2015LightTheme
        dockpan_main.DockBackColor = Color.White
        dockpan_main.DocumentStyle = DocumentStyle.DockingWindow
        dockpan_main.ShowDocumentIcon = True

        Me.Size = windowSize
        Me.WindowState = globalUser.windowState

        If IO.File.Exists(IO.Path.Combine(appFolder, "layout.xml")) And opt_saveSession Then
            isStarting = True
            dockpan_main.LoadFromXml(IO.Path.Combine(appFolder, "layout.xml"), New DeserializeDockContent(AddressOf getContentFromPersistString))
            For Each dockcon As DockContent In dockpan_main.Documents
                If TypeOf (dockcon) Is ui_textEditor Then
                    Dim editor As ui_textEditor = CType(dockcon, ui_textEditor)
                    If IsNothing(editor.Viewer) Then
                        editor.Viewer = New ui_frameViewer(editor.Path, editor, editor.ID) With {.HideOnClose = True}
                    End If

                    addRecentFile(editor.Path)

                    AddHandler editor.Viewer.GlobalSettingsChanged, AddressOf GlobalSettingsChangedFromViewer
                    'AddHandler editor.Viewer.OtherEditorsCanRefresh, AddressOf OtherEditorsCanRefreshFromViewer
                    AddHandler editor.EditorTextChanged, AddressOf ActivedContentTextChanged
                    AddHandler editor.SaveStateChanged, AddressOf EditorSaveStateChanged
                    AddHandler editor.DropEventOfEditor, AddressOf lv_items_DragDrop2
                    AddHandler editor.CurrentFrameViewerChanger, AddressOf TSMI_hT_frameViewer_Click
                End If
            Next

            isStarting = False
            Dim dockConTest As DockContent = dockpan_main.ActiveDocument
            If Not IsNothing(dockConTest) Then
                If TypeOf (dockConTest) Is ITextEditor Then
                    CType(dockConTest, ITextEditor).SetUnusedFramesList(False)
                    CType(dockConTest, ITextEditor).SetErrorList(False)
                ElseIf TypeOf (dockConTest) Is IFrameViewer Then
                    CType(dockConTest, IFrameViewer).getTextEditor.SetUnusedFramesList(False)
                    CType(dockConTest, IFrameViewer).getTextEditor.SetErrorList(False)
                End If
            End If
        End If

        For Each arg As String In My.Application.CommandLineArgs
            If IO.File.Exists(arg) Then
                OpenFile(IO.Path.GetFullPath(arg))
            End If
        Next




        'Dim mtchs As MatchCollection = Regex.Matches(test, "(?<=\<Word\>)[^\<\>]+(?=\</Word\>)", RegexOptions.IgnoreCase)
        'For Each tes As Match In mtchs
        '    Console.WriteLine(tes)
        'Next

        'isStarting = True 'DEBUG REMOVE IT
    End Sub

    Private Sub index_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ms_main.Refresh()
        ms_icons.Refresh()
        ms_main.Invalidate()
        ms_icons.Invalidate()

        For Each con As DockContent In dockpan_main.Documents
            con.Refresh()
            con.Invalidate()
        Next
    End Sub

    Private Sub OpenFile(ByVal file As String)
        If IO.File.Exists(file) Then
            Dim loadFile As Boolean = True
            Dim conOwner As IDockContent = Nothing

            If Not globalUser.opt_doubleOpening Then
                For Each con As IDockContent In dockpan_main.Documents
                    If TypeOf (con) Is ITextEditor Then
                        conOwner = con
                        If CType(con, ITextEditor).Path.Equals(file) Then
                            CType(con, DockContent).Show()
                            loadFile = False
                            Exit For
                        End If
                    End If
                Next
            End If

            If loadFile Then
                Dim editor As New ui_textEditor(file)

                If Not IsNothing(conOwner) Then
                    editor.Show(CType(conOwner, DockContent).PanelPane, conOwner)
                Else
                    editor.Show(dockpan_main, DockState.Document)
                End If


                AddHandler editor.Viewer.GlobalSettingsChanged, AddressOf GlobalSettingsChangedFromViewer
                'AddHandler editor.Viewer.OtherEditorsCanRefresh, AddressOf OtherEditorsCanRefreshFromViewer
                AddHandler editor.EditorTextChanged, AddressOf ActivedContentTextChanged
                AddHandler editor.SaveStateChanged, AddressOf EditorSaveStateChanged
                AddHandler editor.DropEventOfEditor, AddressOf lv_items_DragDrop2
                AddHandler editor.CurrentFrameViewerChanger, AddressOf TSMI_hT_frameViewer_Click

                If opt_autoOpenViewer Then
                    Dim foundOtherViewer As Boolean = False
                    For Each con As IDockContent In dockpan_main.Documents
                        If TypeOf (con) Is IFrameViewer Then
                            editor.Viewer.Show(CType(con, DockContent).PanelPane, con)
                            foundOtherViewer = True
                            Exit For
                        End If
                    Next
                    If Not foundOtherViewer Then
                        editor.Viewer.Show(dockpan_main, DockState.Document)
                    End If
                End If
            End If
        End If
    End Sub

#Region "ToolStripMenuItems"
#Region "File"
    Private Sub TSMI_file_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_file.DropDownOpening
        TSMI_recentFiles.DropDownItems.Clear()
        For Each file As String In recentFiles
            Dim tsmi As New ToolStripMenuItem With {.Text = file}
            AddHandler tsmi.Click, New EventHandler(Sub()
                                                        OpenFile(file)
                                                    End Sub)
            TSMI_recentFiles.DropDownItems.Add(tsmi)
        Next
        TSMI_recentFiles.Enabled = recentFiles.Count > 0
    End Sub

    Private Sub TSMI_new_Click(sender As Object, e As EventArgs) Handles TSMI_new.Click, TSMI_icon_new.Click
        Dim editor As New ui_textEditor()
        editor.Show(dockpan_main, DockState.Document)

        AddHandler editor.Viewer.GlobalSettingsChanged, AddressOf GlobalSettingsChangedFromViewer
        'AddHandler editor.Viewer.OtherEditorsCanRefresh, AddressOf OtherEditorsCanRefreshFromViewer
        AddHandler editor.EditorTextChanged, AddressOf ActivedContentTextChanged
        AddHandler editor.SaveStateChanged, AddressOf EditorSaveStateChanged
        AddHandler editor.DropEventOfEditor, AddressOf lv_items_DragDrop2
        AddHandler editor.CurrentFrameViewerChanger, AddressOf TSMI_hT_frameViewer_Click
    End Sub

    Private Sub TSMI_open_Click(sender As Object, e As EventArgs) Handles TSMI_open.Click, TSMI_icon_open.Click
        If ofd_data.ShowDialog = DialogResult.OK Then
            For Each file As String In ofd_data.FileNames
                OpenFile(file)
                addRecentFile(file)
            Next
        End If
    End Sub

    Private Sub TSMI_save_Click(sender As Object, e As EventArgs) Handles TSMI_save.Click, TSMI_icon_save.Click, TSMI_saveAs.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.Save(CType(sender, ToolStripMenuItem).Name.EndsWith("As"))
        End If
    End Sub

    Private Sub TSMI_saveAll_Click(sender As Object, e As EventArgs) Handles TSMI_saveAll.Click, TSMI_icon_saveAll.Click
        For Each dockEle As IDockContent In dockpan_main.Documents
            If TypeOf (dockEle) Is ITextEditor Then
                Dim teditor As ITextEditor = CType(dockEle, ITextEditor)
                If Not teditor.IsSave Then
                    teditor.Save()
                End If
            End If
        Next
    End Sub

    Private Sub TSMI_close_Click(sender As Object, e As EventArgs) Handles TSMI_close.Click, TSMI_icon_close.Click
        Dim yetActived As DockContent = dockpan_main.ActiveDocument
        If Not IsNothing(yetActived) Then
            If yetActived.HideOnClose Then
                yetActived.Hide()
            Else
                yetActived.Close()
            End If
        End If
    End Sub

    Private Sub TSMI_quit_Click(sender As Object, e As EventArgs) Handles TSMI_quit.Click
        Me.Close()
    End Sub
#End Region
#Region "Edit"
    Private Sub TSMI_edit_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_edit.DropDownOpening
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            TSMI_cut.Enabled = editor.GetAvalonEditor.SelectionLength > 0
            TSMI_copy.Enabled = editor.GetAvalonEditor.SelectionLength > 0
            TSMI_delete.Enabled = editor.GetAvalonEditor.SelectionLength > 0

            TSMI_paste.Enabled = My.Computer.Clipboard.ContainsText
            TSMI_paste_cool.Enabled = My.Computer.Clipboard.ContainsText
        End If
    End Sub

    Private Sub TSMI_undo_Click(sender As Object, e As EventArgs) Handles TSMI_undo.Click, TSMI_icon_undo.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.GetAvalonEditor().Undo()
        End If
    End Sub

    Private Sub TSMI_redo_Click(sender As Object, e As EventArgs) Handles TSMI_redo.Click, TSMI_icon_redo.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.GetAvalonEditor().Redo()
        End If
    End Sub

    Private Sub TSMI_cut_Click(sender As Object, e As EventArgs) Handles TSMI_cut.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.GetAvalonEditor().Cut()
        End If
    End Sub

    Private Sub TSMI_copy_Click(sender As Object, e As EventArgs) Handles TSMI_copy.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.GetAvalonEditor().Copy()
        End If
    End Sub

    Private Sub TSMI_paste_Click(sender As Object, e As EventArgs) Handles TSMI_paste.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.GetAvalonEditor().Paste()
        End If
    End Sub

    Private Sub TSMI_paste_cool_Click(sender As Object, e As EventArgs) Handles TSMI_paste_cool.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.PasteCool()
        End If
    End Sub

    Private Sub TSMI_delete_Click(sender As Object, e As EventArgs) Handles TSMI_delete.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.GetAvalonEditor().Delete()
        End If
    End Sub

    Private Sub TSMI_selectAll_Click(sender As Object, e As EventArgs) Handles TSMI_selectAll.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.GetAvalonEditor().SelectAll()
        End If
    End Sub

    Private Sub TSMI_expand_Click(sender As Object, e As EventArgs) Handles TSMI_expand.Click, TSMI_collapse.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            editor.Expand(Not CType(sender, ToolStripMenuItem).Name.EndsWith("expand"))
        End If
    End Sub

    Private Function getActivedEditor() As ITextEditor
        Dim yetActived As IDockContent = dockpan_main.ActiveContent
        If Not IsNothing(yetActived) Then
            If TypeOf (yetActived) Is ITextEditor Then
                Return CType(yetActived, ITextEditor)
            ElseIf TypeOf (yetActived) Is IFrameViewer Then
                Return CType(yetActived, IFrameViewer).getTextEditor
            End If
        End If
        Return Nothing
    End Function
#End Region
#Region "Search"
    'Private Sub TSMI_search_Click(sender As Object, e As EventArgs) Handles TSMI_search.Click
    '    'Dim editor As ITextEditor = getActivedEditor()
    '    'If Not IsNothing(editor) Then
    '    '    Dim sp As SearchPanel = SearchPanel.Install(editor.GetAvalonEditor())
    '    '    sp.Open()
    '    'End If
    'End Sub

    Private Sub TSMI_find_Click(sender As Object, e As EventArgs) Handles TSMI_find.Click, TSMI_find_replace.Click
        If Not IsNothing(SearchClass) Then
            If Not IsNothing(lastRealTextEditor) Then
                SearchClass.TextEditor = lastRealTextEditor.GetAvalonEditor
                Dim selectedWord As String = SearchClass.TextEditor.SelectedText
                If Not String.IsNullOrWhiteSpace(selectedWord) Then
                    SearchClass.searchWord = selectedWord
                End If
            Else
                MessageBox.Show(Me, "No text editor selected.", "Error - Data-Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Else
            SearchClass.TextEditor = Nothing
        End If

        If Not IsNothing(SearchWindow) Then
            SearchClass.ReverseIsOpen = CType(sender, ToolStripMenuItem).Name.EndsWith("replace")
            SearchWindow.Showing()
            If Not SearchWindow.Visible Then
                SearchWindow.Show(Me)
            Else
                SearchWindow.Focus()
            End If
        End If
    End Sub

    Private Sub TSMI_find2_Click(sender As ToolStripMenuItem, e As EventArgs) Handles TSMI_find_again.Click, TSMI_find_again_reverse.Click
        If Not IsNothing(SearchClass) Then
            If Not IsNothing(lastRealTextEditor) Then
                SearchClass.TextEditor = lastRealTextEditor.GetAvalonEditor
                SearchClass.Find(sender.Name.EndsWith("reverse"))
            Else
                MessageBox.Show(Me, "No text editor selected.", "Error - Data-Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TSMI_jump_to_Click(sender As Object, e As EventArgs) Handles TSMI_jump_to.Click
        Dim editor As ITextEditor = lastRealTextEditor
        If Not IsNothing(editor) Then
            Dim frm As New ui_go_to(lastRealTextEditor.GetAvalonEditor)
            frm.ShowDialog(Me)
        End If
    End Sub
#End Region
#Region "Windows"
    Private Sub TSMI_view_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_windows.DropDownOpening
        TSMI_frameViewer.DropDownItems.Clear()
        For Each con As IDockContent In dockpan_main.Documents
            If TypeOf (con) Is ITextEditor Then
                Dim editor As ITextEditor = CType(con, ITextEditor)
                Dim TSMI As New ToolStripMenuItem With {.Checked = CType(editor.Viewer, DockContent).Visible}
                Dim foundText As Boolean = False
                If Not String.IsNullOrEmpty(editor.Path) Then
                    If editor.Path.Length > 3 Then
                        Dim file As String = IO.Path.GetFileName(editor.Path)
                        If file.Length > 1 Then
                            TSMI.Text = file
                            foundText = True
                        End If
                    End If
                End If
                If Not foundText Then
                    TSMI.Text = "New File"
                End If
                TSMI.CheckOnClick = True
                TSMI.Tag = CType(con, ITextEditor).Viewer
                AddHandler TSMI.CheckStateChanged, AddressOf TSMI_ViewItem_CheckStateChanged
                TSMI_frameViewer.DropDownItems.Add(TSMI)
            End If
        Next

        TSMI_unused_frames.Checked = UnusedFrames.Visible
        TSMI_error_list.Checked = ErrorList.Visible
    End Sub

    Private Sub TSMI_ViewItem_CheckStateChanged(sender As ToolStripMenuItem, e As EventArgs) Handles TSMI_windows.CheckStateChanged
        If Not IsNothing(sender.Tag) Then
            If TypeOf (sender.Tag) Is DockContent Then
                Dim viewer As DockContent = CType(sender.Tag, DockContent)
                If Not viewer.Visible Then
                    Dim dockcon As IDockContent = Nothing
                    Dim foundOtherViewer As Boolean = False
                    For Each con As IDockContent In dockpan_main.Documents
                        If TypeOf (con) Is IFrameViewer Then
                            dockcon = con
                            Exit For
                        End If
                    Next

                    If Not IsNothing(dockcon) Then
                        viewer.Show(CType(dockcon, DockContent).PanelPane, dockcon)
                    Else
                        Dim dockPane As DockPane = getDockElement(DockState.Document)
                        If Not IsNothing(dockPane) Then
                            viewer.Show(dockPane, DockAlignment.Right, 0.5)
                        Else
                            viewer.Show(dockpan_main, DockState.Document)
                        End If
                    End If
                Else
                    viewer.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub TSMI_unused_frames_Click(sender As Object, e As EventArgs) Handles TSMI_unused_frames.Click
        If Not UnusedFrames.Visible Then
            'Dim dockPane As DockPane = getDockElement(DockState.Document)
            'If Not IsNothing(dockPane) Then
            '    UnusedFrames.Show(dockPane, DockAlignment.Right, 0.5)
            'Else
            '    UnusedFrames.Show(dockpan_main, DockState.Document)
            'End If
            UnusedFrames.Show(dockpan_main, DockState.Document)
        Else
            UnusedFrames.Hide()
        End If
    End Sub

    Private Sub TSMI_error_list_Click(sender As Object, e As EventArgs) Handles TSMI_error_list.Click
        If Not ErrorList.Visible Then
            'Dim dockPane As DockPane = getDockElement(DockState.Document)
            'If Not IsNothing(dockPane) Then
            '    ErrorList.Show(dockPane, DockAlignment.Bottom, 0.5)
            'Else
            '    ErrorList.Show(dockpan_main, DockState.Document)
            'End If
            ErrorList.Show(dockpan_main, DockState.Document)
        Else
            ErrorList.Hide()
        End If
    End Sub
#End Region
#Region "Tools"
    Private Sub TSMI_tools_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_tools.DropDownOpening
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            TSMI_tag_adder.Enabled = editor.GetAvalonEditor.SelectedText.Length > 5
            TSMI_ID_changer.Enabled = TSMI_tag_adder.Enabled
        Else
            TSMI_tag_adder.Enabled = False
            TSMI_ID_changer.Enabled = False
        End If
    End Sub

    Private Sub TSMI_framesReformatting_Click(sender As Object, e As EventArgs) Handles TSMI_framesReformatting.Click
        Dim listOfEditors As New List(Of ITextEditor)
        For Each dockCon As DockContent In dockpan_main.Documents
            If TypeOf (dockCon) Is ITextEditor Then
                listOfEditors.Add(dockCon)
            End If
        Next
        Dim editor As ITextEditor = lastRealTextEditor
        Dim selectedPath As String = ""
        If Not IsNothing(editor) Then
            selectedPath = editor.Path
        End If
        Dim frm As New ui_frames_reformatting(listOfEditors, selectedPath)
        frm.ShowDialog()
    End Sub

    Private Sub TSMI_mirrorFrame_Click(sender As Object, e As EventArgs) Handles TSMI_mirrorFrame.Click
        Dim test As DockContent = dockpan_main.ActiveDocument
        If Not IsNothing(test) Then
            If TypeOf (test) Is ui_frameViewer Then
                CType(test, ui_frameViewer).tool_mirrorFrame()
            ElseIf TypeOf (test) Is ITextEditor Then
                CType(test, ITextEditor).Viewer.tool_mirrorFrame()
                CType(test, ITextEditor).Viewer.Invalidate()
                CType(test, ITextEditor).Viewer.Refresh()
            End If
        End If
    End Sub

    Private Sub TSMI_tag_adder_Click(sender As Object, e As EventArgs) Handles TSMI_tag_adder.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            Dim frm As New ui_tag_adder(editor.GetAvalonEditor, IO.Path.GetFileName(editor.Path))
            frm.ShowDialog()
        End If
    End Sub

    Private Sub TSMI_ID_changer_Click(sender As Object, e As EventArgs) Handles TSMI_ID_changer.Click
        Dim editor As ITextEditor = getActivedEditor()
        If Not IsNothing(editor) Then
            Dim frm As New ui_id_changer(editor.GetAvalonEditor, IO.Path.GetFileName(editor.Path))
            frm.ShowDialog()
        End If
    End Sub
#End Region

#Region "Hidden Tools"
    Private Sub TSMI_hT_frameViewer_Click(sender As Object, e As EventArgs) Handles TSMI_hT_frameViewer.Click
        Dim editor As Object = sender
        If IsNothing(editor) Then
            editor = getActivedEditor()
        ElseIf Not TypeOf (editor) Is IFrameViewer And Not TypeOf (editor) Is ITextEditor Then
            editor = getActivedEditor()
        End If

        If TypeOf (editor) Is ITextEditor Then
            editor = CType(editor, ITextEditor).Viewer
        End If
        If Not IsNothing(editor) And TypeOf (editor) Is IFrameViewer Then
            TSMI_ViewItem_CheckStateChanged(New ToolStripMenuItem With {.Tag = editor}, e)
            CType(editor, IFrameViewer).getTextEditor.getDockContent.Activate()
        End If
    End Sub
#End Region

    Private Function getDockElement(ByVal checkDock As DockState) As DockPane
        For Each dD As DockContent In dockpan_main.Contents
            If dD.DockState = checkDock Then
                Return dD.Pane
            End If
        Next
        Return Nothing
    End Function

    Private Sub TSMI_settings_Click(sender As Object, e As EventArgs) Handles TSMI_settings.Click
        Dim frm As New ui_settings(AddressOf SettingsWasChanged)
        frm.ShowDialog()
    End Sub

    Private Sub TSMI_about_Click(sender As Object, e As EventArgs) Handles TSMI_about.Click
        Dim frm As New ui_about
        frm.ShowDialog()
    End Sub

    Private Sub SettingsWasChanged()
        For Each dockCon As DockContent In dockpan_main.Documents
            If TypeOf (dockCon) Is ITextEditor Then
                Dim editor As ICSharpCode.AvalonEdit.TextEditor = CType(dockCon, ITextEditor).GetAvalonEditor
                editor.FontFamily = opt_userFontFamily 'Courier New")
                editor.FontSize = opt_userFontSize
            ElseIf TypeOf (dockCon) Is ui_frameViewer Then
                CType(dockCon, ui_frameViewer).ms_options.Visible = opt_showMS
                CType(dockCon, ui_frameViewer).pal_charView.Visible = Not opt_showMS
                CType(dockCon, ui_frameViewer).pic_preview.BackColor = opt_defaultBackgroundColor
            End If
        Next
    End Sub

    Private Sub GlobalSettingsChangedFromViewer(ByVal sender As Object, ByVal e As class_customEventArgs)
        Dim name As String = ""
        Dim checkState As Boolean = False
        If TypeOf (sender) Is ToolStripMenuItem Then
            name = CType(sender, ToolStripMenuItem).Name
        ElseIf TypeOf (sender) Is CheckBox Then
            name = CType(sender, CheckBox).Name
        ElseIf TypeOf (sender) Is String Then
            name = sender
        End If

        If TypeOf (e.Object) Is Boolean Then
            checkState = CType(e.Object, Boolean)
        End If

        If name.Length > 2 Then
            If name.EndsWith("bodies") Then
                global_draw_bodys = checkState
            ElseIf name.EndsWith("itrs") Then
                global_draw_itrs = checkState
            ElseIf name.EndsWith("bpoint") Then
                global_draw_bpoint = checkState
            ElseIf name.EndsWith("wpoint") Then
                global_draw_weapon = checkState
            ElseIf name.EndsWith("cpoint") Then
                global_draw_cpoint = checkState
            ElseIf name.EndsWith("opoint") Then
                global_draw_opoint = checkState
            ElseIf name.EndsWith("axis") Then
                global_draw_axis = checkState
            ElseIf name.EndsWith("center_xy") Then
                global_draw_centerXY = checkState
            ElseIf name.EndsWith("shadow") Then
                global_draw_shadow = checkState
            ElseIf name.EndsWith("showScales") Then
                global_draw_scales = checkState
            ElseIf name.EndsWith("zoom") Then
                If Not IsNothing(e.Object) Then
                    Dim int As Integer = Convert.ToInt64(e.Object)
                    If int >= 100 And int <= 600 Then
                        global_zoom = int
                    End If
                End If

            ElseIf name.EndsWith("scrollPosition") Then
                If Not IsNothing(e.Object) Then
                    If TypeOf (e.Object) Is Point Then
                        global_scrollPosition = CType(e.Object, Point)
                    End If
                End If
            ElseIf name.EndsWith("centerPoint") Then
                If Not IsNothing(e.Object) Then
                    If TypeOf (e.Object) Is Point Then
                        global_centerPoint = CType(e.Object, Point)
                    End If
                End If
            End If
        End If

        For Each dockCon As DockContent In dockpan_main.Documents
            If TypeOf (dockCon) Is ui_frameViewer Then
                If Not CType(dockCon, ui_frameViewer).ID = e.Object2 Then
                    CType(dockCon, ui_frameViewer).RefreshGlobalSettings()
                End If
            End If
        Next
    End Sub

    'Private Sub OtherEditorsCanRefreshFromViewer(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim selectedID As Integer = -5
    '    If Not IsNothing(sender) Then
    '        If TypeOf (sender) Is Integer Then
    '            selectedID = CType(sender, Integer)
    '        End If
    '    End If
    '    For Each dockCon As DockContent In dockpan_main.Documents
    '        If TypeOf (dockCon) Is ui_frameViewer Then
    '            If Not CType(dockCon, ui_frameViewer).ID = selectedID Then
    '                CType(dockCon, ui_frameViewer).RefreshGlobalSettings()
    '            End If
    '        End If
    '    Next
    'End Sub
#End Region

#Region "Editor Stuff (change something etc)"
    Dim lastFrameViewer As IFrameViewer = Nothing
    Dim lastRealTextEditor As ITextEditor = Nothing
    Dim lastID As Integer = -1
    Private Sub dockpan_main_ActiveContentChanged(sender As Object, e As EventArgs) Handles dockpan_main.ActiveContentChanged
        Dim yetActived As IDockContent = dockpan_main.ActiveContent
        Dim itWasViewer As Boolean = False
        setButtons(Not IsNothing(yetActived))

        If Not IsNothing(lastFrameViewer) Then
            lastFrameViewer.hasFocus = False
        End If

        If Not IsNothing(yetActived) Then
            Console.WriteLine("NOW: " & yetActived.ToString)
            If TypeOf (yetActived) Is IFrameViewer Then
                itWasViewer = True
                lastFrameViewer = CType(yetActived, IFrameViewer)
                lastFrameViewer.hasFocus = True
                CType(yetActived, DockContent).Refresh()
                yetActived = CType(yetActived, IFrameViewer).getTextEditor

            ElseIf TypeOf (yetActived) Is ITextEditor Then
                lastFrameViewer = Nothing
                lastRealTextEditor = CType(yetActived, ITextEditor)
            End If
        End If

        If Not IsNothing(yetActived) Then
            TSMI_edit.Enabled = (TypeOf (yetActived) Is ITextEditor)
            TSMI_search.Enabled = TSMI_edit.Enabled
            If TSMI_edit.Enabled Then 'is ITextEditor
                TSMI_undo.Enabled = CType(yetActived, ITextEditor).GetAvalonEditor().CanUndo
                TSMI_icon_undo.Enabled = TSMI_undo.Enabled
                TSMI_redo.Enabled = CType(yetActived, ITextEditor).GetAvalonEditor().CanRedo
                TSMI_icon_redo.Enabled = TSMI_redo.Enabled

                If Not lastID = CType(yetActived, ITextEditor).ID And Not itWasViewer Then
                    CType(yetActived, ITextEditor).SetErrorList()
                    CType(yetActived, ITextEditor).SetUnusedFramesList()
                    lastID = CType(yetActived, ITextEditor).ID
                End If
            Else
                TSMI_undo.Enabled = False
                TSMI_icon_undo.Enabled = False
                TSMI_redo.Enabled = False
                TSMI_icon_redo.Enabled = False
            End If
        Else
            Dim clrList As Boolean = True
            For Each dockPan As IDockContent In dockpan_main.Documents
                If TypeOf (dockPan) Is ITextEditor Then
                    clrList = False
                    Exit For
                End If
            Next

            If clrList Then
                setButtons(False)
                ErrorList.ClearList()
                UnusedFrames.ClearList()
            End If
        End If
    End Sub

    Private Sub ActivedContentTextChanged(ByVal sender As ICSharpCode.AvalonEdit.TextEditor, ByVal e As EventArgs)
        If Not IsNothing(sender) Then
            TSMI_undo.Enabled = sender.CanUndo
            TSMI_icon_undo.Enabled = TSMI_undo.Enabled
            TSMI_redo.Enabled = sender.CanRedo
            TSMI_icon_redo.Enabled = TSMI_redo.Enabled
        End If
    End Sub

    Private Sub EditorSaveStateChanged(ByVal sender As Object, ByVal e As class_customEventArgs)
        If Not IsNothing(e.Object) Then
            If TypeOf (e.Object) Is Boolean Then
                If Not IsNothing(sender) Then
                    If TypeOf (sender) Is ITextEditor Then
                        Dim activedControl As DockContent = CType(sender, ITextEditor).getDockContent
                        Dim val As Boolean = CType(e.Object, Boolean)
                        If Not val Then
                            If Not activedControl.Text.EndsWith("*") Then
                                activedControl.Text &= "*"
                            End If
                        ElseIf val And activedControl.Text.EndsWith("*") Then
                            activedControl.Text = activedControl.Text.Substring(0, activedControl.Text.Length - 1)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub setButtons(ByVal val As Boolean)
        TSMI_save.Enabled = val
        TSMI_saveAll.Enabled = val
        TSMI_saveAs.Enabled = val
        TSMI_icon_save.Enabled = val
        TSMI_icon_saveAll.Enabled = val
        TSMI_close.Enabled = val
        TSMI_icon_close.Enabled = val

        TSMI_icon_undo.Enabled = val
        TSMI_icon_redo.Enabled = val

        TSMI_edit.Enabled = val
        TSMI_search.Enabled = val
        TSMI_frameViewer.Enabled = val
        TSMI_tools.Enabled = val

        TSMI_expand.Enabled = opt_folding
        TSMI_collapse.Enabled = opt_folding
    End Sub
#End Region

#Region "This window events stuff"
    Private m_lastState As FormWindowState = FormWindowState.Normal
    Protected Overrides Sub OnClientSizeChanged(ByVal e As EventArgs)
        If WindowState <> m_lastState Then
            m_lastState = WindowState
            OnWindowStateChanged(e)
        End If

        MyBase.OnClientSizeChanged(e)
    End Sub

    Protected Sub OnWindowStateChanged(ByVal e As EventArgs)
        globalUser.windowState = WindowState
    End Sub

    Private Sub index_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        globalUser.windowSize = Size
    End Sub

    Private Sub index_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each dockCon As IDockContent In dockpan_main.Documents
            If TypeOf (dockCon) Is ITextEditor Then
                Dim editor As ITextEditor = dockCon
                If Not editor.IsSave Then
                    CType(dockCon, DockContent).Show()
                End If
                If Not editor.CloseDocument Then
                    e.Cancel = True
                    Exit For
                End If
            End If
        Next

        If Not e.Cancel Then
            If opt_saveSession Then
                For i As Integer = 0 To dockpan_main.Documents.Count - 1
                    If i >= dockpan_main.Documents.Count Then
                        Exit For
                    End If

                    If TypeOf (dockpan_main.Documents(i)) Is ITextEditor Then
                        If String.IsNullOrEmpty(CType(dockpan_main.Documents(i), ITextEditor).Path) Then
                            CType(dockpan_main.Documents(i), ITextEditor).IsSave = True
                            CType(dockpan_main.Documents(i), DockContent).Close()
                            i -= 1
                        End If
                    End If
                Next
                dockpan_main.SaveAsXml(IO.Path.Combine(appFolder, "layout.xml"))
            End If
        End If
    End Sub
#End Region

    Private Sub link_cookiesoft_Click(sender As Object, e As EventArgs) Handles link_cookiesoft.Click
        Process.Start("http://cookiesoft.lui-studio.net/")
    End Sub

    Private Sub lv_items_DragEnter(sender As Object, e As DragEventArgs) Handles dockpan_main.DragEnter, Me.DragEnter 'Me.AllowDrop MUSS AUF True SEIN!
        e.Effect = If(e.Data.GetDataPresent(DataFormats.FileDrop), DragDropEffects.Copy, DragDropEffects.None)
    End Sub

    Private Sub lv_items_DragDrop(sender As Object, e As DragEventArgs) Handles dockpan_main.DragDrop, Me.DragDrop 'Me.AllowDrop MUSS AUF True SEIN!
        If TypeOf e.Data.GetData(DataFormats.FileDrop) Is String Then
            OpenFile(CType(e.Data.GetData(DataFormats.FileDrop), String))
        ElseIf TypeOf e.Data.GetData(DataFormats.FileDrop) Is String() Then
            For Each file As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                OpenFile(file)
            Next
        End If
    End Sub

    Private Sub lv_items_DragDrop2(ByVal list As Object, ByVal e As class_customEventArgs)
        If TypeOf list Is String Then
            OpenFile(CType(list, String))
        ElseIf TypeOf list Is String() Then
            For Each file As String In CType(list, String())
                OpenFile(file)
            Next
        End If
    End Sub
End Class
