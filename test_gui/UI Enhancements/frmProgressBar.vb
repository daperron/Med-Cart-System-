Imports System.Threading

Public Class frmProgressBar
    Dim myTask As Task


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myTask = New Task(New Action(Sub() UpdateLabel(Nothing)))
    End Sub

    '/*********************************************************************/
    '/* SubProgram NAME:        frmProgressBar_Load                       */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dillen Perron      		          */   
    '/*		         DATE CREATED: 		3/26/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								              */             
    '/*	 This sub will update the label on the form to give the form      */
    '/*  status updates on what is happening in the background            */
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
    '/*                                                                   */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  DP   3/26/21    Initial creation                                 */
    '/*                                                                   */
    '/*********************************************************************/
    Private Sub frmProgressBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
        'set the loading bar as the front most form 
        Me.TopMost = True
        'point that is the bottom right of frmMain, This will always appear based on the forms location on load
        Dim pt As New Point((frmMain.Width - Me.Width) + frmMain.DesktopLocation.X, (frmMain.Height - Me.Height) + frmMain.DesktopLocation.Y)
        Me.Location = pt

    End Sub
    '/*********************************************************************/
    '/* SubProgram NAME:        UpdateLabel                               */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Dillen Perron      		          */   
    '/*		         DATE CREATED: 		3/26/2021                         */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE: 								              */             
    '/*	 This sub will update the label on the form to give the form      */
    '/*  status updates on what is happening in the background            */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */           
    '/*  None                                                             */
    '/*********************************************************************/
    '/*  CALLS:										                      */                 
    '/*                                                                   */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */         
    '/*	 sender- object representing a control                            */
    '/*  e- eventargs indicating there is an event handle assigned        */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*  UpdateLabel(lbltext)                                             */     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 None                                                             */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */               
    '/*											                          */                     
    '/*  WHO   WHEN     WHAT								              */             
    '/*  ---   ----     ------------------------------------------------  */
    '/*  DP   3/26/21    Initial creation                                 */
    '/*                                                                   */
    '/*********************************************************************/
    'Method to update the label 
    Public Sub UpdateLabel(lbltext As String)

        Debug.WriteLine($"i am here {Now}: {lbltext}")
        If lblMessageUpdate.InvokeRequired Then
            lblMessageUpdate.Invoke(Sub() UpdateLabel(lbltext))
        Else
            Me.lblMessageUpdate.Text = lbltext
            Application.DoEvents()
        End If

    End Sub

    Public Sub StartTask()
        myTask.Start()
    End Sub

End Class
