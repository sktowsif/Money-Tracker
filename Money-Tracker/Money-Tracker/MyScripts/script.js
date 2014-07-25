$(document).ready(function () {
    ajaxCaller("MoneyTracker.aspx/GetAllIncome", "{}", SuccessCall, FailureCall);
    ajaxCaller("MoneyTracker.aspx/GetAllExpense", "{}", SuccessCallExp, FailureCall);
    $("#btnIncome").click(function () {

        insertIncome();

    });

    $("#btnExpense").click(function () {

        insertExpense();

    });
});
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
function FailureCall(xhr, msg, exception) {
    alert(msg);
}
function SuccessCall(data) {
    var Type = data.d;
    BindDropDown("#ddlIncCategory", Type, "Name", "Id");
}
function BindDropDown(selector, data, dataMember, valueMember) {
    $(selector).empty();
    for (var obj in data) {
        $(selector).append("<option value=" + data[obj][valueMember] + ">" + data[obj][dataMember] + "</option>")
    }

}

function SuccessCallExp(data) {
    var Type = data.d;
    BindDropDown("#ddlExpCategory", Type, "Name", "Id");
}


function insertIncome() {
    var Income = JSON.stringify({ "objIncome": [1, $("#txtIncAmount").val(), $("#ddlIncCategory option:selected").val(), $("#txtIncNote").val()] });
    ajaxCaller("MoneyTracker.aspx/InsertIncome", Income, SuccessCallInc, FailureCall);
}

function insertExpense() {
    var Expense = JSON.stringify({ "objExpense": [1, $("#txtExpAmount").val(), $("#ddlExpCategory option:selected").val(), $("#txtExpNote").val()] });
    ajaxCaller("MoneyTracker.aspx/InsertExpense", Expense, SuccessCallInc, FailureCall);
}

function SuccessCallInc() {
    alert("Ok");
    $("#IncomeExp")[0].reset();
}