$(document).ready(function () {
    //$("#FailureSelect").multiSelect({
    //    positionMenuWithin: $(".position-menu-within")
});

function showHideSubmitButtons(finalStatus) {
    // let finalStatus = getElementFinalStatus();

    if (finalStatus == false) {
        $("#AddButton").hide();
        $("#UpdateButton").val(Update);
    } else {
        $("#AddButton").hide();
        $("#UpdateButton").hide();
    }
}

function gotoCreateChecklist() {
    location.href = "/Manage/Index";
}

function addChecklistWiget() { }

function showCardsModal() {
    //$("#checklistContainer").remove();
    //$("#ozoneModal").show();
    // $("#modalContent").load("/Dashboard/Index?handler=CardsPartial");
}

function hideOzoneModal() {
    //$("#ozoneModal").hide();
    console.log("test");
}

function getElementDetails(elementId) {
    var uid = elementId;
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

            let cateId = response.cartegoryId;
            getCategoryDetails(cateId);

            let elemtId = response.id;
            getElementDetailDetails(elemtId);

            let vndrId = response.vendorId;
            getVendorModel(vndrId);

            $("#ElementId").val(elementId);

            $("#ActionElementId").val(elementId);

            $("#elementName").text(response.name);
            $("#elementInstalled").text(formatDate(response.installed));
            $("#elementReplace").text(formatDate(response.replace));
            $("#ElementDetails").text(response.description);
            $("#BrandName").val(response.brandName);

            let fs = getElementFinalStatus();

            if (fs === true) {
                $("#AddButton").hide();
                $("#UpdateButton").hide();
            }

            //$("#elementNameTextbox").val(response.name);
            //let buildingLocation = response.location.replace(/\s/g, "");
            //$("#elementLocation").val(buildingLocation);
            //$("#elementRoomTextbox").val(response.roomNumber);
            //$("#elementVisibility").val(visible);
            //$("#elementRank").val(response.elementRank);
            //$("#elementDescription").val(response.description);
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}

function getCategoryDetails(catId) {
    $.ajax({
        url: "/Manage/Index?handler=GetSingleCategory",
        type: "GET",
        data: {
            categoryId: catId
        },
        success: function (response) {
            $("#categoryName").text(response.name);
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}

function getElementDetailDetails(elemId) {
    $.ajax({
        url: "/Manage/Index?handler=ElementDetailsId",
        type: "GET",
        data: {
            elementId: elemId
        },
        success: function (response) {
            let finalStatus = response.finalStatus;

            $("#FinalStatus").val(finalStatus);
            $("#ElementDetailsId").val(response.guidId);

            $("#elementStatus").text(response.status);
            $("#elementLastUpdate").text(formatDate(response.lastMINT));
            $("#elementLastMint").text(formatDate(response.lastMINT));
            $("#elementNexttMint").text(formatDate(response.nextMINT));

            $("#FaultSelect").val(response.faultType);
            $("#FaultOther").val(response.faultOther);
            $("#StartEventDate").val(formatDate(response.startEventDate));
            $("#FaultEndDate").val(formatDate(response.endEventDate));
            $("#FaultStartTime").val(formatTime(response.startEventHour));
            $("#FaultEndTime").val(formatTime(response.endEventHour));
            $("#FaultDescription").val(response.faultDescription);

            $("#ActionSelect").val(response.actionType);
            $("#ActionOther").val(response.actionOther);
            $("#ActionStatusSelect").val(response.status);
            $("#ActionDescription").val(response.responseDescription);
            $("#ActionEmployessSelect").val(response.employeesInvolved);

            showHideSubmitButtons(finalStatus);

            let pplcVis = response.publicVisible;

            if (pplcVis == true) {
                $("#PublicCheckbox").prop("checked", true);
            } else {
                $("#PublicCheckbox").prop("checked", false);
            }
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}

function resetFroms() {
    document.getElementById("FaultForm").reset();
    document.getElementById("ActionForm").reset();
    $("#AddButton").val("Add");
    $("#AddButton").show();
    $("#UpdateButton").hide();
    $("#ElementDetailsId").val("");
}

function getVendorModel(vndrId) {
    $.ajax({
        url:
            "/Dashboard/DashboardHandlers/DashHandlers?handler=GetVendorModelByVendorId",
        type: "GET",
        data: {
            vendorId: vndrId
        },
        success: function (response) {
            $("#Vendor-Name").val(response.vendorName);
            $("#VendorEmail").val(response.email);
            $("#VendorTel").val(response.tel);
            $("#VendorMobile").val(response.mobile);
        },
        error: function (xhr) {
            //Do Something to handle error
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

function formatTime(time) {
    let d = new Date(time);
    let datetext = d.toTimeString();
    let hour = datetext.split(":")[0];
    let mints = datetext.split(":")[1];
    datetext = hour + ":" + mints;

    return datetext;
}

function checkStatusBeforeAddNewFaultActionDetails() {
    if (finalStatus == true) {
    }
}

function closeFualtCase() {
    let status = $("#ActionStatusSelect").val();
    let enventEndDate = $("#FaultEndDate").val();
    let enventEndTime = $("#FaultEndTime").val();
    let dateTimeNow = Date();

    dateTimeNow = dateTimeNow.toString();

    if (status == "Great") {
        document.getElementById("AcceptModal").style.display = "block";

        if (enventEndDate === "") {
            $("#FaultEndDate").val(formatDate(dateTimeNow));
        }
        if (enventEndTime === "") {
            $("#FaultEndTime").val(formatTime(dateTimeNow));
        }

        $("#UpdateButton").val("Close");
    } else {
        $("#FaultEndTime").val("");
        $("#FaultEndDate").val("");
        return;
    }

    if (enventEndDate != "" && enventEndTime != "") {
        $("#ActionStatusSelect").val("Great");
    }

    if (enventEndDate != "" && enventEndTime === "") {
        $("#ActionStatusSelect").val("Great");
        $("#FaultEndTime").val(formatTime(dateTimeNow));
    }

    if (enventEndDate === "" && enventEndTime != "") {
        $("#ActionStatusSelect").val("Great");
        $("#FaultEndDate").val(formatDate(dateTimeNow));
    }
}

function validateFaultForm() {
    let faultType = $("#FaultSelect").val();
    let faultOther = $("#FaultOther").val();
    let startDate = $("#StartEventDate").val();
    let startTime = $("#FaultStartTime").val();
    let faultDesc = $("#FaultDescription").val();
    let publicVisible = $("#PublicCheckbox").val();

    if (faultType == "Other") {
        // if (faultOther !== "" && startDate !== "" && startTime !== "" faultDesc)
    }
}

function getSerializeFormData(addUpdateSwitch) {
    let data;

    let pblcVis = $("#PublicCheckbox").val();

    if (addUpdateSwitch == true) {
        //$("#ElementDetailsId").prop("disabled", true);

        data = $("#FaultForm").serialize();
        data += "&" + $("#ActionForm").serialize();

        data.publicVisible = pblcVis;
        //data.elementId = elmntId;

        //$("#ElementDetailsId").prop("disabled", false);
    } else {
        data = $("#FaultForm").serialize();
        data += "&" + $("#ActionForm").serialize();

        data.publicVisible = pblcVis;
        //data.elementId = elmntId;
    }

    return data;
}

function addElementFaultDetails() {
    let data;

    let finalStatus = getElementFinalStatus();

    data = getSerializeFormData(finalStatus);

    let s = "";
    $.ajax({
        type: "POST",
        url: "/Dashboard/Index?handler=CreateNewElementDetail",
        data: data,
        //headers: {
        //    RequestVerificationToken: $(
        //        'input[name="__RequestVerificationToken"]'
        //    ).val()
        //},
        success: function (response) {
            $("#ElementDetailsId").val(response);
            $("#UpdateButton").val("Update");
            $("#UpdateButton").show();
            $("#AddButton").hide();

            alert("Done Add new Element Details");
            //$("#ElementDetailsId").val(response.id);
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Update");
        }
    });
}

function updateElementFaultDetails() {
    let finalStatus = getElementFinalStatus();
    let data = getSerializeFormData(finalStatus);

    $.ajax({
        type: "POST",
        url: "/Dashboard/Index?handler=UpdateElementDeatil",
        data: data,
        //headers: {
        //    RequestVerificationToken: $(
        //        'input[name="__RequestVerificationToken"]'
        //    ).val()
        //},
        success: function (response) {
            let fs = response;
            if (fs == true) {
                $("#UpdateButton").hide();
            }
            alert("Done Update same element");
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Update");
        }
    });
}

function getElementFinalStatus() {
    elemId = $("#ElementId").val();

    let finalStatus = false;

    $.ajax({
        url: "/Manage/Index?handler=ElementDetailsId",
        type: "GET",
        data: {
            elementId: elemId
        },
        success: function (response) {
            finalStatus = response.finalStatus;
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });

    return finalStatus;
}

var modal = document.getElementById("AcceptModal");

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
};
