'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents the ComboBoxItem which contains a value and a custom display text.</summary>
''' <typeparam name="T">The type of value.</typeparam>
Public Class CustomComboBoxItem(Of T)
    Public ReadOnly DisplayText As String = ""
    Public ReadOnly Value As T = Nothing

    Public Sub New(ByVal displayText As String, ByVal value As T)
        If Not String.IsNullOrEmpty(displayText) Then
            Me.DisplayText = displayText
        End If

        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        Return DisplayText
    End Function
End Class