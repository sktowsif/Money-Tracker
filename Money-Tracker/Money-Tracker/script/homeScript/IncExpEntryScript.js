$(document).ready(function () {
    var userID = $.session.get('userID');
    //if (typeof userID == 'undefined') {
    //    window.location.replace("Home.aspx");
    //}

    $('#btn_addIncome').click(function () {
        ShowNotification();
    });

    $('#btn_addExpense').click(function () {

    });

});

// GENERIC AJAX CALL
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

function insertIncome(userID) {
    var Income = JSON.stringify({ "objIncome": [userID, $("#txtIncAmount").val(), $("#txtExpAmount").val(), $("#ddlIncCategory option:selected").val(), $("#txtIncNote").val()] });
    ajaxCaller("MoneyTracker.aspx/InsertIncome", Income, SuccessCallInc, FailureCall);
}

function insertExpense(userID) {
    var Expense = JSON.stringify({ "objIncome": [userID, $("#txtIncAmount").val(), $("#txtExpAmount").val(), $("#ddlExpCategory option:selected").val(), $("#txtExpNote").val()] });
    ajaxCaller("MoneyTracker.aspx/InsertIncome", Expense, SuccessCallInc, FailureCall);
}

function SuccessCallInc() {
    alert("Ok");
    $("#IncomeExp")[0].reset();
}

function ShowNotification() {
    var notification = new NotificationFx({
        wrapper: document.body,
        message: '<span class="icon icon-calendar"></span><p>Event have been added to the calendar</p>',
        layout: 'attached',
        effect: 'bouncyflip',
        type: 'notice',
        ttl: 6000,
        onClose: function () { return false; },
        onOpen: function () { return false; }
    });
    notification.show();
}