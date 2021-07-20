Public Class DrawerClass
    '/*********************************************************************/
    '/*                   FILE NAME: DrawerClass                             */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: MedServe				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		              */		  
    '/*		         DATE CREATED:	4/17/2021                   		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 This is going to hold the class for the drawer objects for the    */
    '/*  Drawer imports. 
    '/* 																	  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */			  
    '/*											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			         */		  
    '/* DrawerNode - this is the communication mode the drawer us using to open*/
    '/* DrawerNumber - This is the number the drawer is on the cart.       */
    '/* NumberofDividers - this is the number of dividers in the drawer    */
    '/* Size - 	this is how large the drawer is and what it can hold.      */					  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */				  
    '/*											   */					  
    '/*  WHO   WHEN     WHAT								   */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/*********************************************************************/



    Private intDrawerNode As Integer
    Private intDrawerNumber As Integer
    Private intSize As Integer
    Private intNumberofDividers As Integer

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  New					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   	       	         */   
    '/*		         DATE CREATED: 4/17/2021                    		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*  This is the constructor for the Drawer objects					   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 DrawerNode - this is the value that will be assgined to intDrawerNode*/
    '/*  DrawerNum - this is the value that is going to be assigned to     */
    '/*               intDrawerNumber                                      */
    '/*  size - this is the value that is going to be assigned to intSize  */
    '/*  NumOfDividers - this is the value that is going to be assigned to */
    '/*                   IntNumberOfDividers                              */
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

    Public Sub New(DrawerNode As Integer, DrawerNum As Integer, size As Integer, NumOfDividers As Integer)
        With Me
            .DrawerNode = DrawerNode
            .DrawerNumber = DrawerNum
            .size = size
            .NumberOfDividers = NumOfDividers
        End With
    End Sub


    '/*********************************************************************/
    '/*                   PROPERTY NAME:  	DrawerNode				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 4/17/2021		   */                             
    '/*********************************************************************/
    '/*  PROPERTY PURPOSE:								   */             
    '/*	 This is the getter and setter for the intDrawerNode    		   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the value that is going to be assigned to        */
    '/*         intDrawerNode                                             */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intDrawerNode								   */             
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

    Public Property DrawerNode As Integer
        Get
            Return intDrawerNode
        End Get
        Set(value As Integer)
            intDrawerNode = value
        End Set
    End Property

    '/*********************************************************************/
    '/*                   PROPERTY NAME: DrawerNumber 					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	4/17/2021	   */                             
    '/*********************************************************************/
    '/*  PROPERTY PURPOSE:								   */             
    '/*	 This is the getter and setter for the intDrawerNumber			   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the value being assigned to intDrawerNumber       */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intDrawerNumber								   */             
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


    Public Property DrawerNumber As Integer
        Get
            Return intDrawerNumber
        End Get
        Set(value As Integer)
            intDrawerNumber = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   PROPERTY NAME:  size      					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	4/17/2021                       	   */                             
    '/*********************************************************************/
    '/*  PROPERTY PURPOSE:								   */             
    '/*	 This is the getter and setter for intSize      				   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the value that is going to be assgined to intSize*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intSize								   */             
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

    Public Property size As Integer
        Get
            Return intSize
        End Get
        Set(value As Integer)
            intSize = value
        End Set
    End Property


    '/*********************************************************************/
    '/*                   PROPERTY NAME:  NumberOfDividers					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	4/17/2021	   */                             
    '/*********************************************************************/
    '/*  PROPERTY PURPOSE:								   */             
    '/*	 This is the getter and setter for intNumberOfDividers              */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the value that is going to be assigned to  	   */
    '/*         intNumberOfDividers                                         */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intNumberOfDividers    								   */             
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

    Public Property NumberOfDividers As Integer
        Get
            Return intNumberofDividers
        End Get
        Set(value As Integer)
            intNumberofDividers = value
        End Set
    End Property

End Class
