Imports System.Runtime.InteropServices

'------------------------------------------''---------Created by Lui's Studio----------''-------(http://www.lui-studio.net/)-------''------------------------------------------''-------------Author: Luigi600-------------''------------------------------------------'
'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> see name.... </summary>

Public Class class_singleInstance

    Public Const WM_COPYDATA As Integer = &H4A
    Public Const WM_USER As Integer = &H7FFF
    Public Const WM_SETTEXT As Integer = &HC
    Public Const SW_RESTORE As Integer = &H9

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As IntPtr, lParam As String) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal Msg As UInteger) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
End Class