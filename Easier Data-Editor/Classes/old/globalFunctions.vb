'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Functions which are repeating except getContentFromPersistString </summary>
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports WeifenLuo.WinFormsUI.Docking

''' <summary>Contains a few public static functions.</summary>
''' <todo>Remove this "Module". Clear IDsToPath list. Clean up.</todo>
Friend Module Functions
    Private m_IDsToPath As New Dictionary(Of Integer, IUserItem)
    Public Function GetContentFromPersistString(ByVal persistString As String) As IDockContent
        Dim splitter() As String = Split(persistString, ";")
        Dim result As DockContent = Nothing
        If splitter.Count = 5 Then
            If splitter(0).Equals("TE") Then
                If IsNumeric(splitter(2)) Then
                    Dim id As Integer = Convert.ToInt64(splitter(2))
                    If Not m_IDsToPath.ContainsKey(id) Then
                        result = New TextEditor(id, splitter(1), CInt(splitter(3)), splitter(4))
                        m_IDsToPath.Add(id, result)
                    ElseIf TypeOf m_IDsToPath(id) Is FrameViewer Then
                        result = New TextEditor(CType(m_IDsToPath(id), FrameViewer), splitter(1), CInt(splitter(3)), splitter(4))
                        m_IDsToPath.Remove(id)
                    End If
                End If
            End If
        ElseIf splitter.Count = 2 Then
            If splitter(0).Equals("FV") Then
                If IsNumeric(splitter(1)) Then
                    Dim id As Integer = Convert.ToInt64(splitter(1))
                    If m_IDsToPath.ContainsKey(id) AndAlso TypeOf m_IDsToPath(id) Is TextEditor Then
                        result = New FrameViewer(CType(m_IDsToPath(id), TextEditor))
                        m_IDsToPath.Remove(id)
                    Else
                        result = New FrameViewer(id)
                        If Not m_IDsToPath.ContainsKey(id) Then
                            m_IDsToPath.Add(id, result)
                        End If
                    End If
                End If
            End If
        Else
            If persistString.Equals(GetType(ErrorList).ToString) Then
                result = App.ErrorList
            ElseIf persistString.Equals(GetType(UnusedIDs).ToString) Then
                result = App.UnusedIDs
            End If
        End If

        If IsNothing(result) Then result = New DockContent
        Return result
    End Function

    'input: 'C:\LF2\data\dat.dat' & 'sprite/sys/bandit.bmp'
    Public Function GetFolder(ByVal myPath As String, ByVal path As String) As String
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

    Public Function GetRegexValue(ByVal text As String, ByVal pattern As String, Optional ByVal RegOptions As RegexOptions = RegexOptions.IgnoreCase, Optional ByVal optionalerReturn As Object = Nothing) As String
        If Not IsNothing(text) Then
            Dim match As Match = Regex.Match(text, pattern, RegOptions)
            If match.Success Then
                Return match.Value
            End If
        End If
        Return optionalerReturn
    End Function

    Public Function GetRegexValueInteger(ByVal text As String, ByVal pattern As String, Optional ByVal RegOptions As RegexOptions = RegexOptions.IgnoreCase, Optional ByVal optionalerReturn As Integer = -1) As Integer
        Dim result As String = GetRegexValue(text, pattern, RegexOptions.IgnoreCase)
        If Not IsNothing(result) Then
            result = result.Trim
            If IsNumeric(result) Then
                Return Convert.ToInt32(result)
            End If
        End If
        Return optionalerReturn
    End Function

    Public Function IsNumeric(ByVal str As String) As Boolean
        Dim int As Integer = 0
        Return Integer.TryParse(str, int)
    End Function

    'copy and paste from a c# file; author unknown
    Public Sub PlainTextToDatFile(ByVal text As String, ByVal filepath As String, Optional ByVal password As String = "SiuHungIsAGoodBearBecauseHeIsVeryGood", Optional ByVal First123 As String = "")
        Using ms As New IO.MemoryStream
            For i As Integer = 0 To 123 - 1
                ms.WriteByte(0)
            Next
            ms.Seek(0, IO.SeekOrigin.Begin)
            For i As Integer = 0 To Math.Min(First123.Length, 123) - 1
                ms.WriteByte(Convert.ToByte(First123(i)))
            Next

            ms.Seek(123, IO.SeekOrigin.Begin)

            Dim index As Integer = 12
            For Each byt As Byte In Encoding.ASCII.GetBytes(text)
                Dim newByte As Integer = Convert.ToInt16(byt) + Convert.ToInt16(password(index))
                Do While newByte > 255
                    newByte -= 255
                Loop
                Dim b1 As Byte = Convert.ToByte(newByte)

                ms.WriteByte(b1)

                index += 1
                If index = password.Length Then
                    index = 0
                End If
            Next

            ms.Flush()

            Using fs As New IO.FileStream(filepath, IO.FileMode.Create, IO.FileAccess.Write)
                ms.WriteTo(fs)
                fs.Close()
            End Using

            ms.Close()
        End Using
    End Sub

    Public Function DecryptFromData(ByVal filepath As String, Optional ByVal readLength As Long = -1, Optional ByVal seek As Long = 0, Optional ByVal password As [String] = "SiuHungIsAGoodBearBecauseHeIsVeryGood") As [String]
        Dim resultStr As String = ""
        Using fsm As New IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            If seek < 123 Then seek = (123 - seek)
            If seek > fsm.Length Then seek = 0
            fsm.Seek(seek, IO.SeekOrigin.Begin)
            If readLength > fsm.Length Or readLength <= 0 Then readLength = fsm.Length - fsm.Position

            Dim bufferBytes() As Byte = New Byte(readLength - 1) {}
            Dim result As New StringBuilder(CInt(readLength - 1))
            fsm.Read(bufferBytes, 0, bufferBytes.Count)

            Dim index As Integer = 12
            For i As Integer = 0 To bufferBytes.Count - 1
                Try
                    If index = password.Length Then index = 0
                    Dim newB As Integer = CInt(bufferBytes(i)) - AscW(password(index))
                    Do While newB < 0
                        newB += 255
                    Loop
                    result.Append(Encoding.ASCII.GetString(New Byte() {newB}))
                Catch ex As Exception
                    Console.WriteLine("DECRYPTING ERROR: " & ex.ToString)
                End Try
                index += 1
            Next

            bufferBytes = Nothing
            resultStr = result.ToString
            fsm.Close()
            fsm.Dispose()
        End Using
        Return resultStr
    End Function

    Public Function GetEXE(ByVal file As String) As List(Of String)
        Dim result As New List(Of String)
        Try
            Dim lastFolder As String = ""
            Dim folder As String = IO.Path.GetDirectoryName(file)
            Do While Not lastFolder.Equals(folder)
                For Each exeFile As String In IO.Directory.GetFiles(folder, "*.exe")
                    Dim fileName As String = IO.Path.GetFileNameWithoutExtension(exeFile).ToLower
                    If Not (fileName.Contains("unin") Or fileName.Contains("editor") Or fileName.Contains("install") Or fileName.Contains("changer")) Then
                        result.Add(exeFile)
                    End If
                Next
                lastFolder = folder
                folder = IO.Path.GetDirectoryName(folder)
                If IsNothing(folder) Then Exit Do
            Loop
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Return result
    End Function

    Public Function GetColor(ByVal colStr As String) As Color
        Try
            If colStr.StartsWith("#") Then
                Return ColorTranslator.FromHtml(colStr)
            Else
                Return Color.FromName(colStr)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

        Return Color.Black
    End Function


    Public Sub DontCloseEvent(ByVal sender As Object, ByVal e As ToolStripDropDownClosingEventArgs)
        If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then
            e.Cancel = True
        End If
    End Sub

#Region "XML Stuff"
    Public Function GetAttributeValue(ByVal xmlAttributes As XmlAttributeCollection, ByVal attrName As String) As String
        If Not IsNothing(xmlAttributes) Then
            Dim attr As XmlAttribute = xmlAttributes(attrName)
            If Not IsNothing(attr) Then
                Return attr.Value
            End If
        End If

        Return Nothing
    End Function

    Public Sub GetAttributeValueAndSet(ByVal xmlAttributes As XmlAttributeCollection, ByVal attrName As String, ByRef val As String)
        If Not IsNothing(xmlAttributes) Then
            Dim attr As XmlAttribute = xmlAttributes(attrName)
            If Not IsNothing(attr) Then
                val = attr.Value
            End If
        End If
    End Sub

    Public Sub GetAttributeValueAndSet(ByVal xmlAttributes As XmlAttributeCollection, ByVal attrName As String, ByRef val As Color)
        Dim xmlStr As String = Nothing
        GetAttributeValueAndSet(xmlAttributes, attrName, xmlStr)
        If Not IsNothing(xmlStr) Then
            val = GetColor(xmlStr)
        End If
    End Sub
#End Region



    '<Runtime.CompilerServices.Extension()>
    'Public Sub AddRange(Of TKey, TValue)(ByVal dic As SortedDictionary(Of TKey, TValue), ByVal dicToAdd As SortedDictionary(Of TKey, TValue))
    '    For Each entry As KeyValuePair(Of TKey, TValue) In dicToAdd
    '        If Not dic.ContainsKey(entry.Key) Then
    '            dic.Add(entry.Key, entry.Value)
    '        End If
    '    Next
    'End Sub

    '<Runtime.CompilerServices.Extension()>
    'Public Sub AddRange(Of TKey, TValue)(ByVal dic As SortedDictionary(Of TKey, TValue), ByVal dicToAdd As Dictionary(Of TKey, TValue))
    '    For Each entry As KeyValuePair(Of TKey, TValue) In dicToAdd
    '        If Not dic.ContainsKey(entry.Key) Then
    '            dic.Add(entry.Key, entry.Value)
    '        End If
    '    Next
    'End Sub
End Module