<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoneyTracker.aspx.cs" Inherits="Money_Tracker.Websites.MoneyTracker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="mini social, free download, website templates, CSS, HTML" />
    <meta name="description" content="Mini Social is a free website template from templatemo.com" />

    <link href="../css/templatemo_style.css" rel="stylesheet" />
    <link href="../css/coda-slider.css" rel="stylesheet" media="screen" />
    <script src="../js/jquery-1.2.6.js"></script>

    <script src="../js/jquery.scrollTo-1.3.3.js"></script>
    <script src="../js/jquery.localscroll-1.2.5.js"></script>
    <script src="../js/jquery.serialScroll-1.2.1.js" charset="utf-8"></script>

    <script src="../js/coda-slider.js" charset="utf-8"></script>
    <script src="../js/jquery.easing.1.3.js" charset="utf-8"></script>
    <link href="../css/Mycss.css" rel="stylesheet" />
    <script src="../script/jquery.session.min.js"></script>
    <script src="../MyScripts/script.js"></script>
    <script src="../script/scriptMoneyTracker.js"></script>
</head>

<body>
    <div id="slider">

        <div id="templatemo_sidebar">
            <div id="templatemo_header">
                <a href="http://www.templatemo.com" target="_parent">
                    <img src="../images/templatemo_logo.png" alt="Mini Social" />
                </a>
            </div>
            <!-- end of header -->

            <ul class="navigation">
                <li><a href="#home">Home<span class="ui_icon home"></span></a></li>
                <li><a href="#aboutus">Add Income/Expense<span class="ui_icon aboutus"></span></a></li>
                <li><a href="#services">Register<span class="ui_icon services"></span></a></li>
                <li><a href="#gallery">Status<span class="ui_icon gallery"></span></a></li>
                <li><a href="#contactus">Contact Us<span class="ui_icon contactus"></span></a></li>
            </ul>
        </div>
        <!-- end of sidebar -->

        <div id="templatemo_main">
            <ul id="social_box">
                <li><a href="http://www.facebook.com">
                    <img src="../images/facebook.png" alt="facebook" /></a></li>
                <li><a href="http://www.twitter,com">
                    <img src="../images/twitter.png" alt="twitter" /></a></li>
                <li><a href="http://www.linkedin.com">
                    <img src="../images/linkedin.png" alt="linkin" /></a></li>
                <li><a href="http://www.technorati.com">
                    <img src="../images/technorati.png" alt="technorati" /></a></li>
                <li><a href="http://www.myspace.com">
                    <img src="../images/myspace.png" alt="myspace" /></a></li>
            </ul>

            <div id="content">

                <!-- scroll -->


                <div class="scroll">
                    <div class="scrollContainer">
                        <div class="contact_form">
                            <div class="panel" id="home">
                                <h1>Welcome</h1>
                                <div id="contDiv">
                                    <div>
                                        <span>Your Current Balance is :</span>
                                        <label id="lblBal"></label>
                                    </div>
                                    <form method="post" name="contact" id="fmExport">
                                        <div class="cleaner_h10"></div>
                                        <input type="button" class="submit_btn" name="submit" id="btnExport" value="Export to Excel" />
                                    </form>
                                    <a href="UserExpense.aspx">Click Here For Income and Expense Graphs</a>
                                    &nbsp;
                                </div>
                                <div id="divImg">
                                    <img src="../images/Dollar.jpg" id="imgDollar" />
                                </div>
                            </div>
                        </div>
                        <!-- end of home -->

                        <div class="panel" id="aboutus">
                            <div class="contact_form">
                                <form method="post" name="contact" id="IncomeExp">
                                    <fieldset class="fld">
                                        <legend>Income</legend>
                                        <label for="txtIncAmount">Amount <span class="star">*</span></label>
                                        <input type="text" id="txtIncAmount" name="author" class="required input_field" />
                                        <div class="cleaner_h10"></div>
                                        <label for="ddlCategory">Category <span class="star">*</span></label>
                                        <select id="ddlIncCategory" class="required input_field">
                                            <option>Select Category</option>
                                        </select>
                                        <div class="cleaner_h10"></div>
                                        <label for="txtIncNote">Note <span class="star">*</span></label>
                                        <input type="text" id="txtIncNote" name="author" class="required input_field" />
                                        <div class="cleaner_h10"></div>
                                        <input type="button" class="submit_btn" name="submit" id="btnIncome" value="Add" />
                                    </fieldset>
                                    <div class="flddiv">
                                        &nbsp;
                                    </div>
                                    <fieldset class="fld">
                                        <legend>Expenses</legend>
                                        <label for="txtExpAmount">Amount <span class="star">*</span></label>
                                        <input type="text" id="txtExpAmount" name="author" class="required input_field" />
                                        <div class="cleaner_h10"></div>
                                        <label for="ddlExpCategory">Category <span class="star">*</span></label>
                                        <select id="ddlExpCategory" class="required input_field">
                                            <option>Select Category</option>
                                        </select>
                                        <div class="cleaner_h10"></div>
                                        <label for="txtExpNote">Note <span class="star">*</span></label>
                                        <input type="text" id="txtExpNote" name="author" class="required input_field" />
                                        <div class="cleaner_h10"></div>
                                        <input type="button" class="submit_btn" name="submit" id="btnExpense" value="Add" />
                                    </fieldset>
                                </form>
                            </div>

                        </div>

                        <div class="panel" id="services">
                            <div class="contact_form">
                                <form method="post" name="Register">
                                    <label for="txtUser">User Id</label>
                                    <input type="text" id="txtUser" name="author" class="required input_field" />
                                    <div class="cleaner_h10"></div>
                                    <label for="txtPwd">Password</label>
                                    <input type="text" id="txtPwd" name="author" class="required input_field" />
                                    <div class="cleaner_h10"></div>
                                    <label for="txtConPwd">Confirm Password</label>
                                    <input type="text" id="txtConPwd" name="author" class="required input_field" />
                                    <div class="cleaner_h10"></div>
                                    <label for="txtEmail">Email</label>
                                    <input type="text" id="txtEmail" name="author" class="required input_field" />
                                    <div class="cleaner_h10"></div>


                                    <input type="button" class="submit_btn" name="submit" id="btnRegister" value="Register" />
                                </form>
                            </div>
                        </div>

                        <div class="panel" id="gallery">
                        </div>

                        <div class="panel" id="contactus">
                            <h1>Feel free to send us a message</h1>
                            <div>
                                <div id="jqChart" style="width: 500px; height: 300px;"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- end of scroll -->

        </div>
        <!-- end of content -->

        <div id="templatemo_footer">
            Copyright © 2048 <a href="#">Your Company Name</a> | <a href="http://www.iwebsitetemplate.com" target="_parent">Website Templates</a> by <a href="http://www.templatemo.com" target="_parent">Free CSS Templates</a>

        </div>
        <!-- end of templatemo_footer -->

    </div>
    <!-- end of main -->
</body>
</html>
