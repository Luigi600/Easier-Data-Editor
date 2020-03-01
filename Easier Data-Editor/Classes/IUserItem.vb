'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents an user item.</summary>
''' <todo>Removes the interface. Unnecessary because the polymorphism it not really used.</todo>
Public Interface IUserItem
    ReadOnly Property ID As Integer
    Property Path As String
    WriteOnly Property HasFocus As Boolean
End Interface