Public Class template

    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer

    Private Sub template_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub template_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub template_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Console.CommandLog.Items.Add("Your App Name")
        'Settings.CachedApps.Items.Add("Process::Your App Name")
        
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Visible = False
        'Or Me.Close(), if you aren't going with app caching
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
End Class