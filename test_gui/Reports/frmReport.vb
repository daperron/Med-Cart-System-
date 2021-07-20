


Public Class frmReport

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Eric LaVoie           		         */   
    '/*		         DATE CREATED: 		   */                             
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
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulateReportsList()


    End Sub

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  					   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Eric LaVoie           		         */   
    '/*		         DATE CREATED: 		   */                             
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
    '/*  WHO        WHEN        WHAT								      */             
    '/*  ---        ----        ------------------------------------------*/
    '/*  Eric L.    03/16/21    Initial creation of code                  */  
    '/*  BRH        03/21/21    Add narcotics wasted, add all wasted meds,
    '/*                         narcotic ad hoc orders, 
    '/*  BRH        03/25/21    Added Active and Resolved Discrepancy code*/
    '/*  BRH        03/28/21    Added Allergy and Drug Interaction overrides
    '/*                         and all and narcotic end of shift counts  */
    '/*  BRH        04/11/21    Updated End of Shift count to Restock Inventory.
    '/*********************************************************************/
    Private Sub PopulateReportsList()

        Const STRACTIVEDISCREPANCIES As String = "Active Discrepancies"
        Const STRDISPENSINGHISTORY As String = "Dispensed Medications"
        Const STRADHOCORDERS As String = "Ad Hoc Orders"
        Const STRNARCADHOCORDERS As String = "Narcotic Ad Hoc Orders"
        Const STRNARCOTICSDISPENSED As String = "Narcotics Dispensed"
        Const STRNARCOTICSWASTED As String = "Narcotics Wasted"
        Const STRALLERGYOVERRIDES As String = "Allergy Overrides"
        Const STRWASTES As String = "Wasted Medication"
        Const STRRESOLVEDDISCREPANCIES As String = "Resolved Discrepancies"
        Const STRDRUGINTERACTIONOVERRIDES As String = "Drug Interaction Overrides"
        Const STRNARCRESTOCKINVENTORY As String = "Narcotic Restock Inventory"
        Const STRRESTOCKINVENTORY As String = "Restock Inventory"

        cmbReports.Items.Add(STRACTIVEDISCREPANCIES)
        cmbReports.Items.Add(STRDISPENSINGHISTORY)
        cmbReports.Items.Add(STRADHOCORDERS)
        cmbReports.Items.Add(STRNARCADHOCORDERS)
        cmbReports.Items.Add(STRNARCOTICSDISPENSED)
        cmbReports.Items.Add(STRNARCOTICSWASTED)
        cmbReports.Items.Add(STRALLERGYOVERRIDES)
        cmbReports.Items.Add(STRWASTES)
        cmbReports.Items.Add(STRRESOLVEDDISCREPANCIES)
        cmbReports.Items.Add(STRDRUGINTERACTIONOVERRIDES)
        cmbReports.Items.Add(STRNARCRESTOCKINVENTORY)
        cmbReports.Items.Add(STRRESTOCKINVENTORY)

    End Sub
    '/*******************************************************************/
    '/*          SUBROUTINE NAME:     btnGenerateReport_Click		    */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Eric Lavoie					    */
    '/*		         DATE CREATED: 	   03/16/21							*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	 The purpose of this subroutine is to generate the data for the */
    '/*  selected report into the datatable. If the user doesn't select */
    '/*  a report, the program will notify them and won't go on until a */
    '/*  report is created. Once a report is selected, it will call     */
    '/* getSelectedReport to get the data from the tables that were specified
    '/* from the user's selection. Then, the data is populated into the */
    '/* data table and made visible to the user.                        */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*  (None)								           					*/
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*  getSelectedReport()										    */
    '/*  PrintItemsToDataGrid()                                         */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*	 sender- object representing a control                          */
    '/*  e- eventargs indicating there is an event handle assigned      */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*  btnGenerateReport_Click										*/
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/*  lstOfDataValues - Stores the list of items returned from the   */
    '/*                    tables relating to the user's report selection/
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/*  WHO	    WHEN        WHAT									*/
    '/*  ---        ----        ----------------------------------------*/
    '/*  Eric L.    03/16/21    Initial creation of code                */
    '/*  BRH        03/18/21    Added functionality for displaying the  */
    '/*                         Dispensed Narcotics on the form.        */
    '/*  BRH        04/01/21    Hide data grid view if there isn't a report
    '/*                         and auto resize the columns             */
    '/*  BRH        04/11/21    Updated End of Shift count to Restock Inventory
    '/*******************************************************************/
    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        Dim lstOfDataValues As List(Of String) = New List(Of String)



        dgvReport.Columns.Clear()
        dgvReport.Rows.Clear()

        If cmbReports.SelectedIndex < 0 Then
            MessageBox.Show("Please select a report from the drop down menu", "No Selected Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            lstOfDataValues = getSelectedReport(cmbReports.SelectedIndex)

            If lstOfDataValues.Count = 0 Then
                'If there isn't anything to report
                'hid the item showing the report on the form
                dgvReport.Visible = False
                MessageBox.Show("There is nothing to report.")
            Else
                PrintItemsToDataGrid(lstOfDataValues)
                dgvReport.Visible = True
                'autoresizes the columns to fit the data
                dgvReport.AutoResizeColumns()
            End If

        End If

    End Sub

    '/*******************************************************************/
    '/*          SUBROUTINE NAME:     btnExportToExcel_Click		    */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Eric Lavoie					    */
    '/*		         DATE CREATED: 	   03/24/21							*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	 The purpose of this subroutine is to generate the data for the */
    '/*  selected report into Excel. Once the user generates the report */
    '/*  on the form, the user can click the Export Report To Excel     */
    '/*  button, opening the data in Excel.                             */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*  (None)								           					*/
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*  ExportToExcel()										        */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*	 sender- object representing a control                          */
    '/*  e- eventargs indicating there is an event handle assigned      */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*  btnExporttoExcel_Click										    */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/*  (None)                                                         */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/*  WHO	    WHEN        WHAT									*/
    '/*  ---        ----        ----------------------------------------*/
    '/*  BRH        03/23/21    Initial creation of code                */
    '/*******************************************************************/
    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        ExportToExcel(strReport)
    End Sub

End Class
