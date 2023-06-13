' Dieser Quellcode stammt von http://www.activevb.de
' und kann frei verwendet werden. Für eventuelle Schäden
' wird nicht gehaftet.

' Um Fehler oder Fragen zu klären, nutzen Sie bitte unser Forum.
' Ansonsten viel Spaß und Erfolg mit diesem Source!

' Projektversion:   Visual Studio 2005
' Option Strict:    An
'
' Referenzen: 
'  - System
'  - System.Data
'  - System.Deployment
'  - System.Drawing
'  - System.Windows.Forms
'  - System.Xml
'
' Imports: 
'  - Microsoft.VisualBasic
'  - System
'  - System.Collections
'  - System.Collections.Generic
'  - System.Data
'  - System.Drawing
'  - System.Diagnostics
'  - System.Windows.Forms
'

' ##############################################################################
' ############################ clsListviewPrint.vb #############################
' ##############################################################################
Imports System.Drawing.Printing

Public Class clsListviewPrint

    Public Structure PrinterMarginsS
        Public MarginLeft As Single
        Public MarginTop As Single
        Public MarginRight As Single
        Public MarginBottom As Single

        Public Sub New(ByVal mLeft As Single, ByVal mTop As Single,
                       ByVal mRight As Single, ByVal mBottom As Single)
            MarginLeft = mLeft
            MarginTop = mTop
            MarginRight = mRight
            MarginBottom = mBottom
        End Sub
    End Structure

    Private Lvw As ListView
    Private m_HeaderText As String
    Private m_Landscape As Boolean = False
    Private m_PrinterName As String
    Private m_Copies As Integer = 1
    Private m_PrinterMargins As New PrinterMarginsS(20, 30, 10, 20)
    Private m_Preview As Boolean = False
    Private m_ListviewAlignCenter As Boolean = False
    Private m_DateFormat As String = "dd.MM.yyyy"
    Private m_PrintDate As Boolean = True
    Private m_HeaderAlignCenter As Boolean = True
    Private m_ListDate As Date = Date.Now
    Private m_PageNoAlignCenter As Boolean = False
    Private MMFaktor As Single = 0.254

    'Dokumentenobject zum Druck
    Private WithEvents Doc As New PrintDocument
    'Druckvorschau
    Private WithEvents PrnPreview As New PrintPreviewDialog
    'Klasse für Druckausgabe
    Private cPrint As clsPrinter

    Private xPos() As Single               'horizontale Positionierung
    Private yPos() As Single               'vertikale Positionierung
    Private Br As Brush = Brushes.Black    'Druckfarbe schwarz
    Private P As New Pen(Color.Gray, 0.2)  'Ausgabe Lines
    Private PageNumber As Int32            'für SeitenNummerung
    Private RowNumber As Int32             'als Zeilenzähler bei mehreren Seiten

    'Definition der benötigten Fonts
    Private FtLvw As Font
    Private m_FontFoot As New Font("Arial", 8, FontStyle.Regular)
    Private m_FontHeader As New Font("Arial", 14, FontStyle.Bold)
    Private m_ForeColorHeader As Color = Color.Black
    Private m_ForeColorFoot As Color = Color.Black

    ''' <summary>
    ''' Seitennummerung zentriert andrucken, Default = False (rechtsbündig)
    ''' </summary>
    Public Property PageNoAlignCenter() As Boolean
        Get
            Return m_PageNoAlignCenter
        End Get
        Set(ByVal value As Boolean)
            m_PageNoAlignCenter = value
        End Set
    End Property

    ''' <summary>
    ''' Header zentriert über dem Listview anordnen, Default = True
    ''' </summary>
    Public Property HeaderAlignCenter() As Boolean
        Get
            Return m_HeaderAlignCenter
        End Get
        Set(ByVal value As Boolean)
            m_HeaderAlignCenter = value
        End Set
    End Property

    ''' <summary>
    ''' Font für den Header, Default = Arial, 14, Bold
    ''' </summary>
    Public Property FontHeader() As Font
        Get
            Return m_FontHeader
        End Get
        Set(ByVal value As Font)
            m_FontHeader = value
        End Set
    End Property

    ''' <summary>
    ''' Font für den Fuss mit Datum und PageNo, Default = Arial, 8, Regular
    ''' </summary>
    Public Property FontFoot() As Font
        Get
            Return m_FontFoot
        End Get
        Set(ByVal value As Font)
            m_FontFoot = value
        End Set
    End Property

    ''' <summary>
    ''' ForeColor für den Header, Default = Black
    ''' </summary>
    Public Property ForeColorHeader() As Color
        Get
            Return m_ForeColorHeader
        End Get
        Set(ByVal value As Color)
            m_ForeColorHeader = value
        End Set
    End Property

    ''' <summary>
    ''' ForeColor für den Fuss mit Datum und Seite, Default = Black
    ''' </summary>
    Public Property ForeColorFoot() As Color
        Get
            Return m_ForeColorFoot
        End Get
        Set(ByVal value As Color)
            m_ForeColorFoot = value
        End Set
    End Property

    ''' <summary>
    ''' Datum im Fuss, Default = date.Now
    ''' </summary>
    Public Property ListDate() As Date
        Get
            Return m_ListDate
        End Get
        Set(ByVal value As Date)
            m_ListDate = value
        End Set
    End Property

    ''' <summary>
    ''' Datum im Fuss andrucken, Default = True
    ''' </summary>
    Public Property Printdate() As Boolean
        Get
            Return m_PrintDate
        End Get
        Set(ByVal value As Boolean)
            m_PrintDate = value
        End Set
    End Property

    ''' <summary>
    ''' Format für das Datum im Fuss, Default = dd.MM.yyyy
    ''' </summary>
    Public Property DateFormat() As String
        Get
            Return m_DateFormat
        End Get
        Set(ByVal value As String)
            m_DateFormat = value
        End Set
    End Property

    ''' <summary>
    ''' Listview zentriert anordnen, Default = False
    ''' </summary>
    Public Property ListviewAlignCenter() As Boolean
        Get
            Return m_ListviewAlignCenter
        End Get
        Set(ByVal value As Boolean)
            m_ListviewAlignCenter = value
        End Set
    End Property

    ''' <summary>
    ''' Name/Bezeichnung Drucker, Default = Standarddrucker
    ''' </summary>
    Public Property PrinterName() As String
        Get
            Return m_PrinterName
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(m_PrinterName) Then
                Dim PS As New PrinterSettings
                m_PrinterName = PS.PrinterName
            End If
            m_PrinterName = value
        End Set
    End Property

    ''' <summary>
    ''' Ausgabe am Bildschirm als Druckvorschau, Default = False
    ''' </summary>
    Public Property Preview() As Boolean
        Get
            Return m_Preview
        End Get
        Set(ByVal value As Boolean)
            m_Preview = value
        End Set
    End Property

    ''' <summary>
    ''' Anzahl Kopien, Default = 1
    ''' </summary>
    Public Property Copies() As Integer
        Get
            Return m_Copies
        End Get
        Set(ByVal value As Integer)
            m_Copies = value
        End Set
    End Property

    ''' <summary>
    ''' Überschrift/Header
    ''' </summary>
    Public Property HeaderText() As String
        Get
            Return m_HeaderText
        End Get
        Set(ByVal value As String)
            m_HeaderText = value
        End Set
    End Property

    ''' <summary>
    ''' Druckausgabe Quer, Default = false
    ''' </summary>
    Public Property Landscape() As Boolean
        Get
            Return m_Landscape
        End Get
        Set(ByVal value As Boolean)
            m_Landscape = value
        End Set
    End Property

    ''' <summary>
    ''' Ränder links, oben, rechts, unten
    ''' </summary>
    Public Property PrinterMargins() As PrinterMarginsS
        Get
            Return m_PrinterMargins
        End Get
        Set(ByVal value As PrinterMarginsS)
            m_PrinterMargins = value
        End Set
    End Property

    ''' <summary>
    ''' Übergabe von Recordset, Listview etc
    ''' </summary>
    Public Sub New(ByVal mLvw As ListView,
                   Optional ByVal mHeaderText As String = Nothing)

        'Listview übergeben und Überschrift
        Lvw = mLvw
        FtLvw = Lvw.Font
        If Not String.IsNullOrEmpty(mHeaderText) Then
            HeaderText = mHeaderText
        End If
        PrnPreview.ShowIcon = False
    End Sub

    ''' <summary>
    ''' Druckausgabe starten
    ''' </summary>
    Public Sub Print(Optional ByVal mPrinterName As String = Nothing)

        'Name des Dokuments für Druckerauswahl und Warteschlange
        Doc.DocumentName = mPrinterName

        'festlegen Printername, Copies, Hoch/Quer
        If Not String.IsNullOrEmpty(mPrinterName) Then
            Doc.DefaultPageSettings.PrinterSettings.PrinterName = PrinterName
        Else
            Doc.DefaultPageSettings.PrinterSettings.PrinterName = m_PrinterName
        End If
        Doc.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(Copies)
        Doc.DefaultPageSettings.Landscape = Landscape

        'Init Class mit LeftMargin, TopMargin, MaxHeight
        cPrint = New clsPrinter(Doc, PrinterMargins.MarginLeft,
                                PrinterMargins.MarginTop, 0)
        With PrinterMargins
            cPrint.MaxHeight = cPrint.PageHeight - (.MarginTop + .MarginBottom)
        End With

        'und ausgeben
        If Preview Then
            PrnPreview.Document = Doc
            PrnPreview.ShowDialog()
        Else
            Doc.Print()
        End If
    End Sub

    ''' <summary>
    ''' Zoom 100% und Maximize
    ''' </summary>
    Private Sub PrnPreview_Load(ByVal sender As Object,
            ByVal e As System.EventArgs) Handles PrnPreview.Load
        PrnPreview.Icon = My.Resources._47005_box_inventory_icon
        PrnPreview.WindowState = FormWindowState.Maximized
        PrnPreview.PrintPreviewControl.Zoom = 1.0
        PrnPreview.PrintPreviewControl.AutoZoom = False

    End Sub

    ''' <summary>
    ''' Beginn Drucken, Pagenumber + Rownumber auf Null, SetPositionen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Doc_BeginPrint(ByVal sender As Object,
            ByVal e As System.Drawing.Printing.PrintEventArgs) _
            Handles Doc.BeginPrint

        PageNumber = 0
        RowNumber = 0
        SetPositionen()
    End Sub

    ''' <summary>
    ''' horizontale und vertikale Positionen Init
    ''' </summary>
    Private Sub SetPositionen()

        ReDim xPos(50)    'Positionen horizontal
        xPos(0) = 0       'linker Rand
        For i As Integer = 0 To Lvw.Columns.Count - 1
            'Breite der Spalten umrechnen in MM (* 0.254) plus 1 mm
            xPos(i + 1) += xPos(i) + (Lvw.Columns(i).Width * MMFaktor) + 2
        Next

        If ListviewAlignCenter Then
            cPrint.LeftMargin = (cPrint.PageWidth - xPos(Lvw.Columns.Count)) / 2
        End If

        ReDim yPos(50)    'Positionen vertikal
        yPos(0) = 0       'oberer Rand, Überschrift
        yPos(20) = 10     'Beginn Body
        yPos(30) = cPrint.MaxHeight + 5  'Datum und Page
    End Sub

    ''' <summary>
    ''' Druck Seite
    ''' </summary>
    Private Sub Doc_PrintPage(ByVal sender As Object,
            ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
            Handles Doc.PrintPage

        Dim Gr As Graphics = e.Graphics
        Gr.PageUnit = GraphicsUnit.Millimeter

        'Zeilenhöhe einer Line
        Dim LineHeight As Single =
            Gr.MeasureString("x", FtLvw).Height + Convert.ToSingle(1.8)

        'aktuelle y Position
        Dim y As Single = yPos(0)

        'Anfang und Ende der horizontalen Linien
        Dim yA As Single = 0
        Dim yE As Single = 0

        'Beginn Druck, Header ausgeben
        PrintHeader(Gr, y, yA)

        'höchste Zeile festlegen
        Dim MaxRow As Integer = Lvw.Items.Count - 1

        'Zeilen durchlaufen
        Dim i As Integer
        For i = RowNumber To MaxRow
            'Drucken bis maximal xx cm vertikal
            If (y + LineHeight) >= cPrint.MaxHeight Then
                'Mehrseitendruck anstossen
                e.HasMorePages = True
                Exit For
            End If

            'Ausgabe Zeile
            PrintRow(Gr, y, yE)
            RowNumber += 1
        Next

        'vertikale Linien zeichnen
        For i = 0 To Lvw.Columns.Count
            cPrint.DrawLine(Gr, P, xPos(i), yA, xPos(i), yE)
        Next

        'Datum und Seitennummer
        Using Br As New SolidBrush(ForeColorFoot)
            y = yPos(30)
            Dim s As String = Date.Now.ToString(DateFormat)
            cPrint.PrintLeft(s, Gr, FontFoot, Br, xPos(0) + 1, y)

            s = "Seite  " & PageNumber.ToString
            If PageNoAlignCenter Then
                cPrint.PrintCenter(s, Gr, FontFoot, Br,
                                   xPos(Lvw.Columns.Count) / 2, y)
            Else
                cPrint.PrintRight(s, Gr, FontFoot, Br,
                    xPos(Lvw.Columns.Count) - Convert.ToSingle(0.5), y)
            End If
        End Using

        'abfragen auf Druckende
        If i > MaxRow Then
            e.HasMorePages = False
        End If

        Gr = Nothing
    End Sub

    ''' <summary>
    ''' Ausgabe ListviewItem
    ''' </summary>
    Private Sub PrintRow(ByVal Gr As Graphics, ByRef y As Single,
                         ByRef yE As Single)


        On Error Resume Next
        Dim s As String = Nothing

        Dim Li As ListViewItem = Lvw.Items(RowNumber)

        y += 1
        Dim w As Single = (Lvw.Columns(0).Width * MMFaktor)
        For i As Integer = 0 To Lvw.Columns.Count - 1
            Using B As New SolidBrush(Li.SubItems(i).ForeColor)

                s = Li.SubItems(i).Text
                w = xPos(i + 1) - xPos(i)

                For o As Single = (y) To (y + 5) Step 1


                    cPrint.DrawLine(Gr, New Pen(Li.SubItems(i).BackColor), xPos(i), o, xPos(Lvw.Columns.Count), o)

                Next


                If Lvw.Columns(i).TextAlign = HorizontalAlignment.Right Then
                    cPrint.PrintRight(s, Gr, FtLvw, B,
                        xPos(i + 1) - Convert.ToSingle(0.5), y, w)
                ElseIf Lvw.Columns(i).TextAlign = HorizontalAlignment.Center Then
                    Dim x As Single = xPos(i) + (xPos(i + 1) - xPos(i)) / 2
                    cPrint.PrintCenter(s, Gr, FtLvw, B, x, y, w)
                Else
                    cPrint.PrintLeft(s, Gr, FtLvw, B, xPos(i) + 1, y, w)
                End If
            End Using
        Next

        Dim y2 As Single = Gr.MeasureString("x", FontFoot).Height
        y += Gr.MeasureString("x", FtLvw).Height + Convert.ToSingle(0.8)
        cPrint.DrawLine(Gr, P, xPos(0), y, xPos(Lvw.Columns.Count), y)
        yE = y
    End Sub

    ''' <summary>
    ''' Ausgabe eines Headers
    ''' </summary>
    Private Sub PrintHeader(ByVal Gr As Graphics, ByRef y As Single,
                            ByRef yA As Single)

        'Grundstellung
        y = yPos(0)
        Dim s As String = Nothing

        PageNumber += 1

        s = HeaderText
        Using B As New SolidBrush(ForeColorHeader)
            Dim x As Single = xPos(0)
            If HeaderAlignCenter Then
                cPrint.PrintCenter(s, Gr, FontHeader, B,
                                   xPos(Lvw.Columns.Count) / 2, y)
            Else
                cPrint.PrintLeft(s, Gr, FontHeader, B, xPos(0), y)
            End If
        End Using

        y = yPos(20)
        cPrint.DrawLine(Gr, P, xPos(0), y, xPos(Lvw.Columns.Count), y)
        yA = y
        y += 1

        For i As Integer = 0 To Lvw.Columns.Count - 1
            s = Lvw.Columns(i).Text
            If Lvw.Columns(i).TextAlign = HorizontalAlignment.Right Then
                cPrint.PrintRight(s, Gr, FtLvw, Br,
                                  xPos(i + 1) - Convert.ToSingle(0.5), y)
            ElseIf Lvw.Columns(i).TextAlign = HorizontalAlignment.Center Then
                Dim x As Single = xPos(i) + (xPos(i + 1) - xPos(i)) / 2
                cPrint.PrintCenter(s, Gr, FtLvw, Br, x, y)
            Else
                cPrint.PrintLeft(s, Gr, FtLvw, Br, xPos(i) + 1, y)
            End If
        Next

        y += Gr.MeasureString("x", FtLvw).Height + Convert.ToSingle(0.8)
        cPrint.DrawLine(Gr, P, xPos(0), y, xPos(Lvw.Columns.Count), y)
    End Sub
End Class

' ##############################################################################
' ############################### clsPrinter.vb ################################
' ##############################################################################


''' <summary>
''' Routinen für die Druckersteuerung
''' </summary>
''' <remarks></remarks>
Public Class clsPrinter

    Private m_Doc As PrintDocument
    Private m_LeftMargin As Single
    Private m_TopMargin As Single
    Private m_MaxHeight As Single
    Private m_HardX As Single
    Private m_HardY As Single
    Private MMFaktor As Single = 0.254

    ''' <summary>
    ''' Linker Seitenrand
    ''' </summary>
    Public Property LeftMargin() As Single
        Get
            LeftMargin = m_LeftMargin
        End Get
        Set(ByVal value As Single)
            m_LeftMargin = value
        End Set
    End Property

    ''' <summary>
    ''' oberer Seitenrand
    ''' </summary>
    Public Property TopMargin() As Single
        Get
            TopMargin = m_TopMargin
        End Get
        Set(ByVal value As Single)
            m_TopMargin = value
        End Set
    End Property

    ''' <summary>
    ''' maximale Seitenhöhe ab TopMargin
    ''' </summary>
    Public Property MaxHeight() As Single
        Get
            MaxHeight = m_MaxHeight
        End Get
        Set(ByVal value As Single)
            m_MaxHeight = value
        End Set
    End Property

    ''' <summary>
    ''' liefert den physikalischen Seitenrand links
    ''' </summary>
    Public ReadOnly Property HardX() As Single
        Get
            HardX = m_HardX
        End Get
    End Property

    ''' <summary>
    ''' liefert den physikalischen Seitenrand oben
    ''' </summary>
    Public Property HardY() As Single
        Get
            HardY = m_HardY
        End Get
        Set(ByVal value As Single)

        End Set
    End Property

    ''' <summary>
    ''' Initialize Class
    ''' </summary>
    Public Sub New(ByVal Doc As PrintDocument,
                   ByVal mLeftMargin As Single,
                   ByVal mTopMargin As Single,
                   ByVal mMaxHeight As Single)

        m_Doc = Doc
        'physikalische Druckränder ermitteln
        m_HardX = Doc.DefaultPageSettings.HardMarginX * MMFaktor
        m_HardY = Doc.DefaultPageSettings.HardMarginY * MMFaktor
        m_LeftMargin = mLeftMargin
        m_TopMargin = mTopMargin
        m_MaxHeight = mMaxHeight
    End Sub

    ''' <summary>
    ''' Drucken String Linksbündig
    ''' </summary>
    Public Sub PrintLeft(ByVal s As String, ByVal Gr As Graphics,
                         ByVal Ft As Font, ByVal Br As Brush,
                         ByVal X As Single, ByVal Y As Single,
                         Optional ByVal MaxWidth As Single = 0)

        Dim x1 As Single = LeftMargin + X - HardX
        Dim y1 As Single = TopMargin + Y - HardY

        If MaxWidth > 0 Then
            If Gr.MeasureString(s, Ft).Width > MaxWidth Then
                Do While (Gr.MeasureString(s & "..", Ft).Width > MaxWidth)
                    s = s.Substring(0, s.Length - 1)
                Loop
                s = s & ".."
            End If
        End If
        Gr.DrawString(s, Ft, Br, x1, y1)
    End Sub

    ''' <summary>
    ''' Drucken String Rechtsbündig
    ''' </summary>
    Public Sub PrintRight(ByVal s As String, ByVal Gr As Graphics,
                          ByVal Ft As Font, ByVal Br As Brush,
                          ByVal X As Single, ByVal Y As Single,
                          Optional ByVal MaxWidth As Single = 0)

        Dim x1 As Single = LeftMargin + X - HardX -
                           Gr.MeasureString(s, Ft).Width
        Dim y1 As Single = TopMargin + Y - HardY

        If MaxWidth > 0 Then
            If Gr.MeasureString(s, Ft).Width > MaxWidth Then
                Do While (Gr.MeasureString(s & "..", Ft).Width > MaxWidth)
                    s = s.Substring(1)
                Loop
                s = ".." & s
            End If
        End If
        Gr.DrawString(s, Ft, Br, x1, y1)
    End Sub

    ''' <summary>
    ''' Drucken String Zentriert
    ''' </summary>
    Public Sub PrintCenter(ByVal s As String, ByVal Gr As Graphics,
                           ByVal Ft As Font, ByVal Br As Brush,
                           ByVal X As Single, ByVal Y As Single,
                           Optional ByVal MaxWidth As Single = 0)

        Dim x1 As Single = LeftMargin + X - HardX -
                           (Gr.MeasureString(s, Ft).Width / 2)
        Dim y1 As Single = TopMargin + Y - HardY

        If MaxWidth > 0 Then
            If Gr.MeasureString(s, Ft).Width > MaxWidth Then
                Do While (Gr.MeasureString(s & "..", Ft).Width > MaxWidth)
                    s = s.Substring(0, s.Length - 1)
                Loop
                s = s & ".."
            End If
        End If
        Gr.DrawString(s, Ft, Br, x1, y1)
    End Sub

    Public Sub PrintRotate90(ByVal s As String, ByVal Gr As Graphics,
                             ByVal Ft As Font, ByVal Br As Brush,
                             ByVal X As Single, ByVal Y As Single,
                             Optional ByVal MaxWidth As Single = 0)

        If MaxWidth > 0 Then
            If Gr.MeasureString(s, Ft).Width > MaxWidth Then
                Do While (Gr.MeasureString(s & "..", Ft).Width > MaxWidth)
                    s = s.Substring(0, s.Length - 1)
                Loop
                s = s & ".."
            End If
        End If

        Dim x1 As Single = LeftMargin + X - HardX +
                           Gr.MeasureString(s, Ft).Height
        Dim y1 As Single = TopMargin + Y - HardY

        Gr.TranslateTransform(x1, y1)
        Gr.RotateTransform(90)
        Gr.DrawString(s, Ft, Br, 0, 0)

        Gr.RotateTransform(270)
        Gr.TranslateTransform(x1 * -1, y1 * -1)
    End Sub


    ''' <summary>
    ''' Drucken String um 180 Grad gespiegelt
    ''' </summary>
    Public Sub PrintRotate180(ByVal s As String, ByVal Gr As Graphics,
                              ByVal Ft As Font, ByVal Br As Brush,
                              ByVal X As Single, ByVal Y As Single,
                              Optional ByVal MaxWidth As Single = 0)

        If MaxWidth > 0 Then
            If Gr.MeasureString(s, Ft).Width > MaxWidth Then
                Do While (Gr.MeasureString(s & "..", Ft).Width > MaxWidth)
                    s = s.Substring(0, s.Length - 1)
                Loop
                s = s & ".."
            End If
        End If

        Dim x1 As Single = LeftMargin + X - HardX +
                           Gr.MeasureString(s, Ft).Width
        Dim y1 As Single = TopMargin + Y - HardY +
                           Gr.MeasureString(s, Ft).Height

        Gr.TranslateTransform(x1, y1)
        Gr.RotateTransform(180)
        Gr.DrawString(s, Ft, Br, 0, 0)

        Gr.RotateTransform(180)
        Gr.TranslateTransform(-x1, -y1)
    End Sub

    Public Sub PrintRotate270(ByVal s As String, ByVal Gr As Graphics,
                              ByVal Ft As Font, ByVal Br As Brush,
                              ByVal X As Single, ByVal Y As Single,
                              Optional ByVal MaxWidth As Single = 0)

        If MaxWidth > 0 Then
            If Gr.MeasureString(s, Ft).Width > MaxWidth Then
                Do While (Gr.MeasureString(s & "..", Ft).Width > MaxWidth)
                    s = s.Substring(0, s.Length - 1)
                Loop
                s = s & ".."
            End If
        End If

        Dim x1 As Single = LeftMargin + X - HardX
        Dim y1 As Single = TopMargin + Y - HardY +
                           Gr.MeasureString(s, Ft).Width

        Gr.TranslateTransform(x1, y1)
        Gr.RotateTransform(270)
        Gr.DrawString(s, Ft, Br, 0, 0)

        Gr.RotateTransform(90)
        Gr.TranslateTransform(x1 * -1, y1 * -1)
    End Sub


    ''' <summary>
    ''' eine Line zeichnen
    ''' </summary>
    Public Sub DrawLine(ByVal Gr As Graphics, ByVal P As Pen,
                        ByVal x1 As Single, ByVal y1 As Single,
                        ByVal x2 As Single, ByVal y2 As Single)

        x1 = x1 + LeftMargin - HardX
        x2 = x2 + LeftMargin - HardX
        y1 = y1 + TopMargin - HardY
        y2 = y2 + TopMargin - HardY
        Gr.DrawLine(P, x1, y1, x2, y2)
    End Sub

    ''' <summary>
    ''' ein Rechteck zeichen
    ''' </summary>
    Public Sub DrawRectangle(ByVal Gr As Graphics, ByVal P As Pen,
                             ByVal x As Single, ByVal y As Single,
                             ByVal Width As Single, ByVal Height As Single)

        Dim GU As GraphicsUnit = Gr.PageUnit

        Gr.PageUnit = GraphicsUnit.Display

        Dim x1 As Single = x + LeftMargin - HardX
        Dim y1 As Single = y + TopMargin - HardY
        Dim x2 As Integer = Convert.ToInt32(x1 / MMFaktor)
        Dim y2 As Integer = Convert.ToInt32(y1 / MMFaktor)
        Dim w1 As Integer = Convert.ToInt32(Width / MMFaktor)
        Dim h1 As Integer = Convert.ToInt32(Height / MMFaktor)

        Dim Rect As New System.Drawing.Rectangle(x2, y2, w1, h1)
        Gr.DrawRectangle(P, Rect)
        Gr.PageUnit = GU
    End Sub

    ''' <summary>
    ''' eine gefüllte Box zeichnen
    ''' </summary>
    Public Sub DrawBox(ByVal Gr As Graphics, ByVal x As Single,
                       ByVal y As Single, ByVal Width As Single,
                       ByVal Height As Single, ByVal BackColor As Brush)

        Dim x1 As Single = x + LeftMargin - HardX
        Dim y1 As Single = y + TopMargin - HardY
        Dim R As New RectangleF(x1, y1, Width, Height)

        Gr.FillRectangle(BackColor, R)
    End Sub

    Public Sub DrawBox(ByVal Gr As Graphics, ByVal x As Single,
                       ByVal y As Single, ByVal Width As Single,
                       ByVal Height As Single, ByVal BackColor As Brush,
                       ByVal BorderWidth As Single, ByVal BorderColor As Color)

        Dim x1 As Single = x + LeftMargin - HardX
        Dim y1 As Single = y + TopMargin - HardY
        Dim P As New Pen(BorderColor, BorderWidth)

        DrawBox(Gr, x, y, Width, Height, BackColor)

        Gr.DrawRectangle(P, x1, y1, Width, Height)
    End Sub

    Public Function PageHeight() As Single
        Return m_Doc.DefaultPageSettings.Bounds.Height * MMFaktor
    End Function

    Public Function PageWidth() As Single
        Return m_Doc.DefaultPageSettings.Bounds.Width * MMFaktor
    End Function
End Class