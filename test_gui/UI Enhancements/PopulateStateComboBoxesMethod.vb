Module PopulateStateComboBoxesMethod
    '/*********************************************************************/
    '/*                   FILE NAME: PopulateStateComboBoxesMethod        */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_GUI			        	   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		                */		  
    '/*		         DATE CREATED:	2/8/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 This contains the method the that is going ot populate teh states*/
    '/*  in the states combo box.                                         */
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
    '/*	 strStatesArray - this is going to hold the array of states that is*/
    '/*      that is going to be used to populate ComboBoxs
    '/*                                                                     			   */					  
    '/*********************************************************************/
    '/* COMPILATION NOTES(will include version notes including libraries):*/
    '/* 											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */				  
    '/*											   */					  
    '/*  WHO   WHEN     WHAT								   */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/9/2021 moved the states array out of the populate method */
    '/*                 so I could make a property and use it in other    */
    '/*                 places for error checking                         */
    '/*********************************************************************/



    Dim strStatesArray As String() = {"ME", "NH", "VT", "MA", "CT", "RI", "NY", "VA", "NC",
        "SC", "GA", "FL", "DE", "NJ", "OH", "MI", "IL", "IN", "IA", "KS", "NE", "OK",
        "TX", "AL", "TN", "MO", "ND", "SD", "WY", "MT", "ID", "NV", "WA", "OR", "CO",
        "NM", "AZ", "WV", "PA", "CA", "AR", "HI", "MN", "WI", "MD", "MS", "AK", "LA",
        "UT", "KY", "DC"}

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  	PopulateStateComboBox  	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	2/6/2021                        	   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to populate the state comboxbox on a number of forms.*/
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	cboState - this is the combobox we are putting the states in.      */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:					                			         */                   
    '/*            (NOTHING)				            				   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:		                   						   */             
    '/*	PopulateStateComboBoxesMethod.PopulateStateComboBox(cboStates)     */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */

    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/9/2021 I moved the states array out of the method so I   */
    '/*                 could use it for error checking else were.        */
    '/*********************************************************************/

    Sub PopulateStateComboBox(cboState As ComboBox)
        cboState.Items.Clear()
        For Each item As String In states
            cboState.Items.Add(item)
        Next

    End Sub

    Public ReadOnly Property states As String()
        Get
            System.Array.Sort(strStatesArray)
            Return strStatesArray
        End Get
    End Property
End Module
