Public Class mainwnd
    Dim GlobalPath As String = My.Application.Info.DirectoryPath & "\Data.ntp"
    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HilfeToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EinfügenToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub KopierenToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AusschneidenToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub toolStripSeparator7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DruckenToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ÖffnenToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SpeichernToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NeuToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EinfügenToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub KopierenToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AusschneidenToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub toolStripSeparator6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DruckenToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SpeichernToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ÖffnenToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NeuToolStripButton_Click(sender As Object, e As EventArgs) Handles NeuToolStripButton.Click
        If LoggedIn Then
            Dim NZ As New Form4
            NZ.ShowDialog()
        End If
    End Sub

    Private Sub checkUp_Tick(sender As Object, e As EventArgs) Handles checkUp.Tick
        On Error Resume Next

        If Not LoggedIn Then
            Me.Text = inVen_Name & inVen_Version
            Me.ToolStripStatusLabel1.Text = "Warte..."
            Me.Enabled = False
            If Not timerWait Then
                timerWait = True
                Dim LOG As New loginwnd
                LOG.ShowDialog()
            End If

        Else
            Me.Text = inVen_Name & inVen_Version & " - [" & CurrentFile.Substring(CurrentFile.LastIndexOf("\") + 1) & "]"
            If Not Me.Enabled Then Me.Enabled = True
            Me.ToolStripStatusLabel1.Text = "Datenbank ( " & DB_LOADED_VER & " ) :  " & CurrentUser & " -> " & "[[ " & KeyBound & "\" & currentSaltKeyFile & ".key ]]"

            If ListBox1.SelectedIndex = -1 Then GroupBox1.Enabled = False Else GroupBox1.Enabled = True
            If ListBox1.SelectedIndex = -1 Then Me.ListView1.Enabled = False Else ListView1.Enabled = True
        End If
    End Sub

    Private Sub NeuToolStripMenuItem_Click(sender As Object, e As EventArgs)
        NeuToolStripButton.PerformClick()

    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LogoutInv()

    End Sub

    Private Sub Informationen_Click(sender As Object, e As EventArgs)

    End Sub





    Private Sub VerlaufLeerenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerlaufLeerenToolStripMenuItem.Click
        resetConsole()
    End Sub

    Private Sub LogSpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogSpeichernToolStripMenuItem.Click
        Dim sp As New SaveFileDialog
        sp.Filter = "Textdatei|*.txt"
        sp.Title = "Lod Speichern..."
        Try


            If sp.ShowDialog = DialogResult.OK Then
                Dim FP As New IO.StreamWriter(sp.FileName)
                FP.Write(ConsoleText.ToString)
                FP.Close()
                showMessageEx("Logdatei '" & sp.FileName & "' wurde erfolgreich gespeichert.", "Log Datei", S_STYLES.SINFO)
            End If

        Catch ex As Exception
            showMessageEx("Logdatei '" & sp.FileName & "' konnte nicht gespeichert werden, bitte siehe hierzu in die Details.", "Fehler...", S_STYLES.SERROR, True, ex.Message.ToString)
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs)
        ReloadListView()
    End Sub
    Public Sub ReloadListView()
        CheckLicense(False)
        Me.ListView1.Items.Clear()
        btnUnlock.Visible = False
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If currentInvSelected = "" Then Exit Sub
        If IsNothing(cInventory) Then Exit Sub


        If Not GroupBox1.Visible Then
            If Not IsNothing(cInventory.InventarListe(ListBox1.SelectedIndex).Key) Then
                If Not cInventory.InventarListe(ListBox1.SelectedIndex).Key.Trim = "" Then
                    If currentInvPassword = cInventory.InventarListe(ListBox1.SelectedIndex).Key Then
                        btnUnlock.Visible = False
                    Else
                        btnUnlock.Visible = True
                        Exit Sub
                    End If
                End If
            End If
            For Each P As artikel In cInventory.InventarListe(ListBox1.SelectedIndex).ArtikelEintrag
                Me.ListView1.Items.Add(New ListViewItem({P.artikelnummer,
                                                            getProductDesc(P.artikelnummer),
                                                            P.Bestand, lookforinventory(P.artikelnummer), P.Lagerplatz,
                                                            P.UniqueID}))

            Next
        Else

            If Button1.Text = "Artikel" Then
                SearchItems(tSearchBar.Text, 0)
            ElseIf Button1.Text = "Beschreibung" Then
                SearchItems(tSearchBar.Text, 1)

            End If
        End If
    End Sub
    Private Sub NeuesInventarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuesInventarToolStripMenuItem.Click
        NeuToolStripButton.PerformClick()
    End Sub

    Private Sub ArtikelEinspeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtikelEinspeichernToolStripMenuItem.Click
        Dim nw As New newPos
        nw.ShowDialog()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        currentInvSelected = ListBox1.SelectedItem.ToString
        If Not currentInvSelected = old_currentInvSelected Then
            currentInvPassword = ""
            old_currentInvSelected = currentInvSelected
        End If
        ReloadListView()
    End Sub

    Private Sub InventarLöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarLöschenToolStripMenuItem.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If currentInvSelected = "" Then Exit Sub
        Dim cnt As Integer = -1
        For Each P As cinventar In cInventory.InventarListe
            cnt += 1
            If P.invenName = currentInvSelected Then
                cInventory.InventarListe.RemoveAt(cnt)
                ReloadTree()
                ReloadListView()
                Exit For
            End If
        Next
    End Sub

    Private Sub mainwnd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        LogoutInv()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tSearchBar.TextChanged

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles tSearchBar.KeyUp
        If e.KeyValue = Keys.Enter Then
            ReloadListView()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If Me.GroupBox1.Visible Then Me.GroupBox1.Visible = False Else Me.GroupBox1.Visible = True
        ReloadListView()
    End Sub

    Public Sub SearchItems(Text As String, Optional SearchOption As Integer = 0)
        Dim Ergebnisse As Integer = 0
        ListView1.Items.Clear()

        For Each T As cinventar In cInventory.InventarListe
            If T.invenName = currentInvSelected Then
                For Each P As artikel In T.ArtikelEintrag
                    Select Case SearchOption
                        Case 0
                            If P.artikelnummer = tSearchBar.Text.Trim Then

                                ListView1.Items.Add(New ListViewItem({P.artikelnummer, getProductDesc(P.artikelnummer), P.Bestand, lookforinventory(P.artikelnummer), P.Lagerplatz, P.UniqueID}))
                                Ergebnisse += 1
                            End If

                        Case 1

                            If Not CheckBox1.Checked Then
                                If getProductDesc(P.artikelnummer).ToLower.Contains(tSearchBar.Text.Trim.ToLower) Then
                                    ListView1.Items.Add(New ListViewItem({P.artikelnummer, getProductDesc(P.artikelnummer), P.Bestand, lookforinventory(P.artikelnummer), P.Lagerplatz, P.UniqueID}))
                                    Ergebnisse += 1
                                End If
                            Else
                                If getProductDesc(P.artikelnummer).Contains(tSearchBar.Text.Trim) Then
                                    ListView1.Items.Add(New ListViewItem({P.artikelnummer, getProductDesc(P.artikelnummer), P.Bestand, lookforinventory(P.artikelnummer), P.Lagerplatz, P.UniqueID}))
                                    Ergebnisse += 1
                                End If
                            End If



                    End Select


                Next

                Exit For
            End If
        Next
        If Ergebnisse > 0 Then

            lblRes.Text = "Es wurden " & Ergebnisse & " Einträge gefunden."
        Else

            lblRes.Text = "Es wurden keine Einträge gefunden."
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub PositionLöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PositionLöschenToolStripMenuItem.Click
        If IsNothing(cInventory) Then Exit Sub
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If ListView1.Items.Count = 0 Then Exit Sub
        If ListView1.SelectedIndices.Count = 0 Then Exit Sub
        Dim INV As Integer = -1

        Dim RMVS As New List(Of artikel)
        For Each b As cinventar In cInventory.InventarListe
            If b.invenName = currentInvSelected Then
                For Each Z As ListViewItem In ListView1.SelectedItems
                    For Each U As artikel In b.ArtikelEintrag
                        If Z.SubItems(5).Text = U.UniqueID Then
                            RMVS.Add(U)
                        End If
                    Next
                Next
                For Each DEL As artikel In RMVS
                    b.ArtikelEintrag.Remove(DEL)
                Next
                Exit For
            End If
        Next



        ReloadListView()


    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        LogoutInv()
        cInventory = Nothing
        ReloadListView()
        ReloadTree()
        CheckLicense()
    End Sub

    Private Sub cCommandLine_TextChanged(sender As Object, e As EventArgs)

    End Sub




    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click



    End Sub

    Private Sub cConsoleText_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub BestandÄndernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BestandÄndernToolStripMenuItem.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If ListView1.Items.Count = 0 Then Exit Sub
        If ListView1.SelectedIndices.Count = 0 Or ListView1.SelectedIndices.Count > 1 Then Exit Sub
        Try

            Dim Eingabe As Integer = CInt(InputBox("Wie viel möchten Sie entnehmen ?", "Entnahme", "1"))
            If Eingabe = 0 Then Exit Sub

            Dim CHN As New List(Of artikel)
            For Each b As cinventar In cInventory.InventarListe
                If b.invenName = currentInvSelected Then
                    For Each Z As ListViewItem In ListView1.SelectedItems
                        For Each U As artikel In b.ArtikelEintrag
                            If Z.SubItems(5).Text = U.UniqueID Then
                                If Eingabe > U.Bestand Then Exit Sub
                                CHN.Add(U)
                            End If
                        Next
                    Next
                    For Each Z As artikel In CHN
                        Z.Bestand -= Eingabe
                        If Z.Bestand <= 0 Then
                            showMessageEx("Kein Bestand mehr für den entnommenen Artikel, wurde daher aus Inventar gelöscht.", "Entnahme", S_STYLES.SINFO)
                            PositionLöschenToolStripMenuItem.PerformClick()
                        End If
                    Next
                    Exit For
                End If
            Next
            ReloadListView()



            showMessageEx("Entnahme erfolgreich.", "Entnahme", S_STYLES.SINFO)

        Catch ex As Exception
            showMessageEx("Fehler beim entnehmen der Artikel, für weiter Informationen siehe Details.", "Fehler...", S_STYLES.SERROR, True, ex.Message.ToString)
        End Try
    End Sub

    Private Sub InventarUmbenennenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarUmbenennenToolStripMenuItem.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If currentInvSelected = "" Then Exit Sub
        Dim newName As String = InputBox("Lege einen neuen Namen für das Inventar fest.", "Inventar umbenennen...", currentInvSelected)
        If newName.Trim = currentInvSelected Or newName.Trim = "" Then Exit Sub
        Dim cnt As Integer = -1
        For Each P As cinventar In cInventory.InventarListe
            cnt += 1
            If cnt = ListBox1.SelectedIndex Then Continue For
            If P.invenName = newName.Trim Then
                showMessageEx("Der Name '" & newName.Trim & "' ist schon vergeben, bitte suche einen anderen Namen hierfür.", "Achtung", S_STYLES.SWARNING)
                Exit Sub
            End If
        Next
        cInventory.InventarListe(Me.ListBox1.SelectedIndex).invenName = newName.Trim
        ReloadTree()
        ReloadListView()
    End Sub

    Private Sub SperrenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SperrenToolStripMenuItem.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If currentInvSelected = "" Then Exit Sub
        If IsNothing(cInventory) Then Exit Sub
        If Not IsNothing(cInventory.InventarListe(ListBox1.SelectedIndex).Key) Then
            If cInventory.InventarListe(Me.ListBox1.SelectedIndex).Key.Trim = "" Then
                Dim nLock As New locked
                nLock.ShowDialog()
                ReloadListView()
            Else
                Dim ENT As String = InputBox("Für das entsperren des Inventar wird das Passwort benötigt welches dafür verwendet wurde", "Inventar entsperren", "")
                If MD5StringHash(ENT) = cInventory.InventarListe(Me.ListBox1.SelectedIndex).Key Then
                    showMessageEx("Inventar wurde erfolgreich entsperrt.", "Vorgang beendet", S_STYLES.SINFO)
                    cInventory.InventarListe(Me.ListBox1.SelectedIndex).Key = ""
                    ReloadListView()
                Else
                    showMessageEx("Passwort ist falsch, Inventar bleibt gesperrt.", "Fehler...", S_STYLES.SERROR)
                    Exit Sub
                End If
            End If
        Else
            Dim nLock As New locked
            nLock.ShowDialog()
            ReloadListView()
        End If

    End Sub

    Private Sub TreeContext_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TreeContext.Opening
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If currentInvSelected = "" Then Exit Sub
        If IsNothing(cInventory) Then Exit Sub
        If IsNothing(cInventory.InventarListe(ListBox1.SelectedIndex).Key) Then Exit Sub
        If cInventory.InventarListe(Me.ListBox1.SelectedIndex).Key.Trim = "" Then Me.SperrenToolStripMenuItem.Text = "Inventar sperren" Else Me.SperrenToolStripMenuItem.Text = "Inventar entsperren"
    End Sub

    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
        If Not IsNothing(cInventory.InventarListe(ListBox1.SelectedIndex).Key) Then
            If Not cInventory.InventarListe(ListBox1.SelectedIndex).Key.Trim = "" Then
                Dim PWD As String = InputBox("Dieses Inventar wurde mit einem Passwort gesperrt", "Passwort erforderlich", "")
                If Not MD5StringHash(PWD) = cInventory.InventarListe(ListBox1.SelectedIndex).Key Then
                    showMessageEx("Falsches Passwort, Inventar wird nicht aufgerufen.", "Fehler...", S_STYLES.SERROR)
                Else
                    currentInvPassword = MD5StringHash(PWD)
                End If
            End If
        End If
        ReloadListView()
    End Sub

    Private Sub SplitContainer3_SplitterMoved(sender As Object, e As SplitterEventArgs)

    End Sub

    Private Sub mainwnd_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles Me.GiveFeedback

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        SaveChanges()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)
        Dim OVP As New OpenFileDialog
        Dim SVP As New SaveFileDialog

        OVP.Filter = "CSV Datei|*.csv"
        SVP.Filter = "CSV Datei|*.csv"

        OVP.Title = "CSV Datei öffnen"
        SVP.Title = "Speicher unter..."

        If OVP.ShowDialog = DialogResult.OK Then
            If SVP.ShowDialog = DialogResult.OK Then
                CleanUpCSV(OVP.FileName, SVP.FileName)
                showMessageEx("Die CSV Datei wurde neu formatiert", "Formatierung", S_STYLES.SINFO)
            End If
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim importForm As New csvImport
        importForm.ShowDialog()
    End Sub

    Private Sub ListContext_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ListContext.Opening
        If ListView1.SelectedIndices.Count > 1 Then
            BestandÄndernToolStripMenuItem.Enabled = False
        Else
            BestandÄndernToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub AllesMarkierenToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton6_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If IsNothing(cInventory) Then Exit Sub
        If ListBox1.SelectedIndex = -1 Then
            showMessageEx("Bitte wählen Sie zuerst ein Inventar aus welches bearbeitet werden soll.", "Achtung...", S_STYLES.SWARNING)
            Exit Sub
        End If

        If Not IsNothing(cInventory.InventarListe(ListBox1.SelectedIndex).Key) Then
            If Not cInventory.InventarListe(ListBox1.SelectedIndex).Key.Trim = "" Then
                If currentInvPassword = cInventory.InventarListe(ListBox1.SelectedIndex).Key Then
                    Dim ngt As New getarticle
                    ngt.Show()
                    Me.Visible = False
                Else
                    showMessageEx("Das ausgewählte Inventar ist Passwort geschützt, bitte entsperren Sie es bevor es bearbeitet werden kann.", "Achtung...", S_STYLES.SWARNING)
                End If
            Else
                Dim ngt As New getarticle
                ngt.Show()
                Me.Visible = False
            End If
        Else
            Dim ngt As New getarticle
            ngt.Show()
            Me.Visible = False
        End If


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Artikel" Then
            Button1.Text = "Beschreibung"
            Me.CheckBox1.Enabled = True
        Else
            Button1.Text = "Artikel"
            Me.CheckBox1.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ReloadListView()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripButton7_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim prnt As New clsListviewPrint(Me.ListView1, "Inventar: " & currentInvSelected)
        prnt.Preview = True
        prnt.Print(currentInvSelected)
    End Sub

    Private Sub ErsatzlieferscheinGenerierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ErsatzlieferscheinGenerierenToolStripMenuItem.Click
        Dim elsn As New eLieferschein
        elsn.ShowDialog()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

    End Sub

    Private Sub EigenschaftenDerDatenbankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EigenschaftenDerDatenbankToolStripMenuItem.Click
        Dim Props As New db_details
        Props.ShowDialog()
    End Sub

    Private Sub SplitContainer2_SplitterMoved(sender As Object, e As SplitterEventArgs)

    End Sub

    Private Sub ArtikelAnzeigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtikelAnzeigenToolStripMenuItem.Click
        Dim sData As New dbdatensatz
        If Not productExists(ListView1.SelectedItems(0).Text) Then
            If showMessageEx("Der Artikel wurde noch nicht im Artikel-Stamm angelegt, möchten Sie dies tun ?", "Datenbank Stammbaum", S_STYLES.SQUESTION) = DialogResult.Yes Then
                sData.cModus = dbdatensatz.modus_.mNew
                sData.pID.Text = ListView1.SelectedItems(0).Text
                sData.ShowDialog()
            End If
            Exit Sub
        Else
            sData.cModus = dbdatensatz.modus_.mShow
            sData.selID = ListView1.SelectedItems(0).Text
            sData.ShowDialog()
        End If


    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If IsNothing(cInventory) Then Exit Sub
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If ListView1.Items.Count = 0 Then Exit Sub
        If ListView1.SelectedIndices.Count = 0 Then Exit Sub
        ArtikelAnzeigenToolStripMenuItem.PerformClick()
    End Sub



    Private Sub XToolStripMenuItem_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        about.ShowDialog()
    End Sub
End Class
