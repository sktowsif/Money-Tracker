<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Money_Tracker.Websites.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset password</title>
    <script src="../script/jquery-1.11.1.js"></script>
    <script src="../script/jquery.noty.packaged.min.js"></script>
    <link href="../css/styleResetPassword.css" rel="stylesheet" />
    <script src="../script/scriptReset.js"></script>
</head>

<body>
    <form id="formResetPassword" runat="server">
        
        <div id="divResetPassword">
            <div id="divHeading">
                <label>Find Your Account</label>
            </div>
            <div>
                <label>Enter Email</label>
            </div>
            <div>
                <input type="text" id="txt_resetEmail" />
            </div>
            <div>
                <input type="button" id="btn_search" value="Search" class="btnColor"/>
            </div>
            <div id="divBack">
                <a href="Home.aspx"><img src="../customImage/back.png"/></a>
            </div>

            <%--<div>
                <input type="button" id="btn_send" value="Send" class="btnColor"/>
            </div>--%>
        </div>
    </form>
</body>
</html>
