<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgressBar
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
        Me.components = New System.ComponentModel.Container()
        Me.tmTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblMessageUpdate = New System.Windows.Forms.Label()
        Me.lblPleaseWait = New System.Windows.Forms.Label()
        Me.pbLoading = New System.Windows.Forms.PictureBox()
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmTimer
        '
        Me.tmTimer.Enabled = True
        '
        'lblMessageUpdate
        '
        Me.lblMessageUpdate.AutoSize = True
        Me.lblMessageUpdate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessageUpdate.ForeColor = System.Drawing.Color.White
        Me.lblMessageUpdate.Location = New System.Drawing.Point(95, 39)
        Me.lblMessageUpdate.Name = "lblMessageUpdate"
        Me.lblMessageUpdate.Size = New System.Drawing.Size(0, 17)
        Me.lblMessageUpdate.TabIndex = 1
        '
        'lblPleaseWait
        '
        Me.lblPleaseWait.AutoSize = True
        Me.lblPleaseWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPleaseWait.ForeColor = System.Drawing.Color.White
        Me.lblPleaseWait.Location = New System.Drawing.Point(91, 12)
        Me.lblPleaseWait.Name = "lblPleaseWait"
        Me.lblPleaseWait.Size = New System.Drawing.Size(186, 25)
        Me.lblPleaseWait.TabIndex = 3
        Me.lblPleaseWait.Text = "Loading, Please Wait"
        '
        'pbLoading
        '
        Me.pbLoading.BackColor = System.Drawing.Color.Transparent
        Me.pbLoading.Image = Global.test_gui.My.Resources.Resources.pillLoading
        Me.pbLoading.InitialImage = Nothing
        Me.pbLoading.Location = New System.Drawing.Point(12, 12)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(69, 63)
        Me.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLoading.TabIndex = 2
        Me.pbLoading.TabStop = False
        '
        'frmProgressBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(416, 87)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblPleaseWait)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.lblMessageUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProgressBar"
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmTimer As Timer
    Friend WithEvents lblMessageUpdate As Label
    Friend WithEvents pbLoading As PictureBox
    Friend WithEvents lblPleaseWait As Label
End Class
