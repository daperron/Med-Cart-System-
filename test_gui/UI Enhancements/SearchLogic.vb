Module SearchLogic


    '/*********************************************************************/
    '/* SubProgram NAME:txtSearchGotFocusEvent                            */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/26/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This sets the behavior of when this control gets focus. We are   */
    '/*  trying to remove the dummy text when the user enters the field   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                    */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*                                       */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/16/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub txtSearchGotFocusEvent(ByVal txtSearchBox As TextBox)

        ' when the search box gains focus, we will remove the default text only if the user has not typed in it yet
        If txtSearchBox.ForeColor = Color.Silver Then

            txtSearchBox.Text = Nothing
            ' update the color of the search text to be black
            txtSearchBox.ForeColor = Color.Black

        End If

    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:txtSearchLostFocusEvent                           */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/26/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This sets the behavior of when this control loses focus. We will */
    '/* reset the text to the dummy text if it is empty, otherwise keep txt/
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                          */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*                                     */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/16/2021    Initial creation                    */
    '/*********************************************************************/

    Public Sub txtSearchLostFocusEvent(ByVal txtSearchBox As TextBox)

        ' when the search box loses focus, we will check and see if they put any text in it
        ' if they didnt, we will reset it to the default text.
        If txtSearchBox.Text = "" Then

            'reset the text to the default and set the font color to be black
            'txtSearchBox.Text = txtSearchBox.Tag
            txtSearchBox.ForeColor = Color.Silver
        End If

    End Sub


End Module
