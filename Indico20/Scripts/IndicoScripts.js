//refresh given kendo grid
function RefreshKendoGrid(gridId) {
    $('#' +gridId).data('kendoGrid').dataSource.read();
    $('#'+gridId).data('kendoGrid').refresh();
}

//serialize form as Java script object
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

//check a form is valid (using jquery validator)
function isFormValid(formId) {
    var result = true;
    $('#' + formId).validator('validate');
    $('#' + formId + ' .form-group').each(function () {
        if ($(this).hasClass('has-error')) {
            result = false;
            return false;
        }
        return false;
    });
    return result;
}

//put helper for jquery
$.put = function (url, data, callback, type) {

    if ($.isFunction(data)) {
        type = type || callback,
        callback = data,
        data = {}
    }

    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: data,
        contentType: type
    });
}

//delete helper for jquery
$.delete = function (url, data, callback, type) {

    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }

    return $.ajax({
        url: url,
        type: 'DELETE',
        success: callback,
        data: data,
        contentType: type
    });
}

//display notification with given context and type
function displayNotification(content, type) {
    $("#notification").data("kendoNotification").show(content, type);
}

//hides all current notifications
function hideAllNotifications() {
    $("#notification").data("kendoNotification").hide();
}