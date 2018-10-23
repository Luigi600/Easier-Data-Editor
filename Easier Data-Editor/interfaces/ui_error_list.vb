'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class ui_error_list
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private m_editor As ITextEditor = Nothing
    Private m_oldList As New List(Of ErrorItem)
    Public Sub New()
        InitializeComponent()

        lv_errors.ListViewItemSorter = New class_ListViewItemComparer(0) With {.reverse = False}
    End Sub

    Public Sub ClearList()
        m_editor = Nothing
        m_oldList.Clear()
        lv_errors.Items.Clear()
    End Sub

    Public Sub SetList(ByRef editor As ITextEditor, ByVal ErrorList As List(Of ErrorItem))
        Dim refresh As Boolean = Not (m_oldList.Count = ErrorList.Count)

        If Not refresh Then
            For i As Integer = 0 To m_oldList.Count - 1
                ErrorList(i).File = editor.Path
                If Not m_oldList(i).Equals(ErrorList(i)) Then
                    refresh = True
                    Exit For
                End If
            Next
        End If

        If refresh Then
            lv_errors.Items.Clear()
            m_oldList.Clear()

            m_editor = editor
            For Each errorItem As ErrorItem In ErrorList
                errorItem.File = editor.Path

                Dim newItem As New ListViewItem
                newItem.Tag = errorItem.Offset
                newItem.Text = errorItem.Line
                newItem.SubItems.Add(errorItem.Message)
                newItem.SubItems.Add(errorItem.File)
                lv_errors.Items.Add(newItem)

                m_oldList.Add(errorItem.Clone)
            Next
        End If
    End Sub

    Private Sub lv_errors_DoubleClick(sender As Object, e As EventArgs) Handles lv_errors.DoubleClick
        If lv_errors.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = lv_errors.SelectedItems(0)
            If Not IsNothing(item.Tag) Then
                If TypeOf (item.Tag) Is Integer Then
                    If Not IsNothing(m_editor) Then
                        Dim editor As ICSharpCode.AvalonEdit.TextEditor = m_editor.GetAvalonEditor()
                        Dim line As ICSharpCode.AvalonEdit.Document.IDocumentLine = editor.Document.GetLineByOffset(CType(item.Tag, Integer))
                        editor.ScrollToLine(line.LineNumber)
                        editor.SelectionLength = 0
                        editor.SelectionStart = line.Offset
                        editor.SelectionLength = line.Length
                        m_editor.GetAvalonEditor().Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lv_errors_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lv_errors.ColumnClick
        Dim createNewSorter As Boolean = True
        If Not IsNothing(sender.ListViewItemSorter) Then
            If TypeOf (sender.ListViewItemSorter) Is class_ListViewItemComparer Then
                If CType(sender.ListViewItemSorter, class_ListViewItemComparer).col = e.Column Then
                    CType(sender.ListViewItemSorter, class_ListViewItemComparer).reverse = Not CType(sender.ListViewItemSorter, class_ListViewItemComparer).reverse
                    createNewSorter = False
                End If
            End If
        End If

        If createNewSorter Then
            sender.ListViewItemSorter = New class_ListViewItemComparer(e.Column)
            If e.Column < 2 Then
                CType(sender.ListViewItemSorter, class_ListViewItemComparer).reverse = Not CType(sender.ListViewItemSorter, class_ListViewItemComparer).reverse
            End If
        End If

        sender.Sort()
    End Sub
End Class
