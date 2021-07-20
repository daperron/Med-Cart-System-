<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResolve
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResolve))
        Me.txtResolved = New System.Windows.Forms.TextBox()
        Me.lblDiscrepancyHeader = New System.Windows.Forms.Label()
        Me.btnResolve = New System.Windows.Forms.Button()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtResolved
        '
        Me.txtResolved.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResolved.Location = New System.Drawing.Point(11, 85)
        Me.txtResolved.Multiline = True
        Me.txtResolved.Name = "txtResolved"
        Me.txtResolved.ShortcutsEnabled = False
        Me.txtResolved.Size = New System.Drawing.Size(358, 119)
        Me.txtResolved.TabIndex = 0
        '
        'lblDiscrepancyHeader
        '
        Me.lblDiscrepancyHeader.AutoSize = True
        Me.lblDiscrepancyHeader.BackColor = System.Drawing.Color.White
        Me.lblDiscrepancyHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscrepancyHeader.Location = New System.Drawing.Point(114, 54)
        Me.lblDiscrepancyHeader.Name = "lblDiscrepancyHeader"
        Me.lblDiscrepancyHeader.Size = New System.Drawing.Size(153, 21)
        Me.lblDiscrepancyHeader.TabIndex = 92
        Me.lblDiscrepancyHeader.Text = "Reason For Closing "
        '
        'btnResolve
        '
        Me.btnResolve.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnResolve.FlatAppearance.BorderSize = 0
        Me.btnResolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResolve.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResolve.ForeColor = System.Drawing.Color.White
        Me.btnResolve.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnResolve.Location = New System.Drawing.Point(126, 219)
        Me.btnResolve.Name = "btnResolve"
        Me.btnResolve.Size = New System.Drawing.Size(129, 39)
        Me.btnResolve.TabIndex = 93
        Me.btnResolve.Text = "Resolve"
        Me.btnResolve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnResolve.UseVisualStyleBackColor = False
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.Controls.Add(Me.btnBack)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(409, 46)
        Me.Panel13.TabIndex = 194
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
        'frmResolve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(409, 324)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.btnResolve)
        Me.Controls.Add(Me.lblDiscrepancyHeader)
        Me.Controls.Add(Me.txtResolved)
        Me.Name = "frmResolve"
        Me.Text = "frmResolve"
        Me.Panel13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtResolved As TextBox
    Friend WithEvents lblDiscrepancyHeader As Label
    Friend WithEvents btnResolve As Button
    Friend WithEvents Panel13 As Panel
    Friend WithEvents btnBack As Button
End Class
