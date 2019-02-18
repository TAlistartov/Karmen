//Global variables
var scanedId;
var createdId;
var coloursDataFromDb;

$(document).ready(function () {

    //Get all colours from Db
    $.ajax({
        type: 'POST',
        url: "Administrator/SendDataToUI",       
        dataType: "json",
        success: function (allColoursFromDb) {
            coloursDataFromDb = allColoursFromDb;
        }
    });

     //Add buttons for Save Cut Delete in 1st load of the AdminPage
    scanedId = $('#select .active').attr("id");            
    AddButtonGroup(scanedId);
    CreateIdForDropDownList(scanedId);
    DisablUndisableButtonsCutDel(scanedId, createdId);
        
    

    //After changing selected punkt of List program 1) Will delete created buttonGroup
    //                                              2) Get current Id of selected punkt of List
    //                                              3) Add buttonGroup with new Id, which we took in 2dh punkt
    $(document).on('click', '#board1', function () {
        //Clear all fields
        ClearAllFields()

        //Get id of selected navigation punkt
        scanedId = $('#select .active').attr("id");
        CreateIdForDropDownList(scanedId);

        //Add DDL in current div, if it has class=ddl_Colours
        if ($('#' + scanedId).hasClass('ddl_Colours'))
        {
           //Delete div if it was added already
            if ($('#' + scanedId).has(scanedId + "_div_with_DDL"))
                $("#" + scanedId + "_div_with_DDL").remove();

           //Search place for insirting div .form-inline and <label> and <select>-->DDL
            var place = $("div .form-inline").has("#" + createdId);
                //Add div with label and DDL
                $("<div id='"+scanedId+"_div_with_DDL' class='form-inline'>"+
                     "<label for='" + scanedId + "_IdColour'>Выбор цвета:</label>" +
                  "</div>").insertAfter($(place));

            //Creating variables for function CreateNewDDL
                var idNameCreatedDDL = scanedId + "_IdColour";
                var firstEmptyOptionDDL = "-Выбирите цвет-";
                var cssClassForCreatedDDL = "SelectColourDDL";
                var placeForInsertingDDL=scanedId + "_div_with_DDL"; //id of parent div
           //Call function for creating and insirting DropDownList with all colours from Db
                CreateNewDDL(coloursDataFromDb, idNameCreatedDDL, firstEmptyOptionDDL, cssClassForCreatedDDL, placeForInsertingDDL);
        }

        //Return to start position DropDownList #dropDownAllColours in Цвет
        $('#' + createdId).val("");

        $('div .scd').remove();
        //Add buttons save/delete/cut
       AddButtonGroup(scanedId);
        //Some buttons should be desabled
       DisablUndisableButtonsCutDel(scanedId, createdId)


        //-------------------------------------------------------****************************************------------------------------------------------------

       

        //-------------------------------------------------------****************************************------------------------------------------------------
       
    })     

   

    //------------------------------------------------------------- USING FUNCTION ----------------------------------------------------------------

    //Clear all user fields (select,input etc.)
    function ClearAllFields() {
        $('select').val("");
        $('input').val("");
        $('textarea').val("");
        $('input:checkbox').prop("checked", false);
    }

    //Create DropDownList using jQuery
    function CreateNewDDL(SelectListItem,IdName,FirstOption,CssClass,placeForInserting){
        if(placeForInserting!=null)
        {
            var DDList = $("<select><option value>" + FirstOption + "</option></select>").attr({ "Id": IdName, "class": "dropdown-toggle form-control mb-2 mr-sm-2 " + CssClass });
            $.each(SelectListItem, function (i, el) {
                $("<option/>", {value:el.Value,html:el.Text}).appendTo(DDList);
            });
           DDList.appendTo($("#" + placeForInserting));
        }
    }

    //Function for creating Id for DropDownList 
    function CreateIdForDropDownList(scanedId) {        
        createdId = scanedId + '_Ddl';
        //Add Id to the first element (in our case DropDownList) of created notes
        $("#" + scanedId + " .dropdown-toggle").filter(':first').attr('id', createdId);

        //Change selected item in DropDownList
        $('#' + createdId).change(function () {
            var selectId = $('#' + createdId).val();
            var selectText = $('#' + createdId + ' :selected').text();
            //Disable or Undisable buttons of actions
            DisablUndisableButtonsCutDel(scanedId, createdId);           

            $.ajax({
                type: 'POST',
                url: "Administrator/FilteringStoreData",
                data: { IdOfSelectedItemDDL: selectId, currentPunctId: scanedId },//IdOfSelectedItemDDL - int; currentPunctId - string
                dataType: "json",
                success: function (necessaryInformation) {
                    // THIS PART SHOULD BE CHANGED ON THE FUNCTION
                    //Filling all text inputs 
                    FillInAllFields(scanedId, necessaryInformation)
                }
            });           
           
        });
    }   

    //Function for disabling some buttons
    function DisablUndisableButtonsCutDel(scanedId, createdId) {
        if ($('#' + createdId).val() == "") {
            $("#delete_" + scanedId).prop("disabled", true);
            //$("#cut_" + scanedId).prop("disabled", true);
        }
        else {
            $("#delete_" + scanedId).prop("disabled", false);
            //$("#cut_" + scanedId).prop("disabled", false);
        }       

    }

    //Function for inserting buttonGroup
    function AddButtonGroup(scanedId) {
        $('#' + scanedId + ' div:last').after("<div class='btn-group scd' role='group' aria-label='Basic example'>" +
                                "<button id='save_" + scanedId + "' title='сохранить новую или измененную запись' type='button' class='btn btn-dark'><i class='fas fa-save'></i></button>" +
                                "<button id='delete_" + scanedId + "' title='удалить выбранную запись из БД' type='button' class='btn btn-dark'><i class='fas fa-trash-alt'></i></button>" +
                                //"<button id='cut_" + scanedId + "' title='пометить выбранную запись как 'не используемая'' type='button' class='btn btn-dark'><i class='fas fa-cut'></i></button>" +
                         "</div>");

        //Дописать Ajax запросі для СОХРАНЕНИЯ И ИЗМЕНЕНИЯ данніх
        //User clicked on save button under form
        $(document).on('click', '#save_' + scanedId, function () {
            var dataForSave = {};
            var parentDiv = "div #" + scanedId;
            //User want to SAVE a new one note to DB (if in the first DDL in form is not selected some value)
            if ($('#' + createdId).val() == "") {
                GetAllFieldsAndDataFromIt(parentDiv, dataForSave);
               
                var jsonData = JSON.stringify(dataForSave);
                //Ajax - SAVE NEW NOTE
                $.ajax({
                    type: 'POST',
                    url: "Administrator/SaveNewNote",
                    //contentType: "application/json; charset=utf-8",
                    data: { jsonData: jsonData, typeOfSaveData: scanedId},
                    traditional:true,
                    dataType: "json",
                    success: function (res) {
                        switch(res)
                        {
                            case 0:
                                alert('Возникла ошибка при сохранении.');
                                break;
                            case 1:
                                alert('Запись успешно сохранена.');
                                //UPDATE PartialView with DropDownList
                                $.ajax({
                                    type: 'GET',
                                    url: "Administrator/Partial_GetAllColours",
                                    success: function (dataFromServer) {
                                        //Update data in DropDownList
                                        $('#' + createdId).html(dataFromServer);
                                        ClearAllFields();
                                    }
                                })
                                break;
                            case 2:
                                alert('Такая запись уже существует.');
                                break;
                        }
                        
                    }
                });
            }
            //User want to CHANGE already created note in DB (if in the first DDL in form is selected some value)
            else {
                GetAllFieldsAndDataFromIt(parentDiv, dataForSave);
            }

        });

        //User clicked on delete button under form
        $(document).on('click', '#delete_' + scanedId, function () {
            var s = 2;
        })
    };

    //Get count of all input gields in selected  list-group #board1 and filling in by information
    function FillInAllFields(idSelectedPunkt, necessaryInformation) {
        //Get all div's with class .form-inline inside div with id=idSelectedPunkt
        var elemInsideMainDiv = $('div #' + idSelectedPunkt).find(".form-inline");
        //Go through the collection
        elemInsideMainDiv.each(function (index, element) {
            //Search input and textarea elements 
            var childElements = $(element).children('input, textarea, select');
            //If length of founded element is >0
            if ($(childElements).length != 0) {
                //Get Id of selected field
                var fullIdName = $(childElements).attr("id");
                //Split Id on Id of list group it's arr[0] and Id which are equal with Key in list necessaryInformation
                var splitedData = fullIdName.split('_', 2);
                //If our Id consist of 2 parts? we took 2dh else we take 1st - for example we take 1st in IdColour - it's DDL with using colours
                var arr = (splitedData.length == 2) ? splitedData[1] : splitedData[0];
                var im = necessaryInformation[0];
                //If we didn't get data from server side after filtering
                if (im == null) {
                    //Call function for clearing all users fields
                    ClearAllFields();
                }
                else
                {
                //Go through Collection and compare collection's Key and separeted Id arr[1]
                    for (key in im)
                    {
                        if (key == arr)
                        {
                            if (typeof im[key] == 'boolean') //if fields are bool
                            {
                                $('#' + fullIdName).prop("checked", im[key]);
                                break;
                            }
                            else // if fields are string
                            {                            
                                $('#' + fullIdName).val(''+im[key]+'');
                                break;                           
                            }

                        }
                    }
               }
            }

        })
    }

    //Get all fields and data from selected parent div 
    function GetAllFieldsAndDataFromIt(parentDiv,readedListOfData)
    {
        //Get all elements in parent DIV
        var filteredDiv = $(parentDiv).find(".form-inline");
        $(filteredDiv).each(function (index, element) {
            //Search input and textarea elements 
            var childElements = $(element).children('input, textarea, select');
            //Get Id of selected field
            var fullIdName = $(childElements).attr("id");
            //Split Id on Id of list group it's arr[0] and Id which are equal with Key in list necessaryInformation
            var splitedData = fullIdName.split('_', 2);
            var currentField = $("#" + fullIdName).val();
            var temp = $("#" + fullIdName);
            //Work with checkboxes
            if (temp[0].type == 'checkbox') {
                readedListOfData[splitedData[1]] = $('#' + fullIdName).is(":checked") ? true : false;
            }
                //Work with other DOM elements
            else {
                if (currentField != "")
                    readedListOfData[splitedData[1]] = $("#" + fullIdName).val();
            }

        })
    }
    
});