'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Namespace LittleFighter
    ''' <summary>Represents a rectangle (like in LF2???).</summary>
    ''' <todo>X2, Y2 than properties, encapsulation, remove this class??</todo>
    ''' <node>WHY Serializable?!</node>
    <Serializable()>
    Public Class LFRect
        Public X As Integer = 0
        Public Y As Integer = 0
        Public Width As Integer = 0
        Public Height As Integer = 0

        Public Function X2() As Integer
            Return X + Width
        End Function

        Public Function Y2() As Integer
            Return Y + Height
        End Function

        Public Sub New()
        End Sub

        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            Me.X = x
            Me.Y = y
        End Sub
        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
            Me.X = x
            Me.Y = y
            Me.Width = width
            Me.Height = height
        End Sub

        Public Sub New(ByVal rect As Rectangle)
            X = rect.X
            Y = rect.Y
            Width = rect.Width
            Height = rect.Height
        End Sub

        Public Function GetRect() As Rectangle
            Return New Rectangle(X, Y, Width, Height)
        End Function

        Public Function GetRectWithX2AndY2() As Rectangle
            Return New Rectangle(X, Y, X2, Y2)
        End Function

        Public Function Contains(ByVal point As Point) As Boolean
            Return point.X >= X And point.X < X2() And point.Y >= Y And point.Y < Y2()
        End Function
    End Class
End Namespace