﻿$(document).ready(function () {

    $("#btnAddNew").click(function () {
        $.get('@Url.Content("Create")', null, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        })

    });

    $(".BtnEdit").click(function () {

        var EmployeeTrainingPassedld = $(this).attr('data-Id');
        $.get('@Url.Content("Edit")', "ID=" + EmployeeTrainingPassedld, function (data) {
            $("#MainModalContent").html(data);
            $("#AddNewModal").modal("show");
        });
    });

    $(".BtnDelete").click(function () {
        var EmployeeTrainingPassedld = $(this).attr('data-Id');
        $.get('@Url.Content("Delete")', "ID=" + EmployeeTrainingPassedld, function (data) {
            $("#MainModalContent").html(data);
        });
    });

});