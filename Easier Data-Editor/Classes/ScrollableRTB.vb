Imports System.Runtime.InteropServices

Public Class ScrollableRTB
    Inherits RichTextBox
    Private Const WM_MOUSEWHEEL As Integer = &H20A

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_MOUSEWHEEL Then
            SendMessage(Me.Parent.Handle, m.Msg, m.WParam, m.LParam)
            m.Result = IntPtr.Zero
        Else
            MyBase.WndProc(m)
        End If
    End Sub
End Class