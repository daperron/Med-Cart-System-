Imports System.Text.RegularExpressions

Public Class frmMyPatients
    Dim strSort As String
    Private Sub frmMyPatients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'rdbShowAll.Checked = True
        ' LoadPanel()

        'CreatePanelMyPatients(flpMyPatientRecords, "test", "test", "test", "11/11/1998", "test", "test", 12)
        'CreatePanelMyPatients(flpMyPatientRecords, "test", "test", "test", "11/11/1998", "test", "test", 12)
        'CreatePanelMyPatients(flpMyPatientRecords, "test", "test", "test", "11/11/1998", "test", "test", 12)


        ' select the my patients item from the cbobox by default
        cboFilter.SelectedIndex = 0
        AddHandlerToLabelClick(pnlHeader, AddressOf frmPatientRecords.SortBySelectedLabel)
        strSort = "Patient.Patient_Last_Name COLLATE NOCASE, Patient.Patient_First_Name COLLATE NOCASE ASC;"
        'HideButtonOnPanels()
        ' AddHandlersLaterForRunTimePerformance()
    End Sub
    Private Sub LoadPanel()



    End Sub

    Private Sub rdbOnlyActive_CheckedChanged(sender As Object, e As EventArgs)
        flpMyPatientRecords.Controls.Clear()
        '  LoadPanel()
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
    '/*                                                                   */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/* flpPannel- the flow panel which the user wants to create the      */
    '/*     create the single panel.                                      */
    '/* strMRN- value from the database we will display                   */
    '/* strFirstName- Name of the user in the database                    */
    '/* strLastName- Last Name of the user in the database                */
    '/* strBirthday- DOB of the user in the database                      */
    '/* strRoom- room of the user in the database                         */
    '/* strBed- bed of the user in the database                           */
    '/* intPatietnID- the ID of the patient that is being added           */
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
    '/* lblID4 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/* lblID5 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/* lblID6 - a new label that is used to contain the string passed in */
    '/*     to the sub routine.                                           */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/6/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreatePanelActivePatients(ByVal flpPannel As FlowLayoutPanel, ByVal strMRN As String, ByVal strFirstName As String, ByVal strLastName As String, ByVal strBirthday As String, ByVal strRoom As String, ByVal strBed As String, ByRef intPatientID As Integer)
        Dim dsPatientUserAssigned As DataSet
        Dim userID = LoggedInID
        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(1030, 47)
            .Name = "pnlIndividualPatientRecordPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(1050, 45)
            .Name = "pnlIndividualPatientRecord" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
        End With

        'put the boarder panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        AddHandler pnlMainPanel.Click, AddressOf frmPatientRecords.DynamicSingleClickOpenPatient
        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault

        ' add controls to this panel

        Dim lblID1 As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label
        Dim lblID5 As New Label
        Dim lblID6 As New Label

        Const YCOORDINATE As Integer = 20
        ' CreateCheckBox(pnlMainPanel, getPanelCount(flpPannel), lblMRN.Location.X - 45, 5)

        Dim strSQL As String = "SELECT COUNT() FROM PatientUser WHERE Patient_TUID= '" & intPatientID & "'" & " AND  User_TUID= '" & userID & "' AND  Active_Flag = '1'"

        If ExecuteScalarQuery(strSQL) = 0 Then
            CreateAddButton(pnlMainPanel, getPanelCount(flpPannel), lblAssignment.Location.X + 15, 5, intPatientID)
        Else
            CreateRemoveButton(pnlMainPanel, getPanelCount(flpPannel), lblAssignment.Location.X + 15, 5, intPatientID)
        End If


        'CreateAddButton(pnlMainPanel, getPanelCount(flpPannel), lblAssignment.Location.X + 15, 5, intPatientID)
        CreateIDLabelWithToolTip(pnlMainPanel, lblID1, "lblMRN", lblMRN.Location.X, YCOORDINATE, strMRN, getPanelCount(flpPannel), tpToolTip, TruncateString(15, strMRN))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID2, "lblFirstName", lblFirstName.Location.X, YCOORDINATE, strFirstName, getPanelCount(flpPannel), tpToolTip, TruncateString(15, strFirstName))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID3, "lblLastName", lblLastName.Location.X, YCOORDINATE, strLastName, getPanelCount(flpPannel), tpToolTip, TruncateString(15, strLastName))
        CreateIDLabel(pnlMainPanel, lblID4, "lblBirthday", lblDOB.Location.X, YCOORDINATE, strBirthday, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID5, "lblRoom", lblRoom.Location.X, YCOORDINATE, strRoom, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID6, "lblBed", lblBed.Location.X, YCOORDINATE, strBed, getPanelCount(flpPannel))

        'Add panel to flow layout panel
        'pnlMainPanel.Tag = intPatientID
        flpPannel.Controls.Add(pnl)
        pnlMainPanel.Tag = intPatientID


        lblID1.Tag = intPatientID
        lblID2.Tag = intPatientID
        lblID3.Tag = intPatientID
        lblID4.Tag = intPatientID
        lblID5.Tag = intPatientID
        lblID6.Tag = intPatientID
    End Sub

    '/********************************************************************/
    '/*            SUB NAME: AddHandlersLaterForRunTimePerformance	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose: This sub adds handlers to the labels at form load  */
    '/*  that allow the user to click the labels and load the next form  */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: DynamicSingleClickOpenPatient   	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	                                                                 */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	DynamicSingleClickOpenPatient()					                 */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		4/3/21		 initial creation                            */
    '/********************************************************************/ 
    Public Sub AddHandlersLaterForRunTimePerformance()

        Dim ctl As Control
        Dim pnlPadding As Control
        Dim pnlMain As Control

        For Each ctl In flpMyPatientRecords.Controls
            For Each pnlPadding In ctl.Controls
                For Each pnlMain In pnlPadding.Controls
                    If pnlMain.Name.Contains("lbl") Then
                        AddHandler pnlMain.Click, AddressOf frmPatientRecords.DynamicSingleClickOpenPatient
                    End If
                Next
            Next
        Next

    End Sub
    '/********************************************************************/
    '/*                   SUB NAME: CreateAddButton             	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub creates a button at run time to be aded to  /
    '/*  the form.                                                       */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: (none)                             	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 pnlpanelName- name of the panel to add the control to           */	 
    '/*  intPanelsAddedCount- current number of panels added on the form */	 
    '/*  intX- x coordinate of where to place the control                */	 
    '/*  intY- Y coordinate of where to place the control                */	 
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	DynamicSingleClickOpenPatient()					                 */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 

    Private Sub CreateAddButton(ByVal pnlPanelName As Panel, ByVal intPanelsAddedCount As Integer, ByVal intX As Integer, ByVal intY As Integer, ByVal intPatientID As Integer)

        Dim btnAddButton As Button
        btnAddButton = New Button
        'declare our image and point at the resource
        Dim mapImagePencil As New Bitmap(New Bitmap(My.Resources.add_icon1), 20, 20)

        'Set button properties
        With btnAddButton
            .AutoSize = True
            .Size = New Size(30, 30)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Transparent
            ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
            '.Location = New Point(825, 5)
            .Location = New Point(intX, intY)
            .Name = "btnAddbutton" + intPanelsAddedCount.ToString
            .Image = mapImagePencil
            .ImageAlign = ContentAlignment.MiddleCenter
            .Tag = intPatientID
            '   .Visible = False

        End With

        Debug.Print(pnlPanelName.Name)
        pnlPanelName.Controls.Add(btnAddButton)
        ' MessageBox.Show("again")
        'Add handler for click events
        AddHandler btnAddButton.Click, AddressOf btnAddAssignment_Click
    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: CreateRemoveButton             	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub creates a button at run time to be aded to  /
    '/*  the form.                                                       */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: (none)                             	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 pnlpanelName- name of the panel to add the control to           */	 
    '/*  intPanelsAddedCount- current number of panels added on the form */	 
    '/*  intX- x coordinate of where to place the control                */	 
    '/*  intY- Y coordinate of where to place the control                */	 
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	DynamicSingleClickOpenPatient()					                 */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub CreateRemoveButton(ByVal pnlPanelName As Panel, ByVal pnlPanelsAddedCount As Integer, ByVal intX As Integer, ByVal intY As Integer, ByVal intPatientID As Integer)

        Dim btnRemove As Button
        btnRemove = New Button
        'declare our image and point at the resource
        Dim mapImagePencil As New Bitmap(New Bitmap(My.Resources.minus_icon1), 20, 20)

        'Set button properties
        With btnRemove
            .AutoSize = True
            .Size = New Size(30, 30)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Transparent
            ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
            '.Location = New Point(825, 5)
            .Location = New Point(intX, intY)
            .Name = "btnRemove" + (pnlPanelsAddedCount).ToString
            .Image = mapImagePencil
            .ImageAlign = ContentAlignment.MiddleCenter
            .Tag = intPatientID
            '  .Visible = False
        End With

        Debug.Print(pnlPanelName.Name)
        pnlPanelName.Controls.Add(btnRemove)
        ' MessageBox.Show("again")
        'Add handler for click events
        AddHandler btnRemove.Click, AddressOf RemoveAssignment_Click

    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: RemoveAssignment_Click      	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub is the handler that is called when the remove
    '/*  button is clicked                                               */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing a control                           */
    '/*  e- eventargs indicating there is an event handle assigned       */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                 */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub RemoveAssignment_Click(ByVal sender As Object, e As EventArgs)
        Dim User_ID As Integer = LoggedInID

        Dim patientIDFromSelectedRecord As Integer = CInt(sender.tag)
        MessageBox.Show("Patient unassigned to you")


        ExecuteInsertQuery("UPDATE PatientUser SET Active_Flag = 0 WHERE Patient_TUID =" & patientIDFromSelectedRecord.ToString & " AND User_TUID =" & User_ID.ToString & " ;")
        If cboFilter.SelectedIndex = 0 Then


            RemoveOnScreenPanel(sender)
        Else
            LoadAllActivePatients("Select MRN_Number, Patient_First_Name, Patient_Last_Name, Date_of_Birth, Primary_Physician_ID, Patient.Patient_ID, PatientRoom.Patient_TUID, Room_TUID, Bed_Name FROM Patient LEFT JOIN PatientRoom ON PatientRoom.Patient_TUID = Patient.Patient_ID Where Patient.Active_Flag= 1 ;")
        End If

    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: btnAddAssignment_Click      	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub is the handler that is called when the remove
    '/*  button is clicked                                               */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing a control                           */
    '/*  e- eventargs indicating there is an event handle assigned       */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                 */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub btnAddAssignment_Click(ByVal sender As Object, e As EventArgs)
        Dim UserID As Integer = LoggedInID
        'default values to populate the table with
        Dim intActive_Flag As String = "1"
        Dim strVisitDate As String = "10/10/2021" 'might need to be system time
        Dim patientIDFromSelectedRecord As Integer = CInt(sender.tag) 'patient id from the user they clickec on, should be the tag of the add button
        Dim dsPatientUser As DataSet
        dsPatientUser = ExecuteSelectQuery("Select * From PatientUser")
        Dim intActiveFlag As Integer = 1
        For Each row As DataRow In dsPatientUser.Tables(0).Rows
            If CInt(row(0)) = patientIDFromSelectedRecord And CInt(row(1)) = UserID Then
                intActiveFlag = CInt(row(3))
            End If
        Next
        If intActiveFlag = 0 Then
            ExecuteInsertQuery("UPDATE PatientUser SET Active_Flag = 1 WHERE Patient_TUID =" & patientIDFromSelectedRecord.ToString & " AND User_TUID =" & UserID.ToString & " ;")
            'ElseIf intActiveFlag = 1 Then 'if they get to here they are already assigned to someone else so i will just change the user_ID


        Else

            ExecuteInsertQuery("INSERT INTO PatientUser ('Patient_TUID','User_TUID','Visit_Date','Active_Flag') VALUES ('" & patientIDFromSelectedRecord.ToString & "','" & UserID.ToString & "','" & strVisitDate & "','" & intActive_Flag.ToString & "' );")

        End If


        MessageBox.Show("Patient assigned to you")
        If cboFilter.SelectedIndex = 0 Then


            RemoveOnScreenPanel(sender)
        Else
            LoadAllActivePatients("Select MRN_Number, Patient_First_Name, Patient_Last_Name, Date_of_Birth, Primary_Physician_ID, Patient.Patient_ID, PatientRoom.Patient_TUID, Room_TUID, Bed_Name FROM Patient LEFT JOIN PatientRoom ON PatientRoom.Patient_TUID = Patient.Patient_ID Where Patient.Active_Flag= 1 ;")
        End If
    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: cboFilter_SelectedIndexChanged       */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub determines the current item selected       */
    '/* in the combobox and then calls the necessary method accordingly. */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing a control                           */
    '/*  e- eventargs indicating there is an event handle assigned       */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub cboFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilter.SelectedIndexChanged
        Dim UserID As Integer = LoggedInID
        Dim strUserFirst As String = ""
        Dim strUserLast As String = ""
        Dim strVisitDate As String = ""
        Dim intPhysicianID As Integer = 0
        Dim intPatientID As Integer = 0
        Dim intPatientMRN As Integer = 0
        Dim strPatientFirst As String = ""
        Dim strPatientLast As String = ""
        Dim StrDOB As String = ""
        Dim strRoom As String = ""
        Dim strBed As String = ""
        Dim intActive_Flag As String = ""
        'my patients
        If cboFilter.SelectedIndex = 0 Then
            '******************* 
            flpMyPatientRecords.Controls.Clear()

            ' ADAM call this before calling a create panel method to show the new items
            Dim strSQLCode As String = "Select * from Patient
                Inner JOIN PatientUser on PatientUser.Patient_TUID = Patient.Patient_ID
                Inner Join PatientRoom on PatientRoom.Patient_TUID = Patient.Patient_ID
                Where PatientUser.User_TUID = '" & LoggedInID.ToString & "' AND PatientUser.Active_Flag = '1' AND Patient.Active_Flag = '1' AND PatientRoom.Active_Flag = '1' ORDER BY Patient.Patient_Last_Name"
            LoadMyPatients(strSQLCode)

            ShowAllControlsOnPanels()
            HideControlOnPanels("btnAdd")
            lblAssignment.Text = "Remove Assignment"
            AddHandlersLaterForRunTimePerformance()
            'ElseIf cboFilter.SelectedIndex = 1 Then
            '    '******************* 
            '    flpMyPatientRecords.Controls.Clear()
            '    ' ADAM call this before calling a create panel method to show the new items

            '    LoadAllPatients()
            '    ShowAllControlsOnPanels()
            '    HideControlOnPanels("btnRemove")
            '    lblAssignment.Text = "Assign Patient To Me"

            'ElseIf cboFilter.SelectedIndex = 2 Then


            '    '******************* 
            '    flpMyPatientRecords.Controls.Clear()
            '    ' ADAM call this before calling a create panel method to show the new items
            '    LoadAllPatientUser()

            '    ShowAllControlsOnPanels()
            '    HideControlOnPanels("btnRemove")
            '    lblAssignment.Text = "Assign Patient To Me"

        ElseIf cboFilter.SelectedIndex = 1 Then
            '******************* 
            flpMyPatientRecords.Controls.Clear()
            ' ADAM call this before calling a create panel method to show the new items

            LoadAllActivePatients("Select MRN_Number, Patient_First_Name, Patient_Last_Name, Date_of_Birth, Primary_Physician_ID, Patient.Patient_ID, PatientRoom.Patient_TUID, Room_TUID, Bed_Name FROM Patient LEFT JOIN PatientRoom ON PatientRoom.Patient_TUID = Patient.Patient_ID Where Patient.Active_Flag= 1 ;")
            ShowAllControlsOnPanels()
            'HideControlOnPanels("btnRemove")
            lblAssignment.Text = "Assign Patient To Me"
            AddHandlersLaterForRunTimePerformance()
            'ElseIf cboFilter.SelectedIndex = 2 Then

        End If

    End Sub
    '/********************************************************************/
    '/*                   SUB NAME: cboFilter_SelectedIndexChanged       */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub determines the current item selected       */
    '/* in the combobox and then calls the necessary method accordingly. */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing a control                           */
    '/*  e- eventargs indicating there is an event handle assigned       */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub LoadAllActivePatients(ByRef strSQLCode As String)
        ' remove all controls and the handlers of those controls before generating new panels
        RemoveHandlersAndAssociations(GetListOfAllControls(flpMyPatientRecords), flpMyPatientRecords)
        Dim dsPatient As DataSet
        Dim dsPatientUserAssigned As DataSet
        Dim UserID As Integer = LoggedInID
        Dim strUserFirst As String = ""
        Dim strUserLast As String = ""
        Dim strVisitDate As String = ""
        Dim intPhysicianID As Integer = 0
        Dim intPatientID As Integer = 0
        Dim intPatientMRN As Long = 0
        Dim strPatientFirst As String = ""
        Dim strPatientLast As String = ""
        Dim StrDOB As String = ""
        Dim strRoom As String = ""
        Dim strBed As String = ""
        Dim intActive_Flag As String = ""

        dsPatient = CreateDatabase.ExecuteSelectQuery(strSQLCode)

        For Each Patient As DataRow In dsPatient.Tables(0).Rows
            intPatientMRN = Patient(0)
            strPatientFirst = Patient(1)
            strPatientLast = Patient(2)
            StrDOB = Patient(3)
            intPhysicianID = Patient(4)
            intPatientID = Patient(5)
            strRoom = Patient(7)
            strBed = Patient(8)
            'StrDOB = StrDOB.Substring(0, 9)
            Debug.WriteLine("")


            'if userpatient contains patient then 
            'CreatePanelMyPatients(flpMyPatientRecords, intPatientMRN.ToString, strPatientFirst, strPatientLast, StrDOB, strRoom, strBed, intPatientID)
            'else
            CreatePanelActivePatients(flpMyPatientRecords, intPatientMRN.ToString, strPatientFirst, strPatientLast, StrDOB, strRoom, strBed, intPatientID)
        Next

        'dsPatientUserAssigned = CreateDatabase.ExecuteSelectQuery("Select * From PatientUser Where User_TUID=" & UserID & ";")

    End Sub
    '/********************************************************************/
    '/*                   SUB NAME: cboFilter_SelectedIndexChanged       */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub determines the current item selected       */
    '/* in the combobox and then calls the necessary method accordingly. */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing a control                           */
    '/*  e- eventargs indicating there is an event handle assigned       */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    'Private Sub LoadAllPatients()
    '    Dim dsPatient As DataSet
    '    Dim UserID As Integer = 9
    '    Dim strUserFirst As String = ""
    '    Dim strUserLast As String = ""
    '    Dim strVisitDate As String = ""
    '    Dim intPhysicianID As Integer = 0
    '    Dim intPatientID As Integer = 0
    '    Dim intPatientMRN As Long = 0
    '    Dim strPatientFirst As String = ""
    '    Dim strPatientLast As String = ""
    '    Dim StrDOB As String = ""
    '    Dim strRoom As String = ""
    '    Dim strBed As String = ""
    '    Dim intActive_Flag As String = ""

    '    dsPatient = CreateDatabase.ExecuteSelectQuery("Select MRN_Number, Patient_First_Name, Patient_Last_Name, Date_of_Birth, Primary_Physician_ID, Patient.Patient_ID, PatientRoom.Patient_TUID, Room_TUID, Bed_Name FROM Patient LEFT JOIN PatientRoom ON PatientRoom.Patient_TUID = Patient.Patient_ID ;")
    '    For Each Patient As DataRow In dsPatient.Tables(0).Rows
    '        intPatientMRN = Patient(0)
    '        strPatientFirst = Patient(1)
    '        strPatientLast = Patient(2)
    '        StrDOB = Patient(3)
    '        intPhysicianID = Patient(4)
    '        intPatientID = Patient(5)
    '        strRoom = Patient(7)
    '        strBed = Patient(8)
    '        'StrDOB = StrDOB.Substring(0, 9)
    '        Debug.WriteLine("")
    '        CreatePanelMyPatients(flpMyPatientRecords, intPatientMRN.ToString, strPatientFirst, strPatientLast, StrDOB, strRoom, strBed, intPatientID)
    '    Next

    'End Sub
    '/********************************************************************/
    '/*                   SUB NAME: cboFilter_SelectedIndexChanged       */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub determines the current item selected       */
    '/* in the combobox and then calls the necessary method accordingly. */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing a control                           */
    '/*  e- eventargs indicating there is an event handle assigned       */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub LoadMyPatients(ByRef strSQLCode As String)
        ' remove all controls and the handlers of those controls before generating new panels
        RemoveHandlersAndAssociations(GetListOfAllControls(flpMyPatientRecords), flpMyPatientRecords)
        Dim dsPatientUser As DataSet
        'Dim dsPatientUserAssigned As DataSet
        'Dim dsPatient As DataSet
        Dim UserID As Integer = LoggedInID
        Dim strUserFirst As String = ""
        Dim strUserLast As String = ""
        Dim strVisitDate As String = ""
        Dim intPhysicianID As Integer = 0
        Dim intPatientID As Integer = 0
        Dim intPatientMRN As Double = 0
        Dim strPatientFirst As String = ""
        Dim strPatientLast As String = ""
        Dim StrDOB As String = ""
        Dim strRoom As String = ""
        Dim strBed As String = ""
        Dim intActive_Flag As String = ""

        'Sorting_MyPatients_Fix_Physicians
        dsPatientUser = CreateDatabase.ExecuteSelectQuery(strSQLCode)


        For Each dr As DataRow In dsPatientUser.Tables(0).Rows
            intPatientID = dr(0)
            strVisitDate = dr(20)
            intPatientMRN = dr(1)
            strPatientFirst = dr(3)
            strPatientLast = dr(5)
            StrDOB = dr(6)
            intPhysicianID = dr(16)
            strRoom = dr(23)
            strBed = dr(24)
            CreatePanelActivePatients(flpMyPatientRecords, intPatientMRN.ToString, strPatientFirst, strPatientLast, StrDOB, strRoom, strBed, intPatientID)
        Next

    End Sub
    '/********************************************************************/
    '/*                   SUB NAME: cboFilter_SelectedIndexChanged       */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub determines the current item selected       */
    '/* in the combobox and then calls the necessary method accordingly. */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing a control                           */
    '/*  e- eventargs indicating there is an event handle assigned       */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 none                           				                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    'Private Sub LoadAllPatientUser()
    '    Dim dsPatientUser As DataSet
    '    Dim dsPatientUserAssigned As DataSet
    '    Dim dsPatient As DataSet
    '    Dim UserID As Integer = 9
    '    Dim strUserFirst As String = ""
    '    Dim strUserLast As String = ""
    '    Dim strVisitDate As String = ""
    '    Dim intPhysicianID As Integer = 0
    '    Dim intPatientID As Integer = 0
    '    Dim intPatientMRN As Integer = 0
    '    Dim strPatientFirst As String = ""
    '    Dim strPatientLast As String = ""
    '    Dim StrDOB As String = ""
    '    Dim strRoom As String = ""
    '    Dim strBed As String = ""
    '    Dim intActive_Flag As String = ""
    '    dsPatientUser = CreateDatabase.ExecuteSelectQuery("Select * From PatientUser ;")
    '    dsPatientUserAssigned = CreateDatabase.ExecuteSelectQuery("Select * From PatientUser Where User_TUID=" & UserID & ";")
    '    For Each row As DataRow In dsPatientUser.Tables(0).Rows
    '        intPatientID = row(0)
    '        strVisitDate = row(2)
    '        dsPatient = CreateDatabase.ExecuteSelectQuery("Select MRN_Number, Patient_First_Name, Patient_Last_Name, Date_of_Birth, Primary_Physician_ID, Patient.Patient_ID, PatientRoom.Patient_TUID, Room_TUID, Bed_Name FROM Patient LEFT JOIN PatientRoom ON PatientRoom.Patient_TUID = Patient.Patient_ID Where Patient_ID =" & intPatientID.ToString() & ";")
    '        For Each Patient As DataRow In dsPatient.Tables(0).Rows
    '            intPatientMRN = Patient(0)
    '            strPatientFirst = Patient(1)
    '            strPatientLast = Patient(2)
    '            StrDOB = Patient(3)
    '            intPhysicianID = Patient(4)
    '            intPatientID = Patient(5)
    '            strRoom = Patient(7)
    '            strBed = Patient(8)
    '            'StrDOB = StrDOB.Substring(0, 9)
    '            Debug.WriteLine("")
    '            CreatePanelMyPatients(flpMyPatientRecords, intPatientMRN.ToString, strPatientFirst, strPatientLast, StrDOB, strRoom, strBed, intPatientID)
    '        Next

    '        Debug.WriteLine("")

    '    Next

    'End Sub

    '/********************************************************************/
    '/*                   SUB NAME: HideControlOnPanels                  */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub iterates over the flow panel and modifies  */
    '/*  controls within. It hides the button containing the name passed in
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 nameOfControlToHide- string of the control name we want to hide.*/
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 paddingPanel- represents the padding panel                      */
    '/*	 panelWithControls- represents the panel containing the buttons  */
    '/*	 controlOnPanel- represents the single control on the panel      */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub HideControlOnPanels(ByVal nameOfControlToHide As String)

        Dim paddingPanel As Control
        Dim panelWithControls As Control
        Dim controlOnPanel As Control
        ' Dim control As Control

        For Each paddingPanel In flpMyPatientRecords.Controls
            For Each panelWithControls In paddingPanel.Controls
                For Each controlOnPanel In panelWithControls.Controls

                    ' hide the specific control we need to
                    If controlOnPanel.Name.Contains(nameOfControlToHide) Then

                        controlOnPanel.Visible = False

                    End If
                    ' Debug.Print(controlOnPanel.Name)
                Next
            Next
        Next



    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: ShowAllControlsOnPanels              */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub iterates over the flow panel and modifies  */
    '/*  controls within. It hides the button containing the name passed in
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 (NONE)                                                          */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 paddingPanel- represents the padding panel                      */
    '/*	 panelWithControls- represents the panel containing the buttons  */
    '/*	 controlOnPanel- represents the single control on the panel      */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub ShowAllControlsOnPanels()

        Dim paddingPanel As Control
        Dim panelWithControls As Control
        Dim controlOnPanel As Control
        ' Dim control As Control

        For Each paddingPanel In flpMyPatientRecords.Controls
            For Each panelWithControls In paddingPanel.Controls
                For Each controlOnPanel In panelWithControls.Controls

                    ' hide the specific control we need to

                    controlOnPanel.Visible = True


                    ' Debug.Print(controlOnPanel.Name)


                Next
            Next
        Next

    End Sub


    '/********************************************************************/
    '/*                   SUB NAME: RemoveOnScreenPanel                  */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This destroys the panel that sender (a control) lives
    '/*  within                                                          */
    '/********************************************************************/
    '/*  CALLED BY:    	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 (NONE)                                                          */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*				                                                      */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */

    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		2/6/21		 initial creation                            */
    '/********************************************************************/ 
    Public Sub RemoveOnScreenPanel(ByVal sender As Object)
        Dim ctlControl As Control = sender.Parent
        Dim ctlParents As Control = ctlControl.Parent

        Dim ctlParentFlowPanel As Control = ctlControl.Parent
        Dim strParentPanelName As String
        strParentPanelName = Nothing

        'Remove handler from sender
        For Each ctlObject As Control In ctlParentFlowPanel.Controls
            For Each ctlChildControlObj As Control In ctlObject.Controls
                If ctlChildControlObj.Name = sender.name Then

                    RemoveHandler ctlChildControlObj.Click, AddressOf DynamicButton_Click

                    strParentPanelName = ctlChildControlObj.Parent.Name
                End If
            Next
        Next

        'Remove  panel
        For Each ctlObject As Control In ctlParentFlowPanel.Controls
            If ctlObject.Name = strParentPanelName Then

                ' prompt user if they are sure they want to delete the record
                ' remove the record from the database
                'remove the padding panel from the flow panel
                ctlParentFlowPanel.Controls.Remove(ctlObject.Parent)
                ctlObject.Parent.Dispose()

                'remove the panel from the flow panel
                ctlParentFlowPanel.Controls.Remove(ctlObject)
                ctlObject.Dispose()

            End If
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
    '/*  Dylan Walter    4/6/2021    copied to frmPatientRecords          */
    '/*********************************************************************/

    Private Sub RemoveHandlersAndAssociations(ByVal lstOfControlsToRemove As List(Of Control), flpFlowPanel As FlowLayoutPanel)

        Dim ctlControlObject As Control
        Const PANELWITHASSIGNEDHANDLERS As String = "pnlIndividualPatientRecord"
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
    '/*  Dylan Walter    4/6/2021    copied to frmPatientRecords          */
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

    Private Sub lblMRN_Click(sender As Object, e As EventArgs) Handles lblMRN.Click
        'sort by patient MRN number
        If strSort <> "Patient.MRN_Number COLLATE NOCASE ASC;" Then
            strSort = "Patient.MRN_Number COLLATE NOCASE ASC;"
        Else strSort = "Patient.MRN_Number COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblFirstName_Click(sender As Object, e As EventArgs) Handles lblFirstName.Click
        'sort by patient First name
        If strSort <> "Patient.Patient_First_Name COLLATE NOCASE ASC;" Then
            strSort = "Patient.Patient_First_Name COLLATE NOCASE ASC;"
        Else strSort = "Patient.Patient_First_Name COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblLastName_Click(sender As Object, e As EventArgs) Handles lblLastName.Click
        'sort by Patient Last Name
        If strSort <> "Patient.Patient_Last_Name COLLATE NOCASE ASC;" Then
            strSort = "Patient.Patient_Last_Name COLLATE NOCASE ASC;"
        Else strSort = "Patient.Patient_Last_Name COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblDOB_Click(sender As Object, e As EventArgs) Handles lblDOB.Click
        'sort by PatientDate of birth
        If strSort <> "Patient.Date_of_Birth ASC;" Then
            strSort = "Patient.Date_of_Birth ASC;"
        Else strSort = "Patient.Date_of_Birth DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblRoom_Click(sender As Object, e As EventArgs) Handles lblRoom.Click
        'sort by Patient room
        If strSort <> "patientroom.Room_TUID COLLATE NOCASE ASC;" Then
            strSort = "patientroom.Room_TUID COLLATE NOCASE ASC;"
        Else strSort = "patientroom.Room_TUID COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblBed_Click(sender As Object, e As EventArgs) Handles lblBed.Click
        'sort by Patient bed
        If strSort <> "patientroom.Bed_Name COLLATE NOCASE ASC;" Then
            strSort = "patientroom.Bed_Name COLLATE NOCASE ASC;"
        Else strSort = "patientroom.Bed_Name COLLATE NOCASE DESC;"
        End If
        SortItems()
    End Sub

    Sub SortItems()
        Dim strSQLCode As String
        Dim strSearch = txtSearch.Text
        'when the user searches change the single comma to allow searching
        strSearch = Regex.Replace(strSearch, "'", "''")
        If cboFilter.SelectedIndex = 0 Then
            If strSearch = "" Then
                strSQLCode = "Select * from Patient Inner JOIN PatientUser on PatientUser.Patient_TUID = Patient.Patient_ID " &
                             "Inner Join PatientRoom on PatientRoom.Patient_TUID = Patient.Patient_ID Where PatientUser.User_TUID = '" & LoggedInID.ToString & "'" &
                             "AND PatientUser.Active_Flag = '1' AND Patient.Active_Flag = '1' AND PatientRoom.Active_Flag = '1' ORDER BY " & strSort

                LoadMyPatients(strSQLCode)
            Else 'if the user is searching then reduce the results and also sort
                strSQLCode = "Select * from Patient Inner JOIN PatientUser on PatientUser.Patient_TUID = Patient.Patient_ID " &
                             "Inner Join PatientRoom on PatientRoom.Patient_TUID = Patient.Patient_ID Where PatientUser.User_TUID = '" & LoggedInID.ToString & "'" &
                             "AND PatientUser.Active_Flag = '1' AND Patient.Active_Flag = '1' AND PatientRoom.Active_Flag = '1' AND " &
                             "(Patient_First_Name Like '" & strSearch & "%' OR Patient_Last_Name Like '" & strSearch & "%'" &
                             " OR MRN_Number like '" & strSearch & "%') ORDER BY " & strSort
                LoadMyPatients(strSQLCode)
            End If
        Else
            If strSearch = "" Then
                strSQLCode = "Select MRN_Number, Patient_First_Name, Patient_Last_Name, Date_of_Birth, Primary_Physician_ID, Patient.Patient_ID, PatientRoom.Patient_TUID, " &
                "Room_TUID, Bed_Name FROM Patient LEFT JOIN PatientRoom ON PatientRoom.Patient_TUID = Patient.Patient_ID Where Patient.Active_Flag= 1 ORDER BY " & strSort
                LoadAllActivePatients(strSQLCode)
            Else 'if the user is searching then reduce the results and also sort
                strSQLCode = "Select MRN_Number, Patient_First_Name, Patient_Last_Name, Date_of_Birth, Primary_Physician_ID, Patient.Patient_ID, PatientRoom.Patient_TUID, " &
                "Room_TUID, Bed_Name FROM Patient LEFT JOIN PatientRoom ON PatientRoom.Patient_TUID = Patient.Patient_ID Where Patient.Active_Flag= 1 AND" &
                "(Patient_First_Name Like '" & strSearch & "%' OR Patient_Last_Name Like '" & strSearch & "%' OR MRN_Number like '" & strSearch & "%') ORDER BY " & strSort
                LoadAllActivePatients(strSQLCode)
            End If

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SortItems()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'if the text box is empty then reset the panels
        If txtSearch.Text = "" Then
            SortItems()

        End If
    End Sub

    Private Sub Search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        'when the user hits enter in the search text box then backspace the enter then run the search
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            SortItems()
        End If

    End Sub

    Private Sub txtSearchKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz '-1234567890!@#$%^&*()/.,<>=+")
    End Sub
End Class