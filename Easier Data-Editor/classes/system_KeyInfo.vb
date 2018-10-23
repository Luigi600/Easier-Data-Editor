'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Used by FrameViewer to check if "key is pressed" </summary>

Public Class system_KeyInfo
    <Runtime.InteropServices.DllImport("User32.dll")>
    Private Shared Function GetKeyState(vKey As System.Int32) As Short
    End Function

    Public Shared Function IsKeyPressed(key As Keys) As Boolean
        Return BitConverter.GetBytes(GetKeyState(CInt(key)))(1) > 0
    End Function
End Class