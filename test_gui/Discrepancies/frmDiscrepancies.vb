Public Class frmDiscrepancies

    Public Enum DiscrepanciesEnum
        ID = 1
        medication = 2
        drawer = 3
        expectedCount = 4
        actualCount = 5
        dateAndTime = 6
    End Enum

    Dim currentContactPanelName As String = Nothing
    Dim ContactPanelsAddedCount As Integer = 0

    '/*********************************************************************/
    '/*                   SubProgram NAME: frmDiscrepancies_Load   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		  */   
    '/*		         DATE CREATED: 		 2/14/2021                 */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to be called when a the form loads and handle the  */
    '/*  necessary logic involved in setting the form up for the user     */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                             */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender                                                           */ 
    '/*  e
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 none  	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub frmDiscrepancies_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        '************************************************************************************
        ' Notes for who writes the query. Use the Create panel to loop through your data set 
        ' to send the database table data to the UI. replace the mock data with your tabledata
        '************************************************************************************

        Discrepancies.PopulateDiscrepancies()
        CreateToolTips(pnlHeader, tpLabelHover)
        AddHandlerToLabelClick(pnlHeader, AddressOf SortBySelectedLabel)
        AddHandlersLaterForRunTimePerformance()

        If flpDiscrepancies.Controls.Count = 0 Then

            btnResolve.Visible = False
        Else

            btnResolve.Visible = True

        End If
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

        For Each ctl In flpDiscrepancies.Controls
            For Each pnlPadding In ctl.Controls
                For Each pnlMain In pnlPadding.Controls

                    AddHandler pnlMain.Click, AddressOf SingleClickButtonShow

                Next
            Next
        Next

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
    '/*	field- integer equal to the tag of the selected label             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SortBySelectedLabel(sender As Object, e As EventArgs)

        Dim parent As Panel = sender.parent
        Dim field As Integer = CInt(sender.tag)

        BoldLabelToSortBy(sender, parent)

        'check If the user Is selecting a dispense history field to sort by
        If parent.Name = pnlHeader.Name Then

            DiscrepancySelectedField(field)

        End If


    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: DiscrepancySelectedField   */         
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
    '/*	 DispenseHistorySelectedField(Cint(Label1.Tag))   	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub DiscrepancySelectedField(ByVal field As Integer)

        ' clear the controls as they will need to be rebuilt when sorting
        'flpPatientRecords.Controls.Clear()

        Select Case field

            Case DiscrepanciesEnum.ID

            Case DiscrepanciesEnum.medication

            Case DiscrepanciesEnum.drawer

            Case DiscrepanciesEnum.expectedCount

            Case DiscrepanciesEnum.actualCount

            Case DiscrepanciesEnum.dateAndTime

        End Select

    End Sub
    '/********************************************************************/
    '/*                   SUB NAME: CreatePanel            	             */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  SUB PURPOSE: contains the logic and mechanics to display db data*/
    '/*   to the front end in the form of panels.                        */
    '/********************************************************************/
    '/*  CALLED BY:                                      	      		 */				            
    '/*                                              			         */         
    '/********************************************************************/
    '/*  CALLS:							                            	 */		                  
    '/*            CreateIDLabel        					             */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/* flpPannel- A flow panel that contains subpanels which contain    */
    '/*    the rest of the controls.                                     */
    '/* strID- the ID of the discrepancy from the DB                     */
    '/* strMedication- the medication from the DB in question            */
    '/* strDrawerNumber- the drawer number of the medication in question */
    '/* strExpectedCount- the count the system is expecting to have      */
    '/* strActualCount- the count of medication that is physically present/
    '/* strDTE- date the discrepancy was discovered                      */
    '/* strTime- time the discrepancy was discovered                     */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	CreatePanel(flpDiscrepancies, strID, genName1, quantity2, dispensedBy5, quantity1, dispenseDate1, dispenseTime1)				                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 pnl- an object of type panel that will be created at run time   */
    '/*	 pnlMain- an object of type panel that will be created at run time/
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    Public Sub CreatePanel(ByVal flpPannel As FlowLayoutPanel, ByVal strID As String, ByVal strMedication As String, ByVal strDrawerNumber As String, ByVal strExpectedCount As String, ByVal strActualCount As String, ByVal strDateAndTime As String)

        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel
        ' call method here to get the count from the database and update the panel number so the next item is correct

        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(flpDiscrepancies.Size.Width - 6, 47)
            .Name = "pnlIndividualDiscrepancyPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel
            .BackColor = Color.White
            .Size = New Size(flpDiscrepancies.Size.Width - 5, 45)
            .Name = "pnlIndividualDiscrepancy" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
        End With

        'put the boarder panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        AddHandler pnlMainPanel.Click, AddressOf SingleClickButtonShow
        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault

        'add controls to this panel
        Const Y As Integer = 20
        Dim lblID As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label
        Dim lblID5 As New Label
        Dim lblID6 As New Label
        Dim lblID7 As New Label

        'anywhere we have quotes except for the label names, we can call our Database and get method
        CreateIDLabel(pnlMainPanel, lblID7, "lblDiscrepancyID", lblDiscrepancyID.Location.X, Y, strID, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID, "lblMedication", lblMedication.Location.X, Y, strMedication, getPanelCount(flpPannel), tpLabelHover, TruncateString(18, strMedication))
        CreateIDLabel(pnlMainPanel, lblID2, "lblDrawer", lblDrawer.Location.X, Y, strDrawerNumber, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID3, "lblExpectedCount", lblExpectedCount.Location.X, Y, strExpectedCount, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID4, "lblActualCount", lblActualCount.Location.X, Y, strActualCount, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID5, "lblDateAndTime", lblDateTime.Location.X, Y, strDateAndTime, getPanelCount(flpPannel))

        'Add panel to flow layout panel
        flpPannel.Controls.Add(pnl)

    End Sub

    '/********************************************************************/
    '/*            SUB NAME: btnResolve_Click                    	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	3/15/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:                                                    */
    '/*  This sub ensures the user has selected a discrepancy to resolve.*/
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
    '/*	 checkIfSelected                           				         */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		3/15/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub btnResolve_Click(sender As Object, e As EventArgs) Handles btnResolve.Click

        Dim paddingPanel As Control
        Dim controlPanel As Control
        Dim checkIfSelected As Boolean = False

        For Each paddingPanel In flpDiscrepancies.Controls
            Debug.Print(paddingPanel.Name)
            For Each controlPanel In paddingPanel.Controls
                If controlPanel.Name.Contains("pnlIndividualDiscrepancy") Then
                    If controlPanel.BackColor = Color.FromArgb(71, 103, 216) Then
                        checkIfSelected = True
                    End If
                End If
            Next
        Next

        If checkIfSelected = False Then
            MessageBox.Show("Please select a discrepancy to resolve.")
        Else

            frmResolve.SetDiscrepancyID(CInt(getSelectedDiscrepancyLabel().Text))
            frmMain.OpenChildForm(frmResolve)
            ' frmResolve.Show()
        End If


    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: getSelectedDiscrepancy	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  FUNCTION PURPOSE: this function retrieves the ID of the discrepancy
    '/*   by taking it off of the panel on the user interface.		     */	                       
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: frmResolve                             	      		 */				            
    '/*                                        			            	 */         
    '/********************************************************************/
    '/*  CALLS:							                            	 */		                  
    '/*             (NONE)					                        	 */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 (NONE)                                                          */								                        
    '/*                                                                  */  
    '/********************************************************************/
    '/*  RETURNS:							                             */	                          
    '/*  intDiscrepancyID- an integer that is the discrepancy            */								             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	getSelectedDiscrepancy()					                     */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 ctlPaddingPanel- a control object that is used to hold all of the/
    '/*  controls that will be iterated over.					         */
    '/*	 ctlPanel- a control object that is used to hold all of the      */
    '/*  controls that will be iterated over.					         */
    '/*	 lbl- a control object that is used to hold all of the           */
    '/*  controls that will be iterated over.					         */
    '/*  intDiscrepancyID- integer representing the ID of the discrepancy*/
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    Function getSelectedDiscrepancyLabel() As Label

        Dim ctlPaddingPanel As Control
        Dim ctlPanel As Control
        Dim lbl As Control
        Dim lblID As Label = Nothing

        For Each ctlPaddingPanel In flpDiscrepancies.Controls
            For Each ctlPanel In ctlPaddingPanel.Controls
                If ctlPanel.Name.Contains("pnlIndividualDiscrepancy") Then
                    If ctlPanel.BackColor = Color.FromArgb(71, 103, 216) Then
                        For Each lbl In ctlPanel.Controls
                            If lbl.Name.Contains("lblDiscrepancyID") Then

                                ' grab the control and cast it as a labels

                                lblID = CType(lbl, Label)
                            End If
                        Next
                    End If
                End If
            Next
        Next

        Return lblID

    End Function

    '/********************************************************************/
    '/*                   SUB NAME: SingleClickButtonShow   	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  SUB PURPOSE: contains functionality to determine which control  */
    '/*  was selected and based on that, the background color and labels */
    '/*  will be updated.                                                */
    '/********************************************************************/
    '/*  CALLED BY:                                      	      		 */				            
    '/*            (NONE)                           			         */         
    '/********************************************************************/
    '/*  CALLS:							                            	 */		                  
    '/*             UpdateBackColors      					             */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing the selected control                */								                        
    '/*  e- the base class containing the data                           */  
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	                        				                         */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 pnlSelected- an object of type panel that will be iterated over */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub SingleClickButtonShow(sender As Object, e As EventArgs)

        Dim pnlSelected As Panel = Nothing

        If TypeName(sender) = "Label" Then

            pnlSelected = CType(sender.parent, Panel)
            UpdateBackColors(pnlSelected)

        Else

            pnlSelected = CType(sender, Panel)
            UpdateBackColors(pnlSelected)

        End If

    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: UpdateBackColors           	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	4/13/21			                     */                             
    '/********************************************************************/
    '/*  SUB PURPOSE: Changes the background color by checking each panel*/
    '/*  in the flow panel and looking to see if one is already highlighted
    '/*  if one already is, the back color will be set back to default and/
    '/*  the newly selected one will be updated to have a blue background*/
    '*/  with white text.                                                */
    '/********************************************************************/
    '/*  CALLED BY:                                      	      		 */				            
    '/*            (NONE)                           			         */         
    '/********************************************************************/
    '/*  CALLS:							                            	 */		                  
    '/*             (ResetColorsOnPanel)					             */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 sender- object representing the selected control                */								                        
    '/*  e- the base class containing the data                           */  
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	getSelectedDiscrepancy					                         */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 pnlSelected- an object of type panel that will be iterated over */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        4/13/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub UpdateBackColors(ByVal pnlSelected As Panel)

        If CheckIfPanelIsSelected(pnlSelected) = True Then

            Dim paddingPanel As Control
            Dim controlPanel As Control

            For Each paddingPanel In flpDiscrepancies.Controls
                Debug.Print(paddingPanel.Name)
                For Each controlPanel In paddingPanel.Controls
                    If controlPanel.Name.Contains("pnlIndividualDiscrepancy") Then
                        If controlPanel.BackColor = Color.FromArgb(71, 103, 216) Then
                            controlPanel.BackColor = Color.White
                            For Each lbl In controlPanel.Controls
                                lbl.ForeColor = Color.Black
                            Next
                        End If
                    End If
                Next
            Next
            ResetColorsOnPanel(pnlSelected)
        Else
            ResetColorsOnPanel(pnlSelected)
        End If

    End Sub

    '/********************************************************************/
    '/*                   SUBROUTINE NAME: ResetColorsOnPanel   	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  SUBROUTINE PURPOSE: takes the color of the panel and decides	 */	                       
    '/*  if it needs to change the back color or text color              */
    '/********************************************************************/
    '/*  CALLED BY: SingleClickButtonShow                         		 */				            
    '/*                                        			            	 */         
    '/********************************************************************/
    '/*  CALLS:							                            	 */		                  
    '/*             (NONE)					                        	 */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 (NONE)                                                          */								                        
    '/*                                                                  */  
    '/********************************************************************/
    '/*  RETURNS:							                             */	                          
    '/*  intDiscrepancyID- an integer that is the discrepancy            */								             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	ResetColorsOnPanel(pnlName)					                     */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*                                                                  */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Sub ResetColorsOnPanel(pnlSelected As Panel)

        If Not pnlSelected.BackColor = Color.FromArgb(71, 103, 216) Then
            pnlSelected.BackColor = Color.FromArgb(71, 103, 216)

            For Each lbl In pnlSelected.Controls
                lbl.ForeColor = Color.White
            Next
        Else
            pnlSelected.BackColor = Color.Gainsboro

            For Each lbl In pnlSelected.Controls
                lbl.ForeColor = Color.Black
            Next
        End If

    End Sub

    '/********************************************************************/
    '/*                   FUNCTION NAME: CheckIfPanelIsSelected	         */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  FUNCTION PURPOSE: this function checks to see if any panels are */	 
    '/*  are currently selected (highlighted blue).                      */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: SingleClickButtonShow                          		 */				            
    '/*                                        			            	 */         
    '/********************************************************************/
    '/*  CALLS:							                            	 */		                  
    '/*             (NONE)					                        	 */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	 pnl- a control object of type Panel                             */								                        
    '/*                                                                  */  
    '/********************************************************************/
    '/*  RETURNS:							                             */	                          
    '/*  blnIsSelected- a boolean                                        */								             
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	getSelectedDiscrepancy()					                     */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 paddingPanel- a control object that is used to hold all of the   /
    '/*  controls that will be iterated over.					         */
    '/*	 controlPanel- a control object that is used to hold all of the  */
    '/*  controls that will be iterated over.					         */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    Private Function CheckIfPanelIsSelected(pnl As Panel) As Boolean

        Dim blnIsSelected As Boolean = False
        Dim paddingPanel As Control
        Dim controlPanel As Control

        For Each paddingPanel In flpDiscrepancies.Controls
            Debug.Print(paddingPanel.Name)

            For Each controlPanel In paddingPanel.Controls
                If controlPanel.Name.Contains("pnlIndividualDiscrepancy") Then

                    If controlPanel.BackColor = Color.FromArgb(71, 103, 216) Then
                        blnIsSelected = True
                    End If

                End If
            Next
        Next

        Return blnIsSelected

    End Function

End Class