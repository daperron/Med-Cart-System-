<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewPatient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewPatient))
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.cmbState = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbSex = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.cmbPhysician = New System.Windows.Forms.ComboBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.cboBed = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cboRoom = New System.Windows.Forms.ComboBox()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.mtbPhone = New System.Windows.Forms.MaskedTextBox()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.mtbZipCode = New System.Windows.Forms.MaskedTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.mtbDoB = New System.Windows.Forms.MaskedTextBox()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel13.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFirstName
        '
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(1, 1)
        Me.txtFirstName.MaxLength = 40
        Me.txtFirstName.Multiline = True
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ShortcutsEnabled = False
        Me.txtFirstName.Size = New System.Drawing.Size(250, 26)
        Me.txtFirstName.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.txtFirstName)
        Me.Panel1.Location = New System.Drawing.Point(46, 111)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(252, 28)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Patient Information:"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DarkGray
        Me.Panel9.Controls.Add(Me.txtMiddleName)
        Me.Panel9.Location = New System.Drawing.Point(338, 111)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel9.Size = New System.Drawing.Size(252, 28)
        Me.Panel9.TabIndex = 2
        '
        'txtMiddleName
        '
        Me.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMiddleName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMiddleName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(1, 1)
        Me.txtMiddleName.MaxLength = 40
        Me.txtMiddleName.Multiline = True
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.ShortcutsEnabled = False
        Me.txtMiddleName.Size = New System.Drawing.Size(250, 26)
        Me.txtMiddleName.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.DarkGray
        Me.Panel10.Controls.Add(Me.txtAddress)
        Me.Panel10.Location = New System.Drawing.Point(46, 341)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel10.Size = New System.Drawing.Size(843, 31)
        Me.Panel10.TabIndex = 13
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(1, 1)
        Me.txtAddress.MaxLength = 50
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ShortcutsEnabled = False
        Me.txtAddress.Size = New System.Drawing.Size(841, 29)
        Me.txtAddress.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DarkGray
        Me.Panel11.Controls.Add(Me.txtLastName)
        Me.Panel11.Location = New System.Drawing.Point(630, 111)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel11.Size = New System.Drawing.Size(259, 28)
        Me.Panel11.TabIndex = 3
        '
        'txtLastName
        '
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLastName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(1, 1)
        Me.txtLastName.MaxLength = 40
        Me.txtLastName.Multiline = True
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ShortcutsEnabled = False
        Me.txtLastName.Size = New System.Drawing.Size(257, 26)
        Me.txtLastName.TabIndex = 0
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.DarkGray
        Me.Panel12.Controls.Add(Me.txtEmail)
        Me.Panel12.Location = New System.Drawing.Point(630, 415)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel12.Size = New System.Drawing.Size(259, 32)
        Me.Panel12.TabIndex = 17
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(1, 1)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Multiline = True
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ShortcutsEnabled = False
        Me.txtEmail.Size = New System.Drawing.Size(257, 30)
        Me.txtEmail.TabIndex = 0
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DarkGray
        Me.Panel16.Controls.Add(Me.txtCity)
        Me.Panel16.Location = New System.Drawing.Point(46, 415)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel16.Size = New System.Drawing.Size(251, 31)
        Me.Panel16.TabIndex = 14
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(1, 1)
        Me.txtCity.MaxLength = 30
        Me.txtCity.Multiline = True
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ShortcutsEnabled = False
        Me.txtCity.Size = New System.Drawing.Size(249, 29)
        Me.txtCity.TabIndex = 0
        '
        'cmbState
        '
        Me.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbState.DropDownHeight = 250
        Me.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbState.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbState.FormattingEnabled = True
        Me.cmbState.IntegralHeight = False
        Me.cmbState.Location = New System.Drawing.Point(1, 1)
        Me.cmbState.MaxLength = 2
        Me.cmbState.Name = "cmbState"
        Me.cmbState.Size = New System.Drawing.Size(105, 29)
        Me.cmbState.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.cmbState)
        Me.Panel2.Location = New System.Drawing.Point(338, 415)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(107, 31)
        Me.Panel2.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.cmbSex)
        Me.Panel3.Location = New System.Drawing.Point(630, 185)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(124, 31)
        Me.Panel3.TabIndex = 6
        '
        'cmbSex
        '
        Me.cmbSex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSex.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSex.FormattingEnabled = True
        Me.cmbSex.Location = New System.Drawing.Point(1, 1)
        Me.cmbSex.Name = "cmbSex"
        Me.cmbSex.Size = New System.Drawing.Size(122, 29)
        Me.cmbSex.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Image = Global.test_gui.My.Resources.Resources.resolve
        Me.btnSave.Location = New System.Drawing.Point(417, 554)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 38)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "   SAVE "
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkGray
        Me.Panel6.Controls.Add(Me.txtHeight)
        Me.Panel6.Location = New System.Drawing.Point(339, 258)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel6.Size = New System.Drawing.Size(105, 32)
        Me.Panel6.TabIndex = 11
        '
        'txtHeight
        '
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHeight.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(1, 1)
        Me.txtHeight.MaxLength = 4
        Me.txtHeight.Multiline = True
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.ShortcutsEnabled = False
        Me.txtHeight.Size = New System.Drawing.Size(103, 30)
        Me.txtHeight.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGray
        Me.Panel7.Controls.Add(Me.txtWeight)
        Me.Panel7.Location = New System.Drawing.Point(631, 259)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel7.Size = New System.Drawing.Size(87, 32)
        Me.Panel7.TabIndex = 12
        '
        'txtWeight
        '
        Me.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWeight.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(1, 1)
        Me.txtWeight.MaxLength = 5
        Me.txtWeight.Multiline = True
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ShortcutsEnabled = False
        Me.txtWeight.Size = New System.Drawing.Size(85, 30)
        Me.txtWeight.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Controls.Add(Me.cmbPhysician)
        Me.Panel8.Location = New System.Drawing.Point(338, 495)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel8.Size = New System.Drawing.Size(252, 31)
        Me.Panel8.TabIndex = 19
        '
        'cmbPhysician
        '
        Me.cmbPhysician.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPhysician.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPhysician.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPhysician.DropDownHeight = 150
        Me.cmbPhysician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPhysician.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPhysician.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPhysician.FormattingEnabled = True
        Me.cmbPhysician.IntegralHeight = False
        Me.cmbPhysician.Location = New System.Drawing.Point(1, 1)
        Me.cmbPhysician.Name = "cmbPhysician"
        Me.cmbPhysician.Size = New System.Drawing.Size(250, 29)
        Me.cmbPhysician.TabIndex = 0
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblFirstName.Location = New System.Drawing.Point(43, 83)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(89, 21)
        Me.lblFirstName.TabIndex = 68
        Me.lblFirstName.Text = "First Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(628, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 21)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Last Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(338, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 21)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Middle Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(626, 391)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 21)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Email:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(626, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 21)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Sex:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(42, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 21)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "DOB (Year-Month-Date):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(334, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 21)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Height (in cm):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(627, 235)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 21)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Weight (in kg):"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(42, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 21)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Rooms:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(44, 315)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 21)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "Street Address:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(43, 391)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 21)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "City:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(335, 391)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 21)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "State:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(479, 391)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 21)
        Me.Label14.TabIndex = 81
        Me.Label14.Text = "Zip Code:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(44, 471)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 21)
        Me.Label15.TabIndex = 82
        Me.Label15.Text = "Phone:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(335, 471)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(134, 21)
        Me.Label16.TabIndex = 83
        Me.Label16.Text = "Primary Physician"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.Controls.Add(Me.btnBack)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1091, 46)
        Me.Panel13.TabIndex = 0
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
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(89, 37)
        Me.btnBack.TabIndex = 0
        Me.btnBack.Text = "Back"
        Me.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(334, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 21)
        Me.Label10.TabIndex = 206
        Me.Label10.Text = "Beds:"
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.DarkGray
        Me.Panel17.Controls.Add(Me.cboBed)
        Me.Panel17.Location = New System.Drawing.Point(338, 186)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel17.Size = New System.Drawing.Size(252, 31)
        Me.Panel17.TabIndex = 5
        '
        'cboBed
        '
        Me.cboBed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBed.DropDownHeight = 150
        Me.cboBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBed.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBed.FormattingEnabled = True
        Me.cboBed.IntegralHeight = False
        Me.cboBed.Location = New System.Drawing.Point(1, 1)
        Me.cboBed.Name = "cboBed"
        Me.cboBed.Size = New System.Drawing.Size(250, 29)
        Me.cboBed.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.cboRoom)
        Me.Panel5.Location = New System.Drawing.Point(46, 185)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(252, 31)
        Me.Panel5.TabIndex = 4
        '
        'cboRoom
        '
        Me.cboRoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboRoom.DropDownHeight = 150
        Me.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRoom.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoom.FormattingEnabled = True
        Me.cboRoom.IntegralHeight = False
        Me.cboRoom.Location = New System.Drawing.Point(1, 1)
        Me.cboRoom.Name = "cboRoom"
        Me.cboRoom.Size = New System.Drawing.Size(250, 29)
        Me.cboRoom.TabIndex = 0
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.DarkGray
        Me.Panel18.Controls.Add(Me.Panel19)
        Me.Panel18.Controls.Add(Me.mtbPhone)
        Me.Panel18.Location = New System.Drawing.Point(46, 495)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel18.Size = New System.Drawing.Size(252, 31)
        Me.Panel18.TabIndex = 18
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel19.Location = New System.Drawing.Point(1, 23)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(250, 7)
        Me.Panel19.TabIndex = 173
        '
        'mtbPhone
        '
        Me.mtbPhone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mtbPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtbPhone.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mtbPhone.Location = New System.Drawing.Point(1, 1)
        Me.mtbPhone.Mask = "(999) 000-0000"
        Me.mtbPhone.Name = "mtbPhone"
        Me.mtbPhone.ShortcutsEnabled = False
        Me.mtbPhone.Size = New System.Drawing.Size(250, 22)
        Me.mtbPhone.TabIndex = 172
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.DarkGray
        Me.Panel15.Controls.Add(Me.Panel20)
        Me.Panel15.Controls.Add(Me.mtbZipCode)
        Me.Panel15.Location = New System.Drawing.Point(483, 415)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel15.Size = New System.Drawing.Size(107, 31)
        Me.Panel15.TabIndex = 16
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.White
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel20.Location = New System.Drawing.Point(1, 23)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(105, 7)
        Me.Panel20.TabIndex = 173
        '
        'mtbZipCode
        '
        Me.mtbZipCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mtbZipCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtbZipCode.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mtbZipCode.Location = New System.Drawing.Point(1, 1)
        Me.mtbZipCode.Mask = "00000"
        Me.mtbZipCode.Name = "mtbZipCode"
        Me.mtbZipCode.ShortcutsEnabled = False
        Me.mtbZipCode.Size = New System.Drawing.Size(105, 22)
        Me.mtbZipCode.TabIndex = 172
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.mtbDoB)
        Me.Panel4.Controls.Add(Me.Panel14)
        Me.Panel4.Location = New System.Drawing.Point(46, 260)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel4.Size = New System.Drawing.Size(171, 31)
        Me.Panel4.TabIndex = 7
        '
        'mtbDoB
        '
        Me.mtbDoB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mtbDoB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtbDoB.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mtbDoB.Location = New System.Drawing.Point(1, 1)
        Me.mtbDoB.Mask = "0000/00/00"
        Me.mtbDoB.Name = "mtbDoB"
        Me.mtbDoB.ShortcutsEnabled = False
        Me.mtbDoB.Size = New System.Drawing.Size(169, 22)
        Me.mtbDoB.TabIndex = 175
        Me.mtbDoB.ValidatingType = GetType(Date)
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.White
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel14.Location = New System.Drawing.Point(1, 23)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(169, 7)
        Me.Panel14.TabIndex = 174
        '
        'frmNewPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 645)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.Panel18)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmNewPatient"
        Me.Text = "frmNewPatient"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel13.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents txtCity As TextBox
    Friend WithEvents cmbState As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbSex As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtWeight As TextBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblFirstName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbPhysician As ComboBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Panel13 As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents cboBed As ComboBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cboRoom As ComboBox
    Friend WithEvents Panel15 As Panel
    Friend WithEvents mtbZipCode As MaskedTextBox
    Friend WithEvents Panel18 As Panel
    Friend WithEvents mtbPhone As MaskedTextBox
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents mtbDoB As MaskedTextBox
End Class
