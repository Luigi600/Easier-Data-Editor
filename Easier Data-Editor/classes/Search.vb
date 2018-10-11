Imports System.Text.RegularExpressions

Public Class Search
    Public searchWord As String = ""
    Public replaceWord As String = ""
    Public FileBeginning As Boolean = False
    Public Forward As Boolean = True

    Public MatchCase As Boolean = False
    Public MatchWholeWord As Boolean = False
    Public LastSearchItem As New SearchItem

    Public ReverseIsOpen As Boolean = False

    Public TextEditor As ICSharpCode.AvalonEdit.TextEditor = Nothing

    Public Sub New()
    End Sub

    Public Function Find(Optional ByVal reverse As Boolean = False) As Boolean
        If Not IsNothing(TextEditor) And Not String.IsNullOrWhiteSpace(searchWord) Then
            Dim offset As Integer = -1
            Dim searchOffset As Integer = TextEditor.TextArea.Caret.Offset
            Dim txt As String = TextEditor.Text

            If FileBeginning Then
                If LastSearchItem.SearchName.Equals(searchWord) Then
                    searchOffset = LastSearchItem.LastOffset
                Else
                    searchOffset = 0
                End If
            End If

            If searchOffset < 0 Then searchOffset = 0
            If Not reverse And Not Forward Then
                reverse = Not Forward
            ElseIf reverse And Not Forward Then
                reverse = Forward
            End If


            Dim strCom As StringComparison = StringComparison.Ordinal
            Dim regOpt As RegexOptions = RegexOptions.None
            If Not MatchCase Then
                regOpt = RegexOptions.IgnoreCase
                strCom = StringComparison.CurrentCultureIgnoreCase
            End If

            If reverse Then
                txt = TextEditor.Document.Text.Substring(0, If(searchOffset > 0, searchOffset - 1, 0))
                regOpt = (RegexOptions.RightToLeft Or regOpt)
            End If

            If MatchWholeWord Then
                Dim searchWord As String = Me.searchWord
                Dim pattern As String = "\b(" & RegexFriendlySearch(searchWord) & ")\b"
                If searchWord.EndsWith(":") Then
                    searchWord = searchWord.Substring(0, searchWord.Length - 1)
                    pattern = "\b(" & RegexFriendlySearch(searchWord) & ")\b:"
                End If
                Dim rg As New Regex(pattern, regOpt)
                Dim mtch As Match = rg.Match(txt, If(reverse, txt.Length, searchOffset))
                If mtch.Success Then
                    offset = mtch.Index
                End If
            Else
                If Not reverse Then
                    offset = txt.IndexOf(searchWord, searchOffset, strCom)
                Else
                    offset = txt.LastIndexOf(searchWord, strCom)
                End If
            End If


            LastSearchItem.SearchName = searchWord
            LastSearchItem.LastOffset = offset + searchWord.Length

            If offset >= 0 Then
                Dim line As ICSharpCode.AvalonEdit.Document.DocumentLine = TextEditor.Document.GetLineByOffset(offset)
                TextEditor.SelectionLength = 0
                TextEditor.SelectionStart = offset
                TextEditor.SelectionLength = searchWord.Length
                TextEditor.TextArea.Caret.BringCaretToView()
                'TextEditor.ScrollToLine(line.LineNumber)
                'TextEditor.ScrollToHorizontalOffset(offset - line.Offset + line.Length)
                Return True
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        End If

        Return False
    End Function

    Public Sub Replace()
        If Not IsNothing(TextEditor) And Not String.IsNullOrWhiteSpace(replaceWord) Then
            If Find() Then
                TextEditor.SelectedText = replaceWord
            End If
        End If
    End Sub

    Public Sub ReplaceAll()
        'If Not IsNothing(TextEditor) Then
        '    Do While Find()
        '        TextEditor.SelectedText = replaceWord
        '    Loop
        'End If



        If Not IsNothing(TextEditor) Then
            Dim offset As Integer = -1
            Dim searchOffset As Integer = TextEditor.TextArea.Caret.Offset
            Dim txt As String = TextEditor.Text
            Dim originalLength As Integer = 0
            Dim pattern As String = searchWord

            If FileBeginning Then
                If LastSearchItem.SearchName.Equals(searchWord) And LastSearchItem.SearchReplace.Equals(replaceWord) Then
                    searchOffset = LastSearchItem.LastOffset
                Else
                    searchOffset = 0
                End If
            End If

            If searchOffset < 0 Then searchOffset = 0
            Dim regOpt As RegexOptions = RegexOptions.None
            If Not MatchCase Then
                regOpt = RegexOptions.IgnoreCase
            End If

            If Not Forward Then
                txt = TextEditor.Document.Text.Substring(0, If(searchOffset > 0, searchOffset - 1, 0))
                regOpt = (RegexOptions.RightToLeft Or regOpt)
            End If



            If MatchWholeWord Then
                Dim searchWord As String = Me.searchWord
                If searchWord.EndsWith(":") Then
                    searchWord = searchWord.Substring(0, searchWord.Length - 1)
                    pattern = "\b(" & RegexFriendlySearch(searchWord) & ")\b:"
                Else
                    pattern = "\b(" & RegexFriendlySearch(searchWord) & ")\b"
                End If
            End If

            originalLength = txt.Length
            Dim rg As New Regex(pattern, regOpt)
            txt = rg.Replace(txt, replaceWord, -1, If(searchOffset < txt.Length, searchOffset, txt.Length))

            TextEditor.SelectionLength = 0
            TextEditor.SelectionStart = 0
            TextEditor.SelectionLength = originalLength
            TextEditor.SelectedText = txt

            TextEditor.SelectionLength = 0
            TextEditor.CaretOffset = searchOffset


            LastSearchItem.SearchName = searchWord
            LastSearchItem.LastOffset = offset + searchWord.Length
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        End If
    End Sub

    Public Shared Function RegexFriendlySearch(ByVal word As String) As String
        word = word.Replace("?", "\?")
        word = word.Replace(".", "\.")
        word = word.Replace("$", "\$")
        word = word.Replace("(", "\(")
        word = word.Replace(")", "\)")
        word = word.Replace("{", "\{")
        word = word.Replace("}", "\}")
        word = word.Replace("[", "\[")
        word = word.Replace("]", "\]")
        word = word.Replace("\", "\\")
        word = word.Replace("/", "//")
        Return word
    End Function
End Class
