Imports System.Data.SQLite
Imports System.Text
Imports System.Security.Cryptography

Module LogIn
    Public LoggedInID As String
    Public LoggedInPermission As String
    Public LoggedInUsername As String
    Public LoggedInFullName As String
    '/*******************************************************************/
    '/*                   FILE NAME:  LogIn.vb                          */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  Dylan Walter  		            */
    '/*		         DATE CREATED: January 31, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*											                        */
    '/* Check entered Loggin information with records in the database   */
    '/* change the variable concernering access level the user has.     */
    '/*                                                                 */
    '/*******************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
    '/*                                                    (NONE)	    */
    '/*******************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                */
    '/*                          (NOTHING)					            */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:								                */
    '/*											                        */
    '/* the program will invoke this module on a user logging into the  */
    '/* the system.                                                     */
    '/*******************************************************************/
    '/*  GLOBAL VARIABLE LIST (Alphabetically):			                */
    '/*  AccessLevel                                                    */
    '/*  UserName                                                       */
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
    '/*  WHO             WHEN        WHAT								*/
    '/*  Dylan Walter    1/31/2021   Initial creation                   */
    '/*	 Dylan Walter    2/3/2021	 Added ScanLogin and UsernameLogin  */
    '/*******************************************************************/
    Public Function ScanLogIn(ByVal strBarcode As String)

        'Dim sqlite_conn As SQLiteConnection
        'Dim sqlite_cmd As SQLiteCommand

        'open a file reader and read in the database location
        'Dim fileReader As String
        'fileReader = My.Computer.FileSystem.ReadAllText("config.app")


        ' create a new database connection:
        'sqlite_conn = New SQLiteConnection("Data Source=" & fileReader & ";")

        ' open the connection:
        'sqlite_conn.Open()

        'sqlite_cmd = sqlite_conn.CreateCommand()

        ' Convert the barcode to the peppered hash
        Dim strHashedBarcode = ConvertBarcodePepperAndHash(strBarcode)

        'Search the table for the barcode
        'sqlite_cmd.CommandText = "SELECT COUNT(*) FROM User WHERE Barcode = '" & strHashedBarcode & "'"
        'sqlite_cmd.ExecuteNonQuery()

        'If there is a user with that Barcode in the user database then log them in and continue to Form1
        'If sqlite_cmd.ExecuteScalar <> 0 Then
        If ExecuteScalarQuery("SELECT COUNT(*) FROM User WHERE Barcode = '" & strHashedBarcode & "'" & " AND Active_Flag = '1'") <> 0 Then
            LogIn.LoggedInUsername = (ExecuteScalarQuery("SELECT Username FROM User WHERE Barcode = '" & strHashedBarcode & "'"))
            LogIn.LoggedInFullName = (ExecuteScalarQuery("SELECT User_First_Name FROM User WHERE Barcode = '" & strHashedBarcode & "'") & " " &
                                    ExecuteScalarQuery("SELECT User_Last_Name FROM User WHERE Barcode = '" & strHashedBarcode & "'"))
            LogIn.LoggedInID = ExecuteScalarQuery("SELECT User_ID FROM User WHERE Barcode = '" & strHashedBarcode & "'")
            'check what Role the user will have
            If ExecuteScalarQuery("SELECT Admin_Flag FROM User WHERE Barcode = '" & strHashedBarcode & "'") = 1 Then
                LogIn.LoggedInPermission = "Admin"
            ElseIf ExecuteScalarQuery("SELECT Supervisor_Flag FROM User WHERE Barcode = '" & strHashedBarcode & "'") = 1 Then
                LogIn.LoggedInPermission = "Supervisor"
            Else LogIn.LoggedInPermission = "Nurse"
            End If
            Return "True"
        Else
            Return "False"
        End If
        'sqlite_conn.Close()
    End Function

    Public Function UsernameLogIn(ByVal strUsername As String, ByVal strPassword As String)
        ' hash the password and add the pepper
        strPassword = AddSaltPepperAndHash(strPassword, strUsername)

        'Dim sqlite_conn As SQLiteConnection
        'Dim sqlite_cmd As SQLiteCommand

        'open a file reader and read in the database location
        'Dim fileReader As String
        'fileReader = My.Computer.FileSystem.ReadAllText("config.app")


        ' create a new database connection:
        'sqlite_conn = New SQLiteConnection("Data Source=" & fileReader & ";")

        ' open the connection:
        'sqlite_conn.Open()

        'sqlite_cmd = sqlite_conn.CreateCommand()

        'Search the table for the Username and Password
        'sqlite_cmd.CommandText = "SELECT COUNT(*) FROM User WHERE Username = '" & strUsername & "'" & " AND Password = '" & strPassword & "'"
        'sqlite_cmd.ExecuteNonQuery()




        'If there is a user with that Barcode in the user database then log them in and continue to Form1
        If ExecuteScalarQuery("SELECT COUNT(*) FROM User WHERE Username = '" & strUsername & "'" & " AND Password = '" & strPassword & "'" & " AND Active_Flag = '1'") <> 0 Then
            LogIn.LoggedInID = ExecuteScalarQuery("SELECT User_ID FROM User WHERE Username = '" & strUsername & "'" & " AND Password = '" & strPassword & "'")
            LogIn.LoggedInUsername = (ExecuteScalarQuery("SELECT Username FROM User WHERE Username = '" & strUsername & "'" & " AND Password = '" & strPassword & "'"))
            LogIn.LoggedInFullName = (ExecuteScalarQuery("SELECT User_First_Name FROM User WHERE Username = '" & strUsername & "'") & " " &
                                    ExecuteScalarQuery("SELECT User_Last_Name FROM User WHERE Username = '" & strUsername & "'"))
            'check what Role the user will have
            If ExecuteScalarQuery("SELECT Admin_Flag FROM User WHERE Username = '" & strUsername & "'" & " AND Password = '" & strPassword & "'") = 1 Then
                LogIn.LoggedInPermission = "Admin"
            ElseIf ExecuteScalarQuery("SELECT Supervisor_Flag FROM User WHERE Username = '" & strUsername & "'" & " AND Password = '" & strPassword & "'") = 1 Then
                LogIn.LoggedInPermission = "Supervisor"
            Else LogIn.LoggedInPermission = "Nurse"
            End If
            Return "True"
        Else
            Return "False"
        End If
        'sqlite_conn.Close()
    End Function

    Public Function AddSaltPepperAndHash(ByVal strPassword As String, ByVal strUsername As String) As String
        '/*********************************************************************/
        '/*                   Function NAME: AddSaltPepperAndHash             */         
        '/*********************************************************************/
        '/*              WRITTEN BY:  Eric LaVoie                             */   
        '/*		         DATE CREATED: 		 2/16/2021                        */                             
        '/*********************************************************************/
        '/*  Function PURPOSE:								                  */             
        '/*	 This function is to get the salt and pepper added to a password  */
        '/*  input for login and return it to be verified against the database*/
        '/*********************************************************************/
        '/*  Function Return Value:					                          */         
        '/*	 A string of the salted, peppered, and hashed password            */
        '/*********************************************************************/
        '/*  CALLED BY:   	      						                      */    
        '/*  frmConfiguration.Button1_Click                                   */
        '/*********************************************************************/
        '/*  CALLS:										                      */                 
        '/* EncryptString                                                     */  
        '/*********************************************************************/
        '/*  PARAMETER LIST (In Parameter Order):					          */         
        '/*	strPassword - the password to be hashed                           */
        '/* strUsername - the username whose password needs the salt          */
        '/*********************************************************************/
        '/* SAMPLE INVOCATION:								                  */             
        '/*	AddSaltPepperAndHash("passW0rd12^")  							  */     
        '/*********************************************************************/
        '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
        '/*	strHashedSaltedPepperedPassword - the string to hold the salt     */
        '/*                                   and salted, peppered, hashed    */
        '/*                                   password                        */
        '/* strSalt - the salt string                                         */
        '/*********************************************************************/
        '/* MODIFICATION HISTORY:						                      */               
        '/*											                          */                     
        '/*  WHO   WHEN     WHAT								              */             
        '/*  ---   ----     ------------------------------------------------  */
        '/*  Eric LaVoie  2/16/2021    Initial creation                       */
        '/*********************************************************************/
        Dim strHashedSaltedPepperedPassword As String = Nothing
        Dim strSalt As String
        ' create a pepper for the hashing to add to the password
        Const STRPEPPER As String = "aBcEasyas123"
        ' add the pepper to the password
        strPassword = strPassword & STRPEPPER
        ' retrieve the salt from the database
        strSalt = ExecuteScalarQuery("SELECT Salt FROM USER WHERE Username = '" & strUsername & "'")
        ' add the salt to the password prepended
        strPassword = strSalt & strPassword
        ' get the hash of the byte array
        strHashedSaltedPepperedPassword = EncryptString(strPassword)
        ' return the hashed, saleted and peppered password
        Return strHashedSaltedPepperedPassword
    End Function

    Public Function MakeSaltPepperAndHash(ByVal strPassword As String) As String()
        '/*********************************************************************/
        '/*                   Function NAME: MakeSaltPepperAndHash            */         
        '/*********************************************************************/
        '/*              WRITTEN BY:  Eric LaVoie                             */   
        '/*		         DATE CREATED: 		 2/16/2021                        */                             
        '/*********************************************************************/
        '/*  Function PURPOSE:								                  */             
        '/*	 This function is to make the salt and add it and the pepper to a */
        '/*  password Input for a New user And to add it to the database. It  */
        '/*  returns an array of strings where O is the salted, peppered,     */
        '/*  hashed password And 1 Is the salt                                */
        '/*********************************************************************/
        '/*  Function Return Value:					                          */         
        '/*	 An array of string where:                                        */
        '/*  (0) Is the salted, peppered, hashed password                     */
        '/*  (1) Is the salt used
        '/*********************************************************************/
        '/*  CALLED BY:   	      						                      */    
        '/*  frmConfiguration.Button1_Click                                   */
        '/*********************************************************************/
        '/*  CALLS:										                      */                 
        '/* EncryptString                                                     */  
        '/*********************************************************************/
        '/*  PARAMETER LIST (In Parameter Order):					          */         
        '/*	strPassword - the password to be hashed                           */ 
        '/*********************************************************************/
        '/* SAMPLE INVOCATION:								                  */             
        '/*	MakeSaltPepperAndHash("passW0rd12^")  							  */     
        '/*********************************************************************/
        '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
        '/* generatorCharPosition - a Random object                           */
        '/* intCharPosition - the position in the STRSALTCHARS selected       */
        '/*	strHashedSaltedPepperedPassword(2) - the array to hold the salt   */
        '/*                                      and salted, peppered, hashed */
        '/*                                      password                     */
        '/* strSalt - the salt string                                         */
        '/* STRSALTCHARS - the constant of the string of characters used in   */
        '/*                the salts.                                         */
        '/* strUpdatedPassword - the password with the pepper appended        */
        '/*********************************************************************/
        '/* MODIFICATION HISTORY:						                      */               
        '/*											                          */                     
        '/*  WHO   WHEN     WHAT								              */             
        '/*  ---   ----     ------------------------------------------------  */
        '/*  Eric LaVoie  2/16/2021    Initial creation                       */
        '/*  NP   2/18/2021 I changed the random generation function for the  */
        '/*                 salt into its own module and made it generatic to */
        '/*                 be able to be used in other forms and modules.    */
        '/*********************************************************************/
        Const STRSALTCHARS As String = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim strHashedSaltedPepperedPassword(2) As String
        Dim strUpdatedPassword As String
        Dim strSalt As String = ""
        ' create a pepper for the hashing to add to the password
        Const STRPEPPER As String = "aBcEasyas123"

        ' add the pepper to the password
        strUpdatedPassword = strPassword & STRPEPPER
        ' generate a random salt
        strSalt = GenerateRandom.generateRandomAlphanumeric(7, STRSALTCHARS)

        ' For i = 0 To (7) Step 1
        '     Dim generatorCharPosition = New System.Random
        '     Dim intCharPosition = generatorCharPosition.Next(0, 61)
        '     Threading.Thread.Sleep(176 + generatorCharPosition.Next(5))
        '     strSalt += STRSALTCHARS.ToCharArray.ElementAt(intCharPosition)
        ' Next
        ' add the salt to the password prepended
        'strTemp = EncryptString(strUpdatedPassword)
        strUpdatedPassword = strSalt & strUpdatedPassword
        strHashedSaltedPepperedPassword(0) = EncryptString(strUpdatedPassword)
        ' save the salt to the return
        strHashedSaltedPepperedPassword(1) = strSalt.ToString
        ' return the hashed, saleted and peppered password
        Return strHashedSaltedPepperedPassword
    End Function

    Public Function ConvertBarcodePepperAndHash(ByVal strBarcode As String) As String
        ' This function is to add pepper a barcode input for login and return it to either be saved to the database or 1be verified against the database
        Dim strHashedPepperedBarcode As String = Nothing
        ' create a pepper for the hashing to add to the Barcode
        Const STRPEPPER1 As String = "ImGoingToThe"
        Const STRPEPPER2 As String = "SpiritInTheSky"
        ' add the pepper to the barcode
        strBarcode = STRPEPPER1 & strBarcode & STRPEPPER2
        ' get the hash of the byte array
        strHashedPepperedBarcode = EncryptString(strBarcode)
        ' return the hashed, peppered barcode
        Return strHashedPepperedBarcode
    End Function

    Private Function EncryptString(str As String) As String
        '/*********************************************************************/
        '/*                   Function NAME: EncryptString                    */         
        '/*********************************************************************/
        '/*              WRITTEN BY:  Eric LaVoie                             */   
        '/*		         DATE CREATED: 		 2/16/2021                        */                             
        '/*********************************************************************/
        '/*  Function PURPOSE:								                  */             
        '/*	 This function encrypts the string provided and returns the hashed*/
        '/*  value string                                                     */
        '/*********************************************************************/
        '/*  Function Return Value:					                          */         
        '/*	 The string of the hashed original string                         */
        '/*********************************************************************/
        '/*  CALLED BY:   	      						                      */    
        '/*  frmConfiguration.Button1_Click                                   */
        '/*  ScanLogIn                                                        */
        '/*  UsernameLogIn                                                    */
        '/*  AddSaltPepperAndHash                                             */
        '/*  MakeSaltPepperAndHash                                            */
        '/*********************************************************************/
        '/*  CALLS:										                      */                 
        '/* None                                                              */  
        '/*********************************************************************/
        '/*  PARAMETER LIST (In Parameter Order):					          */         
        '/*	str - the string to be hashed                                     */ 
        '/*********************************************************************/
        '/* SAMPLE INVOCATION:								                  */             
        '/*	EncryptedString("passW0rd12^")         							  */     
        '/*********************************************************************/
        '/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
        '/*	bytes - the bytearray of the ascii values of the string           */
        '/* hashed - the hashed bytearray of the string                       */
        '/*********************************************************************/
        '/* MODIFICATION HISTORY:						                      */               
        '/*											                          */                     
        '/*  WHO   WHEN     WHAT								              */             
        '/*  ---   ----     ------------------------------------------------  */
        '/*  Eric LaVoie  2/16/2021    Initial creation                       */
        '/*********************************************************************/
        Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(str)
        Dim hashed As Byte() = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes)
        Return Convert.ToBase64String(hashed)
    End Function

End Module
