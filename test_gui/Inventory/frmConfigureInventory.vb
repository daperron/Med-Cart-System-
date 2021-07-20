Public Class frmConfigureInventory

    Dim ContactPanelsAddedCount As Integer = 0
    Dim CurrentContactPanelName As String = Nothing
    Private intCurrentDrawer As Integer

    Private btnDrawerToSelectOnLoad As Button


    Public Enum InventoryEnum

        medication = 1
        divider = 2
        strength = 3
        quantity = 4

    End Enum

    '/*********************************************************************/
    '/*             SubProgram NAME: frmConfigureInventory_Load             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method is called when the form loads. preliminary actions like   
    '/*  selecting the drawer, drawing buttons, and assigning handlers takes
    '/*  place at this time.                                              */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          btnSaveOrAdd_Click                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub frmConfigureInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'txtCapacity.Enabled = False
        txtDividers.Enabled = False

        SetDrawerPropertiesToAdd()
        UpdateButtonsOnScreen()
        AddHandlerToDrawerButtons()

        SelectDrawer(btnDrawerToSelectOnLoad)
        'btnDrawer1.PerformClick()

        CreateToolTips(pnlHeader, tpSelectedLabelHover)
        AddHandlerToLabelClick(pnlHeader, AddressOf SortBySelectedLabel)

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
    '/* field- an integer equal to the tag value of the selected label
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

            InventorySelectedFields(field)

        End If

    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: InventorySelectedFields   */         
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
    '/*	 InventorySelectedFields(Cint(Label1.Tag))   	              */
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
    Private Sub InventorySelectedFields(ByVal field As Integer)

        ' clear the controls as they will need to be rebuilt when sorting
        'flpPatientRecords.Controls.Clear()

        Select Case field

            Case InventoryEnum.medication

            Case InventoryEnum.divider

            Case InventoryEnum.strength

            Case InventoryEnum.quantity

        End Select

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: CreatePanel()                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
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
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub CreatePanel(ByVal flpPannel As FlowLayoutPanel, ByVal strDrugName As String, ByVal strDividerBin As String, ByVal strStrength As String, ByVal strQuantity As String, ByRef intMedicationTUID As Integer)

        Dim pnl As Panel
        pnl = New Panel

        Dim pnlMainPanel As Panel
        pnlMainPanel = New Panel
        ' call method here to get the count from the database and update the panel number so the next item is correct


        'Set panel properties
        With pnl
            .BackColor = Color.Gainsboro
            .Size = New Size(670, 47)
            .Name = "pnlMedicationRecordPadding" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Padding = New Padding(0, 0, 0, 3)
            ' .Dock = System.Windows.Forms.DockStyle.Top
        End With

        With pnlMainPanel

            .BackColor = Color.White
            .Size = New Size(670, 45)
            .Name = "pnlMedicationRecord" + getPanelCount(flpPannel).ToString
            .Tag = getPanelCount(flpPannel).ToString
            .Dock = System.Windows.Forms.DockStyle.Top
        End With

        'put the boarder panel inside the main panel
        pnl.Controls.Add(pnlMainPanel)

        AddHandler pnlMainPanel.MouseEnter, AddressOf MouseEnterPanelSetBackGroundColor
        AddHandler pnlMainPanel.MouseLeave, AddressOf MouseLeavePanelSetBackGroundColorToDefault

        Dim pt As New Point(lblActions.Location.X - 10, 5)
        ' add controls to this panel
        CreateEditButton(pnlMainPanel, getPanelCount(flpPannel), lblActions.Location.X - 10, 5)
        CreateDeleteBtn(pnlMainPanel, getPanelCount(flpPannel), lblActions.Location.X + 40, 5)

        Dim lblID As New Label
        Dim lblID2 As New Label
        Dim lblID3 As New Label
        Dim lblID4 As New Label
        Dim lblID5 As New Label
        Dim tpToolTip As New ToolTip

        Dim intLength As Integer = strDrugName.Length

        If intLength > 25 Then
            intLength = 25
        End If

        Dim strTuncated As String = strDrugName.Substring(0, intLength)
        'CreateIDLabel(pnlMainPanel, lblID, "lblDrugName", lblDrugName.Location.X, 20, strDrugName, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID, "lblDrugName", lblDrugName.Location.X, 20, strDrugName, getPanelCount(flpPannel), tpToolTip, strTuncated)
        CreateIDLabel(pnlMainPanel, lblID5, "lblDivider", lblDivider.Location.X, 20, strDividerBin, getPanelCount(flpPannel))
        CreateIDLabelWithToolTip(pnlMainPanel, lblID2, "lblStrength", lblStrength.Location.X, 20, strStrength, getPanelCount(flpPannel), tpToolTip, TruncateString(15, strStrength))
        ' CreateIDLabel(pnlMainPanel, lblID2, "lblStrength", lblStrength.Location.X, 20, strStrength, getPanelCount(flpPannel))
        'CreateIDLabel(pnlMainPanel, lblID3, "lblType", 220, 20, strType, getPanelCount(flpPannel))
        CreateIDLabel(pnlMainPanel, lblID4, "lblQuantity", lblQuantity.Location.X, 20, strQuantity, getPanelCount(flpPannel))

        'Add panel to flow layout panel
        flpPannel.Controls.Add(pnl)
        pnlMainPanel.Tag = intMedicationTUID
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: UpdateDrawerLabel              */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is an event handler assigned to all of the buttons that will*/
    '/*  update the label text on the form indicating which drawer is click/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      btnClick                                                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
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
    Private Sub UpdateDrawerLabel(sender As Object, e As EventArgs)

        lblDrawerNum.Text = "Drawer " & CStr(sender.tabIndex) & " Information:"

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: UpdateButtonsOnScreen          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is called to set the properties of each drawer button at run*/
    '/*  time. Items such as tool tip and special information like the if */
    '/*  the drawer is full can be noted here and the button can be updated/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmConfiguration_Load                                        */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
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
    Private Sub UpdateButtonsOnScreen()

        'aray used to throw temporary data here for dumping. only for prototype purposes
        Dim arrQuantity As Integer() = {6, 7, 5, 78, 7, 8, 8, 9, 12, 144, 34, 55, 23, 67, 8, 67, 12, 34, 5, 65, 87, 43, 65, 21, 59}
        Dim tp As New ToolTip
        Dim count As Integer = 0

        For Each ctl In pnlLayoutButtons.Controls

            'Dim lbl As New Label

            'With lbl
            '    .Name = "lblStatus" & count
            'End With


            'Dim lblItemQuantity As New Label

            'With lblItemQuantity
            '    .Name = "lblItemQuantity" & count
            'End With

            If TypeName(ctl) = "Button" Then

                Dim btn As Button = CType(ctl, Button)


                ' this would be concated with a search on the database looking at the drawer number
                btn.Text = CStr(ctl.tabIndex)


                'here we will update the buttons to see if they are full and label them as being full
                If CheckIfDrawerFull(ctl.tabIndex) = True Then
                    btn.Text = CStr(ctl.tabIndex) & Environment.NewLine & ("Full")
                    CreateDatabase.ExecuteInsertQuery("Update Drawers set Full_Flag = '1' where Drawers_ID = '" & CStr(ctl.tabIndex) & "'")
                Else
                    CreateDatabase.ExecuteInsertQuery("Update Drawers set Full_Flag = '0' where Drawers_ID = '" & CStr(ctl.tabIndex) & "'")
                End If


                ' here we need to check if any of the medications in the drawer are close to being empty.
                ' if so, then we will make the drawer appear red. Remember that each drawer can hold
                ' multiple medications.

                If arrQuantity(count) < 5 Then

                    btn.BackColor = Color.Red
                    tp.SetToolTip(btn, "Less than 5 items remain in this drawer")
                    'add btn tool tip when hover


                    'With lbl
                    '    ' location for all the full labels based on the current buttonsize we can dynmaically create labels... why?
                    '    ' well since we are putting labels on the button it is possible if the user selects the label they will not be selecting the button
                    '    ' obviuosly we want the label to function like an extension of the button so we may need to assign button handlers to the labels to ensure
                    '    ' the function properly so there is no difference between clicking the button, and clicking the label on top of the button.

                    '    .Location = New Point(btn.Location.X + 19, btn.Location.Y + 62)
                    '    .Text = "Empty"
                    '    .Font = New Font(New FontFamily("Segoe UI"), 9, FontStyle.Regular)
                    '    .BackColor = Color.Gainsboro

                    'End With

                    'With lblItemQuantity

                    '    .Location = New Point(btn.Location.X + 32, btn.Location.Y + 36)
                    '    .Text = CStr(arrQuantity(count))
                    '    .Font = New Font(New FontFamily("Segoe UI"), 9, FontStyle.Regular)
                    '    .BackColor = Color.Gainsboro
                    '    .ForeColor = Color.Black
                    '    .BringToFront()

                    'End With
                    'pnlLayoutButtons.Controls.Add(lbl)
                    'pnlLayoutButtons.Controls.Add(lblItemQuantity)

                Else


                    'With lbl
                    '    ' location for all the full labels based on the current buttonsize we can dynmaically create labels... why?
                    '    ' well since we are putting labels on the button it is possible if the user selects the label they will not be selecting the button
                    '    ' obviuosly we want the label to function like an extension of the button so we may need to assign button handlers to the labels to ensure
                    '    ' the function properly so there is no difference between clicking the button, and clicking the label on top of the button.

                    '    .Location = New Point(btn.Location.X + 26, btn.Location.Y + 62)
                    '    .Text = "Full"
                    '    .Font = New Font(New FontFamily("Segoe UI"), 9, FontStyle.Regular)
                    '    .BackColor = Color.Gainsboro

                    'End With


                    'With lblItemQuantity

                    '    .Location = New Point(btn.Location.X + 32, btn.Location.Y + 36)
                    '    .Text = CStr(arrQuantity(count))
                    '    .Font = New Font(New FontFamily("Segoe UI"), 9, FontStyle.Regular)
                    '    .BackColor = Color.Gainsboro

                    'End With

                End If

                ' adding the handle to allow the drawer label to update based on the drawer we select

                AddHandler btn.Click, AddressOf UpdateDrawerLabel
                AddHandler btn.Click, AddressOf UpdateScreenWithMedicationsInSelectedDrawer
                AddHandler btn.Click, AddressOf HideEditButton
                count += 1

            End If



        Next
    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: AddHandlerToDrawerButtons      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is called to add functionality to the buttons at run time   */
    '/*  this is specifically impacting the buttons depicting the drawers */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmConfiguration_Load                                        */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
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
    Private Sub AddHandlerToDrawerButtons()

        Dim btnSingle As Button

        For Each ctlControl In pnlLayoutButtons.Controls

            If TypeName(ctlControl) = "Button" Then

                btnSingle = CType(ctlControl, Button)

                AddHandler btnSingle.Click, AddressOf HighlightSelectedDrawer

            End If
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: AddHandlerToDrawerButtons      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is a handler that will determine if a button is clicked what*/
    '/*  color that button should become and the color of all other buttons/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmConfiguration_Load                                        */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 field- an integer equal to the tag value of the selected label   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
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
    Private Sub HighlightSelectedDrawer(sender As Object, e As EventArgs)

        intCurrentDrawer = sender.TabIndex.ToString()
        Dim btn As Control

        For Each btn In pnlLayoutButtons.Controls

            If sender.Name = btn.Name Then

                If sender.backColor = Color.Gainsboro Then

                    sender.ForeColor = Color.White
                    sender.backColor = Color.FromArgb(71, 103, 216)

                End If

            Else

                btn.BackColor = Color.Gainsboro
                btn.ForeColor = Color.Black

            End If
        Next

        If btnSaveOrAdd.Text = "SAVE CHANGES" Then
            btnSaveOrAdd.Text = "ADD TO DRAWER"
        End If

        LockButton()

    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME: GetSelectedDrawer                */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:		    						              */             
    '/*	 This looks at all of the drawers, takes the selected one, and then/
    '/*  returns the selected button.
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      SetSelectedDrawer()                                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:			                            		          */         
    '/*	 Button object                                                    */ 
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 NONE                                                             */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	GetSelectedDrawer()                                               */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Function GetSelectedDrawer() As Button

        Dim btnSelectedDrawer As Button = Nothing
        Dim ctl As Control = Nothing

        For Each ctl In pnlLayoutButtons.Controls

            If ctl.BackColor = Color.FromArgb(71, 103, 216) Then

                btnSelectedDrawer = CType(ctl, Button)

            End If

        Next

        Return btnSelectedDrawer

    End Function

    '/*********************************************************************/
    '/*                   SubProgram NAME: PreviouslySelectedDrawer       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This receives the drawer that was previous visited before changing/
    '/*  screens.                                                          /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmConfiguration_Load                                        */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 btnUserSelectedDrawer- a button control object   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
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
    Public Sub PreviouslySelectedDrawer(ByVal btnUserSelectedDrawer As Button)

        btnDrawerToSelectOnLoad = btnUserSelectedDrawer

    End Sub

    '/*********************************************************************/
    '/*   SubProgram NAME: UpdateScreenWithMedicationsInSelectedDrawer    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is a handler assigned to all of the buttons depicting the drawer
    '/*  When the drawer is selected, this method determines what medications
    '/*  are associated with that drawer and adds them to the screen.      /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*     UpdateButtonsOnScreen                                         */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	NONE                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
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
    Private Sub UpdateScreenWithMedicationsInSelectedDrawer(sender As Button, e As EventArgs) Handles btnDrawer1.Click

        flpMedication.Controls.Clear()
        Dim strDrugName As String = ""
        Dim intStrength As String = ""
        Dim intDividerBin As Integer = 0
        Dim intDrawerSize As Integer = 0
        Dim intDrugQuantity As Integer = 0
        Dim intMedicationTUID As Integer = 0
        Dim dsDrawerContents As DataSet = GetDrawerDrugs(sender.TabIndex)

        For Each dr As DataRow In dsDrawerContents.Tables(0).Rows
            strDrugName = dr(0)
            intStrength = dr(1)
            intDrugQuantity = CInt(dr(2))
            intDividerBin = dr(3)
            intMedicationTUID = dr(4)

            CreatePanel(flpMedication, strDrugName, intDividerBin, intStrength.ToString(), intDrugQuantity.ToString(), intMedicationTUID)
        Next

        '  Dim size As Integer = CreateDatabase.ExecuteScalarQuery("SELECT Size FROM Drawers where Drawers_ID = " & sender.TabIndex.ToString() & ";")
        'txtCapacity.Text = size
        Dim dividers As Integer = CreateDatabase.ExecuteScalarQuery("SELECT Number_of_Dividers FROM Drawers where Drawers_ID = " & sender.TabIndex.ToString() & ";")
        txtDividers.Text = dividers


        'MessageBox.Show(strDrugName + " " + intStrength.ToString() + "   " + intDividerBin.ToString() + " In drawer number: " + sender.TabIndex.ToString())
    End Sub


    'Private Sub btnAddtoDrawer_Click(sender As Object, e As EventArgs)

    '    ' pass the name of thecurrently selected drawer the user is looking at
    '    frmInventory.SetSelectedDrawer(GetSelectedDrawer)

    '    ' open the inventory form
    '    frmMain.OpenChildForm(frmInventory)

    'End Sub


    '/*********************************************************************/
    '/*                      SubProgram NAME: SelectDrawer                */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method decides which drawer to select when the form laods. If/
    '/*  the user previously selected a drawer and added to it, when the  */
    '/*  add to the drawer and leave, then come back, this drawer is selected
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*     frmConfigureInventory_Load                                    */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	btnDrawerToSelect- a button control object                        */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SelectDrawer(ByVal btnDrawerToSelect As Button)

        'check if there is an object to pass. If its null, then we know this is the first time the page is being loaded
        'there wouldnt be a previous button in that case
        If IsDBNull(btnDrawerToSelect) Or btnDrawerToSelect Is Nothing Then
            ' set Drawer 1 as the default Drawer to Select
            btnDrawer1.PerformClick()
        Else

            Dim ctl As Control
            Dim btnSelect As Button

            ' select the drawer that was previously selected by checking which button as that name,
            ' the performing a click event. Cant simply call btnDrawerToSelect.PerformClick() because the reference to this
            ' button was deleted when frmConfigureInventory was originally closed.

            For Each ctl In pnlLayoutButtons.Controls
                If ctl.Name = btnDrawerToSelect.Name Then
                    btnSelect = CType(ctl, Button)
                    btnSelect.PerformClick()
                End If
            Next
        End If

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: btnIncrementDividers_Click           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method decides what to do when the increment button is clicked
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                    */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnIncrementDividers_Click(sender As Object, e As EventArgs) Handles btnIncrementDividers.Click

        btnSaveOrAdd.Visible = True
        ButtonIncrement(5, txtDividers)
        SetDrawerPropertiesToSave()




    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: btnDecrementDividers_Click           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method decides what to do when the decrement button is clicked
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                    */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnDecrementDividers_Click(sender As Object, e As EventArgs) Handles btnDecrementDividers.Click
        btnSaveOrAdd.Visible = True
        If txtDividers.Text = 1 Then
            'ignore the decrement method because it does not handle 0
            txtDividers.Text = 0
            SetDrawerPropertiesToSave()
        ElseIf txtDividers.Text = 0 Then
            txtDividers.Text = 0
            MessageBox.Show("The minimum allowed value is zero")
        Else

            ButtonDecrement(txtDividers)
            SetDrawerPropertiesToSave()
        End If

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: SetDrawerPropertiesToSave            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method updates the button properties to indicate the user can/
    '/*  click this button to save the changes.                            /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                    */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SetDrawerPropertiesToSave()

        If btnSaveOrAdd.Text = "ADD TO DRAWER" Then

            With btnSaveOrAdd
                .Text = "SAVE CHANGES"
                .Image = My.Resources.resolve
                .ImageAlign = ContentAlignment.MiddleCenter
                .TextImageRelation = TextImageRelation.ImageBeforeText

            End With

        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: RemoveDrugFromDrawer   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker  		  */   
    '/*		         DATE CREATED: 		 3/21/2021                 */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to handle the set up and gathering of variables 
    '/*  to remove the drug from the drawermedication database
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      DetermineQueryDelete_Click                                   */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* Inventory.RemoveDrugfromDrawer(intDrawerTUID, intDividerNumber, intMedicationTUID)  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */          
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 RemoveDrugFromDrawer(Sender)  	                  */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  AB  3/21/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub RemoveDrugFromDrawer(sender As Object)
        'get the divider number from the panel
        Dim intDividerNumber As Integer = GetSelectedInformation(sender.parent, "lblDivider")
        'get the medication from the panel .tag field
        Dim intMedicationTUID As Integer = sender.parent.tag
        'get the drawer number from the global variable
        Dim intSelectedDrawer As Integer = intCurrentDrawer
        ''get drawer TUID from database using selected drawer
        Dim intDrawerTUID As Integer = CreateDatabase.ExecuteScalarQuery("Select Drawers_ID from Drawers where Drawer_Number = '" & intSelectedDrawer & "'")
        Inventory.RemoveDrugfromDrawer(intDrawerTUID, intDividerNumber, intMedicationTUID)
        CreateDatabase.ExecuteInsertQuery("UPDATE PatientMedication set Active_Flag = '0' where Medication_TUID = '" & intMedicationTUID & "'")
        CreateDatabase.ExecuteInsertQuery("UPDATE Medication SET Active_Flag = '0' where Medication_ID = '" & intMedicationTUID & "'")
        CartInterfaceCode.OpenOneDrawer(intSelectedDrawer)
        MessageBox.Show("Drug removed from drawer number: " & intSelectedDrawer)
        UpdateButtonsOnScreen()
    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: btnSaveOrAdd_Click                   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method checks if the user is trying to save or add and then */
    '/*  the function of the button changes based on the .text of the btn */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                    */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnSaveOrAdd_Click(sender As Object, e As EventArgs) Handles btnSaveOrAdd.Click

        If btnSaveOrAdd.Text = "SAVE CHANGES" Then
            Dim intdraweer As Integer = intCurrentDrawer
            Dim intDrugCount As Integer = getPanelCount(flpMedication)
            Dim intDividerNumber As Integer = txtDividers.Text
            Dim intDividerNumberBeforeChange As Integer = CreateDatabase.ExecuteScalarQuery("Select Number_of_Dividers from Drawers where Drawers_ID = '" & intCurrentDrawer & "' and Active_Flag = '1'")
            If (intDividerNumber + 1) >= intDrugCount Then
                SaveButtonFunctionality()
                SetDrawerPropertiesToAdd()
                UpdateUser()
                UpdateButtonsOnScreen()
                LockButton()
            Else
                MessageBox.Show("There are currently " & intDrugCount & " medications in this drawer, you can not decrease the divider count below " &
                                (intDrugCount - 1) & ".")
                txtDividers.Text = intDividerNumberBeforeChange
                SetDrawerPropertiesToAdd()
            End If


        Else

            AddToDrawerFunctionality()

        End If

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: SetDrawerPropertiesToAdd             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method updates the button properties to indicate the user can/
    '/*  click this button to add more items to the drawer                 /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*       btnSaveOrAdd_Click                             */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SetDrawerPropertiesToAdd()

        With btnSaveOrAdd
            .Text = "ADD TO DRAWER"
            .Image = My.Resources.add_24px
            .ImageAlign = ContentAlignment.MiddleCenter
            .TextImageRelation = TextImageRelation.ImageBeforeText
        End With

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: UpdateUser                           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method updates the user so they know changes were saved      /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*         btnSaveOrAdd_Click                           */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub UpdateUser()

        MessageBox.Show("Drawer updated to contain " & txtDividers.Text & " divider(s)")

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: SaveButtonFunctionality              */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method updates the database with changes the user made      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          btnSaveOrAdd_Click                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SaveButtonFunctionality()

        ' call code here to update the database with the txtCapacity and txtDividers information about the drawer.
        ' ExecuteScalarQuery("UPDATE Drawers SET Number_of_Dividers = " & CInt(txtDividers.Text) & ", Size = " & CInt(txtCapacity.Text) & "  WHERE Drawers_ID  = " & intCurrentDrawer & ";")
        ExecuteScalarQuery("UPDATE Drawers SET Number_of_Dividers = " & CInt(txtDividers.Text) & " WHERE Drawers_ID  = " & intCurrentDrawer & ";")
        Me.Refresh()

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: AddToDrawerFunctionality             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/24/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method documents the currently selected drawer, then opensthe/
    '/*  add to inventory form.                                            /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          btnSaveOrAdd_Click                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub AddToDrawerFunctionality()

        ' pass the name of thecurrently selected drawer the user is looking at
        frmInventory.SetSelectedDrawer(GetSelectedDrawer)

        ' pass the list of full drawers to the next form
        frmInventory.SetFullDrawersList(GetDrawersThatAreFull)

        ' open the inventory form
        frmMain.OpenChildForm(frmInventory)

    End Sub


    '/*********************************************************************/
    '/*             SubProgram NAME: CheckIfDrawerFull             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker   		          */   
    '/*		         DATE CREATED: 		 3/30/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This Function will take in a drawer number and check too see if the
    '/* drawer is fully filled with medications. and return a true or false 
    '/* if it is or is not filled
    '/*
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          btnSaveOrAdd_Click                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Function CheckIfDrawerFull(intDrawerNumber As Integer)
        Dim blnIsDrawerFull As Boolean
        Dim intDrawerBinsFilled As Integer
        Dim intDrawerDividers As Integer
        intDrawerDividers = CreateDatabase.ExecuteScalarQuery("Select Number_of_Dividers from Drawers where Drawers_ID = '" & intDrawerNumber & "' and Active_Flag = '1'")
        intDrawerBinsFilled = CreateDatabase.ExecuteScalarQuery("Select count(Divider_Bin) from DrawerMedication where Drawers_TUID = '" & intDrawerNumber & "' and Active_Flag = '1'")

        If intDrawerBinsFilled = (intDrawerDividers + 1) Then
            blnIsDrawerFull = True
        Else
            blnIsDrawerFull = False
        End If
        Return blnIsDrawerFull

    End Function

    '/*********************************************************************/
    '/*             SubProgram NAME: HideEditButton             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/30/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This sub hides the pencil icon because it is not needed to appear */
    '/ on the form. It is needed to be physically located on it because it */
    '/* plays a roll in showing the check mark icon so we need to still add*/
    '/  add it to the form
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          UpdateButtonsOnScreen                                    */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 This is an event handler and uses Vb default parameters for handlers 
    '/*  sender and e
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	ctl- a control that is being iterated over                        */
    '/*	pnl- a control that is being iterated over                        */
    '/*	pnlMain - a control that is being iterated over                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub HideEditButton(ByVal sender As Object, e As EventArgs)

        Dim ctl As Control
        Dim pnl As Control
        Dim pnlMain As Control
        ' panel in the flow panel
        For Each ctl In flpMedication.Controls
            'panel in the pnlPadding
            For Each pnl In ctl.Controls
                'each control in the pnl main
                For Each pnlMain In pnl.Controls

                    If pnlMain.Name.Contains("Edit") Then

                        pnlMain.Visible = False

                        '   AddHandler pnlMain.VisibleChanged, AddressOf VisibleChangedEvent

                    End If
                Next
            Next
        Next

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: LockButtons             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/30/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This sub checks if a drawer is full, then hides the add to drawer /
    '/*  button to prevent a user from trying to add to a full drawer before
    '/*  increasing the drawers capacity.                                  /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          HighlightSelectedDrawer                                  */ 
    '/*          btnSaveOrAddClick                                        */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	none                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub LockButton()

        Dim ctl As Control

        For Each ctl In pnlLayoutButtons.Controls
            If TypeName(ctl) = "Button" Then
                If ctl.BackColor = Color.FromArgb(71, 103, 216) Then
                    If ctl.Text.Contains("Full") Then

                        btnSaveOrAdd.Visible = False
                        If btnSaveOrAdd.Text = "ADD TO DRAWER" Then
                            btnSaveOrAdd.Visible = False
                        End If

                    Else

                        btnSaveOrAdd.Visible = True

                    End If
                End If
            End If
        Next

    End Sub

    '/*********************************************************************/
    '/*             SubProgram NAME: GetDrawersThatAreFull                */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/30/2021                        */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:			    					              */             
    '/*	 This sub checks if a drawer is full, then hides the add to drawer /
    '/*  button to prevent a user from trying to add to a full drawer before
    '/*  increasing the drawers capacity.                                  /
    '/*********************************************************************/
    '/   RETURNS                                                           /
    '/   List of integers that represent the drawers that are full         /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          HighlightSelectedDrawer                                  */ 
    '/*          btnSaveOrAddClick                                        */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	  none                                                            */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                                 	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 ctl- a control that is being iterated over                       */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/24/2021    Initial creation                    */
    '/*********************************************************************/
    Private Function GetDrawersThatAreFull() As List(Of Integer)

        Dim lstFullDrawers As New List(Of Integer)
        Dim ctl As Control

        For Each ctl In pnlLayoutButtons.Controls
            If TypeName(ctl) = "Button" Then
                If ctl.Text.Contains("Full") Then
                    ' if the drawer is full we will add it to the array to indicate so
                    lstFullDrawers.Add(ctl.TabIndex)
                End If
            End If
        Next

        Return lstFullDrawers

    End Function

End Class