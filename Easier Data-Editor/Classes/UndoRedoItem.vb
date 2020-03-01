'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents an undo/redo item. Contains information of undo/redo, to handle of undos/redos.</summary>
Public Class UndoRedoItem
    Implements ICloneable

    Public Enum EEvent
        MirroredFrame
    End Enum

    Public ReadOnly StackIndex As Integer = -1
    Public ReadOnly [Event] As EEvent
    Public ReadOnly FrameIndex As Integer = -1
    Public IsUndo As Boolean = True

    Public Sub New(ByVal stackIndex As Integer, ByVal [event] As EEvent, ByVal frameIndex As Integer)
        Me.StackIndex = stackIndex
        Me.Event = [event]
        Me.FrameIndex = frameIndex
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim result As UndoRedoItem = MemberwiseClone()
        result.IsUndo = Not result.IsUndo
        Return result
    End Function
End Class