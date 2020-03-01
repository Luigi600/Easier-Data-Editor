'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class ErrorList
    Inherits Translation.TranslatableDockContent

    Private Class ListViewItemComparer
        Implements IComparer

        Private m_col As Integer = 0
        Public ReadOnly ColumnMaximum As Integer
        Public Property Column As Integer
            Get
                Return m_col
            End Get
            Set(value As Integer)
                If value > 0 And value < ColumnMaximum Then
                    m_col = value
                End If
            End Set
        End Property

        Public Reverse As Boolean = False

        Public Sub New(ByVal max As Integer, ByVal col As Integer)
            Me.ColumnMaximum = max
            Me.Column = col
        End Sub

        Public Function Compare(ByVal xx As Object, ByVal yy As Object) As Integer Implements IComparer.Compare
            Dim x As String = CType(xx, ListViewItem).SubItems(m_col).Text
            Dim y As String = CType(yy, ListViewItem).SubItems(m_col).Text

            Dim returnVal As Integer = -1

            If m_col = 0 Then
                returnVal = CType(x, Integer).CompareTo(CType(y, Integer))
            Else
                returnVal = x.CompareTo(y)
            End If

            If Reverse Then
                returnVal *= -1
            End If
            Return returnVal
        End Function
    End Class

    Public Sub New()
        InitializeComponent()

        Lv_errors.ListViewItemSorter = New ListViewItemComparer(Lv_errors.Columns.Count, 0)
    End Sub


    Public Sub CheckEditors(ByVal editors As List(Of TextEditor))
        Dim checkIndex As Integer = 0
        Do While checkIndex < Lv_errors.Items.Count
            Dim itemObj As ListViewItemObject = Lv_errors.Items(checkIndex).Tag
            If Not editors.Contains(itemObj.TextEditor) Then
                Lv_errors.Items.RemoveAt(checkIndex)
            Else
                checkIndex += 1
            End If
        Loop
    End Sub

    Private Class ListViewItemObject
        Public ReadOnly TextEditor As TextEditor
        Public ReadOnly ErrorItem As ErrorItem

        Public Sub New(ByVal textEditor As TextEditor, ByVal errorItem As ErrorItem)
            Me.TextEditor = textEditor
            Me.ErrorItem = errorItem
        End Sub
    End Class

    Public Sub SetErrors(ByVal textEditor As TextEditor)
        Dim checkIndex As Integer = 0
        Dim newErrors As New List(Of ErrorItem)
        newErrors.AddRange(textEditor.Errors) 'clone
        Do While checkIndex < Lv_errors.Items.Count
            Dim found As Boolean = True
            Dim itemObj As ListViewItemObject = Lv_errors.Items(checkIndex).Tag
            If itemObj.TextEditor.Equals(textEditor) Then
                found = False

                For Each errorItem As ErrorItem In newErrors
                    If errorItem.Equals(itemObj.ErrorItem) Then
                        found = True
                        newErrors.Remove(errorItem)
                        Exit For
                    End If
                Next
            End If

            If Not found Then
                Lv_errors.Items.RemoveAt(checkIndex)
            Else
                checkIndex += 1
            End If
        Loop

        For Each errorItem As ErrorItem In newErrors
            Dim lvItem As New ListViewItem With {.Text = errorItem.Line, .Tag = New ListViewItemObject(textEditor, errorItem.Clone)}
            lvItem.SubItems.Add(errorItem.Message)
            lvItem.SubItems.Add(errorItem.File)

            Lv_errors.Items.Add(lvItem)
        Next
    End Sub

    Private Sub Lv_errors_DoubleClick(sender As Object, e As EventArgs) Handles Lv_errors.DoubleClick
        If Lv_errors.SelectedItems.Count > 0 Then
            Try
                Dim itemObj As ListViewItemObject = Lv_errors.SelectedItems(0).Tag
                itemObj.TextEditor.GoToPosition(itemObj.ErrorItem.Offset)
                itemObj.TextEditor.Show()
                itemObj.TextEditor.Activate()
            Catch ex As Exception
            End Try
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        End If
    End Sub

    Private Sub Lv_errors_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles Lv_errors.ColumnClick
        Dim reversed As Boolean = False
        If CType(Lv_errors.ListViewItemSorter, ListViewItemComparer).Column = e.Column Then
            CType(Lv_errors.ListViewItemSorter, ListViewItemComparer).Reverse = Not CType(sender.ListViewItemSorter, ListViewItemComparer).Reverse
            reversed = True
        End If

        If Not reversed Then
            CType(sender.ListViewItemSorter, ListViewItemComparer).Column = e.Column
            CType(sender.ListViewItemSorter, ListViewItemComparer).Reverse = False
        End If

        sender.Sort()
    End Sub
End Class