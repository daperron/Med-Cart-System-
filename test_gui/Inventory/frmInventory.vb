Imports System.Text.RegularExpressions
Public Class frmInventory

    'create event for updating loading form 
    Public Event UpdateLoadScreen(txt As String)

    Private btnSelectedDrawer As Button
    Private lstFullDrawers As List(Of Integer)
    Private transparentPanelForLocking As New TransparentPanel

    Public Sub SetSelectedDrawer(ByVal btnDrawer As Button)

        btnSelectedDrawer = btnDrawer

    End Sub

    Public Sub SetFullDrawersList(ByVal lstDrawers As List(Of Integer))

        lstFullDrawers = lstDrawers

    End Sub

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateInventoryComboBoxes()
        cmbDrawerNumber.SelectedIndex = 0
        txtQuantity.Text = "1"
        ' setdefault text to the search box
        txtSearch.Text = txtSearch.Tag
        txtSearch.ForeColor = Color.Silver
        txtStatus.Visible = False
        'Set the focus
        txtSearch.Select()

        DefaultSaveButtonLocation()
        txtQuantity.Text = 1

        ' the button's tab index from the previous screen will allow us to know what drawer that is
        'cmbDrawerNumber.SelectedIndex = btnSelectedDrawer.TabIndex - 1
        cmbDrawerNumber.SelectedIndex = cmbDrawerNumber.FindStringExact(CStr(btnSelectedDrawer.TabIndex))
        cmbPatientNames.Items.Clear()
        Dim dsactivePatients As DataSet = CreateDatabase.ExecuteSelectQuery("Select * From Patient WHERE Active_Flag = 1 ;")
        For Each dr As DataRow In dsactivePatients.Tables(0).Rows
            cmbPatientNames.Items.Add(dr(EnumList.Patient.LastName) & ", " & dr(EnumList.Patient.FristName) & "   MRN: " & dr(EnumList.Patient.MRN_Number))
            intPatientIDArray.Add(dr(EnumList.Patient.MRN_Number))
        Next

    End Sub

    '/*********************************************************************/
    '/*               SubProgram NAME: MoveControlsIfPatientMedication    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/16/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This moves the save button to a specific location and makes the  */
    '/*  patient selection label and combobox visible.                    */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  cmbPatientPersonalMedication_SelectedIndexChanged                */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  None                                                             */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	None                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/* MoveControlsIfPatientMedication()                                 */     
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
    Public Sub MoveControlsIfPatientMedication()
        btnSave.Location = New Point(184, 75)
        pnlPatientNamePadding.Visible = True
        lblPatientName.Visible = True
    End Sub


    '/*********************************************************************/
    '/*               SubProgram NAME: DefaultSaveButtonLocation          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/16/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This moves the save button to a specific location and makes the  */
    '/*  patient selection label and combobox invisible.                  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  cmbPatientPersonalMedication_SelectedIndexChanged                */
    '/*  frmInventory_Load                                                */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  None                                                             */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*  DefaultSaveButtonLocation()                                      */     
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
    Public Sub DefaultSaveButtonLocation()
        btnSave.Location = New Point(184, 18)
        pnlPatientNamePadding.Visible = False
        lblPatientName.Visible = False
    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME: cmbPatientPersonalMedication_SelectedIndexChanged*/         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/16/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This assess what item is selected in the combobox and then calls */
    '/*  the correct method to show additional fields as necessary.       */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  MoveControlsIfPatientMedication                                  */  
    '/*  DefaultSaveButtonLocation                                        */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*  DefaultSaveButtonLocation()                                      */     
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
    Private Sub cmbPatientPersonalMedication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPersonalMedication.SelectedIndexChanged

        Const YES As String = "Yes"

        If cboPersonalMedication.SelectedItem.Contains(YES) Then
            MoveControlsIfPatientMedication()
        Else
            DefaultSaveButtonLocation()
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        frmMain.LockSideMenu()
        LockUnlock()
        btnBack.Enabled = False
        btnSave.Enabled = False
        'create an instance of the progress bar form
        'Dim thdThread1 As New Threading.Thread(AddressOf ThreadedMessageBox)
        'thdThread1.Name = strMessage
        'thdThread1.Start()
        Dim LoadingScreen As New frmProgressBar
        AddHandler UpdateLoadScreen, AddressOf LoadingScreen.UpdateLabel
        'Dim thdThread1 As New Threading.Thread(AddressOf LoadingScreen.UpdateLabel)
        'thdThread1.Name = strMessage
        'thdThread1.Start()
        'LoadingScreen.StartTask()


        Dim intControlled As Integer
        Dim intNarcotic As Integer
        Dim intDrawerMedication_ID As Integer = 0
        Dim Drawers_Tuid As Integer = 0
        Dim intMedicationTuid As Integer = 0
        Dim intMedQuanitiy As Integer = 0
        Dim intDividerBin As Integer = 0
        Dim intDiscrepancies As Integer = 0
        Dim strBarcode As String
        Dim strMessage As String
        Dim intSchedule As Integer

        If chkControlled.Checked Then
            intControlled = 1
        Else
            intControlled = 0
        End If

        If chkNarcotic.Checked Then
            intNarcotic = 1
        Else
            intNarcotic = 0
        End If

        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("please make sure amount per container is numeric")
        Else
            'Check that all fields have data entered before attempting to save into the database
            If txtStrength.Text.Equals("") Or txtType.Text.Equals("") Or mtbExpirationDate.MaskFull = False Or
            cboPersonalMedication.SelectedIndex.Equals(-1) Or mtbExpirationDate.MaskCompleted = False Or txtSchedule.Text.Equals("") Or cmbDividerBin.SelectedIndex = -1 Or
            txtAmount.Text = "" Or txtUnits.Text = "" Then
                MessageBox.Show("Please enter data in all fields before saving.")


                RaiseEvent UpdateLoadScreen("")
                LoadingScreen.Close()
                btnBack.Enabled = True
                btnSave.Enabled = True
                frmMain.UnlockSideMenu()
                LockUnlock()
                Exit Sub
            Else
                If Not IsDate(mtbExpirationDate.Text) Then
                    MessageBox.Show("Please enter a valid expiration date.")
                Else
                    Dim dtmDOByear As Date = CDate(mtbExpirationDate.Text)
                    If dtmDOByear < Date.Today Then
                        MessageBox.Show("Please enter a valid expiration date.")
                    Else
                        LoadingScreen.Show(Me)
                        changeStatusVisible()
                        RaiseEvent UpdateLoadScreen("This could take up to 3 minutes")
                        If txtBarcode.Text = Nothing Then
                            strBarcode = generateSampleBarcode()
                        Else
                            strBarcode = txtBarcode.Text
                        End If
                        CompareMedications(strName.Substring(0, strName.Length), strRXCUI, intControlled, intNarcotic, strBarcode, txtType.Text, txtStrength.Text, intSchedule, 1)

                        Try
                            If CInt(cmbDrawerNumber.SelectedItem) > 25 Or CInt(cmbDrawerNumber.SelectedItem) < 0 Then
                                MessageBox.Show("Please select an appropriate drawer number")
                            Else

                                Drawers_Tuid = CInt(cmbDrawerNumber.SelectedItem)
                                intDividerBin = CInt(cmbDividerBin.SelectedItem)
                            End If

                        Catch ex As Exception
                            eprError.SetError(cmbDrawerNumber, "please enter an integer for drawer number between 1-25")

                        End Try

                        Try
                            intMedQuanitiy = CInt(txtQuantity.Text)
                        Catch ex As Exception
                            eprError.SetError(cmbDrawerNumber, "please enter an amount that is a positive whole number")
                        End Try



                        ' search the information from the allproperties API call
                        ' double-check if the drug is in the database already
                        ' if yes, then update if there's differences
                        ' if no, then save those items
                        ' and pass it to the function to find interactions
                        'thdThread1.Start()
                        RaiseEvent UpdateLoadScreen("Retrieving drug interactions from the NIH website")
                        Dim myPropertyNameList As New List(Of String)({"severity", "description", "rxcui"})
                        Dim outputList As New List(Of (PropertyName As String, PropertyValue As String))
                        'strMessage = "Retrieving drug interactions from the NIH website"
                        'thdThread1.Name = "Loading..." 'Dim thdThread1 As New Threading.Thread(AddressOf ThreadedMessageBox)
                        'thdThread1.Name = strMessage
                        'thdThread1.Start()
                        If IsNothing(getInteractionsByName(strRXCUI, myPropertyNameList)) Then
                            MessageBox.Show("The network sites are not responding. Please check your network connection and try again.")
                        Else
                            outputList = getInteractionsByName(strRXCUI, myPropertyNameList)



                            'Double-check if the interactions with the matching pair of RXCUI's exist
                            'If yes, Then update If there's differences
                            ' Or insert the New lines
                            ' And save those items

                            Try
                                RaiseEvent UpdateLoadScreen("Saving interaction to the database")

                                strMessage = "Please wait while the interactions are saved to the database"

                                'old code look to delete later?
                                Dim thdThread2 As New Threading.Thread(AddressOf ThreadedMessageBox)
                                'thdThread2.Name = strMessage
                                'thdThread2.Start()


                                CompareDrugInteractions(CInt(strRXCUI), outputList) 'CInt(outputList.Item(i + 3).PropertyValue), outputList.Item(i).PropertyValue, outputList.Item(i + 1).PropertyValue.Replace("'", ""), 1)
                                'Next
                                RaiseEvent UpdateLoadScreen("Interactions records have been added")
                                strMessage = "All interaction records have been added"
                                Dim thdThread3 As New Threading.Thread(AddressOf ThreadedMessageBox)
                                'thdThread3.Name = strMessage
                                'thdThread3.Start()
                            Catch ex As Exception
                                MessageBox.Show("Interactions could not be recorded")
                            End Try

                            intDrawerMedication_ID = ExecuteScalarQuery("SELECT COUNT(DISTINCT DrawerMedication_ID) FROM DrawerMedication;")


                            intMedicationTuid = ExecuteScalarQuery("Select Medication_ID From Medication WHERE Drug_Name ='" & strName & "';")
                            'because we are adding a new drawermedication for now
                            intDrawerMedication_ID += 1

                            Dim strAmount As String = txtAmount.Text
                            Dim strUnit As String = txtUnits.Text
                            ExecuteInsertQuery("INSERT INTO DrawerMedication (DrawerMedication_ID,Drawers_TUID,Medication_TUID,Quantity,Amount_Per_Container,Amount_Per_Container_Unit,Divider_Bin,Expiration_Date,Discrepancy_Flag, Active_Flag) VALUES (" & intDrawerMedication_ID & ", " & Drawers_Tuid & ", " & intMedicationTuid & ", " & intMedQuanitiy & ",'" & strAmount.ToString & "','" & strUnit.ToString & "'," & intDividerBin & " , '" & mtbExpirationDate.Text & "'," & intDiscrepancies & ",1);")
                            OpenOneDrawer(Drawers_Tuid)
                            'If the user selects "Yes" in the Personal Patient medication drop down
                            'Insert the information into the PersonalPatientDrawerMedication Table
                            'in the database
                            If cboPersonalMedication.SelectedItem = "Yes" Then
                                InsertPersonalPatientMedication()
                                RaiseEvent UpdateLoadScreen("Personal Patient Medication has been added")
                            End If


                            RaiseEvent UpdateLoadScreen("Medication has been added to the drawer")
                            'MessageBox.Show("Medication has been added to the drawer")
                            Debug.WriteLine("")


                            intDividerBin = CInt(cmbDividerBin.SelectedItem)

                            eprError.Clear()

                            ClearInventoryForm()
                            changeStatusVisible()
                        End If
                    End If
                End If
            End If
        End If
        LoadingScreen.Close()
        btnBack.Enabled = True
        btnSave.Enabled = True
        frmMain.UnlockSideMenu()
        LockUnlock()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles pnlSearch.Click
        Dim myPropertyNameList As New List(Of String)({"rxcui"})
        Dim outputList As New List(Of (PropertyName As String, PropertyValue As String))
        Dim suggestedList As New List(Of String)
        Dim LoadingScreen As New frmProgressBar
        txtSearch.ReadOnly = True
        pnlSearch.Enabled = False
        frmMain.LockSideMenu()
        cboSuggestedNames.Visible = False
        txtStatus.Visible = True
        txtStatus.Text = "Please wait while we check the network connection..."
        LoadingScreen.Show(Me)
        RaiseEvent UpdateLoadScreen("This could take up to 3 minutes")
        frmMain.LockSideMenu()
        LockUnlock()
        System.Threading.Thread.Sleep(500)
        If IsNothing(GetRxcuiByName(txtSearch.Text, myPropertyNameList)) Then
            ' do nothing, this is handled in the API database selection or rxNorm modules
        Else
            outputList = GetRxcuiByName(txtSearch.Text, myPropertyNameList)
            ' check to see if anything comes back
            If outputList.Count = 0 Then
                ' if nothing, then ask to suggest names
                cboSuggestedNames.Visible = True
                If IsNothing(GetSuggestionList(txtSearch.Text)) Then
                    ' do nothing, this is handled in the API database selection or rxNorm modules
                Else
                    suggestedList = GetSuggestionList(txtSearch.Text)
                    txtStatus.Text = "Please choose from suggestions or try again."
                    ' then populate the combobox
                    cboSuggestedNames.DataSource = suggestedList
                End If
            Else
                txtStatus.Text = "Success! Please select from the list of medications"
                ' otherwise populate the medication name comboBox
                cmbMedicationName.DataSource = outputList
            End If
        End If
        LoadingScreen.Close()
        frmMain.UnlockSideMenu()
        pnlSearch.Enabled = True
        txtSearch.ReadOnly = False
        LockUnlock()
    End Sub

    Private Sub cmbMedicationName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedicationName.SelectedIndexChanged
        Dim strTrimmedString As String
        Dim strSplitString() As String
        Dim lstProperties As List(Of String) = New List(Of String)
        Dim lstResults As List(Of (strPropertyName As String, strPropertyValue As String))
        ' take the split of the combobox selected item
        strTrimmedString = cmbMedicationName.Text.ToString '.Split(","))
        ' take off the parens
        Dim intOpenParens = InStr(strTrimmedString, "(")
        Dim intClosedParens = InStr(strTrimmedString, ")")
        If intOpenParens > 0 And intClosedParens > 0 Then
            strTrimmedString = strTrimmedString.Remove(intOpenParens - 1, 1)
            strTrimmedString = strTrimmedString.Remove(intClosedParens - 2, 1) ' remove 2 because of 0 is beginning and because the open parens is gone now too
        End If
        strSplitString = strTrimmedString.Split(",")
        'Dim strParens() As String = {"(", ")"}
        ' then trim off every space that's not necessary
        For Each strItem In strSplitString
            strItem = strItem.Trim
        Next
        ' and pass it to the function to get the atrributes
        lstProperties.Add("AVAILABLE_STRENGTH")
        lstProperties.Add("STRENGTH")
        lstProperties.Add("SCHEDULE")
        frmMain.LockSideMenu()
        LockUnlock()
        If IsNothing(getRxcuiProperty(strSplitString(0), lstProperties)) Then
            MessageBox.Show("The network sites are not responding. Please check your network connection and try again.")
            frmMain.UnlockSideMenu()
            LockUnlock()
        Else
            lstResults = getRxcuiProperty(strSplitString(0), lstProperties)
            ' add the original items to the lstResults
            lstResults.Add(("RXCUI", strSplitString(0)))
            lstResults.Add(("NAME", strSplitString(1)))

            ' first clear the fields
            txtStrength.Text = ""
            txtStrength.Enabled = True
            txtSchedule.Text = ""
            txtSchedule.Enabled = True
            txtType.Text = ""
            chkControlled.Checked = False
            chkNarcotic.Checked = False
            cmbDrawerNumber.Text = ""
            cmbBin.Items.Clear()
            txtQuantity.Text = "1"
            mtbExpirationDate.Text = ""
            cmbPatientPersonalMedication.SelectedItem = ""

            ' then populate the form and pass the results on 
            For Each result In lstResults
                Select Case result.strPropertyName
                    Case "AVAILABLE_STRENGTH"
                        txtStrength.Text = result.strPropertyValue
                        txtStrength.Enabled = False
                    Case "STRENGTH"
                        txtStrength.Text = result.strPropertyValue
                        txtStrength.Enabled = False
                    Case "SCHEDULE"
                        If result.strPropertyValue Is Nothing Then
                            ' do nothing
                        ElseIf result.strPropertyValue = "1" Or result.strPropertyValue = "2" Or result.strPropertyValue = "3" Then
                            ' check the controlled and narcotic
                            chkControlled.Checked = True
                            chkNarcotic.Checked = True
                            txtSchedule.Enabled = False
                        ElseIf result.strPropertyValue = "2N" Or result.strPropertyValue = "3N" Or result.strPropertyValue = "4" Or result.strPropertyValue = "5" Then
                            ' check controlled only
                            chkControlled.Checked = True
                            txtSchedule.Enabled = False
                        ElseIf result.strPropertyValue = "0" Then
                            txtSchedule.Text = "0"
                            ' leave it enabled in case there's an error
                        Else
                            ' if the value isn't in these then it must be invalid - do nothing
                        End If
                        txtSchedule.Text = result.strPropertyValue
                End Select
            Next

            getDrugNameRxcui(lstResults)

            ' if the combo box text exceeds the box, there will be a tooltip that is provided on hover over the box with the full medication
            ' name 
            tpSelectedItem.SetToolTip(cmbMedicationName, cmbMedicationName.SelectedItem.ToString)
            txtStatus.Text = "Success! Please continue with your entry."
            frmMain.UnlockSideMenu()
            LockUnlock()
        End If
    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:txtSearch_GotFocus                                */         
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
    '/*                                    */
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

        ' when the search box gains focus, we will remove the default text only if the user has not typed in it yet
        If txtSearch.ForeColor = Color.Silver Then

            txtSearch.Text = Nothing
            ' update the color of the search text to be black
            txtSearch.ForeColor = Color.Black

        End If

    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:txtSearch_GotFocus                                */         
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
    '/*                          */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*                                     */     
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

        ' when the search box loses focus, we will check and see if they put any text in it
        ' if they didnt, we will reset it to the default text.
        If txtSearch.Text = "" Then
            'reset the text to the default and set the font color to be black
            txtSearch.Text = txtSearch.Tag
            txtSearch.ForeColor = Color.Silver
        End If

    End Sub


    '/*********************************************************************/
    '/* SubProgram NAME:txtSearch_TextChanged                             */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/26/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This method ensures that when the user selects the enter key the */
    '/* the textbox does not go to the nextline, and that it searches.    */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                          */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*                                     */     
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
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        ' detects if there has been another line added to the textbox
        ' indicating the user has selected the "enter" key
        If txtSearch.Lines.Length > 1 Then

            ' since we know the user selected enter and we are using a multiline textbox,
            ' the text input will be equal to whatever the user typed + a CRLF character
            ' we will replace that character with an empty string as if it was never typed.
            Dim singleLine = txtSearch.Text.Replace(vbCrLf, "")

            ' reset the textbox to be empty because it currently contains the user types string + CRLF
            txtSearch.Text = ""

            ' set the textbox to contain the searched word on a single line
            txtSearch.Text = singleLine

            ' by default VB will move the text cursor position to be at the first character after adding
            ' a new string to the textbox. This looks weird and seems like a bug to the user when the
            ' cursor position moves from the last character to the first. We will set to be the last 
            ' with the code below.
            txtSearch.Select(txtSearch.Text.Length, 0)


            '*********************************
            'Call method here to do the search
            '*********************************
            btnSearch_Click(sender, e)





            'set the focus to the next control because it should be populated 
            cmbMedicationName.Select()

        End If

    End Sub

    Private Sub SearchResults()
        frmProgressBar.Show()
        Dim myPropertyNameList As New List(Of String)({"rxcui"})
        Dim outputList As New List(Of (PropertyName As String, PropertyValue As String))
        If IsNothing(GetRxcuiByName(txtSearch.Text, myPropertyNameList)) Then
            MessageBox.Show("Could not connect to web APIs. Please check your connection and try again later.")
        Else
            outputList = GetRxcuiByName(txtSearch.Text, myPropertyNameList)
            If outputList.Count = 0 Then
                'outputList = GetSuggestionList(txtSearch.Text)
                ' then populate the combobox
                ' and if they click again on an item put it into the search box and search
                ' recursion 'til the cows come home
            End If
            cmbMedicationName.DataSource = outputList
            txtStatus.Text = "Drug not found. Please select from suggestions or retry search."
        End If
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Eric LaVoie           		         */   
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

    Private Sub cboSuggestedNames_SelectedItemChanged(sender As Object, e As EventArgs) Handles cboSuggestedNames.DropDownClosed
        Dim strTrimmedSelection As String = cboSuggestedNames.SelectedItem.ToString
        ' if we'd have to trim it the logic would be here

        'send the item into the search box
        txtSearch.Text = strTrimmedSelection
        ' change the visibility of the comboboxes and clear them out
        cboSuggestedNames.Visible = False
        'cboSuggestedNames.Items.Clear()
        'cmbMedicationName.Visible = True
        'cmbMedicationName.Items.Clear()
        btnSearch_Click(sender, e)
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Perron           		         */   
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
    Private Sub cmbDrawerNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrawerNumber.SelectedIndexChanged
        If Not cmbDrawerNumber.SelectedIndex = -1 Then
            cmbDividerBin.Items.Clear()
            Dim arrintBinsFilled As New ArrayList
            Dim intDrawerSize As Integer = 0
            Dim intNumDividers As Integer = 0
            Dim intDrawerNumber As Integer = CInt(cmbDrawerNumber.Text)
            Dim intCountBinsFilled As Integer
            Dim dsDividerBinsFilled As DataSet
            Try
                dsDividerBinsFilled = CreateDatabase.ExecuteSelectQuery("Select Divider_Bin from DrawerMedication where Drawers_TUID = '" & intDrawerNumber.ToString & "' AND Active_Flag = '1'")
                intCountBinsFilled = CreateDatabase.ExecuteScalarQuery("Select Count(Divider_Bin) from DrawerMedication where Drawers_TUID = '" & intDrawerNumber.ToString & "' AND Active_Flag = '1'")
                intDrawerSize = ExecuteScalarQuery("SELECT Size FROM Drawers where Drawers_ID = " & intDrawerNumber.ToString & " AND Active_Flag = '1';")
                intNumDividers = ExecuteScalarQuery("SELECT Number_of_Dividers FROM Drawers where Drawers_ID = " & intDrawerNumber.ToString & " AND Active_Flag = '1';")
            Catch ex As Exception
                ' do nothing because there are empty values in the database
            End Try
            'txtQuantity.Text = intDrawerSize.ToString

            If intCountBinsFilled = (intNumDividers + 1) Then

            Else
                For Each dr As DataRow In dsDividerBinsFilled.Tables(0).Rows
                    arrintBinsFilled.Add(dr(0))
                Next
                Dim dividerspopulation As New ArrayList(intNumDividers + 1)
                Dim intCounter As Integer = 1
                'Do Until intCounter > (intNumDividers + 1)
                '    cmbDividerBin.Items.Add(intCounter)
                '    intCounter += 1
                'Loop
                Do Until intCounter > (intNumDividers + 1)
                    dividerspopulation.Add(intCounter)
                    intCounter += 1
                Loop
                intCounter = 0

                Do Until intCounter > (arrintBinsFilled.Count - 1)
                    Dim intItem As Integer = arrintBinsFilled(intCounter)
                    If dividerspopulation.Contains(intItem) Then
                        dividerspopulation.Remove(intItem)
                    End If
                    intCounter += 1
                Loop
                intCounter = 0
                Do Until intCounter > (dividerspopulation.Count - 1)
                    cmbDividerBin.Items.Add(dividerspopulation(intCounter))
                    intCounter += 1
                Loop
            End If
        End If
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Perron          		         */   
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
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        frmConfigureInventory.PreviouslySelectedDrawer(btnSelectedDrawer)
        frmMain.OpenChildForm(frmConfigureInventory)

    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:        txtStrength_KeyPress                      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Breanna Howey       		          */   
    '/*		         DATE CREATED: 		3/01/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This assess what key is pressed and restricts the keys to the string
    '/* passed to the KeyPressCheck function.                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  KeyPressCheck                                                    */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*  txtStrength_KeyPress()                                           */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  BRH  3/01/21    Initial creation                                 */
    Private Sub txtStrength_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStrength.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz1234567890/ ")
    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:        txtType_KeyPress                          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Breanna Howey       		          */   
    '/*		         DATE CREATED: 		3/01/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This assess what key is pressed and restricts the keys to the string
    '/* passed to the KeyPressCheck function.                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  KeyPressCheck                                                    */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*  txtType_KeyPress()                                               */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  BRH  3/01/21    Initial creation                                 */
    Private Sub txtType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtType.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz1234567890/ ")
    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:        txtBarcode_KeyPress                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Breanna Howey       		          */   
    '/*		         DATE CREATED: 		3/01/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This assess what key is pressed and restricts the keys to the string
    '/* passed to the KeyPressCheck function.                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  KeyPressCheck                                                    */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*  txtBarcode_KeyPress                                              */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz1234567890/")
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Perron          		         */   
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
    Private Sub btnDrawerUp_Click(sender As Object, e As EventArgs) Handles btnDrawerUp.Click
        IndexButtonIncrement(cmbDrawerNumber.SelectedIndex, cmbDrawerNumber.Items.Count - 1, cmbDrawerNumber)
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Perron         		         */   
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
    Private Sub btnDrawerDown_Click(sender As Object, e As EventArgs) Handles btnDrawerDown.Click
        IndexButtonDecrement(cmbDrawerNumber.SelectedIndex, cmbDrawerNumber)
    End Sub


    Private Sub btnQuantityUp_Click(sender As Object, e As EventArgs) Handles btnQuantityUp.Click
        If Not IsNumeric(txtQuantity.Text) Then
            txtQuantity.Text = 0
        End If
        ButtonIncrement(1000, txtQuantity)
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Perron          		         */   
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
    Private Sub btnQuantityDown_Click(sender As Object, e As EventArgs) Handles btnQuantityDown.Click
        If Not IsNumeric(txtQuantity.Text) Then
            txtQuantity.Text = 2
        End If
        ButtonDecrement(txtQuantity)
    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Perron          		         */   
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
    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789")
        If txtQuantity.Text IsNot "" Then
            GraphicalUserInterfaceReusableMethods.MaxValue(sender.Text.ToString, 1000, txtQuantity)
        Else
        End If
    End Sub

    Private Sub txtUnits_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.")
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnits.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789.abcdefghijklmnopqrstuvwxyz/")
    End Sub
    Private Sub txtQuantity_Validated(sender As Object, e As EventArgs) Handles txtQuantity.Validated
        If txtQuantity.Text IsNot "" Then
            GraphicalUserInterfaceReusableMethods.MaxValue(sender.Text.ToString, 1000, txtQuantity)
        Else
        End If
    End Sub

    Private Sub mtbExpirationDate_Validated(sender As Object, e As EventArgs) Handles mtbExpirationDate.KeyPress
        DataVaildationMethods.KeyPressCheck(e, "0123456789")
    End Sub

    Private Sub changeStatusVisible()
        If lblStatus.Visible = True Then
            lblStatus.Visible = False
            txtStatus.Visible = False
        Else
            lblStatus.Visible = True
            txtStatus.Visible = True
        End If
    End Sub


    Public Sub PopulateInventoryComboBoxes()
        cmbDrawerNumber.Items.Clear()
        Dim dsDrawers As DataSet = CreateDatabase.ExecuteSelectQuery("Select * from Drawers where Full_Flag = '0' AND Active_Flag = '1'")
        For Each dr As DataRow In dsDrawers.Tables(0).Rows
            cmbDrawerNumber.Items.Add(dr(2))
        Next
    End Sub

    Public Sub LockUnlock()
        'If pnlTransparent.Visible = True Then
        '    pnlTransparent.Visible = False
        'Else
        '    pnlTransparent.Visible = True
        'End If
    End Sub

End Class