Public Class locked
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Button1.ImageIndex = 1 Then Me.Button1.ImageIndex = 0 Else Me.Button1.ImageIndex = 1
    End Sub

    Private Sub locked_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyValue = Keys.Enter Then
            If Me.Button1.ImageIndex = 1 Then
                showMessageEx("Zuerst muss der Vorgang bestätigt werden, siehe Beschreibung im Dialog.", "Achtung...", S_STYLES.SWARNING)
            Else
                cInventory.InventarListe(mainwnd.ListBox1.SelectedIndex).Key = MD5StringHash(Me.TextBox1.Text)
                showMessageEx("Das Inventar '" & cInventory.InventarListe(mainwnd.ListBox1.SelectedIndex).invenName & "' wurde gesperrt.", "Vorgang erfolgreich", S_STYLES.SINFO)
                Me.Close()
            End If
        End If
    End Sub
End Class