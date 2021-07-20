Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmEditPhysician
    Dim strSort As String
    Public Enum AddAndRemovePhysicianEnum

        name = 1
        username = 2
        permissions = 3
        active = 4

    End Enum

    '/*********************************************************************/
    '/*                   SubProgram NAME: frmEditPhysician_Load          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 2/10/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This  sub program is used to populate the flpPhysicianInfo Flow       */
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
    Private Sub frmEditPhysician_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName_Click(Nothing, Nothing)
        lblName.Font = New Font(New FontFamily("Segoe UI Semibold"), 12, FontStyle.Underline)
        cboCredentials.Items.AddRange({"MD", "DO", "MBBS", "PhD", "DNP", "NP", "PA", "CNP", "CNNP", "PA", "CNS", "CNM"})
        PopulateStateComboBox(cboState)
        'btnSaveChanges.Visible = False
        btnCancel.Visible = False

        'CreateToolTips(pnlPhysicianHeader, tpLabelHover)
        AddHandlerToLabelClick(pnlPhysicianHeader, AddressOf SortBySelectedLabel)

        txtID.Visible = False
        btnSaveChanges.Visible = False
        btnCancel.Visible = False
        strSort = "Physician_First_Name COLLATE NOCASE ASC;"

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
        If parent.Name = pnlPhysicianHeader.Name Then

            EditPhysicianSelectedFields(field)

        End If


    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: EditPhysicianSelectedFields   */         
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
    '/*	 EditPhysicianSelectedFields(Cint(Label1.Tag))   	              */
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
    Private Sub EditPhysicianSelectedFields(ByVal field As Integer)

        ' clear the controls as they will need to be rebuilt when sorting
        'flpPatientRecords.Controls.Clear()

        Select Case field

            Case AddAndRemovePhysicianEnum.name

            Case AddAndRemovePhysicianEnum.username

            Case AddAndRemovePhysicianEnum.permissions

            Case AddAndRemovePhysicianEnum.active

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
    '/*  CALLED BY: frmEditPhysician_Load  	      						  */           
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
    '/*	   CreatePanel(flpPhysicianInfo, strID9, strFirstName9, strAccess9)    */
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
    Public Sub CreatePanel_Physician(ByVal flpPannel As FlowLayoutPanel, ByVal strID As String, ByVal strName As String, ByVal strAccess As String, ByVal strActive As String)

        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel
        ' call method here to get the count from the database and update the panel number so the next item is correct

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(flpPhysicianInfo.Size.Width - 25, 47)
            .Name = "pnlIndividualPhysicianRecordPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(flpPhysicianInfo.Size.Width - 25, 45)
            .Name = "pnlIndividualPhysicianRecord" + getPanelCount(flpPannel).ToString
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
        CreateIDLabelWithToolTip(pnlMainPanel, lblID2, "lblNames", lblName.Location.X, INTTWENTY, strName, getPanelCount(flpPannel), tpToolTip, TruncateString(30, strName))
        '  CreateIDLabel(pnlMainPanel, lblID2, "lblNames", lblName.Location.X, INTTWENTY, strName, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID4, "lblPermissions", lblPermissions.Location.X, INTTWENTY, strAccess, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID5, "lblStatus", lblStatus.Location.X, INTTWENTY, strActive, getPanelCount(flpPannel))


        'Add panel to flow layout panel
        flpPannel.Controls.Add(pnl)

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: Button1_Click 		    	   */         
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


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim intActiveFlag As Integer = 1
        Dim strLastName As String = txtLastName.Text
        Dim strFirstName As String = txtFirstName.Text
        Dim strMiddleName As String = txtMiddleName.Text
        Dim strAddress As String = txtAddress.Text
        Dim strCity As String = txtCity.Text
        Dim strFullName As String = strFirstName & " " & strLastName
        strFirstName = Regex.Replace(strFirstName, "'", "''")
        strLastName = Regex.Replace(strLastName, "'", "''")
        strMiddleName = Regex.Replace(strMiddleName, "'", "''")
        strAddress = Regex.Replace(strAddress, "'", "''")
        strCity = Regex.Replace(strCity, "'", "''")
        'Make Sure all fields are filled
        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtMiddleName.Text = "" Or txtAddress.Text = "" Or txtCity.Text = "" Or txtZipCode.MaskCompleted = False Or mtbPhone.MaskCompleted = False Or mtbFax.MaskCompleted = False Then
            MessageBox.Show("All fields must be filled in.")
        Else

            'Insert data into table by calling ExecuteInsertQuery in CreateDatabase Module

            Dim strStatement = "INSERT INTO Physician(Physician_First_Name, Physician_Middle_Name, Physician_Last_Name, Physician_Credentials, Physician_Phone_Number, Physician_Fax_Number, Physician_Address, Physician_City, Physician_State, Physician_Zip_Code, Active_Flag)" &
            "VALUES('" & strFirstName & "','" & strMiddleName & "','" & strLastName & "','" & cboCredentials.SelectedItem & "','" & mtbPhone.Text & "','" & mtbFax.Text & "','" & strAddress & "','" & strCity & "','" & cboState.SelectedItem & "','" & txtZipCode.Text & "','" & intActiveFlag & "')"
            ExecuteInsertQuery(strStatement)



            strStatement = "SELECT User_ID FROM User ORDER BY User_ID DESC LIMIT 1;"
            Dim strNewID As String = ExecuteScalarQuery(strStatement)


            ' do query to return the record that was just created and return the result into the create panel method below
            CreatePanel_Physician(flpPhysicianInfo, strNewID, strFullName, cboCredentials.SelectedItem, "Yes")

            'clear all text boxes
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtMiddleName.Text = ""
            txtAddress.Text = ""
            txtCity.Text = ""
            txtZipCode.Text = ""
            mtbFax.Text = ""
            mtbPhone.Text = ""
            cboCredentials.SelectedItem = Nothing
            cboState.SelectedItem = Nothing
            MessageBox.Show("Physician added.")

            SortItems()
        End If


    End Sub

    Private Sub NameKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles  txtMiddleName.KeyPress, txtLastName.KeyPress, txtFirstName.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz '-1234567890!@#$%^&*.,<>=+")
    End Sub
    Private Sub AddressKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz '-1234567890&()/.,")
    End Sub
    Private Sub CityKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCity.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz' &()/.,")
    End Sub

    Private Sub ZipKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        KeyPressCheck(e, "1234567890")
    End Sub

    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        Dim intID As Integer = txtID.Text
        Dim strStatement = "SELECT COUNT(*) FROM Physician WHERE Physician_First_Name = '" & txtFirstName.Text & "'" & " AND Physician_Middle_Name = '" & txtMiddleName.Text & "'" & " AND Physician_Last_Name = '" & txtLastName.Text & "'"
        Dim intSupervisor As Integer = 0
        Dim intAdmin As Integer = 0
        Dim strLastName As String = txtLastName.Text
        Dim strFirstName As String = txtFirstName.Text
        Dim strMiddleName As String = txtMiddleName.Text
        Dim strAddress As String = txtAddress.Text
        Dim strCity As String = txtCity.Text
        strFirstName = Regex.Replace(strFirstName, "'", "''")
        strLastName = Regex.Replace(strLastName, "'", "''")
        strMiddleName = Regex.Replace(strMiddleName, "'", "''")
        strAddress = Regex.Replace(strAddress, "'", "''")
        strCity = Regex.Replace(strCity, "'", "''")
        lblTitle.Text = "Create New Physician"


        'if it returns 2 then the First, Middle, and Last Name match someone else already in the database 
        If ExecuteScalarQuery(strStatement) = 2 Then
            MessageBox.Show("A physician already has that first, middle, and last name.")
            'Make Sure all fields are filled
        ElseIf txtFirstName.Text = "" Or txtLastName.Text = "" Or txtMiddleName.Text = "" Or txtAddress.Text = "" Or txtCity.Text = "" Or txtZipCode.MaskCompleted = False Or mtbPhone.MaskCompleted = False Or mtbFax.MaskCompleted = False Then
            MessageBox.Show("All fields must be filled in.")
        Else
            'Insert data into table by calling ExecuteInsertQuery in CreateDatabase Module
            strStatement = "UPDATE Physician SET Physician_First_Name='" & strFirstName & "',Physician_Middle_Name='" & strMiddleName & "', Physician_Last_Name='" & strLastName & "', Physician_Credentials='" & cboCredentials.SelectedItem & "', Physician_Phone_Number='" & mtbPhone.Text & "', Physician_Fax_Number='" & mtbFax.Text & "', Physician_Address='" & strAddress & "', Physician_City='" & strCity & "', Physician_State='" & cboState.SelectedItem & "', Physician_Zip_Code='" & txtZipCode.Text & "',Active_Flag=1 WHERE Physician_ID='" & txtID.Text & "';"
            ExecuteInsertQuery(strStatement)



            'clear all text boxes and change button visibility back to default 
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtMiddleName.Text = ""
            txtAddress.Text = ""
            txtCity.Text = ""
            txtZipCode.Text = ""
            btnCancel.Visible = False
            btnSaveChanges.Visible = False
            btnSave.Visible = True
            mtbFax.Text = ""
            mtbPhone.Text = ""
            cboCredentials.SelectedItem = Nothing
            cboState.SelectedItem = Nothing
        End If


        SortItems()
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
    '/*  Dylan Walter    4/6/2021    copied to frmEditPhysician           */
    '/*********************************************************************/

    Private Sub RemoveHandlersAndAssociations(ByVal lstOfControlsToRemove As List(Of Control), flpFlowPanel As FlowLayoutPanel)

        Dim ctlControlObject As Control
        Const PANELWITHASSIGNEDHANDLERS As String = "pnlIndividualPhysicianRecord"
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
    '/*  Dylan Walter    4/6/2021    copied to frmEditPhysician           */
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
    Public Sub Fill_Table(ByVal strFillSQL As String)

        ' remove all controls and the handlers of those controls before generating new panels
        RemoveHandlersAndAssociations(GetListOfAllControls(flpPhysicianInfo), flpPhysicianInfo)

        Dim dsPhysicianInfo As DataSet = CreateDatabase.ExecuteSelectQuery(strFillSQL)



        For Each item As DataRow In dsPhysicianInfo.Tables(0).Rows()
            With dsPhysicianInfo.Tables(0)
                'grab first name and last name and merge into one string
                Dim strFirst As String = item.Item(1)
                Dim strLast As String = item.Item(3)
                Dim strName = strFirst & " " & strLast
                Dim strActive As String = ""

                If (item.Item(11)) = "1" Then
                    strActive = "Yes"
                Else strActive = "No"
                End If
                Dim strRole As String = item.Item(4)

                'populate data into panels
                CreatePanel_Physician(flpPhysicianInfo, item.Item(0), strName,
                               strRole, strActive)

            End With
        Next
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click

        txtFirstName.Text = Nothing
        txtLastName.Text = Nothing
        txtMiddleName.Text = Nothing
        mtbPhone.Text = Nothing
        mtbFax.Text = Nothing
        txtAddress.Text = Nothing
        txtCity.Text = Nothing
        txtZipCode.Text = Nothing
        txtID.Text = Nothing
        btnCancel.Visible = False
        btnSaveChanges.Visible = False
        btnSave.Visible = True
        cboCredentials.SelectedIndex = 0
        cboCredentials.Text = Nothing
        cboState.SelectedIndex = 0
        cboState.Text = Nothing
        lblTitle.Text = "Create New Physician"

    End Sub


    Private Sub Search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            SortItems()
        End If
    End Sub

    Private Sub pnlSearchIcon_Click(sender As Object, e As EventArgs) Handles pnlSearchIcon.Click

        SortItems()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBox.TextChanged
        If txtSearchBox.Text = "" Then
            SortItems()
        End If
    End Sub

    Private Sub lblName_Click(sender As Object, e As EventArgs) Handles lblName.Click
        If strSort <> "Physician_First_Name COLLATE NOCASE ASC;" Then
            strSort = "Physician_First_Name COLLATE NOCASE ASC;"
        Else strSort = "Physician_First_Name COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblPermissions_Click(sender As Object, e As EventArgs) Handles lblPermissions.Click
        If strSort <> "Physician_Credentials COLLATE NOCASE ASC;" Then
            strSort = "Physician_Credentials COLLATE NOCASE ASC;"
        Else strSort = "Physician_Credentials COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblStatus_Click(sender As Object, e As EventArgs) Handles lblStatus.Click
        If strSort <> "Active_Flag COLLATE NOCASE DESC;" Then
            strSort = "Active_Flag COLLATE NOCASE DESC;"
        Else strSort = "Active_Flag COLLATE NOCASE ASC;"
        End If
        SortItems()
    End Sub

    Sub SortItems()

        Dim strFillSQL As String
        Dim strSearch = txtSearchBox.Text
        'when the user searches change the single comma to allow searching
        strSearch = Regex.Replace(strSearch, "'", "''")
        If txtSearchBox.Text = "" Then

            strFillSQL = "select Physician.Physician_ID, Physician.Physician_First_Name, Physician.Physician_Middle_Name," &
                                    "Physician.Physician_Last_Name, Physician.Physician_Credentials, Physician.Physician_Phone_Number," &
                                    "Physician.Physician_Fax_Number, Physician.Physician_Address, Physician.Physician_City," &
                                    "Physician.Physician_State, Physician.Physician_Zip_Code, Physician.Active_Flag From Physician ORDER BY " & strSort
        Else
            strFillSQL = "select Physician.Physician_ID, Physician.Physician_First_Name, Physician.Physician_Middle_Name," &
                                    "Physician.Physician_Last_Name, Physician.Physician_Credentials, Physician.Physician_Phone_Number," &
                                    "Physician.Physician_Fax_Number, Physician.Physician_Address, Physician.Physician_City," &
                                    "Physician.Physician_State, Physician.Physician_Zip_Code, Physician.Active_Flag From Physician " &
                                    "WHERE Physician_First_Name LIKE '" & strSearch & "%' Or Physician_Last_Name LIKE '" & strSearch & "%' Or Physician_Credentials LIKE '" & strSearch & "%' ORDER BY " & strSort
        End If
        Fill_Table(strFillSQL)
    End Sub
End Class
