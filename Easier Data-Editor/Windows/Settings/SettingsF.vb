'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class SettingsF
    Private m_save As Boolean = True
    Private WithEvents Settings As Settings = App.Settings.Clone
    Private m_pages As New List(Of UserControl)
    Private oldLanguage As Integer = Translation.SelectedLanguage

    Public Sub New()
        Variables.Add("SAVE_TITLE", "Easier Data-Editor    -   Save Settings?")
        Variables.Add("SAVE", "Do you want save the settings?")

        InitializeComponent()
        m_pages.AddRange({New UC_General(Settings), New UC_TextEditor(Settings), New UC_FrameViewer(Settings)})

        For Each page As UserControl In m_pages
            page.Dock = DockStyle.Fill
        Next

        TreeV_settings.Nodes(0).Expand()
        Settings_SettingsChanged(Settings, True)
    End Sub

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatablePrefix = AppTitle
    End Sub

    Public Sub SetOldLanguageNew()
        oldLanguage = Translation.SelectedLanguage
    End Sub

    Private Sub SettingsF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not m_save Then
            Dim buttonResult As DialogResult = MessageBox.Show(GetVariable("SAVE"), GetVariable("SAVE_TITLE"), MessageBoxButtons.YesNoCancel)
            If buttonResult = DialogResult.Cancel Then
                e.Cancel = True
            ElseIf buttonResult = DialogResult.No Then
                CancelSettings()
            Else
                SaveSettings()
            End If
        End If
    End Sub

    Private Sub Settings_SettingsChanged(sender As Object, e As Boolean) Handles Settings.SettingsChanged
        m_save = Settings.Equals(App.Settings)
        Btn_apply.Enabled = Not m_save
    End Sub

    Private Sub TreeV_settings_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeV_settings.AfterSelect
        If e.Node.Index < m_pages.Count Then
            Pal_settingPage.Controls.Clear()
            Pal_settingPage.Controls.Add(m_pages(e.Node.Index))
        End If
    End Sub

    Private Sub Btn_reset_Click(sender As Object, e As EventArgs) Handles Btn_reset.Click
        Settings.ApplyFrom(New Settings(False))
        Settings_SettingsChanged(Settings, False)
    End Sub

    Private Sub Btn_cancel_Click(sender As Object, e As EventArgs) Handles Btn_cancel.Click
        CancelSettings()
        Me.Close()
    End Sub

    Private Sub Btn_save_Click(sender As Object, e As EventArgs) Handles Btn_save.Click
        SaveSettings()
        Me.Close()
    End Sub

    Private Sub Btn_apply_Click(sender As Object, e As EventArgs) Handles Btn_apply.Click
        SaveSettings()
    End Sub

    Private Sub CancelSettings()
        m_save = True
        If Not Translation.SelectedLanguage = oldLanguage Then
            Translation.SelectedLanguage = oldLanguage
        End If
    End Sub

    Private Sub SaveSettings()
        App.Settings.ApplyFrom(Settings)
        App.Settings.Save()
        Settings_SettingsChanged(App.Settings, True)
        oldLanguage = Translation.SelectedLanguage
    End Sub

    Private Sub OwnDispose()
        For Each page As UserControl In m_pages
            Try
                page.Dispose()
            Catch ex As Exception
            End Try
        Next
    End Sub
End Class