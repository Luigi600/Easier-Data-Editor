Imports System.Text
Imports System.Xml
Imports ICSharpCode.AvalonEdit.Document
Imports System.Runtime.InteropServices
Imports ICSharpCode.AvalonEdit.Folding
Imports System.Text.RegularExpressions

'------------------------------------------''---------Created by Lui's Studio----------''-------(http://www.lui-studio.net/)-------''------------------------------------------''-------------Author: Luigi600-------------''------------------------------------------'
'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> see name... </summary>

NotInheritable Class LFFoldStart
    Inherits NewFolding

    Friend StartLine As Integer
End Class

Public Class LFFoldingStrategy
    Public Property ShowAttributesWhenFolded As Boolean

    Public Sub UpdateFoldings(ByVal manager As FoldingManager, ByVal document As TextDocument)
        Dim firstErrorOffset As Integer
        Dim foldings As IEnumerable(Of NewFolding) = CreateNewFoldings(document, firstErrorOffset)
        manager.UpdateFoldings(foldings, firstErrorOffset)
    End Sub

    Public Function CreateNewFoldings(ByVal document As TextDocument, <Out> ByRef firstErrorOffset As Integer) As IEnumerable(Of NewFolding)
        Dim stack As Stack(Of LFFoldStart) = New Stack(Of LFFoldStart)()
        Dim foldMarkers As List(Of NewFolding) = New List(Of NewFolding)()


        Dim txt As String = document.Text

        Dim mtches As MatchCollection = Regex.Matches(txt, "<(?!stage)[^<>]+>.*?<[^\<\>]+_end>", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        For Each mtch As Match In mtches
            Dim id As Integer = getRegexValueInteger(mtch.Value, "(?<=\<frame\>\s*)[0-9]+")
            Dim newFoldStart As New LFFoldStart
            newFoldStart.StartOffset = mtch.Index
            newFoldStart.Name = UppercaseFirstLetter(getRegexValue(mtch.Value, "(?<=\<)[^\<\>]+(?=\>)"))
            If id >= 0 Then
                newFoldStart.Name &= " " & id.ToString
                newFoldStart.Name &= " " & getRegexValue(mtch.Value, "(?<=\<frame\>\s*[0-9]+\s+)[^\r\n]+")
            End If
            stack.Push(newFoldStart)

            Dim foldStart As LFFoldStart = stack.Pop()
            foldStart.EndOffset = mtch.Index + mtch.Length
            foldMarkers.Add(foldStart)
            'CreateElementFold(document, foldMarkers, reader, foldStart)
        Next

        foldMarkers.Sort(Function(a, b) a.StartOffset.CompareTo(b.StartOffset))
        Return foldMarkers
    End Function

    Private Function UppercaseFirstLetter(ByVal val As String) As String
        If String.IsNullOrEmpty(val) Then
            Return val
        End If

        Dim array() As Char = val.ToCharArray
        array(0) = Char.ToUpper(array(0))
        Return New String(array)
    End Function
End Class