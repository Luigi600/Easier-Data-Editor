Public Class ErrorItem
    Implements ICloneable

    Public Message As String = ""
    Public Offset As Integer = -1
    Public Line As Integer = -1
    Public File As String = ""

    Public Shadows Function Equals(Of T As ErrorItem)(ByVal check As T) As Boolean
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