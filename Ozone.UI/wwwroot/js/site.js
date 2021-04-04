
$(document).ready(function () {

    
    //$('#dtUnits').DataTable();
    //$('.dataTables_length').addClass('bs-select');

    $('#dtUnits').DataTable();
    $('#dtCourses').DataTable();
    $('#dtTrainees').DataTable();
    $('#dtTrainers').DataTable();
    $('#dtTrainings').DataTable();
    $('#dtUnits_wrapper').find('label').each(function () {
        $(this).parent().append($(this).children());
    });
    $('#dtUnits_wrapper .dataTables_filter').find('input').each(function () {
        const $this = $(this);
        $this.attr("placeholder", "Search");
        $this.removeClass('form-control-sm');
    });
    $('#dtUnits_wrapper .dataTables_length').addClass('d-flex flex-row');
    $('#dtUnits_wrapper .dataTables_filter').addClass('md-form');
    $('#dtUnits_wrapper select').removeClass('custom-select custom-select-sm form-control form-control-sm');
    $('#dtUnits_wrapper select').addClass('mdb-select');
    $('#dtUnits_wrapper .mdb-select').materialSelect();
    $('#dtUnits_wrapper .dataTables_filter').find('label').remove();



    //$(document).ready(function () {
    //$('.mdb-select').materialSelect();
    //});


    $('.mdb-select.validate').materialSelect({
        validate: true
        //,
        //labels: {
        //    validFeedback: 'Correct choice',
        //    invalidFeedback: 'Wrong choice'
        //}
    });

    $('.select-wrapper.md-form.md-outline input.select-dropdown').bind('focus blur', function () {
        $(this).closest('.select-outline').find('label').toggleClass('active');
        $(this).closest('.select-outline').find('.caret').toggleClass('active');
    });

    function validateSelect(e) {
        e.preventDefault();
        $('.needs-validation').addClass('was-validated');
        if ($('.needs-validation select').val() === null) {
            $('.needs-validation').find('.valid-feedback').hide();
            $('.needs-validation').find('.invalid-feedback').show();
            $('.needs-validation').find('.select-dropdown').val('').prop('placeholder', 'select one')
        } else {
            $('.needs-validation').find('.valid-feedback').show();
            $('.needs-validation').find('.invalid-feedback').hide();
        }
    }
    $('.needs-validation select').on('change', e => validateSelect(e))
    $('.needs-validation').on('submit', e => validateSelect(e))


    $(function () {
        'use strict';
        window.addEventListener('load', function () {
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.getElementsByClassName('needs-validation');
            // Loop over them and prevent submission
            var validation = Array.prototype.filter.call(forms, function (form) {
                form.addEventListener('submit', function (event) {
                    if (form.checkValidity() === false) {
                        $('#btnCreateUnit').addClass('animated shake');
                        event.preventDefault();
                        event.stopPropagation();
                    }
                    form.classList.add('was-validated');
                }, false);
            });
        }, false);
    });

    $("#btnCreateUnit").click(function () {

        var data = $("#createUnitForm").serialize();

        $.ajax({

            type: "POST",
            url: "/Units/Index?handler=CreateUnit",
            data: data,
            success: function (response) {

            }

        });

    });


    //$("#createCategory").click(function () {

    //    var data = $("#wf-form-Category-Form").serialize();

    //    $.ajax({
    //        type: "POST",
    //        url: "/Checklists/Index?handler=CreateCategory",
    //        data: data,
    //        success: function (response) {
    //            alert("Done Update");
    //        },
    //        error: function (xhr) {
    //            //Do Something to handle error
    //            alert("Not Done Update");
    //        }

    //    })

    //});

    //$("#btnUpdateUnit").click(function () {

    //    var data = $("#updateUnitModelForm").serialize();
    //    var id = data.unit.id
    //    $.ajax({

    //        type: "POST",
    //        url: "/Units/Index?handler=UpdateUnit&unitId=" + id ,
    //        data: data,
    //        success: function (response) {

              
    //        }

    //    })

    //});


    $("#unitDetails").click(function () {

        var uid = $('#unitId').val();
        $.ajax({
            url: "/Units/Index?handler=Details",
            type: "get",
            data: {
                unitId: uid
            },
            success: function (response) {
                $("#tableDetailsBody").remove();
                $("#tableDetailsBody").append("<tr><td>" + response.arabicName + "</td><td>" + response.englishName + "</td></tr>");
            },
            error: function (xhr) {
                //Do Something to handle error
            }

        })
    });



    //$("#editUnit").click(function () {
    //    $("#modalUpdateUnit").modal();
    //});


    // Material Select Initialization
    //$(document).ready(function () {
    //    //$('.mdb-select').materialSelect();

});



$('.location-autocomplete').mdbAutocomplete({
    data: Buildings
});

$('.location-autocomplete-edit').mdbAutocomplete({
    data: Buildings
});


function openDetails(untid) {

    var uid = untid;
    $.ajax({
        url: "/Units/Index?handler=Details",
        type: "get",
        data: {
            unitId: uid
        },
        success: function (response) {
            $("#tableDetailsBody").empty();
            $("#tableDetailsBody").append("<tr id=" + "tableTrDetails" + "><td>" + "اسم الوحدة" + "</td><td>" + response.arabicName + "</td></tr>");
            $("#tableDetailsBody").append("<tr id=" + "tableTrDetails" + "><td>" + "Name" + "</td><td>" + response.englishName + "</td></tr>");
            $("#unitDesc").remove();
            $("#description-just").append("<p id=" + "unitDesc" + ">" + response.description + "</p>");
        },
        error: function (xhr) {
            //Do Something to handle error
        }

    })
};


function openEditPartial(untid) {

    var uid = untid;

    $.ajax({
        url: "/Units/Index?handler=UpdateUnitDataModel",
        type: "get",
        data: {
            unitId: uid
        },
        success: function (response) {

            $("#editPartial").empty();
            $("#editPartial").append(response)
            $("#modalUpdateUnit").modal("show");
        },
        error: function (xhr) {
            //Do Something to handle error
        }

    })

}



function updateUnit(uId) {

    var data = $("#updateUnitModelForm").serialize();
    var id = uId;
    $.ajax({
        type: "POST",
        url: "/Units/Index?handler=UpdateUnit&unitId=" + id,
        data: data,
        success: function (response) {
            alert("Done Update");
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("Not Done Update");
        }

    })

}


function sendUnitId(id) {
    $("#unitUpdateId").val(id);
}

function saveNewUnit() {

    var name = $('#Category-Name-Textbox').val();
    $.ajax({
        type: "POST",
        url: "/manage?handler=Filter",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: JSON.stringify({
            Name: name,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });
}







