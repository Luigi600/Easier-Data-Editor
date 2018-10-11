Public Class SearchItem
    Public SearchName As String = ""
    Public SearchReplace As String = ""
    Public LastOffset As Integer = -1

    Public Shadows Function Equals(obj As SearchItem) As Boolean
        If Not IsNothing(obj) Then
            If Not SearchName.Equals(obj.SearchName) Then Return False
            If Not SearchReplace.Equals(obj.SearchReplace) Then Return False
            Return True
        End If
        Return False
    End Function
End Class
