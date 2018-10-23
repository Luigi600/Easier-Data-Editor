Imports System.Text.RegularExpressions
Imports WeifenLuo.WinFormsUI.Docking

'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Functions which are repeating except getContentFromPersistString </summary>

Module globalFunctions
    Private m_integerToEditor As New Dictionary(Of Integer, ITextEditor)

    Public Function getContentFromPersistString(ByVal persistString As String) As IDockContent
        persistString = persistString.Replace("Easier_LF_Editor___Data_Editor", "Easier_Data_Editor") 'old version name space >.>
        Dim splitter() As String = Split(persistString, ";")
        Dim result As New DockContent
        If splitter.Count = 3 Then
            If splitter(0).Equals(GetType(ui_textEditor).ToString) Then
                If IsNumeric(splitter(2)) Then
                    Dim int As Integer = Convert.ToInt64(splitter(2))
                    result = New ui_textEditor(splitter(1), False, int)
                    If Not m_integerToEditor.ContainsKey(int) Then
                        m_integerToEditor.Add(int, result)
                    End If
                End If
            End If
        ElseIf splitter.Count = 2 Then
            If splitter(0).Equals(GetType(ui_frameViewer).ToString) Then
                If IsNumeric(splitter(1)) Then
                    Dim int As Integer = Convert.ToInt64(splitter(1))
                    If m_integerToEditor.ContainsKey(int) Then
                        result = New ui_frameViewer(m_integerToEditor(int).Path, m_integerToEditor(int), int)
                        m_integerToEditor(int).Viewer = result
                    Else
                        result = New ui_frameViewer() With {.ID = int}
                    End If
                Else
                    result = New ui_frameViewer()
                End If
            End If
        Else
            If persistString.Equals(GetType(ui_error_list).ToString) Then
                result = ErrorList
            ElseIf persistString.Equals(GetType(ui_unused_frames).ToString) Then
                result = UnusedFrames
            End If
        End If

        Return result
    End Function

    'input: 'C:\LF2\data\dat.dat' & 'sprite/sys/bandit.bmp'
    Public Function getFolder(ByVal myPath As String, ByVal path As String) As String
        Dim result As String = Nothing
        If String.IsNullOrEmpty(myPath) Then Return Nothing

        Dim check As String = IO.Path.GetDirectoryName(myPath)
        Do While Not IO.File.Exists(IO.Path.Combine(check, path))
            Dim oldPath As String = check
            check = IO.Path.GetDirectoryName(check)
            If oldPath.Equals(check) Or IsNothing(check) Then
                Exit Do
            End If
        Loop
        If Not IsNothing(check) Then
            If IO.File.Exists(IO.Path.Combine(check, path)) Then
                Return IO.Path.Combine(check, path)
            End If
        End If
        Return result
    End Function

    Public Sub SetFrameIfSuccess(ByRef setValue As Integer, ByVal input As String, ByVal pattern As String, Optional ByVal regexOptions As RegexOptions = RegexOptions.IgnoreCase)
        Dim mtch As Match = Regex.Match(input, pattern, regexOptions)
        If mtch.Success Then
            If IsNumeric(mtch.Value.Trim) Then
                setValue = Convert.ToInt64(mtch.Value.Trim)
            End If
        End If
    End Sub

    Public Function getRegexValue(ByVal text As String, ByVal pattern As String, Optional ByVal RegOptions As RegexOptions = RegexOptions.IgnoreCase, Optional ByVal optionalerReturn As Object = Nothing) As String
        If Not IsNothing(text) Then
            Dim match As Match = Regex.Match(text, pattern, RegOptions)
            If match.Success Then
                Return match.Value
            End If
        End If
        Return optionalerReturn
    End Function

    Public Function getRegexValueInteger(ByVal text As String, ByVal pattern As String, Optional ByVal RegOptions As RegexOptions = RegexOptions.IgnoreCase, Optional ByVal optionalerReturn As Integer = -1) As Integer
        Dim result As String = getRegexValue(text, pattern, RegexOptions.IgnoreCase)
        If Not IsNothing(result) Then
            result = result.Trim
            If IsNumeric(result) Then
                Return Convert.ToInt64(result)
            End If
        End If
        Return optionalerReturn
    End Function

    'copy and paste from a c# file; author unknown
    Public Sub PlainTextToDatFile(ByVal text As String, ByVal filepath As String, Optional ByVal password As String = "SiuHungIsAGoodBearBecauseHeIsVeryGood", Optional ByVal First123 As String = "")
        Dim dat As Byte() = New Byte(123 + (text.Length - 1)) {}
        For i As Integer = 0 To 123 - 1
            dat(i) = 0
        Next
        For i As Integer = 0 To First123.Length - 1
            If i > 123 Then
                Exit For
            End If
            dat(i) = CByte(AscW(First123(i)))
        Next
        Dim index As Integer = 12
        For i As Integer = 0 To text.Length - 1
            Dim b1 As Byte = CByte(CByte(AscW(text(i))) + CByte(AscW(password(index))))
            dat(i + 123) = b1
            index += 1
            If index = password.Length Then
                index = 0
            End If
        Next
        Dim fs As New IO.FileStream(filepath, IO.FileMode.Create, IO.FileAccess.Write)
        fs.Write(dat, 0, 123 + text.Length)
        fs.Close()
    End Sub

    'copy and paste from a c# file; author unknown
    Public Function DatFileToPlainText(ByVal filepath As [String], Optional ByVal read_length As Int64 = -1, Optional ByVal password As [String] = "SiuHungIsAGoodBearBecauseHeIsVeryGood") As [String]
        Dim fileStream As New IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
        If read_length < 0 Then read_length = fileStream.Length - 1
        Dim buffer As Byte() = New Byte(read_length) {}
        fileStream.Read(buffer, 0, buffer.Length)
        Dim decryptedtext As New Text.StringBuilder(CInt(fileStream.Length))
        fileStream.Close()
        Dim index As Integer = 12
        Try
            For i As Integer = 123 To buffer.Length - 1
                Dim b1 As Byte = CByte(buffer(i) - CByte(AscW(password(index))))
                decryptedtext.Append(ChrW(b1))

                index += 1
                If index = password.Length Then
                    index = 0
                End If
            Next
        Catch ex As Exception
        End Try

        Return decryptedtext.ToString()
    End Function


    Public Function getEXE(ByVal file As String) As String
        Try
            Dim lastFolder As String = ""
            Dim folder As String = IO.Path.GetDirectoryName(file)
            Do While folder.Length > 0 And Not lastFolder.Equals(folder)
                For Each exeFile As String In IO.Directory.GetFiles(folder, "*.exe")
                    Return exeFile
                Next
                lastFolder = folder
                folder = IO.Path.GetDirectoryName(folder)
            Loop
        Catch ex As Exception
        End Try
        Return Nothing
    End Function


    <Runtime.CompilerServices.Extension()>
    Public Sub AddRange(Of TKey, TValue)(ByVal dic As SortedDictionary(Of TKey, TValue), ByVal dicToAdd As SortedDictionary(Of TKey, TValue))
        For Each entry As KeyValuePair(Of TKey, TValue) In dicToAdd
            If Not dic.ContainsKey(entry.Key) Then
                dic.Add(entry.Key, entry.Value)
            End If
        Next
    End Sub

    <Runtime.CompilerServices.Extension()>
    Public Sub AddRange(Of TKey, TValue)(ByVal dic As SortedDictionary(Of TKey, TValue), ByVal dicToAdd As Dictionary(Of TKey, TValue))
        For Each entry As KeyValuePair(Of TKey, TValue) In dicToAdd
            If Not dic.ContainsKey(entry.Key) Then
                dic.Add(entry.Key, entry.Value)
            End If
        Next
    End Sub
End Module
