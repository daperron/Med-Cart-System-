<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDiscrepancies
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
        Me.flpDiscrepancies = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblDiscrepancyID = New System.Windows.Forms.Label()
        Me.lblActualCount = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblExpectedCount = New System.Windows.Forms.Label()
        Me.lblMedication = New System.Windows.Forms.Label()
        Me.lblDrawer = New System.Windows.Forms.Label()
        Me.pnlHeaderPatientRecords = New System.Windows.Forms.Panel()
        Me.btnResolve = New System.Windows.Forms.Button()
        Me.tpLabelHover = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlHeaderPatientRecords.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpDiscrepancies
        '
        Me.flpDiscrepancies.AutoScroll = True
        Me.flpDiscrepancies.BackColor = System.Drawing.Color.White
        Me.flpDiscrepancies.Location = New System.Drawing.Point(12, 105)
        Me.flpDiscrepancies.Name = "flpDiscrepancies"
        Me.flpDiscrepancies.Size = New System.Drawing.Size(901, 430)
        Me.flpDiscrepancies.TabIndex = 43
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblDiscrepancyID)
        Me.pnlHeader.Controls.Add(Me.lblActualCount)
        Me.pnlHeader.Controls.Add(Me.lblDateTime)
        Me.pnlHeader.Controls.Add(Me.lblExpectedCount)
        Me.pnlHeader.Controls.Add(Me.lblMedication)
        Me.pnlHeader.Controls.Add(Me.lblDrawer)
        Me.pnlHeader.Location = New System.Drawing.Point(12, 54)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(901, 47)
        Me.pnlHeader.TabIndex = 42
        '
        'lblDiscrepancyID
        '
        Me.lblDiscrepancyID.AutoSize = True
        Me.lblDiscrepancyID.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscrepancyID.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDiscrepancyID.Location = New System.Drawing.Point(7, 16)
        Me.lblDiscrepancyID.Name = "lblDiscrepancyID"
        Me.lblDiscrepancyID.Size = New System.Drawing.Size(26, 21)
        Me.lblDiscrepancyID.TabIndex = 11
        Me.lblDiscrepancyID.Tag = "1"
        Me.lblDiscrepancyID.Text = "ID"
        '
        'lblActualCount
        '
        Me.lblActualCount.AutoSize = True
        Me.lblActualCount.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblActualCount.Location = New System.Drawing.Point(541, 16)
        Me.lblActualCount.Name = "lblActualCount"
        Me.lblActualCount.Size = New System.Drawing.Size(104, 21)
        Me.lblActualCount.TabIndex = 10
        Me.lblActualCount.Tag = "5"
        Me.lblActualCount.Text = "Actual Count"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDateTime.Location = New System.Drawing.Point(687, 16)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(179, 21)
        Me.lblDateTime.TabIndex = 5
        Me.lblDateTime.Tag = "6"
        Me.lblDateTime.Text = "Discrepancy Date/Time"
        '
        'lblExpectedCount
        '
        Me.lblExpectedCount.AutoSize = True
        Me.lblExpectedCount.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpectedCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblExpectedCount.Location = New System.Drawing.Point(362, 16)
        Me.lblExpectedCount.Name = "lblExpectedCount"
        Me.lblExpectedCount.Size = New System.Drawing.Size(126, 21)
        Me.lblExpectedCount.TabIndex = 2
        Me.lblExpectedCount.Tag = "4"
        Me.lblExpectedCount.Text = "Expected Count"
        '
        'lblMedication
        '
        Me.lblMedication.AutoSize = True
        Me.lblMedication.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedication.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblMedication.Location = New System.Drawing.Point(73, 16)
        Me.lblMedication.Name = "lblMedication"
        Me.lblMedication.Size = New System.Drawing.Size(93, 21)
        Me.lblMedication.TabIndex = 8
        Me.lblMedication.Tag = "2"
        Me.lblMedication.Text = "Medication"
        '
        'lblDrawer
        '
        Me.lblDrawer.AutoSize = True
        Me.lblDrawer.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDrawer.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDrawer.Location = New System.Drawing.Point(249, 16)
        Me.lblDrawer.Name = "lblDrawer"
        Me.lblDrawer.Size = New System.Drawing.Size(62, 21)
        Me.lblDrawer.TabIndex = 9
        Me.lblDrawer.Tag = "3"
        Me.lblDrawer.Text = "Drawer"
        '
        'pnlHeaderPatientRecords
        '
        Me.pnlHeaderPatientRecords.BackColor = System.Drawing.Color.White
        Me.pnlHeaderPatientRecords.Controls.Add(Me.Label1)
        Me.pnlHeaderPatientRecords.Controls.Add(Me.Label3)
        Me.pnlHeaderPatientRecords.Controls.Add(Me.btnResolve)
        Me.pnlHeaderPatientRecords.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderPatientRecords.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderPatientRecords.Name = "pnlHeaderPatientRecords"
        Me.pnlHeaderPatientRecords.Size = New System.Drawing.Size(929, 51)
        Me.pnlHeaderPatientRecords.TabIndex = 41
        '
        'btnResolve
        '
        Me.btnResolve.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnResolve.FlatAppearance.BorderSize = 0
        Me.btnResolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResolve.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResolve.ForeColor = System.Drawing.Color.White
        Me.btnResolve.Image = Global.test_gui.My.Resources.Resources.resolve
        Me.btnResolve.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnResolve.Location = New System.Drawing.Point(793, 12)
        Me.btnResolve.Name = "btnResolve"
        Me.btnResolve.Size = New System.Drawing.Size(120, 35)
        Me.btnResolve.TabIndex = 49
        Me.btnResolve.Text = "  Resolve"
        Me.btnResolve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnResolve.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(18, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 25)
        Me.Label3.TabIndex = 52
        Me.Label3.Tag = "1"
        Me.Label3.Text = "Active Discrepancies: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(580, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 21)
        Me.Label1.TabIndex = 53
        Me.Label1.Tag = "5"
        Me.Label1.Text = "Hover here for instructions"
        Me.tpLabelHover.SetToolTip(Me.Label1, "1. Select a discrepancy you would like to resolve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Press the Resolve button in" &
        " order to enter an explanation")
        '
        'frmDiscrepancies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(929, 561)
        Me.Controls.Add(Me.flpDiscrepancies)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlHeaderPatientRecords)
        Me.Name = "frmDiscrepancies"
        Me.Text = "frmDiscrepancies"
        Me.tpLabelHover.SetToolTip(Me, "1. Select a discrepancy you would like to resolve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Press the Resolve button in" &
        " order to enter an explanation")
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlHeaderPatientRecords.ResumeLayout(False)
        Me.pnlHeaderPatientRecords.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpDiscrepancies As FlowLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblExpectedCount As Label
    Friend WithEvents pnlHeaderPatientRecords As Panel
    Friend WithEvents lblMedication As Label
    Friend WithEvents lblDrawer As Label
    Friend WithEvents lblActualCount As Label
    Friend WithEvents btnResolve As Button
    Friend WithEvents lblDiscrepancyID As Label
    Friend WithEvents tpLabelHover As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
