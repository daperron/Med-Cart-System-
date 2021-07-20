Public Class PhysicianClass
    Inherits PersonClass

    '/*********************************************************************/
    '/*                   FILE NAME: PhysicianClass                      */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_Gui       				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		                */		  
    '/*		         DATE CREATED:	3/3/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									                  */			  
    '/*	 This is going to the be the Physician Object that holds the       */
    '/*  information as it is read in from a file before it is written to */
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
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                   */		  
    '/*	strCredentials - this is where the Physician got their credentials */
    '/*                  from                                              */
    '/* strFaxNumber -	This is the fax number of the physician            */			  
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



    Private strCredentials As String
    Private strFaxNumber As String

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  New     					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:		            						   */             
    '/*  This is the constructor for the class.		    				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	strAddress - This is the address of the physician.                */
    '/* strCredentials - this is the place the physician got their        */
    '/*                 credentials from.                                 */
    '/* strFaxNumber - this is the fax number of the physician.           */
    '/* strFirstName - this is the first name of the physician.           */
    '/* strLastName - this is the alst name of the physician.             */
    '/* strMiddleName - This is the middle name of the physician.         */
    '/* strPhoneNumber - this is the physician phone number.              */
    '/* strState - this is the state the physician lives in.              */
    '/* strZip - this is the zip code the physician lives in. 			  */   
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


    Public Sub New(strFirstName As String, strMiddleName As String, strLastName As String, strCredentials As String, strPhoneNumber As String, strFaxNumber As String, strAddress As String,
                    strCity As String, strState As String, strZip As String)
        MyBase.New(strFirstName, strMiddleName, strLastName, strPhoneNumber, strAddress, strCity, strState, strZip)
        Me.Credentials = strCredentials
        Me.FaxNumber = strFaxNumber
    End Sub

    '/*********************************************************************/
    '/*                   Property NAME:  Credentials					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		             */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:						                		   */             
    '/*	 This is the getter and setter for strCredentials           	   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				               */         
    '/*	 Credentials - this is the value that is going to be assigned to  */
    '/*                strCredentials                                     */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                           */                   
    '/*            strCredentials       								   */             
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


    Public Property Credentials As String
        Get
            Return strCredentials
        End Get
        Set(value As String)
            strCredentials = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME: FaxNumber   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 3/3/2021                               */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is the getter and setter for strFaxNumber					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 FaxNumber - this is the value that is going to be assigned to    */
    '/*         strFaxNumber                                              */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            strFaxNumber         						    	   */             
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


    Public Property FaxNumber As String
        Get
            Return strFaxNumber
        End Get
        Set(value As String)
            strFaxNumber = value
        End Set
    End Property

End Class
