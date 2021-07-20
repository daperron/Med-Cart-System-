Public Class frmResolve

    Private discrepancyID As Integer

    Public Sub SetDiscrepancyID(ByVal ID As Integer)

        discrepancyID = ID

    End Sub

    Private Sub frmResolve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' take the selected panel from the flow panel and pass over the ID of it. We can also use this data
        ' to to delete from the database because we can search by ID in the where statement.
        ' lblDiscrepancyID.Text = "Discrepancy ID " & frmDiscrepancies.getSelectedDiscrepancyLabel().Text
        'txtResolved.Tag = frmDiscrepancies.getSelectedDiscrepancyLabel().Text
        ' MessageBox.Show(discrepancyID)
    End Sub

    '/********************************************************************/
    '/*            SUB NAME: btnResolve_Click                    	     */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	3/15/21			                     */                             
    '/********************************************************************/
    '/*  SUB Purpose:                                                    */
    '/*  updates the user it has been resolved and then closes the form .*/
    '/*  directing the user back to the discrepancies page.              */
    '/*                                                                  */
    '/********************************************************************/
    '/*  CALLED BY: DynamicSingleClickOpenPatient   	      		     */				            
    '/*                                        				             */         
    '/********************************************************************/
    '/*  CALLS:								                             */		                  
    '/*             (NONE)						                         */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/*	                                                                 */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	DynamicSingleClickOpenPatient()					                 */					                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 checkIfSelected                           				         */
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                                 
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		3/15/21		 initial creation                            */
    '/********************************************************************/ 
    Private Sub btnResolve_Click(sender As Object, e As EventArgs) Handles btnResolve.Click

        'CALL TO DELETE DISCREPANCY FROM DATABASE TABLE HERE

        'call method to remove the selected discrepancy from the panel and list
        'RemoveItemFromFlowPanel(frmDiscrepancies.getSelectedDiscrepancyLabel())
        If Not String.IsNullOrEmpty(txtResolved.Text) Then
            Dim strResolve As String = txtResolved.Text
            Discrepancies.ResolveDiscrepancies(discrepancyID, strResolve)
            'close the resolve form 
            'Me.Close()
            MessageBox.Show("Reason recorded and the discrepancy has been resolved.")
            frmMain.OpenChildForm(frmDiscrepancies)
        Else
            MessageBox.Show("Please enter a reason to resolve the discrepancy.")
        End If


    End Sub

    '/********************************************************************/
    '/*                   SUB NAME: RemoveItemFromFlowPanel            	 */         
    '/********************************************************************/
    '/*                   WRITTEN BY: Collin Krygier  		             */   
    '/*		         DATE CREATED: 	2/7/21			                     */                             
    '/********************************************************************/
    '/*  SUB PURPOSE: contains the logic to remove items from the flow   */
    '/*  on the frmDiscrepancies.                                        */
    '/********************************************************************/
    '/*  CALLED BY:                                      	      		 */				            
    '/*                 btnResolve_Click                                 */         
    '/********************************************************************/
    '/*  CALLS:							                            	 */		                  
    '/*            (NONE)     	            				             */		               
    '/********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):				             */	           
    '/* ctl- an object of type control                                   */
    '/********************************************************************/
    '/* SAMPLE INVOCATION:						                         */		             
    '/*	RemoveItemFromFlowPanel(panelName)                               */				                       
    '/*                                                                  */   
    '/********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):   */
    '/*	 ctlControl- an object of type control                           */
    '/*	 ctlParents an object of type control to represent a controls parent
    '/*	 ctlParentFlowPanel- represents the flow panel the control is in */
    '/*	 strParentPanelName- the string name of the control panel to remove
    '/********************************************************************/
    '/* MODIFICATION HISTORY:						                     */		                 
    '/*									                                 */		                   
    '/*  WHO            WHEN             WHAT				             */		            
    '/*  ---            ----             ----				             */
    '/*  CK		        2/7/21		    initial creation                 */
    '/********************************************************************/ 
    'Public Sub RemoveItemFromFlowPanel(ctl As Control)

    '    'the parent of the button will be the panel the control is located on.
    '    'we want to get one step removed so we need to next take the parent of the control
    '    'to get the name of flowpanel which the button is laid out on

    '    Dim ctlControl As Control = ctl.Parent
    '    Dim ctlParents As Control = ctlControl.Parent
    '    Dim ctlParentFlowPanel As Control = ctlControl.Parent
    '    Dim strParentPanelName As String
    '    strParentPanelName = Nothing

    '    'Remove handler from sender
    '    For Each ctlObject As Control In ctlParentFlowPanel.Controls
    '        For Each ctlChildControlObj As Control In ctlObject.Controls
    '            If ctlChildControlObj.Name = ctl.Name Then
    '                strParentPanelName = ctlChildControlObj.Parent.Name
    '            End If
    '        Next
    '    Next

    '    'Remove  panel
    '    For Each ctlObject As Control In ctlParentFlowPanel.Controls
    '        If ctlObject.Name = strParentPanelName Then

    '            'remove the padding panel from the flow panel
    '            ctlParentFlowPanel.Controls.Remove(ctlObject.Parent)
    '            ctlObject.Parent.Dispose()

    '            'remove the panel from the flow panel
    '            ctlParentFlowPanel.Controls.Remove(ctlObject)
    '            ctlObject.Dispose()
    '        End If
    '    Next

    'End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmMain.OpenChildForm(frmDiscrepancies)
    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:        txtResolved_KeyPress                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker       		          */   
    '/*		         DATE CREATED: 		3/02/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This assess what key is pressed and restricts the keys to the string
    '/* passed to the KeyPressCheck function.                             */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  KeyPressCheck                                                    */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*  txtResolved_KeyPress                                              */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*	 AB    03/03/2021   Initial Creation	
    '/*											                          */ 
    '/*  ---   ----     ------------------------------------------------  */

    Private Sub txtResolved_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtResolved.KeyPress
        KeyPressCheck(e, "abcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()_+= {}[]|:,.<>?`~")
    End Sub

End Class