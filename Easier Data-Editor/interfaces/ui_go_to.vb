Imports System.Text.RegularExpressions

Public Class ui_go_to
    Private m_updating As Boolean = True
    Private m_editor As ICSharpCode.AvalonEdit.TextEditor = Nothing

    Public Sub New(ByVal editor As ICSharpCode.AvalonEdit.TextEditor)
        InitializeComponent()

        m_editor = editor

        rb_frame.Checked = Not LastGoToWasLine
        rb_line.Checked = LastGoToWasLine
        nud_val.Maximum = If(editor.Document.LineCount > 399, editor.Document.LineCount, 399)
        nud_val.Select(0, nud_val.Value.ToString.Length)
        m_updating = False
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub rb_line_CheckedChanged(sender As Object, e As EventArgs) Handles rb_line.CheckedChanged, rb_frame.CheckedChanged
        If Not m_updating Then
            LastGoToWasLine = rb_line.Checked
        End If
    End Sub

    Private Sub nud_val_KeyDown(sender As Object, e As KeyEventArgs) Handles nud_val.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            btn_goo_Click(Nothing, New EventArgs)
        End If
    End Sub

    Private Sub btn_goo_Click(sender As Object, e As EventArgs) Handles btn_goo.Click
        If rb_line.Checked Then
            Dim val As Integer = nud_val.Value
            If val < 0 Then
                val = 1
            ElseIf val > m_editor.Document.LineCount Then
                val = m_editor.Document.LineCount
            End If
            m_editor.ScrollToLine(val)
            Me.Close()
        Else
            Dim mtch As Match = Regex.Match(m_editor.Text, "<frame>\s+(" & nud_val.Value & "$|" & nud_val.Value & "\s+)", RegexOptions.IgnoreCase)
            If mtch.Success Then
                m_editor.SelectionLength = 0
                m_editor.SelectionStart = mtch.Index
                m_editor.SelectionLength = mtch.Length
                m_editor.ScrollToLine(m_editor.Document.GetLineByOffset(mtch.Index).LineNumber)
                Me.Close()
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        End If
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub
End Class