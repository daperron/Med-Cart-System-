Imports System.Text
Module GenerateRandom

    '/*********************************************************************/
    '/*                   FILE NAME:  GenerateRandom                      */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: MedServe       				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		                */		  
    '/*		         DATE CREATED:	2/18/2021                   		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*  This is going to hold the methods to generate random numbers and/or*/
    '/*  String.                                                            */
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
    '/*                   FUNCTION NAME: generateRandomAlphanumeric 	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 2/18/2021                    		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to generate a random string based on the length and*/
    '/*  a string of the chartacter you want it to make up. This uses the */
    '/*  System.random to get a random number between 0 and the size of the*/
    '/*  pool. It used thread.sleep to make the program sleep for a random*/
    '/*  amount of time as the random methods in VB are based on how long */
    '/*  the application has been running so we are changing how long it has*/
    '/*  been running to allow for a more ransom set of numbers.           */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 Length - this is how long you want yoru random string to be.    */
    '/*  Pool - this is the set of Characters you want your string to      */
    '/*         consist of. this can also be numbers in a string and converted*/
    '/*         back to numbers later.                                     */
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



    Public Function generateRandomAlphanumeric(Length As Integer, Pool As String) As String
        Dim randomString As New StringBuilder
        For i = 0 To Length Step 1
            Dim generatorCharPosition = New System.Random
            Dim intCharPosition = generatorCharPosition.Next(0, Pool.Length - 1)
            Threading.Thread.Sleep(76 + generatorCharPosition.Next(5))
            randomString.Append(Pool.ToCharArray.ElementAt(intCharPosition))
        Next


        Return randomString.ToString
    End Function
End Module
