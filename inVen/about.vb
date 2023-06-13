Public Class about
    Dim registered As Boolean = False
    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckLicense()
        If Not GetSetting("INVEN_APP", "LICENSE", "NAME") = "" Then

            Label2.Text = "Name : " & GetSetting("INVEN_APP", "LICENSE", "NAME") & vbNewLine & "Lizenz-ID : " & GetSetting("INVEN_APP", "LICENSE", "KEY")
            Me.Button1.Text = "Lizenz entfernen"
            registered = True
        Else
            Me.Button1.Text = "Lizenz hinzufügen"
            registered = False
            Label2.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If registered Then
            DeleteSetting("INVEN_APP", "LICENSE")
            showMessageEx("Lizenz wurde von deinem PC entfernt.", "Lizenz entfernt.", S_STYLES.SINFO)

        Else
            Lic.ShowDialog()
        End If
    End Sub
End Class