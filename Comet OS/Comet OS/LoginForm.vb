Public Class LoginForm

    Private Sub shutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles shutdown.Click
        End
    End Sub

    Private Sub create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles create.Click
        accountCreate.Show()
    End Sub
    Private Sub login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login.Click
        If username.Text <> My.Settings.Username Then
            errorMessage.Show()
            errorMessage.message.Text = "Invalid username."
            errorMessage.title.Text = "Login error"

        ElseIf password.Text <> My.Settings.Password Then
            errorMessage.Show()
            errorMessage.message.Text = "Invalid password."
            errorMessage.title.Text = "Login error"

        ElseIf username.Text = My.Settings.Username And password.Text = My.Settings.Password Then
            Desktop.Show()
        End If
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

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        FadeIn.Interval = 1
        FadeIn.Enabled = True
        FadeOut.Interval = 1
        FadeOut.Enabled = False
    End Sub
End Class
