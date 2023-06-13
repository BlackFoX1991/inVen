<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dbdatensatz
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dbdatensatz))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pDesc = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pGroup = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pColor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pPrice = New System.Windows.Forms.NumericUpDown()
        Me.pImage = New System.Windows.Forms.PictureBox()
        Me.pSave = New System.Windows.Forms.Button()
        Me.pCancel = New System.Windows.Forms.Button()
        Me.importCon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BildImportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.pPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.importCon.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.pImage)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(454, 305)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pDesc)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(446, 101)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Produkt-Beschreibung"
        '
        'pDesc
        '
        Me.pDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pDesc.Location = New System.Drawing.Point(3, 16)
        Me.pDesc.Multiline = True
        Me.pDesc.Name = "pDesc"
        Me.pDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.pDesc.Size = New System.Drawing.Size(440, 82)
        Me.pDesc.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(159, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 195)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Allgemeine Infos"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.pID)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.pGroup)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.pColor)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.pPrice)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(284, 176)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Produkt ID"
        '
        'pID
        '
        Me.pID.Location = New System.Drawing.Point(3, 19)
        Me.pID.Name = "pID"
        Me.pID.Size = New System.Drawing.Size(278, 22)
        Me.pID.TabIndex = 1
        Me.pID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Produkt-Gruppen ID"
        '
        'pGroup
        '
        Me.pGroup.Location = New System.Drawing.Point(3, 63)
        Me.pGroup.Name = "pGroup"
        Me.pGroup.Size = New System.Drawing.Size(278, 22)
        Me.pGroup.TabIndex = 3
        Me.pGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Farbe/ Spezifikation"
        '
        'pColor
        '
        Me.pColor.Location = New System.Drawing.Point(3, 107)
        Me.pColor.Name = "pColor"
        Me.pColor.Size = New System.Drawing.Size(278, 22)
        Me.pColor.TabIndex = 5
        Me.pColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Preis"
        '
        'pPrice
        '
        Me.pPrice.DecimalPlaces = 2
        Me.pPrice.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.pPrice.Location = New System.Drawing.Point(3, 151)
        Me.pPrice.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.pPrice.Name = "pPrice"
        Me.pPrice.Size = New System.Drawing.Size(278, 22)
        Me.pPrice.TabIndex = 7
        Me.pPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pPrice.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
        '
        'pImage
        '
        Me.pImage.BackColor = System.Drawing.Color.White
        Me.pImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pImage.ContextMenuStrip = Me.importCon

        Me.pImage.Location = New System.Drawing.Point(6, 32)
        Me.pImage.Name = "pImage"
        Me.pImage.Size = New System.Drawing.Size(150, 150)
        Me.pImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pImage.TabIndex = 0
        Me.pImage.TabStop = False
        '
        'pSave
        '
        Me.pSave.Location = New System.Drawing.Point(378, 323)
        Me.pSave.Name = "pSave"
        Me.pSave.Size = New System.Drawing.Size(88, 23)
        Me.pSave.TabIndex = 1
        Me.pSave.Text = "Speichern"
        Me.pSave.UseVisualStyleBackColor = True
        '
        'pCancel
        '
        Me.pCancel.Location = New System.Drawing.Point(284, 323)
        Me.pCancel.Name = "pCancel"
        Me.pCancel.Size = New System.Drawing.Size(88, 23)
        Me.pCancel.TabIndex = 2
        Me.pCancel.Text = "Abbrechen"
        Me.pCancel.UseVisualStyleBackColor = True
        '
        'importCon
        '
        Me.importCon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BildImportierenToolStripMenuItem})
        Me.importCon.Name = "importCon"
        Me.importCon.ShowImageMargin = False
        Me.importCon.Size = New System.Drawing.Size(156, 48)
        '
        'BildImportierenToolStripMenuItem
        '
        Me.BildImportierenToolStripMenuItem.Name = "BildImportierenToolStripMenuItem"
        Me.BildImportierenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.BildImportierenToolStripMenuItem.Text = "Bild importieren"
        '
        'dbdatensatz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 354)
        Me.Controls.Add(Me.pCancel)
        Me.Controls.Add(Me.pSave)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dbdatensatz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datensatz ansehen/ bearbeiten/ Neu anlegen..."
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.pPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.importCon.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pImage As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents pID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pGroup As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents pDesc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pColor As TextBox
    Friend WithEvents pSave As Button
    Friend WithEvents pCancel As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents pPrice As NumericUpDown
    Friend WithEvents importCon As ContextMenuStrip
    Friend WithEvents BildImportierenToolStripMenuItem As ToolStripMenuItem
End Class
