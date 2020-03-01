Public Class Offset
    Dim m_offset As Integer = -1
    Dim m_endOffset As Integer = -1

    Public Property X_Offset As New Point(-1, -1)
    Public Property Y_Offset As New Point(-1, -1)

    Public Property Offset As Integer
        Get
            Return m_offset
        End Get
        Set(value As Integer)
            If value >= 0 Then
                m_offset = value 'DONT CHECK IF OFFSET > ENDOFFSET
            End If
        End Set
    End Property

    Public Property EndOffset As Integer
        Get
            Return m_endOffset
        End Get
        Set(value As Integer)
            If value >= m_endOffset Then
                m_endOffset = value 'PERHAPS CHECK IF ENDOFFSET < OFFSET
            End If
        End Set
    End Property

    Protected Sub New()
    End Sub

    Public Sub New(ByVal frameOffset As Integer, ByVal offset As Integer, ByVal length As Integer, ByVal frameText As String)
        Dim rng As String = frameText.Substring(offset, length)

    End Sub
End Class