'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Just Combobox-Frame-Item (thanks at Uri that I have to created this class :p) </summary>

Public Class class_comboItem
    Public FrameName As String = ""
    Public FrameOffset As Integer = 0

    Public Sub New() 'Dummy
    End Sub

    Public Sub New(ByVal frameName As String, ByVal frameOffset As Integer)
        Me.FrameName = frameName.Trim
        Me.FrameOffset = frameOffset
    End Sub

    Public Overrides Function ToString() As String
        Return FrameName
    End Function
End Class

Public Class class_comboEXEItem
    Public Name As String = ""
    Public Path As String = ""

    Public Sub New() 'Dummy
    End Sub

    Public Sub New(ByVal path As String)
        Me.Path = path
        Name = IO.Path.GetFileName(path)
    End Sub

    Public Sub New(ByVal fileName As String, ByVal path As String)
        Name = fileName.Trim
        Me.Path = path.Trim
    End Sub

    Public Overrides Function ToString() As String
        Return getViewName() ' Name
    End Function

    Private Function getViewName() As String
        Dim maxLen As Integer = 30
        If Path.Length > maxLen Then
            Dim result As String = Path.Substring(Path.Length - maxLen, maxLen)
            Return "..." & result
        End If
        Return Path
    End Function
End Class