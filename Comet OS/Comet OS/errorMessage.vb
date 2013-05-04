Public Class errorMessage
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer

    Private Sub errorMessage_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub
    Private Sub errorMessage_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub errorMessage_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub errorMessage_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub errorMessage_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Me.Opacity = 1
    End Sub

    Private Sub errorMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Settings.CachedApps.Items.Add("SystemProcess::MessageSystem")
        Console.CommandLog.Items.Add("System message shown at " & TimeOfDay)
    End Sub

    Private Sub errorMessage_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("SystemProcess::MessageSystem")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class