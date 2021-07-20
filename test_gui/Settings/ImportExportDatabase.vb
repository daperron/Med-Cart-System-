Imports System.IO
'/***********************************************************************/
'/*                   FILE NAME:  ImportExportDatabase.vb				*/
'/***********************************************************************/
'/*					  PART OF PROJECT: 									*/
'/***********************************************************************/
'/*                   WRITTEN BY:  Breanna Howey	  					*/
'/*					  DATE CREATED: February 3, 2021					*/
'/***********************************************************************/
'/*  MODULE PURPOSE:													*/
'/*																		*/
'/* This file serves as the driver for importing and exporting database.*/
'/* When the subroutines are invoked, the user can choose to import the */
'/* database, import a copy of a database, or export the database.      */
'/********************************************************************	*/
'/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			        */
'/*                         (NONE)	                                    */
'/***********************************************************************/
'/*  ENVIRONMENTAL RETURNS:							                    */
'/*                        (NOTHING)					                */
'/***********************************************************************/
'/* SAMPLE INVOCATION:								                    */
'/*											                            */
'/* The program will invoke the ImportExportDatabase module when the user
'/* clicks on either the Import or Export buttonns.                     */
'/***********************************************************************/
'/*  GLOBAL VARIABLE LIST (Alphabetically):			                    */
'/*						  	 (NONE)			                            */
'/******************************************************************    */
'/* COMPILATION NOTES:								                    */
'/* 											                        */
'/* This project compiles normally under Microsoft Visual Basic.        */
'/* All one needs to do Is open up the Solver project And compile.      */
'/* No special compile options Or optimizations were used.  No          */
'/* unresolved warnings Or errors exist under these compilation         */
'/* conditions.									                        */
'/***********************************************************************/
'/* MODIFICATION HISTORY:						                        */
'/*											                            */
'/*  WHO        WHEN        WHAT						                */
'/*  BRH        02/13/21   Initial creation of the code-------------	*/
'/***********************************************************************/
Module ImportExportDatabase

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      ExportDatabase			*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to allow the user to export	*/
	'/* data stored in the current database into another database. When */
	'/* it is called, the config.app is read to determine what the		*/
	'/*	current database is. Next, a savefiledialog window will appear	*/
	'/* asking the user where to save the file and under what name.		*/
	'/* Finally, the FileCopy function is called copying all data from	*/
	'/* the current database into the new database.						*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	frmSerialPort.vb												*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*		(None)														*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	ExportDatabase()												*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*  dlgOpenFileDialog - Stores an instance of the OpenFileDialog	*/
	'/*							window									*/
	'/*	strDestinationFile - Stores the destination file path specified	*/
	'/*							by the user								*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT												*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*******************************************************************/
	Public Sub ExportDatabase()
		Dim strDestinationFile As String
		'Initializes a dialog for saving files
		Dim dlgSaveFileDialog As New SaveFileDialog

		Using reader As StreamReader = New StreamReader(strApplicationPath)
			'use the global strDBPath
			strDBPath = reader.ReadLine
		End Using

		'Set up how the save dialog box will work
		dlgSaveFileDialog.Filter = "db files (*.db)|*.db"
		dlgSaveFileDialog.FilterIndex = 1
		dlgSaveFileDialog.RestoreDirectory = True

		'If the user types in a name and selects ok, the 
		'file path that they entered in will be stored in the
		'destination file variables and then data from the 
		'original database will be exported to the newly specified database
		If dlgSaveFileDialog.ShowDialog() = DialogResult.OK Then
			strDestinationFile = dlgSaveFileDialog.FileName
			FileCopy(strDBPath, strDestinationFile)
			MessageBox.Show("Data was successfully exported")
		End If
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      ImportDatabase			*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to allow the user to import	*/
	'/* a database into the system and use that database's data.		*/
	'/* When called, the subrotutine will prompt the user to select the */
	'/* name of a database to import. Once the file path is read into	*/
	'/* the designated variable, the program will reload the data to be */
	'/* cohesive with the new database path.							*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	frmSerialPort.vb												*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*		SetupOpenFileDialog											*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	ImportDatabase()												*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT												*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*******************************************************************/
	Public Sub ImportDatabase()

		SetupOpenFileDialog()

		'If the user selects a file and presses ok, the file path will be saved in config.app
		If dlgOpenFileDialog.ShowDialog() = DialogResult.OK Then
			strDBPath = dlgOpenFileDialog.FileName

			My.Computer.FileSystem.DeleteFile(strApplicationPath)
			'Rewrite the imported database path into the config app
			My.Computer.FileSystem.WriteAllText(strApplicationPath, strDBPath, True)
			Using reader As StreamReader = New StreamReader(strApplicationPath)
				strDBPath = reader.ReadLine
			End Using

			'Reload the data
			CreateDatabase.Main()
			MessageBox.Show("Database successfully imported")
		End If
	End Sub

	'/*******************************************************************/
	'/*                   SUBROUTINE NAME:      ImportDatabaseAsCopy	*/
	'/*******************************************************************/
	'/*                   WRITTEN BY:  	Breanna Howey					*/
	'/*					DATE CREATED: 	   02/13/21						*/
	'/*******************************************************************/
	'/*  SUBROUTINE PURPOSE:											*/
	'/*	The purpose of this subroutine is to allow the user to import	*/
	'/* a copy of the database into the system and use that database's 	*/
	'/* data. When called, the subroutine will prompt the user to select */
	'/* the name of a database to copy. Once the file is copied, the file */
	'/* path is read into the designated variable, the program will		 */
	'/* reload the data to becohesive with the new database path.		*/
	'/*******************************************************************/
	'/*  CALLED BY:   	      											*/
	'/*	frmSerialPort.vb												*/
	'/*******************************************************************/
	'/*  CALLS:															*/
	'/*		ImportDatabaseAsCopy										*/
	'/*******************************************************************/
	'/*  PARAMETER LIST (In Parameter Order):							*/
	'/*																	*/
	'/*  (None)															*/
	'/*******************************************************************/
	'/* SAMPLE INVOCATION:												*/
	'/*																	*/
	'/*	ImportDatabase()												*/
	'/*******************************************************************/
	'/*  LOCAL VARIABLE LIST (Alphabetically):							*/
	'/*																	*/
	'/*	strDestinationFile - Stores the desired destination file		*/
	'/*******************************************************************/
	'/* MODIFICATION HISTORY:											*/
	'/*																	*/
	'/* WHO   WHEN     WHAT												*/
	'/*  ---   ----     ------------------------------------------------*/
	'/*	BRH	 02/13/21	Created subroutine to allow for less code in main
	'/*******************************************************************/
	Public Sub ImportDatabaseAsCopy()
		Dim strDestinationFile As String

		SetupOpenFileDialog()

		'If the user selects a file and presses ok, the file path will be saved in config.app
		If dlgOpenFileDialog.ShowDialog() = DialogResult.OK Then
			'The code will copy the database path specified by the user behind the scenes
			strDBPath = dlgOpenFileDialog.FileName
			strDestinationFile = dlgOpenFileDialog.FileName.Substring(0, dlgOpenFileDialog.FileName.Length - 3) & " - Copy.db"
			'Method to copy the data in the database specified into the new copy
			FileCopy(strDBPath, strDestinationFile)
			MessageBox.Show("Data was successfully copied")

			'Rewrite the new database path to the copied database
			My.Computer.FileSystem.DeleteFile(strApplicationPath)
			My.Computer.FileSystem.WriteAllText(strApplicationPath, strDestinationFile, True)

			'Reload the data
			CreateDatabase.Main()
			MessageBox.Show("Database was successfully imported")
		End If


	End Sub
End Module
