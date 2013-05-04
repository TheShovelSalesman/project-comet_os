Imports Gecko
Imports System.Windows
Public Class Sapphire
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim url As String
    Dim i As Integer = 1
    Dim CurPos, AppSize As New Point(0, 0)
    Dim oloc As New Point(0, 0)
    Dim ocur As New Point(System.Windows.Forms.Cursor.Position)
    Sub addTabPage()
        Try
            Gecko.Xpcom.Initialize(Application.StartupPath + "\xulrunner")
            Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = False
            Dim Browser As New GeckoWebBrowser
            Dim TabPage As New TabPage
            AddHandler Browser.Navigated, AddressOf navigating
            TabControl1.TabPages.Add(TabPage)
            TabControl1.SelectTab(TabPage)
            Browser.Name = "gecko_browser"
            Browser.Dock = DockStyle.Fill
            TabControl1.SelectedTab.Controls.Add(Browser)
            Browser.Navigate(My.Settings.Homepage)
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.message.Text = "Failed to initialize geckofx."
            errorMessage.title.Text = "Sapphire"
        End Try
    End Sub
    Sub deleteTab()
        If TabControl1.TabCount <> 1 Then
            TabControl1.TabPages.RemoveAt(TabControl1.SelectedIndex)

            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub
    Sub goHome()
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(My.Settings.Homepage)
    End Sub
    Sub refreshPage()
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Reload()
    End Sub
    Sub stopPage()
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Stop()
    End Sub
    Sub forward()
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).GoForward()
    End Sub
    Sub back()
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).GoBack()
    End Sub
    Sub navToPage()
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(urlBar.Text)
    End Sub
    Sub syncSizeArghIHateTimers()
        CurPos = Cursor.Position
        AppSize = Me.Size
    End Sub
    Private Sub refpositions()
        oloc = Me.Location
        ocur = System.Windows.Forms.Cursor.Position
    End Sub
    Sub navigating()
        Try
            TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
            urlBar.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url.ToString
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.title.Text = "Sapphire"
            errorMessage.message.Text = "An error ocurred."
        End Try
    End Sub

    Private Sub CelloNet_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub CelloNet_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub CelloNet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Gecko.Xpcom.Initialize(Application.StartupPath + "\xulrunner")
            If My.Settings.Extensions = True Then
                Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = False
            Else
                Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = True
            End If
            Dim Browser As New GeckoWebBrowser
            Dim TabPage As New TabPage
            AddHandler Browser.Navigated, AddressOf navigating
            TabControl1.TabPages.Add(TabPage)
            TabControl1.SelectTab(TabPage)
            Browser.Name = "gecko_browser"
            Browser.Dock = DockStyle.Fill
            TabControl1.SelectedTab.Controls.Add(Browser)
            Browser.Navigate(My.Settings.Homepage)
            Settings.CachedApps.Items.Add("Process::Sapphire")
            Console.CommandLog.Items.Add("Opened Sapphire at " & TimeOfDay)

        Catch ex As Exception
            errorMessage.Show()
            errorMessage.message.Text = "Failed to initialize geckofx."
            errorMessage.title.Text = "Sapphire"
        End Try
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

    Private Sub resizer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resizer.Tick
        Me.Size = AppSize - CurPos + Cursor.Position
        refpositions()
    End Sub

    Private Sub CelloNet_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        MouseX = Forms.Cursor.Position.X - Me.Left
        MouseY = Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub CelloNet_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Forms.Cursor.Position.Y - MouseY
            Me.Left = Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub CelloNet_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Visible = False
    End Sub

    Private Sub closeButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.MouseEnter
        closeButton.ForeColor = Color.DimGray
    End Sub

    Private Sub closeButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.MouseLeave
        closeButton.ForeColor = Color.Black
    End Sub

    Private Sub minimize_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        minimize.ForeColor = Color.DimGray
    End Sub

    Private Sub minimize_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        minimize.ForeColor = Color.Black
    End Sub

    Private Sub minimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New minimize
        m.Show()
    End Sub

    Private Sub home_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles home.Click
        goHome()
    End Sub

    Private Sub reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reload.Click
        refreshPage()
    End Sub

    Private Sub stopLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stopLoad.Click
        stopPage()
    End Sub

    Private Sub goForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles goForward.Click
        forward()
    End Sub

    Private Sub goBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles goBack.Click
        back()
    End Sub

    Private Sub delTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delTab.Click
        deleteTab()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles goButton.Click
        If urlBar.Text.Contains(".") Then
            navToPage()
        Else
            CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(My.Settings.searchEngine + urlBar.Text)
        End If
    End Sub

    Private Sub urlBar_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles urlBar.Enter
        Me.AcceptButton = goButton
    End Sub

    Private Sub urlBar_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles urlBar.Leave
        Me.AcceptButton = Nothing
    End Sub

    Private Sub Sapphire_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process::Sapphire")
        Console.CommandLog.Items.Add("ProcessTerminated(Sapphire)")
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles search.Click
        sapphireSettings.Show()
    End Sub

    Private Sub addTab_Click(sender As System.Object, e As System.EventArgs) Handles addTab.Click
        addTabPage()
    End Sub
End Class
