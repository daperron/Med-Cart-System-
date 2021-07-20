Imports System.Text

Module Discrepancies
    '/*******************************************************************/
    '/*                   FILE NAME: Discrepancies.vb                   */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*              WRITTEN BY:  Alexander Beasecker   		        */
    '/*		         DATE CREATED: January 25, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*											                        */
    '/* This module is responsible the handling of the discrepancies in */
    '/* in the medications that are stored in the drawers. It handles   */
    '/* the recording of all information for the discrepancy table in   */
    '/* the database, medication generic and brand name, the dosage of  */
    '/* the medication, the amount that is missing, the name of the     */
    '/* nurse who dispensed the medication, the patient name who was to */
    '/* recieve the dispenced medication, the date and the time of the  */
    '/* discrepancy.                                                    */
    '/* It populates the discrepancies table with all current           */
    '/* discrepancies. and it handles the resolving of discrepancies.   */
    '/*                                                                 */
    '/*******************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
    '/*                         (NONE)	                                */
    '/*******************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                */
    '/*                        (NOTHING)					            */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:								                */
    '/*											                        */
    '/* the program will invoke this module in three differnet ways.    */
    '/* The first method of this module to be invoked is when the       */
    '/* dispensed medicaiton is returned to the drawer and the current  */
    '/* amount is recorded. If the expected value and the reported value are */ 
    '/* not correct this module will be invoked and it will record a    */
    '/* discrepancy.                                                    */
    '/* the second method this is invoked is when the user wants to view*/
    '/* and display all current discrepancies, it will call this module to */
    '/* display the information.                                        */
    '/* the last way this can be invoked is when the user chooses to    */
    '/* resolve a discrepancy, this module will be invoked to clear     */
    '/* the discrepancy.                                                */
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
    '/*                   FUNCTION NAME: CheckSystemCountVSActualCount    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		       */   
    '/*		         DATE CREATED: 2/22/2021 		                      */                                          
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:	the purpose of this is to check two different */
    '/*       numbers together and see if they are equal, returning a true or
    '/*      false depending
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		intSystemCount									   */                     
    '/*     intActualCount                                                                
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            Boolean, True or false     
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*		CheckSystemCountVSActualCount(10,10)				     	   */                     
    '/*           check if 10, and 10 are equal
    '/*           returns True
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*			blnCountsEqual								   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/27/2021 Initial creation
    '/*********************************************************************/

    Public Function CheckSystemCountVSActualCount(ByRef intSystemCount As Integer, ByRef intActualCount As Integer)
        Dim blnCountsEqual As Boolean = False

        If intSystemCount = intActualCount Then
            blnCountsEqual = True
        Else
            blnCountsEqual = False
        End If

        Return blnCountsEqual
    End Function

    '/*********************************************************************/
    '/*                   Sub NAME: CreateDiscrepancy    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/27/2021 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE: this sub is used to begin the creation of the discrepancies
    '/* it will create the system date object and push them along to this insert method
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*   InsertSplit                                 				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*            InsertDiscrepancy		  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*     intDiscrepID As Integer                                                                
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*      CreateDiscrepancy(10,1,25,22,1,1,1)                                                               
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*		dtmAdhocTime									   */                                                                                  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/27/2021 Initial creation
    '/*********************************************************************/
    Public Sub CreateDiscrepancy(ByRef intDrawerNumber As Integer, ByRef intBinNumber As Integer, ByRef intExpectedCount As Integer,
                                  ByRef intActualCount As Integer, ByRef intPrimaryUserID As Integer, ByRef intApprovingUserID As Integer, ByRef intMedicationTUID As Integer)

        Dim dtmAdhocTime As String = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")

        InsertDiscrepancy(intDrawerNumber, intMedicationTUID, intExpectedCount, intActualCount, intPrimaryUserID, intApprovingUserID, dtmAdhocTime)

    End Sub

    '/*********************************************************************/
    '/*                   Sub NAME: InsertDiscrepancy    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/22/2021 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE: this subs purpose is to create the sql command string
    '/*   with the provided variables to pass along to the generic insert method
    '/*  it will insert a entry into the discrepancies table
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*            ExecuteInsertQuery(strbSQL.ToString)			  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*     intDiscrepID As Integer                                                                
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*      ResolveDiscrepancies(10)                                                               
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*		dtmAdhocTime									   */                     
    '/*     strbSQL                                                               
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/22/2021 Initial creation
    '/*********************************************************************/
    Private Sub InsertDiscrepancy(ByRef intDrawerTUID As Integer, ByRef intMedicationID As Integer,
                                  ByRef intExpectedCount As Integer, ByRef intActualCount As Integer, ByRef intPrimaryUserID As Integer,
                                  ByRef intApprovingUserID As Integer, ByRef dtmDateTimeEntered As String)

        Dim strbSQL As StringBuilder = New StringBuilder
        strbSQL.Append("INSERT INTO Discrepancies(Drawer_TUID, Medication_TUID, Expected_Count, Actual_Count, Primary_User_TUID, Approving_User_TUID, DateTime_Entered, Reason) ")
        strbSQL.Append("VALUES('" & intDrawerTUID & "', '" & intMedicationID & "', '" & intExpectedCount & "', '" & intActualCount & "', '" & intPrimaryUserID & "', '" & intApprovingUserID & "', '" & dtmDateTimeEntered & "', ' ')")
        CreateDatabase.ExecuteInsertQuery(strbSQL.ToString)

        strbSQL.Clear()
        strbSQL.Append("UPDATE DrawerMedication SET Discrepancy_Flag = '1' WHERE Medication_TUID = '" & intMedicationID & "' AND Active_Flag = '1'")
        CreateDatabase.ExecuteInsertQuery(strbSQL.ToString)
    End Sub

    '/*********************************************************************/
    '/*                   Sub NAME: PopulateDiscrepancies    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/22/2021 		   */                       
    '/*********************************************************************/
    '/*  Sub PURPOSE:	this sub is used to populate all active
    '/* discrepancies to the discrepancy form
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/* strbSQL.Append(
    '*/ strbSQL.Clear()    
    '*/ frmDiscrepancies.CreatePanel(
    '*/ CreateDatabase.ExecuteSelectQuery(
    '*/ CreateDatabase.ExecuteScalarQuery(
    '*/
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
    '/*  AB    2/22/2021 Initial creation
    '/*********************************************************************/
    Public Sub PopulateDiscrepancies()
        Dim strbSQL As StringBuilder = New StringBuilder
        Dim strMedicationName As String
        Dim dsDiscrepancyDataset As DataSet
        'build sql command to return all discrepancies that do not have a cleared time
        strbSQL.Append("Select * from Discrepancies where DateTime_Cleared IS NULL")
        dsDiscrepancyDataset = CreateDatabase.ExecuteSelectQuery(strbSQL.ToString)

        'loop through each row of the dataset, call sql statement to get medication name for each discrepancy and create panel
        For Each dr As DataRow In dsDiscrepancyDataset.Tables(0).Rows
            strbSQL.Clear()
            strbSQL.Append("Select Drug_Name from Medication where Medication_ID = '" & dr(EnumList.Discrepancies.MedicationID) & "'")
            strMedicationName = CreateDatabase.ExecuteScalarQuery(strbSQL.ToString)
            frmDiscrepancies.CreatePanel(frmDiscrepancies.flpDiscrepancies, dr(EnumList.Discrepancies.ID), strMedicationName, dr(EnumList.Discrepancies.Drawer), dr(EnumList.Discrepancies.Expected), dr(EnumList.Discrepancies.actual), dr(EnumList.Discrepancies.DateTimeEntered))
        Next
    End Sub

    '/*********************************************************************/
    '/*                   Sub NAME: ResolveDiscrepancies    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/22/2021 		   */                             
    '/*********************************************************************/
    '/*  Sub PURPOSE: this sub is used to update the discrepancy cleared 
    '/* time. 
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*            ExecuteInsertQuery(strbSQL.ToString)			  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*     intDiscrepID As Integer                                                                
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*      ResolveDiscrepancies(10)                                                               
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*		dtmAdhocTime									   */                     
    '/*     strbSQL                                                               
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/22/2021 Initial creation
    '/*********************************************************************/
    Public Sub ResolveDiscrepancies(ByRef intDiscrepID As Integer, ByRef strReasonString As String)
        'create current date and time for discrepancy database table
        'create string builder to build sql command
        Dim dtmAdhocTime As String = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
        Dim strbSQL As StringBuilder = New StringBuilder
        Dim intMedicationTUID As Integer
        'create sql update statement and call generic sql subroutine
        strbSQL.Append("UPDATE Discrepancies SET DateTime_Cleared ='" & dtmAdhocTime & "', Reason = '" & strReasonString & "' WHERE Discrepancies_ID = '" & intDiscrepID & "';")
        CreateDatabase.ExecuteInsertQuery(strbSQL.ToString)
        strbSQL.Clear()
        strbSQL.Append("SELECT Medication_TUID FROM Discrepancies WHERE Discrepancies_ID = '" & intDiscrepID & "'")
        intMedicationTUID = CreateDatabase.ExecuteScalarQuery(strbSQL.ToString)

        strbSQL.Clear()
        strbSQL.Append("UPDATE DrawerMedication SET Discrepancy_Flag = '0' WHERE Medication_TUID = '" & intMedicationTUID & "' AND Active_Flag = '1'")
        CreateDatabase.ExecuteSelectQuery(strbSQL.ToString)
    End Sub

    '/*********************************************************************/
    '/*                   Sub NAME: IsInsertedAlready    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/27/2021 		   */                       
    '/*********************************************************************/
    '/*  Sub PURPOSE
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                                                                              
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                                                                                
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */                                                         
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/27/2021 Initial creation
    '/*********************************************************************/
    Public Function IsInsertedAlready(ByRef intMedicationID As String, ByRef intCount As Integer)
        Dim strbSQL As StringBuilder = New StringBuilder
        Dim strArray() As String
        strArray = intMedicationID.Split(",")
        Dim intDatabaseCount As String

        'create a sql statement for checking if a actual count is returned with the medication ID and no cleared time.
        'if the sql command returns nothing then there is no entry already, if true then it is already in the database as an uncleared discrepancy
        strbSQL.Append("SELECT Actual_Count FROM Discrepancies where Medication_TUID = " & strArray(0) & " AND DateTime_Cleared IS NULL")
        intDatabaseCount = CreateDatabase.ExecuteScalarQuery(strbSQL.ToString)

        If IsNothing(intDatabaseCount) Then
            Return False
        Else
            Return True
        End If
    End Function

    '/*********************************************************************/
    '/*                   Sub NAME: UpdateSplit    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/27/2021 		   */                       
    '/*********************************************************************/
    '/*  Sub PURPOSE:	this subs purpose is to split the string array for
    '/* the updating amount method
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*  frmEndOfSHift when saving a report and the discrepancy is already
    '/*  in the system but not cleared
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '*/ UpdateDiscrepancy
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*  intMedicationID,  intActualCount                                                                    
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*     InsertSplit(intMedicationString,12)                                                                
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											   */                     
    '/*     strArray                                                               
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/27/2021 Initial creation
    '/*********************************************************************/
    Public Sub UpdateSplit(ByRef intMedicationString As String, ByRef intCount As Integer)
        Dim strArray() As String
        strArray = intMedicationString.Split(",")
        UpdateDiscrepancy(strArray(0), intCount)
    End Sub

    '/*********************************************************************/
    '/*                   Sub NAME: UpdateDiscrepancy    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/27/2021 		   */                       
    '/*********************************************************************/
    '/*  Sub PURPOSE:	this subs purpose is to update a discrepancy amount
    '/* for a discrepancy record that is already in the system but not cleared
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*  frmEndOfSHift when saving a report and the discrepancy is already
    '/*  in the system but not cleared
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '*/ CreateDatabase.ExecuteInsertQuery(
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*  intMedicationID,  intActualCount                                                                    
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*     InsertSplit(1,12)                                                                
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											   */                     
    '/*     Strdatacommand                                                               
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/27/2021 Initial creation
    '/*********************************************************************/
    Private Sub UpdateDiscrepancy(ByRef intMedicationID As Integer, ByRef intActualCount As Integer)

        Dim Strdatacommand As String

        'create update statement for updating discrepancy amount on uncleared discrepancy
        Strdatacommand = "UPDATE Discrepancies SET Actual_Count = '" & intActualCount & "' WHERE Medication_TUID = ' " & intMedicationID & " ' AND DateTime_Cleared IS NULL"
        CreateDatabase.ExecuteInsertQuery(Strdatacommand)

    End Sub

    '/*********************************************************************/
    '/*                   Sub NAME: InsertSplit    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker    		         */   
    '/*		         DATE CREATED: 2/27/2021 		   */                       
    '/*********************************************************************/
    '/*  Sub PURPOSE:	this subs purpose is to split the string array that is 
    '/* passed to then pass it to the discrepancy inserting method
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*  frmEndOfSHift when saving a report and the discrepancy is not already 
    '*/  in the system        
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '*/ CreateDiscrepancy()
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*  intMedicationString,  intCount                                                                    
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*     InsertSplit(StringArray,12)                                                                
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											   */                     
    '/*     strArray()                                                                
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AB    2/27/2021 Initial creation
    '/*********************************************************************/
    Public Sub InsertSplit(ByRef intMedicationString As String, ByRef intCount As Integer)

        'split array that has all the medication information
        Dim strArray() As String
        strArray = intMedicationString.Split(",")

        'pass to method to create discrepancy 
        CreateDiscrepancy(strArray(2), strArray(3), strArray(4), intCount, 1, 1, strArray(0))
    End Sub

End Module
