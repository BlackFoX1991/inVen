<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainwnd
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainwnd))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NeuToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ErsatzlieferscheinGenerierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EigenschaftenDerDatenbankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TreeContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuesInventarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarUmbenennenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SperrenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnUnlock = New System.Windows.Forms.Button()
        Me.LOCKLIST = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.hArtikelNr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hBestand = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hGesamt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hLager = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hUID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ArtikelEinspeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BestandÄndernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PositionLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ArtikelAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblRes = New System.Windows.Forms.Label()
        Me.tSearchBar = New System.Windows.Forms.TextBox()
        Me.consoleContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LogSpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerlaufLeerenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.checkUp = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TreeContext.SuspendLayout()
        Me.ListContext.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.consoleContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripButton, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripSeparator1, Me.ToolStripSplitButton1, Me.ToolStripSeparator2, Me.ToolStripButton8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(900, 55)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NeuToolStripButton
        '
        Me.NeuToolStripButton.AutoSize = False
        Me.NeuToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NeuToolStripButton.Image = CType(resources.GetObject("NeuToolStripButton.Image"), System.Drawing.Image)
        Me.NeuToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NeuToolStripButton.Name = "NeuToolStripButton"
        Me.NeuToolStripButton.Size = New System.Drawing.Size(32, 32)
        Me.NeuToolStripButton.Text = "&Neu"
        Me.NeuToolStripButton.ToolTipText = "Neues Inventar anlegen"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.CheckOnClick = True
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton1.Text = "Suchmodus aktivieren"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton2.Text = "Abmelden/ Benutzer wechseln"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.AutoSize = False
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton3.Text = "Änderungern Speichern"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.AutoSize = False
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton4.Text = "Importieren"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.AutoSize = False
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton5.Text = "Export"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.AutoSize = False
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton6.Text = "schnelle Ausbuchung"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.AutoSize = False
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton7.Text = "Artikelliste drucken"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.AutoSize = False
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErsatzlieferscheinGenerierenToolStripMenuItem, Me.EigenschaftenDerDatenbankToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(44, 32)
        Me.ToolStripSplitButton1.Text = "Tools"
        Me.ToolStripSplitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripSplitButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        Me.ToolStripSplitButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ErsatzlieferscheinGenerierenToolStripMenuItem
        '
        Me.ErsatzlieferscheinGenerierenToolStripMenuItem.Name = "ErsatzlieferscheinGenerierenToolStripMenuItem"
        Me.ErsatzlieferscheinGenerierenToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.ErsatzlieferscheinGenerierenToolStripMenuItem.Text = "Ersatzlieferschein generieren"
        '
        'EigenschaftenDerDatenbankToolStripMenuItem
        '
        Me.EigenschaftenDerDatenbankToolStripMenuItem.Name = "EigenschaftenDerDatenbankToolStripMenuItem"
        Me.EigenschaftenDerDatenbankToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.EigenschaftenDerDatenbankToolStripMenuItem.Text = "Eigenschaften der Datenbank..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(36, 52)
        Me.ToolStripButton8.Text = "Über..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 592)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(900, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnUnlock)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(900, 537)
        Me.SplitContainer1.SplitterDistance = 271
        Me.SplitContainer1.TabIndex = 3
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.TreeContext
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(271, 537)
        Me.ListBox1.TabIndex = 0
        '
        'TreeContext
        '
        Me.TreeContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuesInventarToolStripMenuItem, Me.InventarLöschenToolStripMenuItem, Me.InventarUmbenennenToolStripMenuItem, Me.SperrenToolStripMenuItem})
        Me.TreeContext.Name = "TreeContext"
        Me.TreeContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TreeContext.ShowImageMargin = False
        Me.TreeContext.Size = New System.Drawing.Size(219, 92)
        '
        'NeuesInventarToolStripMenuItem
        '
        Me.NeuesInventarToolStripMenuItem.Name = "NeuesInventarToolStripMenuItem"
        Me.NeuesInventarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NeuesInventarToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.NeuesInventarToolStripMenuItem.Text = "Neues Inventar anlegen"
        '
        'InventarLöschenToolStripMenuItem
        '
        Me.InventarLöschenToolStripMenuItem.Name = "InventarLöschenToolStripMenuItem"
        Me.InventarLöschenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.InventarLöschenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.InventarLöschenToolStripMenuItem.Text = "Inventar löschen"
        '
        'InventarUmbenennenToolStripMenuItem
        '
        Me.InventarUmbenennenToolStripMenuItem.Name = "InventarUmbenennenToolStripMenuItem"
        Me.InventarUmbenennenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.InventarUmbenennenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.InventarUmbenennenToolStripMenuItem.Text = "Inventar umbenennen"
        '
        'SperrenToolStripMenuItem
        '
        Me.SperrenToolStripMenuItem.Name = "SperrenToolStripMenuItem"
        Me.SperrenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SperrenToolStripMenuItem.Text = "Inventar sperren"
        '
        'btnUnlock
        '
        Me.btnUnlock.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUnlock.ImageIndex = 0
        Me.btnUnlock.ImageList = Me.LOCKLIST
        Me.btnUnlock.Location = New System.Drawing.Point(0, 479)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(625, 58)
        Me.btnUnlock.TabIndex = 4
        Me.btnUnlock.Text = "(Gesperrt) Hier klicken für Passworteingabe"
        Me.btnUnlock.UseVisualStyleBackColor = True
        Me.btnUnlock.Visible = False
        '
        'LOCKLIST
        '
        Me.LOCKLIST.ImageStream = CType(resources.GetObject("LOCKLIST.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LOCKLIST.TransparentColor = System.Drawing.Color.Transparent
        Me.LOCKLIST.Images.SetKeyName(0, "2537363_protection_safety_security_shield_icon.png")
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.hArtikelNr, Me.hName, Me.hBestand, Me.hGesamt, Me.hLager, Me.hUID})
        Me.ListView1.ContextMenuStrip = Me.ListContext
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 117)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(625, 420)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'hArtikelNr
        '
        Me.hArtikelNr.Text = "Artikel Nummer"
        Me.hArtikelNr.Width = 100
        '
        'hName
        '
        Me.hName.Text = "Beschreibung"
        Me.hName.Width = 133
        '
        'hBestand
        '
        Me.hBestand.Text = "Bestand"
        Me.hBestand.Width = 77
        '
        'hGesamt
        '
        Me.hGesamt.Text = "Gesamtbestand"
        Me.hGesamt.Width = 120
        '
        'hLager
        '
        Me.hLager.Text = "Lagerplatz"
        Me.hLager.Width = 102
        '
        'hUID
        '
        Me.hUID.Text = "Buchungs ID"
        Me.hUID.Width = 124
        '
        'ListContext
        '
        Me.ListContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArtikelEinspeichernToolStripMenuItem, Me.BestandÄndernToolStripMenuItem, Me.PositionLöschenToolStripMenuItem, Me.ToolStripMenuItem2, Me.ArtikelAnzeigenToolStripMenuItem})
        Me.ListContext.Name = "ListContext"
        Me.ListContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ListContext.ShowImageMargin = False
        Me.ListContext.Size = New System.Drawing.Size(154, 98)
        '
        'ArtikelEinspeichernToolStripMenuItem
        '
        Me.ArtikelEinspeichernToolStripMenuItem.Name = "ArtikelEinspeichernToolStripMenuItem"
        Me.ArtikelEinspeichernToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ArtikelEinspeichernToolStripMenuItem.Text = "Artikel einspeichern"
        '
        'BestandÄndernToolStripMenuItem
        '
        Me.BestandÄndernToolStripMenuItem.Name = "BestandÄndernToolStripMenuItem"
        Me.BestandÄndernToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.BestandÄndernToolStripMenuItem.Text = "Menge entnehmen"
        '
        'PositionLöschenToolStripMenuItem
        '
        Me.PositionLöschenToolStripMenuItem.Name = "PositionLöschenToolStripMenuItem"
        Me.PositionLöschenToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.PositionLöschenToolStripMenuItem.Text = "Position löschen"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(150, 6)
        '
        'ArtikelAnzeigenToolStripMenuItem
        '
        Me.ArtikelAnzeigenToolStripMenuItem.Name = "ArtikelAnzeigenToolStripMenuItem"
        Me.ArtikelAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ArtikelAnzeigenToolStripMenuItem.Text = "Artikel Anzeigen"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lblRes)
        Me.GroupBox1.Controls.Add(Me.tSearchBar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(625, 117)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Suche ( Aktuelles Inventar )"
        Me.GroupBox1.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(12, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(261, 23)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Auf Groß/Kleinschreibung achten"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(458, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 27)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Artikel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblRes
        '
        Me.lblRes.AutoSize = True
        Me.lblRes.Location = New System.Drawing.Point(15, 57)
        Me.lblRes.Name = "lblRes"
        Me.lblRes.Size = New System.Drawing.Size(0, 19)
        Me.lblRes.TabIndex = 4
        '
        'tSearchBar
        '
        Me.tSearchBar.Location = New System.Drawing.Point(12, 84)
        Me.tSearchBar.Name = "tSearchBar"
        Me.tSearchBar.Size = New System.Drawing.Size(440, 27)
        Me.tSearchBar.TabIndex = 3
        '
        'consoleContext
        '
        Me.consoleContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogSpeichernToolStripMenuItem, Me.ToolStripMenuItem1, Me.KopierenToolStripMenuItem, Me.VerlaufLeerenToolStripMenuItem})
        Me.consoleContext.Name = "ContextMenuStrip1"
        Me.consoleContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.consoleContext.ShowImageMargin = False
        Me.consoleContext.Size = New System.Drawing.Size(176, 76)
        '
        'LogSpeichernToolStripMenuItem
        '
        Me.LogSpeichernToolStripMenuItem.Name = "LogSpeichernToolStripMenuItem"
        Me.LogSpeichernToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LogSpeichernToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.LogSpeichernToolStripMenuItem.Text = "Log Speichern..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(172, 6)
        '
        'KopierenToolStripMenuItem
        '
        Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
        Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.KopierenToolStripMenuItem.Text = "Kopieren"
        '
        'VerlaufLeerenToolStripMenuItem
        '
        Me.VerlaufLeerenToolStripMenuItem.Name = "VerlaufLeerenToolStripMenuItem"
        Me.VerlaufLeerenToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.VerlaufLeerenToolStripMenuItem.Text = "Verlauf löschen"
        '
        'checkUp
        '
        Me.checkUp.Enabled = True
        Me.checkUp.Interval = 800
        '
        'mainwnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 614)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mainwnd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "inVen Solution"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TreeContext.ResumeLayout(False)
        Me.ListContext.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.consoleContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents NeuToolStripButton As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents consoleContext As ContextMenuStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents checkUp As Timer
    Friend WithEvents LogSpeichernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents KopierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerlaufLeerenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TreeContext As ContextMenuStrip
    Friend WithEvents NeuesInventarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventarLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventarUmbenennenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListContext As ContextMenuStrip
    Friend WithEvents ArtikelEinspeichernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PositionLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents hArtikelNr As ColumnHeader
    Friend WithEvents hName As ColumnHeader
    Friend WithEvents hBestand As ColumnHeader
    Friend WithEvents hGesamt As ColumnHeader
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tSearchBar As TextBox
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents lblRes As Label
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents BestandÄndernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SperrenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnUnlock As Button
    Friend WithEvents LOCKLIST As ImageList
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents hUID As ColumnHeader
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents ErsatzlieferscheinGenerierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EigenschaftenDerDatenbankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents hLager As ColumnHeader
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ArtikelAnzeigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton8 As ToolStripButton
End Class
