Public Class frmEndOfShift

    '/*******************************************************************/
    '/*                   FILE NAME:  frmEndOfShift.vb                  */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier  		            */
    '/*		         DATE CREATED: 2/5/2020         		            */
    '/*******************************************************************/
    '/*  Class PURPOSE:								                    */
    '/*											                        */
    '/*  Contains all of the functionality that occurs on this form     */
    '/*                                                                 */
    '/*******************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
    '/*                                                    (NONE)	    */
    '/*******************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                */
    '/*                          (NOTHING)					            */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:								                */
    '/*											                        */
    '/* the program will invoke this class when a user selects the      */
    '/* end of shift button in the sub menu.                            */
    '/*******************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                */
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
    '/*  WHO             WHEN        WHAT								*/
    '/*  Collin Krygier  2/5/2021    Initial creation                   */
    '/*******************************************************************/

    Enum TypesOfReports As Integer
        AllMedication
        Controlled
        ControlledNonNarcotic
        Narcotic
        NonNarcotic
    End Enum


    Dim ContactPanelsAddedCount As Integer = 0
    Dim CurrentContactPanelName As String = Nothing

    '/*********************************************************************/
    '/*                   SubProgram NAME: frmEndOfShift_Load()           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/13/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is routine is called at the time of the form loading        */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*   nothing                                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*   nothing                                       				  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/* sender As Object- represents a control object                     */
    '/* e As EventArgs- the event associated                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	frmEndOfShift_Load()                                              */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/13/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub frmEndOfShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not cmbFilter.SelectedIndex = -1 Then
            btnSave.Visible = True
        Else
            btnSave.Visible = False

        End If
        'Remove these once the SQL statements are corrected and updated.
        AddHandlerToLabelClick(pnlHeader, AddressOf SortBySelectedLabel)

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: CreatePanel()                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/5/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is routine is dynamically creates panels that are placed    */ 
    '/*	 inside of the flowpanel that is fixed on the form. The panels are*/
    '/*	 created here, assigned handlers, and the contents of the panels  */
    '/*	 are updated in this routine                                      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*   btnAllMedications, btnNonControlled, btnControlled              */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/* flpPannel- the flow panel which the user wants to create the      */
    '/*     create the single panel.                                      */
    '/* intMedicationTUID- value from the database we will store in the   */
    '/*     control during runtime to save on a backend query later when  */
    '/*     extracting data to send to the database.                      */
    '/* strMedicationName- name of the medication that is assigned to     */
    '/*     to some drawer and section in the cart.                       */
    '/* strDrawerNumber- the drawer number which the medication being     */
    '/*     sent to this method is stored in.                             */
    '/* strSection- the section which the medication being sent here is   */
    '/*     stored in.                                                    */
    '/* strSystemCount- the quantity of the drug that the system assumes  */
    '/*     should be in the drawer.                                      */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 CreatePanel(flpEndOfShiftCount, medTUID1, genName1, intNum1, intNum3, intNum5)   
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
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/5/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreatePanel(ByVal flpPannel As FlowLayoutPanel, ByVal intMedicationTUID As String, ByVal strMedicationName As String, ByVal strDrawerNumber As String, ByVal strSection As String, ByVal strSystemCount As String, ByRef intDrawerMEDID As Integer)

        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel
        ' call method here to get the count from the database and update the panel number so the next item is correct

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(flpEndOfShiftCount.Width - 25, 47)
            .Name = "pnlMedicationFlaggedPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        ' important to note that the .tag is going to contain the medication TUID for querying  purposes

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(flpEndOfShiftCount.Width - 25, 45)
            .Name = "pnlMedicationFlagged" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
            .Tag = intMedicationTUID & "," & strMedicationName & "," & strDrawerNumber & "," & strSection & "," & strSystemCount
        End With

        'put the border panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        'AddHandler pnlMainPanel.Click, AddressOf DynamicSingleClickOpenPatient
        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault

        'add controls to this panel
        CreateFlagBtn(pnlMainPanel, getPanelCount(flpPannel), lblActions.Location.X + 8, 5)
        CreateTextBox(pnlMainPanel, getPanelCount(flpPannel), lblCount.Location.X, 6)

        Dim lblID1 As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label

        ' anywhere we have quotes except for the label names, we can call our Database and get method
        'CreateIDLabel(pnlMainPanel, lblID1, "lblMedication", lblMedication.Location.X, 20, strMedicationName, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID1, "lblMedication", lblMedication.Location.X, 20, strMedicationName, getPanelCount(flpPannel), tpToolTip, TruncateString(20, strMedicationName))
        CreateIDLabel(pnlMainPanel, lblID2, "lblDrawerNumber", lblDrawerNum.Location.X, 20, strDrawerNumber, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID3, "lblSection", lblSection.Location.X, 20, strSection, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID4, "lblSystemCount", lblSystemCount.Location.X, 20, strSystemCount, getPanelCount(flpPannel))

        'Add panel to flow layout panel

        flpPannel.Controls.Add(pnl)
        pnlMainPanel.Tag = intDrawerMEDID
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: ExtractFormDataForDatabase     */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/5/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to iterate over the flow panel to strip the data   */
    '/*  the user typed in when creating the report. it will see if the box 
    '/* has an updated amount, it updates the amount, collects the drawer 
    '/*  numbers for the updated items and opens those drawers
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                             				      */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	ExtractFormDataForDatabase()        							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	ctlPanelPadding- a control representing all of the panels that had*/
    '/*    were used to pad another panel.                                */
    '/* pnlPanel- a control which will contain only panels.               */
    '/* ctlControls- a control which represents all of the controls on a  */
    '/*     particular panel.                                             */
    '/* txtBox- represents a textbox, specifically the one that the user  */
    '/*    typed in to update the medication count in the drawer          */
    '/*
    '/* strArrayList  -- list of strings that collects each drawer that is updated
    '/* strArray -- array of string of each item in strArrayList to pass to multidrawer open method
    '/*
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/5/2021    Initial creation                     */
    '/* AB              4/07/2021    Form changed to restocking form
    '/*********************************************************************/
    Sub ExtractFormDataForDatabase()

        Dim ctlPanelPadding As Control
        Dim pnlPanel As Control
        Dim ctlControl As Control
        Dim txtBox As TextBox

        Dim strArrayList As New List(Of String)

        'the construction of the panels is important to consider here. Look over the createPanel method to understand
        'there is a panel docked inside of another panel which is used to create a padding effect.
        'to get any controls off of the panel, we need to iterate twice through the controls to reach these items

        For Each ctlPanelPadding In flpEndOfShiftCount.Controls
            ' retreiving the pannels for padding
            For Each pnlPanel In ctlPanelPadding.Controls
                ' retreiving list of all panels within the padding

                'check if the panel is marked as red
                If pnlPanel.BackColor = Color.FromArgb(71, 103, 216) Then

                    For Each ctlControl In pnlPanel.Controls
                        ' retreiving the items in the panel such as labels and textbox values
                        If TypeName(ctlControl) = "TextBox" Then

                            txtBox = CType(ctlControl, TextBox)
                            'Debug.Print(pnlPanel.Tag) 'tag will retreive the ID of the medication because it is added there in there create panel method
                            'Debug.Print(txtBox.Text) 'textbox will contain the typed count 
                            'Debug.Print(pnlPanel.BackColor.ToString) 'if the backcolor is red, then the item was flagged

                            Dim strmedicationID As String = pnlPanel.Tag
                            Dim dblUserCount As Double = CDbl(txtBox.Text)
                            Dim strsqlCommand As String = "UPDATE DrawerMedication SET Quantity = '" & dblUserCount & "' where DrawerMedication_ID = '" & strmedicationID & "'"
                            CreateDatabase.ExecuteInsertQuery(strsqlCommand)
                            strsqlCommand = "Select Drawers_TUID from DrawerMedication where DrawerMedication_ID = '" & strmedicationID & "'"
                            Dim intDrawerTUID As Integer = CreateDatabase.ExecuteScalarQuery(strsqlCommand)

                            If Not strArrayList.Contains(intDrawerTUID) Then
                                strArrayList.Add(intDrawerTUID)
                            End If

                        End If
                    Next
                End If
            Next
        Next
        Dim strArray As String() = strArrayList.ToArray
        For Each strItem As String In strArrayList
            OpenOneDrawer(strItem)
            If Not cmbFilter.SelectedIndex = -1 Then
                btnSave.Visible = True
            Else
                btnSave.Visible = False

            End If

            ' remove all controls and the handlers of those controls before generating new panels
            RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)

            ' determine which report will be run based on the user selection from the drop down
            ' this selection determines which SQL query will be called.

            DetermineSelectedReport(cmbFilter.SelectedIndex)
        Next
    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: cmbFilter_SelectedIndexChanged()     */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/13/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is routine is called when the user selects an item from the */
    '/* from the drop down list.                                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*   nothing                                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*   RemoveHandlersAndAssociations()                                 */   
    '/*   GetListOfAllControls                                            */
    '/*   DetermineSelectedReport                                         */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/* sender As Object- represents a control object                     */
    '/* e As EventArgs- the event associated                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	cmbFilter_SelectedIndexChanged()                                  */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/13/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        Dim lbl As Label
        For Each lbl In pnlHeader.Controls
            lbl.Font = New Font(New FontFamily("Segoe UI Semibold"), 12, FontStyle.Regular)
        Next

        If Not cmbFilter.SelectedIndex = -1 Then
            btnSave.Visible = True
        Else
            btnSave.Visible = False

        End If

        ' remove all controls and the handlers of those controls before generating new panels
        RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)

        ' determine which report will be run based on the user selection from the drop down
        ' this selection determines which SQL query will be called.

        DetermineSelectedReport(cmbFilter.SelectedIndex)

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: DetermineSelectedReport()            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/13/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is routine is called when the user selects an item from the */
    '/*  from the drop down list and the index value of the selected item */
    '/*  is passed here                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*   cmbFilter_SelectedIndexChanged                                  */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                     
    '/*                                             
    '/*                                          
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/* intIndex- an integer representing the index value of the selected */
    '/* item.                                                             */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	DetermineSelectedReport(intInteger)                               */ 
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  2/13/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub DetermineSelectedReport(ByVal intIndex As Integer)

        Select Case intIndex

            Case TypesOfReports.AllMedication
                Inventory.EndofShiftAllMedications()
                AddTexChangedHandlerToTextboxes()

            Case TypesOfReports.Controlled
                Inventory.ControlledMedsEndofShift()
                AddTexChangedHandlerToTextboxes()

            Case TypesOfReports.ControlledNonNarcotic
                Inventory.ControlledNonNarcoticMedsEndofShift()
                AddTexChangedHandlerToTextboxes()

            Case TypesOfReports.Narcotic
                Inventory.NarcoticEndOfShift()
                AddTexChangedHandlerToTextboxes()

            Case TypesOfReports.NonNarcotic
                Inventory.NonNarcoticEndOfShift()
                AddTexChangedHandlerToTextboxes()

        End Select

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
    '/*********************************************************************/

    Private Sub RemoveHandlersAndAssociations(ByVal lstOfControlsToRemove As List(Of Control), flpFlowPanel As FlowLayoutPanel)

        Dim ctlControlObject As Control
        Const PANELWITHASSIGNEDHANDLERS As String = "pnlMedicationFlagged"
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim flag As Boolean = False

        For Each ctlPanelPadding In flpEndOfShiftCount.Controls
            ' retreiving the pannels for padding
            For Each pnlPanel In ctlPanelPadding.Controls
                ' retreiving list of all panels within the padding

                'check if the panel is marked as red
                If pnlPanel.BackColor = Color.FromArgb(71, 103, 216) Then
                    flag = True
                End If
            Next
        Next

        If flag = True Then
            ExtractFormDataForDatabase()
            MessageBox.Show("Medication totals have been updated")
        Else
            MessageBox.Show("A medication is not flagged")
        End If

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
        If Not cmbFilter.SelectedIndex = -1 Then
            BoldLabelToSortBy(sender, parent)
        End If


    End Sub


    '/********************************************************************/
    '/*                   FUNCTION NAME: DetermineSelectedReportForLabelsDrawerNumber	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                              
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: this sub will check which reporting type is 
    '/* selected and call the correct sorted method for the correct selected report
    '/*
    '/*
    '/********************************************************************/
    '/*  CALLED BY 
    '/********************************************************************/
    '/*  CALLS:	
    ' CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user clicks the drarwer number label						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub DetermineSelectedReportForLabelsDrawerNumber(ByVal intIndex As Integer)

        Select Case intIndex

            Case TypesOfReports.AllMedication
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet

                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
            "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
            "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE DrawerMedication.Active_Flag = '1' ORDER BY Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)

                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.Controlled
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.ControlledNonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND Medication.NarcoticControlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.Narcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.NarcoticControlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.NonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

        End Select

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtPassword_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                              
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: this sub will check which reporting type is 
    '/* selected and call the correct sorted method for the correct selected report
    '/********************************************************************/
    '/*  CALLED BY lblMedication.Click
    '/********************************************************************/
    '/*  CALLS:	
    '/*  CALLS:	
    ' CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user clicks the medication label						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub DetermineSelectedReportForLabelsMedicationName(ByVal intIndex As Integer)

        Select Case intIndex

            Case TypesOfReports.AllMedication
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet

                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
            "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
            "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE DrawerMedication.Active_Flag = '1' ORDER BY trim(Drug_Name,' ') COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)

                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.Controlled
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY trim(Drug_Name,' ') COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.ControlledNonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND Medication.NarcoticControlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY trim(Drug_Name,' ') COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.Narcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.NarcoticControlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY trim(Drug_Name,' ') COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.NonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY trim(Drug_Name,' ') COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

        End Select

    End Sub


    '/********************************************************************/
    '/*                   FUNCTION NAME: txtPassword_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                              
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: this sub will check which reporting type is 
    '/* selected and call the correct sorted method for the correct selected report
    '/********************************************************************/
    '/*  CALLED BY lblMedication.Click
    '/********************************************************************/
    '/*  CALLS:	
    ' CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user clicks the bin label						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub DetermineSelectedReportForLabelsBin(ByVal intIndex As Integer)

        Select Case intIndex

            Case TypesOfReports.AllMedication
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet

                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
            "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
            "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE DrawerMedication.Active_Flag = '1' ORDER BY Divider_Bin,Drawer_Number COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)

                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.Controlled
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY Divider_Bin,Drawer_Number COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.ControlledNonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND Medication.NarcoticControlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY Divider_Bin,Drawer_Number COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.Narcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.NarcoticControlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY Divider_Bin,Drawer_Number COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.NonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY Divider_Bin,Drawer_Number COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

        End Select

    End Sub



    '/********************************************************************/
    '/*                   FUNCTION NAME: DetermineSelectedReportForLabelsSystemCount	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                              
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: this sub will check which reporting type is 
    '/* selected and call the correct sorted method for the correct selected report
    '/********************************************************************/
    '/*  CALLED BY lblMedication.Click
    '/********************************************************************/
    '/*  CALLS:	
    ' CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user clicks the system count label				                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub DetermineSelectedReportForLabelsSystemCount(ByVal intIndex As Integer)

        Select Case intIndex

            Case TypesOfReports.AllMedication
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet

                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
            "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
            "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE DrawerMedication.Active_Flag = '1' ORDER BY Quantity,Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)

                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.Controlled
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY Quantity,Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next


            Case TypesOfReports.ControlledNonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '1' AND Medication.NarcoticControlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY Quantity,Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.Narcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.NarcoticControlled_Flag = '1' AND DrawerMedication.Active_Flag = '1' ORDER BY Quantity,Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

            Case TypesOfReports.NonNarcotic
                Dim strSqlCommand As String
                Dim dsMedicationDataset As DataSet
                strSqlCommand = "SELECT Medication_TUID, Drug_Name, Drawer_Number, Divider_Bin, Quantity, DrawerMedication.DrawerMedication_ID FROM DrawerMedication " &
                    "INNER JOIN Medication on Medication.Medication_ID = DrawerMedication.Medication_TUID " &
                    "INNER JOIN Drawers on Drawers.Drawers_ID = DrawerMedication.Drawers_TUID WHERE Medication.Controlled_Flag = '0' AND DrawerMedication.Active_Flag = '1' ORDER BY Quantity,Drawer_Number,Divider_Bin COLLATE NOCASE"
                dsMedicationDataset = CreateDatabase.ExecuteSelectQuery(strSqlCommand)
                For Each dr As DataRow In dsMedicationDataset.Tables(0).Rows
                    CreatePanel(flpEndOfShiftCount, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next

        End Select

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: txtPassword_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                              
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:this will call the sorting methods for sorting the 
    '/*   restocking by the medication name
    '/********************************************************************/
    '/*  CALLED BY lblMedication.Click
    '/********************************************************************/
    '/*  CALLS:	
    ' RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
    ' DetermineSelectedReportForLabelsMedicationName(cmbFilter.SelectedIndex)*/		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user clicks the medication label						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub lblMedication_Click(sender As Object, e As EventArgs) Handles lblMedication.Click
        RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
        DetermineSelectedReportForLabelsMedicationName(cmbFilter.SelectedIndex)
    End Sub
    '/********************************************************************/
    '/*                   FUNCTION NAME: txtPassword_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                            
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:this will call the sorting methods for sorting the 
    '/*   restocking by the drawer number
    '/********************************************************************/
    '/*  CALLED BY lblDrawerNum.Click
    '/********************************************************************/
    '/*  CALLS:		
    ' RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
    ' DetermineSelectedReportForLabelsDrawerNumber(cmbFilter.SelectedIndex)
    '*/		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user clicks the drawer number label							                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub lblDrawerNum_Click(sender As Object, e As EventArgs) Handles lblDrawerNum.Click
        RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
        DetermineSelectedReportForLabelsDrawerNumber(cmbFilter.SelectedIndex)
    End Sub
    '/********************************************************************/
    '/*                   FUNCTION NAME: txtPassword_TextChanged	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                              
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE:this will call the sorting methods for sorting the 
    '/*   restocking by the bin number
    '/********************************************************************/
    '/*  CALLED BY lblSection.Click
    '/********************************************************************/
    '/*  CALLS:	
    ' RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
    ' DetermineSelectedReportForLabelsBin(cmbFilter.SelectedIndex)*/		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:	 user clicks the bin number label						                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub lblSection_Click(sender As Object, e As EventArgs) Handles lblSection.Click
        RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
        DetermineSelectedReportForLabelsBin(cmbFilter.SelectedIndex)
    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: lblSystemCount_Click	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker        */   
    '/*		         DATE CREATED:    4/14/2021             */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: this will call the sorting methods for sorting the 
    '/*   restocking by the system count 
    '/********************************************************************/
    '/*  CALLED BY lblSystemCount.Click
    '/********************************************************************/
    '/*  CALLS:		
    ' RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
    ' DetermineSelectedReportForLabelsSystemCount(cmbFilter.SelectedIndex)*/		                  
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	            (NONE)	                                             */								                        							             
    '/********************************************************************/
    '/* SAMPLE INVOCATION: user clicks the system count label							                         */		             			                                 */					                       
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									 */		                         */
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  AB             4/14/2021       Initial creation
    '/********************************************************************/ 
    Private Sub lblSystemCount_Click(sender As Object, e As EventArgs) Handles lblSystemCount.Click
        RemoveHandlersAndAssociations(GetListOfAllControls(flpEndOfShiftCount), flpEndOfShiftCount)
        DetermineSelectedReportForLabelsSystemCount(cmbFilter.SelectedIndex)
    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: AddTexChangedHandlerToTextboxes      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 4/16/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is working to assign the text changed handler to the textboxes
    '/*  at run time. the functionality of the textboxes is specific to   */
    '/*  this form and that is why this is not handled in the public method/
    '/*  that creates the textboxes originally.                            /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      DetermineSelectedReport                                      */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 none                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 BoldLabelToSortBy(sender, parent)     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	txtbox- A textbox control representing a textbox in a panel       */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  4/16/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub AddTexChangedHandlerToTextboxes()

        'looping over the panel construct until we can get to the textbox item
        'and then when we get there we can assign the textchanged handler to it
        For Each ctlPanelPadding In flpEndOfShiftCount.Controls
            ' retreiving the pannels for padding
            For Each pnlPanel In ctlPanelPadding.Controls
                ' retreiving list of all panels within the padding

                For Each ctlControl In pnlPanel.Controls

                    ' retreiving the items in the panel such as labels and textbox values
                    If TypeName(ctlControl) = "TextBox" Then

                        Dim txtbox As TextBox
                        txtbox = CType(ctlControl, TextBox)
                        AddHandler txtbox.TextChanged, AddressOf txtbox_TextChanged

                    End If
                Next
            Next
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: SortBySelectedLabel            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 4/16/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is checks if the text in the textbox is between0-1000       */
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
    '/*	field- integer equal to the tag value of the control              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  4/16/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub txtbox_TextChanged(sender As Object, e As EventArgs)

        'check if the textbox is not null, has valid numeric data in it,
        'if these cases are true then we can cast the data to a double and
        'then check if the value is between 1 and 1000. If it is not, we need
        'to set the value in the textbox to nothing 

        If Not String.IsNullOrEmpty(sender.text) Then
            If IsNumeric(sender.text) Then
                If CDbl(sender.text) < 1 Or CDbl(sender.text) > 1000 Then
                    MessageBox.Show("Please enter a value between 1-1000.")
                    sender.Text = Nothing
                End If
            End If
        End If

    End Sub



End Class