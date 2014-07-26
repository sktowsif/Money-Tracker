$(document).ready(function(){
    var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var email='';

    $('#btn_search').click(function () {
        email = $('#txt_resetEmail').val();
        if (email.length != 0) {
            if (!regex.test(email)) {
                ShowMessage('Please enter a valid mail', 'information');
                return;
            }
            CheckEmailPresent();
        }
        else {
            ShowMessage('Enter email', 'information');
        }
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

// Called when error is encountered by ajax call
function ErrorCallBack(xhr, msg, exception) {
    alert(msg);
}

function ShowMessage(msg, type) {
    var n = noty({
        text: msg,
        type: type,
        timeout: 3000,
    })
}

function SuccessValidEmail(data) {
    var isValid = data.d;

    if (isValid) {
        ShowMessage('To get back to your account, follow the instruction we have sent to ur mail!','information')
        var objEmail = JSON.stringify({ 'objEmail': [$('#txt_resetEmail').val()] });
        //StoreInfoAboutReset();
    }
    else
        ShowMessage('No account found with that email address.','error');
}

// check email present
function CheckEmailPresent() {
    var email = $('#txt_resetEmail').val();
    var userLoginEmail = JSON.stringify({ 'objUserEmail': [email] });
    ajaxCall('Helper.asmx/CheckEmail', userLoginEmail, SuccessValidEmail, ErrorCallBack);
}

function StoreInfoAboutReset() {
    var email = $('#txt_resetEmail').val();
    var userLoginEmail = JSON.stringify({ 'objUserEmail': [email] });
    //ajaxCall('Helper.asmx/CheckEmail', userLoginEmail, SuccessValidEmail, ErrorCallBack);
}