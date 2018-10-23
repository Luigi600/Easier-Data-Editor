'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> custom Comparer for listview items (used by: error items and "unused frames") </summary>

Public Class class_ListViewItemComparer
    Implements IComparer

    Public col As Integer = 0
    Public reverse As Boolean = True

    Public Sub New(column As Integer)
        col = column
    End Sub


    Public Function Compare(xx As Object, yy As Object) As Integer Implements IComparer.Compare
        Dim x As String = CType(xx, ListViewItem).SubItems(col).Text
        Dim y As String = CType(yy, ListViewItem).SubItems(col).Text

        Dim returnVal As Integer = -1

        If col = 0 Then
            returnVal = CType(x, Integer).CompareTo(CType(y, Integer))
        Else
            returnVal = x.CompareTo(y)
            'ElseIf col = 3 Then
            '    Dim xSplit() As String = Split(x, "/")
            '    Dim ySplit() As String = Split(y, "/")
            '    If xSplit.Count = 2 And ySplit.Count = 2 Then
            '        Dim xFloat As Double = Convert.ToDouble(xSplit(0), cultureEN)
            '        Dim yFloat As Double = Convert.ToDouble(ySplit(0), cultureEN)
            '        returnVal = xFloat.CompareTo(yFloat)
            '    End If

            'ElseIf col = 5 Then
            '    returnVal = Convert.ToDateTime(x, cultureEN).CompareTo(Convert.ToDateTime(y, cultureEN))
        End If

        If reverse Then
            returnVal *= -1
        End If
        Return returnVal
    End Function
End Class
