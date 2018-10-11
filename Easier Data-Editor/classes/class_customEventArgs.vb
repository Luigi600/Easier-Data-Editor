Public Class class_customEventArgs
    Inherits EventArgs

    Public ReadOnly Property [Object] As Object
    Public ReadOnly Property Object2 As Object
    Public Sub New(ByVal obj As Object, Optional ByVal obj2 As Object = Nothing)
        [Object] = obj
        Object2 = obj2
    End Sub
End Class
