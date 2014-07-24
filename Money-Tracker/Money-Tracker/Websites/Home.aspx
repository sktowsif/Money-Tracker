<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Money_Tracker.Websites.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../css/styleLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="formlogin">
        <div id="divLogin">
            <label for="txt_email">Email</label>
            <input type="text" id="txt_email" />
            <label for="txt_pwd">Password</label>
            <input type="password" id="txt_pwd" />
            <div id="divloginbtn">
                <div>
                    <input type="button" id="btn_login" value="Login" class="btnColor" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
