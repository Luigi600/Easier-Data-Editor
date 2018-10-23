'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Interface for UserControl "ui_frameViewer" </summary>

Public Interface IFrameViewer
    Function getTextEditor() As ITextEditor
    Property hasFocus As Boolean
End Interface
