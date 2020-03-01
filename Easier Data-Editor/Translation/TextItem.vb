'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Namespace Translation
    ''' <summary>Represents a translatable control/node, parsed from XML.</summary>
    Public Class TextItem
        Public ReadOnly Name As String
        Public ReadOnly Value As Object
        Public ReadOnly Type As String
        Public ReadOnly Meta As String = ""

        Public Sub New(ByVal name As String, ByVal value As Object, ByVal type As String, Optional ByVal meta As String = "")
            Me.Name = name
            Me.Value = value
            Me.Type = type
            Me.Meta = meta
        End Sub

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is Item Then
                Return CType(obj, Item).Equals(Me)
            End If

            Return MyBase.Equals(obj)
        End Function
    End Class
End Namespace