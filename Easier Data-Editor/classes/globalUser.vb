Module globalUser
    Public appFolder As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Easier LF-Editor", "Data Editor")

    Public isStarting As Boolean = True
    Public LastGoToWasLine As Boolean = True

    Public syntaxHighlighting As ICSharpCode.AvalonEdit.Highlighting.IHighlightingDefinition = Nothing
    Public cultureEN As New Globalization.CultureInfo("en-US")

    Public shadow As Bitmap = My.Resources.shadow
    Public Weapon As class_weapon = Nothing

    Public ErrorList As New ui_error_list
    Public UnusedFrames As New ui_unused_frames
    Public SearchWindow As New ui_search
    Public SearchClass As New Search

#Region "User Options"
    Public recentFile As String = IO.Path.Combine(appFolder, "recentfiles.txt")
    Public recentFiles As New List(Of String)
    Public opt_recentMax As Integer = 20
    Public recentFileWasChanged As Boolean = False
    Public opt_doubleOpening As Boolean = False

    Public windowSize As New Size
    Public windowState As FormWindowState = FormWindowState.Normal

    Public opt_saveSession As Boolean = True

    Public opt_userFontFamily As New Windows.Media.FontFamily("Consolas")
    Public opt_userFontSize As Double = 12.5

    Public opt_showMS As Boolean = False

    Public opt_defaultBackgroundColor As Color = Color.White
    Public opt_directResult As Boolean = False
    Public opt_autocomplete As Boolean = False
    Public opt_autoOpenViewer As Boolean = False
    Public opt_folding As Boolean = True

#Region "Global Settings"
    Public isGlobalSettingsEnable As Boolean = True
    Public global_draw_axis As Boolean = True
    Public global_draw_centerXY As Boolean = True
    Public global_draw_shadow As Boolean = True
    'Public global_draw_characterPoint As Boolean = True
    Public global_draw_bodys As Boolean = True
    Public global_draw_itrs As Boolean = True
    Public global_draw_wpoint As Boolean = True
    Public global_draw_weapon As Boolean = True
    Public global_draw_wHitboxes As Boolean = False
    Public global_draw_bpoint As Boolean = True
    Public global_draw_opoint As Boolean = True
    Public global_draw_cpoint As Boolean = True
    Public global_draw_scales As Boolean = True

    Public global_zoom As Integer = 100
    Public global_scrollPosition As New Point(0, 0)
    Public global_centerPoint As New Point(200, 200)
#End Region
#End Region

End Module
