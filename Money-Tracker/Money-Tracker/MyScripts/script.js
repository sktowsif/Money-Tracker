$(document).ready(function () {
    var userID = $.session.get('userID');
    if (typeof userID =='undefined')
    {
        window.location.replace("Home.aspx");
    }
    ajaxCaller("Helper.asmx/GetBalance","{intId:"+userID+"}", SuccessBal, FailureCall);
    ajaxCaller("MoneyTracker.aspx/GetAllIncome", "{}", SuccessCall, FailureCall);
    ajaxCaller("MoneyTracker.aspx/GetAllExpense", "{}", SuccessCallExp, FailureCall);
    $("#btnIncome").click(function () {
        var Text=$("#txtIncNote).val()")
        insertIncome(userID);
        ajaxCaller("Helper.asmx/GetBalance", "{intId:" + userID + "}", SuccessBal, FailureCall);
    });

    $("#btnExpense").click(function () {
        insertExpense(userID);
        ajaxCaller("Helper.asmx/GetBalance", "{intId:" + userID + "}", SuccessBal, FailureCall);
    });
    $("#btnExport").click(function () {
        debugger;
        ajaxCaller("Helper.asmx/ExportToXL", "{intId:" + userID + "}", FailureCall);
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
function SuccessBal(data)
{
    $("#lblBal").text(data.d);
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


function insertIncome(userID) {
    var Income = JSON.stringify({ "objIncome": [userID, $("#txtIncAmount").val(), $("#txtExpAmount").val(), $("#ddlIncCategory option:selected").val(),$("#txtIncNote").val()] });
    ajaxCaller("MoneyTracker.aspx/InsertIncome", Income, SuccessCallInc, FailureCall);
    return false;
}

function insertExpense(userID) {
    var Expense = JSON.stringify({ "objIncome": [userID, $("#txtIncAmount").val(), $("#txtExpAmount").val(), $("#ddlExpCategory option:selected").val(), $("#txtExpNote").val()] });
    ajaxCaller("MoneyTracker.aspx/InsertIncome", Expense, SuccessCallInc, FailureCall);
    return false;
}

function SuccessCallInc() {
    alert("Ok");
    $("#IncomeExp")[0].reset();
}