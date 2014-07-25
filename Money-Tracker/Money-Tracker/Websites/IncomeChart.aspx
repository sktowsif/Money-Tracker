<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncomeChart.aspx.cs" Inherits="Money_Tracker.Websites.WebForm2" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Chart/jquery.jqChart.css" rel="stylesheet" />
    <link href="../Chart/jquery.jqRangeSlider.css" rel="stylesheet" />
    <link href="../Chart/jquery-ui-1.10.4.css" rel="stylesheet" />
    <script src="../Chart/jquery-1.11.1.min.js"></script>
    <script src="../Chart/jquery.mousewheel.js"></script>
    <script src="../Chart/jquery.jqChart.min.js"></script>
    <script src="../Chart/jquery.jqRangeSlider.min.js"></script>
     <script lang="javascript" type="text/javascript">
         $(document).ready(function () {
             $('#jqChart').jqChart({
                 title: { text: 'Column Chart Colors' },
                 animation: { duration: 1 },
                 shadows: {
                     enabled: true
                 },
                 series: [
                     {
                         type: 'column',
                         title: 'Series 1',
                         fillStyles: ['#418CF0', '#FCB441', '#E0400A', '#056492', '#BFBFBF', '#1A3B69', '#FFE382'],
                         data: [['A', 33], ['B', 57], ['C', 33],
                                ['D', 12], ['E', 35], ['F', 7], ['G', 24]]
                     }
                 ]
             });
         });
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div id="jqChart" style="width: 500px; height: 300px;"></div>
        </div>
    </form>
</body>
</html>
