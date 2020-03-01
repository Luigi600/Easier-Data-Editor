'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports ScintillaNET

Public Class TextEditor
    Inherits Translation.TranslatableDockContent
    Implements IUserItem

    Private Const PATTERN_NEWLINE_LF As String = "(?<=[^\r]+)\n|^\n"
    Private Const PATTERN_NEWLINE_CR As String = "\r$|\r(?=[^\n]+)"
    Private Const PATTERN_NEWLINE_CR_LF As String = "\r\n"

    Private Shared ReadOnly COLOR_MARKER_SAVED As New SolidBrush(CustomScintilla.COLOR_MARKER_SAVED)
    Private Shared ReadOnly COLOR_MARKER_CHANGES As New SolidBrush(CustomScintilla.COLOR_MARKER_CHANGES)
    Private Shared ReadOnly COLOR_MARKER_BOOKMARK As New SolidBrush(CustomScintilla.COLOR_MARKER_BOOKMARK)

    Private Shared ReadOnly ICON_SPLIT_H As Bitmap = My.Resources.icon_splitH
    Private Shared ReadOnly ICON_SPLIT_V As Bitmap = My.Resources.icon_splitH

    Private Shared m_sfd_data As New SaveFileDialog() With {.Filter = "Files|*.dat;*.txt|LF2-Data File|*.dat|Text Files|*.txt"}

    Private m_path As String = ""
    Private m_isSave As Boolean = True
    Private m_viewer As FrameViewer = Nothing
    Private m_lastPosition As Integer = -1

    Private m_changedFromFrameViewer As Boolean = False
    Private m_previousFramesList As New List(Of Integer)
    Private m_lastFrameID As Integer = -1
    Private m_frame As TextFrame = Nothing
    Private m_lastID As Integer = -1
    Private m_setText As Boolean = True
    Private m_lastTextChangedDate As Date = Date.MinValue
    Private m_lastCheckDateOfData As Date = Date.MinValue
    'Private m_checkUnusedIDs As Boolean = True

    Private ReadOnly ChangedLines As New SortedSet(Of Integer)
    Private WithEvents TextChanger As New BackgroundWorker() With {.WorkerSupportsCancellation = True, .WorkerReportsProgress = True}

    Public Shared Sub Prepare()
        ICON_SPLIT_V.RotateFlip(RotateFlipType.Rotate90FlipX)
    End Sub

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatableControls.Add(Me)
    End Sub

    Public Sub New(ByVal id As Integer, ByVal file As String, ByVal firstVisLine As Integer, Optional ByVal bookmarks As String = "")
        Me.New(file, False, firstVisLine, bookmarks)

        Me.ID = id
    End Sub

    Public Sub New(ByVal frameViewer As FrameViewer, ByVal file As String, ByVal firstVisLine As Integer, Optional ByVal bookmarks As String = "")
        Me.New(file, False, firstVisLine, bookmarks)

        Me.ID = frameViewer.ID
        Viewer = frameViewer
    End Sub

    Public Sub New(ByVal file As String, Optional ByVal createFrameViewer As Boolean = False, Optional firstVisLine As Integer = -1, Optional ByVal bookmarks As String = "")
        Variables.Add("ERROR_UNDEFINED", "Undefined attribute '[ATTR]'")
        Variables.Add("SAVE_QUESTION", "Do you want save ""[FILE]""?")
        Variables.Add("SAVE_QUESTION_EXCEPTION", "Do you want save ""[FILE]""? That is your last chance.")
        Variables.Add("SAVE_QUESTION_NO_PATH", "The new file") 'if the file new, it doesn't have a path, so show by save "The new file"
        Variables.Add("SAVE_QUESTION_TITLE", "Easier Data-Editor    -   Save File?")
        Variables.Add("SAVE_QUESTION_EXCEPTION_TITLE", "Easier Data-Editor    -   Save File?")
        Variables.Add("ERROR_ID", "The ID '[ID]' is already used.")
        InitializeComponent()

        Path = file
        FirstVisibleLineFromLastStart = firstVisLine
        If IO.File.Exists(file) Then
            Try
                If IO.Path.GetExtension(file).Substring(1).ToLower.Equals("dat") Then
                    Scintilla1.SetStartText(Functions.DecryptFromData(file))
                Else
                    Scintilla1.SetStartText(IO.File.ReadAllText(file))
                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                IsSave = False
            End Try
        Else
            IsSave = False
        End If

        If createFrameViewer Then
            Viewer = New FrameViewer(Me)
        End If

        For Each numbChar As String In bookmarks.Split(",")
            If IsNumeric(numbChar.Trim) Then
                Dim line As Integer = CInt(numbChar.Trim)
                If line >= 0 And line < Scintilla1.Lines.Count Then
                    Scintilla1.Lines(line).MarkerAdd(EMarkerIndices.Bookmark)
                End If
            End If
        Next
        Pic_scrollbarAnnotations.Visible = App.Settings.ScrollbarAnnotations
        If App.Settings.ScrollbarAnnotations Then
            Tim_annotations.Start()
        End If

        TextChanger.RunWorkerAsync()
        m_setText = False
    End Sub

#Region "Own Events"
    Private Sub Closing_(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        e.Cancel = Not CloseDocument()
        If Not e.Cancel Then
            Controls.Clear()

            If Not IsNothing(m_viewer) Then
                'm_viewer.HideOnClose = False

                m_viewer.Kill()
                m_viewer.Close()
                m_viewer.Dispose()
            End If

            Scintilla1.ClearAll()
            Scintilla1.Dispose()
        End If
    End Sub
#End Region
#Region "Scintilla Events"
    Private Sub Scintilla1_UndoRedoStackChanged(sender As Object, e As Boolean) Handles Scintilla1.UndoRedoStackChanged
        If m_setText Then Exit Sub
        If Not Scintilla1.CanUndo() Then
            Scintilla1.MarkerDeleteAll(EMarkerIndices.Changes)
            IsSave = True
        End If
        RaiseEvent UndoRedoStackChanged(Me, e)
    End Sub

    Private Sub Scintilla1_Delete(sender As Object, e As ModificationEventArgs) Handles Scintilla1.Delete, Scintilla1.Insert
        If Not IsNothing(m_frame) Then
            Dim startIndex As Integer = Scintilla1.LineFromPosition(e.Position)
            For i As Integer = startIndex To startIndex + e.LinesAdded
                If Scintilla1.Lines(i).Text.Contains("frame") Then
                    m_frame.Name = GetRegexValue(Scintilla1.Lines(i).Text, "(?<=\<frame\>\s*\d+\s+)[A-Za-z_\-0-9]+", , "")
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub Editor_TextChanged(sender As Object, e As EventArgs) Handles Scintilla1.TextChanged
        m_lastTextChangedDate = Date.Now
        If m_setText Then Exit Sub

        IsSave = False
        RaiseEvent TextChanged(Me, GetTextLengthAndLineNumbers())

        If Not m_changedFromFrameViewer Then
            SetTextFrameFromLineIndex(Scintilla1.CurrentLine)

            If Scintilla1.CurrentPosition < 1000 And IsNothing(m_frame) Then
                If Not IsNothing(m_viewer) Then
                    m_viewer.HeaderChanged(Scintilla1.GetTextRange(0, If(Scintilla1.TextLength < 1000, Scintilla1.TextLength, 1000)))
                End If
            End If
        End If
    End Sub

    Private Sub Scintilla1_UpdateUI(sender As Object, e As ScintillaNET.UpdateUIEventArgs) Handles Scintilla1.UpdateUI
        If m_setText Then Exit Sub

        If TypeOf sender Is CustomScintilla Then
            Dim scin As CustomScintilla = sender
            If m_lastPosition = scin.CurrentPosition Then
                Exit Sub
            End If
            m_lastPosition = scin.CurrentPosition

            Dim setFrame As Boolean = True
            If Not IsNothing(m_frame) Then
                If scin.CurrentPosition >= m_frame.Offset And scin.CurrentPosition < m_frame.Offset + m_frame.Length Then
                    setFrame = False
                End If
            End If

            If setFrame Then
                Dim lastID As Integer = m_lastID
                SetTextFrameFromLineIndex(scin.CurrentLine)
                If Not lastID = m_lastID Then
                    m_previousFramesList.Clear()
                End If
            End If
        End If
    End Sub
#End Region
#Region "FrameViewer"
    Private Sub ChangeXYFrom(ByVal targetStart As Integer, ByVal targetEnd As Integer, ByVal newX As Integer, ByVal newY As Integer, Optional ByVal searchContentBefore As String = "")
        Scintilla1.TargetStart = targetStart
        Scintilla1.TargetEnd = targetEnd

        Dim newText As String = Scintilla1.TargetText
        newText = Regex.Replace(newText, "(?<=(^" & searchContentBefore & "x:|\s+" & searchContentBefore & "x:)\s*)[0-9-]+", newX, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
        newText = Regex.Replace(newText, "(?<=(^" & searchContentBefore & "y:|\s+" & searchContentBefore & "y:)\s*)[0-9-]+", newY, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
        Scintilla1.ReplaceTarget(newText)
    End Sub

    Private Sub ChangeXYExactly(ByVal targetStart As Integer, ByVal targetEnd As Integer, ByVal newX As Integer, ByVal newY As Integer, Optional ByVal searchContentBefore As String = "")
        Dim textRange As String = Scintilla1.GetTextRange(targetStart, targetEnd)

        Dim xMatch As Match = Regex.Match(textRange, "(?<=(^" & searchContentBefore & "x:|\s+" & searchContentBefore & "x:)\s*)[0-9-]+", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        If xMatch.Success Then
            Scintilla1.TargetStart = targetStart + xMatch.Index
            Scintilla1.TargetEnd = targetStart + xMatch.Index + xMatch.Length
            Scintilla1.ReplaceTarget(newX.ToString)
        End If

        textRange = Scintilla1.GetTextRange(targetStart, targetEnd) 'if centerX has one more or one fewer, the offset is wrong
        Dim yMatch As Match = Regex.Match(textRange, "(?<=(^" & searchContentBefore & "y:|\s+" & searchContentBefore & "y:)\s*)[0-9-]+", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        If yMatch.Success Then
            Scintilla1.TargetStart = targetStart + yMatch.Index
            Scintilla1.TargetEnd = targetStart + yMatch.Index + yMatch.Length
            Scintilla1.ReplaceTarget(newY.ToString)
        End If
    End Sub

    Private Function ChangeXY(ByVal text As String, ByVal newX As Integer, ByVal newY As Integer, Optional ByVal searchContentBefore As String = "") As String
        text = Regex.Replace(text, "(?<=(^" & searchContentBefore & "x:|\s+" & searchContentBefore & "x:)\s*)[0-9-]+", newX, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
        text = Regex.Replace(text, "(?<=(^" & searchContentBefore & "y:|\s+" & searchContentBefore & "y:)\s*)[0-9-]+", newY, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
        Return text
    End Function
#End Region
#Region "Edit"
    Private Sub CMS_actions_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_actions.Opening
        TSMI_cut.Enabled = Scintilla1.SelectedText.Length > 0
        TSMI_copy.Enabled = Scintilla1.SelectedText.Length > 0
        TSMI_delete.Enabled = Scintilla1.SelectedText.Length > 0

        TSMI_paste.Enabled = Scintilla1.CanPaste ' My.Computer.Clipboard.ContainsText
        TSMI_paste_cool.Enabled = My.Computer.Clipboard.ContainsText

        TSMI_frameViewer.Enabled = Not IsNothing(m_viewer)
        TSMI_frameViewer.Checked = If(IsNothing(m_viewer), False, Not m_viewer.IsHidden)
    End Sub

    Private Sub Editor_Cut(sender As Object, e As EventArgs) Handles TSMI_cut.Click
        Cut()
    End Sub

    Private Sub Editor_Copy(sender As Object, e As EventArgs) Handles TSMI_copy.Click
        Copy()
    End Sub

    Private Sub Editor_Paste(sender As Object, e As EventArgs) Handles TSMI_paste.Click
        Paste()
    End Sub

    Private Sub Editor_PasteCool(sender As Object, e As EventArgs) Handles TSMI_paste_cool.Click
        PasteCool()
    End Sub

    Private Sub Editor_Delete(sender As Object, e As EventArgs) Handles TSMI_delete.Click
        Delete()
    End Sub

    Private Sub Editor_SelectAll(sender As Object, e As EventArgs) Handles TSMI_selectAll.Click
        SelectAll()
    End Sub

    Private Sub TSMI_frameViewer_Click(sender As Object, e As EventArgs) Handles TSMI_frameViewer.Click
        RaiseEvent ChangeFrameViewerState(Viewer, TSMI_frameViewer.Checked)
    End Sub
#End Region
#Region "Splitter"
    Private Sub Splitter_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter.SplitterMoved
        If Not Splitter.Panel2Collapsed Then
            If Splitter.SplitterDistance < SPLITTER_MINIMUM_HEIGHT Or
                        (Splitter.Orientation = Orientation.Vertical And Splitter.SplitterDistance >= Splitter.Width - SPLITTER_MINIMUM_HEIGHT + 12) Or
                        (Splitter.Orientation = Orientation.Horizontal And Splitter.SplitterDistance >= Splitter.Height - SPLITTER_MINIMUM_HEIGHT + 12) Then

                Split = -1
            End If
        End If
    End Sub

    Private Sub Splitter_ControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded, Splitter.ControlAdded, Splitter.Panel1.ControlAdded, Splitter.Panel2.ControlAdded
        If TypeOf e.Control Is CustomScintilla Then
            If Not e.Control.Name.Equals(Scintilla1.Name) Then
                AddHandler CType(e.Control, CustomScintilla).UndoRedoStackChanged, AddressOf Scintilla1_UndoRedoStackChanged
                'AddHandler CType(e.Control, Scintilla).UpdateUI, AddressOf Scintilla1_UpdateUI
                CType(e.Control, CustomScintilla).ClearCmdKey(Keys.Control Or Keys.S)
            End If
        End If
    End Sub

    Private Sub Splitter_ControlRemoved(sender As Object, e As ControlEventArgs) Handles Me.ControlRemoved, Splitter.ControlRemoved, Splitter.Panel1.ControlRemoved, Splitter.Panel2.ControlRemoved
        If TypeOf e.Control Is CustomScintilla Then
            If Not e.Control.Name.Equals(Scintilla1.Name) Then
                'RemoveHandler CType(e.Control, Scintilla).UpdateUI, AddressOf Scintilla1_UpdateUI
            End If
        End If
    End Sub

    Dim m_addToPoi As Integer = 0
    Private Sub Btn_split_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_split.MouseMove
        If e.Button = MouseButtons.Left Then
            If Splitter.Orientation = Orientation.Horizontal Then
                Dim newY As Integer = PointToClient(MousePosition).Y - m_addToPoi
                If newY < -1 Then
                    newY = -1
                ElseIf newY > Height - Btn_split.Height Then
                    newY = Height - Btn_split.Height
                End If
                Btn_split.Location = New Point(Btn_split.Location.X, newY)
            Else
                Dim newX As Integer = PointToClient(MousePosition).X - m_addToPoi
                If newX < -1 Then
                    newX = -1
                ElseIf newX > Splitter.Width - Btn_split.Width Then
                    newX = Splitter.Width - Btn_split.Width
                End If
                Btn_split.Location = New Point(newX, Btn_split.Location.Y)
            End If
        End If
    End Sub

    Private Sub Btn_split_MouseDown(sender As Object, e As MouseEventArgs) Handles Btn_split.MouseDown
        If Splitter.Orientation = Orientation.Horizontal Then
            m_addToPoi = e.Y
        Else
            m_addToPoi = e.X
        End If
    End Sub

    Private Sub Btn_split_MouseUp(sender As Object, e As MouseEventArgs) Handles Btn_split.MouseUp
        If e.Button = MouseButtons.Left Then
            If Btn_split.Location.Y > 10 Then
                Split(Btn_split.Location.Y) = Orientation.Horizontal
            ElseIf Math.Abs(Btn_split.Location.X + Btn_split.Width - Scintilla1.Width) > 10 Then
                Split(Btn_split.Location.X) = Orientation.Vertical
            Else
                Btn_split.Location = New Drawing.Point(Btn_split.Location.X, -1)
            End If
        End If
    End Sub

    Private Sub Splitter_DragOver(sender As Object, e As DragEventArgs) Handles Splitter.DragOver
        RaiseEvent DragOverEventOfEditor(Me, e)
    End Sub

    Private Sub Splitter_DragEnter(sender As Object, e As DragEventArgs) Handles Splitter.DragEnter
        RaiseEvent DragEnterEventOfEditor(Me, e)
    End Sub

    Private Sub Splitter_DragDrop(sender As Object, e As DragEventArgs) Handles Splitter.DragDrop
        RaiseEvent DropEventOfEditor(Me, e)
    End Sub
#End Region

    Private Sub SetTextFrameFromLineIndex(ByVal lineIndex As Integer, Optional ByVal fireEvent As Boolean = True)
        Dim index As Integer = lineIndex
        Dim lastFrameWasNothing As Boolean = IsNothing(m_frame)
        m_frame = Nothing
        Dim frameStartIndex As Integer = -1

        m_lastID = -1

        Do While True
            If index < 0 Or index < lineIndex - 100 Or lineIndex >= Scintilla1.Lines.Count Then
                Exit Do
            End If

            Dim line As Line = Scintilla1.Lines(index)
            If line.Text.Trim.ToLower.Contains("<frame_end>") And Not index = lineIndex Then
                m_lastID = -5
                Exit Do
            End If

            Dim mtch As Match = Regex.Match(line.Text, "(?<=<frame>\s*)\d+", RegexOptions.IgnoreCase)
            If mtch.Success Then
                Integer.TryParse(mtch.Value, m_lastID)
                frameStartIndex = line.Index

                Exit Do
            End If

            index -= 1
        Loop

        If frameStartIndex >= 0 Then
            Dim line As Line = Scintilla1.Lines(frameStartIndex)
            m_frame = New TextFrame() With {.Offset = line.Position}
            m_frame.Name = GetRegexValue(line.Text, "(?<=\<frame\>\s*\d+\s+)[A-Za-z_\-0-9]+", , "")
            SetFrameOffsetFrom(frameStartIndex)
        End If


        If Not IsNothing(m_frame) Or IsNothing(m_frame) And Not lastFrameWasNothing Then
            If Not IsNothing(m_viewer) AndAlso Not m_changedFromFrameViewer Then m_viewer.FrameChanged(m_frame)
            If fireEvent Then RaiseEvent ChangeFrame(Me, m_frame)
        End If

        'If Not IsNothing(MainWindow) Then
        '    MainWindow.SetFrameName(FrameNames.Keys.ToList().IndexOf(CurrentFrameName()))
        'End If
    End Sub

    Private Sub SetFrameOffsetFrom(ByVal lineIndex As Integer)
        If Not IsNothing(m_frame) Then
            m_frame.OffsetBodies.Clear()
            m_frame.OffsetItrs.Clear()
            Dim index As Integer = lineIndex

            Do While True
                If index <= 0 Or index > lineIndex + 100 Or index >= Scintilla1.Lines.Count Then
                    Exit Do
                End If

                Dim line As Line = Scintilla1.Lines(index)
                If line.Text.Trim.ToLower.StartsWith("<frame_end>") Then
                    m_frame.Length = line.EndPosition - m_frame.Offset
                    m_frame.Lines = Scintilla1.GetTextRange(m_frame.Offset, m_frame.Length)
                    Exit Do
                End If

                index += 1
            Loop


            Dim bodies As MatchCollection = Regex.Matches(m_frame.Lines, PATTERN_BDY, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            For Each mtc As Match In bodies
                If mtc.Success Then
                    m_frame.OffsetBodies.Add(New Point(m_frame.Offset + mtc.Index, m_frame.Offset + mtc.Index + mtc.Length))
                End If
            Next

            Dim itrs As MatchCollection = Regex.Matches(m_frame.Lines, PATTERN_ITR, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            For Each mtc As Match In itrs
                If mtc.Success Then
                    m_frame.OffsetItrs.Add(New Drawing.Point(m_frame.Offset + mtc.Index, m_frame.Offset + mtc.Index + mtc.Length))
                End If
            Next



            Dim bpoint As Match = Regex.Match(m_frame.Lines, PATTERN_BPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If bpoint.Success Then
                m_frame.OffsetBPoint = New Drawing.Point(m_frame.Offset + bpoint.Index, m_frame.Offset + bpoint.Index + bpoint.Length)
            End If
            Dim wpoint As Match = Regex.Match(m_frame.Lines, PATTERN_WPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If wpoint.Success Then
                m_frame.OffsetWPoint = New Drawing.Point(m_frame.Offset + wpoint.Index, m_frame.Offset + wpoint.Index + wpoint.Length)
            End If
            Dim cpoint As Match = Regex.Match(m_frame.Lines, PATTERN_CPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If cpoint.Success Then
                m_frame.OffsetCPoint = New Drawing.Point(m_frame.Offset + cpoint.Index, m_frame.Offset + cpoint.Index + cpoint.Length)
            End If
            Dim opoint As Match = Regex.Match(m_frame.Lines, PATTERN_OPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If opoint.Success Then
                m_frame.OffsetOPoint = New Drawing.Point(m_frame.Offset + opoint.Index, m_frame.Offset + opoint.Index + opoint.Length)
            End If
        End If
    End Sub

    Private Enum EReportRaiseEvent
        [Error]
        UnusedIDs
    End Enum
    Private Sub TextChanger_DoWork(sender As Object, e As DoWorkEventArgs) Handles TextChanger.DoWork
        Do While Not TextChanger.CancellationPending
            If Visible Then
                If m_lastTextChangedDate.CompareTo(m_lastCheckDateOfData) > 0 AndAlso (Date.Now - m_lastCheckDateOfData).TotalMilliseconds > 1000 Then
                    m_lastCheckDateOfData = Date.Now
                    FindErrors()
                    FindFrames()
                    Console.WriteLine("CHECK: " & Path.ToString)
                End If

                'If m_checkUnusedIDs Then
                '    FindFrames()
                '    Console.WriteLine("CHECK IDS: " & Path.ToString)
                'End If
            End If
            Threading.Thread.Sleep(2000)
        Loop
    End Sub

    Private Sub FindErrors()
        Errors.Clear()
        Dim totalText As String = CustomScintilla.GetTextThreadSafety(Scintilla1)
        Dim unknownChars As New List(Of Point) 'X = offset, Y = length 

        Dim sortedList As List(Of RangeSyntax) = App.CustomSyntax.GetStyleRanges(0, totalText.Length, totalText)
        Dim sortedIndex As Integer = 0
        Dim currentPosition As Integer = 0

        Do While currentPosition < totalText.Length
            Dim found As Boolean = False
            Dim [step] As Integer = 1

            For i As Integer = sortedIndex To sortedList.Count - 1
                Dim rng As RangeSyntax = sortedList(i)
                If currentPosition >= rng.Range.X And currentPosition < rng.Range.Y Then
                    [step] = rng.Range.Y - currentPosition
                    found = True
                    sortedIndex = i
                    Exit For
                End If
            Next
            If currentPosition + [step] > totalText.Length Then
                [step] = totalText.Length - currentPosition
            End If

            If Not found Then
                unknownChars.Add(New Point(currentPosition, [step]))
            End If
            currentPosition += [step]
        Loop

        If unknownChars.Count > 1 Then
            Dim startIndex As Integer = 0
            Do While startIndex + 1 < unknownChars.Count
                Dim item1 As Point = unknownChars(startIndex)
                Dim item2 As Point = unknownChars(startIndex + 1)
                If item1.X + item1.Y = item2.X Then
                    unknownChars(startIndex) = New Point(item1.X, item1.Y + item2.Y)
                    unknownChars.RemoveAt(startIndex + 1)
                Else
                    startIndex += 1
                End If
            Loop
        End If

        For Each unknowOffset As Point In unknownChars
            Dim line As Integer = CustomScintilla.LineFromPositionThreadSafety(Scintilla1, unknowOffset.X)
            Errors.Add(New ErrorItem(GetVariable("ERROR_UNDEFINED").
                                     Replace("[ATTR]", totalText.Substring(unknowOffset.X, unknowOffset.Y)), 'substring get the undefinded thing
                                     unknowOffset.X, unknowOffset.X + unknowOffset.Y, line, m_path))
        Next

        Dim alreadyIDs As New HashSet(Of Integer)
        For Each mtch As Match In Regex.Matches(totalText, "(?<=frame\>\s*)\d+")
            Dim id As Integer = CInt(mtch.Value.Trim)
            If Not alreadyIDs.Add(id) Then
                Dim line As Integer = CustomScintilla.LineFromPositionThreadSafety(Scintilla1, mtch.Index)
                Errors.Add(New ErrorItem(GetVariable("ERROR_ID").
                                         Replace("[ID]", id), 'substring get the undefinded thing
                                         mtch.Index, mtch.Index + mtch.Length, line, m_path))
            End If
        Next
        Console.WriteLine("Amount of Errors: " & Errors.Count)
        TextChanger.ReportProgress(EReportRaiseEvent.Error)
    End Sub

    Private Sub FindFrames()
        Frames.Clear()
        UnusedIDs.Clear()

        Dim text As String = CustomScintilla.GetTextThreadSafety(Scintilla1)
        Dim usedIDs As New List(Of UnusedIDItem)
        For Each mtch As Match In Regex.Matches(text, "(?<=^(?!#)\s*<frame>\s*)[0-9]+[^\n\r#]+", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If mtch.Success Then
                Dim ind As Integer = GetRegexValueInteger(mtch.Value, "^[0-9]+", RegexOptions.IgnoreCase)
                Dim lineIndex As Integer = CustomScintilla.LineFromPositionThreadSafety(Scintilla1, mtch.Index)
                Dim name As String = GetRegexValue(mtch.Value, "(?<=[0-9]+\s+).*",, "").Trim
                If ind >= 0 Then
                    usedIDs.Add(New UnusedIDItem(ind, 1, lineIndex))
                End If

                If Not Frames.ContainsKey(name) Then
                    Frames.Add(name, lineIndex - 1)
                End If
            End If
        Next
        usedIDs = usedIDs.OrderBy(Function(x) x.ID).ToList
        Dim lastUsedFrame As Integer = 0
        For Each usedItem As UnusedIDItem In usedIDs
            Dim diff As Integer = usedItem.ID - lastUsedFrame
            If diff > 0 Then
                UnusedIDs.Add(New UnusedIDItem(lastUsedFrame, diff, usedItem.Line))
            End If
            lastUsedFrame = usedItem.ID + 1
        Next
        TextChanger.ReportProgress(EReportRaiseEvent.UnusedIDs)
    End Sub

    Private Sub TextChanger_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles TextChanger.ProgressChanged
        If e.ProgressPercentage = EReportRaiseEvent.Error Then
            RaiseEvent ErrorsChecked(Me, True)
        ElseIf e.ProgressPercentage = EReportRaiseEvent.UnusedIDs Then
            RaiseEvent UnusedIDsChecked(Me, True)
        End If
    End Sub

    Private Sub Pic_scrollbarAnnotations_Paint(sender As Object, e As PaintEventArgs) Handles Pic_scrollbarAnnotations.Paint
        With e.Graphics
            'If Scintilla1.HScrollBar = False Then
            '    PictureBox1.Height = Scintilla1.Height - 17 * 2
            'Else
            '    PictureBox1.Height = Scintilla1.Height - 17 * 2
            'End If
            Dim lineCounter As Integer = Scintilla1.CountOfVisibleLines
            Dim factor As Single = Pic_scrollbarAnnotations.Height / lineCounter
            Dim lineSize As Integer = Math.Ceiling(factor)
            If lineSize < 4 Then
                lineSize = 4
            End If
            Dim bookmarkMask As UInteger = 1 << EMarkerIndices.Bookmark
            Dim savedMask As UInteger = 1 << EMarkerIndices.Saved
            Dim changesMask As UInteger = 1 << EMarkerIndices.Changes

            'e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle)

            For Each entry As KeyValuePair(Of Integer, UInteger) In Scintilla1.Overview
                Dim x As Single = factor * entry.Key - lineSize / 2

                If (entry.Value And bookmarkMask) = bookmarkMask Then
                    .FillRectangle(COLOR_MARKER_BOOKMARK, New RectangleF(3, x, 3, lineSize))
                End If

                If (entry.Value And savedMask) = savedMask Then
                    .FillRectangle(COLOR_MARKER_SAVED, New RectangleF(6, x, 3, lineSize))
                ElseIf (entry.Value And changesMask) = changesMask Then
                    .FillRectangle(COLOR_MARKER_CHANGES, New RectangleF(6, x, 3, lineSize))
                End If
            Next

            For Each errorItm As ErrorItem In Errors
                Dim saveLine As Line = Scintilla1.Lines(errorItm.Line)
                Do While Not saveLine.Visible AndAlso saveLine.FoldParent >= 0
                    saveLine = Scintilla1.Lines(saveLine.FoldParent)
                Loop
                .FillRectangle(Brushes.Red, New RectangleF(0, factor * saveLine.Index, 3, lineSize))
            Next

            .FillRectangle(Brushes.DarkBlue, New RectangleF(0, factor * Scintilla1.CurrentLine + 1, e.ClipRectangle.Width, 2))
        End With
    End Sub

    Private Sub Tim_annotations_Tick(sender As Object, e As EventArgs) Handles Tim_annotations.Tick
        Scintilla1.TestOverview()
        Pic_scrollbarAnnotations.Invalidate()
    End Sub
End Class