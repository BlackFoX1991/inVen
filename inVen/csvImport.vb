Public Class csvImport

    Dim cFile As String = ""
    Dim cReader As xCSVFile
    Dim progressing As Boolean = False
    Dim ProgressP As Integer = 0
    Dim stopP As Boolean = False
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub checkup_Tick(sender As Object, e As EventArgs) Handles checkup.Tick
        If cFile = "" Then
            Me.ListView1.Clear()
            Me.GroupBox3.Enabled = False
            Me.Text = "CSV importieren..."
        Else
            If Not progressing Then
                Me.GroupBox3.Enabled = True
                Me.Text = "CSV importieren [" & cFile & "]"
                Button1.Enabled = True
            Else
                Me.GroupBox3.Enabled = False
                Me.Text = "CSV verarbeiten - Fortschritt : " & ProgressP & "%"
                Button1.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OVP As New OpenFileDialog
        OVP.Filter = "CSV Datei|*.csv"
        If OVP.ShowDialog = DialogResult.OK Then
            cReader = New xCSVFile(OVP.FileName, Me.CheckBox1.CheckState)
            If cReader.ErrorLog <> "" Then
                showMessageEx("Es ist ein Fehler aufgetreten beim lesen der CSV Datei, siehe bitte Details.", "Fehler...", S_STYLES.SERROR, True, cReader.ErrorLog)
                Exit Sub
            End If
            cFile = OVP.FileName

            loadPreview()

        End If
    End Sub

    Public Sub loadPreview()
        If IsNothing(cReader) Then Exit Sub
        If IsNothing(cReader.csv_container) Then Exit Sub
        If Not IsNothing(cReader.csv_container.Headers) Then
            For Each cHeader As String In cReader.csv_container.Headers
                Me.ListView1.Columns.Add(cHeader)
            Next
        Else
            For z = 0 To (cReader.csv_container.ValueUbound - 1)
                Me.ListView1.Columns.Add("Header " & z)
            Next
        End If

        Me.ListView1.Columns.Add("Inventar")

        For Each T As xCSVFile.Columns In cReader.csv_container.Rows
            Dim ITM As ListViewItem = Nothing
            Dim innerCount As Integer = -1
            For Each P As String In T.value

                innerCount += 1
                If innerCount = 0 Then
                    ITM = New ListViewItem
                    ITM.Text = P
                Else
                    ITM.SubItems.Add(P)
                End If


            Next
            ITM.SubItems.Add("")
            ListView1.Items.Add(ITM)

        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If progressing Then Exit Sub
        Dim PRC As Integer = 0
        progressing = True
        For Each IV As ListViewItem In ListView1.Items

            ProgressP = (PRC * 100) / ListView1.Items.Count
            If IV.SubItems(ListView1.Columns.Count - 1).Text = "" Then Continue For

            For Each P As cinventar In cInventory.InventarListe
                Dim UID As String = getUnID()
                If UID = "FALSE" Then
                    showMessageEx("Fehler beim einspeichern des Artikels, siehe Details.", "Fehler...", S_STYLES.SERROR, True, "UID konnte nicht generiert werden. Interner Fehler, bitte kontaktiere einen Entwickler.")
                    Exit Sub
                End If
                cInventory.uniqueIDS.Add(UID)
                If P.invenName = IV.SubItems(ListView1.Columns.Count - 1).Text Then

                    Dim NART As New artikel
                    NART.artikelnummer = IV.SubItems(0).Text
                    NART.Lagerplatz = IV.SubItems(1).Text
                    NART.Bestand = 1
                    NART.UniqueID = UID
                    P.ArtikelEintrag.Add(NART)
                End If

            Next
            PRC += 1
        Next
        progressing = False
        ProgressP = 0
        If Not PRC = 0 Then
            showMessageEx("Die Daten aus der Datei '" & cFile & "' wurden importiert.", "Vorgang beendet.", S_STYLES.SINFO)
            Me.Close()
        Else
            showMessageEx("Es wurden keine Daten importiert, wähle die gewüschten Felder aus und lege dann das Inventar mit einem Rechtsklick aus.", "Warnung.", S_STYLES.SINFO)
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub csvImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lstCSV_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles lstCSV.Opening
        If ListView1.SelectedIndices.Count = 0 Then lstCSV.Close()
    End Sub

    Private Sub InventarWählenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarWählenToolStripMenuItem.Click
        If ListView1.SelectedIndices.Count = 0 Then Exit Sub

        Dim cItems As New List(Of String)

        For Each G As String In mainwnd.ListBox1.Items
            cItems.Add(G)
        Next



        Dim gt As String = selectfromlistwindow("Wähle ein Inventar für die markierten Artikel...", cItems)
        If gt = "" Then Exit Sub
        For Each L As ListViewItem In ListView1.SelectedItems
            L.SubItems(L.SubItems.Count - 1).Text = gt

        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class