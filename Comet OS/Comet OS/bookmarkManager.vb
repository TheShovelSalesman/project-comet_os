Imports Gecko
Public Class bookmarkManager
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Add(Sapphire.urlBar.Text)
        For Each bookmark As String In ListBox1.Items

        Next
        My.Settings.Save()
    End Sub

    Private Sub historyManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each pileOfShit As String In My.Settings.bookmarks
            ListBox1.Items.Add(pileOfShit)
            My.Settings.Save()
        Next
    End Sub
End Class