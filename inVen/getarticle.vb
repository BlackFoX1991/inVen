Public Class getarticle
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyValue = Keys.Enter Then
            ReloadList()
            Me.ListView1.Focus()
        End If
    End Sub

    Public Sub ReloadList()
        ListView1.Items.Clear()

        For Each T As cinventar In cInventory.InventarListe

            If T.invenName = currentInvSelected Then


                For Each P As artikel In T.ArtikelEintrag

                    If P.artikelnummer = TextBox1.Text.Trim Then

                        Me.ListView1.Items.Add(New ListViewItem({P.artikelnummer,
                                                            getProductDesc(P.artikelnummer),
                                                            P.Bestand, lookforinventory(P.artikelnummer), P.Lagerplatz,
                                                            P.UniqueID}))
                    End If
                Next


                Exit For
            End If

        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(cInventory) Then Exit Sub
        If currentInvSelected = "" Then Exit Sub
        If ListView1.Items.Count = 0 Then Exit Sub
        If ListView1.SelectedIndices.Count = 0 Then Exit Sub


        Dim CHN As New List(Of artikel)
        For Each b As cinventar In cInventory.InventarListe
            If b.invenName = currentInvSelected Then
                For Each Z As ListViewItem In ListView1.SelectedItems
                    For Each U As artikel In b.ArtikelEintrag
                        If Z.SubItems(5).Text = U.UniqueID Then CHN.Add(U)

                    Next
                Next
                For Each Z As artikel In CHN
                    Z.Bestand -= 1
                    If Z.Bestand <= 0 Then
                        Dim RMVS As New List(Of artikel)
                        For Each j As cinventar In cInventory.InventarListe
                            If b.invenName = currentInvSelected Then
                                For Each ZX As ListViewItem In ListView1.SelectedItems
                                    For Each U As artikel In j.ArtikelEintrag
                                        If ZX.SubItems(5).Text = U.UniqueID Then
                                            RMVS.Add(U)
                                        End If
                                    Next
                                Next
                                For Each DEL As artikel In RMVS
                                    j.ArtikelEintrag.Remove(DEL)
                                Next
                                Exit For
                            End If
                        Next

                    End If
                Next
                Exit For
            End If
        Next

        If showMessageEx("Position mit der Artikelnummer " & TextBox1.Text & " wurde entnommen. Wollen Sie weitere Positionen mit dieser Artikelnummer entnehmen ?", "Vorgang beendet.", S_STYLES.SQUESTION) = DialogResult.Yes Then
            ReloadList()
            ListView1.Focus()
        Else
            ListView1.Items.Clear()
            TextBox1.Text = ""
            TextBox1.Focus()
        End If


        mainwnd.ReloadListView()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyValue = Keys.F9 Then

            If Me.ListView1.SelectedIndices.Count = 0 Then Exit Sub
            Button1.PerformClick()

        End If
    End Sub

    Private Sub getarticle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub getarticle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        mainwnd.Visible = True
    End Sub
End Class