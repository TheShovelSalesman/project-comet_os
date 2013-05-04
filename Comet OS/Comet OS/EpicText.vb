Imports System.IO
Public Class EpicText
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim moving As Boolean = False

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        
        Me.Visible = False
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim ColorDiag As New ColorDialog
        ColorDiag.ShowDialog()
        RichTextBox1.SelectionColor = ColorDiag.Color
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim FontDiag As New FontDialog
        FontDiag.ShowDialog()
        RichTextBox1.SelectionFont = FontDiag.Font
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub EpicText_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub EpicText_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub EpicText_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub EpicText_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Maximized
        RichTextBox1.Dock = DockStyle.Fill
    End Sub

    Private Sub EpicText_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Settings.CachedApps.Items.Add("Process::EpicText")
        Console.CommandLog.Items.Add("Opened EpicText at " & TimeOfDay)
    End Sub

    Private Sub EpicText_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        RichTextBox1.SaveFile(SaveFileDialog1.FileName)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            RichTextBox1.LoadFile(OpenFileDialog1.FileName)
        Catch ex As Exception
            errorMessage.Show()
            errorMessage.message.Text = "Error, EpicText can only open .rtf files."
            errorMessage.title.Text = "EpicText"
        End Try

    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.DimGray
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
    End Sub

    Private Sub RichTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
        If (e.Control And Keys.J) Then
            Try
                Dim speech
                speech = CreateObject("SAPI.spvoice")
                speech.Speak(RichTextBox1.Text)
            Catch ex As Exception
                errorMessage.Show()
                errorMessage.message.Text = "Failed to initialize speech driver.  Restart Comet OS and try again"
                errorMessage.title.Text = "EpicText"
            End Try
        End If
    End Sub

    Private Sub EpicText_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process::EpicText")
        Console.CommandLog.Items.Add("ProcessTerminated(EpicText)")
    End Sub

    Private Sub Label1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized

        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
End Class