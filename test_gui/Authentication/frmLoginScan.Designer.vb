<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginScan))
        Me.lblSoftwareName = New System.Windows.Forms.Label()
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.lblBadge = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblForgotID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.panelTopBar = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.startUpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlSplash = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblVersionNumber = New System.Windows.Forms.Label()
        Me.lblApplicationName = New System.Windows.Forms.Label()
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.pnlSoftwareLogo = New System.Windows.Forms.Panel()
        Me.pnlLogin.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.panelTopBar.SuspendLayout()
        Me.pnlSplash.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSoftwareName
        '
        Me.lblSoftwareName.AutoSize = True
        Me.lblSoftwareName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoftwareName.ForeColor = System.Drawing.Color.White
        Me.lblSoftwareName.Location = New System.Drawing.Point(288, 104)
        Me.lblSoftwareName.Name = "lblSoftwareName"
        Me.lblSoftwareName.Size = New System.Drawing.Size(87, 21)
        Me.lblSoftwareName.TabIndex = 11
        Me.lblSoftwareName.Text = "MedServe"
        '
        'pnlLogin
        '
        Me.pnlLogin.BackColor = System.Drawing.Color.White
        Me.pnlLogin.Controls.Add(Me.lblBadge)
        Me.pnlLogin.Controls.Add(Me.btnLogin)
        Me.pnlLogin.Controls.Add(Me.lblForgotID)
        Me.pnlLogin.Controls.Add(Me.Label2)
        Me.pnlLogin.Controls.Add(Me.Panel3)
        Me.pnlLogin.Location = New System.Drawing.Point(166, 137)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(332, 232)
        Me.pnlLogin.TabIndex = 10
        '
        'lblBadge
        '
        Me.lblBadge.AutoSize = True
        Me.lblBadge.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBadge.ForeColor = System.Drawing.Color.Black
        Me.lblBadge.Location = New System.Drawing.Point(100, 179)
        Me.lblBadge.Name = "lblBadge"
        Me.lblBadge.Size = New System.Drawing.Size(127, 17)
        Me.lblBadge.TabIndex = 16
        Me.lblBadge.Text = "Login with Password"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(51, 126)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(236, 40)
        Me.btnLogin.TabIndex = 15
        Me.btnLogin.TabStop = False
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lblForgotID
        '
        Me.lblForgotID.AutoSize = True
        Me.lblForgotID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgotID.ForeColor = System.Drawing.Color.Black
        Me.lblForgotID.Location = New System.Drawing.Point(115, 132)
        Me.lblForgotID.Name = "lblForgotID"
        Me.lblForgotID.Size = New System.Drawing.Size(101, 17)
        Me.lblForgotID.TabIndex = 14
        Me.lblForgotID.Text = "Forgot ID Card?"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(105, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 25)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Scan ID Card"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel3.Controls.Add(Me.txtBarcode)
        Me.Panel3.Location = New System.Drawing.Point(51, 93)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(236, 24)
        Me.Panel3.TabIndex = 8
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.txtBarcode.Location = New System.Drawing.Point(1, 1)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ShortcutsEnabled = False
        Me.txtBarcode.Size = New System.Drawing.Size(234, 22)
        Me.txtBarcode.TabIndex = 2
        Me.txtBarcode.Tag = "SVSU ID"
        Me.txtBarcode.UseSystemPasswordChar = True
        '
        'panelTopBar
        '
        Me.panelTopBar.Controls.Add(Me.btnClose)
        Me.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTopBar.Location = New System.Drawing.Point(0, 0)
        Me.panelTopBar.Name = "panelTopBar"
        Me.panelTopBar.Size = New System.Drawing.Size(664, 28)
        Me.panelTopBar.TabIndex = 12
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(624, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 28)
        Me.btnClose.TabIndex = 0
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'startUpTimer
        '
        '
        'pnlSplash
        '
        Me.pnlSplash.BackColor = System.Drawing.Color.White
        Me.pnlSplash.Controls.Add(Me.PictureBox1)
        Me.pnlSplash.Controls.Add(Me.lblVersionNumber)
        Me.pnlSplash.Controls.Add(Me.lblApplicationName)
        Me.pnlSplash.Controls.Add(Me.pnlLogo)
        Me.pnlSplash.Location = New System.Drawing.Point(517, 252)
        Me.pnlSplash.Name = "pnlSplash"
        Me.pnlSplash.Size = New System.Drawing.Size(332, 232)
        Me.pnlSplash.TabIndex = 13
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(149, 176)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'lblVersionNumber
        '
        Me.lblVersionNumber.AutoSize = True
        Me.lblVersionNumber.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblVersionNumber.Location = New System.Drawing.Point(80, 138)
        Me.lblVersionNumber.Name = "lblVersionNumber"
        Me.lblVersionNumber.Size = New System.Drawing.Size(104, 25)
        Me.lblVersionNumber.TabIndex = 16
        Me.lblVersionNumber.Text = "Version 1.0"
        '
        'lblApplicationName
        '
        Me.lblApplicationName.AutoSize = True
        Me.lblApplicationName.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplicationName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblApplicationName.Location = New System.Drawing.Point(99, 90)
        Me.lblApplicationName.Name = "lblApplicationName"
        Me.lblApplicationName.Size = New System.Drawing.Size(135, 37)
        Me.lblApplicationName.TabIndex = 15
        Me.lblApplicationName.Text = "MedServe"
        '
        'pnlLogo
        '
        Me.pnlLogo.BackgroundImage = CType(resources.GetObject("pnlLogo.BackgroundImage"), System.Drawing.Image)
        Me.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLogo.Location = New System.Drawing.Point(134, 27)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New System.Drawing.Size(60, 60)
        Me.pnlLogo.TabIndex = 14
        '
        'pnlSoftwareLogo
        '
        Me.pnlSoftwareLogo.BackgroundImage = Global.test_gui.My.Resources.Resources.MicrosoftTeams_image__4_
        Me.pnlSoftwareLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSoftwareLogo.Location = New System.Drawing.Point(278, 18)
        Me.pnlSoftwareLogo.Name = "pnlSoftwareLogo"
        Me.pnlSoftwareLogo.Size = New System.Drawing.Size(104, 89)
        Me.pnlSoftwareLogo.TabIndex = 14
        '
        'frmLoginScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(664, 496)
        Me.Controls.Add(Me.pnlSoftwareLogo)
        Me.Controls.Add(Me.pnlSplash)
        Me.Controls.Add(Me.panelTopBar)
        Me.Controls.Add(Me.lblSoftwareName)
        Me.Controls.Add(Me.pnlLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoginScan"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.panelTopBar.ResumeLayout(False)
        Me.pnlSplash.ResumeLayout(False)
        Me.pnlSplash.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSoftwareName As Label
    Friend WithEvents pnlLogin As Panel
    Friend WithEvents lblForgotID As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblBadge As Label
    Friend WithEvents panelTopBar As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents startUpTimer As Timer
    Friend WithEvents pnlSplash As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblVersionNumber As Label
    Friend WithEvents lblApplicationName As Label
    Friend WithEvents pnlLogo As Panel
    Friend WithEvents pnlSoftwareLogo As Panel
End Class
