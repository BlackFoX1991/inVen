
Imports Newtonsoft.Json

Public Class inventoryGroup


    Public Property uniqueIDS As List(Of String)
    <JsonProperty("InventarListe")>
    Public Property InventarListe As List(Of cinventar)
    Public Property Stammdaten As List(Of astamm)
    Public Property db_author As String
    Public Property db_desc As String

    Public Sub New()
        InventarListe = New List(Of cinventar)
        uniqueIDS = New List(Of String)
        Stammdaten = New List(Of astamm)
    End Sub
End Class
