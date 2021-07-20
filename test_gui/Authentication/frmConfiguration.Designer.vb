<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfiguration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguration))
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnConfirmEye = New System.Windows.Forms.Button()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnPasswordEye = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbtnAdministrator = New System.Windows.Forms.RadioButton()
        Me.rbtnSupervisor = New System.Windows.Forms.RadioButton()
        Me.rbtnNurse = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.flpUserInfo = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblActions = New System.Windows.Forms.Label()
        Me.lblPermissions = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSaveChanges = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtSearchBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tpLabelHover = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnSaveUser = New System.Windows.Forms.Button()
        Me.tpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.txtUsername)
        Me.Panel5.Location = New System.Drawing.Point(19, 208)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(227, 28)
        Me.Panel5.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(1, 1)
        Me.txtUsername.MaxLength = 20
        Me.txtUsername.Multiline = True
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ShortcutsEnabled = False
        Me.txtUsername.Size = New System.Drawing.Size(225, 26)
        Me.txtUsername.TabIndex = 38
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.btnConfirmEye)
        Me.Panel4.Controls.Add(Me.txtConfirmPassword)
        Me.Panel4.Location = New System.Drawing.Point(19, 410)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel4.Size = New System.Drawing.Size(224, 28)
        Me.Panel4.TabIndex = 6
        '
        'btnConfirmEye
        '
        Me.btnConfirmEye.BackColor = System.Drawing.Color.White
        Me.btnConfirmEye.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnConfirmEye.FlatAppearance.BorderSize = 0
        Me.btnConfirmEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmEye.ForeColor = System.Drawing.Color.Transparent
        Me.btnConfirmEye.Image = CType(resources.GetObject("btnConfirmEye.Image"), System.Drawing.Image)
        Me.btnConfirmEye.Location = New System.Drawing.Point(193, 1)
        Me.btnConfirmEye.Name = "btnConfirmEye"
        Me.btnConfirmEye.Size = New System.Drawing.Size(30, 26)
        Me.btnConfirmEye.TabIndex = 39
        Me.btnConfirmEye.UseVisualStyleBackColor = False
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(1, 1)
        Me.txtConfirmPassword.Multiline = True
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.ShortcutsEnabled = False
        Me.txtConfirmPassword.Size = New System.Drawing.Size(222, 26)
        Me.txtConfirmPassword.TabIndex = 38
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.btnPasswordEye)
        Me.Panel3.Controls.Add(Me.txtPassword)
        Me.Panel3.Location = New System.Drawing.Point(19, 343)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(225, 28)
        Me.Panel3.TabIndex = 5
        '
        'btnPasswordEye
        '
        Me.btnPasswordEye.BackColor = System.Drawing.Color.White
        Me.btnPasswordEye.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPasswordEye.FlatAppearance.BorderSize = 0
        Me.btnPasswordEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPasswordEye.ForeColor = System.Drawing.Color.Transparent
        Me.btnPasswordEye.Image = CType(resources.GetObject("btnPasswordEye.Image"), System.Drawing.Image)
        Me.btnPasswordEye.Location = New System.Drawing.Point(194, 1)
        Me.btnPasswordEye.Name = "btnPasswordEye"
        Me.btnPasswordEye.Size = New System.Drawing.Size(30, 26)
        Me.btnPasswordEye.TabIndex = 39
        Me.btnPasswordEye.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(1, 1)
        Me.txtPassword.Multiline = True
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.ShortcutsEnabled = False
        Me.txtPassword.Size = New System.Drawing.Size(223, 26)
        Me.txtPassword.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(356, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 25)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Registered Users:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 460)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 25)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "Permissions"
        '
        'rbtnAdministrator
        '
        Me.rbtnAdministrator.AutoSize = True
        Me.rbtnAdministrator.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAdministrator.Location = New System.Drawing.Point(228, 502)
        Me.rbtnAdministrator.Name = "rbtnAdministrator"
        Me.rbtnAdministrator.Size = New System.Drawing.Size(124, 25)
        Me.rbtnAdministrator.TabIndex = 9
        Me.rbtnAdministrator.TabStop = True
        Me.rbtnAdministrator.Text = "Administrator"
        Me.rbtnAdministrator.UseVisualStyleBackColor = True
        '
        'rbtnSupervisor
        '
        Me.rbtnSupervisor.AutoSize = True
        Me.rbtnSupervisor.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSupervisor.Location = New System.Drawing.Point(108, 502)
        Me.rbtnSupervisor.Name = "rbtnSupervisor"
        Me.rbtnSupervisor.Size = New System.Drawing.Size(103, 25)
        Me.rbtnSupervisor.TabIndex = 8
        Me.rbtnSupervisor.TabStop = True
        Me.rbtnSupervisor.Text = "Supervisor"
        Me.rbtnSupervisor.UseVisualStyleBackColor = True
        '
        'rbtnNurse
        '
        Me.rbtnNurse.AutoSize = True
        Me.rbtnNurse.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnNurse.Location = New System.Drawing.Point(22, 502)
        Me.rbtnNurse.Name = "rbtnNurse"
        Me.rbtnNurse.Size = New System.Drawing.Size(70, 25)
        Me.rbtnNurse.TabIndex = 7
        Me.rbtnNurse.TabStop = True
        Me.rbtnNurse.Text = "Nurse"
        Me.rbtnNurse.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.txtBarcode)
        Me.Panel2.Location = New System.Drawing.Point(19, 275)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(226, 28)
        Me.Panel2.TabIndex = 4
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(1, 1)
        Me.txtBarcode.Multiline = True
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ShortcutsEnabled = False
        Me.txtBarcode.Size = New System.Drawing.Size(224, 26)
        Me.txtBarcode.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 25)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Create New User:"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DarkGray
        Me.Panel9.Controls.Add(Me.txtLastName)
        Me.Panel9.Location = New System.Drawing.Point(19, 142)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel9.Size = New System.Drawing.Size(286, 28)
        Me.Panel9.TabIndex = 2
        '
        'txtLastName
        '
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLastName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(1, 1)
        Me.txtLastName.MaxLength = 24
        Me.txtLastName.Multiline = True
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ShortcutsEnabled = False
        Me.txtLastName.Size = New System.Drawing.Size(284, 26)
        Me.txtLastName.TabIndex = 38
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.txtFirstName)
        Me.Panel1.Location = New System.Drawing.Point(19, 79)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(286, 28)
        Me.Panel1.TabIndex = 1
        '
        'txtFirstName
        '
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(1, 1)
        Me.txtFirstName.MaxLength = 24
        Me.txtFirstName.Multiline = True
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ShortcutsEnabled = False
        Me.txtFirstName.Size = New System.Drawing.Size(284, 26)
        Me.txtFirstName.TabIndex = 38
        '
        'flpUserInfo
        '
        Me.flpUserInfo.AutoScroll = True
        Me.flpUserInfo.BackColor = System.Drawing.Color.White
        Me.flpUserInfo.Location = New System.Drawing.Point(361, 97)
        Me.flpUserInfo.Name = "flpUserInfo"
        Me.flpUserInfo.Size = New System.Drawing.Size(719, 563)
        Me.flpUserInfo.TabIndex = 140
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblStatus)
        Me.pnlHeader.Controls.Add(Me.lblActions)
        Me.pnlHeader.Controls.Add(Me.lblPermissions)
        Me.pnlHeader.Controls.Add(Me.lblName)
        Me.pnlHeader.Controls.Add(Me.lblUserName)
        Me.pnlHeader.Location = New System.Drawing.Point(361, 44)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(719, 47)
        Me.pnlHeader.TabIndex = 139
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblStatus.Location = New System.Drawing.Point(521, 15)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(56, 21)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Tag = "4"
        Me.lblStatus.Text = "Active"
        '
        'lblActions
        '
        Me.lblActions.AutoSize = True
        Me.lblActions.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActions.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblActions.Location = New System.Drawing.Point(624, 15)
        Me.lblActions.Name = "lblActions"
        Me.lblActions.Size = New System.Drawing.Size(65, 21)
        Me.lblActions.TabIndex = 10
        Me.lblActions.Text = "Actions"
        '
        'lblPermissions
        '
        Me.lblPermissions.AutoSize = True
        Me.lblPermissions.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermissions.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblPermissions.Location = New System.Drawing.Point(368, 16)
        Me.lblPermissions.Name = "lblPermissions"
        Me.lblPermissions.Size = New System.Drawing.Size(95, 21)
        Me.lblPermissions.TabIndex = 9
        Me.lblPermissions.Tag = "3"
        Me.lblPermissions.Text = "Permissions"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblName.Location = New System.Drawing.Point(8, 16)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(53, 21)
        Me.lblName.TabIndex = 8
        Me.lblName.Tag = "1"
        Me.lblName.Text = "Name"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblUserName.Location = New System.Drawing.Point(210, 15)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(83, 21)
        Me.lblUserName.TabIndex = 7
        Me.lblUserName.Tag = "2"
        Me.lblUserName.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 21)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "Last Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 21)
        Me.Label5.TabIndex = 178
        Me.Label5.Text = "Username:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 251)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 21)
        Me.Label6.TabIndex = 179
        Me.Label6.Text = "Barcode:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 319)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 21)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = "Password:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 386)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 21)
        Me.Label8.TabIndex = 181
        Me.Label8.Text = "Confirm Password:"
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSaveChanges.FlatAppearance.BorderSize = 0
        Me.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveChanges.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveChanges.ForeColor = System.Drawing.Color.White
        Me.btnSaveChanges.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveChanges.Location = New System.Drawing.Point(22, 568)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(131, 37)
        Me.btnSaveChanges.TabIndex = 182
        Me.btnSaveChanges.Text = "  Save "
        Me.btnSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveChanges.UseVisualStyleBackColor = False
        Me.btnSaveChanges.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.Location = New System.Drawing.Point(192, 568)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 37)
        Me.btnCancel.TabIndex = 183
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Visible = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(252, 251)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 184
        Me.txtID.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkGray
        Me.Panel6.Controls.Add(Me.pnlSearch)
        Me.Panel6.Controls.Add(Me.txtSearchBox)
        Me.Panel6.Location = New System.Drawing.Point(613, 13)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel6.Size = New System.Drawing.Size(466, 31)
        Me.Panel6.TabIndex = 187
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.BackgroundImage = CType(resources.GetObject("pnlSearch.BackgroundImage"), System.Drawing.Image)
        Me.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearch.ForeColor = System.Drawing.Color.White
        Me.pnlSearch.Location = New System.Drawing.Point(432, 1)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(33, 29)
        Me.pnlSearch.TabIndex = 2
        '
        'txtSearchBox
        '
        Me.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearchBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSearchBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBox.Location = New System.Drawing.Point(1, 1)
        Me.txtSearchBox.Multiline = True
        Me.txtSearchBox.Name = "txtSearchBox"
        Me.txtSearchBox.ShortcutsEnabled = False
        Me.txtSearchBox.Size = New System.Drawing.Size(431, 29)
        Me.txtSearchBox.TabIndex = 1
        Me.txtSearchBox.Tag = "Search Users"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 21)
        Me.Label12.TabIndex = 176
        Me.Label12.Text = "First Name:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.test_gui.My.Resources.Resources.Info
        Me.PictureBox1.Location = New System.Drawing.Point(250, 343)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.PictureBox1.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox1.TabIndex = 188
        Me.PictureBox1.TabStop = False
        Me.tpLabelHover.SetToolTip(Me.PictureBox1, "Password must contain at least 8 characters, 1 uppercase, 1 lowercase, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1 number" &
        ", 1 special characters !@#$%^&*/<>=+-_" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Password can not contain """";')( or spa" &
        "ces")
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.test_gui.My.Resources.Resources.Info
        Me.PictureBox2.Location = New System.Drawing.Point(250, 277)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.PictureBox2.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox2.TabIndex = 189
        Me.PictureBox2.TabStop = False
        Me.tpLabelHover.SetToolTip(Me.PictureBox2, "It is advised to scan the barcode with the barcode reader." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Barcodes must be 12" &
        "-24 characters long and contain " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "alphanumeric and symbols" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Barcodes can not c" &
        "ontain """";')( or spaces")
        '
        'btnSaveUser
        '
        Me.btnSaveUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSaveUser.FlatAppearance.BorderSize = 0
        Me.btnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveUser.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveUser.ForeColor = System.Drawing.Color.White
        Me.btnSaveUser.Image = Global.test_gui.My.Resources.Resources.resolve
        Me.btnSaveUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveUser.Location = New System.Drawing.Point(106, 568)
        Me.btnSaveUser.Name = "btnSaveUser"
        Me.btnSaveUser.Size = New System.Drawing.Size(165, 37)
        Me.btnSaveUser.TabIndex = 10
        Me.btnSaveUser.Text = "   Save User"
        Me.btnSaveUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveUser.UseVisualStyleBackColor = False
        '
        'frmConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 672)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSaveChanges)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnSaveUser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rbtnAdministrator)
        Me.Controls.Add(Me.rbtnSupervisor)
        Me.Controls.Add(Me.rbtnNurse)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.flpUserInfo)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmConfiguration"
        Me.Tag = ""
        Me.Text = "frmConfiguration"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnSaveUser As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents rbtnAdministrator As RadioButton
    Friend WithEvents rbtnSupervisor As RadioButton
    Friend WithEvents rbtnNurse As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents flpUserInfo As FlowLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblActions As Label
    Friend WithEvents lblPermissions As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSaveChanges As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtID As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnConfirmEye As Button
    Friend WithEvents btnPasswordEye As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents txtSearchBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tpLabelHover As ToolTip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents tpToolTip As ToolTip
End Class
