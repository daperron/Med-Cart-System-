<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInventory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventory))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbDividerBin = New System.Windows.Forms.ComboBox()
        Me.cmbBin = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbMedicationName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboPersonalMedication = New System.Windows.Forms.ComboBox()
        Me.cmbPatientPersonalMedication = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDrawerUp = New System.Windows.Forms.Button()
        Me.btnDrawerDown = New System.Windows.Forms.Button()
        Me.btnQuantityDown = New System.Windows.Forms.Button()
        Me.btnQuantityUp = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMainLocation = New System.Windows.Forms.Panel()
        Me.pnlMainFormFields = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.mtbExpirationDate = New System.Windows.Forms.MaskedTextBox()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.cmbDrawerNumber = New System.Windows.Forms.ComboBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.cboSuggestedNames = New System.Windows.Forms.ComboBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtSchedule = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtStrength = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkControlled = New System.Windows.Forms.CheckBox()
        Me.chkNarcotic = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.pnlPatientName = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.pnlPatientNamePadding = New System.Windows.Forms.Panel()
        Me.cmbPatientNames = New System.Windows.Forms.ComboBox()
        Me.eprError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.tpSelectedItem = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlMainLocation.SuspendLayout()
        Me.pnlMainFormFields.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.pnlPatientName.SuspendLayout()
        Me.pnlPatientNamePadding.SuspendLayout()
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(242, 261)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 21)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Drawer Bin:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(477, 183)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 42)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Expiration Date:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Year-Month-Date)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(7, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 21)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Select from List:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.cmbDividerBin)
        Me.Panel4.Controls.Add(Me.cmbBin)
        Me.Panel4.Location = New System.Drawing.Point(245, 283)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel4.Size = New System.Drawing.Size(88, 31)
        Me.Panel4.TabIndex = 14
        '
        'cmbDividerBin
        '
        Me.cmbDividerBin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDividerBin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDividerBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDividerBin.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDividerBin.FormattingEnabled = True
        Me.cmbDividerBin.ItemHeight = 21
        Me.cmbDividerBin.Location = New System.Drawing.Point(1, 1)
        Me.cmbDividerBin.Name = "cmbDividerBin"
        Me.cmbDividerBin.Size = New System.Drawing.Size(86, 29)
        Me.cmbDividerBin.TabIndex = 14
        '
        'cmbBin
        '
        Me.cmbBin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBin.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBin.FormattingEnabled = True
        Me.cmbBin.Location = New System.Drawing.Point(1, 1)
        Me.cmbBin.Name = "cmbBin"
        Me.cmbBin.Size = New System.Drawing.Size(86, 29)
        Me.cmbBin.TabIndex = 50
        Me.cmbBin.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.cmbMedicationName)
        Me.Panel3.Location = New System.Drawing.Point(10, 83)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(651, 31)
        Me.Panel3.TabIndex = 3
        '
        'cmbMedicationName
        '
        Me.cmbMedicationName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbMedicationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedicationName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMedicationName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedicationName.FormattingEnabled = True
        Me.cmbMedicationName.Location = New System.Drawing.Point(1, 1)
        Me.cmbMedicationName.Name = "cmbMedicationName"
        Me.cmbMedicationName.Size = New System.Drawing.Size(649, 29)
        Me.cmbMedicationName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(477, 263)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 21)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = "Quantity:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(29, 45)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(213, 25)
        Me.Label17.TabIndex = 168
        Me.Label17.Text = "Drawer Configuration:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 336)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 21)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Patient Personal Medication:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.cboPersonalMedication)
        Me.Panel1.Controls.Add(Me.cmbPatientPersonalMedication)
        Me.Panel1.Location = New System.Drawing.Point(10, 360)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(200, 31)
        Me.Panel1.TabIndex = 18
        '
        'cboPersonalMedication
        '
        Me.cboPersonalMedication.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPersonalMedication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPersonalMedication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPersonalMedication.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPersonalMedication.FormattingEnabled = True
        Me.cboPersonalMedication.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboPersonalMedication.Location = New System.Drawing.Point(1, 1)
        Me.cboPersonalMedication.Name = "cboPersonalMedication"
        Me.cboPersonalMedication.Size = New System.Drawing.Size(198, 29)
        Me.cboPersonalMedication.TabIndex = 18
        '
        'cmbPatientPersonalMedication
        '
        Me.cmbPatientPersonalMedication.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPatientPersonalMedication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPatientPersonalMedication.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPatientPersonalMedication.FormattingEnabled = True
        Me.cmbPatientPersonalMedication.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbPatientPersonalMedication.Location = New System.Drawing.Point(1, 1)
        Me.cmbPatientPersonalMedication.Name = "cmbPatientPersonalMedication"
        Me.cmbPatientPersonalMedication.Size = New System.Drawing.Size(198, 29)
        Me.cmbPatientPersonalMedication.TabIndex = 60
        Me.cmbPatientPersonalMedication.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Image = Global.test_gui.My.Resources.Resources.resolve
        Me.btnSave.Location = New System.Drawing.Point(279, 72)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 38)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "   SAVE "
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDrawerUp
        '
        Me.btnDrawerUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDrawerUp.FlatAppearance.BorderSize = 0
        Me.btnDrawerUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDrawerUp.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrawerUp.ForeColor = System.Drawing.Color.White
        Me.btnDrawerUp.Image = CType(resources.GetObject("btnDrawerUp.Image"), System.Drawing.Image)
        Me.btnDrawerUp.Location = New System.Drawing.Point(70, 287)
        Me.btnDrawerUp.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDrawerUp.Name = "btnDrawerUp"
        Me.btnDrawerUp.Size = New System.Drawing.Size(27, 27)
        Me.btnDrawerUp.TabIndex = 12
        Me.btnDrawerUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDrawerUp.UseVisualStyleBackColor = False
        '
        'btnDrawerDown
        '
        Me.btnDrawerDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDrawerDown.FlatAppearance.BorderSize = 0
        Me.btnDrawerDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDrawerDown.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrawerDown.ForeColor = System.Drawing.Color.White
        Me.btnDrawerDown.Image = CType(resources.GetObject("btnDrawerDown.Image"), System.Drawing.Image)
        Me.btnDrawerDown.Location = New System.Drawing.Point(103, 287)
        Me.btnDrawerDown.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDrawerDown.Name = "btnDrawerDown"
        Me.btnDrawerDown.Size = New System.Drawing.Size(27, 27)
        Me.btnDrawerDown.TabIndex = 13
        Me.btnDrawerDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDrawerDown.UseVisualStyleBackColor = False
        '
        'btnQuantityDown
        '
        Me.btnQuantityDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnQuantityDown.FlatAppearance.BorderSize = 0
        Me.btnQuantityDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuantityDown.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuantityDown.ForeColor = System.Drawing.Color.White
        Me.btnQuantityDown.Image = CType(resources.GetObject("btnQuantityDown.Image"), System.Drawing.Image)
        Me.btnQuantityDown.Location = New System.Drawing.Point(572, 286)
        Me.btnQuantityDown.Margin = New System.Windows.Forms.Padding(2)
        Me.btnQuantityDown.Name = "btnQuantityDown"
        Me.btnQuantityDown.Size = New System.Drawing.Size(28, 27)
        Me.btnQuantityDown.TabIndex = 17
        Me.btnQuantityDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuantityDown.UseVisualStyleBackColor = False
        '
        'btnQuantityUp
        '
        Me.btnQuantityUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnQuantityUp.FlatAppearance.BorderSize = 0
        Me.btnQuantityUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuantityUp.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuantityUp.ForeColor = System.Drawing.Color.White
        Me.btnQuantityUp.Image = CType(resources.GetObject("btnQuantityUp.Image"), System.Drawing.Image)
        Me.btnQuantityUp.Location = New System.Drawing.Point(541, 286)
        Me.btnQuantityUp.Margin = New System.Windows.Forms.Padding(2)
        Me.btnQuantityUp.Name = "btnQuantityUp"
        Me.btnQuantityUp.Size = New System.Drawing.Size(27, 27)
        Me.btnQuantityUp.TabIndex = 16
        Me.btnQuantityUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuantityUp.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.txtQuantity)
        Me.Panel5.Location = New System.Drawing.Point(480, 286)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(49, 27)
        Me.Panel5.TabIndex = 15
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtQuantity.Location = New System.Drawing.Point(1, 1)
        Me.txtQuantity.MaxLength = 4
        Me.txtQuantity.Multiline = True
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ShortcutsEnabled = False
        Me.txtQuantity.Size = New System.Drawing.Size(47, 25)
        Me.txtQuantity.TabIndex = 15
        Me.txtQuantity.Text = "1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 203)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 21)
        Me.Label15.TabIndex = 186
        Me.Label15.Text = "Type:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(476, 130)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 21)
        Me.Label3.TabIndex = 188
        Me.Label3.Text = "Strength:"
        '
        'pnlMainLocation
        '
        Me.pnlMainLocation.Controls.Add(Me.pnlMainFormFields)
        Me.pnlMainLocation.Controls.Add(Me.Panel11)
        Me.pnlMainLocation.Controls.Add(Me.pnlPatientName)
        Me.pnlMainLocation.Location = New System.Drawing.Point(25, 72)
        Me.pnlMainLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMainLocation.Name = "pnlMainLocation"
        Me.pnlMainLocation.Size = New System.Drawing.Size(726, 553)
        Me.pnlMainLocation.TabIndex = 189
        '
        'pnlMainFormFields
        '
        Me.pnlMainFormFields.Controls.Add(Me.Label11)
        Me.pnlMainFormFields.Controls.Add(Me.Label8)
        Me.pnlMainFormFields.Controls.Add(Me.txtAmount)
        Me.pnlMainFormFields.Controls.Add(Me.Panel2)
        Me.pnlMainFormFields.Controls.Add(Me.txtUnits)
        Me.pnlMainFormFields.Controls.Add(Me.cmbDrawerNumber)
        Me.pnlMainFormFields.Controls.Add(Me.Panel8)
        Me.pnlMainFormFields.Controls.Add(Me.lblBarcode)
        Me.pnlMainFormFields.Controls.Add(Me.cboSuggestedNames)
        Me.pnlMainFormFields.Controls.Add(Me.Panel7)
        Me.pnlMainFormFields.Controls.Add(Me.Label7)
        Me.pnlMainFormFields.Controls.Add(Me.Panel6)
        Me.pnlMainFormFields.Controls.Add(Me.Panel10)
        Me.pnlMainFormFields.Controls.Add(Me.Panel9)
        Me.pnlMainFormFields.Controls.Add(Me.Label4)
        Me.pnlMainFormFields.Controls.Add(Me.chkControlled)
        Me.pnlMainFormFields.Controls.Add(Me.chkNarcotic)
        Me.pnlMainFormFields.Controls.Add(Me.Panel3)
        Me.pnlMainFormFields.Controls.Add(Me.btnQuantityUp)
        Me.pnlMainFormFields.Controls.Add(Me.Label9)
        Me.pnlMainFormFields.Controls.Add(Me.Label10)
        Me.pnlMainFormFields.Controls.Add(Me.btnQuantityDown)
        Me.pnlMainFormFields.Controls.Add(Me.Panel5)
        Me.pnlMainFormFields.Controls.Add(Me.Label6)
        Me.pnlMainFormFields.Controls.Add(Me.Label3)
        Me.pnlMainFormFields.Controls.Add(Me.Label2)
        Me.pnlMainFormFields.Controls.Add(Me.Label1)
        Me.pnlMainFormFields.Controls.Add(Me.Label15)
        Me.pnlMainFormFields.Controls.Add(Me.Panel4)
        Me.pnlMainFormFields.Controls.Add(Me.btnDrawerDown)
        Me.pnlMainFormFields.Controls.Add(Me.btnDrawerUp)
        Me.pnlMainFormFields.Controls.Add(Me.Label5)
        Me.pnlMainFormFields.Controls.Add(Me.Panel1)
        Me.pnlMainFormFields.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMainFormFields.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainFormFields.Name = "pnlMainFormFields"
        Me.pnlMainFormFields.Size = New System.Drawing.Size(726, 411)
        Me.pnlMainFormFields.TabIndex = 189
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(663, 342)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 21)
        Me.Label11.TabIndex = 215
        Me.Label11.Text = "Units:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(475, 341)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(167, 21)
        Me.Label8.TabIndex = 214
        Me.Label8.Text = "Amount Per Container:"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(479, 365)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ShortcutsEnabled = False
        Me.txtAmount.Size = New System.Drawing.Size(176, 25)
        Me.txtAmount.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.mtbExpirationDate)
        Me.Panel2.ForeColor = System.Drawing.Color.DarkGray
        Me.Panel2.Location = New System.Drawing.Point(480, 228)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(92, 24)
        Me.Panel2.TabIndex = 10
        '
        'mtbExpirationDate
        '
        Me.mtbExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mtbExpirationDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtbExpirationDate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mtbExpirationDate.Location = New System.Drawing.Point(1, 1)
        Me.mtbExpirationDate.Mask = "0000/00/00"
        Me.mtbExpirationDate.Name = "mtbExpirationDate"
        Me.mtbExpirationDate.ShortcutsEnabled = False
        Me.mtbExpirationDate.Size = New System.Drawing.Size(90, 22)
        Me.mtbExpirationDate.TabIndex = 10
        Me.mtbExpirationDate.ValidatingType = GetType(Date)
        '
        'txtUnits
        '
        Me.txtUnits.BackColor = System.Drawing.Color.White
        Me.txtUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnits.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnits.Location = New System.Drawing.Point(667, 365)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.ShortcutsEnabled = False
        Me.txtUnits.Size = New System.Drawing.Size(56, 25)
        Me.txtUnits.TabIndex = 20
        '
        'cmbDrawerNumber
        '
        Me.cmbDrawerNumber.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDrawerNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDrawerNumber.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDrawerNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDrawerNumber.FormattingEnabled = True
        Me.cmbDrawerNumber.ItemHeight = 21
        Me.cmbDrawerNumber.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        Me.cmbDrawerNumber.Location = New System.Drawing.Point(10, 285)
        Me.cmbDrawerNumber.Name = "cmbDrawerNumber"
        Me.cmbDrawerNumber.Size = New System.Drawing.Size(49, 29)
        Me.cmbDrawerNumber.TabIndex = 11
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Controls.Add(Me.txtBarcode)
        Me.Panel8.Location = New System.Drawing.Point(245, 226)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel8.Size = New System.Drawing.Size(175, 25)
        Me.Panel8.TabIndex = 9
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(1, 1)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBarcode.Multiline = True
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ShortcutsEnabled = False
        Me.txtBarcode.Size = New System.Drawing.Size(173, 23)
        Me.txtBarcode.TabIndex = 9
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarcode.Location = New System.Drawing.Point(241, 203)
        Me.lblBarcode.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(69, 21)
        Me.lblBarcode.TabIndex = 197
        Me.lblBarcode.Text = "Barcode:"
        '
        'cboSuggestedNames
        '
        Me.cboSuggestedNames.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSuggestedNames.FormattingEnabled = True
        Me.cboSuggestedNames.Location = New System.Drawing.Point(137, 48)
        Me.cboSuggestedNames.Name = "cboSuggestedNames"
        Me.cboSuggestedNames.Size = New System.Drawing.Size(524, 29)
        Me.cboSuggestedNames.TabIndex = 2
        Me.cboSuggestedNames.Visible = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGray
        Me.Panel7.Controls.Add(Me.txtType)
        Me.Panel7.Location = New System.Drawing.Point(10, 226)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel7.Size = New System.Drawing.Size(175, 25)
        Me.Panel7.TabIndex = 8
        '
        'txtType
        '
        Me.txtType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtType.Location = New System.Drawing.Point(1, 1)
        Me.txtType.Multiline = True
        Me.txtType.Name = "txtType"
        Me.txtType.ShortcutsEnabled = False
        Me.txtType.Size = New System.Drawing.Size(173, 23)
        Me.txtType.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(242, 132)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 21)
        Me.Label7.TabIndex = 195
        Me.Label7.Text = "Schedule:"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkGray
        Me.Panel6.Controls.Add(Me.txtSchedule)
        Me.Panel6.Location = New System.Drawing.Point(245, 155)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel6.Size = New System.Drawing.Size(176, 23)
        Me.Panel6.TabIndex = 6
        '
        'txtSchedule
        '
        Me.txtSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSchedule.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSchedule.Location = New System.Drawing.Point(1, 1)
        Me.txtSchedule.Multiline = True
        Me.txtSchedule.Name = "txtSchedule"
        Me.txtSchedule.ShortcutsEnabled = False
        Me.txtSchedule.Size = New System.Drawing.Size(174, 21)
        Me.txtSchedule.TabIndex = 6
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.DarkGray
        Me.Panel10.Controls.Add(Me.txtStrength)
        Me.Panel10.Location = New System.Drawing.Point(479, 152)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel10.Size = New System.Drawing.Size(168, 25)
        Me.Panel10.TabIndex = 7
        '
        'txtStrength
        '
        Me.txtStrength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStrength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStrength.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStrength.Location = New System.Drawing.Point(1, 1)
        Me.txtStrength.Multiline = True
        Me.txtStrength.Name = "txtStrength"
        Me.txtStrength.ShortcutsEnabled = False
        Me.txtStrength.Size = New System.Drawing.Size(166, 23)
        Me.txtStrength.TabIndex = 7
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DarkGray
        Me.Panel9.Controls.Add(Me.pnlSearch)
        Me.Panel9.Controls.Add(Me.txtSearch)
        Me.Panel9.Location = New System.Drawing.Point(10, 14)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel9.Size = New System.Drawing.Size(651, 25)
        Me.Panel9.TabIndex = 1
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.BackgroundImage = CType(resources.GetObject("pnlSearch.BackgroundImage"), System.Drawing.Image)
        Me.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearch.ForeColor = System.Drawing.Color.White
        Me.pnlSearch.Location = New System.Drawing.Point(608, 1)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(42, 23)
        Me.pnlSearch.TabIndex = 2
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(1, 1)
        Me.txtSearch.Multiline = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.ShortcutsEnabled = False
        Me.txtSearch.Size = New System.Drawing.Size(612, 23)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.Tag = "Search Medication by Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(6, 132)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 21)
        Me.Label4.TabIndex = 193
        Me.Label4.Text = "Medication Flag:"
        '
        'chkControlled
        '
        Me.chkControlled.AutoSize = True
        Me.chkControlled.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkControlled.Location = New System.Drawing.Point(109, 155)
        Me.chkControlled.Margin = New System.Windows.Forms.Padding(2)
        Me.chkControlled.Name = "chkControlled"
        Me.chkControlled.Size = New System.Drawing.Size(102, 25)
        Me.chkControlled.TabIndex = 5
        Me.chkControlled.Text = "Controlled"
        Me.chkControlled.UseVisualStyleBackColor = True
        '
        'chkNarcotic
        '
        Me.chkNarcotic.AutoSize = True
        Me.chkNarcotic.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNarcotic.Location = New System.Drawing.Point(10, 155)
        Me.chkNarcotic.Margin = New System.Windows.Forms.Padding(2)
        Me.chkNarcotic.Name = "chkNarcotic"
        Me.chkNarcotic.Size = New System.Drawing.Size(87, 25)
        Me.chkNarcotic.TabIndex = 4
        Me.chkNarcotic.Text = "Narcotic"
        Me.chkNarcotic.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(4, 261)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 21)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Drawer Number:"
        '
        'Panel11
        '
        Me.Panel11.Location = New System.Drawing.Point(622, 113)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(367, 100)
        Me.Panel11.TabIndex = 190
        '
        'pnlPatientName
        '
        Me.pnlPatientName.Controls.Add(Me.lblStatus)
        Me.pnlPatientName.Controls.Add(Me.txtStatus)
        Me.pnlPatientName.Controls.Add(Me.lblPatientName)
        Me.pnlPatientName.Controls.Add(Me.btnSave)
        Me.pnlPatientName.Controls.Add(Me.pnlPatientNamePadding)
        Me.pnlPatientName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPatientName.Location = New System.Drawing.Point(0, 413)
        Me.pnlPatientName.Name = "pnlPatientName"
        Me.pnlPatientName.Size = New System.Drawing.Size(726, 140)
        Me.pnlPatientName.TabIndex = 191
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(417, 89)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(55, 21)
        Me.lblStatus.TabIndex = 193
        Me.lblStatus.Text = "Status:"
        Me.lblStatus.Visible = False
        '
        'txtStatus
        '
        Me.txtStatus.HideSelection = False
        Me.txtStatus.Location = New System.Drawing.Point(421, 113)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(299, 20)
        Me.txtStatus.TabIndex = 192
        Me.txtStatus.Text = "System Status"
        Me.txtStatus.Visible = False
        '
        'lblPatientName
        '
        Me.lblPatientName.AutoSize = True
        Me.lblPatientName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatientName.Location = New System.Drawing.Point(7, 2)
        Me.lblPatientName.Name = "lblPatientName"
        Me.lblPatientName.Size = New System.Drawing.Size(60, 21)
        Me.lblPatientName.TabIndex = 191
        Me.lblPatientName.Text = "Patient:"
        '
        'pnlPatientNamePadding
        '
        Me.pnlPatientNamePadding.BackColor = System.Drawing.Color.DarkGray
        Me.pnlPatientNamePadding.Controls.Add(Me.cmbPatientNames)
        Me.pnlPatientNamePadding.Location = New System.Drawing.Point(9, 26)
        Me.pnlPatientNamePadding.Name = "pnlPatientNamePadding"
        Me.pnlPatientNamePadding.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlPatientNamePadding.Size = New System.Drawing.Size(421, 31)
        Me.pnlPatientNamePadding.TabIndex = 19
        '
        'cmbPatientNames
        '
        Me.cmbPatientNames.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPatientNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatientNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPatientNames.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPatientNames.FormattingEnabled = True
        Me.cmbPatientNames.Location = New System.Drawing.Point(1, 1)
        Me.cmbPatientNames.Name = "cmbPatientNames"
        Me.cmbPatientNames.Size = New System.Drawing.Size(419, 29)
        Me.cmbPatientNames.TabIndex = 19
        '
        'eprError
        '
        Me.eprError.ContainerControl = Me
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnBack)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(976, 42)
        Me.pnlHeader.TabIndex = 203
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBack.Location = New System.Drawing.Point(23, 6)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(105, 35)
        Me.btnBack.TabIndex = 61
        Me.btnBack.Text = "Back"
        Me.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'frmInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(976, 694)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlMainLocation)
        Me.Controls.Add(Me.Label17)
        Me.Name = "frmInventory"
        Me.Text = "frmInventory"
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlMainLocation.ResumeLayout(False)
        Me.pnlMainFormFields.ResumeLayout(False)
        Me.pnlMainFormFields.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.pnlPatientName.ResumeLayout(False)
        Me.pnlPatientName.PerformLayout()
        Me.pnlPatientNamePadding.ResumeLayout(False)
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbBin As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbMedicationName As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbPatientPersonalMedication As ComboBox
    Friend WithEvents btnDrawerUp As Button
    Friend WithEvents btnDrawerDown As Button
    Friend WithEvents btnQuantityDown As Button
    Friend WithEvents btnQuantityUp As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlMainLocation As Panel
    Friend WithEvents pnlPatientName As Panel
    Friend WithEvents pnlPatientNamePadding As Panel
    Friend WithEvents cmbPatientNames As ComboBox
    Friend WithEvents lblPatientName As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents pnlMainFormFields As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkControlled As CheckBox
    Friend WithEvents chkNarcotic As CheckBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtType As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtSchedule As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtStrength As TextBox
    Friend WithEvents cboSuggestedNames As ComboBox
    Friend WithEvents eprError As ErrorProvider
    Friend WithEvents cmbDividerBin As ComboBox
    Friend WithEvents cboPersonalMedication As ComboBox
    Friend WithEvents cmbDrawerNumber As ComboBox
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblBarcode As Label
    Friend WithEvents tpSelectedItem As ToolTip
    Friend WithEvents Panel2 As Panel
    Friend WithEvents mtbExpirationDate As MaskedTextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtUnits As TextBox
    Friend WithEvents pnlTransparent As TransparentPanel
End Class
