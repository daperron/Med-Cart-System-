Public Class PersonClass
    '/*********************************************************************/
    '/*                   FILE NAME: PersonClass                         */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT:	Test_Gui        			   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		                */		  
    '/*		         DATE CREATED:	3/3/2021                    		   */						   
    '/*********************************************************************/
    '/*  FILE PURPOSE:					                				   */			  
    '/*	 This is going to be the main person that that Patient and Physican*/
    '/*  will inherent from as they both share several common field.        */					  
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
    '/*	strAddress - This is going to be the persons street address        */
    '/* strFirstName - this is going to be the persons first name          */
    '/* strLastName - this is going to the the persons last name           */
    '/* strMiddleName - This is going to the the person middle name.       */
    '/* strPhoneNumber - this is going to the persons phone number.        */
    '/* strState - this is the persons state                               */
    '/* intID - This is the ID of the patient or the physician. It is      */
    '/*         really only used for patients but it can be used for physicians*/
    '/* strZip - this is going to be zip code. 
    '/*********************************************************************/
    '/* COMPILATION NOTES(will include version notes including libraries):*/
    '/* 											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */				  
    '/*											   */					  
    '/*  WHO   WHEN     WHAT								   */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/25/2021  Added an ID field here because I needed one for */
    '/*                   patient class and if I needed it for physican   */
    '/*                   later I could use it from here.                 */
    '/*********************************************************************/


    Private intID As Integer
    Private strFirstName As String
    Private strMIddleName As String
    Private strLastName As String
    Private strPhoneNumber As String
    Private strAddress As String
    Private strState As String
    Private strCity As String
    Private strZip As String


    '/*********************************************************************/
    '/*                   PROGRAM NAME:  New        					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 3/3/2021                     		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								                */             
    '/*	 This is the the contructor for the class.  It will set all the   */
    '/*  varable as needed.                                               */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  PatientClass                                                     */
    '/*  PhysicianClass                                                   */
    '/*********************************************************************/
    '/*  CALLS:										                     */                 
    '/*             (NONE)								                 */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */ 
    '/*  strCity - this is the city in which the person lives             */
    '/*	 strFirstName - this is the persons first name                    */
    '/*  strMiddleName - this is going to be the persons middle name      */       
    '/*  strLastName - This is going to be the persons last name          */
    '/*  strPhoneNumber - This is going to be the persons phone number    */
    '/*  strAddress - this is goign to be the persons address             */
    '/*  strState -   This is going to tbe persons state                  */
    '/*  strZip - this is going to be the persons zip code.               */                     
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

    Public Sub New(strFirstName As String, strMiddleName As String, strLastName As String, strPhoneNumber As String, strAddress As String, strCity As String, strState As String, strZip As String)
        Me.FirstName = strFirstName
        Me.MiddleName = strMiddleName
        Me.LastName = strLastName
        Me.PhoneNumber = strPhoneNumber
        Me.Address = strAddress
        Me.city = strCity
        Me.State = strState
        Me.ZipCode = strZip
    End Sub


    '/*********************************************************************/
    '/*                   Property NAME:  	city				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		            */   
    '/*		         DATE CREATED: 	3/9/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 this is the getter and setter for strCity  					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*  value - this will be assigned to strCity   					   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strCity								   */             
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

    Public Property city As String
        Get
            Return strCity
        End Get
        Set(value As String)
            strCity = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME: FirstName 					     */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/3/2021                        	  */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                   */             
    '/*	 This is the getter and setting for the variable strFirstName .    */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 FirstName this is the value the is going to be assigned to       */
    '/*  strFirstName										              */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strFirstName								   */             
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
            Return strFirstName
        End Get
        Set(value As String)
            strFirstName = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  	MiddleName				      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 3/3/2021                    		       */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                   */             
    '/*	 This is the getter and setter for strMiddleName	    		   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 MiddleName  this is going to be the value that strMiddleName is  */ 
    '/*  is set to. 
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strMIddleName								   */             
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


    Public Property MiddleName As String
        Get
            Return strMIddleName
        End Get
        Set(value As String)
            strMIddleName = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME: LastName    					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 	3/3/2021                          	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                  */             
    '/*	 This is going to act as a getter and setter for strLastName      */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				        	   */         
    '/*	LastName - this is going to be the value that strLastName is set to*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strLastName								   */             
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
            Return strLastName
        End Get
        Set(value As String)
            strLastName = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  	PhoneNumber 				  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/3/2021                        	  */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                   */             
    '/*	 This is going to be the getter and setter strPhoneNumber          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 PhoneNumber - This is going to be the value that is assigned to  */
    '/*  strPhoneNumber                                                   */
    '/*********************************************************************/
    '/*  RETURNS:								                           */                   
    '/*            strPhoneNumber       								   */             
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

    Public Property PhoneNumber As String
        Get
            Return strPhoneNumber
        End Get
        Set(value As String)
            strPhoneNumber = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME: Address     					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:					                			   */             
    '/*	 this is going to be the getter and setter for strAddress          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 Address - this is going to be the value assigned to strAddress   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            strAddress								              */             
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

    Public Property Address As String
        Get
            Return strAddress
        End Get
        Set(value As String)
            strAddress = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  State     					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/3/2021                        	  */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                  */             
    '/*	 This is the getter and setter for the strState 				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					            */         
    '/*	 State - this is the value that is going to be assigned to strState*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            strState             								   */             
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


    Public Property State As String
        Get
            Return strState
        End Get
        Set(value As String)
            strState = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  ZipCode   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                   */             
    '/*	 This is the getter and setter for strZip   					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					         */         
    '/*	 ZipCode this is the value that is going to be assigned to strZip */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strZip								   */             
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

    Public Property ZipCode As String
        Get
            Return strZip
        End Get
        Set(value As String)
            strZip = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  ID   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/25/2021                       	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                   */             
    '/*	 This is the getter and setter for ID   					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					            */         
    '/*	 value - this is the value that will be assigned to ID.     	   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:						                   		         */                   
    '/*            strID                								   */             
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

    Public Property ID As String
        Get
            Return intID
        End Get
        Set(value As String)
            intID = value
        End Set
    End Property
End Class
