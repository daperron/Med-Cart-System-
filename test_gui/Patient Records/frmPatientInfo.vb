Public Class frmPatientInfo

    '/*********************************************************************/
    '/*                   FILE NAME:  */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT:				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY: 		         */		  
    '/*		         DATE CREATED:			   */						  
    '/*********************************************************************/
    '/*  PROJECT PURPOSE:								   */				  
    '/*											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			   */ 
    '/*                                                    (NONE)	   */	  
    '/*********************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							   */			  
    '/*                          (NOTHING)					   */		  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */			  
    '/*											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			         */		  
    '/*						  	 (NONE)			   */					  
    '/*********************************************************************/
    '/* COMPILATION NOTES(will include version notes including libraries):*/
    '/* 											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */				  
    '/*											   */					  
    '/*  WHO   WHEN     WHAT								   */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/31/2021 made it so the form can't be edited when outside */
    '/*                  edit mode. And changed the way the edit and view */
    '/*                  modes work.                                      */
    '/*********************************************************************/




    Private intPatientID As Integer
    Private intPatientMRN As Double
    Private strSelectedLabel As String
    Public blnSignedOff As Boolean = True
    Public blnOverride As Boolean = False
    Public strMedName As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Enum DispenseHistoryEnum As Integer
        MedicationName = 1
        Strength = 2
        Type = 3
        Quantity = 4
        DispensedBy = 5
        DispenseDateAndTime = 6
    End Enum
    Public Enum PrescriptionsEnum As Integer
        MedicationName = 1
        Strength = 2
        Type = 3
        Quantity = 4
        DatePrescribed = 5
        PrescribedBy = 6
        Frequency = 7
    End Enum

    Public Sub setPatientID(ByVal ID As Integer)
        intPatientID = ID
        intPatientMRN = ExecuteScalarQuery("SELECT MRN_Number from Patient WHERE Patient_ID =" & intPatientID & ";")
        Debug.WriteLine("")
    End Sub
    Public Sub setPatientMrn(ByVal Mrn As Double)
        intPatientMRN = Mrn
        intPatientID = ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE MRN_Number =" & intPatientMRN & ";")
        Debug.WriteLine("")
    End Sub


    Public Sub DynamicButtonEditRecord_Click(ByVal sender As Object, ByVal e As EventArgs)

        'show the add new patient form filled in with the patients infromation
        'frmNewPatient.Show()

        'we call our  edit medication form

    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: frmPatientInfo_Load  		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:     		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*											   */                     
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
    '/*  WHO   WHEN     WHAT				 				   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/16/2021 Changed cboBed to be disabled by default until a */
    '/*                  selection in room is made.                       */
    '/*  NP   2/16/2021  added a call to the GetRoom method in            */
    '/*                  PatientInformation                               */
    '/* NP    4/1/2021   Added a combo box for physician and populated it.*/
    '/*********************************************************************/

    Private Sub frmPatientInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ctl As Control = Nothing

        'cboBed.Enabled = False 'this will stop the people from selecting a bed before they
        'select a room. 

        ' intPatientMRN = txtMRN.Text

        populatePhysicianComboBox(cboPhysicians, CreateDatabase.ExecuteSelectQuery("Select * from Physician where Active_flag = '" &
                                                                                   1 & "' ORDER BY Physician_Last_Name, Physician_First_Name ;"))
        PatientInformation.GetAllergies(intPatientID)
        PatientInformation.GetPatientInformation(intPatientID)
        PatientInformation.getPrescriptions(intPatientID)
        PatientInformation.getRoom(intPatientID, cboRoom, cboBed)
        DispenseHistory.DispenseHistorySpecificPatient(intPatientID)

        SetControlsToReadOnly(ctl)

        CreateToolTips(pnlPrescriptionsHeader, tpLabelDirections)
        CreateToolTips(pnlDispenseHistoryHeader, tpLabelDirections)

        'btnWaste.Visible = False
        ' AddHandlerToLabelClick(pnlDispenseHistoryHeader)
        ' AddHandlerToLabelClick(pnlPrescriptionsHeader)

        AddHandlerToLabelClick(pnlDispenseHistoryHeader, AddressOf SortBySelectedLabel)
        AddHandlerToLabelClick(pnlPrescriptionsHeader, AddressOf SortBySelectedLabel)

        lblDispenseHistory.ForeColor = Color.DarkGray
        lblPrescriptions.Font = New Font(New FontFamily("Segoe UI Semibold"), 14.25, FontStyle.Underline)
        strSelectedLabel = lblPrescriptions.Name

        ' move labels to default position just to ensure they are in the correct position to start off
        lblDispenseHistory.Location = New Point(153, 190)
        lblPrescriptions.Location = New Point(10, 190)
        moveAndResizePanels()
        disableEdits()
        HideEditButton()

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
    '/*********************************************************************/
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

        CreateIDLabelWithToolTip(pnlMainPanel, lblID, "lblMedicationName", lblMedication.Location.X, 20, strMedicationName, getPanelCount(flpPannel), tpToolTip, TruncateString(22, strMedicationName))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID2, "lblStrength", lblStrength.Location.X, 20, strStrength, getPanelCount(flpPannel), tpToolTip, TruncateString(8, strStrength))
        ' CreateIDLabel(pnlMainPanel, lblID2, "lblStrength", lblStrength.Location.X, 20, strStrength, getPanelCount(flpPannel))
        ' CreateIDLabel(pnlMainPanel, lblID3, "lblType", lblType.Location.X, 20, strType, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID3, "lblType", lblType.Location.X, 20, strType, getPanelCount(flpPannel), tpToolTip, TruncateString(8, strType))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID4, "lblQuantity", lblQuantity.Location.X, 20, strQuantity, getPanelCount(flpPannel), tpToolTip, TruncateString(8, strQuantity))
        'CreateIDLabel(pnlMainPanel, lblID4, "lblQuantity", lblQuantity.Location.X, 20, strQuantity, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID5, "lblDispensedBy", lblDispensedBy.Location.X, 20, strDispenseBy, getPanelCount(flpPannel), tpToolTip, TruncateString(30, strDispenseBy))
        CreateIDLabel(pnlMainPanel, lblID6, "lblDispenseTimeAndDate", lblDateTime.Location.X, 20, strDispenseDate.Substring(0, 19), getPanelCount(flpPannel))


        'Add panel to flow layout panel
        flpPannel.Controls.Add(pnl)

    End Sub
    '/*********************************************************************/
    '/*            SubProgram NAME: CreatePrescriptionsPanels()         */         
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
    '/*  CALLED BY:   	      						  */           
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
    '/* strFrequency - type frequency from the database                   */
    '/* strType- type value from the database                             */
    '/* strQuantity- quantity value from the database                     */
    '/* strDatePrescribed- dispense date from the database                */
    '/* strPrescribedBy- dispensedby value from the database              */
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
    '/* lblID7 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/6/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreatePrescriptionsPanels(ByVal flpPannel As FlowLayoutPanel, ByVal strMedicationName As String, ByVal strStrength As String, ByVal strFrequency As String, ByVal strType As String, ByVal strQuantity As String, ByVal strDatePrescribed As String, ByVal strPrescribedBy As String, ByRef intMedID As Integer, ByRef intPatMEDID As Integer)
        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel
        ' call method here to get the count from the database and update the panel number so the next item is correct

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(1059, 47)
            .Name = "pnlIndividualPatientRecordPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(1059, 45)
            .Name = "pnlIndividualPatientRecord" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
        End With

        'put the boarder panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        'AddHandler pnlMainPanel.DoubleClick, AddressOf DynamicDoubleClickNewOrder
        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault
        AddHandler pnlMainPanel.Click, AddressOf PrescriptionPanel_Click


        CreateEditButton(pnlMainPanel, getPanelCount(flpPannel), lblActions.Location.X - 10, 5)
        CreateDeleteBtn(pnlMainPanel, getPanelCount(flpPannel), lblActions.Location.X + 30, 5)
        ' add controls to this panel
        ' call database info here to populate
        Dim lblID As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label
        Dim lblID5 As New Label
        Dim lblID6 As New Label
        Dim lblID7 As New Label

        AddHandler lblID.Click, AddressOf PrescriptionPanel_Click
        AddHandler lblID2.Click, AddressOf PrescriptionPanel_Click
        AddHandler lblID3.Click, AddressOf PrescriptionPanel_Click
        AddHandler lblID4.Click, AddressOf PrescriptionPanel_Click
        AddHandler lblID5.Click, AddressOf PrescriptionPanel_Click
        AddHandler lblID6.Click, AddressOf PrescriptionPanel_Click
        AddHandler lblID7.Click, AddressOf PrescriptionPanel_Click

        ' anywhere we have quotes except for the label names, we can call our Database and get method
        ' to ensure all of the text being added to the panel is inline with the  headers, we will use the label location of the
        ' header as the reference point for the X axis when creating these labels at run time.

        CreateIDLabelWithToolTip(pnlMainPanel, lblID, "lblMedicationPrescription", lblMedicationPrescription.Location.X, 20, strMedicationName, getPanelCount(flpPannel), tpToolTip, TruncateString(25, strMedicationName))
        '  CreateIDLabel(pnlMainPanel, lblID, "lblMedicationPrescription", lblMedicationPrescription.Location.X, 20, strMedicationName, getPanelCount(flpPannel))
        '  CreateIDLabel(pnlMainPanel, lblID2, "lblStrengthPrescription", lblStrengthPrescription.Location.X, 20, strStrength, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID2, "lblStrengthPrescription", lblStrengthPrescription.Location.X, 20, strStrength, getPanelCount(flpPannel), tpToolTip, TruncateString(8, strStrength))
        '  CreateIDLabel(pnlMainPanel, lblID3, "lblFrequencyPrescription", lblFrequencyPrescription.Location.X, 20, strFrequency, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID3, "lblFrequencyPrescription", lblFrequencyPrescription.Location.X, 20, strFrequency, getPanelCount(flpPannel), tpToolTip, TruncateString(8, strFrequency))
        '  CreateIDLabel(pnlMainPanel, lblID4, "lblTypePrescription", lblTypePrescription.Location.X, 20, strType, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID4, "lblTypePrescription", lblTypePrescription.Location.X, 20, strType, getPanelCount(flpPannel), tpToolTip, TruncateString(8, strType))
        '  CreateIDLabel(pnlMainPanel, lblID5, "lblQuantityPrescription", lblQuantityPrescription.Location.X, 20, strQuantity, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID5, "lblQuantityPrescription", lblQuantityPrescription.Location.X, 20, strQuantity, getPanelCount(flpPannel), tpToolTip, TruncateString(8, strQuantity))
        CreateIDLabel(pnlMainPanel, lblID6, "lblDatePrescribed", lblDatePrescribed.Location.X, 20, strDatePrescribed.Substring(0, 10), getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID7, "lblPrescribedBy", lblPrescribedBy.Location.X, 20, strPrescribedBy, getPanelCount(flpPannel), tpToolTip, TruncateString(17, strPrescribedBy))
        '  CreateIDLabel(pnlMainPanel, lblID7, "lblPrescribedBy", lblPrescribedBy.Location.X, 20, strPrescribedBy, getPanelCount(flpPannel))

        'Add panel to flow layout panel
        pnlMainPanel.Tag = intMedID

        flpPannel.Controls.Add(pnl)

        lblID.Tag = intMedID
        lblID2.Tag = intMedID
        lblID3.Tag = intMedID
        lblID4.Tag = intMedID
        lblID5.Tag = intMedID
        lblID6.Tag = intMedID
        lblID7.Tag = intMedID
        pnl.Tag = intPatMEDID

    End Sub

    Private Sub PrescriptionPanel_Click(ByVal sender As Object, e As EventArgs)

        Dim intPatientPrescriptionID As Integer = sender.parent.parent.tag
        If intPatientPrescriptionID = Nothing Then
            intPatientPrescriptionID = sender.parent.tag
        End If
        frmDispense.setPatientMedID(intPatientPrescriptionID)

        Dim intMedID As Integer = sender.tag

        Dim strPatientMRN As String

        frmDispense.SetPatientID(intPatientID)
        frmDispense.SetintMedicationID(intMedID)

        strMedName = ExecuteScalarQuery("SELECT Drug_Name From Medication WHERE Medication_ID =" & intMedID & ";")

        strPatientMRN = ExecuteScalarQuery("SELECT MRN_Number From Patient WHERE Patient_ID =" & intPatientID & ";")
        Dim intQuantity As Integer = CreateDatabase.ExecuteScalarQuery("Select Quantity from DrawerMedication where Medication_TUID = '" & intMedID & "' AND Active_Flag = '1'")
        'check if medication in drawer is empty
        If intQuantity <= 0 Then

            MessageBox.Show("Medication in drawer is empty, please restock the drawer")
        Else

            'Allergy overrides
            For Each allergy In lstBoxAllergies.Items
                If strMedName.Contains(allergy.ToString.ToLower) Then
                    'show witness sign off
                    frmWitnessSignOff.Label1.Text = strMedName
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
                                               "Values(" & intMaxAllergyID & ", " & intPatientID & ", " & LoggedInID & ", '" & allergy & "', '" & DateTime.Now & "')")
                    Else
                        '   MessageBox.Show("Dispense canceled by user.")
                        blnOverride = False
                        blnSignedOff = False
                        Exit Sub
                    End If

                Else
                    ' do nothing as there is no allergy
                    'blnSignedOff = False
                    'blnOverride = False
                End If
            Next

            'If the user didn't already sign off to dispense the medication,
            'check interactions
            DrugInteractionOverride(CStr(intMedID), strPatientMRN, "Dispense")

            If blnSignedOff = True Then
                'blnSignedOff = False

                frmMain.OpenChildForm(frmDispense)
                DispenseHistory.DispensemedicationPopulate(intPatientID, intMedID)
                PatientInformation.PopulatePatientDispenseInfo(intPatientID)
                PatientInformation.PopulatePatientAllergiesDispenseInfo(intPatientID)
                PatientInformation.DisplayPatientPrescriptionsDispense(intPatientID)
            End If
            'frmMain.OpenChildForm(frmDispense)
            'DispenseHistory.DispensemedicationPopulate(intPatientID, intMedID)
            'PatientInformation.PopulatePatientDispenseInfo(intPatientID)
            'PatientInformation.PopulatePatientAllergiesDispenseInfo(intPatientID)
            'PatientInformation.DisplayPatientPrescriptionsDispense(intPatientID)

        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: SortBySelectedLabel            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to be called as the click event for any label the  */
    '/*  user clicks on. Underline the label, and update the panel contents/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmPatientInfo_load                                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*	 parent- a panel object that the label lives on                   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 BoldLabelToSortBy(sender, parent)     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	lbl- label control*/
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SortBySelectedLabel(sender As Object, e As EventArgs)

        ' if we know the parent then we can determine if we need the prescription table
        ' or if we need the dispense history tables

        Dim parent As Panel = sender.parent
        Dim field As Integer = CInt(sender.tag)

        BoldLabelToSortBy(sender, parent)

        'check If the user Is selecting a dispense history field to sort by
        If parent.Name = pnlDispenseHistoryHeader.Name Then

            DispenseHistorySelectedField(field)
        Else
            PrescriptionsSelectedField(field)
        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: DispenseHistorySelectedField   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to be called when a user selects a label to sort by*/
    '/*  the logic to re-create the panels in the order will be caled here*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmPatientInfo_load                                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 DispenseHistorySelectedField(Cint(Label1.Tag))   	              */
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
    Private Sub DispenseHistorySelectedField(ByVal field As Integer)

        ' clear the controls as they will need to be rebuilt when sorting
        ' flpDispenseHistory.Controls.Clear()
        flpDispenseHistory.Controls.Clear()

        Select Case field

            Case DispenseHistoryEnum.MedicationName
                DispenseHistory.DispenseHistoryByDrugName(intPatientID)
            Case DispenseHistoryEnum.Strength
                DispenseHistory.DispenseHistoryByStrength(intPatientID)
            Case DispenseHistoryEnum.Type
                DispenseHistory.DispenseHistoryByType(intPatientID)
            Case DispenseHistoryEnum.Quantity
                DispenseHistory.DispenseHistoryByQuantity(intPatientID)
            Case DispenseHistoryEnum.DispensedBy
                DispenseHistory.DispenseHistoryByDispensingUser(intPatientID)
            Case DispenseHistoryEnum.DispenseDateAndTime
                DispenseHistory.DispenseHistoryByDispenseDateAndTime(intPatientID)
        End Select


    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: PrescriptionsSelectedField     */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to be called when a user selects a label to sort by*/
    '/*  the logic to re-create the panels in the order will be caled here*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmPatientInfo_load                                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*PatientInformation.PatinetInfoSortedByDrugName(intPatientID)
    '/*PatientInformation.PatinetInfoSortedByStrength(intPatientID)
    '/*PatientInformation.PatinetInfoSortedByType(intPatientID)
    '/*PatientInformation.PatinetInfoSortedByQuantity(intPatientID)
    '/*PatientInformation.PatinetInfoSortedByDate(intPatientID)
    '/*PatientInformation.PatinetInfoSortedByDoctor(intPatientID)
    '/*PatientInformation.PatinetInfoSortedByFrequency(intPatientID)      */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 PrescriptionsSelectedField(Cint(Label1.Tag))   				  */     
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
    Private Sub PrescriptionsSelectedField(ByVal field As Integer)

        ' clear the controls as they will need to be rebuilt when sorting
        flpMedications.Controls.Clear()

        Select Case field
            Case PrescriptionsEnum.MedicationName
                PatientInformation.PatinetInfoSortedByDrugName(intPatientID)
            Case PrescriptionsEnum.Strength
                PatientInformation.PatinetInfoSortedByStrength(intPatientID)
            Case PrescriptionsEnum.Type
                PatientInformation.PatinetInfoSortedByType(intPatientID)
            Case PrescriptionsEnum.Quantity
                PatientInformation.PatinetInfoSortedByQuantity(intPatientID)
            Case PrescriptionsEnum.DatePrescribed
                PatientInformation.PatinetInfoSortedByDate(intPatientID)
            Case PrescriptionsEnum.PrescribedBy
                PatientInformation.PatinetInfoSortedByDoctor(intPatientID)
            Case PrescriptionsEnum.Frequency
                PatientInformation.PatinetInfoSortedByFrequency(intPatientID)
        End Select

    End Sub


    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:     		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*											   */                     
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
    '/*  NP    2/18/2021 Changed it so that the combo boxes are enabled when*/
    '/*                  a user clikcs the edit button.                     */
    '/*  NP   2/18/2021  Made it so the comboboxes are enabled and disabled*/
    '/*                  based on the text of the edit button.             */
    '/*********************************************************************/


    Private Sub btnEditPatient_Click(sender As Object, e As EventArgs) Handles btnEditPatient.Click

        Dim expandedSize As New Size(1092, 251)
        Dim shrinkSize As New Size(1092, 139)
        Dim ctl As Control = Nothing

        Dim arrPnl As Panel() = {pnlPersonalInformation}

        If Not btnEditPatient.Text = "Save Changes" Then

            SetControlsToAllowEdit(ctl)
            enableEdits()
            pnlNameBarcode.Visible = True
            btnEditPatient.Text = "Save Changes"
            moveControlsDown(expandedSize)
            lblMoreDetails.Visible = False


        Else

            SetControlsToReadOnly(ctl)
            disableEdits()
            btnEditPatient.Text = "Edit Patient"
            PatientInformation.SavePatientEdits(intPatientID)
            pnlNameBarcode.Visible = False
            moveControlsUp(shrinkSize)
            lblMoreDetails.Visible = True
        End If

    End Sub
    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: CreatePrescriptionsPanels 	  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:     		                          */   
    '/*		              DATE CREATED: 	                              */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                   */
    '/*********************************************************************/
    Private Sub SetControlsToAllowEdit(ByVal ctl As Control)

        For Each ctl In pnlPersonalInformation.Controls

            If TypeName(ctl) = "TextBox" Then

                If ctl.Name.Contains("txtMRN") Then

                ElseIf ctl.Name.Contains("txtBirthday") Then

                Else


                    Dim txtbox As TextBox = CType(ctl, TextBox)

                    txtbox.ReadOnly = False
                    txtbox.BorderStyle = BorderStyle.FixedSingle
                    txtbox.BackColor = Color.White
                End If


            ElseIf TypeName(ctl) = "ComboBox" Then

                Dim cmbBox As ComboBox = CType(ctl, ComboBox)
                cmbBox.Enabled = True

                'cboBed.Enabled = False
                'cboRoom.Enabled = False
            End If
        Next

        For Each ctl In pnlNameBarcode.Controls
            If TypeName(ctl) = "TextBox" Then

                Dim txtbox As TextBox = CType(ctl, TextBox)

                txtbox.ReadOnly = False
                txtbox.BorderStyle = BorderStyle.FixedSingle
                txtbox.BackColor = Color.White
            End If
        Next
        mtbBirthday.ReadOnly = False
        cboState.Enabled = True
    End Sub
    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: SetControlsToReadOnly     	  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:     		                          */   
    '/*		              DATE CREATED: 	                              */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                   */
    '/*********************************************************************/
    Private Sub SetControlsToReadOnly(ByVal ctl As Control)

        For Each ctl In pnlPersonalInformation.Controls

            If TypeName(ctl) = "TextBox" Then
                Dim txtbox As TextBox = CType(ctl, TextBox)

                txtbox.ReadOnly = True
                ' txtbox.BorderStyle = BorderStyle.None
                txtbox.BackColor = Color.White


            ElseIf TypeName(ctl) = "ComboBox" Then
                Dim cmbBox As ComboBox = CType(ctl, ComboBox)

                cmbBox.BackColor = Color.White
                cmbBox.Enabled = False

            End If
        Next
        For Each ctl In pnlNameBarcode.Controls
            If TypeName(ctl) = "TextBox" Then

                Dim txtbox As TextBox = CType(ctl, TextBox)

                txtbox.ReadOnly = True
                txtbox.BorderStyle = BorderStyle.FixedSingle
                txtbox.BackColor = Color.White
            End If
        Next

        cboBed.Enabled = False
        cboRoom.Enabled = False
        cboState.Enabled = False
        mtbBirthday.ReadOnly = True
    End Sub

    ''/*********************************************************************/
    ''/*                   SUBPROGRAM NAME: btnDispenseMedication_Click 	  */         
    ''/*********************************************************************/
    ''/*                   WRITTEN BY:     		                          */   
    ''/*		              DATE CREATED: 	                              */                             
    ''/*********************************************************************/
    ''/*  FUNCTION PURPOSE:								                  */             
    ''/*											                          */                     
    ''/*                                                                   */
    ''/*********************************************************************/
    ''/*  CALLED BY:   	      						                      */           
    ''/*                                         				          */         
    ''/*********************************************************************/
    ''/*  CALLS:										                      */                 
    ''/*             (NONE)								                  */             
    ''/*********************************************************************/
    ''/*  PARAMETER LIST (In Parameter Order):					          */         
    ''/*											                          */                     
    ''/*                                                                   */  
    ''/*********************************************************************/
    ''/*  RETURNS:								                          */                   
    ''/*            (NOTHING)								              */             
    ''/*********************************************************************/
    ''/* SAMPLE INVOCATION:								                  */             
    ''/*											                          */                     
    ''/*                                                                   */ 
    ''/*********************************************************************/
    ''/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    ''/*											                          */                     
    ''/*                                                                   */  
    ''/*********************************************************************/
    ''/* MODIFICATION HISTORY:						                      */               
    ''/*											                          */                     
    ''/*  WHO   WHEN     WHAT								              */             
    ''/*  ---   ----     ------------------------------------------------- */
    ''/*                                                                   */
    ''/*********************************************************************/
    'Private Sub btnDispenseMedication_Click(sender As Object, e As EventArgs)

    '    ' pass MRN to the dispense screen because it needs to be used to be sent back to the patient info screen if the user
    '    ' decides to go back a screen.

    '    frmDispense.SetPatientID(intPatientID)
    '    frmMain.OpenChildForm(frmDispense)
    '    DispenseHistory.DispensemedicationPopulate(intPatientID)
    '    PatientInformation.PopulatePatientDispenseInfo(intPatientID)
    '    PatientInformation.PopulatePatientAllergiesDispenseInfo(intPatientID)
    '    PatientInformation.DisplayPatientPrescriptionsDispense(intPatientID)
    '    '  Dim frmCurrentForm As Form = Me


    'End Sub

    ' Private Sub Button1_Click(sender As Object, e As EventArgs)
    '     Returns.Show()
    '  End Sub
    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: btnWaste_Click            	  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:     		                          */   
    '/*		              DATE CREATED: 	                              */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                   */
    '/*********************************************************************/
    Private Sub btnWaste_Click(sender As Object, e As EventArgs)

        frmWaste.SetPatientID(intPatientID) 'this should set the patient MRN using the given patientID
        frmMain.OpenChildForm(frmWaste)

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: btnAddAllergies_Click     	  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:     		                          */   
    '/*		              DATE CREATED: 	                              */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                   */
    '/*********************************************************************/
    Private Sub btnAddAllergies_Click(sender As Object, e As EventArgs) Handles btnAddAllergies.Click

        ' pass the MRN of the current patient to the next form
        frmAllergies.SetPatientMrn(CInt(txtMRN.Text))

        ' closing this form and making the main container open the allergies page
        frmMain.OpenChildForm(frmAllergies)
    End Sub
    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: btnBack_Click            	  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:     		                          */   
    '/*		              DATE CREATED: 	                              */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                   */
    '/*********************************************************************/
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If frmMain.btnAllPatients.BackColor = Color.White Then
            frmMain.OpenChildForm(frmPatientRecords)
        Else
            frmMain.OpenChildForm(frmMyPatients)
        End If


    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  cboRoom_SelectedIndexChanged  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		               */   
    '/*		         DATE CREATED: 	3/25/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to update the cboBed list based on the selection in */
    '/*  cboRoom.                                  */
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
    '/*  dsRoomBedsOpen -- this is used to hold all the beds that are not being
    '/*             used
    '/*  dsRoomBedPatientUsing -- this holds the room and bed the patient is currently in
    '/*                 this is used if the user selects the room the patient is in
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB      3/25/2021   initial creation                                                          
    '/*********************************************************************/

    Private Sub cboRoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRoom.SelectedIndexChanged
        cboBed.Enabled = True
        cboBed.Items.Clear()

        If Not cboRoom.SelectedIndex = -1 Then
            If cboRoom.Text.Equals(cboRoom.Tag) Then
                Dim dsRoomBedsOpen As DataSet = CreateDatabase.ExecuteSelectQuery("Select Room_ID,Bed_Name from Rooms WHERE Active_Flag = '1' AND Room_ID = '" & cboRoom.Text & "' EXCEPT Select Room_TUID,Bed_Name from PatientRoom where PatientRoom.Active_Flag = '1'")
                For Each dr As DataRow In dsRoomBedsOpen.Tables(0).Rows
                    cboBed.Items.Add(dr(1))
                Next
                Dim dsRoomBedPatientUsing As DataSet = CreateDatabase.ExecuteSelectQuery("Select * from PatientRoom where Patient_TUID = '" & intPatientID & "' AND Active_Flag = '1'")
                For Each dr As DataRow In dsRoomBedPatientUsing.Tables(0).Rows
                    cboBed.Items.Add(dr(2))
                Next
            Else
                Dim dsRoomBedsOpen As DataSet = CreateDatabase.ExecuteSelectQuery("Select Room_ID,Bed_Name from Rooms WHERE Active_Flag = '1' AND Room_ID = '" & cboRoom.Text & "' EXCEPT Select Room_TUID,Bed_Name from PatientRoom where PatientRoom.Active_Flag = '1'")
                For Each dr As DataRow In dsRoomBedsOpen.Tables(0).Rows
                    cboBed.Items.Add(dr(1))
                Next
            End If
        End If
    End Sub

    Private Sub txtMRN_TextChanged(sender As Object, e As EventArgs) Handles txtMRN.KeyPress, txtPhone.KeyPress, txtZipCode.KeyPress

        DataVaildationMethods.KeyPressCheck(e, "0123456789")

    End Sub

    Private Sub txtHeight_TextChanged(sender As Object, e As EventArgs) Handles txtHeight.KeyPress, txtWeight.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.")
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.KeyPress, txtCity.KeyPress, txtEmail.KeyPress, txtBarcode.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789abcdefghijklmnopqrstuvwxyz-/@.")
    End Sub

    Private Sub txtBirthday_TextChanged(sender As Object, e As EventArgs) Handles mtbBirthday.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789")
    End Sub

    Private Sub txtBirthday_TextChanged(sender As Object, e As KeyPressEventArgs) Handles mtbBirthday.KeyPress

    End Sub

    Private Sub txtHeight_TextChanged(sender As Object, e As KeyPressEventArgs) Handles txtWeight.KeyPress, txtHeight.KeyPress

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: lblPrescriptions_Click         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/29/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to be called when a user clicks on the label. This is
    '/*  used instead of a radio button for the clean look but functions  */
    '/*  the button font is changed to indicate it is selected.            /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	  */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*		              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/29/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub lblPrescriptions_Click(sender As Object, e As EventArgs) Handles lblPrescriptions.Click

        lblPrescriptions.ForeColor = Color.Black
        lblPrescriptions.Font = New Font(New FontFamily("Segoe UI Semibold"), 14.25, FontStyle.Underline)
        lblDispenseHistory.Font = New Font(New FontFamily("Segoe UI Semibold"), 14.25, FontStyle.Bold)
        lblDispenseHistory.ForeColor = Color.DarkGray
        strSelectedLabel = lblPrescriptions.Name
        moveAndResizePanels()
    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: lblDispenseHistory_click       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/29/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to be called when a user clicks on the label. This is
    '/*  used instead of a radio button for the clean look but functions  */
    '/*  the button font is changed to indicate it is selected.            /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	  */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*		              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/29/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub lblDispenseHistory_Click(sender As Object, e As EventArgs) Handles lblDispenseHistory.Click

        lblDispenseHistory.ForeColor = Color.Black
        lblDispenseHistory.Font = New Font(New FontFamily("Segoe UI Semibold"), 14.25, FontStyle.Underline)
        lblPrescriptions.Font = New Font(New FontFamily("Segoe UI Semibold"), 14.25, FontStyle.Bold)
        lblPrescriptions.ForeColor = Color.DarkGray
        strSelectedLabel = lblDispenseHistory.Name
        moveAndResizePanels()
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: moveAndResizePanels()          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/29/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 at run time the flow panels containing dispense history and pres-*/
    '/*  criptions is is moved and the other one is hidden because only 1  /
    '/* should be visible at a time. This method handles that.             /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	  */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*		              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/29/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub moveAndResizePanels()

        ' this is the location that all of the header panels will be mounted to
        ' It is all relative to the location of the prescription labels which makes it easy to move one control
        ' and then have the rest of the controls follow
        Dim mountLocationHeaderPanel As New Point(lblPrescriptions.Location.X, lblPrescriptions.Location.Y + 50)
        Dim mountLocationFlowPanel As New Point(lblPrescriptions.Location.X, lblPrescriptions.Location.Y + 100)
        Dim flowPanelSize As New Size(1067, 320)

        If strSelectedLabel = lblDispenseHistory.Name Then

            ' hide all the other controls from the other panel
            pnlPrescriptionsHeader.Visible = False
            flpMedications.Visible = False

            ' make the other ones visible
            pnlDispenseHistoryHeader.Visible = True
            flpDispenseHistory.Visible = True

            ' move the dispense history panels because they are lower
            pnlDispenseHistoryHeader.Location = mountLocationHeaderPanel
            flpDispenseHistory.Location = mountLocationFlowPanel

            ' make the size of the flow panels larger
            flpDispenseHistory.Size = flowPanelSize

        Else

            ' hide all the other controls from the other panel
            pnlDispenseHistoryHeader.Visible = False
            flpDispenseHistory.Visible = False

            ' make the other ones visible
            pnlPrescriptionsHeader.Visible = True
            flpMedications.Visible = True

            ' move the prescriptions panels as necessary
            pnlPrescriptionsHeader.Location = mountLocationHeaderPanel
            flpMedications.Location = mountLocationFlowPanel

            'this is the size that all flow panels will be set to
            flpMedications.Size = flowPanelSize

        End If


    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: lblMoreDetails_Click()         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/29/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 if the user clicks the label to show less or more the form has to /
    '/* not only show the fields, but adjust the fields below to make sure /
    '/* they are in the correct positon                                    /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	  */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*		              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/29/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub lblMoreDetails_Click(sender As Object, e As EventArgs) Handles lblMoreDetails.Click

        Dim expandedSize As New Size(1092, 251)
        Dim shrinkSize As New Size(1092, 139)


        If lblMoreDetails.Text = "Show More..." Then
            moveControlsDown(expandedSize)
            ' change the text 
            lblMoreDetails.Text = "Show Less..."
            disableEdits()

        Else
            moveControlsUp(shrinkSize)

            ' change the text 
            lblMoreDetails.Text = "Show More..."

        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: moveControlsDown()         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/29/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 The controls need to ne moved to a specific positoin and this method
    '/* handles that. The size fo the controls will also vary and that is  /
    '/* determined by the parameter being passed in.
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*     moveAndResizePanels                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 expandedSize */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*		              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/29/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub moveControlsDown(ByVal expandedSize As Size)

        ' expand the patient info. 
        pnlPersonalInformation.Size = expandedSize

        ' show the necessary controls
        pnlNameBarcode.Visible = True

        'move labels down up
        lblDispenseHistory.Location = New Point(153, 300)
        lblPrescriptions.Location = New Point(10, 300)

        'move panels down
        moveAndResizePanels()

    End Sub



    '/*********************************************************************/
    '/*                   SubProgram NAME: moveControlsUp()               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/29/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 The controls need to ne moved to a specific positoin and this method
    '/* handles that. The size fo the controls will also vary and that is  /
    '/* determined by the parameter being passed in.
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*     moveAndResizePanels                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 shrinkSize */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*		              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/29/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub moveControlsUp(ByVal shrinkSize As Size)

        ' expand the patient info. 
        pnlPersonalInformation.Size = shrinkSize

        ' show the necessary controls
        pnlNameBarcode.Visible = False

        ' move labels back to default position
        lblDispenseHistory.Location = New Point(153, 190)
        lblPrescriptions.Location = New Point(10, 190)

        ' move panels down
        moveAndResizePanels()

    End Sub

    Private Sub txtMRN_TextChanged(sender As Object, e As KeyPressEventArgs) Handles txtZipCode.KeyPress, txtPhone.KeyPress, txtMRN.KeyPress

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  disableEdits				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/31/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to disable all the information boxes on the form so*/
    '/*  they can't be editied if we don't want them to be. this will make*/
    '/*  it far easier to turn edit mode on and off. 
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

    Private Sub disableEdits()
        txtMRN.Enabled = False
        mtbBirthday.Enabled = False
        cboSex.Enabled = False
        txtHeight.Enabled = False
        txtWeight.Enabled = False
        cboRoom.Enabled = False
        cboBed.Enabled = False
        cboPhysicians.Enabled = False
        txtEmail.Enabled = False
        txtPhone.Enabled = False
        txtAddress.Enabled = False
        txtCity.Enabled = False
        cboState.Enabled = False
        txtZipCode.Enabled = False
        txtFirstName.Enabled = False
        txtMiddle.Enabled = False
        txtLast.Enabled = False
        txtBarcode.Enabled = False
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: enableEdits					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 	3/31/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 this works as the opposite to disableEdits. It will allow us to  */
    '/*  easily turn edit mode on.                                        */
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

    Private Sub enableEdits()
        txtMRN.Enabled = True
        mtbBirthday.Enabled = True
        cboSex.Enabled = True
        txtHeight.Enabled = True
        txtWeight.Enabled = True
        cboRoom.Enabled = True
        cboBed.Enabled = True
        cboPhysicians.Enabled = True
        txtEmail.Enabled = True
        txtPhone.Enabled = True
        txtAddress.Enabled = True
        txtCity.Enabled = True
        cboState.Enabled = True
        txtZipCode.Enabled = True
        txtFirstName.Enabled = True
        txtMiddle.Enabled = True
        txtLast.Enabled = True
        txtBarcode.Enabled = True
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: moveControlsUp()               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/29/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 hides the edit button and assigns a handler as needed when looping/
    '/*  over the panels. Panel construction is important to remember if the
    '/*  nested for each loops
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                            */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*		              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/29/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub HideEditButton()

        Dim ctl As Control
        Dim pnl As Control
        Dim pnlMain As Control

        ' panel in the flow panel
        For Each ctl In flpMedications.Controls
            'panel in the pnlPadding
            For Each pnl In ctl.Controls
                'each control in the pnl main
                For Each pnlMain In pnl.Controls

                    If pnlMain.Name.Contains("Edit") Then

                        pnlMain.Visible = False

                        '   AddHandler pnlMain.VisibleChanged, AddressOf VisibleChangedEvent

                    End If
                Next
            Next
        Next

    End Sub


    Public Sub removePrescription(ByRef intPatientMedicationID As Integer)
        CreateDatabase.ExecuteInsertQuery("UPDATE PatientMedication SET Active_Flag = '0' where PatientMedication_ID = '" & intPatientMedicationID & "'")
    End Sub
End Class