Imports System.Net.Mail
Public Class Feedback
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        Try
            Label14.Text = "Sending..."
            Dim msg As New System.Net.Mail.MailMessage()
            msg.[To].Add("codyzusman@gmail.com")
            msg.Subject = "Comet OS feedback report"
            msg.Body = TextBox6.Text & Environment.NewLine & My.Settings.Version
            msg.IsBodyHtml = False
            Dim SMPclint As New SmtpClient()
            SMPclint.Host = "smtp.gmail.com"
            SMPclint.EnableSsl = True
            Dim NetCry As New Net.NetworkCredential()
            NetCry.UserName = TextBox2.Text
            NetCry.Password = TextBox3.Text
            SMPclint.UseDefaultCredentials = True
            SMPclint.Credentials = NetCry
            Dim fromMailAddr As New MailAddress(TextBox2.Text)
            msg.From = fromMailAddr
            SMPclint.Port = 587
            SMPclint.Send(msg)
            Label14.Text = "Sent!"
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.message.Text = "Unable to send."
            errorMessage.title.Text = "Feedback"
        End Try
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Feedback_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub Feedback_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Feedback_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub Feedback_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Feedback_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Close()
    End Sub
End Class