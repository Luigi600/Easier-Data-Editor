Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Enum FrameChangeType
    None = -1
    WPoint
    OPoint
    BPoint
    CPoint
    Bdy
    Itr
    CenterXY
    CenterXY2
End Enum

<Serializable()>
Public Class LFFrame
    Implements ICloneable

    Public Name As String
    Public ID As Integer
    Public PicID As Integer
    Public Image As Bitmap
    Public [Next] As Integer
    Public Center As New Point
    Public DvX As Integer
    Public DvY As Integer
    Public DvZ As Integer

    Public Bodys As New List(Of bdy) 'up to 5/frame
    Public Itrs As New List(Of itr) 'up to 5/frame
    Public WPoint As wpoint
    Public OPoint As New Point(Integer.MaxValue, Integer.MaxValue)
    Public BPoint As New Point(Integer.MaxValue, Integer.MaxValue)
    Public CPoint As New Point(Integer.MaxValue, Integer.MaxValue)

    Public Facing As Boolean = False

    Public Sub Dispose()
        If Not IsNothing(Image) Then
            Image.Dispose()
        End If
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function
End Class

<Serializable()>
Public Class bdy
    Public Rect As New LFRect
    Public Kind As Integer = 0
End Class

<Serializable()>
Public Class itr
    Inherits bdy

    Public DvX As Integer = 0
    Public DvY As Integer = 0
    Public Fall As Integer = 0
    Public Arest As Integer = 0
    Public Vrest As Integer = 0
    Public Bdefend As Integer = 0
    Public Injury As Integer = 0
    Public Effect As Integer = 0
    Public Catchingact As New Point
    Public Caughtact As New Point
End Class

<Serializable()>
Public Class opoint
    Public Kind As Integer = 1
    Public Loca As New Point
    Public Action As Integer = 0
    Public DvX As Integer = 0
    Public DvY As Integer = 0
    Public Oid As Integer = 0
    Public Facing As Boolean = False
End Class

<Serializable()>
Public Class wpoint
    Public Kind As Integer = 1
    Public Loca As New Point
    Public Weaponact As Integer = 0
    Public Attacking As Integer = 0
    Public Cover As Boolean = True
    Public DvX As Integer = 0
    Public DvY As Integer = 0
    Public DvZ As Integer = 0
End Class

<Serializable()>
Public Class cpoint

End Class

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
End Class