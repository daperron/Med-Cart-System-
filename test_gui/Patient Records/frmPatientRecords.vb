Imports System.Text.RegularExpressions

Public Class frmPatientRecords
    Dim strSort As String
    Dim currentContactPanel As String = Nothing

    Public Enum PatientRecordsEnum

        MRN = 1
        FirstName = 2
        LastName = 3
        DOB = 4
        Room = 5
        Bed = 6

    End Enum

    'Private Sub btnNewPatient_Click_1(sender As Object, e As EventArgs) Handles btnNewPatient.Click

    '    frmMain.OpenChildForm(frmNewPatient)

    'End Sub
    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:   		         */   
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
    '/*											                          */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:							                      */             
    '/*											                          */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strBed	- this is going to hold the bed name if there is a value  */
    '/*     in the patientRoom database. If there isn't it will display as*/
    '/*     N/A
    '/*  strRoom - this is going to hold the room number if there is a value*/
    '/*     in the patientRomm database. If tehre isn't it will display as */
    '/*     N/A
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/4/2021 Created the SQL statements to pull back the       */
    '/*                 information needed for Patient Records Form.      */
    '/*                 Created variables strRoom and strBed              */
    '/* AB     2/8/2021 Changed looping code as there was a bug 
    '/*                 that it would only display the first patient multiple
    '/*                 times
    '/*********************************************************************/
    Private Sub frmPatientRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strFillSQL As String = ("select Patient.MRN_Number, Patient.Patient_First_Name, " &
                                           "Patient.Patient_Last_Name, Patient.Date_of_Birth, patientroom.Room_TUID, patientroom.Bed_Name, Patient.Patient_ID from Patient LEFT JOIN " &
                                           "PatientRoom on Patient.Patient_ID = PatientRoom.Patient_TUID where Patient.Active_Flag = 1 AND PatientRoom.Active_Flag = 1 ORDER BY Patient.Patient_Last_Name COLLATE NOCASE, Patient.Patient_First_Name COLLATE NOCASE ASC;")
        Fill_Patient_Table(strFillSQL)
        txtSearch.Text = txtSearch.Tag
        txtSearch.ForeColor = Color.Silver
        CreateToolTips(pnlHeader, tpHeaderSort)
        AddHandlerToLabelClick(pnlHeader, AddressOf SortBySelectedLabel)
        AddHandlersLaterForRunTimePerformance()
        strSort = "Patient.Patient_Last_Name COLLATE NOCASE, Patient.Patient_First_Name COLLATE NOCASE ASC;"
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
    Public Sub CreatePanel(ByVal flpPannel As FlowLayoutPanel, ByVal strMRN As String, ByVal strFirstName As String, ByVal strLastName As String, ByVal strBirthday As String, ByVal strRoom As String, ByVal strBed As String, ByRef intPatientID As Integer)

        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(920, 47)
            .Name = "pnlIndividualPatientRecordPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(920, 45)
            .Name = "pnlIndividualPatientRecord" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
        End With

        'put the boarder panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        AddHandler pnlMainPanel.Click, AddressOf DynamicSingleClickOpenPatient
        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault

        'add controls to this panel
        Dim lblID1 As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label
        Dim lblID5 As New Label
        Dim lblID6 As New Label

        'add click event to the labels and not just the panel
        AddHandler lblID1.Click, AddressOf DynamicSingleClickOpenPatient
        AddHandler lblID2.Click, AddressOf DynamicSingleClickOpenPatient
        AddHandler lblID3.Click, AddressOf DynamicSingleClickOpenPatient
        AddHandler lblID4.Click, AddressOf DynamicSingleClickOpenPatient
        AddHandler lblID5.Click, AddressOf DynamicSingleClickOpenPatient
        AddHandler lblID6.Click, AddressOf DynamicSingleClickOpenPatient

        Const YCOORDINATE As Integer = 20

        CreateIDLabelWithToolTip(pnlMainPanel, lblID1, "lblMRN", lblMRN.Location.X, YCOORDINATE, strMRN, getPanelCount(flpPannel), tpToolTip, TruncateString(15, strMRN))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID2, "lblFirstName", lblFirstName.Location.X, YCOORDINATE, strFirstName, getPanelCount(flpPannel), tpToolTip, TruncateString(15, strFirstName))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID3, "lblLastName", lblLastName.Location.X, YCOORDINATE, strLastName, getPanelCount(flpPannel), tpToolTip, TruncateString(15, strLastName))
        CreateIDLabel(pnlMainPanel, lblID4, "lblBirthday", lblDOB.Location.X, YCOORDINATE, strBirthday, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID5, "lblRoom", lblRoom.Location.X, YCOORDINATE, strRoom, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID6, "lblBed", lblBed.Location.X, YCOORDINATE, strBed, getPanelCount(flpPannel))

        'Add panel to flow layout panel
        flpPannel.Controls.Add(pnl)
        pnlMainPanel.Tag = intPatientID
        currentContactPanel = pnl.Name

        lblID1.Tag = intPatientID
        lblID2.Tag = intPatientID
        lblID3.Tag = intPatientID
        lblID4.Tag = intPatientID
        lblID5.Tag = intPatientID
        lblID6.Tag = intPatientID

    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: DynamicSingleClickOpenPatient	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:This sub creates the handler for when a panel is    */	
    '/* is clicked on by the user.
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: DynamicSingleClickOpenPatient   	      		     */				            
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
    Public Sub DynamicSingleClickOpenPatient(sender As Object, e As EventArgs)

        frmPatientInfo.setPatientID(sender.tag)
        ' open the patient record form of the matching patient
        frmMain.OpenChildForm(frmPatientInfo)

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

        For Each ctl In flpPatientRecords.Controls
            For Each pnlPadding In ctl.Controls
                For Each pnlMain In pnlPadding.Controls

                    AddHandler pnlMain.Click, AddressOf DynamicSingleClickOpenPatient

                Next
            Next
        Next

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: GetSelectedPatientMRN	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/6/21			                     */                             
    '/********************************************************************/
    '/*  FUNCTION PURPOSE: this function retrieves the the MRN of the	 */					            
    '/*	 patient selected by the user.					                 */					                       
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: DynamicSingleClickOpenPatient   	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- an object representing the control that was selected    */								                        
    '/*                                                                  */  
    '/********************************************************************/
    '/*  RETURNS:							                             */	                          
    '/*  intMRN- an integer that is the MRN number of the selected patient/								             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	GetSelectedPatientMRN(sender)					                 */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 ctl- a control object that is used to hold all of the controls  */
    '/*  that will be iterated over.					                 */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		       2/6/21		 initial creation                    */
    '/*  DP            3/9/21        updated to return Patient_ID        */
    '/********************************************************************/ 
    Function GetSelectedPatientMRN(sender As Object) As Integer

        Dim intPatientID As Integer = Nothing
        Dim ctl As Control

        ' iterating over the list of controls in the panel
        For Each ctl In sender.Controls

            ' the label containing the MRN number will always be called "lblMRN" with a number tacked on
            ' to represent what number panel it is in the row of created panels.
            ' simplying searching for the control that contains MRN will always yield the correct label.
            If ctl.Name.Contains("MRN") Then

                Debug.Print(ctl.Text)
                intPatientID = CInt(ctl.Text)
            End If
        Next
        'Get Patient ID using MRN where Active_Flag is = 1

        'SELECT Patient_ID from Patient WHERE MRN_Number = 247413140 AND Active_Flag = 1
        intPatientID = (ExecuteScalarQuery("SELECT Patient_ID from Patient WHERE MRN_Number = " & intPatientID & " AND Active_Flag = 1"))
        'returning the PatientID of the patient from the selected record
        Return intPatientID

    End Function

    '/*********************************************************************/
    '/* SubProgram NAME:txtSearchGotFocusEvent                            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/26/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This sets the behavior of when this control gets focus. We are   */
    '/*  trying to remove the dummy text when the user enters the field   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*           txtSearchGotFocusEvent                                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*                                       */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/16/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus

        SearchLogic.txtSearchGotFocusEvent(txtSearch)

    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:txtSearchLostFocusEvent                           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/26/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This sets the behavior of when this control loses focus. We will */
    '/* reset the text to the dummy text if it is empty, otherwise keep txt/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  txtSearchLostFocusEvent                                          */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*                                                                   */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/16/2021    Initial creation                    */
    '/*********************************************************************/

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus

        SearchLogic.txtSearchLostFocusEvent(txtSearch)

    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: SortBySelectedLabel            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/14/2021                        */                             
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
    '/*	field- integer equal to the tag value of the control*/
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/14/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub SortBySelectedLabel(sender As Object, e As EventArgs)

        Dim parent As Panel = sender.parent
        Dim field As Integer = CInt(sender.tag)

        BoldLabelToSortBy(sender, parent)

        'check If the user Is selecting a dispense history field to sort by
        If parent.Name = pnlHeader.Name Then

            PatientRecordsSelectedFields(field)

        End If


    End Sub

    Private Sub PatientRecordsSelectedFields(ByVal field As Integer)

        ' clear the controls as they will need to be rebuilt when sorting
        'flpPatientRecords.Controls.Clear()

        Select Case field

            Case PatientRecordsEnum.MRN

            Case PatientRecordsEnum.FirstName

            Case PatientRecordsEnum.LastName

            Case PatientRecordsEnum.DOB

            Case PatientRecordsEnum.Room

            Case PatientRecordsEnum.Bed

        End Select

    End Sub


    Private Sub Fill_Patient_Table(ByVal strFillSQL As String)
        ' remove all controls and the handlers of those controls before generating new panels
        RemoveHandlersAndAssociations(GetListOfAllControls(flpPatientRecords), flpPatientRecords)

        Dim dsPatientInfo As DataSet = CreateDatabase.ExecuteSelectQuery(strFillSQL)
        Dim strRoom As String
        Dim strBed As String


        For Each item As DataRow In dsPatientInfo.Tables(0).Rows()
            With dsPatientInfo.Tables(0)


                If IsDBNull(item.Item(4)) Then
                    strRoom = "N/A"
                Else
                    strRoom = item.Item(4).ToString
                End If

                If IsDBNull(item.Item(5)) Then
                    strBed = "N/A"
                Else
                    strBed = item.Item(5).ToString

                End If
                CreatePanel(flpPatientRecords, item.Item(0), item.Item(1),
                           item.Item(2), item.Item(3), strRoom, strBed, item.Item(6))

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


    '/*********************************************************************/
    '/*                   SubProgram NAME: btnSearch_Click               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 3/17/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the search button is clicked check the databse for users   */   
    '/*	  with Username, first name, last name similar to search text     */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS: Fill_Patient_Table(strFillSQL)                            */            
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
    '/*  Dylan W    3/17/2021    Initial creation                          */
    '/*********************************************************************/
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'when the user searches change the single comma to allow searching
        Dim strSearch = txtSearch.Text
        SortItems()
        If strSearch = "" Then
            txtSearch.Text = txtSearch.Tag
        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: txtSearch_TextChanged         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 3/17/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the search textbox is empty then fill panels                  */   
    '/*	                                                                */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	Fill_Patient_Table(strFillSQL)                            */            
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
    '/*  Dylan W    3/17/2021    Initial creation                          */
    '/*********************************************************************/
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        'if the text box is empty then reset the panels
        If txtSearch.Text = "" Then
            SortItems()

        End If



    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: Form1_KeyPress                */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter        		          */   
    '/*		         DATE CREATED: 		 3/17/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the searchbox has focus if the user hits enter then search  */   
    '/*	                                                                */   
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */                 
    '/*********************************************************************/
    '/*  CALLS:	Fill_Patient_Table(strFillSQL)                            */            
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
    '/*  Dylan W    3/17/2021    Initial creation                          */
    '/*********************************************************************/
    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
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

    Private Sub lblMRN_Click(sender As Object, e As EventArgs) Handles lblMRN.Click
        'sort by patient MRN number
        If strSort <> "Patient.MRN_Number ASC;" Then
            strSort = "Patient.MRN_Number ASC;"
        Else strSort = "Patient.MRN_Number DESC;"
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
        If strSort <> "patientroom.Room_TUID ASC;" Then
            strSort = "patientroom.Room_TUID ASC;"
        Else strSort = "patientroom.Room_TUID DESC;"
        End If
        SortItems()
    End Sub

    Private Sub lblBed_Click(sender As Object, e As EventArgs) Handles lblBed.Click
        'sort by Patient bed
        If strSort <> "patientroom.Bed_Name ASC;" Then
            strSort = "patientroom.Bed_Name ASC;"
        Else strSort = "patientroom.Bed_Name DESC;"
        End If
        SortItems()
    End Sub

    Sub SortItems()
        Dim strFillSQL As String
        Dim strSearch = txtSearch.Text
        'when the user searches change the single comma to allow searching
        strSearch = Regex.Replace(strSearch, "'", "''")
        'if the user is not searching then run the first part of the if statment
        If strSearch = "" Or strSearch = "Search Patients" Then
            strFillSQL = "select Patient.MRN_Number, Patient.Patient_First_Name, " &
                                   "Patient.Patient_Last_Name, Patient.Date_of_Birth, patientroom.Room_TUID, patientroom.Bed_Name, Patient.Patient_ID from Patient LEFT JOIN " &
                                   "PatientRoom on Patient.Patient_ID = PatientRoom.Patient_TUID where Patient.Active_Flag = 1 AND PatientRoom.Active_Flag = 1 ORDER BY " & strSort
        Else 'if the user is searching then reduce the results and also sort
            strFillSQL = "select Patient.MRN_Number, Patient.Patient_First_Name, " &
                                   "Patient.Patient_Last_Name, Patient.Date_of_Birth, patientroom.Room_TUID, patientroom.Bed_Name, Patient.Patient_ID from Patient LEFT JOIN " &
                                   "PatientRoom on Patient.Patient_ID = PatientRoom.Patient_TUID where Patient.Active_Flag =1 AND " &
                                   "(Patient_First_Name Like '" & strSearch & "%' OR Patient_Last_Name Like '" & strSearch & "%'" &
                                   "OR MRN_Number like '" & strSearch & "%') ORDER BY " & strSort
        End If
        Fill_Patient_Table(strFillSQL)

    End Sub
End Class