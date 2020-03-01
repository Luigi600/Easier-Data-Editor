'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text.RegularExpressions

Namespace Tools
    ''' <summary>Represents a tool to equation of all frames which have the same pic-ID.</summary>
    Public Class Equation
        Public Shared Function EquationAllFramesFrom(ByVal Scintilla1 As CustomScintilla, ByVal m_frame As TextFrame, ByVal centerXY As Boolean,
                                                     ByVal nextValue As Boolean, ByVal bodies As Boolean, ByVal itrs As Boolean, ByVal bpoi As Boolean,
                                                     ByVal cpoi As Boolean, ByVal opoi As Boolean, ByVal wpoi As Boolean, ByVal hitValues As Boolean,
                                                     ByVal waitValue As Boolean, ByVal stateValue As Boolean) As Boolean
            If Not IsNothing(m_frame) Then
                If m_frame.Offset >= 0 Then
                    Dim picID As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=pic:\s*)\d+", RegexOptions.IgnoreCase)
                    Dim centerX As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=centerx:\s*)[-]?\d+", RegexOptions.IgnoreCase, Integer.MaxValue)
                    Dim centerY As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=centery:\s*)[-]?\d+", RegexOptions.IgnoreCase, Integer.MaxValue)
                    Dim nextVa As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=next:\s*)\d+", RegexOptions.IgnoreCase, Integer.MaxValue)
                    Dim state As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=state:\s*)\d+", RegexOptions.IgnoreCase)
                    Dim waitVa As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=wait:\s*)\d+", RegexOptions.IgnoreCase)

                    Dim bpoiStr As String = ""
                    Dim cpoiStr As String = ""
                    Dim opoiStr As String = ""
                    Dim wpoiStr As String = ""

                    Dim bpoiStrCompleted As String = ""
                    Dim cpoiStrCompleted As String = ""
                    Dim opoiStrCompleted As String = ""
                    Dim wpoiStrCompleted As String = ""

                    Dim bodiesStr As New List(Of String)
                    Dim itrsStr As New List(Of String)
                    Dim bodiesStrCompleted As New List(Of String)
                    Dim itrsStrCompleted As New List(Of String)

                    If m_frame.OffsetBPoint.X >= 0 Then
                        bpoiStr = Scintilla1.GetTextRange(m_frame.OffsetBPoint.X, m_frame.OffsetBPoint.Y - m_frame.OffsetBPoint.X)
                        bpoiStrCompleted = GetRegexValue(m_frame.Lines, "\s*bpoint:.*?bpoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                    End If
                    If m_frame.OffsetCPoint.X >= 0 Then
                        cpoiStr = Scintilla1.GetTextRange(m_frame.OffsetCPoint.X, m_frame.OffsetCPoint.Y - m_frame.OffsetCPoint.X)
                        cpoiStrCompleted = GetRegexValue(m_frame.Lines, "\s*cpoint:.*?cpoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                    End If
                    If m_frame.OffsetOPoint.X >= 0 Then
                        opoiStr = Scintilla1.GetTextRange(m_frame.OffsetOPoint.X, m_frame.OffsetOPoint.Y - m_frame.OffsetOPoint.X)
                        opoiStrCompleted = GetRegexValue(m_frame.Lines, "\s*opoint:.*?opoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                    End If
                    If m_frame.OffsetWPoint.X >= 0 Then
                        wpoiStr = Scintilla1.GetTextRange(m_frame.OffsetWPoint.X, m_frame.OffsetWPoint.Y - m_frame.OffsetWPoint.X)
                        wpoiStrCompleted = GetRegexValue(m_frame.Lines, "\s*wpoint:.*?wpoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                    End If

                    For Each bdy As Point In m_frame.OffsetBodies
                        bodiesStr.Add(Scintilla1.GetTextRange(bdy.X, bdy.Y - bdy.X))
                    Next
                    For Each itr As Point In m_frame.OffsetItrs
                        itrsStr.Add(Scintilla1.GetTextRange(itr.X, itr.Y - itr.X))
                    Next

                    For Each bdy As Match In Regex.Matches(m_frame.Lines, "\s*bdy:.*?bdy_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                        If bdy.Success Then
                            bodiesStrCompleted.Add(bdy.Value)
                        End If
                    Next
                    For Each itr As Match In Regex.Matches(m_frame.Lines, "\s*itr:.*?itr_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                        If itr.Success Then
                            itrsStrCompleted.Add(itr.Value)
                        End If
                    Next

                    If picID >= 0 Then
                        Dim txtFrames As MatchCollection = New Regex("<frame>[^<>]+pic:\s*" & picID & "[^<>]+<frame_end>", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Matches(Scintilla1.Text)
                        For i As Integer = txtFrames.Count - 1 To 0 Step -1
                            Dim frameMatch As Match = txtFrames(i)
                            If frameMatch.Success Then
                                If Not (frameMatch.Index >= m_frame.Offset And frameMatch.Index <= m_frame.Offset + m_frame.Length) Then
                                    Dim newText As String = frameMatch.Value
                                    Dim frameEnd As String = GetRegexValue(newText, "\s*<frame_end>", RegexOptions.IgnoreCase, "<frame_end>")

                                    If centerXY Then
                                        If Not centerX = Integer.MaxValue Then
                                            newText = New Regex("(?<=centerx:\s*)[-]?\d+", RegexOptions.IgnoreCase).Replace(newText, centerX.ToString)
                                        End If
                                        If Not centerY = Integer.MaxValue Then
                                            newText = New Regex("(?<=centery:\s*)[-]?\d+", RegexOptions.IgnoreCase).Replace(newText, centerY.ToString)
                                        End If
                                    End If

                                    If nextValue Then
                                        If Not nextVa = Integer.MaxValue Then
                                            newText = New Regex("(?<=next:\s*)[-]?\d+", RegexOptions.IgnoreCase).Replace(newText, nextVa.ToString)
                                        End If
                                    End If

                                    If stateValue And state >= 0 Then
                                        newText = New Regex("(?<=state:\s*)[-]?\d+", RegexOptions.IgnoreCase).Replace(newText, state.ToString)
                                    End If

                                    If waitValue And waitVa >= 0 Then
                                        newText = New Regex("(?<=wait:\s*)[-]?\d+", RegexOptions.IgnoreCase).Replace(newText, waitVa.ToString)
                                    End If

                                    If bpoi Then ChangeOrAdd(newText, "bpoint", bpoiStr, bpoiStrCompleted, frameEnd)
                                    If cpoi Then ChangeOrAdd(newText, "cpoint", cpoiStr, cpoiStrCompleted, frameEnd)
                                    If opoi Then ChangeOrAdd(newText, "opoint", opoiStr, opoiStrCompleted, frameEnd)
                                    If wpoi Then ChangeOrAdd(newText, "wpoint", wpoiStr, wpoiStrCompleted, frameEnd)

                                    If bodies Then
                                        Dim bodies_ As MatchCollection = Regex.Matches(newText, "\s*bdy:.*?bdy_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                                        If bodies_.Count = bodiesStr.Count Then
                                            For j As Integer = bodies_.Count - 1 To 0 Step -1
                                                newText = New Regex(PATTERN_BDY, RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, bodiesStr(j), 1, bodies_(j).Index)
                                            Next
                                        Else
                                            newText = New Regex("\s*bdy:.*?bdy_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, String.Empty)

                                            For Each str As String In bodiesStrCompleted
                                                newText = New Regex(frameEnd, RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, str & frameEnd)
                                            Next
                                        End If
                                    End If

                                    If itrs Then
                                        Dim itrs_ As MatchCollection = Regex.Matches(newText, "\s*itr:.*?itr_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                                        If itrs_.Count = itrsStr.Count Then
                                            For j As Integer = itrs_.Count - 1 To 0 Step -1
                                                newText = New Regex(PATTERN_ITR, RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, itrsStr(j), 1, itrs_(j).Index)
                                            Next
                                        Else
                                            newText = New Regex("\s*itr:.*?itr_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, String.Empty)

                                            For Each str As String In bodiesStrCompleted
                                                newText = New Regex(frameEnd, RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, str & frameEnd)
                                            Next
                                        End If
                                    End If

                                    Scintilla1.TargetStart = frameMatch.Index
                                    Scintilla1.TargetEnd = frameMatch.Index + frameMatch.Length
                                    Scintilla1.ReplaceTarget(newText)
                                End If
                            End If
                        Next

                        If txtFrames.Count > 0 Then
                            Return True
                        End If
                    End If
                    'Dim 
                End If
            End If

            Return False
        End Function

        Private Shared Sub ChangeOrAdd(ByRef newText As String, ByVal poiStr As String, ByVal newContent As String, ByVal completeStr As String, ByVal frameEnd As String)
            If newContent.Length > 0 Then
                If Regex.IsMatch(newText, GetPattern(poiStr), RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then
                    newText = New Regex(GetPattern(poiStr), RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, newContent)
                Else
                    newText = New Regex(frameEnd, RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, completeStr & frameEnd)
                End If
            Else
                newText = New Regex("\s*" & poiStr & ":.*?" & poiStr & "_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Replace(newText, String.Empty)
            End If
        End Sub
    End Class
End Namespace