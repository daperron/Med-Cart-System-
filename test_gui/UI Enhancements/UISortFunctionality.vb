Module UISortFunctionality

    '/*********************************************************************/
    '/*                   SubProgram NAME: CreateToolTips                 */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to iterate over the  panel that contains labels and*/
    '/*  assign each label a tooltip
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmPatientInfo_load      */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                           */  
    '/*              
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 PanelWithLabels- a panel which contains only labels              */ 
    '/*	 tp- a tooltip control                                            */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	CreateToolTips(Panel1, ToolTip1)     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	directions- string to be appended                                 */
    '/*	newDirections- result of the appending of strings                 */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub CreateToolTips(ByVal PanelWithLabels As Panel, ByVal tp As ToolTip)

        'iterating over the header panel which will only contain labels within it
        'each label needs to have a tooltip added to it.

        Dim directions As String = "click to sort by "


        For Each ctl In PanelWithLabels.Controls

            Dim newDirections As String = Nothing
            newDirections = directions & CStr(ctl.Text)
            tp.SetToolTip(ctl, newDirections)

        Next

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: AddHandlerToLabelClick         */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to iterate over the  panel that contains labels and*/
    '/*  assign each label a a click event handler                        */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmPatientInfo_load                                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 PanelWithLabels- a panel which contains only labels              */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	AddHandlerToLabelClick(Panel1)     							      */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	lbl- label control*/
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub AddHandlerToLabelClick(ByVal PanelWithLabels As Panel, handle As EventHandler)

        'assign a handler to each label in the header panels to allow for a reusable click event

        Dim lbl As Label

        For Each lbl In PanelWithLabels.Controls
            AddHandler lbl.Click, handle
        Next

    End Sub

    '/*********************************************************************/
    '/*                   SubProgram NAME: BoldLabelToSortBy              */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Collin Krygier   		          */   
    '/*		         DATE CREATED: 		 2/14/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This is going to iterate over the  panel that contains labels and*/
    '/*  check which one selected and change the font to be underlined    */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*      frmPatientInfo_load                                          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 clickedLabel- a label that was selected                          */ 
    '/*	 parent- a panel object that the label lives on                   */ 
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	 BoldLabelToSortBy(sender, parent)     							  */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	lbl- label control*/
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  Collin Krygier  2/14/2021    Initial creation                    */
    '/*********************************************************************/
    Public Sub BoldLabelToSortBy(ByVal clickedLabel As Label, ByVal parent As Panel)

        Dim lbl As Label
        ' remove underlined font from all labels
        For Each lbl In parent.Controls
            lbl.Font = New Font(New FontFamily("Segoe UI Semibold"), 12, FontStyle.Regular)

        Next

        ' underline just the selected label
        clickedLabel.Font = New Font(New FontFamily("Segoe UI Semibold"), 12, FontStyle.Underline)

    End Sub


    ' if we know the parent then we can determine if we need the prescription table
    ' or if we need the dispense history tables

End Module
