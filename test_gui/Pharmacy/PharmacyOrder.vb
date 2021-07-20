Module PharmacyOrder
    '/*******************************************************************/
    '/*                   FILE NAME: PharmacyOrder.vb                   */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*              WRITTEN BY:  Alexander Beasecker   		        */
    '/*		         DATE CREATED: January 25, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*											                        */
    '/* the purpse of this module is to handle manual pharmacy orders.  */
    '/* When a user enters the pharmacy tab and enters a new medication */
    '/* order for a patient this module handles the inserting of the    */
    '/* medication information into the patient and adhoc orders table  */
    '/*******************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
    '/*                         (NONE)	                                */
    '/*******************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                */
    '/*                        (NOTHING)					            */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:								                */
    '/*											                        */
    '/* the program will invoke this module when a user inputs a new    */
    '/* medication order for a patient through the pharmacy order screen.*/
    '/* When the new order is submitted to the patient this module will be*/
    '/* invoked to take the information and insert it to the medication */
    '/* perscription table.                                             */
    '/*******************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                */
    '/*						  	 (NONE)			                        */
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


    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:PharmacyOrder                     */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/05/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: the purpse of this method is too insert
    '/* a medication order into the database. requires patient ID, Medication ID,
    '/* physicianID, the amount ordered, the method and the dispense schedule.
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*  CreateDatabase.ExecuteInsertQuery
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):
    '/* intPatientID, intMedicationID, intPhysicianID, 
    '/* intAmount, strMethod, strSchedule
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*				PharmacyOrder("121","223532","543","15","IV drip","every 12 hours")							                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*	intActiveFlag
    '/* dtmOrderTime
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/05/2021  Initial creation of the code    */
    '/*********************************************************************/
    Public Sub PharmacyOrder(ByRef intPatientID As Integer, ByRef intMedicationID As Integer, ByRef intPhysicianID As Integer,
                             ByRef strAmount As String, ByRef strUnits As String, ByRef strType As String, ByRef strFrequency As String)

        'get current time and date
        Dim dtmOrderTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        'set active flag
        Dim intActiveFlag As Integer = 1
        'create sql statement command
        Dim Strdatacommand As String = "INSERT INTO PatientMedication(Patient_TUID, Medication_TUID, Ordering_Physician_ID, Date_Presrcibed, Quantity, Units, Type, Frequency, Active_Flag) " &
            "VALUES('" & intPatientID & "', '" & intMedicationID & "', '" & intPhysicianID & "', '" & dtmOrderTime & "', '" &
            strAmount & "', '" & strUnits & "', '" & strType & "', '" & strFrequency & "', '" & intActiveFlag & "')"
        'call sql insert method to run command
        CreateDatabase.ExecuteInsertQuery(Strdatacommand)

    End Sub

    Public Sub PopulateFrequencyNumberComboBox()
        frmPharmacy.cmbFrequencyNumber.Sorted = False
        For intCount As Integer = 1 To 24

            If intCount = 1 Then
                frmPharmacy.cmbFrequencyNumber.Items.Add(intCount & " Hour")
            Else
                frmPharmacy.cmbFrequencyNumber.Items.Add(intCount & " Hours")
            End If

        Next
    End Sub


End Module
