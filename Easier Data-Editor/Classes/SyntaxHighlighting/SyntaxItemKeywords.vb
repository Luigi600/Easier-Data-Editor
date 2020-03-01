'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Xml

''' <summary>Represents a list keywords which share the same syntax style.</summary>
Public Class SyntaxItemKeywords
    Inherits SyntaxItem

    Public ReadOnly Keywords As New HashSet(Of String)

    Public Sub New(ByVal attrs As XmlAttributeCollection)
        MyBase.New(attrs)
    End Sub
End Class