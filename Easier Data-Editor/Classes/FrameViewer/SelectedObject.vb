'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports Easier_Data_Editor.LittleFighter

''' <summary>Represents a selected object of the Frame Viewer.</summary>
''' <todo>Encapsulation of the members/properties.</todo>
Public Class SelectedObject
    Implements ICloneable

    Public [Object] As EFrameChangeType = -1
    Public Index As Integer = -1 'only for bodies and itrs
    Public Position As ESelectedPosition = ESelectedPosition.Center
    Public RelativPosition As New Point
    Public RelativPosition2 As New Point 'just for bodies and itrs

    Public Function Clone() As Object Implements ICloneable.Clone
        Return MyBase.MemberwiseClone()
    End Function
End Class