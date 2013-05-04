
Public Class Space_Invaders
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer

    Private Sub Space_Invaders_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub
    Private Sub Space_Invaders_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AxShockwaveFlash1.Movie = Application.StartupPath & "\space.swf"
        AxShockwaveFlash1.Play()
        Settings.CachedApps.Items.Add("Process::SpaceInvaders")
    End Sub

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click
        Me.Close()
    End Sub

    Private Sub Space_Invaders_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
        Me.Opacity = 0.9
    End Sub

    Private Sub Space_Invaders_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub Space_Invaders_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Label7_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Space_Invaders_Deactivate(sender As System.Object, e As System.EventArgs) Handles MyBase.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If AxShockwaveFlash1.Dock = DockStyle.Fill And Me.WindowState = FormWindowState.Maximized Then
            AxShockwaveFlash1.Dock = DockStyle.None
            Me.WindowState = FormWindowState.Normal
        ElseIf AxShockwaveFlash1.Dock = DockStyle.None And Me.WindowState = FormWindowState.Normal Then
            AxShockwaveFlash1.Dock = DockStyle.Fill
            Me.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Private Sub Space_Invaders_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process::SpaceInvaders")
        Console.CommandLog.Items.Add("ProcessTerminated(SpaceInvaders)")
    End Sub
End Class