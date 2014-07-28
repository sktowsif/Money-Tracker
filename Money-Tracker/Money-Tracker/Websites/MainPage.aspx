<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Money_Tracker.Websites.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home</title>
    <script src="../script/jquery-1.11.1.js"></script>
    <script src="../script/jquery.session.min.js"></script>

    <link href="../css/homeCSS/homeStyle.css" rel="stylesheet" />
    <link href="../css/homeCSS/selectordie.css" rel="stylesheet" />
    <link href="../css/homeCSS/menu.css" rel="stylesheet" />
    <link href="../css/homeCSS/font-awesome.css" rel="stylesheet" />
    <link href="../css/homeCSS/selectordie_theme_02.css" rel="stylesheet" />
    <link href="../css/homeCSS/fancy-textbox.css" rel="stylesheet" />
    <link href="../css/homeCSS/waves.css" rel="stylesheet" />
    <script src="../script/homeScript/jquery.fancy-textbox.js"></script>
    <script src="../script/homeScript/selectordie.min.js"></script>
    <script src="../script/homeScript/waves.min.js"></script>
    <script src="../script/homeScript/homescript.js"></script>
    
    <%-- NOTIFICATION PLUGIN --%>
    <link href="../css/notification/ns-style-attached.css" rel="stylesheet" />
    <script src="../script/Notification/classie.js"></script>
    <script src="../script/Notification/modernizr.custom.js"></script>
    <script src="../script/Notification/notificationFx.js"></script>
    <script src="../script/homeScript/IncExpEntryScript.js"></script>

    <%-- CALENDAR PLUGIN --%>
    <link href="../script/fullcalendar.css" rel="stylesheet" />
    <link href="../script/fullcalendar.print.css" rel="stylesheet" media="print" />
    <script src="../script/lib/moment.min.js"></script>
    <script src="../script/lib/jquery-ui.custom.min.js"></script>
    <script src="../script/fullcalendar.min.js"></script>
    <script src="../script/calendarScript.js"></script>

    <%-- CHART PLUGIN --%>
    <%--<link href="../Jqplot/jquery.jqplot.min.css" rel="stylesheet" />
    <script src="../Jqplot/jquery.jqplot.min.js"></script>
    <script src="../Jqplot/jquery-migrate-1.2.1.min.js"></script>
    <script src="../Jqplot/jqplot.barRenderer.min.js"></script>
    <script src="../Jqplot/jqplot.categoryAxisRenderer.min.js"></script>
    <script src="../Jqplot/jqplot.pointLabels.min.js"></script>
    <link href="../css/chartChange.css" rel="stylesheet" />
    <script src="../js/MyChartJs.js"></script>--%>

</head>
<body>
    <div id="divBody">
        <!-- TAB CONTROLLERS -->
        <input id="panel-1-ctrl"
            class="panel-radios" type="radio" name="tab-radios" checked="checked" />
        <input id="panel-2-ctrl"
            class="panel-radios" type="radio" name="tab-radios" />
        <input id="panel-3-ctrl"
            class="panel-radios" type="radio" name="tab-radios" />
        <input id="panel-4-ctrl"
            class="panel-radios" type="radio" name="tab-radios" />
        <input id="panel-5-ctrl"
            class="panel-radios" type="radio" name="tab-radios" />
        <input id="nav-ctrl"
            class="panel-radios" type="checkbox" name="nav-checkbox" />

        <header id="introduction">
            <h1>Money Tracker</h1>
        </header>

        <!-- TABS LIST -->
        <ul id="tabs-list">
            <!-- MENU TOGGLE-->
            <label id="open-nav-label" for="nav-ctrl"></label>
            <li id="li-for-panel-1">
                <label class="panel-label"
                    for="panel-1-ctrl">
                    Home</label>
            </li>
            <!--INLINE-BLOCK FIX-->
            <li id="li-for-panel-2">
                <label class="panel-label"
                    for="panel-2-ctrl">
                    Income</label>
            </li>
            <!--INLINE-BLOCK FIX-->
            <li id="li-for-panel-3">
                <label class="panel-label"
                    for="panel-3-ctrl">
                    Expense</label>
            </li>
            <!--INLINE-BLOCK FIX-->
            <li id="li-for-panel-4">
                <label class="panel-label"
                    for="panel-4-ctrl">
                    Chart</label>
            </li>
            <!--INLINE-BLOCK FIX-->
            <li id="li-for-panel-5">
                <label class="panel-label"
                    for="panel-5-ctrl">
                    Calendar</label>
            </li>
            <label id="close-nav-label" for="nav-ctrl">Close</label>
        </ul>

        <!--THE PANELS-->
        <article id="panels">
            <div id="container">
                <section id="panel-1">
                    <main>
                        <h1>Home</h1>
                        <p>Welcome Towsif Hossain,</p>
                        <p>Show the current balance and expenditure</p>
                    </main>
                </section>

                <!--INCOME-->
                <section id="panel-2">
                    <main>
                        <h1>Income</h1>
                        <div class="manageContainer">
                            <select id="ddlIncCategory" class="ddl" data-custom-id="custom" data-custom-class="custom">
                                <option value="">Select Category...</option>
                            </select>
	                        <input type="text" data-animation="slide" id="txt_amtIncome" data-label="Amount" data-mask="0.00" class="styleSlider"/>
                            <input type="text" data-animation="slide" id="txt_noteIncome" data-label="Note" data-mask="Type here" class="styleSlider"/>
                            <div>
                                <button id="btn_addIncome" class="waves-effect waves-button waves-light waves-float" style="background: #488AC7;color: #fff;">Enter</button> 
                            </div>
                        </div>

                    </main>
                </section>

                <!--EXPENSE-->
                <section id="panel-3">
                    <main>
                        <h1>Expense</h1>
                        <div class="manageContainer">
                            <select id="ddlExpCategory" class="ddl" data-custom-id="custom" data-custom-class="custom">
                                <option value="">Select Category...</option>
                            </select>
	                        <input type="text" data-animation="slide" id="txt_amtExpense" data-label="Amount" data-mask="0.00" class="styleSlider"/>
                            <input type="text" data-animation="slide" id="txt_noteExpense" data-label="Note" data-mask="Type here" class="styleSlider"/>
                            <div>
                                <button id="btn_addExpense" class="waves-effect waves-button waves-light waves-float" style="background: #488AC7;color: #fff;">Done</button> 
                            </div>
                        </div>
                    </main>
                </section>

                <!--CHART-->
                <section id="panel-4">
                    <main>
                        <h1>Chart</h1>
                        <div class="manageContainer">
                            <div>
                                <select id="ddlYear" class="ddl" data-custom-id="custom" data-custom-class="custom">
                                    <option value="-1">Select year...</option>
                                </select>
                                <button class="waves-effect waves-button waves-light waves-float" style="background: #488AC7;color: #fff;">Show</button> 
                            </div>
                            <div>
                                <select id="ddlMonth" class="ddl" data-custom-id="custom" data-custom-class="custom">
                                    <option value="-1">Select month...</option>
                                </select>
                                <button class="waves-effect waves-button waves-light waves-float" style="background: #488AC7;color: #fff;">Show</button> 
                            </div>
                            <div>
                                <select id="ddlWeek" class="ddl" data-custom-id="custom" data-custom-class="custom">
                                    <option value="-1">Select week...</option>
                                </select>
                                <button class="waves-effect waves-button waves-light waves-float" style="background: #488AC7;color: #fff;">Show</button> 
                            </div>
                            <div id="Inc">
                            </div>
                            <div id="Exp"></div>
                        </div>
                    </main>
                </section>

                <!--CALENDAR-->
                <section id="panel-5">
                    <main>
                        <h1>Calendar</h1>
                        <div id="calendar">
                        </div>
                    </main>
                </section>

            </div>
        </article>

    </div>
</body>
</html>
