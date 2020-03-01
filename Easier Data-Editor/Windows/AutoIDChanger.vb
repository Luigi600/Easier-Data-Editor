'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class AutoIDChanger
    Private m_editor As TextEditor = Nothing

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatablePrefix = AppTitle
    End Sub

    Public Sub New(ByVal editor As TextEditor)
        InitializeComponent()

        m_editor = editor
        Text = GetTranslatableHeader() & " (" & IO.Path.GetFileName(editor.Path) & ")"
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Btn_close_Click(sender As Object, e As EventArgs) Handles Btn_close.Click
        Me.Close()
    End Sub

    Private Sub Btn_apply_Click(sender As Object, e As EventArgs) Handles Btn_apply.Click
        If Not IsNothing(m_editor) Then
            m_editor.IncreaseIDs(Nud_index.Value, Rb_set.Checked, Cb_hit.Checked, Cb_pic.Checked)
        End If
    End Sub
End Class