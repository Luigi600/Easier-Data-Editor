'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents information about not used ID(s) of LF2 document.</summary>
Public Class UnusedIDItem
    Implements ICloneable

    Public ReadOnly ID As Integer = -1
    Public ReadOnly Range As Integer = 1
    Public ReadOnly Line As Integer = 0

    Public Sub New(ByVal id As Integer, ByVal range As Integer, ByVal line As Integer)
        Me.ID = id
        Me.Range = range
        Me.Line = line
    End Sub

    Public Overloads Function Equals(ByVal check As UnusedIDItem) As Boolean
        If Not IsNothing(check) Then
            If Not ID = check.ID Then Return False
            If Not Line = check.Line Then Return False
            If Not Range.Equals(check.Range) Then Return False
            Return True
        End If

        Return False
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return MyBase.MemberwiseClone
    End Function
End Class