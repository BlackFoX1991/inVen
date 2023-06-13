Imports System.Text
Imports Newtonsoft.Json
Imports System.IO
Public Class loginwnd
    Dim hidden_click As Integer = 0
    Private Sub loginwnd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadLogin()
        CheckLicense()
        ComboBox1.Text = GetSetting("INVEN_APP", "LAST_LOGGED", "USER")
    End Sub
    Public Sub ReloadLogin()
        If Not IO.Directory.Exists(DATAP) Then IO.Directory.CreateDirectory(DATAP)
        If Not IO.Directory.Exists(KeyBound) Then IO.Directory.CreateDirectory(KeyBound)
        ComboBox1.Items.Clear()
        Dim FLS As New List(Of String)
        FLS.AddRange(IO.Directory.GetFiles(DATAP))

        For Each S As String In FLS

            If S.EndsWith(".xjson") Then

                Dim SP As New StringBuilder(IO.File.ReadAllText(S))
                Dim SPL As New List(Of String)
                SPL.AddRange(Split(SP.ToString, "||").ToList)
                If SPL(0).StartsWith("DBI_") Or SPL.Count = 0 Then
                    DB_LOADED_VER = SPL(0)
                    ComboBox1.Items.Add(SPL(1).ToString)
                    ConsoleText.AppendLine("[" & DateTime.Now.ToString("dd/MM/yyyy") & "] : User '" & SPL(0).ToString & "' added, userdb '" & S.Substring(S.LastIndexOf("\") + 1) & "'")
                End If


            End If


        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text.Trim() = "" Then
            showMessageEx("Bitte wähle eine der aufgeführten Datenbanken aus oder registriere eine Neue.", "Achtung...", S_STYLES.SWARNING)
            Exit Sub
        End If
        Dim FLS As New List(Of String)
        FLS.AddRange(IO.Directory.GetFiles(DATAP))
        Dim DB As New List(Of String)
        For Each S As String In FLS

            If S.EndsWith(".xjson") Then

                Dim SP As New StringBuilder(IO.File.ReadAllText(S))
                Dim SPL As New List(Of String)
                SPL.AddRange(Split(SP.ToString, "||").ToList)
                If Not SPL.Count = 0 Then
                    If SPL(1) = ComboBox1.Text Then
                        DB.AddRange(SPL)
                        CurrentFile = S
                        Exit For
                    End If
                End If
            End If
        Next
        If DB.Count = 0 Then
            If showMessageEx("Die Datenbank '" & ComboBox1.Text.Trim & "' wurde nicht gefunden, möchtest du diese Anlegen ?", "Datenbank nicht gefunden...", S_STYLES.SQUESTION) = DialogResult.Yes Then
                Dim mfn As New Form3
                mfn.TextBox3.Text = ComboBox1.Text.Trim
                If Not TextBox1.Text.Trim = "" Or TextBox1.Text = "admin" Then
                    mfn.TextBox1.Text = Me.TextBox1.Text
                    mfn.TextBox2.Text = Me.TextBox1.Text
                End If
                mfn.ShowDialog()
            End If
        Else
            Dim RES As E_Handles = LoginToInv(DB, ComboBox1.Text, TextBox1.Text)
            Select Case RES
                Case E_Handles.ERROR_DATA
                    MsgBox("Die Datenbank scheint beschädigt zu sein, bitte kontaktiere den Admin.", MsgBoxStyle.Critical, "Fehler " & E_Handles.ERROR_DATA)
                Case E_Handles.INVALID_USER
                    MsgBox("Die Datenbank scheint nicht zu existieren oder ist kaputt.", MsgBoxStyle.Critical, "Fehler " & E_Handles.INVALID_USER)
                Case E_Handles.WRONG_PASSWORD
                    MsgBox("Falsches Passwort, bitte versuche es erneut.", MsgBoxStyle.Critical, "Fehler " & E_Handles.WRONG_PASSWORD)

                Case E_Handles.INVALID_SALT
                    MsgBox("Es besteht keine Zugriffsberechtigung für die Datenbank, bitte fordere die entsprechende Schlüsseldatei beim Author an.", MsgBoxStyle.Exclamation, "Achtung")
                Case E_Handles.SUCCESS
                    SaveSetting("INVEN_APP", "LAST_LOGGED", "USER", ComboBox1.Text)

                    If CheckBox1.Checked Then
                        SaveSetting("INVEN_APP", "saved_pw", ComboBox1.Text, TextBox1.Text)

                    End If

                    ClearKey = TextBox1.Text
                    Me.Close()
            End Select

            ConsoleText.AppendLine("[" & DateTime.Now.ToString("dd/MM/yyyy") & "] : Login Results : (USER: " & ComboBox1.Text & "):: " & RES.ToString)
        End If


    End Sub

    Private Sub loginwnd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not LoggedIn Then
            End
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim mfn As New Form3
        If mfn.ShowDialog = DialogResult.OK Then
            ReloadLogin()
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then Button1.PerformClick()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> "" Then



            If TextBox1.Text = "" Then TextBox1.Text = "admin"


        End If
    End Sub

    Private Sub ComboBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyUp
        If e.KeyCode = Keys.Enter Then Me.TextBox1.Focus()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_HandleCreated(sender As Object, e As EventArgs) Handles TextBox1.HandleCreated

    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = "admin" Then TextBox1.Text = ""
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        If ComboBox1.Text.Trim <> "" Then
            If TextBox1.Text = "" Then TextBox1.Text = "admin"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If ComboBox1.Text.Trim <> "" Then
            If CheckBox1.Checked Then
                SaveSetting("INVEN_APP", "SAVE_PW", Me.ComboBox1.Text.Trim, "Y")
            Else
                DeleteSetting("INVEN_APP", "SAVE_PW", Me.ComboBox1.Text.Trim)
            End If
        End If
    End Sub

    Private Sub ComboBox1_TabStopChanged(sender As Object, e As EventArgs) Handles ComboBox1.TabStopChanged

    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        Try


            If GetSetting("INVEN_APP", "SAVE_PW", Me.ComboBox1.Text.Trim) = "Y" Then
                Me.TextBox1.Text = GetSetting("INVEN_APP", "saved_pw", ComboBox1.Text)
                Me.CheckBox1.Checked = True
            Else
                Me.CheckBox1.Checked = False
                TextBox1.Text = ""

            End If


        Catch ex As Exception
            Me.CheckBox1.Checked = False
            TextBox1.Text = ""
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        hidden_click += 1
        If hidden_click >= 5 Then
            DeleteSetting("INVEN_APP")
            showMessageEx("Alle Einstellungen zurückgesetzt.", "Reset", S_STYLES.SINFO)
            hidden_click = 0
        End If
    End Sub
End Class