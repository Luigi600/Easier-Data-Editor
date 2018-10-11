Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Text.RegularExpressions

Public Class ui_frameViewer
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    Implements IFrameViewer

    Private m_path As String = ""
    Private m_editor As ui_textEditor = Nothing
    Public ID As Integer = 0
    Public Event FrameViewerWillChange As ITextEditor.CustomEvent
    Public Event FrameViewerWillDelete As ITextEditor.CustomEvent
    Public Event FrameViewerWillAdd As ITextEditor.CustomEvent
    Public Event FrameViewerWillPreviousFrame As EventHandler
    Public Event FrameViewerWillPreviousRealFrame As EventHandler
    Public Event FrameViewerWillNextFrame As EventHandler
    Public Event FrameViewerWillNextRealFrame As EventHandler

    Public Event GlobalSettingsChanged As ITextEditor.CustomEvent

    Private LFFrame As LFFrame = Nothing
    Private ThatWasMe As Boolean = False

    Private m_newBitmapFiles As New List(Of class_bitmapFile) 'he compares the two lists if he is visible
    Private m_bitmapsFiles As New List(Of class_bitmapFile)
    Private m_bitmaps As New Dictionary(Of Integer, Bitmap)

    Private m_hasFocus As Boolean = False
    Private Property hasFocus As Boolean Implements IFrameViewer.hasFocus
        Get
            Return m_hasFocus
        End Get
        Set(value As Boolean)
            If value Then
                RefreshGlobalSettings()
            End If
            m_hasFocus = value
        End Set
    End Property

    Public Property Path As String
        Get
            Return m_path
        End Get
        Set(value As String)
            If Not IsNothing(value) Then
                If IO.File.Exists(value) Then
                    Text = IO.Path.GetFileName(value) & " [Frame Viewer]"
                    ToolTipText = value
                Else
                    Text = "New Frame Viewer"
                    ToolTipText = Nothing
                End If
            Else
                Text = "New Frame Viewer"
                ToolTipText = Nothing
            End If

            m_path = value
        End Set
    End Property

    Public Function getTextEditor() As ITextEditor Implements IFrameViewer.getTextEditor
        Return m_editor
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        'ErrorList.lv_errors.Items.Add(Convert.ToInt64(keyData))
        Select Case keyData
            Case Keys.Down
                RaiseEvent FrameViewerWillNextFrame(Nothing, New EventArgs())
                Return True
            Case Keys.Up
                RaiseEvent FrameViewerWillPreviousFrame(Nothing, New EventArgs())
                Return True
            Case Keys.PageDown
                RaiseEvent FrameViewerWillNextRealFrame(LFFrame.Next, New EventArgs())
                Return True
            Case Keys.PageUp
                RaiseEvent FrameViewerWillPreviousRealFrame(LFFrame.ID, New EventArgs())
                Return True
            Case Keys.Control, Keys.ControlKey, (Keys.Control Or Keys.ControlKey)
                If Not IsNothing(LFFrame) And Not selectedObj = FrameChangeType.CenterXY Then
                    setCenterXY2()
                    Return True
                End If
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        'ErrorList.lv_errors.Items.Add(Convert.ToInt64(keyData))
        Select Case keyData
            Case Keys.Control, Keys.ControlKey, (Keys.Control Or Keys.ControlKey)
                If Not IsNothing(LFFrame) And Not selectedObj = FrameChangeType.CenterXY Then
                    setCenterXY2()
                    Return True
                End If
        End Select
        Return MyBase.IsInputKey(keyData)
    End Function

    Private Sub setCenterXY2()
        Dim picCenterXWithoutZoom As Integer = CenterPoint.X + scrollPosition.X
        Dim picCenterYWithoutZoom As Integer = CenterPoint.Y + scrollPosition.Y
        picCenterXWithoutZoom = (CenterPoint.X + scrollPosition.X) / 100 * m_zoom
        picCenterYWithoutZoom = (CenterPoint.Y + scrollPosition.Y) / 100 * m_zoom
        Dim relativPosition As New Point(picCenterXWithoutZoom - Math.Floor(LFFrame.Center.X / 100 * m_zoom), picCenterYWithoutZoom - Math.Floor(LFFrame.Center.Y / 100 * m_zoom))

        Dim drawPoint As New Point(relativPosition.X, relativPosition.Y)
        selectedObj = FrameChangeType.CenterXY2
        Cursor = Cursors.SizeAll
        selectedRelativPos = GetRelativPosition(drawPoint, pic_preview.PointToClient(MousePosition))
    End Sub

    Public Sub RefreshGlobalSettings()
        If isGlobalSettingsEnable Then
            TSMI_axis.Checked = global_draw_axis
            cb_axis.Checked = global_draw_axis
            TSMI_center_xy.Checked = global_draw_centerXY
            cb_center_xy.Checked = global_draw_centerXY
            TSMI_shadow.Checked = global_draw_shadow
            cb_shadow.Checked = global_draw_shadow
            TSMI_bodies.Checked = global_draw_bodys
            cb_bodies.Checked = global_draw_bodys
            TSMI_itrs.Checked = global_draw_itrs
            cb_itrs.Checked = global_draw_itrs
            TSMI_wpoint.Checked = global_draw_wpoint
            cb_wpoint.Checked = global_draw_wpoint
            TSMI_weapon.Checked = global_draw_weapon
            cb_weapon.Checked = global_draw_weapon
            TSMI_bpoint.Checked = global_draw_bpoint
            cb_bpoint.Checked = global_draw_bpoint
            TSMI_opoint.Checked = global_draw_opoint
            cb_opoint.Checked = global_draw_opoint
            TSMI_cpoint.Checked = global_draw_cpoint
            cb_cpoint.Checked = global_draw_cpoint
            TSMI_showScales.Checked = global_draw_scales
            cb_showScales.Checked = global_draw_scales
            m_zoom = global_zoom
            scrollPosition = global_scrollPosition
            CenterPoint = global_centerPoint

            If Not hasFocus And Visible Then
                pic_preview.Invalidate()
                pic_preview.Refresh()
            End If
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        RefreshGlobalSettings()
    End Sub

    Public Sub New(ByVal path As String, ByVal editor As ui_textEditor, ByVal ID As Integer)
        InitializeComponent()

        Me.Path = path
        Me.ID = ID

        m_editor = editor
        AddHandler editor.FrameChanged, AddressOf FrameChanged
        AddHandler editor.HeaderChanged, AddressOf HeaderChanged

        Dim maxVal As Long = editor.GetAvalonEditor().Document.TextLength
        HeaderChanged(editor, New class_customEventArgs(editor.GetAvalonEditor().Document.GetText(0, If(maxVal < 1000, maxVal, 1000))))


        ms_options.Visible = opt_showMS
        pal_charView.Visible = Not opt_showMS
        pic_preview.BackColor = opt_defaultBackgroundColor
        background_drawer.RunWorkerAsync()
        RefreshGlobalSettings()
    End Sub

    Private Sub FrameChanged(ByVal sender As ui_textEditor, ByVal e As class_customEventArgs)
        If Not ThatWasMe Then
            If IsNothing(e.Object) Then
                LFFrame = Nothing
                pic_preview.Invalidate()
                Exit Sub
            ElseIf Not TypeOf (e.Object) Is String Then
                LFFrame = Nothing
                pic_preview.Invalidate()
                Exit Sub
            End If

            LFFrame = New LFFrame


            Dim frameCode As String = CType(e.Object, String)
            SetFrameIfSuccess(LFFrame.ID, frameCode, "(?<=<frame>\s+)[0-9]+")
            If m_editor.IDToFacing.ContainsKey(LFFrame.ID) Then
                LFFrame.Facing = m_editor.IDToFacing(LFFrame.ID)
            End If
            TSMI_mirrorFrame.Checked = LFFrame.Facing

            Dim bodies As MatchCollection = Regex.Matches(frameCode, "bdy:[^_]+bdy_end:", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            For Each body As Match In bodies
                If body.Success Then
                    Dim bdy As New bdy
                    SetFrameIfSuccess(bdy.Kind, body.Value, "(?<=(\s+kind|^kind):\s*)[0-9]+")
                    SetFrameIfSuccess(bdy.Rect.X, body.Value, "(?<=(\s+x|^x):\s*)[0-9-]+")
                    SetFrameIfSuccess(bdy.Rect.Y, body.Value, "(?<=(\s+y|^y):\s*)[0-9-]+")
                    SetFrameIfSuccess(bdy.Rect.Width, body.Value, "(?<=(\s+w|^w):\s*)[0-9]+")
                    SetFrameIfSuccess(bdy.Rect.Height, body.Value, "(?<=(\s+h|^h):\s*)[0-9]+")
                    LFFrame.Bodys.Add(bdy)
                End If
            Next

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

                SetFrameIfSuccess(LFFrame.WPoint.Weaponact, wpointMatch.Value, "(?<=(\s+weaponact|^weaponact):\s*)[0-9]+")
                SetFrameIfSuccess(LFFrame.WPoint.Attacking, wpointMatch.Value, "(?<=(\s+attacking|^attacking):\s*)[0-9]+")
                SetFrameIfSuccess(LFFrame.WPoint.Cover, wpointMatch.Value, "(?<=(\s+cover|^cover):\s*)[0-9]+")
            End If


            Dim bpointMatch As Match = Regex.Match(frameCode, "bpoint:[^_]+bpoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If bpointMatch.Success Then
                SetFrameIfSuccess(LFFrame.BPoint.X, bpointMatch.Value, "(?<=(\s+x|^x):\s*)[0-9-]+")
                SetFrameIfSuccess(LFFrame.BPoint.Y, bpointMatch.Value, "(?<=(\s+y|^y):\s*)[0-9-]+")
            End If

            Dim cpointMatch As Match = Regex.Match(frameCode, "cpoint:[^_]+cpoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If cpointMatch.Success Then
                SetFrameIfSuccess(LFFrame.CPoint.X, cpointMatch.Value, "(?<=(\s+x|^x):\s*)[0-9-]+")
                SetFrameIfSuccess(LFFrame.CPoint.Y, cpointMatch.Value, "(?<=(\s+y|^y):\s*)[0-9-]+")
            End If

            Dim opointMatch As Match = Regex.Match(frameCode, "opoint:[^_]+opoint_end:", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If opointMatch.Success Then
                SetFrameIfSuccess(LFFrame.OPoint.X, opointMatch.Value, "(?<=(\s+x|^x):\s*)[0-9-]+")
                SetFrameIfSuccess(LFFrame.OPoint.Y, opointMatch.Value, "(?<=(\s+y|^y):\s*)[0-9-]+")
            End If

            SetFrameIfSuccess(LFFrame.PicID, frameCode, "(?<=(\s+pic|^pic):\s*)[0-9]+")
            'SetFrameIfSuccess(LFFrame.state, frameCode, "(?<=(\s+state|^state):\s*)[0-9]+")
            SetFrameIfSuccess(LFFrame.Next, frameCode, "(?<=(\s+next|^next):\s*)[0-9-]+")
            SetFrameIfSuccess(LFFrame.Center.X, frameCode, "(?<=(\s+centerx|^centerx):\s*)[0-9-]+")
            SetFrameIfSuccess(LFFrame.Center.Y, frameCode, "(?<=(\s+centery|^centery):\s*)[0-9-]+")
            pic_preview.Invalidate()
        End If
    End Sub

    Private Sub ui_frameViewer_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            CheckMyBitmaps()
        End If
    End Sub

    Private Sub HeaderChanged(ByVal sender As ui_textEditor, ByVal e As class_customEventArgs)
        m_newBitmapFiles.Clear()
        For Each line As String In Split(e.Object.ToString, ControlChars.Lf)
            If Regex.IsMatch(line, "file\([0-9]+-[0-9]+\):", RegexOptions.IgnoreCase) Then
                Dim file As String = getRegexValue(line, "(?<=file\([0-9]+-[0-9]+\):\s*)[^:;]+\.[A-Za-z0-9]{1,5}", RegexOptions.IgnoreCase)
                Dim start As String = getRegexValue(line, "(?<=file\()[0-9]+(?=-[0-9]+\):)", RegexOptions.IgnoreCase)
                Dim endB As String = getRegexValue(line, "(?<=file\([0-9]+-)[0-9]+(?=\):)", RegexOptions.IgnoreCase)
                Dim w As String = getRegexValue(line, "(?<=\s+w:\s*)[0-9]+", RegexOptions.IgnoreCase)
                Dim h As String = getRegexValue(line, "(?<=\s+h:\s*)[0-9]+", RegexOptions.IgnoreCase)
                Dim row As String = getRegexValue(line, "(?<=\s+row:\s*)[0-9]+", RegexOptions.IgnoreCase)
                Dim col As String = getRegexValue(line, "(?<=\s+col:\s*)[0-9]+", RegexOptions.IgnoreCase)

                If Not (String.IsNullOrEmpty(file) Or IsNothing(w) Or IsNothing(h) Or IsNothing(row) Or IsNothing(col) Or IsNothing(start) Or IsNothing(endB)) Then
                    m_newBitmapFiles.Add(New class_bitmapFile With {.Path = file.Trim, .Width = Convert.ToInt64(w.Trim),
                                    .Height = Convert.ToInt64(h.Trim),
                                    .Row = Convert.ToInt64(row.Trim),
                                    .Col = Convert.ToInt64(col.Trim),
                                    .IndexStart = Convert.ToInt64(start.Trim),
                                    .IndexEnd = Convert.ToInt64(endB.Trim)})
                End If
            End If
        Next

        If Visible Then
            CheckMyBitmaps()
        End If
    End Sub

    Private Sub CheckMyBitmaps()
        Dim hasDeviation As Boolean = Not (m_newBitmapFiles.Count = m_bitmapsFiles.Count)
        If Not hasDeviation Then
            For i As Integer = 0 To m_newBitmapFiles.Count - 1
                If Not m_newBitmapFiles(i).Equals(m_bitmapsFiles(i)) Then
                    hasDeviation = True
                    Exit For
                End If
            Next
        End If

        If hasDeviation Then
            m_bitmapsFiles.Clear()
            For Each img As Bitmap In m_bitmaps.Values
                img.Dispose()
            Next
            m_bitmaps.Clear()

            For Each info As class_bitmapFile In m_newBitmapFiles
                m_bitmapsFiles.Add(info.Clone)

                Dim characterImage As Bitmap = Nothing
                Dim filePath As String = getFolder(m_path, info.Path)
                If IO.File.Exists(filePath) Then
                    characterImage = New Bitmap(filePath)
                End If
                If IsNothing(characterImage) Then
                    Exit Sub 'macht sonst kein sinn (kein bild vorhanden)
                End If

                Dim x As Integer = 0
                Dim y As Integer = 0
                Dim startImageIndex As Integer = info.IndexStart
                Do While True
                    If Not m_bitmaps.ContainsKey(startImageIndex) Then
                        Dim imageClone As New Bitmap(info.Width, info.Height)
                        Dim grap As Graphics = Graphics.FromImage(imageClone)
                        grap.DrawImage(characterImage, New Rectangle(0, 0, info.Width, info.Height), New Rectangle(x * (info.Width + 1), y * (info.Height + 1), imageClone.Width, imageClone.Height), GraphicsUnit.Pixel)
                        imageClone.MakeTransparent(Color.Black)

                        m_bitmaps.Add(startImageIndex, imageClone.Clone)
                        'imageClone.Save("Test/" & startImageIndex & ".png", Imaging.ImageFormat.Png)
                        grap.Dispose()
                        imageClone.Dispose() 'da ein klone weitergegeben wird, da sonst ein fehler auftritt (er übernimmt sonst einfach das bild...)
                    End If


                    x += 1
                    startImageIndex += 1
                    If startImageIndex = (info.IndexEnd + 1) Then
                        Exit Do
                    End If
                    If x >= info.Row Then
                        x = 0
                        y += 1
                    End If
                    If y >= info.Col Then
                        Exit Do
                    End If
                Loop
            Next

            pic_preview.Invalidate()
        End If
    End Sub

    Public Function getRegexValue(ByVal input As String, ByVal pattern As String, Optional ByVal regexopt As RegexOptions = (RegexOptions.Multiline + RegexOptions.Singleline)) As String
        Dim match As MatchCollection = Regex.Matches(input, pattern, regexopt) 'match support only single OR only multiline...
        If match.Count > 0 Then
            If match(0).Success Then
                Return match(0).Value
            End If
        End If
        Return Nothing
    End Function


    Protected Overrides Function GetPersistString() As String
        Dim originalResult As String = MyBase.GetPersistString()
        originalResult &= ";" & ID.ToString
        Return originalResult
    End Function







#Region "Preview"
    Dim debug_draw_axis As Boolean = True
    Dim debug_draw_centerXY As Boolean = True
    Dim debug_draw_shadow As Boolean = True
    'Dim debug_draw_characterPoint As Boolean = True
    Dim debug_draw_bodys As Boolean = True
    Dim debug_draw_itrs As Boolean = True
    Dim debug_draw_wpoint As Boolean = True
    Dim debug_draw_weapon As Boolean = True
    Dim debug_draw_weaponBoxes As Boolean = True
    Dim debug_draw_bpoint As Boolean = True
    Dim debug_draw_opoint As Boolean = True
    Dim debug_draw_cpoint As Boolean = True

    Dim debug_draw_scales As Boolean = True

    Private m_zoom As Integer = 100
    Private scrollPosition As New Point(0, 0)
    Private CenterPoint As New Point(200, 200)
    Private maxViewY As New Point(300, 300)
    Private maxViewX As New Point(600, 600)

    Dim zoomToBigStepX As New List(Of Integer) From {100, 60, 60, 60, 50, 30}
    Dim zoomToSmallStepX As New List(Of Integer) From {10, 10, 5, 5, 5, 5}
    Dim zoomToBigStepY As New List(Of Integer) From {50, 60, 60, 60, 50, 30}
    Dim zoomToSmallStepY As New List(Of Integer) From {10, 10, 5, 5, 5, 5}

    Private font_big As New Font(FontFamily.GenericMonospace, 18, FontStyle.Bold, GraphicsUnit.Pixel)
    Private font_big_logo As New Font(FontFamily.GenericMonospace, 14, FontStyle.Regular, GraphicsUnit.Pixel)
    Private font_normal As New Font(FontFamily.GenericMonospace, 12, FontStyle.Bold, GraphicsUnit.Pixel)
    Private font_small As New Font(FontFamily.GenericMonospace, 10, FontStyle.Regular, GraphicsUnit.Pixel)


    Private Sub background_drawer_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles background_drawer.DoWork
        Do While True
            Dim startTime As Date = Date.Now
            If hasFocus Then
                pic_preview.Invalidate()
            End If

            Dim sleep As Integer = Math.Floor(1000 / 60) - (Date.Now - startTime).TotalMilliseconds
            If sleep < 0 Then
                sleep = 1
            End If
            Threading.Thread.Sleep(sleep)
        Loop
    End Sub

    Private Sub pic_preview_Paint(sender As Object, e As PaintEventArgs) Handles pic_preview.Paint
        Dim isControlPressed As Boolean = (system_KeyInfo.IsKeyPressed(Keys.Control) Or system_KeyInfo.IsKeyPressed(Keys.ControlKey) Or system_KeyInfo.IsKeyPressed(Keys.Control Or Keys.ControlKey))

        With e.Graphics
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .InterpolationMode = InterpolationMode.NearestNeighbor
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit

            Dim picCenterX As Integer = CenterPoint.X + scrollPosition.X
            Dim picCenterY As Integer = CenterPoint.Y + scrollPosition.Y

            Dim picCenterXWithoutZoom As Integer = CenterPoint.X + scrollPosition.X
            Dim picCenterYWithoutZoom As Integer = CenterPoint.Y + scrollPosition.Y
            picCenterXWithoutZoom = picCenterX / 100 * m_zoom
            picCenterYWithoutZoom = picCenterY / 100 * m_zoom


            If debug_draw_axis Then
                If picCenterXWithoutZoom >= 0 And picCenterXWithoutZoom <= e.ClipRectangle.Width Then
                    e.Graphics.DrawLine(Pens.Gray, picCenterXWithoutZoom, 0, picCenterXWithoutZoom, e.ClipRectangle.Height)
                End If

                If picCenterYWithoutZoom >= 0 And picCenterYWithoutZoom <= e.ClipRectangle.Height Then
                    e.Graphics.DrawLine(Pens.Gray, 0, picCenterYWithoutZoom, e.ClipRectangle.Width, picCenterYWithoutZoom)
                End If

                If picCenterXWithoutZoom + picCenterYWithoutZoom >= 0 And picCenterXWithoutZoom + picCenterYWithoutZoom <= e.ClipRectangle.Width + e.ClipRectangle.Height Then
                    e.Graphics.DrawLine(Pens.Gray, picCenterXWithoutZoom + picCenterYWithoutZoom, 0, 0, picCenterXWithoutZoom + picCenterYWithoutZoom)
                End If
            End If


            If Not IsNothing(LFFrame) Then
                Dim LFimg As Bitmap = Nothing
                If m_bitmaps.ContainsKey(LFFrame.PicID) Then
                    LFimg = m_bitmaps(LFFrame.PicID)
                End If

                .ScaleTransform(1 / 100 * m_zoom, 1 / 100 * m_zoom)

                Dim relativPosition As New Point(picCenterX - LFFrame.Center.X, picCenterY - LFFrame.Center.Y)

                If debug_draw_shadow Then
                    e.Graphics.DrawImage(shadow, New Rectangle(picCenterX - Math.Floor(37 / 2),
                                       picCenterY - Math.Floor(9 / 2), shadow.Width, shadow.Height),
                                       New Rectangle(0, 0, shadow.Width, shadow.Height), GraphicsUnit.Pixel)
                End If


                'WEAPON
                If debug_draw_wpoint And Not IsNothing(LFFrame.WPoint) Then
                    Dim weaponPoint As wpoint = LFFrame.WPoint
                    If Not IsNothing(weaponPoint) And Weapon.Frames.ContainsKey(weaponPoint.Weaponact) Then
                        If weaponPoint.Cover Then
                            Dim weaponFrame As LFFrame = Weapon.Frames(weaponPoint.Weaponact)
                            Dim drawPoint As New Point(relativPosition.X + weaponPoint.Loca.X, relativPosition.Y + weaponPoint.Loca.Y)
                            If Not IsNothing(weaponFrame.Image) And debug_draw_weapon Then
                                e.Graphics.DrawImage(weaponFrame.Image, New Point(drawPoint.X - weaponFrame.WPoint.Loca.X, drawPoint.Y - weaponFrame.WPoint.Loca.Y))
                            End If
                        End If
                    End If
                End If


                'MAIN CHARACTER
                If Not IsNothing(LFimg) Then
                    If LFFrame.Facing Then
                        Dim newBitmap As Bitmap = LFimg.Clone
                        newBitmap.RotateFlip(RotateFlipType.Rotate180FlipY)
                        .DrawImage(newBitmap, relativPosition)
                    Else
                        .DrawImage(LFimg, relativPosition)
                    End If
                End If

                'CENTER XY
                If debug_draw_centerXY Then
                    e.Graphics.FillPie(Brushes.Gray, New Rectangle(relativPosition.X - 3, relativPosition.Y - 3, 6, 6), 0, 360)
                End If


                'BLOOD
                If debug_draw_bpoint Then
                    If Not (Integer.MaxValue = LFFrame.BPoint.X AndAlso LFFrame.BPoint.Y) Then
                        Dim drawRect As New Point(relativPosition.X + LFFrame.BPoint.X, relativPosition.Y + LFFrame.BPoint.Y)
                        If Not LFFrame.Facing Then
                            drawRect.X += 1
                        End If
                        e.Graphics.DrawLine(Pens.Red, drawRect, New Point(drawRect.X, drawRect.Y + 3))
                    End If
                End If

                'WEAPON
                If debug_draw_wpoint And Not IsNothing(LFFrame.WPoint) Then
                    Dim weaponPoint As wpoint = LFFrame.WPoint
                    If Not IsNothing(weaponPoint) And Weapon.Frames.ContainsKey(weaponPoint.Weaponact) Then
                        Dim weaponFrame As LFFrame = Weapon.Frames(weaponPoint.Weaponact)
                        Dim drawPoint As New Point(relativPosition.X + weaponPoint.Loca.X, relativPosition.Y + weaponPoint.Loca.Y)
                        If Not IsNothing(weaponFrame.Image) And debug_draw_weapon And Not weaponPoint.Cover Then
                            e.Graphics.DrawImage(weaponFrame.Image, New Point(drawPoint.X - weaponFrame.WPoint.Loca.X, drawPoint.Y - weaponFrame.WPoint.Loca.Y))
                        End If
                        'e.Graphics.FillRectangle(Brushes.LightGreen, drawPoint.X, drawPoint.Y, 1, 1)
                        'e.Graphics.FillPie(Brushes.Green, New Rectangle(drawPoint.X - 3, drawPoint.Y - 3, 6, 6), 0, 360)
                    End If
                End If

                'OPOINT
                If debug_draw_opoint And Not LFFrame.OPoint.X = Integer.MaxValue And Not LFFrame.OPoint.Y = Integer.MaxValue Then
                    Dim drawPoint As New Point(relativPosition.X + LFFrame.OPoint.X, relativPosition.Y + LFFrame.OPoint.Y)
                    e.Graphics.FillRectangle(Brushes.Purple, drawPoint.X, drawPoint.Y, 1, 1)
                    '  e.Graphics.FillPie(Brushes.Purple, New Rectangle(drawPoint.X - 3, drawPoint.Y - 3, 6, 6), 0, 360)
                End If

                'CPOINT
                If debug_draw_cpoint And Not LFFrame.CPoint.X = Integer.MaxValue And Not LFFrame.CPoint.Y = Integer.MaxValue Then
                    Dim drawPoint As New Point(relativPosition.X + LFFrame.CPoint.X, relativPosition.Y + LFFrame.CPoint.Y)
                    e.Graphics.FillRectangle(Brushes.Chocolate, drawPoint.X, drawPoint.Y, 1, 1)
                    ' e.Graphics.FillPie(Brushes.Chocolate, New Rectangle(drawPoint.X - 3, drawPoint.Y - 3, 6, 6), 0, 360)
                End If

                .ResetTransform()


                relativPosition = New Point(picCenterXWithoutZoom - Math.Floor(LFFrame.Center.X / 100 * m_zoom), picCenterYWithoutZoom - Math.Floor(LFFrame.Center.Y / 100 * m_zoom))

                'DOUBLE DRAW
                '--------------------------------------------------------------------------
                If Not isControlPressed And selectedObj = FrameChangeType.CenterXY2 Then
                    selectedObj = FrameChangeType.None
                    Cursor = Cursors.Default
                End If



                'OPOINT
                If debug_draw_opoint And Not LFFrame.OPoint.X = Integer.MaxValue And Not LFFrame.OPoint.Y = Integer.MaxValue Then
                    Dim drawRect As Rectangle = getAbsolutePositionWithoutZoom(relativPosition, New Point(LFFrame.OPoint.X - 2, LFFrame.OPoint.Y - 2), New Size(5, 5), New Point(1, 1))
                    e.Graphics.DrawRectangle(Pens.Purple, drawRect)
                End If

                'CPOINT
                If debug_draw_cpoint And Not LFFrame.CPoint.X = Integer.MaxValue And Not LFFrame.CPoint.Y = Integer.MaxValue Then
                    Dim drawRect As Rectangle = getAbsolutePositionWithoutZoom(relativPosition, New Point(LFFrame.CPoint.X - 2, LFFrame.CPoint.Y - 2), New Size(5, 5), New Point(1, 1))
                    e.Graphics.DrawRectangle(Pens.Chocolate, drawRect)
                End If



                'BODYS
                If debug_draw_bodys Then
                    For Each body As bdy In LFFrame.Bodys
                        Dim drawRect As Rectangle = getAbsolutePositionWithoutZoom(relativPosition, body.Rect)
                        e.Graphics.DrawRectangle(Pens.Blue, drawRect)
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(60, Color.Blue)), drawRect)
                    Next
                End If

                'ITRS
                If debug_draw_itrs Then
                    For Each itr As itr In LFFrame.Itrs
                        Dim itrColor As Color = Color.Red
                        Dim drawRect As Rectangle = getAbsolutePositionWithoutZoom(relativPosition, itr.Rect)
                        If itr.Kind <> 0 Then
                            itrColor = Color.Chocolate
                        End If
                        e.Graphics.DrawRectangle(New Pen(itrColor), drawRect)
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(60, itrColor)), drawRect)
                    Next
                End If

                'WPOINT
                If debug_draw_wpoint And Not IsNothing(LFFrame.WPoint) Then
                    Dim weaponPoint As wpoint = LFFrame.WPoint
                    If Not IsNothing(weaponPoint) And Weapon.Frames.ContainsKey(weaponPoint.Weaponact) Then
                        Dim weaponFrame As LFFrame = Weapon.Frames(weaponPoint.Weaponact)
                        Dim drawRect As Rectangle = getAbsolutePositionWithoutZoom(relativPosition, New Point(weaponPoint.Loca.X - 2, weaponPoint.Loca.Y - 2), New Size(5, 5), New Point(1, 1))
                        e.Graphics.DrawRectangle(Pens.Lime, drawRect)

                        drawRect = getAbsolutePositionWithoutZoom(relativPosition, New Point(weaponPoint.Loca.X, weaponPoint.Loca.Y), New Size(1, 1))
                        e.Graphics.FillRectangle(Brushes.Lime, drawRect)

                        If Not IsNothing(weaponFrame.WPoint) And debug_draw_weaponBoxes Then
                            For Each itr As itr In weaponFrame.Itrs
                                Dim itrColor As Color = Color.Red
                                drawRect = getAbsolutePositionWithoutZoom(relativPosition, New Point(weaponPoint.Loca.X - weaponFrame.WPoint.Loca.X + itr.Rect.X, weaponPoint.Loca.Y - weaponFrame.WPoint.Loca.Y + itr.Rect.Y + If(weaponPoint.Cover, 2, 0)), New Size(itr.Rect.Width, itr.Rect.Height))
                                If itr.Kind <> 0 Then
                                    itrColor = Color.Chocolate
                                End If
                                e.Graphics.DrawRectangle(New Pen(itrColor), drawRect)
                            Next
                        End If


                    End If
                End If
            End If








            If debug_draw_scales Then
                e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, e.ClipRectangle.Width, 20))
                e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, 20, e.ClipRectangle.Height))

                Dim bigStepX As Integer = 100
                Dim smallStepX As Integer = 10
                Dim smallStepY As Integer = 10
                Dim bigStepY As Integer = 50

                Dim zoomIndex As Integer = (m_zoom - 100) / 100
                If zoomIndex >= 0 And zoomIndex < zoomToBigStepX.Count Then
                    bigStepX = zoomToBigStepX(zoomIndex)
                    smallStepX = zoomToSmallStepX(zoomIndex)
                    bigStepY = zoomToBigStepY(zoomIndex)
                    smallStepY = zoomToSmallStepY(zoomIndex)
                End If

                Dim iStart As Integer = picCenterXWithoutZoom Mod smallStepX
                For i = iStart To pic_preview.Width Step smallStepX
                    If (picCenterXWithoutZoom - i) Mod bigStepX = 0 Then
                        e.Graphics.DrawLine(Pens.Black, i, 0, i, 6)

                        Dim text As String = Math.Round(-(picCenterXWithoutZoom - iStart) / m_zoom * 100 + ((i - iStart) / m_zoom * 100)).ToString
                        Dim fontSize As Size = TextRenderer.MeasureText(text, font_small)
                        e.Graphics.DrawString(text, font_small, Brushes.Black, New Point(1 + i - (fontSize.Width / 2), 7))
                    ElseIf (picCenterXWithoutZoom - i) Mod (bigStepX / 2) = 0 Then
                        e.Graphics.DrawLine(Pens.LightGray, i, 0, i, 5)
                    Else
                        e.Graphics.DrawLine(Pens.LightGray, i, 0, i, 3)
                    End If
                Next



                iStart = picCenterYWithoutZoom Mod smallStepY
                For i = iStart To pic_preview.Height Step smallStepY
                    If (picCenterYWithoutZoom - i) Mod bigStepY = 0 Then
                        e.Graphics.DrawLine(Pens.Black, 19 - 6, i, 19, i)
                    ElseIf (picCenterYWithoutZoom - i) Mod (bigStepY / 2) = 0 Then
                        e.Graphics.DrawLine(Pens.LightGray, 19 - 5, i, 19, i)
                    Else
                        e.Graphics.DrawLine(Pens.LightGray, 19 - 3, i, 19, i)
                    End If
                Next

                e.Graphics.TranslateTransform(e.ClipRectangle.Width, e.ClipRectangle.Height)
                e.Graphics.RotateTransform(-90)
                iStart = picCenterYWithoutZoom Mod bigStepY

                iStart = picCenterYWithoutZoom Mod bigStepY
                For i = iStart To pic_preview.Height Step bigStepY
                    Dim text As String = Math.Round(-(-(picCenterYWithoutZoom - iStart) / m_zoom * 100 + ((i - iStart) / m_zoom * 100))).ToString
                    Dim fontSize As Size = TextRenderer.MeasureText(text, font_small)
                    e.Graphics.DrawString(text, font_small, Brushes.Black, New Point(e.ClipRectangle.Height - i - (fontSize.Width / 2) + 1, -e.ClipRectangle.Width + 1)) ' + TextRenderer.MeasureText("test", newFont).Width))
                Next
                e.Graphics.ResetTransform()


                e.Graphics.DrawLine(Pens.Black, 0, 20, e.ClipRectangle.Width, 20)
                e.Graphics.DrawLine(Pens.Black, 20, 0, 20, e.ClipRectangle.Height)

                e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, 20, 20))
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, 20, 20))
                e.Graphics.DrawString("px", New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), Brushes.Black, New Point(2, 2))


                Dim transHeight As Integer = 25
                Dim linGrBrush = New LinearGradientBrush(
   New Point(0, (e.ClipRectangle.Height Mod transHeight)),
   New Point(0, transHeight + ((e.ClipRectangle.Height Mod transHeight))),
   Color.FromArgb(0, 255, 255, 255),
   Color.FromArgb(255, 255, 255, 255))


                'e.Graphics.FillRectangle(linGrBrush, 0, e.ClipRectangle.Height - 15, pic_preview.Width, 20)
                e.Graphics.FillRectangle(linGrBrush, 20, e.ClipRectangle.Height - transHeight, pic_preview.Width, transHeight)

                e.Graphics.DrawString("Easier Data-Editor (STM93 Version)", New Font(FontFamily.GenericSansSerif, 6.5, FontStyle.Regular), Brushes.DarkBlue, New Point(25, pic_preview.Height - 15))

                If Not selectedObj = FrameChangeType.None Then
                    Dim fontF As New Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold)
                    Dim fontSize As Size = TextRenderer.MeasureText("Selected: " & selectedObj.ToString, fontF)
                    e.Graphics.FillRectangle(Brushes.White, New Rectangle(30 - 1, 30 - 1, fontSize.Width + 3, fontSize.Height + 3))
                    e.Graphics.DrawString("Selected: " & selectedObj.ToString, fontF, Brushes.Black, New Point(31, 30))

                    'e.Graphics.DrawString("Selected: " & selectedObj.ToString, fontF, Brushes.Black, New Point(startPos.X + 10, startPos.Y - 20))
                End If
            End If
        End With
    End Sub

    Private Function getAbsolutePositionWithoutZoom(ByVal relativPosition As Point, ByVal pos As Point, ByVal size As Size, Optional ByVal plusPos As Point = Nothing) As Rectangle
        Return getAbsolutePositionWithoutZoom(relativPosition, New LFRect(pos.X, pos.Y, size.Width, size.Height), plusPos)
    End Function

    Private Function getAbsolutePositionWithoutZoom(ByVal relativPosition As Point, ByVal rect As LFRect, Optional ByVal plusPos As Point = Nothing) As Rectangle
        Dim drawRect As New Rectangle(relativPosition.X + Math.Floor(rect.X / 100 * m_zoom),
                              relativPosition.Y + Math.Floor(rect.Y / 100 * m_zoom),
                              rect.Width,
                              rect.Height)
        drawRect.Width = Math.Floor(drawRect.Width / 100 * m_zoom)
        drawRect.Height = Math.Floor(drawRect.Height / 100 * m_zoom)
        If Not IsNothing(plusPos) Then
            drawRect.X += plusPos.X
            drawRect.Y += plusPos.Y
            drawRect.Width -= plusPos.X
            drawRect.Height -= plusPos.Y
        End If
        Return drawRect
    End Function

    Private Sub pic_preview_MouseEnter(sender As Object, e As EventArgs) Handles pic_preview.MouseEnter
        'Dim searchRect As New Rectangle(SearchWindow.Location.X, SearchWindow.Location.Y,
        '                                SearchWindow.Size.Width, SearchWindow.Size.Height)
        'Dim meRect As New Rectangle(PointToScreen(pic_preview.Location), pic_preview.Size)
        'If SearchWindow.Visible Then
        '    If meRect.Y > searchRect.Y - 20 And meRect.Height < searchRect.Y - 20 Or
        '       meRect.X > searchRect.X - 20 And meRect.Width < searchRect.Width + 20 Then
        '        Exit Sub
        '    End If
        'End If

        If Not pic_preview.Focused And Not SearchWindow.Visible Then
            pic_preview.Focus()
        End If
    End Sub

    Private Sub pic_preview_MouseClick(sender As Object, e As MouseEventArgs) Handles pic_preview.MouseClick
        If Not pic_preview.Focused Then
            pic_preview.Focus()
        End If
    End Sub

    Private Sub pic_preview_MouseDown(sender As Object, e As MouseEventArgs) Handles pic_preview.MouseDown
        startPos = e.Location
    End Sub

    Private Sub pic_preview_MouseWheel(sender As Object, e As MouseEventArgs) Handles pic_preview.MouseWheel
        Dim relativPos As New Point(e.Location.X / m_zoom * 100,
                                    e.Location.Y / m_zoom * 100)

        If ModifierKeys.HasFlag(Keys.Control) Or ModifierKeys.HasFlag(Keys.ControlKey) Or ModifierKeys.HasFlag(Keys.Control Or Keys.ControlKey) Then
            hasFocus = True
            If e.Delta > 0 And m_zoom < 600 Then
                m_zoom += 100

                scrollPosition = New Point(scrollPosition.X - relativPos.X / m_zoom * 100,
                                           scrollPosition.Y - relativPos.Y / m_zoom * 100)
                checkScrollbarPosition()
            ElseIf e.Delta < 0 And m_zoom > 100 Then
                m_zoom -= 100

                scrollPosition = New Point(scrollPosition.X + relativPos.X / m_zoom * 100,
                                           scrollPosition.Y + relativPos.Y / m_zoom * 100)
                checkScrollbarPosition()
            End If

            If isGlobalSettingsEnable Then
                RaiseEvent GlobalSettingsChanged("zoom", New class_customEventArgs(m_zoom, ID))
            End If


        ElseIf ModifierKeys.HasFlag(Keys.ShiftKey) Or ModifierKeys.HasFlag(Keys.Shift) Or ModifierKeys.HasFlag(Keys.Shift Or Keys.ShiftKey) Then
            scrollPosition = New Point(scrollPosition.X + If(e.Delta > 0, 5, -5),
                                       scrollPosition.Y)
            checkScrollbarPosition()
        Else
            scrollPosition = New Point(scrollPosition.X,
                                       scrollPosition.Y + If(e.Delta > 0, 5, -5))
            checkScrollbarPosition()
        End If
    End Sub

    Dim startPos As New Point
    Dim selectedObj As FrameChangeType = -1
    Dim selectedIndex As Integer = -1 'only for bodies and itrs
    Dim selectedPos As SelectedPosition = SelectedPosition.Center
    Dim selectedRelativPos As New Point

    Private Sub pic_preview_MouseMove(sender As Object, e As MouseEventArgs) Handles pic_preview.MouseMove
        Dim setOnlyWhen As Boolean = False
        Dim newX As Integer = e.Location.X - startPos.X
        Dim newY As Integer = e.Location.Y - startPos.Y
        If newX > 0 Then
            newX = Math.Floor(newX / m_zoom * 100)
        Else
            newX = Math.Ceiling(newX / m_zoom * 100)
        End If
        If newY > 0 Then
            newY = Math.Floor(newY / m_zoom * 100)
        Else
            newY = Math.Ceiling(newY / m_zoom * 100)
        End If


        'view stuff
        If e.Button = MouseButtons.Middle Then
            scrollPosition = New Point(scrollPosition.X + newX,
                                       scrollPosition.Y + newY)


            checkScrollbarPosition()

            setOnlyWhen = True

            'change object
        ElseIf Not Cursor = Cursors.Default And Not selectedObj = FrameChangeType.None And Not IsNothing(LFFrame) And e.Button = MouseButtons.Left Then
            Dim absoluteMousePosition As New Point(e.Location.X / m_zoom * 100, e.Location.Y / m_zoom * 100)
            absoluteMousePosition.X -= CenterPoint.X + scrollPosition.X
            absoluteMousePosition.Y -= CenterPoint.Y + scrollPosition.Y
            Dim selectedThing As bdy = Nothing

            If selectedObj = FrameChangeType.Bdy And selectedIndex >= 0 And selectedIndex < 5 And selectedIndex < LFFrame.Bodys.Count Then
                selectedThing = LFFrame.Bodys(selectedIndex)
            ElseIf selectedObj = FrameChangeType.Itr And selectedIndex >= 0 And selectedIndex < 5 And selectedIndex < LFFrame.Itrs.Count Then
                selectedThing = LFFrame.Itrs(selectedIndex)
            ElseIf selectedObj = FrameChangeType.Bdy Or selectedObj = FrameChangeType.Itr Then
                Exit Sub
            End If

            If selectedPos = SelectedPosition.Center Then
                If selectedObj = FrameChangeType.WPoint Then
                    LFFrame.WPoint.Loca.X = absoluteMousePosition.X + LFFrame.Center.X - selectedRelativPos.X
                    LFFrame.WPoint.Loca.Y = absoluteMousePosition.Y + LFFrame.Center.Y - selectedRelativPos.Y
                ElseIf selectedObj = FrameChangeType.BPoint Then
                    LFFrame.BPoint.X = absoluteMousePosition.X + LFFrame.Center.X - selectedRelativPos.X
                    LFFrame.BPoint.Y = absoluteMousePosition.Y + LFFrame.Center.Y - selectedRelativPos.Y
                ElseIf selectedObj = FrameChangeType.OPoint Then
                    LFFrame.OPoint.X = absoluteMousePosition.X + LFFrame.Center.X - selectedRelativPos.X
                    LFFrame.OPoint.Y = absoluteMousePosition.Y + LFFrame.Center.Y - selectedRelativPos.Y
                ElseIf selectedObj = FrameChangeType.CPoint Then
                    LFFrame.CPoint.X = absoluteMousePosition.X + LFFrame.Center.X - selectedRelativPos.X
                    LFFrame.CPoint.Y = absoluteMousePosition.Y + LFFrame.Center.Y - selectedRelativPos.Y
                ElseIf selectedObj = FrameChangeType.CenterXY Or selectedObj = FrameChangeType.CenterXY2 Then
                    LFFrame.Center.X = -absoluteMousePosition.X + selectedRelativPos.X
                    LFFrame.Center.Y = -absoluteMousePosition.Y + selectedRelativPos.Y
                ElseIf (selectedObj = FrameChangeType.Bdy Or selectedObj = FrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    selectedThing.Rect.X = absoluteMousePosition.X + LFFrame.Center.X - selectedRelativPos.X
                    selectedThing.Rect.Y = absoluteMousePosition.Y + LFFrame.Center.Y - selectedRelativPos.Y
                End If



            ElseIf selectedPos = SelectedPosition.Top Then
                If (selectedObj = FrameChangeType.Bdy Or selectedObj = FrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    Dim oldRectY As Integer = selectedThing.Rect.Y
                    Dim newRectY As Integer = absoluteMousePosition.Y + LFFrame.Center.Y
                    'selectedThing.Rect.Height += (oldHeight - selectedThing.Rect.Y)

                    Dim newHeight As Integer = selectedThing.Rect.Height + (oldRectY - newRectY)
                    If newHeight < 0 Then
                        newHeight = 0
                        selectedThing.Rect.Y = selectedThing.Rect.Height + (oldRectY - newHeight)
                        selectedPos = SelectedPosition.Bottom
                        selectedThing.Rect.Height = newHeight
                        Exit Sub
                    End If

                    selectedThing.Rect.Y = newRectY
                    selectedThing.Rect.Height = newHeight
                End If



            ElseIf selectedPos = SelectedPosition.Bottom Then
                If (selectedObj = FrameChangeType.Bdy Or selectedObj = FrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    Dim newHeight As Integer = (LFFrame.Center.Y + absoluteMousePosition.Y) - selectedThing.Rect.Y
                    If newHeight < 0 Then
                        selectedPos = SelectedPosition.Top
                        newHeight = 0
                    End If
                    selectedThing.Rect.Height = newHeight
                End If



            ElseIf selectedPos = SelectedPosition.Right Then
                If (selectedObj = FrameChangeType.Bdy Or selectedObj = FrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    Dim newWidth As Integer = (LFFrame.Center.X + absoluteMousePosition.X) - selectedThing.Rect.X
                    If newWidth < 0 Then
                        selectedPos = SelectedPosition.Left
                        newWidth = 0
                    End If
                    selectedThing.Rect.Width = newWidth
                End If



            ElseIf selectedPos = SelectedPosition.Left Then
                If (selectedObj = FrameChangeType.Bdy Or selectedObj = FrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    Dim oldRectX As Integer = selectedThing.Rect.X
                    Dim newRectX As Integer = absoluteMousePosition.X + LFFrame.Center.X

                    Dim newWidth As Integer = selectedThing.Rect.Width + (oldRectX - newRectX)
                    If newWidth < 0 Then
                        newWidth = 0
                        selectedThing.Rect.X = selectedThing.Rect.Width + (oldRectX - newWidth)
                        selectedPos = SelectedPosition.Right
                        selectedThing.Rect.Width = newWidth
                        Exit Sub
                    End If

                    selectedThing.Rect.X = newRectX
                    selectedThing.Rect.Width = newWidth
                End If




            ElseIf selectedPos = SelectedPosition.LeftTop Or selectedPos = SelectedPosition.RightTop Or
                   selectedPos = SelectedPosition.LeftBottom Or selectedPos = SelectedPosition.RightBottom Then

                Dim deltaPos As New Point(e.Location.X - selectedRelativPos.X,
                                          e.Location.Y - selectedRelativPos.Y)

                Dim newRect As New Rectangle(selectedRelativPos.X, selectedRelativPos.Y,
                                             deltaPos.X, deltaPos.Y)
                If deltaPos.X < 0 Then
                    newRect.X = e.Location.X
                    newRect.Width = Math.Abs(deltaPos.X)
                End If
                If deltaPos.Y < 0 Then
                    newRect.Y = e.Location.Y
                    newRect.Height = Math.Abs(deltaPos.Y)
                End If


                Dim picCenterXWithoutZoom As Integer = CenterPoint.X + scrollPosition.X
                Dim picCenterYWithoutZoom As Integer = CenterPoint.Y + scrollPosition.Y
                picCenterXWithoutZoom = (CenterPoint.X + scrollPosition.X) / 100 * m_zoom
                picCenterYWithoutZoom = (CenterPoint.Y + scrollPosition.Y) / 100 * m_zoom
                Dim relativPosition As New Point(picCenterXWithoutZoom - Math.Floor(LFFrame.Center.X / 100 * m_zoom), picCenterYWithoutZoom - Math.Floor(LFFrame.Center.Y / 100 * m_zoom))


                newRect.X = (newRect.X - relativPosition.X) / m_zoom * 100
                newRect.Y = (newRect.Y - relativPosition.Y) / m_zoom * 100
                newRect.Width = (newRect.Width / m_zoom * 100)
                newRect.Height = (newRect.Height / m_zoom * 100)

                selectedThing.Rect = New LFRect(newRect)
            End If

            If opt_directResult Then
                ThatWasMe = True
                RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(selectedObj, selectedIndex))
                ThatWasMe = False
            End If


            setOnlyWhen = True


            'get object under mouse
        ElseIf Not IsNothing(LFFrame) And e.Button = MouseButtons.None Then
            Dim isCenterXY2 As Boolean = selectedObj = FrameChangeType.CenterXY2
            selectedObj = FrameChangeType.None
            selectedRelativPos = New Point()

            Dim picCenterXWithoutZoom As Integer = CenterPoint.X + scrollPosition.X
            Dim picCenterYWithoutZoom As Integer = CenterPoint.Y + scrollPosition.Y
            picCenterXWithoutZoom = (CenterPoint.X + scrollPosition.X) / 100 * m_zoom
            picCenterYWithoutZoom = (CenterPoint.Y + scrollPosition.Y) / 100 * m_zoom
            Dim relativPosition As New Point(picCenterXWithoutZoom - Math.Floor(LFFrame.Center.X / 100 * m_zoom), picCenterYWithoutZoom - Math.Floor(LFFrame.Center.Y / 100 * m_zoom))


            While True
                'CENTER XY
                If debug_draw_centerXY Or isCenterXY2 Then
                    Dim drawPoint As New Point(relativPosition.X, relativPosition.Y)
                    Dim drawRect As New Rectangle(drawPoint.X - 3 / 100 * m_zoom, drawPoint.Y - 3 / 100 * m_zoom,
                              6 / 100 * m_zoom, 6 / 100 * m_zoom)

                    If isCenterXY2 Then
                        selectedRelativPos = GetRelativPosition(drawPoint, e.Location)
                        selectedObj = FrameChangeType.CenterXY2
                        Exit While
                    ElseIf drawRect.Contains(e.Location) Then
                        selectedRelativPos = GetRelativPosition(drawPoint, e.Location)
                        selectedObj = FrameChangeType.CenterXY
                        Exit While
                    End If
                End If

                'WEAPON POINT
                If debug_draw_wpoint And Not IsNothing(LFFrame.WPoint) Then
                    Dim weaponPoint As wpoint = LFFrame.WPoint
                    If Not IsNothing(weaponPoint) And Weapon.Frames.ContainsKey(weaponPoint.Weaponact) Then
                        Dim weaponFrame As LFFrame = Weapon.Frames(weaponPoint.Weaponact)

                        Dim drawPoint As New Point(relativPosition.X + Math.Floor(weaponPoint.Loca.X / 100 * m_zoom),
                                                   relativPosition.Y + Math.Floor(weaponPoint.Loca.Y / 100 * m_zoom))
                        Dim drawRect As New Rectangle(drawPoint.X - 2 / 100 * m_zoom, drawPoint.Y - 2 / 100 * m_zoom,
                                                      5 / 100 * m_zoom, 5 / 100 * m_zoom)

                        If drawRect.Contains(e.Location) Then
                            selectedObj = FrameChangeType.WPoint
                            selectedRelativPos = GetRelativPosition(drawPoint, e.Location)
                            Exit While
                        End If
                    End If
                End If

                'BPOINT
                If debug_draw_bpoint Then
                    If Not (Integer.MaxValue = LFFrame.BPoint.X AndAlso LFFrame.BPoint.Y) Then
                        Dim drawPoint As New Point(relativPosition.X + Math.Floor(LFFrame.BPoint.X / 100 * m_zoom),
                                                   relativPosition.Y + Math.Floor(LFFrame.BPoint.Y / 100 * m_zoom))
                        Dim drawRect As New Rectangle(drawPoint.X - 2 / 100 * m_zoom, drawPoint.Y - 2 / 100 * m_zoom,
                                                      5 / 100 * m_zoom, 5 / 100 * m_zoom)

                        If drawRect.Contains(e.Location) Then
                            selectedObj = FrameChangeType.BPoint
                            selectedRelativPos = GetRelativPosition(drawPoint, e.Location)
                            Exit While
                        End If
                    End If
                End If


                'OPOINT
                If debug_draw_opoint Then
                    If Not (Integer.MaxValue = LFFrame.OPoint.X AndAlso LFFrame.OPoint.Y) Then
                        Dim drawPoint As New Point(relativPosition.X + Math.Floor(LFFrame.OPoint.X / 100 * m_zoom),
                                                   relativPosition.Y + Math.Floor(LFFrame.OPoint.Y / 100 * m_zoom))
                        Dim drawRect As New Rectangle(drawPoint.X - 2 / 100 * m_zoom, drawPoint.Y - 2 / 100 * m_zoom,
                                                      5 / 100 * m_zoom, 5 / 100 * m_zoom)

                        If drawRect.Contains(e.Location) Then
                            selectedObj = FrameChangeType.OPoint
                            selectedRelativPos = GetRelativPosition(drawPoint, e.Location)
                            Exit While
                        End If
                    End If
                End If

                'CPOINT
                If debug_draw_cpoint Then
                    If Not (Integer.MaxValue = LFFrame.CPoint.X AndAlso LFFrame.CPoint.Y) Then
                        Dim drawPoint As New Point(relativPosition.X + Math.Floor(LFFrame.CPoint.X / 100 * m_zoom),
                                                   relativPosition.Y + Math.Floor(LFFrame.CPoint.Y / 100 * m_zoom))
                        Dim drawRect As New Rectangle(drawPoint.X - 2 / 100 * m_zoom, drawPoint.Y - 2 / 100 * m_zoom,
                                                      5 / 100 * m_zoom, 5 / 100 * m_zoom)

                        If drawRect.Contains(e.Location) Then
                            selectedObj = FrameChangeType.CPoint
                            selectedRelativPos = GetRelativPosition(drawPoint, e.Location)
                            Exit While
                        End If
                    End If
                End If

                'BODYS
                If debug_draw_bodys Then
                    For i As Integer = 0 To LFFrame.Bodys.Count - 1
                        Dim body As bdy = LFFrame.Bodys(i)
                        Dim drawRect As New Rectangle(relativPosition.X + Math.Floor(body.Rect.X / 100 * m_zoom),
                                                  relativPosition.Y + Math.Floor(body.Rect.Y / 100 * m_zoom),
                                                  body.Rect.Width,
                                                  body.Rect.Height)
                        drawRect.Width = drawRect.Width / 100 * m_zoom
                        drawRect.Height = drawRect.Height / 100 * m_zoom

                        If drawRect.Contains(e.Location) Then
                            selectedObj = FrameChangeType.Bdy
                            selectedIndex = i
                            selectedPos = getSelectedPosition(drawRect, e.Location)
                            selectedRelativPos = GetRelativPosition(drawRect, e.Location)

                            If selectedPos = SelectedPosition.LeftTop Then
                                selectedRelativPos = New Point(drawRect.X + drawRect.Width, drawRect.Y + drawRect.Height)
                            ElseIf selectedPos = SelectedPosition.LeftBottom Then
                                selectedRelativPos = New Point(drawRect.X + drawRect.Width, drawRect.Y)
                            ElseIf selectedPos = SelectedPosition.RightTop Then
                                selectedRelativPos = New Point(drawRect.X, drawRect.Y + drawRect.Height)
                            ElseIf selectedPos = SelectedPosition.RightBottom Then
                                selectedRelativPos = New Point(drawRect.X, drawRect.Y)
                            End If

                            Cursor = getCursor(selectedPos)
                            Exit While
                        End If
                    Next
                End If


                If debug_draw_itrs Then
                    For i As Integer = 0 To LFFrame.Itrs.Count - 1
                        Dim itr As itr = LFFrame.Itrs(i)
                        Dim drawRect As New Rectangle(relativPosition.X + Math.Floor(itr.Rect.X / 100 * m_zoom),
                                                  relativPosition.Y + Math.Floor(itr.Rect.Y / 100 * m_zoom),
                                                  itr.Rect.Width,
                                                  itr.Rect.Height)
                        drawRect.Width = drawRect.Width / 100 * m_zoom
                        drawRect.Height = drawRect.Height / 100 * m_zoom

                        If drawRect.Contains(e.Location) Then
                            selectedObj = FrameChangeType.Itr
                            selectedIndex = i
                            selectedPos = getSelectedPosition(drawRect, e.Location)
                            selectedRelativPos = GetRelativPosition(drawRect, e.Location)

                            If selectedPos = SelectedPosition.LeftTop Then
                                selectedRelativPos = New Point(drawRect.X + drawRect.Width, drawRect.Y + drawRect.Height)
                            ElseIf selectedPos = SelectedPosition.LeftBottom Then
                                selectedRelativPos = New Point(drawRect.X + drawRect.Width, drawRect.Y)
                            ElseIf selectedPos = SelectedPosition.RightTop Then
                                selectedRelativPos = New Point(drawRect.X, drawRect.Y + drawRect.Height)
                            ElseIf selectedPos = SelectedPosition.RightBottom Then
                                selectedRelativPos = New Point(drawRect.X, drawRect.Y)
                            End If

                            Cursor = getCursor(selectedPos)
                            Exit While
                        End If
                    Next
                End If
                Exit While
            End While

            If Not selectedObj = FrameChangeType.None And Not selectedObj = FrameChangeType.Itr And Not selectedObj = FrameChangeType.Bdy Then
                selectedPos = SelectedPosition.Center
                Cursor = Cursors.SizeAll
            ElseIf selectedObj = FrameChangeType.None Then
                Cursor = Cursors.Default
            End If
        End If



        If Not setOnlyWhen Or m_zoom = 100 Then
            startPos = e.Location
        Else
            If Math.Abs(newX) >= 1 Then
                startPos.X = e.Location.X
            End If
            If Math.Abs(newY) >= 1 Then
                startPos.Y = e.Location.Y
            End If
        End If
    End Sub

    Private Sub pic_preview_MouseUp(sender As Object, e As MouseEventArgs) Handles pic_preview.MouseUp
        If Not IsNothing(LFFrame) And Not e.Button = MouseButtons.Middle Then
            Dim selectedThing As bdy = Nothing

            If selectedObj = FrameChangeType.Bdy And selectedIndex >= 0 And selectedIndex < 5 And selectedIndex < LFFrame.Bodys.Count Then
                selectedThing = LFFrame.Bodys(selectedIndex)
            ElseIf selectedObj = FrameChangeType.Itr And selectedIndex >= 0 And selectedIndex < 5 < LFFrame.Itrs.Count Then
                selectedThing = LFFrame.Itrs(selectedIndex)
            ElseIf selectedObj = FrameChangeType.Bdy Or selectedObj = FrameChangeType.Itr Then
                Exit Sub
            End If

            If Not IsNothing(selectedThing) Then
                If selectedThing.Rect.Width = 0 Or selectedThing.Rect.Height = 0 Then
                    RaiseEvent FrameViewerWillDelete(LFFrame, New class_customEventArgs(selectedObj, selectedIndex))
                    Exit Sub
                End If
            End If

            If Not opt_directResult Then
                ThatWasMe = True
                RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(selectedObj, selectedIndex))
                ThatWasMe = False
            End If
        End If
    End Sub

    Private Function getSelectedPosition(ByVal rect As Rectangle, ByVal poi As Point) As SelectedPosition
        Dim tolerance As Integer = 5
        If Math.Abs(rect.X - poi.X) < tolerance And Math.Abs(rect.Y - poi.Y) < tolerance Then
            Return SelectedPosition.LeftTop
        ElseIf Math.Abs(rect.X + rect.Width - poi.X) < tolerance And Math.Abs(rect.Y - poi.Y) < tolerance Then
            Return SelectedPosition.RightTop

        ElseIf Math.Abs(rect.X - poi.X) < tolerance And Math.Abs(rect.Y + rect.Height - poi.Y) < tolerance Then
            Return SelectedPosition.LeftBottom
        ElseIf Math.Abs(rect.X + rect.Width - poi.X) < tolerance And Math.Abs(rect.Y + rect.Height - poi.Y) < tolerance Then
            Return SelectedPosition.RightBottom

        ElseIf Math.Abs(rect.X - poi.X) < tolerance Then
            Return SelectedPosition.Left
        ElseIf Math.Abs(rect.X + rect.Width - poi.X) < tolerance Then
            Return SelectedPosition.Right

        ElseIf Math.Abs(rect.Y - poi.Y) < tolerance Then
            Return SelectedPosition.Top
        ElseIf Math.Abs(rect.Y + rect.Height - poi.Y) < tolerance Then
            Return SelectedPosition.Bottom
        End If

        Return SelectedPosition.Center
    End Function

    Private Function getCursor(ByVal pos As SelectedPosition) As Cursor
        Dim tolerance As Integer = 5
        If pos = SelectedPosition.LeftTop Or pos = SelectedPosition.RightBottom Then
            Return Cursors.SizeNWSE
        ElseIf pos = SelectedPosition.RightTop Or pos = SelectedPosition.LeftBottom Then
            Return Cursors.SizeNESW
        ElseIf pos = SelectedPosition.Left Or pos = SelectedPosition.Right Then
            Return Cursors.SizeWE
        ElseIf pos = SelectedPosition.Top Or pos = SelectedPosition.Bottom Then
            Return Cursors.SizeNS
        End If

        Return Cursors.SizeAll
    End Function


    Private Enum SelectedPosition
        LeftTop
        Top
        RightTop
        Left
        Center
        Right
        LeftBottom
        Bottom
        RightBottom
    End Enum

    Public Function GetRelativPosition(ByVal rect As Rectangle, ByVal pos As Point) As Point
        Return New Point((pos.X - rect.X) / m_zoom * 100, (pos.Y - rect.Y) / m_zoom * 100)
    End Function

    Public Function GetRelativPosition(ByVal pot As Point, ByVal pos As Point) As Point
        Return New Point((pos.X - pot.X) / m_zoom * 100, (pos.Y - pot.Y) / m_zoom * 100)
    End Function

    Private Sub checkScrollbarPosition()
        Dim maxViewY As Point = Me.maxViewY
        Dim maxViewX As Point = Me.maxViewX

        Dim picSizeWithWithoutZoom As Size = New Point(pic_preview.Width / m_zoom * 100, pic_preview.Height / m_zoom * 100)

        Dim viewXPositive As Integer = scrollPosition.X + CenterPoint.X - picSizeWithWithoutZoom.Width
        Dim viewXNegative As Integer = scrollPosition.X + CenterPoint.X
        Dim viewYPositive As Integer = scrollPosition.Y + CenterPoint.Y - picSizeWithWithoutZoom.Height
        Dim viewYNegative As Integer = scrollPosition.Y + CenterPoint.Y


        If picSizeWithWithoutZoom.Height > maxViewY.X + maxViewY.Y Then
            maxViewY = New Point(picSizeWithWithoutZoom.Height, picSizeWithWithoutZoom.Height)
        End If
        If picSizeWithWithoutZoom.Width > maxViewX.X + maxViewX.Y Then
            maxViewX = New Point(picSizeWithWithoutZoom.Width * 6 / 4, picSizeWithWithoutZoom.Width * 6 / 4)
        End If
        If viewXPositive < -maxViewX.X Then '< coz both are negative...
            scrollPosition.X = -(CenterPoint.X - picSizeWithWithoutZoom.Width + maxViewX.X)
        ElseIf viewXNegative > maxViewX.Y Then
            scrollPosition.X = maxViewX.Y - CenterPoint.X
        End If
        If viewYPositive < -maxViewY.X Then '< coz both are negative...
            scrollPosition.Y = -(CenterPoint.Y - picSizeWithWithoutZoom.Height + maxViewY.X)
        ElseIf viewYNegative > maxViewY.Y Then
            scrollPosition.Y = maxViewY.Y - CenterPoint.Y
        End If

        If isGlobalSettingsEnable Then
            RaiseEvent GlobalSettingsChanged("scrollPosition", New class_customEventArgs(scrollPosition, ID))
        End If
    End Sub
#End Region

#Region "View Options Stuff"
#Region "View"
    Private Sub TSMI_showScales_Click(sender As Object, e As EventArgs) Handles TSMI_showScales.Click, cb_showScales.CheckedChanged
        debug_draw_scales = getBoolValue(sender)
    End Sub

    Private Sub TSMI_resetView_Click(sender As Object, e As EventArgs) Handles TSMI_resetView.Click
        scrollPosition = New Point(0, 0)
        CenterPoint = New Point((pic_preview.Width / 2) / m_zoom * 100, (pic_preview.Height / 2) / m_zoom * 100 + (80 / m_zoom * 100))
        If isGlobalSettingsEnable Then
            RaiseEvent GlobalSettingsChanged("scrollPosition", New class_customEventArgs(scrollPosition, ID))
            RaiseEvent GlobalSettingsChanged("centerPoint", New class_customEventArgs(CenterPoint, ID))
        End If
    End Sub

    Private Sub TSMI_axis_Click(sender As Object, e As EventArgs) Handles TSMI_axis.Click, cb_axis.CheckedChanged
        debug_draw_axis = getBoolValue(sender)
    End Sub

    Private Sub TSMI_mirrorFrame_data_Click(sender As Object, e As EventArgs) Handles TSMI_mirrorFrame_data.Click
        tool_mirrorFrame()
    End Sub

    Private Sub TSMI_mirrorFrame_Click(sender As Object, e As EventArgs) Handles TSMI_mirrorFrame.Click
        If Not IsNothing(LFFrame) Then
            LFFrame.Facing = TSMI_mirrorFrame.Checked
            If m_editor.IDToFacing.ContainsKey(LFFrame.ID) Then
                m_editor.IDToFacing(LFFrame.ID) = LFFrame.Facing
            Else
                m_editor.IDToFacing.Add(LFFrame.ID, LFFrame.Facing)
            End If
        End If
    End Sub

    Private Sub TSMI_auto_bdy_Click(sender As Object, e As EventArgs) Handles TSMI_auto_bdy.Click
        If Not IsNothing(LFFrame) Then
            Dim LFimg As Bitmap = m_bitmaps(LFFrame.PicID)

            If Not IsNothing(LFimg) Then
                Dim rect As Rectangle = AutoBdy.createBody(LFimg)
                LFFrame.Bodys.Add(New bdy() With {.Rect = New LFRect(rect.X, rect.Y, rect.Width, rect.Height)})
                RaiseEvent FrameViewerWillAdd(FrameChangeType.Bdy, New class_customEventArgs(rect))
            End If
        End If
    End Sub

    Dim updating As Boolean = False
    Private Sub TSMI_bg_image_CheckedChanged(sender As Object, e As EventArgs) Handles TSMI_bg_image.CheckedChanged
        If Not updating Then
            updating = True
            TSMI_bg_color.Checked = Not TSMI_bg_image.Checked
            updating = False
        End If

        If Not IsNothing(pic_preview.BackgroundImage) Then
            pic_preview.BackgroundImage.Dispose()
        End If

        If TSMI_bg_image.Checked Then
            pic_preview.BackgroundImage = My.Resources.bg_transparent
        Else
            pic_preview.BackgroundImage = Nothing
        End If
    End Sub

    Private Sub TSMI_bg_color_CheckedChanged(sender As Object, e As EventArgs) Handles TSMI_bg_color.CheckedChanged
        If Not updating Then
            updating = True
            TSMI_bg_image.Checked = Not TSMI_bg_color.Checked
            updating = False
        End If
    End Sub

    Private Sub TSMI_bg_color_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_background.DropDownOpening
        If Not IsNothing(TSMI_bg_color.Image) Then
            TSMI_bg_color.Image.Dispose()
        End If

        Dim newB As New Bitmap(20, 20)
        Using grap As Graphics = Graphics.FromImage(newB)
            grap.Clear(pic_preview.BackColor)
            grap.Dispose()
        End Using
        TSMI_bg_color.Image = newB
    End Sub

    Private Sub TSMI_bg_col_set_Click(sender As Object, e As EventArgs) Handles TSMI_bg_col_set.Click
        cd_bg.Color = pic_preview.BackColor
        If cd_bg.ShowDialog = DialogResult.OK Then
            pic_preview.BackColor = cd_bg.Color
            TSMI_bg_image.Checked = False
        End If
    End Sub
#End Region

#Region "Character View"
    Private Sub TSMI_bodies_Click(sender As Object, e As EventArgs) Handles TSMI_bodies.Click, cb_bodies.CheckedChanged
        debug_draw_bodys = getBoolValue(sender)
    End Sub

    Private Sub TSMI_itrs_Click(sender As Object, e As EventArgs) Handles TSMI_itrs.Click, cb_itrs.CheckedChanged
        debug_draw_itrs = getBoolValue(sender)
    End Sub

    Private Sub TSMI_wpoint_Click(sender As Object, e As EventArgs) Handles TSMI_wpoint.Click, cb_wpoint.CheckedChanged
        debug_draw_wpoint = getBoolValue(sender)
    End Sub

    Private Sub cb_wpoint_CheckedChanged(sender As Object, e As EventArgs) Handles cb_wpoint.CheckedChanged
        cb_weapon.Enabled = getBoolValue(sender) 'cb_wpoint.Checked
    End Sub

    Private Sub TSMI_weapon_Click(sender As Object, e As EventArgs) Handles TSMI_weapon.Click, cb_weapon.CheckedChanged
        debug_draw_weapon = getBoolValue(sender)
    End Sub

    Private Sub cb_wHitbox_CheckedChanged(sender As Object, e As EventArgs) Handles TSMI_wHitbox.Click, cb_wHitbox.CheckedChanged
        debug_draw_weaponBoxes = getBoolValue(sender)
    End Sub

    Private Sub TSMI_bpoint_Click(sender As Object, e As EventArgs) Handles TSMI_bpoint.Click, cb_bpoint.CheckedChanged
        debug_draw_bpoint = getBoolValue(sender)
    End Sub

    Private Sub TSMI_opoint_Click(sender As Object, e As EventArgs) Handles TSMI_opoint.Click, cb_opoint.CheckedChanged
        debug_draw_opoint = getBoolValue(sender)
    End Sub

    Private Sub TSMI_cpoint_Click(sender As Object, e As EventArgs) Handles TSMI_cpoint.Click, cb_cpoint.CheckedChanged
        debug_draw_cpoint = getBoolValue(sender)
    End Sub

    Private Sub TSMI_shadow_Click(sender As Object, e As EventArgs) Handles TSMI_shadow.Click, cb_shadow.CheckedChanged
        debug_draw_shadow = getBoolValue(sender)
    End Sub

    Private Sub TSMI_center_xy_Click(sender As Object, e As EventArgs) Handles TSMI_center_xy.Click, cb_center_xy.CheckedChanged
        debug_draw_centerXY = getBoolValue(sender)
    End Sub
#End Region

    Private Function getBoolValue(ByVal sender As Object) As Boolean
        Dim result As Boolean = False
        If TypeOf (sender) Is ToolStripMenuItem Then
            result = CType(sender, ToolStripMenuItem).Checked
        ElseIf TypeOf (sender) Is CheckBox Then
            result = CType(sender, CheckBox).Checked
        End If
        If isGlobalSettingsEnable Then
            RaiseEvent GlobalSettingsChanged(sender, New class_customEventArgs(result, ID))
        End If
        Return result
    End Function
#End Region

    Public Sub tool_mirrorFrame()
        If Not IsNothing(LFFrame) Then
            Dim imgWidth As Integer = -1
            For Each clsBit As class_bitmapFile In m_newBitmapFiles
                If LFFrame.PicID >= clsBit.IndexStart And LFFrame.PicID <= clsBit.IndexEnd Then
                    imgWidth = clsBit.Width
                End If
            Next

            If imgWidth < 0 Then
                For Each clsBit As class_bitmapFile In m_bitmapsFiles
                    If LFFrame.PicID >= clsBit.IndexStart And LFFrame.PicID <= clsBit.IndexEnd Then
                        imgWidth = clsBit.Width
                    End If
                Next
            End If


            If imgWidth >= 0 Then
                ThatWasMe = True
                LFFrame.Center.X = imgWidth - LFFrame.Center.X
                RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(FrameChangeType.CenterXY, selectedIndex))

                For i As Integer = 0 To LFFrame.Bodys.Count - 1
                    LFFrame.Bodys(i).Rect.X = imgWidth - LFFrame.Bodys(i).Rect.Width - LFFrame.Bodys(i).Rect.X
                    RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(FrameChangeType.Bdy, i))
                Next
                For i As Integer = 0 To LFFrame.Itrs.Count - 1
                    LFFrame.Itrs(i).Rect.X = imgWidth - LFFrame.Itrs(i).Rect.Width - LFFrame.Itrs(i).Rect.X
                    RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(FrameChangeType.Itr, i))
                Next

                If Not IsNothing(LFFrame.WPoint) Then
                    LFFrame.WPoint.Loca.X = imgWidth - LFFrame.WPoint.Loca.X
                    LFFrame.WPoint.Weaponact = -LFFrame.WPoint.Weaponact + 56
                    RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(FrameChangeType.WPoint, 0))
                End If

                If Not (Integer.MaxValue = LFFrame.BPoint.X AndAlso LFFrame.BPoint.Y) Then
                    LFFrame.BPoint.X = imgWidth - LFFrame.BPoint.X
                    RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(FrameChangeType.BPoint, 0))
                End If
                If Not (Integer.MaxValue = LFFrame.OPoint.X AndAlso LFFrame.OPoint.Y) Then
                    LFFrame.OPoint.X = imgWidth - LFFrame.OPoint.X
                    RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(FrameChangeType.OPoint, 0))
                End If
                If Not (Integer.MaxValue = LFFrame.CPoint.X AndAlso LFFrame.CPoint.Y) Then
                    LFFrame.CPoint.X = imgWidth - LFFrame.CPoint.X
                    RaiseEvent FrameViewerWillChange(LFFrame, New class_customEventArgs(FrameChangeType.CPoint, 0))
                End If

                LFFrame.Facing = Not LFFrame.Facing
                If m_editor.IDToFacing.ContainsKey(LFFrame.ID) Then
                    m_editor.IDToFacing(LFFrame.ID) = LFFrame.Facing
                Else
                    m_editor.IDToFacing.Add(LFFrame.ID, LFFrame.Facing)
                End If
                TSMI_mirrorFrame.Checked = LFFrame.Facing


                ThatWasMe = False
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        End If
    End Sub
End Class
