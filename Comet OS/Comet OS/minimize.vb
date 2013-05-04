Public Class minimize
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Private Sub minimize_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub minimize_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
        End If
    End Sub

    Private Sub minimize_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Private Sub minimize_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDoubleClick
        If Label1.Text = "Calculator" Then
            Calculator.Visible = True
            Me.Visible = False
        End If
    End Sub

    Private Sub minimize_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Opacity = "0.5"
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If Label1.Text = "Calculator" Then
            Calculator.Visible = True
            Me.Visible = False
        End If
    End Sub
End Class