'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.ComponentModel
Imports System.Reflection

Namespace Translation
    ''' <summary>Contains public functions for the projects.</summary>
    Friend Module GlobalStuff
        Private m_selectedLang As Integer = 0
        Public ReadOnly Languages As New HashSet(Of Language) From {New Language("English (Default)", "Luigi600")}
        Public ReadOnly TranslatableForms As New HashSet(Of ITranslatable)
        Friend ReadOnly NotTranslatableTypes As New List(Of Type) From {GetType(MenuStrip), GetType(ScintillaNET.Scintilla), GetType(CustomScintilla),
                        GetType(NumericUpDown), GetType(UpDownBase), GetType(Panel), GetType(TableLayoutPanel), GetType(PictureBox), GetType(SplitContainer),
                        GetType(ToolStripControlHost)}

        Public Property SelectedLanguage As Integer
            Get
                Return m_selectedLang
            End Get
            Set(value As Integer)
                If value < Languages.Count Then
                    m_selectedLang = value

                    For Each translatable As ITranslatable In TranslatableForms
                        translatable.Translate(Languages(m_selectedLang))
                    Next
                End If
            End Set
        End Property

        Friend Sub AddToDefaultLanguage(ByVal control As Control)
            If Languages.Count > 0 AndAlso Not Languages(0).Dictionary.ContainsKey(control.Name) Then
                Dim items As New List(Of TextItem)
                For Each itm As Item In GetALLTranslatableItems(control)
                    items.Add(itm.ToTextItem())
                Next

                If items.Count > 0 Then Languages(0).Dictionary.Add(control.Name, items)

                If Not Languages(0).DictionaryOfVariables.ContainsKey(control.Name) AndAlso TypeOf control Is ITranslatable Then
                    Languages(0).DictionaryOfVariables.Add(control.Name, CType(control, ITranslatable).Variables.ToDictionary(Function(entry) entry.Key, Function(entry) entry.Value))
                End If
            End If
        End Sub

        Friend Sub Translate(ByVal lang As Language, ByVal parentControl As Control)
            Translate(lang, parentControl.Name, parentControl)
        End Sub

        Friend Sub Translate(ByVal lang As Language, ByVal formName As String, ByVal parentControl As Control)
            If lang.Dictionary.ContainsKey(formName) Then
                Dim items As List(Of Item) = GetALLTranslatableItems(parentControl)

                For Each item As TextItem In lang.Dictionary(formName)
                    For Each con As Item In items
                        If con.Equals(item) Then
                            If TypeOf con.Object Is ComboBox AndAlso TypeOf item.Value Is IList Then
                                Dim combobox As ComboBox = con.Object
                                Dim list As IList = item.Value
                                For i As Integer = 0 To Math.Min(combobox.Items.Count, list.Count) - 1
                                    combobox.Items(i) = list(i)
                                Next
                            Else
                                Dim infoText As PropertyInfo = con.Object.GetType().GetProperty("Text")
                                If Not IsNothing(infoText) Then
                                    infoText.SetValue(con.Object, item.Value)
                                End If

                                If TypeOf con.Object Is ToolStripItem Then
                                    If Not String.IsNullOrEmpty(item.Meta) Then
                                        CType(con.Object, ToolStripItem).ToolTipText = item.Meta
                                    End If
                                End If

                            End If
                        End If
                    Next
                Next
            End If

            If TypeOf parentControl Is ITranslatable Then
                Dim translateI As ITranslatable = parentControl
                If lang.DictionaryOfVariables.ContainsKey(formName) Then
                    For Each entry As KeyValuePair(Of String, String) In lang.DictionaryOfVariables(formName)
                        If translateI.Variables.ContainsKey(entry.Key) Then
                            translateI.Variables(entry.Key) = entry.Value
                        End If
                    Next
                End If
            End If
        End Sub

        Friend Function GetALLTranslatableItems(ByVal rootControl As Component, Optional ByVal addRootControlToResult As Boolean = True) As List(Of Item)
            Dim result As New List(Of Item)

            Dim controls As New List(Of Component) From {rootControl}
            Do While controls.Count > 0
                Dim control As Component = controls(0)

                If TypeOf control Is ToolStrip Then
                    For Each childChild As Component In CType(control, ToolStrip).Items
                        controls.Add(childChild)
                    Next
                ElseIf TypeOf control Is ToolStripMenuItem Then
                    For Each childChild As Component In CType(control, ToolStripMenuItem).DropDownItems
                        controls.Add(childChild)
                    Next
                ElseIf TypeOf control Is ListView Then
                    For Each col As ColumnHeader In CType(control, ListView).Columns
                        controls.Add(col)
                    Next
                ElseIf TypeOf control Is TabControl Then
                    For Each page As TabPage In CType(control, TabControl).TabPages
                        controls.Add(page)
                    Next
                ElseIf TypeOf control Is Control And Not TypeOf control Is WeifenLuo.WinFormsUI.Docking.DockPanel And Not TypeOf control Is NumericUpDown Then
                    For Each childChild As Control In CType(control, Control).Controls
                        controls.Add(childChild)
                    Next
                End If

                Dim fields As FieldInfo() = control.GetType().GetFields(BindingFlags.NonPublic Or BindingFlags.Instance)
                For Each contextMenu As ContextMenuStrip In fields.Select(Function(x) x.GetValue(control)).OfType(Of ContextMenuStrip)
                    For Each childChild As Component In contextMenu.Items
                        controls.Add(childChild)
                    Next
                Next

                If Not NotTranslatableTypes.Contains(control.GetType()) Then
                    If addRootControlToResult Or Not addRootControlToResult And Not rootControl.Equals(control) Then
                        Try
                            result.Add(New Item(control))
                        Catch ex As InvalidCastException
                        End Try
                    End If
                End If

                controls.RemoveAt(0)
            Loop

            If TypeOf rootControl Is Control Then
                For Each itm As Item In result.Where(Function(x) TypeOf x.Object Is TreeView).ToList
                    result.AddRange(GetALLNodes(itm.Object))
                Next
            End If

            If TypeOf rootControl Is ITranslatable Then
                For Each notTranslatable As Component In CType(rootControl, ITranslatable).NotTranslatableControls
                    For Each itm As Item In result
                        If itm.Object.Equals(notTranslatable) Then
                            result.Remove(itm)
                            Exit For
                        End If
                    Next
                Next
            End If
            Return result
        End Function

        Private Function GetALLNodes(ByVal treeView As TreeView) As List(Of Item)
            Dim result As New List(Of Item)

            Dim nodes As New List(Of TreeNode)
            For Each node As TreeNode In treeView.Nodes
                nodes.Add(node)
            Next

            Do While nodes.Count > 0
                Dim node As TreeNode = nodes(0)

                For Each subNode As TreeNode In node.Nodes
                    nodes.Add(subNode)
                Next

                Try
                    result.Add(New Item(node))
                Catch ex As InvalidCastException
                End Try
                nodes.RemoveAt(0)
            Loop

            Return result
        End Function
    End Module
End Namespace