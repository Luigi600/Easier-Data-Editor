'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class GoToWindow
    Private m_updating As Boolean = True
    Private m_editor As TextEditor = Nothing

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatablePrefix = AppTitle
        NotTranslatableControls.AddRange({Lbl_currentValue, Lbl_maximumValue})
    End Sub

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
        SetValues()
    End Sub

    Public Overloads Sub Show(ByVal owner As IWin32Window, ByVal stateLine As Boolean)
        MyBase.Show(owner)
        Rb_line.Checked = stateLine
        Rb_frame.Checked = Not stateLine
    End Sub

    Public Property TextEditor As TextEditor
        Get
            Return m_editor
        End Get
        Set(value As TextEditor)
            m_editor = value
            SetValues()
        End Set
    End Property

    Private Sub SetValues()
        If Not IsNothing(m_editor) Then
            Lbl_currentValue.Text = m_editor.GetCurrentLineNumber() + 1
            Lbl_maximumValue.Text = m_editor.GetCountOfLineNumbers()
        End If
    End Sub

    Private Sub Rb_line_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_line.CheckedChanged, Rb_frame.CheckedChanged
        If Rb_line.Checked Then
            If Nud_val.Value < 1 Then
                Nud_val.Value = 1
                Nud_val.Minimum = 1
            End If
        End If

        Lbl_current.Visible = Rb_line.Checked
        Lbl_currentValue.Visible = Rb_line.Checked
        Lbl_maximum.Visible = Rb_line.Checked
        Lbl_maximumValue.Visible = Rb_line.Checked
    End Sub

    Private Sub Nud_val_KeyDown(sender As Object, e As KeyEventArgs) Handles Nud_val.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            Btn_goo_Click(Nothing, New EventArgs)
        End If
    End Sub

    Private Sub Btn_goo_Click(sender As Object, e As EventArgs) Handles Btn_goo.Click
        If Not IsNothing(m_editor) Then
            If Rb_line.Checked Then
                m_editor.GoToLine(Nud_val.Value)
                Me.Close()
            Else
                If m_editor.GoToFrame(Nud_val.Value) Then
                    Me.Close()
                Else
                    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                End If
            End If
        End If
    End Sub

    Private Sub Btn_cancel_Click(sender As Object, e As EventArgs) Handles Btn_cancel.Click
        Me.Close()
    End Sub

    Private Sub GoToWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub
End Class