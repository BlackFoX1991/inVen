Module modStammdaten


    Public Function NeueStammdaten(ID As String, groupID As String, productDesc As String, productColor As String, productPrice As Single, Optional edit As Boolean = False) As Boolean

        If Not edit Then
            If productExists(ID) Then
                Return False
            End If

            Dim aST As New astamm

            aST.ID_Nummer = ID
            aST.StammID = groupID
            aST.aBeschreibung = productDesc
            aST.aFarbe = productColor
            aST.preis = productPrice

            cInventory.Stammdaten.Add(aST)

            Return True
        Else
            If Not productExists(ID) Then
                Return False
            End If
            For Each T As astamm In cInventory.Stammdaten

                If T.ID_Nummer = ID Then

                    T.StammID = groupID
                    T.aBeschreibung = productDesc
                    T.aFarbe = productColor
                    T.preis = productPrice
                    Exit For
                End If

            Next
            Return True

        End If
    End Function
    ''' <summary>
    ''' 0 = Existiert nicht
    ''' 1 = Wurde gelöscht
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    Public Function StammdatenLoeschen(ID As String) As Boolean

        If Not productExists(ID) Then
            Return False
        End If

        Dim aST As astamm = Nothing
        For Each T As astamm In cInventory.Stammdaten

            If T.ID_Nummer = ID Then
                aST = T
                Exit For
            End If

        Next
        If Not IsNothing(aST) Then
            cInventory.Stammdaten.Remove(aST)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IDGruppeLöschen(groupID As String) As Boolean
        Dim aST As New List(Of astamm)
        For Each T As astamm In cInventory.Stammdaten
            If T.StammID = groupID Then aST.Add(T)
        Next
        If aST.Count = 0 Then
            Return False
        Else
            For i = 0 To (aST.Count - 1)
                cInventory.Stammdaten.Remove(aST(i))
            Next
            Return True
        End If
    End Function


    Public Function productExists(ID As String) As Boolean
        Dim pFound As Boolean = False
        For Each T As astamm In cInventory.Stammdaten
            If T.ID_Nummer.Trim = ID.Trim Then
                pFound = True
                Exit For
            End If
        Next
        Return pFound
    End Function


    Public Function getProductDesc(ID As String) As String
        Dim desc As String = "( Keine Beschreibung )"
        For Each T As astamm In cInventory.Stammdaten
            If T.ID_Nummer = ID Then
                desc = T.aBeschreibung & " - " & T.aFarbe
                Exit For
            End If
        Next
        Return desc
    End Function



End Module
