<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Money_Tracker.Websites.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../css/styleLogin.css" rel="stylesheet" />
    <script src="../script/jquery-1.11.1.js"></script>
    <script src="../script/jquery.session.min.js"></script>
    <script src="../script/jquery.noty.packaged.min.js"></script>
    <script src="../script/scriptLogin.js"></script>
</head>
<body>

    <form id="formlogin">
        <div id="divLogin">
            <div id="divHeading">
                <h1>Money Tracker</h1>
            </div>
            <div>
                <label for="txt_email">Email</label>
                <input type="text" id="txt_email" />
            </div>
            <div>
                <label for="txt_pwd">Password</label>
                <input type="password" id="txt_pwd" />
            </div>
            <div id="divRememberPwd">
                <a href="#">Can't remember password?</a>
            </div>
            <div id="divloginbtn">
                <div>
                    <input type="button" id="btn_login" value="Login" class="btnColor" />
                </div>
                <div>
                    <input type="button" id="btn_newregister" value="Sign up" class="btnColor" />
                </div>
            </div>
        </div>
    </form>

</body>
</html>
