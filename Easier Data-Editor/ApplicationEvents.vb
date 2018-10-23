Imports System.Threading
Imports System.Xml
Imports ICSharpCode.AvalonEdit.Highlighting
Imports Microsoft.VisualBasic.ApplicationServices

'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Main-Class: Loads in single instance, loads options/settings, set autocomplete list </summary>

Namespace My
    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
    ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication
        Shared mutex_ As New Mutex(True, "Easier_Data_Editor") '{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}")


        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If Not IO.Directory.Exists(appFolder) Then
                IO.Directory.CreateDirectory(appFolder)
            End If


            If mutex_.WaitOne(TimeSpan.Zero, True) Then
                mutex_.ReleaseMutex()
            Else
                e.Cancel = True
                Dim found_pro As Process = Nothing
                For Each pro As Process In Process.GetProcesses
                    If Not IsNothing(pro.MainWindowTitle) Then
                        If pro.MainWindowTitle.Length > 2 Then
                            If pro.MainWindowTitle.StartsWith("Easier Data-Editor") Then
                                If Not pro.MainWindowTitle.Replace("Microsoft", "").Length <> pro.MainWindowTitle.Length Then 'VS 2017 debugger shit
                                    found_pro = pro
                                    Exit For
                                End If
                            End If
                        End If
                    End If
                Next

                If Not IsNothing(found_pro) Then
                    For Each arg As String In Application.CommandLineArgs
                        Try
                            If IO.Path.GetExtension(arg).ToLower.Substring(1).Equals("dat") Or IO.Path.GetExtension(arg).ToLower.Substring(1).Equals("txt") Then
                                class_singleInstance.SendMessage(found_pro.MainWindowHandle, class_singleInstance.WM_SETTEXT, 0, arg)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Exit Sub
                End If
            End If



            syntaxHighlighting = HighlightingManager.Instance.GetDefinition("LF2-Data")
            If IO.File.Exists(IO.Path.Combine(appFolder, "syntax.xshd")) Then
                Try
                    Dim customHighlighting As IHighlightingDefinition = Nothing
                    Using reader As New XmlTextReader(IO.Path.Combine(appFolder, "syntax.xshd"))
                        customHighlighting = Xshd.HighlightingLoader.Load(reader, HighlightingManager.Instance)
                    End Using
                    If Not IsNothing(customHighlighting) Then
                        HighlightingManager.Instance.RegisterHighlighting("CustomData", New String() {".dat"}, customHighlighting)
                        syntaxHighlighting = HighlightingManager.Instance.GetDefinition("CustomData")
                    End If
                Catch ex As Exception
                End Try
            End If


            createAutoList()



            loadFromXMLFile(IO.Path.Combine(appFolder, "settings.xml"))

            shadow.MakeTransparent(Color.Black)
            Weapon = New class_weapon
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            If recentFiles.Count > 0 And recentFileWasChanged Then
                saveRecentFiles()
            End If
        End Sub




        Private Sub createAutoList()
            Dim input As String = "aaction:
act:
action:
arest:
attacking:
backhurtact:
bdefend:
bound:
c1:
c2:
catchingact:
caughtact:
cc:
centery:
col:
cover:
dvx:
dvy:
dvz:
centerx:
dash_height
dash_distance
dash_distancez
decrease:
dircontrol:
entry:
fall:
facing:
file:
fronthurtact:
head:
heavy_running_speed
heavy_running_speedz
heavy_walking_speed
heavy_walking_speedz
height:
hit_a:
hit_d:
hit_j:
hit_Da:
hit_Dj:
hit_Fa:
hit_Fj:
hit_ja:
hit_Ua:
hit_Uj:
hp:
hurtable:
id:
injury:
jaction:
join:
jump_height
jump_distance
jump_distancez
kind:
loop:
mp:
name:
music:
next:
oid:
pic:
ratio:
rect:
reserve:
running_frame_rate
running_speed
running_speedz
row:
rowing_height
rowing_distance
shadow:
shadowsize:
small:
sound:
state:
taction:
transparency:
times:
throwinjury:
throwvx:
throwvy:
throwvz:
vaction:
vrest:
wait:
walking_frame_rate
walking_speed
walking_speedz
weaponact:
weapon_broken_sound:
weapon_drop_sound:
weapon_drop_hurt:
weapon_hit_sound:
weapon_hp:
width:
zboundary:
zwidth:
<bmp_begin>
<bmp_end>
<end>
<frame>
<frame_end>
<phase>
<phase_end>
<stage>
<stage_end>
<weapon_strength_list>
<weapon_strength_list_end>
bdy:
bdy_end:
bpoint:
bpoint_end:
cpoint:
cpoint_end:
itr:
itr_end:
layer:
layer_end
opoint:
opoint_end:
wpoint:
wpoint_end:
<soldier>
<boss>
effect:"

            For Each line As String In Split(input, ControlChars.Lf)
                line = line.Trim
                If Not String.IsNullOrWhiteSpace(line) Then
                    If line.Length > 2 Then
                        If Not listOfAutoItems.Contains(line) Then
                            listOfAutoItems.Add(line)
                        End If
                    End If
                End If
            Next
        End Sub
    End Class
End Namespace
