Public Class Commands
    Sub CommandNotFound()
        Console.CommandLog.Items.Add("Command not found.")
    End Sub
    Sub showCursorPos()


        Desktop.cursorSync.Start()
        Desktop.Panel2.Visible = True
    End Sub
    Sub RunSapphire()
        Sapphire.Show()
    End Sub
    Sub RunClef()
        Clef.Show()
    End Sub
    Sub RunEpicText()
        EpicText.Show()
    End Sub
    Sub RunAbout()
        About.Show()
    End Sub
    Sub RunGame()
        Space_Invaders.Show()
    End Sub
    Sub RunCalc()
        Calculator.Show()
    End Sub
    Sub RunSettings()
        Settings.Show()
    End Sub
    Sub Shutdown()
        End
    End Sub
    Sub Logout()
        LoginForm.Show()
    End Sub
    Sub InvokeError()
        errorMessage.Show()
        errorMessage.message.Text = "Error::GenericError"
        errorMessage.title.Text = "Console"
    End Sub
    Sub InvokeLoginError()
        errorMessage.Show()
        errorMessage.message.Text = "Failed to login."
        errorMessage.title.Text = "Console"
    End Sub
    Sub InvokeAppCacheError()
        errorMessage.Show()
        errorMessage.message.Text = "Application cache has stopped working, stopping all programs."
        errorMessage.title.Text = "Console"
        Sapphire.Close()
        Clef.Close()
        EpicText.Close()
        Space_Invaders.Close()
        RlsNotes.Close()
        Calculator.Close()
        FlashViewer.Close()
        Settings.Close()
    End Sub
    Sub InvokeUserSettingsError()
        errorMessage.Show()
        errorMessage.message.Text = "User settings have either failed to load or save."
        errorMessage.title.Text = "Console"
    End Sub
    Sub InvokeNetworkError()
        errorMessage.Show()
        errorMessage.message.Text = "Network unavailable"
        errorMessage.title.Text = "Console"
    End Sub
    Sub InvokeSystemFailure()
        errorMessage.Show()
        errorMessage.message.Text = "System failure, shutting down Comet OS."
        errorMessage.title.Text = "Console"
        CBOD.Show()
        InvokeAppCacheError()
    End Sub
    Sub InvokeFailedToLoadApp()
        errorMessage.Show()
        errorMessage.message.Text = "Application failed to load."
        errorMessage.title.Text = "Console"
    End Sub
    Sub bread()
        Dim speech
        speech = CreateObject("SAPI.spvoice")
        speech.Speak("Bread.")
    End Sub
    Sub help()
        For Each le As String In My.Settings.Commandlist
            Console.CommandLog.Items.Add(le)
        Next
    End Sub
    Sub cls()
        Console.CommandLog.Items.Clear()
    End Sub
    Sub listCache()
        For Each lele As String In Settings.CachedApps.Items
            Console.CommandLog.Items.Add(lele)
        Next
    End Sub
    Sub runIntegrityCheck()
        If GS.Label1.Visible = True Then
            Console.CommandLog.Items.Add("This version of Comet OS was made by Galaxy Software.")
        Else
            Console.CommandLog.Items.Add("This version of Comet OS is either a re-distribution or a carbon copy.")
        End If
    End Sub
End Class



