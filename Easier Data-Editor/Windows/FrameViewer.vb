'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Text.RegularExpressions
Imports Easier_Data_Editor.LittleFighter

Public Class FrameViewer
    Inherits Translation.TranslatableDockContent
    Implements IUserItem

#Region "'Consts'"
    Private Shared ReadOnly MAX_VIEW_Y As New Point(300, 300)
    Private Shared ReadOnly MAX_VIEW_X As New Point(600, 600)

    Private Shared ReadOnly ZOOM_TO_BIG_STEP_X As New List(Of Integer) From {100, 100, 50, 50, 25, 25, 15, 15, 10}
    Private Shared ReadOnly ZOOM_TO_SMALL_STEP_X As New List(Of Integer) From {10, 5, 5, 5, 5, 5, 2, 2, 2}
    Private Shared ReadOnly ZOOM_TO_BIG_STEP_Y As New List(Of Integer) From {100, 100, 50, 50, 25, 25, 15, 15, 10}
    Private Shared ReadOnly ZOOM_TO_SMALL_STEP_Y As New List(Of Integer) From {10, 5, 5, 5, 5, 5, 2, 2, 2}

    'Private Shared ReadOnly FONT_BIG As New Font(FontFamily.GenericMonospace, 18, FontStyle.Bold, GraphicsUnit.Pixel)
    'Private Shared ReadOnly FONT_BIG_LOGO As New Font(FontFamily.GenericMonospace, 14, FontStyle.Regular, GraphicsUnit.Pixel)
    'Private Shared ReadOnly font_normal As New Font(FontFamily.GenericMonospace, 12, FontStyle.Bold, GraphicsUnit.Pixel)
    Private Shared ReadOnly FONT_SMALL As New Font(FontFamily.GenericMonospace, 10, FontStyle.Regular, GraphicsUnit.Pixel)
    Private Shared ReadOnly FONT_SELECTED As New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold, GraphicsUnit.Pixel)
    Private Shared ReadOnly FONT_COPYRIGHT As New Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular, GraphicsUnit.Pixel)

    Private Shared Shadow As Bitmap = My.Resources.shadow
    Private Shared Weapon As Weapon = Nothing
    Private Shared WeaponHeavy As Weapon = Nothing

    Private Shared ReadOnly CENTER_XY As New Rectangle(-2, -2, 5, 5)
    Private Shared ReadOnly SHADOW_SIZE As New Rectangle(0, 0, Shadow.Width, Shadow.Height)
    Private Shared ReadOnly SHADOW_MIDDLE As Single = Math.Floor(37 / 2)
    Private Shared ReadOnly SHADOW_MIDDLE_H As Single = Math.Floor(9 / 2)


    Private Const RECT_RADIUS As Integer = 2
#End Region

    Private m_LFFrame As Frame = Nothing
    Private m_id As Integer = New Random().Next(1, Integer.MaxValue)
    Private m_textEditor As TextEditor = Nothing
    Private m_startPos As New Point
    Private m_selectedObject As New SelectedObject
    Private m_behind3DRect As Boolean = False
    Private m_lastPosition As New Point(-1000, -1000)
    Private m_updatingViewSettings As Boolean = True

    Private WithEvents ViewSettings As FrameViewerSettings = App.Settings.Restorer


    Private m_newBitmapFiles As New List(Of FrameHeader) 'compares the two arrays
    Private m_bitmapsFiles As New List(Of FrameHeader)
    Private m_bitmaps As New List(Of IO.MemoryStream)

    Private CharacterPosition As New Point(0, 0)

    Private m_lastZoom As Integer = 100
    Private m_big1pixel As Integer = 1 'if zoom = 200 then 2; if zomm = 300 then 3...
    Private m_realPixelSize As Single = 1 'if zoom = 200 then 0.5... 
    Private m_bdyPen As New Pen(Color.FromArgb(100, Color.Blue), m_realPixelSize) With {.Alignment = PenAlignment.Outset}
    Private m_oPen As New Pen(Color.Magenta, m_realPixelSize) With {.Alignment = PenAlignment.Outset}
    Private m_cPen As New Pen(Color.Orange, m_realPixelSize) With {.Alignment = PenAlignment.Outset}
    Private m_itrPen As New Pen(Color.Red, m_realPixelSize) With {.Alignment = PenAlignment.Outset}
    Private m_itrPen2 As New Pen(Color.Chocolate, m_realPixelSize) With {.Alignment = PenAlignment.Outset}

    Private m_itrBrush As New SolidBrush(Color.FromArgb(35, Color.Red))
    Private m_itrBrush2 As New SolidBrush(Color.FromArgb(35, Color.Chocolate))
    Private m_ia As New Imaging.ImageAttributes

    Private lastFrameID As Integer = -1
    Private FrameImage As Bitmap = Nothing
    Private m_hasFocus As Boolean = False

    Private m_currentShowImage As Boolean = True

    Private ReadOnly m_undoItems As New List(Of UndoRedoItem) 'contains information that by undo/redo the frame will mirror (back to the original facing)

    Private m_bspriteIndex As Integer = -1
    Private ReadOnly m_trackbarOpacity As New TrackBar With {.Width = 150, .Minimum = 20, .Maximum = 100, .SmallChange = 20, .TickFrequency = 10, .Value = 100}
    Private ReadOnly m_bspriteNud As New NumericUpDown With {.Width = 150, .Minimum = -1000, .Maximum = 1000, .Value = 0}

    'in progress
    Private m_animationPreview As Boolean = False
    Private m_currentWait As Integer = 0

    Public ReadOnly IDToFacing As New Dictionary(Of Integer, Boolean)

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatableControls.Add(Me)
    End Sub

    Public Sub New(ByVal textEditor As TextEditor)
        SetVariables()
        InitializeComponent()

        Me.TextEditor = textEditor
        SubNew()
    End Sub

    Public Sub New(ByVal id As Integer)
        SetVariables()
        InitializeComponent()

        m_id = id
        SubNew()
    End Sub

    Public Shared Sub Prepare()
        Weapon = New Weapon()
        WeaponHeavy = New Weapon(True)
    End Sub

    Public ReadOnly Property ID As Integer Implements IUserItem.ID
        Get
            If Not IsNothing(m_textEditor) Then
                Return m_textEditor.ID
            Else
                Return m_id
            End If
        End Get
    End Property

    Public Property Path As String Implements IUserItem.Path
        Get
            If Not IsNothing(m_textEditor) Then
                Return m_textEditor.Path
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public WriteOnly Property HasFocus As Boolean Implements IUserItem.HasFocus
        Set(value As Boolean)
            'If Not value AndAlso App.Settings.GlobalView AndAlso Visible Then
            '    Tim_drawer.Enabled = True
            'Else

            'End If
            Tim_drawer.Enabled = value
            m_hasFocus = value

            'Tim_animation.Enabled = value
        End Set
    End Property

    Public Property TextEditor As TextEditor
        Get
            Return m_textEditor
        End Get
        Set(value As TextEditor)
            If Not IsNothing(m_textEditor) Then
                RemoveHandler m_textEditor.UndoRedoStackChanged, AddressOf UndoRedoStackChanged
            End If
            If Not IsNothing(value) Then
                Text = IO.Path.GetFileName(value.Path) & " [Frame Viewer]"
                ToolTipText = value.Path
                AddHandler value.UndoRedoStackChanged, AddressOf UndoRedoStackChanged
            Else
                Text = "New Frame Viewer"
                ToolTipText = Text
            End If

            m_textEditor = value
        End Set
    End Property

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        'ErrorList.lv_errors.Items.Add(Convert.ToInt64(keyData))
        If Not IsNothing(m_textEditor) Then
            Select Case keyData
                Case Keys.Down
                    m_textEditor.SetNextFrame()
                    Return True
                Case Keys.Up
                    m_textEditor.SetPreviousFrame()
                    Return True
                Case Keys.PageDown
                    m_textEditor.SetNextRealFrame(m_LFFrame.Next)
                    Return True
                Case Keys.PageUp
                    m_textEditor.SetPreviousRealFrame(m_LFFrame.ID)
                    Return True
                Case Keys.Control, Keys.ControlKey, (Keys.Control Or Keys.ControlKey)
                    If Not IsNothing(m_LFFrame) And Not m_selectedObject.Object = EFrameChangeType.CenterXY Then
                        SetCenterXY2()
                        Return True
                    End If
            End Select
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        'ErrorList.lv_errors.Items.Add(Convert.ToInt64(keyData))
        Select Case keyData
            Case Keys.Control, Keys.ControlKey, (Keys.Control Or Keys.ControlKey)
                If Not IsNothing(m_LFFrame) And Not m_selectedObject.Object = EFrameChangeType.CenterXY Then
                    SetCenterXY2()
                    Return True
                End If
        End Select
        Return MyBase.IsInputKey(keyData)
    End Function

    Private Sub SetCenterXY2()
        Dim posToCharacter As New Point(Math.Floor(Preview.PointToClient(MousePosition).X / ViewSettings.Zoom * 100),
                                        Math.Floor(Preview.PointToClient(MousePosition).Y / ViewSettings.Zoom * 100))

        m_selectedObject.Object = EFrameChangeType.CenterXY2
        m_selectedObject.RelativPosition = m_LFFrame.Center
        m_selectedObject.RelativPosition2 = posToCharacter
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub SetVariables()
        Variables.Add("selected", "Selected: ")
    End Sub

    Private Sub SubNew()
        AddHandler App.Settings.SettingsChanged, AddressOf SettingsChanged
        AddHandler m_trackbarOpacity.ValueChanged, Sub()
                                                       TB_Opacity.Value = m_trackbarOpacity.Value
                                                   End Sub
        AddHandler m_bspriteNud.ValueChanged, Sub()
                                                  Nud_bspriteIndex.Value = m_bspriteNud.Value
                                              End Sub
        ViewSettings = App.Settings.Restorer
        SettingsChanged(Me, True)
        If App.Settings.FrameViewerBGColor.Equals(Color.Transparent) Then
            TSMI_bg_color.Tag = Color.White
        Else
            TSMI_bg_color.Tag = App.Settings.FrameViewerBGColor
        End If
        SetBackgroundColor(App.Settings.FrameViewerBGColor)
        ViewSettings.BackgroundColor = App.Settings.FrameViewerBGColor

        Dim m_dropItems As New List(Of ToolStripItemCollection) From {MS_options.Items}
        Do While m_dropItems.Count > 0
            Dim items As ToolStripItemCollection = m_dropItems(0)
            For Each tsmi As ToolStripItem In items
                If TypeOf tsmi Is ToolStripMenuItem Then
                    If CType(tsmi, ToolStripMenuItem).DropDownItems.Count > 0 Then
                        m_dropItems.Add(CType(tsmi, ToolStripMenuItem).DropDownItems)
                        AddHandler CType(tsmi, ToolStripMenuItem).DropDown.Closing, AddressOf DontCloseEvent
                    End If
                End If
            Next

            m_dropItems.RemoveAt(0)
        Loop
        Dim tsHost As New ToolStripControlHost(m_trackbarOpacity)
        TSMI_opacity.DropDownItems.Add(tsHost)

        Dim tsHost2 As New ToolStripControlHost(m_bspriteNud)
        TSMI_drawBSprite.DropDownItems.Add(tsHost2)

        m_updatingViewSettings = False
    End Sub

    Private Sub SettingsChanged(ByVal sender As Object, ByVal e As Boolean)
        If Not sender.Equals(App.Settings) AndAlso Not sender.Equals(Me) Then Exit Sub
        MS_options.Visible = App.Settings.FrameViewerMenuStrip
        Pal_charView.Visible = Not MS_options.Visible

        Dim refreshGuiElements As Boolean = False
        If Not App.Settings.GlobalView Then
            If ViewSettings.Equals(App.Settings.Restorer) Then
                ViewSettings = New FrameViewerSettings()
                refreshGuiElements = True
            End If
        ElseIf Not ViewSettings.Equals(App.Settings.Restorer) Then
            'viewSettings.Close or something?
            ViewSettings = App.Settings.Restorer
            refreshGuiElements = True
        End If

        If refreshGuiElements Or Not IsNothing(sender) AndAlso sender.Equals(Me) Then
            m_updatingViewSettings = True

            Cb_axis.Checked = ViewSettings.Axis
            TSMI_axis.Checked = ViewSettings.Axis
            Cb_center_xy.Checked = ViewSettings.CenterXY
            TSMI_center_xy.Checked = ViewSettings.CenterXY
            Cb_shadow.Checked = ViewSettings.Shadow
            TSMI_shadow.Checked = ViewSettings.Shadow
            Cb_bodies.Checked = ViewSettings.Bodies
            TSMI_bodies.Checked = ViewSettings.Bodies
            Cb_itrs.Checked = ViewSettings.Itrs
            TSMI_itrs.Checked = ViewSettings.Itrs
            TSMI_itr_3d.Checked = ViewSettings.Itr3D
            Cb_wpoint.Checked = ViewSettings.WPoint
            TSMI_wpoint.Checked = ViewSettings.WPoint
            Cb_weapon.Checked = ViewSettings.Weapon
            TSMI_weapon.Checked = ViewSettings.Weapon
            Cb_wHitbox.Checked = ViewSettings.WeaponHitboxes
            TSMI_wHitbox.Checked = ViewSettings.WeaponHitboxes
            Cb_bpoint.Checked = ViewSettings.BPoint
            TSMI_bpoint.Checked = ViewSettings.BPoint
            Cb_opoint.Checked = ViewSettings.OPoint
            TSMI_opoint.Checked = ViewSettings.OPoint
            Cb_cpoint.Checked = ViewSettings.CPoint
            TSMI_cpoint.Checked = ViewSettings.CPoint
            Cb_showScales.Checked = ViewSettings.Scales
            TSMI_showScales.Checked = ViewSettings.Scales
            Cb_Fill.Checked = ViewSettings.FillRectangles
            TSMI_Fill.Checked = ViewSettings.FillRectangles
            m_trackbarOpacity.Value = ViewSettings.CharacterOpacity
            Cb_drawBSprite.Checked = ViewSettings.DrawBSprite
            TSMI_drawBSprite.Checked = ViewSettings.DrawBSprite

            ViewSettings_ZoomStateChanged(ViewSettings, True)

            m_updatingViewSettings = False
        End If

        If IsNothing(Weapon) OrElse Not Weapon.DataPath.Equals(App.Settings.WeaponData) OrElse Not Weapon.SpritePath.Equals(App.Settings.WeaponSprite) Then
            Weapon = New Weapon()
        End If

        If IsNothing(WeaponHeavy) OrElse Not WeaponHeavy.DataPath.Equals(App.Settings.HeavyWeaponData) OrElse Not WeaponHeavy.SpritePath.Equals(App.Settings.HeavyWeaponSprite) Then
            WeaponHeavy = New Weapon(True)
        End If
        Preview.Invalidate()
    End Sub

    Private Sub UndoRedoStackChanged(ByVal sender As Object, ByVal e As Boolean)
        For Each item As UndoRedoItem In m_undoItems
            If item.StackIndex > m_textEditor.Scintilla1.UndoSize + 1 Then
                item.IsUndo = False
            End If
        Next

        If Not e Then
            For Each item As UndoRedoItem In m_undoItems
                If item.IsUndo = e AndAlso item.StackIndex = m_textEditor.Scintilla1.UndoSize Then
                    If IDToFacing.ContainsKey(item.FrameIndex) Then
                        IDToFacing(item.FrameIndex) = Not IDToFacing(item.FrameIndex)
                        m_LFFrame.Facing = IDToFacing(item.FrameIndex)
                    End If

                    item.IsUndo = Not item.IsUndo
                End If
            Next
        End If

        If Not m_textEditor.CanRedo Then
            Dim index As Integer = 0
            Do While index < m_undoItems.Count
                If Not m_undoItems(index).IsUndo Then
                    m_undoItems.RemoveAt(index)
                Else
                    index += 1
                End If
            Loop
        End If

        If e Then
            For Each item As UndoRedoItem In m_undoItems
                If item.IsUndo = e AndAlso item.StackIndex = m_textEditor.Scintilla1.UndoSize + 1 Then
                    If IDToFacing.ContainsKey(item.FrameIndex) Then
                        IDToFacing(item.FrameIndex) = Not IDToFacing(item.FrameIndex)
                        m_LFFrame.Facing = IDToFacing(item.FrameIndex)
                    End If

                    item.IsUndo = Not item.IsUndo
                End If
            Next
        End If
    End Sub

#Region "Own Events"
    Private Sub VisibleChanged_(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        MS_options.Visible = App.Settings.FrameViewerMenuStrip
        Pal_charView.Visible = Not MS_options.Visible

        If Visible Then
            CheckMyBitmaps()
        End If
        Tim_drawer.Enabled = Visible
        Tim_animation.Enabled = Visible
    End Sub
#End Region

#Region "Preview Events"
    Private Sub Tim_drawer_Tick(sender As Object, e As EventArgs) Handles Tim_drawer.Tick
        Preview.Invalidate()
        If Not m_hasFocus Then Tim_drawer.Stop()
    End Sub

    'in progress
    Private Sub Tim_animation_Tick(sender As Object, e As EventArgs) Handles Tim_animation.Tick
        If Not IsNothing(m_LFFrame) Then
            If m_animationPreview Then
                CharacterPosition.X += m_LFFrame.DvX
                CharacterPosition.Y += m_LFFrame.DvY

                If m_currentWait < 0 Then
                    If m_LFFrame.Next = 999 Or m_LFFrame.Next = 1000 Then
                        m_animationPreview = False
                    Else
                        'If Not IsNothing(MainWindow) Then
                        '    'Dim editor As ui_textEditor = MainWindow.GetTextEditorFromID(ID)
                        '    'If Not IsNothing(editor) Then
                        '    '    editor.GoToFrame(LFFrame.Next)
                        '    'End If
                        'End If
                    End If
                Else
                    m_currentWait -= 1
                End If
            End If
        End If
    End Sub

    'Private m_lastTime As Date = Date.Now
    Private Sub Preview_Paint(sender As Object, e As PaintEventArgs) Handles Preview.Paint
        If Not ViewSettings.Zoom = m_lastZoom Then
            m_big1pixel = ViewSettings.Zoom / 100
            m_realPixelSize = 100 / ViewSettings.Zoom
            m_bdyPen.Width = m_realPixelSize
            m_oPen.Width = m_realPixelSize
            m_cPen.Width = m_realPixelSize
            m_itrPen.Width = m_realPixelSize
            m_itrPen2.Width = m_realPixelSize

            m_lastZoom = ViewSettings.Zoom
        End If

        Try
            Dim isControlPressed As Boolean = (KeyInformation.IsKeyPressed(Keys.Control) Or KeyInformation.IsKeyPressed(Keys.ControlKey) Or KeyInformation.IsKeyPressed(Keys.Control Or Keys.ControlKey))
            With e.Graphics
                .PixelOffsetMode = PixelOffsetMode.Half
                .InterpolationMode = InterpolationMode.NearestNeighbor
                .SmoothingMode = SmoothingMode.None
                .TextRenderingHint = TextRenderingHint.ClearTypeGridFit


                .CompositingQuality = CompositingQuality.Default

                Dim picCenterX As Single = ViewSettings.CenterPoint.X + ViewSettings.ScrollPosition.X
                Dim picCenterY As Single = ViewSettings.CenterPoint.Y + ViewSettings.ScrollPosition.Y
                Dim picCenterXWithoutZoom As Single = picCenterX * m_big1pixel
                Dim picCenterYWithoutZoom As Single = picCenterY * m_big1pixel


                If ViewSettings.Axis Then
                    If picCenterXWithoutZoom >= 0 And picCenterXWithoutZoom <= e.ClipRectangle.Width Then
                        .DrawLine(Pens.Gray, picCenterXWithoutZoom, 0, picCenterXWithoutZoom, e.ClipRectangle.Height)
                    End If

                    If picCenterYWithoutZoom >= 0 And picCenterYWithoutZoom <= e.ClipRectangle.Height Then
                        .DrawLine(Pens.Gray, 0, picCenterYWithoutZoom, e.ClipRectangle.Width, picCenterYWithoutZoom)
                    End If

                    If picCenterXWithoutZoom + picCenterYWithoutZoom >= 0 And picCenterXWithoutZoom + picCenterYWithoutZoom <= e.ClipRectangle.Width + e.ClipRectangle.Height Then
                        .DrawLine(Pens.Gray, picCenterXWithoutZoom + picCenterYWithoutZoom, 0, 0, picCenterXWithoutZoom + picCenterYWithoutZoom)
                    End If
                End If


                If Not IsNothing(m_LFFrame) Then
                    If Not m_LFFrame.PicID = lastFrameID Or IsNothing(FrameImage) Then
                        If Not IsNothing(FrameImage) Then FrameImage.Dispose()
                        FrameImage = Nothing

                        If m_LFFrame.PicID < m_bitmaps.Count Then
                            FrameImage = New Bitmap(m_bitmaps(m_LFFrame.PicID))
                            lastFrameID = m_LFFrame.PicID
                        End If
                    End If

                    .ScaleTransform(m_big1pixel, m_big1pixel)
                    Dim relativPosition As New PointF(picCenterX - m_LFFrame.Center.X + CharacterPosition.X, picCenterY - m_LFFrame.Center.Y + CharacterPosition.Y)
                    Dim oldPos As PointF = relativPosition
                    relativPosition.X = GetRightValue(relativPosition.X)
                    relativPosition.Y = GetRightValue(relativPosition.Y)
                    .TranslateTransform(relativPosition.X, relativPosition.Y, MatrixOrder.Prepend)

                    If Math.Abs(relativPosition.X - oldPos.X) > m_realPixelSize Then
                        Console.WriteLine("STOP")
                    End If

                    If Math.Abs(relativPosition.Y - oldPos.Y) > m_realPixelSize Then
                        Console.WriteLine("STOP")
                    End If


                    If ViewSettings.Shadow Then
                        .DrawImage(Shadow, New Rectangle(m_LFFrame.Center.X - SHADOW_MIDDLE,
                                           m_LFFrame.Center.Y - SHADOW_MIDDLE_H, Shadow.Width, Shadow.Height),
                                           SHADOW_SIZE, GraphicsUnit.Pixel)
                    End If
                    Dim weaponPoint As WPoint = Nothing
                    Dim weaponFrame As Frame = Nothing

                    'WEAPON
                    If ViewSettings.WPoint Then
                        If Not IsNothing(m_LFFrame.WPoint) Then
                            Dim heavyWeaponImg As Boolean = (m_LFFrame.ID >= 12 And m_LFFrame.ID < 20 Or m_LFFrame.ID >= 50 And m_LFFrame.ID <= 51 Or m_LFFrame.ID >= 116 And m_LFFrame.ID <= 117)

                            weaponPoint = m_LFFrame.WPoint
                            If Not heavyWeaponImg Then
                                If Weapon.Frames.ContainsKey(weaponPoint.Weaponact) Then
                                    weaponFrame = Weapon.Frames(weaponPoint.Weaponact)
                                End If
                            ElseIf WeaponHeavy.Frames.ContainsKey(weaponPoint.Weaponact) Then
                                weaponFrame = WeaponHeavy.Frames(weaponPoint.Weaponact)
                            End If

                            If ViewSettings.Weapon Then
                                If weaponPoint.Cover Then
                                    If Not IsNothing(weaponFrame) Then
                                        If Not IsNothing(weaponFrame.WPoint) Then
                                            Dim drawPoint As New Point(weaponPoint.Loca.X, weaponPoint.Loca.Y)
                                            If Not IsNothing(weaponFrame.Image) Then
                                                .DrawImage(weaponFrame.Image, New Point(drawPoint.X - weaponFrame.WPoint.Loca.X, drawPoint.Y - weaponFrame.WPoint.Loca.Y))
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    End If

                    '3D itrs
                    If ViewSettings.Itrs And ViewSettings.Itr3D Then
                        For Each itr As Itr In m_LFFrame.Itrs
                            Dim paths As ItrPathResult = itr.GetItrPaths(True, m_realPixelSize)
                            Dim rectF As RectangleF = GetRectFToDraw(paths.Rect, True)

                            Dim itrBrushCol As SolidBrush = m_itrBrush ' = itr.Kind <> 0
                            Dim itrPenCol As Pen = m_itrPen

                            If itr.Kind <> 0 Then
                                itrBrushCol = m_itrBrush2
                                itrPenCol = m_itrPen2
                            End If

                            If ViewSettings.FillRectangles Then
                                .FillPath(itrBrushCol, paths.Path1)
                                .FillPath(itrBrushCol, paths.Path2)
                                .FillRectangle(itrBrushCol, paths.Rect)
                            End If

                            .DrawPath(itrPenCol, paths.Path1)
                            .DrawRectangle(itrPenCol, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                        Next
                    End If


                    'MAIN CHARACTER
                    If Not IsNothing(FrameImage) AndAlso Not ViewSettings.DrawBSprite Then
                        If m_LFFrame.Facing Then
                            Dim newBitmap As Bitmap = FrameImage.Clone
                            newBitmap.RotateFlip(RotateFlipType.Rotate180FlipY)
                            .DrawImage(newBitmap, New Rectangle(New Point(), newBitmap.Size), 0, 0, newBitmap.Width, newBitmap.Height, GraphicsUnit.Pixel, m_ia)
                            newBitmap.Dispose()
                        Else
                            .DrawImage(FrameImage, New Rectangle(New Point(), FrameImage.Size), 0, 0, FrameImage.Width, FrameImage.Height, GraphicsUnit.Pixel, m_ia)
                        End If
                    End If

                    Dim drawBSpriteExists As Boolean = m_LFFrame.PicID + Nud_bspriteIndex.Value < m_bitmaps.Count
                    'MAIN CHARACTER 2
                    If ViewSettings.DrawBSprite AndAlso drawBSpriteExists Then
                        Dim frame2 As New Bitmap(m_bitmaps(m_LFFrame.PicID + Nud_bspriteIndex.Value))

                        If m_LFFrame.Facing Then
                            frame2.RotateFlip(RotateFlipType.Rotate180FlipY)
                        End If
                        .DrawImage(frame2, New Rectangle(New Point(), frame2.Size), 0, 0, frame2.Width, frame2.Height, GraphicsUnit.Pixel, m_ia)

                        frame2.Dispose()
                    End If



                    'BLOOD
                    If ViewSettings.BPoint Then
                        If Not m_LFFrame.BPoint.X = Integer.MaxValue And Not m_LFFrame.BPoint.Y = Integer.MaxValue Then
                            Dim drawRect As New Point(m_LFFrame.BPoint.X, m_LFFrame.BPoint.Y)
                            If m_LFFrame.Facing Then
                                drawRect.X += 1
                            End If
                            .FillRectangle(Brushes.Red, New Rectangle(drawRect, New Size(1, 3)))
                        End If
                    End If


                    'BODIES
                    If ViewSettings.Bodies Then
                        For Each body As Bdy In m_LFFrame.Bodys
                            If ViewSettings.FillRectangles Then .FillRectangle(New SolidBrush(Color.FromArgb(60, Color.Blue)), body.Rect.GetRect)

                            Dim rectF As RectangleF = GetRectFToDraw(body.Rect.GetRect, True)
                            .DrawRectangle(m_bdyPen, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                        Next
                    End If

                    'WEAPON 2
                    If ViewSettings.WPoint Then

                        If Not IsNothing(weaponFrame) Then
                            If Not IsNothing(weaponFrame.WPoint) Then
                                If ViewSettings.Weapon AndAlso Not weaponPoint.Cover Then
                                    If Not IsNothing(weaponFrame.Image) Then
                                        Dim drawPoint As New Point(weaponPoint.Loca.X, weaponPoint.Loca.Y)
                                        .DrawImage(weaponFrame.Image, New Point(drawPoint.X - weaponFrame.WPoint.Loca.X, drawPoint.Y - weaponFrame.WPoint.Loca.Y))
                                    End If
                                End If


                                If ViewSettings.WeaponHitboxes Then
                                    For Each itr As Itr In weaponFrame.Itrs
                                        Dim itrColor As Color = Color.Red
                                        Dim drawRectR As RectangleF = GetRectFToDraw(New Rectangle(weaponPoint.Loca.X - weaponFrame.WPoint.Loca.X + itr.Rect.X,
                                                                                                   weaponPoint.Loca.Y - weaponFrame.WPoint.Loca.Y + itr.Rect.Y + If(weaponPoint.Cover, 2, 0),
                                                                                                   itr.Rect.Width, itr.Rect.Height), True)
                                        If itr.Kind <> 0 Then
                                            itrColor = Color.Chocolate
                                        End If
                                        .DrawRectangle(New Pen(itrColor, m_realPixelSize) With {.Alignment = PenAlignment.Outset}, drawRectR.X, drawRectR.Y, drawRectR.Width, drawRectR.Height)
                                    Next
                                End If
                            End If
                        End If
                    End If



                    If ViewSettings.Itrs Then
                        If ViewSettings.Itr3D Then
                            For Each itr As Itr In m_LFFrame.Itrs
                                Dim paths As ItrPathResult = itr.GetItrPaths(False, m_realPixelSize)
                                Dim rectF As RectangleF = GetRectFToDraw(paths.Rect, True)

                                Dim itrBrushCol As SolidBrush = m_itrBrush ' = itr.Kind <> 0
                                Dim itrPenCol As Pen = m_itrPen

                                If itr.Kind <> 0 Then
                                    itrBrushCol = m_itrBrush2
                                    itrPenCol = m_itrPen2
                                End If

                                If ViewSettings.FillRectangles Then
                                    .FillPath(itrBrushCol, paths.Path1)
                                    .FillPath(itrBrushCol, paths.Path2)
                                End If

                                .DrawPath(itrPenCol, paths.Path1)
                                .DrawRectangle(itrPenCol, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                            Next
                        Else
                            For Each itr As Itr In m_LFFrame.Itrs
                                Dim rectF As RectangleF = GetRectFToDraw(itr.Rect.GetRect, True)
                                If itr.Kind <> 0 Then
                                    If ViewSettings.FillRectangles Then .FillRectangle(m_itrBrush2, itr.Rect.GetRect)
                                    .DrawRectangle(m_itrPen2, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                                Else
                                    If ViewSettings.FillRectangles Then .FillRectangle(m_itrBrush, itr.Rect.GetRect)
                                    .DrawRectangle(m_itrPen, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                                End If
                            Next
                        End If
                    End If


                    If ViewSettings.WPoint Then
                        If Not IsNothing(weaponPoint) Then
                            Dim drawPoint As New Point(weaponPoint.Loca.X, weaponPoint.Loca.Y)
                            .FillRectangle(Brushes.Lime, drawPoint.X, drawPoint.Y, 1, 1)
                            Dim rectF As RectangleF = GetRectFToDraw(New Rectangle(drawPoint.X - 2, drawPoint.Y - 2, 5, 5), True)
                            .DrawRectangle(New Pen(Color.Lime, m_realPixelSize) With {.Alignment = PenAlignment.Outset}, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                        End If
                    End If




                    'OPOINT
                    If ViewSettings.OPoint Then
                        If Not (m_LFFrame.OPoint.X = Integer.MaxValue Or m_LFFrame.OPoint.Y = Integer.MaxValue) Then
                            Dim drawPoint As New Point(m_LFFrame.OPoint.X, m_LFFrame.OPoint.Y)
                            .FillRectangle(Brushes.Magenta, drawPoint.X, drawPoint.Y, 1, 1)

                            Dim rectF As RectangleF = GetRectFToDraw(New Rectangle(drawPoint.X - 2, drawPoint.Y - 2, 5, 5), True)
                            .DrawRectangle(m_oPen, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                        End If

                    End If

                    'CPOINT
                    If ViewSettings.CPoint Then
                        If Not (m_LFFrame.CPoint.X = Integer.MaxValue Or m_LFFrame.CPoint.Y = Integer.MaxValue) Then
                            Dim drawPoint As New Point(m_LFFrame.CPoint.X, m_LFFrame.CPoint.Y)
                            .FillRectangle(Brushes.Orange, drawPoint.X, drawPoint.Y, 1, 1)
                            Dim rectF As RectangleF = GetRectFToDraw(New Rectangle(drawPoint.X - 2, drawPoint.Y - 2, 5, 5), True)
                            .DrawRectangle(m_cPen, rectF.X, rectF.Y, rectF.Width, rectF.Height)
                        End If
                    End If



                    If ViewSettings.CenterXY Then
                        .FillEllipse(Brushes.Gray, CENTER_XY)
                    End If

                    If Not isControlPressed And m_selectedObject.Object = EFrameChangeType.CenterXY2 Then
                        m_selectedObject.Object = EFrameChangeType.None
                        Cursor = Cursors.Default
                    End If


                    .ResetTransform()
                End If


                If ViewSettings.Scales Then
                    .FillRectangle(Brushes.White, New Rectangle(0, 0, e.ClipRectangle.Width, 20))
                    .FillRectangle(Brushes.White, New Rectangle(0, 0, 20, e.ClipRectangle.Height))

                    Dim bigStepX As Integer = 100
                    Dim smallStepX As Integer = 10
                    Dim smallStepY As Integer = 10
                    Dim bigStepY As Integer = 50

                    Dim zoomIndex As Integer = (ViewSettings.Zoom - 100) / 100
                    If zoomIndex > ZOOM_TO_BIG_STEP_X.Count - 1 Then zoomIndex = ZOOM_TO_BIG_STEP_X.Count - 1

                    If zoomIndex >= 0 And zoomIndex < ZOOM_TO_BIG_STEP_X.Count Then
                        bigStepX = ZOOM_TO_BIG_STEP_X(zoomIndex)
                        smallStepX = ZOOM_TO_SMALL_STEP_X(zoomIndex)
                        bigStepY = ZOOM_TO_BIG_STEP_Y(zoomIndex)
                        smallStepY = ZOOM_TO_SMALL_STEP_Y(zoomIndex)
                    End If

                    bigStepX = bigStepX * m_big1pixel
                    smallStepX = smallStepX * m_big1pixel
                    smallStepY = smallStepY * m_big1pixel
                    bigStepY = bigStepY * m_big1pixel

                    'picCenterXWithoutZoom += Math.Ceiling(viewSettings.Zoom / 100 / 2)
                    Dim picCenter As New Point(Math.Truncate(picCenterXWithoutZoom), Math.Truncate(picCenterYWithoutZoom))

                    Dim iStart As Integer = picCenter.X Mod smallStepX
                    For i = iStart To e.ClipRectangle.Width Step smallStepX
                        If (picCenter.X - i) Mod bigStepX = 0 Then
                            .DrawLine(Pens.Black, i, 0, i, 6)

                            Dim text As String = Math.Round(-(picCenter.X - iStart) / ViewSettings.Zoom * 100 + ((i - iStart) / ViewSettings.Zoom * 100)).ToString
                            Dim fontSize As Size = TextRenderer.MeasureText(text, FONT_SMALL)
                            .DrawString(text, FONT_SMALL, Brushes.Black, New Point(1 + i - (fontSize.Width / 2), 7))
                        ElseIf (picCenter.X - i) Mod (bigStepX / 2) = 0 Then
                            .DrawLine(Pens.LightGray, i, 0, i, 5)
                        Else
                            .DrawLine(Pens.LightGray, i, 0, i, 3)
                        End If
                    Next



                    iStart = picCenter.Y Mod smallStepY
                    For i = iStart To e.ClipRectangle.Height Step smallStepY
                        If (picCenter.Y - i) Mod bigStepY = 0 Then
                            .DrawLine(Pens.Black, 19 - 6, i, 19, i)
                        ElseIf (picCenter.Y - i) Mod (bigStepY / 2) = 0 Then
                            .DrawLine(Pens.LightGray, 19 - 5, i, 19, i)
                        Else
                            .DrawLine(Pens.LightGray, 19 - 3, i, 19, i)
                        End If
                    Next




                    .DrawLine(Pens.Black, 0, 20, e.ClipRectangle.Width, 20)
                    .DrawLine(Pens.Black, 20, 0, 20, e.ClipRectangle.Height)
                    .DrawLine(Pens.Black, 0, 0, 0, e.ClipRectangle.Height)
                    .DrawLine(Pens.Black, 0, 0, e.ClipRectangle.Width, 0)

                    .FillRectangle(Brushes.White, New Rectangle(0, 0, 20, 20))
                    .DrawRectangle(Pens.Black, New Rectangle(0, 0, 20, 20))
                    .DrawString("px", FONT_SMALL, Brushes.Black, New Point(2, 2))


                    Dim transHeight As Integer = 26
                    Dim linGrBrush = New LinearGradientBrush(New Point(0, (e.ClipRectangle.Height Mod transHeight)),
                                                         New Point(0, transHeight + ((e.ClipRectangle.Height Mod transHeight))),
                                                         Color.FromArgb(0, 255, 255, 255),
                                                         Color.FromArgb(255, 255, 255, 255))


                    '.FillRectangle(linGrBrush, 0, e.ClipRectangle.Height - 15, e.ClipRectangle.Width, 20)
                    .FillRectangle(linGrBrush, 20, e.ClipRectangle.Height - transHeight, e.ClipRectangle.Width, transHeight)

                    .DrawString("Easier Data-Editor (STM93 Version)", FONT_COPYRIGHT, Brushes.DarkBlue, New Point(25, e.ClipRectangle.Height - 15))

                    If Not m_selectedObject.Object = EFrameChangeType.None Then
                        Dim text As String = GetVariable("selected") & m_selectedObject.Object.ToString & "  (" & m_selectedObject.Position.ToString & ")"
                        Dim fontSize As Size = TextRenderer.MeasureText(text, FONT_SELECTED)
                        .FillRectangle(Brushes.White, New Rectangle(30 - 1, 30 - 1, fontSize.Width + 3, fontSize.Height + 3))
                        .DrawString(text, FONT_SELECTED, Brushes.Black, New Point(31, 30))

                        '.DrawString("Selected: " & selectedObj.ToString, fontF, Brushes.Black, New Point(startPos.X + 10, startPos.Y - 20))
                    End If





                    .SetClip(New Rectangle(0, 20, 20, e.ClipRectangle.Height))
                    .TranslateTransform(e.ClipRectangle.Width, e.ClipRectangle.Height)
                    .RotateTransform(-90)
                    iStart = picCenter.Y Mod bigStepY

                    For i = iStart To e.ClipRectangle.Height Step bigStepY
                        Dim text As String = Math.Round(-(-(picCenter.Y - iStart) / ViewSettings.Zoom * 100 + ((i - iStart) / ViewSettings.Zoom * 100))).ToString
                        Dim fontSize As Size = TextRenderer.MeasureText(text, FONT_SMALL)
                        .DrawString(text, FONT_SMALL, Brushes.Black, New Point(e.ClipRectangle.Height - i - (fontSize.Width / 2) + 1, -e.ClipRectangle.Width + 1)) ' + TextRenderer.MeasureText("test", newFont).Width))
                    Next
                    '.ResetTransform()
                    '.FillRectangle(Brushes.White, New Rectangle(0, 0, 20, 20))
                    '.DrawRectangle(Pens.Black, New Rectangle(0, 0, 20, 20))
                    '.DrawString("px", FONT_SMALL, Brushes.Black, New Point(2, 2))
                End If
            End With
        Catch ex As Exception
            Console.WriteLine("FrameViewer: " & ex.ToString)
        End Try


        'Console.WriteLine("draw: " & Path.ToString & " - " & (Date.Now - m_lastTime).TotalMilliseconds)
        'm_lastTime = Date.Now
    End Sub

    Private Sub Preview_MouseDown(sender As Object, e As MouseEventArgs) Handles Preview.MouseDown
        HasFocus = True
        m_startPos = e.Location
        If Not Preview.Focused Then
            Preview.Focus()
        End If

        If Not m_selectedObject.Object = EFrameChangeType.None AndAlso e.Button = MouseButtons.Left Then
            If Not IsNothing(m_textEditor) Then
                m_textEditor.FrameViewer_MouseDown()
            End If
        End If

        If e.Button = MouseButtons.Left AndAlso (m_selectedObject.Object = EFrameChangeType.BPoint Or m_selectedObject.Object = EFrameChangeType.CPoint Or m_selectedObject.Object = EFrameChangeType.OPoint Or m_selectedObject.Object = EFrameChangeType.WPoint) Then
            Cursor.Hide()
        End If
    End Sub

    Private Sub Preview_MouseWheel(sender As Object, e As MouseEventArgs) Handles Preview.MouseWheel
        Dim relativPos As New PointF(e.Location.X / ViewSettings.Zoom * 100,
                                     e.Location.Y / ViewSettings.Zoom * 100)

        If ModifierKeys.HasFlag(Keys.Control) Or ModifierKeys.HasFlag(Keys.ControlKey) Or ModifierKeys.HasFlag(Keys.Control Or Keys.ControlKey) Then
            HasFocus = True
            If e.Delta > 0 And ViewSettings.Zoom < FrameViewerSettings.ZOOM_MAXIMUM Then
                ViewSettings.Zoom += 100

                ViewSettings.ScrollPosition = New PointF(ViewSettings.ScrollPosition.X - relativPos.X / ViewSettings.Zoom * 100,
                                                         ViewSettings.ScrollPosition.Y - relativPos.Y / ViewSettings.Zoom * 100)
                CheckScrollbarPosition()
            ElseIf e.Delta < 0 And ViewSettings.Zoom > 100 Then
                ViewSettings.Zoom -= 100

                ViewSettings.ScrollPosition = New PointF(ViewSettings.ScrollPosition.X + relativPos.X / ViewSettings.Zoom * 100,
                                                         ViewSettings.ScrollPosition.Y + relativPos.Y / ViewSettings.Zoom * 100)
                CheckScrollbarPosition()
            End If

        ElseIf ModifierKeys.HasFlag(Keys.ShiftKey) Or ModifierKeys.HasFlag(Keys.Shift) Or ModifierKeys.HasFlag(Keys.Shift Or Keys.ShiftKey) Then
            ViewSettings.ScrollPosition = New PointF(ViewSettings.ScrollPosition.X + If(e.Delta > 0, 5, -5),
                                                     ViewSettings.ScrollPosition.Y)
            CheckScrollbarPosition()
        Else
            ViewSettings.ScrollPosition = New PointF(ViewSettings.ScrollPosition.X,
                                                     ViewSettings.ScrollPosition.Y + If(e.Delta > 0, 5, -5))
            CheckScrollbarPosition()
        End If
    End Sub

    Private Sub Preview_MouseMove(sender As Object, e As MouseEventArgs) Handles Preview.MouseMove
        'mousePositionRelativToCharacter
        Dim posToCharacterF As New PointF(e.Location.X / ViewSettings.Zoom * 100, e.Location.Y / ViewSettings.Zoom * 100)
        If Not IsNothing(m_LFFrame) Then
            posToCharacterF.X -= ViewSettings.CenterPoint.X + ViewSettings.ScrollPosition.X - m_LFFrame.Center.X
            posToCharacterF.Y -= ViewSettings.CenterPoint.Y + ViewSettings.ScrollPosition.Y - m_LFFrame.Center.Y
        End If

        Dim posToCharacter As New Point(Math.Floor(posToCharacterF.X), Math.Floor(posToCharacterF.Y))
        Dim positionChanged As Boolean = Not posToCharacter.Equals(m_lastPosition)
        m_lastPosition = posToCharacter 'its always true now, because its is a reference now (?!)

        'Console.WriteLine(posToCharacter)


        Dim setOnlyWhen As Boolean = False
        Dim newX As Integer = e.Location.X - m_startPos.X
        Dim newY As Integer = e.Location.Y - m_startPos.Y
        If newX > 0 Then
            newX = Math.Floor(newX / ViewSettings.Zoom * 100)
        Else
            newX = Math.Ceiling(newX / ViewSettings.Zoom * 100)
        End If
        If newY > 0 Then
            newY = Math.Floor(newY / ViewSettings.Zoom * 100)
        Else
            newY = Math.Ceiling(newY / ViewSettings.Zoom * 100)
        End If


        'view stuff
        If e.Button = MouseButtons.Middle Then
            ViewSettings.ScrollPosition = New PointF(ViewSettings.ScrollPosition.X + newX,
                                                     ViewSettings.ScrollPosition.Y + newY)
            CheckScrollbarPosition()
            setOnlyWhen = True

            'change object
        ElseIf Not Cursor = Cursors.Default And Not m_selectedObject.Object = EFrameChangeType.None And Not IsNothing(m_LFFrame) And e.Button = MouseButtons.Left Then
            Dim selectedThing As Bdy = Nothing
            If Not positionChanged Then Exit Sub

            If m_selectedObject.Object = EFrameChangeType.Bdy And m_selectedObject.Index >= 0 And m_selectedObject.Index < 5 And m_selectedObject.Index < m_LFFrame.Bodys.Count Then
                selectedThing = m_LFFrame.Bodys(m_selectedObject.Index)
            ElseIf m_selectedObject.Object = EFrameChangeType.Itr And m_selectedObject.Index >= 0 And m_selectedObject.Index < 5 And m_selectedObject.Index < m_LFFrame.Itrs.Count Then
                selectedThing = m_LFFrame.Itrs(m_selectedObject.Index)
            ElseIf m_selectedObject.Object = EFrameChangeType.Bdy Or m_selectedObject.Object = EFrameChangeType.Itr Then
                Exit Sub
            End If

            If m_selectedObject.Position = ESelectedPosition.Center Then
                If m_selectedObject.Object = EFrameChangeType.WPoint Then
                    m_LFFrame.WPoint.Loca.X = posToCharacter.X - m_selectedObject.RelativPosition.X
                    m_LFFrame.WPoint.Loca.Y = posToCharacter.Y - m_selectedObject.RelativPosition.Y
                ElseIf m_selectedObject.Object = EFrameChangeType.BPoint Then
                    m_LFFrame.BPoint.X = posToCharacter.X - m_selectedObject.RelativPosition.X
                    m_LFFrame.BPoint.Y = posToCharacter.Y - m_selectedObject.RelativPosition.Y
                ElseIf m_selectedObject.Object = EFrameChangeType.OPoint Then
                    m_LFFrame.OPoint.X = posToCharacter.X - m_selectedObject.RelativPosition.X
                    m_LFFrame.OPoint.Y = posToCharacter.Y - m_selectedObject.RelativPosition.Y
                ElseIf m_selectedObject.Object = EFrameChangeType.CPoint Then
                    m_LFFrame.CPoint.X = posToCharacter.X - m_selectedObject.RelativPosition.X
                    m_LFFrame.CPoint.Y = posToCharacter.Y - m_selectedObject.RelativPosition.Y
                ElseIf m_selectedObject.Object = EFrameChangeType.CenterXY Or m_selectedObject.Object = EFrameChangeType.CenterXY2 Then
                    Dim posToCharacter2 As New Point(Math.Floor(e.Location.X / ViewSettings.Zoom * 100), Math.Floor(e.Location.Y / ViewSettings.Zoom * 100))
                    m_LFFrame.Center.X = m_selectedObject.RelativPosition.X + (m_selectedObject.RelativPosition2.X - posToCharacter2.X)
                    m_LFFrame.Center.Y = m_selectedObject.RelativPosition.Y + (m_selectedObject.RelativPosition2.Y - posToCharacter2.Y)
                ElseIf (m_selectedObject.Object = EFrameChangeType.Bdy Or m_selectedObject.Object = EFrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    selectedThing.Rect.X = posToCharacter.X - m_selectedObject.RelativPosition.X
                    selectedThing.Rect.Y = posToCharacter.Y - m_selectedObject.RelativPosition.Y
                End If



            ElseIf m_selectedObject.Position = ESelectedPosition.Top Then
                If (m_selectedObject.Object = EFrameChangeType.Bdy Or m_selectedObject.Object = EFrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    Dim oldRectY As Integer = selectedThing.Rect.Y
                    Dim newRectY As Integer = posToCharacter.Y - m_selectedObject.RelativPosition.Y
                    If ViewSettings.Itr3D And m_selectedObject.Object = EFrameChangeType.Itr Then
                        Dim zwidth As Size = CType(selectedThing, Itr).GetZWidthThanSize()
                        newRectY += If(m_behind3DRect, zwidth.Width, -zwidth.Width)
                    End If

                    Dim newHeight As Integer = selectedThing.Rect.Height + (oldRectY - newRectY)
                    If newHeight < 0 Then
                        newHeight = 0
                        selectedThing.Rect.Y = selectedThing.Rect.Height + (oldRectY - newHeight)
                        m_selectedObject.Position = ESelectedPosition.Bottom
                        selectedThing.Rect.Height = newHeight
                        Exit Sub
                    End If

                    selectedThing.Rect.Y = newRectY
                    selectedThing.Rect.Height = newHeight
                End If



            ElseIf m_selectedObject.Position = ESelectedPosition.Bottom Then
                If (m_selectedObject.Object = EFrameChangeType.Bdy Or m_selectedObject.Object = EFrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    Dim newHeight As Integer = posToCharacter.Y - selectedThing.Rect.Y - m_selectedObject.RelativPosition.Y
                    If ViewSettings.Itr3D And m_selectedObject.Object = EFrameChangeType.Itr Then
                        Dim zwidth As Size = CType(selectedThing, Itr).GetZWidthThanSize()
                        newHeight += If(m_behind3DRect, zwidth.Height, -zwidth.Height)
                    End If

                    If newHeight < 0 Then
                        m_selectedObject.Position = ESelectedPosition.Top
                        newHeight = 0
                    End If
                    selectedThing.Rect.Height = newHeight
                End If



            ElseIf m_selectedObject.Position = ESelectedPosition.Right Then
                If (m_selectedObject.Object = EFrameChangeType.Bdy Or m_selectedObject.Object = EFrameChangeType.Itr) And Not IsNothing(selectedThing) Then
                    Dim newWidth As Integer = posToCharacter.X - selectedThing.Rect.X - m_selectedObject.RelativPosition.X
                    If ViewSettings.Itr3D And m_selectedObject.Object = EFrameChangeType.Itr Then
                        Dim zwidth As Size = CType(selectedThing, Itr).GetZWidthThanSize()
                        newWidth += If(m_behind3DRect, -zwidth.Width, zwidth.Width)
                    End If
                    If newWidth < 0 Then
                        m_selectedObject.Position = ESelectedPosition.Left
                        newWidth = 0
                    End If
                    selectedThing.Rect.Width = newWidth
                End If



            ElseIf m_selectedObject.Position = ESelectedPosition.Left Then
                If (m_selectedObject.Object = EFrameChangeType.Bdy Or m_selectedObject.Object = EFrameChangeType.Itr) And Not IsNothing(selectedThing) Then


                    Dim oldRectX As Integer = selectedThing.Rect.X
                    Dim newRectX As Integer = posToCharacter.X - m_selectedObject.RelativPosition.X
                    If ViewSettings.Itr3D And m_selectedObject.Object = EFrameChangeType.Itr Then
                        Dim zwidth As Size = CType(selectedThing, Itr).GetZWidthThanSize()
                        newRectX += If(m_behind3DRect, -zwidth.Height, zwidth.Height)
                    End If

                    Dim newWidth As Integer = selectedThing.Rect.Width + (oldRectX - newRectX)
                    If newWidth < 0 Then
                        newWidth = 0
                        selectedThing.Rect.X = selectedThing.Rect.Width + (oldRectX - newWidth)
                        m_selectedObject.Position = ESelectedPosition.Right
                        selectedThing.Rect.Width = newWidth
                        Exit Sub
                    End If

                    selectedThing.Rect.X = newRectX
                    selectedThing.Rect.Width = newWidth
                End If





            ElseIf m_selectedObject.Position = ESelectedPosition.ItrZWidthTop Or m_selectedObject.Position = ESelectedPosition.ItrZWidthBottom Then
                If ViewSettings.Itr3D And m_selectedObject.Object = EFrameChangeType.Itr And Not IsNothing(selectedThing) Then
                    Dim deltaPos As New Point(posToCharacter.X - m_selectedObject.RelativPosition.X, posToCharacter.Y - m_selectedObject.RelativPosition.Y)

                    CType(selectedThing, Itr).zWidth = Math.Abs(deltaPos.Y)
                End If





            ElseIf (m_selectedObject.Position = ESelectedPosition.LeftTop Or m_selectedObject.Position = ESelectedPosition.RightTop Or
                   m_selectedObject.Position = ESelectedPosition.LeftBottom Or m_selectedObject.Position = ESelectedPosition.RightBottom) And Not IsNothing(selectedThing) Then

                Dim deltaPos As New Point(posToCharacter.X - m_selectedObject.RelativPosition.X,
                                          posToCharacter.Y - m_selectedObject.RelativPosition.Y)

                Dim newRect As New Rectangle(m_selectedObject.RelativPosition.X, m_selectedObject.RelativPosition.Y,
                                             deltaPos.X - m_selectedObject.RelativPosition2.X, deltaPos.Y - m_selectedObject.RelativPosition2.Y)
                If deltaPos.X < 0 Then
                    newRect.X = posToCharacter.X - m_selectedObject.RelativPosition2.X
                    newRect.Width = Math.Abs(deltaPos.X) + m_selectedObject.RelativPosition2.X
                End If
                If deltaPos.Y < 0 Then
                    newRect.Y = posToCharacter.Y - m_selectedObject.RelativPosition2.Y
                    newRect.Height = Math.Abs(deltaPos.Y) + m_selectedObject.RelativPosition2.Y
                End If

                If ViewSettings.Itr3D And m_selectedObject.Object = EFrameChangeType.Itr Then
                    Dim zwidth As Size = CType(selectedThing, Itr).GetZWidthThanSize()
                    If m_behind3DRect Then
                        zwidth.Width *= -1
                        zwidth.Height *= -1
                    End If
                    newRect.Y -= zwidth.Height
                    newRect.X += zwidth.Height
                End If

                selectedThing.Rect = New LFRect(newRect)
            End If

            If Not IsNothing(m_textEditor) AndAlso App.Settings.ChangeDirectFV Then
                m_textEditor.ChangeValues(m_LFFrame, m_selectedObject.Object, m_selectedObject.Index)
            End If

            setOnlyWhen = True
            'get object under mouse
        ElseIf Not IsNothing(m_LFFrame) And e.Button = MouseButtons.None Then
            While True
                If m_selectedObject.Object = EFrameChangeType.CenterXY2 Then
                    If ModifierKeys.HasFlag(Keys.Control) Or ModifierKeys.HasFlag(Keys.ControlKey) Or ModifierKeys.HasFlag(Keys.Control Or Keys.ControlKey) Then
                        Exit While
                    End If
                End If

                m_selectedObject.Object = EFrameChangeType.None
                m_selectedObject.RelativPosition = New Point()
                m_selectedObject.RelativPosition2 = New Point()

                'CENTER XY
                If ViewSettings.CenterXY Then
                    If Math.Abs(posToCharacter.X) <= 2 And Math.Abs(posToCharacter.Y) <= 2 Then
                        m_selectedObject.Object = EFrameChangeType.CenterXY
                        m_selectedObject.RelativPosition = m_LFFrame.Center
                        m_selectedObject.RelativPosition2 = New Point(Math.Floor(Preview.PointToClient(MousePosition).X / ViewSettings.Zoom * 100),
                                                                    Math.Floor(Preview.PointToClient(MousePosition).Y / ViewSettings.Zoom * 100))
                        Cursor = Cursors.SizeAll
                        Exit While
                    End If
                End If

                'WEAPON POINT
                If ViewSettings.WPoint And Not IsNothing(m_LFFrame.WPoint) Then
                    Dim weaponPoint As WPoint = m_LFFrame.WPoint
                    If Not IsNothing(weaponPoint) Then
                        If Math.Abs(posToCharacter.X - weaponPoint.Loca.X) <= RECT_RADIUS And Math.Abs(posToCharacter.Y - weaponPoint.Loca.Y) <= RECT_RADIUS Then
                            m_selectedObject.Object = EFrameChangeType.WPoint
                            m_selectedObject.RelativPosition = New Point(posToCharacter.X - weaponPoint.Loca.X, posToCharacter.Y - weaponPoint.Loca.Y)
                            Exit While
                        End If
                    End If
                End If

                'BPOINT
                If ViewSettings.BPoint Then
                    If Not m_LFFrame.BPoint.X = Integer.MaxValue And Not m_LFFrame.BPoint.Y = Integer.MaxValue Then
                        If Math.Abs(posToCharacter.X - m_LFFrame.BPoint.X) <= RECT_RADIUS And Math.Abs(posToCharacter.Y - m_LFFrame.BPoint.Y - 1) <= RECT_RADIUS Then
                            m_selectedObject.Object = EFrameChangeType.BPoint
                            m_selectedObject.RelativPosition = New Point(posToCharacter.X - m_LFFrame.BPoint.X, posToCharacter.Y - m_LFFrame.BPoint.Y)
                            Exit While
                        End If
                    End If
                End If


                'OPOINT
                If ViewSettings.OPoint Then
                    If Not m_LFFrame.OPoint.X = Integer.MaxValue And Not m_LFFrame.OPoint.Y = Integer.MaxValue Then
                        If Math.Abs(posToCharacter.X - m_LFFrame.OPoint.X) <= RECT_RADIUS And Math.Abs(posToCharacter.Y - m_LFFrame.OPoint.Y) <= RECT_RADIUS Then
                            m_selectedObject.Object = EFrameChangeType.OPoint
                            m_selectedObject.RelativPosition = New Point(posToCharacter.X - m_LFFrame.OPoint.X, posToCharacter.Y - m_LFFrame.OPoint.Y)
                            Exit While
                        End If
                    End If
                End If

                'CPOINT
                If ViewSettings.CPoint Then
                    If Not m_LFFrame.CPoint.X = Integer.MaxValue And Not m_LFFrame.CPoint.Y = Integer.MaxValue Then
                        If Math.Abs(posToCharacter.X - m_LFFrame.CPoint.X) <= RECT_RADIUS And Math.Abs(posToCharacter.Y - m_LFFrame.CPoint.Y) <= RECT_RADIUS Then
                            m_selectedObject.Object = EFrameChangeType.CPoint
                            m_selectedObject.RelativPosition = New Point(posToCharacter.X - m_LFFrame.CPoint.X, posToCharacter.Y - m_LFFrame.CPoint.Y)
                            Exit While
                        End If
                    End If
                End If


                Dim listOfPossibles As New List(Of SelectedObject)
                ''BODYS
                If ViewSettings.Bodies Then
                    For i As Integer = 0 To m_LFFrame.Bodys.Count - 1
                        Dim body As Bdy = m_LFFrame.Bodys(i)

                        If body.Rect.Contains(posToCharacter) Then
                            m_selectedObject.Object = EFrameChangeType.Bdy
                            m_selectedObject.Index = i
                            m_selectedObject.Position = GetSelectedPosition(body.Rect.GetRect(), posToCharacterF)
                            m_selectedObject.RelativPosition = New Point(posToCharacter.X - body.Rect.X, posToCharacter.Y - body.Rect.Y)
                            Console.WriteLine(m_selectedObject.Position.ToString)

                            If m_selectedObject.Position = ESelectedPosition.Bottom Or m_selectedObject.Position = ESelectedPosition.Right Then
                                m_selectedObject.RelativPosition = New Point(posToCharacter.X - (body.Rect.X + body.Rect.Width), posToCharacter.Y - (body.Rect.Y + body.Rect.Height))
                            ElseIf m_selectedObject.Position = ESelectedPosition.LeftTop Then
                                m_selectedObject.RelativPosition2 = m_selectedObject.RelativPosition
                                m_selectedObject.RelativPosition = New Point(body.Rect.X + body.Rect.Width, body.Rect.Y + body.Rect.Height)
                            ElseIf m_selectedObject.Position = ESelectedPosition.LeftBottom Then
                                m_selectedObject.RelativPosition2 = New Point(m_selectedObject.RelativPosition.X, posToCharacter.Y - (body.Rect.Y + body.Rect.Height))
                                m_selectedObject.RelativPosition = New Point(body.Rect.X + body.Rect.Width, body.Rect.Y)
                            ElseIf m_selectedObject.Position = ESelectedPosition.RightTop Then
                                m_selectedObject.RelativPosition2 = New Point(posToCharacter.X - (body.Rect.X + body.Rect.Width), m_selectedObject.RelativPosition.Y)
                                m_selectedObject.RelativPosition = New Point(body.Rect.X, body.Rect.Y + body.Rect.Height)
                            ElseIf m_selectedObject.Position = ESelectedPosition.RightBottom Then
                                m_selectedObject.RelativPosition2 = New Point(posToCharacter.X - (body.Rect.X + body.Rect.Width), posToCharacter.Y - (body.Rect.Y + body.Rect.Height))
                                m_selectedObject.RelativPosition = New Point(body.Rect.X, body.Rect.Y)
                            ElseIf m_selectedObject.Position = ESelectedPosition.Center Then
                                listOfPossibles.Add(m_selectedObject.Clone)
                                Continue For
                            End If

                            Cursor = GetCursor(m_selectedObject.Position)
                            Exit While
                        End If
                    Next
                End If


                If ViewSettings.Itrs Then
                    For i As Integer = 0 To m_LFFrame.Itrs.Count - 1
                        Dim itr As Itr = m_LFFrame.Itrs(i)

                        If ViewSettings.Itr3D Then
                            Dim paths As ItrPathResult = itr.GetItrPaths(True, m_realPixelSize)
                            Dim paths2 As ItrPathResult = itr.GetItrPaths(False, m_realPixelSize)

                            If paths2.Path1.IsVisible(posToCharacter) Then
                                m_selectedObject.Index = i
                                m_selectedObject.Position = ESelectedPosition.Top
                                m_selectedObject.RelativPosition = New Point(posToCharacter.X - paths2.Rect.X,
                                                                           posToCharacter.Y - paths2.Rect.Y)
                            ElseIf paths.Path1.IsVisible(posToCharacter) Then
                                m_selectedObject.Index = i
                                m_selectedObject.Position = ESelectedPosition.Bottom
                                m_selectedObject.RelativPosition = New Point(posToCharacter.X - (paths2.Rect.X + paths2.Rect.Width), posToCharacter.Y - (paths2.Rect.Y + paths2.Rect.Height))
                            ElseIf paths2.Path2.IsVisible(posToCharacter) Then
                                m_selectedObject.Index = i
                                m_selectedObject.Position = ESelectedPosition.Right
                                m_selectedObject.RelativPosition = New Point(posToCharacter.X - (paths2.Rect.X + paths2.Rect.Width), posToCharacter.Y - (paths2.Rect.Y + paths2.Rect.Height))
                            Else
                                If (paths2.Rect.Contains(posToCharacter) Or paths.Rect.Contains(posToCharacter)) And
                                                              (m_selectedObject.Position = ESelectedPosition.Center Or m_selectedObject.Object = EFrameChangeType.None) Then
                                    m_selectedObject.Index = i
                                    If paths2.Rect.Contains(posToCharacter) Then
                                        m_selectedObject.Position = GetSelectedPosition(Rectangle.Ceiling(paths2.Rect), posToCharacterF)
                                    Else
                                        m_selectedObject.Position = GetSelectedPosition(Rectangle.Ceiling(paths.Rect), posToCharacterF)
                                    End If
                                    m_selectedObject.RelativPosition = New Point(posToCharacter.X - paths2.Rect.X,
                                                                               posToCharacter.Y - paths2.Rect.Y)

                                    If m_selectedObject.Position = ESelectedPosition.Bottom Or m_selectedObject.Position = ESelectedPosition.Right Then
                                        m_selectedObject.RelativPosition = New Point(posToCharacter.X - (paths2.Rect.X + paths2.Rect.Width), posToCharacter.Y - (paths2.Rect.Y + paths2.Rect.Height))
                                    ElseIf m_selectedObject.Position = ESelectedPosition.LeftTop Then
                                        m_selectedObject.RelativPosition2 = m_selectedObject.RelativPosition
                                        m_selectedObject.RelativPosition = New Point(paths2.Rect.X + paths2.Rect.Width, paths2.Rect.Y + paths2.Rect.Height)
                                    ElseIf m_selectedObject.Position = ESelectedPosition.LeftBottom Then
                                        m_selectedObject.RelativPosition2 = New Point(m_selectedObject.RelativPosition.X, posToCharacter.Y - (paths2.Rect.Y + paths2.Rect.Height))
                                        m_selectedObject.RelativPosition = New Point(paths2.Rect.X + paths2.Rect.Width, paths2.Rect.Y)
                                    ElseIf m_selectedObject.Position = ESelectedPosition.RightTop Then
                                        m_selectedObject.RelativPosition2 = New Point(posToCharacter.X - (paths2.Rect.X + paths2.Rect.Width), m_selectedObject.RelativPosition.Y)
                                        m_selectedObject.RelativPosition = New Point(paths2.Rect.X, paths2.Rect.Y + paths2.Rect.Height)
                                    ElseIf m_selectedObject.Position = ESelectedPosition.RightBottom Then
                                        m_selectedObject.RelativPosition2 = New Point(posToCharacter.X - (paths2.Rect.X + paths2.Rect.Width), posToCharacter.Y - (paths2.Rect.Y + paths2.Rect.Height))
                                        m_selectedObject.RelativPosition = New Point(paths2.Rect.X, paths2.Rect.Y)
                                    ElseIf m_selectedObject.Position = ESelectedPosition.Center Then

                                        'm_selectedObject.RelativPosition = New Point(posToCharacter.X - paths2.Rect.X - (paths.Rect.X - itr.Rect.X),
                                        '                                           posToCharacter.Y - paths2.Rect.Y - (paths.Rect.Y - itr.Rect.Y))
                                        'listOfPossibles.Insert(0, New class_m_selectedObject(m_selectedObject))
                                        'Continue For
                                        m_selectedObject.Position = ESelectedPosition.ItrZWidthBottom
                                        m_selectedObject.RelativPosition = New Point(posToCharacter.X - If(itr.zWidth <= 0, 15, itr.zWidth),
                                                                                   posToCharacter.Y - If(itr.zWidth <= 0, 15, itr.zWidth))
                                    End If
                                Else
                                    Continue For
                                End If
                            End If

                            m_selectedObject.Object = EFrameChangeType.Itr
                            Cursor = GetCursor(m_selectedObject.Position)
                            Exit While





                        Else
                            If itr.Rect.Contains(posToCharacter) Then
                                m_selectedObject.Object = EFrameChangeType.Itr
                                m_selectedObject.Index = i
                                m_selectedObject.Position = GetSelectedPosition(itr.Rect.GetRect(), posToCharacterF)
                                m_selectedObject.RelativPosition = New Point(posToCharacter.X - itr.Rect.X, posToCharacter.Y - itr.Rect.Y)

                                If m_selectedObject.Position = ESelectedPosition.Bottom Or m_selectedObject.Position = ESelectedPosition.Right Then
                                    m_selectedObject.RelativPosition = New Point(posToCharacter.X - (itr.Rect.X + itr.Rect.Width), posToCharacter.Y - (itr.Rect.Y + itr.Rect.Height))
                                ElseIf m_selectedObject.Position = ESelectedPosition.LeftTop Then
                                    m_selectedObject.RelativPosition2 = m_selectedObject.RelativPosition
                                    m_selectedObject.RelativPosition = New Point(itr.Rect.X + itr.Rect.Width, itr.Rect.Y + itr.Rect.Height)
                                ElseIf m_selectedObject.Position = ESelectedPosition.LeftBottom Then
                                    m_selectedObject.RelativPosition2 = New Point(m_selectedObject.RelativPosition.X, posToCharacter.Y - (itr.Rect.Y + itr.Rect.Height))
                                    m_selectedObject.RelativPosition = New Point(itr.Rect.X + itr.Rect.Width, itr.Rect.Y)
                                ElseIf m_selectedObject.Position = ESelectedPosition.RightTop Then
                                    m_selectedObject.RelativPosition2 = New Point(posToCharacter.X - (itr.Rect.X + itr.Rect.Width), m_selectedObject.RelativPosition.Y)
                                    m_selectedObject.RelativPosition = New Point(itr.Rect.X, itr.Rect.Y + itr.Rect.Height)
                                ElseIf m_selectedObject.Position = ESelectedPosition.RightBottom Then
                                    m_selectedObject.RelativPosition2 = New Point(posToCharacter.X - (itr.Rect.X + itr.Rect.Width), posToCharacter.Y - (itr.Rect.Y + itr.Rect.Height))
                                    m_selectedObject.RelativPosition = New Point(itr.Rect.X, itr.Rect.Y)
                                ElseIf m_selectedObject.Position = ESelectedPosition.Center Then
                                    listOfPossibles.Add(m_selectedObject.Clone)
                                    Continue For
                                End If

                                Cursor = GetCursor(m_selectedObject.Position)
                                Exit While
                            End If
                        End If
                    Next
                End If

                For Each obj As SelectedObject In listOfPossibles
                    If Not obj.Position = ESelectedPosition.Center Then
                        m_selectedObject = obj
                        Cursor = GetCursor(obj.Position)
                        Exit While
                    End If
                Next

                If listOfPossibles.Count > 0 Then
                    m_selectedObject = listOfPossibles.First
                    Cursor = GetCursor(listOfPossibles.First.Position)
                End If
                'End If
                Exit While
            End While

            If Not m_selectedObject.Object = EFrameChangeType.None And Not m_selectedObject.Object = EFrameChangeType.Itr And Not m_selectedObject.Object = EFrameChangeType.Bdy Then
                m_selectedObject.Position = ESelectedPosition.Center
                Cursor = Cursors.SizeAll
            ElseIf m_selectedObject.Object = EFrameChangeType.None Then
                Cursor = Cursors.Default
            End If
        End If

        If Not setOnlyWhen Or ViewSettings.Zoom = 100 Then
            m_startPos = e.Location
        Else
            If Math.Abs(newX) >= 1 Then
                m_startPos.X = e.Location.X
            End If
            If Math.Abs(newY) >= 1 Then
                m_startPos.Y = e.Location.Y
            End If
        End If
    End Sub

    Private Sub Preview_MouseUp(sender As Object, e As MouseEventArgs) Handles Preview.MouseUp
        If m_selectedObject.Object = EFrameChangeType.BPoint Or m_selectedObject.Object = EFrameChangeType.CPoint Or m_selectedObject.Object = EFrameChangeType.OPoint Or m_selectedObject.Object = EFrameChangeType.WPoint Then
            Cursor.Show()
        End If

        If Not IsNothing(m_LFFrame) And Not e.Button = MouseButtons.Middle Then
            Do
                Dim selectedThing As Bdy = Nothing

                If m_selectedObject.Object = EFrameChangeType.Bdy And m_selectedObject.Index >= 0 And m_selectedObject.Index < 5 And m_selectedObject.Index < m_LFFrame.Bodys.Count Then
                    selectedThing = m_LFFrame.Bodys(m_selectedObject.Index)
                ElseIf m_selectedObject.Object = EFrameChangeType.Itr And m_selectedObject.Index >= 0 And m_selectedObject.Index < 5 And m_selectedObject.Index < m_LFFrame.Itrs.Count Then
                    selectedThing = m_LFFrame.Itrs(m_selectedObject.Index)
                ElseIf m_selectedObject.Object = EFrameChangeType.Bdy Or m_selectedObject.Object = EFrameChangeType.Itr Then
                    Exit Do
                End If

                If Not IsNothing(selectedThing) Then
                    If selectedThing.Rect.Width = 0 Or selectedThing.Rect.Height = 0 Then
                        If Not IsNothing(m_textEditor) Then
                            m_textEditor.DeleteValues(m_LFFrame, m_selectedObject.Object, m_selectedObject.Index)
                        End If
                        Exit Do
                    End If
                End If

                If Not IsNothing(m_textEditor) AndAlso e.Button = MouseButtons.Left Then
                    m_textEditor.ChangeValues(m_LFFrame, m_selectedObject.Object, m_selectedObject.Index)
                End If
            Loop While False

        End If

        If Not m_selectedObject.Object = EFrameChangeType.None Then
            If Not IsNothing(m_textEditor) Then
                m_textEditor.FrameViewer_MouseUp()
            End If
        End If
    End Sub
#End Region

#Region "Settings Events"
    Private Sub ViewSettings_AxisStateChanged(sender As Object, e As Boolean) Handles ViewSettings.AxisStateChanged
        If Not m_updatingViewSettings Then
            Cb_axis.Checked = e
            TSMI_axis.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_BackgroundColorChanged(sender As Object, e As Color) Handles ViewSettings.BackgroundColorChanged
        If Not m_updatingViewSettings Then
            SetBackgroundColor(e)
        End If
    End Sub

    Private Sub ViewSettings_BodiesStateChanged(sender As Object, e As Boolean) Handles ViewSettings.BodiesStateChanged
        If Not m_updatingViewSettings Then
            Cb_bodies.Checked = e
            TSMI_bodies.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_BPointStateChanged(sender As Object, e As Boolean) Handles ViewSettings.BPointStateChanged
        If Not m_updatingViewSettings Then
            Cb_bpoint.Checked = e
            TSMI_bpoint.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_CenterPointChanged(sender As Object, e As Point) Handles ViewSettings.CenterPointChanged
        If Not m_updatingViewSettings Then
            Tim_drawer.Start()
        End If
    End Sub

    Private Sub ViewSettings_CenterStateChanged(sender As Object, e As Boolean) Handles ViewSettings.CenterStateChanged
        If Not m_updatingViewSettings Then
            Cb_center_xy.Checked = e
            TSMI_center_xy.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_CharacterOpacityChanged(sender As Object, e As Boolean) Handles ViewSettings.CharacterOpacityChanged
        If Not m_updatingViewSettings Then
            m_trackbarOpacity.Value = ViewSettings.CharacterOpacity
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_CPointStateChanged(sender As Object, e As Boolean) Handles ViewSettings.CPointStateChanged
        If Not m_updatingViewSettings Then
            Cb_cpoint.Checked = e
            TSMI_cpoint.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_FillStateChanged(sender As Object, e As Boolean) Handles ViewSettings.FillStateChanged
        If Not m_updatingViewSettings Then
            Cb_Fill.Checked = e
            TSMI_Fill.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_DrawBSpriteChanged(sender As Object, e As Boolean) Handles ViewSettings.DrawBSpriteChanged
        If Not m_updatingViewSettings Then
            Cb_drawBSprite.Checked = e
            TSMI_drawBSprite.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_Itrs3DStateChanged(sender As Object, e As Boolean) Handles ViewSettings.Itrs3DStateChanged
        If Not m_updatingViewSettings Then
            TSMI_itr_3d.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_ItrsStateChanged(sender As Object, e As Boolean) Handles ViewSettings.ItrsStateChanged
        If Not m_updatingViewSettings Then
            Cb_itrs.Checked = e
            TSMI_itrs.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_OPointStateChanged(sender As Object, e As Boolean) Handles ViewSettings.OPointStateChanged
        If Not m_updatingViewSettings Then
            Cb_opoint.Checked = e
            TSMI_opoint.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_ScaleStateChanged(sender As Object, e As Boolean) Handles ViewSettings.ScaleStateChanged
        If Not m_updatingViewSettings Then
            Cb_showScales.Checked = e
            TSMI_showScales.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_ScrollPositionChanged(sender As Object, e As PointF) Handles ViewSettings.ScrollPositionChanged
        If Not m_updatingViewSettings Then
            Tim_drawer.Start()
        End If
    End Sub

    Private Sub ViewSettings_SelectedIDChanged(sender As Object, e As Integer) Handles ViewSettings.SelectedIDChanged
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_ShadowStateChanged(sender As Object, e As Boolean) Handles ViewSettings.ShadowStateChanged
        If Not m_updatingViewSettings Then
            Cb_shadow.Checked = e
            TSMI_shadow.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_WeaponHitboxesChanged(sender As Object, e As Boolean) Handles ViewSettings.WeaponHitboxesChanged
        If Not m_updatingViewSettings Then
            Cb_wHitbox.Checked = e
            TSMI_wHitbox.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_WeaponStateChanged(sender As Object, e As Boolean) Handles ViewSettings.WeaponStateChanged
        If Not m_updatingViewSettings Then
            Cb_weapon.Checked = e
            TSMI_weapon.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_WPointStateChanged(sender As Object, e As Boolean) Handles ViewSettings.WPointStateChanged
        If Not m_updatingViewSettings Then
            Cb_wpoint.Checked = e
            TSMI_wpoint.Checked = e
        End If
        Preview.Invalidate()
    End Sub

    Private Sub ViewSettings_ZoomStateChanged(sender As Object, e As Boolean) Handles ViewSettings.ZoomStateChanged
        If Not m_updatingViewSettings Then
            Tim_drawer.Start()
        End If
    End Sub
#End Region

    Private Sub SetBackgroundColor(ByVal col As Color)
        If col.Equals(Color.Transparent) And m_currentShowImage Then
            Exit Sub 'do nothing
        ElseIf col.Equals(Color.Transparent) Then
            Preview.BackgroundImage = My.Resources.bg_transparent

            m_currentShowImage = True
        Else
            Preview.BackgroundImage = Nothing
            Preview.BackColor = col

            TSMI_bg_color.Tag = col

            m_currentShowImage = False
        End If

        Preview.Invalidate()
    End Sub

    Private Function GetCursor(ByVal pos As ESelectedPosition) As Cursor
        Dim tolerance As Integer = 5
        If pos = ESelectedPosition.LeftTop Or pos = ESelectedPosition.RightBottom Then
            Return Cursors.SizeNWSE
        ElseIf pos = ESelectedPosition.RightTop Or pos = ESelectedPosition.LeftBottom Or pos = ESelectedPosition.ItrZWidthBottom Or pos = ESelectedPosition.ItrZWidthTop Then
            Return Cursors.SizeNESW
        ElseIf pos = ESelectedPosition.Left Or pos = ESelectedPosition.Right Then
            Return Cursors.SizeWE
        ElseIf pos = ESelectedPosition.Top Or pos = ESelectedPosition.Bottom Then
            Return Cursors.SizeNS
        End If

        Return Cursors.SizeAll
    End Function

    Private Function GetSelectedPosition(ByVal rect As Rectangle, ByVal poi As PointF) As ESelectedPosition
        Dim toleranceW As Single = 10 / ViewSettings.Zoom * 100
        Dim toleranceH As Single = 10 / ViewSettings.Zoom * 100
        If rect.Width < toleranceW * 2 Then
            toleranceW = rect.Width / 100 * 35
        End If

        If rect.Height < toleranceH * 2 Then
            toleranceH = rect.Height / 100 * 35
        End If

        If Math.Abs(rect.X - poi.X) < toleranceW And Math.Abs(rect.Y - poi.Y) < toleranceH Then
            Return ESelectedPosition.LeftTop
        ElseIf Math.Abs(rect.X + rect.Width - poi.X) < toleranceW And Math.Abs(rect.Y - poi.Y) < toleranceH Then
            Return ESelectedPosition.RightTop

        ElseIf Math.Abs(rect.X - poi.X) < toleranceW And Math.Abs(rect.Y + rect.Height - poi.Y) < toleranceH Then
            Return ESelectedPosition.LeftBottom
        ElseIf Math.Abs(rect.X + rect.Width - poi.X) < toleranceW And Math.Abs(rect.Y + rect.Height - poi.Y) < toleranceH Then
            Return ESelectedPosition.RightBottom

        ElseIf Math.Abs(rect.X - poi.X) < toleranceW Then
            Return ESelectedPosition.Left
        ElseIf Math.Abs(rect.X + rect.Width - poi.X) < toleranceW Then
            Return ESelectedPosition.Right

        ElseIf Math.Abs(rect.Y - poi.Y) < toleranceH Then
            Return ESelectedPosition.Top
        ElseIf Math.Abs(rect.Y + rect.Height - poi.Y) < toleranceH Then
            Return ESelectedPosition.Bottom
        End If

        Return ESelectedPosition.Center
    End Function

    Private Sub CheckScrollbarPosition()
        Dim maxViewY As Point = MAX_VIEW_Y
        Dim maxViewX As Point = MAX_VIEW_X
        Dim tmp As PointF = ViewSettings.ScrollPosition

        Dim picSizeWithWithoutZoom As Size = New Point(Preview.Width / ViewSettings.Zoom * 100, Preview.Height / ViewSettings.Zoom * 100)

        Dim viewXPositive As Integer = CInt(tmp.X) + ViewSettings.CenterPoint.X - picSizeWithWithoutZoom.Width
        Dim viewXNegative As Integer = CInt(tmp.X) + ViewSettings.CenterPoint.X
        Dim viewYPositive As Integer = CInt(tmp.Y) + ViewSettings.CenterPoint.Y - picSizeWithWithoutZoom.Height
        Dim viewYNegative As Integer = CInt(tmp.Y) + ViewSettings.CenterPoint.Y


        If picSizeWithWithoutZoom.Height > maxViewY.X + maxViewY.Y Then
            maxViewY = New Point(picSizeWithWithoutZoom.Height, picSizeWithWithoutZoom.Height)
        End If
        If picSizeWithWithoutZoom.Width > maxViewX.X + maxViewX.Y Then
            maxViewX = New Point(picSizeWithWithoutZoom.Width * 6 / 4, picSizeWithWithoutZoom.Width * 6 / 4)
        End If
        If viewXPositive < -maxViewX.X Then '< coz both are negative...
            tmp.X = -(ViewSettings.CenterPoint.X - picSizeWithWithoutZoom.Width + maxViewX.X)
        ElseIf viewXNegative > maxViewX.Y Then
            tmp.X = maxViewX.Y - ViewSettings.CenterPoint.X
        End If
        If viewYPositive < -maxViewY.X Then '< coz both are negative...
            tmp.Y = -(ViewSettings.CenterPoint.Y - picSizeWithWithoutZoom.Height + maxViewY.X)
        ElseIf viewYNegative > maxViewY.Y Then
            tmp.Y = maxViewY.Y - ViewSettings.CenterPoint.Y
        End If

        ViewSettings.ScrollPosition = tmp
    End Sub

    Private Function GetRightValue(ByVal val As Single) As Single
        Dim valInt As Integer = Math.Truncate(val)
        Dim sig As Single = Math.Abs(val) - Math.Abs(valInt)

        If sig Mod m_realPixelSize <> 0 Then
            For i As Integer = 1 To m_big1pixel
                Dim newSig As Single = (100 * i / ViewSettings.Zoom)
                If newSig > sig Then
                    Dim lastSig As Single = 100 * (i - 1) / ViewSettings.Zoom
                    ' sig = newSig
                    If Math.Abs(newSig - sig) < Math.Abs(lastSig - sig) Then
                        sig = newSig
                    Else
                        sig = lastSig
                    End If
                    Exit For
                End If
            Next
        End If

        If val < 0 Then
            Return valInt - sig
        Else
            Return valInt + sig
        End If
    End Function

    Private Function GetRectFToDraw(ByVal rect As Rectangle, Optional ByVal withY As Boolean = False) As RectangleF
        Dim result As New RectangleF(rect.X, rect.Y, rect.Width, rect.Height)
        result.Width -= m_realPixelSize
        result.Height -= m_realPixelSize
        If withY Then
            result.X += m_realPixelSize
            result.Y += m_realPixelSize
        End If
        Return result
    End Function
    Private Sub CheckMyBitmaps()
        If IsNothing(m_textEditor) Then Exit Sub

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
            Dim setNUD As Boolean = m_bspriteIndex < 0
            If Nud_bspriteIndex.Value = m_bspriteIndex Then
                setNUD = True
            End If
            m_bspriteIndex = -1
            m_bitmapsFiles.Clear()
            For Each ms As IO.MemoryStream In m_bitmaps
                ms.Close()
                ms.Dispose()
            Next
            m_bitmaps.Clear()

            'Dim bspriteStartIndex As Integer = -1
            'Dim bspriteSpriteNumber As Integer = -1

            For Each info As FrameHeader In m_newBitmapFiles
                m_bitmapsFiles.Add(info.Clone)

                Dim characterImage As Bitmap = Nothing
                Dim filePath As String = GetFolder(m_textEditor.Path, info.Path)
                If IO.File.Exists(filePath) Then
                    characterImage = New Bitmap(filePath)
                End If
                If IsNothing(characterImage) Then
                    Exit Sub 'macht sonst kein sinn (kein bild vorhanden)
                End If

                Dim x As Integer = 0
                Dim y As Integer = 0

                Do While True
                    Dim imageClone As New Bitmap(CInt(info.Width), CInt(info.Height))
                    Dim grap As Graphics = Graphics.FromImage(imageClone)
                    grap.DrawImage(characterImage, New Rectangle(0, 0, info.Width, info.Height), New Rectangle(x * (info.Width + 1), y * (info.Height + 1), imageClone.Width, imageClone.Height), GraphicsUnit.Pixel)
                    imageClone.MakeTransparent(Color.Black)

                    Dim ms As New IO.MemoryStream
                    imageClone.Save(ms, Imaging.ImageFormat.Png)
                    m_bitmaps.Add(ms)

                    grap.Dispose()
                    imageClone.Dispose()

                    x += 1
                    If x >= info.Row Then
                        x = 0
                        y += 1
                    End If
                    If y >= info.Col Then
                        Exit Do
                    End If
                Loop
                characterImage.Dispose()
            Next

            If m_newBitmapFiles.Count > 0 AndAlso m_newBitmapFiles(m_newBitmapFiles.Count - 1).IndexS >= 140 Then
                m_bspriteIndex = 140 'HARDCODED by LF
                If setNUD Then
                    m_updatingCheckbox = True
                    m_bspriteNud.Value = m_bspriteIndex 'raise the event to change Nud_bspriteIndex
                    m_updatingCheckbox = False
                End If

                If Cb_drawBSprite.Text.Contains("?") Then
                    Cb_drawBSprite.Text = Cb_drawBSprite.Text.Replace("? ", "")
                End If
            Else
                If Not Cb_drawBSprite.Text.Contains("?") Then
                    Cb_drawBSprite.Text = "? " & Cb_drawBSprite.Text
                End If
            End If

            Preview.Invalidate()
        End If

        If App.Settings.FullRestore Then Preview.Invalidate()
    End Sub

#Region "View Options Stuff"
#Region "View"
    Private Sub TSMI_showScales_Click(sender As Object, e As EventArgs) Handles TSMI_showScales.Click, Cb_showScales.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.Scales = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_resetView_Click(sender As Object, e As EventArgs) Handles TSMI_resetView.Click
        m_updatingViewSettings = True
        ViewSettings.ScrollPosition = New PointF(0, 0)
        ViewSettings.CenterPoint = New Point((Preview.Width / 2) / ViewSettings.Zoom * 100, (Preview.Height / 2) / ViewSettings.Zoom * 100 + (80 / ViewSettings.Zoom * 100))
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_axis_Click(sender As Object, e As EventArgs) Handles TSMI_axis.Click, Cb_axis.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.Axis = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_mirrorFrame_data_Click(sender As Object, e As EventArgs) Handles TSMI_mirrorFrame_data.Click
        Tool_mirrorFrame()
    End Sub

    Private Sub TSMI_mirrorFrame_Click(sender As Object, e As EventArgs) Handles TSMI_mirrorFrame.Click
        If Not IsNothing(m_LFFrame) Then
            m_LFFrame.Facing = TSMI_mirrorFrame.Checked
            If IDToFacing.ContainsKey(m_LFFrame.ID) Then
                IDToFacing(m_LFFrame.ID) = m_LFFrame.Facing
            Else
                IDToFacing.Add(m_LFFrame.ID, m_LFFrame.Facing)
            End If
        End If
    End Sub

    Private Sub TSMI_auto_bdy_Click(sender As Object, e As EventArgs) Handles TSMI_auto_bdy.Click
        If Not IsNothing(m_LFFrame) Then
            Dim LFimg As Bitmap = New Bitmap(m_bitmaps(m_LFFrame.PicID))

            If Not IsNothing(LFimg) Then
                Dim rect As Rectangle = Tools.AutoBdy.CreateBody(LFimg)
                m_LFFrame.Bodys.Add(New Bdy() With {.Rect = New LFRect(rect.X, rect.Y, rect.Width, rect.Height)})
                If Not IsNothing(m_textEditor) Then
                    m_textEditor.AddValues(EFrameChangeType.Bdy, rect)
                End If
            End If
        End If
    End Sub

    Private m_updatingCheckbox As Boolean = False
    Private Sub TSMI_bg_image_CheckedChanged(sender As Object, e As EventArgs) Handles TSMI_bg_image.CheckedChanged
        If m_updatingCheckbox Then Exit Sub

        Dim col As Color = Color.Transparent
        If Not TSMI_bg_image.Checked Then
            col = TSMI_bg_color.Tag
        End If

        m_updatingCheckbox = True
        TSMI_bg_color.Checked = Not TSMI_bg_image.Checked
        m_updatingCheckbox = False

        ViewSettings.BackgroundColor = col
    End Sub

    Private Sub TSMI_bg_color_CheckedChanged(sender As Object, e As EventArgs) Handles TSMI_bg_color.CheckedChanged
        If Not m_updatingCheckbox Then
            TSMI_bg_image.Checked = Not TSMI_bg_color.Checked
        End If
    End Sub

    Private Sub TSMI_background_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_background.DropDownOpening
        m_updatingCheckbox = True
        TSMI_bg_color.Checked = Not m_currentShowImage
        TSMI_bg_image.Checked = m_currentShowImage
        m_updatingCheckbox = False

        If Not IsNothing(TSMI_bg_color.Image) Then
            TSMI_bg_color.Image.Dispose()
        End If

        If TypeOf TSMI_bg_color.Tag Is Color Then
            Dim newB As New Bitmap(20, 20)
            Using grap As Graphics = Graphics.FromImage(newB)
                grap.Clear(TSMI_bg_color.Tag)
                grap.Dispose()
            End Using
            TSMI_bg_color.Image = newB
        End If
    End Sub

    Private Sub TSMI_bg_col_set_Click(sender As Object, e As EventArgs) Handles TSMI_bg_col_set.Click
        Cd_bg.Color = TSMI_bg_color.Tag
        If Cd_bg.ShowDialog = DialogResult.OK Then
            App.Settings.Restorer.BackgroundColor = Cd_bg.Color

            TSMI_background_DropDownOpening(Nothing, Nothing)
        End If
    End Sub
#End Region
#Region "Character View"
    Private Sub TSMI_bodies_Click(sender As Object, e As EventArgs) Handles TSMI_bodies.Click, Cb_bodies.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.Bodies = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_itrs_Click(sender As Object, e As EventArgs) Handles TSMI_itrs.Click, Cb_itrs.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.Itrs = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_itr_3d_Click(sender As Object, e As EventArgs) Handles TSMI_itr_3d.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.Itr3D = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_wpoint_Click(sender As Object, e As EventArgs) Handles TSMI_wpoint.Click, Cb_wpoint.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.WPoint = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub Cb_wpoint_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_wpoint.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        Cb_weapon.Enabled = GetBoolValue(sender) 'cb_wpoint.Checked
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_weapon_Click(sender As Object, e As EventArgs) Handles TSMI_weapon.Click, Cb_weapon.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.Weapon = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub Cb_wHitbox_CheckedChanged(sender As Object, e As EventArgs) Handles TSMI_wHitbox.Click, Cb_wHitbox.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.WeaponHitboxes = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_bpoint_Click(sender As Object, e As EventArgs) Handles TSMI_bpoint.Click, Cb_bpoint.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.BPoint = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_opoint_Click(sender As Object, e As EventArgs) Handles TSMI_opoint.Click, Cb_opoint.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.OPoint = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_cpoint_Click(sender As Object, e As EventArgs) Handles TSMI_cpoint.Click, Cb_cpoint.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.CPoint = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_shadow_Click(sender As Object, e As EventArgs) Handles TSMI_shadow.Click, Cb_shadow.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.Shadow = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_center_xy_Click(sender As Object, e As EventArgs) Handles TSMI_center_xy.Click, Cb_center_xy.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.CenterXY = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_Fill_Click(sender As Object, e As EventArgs) Handles TSMI_Fill.Click, Cb_Fill.CheckedChanged
        If m_updatingViewSettings Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.FillRectangles = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_specials_DropDownOpening(sender As Object, e As EventArgs) Handles TSMI_specials.DropDownOpening
        m_updatingCheckbox = True
        TSMI_drawBSprite.Checked = ViewSettings.DrawBSprite
        m_updatingCheckbox = False
    End Sub

    Private Sub TSMI_drawBSprite_Click(sender As Object, e As EventArgs) Handles TSMI_drawBSprite.Click, Cb_drawBSprite.CheckedChanged
        If m_updatingViewSettings Or m_updatingCheckbox Then Exit Sub

        m_updatingViewSettings = True
        ViewSettings.DrawBSprite = GetBoolValue(sender)
        m_updatingViewSettings = False
    End Sub

    Private Sub TSMI_drawBSprite2_Click(sender As Object, e As EventArgs) Handles TSMI_drawBSprite.Click
        If m_updatingViewSettings Or m_updatingCheckbox Then Exit Sub

        m_updatingCheckbox = True
        Cb_drawBSprite.Checked = TSMI_drawBSprite.Checked
        m_updatingCheckbox = False
    End Sub

    Private Sub Nud_bspriteIndex_ValueChanged(sender As Object, e As EventArgs) Handles Nud_bspriteIndex.ValueChanged
        If m_updatingCheckbox Then Exit Sub

        Preview.Invalidate()
    End Sub
#End Region
    'in progress
    Private Sub DebugTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugTestToolStripMenuItem.Click
        m_animationPreview = Not m_animationPreview
    End Sub

    Private Sub TB_Opacity_ValueChanged(sender As Object, e As EventArgs) Handles TB_Opacity.ValueChanged
        m_ia.SetColorMatrix(New Imaging.ColorMatrix With {
            .Matrix33 = TB_Opacity.Value / 100.0F
        })

        If Not m_updatingViewSettings Then
            m_updatingViewSettings = True
            ViewSettings.CharacterOpacity = TB_Opacity.Value
            m_updatingViewSettings = False
        End If
    End Sub

    Private Function GetBoolValue(ByVal sender As Object) As Boolean
        Dim result As Boolean = False
        If TypeOf (sender) Is ToolStripMenuItem Then
            result = CType(sender, ToolStripMenuItem).Checked
        ElseIf TypeOf (sender) Is CheckBox Then
            result = CType(sender, CheckBox).Checked
        End If

        Return result
    End Function
#End Region

#Region "Tools"
    Public Sub Tool_mirrorFrame()
        If Not IsNothing(m_LFFrame) And Not IsNothing(m_textEditor) Then
            m_textEditor.FrameViewer_MouseDown() 'undo/redo action
            m_undoItems.Add(New UndoRedoItem(m_textEditor.Scintilla1.UndoSize, UndoRedoItem.EEvent.MirroredFrame, m_LFFrame.ID))
            Dim imgWidth As Integer = -1
            For Each clsBit As FrameHeader In m_newBitmapFiles
                If m_LFFrame.PicID >= clsBit.IndexS And m_LFFrame.PicID <= clsBit.IndexE Then
                    imgWidth = clsBit.Width
                End If
            Next

            If imgWidth < 0 Then
                For Each clsBit As FrameHeader In m_bitmapsFiles
                    If m_LFFrame.PicID >= clsBit.IndexS And m_LFFrame.PicID <= clsBit.IndexE Then
                        imgWidth = clsBit.Width
                    End If
                Next
            End If


            If imgWidth >= 0 And Not IsNothing(m_textEditor) Then
                m_LFFrame.Center.X = imgWidth - m_LFFrame.Center.X
                m_textEditor.ChangeValues(m_LFFrame, EFrameChangeType.CenterXY, m_selectedObject.Index)

                For i As Integer = 0 To m_LFFrame.Bodys.Count - 1
                    m_LFFrame.Bodys(i).Rect.X = imgWidth - m_LFFrame.Bodys(i).Rect.Width - m_LFFrame.Bodys(i).Rect.X
                    m_textEditor.ChangeValues(m_LFFrame, EFrameChangeType.Bdy, i)
                Next
                For i As Integer = 0 To m_LFFrame.Itrs.Count - 1
                    m_LFFrame.Itrs(i).Rect.X = imgWidth - m_LFFrame.Itrs(i).Rect.Width - m_LFFrame.Itrs(i).Rect.X
                    m_textEditor.ChangeValues(m_LFFrame, EFrameChangeType.Itr, i)
                Next

                If Not IsNothing(m_LFFrame.WPoint) Then
                    m_LFFrame.WPoint.Loca.X = imgWidth - m_LFFrame.WPoint.Loca.X
                    If Not (m_LFFrame.ID >= 12 And m_LFFrame.ID < 20 Or m_LFFrame.ID >= 50 And m_LFFrame.ID <= 51 Or m_LFFrame.ID >= 116 And m_LFFrame.ID <= 117) Then
                        m_LFFrame.WPoint.Weaponact = -m_LFFrame.WPoint.Weaponact + 56
                    End If
                    m_textEditor.ChangeValues(m_LFFrame, EFrameChangeType.WPoint, 0)
                End If

                If Not m_LFFrame.BPoint.X = Integer.MaxValue And Not m_LFFrame.BPoint.Y = Integer.MaxValue Then
                    m_LFFrame.BPoint.X = imgWidth - m_LFFrame.BPoint.X
                    m_textEditor.ChangeValues(m_LFFrame, EFrameChangeType.BPoint, 0)
                End If
                If Not m_LFFrame.OPoint.X = Integer.MaxValue And Not m_LFFrame.OPoint.Y = Integer.MaxValue Then
                    m_LFFrame.OPoint.X = imgWidth - m_LFFrame.OPoint.X
                    m_textEditor.ChangeValues(m_LFFrame, EFrameChangeType.OPoint, 0)
                End If
                If Not m_LFFrame.CPoint.X = Integer.MaxValue And Not m_LFFrame.CPoint.Y = Integer.MaxValue Then
                    m_LFFrame.CPoint.X = imgWidth - m_LFFrame.CPoint.X
                    m_textEditor.ChangeValues(m_LFFrame, EFrameChangeType.CPoint, 0)
                End If

                m_LFFrame.Facing = Not m_LFFrame.Facing
                If IDToFacing.ContainsKey(m_LFFrame.ID) Then
                    IDToFacing(m_LFFrame.ID) = m_LFFrame.Facing
                Else
                    IDToFacing.Add(m_LFFrame.ID, m_LFFrame.Facing)
                End If
                TSMI_mirrorFrame.Checked = m_LFFrame.Facing
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
            m_textEditor.FrameViewer_MouseUp() 'undo/redo action
        End If
    End Sub
#End Region

#Region "Called from TextEditor"
    Public Sub HeaderChanged(ByVal e As String)
        m_newBitmapFiles.Clear()
        Dim lastLength As Integer = 0
        For Each line As String In Split(e, ControlChars.Lf)
            If Regex.IsMatch(line, "file\([0-9]+-[0-9]+\):", RegexOptions.IgnoreCase) Then
                Dim file As String = GetRegexValue(line, "(?<=file\([0-9]+-[0-9]+\):\s*)[^:;]+\.[A-Za-z0-9]{1,5}", RegexOptions.IgnoreCase)
                Dim w As String = GetRegexValue(line, "(?<=\s+w:\s*)[0-9]+", RegexOptions.IgnoreCase)
                Dim h As String = GetRegexValue(line, "(?<=\s+h:\s*)[0-9]+", RegexOptions.IgnoreCase)
                Dim row As String = GetRegexValue(line, "(?<=\s+row:\s*)[0-9]+", RegexOptions.IgnoreCase)
                Dim col As String = GetRegexValue(line, "(?<=\s+col:\s*)[0-9]+", RegexOptions.IgnoreCase)

                If Not (String.IsNullOrEmpty(file) Or IsNothing(w) Or IsNothing(h) Or IsNothing(row) Or IsNothing(col)) Then
                    m_newBitmapFiles.Add(New FrameHeader(file.Trim,
                                                Convert.ToInt64(w.Trim), Convert.ToInt64(h.Trim), Convert.ToInt64(row.Trim), Convert.ToInt64(col.Trim), lastLength))
                    lastLength += m_newBitmapFiles(m_newBitmapFiles.Count - 1).Count
                End If
            End If
        Next

        'Dim startDate As Date = Date.Now
        If Visible Then
            CheckMyBitmaps()
        End If
        'Console.WriteLine("character: " & (Date.Now - startDate).TotalMilliseconds)
    End Sub

    Public Sub FrameChanged(ByVal textFrame As TextFrame)
        If IsNothing(textFrame) Then
            m_LFFrame = Nothing
            Preview.Invalidate()
            Exit Sub
        End If

        m_LFFrame = New Frame

        Dim frameCode As String = textFrame.Lines
        SetFrameIfSuccess(m_LFFrame.ID, frameCode, "(?<=<frame>\s+)[0-9]+")
        If IDToFacing.ContainsKey(m_LFFrame.ID) Then
            m_LFFrame.Facing = IDToFacing(m_LFFrame.ID)
        End If
        TSMI_mirrorFrame.Checked = m_LFFrame.Facing

        For Each bdyFrame As Point In textFrame.OffsetBodies
            Dim startIndex As Integer = bdyFrame.X - textFrame.Offset
            Dim bdyText As String = frameCode.Substring(startIndex, bdyFrame.Y - textFrame.Offset - startIndex)
            Dim bdy As New Bdy
            SetFrameIfSuccess(bdy.Kind, bdyText, "(?<=(\s+kind|^kind):\s*)[0-9]+")
            SetFrameIfSuccess(bdy.Rect.X, bdyText, "(?<=(\s+x|^x):\s*)[0-9-]+")
            SetFrameIfSuccess(bdy.Rect.Y, bdyText, "(?<=(\s+y|^y):\s*)[0-9-]+")
            SetFrameIfSuccess(bdy.Rect.Width, bdyText, "(?<=(\s+w|^w):\s*)[0-9]+")
            SetFrameIfSuccess(bdy.Rect.Height, bdyText, "(?<=(\s+h|^h):\s*)[0-9]+")
            m_LFFrame.Bodys.Add(bdy)
        Next

        For Each itrFrame As Point In textFrame.OffsetItrs
            Dim startIndex As Integer = itrFrame.X - textFrame.Offset
            Dim itrText As String = frameCode.Substring(startIndex, itrFrame.Y - textFrame.Offset - startIndex)
            Dim itr As New Itr
            SetFrameIfSuccess(itr.Kind, itrText, "(?<=(\s+kind|^kind):\s*)[0-9]+")
            SetFrameIfSuccess(itr.Rect.X, itrText, "(?<=(\s+x|^x):\s*)[0-9-]+")
            SetFrameIfSuccess(itr.Rect.Y, itrText, "(?<=(\s+y|^y):\s*)[0-9-]+")
            SetFrameIfSuccess(itr.Rect.Width, itrText, "(?<=(\s+w|^w):\s*)[0-9]+")
            SetFrameIfSuccess(itr.Rect.Height, itrText, "(?<=(\s+h|^h):\s*)[0-9]+")
            SetFrameIfSuccess(itr.zWidth, itrText, "(?<=(\s+zwidth|^zwidth):\s*)[0-9]+")
            m_LFFrame.Itrs.Add(itr)
        Next

        If textFrame.OffsetWPoint.X >= 0 Then
            Dim startIndex As Integer = textFrame.OffsetWPoint.X - textFrame.Offset
            Dim checkText As String = frameCode.Substring(startIndex, textFrame.OffsetWPoint.Y - textFrame.Offset - startIndex)

            m_LFFrame.WPoint = New WPoint
            SetFrameIfSuccess(m_LFFrame.WPoint.Kind, checkText, "(?<=(\s+kind|^kind):\s*)[0-9]+")
            SetFrameIfSuccess(m_LFFrame.WPoint.Loca.X, checkText, "(?<=(\s+x|^x):\s*)[0-9-]+")
            SetFrameIfSuccess(m_LFFrame.WPoint.Loca.Y, checkText, "(?<=(\s+y|^y):\s*)[0-9-]+")

            SetFrameIfSuccess(m_LFFrame.WPoint.Weaponact, checkText, "(?<=(\s+weaponact|^weaponact):\s*)[0-9]+")
            SetFrameIfSuccess(m_LFFrame.WPoint.Attacking, checkText, "(?<=(\s+attacking|^attacking):\s*)[0-9]+")
            SetFrameIfSuccess(m_LFFrame.WPoint.Cover, checkText, "(?<=(\s+cover|^cover):\s*)[0-9]+")
        End If

        If textFrame.OffsetBPoint.X >= 0 Then
            Dim startIndex As Integer = textFrame.OffsetBPoint.X - textFrame.Offset
            Dim checkText As String = frameCode.Substring(startIndex, textFrame.OffsetBPoint.Y - textFrame.Offset - startIndex)

            SetFrameIfSuccess(m_LFFrame.BPoint.X, checkText, "(?<=(\s+x|^x):\s*)[0-9-]+")
            SetFrameIfSuccess(m_LFFrame.BPoint.Y, checkText, "(?<=(\s+y|^y):\s*)[0-9-]+")
        End If

        If textFrame.OffsetCPoint.X >= 0 Then
            Dim startIndex As Integer = textFrame.OffsetCPoint.X - textFrame.Offset
            Dim checkText As String = frameCode.Substring(startIndex, textFrame.OffsetCPoint.Y - textFrame.Offset - startIndex)

            SetFrameIfSuccess(m_LFFrame.CPoint.X, checkText, "(?<=(\s+x|^x):\s*)[0-9-]+")
            SetFrameIfSuccess(m_LFFrame.CPoint.Y, checkText, "(?<=(\s+y|^y):\s*)[0-9-]+")
        End If

        If textFrame.OffsetOPoint.X >= 0 Then
            Dim startIndex As Integer = textFrame.OffsetOPoint.X - textFrame.Offset
            Dim checkText As String = frameCode.Substring(startIndex, textFrame.OffsetOPoint.Y - textFrame.Offset - startIndex)

            SetFrameIfSuccess(m_LFFrame.OPoint.X, checkText, "(?<=(\s+x|^x):\s*)[0-9-]+")
            SetFrameIfSuccess(m_LFFrame.OPoint.Y, checkText, "(?<=(\s+y|^y):\s*)[0-9-]+")
        End If

        SetFrameIfSuccess(m_LFFrame.PicID, frameCode, "(?<=(\s+pic|^pic):\s*)[0-9]+")
        'SetFrameIfSuccess(m_LFFrame.state, frameCode, "(?<=(\s+state|^state):\s*)[0-9]+")
        SetFrameIfSuccess(m_LFFrame.Next, frameCode, "(?<=(\s+next|^next):\s*)[0-9-]+")
        SetFrameIfSuccess(m_LFFrame.Wait, frameCode, "(?<=(\s+wait|^wait):\s*)[0-9-]+")
        SetFrameIfSuccess(m_LFFrame.Center.X, frameCode, "(?<=(\s+centerx|^centerx):\s*)[0-9-]+")
        SetFrameIfSuccess(m_LFFrame.Center.Y, frameCode, "(?<=(\s+centery|^centery):\s*)[0-9-]+")

        SetFrameIfSuccess(m_LFFrame.DvX, frameCode, "(?<=(\s+dvx|^dvx):\s*)[0-9-]+")
        SetFrameIfSuccess(m_LFFrame.DvY, frameCode, "(?<=(\s+dvy|^dvy):\s*)[0-9-]+")
        SetFrameIfSuccess(m_LFFrame.DvZ, frameCode, "(?<=(\s+dvz|^dvz):\s*)[0-9-]+")

        If m_currentWait >= 0 Or Not m_animationPreview Then 'user changed the frame
            CharacterPosition = New Point()
        End If

        m_currentWait = m_LFFrame.Wait
        Preview.Invalidate()
    End Sub
#End Region

    Public Sub ToggleBSpriteOption()

    End Sub

    Public Sub Kill()
        For Each ms As IO.MemoryStream In m_bitmaps
            ms.Close()
            ms.Dispose()
        Next
        m_bitmaps.Clear()

        If Not IsNothing(FrameImage) Then
            FrameImage.Dispose()
        End If
    End Sub
End Class