Imports System.Text.RegularExpressions
Imports ICSharpCode

'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class ui_id_changer
    Private m_editor As AvalonEdit.TextEditor = Nothing

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
        Text &= " (" & fileName & ")"
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_apply_Click(sender As Object, e As EventArgs) Handles btn_apply.Click
        If Not IsNothing(m_editor) Then
            Dim editorClone As New AvalonEdit.TextEditor
            editorClone.Text = m_editor.SelectedText

            Dim frames As MatchCollection = Regex.Matches(m_editor.SelectedText, "\<frame\>.*?\<frame_end\>", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Multiline)
            Dim index As Integer = nud_index.Value
            If rb_set.Checked Then
                index += frames.Count - 1
            End If
            For k As Integer = frames.Count - 1 To 0 Step -1
                Dim frame As Match = frames(k)
                If frame.Success Then
                    Dim frameID As Integer = getRegexValueInteger(frame.Value, "(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase)
                    If frameID >= 0 And frameID < 399 Then
                        If rb_add.Checked Then
                            frameID += index
                        Else
                            frameID = index
                        End If

                        If frameID < 0 Then
                            frameID = 0
                        End If
                        Dim rgx As New Regex("(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase)
                        editorClone.Text = rgx.Replace(editorClone.Text, frameID.ToString, 1, frame.Index)
                    End If


                    Dim nextVal As Integer = getRegexValueInteger(frame.Value, "(?<=next:\s*)[-0-9]+", RegexOptions.IgnoreCase)
                    If nextVal > -399 And nextVal < 399 Then
                        If rb_add.Checked Then
                            If nextVal < 0 Then
                                nextVal -= index
                            Else
                                nextVal += index
                            End If
                        Else
                            If nextVal < 0 Then
                                nextVal = index - 1
                            Else
                                nextVal = index + 1
                            End If
                        End If
                        Dim rgx As New Regex("(?<=next:\s*)[-0-9]+", RegexOptions.IgnoreCase)
                        editorClone.Text = rgx.Replace(editorClone.Text, nextVal.ToString, 1, frame.Index)
                    End If


                    If cb_pic.Checked Then
                        Dim picID As Integer = getRegexValueInteger(frame.Value, "(?<=pic:\s*)[0-9]+", RegexOptions.IgnoreCase)
                        If picID >= 0 Then
                            If rb_add.Checked Then
                                picID += index
                            Else
                                picID = index
                            End If

                            If picID < 0 Then
                                picID = 0
                            End If
                            Dim rgx As New Regex("(?<=pic:\s*)[0-9]+", RegexOptions.IgnoreCase)
                            editorClone.Text = rgx.Replace(editorClone.Text, picID.ToString, 1, frame.Index)
                        End If
                    End If


                    If cb_hit.Checked Then
                        Dim hites As MatchCollection = Regex.Matches(frame.Value, "hit_[A-Za-z]+:\s*[-0-9]+", RegexOptions.IgnoreCase)
                        For i As Integer = hites.Count - 1 To 0 Step -1
                            Dim hit As Match = hites(i)
                            If hit.Success Then
                                Dim hitVal As Integer = getRegexValueInteger(hit.Value, "(?<=hit_[A-Za-z]+:\s*)[-0-9]+", RegexOptions.IgnoreCase, -400)
                                Dim hitName As String = getRegexValue(hit.Value, "hit_[A-Za-z]+:", RegexOptions.IgnoreCase)
                                If hitVal > -399 And hitVal < 399 And Not hitVal = 0 And Not IsNothing(hitName) Then
                                    If rb_add.Checked Then
                                        If hitVal < 0 Then
                                            hitVal -= index
                                        Else
                                            hitVal += index
                                        End If
                                    Else
                                        hitVal = index
                                    End If
                                    Dim rgx As New Regex("(?<=" & hitName & "\s*)[-0-9]+", RegexOptions.IgnoreCase)
                                    editorClone.Text = rgx.Replace(editorClone.Text, hitVal.ToString, 1, frame.Index)
                                End If
                            End If
                        Next
                    End If


                    If rb_set.Checked Then
                        index -= 1
                    End If
                End If
            Next

            m_editor.SelectedText = editorClone.Text
        End If
    End Sub
End Class