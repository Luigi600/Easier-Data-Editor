'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class FrameSorter
    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatablePrefix = AppTitle
    End Sub

    Public Sub New(ByVal editors As List(Of TextEditor), ByVal selectedID As Integer)
        InitializeComponent()

        For Each editor As TextEditor In editors
            Dim lvItem As New ListViewItem With {.Text = editor.Text, .Tag = editor}
            lvItem.SubItems.Add(editor.Path)

            If editor.ID = selectedID Then
                lvItem.Checked = True
            End If

            Lv_files.Items.Add(lvItem)
        Next
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

    Private Sub Btn_doIt_Click(sender As Object, e As EventArgs) Handles Btn_doIt.Click
        For Each lvItem As ListViewItem In Lv_files.CheckedItems
            If TypeOf lvItem.Tag Is TextEditor Then
                CType(lvItem.Tag, TextEditor).SortFrames()
            End If
        Next
    End Sub

    Private Sub Lv_files_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles Lv_files.ItemChecked
        Btn_doIt.Enabled = Lv_files.CheckedItems.Count > 0
    End Sub
End Class