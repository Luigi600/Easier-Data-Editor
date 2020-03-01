'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace LittleFighter
    ''' <summary>Represents a Frame like in LF2.</summary>
    ''' <todo>Encapsulation of members/properties.</todo>
    ''' <node>WHY Serializable?!</node>
    <Serializable()>
    Public Class Frame
        Implements ICloneable

        Public Name As String = ""
        Public ID As Integer
        Public PicID As Integer
        'Public ImageSource As MemoryStream = Nothing
        Public Image As Bitmap
        Public [Next] As Integer
        Public [Wait] As Integer
        Public Center As New Point
        Public DvX As Integer
        Public DvY As Integer
        Public DvZ As Integer

        Public Bodys As New List(Of Bdy) 'up to 5/frame
        Public Itrs As New List(Of Itr) 'up to 5/frame
        Public WPoint As WPoint
        Public OPoint As New Point(Integer.MaxValue, Integer.MaxValue)
        Public BPoint As New Point(Integer.MaxValue, Integer.MaxValue)
        Public CPoint As New Point(Integer.MaxValue, Integer.MaxValue)

        Public Facing As Boolean = False

        'Public Sub Dispose()
        '    If Not IsNothing(Image) Then
        '        Image.Dispose()
        '    End If
        'End Sub

        Public Function Clone() As Object Implements ICloneable.Clone
            Dim m As New MemoryStream()
            Dim f As New BinaryFormatter()
            f.Serialize(m, Me)
            m.Seek(0, SeekOrigin.Begin)
            Return f.Deserialize(m)
        End Function
    End Class
End Namespace