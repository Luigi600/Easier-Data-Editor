'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Error Item: to restore message, offset and line </summary>

''' <summary>Represents an error of the LF2 document (wrong syntax etc.).</summary>
Public Class ErrorItem
    Implements ICloneable

    Public ReadOnly Message As String = ""
    Public ReadOnly Offset As Integer = -1
    Public ReadOnly EndOffset As Integer = -1
    Public ReadOnly Line As Integer = -1
    Public ReadOnly File As String = ""

    Public Sub New(ByVal message As String, ByVal offset As Integer, ByVal endOffset As Integer, ByVal line As Integer, ByVal file As String)
        If Not String.IsNullOrEmpty(message) Then
            Me.Message = message
        End If

        Me.Offset = offset
        Me.EndOffset = endOffset
        Me.Line = line

        If Not String.IsNullOrEmpty(file) Then
            Me.File = file
        End If
    End Sub

    Public Overloads Function Equals(ByVal check As ErrorItem) As Boolean
        If Not IsNothing(check) Then
            If Not Offset = check.Offset Then Return False
            If Not Line = check.Line Then Return False
            If Not File.Equals(check.File) Then Return False
            Return True
        End If

        Return False
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return MyBase.MemberwiseClone
    End Function
End Class