$(document).ready(function () {

   $('#btn_login').click(function () {
       validateLoginPage($('#txt_email').val(),$('#txt_pwd').val())
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
        ShowMessage('You are not a registered user!','information')
}

// Called whr=en error is encountered by ajax call
function ErrorCallBack(xhr,msg,exception) {
    alert(msg);
}

// To generate noty messages
function ShowMessage(msg, type) {
    var n = noty({
        text: msg,
        type: type,
        timeout: 3000,
    })
}

// validation for email and password
function validateLoginPage(email,password) {
    var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var email = $('#txt_email').val();
    var pwd = $('#txt_pwd').val();
    var isValid = true;

    if (email.length == 0 && pwd.length == 0) {
        ShowMessage('Please enter your email and password', 'information');
        return;
    }

    if (email.length != 0 || pwd.length != 0) {
        if (!regex.test(email)) {
            ShowMessage('Please enter a valid email', 'error');
            $('#txt_email').focus();
            isValid = false;
        }
        var pwdLength = password.length;
        if (pwdLength < 6) {
            ShowMessage('Password should be more than 6 charcters', 'error');
            $('#txt_pwd').focus();
            isValid = false;
        }
    }

    if (isValid)
        CheckLogin();

}




