<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserExpense.aspx.cs" Inherits="Money_Tracker.Websites.UserExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Jqplot/jquery.jqplot.min.css" rel="stylesheet" />
    <script src="../script/jquery-1.11.1.js"></script>
    <script src="../Jqplot/jquery.jqplot.min.js"></script>
    <script src="../Jqplot/jquery-migrate-1.2.1.min.js"></script>
    <script src="../Jqplot/jqplot.barRenderer.min.js"></script>
    <script src="../Jqplot/jqplot.categoryAxisRenderer.min.js"></script>
    <script src="../Jqplot/jqplot.pointLabels.min.js"></script>
    <script src="../script/jquery.session.min.js"></script>
    <link href="../css/chartChange.css" rel="stylesheet" />
    <script src="../js/MyChartJs.js"></script>
</head>
<body>
    <div>
        <select id="sltYear">
            <option value="-1">Select</option>

        </select>
    </div>
    <div>
        <select id="sltMonth">
            <option value="-1">Select</option>

        </select>
    </div>
    <div>
        <select id="sltWeek">
            <option value="-1">Select</option>

        </select>
    </div>
    <div id="Inc">
    </div>
    <div id="Exp">
    </div>
</body>
</html>
