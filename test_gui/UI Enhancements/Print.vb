Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Module Print
    '/*******************************************************************/
    '/*                   FILE NAME:  Print.vb                          */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  Eric R. LaVoie   		        */
    '/*		         DATE CREATED: January 25, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*											                        */
    '/* This module will send information to MS OFFICE in order to      */
    '/* br printed or be saved.                                         */
    '/*******************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
    '/*                                                    (NONE)	    */
    '/*******************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                */
    '/*                          (NOTHING)					            */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:								                */
    '/*											                        */
    '/* the program will invoke this module on load. Individual         */
    '/* functions will be invoked separately by the forms that allow    */
    '/* items to be printed. From there, the appropriate office interop */
    '/* application will be invoked.                                    */
    '/*******************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                */
    '/*						  	 (NONE)			                        */
    '/*******************************************************************/
    '/* COMPILATION NOTES:								                */
    '/* 											                    */
    '/* This project compiles normally under Microsoft Visual Basic.    */
    '/* All one needs to do Is open up the Solver project And compile.  */
    '/* No special compile options Or optimizations were used.  No      */
    '/* unresolved warnings Or errors exist under these compilation     */
    '/* conditions.									                    */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:						                    */
    '/*											                        */
    '/*  WHO            WHEN        WHAT								*/
    '/*  Jordan Roberts 2/09/2021   Basic functionality implemented; 
    '/**    module can tell which combo box item from frmreport was selected
    '/*     and sub routines can create a document and table in word and
    '/*     open for viewing. Module is not wired to the database yet.
    '/*******************************************************************/

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
    Sub GenerateReportToWord(ByVal strItem As String, ByRef intColumnCount As Integer, ByRef intRowCount As Integer, ByRef lstOfDataValues As List(Of String))
        Dim aWordApplication As Word.Application
        Dim aWordDocument As Word.Document
        aWordApplication = New Word.Application
        'Open up the aWordApplication variable and modify some of the style preferences
        With aWordApplication
            .Visible = True
            aWordDocument = .Documents.Add()
            .Selection.Font.Size = 8
            .Selection.Font.Name = "Calibri"
            .ActiveWindow.View.TableGridlines = False
        End With

        CreateAndAddTableToWordForFormatting(aWordDocument, intColumnCount, intRowCount)
        Dim intToKeepTrackOfDataInList As Integer = 0

        'this loop will iterate through the lstOfDataValues list that holds each item of the database table
        'and send the data to the table in the Word document.
        For intRow As Integer = 1 To intRowCount
            For intColumn As Integer = 1 To intColumnCount
                aWordApplication.Selection.Tables.Item(1).Cell(intRow, intColumn).Range.Text = lstOfDataValues.Item(intToKeepTrackOfDataInList)
                intToKeepTrackOfDataInList += 1
            Next
        Next

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
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/
    Sub CreateAndAddTableToWordForFormatting(ByRef aWordDoc As Word.Document, ByVal intColumnCount As Integer, ByVal intRowCount As Integer)
        Dim aTableWordDoc As Word.Table
        aTableWordDoc = aWordDoc.Tables.Add(aWordDoc.Range, intRowCount, intColumnCount)
        With aTableWordDoc
            .Range.ParagraphFormat.SpaceAfter = 6
            .Title = "Test Title"
            .AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow)
            .Style = "Plain Table 4"
            With .Borders
                .InsideLineStyle = Word.WdLineStyle.wdLineStyleNone
                .OutsideLineStyle = Word.WdLineStyle.wdLineStyleNone
            End With
        End With
    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:  		ExportToExcel   	  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Breanna Howey           		      */   
    '/*		         DATE CREATED: 		 03/23/21                         */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*  The purpose of this subroutine is to get data from the report and*/
    '/*  export the data to excel. The subroutine will open Excel, allowing
    '/*  the user to save or print the report.                            */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  btnExportToExcel_Click                           				  */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*  (None)							                                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*  (None)                                                           */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/* ExportToExcel()                                                   */                                                                    
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungary notation):   */
    '/*											                          */                     
    '/*  xlApp - Stores an instance of the Excel application              */
    '/*  xlWorkBook - Stores an instance of the Excel Workbook            */
    '/*  xlWorkSheet - Stores an instance of the Excel Worksheet          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO        WHEN        WHAT								      */             
    '/*  ---        ----        ------------------------------------------*/
    '/*  BRH        03/23/21    Initial creation of code                  */
    '/*  BRH        04/01/21    Auto resize the columns when exported     */
    '/*********************************************************************/
    Sub ExportToExcel(strReport As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet


        If frmReport.dgvReport.Rows.Count > 0 Then
            xlApp = New Excel.Application
            'Open 1 sheet in the workbook
            xlWorkBook = xlApp.Workbooks.Add(1)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            'Format the cells with an easy-to-read format
            xlWorkSheet.Cells.Font.Size = 12
            xlWorkSheet.Cells.Font.Name = "Calibri"

            'Insert the headers for the data
            For i As Integer = 0 To intColumnCount - 1
                xlWorkSheet.Cells(1, i + 1) = frmReport.dgvReport.Columns(i).HeaderText
            Next

            'For each row in the data grid view
            For i As Integer = 0 To frmReport.dgvReport.RowCount - 2
                'For each column in the data grid view
                For j As Integer = 0 To frmReport.dgvReport.ColumnCount - 1
                    'Add the cells information from the data grid view to the
                    'Excel worksheet
                    xlWorkSheet.Cells(i + 2, j + 1) =
                    frmReport.dgvReport(j, i).Value.ToString()
                Next
            Next

            'Make the Excel document visible
            xlApp.Visible = True
            'Auto resize columns to fit data
            xlWorkSheet.Columns.AutoFit()
        Else
            MessageBox.Show("There is no data to export to Excel.")
        End If
    End Sub
End Module
