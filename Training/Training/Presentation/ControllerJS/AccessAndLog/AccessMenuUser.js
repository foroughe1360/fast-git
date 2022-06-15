$(document).ready(function () {
    $("#btnAddNew").click(function () {
        $.get('@Url.Content("Create")', null, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        })

    });

    $("#EditTeacher").click(function () {

        var TeacharlId = $(this).attr('data-Id');
        $.get('@Url.Content("Edit")', "ID=" + TeacharlId, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        });
    });

    $("#DeleteTeacher").click(function () {
        var Teacharld = $(this).attr('data-Id');
        $.get('@Url.Content("Delete")', "ID=" + Teacharld, function (data) {
            $("#MainModalContent").html(data);
        });
    });
});