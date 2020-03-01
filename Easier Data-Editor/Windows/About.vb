'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>

Public Class About
    Protected Overrides Sub SetNotTranslatableThings()
        NotTranslatablePrefix = AppTitle
        NotTranslatableControls.AddRange({Lbl_creator_value, LblLink_cookiesoft, Link_library1, Link_library2, Lbl_version_value, Lbl_version_value2})
    End Sub

    Public Sub New()
        InitializeComponent()
        Rtb_story.SelectionStart = Rtb_story.TextLength

        Dim oAssembly As Reflection.AssemblyName = Reflection.Assembly.GetExecutingAssembly().GetName
        Lbl_version_value.Text = oAssembly.Version.ToString & " (STM93 Version)"
        Lbl_version_value2.Text = Application.ProductVersion.ToString
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub LblLink_cookiesoft_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblLink_cookiesoft.LinkClicked
        Process.Start("http://cookiesoft.lui-studio.net/")
    End Sub

    Private Sub LblLink_library1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_library1.LinkClicked
        Process.Start("https://github.com/jacobslusser/ScintillaNET")
    End Sub

    Private Sub LblLink_library2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_library2.LinkClicked
        Process.Start("https://github.com/dockpanelsuite/dockpanelsuite")
    End Sub

    Private Sub Btn_okay_Click(sender As Object, e As EventArgs) Handles Btn_okay.Click
        Me.Close()
    End Sub
End Class