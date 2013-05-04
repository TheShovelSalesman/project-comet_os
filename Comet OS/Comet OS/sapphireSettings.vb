Public Class sapphireSettings
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub sapphireSettings_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub sapphireSettings_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub sapphireSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        homepage.Text = My.Settings.Homepage
        If My.Settings.Extensions = False Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub homepage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles homepage.TextChanged
        title.Text = "Sapphire Settings -- Saving..."
        My.Settings.Homepage = homepage.Text
        My.Settings.Save()
        title.Text = "Sapphire Settings"
    End Sub

    Private Sub sapphireSettings_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub sapphireSettings_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub sapphireSettings_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 1.0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        title.Text = "Sapphire Settings -- Saving..."
        If ComboBox1.Text = "Google" Then
            My.Settings.searchEngine = "https://www.google.com/#hl=en&safe=off&output=search&sclient=psy-ab&q="
            title.Text = "Sapphire Settings"
        ElseIf ComboBox1.Text = "Bing" Then
            My.Settings.searchEngine = "http://www.bing.com/search?q="
            title.Text = "Sapphire Settings"
        ElseIf ComboBox1.Text = "Yahoo" Then
            My.Settings.searchEngine = "http://search.yahoo.com/search;_ylt=AlyHCrd8jdVTyq9fIo6YbcabvZx4?p="
            title.Text = "Sapphire Settings"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            My.Settings.Extensions = True
        Else
            My.Settings.Extensions = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        bookmarkManager.Show()
    End Sub
End Class