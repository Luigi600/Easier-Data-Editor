'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Reflection

Namespace Translation
    ''' <summary>Represents a translatable item/node (object) while runtime.</summary>
    Public Class Item
        Public ReadOnly [Object] As Object
        Public ReadOnly Name As String
        Public ReadOnly Text As String
        Public ReadOnly Meta As String = ""

        Public Sub New(ByVal obj As Object)
            Dim propInfoName As PropertyInfo = obj.GetType().GetProperty("Name")
            Dim propInfoText As PropertyInfo = obj.GetType().GetProperty("Text")
            If Not IsNothing(propInfoName) And Not IsNothing(propInfoText) Then
                Me.Object = obj
                Me.Name = propInfoName.GetValue(obj)
                Me.Text = propInfoText.GetValue(obj)
            Else
                Throw New InvalidCastException
            End If

            If TypeOf obj Is ToolStripItem Then
                Meta = CType(obj, ToolStripItem).ToolTipText
            End If
        End Sub

        Public Function ToTextItem() As TextItem
            Return New TextItem(Name, Text, Me.Object.GetType().Name, Meta)
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is TextItem Then
                Dim textItem As TextItem = obj
                If textItem.Type.Equals(Me.Object.GetType().Name) AndAlso textItem.Name.Equals(Name) Then
                    Return True
                End If
            End If

            Return MyBase.Equals(obj)
        End Function
    End Class
End Namespace