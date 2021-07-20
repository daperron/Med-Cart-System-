<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEndOfShift
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEndOfShift))
        Me.flpEndOfShiftCount = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.lblSystemCount = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lblActions = New System.Windows.Forms.Label()
        Me.lblMedication = New System.Windows.Forms.Label()
        Me.lblDrawerNum = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpEndOfShiftCount
        '
        Me.flpEndOfShiftCount.AutoScroll = True
        Me.flpEndOfShiftCount.BackColor = System.Drawing.Color.White
        Me.flpEndOfShiftCount.Location = New System.Drawing.Point(12, 117)
        Me.flpEndOfShiftCount.Name = "flpEndOfShiftCount"
        Me.flpEndOfShiftCount.Size = New System.Drawing.Size(955, 533)
        Me.flpEndOfShiftCount.TabIndex = 19
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblSection)
        Me.pnlHeader.Controls.Add(Me.lblSystemCount)
        Me.pnlHeader.Controls.Add(Me.lblMedication)
        Me.pnlHeader.Controls.Add(Me.lblDrawerNum)
        Me.pnlHeader.Location = New System.Drawing.Point(12, 66)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(658, 47)
        Me.pnlHeader.TabIndex = 18
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSection.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSection.Location = New System.Drawing.Point(435, 19)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(33, 21)
        Me.lblSection.TabIndex = 8
        Me.lblSection.Text = "Bin"
        '
        'lblSystemCount
        '
        Me.lblSystemCount.AutoSize = True
        Me.lblSystemCount.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSystemCount.Location = New System.Drawing.Point(553, 19)
        Me.lblSystemCount.Name = "lblSystemCount"
        Me.lblSystemCount.Size = New System.Drawing.Size(102, 21)
        Me.lblSystemCount.TabIndex = 7
        Me.lblSystemCount.Text = "System Total"
        Me.tpToolTip.SetToolTip(Me.lblSystemCount, "Current system medication amount")
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCount.Location = New System.Drawing.Point(732, 85)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(82, 21)
        Me.lblCount.TabIndex = 6
        Me.lblCount.Text = "New Total"
        Me.tpToolTip.SetToolTip(Me.lblCount, "Please enter the new total amount of the medication in the bin.")
        '
        'lblActions
        '
        Me.lblActions.AutoSize = True
        Me.lblActions.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActions.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblActions.Location = New System.Drawing.Point(866, 85)
        Me.lblActions.Name = "lblActions"
        Me.lblActions.Size = New System.Drawing.Size(65, 21)
        Me.lblActions.TabIndex = 2
        Me.lblActions.Text = "Actions"
        '
        'lblMedication
        '
        Me.lblMedication.AutoSize = True
        Me.lblMedication.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedication.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblMedication.Location = New System.Drawing.Point(10, 19)
        Me.lblMedication.Name = "lblMedication"
        Me.lblMedication.Size = New System.Drawing.Size(93, 21)
        Me.lblMedication.TabIndex = 1
        Me.lblMedication.Text = "Medication"
        '
        'lblDrawerNum
        '
        Me.lblDrawerNum.AutoSize = True
        Me.lblDrawerNum.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDrawerNum.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDrawerNum.Location = New System.Drawing.Point(225, 19)
        Me.lblDrawerNum.Name = "lblDrawerNum"
        Me.lblDrawerNum.Size = New System.Drawing.Size(126, 21)
        Me.lblDrawerNum.TabIndex = 0
        Me.lblDrawerNum.Text = "Drawer Number"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(746, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(221, 37)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "UPDATE INVENTORY"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cmbFilter
        '
        Me.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Items.AddRange(New Object() {"All Medication", "Controlled", "Controlled Non-Narcotic ", "Narcotic", "Non-Controlled"})
        Me.cmbFilter.Location = New System.Drawing.Point(110, 18)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(317, 29)
        Me.cmbFilter.Sorted = True
        Me.cmbFilter.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 21)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "Report Type:"
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblInstructions.Location = New System.Drawing.Point(447, 21)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(207, 21)
        Me.lblInstructions.TabIndex = 168
        Me.lblInstructions.Text = "Hover here for instructions"
        Me.tpToolTip.SetToolTip(Me.lblInstructions, resources.GetString("lblInstructions.ToolTip"))
        '
        'frmEndOfShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1021, 663)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.cmbFilter)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblActions)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.flpEndOfShiftCount)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmEndOfShift"
        Me.Text = "frmEndOfShift"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flpEndOfShiftCount As FlowLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblCount As Label
    Friend WithEvents lblActions As Label
    Friend WithEvents lblMedication As Label
    Friend WithEvents lblDrawerNum As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lblSection As Label
    Friend WithEvents lblSystemCount As Label
    Friend WithEvents cmbFilter As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents tpToolTip As ToolTip
    Friend WithEvents lblInstructions As Label
End Class
