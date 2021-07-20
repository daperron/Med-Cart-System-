Imports System.Data.SQLite
Module AdHoc
    '/*******************************************************************/
    '/*                   FILE NAME: AdHoc.vb                           */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*              WRITTEN BY:  Alexander Beasecker   		        */
    '/*		         DATE CREATED: January 25, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*											                        */
    '/* the purpse of this module is to handle adHoc medication orders. */
    '/* it will interact with the database to insert the adHoc order and*/ 
    '/* update the patient order history to reflect the new adHoc order */
    '/*******************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
    '/*                         (NONE)	                                */
    '/*******************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                */
    '/*                        (NOTHING)					            */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:								                */
    '/*											                        */
    '/* The program will invoke the AdHoc module when the user places an
    '/* AdHoc order. It will take the information that is placed in the 
    '/* AdHoc section and insert the information into the patient orders 
    '/* database table.
    '/*******************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                */
    '/*	intMedID -- arraylist that sits parallel to the comboBox for the medications
    '/*             this array will have the Medication ID inserted in it in the 
    '/*             same order that the medications are added to the combo box so that
    '/*             you can reference the index of the combo box in this array and get the
    '/*             medication ID*/
    '/*	intPatientID  arraylist that sits parallel to the comboBox for the Patients
    '/*             this array will have the Patients ID inserted in it in the 
    '/*             same order that the Patients are added to the combo box so that
    '/*             you can reference the index of the combo box in this array and get the
    '/*             Patients ID*/
    '/*******************************************************************/
    '/* COMPILATION NOTES:								                */
    '/* 											                    */
    '/* This project compiles normally under Microsoft Visual Basic.    */
    '/* All one needs to do Is open up the Solver project And compile.  */
    '/* No special compile options Or optimizations were used.  No      */
    '/* unresolved warnings Or errors exist under these compilation     */
    '/* conditions.									                    */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:						                    */
    '/*											                        */
    '/*  WHO                     WHEN        WHAT						*/
    '/*  Alexander Beasecker    1/25/2021   Initial creation            */
    '/*******************************************************************/
    Public intPatientIDArray As New ArrayList
    Public intMedIDArray As New ArrayList
    Public intDrawerMedArray As New ArrayList
    Public intPhysicianIDArray As New ArrayList

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:InsertAdHoc                     */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/01/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: This subroutines purpose is to take the 
    '/* information that is selected on the AdHoc order screen and insert it into the
    '/* patient Adhoc order table.
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  frmPatientRecords -- btnDispense_Click()							           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/* String.Split()
    '/* ExecuteScalarQuery()
    '/* IsDBNull()
    '/* ExecuteInsertQuery()
    '/*
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):
    '/* intPatientMRN As Integer, intUserID As Integer
    '/* intAmount As Integer
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*	InsertAdHoc('876523','10','100')										                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/* dtmAdhocTime
    '/* strArray()
    '/*	Strdatacommand
    '/* intMedicationDrawerID
    '/* intMedicationID
    '/* intMedRXCUI
    '/* intPatientID
    '/* StrSelectedMedication
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/01/2021  Initial creation of the code    */
    '/*********************************************************************/

    Public Sub InsertAdHoc(ByRef intPatientID As Integer, ByRef intUserID As Integer,
                           ByRef intAmount As Integer, ByRef intMEDID As Integer, ByRef intDrawerMEDID As Integer)
        'create variables used for insert order
        Dim Strdatacommand As String
        Dim StrSelectedMedication As String
        Dim intMedicationCount As Integer
        Dim intDrawerTUID As Integer
        Dim intDrawerNumber As Integer
        Dim intDrawerMEDTUID As Integer

        StrSelectedMedication = frmAdHockDispense.cmbMedications.SelectedItem
        intDrawerMEDTUID = intDrawerMedArray(frmAdHockDispense.cmbMedications.SelectedIndex)

        Strdatacommand = "SELECT Quantity FROM DrawerMedication WHERE Medication_TUID  = '" & intMEDID & "' AND Active_Flag = '1'"
        intMedicationCount = CreateDatabase.ExecuteScalarQuery(Strdatacommand)
        intMedicationCount = intMedicationCount - intAmount


        If Not IsDBNull(intDrawerMEDTUID) Then
            'get current time for dateTime in table
            Dim dtmAdhocTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Strdatacommand = "INSERT INTO AdHocOrder(Medication_TUID,Patient_TUID,User_TUID,Amount,DrawerMedication_TUID,DateTime) " &
                "VALUES('" & intMEDID & "', '" & intPatientID & "', '" & intUserID & "', '" & intAmount & "', '" & intDrawerMEDTUID & "', '" & dtmAdhocTime & "')"

            'insert AdHoc
            CreateDatabase.ExecuteInsertQuery(Strdatacommand)

            'send update command to the database to update the amount in the drawer minus the amount that was dispensed
            Strdatacommand = "UPDATE DrawerMedication SET Quantity = '" & intMedicationCount & "' WHERE Medication_TUID = '" & intMEDID & "'"
            CreateDatabase.ExecuteInsertQuery(Strdatacommand)
            clearAdhocBoxes()

            Strdatacommand = ("SELECT Drawers_TUID FROM DrawerMedication WHERE DrawerMedication_ID = '" & intDrawerMEDTUID & "' AND DrawerMedication.Active_Flag = '1'")
            intDrawerTUID = CreateDatabase.ExecuteScalarQuery(Strdatacommand)

            Strdatacommand = ("SELECT Drawer_Number FROM Drawers WHERE Drawers_ID = '" & intDrawerTUID & "' AND Drawers.Active_Flag = '1'")
            intDrawerNumber = CreateDatabase.ExecuteScalarQuery(Strdatacommand)
            CartInterfaceCode.OpenOneDrawer(intDrawerNumber)

        End If

    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:GetAllMedicationsForListbox                     */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/09/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: the purpose of this subroutine is too
    '/*  populate the medications listbox with all the current Active medications
    '/*  that are currently on the drawer
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  frmAdHockDispense_Load(							           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/* CreateDatabase.ExecuteSelectQuery(Strdatacommand)
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   		   
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*	GetAllMedicationsForListbox()							                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*	 Strdatacommand
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker 02/09/21	  Initial creation of the code     */
    '/*********************************************************************/
    Public Sub GetAllMedicationsForListbox()
        Dim Strdatacommand As String
        intMedIDArray.Clear()
        intDrawerMedArray.Clear()
        frmAdHockDispense.cmbMedications.Items.Clear()
        ' Currently the medication display is appending the RXCUI Number on too the medication
        ' name, as searching by name alone could cause problems if medication names can repeat
        Strdatacommand = "Select DISTINCT trim(Drug_Name,' '), RXCUI_ID, Medication_ID,DrawerMedication_ID FROM Medication INNER JOIN DrawerMedication ON DrawerMedication.Medication_TUID = Medication.Medication_ID WHERE DrawerMedication.Active_Flag = 1 ORDER BY Medication.Drug_Name COLLATE NOCASE ASC"

        Dim dsMedicationDataSet As DataSet = New DataSet
        dsMedicationDataSet = CreateDatabase.ExecuteSelectQuery(Strdatacommand)
        'add medication name and RXCUI to listbox
        For Each dr As DataRow In dsMedicationDataSet.Tables(0).Rows
            frmAdHockDispense.cmbMedications.Items.Add(dr(0) & " RXCUI: " & dr(1))
            intMedIDArray.Add(dr(2))
            intDrawerMedArray.Add(dr(3))
        Next
    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:SetMedicationProperties         */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/09/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: this subroutine is used too populate the
    '/* properties textboxes for the medication that is selected. it will
    '/* populate the method and dosage textboxes
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  frmPatientRecords.cmbMedications_SelectedIndexChanged(							           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*frmAdHockDispense.cmbMethod.Items.Clear()
    '/*frmAdHockDispense.cmbDosage.Items.Clear()
    '/*strMedicationRXCUI.Split("--")
    '/*frmAdHockDispense.cmbMethod.Items.Add(
    '/*frmAdHockDispense.cmbDosage.Items.Add(
    '/*CreateDatabase.ExecuteSelectQuery(
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   		   
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*	SetMedicationProperties()							                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/* strArray()
    '/* Strdatacommand
    '/* dsMedicationInformation
    '/* strMedicationRXCUI
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/09/21	  Initial creation of the code     */
    '/*********************************************************************/
    Public Sub SetMedicationProperties()
        If Not frmAdHockDispense.cmbMedications.SelectedIndex = -1 Then
            'clear the textboxes
            frmAdHockDispense.txtStrength.Clear()
            frmAdHockDispense.txtType.Clear()
            frmAdHockDispense.txtDrawerBin.Clear()
            frmAdHockDispense.txtUnit.Clear()
            'get selected medication ID using the selected index and get the same index from medID array
            Dim intMedID As Integer = intMedIDArray(frmAdHockDispense.cmbMedications.SelectedIndex)
            Dim intDrawerMEDID As Integer = intDrawerMedArray(frmAdHockDispense.cmbMedications.SelectedIndex)
            'select medication type and strength for the selected medication using MEDid 
            Dim Strdatacommand As String
            Strdatacommand = "SELECT Medication.Type,Medication.Strength,Drawers.Drawer_Number,DrawerMedication.Divider_Bin, DrawerMedication.Amount_Per_Container_Unit From Medication
                                Inner Join DrawerMedication ON DrawerMedication.Medication_TUID = Medication.Medication_ID
                                INNER JOIN Drawers ON Drawers.Drawers_ID = DrawerMedication.Drawers_TUID
                                WHERE Medication.Medication_ID = '" & intMedID & "' AND DrawerMedication.DrawerMedication_ID = '" & intDrawerMEDID & "'"

            'make dataset and call the sql method
            Dim dsMedicationInformation As DataSet = New DataSet
            dsMedicationInformation = CreateDatabase.ExecuteSelectQuery(Strdatacommand)

            'insert the method and dosage into textboxes
            frmAdHockDispense.txtType.Text = (dsMedicationInformation.Tables(0).Rows(0)(0))

            frmAdHockDispense.txtStrength.Text = (dsMedicationInformation.Tables(0).Rows(0)(1))
            frmAdHockDispense.txtDrawerBin.Text = "Drawer number: " & (dsMedicationInformation.Tables(0).Rows(0)(2)) & " Bin number: " & (dsMedicationInformation.Tables(0).Rows(0)(3))
            frmAdHockDispense.txtUnit.Text = (dsMedicationInformation.Tables(0).Rows(0)(4))
        End If


    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:PopulatePatientsAdhoc           */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/09/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: the purpose of this subroutine is too populate
    '/* the currently active patients into the patient combo box
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  frmAdHockDispense_Load(								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*frmAdHockDispense.cmbPatientName.Items.Clear()
    '/*CreateDatabase.ExecuteSelectQuery(Strdatacommand)
    '/*IsDBNull(
    '/*frmAdHockDispense.cmbPatientName.Items.Add(
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):	
    '/*
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*		PopulatePatientsAdhoc()									                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*Strdatacommand
    '/*dsPatientRecords
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/09/21	  Initial creation of the code     */
    '/*********************************************************************/
    Public Sub PopulatePatientsAdhoc()
        'clear patientname listbox
        frmAdHockDispense.cmbPatientName.Items.Clear()
        intPatientIDArray.Clear()
        'get patient name, first, last, and MRN number
        'MRN is appended on too the end currently because search just based on name will not work
        ' if system has multiple patients with the same name
        Dim Strdatacommand As String
        Strdatacommand = "SELECT Patient_First_Name, Patient_Last_Name, MRN_Number, Patient_ID FROM Patient WHERE Active_Flag = 1 Order By Patient_Last_Name COLLATE NOCASE, Patient_First_Name COLLATE NOCASE"

        'call sql method
        Dim dsPatientRecords As DataSet = New DataSet
        dsPatientRecords = CreateDatabase.ExecuteSelectQuery(Strdatacommand)

        'place all patients into list box
        For Each dr As DataRow In dsPatientRecords.Tables(0).Rows
            If IsDBNull(dr(0)) Then

            Else
                frmAdHockDispense.cmbPatientName.Items.Add(dr(1) & ", " & dr(0) & "  MRN:" & dr(2))
                intPatientIDArray.Add(dr(3))
            End If

        Next

    End Sub

    Public Sub PopulatePhysicianAdhoc()
        frmAdHockDispense.cmbphysician.Items.Clear()
        intPhysicianIDArray.Clear()

        Dim Strdatacommand As String
        Strdatacommand = "Select * from Physician where Active_Flag = '1' Order by Physician_Last_Name COLLATE NOCASE, Physician_First_Name COLLATE NOCASE"

        'call sql method
        Dim dsPhysicianRecords As DataSet = New DataSet
        dsPhysicianRecords = CreateDatabase.ExecuteSelectQuery(Strdatacommand)

        For Each dr As DataRow In dsPhysicianRecords.Tables(0).Rows
            If IsDBNull(dr(0)) Then

            Else
                frmAdHockDispense.cmbphysician.Items.Add("Dr. " & dr(EnumList.Physician.LastName) & ", " & dr(EnumList.Physician.FirstName) & " " & dr(EnumList.Physician.PhysicianCredentials))
                intPhysicianIDArray.Add(dr(EnumList.Physician.Id))
            End If

        Next

    End Sub



    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:PopulatePatientInformation                     */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/09/21								  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: the purpose of this subroutine is to populate
    '/* the patient information textboxes after the patient is selected.
    '/* it will fill, patient MRN, Date of Birth and allergies
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/* cmbPatientName_SelectedIndexChanged(							           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/* frmAdHockDispense.txtDateOfBirth.Clear()
    '/* frmAdHockDispense.txtMRN.Clear()
    '/* strPatientSelected.Split("--")
    '/* CreateDatabase.ExecuteSelectQuery(Strdatacommand)
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   		   
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*		PopulatePatientInformation()									                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*
    '/*strArray
    '/*Strdatacommand
    '/*intPatientID
    '/*strPatientSelected
    '/*dsPatientRecords
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/09/21	  Initial creation of the code     */
    '/*********************************************************************/
    Public Sub PopulatePatientInformation()
        If Not frmAdHockDispense.cmbPatientName.SelectedIndex = -1 Then
            'local variables for splitting array and holding patient ID
            Dim intPatientID As Integer

            'clear textboxes so no overlapping data
            frmAdHockDispense.txtDateOfBirth.Clear()
            frmAdHockDispense.txtMRN.Clear()
            frmAdHockDispense.lstboxAllergies.Items.Clear()

            intPatientID = intPatientIDArray(frmAdHockDispense.cmbPatientName.SelectedIndex)
            'create sql command string
            Dim Strdatacommand As String
            Strdatacommand = "SELECT Date_of_Birth, MRN_Number from Patient Where Patient_ID = '" & intPatientID & "'"

            'create dataset and call sql method
            Dim dsPatientRecords As DataSet = New DataSet
            dsPatientRecords = CreateDatabase.ExecuteSelectQuery(Strdatacommand)
            'set patient properties in textboxes
            frmAdHockDispense.txtDateOfBirth.Text = dsPatientRecords.Tables(0).Rows(0)(0)
            frmAdHockDispense.txtMRN.Text = dsPatientRecords.Tables(0).Rows(0)(1)
            'get patient allergies
            Strdatacommand = "SELECT Allergy_Name From PatientAllergy INNER JOIN Allergy on Allergy.Allergy_ID = PatientAllergy.Allergy_TUID Where Patient_TUID = '" & intPatientID & "'"
            dsPatientRecords = CreateDatabase.ExecuteSelectQuery(Strdatacommand)

            'place all allergies for the patient
            For Each dr As DataRow In dsPatientRecords.Tables(0).Rows
                frmAdHockDispense.lstboxAllergies.Items.Add(dr(0))
            Next
            Dim dsRoomBed As DataSet = CreateDatabase.ExecuteSelectQuery("Select * from PatientRoom where Patient_TUID = '" & intPatientID & "'")
            frmAdHockDispense.txtRoomBed.Text = "Room: " & dsRoomBed.Tables(0).Rows(0)(1) & "  Bed: " & dsRoomBed.Tables(0).Rows(0)(2)
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:clearAdhocBoxes                     */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/26/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: the purpose of tthis subroutine is to clear
    '/* all the boxes on the adhoc form.
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/* frmAdhocDispense.btnDispense_Click						           					  
    '/*********************************************************************/
    '/*  CALLS:			
    '/* frmAdHockDispense.lstboxAllergies.Items.Clear()
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   		   
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*		clearAdhocBoxes()									                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	(none)
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/26/21	  Initial creation of the code     */
    '/*********************************************************************/
    Public Sub clearAdhocBoxes()
        frmAdHockDispense.cmbMedications.SelectedIndex = -1
        frmAdHockDispense.cmbPatientName.SelectedIndex = -1
        frmAdHockDispense.txtDateOfBirth.Text = ""
        frmAdHockDispense.txtMRN.Text = ""
        frmAdHockDispense.txtAmount.Text = Nothing
        frmAdHockDispense.txtUnit.Text = Nothing

        frmAdHockDispense.txtStrength.Text = ""
        frmAdHockDispense.txtType.Text = ""
        frmAdHockDispense.txtDrawerBin.Text = ""
        frmAdHockDispense.lstboxAllergies.Items.Clear()
        frmAdHockDispense.txtRoomBed.Text = ""
        frmAdHockDispense.txtDrawerBin.Text = ""
    End Sub

End Module
