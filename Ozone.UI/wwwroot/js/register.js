$(document).ready(function () {
    $(function () {
        let data = "";

        $.ajax({
            type: "get",
            url: "/generalhandlers/general?handler=getallunitcategories",
            data: data,
            success: function (response) {
                $("#form-organization-name").empty();

                $("#form-organization-name").append(
                    "<option value=" +
                    "" +
                    " disabled selected >" +
                    "Select Organization" +
                    "</option>"
                );

                for (var i = 0; i < response.length; i++) {
                    $("#form-organization-name").append(
                        "<option value=" +
                        response[i].id +
                        ">" +
                        response[i].categoryName +
                        "</option>"
                    );
                }
            },
            error: function (xhr) {
                //do something to handle error
                alert("error");
            }
        });
    });

    //$(function () {

    //    let data = '';

    //    $.ajax({

    //        type: "GET",
    //        url: "/GeneralHandlers/General?handler=GetAllUnits",
    //        data: data,
    //        success: function (response) {

    //            $('#form-unit-name').empty();

    //            $('#form-unit-name').append('<option value=' + "" + ' disabled selected >' + "Select Unit Name" + '</option>');

    //            for (var i = 0; i < response.length; i++) {
    //                $('#form-unit-name').append('<option value=' + response[i].id + '>' + response[i].englishName + '</option>');
    //            }

    //            $('#form-unit-name').append('<option value=' + "" + ' >' + "Other..." + '</option>');

    //        },
    //        error: function (xhr) {
    //            //Do Something to handle error
    //            alert("Error");
    //        }

    //    });
    //});
});

function displayOrganizationCategories(selectObject) {
    let category = selectObject.options[selectObject.selectedIndex].text;

    let selectedOrgzCategoryId = $("#form-organization-name").val();

    //Management
    if (selectedOrgzCategoryId == 1) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();

        $("#form-unit-name").show();
        getAllUnitsByCategoryNameAndFillUnitSelect(category);
    }

    //Sector
    if (selectedOrgzCategoryId == 2) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();

        $("#form-unit-name").show();
        getAllUnitsByCategoryNameAndFillUnitSelect(category);
    }

    //Department
    if (selectedOrgzCategoryId == 3) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();

        $("#form-sector-name").show();
        getAndFillAllParentsByName("Sector");

        $("#form-unit-name").show();
    }

    //Superintendence
    if (selectedOrgzCategoryId == 4) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();

        $("#form-sector-name").show();
        getAndFillAllParentsByName("Sector");

        $("#form-department-name").show();
        getAndFillAllParentsByName("Department");

        $("#form-unit-name").show();
    }

    //Section
    if (selectedOrgzCategoryId == 5) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();

        $("#form-sector-name").show();
        getAndFillAllParentsByName("Sector");

        $("#form-department-name").show();
        getAndFillAllParentsByName("Department");

        $("#form-superintendence-name").show();
        getAndFillAllParentsByName("Superintendence");

        $("#form-unit-name").show();
    }

    //Workteam
    if (selectedOrgzCategoryId == 6) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();
        getAllUnitsByCategoryNameAndFillUnitSelect(category);
        $("#form-unit-name").show();
    }

    //Committee
    if (selectedOrgzCategoryId == 7) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();
        getAllUnitsByCategoryNameAndFillUnitSelect(category);
        $("#form-unit-name").show();
    }

    //Airline
    if (selectedOrgzCategoryId == 8) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();
        getAllUnitsByCategoryNameAndFillUnitSelect(category);
        $("#form-unit-name").show();
    }

    //Consultant
    if (selectedOrgzCategoryId == 9) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();
        getAllUnitsByCategoryNameAndFillUnitSelect(category);
        $("#form-unit-name").show();
    }

    //Other
    if (selectedOrgzCategoryId == 1002) {
        $("#form-organization-select").show();
        $("#form-organization-select")
            .children()
            .hide();
        getAllUnitsByCategoryNameAndFillUnitSelect(category);
        $("#form-unit-name").show();
    }

    //if (slct == "1") {
    //    $("#form-dgca-categories").show();
    //    $("#form-other-categories").hide();
    //}
    //else {
    //    $("#form-dgca-categories").hide();
    //    $("#form-other-categories").show();
    //}
}

function displayDgcaCategories() {
    let slct = $("#form-category-type").val();
    if (slct == "DGCA") {
        $("#form-dgca-categories").show();
        $("#form-other-categories").hide();
    } else {
        $("#form-dgca-categories").hide();
        $("#form-other-categories").show();
    }
}

function getAndFillAllParentsByName(category) {
    let data = "";
    let slct = category;
    $.ajax({
        type: "get",
        url:
            "/generalhandlers/general?handler=GetUnitListByCategoryName&categoryName=" +
            slct,
        data: data,
        success: function (response) {
            categoryLowerCase = category.toLowerCase();

            $("#form-" + categoryLowerCase + "-select").empty();
            $("#form-" + categoryLowerCase + "-select").append(
                "<option value=" +
                "" +
                " disabled selected >" +
                "Select " +
                category +
                " Name" +
                "</option>"
            );

            for (var i = 0; i < response.length; i++) {
                $("#form-" + categoryLowerCase + "-select").append(
                    "<optgroup label=" +
                    response[i].arabicName +
                    "><option value=" +
                    response[i].id +
                    ">" +
                    response[i].englishName +
                    "</option></optgroup>"
                );
            }
        },
        error: function (xhr) {
            //do something to handle error
            alert("error");
        }
    });
}

function getAllUnitsByCategoryNameAndFillUnitSelect(category) {
    let data = "";
    let slct = category;
    $.ajax({
        type: "get",
        url:
            "/generalhandlers/general?handler=GetUnitListByCategoryName&categoryName=" +
            slct,
        data: data,
        success: function (response) {
            categoryLowerCase = category.toLowerCase();

            $("#form-unit-select").empty();
            $("#form-unit-select").append(
                "<option value=" +
                "" +
                " disabled selected >" +
                "Select " +
                category +
                " Name" +
                "</option>"
            );

            for (var i = 0; i < response.length; i++) {
                $("#form-unit-select").append(
                    "<optgroup label=" +
                    response[i].arabicName +
                    "><option value=" +
                    response[i].id +
                    ">" +
                    response[i].englishName +
                    "</option></optgroup>"
                );
            }
        },
        error: function (xhr) {
            //do something to handle error
            alert("error");
        }
    });
}

function getAllUnitsByParentName(selectObject) {
    let data = "";
    let parent = selectObject.options[selectObject.selectedIndex].text;
    let callerId = selectObject.id;

    $.ajax({
        type: "get",
        url:
            "/generalhandlers/general?handler=GetUnitListByParentName&parentName=" +
            parent,
        data: data,
        success: function (response) {
            parentLowerCase = parent.toLowerCase();

            if (callerId == "form-sector-select") {
                $("#form-unit-select").empty();
                $("#form-unit-select").append(
                    "<option value=" +
                    "" +
                    " disabled selected >" +
                    "Select Department Unit" +
                    "</option>"
                );

                for (var i = 0; i < response.length; i++) {
                    $("#form-unit-select").append(
                        "<optgroup label=" +
                        response[i].arabicName +
                        "><option value=" +
                        response[i].id +
                        ">" +
                        response[i].englishName +
                        "</option></optgroup>"
                    );
                }
            }

            if (callerId == "form-department-select") {
                let OrgzCategoryId = $("#form-organization-name").val();
                // Selected Category Section

                if (OrgzCategoryId == 5) {
                    $("#form-superintendence-select").empty();
                    $("#form-superintendence-select").append(
                        "<option value=" +
                        "" +
                        " disabled selected >" +
                        "Select Superintendence Unit" +
                        "</option>"
                    );

                    for (var i = 0; i < response.length; i++) {
                        $("#form-superintendence-select").append(
                            "<optgroup label=" +
                            response[i].arabicName +
                            "><option value=" +
                            response[i].id +
                            ">" +
                            response[i].englishName +
                            "</option></optgroup>"
                        );
                    }
                }

                // Selected Category Superintendence
                if (OrgzCategoryId == 4) {
                    $("#form-unit-select").empty();
                    $("#form-unit-select").append(
                        "<option value=" +
                        "" +
                        " disabled selected >" +
                        "Select Superintendence Unit" +
                        "</option>"
                    );

                    for (var i = 0; i < response.length; i++) {
                        $("#form-unit-select").append(
                            "<optgroup label=" +
                            response[i].arabicName +
                            "><option value=" +
                            response[i].id +
                            ">" +
                            response[i].englishName +
                            "</option></optgroup>"
                        );
                    }
                }
            }

            if (callerId == "form-superintendence-select") {
                $("#form-unit-select").empty();
                $("#form-unit-select").append(
                    "<option value=" +
                    "" +
                    " disabled selected >" +
                    "Select Section Unit" +
                    "</option>"
                );

                for (var i = 0; i < response.length; i++) {
                    $("#form-unit-select").append(
                        "<optgroup label=" +
                        response[i].arabicName +
                        "><option value=" +
                        response[i].id +
                        ">" +
                        response[i].englishName +
                        "</option></optgroup>"
                    );
                }
            }

            $("#form-role-name").show();
            $("#form-active-name").show();
            $("#form-auth-name").show();
        },
        error: function (xhr) {
            //do something to handle error
            alert("error");
        }
    });
}

function getAddedElementsList() {
    let data = "";

    $.ajax({
        type: "GET",
        url: "/GeneralHandlers/General?handler=GetAllUnitCategories",
        data: data,
        success: function (response) {
            $("#form-organization-name").empty();
            $("#form-organization-name").append(
                "<option value=" +
                "" +
                " disabled selected >" +
                "Select Organization" +
                "</option>"
            );

            for (var i = 0; i < response.length; i++) {
                $("#form-organization-name").append(
                    "<optgroup label=" +
                    response[i].arabicName +
                    "><option value=" +
                    response[i].id +
                    ">" +
                    response[i].categoryName +
                    "</option></optgroup>"
                );
            }
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Error");
        }
    });
}

//function getAllUnitsByParentName(selectObject) {
//    let data = '';
//    let parent = selectObject.options[selectObject.selectedIndex].text;
//    let callerId = selectObject.id;

//    $.ajax({

//        type: "get",
//        url: "/generalhandlers/general?handler=GetUnitListByParentName&parentName=" + parent,
//        data: data,
//        success: function (response) {

//            parentLowerCase = parent.toLowerCase();

//            if (callerId == 'form-sector-select') {
//                $('#form-department-select').empty();
//                $('#form-department-select').append('<option value=' + "" + ' disabled selected >' + 'Select Department Name' + '</option>');

//                for (var i = 0; i < response.length; i++) {
//                    $('#form-department-select').append('<option value=' + response[i].id + '>' + response[i].englishName + '</option>');
//                }
//            }

//            if (callerId == 'form-department-select') {
//                $('#form-superintendence-select').empty();
//                $('#form-superintendence-select').append('<option value=' + "" + ' disabled selected >' + 'Select Superintendence Name' + '</option>');

//                for (var i = 0; i < response.length; i++) {
//                    $('#form-superintendence-select').append('<option value=' + response[i].id + '>' + response[i].englishName + '</option>');
//                }
//            }

//            if (callerId == 'form-superintendence-select') {
//                $('#form-section-select').empty();
//                $('#form-section-select').append('<option value=' + "" + ' disabled selected >' + 'Select Section Name' + '</option>');

//                for (var i = 0; i < response.length; i++) {
//                    $('#form-section-select').append('<option value=' + response[i].id + '>' + response[i].englishName + '</option>');
//                }
//            }

//            $("#form-role-name").show();
//            $("#form-active-name").show();
//            $("#form-auth-name").show();

//        },
//        error: function (xhr) {
//            //do something to handle error
//            alert("error");
//        }

//    });
//}
