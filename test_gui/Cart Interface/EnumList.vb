Module EnumList

    '/*********************************************************************/
    '/*                   FILE NAME:  EnumList                          */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: MedServe       				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  	       	         */		  
    '/*		         DATE CREATED:	2/4/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 This is going to house all the enums that we are going to need in */
    '/*  the application.                                                   */					  
    '/* 																	  
    '/*********************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			   */ 
    '/*                                                    (NONE)	   */	  
    '/*********************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							   */			  
    '/*                          (NOTHING)					   */		  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */			  
    '/*	EnumList.Patient.FristName									   */					  
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
    '/*                   ENUM NAME:  Patient       					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 	2/4/2021                        	   */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:		                    						   */             
    '/*	 This is going to make the information we are bring back for the   */
    '/*  information the database is going to being back.                  */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         	        			   */         
    '/*********************************************************************/
    '/*  CALLS:									                    	   */                 
    '/*             (NONE)						                		   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):			           		   */         
    '/*		(None)                  									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	EnumList.Patient.FristName											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 Active_Flag - this is going if the patient is active or not        */
    '/*  address - this is for the patient's address                       */
    '/*  barCode - this is the barcode that is used to ID the patient.     */
    '/*  city - this is going to be for the city the patient lives in.     */
    '/*  DoB - this is for the patients date of birth                       */
    '/*  Email - this is going to be for the patient's email.               */
    '/*  FirstName - this is the first anem of the patient.                 */
    '/*  Height - this is for the hieght of the patient.                    */
    '/*  ID - this is for the ID of the patient in the database             */
    '/*  LastName - this is for the last name of the patient.               */
    '/*  MiddleName - this is for the last name of the patient.             */
    '/*  MRN_Number - this is for the movement reference number.            */
    '/*  Phone - this is for the patient phone number.                      */ 
    '/*  PhysicianID - this is for the primary physician responible for the */
    '/*     care of the patient.                                            */
    '/*  Sex - this is for the sex of the patient.                          */
    '/*  zip - this is for the zip code the patient lives in.               */                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/5/2021 Updated this for include teh barcode.             */                                                                   
    '/*********************************************************************/

    Enum Patient
        ID = 0
        MRN_Number = 1
        barCode = 2
        FristName = 3
        MiddleName = 4
        LastName = 5
        DoB = 6 'this is the day of birth
        Sex = 7
        Height = 8
        Weight = 9
        address = 10
        City = 11
        state = 12
        zip = 13
        Phone = 14
        Email = 15
        PhysicianID = 16
        Active_Flag = 17
    End Enum

    '/*********************************************************************/
    '/*                   Enum NAME:  AdHocOrder    					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                 */   
    '/*		         DATE CREATED: 	02/4/2021                       	   */                             
    '/*********************************************************************/
    '/*  Enum PURPOSE:						                    		   */             
    '/*	 This is going ot make the data that we pull from the database easier */
    '/*  to read.                                                          */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					           */         
    '/*		(NONE) 									                     */                                                                                         
    '/*********************************************************************/
    '/*  RETURNS:						                  		         */                   
    '/*            (NOTHING)								               */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:		                						   */             
    '/*	EnumList.AdHocOrder.ID  										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  amount - this is going to be the amount of medication ordered.   */
    '/*  dateTime - this is going to tbe the day and time the order was made. */
    '/*  DrawerMedicationTUID - this is going to be the drawer the meication is in.     */
    '/*  ID - this is the ID of the order.                                 */
    '/*  MedicationID  - this is the ID of the medication being ordered.  */
    '/*  PatientID - this is the id of the patient this order is for.     */
    '/*  UserID - this is for the ID of the nurse that is going to be     */
    '/*     fulfilling the order.                                         */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/5/2021 Changes drawer to DrawerMedicationTUID            */                                                                  
    '/*********************************************************************/

    Enum AdHocOrder
        ID = 0
        MedicationID = 1
        PatientID = 2
        UserID = 3
        amount = 4
        DrawerMedicationTUID = 5
        dateTime = 6
    End Enum


    '/*********************************************************************/
    '/*                   Enum NAME: Allergy         					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                 */   
    '/*		         DATE CREATED: 2/4/2021                        		   */                             
    '/*********************************************************************/
    '/*  Enum PURPOSE:								   */             
    '/*  This is going to make data from the allery table when readable   */
    '/*  when we bring it into our program.                               */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:		                						   */             
    '/*	 EnumList.Allergy.Name  										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 MedicationID - this is the ID for the mediciation the allery is  */
    '/*     in relation to.                                               */
    '/*  Name - this is the name of the allery.                           */
    '/*  Type - this is the type of allery.                               */  
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum Allergy
        Name = 0
        MedicationID = 1
        Type = 2
    End Enum

    '/*********************************************************************/
    '/*                   Enum NAME:  AlleryOverRide    				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   	    	         */   
    '/*		         DATE CREATED: 	2/4/2021                        	   */                             
    '/*********************************************************************/
    '/*  Enum PURPOSE:	                    							   */             
    '/*	 This is going to make the Allery Override information that we    */
    '/*  bring back from the database easier to read.                     */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		(none)									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:				                    			   */             
    '/*		Enumlist.AlleryOverRide.name								   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  AllergyName = this is the name of the allergy                    */
    '/*	 DateTime - this is going to be for the day and time the over ride*/
    '/*     was done.                                                     */
    '/*  ID - this is the TUID of the over ride.                          */
    '/*  PatientID - this is the ID of the patient this is in relation to */
    '/*  UserID - this is the nurse this override is in relation to.       */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum AllergyOverRide
        ID = 0
        PatientID = 1
        UserID = 2
        AllergyName = 3
        DateTime = 4
    End Enum

    '/*********************************************************************/
    '/*                   Enum NAME: Discrepancies   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Enum PURPOSE:		                    						   */             
    '/*	 This is going to make the data from the Discrepancies easier to read*/                   
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		(none)									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	EnumList.Discrepancies.Drawer									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 actual - this is the actual count of the medication.             */
    '/*  approvingUser - this is the user aprroving the Discrepancy has   */
    '/*     been cleared.                                                 */
    '/*  DateTimeCleared - this is the date and time the Discrepancy was  */
    '/*     cleared.                                                      */
    '/*  DateTimeEntered - this is the date and time the Discrepancy was  */
    '/*     entered into the database.                                    */
    '/*  Drawer - number the Discrepancy is in.                           */
    '/*  Expected - this is the count of medication that is expected to be*/
    '/*     in the drawer.                                                */
    '/*  ID - this is the TUID of the Discrepancy.                        */
    '/*  MedicationID - this is the ID of the medication in question.     */                    
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum Discrepancies
        ID = 0
        Drawer = 1
        MedicationID = 2
        Expected = 3
        actual = 4
        primaryUser = 5
        approvingUser = 6
        DateTimeEntered = 7
        DateTimeCleared = 8
    End Enum
    '/*********************************************************************/
    '/*                   Enum NAME:  Dispensing	    				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  Enum PURPOSE:				                    				   */             
    '/*											   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:			                   					   */             
    '/*	EnumList.Dispensing.ID  										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 Amount - this is the amount being dispensed.                     */
    '/*  ApprovingID - this is the ID of the nurse giving the medication. */
    '/*  DateTime - this is the date and time the medication was dispensed*/
    '/*  DrawerMedicationTUID - this is teh TUID of the DrawerMedication  */
    '/*     table.                                                        */
    '/*  ID - this is the ID of this dispensing event.                    */
    '/*  PatientMedicationTUID - this is the TUID of the Patient Medication*/
    '/*     table.                                                        */
    '/* PrimaryUserTUID - this is the ID of the primary nurse responable  */
    '/*     for this patient.                                             */                    
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Enum Dispensing
        ID = 0
        PatientMedicationTUID = 1
        PrimaryUserTUID = 2
        ApprovingID = 3
        DateTime = 4
        Amount = 5
        DrawerMedicationTUID = 6
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME:  DrawerMedication					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/4/2021                           	   */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:							                    	   */             
    '/*	 This is going to make the data we bring back from the 			   */                     
    '/*  DrawerMedication table more readable.                             */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:				                				   */             
    '/*		EnumList.DrawerMedication.ID								   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 DiscrepancyFlag - this is the flag to tell if there is a discrpancy*/
    '/*  DividerBin - this is to tell what divider in the drawer the medication*/
    '/*     is in.                                                         */
    '/*  DrawerID - this is the drawer ID the medication is in.             */
    '/*  ExpirationDate - this is the date the medication expires on.       */
    '/*  ID - this is the TUID of this entry.                               */
    '/*  MedicationID - this is the ID for the medication.                  */
    '/*  Quantity - this is how much of the medication is in that drawer.   */                                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Enum DrawerMedication
        ID = 0
        DrawerID = 1
        MedicationID = 2
        Quantity = 3
        DividerBin = 4
        ExpirationDate = 5
        DiscrepancyFlag = 6
    End Enum

    '/*********************************************************************/
    '/*                   Enum NAME: Drawer          					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	02/4/2021	   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*	 This is going to make the information we pull back from about    */
    '/*  the drawers from the database easier to read.                    */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	EnumList.Drawer.DrawerNumer										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  ActiveFlag - this is to tell if the drawer is active or not.     */
    '/*  DrawerNode - this is the communication node that is going to be used*/
    '/*     to open the drawer.                                            */
    '/*  DrawerNumber - this is the drawer number in the cart.             */
    '/*  DrawerSize - this is how large drawer is in the cart.             */
    '/*  FullFlag - this is going to be tell us if the drawer is full or not*/
    '/*  ID - this is the ID of this entry in the database.                */
    '/*  NumberOfDividers - this is the number of divders in the drawer.   */                    
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum Drawer
        ID = 0
        DrawerNode = 1
        DrawerNumber = 2
        DrawerSize = 3
        NumberOfDividers = 4
        FullFlag = 5
        ActiveFlag = 6
    End Enum

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  DrugInteraction				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		             */   
    '/*		         DATE CREATED: 	02/4/2021                          	   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to make the information we pull back from the      */                     
    '/*  Drug_Interactions able easier to read.                           */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   */             
    '/*	EnumList.DrugInteractions.MedicationOneID       				   */                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  activeFlag - this is to tell us if this record is active or not. */
    '/*  description - this is a discription of the interaction.          */
    '/*  ID - this is the Id of the interaction.                          */
    '/*  MedicationOneID - this is the ID of the first medication in this */
    '/*     interaction.                                                  */
    '/*  MedicationThreeID - this is the ID of the thrid medication in this*/
    '/*     interaction if it has one.                                    */
    '/*  medicationTwoID - this is the ID of the second medication in this*/
    '/*     interaction.                                                  */
    '/*  Severity - this is the severity of how bad the interaction is.   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/5/2021 removed MedicationThreeID to matach database.     */                                                                   
    '/*********************************************************************/

    Enum DrugInteractions
        ID = 0
        MedicationOneID = 1
        medicationTwoID = 2
        Severity = 3
        description = 4
        activeFlag = 5
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME:  	Medication      				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 		02/4/2021                           */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to make the medication information we bring back from*/                     
    '/*  the database easier to read.                                      */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	 EnumList.Medication.Name										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 ActiveFlag - this tells us if the record is in active use or not.*/
    '/*  Barcode - this is the barcode for the medication that will be used*/
    '/*     label its container.                                           */
    '/*  Dosage - this is how of the medication the patient is supposed to */
    '/*     get.                                                           */
    '/*  ID - this is the ID of this medication in our database.           */
    '/*  Name - this is the name of medicataion.                           */
    '/*  NarcoticControlledFlag - this is to tell us if the medication is a*/
    '/*     naroctic or a controlled substance.                            */
    '/*  RXCUID - this is the ID of the medication in the RxNorm RestFul API*/
    '/* Strength - this is the strength of the medication.                 */
    '/* Snyonym - this is other names the medicaiton can go by.            */
    '/* Type - this is the type of substance the medication is.     	   */                                                                                        
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/5/2021 added Snyonym to match the database.              */                                                                   
    '/*********************************************************************/

    Enum Medication
        ID = 0
        Name = 1
        RXCUI = 2
        Dosage = 3
        NarcoticControlledFlag = 4
        Barcode = 5
        Snyonym = 6
        type = 7
        Strength = 8
        Schedule = 9
        ActiveFlag = 10
    End Enum


    '/*********************************************************************/
    '/*                   ENUM NAME: PatientAllery 			    		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 02/4/2021	                           */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:								   */             
    '/*	 This is going to make the PatientAllery information we bring back */                     
    '/*  from the database more readable.                                  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		(none)									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:					                			   */             
    '/*	 Enum.PatientAllery.AllergySeverity								   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  ActiveFlag - this tells us if the record is in active use or not.*/
    '/*  AllergyName - this is the name of the allergy.                   */
    '/*  AllergySeverity - this is for the severity of the allergy.       */
    '/*  PatientID - this is for the ID of the patient this allery is in  */
    '/*     reference to.                                                 */
    '/*  ID - this is the ID for this record.                             */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP     2/5/2021 Removed ID as I misunderstood how the primary key*/
    '/*                  was being made.                                  */
    '/*********************************************************************/

    Enum PatientAllery
        PatientID = 0
        AllergyName = 1
        AllergySeverity = 2
        ActiveFlag = 3
    End Enum
    '/*********************************************************************/
    '/*                   ENUM NAME: PatientMedication       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to make the information from the PatientMedication  */
    '/*  table easier to read when we pull it from the database.          */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:							                	   */             
    '/*	EnumList.PatientMedication.id  					   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 activeFlag - this is to tell us if the record is active or not.  */
    '/*  DatePrescribed - this is the date the medication was prescribed  */
    '/*  ID - this is the ID of this record.                              */
    '/*  MedicationID - this is the ID of the medication being Presribed  */
    '/*  Method - this is the method to which the medication will be      */
    '/*     administered.                                                 */
    '/*  PatientID - this is the ID of the Patient this record is in      */
    '/*     relation to.                                                  */
    '/*  PhysicianID - this is teh ID of the Physicion who is prescibing  */
    '/*     the medication.                                               */
    '/*  Quanity - this is how much of the medication is supposed to be   */
    '/*     admistered.                                                   */
    '/*  schedule - this is  how often the medication should be administered*/                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/5/2021 Changed named to PatientMedication to match database*/                                                                   
    '/*********************************************************************/


    Enum PatientMedication
        ID = 0
        PatientID = 1
        MedicationID = 2
        PhysicianID = 3
        DatePrescribed = 4
        Quanity = 5
        method = 6
        Frequency = 7
        Notes = 8
        activeFlag = 9
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME: PatientPhysician 					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 02/4/2021                      		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                   */             
    '/*	 This is going to make the information from the ParientPhysician  */
    '/*  table easier to read.                                            */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:					                			   */             
    '/*	EnumList.PatientPhysician.PatientID 							   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  Activeflag - this is to tell us if the record is active or not.  */
    '/*  PatientID - this is the ID of the Patient this record is in      */
    '/*     relation to.                                                  */
    '/* PhysicianID - this is the ID of the physician this record is in   */
    '/*     relation to.                                                  */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum PatientPhysician
        PatientID = 0
        PhysicianID = 1
        ActiveFlag = 2

    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME:  PatientRoom   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		             */   
    '/*		         DATE CREATED: 02/4/2021                                */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to make information we bring back from the PatientRoom*/
    '/*  easier to read.                                                    */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	EnumList.PatientRoom.PatientID										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 ActiveFlag - this will tell us if the record is in active use or not*/
    '/*  BedName - this is the name of the bed.                            */
    '/*  PatientID - this is for the ID of the patient.                    */
    '/*  RoomID - this is for the ID of the Room. 						   */                                       
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum PatientRoom
        PatientID = 0
        RoomID = 1
        BedName = 2
        ActiveFlag = 3
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME:  PatientUser   					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	2/4/2021                          	   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*	 This is going to make information brought back from the PatientUser*/                     
    '/*  table more readable.                                              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:		                						   */             
    '/*	Enum.PatientUser.UserID 										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  ActiveFlag - this is to tell us if the record is in active use or not*/
    '/*  PatientID - this is the ID of the Patient this record is in relation*/
    '/*      to.                                                             */
    '/*  UserID - this is the nurse id this record is in relation to.       */
    '/*  VistDate - this is for the date the visit started on.  		   */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Enum PatientUser
        PatientID = 0
        UserID = 1
        VistDate = 2
        ActiveFlag = 3
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME: Personal_Patient_DrawerMedication    */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	2/4/2021                        	   */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:		                    						   */             
    '/*	 This will make the data that we are getting from the 			   */                     
    '/*  Personal_Patient_DrawerMedication table more readable.            */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*	EnumList.Personal_Patient_DrawerMedication.DrawerMedicationID    */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 activeFlag - this will tell us if the record is in active use or not*/
    '/*  DrawerMedicationID - this is the ID for the entry in the         */
    '/*     DrawerMedication table.                                       */
    '/*  PatientID - this is the ID of the patient this record is in      */
    '/*     relation to.                                                  */
    '/*  RemoveDispensing  - This is going to tell us if the patients personal*/
    '/*     medication is being dispensed.                                 */
    '/*  TUID - this is the ID for this record.             			   */                    
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/5/2021 changed TUID to PersonalMedicationID to correctly */
    '/*                 match the database.                               */
    '/*********************************************************************/

    Enum Personal_Patient_DrawerMedication
        PersonalMedicationID = 0
        PatientID = 1
        DrawerMedicationID = 2
        RemoveDispensing = 3
        activeFlag = 4
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME: Physician       					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		            */   
    '/*		         DATE CREATED: 	02/4/2021	                           */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*											   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:		                						   */             
    '/*	Enum.Physician.Address  										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  ActiveFlag - this is to tell us if the record is in active use or*/
    '/*     not.                                                          */
    '/*  Address - this is the address we have for the physician.         */
    '/*  City - this is for the city that the physician lives in.         */
    '/*  FaxNumber - this is the fax number for the physican.             */
    '/*  FirstName - this is the physicans first Name.                    */
    '/*  Id - this is the ID of the physician.                            */
    '/*  LastName - this is the physicans last name.                      */
    '/*  MiddlName - this is for the physicans middle name.               */
    '/*  PhoneNumber - this is for the physicans phone number.            */
    '/*  PhysicianCredentials - this tells us what the phsyicians is allowed*/
    '/*     to do.                                                        */
    '/*  State - this is the state the physican lives in.                 */
    '/*  Zipcode - this is the zip code the physician lives in.     	   */                    
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum Physician
        Id = 0
        FirstName = 1
        MiddlName = 2
        LastName = 3
        PhysicianCredentials = 4
        PhoneNumber = 5
        FaxNumber = 6
        Address = 7
        City = 8
        State = 9
        Zipcode = 10
        ActiveFlag = 11
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME: ROOM             					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		          */   
    '/*		         DATE CREATED: 	02/4/2021                        	   */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:                  								   */             
    '/*	 This is going to make the data we bring back from the rooms table */
    '/*  more readable.                                                    */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   */             
    '/*	EnumList.Room.ID           										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 ActiveFlag - this is going to tell us if the record is in active */
    '/*     Use or not.                                                   */
    '/*  BedName - This is the name of the bed.                           */
    '/*  Id - this is the ID of the room.                                 */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Enum Rooms
        Id = 0
        BedName = 1
        ActiveFlag = 2
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME: Settings        					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 	02/4/2021                         	   */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:	                    							   */             
    '/*	 This is going to help make the data we bring back from the settings*/                     
    '/*  table more readable.                                              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:						                		   */             
    '/*	Enumlist.Settings.Comport										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  bitRate - this is the bit rate that is going to be used for talking*/
    '/*     to the cart.                                                   */
    '/* ComPort - this is the comport that is going to be used for talking */
    '/*     to the cart.                                                   */
    '/* ID - this is the TUID of this record.                              */
    '/* SimulationFlag- this is the flag to tell us if we are in the       */
    '/*     cart simulation mode or not.                                   */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Enum Settings
        ID = 0
        bitRate = 1
        ComPort = 2
        SimulationFlag = 3
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME:  User              				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 2/4/2021                     		   */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:					                    			   */             
    '/*	 This is going to help make the data we get form the user table   */                     
    '/*  to be more readable.                                             */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   */             
    '/*	 EnumList.User.FirstName										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 ActiveFlag - this is going to tell us if the record is in active */
    '/*     use or not.                                                   */
    '/* AdminFlag - this is going to tell us if the user is an Admin.     */
    '/* BarCode - this is going to be the barcode that is on the users ID */
    '/* FistName - this is the users first name.                          */
    '/* ID - this is the ID of the user.                                  */
    '/* LastName - this is the last name of the user.                     */
    '/* Password - this is the password that user has created.            */
    '/* SuperVisorFlag - this will tell us if the user is a supervisior.  */
    '/* UserName - this is the user name the user will use to log into the*/
    '/*     system.                                                       */                                                                
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Enum User
        ID = 0
        UserName = 1
        Password = 2
        FistName = 3
        LastName = 4
        Barcode = 5
        AdminFlag = 6
        SuperVisorFlag = 7
        ActiveFlag = 8
    End Enum

    '/*********************************************************************/
    '/*                   ENUM NAME: Waste          					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  ENUM PURPOSE:			                    					   */             
    '/*	 This is going to make the data we bring back from the waste table */
    '/*  easier to read.                                                   */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:					                			   */             
    '/*	Enumlist.Waste.Reason   										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	DateTime - this is the date and time the waste is taking place.   */
    '/* DrawerMedicationTUID - this is the TUID for the DrawerMedication  */
    '/*     record this waste entry is in relation to.                    */
    '/* ID - this is the ID of the current record we are working with.    */
    '/* MedicationID - this is the ID of the medication we are wasting.   */
    '/* PrimaryUserID - this is the nurse attempting to waste the medication*/
    '/* Reason - This is the reason the medication is being wasted.       */
    '/* SecondaryUserID - this is the second nurse signing off on the first*/
    '/*     nurses attempt to waste.                                      */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    2/5/2021 Removed the MedicationID to match the updates to  */
    '/*                 the database.                                     */
    '/*********************************************************************/


    Enum Waste
        ID = 0
        PrimaryUserID = 1
        SecondaryUserID = 2
        DrawerMedicationTUID = 3
        DateTime = 4
        Reason = 5
    End Enum
End Module
