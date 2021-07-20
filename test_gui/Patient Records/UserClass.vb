Public Class UserClass

    '/*********************************************************************/
    '/*                   FILE NAME: UserClass                           */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_Gui       				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		               */		  
    '/*		         DATE CREATED:	3/3/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 This is going be the class will hold the information from Users  */
    '/*  during bulk imports.                                             */
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
    '/* intAdminFlag - this is a 1 or 0 that acts a boolean to show if the */
    '/*                user is an admin or not.                            */
    '/* strBarcode - this is the bar code for the user. It will be hashed  */
    '/* strPassword - this is the password for the user it will be hashed  */
    '/*               before the constructor is called.                    */ 
    '/* strSuperVisorFlag - this is a 1 or a 0 that acts as a boolean to show*/
    '/*                 if the user is a Supervisor or not.                */
    '/* strUserFirstName - this is the user first name.                    */
    '/* strUserLastName  - this is the users last name.                    */
    '/* strUserName - this is the username the user will use to login with */					  
    '/*********************************************************************/
    '/* COMPILATION NOTES(will include version notes including libraries):*/
    '/* 											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */				  
    '/*											   */					  
    '/*  WHO   WHEN     WHAT								   */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/18/2021 Added the salt to the object because I forgot it */
    '/*********************************************************************/

    Private strUserName As String
    Private strPassword As String
    Private strUserFirstName As String
    Private strUserLastName As String
    Private strBarcode As String
    Private intAdminFlag As Integer
    Private intSuperVisorFlag As Integer
    Private strSalt As String


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: new 					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		             */   
    '/*		         DATE CREATED: 		3/3/2021                           */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is the constructor for the class.     					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	StrUserName - this is the username the user will use to login with */ 
    '/* strPassword - this is the password for the user it will be hashed  */
    '/*               before the constructor is called.                    */ 
    '/* strsalt - this is the salt that is used to hash the password.      */
    '/* strUserFirstName - this is the user first name.                    */
    '/* strUserLastName - this is the users last name.                    */ 
    '/* strBarcode - this is the bar code for the user. It will be hashed  */
    '/* intAdminflag - this is a 1 or 0 that acts a boolean to show if the */
    '/*                user is an admin or not.                            /
    '/* intSuperVisorflag - this is a 1 or a 0 that acts as a boolean to show*/
    '/*                 if the user is a Supervisor or not.                *                  
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
    '/*  NP    3/19/2021 Fixed a bug where username was being given first */
    '/*                   name.
    '/*********************************************************************/


    Public Sub New(StrUserName As String, strPassword As String, strsalt As String, strUserFirstName As String, strUserLastName As String, strBarcode As String, intAdminflag As Integer, intSuperVisorflag As Integer)
        Me.UserName = StrUserName
        Me.salt = strsalt
        Me.Password = strPassword
        Me.FirstName = strUserFirstName
        Me.LastName = strUserLastName
        Me.Barcode = strBarcode
        Me.AdminFlag = intAdminflag
        Me.SuperVisorFlag = intSuperVisorflag
    End Sub



    '/*********************************************************************/
    '/*                   Property NAME: UserName    					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                 */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */  
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This will act as the getter and setter for strUserName     	   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is what is going to be assigned to strUserName       */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strUserName								   */             
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

    Public Property UserName As String
        Get
            Return strUserName
        End Get
        Set(value As String)
            strUserName = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME: Password    					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */  
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is going to act as teh getter and setter for strPassword       */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - This is what is going to be assigned to strPassword       */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strPassword								   */             
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


    Public Property Password As String
        Get
            Return strPassword
        End Get
        Set(value As String)
            strPassword = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  	FirstName 				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */  
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is the getter and setter for strUserFirstName 			   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 This is the value that is going to be assigned to strUserFirstName*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strUserFirstName								   */             
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


    Public Property FirstName As String
        Get
            Return strUserFirstName
        End Get
        Set(value As String)
            strUserFirstName = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  LastName					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */  
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is the getter and setter for strUserLastName      		   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	value -  This is the value that is going to be assigned to         */
    '/*             strUserLastName										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strUserLastName								   */             
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


    Public Property LastName As String
        Get
            Return strUserLastName
        End Get
        Set(value As String)
            strUserLastName = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME: Barcode 					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */  
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is the getter and setter for strBarcode				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is what is goign to be assigned to strBarcode         */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strBarcode								   */             
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


    Public Property Barcode As String
        Get
            Return strBarcode
        End Get
        Set(value As String)
            strBarcode = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  AdminFlag					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */  
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is the getter and setter for intAdminFlag     			   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is what is going to be assigned to intAdminFlag if it*/
    '/*          a 1 or a 0                                                */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intAdminFlag								   */             
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


    Public Property AdminFlag As Integer
        Get
            Return intAdminFlag
        End Get
        Set(value As Integer)
            If value = 0 Or value = 1 Then
                intAdminFlag = value
            End If
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  SuperVisorFlag	    		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is the getter and setter for intSuperVisorFlag			   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is what is going to be assigned to intSuperVisorFlag*/
    '/*            if it is 1 or 0                                        */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intSuperVisorFlag								   */             
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


    Public Property SuperVisorFlag As Integer
        Get
            Return intSuperVisorFlag
        End Get
        Set(value As Integer)
            If value = 0 Or value = 1 Then
                intSuperVisorFlag = value
            End If
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  salt      					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/18/2021	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                    */             
    '/*	 This acts as the getter and setter for the salt.   			   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the value that is going to be assigned to the salt*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                            */                   
    '/*            strSalt              								   */             
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

    Public Property salt As String
        Get
            Return strSalt
        End Get
        Set(value As String)
            strSalt = value
        End Set
    End Property
End Class
