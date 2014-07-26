$(document).ready(function () {

   $('#btn_login').click(function () {
        CheckLogin();
    });

    $('#btn_newregister').click(function () {
        window.location.replace('Registration.aspx');
    });
})

// Ajax Call 
function ajaxCall(url, dataToSend, SuccessCallBack, ErrorCallBack) {
    $.ajax({
        url: url,
        async: true,
        type: 'POST',
        data: dataToSend,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: SuccessCallBack,
        error: ErrorCallBack
    });
}

function CheckLogin() {
    var email = $('#txt_email').val();
    var pwd = $('#txt_pwd').val();
    debugger;
    var userLoginDetails = JSON.stringify({'objCred':[email,pwd]});
    ajaxCall('Home.aspx/CheckLoginDetails', userLoginDetails, SuccessValidUser, ErrorCallBack);
}

function SuccessValidUser(data) {
    var userID = data.d;

    if (userID > 0) {
        $.session.set('userID', userID);
        window.location.replace('MoneyTracker.aspx');
    }
    else
        var n = noty({
            text: 'You are not a registered user!',
            type: 'information',
            theme: 'defaultTheme'
        });
}

// Called whr=en error is encountered by ajax call
function ErrorCallBack(xhr,msg,exception) {
    alert(msg);
}

// To generate noty messages
function ShowMessage(type) {
}


