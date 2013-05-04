Public Class accountCreate

    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text <> TextBox3.Text Then
            errorMessage.Show()
            errorMessage.title.Text = "Error"
            errorMessage.message.Text = "Passwords do not match"

        Else
            My.Settings.Username = TextBox1.Text
            My.Settings.Password = TextBox3.Text
            Console.CommandLog.Items.Add("Created account at " & TimeOfDay & " with " & My.Settings.Username & " as username and " & My.Settings.Password & " as password.")
            My.Settings.Save()
            Me.Close()
            errorMessage.Show()
            errorMessage.title.Text = "Account Created"
            errorMessage.message.Text = "Account successfully created!"
        End If
    End Sub

    Private Sub accountCreate_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub accountCreate_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub accountCreate_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
        End If
    End Sub

    Private Sub accountCreate_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub accountCreate_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Me.Opacity = 1
    End Sub
End Class