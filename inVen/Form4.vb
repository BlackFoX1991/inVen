Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            For Each P As cinventar In cInventory.InventarListe

                If P.invenName = TextBox2.Text.Trim Then
                    showMessageEx("Der Name '" & TextBox2.Text.Trim & "' ist schon vergeben, bitte suche einen anderen Namen hierfür.", "Achtung", S_STYLES.SWARNING)
                    Exit Sub
                End If
            Next
            Dim CP As New cinventar
            CP.invenName = TextBox2.Text
            CP.invenBeschreibung = TextBox3.Text
            cInventory.InventarListe.Add(CP)
            ConsoleText.AppendLine("[" & DateTime.Now.ToString("dd/MM/yyyy") & "] Der Inventareintrag '" & TextBox2.Text.Trim & "' wurde hinzugefügt. ( Benutzer : " & CurrentUser & " )")
            showMessageEx("Der Eintrag '" & TextBox2.Text.Trim & "' wurde dem Inventar hinzugefügt.", "Info", S_STYLES.SINFO)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ReloadTree()
        SaveChanges()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form4_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F9 Then
            Button1.PerformClick()
        ElseIf e.KeyValue = Keys.F2 Then
            Me.TextBox3.ReadOnly = False
            Me.TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp
        If e.KeyValue = Keys.Enter Then
            Me.TextBox3.ReadOnly = True
            Button1.PerformClick()
        End If
        Form4_KeyUp(sender, e)
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        Form4_KeyUp(sender, e)
    End Sub
End Class