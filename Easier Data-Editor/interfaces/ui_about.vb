'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class ui_about
    Public Sub New()
        InitializeComponent()
        rtb_story.SelectionStart = rtb_story.TextLength
        lbl_version_value.Text = Application.ProductVersion.ToString & " (STM93 Version)"
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub lblLink_cookiesoft_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLink_cookiesoft.LinkClicked
        Process.Start("http://cookiesoft.lui-studio.net/")
    End Sub

    Private Sub lblLink_library1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLink_library1.LinkClicked
        Process.Start("https://github.com/icsharpcode/AvalonEdit")
    End Sub

    Private Sub lblLink_library2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLink_library2.LinkClicked
        Process.Start("https://github.com/dockpanelsuite/dockpanelsuite")
    End Sub

    Private Sub btn_okay_Click(sender As Object, e As EventArgs) Handles btn_okay.Click
        Me.Close()
    End Sub
End Class