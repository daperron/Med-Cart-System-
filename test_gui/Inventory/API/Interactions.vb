Imports RestSharp
Imports Newtonsoft.Json.Linq
Imports System.Text

Module Interactions
    '/***************************************************************************/
    '/*                   FILE NAME: Interactions.vb                            */
    '/***************************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				                */
    '/***************************************************************************/
    '/*              WRITTEN BY:  Alexander Beasecker   		                */
    '/*		         DATE CREATED: January 25, 2021			                    */
    '/***************************************************************************/
    '/*  MODULE PURPOSE:								                        */
    '/*	The purpose of this is to handle all drug interactions in the           */
    '/* program. It will handle parsing the interactions from the               */
    '/* Rxnorm API and storing them into the database. It will also handle      */
    '/* alerting the user of an interactions between drugs that are             */
    '/* being dispensed and others the patient is prescribed.                   */
    '/*                                                                         */
    '/***************************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			            */
    '/*                         (NONE)	                                        */
    '/***************************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                        */
    '/*                        (NOTHING)					                    */
    '/***************************************************************************/
    '/* SAMPLE INVOCATION:								                        */
    '/*											                                */
    '/* the program will invoke this module when the program is pulling         */
    '/* new and/or updating drug information from the RXnorm API. this module   */
    '/* will then use the API information to update and insert new              */
    '/* drug interactions into the database. The program will also invoke       */ 
    '/* this module when a user clicks to dispense a medication. When the       */ 
    '/* dispense option is clicked this module will be invoked to check the     */
    '/* database for any drug interactions between the dispensed drug and       */
    '/* any other medications that the patient is prescribed and push           */
    '/* and alert to the screen for any found interactions                      */
    '/***************************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                        */
    '/*						  	 (NONE)			                                */
    '/***************************************************************************/
    '/* COMPILATION NOTES:								                        */
    '/* 											                            */
    '/* This project compiles normally under Microsoft Visual Basic.            */
    '/* All one needs to do Is open up the Solver project And compile.          */
    '/* No special compile options Or optimizations were used.  No              */
    '/* unresolved warnings Or errors exist under these compilation             */
    '/* conditions.									                            */
    '/******************************************************************        */
    '/* MODIFICATION HISTORY:						                            */
    '/*											                                */
    '/*  WHO                     WHEN        WHAT						        */
    '/*  Alexander Beasecker    1/25/2021   Initial creation                    */
    '*/  Dillen Perron          2/3/2021    Added Interaction function          */
    '/***************************************************************************/



    '/*********************************************************************/
    '/*                   FUNCTION NAME:  getDrugInteraction              */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/3/2021         		              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This function Is responsible for taking an rxui number and        */
    '/* check durg interactions                                           */
    '/*											                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/* 			                                                      */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*       								                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*    getDrugInteraction("153010", "2760")					          */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*	 url - holds a link to the api with the selected rxui             */
    '/*  restClient -			                                          */
    '/*  restRequest - 			                                          */
    '/*  result - holds the result of the api call (json format)          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '/*  Dillen  02/3/21  Function that check Interations                 */
    '/*  Dillen  02/9/21  Added way to choose json Property to pull       */
    '/*                   from Interaction API                            */
    '/*********************************************************************/
    '/*  NP      02/9/2021 Added a return that returns the result to      */
    '/*                    remove the function has no return warning.     */
    '/********************************************************************/

    Function getDrugInteraction(rxcuiNum1 As String, rxcuiNum2 As String) As String
        Dim trawledResult As JToken
        frmInventory.txtStatus.Text = "Checking network connectivity"
        ' Insert functionality to check the network connectivity
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            'URL for finding interactions 
            Dim url As String = strSite & "interaction/list.json?rxcuis=" & rxcuiNum1 & "+" & rxcuiNum2
            'location in json of properties
            Dim trawlPointer As String = "$.interactionTypeGroup.interactionType.interactionPair"
            'inputJSON
            Dim inputJSON As JToken = rxNorm.GetJSON(url)
            'set Jtoken into array to pull data from json
            trawledResult = inputJSON.SelectToken(trawlPointer)

            Return trawledResult
        Else
            Return trawledResult
        End If
    End Function


    '/*********************************************************************/
    '/*                   FUNCTION NAME:   getInteractionsByName          */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/18/2021         		              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This function Is responsible for taking an rxui number and        */
    '/* check durg interactions                                           */
    '/*											                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/* 			                                                      */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*       								                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/* getInteractionsByName("153008", myPropertyNameList)	              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*	 url - holds a link to the api with the selected rxui             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '/*  Dillen  02/18/21  Function that check Interations                */
    '/*  Dillen  02/25/21  Added functionality to return                  */
    '/*********************************************************************/
    Function getInteractionsByName(rxcuiNum As String, propertyNames As List(Of String)) As List(Of (PropertyName As String, PropertyValue As String))
        Dim myReturnList As New List(Of (PropertyName As String, PropertyValue As String))
        Dim strName As String
        Dim strValue As String
        frmInventory.txtStatus.Text = "Checking network connectivity"
        ' Insert functionality to check the network connectivity
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            frmInventory.txtStatus.Text = "Retrieving interactions via web API."
            'URL for finding interactions 
            Dim url As String = (strSite & "interaction/interaction.json?rxcui=" & rxcuiNum)
            'location in json of properties
            Dim trawlPointer As String = "$.interactionTypeGroup[0].interactionType[0].interactionPair"
            'inputJSON
            Dim inputJSON As JToken = rxNorm.GetJSON(url)
            'set Jtoken into array to pull data from json
            Dim JsonJArray As JArray = inputJSON.SelectToken(trawlPointer)
            Dim JsonJArrayRxcui As JArray = New JArray
            'Stores our List of properties selected 

            Dim intCounter As Integer = 0
            'Pulls out the data at our specified trawlPointer to retrieve severity, description, and rxcui
            For Each propertyName As String In propertyNames
                For Each item As JObject In JsonJArray
                    For Each subItem As JProperty In item.Children
                        'this should return the property names severity and description
                        For Each propertyIdentifier In propertyNames
                            If subItem.Name.ToString.ToUpper = propertyIdentifier.ToUpper Then
                                strName = subItem.Name
                                strValue = subItem.Value
                                myReturnList.Add((strName, strValue))
                            End If
                        Next
                        frmProgressBar.UpdateLabel("Retrieving Interactions " & intCounter & " of " & propertyNames.Count)
                    Next
                    'parses json for rxcui this will return both what drug is searched and what drug it interacts with
                    JsonJArrayRxcui = item("interactionConcept")
                    For Each interactionConcept In JsonJArrayRxcui
                        For Each minConceptItem In interactionConcept
                            For Each values In minConceptItem
                                If values("rxcui") IsNot Nothing Then
                                    If values("rxcui").ToString <> rxcuiNum Then
                                        strName = "rxcui" ' subItem.First.Value.Last.First.First.First.Name
                                        strValue = values("rxcui") 'subItem.First.Value.Last.First.First.First.Value
                                        myReturnList.Add((strName, strValue))
                                    End If
                                End If
                            Next
                            frmProgressBar.UpdateLabel("Retrieving Interactions " & intCounter & " of " & propertyNames.Count)
                        Next
                    Next
                Next
                frmProgressBar.UpdateLabel("Retrieving Interactions " & intCounter & " of " & propertyNames.Count)
                frmInventory.txtStatus.Text = ("Retrieving Interactions " & intCounter & " of " & propertyNames.Count)
                intCounter += 1
            Next

            Return myReturnList
        Else
            myReturnList.Add(("Error", strSite)) ' this is where we handle the error
        End If
    End Function


    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:GetInteractionsDispense           */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   02/25/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE: The purpose of this subroutine is to display a 
    '/* messagebox to the screen that contains a list of all interactions
    '/* that the selected drug as with other meds the patient is prescribed
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  Adhoc.InsertAdHoc()								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*  strbSQL.Append()
    '/* strbSQL.Clear()
    '/* CreateDatabase.ExecuteScalarQuery
    '/* CreateDatabase.ExecuteSelectQuery
    '/* MessageBox.Show
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   
    '/*											   
    '/* intMedicationRXCUI		
    '/* IntPatientMRN
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   
    '/*											                           
    '/*   GetInteractionsDispense("12345","2255")
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/* dsPatientInteractions
    '/* intMEDID
    '/* intPatientID
    '/* strDrugoneName
    '/* strDrugtwoName
    '/* strbInteractionsString
    '/* strbSQL
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  02/25/21  Initial creation of the code      */
    '/*********************************************************************/
    Public Sub GetInteractionsDispense(ByRef intMedicationRXCUI As Integer, ByRef IntPatientMRN As Integer)

        Dim strbSQL As StringBuilder = New StringBuilder
        Dim intMEDID As Integer
        Dim intPatientID As Integer
        Dim dsPatientInteractions As DataSet
        Dim strbInteractionsString As StringBuilder = New StringBuilder
        Dim strDrugoneName As String
        Dim strDrugtwoName As String
        'using RXCUI get the medication ID from the database to use to find the interactions
        strbSQL.Append("SELECT Medication_ID FROM Medication WHERE RXCUI_ID = '" & intMedicationRXCUI & "'")
        intMEDID = CreateDatabase.ExecuteScalarQuery(strbSQL.ToString)
        strbSQL.Clear()
        'using MRN number get patient ID for getting prescribed meds for interactions
        strbSQL.Append("SELECT Patient_ID FROM Patient WHERE MRN_Number = '" & IntPatientMRN & "'")
        intPatientID = CreateDatabase.ExecuteScalarQuery(strbSQL.ToString)
        strbSQL.Clear()

        strbSQL.Append("Select Medication_One_ID,Medication_Two_ID,Severity,Description From Drug_Interactions ")
        strbSQL.Append("Inner join Medication ")
        strbSQL.Append("ON Medication.Medication_ID = Drug_Interactions.Medication_One_ID ")
        strbSQL.Append("Inner Join PatientMedication ")
        strbSQL.Append("ON PatientMedication.Medication_TUID = Drug_Interactions.Medication_One_ID ")
        strbSQL.Append("WHERE PatientMedication.Patient_TUID = '" & intPatientID & "' ")
        strbSQL.Append("AND PatientMedication.Active_Flag = '1'")
        strbSQL.Append("AND Drug_Interactions.Active_Flag = '1'")
        dsPatientInteractions = CreateDatabase.ExecuteSelectQuery(strbSQL.ToString)


        For Each dr As DataRow In dsPatientInteractions.Tables(0).Rows
            strbSQL.Clear()
            strbSQL.Append("SELECT Drug_Name FROM Medication WHERE Medication_ID = '" & dr(0) & "'")
            strDrugoneName = CreateDatabase.ExecuteScalarQuery(strbSQL.ToString)
            strbSQL.Clear()
            strbSQL.Append("SELECT Drug_Name FROM Medication WHERE Medication_ID = '" & dr(1) & "'")
            strDrugtwoName = CreateDatabase.ExecuteScalarQuery(strbSQL.ToString)

            strbInteractionsString.AppendLine(strDrugoneName & " interacts with " & strDrugtwoName)
            strbInteractionsString.AppendLine("Severity: " & dr(2))
            strbInteractionsString.AppendLine("Descriptions: " & dr(3))
            strbInteractionsString.AppendLine("")
            frmProgressBar.UpdateLabel("Checking interaction records")
        Next

        If (strbInteractionsString.Length > 0) Then
            MessageBox.Show(strbInteractionsString.ToString)
        Else
        End If

    End Sub

    '/*******************************************************************/
    '/*               SUBROUTINE NAME:         DrugInteractionOverride	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*		         DATE CREATED: 	   03/30/21							*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	 The purpose of this subroutine is to handle the code behind drug
    '/*  interaction overrides. When the user dispense a medication, whether
    '/*  ad hoc or regular dispensing, this sub routine will be called. */
    '/*  The medication rxcui, patient mrn, form name are passed to this
    '/*  subroutine. Next, the patient is selected from the table where the
    '/*  MRN equals the one sent in by the user. The routine then looks */
    '/*  for all medication prescribed to the patient. If an interaction*/
    '/*  is found, then the strInteraction variable is set to true. When*/
    '/*  it is true, the drug interaction override pop up is available to 
    '/*  the user. If the user chooses to override the drug, an entry is*/
    '/*  added to the drug interaction override table.                  */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*  frmAdHockDispense.btnDispense_Click                            */
    '/*  frmDispense.btnDispense_Click_1                                */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*  ExecuteScalerQuery 											*/
    '/*  ExecuteSelectQuery 											*/
    '/*  ExecuteInsertQuery             `                               */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*  strMedRXCUIFromForm - Stores the RXCUI on the dispense or ad   */
    '/*                        hoc form                                 */
    '/*  strPatientMRNFromForm - Stores the MRN from the dispense or ad */
    '/*                          ad hoc form                            */
    '/*  strForm - Stores the name of the form that called the routine  */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/* DrugInteractionOverride("11111", "121212", "frmDispense")   	*/	
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/*  blnInteraction - Stores whether an interaction was found in the*/
    '/*                   database                                      */
    '/*  dsDataset - Used to store data sets returned from querying the */
    '/*              database                                           */
    '/*  intPatientID - Stores the patient ID passed to the routine     */
    '/*  objReferencingForm - Stores an object of what form we're referencing
    '/*  strArray - Stores the split RXCUI from the dropdown list       */
    '/*  strInteraction - Stores one interacting drug with the selected */
    '/*                   drug                                          */
    '/*  strLabel1Text - Stores the text for Label1                     */
    '/*  strMedicationOneRXCUI - Stores the first medication rxcui      */
    '/*  strSQLCmd - Stores the SQL command to query the database       */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/*  WHO   WHEN     WHAT											*/
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH  03/30/21  Initial creation of the code					*/
    '/*  BRH  04/01/21  Fixed issue where the medication wouldn't   	*/  
    '/*                 dispense if no interactions were found.         */
    '/*  BRH  04/02/21  Add interaction checking for dispensing and fixed/
    '/*                 the text on the drug overrides                  */
    '/*******************************************************************/
    Public Sub DrugInteractionOverride(strMedRXCUIFromForm As String, strPatientMRNFromForm As String, strForm As String)

        Dim blnInteraction As Boolean = False
        Dim dsDataset As New DataSet
        Dim intPatientID As Integer
        'split out the RXCUI and name
        Dim objReferencingForm As Object
        Dim strArray() As String
        Dim strInteraction As String
        Dim strLabel1Text As String
        Dim strMedicationOneRXCUI As String
        Dim strMedicationTwoRXCUI As String
        Dim strSQLCmd As String

        'Select the patient id given the mrn
        strSQLCmd = "Select Patient_ID From Patient 
                    WHERE MRN_Number = '" & strPatientMRNFromForm & "';"

        intPatientID = ExecuteScalarQuery(strSQLCmd)

        'The medication name is shown differently
        'depending on the form. Therefore, we
        'have to parse out the desired data differently
        If strForm = "Dispense" Then
            'strMedicationOneRXCUI = strMedRXCUIFromForm
            'strArray = strMedicationOneRXCUI.Split("--")
            'strMedicationOneRXCUI = strArray(2)
            strMedicationOneRXCUI = ExecuteScalarQuery("SELECT RXCUI_ID FROM Medication WHERE Medication_ID = " & strMedRXCUIFromForm & ";")
            strLabel1Text = frmPatientInfo.strMedName
            objReferencingForm = frmPatientInfo

        ElseIf strForm = "AdHoc" Then
            strMedicationOneRXCUI = strMedRXCUIFromForm
            strArray = strMedicationOneRXCUI.Split(":")
            strMedicationOneRXCUI = strArray(1)
            strLabel1Text = frmAdHockDispense.cmbMedications.SelectedItem.ToString
            objReferencingForm = frmAdHockDispense

        End If

        'Select the rxcui from the selected medication
        strSQLCmd = "Select RXCUI_ID From Medication 
                    INNER JOIN PatientMedication ON Medication_TUID = Medication_ID 
                    INNER JOIN Patient ON Patient_TUID = Patient_ID
                    WHERE MRN_Number = '" & strPatientMRNFromForm & "';"

        dsDataset = ExecuteSelectQuery(strSQLCmd)

        'Try to find any interactions with the selected medication
        For Each item In dsDataset.Tables(0).Rows
            strSQLCmd = "SELECT Drug_Interactions_ID FROM Drug_Interactions
                         WHERE Medication_One_ID = " & item(0) & "
                         AND Medication_Two_ID = " & strMedicationOneRXCUI & "
                         OR Medication_Two_ID = " & item(0) & "
                         AND Medication_One_ID = " & strMedicationOneRXCUI & ";"

            'If no Then interactions were found previously, store the 
            'rxcui of the interacting medication in strInteraction
            If blnInteraction.Equals(False) Then

                strInteraction = ExecuteScalarQuery(strSQLCmd)

                If strInteraction IsNot Nothing Then
                    blnInteraction = True
                    strMedicationTwoRXCUI = item(0)
                    'Else
                    '    blnInteraction = False
                End If
            End If
        Next


        If blnInteraction.Equals(True) Then
            'Change how the witness sign off form looks
            frmWitnessSignOff.Label5.Visible = True
            frmWitnessSignOff.Label6.Visible = True
            '  frmWitnessSignOff.Label1.AutoSize = True
            ' frmWitnessSignOff.Label2.AutoSize = True
            frmWitnessSignOff.Label1.Location = New Point(3, 34)
            frmWitnessSignOff.Label2.Location = New Point(103, 64)
            frmWitnessSignOff.Label5.Location = New Point(3, 100)
            frmWitnessSignOff.Label6.Location = New Point(3, 131)
            frmWitnessSignOff.Label1.Text = strLabel1Text
            frmWitnessSignOff.Label2.Text = "Interacts With:"
            frmWitnessSignOff.Label5.Text = ExecuteScalarQuery("SELECT Drug_Name FROM Medication WHERE RXCUI_ID =" & strMedicationTwoRXCUI & ";")
            frmWitnessSignOff.Label6.Text = "Reason: " & ExecuteScalarQuery("SELECT Description FROM Drug_Interactions WHERE Drug_Interactions_ID = " & strInteraction & ";")

            frmWitnessSignOff.referringForm = objReferencingForm
            frmWitnessSignOff.Text = "Drug Interactions Override"
            frmWitnessSignOff.ShowDialog()

            'MessageBox.Show("The drug you are trying to dispense interacts with other meds the patient's prescribed")

            'If the user chose to override the interaction, insert the record into the database
            If frmPatientInfo.blnOverride Or frmAdHockDispense.blnOverride Then
                ExecuteInsertQuery("INSERT INTO Drug_InteractionsOverride(Patient_TUID, User_TUID, Drug_Interactions_TUID, DateTime) " &
                                           "Values(" & intPatientID & ", " & LoggedInID & ", '" & strInteraction & "', '" & DateTime.Now & "')")

                If strForm = "Dispense" Then
                    frmPatientInfo.blnSignedOff = True
                ElseIf strForm = "AdHoc" Then
                    frmAdHockDispense.blnSignedOff = True
                End If

            Else
                MessageBox.Show("Dispense canceled by user.")

                If strForm = "Dispense" Then
                    frmPatientInfo.blnSignedOff = False
                ElseIf strForm = "AdHoc" Then
                    frmAdHockDispense.blnSignedOff = False
                End If

                frmPatientInfo.blnOverride = False
                frmAdHockDispense.blnOverride = False

                Exit Sub


            End If
        Else
            'If there were no interactions,
            'there is an immediate sign off
            frmAdHockDispense.blnSignedOff = True
            frmPatientInfo.blnSignedOff = True
        End If

    End Sub

End Module
