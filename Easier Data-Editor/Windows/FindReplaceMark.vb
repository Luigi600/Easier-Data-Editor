'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class FindReplaceMark
    Private Shared ReadOnly COLOR_INFORMATION As Color = Color.Green
    Private Shared ReadOnly COLOR_RESULT As Color = Color.DodgerBlue
    Private Shared ReadOnly COLOR_FAILED As Color = Color.Red

    Public TextEditor As TextEditor = Nothing
    Private m_updating As Boolean = True

    Public Enum EMode As Byte
        Find
        Replace
        FindInFiles
        Mark
    End Enum

    Public Sub Prepare()
        TabC_mode_SelectedIndexChanged(TabC_mode, New EventArgs())
        Cb_transparency_CheckedChanged(Cb_transparency, New EventArgs())

        Cb_case.Checked = App.Settings.SearchSettings.MatchCase
        Cb_wholeWord.Checked = App.Settings.SearchSettings.MatchCase
        Cb_wholeWord.Enabled = Not App.Settings.SearchSettings.SearchMode = ESearchMode.Regex
        Cb_wrapAround.Checked = App.Settings.SearchSettings.WrapAround
        Cb_selections.Checked = App.Settings.SearchSettings.InSelections

        Rb_search_normal.Checked = App.Settings.SearchSettings.SearchMode = ESearchMode.Normal
        Rb_search_regex.Checked = Not Rb_search_normal.Checked

        Cb_transparency.Checked = Not App.Settings.SearchSettings.TransparencyState = ETransparency.None
        Rb_trans_always.Checked = App.Settings.SearchSettings.TransparencyState = ETransparency.Always
        Rb_trans_losing.Checked = App.Settings.SearchSettings.TransparencyState = ETransparency.LosingFocus

        Cb_subfolders.Checked = App.Settings.SearchSettings.InSubfolders
        Cb_hiddenFolders.Checked = App.Settings.SearchSettings.InHiddenFolders

        Cb_bookmark.Checked = App.Settings.SearchSettings.BookmarkLine
        Cb_clearBookmarks.Checked = App.Settings.SearchSettings.Purge
        SetOpacity()

        TabC_mode.TabPages.RemoveAt(EMode.FindInFiles)

        AddHandler App.Settings.SearchSettings.FindList.ItemAdded, AddressOf Refresh_FindList
        AddHandler App.Settings.SearchSettings.FindList.ItemRemoved, AddressOf Refresh_FindList

        AddHandler App.Settings.SearchSettings.ReplaceList.ItemAdded, AddressOf Refresh_ReplaceList
        AddHandler App.Settings.SearchSettings.ReplaceList.ItemRemoved, AddressOf Refresh_ReplaceList

        Refresh_FindList(Me, Nothing)
        Refresh_ReplaceList(Me, Nothing)
        m_updating = False
    End Sub

    Public Sub New()
        Variables.Add("COUNT", "Count: [VAL] matches.")
        Variables.Add("COUNT_SINGLE", "Count: [VAL] match.")
        Variables.Add("NOT_FOUND", "Find: Can't find the text ""[VAL]"".")
        Variables.Add("FIND_AROUND_TOP", "Find: Found the 1st occurrence from the top. The end of the document has been reached.")
        Variables.Add("FIND_AROUND_BOTTOM", "Find: Found the 1st occurrence from the bottom. The beginning of the document has been reached.")
        Variables.Add("REPLACE_ALL", "Replace All: [VAL] occurrences were replaced.")
        Variables.Add("REPLACE_ALL_SINGLE", "Replace All: [VAL] occurrence was replaced.")

        Variables.Add("REPLACED", "Replace: 1 occurrence was replaced. The next occurence found.")
        Variables.Add("REPLACED_SINGLE", "Replace: 1 occurrence was replaced. The next occurence not found.")
        Variables.Add("REPLACED_FAILED", "Replace: no occurrence was found.")
        Variables.Add("REPLACE_AROUND_TOP", "Replace: Replaced the 1st occurrence from the bottom. The end of the document has been reached.")
        Variables.Add("REPLACE_AROUND_BOTTOM", "Replace: Replaced the 1st occurrence from the top. The begin of the document has been reached.")

        Variables.Add("MARK", "Count: [VAL] matches.")
        Variables.Add("MARK_SINGLE", "Count: [VAL] match.")

        InitializeComponent()
    End Sub

#Region "Overrides Functions & Own Events"
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Sub OnActivated(e As EventArgs)
        MyBase.OnActivated(e)
        Try
            If App.Settings.SearchSettings.TransparencyState = ETransparency.LosingFocus Then
                Opacity = 1.0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub OnDeactivate(e As EventArgs)
        MyBase.OnDeactivate(e)
        Try
            If App.Settings.SearchSettings.TransparencyState = ETransparency.LosingFocus Then
                Opacity = App.Settings.SearchSettings.Opacity / 100
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormClosing_(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            SS_info.Items.Clear()
            Me.Hide()
        End If
    End Sub

    Private Sub FindReplaceHighlighting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Comb_find.Focus()
    End Sub
#End Region

    Public Sub SetMode(ByVal mode As EMode, ByVal selectedText As String)
        If mode >= EMode.FindInFiles Then
            mode -= 1 'coz "Find in Files" is in progress
        End If
        If mode < TabC_mode.TabPages.Count Then
            TabC_mode.SelectedIndex = mode
        End If

        If Not String.IsNullOrEmpty(selectedText) Then
            Comb_find.Text = selectedText
        End If

        Comb_find.Focus()
    End Sub

    Private Sub Refresh_FindList(ByVal sender As Object, ByVal e As String)
        Comb_find.Items.Clear()
        For Each item As String In App.Settings.SearchSettings.FindList
            Comb_find.Items.Add(item)
        Next
    End Sub

    Private Sub Refresh_ReplaceList(ByVal sender As Object, ByVal e As String)
        Comb_replace.Items.Clear()
        For Each item As String In App.Settings.SearchSettings.ReplaceList
            Comb_replace.Items.Add(item)
        Next
    End Sub

    Private Sub TabC_mode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabC_mode.SelectedIndexChanged
        If Not IsNothing(TabC_mode.SelectedTab) Then
            Dim showReplaceStuff As Boolean = Not TabC_mode.SelectedTab.Equals(Tabp_find) And Not TabC_mode.SelectedTab.Equals(Tabp_mark)
            Lbl_replace.Visible = showReplaceStuff
            Comb_replace.Visible = showReplaceStuff

            Cb_wrapAround.Visible = Not TabC_mode.SelectedTab.Equals(Tabp_findInFiles)
            Text = TabC_mode.SelectedTab.Text
        End If
    End Sub

    Private Sub Btn_close_Click(sender As Object, e As EventArgs) Handles Btn_close.Click, Btn_close_1.Click, Btn_close_2.Click, Btn_close_3.Click
        Me.Close()
    End Sub

#Region "Settings"
    Private Sub Cb_transparency_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_transparency.CheckedChanged
        Gb_transparency.Enabled = Cb_transparency.Checked

        If Not m_updating Then
            If Cb_transparency.Checked Then
                App.Settings.SearchSettings.TransparencyState = If(Rb_trans_always.Checked, ETransparency.Always, ETransparency.LosingFocus)
            Else
                App.Settings.SearchSettings.TransparencyState = ETransparency.None
            End If
            SetOpacity()
        End If
    End Sub

    Private Sub Rb_trans_losing_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_trans_losing.CheckedChanged, Rb_trans_always.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.TransparencyState = If(Rb_trans_always.Checked, ETransparency.Always, ETransparency.LosingFocus)
            SetOpacity()
        End If
    End Sub

    Private Sub Trackb_transparency_Scroll(sender As Object, e As EventArgs) Handles Trackb_transparency.Scroll
        If Not m_updating Then
            App.Settings.SearchSettings.Opacity = Trackb_transparency.Value
            SetOpacity()
        End If
    End Sub

    Private Sub SetOpacity()
        If App.Settings.SearchSettings.TransparencyState = ETransparency.None Or App.Settings.SearchSettings.TransparencyState = ETransparency.LosingFocus Then
            Opacity = 1.0
        Else
            Opacity = App.Settings.SearchSettings.Opacity / 100
        End If
    End Sub

    Private Sub Cb_wholeWord_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_wholeWord.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.MatchWholeWord = Cb_wholeWord.Checked
        End If
    End Sub

    Private Sub Cb_case_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_case.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.MatchCase = Cb_case.Checked
        End If
    End Sub

    Private Sub Cb_wrapAround_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_wrapAround.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.WrapAround = Cb_wrapAround.Checked
        End If
    End Sub

    Private Sub Cb_selections_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_selections.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.InSelections = Cb_selections.Checked
        End If
    End Sub

    Private Sub Rb_search_normal_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_search_normal.CheckedChanged, Rb_search_regex.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.SearchMode = If(Rb_search_normal.Checked, ESearchMode.Normal, ESearchMode.Regex)
            Cb_wholeWord.Enabled = Not App.Settings.SearchSettings.SearchMode = ESearchMode.Regex
        End If
    End Sub

    Private Sub Cb_subfolders_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_subfolders.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.InSubfolders = Cb_subfolders.Checked
        End If
    End Sub

    Private Sub Cb_hiddenFolders_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_hiddenFolders.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.InHiddenFolders = Cb_hiddenFolders.Checked
        End If
    End Sub

    Private Sub Cb_bookmark_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_bookmark.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.BookmarkLine = Cb_bookmark.Checked
        End If
    End Sub

    Private Sub Cb_clearBookmarks_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_clearBookmarks.CheckedChanged
        If Not m_updating Then
            App.Settings.SearchSettings.Purge = Cb_clearBookmarks.Checked
        End If
    End Sub
#End Region

    Private Sub ClickOnButton(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_find_reverse.Click, Btn_find.Click, Btn_count.Click, Btn_close.Click,
                Btn_find_reverse_1.Click, Btn_find_1.Click, Btn_replace.Click, Btn_replaceAll.Click, Btn_close_1.Click,
                Btn_searchInFiles.Click, Btn_replaceInFiles.Click, Btn_close_2.Click,
                Btn_mark.Click, Btn_clearMarks.Click, Btn_close_3.Click

        SS_info.Items.Clear()
    End Sub

    Private Sub AddSearchTextToHistory(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_find_reverse.Click, Btn_find.Click, Btn_count.Click,
                Btn_find_reverse_1.Click, Btn_find_1.Click, Btn_replace.Click, Btn_replaceAll.Click,
                Btn_searchInFiles.Click, Btn_replaceInFiles.Click,
                Btn_mark.Click

        If Not String.IsNullOrEmpty(Comb_find.Text) Then
            App.Settings.SearchSettings.FindList.Add(Comb_find.Text)
        End If
    End Sub

    Private Sub AddReplaceTextToHistory(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_replace.Click, Btn_replaceAll.Click, Btn_replaceInFiles.Click
        If Not String.IsNullOrEmpty(Comb_replace.Text) Then
            App.Settings.SearchSettings.ReplaceList.Add(Comb_replace.Text)
        End If
    End Sub

    Private Sub Comb_find_KeyDown(sender As Object, e As KeyEventArgs) Handles Comb_find.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            Find()
        End If
    End Sub

    Private Sub Comb_replace_KeyDown(sender As Object, e As KeyEventArgs) Handles Comb_replace.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            ClickOnButton(Me, Nothing)
            Btn_replace_Click(Me, Nothing)
        End If
    End Sub

#Region "Tab - Find"
    Private Sub Btn_find_reverse_Click(sender As Object, e As EventArgs) Handles Btn_find_reverse.Click, Btn_find_reverse_1.Click
        If Not IsNothing(TextEditor) Then
            Dim oldPos As Integer = TextEditor.GetCurrentPosition

            If TextEditor.FindReverse(Comb_find.Text) Then
                If TextEditor.GetCurrentPosition >= oldPos Then
                    SS_info.Items.Add(New ToolStripStatusLabel With {
                        .Text = GetVariable("FIND_AROUND_BOTTOM"),
                        .ForeColor = COLOR_INFORMATION
                    })
                End If
            Else
                FindUnsuccessful()
            End If
        End If
    End Sub

    Private Sub Btn_find_Click(sender As Object, e As EventArgs) Handles Btn_find.Click, Btn_find_1.Click
        If Not IsNothing(TextEditor) Then
            Dim oldPos As Integer = TextEditor.GetCurrentPosition

            If TextEditor.Find(Comb_find.Text) Then
                If TextEditor.GetCurrentPosition <= oldPos Then
                    SS_info.Items.Add(New ToolStripStatusLabel With {
                        .Text = GetVariable("FIND_AROUND_TOP"),
                        .ForeColor = COLOR_INFORMATION
                    })
                End If
            Else
                FindUnsuccessful()
            End If
        End If
    End Sub

    Private Sub Btn_count_Click(sender As Object, e As EventArgs) Handles Btn_count.Click
        If Not IsNothing(TextEditor) Then
            Dim count As Integer = TextEditor.Count(Comb_find.Text)
            Dim text As String = If(count = 1, GetVariable("COUNT_SINGLE"), GetVariable("COUNT"))
            SS_info.Items.Add(New ToolStripStatusLabel With {
                .Text = text.Replace("[VAL]", count),
                .ForeColor = COLOR_RESULT
            })
        End If
    End Sub

    Private Sub FindUnsuccessful()
        SS_info.Items.Add(New ToolStripStatusLabel With {
            .Text = GetVariable("NOT_FOUND").Replace("[VAL]", Comb_find.Text),
            .ForeColor = COLOR_FAILED
        })

        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
    End Sub
#End Region

#Region "Tab - Replace"
    Private Shared m_reverse As Boolean = False
    Private Sub Btn_replaceFind_Click(sender As Object, e As EventArgs) Handles Btn_find_1.Click
        m_reverse = False
    End Sub

    Private Sub Btn_replaceFindReverse_Click(sender As Object, e As EventArgs) Handles Btn_find_reverse_1.Click
        m_reverse = True
    End Sub

    Private Sub Btn_replace_Click(sender As Object, e As EventArgs) Handles Btn_replace.Click
        If Not IsNothing(TextEditor) Then
            Dim result As Integer = -1
            Dim oldPos As Integer = TextEditor.GetCurrentPosition

            If Not m_reverse Then
                result = TextEditor.Replace(Comb_find.Text, Comb_replace.Text)
            Else
                result = TextEditor.ReplaceReverse(Comb_find.Text, Comb_replace.Text)
            End If

            If result > 0 And Not m_reverse And TextEditor.GetCurrentPosition < oldPos Then
                SS_info.Items.Add(New ToolStripStatusLabel With {
                    .Text = GetVariable("REPLACE_AROUND_TOP"),
                    .ForeColor = COLOR_INFORMATION
                })
            ElseIf result > 0 And m_reverse And TextEditor.GetCurrentPosition > oldPos Then
                SS_info.Items.Add(New ToolStripStatusLabel With {
                    .Text = GetVariable("REPLACE_AROUND_BOTTOM"),
                    .ForeColor = COLOR_INFORMATION
                })
            Else
                If result < 0 Then
                    SS_info.Items.Add(New ToolStripStatusLabel With {
                        .Text = GetVariable("REPLACED_FAILED"),
                        .ForeColor = COLOR_FAILED
                    })

                    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                ElseIf result = 1 Then
                    SS_info.Items.Add(New ToolStripStatusLabel With {
                        .Text = GetVariable("REPLACED_SINGLE"),
                        .ForeColor = COLOR_RESULT
                    })
                ElseIf result > 1 Then
                    SS_info.Items.Add(New ToolStripStatusLabel With {
                        .Text = GetVariable("REPLACED"),
                        .ForeColor = COLOR_RESULT
                    })

                    'ignore 0
                End If
            End If
        End If
    End Sub

    Private Sub Btn_replaceAll_Click(sender As Object, e As EventArgs) Handles Btn_replaceAll.Click
        If Not IsNothing(TextEditor) Then
            Dim count As Integer = TextEditor.ReplaceAll(Comb_find.Text, Comb_replace.Text)
            Dim text As String = If(count = 1, GetVariable("REPLACE_ALL_SINGLE"), GetVariable("REPLACE_ALL"))
            SS_info.Items.Add(New ToolStripStatusLabel With {
                .Text = text.Replace("[VAL]", count),
                .ForeColor = Color.DodgerBlue
            })
        End If
    End Sub
#End Region

#Region "Tab - Mark"
    Private Sub Btn_mark_Click(sender As Object, e As EventArgs) Handles Btn_mark.Click
        If Not IsNothing(TextEditor) Then
            Dim count As Integer = TextEditor.Mark(Comb_find.Text)
            Dim text As String = If(count = 1, GetVariable("MARK_SINGLE"), GetVariable("MARK"))
            SS_info.Items.Add(New ToolStripStatusLabel With {
                .Text = text.Replace("[VAL]", count),
                .ForeColor = COLOR_RESULT
            })
        End If
    End Sub

    Private Sub Btn_clearMarks_Click(sender As Object, e As EventArgs) Handles Btn_clearMarks.Click
        If Not IsNothing(TextEditor) Then
            TextEditor.MarkClear()
        End If
    End Sub
#End Region

#Region "Public Actions"
    Public Sub Find()
        ClickOnButton(Me, Nothing)
        Btn_find_Click(Me, Nothing)
        AddSearchTextToHistory(Me, Nothing)
    End Sub

    Public Sub FindReverse()
        ClickOnButton(Me, Nothing)
        Btn_find_reverse_Click(Me, Nothing)
        AddSearchTextToHistory(Me, Nothing)
    End Sub

    Public Sub Replace()
        m_reverse = False
        ClickOnButton(Me, Nothing)
        Btn_replace_Click(Me, Nothing)
        AddReplaceTextToHistory(Me, Nothing)
    End Sub

    Public Sub ReplaceReverse()
        m_reverse = True
        ClickOnButton(Me, Nothing)
        Btn_replace_Click(Me, Nothing)
        AddReplaceTextToHistory(Me, Nothing)
    End Sub
#End Region
End Class