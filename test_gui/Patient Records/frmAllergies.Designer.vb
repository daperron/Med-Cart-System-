<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAllergies
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAllergies))
        Me.flpAllergies = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblActions = New System.Windows.Forms.Label()
        Me.lblAllergyName = New System.Windows.Forms.Label()
        Me.lblAllergyType = New System.Windows.Forms.Label()
        Me.lblSeverity = New System.Windows.Forms.Label()
        Me.cmbSeverity = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddAllergy = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbAllergies = New System.Windows.Forms.ComboBox()
        Me.cmbAllergiesType = New System.Windows.Forms.ComboBox()
        Me.btnAllergyCancel = New System.Windows.Forms.Button()
        Me.btnAllergySave = New System.Windows.Forms.Button()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.tpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpAllergies
        '
        Me.flpAllergies.AutoScroll = True
        Me.flpAllergies.BackColor = System.Drawing.Color.White
        Me.flpAllergies.Location = New System.Drawing.Point(10, 236)
        Me.flpAllergies.Name = "flpAllergies"
        Me.flpAllergies.Size = New System.Drawing.Size(873, 319)
        Me.flpAllergies.TabIndex = 50
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblActions)
        Me.Panel2.Controls.Add(Me.lblAllergyName)
        Me.Panel2.Controls.Add(Me.lblAllergyType)
        Me.Panel2.Controls.Add(Me.lblSeverity)
        Me.Panel2.Location = New System.Drawing.Point(10, 185)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(873, 47)
        Me.Panel2.TabIndex = 49
        '
        'lblActions
        '
        Me.lblActions.AutoSize = True
        Me.lblActions.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActions.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblActions.Location = New System.Drawing.Point(711, 16)
        Me.lblActions.Name = "lblActions"
        Me.lblActions.Size = New System.Drawing.Size(65, 21)
        Me.lblActions.TabIndex = 10
        Me.lblActions.Text = "Actions"
        '
        'lblAllergyName
        '
        Me.lblAllergyName.AutoSize = True
        Me.lblAllergyName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllergyName.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblAllergyName.Location = New System.Drawing.Point(11, 16)
        Me.lblAllergyName.Name = "lblAllergyName"
        Me.lblAllergyName.Size = New System.Drawing.Size(66, 21)
        Me.lblAllergyName.TabIndex = 1
        Me.lblAllergyName.Text = "Allergy "
        '
        'lblAllergyType
        '
        Me.lblAllergyType.AutoSize = True
        Me.lblAllergyType.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllergyType.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblAllergyType.Location = New System.Drawing.Point(475, 16)
        Me.lblAllergyType.Name = "lblAllergyType"
        Me.lblAllergyType.Size = New System.Drawing.Size(45, 21)
        Me.lblAllergyType.TabIndex = 9
        Me.lblAllergyType.Text = "Type"
        '
        'lblSeverity
        '
        Me.lblSeverity.AutoSize = True
        Me.lblSeverity.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeverity.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSeverity.Location = New System.Drawing.Point(234, 16)
        Me.lblSeverity.Name = "lblSeverity"
        Me.lblSeverity.Size = New System.Drawing.Size(109, 21)
        Me.lblSeverity.TabIndex = 0
        Me.lblSeverity.Text = "Severity KU/L"
        '
        'cmbSeverity
        '
        Me.cmbSeverity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSeverity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeverity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSeverity.FormattingEnabled = True
        Me.cmbSeverity.Items.AddRange(New Object() {"Class 1 (0.35-0.7)", "Class 2 (0.71-3.5)", "Class 3 (3.51-17.5)", "Class 4 (17.51-50)", "Class 5 (50.01-100)", "N/A"})
        Me.cmbSeverity.Location = New System.Drawing.Point(604, 118)
        Me.cmbSeverity.Name = "cmbSeverity"
        Me.cmbSeverity.Size = New System.Drawing.Size(282, 29)
        Me.cmbSeverity.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(600, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 21)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Allergy Severity KU/L"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 21)
        Me.Label12.TabIndex = 180
        Me.Label12.Text = "Allergy Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(353, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 21)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Allergy Type:"
        '
        'btnAddAllergy
        '
        Me.btnAddAllergy.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnAddAllergy.FlatAppearance.BorderSize = 0
        Me.btnAddAllergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddAllergy.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAllergy.ForeColor = System.Drawing.Color.White
        Me.btnAddAllergy.Image = CType(resources.GetObject("btnAddAllergy.Image"), System.Drawing.Image)
        Me.btnAddAllergy.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddAllergy.Location = New System.Drawing.Point(739, 6)
        Me.btnAddAllergy.Name = "btnAddAllergy"
        Me.btnAddAllergy.Size = New System.Drawing.Size(146, 37)
        Me.btnAddAllergy.TabIndex = 5
        Me.btnAddAllergy.Text = "Add Allergy"
        Me.btnAddAllergy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddAllergy.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 21)
        Me.Label4.TabIndex = 185
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(129, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(261, 25)
        Me.Label5.TabIndex = 186
        Me.Label5.Text = "Patient Allergy Information:"
        '
        'cmbAllergies
        '
        Me.cmbAllergies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAllergies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAllergies.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAllergies.FormattingEnabled = True
        Me.cmbAllergies.Items.AddRange(New Object() {"Class 1", "Class 2", "Class 3", "Class 4", "Class 5"})
        Me.cmbAllergies.Location = New System.Drawing.Point(10, 118)
        Me.cmbAllergies.Name = "cmbAllergies"
        Me.cmbAllergies.Size = New System.Drawing.Size(286, 29)
        Me.cmbAllergies.TabIndex = 188
        '
        'cmbAllergiesType
        '
        Me.cmbAllergiesType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAllergiesType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAllergiesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAllergiesType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAllergiesType.FormattingEnabled = True
        Me.cmbAllergiesType.Items.AddRange(New Object() {"Food", "Drug", "Insect", "Latex", "Mold", "Pet", "Environmental"})
        Me.cmbAllergiesType.Location = New System.Drawing.Point(357, 118)
        Me.cmbAllergiesType.Name = "cmbAllergiesType"
        Me.cmbAllergiesType.Size = New System.Drawing.Size(194, 29)
        Me.cmbAllergiesType.TabIndex = 190
        '
        'btnAllergyCancel
        '
        Me.btnAllergyCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnAllergyCancel.FlatAppearance.BorderSize = 0
        Me.btnAllergyCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllergyCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllergyCancel.ForeColor = System.Drawing.Color.White
        Me.btnAllergyCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAllergyCancel.Location = New System.Drawing.Point(739, 6)
        Me.btnAllergyCancel.Name = "btnAllergyCancel"
        Me.btnAllergyCancel.Size = New System.Drawing.Size(146, 37)
        Me.btnAllergyCancel.TabIndex = 191
        Me.btnAllergyCancel.Text = "Cancel"
        Me.btnAllergyCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAllergyCancel.UseVisualStyleBackColor = False
        '
        'btnAllergySave
        '
        Me.btnAllergySave.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnAllergySave.FlatAppearance.BorderSize = 0
        Me.btnAllergySave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllergySave.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllergySave.ForeColor = System.Drawing.Color.White
        Me.btnAllergySave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAllergySave.Location = New System.Drawing.Point(586, 6)
        Me.btnAllergySave.Name = "btnAllergySave"
        Me.btnAllergySave.Size = New System.Drawing.Size(146, 37)
        Me.btnAllergySave.TabIndex = 192
        Me.btnAllergySave.Text = "Save"
        Me.btnAllergySave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAllergySave.UseVisualStyleBackColor = False
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.Controls.Add(Me.btnBack)
        Me.Panel13.Controls.Add(Me.btnAllergySave)
        Me.Panel13.Controls.Add(Me.btnAllergyCancel)
        Me.Panel13.Controls.Add(Me.btnAddAllergy)
        Me.Panel13.Controls.Add(Me.Label5)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(926, 46)
        Me.Panel13.TabIndex = 193
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
        Me.btnBack.TabIndex = 61
        Me.btnBack.Text = "Back"
        Me.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClear.Location = New System.Drawing.Point(739, 53)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(146, 37)
        Me.btnClear.TabIndex = 194
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = False
        Me.btnClear.Visible = False
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAction.Location = New System.Drawing.Point(5, 58)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(151, 21)
        Me.lblAction.TabIndex = 193
        Me.lblAction.Text = "Add a new allergy:"
        '
        'frmAllergies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 567)
        Me.Controls.Add(Me.lblAction)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.cmbAllergiesType)
        Me.Controls.Add(Me.cmbAllergies)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbSeverity)
        Me.Controls.Add(Me.flpAllergies)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmAllergies"
        Me.Text = "frmAllergies"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flpAllergies As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblAllergyName As Label
    Friend WithEvents lblAllergyType As Label
    Friend WithEvents lblSeverity As Label
    Friend WithEvents cmbSeverity As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAddAllergy As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblActions As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbAllergies As ComboBox
    Friend WithEvents cmbAllergiesType As ComboBox
    Friend WithEvents btnAllergyCancel As Button
    Friend WithEvents btnAllergySave As Button
    Friend WithEvents Panel13 As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents tpToolTip As ToolTip
    Friend WithEvents btnClear As Button
    Friend WithEvents lblAction As Label
End Class
