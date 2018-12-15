$(document).ready(function () {
   //Add buttons for Save Cut Delete in 1st load of the AdminPage
    var scanedId = $('#select .active').attr("id");
            //Call the function
            AddButtonGroup(scanedId);

    //After changing selected punkt of List program 1) Will delete created buttonGroup
    //                                              2) Get current Id of selected punkt of List
    //                                              3) Add buttonGroup with new Id, which we took in 2dh punkt
    $(document).on('click', '#board1', function () {
        $('div .scd').remove();
       var scanedId= $('#select .active').attr("id");
       AddButtonGroup(scanedId);
    })
 
    //Function for inserting buttonGroup
    function AddButtonGroup(scanedId){
        $('#' + scanedId + ' div:last').after("<div class='btn-group scd' role='group' aria-label='Basic example'>" +
                                "<button id='save_" + scanedId + "' title='сохранить новую или измененную запись' type='button' class='btn btn-dark'><i class='fas fa-save'></i></button>" +
                                "<button id='delete_" + scanedId + "' title='удалить выбранную запись из БД' type='button' class='btn btn-dark'><i class='fas fa-trash-alt'></i></button>" +
                                "<button id='cut_" + scanedId + "' title='пометить выбранную запись как 'не используемая'' type='button' class='btn btn-dark'><i class='fas fa-cut'></i></button>" +
                         "</div>");
    };
});