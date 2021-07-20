Imports System.Text.RegularExpressions

Module DataVaildationMethods
    '/*********************************************************************/
    '/*                   FILE NAME:  DataVaildationMethods                 */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_Gui				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		                   */		  
    '/*		         DATE CREATED: 2/17/2021                        	   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 This is going to contain the reusable methods to vailidating data.*/
    '/*  Things like checking keypresses and other things.                 */
    '/* 																	  
    '/*********************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			   */ 
    '/*                                                    (NONE)	   */	  
    '/*********************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							   */			  
    '/*                          (NOTHING)					   */		  
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
    '/*                   SUBPROGRAM NAME:  KeyPressCheck   			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/17/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:							            	   */             
    '/*  This is going to check to see if the key being pressed is part of */
    '/*  The allowed characters. All you need to do is give it the         */
    '/*  KeyPressEventArgs and the a string of the characters you want to  */
    '/*  allow and it will handle the rest. It was made beause where was a */
    '/*  lot of reduntant code that could be reused for checking keypresses*/
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY: frmConfiguration.txtFirst_Last_Keypress  	       */           
    '/*             frmConfiguration.txtPasswordKeypress                 */          
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 e - this is the key press event args that are generated when a key*/
    '/*      press happens.                                                */
    '/* AllowChars - this is a string of the characters you want to be able*/
    '/*              to allow.                                             */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*		(e, "abcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()/.,<>=+")    */                     
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
    '/*  NP   2/18/21  Creation                                                                    
    '/*********************************************************************/



    Sub KeyPressCheck(ByRef e As KeyPressEventArgs, AllowChars As String)
        If Not (Asc(e.KeyChar) = 8) Then 'char 8 is a backspace. So we don't care. 
            If Not AllowChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub



    '/**********************************************************************/
    '/*                   SUBPROGRAM NAME:  LimitQuantityToQuantityStocked */         
    '/**********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		           */   
    '/*		         DATE CREATED: 	2/19/2021                       	   */                             
    '/**********************************************************************/
    '/*  SUBPROGRAM PURPOSE:							            	   */             
    '/*  This is going to check to the quantity of the medication that is  */
    '/*  currently stocked in the cart and ensure that the user cannot     */
    '/*  increment the medication button past the value we have stored.    */
    '/*                                                                    */
    '/**********************************************************************/
    '/*  CALLED BY:   	      						                       */           
    '/*                                         				           */         
    '/**********************************************************************/
    '/*  CALLS:										                       */                 
    '/*             (NONE)								                   */             
    '/**********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					           */         
    '/*	 limit- integer equal to the quantity of that medication stored    */
    '/*  txtBoxQuantity- the textbox that is used to contain the qty value */                                                                  
    '/**********************************************************************/
    '/*  RETURNS:								                           */                   
    '/*            (NOTHING)								               */             
    '/**********************************************************************/
    '/* SAMPLE INVOCATION:								                   */             
    '/*											                           */                     
    '/**********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):     */
    '/* None                                                               */     
    '/**********************************************************************/
    '/* MODIFICATION HISTORY:						                       */               
    '/*											                           */                     
    '/*  WHO         WHEN           WHAT								   */             
    '/*  ck          2/19/21        Creation                               */
    '/*********************************************************************/
    Sub LimitQuantityToQuantityStocked(ByVal limit As Integer, ByVal txtBoxQuantity As TextBox)

        If CInt(txtBoxQuantity.Text) > limit Then
            ' set the value to the limit because the user cannot dispense more than the cart contains
            txtBoxQuantity.Text = limit
            MessageBox.Show("The cart only contains " & limit & " of this medication. Please restock or pick a smaller quantity.")
        End If

    End Sub


    '/**********************************************************************/
    '/*               FUNCTION NAME: checkSQLInjection                     */         
    '/**********************************************************************/
    '/*                    WRITTEN BY:  Dillen Perron  		               */   
    '/*		              DATE CREATED: 	2/19/2021                  	   */                             
    '/**********************************************************************/
    '/*  SUBPROGRAM PURPOSE:							            	   */             
    '/*  This function will check for characters typed and remove any that */
    '/* that could be an sql injection                                     */
    '/*                                                                    */
    '/**********************************************************************/
    '/*  CALLED BY:   	      						                       */           
    '/*                                         				           */         
    '/**********************************************************************/
    '/*  CALLS:										                       */                 
    '/*             (NONE)								                   */             
    '/**********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					           */                                                                           
    '/**********************************************************************/
    '/*  RETURNS:								                           */                   
    '/*            (NOTHING)								               */ 
    '/*											                           */
    '/**********************************************************************/
    '/* SAMPLE INVOCATION:								                   */             
    '/*											                           */                     
    '/**********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):     */
    '/* None                                                               */     
    '/**********************************************************************/
    '/* MODIFICATION HISTORY:						                       */               
    '/*											                           */                     
    '/*  WHO         WHEN           WHAT								   */             
    '/*  dillen      3/1/21        Creation                                */
    '/*  NP          3/19/2021     Commented out line 186 as it is erroring*/
    '/*                            out and I needed to make sure that my   */
    '/*                            coded worked before I tried to fix it.
    '/* dillen      3/22/2021      Fixed \ to work with regex              */
    '/* NP          3/30/2021      added an optional parameter to allow for*/
    '/*                            situations where single ' are kept      */
    '/*********************************************************************/

    Function checkSQLInjection(TextToCheck As String, Optional allowSingleQuote As Boolean = False) As String
        If allowSingleQuote Then
            TextToCheck = Regex.Replace(TextToCheck, Chr(39), "''") ' check for '
        Else
            TextToCheck = Regex.Replace(TextToCheck, Chr(39), "") ' check for '
        End If
        TextToCheck = Regex.Replace(TextToCheck, Chr(34), "") 'check for "
        TextToCheck = Regex.Replace(TextToCheck, "\\", "") ' check for \    
        TextToCheck = Regex.Replace(TextToCheck, Chr(47), "") ' check for /
        TextToCheck = Regex.Replace(TextToCheck, Chr(59), "") ' check for ;

        Return TextToCheck
    End Function


End Module
