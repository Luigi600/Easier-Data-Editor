'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.ComponentModel

Namespace Translation
    ''' <summary>Represents a translatable control.</summary>
    Public Interface ITranslatable
        ReadOnly Property NotTranslatableControls As List(Of Component)
        ReadOnly Property Variables As Dictionary(Of String, String) 'contains all strings for messageboxes etc.

        Function GetTranslatableHeader() As String
        Sub Translate(ByVal language As Language)
    End Interface
End Namespace