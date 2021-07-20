Public Class frmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'set textbox text to string variable strUsername and strPassword
        Dim strUsername = txtUserName.Text
        Dim strPassword = txtPassword.Text
        If strUsername = "" Then
            MsgBox("            WARNING" & vbCrLf & "User Name Field is Blank")
            txtUserName.Focus()
        ElseIf strPassword = "" Then
            MsgBox("            WARNING" & vbCrLf & "Password Field is Blank")
            txtPassword.Focus()
            'send strUsername and strPassword to LogIn Module and recive responce
        ElseIf LogIn.UsernameLogIn(strUsername, strPassword) = "True" Then
            'If users Username and Password is in the User table in the database then close current form and open frmMain
            Me.Close()
            'call to set what sub form should be open
            frmMain.DetermineFormToOpen(2)
            'set the header for main to show who is logged in
            frmMain.Text = "Medical Dispence - " & LogIn.LoggedInFullName
            frmMain.Show()
            'make btnPatientRecords have focus
            '  frmMain.pnlSubMenuPatientRecords.Visible = True

            '  frmMain.btnAll.PerformClick()
        Else
            'If users Username and Password is not in the User table then inform the user
            MsgBox("No User With That Username and Password")
        End If


    End Sub

    Private Sub lblBadge_Click(sender As Object, e As EventArgs) Handles lblBadge.Click
        'close current form and open frmLoginScan to login with username and password
        Me.Close()
        frmLoginScan.Visible = True
    End Sub

    Private Sub btnEye_Click(sender As Object, e As EventArgs) Handles btnEye.Click

        'If checked then password is visible as plain text
        If txtPassword.UseSystemPasswordChar = False Then

            txtPassword.UseSystemPasswordChar = True
            'If unchecked then password is visible as *
        Else
            txtPassword.UseSystemPasswordChar = False

        End If
    End Sub


    'Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    '    If MessageBox.Show("Are you sure you want to close the application?",
    '                       "Medication Dispense",
    '                       MessageBoxButtons.YesNo) = DialogResult.No Then
    '        e.Cancel = True

    '    End If

    'End Sub
    Private Sub Password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        'if the user hits enter in txtPassword then try to log them in
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            'set textbox text to string variable strUsername and strPassword
            Dim strUsername = txtUserName.Text
            Dim strPassword = txtPassword.Text
            If strUsername = "" Then
                MsgBox("            WARNING" & vbCrLf & "Username Field is Blank")
                txtUserName.Focus()
            ElseIf strPassword = "" Then
                MsgBox("            WARNING" & vbCrLf & "Password Field is Blank")
                txtPassword.Focus()
                'send strUsername and strPassword to LogIn Module and recive responce
            ElseIf LogIn.UsernameLogIn(strUsername, strPassword) = "True" Then
                'If users Username and Password is in the User table in the database then close current form and open frmMain
                Me.Close()
                'call to set what sub form should be open
                frmMain.DetermineFormToOpen(2)
                'set the header for main to show who is logged in
                frmMain.SetUserName(strUsername)
                frmMain.Text = "MedServe - " & LogIn.LoggedInFullName

                frmMain.Show()
                'make btnPatientRecords have focus
                frmMain.btnAllPatients.PerformClick()

                'pass user name to the main form

            Else
                'If users Username and Password is not in the User table then inform the user
                MsgBox("No User with that Username or Password")
            End If
        End If
    End Sub

    Private Sub Username_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        'if the user hits enter in txtusername then set focus to txtPassword
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            txtPassword.Focus()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        ' If MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.YesNo) = DialogResult.No Then
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            '  e.Cancel = True
            Me.Close()
            frmLoginScan.Close()
        End If

    End Sub

    Private Sub txtLoginKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress, txtPassword.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz-1234567890!@#$%^&*.,<>=+")
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class