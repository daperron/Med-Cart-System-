Imports System.Text
Module PopulateRoomsCombBoxesMethods


    '/*********************************************************************/
    '/*                   FILE NAME: PopulateRoomsCombBoxesMethods        */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: Test_GUI       				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		               */		  
    '/*		         DATE CREATED:	2/8/2021                      		   */						  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									                      */			  
    '/*	 This holds the method that will handle populating the combo box for*/
    '/*  rooms and the beds on a number of forms.                           */					  
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
    '/*  NP    2/16/2021 Added UpdateBedComboBox                          */
    '/*********************************************************************/



    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  PopulateRoomComboBox 	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 2/6/2021                     		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								               */             
    '/*	 This is going to populate a combo box with the list of rooms that */
    '/*  are in our database.                                              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	cboRoom - this is the combo box that we are going to be populating*/
    '/* dsrooms- this is the dataset of the rooms that we are going to be */
    '/*     using. 
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                    */             
    '/*	PopulateRoomsCombBoxesMethods.PopulateRoomComboBox                 */
    '/*                         (CboRooms, dsRooms)					       */                     
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

    Sub PopulateRoomComboBox(cboRoom As ComboBox, dsrooms As DataSet)
        cboRoom.Items.Clear()

        For Each row As DataRow In dsrooms.Tables(0).Rows
            If checkComboForDup(cboRoom, row(EnumList.Rooms.Id)) Then
                cboRoom.Items.Add(row(EnumList.Rooms.Id))
            End If
        Next
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: populateBedComboBox  		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:						            		   */             
    '/*	This is going to populate a combo box with the list of rooms that  */                     
    '/* we have in our database. It is only going to post the unique ones. */
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
    '/*	PopulateRoomsCombBoxesMethods.populateBedComboBox(cmbBed, dsrooms)*/                     
    '/*                                                                   */
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


    Sub populateBedComboBox(cboBed As ComboBox, dsrooms As DataSet)
        cboBed.Items.Clear()

        For Each row As DataRow In dsrooms.Tables(0).Rows
            If checkComboForDup(cboBed, row(EnumList.Rooms.BedName)) Then
                cboBed.Items.Add(row(EnumList.Rooms.BedName))
            End If
        Next
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: UpdateBedComboBox      		   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 	2/16/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPRORAM PURPOSE:								                   */             
    '/*	 this is going to update the list of options in the beds combobox  */
    '/*  based on what is selected in the rooms combobox.                  */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 cboBed - this is the combobox that is being used for the beds    */

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

    Sub UpdateBedComboBox(cboBed As ComboBox, cboRoom As ComboBox)
        Dim strbSQL = New StringBuilder
        Dim dsBeds As DataSet
        strbSQL.Append("Select * from Rooms where Room_ID = '")
        strbSQL.Append(cboRoom.SelectedItem & "' and active_flag = '" & 1 & "';")

        dsBeds = CreateDatabase.ExecuteSelectQuery(strbSQL.ToString)

        populateBedComboBox(cboBed, dsBeds)


    End Sub
End Module
