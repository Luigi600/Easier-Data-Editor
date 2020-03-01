'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Namespace LittleFighter
    ''' <summary>Represents the information about a spritesheet, like the bitmap header in LF2.</summary>
    ''' <remarks>LF2 ignores the information inside of the brackets of "file". Its determines the range with row and col information.
    ''' Example by STM93 (Thanks!!!):
    ''' <code>
    ''' file(12-123):  sprite_1.bmp   row: 10 col: 7
    ''' file(0-99):    sprite_0.bmp   row: 5 col: 14
    ''' file(999-453): sprite_2.bmp   row: 3 col: 2
    ''' </code>
    ''' LF2 parses than:
    ''' <code>
    ''' file(0-69):    sprite_1.bmp   row: 10 col: 7
    ''' file(70-139):  sprite_0.bmp   row: 5 col: 14
    ''' file(140-145): sprite_2.bmp   row: 3 col: 2
    ''' </code>
    ''' </remarks>
    ''' <note>WHY Serializable?!</note>
    <Serializable>
    Public Class FrameHeader
        Implements ICloneable

        Public ReadOnly Path As String = ""
        Public ReadOnly Width As UInteger = 79
        Public ReadOnly Height As UInteger = 79
        Public ReadOnly Row As UInteger = 10
        Public ReadOnly Col As UInteger = 7

        Public ReadOnly Property IndexS As Integer = 0
        Public ReadOnly Property IndexE As Integer
            Get
                Return IndexS + Count - 1
            End Get
        End Property
        Public ReadOnly Property Count As Integer
            Get
                Return Row * Col
            End Get
        End Property

        Public Sub New(ByVal path As String, ByVal width As UInteger, ByVal height As UInteger, ByVal row As UInteger, ByVal col As UInteger, ByVal lastLength As Integer)
            Me.Path = path
            Me.Width = width
            Me.Height = height
            Me.Row = row
            Me.Col = col
            Me.IndexS = lastLength
        End Sub

        Public Function Clone() As Object Implements ICloneable.Clone
            Return MyBase.MemberwiseClone
        End Function

        Public Shadows Function Equals(Of T As FrameHeader)(ByVal check As T) As Boolean
            If Not IsNothing(check) Then
                If Not Path.Equals(check.Path) Then Return False
                If Not Width = check.Width Then Return False
                If Not Height = check.Height Then Return False
                If Not Row = check.Row Then Return False
                If Not Col = check.Col Then Return False

                Return True
            End If

            Return False
        End Function
    End Class
End Namespace