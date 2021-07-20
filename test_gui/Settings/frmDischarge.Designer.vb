<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDischarge
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
        Me.components = New System.ComponentModel.Container()
        Me.lblAdmitPatients = New System.Windows.Forms.Label()
        Me.pnlAdmit = New System.Windows.Forms.Panel()
        Me.cmbAdmitPatients = New System.Windows.Forms.ComboBox()
        Me.btnAdmit = New System.Windows.Forms.Button()
        Me.lblDischargePatients = New System.Windows.Forms.Label()
        Me.pnlDischarge = New System.Windows.Forms.Panel()
        Me.cmbDischargePatients = New System.Windows.Forms.ComboBox()
        Me.btnDischarge = New System.Windows.Forms.Button()
        Me.pnlRadioButtons = New System.Windows.Forms.Panel()
        Me.radDischarge = New System.Windows.Forms.RadioButton()
        Me.radAdmitPatient = New System.Windows.Forms.RadioButton()
        Me.pnlInformation = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.txtPhone = New System.Windows.Forms.MaskedTextBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtPhysician = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtZipCode = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtMRN = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panel = New System.Windows.Forms.Panel()
        Me.txtBirthday = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlAdmitRoomBed = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboRoomandBed = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlDischargeRoomBed = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtBed = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.txtRoom = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlAdmit.SuspendLayout()
        Me.pnlDischarge.SuspendLayout()
        Me.pnlRadioButtons.SuspendLayout()
        Me.pnlInformation.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.panel.SuspendLayout()
        Me.pnlAdmitRoomBed.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlDischargeRoomBed.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAdmitPatients
        '
        Me.lblAdmitPatients.AutoSize = True
        Me.lblAdmitPatients.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdmitPatients.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblAdmitPatients.Location = New System.Drawing.Point(466, 99)
        Me.lblAdmitPatients.Name = "lblAdmitPatients"
        Me.lblAdmitPatients.Size = New System.Drawing.Size(183, 21)
        Me.lblAdmitPatients.TabIndex = 109
        Me.lblAdmitPatients.Text = "Select Patient to Admit:"
        '
        'pnlAdmit
        '
        Me.pnlAdmit.BackColor = System.Drawing.Color.DarkGray
        Me.pnlAdmit.Controls.Add(Me.cmbAdmitPatients)
        Me.pnlAdmit.Location = New System.Drawing.Point(470, 123)
        Me.pnlAdmit.Name = "pnlAdmit"
        Me.pnlAdmit.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlAdmit.Size = New System.Drawing.Size(437, 31)
        Me.pnlAdmit.TabIndex = 1
        Me.pnlAdmit.TabStop = True
        '
        'cmbAdmitPatients
        '
        Me.cmbAdmitPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbAdmitPatients.DropDownHeight = 200
        Me.cmbAdmitPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAdmitPatients.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAdmitPatients.FormattingEnabled = True
        Me.cmbAdmitPatients.IntegralHeight = False
        Me.cmbAdmitPatients.Location = New System.Drawing.Point(1, 1)
        Me.cmbAdmitPatients.Name = "cmbAdmitPatients"
        Me.cmbAdmitPatients.Size = New System.Drawing.Size(435, 29)
        Me.cmbAdmitPatients.TabIndex = 5
        '
        'btnAdmit
        '
        Me.btnAdmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnAdmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdmit.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdmit.ForeColor = System.Drawing.Color.White
        Me.btnAdmit.Image = Global.test_gui.My.Resources.Resources.resolve
        Me.btnAdmit.Location = New System.Drawing.Point(386, 280)
        Me.btnAdmit.Name = "btnAdmit"
        Me.btnAdmit.Size = New System.Drawing.Size(132, 38)
        Me.btnAdmit.TabIndex = 2
        Me.btnAdmit.Text = "  Admit"
        Me.btnAdmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdmit.UseVisualStyleBackColor = False
        '
        'lblDischargePatients
        '
        Me.lblDischargePatients.AutoSize = True
        Me.lblDischargePatients.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDischargePatients.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblDischargePatients.Location = New System.Drawing.Point(16, 99)
        Me.lblDischargePatients.Name = "lblDischargePatients"
        Me.lblDischargePatients.Size = New System.Drawing.Size(210, 21)
        Me.lblDischargePatients.TabIndex = 112
        Me.lblDischargePatients.Text = "Select Patient to Discharge:"
        '
        'pnlDischarge
        '
        Me.pnlDischarge.BackColor = System.Drawing.Color.DarkGray
        Me.pnlDischarge.Controls.Add(Me.cmbDischargePatients)
        Me.pnlDischarge.Location = New System.Drawing.Point(20, 123)
        Me.pnlDischarge.Name = "pnlDischarge"
        Me.pnlDischarge.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlDischarge.Size = New System.Drawing.Size(437, 31)
        Me.pnlDischarge.TabIndex = 3
        Me.pnlDischarge.TabStop = True
        '
        'cmbDischargePatients
        '
        Me.cmbDischargePatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDischargePatients.DropDownHeight = 200
        Me.cmbDischargePatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDischargePatients.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDischargePatients.FormattingEnabled = True
        Me.cmbDischargePatients.IntegralHeight = False
        Me.cmbDischargePatients.Location = New System.Drawing.Point(1, 1)
        Me.cmbDischargePatients.Name = "cmbDischargePatients"
        Me.cmbDischargePatients.Size = New System.Drawing.Size(435, 29)
        Me.cmbDischargePatients.TabIndex = 5
        '
        'btnDischarge
        '
        Me.btnDischarge.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDischarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDischarge.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDischarge.ForeColor = System.Drawing.Color.White
        Me.btnDischarge.Image = Global.test_gui.My.Resources.Resources.resolve
        Me.btnDischarge.Location = New System.Drawing.Point(386, 217)
        Me.btnDischarge.Name = "btnDischarge"
        Me.btnDischarge.Size = New System.Drawing.Size(132, 38)
        Me.btnDischarge.TabIndex = 4
        Me.btnDischarge.Text = "  Discharge"
        Me.btnDischarge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDischarge.UseVisualStyleBackColor = False
        '
        'pnlRadioButtons
        '
        Me.pnlRadioButtons.Controls.Add(Me.radDischarge)
        Me.pnlRadioButtons.Controls.Add(Me.radAdmitPatient)
        Me.pnlRadioButtons.Location = New System.Drawing.Point(20, 43)
        Me.pnlRadioButtons.Name = "pnlRadioButtons"
        Me.pnlRadioButtons.Size = New System.Drawing.Size(380, 40)
        Me.pnlRadioButtons.TabIndex = 115
        '
        'radDischarge
        '
        Me.radDischarge.AutoSize = True
        Me.radDischarge.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDischarge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.radDischarge.Location = New System.Drawing.Point(190, 11)
        Me.radDischarge.Name = "radDischarge"
        Me.radDischarge.Size = New System.Drawing.Size(155, 25)
        Me.radDischarge.TabIndex = 1
        Me.radDischarge.TabStop = True
        Me.radDischarge.Text = "Discharge Patient"
        Me.tpToolTip.SetToolTip(Me.radDischarge, "Please select a patient from the drop down and click discharge")
        Me.radDischarge.UseVisualStyleBackColor = True
        '
        'radAdmitPatient
        '
        Me.radAdmitPatient.AutoSize = True
        Me.radAdmitPatient.Checked = True
        Me.radAdmitPatient.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAdmitPatient.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.radAdmitPatient.Location = New System.Drawing.Point(3, 11)
        Me.radAdmitPatient.Name = "radAdmitPatient"
        Me.radAdmitPatient.Size = New System.Drawing.Size(128, 25)
        Me.radAdmitPatient.TabIndex = 0
        Me.radAdmitPatient.TabStop = True
        Me.radAdmitPatient.Text = "Admit Patient"
        Me.tpToolTip.SetToolTip(Me.radAdmitPatient, "Please select a patient from the drop down and click admit")
        Me.radAdmitPatient.UseVisualStyleBackColor = True
        '
        'pnlInformation
        '
        Me.pnlInformation.Controls.Add(Me.Panel13)
        Me.pnlInformation.Controls.Add(Me.Panel12)
        Me.pnlInformation.Controls.Add(Me.Panel11)
        Me.pnlInformation.Controls.Add(Me.Panel10)
        Me.pnlInformation.Controls.Add(Me.Panel3)
        Me.pnlInformation.Controls.Add(Me.Panel7)
        Me.pnlInformation.Controls.Add(Me.Panel5)
        Me.pnlInformation.Controls.Add(Me.Panel8)
        Me.pnlInformation.Controls.Add(Me.Panel6)
        Me.pnlInformation.Controls.Add(Me.Panel4)
        Me.pnlInformation.Controls.Add(Me.Panel9)
        Me.pnlInformation.Controls.Add(Me.Label2)
        Me.pnlInformation.Controls.Add(Me.panel)
        Me.pnlInformation.Controls.Add(Me.Label6)
        Me.pnlInformation.Controls.Add(Me.Label3)
        Me.pnlInformation.Controls.Add(Me.Label5)
        Me.pnlInformation.Controls.Add(Me.Label11)
        Me.pnlInformation.Controls.Add(Me.Label10)
        Me.pnlInformation.Controls.Add(Me.Label12)
        Me.pnlInformation.Controls.Add(Me.Label21)
        Me.pnlInformation.Controls.Add(Me.btnAdmit)
        Me.pnlInformation.Controls.Add(Me.Label20)
        Me.pnlInformation.Controls.Add(Me.Label1)
        Me.pnlInformation.Controls.Add(Me.Label9)
        Me.pnlInformation.Controls.Add(Me.pnlAdmitRoomBed)
        Me.pnlInformation.Controls.Add(Me.Label8)
        Me.pnlInformation.Controls.Add(Me.btnDischarge)
        Me.pnlInformation.Controls.Add(Me.pnlDischargeRoomBed)
        Me.pnlInformation.Location = New System.Drawing.Point(12, 170)
        Me.pnlInformation.Name = "pnlInformation"
        Me.pnlInformation.Size = New System.Drawing.Size(907, 334)
        Me.pnlInformation.TabIndex = 116
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.DarkGray
        Me.Panel13.Controls.Add(Me.Panel14)
        Me.Panel13.Controls.Add(Me.txtPhone)
        Me.Panel13.Location = New System.Drawing.Point(749, 106)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel13.Size = New System.Drawing.Size(148, 28)
        Me.Panel13.TabIndex = 170
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.White
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel14.Location = New System.Drawing.Point(1, 21)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(146, 6)
        Me.Panel14.TabIndex = 171
        '
        'txtPhone
        '
        Me.txtPhone.BackColor = System.Drawing.Color.White
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPhone.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(1, 1)
        Me.txtPhone.Mask = "(999) 000-0000"
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReadOnly = True
        Me.txtPhone.Size = New System.Drawing.Size(146, 22)
        Me.txtPhone.TabIndex = 16
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.DarkGray
        Me.Panel12.Controls.Add(Me.txtEmail)
        Me.Panel12.Location = New System.Drawing.Point(562, 106)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel12.Size = New System.Drawing.Size(151, 28)
        Me.Panel12.TabIndex = 169
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(1, 1)
        Me.txtEmail.Multiline = True
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.ShortcutsEnabled = False
        Me.txtEmail.Size = New System.Drawing.Size(149, 26)
        Me.txtEmail.TabIndex = 38
        Me.txtEmail.TabStop = False
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DarkGray
        Me.Panel11.Controls.Add(Me.txtPhysician)
        Me.Panel11.Location = New System.Drawing.Point(378, 106)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel11.Size = New System.Drawing.Size(151, 28)
        Me.Panel11.TabIndex = 168
        '
        'txtPhysician
        '
        Me.txtPhysician.BackColor = System.Drawing.Color.White
        Me.txtPhysician.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPhysician.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPhysician.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhysician.Location = New System.Drawing.Point(1, 1)
        Me.txtPhysician.Multiline = True
        Me.txtPhysician.Name = "txtPhysician"
        Me.txtPhysician.ReadOnly = True
        Me.txtPhysician.ShortcutsEnabled = False
        Me.txtPhysician.Size = New System.Drawing.Size(149, 26)
        Me.txtPhysician.TabIndex = 38
        Me.txtPhysician.TabStop = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.DarkGray
        Me.Panel10.Controls.Add(Me.txtAddress)
        Me.Panel10.Location = New System.Drawing.Point(8, 167)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel10.Size = New System.Drawing.Size(336, 28)
        Me.Panel10.TabIndex = 168
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(1, 1)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.ShortcutsEnabled = False
        Me.txtAddress.Size = New System.Drawing.Size(334, 26)
        Me.txtAddress.TabIndex = 38
        Me.txtAddress.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.txtZipCode)
        Me.Panel3.Location = New System.Drawing.Point(749, 166)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(148, 28)
        Me.Panel3.TabIndex = 165
        '
        'txtZipCode
        '
        Me.txtZipCode.BackColor = System.Drawing.Color.White
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtZipCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtZipCode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.Location = New System.Drawing.Point(1, 1)
        Me.txtZipCode.Multiline = True
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.ReadOnly = True
        Me.txtZipCode.ShortcutsEnabled = False
        Me.txtZipCode.Size = New System.Drawing.Size(146, 26)
        Me.txtZipCode.TabIndex = 38
        Me.txtZipCode.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGray
        Me.Panel7.Controls.Add(Me.txtWeight)
        Me.Panel7.Location = New System.Drawing.Point(749, 46)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel7.Size = New System.Drawing.Size(148, 28)
        Me.Panel7.TabIndex = 161
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.Color.White
        Me.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWeight.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(1, 1)
        Me.txtWeight.Multiline = True
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ReadOnly = True
        Me.txtWeight.ShortcutsEnabled = False
        Me.txtWeight.Size = New System.Drawing.Size(146, 26)
        Me.txtWeight.TabIndex = 38
        Me.txtWeight.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.txtMRN)
        Me.Panel5.Location = New System.Drawing.Point(8, 46)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(152, 28)
        Me.Panel5.TabIndex = 162
        '
        'txtMRN
        '
        Me.txtMRN.BackColor = System.Drawing.Color.White
        Me.txtMRN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMRN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMRN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRN.Location = New System.Drawing.Point(1, 1)
        Me.txtMRN.Multiline = True
        Me.txtMRN.Name = "txtMRN"
        Me.txtMRN.ReadOnly = True
        Me.txtMRN.ShortcutsEnabled = False
        Me.txtMRN.Size = New System.Drawing.Size(150, 26)
        Me.txtMRN.TabIndex = 38
        Me.txtMRN.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Controls.Add(Me.txtState)
        Me.Panel8.Location = New System.Drawing.Point(562, 166)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel8.Size = New System.Drawing.Size(150, 28)
        Me.Panel8.TabIndex = 166
        '
        'txtState
        '
        Me.txtState.BackColor = System.Drawing.Color.White
        Me.txtState.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtState.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.Location = New System.Drawing.Point(1, 1)
        Me.txtState.Multiline = True
        Me.txtState.Name = "txtState"
        Me.txtState.ReadOnly = True
        Me.txtState.ShortcutsEnabled = False
        Me.txtState.Size = New System.Drawing.Size(148, 26)
        Me.txtState.TabIndex = 38
        Me.txtState.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkGray
        Me.Panel6.Controls.Add(Me.txtHeight)
        Me.Panel6.Location = New System.Drawing.Point(562, 46)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel6.Size = New System.Drawing.Size(150, 28)
        Me.Panel6.TabIndex = 161
        '
        'txtHeight
        '
        Me.txtHeight.BackColor = System.Drawing.Color.White
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHeight.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(1, 1)
        Me.txtHeight.Multiline = True
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.ReadOnly = True
        Me.txtHeight.ShortcutsEnabled = False
        Me.txtHeight.Size = New System.Drawing.Size(148, 26)
        Me.txtHeight.TabIndex = 38
        Me.txtHeight.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.txtGender)
        Me.Panel4.Location = New System.Drawing.Point(378, 46)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel4.Size = New System.Drawing.Size(151, 28)
        Me.Panel4.TabIndex = 161
        '
        'txtGender
        '
        Me.txtGender.BackColor = System.Drawing.Color.White
        Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGender.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGender.Location = New System.Drawing.Point(1, 1)
        Me.txtGender.Multiline = True
        Me.txtGender.Name = "txtGender"
        Me.txtGender.ReadOnly = True
        Me.txtGender.ShortcutsEnabled = False
        Me.txtGender.Size = New System.Drawing.Size(149, 26)
        Me.txtGender.TabIndex = 38
        Me.txtGender.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DarkGray
        Me.Panel9.Controls.Add(Me.txtCity)
        Me.Panel9.Location = New System.Drawing.Point(378, 166)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel9.Size = New System.Drawing.Size(151, 28)
        Me.Panel9.TabIndex = 167
        '
        'txtCity
        '
        Me.txtCity.BackColor = System.Drawing.Color.White
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(1, 1)
        Me.txtCity.Multiline = True
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReadOnly = True
        Me.txtCity.ShortcutsEnabled = False
        Me.txtCity.Size = New System.Drawing.Size(149, 26)
        Me.txtCity.TabIndex = 38
        Me.txtCity.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(745, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 21)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Zip Code:"
        '
        'panel
        '
        Me.panel.BackColor = System.Drawing.Color.DarkGray
        Me.panel.Controls.Add(Me.txtBirthday)
        Me.panel.Location = New System.Drawing.Point(193, 46)
        Me.panel.Name = "panel"
        Me.panel.Padding = New System.Windows.Forms.Padding(1)
        Me.panel.Size = New System.Drawing.Size(152, 28)
        Me.panel.TabIndex = 161
        '
        'txtBirthday
        '
        Me.txtBirthday.BackColor = System.Drawing.Color.White
        Me.txtBirthday.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBirthday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBirthday.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBirthday.Location = New System.Drawing.Point(1, 1)
        Me.txtBirthday.Multiline = True
        Me.txtBirthday.Name = "txtBirthday"
        Me.txtBirthday.ReadOnly = True
        Me.txtBirthday.ShortcutsEnabled = False
        Me.txtBirthday.Size = New System.Drawing.Size(150, 26)
        Me.txtBirthday.TabIndex = 38
        Me.txtBirthday.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(4, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 21)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "Street Address:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(556, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 21)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "State:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(374, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 21)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Primary Physician:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(559, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 21)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "Email:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(374, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 21)
        Me.Label10.TabIndex = 168
        Me.Label10.Text = "City:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(745, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 21)
        Me.Label12.TabIndex = 167
        Me.Label12.Text = "Phone:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(745, 23)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 21)
        Me.Label21.TabIndex = 164
        Me.Label21.Text = "Weight:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(556, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 21)
        Me.Label20.TabIndex = 163
        Me.Label20.Text = "Height:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 21)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "MRN:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(374, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 21)
        Me.Label9.TabIndex = 162
        Me.Label9.Text = "Sex:"
        '
        'pnlAdmitRoomBed
        '
        Me.pnlAdmitRoomBed.Controls.Add(Me.Label4)
        Me.pnlAdmitRoomBed.Controls.Add(Me.Panel1)
        Me.pnlAdmitRoomBed.Location = New System.Drawing.Point(5, 75)
        Me.pnlAdmitRoomBed.Name = "pnlAdmitRoomBed"
        Me.pnlAdmitRoomBed.Size = New System.Drawing.Size(352, 66)
        Me.pnlAdmitRoomBed.TabIndex = 119
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(-1, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 21)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "Room and Bed:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.cboRoomandBed)
        Me.Panel1.Location = New System.Drawing.Point(3, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(337, 31)
        Me.Panel1.TabIndex = 6
        Me.Panel1.TabStop = True
        '
        'cboRoomandBed
        '
        Me.cboRoomandBed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboRoomandBed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRoomandBed.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoomandBed.FormattingEnabled = True
        Me.cboRoomandBed.Location = New System.Drawing.Point(1, 1)
        Me.cboRoomandBed.Name = "cboRoomandBed"
        Me.cboRoomandBed.Size = New System.Drawing.Size(335, 29)
        Me.cboRoomandBed.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(189, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 21)
        Me.Label8.TabIndex = 161
        Me.Label8.Text = "DOB:"
        '
        'pnlDischargeRoomBed
        '
        Me.pnlDischargeRoomBed.Controls.Add(Me.Panel2)
        Me.pnlDischargeRoomBed.Controls.Add(Me.Label15)
        Me.pnlDischargeRoomBed.Controls.Add(Me.Label14)
        Me.pnlDischargeRoomBed.Controls.Add(Me.Panel15)
        Me.pnlDischargeRoomBed.Location = New System.Drawing.Point(5, 77)
        Me.pnlDischargeRoomBed.Name = "pnlDischargeRoomBed"
        Me.pnlDischargeRoomBed.Size = New System.Drawing.Size(352, 66)
        Me.pnlDischargeRoomBed.TabIndex = 120
        Me.pnlDischargeRoomBed.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.txtBed)
        Me.Panel2.Location = New System.Drawing.Point(188, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(151, 28)
        Me.Panel2.TabIndex = 171
        '
        'txtBed
        '
        Me.txtBed.BackColor = System.Drawing.Color.White
        Me.txtBed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBed.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBed.Location = New System.Drawing.Point(1, 1)
        Me.txtBed.Multiline = True
        Me.txtBed.Name = "txtBed"
        Me.txtBed.ReadOnly = True
        Me.txtBed.ShortcutsEnabled = False
        Me.txtBed.Size = New System.Drawing.Size(149, 26)
        Me.txtBed.TabIndex = 38
        Me.txtBed.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(184, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 21)
        Me.Label15.TabIndex = 162
        Me.Label15.Text = "Bed:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(3, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 21)
        Me.Label14.TabIndex = 161
        Me.Label14.Text = "Room:"
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.DarkGray
        Me.Panel15.Controls.Add(Me.txtRoom)
        Me.Panel15.Location = New System.Drawing.Point(3, 29)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel15.Size = New System.Drawing.Size(151, 28)
        Me.Panel15.TabIndex = 170
        '
        'txtRoom
        '
        Me.txtRoom.BackColor = System.Drawing.Color.White
        Me.txtRoom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRoom.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoom.Location = New System.Drawing.Point(1, 1)
        Me.txtRoom.Multiline = True
        Me.txtRoom.Name = "txtRoom"
        Me.txtRoom.ReadOnly = True
        Me.txtRoom.ShortcutsEnabled = False
        Me.txtRoom.Size = New System.Drawing.Size(149, 26)
        Me.txtRoom.TabIndex = 38
        Me.txtRoom.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(15, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(234, 25)
        Me.Label18.TabIndex = 159
        Me.Label18.Text = "Admit/Discharge Patient:"
        '
        'frmDischarge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(982, 580)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblAdmitPatients)
        Me.Controls.Add(Me.pnlAdmit)
        Me.Controls.Add(Me.lblDischargePatients)
        Me.Controls.Add(Me.pnlInformation)
        Me.Controls.Add(Me.pnlDischarge)
        Me.Controls.Add(Me.pnlRadioButtons)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Name = "frmDischarge"
        Me.Text = "frmDischarge"
        Me.pnlAdmit.ResumeLayout(False)
        Me.pnlDischarge.ResumeLayout(False)
        Me.pnlRadioButtons.ResumeLayout(False)
        Me.pnlRadioButtons.PerformLayout()
        Me.pnlInformation.ResumeLayout(False)
        Me.pnlInformation.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.panel.ResumeLayout(False)
        Me.panel.PerformLayout()
        Me.pnlAdmitRoomBed.ResumeLayout(False)
        Me.pnlAdmitRoomBed.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlDischargeRoomBed.ResumeLayout(False)
        Me.pnlDischargeRoomBed.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblAdmitPatients As Label
    Friend WithEvents pnlAdmit As Panel
    Friend WithEvents cmbAdmitPatients As ComboBox
    Friend WithEvents btnAdmit As Button
    Friend WithEvents lblDischargePatients As Label
    Friend WithEvents cmbDischargePatients As ComboBox
    Friend WithEvents btnDischarge As Button
    Friend WithEvents pnlDischarge As Panel
    Friend WithEvents pnlRadioButtons As Panel
    Friend WithEvents radDischarge As RadioButton
    Friend WithEvents radAdmitPatient As RadioButton
    Friend WithEvents pnlInformation As Panel
    Friend WithEvents pnlAdmitRoomBed As Panel
    Friend WithEvents pnlDischargeRoomBed As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboRoomandBed As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtMRN As TextBox
    Friend WithEvents panel As Panel
    Friend WithEvents txtBirthday As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtGender As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtWeight As TextBox
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents txtPhone As MaskedTextBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents txtPhysician As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtZipCode As TextBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtState As TextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents txtCity As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtBed As TextBox
    Friend WithEvents Panel15 As Panel
    Friend WithEvents txtRoom As TextBox
    Friend WithEvents tpToolTip As ToolTip
End Class
