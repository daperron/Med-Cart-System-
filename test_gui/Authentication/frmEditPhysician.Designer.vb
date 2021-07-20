<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditPhysician
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditPhysician))
        Me.flpPhysicianInfo = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlPhysicianHeader = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblActions = New System.Windows.Forms.Label()
        Me.lblPermissions = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.pnlAllTextboxes = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.mtbFax = New System.Windows.Forms.MaskedTextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.mtbPhone = New System.Windows.Forms.MaskedTextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.txtZipCode = New System.Windows.Forms.MaskedTextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.btnSaveChanges = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboCredentials = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtSearchBox = New System.Windows.Forms.TextBox()
        Me.tpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.pnlSearchIcon = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlPhysicianHeader.SuspendLayout()
        Me.pnlAllTextboxes.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpPhysicianInfo
        '
        Me.flpPhysicianInfo.AutoScroll = True
        Me.flpPhysicianInfo.BackColor = System.Drawing.Color.White
        Me.flpPhysicianInfo.Location = New System.Drawing.Point(522, 73)
        Me.flpPhysicianInfo.Name = "flpPhysicianInfo"
        Me.flpPhysicianInfo.Size = New System.Drawing.Size(557, 562)
        Me.flpPhysicianInfo.TabIndex = 141
        '
        'pnlPhysicianHeader
        '
        Me.pnlPhysicianHeader.BackColor = System.Drawing.Color.White
        Me.pnlPhysicianHeader.Controls.Add(Me.lblStatus)
        Me.pnlPhysicianHeader.Controls.Add(Me.lblActions)
        Me.pnlPhysicianHeader.Controls.Add(Me.lblPermissions)
        Me.pnlPhysicianHeader.Controls.Add(Me.lblName)
        Me.pnlPhysicianHeader.Location = New System.Drawing.Point(522, 29)
        Me.pnlPhysicianHeader.Name = "pnlPhysicianHeader"
        Me.pnlPhysicianHeader.Size = New System.Drawing.Size(556, 39)
        Me.pnlPhysicianHeader.TabIndex = 142
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblStatus.Location = New System.Drawing.Point(359, 16)
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
        Me.lblActions.Location = New System.Drawing.Point(460, 16)
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
        Me.lblPermissions.Location = New System.Drawing.Point(220, 16)
        Me.lblPermissions.Name = "lblPermissions"
        Me.lblPermissions.Size = New System.Drawing.Size(92, 21)
        Me.lblPermissions.TabIndex = 9
        Me.lblPermissions.Tag = "3"
        Me.lblPermissions.Text = "Credentials"
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
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(349, 474)
        Me.txtID.Name = "txtID"
        Me.txtID.ShortcutsEnabled = False
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 165
        '
        'pnlAllTextboxes
        '
        Me.pnlAllTextboxes.Controls.Add(Me.Panel8)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel18)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel7)
        Me.pnlAllTextboxes.Controls.Add(Me.lblTitle)
        Me.pnlAllTextboxes.Controls.Add(Me.txtID)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel5)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel11)
        Me.pnlAllTextboxes.Controls.Add(Me.btnSaveChanges)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel4)
        Me.pnlAllTextboxes.Controls.Add(Me.Label14)
        Me.pnlAllTextboxes.Controls.Add(Me.Label13)
        Me.pnlAllTextboxes.Controls.Add(Me.Label12)
        Me.pnlAllTextboxes.Controls.Add(Me.Label11)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel2)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel16)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel10)
        Me.pnlAllTextboxes.Controls.Add(Me.Label5)
        Me.pnlAllTextboxes.Controls.Add(Me.Panel3)
        Me.pnlAllTextboxes.Controls.Add(Me.btnCancel)
        Me.pnlAllTextboxes.Controls.Add(Me.btnSave)
        Me.pnlAllTextboxes.Controls.Add(Me.Label2)
        Me.pnlAllTextboxes.Controls.Add(Me.Label15)
        Me.pnlAllTextboxes.Controls.Add(Me.Label3)
        Me.pnlAllTextboxes.Controls.Add(Me.Label1)
        Me.pnlAllTextboxes.Controls.Add(Me.lblFirstName)
        Me.pnlAllTextboxes.Location = New System.Drawing.Point(12, 1)
        Me.pnlAllTextboxes.Name = "pnlAllTextboxes"
        Me.pnlAllTextboxes.Size = New System.Drawing.Size(478, 497)
        Me.pnlAllTextboxes.TabIndex = 167
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Controls.Add(Me.mtbFax)
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Location = New System.Drawing.Point(263, 212)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel8.Size = New System.Drawing.Size(207, 31)
        Me.Panel8.TabIndex = 6
        '
        'mtbFax
        '
        Me.mtbFax.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mtbFax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtbFax.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mtbFax.Location = New System.Drawing.Point(1, 1)
        Me.mtbFax.Mask = "(999) 000-0000"
        Me.mtbFax.Name = "mtbFax"
        Me.mtbFax.ShortcutsEnabled = False
        Me.mtbFax.Size = New System.Drawing.Size(205, 22)
        Me.mtbFax.TabIndex = 174
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(1, 23)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(205, 7)
        Me.Panel9.TabIndex = 173
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.DarkGray
        Me.Panel18.Controls.Add(Me.Panel19)
        Me.Panel18.Controls.Add(Me.mtbPhone)
        Me.Panel18.Location = New System.Drawing.Point(13, 212)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel18.Size = New System.Drawing.Size(185, 31)
        Me.Panel18.TabIndex = 5
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel19.Location = New System.Drawing.Point(1, 23)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(183, 7)
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
        Me.mtbPhone.Size = New System.Drawing.Size(183, 22)
        Me.mtbPhone.TabIndex = 172
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGray
        Me.Panel7.Controls.Add(Me.Panel20)
        Me.Panel7.Controls.Add(Me.txtZipCode)
        Me.Panel7.Location = New System.Drawing.Point(361, 356)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel7.Size = New System.Drawing.Size(108, 31)
        Me.Panel7.TabIndex = 10
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.White
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel20.Location = New System.Drawing.Point(1, 23)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(106, 7)
        Me.Panel20.TabIndex = 173
        '
        'txtZipCode
        '
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtZipCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtZipCode.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtZipCode.Location = New System.Drawing.Point(1, 1)
        Me.txtZipCode.Mask = "00000"
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.ShortcutsEnabled = False
        Me.txtZipCode.Size = New System.Drawing.Size(106, 22)
        Me.txtZipCode.TabIndex = 172
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(201, 25)
        Me.lblTitle.TabIndex = 189
        Me.lblTitle.Text = "Create New Physician"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.txtMiddleName)
        Me.Panel5.Location = New System.Drawing.Point(263, 70)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(207, 28)
        Me.Panel5.TabIndex = 2
        '
        'txtMiddleName
        '
        Me.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMiddleName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMiddleName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(1, 1)
        Me.txtMiddleName.MaxLength = 25
        Me.txtMiddleName.Multiline = True
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.ShortcutsEnabled = False
        Me.txtMiddleName.Size = New System.Drawing.Size(205, 26)
        Me.txtMiddleName.TabIndex = 2
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DarkGray
        Me.Panel11.Controls.Add(Me.txtLastName)
        Me.Panel11.Location = New System.Drawing.Point(13, 137)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel11.Size = New System.Drawing.Size(215, 28)
        Me.Panel11.TabIndex = 3
        '
        'txtLastName
        '
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLastName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(1, 1)
        Me.txtLastName.MaxLength = 25
        Me.txtLastName.Multiline = True
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ShortcutsEnabled = False
        Me.txtLastName.Size = New System.Drawing.Size(213, 26)
        Me.txtLastName.TabIndex = 2
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveChanges.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveChanges.ForeColor = System.Drawing.Color.White
        Me.btnSaveChanges.Location = New System.Drawing.Point(245, 411)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(120, 38)
        Me.btnSaveChanges.TabIndex = 12
        Me.btnSaveChanges.Text = "   SAVE "
        Me.btnSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveChanges.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.txtFirstName)
        Me.Panel4.Location = New System.Drawing.Point(13, 70)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel4.Size = New System.Drawing.Size(215, 28)
        Me.Panel4.TabIndex = 1
        '
        'txtFirstName
        '
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(1, 1)
        Me.txtFirstName.MaxLength = 25
        Me.txtFirstName.Multiline = True
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ShortcutsEnabled = False
        Me.txtFirstName.Size = New System.Drawing.Size(213, 26)
        Me.txtFirstName.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(359, 332)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 21)
        Me.Label14.TabIndex = 188
        Me.Label14.Text = "Zip Code:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(232, 333)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 21)
        Me.Label13.TabIndex = 187
        Me.Label13.Text = "State:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(10, 333)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 21)
        Me.Label12.TabIndex = 186
        Me.Label12.Text = "City:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(9, 264)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 21)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "Street Address:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.cboState)
        Me.Panel2.Location = New System.Drawing.Point(235, 357)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(80, 31)
        Me.Panel2.TabIndex = 9
        '
        'cboState
        '
        Me.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboState.DropDownHeight = 250
        Me.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboState.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.IntegralHeight = False
        Me.cboState.Location = New System.Drawing.Point(1, 1)
        Me.cboState.MaxLength = 2
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(78, 29)
        Me.cboState.TabIndex = 13
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DarkGray
        Me.Panel16.Controls.Add(Me.txtCity)
        Me.Panel16.Location = New System.Drawing.Point(13, 357)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel16.Size = New System.Drawing.Size(184, 30)
        Me.Panel16.TabIndex = 8
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(1, 1)
        Me.txtCity.MaxLength = 25
        Me.txtCity.Multiline = True
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ShortcutsEnabled = False
        Me.txtCity.Size = New System.Drawing.Size(182, 28)
        Me.txtCity.TabIndex = 12
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.DarkGray
        Me.Panel10.Controls.Add(Me.txtAddress)
        Me.Panel10.Location = New System.Drawing.Point(13, 287)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel10.Size = New System.Drawing.Size(457, 31)
        Me.Panel10.TabIndex = 7
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
        Me.txtAddress.Size = New System.Drawing.Size(455, 29)
        Me.txtAddress.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(260, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 21)
        Me.Label5.TabIndex = 180
        Me.Label5.Text = "Credentials:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.cboCredentials)
        Me.Panel3.Location = New System.Drawing.Point(263, 134)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(207, 31)
        Me.Panel3.TabIndex = 4
        '
        'cboCredentials
        '
        Me.cboCredentials.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCredentials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCredentials.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCredentials.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCredentials.FormattingEnabled = True
        Me.cboCredentials.Location = New System.Drawing.Point(1, 1)
        Me.cboCredentials.Name = "cboCredentials"
        Me.cboCredentials.Size = New System.Drawing.Size(205, 29)
        Me.cboCredentials.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(97, 411)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 38)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "   CANCEL"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(166, 411)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 38)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "   SAVE "
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(260, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 21)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Fax:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(9, 188)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 21)
        Me.Label15.TabIndex = 174
        Me.Label15.Text = "Phone:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(259, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 21)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Middle Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 21)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Last Name:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblFirstName.Location = New System.Drawing.Point(9, 47)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(89, 21)
        Me.lblFirstName.TabIndex = 167
        Me.lblFirstName.Text = "First Name:"
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
        Me.txtSearchBox.Size = New System.Drawing.Size(361, 29)
        Me.txtSearchBox.TabIndex = 170
        Me.txtSearchBox.Tag = "Search Users"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.pnlSearch)
        Me.Panel1.Controls.Add(Me.txtSearchBox)
        Me.Panel1.Location = New System.Drawing.Point(692, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(386, 31)
        Me.Panel1.TabIndex = 172
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.BackgroundImage = CType(resources.GetObject("pnlSearch.BackgroundImage"), System.Drawing.Image)
        Me.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlSearch.Controls.Add(Me.pnlSearchIcon)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearch.ForeColor = System.Drawing.Color.White
        Me.pnlSearch.Location = New System.Drawing.Point(352, 1)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(33, 29)
        Me.pnlSearch.TabIndex = 2
        '
        'pnlSearchIcon
        '
        Me.pnlSearchIcon.BackColor = System.Drawing.Color.White
        Me.pnlSearchIcon.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSearchIcon.FlatAppearance.BorderSize = 0
        Me.pnlSearchIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pnlSearchIcon.ForeColor = System.Drawing.Color.Transparent
        Me.pnlSearchIcon.Image = Global.test_gui.My.Resources.Resources.Search
        Me.pnlSearchIcon.Location = New System.Drawing.Point(3, 0)
        Me.pnlSearchIcon.Name = "pnlSearchIcon"
        Me.pnlSearchIcon.Size = New System.Drawing.Size(30, 29)
        Me.pnlSearchIcon.TabIndex = 40
        Me.pnlSearchIcon.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(529, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 25)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "Physicians:"
        '
        'frmEditPhysician
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 672)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlAllTextboxes)
        Me.Controls.Add(Me.pnlPhysicianHeader)
        Me.Controls.Add(Me.flpPhysicianInfo)
        Me.Name = "frmEditPhysician"
        Me.Text = "frmEditPhysician"
        Me.pnlPhysicianHeader.ResumeLayout(False)
        Me.pnlPhysicianHeader.PerformLayout()
        Me.pnlAllTextboxes.ResumeLayout(False)
        Me.pnlAllTextboxes.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents flpPhysicianInfo As FlowLayoutPanel
    Friend WithEvents pnlPhysicianHeader As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblActions As Label
    Friend WithEvents lblPermissions As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents pnlAllTextboxes As Panel
    Friend WithEvents btnSaveChanges As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cboState As ComboBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents txtCity As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cboCredentials As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtSearchBox As TextBox
    Friend WithEvents tpToolTip As ToolTip
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents txtZipCode As MaskedTextBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents mtbFax As MaskedTextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents mtbPhone As MaskedTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents pnlSearchIcon As Button
    Friend WithEvents Label4 As Label
End Class
