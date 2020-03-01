'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Namespace LittleFighter
    ''' <summary>Represents a bdy like in LF2.</summary>
    ''' <todo>Encapsulation of the members/properties.</todo>
    ''' <note>WHY Serializable?!</note>
    <Serializable()>
    Public Class Bdy
        Public Rect As New LFRect
        Public Kind As Integer = 0
    End Class
End Namespace