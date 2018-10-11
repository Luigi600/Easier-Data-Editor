Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Windows
Imports System.Windows.Forms.Integration
Imports System.Windows.Input
Imports ICSharpCode
Imports ICSharpCode.AvalonEdit.CodeCompletion
Imports ICSharpCode.AvalonEdit.Folding
Imports ICSharpCode.AvalonEdit.Search

Public Class ui_textEditor
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    Implements ITextEditor

#Region "Interface Stuff + Private global variables"
    Private m_isSave As Boolean = True
    Private m_frame As New class_frame
    Public Property ID As Integer = 0 Implements ITextEditor.ID

    Private m_path As String = ""
    Public Property Path As String Implements ITextEditor.Path
        Get
            Return m_path
        End Get
        Set(value As String)
            If Not IsNothing(value) Then
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
            End If
            m_path = value
            If Not IsNothing(Viewer) Then
                Viewer.Path = value
            End If
        End Set
    End Property
    Public Property ErrorSearcher As ErrorSearcher = Nothing Implements ITextEditor.ErrorSearcher
    Private WithEvents AvalonEditor As New AvalonEdit.TextEditor With {.SyntaxHighlighting = syntaxHighlighting}
    Public Event SaveStateChanged As ITextEditor.CustomEvent Implements ITextEditor.SaveStateChanged
    Public Event EditorTextChanged As EventHandler Implements ITextEditor.TextChanged
    Public Event DropEventOfEditor As ITextEditor.CustomEvent Implements ITextEditor.DropEventOfEditor
    Public Event CurrentFrameViewerChanger As EventHandler Implements ITextEditor.CurrentFrameViewerChanger
    Private m_viewer As ui_frameViewer = Nothing

    Public Event FrameChanged As ITextEditor.CustomEvent
    Public Event HeaderChanged As ITextEditor.CustomEvent

    Public Property IsSave As Boolean Implements ITextEditor.IsSave
        Get
            Return m_isSave
        End Get
        Set(value As Boolean)
            If Not value = m_isSave Then
                RaiseEvent SaveStateChanged(Me, New class_customEventArgs(value))
            End If
            m_isSave = value
        End Set
    End Property

    Public Function GetAvalonEditor() As AvalonEdit.TextEditor Implements ITextEditor.GetAvalonEditor
        Return AvalonEditor
    End Function

    Public Property Viewer As ui_frameViewer Implements ITextEditor.Viewer  ' = Nothing
        Get
            Return m_viewer
        End Get
        Set(value As ui_frameViewer)
            If Not IsNothing(value) Then
                AddHandler value.FrameViewerWillChange, AddressOf FrameViewerWillChangeContent
                AddHandler value.FrameViewerWillDelete, AddressOf FrameViewerWillDeleteSomething
                AddHandler value.FrameViewerWillAdd, AddressOf FrameViewerWillAddSomething

                AddHandler value.FrameViewerWillNextFrame, AddressOf FrameViewerWillNextFrame
                AddHandler value.FrameViewerWillNextRealFrame, AddressOf FrameViewerWillNextRealFrame
                AddHandler value.FrameViewerWillPreviousFrame, AddressOf FrameViewerWillPreviousFrame
                AddHandler value.FrameViewerWillPreviousRealFrame, AddressOf FrameViewerWillPreviousRealFrame
            End If
            m_viewer = value
        End Set
    End Property

    Public Function getDockContent() As WeifenLuo.WinFormsUI.Docking.DockContent Implements ITextEditor.getDockContent
        Return Me
    End Function

    Public Sub Save(Optional ByVal saveAs As Boolean = False) Implements ITextEditor.Save
        If Not saveAs And Path.Length > 2 Then
            PlainTextToDatFile(AvalonEditor.Text, Path,, "Edited with Easier Data-Editor (STM93 Version) Created by Luigi600 (http://cookiesoft.lui-studio.net/) ")
            IsSave = True
        Else
            Using sfd As New SaveFileDialog() With {.Filter = "LF2-Data|*.dat"}
                If sfd.ShowDialog = DialogResult.OK Then
                    Path = sfd.FileName
                    PlainTextToDatFile(AvalonEditor.Text, sfd.FileName,, "Edited with Easier Data-Editor (STM93 Version) Created by Luigi600 (http://cookiesoft.lui-studio.net/) ")
                    IsSave = True
                    If Not IsNothing(Viewer) Then
                        RaiseEvent HeaderChanged(Me, New class_customEventArgs(AvalonEditor.Document.GetText(0, If(AvalonEditor.Document.TextLength < 1000, AvalonEditor.Document.TextLength, 1000))))
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub SetErrorList(Optional ByVal checkVis As Boolean = True) Implements ITextEditor.SetErrorList
        If Not isStarting And Not IsNothing(ErrorSearcher) Then
            If globalUser.ErrorList.Visible Or Not checkVis Then
                ErrorSearcher.FindErrors()
                'ErrorItem.FindErrors(AvalonEditor, ErrorList)
                'globalUser.ErrorList.SetList(Me, ErrorList)
            End If
        End If
    End Sub

    Private Sub SetUnusedFramesList(Optional ByVal checkVis As Boolean = True) Implements ITextEditor.SetUnusedFramesList
        If Not isStarting Then
            If globalUser.UnusedFrames.Visible Or Not checkVis Then
                globalUser.UnusedFrames.SetList(AvalonEditor.Text, Me)
                tim_UnusedFrames.Stop()
            End If
        End If
    End Sub
#End Region


    Public Sub New()
        InitializeComponent()

        Loading(True)
    End Sub

    Public Sub New(ByVal path As String, Optional ByVal setViewer As Boolean = True, Optional ByVal ID As Integer = -1)
        InitializeComponent()

        If IO.File.Exists(path) Then
            Me.Path = path
        End If

        If ID <= 0 Then
            ID = New Random().Next(1, Integer.MaxValue)
        End If

        Me.ID = ID

        Loading(setViewer)
    End Sub

    Private m_foldingManager As FoldingManager = Nothing
    Private m_foldderingStrategy As LFFoldingStrategy = Nothing
    Private Delegate Sub DataObjectPastingEventHandler(sender As Object, e As DataObjectPastingEventArgs)
    Private Sub Loading(ByVal setView As Boolean)
        If opt_folding Then
            m_foldingManager = FoldingManager.Install(AvalonEditor.TextArea)
            m_foldderingStrategy = New LFFoldingStrategy()
        End If


        If opt_autocomplete Then
            AddHandler AvalonEditor.TextArea.TextEntered, AddressOf AvalonEditor_TextEntered
        End If

        AddHandler AvalonEditor.TextArea.MouseRightButtonDown, AddressOf AvalonEditor_MouseButtonEvent
        Dim host As New ElementHost With {.Dock = DockStyle.Fill}
        AvalonEditor.FontFamily = opt_userFontFamily 'Courier New")
        AvalonEditor.FontSize = opt_userFontSize
        AvalonEditor.ShowLineNumbers = True
        If IO.File.Exists(Path) Then
            Try
                AvalonEditor.Text = globalFunctions.DatFileToPlainText(Path)
            Catch ex As Exception
            End Try
        End If
        If setView Then
            Viewer = New ui_frameViewer(Path, Me, ID) With {.HideOnClose = True}
        End If


        'DataObject.AddPastingHandler(AvalonEditor.TextArea, AddressOf AvalonEditor_Pasting)


        host.Child = AvalonEditor
        Controls.Add(host)

        ErrorSearcher = New ErrorSearcher(Me)

        IsSave = Path.Length > 2
        If Not IsSave Then
            Me.Text &= "*"
        End If
    End Sub

    Private m_lastTextChanged As Date = Date.Now
    Private Sub AvalonEditor_TextChanged(sender As Object, e As EventArgs) Handles AvalonEditor.TextChanged
        IsSave = False
        m_lastTextChanged = Date.Now
        If Not isStarting Then
            If Not tim_ErrorChecker.Enabled Then tim_ErrorChecker.Start()
            If Not tim_UnusedFrames.Enabled Then tim_UnusedFrames.Start()

            RaiseEvent EditorTextChanged(AvalonEditor, New EventArgs())
        Else
            SetFolding()
        End If


        If AvalonEditor.TextArea.Caret.Offset < 1000 And m_frame.Offset < 0 Then
            RaiseEvent HeaderChanged(Me, New class_customEventArgs(AvalonEditor.Document.GetText(0, If(AvalonEditor.Document.TextLength < 1000, AvalonEditor.Document.TextLength, 1000))))
        End If
        If m_frame.Offset >= 0 Then
            getFrame(AvalonEditor.TextArea.Caret.Line)
        End If
    End Sub

    Dim CompletionWindow As CompletionWindow = Nothing
    Private Sub AvalonEditor_TextEntered(sender As Object, e As TextCompositionEventArgs)
        If e.Text.Equals(vbLf) Then
            Exit Sub
        End If
        If opt_autocomplete Then
            CompletionWindow = New CompletionWindow(AvalonEditor.TextArea)
            Dim data As IList(Of ICompletionData) = CompletionWindow.CompletionList.CompletionData

            Dim dline As AvalonEdit.Document.IDocumentLine = AvalonEditor.TextArea.Document.GetLineByNumber(AvalonEditor.TextArea.Caret.Line)
            Dim wordOffset As Integer = AvalonEditor.TextArea.Caret.Offset
            Dim lineTxt As String = AvalonEditor.Document.GetText(dline.Offset, dline.Length)
            Dim word As String = ""
            Dim spaces As String = ""
            Do While wordOffset > dline.Offset
                Dim chr As Char = lineTxt(dline.Length - (dline.Offset + dline.Length - wordOffset) - 1)
                If Char.IsWhiteSpace(chr) Then
                    spaces = chr & spaces
                ElseIf Char.IsControl(chr) Then
                    Exit Do
                Else
                    If spaces.Count = 0 Then
                        word = chr & word
                    Else
                        Exit Do
                    End If
                End If
                wordOffset -= 1
            Loop

            If word.Length > 0 Then
                Dim wordList As New List(Of String)
                For Each wrd As String In listOfAutoItems
                    Dim mtcWrd As String = wrd.Substring(0, If(wrd.Length > word.Length, word.Length, wrd.Length))
                    If word.StartsWith(mtcWrd) Then
                        data.Add(New CustomCompletionData(wrd, spaces))
                    End If
                Next


            End If

            If data.Count > 0 Then
                CompletionWindow.Show()
                AddHandler CompletionWindow.Closed, New EventHandler(Sub(ByVal sender2 As CompletionWindow, ByVal e2 As EventArgs)
                                                                         CompletionWindow = Nothing
                                                                     End Sub)
            End If
        End If
    End Sub

    Private Sub AvalonEditor_PreviewMouseUp(sender As Object, e As MouseButtonEventArgs) Handles AvalonEditor.PreviewMouseUp
        If Not lastLine = AvalonEditor.TextArea.Caret.Line Then
            Dim lastID As Integer = Me.lastID
            getFrame(AvalonEditor.TextArea.Caret.Line)
            lastLine = AvalonEditor.TextArea.Caret.Line
            If Not lastID = Me.lastID Then
                m_PreviousFramesList.Clear()
            End If
        End If
    End Sub
    Private Sub AvalonEditor_PreviewKeyUp(sender As Object, e As KeyEventArgs) Handles AvalonEditor.PreviewKeyUp
        If Not lastLine = AvalonEditor.TextArea.Caret.Line Then
            Dim lastID As Integer = Me.lastID
            getFrame(AvalonEditor.TextArea.Caret.Line)
            lastLine = AvalonEditor.TextArea.Caret.Line
            If Not lastID = Me.lastID Then
                m_PreviousFramesList.Clear()
            End If
        End If
    End Sub
    Private Sub AvalonEditor_MouseButtonEvent(sender As Object, e As MouseButtonEventArgs)
        cms_.Show(MousePosition)
    End Sub

    Private Sub AvalonEditor_MouseEnter(sender As Object, e As EventArgs) Handles AvalonEditor.MouseEnter
        If Not AvalonEditor.IsFocused And Not SearchWindow.Visible Then
            AvalonEditor.Focus()
        End If
    End Sub

    Private Sub AvalonEditor_MouseClick(sender As Object, e As MouseEventArgs) Handles AvalonEditor.MouseDown
        If Not AvalonEditor.IsFocused Then
            AvalonEditor.Focus()
        End If
    End Sub

    Private Sub AvalonEditor_Pasting(ByVal sender As Object, ByVal e As DataObjectPastingEventArgs)
        Dim text As String = CType(e.DataObject.GetData(GetType(String)), String)

        Dim dataObj As DataObject = pasing(text)
        If Not IsNothing(dataObj) Then
            e.DataObject = dataObj
        End If
    End Sub

    Private Function pasing(ByVal text As String) As DataObject
        If text.Length > 5 Then
            Dim inputFrames As MatchCollection = Regex.Matches(text, "\<frame\>.*?\<frame_end\>", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Multiline)
            Dim unusedFrameList As New List(Of Integer)
            If inputFrames.Count > 0 Then


                Dim firstFrame As Match = inputFrames(0)
                If firstFrame.Success Then
                    Dim frameID As Integer = getRegexValueInteger(firstFrame.Value, "(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase, 0)
                    unusedFrameList.AddRange(UnusedFrames.getFreeIDs(inputFrames.Count, frameID))
                Else
                    unusedFrameList.AddRange(UnusedFrames.getFreeIDs(inputFrames.Count))
                End If

                If unusedFrameList.Count = inputFrames.Count Then
                    Dim oldIDsToNew As New Dictionary(Of Integer, Integer)
                    Dim indexID As Integer = unusedFrameList.Count - 1
                    For i As Integer = inputFrames.Count - 1 To 0 Step -1
                        Dim frame As Match = inputFrames(i)
                        If frame.Success Then
                            Dim frameID As Integer = getRegexValueInteger(frame.Value, "(?<=\<frame\>\s*)[0-9]+", RegexOptions.IgnoreCase)

                            If frameID >= 0 And frameID < 399 Then
                                Dim rgx As New Regex("(?<=\<frame\>\s*)" & frameID, RegexOptions.IgnoreCase)
                                text = rgx.Replace(text, unusedFrameList(indexID).ToString, 1, frame.Index)

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
                            Dim nextID As Integer = getRegexValueInteger(frame.Value, "(?<=next:\s*)[-0-9]+", RegexOptions.IgnoreCase, 400)

                            If Math.Abs(nextID) < 399 Then
                                If oldIDsToNew.ContainsKey(Math.Abs(nextID)) Then
                                    Dim newID As Integer = oldIDsToNew(Math.Abs(nextID))
                                    If nextID < 0 Then
                                        newID *= -1
                                    End If

                                    Dim rgx As New Regex("(?<=next:\s*)" & nextID, RegexOptions.IgnoreCase)
                                    text = rgx.Replace(text, newID.ToString, 1, frame.Index)
                                End If
                            End If


                            Dim hites As MatchCollection = Regex.Matches(frame.Value, "hit_[A-Za-z]+:\s*[-0-9]+", RegexOptions.IgnoreCase)
                            For k As Integer = hites.Count - 1 To 0 Step -1
                                Dim hit As Match = hites(k)
                                If hit.Success Then
                                    Dim hitVal As Integer = getRegexValueInteger(hit.Value, "(?<=hit_[A-Za-z]+:\s*)[-0-9]+", RegexOptions.IgnoreCase, -400)
                                    Dim hitName As String = getRegexValue(hit.Value, "hit_[A-Za-z]+:", RegexOptions.IgnoreCase)
                                    If hitVal > -399 And hitVal < 399 And Not hitVal = 0 And Not IsNothing(hitName) Then

                                        If oldIDsToNew.ContainsKey(Math.Abs(hitVal)) Then
                                            Dim newID As Integer = oldIDsToNew(Math.Abs(hitVal))
                                            If hitVal < 0 Then
                                                newID *= -1
                                            End If

                                            Dim rgx As New Regex("(?<=" & hitName & "\s*)[-0-9]+", RegexOptions.IgnoreCase)
                                            text = rgx.Replace(text, newID.ToString, 1, frame.Index)
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next

                    Dim d As DataObject = New DataObject()
                    d.SetData(DataFormats.Text, text)
                    Return d
                End If
            End If
        End If

        Return Nothing
    End Function

    Dim lastLine As Integer = -1
    Dim lastID As Integer = -1
    Public IDToFacing As New Dictionary(Of Integer, Boolean)
    Private Sub getFrame(ByVal lineIndex As Integer)
        Dim getIndex As Integer = lineIndex
        Dim frame As class_frame = Nothing

        Do While True
            If getIndex < 1 Or getIndex < lineIndex - 100 Then
                Exit Do
            End If

            Dim line As AvalonEdit.Document.DocumentLine = AvalonEditor.Document.GetLineByNumber(getIndex)
            Dim lineStr As String = AvalonEditor.Document.GetText(line.Offset, line.Length)

            If lineStr.Trim.ToLower.StartsWith("<frame_end>") And Not getIndex = lineIndex Then
                Exit Do
            End If

            Dim mtch As Match = Regex.Match(lineStr, "(?<=<frame>\s*)[0-9]+", RegexOptions.IgnoreCase)
            If mtch.Success Then
                lastID = getRegexValueInteger(lineStr, "[0-9]+", RegexOptions.IgnoreCase, -1)
                frame = New class_frame With {.Offset = line.Offset}
                Exit Do
            End If

            getIndex -= 1
        Loop

        getIndex += 1
        Do While Not IsNothing(frame)
            If getIndex < 1 Or getIndex > lineIndex + 100 Then
                Exit Do
            End If

            Dim line As AvalonEdit.Document.DocumentLine = AvalonEditor.Document.GetLineByNumber(getIndex)
            Dim lineStr As String = AvalonEditor.Document.GetText(line.Offset, line.Length)
            If lineStr.Trim.ToLower.StartsWith("<frame_end>") Then
                frame.Length = line.Offset - frame.Offset
                frame.Lines = AvalonEditor.Document.GetText(frame.Offset, frame.Length)
                Exit Do
            End If

            getIndex += 1
        Loop

        If Not IsNothing(frame) Then
            Dim bodies As MatchCollection = Regex.Matches(frame.Lines, "(^bdy:|\s+bdy):.{30,100}(bdy_end:)", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            For Each mtc As Match In bodies
                If mtc.Success Then
                    frame.OffsetBodies.Add(New Drawing.Point(frame.Offset + mtc.Index, frame.Offset + mtc.Index + mtc.Length))
                End If
            Next

            Dim itrs As MatchCollection = Regex.Matches(frame.Lines, "(^itr:|\s+itr):.{30,150}(itr_end:)", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            For Each mtc As Match In itrs
                If mtc.Success Then
                    frame.OffsetItrs.Add(New Drawing.Point(frame.Offset + mtc.Index, frame.Offset + mtc.Index + mtc.Length))
                End If
            Next



            Dim bpoint As Match = Regex.Match(frame.Lines, "(?<=(^bpoint|\s+bpoint):).+(?=bpoint_end:)", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If bpoint.Success Then
                frame.OffsetBPoint = New Drawing.Point(frame.Offset + bpoint.Index, frame.Offset + bpoint.Index + bpoint.Length)
            End If
            Dim wpoint As Match = Regex.Match(frame.Lines, "(?<=(^wpoint|\s+wpoint):).+(?=wpoint_end:)", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If wpoint.Success Then
                frame.OffsetWPoint = New Drawing.Point(frame.Offset + wpoint.Index, frame.Offset + wpoint.Index + wpoint.Length)
            End If
            Dim cpoint As Match = Regex.Match(frame.Lines, "(?<=(^cpoint|\s+cpoint):).+(?=cpoint_end:)", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If cpoint.Success Then
                frame.OffsetCPoint = New Drawing.Point(frame.Offset + cpoint.Index, frame.Offset + cpoint.Index + cpoint.Length)
            End If
            Dim opoint As Match = Regex.Match(frame.Lines, "(?<=(^opoint|\s+opoint):).+(?=opoint_end:)", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            If opoint.Success Then
                frame.OffsetOPoint = New Drawing.Point(frame.Offset + opoint.Index, frame.Offset + opoint.Index + opoint.Length)
            End If
        End If



        If Not IsNothing(frame) Then
            If frame.Offset >= 0 And frame.Length > 2 Then
                ' If Not frame.Offset = m_frame.Offset Then = Perhaps it was changed a value
                RaiseEvent FrameChanged(Me, New class_customEventArgs(frame.Lines))
                'End If
            End If
            m_frame = frame
        ElseIf m_frame.Offset >= 0 Then 'last frame exists; now it is not more frame => set frame to invalid
            RaiseEvent FrameChanged(Me, New class_customEventArgs(Nothing))
            m_frame.Offset = -1
        End If
    End Sub


    Private Sub tim_frameChecker_Tick(sender As Object, e As EventArgs) Handles tim_ErrorChecker.Tick
        If (Date.Now - m_lastTextChanged).TotalMilliseconds > 1000 Then
            SetErrorList()
            tim_ErrorChecker.Stop()
        End If
    End Sub

    Private Sub tim_UnusedFrames_Tick(sender As Object, e As EventArgs) Handles tim_UnusedFrames.Tick
        If (Date.Now - m_lastTextChanged).TotalMilliseconds > 250 Then
            SetUnusedFramesList()
            SetFolding()
        End If
    End Sub

    Private Sub SetFolding() Implements ITextEditor.SetFolding
        If Not IsNothing(m_foldingManager) And Not IsNothing(m_foldderingStrategy) And opt_folding Then
            m_foldderingStrategy.UpdateFoldings(m_foldingManager, AvalonEditor.Document)
        End If
    End Sub


    Private Sub Expand(Optional ByVal expand As Boolean = False) Implements ITextEditor.Expand, ITextEditor.Collapse
        If Not IsNothing(m_foldingManager) And opt_folding Then
            For Each fs As FoldingSection In m_foldingManager.AllFoldings
                fs.IsFolded = expand
            Next
        End If
    End Sub



    Private Sub FrameViewerWillChangeContent(ByVal LFFrame As LFFrame, ByVal e As class_customEventArgs)
        If IsNothing(e.Object) Or IsNothing(e.Object2) Then
            Exit Sub
        End If
        If Not TypeOf (e.Object) Is FrameChangeType Or Not TypeOf (e.Object2) Is Integer Then
            Exit Sub
        End If
        Dim changeType As FrameChangeType = Convert.ToInt16(e.Object)
        Dim oldSelectOffset As Integer = AvalonEditor.SelectionStart
        Dim oldSelectLength As Integer = AvalonEditor.SelectionLength

        AvalonEditor.SelectionLength = 0


        If changeType = FrameChangeType.Bdy Or changeType = FrameChangeType.Itr Then
            Dim selectedIndex As Integer = Convert.ToInt16(e.Object2)
            Dim selectedThing As bdy = Nothing
            If changeType = FrameChangeType.Bdy And selectedIndex < m_frame.OffsetBodies.Count Then
                AvalonEditor.SelectionStart = m_frame.OffsetBodies(selectedIndex).X
                AvalonEditor.SelectionLength = m_frame.OffsetBodies(selectedIndex).Y - m_frame.OffsetBodies(selectedIndex).X
                selectedThing = LFFrame.Bodys(selectedIndex)
            ElseIf changeType = FrameChangeType.Itr And selectedIndex < m_frame.OffsetItrs.Count Then
                AvalonEditor.SelectionStart = m_frame.OffsetItrs(selectedIndex).X
                AvalonEditor.SelectionLength = m_frame.OffsetItrs(selectedIndex).Y - m_frame.OffsetItrs(selectedIndex).X
                selectedThing = LFFrame.Itrs(selectedIndex)
            End If

            If Not IsNothing(selectedThing) Then
                Dim newText As String = AvalonEditor.SelectedText

                newText = Regex.Replace(newText, "(?<=(^x:|\s+x:)\s*)[0-9-]+", selectedThing.Rect.X, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
                newText = Regex.Replace(newText, "(?<=(^y:|\s+y:)\s*)[0-9-]+", selectedThing.Rect.Y, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
                If (selectedThing.Rect.Width > 0) Then newText = Regex.Replace(newText, "(?<=(^w:|\s+w:)\s*)[0-9]+", selectedThing.Rect.Width, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
                If (selectedThing.Rect.Height > 0) Then newText = Regex.Replace(newText, "(?<=(^h:|\s+h:)\s*)[0-9]+", selectedThing.Rect.Height, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))

                AvalonEditor.SelectedText = newText
            End If


        ElseIf changeType = FrameChangeType.WPoint Then
            AvalonEditor.SelectionStart = m_frame.OffsetWPoint.X
            AvalonEditor.SelectionLength = m_frame.OffsetWPoint.Y - m_frame.OffsetWPoint.X

            Dim newText As String = AvalonEditor.SelectedText
            newText = Regex.Replace(newText, "(?<=(^x:|\s+x:)\s*)[0-9-]+", LFFrame.WPoint.Loca.X, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            newText = Regex.Replace(newText, "(?<=(^y:|\s+y:)\s*)[0-9-]+", LFFrame.WPoint.Loca.Y, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            newText = Regex.Replace(newText, "(?<=(^weaponact:|\s+weaponact:)\s*)[0-9-]+", LFFrame.WPoint.Weaponact, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            AvalonEditor.SelectedText = newText


        ElseIf changeType = FrameChangeType.OPoint Then
            AvalonEditor.SelectionStart = m_frame.OffsetOPoint.X
            AvalonEditor.SelectionLength = m_frame.OffsetOPoint.Y - m_frame.OffsetOPoint.X

            Dim newText As String = AvalonEditor.SelectedText
            newText = Regex.Replace(newText, "(?<=(^x:|\s+x:)\s*)[0-9-]+", LFFrame.OPoint.X, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            newText = Regex.Replace(newText, "(?<=(^y:|\s+y:)\s*)[0-9-]+", LFFrame.OPoint.Y, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            AvalonEditor.SelectedText = newText


        ElseIf changeType = FrameChangeType.BPoint Then
            AvalonEditor.SelectionStart = m_frame.OffsetBPoint.X
            AvalonEditor.SelectionLength = m_frame.OffsetBPoint.Y - m_frame.OffsetBPoint.X

            Dim newText As String = AvalonEditor.SelectedText
            newText = Regex.Replace(newText, "(?<=(^x:|\s+x:)\s*)[0-9-]+", LFFrame.BPoint.X, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            newText = Regex.Replace(newText, "(?<=(^y:|\s+y:)\s*)[0-9-]+", LFFrame.BPoint.Y, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            AvalonEditor.SelectedText = newText


        ElseIf changeType = FrameChangeType.CPoint Then
            AvalonEditor.SelectionStart = m_frame.OffsetCPoint.X
            AvalonEditor.SelectionLength = m_frame.OffsetCPoint.Y - m_frame.OffsetCPoint.X

            Dim newText As String = AvalonEditor.SelectedText
            newText = Regex.Replace(newText, "(?<=(^x:|\s+x:)\s*)[0-9-]+", LFFrame.CPoint.X, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            newText = Regex.Replace(newText, "(?<=(^y:|\s+y:)\s*)[0-9-]+", LFFrame.CPoint.Y, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            AvalonEditor.SelectedText = newText

        ElseIf changeType = FrameChangeType.CenterXY Then
            AvalonEditor.SelectionStart = m_frame.Offset
            AvalonEditor.SelectionLength = m_frame.Length

            Dim newText As String = AvalonEditor.SelectedText
            newText = Regex.Replace(newText, "(?<=(^centerx:|\s+centerx:)\s*)[0-9-]+", LFFrame.Center.X, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            newText = Regex.Replace(newText, "(?<=(^centery:|\s+centery:)\s*)[0-9-]+", LFFrame.Center.Y, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5))
            AvalonEditor.SelectedText = newText
        End If


        AvalonEditor.SelectionLength = 0
        AvalonEditor.SelectionStart = oldSelectOffset
        AvalonEditor.SelectionLength = oldSelectLength
    End Sub

    Private Sub FrameViewerWillDeleteSomething(ByVal LFFrame As LFFrame, ByVal e As class_customEventArgs)
        If IsNothing(e.Object) Or IsNothing(e.Object2) Then
            Exit Sub
        End If
        If Not TypeOf (e.Object) Is FrameChangeType Or Not TypeOf (e.Object2) Is Integer Then
            Exit Sub
        End If
        Dim changeType As FrameChangeType = Convert.ToInt16(e.Object)

        Dim oldSelectOffset As Integer = AvalonEditor.SelectionStart
        Dim oldSelectLength As Integer = AvalonEditor.SelectionLength

        AvalonEditor.SelectionLength = 0

        If changeType = FrameChangeType.Bdy Then
            Dim selectedIndex As Integer = Convert.ToInt16(e.Object2)
            If selectedIndex < m_frame.OffsetBodies.Count Then
                AvalonEditor.SelectionStart = m_frame.OffsetBodies(selectedIndex).X
                AvalonEditor.SelectionLength = m_frame.OffsetBodies(selectedIndex).Y - m_frame.OffsetBodies(selectedIndex).X
                AvalonEditor.SelectedText = ""
            End If
        ElseIf changeType = FrameChangeType.Itr Then
            Dim selectedIndex As Integer = Convert.ToInt16(e.Object2)
            If selectedIndex < m_frame.OffsetItrs.Count Then
                AvalonEditor.SelectionStart = m_frame.OffsetItrs(selectedIndex).X
                AvalonEditor.SelectionLength = m_frame.OffsetItrs(selectedIndex).Y - m_frame.OffsetItrs(selectedIndex).X
                AvalonEditor.SelectedText = ""
            End If
        End If


        AvalonEditor.SelectionLength = 0
        AvalonEditor.SelectionStart = oldSelectOffset
        AvalonEditor.SelectionLength = oldSelectLength
    End Sub

    Private Sub FrameViewerWillAddSomething(ByVal changeType As FrameChangeType, ByVal e As class_customEventArgs)
        If IsNothing(e.Object) Then
            Exit Sub
        End If

        If TypeOf (e.Object) Is Rectangle Then
            Dim rect As Rectangle = CType(e.Object, Rectangle)
            If changeType = FrameChangeType.Bdy Then
                If Not m_frame.Offset < 0 Then
                    Dim docLine As AvalonEdit.Document.DocumentLine = AvalonEditor.Document.GetLineByOffset(m_frame.Offset + m_frame.Length)
                    If Not IsNothing(docLine) Then
                        Dim txt As String = AvalonEditor.Document.GetText(docLine.Offset, docLine.Length)
                        If Regex.IsMatch(txt, "<frame_end>", RegexOptions.IgnoreCase) Then
                            Dim oldSel As Integer = AvalonEditor.SelectionStart
                            Dim oldSelLen As Integer = AvalonEditor.SelectionLength

                            AvalonEditor.SelectionLength = 0
                            AvalonEditor.SelectionStart = docLine.Offset
                            AvalonEditor.SelectionLength = docLine.Length
                            AvalonEditor.SelectedText = "   bdy:  x: " & rect.X & "  y: " & rect.Y & "  w: " & rect.Width & "  h: " & rect.Height & "  bdy_end:" &
                                                        vbNewLine & AvalonEditor.SelectedText

                            If oldSel >= 0 And oldSelLen >= 0 Then
                                AvalonEditor.SelectionLength = 0
                                AvalonEditor.SelectionStart = oldSel
                                AvalonEditor.SelectionLength = oldSelLen
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private m_PreviousFramesList As New List(Of Integer)
    Private Sub FrameViewerWillNextFrame(ByVal sender As Object, ByVal e As EventArgs)
        If m_frame.Offset >= 0 Then
            lastFrameID = -1
            Dim line As AvalonEdit.Document.IDocumentLine = AvalonEditor.Document.GetLineByOffset(m_frame.Offset + m_frame.Length)
            Do While True
                If IsNothing(line) Then Exit Do

                Dim txt As String = AvalonEditor.Document.GetText(line.Offset, line.Length)
                If Regex.IsMatch(txt, "<frame>", RegexOptions.IgnoreCase) Then
                    getFrame(line.LineNumber)
                    Exit Do
                End If

                If line.LineNumber > 0 Then
                    line = line.NextLine
                Else
                    Exit Do
                End If
            Loop
            m_PreviousFramesList.Clear()
        End If
    End Sub

    Private Sub FrameViewerWillPreviousFrame(ByVal sender As Object, ByVal e As EventArgs)
        If m_frame.Offset >= 0 Then
            lastFrameID = -1
            Dim line As AvalonEdit.Document.IDocumentLine = AvalonEditor.Document.GetLineByOffset(m_frame.Offset).PreviousLine
            Do While True
                If IsNothing(line) Then Exit Do

                Dim txt As String = AvalonEditor.Document.GetText(line.Offset, line.Length)
                If Regex.IsMatch(txt, "<frame>", RegexOptions.IgnoreCase) Then
                    getFrame(line.LineNumber)
                    Exit Do
                End If

                If line.LineNumber > 0 Then
                    line = line.PreviousLine
                Else
                    Exit Do
                End If
            Loop
            m_PreviousFramesList.Clear()
        End If
    End Sub

    Dim lastFrameID As Integer = -1
    Private Sub FrameViewerWillNextRealFrame(ByVal sender As Object, ByVal e As EventArgs)
        If m_frame.Offset >= 0 Then
            If Not IsNothing(sender) Then
                If TypeOf (sender) Is Integer Then
                    Dim searchID As Integer = Math.Abs(CType(sender, Integer))
                    lastFrameID = searchID
                    If searchID > 0 Then
                        Dim searchMatch As Match = Regex.Match(AvalonEditor.Text, "<frame>\s*(" & searchID & "$|" & searchID & "\n|" & searchID & "\r|" & searchID & "\s+)", RegexOptions.IgnoreCase)
                        If searchMatch.Success Then
                            m_PreviousFramesList.Add(searchID)
                            getFrame(AvalonEditor.Document.GetLineByOffset(searchMatch.Index).LineNumber)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FrameViewerWillPreviousRealFrame(ByVal sender As Object, ByVal e As EventArgs)
        If m_frame.Offset >= 0 Then
            If m_PreviousFramesList.Count > 0 Then
                Dim searchID As Integer = m_PreviousFramesList(m_PreviousFramesList.Count - 1)
                Dim searchMatch As Match = Regex.Match(AvalonEditor.Text, "<frame>\s*(" & searchID & "$|" & searchID & "\n|" & searchID & "\r|" & searchID & "\s+)", RegexOptions.IgnoreCase)
                If searchMatch.Success Then
                    getFrame(AvalonEditor.Document.GetLineByOffset(searchMatch.Index).LineNumber)
                    m_PreviousFramesList.RemoveAt(m_PreviousFramesList.Count - 1)
                    Exit Sub
                End If
            End If

            If Not IsNothing(sender) Then
                If TypeOf (sender) Is Integer Then
                    Dim searchID As Integer = Math.Abs(CType(sender, Integer))
                    lastFrameID = searchID
                    If searchID > 0 Then
                        Dim searchMatch As Match = Regex.Match(AvalonEditor.Text, "next:\s*[\-]{0,1}(" & searchID & "$|" & searchID & "\n|" & searchID & "\r|" & searchID & "\s+)", RegexOptions.IgnoreCase)
                        If searchMatch.Success Then
                            Dim int As Integer = getRegexValueInteger(searchMatch.Value, "[\-]{0,1}[0-9]+", RegexOptions.IgnoreCase, 0)
                            If IDToFacing.ContainsKey(Math.Abs(int)) Then
                                IDToFacing(Math.Abs(int)) = (int < 0)
                            Else
                                IDToFacing.Add(Math.Abs(int), (int < 0))
                            End If

                            getFrame(AvalonEditor.Document.GetLineByOffset(searchMatch.Index).LineNumber)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

#Region "Edit"
    Private Sub cms__Opening(sender As Object, e As CancelEventArgs) Handles cms_.Opening
        TSMI_cut.Enabled = AvalonEditor.SelectionLength > 0
        TSMI_copy.Enabled = AvalonEditor.SelectionLength > 0
        TSMI_delete.Enabled = AvalonEditor.SelectionLength > 0

        TSMI_paste.Enabled = My.Computer.Clipboard.ContainsText
        TSMI_paste_cool.Enabled = My.Computer.Clipboard.ContainsText

        TSMI_frameViewer.Checked = Viewer.Visible
    End Sub

    Private Sub TSMI_cut_Click(sender As Object, e As EventArgs) Handles TSMI_cut.Click
        AvalonEditor.Cut()
    End Sub

    Private Sub TSMI_copy_Click(sender As Object, e As EventArgs) Handles TSMI_copy.Click
        AvalonEditor.Copy()
    End Sub

    Private Sub TSMI_paste_Click(sender As Object, e As EventArgs) Handles TSMI_paste.Click
        AvalonEditor.Paste()
    End Sub

    Private Sub TSMI_paste_cool_Click(sender As Object, e As EventArgs) Handles TSMI_paste_cool.Click
        PasteCool()
    End Sub

    Private Sub PasteCool() Implements ITextEditor.PasteCool
        If My.Computer.Clipboard.ContainsText Then
            Dim text As String = My.Computer.Clipboard.GetText()

            Dim dataObj As DataObject = pasing(text)
            If Not IsNothing(dataObj) Then
                My.Computer.Clipboard.SetText(CType(dataObj.GetData(GetType(String)), String))
                AvalonEditor.Paste()

                My.Computer.Clipboard.SetText(text)
            End If
        End If
    End Sub

    Private Sub TSMI_delete_Click(sender As Object, e As EventArgs) Handles TSMI_delete.Click
        AvalonEditor.Delete()
    End Sub

    Private Sub TSMI_selectAll_Click(sender As Object, e As EventArgs) Handles TSMI_selectAll.Click
        AvalonEditor.SelectAll()
    End Sub

    Private Sub TSMI_frameViewer_Click(sender As Object, e As EventArgs) Handles TSMI_frameViewer.Click
        RaiseEvent CurrentFrameViewerChanger(Me, e)
    End Sub
#End Region


    Private Sub ui_textEditor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = Not CloseDocument()
        If Not e.Cancel Then
            If Not IsNothing(m_viewer) Then
                'm_viewer.HideOnClose = False
                m_viewer.Close()
            End If
        End If
    End Sub

    Public Function CloseDocument() As Boolean Implements ITextEditor.CloseDocument
        If Not IsSave Then
            Dim dResult As DialogResult = MessageBox.Show("Do you want save """ & If(Path.Length < 2, "The new file", Path) & """?", "Easier Data-Editor    -   Save file?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If dResult = DialogResult.Yes Then
                Save(Me.Path.Length < 2)
                Return True
            ElseIf dResult = DialogResult.Cancel Then
                Return False
            End If
        End If
        Return True
    End Function

    Protected Overrides Function GetPersistString() As String
        Dim originalResult As String = MyBase.GetPersistString()
        originalResult &= ";" & Path & ";" & ID
        Return originalResult
    End Function


    Private Sub AvalonEditor_Drop(sender As Object, e As DragEventArgs) Handles AvalonEditor.Drop
        RaiseEvent DropEventOfEditor(e.Data.GetData(DataFormats.FileDrop), New class_customEventArgs(Nothing))
    End Sub
End Class
