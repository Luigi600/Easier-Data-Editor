Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.Integration
Imports ICSharpCode

Public Class ui_frames_reformatting

    Private template As String = ""
    Private template_bdy As String = ""
    Private template_itr As String = ""
    Private template_wpoint As String = ""
    Private template_bpoint As String = ""
    Private template_cpoint As String = ""
    Private template_opoint As String = ""

    ' Private m_editors As New List(Of  AvalonEdit.TextEditor = Nothing
    Private m_updating As Boolean = True

    Private WithEvents m_editorFrame As New AvalonEdit.TextEditor With {.SyntaxHighlighting = syntaxHighlighting}
    Private WithEvents m_editorSubstructure As New AvalonEdit.TextEditor With {.SyntaxHighlighting = syntaxHighlighting}

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub New(ByVal editors As List(Of ITextEditor), Optional ByVal selectedPath As String = "")
        InitializeComponent()
        Dim alreadyAdded As New List(Of String)
        For Each editor As ITextEditor In editors
            If Not alreadyAdded.Contains(editor.Path) Then
                Dim lvItem As New ListViewItem
                lvItem.Text = editor.getDockContent.Text
                If lvItem.Text.EndsWith("*") Then
                    lvItem.Text = lvItem.Text.Substring(0, lvItem.Text.Length - 1)
                End If
                lvItem.SubItems.Add(editor.Path)
                lvItem.Checked = editor.Path.Equals(selectedPath)
                lvItem.Tag = editor.GetAvalonEditor
                lv_files.Items.Add(lvItem)
                alreadyAdded.Add(editor.Path)
            End If
        Next

        Dim host As New ElementHost With {.Dock = DockStyle.Fill}
        m_editorFrame.FontFamily = opt_userFontFamily
        m_editorFrame.FontSize = opt_userFontSize
        m_editorFrame.ShowLineNumbers = True
        host.Child = m_editorFrame
        gb_frame.Controls.Add(host)



        Dim host2 As New ElementHost With {.Dock = DockStyle.Fill}
        m_editorSubstructure.FontFamily = opt_userFontFamily
        m_editorSubstructure.FontSize = opt_userFontSize
        m_editorSubstructure.ShowLineNumbers = True
        host2.Child = m_editorSubstructure
        gb_substructure.Controls.Add(host2)

        host2.BringToFront()

        If IO.File.Exists(IO.Path.Combine(appFolder, "template_frame.txt")) Then
            template = IO.File.ReadAllText(IO.Path.Combine(appFolder, "template_frame.txt"))
        End If
        If template.Length < 5 Then
            template = "<frame>	 $  %FRAMENAME%
	pic: $
	centerx: $ 
	centery: $
	state: $  wait: $  next: $  hit_Uj: $ %others%
%BODIES%
%ITRS%
%WPOINT%
%BPOINT%
%CPOINT%
%OPOINT%
%othersPoints%
<frame_end>"
        End If

        If IO.File.Exists(IO.Path.Combine(appFolder, "template_body.txt")) Then
            template_bdy = IO.File.ReadAllText(IO.Path.Combine(appFolder, "template_body.txt"))
        End If
        If template_bdy.Length < 5 Then
            template_bdy = "   bdy:
      kind: $  x: $  y: $  w: $  h: $ %others%
   bdy_end:"
        End If

        If IO.File.Exists(IO.Path.Combine(appFolder, "template_itr.txt")) Then
            template_itr = IO.File.ReadAllText(IO.Path.Combine(appFolder, "template_itr.txt"))
        End If
        If template_itr.Length < 5 Then
            template_itr = "   itr:
      kind: $  x: $  y: $  w: $  h: $  
      catchingact: $ $  caughtact: $ $  %others%
   itr_end:"
        End If



        If IO.File.Exists(IO.Path.Combine(appFolder, "template_bpoint.txt")) Then
            template_bpoint = IO.File.ReadAllText(IO.Path.Combine(appFolder, "template_bpoint.txt"))
        End If
        If template_bpoint.Length < 5 Then
            template_bpoint = "   bpoint: x: $  y: $  %others% bpoint_end:"
        End If


        If IO.File.Exists(IO.Path.Combine(appFolder, "template_wpoint.txt")) Then
            template_wpoint = IO.File.ReadAllText(IO.Path.Combine(appFolder, "template_wpoint.txt"))
        End If
        If template_wpoint.Length < 5 Then
            template_wpoint = "   wpoint: kind: $  x: $  y: $  weaponact: $  attacking: $  cover: $  dvx: $  dvy: $  dvz: $  %others% wpoint_end:"
        End If


        If IO.File.Exists(IO.Path.Combine(appFolder, "template_cpoint.txt")) Then
            template_cpoint = IO.File.ReadAllText(IO.Path.Combine(appFolder, "template_cpoint.txt"))
        End If
        If template_cpoint.Length < 5 Then
            template_cpoint = "   cpoint:
      kind: $  x: $  y: $  vaction: $  throwvz: $  hurtable: $ throwinjury: $ decrease: $ 
   cpoint_end:"
        End If


        If IO.File.Exists(IO.Path.Combine(appFolder, "template_opoint.txt")) Then
            template_opoint = IO.File.ReadAllText(IO.Path.Combine(appFolder, "template_opoint.txt"))
        End If
        If template_opoint.Length < 5 Then
            template_opoint = "   opoint: kind: $  x: $  y: $  action: $  dvx: $  dvy: $  oid: $  facing: $  opoint_end:"
        End If


        m_editorFrame.Text = template
        comb_substructure.SelectedIndex = 0
        '  gb_frame.Text &= " (" & IO.Path.GetFileName(editor.Path) & ")"
        m_updating = False
    End Sub


    Private Sub comb_substructure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comb_substructure.SelectedIndexChanged
        Select Case comb_substructure.SelectedIndex
            Case 0
                m_editorSubstructure.Text = template_bdy
            Case 1
                m_editorSubstructure.Text = template_itr
            Case 2
                m_editorSubstructure.Text = template_bpoint
            Case 3
                m_editorSubstructure.Text = template_wpoint
            Case 4
                m_editorSubstructure.Text = template_cpoint
            Case 5
                m_editorSubstructure.Text = template_opoint
        End Select
    End Sub


    Private Sub btn_doIt_Click(sender As Object, e As EventArgs) Handles btn_doIt.Click

        If lv_files.CheckedItems.Count = 0 Then
            MessageBox.Show(Me, "You must select one file minimum!", "Easier Data-Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        For Each lv As ListViewItem In lv_files.CheckedItems
            If Not IsNothing(lv.Tag) Then
                If TypeOf (lv.Tag) Is AvalonEdit.TextEditor Then
                    ' Dim m_editor As AvalonEdit.TextEditor = CType(lv.Tag, AvalonEdit.TextEditor)
                    Dim m_editor As New AvalonEdit.TextEditor
                    Dim originalEditor As AvalonEdit.TextEditor = CType(lv.Tag, AvalonEdit.TextEditor)
                    m_editor.Text = originalEditor.Text

                    Dim list As New Dictionary(Of Point, String)
                    Dim framesMatch As MatchCollection = Regex.Matches(m_editor.Text, "(<frame>)[^<>]*<frame_end>", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                    For Each frameMatch As Match In framesMatch
                        If frameMatch.Success Then
                            Dim template_copy As String = template
                            Dim newFrame As String = frameMatch.Value

                            Dim frameID As Integer = getRegexValueInteger(newFrame, "(?<=<frame>\s*)[0-9]+", RegexOptions.IgnoreCase, -1)
                            Dim frameName As String = getRegexValue(newFrame, "(?<=<frame>\s*[0-9]+\s+)[^\s]+", RegexOptions.IgnoreCase)

                            If frameID >= 0 Then
                                template_copy = Regex.Replace(template_copy, "(?<=<frame>\s*)\$", frameID.ToString, RegexOptions.IgnoreCase)
                                template_copy = template_copy.Replace("%FRAMENAME%", frameName)

                                Dim points As MatchCollection = Regex.Matches(newFrame, "\s*(bpoint|wpoint|cpoint|opoint|bdy|itr):[^_]+_end:", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                                For i As Integer = points.Count - 1 To 0 Step -1
                                    Dim point As Match = points(i)
                                    If point.Success Then
                                        newFrame = newFrame.Substring(0, point.Index) & newFrame.Substring(point.Index + point.Length, newFrame.Length - point.Length - point.Index)
                                    End If
                                Next


                                newFrame = Regex.Replace(newFrame, "<frame>\s*[0-9]+[^\n]+\n", "", RegexOptions.IgnoreCase)
                                newFrame = Regex.Replace(newFrame, "<frame_end>", "", RegexOptions.IgnoreCase)
                                WriteToTemplate(newFrame, template_copy) ', "<frame>")

                                For Each match As Match In points
                                    If match.Success Then
                                        Dim selected As FrameChangeType = FrameChangeType.None
                                        Dim input As String = match.Value
                                        Dim pointCopy As String = ""
                                        Dim pointName As String = ""

                                        If Regex.IsMatch(match.Value, "bpoint", RegexOptions.IgnoreCase) Then
                                            selected = FrameChangeType.BPoint
                                            pointName = "bpoint"
                                            pointCopy = template_bpoint
                                        ElseIf Regex.IsMatch(match.Value, "opoint", RegexOptions.IgnoreCase) Then
                                            selected = FrameChangeType.OPoint
                                            pointName = "opoint"
                                            pointCopy = template_opoint
                                        ElseIf Regex.IsMatch(match.Value, "cpoint", RegexOptions.IgnoreCase) Then
                                            selected = FrameChangeType.CPoint
                                            pointName = "cpoint"
                                            pointCopy = template_cpoint
                                        ElseIf Regex.IsMatch(match.Value, "wpoint", RegexOptions.IgnoreCase) Then
                                            selected = FrameChangeType.WPoint
                                            pointName = "wpoint"
                                            pointCopy = template_wpoint
                                        ElseIf Regex.IsMatch(match.Value, "bdy", RegexOptions.IgnoreCase) Then
                                            selected = FrameChangeType.Bdy
                                            pointName = "bdy"
                                            pointCopy = template_bdy
                                        ElseIf Regex.IsMatch(match.Value, "itr", RegexOptions.IgnoreCase) Then
                                            selected = FrameChangeType.Itr
                                            pointName = "itr"
                                            pointCopy = template_itr
                                        End If

                                        input = Regex.Replace(input, pointName & ":[\r\n\s]*", "", RegexOptions.IgnoreCase)
                                        input = Regex.Replace(input, "[\r\n\s]*" & pointName & "_end:", "", RegexOptions.IgnoreCase)
                                        WriteToTemplate(input, pointCopy) ', pointName & ":")

                                        '^([\s#])*(?=%[A-Za-z]+%)

                                        If selected = FrameChangeType.Bdy And template_bdy.Length > 2 Then
                                            template_copy = template_copy.Replace("%BODIES%", pointCopy & vbNewLine & "%BODIES%")
                                        ElseIf selected = FrameChangeType.Itr And template_itr.Length > 2 Then
                                            template_copy = template_copy.Replace("%ITRS%", pointCopy & vbNewLine & "%ITRS%")
                                        ElseIf selected = FrameChangeType.WPoint And template_wpoint.Length > 2 Then
                                            template_copy = template_copy.Replace("%WPOINT%", pointCopy & vbNewLine & "%WPOINT%")
                                        ElseIf selected = FrameChangeType.BPoint And template_bpoint.Length > 2 Then
                                            template_copy = template_copy.Replace("%BPOINT%", pointCopy & vbNewLine & "%BPOINT%")
                                        ElseIf selected = FrameChangeType.CPoint And template_cpoint.Length > 2 Then
                                            template_copy = template_copy.Replace("%CPOINT%", pointCopy & vbNewLine & "%CPOINT%")
                                        ElseIf selected = FrameChangeType.OPoint And template_opoint.Length > 2 Then
                                            template_copy = template_copy.Replace("%OPOINT%", pointCopy & vbNewLine & "%OPOINT%")
                                        Else
                                            template_copy = template_copy.Replace("%othersPoints%", match.Value & vbNewLine & "%othersPoints%")
                                        End If
                                        'template_bdy
                                    End If
                                Next


                                template_copy = Regex.Replace(template_copy, "%[A-Za-z]+%", "", RegexOptions.IgnoreCase)
                                template_copy = Regex.Replace(template_copy, "([^\s]+:\s*\$)\s+\$[^\r\nA-Za-z]*", "", RegexOptions.IgnoreCase)
                                template_copy = Regex.Replace(template_copy, "([^\s]+:\s*\$)[^\S\r\n]*", "", RegexOptions.IgnoreCase)

                                template_copy = Regex.Replace(template_copy, "([^\s]+:\s*\?)\s+\?[^\r\nA-Za-z]*", "", RegexOptions.IgnoreCase)
                                template_copy = Regex.Replace(template_copy, "([^\s]+:\s*\?)[^\S\r\n]*", "", RegexOptions.IgnoreCase)

                                template_copy = Regex.Replace(template_copy, "\r", vbNewLine, RegexOptions.Multiline)
                                template_copy = Regex.Replace(template_copy, "^\n|^\s+(\n)", "", RegexOptions.Multiline)


                                'Console.WriteLine(template_copy)
                                list.Add(New Point(frameMatch.Index, frameMatch.Length), template_copy)
                            End If
                        End If
                    Next

                    For Each entry As KeyValuePair(Of Point, String) In list.Reverse
                        m_editor.SelectionLength = 0
                        m_editor.SelectionStart = entry.Key.X
                        m_editor.SelectionLength = entry.Key.Y
                        m_editor.SelectedText = entry.Value
                    Next

                    Dim oldSelLen As Integer = originalEditor.SelectionLength
                    Dim oldSel As Integer = originalEditor.SelectionStart

                    originalEditor.SelectionLength = 0
                    originalEditor.SelectionStart = 0
                    originalEditor.SelectionLength = originalEditor.Text.Length
                    originalEditor.SelectedText = m_editor.Text

                    originalEditor.SelectionLength = 0
                    Try
                        originalEditor.SelectionStart = oldSel
                        originalEditor.SelectionLength = oldSelLen
                    Catch ex As Exception
                    End Try
                End If
            End If
        Next
    End Sub





    Private Sub WriteToTemplate(ByRef frameText As String, ByRef template As String) ', ByVal setAfter As String)
        '    frameText = Regex.Replace(frameText, "(^[\r\n]$|^\s+$[\r\n])", "", RegexOptions.Multiline)
        Dim attri As MatchCollection = Regex.Matches(frameText, "(^[A-Za-z_]+|[^\s]+):\s*([^\s\r\n:]+\s+[^\s\r\n:]+\s+|[^\s\r\n:]+)", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        For Each attr As Match In attri
            If attr.Success Then
                Dim attri_name As Match = Regex.Match(attr.Value.Trim, "(^[A-Za-z_]+|[^\s]+):", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                Dim attri_value As String = getRegexValue(attr.Value.Trim, "(?<=:\s*)[^\s]+", RegexOptions.IgnoreCase, Nothing)
                Dim attri_value2 As String = getRegexValue(attr.Value.Trim, "(?<=:\s*[^\s]+\s+)[^\s]+", RegexOptions.IgnoreCase, Nothing)

                If attri_name.Success And Not String.IsNullOrWhiteSpace(attri_value) Then
                    If IsNothing(attri_value2) Then
                        Dim attri_ As Match = Regex.Match(template, attri_name.Value & "\s*\$", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                        If attri_.Success Then
                            template = Regex.Replace(template, "(?<=(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*)\$", attri_value.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                            frameText = Regex.Replace(frameText, "(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*[^\s\r\n]+", "")
                        End If
                    Else
                        Dim attri_ As Match = Regex.Match(template, attri_name.Value & "\s*\$\s+\$", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                        If attri_.Success Then
                            template = Regex.Replace(template, "(?<=(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*\$\s+)\$", attri_value2.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                            template = Regex.Replace(template, "(?<=(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*)\$", attri_value.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                            frameText = Regex.Replace(frameText, "(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*[^\s\r\n]+\s+[^\s\r\n]+", "")
                        End If
                    End If
                End If


                'SAME STUFF; ONLY REPLACED "$" TO "?"
                If String.IsNullOrWhiteSpace(attri_value2) Then
                    Dim attri_ As Match = Regex.Match(template, attri_name.Value & "\s*\?", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                    If attri_.Success Then
                        If Not IsNothing(attri_value) Then
                            Dim setVal As Boolean = Not IsNumeric(attri_value)
                            If IsNumeric(attri_value) Then
                                setVal = Not Convert.ToInt64(attri_value) = 0
                            End If

                            If setVal Then
                                template = Regex.Replace(template, "(?<=(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*)\?", attri_value.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                            End If
                        End If

                        frameText = Regex.Replace(frameText, "(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*[^\s\r\n]+", "")
                    End If
                Else
                    Dim attri_ As Match = Regex.Match(template, attri_name.Value & "\s*\?\s+\?", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                    If attri_.Success Then
                        Dim setVal As Boolean = (IsNothing(attri_value) And IsNothing(attri_value2))
                        If Not setVal Then
                            If Not IsNothing(attri_value) Then
                                If IsNumeric(attri_value) Then
                                    setVal = Not Convert.ToInt64(attri_value) = 0
                                End If
                            End If

                            If Not setVal Then
                                If Not IsNothing(attri_value2) Then
                                    If IsNumeric(attri_value2) Then
                                        setVal = Not Convert.ToInt64(attri_value2) = 0
                                    End If
                                End If
                            End If
                        End If


                        If setVal Then
                            template = Regex.Replace(template, "(?<=(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*\?\s+)\?", attri_value2.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                            template = Regex.Replace(template, "(?<=(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*)\?", attri_value.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                        End If

                        frameText = Regex.Replace(frameText, "(^" & attri_name.Value & "|\s+" & attri_name.Value & ")\s*[^\s\r\n]+\s+[^\s\r\n]+", "")
                    End If
                End If
            End If
        Next


        Dim lines As String = ""
        For Each line As String In frameText.Split(vbNewLine)
            If Not String.IsNullOrWhiteSpace(line) Then
                If lines.Count > 0 Then
                    lines &= " "
                End If
                lines &= line.Trim
            End If
        Next
        lines = Regex.Replace(lines, "\s{2,}", " ")


        template = template.Replace("%others%", lines)

        'Dim nextLine As Boolean = False
        'For Each line As String In template.Split(vbNewLine)
        '    If nextLine Then
        '        template = Regex.Replace(template, line.Replace("$", "\$"), line.TrimEnd & " " & lines)
        '        Exit For
        '    Else
        '        If Regex.IsMatch(line, setAfter, RegexOptions.IgnoreCase) Then
        '            nextLine = True
        '        End If
        '    End If
        'Next
    End Sub

    Private Sub m_editorFrame_TextChanged(sender As Object, e As EventArgs) Handles m_editorFrame.TextChanged
        If Not m_updating Then
            template = m_editorFrame.Text
        End If
    End Sub

    Private Sub m_editorSubstructure_TextChanged(sender As Object, e As EventArgs) Handles m_editorSubstructure.TextChanged
        If Not m_updating Then
            Select Case comb_substructure.SelectedIndex
                Case 0
                    template_bdy = m_editorSubstructure.Text
                Case 1
                    template_itr = m_editorSubstructure.Text
                Case 2
                    template_bpoint = m_editorSubstructure.Text
                Case 3
                    template_wpoint = m_editorSubstructure.Text
                Case 4
                    template_cpoint = m_editorSubstructure.Text
                Case 5
                    template_opoint = m_editorSubstructure.Text
            End Select
        End If
    End Sub

    Private Sub btn_abort_Click(sender As Object, e As EventArgs) Handles btn_abort.Click
        Me.Close()
    End Sub

    Private Sub ui_auto_reformatter_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(appFolder, "template_body.txt"), template_bdy, False)
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(appFolder, "template_itr.txt"), template_itr, False)
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(appFolder, "template_bpoint.txt"), template_bpoint, False)
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(appFolder, "template_wpoint.txt"), template_wpoint, False)
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(appFolder, "template_cpoint.txt"), template_cpoint, False)
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(appFolder, "template_opoint.txt"), template_opoint, False)

        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(appFolder, "template_frame.txt"), template, False)
    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        template = "<frame> $ %FRAMENAME%
   pic: $  state: $  wait: $  next: $  dvx: $  dvy: $  dvz: $  centerx: $  centery: $  %others%
%OPOINT%
%CPOINT%
%BPOINT%
%WPOINT%
%ITRS%
%BODIES%
%othersPoints%
<frame_end>"
        template_bdy = "   bdy:
      kind: $  x: $  y: $  w: $  h: $ %others%
   bdy_end:"
        template_itr = "   itr:
      kind: $  x: $  y: $  w: $  h: $  
      catchingact: $ $  caughtact: $ $ %others%
   itr_end:"
        template_wpoint = "   wpoint:
      kind: $  x: $  y: $  weaponact: $  attacking: $  cover: $  dvx: $  dvy: $  dvz: $ %others%
   wpoint_end:"
        template_bpoint = "   bpoint:
      x: $  y: $ %others%
   bpoint_end:"
        template_cpoint = "   cpoint:
      kind: $  x: $  y: $
      vaction: $  throwvz: $  hurtable: $ throwinjury: $ decrease: $ %others% 
   cpoint_end:"
        template_opoint = "   opoint:
      kind: $  x: $  y: $  action: $  dvx: $  dvy: $  oid: $  facing: $ %others%
   opoint_end:"

        m_updating = True
        m_editorFrame.Text = template
        comb_substructure_SelectedIndexChanged(Nothing, New EventArgs())
        m_updating = False
    End Sub

    Private Sub lv_files_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lv_files.ItemChecked
        btn_doIt.Enabled = lv_files.CheckedItems.Count > 0
    End Sub
End Class