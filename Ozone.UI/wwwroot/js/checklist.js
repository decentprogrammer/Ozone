//$("#createChecklistPanelWraper").hide();
//document.getElementById("createChecklistPanelWraper").style.display = "none";

$(document).ready(function () {
    // console.log("Checklist Ready");

    var vendorNamesList = [];

    $(function () {
        $.ajax({
            type: "GET",
            url: "/Manage/Index?handler=AllVendorsNamsList",
            data: {},
            success: function (response) {
                for (var i = 0; i < response.length; i++) {
                    vendorNamesList.push(response[i].vendorName);
                }
            },
            error: function (xhr) {
                //Do Something to handle error
            }
        });
    });

    $(function () {
        $("#vendorName").autocomplete({
            source: vendorNamesList
        });
    });

    $(function () {
        for (var i = 0; i < Buildings.length; i++) {
            let buildingVal = Buildings[i].replace(/\s/g, "");
            $("#elementLocation").append(
                "<option value=" + buildingVal + ">" + Buildings[i] + "</option>"
            );
        }
    });

    $("#createChecklist").click(function () {
        $("#createChecklistPanelWraper").show();
    });

    $("#createCategory").click(function () {
        let formData = $("#wf-form-Category-Form").serialize();

        $.ajax({
            type: "POST",
            url: "/Manage/Index?handler=CreateCategory",
            data: formData,
            success: function (response) {
                document.getElementById("wf-form-Category-Form").reset();

                //var id = 79;
                let userUnitId = $("userUnitId").val();
                let id = userUnitId;

                $.ajax({
                    type: "GET",
                    url: "/Manage/Index?handler=AllUnitCategories",
                    data: { unitId: id },
                    success: function (response) {
                        $("#Categories-Select-2").empty();
                        $("#Categories-Select-2").append(
                            "<option value=" +
                            "" +
                            " disabled selected >" +
                            "Added Categories..." +
                            "</option>"
                        );

                        for (var i = 0; i < response.length; i++) {
                            $("#Categories-Select-2").append(
                                "<option value=" +
                                response[i].id +
                                ">" +
                                response[i].name +
                                "</option>"
                            );
                        }

                        $("#elementCategory").empty();
                        $("#elementCategory").append(
                            "<option value=" +
                            "" +
                            " disabled selected >" +
                            "Added Categories..." +
                            "</option>"
                        );

                        for (var i = 0; i < response.length; i++) {
                            $("#elementCategory").append(
                                "<option value=" +
                                response[i].id +
                                ">" +
                                response[i].name +
                                "</option>"
                            );
                        }
                    },
                    error: function (xhr) {
                        //Do Something to handle error
                        console.log("Category add fail");
                    }
                });
            }
        });
    });

    $(function () {
        //var id = 79;
        let userUnitId = $("#userUnitId").val();
        let id = userUnitId;

        $.ajax({
            type: "GET",
            url: "/Manage/Index?handler=AllUnitCategories",
            data: { unitId: id },
            success: function (response) {
                //$('#Categories-Select-2').empty();
                //$('#Categories-Select-2').append('<option value='+ "" +'>' + "Added Categories..." + '</option>');
                for (var i = 0; i < response.length; i++) {
                    $("#Categories-Select-2").append(
                        "<option value=" +
                        response[i].id +
                        ">" +
                        response[i].name +
                        "</option>"
                    );
                }

                for (var i = 0; i < response.length; i++) {
                    $("#elementCategory").append(
                        "<option value=" +
                        response[i].id +
                        ">" +
                        response[i].name +
                        "</option>"
                    );
                }
            },
            error: function (xhr) {
                //Do Something to handle error
                alert("Error");
            }
        });
    });
});
//////////////
function updateCategoriesList() {
    //var unitId = 79;
    let userUnitId = $("#userUnitId").val();
    let unitId = userUnitId;

    $.ajax({
        type: "GET",
        url: "/Manage/Index?handler=AllUnitCategories&unitId=" + unitId,
        data: data,
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                $("#Categories-Select-2").append(
                    "<option value=" +
                    response[i].id +
                    ">" +
                    response[i].name +
                    "</option>"
                );
            }
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Error");
        }
    });
}

function loadCategory() {
    alert("Load Category");
}

function saveCategory() {
    //alert("Test saved");

    var data = $("#wf-form-Category-Form").serialize();

    $.ajax({
        type: "POST",
        url: "/Manage/Index?handler=CreateCategory",
        data: data,
        success: function (response) {
            alert("Done Update");
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Update");
        }
    });
}

function getSingleCategory(selectObject) {
    var uid = selectObject.value;
    var visible = "";

    $.ajax({
        url: "/Manage/Index?handler=GetSingleCategory",
        type: "GET",
        data: {
            categoryId: uid
        },
        success: function (response) {
            if (response.publicVisible == true) {
                visible = "true";
            } else {
                visible = "false";
            }

            $("#categoryId").val(response.id);
            $("#Category-Name-Textbox").val(response.name);
            $("#Visibility").val(visible);
            $("#Category-Description").val(response.description);

            //$("#editCategoryBtn").prop('disabled', true);
            //$("#deleteCategoryBtn").prop('disabled', true);
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}

function getSingleElement(selectObject) {
    var uid = selectObject.value;
    var visible = "";

    $.ajax({
        url: "/Manage/Index?handler=GetSingleElementById",
        type: "GET",
        data: {
            elementId: uid
        },
        success: function (response) {
            if (response.publicVisible == true) {
                visible = "true";
            } else {
                visible = "false";
            }

            $("#categoryId").val(response.id);
            $("#elementId").val(response.guidId);
            $("#elementNameTextbox").val(response.name);
            let buildingLocation = response.location.replace(/\s/g, "");
            $("#elementLocation").val(buildingLocation);
            $("#elementRoomTextbox").val(response.roomNumber);
            $("#elementVisibility").val(visible);
            $("#elementRank").val(response.elementRank);
            $("#elementDescription").val(response.description);
            $("#vendorName").val(response.vendorName);
            $("#BrandName").val(response.brandName);
            //$("#ElementInstalled").val(formatDate(response.installed));
            //  $("#ElementReplace").val(formatDate(response.replace));

            document.getElementById("ElementInstalled").value = formatDate(
                response.installed
            );
            document.getElementById("ElementReplace").value = formatDate(
                response.replace
            );

            getVendorIdByName(response.vendorName);
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}

function updateCategory() {
    var data = $("#wf-form-Category-Form").serialize();

    $.ajax({
        type: "POST",
        url: "/Manage/Index?handler=UpdateCategory",
        data: data,
        success: function (response) {
            alert("Done Update");
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Update");
        }
    });
}

function updateElement() {
    var data = $("#wf-form-Element-Form").serialize();

    $.ajax({
        type: "POST",
        url: "/Manage/Index?handler=UpdateElement",
        data: data,
        success: function (response) {
            alert("Done Update");
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Update");
        }
    });
}

function formatDate(date) {
    let d = new Date(date),
        month = "" + (d.getMonth() + 1),
        day = "" + d.getDate(),
        year = d.getFullYear();

    if (month.length == 1) {
        month = "0" + month;
    }

    if (day.length == 1) {
        day = "0" + day;
    }

    return [year, month, day].join("-");
}

function deleteCategory() {
    var id = $("#categoryId").val();
    var data = $("#wf-form-Category-Form").serialize();

    $.ajax({
        type: "POST",
        url: "/Manage/Index?handler=DeleteCategory&categoryId=" + id,
        data: data,
        success: function (response) {
            document.getElementById("wf-form-Category-Form").reset();

            //var unitId = 79;
            var unitId = userUnitId;

            $.ajax({
                type: "GEt",
                url: "/Manage/Index?handler=AllUnitCategories&unitId=" + unitId,
                data: data,
                success: function (response) {
                    $("#Categories-Select-2").empty();
                    $("#Categories-Select-2").append(
                        "<option value=" +
                        "" +
                        " disabled selected >" +
                        "Added Categories..." +
                        "</option>"
                    );

                    for (var i = 0; i < response.length; i++) {
                        $("#Categories-Select-2").append(
                            "<option value=" +
                            response[i].id +
                            ">" +
                            response[i].name +
                            "</option>"
                        );
                    }

                    $("#elementCategory").empty();
                    $("#elementCategory").append(
                        "<option value=" +
                        "" +
                        " disabled selected >" +
                        "Select Category..." +
                        "</option>"
                    );
                    for (var i = 0; i < response.length; i++) {
                        $("#elementCategory").append(
                            "<option value=" +
                            response[i].id +
                            ">" +
                            response[i].name +
                            "</option>"
                        );
                    }
                },
                error: function (xhr) {
                    //Do Something to handle error
                    alert("Error");
                }
            });
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Delete");
        }
    });
}

function deleteElement() {
    var id = $("#elementId").val();
    var data = $("#wf-form-Element-Form").serialize();

    $.ajax({
        type: "POST",
        url: "/Manage/Index?handler=DeleteElement&elementId=" + id,
        data: data,
        success: function (response) {
            document.getElementById("wf-form-Element-Form").reset();
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Delete");
        }
    });
}

function saveElement() {
    let vndrNam = $("#vendorName").val();
    //getVendorId(vndrNam);
    let formData = $("#wf-form-Element-Form").serialize();

    $.ajax({
        type: "POST",
        url: "/Manage/Index?handler=CreateElement",
        data: formData,
        success: function (response) {
            document.getElementById("wf-form-Element-Form").reset();
        }
    });
}

function getVendorId(vendorNameTXT) {
    var vName = vendorNameTXT.value;
    $.ajax({
        type: "GET",
        url: "/Manage/Index?handler=GetVendorId",
        data: { vendorName: vName },
        success: function (response) {
            $("#vendorId").val(response);
        }
    });
}

function getVendorIdByName(vendorNameTXT) {
    var vName = vendorNameTXT;
    $.ajax({
        type: "GET",
        url: "/Manage/Index?handler=GetVendorId",
        data: { vendorName: vName },
        success: function (response) {
            $("#vendorId").val(response);
        }
    });
}

function getAddedElementsList(selectObject) {
    let cateId = selectObject.value;

    $.ajax({
        type: "GET",
        url: "/Manage/Index?handler=AllElementsByCategoryId",
        data: { categoryId: cateId },
        success: function (response) {
            $("#elementAdded").empty();
            $("#elementAdded").append(
                "<option value=" +
                "" +
                " disabled selected >" +
                "Added Elements..." +
                "</option>"
            );

            for (var i = 0; i < response.length; i++) {
                $("#elementAdded").append(
                    "<option value=" +
                    response[i].id +
                    ">" +
                    response[i].name +
                    "</option>"
                );
            }
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Error");
        }
    });
}

function openCategoriesModal() {
    //var untId = 79;
    let userUnitId = $("#userUnitId").val();
    let untId = userUnitId;

    $.ajax({
        type: "GET",
        url: "/Manage/Index?handler=AllUnitCategoriesForChecklistModal",
        data: { unitId: untId },
        success: function (response) {
            let togle = false;

            let obj = JSON.stringify(response);
            let checklistString = obj;

            var checklistJSON = JSON.parse(checklistString);
            let categoryTitle = "";
            let cateId = "";
            let accordianContentId = "";
            let expandButtonIcon = "./wf/images/details-white-18dp.svg";

            //$('#categoryItem').remove();
            $("#categoriesComponentsContainer").empty();
            $.each(checklistJSON, function (i, item) {
                categoryTitle = item.name;
                cateId = item.id;
                accordianContentId = categoryTitle.replace(/\s/g, "");

                $("#categoriesComponentsContainer").append(`
                    <input id="id-${cateId}" type="hidden" value="${categoryTitle}"/>
                    <div class="accordian-item">
                        <div class="accordian-item-trigger">
                            <div class="component-body category-component-body-margin">
                                <div class="category-title-container">
                                    <div class="category-text-block">${categoryTitle}</div>
                                </div>
                                <div onclick="getChecklistElementsByCategoryId(${cateId})" class="category-expand-button">
                                    <div class="text-block">Elements</div><img src="${expandButtonIcon}" alt="" class="expand-icon">
                                </div>
                            </div>
                        </div>
                     <div id="id-${accordianContentId}" class="accordian-content" style="display: none">
                     </div>
                    </div>
                `);

                //let accordianContentToggle = categoryTitle + cateId;
            });
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Error");
        }
    });
}

function openCategoriesFromDashboardModal() {
    //var untId = 79;
    let userUnitId = $("#userUnitId").val();
    let untId = userUnitId;

    //$("#checklist-modal").load("/Dashboard/Index?handler=ChecklistModal");

    $.ajax({
        type: "GET",
        url: "/Manage/Index?handler=AllUnitCategoriesForChecklistModal",
        data: { unitId: untId },
        success: function (response) {
            let togle = false;

            let obj = JSON.stringify(response);
            let checklistString = obj;

            var checklistJSON = JSON.parse(checklistString);
            let categoryTitle = "";
            let cateId = "";
            let accordianContentId = "";
            let expandButtonIcon = "./wf/images/details-white-18dp.svg";

            //$('#categoryItem').remove();
            $("#categoriesComponentsContainer").empty();
            $.each(checklistJSON, function (i, item) {
                categoryTitle = item.name;
                cateId = item.id;
                accordianContentId = categoryTitle.replace(/\s/g, "");

                $("#categoriesComponentsContainer").append(`
                    <input id="id-${cateId}" type="hidden" value="${categoryTitle}"/>
                    <div class="accordian-item">
                        <div class="accordian-item-trigger">
                            <div class="component-body category-component-body-margin">
                                <div class="category-title-container">
                                    <div class="category-text-block">${categoryTitle}</div>
                                </div>
                                <div onclick="getChecklistElementsByCategoryId(${cateId})" class="category-expand-button">
                                    <div class="text-block">Elements</div><img src="${expandButtonIcon}" alt="" class="expand-icon">
                                </div>
                            </div>
                        </div>
                     <div id="id-${accordianContentId}" class="accordian-content" style="display: none">
                     </div>
                    </div>
                `);

                //let accordianContentToggle = categoryTitle + cateId;
            });
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Error");
        }
    });
}

//var togglesComponent = {};

//var getProperty = function (propertyName) {
//    return togglesComponent[propertyName];
//};

function getChecklistElementsByCategoryId(categoryID) {
    let ele = "#id-" + categoryID;

    let accordianContentId = "#id-" + $(ele).val();
    accordianContentId = accordianContentId.replace(/\s/g, "");

    $.ajax({
        type: "GET",
        url: "/Manage/Index?handler=AllElementsByCategoryId",
        data: { categoryId: categoryID },
        success: function (response) {
            let obj = JSON.stringify(response);
            let checklistString = obj;

            let checklistJSON = JSON.parse(checklistString);
            let elementTitle = "";
            let elementId = "";
            let elementLocation = "";

            $(accordianContentId).empty();

            $.each(checklistJSON, function (i, item) {
                elementTitle = item.name;
                elementId = item.guidId;
                //elementId = item.id;
                elementLocation = item.location;

                $(accordianContentId).append(`
                    <input id="id-${elementId}" type="hidden" value="${elementId}"/>
                    <div id="elementComponent" class="element-component-body element-component-body-margin">
                        <div class="element-category-title-container">
                            <div id="elementCompTitle" class="element-title">${elementTitle}</div>
                            <div id="elementCompLocation" class="element-location">${elementLocation}</div>
                        </div>
                        <div class="element-buttons-wraper">
                            <div onclick="getElementDetails('${elementId}')" class="element-expand-button">
                                 <div class="text-block">Details</div>
                            </div>
                        </div>
                    </div>
                `);
                //console.log(accordianContentId + " " + elementTitle); data-w-id="1075fbc2-4c90-ef1d-fdb1-ba98d9e993c4"
            });

            $(accordianContentId).slideToggle();
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Error");
        }
    });
}

//function hideModal() {
//    $("#ozoneChecklistModal")
//        .fadeOut()
//        .hide();
//}

//let accordianContentToggle = $(ele).val() + categoryID;

//let toggle = getProperty(accordianContentToggle);

//if (toggle == undefined) {
//    togglesComponent[accordianContentToggle] = true;
//    toggle = true;
//    //$(accordianContent).toggle("slow");
//}

//console.log(toggle + " Outside");

//for (let key in togglesComponent) {
//    console.log(key, togglesComponent[key]);
//}

//if (toggle == true) {
//    togglesComponent[accordianContentToggle] = false;
//    console.log(toggle + " inside");
//    $(accordianContent).toggle("slow");

//    return;
//} else {
//    togglesComponent[accordianContentToggle] = true;
//    console.log(toggle + " inside");
//    $(accordianContent).toggle("slow");
//}

//    $("#openChecklistModal").click(function () {
//        var untId = 79;
//        $.ajax({
//            type: "GET",
//            url: "/Manage/Index?handler=AllUnitCategoriesAndSubElements",
//            data: { unitId: untId },
//            success: function (response) {
//                var obj = JSON.stringify(response);
//                //var checklistString = '[{"categoryId":2,"categoryName":"systems","checklistElementsList":[{"id":1,"helpId":"744d6653-1dad-4fd6-af45-0e57ee8ea02e","name":"Element 1","location":"Terminal","roomNumber":"R 5","description":"Desc","status":false,"processStatus":"None","publicVisible":true,"elementRank":"2","checklistElementDetailsModel":null,"cartegoryId":2,"checklistCategoryModel":null},{"id":2,"helpId":"848889f6-919e-4ee0-88d8-a8b5aaffb598","name":"Element 2","location":"Terminal","roomNumber":"R55","description":"mxmxm","status":false,"processStatus":"None","publicVisible":true,"elementRank":"2","checklistElementDetailsModel":null,"cartegoryId":2,"checklistCategoryModel":null},{"id":3,"helpId":"d8c8920d-5bab-4a0f-8129-d7af68574a95","name":"Element 3","location":"Terminal","roomNumber":"232","description":"desc","status":false,"processStatus":"None","publicVisible":true,"elementRank":"1","checklistElementDetailsModel":null,"cartegoryId":2,"checklistCategoryModel":null}]}]'
//                var checklistString = obj;
//                var checklistJSON = JSON.parse(checklistString);
//                var result = '';
//                var elem = '';
//                let categoryTitle = '';
//                let elementTitle = '';
//                let elementLocation = '';
//                let expandButtonIcon = './wf/images/details-white-18dp.svg';
//                let appendElementcompContainer = false;
//                //$('#test').empty();
//                //$('#categoriesComponentsContainer').empty();
//                //$('#elementsComponentsContainer').empty();
//                //$('#categoryComponent').remove();
//                $('#categoryItem').remove();
//                $.each(checklistJSON, function (i, item) {
//                    categoryTitle = item.categoryName;
//                    $('#categoriesComponentsContainer').append(`
//<div id="categoryItem${i}" class="accordian-item">
//                        <div class="accordian-item-trigger">
//                            <div class="component-body category-component-body-margin">
//                                <div id="categoryCompTitle${i}" class="category-title-container">
//                                    <div class="category-text-block">${categoryTitle}</div>
//                                </div>
//                                <div class="category-expand-button">
//                                    <div  class="text-block">Elements</div>
//                                    <img src="${expandButtonIcon}" alt="" class="expand-icon">
//                                </div>
//                            </div>
//                        </div>
//<div id="elementsComponentsContainer" class="accordian-content">
//</div>
//</div>
//                `);
//                    //alert("cate " + categoryTitle + " " + i);
//                    //result = '';
//                    $.each(item.checklistElementsList, function (d, it) {
//                        elementTitle = it.name;
//                        elementLocation = it.location;
//                        //if (appendElementcompContainer == false) {
//                        //    $('#categoriesComponentsContainer').append('<div id="elementsComponentsContainer" class="accordian-content">');
//                        //    appendElementcompContainer = true
//                        //    alert('#categoriesComponentsContainer added')
//                        //}
//                        $('#elementsComponentsContainer').append(`
//                            <div class="element-component-body element-component-body-margin">
//                                <div class="element-category-title-container">
//                                    <div id="elementCompTitle${d}" class="element-title">${elementTitle}</div>
//                                    <div id="elementCompLocation${d}" class="element-location">${elementLocation}</div>
//                                </div>
//                                <div class="element-buttons-wraper">
//                                    <div data-w-id="1075fbc2-4c90-ef1d-fdb1-ba98d9e993c4" class="element-expand-button">
//                                        <div class="text-block">Details</div>
//                                    </div>
//                                </div>
//                            </div>
//                `);
//                        //alert("element " + elementTitle + " " + d);
//                    });
//                    //elem = '';
//                });
//                console.log(obj);
//                //for (var i = 0; i < response.length; i++) {
//                //    $('#elementAdded').append('<option value=' + i + '>' + response[i].name + '</option>');
//                //}
//            },
//            error: function (xhr) {
//                //Do Something to handle error
//                alert("Error");
//            }
//        });
//    });

//$("#openModalButton").mouseenter(function () {
//    var a = $('#mainHtml').data('wf-page');

//    $('#mainHtml').attr('data-wf-page', "5ee518a8f5724b81ff269b52");
//});

//$("#openModalButton").mouseleave(function () {
//    var a = $('#mainHtml').data('wf-page');
//    $('#mainHtml').attr('data-wf-page', "5ee518a8f5724be5eb269b6a");
//});
