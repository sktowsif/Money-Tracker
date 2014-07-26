$(document).ready(function() {
    
    //populate the country drop down list
    ajaxCall('Registration.aspx/FillCountryDropDown', '{}', BindCountry, ErrorCallBack);

    // button register action
    $('#btn_register').click(function () {
        GetUserDetails();
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

// Called whr=en error is encountered by ajax call
function ErrorCallBack(xhr,msg,exception) {
    alert(msg);
}

// create the option attribute for drop down
function BindDropDown(selector,data,dataMember,valueMember) {
    for (var obj in data) 
        $(selector).append("<option value=" + data[obj][valueMember] + ">" + data[obj][dataMember] + "</option>")
}

// get the value on success call
function BindCountry(data) {
    var country = data.d;
    BindDropDown('#ddlCountry',country,"Name","Id");
}

// get the user data from registration form
// and store in database using ajax
function GetUserDetails() {
    var name = $('#txt_name').val();
    var email = $('#txt_email').val();
    var pwd = $('#txt_pwd').val();

    // read the gender selected
    var gender = $('input[name=gender]:checked', '#formRegister').val();

    // find the country selected
    var $selectedOpt = $('#ddlCountry').find('option:selected');
    var country = $selectedOpt.text();
    
    var objUserData = JSON.stringify({"objUserData":[name,gender,email,pwd,country] });

    ajaxCall('Registration.aspx/InsertUser', objUserData, SuccessUserInsert, ErrorCallBack);
}

function SuccessUserInsert() {
    var n = noty({
        text: 'You are successfully signed up go back to login page!',
        type: 'information',
        theme: 'defaultTheme'
    });
}