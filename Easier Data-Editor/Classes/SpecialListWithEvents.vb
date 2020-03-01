'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents a <codeInline>List</codeInline> with events.</summary>
''' <typeparam name="T">The type of elements in the list. Without bounds.</typeparam>
Public Class SpecialListWithEvents(Of T)
    Inherits List(Of T)

    ''' <summary>Event before an item will be added to list. Triggered by "Add".</summary>
    Public Event ItemAdd As EventHandler(Of T)
    ''' <summary>Event after an item is added to list. Triggered by "Add".</summary>
    Public Event ItemAdded As EventHandler(Of T)

    ''' <summary>Event before items will be added to list. Triggered by "AddRange".</summary>
    Public Event ItemsAdd As EventHandler(Of IEnumerable(Of T))
    ''' <summary>Event after items are added to list. Triggered by "AddRange".</summary>
    Public Event ItemsAdded As EventHandler(Of IEnumerable(Of T))

    ''' <summary>Event before an item will be removed from the list. Triggered by "Remove" and "RemoveAt".</summary>
    Public Event ItemRemove As EventHandler(Of T)
    ''' <summary>Event after an item is removed from the list. Triggered by "Remove" and "RemoveAt".</summary>
    Public Event ItemRemoved As EventHandler(Of T)

    ''' <include file="Documentation\Main.xml" path="Parts/summary[@id='itemsClear']" />
    Public Event ItemsClear As EventHandler(Of T)
    ''' <include file="Documentation\Main.xml" path="Parts/summary[@id='itemsCleared']" />
    Public Event ItemsCleared As EventHandler(Of T)

    ''' <include file="Documentation\Main.xml" path="Parts/summary[@id='raiseEvents']" />
    Public RasieEvents As Boolean = True 'false = NONE raiseEvent

    Private m_capacity As Integer = 20
    Public Overloads Property Capacity As Integer
        Get
            Return m_capacity
        End Get
        Set(value As Integer)
            If value >= 0 And value < m_capacity Then
                Do While Count > value
                    RemoveAt(Count - 1)
                Loop
            End If

            m_capacity = value
        End Set
    End Property

    ''' <summary>Adds an object to the end of the List and triggers events, if RasieEvents on true.</summary>
    ''' <param name="item">The object to be added to the end of the List. The value can be null for reference types.</param>
    Public Overloads Sub Add(ByVal item As T)
        If RasieEvents Then RaiseEvent ItemAdd(Me, item)
        If Contains(item) Then Remove(item) 'remove old item and add at position 0
        MyBase.Insert(0, item)
        If Capacity >= 0 Then
            Do While Count > Capacity
                RemoveAt(Count - 1)
            Loop
        End If
        If RasieEvents Then RaiseEvent ItemAdded(Me, item)
    End Sub

    ''' <summary>Adds the elements of the specified collection to the end of the List and triggers events, if RasieEvents on true.</summary>
    ''' <param name="items">The collection whose elements should be added to the end of the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
    Public Overloads Sub AddRange(ByVal items As IEnumerable(Of T))
        If RasieEvents Then RaiseEvent ItemsAdd(Me, items)
        MyBase.AddRange(items)
        If RasieEvents Then RaiseEvent ItemsAdded(Me, items)
    End Sub

    ''' <summary>Removes the first occurrence of a specific object from the List and triggers events, if RasieEvents on true.</summary>
    ''' <param name="item">The object to remove from the List. The value can be null for reference types.</param>
    Public Overloads Sub Remove(ByVal item As T)
        If RasieEvents Then RaiseEvent ItemRemove(Me, item)
        MyBase.Remove(item)
        If RasieEvents Then RaiseEvent ItemRemoved(Me, item)
    End Sub

    ''' <summary>Removes the element at the specified index of the List and triggers events, if RasieEvents on true.</summary>
    ''' <param name="index">The zero-based index of the element to remove.</param>
    Public Overloads Sub RemoveAt(ByVal index As Integer)
        If index < Count Then
            Dim item As T = Me(index)
            If RasieEvents Then RaiseEvent ItemRemove(Me, item)
            MyBase.RemoveAt(index)
            If RasieEvents Then RaiseEvent ItemRemoved(Me, item)
        End If
    End Sub

    ''' <summary>Removes a range of elements from the List and triggers events, if RasieEvents on true. <b>Important:</b> this function calls RemoveAt(int index). So it triggers <paramref name="counter"/> times one/two events.</summary>
    ''' <param name="index">The zero-based starting index of the range of elements to remove.</param>
    ''' <param name="counter">The number of elements to remove.</param>
    ''' <exception cref="ArgumentOutOfRangeException">
    ''' index is less than 0. <br />-or-<br />
    ''' count is less than 0.
    ''' </exception>
    ''' <exception cref="ArgumentException">index and count do not denote a valid range of elements in the List.</exception>
    Public Overloads Sub RemoveRange(ByVal index As Integer, ByVal counter As Integer)
        Do While index < Count And counter > 0
            RemoveAt(index)
            counter -= 1
        Loop
    End Sub

    ''' <summary>Removes all elements from the List and triggers events, if RasieEvents on true.</summary>
    Public Overloads Sub Clear()
        If RasieEvents Then RaiseEvent ItemsClear(Me, Nothing)
        MyBase.Clear()
        If RasieEvents Then RaiseEvent ItemsCleared(Me, Nothing)
    End Sub
End Class