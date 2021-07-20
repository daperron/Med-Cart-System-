Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmConfiguration
    Dim strSort As String
    Public Enum DispenseHistoryEnum As Integer
        Name = 1
        Username = 2
        Permission = 3
        Active = 4
    End Enum
    Public Enum AddAndRemoveUserEnum

        name = 1
        username = 2
        permissions = 3
        active = 4

    End Enum

    '/*********************************************************************/
    '/*                   SubProgram NAME: frmConfiguration_Load          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 2/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This  sub program is used to populate the flpUserInfo Flow       */
    '/* Layout Panel from the User Table and set the default radio button */ 
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	CreateDatabase.ExecuteSelectQuery                         */ 
    '/*         Create Panel                                              */                 
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	  Launched on load                                               */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */   
    '/*strFirst- User first name pulled from User Table                     */
    '/*strLast- User last name pulled from User Table                     */
    '/*strName- Combined first and last name                              */
    '/*strRole- Permission level given by flags in the User Table          */
    '/*dsUserInfo- data table to store data brought in from database      */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  Dylan W    2/10/2021    Initial creation and pull data from DB   */
    '/*********************************************************************/
    Private Sub frmConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName.Font = New Font(New FontFamily("Segoe UI Semibold"), 12, FontStyle.Underline)
        Dim strFillSQL As String = "select User.User_ID, User.Username, User.User_First_Name, User.User_Last_Name, User.Admin_Flag, " &
                                                  "User.Supervisor_Flag, User.Active_Flag From User ORDER BY User_First_Name COLLATE NOCASE ASC;"
        Fill_Table(strFillSQL)

        'have new users assigned as Nurses by default
        rbtnNurse.Checked = True
        btnSaveChanges.Visible = False
        btnCancel.Visible = False

        CreateToolTips(pnlHeader, tpLabelHover)
        AddHandlerToLabelClick(pnlHeader, AddressOf SortBySelectedLabel)

        strSort = "User_First_Name COLLATE NOCASE ASC;"
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
    '/*	field- an integer equal to the tag value of the selected label
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SortBySelectedLabel(sender As Object, e As EventArgs)

        Dim parent As Panel = sender.parent
        Dim field As Integer = CInt(sender.tag)

        BoldLabelToSortBy(sender, parent)

        'check If the user Is selecting a dispense history field to sort by
        If parent.Name = pnlHeader.Name Then

            ConfigurationSelectedFields(field)

        End If


    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: ConfigurationSelectedFields   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		  */   
    '/*		         DATE CREATED: 		 2/14/2021                 */                             
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
    '/*	 ConfigurationSelectedFields(Cint(Label1.Tag))   	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub ConfigurationSelectedFields(ByVal field As Integer)

        ' clear the controls as they will need to be rebuilt when sorting
        'flpPatientRecords.Controls.Clear()

        Select Case field

            Case AddAndRemoveUserEnum.name

            Case AddAndRemoveUserEnum.username

            Case AddAndRemoveUserEnum.permissions

            Case AddAndRemoveUserEnum.active

        End Select

    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: CreatePanel()                  */         
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
    '/*                                                                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/* flpPannel- the flow panel which the user wants to create the      */
    '/*     create the single panel.                                      */
    '/* strID- value from the database we will display                    */
    '/* strName- Name of the user in the database                         */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	   CreatePanel(flpUserInfo, strID9, strFirstName9, strAccess9)    */
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
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/6/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreatePanel(ByVal flpPannel As FlowLayoutPanel, ByVal strID As String, ByVal strName As String, ByVal strUsername As String, ByVal strAccess As String, ByVal strActive As String)

        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel
        ' call method here to get the count from the database and update the panel number so the next item is correct

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(flpUserInfo.Size.Width - 25, 47)
            .Name = "pnlIndividualUserRecordPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(flpUserInfo.Size.Width - 25, 45)
            .Name = "pnlIndividualUserRecord" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
        End With

        'put the boarder panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault

        CreateEditButton(pnlMainPanel, getPanelCount(flpPannel), lblActions.Location.X - 15, 5)
        CreateDeleteBtn(pnlMainPanel, getPanelCount(flpPannel), lblActions.Location.X + 30, 5)

        ' create labels at run time and pass them to the create label method to format how the labels will look and their
        ' properties
        Dim lblID As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label
        Dim lblID5 As New Label
        lblID.Visible = False
        Const INTTWENTY As Integer = 20

        ' anywhere we have quotes except for the label names, we can call our Database and get method
        CreateIDLabel(pnlMainPanel, lblID, "lblID", lblName.Location.X - 15, INTTWENTY, strID, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID2, "lblNames", lblName.Location.X, INTTWENTY, strName, getPanelCount(flpPannel), tpToolTip, TruncateString(20, strName))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID3, "lblUsername", lblUserName.Location.X, INTTWENTY, strUsername, getPanelCount(flpPannel), tpToolTip, TruncateString(20, strUsername))
        ' CreateIDLabel(pnlMainPanel, lblID2, "lblNames", lblName.Location.X, INTTWENTY, strName, getPanelCount(flpPannel))
        ' CreateIDLabel(pnlMainPanel, lblID3, "lblUsername", lblUserName.Location.X, INTTWENTY, strUsername, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID4, "lblPermissions", lblPermissions.Location.X, INTTWENTY, strAccess, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID5, "lblStatus", lblStatus.Location.X, INTTWENTY, strActive, getPanelCount(flpPannel))

        'Add panel to flow layout panel
        flpPannel.Controls.Add(pnl)

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: txtUsername_LostFocus          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 2/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This  sub program is used to check if the Username already exist */ 
    '/*  in the User table when you leave txtUsername  				      */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	CreateDatabase.ExecuteScalarQuery                        */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	  "dwwalter"                                                       */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */   
    '/*strStatement- SQL String passed to ExecuteScalarQuery to check     */
    '/* User table for a duplicate Username                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  Dylan W    2/10/2021    Initial creation and check data in DB   */
    '/*********************************************************************/
    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        'String to be sent to CreateDatabase Module to exicute search to check if Username is already in the User Table
        Dim strStatement = "SELECT COUNT(*) FROM User WHERE Username = '" & txtUsername.Text & "'"
        If ExecuteScalarQuery(strStatement) <> 0 Then
            MsgBox("A User already has that Username")
            txtUsername.Focus()
            txtUsername.Text = ""
        End If
    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: txtBarcode_LostFocus          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 2/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This  sub program is used to check if the Barcode already exist */ 
    '/*  in the User table when you leave txtBarcode  				      */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	CreateDatabase.ExecuteScalarQuery                        */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	  "6gGMRK7bIKlWkNEp4mT71hAU"                                       */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */   
    '/*strStatement- SQL String passed to ExecuteScalarQuery to check     */
    '/* User table for a duplicate Bqarcode                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  Dylan W    2/10/2021    Initial creation and check data in DB   */
    '/*********************************************************************/
    Private Sub txtBarcode_LostFocus(sender As Object, e As EventArgs) Handles txtBarcode.LostFocus
        ' Convert the barcode to the peppered hash
        Dim strHashedBarcode = ConvertBarcodePepperAndHash(txtBarcode.Text)
        'String to be sent to CreateDatabase Module to exicute search to check if Barcode is already in the User Table
        Dim strStatement = "SELECT COUNT(*) FROM User WHERE Barcode = '" & strHashedBarcode & "'"
        If ExecuteScalarQuery(strStatement) <> 0 Then
            MsgBox("A User already has that Barcode")
            txtBarcode.Focus()
            txtBarcode.Text = ""
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: btnSaveUser.Click 		    	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Dylan Walter    		            */   
    '/*		         DATE CREATED: 2/6/2021                      		   */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE: when button1 is clicked check if data in all 	*/             
    '/*	text boxes is valid and insert into the User table in SQL 			*/                     
    '/*  database                                                                 */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:	CheckPassword						        			   */                 
    '/*         CreateDatabase.ExecuteInsertQuery   					   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*		intActiveFlag- used to assign 1 to the active flag      	   */                     
    '/*      intAdmin- 1 if admin radio button is checked                   */
    '/*		strFirstName- text from txtFirstName 							*/
    '/*     strHashedBarcode - hashed barcode
    '/*		strLastName- text from txtLastName								*/
    '/*		strPassword- text from txtPassword								*/
    '/*     strResults() - the results of the salt and the hashed password  */
    '/*     strSalt - the salt of the password                              */
    '/*		strSpecialChar-	list of allowed special characters				*/
    '/*     strStatement- SQL String passed to ExecuteScalarQuery to check */
    '/*		intSupervisor- 1 if supervisor radio button is checked		    */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO        WHEN     WHAT								   */             
    '/*  ---        ----     ------------------------------------------------- */
    '/*	Dylan W	    2/3/2021  Users can now be added to the User Table		*/ 
    '/*  NP         2/10/2021 Changed the first and last name to accept '-@ */  
    '/*	Dylan W     2/10/2021 checked first and last for multiple ' 	   */ 
    '/* Eric L.     2/17/2021 Added methods to salt, pepper and hash        */
    '/*********************************************************************/


    Private Sub btnSaveUser_Click(sender As Object, e As EventArgs) Handles btnSaveUser.Click

        Dim intSupervisor As Integer = 0
        Dim intAdmin As Integer = 0
        Dim intActiveFlag As Integer = 1
        Dim strPassword As String = txtPassword.Text
        Dim strLastName As String = txtLastName.Text
        Dim strFirstName As String = txtFirstName.Text
        Dim strSalt As String = Nothing
        Dim strResults() As String = Nothing ' this will hold the salted, peppered, hashed password and the salt
        Dim strHashedBarcode As String ' this will hold the peppered, hashed barcode
        Dim strFullName As String = strFirstName & " " & strLastName
        strFirstName = Regex.Replace(strFirstName, "'", "''")
        strLastName = Regex.Replace(strLastName, "'", "''")
        strFirstName = Regex.Replace(strFirstName, """", "")
        strLastName = Regex.Replace(strLastName, """", "")

        'check what Role the user will have
        If rbtnAdministrator.Checked = True Then
            intAdmin = 1
        ElseIf rbtnSupervisor.Checked = True Then
            intSupervisor = 1
        End If

        'call CheckPassword Function to see if password mets security standards
        If CheckPassword(strPassword) = False Then
            MsgBox("Password must contain at least 8 characters, 1 uppercase, 1 lowercase, 1 number, 1 special characters !@#$%^&*()/.,<>=+-_ ")
            txtPassword.Focus()
            ' make sure password and Confirm Password Match
        ElseIf txtPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("Confirm Password must match Password")
            txtConfirmPassword.Focus()
            'Make Sure all fields are filled
        ElseIf txtFirstName.Text = "" Or txtLastName.Text = "" Or txtUsername.Text = "" Or txtBarcode.Text = "" Then
            MsgBox("All Fields must be filled")
        Else
            ' get the peppered hash of the password
            strResults = LogIn.MakeSaltPepperAndHash(strPassword)
            strPassword = strResults(0)
            strSalt = strResults(1)

            ' Convert the barcode to the peppered hash
            strHashedBarcode = ConvertBarcodePepperAndHash(txtBarcode.Text)

            'Insert data into table by calling ExecuteInsertQuery in CreateDatabase Module

            Dim strStatement = "INSERT INTO USER(Username,Salt,Password,User_First_Name, User_Last_Name, Barcode, Admin_Flag, Supervisor_Flag, Active_Flag)" &
            "VALUES('" & txtUsername.Text & "','" & strSalt & "','" & strPassword & "','" & strFirstName & "','" & strLastName & "','" & strHashedBarcode & "','" & intAdmin & "','" & intSupervisor & "','" & intActiveFlag & "')"
            ExecuteInsertQuery(strStatement)



            strStatement = "SELECT User_ID FROM User ORDER BY User_ID DESC LIMIT 1;"
            Dim strNewID As String = ExecuteScalarQuery(strStatement)

            Dim strRole As String
            'check what Role the user will have
            If rbtnAdministrator.Checked = True Then
                strRole = "Admin"
            ElseIf rbtnSupervisor.Checked = True Then
                strRole = "Supervisor"
            Else strRole = "Nurse"
            End If

            ' do query to return the record that was just created and return the result into the create panel method below
            CreatePanel(flpUserInfo, strNewID, strFullName, txtUsername.Text, strRole, "Yes")





            'clear all text boxes
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtUsername.Text = ""
            txtBarcode.Text = ""
            txtPassword.Text = ""
            txtConfirmPassword.Text = ""
        End If


    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  CheckPassword			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter   						 */   
    '/*		         DATE CREATED: 	2/7/2021							   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:											   */             
    '/*  Will check if the password being entered meets security          */
    '/*  requierments                                                     */
    '/*********************************************************************/
    '/*  CALLED BY: Button1_Click        	      						  */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):								*/         
    '/*	 strPassword - this is the password being tested                  */ 
    '/*					    `   										  */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            Secure								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*		regLower- Regex of all lowercase letters						*/                     
    '/*		intMinLength- number of needed characters					*/ 
    '/*		regNumber- Regex of all numbers 								*/ 
    '/*		intNumLower- number of needed lowercase letters 				*/ 
    '/*		intNumNumbers- number of needed numbers							*/ 
    '/*		intNumUpper- number of needed uppercase letters					*/ 
    '/*		intNumSpecial- number of needed special characters 				*/ 
    '/*		bolSecure- returned boolean, true if requirements are met	    */    
    '/*     regSpecial- Regex of all other characters                       */
    '/*     regUpper- Regex of all uppercase letters                        */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                        */               
    '/*											                            */                     
    '/*  WHO            WHEN        WHAT								   */             
    '/*  ---            ----        ------------------------------------- */
    '/*  Dylan Walter   2/7/2021    Initial Creation                      */
    '/*  Nathan Premo   2/10/2021   adding the ability for first and last */
    '/*                             name to have ' - @                    */
    '/*********************************************************************/
    Function CheckPassword(strPassword)
        'Security Requierments 
        Dim intMinLength As Integer = 8
        Dim intNumUpper As Integer = 1
        Dim intNumLower As Integer = 1
        Dim intNumNumbers As Integer = 1
        Dim intNumSpecial As Integer = 1
        Dim bolSecure As Boolean = True

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim regUpper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim regLower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim regNumber As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim regSpecial As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Check the length.
        If Len(strPassword) < intMinLength Then bolSecure = False
        ' Check for minimum number of occurrences.
        If regUpper.Matches(strPassword).Count < intNumUpper Then bolSecure = False
        If regLower.Matches(strPassword).Count < intNumLower Then bolSecure = False
        If regNumber.Matches(strPassword).Count < intNumNumbers Then bolSecure = False
        If regSpecial.Matches(strPassword).Count < intNumSpecial Then bolSecure = False

        ' Passed all checks.
        Return bolSecure
    End Function

    '/*********************************************************************/
    '/*                   SubProgram NAME: btnSaveChanges_Click		    	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Dylan Walter    		            */   
    '/*		         DATE CREATED: 3/6/2021                      		   */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE: when btnSaveChanges is clicked check 	*/             
    '/*	if data in all text boxes is valid and change the User table in SQL 			*/                     
    '/*  database                                                                 */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:	CheckPassword						        			   */                 
    '/*         CreateDatabase.ExecuteInsertQuery   					   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*		intActiveFlag- used to assign 1 to the active flag      	   */                     
    '/*      intAdmin- 1 if admin radio button is checked                   */
    '/*		strFirstName- text from txtFirstName 							*/
    '/*     strHashedBarcode - hashed barcode
    '/*		strLastName- text from txtLastName								*/
    '/*		strPassword- text from txtPassword								*/
    '/*     strResults() - the results of the salt and the hashed password  */
    '/*     strSalt - the salt of the password                              */
    '/*		strSpecialChar-	list of allowed special characters				*/
    '/*     strStatement- SQL String passed to ExecuteScalarQuery to check */
    '/*		intSupervisor- 1 if supervisor radio button is checked		    */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO        WHEN     WHAT								   */             
    '/*  ---        ----     ------------------------------------------------- */
    '/*	Dylan W	    3/6/2021  Users can now be added to the User Table		*/ 
    '/*********************************************************************/
    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        Dim intID As Integer = txtID.Text
        Dim strStatement = "SELECT COUNT(*) FROM User WHERE Username = '" & txtUsername.Text & "'" & " OR User_ID = '" & intID & "'"
        Dim intSupervisor As Integer = 0
        Dim intAdmin As Integer = 0
        Dim strPassword As String = txtPassword.Text
        Dim strLastName As String = txtLastName.Text
        Dim strFirstName As String = txtFirstName.Text
        Dim strSalt As String = Nothing
        Dim strResults() As String = Nothing ' this will hold the salted, peppered, hashed password and the salt
        Dim strHashedBarcode As String
        strFirstName = Regex.Replace(strFirstName, "'", "''")
        strLastName = Regex.Replace(strLastName, "'", "''")
        strFirstName = Regex.Replace(strFirstName, """", "")
        strLastName = Regex.Replace(strLastName, """", "")

        'check what Role the user will have
        If rbtnAdministrator.Checked = True Then
            intAdmin = 1
        ElseIf rbtnSupervisor.Checked = True Then
            intSupervisor = 1
        End If

        'check if the user is changing the password and ran if yes

        If txtConfirmPassword.Text <> "" And txtPassword.Text <> "" Then
            'if it returns 2 then the username was changed to something already in the database 
            If ExecuteScalarQuery(strStatement) = 2 Then
                MsgBox("A User already has that Username")
                'call CheckPassword Function to see if password mets security standards
            ElseIf CheckPassword(strPassword) = False Then
                MsgBox("Password must contain at least 8 characters, 1 uppercase, 1 lowercase, 1 number, 1 special characters !@#$%^&* ")
                txtPassword.Focus()
                ' make sure password and Confirm Password Match
            ElseIf txtPassword.Text <> txtConfirmPassword.Text Then
                MsgBox("Confirm Password must match Password")
                txtConfirmPassword.Focus()
                'Make Sure all fields are filled
            ElseIf txtFirstName.Text = "" Or txtLastName.Text = "" Or txtUsername.Text = "" Then
                MsgBox("All Fields must be filled12")
            Else
                ' get the peppered hash of the password
                strResults = LogIn.MakeSaltPepperAndHash(strPassword)
                strPassword = strResults(0)
                strSalt = strResults(1)

                If txtBarcode.Text = "" Then
                    'Insert data into table by calling ExecuteInsertQuery in CreateDatabase Module
                    strStatement = "UPDATE USER SET Username='" & txtUsername.Text & "',Salt='" & strSalt & "',Password='" & strPassword & "',User_First_Name='" & strFirstName & "',User_Last_Name='" & strLastName & "',Admin_Flag='" & intAdmin & "',Supervisor_Flag='" & intSupervisor & "',Active_Flag=1 WHERE User_ID='" & txtID.Text & "';"
                    ExecuteInsertQuery(strStatement)
                Else
                    ' Convert the barcode to the peppered hash
                    strHashedBarcode = ConvertBarcodePepperAndHash(txtBarcode.Text)
                        'Insert data into table by calling ExecuteInsertQuery in CreateDatabase Module
                        strStatement = "UPDATE USER SET Username='" & txtUsername.Text & "',Salt='" & strSalt & "',Password='" & strPassword & "',User_First_Name='" & strFirstName & "',User_Last_Name='" & strLastName & "',Barcode='" & strHashedBarcode & "',Admin_Flag='" & intAdmin & "',Supervisor_Flag='" & intSupervisor & "',Active_Flag=1 WHERE User_ID='" & txtID.Text & "';"
                        ExecuteInsertQuery(strStatement)
                    End If
                End If



                'clear all text boxes and change button visibility back to default 
                txtFirstName.Text = ""
                txtLastName.Text = ""
                txtUsername.Text = ""
                txtBarcode.Text = ""
                txtPassword.Text = ""
                txtConfirmPassword.Text = ""
                txtID.Text = ""
                btnCancel.Visible = False
                btnSaveChanges.Visible = False
                btnSaveUser.Visible = True
            End If




        'check if the user is changing the password and ran if no
        If txtConfirmPassword.Text = "" And txtPassword.Text = "" And txtID.Text <> "" Then
            'if it returns 2 then the username was changed to something already in the database 
            If ExecuteScalarQuery(strStatement) = 2 Then
                MsgBox("A User already has that Username")
                'call CheckPassword Function to see if password mets security standards
                ' make sure password and Confirm Password Match
            ElseIf txtPassword.Text <> txtConfirmPassword.Text Then
                MsgBox("Confirm Password must match Password")
                txtConfirmPassword.Focus()
                'Make Sure all fields are filled
            ElseIf txtFirstName.Text = "" Or txtLastName.Text = "" Or txtUsername.Text = "" Then
                MsgBox("All Fields must be filled in")
            Else
                If txtBarcode.Text = "" Then
                    'Insert data into table by calling ExecuteInsertQuery in CreateDatabase Module
                    strStatement = "UPDATE USER SET Username='" & txtUsername.Text & "',User_First_Name='" & strFirstName & "',User_Last_Name='" & strLastName & "',Admin_Flag='" & intAdmin & "',Supervisor_Flag='" & intSupervisor & "',Active_Flag=1  WHERE User_ID='" & txtID.Text & "';"
                    ExecuteInsertQuery(strStatement)
                Else
                    ' Convert the barcode to the peppered hash
                    strHashedBarcode = ConvertBarcodePepperAndHash(txtBarcode.Text)
                        'Insert data into table by calling ExecuteInsertQuery in CreateDatabase Module
                        strStatement = "UPDATE USER SET Username='" & txtUsername.Text & "',User_First_Name='" & strFirstName & "',User_Last_Name='" & strLastName & "',Barcode='" & strHashedBarcode & "',Admin_Flag='" & intAdmin & "',Supervisor_Flag='" & intSupervisor & "',Active_Flag=1  WHERE User_ID='" & txtID.Text & "';"
                        ExecuteInsertQuery(strStatement)
                    End If
                End If



                'clear all text boxes and change button visibility back to default 
                txtFirstName.Text = ""
                txtLastName.Text = ""
                txtUsername.Text = ""
                txtBarcode.Text = ""
                txtPassword.Text = ""
                txtConfirmPassword.Text = ""
                btnCancel.Visible = False
                btnSaveChanges.Visible = False
                btnSaveUser.Visible = True
            End If

        SortItems()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'clear all text boxes and change button visibility back to default 
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtUsername.Text = ""
        txtBarcode.Text = ""
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""
        btnCancel.Visible = False
        btnSaveChanges.Visible = False
        btnSaveUser.Visible = True
        Label2.Text = "Create New User"
    End Sub

    Private Sub btnPasswordEye_Click(sender As Object, e As EventArgs) Handles btnPasswordEye.Click
        'If checked then password is visible as plain text
        If txtPassword.UseSystemPasswordChar = False Then

            txtPassword.UseSystemPasswordChar = True
            'If unchecked then password is visible as *
        Else
            txtPassword.UseSystemPasswordChar = False

        End If
    End Sub

    Private Sub btnConfirmEye_Click(sender As Object, e As EventArgs) Handles btnConfirmEye.Click
        'If checked then password is visible as plain text
        If txtConfirmPassword.UseSystemPasswordChar = False Then

            txtConfirmPassword.UseSystemPasswordChar = True
            'If unchecked then password is visible as *
        Else
            txtConfirmPassword.UseSystemPasswordChar = False

        End If
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: SearchIcon_Click               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 3/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the search button is clicked check the databse for users   */   
    '/*	  with Username, first name, last name similar to search text     */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	Fill_Table(strFillSQL)                                  */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */   
    '/* strFillSQL- SQL String passed to Fill_Table                        */
    '/* strSearch- text from txtSearchBox                                 */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  Dylan W    3/10/2021    Initial creation                          */
    '/*********************************************************************/
    Private Sub SearchIcon_Click(sender As Object, e As EventArgs) Handles pnlSearch.Click
        SortItems()

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: txtSearch_TextChanged         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 3/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the search button is empty then fill panels                  */   
    '/*	                                                                */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	Fill_Table(strFillSQL)                                  */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */   
    '/* strFillSQL- SQL String passed to Fill_Table                        */
    '/* strSearch- text from txtSearchBox                                 */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  Dylan W    3/10/2021    Initial creation                          */
    '/*********************************************************************/
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBox.TextChanged

        'if the text box is empty then reset the panels
        If txtSearchBox.Text = "" Then
            SortItems()

        End If



    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: Fill_Table                      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 3/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 take the SQL results from CreateDatabase.ExecuteSelectQuery      */   
    '/*	 Organize the data into a dataset and send to CreatePanel        */   
    '/*********************************************************************/
    '/*  CALLED BY: frmConfiguration_Load                                 */         
    '/*             btnSaveChanges_Click                                */  
    '/*             SearchIcon_Click                                     */  
    '/*             txtSearch_TextChanged                                */  
    '/*             Search_KeyPress                                      */  
    '/*             lblName_Click                                           */  
    '/*             lblUserName_Click                                     */  
    '/*             lblStatus_Click                                         */         
    '/*             lblPermissions_Click                                    */    
    '/* GraphicalUserInterfaceReusableMethods. DetermineQueryDelete_Click */
    '/*********************************************************************/
    '/*  CALLS:	CreatePanel                                 */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     strFillSQL                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */   
    '/* strActive- check if the user table has 1/0 and set text to yes/no */
    '/* strFirst- pull users first name from table                        */
    '/* strLast- pull users last name from table                        */                     
    '/* strName- combine first and last name                              */
    '/* dsUserInfo- get dataset from the user table                       */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  Dylan W    3/10/2021    Initial creation and check data in DB   */
    '/*********************************************************************/
    Public Sub Fill_Table(ByVal strFillSQL As String)

        ' remove all controls and the handlers of those controls before generating new panels
        RemoveHandlersAndAssociations(GetListOfAllControls(flpUserInfo), flpUserInfo)
        'flpUserInfo.Controls.Clear()
        Dim dsUserInfo As DataSet = CreateDatabase.ExecuteSelectQuery(strFillSQL)



        For Each item As DataRow In dsUserInfo.Tables(0).Rows()
            With dsUserInfo.Tables(0)
                'grab first name and last name and merge into one string
                Dim strFirst As String = item.Item(2)
                Dim strLast As String = item.Item(3)
                Dim strName = strFirst & " " & strLast
                Dim strActive As String = ""

                If (item.Item(6)) = 1 Then
                    strActive = "Yes"
                Else strActive = "No"
                End If
                'check what role the person has, if adminis 1 then it does not matter what Supervisor is 
                'if admin is 0 then check supervisor. If both admin and supervidor are 0 then the 
                'user is a nurse
                Dim strRole As String
                If (item.Item(4)) = 1 Then
                    strRole = "Admin"
                ElseIf (item.Item(5)) = 1 Then
                    strRole = "Supervisor"
                Else strRole = "Nurse"
                End If

                'populate data into panels
                CreatePanel(flpUserInfo, item.Item(0), strName, item.Item(1),
                               strRole, strActive)

            End With
        Next
    End Sub


    '/*********************************************************************/
    '/*                   SUB NAME: RemoveHandlersAndAssociations         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/13/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to iterate over a list of controls and remove the  */
    '/* control handlers before removing and disposing of the controls    */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*     cmbFilter_SelectedIndexChanged                                */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*         nothing                                    				  */                     
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 A flow panel object                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 RemoveHandlersAndAssociations(listOfControls, flowpanel1)    	  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	ctlControlObject- a control representing all controls             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/13/2021    Initial creation                    */
    '/*  Dylan Walter    4/6/2021    copied to frmConfiguration           */
    '/*********************************************************************/

    Private Sub RemoveHandlersAndAssociations(ByVal lstOfControlsToRemove As List(Of Control), flpFlowPanel As FlowLayoutPanel)

        Dim ctlControlObject As Control
        Const PANELWITHASSIGNEDHANDLERS As String = "pnlIndividualUserRecord"
        For Each ctlControlObject In lstOfControlsToRemove

            If TypeName(ctlControlObject) = "TextBox" Then
                ' no handler here
                flpFlowPanel.Controls.Remove(ctlControlObject)
                ctlControlObject.Dispose()

            ElseIf TypeName(ctlControlObject) = "Button" Then
                ' remove the handler that is assiged to all edit buttons
                RemoveHandler ctlControlObject.Click, AddressOf DynamicFlagMedicationButton
                flpFlowPanel.Controls.Remove(ctlControlObject)
                ctlControlObject.Dispose()

            ElseIf TypeName(ctlControlObject) = "Panel" And ctlControlObject.Name.Contains(PANELWITHASSIGNEDHANDLERS) Then

                RemoveHandler ctlControlObject.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
                RemoveHandler ctlControlObject.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault
                flpFlowPanel.Controls.Remove(ctlControlObject)
                ctlControlObject.Dispose()
            Else

                flpFlowPanel.Controls.Remove(ctlControlObject)
                ctlControlObject.Dispose()
            End If

        Next

        ' clear the panel even though it should be empty at this point and all links to old controls are deleted.
        flpFlowPanel.Controls.Clear()

    End Sub

    '/*********************************************************************/
    '/*                   Function NAME: GetListOfAllControls             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/13/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to iterate over the flow panel and return all of the/
    '/*  controls within the flow panel.                                  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*             RemoveHandlersAndAssociations                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             nothing                                				  */             
    '/*********************************************************************/
    '/*  Returns: A list of controls that are contained on the flowpanel  */                 
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 A flow panel object                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 GetListOfAllControls(FlowPanel1)       						  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	ctlRemainingControls- a control representing all non panel controls/
    '/* pnlMain- a control which represents a panel in this usecase       */
    '/*     particular panel.                                             */
    '/* pnlPadding- a control which represents a panel in this usecase    */
    '/*     particular panel.                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/13/2021    Initial creation                    */
    '/*  Dylan Walter    4/6/2021    copied to frmConfiguration           */
    '/*********************************************************************/
    Private Function GetListOfAllControls(ByVal flpFlowPanel As FlowLayoutPanel)

        ' the order in which this list is created is important because the controls added
        ' to this list will need to be disposed of and have handles removed properly
        ' to allow for effecient use of resources within the software.

        Dim lstOfControlsToRemove As New List(Of Control)
        Dim pnlPadding As Control
        Dim pnlMain As Control
        Dim ctlRemainingControls As Control

        ' add all of the padding panels to the list
        For Each pnlPadding In flpFlowPanel.Controls
            lstOfControlsToRemove.Add(pnlPadding)
        Next

        ' add all of the main panels to the list
        For Each pnlPadding In flpFlowPanel.Controls
            For Each pnlMain In pnlPadding.Controls
                lstOfControlsToRemove.Add(pnlMain)
            Next
        Next

        ' add all of the remaining controls such as txtboxes, labels, and buttons to the list
        For Each pnlPadding In flpFlowPanel.Controls
            For Each pnlMain In pnlPadding.Controls
                For Each ctlRemainingControls In pnlMain.Controls
                    lstOfControlsToRemove.Add(ctlRemainingControls)
                Next
            Next
        Next


        ' List of all controls on the form is populated. Next, the controls needs to be
        ' iterated over from last to first because if the panels are disposed of before
        ' the single controls, the handlers and other parts will not be disposed of correctly
        ' and may consume memory for the life of the running application.

        lstOfControlsToRemove.Reverse()

        Return lstOfControlsToRemove

    End Function

    '/*********************************************************************/
    '/*                   SubProgram NAME: Search_KeyPress               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 3/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the enter key is pressed check the databse for users         */   
    '/*	  with Username, first name, last name similar to search text     */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	Fill_Table(strFillSQL)                                  */            
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	     sender                                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */   
    '/* strFillSQL- SQL String passed to Fill_Table                        */
    '/* strSearch- text from txtSearchBox                                 */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN            WHAT					               */             
    '/*  Dylan W    3/10/2021    Initial creation and check data in DB   */
    '/*********************************************************************/
    Private Sub Search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchBox.KeyPress
        'when the user hits enter in the search text box then backspace the enter then run the search
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            SortItems()
        End If
    End Sub

    Private Sub Name_Search_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress, txtLastName.KeyPress, txtSearchBox.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz '-1234567890!@#$%^&*.,<>=+")
    End Sub

    Private Sub Password_Barcode_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress, txtConfirmPassword.KeyPress, txtBarcode.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz-1234567890!@#$%^&*.,<>=+")
    End Sub

    Private Sub lblName_Click(sender As Object, e As EventArgs) Handles lblName.Click
        'sort by User First name
        If strSort <> "User_First_Name COLLATE NOCASE ASC;" Then
            strSort = "User_First_Name COLLATE NOCASE ASC;"
        Else strSort = "User_First_Name COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblUserName_Click(sender As Object, e As EventArgs) Handles lblUserName.Click
        'sort by User Username
        If strSort <> "Username COLLATE NOCASE ASC;" Then
            strSort = "Username COLLATE NOCASE ASC;"
        Else strSort = "Username COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblStatus_Click(sender As Object, e As EventArgs) Handles lblStatus.Click
        'sort by User Active flag
        If strSort <> "Active_Flag DESC;" Then
            strSort = "Active_Flag DESC;"
        Else strSort = "Active_Flag ASC;"
        End If
        SortItems()
    End Sub

    Private Sub lblPermissions_Click(sender As Object, e As EventArgs) Handles lblPermissions.Click
        'sort by User Permission level
        If strSort <> "Supervisor_Flag, Admin_Flag DESC;" Then
            strSort = "Supervisor_Flag, Admin_Flag DESC;"
        Else strSort = "Supervisor_Flag, Admin_Flag ASC;"
        End If
        SortItems()
    End Sub

    Sub SortItems()
        Dim strFillSQL As String
        Dim strSearch = txtSearchBox.Text
        'when the user searches change the single comma to allow searching
        strSearch = Regex.Replace(strSearch, "'", "''")
        If txtSearchBox.Text = "" Then
            strFillSQL = "select User.User_ID, User.Username, User.User_First_Name, User.User_Last_Name, User.Admin_Flag, " &
                              "User.Supervisor_Flag, User.Active_Flag From User ORDER BY " & strSort
        Else
            strFillSQL = "select User.User_ID, User.Username, User.User_First_Name, User.User_Last_Name, User.Admin_Flag, " &
                             "User.Supervisor_Flag, User.Active_Flag From User WHERE Username LIKE '" & strSearch & "%' Or User_First_Name LIKE '" & strSearch & "%' Or User_Last_Name LIKE '" & strSearch & "%' ORDER BY " & strSort
        End If
        Fill_Table(strFillSQL)

    End Sub
End Class