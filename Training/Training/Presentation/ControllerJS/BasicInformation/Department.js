$(document).ready(function () {

    $("#btnAddNew").click(function () {
        $.get('@Url.Content("Create")', null, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        })

    });

    $(".BtnEdit").click(function () {

        var Departmentld = $(this).attr('data-Id');
        $.get('@Url.Content("Edit")', "ID=" + Departmentld, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        });
    });

    $(".BtnDelete").click(function () {
        var Departmentld = $(this).attr('data-Id');
        $.get('@Url.Content("Delete")', "ID=" + Departmentld, function (data) {
            $("#MainModalContent").html(data);
        });
    });

});