'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents a range of successful found syntax highlighting.</summary>
Public Class RangeSyntax
    Public ReadOnly Range As Point
    Public ReadOnly Style As Integer = StylesIndices.Default

    Public Sub New(ByVal start As Integer, ByVal len As Integer, Optional ByVal style As Integer = StylesIndices.Default)
        Range = New Point(start, start + len)
        Me.Style = style
    End Sub
End Class