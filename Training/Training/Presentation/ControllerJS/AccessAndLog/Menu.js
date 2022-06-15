$(document).ready(function () {

    $("#btnAddNew").click(function () {
        $.get('@Url.Content("Create")', null, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        })

    });

    $(".BtnEdit").click(function () {

        var Menuld = $(this).attr('data-Id');
        $.get('@Url.Content("Edit")', "ID=" + Menuld, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        });
    });

    $(".BtnDelete").click(function () {
        var Menuld = $(this).attr('data-Id');
        $.get('@Url.Content("Delete")', "ID=" + Menuld, function (data) {
            $("#MainModalContent").html(data);
        });
    });

});