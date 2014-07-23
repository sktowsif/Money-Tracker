<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Money_Tracker.Websites.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="mini social, free download, website templates, CSS, HTML" />
    <meta name="description" content="Mini Social is a free website template from templatemo.com" />
    <link href="../css/templatemo_style.css" rel="stylesheet" />
    <link href="../css/coda-slider.css" rel="stylesheet" media="screen" charset="utf-8" />
    <script src="../js/jquery-1.2.6.js"></script>
    <script src="../js/jquery.scrollTo-1.3.3.js"></script>
    <script src="../js/jquery.localscroll-1.2.5.js"></script>
    <script src="../js/jquery.serialScroll-1.2.1.js" charset="utf-8"></script>
    <script src="../js/coda-slider.js" charset="utf-8"></script>
    <script src="../js/jquery.easing.1.3.js" charset="utf-8"></script>
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
                <li><a href="#aboutus">Login<span class="ui_icon aboutus"></span></a></li>
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

                        <div class="panel" id="home">
                        </div>
                        <!-- end of home -->

                        <div class="panel" id="aboutus">
                            <h1>Login</h1>

                            <div class="contact_form">
                                <form method="post" name="contact">
                                    <label for="author">User Id</label>
                                    <input type="text" id="txtUserId" name="author" class="required input_field" />
                                    <div class="cleaner_h10"></div>
                                    <label for="Pswd">Password</label>
                                    <input type="text" id="txtPswd" name="author" class="required input_field" />
                                    <div class="cleaner_h10"></div>
                                    <input type="button" class="submit_btn" name="submit" id="btnLogin" value="Send" />
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
                                    <label for="ddlCountry">Country</label>
                                    <select id="ddlCountry" class="required input_field">
                                        <option>Select Country</option>

                                    </select>
                                    <div class="cleaner_h10"></div>

                                    <input type="button" class="submit_btn" name="submit" id="btnRegister" value="Register" />
                                </form>
                            </div>
                        </div>

                        <div class="panel" id="gallery">
                        </div>

                        <div class="panel" id="contactus">
                            <h1>Feel free to send us a message</h1>
                            <div id="contact_form1">
                                <form method="post" name="contact">

                                    <label for="author">Your Name:</label>
                                    <input type="text" id="author1" name="author" class="required input_field" />
                                    <div class="cleaner_h10"></div>

                                    <label for="email">Your Email:</label>
                                    <input type="text" id="email" name="email" class="validate-email required input_field" />
                                    <div class="cleaner_h10"></div>

                                    <label for="text">Message:</label>
                                    <textarea id="text" name="text" rows="0" cols="0" class="required"></textarea>
                                    <div class="cleaner_h10"></div>

                                    <input type="submit" class="submit_btn" name="submit" id="submit" value="Send" />
                                    <input type="reset" class="submit_btn" name="reset" id="reset" value="Reset" />

                                </form>
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
    </div>

    </form>
</body>
</html>
