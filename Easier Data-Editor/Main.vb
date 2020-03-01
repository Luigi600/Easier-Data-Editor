'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports WeifenLuo.WinFormsUI.Docking

''' <summary>The main window.</summary>
Public Class Main
    Private m_toolStripItems As New List(Of ToolStripItem)
    Private m_isStarting As Boolean = True
    Private m_lastUserItem As IUserItem = Nothing
    Private m_isActive As Boolean = True
    Private Const SUPPORTED_FILES_PATTERN As String = "\.(txt|dat)$"

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatablePrefix = AppTitle
        NotTranslatableControls.AddRange({TSComb_frames, TSComb_lf, TSSL_textLengthVal, TSSL_textLinesVal, Link_Cookiesoft})
    End Sub

    Public Sub New()
        InitializeComponent()

        AddHandler TSMI_equation.DropDown.Closing, AddressOf DontCloseEvent

        Dim debugTest As Date = Date.Now
        DockPan_Main.Theme = New DataEditorTheme
        DockPan_Main.DockBackColor = Color.White
        DockPan_Main.DocumentStyle = DocumentStyle.DockingWindow
        DockPan_Main.ShowDocumentIcon = True

        Size = App.Settings.WindowSize
        WindowState = App.Settings.WindowState

        m_toolStripItems.AddRange({TSMI_save, TSMI_saveAll, TSMI_saveAs, TSMI_export, TSMI_close, TSMI_closeAll,
        TSMI_icon_save, TSMI_icon_saveAll, TSMI_icon_close, TSMI_icon_undo, TSMI_icon_redo, TSComb_frames, TSComb_lf, TSMI_run,
        TSMI_edit, TSMI_search, TSMI_view, TSMI_tools})

        DEBUG_DO_ERRORS.Visible = App.IsDebug

        If App.Settings.SaveSession AndAlso IO.File.Exists(LayoutFile) Then
            DockPan_Main.LoadFromXml(LayoutFile, New DeserializeDockContent(AddressOf GetContentFromPersistString))
            Dim frameViewers As New List(Of FrameViewer)
            For Each con As DockContent In DockPan_Main.Contents
                If TypeOf con Is FrameViewer Then
                    frameViewers.Add(con)
                End If
            Next

            For Each dockcon As DockContent In DockPan_Main.Contents
                If TypeOf dockcon Is TextEditor Then
                    Dim editor As TextEditor = dockcon
                    Dim frameInd As Integer = -1
                    For i As Integer = 0 To frameViewers.Count - 1
                        If frameViewers(i).ID = CType(dockcon, TextEditor).ID Then
                            frameInd = i
                            Exit For
                        End If
                    Next

                    If frameInd >= 0 Then
                        editor.Viewer = frameViewers(frameInd)
                        frameViewers.RemoveAt(frameInd)
                    Else
                        editor.Viewer = New FrameViewer(editor) With {.HideOnClose = True}
                    End If

                    If App.Settings.FullRestore Then
                        editor.GoToFrame(App.Settings.Restorer.SelectedID)
                        editor.SetFirstVisibleLine(editor.FirstVisibleLineFromLastStart)
                    End If

                    SetEditorEvents(editor)
                End If
            Next
        End If

        m_isStarting = False
        CheckEXEFiles()

        For Each arg As String In My.Application.CommandLineArgs
            If IO.File.Exists(arg) Then
                OpenFile(IO.Path.GetFullPath(arg))
            End If
        Next

        Console.WriteLine("Loading Time: {0}", (Date.Now - debugTest).TotalMilliseconds)
        'OpenTextEditor(New TextEditor("D:\Little Fighters\LittleFighter2_ORIGINAL\data\davis.dat", True))

        AddHandler App.Settings.SettingsChanged, AddressOf SettingsChanged
    End Sub

#Region "Overrides and events"
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Delete Then
            Dim active As Object = GetActiveTextEditor()
            If TypeOf active Is TextEditor Then
                If CType(active, TextEditor).DeleteKey() Then
                    Return True
                End If
            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H20A Then 'm.Msg = &H115 OrElse
            Dim editors As List(Of TextEditor) = DockPan_Main.Contents.OfType(Of TextEditor).ToList
            For Each editor As TextEditor In editors
                editor.LineScroll(If(CInt(m.WParam) < 0, 1, -1) * 3)
            Next
            Exit Sub
        ElseIf m.Msg = SingleInstance.WM_SETTEXT Then 'm.Msg = &H400
            Dim file As String = Marshal.PtrToStringAuto(m.LParam)
            If IO.File.Exists(file) Then
                OpenFile(file)

                Me.Show()
                Me.BringToFront()
                Me.Focus()
                Me.Activate()
                SingleInstance.SetForegroundWindow(Me.Handle)
                If WindowState = FormWindowState.Minimized Then
                    SingleInstance.ShowWindow(Me.Handle, SingleInstance.SW_RESTORE)
                End If
                Exit Sub 'bypass MyBase Function
            End If
        End If

        MyBase.WndProc(m)
    End Sub

    Protected Overrides Sub OnDeactivate(e As EventArgs)
        m_isActive = False
        For Each txtEditor As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
            txtEditor.SetScintillasState(False)
        Next
        MyBase.OnDeactivate(e)
    End Sub

    Protected Overrides Sub OnActivated(e As EventArgs)
        m_isActive = True
        For Each txtEditor As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
            txtEditor.SetScintillasState(True)
        Next
        MyBase.OnActivated(e)
    End Sub

    Private Sub DragOver_(sender As Object, e As DragEventArgs) Handles DockPan_Main.DragOver, Me.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop, True) Then
            Dim files As String() = e.Data.GetData(DataFormats.FileDrop, True)
            Dim misMatchCounter As Integer = 0
            For Each file As String In files
                If Not System.Text.RegularExpressions.Regex.IsMatch(file, SUPPORTED_FILES_PATTERN, System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                    misMatchCounter += 1
                End If
            Next

            If misMatchCounter = files.Count Then
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Sub DragEnter_(sender As Object, e As DragEventArgs) Handles DockPan_Main.DragEnter, Me.DragEnter 'Me.AllowDrop MUST BE True!
        e.Effect = If(e.Data.GetDataPresent(DataFormats.FileDrop), DragDropEffects.Copy, DragDropEffects.None)
    End Sub

    Private Sub DragDrop_(sender As Object, e As DragEventArgs) Handles DockPan_Main.DragDrop, Me.DragDrop 'Me.AllowDrop MUST BE True!
        If TypeOf e.Data.GetData(DataFormats.FileDrop) Is String() Then
            For Each file As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                If System.Text.RegularExpressions.Regex.IsMatch(file, SUPPORTED_FILES_PATTERN, System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                    OpenFile(file)
                End If
            Next
        End If
    End Sub

    Private m_lastState As FormWindowState = FormWindowState.Normal
    Protected Overrides Sub OnResizeEnd(e As EventArgs)
        If Not m_isStarting Then
            If WindowState = FormWindowState.Normal Then
                App.Settings.WindowSize = Size
            End If
        End If
        MyBase.OnResizeEnd(e)
    End Sub

    Protected Overrides Sub OnClientSizeChanged(ByVal e As EventArgs)
        If WindowState <> m_lastState And Not m_isStarting Then
            m_lastState = WindowState
            OnWindowStateChanged()
        End If

        MyBase.OnClientSizeChanged(e)
    End Sub

    Private Sub OnWindowStateChanged()
        App.Settings.WindowState = WindowState
    End Sub

    Private m_closeFromException As Boolean = False
    Public Sub CloseException()
        m_closeFromException = True
        CloseEvent(True)
    End Sub

    Protected Overrides Sub OnClosing(e As CancelEventArgs)
        MyBase.OnClosing(e)
        If Not m_closeFromException Then
            e.Cancel = CloseEvent()
        End If
    End Sub

    Private Function CloseEvent(Optional ByVal exception As Boolean = False) As Boolean
        Dim cancel As Boolean = False
        For Each dockCon As DockContent In DockPan_Main.Contents
            If TypeOf dockCon Is TextEditor Then
                Dim editor As TextEditor = dockCon
                If Not editor.IsSave Then
                    CType(dockCon, DockContent).Show()
                End If
                If Not editor.CloseDocument(exception) Then
                    cancel = True
                    Exit For
                End If
            End If
        Next

        If Not cancel And Not exception Then
            If App.Settings.SaveSession Then
                For i As Integer = 0 To DockPan_Main.Contents.Count - 1
                    If i >= DockPan_Main.Contents.Count Then
                        Exit For
                    End If

                    If TypeOf DockPan_Main.Contents(i) Is TextEditor Then
                        If String.IsNullOrEmpty(CType(DockPan_Main.Contents(i), TextEditor).Path) Then
                            CType(DockPan_Main.Contents(i), TextEditor).IsSave = True
                            CType(DockPan_Main.Contents(i), DockContent).Close()
                            i -= 1
                        End If
                    End If
                Next
                DockPan_Main.SaveAsXml(LayoutFile)
            End If
        End If

        Return cancel And Not exception
    End Function
#End Region

    Private Property LastUserItem As IUserItem
        Get
            Return m_lastUserItem
        End Get
        Set(value As IUserItem)
            Dim currentEditor As TextEditor = Nothing
            If Not IsNothing(m_lastUserItem) Then
                m_lastUserItem.HasFocus = False
            End If

            m_lastUserItem = value
            If Not IsNothing(value) Then
                value.HasFocus = True
            End If


            If TypeOf value Is TextEditor Then
                currentEditor = value
            ElseIf TypeOf value Is FrameViewer Then
                currentEditor = CType(value, FrameViewer).TextEditor
            End If

            If Not IsNothing(currentEditor) Then
                Editor_TextChanged(currentEditor, currentEditor.GetTextLengthAndLineNumbers())
            Else
                TSSL_textLengthVal.Text = "-"
                TSSL_textLinesVal.Text = "-"
            End If

            'don't check on "null"
            App.UnusedIDs.TextEditor = currentEditor
            App.GoToWindow.TextEditor = currentEditor
            App.SearchWindow.TextEditor = currentEditor
            SetComboFrameList()
            SetSelectedComboItem()
        End Set
    End Property

    Private Sub SettingsChanged(ByVal sender As Object, ByVal e As Boolean)
        If sender.Equals(App.Settings) Or Not e Then
            For Each textEditor As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
                textEditor.ReloadStyle()
            Next
        End If
    End Sub

    Private Sub OpenFile(ByVal file As String)
        If IO.File.Exists(file) Then
            Dim loadFile As Boolean = True
            Dim conOwner As IDockContent = Nothing

            If Not App.Settings.MultipleOpening Then
                For Each con As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
                    conOwner = con
                    If con.Path.Equals(file) Then
                        con.Show()
                        loadFile = False
                        Exit For
                    End If
                Next
            End If

            If loadFile Then
                App.Settings.RecentFiles.Add(file)
                Dim editor As New TextEditor(file, True)
                editor.SetScintillasState(m_isActive)

                OpenTextEditor(editor, conOwner)
            End If
        End If
    End Sub

    Private Sub OpenTextEditor(ByVal textEditor As TextEditor, Optional ByVal dockParent As IDockContent = Nothing)
        If Not IsNothing(dockParent) Then
            textEditor.Show(CType(dockParent, DockContent).PanelPane, dockParent)
        Else
            textEditor.Show(DockPan_Main, DockState.Document)
        End If
        SetEditorEvents(textEditor)
    End Sub

#Region "Dock Panel"
    Private Sub Dockpan_main_AmountOfContentChanged(sender As Object, e As DockContentEventArgs) Handles DockPan_Main.ContentAdded, DockPan_Main.ContentRemoved
        Dim existsEditors As Boolean = DockPan_Main.Contents.OfType(Of TextEditor).Count > 0
        For Each item As ToolStripItem In m_toolStripItems
            item.Enabled = existsEditors
        Next

        If Not existsEditors Then
            LastUserItem = Nothing
        End If

        If m_isStarting Then Exit Sub
        CheckEXEFiles()
    End Sub

    Private Sub Dockpan_main_Removed(sender As Object, e As DockContentEventArgs) Handles DockPan_Main.ContentRemoved
        If m_isStarting Then Exit Sub
        App.ErrorList.CheckEditors(DockPan_Main.Contents.OfType(Of TextEditor).ToList)
    End Sub

    Private Sub Dockpan_main_ActiveContentChanged(sender As Object, e As EventArgs) Handles DockPan_Main.ActiveContentChanged
        If m_isStarting Then Exit Sub

        Dim yetActived As DockContent = DockPan_Main.ActiveContent
        If TypeOf yetActived Is IUserItem Then
            If Not IsNothing(m_lastUserItem) Then
                'If Not m_lastUserItem.Equals(yetActived) Then
                '    CType(yetActived, IUserItem).HasFocus = True
                'End If

                If CType(yetActived, IUserItem).ID = m_lastUserItem.ID Then
                    Exit Sub
                End If
            End If
        End If


        If Not IsNothing(yetActived) Then
            If TypeOf yetActived Is IUserItem Then
                LastUserItem = yetActived

                If App.Settings.AutoSwitchToFrameViewer Then
                    If TypeOf yetActived Is FrameViewer Then
                        Dim editor As TextEditor = CType(yetActived, FrameViewer).TextEditor
                        If Not IsNothing(editor) Then
                            If Not editor.Visible Then
                                editor.Show()
                                yetActived.Activate()
                            End If
                        End If
                    ElseIf TypeOf yetActived Is TextEditor Then
                        Dim editor As TextEditor = yetActived
                        If Not IsNothing(editor.Viewer) Then
                            'If Not m_firstOpen Then
                            '    ' If editor.Viewer.IsHidden Or Not editor.Viewer.Visible Then
                            '    editor.Viewer.Show()
                            '    yetActived.Activate()
                            '    ' End If
                            'ElseIf Opt_autoOpenViewer Then

                            'End If

                            If IsNothing(editor.Viewer.DockPanel) Or editor.Viewer.IsHidden Then
                                Dim foundOtherViewer As Boolean = False
                                For Each con As IDockContent In DockPan_Main.Contents
                                    If TypeOf con Is FrameViewer Then
                                        If Not CType(con, DockContent).IsHidden Then
                                            editor.Viewer.Show(CType(con, DockContent).PanelPane, con)
                                            foundOtherViewer = True
                                            Exit For
                                        End If
                                    End If
                                Next
                                If Not foundOtherViewer Then
                                    editor.Viewer.Show(DockPan_Main, DockState.Document)
                                End If
                            Else
                                editor.Viewer.Show()
                            End If

                            yetActived.Activate()

                        End If
                    End If
                End If

            End If
        End If
        If Not IsNothing(GetActiveTextEditor) Then
            TextEditor_UndoRedoStackChanged(GetActiveTextEditor, False)
            TextEditor_SaveStateChanged(GetActiveTextEditor, False)
        End If
    End Sub

    Private Function GetActiveTextEditor() As TextEditor
        If Not IsNothing(m_lastUserItem) Then
            Return GetTextEditorFromID(m_lastUserItem.ID)
        Else
            Dim yetActived As IDockContent = DockPan_Main.ActiveContent
            If Not IsNothing(yetActived) Then
                If TypeOf (yetActived) Is TextEditor Then
                    Return CType(yetActived, TextEditor)
                ElseIf TypeOf (yetActived) Is FrameViewer Then
                    Return CType(yetActived, FrameViewer).TextEditor
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Function GetTextEditorFromID(ByVal id As Integer) As TextEditor
        For Each editor As TextEditor In DockPan_Main.Documents.OfType(Of TextEditor)
            If editor.ID = id Then
                Return editor
            End If
        Next
        Return Nothing
    End Function
#End Region

#Region "Editor Events"
    Private Sub SetEditorEvents(ByVal textEditor As TextEditor)
        AddHandler textEditor.SaveStateChanged, AddressOf TextEditor_SaveStateChanged
        AddHandler textEditor.UndoRedoStackChanged, AddressOf TextEditor_UndoRedoStackChanged
        AddHandler textEditor.ChangeFrameViewerState, AddressOf Editor_ChangeFrameViewerState
        AddHandler textEditor.ChangeFrame, AddressOf Editor_ChangeFrame
        AddHandler textEditor.DragEnterEventOfEditor, AddressOf DragEnter_
        AddHandler textEditor.DropEventOfEditor, AddressOf DragDrop_
        AddHandler textEditor.DragOverEventOfEditor, AddressOf DragOver_

        AddHandler textEditor.TextChanged, AddressOf Editor_TextChanged
        AddHandler textEditor.ErrorsChecked, AddressOf Editor_ErrorsChecked
        AddHandler textEditor.UnusedIDsChecked, AddressOf Editor_UnusedIDsChecked
    End Sub

    Private Sub TextEditor_SaveStateChanged(ByVal sender As TextEditor, ByVal e As Boolean)
        If Not IsNothing(m_lastUserItem) AndAlso m_lastUserItem.ID = sender.ID Then
            TSMI_save.Enabled = Not sender.IsSave
            TSMI_icon_save.Enabled = TSMI_save.Enabled
        End If
    End Sub

    Private Sub TextEditor_UndoRedoStackChanged(ByVal sender As TextEditor, ByVal e As Boolean)
        If Not IsNothing(m_lastUserItem) AndAlso m_lastUserItem.ID = sender.ID Then
            TSMI_undo.Enabled = sender.CanUndo
            TSMI_icon_undo.Enabled = TSMI_undo.Enabled
            TSMI_redo.Enabled = sender.CanRedo
            TSMI_icon_redo.Enabled = TSMI_redo.Enabled
        End If
    End Sub

    Private Sub Editor_ChangeFrameViewerState(ByVal sender As FrameViewer, ByVal e As Boolean)
        TSMI_windows_CheckStateChanged(New ToolStripMenuItem With {.Tag = sender}, New EventArgs())
    End Sub

    Private Sub Editor_ChangeFrame(ByVal sender As TextEditor, ByVal e As TextFrame)
        If m_IWasThat Then Exit Sub

        If App.Settings.SyncFrameID Then
            m_IWasThat = True
            For Each editor As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
                If Not editor.Equals(sender) Then
                    editor.CurrentFrameID = sender.CurrentFrameID
                End If
            Next
            m_IWasThat = False
        End If

        If Not IsNothing(m_lastUserItem) AndAlso m_lastUserItem.ID = sender.ID Then
            SetSelectedComboItem()
        End If

        App.Settings.Restorer.SelectedID = sender.CurrentFrameID
    End Sub

    Private Sub Editor_TextChanged(ByVal sender As TextEditor, ByVal e As Point)
        If Not IsNothing(m_lastUserItem) AndAlso m_lastUserItem.ID = sender.ID Then
            TSSL_textLengthVal.Text = e.X.ToString("N0")
            TSSL_textLinesVal.Text = e.Y.ToString("N0")
        End If
    End Sub

    Private Sub Editor_ErrorsChecked(ByVal sender As Object, ByVal e As Boolean)
        App.ErrorList.SetErrors(sender)
    End Sub

    Private Sub Editor_UnusedIDsChecked(ByVal sender As TextEditor, ByVal e As Boolean)
        If Not IsNothing(m_lastUserItem) AndAlso m_lastUserItem.ID = sender.ID Then
            App.UnusedIDs.TextEditor = sender 'refresh the list

            SetComboFrameList()
        End If
    End Sub

    Private Sub SetSelectedComboItem()
        Dim sender As TextEditor = GetActiveTextEditor()
        If Not IsNothing(sender) Then
            Dim frameName As String = sender.GetCurrentFrameName
            If IsNothing(frameName) Then
                TSComb_frames.SelectedText = ""
            Else
                m_IWasThat = True
                For i As Integer = 0 To TSComb_frames.Items.Count - 1
                    If CType(TSComb_frames.Items(i), CustomComboBoxItem(Of Integer)).DisplayText.Equals(frameName) Then
                        TSComb_frames.SelectedIndex = i
                    End If
                Next
                m_IWasThat = False
            End If
        Else
            TSComb_frames.Items.Clear()
            TSComb_frames.Text = ""
        End If
    End Sub

    Private Sub SetComboFrameList()
        Dim sender As TextEditor = GetActiveTextEditor()
        If Not IsNothing(sender) Then
            Dim currentFrameName As String = sender.GetCurrentFrameName()
            Dim resetList As Boolean = TSComb_frames.Items.Count <> sender.Frames.Count

            If Not resetList Then
                Dim index As Integer = 0
                For Each item As CustomComboBoxItem(Of Integer) In TSComb_frames.Items
                    If sender.Frames.ContainsKey(item.DisplayText) Then
                        If Not sender.Frames(item.DisplayText) = item.Value Then
                            resetList = True
                            Exit For
                        End If
                    Else
                        resetList = True
                        Exit For
                    End If
                Next
            End If

            If resetList Then
                m_IWasThat = True
                TSComb_frames.Items.Clear()
                For Each entry As KeyValuePair(Of String, Integer) In sender.Frames
                    TSComb_frames.Items.Add(New CustomComboBoxItem(Of Integer)(entry.Key, entry.Value))
                    If entry.Key.Equals(currentFrameName) Then
                        TSComb_frames.SelectedIndex = TSComb_frames.Items.Count - 1
                    End If
                Next
                If TSComb_frames.SelectedIndex < 0 Then
                    SetSelectedComboItem()
                End If
                m_IWasThat = False
            End If
        Else
            TSComb_frames.Items.Clear()
            TSComb_frames.Text = ""
        End If
    End Sub
#End Region

#Region "ToolStripMenuItems"
#Region "File"
    Private Sub TSMI_file_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_file.DropDownOpening
        TSMI_recentFiles.DropDownItems.Clear()
        For Each file As String In App.Settings.RecentFiles
            Dim tsmi As New ToolStripMenuItem With {.Text = file}
            AddHandler tsmi.Click, New EventHandler(Sub()
                                                        OpenFile(file)
                                                    End Sub)
            TSMI_recentFiles.DropDownItems.Add(tsmi)
        Next
        TSMI_recentFiles.Enabled = App.Settings.RecentFiles.Count > 0
        TSMI_closeAll.Enabled = DockPan_Main.Contents.OfType(Of TextEditor).Count > 0
    End Sub

    Private Sub TSMI_new_Click(sender As Object, e As EventArgs) Handles TSMI_new.Click, TSMI_icon_new.Click
        Dim conOwner As IDockContent = Nothing
        For Each con As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
            conOwner = con
            Exit For
        Next
        OpenTextEditor(New TextEditor("", True), conOwner)
    End Sub

    Private Sub TSMI_open_Click(sender As Object, e As EventArgs) Handles TSMI_open.Click, TSMI_icon_open.Click
        If Ofd_Data.ShowDialog = DialogResult.OK Then
            For Each file As String In Ofd_Data.FileNames
                OpenFile(file)
            Next
        End If
    End Sub

    Private Sub TSMI_save_Click(sender As Object, e As EventArgs) Handles TSMI_save.Click, TSMI_icon_save.Click, TSMI_saveAs.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.Save(CType(sender, ToolStripItem).Name.EndsWith("As"))
        End If
    End Sub

    Private Sub TSMI_saveAll_Click(sender As Object, e As EventArgs) Handles TSMI_saveAll.Click, TSMI_icon_saveAll.Click
        For Each textEditor As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
            If Not textEditor.IsSave Then
                textEditor.Save()
            End If
        Next
    End Sub

    Private Sub TSMI_close_Click(sender As Object, e As EventArgs) Handles TSMI_close.Click, TSMI_icon_close.Click
        Dim yetActived As DockContent = DockPan_Main.ActiveContent
        If Not IsNothing(yetActived) Then
            If yetActived.HideOnClose Then
                yetActived.Hide()
            Else
                yetActived.Close()
            End If
        End If
    End Sub

    Private Sub TSMI_closeAll_Click(sender As Object, e As EventArgs) Handles TSMI_closeAll.Click
        Dim index As Integer = 0
        Do While index < DockPan_Main.Contents.Count
            Dim dockCon As DockContent = DockPan_Main.Contents(index)
            If TypeOf dockCon Is TextEditor Then
                Dim editor As TextEditor = dockCon
                If Not editor.CloseDocument() Then Exit Do
            End If

            If TypeOf dockCon Is TextEditor Or TypeOf dockCon Is FrameViewer Then
                dockCon.HideOnClose = False
                dockCon.Close()
            Else
                index += 1
            End If
        Loop

        DockPan_Main.ResumeLayout()
    End Sub

    Private Sub TSMI_export_Click(sender As Object, e As EventArgs) Handles TSMI_export.Click
        Using Sfd_HTML
            If Sfd_HTML.ShowDialog() = DialogResult.OK Then
                'Dim content As String = "<body style=""font-family'" & globalUser.opt_userFontFamily.ToString & "'; font-size:" & globalUser.opt_userFontSize.ToString("0.0", cultureEN) & ";"">"
                My.Computer.FileSystem.WriteAllText(Sfd_HTML.FileName, GetActiveTextEditor().ExportToHTML(), False)
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
            End If
        End Using
    End Sub

    Private Sub TSMI_quit_Click(sender As Object, e As EventArgs) Handles TSMI_quit.Click
        Me.Close()
    End Sub
#End Region
#Region "Edit"
    Private Sub TSMI_edit_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_edit.DropDownOpening
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            TSMI_cut.Enabled = editor.Scintilla1.SelectedText.Length > 0
            TSMI_copy.Enabled = editor.Scintilla1.SelectedText.Length > 0
            TSMI_delete.Enabled = editor.Scintilla1.SelectedText.Length > 0

            TSMI_paste.Enabled = editor.Scintilla1.CanPaste ' My.Computer.Clipboard.ContainsText
            TSMI_pasteCool.Enabled = editor.Scintilla1.CanPaste ' My.Computer.Clipboard.ContainsText

            TSMI_expand.Enabled = App.Settings.Folding
            TSMI_collapse.Enabled = App.Settings.Folding
        End If
    End Sub

    Private Sub TSMI_undo_Click(sender As Object, e As EventArgs) Handles TSMI_undo.Click, TSMI_icon_undo.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.Undo()
        End If
    End Sub

    Private Sub TSMI_redo_Click(sender As Object, e As EventArgs) Handles TSMI_redo.Click, TSMI_icon_redo.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.Redo()
        End If
    End Sub

    Private Sub TSMI_cut_Click(sender As Object, e As EventArgs) Handles TSMI_cut.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.Cut()
        End If
    End Sub

    Private Sub TSMI_copy_Click(sender As Object, e As EventArgs) Handles TSMI_copy.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.Copy()
        End If
    End Sub

    Private Sub TSMI_paste_Click(sender As Object, e As EventArgs) Handles TSMI_paste.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.Paste()
        End If
    End Sub

    Private Sub TSMI_pasteCool_Click(sender As Object, e As EventArgs) Handles TSMI_pasteCool.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.PasteCool()
        End If
    End Sub

    Private Sub TSMI_delete_Click(sender As Object, e As EventArgs) Handles TSMI_delete.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.Delete()
        End If
    End Sub

    Private Sub TSMI_selectAll_Click(sender As Object, e As EventArgs) Handles TSMI_selectAll.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.SelectAll()
        End If
    End Sub

    Private Sub TSMI_expand_Click(sender As Object, e As EventArgs) Handles TSMI_expand.Click, TSMI_collapse.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            If CType(sender, ToolStripMenuItem).Name.ToLower.EndsWith("expand") Then
                editor.ExpandFoldingAll()
            Else
                editor.CollapseFoldingAll()
            End If
        End If
    End Sub
#End Region
#Region "Search"
    Private Sub TSMI_search_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_search.DropDownOpening
        TSMI_bookmark.Enabled = App.Settings.Bookmarks
    End Sub

    Private Sub TSMI_find_Click(sender As Object, e As EventArgs) Handles TSMI_find.Click
        ShowSearchWindow(FindReplaceMark.EMode.Find)
    End Sub
    Private Sub TSMI_findAgain_Click(sender As Object, e As EventArgs) Handles TSMI_findAgain.Click
        App.SearchWindow.Find()
    End Sub
    Private Sub TSMI_findAgainReverse_Click(sender As Object, e As EventArgs) Handles TSMI_findAgainReverse.Click
        App.SearchWindow.FindReverse()
    End Sub


    Private Sub TSMI_replace_Click(sender As Object, e As EventArgs) Handles TSMI_replace.Click
        ShowSearchWindow(FindReplaceMark.EMode.Replace)
    End Sub
    Private Sub TSMI_replaceAgain_Click(sender As Object, e As EventArgs) Handles TSMI_replaceAgain.Click
        App.SearchWindow.Replace()
    End Sub
    Private Sub TSMI_replaceAgainReverse_Click(sender As Object, e As EventArgs) Handles TSMI_replaceAgainReverse.Click
        App.SearchWindow.ReplaceReverse()
    End Sub


    Private Sub TSMI_mark_Click(sender As Object, e As EventArgs) Handles TSMI_mark.Click
        ShowSearchWindow(FindReplaceMark.EMode.Mark)
    End Sub

    Private Sub ShowSearchWindow(ByVal mode As FindReplaceMark.EMode)
        Dim selText As String = Nothing
        Dim currentEditor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(currentEditor) Then
            selText = currentEditor.GetSelectedTextForSearchWindow()
        End If

        SearchWindow.SetMode(mode, selText)
        If Not SearchWindow.Visible Then
            SearchWindow.Show(Me)
        Else
            SearchWindow.Activate()
        End If
    End Sub

    Private Sub TSMI_goTo_Click(sender As Object, e As EventArgs) Handles TSMI_goTo.Click
        App.GoToWindow.Show(Me)
    End Sub

    Private Sub TSMI_goToLine_Click(sender As Object, e As EventArgs) Handles TSMI_goToLine.Click
        App.GoToWindow.Show(Me, True)
    End Sub

    Private Sub TSMI_goToFrame_Click(sender As Object, e As EventArgs) Handles TSMI_goToFrame.Click
        App.GoToWindow.Show(Me, False)
    End Sub

#Region "Bookmark"
    Private Sub TSMI_toggleBookmark_Click(sender As Object, e As EventArgs) Handles TSMI_toggleBookmark.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.SetOrDeleteBookmark()
        End If
    End Sub

    Private Sub TSMI_nextBookmark_Click(sender As Object, e As EventArgs) Handles TSMI_nextBookmark.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.GoToNextBookmark()
        End If
    End Sub

    Private Sub TSMI_previousBookmark_Click(sender As Object, e As EventArgs) Handles TSMI_previousBookmark.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.GoToPreviousBookmark()
        End If
    End Sub

    Private Sub TSMI_clearBookmarks_Click(sender As Object, e As EventArgs) Handles TSMI_clearBookmarks.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.ClearBookmarks()
        End If
    End Sub

    Private Sub TSMI_cutBookmarkedLines_Click(sender As Object, e As EventArgs) Handles TSMI_cutBookmarkedLines.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.CutBookmarkedLines()
        End If
    End Sub

    Private Sub TSMI_copyBookmarkedLines_Click(sender As Object, e As EventArgs) Handles TSMI_copyBookmarkedLines.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.CopyBookmarkedLines()
        End If
    End Sub

    Private Sub TSMI_pasteBookmarkedLines_Click(sender As Object, e As EventArgs) Handles TSMI_pasteBookmarkedLines.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.PasteToBookmarkedLines()
        End If
    End Sub

    Private Sub TSMI_removeBookmarkedLines_Click(sender As Object, e As EventArgs) Handles TSMI_removeBookmarkedLines.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.RemoveBookmarkedLines()
        End If
    End Sub

    Private Sub TSMI_removeUnmarkedLines_Click(sender As Object, e As EventArgs) Handles TSMI_removeUnmarkedLines.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.RemoveUnmarkedLines()
        End If
    End Sub

    Private Sub TSMI_inverseBookmark_Click(sender As Object, e As EventArgs) Handles TSMI_inverseBookmark.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.InvertBookmarks()
        End If
    End Sub
#End Region
#End Region
#Region "View"
    Private Sub TSMI_view_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_view.DropDownOpening
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            TSMI_lineNumbers.Checked = App.Settings.ShowLineNumbers
            TSMI_markLine.Checked = App.Settings.MarkCurrentLine
            TSMI_whitespaces.Checked = App.Settings.ShowWhitespaces

            Dim state As Integer = editor.Split
            TSMI_hSplit.Checked = state = Orientation.Vertical
            TSMI_vSplit.Checked = state = Orientation.Horizontal

            m_IWasThat = True
            TSComb_WrapMode.SelectedIndex = App.Settings.WrapMode
            m_IWasThat = False
        End If
    End Sub

    Private Sub TSMI_lineNumbers_Click(sender As Object, e As EventArgs) Handles TSMI_lineNumbers.Click
        App.Settings.ShowLineNumbers = TSMI_lineNumbers.Checked
    End Sub

    Private Sub TSMI_markLine_Click(sender As Object, e As EventArgs) Handles TSMI_markLine.Click
        App.Settings.MarkCurrentLine = TSMI_markLine.Checked
    End Sub

    Private Sub TSMI_whitespaces_Click(sender As Object, e As EventArgs) Handles TSMI_whitespaces.Click
        App.Settings.ShowWhitespaces = TSMI_whitespaces.Checked
    End Sub

    Private Sub TSMI_hSplit_Click(sender As Object, e As EventArgs) Handles TSMI_hSplit.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            If TSMI_hSplit.Checked Then
                editor.Split = Orientation.Vertical
            Else
                editor.Split = -1
            End If
        End If
    End Sub

    Private Sub TSMI_vSplit_Click(sender As Object, e As EventArgs) Handles TSMI_vSplit.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            If TSMI_vSplit.Checked Then
                editor.Split = Orientation.Horizontal
            Else
                editor.Split = -1
            End If
        End If
    End Sub

    Private Sub TSComb_wrapMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TSComb_WrapMode.SelectedIndexChanged
        If Not m_IWasThat Then
            App.Settings.WrapMode = TSComb_WrapMode.SelectedIndex
        End If
    End Sub
#End Region
#Region "Windows"
    Private Sub TSMI_window_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_windows.DropDownOpening
        TSMI_frameViewer.DropDownItems.Clear()

        'Dim 
        For Each editor As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
            If Not IsNothing(editor.Viewer) Then
                Dim TSMI As New ToolStripMenuItem With {.Checked = Not CType(editor.Viewer, DockContent).IsHidden}
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
                TSMI.Tag = editor.Viewer
                AddHandler TSMI.CheckStateChanged, AddressOf TSMI_windows_CheckStateChanged
                TSMI_frameViewer.DropDownItems.Add(TSMI)
            End If
        Next

        TSMI_frameViewer.Enabled = TSMI_frameViewer.DropDownItems.Count > 0
        TSMI_unusedIDs.Checked = Not App.UnusedIDs.IsHidden
        TSMI_errorList.Checked = Not App.ErrorList.IsHidden
    End Sub

    Private Sub TSMI_windows_CheckStateChanged(sender As ToolStripMenuItem, e As EventArgs) Handles TSMI_windows.CheckStateChanged
        If Not IsNothing(sender.Tag) Then
            If TypeOf sender.Tag Is FrameViewer Then
                Dim frameViewer As FrameViewer = sender.Tag
                If frameViewer.IsHidden Then
                    Dim dockcon As IDockContent = Nothing
                    Dim foundOtherViewer As Boolean = False
                    For Each con As IDockContent In DockPan_Main.Documents
                        If TypeOf con Is FrameViewer Then
                            dockcon = con
                            Exit For
                        End If
                    Next

                    If Not IsNothing(dockcon) Then
                        frameViewer.Show(CType(dockcon, DockContent).PanelPane, dockcon)
                    Else
                        Dim dockPane As DockPane = GetDockElement(DockState.Document)
                        If Not IsNothing(dockPane) Then
                            frameViewer.Show(dockPane, DockAlignment.Right, 0.5)
                        Else
                            frameViewer.Show(DockPan_Main, DockState.Document)
                        End If
                    End If
                Else
                    frameViewer.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub TSMI_unusedIDs_Click(sender As Object, e As EventArgs) Handles TSMI_unusedIDs.Click
        If App.UnusedIDs.IsHidden Then
            'Dim dockPane As DockPane = getDockElement(DockState.Document)
            'If Not IsNothing(dockPane) Then
            '    UnusedFrames.Show(dockPane, DockAlignment.Right, 0.5)
            'Else
            '    UnusedFrames.Show(dockpan_main, DockState.Document)
            'End If
            App.UnusedIDs.Show(DockPan_Main, DockState.Document)
        Else
            App.UnusedIDs.Hide()
        End If
    End Sub

    Private Sub TSMI_errorList_Click(sender As Object, e As EventArgs) Handles TSMI_errorList.Click
        If App.ErrorList.IsHidden Then
            App.ErrorList.Show(DockPan_Main, DockState.Document)
        Else
            App.ErrorList.Hide()
        End If
    End Sub

    Private Function GetDockElement(ByVal checkDock As DockState) As DockPane
        For Each dD As DockContent In DockPan_Main.Contents
            If dD.DockState = checkDock Then
                Return dD.Pane
            End If
        Next
        Return Nothing
    End Function
#End Region
#Region "Tools"
    Private Sub TSMI_tools_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_tools.DropDownOpening
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            TSMI_tagAdder.Enabled = editor.Scintilla1.SelectedText.Length > 5
            TSMI_IDChanger.Enabled = TSMI_tagAdder.Enabled
        Else
            TSMI_tagAdder.Enabled = False
            TSMI_IDChanger.Enabled = False
        End If
    End Sub

    Private Sub TSMI_framesReformatting_Click(sender As Object, e As EventArgs) Handles TSMI_framesReformatting.Click
        Dim editors As New List(Of TextEditor)
        Dim selected As Integer = -1
        If Not IsNothing(m_lastUserItem) Then selected = m_lastUserItem.ID

        For Each dockCon As IDockContent In DockPan_Main.Contents
            If TypeOf dockCon Is TextEditor Then
                editors.Add(dockCon)
            End If
        Next

        Dim frm As New FramesReformatting(editors, selected)
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub TSMI_mirrorFrame_Click(sender As Object, e As EventArgs) Handles TSMI_mirrorFrame.Click
        Dim test As DockContent = DockPan_Main.ActiveDocument
        If Not IsNothing(test) Then
            If TypeOf (test) Is FrameViewer Then
                CType(test, FrameViewer).Tool_mirrorFrame()
            ElseIf TypeOf test Is TextEditor Then
                CType(test, TextEditor).Viewer.Tool_mirrorFrame()
                CType(test, TextEditor).Viewer.Invalidate()
            End If
        End If
    End Sub

    Private Sub TSMI_tagAdder_Click(sender As Object, e As EventArgs) Handles TSMI_tagAdder.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            Dim frm As New TagAdder(editor)
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub TSMI_IDChanger_Click(sender As Object, e As EventArgs) Handles TSMI_IDChanger.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            Dim frm As New AutoIDChanger(editor)
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub TSMI_sort_Click(sender As Object, e As EventArgs) Handles TSMI_sort.Click
        Dim frm As New FrameSorter(DockPan_Main.Contents.OfType(Of TextEditor).ToList, If(Not IsNothing(m_lastUserItem), m_lastUserItem.ID, -1))
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub TSMI_equation_apply_Click(sender As Object, e As EventArgs) Handles TSMI_equation_apply.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            If editor.EquationAllFramesFrom(TSMI_equation_center.Checked,
                                            TSMI_equation_next.Checked,
                                            TSMI_equation_bodies.Checked,
                                            TSMI_equation_itrs.Checked,
                                            TSMI_equation_bpoi.Checked,
                                            TSMI_equation_cpoi.Checked,
                                            TSMI_equation_opoi.Checked,
                                            TSMI_equation_wpoi.Checked,
                                            TSMI_equation_hit.Checked,
                                            TSMI_equation_wait.Checked,
                                            TSMI_equation_state.Checked) Then
                TSMI_tools.DropDown.Close()
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        End If
    End Sub
#End Region
#Region "Hidden Tools"
    Private Sub TSMI_hT_frameViewer_Click(sender As Object, e As EventArgs) Handles TSMI_hT_frameViewer.Click
        Dim editor As TextEditor = GetActiveTextEditor()

        If Not IsNothing(editor) AndAlso Not IsNothing(editor.Viewer) Then
            TSMI_windows_CheckStateChanged(New ToolStripMenuItem With {.Tag = editor.Viewer}, e)
        End If
    End Sub

    Private Sub TSMI_hT_nextFrame_Click(sender As Object, e As EventArgs) Handles TSMI_hT_nextFrame.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.SetNextRealFrame()
        End If
    End Sub

    Private Sub TSMI_hT_previousFrame_Click(sender As Object, e As EventArgs) Handles TSMI_hT_previousFrame.Click
        Dim editor As TextEditor = GetActiveTextEditor()
        If Not IsNothing(editor) Then
            editor.SetPreviousRealFrame()
        End If
    End Sub
#End Region
#Region "MenuStrip Icons"
    Private Sub TSComb_lf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TSComb_lf.SelectedIndexChanged
        TSMI_run.Enabled = Not IsNothing(TSComb_lf.SelectedItem)
    End Sub

    Private Sub TSMI_run_MouseMove(sender As Object, e As MouseEventArgs) Handles TSMI_run.MouseMove
        TSMI_run.Select()
    End Sub

    Private Sub TSMI_run_Click(sender As Object, e As EventArgs) Handles TSMI_run.Click
        If TypeOf TSComb_lf.SelectedItem Is CustomComboBoxItem(Of String) Then
            Dim exeFile As String = CType(TSComb_lf.SelectedItem, CustomComboBoxItem(Of String)).Value
            If IO.File.Exists(exeFile) Then
                Dim lfP As New Process
                lfP.StartInfo.FileName = exeFile
                lfP.StartInfo.Domain = exeFile
                lfP.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(exeFile)
                lfP.Start()
            End If
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        End If
    End Sub

    Private Sub CheckEXEFiles()
        Dim exeFiles As New HashSet(Of String)
        Dim lastEXE As String = ""
        If TypeOf TSComb_lf.SelectedItem Is CustomComboBoxItem(Of String) Then
            lastEXE = CType(TSComb_lf.SelectedItem, CustomComboBoxItem(Of String)).Value.Clone()
        End If

        For Each editor As TextEditor In DockPan_Main.Contents.OfType(Of TextEditor)
            For Each exeFile As String In GetEXE(editor.Path)
                exeFiles.Add(exeFile)
            Next
        Next

        TSComb_lf.Items.Clear()
        For Each exeFile As String In exeFiles
            Dim comboItem As New CustomComboBoxItem(Of String)(GetEXEFileDisplayPath(exeFile), exeFile)
            TSComb_lf.Items.Add(comboItem)
            If comboItem.Value.Equals(lastEXE) Then
                TSComb_lf.SelectedIndex = TSComb_lf.Items.Count - 1
            End If
        Next

        If TSComb_lf.Items.Count = 0 Then
            TSMI_run.Enabled = False
        Else
            TSMI_run.Enabled = Not IsNothing(TSComb_lf.SelectedItem)
        End If
    End Sub

    Private Function GetEXEFileDisplayPath(ByVal path As String) As String
        Dim maxLen As Integer = 30
        If path.Length > maxLen Then
            Dim result As String = path.Substring(path.Length - maxLen, maxLen)
            Return "..." & result
        End If
        Return path
    End Function
#End Region

    Private Sub TSMI_settings_Click(sender As Object, e As EventArgs) Handles TSMI_settings.Click
        Dim frm As New SettingsF()
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub TSMI_about_Click(sender As Object, e As EventArgs) Handles TSMI_about.Click
        Dim frm As New About
        frm.ShowDialog()
        frm.Dispose()
    End Sub
#End Region

#Region "Editor Stuff (change something etc)"
    Private m_IWasThat As Boolean = False
    Private Sub TSComb_frames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TSComb_frames.SelectedIndexChanged
        If Not m_IWasThat Then
            If TypeOf TSComb_frames.SelectedItem Is CustomComboBoxItem(Of Integer) Then
                Dim editor As TextEditor = GetActiveTextEditor()
                If Not IsNothing(editor) Then
                    m_IWasThat = True
                    editor.GoToLine(CType(TSComb_frames.SelectedItem, CustomComboBoxItem(Of Integer)).Value)
                    editor.Activate()
                    m_IWasThat = False
                    Exit Sub
                End If
            End If

            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        End If
    End Sub
#End Region

    Public Sub ChangeLanguages(ByVal e As IO.FileSystemEventArgs)
        Me.BeginInvoke(Sub()
                           Dim exception As Boolean = False
                           If e.ChangeType = IO.WatcherChangeTypes.Renamed Then
                               For i As Integer = 1 To Translation.Languages.Count - 1
                                   If Translation.Languages(i).FileName.Equals(CType(e, IO.RenamedEventArgs).OldName) Then
                                       Translation.Languages(i).FileName = e.Name
                                       If Translation.SelectedLanguage = i Then
                                           App.Settings.Language = Translation.Languages(i).FileName
                                       End If
                                       Exit For
                                   End If
                               Next
                               'Translation.Languages.Add(Translation.)
                           ElseIf e.ChangeType = IO.WatcherChangeTypes.Deleted Then
                               Dim oldLangID As Integer = Translation.SelectedLanguage
                               Dim removedID As Integer = Integer.MaxValue
                               For i As Integer = 1 To Translation.Languages.Count - 1
                                   If Translation.Languages(i).FileName.Equals(e.Name) Then
                                       Translation.Languages.Remove(Translation.Languages(i))
                                       removedID = i
                                       Exit For
                                   End If
                               Next

                               If oldLangID >= removedID Then
                                   Translation.SelectedLanguage -= 1
                                   For Each settings As SettingsF In Translation.TranslatableForms.OfType(Of SettingsF)
                                       settings.SetOldLanguageNew()
                                   Next
                                   App.Settings.Language = Translation.Languages(Translation.SelectedLanguage).FileName
                               End If



                           ElseIf e.ChangeType = IO.WatcherChangeTypes.Changed Then
                               For i As Integer = 1 To Translation.Languages.Count - 1
                                   If Translation.Languages(i).FileName.Equals(e.Name) Then
                                       Translation.Languages(i).Reload()

                                       If i = Translation.SelectedLanguage Then
                                           For Each translatableForm As Translation.ITranslatable In Translation.TranslatableForms
                                               translatableForm.Translate(Translation.Languages(i))
                                           Next
                                       End If
                                       Exit For
                                   End If
                               Next


                           ElseIf e.ChangeType = IO.WatcherChangeTypes.Created Then
                               Try
                                   Translation.Languages.Add(New Translation.Language(e.FullPath))
                               Catch ex As Exception
                                   exception = True
                               End Try
                           End If


                           If Not exception AndAlso Not e.ChangeType = IO.WatcherChangeTypes.Renamed Then
                               For Each ucGeneral As UC_General In Translation.TranslatableForms.OfType(Of UC_General)
                                   ucGeneral.RefreshLanguages()
                               Next
                           End If
                       End Sub)
    End Sub

    Private Sub Link_Cookiesoft_Click(sender As Object, e As EventArgs) Handles Link_Cookiesoft.Click
        Process.Start("http://cookiesoft.lui-studio.net/")
    End Sub

    Private Sub TSMI_doERRORS_Click(sender As Object, e As EventArgs) Handles DEBUG_DO_ERRORS.Click
        'For Each dockCon As DockContent In DockPan_Main.Documents
        '    If TypeOf dockCon Is FrameViewer Then
        '        Console.WriteLine(CType(dockCon, FrameViewer).Path)
        '        dockCon.BringToFront()
        '    End If
        'Next

        For i As Integer = 0 To 10
            Throw New Exception
            Threading.Thread.Sleep(250)
        Next
    End Sub

    Private Sub TSMI_toggleBSprite_Click(sender As Object, e As EventArgs) Handles TSMI_toggleBSprite.Click
        GetActiveTextEditor()?.Viewer?.ToggleBSpriteOption()
    End Sub
End Class