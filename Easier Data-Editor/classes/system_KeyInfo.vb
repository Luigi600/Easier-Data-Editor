Public Class system_KeyInfo
    <Runtime.InteropServices.DllImport("User32.dll")>
    Private Shared Function GetKeyState(vKey As System.Int32) As Short
    End Function

    Public Shared Function IsKeyPressed(key As Keys) As Boolean
        Return BitConverter.GetBytes(GetKeyState(CInt(key)))(1) > 0
    End Function
End Class