$(document).ready(function () {
    ajaxCaller("UserExpense.aspx/GetIncome", "{}", SuccessCallInc, FailureCall);
    ajaxCaller("UserExpense.aspx/GetExpense","{}",SuccessCallExp, FailureCall);
});

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

function Chart(data) {
    var dataTemp = data.d;
    var IncomeArray = new Array();
    var DateArray = new Array();
    for (var i = 0; i < dataTemp.length; i++) {
        IncomeArray.push(dataTemp[i]["Incomes"]);
        DateArray.push(dataTemp[i]["strDate"]);
    }
    //var s2 = [460, -210, 690, 820];
    // var s3 = [-260, -440, 320, 200];
    // Can specify a custom tick Array.
    // Ticks should match up one for each y value (category) in the series.
    var ticks = DateArray;

    var plot1 = $.jqplot('Inc', [IncomeArray], {
        // The "seriesDefaults" option is an options object that will
        // be applied to all series in the chart.
        seriesDefaults: {
            renderer: $.jqplot.BarRenderer,
            rendererOptions: { fillToZero: true }
        },
        // Custom labels for the series are specified with the "label"
        // option on the series option.  Here a series option object
        // is specified for each series.
        series: [
            { label: 'Income' },
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
                ticks: ticks
            },
            // Pad the y axis just a little so bars can get close to, but
            // not touch, the grid boundaries.  1.2 is the default padding.
            yaxis: {
                pad: 1.05,
                tickOptions: { formatString: '$%d' }
            }
        }
    });
}
function SuccessCallInc(data) {
    var value = data;
    Chart(value);
}

function SuccessCallExp(data) {
    var value = data;
    ChartExp(value);
}

function FailureCall(xhr, msg, exception) {
    alert(msg);
}
function ChartExp(data) {
    var dataTemp = data.d;
    var ExpenseArray = new Array();
    var DateArray = new Array();
    for (var i = 0; i < dataTemp.length; i++) {
        ExpenseArray.push(dataTemp[i]["Expenses"]);
        DateArray.push(dataTemp[i]["strDate"]);
    }
    //var s2 = [460, -210, 690, 820];
    // var s3 = [-260, -440, 320, 200];
    // Can specify a custom tick Array.
    // Ticks should match up one for each y value (category) in the series.
    var ticks = DateArray;

    var plot1 = $.jqplot('Exp', [ExpenseArray], {
        // The "seriesDefaults" option is an options object that will
        // be applied to all series in the chart.
        seriesDefaults: {
            renderer: $.jqplot.BarRenderer,
            rendererOptions: { fillToZero: true }
        },
        // Custom labels for the series are specified with the "label"
        // option on the series option.  Here a series option object
        // is specified for each series.
        series: [
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
                ticks: ticks
            },
            // Pad the y axis just a little so bars can get close to, but
            // not touch, the grid boundaries.  1.2 is the default padding.
            yaxis: {
                pad: 1.05,
                tickOptions: { formatString: '$%d' }
            }
        }
    });
}