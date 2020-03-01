'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Xml

Namespace Translation
    ''' <summary>Represents a tool to create a language file of the whole project.</summary>
    Public Class Creator
        Private ReadOnly LanguageName As String = ""
        Private ReadOnly Translator As String = ""

        Private Variables As New Dictionary(Of String, List(Of Item))
        Private Controls As New Dictionary(Of ContainerControl, List(Of Item))
        Private Nodes As New Dictionary(Of ContainerControl, List(Of TreeNode))

        Public Sub New(ByVal langName As String, ByVal translator As String)
            If Not String.IsNullOrEmpty(langName) Then LanguageName = langName
            If Not String.IsNullOrEmpty(translator) Then Me.Translator = translator
        End Sub

        Public Sub GetXMLFromWindow(ByVal form As Form)
            GetControlsAndSet(form)
        End Sub

        Public Sub GetXMLFromUserControl(ByVal uc As UserControl)
            GetControlsAndSet(uc)
        End Sub

        Private Sub GetControlsAndSet(ByVal parent As ContainerControl)
            If Not Controls.ContainsKey(parent) Then Controls.Remove(parent)
            Dim items As List(Of Item) = GetALLTranslatableItems(parent, False)
            If items.Count > 0 Then
                Controls.Add(parent, New List(Of Item))

                For Each itm As Item In items
                    If Not String.IsNullOrEmpty(itm.Text) Then
                        Controls(parent).Add(itm)
                        If Variables.ContainsKey(itm.Text) Then
                            Variables(itm.Text).Add(itm)
                        Else
                            Variables.Add(itm.Text, New List(Of Item) From {itm})
                        End If
                    End If
                Next
            End If
        End Sub

        Public Sub Close(ByVal filePath As String)
            Dim variables As List(Of KeyValuePair(Of String, List(Of Item))) = Me.Variables.ToList.Where(Function(x) x.Value.Count > 1).ToList
            variables.Sort(Function(x, y)
                               Return y.Value.Count.CompareTo(x.Value.Count)
                           End Function)

            ' variables = variables.Where(Function(x) x.Value.Count > 0)
            Using output As New IO.StreamWriter(New IO.FileStream(filePath, IO.FileMode.Create))
                Dim writer As XmlWriter = XmlWriter.Create(output, New XmlWriterSettings() With {.Indent = True, .OmitXmlDeclaration = False})
                With writer
                    .WriteStartDocument()
                    .WriteStartElement("Language")
                    .WriteAttributeString("displayName", LanguageName)
                    .WriteAttributeString("translator", Translator)

                    Dim varCounter As Integer = 0
                    For Each variable As KeyValuePair(Of String, List(Of Item)) In variables
                        .WriteStartElement("Variable")
                        .WriteAttributeString("name", "VAR" & varCounter)
                        .WriteString(variable.Key)
                        .WriteEndElement()
                        varCounter += 1
                    Next

                    For Each entry As KeyValuePair(Of ContainerControl, List(Of Item)) In Controls
                        .WriteStartElement(entry.Key.Name)
                        If TypeOf entry.Key Is ITranslatable Then
                            .WriteAttributeString("header", CType(entry.Key, ITranslatable).GetTranslatableHeader())

                            For Each var As KeyValuePair(Of String, String) In CType(entry.Key, ITranslatable).Variables
                                .WriteStartElement("Variable")
                                .WriteAttributeString("name", var.Key)
                                .WriteString(var.Value)
                                .WriteEndElement()
                            Next
                        Else
                            .WriteAttributeString("header", entry.Key.Text)
                        End If


                        For Each itm As Item In entry.Value
                            .WriteStartElement(itm.Object.GetType().Name)
                            .WriteAttributeString("name", itm.Name)

                            If Not String.IsNullOrEmpty(itm.Meta) Then
                                .WriteAttributeString("meta", itm.Meta)
                            End If

                            If TypeOf itm.Object Is ComboBox Then
                                For Each childChild As Object In CType(itm.Object, ComboBox).Items
                                    .WriteElementString("Value", childChild.ToString)
                                Next
                            Else
                                Dim varIndex As Integer = -1
                                For i As Integer = 0 To variables.Count - 1
                                    If variables(i).Key.Equals(itm.Text) Then
                                        varIndex = i
                                        Exit For
                                    End If
                                Next

                                If varIndex >= 0 Then
                                    .WriteString("{VAR" & varIndex & "}")
                                Else
                                    .WriteString(itm.Text)
                                End If
                            End If
                            .WriteEndElement()
                        Next

                        If Nodes.ContainsKey(entry.Key) Then
                            For Each node As TreeNode In Nodes(entry.Key)
                                .WriteElementString(node.GetType().Name, node.Text)
                            Next
                        End If

                        .WriteEndElement()
                    Next


                    .WriteEndElement()
                    .WriteEndDocument()
                    .Close()
                End With
            End Using
        End Sub
    End Class
End Namespace