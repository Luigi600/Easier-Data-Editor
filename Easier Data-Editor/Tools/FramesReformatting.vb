'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text.RegularExpressions
Imports ScintillaNET

Namespace Tools
    ''' <summary>Represents the best tool of this editor. The tool changes the format of all frames with specials functions like LIMIT or add values.</summary>
    Public Class FramesReformatting
        Private Const REGEX_PATTERN_LIMIT As String = "LIMIT\(\s*-?\d+\;\s*-?\d+\s*\)"
        Private Const REGEX_PATTERN_MIN_MAX As String = "(MIN|MAX)\(\s*-?\d+\s*\)"
        Private Const REGEX_PATTERN_SEARCH_PATTERN As String = "(\$|\?|" & REGEX_PATTERN_LIMIT & "|" & REGEX_PATTERN_MIN_MAX & ")" 'finds ?, $, but now also MIN and MAX
        Private Const REGEX_PATTERN_NUMBER_BEHIND_OPTIONAL As String = "(([\+\-()]*\d+[+\-/()^*]*)|[+\-()])" 'finds optional all number expressions behind something
        Private Const REGEX_PATTERN_NUMBER_NUMBER_WITH_SIGN As String = "([\+\-()/*]+\d+[()]*)" 'must have a math sign (like +)
        Private Const REGEX_PATTERN_SEARCH_PATTERN_SINGLE As String = REGEX_PATTERN_NUMBER_BEHIND_OPTIONAL & "*" &
                                                                  REGEX_PATTERN_SEARCH_PATTERN & REGEX_PATTERN_NUMBER_NUMBER_WITH_SIGN & "*"

        Private Const REGEX_PATTERN_SEARCH_PATTERN_MULTI As String = REGEX_PATTERN_SEARCH_PATTERN_SINGLE & "(\s+" & REGEX_PATTERN_SEARCH_PATTERN_SINGLE & ")*"

        Private Shared ReadOnly REGEX_REPLACER As New Regex("\$|\?", RegexOptions.IgnoreCase)
        Private Shared ReadOnly REGEX_REPLACER_LIMIT As New Regex(REGEX_PATTERN_LIMIT, RegexOptions.IgnoreCase)
        Private Shared ReadOnly REGEX_REPLACER_MIN_MAX As New Regex(REGEX_PATTERN_MIN_MAX, RegexOptions.IgnoreCase)
        Private Shared ReadOnly REGEX_REPLACER_HAS_MATH_EXPRESSION As New Regex("([+\-()]+\d+|[+\-()]*\d+[+\-/()*^]+)", RegexOptions.IgnoreCase)
        Private Shared ReadOnly REGEX_REPLACER_MATH_EXPRESSION As New Regex("[+\-/*()\?\$^\d]+", RegexOptions.IgnoreCase)
        Private Shared ReadOnly REGEX_REPLACER_VERY_SPECIAL_COMMANDS As New Regex("(CEILING|FLOOR|TRUNCATE)\(.*?\)", RegexOptions.IgnoreCase)
        Private Shared ReadOnly DATA_TABLE As New DataTable()

        Public Shared Sub Reformatting(ByVal originalEditor As CustomScintilla, ByVal onlySelected As Boolean, ByVal removeEmptyLines As Boolean,
                                       ByVal template As String, ByVal template_bpoint As String, ByVal template_cpoint As String, ByVal template_opoint As String,
                                       ByVal template_wpoint As String, ByVal template_bdy As String, ByVal template_itr As String)
            Dim selections As SelectionCollection = originalEditor.Selections

            originalEditor.BlockUndoRedoActions = True
            Dim framesMatch As MatchCollection = Nothing
            'If Not onlySelected Then
            framesMatch = Regex.Matches(originalEditor.Text, "(<frame>)[^<>]*<frame_end>", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            'Else
            '    framesMatch = m_regexRangeForFrames.Matches(originalEditor.Text, originalEditor.SelectionStart)
            'End If



            For k As Integer = framesMatch.Count - 1 To 0 Step -1
                Dim frameMatch As Match = framesMatch(k)
                If frameMatch.Success Then
                    If onlySelected Then
                        Dim found As Boolean = False
                        For Each sel As Selection In selections
                            If frameMatch.Index >= sel.Caret And frameMatch.Index <= sel.End Then
                                found = True
                                Exit For
                            End If
                        Next

                        If Not found Then
                            Continue For 'bottom to top, NOT BREAK
                        End If
                    End If

                    Dim newFrame As String = template
                    Dim originalFrame As String = frameMatch.Value

                    Dim frameID As Integer = GetRegexValueInteger(originalFrame, "(?<=<frame>\s*)[0-9]+", RegexOptions.IgnoreCase, -1)
                    Dim frameName As String = GetRegexValue(originalFrame, "(?<=<frame>\s*[0-9]+\s+)[^\s]+", RegexOptions.IgnoreCase)

                    If frameID >= 0 Then
                        Dim frameCommentMatch As Match = Regex.Match(originalFrame, "(?<=\<frame\>\s*\d+\s+[^\s]*\s*)#[^\r\n]+", RegexOptions.IgnoreCase)
                        If frameCommentMatch.Success Then
                            originalFrame = originalFrame.Substring(0, frameCommentMatch.Index) & originalFrame.Substring(frameCommentMatch.Index + frameCommentMatch.Length)

                            If Not Regex.IsMatch(newFrame, "%FRAMENAME%[^\n\r]+#($|(?=\s+))") Then
                                newFrame = newFrame.Replace("%FRAMENAME%", "%FRAMENAME% " & frameCommentMatch.Value)
                            Else
                                newFrame = Regex.Replace(newFrame, "(?<=%FRAMENAME%[^\n\r]+)#($|(?=\s+))", frameCommentMatch.Value)
                            End If
                        Else
                            newFrame = Regex.Replace(newFrame, "(?<=%FRAMENAME%)\s*#", "")
                        End If

                        newFrame = Regex.Replace(newFrame, "(?<=<frame>\s*)\$", frameID.ToString, RegexOptions.IgnoreCase)
                        newFrame = newFrame.Replace("%FRAMENAME%", frameName)

                        Dim points As MatchCollection = Regex.Matches(originalFrame, "\s*(bpoint|wpoint|cpoint|opoint|bdy|itr):[^_]+?_end:[^\n\r]*", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                        For i As Integer = points.Count - 1 To 0 Step -1
                            Dim point As Match = points(i)
                            If point.Success Then
                                originalFrame = originalFrame.Substring(0, point.Index) & originalFrame.Substring(point.Index + point.Length, originalFrame.Length - point.Length - point.Index)
                            End If
                        Next


                        FindAndWriteAttributes(originalFrame, newFrame)
                        For Each match As Match In points
                            If match.Success Then
                                Dim input As String = match.Value
                                Dim newPoint As String = ""
                                Dim pointName As String = ""

                                If Regex.IsMatch(match.Value, "bpoint", RegexOptions.IgnoreCase) Then
                                    pointName = "BPOINT"
                                    newPoint = template_bpoint
                                ElseIf Regex.IsMatch(match.Value, "opoint", RegexOptions.IgnoreCase) Then
                                    pointName = "OPOINT"
                                    newPoint = template_opoint
                                ElseIf Regex.IsMatch(match.Value, "cpoint", RegexOptions.IgnoreCase) Then
                                    pointName = "CPOINT"
                                    newPoint = template_cpoint
                                ElseIf Regex.IsMatch(match.Value, "wpoint", RegexOptions.IgnoreCase) Then
                                    pointName = "WPOINT"
                                    newPoint = template_wpoint
                                ElseIf Regex.IsMatch(match.Value, "bdy", RegexOptions.IgnoreCase) Then
                                    pointName = "BODIES"
                                    newPoint = template_bdy
                                ElseIf Regex.IsMatch(match.Value, "itr", RegexOptions.IgnoreCase) Then
                                    pointName = "ITRS"
                                    newPoint = template_itr
                                End If

                                If newPoint.Length > 0 Then
                                    FindAndWriteAttributes(match.Value, newPoint)
                                    Dim tagSpace As String = GetRegexValue(newFrame, "\s*(?=\%" & pointName & "\%)", RegexOptions.IgnoreCase)
                                    If Not IsNothing(tagSpace) Then
                                        If tagSpace.Length = 0 Then
                                            tagSpace = " "
                                        End If

                                        newFrame = New Regex("\%" & pointName & "\%").Replace(newFrame, newPoint & tagSpace & "%" & pointName & "%", 1)
                                    Else
                                        Dim spaceBefore As String = GetRegexValue(newFrame, "\s*(?=\%othersPoints\%)", RegexOptions.IgnoreCase, "")
                                        newFrame = newFrame.Replace("%othersPoints%", newPoint & vbNewLine & spaceBefore & "%othersPoints%")
                                    End If
                                End If
                            End If
                        Next



                        newFrame = Regex.Replace(newFrame, "([\n\r]{1}\s+)?\%(ITRS|BODIES|(B|C|O|W)POINT)\%([^\S\r\n]*|$|(?=[\n\r]+))", "")
                        newFrame = Regex.Replace(newFrame, "[\r\n]+\s+\w+:[^\S\r\n]*(\$|\?)([^\S\r\n]+(\$|\?))?($|[^\S\r\n]*(?=[\n\r]+))", " ")
                        newFrame = Regex.Replace(newFrame, "\w+:[^\S\r\n]*(\$|\?)([^\S\r\n]+(\$|\?))?([^\S\r\n]+|$|(?=[\n\r]+))", "")
                        '  newFrame = Regex.Replace(newFrame, "([\n\r]{1}\s+)+\w+:[^\S\r\n]*(\$|\?)([^\S\r\n]+(\$|\?))?([^\S\r\n]+)(?=[\n\r]+|$)", " ")
                        newFrame = Regex.Replace(newFrame, "\s*\%others(|Points)\%", "")

                        If removeEmptyLines Then
                            newFrame = Regex.Replace(newFrame, "^\s+$[\r\n]*", "", RegexOptions.Multiline)
                        End If

                        originalEditor.TargetStart = frameMatch.Index
                        originalEditor.TargetEnd = frameMatch.Index + frameMatch.Length
                        originalEditor.ReplaceTarget(newFrame)
                    End If
                End If
            Next

            originalEditor.BlockUndoRedoActions = False
        End Sub

        Private Shared Sub FindAndWriteAttributes(ByVal originalFrame As String, ByRef newFrame As String)
            Dim comments As String = ""

            Dim commentsMatch As MatchCollection = Regex.Matches(originalFrame, "#[^\r\n]+", RegexOptions.IgnoreCase)
            For i As Integer = commentsMatch.Count - 1 To 0 Step -1
                If commentsMatch(i).Success Then
                    If comments.Length > 0 Then
                        comments &= vbNewLine
                    End If
                    comments &= commentsMatch(i).Value

                    originalFrame = originalFrame.Substring(0, commentsMatch(i).Index) & originalFrame.Substring(commentsMatch(i).Index + commentsMatch(i).Length)
                End If
            Next


            Dim attributes As MatchCollection = Regex.Matches(originalFrame, "\w+:[^\S\r\n]*([^<>:\s\n\r]+)([^\S\r\n]+[^<>:\s\n\r]+)?([^\S\r\n]+|$|(?=[\n\r]+))", RegexOptions.IgnoreCase)
            For Each attri As Match In attributes
                If attri.Success Then
                    Dim attriName As String = GetRegexValue(attri.Value, "\w+:")

                    Dim tmpAttr As Match = Regex.Match(newFrame, attriName & "\s*(" & REGEX_PATTERN_SEARCH_PATTERN_MULTI & "|(CEILING|FLOOR|TRUNCATE)\(.*?\))") '(\$|\?)(\s+(\$|\?))*")
                    If tmpAttr.Success Then
                        Dim newAttr As String = tmpAttr.Value

                        Dim attriValues As MatchCollection = Regex.Matches(attri.Value, "([^<>:\s]+(\s+|$))", RegexOptions.IgnoreCase)
                        If attriValues.Count = 1 Then
                            Dim valMatch As Match = attriValues(0)
                            If valMatch.Success Then
                                newAttr = ParseInput(newAttr, valMatch.Value.Trim, True)

                                'newAttr = Regex.Replace(newAttr, "(?<=(^|\s+))\$(?=(\s+|$))", valMatch.Value.Trim)
                                'If newAttr.Equals(tmpAttr.Value) Then 'then set only when val <> 0 OR SPECIAL FUNCTION
                                '    If IsNumeric(valMatch.Value) Then
                                '        If Not CInt(valMatch.Value.Trim) = 0 Then
                                '            newAttr = Regex.Replace(newAttr, "(?<=(^|\s+))\?(?=(\s+|$))", valMatch.Value.Trim)
                                '        End If
                                '    ElseIf attriName.Contains("sound:") Then
                                '        newAttr = Regex.Replace(newAttr, "(?<=(^|\s+))\?(?=(\s+|$))", valMatch.Value.Trim)
                                '    End If
                                'End If
                            End If
                        ElseIf attriValues.Count > 0 Then
                            Dim space As String = GetRegexValue(tmpAttr.Value, "(?<=\w+:)\s*")
                            If space.Length = 0 Then
                                space = " "
                            End If

                            For j As Integer = Regex.Matches(tmpAttr.Value, "(\$|\?)").Count To attriValues.Count - 1
                                newAttr &= space & "$"
                            Next

                            For Each attrV As Match In attriValues
                                newAttr = ParseInput(newAttr, attrV.Value.Trim)

                                ' newAttr = New Regex("\$|\?", RegexOptions.IgnoreCase).Replace(newAttr, attrV.Value.Trim, 1)
                            Next



                        End If
                        newFrame = newFrame.Substring(0, tmpAttr.Index) & newAttr & newFrame.Substring(tmpAttr.Index + tmpAttr.Length)
                    Else
                        If Not attri.Value.EndsWith(" ") Then
                            newFrame = newFrame.Replace("%others%", attri.Value & " %others%")
                        Else
                            newFrame = newFrame.Replace("%others%", attri.Value & "%others%")
                        End If
                    End If


                    Console.WriteLine("---------")
                End If
            Next

            If Regex.IsMatch(newFrame, "(^|(?<=\s+))#($|(?=\s+))") Then
                newFrame = Regex.Replace(newFrame, "(^|(?<=\s+))#($|(?=\s+))", comments)
            Else
                newFrame = newFrame.Replace("%others%", "%others% " & comments)
            End If
        End Sub

        Private Shared Function ParseInput(ByVal parseAttr As String, ByVal val As String, Optional ByVal setOnlyWhenNotZero As Boolean = False) As String
            Dim valIsNumber As Boolean = IsNumeric(val)
            If setOnlyWhenNotZero And valIsNumber Then
                If parseAttr.Contains("?") Then
                    If CInt(val) = 0 Then
                        Return parseAttr
                    End If
                End If
            End If

            parseAttr = REGEX_REPLACER.Replace(parseAttr, val, 1)

            If valIsNumber Then
                If parseAttr.Contains("LIMIT") Then
                    Dim val2 As Integer = GetRegexValueInteger(parseAttr, "(?<=LIMIT\(\s*\-?\d+\s*\;\s*)(\-?\d+)(?=\s*\))", RegexOptions.IgnoreCase, Integer.MaxValue)
                    Dim val1 As Integer = GetRegexValueInteger(parseAttr, "(?<=LIMIT\(\s*)(\-?\d+)(?=\s*\;)", RegexOptions.IgnoreCase, Integer.MinValue)

                    parseAttr = REGEX_REPLACER_LIMIT.Replace(parseAttr, Math.Min(Math.Max(val1, CInt(val)), val2).ToString, 1)


                ElseIf parseAttr.Contains("MAX") Then
                    Dim val1 As Integer = GetRegexValueInteger(parseAttr, "(?<=(MIN|MAX)\()(\s*\-?\d+\s*)(?=\))", RegexOptions.IgnoreCase, Integer.MaxValue)

                    parseAttr = REGEX_REPLACER_MIN_MAX.Replace(parseAttr, Math.Min(CInt(val), val1).ToString, 1)

                ElseIf parseAttr.Contains("MIN") Then
                    Dim val1 As Integer = GetRegexValueInteger(parseAttr, "(?<=(MIN|MAX)\()(\s*\-?\d+\s*)(?=\))", RegexOptions.IgnoreCase, Integer.MinValue)

                    parseAttr = REGEX_REPLACER_MIN_MAX.Replace(parseAttr, Math.Max(CInt(val), val1).ToString, 1)

                ElseIf parseAttr.Contains("CEILING") Then
                    Dim val1 As String = GetRegexValue(parseAttr, "(?<=CEILING\(\s*).*?(?=\s*\))", RegexOptions.IgnoreCase, "").Trim
                    val1 = REGEX_REPLACER.Replace(val1, val)
                    Dim result As Object = Calculate(val1)
                    If Not IsNothing(result) Then
                        If TypeOf result Is Integer Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, result.ToString, 1)
                        ElseIf TypeOf result Is Single Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Ceiling(CSng(result)).ToString, 1)
                        ElseIf TypeOf result Is Double Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Ceiling(CDbl(result)).ToString, 1)
                        ElseIf TypeOf result Is Decimal Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Ceiling(CDec(result)).ToString, 1)
                        Else
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, val, 1)
                        End If
                    Else
                        parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, val, 1)
                    End If

                ElseIf parseAttr.Contains("FLOOR") Then
                    Dim val1 As String = GetRegexValue(parseAttr, "(?<=FLOOR\(\s*).*?(?=\s*\))", RegexOptions.IgnoreCase, "").Trim
                    val1 = REGEX_REPLACER.Replace(val1, val)
                    Dim result As Object = Calculate(val1)
                    If Not IsNothing(result) Then
                        If TypeOf result Is Integer Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, result.ToString, 1)
                        ElseIf TypeOf result Is Single Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Floor(CSng(result)).ToString, 1)
                        ElseIf TypeOf result Is Double Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Floor(CDbl(result)).ToString, 1)
                        ElseIf TypeOf result Is Decimal Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Floor(CDec(result)).ToString, 1)
                        Else
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, val, 1)
                        End If
                    Else
                        parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, val, 1)
                    End If

                ElseIf parseAttr.Contains("TRUNCATE") Then
                    Dim val1 As String = GetRegexValue(parseAttr, "(?<=TRUNCATE\(\s*).*?(?=\s*\))", RegexOptions.IgnoreCase, "").Trim
                    val1 = REGEX_REPLACER.Replace(val1, val)
                    Dim result As Object = Calculate(val1)
                    If Not IsNothing(result) Then
                        If TypeOf result Is Integer Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, result.ToString, 1)
                        ElseIf TypeOf result Is Single Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Truncate(CSng(result)).ToString, 1)
                        ElseIf TypeOf result Is Double Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Truncate(CDbl(result)).ToString, 1)
                        ElseIf TypeOf result Is Decimal Then
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, Math.Truncate(CDec(result)).ToString, 1)
                        Else
                            parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, val, 1)
                        End If
                    Else
                        parseAttr = REGEX_REPLACER_VERY_SPECIAL_COMMANDS.Replace(parseAttr, val, 1)
                    End If
                End If
            End If

            If REGEX_REPLACER_HAS_MATH_EXPRESSION.IsMatch(parseAttr) Then
                Dim result As Object = Calculate(parseAttr.Substring(parseAttr.IndexOf(":") + 1))
                If Not IsNothing(result) Then
                    If TypeOf result Is Integer Then
                        parseAttr = REGEX_REPLACER_MATH_EXPRESSION.Replace(parseAttr, result.ToString, 1)
                    ElseIf TypeOf result Is Single Then
                        parseAttr = REGEX_REPLACER_MATH_EXPRESSION.Replace(parseAttr, Math.Ceiling(CSng(result)).ToString, 1)
                    ElseIf TypeOf result Is Double Then
                        parseAttr = REGEX_REPLACER_MATH_EXPRESSION.Replace(parseAttr, Math.Ceiling(CDbl(result)).ToString, 1)
                    ElseIf TypeOf result Is Decimal Then
                        parseAttr = REGEX_REPLACER_MATH_EXPRESSION.Replace(parseAttr, Math.Ceiling(CDec(result)).ToString, 1)
                    Else
                        parseAttr = REGEX_REPLACER_MATH_EXPRESSION.Replace(parseAttr, val, 1)
                    End If
                Else
                    parseAttr = REGEX_REPLACER_MATH_EXPRESSION.Replace(parseAttr, val, 1)
                End If
            End If

            Return parseAttr
        End Function

        Private Shared Function Calculate(ByVal expression As String) As Object
            Try
                Return CalculateWithException(expression)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Private Shared Function CalculateWithException(ByVal expression As String) As Object
            Return DATA_TABLE.Compute(expression, Nothing)
        End Function
    End Class
End Namespace