//Global variables
var scanedId;
var createdId;

$(document).ready(function () {
     //Add buttons for Save Cut Delete in 1st load of the AdminPage
    scanedId = $('#select .active').attr("id");            
    AddButtonGroup(scanedId);
    CreateIdForDropDownList(scanedId);
    DisablUndisableButtonsCutDel(scanedId, createdId);
    

    //After changing selected punkt of List program 1) Will delete created buttonGroup
    //                                              2) Get current Id of selected punkt of List
    //                                              3) Add buttonGroup with new Id, which we took in 2dh punkt
    $(document).on('click', '#board1', function () {
        scanedId = $('#select .active').attr("id");
        CreateIdForDropDownList(scanedId);
        //Return to start position DropDownList #dropDownAllColours in Цвет
        $('#' + createdId).val("");

        // THIS PART SHOULD BE CHANGED ON THE FUNCTION
        $('#colorName').val("");

       $('div .scd').remove();       
        //Add buttons save/delete/cut
       AddButtonGroup(scanedId);
        //Some buttons should be desabled
       DisablUndisableButtonsCutDel(scanedId,createdId)
       
    })     

//------------------------------------------------------------- USING FUNCTION ----------------------------------------------------------------

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

            // THIS PART SHOULD BE CHANGED ON THE FUNCTION
            //Filling all text inputs 
            if (selectId == "")
                $('#colorName').val("");
            else
                $('#colorName').val(selectText);
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
    };
});