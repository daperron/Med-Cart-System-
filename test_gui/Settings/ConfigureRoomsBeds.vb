'/********************************************************************	*/
'/*                   FILE NAME:  ConfigureRoomsBeds					*/
'/********************************************************************	*/
'/*					  PART OF PROJECT: 									*/
'/********************************************************************	*/
'/*                   WRITTEN BY:  Breanna Howey	  					*/
'/*					  DATE CREATED: February 17, 2021					*/
'/********************************************************************	*/
'/*  FILE PURPOSE:														*/
'/*																		*/
'/* This file serves as the driver for adding and deleting rooms and beds/
'/* from the database. When the functions are called, a room and bed    */
'/* will be added, or the user will choose a room or a bed to delete.   */
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
'/* dsValues - Stores the dataset returned by selecting info from the   */
'/*             database.                                               */
'/* strSQLCmd - Stores the SQL statement to either insert, update, or   */
'/*             select information from the database                    */
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
'/*  BRH        02/17/21   Initial creation of the code-------------	*/
'/********************************************************************	*/
Module ConfigureRoomsBeds

    Dim strSQLCmd As String
    Dim dsValues As DataSet = New DataSet

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:     AddRoomsBeds      		*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of      */
    '/* adding rooms and beds. The routine will go through and read in  */
    '/* all records from the database and store it in a dataset. Then,  */
    '/* the information entered into the Rooms and Beds textboxes will be/
    '/* read and stored in the specified variables. If a record already */
    '/* exists in the database with the entered room and bed names, then*/
    '/* the active flag will be reset to active. If the user doesn't enter
    '/* a room or a bed and tries to hit the add button, the program will
    '/* notify the user of their mistake and won't talk to the databse. */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*	frmConfigureRooms.btnAddBed_Click()								*/
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ExecuteInsertQuery()											*/
    '/* frmConfigureRooms.ShowRoomsBeds()                               */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*  strRoom - Holds the name of the room							*/
    '/*  strBed - Holds the name of the bed 							*/
    '/*  intActiveFlag - Holds whether the room and bed are active  	*/
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	AddRoomsBeds()												    */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* blnActiveFlag - Stores whether the record is active             */
    '/* blnDuplicateBed - Stores whether the bed name is in the database*/
    '/* blnDuplicateRoom - Stores whether the room name is in the database
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/17/21   Initial creation of the code-------------*/
    '/*  BRH        03/23/21   Fixed to only show persistent beds added */
    '/*                        to rooms if a room and bed were entered  */
    '/*******************************************************************/

    Public Sub AddRoomsBeds(ByVal strRoom As String, ByVal strBed As String, ByVal intActiveFlag As Integer)
        Dim blnDuplicateRoom As Boolean = False
        Dim blnDuplicateBed As Boolean = False
        Dim blnActiveFlag As Boolean = True
        'Clears the dataset
        dsValues.Clear()

        'Grab all the rooms and beds from the database
        dsValues = ExecuteSelectQuery("SELECT * FROM Rooms")

        'As long as both textboxes have data, do the following:
        If strRoom <> Nothing And strBed <> Nothing Then

            'Check to see if the desired room and bed name
            'entered into the textboxes are in the database
            'If they are, set corresponding duplicate boolean
            'values for future use and store whether the record was
            'active or inactive in the database
            For Each value As DataRow In dsValues.Tables(0).Rows
                If value(0) = strRoom And value(1) = strBed Then
                    blnDuplicateRoom = True
                    blnDuplicateBed = True
                    blnActiveFlag = value(2)
                End If
            Next

            'If the entered room and bed names are already active in the database,
            'let the user know it is already in the system
            If blnDuplicateRoom = True And blnDuplicateBed = True And blnActiveFlag = True Then
                MessageBox.Show("An active room and bed with the specified names is already stored in the system.")
                'If the entered room and bed names are already in the database but inactive,
                'update the active flag in the database and let the user know the database
                'was updated
            ElseIf blnDuplicateRoom = True And blnDuplicateBed = True And blnActiveFlag = False Then
                strSQLCmd = "UPDATE Rooms SET Active_Flag ='" & 1 & "' WHERE Room_ID = '" & strRoom & "' AND Bed_Name = '" & strBed & "';"

                ExecuteInsertQuery(strSQLCmd)

                MessageBox.Show("The room and bed has been updated")
                'The entered values weren't duplicates, so a new record is inserted
            Else
                strSQLCmd = "INSERT INTO Rooms(Room_ID,Bed_Name,Active_Flag) " &
                    "VALUES('" & strRoom & "', '" & strBed & "', '" & intActiveFlag & "')"

                ExecuteInsertQuery(strSQLCmd)

                MessageBox.Show("The room and bed has been inserted.")
            End If

            'Show the radio buttons asking the user if they want to add
            'more beds to the entered room.
            frmConfigureRooms.lblAddMoreBeds.Text = "Would you like to add more beds to " & frmConfigureRooms.txtRoom.Text & "?"
            frmConfigureRooms.lblAddMoreBeds.Visible = True
            frmConfigureRooms.rdoYes.Visible = True
            frmConfigureRooms.rdoNo.Visible = True
            frmConfigureRooms.rdoYes.Checked = False
            frmConfigureRooms.rdoNo.Checked = False
            'Make the text boxes read only until the user chooses
            'whether they want to add another bed to the recently
            'entered room
            frmConfigureRooms.txtRoom.ReadOnly = True
            frmConfigureRooms.txtBed.ReadOnly = True

        Else
            MessageBox.Show("Please make sure a room and a bed are entered before adding")
        End If
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:        DeleteRoom       		*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of      */
    '/* deleting the room from the database. If the user hasn't selected*/
    '/* a room, let the user know they haven't selected a room. If one is
    '/* selected, update all active flag for records with the designated*/
    '/* room name to inactive, as we still want to have record that the */
    '/* room and bed existed.                                           */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*	btnDeleteRoom_Click()           								*/
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ExecuteInsertQuery()											*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*  strRoom - Stores the name of the room to be inactivated        */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	DeleteRoom()												    */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/*  dlgResult - Stores the initialization of a dialog box.         */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/17/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Public Sub DeleteRoom(ByVal strRoom As String)
        If strRoom <> Nothing Then
            Dim dlgResult As DialogResult = MessageBox.Show("Are you sure you want to delete room " & strRoom & "?" & vbCr &
                                                            "If yes, all beds will be deleted, as well", "Delete Room", MessageBoxButtons.YesNo)

            If dlgResult = DialogResult.Yes Then
                strSQLCmd = "UPDATE Rooms SET Active_Flag ='" & 0 & "' WHERE Room_ID = '" & strRoom & "';"

                ExecuteInsertQuery(strSQLCmd)

                MessageBox.Show("All rooms with specified name were deleted")
            End If
        Else
            MessageBox.Show("Please select a room before proceeding to delete")
        End If
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:        DeleteBed       		*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of      */
    '/* deleting the bed from the database. If the user hasn't selected*/
    '/* a bed, it lets the user know they haven't selected a room. If one is
    '/* selected, update all active flag for records with the designated*/
    '/* bed name to inactive, as we still want to have record that the */
    '/* room and bed existed.                                           */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*	btnDeleteBed_Click()            								*/
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ExecuteInsertQuery()											*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*  strBed - Stores the name of the bed to be inactivated          */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	DeleteBed()												        */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/*  dlgResult - Stores the initialization of a dialog box.         */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/17/21   Initial creation of the code-------------*/
    '/*  BRH        03/23/21    Updated functionality to only clear selection
    '/*                         if a bed was deleted                    */
    '/*******************************************************************/
    Public Sub DeleteBed(ByVal strBed As String)
        If strBed <> Nothing Then
            Dim dlgResult As DialogResult = MessageBox.Show("Are you sure you want to delete bed " & strBed & "?" & vbCr &
                                                            "If yes, all rooms with the bed will be deleted", "Delete Bed", MessageBoxButtons.YesNo)

            If dlgResult = DialogResult.Yes Then
                strSQLCmd = "UPDATE Rooms SET Active_Flag ='" & 0 & "' WHERE Bed_Name = '" & strBed & "';"

                ExecuteInsertQuery(strSQLCmd)

                MessageBox.Show("All beds with specified name were deleted")
            End If

            frmConfigureRooms.lstRooms.Items.Clear()
            frmConfigureRooms.lstBeds.Items.Clear()
            frmConfigureRooms.ShowRoomsBeds()
        Else
            MessageBox.Show("Please select a Bed before proceeding to delete")
        End If
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:         ShowRooms      		*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of      */
    '/* grabbing rooms from the database and displaying them to the user*/
    '/* The routine clears the dataset, selects the unique rooms from the
    '/* database, and popuate the room listbox for the user.            */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*	frmConfigureRooms.ShowRoomsBeds()								*/
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ExecuteSelecttQuery()											*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*  strSQLCmd - Stores the SQL code for passing to the database    */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	ShowRooms()												        */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/17/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Public Sub ShowRooms(strSQLCmd As String)

        dsValues.Clear()

        dsValues = ExecuteSelectQuery(strSQLCmd)

        For Each value As DataRow In dsValues.Tables(0).Rows
            frmConfigureRooms.lstRooms.Items.Add(value(0))
        Next
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:         ShowBeds      		*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of      */
    '/* grabbing beds from the database and displaying them to the user*/
    '/* The routine clears the dataset, selects the unique beds from the
    '/* database, and popuates the beds listbox for the user.           */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*	frmConfigureRooms.ShowRoomsBeds()								*/
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ExecuteSelecttQuery()											*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*  strSQLCmd - Stores the SQL code for passing to the database    */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	ShowBeds()												        */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/17/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Public Sub ShowBeds(strSQLCmd As String)
        dsValues.Clear()

        dsValues = ExecuteSelectQuery(strSQLCmd)

        For Each value As DataRow In dsValues.Tables(0).Rows
            frmConfigureRooms.lstBeds.Items.Add(value(0))
        Next
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:         SetButtonVisibility  */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   03/23/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to set the visibility of the Add
    '/* button to be enabled only after a room and bed are entered.     */
    '/*******************************************************************/
    '/*  CALLED BY:   	      											*/
    '/*	txtRoom_TextChanged								                */
    '/* txtBed_TextChanged                                              */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* None											                */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/*  None                                                           */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	SetButtonVisibility()										    */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        03/23/21   Initial creation of the code-------------*/
    '/*  BRH        04/03/21   Hide the add button until the user enters*/
    '/*                        info into both the room and bed text boxes/
    '/*******************************************************************/
    Public Sub SetButtonVisibility()

        If frmConfigureRooms.txtRoom.Text IsNot "" And frmConfigureRooms.txtBed.Text IsNot "" Then
            frmConfigureRooms.btnAdd.Visible = True
        Else
            frmConfigureRooms.btnAdd.Visible = False
        End If
    End Sub

End Module
