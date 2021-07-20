<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdHockDispense
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdHockDispense))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMedications = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lstboxAllergies = New System.Windows.Forms.ListBox()
        Me.cmbPatientName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDispense = New System.Windows.Forms.Button()
        Me.txtStrength = New System.Windows.Forms.TextBox()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDrawerBin = New System.Windows.Forms.TextBox()
        Me.txtMRN = New System.Windows.Forms.TextBox()
        Me.txtDateOfBirth = New System.Windows.Forms.TextBox()
        Me.txtRoomBed = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
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
        Me.cmbphysician = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlSelector.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(378, 329)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 21)
        Me.Label13.TabIndex = 210
        Me.Label13.Text = "Patient Allergies:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(707, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 21)
        Me.Label15.TabIndex = 208
        Me.Label15.Text = "Type:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 21)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "Ad Hoc Order:"
        '
        'cmbMedications
        '
        Me.cmbMedications.BackColor = System.Drawing.Color.White
        Me.cmbMedications.DropDownHeight = 300
        Me.cmbMedications.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedications.FormattingEnabled = True
        Me.cmbMedications.IntegralHeight = False
        Me.cmbMedications.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbMedications.Location = New System.Drawing.Point(35, 64)
        Me.cmbMedications.Name = "cmbMedications"
        Me.cmbMedications.Size = New System.Drawing.Size(579, 29)
        Me.cmbMedications.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(32, 184)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 21)
        Me.Label14.TabIndex = 206
        Me.Label14.Text = "Strength:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(32, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 21)
        Me.Label17.TabIndex = 205
        Me.Label17.Text = "Medication:"
        '
        'lstboxAllergies
        '
        Me.lstboxAllergies.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lstboxAllergies.FormattingEnabled = True
        Me.lstboxAllergies.ItemHeight = 21
        Me.lstboxAllergies.Location = New System.Drawing.Point(382, 353)
        Me.lstboxAllergies.Name = "lstboxAllergies"
        Me.lstboxAllergies.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstboxAllergies.Size = New System.Drawing.Size(232, 172)
        Me.lstboxAllergies.TabIndex = 7
        Me.lstboxAllergies.TabStop = False
        '
        'cmbPatientName
        '
        Me.cmbPatientName.BackColor = System.Drawing.Color.White
        Me.cmbPatientName.DropDownHeight = 300
        Me.cmbPatientName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPatientName.FormattingEnabled = True
        Me.cmbPatientName.IntegralHeight = False
        Me.cmbPatientName.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbPatientName.Location = New System.Drawing.Point(35, 280)
        Me.cmbPatientName.Name = "cmbPatientName"
        Me.cmbPatientName.Size = New System.Drawing.Size(579, 29)
        Me.cmbPatientName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 256)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 21)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Select Patient:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(31, 329)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 21)
        Me.Label8.TabIndex = 214
        Me.Label8.Text = "Patient DOB:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 401)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 21)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "Patient MRN:"
        '
        'btnDispense
        '
        Me.btnDispense.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDispense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDispense.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDispense.ForeColor = System.Drawing.Color.White
        Me.btnDispense.Image = CType(resources.GetObject("btnDispense.Image"), System.Drawing.Image)
        Me.btnDispense.Location = New System.Drawing.Point(760, 435)
        Me.btnDispense.Name = "btnDispense"
        Me.btnDispense.Size = New System.Drawing.Size(229, 38)
        Me.btnDispense.TabIndex = 3
        Me.btnDispense.Text = "    SUBMIT ORDER"
        Me.btnDispense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDispense.UseVisualStyleBackColor = False
        '
        'txtStrength
        '
        Me.txtStrength.BackColor = System.Drawing.Color.White
        Me.txtStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStrength.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtStrength.Location = New System.Drawing.Point(36, 208)
        Me.txtStrength.MaxLength = 9
        Me.txtStrength.Name = "txtStrength"
        Me.txtStrength.ReadOnly = True
        Me.txtStrength.ShortcutsEnabled = False
        Me.txtStrength.Size = New System.Drawing.Size(293, 29)
        Me.txtStrength.TabIndex = 5
        Me.txtStrength.TabStop = False
        '
        'txtType
        '
        Me.txtType.BackColor = System.Drawing.Color.White
        Me.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtType.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtType.Location = New System.Drawing.Point(710, 65)
        Me.txtType.MaxLength = 9
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.ShortcutsEnabled = False
        Me.txtType.Size = New System.Drawing.Size(279, 29)
        Me.txtType.TabIndex = 1
        Me.txtType.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 21)
        Me.Label4.TabIndex = 220
        Me.Label4.Text = "Drawer and Bin number:"
        '
        'txtDrawerBin
        '
        Me.txtDrawerBin.BackColor = System.Drawing.Color.White
        Me.txtDrawerBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDrawerBin.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtDrawerBin.Location = New System.Drawing.Point(35, 136)
        Me.txtDrawerBin.MaxLength = 9
        Me.txtDrawerBin.Name = "txtDrawerBin"
        Me.txtDrawerBin.ReadOnly = True
        Me.txtDrawerBin.ShortcutsEnabled = False
        Me.txtDrawerBin.Size = New System.Drawing.Size(293, 29)
        Me.txtDrawerBin.TabIndex = 2
        Me.txtDrawerBin.TabStop = False
        '
        'txtMRN
        '
        Me.txtMRN.BackColor = System.Drawing.Color.White
        Me.txtMRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMRN.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtMRN.Location = New System.Drawing.Point(35, 425)
        Me.txtMRN.MaxLength = 9
        Me.txtMRN.Name = "txtMRN"
        Me.txtMRN.ReadOnly = True
        Me.txtMRN.ShortcutsEnabled = False
        Me.txtMRN.Size = New System.Drawing.Size(322, 29)
        Me.txtMRN.TabIndex = 8
        Me.txtMRN.TabStop = False
        '
        'txtDateOfBirth
        '
        Me.txtDateOfBirth.BackColor = System.Drawing.Color.White
        Me.txtDateOfBirth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateOfBirth.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtDateOfBirth.Location = New System.Drawing.Point(35, 353)
        Me.txtDateOfBirth.MaxLength = 9
        Me.txtDateOfBirth.Name = "txtDateOfBirth"
        Me.txtDateOfBirth.ReadOnly = True
        Me.txtDateOfBirth.ShortcutsEnabled = False
        Me.txtDateOfBirth.Size = New System.Drawing.Size(322, 29)
        Me.txtDateOfBirth.TabIndex = 6
        Me.txtDateOfBirth.TabStop = False
        '
        'txtRoomBed
        '
        Me.txtRoomBed.BackColor = System.Drawing.Color.White
        Me.txtRoomBed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoomBed.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtRoomBed.Location = New System.Drawing.Point(35, 496)
        Me.txtRoomBed.MaxLength = 9
        Me.txtRoomBed.Name = "txtRoomBed"
        Me.txtRoomBed.ReadOnly = True
        Me.txtRoomBed.ShortcutsEnabled = False
        Me.txtRoomBed.Size = New System.Drawing.Size(322, 29)
        Me.txtRoomBed.TabIndex = 6
        Me.txtRoomBed.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 472)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 21)
        Me.Label6.TabIndex = 224
        Me.Label6.Text = "Patient Room and Bed:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(880, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 21)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "Unit:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(706, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 21)
        Me.Label7.TabIndex = 228
        Me.Label7.Text = "Ordered Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtAmount.Location = New System.Drawing.Point(712, 136)
        Me.txtAmount.MaxLength = 5
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ShortcutsEnabled = False
        Me.txtAmount.Size = New System.Drawing.Size(147, 29)
        Me.txtAmount.TabIndex = 2
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.Color.White
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtUnit.Location = New System.Drawing.Point(884, 136)
        Me.txtUnit.MaxLength = 5
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.ShortcutsEnabled = False
        Me.txtUnit.Size = New System.Drawing.Size(125, 29)
        Me.txtUnit.TabIndex = 4
        Me.txtUnit.TabStop = False
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
        Me.pnlSelector.Location = New System.Drawing.Point(708, 175)
        Me.pnlSelector.Name = "pnlSelector"
        Me.pnlSelector.Size = New System.Drawing.Size(304, 300)
        Me.pnlSelector.TabIndex = 230
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
        Me.btnClear.Size = New System.Drawing.Size(84, 136)
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
        Me.btnEnter.Size = New System.Drawing.Size(84, 136)
        Me.btnEnter.TabIndex = 24
        Me.btnEnter.Text = "Submit"
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
        'cmbphysician
        '
        Me.cmbphysician.BackColor = System.Drawing.Color.White
        Me.cmbphysician.DropDownHeight = 300
        Me.cmbphysician.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbphysician.FormattingEnabled = True
        Me.cmbphysician.IntegralHeight = False
        Me.cmbphysician.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbphysician.Location = New System.Drawing.Point(35, 564)
        Me.cmbphysician.Name = "cmbphysician"
        Me.cmbphysician.Size = New System.Drawing.Size(579, 29)
        Me.cmbphysician.TabIndex = 231
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 540)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 21)
        Me.Label9.TabIndex = 232
        Me.Label9.Text = "Select Physician:"
        '
        'frmAdHockDispense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 645)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbphysician)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pnlSelector)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRoomBed)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDateOfBirth)
        Me.Controls.Add(Me.txtMRN)
        Me.Controls.Add(Me.txtDrawerBin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.txtStrength)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbPatientName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnDispense)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbMedications)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lstboxAllergies)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "frmAdHockDispense"
        Me.Text = "frmAdHockDispense"
        Me.pnlSelector.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As Label
    Friend WithEvents btnDispense As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMedications As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lstboxAllergies As ListBox
    Friend WithEvents cmbPatientName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtStrength As TextBox
    Friend WithEvents txtType As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDrawerBin As TextBox
    Friend WithEvents txtMRN As TextBox
    Friend WithEvents txtDateOfBirth As TextBox
    Friend WithEvents txtRoomBed As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtUnit As TextBox
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
    Friend WithEvents cmbphysician As ComboBox
    Friend WithEvents Label9 As Label
End Class
