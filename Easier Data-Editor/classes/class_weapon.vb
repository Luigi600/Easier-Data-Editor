Imports System.Text.RegularExpressions

'------------------------------------------''---------Created by Lui's Studio----------''-------(http://www.lui-studio.net/)-------''------------------------------------------''-------------Author: Luigi600-------------''------------------------------------------'
'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Hardcoded weapon object </summary>

Public Class class_weapon
    Public Frames As New Dictionary(Of Integer, LFFrame)

    Public Sub New()
        Dim fileContent As String = "<frame> 20 on_hand
   pic: 20  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 24  y: 40  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 18  y: 4  w: 12  h: 50  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 21 on_hand
   pic: 21  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 17  y: 41  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 23  y: 2  w: 13  h: 23  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 12  y: 26  w: 13  h: 26  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 22 on_hand
   pic: 22  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 12  y: 37  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: -6  y: 36  w: 21  h: 19  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 28  y: 5  w: 14  h: 19  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 10  y: 18  w: 21  h: 22  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 23 on_hand
   pic: 23  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 9  y: 33  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 33  y: 15  w: 13  h: 11  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 5  y: 24  w: 25  h: 11  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: -18  y: 33  w: 31  h: 10  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 24 on_hand
   pic: 24  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 10  y: 29  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: -23  y: 23  w: 70  h: 12  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 25 on_hand
   pic: 25  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 12  y: 23  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: -14  y: 13  w: 38  h: 17  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 22  y: 25  w: 23  h: 16  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 26 on_hand
   pic: 26  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 14  y: 15  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 26  y: 27  w: 16  h: 16  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: -3  y: -1  w: 24  h: 24  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 17  y: 20  w: 16  h: 13  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 27 on_hand
   pic: 27  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 17  y: 13  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 7  y: 3  w: 16  h: 22  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 19  y: 22  w: 15  h: 23  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 28 on_hand
   pic: 28  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 24  y: 11  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 18  y: 2  w: 14  h: 45  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 29 on_hand
   pic: 29  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 29  y: 13  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 24  y: -1  w: 11  h: 28  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 11  y: 25  w: 16  h: 22  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 30 on_hand
   pic: 30  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 36  y: 16  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: -2  y: 34  w: 24  h: 14  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 34  y: -1  w: 23  h: 16  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 18  y: 14  w: 20  h: 20  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 31 on_hand
   pic: 31  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 37  y: 19  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 28  y: 10  w: 32  h: 12  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: -4  y: 21  w: 39  h: 16  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 32 on_hand
   pic: 32  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 37  y: 26  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: -2  y: 23  w: 66  h: 8  
   itr_end:
<frame_end>

<frame> 33 on_hand
   pic: 33  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 38  y: 33  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 3  y: 15  w: 22  h: 16  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 25  y: 27  w: 39  h: 15  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 34 on_hand
   pic: 34  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 34  y: 36  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 32  y: 34  w: 20  h: 18  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 5  y: 5  w: 17  h: 19  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 15  y: 19  w: 20  h: 18  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>

<frame> 35 on_hand
   pic: 35  state: 1001  wait: 0  next: 0  dvx: 0  dvy: 0  dvz: 0  centerx: 24  centery: 40  hit_a: 0  hit_d: 0  hit_j: 0
   wpoint:
      kind: 2  x: 29  y: 40  weaponact: 0  attacking: 0  cover: 0  dvx: 0  dvy: 0  dvz: 0 
   wpoint_end:
   itr:
      kind: 5  x: 9  y: 1  w: 14  h: 22  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
   itr:
      kind: 5  x: 19  y: 20  w: 18  h: 32  dvx: 8  fall: 20  bdefend: 16  injury: 789  
   itr_end:
<frame_end>"

        Parser(fileContent)

        Dim w As Integer = 48
        Dim h As Integer = 48
        Dim r As Integer = 10
        Dim c As Integer = 10

        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim startImageIndex As Integer = 0
        Dim weaponImg As Bitmap = My.Resources.weapon0
        weaponImg.MakeTransparent(Color.Black)
        Do While True
            Dim frames As List(Of LFFrame) = getFrameWithPicID(startImageIndex)
            If frames.Count > 0 Then
                Dim imageClone As New Bitmap(w, h)
                Dim grap As Graphics = Graphics.FromImage(imageClone)
                grap.DrawImage(weaponImg, New Rectangle(0, 0, w, h), New Rectangle(x * (w + 1), y * (h + 1), imageClone.Width, imageClone.Height), GraphicsUnit.Pixel)
                imageClone.MakeTransparent(Color.Black)

                For Each frame As LFFrame In frames
                    frame.Image = imageClone.Clone
                Next
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

    Private Function getFrameWithPicID(ByVal ID As Integer) As List(Of LFFrame)
        Dim result As New List(Of LFFrame)
        For Each frame As LFFrame In Frames.Values
            If frame.PicID = ID Then
                result.Add(frame)
            End If
        Next
        Return result
    End Function

    Private Sub Parser(ByVal content As String)
        For Each frameMatch As Match In Regex.Matches(content, "<frame>.*?<frame_end>", RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Singleline)
            If frameMatch.Success Then
                Dim LFFrame As New LFFrame
                Dim frameCode As String = frameMatch.Value
                SetFrameIfSuccess(LFFrame.ID, frameCode, "(?<=<frame>\s+)[0-9]+")

                Dim itrs As MatchCollection = Regex.Matches(frameCode, "itr:[^_]+itr_end:", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                For Each itr As Match In itrs
                    If itr.Success Then
                        Dim ir As New itr
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
                    LFFrame.WPoint = New wpoint
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
