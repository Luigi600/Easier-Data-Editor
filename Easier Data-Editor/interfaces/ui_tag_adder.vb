Imports System.Text.RegularExpressions
Imports System.Windows.Forms.Integration
Imports ICSharpCode

'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class ui_tag_adder

    Private m_editor As AvalonEdit.TextEditor = Nothing
    Private m_input As New AvalonEdit.TextEditor With {.SyntaxHighlighting = syntaxHighlighting}

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub New(ByVal editor As AvalonEdit.TextEditor, ByVal fileName As String)
        InitializeComponent()

        m_editor = editor
        gb_input.Text &= " (" & fileName & ")"

        Dim host2 As New ElementHost With {.Dock = DockStyle.Fill}
        m_input.FontFamily = opt_userFontFamily
        m_input.FontSize = opt_userFontSize
        m_input.ShowLineNumbers = True
        host2.Child = m_input
        gb_input.Controls.Add(host2)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_apply_Click(sender As Object, e As EventArgs) Handles btn_apply.Click
        If Not IsNothing(m_editor) Then
            Dim editorClone As New AvalonEdit.TextEditor
            editorClone.Text = m_editor.SelectedText
            Dim frames As MatchCollection = Regex.Matches(editorClone.Text, "\S*<frame_end>", RegexOptions.IgnoreCase)
            For i As Integer = frames.Count - 1 To 0 Step -1
                If frames(i).Success Then
                    editorClone.SelectionLength = 0
                    editorClone.SelectionStart = frames(i).Index
                    editorClone.SelectionLength = frames(i).Length
                    editorClone.SelectedText = m_input.Text & vbNewLine & frames(i).Value
                End If
            Next

            m_editor.SelectedText = editorClone.Text
        End If
    End Sub
End Class