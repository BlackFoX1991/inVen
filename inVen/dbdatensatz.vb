Public Class dbdatensatz

    Public Enum modus_
        mNew
        mEdit
        mShow
    End Enum
    Public cModus As modus_ = modus_.mShow
    Public selID As String = ""
    Private Sub dbdatensatz_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\data\images") Then IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\data\images")
        Select Case cModus
            Case modus_.mShow
                loadView()
                pSave.Enabled = False
                pID.ReadOnly = True
                pGroup.ReadOnly = True
                pDesc.ReadOnly = True
                pColor.ReadOnly = True
                pPrice.Enabled = False
                Me.Text = "Datensatz ansehen..."
                Me.importCon.Enabled = True
            Case modus_.mNew
                pSave.Enabled = True
                pID.ReadOnly = False
                pGroup.ReadOnly = False
                pDesc.ReadOnly = False
                pColor.ReadOnly = False
                pPrice.Enabled = True
                Me.Text = "Neuen Datensatz anlegen..."
                Me.importCon.Enabled = False
            Case modus_.mEdit
                loadView()
                pSave.Enabled = True
                pID.ReadOnly = True
                pGroup.ReadOnly = False
                pDesc.ReadOnly = False
                pColor.ReadOnly = False
                pPrice.Enabled = True
                Me.Text = "Datensatz bearbeiten..."
                Me.importCon.Enabled = True


        End Select
    End Sub

    Public Sub loadView()
        For Each T As astamm In cInventory.Stammdaten

            If T.ID_Nummer = selID Then
                pID.Text = T.ID_Nummer
                pGroup.Text = T.StammID
                pColor.Text = T.aFarbe
                pPrice.Value = T.preis
                pDesc.Text = T.aBeschreibung
                If IO.File.Exists(My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & ".jpg") Then
                    pImage.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & ".jpg")
                ElseIf IO.File.Exists(My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & ".png") Then
                    pImage.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & ".png")
                ElseIf IO.File.Exists(My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & ".jpeg") Then
                    pImage.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & ".jpeg")
                End If
                Exit For
            End If

        Next
    End Sub

    Private Sub pSave_Click(sender As Object, e As EventArgs) Handles pSave.Click

        If pID.Text.Trim = "" Then
            showMessageEx("Die ID für den Datensatz darf nicht leer sein!", "Fehler...", S_STYLES.SERROR)
            Exit Sub
        End If
        Select Case cModus
            Case modus_.mEdit

                If NeueStammdaten(pID.Text.Trim, pGroup.Text.Trim, pDesc.Text, pColor.Text, pPrice.Value, True) Then
                    showMessageEx("Der Datensatz wurde für die ID '" & pID.Text.Trim & "' erfolgreich übernommen.", "Datensatz gespeichert.", S_STYLES.SINFO)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    showMessageEx("Der Datensatz mit der ID '" & pID.Text.Trim & "' scheint nicht mehr zu existieren.", "Fehler...", S_STYLES.SERROR)
                End If

            Case modus_.mNew

                If NeueStammdaten(pID.Text.Trim, pGroup.Text.Trim, pDesc.Text, pColor.Text, pPrice.Value, False) Then
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    showMessageEx("Fehler beim anlegen des Datensatzes mit der ID '" & pID.Text.Trim & "'. Die ID scheint bereits zu existieren.", "Fehler...", S_STYLES.SERROR)
                End If
            Case modus_.mShow
                showMessageEx("Aktuell kann der Datensatz nicht gespeichert werden, Sie befinden sich in der Ansicht.", "Warnung.", S_STYLES.SWARNING)
        End Select
    End Sub

    Private Sub pCancel_Click(sender As Object, e As EventArgs) Handles pCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub pImage_Click(sender As Object, e As EventArgs) Handles pImage.Click
        showMessageEx("Das Bild wird später aus dem Dateipfad '" & My.Application.Info.DirectoryPath & "\data\images' geladen. Dateibezeichnung entspricht der ID des Artikels und kann folgendes Format besitzen: jpg,jpeg oder png.", "Info", S_STYLES.SINFO)
    End Sub

    Private Sub BildImportierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BildImportierenToolStripMenuItem.Click
        Dim svp As New OpenFileDialog
        svp.Title = "Bild für ausgewählten Artikel wählen..."
        svp.Filter = "Portable Network Image (.png) |*.png|Joint Photographic Experts Group (.jpeg)|*.jpeg|Joint Photographic Experts Group (.jpg)|*.jpg"
        If svp.ShowDialog = DialogResult.OK Then


            Dim sr As New IO.FileStream(svp.FileName, IO.FileMode.Open)
            Dim sw As New IO.FileStream(My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & svp.FileName.Substring(svp.FileName.LastIndexOf(".")), IO.FileMode.Create)
            Dim len As Long = sr.Length - 1
            Dim buffer(1024) As Byte
            Dim bytesread As Integer
            Dim prg As New progressed
            prg.Label1.Text = "Kopiere Datei " & svp.FileName & " nach " & My.Application.Info.DirectoryPath & "\data\images\" & pID.Text & svp.FileName.Substring(svp.FileName.LastIndexOf("."))
            prg.Show()
            While sr.Position < len
                bytesread = (sr.Read(buffer, 0, 1024))
                sw.Write(buffer, 0, bytesread)
                prg.ProgressBar1.Value = CInt(sr.Position / len * 100)

                Application.DoEvents()
            End While

            sw.Flush()
            sw.Close()
            sr.Close()
            prg.Close()
            loadView()

        End If
    End Sub
End Class