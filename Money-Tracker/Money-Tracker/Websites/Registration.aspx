<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Money_Tracker.Websites.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign up</title>
    <link href="../css/styleRegister.css" rel="stylesheet" />
    <script src="../script/jquery-1.11.1.js"></script>
    <script src="../script/jquery.noty.packaged.min.js"></script>
    <script src="../script/scriptRegister.js"></script>
</head>
<body>
    <form id="formRegister">
        <div id="divRegister">
            <div style="text-align: center; margin-bottom: 10px; font-size: 20px;">
                <h1>Enter Details</h1>
            </div>
            <div>
                <label for="txt_name">Name</label>
                <input type="text" id="txt_name" class="alignControls" />
            </div>
            <div>
                <label for="txt_email">Email</label>
                <input type="text" id="txt_email" class="alignControls" />
            </div>
            <div>
                <label for="txt_pwd">Password</label>
                <input type="password" id="txt_pwd" class="alignControls" />
            </div>
            <div>
                <label for="txt_conpwd">Confirm Password</label>
                <input type="password" id="txt_conpwd" class="alignControls" />
            </div>
            <div>
                <label>Gender</label>
                <div class="radioStyle">
                    <input type="radio" id="rdoMale" value="Male" name="gender" />
                    <label for="rdoMale">Male</label>
                    <input type="radio" id="rdoFemale" value="Female" name="gender" />
                    <label for="rdoFemale">Female</label>
                </div>
            </div>
            <div>
                <label for="txt_name">Country</label>
                <select id="ddlCountry">
                    <option value="-1">Choose country...</option>
                </select>
            </div>
            <div>
                <input type="button" value="Sign up" id="btn_register" class="btnColor alignControls" />
            </div>
            <div id="divBack">
                <a href="Home.aspx"><img src="../customImage/back.png"/></a>
            </div>
        </div>
    </form>
</body>
</html>
