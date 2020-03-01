'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text.RegularExpressions
Imports System.Xml

''' <summary>Represents a custom syntax highlighting for CustomScintilla.</summary>
Public Class Syntax
    Public ReadOnly RegexSpecials As New List(Of SyntaxItemRegex)
    Public ReadOnly SingleWordRegex As New List(Of SyntaxItemRegex)
    Public ReadOnly KeywordItems As New List(Of SyntaxItemKeywords)
    Public ReadOnly DefaultColor As Color = Color.Black
    Public ReadOnly DefaultBackColor As Color = Color.White

    Public Sub New(ByVal xmlContent As String)
        Dim xmlFile As New XmlDocument()
        xmlFile.LoadXml(xmlContent)
        For Each node As XmlNode In xmlFile.ChildNodes
            If node.Name.Equals("SyntaxDefinition") Then
                For Each defineNode As XmlNode In node.ChildNodes
                    If Not IsNothing(defineNode.Attributes) Then
                        If defineNode.Name.Equals("Default") Then
                            GetAttributeValueAndSet(defineNode.Attributes, "forecol", DefaultColor)
                            GetAttributeValueAndSet(defineNode.Attributes, "backcol", DefaultBackColor)
                        ElseIf defineNode.Name.Equals("Regex") Then
                            Dim regexItem As New SyntaxItemRegex(defineNode.Attributes)

                            If regexItem.Pattern.Length > 1 Then
                                RegexSpecials.Add(regexItem)
                            End If
                        End If
                    End If

                    If defineNode.Name.Equals("Keywords") Then
                        Dim ky As New SyntaxItemKeywords(defineNode.Attributes)
                        For Each subNode As XmlNode In defineNode.ChildNodes
                            If subNode.Name.Equals("Word") Then
                                ky.Keywords.Add(subNode.InnerText.ToLower)
                            End If
                        Next

                        If ky.Keywords.Count > 0 Then
                            KeywordItems.Add(ky)
                        End If
                    ElseIf defineNode.Name.Equals("SingleWordRegex") Then
                        For Each subNode As XmlNode In defineNode.ChildNodes
                            If subNode.Name.Equals("Pattern") Then
                                Dim ky As New SyntaxItemRegex(defineNode.Attributes, subNode.InnerText.ToLower)
                                SingleWordRegex.Add(ky)
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Public Function GetStyleRanges(ByVal startPos As Integer, ByVal endPos As Integer, ByVal text As String) As List(Of RangeSyntax)
        Dim range As New Text.StringBuilder(text)
        Dim addedStyleRange As New List(Of RangeSyntax)

        For Each spaceMatch As Match In Regex.Matches(range.ToString, "\s+")
            addedStyleRange.Add(New RangeSyntax(startPos + spaceMatch.Index, spaceMatch.Length, StylesIndices.Default))
        Next

        For Each regexItem As SyntaxItemRegex In RegexSpecials
            For Each mtc As Match In Regex.Matches(range.ToString, regexItem.Pattern)
                If mtc.Success Then
                    addedStyleRange.Add(New RangeSyntax(startPos + mtc.Index, mtc.Length, regexItem.StyleIndex))

                    range = range.Remove(mtc.Index, mtc.Length)
                    range = range.Insert(mtc.Index, " "c, mtc.Length)
                    '  range = range.Substring(0, mtc.Index) & "".PadLeft(mtc.Length, " "c) & range.Substring(mtc.Index + mtc.Length)
                End If
            Next
        Next

        Dim mtchs As MatchCollection = Regex.Matches(range.ToString, "(?:[^\s]+)") '(?:[^\s]+)  "(?:\bTest\b|\bTestTwo\b|\bTestThree\b)")
        For Each mtch As Match In mtchs
            If mtch.Success Then
                Dim val As String = mtch.Value.Trim.ToLower
                Dim style As Integer = -1

                For Each regexItem As SyntaxItemRegex In SingleWordRegex
                    Dim mtc As Match = Regex.Match(val, regexItem.Pattern)
                    If mtc.Success Then
                        style = regexItem.StyleIndex
                        Exit For
                    End If
                Next


                If style < 0 Then
                    For Each syn As SyntaxItemKeywords In KeywordItems
                        If syn.Keywords.Contains(val) Then
                            style = syn.StyleIndex
                            Exit For
                        End If
                    Next
                End If

                If style >= 0 Then
                    addedStyleRange.Add(New RangeSyntax(startPos + mtch.Index, mtch.Length, style))
                End If
            End If
        Next

        Return addedStyleRange.OrderBy(Function(o) o.Range.Y).ToList()
    End Function
End Class