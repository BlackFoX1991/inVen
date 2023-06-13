
Public Class xCSVFile

    Public ErrorLog As String = ""
    Public Structure Columns
        Dim value As List(Of String)
    End Structure
    Public Structure csv_file
        Dim haveHeaders As Boolean
        Dim ValueUbound As Integer
        Dim Headers As List(Of String)
        Dim Rows As List(Of Columns)
    End Structure
    Public csv_container As csv_file
    ''' <summary>
    ''' Lädt eine CSV Datei, wird die erste Linie als Kopfspalte deklariert so werden alle Spalten die nach den Kopfspalten kommen ignoriert.
    ''' </summary>
    ''' <param name="eFile"></param>
    ''' <param name="FirstLineAreHeaders"></param>
    Public Sub New(eFile As String, Optional FirstLineAreHeaders As Boolean = False, Optional IgnoreEmptyHeaders As Boolean = True)

        If Not IO.File.Exists(eFile) Then Exit Sub

        csv_container = New csv_file
        Dim LineCount As Integer = -1
        csv_container.Rows = New List(Of Columns)

        Dim CountOfHeaders As Integer = -1
        Dim iox As New IO.StreamReader(eFile)
        csv_container.haveHeaders = FirstLineAreHeaders

        Do While Not iox.EndOfStream

            Dim nItem As New Columns
            nItem.value = New List(Of String)

            Dim ColCount As Integer = -1
            LineCount += 1
            Dim LN As String = iox.ReadLine
            Dim SPL As New List(Of String)
            If LN.Contains(";") Then SPL.AddRange(LN.Split(";")) Else SPL.AddRange(LN.Split(","))

            If FirstLineAreHeaders Then

                If LineCount = 0 Then
                    csv_container.Headers = New List(Of String)
                    For Each T As String In SPL

                        If Not IgnoreEmptyHeaders Then
                            If T.Trim <> "" Then
                                csv_container.Headers.Add(T.Trim)
                                CountOfHeaders += 1
                            End If
                        Else

                            CountOfHeaders += 1
                            csv_container.Headers.Add("Header " & CountOfHeaders)
                        End If
                    Next
                    GoTo LP
                End If

            End If

            For Each T As String In SPL
                If CountOfHeaders > -1 Then
                    If Not ColCount >= CountOfHeaders Then nItem.value.Add(T)
                Else
                    nItem.value.Add(T)
                End If
                ColCount += 1
            Next
            If nItem.value.Count > csv_container.ValueUbound Then csv_container.ValueUbound = nItem.value.Count
            csv_container.Rows.Add(nItem)


LP:
        Loop



        iox.Close()


    End Sub

    Public Sub SaveCSVToFile(Filename As String, CSVContainer As csv_file)
        On Error Resume Next
        Dim IPX As String = ""

        For Each H As String In csv_container.Headers
            IPX &= H & ","
        Next
        IPX = IPX.Substring(0, IPX.Length - 1)
        IPX &= vbCrLf

        For Each C As Columns In csv_container.Rows

            For Each V As String In C.value

                IPX &= V & ","

            Next
            IPX = IPX.Substring(0, IPX.Length - 1)
            IPX &= vbCrLf
        Next

        Dim IOX As New IO.StreamWriter(Filename)
        IOX.Write(IPX)
        IOX.Close()


    End Sub


End Class
