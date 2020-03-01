'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Namespace LittleFighter
    ''' <summary>Represents a wpoint like in LF2.</summary>
    ''' <todo>Inherits from OPoint(?) or rather same base class. Encapsulation of members/properties.</todo>
    ''' <note>WHY Serializable?!</note>
    <Serializable()>
    Public Class WPoint
        Public Kind As Integer = 1
        Public Loca As New Point
        Public Weaponact As Integer = 0
        Public Attacking As Integer = 0
        Public Cover As Boolean = True
        Public DvX As Integer = 0
        Public DvY As Integer = 0
        Public DvZ As Integer = 0
    End Class
End Namespace