Imports Newtonsoft.Json.Linq
Imports RestSharp
Module rxNorm
    '/*******************************************************************/
    '/*                   FILE NAME:  rxNorm.vb                         */
    '/*******************************************************************/
    '/*                 PART OF PROJECT: Med_Cart				        */
    '/*******************************************************************/
    '/*                   WRITTEN BY:  Dillen Perron    		        */
    '/*		         DATE CREATED: January 27, 2021			            */
    '/*******************************************************************/
    '/*  MODULE PURPOSE:								                */
    '/*											                        */
    '/* This module will allow the application to pull a RESTcall       */
    '/* to the web api and return the drug information including the    */  
    '/* rxUI number                                                     */
    '/*******************************************************************/
    '/*  COMMAND LINE PARAMETER LIST (In Parameter Order):			    */
    '/*                                                    (NONE)	    */
    '/*******************************************************************/
    '/*  ENVIRONMENTAL RETURNS:							                */
    '/*                          (NOTHING)					            */
    '/*******************************************************************/
    '/* SAMPLE INVOCATION:								                */
    '/*											                        */
    '/*                                                                 */
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
    '/*  Dillen    1/27/2021   Initial creation                         */
    '/*******************************************************************/







    '/*********************************************************************/
    '/*                   FUNCTION NAME:  getDrugInformationByName        */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/3/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This function Is responsible for making rxNorm api call           */
    '*/ to gather drug information                                        */
    '/*											                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*            (NOTHING)								              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/* getDrugInformationByName("tylenol")  		                      */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '/*  Dillen  01/27/21  Function to make api call to get               */
    '<<<<<<< HEAD
    '/*                      drug information.                            */
    '/*  Dillen 02/17/2021  Optimzed code                                 */
    '=======
    '/*                      drug information.			                  */
    '/* NP       02/9/2021 Changed function to return result to remove the*/
    '/*                    Warning for not returning a value.             */
    '>>>>>>> main
    '/*********************************************************************/


    Function getDrugInformationByName(drugname As String) As String
        ' Insert functionality to check the network connectivity
        frmInventory.txtStatus.Text = "Checking network connectivity"
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            'URL for finding each drug name 
            Dim url As String = strSite & "drugs?name=" & drugname

            Dim trawlPointer As String = "$.drugGroup.conceptGroup[1].conceptProperties"
            'convert web response to Jtoken
            Dim inputJSON As JToken = GetJSON(url)

            'set Jtoken into array to pull data from json
            Dim JsonJArray As JArray = inputJSON.SelectToken(trawlPointer)

            'currently not working should pull back the full drug name 
            For Each item In JsonJArray
                For Each subItem As JProperty In item
                    If subItem.Name = "name" Then
                        Return DirectCast(subItem.Next, JProperty).Value
                    End If
                Next
            Next

            Return Nothing
        Else
            Return Nothing
        End If


    End Function




    '/*********************************************************************/
    '/*                   FUNCTION NAME:  getRxcuiProperty               */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/3/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This function Is responsible for gathering all property           */
    '/*	information on a given rxcui number		                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/* trawledResult - this will be the property returned from api       */
    '/*                 as a string                                       */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*  getRxcuiProperty("2055307", myPropertyNameList)			      */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*	 url - holds a link to the api with the selected rxui             */
    '/*  restClient -			                                          */
    '/*  restRequest - 			                                          */
    '/*  result - holds the result of the api call (json format)          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '/*  Dillen  01/27/21  Function to make api call to get               */
    '/*                      drug properties                              */
    '/*  Dillen  2/10/21    Added functionality for finding property      */
    '/*                     in json file                                  */
    '/*  Dillen  2/16/21    Fixed Functionality search any property       */
    '/*********************************************************************/

    Function getRxcuiProperty(rxcuiNum As String, propertyNames As List(Of String)) As List(Of (PropertyName As String, PropertyValue As String))
        Dim strName As String
        Dim strValue As String
        'list that holds Property name and its value
        Dim myReturnList As New List(Of (PropertyName As String, PropertyValue As String))
        ' Insert functionality to check the network connectivity
        frmInventory.txtStatus.Text = "Checking network connectivity"
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            'API url for get all properties
            Dim url As String = strSite & "rxcui/" & rxcuiNum & "/allProperties.json?prop=attributes"
            'location in json of properties
            Dim trawlPointer As String = "$.propConceptGroup.propConcept"
            'convert web response to Jtoken
            Dim inputJSON As JToken = GetJSON(url)
            'set Jtoken into array to pull data from json
            Dim JsonJArray As JArray = inputJSON.SelectToken(trawlPointer)

            'Goes through the  Json file and looks for the properties set in propertyNames List and pulls the value and stores in myReturnList
            For Each PropertyName As String In propertyNames
                For Each item In JsonJArray
                    For Each subItem As JProperty In item
                        If subItem.Value.ToString.ToUpper = PropertyName.ToUpper Then
                            strName = subItem.Value.ToString
                            strValue = DirectCast(subItem.Next, JProperty).Value.ToString
                            myReturnList.Add((strName, strValue))
                        End If
                    Next
                Next
            Next
            'returns the List
            Return myReturnList
        Else
            Return myReturnList
        End If

    End Function


    '/*********************************************************************/
    '/*                   FUNCTION NAME:  getDrugRXCUI                    */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/3/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This function is a Search for a name in the RxNorm data set and   */
    '/* Return the RxCUIs Of any concepts which have that name As an      */
    '/* RxNorm term Or As a synonym Of an RxNorm term. Search option      */
    '/* is a normalized String search. (search = 1)                       */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*   		Rxcui As String					                          */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*   getDrugRXCUI("advil","200","mg","Tab")				          */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*	 url - holds a link to the api with the selected rxui             */
    '/*  restClient -			                                          */
    '/*  restRequest - 			                                          */
    '/*  result - holds the result of the api call (json format)          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '<<<<<<< HEAD
    '/*  Dillen  02/4/21  inital creation                                 */
    '/*  Dillen  02/5/21  Parsing data in api                             */  
    '/*  Dillen  02/17/21 Optimized code                                  */
    '/*********************************************************************/
    '/*  Dillen  01/27/21  Function to make api call to get               */
    '/*                      drug properties            			      */
    '/*  NP      02/9/2021 Added a return that returns the result to      */
    '/*                    remove the function has no return warning.     */
    '/*********************************************************************/
    Function getDrugRXCUI(drugName As String, drugStrength As String, drugMeasurement As String, drugType As String) As String
        'URL for finding rxcui json file that contains the name and rxcui 
        Dim jValueObj As JValue
        ' Insert functionality to check the network connectivity
        frmInventory.txtStatus.Text = "Checking network connectivity"
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            Dim url As String = strSite & "rxcui.json?name=" & drugName & "+" & drugStrength & "+" & drugMeasurement & "+" & drugType & "&search=1"
            'location in json of properties
            Dim trawlPointer As String = "$.idGroup.rxnormId"
            'convert web response to Jtoken
            Dim inputJSON As JToken = GetJSON(url)
            'set Jtoken into array to pull data from json
            Dim trawledResult As JToken = inputJSON.SelectToken(trawlPointer)
            ''set Jtoken into array to pull data from json
            Dim JsonJArray As JArray = DirectCast(trawledResult, JArray)
            ' convert value from jarray to a jvalue to store the rxcui
            jValueObj = DirectCast(JsonJArray.First, JValue)
            'return the rxcui 
            Return jValueObj.Value
        Else
            Return jValueObj.Value
        End If
    End Function


    '/*********************************************************************/
    '/*                   FUNCTION NAME:  TrawlJSON                       */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/8/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This Function takes the json form and what properties we want     */
    '/* pulled and returns the token                                      */
    '/*********************************************************************/
    '/*  CALLED BY:                                                       */
    '/* getDrugRXCUI                                                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*            (NOTHING)								              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*   TrawlJSON(jsonResult, myTrawlString)				          */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '/*  Dillen  02/8/21  inital creation                                 */
    '/*                                                                   */  
    '/*                                                                   */
    '/*********************************************************************/
    Public Function TrawlJSON(json As JToken, trawlPointer As String) As JToken
        Return json.SelectToken(trawlPointer)
    End Function


    '/*********************************************************************/
    '/*                   FUNCTION NAME:  getDrugGeneric                  */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/8/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This Function takes the json form and what properties we want     */
    '/* pulled and returns the token                                      */
    '/*********************************************************************/
    '/*  CALLED BY:                                                       */
    '/*                                                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*            (NOTHING)								              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*   	getDrugGeneric("5640")                  			          */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '/*  Dillen  02/10/21  inital creation                                 */
    '/*                                                                   */  
    '/*                                                                   */
    '/*********************************************************************/
    Function getDrugGeneric(drugRxcui As String)
        Dim theJArray As JArray
        ' Insert functionality to check the network connectivity
        frmInventory.txtStatus.Text = "Checking network connectivity"
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            'URL for finding each drug name 
            Dim url As String = strSite & "brands?ingredientids=" & drugRxcui
            'location of the names im looking for
            '"$.brandGroup.conceptProperties[1].name"
            Dim jsonPointer As String = "$.brandGroup.conceptProperties"

            Dim inputJSON As JToken = GetJSON(url)

            theJArray = inputJSON.SelectToken(jsonPointer)

            For Each item In theJArray
                For Each subItem As JProperty In item
                    If subItem.Value = "name" Then
                        Return DirectCast(subItem.Next, JProperty).Value
                    End If

                Next
            Next
            Return theJArray.ToString
        Else
            Return theJArray.ToString
        End If

    End Function

    '/*********************************************************************/
    '/*                   FUNCTION NAME:  getSchedule                     */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/15/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This Function Returns a drugs SCHEDULE, if the api does not have  */
    '/* a SCHEDULE it will return nothing                                 */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:                                                       */
    '/*                                                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*            (NOTHING)								              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*   	'getSchedule(2055307)                  			              */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '<<<<<<< HEAD
    '/*  Dillen  02/15/21  inital creation                                 */
    '/*                                                                   */  
    '/*                                                                   */
    '=======
    '/*  Dillen  02/4/21  inital creation                                 */
    '/*  NP      02/9/2021 Added a return that returns the result to      */
    '/*                    remove the function has no return warning.     */
    '>>>>>>> main
    '/*********************************************************************/
    Function getSchedule(rxcuiID As String) As String
        ' Insert functionality to check the network connectivity
        frmInventory.txtStatus.Text = "Checking network connectivity"
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            'api location
            Dim url As String = strSite & "rxcui/" & rxcuiID & "/allProperties.json?prop=all"
            'This is the location where S SCHEDULE should appear in the json file
            Dim trawlPointer As String = "$.propConceptGroup.propConcept"

            'converts the api's json to JToken 
            Dim inputJSON As JToken = GetJSON(url)

            'set the json file to a JArray 
            Dim JsonJArray As JArray = inputJSON.SelectToken(trawlPointer)

            'Looks Though each propConcept in the json file and returns the value of SCHEDULE 
            For Each item In JsonJArray
                For Each subItem As JProperty In item
                    If subItem.Value = "SCHEDULE" Then
                        frmInventory.txtSchedule.Enabled = False
                        Return DirectCast(subItem.Next, JProperty).Value
                    End If
                Next
            Next
            'if nothing is found just return nothing 
            Return Nothing
        Else
            Return Nothing
        End If
    End Function
    '/*********************************************************************/
    '/*                   FUNCTION NAME:  GetJSON                         */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/15/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* The purpose of this function is to get the json output from our   */
    '/* json file and store it as a jtoken                                */
    '/*                                                                   */
    '/*********************************************************************/
    '/*  CALLED BY:                                                       */
    '/*                                                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*            (NOTHING)								              */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*   	'GetJSON(url)               			                      */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*                                                                   */
    '/*  Dillen  02/15/21  inital creation                                 */
    '/*                                                                   */  
    '/*                                                                   */
    '/*********************************************************************/
    Public Function GetJSON(url As String) As JToken
        'web request to pull data 
        Dim restClient As New RestSharp.RestClient(url)
        Dim restRequest As New RestSharp.RestRequest(url)
        'saves the result from request as IRestResponse
        Dim result As IRestResponse = restClient.Get(restRequest)
        'parse the IRestResponse to JToken
        Dim jsonResult As JToken = JToken.Parse(result.Content)
        Return jsonResult

    End Function
    '/*********************************************************************/
    '/*                   FUNCTION NAME:  GetRxcuiByName                  */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/17/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This function is a search for the rxcui number in the RxNorm data */
    '/* Set and only requires a string name for the drug                  */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*   	 Rxcui As String					                          */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*    GetRxcuiByName("advil")				                          */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */
    '/*	 url - holds a link to the api with the selected rxui             */
    '/*  restClient -			                                          */
    '/*  restRequest - 			                                          */
    '/*  result - holds the result of the api call (json format)          */
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*********************************************************************/
    '/*  Dillen  02/17/21  Function to make api call to get               */
    '/*                      drug rxcui by name                           */
    '/*                                                                   */
    '/*********************************************************************/
    Public Function GetRxcuiByName(drugName As String, propertyNames As List(Of String)) As List(Of (PropertyName As String, PropertyValue As String))
        Dim intIndex = 1
        Dim myReturnList As New List(Of (PropertyName As String, PropertyValue As String))
        drugName = drugName.ToLower
        ' Insert functionality to check the network connectivity
        frmInventory.txtStatus.Text = "Checking network connectivity"
        frmProgressBar.UpdateLabel("Checking network connectivity")
        Dim strSite As String = checkConnections() ' insert functionality to return the site string
        If strSite IsNot "ERROR" Then
            Dim url As String = strSite & "drugs?name=" & drugName
            'location of json <rxnormId

            'loop to make sure we've checked all the indexes
            Do
                Dim trawlPointer As String = "$.drugGroup.conceptGroup[" & intIndex & "].conceptProperties"
                'convert web response to Jtoken
                Dim inputJson As JToken = GetJSON(url)
                'contains the conceptProperties returned from jason
                Dim JsonJArray As JArray = inputJson.SelectToken(trawlPointer)
                'List of the returned results from the api 


                If JsonJArray Is Nothing Then
                    ' prepare for looking in the next index
                    intIndex += 1
                Else
                    frmProgressBar.UpdateLabel("Retrieving drug information...")
                    'looks through our JsonJArray for the properties specified 
                    For Each propertyName As String In propertyNames
                        For Each item As JObject In JsonJArray '
                            For Each subItem As JProperty In item.Children
                                If subItem.Name.ToString.ToUpper = "NAME" Then
                                    myReturnList.Add((DirectCast(subItem.Previous, JProperty).Value, subItem.Value))
                                End If
                            Next
                        Next
                    Next
                    ' prepare for looking in the next index
                    intIndex += 1
                End If
            Loop While intIndex < 5 ' arbitrarily picking 5 as we haven't seen one with more than 3 
            Return myReturnList
        Else
            Return myReturnList
        End If
    End Function
    '/*********************************************************************/
    '/*                   FUNCTION NAME: GetSuggestionList                 */
    '/*********************************************************************/
    '/*                   WRITTEN BY:Dillen Perron  		              */
    '/*		         DATE CREATED: 2/25/2021     			              */
    '/*********************************************************************/
    '/*  FUNCTION PURPOSE:								                  */
    '/*											                          */
    '/* This function calls the web api to get a list of suggested names  */
    '/* of drugs from rxnorm api                                          */
    '/*********************************************************************/
    '/*  CALLED BY:   	      						                      */
    '/*                                     				              */
    '/*********************************************************************/
    '/*  CALLS:										                      */
    '/*             (NONE)								                  */
    '/*********************************************************************/
    '/*  PARAMETER LIST (In Parameter Order):					          */
    '/*											                          */
    '/* 			                                                      */
    '/*********************************************************************/
    '/*  RETURNS:								                          */
    '/*   	 Rxcui As String					                          */
    '/*********************************************************************/
    '/* SAMPLE INVOCATION:								                  */
    '/*											                          */
    '/*    GetRxcuiByName("advil")				                          */
    '/*********************************************************************/
    '/*  LOCAL VARIABLE LIST (Alphabetically):			    	          */
    '/*											                          */  
    '/*											                          */
    '/*********************************************************************/
    '/* MODIFICATION HISTORY:						                      */
    '/*											                          */
    '/*  WHO      WHEN     WHAT								              */
    '/*********************************************************************/
    '/*  Dillen  02/25/21  Calls api to return suggested drug name        */
    '/*                                                                   */
    '/*********************************************************************/
    Public Function GetSuggestionList(name As String) As List(Of String)
        Dim result As New List(Of String)
        If name = "" Then
            result.Add("Nothing to Search")
            Return result
        Else
            Dim strValue As String
            name = name.ToLower
            'Location of result from api 
            Dim trawlpointer As String = "$.suggestionGroup.suggestionList.suggestion"
            'web address for api
            ' Insert functionality to check the network connectivity
            frmInventory.txtStatus.Text = "Checking network connectivity"
            frmProgressBar.UpdateLabel("Checking network connectivity")
            Dim strSite As String = checkConnections() ' insert functionality to return the site string
            If strSite IsNot "ERROR" Then
                Dim url As String = strSite & "spellingsuggestions.json?name=" & name
                'Gets json from web api 
                Dim inputJSON As JToken = GetJSON(url)
                'creates a jtoken of the location specified by twalpointer
                Dim trawledResult As JToken = inputJSON.SelectToken(trawlpointer)
                'creates jarray to store values of twaledResult
                Dim jArrayObj As JArray = DirectCast(trawledResult, JArray)
                If IsNothing(jArrayObj) Then
                    frmInventory.txtStatus.Text = "No suggestions found. Please try again."
                    MessageBox.Show("Could not find suggestions. Please try another search.")
                    frmInventory.cboSuggestedNames.Visible = False
                Else
                    ' now get the individual values out from the items and add them to the list
                    For Each item In jArrayObj
                        strValue = item.ToString
                        result.Add(strValue)
                    Next

                    Return result
                End If
            Else
                Return result
            End If
        End If
        Return Nothing
    End Function

End Module