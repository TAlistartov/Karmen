﻿//Global variables
var scanedId;
var createdFormId;
var createdId;
var DataFromDb;
var callBack;
var temp;

$(document).ready(function () {   

    GetAllDataFromDbForDDL('SendDataToUI', 'colour');

     //Add buttons for Save Cut Delete in 1st load of the AdminPage
    scanedId = $('#select .active').attr("id");    
    createdFormId = scanedId + 'Form';
    AddButtonGroup(scanedId);
    CreateIdForDropDownList(scanedId);
    DisablUndisableButtonsCutDel(scanedId, createdId);    

    //After changing selected punkt of List program 1) Will delete created buttonGroup
    //                                              2) Get current Id of selected punkt of List
    //                                              3) Add buttonGroup with new Id, which we took in 2dh punkt
    $(document).on('click', '#board1', function () {
        //Clear all fields
        ClearAllFields();

        //Get id of selected navigation punkt
        scanedId = $('#select .active').attr("id");
        createdFormId = scanedId + 'Form';//Form Id
        CreateIdForDropDownList(scanedId);

        //Add DDL in current div, if it has class=ddl_Colours
        if ($('#' + scanedId).hasClass('ddl_Colours'))
        {
            var nameActionMethodInController = 'SendDataToUI'; //Name of action method from Controller (Server Side)
            //Update List of Colours from Db
            GetAllDataFromDbForDDL(nameActionMethodInController, scanedId);
            callBack.done(function () {
                //Delete div if it was added already
                if ($('#' + scanedId).has(scanedId + "_div_with_DDL"))
                    $("#" + scanedId + "_div_with_DDL").remove();

                //Search place for insirting div .form-inline and <label> and <select>-->DDL
                var place = $("div .form-inline").has("#" + createdId);
                //Add div with label and DDL
                $("<div id='" + scanedId + "_div_with_DDL' class='form-inline'>" +
                     "<label for='" + scanedId + "_IdColour'>Выбор цвета:</label>" +
                  "</div>").insertAfter($(place));

                //Creating variables for function CreateNewDDL
                var idNameCreatedDDL = scanedId + "_IdColour";
                var nameDDL = scanedId + "IdColour";
                var firstEmptyOptionDDL = "-Выбирите цвет-";
                var cssClassForCreatedDDL = "SelectColourDDL";
                var placeForInsertingDDL = scanedId + "_div_with_DDL"; //id of parent div
                //Call function for creating and insirting DropDownList with all colours from Db
                CreateNewDDL(DataFromDb[0], idNameCreatedDDL, firstEmptyOptionDDL, cssClassForCreatedDDL, nameDDL, placeForInsertingDDL);
            })          
        }

        //Add DDL in current div, if it has class=ddl_Season
        if ($('#' + scanedId).hasClass('ddl_Season')) {
            var nameActionMethodInController = 'SendDataToUI'; //Name of action method from Controller (Server Side)
            //Update List of Colours from Db
            GetAllDataFromDbForDDL(nameActionMethodInController, scanedId);
            callBack.done(function () {
                //Delete div if it was added already
                if ($('#' + scanedId).has(scanedId + "_Season"))
                    $("#" + scanedId + "_Season").remove();

                //Creating variables for function CreateNewDDL
                var idNameCreatedDDL = scanedId + "_Season";
                var nameDDL = scanedId + "Season";
                var firstEmptyOptionDDL = "-Выбирите сезон-";
                var cssClassForCreatedDDL = "SelectSeasonDDL";
                var placeForInsertingDDL = scanedId + "_div_with_SeasonDDL"; //id of parent div
                //Call function for creating and insirting DropDownList with all colours from Db
                CreateNewDDL(DataFromDb[0], idNameCreatedDDL, firstEmptyOptionDDL, cssClassForCreatedDDL, nameDDL, placeForInsertingDDL);
            });
        }


        //-------------------------------------------------------------------8888888888888------------------------------------------------------------
        //Add DDL in current div, if it has class=ddl_Season
        if ($('#' + scanedId).hasClass('ddl_MaterialOfCovering')) {
            var nameActionMethodInController = 'SendDataToUI'; //Name of action method from Controller (Server Side)
            //Update List of Colours from Db
            GetAllDataFromDbForDDL(nameActionMethodInController, scanedId);
            callBack.done(function () {
                //Delete div if it was added already
                if ($('#' + scanedId).has(scanedId + "_IdMaterilOfCovering"))
                    $("#" + scanedId + "_IdMaterilOfCovering").remove();

                //Creating variables for function CreateNewDDL
                var idNameCreatedDDL = scanedId + "_IdMaterilOfCovering";
                var nameDDL = scanedId + "IdMaterilOfCovering";
                var firstEmptyOptionDDL = "-Материал обтяжки-";
                var cssClassForCreatedDDL = "SelectIdMaterilOfCoveringDDL";
                var placeForInsertingDDL = scanedId + "_div_with_MaterialOfCoveringDDL"; //id of parent div
                //Call function for creating and insirting DropDownList with all colours from Db
                CreateNewDDL(DataFromDb[1], idNameCreatedDDL, firstEmptyOptionDDL, cssClassForCreatedDDL, nameDDL, placeForInsertingDDL);
            });
        }

        //-------------------------------------------------------------------8888888888888------------------------------------------------------------

        //Return to start position DropDownList #dropDownAllColours in Цвет
        $('#' + createdId).val("");

        $('div .scd').remove();
        //Add buttons save/delete/cut
       AddButtonGroup(scanedId);
        //Some buttons should be desabled
       DisablUndisableButtonsCutDel(scanedId, createdId)

    })     

   

    //------------------------------------------------------------- USING FUNCTION ----------------------------------------------------------------

    //Clear all user fields (select,input etc.)
    function ClearAllFields() {
        $('select').val("");
        $('input').val("");
        $('textarea').val("");
        $('input:checkbox').prop("checked", false);
        //Disable or Undisable buttons of actions
        DisablUndisableButtonsCutDel(scanedId, createdId);
    }

    //Create DropDownList using jQuery
    function CreateNewDDL(SelectListItem,IdName,FirstOption,CssClass,NameDDL,placeForInserting){
        if(placeForInserting!=null)
        {
            var DDList = $("<select><option value>" + FirstOption + "</option></select>").attr({ "Id": IdName, "name": NameDDL, "class": "dropdown-toggle form-control mb-2 mr-sm-2 " + CssClass });
            $.each(SelectListItem, function (i, el) {
                $("<option/>", {value:el.Value,html:el.Text}).appendTo(DDList);
            });
           DDList.appendTo($("#" + placeForInserting));
        }
    }

    //Function for creating Id for DropDownList 
    function CreateIdForDropDownList(scanedId) {        
        createdId = scanedId + '_Id';//*********************************************************************<<<<<<<<<<--------------------'_Ddl'
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
                                "<button id='save_" + scanedId + "' title='сохранить новую или измененную запись' type='submit' class='btn btn-dark'><i class='fas fa-save'></i></button>" +
                                "<button id='delete_" + scanedId + "' title='удалить выбранную запись из БД' type='button' class='btn btn-dark'><i class='fas fa-trash-alt'></i></button>" +
                                //"<button id='cut_" + scanedId + "' title='пометить выбранную запись как 'не используемая'' type='button' class='btn btn-dark'><i class='fas fa-cut'></i></button>" +
                         "</div>");            

        //If button save was clecked? system should validate the form
        $("#save_" + scanedId).unbind().click(function () {
            switch (createdFormId) {
                case 'colourForm':
                    $("#" + createdFormId).validate(v_colourForm);
                    break;
                case 'patternForm':
                    $("#" + createdFormId).validate(v_patternForm);
                    break;
                case 'liningForm':
                    $("#" + createdFormId).validate(v_liningForm);
                    break;
                case 'furnitureForm':
                    $("#" + createdFormId).validate(v_furnitureForm);
                    break;
                case 'footbedForm':
                    $("#" + createdFormId).validate(v_footBedForm);
                    break;
                case 'padForm':
                    $("#" + createdFormId).validate(v_padForm);
                    break;
                case 'kindOfBlockForm':
                    $("#" + createdFormId).validate(v_kindOfBlockForm);
                    break;
                case 'materialOfSoleForm':
                    $("#" + createdFormId).validate(v_materialOfSoleForm);
                    break;
                case 'topMaterialForm':
                    $("#" + createdFormId).validate(v_topMaterialForm);
                    break;
                case 'componentForm':
                    $("#" + createdFormId).validate(v_componentForm);
                    break;
            }
        });

        //User clicked on delete button under form
        $(document).on('click', '#delete_' + scanedId, function () {
            //Create Id of the main DDL in PartialView
            var createdId = scanedId + "_Id";
            //Get selected value in this DDL 
            var selectValueInMainDDL = $("#" + createdId).val();
            //Call function for deliting
            DeleteSelectedNote(selectValueInMainDDL, scanedId);            
            callBack.done(function () {
                $.ajax({
                    type: 'GET',
                    url: "Administrator/Partial_GetAll" + temp,
                    success: function (dataFromServer) {
                        //Update data in DropDownList
                        $('#' + createdId).html(dataFromServer);                        
                    }
                })
            });
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
    //Refresh data
    function GetAllDataFromDbForDDL(functionName, scanedId)
    {
        //Get all colours from Db
        callBack=$.ajax({
            type: 'POST',
            url: "Administrator/"+functionName,
            dataType: "json",
            data: { scanedId: scanedId },
            success: function (data) {                
                DataFromDb = data;
            }            
        });
       
    }

    //Ajax - SAVE NEW  OR CHANGE SELECTED NOTE
    function SaveChangeNewData(jsonDataForSave,scanedIdOfSaveData,necessaryAction,handleResult) {
        
        $.ajax({
            type: 'POST',
            url: "Administrator/" + necessaryAction,
            //contentType: "application/json; charset=utf-8",
            data: { jsonData: jsonDataForSave, typeOfSaveData: scanedIdOfSaveData },
            traditional: true,
            dataType: "json",
            success: function (res) {
                //Call Back
                handleResult(res);
            }            
        });
    }
    function DeleteSelectedNote(IdForDeliting, scanedId) {        
        //Ajax DELETE selected Note
        callBack = $.ajax({
            type: 'POST',
            url: "Administrator/DeleteSelectedNote",
            //contentType: "application/json; charset=utf-8",
            data: { idSelectedNote: IdForDeliting, typeOfSaveData: scanedId },
            traditional: true,
            dataType: "json",
            success: function (res) {
                temp = res[0];
                if (res[1] == true) {
                    ClearAllFields();
                    alert("Запись успешно удалена.");
                }
                else
                    alert("Возникла ошибка при удалении.");
            },
            error: function () {
                alert("Возникла ошибка при удалении.");
            }
        });        
    }
    
      
   
    //FORMS VALIDATION    
    //Form for Partial View Colour
    var v_colourForm = {
        rules: {
            color: { required: true, maxlength: 25 }
        },
        messages: {
            color: { required: "Не может быть пустым.", maxlength: "Не более 25 символов." },
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View Pattern
    var v_patternForm = {
        rules: {
            patternCrossReference: { maxlength: 50 },
            patternAdditionalInformation: { maxlength: 100 }
        },
        messages: {
            patternCrossReference: { maxlength: "Не более 50 символов." },
            patternAdditionalInformation: { maxlength: "Не более 100 символов." }
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View Lining
    var v_liningForm = {
        rules: {
            liningName: { required: true,maxlength: 50 },
            liningSeason: { required: true, maxlength: 30 },
            liningCrossReference: { maxlength: 50 },
            liningAdditionalInformation:{ maxlength: 100 }
        },
        messages: {
            liningName: { required: "Не может быть пустым.", maxlength: "Не более 50 символов." },
            liningSeason: { required: "Не может быть пустым.", maxlength: "Не более 30 символов." },
            liningCrossReference: {maxlength: "Не более 50 символов." },
            liningAdditionalInformation: { maxlength: "Не более 100 символов." }
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View Furniture
    var v_furnitureForm = {
        rules: {
            furnitureType: { required: true, maxlength: 30 },
            furnitureCrossReference: { maxlength: 50 },
            furnitureIdColour:{required: true}
        },
        messages: {
            furnitureType: { required: "Не может быть пустым.", maxlength: "Не более 30 символов." },
            furnitureCrossReference: { maxlength: "Не более 50 символов." },
            furnitureIdColour:{required: "Не может быть пустым."}
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View FootBed
    var v_footBedForm = {
        rules: {
            footbedType: { required: true, maxlength: 50 },
            footbedCrossReference: { maxlength: 50 },
            footbedAdditionalInformation: { maxlength: 100 }
        },
        messages: {
            footbedType: { required: "Не может быть пустым.", maxlength:"Не более 50 символов." },
            footbedCrossReference: { maxlength: "Не более 50 символов." },
            footbedAdditionalInformation: { maxlength: "Не более 100 символов."}
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View Pad    
    var v_padForm = {
        rules: {
            padKind: { required: true, maxlength: 50 },
            padPadSize: {
                required: true,
                //name of JS function below
                regex: /(\d{1,3}\.\d{1,2})|(\d{1,3}\.\d{1,2})|(^(?:\d+|\d{1,3}(?:\.\d{3})+)?(?:\.\d+)?$)/ },
            padAdditionalInformation: { maxlength: 100 }
        },
        messages: {
            padKind: { required: "Не может быть пустым.", maxlength: "Не более 50 символов." },
            padPadSize: { required: "Не может быть пустым." },
            padAdditionalInformation: { maxlength: "Не более 100 символов." }
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View kindOfBlock
    var v_kindOfBlockForm = {
        rules: {
            kindOfBlockName: { required: true, maxlength: 50 },
            kindOfBlockCrossReference: { maxlength: 50 },    
            kindOfBlockAdditionalInformation: { maxlength: 100 }
        },
        messages: {
            kindOfBlockName: { required: "Не может быть пустым.", maxlength: "Не более 50 символов." },
            kindOfBlockCrossReference: { maxlength: "Не более 50 символов." },
            padAdditionalInformation: { maxlength: "Не более 100 символов." }
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View materialOfSoleForm
    var v_materialOfSoleForm = {
        rules: {
            materialOfSoleName: { required: true, maxlength: 50 },
            materialOfSoleCrossReference: { maxlength: 50 },
            materialOfSoleIdColour: { required: true }
        },
        messages: {
            materialOfSoleName: { required: "Не может быть пустым.", maxlength: "Не более 50 символов." },
            materialOfSoleCrossReference: { maxlength: "Не более 50 символов." },
            materialOfSoleIdColour: { required: "Не может быть пустым." }
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View topMaterialForm
    var v_topMaterialForm = {
        rules: {
            topMaterialType: { required: true, maxlength: 30 },
            topMaterialCrossReference: { maxlength: 50 },
            materialOfSoleIdColour: { required: true }
        },
        messages: {
            topMaterialType: { required: "Не может быть пустым.", maxlength: "Не более 30 символов." },
            topMaterialCrossReference: { maxlength: "Не более 50 символов." },
            materialOfSoleIdColour: { required: "Не может быть пустым." }
        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };

    //Form for Partial View topMaterialForm
    var v_componentForm = {
        rules: {            
            componentIdColour: { required: true },
            componentTypeOfComponent: { required: true, maxlength: 50 },
            componentCrossReference: { maxlength: 50 },
            componentSize: { required: true, number: true, regexInteger: /(\?<=\s|^)[-+]?\d+(?=\s|$)/ },
            componentHeight: { number: true, regexInteger: /(\?<=\s|^)[-+]?\d+(?=\s|$)/ },
            componentWidth: { number: true, regexInteger: /(\?<=\s|^)[-+]?\d+(?=\s|$)/ },
            componentForm: { maxlength: 30 },
            componentType: { maxlength: 30 },
            componentAdditionalInformation: { maxlength: 100}


        },
        messages: {            
            componentIdColour: { required: "Не может быть пустым." },
            componentTypeOfComponent: { required: "Не может быть пустым.", maxlength: "Не более 50 символов." },
            componentCrossReference: { maxlength: "Не более 50 символов." },
            componentSize: { required: "Не может быть пустым.", number: "Только целые числа." },
            componentHeight: { number: "Только целые числа." },
            componentWidth: { number: "Только целые числа." },
            componentForm: { maxlength: "Не более 30 символов." },
            componentType: { maxlength: "Не более 30 символов." },
            componentAdditionalInformation: { maxlength: "Не более 100 символов." }

        },
        submitHandler: function () {
            submitHandlerForm();
        }
    };
   
    //Add method of Regular expression for Float NUMBER
    $.validator.addMethod('regex', function (value, element, regexp) {        
        var check = false;
        return this.optional(element) || regexp.test(value);
    },
            "Не верный фомат.");

    //Add method of Regular expression for Float NUMBER
    $.validator.addMethod('regexInteger', function (value, element, regexp) {
        var check = false;
        return this.optional(element) || regexp.test(value);
    },
            "Только целые числа.");

    //Save or Change the form After validation
    function submitHandlerForm() {

        var dataForSave = {};
        var parentDiv = "div #" + scanedId;
        //User want to SAVE a new one note to DB (if in the first DDL in form is not selected some value)
        if ($('#' + createdId).val() == "") {
            var necessaryAction = 'SaveNewNote';
            GetAllFieldsAndDataFromIt(parentDiv, dataForSave);

            var jsonData = JSON.stringify(dataForSave);

            //Ajax - SAVE NEW NOTE (With call back)
            SaveChangeNewData(jsonData, scanedId, necessaryAction, function (res) {
                //res - it's an array of object. res[0] - it is result of saving to Db (0-Error, 1-Success, 2- note is already exist
                //    //                               res[1] - Name of Class, using for the correct defining Method's Name in controller (Updating PartialView with DropDownList)
                switch (res[0]) {
                    case 0:
                        alert('Возникла ошибка при сохранении.');
                        break;
                    case 1:
                        alert('Запись успешно сохранена.');
                        //UPDATE PartialView with DropDownList
                        $.ajax({
                            type: 'GET',
                            url: "Administrator/Partial_GetAll" + res[1] + "s",
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

            });

        }
            //User want to CHANGE already created note in DB (if in the first DDL in form is selected some value)
        else {
            var necessaryAction = 'ChangeDataSelectedNote';
            GetAllFieldsAndDataFromIt(parentDiv, dataForSave);
            var jsonData = JSON.stringify(dataForSave);

            //Ajax - SAVE NEW NOTE (With call back)
            SaveChangeNewData(jsonData, scanedId, necessaryAction, function (res) {
                //res - it's an array of object. res[0] - it is result of saving to Db (0-Error, 1-Success, 2- note is already exist
                //                               res[1] - Name of Class, using for the correct defining Method's Name in controller (Updating PartialView with DropDownList)

                switch (res[0]) {
                    case 0:
                        alert('Возникла ошибка при изменении.');
                        break;
                    case 1:
                        alert('Запись успешно изменена.');
                        //UPDATE PartialView with DropDownList
                        $.ajax({
                            type: 'GET',
                            url: "Administrator/Partial_GetAll" + res[1] + "s",
                            success: function (dataFromServer) {
                                //Update data in DropDownList
                                $('#' + createdId).html(dataFromServer);
                                ClearAllFields();
                            }
                        })
                        break;
                }
            });

        }

    }    
    
});




