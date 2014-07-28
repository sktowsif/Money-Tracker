$(document).ready(function () {
    Waves.displayEffect();
    $('.styleSlider').ftext();
    $('.ddl').selectOrDie();
    ajaxCaller("Helper.asmx/GetIncomeTypeList", "{}", BindIncome, FailureCall);
    ajaxCaller("Helper.asmx/GetExpenseTypeList", "{}", BindExpense, FailureCall);
});

// BASIC AJAX CALL METHOD
function ajaxCaller(url, dataToSend, SuccessCallBack, FailureCallBack) {
    $.ajax({
        url: url,
        async: true,
        type: 'POST',
        data: dataToSend,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: SuccessCallBack,
        error: FailureCallBack
    });
}

// BASIC DROPDOWN BINDER METHOD
function BindDropDown(selector, data, dataMember, valueMember) {
    for (var obj in data) {
        $(selector).append("<option value=" + data[obj][valueMember] + ">" + data[obj][dataMember] + "</option>")
    }
    $(selector).selectOrDie("update");
}

// Show failure messages
function FailureCall(xhr, msg, exception) {
    alert(msg);
}

// On success ajax call bind the drop down data
function BindIncome(data) {
    var Type = data.d;
    BindDropDown("#ddlIncCategory", Type, "Name", "Id");
}
function BindExpense(data) {
    var Type = data.d;
    BindDropDown("#ddlExpCategory", Type, "Name", "Id");
}

