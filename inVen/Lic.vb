Public Class Lic
    Dim registered As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim webq As New Net.WebClient
        Dim req As String = webq.DownloadString("https://drive.google.com/uc?export=download&id=1sNFQqbZJF94tllYgyAlXmvJoSPRIg8P7")
        Dim hsh As String = MD5StringHash(TextBox1.Text & TextBox2.Text).ToLower

        Dim lns As New List(Of String)
        lns.AddRange(req.Split(vbNewLine))

        Dim fnd As Boolean = False
        For Each L As String In lns

            If L = hsh Then
                fnd = True
                Exit For

            End If

        Next

        If Not fnd Then

            showMessageEx("Lizenz wurde nicht gefunden, bitte überprüfe deine Eingabe", "Fehler...", S_STYLES.SERROR)
            registered = False
        Else
            registered = True
            Me.DialogResult = DialogResult.OK
            SaveSetting("INVEN_APP", "LICENSE", "NAME", TextBox1.Text)
            SaveSetting("INVEN_APP", "LICENSE", "KEY", TextBox2.Text)
            SaveSetting("INVEN_APP", "LICENSE", "HASH", hsh)
            showMessageEx("Deine Lizenz wurde gefunden, viel Spaß bei der Nutzung!", "Registriert.", S_STYLES.SINFO)
            Me.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Abort
        registered = True
        Me.Close()
    End Sub

    Private Sub Lic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Lic_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not registered Then e.Cancel = True
    End Sub
End Class