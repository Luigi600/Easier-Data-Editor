'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text
Imports System.Text.RegularExpressions
Imports ScintillaNET

''' <summary>Represents a Scintilla.NET editor with extensions. Includes also a few LF2 special functions.</summary>
Public Class CustomScintilla
    Inherits Scintilla

    Private Shared ReadOnly FoldingTags As New List(Of String()) From {New String() {"<frame>", "<frame_end>"},
                                                                       New String() {"<bmp_begin>", "<bmp_end>"},
                                                                       New String() {"layer:", "layer_end"},
                                                                       New String() {"<stage>", "<stage_end>"}}

    Private Shared ReadOnly FoldingTagsTest As New List(Of String()) From {New String() {"bdy:", "bdy_end:"},
                                                                           New String() {"itr:", "itr_end:"},
                                                                           New String() {"bpoint:", "bpoint_end:"},
                                                                           New String() {"cpoint:", "cpoint_end:"},
                                                                           New String() {"opoint:", "opoint_end:"},
                                                                           New String() {"wpoint:", "wpoint_end:"},
                                                                           New String() {"<phase>", "<phase_end>"}}

    Private Shared FoldingTagsPattern As New StringBuilder()
    Private Shared FoldingTagsPatternTest As New StringBuilder()

    Private Const LINE_NUMBER_PADDING As Integer = 5
    Private Const MARKER_BOOKMARK As MarkerSymbol = MarkerSymbol.Circle

    Private m_undoActionIsClosed As Boolean = True
    Private m_startUndoByLine As Integer = -1
    Private m_lastTextChangedDate As Date = Date.MinValue
    Private m_lastClickOnDocument As Date = Date.MinValue
    Private m_blockUndoRedoActions As Boolean = False
    Private m_blockTextChangedEvent As Boolean = False
    Private m_maxLineNumberCharLength As Integer = 1
    Private m_setText As Boolean = False
    Private m_syntax As Syntax = App.CustomSyntax
    Private m_settings As Settings = App.Settings
    Private m_undoCounter As Integer = -1
    Private m_lastFoldingState As Boolean = False
    Private m_lastSubfoldingState As Boolean = False

    Public Event UndoRedoStackChanged As EventHandler(Of Boolean)
    Public Property SuppressFoldingCheck As Boolean = False

    Public Shared ReadOnly COLOR_MARKER_SAVED As Color = Color.FromArgb(108, 226, 108)
    Public Shared ReadOnly COLOR_MARKER_CHANGES As Color = Color.FromArgb(255, 238, 98)
    Public Shared ReadOnly COLOR_MARKER_BOOKMARK As Color = Color.DeepSkyBlue

    Private Const SCI_SETCARETLINEVISIBLEALWAYS As Integer = 2655

    Public Sub New()
        If FoldingTagsPattern.Length = 0 Then
            For Each foldingStr As String() In FoldingTags
                If foldingStr.Count = 2 Then
                    If FoldingTagsPattern.Length > 0 Then
                        FoldingTagsPattern.Append("|"c)
                    End If

                    '<frame>((?!<frame>).)*</frame>
                    FoldingTagsPattern.Append("(").
                                       Append(foldingStr(0)).
                                       Append("((?!").Append(foldingStr(0)).Append(").)*").
                                       Append(foldingStr(1)).Append(")")
                End If
            Next

            For Each foldingStr As String() In FoldingTagsTest
                If foldingStr.Count = 2 Then
                    If FoldingTagsPatternTest.Length > 0 Then
                        FoldingTagsPatternTest.Append("|"c)
                    End If
                    FoldingTagsPatternTest.Append("(").
                                       Append(foldingStr(0)).
                                       Append("((?!").Append(foldingStr(0)).Append(").)*").
                                       Append(foldingStr(1)).Append(")")
                End If
            Next
        End If

        ClearCmdKey(Keys.Control Or Keys.S)
        ClearCmdKey(Keys.Control Or Keys.K)
        ClearCmdKey(Keys.Control Or Keys.L)
        ClearCmdKey(Keys.Control Or Keys.J)
        ClearCmdKey(Keys.ControlKey Or Keys.J)

        SetFirstStyle()
        ReloadStyle()
        BeginUndoAction()
        m_lastTextChangedDate = Date.MinValue
    End Sub
    'https://docs.microsoft.com/de-de/dotnet/api/system.windows.forms.scrollbarrenderer?view=netframework-4.8

    Public ReadOnly Property Overview As New Dictionary(Of Integer, UInteger)
    Public ReadOnly Property CountOfVisibleLines As Integer
        Get
            Return Lines.Where(Function(x) x.Visible).Count
        End Get
    End Property

    Public Sub TestOverview()
        Overview.Clear()
        Dim lineIndex As Integer = 0
        Do While True
            Dim oldIndex As Integer = lineIndex
            lineIndex = Lines(lineIndex).MarkerNext(1 << EMarkerIndices.Bookmark Or 1 << EMarkerIndices.Changes Or 1 << EMarkerIndices.Saved)
            If lineIndex >= 0 AndAlso lineIndex >= oldIndex Then
                Dim saveLine As Line = Lines(lineIndex)
                Do While Not saveLine.Visible AndAlso saveLine.FoldParent >= 0
                    saveLine = Lines(saveLine.FoldParent)
                Loop
                If Overview.ContainsKey(saveLine.Index) Then
                    Overview(saveLine.Index) = Overview(saveLine.Index) Or saveLine.MarkerGet()
                Else
                    Overview.Add(saveLine.Index, saveLine.MarkerGet())
                End If
                lineIndex += 1
            Else
                Exit Do
            End If
        Loop
    End Sub
#Region "Overrides"
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        'TestOverview()

        If Not m_blockTextChangedEvent Then
            If Not m_setText Then
                m_lastTextChangedDate = Date.Now
            End If

            Dim maxLineNumberCharLength As Integer = Lines.Count.ToString.Length
            If maxLineNumberCharLength <> m_maxLineNumberCharLength Then
                m_maxLineNumberCharLength = maxLineNumberCharLength
                ChangeWidthOfNumberMargin()
            End If

            MyBase.OnTextChanged(e)
        End If
    End Sub

    Protected Overrides Sub OnStyleNeeded(e As StyleNeededEventArgs)
        Dim startPos As Integer = GetEndStyled()
        'Dim firstLine As Line = Scintilla1.Lines(Scintilla1.FirstVisibleLine)
        Dim linePos As Integer = LineFromPosition(startPos)
        startPos = Lines(linePos).Position
        'If startPos < firstLine.Index Then
        '    startPos = firstLine.Index
        'End If

        HighlightingSyntax(startPos, e.Position)
    End Sub

    Protected Overrides Sub OnBeforeDelete(e As BeforeModificationEventArgs)
        If Not e.Source = ModificationSource.User Then
            ' EndScintillaUndoAction()
        ElseIf Not m_blockUndoRedoActions Then
            Dim clickDiff As Double = (Date.Now - m_lastClickOnDocument).TotalSeconds
            If (Date.Now - m_lastTextChangedDate).TotalSeconds > 1.0 Or clickDiff >= 0 And clickDiff <= 1.0 Then
                m_lastClickOnDocument = Date.MinValue
                EndUndoAction()
            End If
        End If

        MyBase.OnBeforeDelete(e)
    End Sub

    Protected Overrides Sub OnDelete(e As ModificationEventArgs)
        Dim startIndex As Integer = LineFromPosition(e.Position)
        'For i As Integer = startIndex To startIndex + e.LinesAdded
        Dim line As Line = Lines(startIndex)
        line.MarkerAdd(EMarkerIndices.Changes)
        CheckFoldingFromLines(startIndex, 0)
        'If Not m_blockTextChangedEvent And Not SuppressFoldingCheck Then
        '    GetCheckRangeForFolding(line)
        'End If
        'Next

        If Not m_blockTextChangedEvent Then
            If (Date.Now - m_lastTextChangedDate).TotalSeconds > 1.0 Then
                RaiseEvent UndoRedoStackChanged(Me, True)
            End If
        End If

        MyBase.OnDelete(e)
    End Sub

    Protected Overrides Sub OnInsertCheck(e As InsertCheckEventArgs)
        If Not m_setText Then
            Dim hasLineBreak As Boolean = e.Text.EndsWith("\r") Or e.Text.EndsWith("\n") Or e.Text.EndsWith(vbCrLf) Or e.Text.EndsWith(vbCr) Or e.Text.EndsWith(vbLf)

            If m_settings.Folding Then
                Dim line As Line = Lines(LineFromPosition(e.Position))
                If hasLineBreak AndAlso Not line.Expanded Then
                    line.ToggleFold()
                    IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
                    IndicatorClearRange(line.Position, line.Length)
                End If
            End If

            If m_settings.Indention Then
                If hasLineBreak Then
                    Dim curLine As Line = Lines(LineFromPosition(e.Position))
                    e.Text &= Regex.Match(curLine.Text, "^[^\S\r\n]*").Value
                End If
            End If
        End If

        MyBase.OnInsertCheck(e)
    End Sub

    Protected Overrides Sub OnBeforeInsert(e As BeforeModificationEventArgs)
        If Not m_setText Then
            If Not e.Source = ModificationSource.User Then
                ' EndScintillaUndoAction()
            ElseIf Not m_blockUndoRedoActions Then
                IndicatorCurrent = EIndicatorIndices.TmpHighlight
                IndicatorClearRange(0, TextLength)

                Dim clickDiff As Double = (Date.Now - m_lastClickOnDocument).TotalSeconds
                If (Date.Now - m_lastTextChangedDate).TotalSeconds > 1.0 Or clickDiff >= 0 And clickDiff <= 1.0 Then
                    m_lastClickOnDocument = Date.MinValue
                    BeginUndoAction()
                End If
            End If
        End If

        MyBase.OnBeforeInsert(e)
    End Sub

    Protected Overrides Sub OnInsert(e As ModificationEventArgs)
        If Not m_setText Then
            If m_settings.Folding Then
                Dim line As Line = Lines(LineFromPosition(e.Position))
                If Not line.Expanded Then
                    IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
                    IndicatorFillRange(e.Position, e.Text.Length)
                End If
            End If

            Dim startIndex As Integer = LineFromPosition(e.Position)
            For i As Integer = startIndex To startIndex + e.LinesAdded
                Lines(i).MarkerAdd(EMarkerIndices.Changes)
            Next
            CheckFoldingFromLines(startIndex, e.LinesAdded)
            'If m_settings.Folding And Not SuppressFoldingCheck Then
            '    Dim ranges As New List(Of FoldingRange)
            '    For i As Integer = startIndex To startIndex + e.LinesAdded
            '        Dim ignore As Boolean = False
            '        For Each rng As FoldingRange In ranges
            '            If i >= rng.StartLine AndAlso i <= rng.EndLine Then
            '                ignore = True
            '                Exit For
            '            End If
            '        Next

            '        If Not ignore Then
            '            Dim rng As FoldingRange = GetCheckRangeForFolding(Lines(i))
            '            If Not IsNothing(rng) Then
            '                ranges.Add(rng)
            '            End If
            '        End If
            '    Next

            '    Console.WriteLine(ranges.Count)
            'End If

            If Not m_blockTextChangedEvent Then
                If (Date.Now - m_lastTextChangedDate).TotalSeconds > 1.0 Then
                    'Debug.WriteLine(m_lastTextChangedDate.ToString)
                    RaiseEvent UndoRedoStackChanged(Me, True)
                End If
            End If
        End If

        MyBase.OnInsert(e)
    End Sub

    Protected Overrides Sub OnZoomChanged(e As EventArgs)
        If Not m_setText Then
            ChangeWidthOfNumberMargin()
            If m_settings.ShowChanges Then
                ' Margins(MarginIndices.TextChanges).Width = 100 / 4 * (Zoom * 0.5 + 4)
            End If
        End If

        MyBase.OnZoomChanged(e)
    End Sub

    Protected Overrides Sub OnUpdateUI(e As UpdateUIEventArgs)
        If Not m_setText Then
            If e.Change = UpdateChange.Selection Then
                IndicatorCurrent = EIndicatorIndices.ResultInSelection
                IndicatorClearRange(0, TextLength)
            End If
        End If

        MyBase.OnUpdateUI(e)
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.HandleCreatedOriginal(e)
    End Sub

    Protected Overrides Sub OnDragEnter(drgevent As DragEventArgs)
        MyBase.OnDragEnter(drgevent)
    End Sub

    Private Sub ChangeWidthOfNumberMargin()
        If m_settings.ShowLineNumbers Then
            Margins(EMarginIndices.LineNumber).Width = TextWidth(Style.LineNumber, New String("9"c, m_maxLineNumberCharLength + 1)) + LINE_NUMBER_PADDING
        End If
    End Sub

#Region "User direct interactions (clicks)"
    Protected Overrides Sub OnMarginClick(e As MarginClickEventArgs)
        Dim line As Line = Lines(LineFromPosition(e.Position))
        If e.Margin = EMarginIndices.Folding Then
            FoldingToggleLine(line)
        ElseIf e.Margin = EMarginIndices.Bookmark Then
            If LineHasMarker(line, EMarkerIndices.Bookmark) Then
                line.MarkerDelete(EMarkerIndices.Bookmark)
            Else
                line.MarkerAdd(EMarkerIndices.Bookmark)
            End If
        Else
            SetSelection(line.Position, line.Position + line.Length)
        End If

        MyBase.OnMarginClick(e)
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        m_lastClickOnDocument = Date.Now

        IndicatorCurrent = EIndicatorIndices.TmpHighlight
        IndicatorClearRange(0, TextLength)

        Debug.WriteLine("{0} {1} {2}", PointXFromPosition(e.X), PointYFromPosition(e.Y), CurrentLine)

        MyBase.OnMouseClick(e)
    End Sub

    Protected Overrides Sub OnDoubleClick(e As DoubleClickEventArgs)
        If m_settings.Folding Then
            If Not Lines(CurrentLine).Expanded Then
                Dim line As Line = Lines(CurrentLine)
                line.ToggleFold()
                IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
                IndicatorClearRange(line.Position, line.Length)

                HighlightingSyntax(line.Position, line.EndPosition)
                Exit Sub
            End If
        End If

        If e.Position >= 0 Then
            Dim selectedWord As String = GetWordFromPosition(e.Position)
            If selectedWord.Trim.Length > 0 Then
                IndicatorCurrent = EIndicatorIndices.TmpHighlight
                TargetStart = 0
                TargetEnd = TextLength

                While SearchInTarget(selectedWord) <> -1
                    IndicatorFillRange(TargetStart, TargetEnd - TargetStart)
                    TargetStart = TargetEnd
                    TargetEnd = TextLength
                End While
            End If
        End If
    End Sub
#End Region
#End Region

#Region "'Overrides' / Extend Scintilla Functions"
    Public Shadows Sub FoldAll(ByVal action As FoldAction)
        MyBase.FoldAll(action)
        If action = FoldAction.Contract Then
            IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
            For Each line As Line In Lines
                If line.FoldLevelFlags = FoldLevelFlags.Header AndAlso line.FoldParent < 0 Then
                    IndicatorFillRange(line.Position, line.Length)
                End If
            Next
        ElseIf action = FoldAction.Expand Then
            IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
            IndicatorClearRange(0, TextLength)
        End If

        HighlightingSyntax(0, TextLength)
    End Sub
    Public Shadows Sub BeginUndoAction()
        Dim oldState As Boolean = m_undoActionIsClosed
        EndUndoAction()
        MyBase.BeginUndoAction()
        m_undoActionIsClosed = False
        Debug.WriteLine("Begin Undo Action")
        ' If Not oldState Then RaiseEvent UndoRedoStackChanged(Me, True)
        m_startUndoByLine = CurrentLine
    End Sub

    Public Shadows Sub EndUndoAction()
        If Not m_undoActionIsClosed Then
            m_undoCounter += 1
            MyBase.EndUndoAction()
            m_undoActionIsClosed = True
            Debug.WriteLine("End Undo Action")
            RaiseEvent UndoRedoStackChanged(Me, True)
        End If
    End Sub

    Public Shadows Sub Undo()
        m_blockTextChangedEvent = True
        m_undoCounter -= 2
        BeginUndoAction()
        MyBase.Undo()
        m_blockTextChangedEvent = False
        OnTextChanged(EventArgs.Empty)
        RaiseEvent UndoRedoStackChanged(Me, True)
    End Sub

    Public Shadows Sub Redo()
        m_blockTextChangedEvent = True
        BeginUndoAction()
        MyBase.Redo()
        m_blockTextChangedEvent = False
        OnTextChanged(EventArgs.Empty)
        RaiseEvent UndoRedoStackChanged(Me, False)
    End Sub

    Public Shadows Sub Paste()
        BeginUndoAction()
        MyBase.Paste()
        m_lastTextChangedDate = Date.MinValue
    End Sub

    Public Shadows Sub EmptyUndoBuffer()
        MyBase.EmptyUndoBuffer()
        RaiseEvent UndoRedoStackChanged(Me, True)
    End Sub

    Public Shadows Property Document As Document
        Get
            Return MyBase.Document
        End Get
        Set(value As Document)
            MyBase.Document = value
            m_setText = True
            OnTextChanged(EventArgs.Empty)
            m_setText = False
        End Set
    End Property

    Public Sub GoToLine(ByVal line As Integer)
        If line < 0 Then
            line = 0
        ElseIf line >= Lines.Count Then
            line = Lines.Count - 1
        End If

        GotoPosition(Math.Max(0, Lines(line).EndPosition - 1))
    End Sub

    Public Function DeleteKey() As Boolean
        If SelectedText.Count = 0 Then
            Dim deleteChar As String = GetTextRange(CurrentPosition, 1)
            If deleteChar.Equals(vbCr) Then
                If CurrentPosition + 1 < TextLength Then
                    If GetTextRange(CurrentPosition + 1, 1).Equals(vbLf) Then
                        deleteChar &= vbLf 'just extend the length
                    End If
                End If
            End If
            DeleteRange(CurrentPosition, deleteChar.Length)
            Return True
        End If

        Return False
    End Function

    Public Sub GoToNextBookmark()
        For i As Integer = CurrentLine + 1 To Lines.Count + CurrentLine
            Dim indexLine As Integer = i Mod Lines.Count
            Dim line As Line = Lines(indexLine)
            If LineHasMarker(line, EMarkerIndices.Bookmark) Then
                line.Goto()
                Exit For
            End If
        Next
    End Sub

    Public Sub GoToPreviousBookmark()
        For i As Integer = 1 To Lines.Count
            Dim indexLine As Integer = (CurrentLine - i) Mod Lines.Count
            If indexLine < 0 Then indexLine += Lines.Count
            Dim line As Line = Lines(indexLine)
            If LineHasMarker(line, EMarkerIndices.Bookmark) Then
                line.Goto()
                Exit For
            End If
        Next
    End Sub

    Public Sub CutBookmarkedLines()
        Dim lines As New StringBuilder()
        Dim markedLines As List(Of Line) = GetBookmarkedLines()
        If markedLines.Count > 0 Then
            BeginUndoAction()
            For i As Integer = markedLines.Count - 1 To 0 Step -1
                Dim line As Line = markedLines(i)
                lines.Insert(0, line.Text)
                line.MarkerDelete(EMarkerIndices.Bookmark)
                DeleteRange(line.Position, line.Length)
            Next
            EndUndoAction()
        End If

        My.Computer.Clipboard.SetText(lines.ToString)
    End Sub

    Public Sub CopyBookmarkedLines()
        Dim lines As New StringBuilder()
        For Each line As Line In GetBookmarkedLines()
            lines.Append(line.Text)
        Next
        My.Computer.Clipboard.SetText(lines.ToString)
    End Sub

    Public Sub PasteToBookmarkedLines(ByVal replaceTo As String)
        Dim markedLines As List(Of Line) = GetBookmarkedLines()
        For i As Integer = markedLines.Count - 1 To 0 Step -1
            Dim line As Line = markedLines(i)
            TargetStart = line.Position
            TargetEnd = line.EndPosition
            ReplaceTarget(replaceTo)
        Next
    End Sub

    Public Sub RemoveBookmarkedLines()
        Dim markedLines As List(Of Line) = GetBookmarkedLines()
        If markedLines.Count > 0 Then
            BeginUndoAction()
            For i As Integer = markedLines.Count - 1 To 0 Step -1
                Dim line As Line = markedLines(i)
                line.MarkerDelete(EMarkerIndices.Bookmark)
                DeleteRange(line.Position, line.Length)
            Next
            EndUndoAction()
        End If
    End Sub

    Public Sub RemoveUnmarkedLines()
        BeginUndoAction()
        Dim unmarked As New List(Of Integer)
        For i As Integer = 0 To Lines.Count - 1
            unmarked.Add(i)
        Next
        unmarked = unmarked.Except(GetBookmarkedLinesIndices()).ToList
        For i As Integer = unmarked.Count - 1 To 0 Step -1
            Dim line As Line = Lines(unmarked(i))
            DeleteRange(line.Position, line.Length)
        Next
        EndUndoAction()
    End Sub

    Public Sub InvertBookmarks()
        For Each line As Line In Lines
            If LineHasMarker(line, EMarkerIndices.Bookmark) Then
                line.MarkerDelete(EMarkerIndices.Bookmark)
            Else
                line.MarkerAdd(EMarkerIndices.Bookmark)
            End If
        Next
    End Sub

    Private Function GetBookmarkedLines() As List(Of Line)
        Dim result As New List(Of Line)
        For Each line As Line In Lines
            If LineHasMarker(line, EMarkerIndices.Bookmark) Then
                result.Add(line)
            End If
        Next

        Return result
    End Function

    Public Function GetBookmarkedLinesIndices() As List(Of Integer)
        Return GetBookmarkedLines().Select(Function(x) x.Index).ToList
    End Function

    Public Function LineHasMarker(ByVal line As Line, ByVal marker As EMarkerIndices)
        Dim mask_ As UInteger = 1 << EMarkerIndices.Bookmark
        Return (line.MarkerGet() And mask_) > 0
    End Function
#End Region

#Region "Public Functions"
    Public Property BlockUndoRedoActions As Boolean
        Get
            Return m_blockUndoRedoActions
        End Get
        Set(value As Boolean)
            If Not value = m_blockUndoRedoActions Then
                m_blockUndoRedoActions = value
                If value Then
                    BeginUndoAction()
                Else
                    EndUndoAction()
                End If
            End If
        End Set
    End Property

    Public Property Syntax As Syntax
        Get
            Return m_syntax
        End Get
        Set(value As Syntax)
            If IsNothing(value) Then
                m_syntax = App.CustomSyntax
            Else
                m_syntax = value
            End If
            ReloadStyle()
        End Set
    End Property

    Public Property Settings As Settings
        Get
            Return m_settings
        End Get
        Set(value As Settings)
            If IsNothing(value) Then
                m_settings = App.Settings
            Else
                m_settings = value
            End If
            SetFirstStyle()
            ReloadStyle()
        End Set
    End Property

    Public ReadOnly Property UndoSize As Integer
        Get
            Return m_undoCounter
        End Get
    End Property

    Public Sub SetStartText(ByVal text As String)
        Dim emptyBuffer As Boolean = Me.Text.Length = 0 And Not CanUndo
        m_setText = True
        EndUndoAction()
        Me.Text = text
        m_setText = False
        If emptyBuffer Then
            EmptyUndoBuffer()
        End If
        BeginUndoAction()
        Folding(0, TextLength, False)
    End Sub

    Public Sub FoldingToggleLine(ByVal line As Line)
        If line.FoldLevelFlags = FoldLevelFlags.Header Then
            If Not line.Expanded Then
                IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
                IndicatorClearRange(line.Position, line.Length)

                HighlightingSyntax(line.Position, line.EndPosition)
            Else
                IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
                Dim lineStr As String = line.Text.Trim
                IndicatorFillRange(line.Position + (line.Length - line.Text.TrimStart.Length), lineStr.Length)

                StartStyling(line.Position)
                SetStyling(line.EndPosition - line.Position, StylesIndices.FolderCollapsed)
            End If
            line.ToggleFold()
        End If
    End Sub
#End Region

#Region "Syntax & Style"
    Private Sub SetFirstStyle()
        Lexer = Lexer.Container
        Margins.Left = 5
        Margins.Capacity = 10
        AutomaticFold = False

        'so scrollbar size...
        ScrollWidth = 10
        ScrollWidthTracking = True

        'nice selection feature
        MultipleSelection = True
        MouseSelectionRectangularSwitch = True
        AdditionalSelectionTyping = True
        VirtualSpaceOptions = VirtualSpace.RectangularSelection

        'whitespace
        WhitespaceSize = 3
        SetWhitespaceForeColor(True, Color.LightGray)

        'SetFoldMarginColor(True, Color.White)

        With Margins(EMarginIndices.LineNumber)
            .Type = MarginType.Number
            .Sensitive = False
            .Mask = 0
            .Width = 0
        End With

        '--- spacing between line number and "changes bar"
        With Margins(EMarginIndices.TextChangesSpacing)
            .Type = MarginType.Symbol
            .Mask = 0
            .Width = 0
        End With

        '--- changes (shows orange/green bar)
        With Margins(EMarginIndices.TextChanges)
            .Type = MarginType.Symbol
            .Mask = 1 << EMarkerIndices.Saved Or 1 << EMarkerIndices.Changes
            .Width = 0
        End With
        With Markers(EMarkerIndices.Saved)
            .Symbol = MarkerSymbol.FullRect
            .SetBackColor(COLOR_MARKER_SAVED)
        End With
        With Markers(EMarkerIndices.Changes)
            .Symbol = MarkerSymbol.FullRect
            .SetBackColor(COLOR_MARKER_CHANGES)
        End With

        '--- spacing between "change bar" and bookmark
        With Margins(EMarginIndices.BookmarkSpacing)
            .Type = MarginType.Symbol
            .Mask = 0
            .Width = 0
        End With

        '--- bookmark
        With Margins(EMarginIndices.Bookmark)
            .Type = MarginType.Symbol
            .Sensitive = True
            .Mask = 1 << EMarkerIndices.Bookmark
            .Width = 0
            ' .Margins(MarginIndices.Bookmark).Cursor = MarginCursor.Arrow
        End With
        With Markers(EMarkerIndices.Bookmark)
            .Symbol = MARKER_BOOKMARK
            .SetBackColor(COLOR_MARKER_BOOKMARK)
            .SetForeColor(Color.Black)
        End With

        With Margins(EMarginIndices.Folding)
            .Type = MarginType.Symbol
            .Sensitive = True
            .Mask = Marker.MaskFolders
            .Width = 0
            SetFoldMarginColor(True, Color.FromArgb(233, 233, 233))

            Markers(Marker.FolderEnd).Symbol = MarkerSymbol.BoxPlus
            Markers(Marker.FolderOpenMid).Symbol = MarkerSymbol.BoxMinus
            Markers(Marker.FolderOpen).Symbol = MarkerSymbol.BoxMinus
            Markers(Marker.FolderMidTail).Symbol = MarkerSymbol.TCorner
            Markers(Marker.FolderTail).Symbol = MarkerSymbol.LCorner
            Markers(Marker.FolderSub).Symbol = MarkerSymbol.VLine
            Markers(Marker.Folder).Symbol = MarkerSymbol.BoxPlus


            For i As Integer = Marker.FolderEnd To Marker.FolderOpen
                Markers(i).SetBackColor(Color.DarkGray)
                Markers(i).SetForeColor(Color.White)
            Next
        End With

        'Indicators
        '--- errors
        With Indicators(EIndicatorIndices.Error)
            .Style = IndicatorStyle.Squiggle  'StraightBox
            .Under = True
            .ForeColor = Color.Orange
            .Alpha = 255
            ' .OutlineAlpha = 100
        End With
        With Indicators(EIndicatorIndices.SyntaxUnknown)
            .Style = IndicatorStyle.Squiggle  'StraightBox
            .Under = True
            .ForeColor = Color.Red
        End With

        '--- selections
        With Indicators(EIndicatorIndices.ResultInSelection)
            .Style = IndicatorStyle.StraightBox
            .Under = False
            .ForeColor = Color.Blue
            .Alpha = 50
        End With

        With Indicators(EIndicatorIndices.Highlight)
            .Style = IndicatorStyle.StraightBox
            .Under = False
            .ForeColor = Color.Red
            .Alpha = 50
        End With

        With Indicators(EIndicatorIndices.TmpHighlight)
            .Style = IndicatorStyle.StraightBox
            .Under = False
            .ForeColor = Color.Lime  'Color.FromArgb(155, 255, 155)
            ' .HoverForeColor = Color.Black
            .Alpha = 120
        End With

        With Indicators(EIndicatorIndices.FoldingCollapsed)
            .Style = IndicatorStyle.FullBox
            .Under = False
            .ForeColor = Color.Green
            .HoverForeColor = Color.Blue
            .OutlineAlpha = 100
            .Alpha = 0
        End With
    End Sub

    Public Sub ReloadStyle()
        If Not m_settings.Folding Then
            FoldAll(FoldAction.Expand)
        ElseIf Not m_lastFoldingState Or m_settings.Subfolding AndAlso Not m_lastSubfoldingState Then
            Folding(0, Lines.Count - 1, False)
        End If

        m_lastFoldingState = m_settings.Folding
        m_lastSubfoldingState = m_settings.Subfolding


        With Styles(StylesIndices.Default)
            .Font = m_settings.FontFamily
            .Size = m_settings.FontSize

            .BackColor = m_syntax.DefaultBackColor
            .ForeColor = m_syntax.DefaultColor
        End With
        StyleClearAll()
        Styles(StylesIndices.FolderCollapsed).ForeColor = Color.DimGray
        ' Styles(Style.FoldDisplayText).ForeColor = Color.Pink

        Styles(StylesIndices.LineNumber).BackColor = Color.FromArgb(228, 228, 228)
        Styles(StylesIndices.LineNumber).ForeColor = Color.FromArgb(128, 128, 128)

        WrapMode = m_settings.WrapMode

        CaretLineBackColor = m_settings.MarkLineColor ' Color.FromArgb(235, 235, 255)
        CaretLineVisible = m_settings.MarkCurrentLine
        DirectMessage(SCI_SETCARETLINEVISIBLEALWAYS, If(CaretLineVisible, 1, 0), 0)

        ViewWhitespace = If(m_settings.ShowWhitespaces, WhitespaceMode.VisibleAlways, WhitespaceMode.Invisible)
        Styles(StylesIndices.LineNumber).Visible = m_settings.ShowLineNumbers

        If m_settings.ShowLineNumbers Then
            Margins(EMarginIndices.LineNumber).Width = TextWidth(Style.LineNumber, New String("9"c, m_maxLineNumberCharLength + 1)) + LINE_NUMBER_PADDING
        Else
            Margins(EMarginIndices.LineNumber).Width = 0
        End If

        If m_settings.ShowLineNumbers Then
            Margins(EMarginIndices.TextChangesSpacing).Width = 3
        Else
            Margins(EMarginIndices.TextChangesSpacing).Width = 0
        End If

        If m_settings.ShowChanges Then
            Margins(EMarginIndices.TextChanges).Width = 4
            Markers(EMarkerIndices.Changes).Symbol = MarkerSymbol.FullRect
            Markers(EMarkerIndices.Saved).Symbol = MarkerSymbol.FullRect
        Else
            Margins(EMarginIndices.TextChanges).Width = 0
            Markers(EMarkerIndices.Changes).Symbol = MarkerSymbol.Empty
            Markers(EMarkerIndices.Saved).Symbol = MarkerSymbol.Empty
        End If

        'spacing between bookmarks and "change bar"
        If m_settings.Bookmarks AndAlso (m_settings.ShowChanges Or (m_settings.ShowLineNumbers And Not m_settings.ShowChanges)) Then
            Margins(EMarginIndices.BookmarkSpacing).Width = 2
        Else
            Margins(EMarginIndices.BookmarkSpacing).Width = 0
        End If

        'bookmarks
        If m_settings.Bookmarks Then
            Margins(EMarginIndices.Bookmark).Width = 16
            Markers(EMarkerIndices.Bookmark).Symbol = MARKER_BOOKMARK
        Else
            Margins(EMarginIndices.Bookmark).Width = 0
            Markers(EMarkerIndices.Bookmark).Symbol = MarkerSymbol.Empty
        End If

        'folding
        If m_settings.Folding Then
            Margins(EMarginIndices.Folding).Width = 15
        Else
            Margins(EMarginIndices.Folding).Width = 0
        End If



        'set styles
        Dim styleCounter As Byte = 0
        Dim items As New List(Of SyntaxItem)
        items.AddRange(m_syntax.RegexSpecials)
        items.AddRange(m_syntax.SingleWordRegex)
        items.AddRange(m_syntax.KeywordItems)
        For Each item As SyntaxItem In items
            item.StyleIndex = styleCounter

            If Not item.BackColor.Equals(Color.Transparent) Then
                Styles(styleCounter).BackColor = item.BackColor
            End If

            If Not item.ForeColor.Equals(Color.Transparent) Then
                Styles(styleCounter).ForeColor = item.ForeColor
            End If

            Styles(styleCounter).Bold = item.IsBold
            Styles(styleCounter).Italic = item.IsItalic

            styleCounter = item.StyleIndex + 1 'do that, because perhaps its +2 coz the number exists already in the style enum
        Next
        items.Clear()
    End Sub

    Private Sub HighlightingSyntax(ByVal startPos As Integer, ByVal endPos As Integer)
        'Dim startTime As Date = Date.Now
        Dim range As New Text.StringBuilder(GetTextRange(startPos, endPos - startPos))
        Dim bitmapFlagFoldingCollapsed As Integer = 1 << EIndicatorIndices.FoldingCollapsed

        Dim addedStyleRange As New List(Of RangeSyntax)

        For Each spaceMatch As Match In Regex.Matches(range.ToString, "\s+")
            addedStyleRange.Add(New RangeSyntax(startPos + spaceMatch.Index, spaceMatch.Length, StylesIndices.Default))
        Next

        If m_settings.Folding Then
            For lineIndex As Integer = LineFromPosition(startPos) To LineFromPosition(endPos)
                Dim line As Line = Lines(lineIndex)
                If Not line.Expanded And (IndicatorAllOnFor(line.Position) And bitmapFlagFoldingCollapsed) = bitmapFlagFoldingCollapsed Then
                    If line.Position + line.Length < endPos Then
                        addedStyleRange.Add(New RangeSyntax(line.Position, line.Length, StylesIndices.FolderCollapsed))
                        range = range.Remove(line.Position - startPos, line.Length)
                        range = range.Insert(line.Position - startPos, " "c, line.Length)
                    End If
                End If
            Next
        End If

        For Each regexItem As SyntaxItemRegex In m_syntax.RegexSpecials
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

                For Each regexItem As SyntaxItemRegex In m_syntax.SingleWordRegex
                    Dim mtc As Match = Regex.Match(val, regexItem.Pattern)
                    If mtc.Success Then
                        style = regexItem.StyleIndex
                        Exit For
                    End If
                Next


                If style < 0 Then
                    For Each syn As SyntaxItemKeywords In m_syntax.KeywordItems
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

        ' Dim startTest As Date = Date.Now
        Dim sortedList As List(Of RangeSyntax) = addedStyleRange.OrderBy(Function(o) o.Range.Y).ToList()
        Dim sortedIndex As Integer = 0

        IndicatorCurrent = EIndicatorIndices.SyntaxUnknown
        IndicatorClearRange(startPos, endPos - startPos)
        StartStyling(startPos)

        Do While startPos < endPos
            Dim found As Boolean = False
            Dim [step] As Integer = 1
            Dim style As Integer = StylesIndices.Default

            For i As Integer = sortedIndex To sortedList.Count - 1
                Dim rng As RangeSyntax = sortedList(i)
                If startPos >= rng.Range.X And startPos < rng.Range.Y Then
                    [step] = rng.Range.Y - startPos
                    found = True
                    style = rng.Style
                    sortedIndex = i
                    Exit For
                End If
            Next
            If startPos + [step] > endPos Then
                [step] = endPos - startPos
            End If

            SetStyling([step], style)

            If Not found Then
                IndicatorFillRange(startPos, [step])
            End If
            startPos += [step]
        Loop

        'Console.WriteLine("syntax loading: {0} (set {1})", (Date.Now - startTime).TotalMilliseconds, (Date.Now - startTest).TotalMilliseconds)
    End Sub
#End Region

#Region "LF Specials"
    Public Function GetOffsetFromFrame(ByVal frameId As Integer) As Integer
        Dim mtch As Match = Regex.Match(Text, "<frame>\s+(" & frameId & "$|" & frameId & "\s+)", RegexOptions.IgnoreCase)
        If mtch.Success Then
            Return mtch.Index
        End If

        Return -1
    End Function

    Public Function GoToFrame(ByVal frameID As Integer) As Boolean
        Dim frameOffset As Integer = GetOffsetFromFrame(frameID)
        If frameOffset >= 0 Then
            Dim goToLine As Integer = LineFromPosition(frameOffset)
            'goToLine += Scintilla1.LinesOnScreen
            'If goToLine >= Scintilla1.Lines.Count Then
            '    goToLine = Scintilla1.Lines.Count - 1
            'End If
            'Scintilla1.GotoPosition(mtch.Index)

            GotoPosition(Math.Max(0, Lines(goToLine).EndPosition - 1))
            Return True
        End If

        Return False
    End Function

    Private Sub CheckFoldingFromLines(ByVal lineStart As Integer, ByVal countOfLines As Integer)
        If m_settings.Folding And Not SuppressFoldingCheck Then
            Dim ranges As New List(Of FoldingRange)
            For i As Integer = lineStart To lineStart + countOfLines
                Dim ignore As Boolean = False
                For Each rng As FoldingRange In ranges
                    If i >= rng.StartLine AndAlso i <= rng.EndLine Then
                        ignore = True
                        Exit For
                    End If
                Next

                If Not ignore Then
                    Dim rng As FoldingRange = GetCheckRangeForFolding(Lines(i))
                    If Not IsNothing(rng) Then
                        ranges.Add(rng)
                    End If
                End If
            Next

            If ranges.Count = 0 Then
                'Dim foldStart As Integer = -1
                'For i As Integer = lineStart To lineStart + countOfLines
                '    Dim line As Line = Lines(i)
                '    If line.FoldParent >= 0 Then
                '        foldStart = line.FoldParent
                '        Exit For
                '    End If
                'Next

                'If foldStart >= 0 Then
                '    Dim line As Line = Lines(foldStart)
                '    Do While line.Index + 1 < Lines.Count
                '        line = Lines(line.Index + 1)
                '        If line.FoldLevelFlags = FoldLevelFlags.Header Or Not line.FoldParent = foldStart Then
                '            Exit Do
                '        End If
                '    Loop

                '    ranges.Add(New FoldingRange(foldStart + 1, If(line.Index = Lines.Count - 1, line.Index, line.Index - 1), True))
                'End If
            End If

            For Each rng As FoldingRange In ranges
                Folding(rng.StartLine, rng.EndLine, True, rng.IsSubfolding)
            Next
        End If
    End Sub

    Private Class FoldingRange
        Public ReadOnly StartLine As Integer = -1
        Public ReadOnly EndLine As Integer = -1
        Public ReadOnly IsSubfolding As Boolean = False

        Public Sub New(ByVal startLine As Integer, ByVal endLine As Integer, ByVal isSubfolding As Boolean)
            Me.StartLine = startLine
            Me.EndLine = endLine
            Me.IsSubfolding = isSubfolding
        End Sub
    End Class
    Private Function GetCheckRangeForFolding(ByVal line As Line) As FoldingRange
        If Not m_settings.Folding Or SuppressFoldingCheck Then Return Nothing

        If line.FoldParent >= 0 AndAlso Not line.Index = line.FoldParent AndAlso 'the line is a "child line" of the folding
           line.Index + 1 < Lines.Count AndAlso Lines(line.Index + 1).FoldParent = line.FoldParent Then 'and is not the last line of the folding structure
            Dim startSearchBy As Integer = line.Index

            'go backwards until found the fold parent OR a header of another subfolding
            Do While line.Index > 0 AndAlso line.FoldParent >= 0 And line.FoldParent = Lines(startSearchBy).FoldParent
                line = Lines(line.Index - 1)
            Loop
            Dim startLine_ As Integer = line.Index

            line = Lines(startSearchBy)
            Do While line.Index + 1 < Lines.Count
                line = Lines(line.Index + 1)
                If line.FoldLevelFlags = FoldLevelFlags.Header Then
                    Exit Do
                ElseIf line.FoldParent >= 0 And (Not line.FoldParent = Lines(startSearchBy).FoldParent Or
                       (line.Index + 1 < Lines.Count AndAlso Not Lines(line.Index + 1).FoldParent = Lines(startSearchBy).FoldParent)) Then
                    Exit Do
                End If
            Loop

            Return New FoldingRange(startLine_ + 1, If(line.Index = Lines.Count - 1, line.Index, line.Index - 1), Lines(startSearchBy).FoldParent >= 0)

            'Return Nothing  'DO NOTHING
        End If

        If Not line.FoldLevelFlags = FoldLevelFlags.Header AndAlso line.FoldParent >= 0 Then
            line = Lines(line.FoldParent)
        End If
        Dim startFold As Integer = line.Index

        'go back to the last successful folding line
        Dim checkFoldParent As Integer = line.FoldParent
        Do While line.Index > 0 AndAlso Lines(line.Index - 1).FoldParent = checkFoldParent
            line = Lines(line.Index - 1)
        Loop
        Dim startLine As Integer = line.Index

        'go forwards and search the first line which has another folding
        line = Lines(startFold) 'start by folding start
        Dim checkSubfoldings As New Stack(Of Integer) 'stack to watch sub- sub- sub- sub- sub- subfoldings
        checkSubfoldings.Push(startFold)
        Do While line.Index + 1 < Lines.Count
            line = Lines(line.Index + 1)
            If checkSubfoldings.Count > 0 Then 'inside my folding
                If Not line.FoldParent = checkSubfoldings.First Then
                    checkSubfoldings.Pop() 'the line doesn't contain to the folding of the item on the stack

                    If checkSubfoldings.Count = 0 Then 'break or conti
                        If line.FoldLevelFlags = FoldLevelFlags.Header Or line.FoldParent >= 0 Then 'start folding => new folding outside of my => EXIT
                            Exit Do
                        Else
                            Continue Do
                        End If
                    End If
                End If

                If line.FoldLevelFlags = FoldLevelFlags.Header Then
                    If line.FoldParent = checkSubfoldings.First Then 'its a subfolding inside me, so pushs to the stack
                        checkSubfoldings.Push(line.Index)
                    Else
                        Exit Do
                    End If
                End If
            Else
                If line.FoldLevelFlags = FoldLevelFlags.Header Then
                    Exit Do
                End If
            End If
        Loop

        Return New FoldingRange(startLine,
                                If(line.Index = Lines.Count - 1, Lines.Count - 1, line.Index - 1),
                                Lines(startFold).FoldParent >= 0)


        'If line.FoldParent >= 0 Then
        '    line = Lines(line.FoldParent)
        'End If

        'Dim startIndex As Integer = line.Index
        'Dim checkParentFolding As Boolean = False

        'If startIndex + 1 < Lines.Count Then
        '    line = Lines(startIndex + 1)
        '    Do While line.Index < Lines.Count - 1
        '        If line.FoldParent = -1 AndAlso Not checkParentFolding Then
        '            checkParentFolding = True
        '        ElseIf line.FoldParent >= 0 And checkParentFolding Then
        '            Exit Do
        '        End If
        '        line = Lines(line.Index + 1)
        '    Loop


        '    For i As Integer = startIndex To line.Index - 2
        '        Lines(i).FoldLevel = Lines(startIndex).FoldLevel
        '        Lines(i).FoldLevelFlags = 0
        '    Next

        '    Folding(startIndex, line.Index)
        '    Console.WriteLine(line)
        'End If
    End Function

    Private Sub Folding(ByVal lineStartIndex As Integer, ByVal lineEndIndex As Integer, Optional ByVal cleanRange As Boolean = True, Optional ByVal isSubfolding As Boolean = False)
        Dim stopper As Date = Date.Now
        If m_settings.Folding Then
            Dim lineStart As Line = Lines(lineStartIndex)
            Dim lineEnd As Line = Lines(lineEndIndex)

            If cleanRange Then
                For i As Integer = lineStart.Index To lineEnd.Index
                    Lines(i).FoldLevel = lineStart.FoldLevel
                    Lines(i).FoldLevelFlags = 0
                Next
            End If

            Dim range As String = GetTextRange(lineStart.Position, lineEnd.EndPosition - lineStart.Position)
            For Each mtch As Match In Regex.Matches(range, If(Not isSubfolding, FoldingTagsPattern.ToString, FoldingTagsPatternTest.ToString),
                                                    RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                Dim endLine As Integer = LineFromPosition(lineStart.Position + mtch.Index + mtch.Length)
                Dim ls As Line = Lines(LineFromPosition(lineStart.Position + mtch.Index))
                Dim le As Line = Lines(endLine + 1)


                Dim foldLevel As Integer = 0
                For i As Integer = ls.Index To le.Index - 1
                    Dim line As Line = Lines(i)
                    If i = ls.Index Then
                        line.FoldLevelFlags = FoldLevelFlags.Header
                        foldLevel = line.FoldLevel + 1
                    Else
                        line.FoldLevel = foldLevel
                    End If
                Next

                le.FoldLevel = If(Not le.Index = endLine, foldLevel - 1, foldLevel)

                If m_settings.Subfolding AndAlso Not isSubfolding Then
                    Folding(ls.Index, le.Index, False, True)
                End If
            Next
            'For i As Integer = lineStart.Index To lineEnd.Index
            '    If Lines(i).FoldLevelFlags = 0 AndAlso Lines(i).FoldParent < 0 AndAlso Not Lines(i).Visible Then
            '        Lines(i).EnsureVisible()
            '        Lines(i).FoldChildren(FoldAction.Expand)
            '    End If
            'Next
        End If

        If Not isSubfolding Then
            Console.WriteLine("Folding Time: " & (Date.Now - stopper).TotalMilliseconds)
        End If
    End Sub
#End Region

#Region "Extra Thread Functions"
    Public Shared Function GetTextThreadSafety(ByVal scin As CustomScintilla) As String
        Try
            If Not scin.IsDisposed Then
                If scin.InvokeRequired Then
                    Return CStr(scin.Invoke(New Func(Of String)(Function() GetTextThreadSafety(scin))))
                Else
                    Return scin.Text
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try

        Return ""
    End Function

    Public Shared Function LineFromPositionThreadSafety(ByVal scin As CustomScintilla, ByVal pos As Integer) As Integer
        Try
            If Not scin.IsDisposed Then
                If scin.InvokeRequired Then
                    Return CStr(scin.Invoke(New Func(Of String)(Function() LineFromPositionThreadSafety(scin, pos))))
                Else
                    Return scin.LineFromPosition(pos)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try

        Return ""
    End Function
#End Region

End Class