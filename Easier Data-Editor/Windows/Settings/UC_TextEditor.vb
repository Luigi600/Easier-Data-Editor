'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

<System.ComponentModel.ToolboxItem(False)>
Public Class UC_TextEditor
    Private settings As Settings = Nothing
    Private m_updating As Boolean = True

    Public Sub New(ByRef settings As Settings)
        Me.settings = settings
        InitializeComponent()

        Txt_fontFamily.Text = settings.FontFamily
        Nud_fontSize.Value = settings.FontSize
        Cb_lineNumbers.Checked = settings.ShowLineNumbers
        Cb_whitespaces.Checked = settings.ShowWhitespaces
        Cb_markCurrentLine.Checked = settings.MarkCurrentLine
        Pic_currentLine.BackColor = settings.MarkLineColor

        For Each val As String In [Enum].GetNames(GetType(ScintillaNET.WrapMode))
            Comb_wrapMode.Items.Add(val)
        Next
        Comb_wrapMode.SelectedIndex = settings.WrapMode

        Cb_autocompletion.Checked = settings.Autocompletion
        Cb_folding.Checked = settings.Folding
        Cb_subfolding.Checked = settings.Subfolding
        Cb_bookmarks.Checked = settings.Bookmarks
        Cb_changeBar.Checked = settings.ShowChanges
        Cb_scrollbarAnnotations.Checked = settings.ScrollbarAnnotations
        Cb_syncID.Checked = settings.SyncFrameID
        Cb_autoJumpBySyncID.Checked = settings.AutoJumpBySyncID
        Cb_indention.Checked = settings.Indention

        m_updating = False
    End Sub

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatableControls.AddRange({Txt_fontFamily, Comb_wrapMode})
    End Sub

    Private Sub Txt_fontFamily_TextChanged(sender As Object, e As EventArgs) Handles Txt_fontFamily.TextChanged
        If Not m_updating Then
            settings.FontFamily = Txt_fontFamily.Text
        End If
    End Sub

    Private Sub Nud_fontSize_ValueChanged(sender As Object, e As EventArgs) Handles Nud_fontSize.ValueChanged
        If Not m_updating Then
            settings.FontSize = Nud_fontSize.Value
        End If
    End Sub

    Private Sub Btn_changeFontFamily_Click(sender As Object, e As EventArgs) Handles Btn_changeFontFamily.Click
        FD_fontFamily.Font = New Font("", CSng(settings.FontSize), FontStyle.Regular)
        If FD_fontFamily.ShowDialog() = DialogResult.OK Then
            Txt_fontFamily.Text = FD_fontFamily.Font.Name
            Nud_fontSize.Value = CInt(FD_fontFamily.Font.Size)
        End If
    End Sub

    Private Sub Cb_lineNumbers_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_lineNumbers.CheckedChanged
        If Not m_updating Then
            settings.ShowLineNumbers = Cb_lineNumbers.Checked
        End If
    End Sub

    Private Sub Cb_whitespaces_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_whitespaces.CheckedChanged
        If Not m_updating Then
            settings.ShowWhitespaces = Cb_whitespaces.Checked
        End If
    End Sub

    Private Sub Cb_markCurrentLine_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_markCurrentLine.CheckedChanged
        If Not m_updating Then
            settings.MarkCurrentLine = Cb_markCurrentLine.Checked
        End If
    End Sub

    Private Sub Pic_currentLine_BackColorChanged(sender As Object, e As EventArgs) Handles Pic_currentLine.BackColorChanged
        If Not m_updating Then
            settings.MarkLineColor = Pic_currentLine.BackColor
        End If
    End Sub

    Private Sub Btn_changeLineColor_Click(sender As Object, e As EventArgs) Handles Btn_changeLineColor.Click
        CD_lineColor.Color = Pic_currentLine.BackColor
        If CD_lineColor.ShowDialog() = DialogResult.OK Then
            Pic_currentLine.BackColor = CD_lineColor.Color
        End If
    End Sub

    Private Sub Comb_wrapMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Comb_wrapMode.SelectedIndexChanged
        If Not m_updating Then
            settings.WrapMode = Comb_wrapMode.SelectedIndex
        End If
    End Sub

    Private Sub Cb_autocompletion_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_autocompletion.CheckedChanged
        If Not m_updating Then
            settings.Autocompletion = Cb_autocompletion.Checked
        End If
    End Sub

    Private Sub Cb_folding_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_folding.CheckedChanged
        If Not m_updating Then
            settings.Folding = Cb_folding.Checked
        End If

        Lbl_subfolding.Enabled = Cb_folding.Checked
        Cb_subfolding.Enabled = Cb_folding.Checked
    End Sub

    Private Sub Cb_subfolding_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_subfolding.CheckedChanged
        If Not m_updating Then
            settings.Subfolding = Cb_subfolding.Checked
        End If
    End Sub

    Private Sub Cb_bookmarks_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_bookmarks.CheckedChanged
        If Not m_updating Then
            settings.Bookmarks = Cb_bookmarks.Checked
        End If
    End Sub

    Private Sub Cb_changeBar_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_changeBar.CheckedChanged
        If Not m_updating Then
            settings.ShowChanges = Cb_changeBar.Checked
        End If
    End Sub

    Private Sub Cb_scrollbarAnnotations_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_scrollbarAnnotations.CheckedChanged
        If Not m_updating Then
            settings.ScrollbarAnnotations = Cb_scrollbarAnnotations.Checked
        End If
    End Sub

    Private Sub Cb_syncID_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_syncID.CheckedChanged
        If Not m_updating Then
            settings.SyncFrameID = Cb_syncID.Checked
        End If

        Lbl_autoJumpBySyncID.Enabled = Cb_syncID.Checked
        Cb_autoJumpBySyncID.Enabled = Cb_syncID.Checked
    End Sub

    Private Sub Cb_indention_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_indention.CheckedChanged
        If Not m_updating Then
            settings.Indention = Cb_indention.Checked
        End If
    End Sub

    Private Sub Cb_autoJumpBySyncID_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_autoJumpBySyncID.CheckedChanged
        If Not m_updating Then
            settings.AutoJumpBySyncID = Cb_autoJumpBySyncID.Checked
        End If
    End Sub
End Class