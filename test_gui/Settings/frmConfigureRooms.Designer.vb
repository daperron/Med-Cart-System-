<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfigureRooms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigureRooms))
        Me.lblChooseAction = New System.Windows.Forms.Label()
        Me.rdoAddRoomBed = New System.Windows.Forms.RadioButton()
        Me.rdoDeleteRoomBed = New System.Windows.Forms.RadioButton()
        Me.pnlDelete = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDeleteBed = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lstBeds = New System.Windows.Forms.ListBox()
        Me.lblDeleteBedName = New System.Windows.Forms.Label()
        Me.btnDeleteRoom = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lstRooms = New System.Windows.Forms.ListBox()
        Me.lblDeleteRoomName = New System.Windows.Forms.Label()
        Me.lblDeleteInstructions = New System.Windows.Forms.Label()
        Me.lblDetailedInstructions = New System.Windows.Forms.Label()
        Me.pnlAdd = New System.Windows.Forms.Panel()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.rdoYes = New System.Windows.Forms.RadioButton()
        Me.lblAddMoreBeds = New System.Windows.Forms.Label()
        Me.lblDetailAddInstruc = New System.Windows.Forms.Label()
        Me.lblDeleteIns = New System.Windows.Forms.Label()
        Me.lblAddBed = New System.Windows.Forms.Label()
        Me.lblAddRoom = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtBed = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtRoom = New System.Windows.Forms.TextBox()
        Me.pnlDelete.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlAdd.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblChooseAction
        '
        Me.lblChooseAction.AutoSize = True
        Me.lblChooseAction.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblChooseAction.Location = New System.Drawing.Point(11, 0)
        Me.lblChooseAction.Name = "lblChooseAction"
        Me.lblChooseAction.Size = New System.Drawing.Size(218, 21)
        Me.lblChooseAction.TabIndex = 181
        Me.lblChooseAction.Text = "Choose an action to complete:"
        '
        'rdoAddRoomBed
        '
        Me.rdoAddRoomBed.AutoSize = True
        Me.rdoAddRoomBed.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rdoAddRoomBed.Location = New System.Drawing.Point(15, 24)
        Me.rdoAddRoomBed.Name = "rdoAddRoomBed"
        Me.rdoAddRoomBed.Size = New System.Drawing.Size(174, 25)
        Me.rdoAddRoomBed.TabIndex = 182
        Me.rdoAddRoomBed.TabStop = True
        Me.rdoAddRoomBed.Text = "Add a Room and Bed"
        Me.rdoAddRoomBed.UseVisualStyleBackColor = True
        '
        'rdoDeleteRoomBed
        '
        Me.rdoDeleteRoomBed.AutoSize = True
        Me.rdoDeleteRoomBed.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rdoDeleteRoomBed.Location = New System.Drawing.Point(216, 24)
        Me.rdoDeleteRoomBed.Name = "rdoDeleteRoomBed"
        Me.rdoDeleteRoomBed.Size = New System.Drawing.Size(179, 25)
        Me.rdoDeleteRoomBed.TabIndex = 183
        Me.rdoDeleteRoomBed.TabStop = True
        Me.rdoDeleteRoomBed.Text = "Delete a Room or Bed"
        Me.rdoDeleteRoomBed.UseVisualStyleBackColor = True
        '
        'pnlDelete
        '
        Me.pnlDelete.Controls.Add(Me.Label1)
        Me.pnlDelete.Controls.Add(Me.btnDeleteBed)
        Me.pnlDelete.Controls.Add(Me.Panel2)
        Me.pnlDelete.Controls.Add(Me.lblDeleteBedName)
        Me.pnlDelete.Controls.Add(Me.btnDeleteRoom)
        Me.pnlDelete.Controls.Add(Me.Panel1)
        Me.pnlDelete.Controls.Add(Me.lblDeleteRoomName)
        Me.pnlDelete.Controls.Add(Me.lblDeleteInstructions)
        Me.pnlDelete.Controls.Add(Me.lblDetailedInstructions)
        Me.pnlDelete.Location = New System.Drawing.Point(12, 228)
        Me.pnlDelete.Name = "pnlDelete"
        Me.pnlDelete.Size = New System.Drawing.Size(717, 294)
        Me.pnlDelete.TabIndex = 187
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 198
        '
        'btnDeleteBed
        '
        Me.btnDeleteBed.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDeleteBed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteBed.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBed.ForeColor = System.Drawing.Color.White
        Me.btnDeleteBed.Location = New System.Drawing.Point(206, 254)
        Me.btnDeleteBed.Name = "btnDeleteBed"
        Me.btnDeleteBed.Size = New System.Drawing.Size(175, 33)
        Me.btnDeleteBed.TabIndex = 196
        Me.btnDeleteBed.Text = "Delete Bed"
        Me.btnDeleteBed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteBed.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.lstBeds)
        Me.Panel2.Location = New System.Drawing.Point(206, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(175, 203)
        Me.Panel2.TabIndex = 195
        '
        'lstBeds
        '
        Me.lstBeds.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstBeds.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstBeds.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBeds.FormattingEnabled = True
        Me.lstBeds.ItemHeight = 20
        Me.lstBeds.Location = New System.Drawing.Point(1, 1)
        Me.lstBeds.Name = "lstBeds"
        Me.lstBeds.Size = New System.Drawing.Size(173, 201)
        Me.lstBeds.TabIndex = 174
        '
        'lblDeleteBedName
        '
        Me.lblDeleteBedName.AutoSize = True
        Me.lblDeleteBedName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeleteBedName.Location = New System.Drawing.Point(202, 10)
        Me.lblDeleteBedName.Name = "lblDeleteBedName"
        Me.lblDeleteBedName.Size = New System.Drawing.Size(85, 21)
        Me.lblDeleteBedName.TabIndex = 197
        Me.lblDeleteBedName.Text = "Bed Name:"
        '
        'btnDeleteRoom
        '
        Me.btnDeleteRoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDeleteRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteRoom.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteRoom.ForeColor = System.Drawing.Color.White
        Me.btnDeleteRoom.Location = New System.Drawing.Point(7, 255)
        Me.btnDeleteRoom.Name = "btnDeleteRoom"
        Me.btnDeleteRoom.Size = New System.Drawing.Size(175, 32)
        Me.btnDeleteRoom.TabIndex = 193
        Me.btnDeleteRoom.Text = "Delete Room"
        Me.btnDeleteRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteRoom.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.lstRooms)
        Me.Panel1.Location = New System.Drawing.Point(7, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(175, 203)
        Me.Panel1.TabIndex = 192
        '
        'lstRooms
        '
        Me.lstRooms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstRooms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstRooms.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRooms.FormattingEnabled = True
        Me.lstRooms.ItemHeight = 20
        Me.lstRooms.Location = New System.Drawing.Point(1, 1)
        Me.lstRooms.Name = "lstRooms"
        Me.lstRooms.Size = New System.Drawing.Size(173, 201)
        Me.lstRooms.TabIndex = 174
        '
        'lblDeleteRoomName
        '
        Me.lblDeleteRoomName.AutoSize = True
        Me.lblDeleteRoomName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeleteRoomName.Location = New System.Drawing.Point(3, 10)
        Me.lblDeleteRoomName.Name = "lblDeleteRoomName"
        Me.lblDeleteRoomName.Size = New System.Drawing.Size(101, 21)
        Me.lblDeleteRoomName.TabIndex = 194
        Me.lblDeleteRoomName.Text = "Room Name:"
        '
        'lblDeleteInstructions
        '
        Me.lblDeleteInstructions.AutoSize = True
        Me.lblDeleteInstructions.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeleteInstructions.Location = New System.Drawing.Point(400, 12)
        Me.lblDeleteInstructions.Name = "lblDeleteInstructions"
        Me.lblDeleteInstructions.Size = New System.Drawing.Size(94, 21)
        Me.lblDeleteInstructions.TabIndex = 188
        Me.lblDeleteInstructions.Text = "Instructions:"
        '
        'lblDetailedInstructions
        '
        Me.lblDetailedInstructions.AutoSize = True
        Me.lblDetailedInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDetailedInstructions.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDetailedInstructions.Location = New System.Drawing.Point(404, 33)
        Me.lblDetailedInstructions.Name = "lblDetailedInstructions"
        Me.lblDetailedInstructions.Size = New System.Drawing.Size(291, 211)
        Me.lblDetailedInstructions.TabIndex = 187
        Me.lblDetailedInstructions.Text = resources.GetString("lblDetailedInstructions.Text")
        '
        'pnlAdd
        '
        Me.pnlAdd.Controls.Add(Me.rdoNo)
        Me.pnlAdd.Controls.Add(Me.rdoYes)
        Me.pnlAdd.Controls.Add(Me.lblAddMoreBeds)
        Me.pnlAdd.Controls.Add(Me.lblDetailAddInstruc)
        Me.pnlAdd.Controls.Add(Me.lblDeleteIns)
        Me.pnlAdd.Controls.Add(Me.lblAddBed)
        Me.pnlAdd.Controls.Add(Me.lblAddRoom)
        Me.pnlAdd.Controls.Add(Me.btnAdd)
        Me.pnlAdd.Controls.Add(Me.Panel3)
        Me.pnlAdd.Controls.Add(Me.Panel5)
        Me.pnlAdd.Location = New System.Drawing.Point(12, 65)
        Me.pnlAdd.Name = "pnlAdd"
        Me.pnlAdd.Size = New System.Drawing.Size(717, 248)
        Me.pnlAdd.TabIndex = 188
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rdoNo.Location = New System.Drawing.Point(80, 112)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(49, 25)
        Me.rdoNo.TabIndex = 202
        Me.rdoNo.TabStop = True
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'rdoYes
        '
        Me.rdoYes.AutoSize = True
        Me.rdoYes.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rdoYes.Location = New System.Drawing.Point(10, 111)
        Me.rdoYes.Name = "rdoYes"
        Me.rdoYes.Size = New System.Drawing.Size(51, 25)
        Me.rdoYes.TabIndex = 201
        Me.rdoYes.TabStop = True
        Me.rdoYes.Text = "Yes"
        Me.rdoYes.UseVisualStyleBackColor = True
        '
        'lblAddMoreBeds
        '
        Me.lblAddMoreBeds.AutoSize = True
        Me.lblAddMoreBeds.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblAddMoreBeds.Location = New System.Drawing.Point(6, 87)
        Me.lblAddMoreBeds.Name = "lblAddMoreBeds"
        Me.lblAddMoreBeds.Size = New System.Drawing.Size(125, 21)
        Me.lblAddMoreBeds.TabIndex = 200
        Me.lblAddMoreBeds.Text = "lblAddMoreBeds"
        '
        'lblDetailAddInstruc
        '
        Me.lblDetailAddInstruc.AutoSize = True
        Me.lblDetailAddInstruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDetailAddInstruc.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDetailAddInstruc.Location = New System.Drawing.Point(525, 30)
        Me.lblDetailAddInstruc.Name = "lblDetailAddInstruc"
        Me.lblDetailAddInstruc.Size = New System.Drawing.Size(175, 211)
        Me.lblDetailAddInstruc.TabIndex = 199
        Me.lblDetailAddInstruc.Text = resources.GetString("lblDetailAddInstruc.Text")
        '
        'lblDeleteIns
        '
        Me.lblDeleteIns.AutoSize = True
        Me.lblDeleteIns.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeleteIns.Location = New System.Drawing.Point(521, 9)
        Me.lblDeleteIns.Name = "lblDeleteIns"
        Me.lblDeleteIns.Size = New System.Drawing.Size(94, 21)
        Me.lblDeleteIns.TabIndex = 198
        Me.lblDeleteIns.Text = "Instructions:"
        '
        'lblAddBed
        '
        Me.lblAddBed.AutoSize = True
        Me.lblAddBed.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddBed.Location = New System.Drawing.Point(210, 9)
        Me.lblAddBed.Name = "lblAddBed"
        Me.lblAddBed.Size = New System.Drawing.Size(85, 21)
        Me.lblAddBed.TabIndex = 185
        Me.lblAddBed.Text = "Bed Name:"
        '
        'lblAddRoom
        '
        Me.lblAddRoom.AutoSize = True
        Me.lblAddRoom.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddRoom.Location = New System.Drawing.Point(3, 9)
        Me.lblAddRoom.Name = "lblAddRoom"
        Me.lblAddRoom.Size = New System.Drawing.Size(101, 21)
        Me.lblAddRoom.TabIndex = 184
        Me.lblAddRoom.Text = "Room Name:"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(420, 30)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 33)
        Me.btnAdd.TabIndex = 183
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.txtBed)
        Me.Panel3.Location = New System.Drawing.Point(213, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel3.Size = New System.Drawing.Size(175, 28)
        Me.Panel3.TabIndex = 182
        '
        'txtBed
        '
        Me.txtBed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBed.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBed.Location = New System.Drawing.Point(1, 1)
        Me.txtBed.Multiline = True
        Me.txtBed.Name = "txtBed"
        Me.txtBed.ShortcutsEnabled = False
        Me.txtBed.Size = New System.Drawing.Size(173, 26)
        Me.txtBed.TabIndex = 38
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.txtRoom)
        Me.Panel5.Location = New System.Drawing.Point(8, 33)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(175, 28)
        Me.Panel5.TabIndex = 181
        '
        'txtRoom
        '
        Me.txtRoom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRoom.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoom.Location = New System.Drawing.Point(1, 1)
        Me.txtRoom.Multiline = True
        Me.txtRoom.Name = "txtRoom"
        Me.txtRoom.ShortcutsEnabled = False
        Me.txtRoom.Size = New System.Drawing.Size(173, 26)
        Me.txtRoom.TabIndex = 1
        '
        'frmConfigureRooms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(760, 545)
        Me.Controls.Add(Me.pnlAdd)
        Me.Controls.Add(Me.pnlDelete)
        Me.Controls.Add(Me.rdoDeleteRoomBed)
        Me.Controls.Add(Me.rdoAddRoomBed)
        Me.Controls.Add(Me.lblChooseAction)
        Me.Name = "frmConfigureRooms"
        Me.Text = "frmConfigureRooms"
        Me.pnlDelete.ResumeLayout(False)
        Me.pnlDelete.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlAdd.ResumeLayout(False)
        Me.pnlAdd.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblChooseAction As Label
    Friend WithEvents rdoAddRoomBed As RadioButton
    Friend WithEvents rdoDeleteRoomBed As RadioButton
    Friend WithEvents pnlDelete As Panel
    Friend WithEvents btnDeleteBed As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lstBeds As ListBox
    Friend WithEvents lblDeleteBedName As Label
    Friend WithEvents btnDeleteRoom As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lstRooms As ListBox
    Friend WithEvents lblDeleteRoomName As Label
    Friend WithEvents lblDeleteInstructions As Label
    Friend WithEvents lblDetailedInstructions As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlAdd As Panel
    Friend WithEvents lblDetailAddInstruc As Label
    Friend WithEvents lblDeleteIns As Label
    Friend WithEvents lblAddBed As Label
    Friend WithEvents lblAddRoom As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtBed As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtRoom As TextBox
    Friend WithEvents rdoNo As RadioButton
    Friend WithEvents rdoYes As RadioButton
    Friend WithEvents lblAddMoreBeds As Label
End Class
