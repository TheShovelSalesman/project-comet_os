
Public Class start
    Dim start As Boolean
    Private Sub start_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            If TextBox1.Text = "" <> TextBox2.Text = "" Then
                errorMessage.Show()
                errorMessage.message.Text = "Username and/or password cannot be blank."
                errorMessage.title.Text = "Setup"
            Else
                My.Settings.Username = TextBox1.Text
                My.Settings.Password = TextBox2.Text
            End If

            If start = True Then
                Dim FileToMove As String
                Dim WhereToMove As String

                FileToMove = Application.StartupPath & "Comet OS.exe"
                WhereToMove = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup"
                If System.IO.File.Exists(FileToMove) = True Then

                    System.IO.File.Move(FileToMove, WhereToMove)
                    errorMessage.Show()
                    errorMessage.message.Text = "Comet OS will now boot at windows startup."
                    errorMessage.title.Text = "Setup"

                End If
            Else

            End If
            LoginForm.Visible = True
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        start = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        start = False
    End Sub
End Class