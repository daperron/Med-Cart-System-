Imports System.Text

Module PopulateAllergiesComboBoxMethods
    '/*********************************************************************/
    '/*                   FILE NAME: PopulatePatientComboBoxMethods          */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_Gui		        		   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		             */		  
    '/*		         DATE CREATED:	2/8/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									                   */			  
    '/*	 This contains the method to populate the patient Combo boxes on a */
    '/*  number of forms.                                                  */
    '/*********************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			   */ 
    '/*                                                    (NONE)	   */	  
    '/*********************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							   */			  
    '/*                          (NOTHING)					   */		  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */			  
    '/*											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			         */		  
    '/*						  	 (NONE)			   */					  
    '/*********************************************************************/
    '/* COMPILATION NOTES(will include version notes including libraries):*/
    '/* 											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */				  
    '/*											   */					  
    '/*  WHO   WHEN     WHAT								   */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/*********************************************************************/





    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: populateAllergiesComboBox      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Adam Kott   		                */   
    '/*		         DATE CREATED: 	2/17/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								                 */             
    '/*	 This is going to populate a combo box with Medication               */                     
    '/*                                                              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 cmbAllergies - this is the combo box we are going to be populating */
    '/*  dsAllergies - this is the data set of the medication we have in the */
    '/*     database.                                                     */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	miscMethods.populateAllergiesComboBox(cmbAllergies,dsAllergies) */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbTesting - this is a string builder that is used to make the  */                     
    '/*     make the string that will be added to the combo box. It will be*/
    '/*     The first and laste name.                                      */
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Sub populateAllergiesComboBox(cmbAllergies As ComboBox, dsAllergies As DataSet)
        frmAllergies.flpAllergies.Controls.Clear()
        Dim strbTesting As New StringBuilder
        Dim dcAllergies As New AutoCompleteStringCollection
        'cmbAllergies.Items.Clear()


        For Each row As DataRow In dsAllergies.Tables(0).Rows
            dcAllergies.Add(row(0).ToString())
        Next
        With cmbAllergies
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = dcAllergies
            .DataSource = dcAllergies
        End With
    End Sub
    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: populateGenericComboBox      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Adam Kott   		                */   
    '/*		         DATE CREATED: 	2/17/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								                 */             
    '/*	 This is going to populate a combo box with generic values from select*/                     
    '/*                                                              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 cmbGenericBox - this is the combo box we are going to be populating */
    '/*  dsGenericDataset - this is the data set of the medication we have in the */
    '/*     database.                                                     */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	miscMethods.populateGenericComboBox(cmbMedication,dsMedication) */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbTesting - this is a string builder that is used to make the  */                     
    '/*     make the string that will be added to the combo box. It will be*/
    '/*     The first and laste name.                                      */
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  AK    2/28/2021created the function because allergies cmb method was used */
    '/*                                                                     
    '/*********************************************************************/
    Sub populateGenericComboBox(cmbGenericBox As ComboBox, dsGenericDataset As DataSet)
        Dim strPatientInfo As New StringBuilder
        Dim strDOB As String = ""
        Dim dcAllergies As New AutoCompleteStringCollection
        cmbGenericBox.Items.Clear()


        For Each row As DataRow In dsGenericDataset.Tables(0).Rows
            strPatientInfo.Clear()
            strPatientInfo.Append(row(0) + " ")
            strPatientInfo.Append(row(1) + ", ")
            strDOB = row(2)
            strPatientInfo.Append(strDOB.Substring(0, 10) + ", ")
            strPatientInfo.Append(row(3))
            cmbGenericBox.Items.Add(strPatientInfo)
        Next
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: populateMedicationComboBox      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Adam Kott   		                */   
    '/*		         DATE CREATED: 	2/17/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								                 */             
    '/*	 This is going to populate a combo box with Medication               */                     
    '/*                                                              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 cmbMedication - this is the combo box we are going to be populating */
    '/*  dsMEdication - this is the data set of the medication we have in the */
    '/*     database.                                                     */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	miscMethods.populateMedicationComboBox(cmbMedication,dsMedication) */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbTesting - this is a string builder that is used to make the  */                     
    '/*     make the string that will be added to the combo box. It will be*/
    '/*     The first and laste name.                                      */
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/
    Sub populateMedicationComboBox(cmbMedication As ComboBox, dsAllergies As DataSet)
        Dim strbTesting As New StringBuilder
        Dim dcAllergies As New AutoCompleteStringCollection
        cmbMedication.Items.Clear()


        For Each row As DataRow In dsAllergies.Tables(0).Rows
            dcAllergies.Add(row(0).ToString())
        Next
        With cmbMedication
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = dcAllergies
            .DataSource = dcAllergies
        End With
    End Sub
    Sub populateAllergyTypeComboBox(cmbAllergyType As ComboBox, dsAllergyType As DataSet)
        Dim strbTesting As New StringBuilder
        Dim dcAllergies As New AutoCompleteStringCollection
        cmbAllergyType.Items.Clear()


        For Each row As DataRow In dsAllergyType.Tables(0).Rows
            'If cmbAllergyType.FindStringExact(row(2).ToString()) = 0 Or dcAllergies.Count = 0 Then

            dcAllergies.Add(row(0).ToString())

            'End If
        Next
        With cmbAllergyType
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = dcAllergies
            .DataSource = dcAllergies
        End With
    End Sub
End Module
