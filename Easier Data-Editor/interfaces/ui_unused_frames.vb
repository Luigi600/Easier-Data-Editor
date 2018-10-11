Imports System.Text.RegularExpressions

Public Class ui_unused_frames
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private m_oldList As New List(Of Integer)
    Private m_selectedTextEditor As ITextEditor = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub ClearList()
        m_oldList.Clear()
        lv_unused.Items.Clear()
    End Sub

    Public Sub SetList(ByVal fileContent As String, ByVal textEditor As ITextEditor)
        m_selectedTextEditor = textEditor

        Dim refresh As Boolean = False
        Dim usedFrameIDs As New Dictionary(Of Integer, Boolean)
        Dim matches As MatchCollection = Regex.Matches(fileContent, "(?<=^(?!#)\s*<frame>\s*)[0-9]+", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        For Each mtch As Match In matches
            If mtch.Success Then
                If IsNumeric(mtch.Value) Then
                    Dim ID As Integer = Convert.ToInt64(mtch.Value)
                    If Not usedFrameIDs.ContainsKey(ID) Then
                        usedFrameIDs.Add(ID, True)
                    End If
                End If

            End If
        Next


        Dim newList As New Dictionary(Of Integer, Boolean)
        For i As Integer = 0 To 400 - 1
            If Not usedFrameIDs.ContainsKey(i) Then
                newList.Add(i, True)
            End If
        Next


        refresh = Not (m_oldList.Count = newList.Count)

        If Not refresh Then
            For Each i As Integer In newList.Keys
                If Not m_oldList.Contains(i) Then
                    refresh = True
                    Exit For
                End If
            Next
        End If

        If refresh Then
            lv_unused.Items.Clear()
            m_oldList.Clear()

            For Each id As Integer In newList.Keys
                lv_unused.Items.Add(id)
                m_oldList.Add(id)
            Next


            Invalidate()
            lv_unused.Invalidate()
        End If
    End Sub

    Private Sub lv_unused_DoubleClick(sender As ListView, e As EventArgs) Handles lv_unused.DoubleClick
        If sender.SelectedItems.Count > 0 And Not IsNothing(m_selectedTextEditor) Then
            Dim ID As Integer = CType(sender.SelectedItems(0).Text, Integer)
            Dim previousID As Integer = ID
            Do While m_oldList.Contains(previousID)
                previousID -= 1
            Loop

            If previousID < 0 Then
                previousID = 0
            End If

            Dim m_editor As ICSharpCode.AvalonEdit.TextEditor = m_selectedTextEditor.GetAvalonEditor
            Dim mtch As Match = Regex.Match(m_editor.Text, "<frame>\s+(" & previousID & "$|" & previousID & "\s+)", RegexOptions.IgnoreCase)
            If mtch.Success Then
                m_editor.TextArea.Caret.Offset = mtch.Index + If(mtch.Index > 0, -1, 0)
                m_editor.TextArea.Caret.BringCaretToView()
                m_selectedTextEditor.getDockContent.Focus()
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        End If
    End Sub

    Public Function getFreeIDs(ByVal countOfFrames As Integer, Optional ByVal atFrame As Integer = 0) As List(Of Integer)
        If countOfFrames < 0 Then
            Return Nothing
        End If
        Dim result As New SortedList(Of Integer, Boolean)
        Dim freeLengths As New Dictionary(Of Integer, Integer) '1. at frame ID, 2. count of free frames at 1.
        Dim freeLengthsAtFrame As New Dictionary(Of Integer, Integer) 'same like freeLenghts but only with frameID >= atFrame
        Dim totalFreeFramesAtFrame As Integer = 0
        Dim totalFreeFrames As Integer = 0

        Dim lastID As Integer = -1
        For Each freeID As Integer In m_oldList
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
End Class