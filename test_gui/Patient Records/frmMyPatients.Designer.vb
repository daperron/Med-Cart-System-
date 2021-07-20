<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMyPatients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMyPatients))
        Me.flpMyPatientRecords = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlHeaderPatientRecords = New System.Windows.Forms.Panel()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblAssignment = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblBed = New System.Windows.Forms.Label()
        Me.lblRoom = New System.Windows.Forms.Label()
        Me.lblMRN = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.tpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlHeaderPatientRecords.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpMyPatientRecords
        '
        Me.flpMyPatientRecords.AutoScroll = True
        Me.flpMyPatientRecords.BackColor = System.Drawing.Color.White
        Me.flpMyPatientRecords.Location = New System.Drawing.Point(15, 120)
        Me.flpMyPatientRecords.Name = "flpMyPatientRecords"
        Me.flpMyPatientRecords.Size = New System.Drawing.Size(1064, 512)
        Me.flpMyPatientRecords.TabIndex = 20
        '
        'pnlHeaderPatientRecords
        '
        Me.pnlHeaderPatientRecords.BackColor = System.Drawing.Color.White
        Me.pnlHeaderPatientRecords.Controls.Add(Me.lblFilter)
        Me.pnlHeaderPatientRecords.Controls.Add(Me.Panel4)
        Me.pnlHeaderPatientRecords.Controls.Add(Me.Panel9)
        Me.pnlHeaderPatientRecords.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderPatientRecords.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderPatientRecords.Name = "pnlHeaderPatientRecords"
        Me.pnlHeaderPatientRecords.Size = New System.Drawing.Size(1091, 61)
        Me.pnlHeaderPatientRecords.TabIndex = 19
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilter.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblFilter.Location = New System.Drawing.Point(832, 21)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(52, 21)
        Me.lblFilter.TabIndex = 7
        Me.lblFilter.Text = "Filter:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.cboFilter)
        Me.Panel4.Location = New System.Drawing.Point(900, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel4.Size = New System.Drawing.Size(179, 31)
        Me.Panel4.TabIndex = 21
        '
        'cboFilter
        '
        Me.cboFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFilter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Items.AddRange(New Object() {"My Patients", "Active Patients"})
        Me.cboFilter.Location = New System.Drawing.Point(1, 1)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(177, 29)
        Me.cboFilter.TabIndex = 10
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DarkGray
        Me.Panel9.Controls.Add(Me.pnlSearch)
        Me.Panel9.Controls.Add(Me.txtSearch)
        Me.Panel9.Location = New System.Drawing.Point(15, 15)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel9.Size = New System.Drawing.Size(466, 31)
        Me.Panel9.TabIndex = 20
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.BackgroundImage = CType(resources.GetObject("pnlSearch.BackgroundImage"), System.Drawing.Image)
        Me.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearch.ForeColor = System.Drawing.Color.White
        Me.pnlSearch.Location = New System.Drawing.Point(432, 1)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(33, 29)
        Me.pnlSearch.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.Transparent
        Me.btnSearch.Image = Global.test_gui.My.Resources.Resources.Search
        Me.btnSearch.Location = New System.Drawing.Point(3, 0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 29)
        Me.btnSearch.TabIndex = 40
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(1, 1)
        Me.txtSearch.Multiline = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.ShortcutsEnabled = False
        Me.txtSearch.Size = New System.Drawing.Size(431, 29)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.Tag = "Search Patients"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblAssignment)
        Me.pnlHeader.Controls.Add(Me.lblDOB)
        Me.pnlHeader.Controls.Add(Me.lblLastName)
        Me.pnlHeader.Controls.Add(Me.lblBed)
        Me.pnlHeader.Controls.Add(Me.lblRoom)
        Me.pnlHeader.Controls.Add(Me.lblMRN)
        Me.pnlHeader.Controls.Add(Me.lblFirstName)
        Me.pnlHeader.Location = New System.Drawing.Point(15, 69)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1064, 47)
        Me.pnlHeader.TabIndex = 18
        '
        'lblAssignment
        '
        Me.lblAssignment.AutoSize = True
        Me.lblAssignment.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignment.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblAssignment.Location = New System.Drawing.Point(862, 19)
        Me.lblAssignment.Name = "lblAssignment"
        Me.lblAssignment.Size = New System.Drawing.Size(125, 21)
        Me.lblAssignment.TabIndex = 7
        Me.lblAssignment.Text = "Assign/Remove"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDOB.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDOB.Location = New System.Drawing.Point(499, 19)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(43, 21)
        Me.lblDOB.TabIndex = 6
        Me.lblDOB.Text = "DOB"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastName.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblLastName.Location = New System.Drawing.Point(332, 19)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(86, 21)
        Me.lblLastName.TabIndex = 5
        Me.lblLastName.Text = "Last Name"
        '
        'lblBed
        '
        Me.lblBed.AutoSize = True
        Me.lblBed.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBed.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblBed.Location = New System.Drawing.Point(751, 19)
        Me.lblBed.Name = "lblBed"
        Me.lblBed.Size = New System.Drawing.Size(39, 21)
        Me.lblBed.TabIndex = 3
        Me.lblBed.Text = "Bed"
        '
        'lblRoom
        '
        Me.lblRoom.AutoSize = True
        Me.lblRoom.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoom.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblRoom.Location = New System.Drawing.Point(628, 19)
        Me.lblRoom.Name = "lblRoom"
        Me.lblRoom.Size = New System.Drawing.Size(54, 21)
        Me.lblRoom.TabIndex = 2
        Me.lblRoom.Text = "Room"
        '
        'lblMRN
        '
        Me.lblMRN.AutoSize = True
        Me.lblMRN.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMRN.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblMRN.Location = New System.Drawing.Point(13, 19)
        Me.lblMRN.Name = "lblMRN"
        Me.lblMRN.Size = New System.Drawing.Size(47, 21)
        Me.lblMRN.TabIndex = 1
        Me.lblMRN.Text = "MRN"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblFirstName.Location = New System.Drawing.Point(155, 19)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(88, 21)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "First Name"
        '
        'frmMyPatients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 644)
        Me.Controls.Add(Me.flpMyPatientRecords)
        Me.Controls.Add(Me.pnlHeaderPatientRecords)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmMyPatients"
        Me.Text = "frmMyPatients"
        Me.pnlHeaderPatientRecords.ResumeLayout(False)
        Me.pnlHeaderPatientRecords.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpMyPatientRecords As FlowLayoutPanel
    Friend WithEvents pnlHeaderPatientRecords As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblDOB As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblBed As Label
    Friend WithEvents lblRoom As Label
    Friend WithEvents lblMRN As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblFilter As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cboFilter As ComboBox
    Friend WithEvents lblAssignment As Label
    Friend WithEvents tpToolTip As ToolTip
End Class
