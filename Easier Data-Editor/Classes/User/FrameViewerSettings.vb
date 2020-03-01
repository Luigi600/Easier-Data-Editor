'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Reflection
Imports System.Xml

''' <summary>Represents the view settings of a Frame Viewer.</summary>
Public Class FrameViewerSettings
    Public Const ZOOM_MAXIMUM As Integer = 1400

    Private m_axis As Boolean = False
    Private m_centerXY As Boolean = False
    Private m_shadow As Boolean = True
    Private m_bodies As Boolean = True
    Private m_itrs As Boolean = True
    Private m_itr3D As Boolean = False
    Private m_wpoint As Boolean = True
    Private m_weapon As Boolean = True
    Private m_weaponHitboxes As Boolean = False
    Private m_bpoint As Boolean = True
    Private m_opoint As Boolean = True
    Private m_cpoint As Boolean = True
    Private m_scales As Boolean = True
    Private m_selectedID As Integer = -1
    Private m_zoom As Integer = 100
    Private m_scrollPosition As New PointF(0, 0)
    Private m_centerPoint As New Point(200, 200)
    Private m_characterOpacity As Integer = 100
    Private m_backgroundColor As Color = Color.Transparent
    Private m_fillRectangles As Boolean = True
    Private m_drawBSprite As Boolean = False

    Public FireEvent As Boolean = True
    Public Event AxisStateChanged As EventHandler(Of Boolean)
    Public Event CenterStateChanged As EventHandler(Of Boolean)
    Public Event ShadowStateChanged As EventHandler(Of Boolean)
    Public Event BodiesStateChanged As EventHandler(Of Boolean)
    Public Event ItrsStateChanged As EventHandler(Of Boolean)
    Public Event Itrs3DStateChanged As EventHandler(Of Boolean)
    Public Event WPointStateChanged As EventHandler(Of Boolean)
    Public Event WeaponStateChanged As EventHandler(Of Boolean)
    Public Event WeaponHitboxesChanged As EventHandler(Of Boolean)
    Public Event BPointStateChanged As EventHandler(Of Boolean)
    Public Event OPointStateChanged As EventHandler(Of Boolean)
    Public Event CPointStateChanged As EventHandler(Of Boolean)
    Public Event ScaleStateChanged As EventHandler(Of Boolean)
    Public Event SelectedIDChanged As EventHandler(Of Integer)
    Public Event ZoomStateChanged As EventHandler(Of Boolean)
    Public Event ScrollPositionChanged As EventHandler(Of PointF)
    Public Event CenterPointChanged As EventHandler(Of Point)
    Public Event CharacterOpacityChanged As EventHandler(Of Boolean)
    Public Event BackgroundColorChanged As EventHandler(Of Color)
    Public Event FillStateChanged As EventHandler(Of Boolean)
    Public Event DrawBSpriteChanged As EventHandler(Of Boolean)

#Region "Properties"
    Public Property Axis As Boolean
        Get
            Return m_axis
        End Get
        Set(value As Boolean)
            If Not m_axis = value Then
                m_axis = value
                If FireEvent Then RaiseEvent AxisStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property CenterXY As Boolean
        Get
            Return m_centerXY
        End Get
        Set(value As Boolean)
            If Not m_centerXY = value Then
                m_centerXY = value
                If FireEvent Then RaiseEvent CenterStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property Shadow As Boolean
        Get
            Return m_shadow
        End Get
        Set(value As Boolean)
            If Not m_shadow = value Then
                m_shadow = value
                If FireEvent Then RaiseEvent ShadowStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property Bodies As Boolean
        Get
            Return m_bodies
        End Get
        Set(value As Boolean)
            If Not m_bodies = value Then
                m_bodies = value
                If FireEvent Then RaiseEvent BodiesStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property Itrs As Boolean
        Get
            Return m_itrs
        End Get
        Set(value As Boolean)
            If Not m_itrs = value Then
                m_itrs = value
                If FireEvent Then RaiseEvent ItrsStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property Itr3D As Boolean
        Get
            Return m_itr3D
        End Get
        Set(value As Boolean)
            If Not m_itr3D = value Then
                m_itr3D = value
                If FireEvent Then RaiseEvent Itrs3DStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property WPoint As Boolean
        Get
            Return m_wpoint
        End Get
        Set(value As Boolean)
            If Not m_wpoint = value Then
                m_wpoint = value
                If FireEvent Then RaiseEvent WPointStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property Weapon As Boolean
        Get
            Return m_weapon
        End Get
        Set(value As Boolean)
            If Not m_weapon = value Then
                m_weapon = value
                If FireEvent Then RaiseEvent WeaponStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property WeaponHitboxes As Boolean
        Get
            Return m_weaponHitboxes
        End Get
        Set(value As Boolean)
            If Not m_weaponHitboxes = value Then
                m_weaponHitboxes = value
                If FireEvent Then RaiseEvent WeaponHitboxesChanged(Me, value)
            End If
        End Set
    End Property

    Public Property BPoint As Boolean
        Get
            Return m_bpoint
        End Get
        Set(value As Boolean)
            If Not m_bpoint = value Then
                m_bpoint = value
                If FireEvent Then RaiseEvent BPointStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property OPoint As Boolean
        Get
            Return m_opoint
        End Get
        Set(value As Boolean)
            If Not m_opoint = value Then
                m_opoint = value
                If FireEvent Then RaiseEvent OPointStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property CPoint As Boolean
        Get
            Return m_cpoint
        End Get
        Set(value As Boolean)
            If Not m_cpoint = value Then
                m_cpoint = value
                If FireEvent Then RaiseEvent CPointStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property Scales As Boolean
        Get
            Return m_scales
        End Get
        Set(value As Boolean)
            If Not m_scales = value Then
                m_scales = value
                If FireEvent Then RaiseEvent ScaleStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property SelectedID As Integer
        Get
            Return m_selectedID
        End Get
        Set(value As Integer)
            If Not m_selectedID = value Then
                m_selectedID = value
                If FireEvent Then RaiseEvent SelectedIDChanged(Me, value)
            End If
        End Set
    End Property

    Public Property Zoom As Integer
        Get
            Return m_zoom
        End Get
        Set(value As Integer)
            If value >= 100 And value <= ZOOM_MAXIMUM Then
                m_zoom = value
                RaiseEvent ZoomStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property ScrollPosition As PointF
        Get
            Return m_scrollPosition
        End Get
        Set(value As PointF)
            If Not m_scrollPosition.Equals(value) Then
                m_scrollPosition = value
                If FireEvent Then RaiseEvent ScrollPositionChanged(Me, value)
            End If
        End Set
    End Property

    Public Property CenterPoint As Point
        Get
            Return m_centerPoint
        End Get
        Set(value As Point)
            m_centerPoint = value
            If FireEvent Then RaiseEvent CenterPointChanged(Me, value)
        End Set
    End Property

    Public Property CharacterOpacity As Integer
        Get
            Return m_characterOpacity
        End Get
        Set(value As Integer)
            If Not m_characterOpacity = value Then
                m_characterOpacity = value
                If FireEvent Then RaiseEvent CharacterOpacityChanged(Me, value)
            End If
        End Set
    End Property

    Public Property BackgroundColor As Color
        Get
            Return m_backgroundColor
        End Get
        Set(value As Color)
            If Not m_backgroundColor = value Then
                m_backgroundColor = value
                If FireEvent Then RaiseEvent BackgroundColorChanged(Me, value)
            End If
        End Set
    End Property

    Public Property FillRectangles As Boolean
        Get
            Return m_fillRectangles
        End Get
        Set(value As Boolean)
            If Not m_fillRectangles = value Then
                m_fillRectangles = value
                If FireEvent Then RaiseEvent FillStateChanged(Me, value)
            End If
        End Set
    End Property

    Public Property DrawBSprite As Boolean
        Get
            Return m_drawBSprite
        End Get
        Set(value As Boolean)
            If Not m_drawBSprite = value Then
                m_drawBSprite = value
                If FireEvent Then RaiseEvent DrawBSpriteChanged(Me, value)
            End If
        End Set
    End Property
#End Region

    Public Sub WriteToXML(ByRef writer As XmlWriter)
        With writer
            For Each info As PropertyInfo In Me.GetType().GetProperties()
                .WriteElementString(info.Name, Settings.GetStringValue(info.GetValue(Me)))
            Next
        End With
    End Sub

    Public Sub LoadFromXML(ByVal restoreNode As XmlNode)
        For Each node As XmlNode In restoreNode.ChildNodes
            Dim propInfo As PropertyInfo = Me.GetType().GetProperty(node.Name)
            If Not IsNothing(propInfo) Then
                Try
                    propInfo.SetValue(Me, Settings.ParseStringValue(propInfo.PropertyType, node.InnerText))
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub
End Class