'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Namespace Tools
    ''' <summary>Represents a clone of a regex match.</summary>
    Public Class RegexMatchCloner
        Public ReadOnly Index As Integer = 0
        Public [End] As Integer = -1
        Public ReadOnly Value As String = ""

        Public Sub New(ByVal index As Integer, ByVal [end] As Integer, ByVal val As String)
            Me.Index = index
            Me.End = [end]
            Value = val
        End Sub
    End Class
End Namespace