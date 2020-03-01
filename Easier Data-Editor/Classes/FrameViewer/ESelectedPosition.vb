'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Represents a position (edge, center, etc.) of a selected object of the Frame Viewer.</summary>
''' <todo>Replace with values to do byte operations, to short code.  (Removing LeftTop, RightTop etc.; see "Easier.LF-Editor.Global")</todo>
Public Enum ESelectedPosition As Byte
    LeftTop
    Top
    RightTop
    Left
    Center
    Right
    LeftBottom
    Bottom
    RightBottom
    ItrZWidthBottom
    ItrZWidthTop
End Enum