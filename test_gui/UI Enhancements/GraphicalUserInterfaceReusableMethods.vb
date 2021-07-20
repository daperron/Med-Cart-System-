Imports System.Threading
Module GraphicalUserInterfaceReusableMethods
    '/*********************************************************************/
    '/*           SubProgram NAME: MouseEnterPanelSetBackGroundColor      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Hander that controls the appearance of a panel when the user hovers
    '/*  over the panel.                                                  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub MouseEnterPanelSetBackGroundColor(Sender As Object, e As EventArgs)

        'changes the background color when the mouse is hovered over the panel
        If Not Sender.backcolor = Color.Red And Not Sender.backcolor = Color.FromArgb(71, 103, 216) Then

            If Sender.backColor = Color.White Then
                Sender.backColor = Color.Gainsboro

            Else

                Sender.backcolor = Color.White
            End If

        End If

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: MouseEnterPanelSetBackGroundColor      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Hander that controls the appearance of a panel when the user leaves
    '/*  the panel with their cursor.                                     */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub MouseLeavePanelSetBackGroundColorToDefault(sender As Object, e As EventArgs)

        ' checking if the background color is set to the highlighted color
        'if it is not then we will set it.
        If Not sender.backcolor = Color.Red And Not sender.backcolor = Color.FromArgb(71, 103, 216) Then
            If sender.backColor = Color.Gainsboro Then

                sender.backColor = Color.White

            Else

                sender.backcolor = Color.Gainsboro
            End If
        End If


    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME:RestDefaultButtons                      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the user decides to click on the trash can icon or the check*/
    '/*  at some point the settings need to go back to the standard icons.*/
    '/*  this method resets the icons to how they should be which is just */
    '/*  the trash can being visble.                                      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/* CreateXMarkButton()                                               */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub RestDefaultButtons(ByVal sender As Object, ByVal e As EventArgs)

        Dim intTemp As Integer = 1

        Dim ctlControl As Control

        For Each ctlControl In sender.Parent.Controls

            If TypeName(ctlControl) = "Button" Then

                If Not ctlControl.Name.Contains("Cancel") Or ctlControl.Name.Contains("Check") Then
                    ' for any controls that are not the check mark or red x, we will make them visible

                    ctlControl.Visible = True

                    If getOpenedForm.GetType() Is frmConfigureInventory.GetType Or getOpenedForm.GetType() Is frmPatientInfo.GetType Then
                        ' Debug.Print(ctlControl.Name)
                        If ctlControl.Name.Contains("EditPatientRecord") Or ctlControl.Name.Contains("btnConfirmation") Then
                            ctlControl.Visible = False
                        End If
                    End If

                Else
                        'even though we hide the other controls, once we select the delete button once, we are hiding all of the other icons
                        ' there fore we do not need to recreate them we can simply hide or unhide them
                        ' in this case we will set the visibility to false because they are controls that we need to hide.

                        ctlControl.Visible = False

                End If
            End If
        Next

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: ShowConfirmationButtons                */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Hander that controls when the Xmark button is made visible       */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub ShowConfirmationButtons(ByVal sender As Object, ByVal e As EventArgs)

        'call methods here to show the checkmark buttons when the item is clicked

        ' hide the sender which is the trash can icon
        sender.Visible = False

        Debug.Print(sender.Location.X.ToString)
        Debug.Print(sender.Location.Y.ToString)

        'put the check mark where the trash can icon was
        ' CreateCheckMarkBtn(sender.parent, New Point(sender.Location.X, sender.Location.Y))

        CreateXMarkBtn(sender.parent, New Point(sender.Location.X, sender.Location.Y))

        'put the x icon where the edit button was. We need to find the location of the edit Button.
        Dim ctlControl As Control

        For Each ctlControl In sender.Parent.Controls

            If TypeName(ctlControl) = "Button" Then
                If ctlControl.Name.Contains("Edit") Then

                    Debug.Print(ctlControl.Name)

                    'hide the control
                    ctlControl.Visible = False

                    ' get the location and put the x in that location
                    ' CreateXMarkBtn(sender.Parent, New Point(ctlControl.Location.X, ctlControl.Location.Y))
                    CreateCheckMarkBtn(sender.Parent, New Point(ctlControl.Location.X, ctlControl.Location.Y))
                End If
            End If
        Next

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: DynamicButton_Click                    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Removes handler from the panel and destroys the object. This is  */
    '/*  used when the delete button is called to properly dispose the obj*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  strParentPanelName                                               */
    '/*  strParentPanelName                                               */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    Public Sub DynamicButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        'the parent of the button will be the panel the control is located on.
        'we want to get one step removed so we need to next take the parent of the control
        ' to get the name of flowpanel which the button is laid out on
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

        'parents.Name
        ' Dim connn As Control = parentFlowPanel.Parent
        'Debug.Print(connn.Name)
        'Debug.Print(parentFlowPanel.Name)
        'UpdateCamerasSubtotalLabel(parentFlowPanel)

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateIDLabel                          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 arranges the label on the panel when it is created by giving it  */
    '/*  proper formatting, font, and alignment. Used for every panels creation
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlName                                                           */
    '/*	lblName                                                           */
    '/*	strLabelName                                                      */
    '/*	x                                                                 */
    '/*	y                                                                 */
    '/*	strLabelText                                                      */
    '/*intPanelsAddedCount                                                */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateIDLabel(ByVal pnlName As Panel, lblName As Label, strLabelName As String, x As Integer, y As Integer, strLabelText As String, ByVal intPanelsAddedCount As Integer)

        ' Dim lblID As Label
        'lblName = New Label
        'location = New Point
        'declare our image and point at the resource

        'Set button properties
        With lblName
            .AutoSize = True
            '.Size = New Size(30, 30)

            .FlatStyle = FlatStyle.Flat
            ' .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Black
            .Font = New Font(New FontFamily("Segoe UI"), 11, FontStyle.Regular)
            .Location = New Point(x, y) 'new Point(600, 5)
            .Name = strLabelName + (intPanelsAddedCount).ToString
            .Text = strLabelText
            .Tag = intPanelsAddedCount + 1
        End With


        pnlName.Controls.Add(lblName)

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateIDLabelWithToolTip                */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 arranges the label on the panel when it is created by giving it  */
    '/*  proper formatting, font, and alignment. Used for every panels creation
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateIDLabelWithToolTip(ByVal pnlName As Panel, lblName As Label, strLabelName As String, x As Integer, y As Integer, strLabelText As String, ByVal intPanelsAddedCount As Integer, ByVal toolTip As ToolTip, ByVal strTruncatedText As String)

        'Set button properties
        With lblName
            .AutoSize = True
            '.Size = New Size(30, 30)

            .FlatStyle = FlatStyle.Flat
            ' .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Black
            .Font = New Font(New FontFamily("Segoe UI"), 11, FontStyle.Regular)
            .Location = New Point(x, y) 'new Point(600, 5)
            .Name = strLabelName + (intPanelsAddedCount).ToString
            .Text = strTruncatedText
            .Tag = intPanelsAddedCount + 1
        End With

        toolTip.SetToolTip(lblName, strLabelText)
        pnlName.Controls.Add(lblName)


    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: DynamicRemoveHandlerFromSender         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Removes handler from the specified control when this is called.  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub DynamicRemoveHandlerFromSender(ByVal sender As Object, ByVal e As EventArgs)

        'the parent of the button will be the panel the control is located on.
        'we want to get one step removed so we need to next take the parent of the control
        ' to get the name of flowpanel which the button is laid out on
        Dim ctlControl As Control = sender.Parent
        Dim ctlParents As Control = ctlControl.Parent
        Dim ctlParentFlowPanel As Control = ctlControl.Parent
        Dim strParentPanelName As String
        strParentPanelName = Nothing

        'Remove handler from sender
        For Each ctlControlObj As Control In ctlParentFlowPanel.Controls
            For Each ctlChildControlObj As Control In ctlControlObj.Controls
                If ctlChildControlObj.Name = sender.name Then

                    RemoveHandler ctlChildControlObj.Click, AddressOf DynamicButton_Click
                    strParentPanelName = ctlChildControlObj.Parent.Name

                End If
            Next
        Next

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateDeleteBtn                        */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 arranges the button on the panel when it is created by giving it */
    '/*  proper formatting, font, and alignment. Used for every panels creation
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlPanelName                                                      */
    '/*	intPanelsAddedCount                                               */
    '/*	intX                                                              */
    '/*	intY                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateDeleteBtn(ByVal pnlPanelName As Panel, ByVal intPanelsAddedCount As Integer, ByVal intX As Integer, ByVal intY As Integer)

        Dim btnDeleteButton As Button
        btnDeleteButton = New Button
        'declare our image and point at the resource

        If getOpenedForm().GetType() Is frmConfiguration.GetType() Then
            Dim mapImageTrash As New Bitmap(New Bitmap(My.Resources.plusminus), 25, 25)
            'Set button properties
            With btnDeleteButton
                .AutoSize = True
                .Size = New Size(30, 30)
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .ForeColor = Color.Transparent
                ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
                ' .Location = New Point(  )
                .Location = New Point(intX, intY)
                .Name = "btnDeletePatientRecord" + (intPanelsAddedCount).ToString
                .Image = mapImageTrash
                .ImageAlign = ContentAlignment.MiddleCenter
                .Tag = intPanelsAddedCount + 1
            End With
        ElseIf getOpenedForm().GetType() Is frmEditPhysician.GetType() Then
            Dim mapImageTrash As New Bitmap(New Bitmap(My.Resources.plusminus), 25, 25)
                'Set button properties
                With btnDeleteButton
                    .AutoSize = True
                    .Size = New Size(30, 30)
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 0
                    .ForeColor = Color.Transparent
                    ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
                    ' .Location = New Point(  )
                    .Location = New Point(intX, intY)
                    .Name = "btnDeletePatientRecord" + (intPanelsAddedCount).ToString
                    .Image = mapImageTrash
                    .ImageAlign = ContentAlignment.MiddleCenter
                    .Tag = intPanelsAddedCount + 1
                End With
            Else
            Dim mapImageTrash As New Bitmap(New Bitmap(My.Resources.icons8_delete_trash), 25, 25)
            'Set button properties
            With btnDeleteButton
                .AutoSize = True
                .Size = New Size(30, 30)
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .ForeColor = Color.Transparent
                ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
                ' .Location = New Point(  )
                .Location = New Point(intX, intY)
                .Name = "btnDeletePatientRecord" + (intPanelsAddedCount).ToString
                .Image = mapImageTrash
                .ImageAlign = ContentAlignment.MiddleCenter
                .Tag = intPanelsAddedCount + 1
            End With
        End If

        pnlPanelName.Controls.Add(btnDeleteButton)

        ' MessageBox.Show("again")
        'Add handler for click events
        AddHandler btnDeleteButton.Click, AddressOf ShowConfirmationButtons

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateFlagBtn                          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 arranges the button on the panel when it is created by giving it */
    '/*  proper formatting, font, and alignment. Used for every panels creation
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlPanelName                                                      */
    '/*	intPanelsAddedCount                                               */
    '/*	intX                                                              */
    '/*	intY                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateFlagBtn(ByVal pnlPanelName As Panel, ByVal intPanelsAddedCount As Integer, ByVal intX As Integer, ByVal intY As Integer)

        Dim btnFlagMedication As Button
        btnFlagMedication = New Button
        'declare our image and point at the resource
        Dim mapImageTrash As New Bitmap(New Bitmap(My.Resources.flag_black_25px), 25, 25)

        'Set button properties
        With btnFlagMedication
            .AutoSize = True
            .Size = New Size(30, 30)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Transparent
            ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
            ' .Location = New Point(  )
            .Location = New Point(intX, intY)
            .Name = "btnFlagMedication" + (intPanelsAddedCount).ToString
            .Image = mapImageTrash
            .ImageAlign = ContentAlignment.MiddleCenter
            .Tag = intPanelsAddedCount + 1
            .TabStop = False
        End With

        pnlPanelName.Controls.Add(btnFlagMedication)

        ' MessageBox.Show("again")
        'Add handler for click events
        AddHandler btnFlagMedication.Click, AddressOf DynamicFlagMedicationButton

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: DynamicFlagMedicationButton            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 is a handler that tells the flag button how to behave when clicked/
    '/*  it checks the textboxes to make sure they have correct quantities*/
    '/*  before the user can submit their information to the db           */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlPanelName                                                      */
    '/*	intPanelsAddedCount                                               */
    '/*	intX                                                              */
    '/*	intY                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub DynamicFlagMedicationButton(sender As Object, ByVal e As EventArgs)


        ' Dim pnlFlaggedPannel As Panel
        ' Dim txtBoxOnFlaggedPanel As TextBox = Nothing

        Dim pnlFlaggedPannel As Panel = CType(sender.parent, Panel)
        Dim txtBoxOnFlaggedPanel As TextBox = FindTextBoxOnPanel(pnlFlaggedPannel)

        Dim systemCount As Integer = CInt(FindLabelOnPanel(pnlFlaggedPannel).Text)

        Dim ctl As Control

        For Each ctl In pnlFlaggedPannel.Controls
            If ctl.Name.Contains("lbl") Then
                ctl.ForeColor = Color.White
            End If
        Next

        ' when using the flag, we need to check that the system count is not the same as the user count
        ' if it is, then there is nothing to flag and we need to let the user know that incase they
        ' typed something wrong. If the user tries to flag a medication without typing a value in, they should not
        ' be able to flag anything so the button will not respond.

        If String.IsNullOrEmpty(txtBoxOnFlaggedPanel.Text) Or Not IsNumeric(txtBoxOnFlaggedPanel.Text) Then
            For Each ctl In pnlFlaggedPannel.Controls
                If ctl.Name.Contains("lbl") Then
                    ctl.ForeColor = Color.Black
                End If
            Next
            MessageBox.Show("A new total has not been entered. Please type a number into the new total field.")
        Else

            If systemCount = CInt(txtBoxOnFlaggedPanel.Text) Then

                For Each ctl In pnlFlaggedPannel.Controls
                    If ctl.Name.Contains("lbl") Then
                        ctl.ForeColor = Color.Black
                    End If
                Next
                MessageBox.Show("The system total matches the entered new total.")

            Else

                ' at this point there is a valid difference and we will want to lock the textbox and change
                ' the color of the panel so it is clear a discrepancy is being marked.

                If Not pnlFlaggedPannel.BackColor = Color.FromArgb(71, 103, 216) Then

                    'find the textbox and set the field to be read only
                    'txtBoxOnFlaggedPanel.ReadOnly = True
                    'txtBoxOnFlaggedPanel.AcceptsTab = False

                    txtBoxOnFlaggedPanel.Enabled = False
                    ' change the panel color to be blue
                    pnlFlaggedPannel.BackColor = Color.FromArgb(71, 103, 216)

                Else

                    'find the textbox and set the field to be editable
                    'txtBoxOnFlaggedPanel.ReadOnly = False
                    'txtBoxOnFlaggedPanel.AcceptsTab = True
                    txtBoxOnFlaggedPanel.Enabled = True

                    ' change the panel color to be white
                    pnlFlaggedPannel.BackColor = Color.White

                    ' reset label color
                    For Each ctl In pnlFlaggedPannel.Controls
                        If ctl.Name.Contains("lbl") Then
                            ctl.ForeColor = Color.Black
                        End If
                    Next

                End If

            End If


        End If



        ' Debug.Print(pnlFlaggedPannel.Name)

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: FindTextBoxOnPanel                     */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Finds the textbox that a user could type in and that is on the   */
    '/*  flagged panel. This takes that textbox and returns the control   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlFlagged                                                        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Function FindTextBoxOnPanel(ByVal pnlFlagged As Panel) As TextBox

        ' search for control with the name txtCount
        ' this control will be the textbox on the selected panel
        Const TEXTBOXNAME As String = "txtCount"
        Dim ctlControl As Control
        Dim txtBox As TextBox = Nothing

        ' looking at each control on the panel
        For Each ctlControl In pnlFlagged.Controls
            ' if the current control is the textbox, then asign the textbox variable to this 
            If ctlControl.Name.Contains(TEXTBOXNAME) Then
                txtBox = CType(ctlControl, TextBox)
            End If
        Next

        Return txtBox

    End Function

    '/*********************************************************************/
    '/*           SubProgram NAME: FindLabelOnPanel                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Finds the label on the panel and takes the numeric value of that */
    '/*  to ensure that the count is not the same as the system count     */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlFlagged                                                        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Function FindLabelOnPanel(ByVal pnlFlagged As Panel) As Label

        ' search for control with the name txtCount
        ' this control will be the textbox on the selected panel
        Const lblName As String = "lblSystemCount"
        Dim ctlControl As Control
        Dim lblLabel As Label = Nothing

        ' looking at each control on the panel
        For Each ctlControl In pnlFlagged.Controls
            ' if the current control is the textbox, then asign the textbox variable to this 
            If ctlControl.Name.Contains(lblName) Then
                lblLabel = CType(ctlControl, Label)
            End If
        Next

        Return lblLabel

    End Function

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateTextBox                          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Creates the textbox and positions it with the correct formatting */
    '/*  onto the panel on the form.                                      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlPanelName                                                      */
    '/*	intPanelsAddedCount                                               */
    '/*	intX                                                              */
    '/*	intY                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateTextBox(ByVal pnlPanelName As Panel, ByVal intPanelsAddedCount As Integer, ByVal intX As Integer, ByVal intY As Integer)

        Dim txtCount As TextBox
        txtCount = New TextBox

        'Set button properties
        With txtCount
            .AutoSize = True
            .BorderStyle = BorderStyle.FixedSingle
            .Size = New Size(45, 30)
            .ForeColor = Color.Black
            .Font = New Font(New FontFamily("Segoe UI"), 11)
            ' .Location = New Point(  )
            .Location = New Point(intX, intY)
            .Name = "txtCount" + (intPanelsAddedCount).ToString
            .Tag = intPanelsAddedCount + 1
            .MaxLength = 4
            ' .Dock = DockStyle.Fill

        End With

        pnlPanelName.Controls.Add(txtCount)

        ' MessageBox.Show("again")
        'Add handler for click events
        'assing functionality here
        AddHandler txtCount.TextChanged, AddressOf TextBoxErrorHandling_TextChanged
        'AddHandler btnFlagMedication.Click, AddressOf DynamicFlagMedicationButton

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateEditButton                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Creates the edit and positions it with the correct formatting */
    '/*  onto the panel on the form.                                      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlPanelName                                                      */
    '/*	intPanelsAddedCount                                               */
    '/*	intX                                                              */
    '/*	intY                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateEditButton(ByVal pnlPanelName As Panel, ByVal pnlPanelsAddedCount As Integer, ByVal intX As Integer, ByVal intY As Integer)

        Dim btnEditButton As Button
        btnEditButton = New Button
        'declare our image and point at the resource
        Dim mapImagePencil As New Bitmap(New Bitmap(My.Resources.icons8_pencil), 25, 25)

        'Set button properties
        With btnEditButton
            .AutoSize = True
            .Size = New Size(30, 30)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Transparent
            ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
            '.Location = New Point(825, 5)
            .Location = New Point(intX, intY)
            .Name = "btnEditPatientRecord" + (pnlPanelsAddedCount).ToString
            .Image = mapImagePencil
            .ImageAlign = ContentAlignment.MiddleCenter
            .Tag = pnlPanelsAddedCount + 1
        End With

        Debug.Print(pnlPanelName.Name)
        pnlPanelName.Controls.Add(btnEditButton)
        ' MessageBox.Show("again")
        'Add handler for click events
        AddHandler btnEditButton.Click, AddressOf DynamicButtonEditRecord_Click

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateCheckMarkBtn                     */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Creates the check and positions it with the correct formatting   */
    '/*  onto the panel on the form.                                      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlPanelName                                                      */
    '/*	intPanelsAddedCount                                               */
    '/*	intX                                                              */
    '/*	intY                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateCheckMarkBtn(ByVal pnlPanelName As Panel, ByVal pntLocation As Point)

        Dim btnCheckMark As Button
        btnCheckMark = New Button
        'declare our image and point at the resource
        Dim mapImageTrash As New Bitmap(New Bitmap(My.Resources.checkmark), 25, 25)

        'Set button properties
        With btnCheckMark
            .AutoSize = True
            .Size = New Size(30, 30)

            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Transparent
            ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
            ' .Location = New Point(  )
            .Location = New Point(pntLocation)
            .Name = "btnConfirmation"
            .Image = mapImageTrash
            .ImageAlign = ContentAlignment.MiddleCenter

        End With

        pnlPanelName.Controls.Add(btnCheckMark)

        'Add handler for click events
        AddHandler btnCheckMark.Click, AddressOf DetermineQueryDelete_Click

        If getOpenedForm().GetType() Is frmConfiguration.GetType() Then
        ElseIf getOpenedForm().GetType() Is frmEditPhysician.GetType() Then
        Else AddHandler btnCheckMark.Click, AddressOf DynamicButton_Click
        End If

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: CreateXMarkBtn                         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/2/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Creates the X and positions it with the correct formatting       */
    '/*  onto the panel on the form.                                      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	pnlPanelName                                                      */
    '/*	intPanelsAddedCount                                               */
    '/*	intX                                                              */
    '/*	intY                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/2/2021    Initial creation                     */
    '/*********************************************************************/
    Public Sub CreateXMarkBtn(ByVal pnlPanelName As Panel, ByVal pntLocation As Point)

        Dim btnCancel As Button
        btnCancel = New Button
        'declare our image and point at the resource
        Dim mapImageTrash As New Bitmap(New Bitmap(My.Resources.xmark), 25, 25)

        'Set button properties
        With btnCancel
            .AutoSize = True
            .Size = New Size(30, 30)

            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .ForeColor = Color.Transparent
            ' .Font = New Font(New FontFamily("Microsoft Sans Serif"), 11)
            ' .Location = New Point(  )
            .Location = New Point(pntLocation)
            .Name = "btnCancel"
            .Image = mapImageTrash
            .ImageAlign = ContentAlignment.MiddleCenter

        End With


        pnlPanelName.Controls.Add(btnCancel)

        'Add handler for click events
        AddHandler btnCancel.Click, AddressOf RestDefaultButtons

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: DetermineQueryDelete_Click     */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 2/15/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to compare two instances of forms and see if they  */
    '/*  are the same form or not. From here, the necessary method will be*/
    '/* called based upon the functionality of the button based on that form
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  CreateCheckMarkBtn, it is working as a handler                   */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             none                                                  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	None                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	None                                 							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	dsValues - Stores the patient's who have the selected physician   */
    '/*            assigned to them.                                      */
    '/* strPatients - Stores the patient names                            */
    '/* strSQLCmd - Stores the sql command for selecting the patient names*/
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/15/2021    Initial creation                    */
    '/*  BRH   4/11/2021 Added functionality to block user from deactivating
    '/*                  a physician without changing the patient's physician
    '/*                  first.                                           */
    '/*********************************************************************/
    Public Sub DetermineQueryDelete_Click(sender As Object, ByVal e As EventArgs)

        Dim dsValues As DataSet
        Dim strSQLCmd As String
        Dim strPatients As String = vbCrLf

        ' determine the form that is currently opened in the application because this
        ' will influence the SQL query called to update the database

        ' use reflection to determine if the form opened is the same as another form
        ' because the functionality of the delete button varies depending on the form
        ' that is currently opened.

        If getOpenedForm().GetType() Is frmConfiguration.GetType() Then

            ' call SQL method to set the user flag to inactive or delete the user from the DB

            Dim intID As Integer = GetSelectedInformation(sender.parent, "lblID")
            Dim strStatement As String = "SELECT Active_Flag FROM User WHERE User_ID = '" & intID & "'"
            If ExecuteScalarQuery(strStatement) = 1 Then
                strStatement = "UPDATE USER SET Active_Flag='0' WHERE User_ID='" & intID & "';"
                ExecuteInsertQuery(strStatement)
            Else
                strStatement = "UPDATE USER SET Active_Flag='1' WHERE User_ID='" & intID & "';"
                ExecuteInsertQuery(strStatement)
            End If
            Dim strFillSQL As String = "select User.User_ID, User.Username, User.User_First_Name, User.User_Last_Name, User.Admin_Flag, " &
                                                  "User.Supervisor_Flag, User.Active_Flag From User ORDER BY User_First_Name COLLATE NOCASE ASC;"
            frmConfiguration.Fill_Table(strFillSQL)

        ElseIf getOpenedForm().GetType() Is frmPatientRecords.GetType() Then

            ' call SQL method to set the Patient Record flag to inactive or delete the user from the DB
            '    Debug.Print("patient records")

        ElseIf getOpenedForm().GetType() Is frmEditPhysician.GetType() Then

            Dim intID As Integer = GetSelectedInformation(sender.parent, "lblID")
            Dim strStatement As String = "SELECT Active_Flag FROM Physician WHERE Physician_ID = '" & intID & "'"
            If ExecuteScalarQuery(strStatement) = 1 Then

                'Check to see if the physician has patients assigned to them
                strSQLCmd = "SELECT Patient_First_Name, Patient_Middle_Name, Patient_Last_Name FROM Patient 
                            INNER JOIN Physician On Physician.Physician_ID = Primary_Physician_ID
                            WHERE Patient.Active_Flag = 1 AND Physician.Physician_ID ='" & intID & "';"

                dsValues = ExecuteSelectQuery(strSQLCmd)

                For Each item In dsValues.Tables(0).Rows
                    strPatients += item(0) & " " & item(1) & " " & item(2) & vbCrLf
                Next

                'If there are patients assigned, let the user know what patients are assigned and block them from deactivating the physician
                If dsValues.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("The following patients are assigned to this physician: " & strPatients & "Please assign them to another physician before deleting.")
                    'Else, allow the physician to deactivate the physician
                Else
                    strStatement = "UPDATE Physician SET Active_Flag='0' WHERE Physician_ID='" & intID & "';"
                    ExecuteInsertQuery(strStatement)
                End If

            Else
                strStatement = "UPDATE Physician SET Active_Flag='1' WHERE Physician_ID='" & intID & "';"
                ExecuteInsertQuery(strStatement)
            End If
            Dim strFillSQL As String = "select Physician.Physician_ID, Physician.Physician_First_Name, Physician.Physician_Middle_Name," &
                                    "Physician.Physician_Last_Name, Physician.Physician_Credentials, Physician.Physician_Phone_Number," &
                                    "Physician.Physician_Fax_Number, Physician.Physician_Address, Physician.Physician_City," &
                                    "Physician.Physician_State, Physician.Physician_Zip_Code, Physician.Active_Flag From Physician;"
            frmEditPhysician.Fill_Table(strFillSQL)

        ElseIf getOpenedForm().GetType() Is frmConfigureInventory.GetType() Then

            ' call SQL method to remove the item from the list of currently stocked items in the med cart
            '  Debug.Print("removing this inventory piece")
            frmConfigureInventory.RemoveDrugFromDrawer(sender)

        ElseIf getOpenedForm().GetType() Is frmAllergies.GetType() Then

            Dim intPatientTUID As Integer = frmAllergies.GetPatientTuid()
            Dim intAllergyName As Integer = GetSelectedAllergiesInformation(sender)
            Dim strSqlStatment As String = ("Select Active_Flag FROM PatientAllergy WHERE Allergy_TUID=" & intAllergyName & " and Patient_TUID= " & intPatientTUID & ";")
            Dim value = ExecuteScalarQuery(strSqlStatment)
            If value = 1 Then
                ExecuteScalarQuery("UPDATE PatientAllergy SET Active_Flag='0' WHERE Allergy_TUID=" & intAllergyName & " and Patient_TUID =" & intPatientTUID & ";")
            Else
                ExecuteScalarQuery("UPDATE PatientAllergy SET Active_Flag='1' WHERE Allergy_TUID=" & intAllergyName & " and Patient_TUID =" & intPatientTUID & ";")
            End If

            ' add the update to the patients table because the patient information form is not visible anymore. the update will be reflected
            ' when the patient info form is loaded again
            'frmPatientInfo.lstBoxAllergies.Items.Clear()

            GetAllergies(frmAllergies.GetPatientMrn())
            Debug.Print("remove allergy assigned to patient")

        ElseIf getOpenedForm().GetType() Is frmMyPatients.GetType() Then

            MessageBox.Show(sender.name)


        ElseIf getOpenedForm().GetType() Is frmPatientInfo.GetType() Then

            Dim intPATMedID As Integer = sender.parent.parent.tag
            frmPatientInfo.removePrescription(intPATMedID)
            MessageBox.Show("Prescription has been removed")
        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: DynamicButtonEditRecord_Click  */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 2/15/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to compare two instances of forms and see if they  */
    '/*  are the same form or not. From here, the necessary method will be*/
    '/* called based upon the functionality of the button based on that form
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  CreateEditButton, it is working as a handler                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             none                                                  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	None                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	None                                 							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/15/2021    Initial creation                    */
    '/*********************************************************************/

    Public Sub DynamicButtonEditRecord_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' determine the form that is currently opened in the application because this
        ' will influence the SQL query called to update the database

        ' use reflection to determine if the form opened is the same as another form
        ' because the functionality of the delete button varies depending on the form
        ' that is currently opened.

        If getOpenedForm().GetType() Is frmConfiguration.GetType() Then

            'call GetSelectedInformation to get the selected username and ID
            frmConfiguration.txtUsername.Text = GetSelectedInformation(sender.parent, "lblUsername")
            frmConfiguration.txtID.Text = GetSelectedInformation(sender.parent, "lblID")

            'calls to fill the other textboxes for editing the user
            Dim strStatement = "SELECT User_First_Name FROM User WHERE User_ID = '" & frmConfiguration.txtID.Text & "';"
            frmConfiguration.txtFirstName.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT User_Last_Name FROM User WHERE User_ID = '" & frmConfiguration.txtID.Text & "';"
            frmConfiguration.txtLastName.Text = ExecuteScalarQuery(strStatement)
            'strStatement = "SELECT Barcode FROM User WHERE User_ID = '" & frmConfiguration.txtID.Text & "';"
            frmConfiguration.txtBarcode.Text = ""
            strStatement = "SELECT Admin_Flag FROM User WHERE User_ID = '" & frmConfiguration.txtID.Text & "';"
            Dim strSupervisor = "SELECT Supervisor_Flag FROM User WHERE User_ID = '" & frmConfiguration.txtID.Text & "';"

            'look at the users permissions on the user table and see what radio button should be selected
            If ExecuteScalarQuery(strStatement) = 1 Then
                frmConfiguration.rbtnAdministrator.Checked = True
            ElseIf ExecuteScalarQuery(strSupervisor) = 1 Then
                frmConfiguration.rbtnSupervisor.Checked = True
            Else frmConfiguration.rbtnNurse.Checked = True
            End If

            'make the save and cancel button visible and hide button1
            frmConfiguration.btnSaveChanges.Visible = True
            frmConfiguration.btnCancel.Visible = True
            frmConfiguration.btnSaveUser.Visible = False
            frmConfiguration.Label2.Text = "Editing User"

        ElseIf getOpenedForm().GetType() Is frmPatientRecords.GetType() Then
            'this will set up the functions for the editing pencil. 
            Dim PatientInfo = New frmPatientInfo


            ' call SQL method to set edit functionality
            Debug.Print("patient records")

        ElseIf getOpenedForm().GetType() Is frmConfigureInventory.GetType() Then

            ' call SQL method to set edit functionality
            '  Debug.Print("removing this inventory piece")
        ElseIf getOpenedForm().GetType() Is frmEditPhysician.GetType() Then
            'call GetSelectedInformation to get the selected username and ID
            frmEditPhysician.txtID.Text = GetSelectedInformation(sender.parent, "lblID")
            Dim IDNumber As String = frmEditPhysician.txtID.Text

            'calls to fill the other textboxes for editing the user
            Dim strStatement = "SELECT Physician_First_Name FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.txtFirstName.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_Last_Name FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.txtLastName.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_Middle_Name FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.txtMiddleName.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_Phone_Number FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.mtbPhone.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_Fax_Number FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.mtbFax.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_Address FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.txtAddress.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_City FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.txtCity.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_Zip_Code FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.txtZipCode.Text = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_State FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.cboState.SelectedItem = ExecuteScalarQuery(strStatement)
            strStatement = "SELECT Physician_Credentials FROM Physician WHERE Physician_ID = '" & IDNumber & "';"
            frmEditPhysician.cboCredentials.SelectedItem = ExecuteScalarQuery(strStatement)

            'make the save and cancel button visible and hide button1
            frmEditPhysician.btnSaveChanges.Visible = True
            frmEditPhysician.btnCancel.Visible = True
            frmEditPhysician.btnSave.Visible = False
            frmEditPhysician.lblTitle.Text = "Editing Physician"
        ElseIf getOpenedForm().GetType() Is frmAllergies.GetType() Then

            If frmAllergies.btnAddAllergy.Visible = True Then
                Dim selectedAllergyName = GetSelectedInformation(sender.parent, "lblAllergyName")
                Dim selectedAllergySeverity = GetSelectedInformation(sender.parent, "lblSeverity")
                Dim selectedAllergyType = GetSelectedInformation(sender.parent, "lblAllergyType")
                Dim selectedMedication = GetSelectedInformation(sender.parent, "lblMedication")

                With frmAllergies
                    .cmbAllergies.Text = selectedAllergyName
                    .cmbAllergiesType.Text = selectedAllergyType
                    .cmbSeverity.Text = selectedAllergySeverity
                    '.cmbMedicationName.Text = selectedMedication
                    .cmbAllergies.Enabled = False
                    .cmbAllergiesType.Enabled = False
                    '.cmbMedicationName.Enabled = False
                    .lblAction.Text = "Edit existing allergy:"
                    .btnAllergySave.Visible = True
                    .btnAllergyCancel.Visible = True
                    .btnAddAllergy.Visible = False
                End With


                ' call SQL method to set edit functionality
                ' Debug.Print("remove allergy assigned to patient")
                Debug.WriteLine("")
            End If

        End If


    End Sub



    '/*********************************************************************/
    '/*                   Function NAME: getOpenedForm()                  */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 2/15/2021                        */                             
    '/*********************************************************************/
    '/*  Function PURPOSE:								                  */             
    '/*	 This function simply retrieves the form that is currently on the */
    '/*  pnlDockLocation panel.                                           */
    '/*********************************************************************/
    '/*  Function Return Value:					                          */         
    '/*	 A form object representing the form that is opened on the screen */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  DynamicButtonEditRecord_Click                                    */ 
    '/*  DetermineQueryDelete_Click                                       */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	None                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	None                                 							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/15/2021    Initial creation                    */
    '/*********************************************************************/
    Public Function getOpenedForm() As Form

        ' on frmMain, the panel called pnlDockedLocation is where we are shoving all of our forms into.
        ' we arent really interested in the location, we are interested in the control that is inside
        ' the pnlDockLocation. 
        ' the GetChildAtPoint() requires point as a parameter and we will use 1,1 to get that.

        Dim ptPoint As Point = New Point(1, 1)
        Dim frmOpenedControl As Control = frmMain.pnlDockLocation.GetChildAtPoint(ptPoint)
        Dim frmOpenedForm As Form = CType(frmOpenedControl, Form)

        Return frmOpenedForm

    End Function

    '/*********************************************************************/
    '/*                   Function NAME: GetSelectedInformation()         */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Dylan Walter          		          */   
    '/*		         DATE CREATED: 		 2/16/2021                        */                             
    '/*********************************************************************/
    '/*  Function PURPOSE:								                  */             
    '/*	 This function simply retrieves the requested information from    */
    '/*  the selected form.                                               */
    '/*********************************************************************/
    '/*  Function Return Value:					                          */         
    '/*	 strSelected- a string that contains the requested selection      */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  DynamicButtonEditRecord_Click                                    */ 
    '/*  DetermineQueryDelete_Click                                       */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	sender                                                            */ 
    '/* strLable                                                          */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	None                                 							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	ctl                                                               */
    '/*	Selected                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  DW  2/16/2021    Initial creation                                */
    '/*********************************************************************/
    Function GetSelectedInformation(ByVal sender As Object, ByVal strLabel As String) As String
        Dim strSelected = Nothing
        Dim ctl As Control

        ' iterating over the list of controls in the panel
        For Each ctl In sender.Controls

            ' the label containing the wanted information is stored in strLabel and is sent by the user
            ' to represent what number panel it is in the row of created panels.
            If ctl.Name.Contains(strLabel) Then

                Debug.Print(ctl.Text)
                strSelected = (ctl.Text)
            End If
        Next
        'returning the Requested information from the selected record
        Return strSelected
    End Function
    '/*********************************************************************/
    '/*           SubProgram NAME: GetSelectedAllergiesInformation        */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Adam Kott   		          */   
    '/*		         DATE CREATED: 		                       */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	                                 */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*                                                    */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			                                  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                                   */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*                    */
    '/*********************************************************************/
    Function GetSelectedAllergiesInformation(ByVal sender As Object) As String
        Dim strSelected = Nothing

        strSelected = sender.parent.tag


        'Dim ctl As Control

        '' iterating over the list of controls in the panel
        'For Each ctl In sender.Controls

        '    ' the label containing the wanted information is stored in strLabel and is sent by the user
        '    ' to represent what number panel it is in the row of created panels.
        '    If ctl.Name.Contains(strLabel) Then

        '        Debug.Print(ctl.Tag)
        '        strSelected = (ctl.Tag)
        '    End If
        'Next
        ''returning the Requested information from the selected record
        Return strSelected
    End Function

    '/*********************************************************************/
    '/*                   SubProgram NAME: getCurrentPanel                */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 2/15/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is a debugging method that helps determine which panel the  */
    '/*  user is interacting with when making GUI updates/changes         */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  CreateEditButton, it is working as a handler                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             none                                                  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	None                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	None                                 							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/15/2021    Initial creation                    */
    '/*********************************************************************/
    Public Function getCurrentPanel(ByVal flpPanel As FlowLayoutPanel, ByVal intPanelsAddedCount As Integer) As Panel

        Dim ctlName As String = "pnlIndividualPatientRecord"
        Dim pnl As Panel
        pnl = New Panel

        For Each ctlControl In flpPanel.Controls

            If ctlControl.Name = ctlName & intPanelsAddedCount.ToString Then

                pnl = CType(ctlControl, Panel)

            End If

        Next

        Debug.Print("Panel Name: " & pnl.Name)

        Return pnl

    End Function

    '/*********************************************************************/
    '/*                   Function NAME: getPanelCount()                  */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 2/15/2021                        */                             
    '/*********************************************************************/
    '/*  Function PURPOSE:								                  */             
    '/*	 Used everywhere on each form to track the number of panels that  */
    '/*  have been created. Specifically it is used to generate names for */
    '/*  controls that are made at runtime to ensure unique naming.       */
    '/*********************************************************************/
    '/*  Function Return Value:					                          */         
    '/*	 A form object representing the form that is opened on the screen */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  DynamicButtonEditRecord_Click                                    */ 
    '/*  DetermineQueryDelete_Click                                       */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	None                                                              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	None                                 							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/15/2021    Initial creation                    */
    '/*********************************************************************/

    Public Function getPanelCount(flpPanel As FlowLayoutPanel) As Integer
        ' method keeps track of the panel count by checking how many panels are on the main flowPanel.
        ' this is necessary because with the generic methods global counting variables would need to be
        ' defined in too many classes to keep track of what number of panel has been created.
        Dim ctlControl As Control
        Dim intCount As Integer

        For Each ctlControl In flpPanel.Controls

            If TypeName(ctlControl) = "Panel" Then

                intCount += 1

            End If

        Next

        'Debug.Print(count)

        Return intCount

    End Function

    '/*********************************************************************/
    '/*              Sub NAME: DynamicSingleClick()                          */         
    '/*********************************************************************/
    '/*              WRITTEN BY:            		          */   
    '/*		         DATE CREATED: 		                       */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	                                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                                                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                               		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*                     */
    '/*********************************************************************/
    Public Sub DynamicSingleClick(sender As Object, ByVal e As EventArgs)

        If sender.backColor = Color.White Then
            sender.backColor = Color.Gainsboro
        Else
            sender.backcolor = Color.White
        End If
    End Sub

    '/*********************************************************************/
    '/*              Sub NAME: ButtonIncrement()                          */         
    '/*********************************************************************/
    '/*              WRITTEN BY:            		          */   
    '/*		         DATE CREATED: 		                       */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	                                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                                                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                               		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*                     */
    '/*********************************************************************/
    Public Sub ButtonIncrement(intMaxValue As Integer, ByVal txtBox As TextBox)

        If Not CInt(txtBox.Text) = intMaxValue Then
            txtBox.Text = Int(txtBox.Text) + 1
        Else
            MessageBox.Show("The maximum allowed value is " & intMaxValue)
        End If

    End Sub

    '/*********************************************************************/
    '/*              Sub NAME: ButtonDecrement()                          */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 3/22/2021                        */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	 This Subroutine is called whenever the user decrements the qty   */
    '/*  buttons on a form.                                               */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  None                                                             */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	txtBox                                                            */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	RemoveCharacters("1hello")                                		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/* None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/22/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub ButtonDecrement(ByVal txtBox As TextBox)

        If Not CInt(txtBox.Text) = 1 Then
            If Not CInt(txtBox.Text) = 0 Then
                txtBox.Text = Int(txtBox.Text) - 1
            Else
                txtBox.Text = 1
                MessageBox.Show("You cannot reduce the value below the displayed number")
            End If
        Else
            MessageBox.Show("You cannot reduce the value below the displayed number")
        End If

    End Sub

    '/*********************************************************************/
    '/*              Sub NAME: MaxValue()                          */         
    '/*********************************************************************/
    '/*              WRITTEN BY:            		          */   
    '/*		         DATE CREATED: 		                       */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	                                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                                                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                               		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*                     */
    '/*********************************************************************/
    Public Sub MaxValue(intValue As Integer, intTest As Integer, ByVal txtBox As TextBox)
        If intValue > intTest Then
            txtBox.Text = intTest
            MessageBox.Show("Maximum value is " & intTest & ".")
        End If
    End Sub

    '/*********************************************************************/
    '/*              Sub NAME: IndexButtonIncrement()                          */         
    '/*********************************************************************/
    '/*              WRITTEN BY:            		          */   
    '/*		         DATE CREATED: 		                       */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	                                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                                                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                               		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*                     */
    '/*********************************************************************/
    Public Sub IndexButtonIncrement(intCurrent As Integer, intMax As Integer, ByVal cboBox As ComboBox)
        If intCurrent <= intMax Then
            cboBox.SelectedIndex = intCurrent + 1
        Else
            MessageBox.Show("The maximum allowed value is " & intMax)
        End If
    End Sub
    '/*********************************************************************/
    '/*              Sub NAME: IndexButtonDecrement()                          */         
    '/*********************************************************************/
    '/*              WRITTEN BY:            		          */   
    '/*		         DATE CREATED: 		                       */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	                                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                                                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                               		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*                     */
    '/*********************************************************************/
    Public Sub IndexButtonDecrement(intCurrent As Integer, ByVal cboBox As ComboBox)
        If intCurrent > 0 Then
            cboBox.SelectedIndex = intCurrent - 1
        Else
            MessageBox.Show("You cannot reduce the value below the displayed number")
        End If
    End Sub

    '/*********************************************************************/
    '/*              Sub NAME: ThreadedMessageBox()                          */         
    '/*********************************************************************/
    '/*              WRITTEN BY:            		          */   
    '/*		         DATE CREATED: 		                       */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	                                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	                                                       */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                               		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*                     */
    '/*********************************************************************/
    Public Sub ThreadedMessageBox()
        MessageBox.Show(Thread.CurrentThread.Name())

    End Sub

    '/*********************************************************************/
    '/*                   Function NAME: TruncateString()                 */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 3/14/2021                        */                             
    '/*********************************************************************/
    '/*  Function PURPOSE:								                  */             
    '/*	 This function simply takes a string and truncates it to a new    */
    '/*  length if the string is longer than the specified length. If not,*/
    '/*  it will be left alone and we return the original string passed in*/
    '/*********************************************************************/
    '/*  Function Return Value:					                          */         
    '/*	 A string that is possibly shorter version of what was passed in  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  CreatePanel()                                                    */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/* None                                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	idealLength- integer representing the length we want to truncate at/ 
    '/*	wordToTruncate- a string that will be truncated if its longer than /
    '/* the ideal length in characters.                                   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	TruncateString(15, "hello")                                		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/14/2021    Initial creation                    */
    '/*********************************************************************/
    Public Function TruncateString(ByVal idealLength As Integer, ByVal wordToTruncate As String) As String

        ' checking if the length of the word is longer than the ideal length. This needs to be done because
        ' we cannot fix the length of all strings without getting an error. Consider the following:
        ' strWord1 = "hello"
        ' strWord1.Substring(0,10)  <- this would result in a run time error because the string is not 10 characters long

        Dim actualWordLength As Integer = wordToTruncate.Length

        If actualWordLength > idealLength Then
            actualWordLength = idealLength
        End If

        Dim strTuncated As String = wordToTruncate.Substring(0, actualWordLength)

        Return strTuncated

    End Function

    '/*********************************************************************/
    '/*              Sub NAME: TextBoxErrorHandling_TextChanged()    */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 3/22/2021                        */                             
    '/*********************************************************************/
    '/*  SUB PURPOSE:								                      */             
    '/*	 This Subroutine is called whenever text changes in a run time made/
    '/*  textbox.                                                         */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  None                                                             */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	sender                                                            */
    '/* e                                                                 */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	RemoveCharacters("1hello")                                		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/* None                                                              */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/22/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub TextBoxErrorHandling_TextChanged(ByVal sender As Object, e As EventArgs)

        sender.text = RemoveCharacters(sender.text)

        'set the cursor position to the last item 
        sender.Select(sender.Text.Length, 0)

    End Sub



    '/*********************************************************************/
    '/*                   Function NAME: RemoveCharacters()               */         
    '/*********************************************************************/
    '/*              WRITTEN BY:  Collin Krygier          		          */   
    '/*		         DATE CREATED: 		 3/22/2021                        */                             
    '/*********************************************************************/
    '/*  Function PURPOSE:								                  */             
    '/*	 This function simply takes a string , checks if it is numberic,if*/
    '/*  if not, it removes everything that is not numeric.               */
    '/*********************************************************************/
    '/*  Function Return Value:					                          */         
    '/*	 A string that is contains only valid text for the textbox        */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  TextBoxErrorHandling_TextChanged()                               */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  None                                                             */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	strTextboxValue- string that is the value from the count textbox  */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	RemoveCharacters("1hello")                                		  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	newString- a string equal to the original textbox value           */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/22/2021    Initial creation                    */
    '/*********************************************************************/
    Public Function RemoveCharacters(ByVal strTextboxValue As String) As String

        Dim newString As String = strTextboxValue

        For Each character In strTextboxValue
            If Not Char.IsNumber(character) Then

                newString = Replace(strTextboxValue, character, "")

            End If
        Next

        Return newString
    End Function

End Module
