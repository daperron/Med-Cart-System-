Public Class frmMaintenance



    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:btnUpload_Click                  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	3/8/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								               */             
    '/*	 This is going to run when the user clicks select file. It will set*/
    '/*  up the file dialog box, get the file, figure out what type of file*/
    '/*  we are importing and then call the import method.                 */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					            */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 strFileName - this is the path to the file that the user selects */
    '/*                 by default it is nothing.                         */
    '/*  strFileType - this is teh type of file that we are importing.    */
    '/*                 it will be a patient, physician, user, or room file*/
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim strFileName As String = Nothing
        Dim strFileType As String = Nothing
        With OpenFileDialog1
            .Filter = "Tab Seperated Files (*.txt)|*.txt"
            .CheckPathExists = True
            If .ShowDialog = DialogResult.OK Then
                strFileName = .FileName
            End If
        End With

        Select Case True
            Case radPatient.Checked
                strFileType = "patient"
            Case radPhysician.Checked
                strFileType = "physician"
            Case radRoom.Checked
                strFileType = "room"
            Case radUser.Checked
                strFileType = "user"
            Case radDrawers.CheckAlign
                strFileType = "drawer"
        End Select

        If Not IsNothing(strFileName) Then
            importStart(strFileName, strFileType)
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  frmMaintenance_Load			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 3/8/2021		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to run when the form first starts. It is going to  */
    '/*  make sure there is a default radio button selected.              */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
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


    Private Sub frmMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        radPatient.Checked = True
        radDatabse.Checked = True
        pnlOptions.Visible = False
    End Sub

    Private Sub btnExportDatabase_Click(sender As Object, e As EventArgs) Handles btnExportDatabase.Click
        pnlRecords.Visible = False
        ExportDatabase()
    End Sub

    Private Sub btnImportDatabase_Click(sender As Object, e As EventArgs) Handles btnImportDatabase.Click
        pnlRecords.Visible = False
        ImportDatabase()
    End Sub

    Private Sub btnImportAsCopy_Click(sender As Object, e As EventArgs) Handles btnImportAsCopy.Click
        pnlRecords.Visible = False
        ImportDatabaseAsCopy()
    End Sub

    Private Sub radDatabse_CheckedChanged(sender As Object, e As EventArgs) Handles radDatabse.CheckedChanged, radRecords.CheckedChanged
        If radDatabse.Checked = True Then
            pnlRecords.Visible = False
            pnlDatabase.Visible = True
        Else
            pnlRecords.Visible = True
            pnlDatabase.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRecords.Click

        If pnlRecords.Visible = False Then

            pnlRecords.Visible = True

        End If

    End Sub
End Class