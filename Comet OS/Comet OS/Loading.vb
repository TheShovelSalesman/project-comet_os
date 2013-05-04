Imports System.Net
Public Class Loading
    
    Sub initializeAppCaching()
        Me.Visible = False
        Console.CommandLog.Items.Add("Starting up Comet OS at " & TimeOfDay & "...")
        Label9.Text = "Initializing Application Cache..."
        Console.Show()
        Console.Visible = False
        Clef.Show()
        Label9.Text = "Loading Clef..."
        Clef.Visible = False
        Sapphire.Show()
        Label9.Text = "Loading CelloNet..."
        Sapphire.Visible = False
        EpicText.Show()
        Label9.Text = "Loading EpicText..."
        EpicText.Visible = False
        Settings.Show()
        Label9.Text = "Loading user settings..."
        Settings.Visible = False
        About.Show()
        About.Visible = False
        download.Show()
        download.Visible = False
        Timer1.Enabled = True
        Console.CommandLog.Items.Add("Comet OS has initialized AppCache and started up services at " & TimeOfDay)
        Me.Visible = True
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LoginForm.Visible = True
        Me.Visible = False
    End Sub

    Private Sub Loading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Opacity = 0
            FadeIn.Interval = 1
            FadeIn.Enabled = True
            FadeOut.Interval = 1
            FadeOut.Enabled = False
            initializeAppCaching()
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.message.Text = "Failed to initialize application caching," + Environment.NewLine + "go to the console for more info."
            errorMessage.title.Text = "Comet OS"
            Console.CommandLog.Items.Add("An error occured at " & TimeOfDay & " while initializing AppCache." & Environment.NewLine & "Please re-install Comet OS.")
        End Try
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