Public Class PatientClass
    Inherits PersonClass

    '/*********************************************************************/
    '/*                   FILE NAME:  PatientClass                        */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_GUI				          */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		              */		  
    '/*		         DATE CREATED:	3/3/2021                    		  */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									                   */			  
    '/*	 This is going to be the Class used to make the patient object when*/
    '/*  We read in files. 
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
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                  */		  
    '/*	                                                                  */
    '/* strBarcode - this is the bar code that will be used with the badge.*/
    '/* strDob - this is the date of birth for the patient.                */
    '/* intHeight - this is the height of the patient.                     */
    '/* lngMRN_Number - This is the MRN of the patient. It is a long as I am*/
    '/*         not sure how long the number will need to be.              */
    '/* lngPrimaryPhysicianID - this is the ID of the physician that is    */
    '/*                 taking care of them. It is a long as I am not sure */
    '/*                 how long the IDs will be.                          */
    '/* strSex - this is the sex of the patient. It will either be male or */
    '/*          Female.                                                   */
    '/* intWeight - this is the weight of the patient.   				   */	
    '/* roomDataValue - this is going to be an object of the RoomClass and */
    '/*                 is going to hold the room and bed information for  */
    '/*                 the patient.                                       */
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

    Private idValue As String
    Private lngMRN_Number As Long
    Private strBarcode As String
    Private strDob As String
    Private strSex As String
    Private intHeight As Integer
    Private intWeight As Integer
    Private lngPrimaryPhysicianID As Long
    Private strEmail_Address As String
    Private roomDataValue As RoomClass

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  New					          */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 		3/3/2021                           */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is the constructor for the class.         				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					           */         
    '/*	 strAddress - This is the address of the patient.                  */
    '/*  strBarcode - this is going to be the barcode for the patient.     */
    '/* strDoB - this is the birth day of the patient.                     */
    '/* strFirstName - this is the first name of the patient.              */
    '/* intHeight - this is the height of the patient.                     */
    '/* strLastName - this is the alst name of the patient.                */
    '/* strMiddleName - This is the middle name of the patient.            */
    '/* lngMRN_Number - this is the medical record number of the patient   */
    '/* strPhoneNumber - this is the patient phone number.                 */
    '/* lngPrimaryPhysicianID - this is the ID of the physician taking care*/
    '/*                         of the patient.                            */
    '/* strSex - this is the gender of the patient. It will be male or female*/
    '/* strState - this is the state the patient lives in.                 */
    '/* intWeight - this is the weight of the patient.                     */
    '/* strZip - this is the zip code the patient lives in. 			   */                     
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


    Public Sub New(lngMRN_Number As Long, strBarcode As String, strFirstName As String, strMiddleName As String, strLastName As String, strDoB As String,
                   strSex As String, intHeight As Integer, intWeight As Integer, strAddress As String, strCity As String, strState As String, strEmail_address As String, strZip As String,
                   strPhoneNumber As String, lngPrimaryPhysicianID As Long, roomName As String, bedName As String)
        MyBase.New(strFirstName, strMiddleName, strLastName, strPhoneNumber, strCity, strAddress, strState, strZip)
        Me.MRN_Number = lngMRN_Number
        Me.email = strEmail_address
        Me.barcode = strBarcode
        Me.DoB = strDoB
        Me.sex = strSex
        Me.Height = intHeight
        Me.weight = intWeight
        Me.PrimaryPhysicianID = lngPrimaryPhysicianID
        Me.roomData = New RoomClass(roomName, bedName)
    End Sub


    '/*********************************************************************/
    '/*                   Property NAME: email       					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                 */   
    '/*		         DATE CREATED: 3/9/2021                     		   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 this is a getter and setter for strEmail_Address       		   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is what is going to be assgined to strEmail_Address  */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strEmail_Address								   */             
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

    Public Property email As String
        Get
            Return strEmail_Address
        End Get
        Set(value As String)
            strEmail_Address = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME: MRN_Numbe   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                   */             
    '/*	 This is the Getter and setter for lngMRN_Number    			   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					         */         
    '/*	 MRN_Number- this is the value that is going to be assigned to    */
    '/*            lngMRN_Number*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                           */                   
    '/*            lngMRN_Number        								   */             
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

    Public Property MRN_Number As Long
        Get
            Return lngMRN_Number
        End Get
        Set(value As Long)
            lngMRN_Number = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  barcode   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                    */             
    '/*	 This is the getter and setter for strBarcode   				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 barcode - this is the value that is going to be assigned to barcode*/                     
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

    Public Property barcode As String
        Get
            Return strBarcode
        End Get
        Set(value As String)
            strBarcode = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME: DoB 					         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:							                	   */             
    '/*	 This is the getter and setter for strDob   					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					           */         
    '/*	 DoB this is the value that is going to be assigned to strDob      */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strDob								   */             
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


    Public Property DoB As String
        Get
            Return strDob
        End Get
        Set(value As String)
            strDob = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  sex					            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 3/3/2021		                         */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                   */             
    '/*	 This is the getter and setter for strSex   					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sex - this is the value that is going to be assigned to strSex   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            strSex								   */             
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

    Public Property sex As String
        Get
            Return strSex
        End Get
        Set(value As String)
            strSex = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  	Height				           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		             */   
    '/*		         DATE CREATED: 	3/3/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								                    */             
    '/*	 This is the getter and setter for intHeight    				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				        	   */         
    '/*	 Height	- this is the value that is going to be assigned to intHeight*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intHeight								   */             
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


    Public Property Height As Integer
        Get
            Return intHeight
        End Get
        Set(value As Integer)
            intHeight = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  weight    					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                 */   
    '/*		         DATE CREATED: 3/3/2021                     		   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is the getter and setter for 	intWeight   				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					           */         
    '/*	 weight	- this is the value that is going to be assigned to intWeight*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intWeight								   */             
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

    Public Property weight As Integer
        Get
            Return intWeight
        End Get
        Set(value As Integer)
            intWeight = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   Property NAME:  	PrimaryPhysicianID  		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 		3/3/2021                            */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*  This is the getter and setter for lngPrimaryPhysicianIDd     	   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 PrimaryPhysicianID	- this is the value that is going to be assigned*/
    '/*                     to lngPrimaryPhysicianID                        */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*        lngPrimaryPhysicianID    								   */             
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


    Public Property PrimaryPhysicianID As Long
        Get
            Return lngPrimaryPhysicianID
        End Get
        Set(value As Long)
            lngPrimaryPhysicianID = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  roomData					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   	       	         */   
    '/*		         DATE CREATED: 3/24/2021                    		   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*  This is the getter and setter for roomdata. 					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	value - this is the value that is going to be assigned to roomDataValue*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*           roomDataValue 								   */             
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


    Public Property roomData As RoomClass
        Get
            Return roomDataValue
        End Get
        Set(value As RoomClass)
            roomDataValue = value
        End Set
    End Property



    Public Property ID As String
        Get
            Return idValue
        End Get
        Set(value As String)
            idValue = value
        End Set
    End Property
End Class
