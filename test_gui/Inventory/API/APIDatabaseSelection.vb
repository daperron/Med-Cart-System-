'Import necessary libraries to connect to the SQLite database
Imports System.Data.SQLite
Imports System.IO
Imports System.Net
'Import necessary to use StringBuilder class
Imports System.Text
'/*******************************************************************/
'/*                   FILE NAME: APIDatabaseSelection.vb            */
'/*******************************************************************/
'/*                 PART OF PROJECT: Med_Cart				        */
'/*******************************************************************/
'/*                   WRITTEN BY: Cody Russell       		        */
'/*		         DATE CREATED: February 3, 2021			            */
'/*******************************************************************/
'/*  MODULE PURPOSE:								                */
'/*											                        */
'/* This module will allow the application to pull information      */
'/* from the database and input the information into the necessary  */  
'/* form textboxes.                                                 */
'/*******************************************************************/
'/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
'/*                                                    (NONE)	    */
'/*******************************************************************/
'/*  ENVIRONMENTAL RETURNS:							                */
'/*                          (NOTHING)					            */
'/*******************************************************************/
'/* SAMPLE INVOCATION:								                */
'/*											                        */
'/*                                                                 */
'/*******************************************************************/
'/*  GLOBAL VARIABLE LIST (Alphabetically):			                */
'/*(none)                                                          	*/
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
'/*  WHO            WHEN        WHAT								*/
'/*  Cody Russell    02/3/21   Initial creation                     */
'/*******************************************************************/
Module APIDatabaseSelection
	Public strRXCUI As String
	Public strName As String
	'/*******************************************************************/
	'/*                   Subroutine NAME:        GetDrugRXCUI		    */
	'/*******************************************************************/
	'/*              WRITTEN BY:  	Cody Russell					    */
	'/*		         DATE CREATED: 	   February 3, 2021		            */
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:									      	*/
	'/*	The purpose of this subroutine is to get the medication rxcui   */ 
	'/* number from the database.                                       */
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* GetDrugRXCUI()							        			    */
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  Cody Russell 02/3/21  Initial creation of the code	        	*/
	'/*  Cody Russell 02/5/21  Made altercations to make more readable code */
	'/*******************************************************************/
	Sub getDrugRXCUI()

		ExecuteSelectQuery("SELECT RXCUI_ID, Drug_Name, Dosage, Type FROM Medication ORDER BY ASCEND")

	End Sub

	'/*******************************************************************/
	'/*                  Subroutine NAME:        GetMedication		    */
	'/*******************************************************************/
	'/*              WRITTEN BY:  	Cody Russell					    */
	'/*		         DATE CREATED: 	   February 3, 2021		            */
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:									      	*/
	'/*	The purpose of this subroutine is to get the medication detail from */ 
	'/* the database.                                                   */
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* GetMedication()							        			    */
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  Cody Russell 02/3/21  Initial creation of the code	        	*/
	'/*  Cody Russell 02/5/21  Made altercations to make more readable code  */
	'/*******************************************************************/
	Sub getMedication()

		ExecuteSelectQuery("SELECT * FROM Medication")

	End Sub

	'/*******************************************************************/
	'/*                   Subroutine NAME:        GetDrugInteractions	*/
	'/*******************************************************************/
	'/*              WRITTEN BY:  	Cody Russell					    */
	'/*		         DATE CREATED: 	   February 5, 2021		            */
	'/*******************************************************************/
	'/*  Subroutine PURPOSE:									      	*/
	'/*	The purpose of this subroutine is to get the drug interaction   */ 
	'/* details from the database.                                      */
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* GetDrugInteractions()							                */
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  Cody Russell 02/5/21  Initial creation of the code	        	*/
	'/*******************************************************************/
	Sub GetDrugInteraction()
		ExecuteSelectQuery("SELECT * FROM Drug_Interactions")
	End Sub


	'/*******************************************************************/
	'/*                  Subroutine NAME:     CompareDrugInteractions	*/
	'/*******************************************************************/
	'/*              WRITTEN BY:  	Cody Russell					    */
	'/*		         DATE CREATED: 	   February 5, 2021		            */
	'/*******************************************************************/
	'/*  Subroutine PURPOSE:									        */
	'/*	The purpose of this subroutine is to get the drug interaction   */ 
	'/* details from the database and compare the data.                 */
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  Drug1 - Integer that holds the first medication numebr,		*/
	'/* Drug2 - Integer that holds the second medication number,        */
	'/* Severity - String that holds the severity in the database,      */
	'/* Description - String that holds the description information from*/
	'/* the database, ActiveFlag - holds the integer value of the       */
	'/* Active_Flag column.                                             */
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CompareDrugInteractions()							            */
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  dtCompareDrugInteractions - dataset that holds the information */
	'/* in each parameter in the subroutine.                            */
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  Cody Russell 02/5/21  Initial creation of the code	        	*/
	'/* Cody Russell  02/6/21  Altered this function so that it will    */
	'/* hold data in a reader than compare from the database it pulls.  */
	'/* Cody Russell  02/8/21 Altered the subroutine more to make it more*/
	'/* simple and easier to read and understand.                       */

	'/*	BRH	 03/02/21	Updated functionality for interactions			*/
	'/*******************************************************************/
	Sub CompareDrugInteractions(Drug1 As Integer, ByRef outputList As List(Of (PropertyName As String, PropertyValue As String))) ' Drug2 As Integer, Severity As String, Description As String,
		'ActiveFlag As Integer)

		'Create a dataset to hold database data
		'Dim dtCompareDrugInteractions As DataSet
		Dim intRows As Integer = 0
		Dim strStatement As String
		Dim Drug2 As Integer
		Dim Severity As String
		Dim Description As String
		Const ACTIVEFLAG As Integer = 1
		DBConn = New SQLiteConnection(strCONNECTION)
		'DBCmd = New SQLiteCommand(strStatement, DBConn)
		DBConn.Open()

		For i = 0 To outputList.Count - 4 Step 4
			Drug2 = CInt(outputList.Item(i + 3).PropertyValue)
			Severity = outputList.Item(i).PropertyValue
			Description = outputList.Item(i + 1).PropertyValue.Replace("'", "")

			'Select the specific table and the data in each column, filling a dataset through the different parameters
			strStatement = "SELECT * FROM Drug_Interactions WHERE Medication_One_ID = '" & Drug1 & "'AND Medication_Two_ID = '" & Drug2 & "'"
			DBCmd = New SQLiteCommand(strStatement, DBConn)
			Try
				intRows = DBCmd.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show("could not complete the following SQL statement: " & strStatement &
								" the following error occured: " & vbCrLf & vbCrLf & ex.ToString)
			End Try '("SELECT * FROM Drug_Interactions WHERE Medication_One_ID = '" & Drug1 & "'AND Medication_Two_ID = '" & Drug2 & "'")

			'If there isn't a medication in the database with that rxcui, insert all information into the database
			If intRows = -1 Then

				'Send an insert sql statement to the database
				'ExecuteInsertQuery("INSERT INTO Drug_Interactions(Medication_One_ID, Medication_Two_ID, 
				'Severity, Description, Active_Flag) VALUES('" & Drug1 & "','" & Drug2 & "','" &
				'Severity & "','" & Description & "','" & ACTIVEFLAG & "');")
				strStatement = "INSERT INTO Drug_Interactions(Medication_One_ID, Medication_Two_ID," &
					"Severity, Description, Active_Flag) VALUES('" & Drug1 & "','" & Drug2 & "','" &
					Severity & "','" & Description & "','" & ACTIVEFLAG & "');"
				DBCmd = New SQLiteCommand(strStatement, DBConn)
				Try
					DBCmd.ExecuteNonQuery()
				Catch ex As Exception
					MessageBox.Show("could not complete the following SQL statement: " & strStatement &
									" the following error occured: " & vbCrLf & vbCrLf & ex.ToString)
				End Try
			Else

				'Send an update sql statement to the database
				'ExecuteScalarQuery("UPDATE Drug_Interactions SET Severity = '" & Severity & "', Description = '" & Description & "', Active_Flag = '" & ActiveFlag &
				'			   "'WHERE Medication_One_ID = '" & Drug1 & "' AND Medication_Two_ID = '" & Drug2 & "';")
				strStatement = "UPDATE Drug_Interactions SET Severity = '" & Severity & "', Description = '" & Description & "', Active_Flag = '" & ACTIVEFLAG &
					"'WHERE Medication_One_ID = '" & Drug1 & "' AND Medication_Two_ID = '" & Drug2 & "';"
				DBCmd = New SQLiteCommand(strStatement, DBConn)
				Try
					DBCmd.ExecuteNonQuery()
				Catch ex As Exception
					MessageBox.Show("could not complete the following SQL statement: " & strStatement &
									" the following error occured: " & vbCrLf & vbCrLf & ex.ToString)
				End Try
			End If
			'Clear the dataset after it is sent to the database
			'dtCompareDrugInteractions.Clear()
			frmProgressBar.UpdateLabel("Inserting record " & i & " of " & outputList.Count)
			frmInventory.txtStatus.Text = ("Inserting record " & i & " of " & outputList.Count)
		Next
		' close the db connection
		DBConn.Close()
		' clear the outputList
		outputList.Clear()
		frmInventory.txtStatus.Text = ("I")
	End Sub

	'/*******************************************************************/
	'/*                  Subroutine NAME:     CompareMedications    	*/
	'/*******************************************************************/
	'/*              WRITTEN BY:  	Cody Russell					    */
	'/*		         DATE CREATED: 	   February 9, 2021		            */
	'/*******************************************************************/
	'/*  Subroutine PURPOSE:									        */
	'/*	The purpose of this subroutine is to get the medication         */ 
	'/* details from the database and compare the data.                 */
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*																	*/
	'/*																	*/
	'/*																	*/
	'/*																	*/
	'/*																	*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CompareMedications()	     						            */
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  dtCompareDrugInteractions - dataset that holds the information */
	'/* in each parameter in the subroutine.                            */
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  Cody Russell 02/9/21  Initial creation of the code	        	*/
	'/*  Cody Russell 02/9/21  Made changes to a few sql statements     */
	'/*	BRH	 02/25/21	Made changes with updated database fields		*/
	'/*	BRH	 02/27/21	Updated functionality for new API implementation*/
	'/*	BRH	 03/01/21	Updated functionality for updating a barcode	*/
	'/*******************************************************************/
	Sub CompareMedications(DrugName As String, RXCUID As String, ControlledFlag As Integer, NarcoticFlag As Integer,
								 Barcode As String, Type As String, Strength As String, Schedule As Integer, ActiveFlag As Integer)

		'Create a dataset to hold database data for that
		Dim dsMedications As DataSet
		frmInventory.txtStatus.Text = "Saving medication to database."

		'Select the specific table and the data in each column, filling a dataset through the different parameters
		'Searching by RXCUI because they are never reused or deleted
		'Source: https://www.nlm.nih.gov/research/umls/rxnorm/docs/techdoc.html Section 11.5
		dsMedications = ExecuteSelectQuery("SELECT * FROM Medication WHERE RXCUI_ID = '" & RXCUID & "'")

		'MessageBox.Show(dsMedications.Tables(0).Rows.Count)

		'If there isn't a medication in the database with that rxcui, insert all information into the database
		If dsMedications.Tables(0).Rows.Count = 0 Then

			'Send an insert sql statement to the database
			ExecuteInsertQuery("INSERT INTO Medication(Drug_Name, RXCUI_ID, Controlled_Flag, NarcoticControlled_Flag, Barcode, Type, 
			                          Strength, Schedule, Active_Flag) VALUES('" & DrugName & "','" & RXCUID & "','" & ControlledFlag & "','" & NarcoticFlag &
								"','" & Barcode & "','" & Type & "','" & Strength & "','" & Schedule & "','" & ActiveFlag & "')")

			'MessageBox.Show("Saved basic medication information to the system. Please wait...")

		Else

			For Each dsValue As DataRow In dsMedications.Tables(0).Rows
				'Send an update sql statement to the database

				If dsValue(3) <> ControlledFlag Then
					'update the controlled flag field in database
					ExecuteScalarQuery("UPDATE Medication SET Controlled_Flag = '" & ControlledFlag & "' WHERE RXCUI_ID = '" & RXCUID & "';")
				End If

				If dsValue(4) <> NarcoticFlag Then
					'update the narcotic flag field in database
					ExecuteScalarQuery("UPDATE Medication SET NarcoticControlled_Flag = '" & NarcoticFlag & "' WHERE RXCUI_ID = '" & RXCUID & "';")
				End If

				If dsValue(5) <> Barcode Then
					'update the barcode field in database
					ExecuteScalarQuery("UPDATE Medication SET Barcode = '" & Barcode & "' WHERE RXCUI_ID = '" & RXCUID & "';")
				End If

				If dsValue(6) <> Type Then
					'update the type field in database
					ExecuteScalarQuery("UPDATE Medication SET Type = '" & Type & "' WHERE RXCUI_ID = '" & RXCUID & "';")
				End If

				If dsValue(7) <> Strength Then
					'update the strength field in database
					ExecuteScalarQuery("UPDATE Medication SET Strength = '" & Strength & "' WHERE RXCUI_ID = '" & RXCUID & "';")
				End If

				If dsValue(8) <> Schedule Then
					'update the schedule field in datbase
					ExecuteScalarQuery("UPDATE Medication SET Schedule = '" & "' WHERE RXCUI_ID = '" & RXCUID & "';")
				End If

				If dsValue(9) <> ActiveFlag Then
					'update the active flag in the database
					ExecuteScalarQuery("UPDATE Medication SET Active_Flag = '" & "' WHERE RXCUI_ID = '" & RXCUID & "';")
				End If

				'MessageBox.Show("Basic Medication was updated on the system. Please wait...")

			Next

			'Clear the dataset after it is sent to the database
			dsMedications.Clear()
		End If
	End Sub

	'/*******************************************************************/
	'/*    SUBROUTINE NAME:			getDrugNameRxcui					*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   02/27/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to store the drug RXCUI and name
	'/* found in the frmInventory file									*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   cmbMedicationName_SelectedIndexChanged   						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  lstResults - Stores a list of RXCUI's and names				*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* getDrugNameRxcui(lstResults										*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  02/27/21  Initial creation of the code					*/
	'/*******************************************************************/
	Public Sub getDrugNameRxcui(lstResults As List(Of (strPropertyName As String, strPropertyValue As String)))

		For Each result In lstResults
			Select Case result.strPropertyName
				Case "RXCUI"
					strRXCUI = result.strPropertyValue
				Case "NAME"
					strName = result.strPropertyValue
			End Select
		Next
	End Sub

	'/*******************************************************************/
	'/*    SUBROUTINE NAME:			generateSampleBarcode				*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   02/27/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to generate sample barcodes for/
	'/*	insertion in the database.										*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   btnSave_Click()						   						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/* (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* generateSampleBarcode()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*	intCharacterInString - Stores the random length of the barcode	*/
	'/*  strPossibleCharacters - Stores a list of possible barcode		*/
	'/*							characters								*/
	'/*	strRandom - Stores a new random variable						*/
	'/*	strStringBuilder - Stores a new stringbuilder variable			*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  02/27/21  Initial creation of the code					*/
	'/*  BRH  03/01/21  Changed the length of possible barcodes			*/
	'/*******************************************************************/
	Function generateSampleBarcode() As String
		Dim strPossibleCharacters As String = "abcdefghijklmnopqrstuvwxyz0123456789"
		Static strRandom As New Random
		Dim intCharactersInString As Integer = strRandom.Next(5, 10)
		Dim strStringBuilder As New StringBuilder
		For i As Integer = 1 To intCharactersInString
			Dim idx As Integer = strRandom.Next(0, strPossibleCharacters.Length)
			strStringBuilder.Append(strPossibleCharacters.Substring(idx, 1))
		Next
		'Adding Sample to the end of the barcode to denote that it is a sample barcode
		strStringBuilder.Append("SAMPLE")
		Return strStringBuilder.ToString()
	End Function

	'/*********************************************************************/
	'/*                   FUNCTION NAME:  					   */         
	'/*********************************************************************/
	'/*                   WRITTEN BY:  Eric LaVoie           		         */   
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
	'/*                                                                     
	'/*********************************************************************/

	Function checkConnections() As String
		Dim strWebSite As String = "https://rxnav.nlm.nih.gov/REST/"
		Try
			frmInventory.txtStatus.Text = "Checking primary site..."
			frmProgressBar.UpdateLabel("Checking primary site...")
			Using client = New WebClient()
				Using Stream = client.OpenRead(strWebSite)
					Return strWebSite
				End Using
			End Using
			Return strWebSite
		Catch
			Try
				frmInventory.txtStatus.Text = "Checking secondary site..."
				frmProgressBar.UpdateLabel("Checking secondary site...")
				Using client = New WebClient()
					Using stream = client.OpenRead("https://10.8.30.33/REST/")
						strWebSite = "https://10.8.30.33/REST/"
						Return strWebSite
					End Using
				End Using
			Catch
				strWebSite = "ERROR"
				Return strWebSite
			End Try
		End Try
		frmInventory.txtStatus.Text = "Error with network connection"
		MessageBox.Show("Could not connect to web APIs. Please check your connection and try again later.")
		Return "ERROR"
	End Function
End Module
