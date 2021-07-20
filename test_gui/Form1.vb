Public Class frmMain

    Public comportIssue As Boolean = False
    Private strSessionUsername As String
    Private frmCurrentChildForm As Form
    Private frmPreviousChildForm As Form
    Dim transparentPanelForLocking As New TransparentPanel

    Public Enum SelectedForm As Integer
        PatientRecordsDropDown = 1
        AllPatients = 2
        MyPatients = 3
        AddPatient = 4
        InventoryDropDown = 5
        EndOfShiftCount = 6
        Inventory = 7
        Waste = 8
        Report = 9
        Discrepancies = 10
        Maintenance = 11
        Pharmacy = 12
        NewPrescription = 13
        AdhocOrder = 14
        SettingsDropDown = 15
        ConfigureUserPermissions = 16
        Discharge = 17
        ConfigureRooms = 18
        SerialPortSettings = 19
        EditPhysician = 20
        LogOut = 21
    End Enum

    '/*********************************************************************/
    '/*           SubProgram NAME: SetUserName                            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 sets the variable within this file to be the logged in users     */
    '/*  username.                                                        */
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
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub SetUserName(ByVal strUsername As String)

        strSessionUsername = strUsername

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: GetUserName                            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 gets the logged in users username                                */
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
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Public Function GetUserName() As String

        Return strSessionUsername

    End Function

    '/*********************************************************************/
    '/*           SubProgram NAME: LockSideMenu                           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 Places a transparent panel over the menu so the user is not able */
    '/*  to click on controls. Easier than disabling all buttons or removing
    '/*  handlers from buttons. plus, disabling buttons changes the colors*/
    '/*  which is not appealing to the app design.                        */
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
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub LockSideMenu()

        transparentPanelForLocking.Location = New Point(pnlLogo.Location.X, pnlLogo.Location.Y)
        transparentPanelForLocking.Size = New Size(pnlLogo.Width, 720)
        Me.Controls.Add(transparentPanelForLocking)
        '  transparentPanelForLocking.BackColor = Color.FromArgb(120, 127, 127, 127)
        transparentPanelForLocking.Visible = True
        transparentPanelForLocking.BringToFront()

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: UnlockSideMenu                         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 makes the transparent panel over the side menu of the application*/
    '/*  invisible.                                                       */
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
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub UnlockSideMenu()

        transparentPanelForLocking.Visible = False

    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: btnMenu_Click                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to iterate over the  panel on the side menu which  */
    '/*  contains buttons that are docked. The purpose of this method is to/
    '/*  determine which button is selected and indicate to the user it is*/
    '/*  selected by setting the control color to indicate it is selected */
    '/*  or is not selected.                                              */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*       all buttons listed as having a handle assignment to it      */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*              DetermineFormToOpen()                                */  
    '/*              
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender object, e event args                                      */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	ExtractFormDataForDatabase()        							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	ctlControl- a control representing all of the controls in the side*/
    '/* the side menu.                                                    */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnWaste.Click, btnUsers.Click, btnSerialPort.Click, btnReport.Click, btnMyPatients.Click, btnMaintenance.Click, btnEndOfShiftCount.Click, btnEditRooms.Click, btnEditPhysician.Click, btnDischargePatient.Click, btnDescrepancies.Click, btnConfigureInventory.Click, btnAllPatients.Click, btnAddPatients.Click, btnAdhoc.Click, btnNewPrescription.Click



        ' ensure that the colors of the buttons change accordingly. We need to know which button is clicked,
        ' and then change the backgroud tot he correct blue color. When this happens we need to change the other buttons
        ' color back to the default RGB blue of 0,0,64

        DetermineFormToOpen(CInt(sender.tag))

        Dim ctlControl As Control

        For Each ctlControl In pnlSideMenu.Controls

            If TypeName(ctlControl) = "Button" Then

                If sender.Name = ctlControl.Name Then
                    ' set the color of the control to indicate it is selected
                    If sender.backColor = Color.FromArgb(71, 103, 216) Then

                        sender.backColor = Color.FromArgb(38, 61, 147)

                    End If
                Else
                    ' set the color of the control to indicate it is not selected, so we reset the color back to the default RGB specified
                    ctlControl.BackColor = Color.FromArgb(71, 103, 216)
                End If
            End If
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: OpenChildForm                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to allow for a form to placed inside of a flow panel/
    '/*  changing the form hierarchy to be equivelent to that of a control./
    '/*  with that established, it allows for a form to be placed into any*/
    '/*  control object that we choose.                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*       DetermineFormToOpen()                                       */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             none                                                  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 frmChil- a form that needs to become placed inside of the panel  */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	OpenChildForm(frmMainForm)            							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/

    Sub OpenChildForm(ByVal frmChild As Form)

        ' this is where we dock the form as a frmChild form onto the panel
        ' if there is currently a form here we need to close it


        If Not frmPreviousChildForm Is Nothing Then
            If Not frmPreviousChildForm Is frmChild Then
                frmPreviousChildForm.Close()
                Debug.Print("We should be closing the frmChild form now")
            End If

        End If

        frmPreviousChildForm = frmChild
        'frmChild.TopMost = False
        frmChild.TopLevel = False
        ' removes boarder on form which is where someone can close the form. We will close it on button clicks instead
        frmChild.FormBorderStyle = FormBorderStyle.None

        frmChild.Parent = Me

        'add form to panel
        Me.pnlDockLocation.Controls.Add(frmChild)

        'make form visible
        frmChild.Show()

        For Each ctl In frmChild.Controls
            Debug.Print(ctl.name)
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: DetermineFormToOpen            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies what to do with the button the user has selected */
    '/* specifically, there selection indicates which form they want to see/
    '/* next. The select case statement maps the buttons to the proper forms
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      btnMenu_Click                                                */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      HideSettingsSubMenu()                                        */  
    '/*      HideInventorySubMenu()                                       */  
    '/*      OpenChildForm()                                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 intTagNum- a number placed in the tag field of all buttons in the*/ 
    '/*  left menu. This index allows us to identify exactly which button */
    '/*  sender is and what we need to do next with that information.     */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	DetermineFormToOpen(tagNum)            							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    intValue- integer value from the button tag field             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/

    Public Sub DetermineFormToOpen(ByVal intTagNum As Integer)

        ' based on the button that is clicked this is where we decide
        ' which form we need to open
        Dim intValue As Integer = intTagNum
        Debug.Print(intValue)

        Select Case intValue

            Case SelectedForm.PatientRecordsDropDown

                'nothing will happen here because we have a submenu that needs to be displayed to show more buttons
                'more buttons will be shown and we will take the tag num of those to determine which form to dock

            Case SelectedForm.AllPatients

                frmCurrentChildForm = frmPatientRecords
                OpenChildForm(frmPatientRecords)

            Case SelectedForm.MyPatients

                frmCurrentChildForm = frmMyPatients
                OpenChildForm(frmMyPatients)

            Case SelectedForm.AddPatient

                frmCurrentChildForm = frmNewPatient
                OpenChildForm(frmNewPatient)

            Case SelectedForm.InventoryDropDown

                'nothing will happen here because we have a submenu that needs to be displayed to show more buttons
                'more buttons will be shown and we will take the tag num of those to determine which form to dock

            Case SelectedForm.EndOfShiftCount

                frmCurrentChildForm = frmEndOfShift
                OpenChildForm(frmEndOfShift)

            Case SelectedForm.Inventory

                frmCurrentChildForm = frmInventory
                OpenChildForm(frmConfigureInventory)

            Case SelectedForm.Waste

                frmCurrentChildForm = frmMainScreenWaste
                OpenChildForm(frmMainScreenWaste)

            Case SelectedForm.Report

                frmCurrentChildForm = frmReport
                OpenChildForm(frmReport)
                HideSubMenu(pnlSubMenuSettings)
                HideSubMenu(pnlSubMenuPatientRecords)
                HideSubMenu(pnlSubMenuInventory)
                HideSubMenu(pnlSubMenuPharmacy)

            Case SelectedForm.Discrepancies

                frmCurrentChildForm = frmDiscrepancies
                OpenChildForm(frmDiscrepancies)
                HideSubMenu(pnlSubMenuSettings)
                HideSubMenu(pnlSubMenuPatientRecords)
                HideSubMenu(pnlSubMenuInventory)
                HideSubMenu(pnlSubMenuPharmacy)

            Case SelectedForm.Maintenance

                frmCurrentChildForm = frmMaintenance
                OpenChildForm(frmMaintenance)
                HideSubMenu(pnlSubMenuSettings)
                HideSubMenu(pnlSubMenuPatientRecords)
                HideSubMenu(pnlSubMenuInventory)
                HideSubMenu(pnlSubMenuPharmacy)

            Case SelectedForm.Pharmacy

              '  frmCurrentChildForm = frmPharmacy
                ' OpenChildForm(frmPharmacy)
                '  HideSubMenu(pnlSubMenuSettings)
                ' HideSubMenu(pnlSubMenuPatientRecords)
               ' HideSubMenu(pnlSubMenuInventory)

            Case SelectedForm.NewPrescription

                frmCurrentChildForm = frmAdHockDispense
                OpenChildForm(frmPharmacy)

            Case SelectedForm.AdhocOrder

                frmCurrentChildForm = frmAdHockDispense
                OpenChildForm(frmAdHockDispense)

            Case SelectedForm.SettingsDropDown

                'nothing will happen here because we have a submenu that needs to be displayed to show more buttons
                'more buttons will be shown and we will take the tag num of those to determine which form to dock

            Case SelectedForm.ConfigureUserPermissions

                frmCurrentChildForm = frmConfiguration
                OpenChildForm(frmConfiguration)

            Case SelectedForm.Discharge

                frmCurrentChildForm = frmDischarge
                OpenChildForm(frmDischarge)

            Case SelectedForm.ConfigureRooms

                frmCurrentChildForm = frmConfigureRooms
                OpenChildForm(frmConfigureRooms)

            Case SelectedForm.SerialPortSettings

                frmCurrentChildForm = frmSerialPort
                OpenChildForm(frmSerialPort)

            Case SelectedForm.EditPhysician

                frmCurrentChildForm = frmEditPhysician
                OpenChildForm(frmEditPhysician)

            Case SelectedForm.LogOut

                'call method here to ask if we are sure that we really want to log out of the system
                Me.Hide()
                frmLoginScan.Show()
                '   Case 9
                '      frmCurrentChildForm = frmAdminSettings
                '     OpenChildForm(frmAdminSettings)
        End Select

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: frmMain_Load                   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies what to do when the form loads for the first time*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                                                   */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*       CreateDatabase.Main()                                       */  
    '/*       AssignHandlersToSubMenuItems()                              */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*  NP     4/7/2021   Made a test to see if there are issues with the*/
    '/*                    COM port when a user logins.                   */
    '/*********************************************************************/
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'the following gets the COM port settings and testing to see if the 
        'COM port that would be used exisits.   
        Dim testingForm = New frmFullCart
        Dim allPorts = IO.Ports.SerialPort.GetPortNames
        testingForm.gettingConnectionSettings()
        If Not allPorts.Contains(testingForm.comPort) Then
            comportIssue = True
        End If

        'MessageBox.Show(comportIssue)
        ' assing labels to contain the logged in user's name. 
        ' assign a tooltip because truncation of the username may need to happen. We need to fix the max length 
        ' that can display on the UI
        Dim strLoggedInAs = "Logged in as " & LoggedInUsername
        lblCurrentUser.BringToFront()
        lblCurrentUser.Visible = True
        lblCurrentUser.Text = TruncateString(15, LoggedInUsername)
        tpMultiPurposeTooltip.SetToolTip(lblCurrentUser, strLoggedInAs)
        tpMultiPurposeTooltip.SetToolTip(pbLogin, strLoggedInAs)

        ' check user permissions
        CheckUserPermissions(LoggedInPermission)

        'set submenu to be invisible on form load
        pnlSubMenuSettings.Visible = False
        pnlSubMenuInventory.Visible = False
        pnlSubMenuPharmacy.Visible = False

        AssignHandlersToSubMenuButtons(pnlSubMenuInventory)
        AssignHandlersToSubMenuButtons(pnlSubMenuSettings)
        AssignHandlersToSubMenuButtons(pnlSubMenuPatientRecords)
        AssignHandlersToSubMenuButtons(pnlSubMenuPharmacy)

        'set the patient records form to be selected on default application startup
        pnlSubMenuPatientRecords.Visible = True
        btnAllPatients.PerformClick()

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: CheckUserPermissions           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/30/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies what the user's current access level is and shows*/
    '/*  then calls to out to display only the relevant controls          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          frmLoad                                                  */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ShowOnlyPermittedScreens                                     */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 permissionlevel as String  */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/30/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub CheckUserPermissions(ByVal permissionLevel As String)

        Const ADMINACCESS = "Admin"
        Const SUPERVISORACCESS = "Supervisor"
        Const NURSEACCESS = "Nurse"

        ' Dim arrBUttonsToRemoveAdmin() = {btnWaste} ' btn waste is not eneded on the side menu currently but easy to add back on as needed
        Dim arrButtonsToRemoveSupervisor() = {btnSerialPort}
        Dim arrButtonsToRemoveNurse() = {btnUsers, btnSerialPort, btnEditPhysician, btnNewPrescription, btnMaintenance, btnDescrepancies, btnConfigureInventory, btnEndOfShiftCount}

        If String.Equals(ADMINACCESS, permissionLevel) Then
            ' ShowOnlyPermittedScreens(arrBUttonsToRemoveAdmin)

        ElseIf String.Equals(SUPERVISORACCESS, permissionLevel) Then

            ' remove controls that are in the super visor access level
            '  ShowOnlySupervisorControls()
            ShowOnlyPermittedScreens(arrButtonsToRemoveSupervisor)

        ElseIf String.Equals(NURSEACCESS, permissionLevel) Then
            ' remove the controls that are not in the nurse access level
            ' ShowOnlyNurseControls()
            ShowOnlyPermittedScreens(arrButtonsToRemoveNurse)

        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: ShowOnlyPermittedScreens       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/30/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This hides buttons on the main form from a list.                 */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          frmLoad                                                  */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ShowOnlyPermittedScreens                                     */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 arrButtonsToRemove is an array of buttons                        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/30/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub ShowOnlyPermittedScreens(ByVal arrButtonsToRemove() As Button)

        ' array of buttons a supervisor does NOT have access to
        'Dim arrButtonsToRemoveSupervisor() = {btnUsers, btnEditPhysician, btnSerialPort, btnConfigureInventory, btnEndOfShiftCount}

        For Each btn In arrButtonsToRemove

            btn.Visible = False

        Next

        ' This method needs to be called for each submenu item where we removed a button, otherwise the UI submenu will show
        ' and there will be large chunks of blue space between the submenu, and next menu item. This space is there because the control was removed
        ' this method will resize the submenu to accomedate the new menu sizes.
        ResizeSubMenuSizeAccordingToVisibleButtons(pnlSubMenuInventory)
        ResizeSubMenuSizeAccordingToVisibleButtons(pnlSubMenuPatientRecords)
        ResizeSubMenuSizeAccordingToVisibleButtons(pnlSubMenuSettings)
        ResizeSubMenuSizeAccordingToVisibleButtons(pnlSubMenuPharmacy)

    End Sub

    '/*********************************************************************/
    '/*   SubProgram NAME: ResizeSubMenuSizeAccordingToVisibleButtons     */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/30/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This resizes the panel that is passed in. When buttons are removed/
    '*/  from the panel, the panel still is set to be the original size.   /
    '/*  this leaves extraspace between the next Main menu item and itemsin/
    '/*  submenu. This method resizes the panel based on the number of btns/
    '*/  that the control currently contains.                              /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          ShowOnlyPermittedScreens                                 */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 pnlSubMenu- the panel which is a submenu containing buttons      */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/30/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub ResizeSubMenuSizeAccordingToVisibleButtons(ByVal pnlSubMenu As Panel)

        ' the target size of the control we need will be the submenus current width, but we need to adjust the height based on
        ' the number of buttons within the sub menu.

        ' size = new Size(current width of the sub panel, (buttonCount * (buttonHeight + padding))
        Dim ctl As Control = Nothing
        Dim visibleCount As Integer = 0
        Dim padding As Integer = 2
        Dim btnHeight As Integer

        ' need the number of visible controls to know which size to make the submenu panel that the buttons sit in
        For Each ctl In pnlSubMenu.Controls
            ' get the number of visible buttons
            If ctl.Visible = True Then
                visibleCount += 1
                btnHeight = ctl.Size.Height
            End If

        Next

        Dim newHeight As Integer = visibleCount * (btnHeight + padding)
        pnlSubMenu.Size = New Size(pnlSubMenu.Width, newHeight)

    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: btnSettings_Click              */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies what to do when the settings button is clicked   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          none                                                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ShowOrHideSubMenu                                            */ 
    '/*      HideSubMenu                                                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click

        HideSubMenu(pnlSubMenuInventory)
        HideSubMenu(pnlSubMenuPatientRecords)
        HideSubMenu(pnlSubMenuPharmacy)
        ShowOrHideSubMenu(pnlSubMenuSettings)

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: btnSettings_Click              */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies what to do when the inventory button is clicked  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          none                                                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ShowOrHideSubMenu                                            */ 
    '/*      HideSubMenu                                                  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click

        HideSubMenu(pnlSubMenuSettings)
        HideSubMenu(pnlSubMenuPatientRecords)
        HideSubMenu(pnlSubMenuPharmacy)
        ShowOrHideSubMenu(pnlSubMenuInventory)

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: btnPatientRecords_Click        */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies what to do when the patient records button is    */
    '/*  clicked                                                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          none                                                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ShowOrHideSubMenu                                            */ 
    '/*      HideSubMenu                                                  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnPatientRecords_Click(sender As Object, e As EventArgs) Handles btnPatientRecords.Click

        HideSubMenu(pnlSubMenuSettings)
        HideSubMenu(pnlSubMenuInventory)
        HideSubMenu(pnlSubMenuPharmacy)
        ShowOrHideSubMenu(pnlSubMenuPatientRecords)

    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: btnPharmacy_Click              */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies what to do when the patient records button is    */
    '/*  clicked                                                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          none                                                     */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ShowOrHideSubMenu                                            */ 
    '/*      HideSubMenu                                                  */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                                     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnPharmacy_Click(sender As Object, e As EventArgs) Handles btnPharmacy.Click

        HideSubMenu(pnlSubMenuSettings)
        HideSubMenu(pnlSubMenuInventory)
        HideSubMenu(pnlSubMenuPatientRecords)
        ShowOrHideSubMenu(pnlSubMenuPharmacy)

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: HideSubMenu                    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This forces the submenu to be hidden                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*       determine form to open                                      */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ResetButtonColorsAfterClosingTab                             */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	      ShowOrHideSettingsSubMenu                     			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub HideSubMenu(ByVal PanelToHide As Panel)

        If PanelToHide.Visible = True Then
            PanelToHide.Visible = False
            ResetButtonColorsAfterClosingTab(PanelToHide)
        End If

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: ShowOrHideSettingsSubMenu      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies whether the sub menu needs to be shown           */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          btnInventory_Click                                       */  
    '/*          btnPatientRecords_Click                                  */ 
    '/*          btnSettings_Click                                        */ 
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*      ResetButtonColorsAfterClosingTab                             */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	      ShowOrHideInventorySubMenu                     			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	    none                                                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub ShowOrHideSubMenu(ByVal PanelToShowOrHide As Panel)

        If PanelToShowOrHide.Visible = False Then

            PanelToShowOrHide.Visible = True
        Else
            PanelToShowOrHide.Visible = False
            ResetButtonColorsAfterClosingTab(PanelToShowOrHide)

        End If

    End Sub



    '/*********************************************************************/
    '/*                   SubProgram NAME: AssignHandlersToSubMenuButtons */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This identifies all of the buttons in a submenu on the menu      */
    '/*  system and assigns it to be a a different back color than the rest/
    '/*  of the  menu items. It also assigns the click event dynamically to/
    '/*  so as new sub menu buttons are added, there colors are automatically
    '/*  handled here and their functionality is correct.                 */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          frmMain_Load                                             */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	PanelSubMenu which is a panel object on the form                  */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	      AssignHandlersToSubMenuItems()                   			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/* btnButton- a control object that will be casted to contain a button/
    '/* ctlControl- a control object that will represent buttons          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub AssignHandlersToSubMenuButtons(ByVal PanelSubMenu As Panel)

        Dim ctlControl As Control
        Dim btnButton As Button

        ' iterating over all of the submenu panels
        For Each ctlControl In PanelSubMenu.Controls
            If TypeName(ctlControl) = "Button" Then

                'cast to a button allowing access to button properties
                btnButton = CType(ctlControl, Button)

                AddHandler btnButton.Click, AddressOf SubMenu_Click

            End If
        Next

    End Sub


    '/*********************************************************************/
    '/*                   SubProgram NAME: SubMenu_Click                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is called everytime a button in the submenu is clicked.     */
    '/* when this happens, the back color needs to be updated depending if*/
    '/* if the user is selecting the button or selecting a new one        */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*          AssignHandlersToSubMenuItems                             */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	      AssignHandlersToSubMenuItems()                   			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/* btnButton- a control object that will be casted to contain a button/
    '/* ctlControl- a control object that will represent buttons          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub SubMenu_Click(sender As Object, e As EventArgs)

        'changes the background color when the mouse clicks the submenu buttons

        Dim arrPanels As Panel() = {pnlSubMenuSettings, pnlSubMenuPatientRecords, pnlSubMenuInventory, pnlSubMenuPharmacy}
        ' arrPanels = 

        Dim ctlControl As Control
        Dim btnButton As Button

        ' iterating over all of the submenu panels
        For Each pnl In arrPanels

            For Each ctlControl In pnl.Controls
                If TypeName(ctlControl) = "Button" Then

                    ' cast to a button
                    btnButton = CType(ctlControl, Button)

                    ' set the backcolor of the control depending on the current back color of it
                    If sender.Name = ctlControl.Name Then

                        If sender.backColor = Color.FromArgb(60, 80, 150) Then
                            sender.ForeColor = Color.Black
                            sender.BackColor = Color.White
                            sender.FlatAppearance.BorderSize = 0
                        End If
                    Else
                        btnButton.BackColor = Color.FromArgb(60, 80, 150)
                        btnButton.ForeColor = Color.White
                        btnButton.FlatAppearance.BorderSize = 1
                    End If

                End If
            Next
        Next

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: ResetButtonColorsAfterClosingTab       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is called everytime a button in the submenu is clicked.     */
    '/* when this happens, the back color needs to be updated depending if*/
    '/* if the user is selecting the button or selecting a new one        */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*          ShowOrHideSettingsSubMenu                                */     
    '/*          HideSettingsSubMenu                                      */   
    '/*          ShowOrHideInventorySubMenu                               */     
    '/*          HideInventorySubMenu                                     */  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	      AssignHandlersToSubMenuItems()                   			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/* ctlControl- a control object that will represent buttons          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub ResetButtonColorsAfterClosingTab(pnl As Panel)

        Dim ctlControl As Control

        For Each ctlControl In pnl.Controls
            ctlControl.BackColor = Color.FromArgb(60, 80, 150)
            ctlControl.ForeColor = Color.White
        Next

    End Sub



    '/*********************************************************************/
    '/*           SubProgram NAME: btnLogout_Click                        */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '*/  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*        */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        ' not commenting because functionality will change as the form that the program starts up with is going to
        ' to change and this functionality will too.


        frmLoginScan.Show()
        Me.Close()

    End Sub


    Public isDragging As Boolean = False, isClick As Boolean = False
    Public startPoint, firstPoint, lastPoint As Point


    '/*********************************************************************/
    '/*           SubProgram NAME: TopBar_MouseDown                        */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the mouse down event occurs on the menu bar, the program will/
    '/*  record the starting location and set the isDragging bln as true to/
    '/*  to indicate that an item is being moused down and dragged        */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '*/  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- mouseeventargs indicating there is a mouse event handle       */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*        */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier 3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub TopBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlTopBar.MouseDown, pnlTopBarContrast.MouseDown

        startPoint = pnlTopBar.PointToScreen(New Point(e.X, e.Y))
        firstPoint = startPoint
        isDragging = True

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: TopBar_MouseMove                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 If the user is dragging the mouse after clicking the menu bar,then/
    '/*  the end point will be where the user lets go of the mouse. Me, will
    '/*  move the form to the specified location.                          /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '*/  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- mouseeventargs indicating there is a mouse event handle       */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  endPoint- a point variable to hold coordinates of controls       */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub TopBar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlTopBar.MouseMove, pnlTopBarContrast.MouseMove

        If isDragging Then
            Dim endPoint As Point = pnlTopBar.PointToScreen(New Point(e.X, e.Y))
            isClick = False
            Me.Left += (endPoint.X - startPoint.X)
            Me.Top += (endPoint.Y - startPoint.Y)
            startPoint = endPoint
            lastPoint = endPoint
        End If

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: TopBar_MouseUp                         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the user is no longer clicking and dragging this gets called*/
    '/*  dragging becomes false and we check if the lastPoint is the start*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '*/  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*        */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub TopBar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlTopBar.MouseUp, pnlTopBarContrast.MouseUp

        isDragging = False
        If lastPoint = startPoint Then isClick = True Else isClick = False

    End Sub






End Class
