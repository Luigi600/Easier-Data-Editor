'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Contains global variables.</summary>
Friend Module App
    Public Const AppTitle As String = "Easier Data-Editor (STM93 Version)" 'title (not translatable)
    Public ReadOnly AppFolder As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Easier LF-Editor", "Data Editor")
    Public ReadOnly SettingsFile As String = IO.Path.Combine(AppFolder, "settings_v2.xml")
    Public ReadOnly RecentFilesFile As String = IO.Path.Combine(AppFolder, "recentfiles.txt")
    Public ReadOnly LayoutFile As String = IO.Path.Combine(AppFolder, "layout_v2.xml")
    Public ReadOnly LanguageDirectory As String = IO.Path.Combine(AppFolder, "languages")

    Public ReadOnly CultureEN As New Globalization.CultureInfo("en-US")
    Public ReadOnly SpecialSettings As New Settings(False) With {.Autocompletion = False, .Folding = False, .ShowLineNumbers = False, .ShowChanges = False}
    Public ReadOnly Settings As New Settings()

    Public LanguageChecker As IO.FileSystemWatcher = Nothing

    Public CustomSyntax As New Syntax(My.Resources.syntax)

#Region "Windows"
    Public ReadOnly GoToWindow As New GoToWindow
    Public ReadOnly ErrorList As New ErrorList
    Public ReadOnly UnusedIDs As New UnusedIDs
    Public ReadOnly SearchWindow As New FindReplaceMark
#End Region

    Private isDebug_ As Boolean = False

    Public Sub SetDebug()
#If DEBUG Then
        isDebug_ = True
#End If
    End Sub

    Public ReadOnly Property IsDebug As Boolean
        Get
            Return isDebug_
        End Get
    End Property
End Module