Module CheckComboBoxForDuplicateMethods
    '/*********************************************************************/
    '/*                   FILE NAME: CheckComboBoxForDuplicateMethods       */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_GUI       				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		                */		  
    '/*		         DATE CREATED:	2/8/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 This file is going to contain the methods that check the if the  */					  
    '/*  string we are trying to put in the combo box is unqiue.          */
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
    '/*                   FUNCTION NAME: checkComboForDup                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		             */   
    '/*		         DATE CREATED: 2/6/2021                     		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*  this is going to check	the combo box to make sure that we are only*/
    '/*  adding items that are unqiue                                      */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 cboRoom - this is the combo box we are trying to add the itme to. */                     
    '/*   item - This is the string that you wish to add to the combobox    */                                                                  
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*	blnGood - this is the value that will tell us if the item is unqiue*/  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/* CheckComboBoxForDuplicateMethods.checkComboForDup(cboStates, "MI")*/
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	blnGood - this is going to be true if the item trying to be added */
    '/*     is unquie. It will be false if it is a duplicate              */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Function checkComboForDup(cboRoom As ComboBox, item As String)
        Dim blnGood As Boolean = True
        For Each thing As String In cboRoom.Items
            If thing.Equals(item) Then
                blnGood = False
            End If
        Next
        Return blnGood
    End Function

End Module
