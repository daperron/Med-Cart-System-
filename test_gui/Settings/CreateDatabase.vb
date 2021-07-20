
'/********************************************************************	*/
'/*                   FILE NAME:  CreateDatabase.vb						*/
'/********************************************************************	*/
'/*					  PART OF PROJECT: 									*/
'/********************************************************************	*/
'/*                   WRITTEN BY:  Breanna Howey	  					*/
'/*					  DATE CREATED: January 23, 2021					*/
'/********************************************************************	*/
'/*  FILE PURPOSE:														*/
'/*																		*/
'/* This file serves as the driver for database initialization.  The	*/
'/* main program provide the stage for creating the database and the	*/
'/* tables. The main subroutine (main()) calls the necessary subroutines*/
'*/ and provides the user output as to whether the database was created.*/
'*/ The main method will check to see if the database was already created.
'*/ If it is, then none of the following subroutines will fire. If no,	*/
'*/ then the subroutines are called and will create the database.		*/
'/********************************************************************	*/
'/*  COMMAND LINE PARAMETER LIST (In Parameter Order):					*/
'/*                                                    (NONE)			*/
'/********************************************************************	*/
'/*  ENVIRONMENTAL RETURNS:												*/
'/*                          (NOTHING)									*/
'/********************************************************************	*/
'/* SAMPLE INVOCATION:													*/
'/*																		*/
'/* This program is launched from (1) the Windows Start Menu, (2)		*/
'/* clicking on the FILENAME.EXE program icon or (3) entering the path	*/
'/* and FILENAME.EXE name in the Run box on the Windows Start Menu.		*/
'/********************************************************************	*/
'/*  GLOBAL VARIABLE LIST (Alphabetically):								*/
'/*DBCmd - Stores the SQL commands for either creating the database or	*/
'/*			the database tables											*/
'/*DBConn - Stores the information to connect to the database, after creation
'/*strApplicationPath - Stores the path of the config.app file			*/
'/*strCONNECTION - Stores the string that contains the database name and the
'*/				   folder the database is stored in (database path)		*/
'/*strCreateTable-Stores the Sql needed to create the necessary database*/
'*/		           tables.												*/
'/*strDBNAME - Stores the database name									*/
'/*strDBPath - Stores the database path									*/
'/*strDEFAULTFOLDER -Stores the folder to save the newly created database
'*/				      and where to search for a database before creation*/
'/********************************************************************	*/
'/* COMPILATION NOTES:													*/
'/* 																	*/
'/* This project compiles normally under Microsoft Visual Basic .NET 4.7.2*/
'/* All one needs to do is open up the FILENAME project and compile.	*/
'/* No special compile options or optimizations were used.  No			*/
'/* unresolved warnings or errors exist under these compilation			*/
'/* conditions.															*/
'/********************************************************************	*/
'/* MODIFICATION HISTORY:												*/
'/*																		*/
'/*  WHO		WHEN		WHAT										*/
'/*  BRH        01/23/21   Initial creation of the code-------------	*/
'/*  BRH		01/27/21  Updated database path to save on computer		*/
'/*  BRH		02/06/21	Allowed for user to choose database file	*/
'/*							and database file name upon creation.		*/
'/*  NP			02/12/2021	added defaultCartSettings sub and set the   */
'/*							database to call it when the database is    */
'/*							being made.									*/
'/*	 BRH		02/13/2021	Added subroutines to allow for opening and	*/
'/*							saving file functionality to be used in other
'*/							modules.									*/

'/*	 BRH		04/05/21	Changed the default folder for the database	*/
'/*  BRH		04/06/21	Updated the create database file dialog to 	*/
'/*						default database files (.db)					*/
'/*	 BRH		04/08/21	Fixed the file path to remove an extra \	*/
'/********************************************************************	*/

'Imports the libraries necessary to connect and create SQLite databases
Imports System.Data.SQLite
Imports System.IO
Module CreateDatabase
	'The path where the database is desired to be stored. 
	Dim STRDEFAULTFOLDER As String = "C:\Users\Public\Documents\MedServe"
	Public strDBNAME As String = "Medication_Cart_System"
	Public strDBPath As String = strDEFAULTFOLDER & strDBNAME & ".db"
	Public DBConn As SQLiteConnection
	Public DBCmd As SQLiteCommand
    Public strCONNECTION As String
	Dim strCreateTable As String
	Public strApplicationPath As String = "C:\Users\Public\Documents\MedServe\config.app"
	Public dlgOpenFileDialog As New OpenFileDialog

	'/*********************************************************************/
	'/*                   SUBROUTINE NAME:     Main						*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*																	*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  (None)								           					*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  CreateDataBase()												*/	
	'/*  CreateDrawersTable()											*/
	'/*  CreateMedicationTable()										*/
	'/*  CreatePatientTable()											*/
	'/*  CreatePhysicianTable()											*/		
	'/*  CreateUserTable()												*/	
	'/*  CreatePatientUserTable()										*/		
	'/*  CreateRoomsTable()												*/
	'/*  CreatePatientRoomTable()										*/
	'/*  CreateAllergyTable()											*/
	'/*  CreatePatientAllergyTable()									*/
	'/*  CreateAllergyOverrideTable()									*/
	'/*  CreatePatientMedicationTable()									*/		
	'/*  CreateDrugInteractionsTable()									*/		
	'/*  CreateDrawerMedicationTable()									*/
	'/*  CreateWastesTable()											*/		
	'/*  CreateDispensingTable()										*/
	'/*  CreateDiscrepanciesTable()										*/	
	'/*  CreateAdHocOrderTable()										*/
	'/*  CreatePersonalPatientDrawerMedicationTable()					*/
	'/*	 CreateDrugInteractionsOverrideTable()							*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*   Main();														*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None).														*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO	WHEN		WHAT										*/
	'/*  ---   ----			--------------------------------------------*/
	'/*  BRH	01/23/21	Initial creation of the code				*/
	'/*  BRH	01/28/21	Add the CreateSettingsTable method			*/
	'/*  BRH	02/06/21	Allowed for user to choose database file	*/
	'/*							and database file name upon creation.	*/
	'/*	 BRH	02/13/21	Removed code to allow for more practical	*/
	'/*						programming practices.						*/
	'/*	 BRH	03/28/21	Added the Drug Interactions Override table	*/
	'/*	 BRH	04/13/21	Removed PatientPhysician table				*/
	'/*******************************************************************/

	Sub Main()

		'If the default directory doesn't exist, create it
		If My.Computer.FileSystem.DirectoryExists(STRDEFAULTFOLDER) = False Then
			My.Computer.FileSystem.CreateDirectory(STRDEFAULTFOLDER)
		End If

		CreateConfigAppFile()


		strCONNECTION = String.Format("Data Source = {0}", strDBPath)
		If Not System.IO.File.Exists(strDBPath) Then
			'Creates the database
			CreateDataBase()

			'Seperate routines to create the tables
			CreateDrawersTable()
			CreateMedicationTable()
			CreatePatientTable()
			CreatePhysicianTable()
			CreateUserTable()
			CreatePatientUserTable()
			CreateRoomsTable()
			CreatePatientRoomTable()
			CreateAllergyTable()
			CreatePatientAllergyTable()
			CreateAllergyOverrideTable()
			CreatePatientMedicationTable()
			CreateDrugInteractionsTable()
			CreateDrawerMedicationTable()
			CreateWastesTable()
			CreateDispensingTable()
			CreateDiscrepanciesTable()
			CreateAdHocOrderTable()
			CreatePersonalPatientDrawerMedicationTable()
			CreateSettingsTable()
			CreateDrugInteractionsOverrideTable()

			DBConn.Close()

			MessageBox.Show("All tables were created")
			defaultCartSettings() 'this is going to put the default settings for our cart in the database. 
			CreateDefaultUser()
		Else

		End If

	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      SetupOpenFileDialog		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to set up the necessary variable
	'/* for allowing other subroutines to use the open file dialog.		*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	OpenDatabaseFile()												*/
	'/*	ImportExportDatabase.ImportDatabase()							*/
	'/*	ImportExportDatabase.ImportDatabaseAsCopy()						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	SetupOpenFileDialog()											*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*	BRH	 04/05/21	Show the default path in the open file dialog	*/
	'/*******************************************************************/
	Public Sub SetupOpenFileDialog()

		'Initialize the dialog for opening a file
		dlgOpenFileDialog.InitialDirectory = strDEFAULTFOLDER
		dlgOpenFileDialog.Title = "Open File..."
		dlgOpenFileDialog.Multiselect = False
		dlgOpenFileDialog.Filter = "All Files|*.*"

	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      OpenDatabaseFile		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subrouting is to allow the user to open		*/
	'/* an existing database. When called, the subroutine will show the	*/
	'/* open dialog window and prompt the user to choose a file. The user*/
	'/* will then select a file and hit open. The file path will then by*/
	'/* stored in the config.app file for future use. If the user closes*/
	'/* out of the pop up window without specifying a file, the system	*/
	'/* will call a subroutine to create a default path.				*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	CreateConfigApp()												*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  CreateDefaultDBPath()											*/
	'/*	 SetUpOpenFileDialog()											*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	OpenDatabaseFile()												*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  dlgOpenFileDialog - Stores an instance of the OpenFileDialog	*/
	'/*							window									*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*					Initial code created by Alexander B.			*/
	'/*******************************************************************/
	Public Sub OpenDatabaseFile()

		SetupOpenFileDialog()

		'If the user selects a file and presses ok, the file path will be saved in config.app
		If dlgOpenFileDialog.ShowDialog() = DialogResult.OK Then
			strDBPath = dlgOpenFileDialog.FileName

			My.Computer.FileSystem.WriteAllText(strApplicationPath, strDBPath, True)
			Using reader As StreamReader = New StreamReader(strApplicationPath)
				strDBPath = reader.ReadLine
			End Using

			'If the user accidentally closes out, a default database will be made 
		Else
			'if the user clicks cancel or 'X' set a default path for the database into the config.app file
			CreateDefaultDBPath()
		End If
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      SaveDatabaseFile		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to allow the user to save		*/
	'/* the database with the desired name. When called, the subroutine */
	'/* will show the save dialog box and prompt the user to save the	*/
	'/* database. The user will then select where they want to save it 	*/
	'/* and type the name of the file. The user will then click save and*/
	'/* the file path will then by stored in the config.app file for	*/
	'/* future use. If the user closes out of the pop up window without */
	'/*	specifying a file, the system will call a subroutine to create a*/
	'/*	default path.													*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	CreateConfigApp()												*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  CreateDefaultDBPath()											*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	SaveDatabaseFile()												*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  dlgOpenFileDialog - Stores an instance of the OpenFileDialog	*/
	'/*							window									*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*					Initial code created by Alexander B.			*/
	'/*	BRH	 04/05/21	Show the default path in the open file dialog	*/
	'/*******************************************************************/
	Public Sub SaveDatabaseFile()
		'Initializes a dialog for saving files
		Dim dlgSaveFileDialog As New SaveFileDialog

		'Set up how the save dialog box will work
		dlgSaveFileDialog.InitialDirectory = STRDEFAULTFOLDER
		'Default the file type to database (db)
		dlgSaveFileDialog.Filter = "All files (*.*)|*.*| db files (*.db)|*.db"
		dlgSaveFileDialog.FilterIndex = 2
		dlgSaveFileDialog.RestoreDirectory = True

		'If the user selects a file path and types in a file name and hits ok,
		'the file's path will be stored in the config.app file
		If dlgSaveFileDialog.ShowDialog() = DialogResult.OK Then
			strDBPath = dlgSaveFileDialog.FileName
			My.Computer.FileSystem.WriteAllText(strApplicationPath, strDBPath, True)
		Else
			'if the user clicks cancel or 'X' set a default path for the database into the config.app file
			CreateDefaultDBPath()
		End If
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      CreateDefaultDBPath		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to create a default path to	*/ 
	'/* the database in case the user closes out of the Open or Save	*/ 
	'/* database options without specifying a database to open or save.	*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	OpenDatabaseFile()												*/
	'/*	CloseDatabaseFile()												*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	CreateDefaultDBPath()											*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*					Initial code created by Alexander B.			*/
	'/*	BRH	 04/05/21	Show the default path in the open file dialog	*/
	'/*******************************************************************/
	Public Sub CreateDefaultDBPath()
		dlgOpenFileDialog.InitialDirectory = strDEFAULTFOLDER
		'strDEFAULTFOLDER = Application.StartupPath
		strDBPath = strDEFAULTFOLDER & "\" & strDBNAME & ".db"
		My.Computer.FileSystem.WriteAllText(strApplicationPath, strDBPath, True)
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      CreateConfigAppFile		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to create and populate the	*/
	'/*	config.app file responsible for storing the database path.		*/
	'/* First, the routine checks if the file exists and the specified	*/
	'/* file path, if not, the file will be created and the user will be*/
	'/* be prompted to either open or create a new database (done through
	'/* other subroutines). If the file already exists, the routine will*/
	'/* read the fie path from the file and store it in the strDBpath	*/
	'/* variable.														*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	Main()												*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  CreateDefaultDBPath()											*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	CreateConfigAppFile()												*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  dlgFolderDialogeLocation - Stores an instance of the			*/
	'/*								FolderBrowserDialog	window			*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT												*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*					Initial code created by Alexander B.			*/
	'/*******************************************************************/
	Public Sub CreateConfigAppFile()
		'Create folder dialog object to prompt user to select a folder path
		Dim dlgFolderDialogeLocation As New FolderBrowserDialog

		'Set the default displayed path to the application path for better user experience
		dlgFolderDialogeLocation.SelectedPath = strDEFAULTFOLDER

		'check if the config file exists or not
		If Not System.IO.File.Exists(strApplicationPath) Then

			'if the file does not exist, create it, then dispose of the connection
			System.IO.File.Create(strApplicationPath).Dispose()

			'Show a message asking the user if they want to open an existing file or create a new one
			Dim dlgResult As DialogResult = MessageBox.Show("Would you like to open an existing file?" & vbCr & "If you would like to create a file, select No.",
														"Open file", MessageBoxButtons.YesNo)

			'If the user selects yes, they want to select an existing file
			If dlgResult = DialogResult.Yes Then
				OpenDatabaseFile()

			Else 'If the user didn't want to open a file, the user is prompted to choose a path to save the database
				'prompt user to select a database path after the config file is created

				'Set up how the save dialog box will work
				SaveDatabaseFile()
			End If

		Else
			'if the file already exists
			'use reader to read database path from the config.app file
			Using reader As StreamReader = New StreamReader(strApplicationPath)
				strDBPath = reader.ReadLine
			End Using
		End If
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:        CreateDataBase()		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to create the database. First,*/ 
	'/* the database file is created at the specified path. Next, the	*/
	'/* program lets the user know the database has been created		*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  Main()															*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (NONE)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDataBase()												*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*******************************************************************/
	Public Sub CreateDataBase()

		'Creates a database file through the SQLiteConnection
		SQLiteConnection.CreateFile(strDBPath)
		MessageBox.Show("Database Created")

	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:		CreateDrawersTable		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Drawers table. */
	'/*  SQL code is stored in the strCreateTable variables and is		*/  
	'/*  executed in the call for the ExecuteQuery() subroutine			*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDrawersTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*******************************************************************/
	Public Sub CreateDrawersTable()
		strCreateTable = "CREATE TABLE 'Drawers' (
		'Drawers_ID'	INTEGER NOT NULL UNIQUE,
		'Drawer_Node'	TEXT NOT NULL,
		'Drawer_Number'	INTEGER NOT NULL,
		'Size'	INTEGER NOT NULL,
		'Number_of_Dividers'	INTEGER NOT NULL,
		'Full_Flag'	INTEGER NOT NULL,
		'Active_Flag' INTEGER NOT NULL,
		PRIMARY KEY(" & "Drawers_ID" & " AUTOINCREMENT));"
		ExecuteQuery("Drawers")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:		CreateMedicationTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Medication		*/
	'/*  table. SQL code is stored in the strCreateTable variables and	*/  
	'/*  the is in the call for the ExecuteQuery() subroutine.			*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateMedicationTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*  BRH  02/04/21  Change Brand_name to Synonym field				*/
	'/*  BRH  02/08/21  Updated fields per Database meeting				*/
	'/*  BRH  02/11/21  Added a Schedule field							*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*******************************************************************/
	Public Sub CreateMedicationTable()
		strCreateTable = "CREATE TABLE 'Medication' (
							'Medication_ID'	INTEGER NOT NULL UNIQUE,
							'Drug_Name'	TEXT NOT NULL,
							'RXCUI_ID'	TEXT NOT NULL,
							'Controlled_Flag'	INTEGER NOT NULL,
							'NarcoticControlled_Flag'	INTEGER NOT NULL,
							'Barcode'	TEXT NOT NULL UNIQUE,
							'Type'	TEXT,
							'Strength'	TEXT,
							'Schedule'	TEXT,
							'Active_Flag' INTEGER NOT NULL,
							PRIMARY KEY(" & "Medication_ID" & " AUTOINCREMENT));"

		ExecuteQuery("Medication")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:		CreatePatientTable		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Patient table. */
	'/*  SQL code is stored in the strCreateTable variables and is		*/  
	'/*  executed in the call for the ExecuteQuery() subroutine			*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreatePatientTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  01/28/21  Updated fields in the database					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*  BRH  02/04/21  Added Barcode field								*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*******************************************************************/
	Public Sub CreatePatientTable()
		strCreateTable = "CREATE TABLE 'Patient' (
	                    'Patient_ID'	INTEGER NOT NULL UNIQUE,
	                    'MRN_Number'	INTEGER NOT NULL,
						'Barcode'	TEXT UNIQUE,
	                    'Patient_First_Name'	TEXT NOT NULL,
	                    'Patient_Middle_Name'	TEXT,
	                    'Patient_Last_Name'	TEXT NOT NULL,
	                    'Date_of_Birth'	TEXT NOT NULL,
	                    'Sex'	TEXT NOT NULL,
	                    'Height'	TEXT NOT NULL,
	                    'Weight'	TEXT NOT NULL,
	                    'Address'	TEXT NOT NULL,
						'City'	TEXT NOT NULL,
						'State'	TEXT NOT NULL,
						'Zip_Code'	TEXT NOT NULL,
	                    'Phone_Number'	TEXT NOT NULL,
	                    'Email_address'	TEXT,
	                    'Primary_Physician_ID'	INTEGER NOT NULL,
						'Active_Flag' INTEGER NOT NULL,
	                    FOREIGN KEY(" & "Primary_Physician_ID" & ") REFERENCES " & "Physician" & "(" & "Physician_ID" & "),
						PRIMARY KEY(" & "Patient_ID" & " AUTOINCREMENT));"

		ExecuteQuery("Patient")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:		CreatePhysicianTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Physician table*/
	'/*  SQL code is stored in the strCreateTable variables and is		*/  
	'/*  executed in the call for the ExecuteQuery() subroutine			*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreatePHysicianTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  01/28/21  Updated fields in the database					*/
	'/*******************************************************************/
	Public Sub CreatePhysicianTable()
		strCreateTable = "CREATE TABLE 'Physician' (
	                    'Physician_ID'	INTEGER NOT NULL UNIQUE,
	                    'Physician_First_Name'	TEXT NOT NULL,
	                    'Physician_Middle_Name'	TEXT,
	                    'Physician_Last_Name'	TEXT NOT NULL,
	                    'Physician_Credentials'	TEXT NOT NULL,
	                    'Physician_Phone_Number'	TEXT NOT NULL,
	                    'Physician_Fax_Number'	TEXT,
	                    'Physician_Address'	TEXT NOT NULL,
						'Physician_City'	TEXT NOT NULL,
						'Physician_State'	TEXT NOT NULL,
						'Physician_Zip_Code'	TEXT NOT NULL,
						'Active_Flag' INTEGER NOT NULL,
	                    PRIMARY KEY(" & "Physician_ID" & "));"

		ExecuteQuery("Physician")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateUserTable				*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the User			*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateUserTable()												*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*  BRH  02/04/21  Made barcode unique								*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*******************************************************************/
	Public Sub CreateUserTable()
		strCreateTable = "CREATE TABLE 'User' (
	                    'User_ID'	INTEGER NOT NULL,
						'Username'	TEXT NOT NULL UNIQUE,
						'Salt'	TEXT NOT NULL,
	                    'Password'	TEXT NOT NULL,
						'User_First_Name'	TEXT,
						'User_Last_Name'	TEXT,
	                    'Barcode'	TEXT NOT NULL UNIQUE,
	                    'Admin_Flag'	INTEGER,
	                    'Supervisor_Flag'	INTEGER,
						'Active_Flag' INTEGER NOT NULL,
						PRIMARY KEY(" & "User_ID" & " AUTOINCREMENT));"

		ExecuteQuery("User")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreatePatientUserTable		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the PatientUser	*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreatePatientUserTable()										*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*******************************************************************/
	Public Sub CreatePatientUserTable()
		strCreateTable = "CREATE TABLE 'PatientUser' (
	                    'Patient_TUID'	INTEGER NOT NULL,
	                    'User_TUID'	INTEGER NOT NULL,
	                    'Visit_Date'	TEXT NOT NULL,
						'Active_Flag' INTEGER NOT NULL,
	                    PRIMARY KEY(" & "Patient_TUID" & "," & "User_TUID" & "),
	                    FOREIGN KEY(" & "User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
	                    FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "));"

		ExecuteQuery("PatientUser")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateRoomsTable			*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Rooms			*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateRoomTable()												*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/09/21  Edited Room_ID data type						*/
	'/*******************************************************************/
	Public Sub CreateRoomsTable()
		strCreateTable = "CREATE TABLE 'Rooms' (
	                    'Room_ID'	TEXT NOT NULL,
	                    'Bed_Name'	TEXT NOT NULL,
	                    'Active_Flag'	INTEGER NOT NULL,
	                    PRIMARY KEY(" & "Room_ID" & "," & "Bed_Name" & "));"

		ExecuteQuery("Rooms")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreatePatientRoomTable		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the PatientRoom	*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreatePatientRoomTable()										*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/09/21  Change Room_TUID to match Rooms ID				*/
	'/*  BRH  02/09/21  Update foreign keys to fix insertion issue		*/
	'/*******************************************************************/
	Public Sub CreatePatientRoomTable()
		strCreateTable = "CREATE TABLE 'PatientRoom' (
	                    'Patient_TUID'	INTEGER NOT NULL,
	                    'Room_TUID'	TEXT NOT NULL,
	                    'Bed_Name'	TEXT NOT NULL,
	                    'Active_Flag'	INTEGER NOT NULL,
						PRIMARY KEY(" & "Patient_TUID" & "," & "Room_TUID" & "," & "Bed_Name" & "),                   
	                    FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "),
	                   FOREIGN KEY(" & "Room_TUID," & "Bed_Name" & ") REFERENCES " & "Rooms" & "(" & "Room_ID," & "Bed_Name" & "));"

		ExecuteQuery("PatientRoom")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateAllergyTable			*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Allergy		*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateAllergyTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for unique primary keys, removed medication
	'/*					tuid											*/
	'/*	 BRH  04/13/21	Added allergy id								*/
	'/*******************************************************************/
	Public Sub CreateAllergyTable()
		strCreateTable = "CREATE TABLE 'Allergy' (
						'Allergy_ID'	INTEGER NOT NULL UNIQUE,
	                    'Allergy_Name'	TEXT NOT NULL,
	                    'Allergy_Type'	TEXT NOT NULL,
	                    PRIMARY KEY(" & "Allergy_ID" & " AUTOINCREMENT));"

		ExecuteQuery("Allergy")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreatePatientAllergyTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the PatientAllergy	*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreatePatientAllergyTable()										*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*	 BRH  04/13/21	fixed foreign key to the allergy table			*/
	'/*******************************************************************/
	Public Sub CreatePatientAllergyTable()
		strCreateTable = "CREATE TABLE 'PatientAllergy' (
	                    'Patient_TUID'	INTEGER NOT NULL,
	                    'Allergy_TUID'	INTEGER NOT NULL,
	                    'Allergy_Severity'	TEXT,
	                    'Active_Flag'	INTEGER NOT NULL,
	                    PRIMARY KEY(" & "Patient_TUID" & "," & "Allergy_TUID" & "),
	                    FOREIGN KEY(" & "Allergy_TUID" & ") REFERENCES " & "Allergy" & "(" & "Allergy_ID" & "),
	                    FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "));"

		ExecuteQuery("PatientAllergy")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateAllergyOverrideTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the AllergyOverride*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateAllergyOVerrideTable()									*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*******************************************************************/
	Public Sub CreateAllergyOverrideTable()
		strCreateTable = "CREATE TABLE 'AllergyOverride' (
	                    'AllergyOverride_ID'	INTEGER NOT NULL UNIQUE,
	                    'Patient_TUID'	INTEGER NOT NULL,
	                    'User_TUID'	INTEGER NOT NULL,
	                    'Allergy_Name'	TEXT NOT NULL,
	                    'DateTime'	TEXT NOT NULL,
	                    FOREIGN KEY(" & "User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
	                    FOREIGN KEY(" & "Allergy_Name" & ") REFERENCES " & "Allergy" & "(" & "Allergy_Name" & "),
	                    FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "),
						PRIMARY KEY(" & "AllergyOverride_ID" & " AUTOINCREMENT));"

		ExecuteQuery("AllergyOverride")
	End Sub

	'/*******************************************************************/
	'/*                SUBROUTINE NAME:	 CreatePatientMedicationTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the PatientMedication*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreatePatientMedicationTable()									*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*  BRH  02/09/21  Added Frequency and Notes fields				*/
	'/*  BRH  02/16/21  Changed Method to Type							*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*	 BRH  04/01/21	Added 'unit' field and changed quantity data type/
	'/*******************************************************************/
	Public Sub CreatePatientMedicationTable()
		strCreateTable = "CREATE TABLE 'PatientMedication' (
	                    'PatientMedication_ID'	INTEGER NOT NULL UNIQUE,
	                    'Patient_TUID'	INTEGER NOT NULL,
	                    'Medication_TUID'	INTEGER NOT NULL,
	                    'Ordering_Physician_ID'	INTEGER NOT NULL,
	                    'Date_Presrcibed'	TEXT NOT NULL,
	                    'Quantity'	NUMERIC NOT NULL,
	                    'Units'	TEXT,
						'Type'	TEXT NOT NULL,
	                    'Frequency'	TEXT NOT NULL,
						'Notes'		TEXT,
						'Active_Flag'	INTEGER NOT NULL,
	                    FOREIGN KEY(" & "Medication_TUID" & ") REFERENCES " & "Medication" & "(" & "Medication_ID" & "),
	                    FOREIGN KEY(" & "Ordering_Physician_ID" & ") REFERENCES " & "Physician" & "(" & "Physician_ID" & "),
	                    FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "),
						PRIMARY KEY(" & "PatientMedication_ID" & " AUTOINCREMENT));"

		ExecuteQuery("PatientMedication")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateDrugInteractionsTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the DrugInteractions*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDrugInteractionsTable()									*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*  BRH  02/04/21  Removed third medication id						*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*	 BRH  03/30/21	Fixed Medication One and Two foreign key reference
	'/*******************************************************************/
	Public Sub CreateDrugInteractionsTable()
		strCreateTable = "CREATE TABLE 'Drug_Interactions' (
	                    'Drug_Interactions_ID'	INTEGER NOT NULL UNIQUE,
	                    'Medication_One_ID'	TEXT NOT NULL,
	                    'Medication_Two_ID'	TEXT NOT NULL,
	                    'Severity'	TEXT,
	                    'Description'	TEXT,
						'Active_Flag' INTEGER NOT NULL,
	                    FOREIGN KEY(" & "Medication_One_ID" & ") REFERENCES " & "Medication" & "(" & "RXCUI_ID" & "),
						PRIMARY KEY(" & "Drug_Interactions_ID" & " AUTOINCREMENT));"

		ExecuteQuery("DrugInteractions")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateDrawerMedicationTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the DrawerMedication*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDrawerMedicationTable()									*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*	 BRH  03/28/21	Added proper primary key code, added amount per	*/
	'/*					container and container unit, and updated quanity
	'/*					data field to numeric							*/
	'/*******************************************************************/
	Public Sub CreateDrawerMedicationTable()
		strCreateTable = "CREATE TABLE 'DrawerMedication' (
	                'DrawerMedication_ID'	INTEGER NOT NULL UNIQUE,
	                'Drawers_TUID'	INTEGER NOT NULL,
	                'Medication_TUID'	INTEGER NOT NULL,
	                'Quantity'	NUMERIC NOT NULL,
					'Amount_Per_Container' INTEGER,
					'Amount_Per_Container_Unit'	TEXT,
	                'Divider_Bin'	INTEGER,
	                'Expiration_Date'	TEXT NOT NULL,
	                'Discrepancy_Flag'	INTEGER NOT NULL,
					'Active_Flag'	INTEGER NOT NULL,
					PRIMARY KEY(" & "DrawerMedication_ID" & " AUTOINCREMENT),
	                FOREIGN KEY(" & "Medication_TUID" & ") REFERENCES " & "Medication" & "(" & "Medication_ID" & "),
	                FOREIGN KEY(" & "Drawers_TUID" & ") REFERENCES " & "Drawers" & "(" & "Drawers_ID" & "));"

		ExecuteQuery("DrawerMedication")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateWastesTable			*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Wastes			*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateWastesTable()												*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*	 BRH  03/19/21	Added the "Quantity" field						*/
	'/*	 BRH  03/19/21	Added the "Medication_TUID" field				*/
	'/*	 BRH  03/28/21	Added proper primary key code, changed quantity	*/
	'/*					data type to allow decimals (to numeric)		*/
	'/*******************************************************************/
	Public Sub CreateWastesTable()
		strCreateTable = "CREATE TABLE 'Wastes' (
	                    'Wastes_ID'	INTEGER NOT NULL UNIQUE,
	                    'Primary_User_TUID'	INTEGER NOT NULL,
	                    'Secondary_User_TUID'	INTEGER NOT NULL,
	                    'DrawerMedication_TUID'	INTEGER,
						'Medication_TUID'	INTEGER,
						'Patient_TUID'	INTEGER,
	                    'DateTime'	TEXT NOT NULL,
						'Reason' TEXT,
						'Quantity' NUMERIC,
						PRIMARY KEY(" & "Wastes_ID" & " AUTOINCREMENT),
	                    FOREIGN KEY(" & "Primary_User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
	                    FOREIGN KEY(" & "Secondary_User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
						FOREIGN KEY(" & "Medication_TUID" & ") REFERENCES " & "Medication" & "(" & "Medication_ID" & "),
	                    FOREIGN KEY(" & "DrawerMedication_TUID" & ") REFERENCES " & "DrawerMedication" & "(" & "DrawerMedication_ID" & "),
						FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "));"

		ExecuteQuery("Wastes")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateDispensingTable		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Dispensing		*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDispensingTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*******************************************************************/
	Public Sub CreateDispensingTable()
		strCreateTable = "CREATE TABLE 'Dispensing' (
						'Dispensing_ID'	INTEGER NOT NULL UNIQUE,
						'PatientMedication_TUID'	INTEGER NOT NULL,
						'Primary_User_TUID'	INTEGER NOT NULL,
						'Approving_User_TUID'	INTEGER,
						'DateTime_Dispensed'	TEXT NOT NULL,
						'Amount_Dispensed'	TEXT NOT NULL,
						'DrawerMedication_TUID'	INTEGER NOT NULL,
						FOREIGN KEY(" & "Approving_User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
						FOREIGN KEY(" & "DrawerMedication_TUID" & ") REFERENCES " & "DrawerMedication" & "(" & "DrawerMedication_ID" & "),
						FOREIGN KEY(" & "PatientMedication_TUID" & ") REFERENCES " & "PatientMedication" & "(" & "PatientMedication_ID" & "),
						FOREIGN KEY(" & "Primary_User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
						PRIMARY KEY(" & "Dispensing_ID" & " AUTOINCREMENT));"

		ExecuteQuery("Dispensing")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateDiscrepanciesTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Discrepancies	*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDiscrepanciesTable()										*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*  BRH  02/23/21  Added a Reason field							*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*	 BRH  03/30/21	Changed Expected and Actual Count data types	*/
	'/*******************************************************************/
	Public Sub CreateDiscrepanciesTable()
		strCreateTable = "CREATE TABLE 'Discrepancies' (
						'Discrepancies_ID'	INTEGER NOT NULL UNIQUE,
						'Drawer_TUID'	INTEGER NOT NULL,
						'Medication_TUID'	INTEGER NOT NULL,
						'Expected_Count'	TEXT NOT NULL,
						'Actual_Count'	TEXT,
						'Primary_User_TUID'	INTEGER NOT NULL,
						'Approving_User_TUID'	INTEGER NOT NULL,
						'DateTime_Entered'	TEXT NOT NULL,
						'DateTime_Cleared'	TEXT,
						'Reason'	TEXT NOT NULL,
						FOREIGN KEY(" & "Primary_User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
						FOREIGN KEY(" & "Drawer_TUID" & ") REFERENCES " & "Drawers" & "(" & "Drawers_ID" & "),
						FOREIGN KEY(" & "Medication_TUID" & ") REFERENCES " & "Medication" & "(" & "Medication_ID" & "),
						FOREIGN KEY(" & "Approving_User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "),
						PRIMARY KEY(" & "Discrepancies_ID" & " AUTOINCREMENT));"

		ExecuteQuery("Discrepancies")
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:	CreateAdHocOrderTable		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the AdHocOrder		*/
	'/*  table. SQL code is stored in the strCreateTable variables and 	*/  
	'/*  is executed in the call for the ExecuteQuery() subroutine		*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateAdHocOrderTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*	 BRH  04/13/21	Added Physician_TUID							*/
	'/*******************************************************************/
	Public Sub CreateAdHocOrderTable()
		strCreateTable = "CREATE TABLE 'AdHocOrder' (
						'AdHocOrder_ID'	INTEGER NOT NULL,
						'Medication_TUID'	INTEGER NOT NULL,
						'Patient_TUID'	INTEGER NOT NULL,
						'User_TUID'	INTEGER NOT NULL,
						'Amount'	TEXT NOT NULL,
						'DrawerMedication_TUID'	INTEGER NOT NULL,
						'DateTime'	TEXT NOT NULL,
						'Physician_TUID'	INTEGER,
						PRIMARY KEY(" & "AdHocOrder_ID" & " AUTOINCREMENT),
						FOREIGN KEY(" & "Physician_TUID" & ") REFERENCES " & "Physician" & "(" & "Physician_ID" & "),
						FOREIGN KEY(" & "DrawerMedication_TUID" & ") REFERENCES " & "DrawerMedication" & "(" & "DrawerMedication_ID" & "),
						FOREIGN KEY(" & "Medication_TUID" & ") REFERENCES " & "Medication" & "(" & "Medication_ID" & "),
						FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "),
						FOREIGN KEY(" & "User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "));"

		ExecuteQuery("AdHocOrder")
	End Sub

	'/*******************************************************************/
	'/*    SUBROUTINE NAME:	CreatePersonalPatientDrawerMedicationTable	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to create the					*/
	'/*	PersonalPatientDrawerMedication table. SQL code is stored in the*/  
	'/* strCreateTable variables and is executed in the call for the	*/ 
	'/*	ExecuteQuery() subroutine										*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreatePersonalPatientDrawerMedicationTable()					*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*******************************************************************/
	Public Sub CreatePersonalPatientDrawerMedicationTable()
		strCreateTable = "CREATE TABLE 'Personal_Patient_DrawerMedication' (
						'PersonalMedication_ID'	INTEGER NOT NULL UNIQUE,
						'Patient_TUID'	INTEGER NOT NULL,
						'DrawerMedication_TUID'	INTEGER NOT NULL,
						'Removed_Dispensing'	INTEGER,
						'Active_Flag'	INTEGER NOT NULL,
						PRIMARY KEY(" & "PersonalMedication_ID" & " AUTOINCREMENT),
						FOREIGN KEY(" & "DrawerMedication_TUID" & ") REFERENCES " & "DrawerMedication" & "(" & "DrawerMedication_ID" & "),
						FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "));"

		ExecuteQuery("Personal_Patient_DrawerMedication")
	End Sub

	'/*******************************************************************/
	'/*    SUBROUTINE NAME:			CreateSettingsTable					*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/28/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to create the					*/
	'/*	Settings table. SQL code is stored in the						*/  
	'/* strCreateTable variables and is executed in the call for the	*/ 
	'/*	ExecuteQuery() subroutine										*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateSettingsTable()											*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*  BRH  01/28/21  Update fields in database						*/
	'/*  BRH  02/01/21  Updated for autoincrementing primary keys		*/
	'/*	 BRH  03/28/21	Added proper primary key code					*/
	'/*******************************************************************/
	Public Sub CreateSettingsTable()
		strCreateTable = "CREATE TABLE 'Settings' (
						'Settings_ID'	INTEGER NOT NULL UNIQUE,
						'Bit_rate'	TEXT NOT NULL,
						'Comm_Port'	TEXT NOT NULL,
						'Simulation_Mode_Flag'	INTEGER,
						PRIMARY KEY(" & "Settings_ID" & " AUTOINCREMENT));"

		ExecuteQuery("Settings")
	End Sub

	'/*******************************************************************/
	'/*   SUBROUTINE NAME:		CreateDrugInteractionsOverrideTable		*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   03/28/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create the Drugs Interactions 
	'/*  Override table. SQL code is stored in the strCreateTable		*/
	'/*	 variables and is executed in the call for the ExecuteQuery()	*/ 
	'/*	 subroutine														*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteQuery()													*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDrugInteractionsOverrideTable()							*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  03/28/21  Initial creation of the code					*/
	'/*******************************************************************/
	Public Sub CreateDrugInteractionsOverrideTable()
		strCreateTable = "CREATE TABLE 'Drug_InteractionsOverride' (
						'Drug_Interaction_Override_TUID'	INTEGER NOT NULL UNIQUE,
						'Patient_TUID'	INTEGER NOT NULL,
						'User_TUID'	INTEGER NOT NULL,
						'Drug_Interactions_TUID'	INTEGER NOT NULL,
						'DateTime'	TEXT NOT NULL,
						PRIMARY KEY(" & "Drug_Interaction_Override_TUID" & " AUTOINCREMENT),
						FOREIGN KEY(" & "Drug_Interactions_TUID" & ") REFERENCES " & "Drug_Interactions" & "(" & "Drug_Interactions_ID" & "),
						FOREIGN KEY(" & "Patient_TUID" & ") REFERENCES " & "Patient" & "(" & "Patient_ID" & "),	
						FOREIGN KEY(" & "User_TUID" & ") REFERENCES " & "User" & "(" & "User_ID" & "));"

		ExecuteQuery("Drawers")
	End Sub


	'/*********************************************************************/
	'/*                   SUBPROGRAM NAME: defaultCartSettings    		   */         
	'/*********************************************************************/
	'/*                   WRITTEN BY:  Nathan Premo   		                 */   
	'/*		         DATE CREATED: 	2/12/2021                       	   */                             
	'/*********************************************************************/
	'/*  SUBPROGRAM PURPOSE:		            						   */             
	'/*	 This is going to make the SQL call that will set the default settings*/
	'/*  for our cart in the database. This is so everytime a new database*/
	'/*  is made it will work with our cart out of the box.               */
	'/*                                                                   */
	'/*********************************************************************/
	'/*  CALLED BY:   	      						         */           
	'/*  createDatabase.main()                            				   */         
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
	'/* SAMPLE INVOCATION:								                 */             
	'/*	defaultCartSettings()						      */                     
	'/*********************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
	'/*	 strDefaultSettings - this is the string that has our SQL call	   */                     
	'/*                                                                     
	'/*********************************************************************/
	'/* MODIFICATION HISTORY:						         */               
	'/*											   */                     
	'/*  WHO   WHEN     WHAT								   */             
	'/*  ---   ----     ------------------------------------------------- */
	'/*  NP    3/30/2021 Made the default settings to be com1 and the sim */
	'/*					 to be off.										  */
	'/*********************************************************************/

	Sub defaultCartSettings()
		Dim strDefaultSettings As String = "INSERT INTO Settings('Settings_ID', 'Bit_rate', 'Comm_Port', 'Simulation_Mode_Flag') VALUES (0, '115200', 'COM1', 0);"

		ExecuteInsertQuery(strDefaultSettings)
	End Sub

	'/*******************************************************************/
	'/*				SUBROUTINE NAME:		CreateDefaultUser			*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   03/28/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to create a default user when*/
	'/*  creating a blank database. This allows the user to import new	*/
	'/*	 data into the system when creating a blank database.			*/
	'/*******************************************************************/
	'/*  CALLED BY:   													*/
	'/*   Main()						          						*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  ExecuteInsertQuery()											*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* CreateDefaultUser()												*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  strSQLCmd - Stores the SQL statement for manipulating the database
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  04/08/21  Initial creation of the code					*/
	'/*******************************************************************/
	Sub CreateDefaultUser()
		Dim strSQLCmd As String

		'Inserts a default user into the database so the user can begin entering in the appropriate
		'data. This inserts the already salted and hashed values for easier input and faster performance
		'when loading.
		strSQLCmd = "INSERT INTO User('User_ID', 'Username', 'Salt', 'Password', 'User_First_Name', 
					'User_Last_Name', 'Barcode', 'Admin_Flag', 'Supervisor_Flag', 'Active_Flag') 
					VALUES (1, 'MedServeAdmin', 'oYqaK6pa', 'NIbDUOTNj3mrJiI1n/m6PfySImw2mxOCKQlZFkboY0Q=', 
					'MedServe', 'Admin', 'zfa1PP7+DaLGpQeSfnvs+65sVL43djxQQoffdbcEhLo=', 1, 0, 1);"

		ExecuteInsertQuery(strSQLCmd)
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:         ExecuteQuery			*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*		         DATE CREATED: 	   01/23/21							*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	 The purpose of this subroutine is to execute the specified SQL	*/ 	
	'/* code used in each subroutine that invokes this subroutine. The	*/  
	'/* routine instantiates a connection string and database SQL		*/
	'/* command, opens the database, and trys to execute the query. If	*/
	'/* it is successful, the tables are created. If it isn't, the		*/
	'/* program tells the user the table couldn't be created. The		*/
	'/*	database is the closed.											*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*  CreateDataBase()												*/
	'/*  CreateDrawersTable()											*/
	'/*  CreateMedicationTable()										*/
	'/*  CreatePatientTable()											*/
	'/*  CreatePhysicianTable()											*/
	'/*  CreatePatientPhysicianTable()									*/
	'/*  CreateUserTable()												*/
	'/*  CreatePatientUserTable()										*/
	'/*  CreateRoomsTable()												*/
	'/*  CreatePatientRoomTable()										*/
	'/*  CreateAllergyTable()											*/
	'/*  CreatePatientAllergyTable()									*/
	'/*  CreateAllergyOverrideTable()									*/
	'/*  CreateDrugInteractionsTable()									*/
	'/*  CreateDrawerMedicationTable()									*/
	'/*  CreateWastesTable()											*/
	'/*  CreateDispensingTable()										*/
	'/*  CreateDiscrepanciesTable()										*/
	'/*  CreateAdHocOrderTable()										*/
	'/*  CreatePatientMedicationPrescriptionTable()						*/
	'/*  CreatePersonalPatientDrawerMedicationTable()					*/
	'/*  CreateSettingsTable()											*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  strTableName - Stores the name of the table that is being created */
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/* ExecuteQuery()													*/	
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/*  WHO   WHEN     WHAT											*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*  BRH  01/23/21  Initial creation of the code					*/
	'/*******************************************************************/
	Public Sub ExecuteQuery(strTableName As String)
		DBConn = New SQLiteConnection(strCONNECTION)
		DBCmd = New SQLiteCommand(strCreateTable, DBConn)
		DBConn.Open()
		Try
			DBCmd.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show("Could not create " & strTableName & " table")
		End Try
		DBConn.Close()
	End Sub

	'/*********************************************************************/
	'/*                   FUNCTION NAME:  	ExecuteSelectQuery   		   */         
	'/*********************************************************************/
	'/*                   WRITTEN BY:  Nathan Premo   						*/   
	'/*		         DATE CREATED: 		2/2/2021						  */                             
	'/*********************************************************************/
	'/*  FUNCTION PURPOSE:								   */             
	'/*	 this is going to handle select requests from the database. It will*/
	'/*  set up and send the SQL request to the database and return the    */
	'/*  values as a dataset. If there is an issue, it will display the    */
	'/*  query that had the issue as well as the issue being reported.     */
	'/*********************************************************************/
	'/*  CALLED BY:   	      						         */           
	'/*                                         				   */         
	'/*********************************************************************/
	'/*  CALLS:										   */                 
	'/*             (NONE)								   */             
	'/*********************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):					   */         
	'/*	 strStatement - this is the SQL query that the user is looking to */ 
	'/*					excute.											  */             
	'/*                                                                     
	'/*********************************************************************/
	'/*  RETURNS:														 */                   
	'/*  dsValues														  */
	'/*********************************************************************/
	'/* SAMPLE INVOCATION:												 */             
	'/*	 Databasecreation.ExecuteSelectQuery("SELECT * from user;")		 */                     
	'/*                                                                     
	'/*********************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
	'/*  dsValues	- this is going to be the dataset that is returned    */
	'/*					from the database.								  */
	'/*                                                                     
	'/*********************************************************************/
	'/* MODIFICATION HISTORY:						         */               
	'/*											   */                     
	'/*  WHO   WHEN     WHAT								   */             
	'/*  ---   ----     ------------------------------------------------- */
	'/*                                                                     
	'/*********************************************************************/


	Public Function ExecuteSelectQuery(strStatement As String)
		Dim dsValues As DataSet = New DataSet
		Dim DBAdaptor As SQLiteDataAdapter

		DBConn = New SQLiteConnection(strCONNECTION)
		DBCmd = New SQLiteCommand(strStatement, DBConn)
		'DBConn.Open()
		Try
			DBAdaptor = New SQLiteDataAdapter(strStatement, DBConn)
			DBAdaptor.Fill(dsValues, "Table")
		Catch ex As Exception
			MessageBox.Show("could not complete the following SQL statement: " & strStatement &
							" the following error occured: " & vbCrLf & vbCrLf & ex.ToString)

		End Try
		Return dsValues
	End Function

	'/*********************************************************************/
	'/*                   SUBPROGRAM NAME:  ExecuteInsertQuery			   */         
	'/*********************************************************************/
	'/*                   WRITTEN BY:  Nathan Premo   						 */   
	'/*		         DATE CREATED: 	2/2/2021							   */                             
	'/*********************************************************************/
	'/*  SUBPROGRAM PURPOSE:											   */             
	'/*	 This will handle insert requests to the database. It will set up  */
	'/*  The database connection and send the query. If there is an issue  */
	'/*  it will display the query that had the issue as well as the issue */
	'/*  being reported.     */
	'/*                                                                   */
	'/*********************************************************************/
	'/*  CALLED BY: frmConfiguration.vb  	      						  */           
	'/*                                         				   */         
	'/*********************************************************************/
	'/*  CALLS:										   */                 
	'/*             (NONE)								   */             
	'/*********************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):								*/         
	'/*	 strStatement - this is the SQL query that the user is looking to */ 
	'/*					excute.											  */
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

	Public Sub ExecuteInsertQuery(strStatement As String)
		DBConn = New SQLiteConnection(strCONNECTION)
		DBCmd = New SQLiteCommand(strStatement, DBConn)
		DBConn.Open()
		Try
			DBCmd.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show("could not complete the following SQL statement: " & strStatement &
							" the following error occured: " & vbCrLf & vbCrLf & ex.ToString)
		End Try
		DBConn.Close()
	End Sub

	'/*********************************************************************/
	'/*                   SUBPROGRAM NAME:  ExecuteScalarQuery			   */         
	'/*********************************************************************/
	'/*                   WRITTEN BY:  Alexander Beasecker   			 */   
	'/*		         DATE CREATED: 	2/2/2021							   */                             
	'/*********************************************************************/
	'/*  SUBPROGRAM PURPOSE:											   */             
	'/*	 This will handle execute scalar sql statements. these statements
	'/*  will return a single value from the database. The sql statement 
	'/* is passed to this method, this method runs the scalar statement
	'/* then returns the  string value from the statement.
	'/*********************************************************************/
	'/*  CALLED BY: frmConfiguration.vb     						         */           
	'/*                                         				   */         
	'/*********************************************************************/
	'/*  CALLS:										   */                 
	'/*             (NONE)								   */             
	'/*********************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):								*/         
	'/*	 strStatement - this is the SQL query that the user is looking to */ 
	'/*					excute.											  */
	'/*                                                                     
	'/*********************************************************************/
	'/*  RETURNS:								         */                   
	'/*    strReturnedScalar as string         
	'/*********************************************************************/
	'/* SAMPLE INVOCATION:								   */             
	'/*											   */                     
	'/*          ExecuteScalarQuery("Select * from Table")                                                           
	'/*********************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically without hungry notation):    */
	'/*	strReturnedScalar									                      
	'/*                                                                     
	'/*********************************************************************/
	'/* MODIFICATION HISTORY:						                      
	'/*											                       
	'/*  WHO             WHEN     WHAT								      */             
	'/*  ---             ----     ----------------------------------------*/
	'/*  AlexBeasecker  01/23/21  Initial creation of the code			  */                                                                   
	'/*********************************************************************/
	Public Function ExecuteScalarQuery(strStatement As String)
        'declare string for the scalar statement
        Dim strReturnedScalar As String = ""

        'create database connection
        DBConn = New SQLiteConnection(strCONNECTION)
        DBCmd = New SQLiteCommand(strStatement, DBConn)
        DBConn.Open()
        Try
            strReturnedScalar = DBCmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("could not complete the following SQL statement: " & strStatement &
                            " the following error occured: " & vbCrLf & vbCrLf & ex.ToString)

        End Try
		DBConn.Close()
		Return strReturnedScalar
    End Function
End Module
