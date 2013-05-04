Public Class CBOD

    Private Sub CBOD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = My.Settings.Version
        Clef.musicPlayer.Ctlcontrols.pause()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Visible = False
        Desktop.Show()
    End Sub
End Class