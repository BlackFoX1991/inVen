Imports Newtonsoft.Json

Public Class cinventar
    Public Property invenName As String
    Public Property Key As String
    Public Property invenBeschreibung As String

    <JsonProperty("ArtikelEintrag")>
    Public Property ArtikelEintrag As List(Of artikel)
    Public Sub New()
        ArtikelEintrag = New List(Of artikel)
    End Sub
End Class
