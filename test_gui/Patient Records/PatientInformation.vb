Imports System.Data.SQLite
Imports System.Net.Mail
Imports System.Text
Module PatientInformation
#Const debug = True
    '/*******************************************************************/
    '/*                   FILE NAME: PatientInformation.vb              */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*              WRITTEN BY:  Alexander Beasecker   		        */
    '/*		         DATE CREATED: January 25, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*											                        */
    '/* This module is  reponsible for populating the patient           */
    '/* information boxes, patient first, and last name, patient MRN,   */
    '/* DOB, sex, height, weight, room number, bed number, the patient's*/
    '/* primary physician, and the patients address email and           */
    '/* phone number into the patient information form.                 */
    '/* it is also responsible for displaying the current and past      */
    '/* medication history of the patient, along with displaying patient*/
    '/* allergies and patient chart notes.                              */
    '/*ALL patient information will be imported from the database into a*/ 
    '/*list which will Then populate the tables Of data On the patient  */ 
    '/*information view                                                 */
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
    '/* the program will invoke this module when a patient chart is     */
    '/* loaded to populate the selected patients information fields.     */
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
    '/*  Adam Kott              1/27/2021   added plans for module      */
    '/*  Adam Kott              1/28/2021   added database connection   */
    '/*  Nathan Premo           2/16/2021   added getRoom method to     */
    '/*                                     connect the room combo box  */
    '/*                                     to the database.            */
    '/*******************************************************************/
    Dim intMRNInitalValue As Double

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:GetPatientInformation           */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/09/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: The purpose of this subroutine is designed to handle
    '/* the population of the patient information in the patient inforamtion
    '/* screen.
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/* ExecuteSelectQuery()
    '/* IsDBNull()
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   
    '/*											   
    '/*  intPatientMRN			   
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*											                           
    '/*   GetPatientInformation("233987")
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*	
    '/* dsPatientDataSet
    '/* intPhysicianID
    '/* strSQLiteCommand
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/09/21  Initial creation of the code      */
    '/*  NP                   02/9/2021 Changed intPhysicianID to be nothing*/
    '/*                                 When first made to remove the used*/
    '/*                                 before declared warning.          */
    '/*********************************************************************/
    Public Sub GetPatientInformation(ByRef intPatient_ID As Integer)
        PopulateStateComboBox(frmPatientInfo.cboState)
        frmPatientInfo.cboSex.Items.Clear()
        frmPatientInfo.cboSex.Items.Add("Male")
        frmPatientInfo.cboSex.Items.Add("Female")
        frmPatientInfo.cboSex.Items.Add("Other")
        Dim dsPatientDataSet As DataSet = New DataSet
        'changed be nothing when made to clear up used before declared warning. 
        Dim intPhysicianID As String = Nothing
        'sql taktement to get patient information
        Dim strSQLiteCommand As String = "SELECT * FROM Patient WHERE Patient_ID = '" & intPatient_ID & "'"

        dsPatientDataSet = CreateDatabase.ExecuteSelectQuery(strSQLiteCommand)
        ''check each piece of dataset for null, if not null set it, set to N/A if null
        For Each dr As DataRow In dsPatientDataSet.Tables(0).Rows
            ''go through and check for each piece and see if each is DBnull
            '' attach the value for each item to the .tag of tthat item
            '' the .tag field will be used to check if the text is edited in the save information methods
            If IsDBNull(dr(0)) Then
                frmPatientInfo.txtMRN.Text = "N/A"
            Else
                frmPatientInfo.txtMRN.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.MRN_Number)
                frmPatientInfo.txtMRN.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.MRN_Number)
                intMRNInitalValue = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.MRN_Number)
            End If

            If IsDBNull(dr(4)) Then
                frmPatientInfo.mtbBirthday.Text = Nothing
            Else
                frmPatientInfo.mtbBirthday.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.DoB)
                frmPatientInfo.mtbBirthday.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.DoB)
            End If

            If IsDBNull(dr(5)) Then
                frmPatientInfo.cboSex.SelectedIndex = -1
            Else
                frmPatientInfo.cboSex.SelectedItem = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Sex)
                frmPatientInfo.cboSex.Tag = frmPatientInfo.cboSex.SelectedIndex
            End If

            If IsDBNull(dr(6)) Then
                frmPatientInfo.txtHeight.Text = "N/A"
            Else
                frmPatientInfo.txtHeight.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Height)
                frmPatientInfo.txtHeight.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Height)
            End If

            If IsDBNull(dr(7)) Then
                frmPatientInfo.txtWeight.Text = "N/A"
            Else
                frmPatientInfo.txtWeight.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Weight)
                frmPatientInfo.txtWeight.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Weight)
            End If

            If IsDBNull(dr(8)) Then
                frmPatientInfo.txtAddress.Text = "N/A"
            Else
                frmPatientInfo.txtAddress.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.address)
                frmPatientInfo.txtAddress.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.address)
            End If

            If IsDBNull(dr(8)) Then
                frmPatientInfo.txtCity.Text = "N/A"
            Else
                frmPatientInfo.txtCity.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.City)
                frmPatientInfo.txtCity.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.City)
            End If

            If IsDBNull(dr(8)) Then
                frmPatientInfo.cboState.SelectedItem = "N/A"
            Else
                frmPatientInfo.cboState.SelectedItem = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.state)
                frmPatientInfo.cboState.Tag = frmPatientInfo.cboState.SelectedIndex
            End If

            If IsDBNull(dr(8)) Then
                frmPatientInfo.txtZipCode.Text = "N/A"
            Else
                frmPatientInfo.txtZipCode.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.zip)
                frmPatientInfo.txtZipCode.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.zip)
            End If

            If IsDBNull(dr(11)) Then
                frmPatientInfo.txtEmail.Text = "N/A"
            Else
                frmPatientInfo.txtEmail.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Email)
                frmPatientInfo.txtEmail.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Email)
            End If

            If IsDBNull(dr(12)) Then
                frmPatientInfo.txtPhone.Text = "N/A"
            Else
                frmPatientInfo.txtPhone.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Phone)
                frmPatientInfo.txtPhone.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.Phone)
            End If

            If IsDBNull(dr(1)) Then
                frmPatientInfo.LblPatientName.Text = "N/A"
            Else
                patientRecordLabeling(dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.FristName),
                                        dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.MiddleName),
                                        dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.LastName))
                frmPatientInfo.txtFirstName.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.FristName)
                frmPatientInfo.txtMiddle.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.MiddleName)
                frmPatientInfo.txtLast.Text = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.LastName)
                frmPatientInfo.txtFirstName.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.FristName)
                frmPatientInfo.txtMiddle.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.MiddleName)
                frmPatientInfo.txtLast.Tag = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.LastName)
            End If
            If IsDBNull(dr(2)) Then

            Else
                frmPatientInfo.txtBarcode.Text = dr(2)
                frmPatientInfo.txtBarcode.Tag = dr(2)
            End If

            intPhysicianID = dsPatientDataSet.Tables(0).Rows(0)(EnumList.Patient.PhysicianID)
        Next
        'get name of physician that is assigned to patient
        strSQLiteCommand = "SELECT Physician_First_Name,Physician_Last_Name,Physician_Credentials" &
            " FROM Physician WHERE Physician_ID = '" & intPhysicianID & "'"

        dsPatientDataSet = CreateDatabase.ExecuteSelectQuery(strSQLiteCommand)

        'check if physician fields are null
        For Each dr As DataRow In dsPatientDataSet.Tables(0).Rows
            If IsDBNull(dr(1)) Then
                'frmPatientInfo.txtPhysician.Text = "N/A"
            Else

                frmPatientInfo.cboPhysicians.Tag = (dr(1).ToString & ", " & dr(0).ToString & ", " & dr(2).ToString).ToString.Trim
                frmPatientInfo.cboPhysicians.SelectedItem = frmPatientInfo.cboPhysicians.Tag
                '   MessageBox.Show(frmPatientInfo.cboPhysicians.GetItemText(frmPatientInfo.cboPhysicians.Tag))
            End If
        Next
        'call dispense history to get dispensed history of the patient
    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:SavePatientEdits           */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   03/15/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: The purpose of this subroutine is to check and
    '/* update each value in the patient information screen that was changed
    '/* to a new value when the save button is clicked
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   
    '/*											   
    '/*  intPatientID			   
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*											                           
    '/*   SavePatientEdits("23")
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*	
    '/* intCountChanged
    '/* strbItemsChanged
    '/* intMRNCurrentValue
    '/* strbSqlCommand
    '/*
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  03/15/21  Initial creation of the code      */
    '/*  NP                   03/31/2021 Added Error checking to the code.*/
    '/*  NP                   4/7/2021   fixed an issue that caused a crash*/
    '/*                                 I had to add a second trim for the*/
    '/*                                 Physician.trim(",")               */
    '/*********************************************************************/
    Public Sub SavePatientEdits(ByRef intPatientID As Integer)
        'check if MRN is changed
        Dim intMRNCurrentValue As Double = frmPatientInfo.txtMRN.Text
        Dim strbItemsChanged As StringBuilder = New StringBuilder
        Dim intCountChanged As Integer = 0
        Dim strbSqlCommand As StringBuilder = New StringBuilder
        Dim strbErrorMessage As StringBuilder = New StringBuilder
        Dim blnIssue = False
        'this is for checking if first name was changed
        'there is a if not call for each piece of patient information
        'it checks if the .tag value is the same as what is in the box, if they are the same
        'it was not changed
        'if it is not the same then the value was changed, update the value
        'i have a count that increases after each change to track the number of items that was changed
        'and i add on to a string builder to let the user know all the items that were changed after is saves everything
        With frmPatientInfo
            If Not frmPatientInfo.txtFirstName.Text.Equals(frmPatientInfo.txtFirstName.Tag) Then
                If .txtFirstName.Text = String.Empty Or .txtFirstName.Text.Length <= 2 Then
                    strbErrorMessage.AppendLine("First must be longer than 2 character ")
                    blnIssue = True
                    .txtFirstName.Text = .txtFirstName.Tag
                ElseIf BulkImportMethods.TextCheck(frmPatientInfo.txtFirstName.Text) Then
                    strbErrorMessage.AppendLine("First name cannot contain a ;")
                    blnIssue = True
                    .txtFirstName.Text = .txtFirstName.Tag
                Else

                    strbSqlCommand.Append("UPDATE Patient SET Patient_First_Name = '" & checkSQLInjection(frmPatientInfo.txtFirstName.Text, True) & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    strbItemsChanged.AppendLine("First Name")
                    intCountChanged = intCountChanged + 1
                    strbSqlCommand.Clear()
                    frmPatientInfo.txtFirstName.Tag = frmPatientInfo.txtFirstName.Text
                End If
            End If

            'this is for checking if middle name was changed
            If Not frmPatientInfo.txtMiddle.Text.Equals(frmPatientInfo.txtMiddle.Tag) Then
                If .txtMiddle.Text = String.Empty Or .txtMiddle.Text.Length < 1 Then
                    strbErrorMessage.AppendLine("Middle name must be at least one character")
                    blnIssue = True
                    .txtMiddle.Text = .txtMiddle.Tag
                ElseIf TextCheck(.txtMiddle.Text) Then
                    strbErrorMessage.AppendLine("Middle name cannot contain a ;")
                    blnIssue = True
                    .txtMiddle.Text = .txtMiddle.Tag
                Else
                    strbSqlCommand.Append("UPDATE Patient SET Patient_Middle_Name = '" & checkSQLInjection(.txtMiddle.Text, True) & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    strbItemsChanged.AppendLine("Middle Name")
                    intCountChanged = intCountChanged + 1
                    strbSqlCommand.Clear()
                    frmPatientInfo.txtMiddle.Tag = frmPatientInfo.txtMiddle.Text
                End If
            End If

            'this is for checking if last name was changed
            If Not frmPatientInfo.txtLast.Text.Equals(frmPatientInfo.txtLast.Tag) Then
                If .txtLast.Text = String.Empty Or .txtLast.Text.Length <= 2 Then
                    strbErrorMessage.AppendLine("Last name must be longer than 2 characters")
                    blnIssue = True
                    .txtLast.Text = .txtLast.Tag
                ElseIf TextCheck(.txtLast.Text) Then
                    strbErrorMessage.Append("Last name cannot contain a ;")
                    blnIssue = True
                    .txtLast.Text = .txtLast.Tag
                Else
                    strbSqlCommand.Append("UPDATE Patient SET Patient_Last_Name = '" & checkSQLInjection(frmPatientInfo.txtLast.Text, True) & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    strbItemsChanged.AppendLine("Last Name")
                    intCountChanged = intCountChanged + 1
                    strbSqlCommand.Clear()
                    frmPatientInfo.txtLast.Tag = frmPatientInfo.txtLast.Text
                End If
            End If

            If Not intMRNCurrentValue.Equals(intMRNInitalValue) Then
                If Not IsNumeric(intMRNCurrentValue) Then
                    strbErrorMessage.AppendLine("MRN must be numeric")
                    blnIssue = True
                Else
                    'build sql update command
                    strbSqlCommand.Append("UPDATE Patient SET MRN_Number = '" & intMRNCurrentValue & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    'add item that was changed too string that is tracking all changed items
                    strbItemsChanged.AppendLine("MRN")
                    'increase changed item count
                    intCountChanged = intCountChanged + 1
                    'clear string bulder
                    strbSqlCommand.Clear()
                    'update tag to new item
                    intMRNInitalValue = intMRNCurrentValue
                End If
            End If

            'check if date of birth is changed
            If Not frmPatientInfo.mtbBirthday.Text.Equals(frmPatientInfo.mtbBirthday.Tag) Then
                If .mtbBirthday.Text = String.Empty Or Not IsDate(.mtbBirthday.Text) Then
                    strbErrorMessage.AppendLine("Date of birth must be a vaild date")
                    blnIssue = True
                    .mtbBirthday.Text = .mtbBirthday.Tag
                ElseIf Convert.ToDateTime(.mtbBirthday.Text) > Now() Then
                    strbErrorMessage.AppendLine("Date of bith cannot be a future date")
                    blnIssue = True
                    .mtbBirthday.Text = .mtbBirthday.Tag
                Else

                    'build sql update command
                    strbSqlCommand.Append("UPDATE Patient SET Date_of_Birth = '" & frmPatientInfo.mtbBirthday.Text & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    'add item that was changed too string that is tracking all changed items
                    strbItemsChanged.AppendLine("Date of birth")
                    'increase changed item count
                    intCountChanged = intCountChanged + 1
                    'clear string bulder
                    strbSqlCommand.Clear()
                    'update tag to new item
                    frmPatientInfo.mtbBirthday.Tag = frmPatientInfo.mtbBirthday.Text
                End If
            End If
            'check if sex is changed
            If Not frmPatientInfo.cboSex.SelectedIndex.Equals(frmPatientInfo.cboSex.Tag) Then
                'build sql update command
                strbSqlCommand.Append("UPDATE Patient SET Sex = '" & frmPatientInfo.cboSex.SelectedItem & "' Where Patient_ID = '" & intPatientID & "'")
                CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                'add item that was changed too string that is tracking all changed items
                strbItemsChanged.AppendLine("Sex")
                'increase changed item count
                intCountChanged = intCountChanged + 1
                'clear string bulder
                strbSqlCommand.Clear()
                'update tag to new item
                frmPatientInfo.cboSex.Tag = frmPatientInfo.cboSex.SelectedIndex
            End If

            'check if height is changed
            If Not frmPatientInfo.txtHeight.Text.Equals(frmPatientInfo.txtHeight.Tag) Then
                If Not IsNumeric(.txtHeight.Text) Then
                    .txtHeight.Text = .txtHeight.Tag
                    strbErrorMessage.AppendLine("Height must be numeric")
                    blnIssue = True

                Else
                    If Not CDbl(.txtHeight.Text) > 250 Then
                        'build sql update command
                        strbSqlCommand.Append("UPDATE Patient SET Height = '" & frmPatientInfo.txtHeight.Text & "' Where Patient_ID = '" & intPatientID & "'")
                        CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                        'add item that was changed too string that is tracking all changed items
                        strbItemsChanged.AppendLine("Height")
                        'increase changed item count
                        intCountChanged = intCountChanged + 1
                        'clear string bulder
                        strbSqlCommand.Clear()
                        'update tag to new item
                        frmPatientInfo.txtHeight.Tag = frmPatientInfo.txtHeight.Text
                    Else
                        strbErrorMessage.AppendLine("Height must be under 250cm")
                        .txtHeight.Text = .txtHeight.Tag
                        blnIssue = True
                    End If

                End If
            End If
            'check if weight is changed
            If Not frmPatientInfo.txtWeight.Text.Equals(frmPatientInfo.txtWeight.Tag) Then
                If Not IsNumeric(.txtWeight.Text) Then
                    .txtWeight.Text = .txtWeight.Tag
                    strbErrorMessage.AppendLine("Weight must be numeric")
                    blnIssue = True
                Else
                    If Not CDbl(.txtWeight.Text) > 440 Then
                        'build sql update command
                        strbSqlCommand.Append("UPDATE Patient SET Weight = '" & frmPatientInfo.txtWeight.Text & "' Where Patient_ID = '" & intPatientID & "'")
                        CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                        'add item that was changed too string that is tracking all changed items
                        strbItemsChanged.AppendLine("Weight")
                        'increase changed item count
                        intCountChanged = intCountChanged + 1
                        'clear string bulder
                        strbSqlCommand.Clear()
                        'update tag to new item
                        frmPatientInfo.txtWeight.Tag = frmPatientInfo.txtWeight.Text
                    Else
                        strbErrorMessage.AppendLine("Weight must be under 440kg")
                        blnIssue = True
                        .txtWeight.Text = .txtWeight.Tag
                    End If
                End If
            End If
            'check if email is changed
            If Not frmPatientInfo.txtEmail.Text.Equals(frmPatientInfo.txtEmail.Tag) Then
                Try

                    Dim email = New MailAddress(.txtEmail.Text) 'this allows .net to check
                    'to see if the email is vaild. 

                    'build sql update command
                    strbSqlCommand.Append("UPDATE Patient SET Email_address = '" & frmPatientInfo.txtEmail.Text & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    'add item that was changed too string that is tracking all changed items
                    strbItemsChanged.AppendLine("Email")
                    'increase changed item count
                    intCountChanged = intCountChanged + 1
                    'clear string bulder
                    strbSqlCommand.Clear()
                    'update tag to new item
                    frmPatientInfo.txtEmail.Tag = frmPatientInfo.txtEmail.Text
                Catch ex As Exception
                    strbErrorMessage.AppendLine("Email must follow a vaild email format")
                    blnIssue = True
                    .txtEmail.Text = .txtEmail.Tag
                End Try
            End If
            'check if phone is changed
            If Not frmPatientInfo.txtPhone.Text.Equals(frmPatientInfo.txtPhone.Tag) Then
                '
                If Not .txtPhone.MaskCompleted Then
                    .txtPhone.Text = .txtPhone.Tag
                    strbErrorMessage.AppendLine("Phone number must be a vaild phone number")
                    blnIssue = True
                Else
                    'build sql update command
                    strbSqlCommand.Append("UPDATE Patient SET Phone_Number = '" & frmPatientInfo.txtPhone.Text & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    'add item that was changed too string that is tracking all changed items
                    strbItemsChanged.AppendLine("Phone Number")
                    'increase changed item count
                    intCountChanged = intCountChanged + 1
                    'clear string bulder
                    strbSqlCommand.Clear()
                    'update tag to new item
                    frmPatientInfo.txtPhone.Tag = frmPatientInfo.txtPhone.Text
                End If
            End If

            'check if street address is changed
            If Not frmPatientInfo.txtAddress.Text.Equals(frmPatientInfo.txtAddress.Tag) Then
                If Not frmPatientInfo.txtAddress.Text.Trim.Length = 0 And frmPatientInfo.txtAddress.Text.Length > 2 Then

                    If TextCheck(.txtAddress.Text) Then
                        strbErrorMessage.AppendLine("Address cannot contain a ;")
                        blnIssue = True
                        .txtAddress.Text = .txtAddress.Tag
                    Else
                        'build sql update command
                        strbSqlCommand.Append("UPDATE Patient SET Address = '" & checkSQLInjection(frmPatientInfo.txtAddress.Text, True) & "' Where Patient_ID = '" & intPatientID & "'")
                        CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                        'add item that was changed too string that is tracking all changed items
                        strbItemsChanged.AppendLine("Street Address")
                        'increase changed item count
                        intCountChanged = intCountChanged + 1
                        'clear string bulder
                        strbSqlCommand.Clear()
                        'update tag to new item
                        frmPatientInfo.txtAddress.Tag = frmPatientInfo.txtAddress.Text
                    End If
                Else
                    strbErrorMessage.AppendLine("Address must be longer than 2 characters")
                    blnIssue = True
                    .txtAddress.Text = .txtAddress.Tag
                End If
            End If
            'check if city is changed
            Dim intlength As Integer = frmPatientInfo.txtCity.Text.Length
            If Not frmPatientInfo.txtCity.Text.Equals(frmPatientInfo.txtCity.Tag) Then
                If Not frmPatientInfo.txtCity.Text.Trim.Length = 0 And frmPatientInfo.txtCity.Text.Length > 2 Then
                    If TextCheck(.txtCity.Text) Then
                        strbErrorMessage.AppendLine("City cannot contain a ;")
                        blnIssue = True
                        .txtCity.Text = .txtCity.Tag
                    Else
                        'build sql update command
                        strbSqlCommand.Append("UPDATE Patient SET City = '" & checkSQLInjection(frmPatientInfo.txtCity.Text, True) & "' Where Patient_ID = '" & intPatientID & "'")
                        CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                        'add item that was changed too string that is tracking all changed items
                        strbItemsChanged.AppendLine("City")
                        'increase changed item count
                        intCountChanged = intCountChanged + 1
                        'clear string bulder
                        strbSqlCommand.Clear()
                        'update tag to new item
                        frmPatientInfo.txtCity.Tag = frmPatientInfo.txtCity.Text
                    End If
                Else
                    strbErrorMessage.AppendLine("City must be longer than 2 characters")
                    blnIssue = True
                    .txtCity.Text = .txtCity.Tag
                End If
            End If
            'check if state is changed
            If Not frmPatientInfo.cboState.SelectedIndex.Equals(frmPatientInfo.cboState.Tag) Then
                'build sql update command
                strbSqlCommand.Append("UPDATE Patient SET State = '" & frmPatientInfo.cboState.SelectedItem & "' Where Patient_ID = '" & intPatientID & "'")
                CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                'add item that was changed too string that is tracking all changed items
                strbItemsChanged.AppendLine("State")
                'increase changed item count
                intCountChanged = intCountChanged + 1
                'clear string bulder
                strbSqlCommand.Clear()
                'update tag to new item
                frmPatientInfo.cboState.Tag = frmPatientInfo.cboState.SelectedIndex
            End If
            'check if zip code is changed
            If Not frmPatientInfo.txtZipCode.Text.Equals(frmPatientInfo.txtZipCode.Tag) Then
                If Not .txtZipCode.Text.Length = 5 Then
                    strbErrorMessage.AppendLine("Zipcode must be 5 digits in length")
                    blnIssue = True
                    .txtZipCode.Text = .txtZipCode.Tag
                Else
                    'build sql update command
                    strbSqlCommand.Append("UPDATE Patient SET Zip_Code = '" & frmPatientInfo.txtZipCode.Text & "' Where Patient_ID = '" & intPatientID & "'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    'add item that was changed too string that is tracking all changed items
                    strbItemsChanged.AppendLine("ZipCode")
                    'increase changed item count
                    intCountChanged = intCountChanged + 1
                    'clear string bulder
                    strbSqlCommand.Clear()
                    'update tag to new item
                    frmPatientInfo.txtZipCode.Tag = frmPatientInfo.txtZipCode.Text
                End If
            End If

            If Not frmPatientInfo.txtBarcode.Text.Equals(frmPatientInfo.txtBarcode.Tag) Then
                If Not frmPatientInfo.txtBarcode.Text.Trim.Length = 0 And frmPatientInfo.txtBarcode.Text.Length > 4 Then
                    If TextCheck(.txtBarcode.Text) Then
                        strbErrorMessage.AppendLine("Barcode cannot contain a ;")
                        blnIssue = True
                        .txtBarcode.Text = .txtBarcode.Tag
                    Else
                        'check if barcode is already assigned to patient
                        Dim cmdSQLExistsCheck As String = "Select Count(Patient_ID) from Patient where Barcode = '" & .txtBarcode.Text & "'"
                        If ExecuteScalarQuery(cmdSQLExistsCheck) = 0 Then
                            'build sql update command
                            strbSqlCommand.Append("UPDATE Patient SET Barcode = '" & frmPatientInfo.txtBarcode.Text & "' Where Patient_ID = '" & intPatientID & "'")
                            CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                            'add item that was changed too string that is tracking all changed items
                            strbItemsChanged.AppendLine("Barcode")
                            'increase changed item count
                            intCountChanged = intCountChanged + 1
                            'clear string bulder
                            strbSqlCommand.Clear()
                            'update tag to new item
                            frmPatientInfo.txtBarcode.Tag = frmPatientInfo.txtBarcode.Text
                        Else
                            strbErrorMessage.AppendLine("Barcode must be unique")
                            blnIssue = True
                            .txtBarcode.Text = .txtBarcode.Tag
                        End If
                    End If
                Else
                    strbErrorMessage.AppendLine("Barcode must be longer than 4 characters")
                    blnIssue = True
                    .txtBarcode.Text = .txtBarcode.Tag
                End If
            End If
            If Not frmPatientInfo.cboBed.SelectedIndex = -1 Then
                Dim strRoomBed As String = frmPatientInfo.cboRoom.Text & frmPatientInfo.cboBed.Text
                Dim strTagRoomBed As String = frmPatientInfo.cboRoom.Tag & frmPatientInfo.cboBed.Tag

                'get the tag room and bed, the tag room and bed are the room and bed the patient is currently in.
                'check to see if the room and bed changed by checking if they are equal.
                'if they are equal then it didnt change
                'if they are not equal then they did change and update the room
                If Not strTagRoomBed.Equals(strRoomBed) Then
                    strbSqlCommand.Clear()
                    strbSqlCommand.Append("UPDATE PatientRoom SET Active_Flag = '0' Where Patient_TUID = '" & intPatientID & "' AND Active_Flag = '1'")
                    CreateDatabase.ExecuteInsertQuery(strbSqlCommand.ToString)
                    strbSqlCommand.Clear()
                    Dim strCheck As String = CreateDatabase.ExecuteScalarQuery("SELECT Room_TUID FROM PatientRoom where Patient_TUID = '" & intPatientID & "' AND Room_TUID = '" & frmPatientInfo.cboRoom.Text & "' AND Bed_Name = '" & frmPatientInfo.cboBed.Text & "' AND Active_Flag = '0'")
                    If IsNothing(strCheck) Then
                        'if nothing is returned that record is not in the database so insert
                        CreateDatabase.ExecuteInsertQuery("INSERT INTO PatientRoom(Patient_TUID,Room_TUID,Bed_Name,Active_Flag) VALUES('" & intPatientID & "', '" & frmPatientInfo.cboRoom.Text & "', '" & frmPatientInfo.cboBed.Text & "','1')")
                        frmPatientInfo.cboRoom.Tag = frmPatientInfo.cboRoom.Text
                        frmPatientInfo.cboBed.Tag = frmPatientInfo.cboBed.Text
                        intCountChanged = intCountChanged + 1
                        strbItemsChanged.AppendLine("Room and Bed")
                    Else
                        'if it was in the database reactivate it
                        CreateDatabase.ExecuteInsertQuery("Update PatientRoom SET Active_Flag = '1' where Patient_TUID = '" & intPatientID & "' AND Room_TUID = '" & frmPatientInfo.cboRoom.Text & "' AND Bed_Name = '" & frmPatientInfo.cboBed.Text & "'")
                        frmPatientInfo.cboRoom.Tag = frmPatientInfo.cboRoom.Text
                        frmPatientInfo.cboBed.Tag = frmPatientInfo.cboBed.Text
                        intCountChanged = intCountChanged + 1
                        strbItemsChanged.AppendLine("Room and Bed")
                    End If

                End If
            End If
            If Not IsNothing(.cboPhysicians.SelectedItem) Then
                    If Not .cboPhysicians.SelectedItem.Equals(.cboPhysicians.Tag) Then
                        Dim strPhysicianName As String() = Split(.cboPhysicians.SelectedItem)
                    Dim dsPhysicians As DataSet
                    strPhysicianName(0) = strPhysicianName(0).TrimEnd(",")
                    strPhysicianName(1) = strPhysicianName(1).TrimEnd(",")
                    dsPhysicians = CreateDatabase.ExecuteSelectQuery("Select Physician_ID from  Physician where Physician_First_name = '" &
                                                                         strPhysicianName(1) & "' and Physician_Last_Name = '" &
                                                                         strPhysicianName(0) & "';")
                    strbSqlCommand.Append("UPDATE Patient SET Primary_Physician_ID = '" & dsPhysicians.Tables(0).Rows(0)(EnumList.Physician.Id) &
                                              "' Where Patient_ID = '" & intPatientID & "'")
                    ExecuteInsertQuery(strbSqlCommand.ToString)
                        intCountChanged += 1
                        strbItemsChanged.AppendLine("Primary Physician")
                        .cboPhysicians.Tag = .cboPhysicians.SelectedItem

                    End If
                Else
                    strbErrorMessage.AppendLine("You must select a physician to be in charge ")
                    strbErrorMessage.AppendLine("of the patient")
                    blnIssue = True
                End If

        End With

        If intCountChanged = 1 Then
            MessageBox.Show("Updated " & intCountChanged & " Item " & strbItemsChanged.ToString)
        Else
            MessageBox.Show("Updated " & intCountChanged & " Items: " & vbCrLf & strbItemsChanged.ToString)
        End If
        If blnIssue Then
            MessageBox.Show(strbErrorMessage.ToString)
        End If
        frmPatientInfo.LblPatientName.Text = Nothing
        Dim dsPatientName As DataSet = CreateDatabase.ExecuteSelectQuery("SELECT Patient_First_Name, Patient_Middle_Name, Patient_Last_Name from Patient where Patient_ID = '" & intPatientID & "'")
        patientRecordLabeling(dsPatientName.Tables(0).Rows(0)(0), dsPatientName.Tables(0).Rows(0)(1), dsPatientName.Tables(0).Rows(0)(2))
        frmPatientInfo.lblMoreDetails.Text = "Show More..."
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: patientRecordLabeling    	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		             */   
    '/*		         DATE CREATED: 4/1/2021                     		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This method tried to make the patient label. If the first, middle*/
    '/*  and last name together are above 27 characters it will cut out   */
    '/*  the middle name. If the first and last name are over 27 characters*/
    '/*  it will cut out the middle and last name. If the first name is over*/
    '/*  27 characters it will just remove everything past the 27 character.*/
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 fName - this is the Patient First Name                           */
    '/*  mName - this is the Patient middle name                          */
    '/*  lName - this is the patients last name.                                                                   
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	patientRecordLabeling(dsPatientName.Tables(0).Rows(0)(0),         */
    '/* dsPatientName.Tables(0).Rows(0)(1),                               */  
    '/* dsPatientName.Tables(0).Rows(0)(2))								  */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  strbPatientName - this is the string builder that will be used to*/
    '/*                 work with the string.                             */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Sub patientRecordLabeling(fName As String, mName As String, lName As String)
        Dim strbPatientName As StringBuilder = New StringBuilder
        'this is going to check how long the name is to make sure it doesn't
        'bleed into other controls. 
        strbPatientName.Append((fName & " " & mName & " " & lName))
        If strbPatientName.Length <= 27 Then
            frmPatientInfo.LblPatientName.Text = strbPatientName.ToString
        Else
            strbPatientName.Clear()
            strbPatientName.Append((fName & " " & lName))

            If strbPatientName.Length <= 27 Then
                frmPatientInfo.LblPatientName.Text = strbPatientName.ToString

            Else
                strbPatientName.Clear()
                strbPatientName.Append((fName))

                If strbPatientName.Length <= 27 Then
                    frmPatientInfo.LblPatientName.Text = strbPatientName.ToString
                Else
                    strbPatientName.Remove(27, strbPatientName.Length - 27)
                    frmPatientInfo.LblPatientName.Text = strbPatientName.ToString
                End If
            End If
        End If
    End Sub


    '/*********************************************************************/
    '/*                   FUNCTION NAME: GetAllergies                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:Adam kott                             */   
    '/*                 DATE CREATED:2/8/2021                                 */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:    receive a MRN number and push the              */             
    '/* allergy information into the allergies list                       */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:                                                           */           
    '/*                                                                   */         
    '/*********************************************************************/
    '/*  CALLS:                                                              */                 
    '/*             (ExecuteScalar),(ExectueSelectQuery)                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):                              */         
    '/*        intPatientInformationMRN                                      */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:                                                          */                   
    '/*            (NOTHING)                                              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:                                   */             
    '/*                                               */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*           dtsPatientAllergy:                                         */
    '/*        intPatientAllergyId:                                       */
    '/*        intPatientInformationMRN:                                  */


    '/*    */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:                                 */               
    '/*                                               */                     
    '/*  WHO   WHEN     WHAT                                   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  AK   2/8/2021 Created the SQL statements to pull back the       */
    '/*                 information needed for Patient allergies list     */
    '/* BRH   4/13/2021 Fixed SQL so the program wouldn't break.          */
    '/*********************************************************************/
    Public Sub GetAllergies(ByRef intPatient_ID As Integer)
        frmPatientInfo.lstBoxAllergies.Items.Clear()
        'default value for an mrn number so allergies are shown
        'intPatientInformationMRN = 949764144

        'get the patient id assiociated with the MRN Nummber
        Dim intPatientAllergyId As Integer = intPatient_ID ' CInt(CreateDatabase.ExecuteScalarQuery("select patient.Patient_ID From Patient " &
        '"where Patient.Patient_ID=" & (intPatient_ID).ToString & ";"))
        'get the allergy information from the patient allergy tables
        Dim dtsPatientAllergy As DataSet = CreateDatabase.ExecuteSelectQuery("Select Allergy_Name From Allergy INNER JOIN PatientAllergy ON Allergy_ID = Allergy_TUID " &
                            "Where Active_Flag =1 AND Patient_TUID =" & (intPatientAllergyId).ToString & ";")

        'push each row from the
        For Each item As DataRow In dtsPatientAllergy.Tables(0).Rows
            With dtsPatientAllergy.Tables(0)
                frmPatientInfo.lstBoxAllergies.Items.Add(item(0))
            End With
        Next
        'get select from patient allergy inner join on patient table where tuid is the same
        'join patients meds table and medications table
    End Sub
    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PopulatePatientDispenseInfo 	  */         
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
    Public Sub PopulatePatientDispenseInfo(ByRef intPatient_ID As Integer)

        'get patient information using sql generic method
        Dim dsPatientInfo As DataSet = CreateDatabase.ExecuteSelectQuery("SELECT * FROM Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        'set all patient information into dispense textboxes
        frmDispense.lblPatientInfo.Text = "Patient: "
        frmDispense.lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.LastName) & ", "
        frmDispense.lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.FristName) & "         "
        frmDispense.lblPatientInfo.Text &= "MRN: "
        frmDispense.lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.MRN_Number) & "         "
        frmDispense.lblPatientInfo.Text &= "DOB: "
        frmDispense.lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.DoB) & "         "
        frmDispense.lblPatientInfo.Text &= "Height: "
        frmDispense.lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.Height) & "         "
        frmDispense.lblPatientInfo.Text &= "Weight: "
        frmDispense.lblPatientInfo.Text &= dsPatientInfo.Tables(0).Rows(0)(EnumList.Patient.Weight) & "         "


        Dim Strdatacommand As String = "Select trim(Medication.Drug_Name,' '), Medication.Strength, Medication.Type, Dispensing.Amount_Dispensed,Dispensing.DateTime_Dispensed, User.User_Last_Name, User.User_First_Name from Dispensing 
                                        Inner Join PatientMedication ON PatientMedication.PatientMedication_ID = Dispensing.PatientMedication_TUID
                                        INNER JOIN Medication ON Medication.Medication_ID = PatientMedication.Medication_TUID
                                        INNER JOIN User ON User.User_ID = Dispensing.Primary_User_TUID
                                        where PatientMedication.Patient_TUID = '" & intPatient_ID & "'
                                        UNION
                                        Select trim(Medication.Drug_Name,' '), Medication.Strength, Medication.Type, AdHocOrder.Amount, AdHocOrder.DateTime, User_Last_Name,User_First_Name  from AdHocOrder
                                        Inner Join Medication on Medication.Medication_ID = AdHocOrder.Medication_TUID
                                        INNER JOIN User ON user.User_ID = AdHocOrder.User_TUID
                                        where AdHocOrder.Patient_TUID = '" & intPatient_ID & "'
                                        Order by Dispensing.DateTime_Dispensed DESC"

        Dim dsmydataset As DataSet = CreateDatabase.ExecuteSelectQuery(Strdatacommand)

        For Each dr As DataRow In dsmydataset.Tables(0).Rows
            frmPatientInfo.CreateDispenseHistoryPanels(frmDispense.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(5) & " " & dr(6), dr(4), "")
        Next
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME: PopulatePatientAllergiesDispenseInfo   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:Adam kott                             */   
    '/*                 DATE CREATED:2/10/2021                           */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:
    '/*********************************************************************/
    '/*  CALLED BY:                                                      */                    
    '/*********************************************************************/
    '/*  CALLS:                                                         */                            
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):                              */         
    '/*********************************************************************/
    '/*  RETURNS:                                                          */                   
    '/*            (NOTHING)                                              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:                                   */             
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:                                 */               
    '/*                                               */                     
    '/*  WHO   WHEN     WHAT                                   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  ATB   2/10/2021 initial code creation
    '/*********************************************************************/
    Public Sub PopulatePatientAllergiesDispenseInfo(ByRef intPatient_ID As Integer)
        Dim dsPatientInfo As DataSet = CreateDatabase.ExecuteSelectQuery("SELECT Allergy_Name From PatientAllergy " &
                                                                         "INNER JOIN Allergy on Allergy.Allergy_ID = PatientAllergy.Allergy_TUID " &
                                                                         "INNER JOIN Patient on Patient.Patient_ID = PatientAllergy.Patient_TUID " &
                                                                         "WHERE Patient_ID = '" & intPatient_ID & "' AND PatientAllergy.Active_Flag = '1' ")
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmDispense.lstboxAllergies.Items.Add(dr(0))
        Next
    End Sub
    '/*********************************************************************/
    '/*                   FUNCTION NAME: getPrescriptions                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:Adam kott                             */   
    '/*                 DATE CREATED:2/10/2021                           */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:
    '/*********************************************************************/
    '/*  CALLED BY:                                                      */                    
    '/*********************************************************************/
    '/*  CALLS:                                                         */                            
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):                              */         
    '/*********************************************************************/
    '/*  RETURNS:                                                          */                   
    '/*            (NOTHING)                                              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:                                   */             
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:                                 */               
    '/*                                               */                     
    '/*  WHO   WHEN     WHAT                                   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  ATB   2/10/2021 initial code creation
    '/*********************************************************************/
    Public Sub getPrescriptions(ByRef intPatient_ID As Integer)
        Dim strSQLiteCommand As String
        Dim dsPatientPrescription As DataSet
        strSQLiteCommand = "SELECT DISTINCT trim(Drug_Name,' '), Medication.Strength, PatientMedication.Frequency, PatientMedication.Type, PatientMedication.Quantity, PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.Units, PatientMedication.PatientMedication_ID FROM PatientMedication " &
            "INNER JOIN Medication on Medication.Medication_ID = PatientMedication.Medication_TUID " &
            "INNER JOIN Patient ON Patient.Patient_ID = PatientMedication.Patient_TUID " &
            "INNER JOIN Physician on Physician.Physician_ID = PatientMedication.Ordering_Physician_ID " &
            "INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = PatientMedication.Medication_TUID " &
            "WHERE Patient.Patient_ID = '" & intPatient_ID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY trim(Drug_Name,' ') COLLATE NOCASE ASC"

        dsPatientPrescription = CreateDatabase.ExecuteSelectQuery(strSQLiteCommand)
        For Each dr As DataRow In dsPatientPrescription.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(9), dr(5), "Dr. " & dr(6) & " " & dr(7), dr(8), dr(10))
        Next
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: getRoom   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 2/16/2021                    		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This is going to populate the room combo box as well as select the*/
    '/*  select the room the patient is in. It is also going to populate   */
    '/*  the room combo box using the populateRoomComboboxMethod           */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */               
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/* strbSQL -- sql builder
    '/* dsPatient -- 
    '/* dsPatientRoom -- 
    '/* intPatient_TUID -- patient database id
    '/* strbed -- holds room 
    '/* strroom -- holds bed
    '/* 
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- *
    '/*   AB    2/28/2021   Initial creation                                                                                                                      
    '/*********************************************************************/


    Public Sub getRoom(intPatient_ID As Integer, cboRoom As ComboBox, cboBed As ComboBox)

        Dim strbSQL As StringBuilder = New StringBuilder
        Dim dsPatient As DataSet
        Dim dsPatientRoom As DataSet
        Dim intPatient_TUID As Integer
        Dim strbed As String = ""
        Dim strroom As String = ""

        dsPatient = CreateDatabase.ExecuteSelectQuery("Select * from Patient where Patient_ID = '" & intPatient_ID & "';")
        strbSQL.Append("Select Room_ID,Bed_Name from Rooms WHERE Active_Flag = '1' EXCEPT Select Room_TUID,Bed_Name from PatientRoom where PatientRoom.Active_Flag = '1'")
        Dim dsOpenrooms As DataSet = CreateDatabase.ExecuteSelectQuery(strbSQL.ToString)
        PopulateRoomsCombBoxesMethods.PopulateRoomComboBox(cboRoom, dsOpenrooms)
        'calling that function will populate the room combobox for us. 

        strbSQL.Clear()


        For Each row As DataRow In dsPatient.Tables(0).Rows
            intPatient_TUID = row(0)
        Next

        dsPatientRoom = CreateDatabase.ExecuteSelectQuery("Select * from PatientRoom where Patient_TUID ='" & intPatient_TUID & "' AND Active_Flag = '1';")
        For Each row As DataRow In dsPatientRoom.Tables(0).Rows
            strbed = row(2)
            strroom = row(1)
        Next
        Dim strcheckroom As String = dsPatientRoom.Tables(0).Rows(0)(1)
        If checkComboForDup(frmPatientInfo.cboRoom, strcheckroom) = True Then
            cboRoom.Items.Add(strroom)
        End If
        If cboRoom.FindString(strroom.ToString) <= -1 Then
            cboRoom.Items.Add(strroom)
        End If

        'PopulateRoomsCombBoxesMethods.UpdateBedComboBox(cboBed, cboRoom)
        cboRoom.Tag = strroom
        cboBed.Tag = strbed
        cboRoom.SelectedItem = strroom
        cboBed.SelectedItem = strbed
    End Sub

    Private Sub populatebedsforpatient()
        Dim strRoom As String = frmPatientInfo.cboRoom.SelectedItem
        Dim strRoomTag As String = frmPatientInfo.cboRoom.Tag

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: DisplayPatientPrescriptionsDispense    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED: 2/28/2021                    		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder                                                                   
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    2/28/2021   Initial creation                                                                  
    '/*********************************************************************/
    Public Sub DisplayPatientPrescriptionsDispense(ByRef intPatient_ID As Integer)
        'Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        'Dim dsPatientInfo As DataSet
        'Dim strbSqlCommand As StringBuilder = New StringBuilder

        ''set up sql command inner joining the medication, patientMedicaiton and physician table
        '' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        '' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        '' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        'strbSqlCommand.Append("SELECT trim(Drug_Name,' '), Strength, Frequency, Medication.Type, PatientMedication.Quantity, ")
        'strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name ")
        'strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        'strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        'strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1'")
        'dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        ''look create panel method for each prescription the patient has
        'For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
        '    'frmDispense.CreatePrescriptionsPanels(frmDispense.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), "Dr. " & dr(6) & " " & dr(7))
        'Next

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PatinetInfoSortedByFrequency    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED: 3/12/2021                    		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form sorted by the frequency in dispense time
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    3/12/2021    Initial creation                                     
    '/*********************************************************************/
    Public Sub PatinetInfoSortedByFrequency(ByRef intPatient_ID As Integer)
        Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        Dim dsPatientInfo As DataSet
        Dim strbSqlCommand As StringBuilder = New StringBuilder

        'set up sql command inner joining the medication, patientMedicaiton and physician table
        ' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        ' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        ' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        strbSqlCommand.Append("SELECT DISTINCT trim(Drug_Name,' '), Strength, Frequency, PatientMedication.Type, PatientMedication.Quantity, PatientMedication.Units, ")
        strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.PatientMedication_ID ")
        strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        strbSqlCommand.Append("INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY CAST(PatientMedication.Frequency as INTEGER)")
        dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        'look create panel method for each prescription the patient has
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "Dr. " & dr(7) & " " & dr(8), dr(9), dr(10))
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PatinetInfoSortedByDoctor    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED:  3/12/2021                       		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form sorted by the doctors last name and first name
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder                                                                   
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    3/12/2021    Initial creation                                     
    '/*********************************************************************/
    Public Sub PatinetInfoSortedByDoctor(ByRef intPatient_ID As Integer)
        Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        Dim dsPatientInfo As DataSet
        Dim strbSqlCommand As StringBuilder = New StringBuilder

        'set up sql command inner joining the medication, patientMedicaiton and physician table
        ' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        ' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        ' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        strbSqlCommand.Append("SELECT DISTINCT trim(Drug_Name,' '), Strength, Frequency, PatientMedication.Type, PatientMedication.Quantity, PatientMedication.Units, ")
        strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.PatientMedication_ID ")
        strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        strbSqlCommand.Append("INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1'  ORDER BY Physician_Last_Name, Physician_First_Name")
        dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        'look create panel method for each prescription the patient has
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "Dr. " & dr(7) & " " & dr(8), dr(9), dr(10))
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PatinetInfoSortedByDate    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED:  3/12/2021                          		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form  sorted by the prescription date
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder                                                                  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    3/12/2021    Initial creation                                     
    '/*********************************************************************/
    Public Sub PatinetInfoSortedByDate(ByRef intPatient_ID As Integer)
        Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        Dim dsPatientInfo As DataSet
        Dim strbSqlCommand As StringBuilder = New StringBuilder

        'set up sql command inner joining the medication, patientMedicaiton and physician table
        ' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        ' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        ' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        strbSqlCommand.Append("SELECT DISTINCT trim(Drug_Name,' '), Strength, Frequency, PatientMedication.Type, PatientMedication.Quantity, PatientMedication.Units, ")
        strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.PatientMedication_ID ")
        strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        strbSqlCommand.Append("INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1'  ORDER BY Date_Presrcibed")
        dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        'look create panel method for each prescription the patient has
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "Dr. " & dr(7) & " " & dr(8), dr(9), dr(10))
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PatinetInfoSortedByQuantity    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED:  3/12/2021                          		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form  sorted by the prescription quantity
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder                                                                  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    3/12/2021    Initial creation                                     
    '/*********************************************************************/
    Public Sub PatinetInfoSortedByQuantity(ByRef intPatient_ID As Integer)
        Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        Dim dsPatientInfo As DataSet
        Dim strbSqlCommand As StringBuilder = New StringBuilder

        'set up sql command inner joining the medication, patientMedicaiton and physician table
        ' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        ' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        ' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        strbSqlCommand.Append("SELECT DISTINCT trim(Drug_Name,' '), Strength, Frequency, PatientMedication.Type, PatientMedication.Quantity, PatientMedication.Units, ")
        strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.PatientMedication_ID ")
        strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        strbSqlCommand.Append("INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1'  ORDER BY PatientMedication.Quantity")
        dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        'look create panel method for each prescription the patient has
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "Dr. " & dr(7) & " " & dr(8), dr(9), dr(10))
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PatinetInfoSortedByType    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED: 3/12/2021              		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form sorted by the type of the medication
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder                                                                  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    3/12/2021    Initial creation                                     
    '/*********************************************************************/
    Public Sub PatinetInfoSortedByType(ByRef intPatient_ID As Integer)
        Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        Dim dsPatientInfo As DataSet
        Dim strbSqlCommand As StringBuilder = New StringBuilder

        'set up sql command inner joining the medication, patientMedicaiton and physician table
        ' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        ' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        ' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        strbSqlCommand.Append("SELECT DISTINCT trim(Drug_Name,' '), Strength, Frequency, PatientMedication.Type, PatientMedication.Quantity,  PatientMedication.Units,")
        strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.PatientMedication_ID ")
        strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        strbSqlCommand.Append("INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1'  ORDER BY trim(PatientMedication.Type,' ') COLLATE NOCASE")
        dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        'look create panel method for each prescription the patient has
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "Dr. " & dr(7) & " " & dr(8), dr(9), dr(10))
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PatinetInfoSortedByStrength    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED:  3/12/2021                    		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form sorted by the strength of the medication
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder                                                             
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    3/12/2021    Initial creation                                                                      
    '/*********************************************************************/
    Public Sub PatinetInfoSortedByStrength(ByRef intPatient_ID As Integer)
        Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        Dim dsPatientInfo As DataSet
        Dim strbSqlCommand As StringBuilder = New StringBuilder

        'set up sql command inner joining the medication, patientMedicaiton and physician table
        ' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        ' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        ' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        strbSqlCommand.Append("SELECT DISTINCT trim(Drug_Name,' '), Strength, Frequency, PatientMedication.Type, PatientMedication.Quantity,  PatientMedication.Units,")
        strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.PatientMedication_ID ")
        strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        strbSqlCommand.Append("INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1'  ORDER BY CAST(Strength as INTEGER)")
        dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        'look create panel method for each prescription the patient has
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "Dr. " & dr(7) & " " & dr(8), dr(9), dr(10))
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: PatinetInfoSortedByDrugName    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		       */   
    '/*		         DATE CREATED:  3/12/2021                       		   */                             
    '/*********************************************************************/
    '/*  SUBPROHRAM PURPOSE:								               */             
    '/*	 This sub will populate the patient prescription panels on the 
    '/*  patient dispense form sorted by the medication names
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 intPatient_ID - this is the patient ID we are going to*/                     
    '/*                  be using for the SQL statements.                  */
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
    '/*
    '/*		intPatientID --	Integer --	stores patient ID 							                      
    '/*     dsPatientInfo -- As DataSet -- dataset that holds patient information
    '/*     strbSqlCommand -- StringBuilder -- sql string builder
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*   AB    3/12/2021    Initial creation                                                                  
    '/*********************************************************************/
    Public Sub PatinetInfoSortedByDrugName(ByRef intPatient_ID As Integer)
        Dim intPatientID As Integer = intPatient_ID ' CreateDatabase.ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE Patient_ID = '" & intPatient_ID & "'")
        Dim dsPatientInfo As DataSet
        Dim strbSqlCommand As StringBuilder = New StringBuilder

        'set up sql command inner joining the medication, patientMedicaiton and physician table
        ' this is done to get the drug name, strength, type and frequency of the medication the specific patient
        ' is prescribed, it then joins the patient medicaiton table to get the quantity, date prescribed and 
        ' the physician ID who prescribed it, inner joining the physician table with the ID to get the name of the physician
        strbSqlCommand.Append("SELECT DISTINCT trim(Drug_Name,' '), Strength, Frequency, PatientMedication.Type, PatientMedication.Quantity,  PatientMedication.Units,")
        strbSqlCommand.Append("PatientMedication.Date_Presrcibed, Physician.Physician_First_Name, Physician.Physician_Last_Name, Medication.Medication_ID, PatientMedication.PatientMedication_ID ")
        strbSqlCommand.Append("FROM Medication Inner Join PatientMedication ON PatientMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("Inner Join Physician ON Physician.Physician_ID = PatientMedication.Ordering_Physician_ID ")
        strbSqlCommand.Append("INNER JOIN DrawerMedication on DrawerMedication.Medication_TUID = Medication.Medication_ID ")
        strbSqlCommand.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' AND PatientMedication.Active_Flag = '1' AND DrawerMedication.Active_Flag = '1'  ORDER BY trim(Drug_Name,' ') COLLATE NOCASE ASC")
        dsPatientInfo = CreateDatabase.ExecuteSelectQuery(strbSqlCommand.ToString)
        'look create panel method for each prescription the patient has
        For Each dr As DataRow In dsPatientInfo.Tables(0).Rows
            frmPatientInfo.CreatePrescriptionsPanels(frmPatientInfo.flpMedications, dr(0), dr(1), dr(2), dr(3), dr(4) & " " & dr(5), dr(6), "Dr. " & dr(7) & " " & dr(8), dr(9), dr(10))
        Next
    End Sub


End Module