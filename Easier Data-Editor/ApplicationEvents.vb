'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

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
            If Not IO.Directory.Exists(AppFolder) Then
                IO.Directory.CreateDirectory(AppFolder)
            End If

            If IO.Directory.Exists(LanguageDirectory) Then
                SetLanguageCheckerEvents()
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
                                SingleInstance.SendMessage(found_pro.MainWindowHandle, SingleInstance.WM_SETTEXT, 0, arg)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Exit Sub
                End If
            End If



            If IO.File.Exists(IO.Path.Combine(AppFolder, "syntax.xml")) Then
                Try
                    CustomSyntax = New Syntax(IO.File.ReadAllText(IO.Path.Combine(AppFolder, "syntax.xml")))
                Catch ex As Exception
                End Try
            End If

            TextEditor.Prepare()
            FrameViewer.Prepare()
            App.SearchWindow.Prepare()
            SetDebug()


            'Dim test As New Translation.Creator("English", "Luigi600")
            'Dim txt As New TextEditor("", True)
            'test.GetXMLFromWindow(New SettingsF)
            'test.GetXMLFromUserControl(New UC_FrameViewer(App.Settings))
            'test.GetXMLFromUserControl(New UC_General(App.Settings))
            'test.GetXMLFromUserControl(New UC_TextEditor(App.Settings))

            'test.GetXMLFromWindow(New About)
            'test.GetXMLFromWindow(New AutoIDChanger(txt))
            'test.GetXMLFromWindow(New ErrorList)
            'test.GetXMLFromWindow(New FindReplaceMark)
            'test.GetXMLFromWindow(New FrameSorter(New List(Of TextEditor) From {txt}, 0))
            'test.GetXMLFromWindow(New FramesReformatting(New List(Of TextEditor) From {txt}))
            'test.GetXMLFromWindow(txt.Viewer)
            'test.GetXMLFromWindow(New GoToWindow)
            'test.GetXMLFromWindow(New TagAdder(txt))
            'test.GetXMLFromWindow(txt)
            'test.GetXMLFromWindow(New UnusedIDs)

            'test.GetXMLFromWindow(New Main)

            'test.Close(IO.Path.Combine(AppFolder, "languages", "autoCreation_5.xml"))
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            App.Settings.Close()
        End Sub


        Dim lastError As New Date
        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MessageBox.Show(MainForm, "Exception!" & vbNewLine & e.Exception.ToString, "Easier Data-Editor (STM93 Version) - Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.ExitApplication = Not (Date.Now - lastError).TotalSeconds > 5.0
            If e.ExitApplication And TypeOf (MainForm) Is Main Then
                CType(MainForm, Main).CloseException()
            End If

            lastError = Date.Now
        End Sub

        Public Sub SetLanguageCheckerEvents()
            App.LanguageChecker = New IO.FileSystemWatcher With {
                .Path = LanguageDirectory,
                .Filter = "*.xml",
                .EnableRaisingEvents = True,
                .NotifyFilter = IO.NotifyFilters.FileName Or IO.NotifyFilters.LastWrite Or IO.NotifyFilters.Size Or IO.NotifyFilters.CreationTime
            }
            AddHandler App.LanguageChecker.Renamed, AddressOf LanguageChecker
            AddHandler App.LanguageChecker.Changed, AddressOf LanguageChecker
            AddHandler App.LanguageChecker.Created, AddressOf LanguageChecker
            AddHandler App.LanguageChecker.Deleted, AddressOf LanguageChecker
            'AddHandler App.LanguageChecker.Error, AddressOf LanguageChecker
        End Sub

        Private Sub LanguageChecker(sender As Object, e As IO.FileSystemEventArgs)
            If TypeOf MainForm Is Main Then
                CType(MainForm, Main).ChangeLanguages(e)
            End If

            'Dim currentLang As String = Translation.Languages(Translation.SelectedLanguage).FileName

            'If e.ChangeType = WatcherChangeTypes.Created Then
            '    For Each file As String In IO.Directory.GetFiles(langDir).Where(Function(x) IO.Path.GetExtension(x).ToLower.Equals(".xml")).ToList
            '        Try
            '            Languages.Add(New Language(file))
            '        Catch ex As Exception
            '        End Try
            '    Next
            'End If
        End Sub
    End Class
End Namespace