Imports System.Windows.Media
Imports ICSharpCode
Imports ICSharpCode.AvalonEdit.CodeCompletion
Imports ICSharpCode.AvalonEdit.Document
Imports ICSharpCode.AvalonEdit.Editing

'------------------------------------------''---------Created by Lui's Studio----------''-------(http://www.lui-studio.net/)-------''------------------------------------------''-------------Author: Luigi600-------------''------------------------------------------'
'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> A completion item for autocomplete </summary>

Public Module CompletionDataStuff
    Public endWordBlock As New List(Of String) From {"frame", "layer", "stage", "weapon_strength_list", "phase"}
    Public endWordWithSpaces As New List(Of String) From {"bdy", "itr", "bpoint", "opoint", "cpoint", "wpoint"}
    Public endWordBlockSpecial As New Dictionary(Of String, String) From {{"<bmp_begin>", "<bmp_end>"}}


    Public descriptions As New Dictionary(Of String, String) From {{"<frame>", "Creates start and end of a frame-block"},
                                                                   {"layer:", "Creates start and end of a layer-block"}}

    Public listOfAutoItems As New List(Of String)
End Module

Public Class CustomCompletionData
    Implements ICompletionData

    Private m_spaces As String = ""

    Public Sub New(ByVal text As String, ByVal spaces As String)
        Me.Text = text
        m_spaces = spaces
    End Sub

    Public Property Text As String Implements ICompletionData.Text

    Public ReadOnly Property Content As Object
        Get
            Return Me.Text
        End Get
    End Property

    Public ReadOnly Property Priority As Double Implements ICompletionData.Priority
        Get
            Return 1.0
        End Get
    End Property

    Private ReadOnly Property ICompletionData_Image As ImageSource Implements ICompletionData.Image
        Get
            Return Nothing
        End Get
    End Property

    Private ReadOnly Property ICompletionData_Content As Object Implements ICompletionData.Content
        Get
            Return "CONTENT"
        End Get
    End Property

    Private ReadOnly Property ICompletionData_Description As Object Implements ICompletionData.Description
        Get
            If descriptions.ContainsKey(Text) Then
                Return descriptions(Text) & "."
            Else
                Return "..."
            End If
        End Get
    End Property

    Private Sub ICompletionData_Complete(textArea As TextArea, completionSegment As ISegment, insertionRequestEventArgs As EventArgs) Implements ICompletionData.Complete
        Dim text As String = Me.Text

        Dim dline As IDocumentLine = textArea.Document.GetLineByNumber(textArea.Caret.Line)
        Dim wordOffset As Integer = textArea.Caret.Offset
        Dim lineTxt As String = textArea.Document.GetText(dline.Offset, dline.Length)
        Dim word As String = ""
        Do While wordOffset > dline.Offset
            Dim chr As Char = lineTxt(dline.Length - (dline.Offset + dline.Length - wordOffset) - 1)
            If Char.IsWhiteSpace(chr) Then Exit Do
            word = chr & word
            wordOffset -= 1
        Loop

        If word.Length > 0 Then
            text = text.Substring(word.Length)
        End If

        textArea.Document.Replace(completionSegment, text)
        Dim friendly As String = getWordFinderFriendly()
        Dim endOffset As Integer = completionSegment.EndOffset
        If endWordBlockSpecial.ContainsKey(Me.Text) Then
            textArea.Document.Insert(endOffset, vbNewLine & m_spaces & vbNewLine & m_spaces & endWordBlockSpecial(Me.Text))
            textArea.Caret.Offset = endOffset + m_spaces.Length + 2
        ElseIf endWordBlock.Contains(friendly) Then
            If Me.Text.Equals("<frame>") Or Me.Text.Equals("<phase>") Then
                textArea.Document.Insert(endOffset, " " & vbNewLine & m_spaces & getBlockEnd())
                textArea.Caret.Offset = endOffset + 2
            ElseIf Me.Text.Equals("layer:") Then
                textArea.Document.Insert(endOffset, vbNewLine & m_spaces & "  " & vbNewLine & m_spaces & getBlockEnd())
                textArea.Caret.Offset = endOffset + m_spaces.Count + 4
            Else
                textArea.Document.Insert(endOffset, vbNewLine & m_spaces & vbNewLine & m_spaces & getBlockEnd())
                textArea.Caret.Offset = endOffset + m_spaces.Count + 2
            End If
        ElseIf endWordWithSpaces.Contains(friendly) Then
            textArea.Document.Insert(endOffset, "  " & getBlockEnd())
            textArea.Caret.Offset = endOffset + 1
        End If
    End Sub


    Private Function getWordFinderFriendly()
        Dim result As String = Me.Text
        If result.StartsWith("<") Then
            result = result.Substring(1)
        End If
        If result.EndsWith(">") Or result.EndsWith(":") Then
            result = result.Substring(0, result.Length - 1)
        End If

        Return result
    End Function

    Private Function getBlockEnd() As String
        If Text.EndsWith(">") Then
            Return Text.Substring(0, Text.Length - 1) & "_end" & ">"
        ElseIf Text.EndsWith(":") Then
            Return Text.Substring(0, Text.Length - 1) & "_end" & ":"
        End If
        Return Text
    End Function
End Class
