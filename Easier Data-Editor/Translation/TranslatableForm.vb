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
    ''' <summary>Represents a translatable Windows.Form.</summary>
    Public Class TranslatableForm
        Inherits Form
        Implements IDisposable, ITranslatable

        Private m_created As Boolean = False
        Private m_notTranslatablePrefix As String = ""
        Private m_originalText As String = ""

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

        Protected Property NotTranslatablePrefix As String
            Get
                Return m_notTranslatablePrefix
            End Get
            Set(value As String)
                If Not IsNothing(value) Then
                    m_notTranslatablePrefix = value
                    If Not DesignMode Then
                        MyBase.Text = m_originalText
                    End If
                End If
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                m_originalText = value
                MyBase.Text = GetTitle()
            End Set
        End Property

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
            Return m_originalText
        End Function

        Public Sub Translate(ByVal language As Language) Implements ITranslatable.Translate
            GlobalStuff.Translate(language, Me)
        End Sub

        Private Function GetTitle() As String
            Dim result As String = ""
            If Not String.IsNullOrEmpty(m_notTranslatablePrefix) Then
                result = m_notTranslatablePrefix

                If Not String.IsNullOrEmpty(m_originalText) Then
                    result &= " - "
                End If
            End If
            Return result & m_originalText
        End Function

        Protected Function GetVariable(ByVal name As String) As String
            If Variables.ContainsKey(name) Then
                Return Variables(name)
            End If
            Return "Variable not found!"
        End Function
    End Class
End Namespace