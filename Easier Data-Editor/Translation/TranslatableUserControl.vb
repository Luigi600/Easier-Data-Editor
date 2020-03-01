'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.ComponentModel

Namespace Translation
    ''' <summary>Represents a translatable Windows.UserControl.</summary>
    Public Class TranslatableUserControl
        Inherits UserControl
        Implements IDisposable, ITranslatable

        Private m_created As Boolean = False

        Public ReadOnly Property NotTranslatableControls As New List(Of Component) Implements ITranslatable.NotTranslatableControls
        Public ReadOnly Property Variables As New Dictionary(Of String, String) Implements ITranslatable.Variables

        Public Sub New()
            MyBase.New()

            If Not DesignMode Then
                GlobalStuff.TranslatableForms.Add(Me)
            End If
        End Sub

        Public Overloads Sub ResumeLayout(ByVal bool As Boolean)
            MyBase.ResumeLayout(bool)

            If Not DesignMode AndAlso Not bool AndAlso Not m_created Then
                m_created = True

                SetNotTranslatableThings()
                AddToDefaultLanguage(Me)
                GlobalStuff.Translate(Languages(SelectedLanguage), Me)
            End If
        End Sub

        Protected Overridable Sub SetNotTranslatableThings()
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                GlobalStuff.TranslatableForms.Remove(Me)
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub

        Public Function GetTranslatableHeader() As String Implements ITranslatable.GetTranslatableHeader
            Return ""
        End Function

        Public Sub Translate(ByVal language As Language) Implements ITranslatable.Translate
            GlobalStuff.Translate(language, Me)
        End Sub

        Protected Function GetVariable(ByVal name As String) As String
            If Variables.ContainsKey(name) Then
                Return Variables(name)
            End If
            Return "Variable not found!"
        End Function
    End Class
End Namespace