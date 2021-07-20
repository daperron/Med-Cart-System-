Public Class frmAdHockDispense
    Dim intPatientID As New ArrayList
    Public blnSignedOff As Boolean = True
    Public blnOverride As Boolean = False


    '/********************************************************************/
    '/*                   SUB NAME: frmAdHockDispense_Load 	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:Collin Krygier
    '/*		         DATE CREATED:                            
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* Sets the form up for the user to use
    '/********************************************************************/
    '/*  CALLED BY 
    '/* 
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* (none)
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 Sender
    '/*  E 								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* 
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* None
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*
    '/********************************************************************/ 
    Private Sub frmAdHockDispense_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'set ad efault quantity to the quantity textbox

        cmbMedications.Items.Clear()
        cmbphysician.Items.Clear()
        cmbPatientName.Items.Clear()
        'populate medications onthe cart into comboboxs
        AdHoc.GetAllMedicationsForListbox()
        'populate active patients into comboboxes
        AdHoc.PopulatePatientsAdhoc()
        AdHoc.PopulatePhysicianAdhoc()
    End Sub


    '/********************************************************************/
    '/*                   SUB NAME: cmbMedications_SelectedIndexChanged          
    '/********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker
    '/*		         DATE CREATED:     3/12/2021                       
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* this will call the method to set medicaiton properties when the 
    '/*  medication combobox index changes
    '/*
    '/********************************************************************/
    '/*  CALLED BY 
    '/*  cmbMedications.SelectedIndexChanged
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* AdHoc.SetMedicationProperties()
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	                                   */						
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* change index in cmbMedications
    '/* when the index changes it will call this method
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* 
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             3/12/2021          initial creation
    '/********************************************************************/ 
    Private Sub cmbMedications_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedications.SelectedIndexChanged
        AdHoc.SetMedicationProperties()
    End Sub


    '/********************************************************************/
    '/*                   SUB NAME:  cmbPatientName_SelectedIndexChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker
    '/*		         DATE CREATED:     3/12/2021                       
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* this will call the method to set populate patient properties when the 
    '/*  medication combobox index changes
    '/*
    '/********************************************************************/
    '/*  CALLED BY 
    '/*  cmbPatientName.SelectedIndexChanged
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* AdHoc.PopulatePatientInformation()
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	                                   */						
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* change index in cmbPatientName
    '/* when the index changes it will call this method
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* 
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             3/12/2021          initial creation
    '/********************************************************************/ 
    Private Sub cmbPatientName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatientName.SelectedIndexChanged
        AdHoc.PopulatePatientInformation()
    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: btnDispense_Click 	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker
    '/*		         DATE CREATED:     3/12/2021                       
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* this 
    '/*
    '/********************************************************************/
    '/*  CALLED BY 
    '/*  btnDispense.Click
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* ExecuteScalarQuery("Select AllergyOverride_ID from AllergyOverride")
    '/* ExecuteScalarQuery("SELECT MAX(AllergyOverride_ID) from AllergyOverride")
    '/* ExecuteInsertQuery("INSERT INTO AllergyOverride(AllergyOverride_ID, Patient_TUID, User_TUID, Allergy_Name, DateTime)
    '/* DrugInteractionOverride(cmbMedications.SelectedItem, txtMRN.Text, "AdHoc")
    '/* frmDispense.setintEntered(1)
    '/* frmDispense.AdhocDispenseSetInformation(strAmount, strUnit, intMedDrawer)
    '/* frmDispense.SetPatientID(intPatientID)
    '/* frmDispense.SetintMedicationID(intMedID)
    '/* frmMain.OpenChildForm(frmDispense)
    '/* DispenseHistory.DispensemedicationPopulate(intPatientID, intMedID)
    '/* PatientInformation.PopulatePatientDispenseInfo(intPatientID)
    '/* PatientInformation.PopulatePatientAllergiesDispenseInfo(intPatientID)
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	                                   */						
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* 
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* 
    '/* intMaxAllergyID 
    '/* intPatientID -- holds selected patient id
    '/* intMedID -- holds selected medication id
    '/* strAmount -- adhoc prescption amount from textbox
    '/* strUnit -- unit from textbox
    '/* intMedDrawer -- drawermedicationTUID from database for selected medication
    '/*
    '/*
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             3/12/2021          initial creation
    '/*  BH             4/2/2021         added allergy/interaction overrides
    '/********************************************************************/ 
    Private Sub btnDispense_Click(sender As Object, e As EventArgs) Handles btnDispense.Click



        'make sure that both patient and medication is selected before ordering the AdHoc
        If IsNothing(cmbMedications.SelectedItem) Then
            MessageBox.Show("Please select a medication")
        ElseIf IsNothing(cmbPatientName.SelectedItem) Then
            MessageBox.Show("Please select a patient")
        ElseIf txtAmount.Text = Nothing Or txtAmount.Text.Trim.Length = 0 Then
            MessageBox.Show("Please enter a prescription amount")
        ElseIf txtUnit.Text = Nothing Or txtUnit.Text.Trim.Length = 0 Then
            MessageBox.Show("Please select a Unit for the amount")
        ElseIf IsNothing(cmbphysician.SelectedItem) Then
            MessageBox.Show("Please select an ordering physician")
        Else
            For Each allergy In lstboxAllergies.Items
                If cmbMedications.SelectedItem.ToString.ToLower.Contains(allergy.ToString.ToLower) Then
                    'show witness sign off
                    frmWitnessSignOff.Label1.Text = cmbMedications.SelectedItem.ToString
                    frmWitnessSignOff.referringForm = Me
                    'added formatting in case a drug interaction override was chosen first
                    frmWitnessSignOff.Label2.Text = "Causes Allergic Reaction to Patient"
                    frmWitnessSignOff.Text = "Allergies Override"
                    frmWitnessSignOff.Label1.Location = New Point(3, 34)
                    frmWitnessSignOff.Label2.Location = New Point(21, 64)
                    frmWitnessSignOff.Label5.Visible = False
                    frmWitnessSignOff.Label6.Visible = False
                    frmWitnessSignOff.ShowDialog()


                    'if authentication from witness sign off form comes back then
                    If blnOverride Then
                        Dim intMaxAllergyID
                        ' pull the information to insert
                        If ExecuteScalarQuery("Select AllergyOverride_ID from AllergyOverride") = Nothing Then
                            intMaxAllergyID = 0
                        Else
                            intMaxAllergyID = ExecuteScalarQuery("SELECT MAX(AllergyOverride_ID) from AllergyOverride")
                            intMaxAllergyID += 1
                        End If

                        ExecuteInsertQuery("INSERT INTO AllergyOverride(AllergyOverride_ID, Patient_TUID, User_TUID, Allergy_Name, DateTime) " &
                                               "Values(" & intMaxAllergyID & ", " & intPatientIDArray(Me.cmbPatientName.SelectedIndex) & ", " & LoggedInID & ", '" & allergy & "', '" & DateTime.Now & "')")
                    Else
                        MessageBox.Show("Dispense canceled by user.")
                        blnOverride = False
                        blnSignedOff = False
                        Exit Sub
                    End If

                Else
                    ' do nothing as there is no allergy
                    blnOverride = False
                End If
            Next

            'If the user didn't already sign off to dispense the medication,
            'check interactions
            DrugInteractionOverride(cmbMedications.SelectedItem, txtMRN.Text, "AdHoc")

            'If the user signs off for any override, dispense the medication
            If blnSignedOff = True Then
                blnSignedOff = False

                'get IDs from parallel arrays
                'this form has three arrays, intPatientIDArray, intMedIDArray, and intDrawerMedArray
                'they have the IDs of the comboboxes added in the same order that they are added to the combobox
                'this allows identifiability when selecting comboboxes, this is required as many database fields
                'are not unique, so i set up these arrays, you can get the Database TUID for any selected item
                ' by indexing the index at the same index of the combobox selected item
                Dim intPatientID As Integer = AdHoc.intPatientIDArray(cmbPatientName.SelectedIndex)
                Dim intMedID As Integer = AdHoc.intMedIDArray(cmbMedications.SelectedIndex)
                Dim strAmount As String = txtAmount.Text
                Dim strUnit As String = txtUnit.Text
                Dim intMedDrawer As Integer = AdHoc.intDrawerMedArray(cmbMedications.SelectedIndex)
                Dim intPhysicianID As Integer = AdHoc.intPhysicianIDArray(cmbphysician.SelectedIndex)
                Dim intDrawerNumber As Integer = CreateDatabase.ExecuteScalarQuery("Select Drawers_TUID from DrawerMedication where DrawerMedication_ID = '" & AdHoc.intDrawerMedArray(cmbMedications.SelectedIndex) & "'")

                Dim intDrawerBin As Integer = CreateDatabase.ExecuteScalarQuery("Select Divider_Bin from DrawerMedication where DrawerMedication_ID = '" & AdHoc.intDrawerMedArray(cmbMedications.SelectedIndex) & "'")
                Dim intQuantity As Integer = CreateDatabase.ExecuteScalarQuery("Select Quantity from DrawerMedication where DrawerMedication_ID = '" & AdHoc.intDrawerMedArray(cmbMedications.SelectedIndex) & "'")
                If intQuantity = 0 Then
                    MessageBox.Show("Medication in the drawer is empty, please restock the drawer")
                Else
                    'AdHoc.InsertAdHoc(AdHoc.intPatientIDArray(cmbPatientName.SelectedIndex), LoggedInID, CInt(txtQuantity.Text), AdHoc.intMedIDArray(cmbMedications.SelectedIndex), AdHoc.intDrawerMedArray(cmbMedications.SelectedIndex))
                    'AdHoc.clearAdhocBoxes()
                    'MessageBox.Show("Order Successfully placed")

                    'set entered variable to 1 to let dispense know adhoc is what started this dispensing
                    frmDispense.setintEntered(1)

                    'set medication variables into dispense screen
                    frmDispense.AdhocDispenseSetInformation(strAmount, strUnit, intMedDrawer, intDrawerNumber, intDrawerBin, intPhysicianID)

                    'set patient id for dispense
                    frmDispense.SetPatientID(intPatientID)

                    'set medication id for dispense
                    frmDispense.SetintMedicationID(intMedID)
                    frmMain.OpenChildForm(frmDispense)
                    DispenseHistory.DispensemedicationPopulate(intPatientID, intMedID)
                    PatientInformation.PopulatePatientDispenseInfo(intPatientID)
                    PatientInformation.PopulatePatientAllergiesDispenseInfo(intPatientID)
                End If
            End If
        End If

    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtQuantity_KeyPress			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 2/17/2021                    		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:            								   */             
    '/*  This is going to handle what happens when a user make a key press */
    '/*  in the txtQuantity textbox. It will make sure that the key press is*/
    '/*  numeric.                                                          */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
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
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.")

    End Sub


    '/********************************************************************/
    '/*                   SUB NAME: 	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: 
    '/*		         DATE CREATED:                            
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/*
    '/********************************************************************/
    '/*  CALLED BY 
    '/* 
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* (none)
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	                                   */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* 
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*
    '/********************************************************************/ 
    Private Sub txtUnit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnit.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.abcdefghijklmnopqrstuvwxyz /-")

    End Sub
    '/*********************************************************************/
    '/*                   Function NAME: txtDateOfBirth_TextChanged()     */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 3/17/2021                        */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:	    							                  */             
    '/*	 This function simply takes a string and truncates it to a new    */
    '/*  length if the string is longer than the specified length. If not,*/
    '/*  it will be left alone and we return the original string passed in*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	sender As Object                                                  */ 
    '/*	e As EventArgs                                                    */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/17/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub txtDateOfBirth_TextChanged(sender As Object, e As EventArgs) Handles txtDateOfBirth.TextChanged

        Dim truncatedDate As String = Nothing

        If txtDateOfBirth.Text.Length > 10 Then

            truncatedDate = CStr(txtDateOfBirth.Text.Substring(0, 10))
        Else
            truncatedDate = CStr(txtDateOfBirth.Text)
        End If

        txtDateOfBirth.Text = truncatedDate
    End Sub

    Private Sub txtStrength_TextChanged(sender As Object, e As EventArgs) Handles txtStrength.TextChanged

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)

    End Sub

    '/*********************************************************************/
    '/*                   Function NAME: btnClear_Click()     */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 3/17/2021                        */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:	    							                  */             
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	sender As Object                                                  */ 
    '/*	e As EventArgs                                                    */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/17/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        txtAmount.Text = Nothing

    End Sub

    '/*********************************************************************/
    '/*                   Function NAME: btnEnter_Click()     */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 4/12/2021                        */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:	    							                  */             
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	sender As Object                                                  */ 
    '/*	e As EventArgs                                                    */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  4/12/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        ' make sure the user has input a value to the textbox
        If String.IsNullOrEmpty(txtAmount.Text) Then

            MessageBox.Show("Please enter the an amount.")

        Else

            btnDispense.PerformClick()

        End If

    End Sub

    '/*********************************************************************/
    '/*                   Function NAME: btnDrawer7_Click()               */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 4/12/2021                        */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:	
    '/*  checks the length of the string and then concats the number to the
    '/*  string if it does not exceed the specified character length.							                           
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	sender As Object                                                  */ 
    '/*	e As EventArgs                                                    */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  4/12/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnDrawer7_Click(sender As Object, e As EventArgs) Handles btnOne.Click, btnTwo.Click, btnThree.Click, btnFour.Click, btnFive.Click, btnSix.Click, btnSeven.Click, btnEight.Click, btnNine.Click, btnZero.Click, btnDecimal.Click

        If txtAmount.Text.Length >= 5 Then

        Else

            txtAmount.Text &= CStr(sender.Text)

        End If

    End Sub

    '/*********************************************************************/
    '/*                   Function NAME: txtAmount_TextChanged()     */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 4/12/2021                        */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:	    							
    '/*  ensures the textbox has valid data and edits the text if the user
    '/*  types the wrong data in the textbox.                   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	sender As Object                                                  */ 
    '/*	e As EventArgs                                                    */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  4/12/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If Not String.IsNullOrEmpty(sender.text) Then
            If IsNumeric(sender.text) Then
                If sender.text.length > 3 Then
                    If CDbl(sender.text) > 1000 Then

                        MessageBox.Show("Please pick a number between 0 - 1000")
                        sender.text = Nothing

                    End If
                End If
            Else
                MessageBox.Show("Please make sure to enter a number with a lead zero if using a decimal and only one decimal point")
                sender.Text = sender.Text.ToString.TrimEnd(CChar("."))
            End If
        End If
    End Sub
End Class