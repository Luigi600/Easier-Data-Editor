'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text.RegularExpressions

Public Class FramesReformatting
#Region "Shared Variables"
    Private Shared ReadOnly SYNTAX_SPECIAL As New Syntax(My.Resources.syntax_special)
    Private Shared ReadOnly INPUT_EXAMPLE As String() = Regex.Split(My.Resources.reformatting_example, "[\n\r]+[][][][\n\r]+")
    Private Shared ReadOnly INPUT_RESET As String() = Regex.Split(My.Resources.reformatting_reset, "[\n\r]+[][][][\n\r]+")

    Private Enum EInputIndex
        Frame
        Bdy
        Itr
        BPoint
        WPoint
        CPoint
        OPoint
    End Enum

    Private Shared template As String = ""
    Private Shared template_bdy As String = ""
    Private Shared template_itr As String = ""
    Private Shared template_wpoint As String = ""
    Private Shared template_bpoint As String = ""
    Private Shared template_cpoint As String = ""
    Private Shared template_opoint As String = ""

    Private Sub Prepare()
        If IO.File.Exists(IO.Path.Combine(AppFolder, "template_frame.txt")) Then
            template = IO.File.ReadAllText(IO.Path.Combine(AppFolder, "template_frame.txt"))
        End If
        If template.Length < 5 Then
            template = INPUT_EXAMPLE(EInputIndex.Frame)
        End If

        If IO.File.Exists(IO.Path.Combine(AppFolder, "template_body.txt")) Then
            template_bdy = IO.File.ReadAllText(IO.Path.Combine(AppFolder, "template_body.txt"))
        End If
        If template_bdy.Length < 5 Then
            template_bdy = INPUT_EXAMPLE(EInputIndex.Bdy)
        End If

        If IO.File.Exists(IO.Path.Combine(AppFolder, "template_itr.txt")) Then
            template_itr = IO.File.ReadAllText(IO.Path.Combine(AppFolder, "template_itr.txt"))
        End If
        If template_itr.Length < 5 Then
            template_itr = INPUT_EXAMPLE(EInputIndex.Itr)
        End If



        If IO.File.Exists(IO.Path.Combine(AppFolder, "template_bpoint.txt")) Then
            template_bpoint = IO.File.ReadAllText(IO.Path.Combine(AppFolder, "template_bpoint.txt"))
        End If
        If template_bpoint.Length < 5 Then
            template_bpoint = INPUT_EXAMPLE(EInputIndex.BPoint)
        End If


        If IO.File.Exists(IO.Path.Combine(AppFolder, "template_wpoint.txt")) Then
            template_wpoint = IO.File.ReadAllText(IO.Path.Combine(AppFolder, "template_wpoint.txt"))
        End If
        If template_wpoint.Length < 5 Then
            template_wpoint = INPUT_EXAMPLE(EInputIndex.WPoint)
        End If


        If IO.File.Exists(IO.Path.Combine(AppFolder, "template_cpoint.txt")) Then
            template_cpoint = IO.File.ReadAllText(IO.Path.Combine(AppFolder, "template_cpoint.txt"))
        End If
        If template_cpoint.Length < 5 Then
            template_cpoint = INPUT_EXAMPLE(EInputIndex.CPoint)
        End If


        If IO.File.Exists(IO.Path.Combine(AppFolder, "template_opoint.txt")) Then
            template_opoint = IO.File.ReadAllText(IO.Path.Combine(AppFolder, "template_opoint.txt"))
        End If
        If template_opoint.Length < 5 Then
            template_opoint = INPUT_EXAMPLE(EInputIndex.OPoint)
        End If
    End Sub
#End Region

    Private m_updating As Boolean = True
    Private m_changes As New HashSet(Of EInputIndex)

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatablePrefix = AppTitle
    End Sub

    Public Sub New(ByVal editors As List(Of TextEditor), Optional ByVal selectedID As Integer = -1)
        Variables.Add("MINIMUM", "You must select one file minimum!")
        Variables.Add("OPEN_INTRO", "Open Instruction/Commands")
        Variables.Add("CLOSE_INTRO", "Close Instruction/Commands")
        InitializeComponent()
        Scintilla_Frame.Syntax = SYNTAX_SPECIAL
        Scintilla_Substructure.Syntax = SYNTAX_SPECIAL
        Scintilla_Frame.Settings = App.SpecialSettings
        Scintilla_Substructure.Settings = App.SpecialSettings

        If String.IsNullOrEmpty(template) Then
            Prepare()
        End If

        For Each editor As TextEditor In editors
            Dim lvItem As New ListViewItem With {
                .Text = editor.Text,
                .Tag = editor,
                .Checked = editor.ID = selectedID
            }
            If lvItem.Text.EndsWith("*") Then
                lvItem.Text = lvItem.Text.Substring(0, lvItem.Text.Length - 1)
            End If
            lvItem.SubItems.Add(editor.Path)
            Lv_files.Items.Add(lvItem)
        Next

        Scintilla_Frame.Text = template
        Comb_substructure.SelectedIndex = 0
        '  gb_frame.Text &= " (" & IO.Path.GetFileName(editor.Path) & ")"
        m_updating = False
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
            Case Keys.F5
                Btn_doIt_Click(Btn_doIt, New EventArgs())
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        SplitContainer_Instruction.SplitterDistance = CInt(SplitContainer_Instruction.Width / 2)
    End Sub

    Private Sub Comb_substructure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Comb_substructure.SelectedIndexChanged
        Select Case Comb_substructure.SelectedIndex + 1
            Case EInputIndex.Bdy
                Scintilla_Substructure.Text = template_bdy
            Case EInputIndex.Itr
                Scintilla_Substructure.Text = template_itr
            Case EInputIndex.BPoint
                Scintilla_Substructure.Text = template_bpoint
            Case EInputIndex.WPoint
                Scintilla_Substructure.Text = template_wpoint
            Case EInputIndex.CPoint
                Scintilla_Substructure.Text = template_cpoint
            Case EInputIndex.OPoint
                Scintilla_Substructure.Text = template_opoint
        End Select
    End Sub

    Private Sub Btn_doIt_selected_Click(sender As Object, e As EventArgs) Handles Btn_doIt_selected.Click
        Btn_doIt_Click(sender, Nothing)
    End Sub

    Private Sub Btn_doIt_Click(sender As Object, e As EventArgs) Handles Btn_doIt.Click
        If Lv_files.CheckedItems.Count = 0 Then
            MessageBox.Show(Me, GetVariable("MINIMUM"), "Easier Data-Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        For Each lv As ListViewItem In Lv_files.CheckedItems
            If TypeOf lv.Tag Is TextEditor Then
                CType(lv.Tag, TextEditor).Reformatting(IsNothing(e), Cb_removeEmptyLines.Checked, template, template_bpoint, template_cpoint, template_opoint, template_wpoint, template_bdy, template_itr)
            End If
        Next
    End Sub

    Private Sub M_editorFrame_TextChanged(sender As Object, e As EventArgs) Handles Scintilla_Frame.TextChanged
        If Not m_updating Then
            template = Scintilla_Frame.Text
            m_changes.Add(EInputIndex.Frame)
        End If
    End Sub

    Private Sub M_editorSubstructure_TextChanged(sender As Object, e As EventArgs) Handles Scintilla_Substructure.TextChanged
        If Not m_updating Then
            Select Case Comb_substructure.SelectedIndex + 1
                Case EInputIndex.Bdy
                    template_bdy = Scintilla_Substructure.Text
                Case EInputIndex.Itr
                    template_itr = Scintilla_Substructure.Text
                Case EInputIndex.BPoint
                    template_bpoint = Scintilla_Substructure.Text
                Case EInputIndex.WPoint
                    template_wpoint = Scintilla_Substructure.Text
                Case EInputIndex.CPoint
                    template_cpoint = Scintilla_Substructure.Text
                Case EInputIndex.OPoint
                    template_opoint = Scintilla_Substructure.Text
            End Select

            m_changes.Add(Comb_substructure.SelectedIndex + 1)
        End If
    End Sub

    Private Sub Btn_close_Click(sender As Object, e As EventArgs) Handles Btn_close.Click
        Me.Close()
    End Sub

    Private Sub Closing_(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If m_changes.Contains(EInputIndex.Bdy) Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppFolder, "template_body.txt"), template_bdy, False)
        If m_changes.Contains(EInputIndex.Itr) Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppFolder, "template_itr.txt"), template_itr, False)
        If m_changes.Contains(EInputIndex.BPoint) Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppFolder, "template_bpoint.txt"), template_bpoint, False)
        If m_changes.Contains(EInputIndex.WPoint) Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppFolder, "template_wpoint.txt"), template_wpoint, False)
        If m_changes.Contains(EInputIndex.CPoint) Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppFolder, "template_cpoint.txt"), template_cpoint, False)
        If m_changes.Contains(EInputIndex.OPoint) Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppFolder, "template_opoint.txt"), template_opoint, False)

        If m_changes.Contains(EInputIndex.Frame) Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppFolder, "template_frame.txt"), template, False)
        m_changes.Clear()
    End Sub

    Private Sub Btn_reset_Click(sender As Object, e As EventArgs) Handles Btn_reset.Click
        template = INPUT_RESET(EInputIndex.Frame)
        template_bdy = INPUT_RESET(EInputIndex.Bdy)
        template_itr = INPUT_RESET(EInputIndex.Itr)
        template_bpoint = INPUT_RESET(EInputIndex.BPoint)
        template_wpoint = INPUT_RESET(EInputIndex.WPoint)
        template_cpoint = INPUT_RESET(EInputIndex.CPoint)
        template_opoint = INPUT_RESET(EInputIndex.OPoint)

        For Each val As EInputIndex In [Enum].GetValues(GetType(EInputIndex))
            m_changes.Add(val)
        Next

        m_updating = True
        Scintilla_Frame.Text = template
        Comb_substructure_SelectedIndexChanged(Nothing, New EventArgs())
        m_updating = False
    End Sub

    Private Sub Lv_files_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles Lv_files.ItemChecked
        Btn_doIt.Enabled = Lv_files.CheckedItems.Count > 0
    End Sub

    Private Sub Btn_hideShow_Panel_Click(sender As Object, e As EventArgs) Handles Btn_hideShow_Panel.Click
        SplitContainer_Instruction.Panel2Collapsed = Not SplitContainer_Instruction.Panel2Collapsed

        If Not SplitContainer_Instruction.Panel2Collapsed Then
            Btn_hideShow_Panel.Text = GetVariable("CLOSE_INTRO")
        Else
            Btn_hideShow_Panel.Text = GetVariable("OPEN_INTRO")
        End If
    End Sub

    Private Sub Btn_math_test_Click(sender As Object, e As EventArgs) Handles Btn_math_test.Click
        'CalculateWithException
    End Sub

    Private Sub SplitContainer_Instruction_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer_Instruction.SplitterMoved
        Rtb_Commands.Height = (Rtb_Commands.GetLineFromCharIndex(Rtb_Commands.Text.Length) + 1) * Rtb_Commands.Font.Height + Rtb_Commands.Margin.Vertical
    End Sub

    Private Sub Rtb_information_ContentsResized(sender As RichTextBox, e As ContentsResizedEventArgs) Handles Rtb_information.ContentsResized, Rtb_Commands.ContentsResized
        sender.Height = e.NewRectangle.Height + 5
    End Sub
End Class