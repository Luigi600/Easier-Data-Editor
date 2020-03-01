'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text.RegularExpressions
Imports System.Xml

Namespace Translation
    ''' <summary>Represents a language with file, translator and list of translated controls and variables.</summary>
    Public Class Language
        Private m_fileName As String = ""
        Private m_name As String = ""
        Private m_translator As String = ""

        Public Property FileName As String
            Get
                Return m_fileName
            End Get
            Set(value As String)
                If Not String.IsNullOrEmpty(value) Then
                    m_fileName = value
                End If
            End Set
        End Property

        Public ReadOnly Property Name As String
            Get
                Return m_name
            End Get
        End Property

        Public ReadOnly Property Translator As String
            Get
                Return m_translator
            End Get
        End Property

        Public ReadOnly Dictionary As New Dictionary(Of String, List(Of TextItem)) 'key = form/usercontrol; values = controls
        Public ReadOnly DictionaryOfVariables As New Dictionary(Of String, Dictionary(Of String, String)) 'key = form/usercontrol; values = dic of string (var name) and string (var content)

        Public Sub New(ByVal name As String, ByVal translator As String)
            If Not IsNothing(name) Then m_name = name
            If Not IsNothing(translator) Then m_translator = translator
        End Sub

        Public Sub New(ByVal xmlFile As String)
            Me.FileName = IO.Path.GetFileName(xmlFile)
            Load()
        End Sub

        Public Sub Reload()
            Try
                Load()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub Load()
            Try
                Dim file As String = IO.Path.Combine(LanguageDirectory, m_fileName)
                If IO.File.Exists(file) Then
                    Dim doc As New XmlDocument()
                    Using fsm As New IO.FileStream(file, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                        doc.Load(fsm)

                        Dim variables As New Dictionary(Of String, String)
                        Dictionary.Clear()
                        DictionaryOfVariables.Clear()

                        If doc.DocumentElement.LocalName.Equals("Language") Then
                            If doc.DocumentElement.HasAttribute("displayName") Then m_name = doc.DocumentElement.GetAttribute("displayName")
                            If doc.DocumentElement.HasAttribute("translator") Then m_translator = doc.DocumentElement.GetAttribute("translator")

                            For Each node As XmlNode In doc.DocumentElement.ChildNodes
                                Try
                                    If node.LocalName.Equals("Variable") Then
                                        Dim name As String = GetAttributeValue(node.Attributes, "name")
                                        If Not String.IsNullOrEmpty(name) Then
                                            If Not variables.ContainsKey(name) Then
                                                variables.Add(name, node.InnerText)
                                            End If
                                        End If
                                    Else
                                        If Not Dictionary.ContainsKey(node.LocalName) Then
                                            If Not IsNothing(node.Attributes) Then
                                                Dim items As New List(Of TextItem)
                                                Dim vars As New Dictionary(Of String, String)
                                                items.Add(New TextItem(node.LocalName, GetAttributeValue(node.Attributes, "header"), node.LocalName)) 'form/usercontrol

                                                For Each subNode As XmlNode In node.ChildNodes
                                                    Dim val As Object = Nothing
                                                    If subNode.LocalName.Equals("Variable") Then
                                                        Dim name As String = GetAttributeValue(subNode.Attributes, "name")
                                                        If Not String.IsNullOrEmpty(name) AndAlso Not vars.ContainsKey(name) Then
                                                            vars.Add(name, subNode.InnerText)
                                                        End If
                                                    ElseIf subNode.LocalName.Equals("ComboBox") Then
                                                        Dim comboItems As New List(Of String)
                                                        For Each comboNode As XmlNode In subNode.ChildNodes
                                                            If comboNode.LocalName.Equals("Value") Then
                                                                comboItems.Add(comboNode.InnerText)
                                                            End If
                                                        Next
                                                        val = comboItems
                                                    Else
                                                        val = subNode.InnerText
                                                    End If

                                                    If Not IsNothing(val) Then
                                                        Dim name As String = GetAttributeValue(subNode.Attributes, "name")

                                                        If Not String.IsNullOrEmpty(name) Then
                                                            If TypeOf val Is String Then
                                                                Dim val_ As New Text.StringBuilder(CType(val, String))
                                                                Dim ranges As MatchCollection = Regex.Matches(val, "\{[^\{\}]+?\}")
                                                                For i As Integer = ranges.Count - 1 To 0 Step -1
                                                                    Dim mtch As Match = ranges(i)
                                                                    Dim varName As String = GetRegexValue(val, "(?<=\{)[^\{\}]+?(?=\})")
                                                                    If variables.ContainsKey(varName) Then
                                                                        val_.Remove(mtch.Index, mtch.Length)
                                                                        val_.Insert(mtch.Index, variables(varName))
                                                                    End If
                                                                Next

                                                                val = val_.ToString
                                                            End If


                                                            items.Add(New TextItem(name, val, subNode.LocalName, GetAttributeValue(subNode.Attributes, "meta")))
                                                        End If
                                                    End If
                                                Next

                                                Dictionary.Add(node.LocalName, items)
                                                If vars.Count > 0 Then DictionaryOfVariables.Add(node.LocalName, vars)
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                End Try
                            Next
                        Else
                            Throw New Exception("Unknown XML Format")
                        End If
                    End Using
                Else
                    Throw New IO.FileNotFoundException
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is Language Then
                Dim lang As Language = obj
                If Not lang.FileName.Equals(FileName) Then Return False
                If Not lang.Name.Equals(Name) Then Return False
                If Not lang.Translator.Equals(Translator) Then Return False

                Return True
            End If

            Return False
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return ToString().GetHashCode
        End Function

        Public Overrides Function ToString() As String
            Return Name & " (by: " & Translator & ")"
        End Function
    End Class
End Namespace