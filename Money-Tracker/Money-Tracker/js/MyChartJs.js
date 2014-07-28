$(document).ready(function () {
    var userID = $.session.get('userID');
    if (typeof userID == 'undefined') {
        window.location.replace("Home.aspx");
    }
    ajaxCaller("Helper.asmx/GetYears", "{}", SuccessCallYears, FailureCall);
    $("#sltYear").change(function () {
        ajaxCaller("Helper.asmx/GetYearData", "{intId:"+userID+",intYear:"+$("#sltYear option:selected").text()+"}", SuccessCallY, FailureCall);
        ajaxCaller("Helper.asmx/GetMonths", {}, SuccessMonth, FailureCall);
    });
    ajaxCaller("Helper.asmx/GetIncome", "{Id:" + userID + "}", SuccessCallAll, FailureCall);
    $("#sltMonth").change(function () {
        ajaxCaller("Helper.asmx/GetSelectedMonth", "{intId:" + userID + ",intYear:" + $("#sltYear option:selected").text() + ",intMonth:" + $("#sltMonth option:selected").val() + "}", SuccessCallM, FailureCall);
        ajaxCaller("Helper.asmx/GetWeeks", "{}", SuccessCallWeeks, FailureCall);
    });
    $("#sltWeek").change(function () {
        ajaxCaller("Helper.asmx/GetWeekData", "{intId:" + userID + ",intYear:" + $("#sltYear option:selected").text() + ",intMonth:" + $("#sltMonth option:selected").val() + ",intWeekNumber:" + $("#sltWeek option:selected").val() + "}", SuccessCallW, FailureCall);
    });
    
});
function SuccessCallM(data) {
    if (data.d.length == 0)
    {
        alert("Sorry Their is No Income or Expense in This Month");
    }
    var value = data;
    var day = "Day";
    var x = "Dates in Week";
    var y = "Amount in $";
    var Name = "Total Month Income and Expenditure";
    Chart(value, day, x, y, Name);

}
function SuccessCallWeeks(data){
    var Type = data.d;
    BindDropDown("#sltWeek", Type, "Week", "Id");
}
function SuccessCallYears(data) {
    var Type = data.d;
    BindDropDown("#sltYear", Type, "Years", "Id");
}
function SuccessCallY(data){
    if (data.d.length == 0) {
        alert("Sorry Their is No Income or Expense in This Year");
    }
    var value = data;
    var day = "MonthName";
    var x = "Months";
    var y = "Amount in $";
    var Name = "Total Year Income and Expenditure";
    Chart(value, day,x,y,Name);
}
function Success(data) {
    var value = data;
    ChartMonth(value);
}
function SuccessMonth(data) {
    var Type = data.d;
    BindDropDown("#sltMonth", Type, "MonthName", "Id");
}
function BindDropDown(selector, data, dataMember, valueMember) {
    $(selector).empty();
    for (var obj in data) {
        $(selector).append("<option value=" + data[obj][valueMember] + ">" + data[obj][dataMember] + "</option>")
    }

}
function ajaxCaller(url, dataToSend, SuccessCall, FailureCallBack) {
    $.ajax({
        url: url,
        async: true,
        type: 'POST',
        data: dataToSend,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: SuccessCall,
        error: FailureCallBack
    });
}

function Chart(data,day,x,y,Name) {
    $("#Inc").empty();
    var dataTemp = data.d;
    var IncomeArray = new Array();
    var DateArray = new Array();
    var ExpArray = new Array();
    for (var i = 0; i < dataTemp.length; i++) {
        IncomeArray.push(dataTemp[i]["Incomes"]);
        DateArray.push(dataTemp[i][day]);
        ExpArray.push(dataTemp[i]["Expense"]);
    }
    //var s2 = [460, -210, 690, 820];
    // var s3 = [-260, -440, 320, 200];
    // Can specify a custom tick Array.
    // Ticks should match up one for each y value (category) in the series.
    var ticks = DateArray;
    var options = {
        title:Name,
        // The "seriesDefaults" option is an options object that will
        // be applied to all series in the chart.
        seriesDefaults: {
            renderer: $.jqplot.BarRenderer(function () {
                this.barPadding = 3

            }),
            rendererOptions: { fillToZero: true }
        },
        // Custom labels for the series are specified with the "label"
        // option on the series option.  Here a series option object
        // is specified for each series.
        series: [
            { label: 'Income' },
            { label: 'Expense' },
            { label: 'strDate' },
            //{ label: 'Airfare' }
        ],
        // Show the legend and put it outside the grid, but inside the
        // plot container, shrinking the grid to accomodate the legend.
        // A value of "outside" would not shrink the grid and allow
        // the legend to overflow the container.
        legend: {
            show: true,
            placement: 'outsideGrid'
        },

        axes: {
            // Use a category axis on the x axis and use our custom ticks.
            xaxis: {
                renderer: $.jqplot.CategoryAxisRenderer,
                ticks: ticks,
                label:x
            },
            // Pad the y axis just a little so bars can get close to, but
            // not touch, the grid boundaries.  1.2 is the default padding.
            yaxis: {
                pad: 1,
                tickOptions: { formatString: '$%d' },
                label:y
            }
        },
    }
    var plot1 = $.jqplot('Inc', [IncomeArray, ExpArray], options);
}
function SuccessCallAll(data) {
    var value = data;
    var day = "Day";
    var x = "day";
    var y = "Amount in $";
    var Name = "Daily Income and Expenditure";
    Chart(value,day,x,y,Name);
}
function SuccessCallW(data) {
    if (data.d.length == 0)
        alert("Sorry Their is No Income or Expense in This Week");
    var value = data;
    var day = "Day";
    var x = "day";
    var y = "Amount in $";
    var Name = "Week Income and Expenditure";
    Chart(value, day, x, y, Name);
}


function FailureCall(xhr, msg, exception) {
    alert(msg);
}

