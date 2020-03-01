'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Namespace LittleFighter
    ''' <summary>Represents an opoint like in LF2.</summary>
    ''' <todo>Inherits from WPoint(?) or rather same base class. Encapsulation of members/properties.</todo>
    ''' <note>WHY Serializable?!</note>
    <Serializable()>
    Public Class OPoint
        Public Kind As Integer = 1
        Public Loca As New Point
        Public Action As Integer = 0
        Public DvX As Integer = 0
        Public DvY As Integer = 0
        Public Oid As Integer = 0
        Public Facing As Boolean = False
    End Class
End Namespace