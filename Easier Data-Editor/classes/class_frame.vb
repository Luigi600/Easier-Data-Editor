Public Class class_frame
    Public ID As Integer = -1
    Public Offset As Long = -1
    Public Length As Long = -1
    Public Lines As String = ""

    Public OffsetBPoint As New Point(-1, -1)
    Public OffsetWPoint As New Point(-1, -1)
    Public OffsetCPoint As New Point(-1, -1)
    Public OffsetOPoint As New Point(-1, -1)

    Public OffsetBodies As New List(Of Point)
    Public OffsetItrs As New List(Of Point)


    Public Overrides Function ToString() As String
        Return Offset & " - " & Length
    End Function
End Class
