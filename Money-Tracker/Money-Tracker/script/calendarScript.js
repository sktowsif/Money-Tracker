$(document).ready(function () {
    ajaxCall('Helper.asmx/GetIncomeExpenseData', "{}", DataForCalendar, ErrorCallBack);
});

// Generic Ajax call function
function ajaxCall(url,dataToSend,SuccessCallBack,ErrorCallBack) {
    $.ajax({
        url: url,
        asyn: true,
        data: dataToSend,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: SuccessCallBack,
        error: ErrorCallBack
    });
}

function ErrorCallBack(xhr,msg,exception) {
    alert(msg);
}

// On Success Call
function DataForCalendar(data) {
    
    var dataTemp = data.d;
    
    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,basicWeek,basicDay'
        },
        defaultDate: new Date(),
        editable: true,
        events: dataTemp,
    });
}