Imports System.Text

Public Class eLieferschein


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        genEList()




    End Sub

    Public Sub genEList()







        TextBox4.Text = ""
        Dim dict As New Dictionary(Of String, Integer)
        Dim fcount As Integer = 0
        For Each P As String In Split(TextBox3.Text, vbCrLf)
            If P.Trim = "" Then Continue For
            If dict.ContainsKey(P.Trim) Then dict(P.Trim) += 1 Else dict.Add(P.Trim, 1)
        Next

        For Each item In dict
            TextBox4.Text &= item.Key & ";;" & item.Value & vbNewLine
        Next
        genListVW()


    End Sub

    Public Sub genListVW()
        Me.ListView1.Items.Clear()


        Dim LVW As New ListViewItem
        LVW.Font = New Drawing.Font("Tahoma", 11, FontStyle.Bold)
        LVW.Text = "Verantwortlicher:"

        If Not TextBox1.Text.Trim = "" Then
            LVW.SubItems.Add(Me.TextBox1.Text.Trim)
        Else
            LVW.SubItems.Add("N/A")
        End If


        ListView1.Items.Add(LVW)
        Dim LVW0 As New ListViewItem
        LVW0.Font = New Drawing.Font("Tahoma", 11, FontStyle.Bold)
        LVW0.Text = "Datum:"
        LVW0.SubItems.Add(DateTime.Now.ToString(“dd/MM/yyyy”))
        ListView1.Items.Add(LVW0)




        Dim LVW1 As New ListViewItem
        LVW1.Font = New Drawing.Font("Tahoma", 11, FontStyle.Bold)
        LVW1.Text = "Ersatz-LSN. Nummer:"
        If Not TextBox2.Text.Trim = "" Then
            LVW1.SubItems.Add(TextBox2.Text.Trim)
        Else
            LVW1.SubItems.Add("N/A")
        End If
        ListView1.Items.Add(LVW1)


        Me.ListView1.Items.Add("")
        Me.ListView1.Items.Add("")
        Me.ListView1.Items.Add("")

        Dim LST_HEADER As New ListViewItem
        LST_HEADER.Text = "Artikel"
        LST_HEADER.SubItems.AddRange({"Beschreibung", "Menge"})
        LST_HEADER.SubItems(0).BackColor = Color.Black
        LST_HEADER.SubItems(1).BackColor = Color.Black
        LST_HEADER.SubItems(2).BackColor = Color.Black
        LST_HEADER.SubItems(0).ForeColor = Color.White
        LST_HEADER.SubItems(1).ForeColor = Color.White
        LST_HEADER.SubItems(2).ForeColor = Color.White
        Me.ListView1.Items.Add(LST_HEADER)
        Dim fcount As Integer = 0
        Dim STL As New List(Of String)

        STL.AddRange(TextBox4.Text.Split(vbCrLf))

        For Each T As String In STL


            Dim inLine As New List(Of String)
            inLine.AddRange(T.Split(";"))

            If inLine.Count < 3 Then Continue For

            If Not IsNumeric(inLine(2)) Then Continue For
            If inLine(0).Trim = "" Or inLine(2).Trim = "" Then Continue For

            Dim lvi As New ListViewItem
            lvi.Text = inLine(0)
            lvi.SubItems.AddRange({inLine(1), inLine(2)})
            fcount += CInt(inLine(2))
            ListView1.Items.Add(lvi)



        Next

        Dim LR As New ListViewItem
        LR.Text = ""
        LR.SubItems.AddRange({"Gesamt", fcount.ToString})
        LR.SubItems(1).BackColor = Color.Black
        LR.SubItems(1).ForeColor = Color.White
        LR.SubItems(2).BackColor = Color.Black
        LR.SubItems(2).ForeColor = Color.White
        LR.SubItems(0).BackColor = Color.Black
        LR.SubItems(0).ForeColor = Color.White
        ListView1.Items.Add(LR)


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        genListVW()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        genListVW()
    End Sub

    Private Sub eLieferschein_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        genEList()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim prnter As New clsListviewPrint(Me.ListView1, "Ersatzlieferschein")
        prnter.Preview = True
        prnter.Print("Ersatzlieferschein")
    End Sub


    Public Sub ListViewToCSV(LSV As ListView, efile As String)
        Dim SRB As String = ""


        For Each P As ListViewItem In LSV.Items

                For i = 0 To P.SubItems.Count - 1


                    SRB &= P.SubItems(i).Text & ","

                Next

                SRB = SRB.Substring(0, SRB.Length - 1)
                SRB &= vbCrLf

            Next

            Dim iof As New IO.StreamWriter(efile)
            iof.Write(SRB)
            iof.Close()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim svp As New SaveFileDialog
            svp.Filter = "CSV Sheet|*.csv"
            svp.Title = "Als CSV Speichern..."
            If svp.ShowDialog = DialogResult.OK Then

                ListViewToCSV(Me.ListView1, svp.FileName)
                MsgBox("Die Liste wurde als CSV gespeichert.", MsgBoxStyle.Information, "CSV")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Fehler")
        End Try

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If Not TextBox3.ReadOnly And TextBox4.Focused Then TextBox3.ReadOnly = True
        genListVW()
    End Sub

    Private Sub TextBox3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseDoubleClick
        If TextBox3.ReadOnly Then
            If MsgBox("Möchtest du diese Liste neu bearbeiten ? Hierdurch geht die, eventuell schon bearbeitete, Haupteingabe wieder verloren.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Achtung!") = MsgBoxResult.Yes Then
                TextBox3.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim svp As New SaveFileDialog
        svp.Filter = "eLSN Datei|.elg"
        svp.Title = "Zwischenspeichern..."
        If svp.ShowDialog = DialogResult.OK Then

            Dim iox As New IO.StreamWriter(svp.FileName)
            iox.Write(TextBox1.Text & "#>#" & TextBox2.Text & "#>#" & TextBox4.Text)
            iox.Close()

            MsgBox("Die Datei '" & svp.FileName & "' wurde erfolgreich gespeichert.", MsgBoxStyle.Information, "Zwischenspeichern")

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ovp As New OpenFileDialog
        ovp.Filter = "eLSN Datei|*.elg"
        ovp.Title = "eLieferschein Datei laden..."
        If ovp.ShowDialog = DialogResult.OK Then

            Dim iof As New IO.StreamReader(ovp.FileName)
            Dim inp As String = iof.ReadToEnd
            iof.Close()

            If Split(inp, "#>#").Count < 3 Then
                MsgBox("Fehler beim laden der Datei '" & ovp.FileName & "'. Unbekanntes Format erkannt.", MsgBoxStyle.Critical, "Fehler")
                Exit Sub
            End If


            Dim inL As New List(Of String)
            inL.AddRange(Split(inp, "#>#"))

            TextBox1.Text = inL(0)
            TextBox2.Text = inL(1)
            TextBox4.Text = inL(2)

            genListVW()

        End If
    End Sub



    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress


        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.F9) Then
            genEList()
            e.Handled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        genEList()
    End Sub
End Class