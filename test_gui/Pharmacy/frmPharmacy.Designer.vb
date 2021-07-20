<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPharmacy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPharmacy))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtPatientDOB = New System.Windows.Forms.TextBox()
        Me.btnORder = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbStrength = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbFrequencyNumber = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cmbMedication = New System.Windows.Forms.ComboBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cmbOrderedBy = New System.Windows.Forms.ComboBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.cmbPatientName = New System.Windows.Forms.ComboBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(36, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 21)
        Me.Label10.TabIndex = 175
        Me.Label10.Text = "Frequency:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(230, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 21)
        Me.Label11.TabIndex = 172
        Me.Label11.Text = "Ordered By:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(35, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 21)
        Me.Label12.TabIndex = 169
        Me.Label12.Text = "Patient Name:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(704, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 21)
        Me.Label13.TabIndex = 167
        Me.Label13.Text = "Patient DOB:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(577, 204)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 21)
        Me.Label14.TabIndex = 166
        Me.Label14.Text = "Strength:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(338, 204)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 21)
        Me.Label15.TabIndex = 165
        Me.Label15.Text = "Type:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(34, 130)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 21)
        Me.Label17.TabIndex = 163
        Me.Label17.Text = "Medication:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(23, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(170, 25)
        Me.Label18.TabIndex = 158
        Me.Label18.Text = "New Prescription:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.txtPatientDOB)
        Me.Panel5.Location = New System.Drawing.Point(707, 76)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(171, 31)
        Me.Panel5.TabIndex = 2
        '
        'txtPatientDOB
        '
        Me.txtPatientDOB.BackColor = System.Drawing.Color.White
        Me.txtPatientDOB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPatientDOB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPatientDOB.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientDOB.Location = New System.Drawing.Point(1, 1)
        Me.txtPatientDOB.Multiline = True
        Me.txtPatientDOB.Name = "txtPatientDOB"
        Me.txtPatientDOB.ReadOnly = True
        Me.txtPatientDOB.ShortcutsEnabled = False
        Me.txtPatientDOB.Size = New System.Drawing.Size(169, 29)
        Me.txtPatientDOB.TabIndex = 38
        Me.txtPatientDOB.TabStop = False
        '
        'btnORder
        '
        Me.btnORder.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnORder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnORder.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnORder.ForeColor = System.Drawing.Color.White
        Me.btnORder.Image = CType(resources.GetObject("btnORder.Image"), System.Drawing.Image)
        Me.btnORder.Location = New System.Drawing.Point(343, 387)
        Me.btnORder.Name = "btnORder"
        Me.btnORder.Size = New System.Drawing.Size(214, 38)
        Me.btnORder.TabIndex = 11
        Me.btnORder.Text = " ORDER PRESCRIPTION"
        Me.btnORder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnORder.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.txtType)
        Me.Panel3.Location = New System.Drawing.Point(343, 229)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(215, 31)
        Me.Panel3.TabIndex = 7
        '
        'txtType
        '
        Me.txtType.BackColor = System.Drawing.Color.White
        Me.txtType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtType.Location = New System.Drawing.Point(1, 1)
        Me.txtType.Multiline = True
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.ShortcutsEnabled = False
        Me.txtType.Size = New System.Drawing.Size(213, 29)
        Me.txtType.TabIndex = 38
        Me.txtType.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.cmbStrength)
        Me.Panel1.Location = New System.Drawing.Point(581, 229)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(298, 31)
        Me.Panel1.TabIndex = 8
        '
        'cmbStrength
        '
        Me.cmbStrength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbStrength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStrength.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStrength.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStrength.FormattingEnabled = True
        Me.cmbStrength.Location = New System.Drawing.Point(1, 1)
        Me.cmbStrength.Name = "cmbStrength"
        Me.cmbStrength.Size = New System.Drawing.Size(296, 29)
        Me.cmbStrength.TabIndex = 0
        Me.cmbStrength.Tag = "cmbFrequencyNumber"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.cmbFrequencyNumber)
        Me.Panel4.Location = New System.Drawing.Point(39, 306)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel4.Size = New System.Drawing.Size(172, 31)
        Me.Panel4.TabIndex = 9
        '
        'cmbFrequencyNumber
        '
        Me.cmbFrequencyNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbFrequencyNumber.DropDownHeight = 200
        Me.cmbFrequencyNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFrequencyNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFrequencyNumber.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFrequencyNumber.FormattingEnabled = True
        Me.cmbFrequencyNumber.IntegralHeight = False
        Me.cmbFrequencyNumber.Location = New System.Drawing.Point(1, 1)
        Me.cmbFrequencyNumber.Name = "cmbFrequencyNumber"
        Me.cmbFrequencyNumber.Size = New System.Drawing.Size(170, 29)
        Me.cmbFrequencyNumber.TabIndex = 0
        Me.cmbFrequencyNumber.Tag = "cmbFrequencyNumber"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkGray
        Me.Panel6.Controls.Add(Me.cmbMedication)
        Me.Panel6.Location = New System.Drawing.Point(38, 153)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel6.Size = New System.Drawing.Size(840, 31)
        Me.Panel6.TabIndex = 3
        '
        'cmbMedication
        '
        Me.cmbMedication.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbMedication.DropDownHeight = 250
        Me.cmbMedication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMedication.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedication.FormattingEnabled = True
        Me.cmbMedication.IntegralHeight = False
        Me.cmbMedication.ItemHeight = 21
        Me.cmbMedication.Location = New System.Drawing.Point(1, 1)
        Me.cmbMedication.Name = "cmbMedication"
        Me.cmbMedication.Size = New System.Drawing.Size(838, 29)
        Me.cmbMedication.TabIndex = 0
        Me.cmbMedication.Tag = ""
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGray
        Me.Panel7.Controls.Add(Me.cmbOrderedBy)
        Me.Panel7.Location = New System.Drawing.Point(236, 306)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel7.Size = New System.Drawing.Size(642, 31)
        Me.Panel7.TabIndex = 10
        '
        'cmbOrderedBy
        '
        Me.cmbOrderedBy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbOrderedBy.DropDownHeight = 200
        Me.cmbOrderedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOrderedBy.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrderedBy.FormattingEnabled = True
        Me.cmbOrderedBy.IntegralHeight = False
        Me.cmbOrderedBy.Location = New System.Drawing.Point(1, 1)
        Me.cmbOrderedBy.Name = "cmbOrderedBy"
        Me.cmbOrderedBy.Size = New System.Drawing.Size(640, 29)
        Me.cmbOrderedBy.TabIndex = 0
        Me.cmbOrderedBy.Tag = ""
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Controls.Add(Me.cmbPatientName)
        Me.Panel8.Location = New System.Drawing.Point(38, 76)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel8.Size = New System.Drawing.Size(650, 31)
        Me.Panel8.TabIndex = 1
        '
        'cmbPatientName
        '
        Me.cmbPatientName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPatientName.DropDownHeight = 250
        Me.cmbPatientName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPatientName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPatientName.FormattingEnabled = True
        Me.cmbPatientName.IntegralHeight = False
        Me.cmbPatientName.ItemHeight = 21
        Me.cmbPatientName.Location = New System.Drawing.Point(1, 1)
        Me.cmbPatientName.Name = "cmbPatientName"
        Me.cmbPatientName.Size = New System.Drawing.Size(648, 29)
        Me.cmbPatientName.TabIndex = 0
        Me.cmbPatientName.Tag = ""
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.White
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(1, 1)
        Me.txtQuantity.MaxLength = 6
        Me.txtQuantity.Multiline = True
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ShortcutsEnabled = False
        Me.txtQuantity.Size = New System.Drawing.Size(170, 28)
        Me.txtQuantity.TabIndex = 176
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.Color.White
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(1, 1)
        Me.txtUnit.MaxLength = 8
        Me.txtUnit.Multiline = True
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ShortcutsEnabled = False
        Me.txtUnit.Size = New System.Drawing.Size(83, 29)
        Me.txtUnit.TabIndex = 178
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.txtQuantity)
        Me.Panel2.Location = New System.Drawing.Point(39, 230)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(172, 30)
        Me.Panel2.TabIndex = 4
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DarkGray
        Me.Panel9.Controls.Add(Me.txtUnit)
        Me.Panel9.Location = New System.Drawing.Point(235, 229)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel9.Size = New System.Drawing.Size(85, 31)
        Me.Panel9.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 21)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Amount:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(230, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 21)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Unit:"
        '
        'frmPharmacy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 645)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.btnORder)
        Me.Name = "frmPharmacy"
        Me.Tag = "6"
        Me.Text = "frmPharmacy"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDispense As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtPatientDOB As TextBox
    Friend WithEvents btnORder As Button
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtType As TextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbStrength As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents cmbMedication As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbFrequencyNumber As ComboBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents cmbOrderedBy As ComboBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents cmbPatientName As ComboBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
