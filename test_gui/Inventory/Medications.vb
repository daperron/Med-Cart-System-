Module Medications
    '/*******************************************************************/
    '/*                   FILE NAME: Interactions.vb                    */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*              WRITTEN BY:  Alexander Beasecker   		        */
    '/*		         DATE CREATED: January 25, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*	The purpose of this module is used to handle medication information*/
    '/* inserting, deleting, and updating medications to the database. It*/
    '/* also handles parsing information from the RxNorm API to gather the*/
    '/* medication information for the database.                        */
    '/*                                                                 */
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
    '/* the program will invoke
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
    '/*                   SUBROUTINE NAME:InsertMedication                */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/01/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: The purpose of this subroutine is to insert
    '/*  a medication record into the medication database. this module takes
    '/*  in the generic name, RXCUI, dosage, narcotic flag, brand name and 
    '/* type. it will create a place holder for the barcode. it will
    '/* then run the sql to insert.
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*  SQLiteCommand()
    '/*  SQLiteConnection()
    '/*  DBConn.Open()
    '/*  DBConn.Close()
    '/*  DBCmd.ExecuteNonQuery()
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order): StrGenericName, intRXCUI, intDosage
    '/*   strNarcoticFlag, strBrandName, strType
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*	InsertMedication("Generic","234443","100","1","Good Brand","Pill")								                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*  Strdatacommand as string
    '/*  StrPlaceHolderBarCode as string
    '/*
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/01/2021  Initial creation of the code     */
    '/*********************************************************************/
    Public Sub InsertMedication(ByRef StrDrugName As String, ByRef intRXCUI As Integer, ByRef intDosage As Integer,
                                ByRef strNarcoticFlag As String, ByRef strType As String,
                                ByRef strStrength As String, ByRef intActiveFlag As Integer)

        'create SQLite command string and barcode placeholder
        Dim StrPlaceHolderBarCode As String = "000000000"
        Dim Strdatacommand As String

        'set up SQL objects

        'set insert statement into sqlite command object
        Strdatacommand = "INSERT INTO Medication(Drug_Name, RXCUI_ID, Dosage, NarcoticControlled_Flag, Barcode, Type, Strength,Active_Flag)
                                VALUES('" & StrDrugName & "','" & intRXCUI & "','" & intDosage & "','" & strNarcoticFlag &
                                "','" & StrPlaceHolderBarCode & "','" & strType & "','" & strStrength & "','" & intActiveFlag & "')"

        'open connection to datebase, run insert and close
        CreateDatabase.ExecuteInsertQuery(Strdatacommand)

    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:UpdateMedicationBarcode         */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/01/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: The purpose of this subroutine is to update
    '/*  the barcode attached to a specific medication record. it takes in
    '/*  the barcode and the RXCUI number for the medication and it will
    '/*  update that medications record with the new barcode
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*  SQLiteCommand()
    '/*  SQLiteConnection()
    '/*  DBConn.Open()
    '/*  DBConn.Close()
    '/*  DBCmd.ExecuteNonQuery()
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order): intRXCUI, strBarcode					   		   
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*	 UpdateMedicationBarcode("443222","123221233")										                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*	Strdatacommand as string
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/01/2021  Initial creation of the code    */
    '/*********************************************************************/
    Public Sub UpdateMedicationBarcode(ByRef intRXCUI As Integer, ByRef strBarcode As String)

        'create string for SQLite command and create placeHolder string for barcode
        Dim Strdatacommand As String

        'create update statement for setting the barcode
        Strdatacommand = "UPDATE Medication SET Barcode ='" & strBarcode & "' WHERE RXCUI_ID = '" & intRXCUI & "';"
        CreateDatabase.ExecuteInsertQuery(Strdatacommand)
    End Sub

End Module
