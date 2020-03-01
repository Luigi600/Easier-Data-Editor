'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Text.RegularExpressions

Namespace LittleFighter
    ''' <summary>Represents a simple weapon like in LF2.</summary>
    ''' <todo>Better regex pattern and make all pattern than static variable.</todo>
    Public Class Weapon
        Public ReadOnly DataPath As String = ""
        Public ReadOnly SpritePath As String = ""
        Public ReadOnly Frames As New Dictionary(Of Integer, Frame)

        Public Sub New(Optional ByVal isHeavy As Boolean = False)
            Dim fileContent As String

            If Not isHeavy Then
                If IO.File.Exists(App.Settings.WeaponData) Then
                    fileContent = DecryptFromData(App.Settings.WeaponData)
                    DataPath = App.Settings.WeaponData
                Else
                    fileContent = My.Resources.weapon_normal
                End If
            Else
                If IO.File.Exists(App.Settings.HeavyWeaponData) Then
                    fileContent = DecryptFromData(App.Settings.HeavyWeaponData)
                    DataPath = App.Settings.HeavyWeaponData
                Else
                    fileContent = My.Resources.weapon_heavy
                End If
            End If

            Parser(fileContent)

            Dim w As Integer = 48
            Dim h As Integer = 48
            Dim r As Integer = 10
            Dim c As Integer = 10


            Dim weaponImg As Bitmap = Nothing
            If isHeavy Then
                w = 58
                h = 58
                r = 10
                c = 1
                If IO.File.Exists(App.Settings.HeavyWeaponSprite) Then
                    weaponImg = New Bitmap(App.Settings.HeavyWeaponSprite)
                    SpritePath = App.Settings.HeavyWeaponSprite

                    Parsing(fileContent, w, h, r, c)
                Else
                    weaponImg = My.Resources.weapon1
                End If
            Else
                If IO.File.Exists(App.Settings.WeaponSprite) Then
                    weaponImg = New Bitmap(App.Settings.WeaponSprite)
                    SpritePath = App.Settings.WeaponSprite

                    Parsing(fileContent, w, h, r, c)
                Else
                    weaponImg = My.Resources.weapon0
                End If
            End If

            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim startImageIndex As Integer = 0

            weaponImg.MakeTransparent(Color.Black)
            Do While True
                Dim frames As List(Of Frame) = GetFrameWithPicID(startImageIndex)
                If frames.Count > 0 Then
                    Dim imageClone As New Bitmap(w, h)
                    Dim grap As Graphics = Graphics.FromImage(imageClone)
                    grap.DrawImage(weaponImg, New Rectangle(0, 0, w, h), New Rectangle(x * (w + 1), y * (h + 1), imageClone.Width, imageClone.Height), GraphicsUnit.Pixel)
                    imageClone.MakeTransparent(Color.Black)

                    For Each frame As Frame In frames
                        frame.Image = imageClone.Clone
                    Next
                    'If Not isHeavy Then
                    '    imageClone.Save("imgs\" & x & "x" & y & ".png", Imaging.ImageFormat.Png)
                    'End If
                    grap.Dispose()
                    imageClone.Dispose() 'da ein klone weitergegeben wird, da sonst ein fehler auftritt (er übernimmt sonst einfach das bild...)
                End If

                x += 1
                startImageIndex += 1
                If startImageIndex = (r * c) Then
                    Exit Do
                End If
                If x >= r Then
                    x = 0
                    y += 1
                End If
                If y >= c Then
                    Exit Do
                End If
            Loop
            weaponImg.Dispose()
        End Sub

        Private Sub Parsing(ByVal content As String, ByRef w As Integer, ByRef h As Integer, ByRef r As Integer, ByRef c As Integer)
            If content.Length > 10 Then
                w = GetRegexValueInteger(content, "(?<=(^w|\s+w):\s*)[0-9]+", RegexOptions.IgnoreCase, w)
                h = GetRegexValueInteger(content, "(?<=(^h|\s+h):\s*)[0-9]+", RegexOptions.IgnoreCase, h)
                r = GetRegexValueInteger(content, "(?<=(^row|\s+row):\s*)[0-9]+", RegexOptions.IgnoreCase, r)
                c = GetRegexValueInteger(content, "(?<=(^col|\s+col):\s*)[0-9]+", RegexOptions.IgnoreCase, c)
            End If
        End Sub

        Private Function GetFrameWithPicID(ByVal ID As Integer) As List(Of Frame)
            Dim result As New List(Of Frame)
            For Each frame As Frame In Frames.Values
                If frame.PicID = ID Then
                    result.Add(frame)
                End If
            Next
            Return result
        End Function

        Private Sub Parser(ByVal content As String)
            For Each frameMatch As Match In Regex.Matches(content, "<frame>.*?<frame_end>", RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Singleline)
                If frameMatch.Success Then
                    Dim LFFrame As New Frame
                    Dim frameCode As String = frameMatch.Value
                    SetFrameIfSuccess(LFFrame.ID, frameCode, "(?<=<frame>\s+)[0-9]+")

                    Dim itrs As MatchCollection = Regex.Matches(frameCode, "itr:[^_]+itr_end:", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                    For Each itr As Match In itrs
                        If itr.Success Then
                            Dim ir As New Itr
                            SetFrameIfSuccess(ir.Kind, itr.Value, "(?<=(\s+kind|^kind):\s*)[0-9]+")
                            SetFrameIfSuccess(ir.Rect.X, itr.Value, "(?<=(\s+x|^x):\s*)[0-9-]+")
                            SetFrameIfSuccess(ir.Rect.Y, itr.Value, "(?<=(\s+y|^y):\s*)[0-9-]+")
                            SetFrameIfSuccess(ir.Rect.Width, itr.Value, "(?<=(\s+w|^w):\s*)[0-9]+")
                            SetFrameIfSuccess(ir.Rect.Height, itr.Value, "(?<=(\s+h|^h):\s*)[0-9]+")
                            LFFrame.Itrs.Add(ir)
                        End If
                    Next

                    Dim wpointMatch As Match = Regex.Match(frameCode, "wpoint:[^_]+wpoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                    If wpointMatch.Success Then
                        LFFrame.WPoint = New WPoint
                        SetFrameIfSuccess(LFFrame.WPoint.Kind, wpointMatch.Value, "(?<=(\s+kind|^kind):\s*)[0-9]+")
                        SetFrameIfSuccess(LFFrame.WPoint.Loca.X, wpointMatch.Value, "(?<=(\s+x|^x):\s*)[0-9-]+")
                        SetFrameIfSuccess(LFFrame.WPoint.Loca.Y, wpointMatch.Value, "(?<=(\s+y|^y):\s*)[0-9-]+")

                        SetFrameIfSuccess(LFFrame.WPoint.Cover, wpointMatch.Value, "(?<=(\s+cover|^cover):\s*)[0-9]+")
                    End If

                    SetFrameIfSuccess(LFFrame.PicID, frameCode, "(?<=(\s+pic|^pic):\s*)[0-9]+")
                    SetFrameIfSuccess(LFFrame.Center.X, frameCode, "(?<=(\s+centerx|^centerx):\s*)[-0-9]+")
                    SetFrameIfSuccess(LFFrame.Center.Y, frameCode, "(?<=(\s+centery|^centery):\s*)[-0-9]+")

                    If Not Frames.ContainsKey(LFFrame.ID) Then
                        Frames.Add(LFFrame.ID, LFFrame.Clone)
                    End If
                End If
            Next
        End Sub
    End Class
End Namespace