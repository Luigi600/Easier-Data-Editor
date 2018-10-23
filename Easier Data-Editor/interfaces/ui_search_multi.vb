'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class ui_search_multi
    Private m_updating As Boolean = True
    Private m_arrow_bottom As Bitmap = Nothing
    Private m_arrow_top As Bitmap = Nothing
    Public Sub New()
        InitializeComponent()

        m_arrow_bottom = My.Resources.arrow_bottom

        Dim newBitmap As Bitmap = My.Resources.arrow_bottom
        newBitmap.RotateFlip(RotateFlipType.Rotate180FlipX)
        m_arrow_top = newBitmap

        Showing()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub Showing()
        m_updating = True
        If Not IsNothing(SearchClass) Then
            txt_find.Text = SearchClass.searchWord
            txt_replace.Text = SearchClass.replaceWord

            rb_file_beginning.Checked = SearchClass.FileBeginning
            rb_cursor.Checked = Not SearchClass.FileBeginning

            rb_forward.Checked = SearchClass.Forward
            rb_backward.Checked = Not SearchClass.Forward

            cb_match_case.Checked = SearchClass.MatchCase
            cb_matchwholeword.Checked = SearchClass.MatchWholeWord

            lbl_replace.Visible = SearchClass.ReverseIsOpen
            txt_replace.Visible = SearchClass.ReverseIsOpen
            btn_replace.Visible = SearchClass.ReverseIsOpen
            btn_replace_all.Visible = SearchClass.ReverseIsOpen
        End If
        m_updating = False
    End Sub

    Private Sub ui_search_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            Opacity = 1.0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ui_search_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Opacity = 0.3
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lbl_find_MouseClick(sender As Object, e As MouseEventArgs) Handles lbl_find.MouseClick, lbl_find.MouseDoubleClick
        SearchClass.ReverseIsOpen = Not SearchClass.ReverseIsOpen 'lol i think i mean "Replace"....
        lbl_replace.Visible = SearchClass.ReverseIsOpen
        txt_replace.Visible = SearchClass.ReverseIsOpen
        btn_replace.Visible = SearchClass.ReverseIsOpen
        btn_replace_all.Visible = SearchClass.ReverseIsOpen
        Me.Refresh()
    End Sub

    Private Sub txt_find_TextChanged(sender As Object, e As EventArgs) Handles txt_find.TextChanged
        If Not m_updating And Not IsNothing(SearchClass) Then
            SearchClass.searchWord = txt_find.Text
        End If
    End Sub

    Private Sub txt_replace_TextChanged(sender As Object, e As EventArgs) Handles txt_replace.TextChanged
        If Not m_updating And Not IsNothing(SearchClass) Then
            SearchClass.replaceWord = txt_replace.Text
        End If
    End Sub

    Private Sub txt_replace_VisibleChanged(sender As Object, e As EventArgs) Handles txt_replace.VisibleChanged
        If txt_replace.Visible Then
            If Not IsNothing(m_arrow_top) Then lbl_find.Image = m_arrow_top
        Else
            If Not IsNothing(m_arrow_bottom) Then lbl_find.Image = m_arrow_bottom
        End If
    End Sub

    Private Sub rb_file_beginning_CheckedChanged(sender As Object, e As EventArgs) Handles rb_file_beginning.CheckedChanged
        If Not m_updating And Not IsNothing(SearchClass) Then
            SearchClass.LastSearchItem.LastOffset = 0
            SearchClass.FileBeginning = rb_file_beginning.Checked
        End If
    End Sub

    Private Sub rb_forward_CheckedChanged(sender As Object, e As EventArgs) Handles rb_forward.CheckedChanged, rb_backward.CheckedChanged
        If Not m_updating And Not IsNothing(SearchClass) Then
            SearchClass.Forward = rb_forward.Checked
        End If
    End Sub

    Private Sub cb_match_case_CheckedChanged(sender As Object, e As EventArgs) Handles cb_match_case.CheckedChanged
        If Not m_updating And Not IsNothing(SearchClass) Then
            SearchClass.MatchCase = cb_match_case.Checked
        End If
    End Sub

    Private Sub cb_matchwholeword_CheckedChanged(sender As Object, e As EventArgs) Handles cb_matchwholeword.CheckedChanged
        If Not m_updating And Not IsNothing(SearchClass) Then
            SearchClass.MatchWholeWord = cb_matchwholeword.Checked
        End If
    End Sub

    Private Sub btn_find_Click(sender As Control, e As EventArgs) Handles btn_find_reverse.Click, btn_find.Click
        If Not IsNothing(SearchClass) Then
            SearchClass.Find(sender.Name.EndsWith("reverse"))
        End If
    End Sub

    Private Sub btn_replace_Click(sender As Object, e As EventArgs) Handles btn_replace.Click
        If Not IsNothing(SearchClass) Then
            SearchClass.Replace()
        End If
    End Sub

    Private Sub btn_replace_all_Click(sender As Object, e As EventArgs) Handles btn_replace_all.Click
        If Not IsNothing(SearchClass) Then
            SearchClass.ReplaceAll()
        End If
    End Sub

    Private Sub txt_find_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_find.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not IsNothing(SearchClass) Then
                SearchClass.Find()
            End If
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ui_search_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        Else
            If Not IsNothing(lbl_find.Image) Then
                lbl_find.Image.Dispose()
                lbl_find.Image = Nothing
            End If
            If Not IsNothing(m_arrow_top) Then
                m_arrow_top.Dispose()
                m_arrow_top = Nothing
            End If
            If Not IsNothing(m_arrow_bottom) Then
                m_arrow_bottom.Dispose()
                m_arrow_bottom = Nothing
            End If
        End If
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Hide()
    End Sub

    Private Sub btn_find_Click(sender As Object, e As EventArgs) Handles btn_find_reverse.Click, btn_find.Click

    End Sub
End Class