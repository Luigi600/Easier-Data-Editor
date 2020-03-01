'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

''' <summary>Contains different regex patterns and other stuff which are public for the project.</summary>
Friend Module GlobalConsts
#Region "'Consts'"
    Friend ReadOnly PATTERN_BDY As String = GetPattern("bdy")
    Friend ReadOnly PATTERN_ITR As String = GetPattern("itr")
    Friend ReadOnly PATTERN_BPOINT As String = GetPattern("bpoint")
    Friend ReadOnly PATTERN_WPOINT As String = GetPattern("wpoint")
    Friend ReadOnly PATTERN_CPOINT As String = GetPattern("cpoint")
    Friend ReadOnly PATTERN_OPOINT As String = GetPattern("opoint")
#End Region

    Friend Const PATTERN_FRAME_CONTENT As String = "\<frame\>.*?\<frame_end\>"
    Friend Const PATTERN_FRAME_ID As String = "(?<=\<frame\>\s*)[0-9]+" 'or just \d+

    Friend Function GetPattern(ByVal searchAt As String) As String
        Return "(?<=" & searchAt & ":[\s\r\n]*)[^\s]+.*?(?=[\s\r\n]+" & searchAt & "_end:)"
    End Function
End Module