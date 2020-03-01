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

''' <summary>Represents the settings for a search with Scintilla.</summary>
Public Class SearchSettings
    Private m_matchWholeWord As Boolean
    Private m_matchCase As Boolean
    Private m_wrapAround As Boolean
    Private m_inSelections As Boolean

    Private m_searchMode As ESearchMode
    Private m_transparency As ETransparency
    Private m_opacity As Integer = 10

    Public ReadOnly Property FindList As New SpecialListWithEvents(Of String) With {.Capacity = 10}
    Public ReadOnly Property ReplaceList As New SpecialListWithEvents(Of String) With {.Capacity = 10}

    Private m_bookmarkLine As Boolean
    Private m_purge As Boolean

    Public ReadOnly Property Filters As New SpecialListWithEvents(Of String) With {.Capacity = 10}
    Public ReadOnly Property Directories As New SpecialListWithEvents(Of String) With {.Capacity = 10}
    Private m_subfolders As Boolean = False
    Private m_hiddenFolders As Boolean = False

    Public FireEvent As Boolean = True

#Region "Properties"
    Public Property MatchWholeWord As Boolean
        Get
            Return m_matchWholeWord
        End Get
        Set(value As Boolean)
            If Not m_matchWholeWord = value Then
                m_matchWholeWord = value
            End If
        End Set
    End Property
    Public Property MatchCase As Boolean
        Get
            Return m_matchCase
        End Get
        Set(value As Boolean)
            If Not m_matchCase = value Then
                m_matchCase = value
            End If
        End Set
    End Property
    Public Property WrapAround As Boolean
        Get
            Return m_wrapAround
        End Get
        Set(value As Boolean)
            If Not m_wrapAround = value Then
                m_wrapAround = value
            End If
        End Set
    End Property
    Public Property InSelections As Boolean
        Get
            Return m_inSelections
        End Get
        Set(value As Boolean)
            If Not m_inSelections = value Then
                m_inSelections = value
            End If
        End Set
    End Property
    Public Property SearchMode As ESearchMode
        Get
            Return m_searchMode
        End Get
        Set(value As ESearchMode)
            If [Enum].IsDefined(GetType(ESearchMode), value) AndAlso Not m_searchMode = value Then
                m_searchMode = value
            End If
        End Set
    End Property
    Public Property TransparencyState As ETransparency
        Get
            Return m_transparency
        End Get
        Set(value As ETransparency)
            If [Enum].IsDefined(GetType(ETransparency), value) AndAlso Not m_transparency = value Then
                m_transparency = value
            End If
        End Set
    End Property
    Public Property Opacity As Integer
        Get
            Return m_opacity
        End Get
        Set(value As Integer)
            If value >= 10 AndAlso value <= 100 AndAlso Not m_opacity = value Then
                m_opacity = value
            End If
        End Set
    End Property
    Public Property BookmarkLine As Boolean
        Get
            Return m_bookmarkLine
        End Get
        Set(value As Boolean)
            If Not m_bookmarkLine = value Then
                m_bookmarkLine = value
            End If
        End Set
    End Property
    Public Property Purge As Boolean
        Get
            Return m_purge
        End Get
        Set(value As Boolean)
            If Not m_purge = value Then
                m_purge = value
            End If
        End Set
    End Property
    Public Property InSubfolders As Boolean
        Get
            Return m_subfolders
        End Get
        Set(value As Boolean)
            If Not m_subfolders = value Then
                m_subfolders = value
            End If
        End Set
    End Property
    Public Property InHiddenFolders As Boolean
        Get
            Return m_hiddenFolders
        End Get
        Set(value As Boolean)
            If Not m_hiddenFolders = value Then
                m_hiddenFolders = value
            End If
        End Set
    End Property
#End Region

    Public Sub WriteToXML(ByRef writer As XmlWriter)
        With writer
            For Each info As PropertyInfo In Me.GetType().GetProperties()
                If GetType(SpecialListWithEvents(Of String)).IsAssignableFrom(info.PropertyType) Then
                    Dim items As SpecialListWithEvents(Of String) = info.GetValue(Me)
                    writer.WriteStartElement(info.Name)
                    items.Reverse()

                    For Each item As String In items
                        writer.WriteElementString("Item", item)
                    Next
                    writer.WriteEndElement()
                Else
                    .WriteElementString(info.Name, Settings.GetStringValue(info.GetValue(Me)))
                End If
            Next
        End With
    End Sub

    Public Sub LoadFromXML(ByVal myRootNode As XmlNode)
        For Each node As XmlNode In myRootNode.ChildNodes
            Dim propInfo As PropertyInfo = Me.GetType().GetProperty(node.Name)
            If Not IsNothing(propInfo) Then
                Try
                    If GetType(SpecialListWithEvents(Of String)).IsAssignableFrom(propInfo.PropertyType) Then
                        For Each subNode As XmlNode In node.ChildNodes
                            propInfo.PropertyType.GetMethod("Add").Invoke(propInfo.GetValue(Me), {subNode.InnerText})
                        Next
                    Else
                        propInfo.SetValue(Me, Settings.ParseStringValue(propInfo.PropertyType, node.InnerText))
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub
End Class