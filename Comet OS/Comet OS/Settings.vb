Public Class Settings
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Sub saveImage()
        Label1.Visible = True
        If ListBox1.SelectedItem = "Default" Then
            PictureBox1.BackgroundImage = My.Resources.gradient_wallpaper_31
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to default.")
        ElseIf ListBox1.SelectedItem = "Pattern" Then
            PictureBox1.BackgroundImage = My.Resources.black_textures_hd_background_squares_210945
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Pattern.")
        ElseIf ListBox1.SelectedItem = "Leaves" Then
            PictureBox1.BackgroundImage = My.Resources.DSC06239
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Leaves.")
        ElseIf ListBox1.SelectedItem = "Stars" Then
            PictureBox1.BackgroundImage = My.Resources.stars
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Stars.")
        ElseIf ListBox1.SelectedItem = "Glow" Then
            PictureBox1.BackgroundImage = My.Resources.CometOSDesktop1
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Glow.")
        ElseIf ListBox1.SelectedItem = "Moon" Then
            PictureBox1.BackgroundImage = My.Resources.darkWindowdesktop
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Moon.")
        ElseIf ListBox1.SelectedItem = "Mountains" Then
            PictureBox1.BackgroundImage = My.Resources.CometOSmnts
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Mountains.")
        ElseIf ListBox1.SelectedItem = "Comet OS beta 3 Logo" Then
            PictureBox1.BackgroundImage = My.Resources.CometOSLogo1
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Comet OS beta 3 Logo.")
        ElseIf ListBox1.SelectedItem = "Comet OS 2.6 Logo" Then
            PictureBox1.BackgroundImage = My.Resources.Comet_OS
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Comet OS 2.6 Logo.")
        ElseIf ListBox1.SelectedItem = "Gradient" Then
            PictureBox1.BackgroundImage = My.Resources.gradient_wallpaper_3
            Desktop.BackgroundImage = PictureBox1.BackgroundImage
            My.Settings.background = ListBox1.SelectedItem.ToString
            My.Settings.Save()
            Console.CommandLog.Items.Add("Desktop changed to Gradient")
        End If

        Label1.Visible = False
    End Sub

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click
        Me.Visible = False
    End Sub

    Private Sub Label7_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Settings_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Me.Opacity = 1
    End Sub

    Private Sub Settings_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub Settings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PictureBox1.BackgroundImage = Desktop.BackgroundImage
    End Sub

   
    
    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Label1.Visible = True
        saveImage()
        Label1.Visible = False
    End Sub

    Private Sub Settings_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
        Me.Opacity = 0.9
    End Sub

    Private Sub Settings_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub Settings_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Desktop.BackgroundImageLayout = ImageLayout.Zoom
        My.Settings.DesktopImageLayout = "Zoom"
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Desktop.BackgroundImageLayout = ImageLayout.Center
        My.Settings.DesktopImageLayout = "Center"
        My.Settings.Save()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Desktop.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.DesktopImageLayout = "Tile"
        My.Settings.Save()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Desktop.BackgroundImageLayout = ImageLayout.Stretch
        My.Settings.DesktopImageLayout = "Stretch"
        My.Settings.Save()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Sapphire.Close()
        Clef.Close()
        EpicText.Close()
        Space_Invaders.Close()
        Desktop.PictureBox2.Visible = False
        Desktop.PictureBox3.Visible = False
        Desktop.PictureBox4.Visible = False
        Desktop.Label5.Visible = False
        Desktop.Label7.Visible = False
        Calculator.Close()
        About.Close()
        RlsNotes.Close()
        qwop.Close()
        screenCapture.Close()
        download.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If CachedApps.SelectedItem = "Process::About" Then
            About.Close()
        ElseIf CachedApps.SelectedItem = "Process::Calculator" Then
            Calculator.Close()
        ElseIf CachedApps.SelectedItem = "Process::Sapphire" Then
            Sapphire.Close()
        ElseIf CachedApps.SelectedItem = "Process::Clef" Then
            Clef.Close()
        ElseIf CachedApps.SelectedItem = "Process::Console" Then
            errorMessage.Show()
            errorMessage.message.Text = "Cannot terminate critical processes."
            errorMessage.title.Text = "Comet OS"
        ElseIf CachedApps.SelectedItem = "SystemProcess::Desktop" Then
            Desktop.Close()
            LoginForm.Close()
            CBOD.Show()
        ElseIf CachedApps.SelectedItem = "Process::EpicText" Then
            EpicText.Close()
        ElseIf CachedApps.SelectedItem = "Process::SpaceInvaders" Then
            Space_Invaders.Close()
        ElseIf CachedApps.SelectedItem = "Process::FlashViewer" Then
            FlashViewer.Close()
        ElseIf CachedApps.SelectedItem = "Process::QWOP" Then
            qwop.Close()
        ElseIf CachedApps.SelectedItem = "Process::ScreenCapture" Then
            screenCapture.Close()
        ElseIf CachedApps.SelectedItem = "Process::DownloadManager" Then
            download.Close()
        End If
    End Sub
End Class