'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text.RegularExpressions
Imports Easier_Data_Editor.LittleFighter
Imports ScintillaNET

Partial Public Class TextEditor
    Public ReadOnly FirstVisibleLineFromLastStart As Integer = -1
    Public ReadOnly Frames As New Dictionary(Of String, Integer) 'key = frame Name, value = frame offset (than line index)
    Public ReadOnly Errors As New List(Of ErrorItem)
    Public ReadOnly UnusedIDs As New List(Of UnusedIDItem)

    Public Event DragEnterEventOfEditor As DragEventHandler
    Public Event DropEventOfEditor As DragEventHandler
    Public Event DragOverEventOfEditor As DragEventHandler
    Public Event UndoRedoStackChanged As EventHandler(Of Boolean)
    Public Event SaveStateChanged As EventHandler(Of Boolean)
    Public Event ChangeFrameViewerState As EventHandler(Of Boolean)
    Public Event ChangeFrame As EventHandler(Of TextFrame)
    Public Shadows Event TextChanged As EventHandler(Of Point)
    Public Event ErrorsChecked As EventHandler(Of Boolean)
    Public Event UnusedIDsChecked As EventHandler(Of Boolean)

#Region "Properties"
    Private Const SPLITTER_MINIMUM_HEIGHT As Integer = 50
    Public Property Split(Optional ByVal splitDis As Integer = -1) As Orientation
        Get
            If Not Splitter.Panel2Collapsed Then
                Return Splitter.Orientation
            Else
                Return -1
            End If
        End Get
        Set(value As Orientation)
            If splitDis > 0 Then
                Splitter.SplitterDistance = Math.Max(SPLITTER_MINIMUM_HEIGHT, splitDis)
            ElseIf Splitter.Panel2Collapsed Then ' Splitter.SplitterDistance < 120 Then
                If value = Orientation.Horizontal Then
                    Splitter.SplitterDistance = Splitter.Height / 2
                Else
                    Splitter.SplitterDistance = Splitter.Width / 2
                End If
            End If

            If value < 0 Then
                Splitter.Panel2Collapsed = True
                If Splitter.Panel2.Controls.Count > 0 Then
                    Dim con As Control = Splitter.Panel2.Controls(0)
                    If TypeOf con Is CustomScintilla Then
                        Dim editor As CustomScintilla = con
                        Scintilla1.CurrentPosition = editor.CurrentPosition
                        RemoveHandler editor.UpdateUI, AddressOf Scintilla1_UpdateUI
                        ' RemoveHandler CType(con, CustomScintilla).DragDrop, AddressOf Scintilla1_DragDrop
                    End If
                End If
                Splitter.Panel2.Controls.Clear()

                'SyntaxHighlighting.Scintilla1_TextChanged(Scintilla1, New EventArgs())
            Else
                If Splitter.Panel2.Controls.Count = 0 Then
                    Dim clone As New CustomScintilla With {.Dock = DockStyle.Fill, .BorderStyle = BorderStyle.None, .Document = Scintilla1.Document}
                    AddHandler clone.UpdateUI, AddressOf Scintilla1_UpdateUI
                    'AddHandler clone.DragDrop, AddressOf Scintilla1_DragDrop
                    'SyntaxHighlighting.SetFirstStyle(clone)
                    clone.ContextMenuStrip = CMS_actions
                    Splitter.Panel2.Controls.Add(clone)

                    clone.FirstVisibleLine = Scintilla1.FirstVisibleLine

                    'SyntaxHighlighting.Scintilla1_TextChanged(clone, New EventArgs())
                End If

                Splitter.Orientation = value
                Splitter.Panel2Collapsed = False
            End If

            Btn_split.Location = New Drawing.Point(Me.Width - Btn_split.Width - 16, -1)
            Btn_split.Visible = Splitter.Panel2Collapsed

            Btn_split.Image = If(Splitter.Orientation = Orientation.Horizontal, ICON_SPLIT_H, ICON_SPLIT_V)
        End Set
    End Property

    Public ReadOnly Property ID As Integer = New Random().Next(1, Integer.MaxValue) Implements IUserItem.ID
    Public WriteOnly Property HasFocus As Boolean Implements IUserItem.HasFocus
        Set(value As Boolean)
            If App.Settings.ScrollbarAnnotations Then
                Tim_annotations.Enabled = value
            End If
        End Set
    End Property

    Public Property Path As String Implements IUserItem.Path
        Get
            Return m_path
        End Get
        Set(value As String)
            If Not String.IsNullOrEmpty(value) Then
                If IO.File.Exists(value) Then
                    Text = IO.Path.GetFileName(value)
                    ToolTipText = value
                Else
                    Text = "New File"
                    ToolTipText = Nothing
                End If
            Else
                Text = "New File"
                ToolTipText = Nothing
                value = ""
            End If
            m_path = value
            'If Not IsNothing(Viewer) Then
            '    Viewer.Path = value
            'End If
        End Set
    End Property

    Public Property Viewer As FrameViewer
        Get
            Return m_viewer
        End Get
        Set(value As FrameViewer)
            If Not IsNothing(m_viewer) Then
                m_viewer.TextEditor = Nothing
            End If
            If Not IsNothing(value) Then
                value.HeaderChanged(Scintilla1.GetTextRange(0, If(Scintilla1.TextLength < 1000, Scintilla1.TextLength, 1000)))
                value.TextEditor = Me
            End If
            m_viewer = value
        End Set
    End Property

    Public Property IsSave As Boolean
        Get
            Return m_isSave
        End Get
        Set(value As Boolean)
            If Not value = m_isSave Then
                m_isSave = value

                If Not value Then
                    If Not Text.EndsWith("*") Then
                        Text &= "*"
                    End If
                    Icon = My.Resources.icon_red
                ElseIf value And Text.EndsWith("*") Then
                    Text = Text.Substring(0, Text.Length - 1)
                    Icon = My.Resources.icon_16_colour2
                End If

                RaiseEvent SaveStateChanged(Me, m_isSave)

                If m_isSave Then
                    For Each line As Line In Scintilla1.Lines
                        Dim mask_ As UInteger = 1 << EMarkerIndices.Changes
                        If (line.MarkerGet() And mask_) > 0 Then
                            'line.MarkerDelete(EMarkerIndices.Changes)
                            line.MarkerDelete(-1)
                            line.MarkerAdd(EMarkerIndices.Saved)
                        End If
                    Next
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property CanUndo As Boolean
        Get
            Return Scintilla1.CanUndo()
        End Get
    End Property

    Public ReadOnly Property CanRedo As Boolean
        Get
            Return Scintilla1.CanRedo()
        End Get
    End Property

    Public Property CurrentFrameID As Integer
        Get
            Return m_lastID
        End Get
        Set(value As Integer)
            If value = m_lastID Then Exit Property

            Dim scin As CustomScintilla = GetActiveScintillaEditor()
            Dim offset As Integer = scin.GetOffsetFromFrame(value)
            If offset >= 0 Then
                Dim lineIndex As Integer = scin.LineFromPosition(offset)
                SetTextFrameFromLineIndex(lineIndex, False)
                If App.Settings.AutoJumpBySyncID Then
                    scin.Lines(lineIndex).Goto()
                    scin.FirstVisibleLine = Math.Max(0, lineIndex - 8)
                End If
            End If
        End Set
    End Property
#End Region

#Region "Default Editor Stuff (Undo, Redo, etc..)"
    Public Sub Undo()
        GetActiveScintillaEditor().Undo()
    End Sub

    Public Sub Redo()
        GetActiveScintillaEditor().Redo()
    End Sub

    Public Sub Copy()
        GetActiveScintillaEditor().Copy()
    End Sub

    Public Sub Paste()
        GetActiveScintillaEditor().Paste()
    End Sub

    Public Sub PasteCool()
        Try
            If My.Computer.Clipboard.ContainsText Then
                Dim scin As CustomScintilla = GetActiveScintillaEditor()
                Dim text As String = My.Computer.Clipboard.GetText()

                Dim dataObj As String = Tools.IDs.GetAdjustedIDs(scin, text)
                If Not String.IsNullOrEmpty(dataObj) Then
                    My.Computer.Clipboard.SetText(dataObj)
                    scin.Paste()

                    My.Computer.Clipboard.SetText(text) 'set the old clipboard text
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Cut()
        GetActiveScintillaEditor().Cut()
    End Sub

    Public Sub Delete()
        GetActiveScintillaEditor().DeleteRange(Scintilla1.SelectionStart, Scintilla1.SelectionEnd - Scintilla1.SelectionStart)
    End Sub

    Public Function DeleteKey()
        Return GetActiveScintillaEditor().DeleteKey()
    End Function

    Public Sub SelectAll()
        GetActiveScintillaEditor().SelectAll()
    End Sub

    Public Sub ExpandFoldingAll()
        GetActiveScintillaEditor().FoldAll(FoldAction.Expand)
    End Sub

    Public Sub CollapseFoldingAll()
        GetActiveScintillaEditor().FoldAll(FoldAction.Contract)
    End Sub

    Public Function ExportToHTML() As String
        Return GetActiveScintillaEditor().GetTextRangeAsHtml(0, GetActiveScintillaEditor().TextLength)
    End Function

    Public Sub GoToLine(ByVal lineIndex As Integer)
        GetActiveScintillaEditor().GoToLine(lineIndex + 1)
    End Sub

    Public Function GoToFrame(ByVal frameID As Integer)
        Return GetActiveScintillaEditor().GoToFrame(frameID)
    End Function

    Public Sub GoToPosition(ByVal position As Integer)
        GetActiveScintillaEditor().GotoPosition(position)
    End Sub

    Public Sub SetFirstVisibleLine(ByVal lineIndex As Integer)
        If lineIndex >= 0 And lineIndex < Scintilla1.Lines.Count Then
            Scintilla1.FirstVisibleLine = lineIndex
        End If
    End Sub

    Public Function GetCurrentPosition() As Integer
        Return GetActiveScintillaEditor().CurrentPosition
    End Function

    Public Sub SetOrDeleteBookmark()
        Dim line As Line = Scintilla1.Lines(GetActiveScintillaEditor().CurrentLine)
        If Scintilla1.LineHasMarker(line, EMarkerIndices.Bookmark) Then
            line.MarkerDelete(EMarkerIndices.Bookmark)
        Else
            line.MarkerAdd(EMarkerIndices.Bookmark)
        End If
    End Sub

    Public Sub GoToNextBookmark()
        GetActiveScintillaEditor().GoToNextBookmark()
    End Sub

    Public Sub GoToPreviousBookmark()
        GetActiveScintillaEditor().GoToPreviousBookmark()
    End Sub

    Public Sub ClearBookmarks()
        Scintilla1.MarkerDeleteAll(EMarkerIndices.Bookmark)
    End Sub

    Public Sub CutBookmarkedLines()
        Scintilla1.CutBookmarkedLines()
    End Sub

    Public Sub CopyBookmarkedLines()
        Scintilla1.CopyBookmarkedLines()
    End Sub

    Public Sub PasteToBookmarkedLines()
        If My.Computer.Clipboard.ContainsText Then
            Scintilla1.PasteToBookmarkedLines(My.Computer.Clipboard.GetText)
        End If
    End Sub

    Public Sub RemoveBookmarkedLines()
        Scintilla1.RemoveBookmarkedLines()
    End Sub

    Public Sub RemoveUnmarkedLines()
        Scintilla1.RemoveUnmarkedLines()
    End Sub

    Public Sub InvertBookmarks()
        Scintilla1.InvertBookmarks()
    End Sub

    Public Sub ReloadStyle()
        For Each scin As CustomScintilla In GetAllEditors()
            scin.ReloadStyle()
        Next

        Pic_scrollbarAnnotations.Visible = App.Settings.ScrollbarAnnotations
    End Sub
#End Region
#Region "Find / Replace / Mark"
    Public Function GetSelectedTextForSearchWindow() As String
        Dim selText As String = GetActiveScintillaEditor().SelectedText
        If Not String.IsNullOrEmpty(selText) Then
            If selText.Length < 90 Then
                Return selText
            End If
        End If

        Return Nothing
    End Function

    Public Function Count(ByVal searchInput As String) As Integer
        Dim result As Integer = 0
        If Not String.IsNullOrEmpty(searchInput) Then
            SetSearchFlags(Scintilla1)

            For Each range As Point In GetSearchRanges()
                Scintilla1.TargetStart = range.X
                Scintilla1.TargetEnd = range.Y
                Do While Scintilla1.SearchInTarget(searchInput) >= 0
                    result += 1
                    'the search sets the values "targetstart" and "targetend", change the values for the next value
                    Scintilla1.TargetStart = Scintilla1.TargetEnd 'is the end position of the found word
                    Scintilla1.TargetEnd = range.Y 'reset of the "default" value (see above the while loop)
                Loop
            Next

        End If

        Return result
    End Function

    Public Function Find(ByVal searchInput As String) As Boolean
        If Not String.IsNullOrEmpty(searchInput) Then
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            SetSearchFlags(editor)

            editor.TargetStart = editor.CurrentPosition
            editor.TargetEnd = editor.TextLength

            If editor.SearchInTarget(searchInput) >= 0 Then
                SetSelectionAndCheckVis(editor)
                Return True
            End If

            If App.Settings.SearchSettings.WrapAround Then
                editor.TargetStart = 0

                If editor.SearchInTarget(searchInput) >= 0 Then
                    SetSelectionAndCheckVis(editor)
                    Return True
                End If
            End If

            Return False
        End If

        Return False
    End Function

    Public Function FindReverse(ByVal searchInput As String) As Boolean
        If Not String.IsNullOrEmpty(searchInput) Then
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            SetSearchFlags(editor)

            editor.TargetStart = editor.CurrentPosition - 1
            editor.TargetEnd = 0

            If editor.SearchInTarget(searchInput) >= 0 Then
                SetSelectionAndCheckVis(editor)
                Return True
            End If

            If App.Settings.SearchSettings.WrapAround Then
                editor.TargetStart = editor.TextLength

                If editor.SearchInTarget(searchInput) >= 0 Then
                    SetSelectionAndCheckVis(editor)
                    Return True
                End If
            End If

            Return False
        End If

        Return False
    End Function

    Private Sub SetSelectionAndCheckVis(ByVal editor As CustomScintilla)
        editor.SelectionStart = editor.TargetStart
        editor.SelectionEnd = editor.TargetEnd
        editor.ScrollRange(editor.SelectionStart, editor.SelectionEnd)

        If App.Settings.Folding Then
            editor.IndicatorCurrent = EIndicatorIndices.FoldingCollapsed
            Dim ls As Line = editor.Lines(editor.LineFromPosition(editor.SelectionStart))
            Dim le As Line = editor.Lines(editor.LineFromPosition(editor.SelectionEnd))

            For i As Integer = ls.Index To le.Index
                Dim line As Line = editor.Lines(i)
                Do While line.FoldParent >= 0
                    line = editor.Lines(line.FoldParent)
                    If Not line.Expanded Then
                        editor.FoldingToggleLine(line)
                    End If
                Loop
            Next
        End If
    End Sub

    Public Function Replace(ByVal searchInput As String, ByVal replaceInput As String) As Integer
        If Not String.IsNullOrEmpty(searchInput) Then
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            Dim oldPos As Integer = editor.CurrentPosition

            If editor.SelectionStart >= 0 And editor.SelectionEnd >= 0 Then
                editor.CurrentPosition = editor.SelectionStart
            End If

            If Find(searchInput) Then
                If oldPos = editor.CurrentPosition Then
                    editor.BeginUndoAction()
                    editor.ReplaceTarget(replaceInput)
                    editor.EndUndoAction()
                    If Find(searchInput) Then 'mark the next match
                        Return 2 'found AND more matches
                    End If
                    Return 1 'found but no more matches
                End If
                Return 0 'found but ONLY select
            End If
        End If

        Return -1 'not found anything
    End Function

    Public Function ReplaceReverse(ByVal searchInput As String, ByVal replaceInput As String) As Integer
        If Not String.IsNullOrEmpty(searchInput) Then
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            Dim oldPos As Integer = editor.CurrentPosition

            If editor.SelectionStart >= 0 And editor.SelectionEnd >= 0 Then
                editor.CurrentPosition += 1
            End If

            If FindReverse(searchInput) Then
                If oldPos = editor.CurrentPosition Then
                    editor.BeginUndoAction()
                    editor.ReplaceTarget(replaceInput)
                    editor.EndUndoAction()
                    If FindReverse(searchInput) Then 'mark the next match
                        Return 2 'found AND more matches
                    End If
                    Return 1 'found but no more matches
                End If
                Return 0 'found but ONLY select
            End If
        End If

        Return -1 'not found anything
    End Function

    Public Function ReplaceAll(ByVal searchInput As String, ByVal replaceInput As String) As Integer
        Dim result As Integer = 0
        If Not String.IsNullOrEmpty(searchInput) Then
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            SetSearchFlags(editor)
            Dim ranges As List(Of Point) = GetSearchRanges()
            If Not App.Settings.SearchSettings.InSelections Then
                ranges(0) = New Point(If(App.Settings.SearchSettings.WrapAround, 0, editor.CurrentPosition), editor.TextLength)
            End If
            editor.BeginUndoAction()
            For Each range As Point In ranges
                editor.TargetStart = range.X
                editor.TargetEnd = range.Y

                Do While editor.SearchInTarget(searchInput) >= 0
                    editor.ReplaceTarget(replaceInput)

                    editor.TargetStart = editor.TargetEnd
                    editor.TargetEnd = range.Y

                    result += 1
                Loop
            Next
            editor.EndUndoAction()
        End If

        Return result
    End Function

    Public Function Mark(ByVal searchInput As String) As Integer
        Dim result As Integer = 0
        If Not String.IsNullOrEmpty(searchInput) Then
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            SetSearchFlags(editor)
            editor.IndicatorCurrent = EIndicatorIndices.Highlight
            If App.Settings.SearchSettings.Purge Then
                For Each line As Line In editor.Lines
                    If editor.LineHasMarker(line, EMarkerIndices.Bookmark) Then
                        line.MarkerDelete(EMarginIndices.Bookmark)
                        Console.WriteLine(line.MarkerGet)
                    End If
                Next

                editor.IndicatorClearRange(0, editor.TextLength)
            End If

            Dim ranges As List(Of Point) = GetSearchRanges()
            If Not App.Settings.SearchSettings.InSelections Then
                ranges(0) = New Point(If(App.Settings.SearchSettings.WrapAround, 0, editor.CurrentPosition), editor.TextLength)
            End If
            For Each range As Point In ranges
                editor.TargetStart = range.X
                editor.TargetEnd = range.Y

                Do While editor.SearchInTarget(searchInput) >= 0
                    editor.IndicatorFillRange(editor.TargetStart, editor.TargetEnd - editor.TargetStart)

                    If App.Settings.SearchSettings.BookmarkLine Then
                        editor.Lines(editor.LineFromPosition(editor.TargetStart)).MarkerAdd(EMarginIndices.Bookmark)
                    End If

                    editor.TargetStart = editor.TargetEnd
                    editor.TargetEnd = range.Y

                    result += 1
                Loop
            Next
        End If

        Return result
    End Function

    Public Sub MarkClear()
        Dim editor As CustomScintilla = GetActiveScintillaEditor()
        editor.IndicatorCurrent = EIndicatorIndices.Highlight
        editor.IndicatorClearRange(0, editor.TextLength)
    End Sub

    Private Function GetSearchRanges() As List(Of Point)
        Dim result As New List(Of Point)
        If App.Settings.SearchSettings.InSelections Then
            For Each sel As Selection In GetActiveScintillaEditor().Selections
                result.Add(New Point(sel.Start, sel.End))
            Next
        Else
            result.Add(New Point(0, Scintilla1.TextLength))
        End If

        Return result
    End Function

    Private Sub SetSearchFlags(ByVal Scintilla1 As CustomScintilla)
        Scintilla1.SearchFlags = SearchFlags.None
        If App.Settings.SearchSettings.SearchMode = ESearchMode.Regex Then Scintilla1.SearchFlags = Scintilla1.SearchFlags Or SearchFlags.Regex
        If App.Settings.SearchSettings.MatchCase Then Scintilla1.SearchFlags = Scintilla1.SearchFlags Or SearchFlags.MatchCase
        If App.Settings.SearchSettings.MatchWholeWord Then Scintilla1.SearchFlags = Scintilla1.SearchFlags Or SearchFlags.WholeWord
    End Sub
#End Region
#Region "Called From FrameViewer"
    Public Sub FrameViewer_MouseUp()
        Scintilla1.EndUndoAction()
        Scintilla1.BlockUndoRedoActions = False
    End Sub

    Public Sub FrameViewer_MouseDown()
        Scintilla1.BeginUndoAction()
        Scintilla1.BlockUndoRedoActions = True
    End Sub

    Public Sub ChangeValues(ByVal LFFrame As Frame, ByVal changeType As EFrameChangeType, Optional ByVal selectedIndex As Integer = -1)
        m_changedFromFrameViewer = True
        Dim oldLen As Integer = Scintilla1.TextLength
        Scintilla1.SuppressFoldingCheck = True

        If changeType = EFrameChangeType.Bdy Or changeType = EFrameChangeType.Itr Then
            Dim selectedThing As Bdy = Nothing
            If changeType = EFrameChangeType.Bdy And selectedIndex < m_frame.OffsetBodies.Count Then
                Scintilla1.TargetStart = m_frame.OffsetBodies(selectedIndex).X
                Scintilla1.TargetEnd = m_frame.OffsetBodies(selectedIndex).Y
                selectedThing = LFFrame.Bodys(selectedIndex)
            ElseIf changeType = EFrameChangeType.Itr And selectedIndex < m_frame.OffsetItrs.Count Then
                Scintilla1.TargetStart = m_frame.OffsetItrs(selectedIndex).X
                Scintilla1.TargetEnd = m_frame.OffsetItrs(selectedIndex).Y
                selectedThing = LFFrame.Itrs(selectedIndex)
            End If

            If Not IsNothing(selectedThing) Then
                Dim newText As String = Scintilla1.TargetText

                newText = ChangeXY(newText, selectedThing.Rect.X, selectedThing.Rect.Y)

                If (selectedThing.Rect.Width > 0) Then newText = Regex.Replace(newText, "(?<=(^w:|\s+w:)\s*)[0-9]+", selectedThing.Rect.Width, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
                If (selectedThing.Rect.Height > 0) Then newText = Regex.Replace(newText, "(?<=(^h:|\s+h:)\s*)[0-9]+", selectedThing.Rect.Height, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))

                If changeType = EFrameChangeType.Itr Then
                    If Regex.IsMatch(newText, "(?<=(^zwidth:|\s+zwidth:)\s*)[0-9-]+") Then
                        newText = Regex.Replace(newText, "(?<=(^zwidth:|\s+zwidth:)\s*)[0-9-]+", CType(selectedThing, Itr).zWidth, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
                    ElseIf CType(selectedThing, Itr).zWidth > 0 Then
                        newText = Regex.Replace(newText, "(?<=(^y:|\s+y:)\s*)[0-9-]+", selectedThing.Rect.Y & " zwidth: " & CType(selectedThing, Itr).zWidth, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
                    End If
                End If

                Scintilla1.ReplaceTarget(newText)
            Else
                Console.WriteLine("----")
            End If


        ElseIf changeType = EFrameChangeType.WPoint Then
            Scintilla1.TargetStart = m_frame.OffsetWPoint.X
            Scintilla1.TargetEnd = m_frame.OffsetWPoint.Y

            Dim newText As String = Scintilla1.TargetText

            newText = ChangeXY(newText, LFFrame.WPoint.Loca.X, LFFrame.WPoint.Loca.Y)
            newText = Regex.Replace(newText, "(?<=(^weaponact:|\s+weaponact:)\s*)[0-9-]+", LFFrame.WPoint.Weaponact, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            Scintilla1.ReplaceTarget(newText)

        ElseIf changeType = EFrameChangeType.OPoint Then
            ChangeXYFrom(m_frame.OffsetOPoint.X, m_frame.OffsetOPoint.Y, LFFrame.OPoint.X, LFFrame.OPoint.Y)
        ElseIf changeType = EFrameChangeType.BPoint Then
            ChangeXYFrom(m_frame.OffsetBPoint.X, m_frame.OffsetBPoint.Y, LFFrame.BPoint.X, LFFrame.BPoint.Y)
        ElseIf changeType = EFrameChangeType.CPoint Then
            ChangeXYFrom(m_frame.OffsetCPoint.X, m_frame.OffsetCPoint.Y, LFFrame.CPoint.X, LFFrame.CPoint.Y)
        ElseIf changeType = EFrameChangeType.CenterXY Or changeType = EFrameChangeType.CenterXY2 Then
            ChangeXYExactly(m_frame.Offset, m_frame.Offset + m_frame.Length, LFFrame.Center.X, LFFrame.Center.Y, "center")
        End If
        Scintilla1.SuppressFoldingCheck = False

        ' GetFrameFromLineIndex(Scintilla1.CurrentLine)
        Dim diff As Integer = Scintilla1.TextLength - oldLen
        If Not diff = 0 Then
            SetFrameOffsetFrom(Scintilla1.LineFromPosition(Scintilla1.TargetStart))
        End If

        m_changedFromFrameViewer = False
    End Sub

    Public Sub DeleteValues(ByVal lfFrame As Frame, ByVal changeType As EFrameChangeType, Optional ByVal selectedIndex As Integer = -1)
        If changeType = EFrameChangeType.Bdy Then
            If selectedIndex < m_frame.OffsetBodies.Count Then
                Dim mtches As MatchCollection = New Regex("(^|\s+)bdy:.*?($|\s+)bdy_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Matches(m_frame.Lines)
                If selectedIndex < mtches.Count Then
                    Scintilla1.TargetStart = m_frame.Offset + mtches(selectedIndex).Index
                    Scintilla1.TargetEnd = m_frame.Offset + mtches(selectedIndex).Index + mtches(selectedIndex).Length
                    Scintilla1.ReplaceTarget(String.Empty)
                End If
            End If
        ElseIf changeType = EFrameChangeType.Itr Then
            If selectedIndex < m_frame.OffsetItrs.Count Then
                Dim mtches As MatchCollection = New Regex("(^|\s+)itr:.*?($|\s+)itr_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Matches(m_frame.Lines)
                If selectedIndex < mtches.Count Then
                    Scintilla1.TargetStart = m_frame.Offset + mtches(selectedIndex).Index
                    Scintilla1.TargetEnd = m_frame.Offset + mtches(selectedIndex).Index + mtches(selectedIndex).Length
                    Scintilla1.ReplaceTarget(String.Empty)
                End If
            End If
        End If
    End Sub

    Public Sub AddValues(ByVal changeType As EFrameChangeType, ByVal rect As Rectangle)
        If changeType = EFrameChangeType.Bdy Then
            If Not m_frame.Offset < 0 Then
                Dim docLine As Line = Scintilla1.Lines(Scintilla1.LineFromPosition(m_frame.Offset + m_frame.Length - 1))
                If Not IsNothing(docLine) Then
                    If Regex.IsMatch(docLine.Text, "<frame_end>", RegexOptions.IgnoreCase) Then
                        Scintilla1.InsertText(docLine.Position, "   bdy:  x: " & rect.X & "  y: " & rect.Y & "  w: " & rect.Width & "  h: " & rect.Height & "  bdy_end:" & vbNewLine)
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SetNextFrame()
        If m_frame.Offset >= 0 Then
            m_lastFrameID = -1
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            Dim line As Line = editor.Lines(editor.LineFromPosition(m_frame.Offset + m_frame.Length))
            Do While True
                If IsNothing(line) Then Exit Do

                If Regex.IsMatch(line.Text, "<frame>", RegexOptions.IgnoreCase) Then
                    line.Goto()  ' SetTextFrameFromLineIndex(line.Index)
                    Exit Do
                End If

                If line.Index > 0 And line.Index < editor.Lines.Count - 1 Then
                    line = editor.Lines(line.Index + 1)
                Else
                    Exit Do
                End If
            Loop
            m_previousFramesList.Clear()
        End If
    End Sub

    Public Sub SetPreviousFrame()
        If m_frame.Offset >= 0 Then
            m_lastFrameID = -1
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            Dim line As Line = editor.Lines(editor.LineFromPosition(m_frame.Offset) - 1)
            Do While True
                If IsNothing(line) Then Exit Do

                If Regex.IsMatch(line.Text, "<frame>", RegexOptions.IgnoreCase) Then
                    line.Goto() ' SetTextFrameFromLineIndex(line.Index)
                    Exit Do
                End If

                If line.Index > 0 Then
                    line = editor.Lines(line.Index - 1)
                Else
                    Exit Do
                End If
            Loop
            m_previousFramesList.Clear()
        End If
    End Sub

    Public Sub SetNextRealFrame()
        If Not IsNothing(m_frame) Then
            Dim nextID As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=next:\s*)\d+", RegexOptions.IgnoreCase)
            If nextID >= 0 Then
                SetNextRealFrame(nextID)
            End If
        End If
    End Sub

    Public Sub SetPreviousRealFrame()
        If Not IsNothing(m_frame) Then
            Dim currentID As Integer = GetRegexValueInteger(m_frame.Lines, "(?<=frame>\s*)\d+", RegexOptions.IgnoreCase)
            If currentID >= 0 Then
                SetPreviousRealFrame(currentID)
            End If
        End If
    End Sub

    Public Sub SetNextRealFrame(ByVal nextID As Integer)
        If Not IsNothing(m_frame) AndAlso m_frame.Offset >= 0 Then
            m_lastFrameID = nextID
            If nextID > 0 Then
                Dim editor As CustomScintilla = GetActiveScintillaEditor()
                Dim searchMatch As Match = Regex.Match(editor.Text, "<frame>\s*(" & nextID & "$|" & nextID & "\n|" & nextID & "\r|" & nextID & "\s+)", RegexOptions.IgnoreCase)
                If searchMatch.Success Then
                    m_previousFramesList.Add(nextID)
                    editor.Lines(editor.LineFromPosition(searchMatch.Index)).Goto()  'SetTextFrameFromLineIndex(editor.LineFromPosition(searchMatch.Index))
                End If
            End If
        End If
    End Sub

    Public Sub SetPreviousRealFrame(ByVal currentID As Integer)
        If Not IsNothing(m_frame) AndAlso m_frame.Offset >= 0 Then
            Dim editor As CustomScintilla = GetActiveScintillaEditor()
            If m_previousFramesList.Count > 0 Then
                Dim searchID As Integer = m_previousFramesList(m_previousFramesList.Count - 1)
                Dim searchMatch As Match = Regex.Match(editor.Text, "<frame>\s*(" & searchID & "$|" & searchID & "\n|" & searchID & "\r|" & searchID & "\s+)", RegexOptions.IgnoreCase)
                If searchMatch.Success Then
                    editor.Lines(editor.LineFromPosition(searchMatch.Index)).Goto()  ' SetTextFrameFromLineIndex(editor.LineFromPosition(searchMatch.Index))
                    m_previousFramesList.RemoveAt(m_previousFramesList.Count - 1)
                    Exit Sub
                End If
            End If

            m_lastFrameID = currentID
            If currentID > 0 Then
                Dim searchMatch As Match = Regex.Match(editor.Text, "next:\s*[\-]{0,1}(" & currentID & "$|" & currentID & "\n|" & currentID & "\r|" & currentID & "\s+)", RegexOptions.IgnoreCase)
                If searchMatch.Success Then
                    Dim int As Integer = GetRegexValueInteger(searchMatch.Value, "[\-]{0,1}[0-9]+", RegexOptions.IgnoreCase, 0)
                    If Not IsNothing(m_viewer) Then
                        If m_viewer.IDToFacing.ContainsKey(Math.Abs(int)) Then
                            m_viewer.IDToFacing(Math.Abs(int)) = int < 0
                        Else
                            m_viewer.IDToFacing.Add(Math.Abs(int), int < 0)
                        End If
                    End If


                    editor.Lines(editor.LineFromPosition(searchMatch.Index)).Goto()  ' SetTextFrameFromLineIndex(editor.LineFromPosition(searchMatch.Index))
                End If
            End If
        End If
    End Sub
#End Region

#Region "Tools"
    Public Sub SortFrames()
        Tools.IDs.SortFrames(Scintilla1)
    End Sub

    Public Sub IncreaseIDs(ByVal value As Integer, ByVal setValues As Boolean, ByVal changeHitValues As Boolean, ByVal changePicValues As Boolean)
        Tools.IDs.IncreaseIDs(GetActiveScintillaEditor(), value, setValues, changeHitValues, changePicValues)
    End Sub

    Public Sub AddTagToSelectionFrames(ByVal tag As String)
        Dim frames As New List(Of Tools.RegexMatchCloner)
        Dim m_editor As CustomScintilla = GetActiveScintillaEditor()
        m_editor.BlockUndoRedoActions = True

        For Each selection As Selection In m_editor.Selections
            For Each mtch As Match In Regex.Matches(m_editor.GetTextRange(selection.Start, selection.End - selection.Start),
                                                    "\S*<frame_end>", RegexOptions.IgnoreCase)
                If mtch.Success Then
                    frames.Add(New Tools.RegexMatchCloner(mtch.Index + selection.Start, selection.Start + mtch.Index + mtch.Length, mtch.Value))
                End If
            Next
        Next

        For i As Integer = frames.Count - 1 To 0 Step -1
            m_editor.TargetStart = frames(i).Index
            m_editor.TargetEnd = frames(i).End
            m_editor.ReplaceTarget(tag & vbNewLine & frames(i).Value)
        Next

        m_editor.BlockUndoRedoActions = False
    End Sub

    Public Sub Reformatting(ByVal onlySelected As Boolean, ByVal removeEmptyLines As Boolean,
                            ByVal template As String, ByVal template_bpoint As String, ByVal template_cpoint As String, ByVal template_opoint As String,
                            ByVal template_wpoint As String, ByVal template_bdy As String, ByVal template_itr As String)
        Dim currentFrameID As Integer = Me.CurrentFrameID
        Tools.FramesReformatting.Reformatting(Scintilla1, onlySelected, removeEmptyLines, template, template_bpoint, template_cpoint, template_opoint, template_wpoint, template_bdy, template_itr)
        Me.CurrentFrameID = currentFrameID
    End Sub

    Public Function EquationAllFramesFrom(ByVal centerXY As Boolean,
                                                     ByVal nextValue As Boolean, ByVal bodies As Boolean, ByVal itrs As Boolean, ByVal bpoi As Boolean,
                                                     ByVal cpoi As Boolean, ByVal opoi As Boolean, ByVal wpoi As Boolean, ByVal hitValues As Boolean,
                                                     ByVal waitValue As Boolean, ByVal stateValue As Boolean) As Boolean
        Return Tools.Equation.EquationAllFramesFrom(GetActiveScintillaEditor(), m_frame, centerXY, nextValue, bodies, itrs, bpoi, cpoi, opoi, wpoi, hitValues, waitValue, stateValue)
    End Function
#End Region

    Public Function GetTextLengthAndLineNumbers() As Point
        Return New Point(Scintilla1.TextLength, Scintilla1.Lines.Count)
    End Function

    Public Function GetCurrentLineNumber() As Integer
        Return GetActiveScintillaEditor().CurrentLine
    End Function

    Public Function GetCountOfLineNumbers() As Integer
        Return Scintilla1.Lines.Count
    End Function

    Public Function GetCurrentFrameName() As String
        If Not IsNothing(m_frame) Then
            Return m_frame.Name
        End If

        Return Nothing
    End Function

    Public Sub Save(Optional ByVal saveAs As Boolean = False)
        Dim savedText As String = Scintilla1.Text

        If (App.Settings.NewlineCharacter And (ENewlineChar.CR Or ENewlineChar.LF)) = (ENewlineChar.CR Or ENewlineChar.LF) Then
            savedText = Regex.Replace(savedText, "((" & PATTERN_NEWLINE_LF & ")|(" & PATTERN_NEWLINE_CR & "))", vbCrLf)
        ElseIf (App.Settings.NewlineCharacter And ENewlineChar.CR) = ENewlineChar.CR Then
            savedText = Regex.Replace(savedText, "((" & PATTERN_NEWLINE_LF & ")|(" & PATTERN_NEWLINE_CR_LF & "))", vbCr)
        ElseIf (App.Settings.NewlineCharacter And ENewlineChar.LF) = ENewlineChar.LF Then
            savedText = Regex.Replace(savedText, "((" & PATTERN_NEWLINE_CR & ")|(" & PATTERN_NEWLINE_CR_LF & "))", vbLf)
        End If

        If Not saveAs And Path.Length > 2 Then
            If IO.Path.GetExtension(Path).Substring(1).ToLower.Equals("dat") Then
                PlainTextToDatFile(savedText, Path,, "Edited with Easier Data-Editor (STM93 Version) Created by Luigi600 (http://cookiesoft.lui-studio.net/) ")
            Else
                My.Computer.FileSystem.WriteAllText(Path, savedText, False, System.Text.Encoding.UTF8)
            End If
            IsSave = True
        Else
            If m_sfd_data.ShowDialog = DialogResult.OK Then
                If IO.Path.GetExtension(m_sfd_data.FileName).Substring(1).ToLower.Equals("dat") Then
                    PlainTextToDatFile(savedText, m_sfd_data.FileName,, "Edited with Easier Data-Editor (STM93 Version) Created by Luigi600 (http://cookiesoft.lui-studio.net/) ")
                Else
                    My.Computer.FileSystem.WriteAllText(m_sfd_data.FileName, savedText, False, System.Text.Encoding.UTF8)
                End If
                IsSave = True
                Path = m_sfd_data.FileName
                App.Settings.RecentFiles.Add(Path)
                If Not IsNothing(m_viewer) Then
                    m_viewer.HeaderChanged(Scintilla1.GetTextRange(0, If(Scintilla1.TextLength < 1000, Scintilla1.TextLength, 1000)))
                End If
            End If
        End If
    End Sub

    Public Function CloseDocument(Optional ByVal exception As Boolean = False) As Boolean
        TextChanger.CancelAsync()

        If Not IsSave Then
            Dim dResult As DialogResult = Nothing
            Dim title As String = If(Not exception, GetVariable("SAVE_QUESTION_TITLE"), GetVariable("SAVE_QUESTION_EXCEPTION_TITLE"))
            Dim text As String = If(Not exception, GetVariable("SAVE_QUESTION"), GetVariable("SAVE_QUESTION_EXCEPTION"))
            If m_path.Length < 2 Then
                text = text.Replace("[FILE]", GetVariable("SAVE_QUESTION_NO_PATH"))
            Else
                text = text.Replace("[FILE]", m_path)
            End If
            'Replace("[FILE]", )
            If Not exception Then
                dResult = MessageBox.Show(text, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            Else
                dResult = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            End If
            If dResult = DialogResult.Yes Then
                Save(m_path.Length < 2)
                Return True
            ElseIf dResult = DialogResult.Cancel Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Sub SetScintillasState(ByVal state As Boolean)
        For Each scin As CustomScintilla In GetAllEditors()
            scin.Enabled = state
        Next
    End Sub

    Public Sub LineScroll(ByVal lines As Integer)
        GetActiveScintillaEditor().LineScroll(lines, 0)
    End Sub

    Private Function GetActiveScintillaEditor() As CustomScintilla
        If Not Splitter.Panel2Collapsed Then
            If TypeOf Splitter.ActiveControl Is CustomScintilla Then
                Return Splitter.ActiveControl
            End If
        End If

        Return Scintilla1
    End Function

    Private Function GetAllEditors() As List(Of CustomScintilla)
        Dim editors As New List(Of CustomScintilla) From {Scintilla1}
        If Not Splitter.Panel2Collapsed Then
            editors.AddRange(Splitter.Panel2.Controls.OfType(Of CustomScintilla))
        End If
        Return editors
    End Function
End Class