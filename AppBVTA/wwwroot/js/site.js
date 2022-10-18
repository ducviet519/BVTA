// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$.fn.clearData = function ($form) {
    $form.find('input:text, input:password, input:file, select, textarea').val('');
    $form.find('input:radio, input:checkbox')
        .removeAttr('checked').removeAttr('selected');
}

$.fn.callModal = function (url) {
    var ReportPopupElement = $('#partialContainer');
    $("body").find(".modal-backdrop").remove();
    $.ajax({
        url: url,
        dataType: 'html',
        success: function (data) {
            ReportPopupElement.html(data);
            ReportPopupElement.find('.modal').modal('show');
        }, error: function (xhr, status) {
            switch (status) {
                case 404:
                    $(this).callToast("error", 'Thông báo', 'File not found');
                    break;
                case 500:
                    $(this).callToast("error", 'Thông báo', 'Server error');
                    break;
                case 0:
                    $(this).callToast("error", 'Thông báo', 'Request aborted');
                    break;
                default:
                    $(this).callToast("error", 'Thông báo', 'Unknown error ' + status);
            }
        }
    });
}

$.fn.callDataTable = function (lang, disableColumn) {
    var array = [];
    $.each(disableColumn.split(','), function (idx, val) {
        array.push(parseInt(val));
    });

    var setVal = 'en';
    if (lang == 'vi') setVal = 'Vietnamese';
    if (disableColumn == '') { disableColumn = 0; }

    $(this).DataTable({
        "bPaginate": true,
        "pageLength": 30,
        "responsive": false,
        "searching": true,
        "info": false,
        "bLengthChange": false,
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/" + setVal + ".json" },
        "order": [],
        "columnDefs": [{ orderable: false, targets: array }]
    });
}

$.fn.callToast = function (status, head, message) {
    if (status == "success") {
        $.toast({
            heading: head,
            text: message,
            showHideTransition: 'fade',
            icon: 'success',
            position: 'top-center',
            hideAfter: 5000,
            afterHidden: function () {
                $(".jq-toast-wrap").remove();
            },
            stack: false
        })
    } else if (status == "warning") {
        $.toast({
            heading: head,
            text: message,
            showHideTransition: 'fade',
            icon: 'warning',
            position: 'top-center',
            hideAfter: 5000,
            afterHidden: function () {
                $(".jq-toast-wrap").remove();
            }, stack: false
        })
    } else {
        $.toast({
            heading: head,
            text: message,
            showHideTransition: 'fade',
            icon: 'error',
            position: 'top-center',
            hideAfter: 5000,
            afterHidden: function () {
                $(".jq-toast-wrap").remove();
            }, stack: false
        })
    }
}
