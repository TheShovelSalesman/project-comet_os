Public Class About
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeWindow.Click, closeWindow.Click
        Me.Visible = False
    End Sub

    Private Sub About_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub About_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
        Me.BackgroundImage = My.Resources.gradientclick
    End Sub

    Private Sub About_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub About_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        drag = False
        Me.Opacity = 1
        Me.BackgroundImage = My.Resources.gradient4
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeWindow.MouseEnter, closeWindow.MouseEnter
        closeWindow.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeWindow.MouseLeave, closeWindow.MouseLeave
        closeWindow.ForeColor = Color.Black
    End Sub

    Private Sub About_Deactivate(sender As System.Object, e As System.EventArgs) Handles MyBase.Deactivate
        Me.Opacity = 0.5
    End Sub
    Private Sub Label3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.MouseEnter
        Label3.ForeColor = Color.DimGray
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.Black
    End Sub

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Settings.CachedApps.Items.Add("Process::About")
        
    End Sub

    Private Sub About_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process::About")
    End Sub

    Private Sub Label9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.Click
        Feedback.Show()
    End Sub

    Private Sub Label9_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.MouseEnter
        Label9.ForeColor = Color.DimGray
    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave
        Label9.ForeColor = Color.Black
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Sapphire.Show()
        Dim Browser As New Gecko.GeckoWebBrowser
        Dim TabPage As New TabPage
        Sapphire.TabControl1.TabPages.Add(TabPage)
        Sapphire.TabControl1.SelectTab(TabPage)
        Browser.Name = "gecko_browser"
        Browser.Dock = DockStyle.Fill
        Sapphire.TabControl1.SelectedTab.Controls.Add(Browser)
        Browser.Navigate("http://www.galaxy-software.webs.com")
    End Sub
End Class