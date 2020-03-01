'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.IO
Imports System.Reflection
Imports System.Xml

''' <summary>Represents the settings of the user.</summary>
Public Class Settings
    Implements ICloneable

    Private m_saveSession As Boolean = True
    Private m_windowState As FormWindowState = FormWindowState.Maximized
    Private m_windowSize As New Size(1024, 500)
    Private m_multipleOpening As Boolean = False
    Private m_autoSwitchToFrameViewer As Boolean = True
    Private m_fontFamily As String = "Courier New"
    Private m_fontSize As UInteger = 9
    Private m_autocompletion As Boolean = False
    Private m_folding As Boolean = False
    Private m_subfolding As Boolean = False
    Private m_frameViewerMenuStrip As Boolean = True
    Private m_frameViewerBGColor As Color = Color.Transparent
    Private m_globalView As Boolean = True
    Private m_syncFrameID As Boolean = True
    Private m_fullRestore As Boolean = True
    Private m_showLineNumbers As Boolean = True
    Private m_markCurrentLine As Boolean = True
    Private m_markLineColor As Color = Color.FromArgb(235, 235, 255)
    Private m_wrapMode As ScintillaNET.WrapMode = ScintillaNET.WrapMode.None
    Private m_showWhitespaces As Boolean = False
    Private m_weaponData As String = ""
    Private m_weaponSprite As String = ""
    Private m_heavyWeaponData As String = ""
    Private m_heavyWeaponSprite As String = ""
    Private m_showChanges As Boolean = True
    Private m_bookmarks As Boolean = False
    Private m_language As String = ""
    Private m_indention As Boolean = False
    Private m_newline As ENewlineChar = ENewlineChar.CR Or ENewlineChar.LF
    Private m_autoJumpBySyncID As Boolean = False
    Private m_scrollbarAnnotations As Boolean = True
    Private m_changeDirect As Boolean = False

    Public WithEvents RecentFiles As New SpecialListWithEvents(Of String) With {.Capacity = 20}
    Private m_recentFilesChanged As Boolean = False

    Public FireEvent As Boolean = True

#Region "Properties"
#Region "General"
    Public Property Language As String
        Get
            Return m_language
        End Get
        Set(value As String)
            If Not m_language.Equals(value) Then
                m_language = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, False)
            End If
        End Set
    End Property
    Public Property RecentFilesCapacity As UInteger
        Get
            Return RecentFiles.Capacity
        End Get
        Set(value As UInteger)
            If value < 100 AndAlso Not RecentFiles.Capacity = value Then
                RecentFiles.Capacity = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property MultipleOpening As Boolean
        Get
            Return m_multipleOpening
        End Get
        Set(value As Boolean)
            If Not m_multipleOpening = value Then
                m_multipleOpening = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property AutoSwitchToFrameViewer As Boolean
        Get
            Return m_autoSwitchToFrameViewer
        End Get
        Set(value As Boolean)
            If Not m_autoSwitchToFrameViewer = value Then
                m_autoSwitchToFrameViewer = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property WindowState As FormWindowState
        Get
            Return m_windowState
        End Get
        Set(value As FormWindowState)
            If [Enum].IsDefined(GetType(FormWindowState), value) AndAlso Not m_windowState = value Then
                m_windowState = value
            End If
        End Set
    End Property
    Public Property WindowSize As Size
        Get
            Return m_windowSize
        End Get
        Set(value As Size)
            If Not m_windowSize.Equals(value) Then
                m_windowSize = value
            End If
        End Set
    End Property
    Public Property SaveSession As Boolean
        Get
            Return m_saveSession
        End Get
        Set(value As Boolean)
            If Not m_saveSession = value Then
                m_saveSession = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property NewlineCharacter As ENewlineChar
        Get
            Return m_newline
        End Get
        Set(value As ENewlineChar)
            If Not m_newline = value Then
                m_newline = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
#End Region
#Region "Text-Editor"
    Public Property FontFamily As String
        Get
            Return m_fontFamily
        End Get
        Set(value As String)
            If Not m_fontFamily.Equals(value) Then
                m_fontFamily = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property FontSize As UInteger
        Get
            Return m_fontSize
        End Get
        Set(value As UInteger)
            If Not m_fontSize = value Then
                m_fontSize = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property Autocompletion As Boolean
        Get
            Return m_autocompletion
        End Get
        Set(value As Boolean)
            If Not m_autocompletion = value Then
                m_autocompletion = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property Folding As Boolean
        Get
            Return m_folding
        End Get
        Set(value As Boolean)
            If Not m_folding = value Then
                m_folding = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property Subfolding As Boolean
        Get
            Return m_subfolding
        End Get
        Set(value As Boolean)
            If Not m_subfolding = value Then
                m_subfolding = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property Indention As Boolean
        Get
            Return m_indention
        End Get
        Set(value As Boolean)
            If Not m_indention = value Then
                m_indention = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property ShowLineNumbers As Boolean
        Get
            Return m_showLineNumbers
        End Get
        Set(value As Boolean)
            If Not m_showLineNumbers = value Then
                m_showLineNumbers = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property ShowWhitespaces As Boolean
        Get
            Return m_showWhitespaces
        End Get
        Set(value As Boolean)
            If Not m_showWhitespaces = value Then
                m_showWhitespaces = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property Bookmarks As Boolean
        Get
            Return m_bookmarks
        End Get
        Set(value As Boolean)
            If Not m_bookmarks = value Then
                m_bookmarks = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property MarkCurrentLine As Boolean
        Get
            Return m_markCurrentLine
        End Get
        Set(value As Boolean)
            If Not m_markCurrentLine = value Then
                m_markCurrentLine = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property MarkLineColor As Color
        Get
            Return m_markLineColor
        End Get
        Set(value As Color)
            If Not m_markLineColor = value Then
                m_markLineColor = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property WrapMode As ScintillaNET.WrapMode
        Get
            Return m_wrapMode
        End Get
        Set(value As ScintillaNET.WrapMode)
            If [Enum].IsDefined(GetType(ScintillaNET.WrapMode), value) AndAlso Not m_wrapMode = value Then
                m_wrapMode = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property ShowChanges As Boolean
        Get
            Return m_showChanges
        End Get
        Set(value As Boolean)
            If Not m_showChanges = value Then
                m_showChanges = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property ScrollbarAnnotations As Boolean
        Get
            Return m_scrollbarAnnotations
        End Get
        Set(value As Boolean)
            If Not value = m_scrollbarAnnotations Then
                m_scrollbarAnnotations = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
#End Region
#Region "Frame Viewer"
    Public Property FrameViewerMenuStrip As Boolean
        Get
            Return m_frameViewerMenuStrip
        End Get
        Set(value As Boolean)
            If Not m_frameViewerMenuStrip = value Then
                m_frameViewerMenuStrip = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property FrameViewerBGColor As Color
        Get
            Return m_frameViewerBGColor
        End Get
        Set(value As Color)
            If Not m_frameViewerBGColor.Equals(value) Then
                m_frameViewerBGColor = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property GlobalView As Boolean
        Get
            Return m_globalView
        End Get
        Set(value As Boolean)
            If Not m_globalView = value Then
                m_globalView = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property FullRestore As Boolean
        Get
            Return m_fullRestore
        End Get
        Set(value As Boolean)
            If Not m_fullRestore = value Then
                m_fullRestore = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property SyncFrameID As Boolean
        Get
            Return m_syncFrameID
        End Get
        Set(value As Boolean)
            If Not m_syncFrameID = value Then
                m_syncFrameID = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property AutoJumpBySyncID As Boolean
        Get
            Return m_autoJumpBySyncID
        End Get
        Set(value As Boolean)
            If Not value = m_autoJumpBySyncID Then
                m_autoJumpBySyncID = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property WeaponData As String
        Get
            Return m_weaponData
        End Get
        Set(value As String)
            If Not m_weaponData.Equals(value) Then
                m_weaponData = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property WeaponSprite As String
        Get
            Return m_weaponSprite
        End Get
        Set(value As String)
            If Not m_weaponSprite.Equals(value) Then
                m_weaponSprite = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property HeavyWeaponData As String
        Get
            Return m_heavyWeaponData
        End Get
        Set(value As String)
            If Not m_heavyWeaponData.Equals(value) Then
                m_heavyWeaponData = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property HeavyWeaponSprite As String
        Get
            Return m_heavyWeaponSprite
        End Get
        Set(value As String)
            If Not m_heavyWeaponSprite.Equals(value) Then
                m_heavyWeaponSprite = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
    Public Property ChangeDirectFV As Boolean
        Get
            Return m_changeDirect
        End Get
        Set(value As Boolean)
            If Not m_changeDirect = value Then
                m_changeDirect = value
                If FireEvent Then RaiseEvent SettingsChanged(Me, True)
            End If
        End Set
    End Property
#End Region
#End Region

    Public ReadOnly Property Restorer As New FrameViewerSettings
    Public ReadOnly Property SearchSettings As New SearchSettings
    Public Event SettingsChanged As EventHandler(Of Boolean)

    Public Sub New(Optional ByVal fromFile As Boolean = True)
        If fromFile Then
            Load()
        End If
    End Sub

    Public Sub Load()
        If File.Exists(SettingsFile) Then
            Try
                Dim doc As New XmlDocument()
                doc.Load(SettingsFile)

                If doc.DocumentElement.Name.Equals(Me.GetType().Name) Then
                    For Each node As XmlNode In doc.DocumentElement.ChildNodes
                        If node.LocalName.Equals("Restorer") Then
                            Restorer.LoadFromXML(node)
                        ElseIf node.LocalName.Equals("SearchSettings") Then
                            SearchSettings.LoadFromXML(node)
                        Else
                            Dim propInfo As PropertyInfo = Me.GetType().GetProperty(node.Name)
                            If Not IsNothing(propInfo) Then
                                Try
                                    propInfo.SetValue(Me, ParseStringValue(propInfo.PropertyType, node.InnerText))
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                    Next
                End If

                If Not String.IsNullOrEmpty(m_language) Then
                    Dim langFile As String = Path.Combine(AppFolder, "languages", m_language)
                    If File.Exists(langFile) Then
                        Translation.Languages.Add(New Translation.Language(langFile))
                        Translation.GlobalStuff.SelectedLanguage = 1
                    End If
                End If
            Catch ex As Exception
            End Try
        End If

        If File.Exists(RecentFilesFile) Then
            For Each line As String In File.ReadLines(RecentFilesFile)
                Try
                    If Not String.IsNullOrEmpty(line) Then
                        If File.Exists(line) Then
                            RecentFiles.Add(line)
                        End If
                    End If
                Catch ex As Exception
                    Debug.WriteLine("Recent file add failed")
                End Try
            Next

            m_recentFilesChanged = False
        End If
    End Sub

    Public Sub Save()
        Using output As New StreamWriter(New FileStream(SettingsFile, FileMode.Create))
            Dim writer As XmlWriter = XmlWriter.Create(output, New XmlWriterSettings() With {.Indent = True, .OmitXmlDeclaration = False})
            With writer
                .WriteStartDocument()
                .WriteStartElement("Settings")

                For Each info As PropertyInfo In Me.GetType().GetProperties
                    If info.PropertyType Is GetType(FrameViewerSettings) Then
                        If Not FullRestore Then Continue For

                        .WriteStartElement(info.Name)
                        CType(info.GetValue(Me), FrameViewerSettings).WriteToXML(writer)
                        .WriteEndElement()
                    ElseIf info.PropertyType Is GetType(SearchSettings) Then
                        .WriteStartElement(info.Name)
                        CType(info.GetValue(Me), SearchSettings).WriteToXML(writer)
                        .WriteEndElement()
                    Else
                        If GetType(SpecialListWithEvents(Of String)).IsAssignableFrom(info.PropertyType) Then
                            Continue For
                        End If
                        .WriteElementString(info.Name, GetStringValue(info.GetValue(Me)))
                    End If
                Next

                .WriteEndDocument()
                .Close()
            End With
        End Using
    End Sub

    Public Sub Close()
        If m_fullRestore Then
            Save()
        End If

        If m_recentFilesChanged Then
            IO.File.WriteAllLines(RecentFilesFile, RecentFiles.ToArray)
        End If
    End Sub

    Public Shared Function GetStringValue(ByVal obj As Object) As String
        If TypeOf obj Is Size Then
            Return CType(obj, Size).Width & "x" & CType(obj, Size).Height
        ElseIf TypeOf obj Is Point Then
            Return CType(obj, Point).X & "x" & CType(obj, Point).Y
        ElseIf TypeOf obj Is SizeF Then
            Return CType(obj, SizeF).Width.ToString("N2", CultureEN) & "x" & CType(obj, SizeF).Height.ToString("N2", CultureEN)
        ElseIf TypeOf obj Is PointF Then
            Return CType(obj, PointF).X.ToString("N2", CultureEN) & "x" & CType(obj, PointF).Y.ToString("N2", CultureEN)
        ElseIf TypeOf obj Is Boolean Or TypeOf obj Is [Enum] Then
            Return Convert.ToInt16(obj).ToString
        ElseIf TypeOf obj Is Color Or TypeOf obj Is SystemColors Then
            Return ColorTranslator.ToHtml(obj)
        ElseIf TypeOf obj Is Single Then
            Return CType(obj, Single).ToString("N2", CultureEN)
            '#Disable Warning 'Necessary fromArgbToArgb because else it is possible that the result is a name
            '            Return ColorTranslator.ToHtml(CType(obj, Color).FromArgb(CType(obj, Color).ToArgb()))
            '#Enable Warning
        End If

        Return obj.ToString
    End Function

    Public Shared Function ParseStringValue(ByVal obj As Type, ByVal val As String) As Object
        If obj Is GetType(Size) Or obj Is GetType(Point) Then
            If Text.RegularExpressions.Regex.IsMatch(val, "-?\d+x-?\d+") Then
                Dim splitter As String() = Split(val, "x")
                If splitter.Count = 2 Then
                    If obj Is GetType(Size) Then
                        Return New Size(CInt(splitter(0)), CInt(splitter(1)))
                    Else
                        Return New Point(CInt(splitter(0)), CInt(splitter(1)))
                    End If
                End If
            End If
        ElseIf obj Is GetType(SizeF) Or obj Is GetType(PointF) Then
            If Text.RegularExpressions.Regex.IsMatch(val, "-?\d+(\.\d+)?x-?\d+(\.\d+)?") Then
                Dim splitter As String() = Split(val, "x")
                If splitter.Count = 2 Then
                    If obj Is GetType(SizeF) Then
                        Return New SizeF(Convert.ToSingle(splitter(0), CultureEN),
                                         Convert.ToSingle(splitter(1), CultureEN))
                    Else
                        Return New PointF(Convert.ToSingle(splitter(0), CultureEN),
                                          Convert.ToSingle(splitter(1), CultureEN))
                    End If
                End If
            End If
        ElseIf obj Is GetType(Boolean) Then
            Return CBool(val)
        ElseIf obj Is GetType(Color) Then
            Return ColorTranslator.FromHtml(val)
        ElseIf obj Is GetType(Integer) Or obj Is GetType(FormWindowState) Then
            Return CInt(val)
        ElseIf obj Is GetType(UInteger) Then
            Return CUInt(val)
        ElseIf obj.IsEnum Then
            Return CByte(val)
        End If
        Return val
    End Function

    Private Sub RecentFiles_ItemAdded(sender As Object, e As String) Handles RecentFiles.ItemAdded, RecentFiles.ItemRemoved, RecentFiles.ItemsCleared
        m_recentFilesChanged = True
    End Sub

    Public Sub ApplyFrom(ByVal settings As Settings)
        FireEvent = False
        For Each propInfo As PropertyInfo In settings.GetType().GetProperties
            If Not propInfo.PropertyType Is GetType(FrameViewerSettings) And Not propInfo.PropertyType Is GetType(SearchSettings) And
               Not GetType(SpecialListWithEvents(Of String)).IsAssignableFrom(propInfo.PropertyType) Then
                propInfo.SetValue(Me, propInfo.GetValue(settings))
            End If
        Next
        FireEvent = True
        RaiseEvent SettingsChanged(Me, True)
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is Settings Then
            Dim settings As Settings = obj

            For Each propInfo As PropertyInfo In settings.GetType().GetProperties
                If Not propInfo.PropertyType Is GetType(FrameViewerSettings) And Not propInfo.PropertyType Is GetType(SearchSettings) And
                   Not GetType(SpecialListWithEvents(Of String)).IsAssignableFrom(propInfo.PropertyType) Then
                    Dim val1 As Object = propInfo.GetValue(settings)
                    Dim val2 As Object = propInfo.GetValue(Me)
                    If Not IsNothing(val1) And Not IsNothing(val2) Then
                        If Not val1.Equals(val2) Then
                            Return False
                        End If
                    ElseIf Not (IsNothing(val1) And IsNothing(val2)) Then
                        Return False
                    End If
                End If
            Next

            Return True
        End If
        Return False
    End Function
End Class