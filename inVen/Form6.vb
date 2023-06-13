Public Class newPos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If tArticle.Text.Trim = "" Then
            showMessageEx("Bitte gebe eine Artikelnummer ein, das Feld darf nicht leer sein!", "Achtung...", S_STYLES.SWARNING)
            Exit Sub
        End If

        Dim UID As String = getUnID()
        If UID = "FALSE" Then
            showMessageEx("Fehler beim einspeichern des Artikels, siehe Details.", "Fehler...", S_STYLES.SERROR, True, "UID konnte nicht generiert werden. Interner Fehler, bitte kontaktiere einen Entwickler.")
            Exit Sub
        End If

        cInventory.uniqueIDS.Add(UID)

        For Each P As cinventar In cInventory.InventarListe

            If P.invenName = currentInvSelected Then

                Dim ART As New artikel
                ART.artikelnummer = tArticle.Text
                ART.Lagerplatz = tDesc.Text

                ART.Bestand = CInt(tCount.Value)
                ART.UniqueID = UID
                P.ArtikelEintrag.Add(ART)
                showMessageEx("Artikel wurde erfolgreich eingespeichert.", "Info", S_STYLES.SINFO)
                ConsoleText.AppendLine("[" & DateTime.Now.ToString("dd/MM/yyyy") & "] Der Artikel '" & tArticle.Text.Trim & "' wurde hinzugefügt zum Inventar '" & currentInvSelected & "'. ( Benutzer : " & CurrentUser & " )")
                Exit For

            End If

        Next
        Me.Close()

    End Sub

    Private Sub newPos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If mainwnd.ListBox1.SelectedIndex = -1 Then Me.Close()
        If IsNothing(cInventory) Then Me.Close()


    End Sub

    Private Sub newPos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        mainwnd.ReloadListView()
    End Sub

    Private Sub tArticle_TextChanged(sender As Object, e As EventArgs) Handles tArticle.TextChanged

    End Sub

    Private Sub newPos_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.F9 Then
            Button1.PerformClick()
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub tArticle_LocationChanged(sender As Object, e As EventArgs) Handles tArticle.LocationChanged

    End Sub

    Private Sub tArticle_KeyUp(sender As Object, e As KeyEventArgs) Handles tArticle.KeyUp
        If e.KeyValue = Keys.Enter Then tDesc.Focus()
        newPos_KeyUp(sender, e)
    End Sub

    Private Sub tDesc_TextChanged(sender As Object, e As EventArgs) Handles tDesc.TextChanged

    End Sub

    Private Sub tDesc_KeyUp(sender As Object, e As KeyEventArgs) Handles tDesc.KeyUp
        If e.KeyValue = Keys.Enter Then tCount.Focus()
        newPos_KeyUp(sender, e)
    End Sub

    Private Sub tCount_ValueChanged(sender As Object, e As EventArgs) Handles tCount.ValueChanged

    End Sub

    Private Sub tCount_KeyUp(sender As Object, e As KeyEventArgs) Handles tCount.KeyUp
        If e.KeyValue = Keys.Enter Then Button1.PerformClick()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class