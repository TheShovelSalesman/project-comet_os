Public Class sysMenu


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        FlashViewer.Show()
        Me.Visible = False
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Console.Show()
        Me.Visible = False
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Calculator.Show()
        Me.Visible = False
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Space_Invaders.Show()
        Me.Visible = False
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        qwop.Show()
        Me.Visible = False
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        EpicText.Show()
        Me.Visible = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Clef.Show()
        Me.Visible = False
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Sapphire.Show()
        Me.Visible = False
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        AppBin.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RlsNotes.Show()
        Me.Visible = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Settings.Show()
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Sapphire.Close()
        Clef.Close()
        EpicText.Close()
        Space_Invaders.Close()
        RlsNotes.Close()
        Calculator.Close()
        LoginForm.Show()
        FlashViewer.Close()
        Settings.Close()
        Desktop.Close()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Label3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.Click
        About.Show()
        Me.Visible = False
    End Sub

    Private Sub Label3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.MouseEnter
        Label3.ForeColor = Color.DimGray
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.Black
    End Sub

    Private Sub sysMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = My.Computer.Screen.Bounds.Left
        Me.Top = My.Computer.Screen.Bounds.Top + 32
        Label4.Text = LoginForm.username.Text
        If LoginForm.username.Text = "" Then
            Label4.Text = "No name specified"
        End If
        Me.Opacity = 0
        FadeIn.Interval = 1
        FadeIn.Enabled = True
        FadeOut.Interval = 1
        FadeOut.Enabled = False
    End Sub

    Private Sub sysMenu_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub

    Private Sub FadeIn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FadeIn.Tick
        If Me.Opacity = 1 Then
            FadeIn.Stop() 'if Opacity = 1, Timer1 will stop
        Else
            Me.Opacity += 0.1 'Opacity value will be increased with 0.02
        End If
    End Sub

    Private Sub FadeOut_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FadeOut.Tick
        If Me.Opacity = 0 Then
            FadeOut.Stop()
            End 'Close the Application
        Else
            Me.Opacity -= 0.1 'Opacity will decrement with 0.02
        End If
    End Sub
End Class