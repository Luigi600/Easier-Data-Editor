'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Xml

''' <summary>Represents a syntax item with a regex pattern.</summary>
Public Class SyntaxItemRegex
    Inherits SyntaxItem

    Public ReadOnly Name As String = ""
    Public ReadOnly Pattern As String = ""

    Public Sub New(ByVal attrs As XmlAttributeCollection)
        MyBase.New(attrs)

        GetAttributeValueAndSet(attrs, "name", Name)
        GetAttributeValueAndSet(attrs, "pattern", Pattern)
    End Sub

    Public Sub New(ByVal attrs As XmlAttributeCollection, ByVal pattern As String)
        Me.New(attrs)
        Me.Pattern = pattern
    End Sub
End Class