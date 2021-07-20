Imports System.IO
Imports System.Net.Mail
Imports System.Text


Module BulkImportMethods
#Const debug = False
    '/*********************************************************************/
    '/*                   FILE NAME: BulkImportMethods                     */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT:	Test_gui        			   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		         */		  
    '/*		         DATE CREATED:	3/8/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 this is going to hold the methods that will handle bulk imports. */					  
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
    '/*  NP    3/24/2021 Made changes to allow the adding of rooms with   */
    '/*                  when importing patient.                          */
    '/*  NP    3/31/2021 change the format for the date required for patient*/
    '*                   imports to be to be yyyy/MM/dd                   */
    '/*********************************************************************/

    Const strPhonePattern As String = "^(1-)?\d{3}-\d{3}-\d{4}$"

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  importStart					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/8/2021	                          */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is the method that is going to kick off the bulk imports.    */ 
    '/*  it will call the other import methods that will actually do the   */
    '/*  work of importing.                                                */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 strFileName - this is the link and name of the file.             */
    '/*  strFileType - this is the tyope of file that is being imported.  */                     
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
    '/*	 srReader - this is the reader that is going to be used to read in*/
    '/*             the file.                                             */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Public Sub importStart(strFileName As String, strFileType As String)

        Try
            Dim srReader As StreamReader = New StreamReader(strFileName)
            Select Case strFileType
                Case "patient"
                    Dim PatientArray As ArrayList = ParsePatientFile(srReader)
                    If Not IsNothing(PatientArray) Then
                        addPatientToDatabase(PatientArray)
                    End If
                Case "physician"
                    Dim PhysicianArray As ArrayList = ParsePhysicianFile(srReader)
                    If Not IsNothing(PhysicianArray) Then
                        addPhysicianToDatabase(PhysicianArray)
                    End If
                Case "room"
                    Dim RoomArray As ArrayList = ParseRoomFile(srReader)
                    If Not IsNothing(RoomArray) Then
                        addRoomToDatabase(RoomArray)
                    End If
                Case "user"
                    Dim userArray As ArrayList = pareseUserFile(srReader)
                    If Not IsNothing(userArray) Then
                        addUsersToDatabase(userArray)
                    End If
                Case "drawer"
                    Dim importDrawerArray As ArrayList = parseDrawerFile(srReader)
                    If Not IsNothing(importDrawerArray) Then
                        addDrawersToDatabase(importDrawerArray)
                    End If
            End Select
            srReader.Close()
        Catch ex As Exception
#If DEBUG = True Then
            MessageBox.Show(ex.ToString)
#End If
            MessageBox.Show("Error opening file " & strFileName & " file is opened by another application")
        End Try

    End Sub



    '/*********************************************************************/
    '/*                   FUNCTION NAME:  	TextCheck   				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 3/8/2021                     		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:					                			   */             
    '/*	 This method just checcks to if a string contains a ;. It is the  */
    '/*  only character not allowed. If the text contains a ; it returns true*/
    '/*  otherwise it returns false.                                      */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					            */         
    '/*	 strTestStringText - this it the text that it is checking   	   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            blnIssue								   */             
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
    '/*  NP   3/17/2021 Filled out the comment block                      */                                                                   
    '/*********************************************************************/



    Function TextCheck(strTestStringText As String) As Boolean
        Dim blnIssue = False
        If strTestStringText.Contains(";") Then
            blnIssue = True
        End If
        Return blnIssue
    End Function

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: finishingUpImport    		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/18/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 The last four lines of the SQL statement creation are always the */
    '/*  same so I put them in a function. All it does it removes the last */
    '/*  comma on the string bulder, adds a ; to the end of the string     */
    '/*  builder, and then sends the insert statement to the database.     */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 strbSQLStatement - this is the string builder that is being used  */
    '/*                     make the sql statments.                        */                     
    '/*  ShowEnd - this is a boolean on if a pop up saying the imports is  */
    '/*            is finished should show up at the end.                  */
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
    '/*  NP    3/24/2021 made an optional paramter for is the program wants*/
    '/*                  the finished popup to show.                       */
    '/*********************************************************************/


    Sub finishingUpImport(ByRef strbSQLStatement As StringBuilder, Optional showEnd As Boolean = True)
        strbSQLStatement.Remove(strbSQLStatement.Length - 1, 1) 'remove the last comma
        strbSQLStatement.Append(";")
        CreateDatabase.ExecuteInsertQuery(strbSQLStatement.ToString)
        If showEnd Then
            MessageBox.Show("import Finished")
        End If
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  ParsePatientFile   			  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021	                           */   
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to parse the patient file the user is trying to    */  
    '/*  import and will check it for errors. If there are errors it will */
    '/*  show an error message of everything wrong with file and return   */
    '/*  nothing. Other wise it will return an array list of all the      */
    '/*  records in PatientClass objects.                                 */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 srReader - this is the stream reader that is being used to read in*/
    '/*             the file.                                              */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            PatientArray								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbErrorMessage - this is the message that is going to be built */
    '/*                     that contains all issues with the file.       */
    '/* blnIssue - this is the boolean that tells us if there was an issue*/
    '/*            with the file and we should block the import.          */
    '/* strLine - this is the array that the text from the file is sent to*/
    '/* intLineNum - this is keeping track of what line number we are on  */
    '/*              in the file so we can tell the user where the error is*/
    '/* PatientArray - this is the arraylist that will hold all the patient*/
    '/*                 objects.                                           */
    '/* strbSQLPull - this is going to be the SQL statement that pulls back*/
    '/*               if the physician exists in the datbaase.             */
    '/* UsedBarCodesArray - this is going to hold all the bar codes that   */
    '/*                     been used in the import so far. To make sure   */
    '/*                     that two active patients will not share the same*/
    '/*                     barcode.                                        */
    '/* resultDate - this is the varaible that will store the newly created */
    '/*                 date object so we can format it later.              */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/24/2021 Added a check for the room and beds.              */  
    '/*  NP    3/31/2021 change the format for the date required to be     */
    '/*                  yyyy/MM/dd                                        */
    '/*********************************************************************/


    Function ParsePatientFile(srReader As StreamReader)
        Dim strLine As String()
        Dim intLineNum As Integer = 1
        Dim blnIssue = False
        Dim strbErrorMessage As StringBuilder = New StringBuilder
        Dim strbSQLPull As StringBuilder = New StringBuilder
        Dim PatientArray As ArrayList = New ArrayList()
        Dim UsedBarCodesArray As ArrayList = New ArrayList()
        Dim resultDate As DateTime
        Do
            strLine = srReader.ReadLine.Split(vbTab)
            If strLine.Length < 17 Then
                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " record is missing information")
                blnIssue = True
            Else
                If Not IsNumeric(strLine(0)) Then
                    blnIssue = True
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " MRN Number must be numeric")
                End If
                For i As Integer = 1 To 4
                    If TextCheck(strLine(i)) Then
                        Select Case i
                            Case 1
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Barcode can not contain a ;")
                            Case 2
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Patient First Name can not contain a ;")
                            Case 3
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Patient Middle Name can not contain a ;")
                            Case 4
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Patient last name can not contain a ;")
                        End Select
                        blnIssue = True

                    End If
                Next

                strbSQLPull.Clear()
                strbSQLPull.AppendLine("Select count(*) from patient where barcode = '" & checkSQLInjection(strLine(1)) & "';")
                If CreateDatabase.ExecuteScalarQuery(strbSQLPull.ToString) <> 0 Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " two patients cannot share a barcode. " &
                                                "A patient in the database already has this barcode in use")
                    blnIssue = True
                ElseIf UsedBarCodesArray.Contains(checkSQLInjection(strLine(1))) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " two patients cannot share a barcode. " &
                                                "A patient being imported in already using this barcode.")
                    blnIssue = True
                End If
                If Not IsDate(strLine(5)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " date of birth must be a valid date")
                    blnIssue = True
                Else
                    If Convert.ToDateTime(strLine(5)) > DateTime.Now Then
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " date of birth can not be a future date")
                        blnIssue = True
                    End If

                    Try
                        resultDate = DateTime.ParseExact(strLine(5), "yyyy/MM/dd", Globalization.CultureInfo.InvariantCulture)

                    Catch ex As Exception
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Date must be the format of YYYY/MM/DD")
                        blnIssue = True
                    End Try

                End If
                If Not strLine(6).ToLower.Equals("male") And Not strLine(6).ToLower.Equals("female") Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Sex must be male or female")
                    blnIssue = True
                End If
                If Not IsNumeric(strLine(7)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " height must be numeric")
                    blnIssue = True
                End If
                If Not IsNumeric(strLine(8)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " weight must be numeric")
                    blnIssue = True
                End If
                If TextCheck(strLine(9)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Address can not contain a ;")
                    blnIssue = True
                End If
                If TextCheck(strLine(10)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " city can not contain a ;")
                    blnIssue = True
                End If
                If Not PopulateStateComboBoxesMethod.states.Contains(strLine(11), StringComparer.OrdinalIgnoreCase) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " state has to be a valid state")
                    blnIssue = True
                End If
                Try

                    Dim email = New MailAddress(strLine(12)) 'this allows .net to check
                    'to see if the email is vaild. 
                Catch ex As Exception
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " email must follow a vaild email format")
                    blnIssue = True
                End Try
                If IsNumeric(strLine(13)) Then
                    If strLine(13).Length > 5 Or strLine(13) < 5 Then
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " zip code must be 5 digits long")
                        blnIssue = True
                    End If
                Else
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " zip code must be numeric")
                    blnIssue = True
                End If
                If Not RegularExpressions.Regex.IsMatch(strLine(14), strPhonePattern) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " phone number must follow the following format xxx-xxx-xxxx with an optional 1- at the front")
                    blnIssue = True
                End If
                If Not IsNumeric(strLine(15)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Physician ID must be numeric and be a physciain in the system")
                    blnIssue = True
                Else
                    strbSQLPull.Clear()
                    strbSQLPull.Append("Select count(Physician_ID) from Physician where Physician_ID = " & strLine(15))
                    If CreateDatabase.ExecuteScalarQuery(strbSQLPull.ToString) < 1 Then
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Physician ID of " & strLine(15) &
                                                        " not found in the system. Please use the ID of a " &
                                                        "Physician that is in the system.")
                        blnIssue = True
                    End If

                End If
                For i As Integer = 16 To 17
                    If TextCheck(strLine(i)) Then
                        Select Case i
                            Case 0
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Room_ID can not contain a ;")
                                blnIssue = True
                            Case 1
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Bed_Name can not contain a ;")
                                blnIssue = True
                        End Select
                    End If
                Next
                strbSQLPull.Clear()
                strbSQLPull.Append("select count(Patient_TUID) From PatientRoom where Room_TUID = '" & strLine(16))
                strbSQLPull.Append("' and Bed_Name = '" & strLine(17) & "' and Active_Flag ='1';")
                If ExecuteScalarQuery(strbSQLPull.ToString) <> 0 Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " room and bed already assigned to a patient")
                    blnIssue = True
                End If
                If Not blnIssue Then
                    UsedBarCodesArray.Add(strLine(1))
                    PatientArray.Add(New PatientClass(strLine(0), strLine(1), strLine(2), strLine(3), strLine(4), resultDate.ToString("yyyy/MM/dd"),
                                strLine(6), strLine(7), strLine(8), strLine(9), strLine(10), strLine(11), strLine(12), strLine(13),
                                strLine(14), strLine(15), strLine(16), strLine(17)))
                End If
            End If
            intLineNum += 1
        Loop While (Not srReader.EndOfStream)
        If blnIssue Then
            MessageBox.Show(strbErrorMessage.ToString)
            PatientArray.Clear()
            PatientArray = Nothing
        End If
        Return PatientArray
    End Function

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  addPatientToDatabase    	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/9/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to loop through the PatientArray and get all the   */
    '/*  patient information into a large SQL statement to the database in*/
    '/*  one shot.                                                        */
    '/*  
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 PatientArray - this is the array list that is being added to the */
    '/*                 database.                                         */
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
    '/* intFirstRecord - this is the id of the first record so we don't   */
    '/*                  insert the record twice.                         */
    '/* strPatientInsert - this is the start of the patient insert.       */
    '/* editRoomArray - this is an array list of the rooms that we have to*/
    '/*                 edit. The rooms already exist in the database so  */
    '/*                 we only need to make sure they are active. 
    '/* strbSQLPatientStatement - this is going to be used for a number of*/
    '/*              SQL statements, It was only used for Patient insert  */
    '/*              but it was repurposes to also get information from the*/
    '/*              database and update rooms and insert into patientRooms*/
    '/*              table                                                 */
    '/* strbSQLGetRoom - this is the string builder that is used for get   */
    '/*                  room inforamtion from the database.               */
    '/* intRecordCount - this is the records that the patient record is    */
    '/*                  be when it gets added to the database so we can   */
    '/*                  use it later.                                     */
    '/* addRoomArray - this is an array list of all the rooms that need to */
    '/*                added to the database.                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/24/2021 Added functionality to add rooms and beds.       */                                                                   
    '/*********************************************************************/


    Sub addPatientToDatabase(PatientArray As ArrayList)
        Dim intRecordCount As Integer
        Dim intFirstRecord As Integer
        Dim strbSQLPatientStatement As StringBuilder = New StringBuilder
        Dim strbSQLGetRoom As StringBuilder = New StringBuilder
        Dim addRoomArray As ArrayList = New ArrayList
        Dim editRoomArray As ArrayList = New ArrayList
        Dim strPatientInsert As String = "INSERT INTO Patient ('MRN_Number', 'Barcode', 'Patient_First_Name'," &
            "'Patient_Middle_Name', 'Patient_Last_Name', 'Date_of_Birth', 'Sex', 'Height', 'Weight', " &
            "'Address', 'City', 'State', 'Zip_Code', 'Phone_Number', 'Email_address', 'Primary_Physician_ID', " &
            "'Active_Flag') Values"

        strbSQLPatientStatement.Clear()
        strbSQLPatientStatement.Append(strPatientInsert)

        With PatientArray.Item(0)
            addingPatientInformationToSQL(strbSQLPatientStatement, PatientArray.Item(0))
            strbSQLPatientStatement.Append(";")
            ExecuteInsertQuery(strbSQLPatientStatement.ToString)
            strbSQLPatientStatement.Clear()
            strbSQLPatientStatement.Append("select Patient_ID from Patient where patient_ID = (Select Max(Patient_ID) from Patient);")
            .id = ExecuteScalarQuery(strbSQLPatientStatement.ToString)
            intFirstRecord = .id
        End With
        intRecordCount = intFirstRecord


        strbSQLPatientStatement.Clear()
        strbSQLPatientStatement.Append(strPatientInsert)

        For Each Patient As PatientClass In PatientArray
            'inputing patients
            With Patient
                If Not .ID = intFirstRecord Then
                    intRecordCount += 1
                    .ID = intRecordCount
                    strbSQLGetRoom.Clear()
                    strbSQLGetRoom.Append("select count(Room_ID) From Rooms where Room_ID = '" & checkSQLInjection(.roomData.RoomID, True))
                    strbSQLGetRoom.Append("' and Bed_Name = '" & checkSQLInjection(.roomData.BedName, True) & "';")
                    'finding already exisiting rooms
                    If ExecuteScalarQuery(strbSQLGetRoom.ToString) <> 0 Then
                        editRoomArray.Add(.roomData)
                    Else
                        addRoomArray.Add(.roomData)
                    End If
                    addingPatientInformationToSQL(strbSQLPatientStatement, Patient)
                    strbSQLPatientStatement.Append(",")
                End If
            End With
        Next
        'adding patients
        finishingUpImport(strbSQLPatientStatement, False)
        'editing already exisitng rooms
        If editRoomArray.Count > 0 Then
            For Each room As RoomClass In editRoomArray
                With room
                    strbSQLPatientStatement.Clear()
                    strbSQLPatientStatement.Append("Update Rooms set Active_Flag = 1 where")
                    strbSQLPatientStatement.Append(" Room_ID ='" & checkSQLInjection(.RoomID, True) & "' and Bed_Name ='")
                    strbSQLPatientStatement.Append(checkSQLInjection(.BedName, True) & "';")
                    ExecuteInsertQuery(strbSQLPatientStatement.ToString)
                End With
            Next
        End If
        'adding new rooms
        If addRoomArray.Count > 0 Then
            addRoomToDatabase(addRoomArray, False)
        End If
        'making records in PatientRoom table
        strbSQLPatientStatement.Clear()
        strbSQLPatientStatement.Append("Insert into PatientRoom ('Patient_TUID', 'Room_TUID', 'Bed_Name', 'Active_Flag')")
        strbSQLPatientStatement.Append(" values ")
        For Each patient As PatientClass In PatientArray
            With patient
                strbSQLPatientStatement.Append("('" & .ID & "', '" & checkSQLInjection(.roomData.RoomID, True))
                strbSQLPatientStatement.Append(" ','" & checkSQLInjection(.roomData.BedName, True) & "','1'),")
            End With
        Next
        finishingUpImport(strbSQLPatientStatement)
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  addingPatientInformationToSQL  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/25/2021                       	   */                             
    '/*********************************************************************/
    '/*  addingPatientInformationToSQL PURPOSE:							   */             
    '/*	 This method exists just to add information to the string builder */
    '/*  It was made to reduce duplicated code.                           */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*  strbSQLPatientStatement - this is the string builder we will be  */
    '/*                         editing.                                  */
    '/*  Patient - this is the patient object that will getting information*/
    '/*             from.                                                  */
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


    Sub addingPatientInformationToSQL(ByRef strbSQLPatientStatement As StringBuilder, Patient As PatientClass)
        With Patient
            strbSQLPatientStatement.Append(" ('" & .MRN_Number & "', '" & checkSQLInjection(.barcode) & "', '" & checkSQLInjection(.FirstName, True) & "', '" & checkSQLInjection(.MiddleName, True) & "', '")
            strbSQLPatientStatement.Append(checkSQLInjection(.LastName, True) & "', '" & .DoB & "' , '" & .sex & "', '" & .Height & "', '" & .weight & "', '")
            strbSQLPatientStatement.Append(checkSQLInjection(.Address, True) & "', '" & checkSQLInjection(.city, True) & "', '" & .State & "', '" & .ZipCode & "', '" & .PhoneNumber & "', '")
            strbSQLPatientStatement.Append(.email & "', '" & .PrimaryPhysicianID & "', '1')")
        End With
    End Sub


    '/*********************************************************************/
    '/*                   FUNCTION NAME:  ParsePhysicianFile 		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/8/2021	                           */   
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:						                		   */             
    '/*	 This is going to parse the physician file the user is trying to  */  
    '/*  import and will check it for errors. If there are errors it will */
    '/*  show an error message of everything wrong with file and return   */
    '/*  nothing. Other wise it will return an array list of all the      */
    '/*  records in PhysicianClass objects.                               */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 srReader - this is the stream reader that is being used to read in*/
    '/*             the file.                                              */
    '/*********************************************************************/
    '/*  RETURNS:								                           */                   
    '/*            PhysicianArray								           */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbErrorMessage - this is the message that is going to be built */
    '/*                     that contains all issues with the file.       */
    '/* blnIssue - this is the boolean that tells us if there was an issue*/
    '/*            with the file and we should block the import.          */
    '/* strLine - this is the array that the text from the file is sent to*/
    '/* intLineNum - this is keeping track of what line number we are on  */
    '/*              in the file so we can tell the user where the error is*/
    '/* PhysicainArray - this is the arraylist that will hold all the physcian*/
    '/*                 objects.                                           */
    '/* strbSQLPull - this is going to be the SQL statement that pulls back*/
    '/*               if the physician exists in the datbaase.             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/12/2021 Created the code for the function.                                                                    
    '/*********************************************************************/


    Function ParsePhysicianFile(srReader As StreamReader)
        Dim PhysicianArray As ArrayList = New ArrayList()
        Dim strLine As String()
        Dim intLineNum As Integer = 1
        Dim blnIssue = False
        Dim strbErrorMessage As StringBuilder = New StringBuilder
        Dim strbSQLPull As StringBuilder = New StringBuilder

        Do
            strLine = srReader.ReadLine.Split(vbTab)
            If strLine.Length < 10 Then
                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " record is missing information")
                blnIssue = True
            Else
                For i As Integer = 0 To 3
                    If TextCheck(strLine(i)) Then
                        Select Case i
                            Case 0
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Physician First Name can not contain a ;")
                                blnIssue = True
                            Case 1
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Physician Middle Name can not contain a ;")
                                blnIssue = True
                            Case 2
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Physician Last Name can not contain a ;")
                                blnIssue = True
                            Case 3
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Physician credentials can not contain a ;")
                                blnIssue = True
                        End Select
                    End If
                Next
                If Not RegularExpressions.Regex.IsMatch(strLine(4), strPhonePattern) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " phone number must follow the following format xxx-xxx-xxxx with an optional 1- at the front")
                    blnIssue = True
                End If
                If Not RegularExpressions.Regex.IsMatch(strLine(5), strPhonePattern) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " fax number must follow the following format xxx-xxx-xxxx with an optional 1- at the front")
                    blnIssue = True
                End If
                If TextCheck(strLine(6)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Address can not contain a ;")
                    blnIssue = True
                End If
                If TextCheck(strLine(7)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " city can not contain a ;")
                    blnIssue = True
                End If
                If Not PopulateStateComboBoxesMethod.states.Contains(strLine(8), StringComparer.OrdinalIgnoreCase) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " state has to be a valid state")
                    blnIssue = True
                End If
                If IsNumeric(strLine(9)) Then
                    If strLine(9).Length > 5 Or strLine(9) < 5 Then
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " zip code must be 5 digits long")
                        blnIssue = True
                    End If
                Else
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " zip code must be numeric")
                    blnIssue = True
                End If
                If Not blnIssue Then
                    PhysicianArray.Add(New PhysicianClass(strLine(0), strLine(1), strLine(2), strLine(3), strLine(4),
                                        strLine(5), strLine(6), strLine(7), strLine(8), strLine(9)))
                End If
            End If
            intLineNum += 1
        Loop While (Not srReader.EndOfStream)

        If blnIssue Then
            MessageBox.Show(strbErrorMessage.ToString)
            PhysicianArray.Clear()
            PhysicianArray = Nothing
        End If
        Return PhysicianArray
    End Function




    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  addPhysicianToDatabase  	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                 */   
    '/*		         DATE CREATED:  3/12/2021                   		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to loop through the array list and make a large SQL*/
    '/*  statement that it is going to push to the database.              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	PhysicianArray - this is the arraylist that is going to be added to*/
    '/*                  The database.                                     */
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
    '/*	 strbSQLStatement - this is the SQL statement that will be sent   */                     
    '/*                     to the database.                              */                                                                    
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/17/2021 Filled out the comment section.                  */                                                                   
    '/*********************************************************************/


    Public Sub addPhysicianToDatabase(PhysicianArray As ArrayList)
        Dim strbSQLStatement As StringBuilder = New StringBuilder
        strbSQLStatement.Append("INSERT INTO Physician ('Physician_First_Name','Physician_Middle_Name',
                'Physician_Last_Name','Physician_Credentials','Physician_Phone_Number','Physician_Fax_Number',
                'Physician_Address','Physician_City','Physician_State','Physician_Zip_Code','Active_Flag') Values")
        For Each Physician As PhysicianClass In PhysicianArray
            With Physician
                strbSQLStatement.Append(" ('" & checkSQLInjection(.FirstName, True) & "', '" & checkSQLInjection(.MiddleName, True) & "', '" & checkSQLInjection(.LastName, True) & "', '")
                strbSQLStatement.Append(checkSQLInjection(.Credentials) & "', '" & .PhoneNumber & "', '" & .FaxNumber & "', '")
                strbSQLStatement.Append(checkSQLInjection(.Address, True) & "', '" & checkSQLInjection(.city, True) & "', '" & .State & "', '" & .ZipCode & "', '")
                strbSQLStatement.Append(1 & "'),")
            End With
        Next
        finishingUpImport(strbSQLStatement)
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  addUsersToDatabase  		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/18/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to loop through the array list and make a large SQL*/
    '/*  statement that it is going to push to the database.              */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	UserArray - this is the arraylist that is going to be added to*/
    '/*                  The database.                                     */
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbSQLStatement - this is the SQL statement that will be sent   */                     
    '/*                     to the database.                              */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Public Sub addUsersToDatabase(UserArray As ArrayList)
        Dim strbSQLStatement As StringBuilder = New StringBuilder
        strbSQLStatement.Append("INSERT INTO User ('Username','Salt','Password','User_First_Name'," &
                                "'User_Last_Name','Barcode','Admin_Flag','Supervisor_Flag','Active_Flag') Values")
        For Each user As UserClass In UserArray
            With user
                strbSQLStatement.Append(" ('" & checkSQLInjection(.UserName) & "','" & .salt & "','" & checkSQLInjection(.Password) & "','")
                strbSQLStatement.Append(checkSQLInjection(.FirstName, True) & "','" & checkSQLInjection(.LastName, True) & "','" & .Barcode & "','")
                strbSQLStatement.Append(.AdminFlag & "','" & .SuperVisorFlag & "','" & 1 & "'),")
            End With
        Next
        finishingUpImport(strbSQLStatement)
    End Sub


    '/*********************************************************************/
    '/*                   FUNCTION NAME:  pareseUserFile  				  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021	                           */   
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:				                				   */             
    '/*	 This is going to parse the user file the user is trying to      */  
    '/*  import and will check it for errors. If there are errors it will */
    '/*  show an error message of everything wrong with file and return   */
    '/*  nothing. Other wise it will return an array list of all the      */
    '/*  records in UserClass objects.                                    */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 srReader - this is the stream reader that is being used to read in*/
    '/*             the file.                                              */
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            userArray								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/* strBarcodeHash - this is going to hold the hashed barcode.         */
    '/*	strbErrorMessage - this is the message that is going to be built    */
    '/*                     that contains all issues with the file.       */
    '/* strHashedPassword - this is going to store the hased password     */
    '/* strhold - this is going to hold the results of the                */
    '/*           MakeSaltPepperAndHash method call.                      */
    '/* blnIssue - this is the boolean that tells us if there was an issue*/
    '/*            with the file and we should block the import.          */
    '/* strLine - this is the array that the text from the file is sent to*/
    '/* intLineNum - this is keeping track of what line number we are on  */
    '/*              in the file so we can tell the user where the error is*/
    '/* strSalt - this is going to store the salt for the hashed password */
    '/* strbSQLPull - this is going to be the SQL statement that pulls back*/
    '/*               if the physician exists in the datbaase.             */ 
    '/* userArray - this is the array list of users that will be added to  */
    '/*             the database if there is no issue. If there is an issue*/
    '/*             it will be nothing.                                    */
    '/* UsedBarCodesArray - this is going to hold all the bar codes that   */
    '/*                     been used in the import so far. To make sure   */
    '/*                     that two active patients will not share the same*/
    '/*                     barcode.                                        */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Function pareseUserFile(srReader As StreamReader)
        Dim UserArray As ArrayList = New ArrayList()
        Dim strLine As String()
        Dim intLineNum As Integer = 1
        Dim blnIssue = False
        Dim strbErrorMessage As StringBuilder = New StringBuilder
        Dim strbSQLPull As StringBuilder = New StringBuilder
        Dim strBarcodeHash As String = Nothing
        Dim strSalt As String
        Dim strHashedPassword As String
        Dim strhold As String()
        Dim UsedBarCodesArray As ArrayList = New ArrayList()

        Do
            strLine = srReader.ReadLine.Split(vbTab)
            If strLine.Length < 7 Then
                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " record is missing information")
                blnIssue = True
            Else
                strbSQLPull.Clear()
                strbSQLPull.AppendLine("Select count(*) from User where username = '" & checkSQLInjection(strLine(0)) & "'")
                If TextCheck(strLine(0)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Username cannot contain a ;")
                    blnIssue = True
                ElseIf ExecuteScalarQuery(strbSQLPull.ToString) <> 0 Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " username must be unqiue")
                    blnIssue = True
                End If

                If TextCheck(strLine(1)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " password cannot have a ;")
                    blnIssue = True
                ElseIf Not frmConfiguration.CheckPassword(strLine(1)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " password must contain at least 8 characters, 1 uppercase, 1 lowercase, 1 number, 1 special characters !@#$%^&* ")
                    blnIssue = True
                End If
                If TextCheck(strLine(2)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " frist name cannot have a ;")
                    blnIssue = True
                End If
                If TextCheck(strLine(3)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " last name cannot have a ;")
                    blnIssue = True
                End If

                If TextCheck(strLine(4)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " barcode cannot contain a ;")
                    blnIssue = True
                Else
                    strbSQLPull.Clear()
                    strBarcodeHash = ConvertBarcodePepperAndHash(strLine(4))
                    strbSQLPull.AppendLine("SELECT COUNT(*) FROM User WHERE Barcode = '" & strBarcodeHash & "'")
                    If ExecuteScalarQuery(strbSQLPull.ToString) <> 0 Then
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " barcode for user must be unique" &
                                                    " a user in the database is already using this barcode")
                        blnIssue = True
                    ElseIf UsedBarCodesArray.Contains(strBarcodeHash) Then
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " barcode for user must be unique" &
                                                    " a user being imported is already using this barcode")
                        blnIssue = True
                    End If
                End If
                If Not IsNumeric(strLine(5)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " admin flag must be either 1 if they are an admin or 0 if they are an admin")
                    blnIssue = True
                ElseIf strLine(5) <> 0 And strLine(5) <> 1 Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " admin flag must be a 1 if they are an admin or a 0 if they are not an admin")
                    blnIssue = True
                End If
                If Not IsNumeric(strLine(6)) Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " supervisor flag must be either 1 if they are an supervisor or 0 if they are not a supervisor")
                    blnIssue = True
                ElseIf strLine(6) <> 0 And strLine(6) <> 1 Then
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " supervisor flag must be a 1 if they are an supervisor or a 0 if they are not a supervisor")
                    blnIssue = True
                End If

                If Not blnIssue Then
                    strhold = LogIn.MakeSaltPepperAndHash(strLine(1))
                    strHashedPassword = strhold(0)
                    UsedBarCodesArray.Add(strBarcodeHash)
                    strSalt = strhold(1)
                    UserArray.Add(New UserClass(checkSQLInjection(strLine(0)), strHashedPassword, strSalt, checkSQLInjection(strLine(2), True), checkSQLInjection(strLine(3), True),
                                strBarcodeHash, strLine(5), strLine(6)))
                End If
            End If
            intLineNum += 1
        Loop While (Not srReader.EndOfStream)



        If blnIssue Then
            MessageBox.Show(strbErrorMessage.ToString)
            UserArray.Clear()
            UserArray = Nothing
        End If

        Return UserArray
    End Function

    '/*********************************************************************/
    '/*                   Function NAME: ParseRoomFile					  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021	                           */   
    '/*********************************************************************/
    '/*  Function PURPOSE:								   */             
    '/*	 This is going to parse the Room file the user is trying to      */  
    '/*  import and will check it for errors. If there are errors it will */
    '/*  show an error message of everything wrong with file and return   */
    '/*  nothing. Other wise it will return an array list of all the      */
    '/*  records in RoomClass objects.                                    */                    
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 srReader - this is the stream reader that is being used to read in*/
    '/*             the file.                                              */
    '/*********************************************************************/
    '/*  RETURNS:								                            */                   
    '/*         roomArray                  								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	strbErrorMessage - this is the message that is going to be built    */
    '/*                     that contains all issues with the file.       */
    '/* blnIssue - this is the boolean that tells us if there was an issue*/
    '/*            with the file and we should block the import.          */
    '/* strLine - this is the array that the text from the file is sent to*/
    '/* intLineNum - this is keeping track of what line number we are on  */
    '/*              in the file so we can tell the user where the error is*/
    '/* roomArray - this is the array list of rooms that will be added to  */
    '/*             the database if there is no issue. If there is an issue*/
    '/*             it will be nothing.                                    */
    '/* strbSQLPull - this is going to be the SQL statement that pulls back*/
    '/*               if the physician exists in the datbaase.             */                   
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Function ParseRoomFile(srReader As StreamReader)
        Dim roomArray = New ArrayList
        Dim strLine As String()
        Dim intLineNum As Integer = 1
        Dim blnIssue = False
        Dim strbErrorMessage As StringBuilder = New StringBuilder
        Dim strbSQLPull As StringBuilder = New StringBuilder

        Do
            strLine = srReader.ReadLine.Split(vbTab)
            If strLine.Length < 2 Then
                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " record is missing information")
                blnIssue = True
            Else
                For i As Integer = 0 To 1
                    If TextCheck(strLine(i)) Then
                        Select Case i
                            Case 0
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Room_ID can not contain a ;")
                                blnIssue = True
                            Case 1
                                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " Bed_Name can not contain a ;")
                                blnIssue = True
                        End Select
                    End If
                Next
                If Not blnIssue Then
                    roomArray.Add(New RoomClass(strLine(0), strLine(1)))
                End If
            End If
            intLineNum += 1
        Loop While (Not srReader.EndOfStream)

        If blnIssue Then
            MessageBox.Show(strbErrorMessage.ToString)
            roomArray.Clear()
            roomArray = Nothing
        End If

        Return roomArray
    End Function

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: addRoomToDatabase		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                 */   
    '/*		         DATE CREATED: 	3/17/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to create a large SQL statement that is going to   */
    '/*  push all the rooms to the database in one shot.                  */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 roomArray - this is the array list that is being added to the database*/                     
    '/*  showEnd - this is the boolean statement that is passed to the    */
    '/*            finishingUpImport method                               */
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbSQLStatement - this is the SQL statement that will be sent   */                     
    '/*                     to the database.                              */           
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Sub addRoomToDatabase(roomArray As ArrayList, Optional showEnd As Boolean = True)
        Dim strbSQLStatement As StringBuilder = New StringBuilder
        strbSQLStatement.Append("Insert Into Rooms ('Room_ID', 'Bed_Name', 'Active_Flag') Values ")
        For Each room As RoomClass In roomArray
            With room
                strbSQLStatement.Append("('" & checkSQLInjection(.RoomID, True) & "', '" & checkSQLInjection(.BedName, True) & "','")
                strbSQLStatement.Append(1 & "'),")
            End With
        Next
        finishingUpImport(strbSQLStatement, showEnd)
    End Sub


    '/*********************************************************************/
    '/*                   Function NAME: parseDrawerFile				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	4/17/2021                       	   */                             
    '/*********************************************************************/
    '/*  Function PURPOSE:								   */             
    '/*	 This is going to parse the Drawer file the user is trying to      */  
    '/*  import and will check it for errors. If there are errors it will */
    '/*  show an error message of everything wrong with file and return   */
    '/*  nothing. Other wise it will return an array list of all the      */
    '/*  records in DrawerClass objects.                                  */  
    '/*
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 srReader - this is the stream reader that is being used to read in*/
    '/*             the file.                                              */
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	strbErrorMessage - this is the message that is going to be built    */
    '/*                     that contains all issues with the file.       */
    '/* blnIssue - this is the boolean that tells us if there was an issue*/
    '/*            with the file and we should block the import.          */
    '/* strLine - this is the array that the text from the file is sent to*/
    '/* intLineNum - this is keeping track of what line number we are on  */
    '/*              in the file so we can tell the user where the error is*/
    '/* DrawerArray - this is the array list of Drawers that will be added to  */
    '/*             the database if there is no issue. If there is an issue*/
    '/*             it will be nothing.                                    */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Function parseDrawerFile(srReader As StreamReader)
        Dim DrawerArray = New ArrayList
        Dim strLine As String()
        Dim intLineNum As Integer = 1
        Dim blnIssue = False
        Dim strbErrorMessage As StringBuilder = New StringBuilder
        Dim drawerNumbersUsedArray = New ArrayList

        Do
            strLine = srReader.ReadLine.Split(vbTab)
            If strLine.Length < 4 Then
                strbErrorMessage.AppendLine("Issue on line " & intLineNum & " record is missing information")
                blnIssue = True
            Else
                If Not IsNumeric(strLine(0)) Then
                    blnIssue = True
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " drawer node must be numeric")
                ElseIf strLine(0) > 100 Or strLine(0) < 1 Then
                    blnIssue = True
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " drawer node must be between 1 and 100")
                End If
                If Not IsNumeric(strLine(1)) Then
                    blnIssue = True
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " drawer number must be numeric")
                Else
                    If strLine(1) > 100 Or strLine(1) < 1 Then
                        blnIssue = True
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " drawer number must be between 1 and 100")
                    Else

                    End If
                    If drawerNumbersUsedArray.Contains(strLine(1)) Then
                        blnIssue = True
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " drawer number already used.")
                    Else
                        drawerNumbersUsedArray.Add(strLine(1)) 'keeps track of the numbers used. 
                    End If

                End If

                If Not IsNumeric(strLine(2)) Then
                    blnIssue = True
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & " size must be numeric")
                Else
                    If strLine(2) > 100 Or strLine(2) < 1 Then
                        blnIssue = True
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " size must be between 1 and 100")
                    End If
                End If

                If Not IsNumeric(strLine(3)) Then
                    blnIssue = True
                    strbErrorMessage.AppendLine("Issue on line " & intLineNum & "  number of dividers must be numeric")
                Else
                    If strLine(3) > 10 Or strLine(3) < 0 Then
                        blnIssue = True
                        strbErrorMessage.AppendLine("Issue on line " & intLineNum & " number of divders must be between 0 and 10")
                    End If
                End If
            End If
            If Not blnIssue Then

                DrawerArray.Add(New DrawerClass(strLine(0), strLine(1), strLine(2), strLine(3)))
            End If
            intLineNum += 1
        Loop While (Not srReader.EndOfStream)


        If blnIssue Then
            MessageBox.Show(strbErrorMessage.ToString)
            DrawerArray.Clear()
            DrawerArray = Nothing
        End If

        Return DrawerArray
    End Function

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: addDrawersToDatabase			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 4/17/2021	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to go through the arraylist of drawers and make a  */
    '/*  large insert statement to add them to the database. When it      */
    '/*  adds the drawers it make the full_flag false because the drawer  */
    '/*  shouldn't have anything in them if the database is empty and the */
    '/*  active_flag is true because the record should be active if we are*/
    '/*  adding it.                                                       */
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


    Sub addDrawersToDatabase(DrawerArray As ArrayList)
        Dim strbSQLStatement As StringBuilder = New StringBuilder
        'clear everything from the database first
        strbSQLStatement.Append("Delete from Drawers")
        ExecuteInsertQuery(strbSQLStatement.ToString)
        strbSQLStatement.Clear()
        strbSQLStatement.Append("Insert into Drawers ('Drawer_Node', 'Drawer_Number', 'Size', 'Number_of_Dividers', 'Full_Flag', 'Active_Flag') Values ")
        For Each drawer As DrawerClass In DrawerArray
            With drawer
                strbSQLStatement.Append("('" & .DrawerNode & "', '" & .DrawerNumber & "', '" & .size & "','")
                strbSQLStatement.Append(.NumberOfDividers & "', '0','1'),")
            End With
        Next
        finishingUpImport(strbSQLStatement)
    End Sub
End Module
