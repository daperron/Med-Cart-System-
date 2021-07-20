Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions
Public Class frmNewPatient
    '/*********************************************************************/
    '/*                   FILE NAME:  */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT:				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		         */		  
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
    '/*  NP    2/6/2021 Started to connect the GUI to the database. 
    '/*  NP    2/20/2021 Added datavaildation for the texboxs on the form.*/
    '/*  NP    2/21/2021 added the error checking call to the save button.*/
    '/*********************************************************************/


    Dim dsrooms As DataSet
    Dim dsPhysicians As DataSet
    Dim strAllowedNameCharacters = "abcdefghijklmnopqrstuvwxyz '-1234567890!@#$%^&*()/.,<>=+"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not hasError() Then
            Dim strPatientName = txtFirstName.Text & " " & txtLastName.Text
            SavePatientDataToDatabase()
            clearInformationBoxes()
            MessageBox.Show("New patient " & strPatientName & " has been added to the system")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        frmMain.OpenChildForm(frmPatientRecords)
    End Sub

    Private Sub clearInformationBoxes()
        txtFirstName.Text = Nothing
        txtMiddleName.Text = Nothing
        txtAddress.Text = Nothing
        txtCity.Text = Nothing
        txtHeight.Text = Nothing
        txtEmail.Text = Nothing
        txtLastName.Text = Nothing
        txtWeight.Text = Nothing
        mtbZipCode.Text = Nothing
        mtbDoB.Text = Nothing
        mtbPhone.Text = Nothing
        cmbSex.SelectedIndex = -1
        cboRoom.SelectedIndex = -1
        cmbPhysician.SelectedIndex = -1
        cmbState.SelectedIndex = -1
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  SavePatientDataToDatabase	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		           */   
    '/*		         DATE CREATED: 	2/6/2021                        	   */                             
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
    '/*	strAddress - this is going to hold the result of txtAddress.text  */
    '/*              after all the ' have been escaped.                   */
    '/* strbSQL - this is the string builder that is used to construct the*/
    '/*           the SQL command.                                        */
    '/* strCharactersForRandomGeneration - this is the string that is used*/
    '/*          to randomly generate a string.                           */
    '/* strCity - this is going ot hold the result of txtCity.text after  */
    '/*           the ' have been escaped.                                *.
    '/* strEmail - this is going to hold the result of txtemail.text after*/
    '/*            the ' are escaped.                                     */
    '/* strFirstName - This is going to hold the result of txtFirstName.text*/
    '/*                after all the ' are escaped.                       */
    '/* strLastName - this is going to hold the result of txtLastName.text*/
    '/*               after all the ' have been escaped.                  */
    '/* strMiddleName - this is going to hold the result of txtMiddleName.text*/
    '/*                 after the ' have been escaped.                    */
    '/* strPhysicianName - this used to remove teh trailing , in the selection*/
    '/*                    of the combo box.                              */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/18/2021 Swapped the numbers of strPhysiciansName() because*/
    '/*                 They were inverted and were breaking the app. I also*/
    '/*                 made it so the comma is trimed off the last name of */
    '/*                 the physician.                                      */
    '/* NP     2/22/2021 added the ability to have ' in the name and email. */   
    '/*********************************************************************/


    Private Sub SavePatientDataToDatabase()
        Dim strbSQL As New StringBuilder()
        Dim strPhysicianName As String() = Split(cmbPhysician.SelectedItem, ",")
        strPhysicianName(0) = strPhysicianName(0).Trim
        strPhysicianName(1) = strPhysicianName(1).Trim
        Dim strCharactersForRandomGeneration = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        'the following is just to escape the ' so that it won't break the SQL
        Dim strFirstName = Regex.Replace(txtFirstName.Text, "'", "''")
        Dim strMiddleName = Regex.Replace(txtMiddleName.Text, "'", "''")
        Dim strLastName = Regex.Replace(txtLastName.Text, "'", "''")
        Dim strEmail = Regex.Replace(txtEmail.Text, "'", "''")
        Dim strAddress = Regex.Replace(txtAddress.Text, "'", "''")
        Dim strCity = Regex.Replace(txtCity.Text, "'", "''")

        strPhysicianName(0) = strPhysicianName(0).TrimEnd(",")
        dsPhysicians = CreateDatabase.ExecuteSelectQuery("Select Physician_ID from  Physician where Physician_First_name = '" &
                                                         strPhysicianName(1) & "' and Physician_Last_Name = '" &
                                                         strPhysicianName(0) & "';")



        'grab data from all textfields and send it to the database

        strbSQL.Append("INSERT INTO Patient ('MRN_Number', 'Barcode', 'Patient_First_Name'," &
            "'Patient_Middle_Name', 'Patient_Last_Name', 'Date_of_Birth', 'Sex', 'Height', 'Weight', " &
            "'Address', 'City', 'State', 'Zip_Code', 'Phone_Number', 'Email_address', 'Primary_Physician_ID', " &
            "'Active_Flag') Values ('")
        Dim blnUsedMRN As Boolean = False
        Dim dsCheckforRecord As DataSet
        'strbSQL.Append(CInt(Rnd() * 20) & "','")
        'strbSQL.Append(CInt(Rnd() * 20) & "',") 'this is going to make a random barcode this is temporary


        Dim strMRN As String = GenerateRandom.generateRandomAlphanumeric(8, "1234567890")
        Dim strBarcode As String = GenerateRandom.generateRandomAlphanumeric(20, strCharactersForRandomGeneration)
        '^this Is going to generate a random MRN number
        'check duplicate MRN
        While blnUsedMRN = False
            dsCheckforRecord = CreateDatabase.ExecuteSelectQuery("Select * from Patient WHERE MRN_Number = '" & strMRN & "'")
            If dsCheckforRecord.Tables.Count > 0 Then
                blnUsedMRN = True
            End If
            strMRN = GenerateRandom.generateRandomAlphanumeric(8, "1234567890")
        End While
        'check for duplicate barcode
        blnUsedMRN = False

        While blnUsedMRN = False
            dsCheckforRecord = CreateDatabase.ExecuteSelectQuery("Select * from Patient WHERE Barcode = '" & strBarcode & "'")
            If dsCheckforRecord.Tables.Count > 0 Then
                blnUsedMRN = True
            End If
            strBarcode = GenerateRandom.generateRandomAlphanumeric(20, strCharactersForRandomGeneration)
        End While

        strbSQL.Append(strMRN & "', '")
        strbSQL.Append(strBarcode & "',")
        '^this is going to genereate a random Bar code. 
        strbSQL.Append("'" & strFirstName & "' , '" & strMiddleName & "',")
        strbSQL.Append("'" & strLastName & "','" & mtbDoB.Text & "',")
        strbSQL.Append("'" & cmbSex.SelectedItem & "','" & txtHeight.Text & "',")
        strbSQL.Append("'" & txtWeight.Text & "','" & strAddress & "',")
        strbSQL.Append("'" & strCity & "','" & cmbState.SelectedItem & "',")
        strbSQL.Append("'" & mtbZipCode.Text & "','" & mtbPhone.Text & "',")
        strbSQL.Append("'" & strEmail & "','" & dsPhysicians.Tables(0).Rows(0)(EnumList.Physician.Id) & "',")
        strbSQL.Append("'" & 1 & "');")

        CreateDatabase.ExecuteInsertQuery(strbSQL.ToString)
        Dim intPatientID As Integer = CreateDatabase.ExecuteScalarQuery("Select Patient_ID from Patient WHERE MRN_Number = '" & strMRN & "'")
        CreateDatabase.ExecuteInsertQuery("INSERT INTO PatientRoom(Patient_TUID,Room_TUID,Bed_Name,Active_Flag) VALUES('" & intPatientID & "', '" & cboRoom.SelectedItem & "', '" & cboBed.SelectedItem & "','1')")
        'send message saying it was a success or error

        'if error say what the error was and return to the form with the filled out info

        ' Else

        ' success message that the data was saved to the database successfully
    End Sub

    '/*********************************************************************/
    '/*                   SUBPRORAM NAME:  frmNewPatient_Load		       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		            */   
    '/*		         DATE CREATED: 	2/6/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGAM PURPOSE:								   */             
    '/*	 This is going to run before the form is shown. It is going to    */                     
    '/*  populate the combo boxes.                                        */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*  sender – Identifies which particular control raised the          */
    '/*          click event                                              */
    '/*  e – Holds the EventArgs object sent to the routine               */        
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

    Private Sub frmNewPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dsrooms = CreateDatabase.ExecuteSelectQuery("Select Room_ID,Bed_Name from Rooms WHERE Active_Flag = '1' EXCEPT Select Room_TUID,Bed_Name from PatientRoom where PatientRoom.Active_Flag = '1'")
        dsPhysicians = CreateDatabase.ExecuteSelectQuery("Select * from Physician where Active_flag = '" & 1 & "' ORDER BY Physician_Last_Name, Physician_First_Name ;")
        cmbSex.Items.AddRange({"Male", "Female"})
        PopulateStateComboBox(cmbState)
        PopulateRoomComboBox(cboRoom, dsrooms)
        populatePhysicianComboBox(cmbPhysician, dsPhysicians)
        btnBack.Visible = False

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  cmbRoom_SelectedIndexChanged  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/20/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								             */             
    '/*	 This Repopulated the bed combo box based on what was selected for */
    '/*   the room. It does this by calling the updateBedComboBox method.  */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*  sender – Identifies which particular control raised the          */
    '/*          click event                                              */
    '/*  e – Holds the EventArgs object sent to the routine               */ 
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


    Private Sub cmbRoom_SelectedIndexChanged(sender As Object, e As EventArgs)

        'PopulateRoomsCombBoxesMethods.UpdateBedComboBox(cmbBed, cmbRoom)
        'cmbBed.Enabled = True
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtZipCode_KeyPress  		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 2/20/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								               */             
    '/*	 This is going to check all the key pressed to make sure that they */                     
    '/*  are numeric. All it does is call the keypressCheck method to do this*/
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*  sender – Identifies which particular control raised the          */
    '/*          click event                                              */
    '/*  e – Holds the EventArgs object sent to the routine               */      
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

    Private Sub txtZipCode_KeyPress(sender As Object, e As KeyPressEventArgs)
        DataVaildationMethods.KeyPressCheck(e, "0123456789")
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: cmbSex_KeyPress  			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:							            	   */             
    '/*	 This is checking what the user is typing in to auto fill the combo*/                     
    '/*  box selection.                                                    */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*  sender – Identifies which particular control raised the          */
    '/*          click event                                              */
    '/*  e – Holds the EventArgs object sent to the routine               */  
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

    Private Sub cmbSex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSex.KeyPress
        If String.Equals(e.KeyChar, "m", StringComparison.InvariantCultureIgnoreCase) Then
            e.Handled = True
            cmbSex.Text = String.Empty
            cmbSex.SelectedItem = "Male"
        ElseIf String.Equals(e.KeyChar, "f", StringComparison.InvariantCultureIgnoreCase) Then
            e.Handled = True
            cmbSex.Text = String.Empty
            cmbSex.SelectedItem = "Female"
        Else
            e.Handled = True
            cmbSex.Text = String.Empty
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtHeight_KeyPress   		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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

    Private Sub txtHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHeight.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.")
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  txtWeight_KeyPress  		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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

    Private Sub txtWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWeight.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.")
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtFirstName_KeyPress		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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

    Private Sub txtFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirstName.KeyPress
        DataVaildationMethods.KeyPressCheck(e, strAllowedNameCharacters)
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtMiddleName_KeyPress		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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

    Private Sub txtMiddleName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMiddleName.KeyPress
        DataVaildationMethods.KeyPressCheck(e, strAllowedNameCharacters)
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtLastName_KeyPress 		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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

    Private Sub txtLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastName.KeyPress
        DataVaildationMethods.KeyPressCheck(e, strAllowedNameCharacters)
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtAddress_KeyPress 	           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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
    Private Sub txtAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddress.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz 0123456789.'-#@%&/")
    End Sub



    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: cmbState_KeyPress 	           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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


    Private Sub cmbState_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbState.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz")
    End Sub
    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: txtCity_KeyPress 	           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								              */             
    '/*	 This is going to check the keys that are pressed. All it does it */
    '/*  is call the keypresscheck fucntion.                              */
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

    Private Sub txtCity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCity.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz -")
    End Sub

    Private Sub mtbDOB_KeyPress(sender As Object, e As KeyPressEventArgs) 
        DataVaildationMethods.KeyPressCheck(e, "0123456789")
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  hasError  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/21/2021	                           */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to check the input boxes on the form to make sure that*/                     
    '/*  there is information in the boxes. Most of the textboxes lock the */
    '/*  characters that are allowed in them so we just need to check to see*/
    '/*  if there are values in the boxes.                                 */
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
    '/*	 email - this is a test value to see if the email is valid.       */	
    '/*  strbErrorMessage- This is the string builder that will be used to*/
    '/*                    display the build error message based on what is*/
    '/*                    missing on the form.                           */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Function hasError() As Boolean
        Dim strbErrorMessage As New StringBuilder
        Dim email As MailAddress
        hasError = False
        If txtFirstName.Text = String.Empty Or txtFirstName.Text.Length <= 1 Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid first name." & vbCrLf)
        End If
        If txtMiddleName.Text = String.Empty Or txtMiddleName.Text.Length <= 1 Then
            If MsgBox("The middle name entered is very short or blank, is this intentional?", vbYesNo) Then
                'to not break the application elsewhere, set the middle name to space.
                txtMiddleName.Text = " "
            Else
                hasError = True
                strbErrorMessage.Append("Please enter a valid middle name." & vbCrLf)
            End If
        End If
            If txtLastName.Text = String.Empty Or txtLastName.Text.Length <= 1 Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid last name." & vbCrLf)
        End If
        Try
            email = New MailAddress(txtEmail.Text) 'this allows .net to check
            'to see if the email is vaild. 

        Catch ex As Exception
            hasError = True
            strbErrorMessage.Append("Please enter a valid email address." & vbCrLf)
        End Try
        If cmbSex.SelectedIndex = -1 Then
            hasError = True
            strbErrorMessage.Append("Please select male or female for the patient sex." & vbCrLf)
        End If
        If Not IsDate(mtbDoB.Text) Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid date of birth." & vbCrLf)
        End If

        If IsDate(mtbDoB.Text) Then
            Dim intyear As Integer = Date.Today.Year
            Dim dtmDOByear As Date = CDate(mtbDoB.Text)
            Dim intDOByear As Integer = dtmDOByear.Year
            If dtmDOByear > Date.Today Then
                hasError = True
                strbErrorMessage.Append("DOB is in the future. Please enter a valid date of birth." & vbCrLf)
            End If
            If (intyear - intDOByear) > 125 Then
                hasError = True
                strbErrorMessage.Append("Patient cannot be more than 125 years old. Please enter a valid date of birth." & vbCrLf)
            End If
        End If
        If IsNumeric(txtHeight.Text) Then
            If CDbl(txtHeight.Text) > 250 Then
                hasError = True
                strbErrorMessage.Append("Please enter a valid height 0.1 - 440 kg." & vbCrLf)
            End If
        End If

        If IsNumeric(txtWeight.Text) Then
            If CDbl(txtWeight.Text) > 440 Then
                hasError = True
                strbErrorMessage.Append("Please enter a valid weight 0.1 - 440 kg" & vbCrLf)
            End If
        End If

        If txtHeight.Text = String.Empty Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid height 1-250 cm." & vbCrLf)
        End If
        If txtWeight.Text = String.Empty Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid weight. 0.1 - 440 kg." & vbCrLf)
        End If
        If cboRoom.SelectedIndex = -1 Then
            hasError = True
            strbErrorMessage.Append("Please enter a room for the patient." & vbCrLf)
        End If
        If txtAddress.Text = String.Empty Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid street address." & vbCrLf)
        End If
        If txtCity.Text = String.Empty Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid city name." & vbCrLf)
        End If
        If cmbState.SelectedIndex = -1 Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid state." & vbCrLf)
        End If
        If Not mtbZipCode.MaskCompleted Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid zip code" & vbCrLf)
        End If
        If Not mtbPhone.MaskCompleted Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid phone number." & vbCrLf)
        End If
        If cmbPhysician.SelectedIndex = -1 Then
            hasError = True
            strbErrorMessage.Append("Please enter a valid physician name." & vbCrLf)
        End If
        If cboBed.SelectedIndex = -1 Then
            hasError = True
            strbErrorMessage.Append("Please select a bed for the patient" & vbCrLf)
        End If
        If hasError Then
            MessageBox.Show(strbErrorMessage.ToString)
        End If
        Return hasError
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click


        frmMain.OpenChildForm(frmPatientRecords)

    End Sub

    Private Sub cboRoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRoom.SelectedIndexChanged
        cboBed.Items.Clear()
        If Not cboRoom.SelectedIndex = -1 Then
            Dim strSelectedRoom As String = cboRoom.SelectedItem
            Dim dsBeds As DataSet = CreateDatabase.ExecuteSelectQuery("Select Room_ID,Bed_Name from Rooms WHERE Active_Flag = '1' AND Room_ID = '" & strSelectedRoom & "' EXCEPT Select Room_TUID,Bed_Name from PatientRoom where PatientRoom.Active_Flag = '1'")
            For Each dr As DataRow In dsBeds.Tables(0).Rows
                cboBed.Items.Add(dr(1))
            Next
        End If
    End Sub

End Class