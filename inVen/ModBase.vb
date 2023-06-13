Imports System.Collections.Specialized
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft

Module ModCrypt


    Public inVen_Version As String = "((Version 2.0A))"
    Public inVen_Name As String = "inVen - Inventar System © 2022 A. Loewen"
    Public DB_VER As String = "DBI_20"
    Public DB_LOADED_VER As String = ""
    Public xDEV_KEY As String = "pMctJr0m4Dob3bI4kJCKXDm5Y4wczXuu"

    Public Enum E_Handles
        ERROR_DATA
        WRONG_PASSWORD
        INVALID_USER
        INVALID_SALT
        SUCCESS
    End Enum

    Public Enum S_STYLES
        SINFO
        SERROR
        SWARNING
        SQUESTION
    End Enum

    Public ConsoleText As New StringBuilder(inVen_Name & inVen_Version & vbNewLine & "<--------------------------------------------------------------->" & vbNewLine)
    Public DATAP As String = My.Application.Info.DirectoryPath & "\data"
    Public KeyBound As String = My.Application.Info.DirectoryPath & "\keys"
    Public CurrentSessionHash As String = ""
    Public CurrentUser As String = ""
    Public CurrentFile As String = ""
    Public ClearKey As String = ""
    Public LoggedIn As Boolean = False
    Public timerWait As Boolean = False
    Public cInventory As inventoryGroup
    Public currentInvSelected As String
    Public old_currentInvSelected As String
    Public currentInvPassword As String
    Public currentSaltKeyFile As String
    Public AES_MOD As New AesCryptor
    Public SAVE_BLOCK_SPLIT_SCALE As Integer = 500


    Public Sub LogoutInv()
        resetConsole()
        If Not LoggedIn Then Exit Sub
        SaveChanges()
        CurrentSessionHash = ""
        DB_LOADED_VER = ""
        CurrentUser = ""
        LoggedIn = False
        timerWait = False
        cInventory = Nothing

    End Sub
    Public Sub resetConsole()
        ConsoleText = New StringBuilder(inVen_Name & inVen_Version & vbNewLine & "<--------------------------------------------------------------->" & vbNewLine)
    End Sub
    Public Function LoginToInv(DataBlocks As List(Of String), User As String, Password As String) As Integer

        If DataBlocks.Count = 0 Then
            Return E_Handles.ERROR_DATA
        End If

        If Not User = DataBlocks(1) Then
            Return E_Handles.INVALID_USER
        End If

        If Not MD5StringHash(Password) = DataBlocks(2) Then

            Return E_Handles.WRONG_PASSWORD
        End If

        CurrentSessionHash = MD5StringHash(Password)
        CurrentUser = User
        LoggedIn = True
        timerWait = False
        cInventory = Nothing

        currentSaltKeyFile = DataBlocks(3)

        If Not IO.File.Exists(KeyBound & "\" & currentSaltKeyFile & ".key") Then
            Return E_Handles.INVALID_SALT
        End If

        If Not DataBlocks(4) = MD5StringHash(getSaltKey()) Then
            Return E_Handles.INVALID_SALT
        End If

        If DataBlocks(5).Trim = "" Then
            cInventory = New inventoryGroup
        Else
            Dim DEC_STR As String = ""
            Dim PRG As New progressed
            PRG.Show()

            For i As Integer = 5 To (DataBlocks.Count - 1)
                DEC_STR &= Decrypt(DataBlocks(i), Password)
                PRG.ProgressBar1.Value = (i / (DataBlocks.Count)) * 100
                PRG.Label1.Text = "Verarbeite Datenblock " & i & " von " & (DataBlocks.Count)
                PRG.Refresh()
            Next
            cInventory = Newtonsoft.Json.JsonConvert.DeserializeObject(Of inventoryGroup)(DEC_STR)
            PRG.Close()
        End If

        ReloadTree()


        Return E_Handles.SUCCESS
    End Function
    Public Function getSaltKey() As String

        Dim inp As New IO.StreamReader(KeyBound & "\" & currentSaltKeyFile & ".key")
        Return inp.ReadToEnd

    End Function
    Public Sub SaveChanges()
        If CurrentFile = "" Then Exit Sub
        If IsNothing(cInventory) Then Exit Sub
        Dim SVRDATA As String = Newtonsoft.Json.JsonConvert.SerializeObject(cInventory)
        If SVRDATA = "" Then Exit Sub
        Dim efl As New IO.StreamWriter(CurrentFile, False)

        Dim CNT As Integer = 0
        Dim LST As New List(Of String)
        Dim ENDSTR As String = ""
        Dim prg As New progressed
        prg.Show()
        Dim UPSCALE As Integer = 1 + (SVRDATA.Length / SAVE_BLOCK_SPLIT_SCALE)
        Dim blockCount As Integer = 0
        prg.Label1.Text = "Verarbeite Datenblock " & blockCount + 1
        For Each TP As Char In SVRDATA
            ENDSTR &= TP
            If CNT = SAVE_BLOCK_SPLIT_SCALE Then
                LST.Add(Encrypt(ENDSTR, ClearKey))
                ENDSTR = ""
                CNT = 0
                blockCount += 1
                prg.ProgressBar1.Value = (blockCount / UPSCALE) * 100
                prg.Label1.Text = "Verarbeite Datenblock " & blockCount + 1
                prg.Refresh()
            End If
            CNT += 1
        Next
        prg.Close()
        If ENDSTR <> "" Then
            LST.Add(Encrypt(ENDSTR, ClearKey))
            ENDSTR = ""
            CNT = 0
        End If
        Dim WRT_STRING As String = DB_VER & "||" & CurrentUser & "||" & CurrentSessionHash & "||" & currentSaltKeyFile & "||" & MD5StringHash(getSaltKey())

        If LST.Count = 0 Then
            WRT_STRING = DB_VER & "||" & CurrentUser & "||" & CurrentSessionHash & "||" & currentSaltKeyFile & "||" & MD5StringHash(getSaltKey()) & "||"

        Else
            prg = New progressed

            For Each L As String In LST
                WRT_STRING &= "||" & L

                prg.Label1.Text = "Speichere Datenblock " & CNT + 1
                CNT += 1
                prg.ProgressBar1.Value = (CNT / (LST.Count)) * 100
            Next
            prg.Close()
        End If


        efl.Write(WRT_STRING)
        efl.Close()
    End Sub
    Public Sub ReloadTree()
        mainwnd.ListBox1.Items.Clear()
        If IsNothing(cInventory) Then Exit Sub
        For Each P As cinventar In cInventory.InventarListe
            mainwnd.ListBox1.Items.Add(P.invenName)
        Next
    End Sub
    Public Function Encrypt(ByVal plainText As String, ByVal secretKey As String) As String
        Dim encryptedPassword As String = Nothing
        Using outputStream As MemoryStream = New MemoryStream()
            Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
            Using cryptoStream As CryptoStream = New CryptoStream(outputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write)
                Dim inputBuffer() As Byte = Encoding.Unicode.GetBytes(plainText)
                cryptoStream.Write(inputBuffer, 0, inputBuffer.Length)
                cryptoStream.FlushFinalBlock()
                encryptedPassword = Convert.ToBase64String(outputStream.ToArray())
            End Using
        End Using
        Return encryptedPassword
    End Function
    Public Function Decrypt(ByVal encryptedBytes As String, ByVal secretKey As String) As String
        Dim plainText As String = Nothing
        Using inputStream As MemoryStream = New MemoryStream(Convert.FromBase64String(encryptedBytes))
            Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
            Using cryptoStream As CryptoStream = New CryptoStream(inputStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read)
                Dim outputBuffer(0 To CType(inputStream.Length - 1, Integer)) As Byte
                Dim readBytes As Integer = cryptoStream.Read(outputBuffer, 0, CType(inputStream.Length, Integer))
                plainText = Encoding.Unicode.GetString(outputBuffer, 0, readBytes)
            End Using
        End Using
        Return plainText
    End Function
    Private Function getAlgorithm(ByVal secretKey As String) As RijndaelManaged

        Const keySize As Integer = 256
        Dim keyBuilder As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(secretKey, Encoding.Unicode.GetBytes(getSaltKey()))
        Dim algorithm As RijndaelManaged = New RijndaelManaged()
        algorithm.KeySize = keySize
        algorithm.IV = keyBuilder.GetBytes(CType(algorithm.BlockSize / 8, Integer))
        algorithm.Key = keyBuilder.GetBytes(CType(algorithm.KeySize / 8, Integer))
        algorithm.Padding = PaddingMode.PKCS7
        Return algorithm
    End Function
    Public Function MD5StringHash(ByVal strString As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim Data As Byte()
        Dim Result As Byte()
        Dim Res As String = ""
        Dim Tmp As String = ""

        Data = Encoding.ASCII.GetBytes(strString)
        Result = MD5.ComputeHash(Data)
        For i As Integer = 0 To Result.Length - 1
            Tmp = Hex(Result(i))
            If Len(Tmp) = 1 Then Tmp = "0" & Tmp
            Res += Tmp
        Next
        Return Res
    End Function


    Public Function getUnID()
        Dim KEY As String = ""
        Dim SETGO As Boolean = False
        Dim FOUND As Boolean = False
        If IsNothing(cInventory) Then
            Return "FALSE"
        End If
        If IsNothing(cInventory.uniqueIDS) Then
            cInventory.uniqueIDS = New List(Of String)
            KEY = getUniqueID()
            cInventory.uniqueIDS.Add(KEY)
            SETGO = True
            Return KEY
        End If

        Do
            KEY = getUniqueID()
            For Each CINV As String In cInventory.uniqueIDS
                If KEY = CINV Then
                    FOUND = True
                    Exit For
                End If
            Next
            If FOUND Then
                SETGO = False
                FOUND = False
            Else
                SETGO = True
            End If
        Loop While Not SETGO
        Return KEY
    End Function
    Public Function getUniqueID()
        Dim KeyGen As RandomKeyGenerator
        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghijklmnopqrstuvwxyz"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 18
        Return KeyGen.Generate()
    End Function


    Public Function getFileKey()
        Dim KeyGen As RandomKeyGenerator
        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghijklmnopqrstuvwxyz"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 12
        Return KeyGen.Generate()
    End Function

    Public Function showMessageEx(Content As String, Title As String, Optional TypeX As S_STYLES = S_STYLES.SINFO, Optional details As Boolean = False, Optional detailText As String = "") As DialogResult
        Dim ns As New errorLog
        ns.Text = Title
        ns.Label1.Text = Content
        ns.sStyle = TypeX
        ns.TextBox1.Text = detailText
        ns.showDetails = details
        Return ns.ShowDialog
    End Function
    Public Function lookforinventory(Articlenum As String, Optional justLocal As Boolean = False, Optional invenName As String = "") As Integer
        Dim COUNT As Integer = 0
        For Each P As cinventar In cInventory.InventarListe
            If justLocal Then
                If P.invenName = invenName Then
                    For Each T As artikel In P.ArtikelEintrag
                        If T.artikelnummer = Articlenum Then
                            COUNT += T.Bestand
                        End If
                    Next
                End If
                Exit For
            Else
                For Each T As artikel In P.ArtikelEintrag
                    If T.artikelnummer = Articlenum Then
                        COUNT += T.Bestand
                    End If
                Next
            End If
        Next
        Return COUNT
    End Function

    Public Sub importCSV(Filename As String, Inventare As List(Of String))

    End Sub

    Public Function selectfromlistwindow(Title As String, Items As List(Of String)) As String
        Dim nSelect As New ListSelector
        nSelect.Text = Title
        For Each J As String In Items
            nSelect.ListBox1.Items.Add(J)
        Next
        nSelect.ShowDialog()
        If nSelect.DialogResult = DialogResult.OK Then Return nSelect.ListBox1.Text Else Return ""

    End Function
    Public Sub CleanUpCSV(Filename As String, Output As String, Optional Columns As Integer = -1)

        On Error Resume Next
        If Not IO.File.Exists(Filename) Then Exit Sub
        Dim OPT As String = ""
        Dim ROWS As New List(Of String)
        Dim IOX As New IO.StreamReader(Filename)
        Dim INP As New StringBuilder
        INP.Append(IOX.ReadToEnd)
        IOX.Close()

        ROWS.AddRange(INP.ToString.Split(vbCrLf))

        For Each T As String In ROWS
            Dim COLS As New List(Of String)
            COLS.AddRange(T.Split(";"))
            Dim InnerCount As Integer = 0
            For Each P As String In COLS

                If Columns = -1 Then
                    If P.Trim <> "" Then

                        OPT &= (P.Trim & ";")


                    End If
                Else
                    InnerCount += 1
                    OPT &= (P.Trim & ";")
                    If InnerCount = Columns Then Exit For
                End If

            Next
            If OPT.EndsWith(";") Then OPT = OPT.Substring(0, (OPT.Length) - 1)
            OPT &= vbCrLf

        Next

        Dim IOP As New StreamWriter(Output)
        IOP.Write(OPT)
        IOP.Close()

    End Sub


    Public Function exMakePaste(_PasteCode As String, _PasteName As String, _Syntax As String, _PasteExposure As String) As String


        Dim chiavi As New NameValueCollection()
        chiavi.Add("api_dev_key", xDEV_KEY)
        chiavi.Add("api_paste_code", _PasteCode)
        chiavi.Add("api_paste_name", _PasteName)
        chiavi.Add("api_paste_format", _Syntax)
        chiavi.Add("api_paste_private", _PasteExposure)
        chiavi.Add("api_paste_expire_date", "N")

        Dim wc As New WebClient()
        Dim Risultato As String = ""
        Dim Risposta As String = Encoding.UTF8.GetString(wc.UploadValues(
                                                         "https://pastebin.com/api/api_post.php", chiavi))

        If Risposta.ToLower.Contains("bad api request") Then
            ' Key non valida
        Else
            Risultato = Risposta
        End If
        Return Risultato
    End Function


    Public Sub CheckLicense(Optional ByVal longCheck As Boolean = True)
        If GetSetting("INVEN_APP", "LICENSE", "NAME") = "" Then
            showMessageEx("inVen benötigt eine gültige Lizenz zur Nutzung. Diese kann beim Entwickler angefordert werden. Falls eine Lizenz vorliegt kann Diese im nächsten Dialog eingegeben werden.", "Achtung.", S_STYLES.SWARNING)
            If Lic.ShowDialog() = DialogResult.Abort Then
                showMessageEx("Das Programm kann ohne gültige Lizenz nicht verwendet werden.", "Fehler...", S_STYLES.SERROR)
                End
            End If
        Else
            Dim tHSH As String = MD5StringHash(GetSetting("INVEN_APP", "LICENSE", "NAME") & GetSetting("INVEN_APP", "LICENSE", "KEY")).ToLower

            If Not tHSH = GetSetting("INVEN_APP", "LICENSE", "HASH") Then
                showMessageEx("Ungültiger Lizenzschlüssel, bitte erneuere deine Eingaben.", "Fehler...", S_STYLES.SERROR)
                If Lic.ShowDialog() = DialogResult.Abort Then
                    showMessageEx("Das Programm kann ohne gültige Lizenz nicht verwendet werden.", "Fehler...", S_STYLES.SERROR)
                    End
                End If
            End If
            If longCheck Then
                If Not HaveInternetConnection() Then

                    showMessageEx("Es wird eine Internetverbindung für die Nutzung von inVen benötigt.", "Fehler...", S_STYLES.SERROR)
                    End

                Else

                    Dim webq As New Net.WebClient
                    Dim req As String = webq.DownloadString("https://drive.google.com/uc?export=download&id=1sNFQqbZJF94tllYgyAlXmvJoSPRIg8P7")
                    Dim lns As New List(Of String)
                    lns.AddRange(req.Split(vbNewLine))

                    Dim fnd As Boolean = False
                    For Each L As String In lns

                        If L = GetSetting("INVEN_APP", "LICENSE", "HASH") Then
                            fnd = True
                            Exit For

                        End If

                    Next
                    If Not fnd Then
                        showMessageEx("Lizenz wurde nicht mehr gefunden", "Fehler...", S_STYLES.SERROR)
                        If Lic.ShowDialog() = DialogResult.Abort Then
                            showMessageEx("Das Programm kann ohne gültige Lizenz nicht verwendet werden.", "Fehler...", S_STYLES.SERROR)
                            End
                        End If
                    End If

                End If
            End If
        End If
    End Sub
    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function
End Module
