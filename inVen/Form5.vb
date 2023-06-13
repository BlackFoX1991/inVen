Public Class errorLog

    Public showDetails As Boolean = False
    Public sStyle As Integer

    Private Sub errorLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not showDetails Then Me.Button2.Visible = False
        Select Case sStyle
            Case S_STYLES.SINFO
                Me.PictureBox1.Image = ICONS.Images.Item(0)
                'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)

            Case S_STYLES.SERROR
                Me.PictureBox1.Image = ICONS.Images.Item(1)
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            Case S_STYLES.SWARNING
                Me.PictureBox1.Image = ICONS.Images.Item(2)
                'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            Case S_STYLES.SQUESTION
                Button2.Visible = False
                Button1.Visible = False
                Button3.Visible = True
                Button4.Visible = True
                'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Question)
                Me.PictureBox1.Image = ICONS.Images.Item(3)
        End Select

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Visible Then TextBox1.Visible = False Else TextBox1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class