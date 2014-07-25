<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Money_Tracker.Websites.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset password</title>
    <link href="../css/styleResetPassword.css" rel="stylesheet" />
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
            <div>
                <input type="button" id="btn_send" value="Send" class="btnColor"/>
            </div>
        </div>
    </form>
</body>
</html>
