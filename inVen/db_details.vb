Public Class db_details
    Private Sub stammContext_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles stammContext.Opening
        If ListView1.SelectedIndices.Count = 0 Then
            Me.MarkierteDatenLöschenToolStripMenuItem.Enabled = False
            Me.DatenAnsehenToolStripMenuItem.Enabled = False
            Me.MarkiertenDatensatzBearbeitenToolStripMenuItem.Enabled = False
        Else
            Me.MarkierteDatenLöschenToolStripMenuItem.Enabled = True
            Me.DatenAnsehenToolStripMenuItem.Enabled = True
            Me.MarkiertenDatensatzBearbeitenToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub DatenAnsehenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatenAnsehenToolStripMenuItem.Click
        Dim nData As New dbdatensatz
        nData.cModus = dbdatensatz.modus_.mShow
        nData.selID = Me.ListView1.SelectedItems(0).Text
        nData.ShowDialog()
    End Sub

    Private Sub NeueDatenAnlegenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeueDatenAnlegenToolStripMenuItem.Click
        Dim nData As New dbdatensatz
        nData.cModus = dbdatensatz.modus_.mNew

        If nData.ShowDialog = DialogResult.OK Then
            ReloadDataView()
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles lblAuthor.Click

    End Sub
    Public Sub ReloadDataView()
        Me.ListView1.Items.Clear()
        If Not cInventory.Stammdaten.Count = 0 Then

            For Each T As astamm In cInventory.Stammdaten
                ListView1.Items.Add(New ListViewItem({T.ID_Nummer, T.aBeschreibung, T.aFarbe, T.preis.ToString, T.StammID}))
            Next
        End If
    End Sub
    Private Sub db_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Eigenschaften von " & CurrentUser & "..."
        lblName.Text = "Name : " & CurrentUser
        lblDatabaseVer.Text = "Datenbank Version : " & DB_LOADED_VER
        lblKey.Text = currentSaltKeyFile & " -> " & getSaltKey()
        author_textbox.Text = cInventory.db_author
        desc_textbox.Text = cInventory.db_desc
        ReloadDataView()
    End Sub

    Private Sub author_textbox_TextChanged(sender As Object, e As EventArgs) Handles author_textbox.TextChanged

    End Sub

    Private Sub author_textbox_KeyUp(sender As Object, e As KeyEventArgs) Handles author_textbox.KeyUp
        If e.KeyCode = Keys.Enter Then
            cInventory.db_author = author_textbox.Text
            showMessageEx("Eingabe wurde gespeichert.", "Author geändert", S_STYLES.SINFO)
        End If
    End Sub

    Private Sub MarkiertenDatensatzBearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkiertenDatensatzBearbeitenToolStripMenuItem.Click
        Dim nData As New dbdatensatz
        nData.cModus = dbdatensatz.modus_.mEdit
        nData.selID = Me.ListView1.SelectedItems(0).Text
        If nData.ShowDialog = DialogResult.OK Then
            ReloadDataView()
        End If
    End Sub

    Private Sub desc_textbox_TextChanged(sender As Object, e As EventArgs) Handles desc_textbox.TextChanged

    End Sub

    Private Sub desc_textbox_KeyUp(sender As Object, e As KeyEventArgs) Handles desc_textbox.KeyUp
        If e.KeyCode = Keys.Enter Then
            cInventory.db_desc = desc_textbox.Text
            showMessageEx("Eingabe wurde gespeichert.", "Beschreibung geändert", S_STYLES.SINFO)
        End If
    End Sub
End Class