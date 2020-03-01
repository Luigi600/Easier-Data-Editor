'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Xml

''' <summary>Represents a syntax highlighting item.</summary>
Public MustInherit Class SyntaxItem
    Public ReadOnly ForeColor As Color = Color.Black
    Public ReadOnly BackColor As Color = Color.Transparent

    Public ReadOnly IsBold As Boolean = False
    Public ReadOnly IsItalic As Boolean = False

    Private m_styleIndex As Byte = 0
    Public Property StyleIndex As Byte
        Get
            Return m_styleIndex
        End Get
        Set(value As Byte)
            Do While [Enum].IsDefined(GetType(StylesIndices), value)
                value += 1
            Loop
            m_styleIndex = value
        End Set
    End Property

    Public Sub New(ByVal attrs As XmlAttributeCollection)
        GetAttributeValueAndSet(attrs, "forecol", ForeColor)
        GetAttributeValueAndSet(attrs, "backcol", BackColor)

        GetAttributeValueAndSet(attrs, "bold", IsBold)
        GetAttributeValueAndSet(attrs, "italic", IsItalic)
    End Sub
End Class