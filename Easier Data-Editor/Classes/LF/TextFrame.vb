'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents the offset of a LF2-Frame inside an editors.</summary>
''' <todo>Encapsulation of members/properties.</todo>
Public Class TextFrame
    Public Offset As Long = -1
    Public Length As Long = -1
    Public Lines As String = ""
    Public Name As String = ""

    Public OffsetBPoint As New Point(-1, -1)
    Public OffsetWPoint As New Point(-1, -1)
    Public OffsetCPoint As New Point(-1, -1)
    Public OffsetOPoint As New Point(-1, -1)

    Public OffsetBodies As New List(Of Point)
    Public OffsetItrs As New List(Of Point)


    Public Overrides Function ToString() As String
        Return Offset & " - " & Length
    End Function
End Class