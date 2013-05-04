Public Class FlashViewer
    Dim drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer

    Private Sub FlashViewer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub FlashViewer_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.5
    End Sub
    Private Sub FlashViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each fileName As String In My.Settings.swfFiles
            Files.Items.Add(fileName)
        Next
        Settings.CachedApps.Items.Add("Process::FlashViewer")
        Console.CommandLog.Items.Add("Opened FlashViewer at " & TimeOfDay)
    End Sub

    Private Sub sfwImporter_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles swfImporter.FileOk
        Try
            For Each file As String In swfImporter.FileNames
                Files.Items.Add(file)
                My.Settings.swfFiles.Add(file)
                My.Settings.Save()

            Next
        Catch ex As Exception
            
        End Try
    End Sub

    Private Sub FlashViewer_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        MouseX = Windows.Forms.Cursor.Position.X - Me.Left
        MouseY = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub FlashViewer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Opacity = 0.9
            Me.Top = Windows.Forms.Cursor.Position.Y - MouseY
            Me.Left = Windows.Forms.Cursor.Position.X - MouseX
            If Me.Top <= Desktop.Panel1.Bottom Then
                MouseY = MouseY - 1
            End If
        End If
    End Sub

    Private Sub FlashViewer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        swfImporter.ShowDialog()
    End Sub

    Private Sub Files_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Files.DoubleClick
        AxShockwaveFlash1.Movie = Files.SelectedItem
        AxShockwaveFlash1.Play()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Close()
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.DimGray
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub FlashViewer_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Settings.CachedApps.Items.Remove("Process::FlashViewer")
    End Sub
End Class