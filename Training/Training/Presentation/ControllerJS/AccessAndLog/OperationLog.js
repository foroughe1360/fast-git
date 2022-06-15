$(document).ready(function () {

    $("#btnAddNew").click(function () {
        $.get('@Url.Content("Create")', null, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        })

    });

    $(".BtnEdit").click(function () {

        var OperationLogld = $(this).attr('data-Id');
        $.get('@Url.Content("Edit")', "ID=" + OperationLogld, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        });
    });

    $(".BtnDelete").click(function () {
        var OperationLogld = $(this).attr('data-Id');
        $.get('@Url.Content("Delete")', "ID=" + OperationLogld, function (data) {
            $("#MainModalContent").html(data);
        });
    });

});