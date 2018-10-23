'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class ui_settings
    Delegate Sub ChangeView()

    Private m_function As ChangeView = Nothing

    Public Sub New(ByVal para As ChangeView)
        InitializeComponent()

        m_function = para

        If globalUser.opt_recentMax < 0 Then
            globalUser.opt_recentMax = 0
        ElseIf globalUser.opt_recentMax > 50 Then
            globalUser.opt_recentMax = 50
        End If
        nud_maxRecentFiles.Value = globalUser.opt_recentMax

        cb_saveSession.Checked = globalUser.opt_saveSession
        txt_fontFamily.Text = globalUser.opt_userFontFamily.ToString

        If globalUser.opt_userFontSize < 5 Then
            globalUser.opt_userFontSize = 5
        ElseIf globalUser.opt_userFontSize > 50 Then
            globalUser.opt_userFontSize = 50
        End If
        nud_fontSize.Value = globalUser.opt_userFontSize
        cb_maximized.Checked = (globalUser.windowState = FormWindowState.Maximized)
        cb_autocomplete.Checked = globalUser.opt_autocomplete
        cb_folding.Checked = globalUser.opt_folding

        cb_ms.Checked = globalUser.opt_showMS
        pal_bg_color.BackColor = globalUser.opt_defaultBackgroundColor
        cb_allow_double.Checked = globalUser.opt_doubleOpening
        cb_directResult.Checked = globalUser.opt_directResult

        cb_globalSettings.Checked = globalUser.isGlobalSettingsEnable
        cb_auto_viewer.Checked = globalUser.opt_autoOpenViewer
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub btn_selectFont_Click(sender As Object, e As EventArgs) Handles btn_selectFont.Click
        fd_editor.Font = New Font(globalUser.opt_userFontFamily.ToString, globalUser.opt_userFontSize)
        If fd_editor.ShowDialog = DialogResult.OK Then
            txt_fontFamily.Text = fd_editor.Font.Name
        End If
    End Sub

    Private Sub btn_select_color_Click(sender As Object, e As EventArgs) Handles btn_select_color.Click
        cd_default.Color = globalUser.opt_defaultBackgroundColor
        If cd_default.ShowDialog = DialogResult.OK Then
            pal_bg_color.BackColor = cd_default.Color
        End If
    End Sub


    Private Sub btn_abort_Click(sender As Object, e As EventArgs) Handles btn_abort.Click
        Me.Close()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        globalUser.opt_recentMax = nud_maxRecentFiles.Value
        globalUser.opt_saveSession = cb_saveSession.Checked
        globalUser.opt_userFontFamily = New System.Windows.Media.FontFamily(txt_fontFamily.Text)
        globalUser.opt_userFontSize = nud_fontSize.Value
        globalUser.opt_doubleOpening = cb_allow_double.Checked

        If cb_maximized.Checked Then
            globalUser.windowState = FormWindowState.Maximized
        Else
            globalUser.windowState = FormWindowState.Normal
        End If

        globalUser.opt_showMS = cb_ms.Checked
        globalUser.opt_defaultBackgroundColor = pal_bg_color.BackColor
        globalUser.opt_directResult = cb_directResult.Checked

        globalUser.isGlobalSettingsEnable = cb_globalSettings.Checked
        globalUser.opt_autocomplete = cb_autocomplete.Checked
        globalUser.opt_folding = cb_folding.Checked
        globalUser.opt_autoOpenViewer = cb_auto_viewer.Checked


        saveSettings()

        If Not IsNothing(m_function) Then
            m_function()
        End If
        Me.Close()
    End Sub
End Class