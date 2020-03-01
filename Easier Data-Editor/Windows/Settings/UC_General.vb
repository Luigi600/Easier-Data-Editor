'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.IO
Imports Easier_Data_Editor.Translation

<System.ComponentModel.ToolboxItem(False)>
Public Class UC_General
    Private settings As Settings = Nothing
    Private m_updating As Boolean = True

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatableControls.AddRange({Comb_lang, Comb_newline})
    End Sub

    Public Sub New(ByRef settings As Settings)
        Me.settings = settings
        InitializeComponent()

        If IO.Directory.Exists(LanguageDirectory) Then
            For Each file As String In IO.Directory.GetFiles(LanguageDirectory).Where(Function(x) IO.Path.GetExtension(x).ToLower.Equals(".xml")).ToList
                Try
                    Languages.Add(New Language(file))
                Catch ex As Exception
                End Try
            Next
        End If

        Nud_recentFiles.Value = settings.RecentFilesCapacity
        Cb_saveSession.Checked = settings.SaveSession
        Cb_multipleOpening.Checked = settings.MultipleOpening
        CheckBox3.Checked = settings.AutoSwitchToFrameViewer
        Comb_newline.SelectedIndex = settings.NewlineCharacter - 1

        RefreshLanguages()
        Comb_lang.SelectedIndex = SelectedLanguage

        m_updating = False
    End Sub

    Private Sub Comb_lang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Comb_lang.SelectedIndexChanged
        If Not m_updating Then
            SelectedLanguage = Comb_lang.SelectedIndex
            settings.Language = Languages(SelectedLanguage).FileName
        End If
    End Sub

    Private Sub Btn_langDir_Click(sender As Object, e As EventArgs) Handles Btn_langDir.Click
        If Not IO.Directory.Exists(LanguageDirectory) Then
            IO.Directory.CreateDirectory(LanguageDirectory)
            My.Application.SetLanguageCheckerEvents()
        End If

        Process.Start(LanguageDirectory)
    End Sub

    Private Sub Nud_recentFiles_ValueChanged(sender As Object, e As EventArgs) Handles Nud_recentFiles.ValueChanged
        If Not m_updating Then
            settings.RecentFilesCapacity = Nud_recentFiles.Value
        End If
    End Sub

    Private Sub Cb_saveSession_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_saveSession.CheckedChanged
        If Not m_updating Then
            settings.SaveSession = Cb_saveSession.Checked
        End If
    End Sub

    Private Sub Cb_multipleOpening_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_multipleOpening.CheckedChanged
        If Not m_updating Then
            settings.MultipleOpening = Cb_multipleOpening.Checked
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If Not m_updating Then
            settings.AutoSwitchToFrameViewer = CheckBox3.Checked
        End If
    End Sub

    Private Sub Comb_newline_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Comb_newline.SelectedIndexChanged
        If Not m_updating Then
            settings.NewlineCharacter = (Comb_newline.SelectedIndex + 1)
        End If
    End Sub

    Public Sub RefreshLanguages()
        Dim oldFile As String = "?"
        m_updating = True

        If Not IsNothing(Comb_lang.SelectedItem) Then
            oldFile = CType(Comb_lang.SelectedItem, Language).FileName
        End If
        Comb_lang.Items.Clear()
        For Each lang As Language In Languages
            Comb_lang.Items.Add(lang)
            If lang.FileName.Equals(oldFile) Then
                m_updating = False
                Comb_lang.SelectedIndex = Comb_lang.Items.Count - 1
                m_updating = True
            End If
        Next

        If Comb_lang.SelectedIndex < 0 And Comb_lang.Items.Count > 0 Then
            Comb_lang.SelectedIndex = 0
        End If
        settings.Language = App.Settings.Language
        m_updating = False
    End Sub
End Class