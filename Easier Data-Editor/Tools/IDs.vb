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
    ''' <summary>Represents tools to change IDs of frames.</summary>
    Public Class IDs
        ''' <summary>Adjusts the IDs of text which contains frames.</summary>
        ''' <param name="scintilla">The editor which is the paste target. To try find unused frame IDs of the current position and in a row.</param>
        ''' <param name="rawText">The text which contains the frames, which should adjust.</param>
        ''' <returns>The adjusted text if successful. Otherwise "rawText".</returns>
        Public Shared Function GetAdjustedIDs(ByVal scintilla As ScintillaNET.Scintilla, ByVal rawText As String) As String
            If Not String.IsNullOrEmpty(rawText) AndAlso rawText.Length > 5 Then
                Dim inputFrames As MatchCollection = Regex.Matches(rawText, PATTERN_FRAME_CONTENT, RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Multiline)
                Dim unusedFrameList As New List(Of Integer)
                If inputFrames.Count > 0 Then
                    Dim frameAt As Integer = 0

                    Dim rgxAt As New Regex("(?<=<frame>\s*)[0-9]+", RegexOptions.IgnoreCase Or RegexOptions.RightToLeft)
                    Dim mtchAt As Match = rgxAt.Match(scintilla.Text, scintilla.CurrentPosition)
                    If mtchAt.Success Then
                        If IsNumeric(mtchAt.Value.Trim) Then
                            frameAt = CInt(mtchAt.Value.Trim)
                        End If
                    Else
                        Dim firstFrame As Match = inputFrames(0)
                        If firstFrame.Success Then
                            frameAt = GetRegexValueInteger(firstFrame.Value, "(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase, 0)
                        End If
                    End If

                    unusedFrameList.AddRange(IDs.GetFreeIDs(IDs.GetUsedFrameIDs(scintilla.Text).ToList(), inputFrames.Count, frameAt))

                    If unusedFrameList.Count = inputFrames.Count Then
                        Dim oldIDsToNew As New Dictionary(Of Integer, Integer)
                        Dim indexID As Integer = unusedFrameList.Count - 1
                        For i As Integer = inputFrames.Count - 1 To 0 Step -1
                            Dim frame As Match = inputFrames(i)
                            If frame.Success Then
                                Dim frameID As Integer = GetRegexValueInteger(frame.Value, "(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase)

                                If frameID >= 0 And frameID < 399 Then
                                    Dim rgx As New Regex("(?<=\<frame\>\s*)" & frameID, RegexOptions.IgnoreCase)
                                    rawText = rgx.Replace(rawText, unusedFrameList(indexID).ToString, 1, frame.Index)

                                    If Not oldIDsToNew.ContainsKey(frameID) Then
                                        oldIDsToNew.Add(frameID, unusedFrameList(indexID))
                                        indexID -= 1
                                    End If
                                End If
                            End If
                        Next


                        For i As Integer = inputFrames.Count - 1 To 0 Step -1
                            Dim frame As Match = inputFrames(i)
                            If frame.Success Then
                                Dim nextID As Integer = GetRegexValueInteger(frame.Value, "(?<=next:\s*)[-0-9]+", RegexOptions.IgnoreCase, 400)

                                If Math.Abs(nextID) < 399 Then
                                    If oldIDsToNew.ContainsKey(Math.Abs(nextID)) Then
                                        Dim newID As Integer = oldIDsToNew(Math.Abs(nextID))
                                        If nextID < 0 Then
                                            newID *= -1
                                        End If

                                        Dim rgx As New Regex("(?<=next:\s*)" & nextID, RegexOptions.IgnoreCase)
                                        rawText = rgx.Replace(rawText, newID.ToString, 1, frame.Index)
                                    End If
                                End If


                                Dim hites As MatchCollection = Regex.Matches(frame.Value, "hit_[A-Za-z]+:\s*[-0-9]+", RegexOptions.IgnoreCase)
                                For k As Integer = hites.Count - 1 To 0 Step -1
                                    Dim hit As Match = hites(k)
                                    If hit.Success Then
                                        Dim hitVal As Integer = GetRegexValueInteger(hit.Value, "(?<=hit_[A-Za-z]+:\s*)[-0-9]+", RegexOptions.IgnoreCase, -400)
                                        Dim hitName As String = GetRegexValue(hit.Value, "hit_[A-Za-z]+:", RegexOptions.IgnoreCase)
                                        If hitVal > -399 And hitVal < 399 And Not hitVal = 0 And Not IsNothing(hitName) Then

                                            If oldIDsToNew.ContainsKey(Math.Abs(hitVal)) Then
                                                Dim newID As Integer = oldIDsToNew(Math.Abs(hitVal))
                                                If hitVal < 0 Then
                                                    newID *= -1
                                                End If

                                                Dim rgx As New Regex("(?<=" & hitName & "\s*)[-0-9]+", RegexOptions.IgnoreCase)
                                                rawText = rgx.Replace(rawText, newID.ToString, 1, frame.Index)
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        Next

                        Return rawText
                    End If
                End If
            End If

            Return rawText
        End Function

        Public Shared Function GetUsedFrameIDs(ByVal rawText As String) As HashSet(Of Integer)
            Dim result As New HashSet(Of Integer)

            For Each mtch As Match In Regex.Matches(rawText, "(?<=^(?!#)\s*<frame>\s*)[0-9]+[^\n\r#]+", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                If mtch.Success Then
                    Dim ind As Integer = GetRegexValueInteger(mtch.Value, "^[0-9]+", RegexOptions.IgnoreCase)
                    If ind >= 0 Then
                        result.Add(ind)
                    End If
                End If
            Next

            Return result
        End Function

        Public Shared Function GetFreeIDs(ByVal usedIDs As List(Of Integer), ByVal countOfFrames As Integer, Optional ByVal atFrame As Integer = 0) As List(Of Integer)
            If countOfFrames < 0 Then
                Return Nothing
            End If
            Dim result As New SortedList(Of Integer, Boolean)
            Dim freeLengths As New Dictionary(Of Integer, Integer) '1. at frame ID, 2. count of free frames at 1.
            Dim freeLengthsAtFrame As New Dictionary(Of Integer, Integer) 'same like freeLenghts but only with frameID >= atFrame
            Dim totalFreeFramesAtFrame As Integer = 0
            Dim totalFreeFrames As Integer = 0

            Dim freeIDs As New List(Of Integer)
            For i As Integer = 0 To 399
                If Not usedIDs.Contains(i) Then
                    freeIDs.Add(i)
                End If
            Next

            Dim lastID As Integer = -1
            For Each freeID As Integer In freeIDs
                If lastID < 0 And Not freeLengths.ContainsKey(freeID) Then
                    freeLengths.Add(freeID, 1)
                ElseIf lastID >= 0 Then
                    If freeID - lastID = 1 Then
                        freeLengths(freeLengths.Last.Key) += 1
                    ElseIf Not freeLengths.ContainsKey(freeID) Then
                        freeLengths.Add(freeID, 1)
                    End If
                End If



                If freeID >= atFrame Then
                    Dim add As Boolean = True
                    If lastID >= 0 And freeID - lastID = 1 And freeLengthsAtFrame.Count > 0 Then
                        freeLengthsAtFrame(freeLengthsAtFrame.Last.Key) += 1
                        add = False
                    End If
                    If add Then
                        freeLengthsAtFrame.Add(freeID, 1)
                    End If
                End If

                lastID = freeID
            Next

            For Each cou As Integer In freeLengthsAtFrame.Values
                totalFreeFramesAtFrame += cou
            Next
            For Each cou As Integer In freeLengths.Values
                totalFreeFrames += cou
            Next




            Dim inRow As Boolean = False
            Dim frameStartIndex As Integer = -1

            If totalFreeFramesAtFrame >= countOfFrames Then
                For Each entry As KeyValuePair(Of Integer, Integer) In freeLengthsAtFrame
                    If entry.Value >= countOfFrames Then
                        inRow = True
                        frameStartIndex = entry.Key
                        Exit For
                    End If
                Next
            End If

            If Not inRow Then
                For Each entry As KeyValuePair(Of Integer, Integer) In freeLengths
                    If entry.Key <= atFrame Then
                        If entry.Value >= countOfFrames Then
                            inRow = True
                            frameStartIndex = entry.Key
                            Exit For
                        End If
                    End If
                Next
            End If


            If inRow Then
                inRow = False 'if the next "if-statement" false
                If freeLengths.ContainsKey(frameStartIndex) Then
                    If freeLengths(frameStartIndex) >= countOfFrames Then
                        inRow = True
                        For i As Integer = frameStartIndex To frameStartIndex + countOfFrames - 1
                            result.Add(i, True)
                        Next
                    End If
                End If
            End If




            If Not inRow Then
                If totalFreeFrames >= countOfFrames Then
                    Dim sorted As IOrderedEnumerable(Of KeyValuePair(Of Integer, Integer)) = From pair In freeLengths
                                                                                             Order By pair.Value
                    Dim sortedDictionary As Dictionary(Of Integer, Integer) = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)

                    For Each entry As KeyValuePair(Of Integer, Integer) In sortedDictionary.Reverse
                        If totalFreeFramesAtFrame >= countOfFrames And entry.Key >= atFrame Or totalFreeFramesAtFrame < countOfFrames Then
                            For i As Integer = entry.Key To entry.Key + entry.Value - 1
                                result.Add(i, True)
                                If result.Count >= countOfFrames Then
                                    Exit For
                                End If
                            Next

                            If result.Count >= countOfFrames Then
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If



            Return result.Keys.ToList
        End Function

        Public Shared Sub SortFrames(ByVal Scintilla1 As CustomScintilla)
            Scintilla1.BlockUndoRedoActions = True
            Dim frames As New Dictionary(Of Integer, List(Of String))

            Dim startIndex As Integer = 0
            Dim mtches As MatchCollection = New Regex("[\n\r]*\s*\<frame\>\s*\d+.*?\<frame_end\>", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Matches(Scintilla1.Text)
            For i As Integer = mtches.Count - 1 To 0 Step -1
                Dim mtch As Match = mtches(i)
                If mtch.Success Then
                    startIndex = mtch.Index

                    Dim frameID As Integer = GetRegexValueInteger(mtch.Value, "(?<=\<frame\>\s*)\d+", RegexOptions.IgnoreCase)
                    If Not frames.ContainsKey(frameID) Then
                        frames.Add(frameID, New List(Of String))
                    End If

                    frames(frameID).Add(mtch.Value)

                    Scintilla1.TargetStart = mtch.Index
                    Scintilla1.TargetEnd = mtch.Index + mtch.Length
                    Scintilla1.ReplaceTarget(String.Empty)
                End If
            Next

            Dim frameOrder As List(Of Integer) = frames.Keys.ToList
            frameOrder.Sort()
            frameOrder.Reverse()

            For Each ind As Integer In frameOrder
                For Each frame As String In frames(ind)
                    Scintilla1.InsertText(startIndex, frame)
                Next
            Next

            Scintilla1.BlockUndoRedoActions = False
        End Sub

        Public Shared Sub IncreaseIDs(ByVal m_editor As CustomScintilla, ByVal value As Integer, ByVal setValues As Boolean, ByVal changeHitValues As Boolean, ByVal changePicValues As Boolean)
            Dim idChangeRegex As New Regex("(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase)
            Dim frames As New List(Of RegexMatchCloner)

            m_editor.BlockUndoRedoActions = True

            For Each selection As ScintillaNET.Selection In m_editor.Selections
                For Each mtch As Match In Regex.Matches(m_editor.GetTextRange(selection.Start, selection.End - selection.Start),
                                                        "\<frame\>\s*\d+.*?\<frame_end\>", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                    If mtch.Success Then
                        frames.Add(New RegexMatchCloner(mtch.Index + selection.Start, selection.Start + mtch.Index + mtch.Length, mtch.Value))
                    End If
                Next
            Next

            If setValues Then value += frames.Count - 1

            For k As Integer = frames.Count - 1 To 0 Step -1
                Dim frame As RegexMatchCloner = frames(k)
                Dim frameID As Integer = GetRegexValueInteger(frame.Value, "(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase)
                If frameID >= 0 And frameID < 399 Then
                    If Not setValues Then
                        frameID += value
                    Else
                        frameID = value
                    End If

                    If frameID < 0 Then
                        frameID = 0
                    End If

                    m_editor.TargetStart = frame.Index
                    m_editor.TargetEnd = frame.End
                    m_editor.ReplaceTarget(idChangeRegex.Replace(m_editor.TargetText, frameID.ToString, 1, 0))

                    frame.End += m_editor.TargetEnd - frame.End
                End If


                Dim nextVal As Integer = GetRegexValueInteger(frame.Value, "(?<=next:\s*)[-0-9]+", RegexOptions.IgnoreCase)
                If nextVal > -399 And nextVal < 399 Then
                    If Not setValues Then
                        If nextVal < 0 Then
                            nextVal -= value
                        Else
                            nextVal += value
                        End If
                    Else
                        If nextVal < 0 Then
                            nextVal = value - 1
                        Else
                            nextVal = value + 1
                        End If
                    End If
                    Dim rgx As New Regex("(?<=next:\s*)[-0-9]+", RegexOptions.IgnoreCase)
                    m_editor.TargetStart = frame.Index
                    m_editor.TargetEnd = frame.End
                    m_editor.ReplaceTarget(rgx.Replace(m_editor.TargetText, nextVal.ToString, 1, 0))
                    frame.End += m_editor.TargetEnd - frame.End
                End If


                If changePicValues Then
                    Dim picID As Integer = GetRegexValueInteger(frame.Value, "(?<=pic:\s*)[0-9]+", RegexOptions.IgnoreCase)
                    If picID >= 0 Then
                        If Not setValues Then
                            picID += value
                        Else
                            picID = value
                        End If

                        If picID < 0 Then
                            picID = 0
                        End If
                        Dim rgx As New Regex("(?<=pic:\s*)[0-9]+", RegexOptions.IgnoreCase)
                        m_editor.TargetStart = frame.Index
                        m_editor.TargetEnd = frame.End
                        m_editor.ReplaceTarget(rgx.Replace(m_editor.TargetText, picID.ToString, 1, 0))
                        frame.End += m_editor.TargetEnd - frame.End
                    End If
                End If


                If changeHitValues Then
                    Dim hites As MatchCollection = Regex.Matches(frame.Value, "hit_[A-Za-z]+:\s*[-0-9]+", RegexOptions.IgnoreCase)
                    For i As Integer = hites.Count - 1 To 0 Step -1
                        Dim hit As Match = hites(i)
                        If hit.Success Then
                            Dim hitVal As Integer = GetRegexValueInteger(hit.Value, "(?<=hit_[A-Za-z]+:\s*)[-0-9]+", RegexOptions.IgnoreCase, -400)
                            Dim hitName As String = GetRegexValue(hit.Value, "hit_[A-Za-z]+:", RegexOptions.IgnoreCase)
                            If hitVal > -399 And hitVal < 399 And Not hitVal = 0 And Not IsNothing(hitName) Then
                                If Not setValues Then
                                    If hitVal < 0 Then
                                        hitVal -= value
                                    Else
                                        hitVal += value
                                    End If
                                Else
                                    hitVal = value
                                End If
                                Dim rgx As New Regex("(?<=" & hitName & "\s*)[-0-9]+", RegexOptions.IgnoreCase)
                                m_editor.TargetStart = frame.Index
                                m_editor.TargetEnd = frame.End
                                m_editor.ReplaceTarget(rgx.Replace(m_editor.TargetText, hitVal.ToString, 1, 0))
                                frame.End += m_editor.TargetEnd - frame.End
                            End If
                        End If
                    Next
                End If


                If setValues Then
                    value -= 1
                End If
            Next

            m_editor.BlockUndoRedoActions = False
        End Sub
    End Class
End Namespace