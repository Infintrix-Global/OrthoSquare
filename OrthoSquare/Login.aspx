
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OrthoSquare.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Orthosquare Login</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for " name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&amp;subset=all" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="../assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../assets/pages/css/login.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <!-- new css file added by samrudhi -->
    <link href="css/newstyle.css" rel="stylesheet" />

    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />

</head>

<body class=" login">
    <form id="form1" runat="server">
        <div class="margin">
        </div>

        <!-- BEGIN LOGIN -->
        <div class="content">
            <div class="col-md-6">
                <div class="quote-txt border-right">
                    <img src="../assets/pages/img/login/quotes.png" alt="" class="img-responsive" /></div>
            </div>
            <div class="col-md-6">
                <!-- BEGIN LOGIN FORM -->
                <form class="login-form" action="" method="post">
                    <div class="logo">
                        <img src="../assets/pages/img/login/l-login.png" width="169" height="103" alt="" /></div>
                    <div class="alert alert-danger display-hide">
                        <button class="close" data-close="alert"></button>
                        <span>Enter any username and password. </span>
                    </div>
                    <div class="form-group">
                        <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                        <label class="control-label visible-ie8 visible-ie9">Username</label>

                        <asp:TextBox ID="txtUserName" class="form-control form-control-solid placeholder-no-fix" placeholder="Username" runat="server"></asp:TextBox>
                        <span class="help-block">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                SetFocusOnError="true" ErrorMessage="Please Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>
                        </span>

                    </div>
                    <div class="form-group">
                        <label class="control-label visible-ie8 visible-ie9">Password</label>


                        <asp:TextBox ID="txtPassword" class="form-control form-control-solid placeholder-no-fix" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>

                        <span class="help-block">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                SetFocusOnError="true" ErrorMessage="Please Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="form-actions">

                        <asp:Button ID="btnlogin" class="btn green uppercase" runat="server" OnClick="btnlogin_Click1" Text="Login" />
                        <asp:Button ID="Btnundermantenas" Visible="false" PostBackUrl="~/UnderMaintenance.aspx" class="btn green uppercase" runat="server" Text="Login" />


                        <label class="rememberme check mt-checkbox mt-checkbox-outline">
                            <input type="checkbox" name="remember" value="1" />Remember
                        <span></span>
                        </label>
                        <a id="forget-password" class="forget-password" data-toggle="modal" data-target="#forgotpw">Forgot Password?</a>
                    </div>

                </form>
                <!-- END LOGIN FORM -->
                <!-- BEGIN FORGOT PASSWORD FORM --<asp:Button runat="server" Text="Button"></asp:Button>>
            <div class="modal fade" id="forgotpw" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content">
        <div class="modal-header">
          <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
          <%--<h4 class="modal-title">Modal Header</h4>--%>
            <h3 class="font-green">Forget Password ?</h3>
        </div>
        <div class="modal-body">
            <form class="forget-form" action="" method="post">
                
                <p> Enter your e-mail address below to reset your password. </p>
                <div class="form-group">
                    <input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="User Name" name="email" /> </div>
               
            </form>
             </div>
        <div class="modal-footer">
           
                    <button type="submit" class="btn btn-success uppercase pull-right"  data-dismiss="modal">Submit</button>
        </div>
      </div>
    </div>
  </div>
            <!-- END FORGOT PASSWORD FORM -->

            </div>
        </div>
        <div class="copyright">
            &copy; 2018 All Rights Reserved</a> &nbsp;|&nbsp;
                <a href="www.infintrixglobal.com" title="">Designed by InfintrixGlobal</a>
        </div>
        <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<script src="../assets/global/plugins/ie8.fix.min.js"></script> 
<![endif]-->
        <!-- BEGIN CORE PLUGINS -->
        <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="../assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../assets/pages/scripts/login.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <!-- END THEME LAYOUT SCRIPTS -->
        <!-- Google Code for Universal Analytics -->
        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../../../../www.google-analytics.com/analytics.js', 'ga');
            ga('create', 'UA-37564768-1', 'auto');
            ga('send', 'pageview');
        </script>
        <!-- End -->

        <!-- Google Tag Manager -->
        <noscript><iframe src="http://www.googletagmanager.com/ns.html?id=GTM-W276BJ"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
        <script>(function (w, d, s, l, i) {
w[l] = w[l] || []; w[l].push({
'gtm.start':
new Date().getTime(), event: 'gtm.js'
}); var f = d.getElementsByTagName(s)[0],
j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
'../../../../../www.googletagmanager.com/gtm5445.html?id=' + i + dl; f.parentNode.insertBefore(j, f);
})(window, document, 'script', 'dataLayer', 'GTM-W276BJ');</script>
        <!-- End -->



        <!-- END HEAD -->










    </form>
</body>
</html>
