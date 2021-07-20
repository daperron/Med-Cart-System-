<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenedDrawer
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReOpen = New System.Windows.Forms.Button()
        Me.pnlDrawer = New System.Windows.Forms.Panel()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.lblReopen = New System.Windows.Forms.Label()
        Me.lblDrawerNumber = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(193, 140)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 53)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close Drawer"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReOpen
        '
        Me.btnReOpen.Location = New System.Drawing.Point(193, 208)
        Me.btnReOpen.Name = "btnReOpen"
        Me.btnReOpen.Size = New System.Drawing.Size(127, 53)
        Me.btnReOpen.TabIndex = 2
        Me.btnReOpen.Text = "Reopen Drawer"
        Me.btnReOpen.UseVisualStyleBackColor = True
        '
        'pnlDrawer
        '
        Me.pnlDrawer.Location = New System.Drawing.Point(-2, 0)
        Me.pnlDrawer.Name = "pnlDrawer"
        Me.pnlDrawer.Size = New System.Drawing.Size(515, 34)
        Me.pnlDrawer.TabIndex = 3
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblClose.Location = New System.Drawing.Point(24, 63)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(469, 21)
        Me.lblClose.TabIndex = 0
        Me.lblClose.Text = "If the drawer is closed and you see this form, click close drawer"
        '
        'lblReopen
        '
        Me.lblReopen.AutoSize = True
        Me.lblReopen.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblReopen.Location = New System.Drawing.Point(81, 99)
        Me.lblReopen.Name = "lblReopen"
        Me.lblReopen.Size = New System.Drawing.Size(351, 21)
        Me.lblReopen.TabIndex = 4
        Me.lblReopen.Text = "If the drawer will not close click reopen drawer"
        '
        'lblDrawerNumber
        '
        Me.lblDrawerNumber.AutoSize = True
        Me.lblDrawerNumber.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDrawerNumber.Location = New System.Drawing.Point(186, 37)
        Me.lblDrawerNumber.Name = "lblDrawerNumber"
        Me.lblDrawerNumber.Size = New System.Drawing.Size(141, 21)
        Me.lblDrawerNumber.TabIndex = 5
        Me.lblDrawerNumber.Text = "Drawer 24 is open"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(22, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(469, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "If the drawer is closed and you see this form, click close drawer"
        '
        'frmOpenedDrawer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 286)
        Me.Controls.Add(Me.lblDrawerNumber)
        Me.Controls.Add(Me.lblReopen)
        Me.Controls.Add(Me.pnlDrawer)
        Me.Controls.Add(Me.btnReOpen)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOpenedDrawer"
        Me.Text = "frmOpenedDrawer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents btnReOpen As Button
    Friend WithEvents pnlDrawer As Panel
    Friend WithEvents lblClose As Label
    Friend WithEvents lblReopen As Label
    Friend WithEvents lblDrawerNumber As Label
    Friend WithEvents Label2 As Label
End Class
