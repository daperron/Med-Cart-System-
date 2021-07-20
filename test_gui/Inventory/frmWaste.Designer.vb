<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWaste
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWaste))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlRadioButtons = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlSignOff = New System.Windows.Forms.Panel()
        Me.pnlCredentials = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblUseBarcode = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnWasteWithCredentials = New System.Windows.Forms.Button()
        Me.pnlBarcode = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblBadge = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblSignoff = New System.Windows.Forms.Label()
        Me.btnWasteWithBarcode = New System.Windows.Forms.Button()
        Me.btnSubmitWithoutSignoff = New System.Windows.Forms.Button()
        Me.txtOther = New System.Windows.Forms.TextBox()
        Me.rbtnOther = New System.Windows.Forms.RadioButton()
        Me.radPatientUnavilable = New System.Windows.Forms.RadioButton()
        Me.radRefused = New System.Windows.Forms.RadioButton()
        Me.radCancel = New System.Windows.Forms.RadioButton()
        Me.radIncorrect = New System.Windows.Forms.RadioButton()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblPatientInfo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtMedication = New System.Windows.Forms.TextBox()
        Me.txtDrawer = New System.Windows.Forms.TextBox()
        Me.pnlSelector = New System.Windows.Forms.Panel()
        Me.btnDecimal = New System.Windows.Forms.Button()
        Me.btnFive = New System.Windows.Forms.Button()
        Me.btnFour = New System.Windows.Forms.Button()
        Me.btnZero = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnThree = New System.Windows.Forms.Button()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnTwo = New System.Windows.Forms.Button()
        Me.btnOne = New System.Windows.Forms.Button()
        Me.btnNine = New System.Windows.Forms.Button()
        Me.btnEight = New System.Windows.Forms.Button()
        Me.btnSeven = New System.Windows.Forms.Button()
        Me.btnSix = New System.Windows.Forms.Button()
        Me.pnlRadioButtons.SuspendLayout()
        Me.pnlSignOff.SuspendLayout()
        Me.pnlCredentials.SuspendLayout()
        Me.pnlBarcode.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelector.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(137, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 25)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Reason For Waste"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(138, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 25)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Medication:"
        '
        'pnlRadioButtons
        '
        Me.pnlRadioButtons.Controls.Add(Me.Label14)
        Me.pnlRadioButtons.Controls.Add(Me.pnlSignOff)
        Me.pnlRadioButtons.Controls.Add(Me.btnSubmitWithoutSignoff)
        Me.pnlRadioButtons.Controls.Add(Me.txtOther)
        Me.pnlRadioButtons.Controls.Add(Me.rbtnOther)
        Me.pnlRadioButtons.Controls.Add(Me.radPatientUnavilable)
        Me.pnlRadioButtons.Controls.Add(Me.radRefused)
        Me.pnlRadioButtons.Controls.Add(Me.radCancel)
        Me.pnlRadioButtons.Controls.Add(Me.radIncorrect)
        Me.pnlRadioButtons.Location = New System.Drawing.Point(143, 155)
        Me.pnlRadioButtons.Name = "pnlRadioButtons"
        Me.pnlRadioButtons.Size = New System.Drawing.Size(532, 441)
        Me.pnlRadioButtons.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(224, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 25)
        Me.Label14.TabIndex = 222
        Me.Label14.Text = "Explanation"
        '
        'pnlSignOff
        '
        Me.pnlSignOff.Controls.Add(Me.pnlCredentials)
        Me.pnlSignOff.Controls.Add(Me.pnlBarcode)
        Me.pnlSignOff.Location = New System.Drawing.Point(4, 158)
        Me.pnlSignOff.Name = "pnlSignOff"
        Me.pnlSignOff.Size = New System.Drawing.Size(517, 223)
        Me.pnlSignOff.TabIndex = 24
        '
        'pnlCredentials
        '
        Me.pnlCredentials.Controls.Add(Me.txtPassword)
        Me.pnlCredentials.Controls.Add(Me.Label9)
        Me.pnlCredentials.Controls.Add(Me.lblFirstName)
        Me.pnlCredentials.Controls.Add(Me.lblUseBarcode)
        Me.pnlCredentials.Controls.Add(Me.txtUsername)
        Me.pnlCredentials.Controls.Add(Me.Label3)
        Me.pnlCredentials.Controls.Add(Me.btnWasteWithCredentials)
        Me.pnlCredentials.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCredentials.Location = New System.Drawing.Point(245, 0)
        Me.pnlCredentials.Name = "pnlCredentials"
        Me.pnlCredentials.Size = New System.Drawing.Size(242, 223)
        Me.pnlCredentials.TabIndex = 219
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(8, 122)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.ShortcutsEnabled = False
        Me.txtPassword.Size = New System.Drawing.Size(220, 25)
        Me.txtPassword.TabIndex = 223
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(6, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 21)
        Me.Label9.TabIndex = 222
        Me.Label9.Text = "Password:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblFirstName.Location = New System.Drawing.Point(3, 38)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(84, 21)
        Me.lblFirstName.TabIndex = 221
        Me.lblFirstName.Text = "Username:"
        '
        'lblUseBarcode
        '
        Me.lblUseBarcode.AutoSize = True
        Me.lblUseBarcode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUseBarcode.ForeColor = System.Drawing.Color.Black
        Me.lblUseBarcode.Location = New System.Drawing.Point(56, 199)
        Me.lblUseBarcode.Name = "lblUseBarcode"
        Me.lblUseBarcode.Size = New System.Drawing.Size(133, 17)
        Me.lblUseBarcode.TabIndex = 220
        Me.lblUseBarcode.Text = "Scan Barcode Instead"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(8, 61)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ShortcutsEnabled = False
        Me.txtUsername.Size = New System.Drawing.Size(220, 25)
        Me.txtUsername.TabIndex = 217
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(235, 25)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Witness Sign-off Required"
        '
        'btnWasteWithCredentials
        '
        Me.btnWasteWithCredentials.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnWasteWithCredentials.FlatAppearance.BorderSize = 0
        Me.btnWasteWithCredentials.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWasteWithCredentials.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWasteWithCredentials.ForeColor = System.Drawing.Color.White
        Me.btnWasteWithCredentials.Image = CType(resources.GetObject("btnWasteWithCredentials.Image"), System.Drawing.Image)
        Me.btnWasteWithCredentials.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWasteWithCredentials.Location = New System.Drawing.Point(47, 159)
        Me.btnWasteWithCredentials.Name = "btnWasteWithCredentials"
        Me.btnWasteWithCredentials.Size = New System.Drawing.Size(150, 37)
        Me.btnWasteWithCredentials.TabIndex = 31
        Me.btnWasteWithCredentials.Text = "   SUBMIT"
        Me.btnWasteWithCredentials.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnWasteWithCredentials.UseVisualStyleBackColor = False
        '
        'pnlBarcode
        '
        Me.pnlBarcode.Controls.Add(Me.Label7)
        Me.pnlBarcode.Controls.Add(Me.lblBadge)
        Me.pnlBarcode.Controls.Add(Me.txtBarcode)
        Me.pnlBarcode.Controls.Add(Me.lblSignoff)
        Me.pnlBarcode.Controls.Add(Me.btnWasteWithBarcode)
        Me.pnlBarcode.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBarcode.Location = New System.Drawing.Point(0, 0)
        Me.pnlBarcode.Name = "pnlBarcode"
        Me.pnlBarcode.Size = New System.Drawing.Size(245, 223)
        Me.pnlBarcode.TabIndex = 218
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(74, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 17)
        Me.Label7.TabIndex = 219
        Me.Label7.Text = "Scan barcode"
        '
        'lblBadge
        '
        Me.lblBadge.AutoSize = True
        Me.lblBadge.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBadge.ForeColor = System.Drawing.Color.Black
        Me.lblBadge.Location = New System.Drawing.Point(46, 141)
        Me.lblBadge.Name = "lblBadge"
        Me.lblBadge.Size = New System.Drawing.Size(144, 17)
        Me.lblBadge.TabIndex = 218
        Me.lblBadge.Text = "Enter Password Instead"
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(8, 61)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ShortcutsEnabled = False
        Me.txtBarcode.Size = New System.Drawing.Size(231, 25)
        Me.txtBarcode.TabIndex = 217
        Me.txtBarcode.UseSystemPasswordChar = True
        '
        'lblSignoff
        '
        Me.lblSignoff.AutoSize = True
        Me.lblSignoff.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSignoff.Location = New System.Drawing.Point(4, 8)
        Me.lblSignoff.Name = "lblSignoff"
        Me.lblSignoff.Size = New System.Drawing.Size(235, 25)
        Me.lblSignoff.TabIndex = 32
        Me.lblSignoff.Text = "Witness Sign-off Required"
        '
        'btnWasteWithBarcode
        '
        Me.btnWasteWithBarcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnWasteWithBarcode.FlatAppearance.BorderSize = 0
        Me.btnWasteWithBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWasteWithBarcode.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWasteWithBarcode.ForeColor = System.Drawing.Color.White
        Me.btnWasteWithBarcode.Image = CType(resources.GetObject("btnWasteWithBarcode.Image"), System.Drawing.Image)
        Me.btnWasteWithBarcode.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWasteWithBarcode.Location = New System.Drawing.Point(43, 101)
        Me.btnWasteWithBarcode.Name = "btnWasteWithBarcode"
        Me.btnWasteWithBarcode.Size = New System.Drawing.Size(150, 37)
        Me.btnWasteWithBarcode.TabIndex = 31
        Me.btnWasteWithBarcode.Text = "   SUBMIT"
        Me.btnWasteWithBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnWasteWithBarcode.UseVisualStyleBackColor = False
        '
        'btnSubmitWithoutSignoff
        '
        Me.btnSubmitWithoutSignoff.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSubmitWithoutSignoff.FlatAppearance.BorderSize = 0
        Me.btnSubmitWithoutSignoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmitWithoutSignoff.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitWithoutSignoff.ForeColor = System.Drawing.Color.White
        Me.btnSubmitWithoutSignoff.Image = CType(resources.GetObject("btnSubmitWithoutSignoff.Image"), System.Drawing.Image)
        Me.btnSubmitWithoutSignoff.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSubmitWithoutSignoff.Location = New System.Drawing.Point(170, 212)
        Me.btnSubmitWithoutSignoff.Name = "btnSubmitWithoutSignoff"
        Me.btnSubmitWithoutSignoff.Size = New System.Drawing.Size(150, 37)
        Me.btnSubmitWithoutSignoff.TabIndex = 220
        Me.btnSubmitWithoutSignoff.Text = "   SUBMIT"
        Me.btnSubmitWithoutSignoff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmitWithoutSignoff.UseVisualStyleBackColor = False
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(229, 28)
        Me.txtOther.MaxLength = 500
        Me.txtOther.Multiline = True
        Me.txtOther.Name = "txtOther"
        Me.txtOther.ShortcutsEnabled = False
        Me.txtOther.Size = New System.Drawing.Size(270, 124)
        Me.txtOther.TabIndex = 6
        '
        'rbtnOther
        '
        Me.rbtnOther.AutoSize = True
        Me.rbtnOther.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnOther.Location = New System.Drawing.Point(4, 127)
        Me.rbtnOther.Name = "rbtnOther"
        Me.rbtnOther.Size = New System.Drawing.Size(219, 25)
        Me.rbtnOther.TabIndex = 5
        Me.rbtnOther.Text = "Other (Provide Explanation)"
        Me.rbtnOther.UseVisualStyleBackColor = True
        '
        'radPatientUnavilable
        '
        Me.radPatientUnavilable.AutoSize = True
        Me.radPatientUnavilable.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPatientUnavilable.Location = New System.Drawing.Point(4, 96)
        Me.radPatientUnavilable.Name = "radPatientUnavilable"
        Me.radPatientUnavilable.Size = New System.Drawing.Size(130, 25)
        Me.radPatientUnavilable.TabIndex = 4
        Me.radPatientUnavilable.Text = "Excess amount"
        Me.radPatientUnavilable.UseVisualStyleBackColor = True
        '
        'radRefused
        '
        Me.radRefused.AutoSize = True
        Me.radRefused.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radRefused.Location = New System.Drawing.Point(3, 65)
        Me.radRefused.Name = "radRefused"
        Me.radRefused.Size = New System.Drawing.Size(135, 25)
        Me.radRefused.TabIndex = 3
        Me.radRefused.Text = "Patient Refused"
        Me.radRefused.UseVisualStyleBackColor = True
        '
        'radCancel
        '
        Me.radCancel.AutoSize = True
        Me.radCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCancel.Location = New System.Drawing.Point(3, 34)
        Me.radCancel.Name = "radCancel"
        Me.radCancel.Size = New System.Drawing.Size(208, 25)
        Me.radCancel.TabIndex = 2
        Me.radCancel.Text = "Order Canceled / On Hold"
        Me.radCancel.UseVisualStyleBackColor = True
        '
        'radIncorrect
        '
        Me.radIncorrect.AutoSize = True
        Me.radIncorrect.Checked = True
        Me.radIncorrect.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radIncorrect.Location = New System.Drawing.Point(3, 3)
        Me.radIncorrect.Name = "radIncorrect"
        Me.radIncorrect.Size = New System.Drawing.Size(170, 25)
        Me.radIncorrect.TabIndex = 1
        Me.radIncorrect.TabStop = True
        Me.radIncorrect.Text = "Incorrect Medication"
        Me.radIncorrect.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnBack)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1091, 10)
        Me.pnlHeader.TabIndex = 202
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
        Me.btnBack.Location = New System.Drawing.Point(14, 6)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(89, 37)
        Me.btnBack.TabIndex = 61
        Me.btnBack.Text = "Back"
        Me.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBack.UseVisualStyleBackColor = False
        Me.btnBack.Visible = False
        '
        'lblPatientInfo
        '
        Me.lblPatientInfo.AutoSize = True
        Me.lblPatientInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblPatientInfo.Location = New System.Drawing.Point(125, 13)
        Me.lblPatientInfo.Name = "lblPatientInfo"
        Me.lblPatientInfo.Size = New System.Drawing.Size(56, 21)
        Me.lblPatientInfo.TabIndex = 200
        Me.lblPatientInfo.Text = "Label1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(477, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 25)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Drawer:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(657, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(199, 25)
        Me.Label5.TabIndex = 213
        Me.Label5.Text = "Enter amount wasted:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.Color.White
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(848, 88)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.ShortcutsEnabled = False
        Me.txtUnit.Size = New System.Drawing.Size(96, 25)
        Me.txtUnit.TabIndex = 214
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.White
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(665, 88)
        Me.txtQuantity.MaxLength = 5
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ShortcutsEnabled = False
        Me.txtQuantity.Size = New System.Drawing.Size(163, 25)
        Me.txtQuantity.TabIndex = 215
        '
        'txtMedication
        '
        Me.txtMedication.BackColor = System.Drawing.Color.White
        Me.txtMedication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMedication.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedication.Location = New System.Drawing.Point(142, 88)
        Me.txtMedication.Name = "txtMedication"
        Me.txtMedication.ReadOnly = True
        Me.txtMedication.ShortcutsEnabled = False
        Me.txtMedication.Size = New System.Drawing.Size(321, 25)
        Me.txtMedication.TabIndex = 216
        '
        'txtDrawer
        '
        Me.txtDrawer.BackColor = System.Drawing.Color.White
        Me.txtDrawer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDrawer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrawer.Location = New System.Drawing.Point(482, 88)
        Me.txtDrawer.Name = "txtDrawer"
        Me.txtDrawer.ReadOnly = True
        Me.txtDrawer.ShortcutsEnabled = False
        Me.txtDrawer.Size = New System.Drawing.Size(163, 25)
        Me.txtDrawer.TabIndex = 217
        '
        'pnlSelector
        '
        Me.pnlSelector.Controls.Add(Me.btnDecimal)
        Me.pnlSelector.Controls.Add(Me.btnFive)
        Me.pnlSelector.Controls.Add(Me.btnFour)
        Me.pnlSelector.Controls.Add(Me.btnZero)
        Me.pnlSelector.Controls.Add(Me.btnClear)
        Me.pnlSelector.Controls.Add(Me.btnThree)
        Me.pnlSelector.Controls.Add(Me.btnEnter)
        Me.pnlSelector.Controls.Add(Me.btnTwo)
        Me.pnlSelector.Controls.Add(Me.btnOne)
        Me.pnlSelector.Controls.Add(Me.btnNine)
        Me.pnlSelector.Controls.Add(Me.btnEight)
        Me.pnlSelector.Controls.Add(Me.btnSeven)
        Me.pnlSelector.Controls.Add(Me.btnSix)
        Me.pnlSelector.Location = New System.Drawing.Point(663, 127)
        Me.pnlSelector.Name = "pnlSelector"
        Me.pnlSelector.Size = New System.Drawing.Size(287, 300)
        Me.pnlSelector.TabIndex = 218
        '
        'btnDecimal
        '
        Me.btnDecimal.BackColor = System.Drawing.Color.Gainsboro
        Me.btnDecimal.FlatAppearance.BorderSize = 0
        Me.btnDecimal.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecimal.Location = New System.Drawing.Point(145, 213)
        Me.btnDecimal.Name = "btnDecimal"
        Me.btnDecimal.Padding = New System.Windows.Forms.Padding(1)
        Me.btnDecimal.Size = New System.Drawing.Size(64, 65)
        Me.btnDecimal.TabIndex = 25
        Me.btnDecimal.Text = "."
        Me.btnDecimal.UseVisualStyleBackColor = False
        '
        'btnFive
        '
        Me.btnFive.BackColor = System.Drawing.Color.Gainsboro
        Me.btnFive.FlatAppearance.BorderSize = 0
        Me.btnFive.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFive.Location = New System.Drawing.Point(74, 71)
        Me.btnFive.Name = "btnFive"
        Me.btnFive.Padding = New System.Windows.Forms.Padding(1)
        Me.btnFive.Size = New System.Drawing.Size(65, 65)
        Me.btnFive.TabIndex = 13
        Me.btnFive.Text = "5"
        Me.btnFive.UseVisualStyleBackColor = False
        '
        'btnFour
        '
        Me.btnFour.BackColor = System.Drawing.Color.Gainsboro
        Me.btnFour.FlatAppearance.BorderSize = 0
        Me.btnFour.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFour.Location = New System.Drawing.Point(3, 71)
        Me.btnFour.Name = "btnFour"
        Me.btnFour.Padding = New System.Windows.Forms.Padding(1)
        Me.btnFour.Size = New System.Drawing.Size(65, 65)
        Me.btnFour.TabIndex = 12
        Me.btnFour.Text = "4"
        Me.btnFour.UseVisualStyleBackColor = False
        '
        'btnZero
        '
        Me.btnZero.BackColor = System.Drawing.Color.Gainsboro
        Me.btnZero.FlatAppearance.BorderSize = 0
        Me.btnZero.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZero.Location = New System.Drawing.Point(3, 213)
        Me.btnZero.Name = "btnZero"
        Me.btnZero.Padding = New System.Windows.Forms.Padding(1)
        Me.btnZero.Size = New System.Drawing.Size(136, 65)
        Me.btnZero.TabIndex = 23
        Me.btnZero.Text = "0"
        Me.btnZero.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Gainsboro
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(217, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Padding = New System.Windows.Forms.Padding(1)
        Me.btnClear.Size = New System.Drawing.Size(65, 136)
        Me.btnClear.TabIndex = 22
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnThree
        '
        Me.btnThree.BackColor = System.Drawing.Color.Gainsboro
        Me.btnThree.FlatAppearance.BorderSize = 0
        Me.btnThree.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThree.Location = New System.Drawing.Point(145, 0)
        Me.btnThree.Name = "btnThree"
        Me.btnThree.Padding = New System.Windows.Forms.Padding(1)
        Me.btnThree.Size = New System.Drawing.Size(65, 65)
        Me.btnThree.TabIndex = 9
        Me.btnThree.Text = "3"
        Me.btnThree.UseVisualStyleBackColor = False
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.Gainsboro
        Me.btnEnter.FlatAppearance.BorderSize = 0
        Me.btnEnter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.Location = New System.Drawing.Point(217, 142)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Padding = New System.Windows.Forms.Padding(1)
        Me.btnEnter.Size = New System.Drawing.Size(65, 136)
        Me.btnEnter.TabIndex = 24
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = False
        '
        'btnTwo
        '
        Me.btnTwo.BackColor = System.Drawing.Color.Gainsboro
        Me.btnTwo.FlatAppearance.BorderSize = 0
        Me.btnTwo.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTwo.Location = New System.Drawing.Point(74, 0)
        Me.btnTwo.Name = "btnTwo"
        Me.btnTwo.Padding = New System.Windows.Forms.Padding(1)
        Me.btnTwo.Size = New System.Drawing.Size(65, 65)
        Me.btnTwo.TabIndex = 8
        Me.btnTwo.Text = "2"
        Me.btnTwo.UseVisualStyleBackColor = False
        '
        'btnOne
        '
        Me.btnOne.BackColor = System.Drawing.Color.Gainsboro
        Me.btnOne.FlatAppearance.BorderSize = 0
        Me.btnOne.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOne.Location = New System.Drawing.Point(3, 0)
        Me.btnOne.Name = "btnOne"
        Me.btnOne.Padding = New System.Windows.Forms.Padding(1)
        Me.btnOne.Size = New System.Drawing.Size(65, 65)
        Me.btnOne.TabIndex = 7
        Me.btnOne.Text = "1"
        Me.btnOne.UseVisualStyleBackColor = False
        '
        'btnNine
        '
        Me.btnNine.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNine.FlatAppearance.BorderSize = 0
        Me.btnNine.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNine.Location = New System.Drawing.Point(145, 142)
        Me.btnNine.Name = "btnNine"
        Me.btnNine.Padding = New System.Windows.Forms.Padding(1)
        Me.btnNine.Size = New System.Drawing.Size(65, 65)
        Me.btnNine.TabIndex = 19
        Me.btnNine.Tag = "9"
        Me.btnNine.Text = "9"
        Me.btnNine.UseVisualStyleBackColor = False
        '
        'btnEight
        '
        Me.btnEight.BackColor = System.Drawing.Color.Gainsboro
        Me.btnEight.FlatAppearance.BorderSize = 0
        Me.btnEight.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEight.Location = New System.Drawing.Point(74, 142)
        Me.btnEight.Name = "btnEight"
        Me.btnEight.Padding = New System.Windows.Forms.Padding(1)
        Me.btnEight.Size = New System.Drawing.Size(65, 65)
        Me.btnEight.TabIndex = 18
        Me.btnEight.Tag = "8"
        Me.btnEight.Text = "8"
        Me.btnEight.UseVisualStyleBackColor = False
        '
        'btnSeven
        '
        Me.btnSeven.BackColor = System.Drawing.Color.Gainsboro
        Me.btnSeven.FlatAppearance.BorderSize = 0
        Me.btnSeven.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeven.Location = New System.Drawing.Point(3, 142)
        Me.btnSeven.Name = "btnSeven"
        Me.btnSeven.Padding = New System.Windows.Forms.Padding(1)
        Me.btnSeven.Size = New System.Drawing.Size(65, 65)
        Me.btnSeven.TabIndex = 17
        Me.btnSeven.Text = "7"
        Me.btnSeven.UseVisualStyleBackColor = False
        '
        'btnSix
        '
        Me.btnSix.BackColor = System.Drawing.Color.Gainsboro
        Me.btnSix.FlatAppearance.BorderSize = 0
        Me.btnSix.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSix.Location = New System.Drawing.Point(145, 71)
        Me.btnSix.Name = "btnSix"
        Me.btnSix.Padding = New System.Windows.Forms.Padding(1)
        Me.btnSix.Size = New System.Drawing.Size(65, 65)
        Me.btnSix.TabIndex = 14
        Me.btnSix.Text = "6"
        Me.btnSix.UseVisualStyleBackColor = False
        '
        'frmWaste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 645)
        Me.Controls.Add(Me.pnlSelector)
        Me.Controls.Add(Me.lblPatientInfo)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.txtDrawer)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtMedication)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlRadioButtons)
        Me.Name = "frmWaste"
        Me.Text = "Waste"
        Me.pnlRadioButtons.ResumeLayout(False)
        Me.pnlRadioButtons.PerformLayout()
        Me.pnlSignOff.ResumeLayout(False)
        Me.pnlCredentials.ResumeLayout(False)
        Me.pnlCredentials.PerformLayout()
        Me.pnlBarcode.ResumeLayout(False)
        Me.pnlBarcode.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelector.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlRadioButtons As Panel
    Friend WithEvents txtOther As TextBox
    Friend WithEvents rbtnOther As RadioButton
    Friend WithEvents radPatientUnavilable As RadioButton
    Friend WithEvents radRefused As RadioButton
    Friend WithEvents radCancel As RadioButton
    Friend WithEvents radIncorrect As RadioButton
    Friend WithEvents pnlSignOff As Panel
    Friend WithEvents lblSignoff As Label
    Friend WithEvents btnWasteWithBarcode As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDrawer As TextBox
    Friend WithEvents txtMedication As TextBox
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblPatientInfo As Label
    Friend WithEvents pnlCredentials As Panel
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnWasteWithCredentials As Button
    Friend WithEvents pnlBarcode As Panel
    Friend WithEvents lblUseBarcode As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblBadge As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents btnSubmitWithoutSignoff As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents pnlSelector As Panel
    Friend WithEvents btnDecimal As Button
    Friend WithEvents btnFive As Button
    Friend WithEvents btnFour As Button
    Friend WithEvents btnZero As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnThree As Button
    Friend WithEvents btnEnter As Button
    Friend WithEvents btnTwo As Button
    Friend WithEvents btnOne As Button
    Friend WithEvents btnNine As Button
    Friend WithEvents btnEight As Button
    Friend WithEvents btnSeven As Button
    Friend WithEvents btnSix As Button
End Class
