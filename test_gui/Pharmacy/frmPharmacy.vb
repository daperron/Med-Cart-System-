Public Class frmPharmacy
    '/*********************************************************************/
    '/*                   FILE NAME: frmPharmacy                          */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT:				                  */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:                		              */		  
    '/*		         DATE CREATED:		3/16/2020	                      */						  
    '/*********************************************************************/
    '/*  PROJECT PURPOSE:								                  */				  
    '/*											                          */					  
    '/* 																  */	  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									                  */			  
    '/*											                          */					  
    '/* 																  */	  
    '/*********************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			      */ 
    '/*                                                    (NONE)	      */	  
    '/*********************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                  */			  
    '/*                          (NOTHING)					              */		  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */			  
    '/*											                          */					  
    '/* 															      */  
    '/*********************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                  */		  
    '/*						  	 (NONE)			                          */					  
    '/*********************************************************************/
    '/* COMPILATION NOTES(will include version notes including libraries):*/
    '/* 											                      */					  
    '/* 															      */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */				  
    '/*											                          */					  
    '/*  WHO   WHEN     WHAT								              */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/* DP     4/4/2020   initial creation                                */
    '/*********************************************************************/

    Dim currentContactPanel As String = Nothing

    Dim dsPhysicians As DataSet
    Dim dsPatients As DataSet
    Dim dsMedications As DataSet
    Dim intPatientID As New ArrayList
    Dim intMedID As New ArrayList
    Dim intPhysicianID As New ArrayList
    Dim intPatientIDfromArray As Integer = 0
    Dim intMedIDfromArray As Integer = 0
    Dim intPhysicianIDfromArray As Integer = 0
    '/*********************************************************************/
    '/*                   SubFUNCTION NAME:frmPharmacy_Load  			  */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dillen Perron   		              */   
    '/*		         DATE CREATED: 		3/16/2020                         */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*										                        	  */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  dp   4/4/2020  initial creation                                                                  
    '/*********************************************************************/

    Private Sub frmPharmacy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPatientName.Items.Clear()
        cmbOrderedBy.Items.Clear()
        cmbMedication.Items.Clear()
        cmbStrength.Items.Clear()
        cmbFrequencyNumber.Items.Clear()
        txtQuantity.Text = Nothing
        PopulateFrequencyNumberComboBox()
        Dim intCounter As Integer = 0
        dsMedications = ExecuteSelectQuery("SELECT *,Trim(Drug_Name,' ') From Medication Inner Join DrawerMedication ON DrawerMedication.Medication_TUID = Medication.Medication_ID WHERE DrawerMedication.Active_Flag = '1' ORDER BY Medication.Drug_Name COLLATE NOCASE")
        dsPhysicians = ExecuteSelectQuery("Select * From Physician WHERE Active_Flag = '1' ORDER BY Physician_Last_Name COLLATE NOCASE, Physician_First_Name COLLATE NOCASE;")
        dsPatients = ExecuteSelectQuery("Select * From Patient WHERE Active_Flag = '1' ORDER BY Patient_Last_Name COLLATE NOCASE, Patient_First_Name COLLATE NOCASE;")

        For Each dr As DataRow In dsPatients.Tables(0).Rows
            cmbPatientName.Items.Add(dr(EnumList.Patient.LastName) & ", " & dr(EnumList.Patient.FristName) &
                                     "   MRN: " & dr(EnumList.Patient.MRN_Number))
            intPatientID.Add(dr(EnumList.Patient.ID))
        Next

        For Each dr As DataRow In dsPhysicians.Tables(0).Rows
            cmbOrderedBy.Items.Add(dr(EnumList.Physician.LastName) & ", " & dr(EnumList.Physician.FirstName) & " " & dr(EnumList.Physician.PhysicianCredentials))
            intPhysicianID.Add(dr(EnumList.Physician.Id))
        Next

        For Each dr As DataRow In dsMedications.Tables(0).Rows
            cmbMedication.Items.Add(dr(20))
            intMedID.Add(dr(EnumList.Medication.ID))
        Next
    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME: Button1_Click                  */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   03/11/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE:                                              */
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          */
    '/*  (None)								           					  */
    '/*********************************************************************/
    '/*  CALLS:														      */	
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):                             */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */ 						                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  03/11/21  Initial creation of the code      */
    '/*  Dillen Perron        04/03/21  Check for duplicat medication     */
    '/*********************************************************************/
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnORder.Click
        Dim Go As Boolean = True
        Dim Result As DialogResult
        ErrorProvider1.Clear()
        If cmbPatientName.SelectedIndex = -1 Or cmbMedication.SelectedIndex = -1 Or cmbOrderedBy.SelectedIndex = -1 Or cmbFrequencyNumber.SelectedIndex = -1 Or txtUnit.Text = Nothing Or txtUnit.Text = " " Or txtQuantity.Text = Nothing Or txtQuantity.Text = " " Or txtUnit.Text.Trim.Length = 0 Then
            MessageBox.Show("You must fill out all boxes before proceeding")
        Else
            Dim cmdSQLExistsCheck = "SELECT Count(Medication_TUID) FROM PatientMedication Where Medication_TUID = " & intMedIDfromArray.ToString & " AND Patient_TUID = " & intPatientIDfromArray.ToString & " AND Active_Flag = 1"
            '
            If ExecuteScalarQuery(cmdSQLExistsCheck) <> 0 Then
                Result = MessageBox.Show("Medication is already assigned to patient, are you sure you wish to continue? ", "Duplicate Medication Detected", MessageBoxButtons.YesNo)
                If Result = DialogResult.No Then
                    Go = False
                End If


            End If
            '

            If Go Then
                Dim dtmOrderTime As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                PharmacyOrder.PharmacyOrder(intPatientIDfromArray, intMedIDfromArray, intPhysicianIDfromArray, txtQuantity.Text, txtUnit.Text, txtType.Text, cmbFrequencyNumber.SelectedItem.ToString)
                MessageBox.Show("Medication order placed")
                cmbPatientName.SelectedIndex = -1
                cmbMedication.SelectedIndex = -1
                cmbOrderedBy.SelectedIndex = -1
                cmbFrequencyNumber.SelectedIndex = -1
                txtQuantity.Text = Nothing
                txtUnit.Text = Nothing
            End If
        End If
    End Sub
    '/*********************************************************************/
    '/*      subFUNCTION NAME: cmbPatientName_SelectedIndexChanged        */         
    '/*********************************************************************/
    '/*                   WRITTEN BY: Alexander Beasecker		          */  
    '/*		         DATE CREATED: 		3/16/2020                         */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  dp   4/4/2020  initial creation                                                                   
    '/*********************************************************************/

    Private Sub cmbPatientName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatientName.SelectedIndexChanged
        If Not cmbPatientName.SelectedIndex = -1 Then
            intPatientIDfromArray = intPatientID(cmbPatientName.SelectedIndex)
            txtPatientDOB.Text = ExecuteScalarQuery("select Date_of_Birth from Patient where Patient_ID = '" & intPatientIDfromArray & "'")
        Else
            txtPatientDOB.Text = ""
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:txtQuantity_TextChanged         */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   03/11/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   						                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  03/11/21  Initial creation of the code      */
    '/*********************************************************************/
    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.KeyPress
        KeyPressCheck(e, "0123456789.")
    End Sub

    '/*********************************************************************/
    '/*                   SUBROUTINE NAME:       */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   03/11/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   						                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  03/11/21  Initial creation of the code      */
    '/*********************************************************************/
    Private Sub cmbMedication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedication.SelectedIndexChanged
        If Not cmbMedication.SelectedIndex = -1 Then
            cmbStrength.Items.Clear()
            intMedIDfromArray = intMedID(cmbMedication.SelectedIndex)
            Dim dsMedication As DataSet = ExecuteSelectQuery("select * from Medication where Medication_ID = '" & intMedIDfromArray & "'")
            txtType.Text = dsMedication.Tables(0).Rows(0)(EnumList.Medication.Snyonym)
            cmbStrength.Items.Add(dsMedication.Tables(0).Rows(0)(EnumList.Medication.type))
            cmbStrength.SelectedIndex = 0
        Else
            cmbStrength.SelectedIndex = -1
            txtType.Text = ""
        End If
    End Sub

    '/*********************************************************************/
    '/*           SUBROUTINE NAME: cmbOrderedBy_SelectedIndexChanged      */
    '/*********************************************************************/
    '/*                   WRITTEN BY:  	Alexander Beasecker			      */
    '/*		         DATE CREATED: 	   03/11/21							  */
    '/*********************************************************************/
    '/*  SUBROUTINE PURPOSE:
    '/*********************************************************************/
    '/*  CALLED BY:   	      									          
    '/*  (None)								           					  
    '/*********************************************************************/
    '/*  CALLS:														    	
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   						                           
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):	
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO                   WHEN     WHAT							  */
    '/*  ---                   ----     ----------------------------------*/
    '/*  Alexander Beasecker  03/11/21  Initial creation of the code      */
    '/*********************************************************************/
    Private Sub cmbOrderedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrderedBy.SelectedIndexChanged
        If Not cmbOrderedBy.SelectedIndex = -1 Then
            intPhysicianIDfromArray = intPhysicianID(cmbOrderedBy.SelectedIndex)
        End If
    End Sub
    '/*********************************************************************/
    '/*                subFUNCTION NAME:  cmbPatientName_LostFocus 	      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker         		  */   
    '/*		         DATE CREATED: 		                                  */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */   
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  dp  4/4/2020   initial creation                                                                
    '/*********************************************************************/

    Private Sub cmbPatientName_LostFocus(sender As Object, e As EventArgs) Handles cmbPatientName.LostFocus, cmbFrequencyNumber.LostFocus, cmbMedication.LostFocus, cmbOrderedBy.LostFocus, cmbStrength.LostFocus

        If sender.SelectedIndex = -1 Then
            sender.Text = ""
        End If
    End Sub
    '/*********************************************************************/
    '/*                   FUNCTION NAME: txtUnit_TextChanged 		      */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Alexander Beasecker                */   
    '/*		         DATE CREATED: 	4/2/2020	                          */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */             
    '/*											                          */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*                                         				          */         
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*             (NONE)								                  */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  RETURNS:								                          */                   
    '/*            (NOTHING)								              */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*											                          */                     
    '/*                                                                   */  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  dp   4/4/2020  initial creation                                                                 
    '/*********************************************************************/

    Private Sub txtUnit_TextChanged(sender As Object, e As EventArgs) Handles txtUnit.KeyPress
        KeyPressCheck(e, ".abcdefghijklmnopqrstuvwxyz /-")
    End Sub

End Class