'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class UnusedIDs
    Private m_editor As TextEditor = Nothing

    Private Class ListViewItemComparer
        Implements IComparer

        Public Reverse As Boolean = False

        Public Function Compare(ByVal xx As Object, ByVal yy As Object) As Integer Implements IComparer.Compare
            Dim x As UnusedIDItem = CType(xx, ListViewItem).Tag
            Dim y As UnusedIDItem = CType(yy, ListViewItem).Tag

            Dim returnVal As Integer = CType(x.ID, Integer).CompareTo(CType(y.ID, Integer))

            If Reverse Then
                returnVal *= -1
            End If
            Return returnVal
        End Function
    End Class

    Public Sub New()
        InitializeComponent()
        Lv_unused.ListViewItemSorter = New ListViewItemComparer()
    End Sub

    Public Property TextEditor As TextEditor
        Get
            Return m_editor
        End Get
        Set(value As TextEditor)
            m_editor = value
            If IsNothing(value) Then
                Lv_unused.Items.Clear()
            Else
                SetList(value)
            End If
        End Set
    End Property

    Private Sub SetList(ByVal textEditor As TextEditor)
        Dim checkIndex As Integer = 0
        Dim newIDs As New List(Of UnusedIDItem)
        newIDs.AddRange(textEditor.UnusedIDs) 'clone
        Do While checkIndex < Lv_unused.Items.Count
            Dim found As Boolean = False
            Dim itemObj As UnusedIDItem = Lv_unused.Items(checkIndex).Tag

            For Each unusedItem As UnusedIDItem In newIDs
                If unusedItem.Equals(itemObj) Then
                    found = True
                    newIDs.Remove(unusedItem)
                    Exit For
                End If
            Next

            If Not found Then
                Lv_unused.Items.RemoveAt(checkIndex)
            Else
                checkIndex += 1
            End If
        Loop

        For Each unusedItem As UnusedIDItem In newIDs
            Dim text As String = unusedItem.ID.ToString
            If unusedItem.Range > 1 Then
                text &= "-" & (unusedItem.ID + unusedItem.Range - 1).ToString
            End If
            Lv_unused.Items.Add(New ListViewItem With {.Text = text, .Tag = unusedItem.Clone})
        Next
    End Sub

    Private Sub Lv_unused_DoubleClick(sender As ListView, e As EventArgs) Handles Lv_unused.DoubleClick
        If sender.SelectedItems.Count > 0 Then
            If Not IsNothing(m_editor) Then
                If TypeOf sender.SelectedItems(0).Tag Is UnusedIDItem Then
                    m_editor.GoToLine(CType(sender.SelectedItems(0).Tag, UnusedIDItem).Line)
                    m_editor.Show()
                    m_editor.Activate()
                    Exit Sub
                End If
            End If
        End If

        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
    End Sub

    Private Sub Lv_unused_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles Lv_unused.ColumnClick
        CType(sender.ListViewItemSorter, ListViewItemComparer).Reverse = Not CType(sender.ListViewItemSorter, ListViewItemComparer).Reverse
        sender.Sort()
    End Sub
End Class