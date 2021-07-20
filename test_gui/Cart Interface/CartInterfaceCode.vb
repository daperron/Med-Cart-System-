Imports System.IO.Ports
Imports System.ComponentModel
Imports System.Threading
Imports System.Text
Module CartInterfaceCode
    '/*********************************************************************/
    '/*                   FILE NAME: CartInterfaceCode                    */									  
    '/*********************************************************************/
    '/*                 PART OF PROJECT: MedServe         				   */				  
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo  		               */		  
    '/*		         DATE CREATED:	1/21/2021                   		   */						  
    '/*********************************************************************/
    '/*  PROJECT PURPOSE:								   */				  
    '/*	This is going to handle the interface actions the program has with */
    '/* the cart. When the program gets a drawer number it will conver the */
    '/* draw number into a string the cart is expecting, and then will send */
    '/* that information to the cart. 
    '/* 																	  
    '/*********************************************************************/
    '/*  FILE PURPOSE:									   */			  
    '/*	 this is going to contain the actual code for the interface.      */					  
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
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                    */	
    '/*  dicButtonDictionary - this is the dictionary of the buttons that are */
    '/*     on the simuated cart form (FullCart). This is to just make things*/
    '/*     easier to read and avoid duplicated code.                      */
    '/*  intDrawerCount - this is the number of drawers that is open. we  */
    '/*     will be using this to make sure that all the drawers are closed*/
    '/*     before the program is able to continue. 
    '/*	 blnSimulationModeValue as boolean - this is going to be a true or false   */ 
    '/*     statement that will tell us if we are simulating the cart.     */
    '/*     If we are simulating the cart then the code that works with the */
    '/*     cart will not compile.  */
    '/*  bytFinal - this is the byte array that the drawer number is going to */
    '/*     be added into and sent to the cart itself. Most of the array is   */
    '/*     is static and doesn't need to change. The only part that needs to */
    '/*     is the drawer number.                                             */
    '/*  comSerialPort1 - this is the port that is used to talk to the cart */
    '/*     It will be set up using the serialSetup function and then used  */
    '/*     to send information to the cart.                                */
    '/*  intLastDrawer - this is the drawer the user tried to open. It is  */
    '/*                  saved in case they try to reopen the drawer in sim */
    '/*                  mode.                                              */
    '/*********************************************************************/
    '/* COMPILATION NOTES(will include version notes including libraries):*/
    '/* 											   */					  
    '/* 																	  
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                       */				  
    '/*											                           */					  
    '/*  WHO   WHEN     WHAT								               */			  
    '/*  ---   ----     ------------------------------------------------- */
    '/* Nathan 2/2/2021 Changes the SimulationMode to be an actual veriable */
    '/*                 and not a compiler option.                          */
    '/* Nathan 2/2/2021 Imported the cartInferfaceProject into the main porject*/
    '/* Nathan 2/2/2021 renamed SimulationMode to blnSimualationMOde to follow*/
    '/*                 naming standards.                                   */
    '/* Np     2/4/2021Fixed bytFinal being used before it is assigned a value*/
    '/*                 Warning.                                            */
    '/* NP     2/12/2021 added defaultCartSettings to set up the default   */
    '/*                  settings for our cart so the software will always */
    '/*                  be able to work for our cart out of the box.      */
    '/* NP     3/24/2021 Moved some variables around to allow access from  */
    '/*                  Other methods.                                    */
    '/* NP     4/9/2021  Move the Drawer Sim window frmFullCart to it own  */
    '/*                  Thread when it is shown.                          */
    '/*********************************************************************/

    '26

    Private FrmCart = New frmFullCart()
    Dim SerialPort1 = FrmCart.serialSetup()
    Dim intDrawerCountValue As Integer
    Private bytFinal As Byte()
    Friend comSerialPort1
    Private strDrawerNumer As String
    Public thread As Thread
    Private intLastDrawer As Integer
    'TODO
    'set up a way to change the COM port. (by default it looks like it is COM1
    'default bit rate looks to be 115200
    Dim blnSimulationModeValue = True 'this is going to dictate if the cart is going to be simulated or not.





    Dim dicButtonDictionary As Dictionary(Of String, Control) = New Dictionary(Of String, Control)




    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: setSimulationMode			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	2/12/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								             */             
    '/*  This is going to set the simulation mode value                   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the value that we are setting the simulation mode*/
    '/'          variable to.                                             */
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                   */             
    '/*	 cartInterfaceCode.setSimulationMode(true)		    			   */                     
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

    Sub setSimulationMode(value As Boolean)
        blnSimulationMode = value
    End Sub

    '/*********************************************************************/
    '/*                   Property NAME:  blnSimulationMode 			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	2/12/2021                       	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is going to handle the setting as setting of blnSimulationModeValue*/                     
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
    '/*	blnSimulationMode = true										   */    
    '/* CartInterfaceCode.blnSimulationMode                                */
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 value - this is the value we are setting blnSimulationModeValue to*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/



    Public Property blnSimulationMode As Boolean 'this is going to dictate if the cart is going to be simulated or not.

        Get
            Return blnSimulationModeValue
        End Get
        Set(value As Boolean)
            blnSimulationModeValue = value
        End Set
    End Property



    Sub main()
        'ChangeSettings("115200", "COM4", True)
        OpenOneDrawer("1")



    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  reopenDrawer    			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 		3/24/2021                          */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is set up to recall the open drawer command in case there is*/
    '/*  an issue closing the drawer. In order for this fucntion to work  */
    '/*  a drawer must first be opened. If this function is called anywhere*/
    '/*  else it will cause an error. The try catch only exists to stop the*/
    '/*  program from blowing up if someone calls this method and isn't    */
    '/*  supposed to.                                                      */
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
    '/*	 reOpenDrawer()         										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Sub reopenDrawer()
        Try
            comSerialPort1.Write(bytFinal, 0, bytFinal.Length)
        Catch
            'if this fails it is likely in sim mode. 
            OpenOneDrawer(intLastDrawer - 1)
        End Try
    End Sub



    '/*********************************************************************/
    '/*                   SubProgram NAME: OpenOneDrawer    			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 		 1/21/2021                        */                             
    '/*********************************************************************/
    '/*  Subprogram PURPOSE:								   */             
    '/*	 This is going to handle taking the drawer number that the calling */
    '/* coding wants to open. It will then take the code, converts it to the */
    '/* string into what the cart is expecting. If the code is compiled in */
    '/* simulation it won't make the string and will pop up a window acting */
    '/* like the drawer has beem opened.                                    */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                        */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										                        */                 
    '/*             CartInterfaceCode.convertToHex					   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 Number - this is the sring of the drawer number that the calling */
    '/*     calling code wants to open. 
    '/*                                                                     
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	OpenOneDrawer("13")        										   */     
    '/* OpenOneDrawer("2")                                                 */
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 frmCart - this is the form that is going be be used to simulate the  */
    '/*     the cart. It will display what drawer is open and will give the */
    '/*     caller an option to close the drawer. 
    '/*  dicHexDictioanry - this is the dictionary that is going to hold the */
    '/*     hex converstion that are going to be sent to the cart.           */
    '/*     A dictionary was used because I could not figure out how to get  */
    '/*     visual basic to convert a string over to a hex correctly. So I just */
    '/*     made a dictionary that would do it. 
    '/*  blnIssue - this is going to let the rest of the program know */
    '/*     if there is an issue with the import and the subprogram needs to */
    '/*     be stopped. 
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*  NP    3/24/2021  Moved comport and the bytFinal to be global vars */
    '/*                   so they can be used in other methods. Also added */
    '/*                   another form on another thread to this method.   */
    '/*********************************************************************/

    Sub OpenOneDrawer(Number As String)
        If Number > 1 Then
            'the cart doesn't have a drawer 2 so if it is 2 or higher we add one
            Number += 1
        End If
        intLastDrawer = Number
        Dim blnissue = errorChecking(Number)
        comSerialPort1 = FrmCart.serialSetup()
        intDrawerCount = 0 'reset the drawer count just in case. 

        If blnSimulationMode Then
            'this will comiple and be ran if the code is compiled in simulation mode. 
            FrmCart.populateButtonDictionary(dicButtonDictionary)
            If Not blnissue Then
                '  FrmCart.LblDrawer.Text = "Drawer Number " + Number + " Is Open"
                '   FrmCart.ShowDialog()

                dicButtonDictionary.Item(Number).BackColor = Color.Red 'changes the color of the button to red
                'to make it looks like it is red. 

                threadAccessor = New Thread(AddressOf openSimModeWindow)
                threadAccessor.Start()
            End If
        Else

            If Not blnissue Then
                threadAccessor = New Thread(AddressOf OpenDrawerFormOpener)
                If Number > 1 Then
                    strDrawerNumer = (CInt(Number) - 1).ToString 'nurses see the cart as having 25 draw
                Else
                    strDrawerNumer = Number.ToString
                End If
                'but the cart doesn't have a drawer number 2 so we have to change how it is seen
                'in the gui. 
                FrmCart.gettingConnectionSettings() 'get the settings in the database for the cart
                intDrawerCount = 0 'reset the drawer count
                'this will compiple and run if the cart is not in simulation mode. 


                bytFinal = getSerialString(Number) 'this is going to get the string we need
                    'to send to the cart. 

                    Try
                    comSerialPort1.Open()
                    getDrawerArray()
                    comSerialPort1.Write(bytFinal, 0, bytFinal.Length)
                    intDrawerCount += 1
                    threadAccessor.Start()

                    Catch
                        MessageBox.Show("Selected comport does not exist. Please have your admin change the comport in Admin Settings")
                    End Try
                End If


            End If

    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: Nathan Premo     			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 4/9/2021                     		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 THis is going to handle opening the fullCart form in another thread*/
    '/*  so the main GUI can keep working.                                */
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


    Sub openSimModeWindow()
        Try
            FrmCart.showdialog()
        Catch
            'it is fails they didn't close the last window so I will just close it for them. 
            threadAccessor.Abort()
            If intLastDrawer > 1 Then
                OpenOneDrawer(intLastDrawer - 1)
            Else
                OpenOneDrawer(intLastDrawer)
            End If

        End Try
    End Sub



    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  OpenDrawerFormOpener    	   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		              */   
    '/*		         DATE CREATED: 	3/24/2021                       	  */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:	            							  */             
    '/*	 This form exist so that we can open up the Open Drawer form on   */
    '/*  a different thread than the  main application.                   */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 number - this is the drawer number that is being opened.          */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */             
    '/*	OpenDrawerFormOpener(25)										  */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*	 DrawerForm - this is the instance of frmOpenDrawer that we are   */
    '/*               going to be using.                                  */
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Sub OpenDrawerFormOpener()
        Dim DrawerForm = New frmOpenedDrawer
        DrawerForm.lblDrawerNumber.Text = "Drawer " & strDrawerNumer & " is open."

        DrawerForm.ShowDialog()
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  getDrawerArray    			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		               */   
    '/*		         DATE CREATED: 	3/29/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This Sub just sends a code to the cart to get the drawer array.  */
    '/*  For some reason when the cart loses power it has to be asked for */
    '/*  the drawer array before it will allow you to open a drawer. So   */
    '/*  I am just going to make a method and get the array every time    */
    '/*  so the drawers will always work. For some reason the cart needs  */
    '/*  both of them to work.                                            */
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
    '/*	 arrByte4 - this is the array of hex codes that is   */
    '/*                     is used to get the drawer array from the cart.*/ 
    '/*  arrByte3 - this is the other message that gets the array.        */ 
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/


    Sub getDrawerArray()
        Dim arrByte4 As Byte() = {&H35, &H34, &H32, &H36, &H36, &H37, &H32, &H2C, &H49, &H2C, &H39, &H2C, &H30, &H2C, &H32, &H36, &H2C, &H36, &H2C, &H35, &H2C, &H31, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H2C, &H32, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H2C, &H33, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H2C, &H34, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H2C, &H35, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H2C, &H36, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H2C, &H37, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H2C, &H38, &H2C, &H30, &H2C, &H30, &H2C, &H30, &H0}
        SerialPort1.Write(arrByte4, 0, arrByte4.Length)


        Dim arrByte3 As Byte() = {&H31, &H38, &H34, &H37, &H37, &H35, &H38, &H2C, &H53, &H2C, &H30, &H2C, &H31, &H30, &H30, &H30, &H0}
        SerialPort1.Write(arrByte4, 0, arrByte4.Length)
    End Sub


    '/*********************************************************************/
    '/*                   FUNCTION NAME: getSerialString 				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	2/1/2021    	   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:						                		   */             
    '/*	 This is going to get the string that needs to be sent to the cart */
    '/* it will populate the dictionary for the hex numbers and then it will*/
    '/* create the strings based on what the string number is.              */
    '/*                                                                  */
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
    '/* Np     2/4/2021Fixed bytFinal being used before it is assigned a value*/
    '/*                 Warning.                                            */
    '/*                                                                     
    '/*********************************************************************/


    Function getSerialString(number As String)
        Dim dicHexDictioanry = New Dictionary(Of String, System.Int32)
        populationDictionary(dicHexDictioanry)
        Dim bytFinal As Byte() = Nothing
        If number.Length > 1 Then
            If number.Substring(0, 1) = 1 Then 'this is going to be for when the drawer number is greater 
                'then 9
                'handles 10 through 19
                bytFinal = {&H32, &H30, &H35, &H39, &H36, &H32, &H35, &H2C, &H4F, &H2C, &H30, &H2C, &H31, dicHexDictioanry.Item(number.Substring(1)), &H0}
            ElseIf number.Substring(0, 1) = 2 Then
                'handles 20 through 29
                bytFinal = {&H32, &H30, &H35, &H39, &H36, &H32, &H35, &H2C, &H4F, &H2C, &H30, &H2C, &H32, dicHexDictioanry.Item(number.Substring(1)), &H0}
            End If
        Else
            'handles 1 through 9
            bytFinal = {&H32, &H30, &H35, &H39, &H36, &H32, &H35, &H2C, &H4F, &H2C, &H30, &H2C, dicHexDictioanry.Item(number), &H0}

        End If

        Return bytFinal
    End Function


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: populationDictionary			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 1/25/2021 		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This is going to populate the dictory that is used to store the  */
    '/*  hex value that Visual Basic is expecting when we are making the  */
    '/*  the bytes arrays that are being sent to the cart. It is only going */
    '/*  contain the numbers one through nine. As the rest are just repeated.*/
    '/*  It is going going to be skipping drawer 2 because we don't have a */
    '/*  drawer 2. 
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*            CartInterfaceCode.getSerialString()    				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		(dicHexDictioanry As Dictionary(Of String, System.Int32) -       */ 
    '/*         This is the dictionary that we are going to be populating */
    '/*         with the hex values
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*											   */                     
    '/*   populationDictionary(hexDictioanry)                                                                  
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


    Sub populationDictionary(ByRef dicHexDictioanry As Dictionary(Of String, System.Int32))
        With dicHexDictioanry
            .Clear() 'this is for the remote chance the dictionary
            'is already populated
            .Add("0", &H30)
            .Add("1", &H31)
            .Add("2", &H32)
            .Add("3", &H33)
            .Add("4", &H34)
            .Add("5", &H35)
            .Add("6", &H36)
            .Add("7", &H37)
            .Add("8", &H38)
            .Add("9", &H39)
        End With
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: ChangeSettings   			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		                */   
    '/*		         DATE CREATED: 	2/12/2021                       	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*  This is going to create the string for the SQL call to update the */                     
    '/*  cart settings in the database as well as call the method to update*/
    '/*  the record in the database. 
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
    Sub ChangeSettings(bitRate As String, comPort As String, simulationMode As Boolean)
        Dim strbSQL As New StringBuilder()
        strbSQL.Append("Update Settings set ")
        strbSQL.Append("Bit_rate =  '" & bitRate & "', " & "Comm_Port = '" & comPort & "', ")
        strbSQL.Append("Simulation_Mode_Flag ='" & Convert.ToInt32(simulationMode) & "' where Settings_ID = 0;")

        CreateDatabase.ExecuteInsertQuery(strbSQL.ToString)
    End Sub



    '/*********************************************************************/
    '/*                   FUNCTION NAME:  		errorChecking			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	1/28/2021                              */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								   */             
    '/*		This is going to handle the errr checking of the number being */
    '/* sent to the open drawer funcitons. It checks to make sure the number*/
    '/* is a number and is a between 1 and 26. 
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*         OpenOneDrawer and openMutiDrawer         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 Number - this is the sring of the drawer number that the calling */
    '/*     calling code wants to open. 										   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                             */                   
    '/*       blnIssue this will be true if there is an issue or it will  */
    '/*          return false if everything is fine.  
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:							                   	   */             
    '/*			errorChecking("12")					        			   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
    '/*  lnIssue - this is going to let the rest of the program know */
    '/*     if there is an issue with the import and the subprogram needs to */
    '/*     be stopped. 
    '/*  blnNaN - this is for the Not a Number Error. The name is taken */
    '/*     from JavaScript. If the SubProgram is sent something that doe not */
    '/*     convert to a number, both this and issue will be marked as true */
    '/*  blntoHigh - this is for when the number is higher then the */
    '/*     number of drawer we have. We only have 26 drawers. So if a number */
    '/*     higher than 26 is passed to the Subprogram both this and issue */
    '/*     will be marked as true.
    '/*  blntoLow - this is for when the number is lower than 1.    */
    '/*     We do not have negative drawers and our drawer count starts at 1. */
    '/*     So anything lower is going to cause this and issue to be marked */
    '/*     as true. 
    '/*                                                                                         
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Function errorChecking(number As String)
        Dim blnIssue = False
        Dim blntoHigh = False
        Dim blntoLow = False
        Dim blnNaN = False


        If Not IsNumeric(number) Then
            blnNaN = True
            blnIssue = True
        Else
            If Convert.ToInt32(number) > 26 Then
                blntoHigh = True
                blnIssue = True
            ElseIf Convert.ToInt32(number) < 1 Then
                blntoLow = True
                blnIssue = True
            End If
        End If


        'this is going to show an error message is there is an issue. 
        If blnIssue Then
            If blntoHigh Then
                MessageBox.Show(number & " is greater than the max number of drawers. There are only 26 drawers in this cart model")
            ElseIf blntoLow Then
                MessageBox.Show(number & " is not a vaild drawer number. A drawer number must be between 1 and 26")
            ElseIf blnNaN Then
                MessageBox.Show(number & " is not a vaild number.")

            End If
        End If

        Return blnIssue
    End Function



    '/*********************************************************************/
    '/*                   FUNCTION NAME:  	OpenMutliDrawer				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 		   */                             
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:		                						   */             
    '/*	 This is going to handle opening more than one drawer at a time.   */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 Drawers - this is going to be an array of strings that will be the*/
    '/*     drawer numbers that need to be opened.                         */
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

    '/*  blnIssue - this is going to let the rest of the program know       */
    '/*     if there is an issue with the import and the subprogram needs to */
    '/*     be stopped.                                                    */
    '/*  comSerialPort1 - this is the port that is used to talk to the cart */
    '/*     It will be set up using the serialSetup function and then used  */
    '/*     to send information to the cart.                                */
    '/*											   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						         */               
    '/*											   */                     
    '/*  WHO   WHEN     WHAT								   */             
    '/*  ---   ----     ------------------------------------------------- */
    '/*                                                                     
    '/*********************************************************************/

    Sub OpenMutliDrawer(Drawers() As String)

        Dim blnIssue As Boolean = False
        Dim comSerialPort1 = FrmCart.serialSetup()
        Dim bytFinal As Byte()

        intDrawerCount = 0 'reset the drawer count
        For Each item As String In Drawers
            If CInt(item) > 1 Then
                item = (CInt(item) + 1).ToString
            End If
            If errorChecking(item) Then
                'the cart doesn't have a drawer 2 so if it is 2 or higher we add one
                blnIssue = True
            End If
        Next
        If blnSimulationMode Then
            'this will comiple and be ran if the code is compiled in simulation mode. 
            FrmCart.populateButtonDictionary(dicButtonDictionary)
            If Not blnIssue Then
                '  FrmCart.LblDrawer.Text = "Drawer Number " + Number + " is Open"
                '   FrmCart.ShowDialog()
                For Each number As String In Drawers
                    dicButtonDictionary.Item(number).BackColor = Color.Red 'changes the color of the button to red
                    'to make it looks like it is red. 
                Next
                FrmCart.showdialog()
            End If
        Else
            If Not blnIssue Then
                FrmCart.gettingConnectionSettings() 'get the settings in the database for the cart
                comSerialPort1.open
                getDrawerArray()
                For Each item As String In Drawers
                    bytFinal = getSerialString(item) 'gets the byte your array
                    comSerialPort1.Write(bytFinal, 0, bytFinal.Length) 'sends the byte array
                    intDrawerCount += 1 'inceases the drawer count
                Next
                Do
                    'this is going to keep looping until the drawer count reached zero. 

                Loop While (intDrawerCount > 0)
                comSerialPort1.Close()
            End If
        End If
    End Sub

    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME:  minusDrawerCount 			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	2/2/2021                        	   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	    This is going to change the open drawer count to zero         */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*		(none)									   */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            (NOTHING)								   */             
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								   */             
    '/*		cartInterfaceCode.minusDrawerCount  						   */                     
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

    Public Sub minusDrawerCount()
        intDrawerCount = 0
    End Sub


    '/*********************************************************************/
    '/*                   SUBPROGRAM NAME: killFormThread				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 4/7/2021                 		   */                             
    '/*********************************************************************/
    '/*  SUBPROGRAM PURPOSE:								   */             
    '/*	 This sub checks to see if there is a thread in the threadaccessor*/
    '/*  if there is it checks to see if it is still running. If it is    */
    '/*  running then it kills this. This method made made in case the    */
    '/*  needs to be stopped from another form.                           */
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


    Public Sub killFormThread()
        If Not IsNothing(threadAccessor) Then
            If threadAccessor.IsAlive Then
                threadAccessor.Abort()
            End If
        End If
    End Sub

    '/*********************************************************************/
    '/*                   Property NAME:  intDrawerCount				   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	4/7/2021                        	   */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 This is to act as a getter and setter for the drawer count        */                     
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the value that will be assigned to the drawer count*/                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								         */                   
    '/*            intDrawerCountValue								   */             
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


    Public Property intDrawerCount As Integer
        Get
            Return intDrawerCountValue
        End Get
        Set(value As Integer)
            intDrawerCountValue = value
            If intDrawerCount = 0 Then
                killFormThread
            End If
        End Set
    End Property


    '/*********************************************************************/
    '/*                   Property NAME:  threadAccessor    			   */         
    '/*********************************************************************/
    '/*                   WRITTEN BY:  Nathan Premo   		         */   
    '/*		         DATE CREATED: 	4/8/2021                               */                             
    '/*********************************************************************/
    '/*  Property PURPOSE:								   */             
    '/*	 this is the getter and setter for the thread to make it easier to*/
    '/*  work with in other forms.                                        */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						         */           
    '/*                                         				   */         
    '/*********************************************************************/
    '/*  CALLS:										   */                 
    '/*             (NONE)								   */             
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					   */         
    '/*	 value - this is the thread that is being assigned to the thread  */                     
    '/*                                                                     
    '/*********************************************************************/
    '/*  RETURNS:								                           */                   
    '/*         thread                     								   */             
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

    Public Property threadAccessor() As Thread
        Get
            Return thread
        End Get
        Set(value As Thread)
            thread = value
        End Set
    End Property

End Module
