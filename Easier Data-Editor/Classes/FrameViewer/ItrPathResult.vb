'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Drawing.Drawing2D

''' <summary>Represents a 3D itr with the graphics paths.</summary>
Public Class ItrPathResult
    Public ReadOnly Path1 As GraphicsPath = Nothing
    Public ReadOnly Path2 As GraphicsPath = Nothing
    Public ReadOnly Rect As New Rectangle

    Public Sub New(ByVal path1 As GraphicsPath, ByVal path2 As GraphicsPath, ByVal rect As Rectangle)
        Me.Path1 = path1
        Me.Path2 = path2
        Me.Rect = rect
    End Sub
End Class