Imports System.Math
Public Class Calculator

    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Visible = False
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Label11_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Label11.ForeColor = Color.DimGray
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        Label2.ForeColor = Color.DimGray
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.White
    End Sub

    Private Sub Label3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.MouseEnter
        Label3.ForeColor = Color.DimGray
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.White
    End Sub

    Private Sub Label4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.MouseEnter
        Label4.ForeColor = Color.DimGray
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.White
    End Sub

    Private Sub Label5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.MouseEnter
        Label5.ForeColor = Color.DimGray
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.White
    End Sub

    Private Sub Label8_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.MouseEnter
        Label8.ForeColor = Color.DimGray
    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        Label8.ForeColor = Color.White
    End Sub

    Private Sub Label9_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.MouseEnter
        Label9.ForeColor = Color.DimGray
    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave
        Label9.ForeColor = Color.White
    End Sub

    Private Sub Label12_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.MouseEnter
        Label12.ForeColor = Color.DimGray
    End Sub

    Private Sub Label12_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.MouseLeave
        Label12.ForeColor = Color.White
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Label11.Text = Val(TextBox1.Text) + Val(TextBox2.Text)
        Label10.Text = "+"
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Label11.Text = Val(TextBox1.Text) - Val(TextBox2.Text)
        Label10.Text = "-"
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Try
            Label11.Text = Val(TextBox1.Text) * Val(TextBox2.Text)
            Label10.Text = "*"
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.message.Text = "Error; number may be too large, or system files may be corrupt."
            errorMessage.title.Text = "Multiplication error"
        End Try

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Label11.Text = Val(TextBox1.Text) / Val(TextBox2.Text)
        Label10.Text = "/"
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        TextBox1.Text = "3.1415926535897932384626433832795"
        Label10.Text = ""
        Label11.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        TextBox1.Text = Label11.Text
        Label10.Text = ""
        TextBox2.Text = ""
        Label11.Text = ""
    End Sub

    Private Sub Calculator_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub Calculator_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Calculator_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub Calculator_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        Label11.Text = ""
        Label10.Text = ""

    End Sub

    Private Sub Calculator_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.Opacity = 1
    End Sub

    Private Sub Calculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Settings.CachedApps.Items.Add("Process:Calculator")
        Console.CommandLog.Items.Add("Opened Calculator at " & TimeOfDay)
    End Sub

    Private Sub Label13_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.MouseEnter
        Label13.ForeColor = Color.DimGray
    End Sub

    Private Sub Label13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseLeave
        Label13.ForeColor = Color.White
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Try
            Dim squared As Double = Val(TextBox1.Text)
            Label11.Text = Math.Sqrt(squared)
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.message.Text = "Conversion Error."
            errorMessage.title.Text = "Calculator"
        End Try
    End Sub

    Private Sub Calculator_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process:Calculator")
        Console.CommandLog.Items.Add("ProcessTerminated(Calculator)")
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class