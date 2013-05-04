Public Class Clef

    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim CurPos, AppSize As New Point(0, 0)
    Dim oloc As New Point(0, 0)
    Dim ocur As New Point(System.Windows.Forms.Cursor.Position)

     
    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click
        Me.Visible = False
        musicPlayer.Ctlcontrols.pause()
        My.Settings.Save()
    End Sub

    Private Sub Label7_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Clef_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
        Desktop.PictureBox2.Visible = False
        Desktop.Label5.Visible = False
    End Sub

    Private Sub Clef_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Clef_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub Clef_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub button2_Click(sender As System.Object, e As System.EventArgs) Handles button2.Click
        ImportDiag.ShowDialog()
    End Sub

    Private Sub ImportDiag_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ImportDiag.FileOk
        For Each track As String In ImportDiag.FileNames
            Music.Items.Add(track)
            My.Settings.Music.Add(track)
            My.Settings.Save()

        Next
    End Sub

    Private Sub Clef_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        For Each song As String In My.Settings.Music
            Music.Items.Add(song)
            My.Settings.Save()

        Next
        Settings.CachedApps.Items.Add("Process::Clef")
        Console.CommandLog.Items.Add("Opened Clef at " & TimeOfDay)
    End Sub

    Private Sub Music_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Music.DoubleClick
        Try
            musicPlayer.URL = Music.SelectedItem
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.title.Text = "Clef Media Player"
            errorMessage.message.Text = "Unable to play file, check to see if it is a media file."
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        musicPlayer.fullScreen = True
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Visible = False
        Desktop.PictureBox2.Visible = True
        Desktop.PictureBox3.Visible = True
        Desktop.PictureBox4.Visible = True
        Desktop.Label5.Visible = True
        Desktop.Label5.Visible = True
        Desktop.Label7.Visible = True
        Desktop.Label15.Visible = True
        Try
            Desktop.Label7.Text = musicPlayer.currentMedia.name
        Catch ex As Exception

        End Try
        If musicPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Desktop.PictureBox2.BackgroundImage = My.Resources.pause1
        ElseIf musicPlayer.playState = WMPLib.WMPPlayState.wmppsPaused Then
            Desktop.PictureBox2.BackgroundImage = My.Resources.Play1
        End If
    End Sub

    Private Sub Label1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.DimGray
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
    End Sub

    Private Sub Clef_Deactivate(sender As System.Object, e As System.EventArgs) Handles MyBase.Deactivate
        Me.Opacity = 0.5
    End Sub

   
  
    Private Sub musicPlayer_PlayStateChange(sender As System.Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles musicPlayer.PlayStateChange


        Try
            Desktop.Label7.Text = musicPlayer.currentMedia.name
        Catch ex As Exception

        End Try
        If musicPlayer.playState <> WMPLib.WMPPlayState.wmppsPlaying Then
            Button1.Enabled = False
        ElseIf musicPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Button1.Enabled = True
        End If
        If musicPlayer.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            If Music.SelectedIndex < Music.Items.Count - 1 Then
                Desktop.PictureBox3_Click(Me, EventArgs.Empty)
            Else

                Music.SelectedIndex = 0
                Dim Filename As String = Music.SelectedItem
                musicPlayer.URL = Filename
                musicPlayer.Ctlcontrols.play()
            End If
        End If
    End Sub

    Private Sub Music_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Music.SelectedIndexChanged
        Dim Filename As String = Music.SelectedItem
        musicPlayer.URL = Filename
        musicPlayer.Ctlcontrols.play()
    End Sub

    Private Sub Clef_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process::Clef")
        Console.CommandLog.Items.Add("ProcessTerminated(Clef)")
        Desktop.PictureBox2.Visible = False
        Desktop.PictureBox3.Visible = False
        Desktop.PictureBox4.Visible = False
        Desktop.Label5.Visible = False
        Desktop.Label7.Visible = False
        Desktop.Label15.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Music.Items.Clear()
        My.Settings.Music.Clear()
        My.Settings.Save()
    End Sub

   
    Private Sub Clef_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible = True Then

            Desktop.PictureBox2.Visible = False
            Desktop.PictureBox3.Visible = False
            Desktop.PictureBox4.Visible = False
            Desktop.Label5.Visible = False
            Desktop.Label7.Visible = False
            Desktop.Label15.Visible = False
        End If
    End Sub

    Private Sub resizer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resizer.Tick
        Me.Size = AppSize - CurPos + Cursor.Position
        refpositions()
    End Sub
    Sub syncSizeArghIHateTimers()
        CurPos = Cursor.Position
        AppSize = Me.Size
    End Sub
    Private Sub refpositions()
        oloc = Me.Location
        ocur = System.Windows.Forms.Cursor.Position
    End Sub

    Private Sub resizePanel_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles resizePanel.MouseDown
        resizer.Start()
        refpositions()
        syncSizeArghIHateTimers()
    End Sub

    Private Sub resizePanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles resizePanel.MouseUp
        resizer.Stop()
        refpositions()
        syncSizeArghIHateTimers()
    End Sub
End Class