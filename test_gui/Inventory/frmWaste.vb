Public Class frmWaste

    'global variables
    'used to store patientID from dispense
    Private intPatientID As Integer
    'holds drawerMedicationTUID from database
    Private intDrawerMedTUID As Integer
    'holds intMedID database TUID from database
    Private intMedID As Integer
    'holds intDrawerID TUID from database
    Private intDrawerID As Integer
    'holds the database from database if the drug is a narcotic
    Private intNarcoticFlagGlobal As Integer
    'holds the id of the user that signs off the medication waste/dispense
    Private intSignoffID As Integer
    'holds the reason selected for why the waste is being done
    Private strReason As String
    'set intEntered to zero for launch, will only set to 1 if the form is sent to from adhoc
    Private intEnteredFromAdhoc As Integer = 0
    'set drawer bin for med
    Private intAdhocBin As Integer

    'information used to limit max wasted
    'MAxWaste is quantity in drawer multiplied by AMount per container
    Private dblMaxWaste As Double
    Private dblQuantity As Double
    Private dblAmountContainer As Double
    Private dblAmountGivenToPatient As Double


    Public Sub SetdblAmountGivenToPatient(ByRef amount As Double)
        dblAmountGivenToPatient = amount
    End Sub
    Public Sub SetintQuantity(ByRef Amount As Double)
        dblQuantity = Amount
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: SetPatientID	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Kreiger          */   
    '/*		         DATE CREATED:  4/08/2021               */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/*  sets the patient ID variable
    '/********************************************************************/
    '/*  CALLED BY 
    '/* frmPatientInfo.wastebuttonclick
    '/* FrmDispense.btnDispenseClick
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* (none)
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 id -- integer-- holds value to set into patient ID	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* SetPatientID(1232)
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*   CK            4/02/2021       initial creation
    '/********************************************************************/ 
    Public Sub SetPatientID(ByVal id As Integer)

        intPatientID = id

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: getEnteredFromAdhoc	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker          */   
    '/*		         DATE CREATED:  4/04/2021               */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/*  returns the intenteredFromAdhoc variable
    '/********************************************************************/
    '/*  CALLED BY 
    '/* none
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* none
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* dim intEntered as integer = getEnteredFromAdhoc()
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/04/2021       Initial creation
    '/********************************************************************/ 
    Public Function getEnteredFromAdhoc()
        Return intEnteredFromAdhoc
    End Function

    '/********************************************************************/
    '/*                   FUNCTION NAME: setEnteredFromAdhoc	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker          */   
    '/*		         DATE CREATED:  4/04/2021               */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* sets the intEnteredFromAdhoc to the variable passed to it
    '/* this variable flips between a 1 or a 0 to tell if the dispensing
    '/* flow of screens was entered from the adhoc screen or patientinfo screen
    '/*
    '/********************************************************************/
    '/*  CALLED BY 
    '/* frmDispense.btnDispenseClick
    '/* frmwaste.btnWaste_click
    '/* frmwaste.CheckBarcode
    '/* frmwaste.buttonwasteWithCredentials
    '/* frmwaste.CheckUsername
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* none
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* setEnteredFromAdhoc(1)
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* none
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/04/2021       Initial creation
    '/********************************************************************/ 
    Public Sub setEnteredFromAdhoc(ByRef intEntered As Integer)
        intEnteredFromAdhoc = intEntered
    End Sub


    '/********************************************************************/
    '/*                   FUNCTION NAME: setMedID	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker          */   
    '/*		         DATE CREATED:  4/04/2021               */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* sets the intMedID to the variable passed to it
    '/********************************************************************/
    '/*  CALLED BY 
    '/* frmDispense.btnDispenseClick
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* none
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* setMedID(1)
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* none
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/04/2021       Initial creation
    '/********************************************************************/ 
    Public Sub setMedID(ByRef id As Integer)
        intMedID = id
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: setDrawer	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker          */   
    '/*		         DATE CREATED:  4/04/2021               */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* sets the intDrawerID to the variable passed to it
    '/********************************************************************/
    '/*  CALLED BY 
    '/* frmDispense.btnDispenseClick
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/* none
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* setDrawer(1)
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* none
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/04/2021       Initial creation
    '/********************************************************************/ 
    Public Sub setDrawer(ByRef id As Integer)
        intDrawerID = id
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: setDrawerMEDTUID	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker          */   
    '/*		         DATE CREATED:  4/08/2021               */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/* sets the drawerMEDTUID
    '/*  drawerMEDTUID -- is the drawerMedicationTUID from the database
    '/*   this is used to diferenciate between multiple of the same drug being
    '/*   in the system since the MedID might not be unique
    '/********************************************************************/
    '/*  CALLED BY 
    '/* frmDispense.btnDispenseClick
    '/********************************************************************/
    '/*  CALLS:								                             */	
    '/*
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	id -- drawerMEDTUID -- integer that holds drawerMEDID	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/* setDrawerMEDTUID(23)
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/04/2021       Initial creation
    '/********************************************************************/ 
    Public Sub setDrawerMEDTUID(ByRef id As Integer)
        intDrawerMedTUID = id
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: RadioButton6_CheckedChanged	     
    '/********************************************************************/
    '/*                   WRITTEN BY:         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  DW			             */
    '/********************************************************************/ 
    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOther.CheckedChanged

        MovePanelOnScreen()

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: Waste_Load	             */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:This sub is the form loading event
    '/********************************************************************/
    '/*  CALLED BY: checkchanged events                    	      		 */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	MovePanelOnScreen()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/* dsWitness -- dataset that holds all users usernames for combobox
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub Waste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextBox1.Visible = False
        'set the patientinfo label to hold patient infomation that is tied to waste
        Dim dsPatientInfo As DataSet = CreateDatabase.ExecuteSelectQuery("SELECT * from Patient where Patient_ID = '" & intPatientID & "'")
        lblPatientInfo.Text = "Patient: "
        lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.LastName) & ", "
        lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.FristName) & "         "
        lblPatientInfo.Text &= "MRN: "
        lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.MRN_Number) & "         "
        lblPatientInfo.Text &= "DOB: "
        lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.DoB) & "         "
        lblPatientInfo.Text &= "Height: "
        lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.Height) & "         "
        lblPatientInfo.Text &= "Weight: "
        lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.Weight) & "         "
        'get information on medication being wasted
        Dim dsMedication As DataSet = CreateDatabase.ExecuteSelectQuery("Select * from Medication INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID where Medication_ID = '" & intMedID & "' and Medication.Active_Flag = '1' and DrawerMedication.Active_Flag = '1'")
        txtMedication.Text = dsMedication.Tables(0).Rows(0)(1)
        txtUnit.Text = dsMedication.Tables(0).Rows(0)(15)
        Dim dsDrawer As DataSet
        If intEnteredFromAdhoc = 1 Then
            dsDrawer = CreateDatabase.ExecuteSelectQuery("Select * from DrawerMedication INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE DrawerMedication.DrawerMedication_ID = '" & intDrawerMedTUID & "' and DrawerMedication.Active_Flag = '1' and Drawers.Active_Flag = '1'")

        Else
            dsDrawer = CreateDatabase.ExecuteSelectQuery("Select * from DrawerMedication INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE DrawerMedication.DrawerMedication_ID = '" & intDrawerMedTUID & "' and DrawerMedication.Active_Flag = '1' and Drawers.Active_Flag = '1'")

        End If


        'get drawer information for medication in drawer
        txtDrawer.Text = "Drawer number:  " & dsDrawer.Tables(0).Rows(0)(12) & " Bin: " & dsDrawer.Tables(0).Rows(0)(6)


        dblAmountContainer = dsDrawer.Tables(0).Rows(0)(4)
        dblMaxWaste = (CDbl(dblQuantity) * CDbl(dblAmountContainer))
        'get narcotic flag from database for medication
        Dim intNarcoticFlag As Integer = CreateDatabase.ExecuteScalarQuery("Select Controlled_Flag from Medication where Medication_ID = '" & intMedID & "' and Active_Flag = '1'")
        intNarcoticFlagGlobal = intNarcoticFlag
        'check if it is a narcotic, if it is, show signoff fields, if not hide them
        If intNarcoticFlagGlobal = 1 Then
            lblSignoff.Visible = True
            txtBarcode.Visible = True
            pnlCredentials.Visible = False
            btnSubmitWithoutSignoff.Visible = False
        Else
            pnlSignOff.Visible = False
            lblSignoff.Visible = False
            txtBarcode.Visible = False
        End If
        txtOther.Visible = False
        Label14.Visible = False

        txtQuantity.Select()
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: MovePanelOnScreen	             */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:This sub makes the form dynamic by moving the*/					                       
    '/*  witness sign off down when the radio button is selected         */
    '/********************************************************************/
    '/*  CALLED BY: checkchanged events                    	      		 */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	MovePanelOnScreen()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 ctl- a control object that is used to hold all of the controls  */
    '/*  that will be iterated over.					                 */
    '/*  rbtn- a radio button control that the control will be casted to */
    '/*  for the purpose of accessing the radio button methods.          */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub MovePanelOnScreen()

        Dim ctl As Control
        Dim rbtn As RadioButton = Nothing

        For Each ctl In pnlRadioButtons.Controls
            If TypeName(ctl) = "RadioButton" Then
                If ctl.Name = "rbtnOther" Then
                    rbtn = CType(ctl, RadioButton)
                    If rbtn.Checked = True Then
                        txtOther.Visible = True
                        Label14.Visible = True
                    Else
                        pnlSignOff.Dock = False
                        txtOther.Visible = False
                        Label14.Visible = False
                    End If
                End If
            End If
        Next

    End Sub


    '/********************************************************************/
    '/*                   FUNCTION NAME: btnBack_Click	             */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker  		         */   
    '/*		         DATE CREATED: 	4/07/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: this method will take you back to the previous form
    '/********************************************************************/
    '/*  CALLED BY:             	      		 */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	MovePanelOnScreen()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB		        4/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmPatientInfo.setPatientID(intPatientID)
        frmMain.OpenChildForm(frmPatientInfo)
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtQuantity_KeyPress	             */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander beasecker  		             */   
    '/*		         DATE CREATED: 	4/5/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:This sub handles the keypress event on quantity
    '/*   sends the value in the textbox to the keypresscheck method
    '/********************************************************************/
    '/*  CALLED BY: checkchanged events                    	      		 */				            
    '/* txtQuantity.KeyPress                                       				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/* DataVaildationMethods.KeyPressCheck(e, "0123456789.")	        */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	sender As Object
    '/* e As KeyPressEventArgs	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	txtQuantity_KeyPress()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB		        4/5/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.")
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: btnWaste_Click	             */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker  		             */   
    '/*		         DATE CREATED: 	2/10/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:This handles the beginning of the wasting logic
    '/*         it has the validation checks to make sure all the data is selected
    '/*         and valid. it will then pass along to the waste sub
    '/*
    '/*
    '/********************************************************************/
    '/*  CALLED BY: btnwaste.click                    	      		 */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*  		Inventory.WasteMedication				                         */	
    '/*  		Inventory.PopulateWasteComboBoxMedication()				                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*sender As Object, 
    '/*e As EventArgs    							                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	btnWaste_Click()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 intWasteAmount
    '/*  intMedID
    '/*
    '/*
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB		        2/10/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub btnWaste_Click(sender As Object, e As EventArgs) Handles btnWasteWithBarcode.Click
        If (rbtnOther.Checked = True) And (txtOther.Text.Trim = Nothing) Then
            MessageBox.Show("Please fill in an Explanation")
            txtOther.Text = Nothing
        Else
            'check to see if the drug being wasted is a narcotic or not
            'if it is a narcotic require sign off
            If intNarcoticFlagGlobal = 1 Then
                If IsNumeric(txtQuantity.Text) Then
                    Dim strBarcode As String = txtBarcode.Text
                    CheckBarcode(strBarcode)
                Else
                    MessageBox.Show("Please enter a numeric value to waste")
                End If
            Else
                'if not narcotic dont require sign off
                If IsNumeric(txtQuantity.Text) Then
                    'insert the waste record
                    InsertWasteNonNarcotic()
                    'unlock the side panels
                    frmMain.UnlockSideMenu()
                    'check to see if adhoc or patient informationw as dispensing to know where to return too
                    If intEnteredFromAdhoc = 0 Then
                        ''set patient id and return to patient information
                        frmPatientInfo.setPatientID(intPatientID)
                        frmMain.OpenChildForm(frmPatientInfo)
                    ElseIf intEnteredFromAdhoc = 1 Then
                        'reset adhoc entered flags and return to adhoc
                        frmDispense.setintEntered(0)
                        setEnteredFromAdhoc(0)
                        frmMain.OpenChildForm(frmAdHockDispense)
                    End If
                End If

            End If
        End If
        txtBarcode.Text = Nothing
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: InsertWasteNonNarcotic	             */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker  		         */   
    '/*		         DATE CREATED: 	4/07/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: This method inserts the waste if its a non-narcotic
    '/********************************************************************/
    '/*  CALLED BY:     frmwaste   
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	MovePanelOnScreen()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 Dim dtmWasteTime As String = date time now
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB		        4/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub InsertWasteNonNarcotic()

        'get time for waste
        Dim dtmWasteTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        'check which waste reason is checked
        If radIncorrect.Checked = True Then
            strReason = radIncorrect.Text

        ElseIf radCancel.Checked = True Then
            strReason = radCancel.Text

        ElseIf radRefused.Checked = True Then
            strReason = radRefused.Text

        ElseIf radPatientUnavilable.Checked = True Then
            strReason = radPatientUnavilable.Text

        ElseIf rbtnOther.Checked = True Then
            strReason = txtOther.Text
        End If

        insertWaste(CInt(LoggedInID), CInt(LoggedInID), intDrawerMedTUID, intMedID, intPatientID, strReason, txtQuantity.Text, dtmWasteTime)
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: InsertWasteNarcotic	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker  		         */   
    '/*		         DATE CREATED: 	4/02/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: This method inserts the waste if itsa narcotic
    '/********************************************************************/
    '/*  CALLED BY: frmwaste   
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*  insertWaste					                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	MovePanelOnScreen()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 Dim dtmWasteTime As String = date time now
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB		        4/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub InsertWasteNarcotic(ByRef intApprovingID As Integer)
        Dim dtmWasteTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        'checks for which checked radio button
        If radIncorrect.Checked = True Then
            strReason = radIncorrect.Text

        ElseIf radCancel.Checked = True Then
            strReason = radCancel.Text

        ElseIf radRefused.Checked = True Then
            strReason = radRefused.Text

        ElseIf radPatientUnavilable.Checked = True Then
            strReason = radPatientUnavilable.Text

        ElseIf rbtnOther.Checked = True Then
            strReason = txtOther.Text
        End If
        'insert waste 
        insertWaste(CInt(LoggedInID), intApprovingID, intDrawerMedTUID, intMedID, intPatientID, strReason, txtQuantity.Text, dtmWasteTime)
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: insertWaste	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker  		         */   
    '/*		         DATE CREATED: 	4/02/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: This method inserts the waste to the database
    '/********************************************************************/
    '/*  CALLED BY:  frmwaste  
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/* CreateDatabase.ExecuteInsertQuery()		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	insertWaste()				                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 Dim dtmWasteTime As String = date time now
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB		        4/2/21		    initial creation                 */
    '/********************************************************************/ 
    Public Sub insertWaste(ByRef intPrimaryUser As Integer, ByRef intSecondaryUser As Integer, ByRef intDrawerMEDID As Integer, ByRef intMedicationID As Integer, ByRef intpatientTUID As Integer, ByRef strReason As String, dblQuantity As Double, ByRef dtmDate As String)
        CreateDatabase.ExecuteInsertQuery("INSERT INTO Wastes(Primary_User_TUID,Secondary_User_TUID,DrawerMedication_TUID,Medication_TUID, Patient_TUID,DateTime,Reason,Quantity) VALUES('" & intPrimaryUser & "','" & intSecondaryUser & "','" & intDrawerMEDID & "','" & intMedicationID & "','" & intpatientTUID & "','" & dtmDate & "','" & strReason & "','" & dblQuantity & "')")
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: CheckBarcode	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Dylan Walter          */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub CheckBarcode(ByRef strBarcode As String)

        If strBarcode = "" Then
            MsgBox("           WARNING" & vbCrLf & "Barcode Field is Blank")
            txtBarcode.Focus()

        ElseIf scanBarcode(strBarcode) = "True" Then
            InsertWasteNarcotic(intSignoffID)

            frmMain.UnlockSideMenu()
            If intEnteredFromAdhoc = 0 Then
                frmPatientInfo.setPatientID(intPatientID)
                frmMain.OpenChildForm(frmPatientInfo)
            ElseIf intEnteredFromAdhoc = 1 Then
                frmDispense.setintEntered(0)
                setEnteredFromAdhoc(0)
                frmMain.OpenChildForm(frmAdHockDispense)
            End If
        ElseIf scanBarcode(strBarcode) = "SameBarcode" Then
            MessageBox.Show("Can not sign-off for yourself.")
            txtBarcode.Text = ""
            txtBarcode.Focus()
        Else
            MsgBox("No User With That Barcode")
            txtBarcode.Focus()
        End If
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: scanBarcode	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Dylan Walter         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Function scanBarcode(ByRef strBarcode As String)
        Dim strHashedBarcode = ConvertBarcodePepperAndHash(strBarcode)
        If strHashedBarcode = ExecuteScalarQuery("SELECT Barcode FROM User WHERE User_ID = '" & LoggedInID & "'") Then
            Return "SameBarcode"
        ElseIf ExecuteScalarQuery("SELECT COUNT(*) FROM User WHERE Barcode = '" & strHashedBarcode & "'" & " AND Active_Flag = '1'") <> 0 Then
            intSignoffID = ExecuteScalarQuery("SELECT User_ID FROM User WHERE Barcode = '" & strHashedBarcode & "'")
            Return "True"
        Else
            Return "False"
        End If
    End Function

    '/********************************************************************/
    '/*                   FUNCTION NAME: lblBadge_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub lblBadge_Click(sender As Object, e As EventArgs) Handles lblBadge.Click

        If pnlBarcode.Visible = True Then
            pnlBarcode.Visible = False
            txtBarcode.Text = Nothing
            pnlCredentials.Visible = True
        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: Label8_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles lblUseBarcode.Click

        If pnlCredentials.Visible = True Then

            pnlCredentials.Visible = False
            txtUsername.Text = Nothing
            txtPassword.Text = Nothing
            pnlBarcode.Visible = True

        End If

    End Sub


    '/********************************************************************/
    '/*                   FUNCTION NAME: btnWasteWithCredentials_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker         */   
    '/*		         DATE CREATED: 4/11/2021                */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: this subs purpose is called when the submit waste
    '/*      is clicked and they are choosing to submit with username and password, it will check if the drug that is currrently being wasted is a narcotic or not
    '/*      if it is a narcotic it will call the check username and password method.   
    '/*      if it is not a narcotic then it will not check credentials as it is not needed.
    '/********************************************************************/
    '/*  CALLED BY btnWasteWithCredentials.Click, btnSubmitWithoutSignoff.Click
    '/********************************************************************/
    '/*  CALLS:	 IsNumeric(txtQuantity.Text)	
    '/*	 CheckUsername(txtUsername.Text, txtPassword.Text)
    '/*	 InsertWasteNonNarcotic()
    '/*	 frmMain.UnlockSideMenu()
    '/*	 frmPatientInfo.setPatientID(intPatientID)
    '/*	 frmMain.OpenChildForm(frmPatientInfo)
    '/*	 frmDispense.setintEntered(0)
    '/*	 setEnteredFromAdhoc(0)
    '/*	 frmMain.OpenChildForm(frmAdHockDispense)
    '/*			                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:	user goes through dispensing flow, and 	
    '/* gets the the waste screen and fills out the waste information, when they clikc submit
    '/* it will call this method
    '/**/		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  AB            4/11/2021               Initial				             */
    '/********************************************************************/ 
    Private Sub btnWasteWithCredentials_Click(sender As Object, e As EventArgs) Handles btnWasteWithCredentials.Click, btnSubmitWithoutSignoff.Click
        If (rbtnOther.Checked = True) And (txtOther.Text.Trim = Nothing) Then
            MessageBox.Show("Please fill in an Explanation")
        Else
            If intNarcoticFlagGlobal = 1 Then
                If IsNumeric(txtQuantity.Text) Then
                    CheckUsername(txtUsername.Text, txtPassword.Text)
                Else
                    MessageBox.Show("Please enter a numeric value to waste")
                End If
            Else
                If IsNumeric(txtQuantity.Text) Then
                    InsertWasteNonNarcotic()
                    frmMain.UnlockSideMenu()

                    If intEnteredFromAdhoc = 0 Then
                        frmPatientInfo.setPatientID(intPatientID)
                        frmMain.OpenChildForm(frmPatientInfo)
                    ElseIf intEnteredFromAdhoc = 1 Then
                        frmDispense.setintEntered(0)
                        setEnteredFromAdhoc(0)
                        frmMain.OpenChildForm(frmAdHockDispense)
                    End If
                End If

            End If
        End If
        txtUsername.Text = Nothing
        txtPassword.Text = Nothing
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: CheckUsername	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Dylan Walter         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub CheckUsername(ByRef strUsername As String, ByRef strPassword As String)
        If strUsername = "" Then
            MsgBox("           WARNING" & vbCrLf & "Username Field is Blank")
            txtUsername.Focus()
        ElseIf strPassword = "" Then
            MsgBox("           WARNING" & vbCrLf & "Password Field is Blank")
            txtPassword.Focus()

        ElseIf scanUserName(strUsername, strPassword) = "True" Then
            InsertWasteNarcotic(intSignoffID)

            frmMain.UnlockSideMenu()
            If intEnteredFromAdhoc = 0 Then
                frmPatientInfo.setPatientID(intPatientID)
                frmMain.OpenChildForm(frmPatientInfo)
            ElseIf intEnteredFromAdhoc = 1 Then
                frmDispense.setintEntered(0)
                setEnteredFromAdhoc(0)
                frmMain.OpenChildForm(frmAdHockDispense)
            End If
        ElseIf scanUserName(strUsername, strPassword) = "SameUser" Then
            MessageBox.Show("Can not sign-off for yourself.")
            txtUsername.Text = ""
            txtUsername.Focus()
        Else
            MsgBox("No User With That Username")
            txtUsername.Focus()
        End If
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: scanUserName	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Dylan Walter          */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Function scanUserName(ByRef strUsername As String, ByRef strPassword As String)
        strPassword = AddSaltPepperAndHash(strPassword, strUsername)
        If strUsername = LoggedInUsername Then
            Return "SameUser"
        ElseIf ExecuteScalarQuery("SELECT COUNT(*) FROM User WHERE Username = '" & strUsername & "'" & " AND Password = '" & strPassword & "'" & " AND Active_Flag = '1'") <> 0 Then
            intSignoffID = ExecuteScalarQuery("SELECT User_ID FROM User WHERE Username = '" & strUsername & "'")
            Return "True"
        Else
            Return "False"
        End If
    End Function

    '/********************************************************************/
    '/*                   FUNCTION NAME: btnDrawer7_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub btnDrawer7_Click(sender As Object, e As EventArgs) Handles btnOne.Click, btnTwo.Click, btnThree.Click, btnFour.Click, btnFive.Click, btnSix.Click, btnSeven.Click, btnEight.Click, btnNine.Click, btnZero.Click, btnDecimal.Click

        If txtQuantity.Text.Length >= 5 Then

        Else

            txtQuantity.Text &= CStr(sender.Text)

        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: btnClear_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: sets the quantity textbox to nothing when called
    '/********************************************************************/
    '/*  CALLED BY  btnClear.Click
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB            4/13/2021             Initial				   */
    '/********************************************************************/ 
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtQuantity.Text = Nothing

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: btnEnter_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:        */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        If (rbtnOther.Checked = True) And (txtOther.Text.Trim = Nothing) Then
            MessageBox.Show("Please fill in an Explanation")
        Else
            ' make sure the user has input a value to the textbox
            If String.IsNullOrEmpty(txtQuantity.Text) Then
                MessageBox.Show("Please enter the amount wasted.")

            Else
                'check for the max amount that can be wasted
                Dim dblWastingAmount As Double = txtQuantity.Text
                Dim dblWastingAmountLeftOver As Double = dblMaxWaste - dblAmountGivenToPatient
                If dblWastingAmount > dblWastingAmountLeftOver Then
                    MessageBox.Show("Please enter a wasted amount that is " & dblWastingAmountLeftOver.ToString & " " & txtUnit.Text & " or less")
                Else
                    'give the barcode field focus, or give the password field focus
                    If pnlBarcode.Visible = True Then

                        btnWasteWithBarcode.PerformClick()

                    ElseIf pnlCredentials.Visible = True Then

                        btnWasteWithCredentials.PerformClick()

                    ElseIf pnlSignOff.Visible = False Then

                        btnSubmitWithoutSignoff.PerformClick()

                    End If

                End If
            End If
        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtQuantity_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:      */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged

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

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtBarcode_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY:Eric LaVoie         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub txtBarcode_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            btnWaste_Click(sender, e)
        End If
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtPassword_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Eric LaVoie         */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub txtPassword_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            btnWasteWithCredentials_Click(sender, e)
        End If
    End Sub


    '/********************************************************************/
    '/*                   FUNCTION NAME: txtother_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Eric LaVoie        */   
    '/*		         DATE CREATED:                 */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: Checks the keypress for the other textbox and sends the text
    '/* to the keypresscheck method to prevent unwanted characters from being typed
    '/********************************************************************/
    '/*  CALLED BY  txtOther.KeyPress
    '/********************************************************************/
    '/*  CALLS:	DataVaildationMethods.KeyPressCheck(e, "0123456789. abcdefghijklmnopqrstuvwxyz -_=+!@#$%^&*")							                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	ByVal sender As Object
    '/* ByVal e As System.Windows.Forms.KeyPressEventArgs
    '/*
    '/*
    '/**/								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/ 
    Private Sub txtother_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOther.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789. abcdefghijklmnopqrstuvwxyz -_=+!@#$%^&*")
    End Sub
End Class