'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Drawing.Drawing2D

Namespace LittleFighter
    ''' <summary>Represents an itr like in LF2.</summary>
    ''' <todo>No inheriting from bdy rather from the same base class. Encapsulation of members/properties.</todo>
    ''' <node>WHY Serializable?!</node>
    <Serializable()>
    Public Class Itr
        Inherits Bdy

        Public zWidth As Integer = -1
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

        Public Function GetZWidthThanSize() As Size
            'thanks STM for the wrong zWidth ;P
            'but really thanks for all and to the people there found it out
            If zWidth < 0 Then zWidth = 15
            Return New Size(zWidth, zWidth - 2)
        End Function

        Public Function GetItrPaths(ByVal isBehind As Boolean, ByVal m_realPixelSize As Single) As ItrPathResult
            Dim zwidth As Size = GetZWidthThanSize()
            Dim rect_behind As New Rectangle(Rect.X + zwidth.Width, Rect.Y - zwidth.Width, Rect.Width, Rect.Height)
            Dim rect_ahead As New Rectangle(Rect.X - zwidth.Height, Rect.Y + zwidth.Height, Rect.Width, Rect.Height)

            If isBehind Then
                'Dim rect_behind As New Rectangle(RelativPosition.X + Rect.X + zwidth.Width, RelativPosition.Y + Rect.Y - zwidth.Width, Rect.Width, Rect.Height)
                'Dim rect_ahead As New Rectangle(RelativPosition.X + Rect.X - zwidth.Height, RelativPosition.Y + Rect.Y + zwidth.Height, Rect.Width, Rect.Height)
                Dim path As GraphicsPath = GetItrPath(False, m_realPixelSize, New PointF(rect_ahead.X, rect_ahead.Y + rect_ahead.Height),
                                                      New PointF(rect_behind.X, rect_behind.Y + rect_behind.Height),
                                                      New PointF(rect_behind.X + rect_behind.Width - m_realPixelSize, rect_behind.Y + rect_behind.Height),
                                                      New PointF(rect_ahead.X + rect_ahead.Width - m_realPixelSize, rect_ahead.Y + rect_ahead.Height))


                Dim path2 As GraphicsPath = GetItrPath(True, m_realPixelSize, New PointF(rect_behind.X, rect_behind.Y + rect_behind.Height),
                                                       New PointF(rect_ahead.X, rect_ahead.Y + rect_ahead.Height),
                                                       New PointF(rect_ahead.X, rect_ahead.Y + 2 * m_realPixelSize),
                                                       New PointF(rect_behind.X, rect_behind.Y + 2 * m_realPixelSize))
                Return New ItrPathResult(path, path2, rect_behind)
            Else
                'Dim rect_behind As New Rectangle(RelativPosition.X + Rect.X + zwidth.Width, RelativPosition.Y + Rect.Y - zwidth.Width, Rect.Width, Rect.Height)
                'Dim rect_ahead As New Rectangle(RelativPosition.X + Rect.X - zwidth.Height, RelativPosition.Y + Rect.Y + zwidth.Height, Rect.Width, Rect.Height)
                Dim path As GraphicsPath = GetItrPath(False, m_realPixelSize, New PointF(rect_behind.X, rect_behind.Y + m_realPixelSize),
                                                      New PointF(rect_behind.X + rect_behind.Width - m_realPixelSize, rect_behind.Y + m_realPixelSize),
                                                      New PointF(rect_ahead.X + rect_ahead.Width - m_realPixelSize, rect_ahead.Y + m_realPixelSize),
                                                      New PointF(rect_ahead.X, rect_ahead.Y + m_realPixelSize))
                Dim path2 As GraphicsPath = GetItrPath(False, m_realPixelSize, New PointF(rect_behind.X + rect_behind.Width, rect_behind.Y + rect_behind.Height),
                                                       New PointF(rect_ahead.X + rect_ahead.Width, rect_ahead.Y + rect_ahead.Height),
                                                       New PointF(rect_ahead.X + rect_ahead.Width, rect_ahead.Y),
                                                       New PointF(rect_behind.X + rect_ahead.Width, rect_behind.Y))
                Return New ItrPathResult(path, path2, rect_ahead)
            End If
        End Function

        Private Function GetItrPath(ByVal addToY As Boolean, ByVal m_realPixelSize As Single, ByVal ParamArray points() As PointF) As GraphicsPath
            Dim result As New GraphicsPath

            For i As Integer = 1 To points.Count - 1
                If addToY Then points(i).Y -= m_realPixelSize
                result.AddLine(points(i - 1), points(i))
            Next
            If points.Count > 1 Then
                If addToY Then points(0).Y -= m_realPixelSize
                result.AddLine(points(points.Count - 1), points(0))
            End If

            Return result
        End Function
    End Class
End Namespace