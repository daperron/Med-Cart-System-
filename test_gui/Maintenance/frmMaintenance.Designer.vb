<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintenance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintenance))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.radRecords = New System.Windows.Forms.RadioButton()
        Me.radDatabse = New System.Windows.Forms.RadioButton()
        Me.pnlRecords = New System.Windows.Forms.Panel()
        Me.radUser = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radPhysician = New System.Windows.Forms.RadioButton()
        Me.radPatient = New System.Windows.Forms.RadioButton()
        Me.radRoom = New System.Windows.Forms.RadioButton()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.pnlDatabase = New System.Windows.Forms.Panel()
        Me.btnRecords = New System.Windows.Forms.Button()
        Me.btnExportDatabase = New System.Windows.Forms.Button()
        Me.btnImportDatabase = New System.Windows.Forms.Button()
        Me.btnImportAsCopy = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.radDrawers = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.pnlRecords.SuspendLayout()
        Me.pnlDatabase.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlOptions)
        Me.Panel1.Controls.Add(Me.pnlRecords)
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(920, 461)
        Me.Panel1.TabIndex = 0
        '
        'pnlOptions
        '
        Me.pnlOptions.Controls.Add(Me.radRecords)
        Me.pnlOptions.Controls.Add(Me.radDatabse)
        Me.pnlOptions.Location = New System.Drawing.Point(583, 117)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(240, 100)
        Me.pnlOptions.TabIndex = 68
        '
        'radRecords
        '
        Me.radRecords.AutoSize = True
        Me.radRecords.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radRecords.Location = New System.Drawing.Point(12, 42)
        Me.radRecords.Name = "radRecords"
        Me.radRecords.Size = New System.Drawing.Size(143, 25)
        Me.radRecords.TabIndex = 67
        Me.radRecords.TabStop = True
        Me.radRecords.Text = "Import Records"
        Me.radRecords.UseVisualStyleBackColor = True
        '
        'radDatabse
        '
        Me.radDatabse.AutoSize = True
        Me.radDatabse.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDatabse.Location = New System.Drawing.Point(12, 11)
        Me.radDatabse.Name = "radDatabse"
        Me.radDatabse.Size = New System.Drawing.Size(205, 25)
        Me.radDatabse.TabIndex = 66
        Me.radDatabse.TabStop = True
        Me.radDatabse.Text = "Import/Export Database"
        Me.radDatabse.UseVisualStyleBackColor = True
        '
        'pnlRecords
        '
        Me.pnlRecords.Controls.Add(Me.radDrawers)
        Me.pnlRecords.Controls.Add(Me.radUser)
        Me.pnlRecords.Controls.Add(Me.Label1)
        Me.pnlRecords.Controls.Add(Me.radPhysician)
        Me.pnlRecords.Controls.Add(Me.radPatient)
        Me.pnlRecords.Controls.Add(Me.radRoom)
        Me.pnlRecords.Controls.Add(Me.btnUpload)
        Me.pnlRecords.Location = New System.Drawing.Point(0, 3)
        Me.pnlRecords.Name = "pnlRecords"
        Me.pnlRecords.Size = New System.Drawing.Size(360, 368)
        Me.pnlRecords.TabIndex = 67
        '
        'radUser
        '
        Me.radUser.AutoSize = True
        Me.radUser.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radUser.Location = New System.Drawing.Point(79, 203)
        Me.radUser.Name = "radUser"
        Me.radUser.Size = New System.Drawing.Size(118, 25)
        Me.radUser.TabIndex = 63
        Me.radUser.TabStop = True
        Me.radUser.Text = "User Record"
        Me.radUser.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 25)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Select Type Of Record to Import"
        '
        'radPhysician
        '
        Me.radPhysician.AutoSize = True
        Me.radPhysician.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPhysician.Location = New System.Drawing.Point(79, 108)
        Me.radPhysician.Name = "radPhysician"
        Me.radPhysician.Size = New System.Drawing.Size(151, 25)
        Me.radPhysician.TabIndex = 62
        Me.radPhysician.TabStop = True
        Me.radPhysician.Text = "Physician Record"
        Me.radPhysician.UseVisualStyleBackColor = True
        '
        'radPatient
        '
        Me.radPatient.AutoSize = True
        Me.radPatient.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPatient.Location = New System.Drawing.Point(79, 57)
        Me.radPatient.Name = "radPatient"
        Me.radPatient.Size = New System.Drawing.Size(136, 25)
        Me.radPatient.TabIndex = 58
        Me.radPatient.TabStop = True
        Me.radPatient.Text = "Patient Record"
        Me.radPatient.UseVisualStyleBackColor = True
        '
        'radRoom
        '
        Me.radRoom.AutoSize = True
        Me.radRoom.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radRoom.Location = New System.Drawing.Point(79, 156)
        Me.radRoom.Name = "radRoom"
        Me.radRoom.Size = New System.Drawing.Size(79, 25)
        Me.radRoom.TabIndex = 61
        Me.radRoom.TabStop = True
        Me.radRoom.Text = "Rooms"
        Me.radRoom.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnUpload.FlatAppearance.BorderSize = 0
        Me.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpload.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.ForeColor = System.Drawing.Color.White
        Me.btnUpload.Image = CType(resources.GetObject("btnUpload.Image"), System.Drawing.Image)
        Me.btnUpload.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpload.Location = New System.Drawing.Point(79, 295)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(158, 39)
        Me.btnUpload.TabIndex = 60
        Me.btnUpload.Text = "   Select File"
        Me.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'pnlDatabase
        '
        Me.pnlDatabase.Controls.Add(Me.btnRecords)
        Me.pnlDatabase.Controls.Add(Me.btnExportDatabase)
        Me.pnlDatabase.Controls.Add(Me.btnImportDatabase)
        Me.pnlDatabase.Controls.Add(Me.btnImportAsCopy)
        Me.pnlDatabase.Location = New System.Drawing.Point(3, 3)
        Me.pnlDatabase.Name = "pnlDatabase"
        Me.pnlDatabase.Size = New System.Drawing.Size(1150, 47)
        Me.pnlDatabase.TabIndex = 66
        '
        'btnRecords
        '
        Me.btnRecords.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecords.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecords.ForeColor = System.Drawing.Color.White
        Me.btnRecords.Image = CType(resources.GetObject("btnRecords.Image"), System.Drawing.Image)
        Me.btnRecords.Location = New System.Drawing.Point(601, 7)
        Me.btnRecords.Name = "btnRecords"
        Me.btnRecords.Size = New System.Drawing.Size(179, 38)
        Me.btnRecords.TabIndex = 188
        Me.btnRecords.Text = "IMPORT RECORDS"
        Me.btnRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRecords.UseVisualStyleBackColor = False
        '
        'btnExportDatabase
        '
        Me.btnExportDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnExportDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportDatabase.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportDatabase.ForeColor = System.Drawing.Color.White
        Me.btnExportDatabase.Image = CType(resources.GetObject("btnExportDatabase.Image"), System.Drawing.Image)
        Me.btnExportDatabase.Location = New System.Drawing.Point(809, 7)
        Me.btnExportDatabase.Name = "btnExportDatabase"
        Me.btnExportDatabase.Size = New System.Drawing.Size(197, 38)
        Me.btnExportDatabase.TabIndex = 187
        Me.btnExportDatabase.Text = "EXPORT DATABASE"
        Me.btnExportDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportDatabase.UseVisualStyleBackColor = False
        '
        'btnImportDatabase
        '
        Me.btnImportDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnImportDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportDatabase.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportDatabase.ForeColor = System.Drawing.Color.White
        Me.btnImportDatabase.Image = CType(resources.GetObject("btnImportDatabase.Image"), System.Drawing.Image)
        Me.btnImportDatabase.Location = New System.Drawing.Point(93, 7)
        Me.btnImportDatabase.Name = "btnImportDatabase"
        Me.btnImportDatabase.Size = New System.Drawing.Size(197, 38)
        Me.btnImportDatabase.TabIndex = 186
        Me.btnImportDatabase.Text = "IMPORT DATABASE"
        Me.btnImportDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportDatabase.UseVisualStyleBackColor = False
        '
        'btnImportAsCopy
        '
        Me.btnImportAsCopy.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnImportAsCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportAsCopy.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportAsCopy.ForeColor = System.Drawing.Color.White
        Me.btnImportAsCopy.Image = CType(resources.GetObject("btnImportAsCopy.Image"), System.Drawing.Image)
        Me.btnImportAsCopy.Location = New System.Drawing.Point(317, 7)
        Me.btnImportAsCopy.Name = "btnImportAsCopy"
        Me.btnImportAsCopy.Size = New System.Drawing.Size(257, 38)
        Me.btnImportAsCopy.TabIndex = 185
        Me.btnImportAsCopy.Text = "IMPORT DATABASE AS COPY"
        Me.btnImportAsCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportAsCopy.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'radDrawers
        '
        Me.radDrawers.AutoSize = True
        Me.radDrawers.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDrawers.Location = New System.Drawing.Point(79, 246)
        Me.radDrawers.Name = "radDrawers"
        Me.radDrawers.Size = New System.Drawing.Size(87, 25)
        Me.radDrawers.TabIndex = 64
        Me.radDrawers.TabStop = True
        Me.radDrawers.Text = "Drawers"
        Me.radDrawers.UseVisualStyleBackColor = True
        '
        'frmMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 645)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlDatabase)
        Me.Name = "frmMaintenance"
        Me.Text = "frmMaintenance"
        Me.Panel1.ResumeLayout(False)
        Me.pnlOptions.ResumeLayout(False)
        Me.pnlOptions.PerformLayout()
        Me.pnlRecords.ResumeLayout(False)
        Me.pnlRecords.PerformLayout()
        Me.pnlDatabase.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents radRecords As RadioButton
    Friend WithEvents radDatabse As RadioButton
    Friend WithEvents pnlRecords As Panel
    Friend WithEvents radUser As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents radPhysician As RadioButton
    Friend WithEvents radPatient As RadioButton
    Friend WithEvents radRoom As RadioButton
    Friend WithEvents btnUpload As Button
    Friend WithEvents pnlDatabase As Panel
    Friend WithEvents btnExportDatabase As Button
    Friend WithEvents btnImportDatabase As Button
    Friend WithEvents btnImportAsCopy As Button
    Friend WithEvents pnlOptions As Panel
    Friend WithEvents btnRecords As Button
    Friend WithEvents radDrawers As RadioButton
End Class
