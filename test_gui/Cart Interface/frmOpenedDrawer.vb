Public Class frmOpenedDrawer
    '/*********************************************************************/
    '/*                   FILE NAME:  frmOpenedDrawer                       */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: MedServe         				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		             */		  
    '/*		         DATE CREATED:	2/2/2021                    		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									                   */			  
    '/*  This is going to hold the form that lets the user know a drawer is*/
    '/*  open. It exists to give the user a way to indicate a crat is closed */
    '/*  if the cart should fail to report it correctly. 
    '/* 																	  
    '/*********************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			       */ 
    '/*                                                    (NONE)	       */	  
    '/*********************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                    */			  
    '/*                          (NOTHING)				            	   */		  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:						                		   */			  
    '/*				(none)                  							   */					  
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
    '/*                   SUBPROGRAM NAME:  btnClose_Click    			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/2/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:						            		   */             
    '/*	 This is going to handle the user clicking the close button. 	   */
    '/*  it exists in case the cart doesn't corretly send the code that a */
    '/*  drawer has closed it will allow the user to indicate that a drawer */
    '/*  has been closed.                                                  */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*   Form button click                                				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*  sender – Identifies which particular control raised the          */
    '/*          click event                                              */
    '/*  e – Holds the EventArgs object sent to the routine               */        
    '/*                                                                   */  
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:			                					   */             
    '/*		btnClose.click          									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*		(none)									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CartInterfaceCode.minusDrawerCount()
    End Sub



    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  btnReOpen_Click				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                  */   
    '/*		         DATE CREATED: 	3/24/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This runs if the user needs to reopen the drawer. It just calls   */
    '/*  the reopenDrawer method in the CartInterfaceCode.vb file.         */
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


    Private Sub btnReOpen_Click(sender As Object, e As EventArgs) Handles btnReOpen.Click
        reopenDrawer()
    End Sub

    Public isDragging As Boolean = False, isClick As Boolean = False
    Public startPoint, firstPoint, lastPoint As Point




    '/*********************************************************************/
    '/*           SubProgram NAME: TopBar_MouseDown                        */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the mouse down event occurs on the menu bar, the program will/
    '/*  record the starting location and set the isDragging bln as true to/
    '/*  to indicate that an item is being moused down and dragged        */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '*/  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- mouseeventargs indicating there is a mouse event handle       */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*        */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier 3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub TopBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlDrawer.MouseDown

        startPoint = pnlDrawer.PointToScreen(New Point(e.X, e.Y))
        firstPoint = startPoint
        isDragging = True

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: TopBar_MouseMove                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 If the user is dragging the mouse after clicking the menu bar,then/
    '/*  the end point will be where the user lets go of the mouse. Me, will
    '/*  move the form to the specified location.                          /
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '*/  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- mouseeventargs indicating there is a mouse event handle       */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  endPoint- a point variable to hold coordinates of controls       */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub TopBar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlDrawer.MouseMove

        If isDragging Then
            Dim endPoint As Point = pnlDrawer.PointToScreen(New Point(e.X, e.Y))
            isClick = False
            Me.Left += (endPoint.X - startPoint.X)
            Me.Top += (endPoint.Y - startPoint.Y)
            startPoint = endPoint
            lastPoint = endPoint
        End If

    End Sub

    '/*********************************************************************/
    '/*           SubProgram NAME: TopBar_MouseUp                         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 3/20/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 When the user is no longer clicking and dragging this gets called*/
    '/*  dragging becomes false and we check if the lastPoint is the start*/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '*/  
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*    none                                                           */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	none                                                              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	                      			  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*        */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  3/20/2021    Initial creation                    */
    '/*********************************************************************/
    Private Sub TopBar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlDrawer.MouseUp

        isDragging = False
        If lastPoint = startPoint Then isClick = True Else isClick = False

    End Sub
End Class