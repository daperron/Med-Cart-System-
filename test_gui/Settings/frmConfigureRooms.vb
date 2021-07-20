'/********************************************************************	*/
'/*                   FILE NAME:  frmConfigureRooms					    */
'/********************************************************************	*/
'/*					  PART OF PROJECT: 									*/
'/********************************************************************	*/
'/*                   WRITTEN BY:  Breanna Howey	  					*/
'/*					  DATE CREATED: February 17, 2021					*/
'/********************************************************************	*/
'/*  FILE PURPOSE:														*/
'/*																		*/
'/* This file serves as the driver for the function between clicking on
'/* the controls for adding and deleting rooms and beds.                */
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
'/* strAllowedNameCharacters - Stores the allowed characters for room   */
'/*                            and bed names                            */
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
'/*  BRH        02/22/21   Added new implementation for new controls	*/
'/********************************************************************	*/
Public Class frmConfigureRooms
    Public strAllowedNameCharacters = "abcdefghijklmnopqrstuvwxyz """"-1234567890"
    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:     frmConfigureRooms_Load	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of showing
    '/* the rooms and the beds to the user upon form load.              */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ShowRoomsBeds()										            */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores other arguments passed to the routine.             */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	frmConfigurationLoad()	    								    */
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
    '/*  BRH        03/23/21   Changed text boxes to only allow 12 characters
    '/*  BRH        04/03/21   Hid the add button and automatically     */
    '/*                        checked the add radio button             */
    '/*******************************************************************/

    Private Sub frmConfigureRooms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowRoomsBeds()
        SetControlVisibility(False, False)
        lblAddMoreBeds.Visible = False
        rdoYes.Visible = False
        rdoNo.Visible = False
        txtRoom.MaxLength = 12
        txtBed.MaxLength = 12
        'hide the add button
        btnAdd.Visible = False
        'have the add rooms and bed checked by default
        rdoAddRoomBed.Checked = True
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:     btnAddBed_Click         	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of adding
    '/* rooms and beds to the database. When the button is clicked, the*/
    '/* program will add the room and bed to the database from the text */
    '/* entered into the corresponding text boxes. Next, the room and bed
    '/* list boxes are cleared to allow for repopulation of data.       */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* AddRoomsBeds()          										*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores other arguments passed to the routine.             */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	frmAddBed_Click()	    								        */
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
    '/*  BRH        03/16/21   Allow for easy addition of multiple beds-*/
    '/*                         to the recent room added----------------*/
    '/*  BRH        03/23/21   Fixed to only show persistent beds added */
    '/*                        to rooms if a room and bed were entered  */
    '/*******************************************************************/
    Private Sub btnAddBed_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddRoomsBeds(txtRoom.Text, txtBed.Text, 1)
        ShowRoomsBeds()

    End Sub



    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:     btnDeleteRoom_Click    	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of deleting
    '/* rooms from the database, when the delete room button is selected*/
    '/* In addition, the listboxes will repopulate withthe rooms and beds in*/
    '/* the database.                                                   */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* DeleteRoom               										*/
    '/* ShowRoomsBeds              										*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores other arguments passed to the routine.             */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	btnDeleteRoom()     	    								    */
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
    Private Sub btnDeleteRoom_Click(sender As Object, e As EventArgs) Handles btnDeleteRoom.Click
        DeleteRoom(lstRooms.SelectedItem)
        ShowRoomsBeds()
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:     btnDeleteBed_Click    	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of deleting
    '/* beds from the database, when the delete bed button is selected  */
    '/* In addition, the listboxes will repopulate the rooms and beds in*/
    '/* the database.                                                   */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* DeleteBed                 										*/
    '/* ShowRoomsBeds              										*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores other arguments passed to the routine.             */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	btnDeleteBed()     	    								    */
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
    '/*  BRH        03/23/21    Updated functionality to only clear selection
    '/*                         if a bed was deleted                    */
    '/*******************************************************************/
    Private Sub btnDeleteBed_Click_1(sender As Object, e As EventArgs) Handles btnDeleteBed.Click
        DeleteBed(lstBeds.SelectedItem)
    End Sub

    '/*******************************************************************/
    '/*                   SUBROUTINE NAME:    ShowRoomsBeds            	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to handle the process of repopulating
    '/* the rooms and beds listboxes to show the user the current rooms */
    '/* and beds in the database. When called, the routine will clear the
    '/* boxes and select the new data from the database.                */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ShowRooms                 										*/
    '/* ShowBeds              										    */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	ShowRoomsBeds()     	    								    */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN      WHAT											*/
    '/*  ---  ----      ------------------------------------------------*/
    '/* BRH   02/17/21  Initial creation of the code--------------------*/
    '/* BRH   04/11/21  Fixed the drop down to only show the rooms that */
    '/*                 have beds not filled by patients yet.           */
    '/*******************************************************************/
    Public Sub ShowRoomsBeds()
        lstRooms.Items.Clear()
        lstBeds.Items.Clear()
        'Show rooms unfilled
        ShowRooms("SELECT DISTINCT Room_ID FROM Rooms WHERE Room_ID || Rooms.Bed_Name  NOT IN 
                   (SELECT Room_TUID || PatientRoom.Bed_Name FROM PatientRoom Inner Join Rooms On Room_TUID = Room_ID 
                    WHERE PatientRoom.Active_Flag = 1) AND Rooms.Active_Flag = 1 ORDER BY Room_ID ASC")
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     lstRooms_SelectedIndexChanged    	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/17/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to populate the beds listbox  *;
    '/* with beds that have the room name equal to that of the item selected
    '/* in the rooms listbox. If a record in the database matches the   */
    '/* criteria, it is added to the beds listbox for the user to select*/
    '/* for deletion or to view what beds are in the room selected.     */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/* ShowBeds                										*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores other arguments passed to the routine.             */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	lstRooms_SelectedIndexChanged  								    */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN      WHAT											*/
    '/*  ---   ----     ------------------------------------------------*/
    '/* BRH   02/17/21  Initial creation of the code--------------------*/
    '/* BRH   04/111/21  Fixed the drop down to only show the beds that */
    '/*                 have beds not filled by patients yet.           */
    '/*******************************************************************/

    Private Sub lstRooms_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lstRooms.SelectedIndexChanged
        lstBeds.Items.Clear()
        'Show beds unfilled
        ShowBeds("SELECT DISTINCT Bed_Name FROM Rooms WHERE Room_ID || Rooms.Bed_Name  NOT IN 
                   (SELECT Room_TUID || PatientRoom.Bed_Name FROM PatientRoom Inner Join Rooms On Room_TUID = Room_ID 
                    WHERE PatientRoom.Active_Flag = 1) AND Room_ID = '" & lstRooms.SelectedItem & "' AND Rooms.Active_Flag = 1 ORDER BY Bed_Name ASC")
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:         	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/22/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to show the add controls on   */
    '/* the form when the Add Room Bed radio button is selected.        */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*  SetControlVisibility      										*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores other arguments passed to the routine.             */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	rdoAddRoomBed_CheckedChanged 								    */
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/22/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Private Sub rdoAddRoomBed_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAddRoomBed.CheckedChanged
        SetControlVisibility(True, False)
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     rdoDeleteRoomBed_CheckedChanged  	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/22/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to show the deltee controls on*/
    '/* the form when the Add Room Bed radio button is selected.        */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*  SetControlVisibility      										*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores other arguments passed to the routine.             */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	rdoDeleteRoomBed_CheckedChanged 								*/
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/22/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Private Sub rdoDeleteRoomBed_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDeleteRoomBed.CheckedChanged
        SetControlVisibility(False, True)
        'Sets the panel of delete controls to the same locations as those of the add controls
        pnlDelete.Location = New Point(12, 65)
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     SetControlVisibility             	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/22/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to set specific controls to be*/
    '/* visible on the screen. The routine takes whether the add or delete
    '/* controls need to be visible on the screen, from boolean variables,
    '/* and sets the controls accordingly.                              */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*  (None)                   										*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* blnAddControls - Stores whether the add controls need to be visible
    '/* blnDeleteControls - Stores whether the delete controls need to  */
    '/*                     be visible                                  */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	SetControlVisibility(True, False) 								*/
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/22/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Private Sub SetControlVisibility(blnAddControls As Boolean, blnDeleteControls As Boolean)
        pnlAdd.Visible = blnAddControls
        pnlDelete.Visible = blnDeleteControls
    End Sub


    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     txtRoom_KeyPress                  	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/22/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to only allow the user to enter*/
    '/* specific characters. If the user tries to enter invalid characters,
    '/* the textbox won't show the characters.                          */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*   DataVaildationMethods.KeyPressCheck   						*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores what key was pressed                               */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	txtRoom_KeyPress                								*/
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/22/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Private Sub txtRoom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRoom.KeyPress
        DataVaildationMethods.KeyPressCheck(e, strAllowedNameCharacters)
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     txtBed_KeyPress                  	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   02/22/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to only allow the user to enter*/
    '/* specific characters. If the user tries to enter invalid characters,
    '/* the textbox won't show the characters.                          */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*   DataVaildationMethods.KeyPressCheck   						*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores what key was pressed                               */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	txtBed_KeyPress                								*/
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        02/22/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Private Sub txtBed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBed.KeyPress
        DataVaildationMethods.KeyPressCheck(e, strAllowedNameCharacters)
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     rdoYes_CheckedChanged            	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   03/16/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to only clear the bed name text/
    '/* box when the user selects the "Yes" radio button.               */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*   None()                                 						*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores what key was pressed                               */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	rdoYes_CheckedChanged              								*/
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        03/16/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Private Sub rdoYes_CheckedChanged(sender As Object, e As EventArgs) Handles rdoYes.CheckedChanged
        txtBed.Clear()
        'Make the text boxes editable
        txtRoom.ReadOnly = False
        txtBed.ReadOnly = False
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     rdoNo_CheckedChanged            	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   03/16/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to only clear the bed name text/
    '/* box and the room name text box when the user selects the "No"   */
    '/* radio button.                                                   */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*   None()                                 						*/
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores what key was pressed                               */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	rdoNo_CheckedChanged              								*/
    '/*******************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):							*/
    '/*																	*/
    '/* (None)                                                          */
    '/*******************************************************************/
    '/* MODIFICATION HISTORY:											*/
    '/*																	*/
    '/* WHO   WHEN     WHAT											    */
    '/*  ---   ----     ------------------------------------------------*/
    '/*  BRH        03/16/21   Initial creation of the code-------------*/
    '/*******************************************************************/
    Private Sub rdoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNo.CheckedChanged
        txtRoom.Clear()
        txtBed.Clear()
        'Make the text boxes editable
        txtRoom.ReadOnly = False
        txtBed.ReadOnly = False

        'Clear the message for adding new beds to the same room
        lblAddMoreBeds.Visible = False
        rdoYes.Visible = False
        rdoNo.Visible = False

        'Necessary to allow for the label and radio buttons to repopulate
        rdoNo.Checked = False
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     txtRoom_TextChanged            	*/
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   03/23/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to call the SetButtonVisibility
    '/* subroutine to determine if the Add button needs to be visible.  */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*   SetButtonVisibility()                                 	    */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores what key was pressed                               */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	txtRoom_TextChanged              								*/
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
    '/*******************************************************************/
    Private Sub txtRoom_TextChanged(sender As Object, e As EventArgs) Handles txtRoom.TextChanged
        SetButtonVisibility()
    End Sub

    '/*******************************************************************/
    '/*         SUBROUTINE NAME:     txtBed_TextChanged            	    */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  	Breanna Howey					*/
    '/*					DATE CREATED: 	   03/23/21						*/
    '/*******************************************************************/
    '/*  SUBROUTINE PURPOSE:											*/
    '/*	The purpose of this subroutine is to call the SetButtonVisibility
    '/* subroutine to determine if the Add button needs to be visible.  */
    '/*******************************************************************/
    '/*  CALLS:															*/
    '/*   SetButtonVisibility()                                 	    */
    '/*******************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):							*/
    '/*																	*/
    '/* sender - Holds the object the program is sending to the routine */
    '/* e   - Stores what key was pressed                               */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:												*/
    '/*																	*/
    '/*	txtBed_TextChanged              								*/
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
    '/*******************************************************************/
    Private Sub txtBed_TextChanged(sender As Object, e As EventArgs) Handles txtBed.TextChanged
        SetButtonVisibility()
    End Sub
End Class