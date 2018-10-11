<Serializable>
Public Class class_bitmapFile
    Implements ICloneable

    Public Path As String = ""
    Public IndexStart As Integer = 0
    Public IndexEnd As Integer = 69
    Public Width As Integer = 79
    Public Height As Integer = 79
    Public Row As Integer = 10
    Public Col As Integer = 7

    Public Function Clone() As Object Implements ICloneable.Clone
        Return MyBase.MemberwiseClone
    End Function

    Public Shadows Function Equals(Of T As class_bitmapFile)(ByVal check As T) As Boolean
        If Not IsNothing(check) Then
            If Not Path.Equals(check.Path) Then Return False
            If Not IndexStart = check.IndexStart Then Return False
            If Not IndexEnd = check.IndexEnd Then Return False
            If Not Width = check.Width Then Return False
            If Not Height = check.Height Then Return False
            If Not Row = check.Row Then Return False
            If Not Col = check.Col Then Return False

            Return True
        End If

        Return False
    End Function
End Class