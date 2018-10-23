Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports ICSharpCode.AvalonEdit
Imports ICSharpCode.AvalonEdit.Document

'------------------------------------------''---------Created by Lui's Studio----------''-------(http://www.lui-studio.net/)-------''------------------------------------------''-------------Author: Luigi600-------------''------------------------------------------'
'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Search Class to find errors (see ErrorItem) </summary>

Public Class ErrorSearcher
    Private m_editor As ITextEditor = Nothing
    Public Errors As New List(Of ErrorItem)

    Public Sub New(ByRef editor As ITextEditor)
        m_editor = editor
    End Sub

    Public Sub FindErrors()
        Errors.Clear()
        Dim bw As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged

        bw.RunWorkerAsync(m_editor.GetAvalonEditor.Text)
    End Sub

    Private Sub CheckError(ByRef ErrorList As List(Of ErrorItem), ByVal pattern As String, ByVal text As String, ByVal message As String,
                                  Optional ByVal addTolineNumber As Integer = 0,
                                  Optional ByVal addMatchLength As Boolean = True,
                                  Optional ByVal regexOptions As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim matches As MatchCollection = Regex.Matches(text, pattern, regexOptions)
        For Each mtch As Match In matches
            If mtch.Success Then
                Dim newError As New ErrorItem
                newError.Message = message
                newError.Offset = mtch.Index
                If addMatchLength Then
                    newError.Offset += mtch.Length
                End If
                'newError.Line = AvalonEditor.Document.GetLineByOffset(newError.Offset).LineNumber + addTolineNumber
                ErrorList.Add(newError)
            End If
        Next
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs)
        'Dim startDate As Date = Date.Now
        Dim input As String = CType(e.Argument, String)

        CheckError(Errors, "(?<=^(?!#)\s*\<frame\>)[^<>]*\<frame\>", input, "Frame is not ending", -2)
        CheckError(Errors, "(?<=^(?!#)\s*\<frame_end\>)[^<>]*\<frame_end\>", input, "Frame is not starting", 2, False)
        CheckError(Errors, "(^bdy|\s+bdy):((?!bdy).)*_end:", input, "Body ending is missing", 2, False, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        CheckError(Errors, "(^itr|\s+itr):((?!itr).)*_end:", input, "Itr ending is missing", 2, False, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        CheckError(Errors, "(^wpoint|\s+wpoint):((?!wpoint).)*_end:", input, "Weapon-Point ending is missing", 2, False, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        CheckError(Errors, "(^bpoint|\s+bpoint):((?!bpoint).)*_end:", input, "Blood-Point ending is missing", 2, False, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        CheckError(Errors, "(^opoint|\s+opoint):((?!opoint).)*_end:", input, "Object-Point ending is missing", 2, False, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        CheckError(Errors, "(^cpoint|\s+cpoint):((?!cpoint).)*_end:", input, "Catch-Point ending is missing", 2, False, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        CheckError(Errors, "_end:((?!bdy:|itr:|wpoint:|bpoint:|opoint:|cpoint:).)*_end:", input, "Point ending of Point ending", 2, False, RegexOptions.IgnoreCase Or RegexOptions.Singleline)

        Dim lines As String() = Regex.Split(input, "\r\n|\r|\n")
        Dim lineOffest As Long = 0
        For Each line As String In lines
            If line.StartsWith("<frame") Then
                If line.StartsWith("<frame_end>") Then
                    Dim newError As New ErrorItem
                    newError.Message = "Frame is not starting"
                    newError.Offset = lineOffest
                    Errors.Add(newError)
                End If
                Exit For
            End If
            lineOffest += line.Length + 1
        Next


        lineOffest = input.Length
        For i As Integer = lines.Count - 1 To 0 Step -1
            Dim linetxt As String = lines(i)

            If linetxt.StartsWith("<frame") Then
                If linetxt.StartsWith("<frame>") Then
                    Dim newError As New ErrorItem
                    newError.Message = "Frame is not ending"
                    newError.Offset = lineOffest
                    Errors.Add(newError)
                End If
                Exit For
            End If
            lineOffest -= linetxt.Length - 1
        Next



        Dim usedFrameIDs As New Dictionary(Of Integer, Boolean)
        Dim matches As MatchCollection = Regex.Matches(input, "(?<=^(?!#)\s*<frame>\s*)[0-9]+", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        For Each mtch As Match In matches
            If mtch.Success Then
                If IsNumeric(mtch.Value) Then
                    Dim ID As Integer = Convert.ToInt64(mtch.Value)
                    If Not usedFrameIDs.ContainsKey(ID) Then
                        usedFrameIDs.Add(ID, True)
                    Else
                        Dim newError As New ErrorItem
                        newError.Message = "ID (" & ID & ") exists already"
                        newError.Offset = mtch.Index
                        Errors.Add(newError)
                    End If
                End If
            End If
        Next

        CType(sender, BackgroundWorker).ReportProgress(0)

        'Console.WriteLine("Error founds in " & (Date.Now - startDate).TotalMilliseconds & " milsecs")
    End Sub

    Private Sub bw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        Dim editor As TextEditor = m_editor.GetAvalonEditor
        For Each errorI As ErrorItem In Errors
            Dim line As IDocumentLine = editor.Document.GetLineByOffset(errorI.Offset)
            errorI.Line = line.LineNumber
        Next
        globalUser.ErrorList.SetList(m_editor, Errors)
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        CType(sender, BackgroundWorker).Dispose()
    End Sub
End Class
