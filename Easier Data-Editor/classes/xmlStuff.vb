Imports System.Xml

'------------------------------------------''---------Created by Lui's Studio----------''-------(http://www.lui-studio.net/)-------''------------------------------------------''-------------Author: Luigi600-------------''------------------------------------------'
'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Module (static class) to load and save settings </summary>

Module xmlStuff
    Public Sub loadFromXMLFile(ByVal file As String)
        If IO.File.Exists(file) Then
            Dim doc As New XmlDocument()
            doc.Load(file)

            If doc.DocumentElement.Name.ToLower.Equals("settings") Then
                For Each node As XmlNode In doc.DocumentElement.ChildNodes
                    Try
                        If node.InnerText.Trim.Length > 0 Then
                            With node.Name.ToLower
                                If .Equals("recentmax") Then
                                    opt_recentMax = CInt(node.InnerText)
                                ElseIf .Equals("savesession") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_saveSession = CBool(node.InnerText)
                                    End If
                                ElseIf .Equals("windowstate") Then
                                    windowState = CInt(node.InnerText)
                                    If Not windowState = 0 And Not windowState = 2 Then
                                        windowState = 0
                                    End If
                                ElseIf .Equals("windowsize") Then
                                    Dim size() As String = Split(node.InnerText, "x")
                                    If size.Count = 2 Then
                                        windowSize = New Size(CInt(size(0)), CInt(size(1)))
                                    End If
                                ElseIf .Equals("doubleopening") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_doubleOpening = CBool(node.InnerText)
                                    End If
                                ElseIf .Equals("fontfamily") Then
                                    opt_userFontFamily = New Windows.Media.FontFamily(node.InnerText)
                                ElseIf .Equals("fontsize") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_userFontSize = Convert.ToDouble(node.InnerText, cultureEN)
                                    End If
                                ElseIf .Equals("autocomplete") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_autocomplete = CBool(node.InnerText)
                                    End If
                                ElseIf .Equals("folding") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_folding = CBool(node.InnerText)
                                    End If
                                ElseIf .Equals("fvmenustrip") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_showMS = CBool(node.InnerText)
                                    End If
                                ElseIf .Equals("defaultbgcolor") Then
                                    opt_defaultBackgroundColor = ColorTranslator.FromHtml(node.InnerText)
                                ElseIf .Equals("directresult") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_directResult = CBool(node.InnerText)
                                    End If
                                ElseIf .Equals("globalsettings") Then
                                    If IsNumeric(node.InnerText) Then
                                        isGlobalSettingsEnable = CBool(node.InnerText)
                                    End If
                                ElseIf .Equals("autoopen") Then
                                    If IsNumeric(node.InnerText) Then
                                        opt_autoOpenViewer = CBool(node.InnerText)
                                    End If
                                End If
                            End With
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If

        loadRecentFiles()
    End Sub

    Public Sub loadRecentFiles()
        If IO.File.Exists(recentFile) Then
            recentFiles.Clear()
            Dim changeReallyWasChanged As Boolean = False 'addRecentFile overrides "recentFileWasChanged"
            For Each line As String In IO.File.ReadLines(recentFile)
                line = line.Trim
                If line.Length > 3 Then
                    If IO.File.Exists(line) Then
                        addRecentFile(line)
                    Else
                        changeReallyWasChanged = True
                    End If
                End If


                If recentFiles.Count = opt_recentMax Then
                    Exit For
                End If
            Next

            recentFileWasChanged = changeReallyWasChanged
        End If
    End Sub

    Public Sub addRecentFile(ByVal file As String)
        Dim found As Integer = -1
        For i As Integer = 0 To recentFiles.Count - 1
            If recentFiles(i).Equals(file) Then
                found = i
                Exit For
            End If
        Next

        If found >= 0 Then
            recentFiles.RemoveAt(found)
        End If

        recentFiles.Insert(0, file)


        Do While recentFiles.Count > opt_recentMax
            recentFiles.RemoveAt(recentFiles.Count - 1)
        Loop

        recentFileWasChanged = True
    End Sub

    Public Sub saveRecentFiles()
        Do While recentFiles.Count > opt_recentMax
            recentFiles.RemoveAt(recentFiles.Count - 1)
        Loop

        IO.File.WriteAllLines(recentFile, recentFiles.ToArray)
    End Sub


    Public Sub saveSettings()
        Dim doc As New XmlDocument
        Dim doc_node As XmlWriter = doc.CreateNavigator().AppendChild()

        Using writer As XmlWriter = doc_node
            With writer
                .WriteStartDocument()
                .WriteStartElement("settings")

                .WriteElementString("recentMax", globalUser.opt_recentMax)
                .WriteElementString("saveSession", Convert.ToInt16(opt_saveSession).ToString)
                .WriteElementString("windowState", Convert.ToInt16(windowState)) '0 = normal; 2 = maxi
                .WriteElementString("windowSize", windowSize.Width & "x" & windowSize.Height)
                .WriteElementString("doubleOpening", Convert.ToInt16(globalUser.opt_doubleOpening))

                .WriteElementString("fontFamily", opt_userFontFamily.ToString)
                .WriteElementString("fontSize", opt_userFontSize.ToString(".#", cultureEN))
                .WriteElementString("autocomplete", Convert.ToInt16(opt_autocomplete).ToString)
                .WriteElementString("folding", Convert.ToInt16(opt_folding).ToString)

                .WriteElementString("fvMenuStrip", Convert.ToInt16(opt_showMS).ToString)
                .WriteElementString("defaultBgColor", ColorTranslator.ToHtml(opt_defaultBackgroundColor))
                .WriteElementString("directResult", Convert.ToInt16(opt_directResult).ToString)
                .WriteElementString("globalSettings", Convert.ToInt16(isGlobalSettingsEnable).ToString)
                .WriteElementString("autoOpen", Convert.ToInt16(opt_autoOpenViewer).ToString)

                .WriteEndElement()
                .WriteEndDocument()
                .Close()
            End With
        End Using
        doc.Save(IO.Path.Combine(appFolder, "settings.xml"))
    End Sub
End Module
