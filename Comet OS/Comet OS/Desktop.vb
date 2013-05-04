
Imports System.Net.Mail
Public Class Desktop
    Dim signature As String = Environment.NewLine & Environment.NewLine & "Sent from Comet OS."

    Sub initializeTime()
        Timer1.Enabled = True
        Label1.Text = TimeOfDay
    End Sub

    Public Sub loadBackground()
        Try
            If My.Settings.background.ToString = "Default" Then
                Me.BackgroundImage = My.Resources.gradient_wallpaper_31
            ElseIf My.Settings.background.ToString = "Leaves" Then
                Me.BackgroundImage = My.Resources.DSC06239
            ElseIf My.Settings.background.ToString = "Stars" Then
                Me.BackgroundImage = My.Resources.stars
            ElseIf My.Settings.background.ToString = "Pattern" Then
                Me.BackgroundImage = My.Resources.black_textures_hd_background_squares_210945
            ElseIf My.Settings.background.ToString = "Glow" Then
                Me.BackgroundImage = My.Resources.CometOSDesktop1
            ElseIf My.Settings.background.ToString = "Moon" Then
                Me.BackgroundImage = My.Resources.darkWindowdesktop
            ElseIf My.Settings.background.ToString = "Mountains" Then
                Me.BackgroundImage = My.Resources.CometOSmnts
            ElseIf My.Settings.background.ToString = "Comet OS beta 3 Logo" Then
                Me.BackgroundImage = My.Resources.CometOSLogo1
            ElseIf My.Settings.background.ToString = "Comet OS 2.6 Logo" Then
                Me.BackgroundImage = My.Resources.Comet_OS
            End If
            If My.Settings.DesktopImageLayout = "Zoom" Then
                Me.BackgroundImageLayout = ImageLayout.Zoom
            ElseIf My.Settings.DesktopImageLayout = "Center" Then
                Me.BackgroundImageLayout = ImageLayout.Center
            ElseIf My.Settings.DesktopImageLayout = "Stretch" Then
                Me.BackgroundImageLayout = ImageLayout.Stretch
            ElseIf My.Settings.DesktopImageLayout = "Tile" Then
                Me.BackgroundImageLayout = ImageLayout.Tile
            ElseIf My.Settings.DesktopImageLayout = "None" Then
                Me.BackgroundImageLayout = ImageLayout.None
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Desktop_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        initializeTime()
        loadBackground()
        Settings.CachedApps.Items.Add("SystemProcess::Desktop")
        Console.CommandLog.Items.Add("Initialized DesktopManager at " & TimeOfDay)
        Me.Opacity = 0
        FadeIn.Interval = 1
        FadeIn.Enabled = True
        FadeOut.Interval = 1
        FadeOut.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = TimeOfDay
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sapphire.Close()
        Clef.Close()
        EpicText.Close()
        Space_Invaders.Close()
        RlsNotes.Close()
        Calculator.Close()
        LoginForm.Show()
        FlashViewer.Close()
        Settings.Close()
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Sapphire.Visible = False Then
            Sapphire.Show()
        End If
        Sapphire.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Clef.Visible = False Then
            Clef.Show()
        End If
        Clef.Show()
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        MonthCalendar1.Visible = False
        If sysMenu.Visible = False Then
            sysMenu.Show()
        ElseIf sysMenu.Visible = True Then
            sysMenu.Visible = False
        End If
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        Label2.ForeColor = Color.DimGray
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.White
    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        If Clef.Visible = False Then
            Clef.Visible = True
            PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            Label5.Visible = False
            Label7.Visible = False
            Label15.Visible = False
        End If
    End Sub

    Private Sub Label5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.MouseEnter
        Label5.ForeColor = Color.DimGray
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.White

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If Clef.musicPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Clef.musicPlayer.Ctlcontrols.pause()
            PictureBox2.BackgroundImage = My.Resources.Play1

        ElseIf Clef.musicPlayer.playState = WMPLib.WMPPlayState.wmppsPaused Then
            Clef.musicPlayer.Ctlcontrols.play()
            PictureBox2.BackgroundImage = My.Resources.pause1
        End If
    End Sub

    Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Try
            Label7.Text = Clef.musicPlayer.currentMedia.name
        Catch ex As Exception

        End Try
        If Clef.Music.SelectedIndex < Clef.Music.Items.Count - 1 Then
            Clef.Music.SelectedIndex = Clef.Music.SelectedIndex + 1
            Dim Filename As String = Clef.Music.SelectedItem
            Clef.musicPlayer.URL = Filename
            Clef.musicPlayer.Ctlcontrols.play()
        Else

            Clef.Music.SelectedIndex = 0
            Dim Filename As String = Clef.Music.SelectedItem
            Clef.musicPlayer.URL = Filename

        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

        If Clef.Music.SelectedIndex = 0 Then
            Clef.Music.SelectedIndex = 1
        End If


        Clef.Music.SelectedIndex = Clef.Music.SelectedIndex - 1
        Dim Filename As String = Clef.Music.SelectedItem
        Clef.musicPlayer.URL = Filename

    End Sub

    Private Sub Desktop_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Console.CommandLog.Items.Add("Complete System Failure(DesktopManager has been terminated)")
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        AppBin.Show()
        AppBin.BringToFront()
        MonthCalendar1.Visible = False
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        PictureBox5.BackgroundImage = My.Resources.appbinrollover
    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.BackgroundImage = My.Resources.Folder_grey_icon
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If MonthCalendar1.Visible = False Then
            MonthCalendar1.Visible = True '
        ElseIf MonthCalendar1.Visible = True Then
            MonthCalendar1.Visible = False
        End If
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.Silver
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.White
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

    Private Sub PictureBox5_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseDown
        PictureBox5.BackgroundImage = My.Resources.appbinclick
    End Sub

    Private Sub PictureBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseUp
        PictureBox5.BackgroundImage = My.Resources.Folder_grey_icon
    End Sub

    Private Sub cursorSync_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cursorSync.Tick
        x.Text = Windows.Forms.Cursor.Position.X.ToString
        y.Text = Windows.Forms.Cursor.Position.Y.ToString
    End Sub

    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click
        Panel2.Visible = False
        cursorSync.Stop()
    End Sub
End Class