Public Class OffsetRect
    Inherits Offset

    Public Property W_Offset As New Point(-1, -1)
    Public Property H_Offset As New Point(-1, -1)

    Public Sub New(ByVal frameOffset As Integer, ByVal offset As Integer, ByVal length As Integer, ByVal frameText As String)
        MyBase.New(frameOffset, offset, length, frameText)

        Dim rng As String = frameText.Substring(offset, length)

    End Sub
End Class