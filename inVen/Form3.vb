Imports System.Text.RegularExpressions

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If (TextBox3.Text.Trim = "") Then
            showMessageEx("Bitte gebe einen gültigen Datenbanknamen ein!", "Achtung...", S_STYLES.SWARNING)
            Exit Sub
        End If
        If (TextBox1.Text.Trim = "") Then
            TextBox1.Text = "admin"
            TextBox2.Text = "admin"
        End If

        If TextBox1.Text = TextBox2.Text Then
                Dim EF As Boolean = False
                Dim RNDK As String = ""
            Do
                RNDK = getFileKey()
                EF = IO.File.Exists(DATAP & "\" & RNDK & ".xjson")
            Loop Until Not EF

            Dim KKEY As String = ""
            Dim KK As Boolean = False
            Do
                KKEY = getFileKey()
                KK = IO.File.Exists(KeyBound & "\" & KKEY & ".key")
            Loop Until Not KK
            Dim EFG As New IO.StreamWriter(KeyBound & "\" & KKEY & ".key")
            Dim T_KEY As String = getFileKey() & getFileKey()
            EFG.Write(T_KEY)
            EFG.Close()


            Dim efl As New IO.StreamWriter(DATAP & "\" & RNDK & ".xjson", False)
            efl.Write(DB_VER & "||" & TextBox3.Text & "||" & MD5StringHash(TextBox1.Text) & "||" & KKEY & "||" & MD5StringHash(T_KEY) & "||")
            efl.Close()
            MsgBox("Deine Datenbank '" & TextBox3.Text.Trim & "' wurde erfolgreich angelegt. Melde dich nun regulär an.", MsgBoxStyle.Information, "Registriert.")

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
                MsgBox("Die Passwörter stimmen nicht überein, bitte vergewissere dich dass sowohl das wiederholte als auch das ursprüngliche Passwort übereinstimmen!", MsgBoxStyle.Exclamation, "Achtung...")
            End If




    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        afterShown.Enabled = True
        afterShown.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        loginwnd.ReloadLogin()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp
        ' Form3_KeyUp(e, sender)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        'Form3_KeyUp(e, sender)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        ' Form3_KeyUp(e, sender)
    End Sub

    Private Sub Form3_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        ' If e.KeyValue = Keys.Enter Then
        'If TextBox3.Focused Then TextBox1.Focus()
        'If TextBox1.Focused Then TextBox2.Focus()
        'If TextBox2.Focused Then Button1.PerformClick()
        'End If

        If e.KeyData = Keys.Escape Then Button2.PerformClick()
        If e.KeyData = Keys.F9 Then Button1.PerformClick()
    End Sub

    Private Sub afterShown_Tick(sender As Object, e As EventArgs) Handles afterShown.Tick
        If TextBox3.Text <> "" Then TextBox1.Focus()
        If TextBox1.Text <> "" Then TextBox2.Focus()
        If TextBox2.Text <> "" Then Button1.Focus()
        afterShown.Stop()
        afterShown.Enabled = False
    End Sub
End Class