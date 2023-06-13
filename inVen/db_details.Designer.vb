<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class db_details
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(db_details))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblDatabaseVer = New System.Windows.Forms.Label()
        Me.lblKey = New System.Windows.Forms.Label()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.author_textbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.desc_textbox = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.stammContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeueDatenAnlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkierteDatenLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenAnsehenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MarkiertenDatensatzBearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.stammContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.lblName)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblDatabaseVer)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblKey)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblAuthor)
        Me.FlowLayoutPanel1.Controls.Add(Me.author_textbox)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.desc_textbox)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(506, 175)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(3, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(66, 19)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name : "
        '
        'lblDatabaseVer
        '
        Me.lblDatabaseVer.AutoSize = True
        Me.lblDatabaseVer.Location = New System.Drawing.Point(3, 19)
        Me.lblDatabaseVer.Name = "lblDatabaseVer"
        Me.lblDatabaseVer.Size = New System.Drawing.Size(193, 19)
        Me.lblDatabaseVer.TabIndex = 2
        Me.lblDatabaseVer.Text = "Datenbank Version : DBI_"
        '
        'lblKey
        '
        Me.lblKey.AutoSize = True
        Me.lblKey.Location = New System.Drawing.Point(3, 38)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(89, 19)
        Me.lblKey.TabIndex = 6
        Me.lblKey.Text = "Schlüssel : "
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Location = New System.Drawing.Point(3, 57)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(74, 19)
        Me.lblAuthor.TabIndex = 3
        Me.lblAuthor.Text = "Author : "
        '
        'author_textbox
        '
        Me.author_textbox.Location = New System.Drawing.Point(3, 79)
        Me.author_textbox.Name = "author_textbox"
        Me.author_textbox.Size = New System.Drawing.Size(490, 27)
        Me.author_textbox.TabIndex = 4
        Me.author_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 19)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Beschreibung :"
        '
        'desc_textbox
        '
        Me.desc_textbox.Location = New System.Drawing.Point(3, 131)
        Me.desc_textbox.Name = "desc_textbox"
        Me.desc_textbox.Size = New System.Drawing.Size(490, 27)
        Me.desc_textbox.TabIndex = 5
        Me.desc_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.ContextMenuStrip = Me.stammContext
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 236)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(506, 277)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Beschreibung"
        Me.ColumnHeader2.Width = 129
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Farbe/Spezifikation"
        Me.ColumnHeader3.Width = 132
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 4
        Me.ColumnHeader4.Text = "ID-Gruppe"
        Me.ColumnHeader4.Width = 85
        '
        'stammContext
        '
        Me.stammContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeueDatenAnlegenToolStripMenuItem, Me.MarkiertenDatensatzBearbeitenToolStripMenuItem, Me.MarkierteDatenLöschenToolStripMenuItem, Me.ToolStripSeparator1, Me.DatenAnsehenToolStripMenuItem})
        Me.stammContext.Name = "stammContext"
        Me.stammContext.ShowImageMargin = False
        Me.stammContext.Size = New System.Drawing.Size(229, 98)
        '
        'NeueDatenAnlegenToolStripMenuItem
        '
        Me.NeueDatenAnlegenToolStripMenuItem.Name = "NeueDatenAnlegenToolStripMenuItem"
        Me.NeueDatenAnlegenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.NeueDatenAnlegenToolStripMenuItem.Text = "Neue Daten anlegen"
        '
        'MarkierteDatenLöschenToolStripMenuItem
        '
        Me.MarkierteDatenLöschenToolStripMenuItem.Name = "MarkierteDatenLöschenToolStripMenuItem"
        Me.MarkierteDatenLöschenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.MarkierteDatenLöschenToolStripMenuItem.Text = "Markierten Datensatz löschen"
        '
        'DatenAnsehenToolStripMenuItem
        '
        Me.DatenAnsehenToolStripMenuItem.Name = "DatenAnsehenToolStripMenuItem"
        Me.DatenAnsehenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DatenAnsehenToolStripMenuItem.Text = "Daten ansehen"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(506, 28)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Datenbank- Stammdaten"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 3
        Me.ColumnHeader5.Text = "Preis ( stk. )"
        Me.ColumnHeader5.Width = 91
        '
        'MarkiertenDatensatzBearbeitenToolStripMenuItem
        '
        Me.MarkiertenDatensatzBearbeitenToolStripMenuItem.Name = "MarkiertenDatensatzBearbeitenToolStripMenuItem"
        Me.MarkiertenDatensatzBearbeitenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.MarkiertenDatensatzBearbeitenToolStripMenuItem.Text = "Markierten Datensatz bearbeiten..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'db_details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 523)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "db_details"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Eigenschaften von <...>"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.stammContext.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lblName As Label
    Friend WithEvents lblDatabaseVer As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents lblKey As Label
    Friend WithEvents author_textbox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents desc_textbox As TextBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Label6 As Label
    Friend WithEvents stammContext As ContextMenuStrip
    Friend WithEvents NeueDatenAnlegenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarkierteDatenLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatenAnsehenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents MarkiertenDatensatzBearbeitenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
