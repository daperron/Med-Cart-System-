Public Class frmWitnessSignOff
    Public referringForm As Object

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: Checking_Credentials  		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Eric LaVoie 		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE:	
    '/*********************************************************************/
    '/*  CALLED BY:          
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */                                                                      
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */                 
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  EL    4/6/2021 Initial creation */
    '/*********************************************************************/
    Private Sub Checking_Credentials(sender As Object, e As EventArgs) Handles btnWasteWithBarcode.Click
        If pnlBarcode.Visible = True Then
            Dim strHashedBarcode = ConvertBarcodePepperAndHash(txtBarcode.Text)
            If ExecuteScalarQuery("SELECT COUNT(*) FROM User WHERE User_ID = '" & LoggedInID & "' AND Barcode = '" & strHashedBarcode & "'" & " AND Active_Flag = '1'") <> 0 Then
                ' add the allergy override
                referringForm.blnOverride = True
                referringForm.blnSignedOff = True
                ' clear the entry
                txtBarcode.Clear()
                Me.Close()
            Else
                MessageBox.Show("Error, barcode entered does not match logged in user. Please try again or cancel dispense.")
                txtBarcode.Clear()
            End If

            ' after text validation then we can actually dispense the medication

            ' close this form and the dispense form at the same time

            ' the patient record gets updated here on the patient information page with the new dispense history


            ' dispensing medications methods from here where we open the drawers
        ElseIf pnlCredentials.Visible = True And txtUsername.Text IsNot "" And txtPassword.Text IsNot "" Then
            Dim strHashedPassword = AddSaltPepperAndHash(txtPassword.Text, txtUsername.Text)
            If ExecuteScalarQuery("SELECT COUNT(*) FROM User WHERE User_ID = '" & LoggedInID & "' AND Password = '" & strHashedPassword & "'" & " AND Active_Flag = '1'") <> 0 Then
                referringForm.blnOverride = True
                referringForm.blnSignedOff = True
                ' clear the entry
                txtBarcode.Clear()
                Me.Close()
            Else
                MessageBox.Show("Error, username and password entered does not match logged in user. Please try again or cancel dispense.")
                txtPassword.Clear()
            End If
        End If
        ' clear the inputs no matter what
        txtBarcode.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub pnlInteractions_Paint(sender As Object, e As PaintEventArgs) Handles pnlInteractions.Paint

        ' pannel is hidden unless these two conditions are true:

        '   1. the patient is alergic to the drug so we need to check the charts
        '   2. There is a drug interaction with a drug the patient is currently taking.


        '   regardless of warning we need to let a sign off happen


    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: btnConfigureInventory_Click  		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Eric LaVoie 		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE:	
    '/*********************************************************************/
    '/*  CALLED BY:          
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */                                                                      
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */                 
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  EL    4/6/2021 Initial creation */
    '/*********************************************************************/
    Private Sub btnConfigureInventory_Click(sender As Object, e As EventArgs) Handles btnConfigureInventory.Click
        referringForm.blnSignedOff = False
        referringForm.blnOverride = False
        txtBarcode.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        Me.Close()
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: Codes_Keypress  		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Eric LaVoie 		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE:	
    '/*********************************************************************/
    '/*  CALLED BY:          
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */                                                                      
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */                 
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  EL    4/6/2021 Initial creation */
    '/*********************************************************************/
    Private Sub Codes_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress, txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            Checking_Credentials(sender, e)
        Else
            KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz-1234567890!@#$%^&*.,<>=+")
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: Username_Keypress  		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Eric LaVoie 		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE:	
    '/*********************************************************************/
    '/*  CALLED BY:          
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */                                                                      
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */                 
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  EL    4/6/2021 Initial creation */
    '/*********************************************************************/
    Private Sub Username_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            txtPassword.Focus()
        Else
            KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz-1234567890!@#$%^&*.,<>=+")
        End If
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: frmWitnessSignOff_Load  		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE:	
    '/*********************************************************************/
    '/*  CALLED BY:          
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		sender As Object									   */                     
    '/*     e As EventArgs                                                                    
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*		lblBadge.Click									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  CK    4/6/2021 Initial creation */
    '/*********************************************************************/
    Private Sub frmWitnessSignOff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlBarcode.Visible = True
        pnlCredentials.Visible = False
        btnWasteWithBarcode.Visible = False
        txtBarcode.Focus()
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: lblBadge_Click_1  		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE:	
    '/*********************************************************************/
    '/*  CALLED BY:          
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		sender As Object									   */                     
    '/*     e As EventArgs                                                                    
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*		lblBadge.Click									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  CK    4/6/2021 Initial creation */
    '/*********************************************************************/
    Private Sub lblBadge_Click_1(sender As Object, e As EventArgs) Handles lblBadge.Click

        If pnlBarcode.Visible = True Then

            pnlBarcode.Visible = False
            txtBarcode.Text = Nothing
            pnlCredentials.Visible = True
            btnWasteWithBarcode.Visible = True
            txtUsername.Focus()
        End If

    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: lblUseBarcode_Click  		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE:	
    '/*********************************************************************/
    '/*  CALLED BY:          
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  CK    4/6/2021 Initial creation */
    '/*********************************************************************/
    Private Sub lblUseBarcode_Click(sender As Object, e As EventArgs) Handles lblUseBarcode.Click

        If pnlCredentials.Visible = True Then

            pnlCredentials.Visible = False
            txtUsername.Text = Nothing
            txtPassword.Text = Nothing
            pnlBarcode.Visible = True
            btnWasteWithBarcode.Visible = False
            txtBarcode.Focus()
        End If
    End Sub
End Class