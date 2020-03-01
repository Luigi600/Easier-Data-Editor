'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents a SortedSet with events.</summary>
''' <typeparam name="T">The type of the items.</typeparam>
Public Class SortedSetWithEvents(Of T)
    Inherits SortedSet(Of T)
    Implements ICloneable

    Public Event ItemAdd As EventHandler(Of T)
    Public Event ItemAdded As EventHandler(Of T)
    Public Event ItemRemove As EventHandler(Of T)
    Public Event ItemRemoved As EventHandler(Of T)

    Public Event ItemsCleared As EventHandler(Of Boolean)

    Public Sub AddRange(ByVal val As SortedSetWithEvents(Of T))
        For Each valL As T In val
            MyBase.Add(valL)
        Next
    End Sub

    ''' <inheritdoc />
    Public Shadows Function Add(ByVal val As T) As Boolean
        RaiseEvent ItemAdd(Me, val)
        Dim result As Boolean = MyBase.Add(val)
        If result Then
            RaiseEvent ItemAdded(Me, val)
        End If
        Return result
    End Function

    ''' <inheritdoc />
    Public Shadows Function Remove(ByVal val As T) As Boolean
        RaiseEvent ItemRemove(Me, val)
        Dim result As Boolean = MyBase.Remove(val)
        If result Then
            RaiseEvent ItemRemoved(Me, val)
        End If
        Return result
    End Function

    ''' <inheritdoc />
    Public Shadows Sub Clear()
        Dim oldLen As Integer = Count
        MyBase.Clear()
        If Count <> oldLen Then
            RaiseEvent ItemsCleared(Me, True)
        End If
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Return MyBase.MemberwiseClone()
    End Function
End Class