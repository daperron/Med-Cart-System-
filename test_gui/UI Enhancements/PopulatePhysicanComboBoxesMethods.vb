Imports System.Text
Module PopulatePhysicanComboBoxesMethods
    '/*********************************************************************/
    '/*                   FILE NAME: PopulatePhysicanComboBoxesMethods     */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_GUI       				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		               */		  
    '/*		         DATE CREATED:	2/8/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 This is going to hold the methods that are used to populate the  */
    '/*  physcian combo boxes in a number of forms.                       */
    '/* 																	  
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
    '/*                   SUBPROGRAM NAME: populatePhysicianComboBox      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 	2/6/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:						            		   */             
    '/*	This is going to populate a combo box with the list of Physicians that*/                     
    '/* we have in our database. It is only going to post the unique ones. */           
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 cboStuff - This is going to be the combo box that we are trying   */
    '/*     populate with the list of physicians.                          */
    '/*  ds - this is the data that we are using to populate the combo box */                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                         */                   
    '/*            (NOTHING)								            */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	PopulatePhysicanComboBoxesMethods.populatePhysicianComboBox        */
    '/*                             (cmbPhysician, dsPhysician)            */                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strbTesting - this is a string builder that is used to make the  */                     
    '/*     make the string that will be added to the combo box. It will be*/
    '/*     The first and laste name.                                      */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Sub populatePhysicianComboBox(cboStuff As ComboBox, ds As DataSet)
        Dim strbTesting As New StringBuilder
        cboStuff.Items.Clear()

        For Each row As DataRow In ds.Tables(0).Rows
            strbTesting.Clear()
            strbTesting.Append(row(EnumList.Physician.LastName) & ", " &
                                row(EnumList.Physician.FirstName) & ", " &
                                row(EnumList.Physician.PhysicianCredentials))
            Debug.WriteLine("")
            If checkComboForDup(cboStuff, strbTesting.ToString) Then
                cboStuff.Items.Add(strbTesting.ToString)
            End If
        Next
    End Sub
End Module
