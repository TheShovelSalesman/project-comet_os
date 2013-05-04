Imports Comet_OS.Commands
Public Class Console
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim commands As New Commands

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Visible = False
    End Sub

    Private Sub Console_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub Console_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub

    Private Sub Console_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CommandLog.Items.Add("Comet OS version 4.0.0  " & Environment.NewLine & "CometScript version 3." & Environment.NewLine)
        Settings.CachedApps.Items.Add("Process::Console")
        Me.CommandLog.Items.Add("Initialized CometScript at " & TimeOfDay)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Command.Text = "showCursorPosition" Then
            commands.showCursorPos()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Template" Then
            template.Show()
        End If

        If Command.Text = "Run Sapphire" Then
            commands.RunSapphire()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Run EpicText" Then
            commands.RunEpicText()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Run Clef" Then
            commands.RunClef()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "About Comet OS" Then
            commands.RunAbout()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Run Calculator" Then
            commands.RunCalc()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "PlayGame" Then
            commands.RunGame()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Run Settings" Then
            commands.RunSettings()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Invoke::genericError" Then
            commands.InvokeError()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Invoke::appCacheError" Then
            commands.InvokeAppCacheError()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Invoke::loginError" Then
            commands.InvokeLoginError()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Invoke::systemFailure" Then
            commands.InvokeSystemFailure()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Invoke::userSettingsFailure" Then
            commands.InvokeUserSettingsError()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "Invoke::appLoadingError" Then
            commands.InvokeFailedToLoadApp()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "bread" Then
            commands.bread()
            CommandLog.Items.Add("You found an easter egg.  BREAD!")
        End If
        If Command.Text = "help" Then
            commands.help()
            CommandLog.Items.Add(Command.Text)
        End If
        If Command.Text = "cls" Then
            commands.cls()
        End If
        If Command.Text = "listCache" Then
            commands.listCache()
        End If
        If Command.Text = "runIntegrityCheck" Then
            commands.runIntegrityCheck()
        End If
        Command.Text = ""
    End Sub

    Private Sub Console_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Console_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub Console_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Console_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process::Console")
        Me.CommandLog.Items.Add("ProcessTerminated(CometScriptConsole)")
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newWindow As New Console
        newWindow.Show()
    End Sub

    Private Sub CloseSessionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
End Class

