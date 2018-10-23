'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Just a custom EventArgs for more arguments (two...) </summary>

Public Class class_customEventArgs
    Inherits EventArgs

    Public ReadOnly Property [Object] As Object
    Public ReadOnly Property Object2 As Object
    Public Sub New(ByVal obj As Object, Optional ByVal obj2 As Object = Nothing)
        [Object] = obj
        Object2 = obj2
    End Sub
End Class
