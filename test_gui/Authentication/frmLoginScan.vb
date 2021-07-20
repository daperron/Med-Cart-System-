Imports System.Data.SQLite

Public Class frmLoginScan

    Private blnFlagToClose As Boolean = False

    Public Sub setBlnFlagToClose(ByVal flag As Boolean)

        blnFlagToClose = flag

    End Sub
    Private Sub lblBadge_Click(sender As Object, e As EventArgs) Handles lblBadge.Click
        'close current form and open frmLogin to login with username and password
        txtBarcode.Clear()
        Me.Visible = False
        frmLogin.Show()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'set textbox text to string variable strBarcode
        Dim strBarcode = txtBarcode.Text
        If strBarcode = "" Then
            MsgBox("           WARNING" & vbCrLf & "Barcode Field is Blank")
            txtBarcode.Focus()
            'send strBarcode to LogIn Module and recive responce
        ElseIf LogIn.ScanLogIn(strBarcode) = "True" Then
            'If users barcode is in the User table in the database then close current form and open frmMain
            Me.Visible = False
            frmMain.Show()
            frmMain.DetermineFormToOpen(2)

            frmMain.Text = "Medical Dispence - " & LogIn.LoggedInFullName
            frmMain.Show()
            frmMain.btnPatientRecords.PerformClick()
            txtBarcode.Clear()
        Else
            'If users barcode is not in the User table then inform the user
            MsgBox("No User With That Barcode")
            txtBarcode.Focus()
        End If
        txtBarcode.Clear()
    End Sub

    Private Sub Barcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        'if the user hits enter in txtBarcode then try to log them in
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            'set textbox text to string variable strBarcode
            Dim strBarcode = txtBarcode.Text
            If strBarcode = "" Then
                MsgBox("           WARNING" & vbCrLf & "Barcode Field is Blank")
                txtBarcode.Focus()
                'send strBarcode to LogIn Module and recive responce
            ElseIf LogIn.ScanLogIn(strBarcode) = "True" Then
                'If users barcode is in the User table in the database then close current form and open frmMain
                Me.Visible = False
                frmMain.DetermineFormToOpen(2)
                frmMain.Text = "MedServe - " & LogIn.LoggedInFullName
                frmMain.Show()
                frmMain.btnPatientRecords.PerformClick()
                txtBarcode.Clear()
            Else
                'If users barcode is not in the User table then inform the user
                MsgBox("No User With That Barcode")
                txtBarcode.Focus()
            End If
            txtBarcode.Clear()
        End If
    End Sub

    Public Sub CloseForm()

        If blnFlagToClose = True Then

            ' If MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.YesNo) = DialogResult.No Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                '  e.Cancel = True
                Me.Close()
            End If

        End If


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        blnFlagToClose = True
        'Me.Close()
        CloseForm()

    End Sub

    Private Sub frmLoginScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetLogo()
        Dim strProjectName As String = System.Reflection.Assembly.GetExecutingAssembly.GetName.Name.ToString
        lblApplicationName.Text = strProjectName
        Dim Version As Version = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version
        Console.WriteLine("Trying to set the version number")
        lblVersionNumber.Text = "Version " & Version.Major & "." & Version.Minor & " (build " & Version.Build & ")"
        ShowSplashScreen()
        CreateDatabase.Main()
        lblSoftwareName.Visible = False
        pnlSoftwareLogo.Visible = False

    End Sub

    Private Sub SetLogo()

        ' pnlLogo contains the image chosen to be the logo
        ' the logo must be imported into visual studio and stored in the resources folder
        ' once there, you can reference the images from the resources folder.
        pnlLogo.BackgroundImage = My.Resources.BLOCK___CMYK

    End Sub

    Private Sub ShowSplashScreen()

        startUpTimer.Interval = 3000
        startUpTimer.Enabled = True
        startUpTimer.Start()
        pnlSplash.Location = New Point(pnlLogin.Location.X, pnlLogin.Location.Y)
        pnlLogin.Visible = False
        pnlSplash.Size = New Size(pnlLogin.Width, pnlLogin.Height)

    End Sub

    Private Sub Timer1_Tick(ByVal Sender As Object, ByVal e As EventArgs) Handles startUpTimer.Tick

        If startUpTimer.Interval = 3000 Then
            pnlSplash.Visible = False
            pnlLogin.Visible = True
            lblSoftwareName.Visible = True
            lblSoftwareName.BringToFront()
            pnlSoftwareLogo.Visible = True
            txtBarcode.Focus()
        End If

    End Sub


    Private Sub txtLoginKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz-1234567890!@#$%^&*.,<>=+")
    End Sub


End Class