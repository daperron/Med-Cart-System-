'/*********************************************************************/
'/*                   FILE NAME:  frmDispense                         */
'/*********************************************************************/
'/* PART OF PROJECT: MedServe                 */
'/*********************************************************************/
'/* WRITTEN BY: Capstone Dev team 2021		         */
'/*********************************************************************/
'/* PROJECT PURPOSE:								   */
'/*	 this project is a medical dispensing software solution for nursing students
'/*  it will work as a simulation or full install into a medical cart for students
'/*  to use as a learning tool in clinical enviornments
'/*********************************************************************/
'/*  FILE PURPOSE:									   */
'/*	 this form Handles all the gui logic for doing the dispensing logic
'/*  the user will input the amount of the dispensing drug they want to remove
'/*  if the drug is a narcotic it will ask for a count of the amount in the drawer
'/*  it will ask how much they gave to the patient.
'/*********************************************************************/
'/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			   */
'/*                                                    (NONE)	   */
''/*********************************************************************/
'/*  ENVIRONMENTAL RETURNS:							   */
'/*                          (NOTHING)					   */
'/*********************************************************************/
'/* SAMPLE INVOCATION:								   */
'/*											   */
'/* This form is launched with two methods, the user launches the program
'/* goes into a patients form, selects a prescription to dispense and it will
'/* open this form.
'/* the second method is to choose the adhoc dispensing method. they fill out all
'/* the adhoc information and hit order adhoc, it will launch this form.
'/*
'/*
'/*********************************************************************/
'/*  GLOBAL VARIABLE LIST (Alphabetically):			         */
'/*
'/* blnOverride 
'/* blnSignedOff 
'/* contactPanelsAddedCount 
'/* currentContactPanelName 
'/* dblAmountAdministerMAX  -- this holds the max amount that could be administered to the patient based on how much was removed
'/* dblAmountPerContainer   -- this holds the amount per container from the datbase
'/* dblDispensedPatientAmount  -- this is the amount that was actually dispensed to the patient
'/* ENTERAMOUNTOTREMOVE 
'/* intAdhocBin -- this is used in the adhoc dispensing 
'/* intAdhocDoctor -- this holds the physician id of the physician who ordered the adhoc
'/* intAdhocDrawerNumber -- the drawer number for the medication being removed for the adhoc
'/* intCountedAmount -- this is the amount that the user input for the amount they counted in the drawer
'/* intDispenseAmount -- this is the amount of the containers the user will remove from the drawer
'/* intDrawerMEDAdhoc -- this is the drawerMedicationID from the database
'/* intEnteredFromAdhoc -- this varirable is used to flag if the user is entering the form from an adhoc order or patient inforamtion
'/* intMedicationID -- the database ID for the medication being dispensed
'/* intPatientID  -- the patient ID for the patient that is being dispensed
'/* intPatientMedID  -- the patient Medication ID, this is the database TUID for the patient prescription
'/* intPatientMRN  -- this is the MRN for the patient
'/* strAmountAdhoc  -- this is the ordered amount from the adhoc order form
'/* strUnitAdhoc -- this is the measurement from the database for the medication (ususally MG or ML)
'/*
'/*********************************************************************/
'/* COMPILATION NOTES:								   */
'/* 											   */
'/* This project compiles normally under Microsoft Visual C++ 7.2   */
'/* All one needs to do Is open up the Solver project And compile.    */
'/* No special compile options Or optimizations were used.  No        */
'/* unresolved warnings Or errors exist under these compilation       */
'/* conditions.									   */
'/*********************************************************************/
'/* MODIFICATION HISTORY:						         */
'/*											   */
'/*  WHO   WHEN     WHAT								   */
'/*  ---   ----     ------------------------------------------------- */
'/*********************************************************************/


Imports System.Text

Public Class frmDispense
    Public blnSignedOff As Boolean = True
    Public blnOverride As Boolean = False
    Private intPatientID As Integer
    Private intPatientMRN As Double
    Private intMedicationID As Integer
    Private intPatientMedID As Integer

    Private intDispenseAmount As Integer
    Private intCountedAmount As Integer
    Private dblDispensedPatientAmount As Integer
    Private dblWastedAmount As Integer

    Private dblAmountPerContainer As Double
    Private dblAmountAdministerMAX As Double

    Dim contactPanelsAddedCount As Integer = 0
    Dim currentContactPanelName As String = Nothing

    Private intEnteredFromAdhoc As Integer = 0

    'variables here are only used if adhoc is the form that initiated dispensing
    Public strAmountAdhoc As String
    Public strUnitAdhoc As String
    Public intDrawerMEDAdhoc As Integer
    Private intAdhocDrawerNumber As Integer
    Private intAdhocBin As Integer
    Private intAdhocDoctor As Integer
    Const ENTERAMOUNTOTREMOVE As String = "  Insert Amount to Remove:"

    Public Sub setAmountPerContainer(ByRef ID As Double)
        dblAmountPerContainer = ID
    End Sub

    Public Sub setintEntered(ByRef ID As Integer)
        intEnteredFromAdhoc = ID
    End Sub

    Public Function getIntEntered()
        Return intEnteredFromAdhoc
    End Function

    Public Sub SetPatientID(ByVal ID As Integer)
        intPatientID = ID
        intPatientMRN = ExecuteScalarQuery("SELECT MRN_Number from Patient WHERE Patient_ID =" & intPatientID & ";")
    End Sub

    Public Sub SetintMedicationID(ByVal ID As Integer)
        intMedicationID = ID
    End Sub

    Public Sub setPatientMedID(ByRef ID As Integer)
        intPatientMedID = ID
    End Sub

    Public Sub SetPatientMrn(ByVal mrn As Integer)
        intPatientMRN = mrn
    End Sub


    Public Function getPattientMedID()
        Return intPatientMedID
    End Function


    Private Sub btnDispense_Click(sender As Object, e As EventArgs)

        'MessageBox.Show("CAUTION: This drug interacts with (insert drug name here) that the patient is currently taking. Or the patient is allergic to this drug")

        'frmWitnessSignOff.Show()
        ' call emthod to open serial port connection and open drawer

    End Sub
    '/*********************************************************************/
    '/*            SubProgram NAME: CreateDispenseHistoryPanels()         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/6/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is routine is dynamically creates panels that are placed    */ 
    '/*	 inside of the flowpanel that is fixed on the form. The panels are*/
    '/*	 created here, assigned handlers, and the contents of the panels  */
    '/*	 are updated in this routine                                      */
    '/*********************************************************************/
    '/*  CALLED BY: frmConfiguration_Load  	      						  */           
    '/*                                                                   */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/* flpPannel- the flow panel which the user wants to create the      */
    '/*     create the single panel.                                      */
    '/* strMedicationName- medication name from the database we will display   
    '/* strStrength- strength value from the the database                 */
    '/* strType- type value from the database                             */
    '/* strQuantity- quantity value from the database                     */
    '/* strDispenseBy- dispensedby value from the database                */
    '/* strDispenseDate- dispense date from the database                  */
    '/* strDispenseTime=- dispense time from the database                 */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 CreateDispenseHistoryPanels(frmPatientInfo.flpDispenseHistory, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "")   
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	pnl- is the pnl which we are creating for padding purposes        */
    '/* pnlMainPanel- is the pnl which we are going to add controls       */
    '/* lblID1 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/* lblID2 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/* lblID3 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/* lblID4 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/* lblID5 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/* lblID6 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/6/2021    Initial creation                     */
    Public Sub CreateDispenseHistoryPanels(ByVal flpPannel As FlowLayoutPanel, ByVal strMedicationName As String, ByVal strStrength As String, ByVal strType As String, ByVal strQuantity As String, ByVal strDispenseBy As String, ByVal strDispenseDate As String, ByVal strDispenseTime As String)

        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(1040, 47)
            .Name = "pnlIndividualPatientRecordPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(1040, 45)
            .Name = "pnlIndividualPatientRecord" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
        End With

        'put the boarder panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        'AddHandler pnlMainPanel.DoubleClick, AddressOf DynamicDoubleClickNewOrder
        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault

        ' add controls to this panel
        ' call database info here to populate
        Dim lblID As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label
        Dim lblID5 As New Label
        Dim lblID6 As New Label

        CreateIDLabelWithToolTip(pnlMainPanel, lblID, "lblMedicationName", lblMedication.Location.X, 20, strMedicationName, getPanelCount(flpPannel), tpToolTip, TruncateString(25, strMedicationName))
        CreateIDLabel(pnlMainPanel, lblID2, "lblStrength", lblStrength.Location.X, 20, strStrength, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID3, "lblType", lblType.Location.X, 20, strType, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID4, "lblQuantity", lblQuantity.Location.X, 20, strQuantity, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID5, "lblDispensedBy", lblDispensedBy.Location.X, 20, strDispenseBy, getPanelCount(flpPannel), tpToolTip, TruncateString(30, strDispenseBy))
        CreateIDLabel(pnlMainPanel, lblID6, "lblDispenseTimeAndDate", lblDateTime.Location.X, 20, strDispenseDate.Substring(0, 19), getPanelCount(flpPannel))

        'Add panel to flow layout panel
        flpPannel.Controls.Add(pnl)

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: Dispense_Load               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier       		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	
    '/*********************************************************************/
    '/*  CALLED BY:   back button clicked     						                      */                            
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*********************************************************************/
    Private Sub Dispense_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblDirections.Text = ENTERAMOUNTOTREMOVE
        ' lblDirections.Left = (pnlSelector.Width \ 2) - (pnlSelector.Width \ 2)
        lblDirections.Location = New Point(pnlLabel.Width \ 2 - lblDirections.Width \ 2, lblDirections.Location.Y)
        pnlAmountInDrawer.Visible = False
        pnlAmountAdministered.Visible = False
        ' pnlSelector.Visible = False
        btnReopenDrawer.Visible = False
        btnZero.Size = New Point(207, 65)
        btnZero.BringToFront()

        AddVisibleChangedEventHandler()

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: btnDispense_Click_1               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this is called and handles the button click methods
    '/* the way the dispense screen is written is it reuses the same
    '/* controls multiple times for multiple parts in the dispensing flow
    '/* first it checks if the drug being dispensed is a narcotic. it will ask the amount to be removed from the drawer.
    '/* after that it opens the drawer. if it is a
    '/* narcotic then it changes to require the narcotic count.
    '/* after the narcotoc count if it is not correct to the system amount, then it
    '/* will alert the user to a discrepancy. after this it will ask for the 
    '/* amount that was given to the patient, and after that it will move to
    '/* the waste input requireing the waste input.
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:  btnDispense.Click 	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS: 
    '/* CreateDatabase.ExecuteScalarQuery("Select Controlled_Flag from Medication where Medication_ID = '" & intMedicationID & "' and Active_Flag = '1'")
    '/* CreateDatabase.ExecuteScalarQuery("Select Drawers_TUID from DrawerMedication where Medication_TUID = '" & intMedicationID & "' and Active_Flag = '1'")
    '/* OpenOneDrawer(intdrawerNumber)
    '/* changebuttonForCounting()
    '/* frmMain.LockSideMenu()
    '/* UpdateDrawerCount(intDispenseAmount, intquantity, intdrawerNumber, intMedicationID)
    '/* UpdateSystemCountForDiscrepancy(intMedicationID, intdrawerNumber, intAmountinCart)
    '/* UpdateDrawerCount(intDispenseAmount, intquantity, intdrawerNumber, intMedicationID)
    '/* changeButtonforDispensing()
    '/* frmMain.UnlockSideMenu()
    '/* frmPatientInfo.setPatientID(intPatientID)
    '/* frmMain.OpenChildForm(frmPatientInfo)
    '/* DispensingDrug(intMedicationID, CInt(LoggedInID), strAmountDispensed)
    '/* frmWaste.SetPatientID(intPatientID)
    '/* frmWaste.setDrawer(intdrawerNumber)
    '/* frmWaste.setMedID(intMedicationID)
    '/* frmWaste.setDrawerMEDTUID(intdrawerMEDTUID)
    '/* frmWaste.SetdblAmountGivenToPatient(CDbl(txtAmountDispensed.Text))
    '/* frmMain.OpenChildForm(frmWaste)
    '/**/             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender
    '/*      e                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*
    '/* NarcoticFlag -- flag that is either zero or one based on if the drug is a narcotic or not
    '/* intdrawerNumber -- the number drawer the medication is in
    '/* intAmountinCart  -- the amount the cart system registers in the cart
    '/* strAmountDispensed -- the amount being removed from the cart
    '/* intdrawerMEDTUID
    '/*
    '/*
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub btnDispense_Click_1(sender As Object, e As EventArgs) Handles btnDispense.Click
        'get if the drug is a narcotic and get the drawer the medication selected is in 


        Dim NarcoticFlag As Integer = CreateDatabase.ExecuteScalarQuery("Select Controlled_Flag from Medication where Medication_ID = '" & intMedicationID & "' and Active_Flag = '1'")
        Dim intdrawerNumber As Integer = CreateDatabase.ExecuteScalarQuery("Select Drawers_TUID from DrawerMedication where Medication_TUID = '" & intMedicationID & "' and Active_Flag = '1'")

        If txtQuantityToDispense.Text.Length > 1 Then

            btnReopenDrawer.Visible = True

        End If

        If intEnteredFromAdhoc = 1 Then
            intdrawerNumber = intAdhocDrawerNumber
        End If
        'check for what set in the process the dispense is in.
        'If lblDirections.Text.Equals("Insert Amount to Remove:") Then
        If lblDirections.Text.Equals(ENTERAMOUNTOTREMOVE) Then
            'check to see if the amount is a numeric
            If IsNumeric(txtQuantityToDispense.Text) Then
                If txtQuantityToDispense.Text > 0 Then
                    'check to see if the drug is a narcotic
                    If NarcoticFlag = 1 Then
                        'Is a narcotic
                        'open drawer for counting
                        OpenOneDrawer(intdrawerNumber)
                        intDispenseAmount = txtQuantityToDispense.Text
                        changebuttonForCounting()
                        'lock side bars to prevent leaving the dispensing early
                        frmMain.LockSideMenu()
                        btnBack.Visible = False
                    Else
                        btnZero.Size = New Point(136, 65)
                        btnZero.BringToFront()
                        'Is not a narcotic
                        OpenOneDrawer(intdrawerNumber)
                        intDispenseAmount = txtQuantityToDispense.Text
                        Dim intquantity As Integer = CreateDatabase.ExecuteScalarQuery("Select Quantity from DrawerMedication where Medication_TUID = '" & intMedicationID & "' AND Active_Flag = '1' AND Drawers_TUID = '" & intdrawerNumber & "'")
                        UpdateDrawerCount(intDispenseAmount, intquantity, intdrawerNumber, intMedicationID)
                        changeButtonforDispensing()
                        frmMain.LockSideMenu()
                        btnBack.Visible = False
                    End If
                Else
                    MessageBox.Show("Please enter a quantity value greater than 0")
                End If
            End If
            'step after narcotic amount entered
        ElseIf lblDirections.Text.Equals("Enter the Quantity in the Cart") Then
            If IsNumeric(txtQuantityToDispense.Text) Then
                btnZero.Size = New Point(136, 65)
                btnZero.BringToFront()
                Dim intAmountinCart As Integer = CInt(txtCountInDrawer.Text)
                UpdateSystemCountForDiscrepancy(intMedicationID, intdrawerNumber, intAmountinCart)
                Dim intquantity As Integer = CreateDatabase.ExecuteScalarQuery("Select Quantity from DrawerMedication where Medication_TUID = '" & intMedicationID & "' AND Active_Flag = '1' AND Drawers_TUID = '" & intdrawerNumber & "'")
                UpdateDrawerCount(intDispenseAmount, intquantity, intdrawerNumber, intMedicationID)
                changeButtonforDispensing()
            End If
            'step after administered drugs, enter wasting
        ElseIf lblDirections.Text.Equals("Enter the Amount Administered") Then
            If IsNumeric(txtAmountDispensed.Text) Then
                If intEnteredFromAdhoc = 0 Then
                    If dblAmountAdministerMAX = CDbl(txtAmountDispensed.Text) Then
                        frmMain.UnlockSideMenu()
                        frmPatientInfo.setPatientID(intPatientID)
                        frmMain.OpenChildForm(frmPatientInfo)
                    Else
                        Dim strAmountDispensed As String = txtAmountDispensed.Text & " " & txtUnits.Text
                        Dim intdrawerMEDTUID As Integer = CreateDatabase.ExecuteScalarQuery("Select DrawerMedication_ID from DrawerMedication where Medication_TUID = '" & intMedicationID & "' and Active_Flag = '1'")
                        DispensingDrug(intMedicationID, CInt(LoggedInID), strAmountDispensed)
                        frmWaste.SetPatientID(intPatientID)
                        frmWaste.setDrawer(intdrawerNumber)
                        frmWaste.setMedID(intMedicationID)
                        frmWaste.setDrawerMEDTUID(intdrawerMEDTUID)
                        frmWaste.SetdblAmountGivenToPatient(CDbl(txtAmountDispensed.Text))
                        frmMain.OpenChildForm(frmWaste)
                    End If

                    'used to check if the form that entered this dispense was adhoc or not
                ElseIf intEnteredFromAdhoc = 1 Then
                    'Dim strAmountDispensed As String = txtAmountDispensed.Text & " " & txtUnits.Text
                    'DispensingDrugAdhoc(intMedicationID, intPatientID, CInt(LoggedInID), strAmountDispensed, intDrawerMEDAdhoc, intAdhocDoctor)
                    'frmWaste.SetPatientID(intPatientID)
                    'frmWaste.setDrawer(intdrawerNumber)
                    'frmWaste.setMedID(intMedicationID)
                    'frmWaste.setDrawerMEDTUID(intDrawerMEDAdhoc)
                    'frmWaste.setEnteredFromAdhoc(1)
                    'frmWaste.SetdblAmountGivenToPatient(CDbl(txtAmountDispensed.Text))
                    'frmMain.OpenChildForm(frmWaste)
                    If dblAmountAdministerMAX = CDbl(txtAmountDispensed.Text) Then
                        frmMain.UnlockSideMenu()
                        Dim strAmountDispensed As String = txtAmountDispensed.Text & " " & txtUnits.Text
                        DispensingDrugAdhoc(intMedicationID, intPatientID, CInt(LoggedInID), strAmountDispensed, intDrawerMEDAdhoc, intAdhocDoctor)
                        setintEntered(0)
                        frmWaste.setEnteredFromAdhoc(0)
                        frmMain.OpenChildForm(frmAdHockDispense)
                    Else
                        Dim strAmountDispensed As String = txtAmountDispensed.Text & " " & txtUnits.Text
                        DispensingDrugAdhoc(intMedicationID, intPatientID, CInt(LoggedInID), strAmountDispensed, intDrawerMEDAdhoc, intAdhocDoctor)
                        frmWaste.SetPatientID(intPatientID)
                        frmWaste.setDrawer(intdrawerNumber)
                        frmWaste.setMedID(intMedicationID)
                        frmWaste.setDrawerMEDTUID(intDrawerMEDAdhoc)
                        frmWaste.setEnteredFromAdhoc(1)
                        frmWaste.SetdblAmountGivenToPatient(CDbl(txtAmountDispensed.Text))
                        frmMain.OpenChildForm(frmWaste)
                    End If
                End If

            Else
                MessageBox.Show("Please enter a numeric number greater than 0")
            End If

        End If
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: changebuttonForCounting               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  This method will swap the frmDispense labels to the narcotic counting
    '/* visuals
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	                                                              */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender
    '/*      e                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub changebuttonForCounting()
        lblDirections.Text = "Enter the Quantity in the Cart"
        ' lblDirections.Left = (pnlSelector.Width \ 2) - (pnlSelector.Width \ 2)
        lblDirections.Location = New Point(pnlLabel.Width \ 2 - lblDirections.Width \ 2, lblDirections.Location.Y)
        btnDispense.Text = "    Submit Count"
        pnlAmountInDrawer.Visible = True
        pnlAmountToRemove.Visible = False
    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: changeButtonforDispensing               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 this program will swap the GUI to the labels and visuals for dispensing 
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	                                                              */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender
    '/*      e                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */ 
    '/*
    '/* strAmountUnit -- gets the unit count from the database for the medication
    '/*
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub changeButtonforDispensing()
        lblDirections.Text = "Enter the Amount Administered"
        btnDispense.Text = "    Submit Amount"
        ' lblDirections.Left = (pnlSelector.Width \ 2) - (pnlSelector.Width \ 2)
        lblDirections.Location = New Point(pnlLabel.Width \ 2 - lblDirections.Width \ 2, lblDirections.Location.Y)
        ' show approiate panels
        pnlAmountAdministered.Visible = True
        pnlAmountToRemove.Visible = False
        pnlAmountInDrawer.Visible = False
        Dim strAmountUnit As String = CreateDatabase.ExecuteScalarQuery("Select Amount_Per_Container_Unit from DrawerMedication where Medication_TUID = '" & intMedicationID & "' and Active_Flag = '1'")
        txtUnits.Text = strAmountUnit
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: DispensingDrug               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this method handles the sql statements to insert the dispense into the database
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	                                      */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     intMedID -- Integer -- holds medication database id
    '/*      intPrimaryID -- Integer -- holds patient database id
    '/*      strAmountDispensed -- Integer -- holds amount dispensed
    '/*
    '/**/ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */ 
    '/* dtmAdhocTime
    '/* strbSQLcommand
    '/* intdrawerNumber
    '/* intPatientMedicationDatabaseID
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub DispensingDrug(ByRef intMedID As Integer, ByRef intPrimaryID As Integer, ByRef strAmountDispensed As String)
        Dim strbSQLcommand As New StringBuilder()
        Dim dtmAdhocTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim intdrawerNumber As Integer = CreateDatabase.ExecuteScalarQuery("Select DrawerMedication_ID from DrawerMedication where Medication_TUID = '" & intMedicationID & "' and Active_Flag = '1'")
        strbSQLcommand.Clear()
        strbSQLcommand.Append("SELECT PatientMedication_ID FROM PatientMedication WHERE Medication_TUID = '" & intMedID & "' AND Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1'")
        Dim intPatientMedicationDatabaseID As Integer = getPattientMedID()
        strbSQLcommand.Clear()
        strbSQLcommand.Append("INSERT INTO Dispensing(PatientMedication_TUID, Primary_User_TUID, Approving_User_TUID, DateTime_Dispensed, Amount_Dispensed, DrawerMedication_TUID) ")
        strbSQLcommand.Append("VALUES('" & intPatientMedicationDatabaseID & "','" & intPrimaryID & "','" & intPrimaryID & "','" & dtmAdhocTime & "','" & strAmountDispensed & "','" & intdrawerNumber & "')")
        CreateDatabase.ExecuteInsertQuery(strbSQLcommand.ToString)
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: DispensingDrugAdhoc               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this method handles the dispensing insert database sql for adhoc orders
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:                             */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */             
    '/* intMedID As Integer- database med tuid
    '/* intPatientID As Integer -- patient database tuid
    '/* intUserID As Integer -- logged in user tuid
    '/* stramount As String -- amount dispensed
    '/* intDrawerID As Integer -- drawer id to be opened
    '/* 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */ 
    '/*
    '/* strbSQLcommand -- sql command
    '/* dtmAdhocTime -- date time object
    '/*
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub DispensingDrugAdhoc(ByRef intMedID As Integer, ByRef intPatientID As Integer, ByRef intUserID As Integer, ByRef stramount As String, ByRef intDrawerID As Integer, ByRef intDoctor As Integer)
        Dim strbSQLcommand As New StringBuilder()
        Dim dtmAdhocTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        strbSQLcommand.Clear()
        strbSQLcommand.Append("INSERT INTO AdHocOrder(Medication_TUID,Patient_TUID,User_TUID,Amount,DrawerMedication_TUID,DateTime,Physician_TUID) ")
        strbSQLcommand.Append("VALUES('" & intMedID & "','" & intPatientID & "','" & intUserID & "','" & stramount & "','" & intDrawerID & "','" & dtmAdhocTime & "','" & intDoctor & "')")
        CreateDatabase.ExecuteInsertQuery(strbSQLcommand.ToString)
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: UpdateSystemCountForDiscrepancy               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 this method handles the updating of the drawer amount to the counted amount
    '/* and calls the insert discrepancy method.
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	                                 */            
    '/*      CreateDatabase.ExecuteInsertQuery 
    '/*      Discrepancies.CreateDiscrepancy                                        				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*     intMedID As Integer- database med tuid
    '/*      intDrawerCount           
    '/*      intEnteredAmount   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub UpdateSystemCountForDiscrepancy(ByRef intMedID As Integer, ByRef intDrawerCount As Integer, ByRef intEnteredAmount As Integer)
        Dim intCurrentSystemCount As Integer = CreateDatabase.ExecuteScalarQuery("Select Quantity from DrawerMedication where Medication_TUID = '" & intMedID & "' and Active_Flag = '1' AND Drawers_TUID = '" & intDrawerCount & "'")
        Dim intdrawerNumber As Integer = CreateDatabase.ExecuteScalarQuery("Select Drawers_TUID from DrawerMedication where Medication_TUID = '" & intMedID & "' and Active_Flag = '1'")
        Dim intBinNumber As Integer = CreateDatabase.ExecuteScalarQuery("Select Divider_Bin from DrawerMedication where Medication_TUID = '" & intMedID & "' and Active_Flag = '1'")
        If Not intCurrentSystemCount = intEnteredAmount Then
            CreateDatabase.ExecuteInsertQuery("Update DrawerMedication SET Quantity = '" & intEnteredAmount & "' WHERE Medication_TUID = '" & intMedID & "' AND Active_Flag = '1'")
            Discrepancies.CreateDiscrepancy(intdrawerNumber, intBinNumber, intCurrentSystemCount, intEnteredAmount, CInt(LoggedInID), CInt(LoggedInID), intMedID)

            ' MessageBox.Show("Discrepancy detected and recorded")
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: txtQuantity_KeyPress               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	   this handles the limiting of dispensed mediaction quantity text
    '/*  box to not go above 1000 or below 1
    '/*********************************************************************/
    '/*  CALLED BY:  txtQuantityToDispense.KeyPress 	      			            
    '/*********************************************************************/          
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender
    '/*      e                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantityToDispense.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789")
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtCountInDrawer_KeyPress	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE 
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub txtCountInDrawer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCountInDrawer.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789")
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtAmountDispensed_KeyPress	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE 
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub txtAmountDispensed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountDispensed.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.")
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: txtQuantity_TextChanged               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this handles the limiting of dispensed mediaction quantity text
    '/*  box to not go above 1000 or below 1
    '/*********************************************************************/
    '/*  CALLED BY:   txtQuantityToDispense.Validated	      		         */                 
    '/*********************************************************************/
    '/*  CALLS:                               */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender
    '/*      e                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantityToDispense.Validated
        'If IsNumeric(sender.Text) Then
        '    GraphicalUserInterfaceReusableMethods.MaxValue(CInt(sender.Text), 1000, txtQuantityToDispense)
        'Else
        '    MessageBox.Show("Please make sure you enter a positive number 1-1000.")
        '    '  sender.Text = "1"
        'End If
    End Sub




    '/*********************************************************************/
    '/*                   SubProgram NAME: btnBack_Click               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this method handles the back button on the form, it will determine
    '/* if patientInfo or adhoc is the one who entered the dispensing flow 
    '/* then return to the correct one
    '/*********************************************************************/
    '/*  CALLED BY:   back button clicked     						                      */                            
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender
    '/*      e                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'check variable too see if adhoc or patientinfromation was the one who opened the form
        If intEnteredFromAdhoc = 0 Then
            frmPatientInfo.setPatientID(intPatientID)
            frmMain.OpenChildForm(frmPatientInfo)
        Else
            setintEntered(0)
            frmMain.OpenChildForm(frmAdHockDispense)
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: AdhocDispenseSetInformation               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this method will set the global variables that are only used in adhoc
    '/* dispensing
    '/*********************************************************************/
    '/*  CALLED BY:   adhocSetinformation	      						                      */                 
    '/*********************************************************************/                                        				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     amount As String
    '/* unit As String
    '/* intDrawerMedA As Integer
    '/*      e                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    3/20/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Public Sub AdhocDispenseSetInformation(ByRef amount As String, ByRef unit As String, ByRef intDrawerMedA As Integer, ByRef intDrawerNumber As Integer, ByRef intBin As Integer, ByRef intDoctor As Integer)
        strAmountAdhoc = amount
        strUnitAdhoc = unit
        intDrawerMEDAdhoc = intDrawerMedA
        intAdhocDrawerNumber = intDrawerNumber
        intAdhocBin = intBin
        intAdhocDoctor = intDoctor
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: btnReopenDrawer_Click               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED:    4/07/2021                    */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this sub program will reopen the drawer for the medication they are dispensing
    '/*********************************************************************/
    '/*  CALLED BY:  btnReopenDrawer.Click      						                      */                 
    '/*********************************************************************/                                        				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	  user presses reopen drawer button                                                                */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB        4/07/2021   Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub btnReopenDrawer_Click(sender As Object, e As EventArgs) Handles btnReopenDrawer.Click
        Dim intdrawerNumber As Integer = CreateDatabase.ExecuteScalarQuery("Select Drawers_TUID from DrawerMedication where Medication_TUID = '" & intMedicationID & "' and Active_Flag = '1'")
        OpenOneDrawer(intdrawerNumber)
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: UpdateDrawerCount               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED:   4/12/2021                       */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	  this sub will update the count in the drawer that will be left after the user dispenses
    '/*   from the drawer
    '/*********************************************************************/
    '/*  CALLED BY: btnDispense_click       						                      */                 
    '/*********************************************************************/                                        				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB        4/12/2021   Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub UpdateDrawerCount(ByRef intAmountDispense As Integer, ByRef intAmountInDrawer As Integer, ByRef intDrawerNumber As Integer, ByRef intMedID As Integer)
        'get amount that should be left
        Dim intLeftover As Integer = intAmountInDrawer - intAmountDispense
        Dim intUpdateNumber As Integer = 0
        'if they dispensed more than was in the drawer set the count to zero
        If intLeftover <= 0 Then
            intUpdateNumber = 0
        Else
            intUpdateNumber = intLeftover
        End If
        'update amount
        CreateDatabase.ExecuteInsertQuery("UPDATE DrawerMedication set Quantity = '" & intUpdateNumber & "' where Drawers_TUID = '" & intDrawerNumber & "' and Medication_TUID = '" & intMedID & "'")

        If intAmountDispense > intAmountInDrawer Then
            intAmountDispense = intAmountInDrawer
        End If
        'using the amount dispensed calculate the max amounts that can be dispensed
        CalculateMaxDispense(intAmountDispense)
        'set the amount dispensed into the waste form
        frmWaste.SetintQuantity(intAmountDispense)
    End Sub
    '/*********************************************************************/
    '/*                   SubProgram NAME: btnDrawer7_Click              */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 4/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Ensures the user cannot add invalid data from the numeric num pad*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                                           */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnDrawer7_Click(sender As Object, e As EventArgs) Handles btnOne.Click, btnTwo.Click, btnThree.Click, btnFour.Click, btnFive.Click, btnSix.Click, btnSeven.Click, btnEight.Click, btnNine.Click, btnZero.Click, btnDecimal.Click

        If pnlAmountToRemove.Visible = True Then

            If txtCountInDrawer.Text.Length > 4 Then

            Else

                txtQuantityToDispense.Text &= CStr(sender.Text)

            End If

        ElseIf pnlAmountInDrawer.Visible = True Then

            If txtCountInDrawer.Text.Length > 4 Then

            Else

                txtCountInDrawer.Text &= CStr(sender.Text)

            End If

        ElseIf pnlAmountAdministered.Visible = True Then

            If txtAmountDispensed.Text.Length > 5 Then

            Else

                txtAmountDispensed.Text &= CStr(sender.Text)

            End If

        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: btnClear_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE Sets the textbox to nothing when it becomes visible
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        If pnlAmountToRemove.Visible = True Then

            txtQuantityToDispense.Text = Nothing

        ElseIf pnlAmountInDrawer.Visible = True Then

            txtCountInDrawer.Text = Nothing

        ElseIf pnlAmountAdministered.Visible = True Then

            txtAmountDispensed.Text = Nothing

        End If
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: btnEnter_Click_1	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE this methods handles the enter button interactions
    '/********************************************************************/
    '/*  CALLED BY btnEnter.Click
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user presses the enter button on the on screen keyboard						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/********************************************************************/
    Private Sub btnEnter_Click_1(sender As Object, e As EventArgs) Handles btnEnter.Click
        'check which stage in the dispensing screen flow we are in
        If pnlAmountToRemove.Visible = True Then
            'make sure not null in the textboxes
            If Not String.IsNullOrEmpty(txtQuantityToDispense.Text) Then
                btnDispense.PerformClick()
            End If

        ElseIf pnlAmountInDrawer.Visible = True Then
            'make sure the count box is not null
            If Not String.IsNullOrEmpty(txtCountInDrawer.Text) Then
                btnDispense.PerformClick()
            End If


        ElseIf pnlAmountAdministered.Visible = True Then

            If IsNumeric(txtAmountDispensed.Text) Then
                Dim dblAmountGiven As Double = CDbl(txtAmountDispensed.Text)

                If dblAmountGiven > dblAmountAdministerMAX Then
                    MessageBox.Show("Max amount to administer to patient is " & dblAmountAdministerMAX.ToString)
                Else
                    If Not String.IsNullOrEmpty(txtAmountDispensed.Text) Then
                        btnDispense.PerformClick()
                    End If
                End If
            Else
                MessageBox.Show("Please enter a valid number.")
                txtAmountDispensed.Text = Nothing
            End If
        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: AddVisibleChangedEventHandler	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE - adds a handler to the pnlAmountToRemove for monitoring
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub AddVisibleChangedEventHandler()
        AddHandler pnlAmountToRemove.VisibleChanged, AddressOf VisibleChangedEvent
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: VisibleChangedEvent	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE sets the visiblility of the reopen drawer button for the user
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub VisibleChangedEvent(ByVal sender As Object, ByVal e As EventArgs)

        If pnlAmountToRemove.Visible = False Then
            btnReopenDrawer.Visible = True
        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtQuantityToDispense_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE - ensures valid data in the textbox by monitoring the 
    '/*  the textchanged event.
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub txtQuantityToDispense_TextChanged(sender As Object, e As EventArgs) Handles txtQuantityToDispense.TextChanged

        If Not String.IsNullOrEmpty(sender.text) Then
            If sender.text.length > 3 Then
                If CInt(sender.text) > 1000 Then

                    MessageBox.Show("Please pick a number between 0 - 1000")
                    sender.text = Nothing

                End If
            End If
        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtCountInDrawer_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE ensures valid data in the textbox by monitoring the 
    '/*  the textchanged event.
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub txtCountInDrawer_TextChanged(sender As Object, e As EventArgs) Handles txtCountInDrawer.TextChanged

        If Not String.IsNullOrEmpty(sender.text) Then
            If sender.text.length > 3 Then
                If CInt(sender.text) > 1000 Then

                    MessageBox.Show("Please pick a number between 0 - 1000")
                    sender.text = Nothing

                End If
            End If
        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtAmountDispensed_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier
    '/*		         DATE CREATED:                             
    '/********************************************************************/
    '/*  SUBROUTINE ensures valid data in the textbox by monitoring the 
    '/*  the textchanged event. Also modifies the text if a . is incorrectly
    '/*  added.
    '/********************************************************************/
    '/*  CALLED BY
    '/********************************************************************/
    '/*  CALLS:			                             */		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           					                        							             
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
    Private Sub txtAmountDispensed_TextChanged(sender As Object, e As EventArgs) Handles txtAmountDispensed.TextChanged

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

    '/*********************************************************************/
    '/*                   SubProgram NAME: CalculateMaxDispense               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker        		          */   
    '/*		         DATE CREATED: 		 4/15/2021                       */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 this method calculates the max amount that can be dispensed based on how 
    '/*  much was removed from the drawer
    '/*
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:	 dispense updatedrawer count     						                      */                 
    '/*********************************************************************/                                        				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     RemoveNumber As Double                                                        */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  AB    4/15/2021     Initial creation/rework of dispensing
    '/*********************************************************************/
    Private Sub CalculateMaxDispense(ByRef RemoveNumber As Double)
        dblAmountAdministerMAX = RemoveNumber * dblAmountPerContainer
    End Sub

End Class