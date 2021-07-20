<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport))
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.cmbReports = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnGenerateReport.FlatAppearance.BorderSize = 0
        Me.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateReport.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReport.ForeColor = System.Drawing.Color.White
        Me.btnGenerateReport.Image = CType(resources.GetObject("btnGenerateReport.Image"), System.Drawing.Image)
        Me.btnGenerateReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerateReport.Location = New System.Drawing.Point(566, 12)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(188, 35)
        Me.btnGenerateReport.TabIndex = 47
        Me.btnGenerateReport.Text = "Generate Report"
        Me.btnGenerateReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGenerateReport.UseVisualStyleBackColor = False
        '
        'cmbReports
        '
        Me.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReports.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReports.FormattingEnabled = True
        Me.cmbReports.Location = New System.Drawing.Point(118, 17)
        Me.cmbReports.Name = "cmbReports"
        Me.cmbReports.Size = New System.Drawing.Size(243, 29)
        Me.cmbReports.Sorted = True
        Me.cmbReports.TabIndex = 166
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 21)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "Select Report:"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToOrderColumns = True
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(13, 65)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(965, 458)
        Me.dgvReport.TabIndex = 168
        Me.dgvReport.Visible = False
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnExportToExcel.FlatAppearance.BorderSize = 0
        Me.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportToExcel.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportToExcel.ForeColor = System.Drawing.Color.White
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportToExcel.Location = New System.Drawing.Point(790, 12)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(188, 35)
        Me.btnExportToExcel.TabIndex = 169
        Me.btnExportToExcel.Text = "Export To Excel"
        Me.btnExportToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportToExcel.UseVisualStyleBackColor = False
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(990, 535)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.cmbReports)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnGenerateReport)
        Me.Name = "frmReport"
        Me.Text = "frmReport"
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents cmbReports As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents btnExportToExcel As Button
End Class
