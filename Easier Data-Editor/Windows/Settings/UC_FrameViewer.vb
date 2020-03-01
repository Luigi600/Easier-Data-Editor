'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

<System.ComponentModel.ToolboxItem(False)>
Public Class UC_FrameViewer
    Private settings As Settings = Nothing
    Private m_updating As Boolean = True

    Public Sub New(ByRef settings As Settings)
        Me.settings = settings
        InitializeComponent()

        Cb_ms.Checked = settings.FrameViewerMenuStrip
        Pic_defaultBG.BackColor = settings.FrameViewerBGColor
        Cb_globalView.Checked = settings.GlobalView
        Cb_fullRestore.Checked = settings.FullRestore
        Cb_direct.Checked = settings.ChangeDirectFV
        Txt_weaponData.Text = settings.WeaponData
        Txt_weaponSprite.Text = settings.WeaponSprite
        Txt_hweaponData.Text = settings.HeavyWeaponData
        Txt_hweaponSprite.Text = settings.HeavyWeaponSprite

        m_updating = False
    End Sub

    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatableControls.AddRange({Txt_weaponData, Txt_weaponSprite, Txt_hweaponData, Txt_hweaponSprite})
    End Sub

    Private Sub Cb_ms_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_ms.CheckedChanged
        If Not m_updating Then
            settings.FrameViewerMenuStrip = Cb_ms.Checked
        End If
    End Sub

    Private Sub Pic_defaultBG_BackColorChanged(sender As Object, e As EventArgs) Handles Pic_defaultBG.BackColorChanged
        If Not m_updating Then
            settings.FrameViewerBGColor = Pic_defaultBG.BackColor
        End If
    End Sub

    Private Sub Btn_defaultBG_Click(sender As Object, e As EventArgs) Handles Btn_defaultBG.Click
        CD_defaultBG.Color = Pic_defaultBG.BackColor
        If CD_defaultBG.ShowDialog() = DialogResult.OK Then
            Pic_defaultBG.BackColor = CD_defaultBG.Color
        End If
    End Sub

    Private Sub Btn_image_Click(sender As Object, e As EventArgs) Handles Btn_image.Click
        settings.FrameViewerBGColor = Color.Transparent
        Pic_defaultBG.BackColor = settings.FrameViewerBGColor
    End Sub

    Private Sub Cb_globalView_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_globalView.CheckedChanged
        If Not m_updating Then
            settings.GlobalView = Cb_globalView.Checked
        End If
    End Sub

    Private Sub Cb_fullRestore_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_fullRestore.CheckedChanged
        If Not m_updating Then
            settings.FullRestore = Cb_fullRestore.Checked
        End If
    End Sub

    Private Sub Cb_direct_CheckedChanged(sender As Object, e As EventArgs) Handles Cb_direct.CheckedChanged
        If Not m_updating Then
            settings.ChangeDirectFV = Cb_direct.Checked
        End If
    End Sub

    Private Sub Btn_changePathWeaponData_Click(sender As Object, e As EventArgs) Handles Btn_changePathWeaponData.Click
        If OFD_data.ShowDialog() = DialogResult.OK Then
            Txt_weaponData.Text = OFD_data.FileName
        End If
    End Sub

    Private Sub Btn_changePathWeaponSprite_Click(sender As Object, e As EventArgs) Handles Btn_changePathWeaponSprite.Click
        If OFD_sprite.ShowDialog() = DialogResult.OK Then
            Txt_weaponSprite.Text = OFD_sprite.FileName
        End If
    End Sub

    Private Sub Btn_changePathHWeaponData_Click(sender As Object, e As EventArgs) Handles Btn_changePathHWeaponData.Click
        If OFD_data.ShowDialog() = DialogResult.OK Then
            Txt_hweaponData.Text = OFD_data.FileName
        End If
    End Sub

    Private Sub Btn_changePathHWeaponSprite_Click(sender As Object, e As EventArgs) Handles Btn_changePathHWeaponSprite.Click
        If OFD_sprite.ShowDialog() = DialogResult.OK Then
            Txt_hweaponSprite.Text = OFD_sprite.FileName
        End If
    End Sub

    Private Sub Txt_weaponData_TextChanged(sender As Object, e As EventArgs) Handles Txt_weaponData.TextChanged
        If Not m_updating Then
            settings.WeaponData = Txt_weaponData.Text
        End If
        Lbl_wdataFound.Visible = Not IO.File.Exists(Txt_weaponData.Text)
    End Sub

    Private Sub Txt_weaponSprite_TextChanged(sender As Object, e As EventArgs) Handles Txt_weaponSprite.TextChanged
        If Not m_updating Then
            settings.WeaponSprite = Txt_weaponSprite.Text
        End If
        Lbl_wspriteFound.Visible = Not IO.File.Exists(Txt_weaponSprite.Text)
    End Sub

    Private Sub Txt_hweaponData_TextChanged(sender As Object, e As EventArgs) Handles Txt_hweaponData.TextChanged
        If Not m_updating Then
            settings.HeavyWeaponData = Txt_hweaponData.Text
        End If
        Lbl_hwdataFound.Visible = Not IO.File.Exists(Txt_hweaponData.Text)
    End Sub

    Private Sub Txt_hweaponSprite_TextChanged(sender As Object, e As EventArgs) Handles Txt_hweaponSprite.TextChanged
        If Not m_updating Then
            settings.HeavyWeaponSprite = Txt_hweaponSprite.Text
        End If
        Lbl_hwSpriteFound.Visible = Not IO.File.Exists(Txt_hweaponSprite.Text)
    End Sub
End Class