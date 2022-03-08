<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="PatientMaster.aspx.cs" Inherits="OrthoSquare.patient.PatientMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ajaxtab.css" rel="stylesheet" />
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 11pt;
        }

        .ErrorControl {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }

        .ajax__tab_xp .ajax__tab_header {
            font-family: arial;
            font-size: 14px !important;
            background: #fff;
            border-bottom: 0px solid #ccc !important;
        }


        .ajax__tab_xp .ajax__tab_default .ajax__tab_header {
            white-space: normal;
            height: 29px !important;
        }

        .ajax__tab_xp .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
            background: none;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
            padding-right: 18px;
            background: none !important;
            height: 46px !important;
        }


        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            height: 43px !important;
            padding: 10px 10px !important;
            background: none !important;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
            padding-left: 4px;
            background: none !important;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            background: none !important;
        }


        .ajax__tab_xp .ajax__tab_tab a:hover {
            background-color: #22bfed !important;
            color: #ffffff !important;
        }

        .ajax__tab_xp .ajax__tab_tab a:active {
            background-color: #22bfed !important;
            color: #ffffff !important;
        }


        .ajax__tab_xp .ajax__tab_active ajax__tab_hover {
            background: #22bfed !important;
            background: -moz-linear-gradient(left, #22bfed 0%, #4ca76d 100%) !important;
            background: -webkit-linear-gradient(left, #22bfed 0%, #4ca76d 100%) !important;
            background: linear-gradient(to right, #22bfed 0%, #4ca76d 100%) !important;
            color: #ffffff !important;
        }

        .ajax__tab_xp .ajax__tab_header {
            font-family: arial;
            font-size: 14px;
            background: #fff;
            border-bottom: 0px solid #ccc !important;
        }
    </style>

    <script type="text/javascript">
        function DateSelectionChanged() {
            var today = new Date();
            var dob = new Date(document.getElementById('<%=txtBDate.ClientID%>').value);
             var months = (today.getMonth() - dob.getMonth() + (12 * (today.getFullYear() - dob.getFullYear())));
             document.getElementById('<%=txtAge.ClientID%>').value = Math.round(months / 12);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="page-content" visible="false" id="Add" runat="server">
        <!-- BEGIN PAGE HEADER-->

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Patient </span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Patient</span>
                        </div>
                        
                    </div>
                    <div class="tabbable-custom ">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">

                                    <div class="col-sm-4">
                                        <label>
                                            Clinic Name  <span class="required">*</span></label>
                                        <asp:DropDownList ID="ddlClinic" class="form-control" runat="server" SelectionMode="Multiple">
                                        </asp:DropDownList>


                                        <span class="help-block">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlClinic" ValidationGroup="a" InitialValue="0"
                                                SetFocusOnError="true" ErrorMessage="Please Select Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </span>


                                    </div>
                                    <div class="col-sm-4">
                                        <%-- <asp:ListBox runat="server" ID="lst" CssClass="form-control" SelectionMode="Multiple"
                                 DataTextField="ClinicName" DataValueField="ClinicID" Height="110px" AppendDataBoundItems="true"></asp:ListBox>--%>
                                    </div>

                                </div>
                            </div>


                        </div>


                        <asp:TabContainer ID="TabContactPerson1" class="nav nav-tabs " runat="server" ActiveTabIndex="0">

                            <asp:TabPanel ID="tabPersonal" class="tab-pane" HeaderText="Personal Information " runat="server">
                                <ContentTemplate>

                                    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                    <div class="row">



                                        <%--<div class="col-md-6 ">--%>

                                        <div class="portlet-body form">

                                            <div class="form-body">

                                                <div class="form-group col-md-6">
                                                    <label>Patient No.</label>
                                                    <asp:TextBox ID="txtPatientNo" class="form-control" ReadOnly="true" TabIndex="1" placeholder="Enter Patient No"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Date</label>
                                                    <asp:TextBox ID="txtRegDate" ReadOnly="true" TabIndex="2" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtENqDate_CalendarExtender" runat="server" Enabled="True"
                                                        TargetControlID="txtRegDate" Format="dd-MM-yyyy">
                                                    </asp:CalendarExtender>

                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group col-md-6">
                                                    <label>First Name <span class="required">*</span></label>
                                                    <asp:TextBox ID="txtFname" class="form-control" placeholder="First Name" TabIndex="3" runat="server"></asp:TextBox>
                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFname" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter First name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ValidationGroup="a"
                                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtFname"
                                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Last Name </label>
                                                    <asp:TextBox ID="txtLname" class="form-control" placeholder="Enter Last Name" TabIndex="4" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredLname" runat="server" ControlToValidate="txtLname" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Last name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorLname" runat="server" ValidationGroup="a"
                                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtLname"
                                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>

                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group col-md-6">
                                                    <label>Date of Birth</label>
                                                    <%--   <asp:TextBox ID="txtBDate" class="form-control" TextMode="Date"  TabIndex="5" OnTextChanged="txtBDate_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                    --%>

                                                    <asp:TextBox ID="txtBDate" class="form-control" TextMode="Date" TabIndex="5" onchange="DateSelectionChanged()" runat="server"></asp:TextBox>



                                                    <%--<asp:CalendarExtender ID="txtBDate_CalendarExtender" OnClientDateSelectionChanged="checkDate" runat="server" Enabled="True"
                                                                TargetControlID="txtBDate" Format="dd-MM-yyyy">
                                                            </asp:CalendarExtender>--%>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Gender</label>

                                                    <asp:RadioButtonList ID="RadGender" runat="server" Width="300px" TabIndex="7" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group col-md-6">
                                                    <label>Address</label>
                                                    <asp:TextBox ID="txtAddress" class="form-control" placeholder="Enter Address" TabIndex="9" runat="server"
                                                        TextMode="MultiLine"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredtxtAddress" runat="server" ControlToValidate="txtAddress" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Country</label>
                                                    <asp:DropDownList ID="ddlCountry" class="form-control" runat="server" AutoPostBack="True" TabIndex="11"
                                                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group col-md-6">
                                                    <label>State</label>
                                                    <asp:DropDownList ID="ddlState" class="form-control" runat="server" AutoPostBack="True" TabIndex="12"
                                                        OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>City</label>
                                                    <asp:DropDownList ID="ddlCity" class="form-control" TabIndex="13" runat="server">
                                                    </asp:DropDownList>

                                                </div>






                                                <div class="clearfix"></div>
                                                <div class="form-group col-md-6">
                                                    <label>Age</label>
                                                    <%--Dhaval--%>
                                                    <%-- <asp:TextBox ID="txtAge" class="form-control" ReadOnly ="true" TabIndex ="6" placeholder="Enter Age" runat="server"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtAge" class="form-control" value="0" TabIndex="6" placeholder="Enter Age" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ValidationGroup="a"
                                                            ErrorMessage="Only Number is allowed" Display="Dynamic" ControlToValidate="txtAge"
                                                            SetFocusOnError="True" ValidationExpression="^\d+$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Blood Group</label>

                                                    <asp:TextBox ID="txtBoolGroup" class="form-control" placeholder="Enter Blood Group" TabIndex="8" runat="server"></asp:TextBox>

                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group col-md-6">
                                                    <label>Area  </label>

                                                    <asp:TextBox ID="txtArea" class="form-control" placeholder="Enter Area" TextMode="MultiLine" TabIndex="10"
                                                        runat="server"></asp:TextBox>

                                                </div>

                                                <div class="form-group col-md-6">
                                                    <label>Email</label>
                                                    <asp:TextBox ID="txtEmail" class="form-control" placeholder="Enter Email" TabIndex="14" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="a"
                                                            ForeColor="Red" ErrorMessage="Enter Proper Email ID" Display="Dynamic" ControlToValidate="txtEmail"
                                                            SetFocusOnError="True" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="form-group col-md-6">
                                                    <label>Mobile No.  <span class="required">*</span></label>

                                                    <asp:TextBox ID="txtMobile" class="form-control" placeholder="Enter Mobile" TabIndex="15" runat="server"></asp:TextBox>



                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredMobile" runat="server" ControlToValidate="txtMobile" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server" ValidationGroup="a"
                                                            Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                            SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </span>

                                                </div>




                                                <div class="form-group col-md-6">
                                                    <label>Telephone No.</label>
                                                    <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Enter Telephone" TabIndex="16"
                                                        runat="server"></asp:TextBox>

                                                </div>
                                                <div class="clearfix"></div>


                                                <div class="form-group col-md-6">
                                                    <label>Enquiry Source</label>
                                                    <asp:DropDownList ID="ddlEnquirysource" class="form-control" runat="server"></asp:DropDownList>

                                                </div>

                                                <%--  </div>

                                            </div>--%>
                                            </div>
                                        </div>
                                        <!-- END CONTENT BODY -->
                                    </div>
                                    <%--  </ContentTemplate>
                                    </asp:UpdatePanel>--%>


                                    <div class="row">

                                        <div class="col-xs-12">
                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label>
                                                        Patient Profile
                                                    </label>
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:FileUpload ID="FileUpProfile" runat="server" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:Button ID="btnProfile" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                        runat="server" Text="Upload Image" OnClick="btnImageProfile_Click" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:Image ID="ImageProfile" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                        ImageUrl="~/Images/no-photo.jpg" />
                                                    <asp:Label ID="lblProfile" runat="server" Visible="False"></asp:Label>
                                                </div>
                                            </div>

                                        </div>


                                    </div>




                                    <div class="row">
                                        <div class="form-actions text-center">
                                            <div align="Right">
                                                <asp:Button ID="BtnNextContact" runat="server" Text="Next" class="btn btn-info btn-sm" OnClick="BtnNextContact_Click" ValidationGroup="a" />
                                            </div>
                                        </div>


                                    </div>
                                </ContentTemplate>

                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanelMedical" class="tab-pane" HeaderText="Medical History" runat="server">
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-6 ">

                                                    <div class="portlet-body form">

                                                        <div class="form-body">

                                                            <div class="form-group">
                                                                <label>Family Doctor's Name</label>
                                                                <asp:TextBox ID="txtFDoctorName" class="form-control" placeholder="Enter Family Doctor's Name"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label><b>Have you Suffered from any of the following</b></label>

                                                            </div>
                                                        </div>


                                                    </div>
                                                </div>

                                                <div class="col-md-6">
                                                    <div class="portlet light form-fit ">

                                                        <div class="portlet-body form">
                                                            <!-- BEGIN FORM-->
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Address & Telephone no.</label>
                                                                    <asp:TextBox ID="txtDoctorAddres" class="form-control" placeholder="Enter Address & Telephone no." runat="server"></asp:TextBox>


                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="form-group">
                                                        <div class="col-sm-12">
                                                            <asp:CheckBoxList ID="ChkMedicalProblem1" Width="100%" RepeatColumns="6" RepeatDirection="Vertical" class="mt-checkbox-list" runat="server"></asp:CheckBoxList>

                                                        </div>



                                                    </div>
                                                    .
                                                </div>



                                            </div>


                                            <div class="text-right mb-20">
                                                <asp:Button ID="btnMedicalProblem" class="btn green" ClientIDMode="Static" CausesValidation="false" Visible="false"
                                                    runat="server" Text="Add" OnClick="btnAddMedicalProblem123_Click" />
                                            </div>
                                            <br />

                                            <div id="AddMedicalProblem" visible="false" runat="server" class="row">

                                                <div class="col-xs-12">
                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <label>
                                                                Medical Problem</label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtMedicalProblem" class="form-control" TabIndex="4"
                                                                runat="server"></asp:TextBox>


                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:Button ID="btnAddMedicalProblem" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                                runat="server" Text="Submit" OnClick="btnAddMedicalProblem_Click" />

                                                            <asp:Button ID="btnMedicalProblemCancel" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                                                OnClick="btnMedicalProblemCancel_Click" CausesValidation="False" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                        </div>
                                                    </div>

                                                </div>


                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <label><b>Woman</b> </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Are you Pregnant</label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:RadioButtonList ID="RadPregnant" class="mt-radio-list" OnSelectedIndexChanged="RadPregnant_SelectedIndexChanged" AutoPostBack="true" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No" Selected="True"></asp:ListItem>
                                                                    </asp:RadioButtonList>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>(If Yes, your due date?)</label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtPreganetDueDate" Visible="false" class="form-control" placeholder="Enter Due Date." runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendartxtPreganetDueDate" runat="server" Enabled="True"
                                                                        TargetControlID="txtPreganetDueDate" Format="dd-MM-yyyy">
                                                                    </asp:CalendarExtender>

                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <label><b>Habits</b> </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Pan Masala Chewing</label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">

                                                                    <asp:RadioButtonList ID="RadPanMasala" class="mt-radio-list" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No" Selected="True"></asp:ListItem>
                                                                    </asp:RadioButtonList>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Pan Chewing(Tobacco)</label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">

                                                                    <asp:RadioButtonList ID="RadTobacco" class="mt-radio-list" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No" Selected="True"></asp:ListItem>
                                                                    </asp:RadioButtonList>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Smoking </label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:RadioButtonList ID="RadSomking" AutoPostBack="true" class="mt-radio-list" OnSelectedIndexChanged="RadSomking_SelectedIndexChanged" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No" Selected="True"></asp:ListItem>
                                                                    </asp:RadioButtonList>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>if yes, How many cigrattes in day   </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtNofoCigrattes" Visible="false" class="form-control" placeholder="How many cigrattes in day." runat="server"></asp:TextBox>

                                                                    <span class="help-block">
                                                                        <asp:RegularExpressionValidator ID="RegularNofoCigrattes" runat="server" ForeColor="Red"
                                                                            ErrorMessage="Only Number is allowed" Display="Dynamic" ControlToValidate="txtNofoCigrattes"
                                                                            SetFocusOnError="True" ValidationExpression="^\d+$">
                                                                        </asp:RegularExpressionValidator>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-6">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>List of Medicine you are taking currently, if any   </label>
                                                                    <asp:TextBox ID="txtListMedicine" class="form-control" placeholder="Enter List of Medicine." runat="server"></asp:TextBox>


                                                                </div>
                                                            </div>

                                                        </div>



                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-6">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Are you allergic to any of the following</label>


                                                                </div>
                                                            </div>

                                                        </div>



                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-12">
                                                          
                                                                <div class="mt-checkbox-inline">
                                                                    <asp:CheckBoxList ID="checkallergic" Width="100%" RepeatDirection="Horizontal" RepeatColumns="6" runat="server">
                                                                    </asp:CheckBoxList>
                                                            
                                                            </div>

                                                        </div>



                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>



                                            <div class="text-right mb-20">
                                                <asp:Button ID="Button1" class="btn green" ClientIDMode="Static" CausesValidation="false" Visible="false"
                                                    runat="server" Text="Add" OnClick="btnAddAllergic123_Click" />
                                            </div>
                                            <br />

                                            <div id="Addallergic" visible="false" runat="server" class="row">

                                                <div class="col-xs-12">
                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <label>
                                                                Allergic</label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtAddallergic" class="form-control" TabIndex="4"
                                                                runat="server"></asp:TextBox>


                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:Button ID="btnAddallergic" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                                runat="server" Text="Submit" OnClick="btnAddallergic_Click" />

                                                            <asp:Button ID="btnallergicCancel" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                                                OnClick="btnallergicCancel_Click" CausesValidation="False" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                        </div>
                                                    </div>

                                                </div>


                                            </div>

                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                    <div class="row">
                                        <div class="form-actions text-center">
                                            <div align="Right">
                                                <asp:Button ID="btnMedical" runat="server" Text="Next" class="btn btn-info btn-sm" OnClick="BtnNextMedical_Click" CausesValidation="false" />
                                            </div>
                                        </div>

                                    </div>


                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanelDentalInformation" class="tab-pane" HeaderText="Dental Information" runat="server">
                                <ContentTemplate>

                                    <br />



                                    <div class="row">
                                        <div class="col-xs-12">


                                            <div class="form-group">
                                                <div class="col-sm-10">
                                                    <div class="form-body">
                                                        <label>What is your complaint? </label>
                                                        <asp:TextBox ID="txtcomplaint" class="form-control" placeholder="Enter complaint." runat="server"></asp:TextBox>

                                                    </div>

                                                </div>



                                                <div class="col-sm-2">
                                                    <div class="form-body">

                                                        <div class="form-group">
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            .
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-xs-12">


                                            <div class="form-group">
                                                <div class="col-sm-10">
                                                    <div class="form-body">
                                                        <label>List any dental treatment done in the one year. </label>
                                                        <asp:TextBox ID="txtlistDentalTreatment" class="form-control" placeholder="Enter List any dental treatment." runat="server"></asp:TextBox>

                                                    </div>

                                                </div>



                                                <div class="col-sm-2">
                                                    <div class="form-body">

                                                        <div class="form-group">
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            .
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">



                                        <div class="col-xs-12">
                                            <div class="form-group">
                                                <div class="col-sm-5">
                                                    <label>
                                                        Tooth No:
                                                    </label>
                                                    <asp:UpdatePanel ID="updatepanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="TextBox1" class="form-control " runat="server"></asp:TextBox>
                                                            <asp:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                                Enabled="True" ExtenderControlID="" TargetControlID="TextBox1" PopupControlID="Panel1"
                                                                OffsetY="22">
                                                            </asp:PopupControlExtender>
                                                            <asp:Panel ID="Panel1" runat="server" Height="300px" Width="256px"
                                                                BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                                Style="display: none">
                                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" BackColor="White" Height="300px" Width="256px"
                                                                    DataTextField="holiday_name" DataValueField="holiday_name" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                                                </asp:CheckBoxList>

                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-3">
                                                </div>
                                                <div class="col-sm-4">
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-xs-12">


                                            <div class="form-group">
                                                <div class="col-sm-4">
                                                    <div class="form-body">
                                                        <asp:CheckBox ID="CheckConsentStatement" OnCheckedChanged="CheckConsentStatement_CheckedChanged" Text="Consent Statement" runat="server" />
                                                    </div>

                                                </div>



                                                <div class="col-sm-8">
                                                    <div class="form-body">

                                                        <div class="form-group">
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            .
                                        </div>
                                    </div>

                                    <asp:Panel ID="PanelConsent" runat="server">

                                        <div class="row">

                                            <div class="col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-sm-3">
                                                        <label>
                                                            Consent Image
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:FileUpload ID="FileUploadConsent" runat="server" />
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Button ID="btnConsentPic" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                            runat="server" Text="Upload Image" OnClick="btnConsentPic_Click" />
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Image ID="ImageConsentPic" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                            ImageUrl="~/Images/no-photo.jpg" />
                                                        <asp:Label ID="lblConsentPic" runat="server" Visible="False"></asp:Label>
                                                    </div>
                                                </div>

                                            </div>


                                        </div>

                                    </asp:Panel>


                                    <br />
                                    <br />


                                    <br />
                                    <br />


                                    <div class="row">
                                        <div class="form-actions text-center">

                                            <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static"
                                                OnClick="btAdd_Click1" />
                                            <asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server"
                                                Text="Update" Visible="False" />
                                            <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static" OnClick="btnclear_Click"
                                                CausesValidation="False" />

                                            <asp:Button ID="btnConsultation" runat="server" Text="Add Consultation" Visible="false" class="btn blue" ClientIDMode="Static" CausesValidation="false"
                                                OnClick="btConsultationAdd_Click1" />

                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                        </asp:TabContainer>


                        <%--<ul class="nav nav-tabs ">
                            <li class="active">
                                <a href="#tab_5_1" data-toggle="tab">Personal Information </a>
                            </li>
                            <li>
                                <a href="#tab_5_2" data-toggle="tab">Medical History </a>
                            </li>
                            <li>
                                <a href="#tab_5_3" data-toggle="tab">Dental Information</a>
                            </li>
                            

                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_5_1">
                              
                                
                                
                                  
                            </div>



                            <div class="tab-pane" id="tab_5_2">
                              
                            </div>
                            <div class="tab-pane" id="tab_5_3">
                               
                            </div>


                            
                        </div>--%>
                    </div>




                </div>
                <!-- END CONTENT BODY -->
            </div>


        </div>

    </div>


    <div id="Edit" runat="server" class="page-content">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Patient</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">

                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-settings font-red"></i>
                            <span class="caption-subject font-red sbold uppercase">Patient</span>
                        </div>
                        <%--<div class="actions">
							<div class="btn-group btn-group-devided" data-toggle="buttons">
								<label class="btn grey-salsa btn-sm active">
									<input type="radio" name="options" class="toggle" id="option1">Actions</label>
								<label class="btn grey-salsa btn-sm">
									<input type="radio" name="options" class="toggle" id="option2">Settings</label>
							</div>
						</div>--%>
                    </div>
                    <div class="portlet-body">
                        <div class="row">


                            <div class="col-md-3">
                                <div class="form-group">



                                    <asp:TextBox ID="txtNameS" runat="server" class="form-control" placeholder="First Name"
                                        ClientIDMode="Static"></asp:TextBox>


                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">



                                    <asp:TextBox ID="txtLastNameS" runat="server" class="form-control" placeholder="Last Name"
                                        ClientIDMode="Static"></asp:TextBox>


                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:TextBox ID="txtPatientNos" runat="server" class="form-control" placeholder="Patient No"
                                        ClientIDMode="Static"></asp:TextBox>


                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:TextBox ID="txttxtMobailNoss" runat="server" class="form-control" placeholder="Mobile No"
                                        ClientIDMode="Static"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />

                                </div>
                            </div>
                        </div>
                        <!-- Usage as a class -->
                        <div class="text-right mb-20">

                            <asp:Button ID="Button11" runat="server" Text="Excel upload" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddexcelupload_Click1" />
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Patient" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />


                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="patientid" OnRowDataBound="gvShow_RowDataBound"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("patientid") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Visible="false" Text='<%# Eval("PatientCode") %>'></asp:Label>

                                            <asp:HyperLink runat="server" NavigateUrl='<%# Eval("patientid","../Doctor/ConsultationAddTreatment.aspx?pid={0}")%>' Text='<%#Eval("PatientCode") %>' Font-Underline="true" />

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPName" runat="server" Text='<%# Eval("FristName") +"  "+ Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Mobile No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Registration Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("RegistrationDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--Dhaval--%>
                                    <asp:TemplateField Visible="false" HeaderText="Patient Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPstatus" runat="server" Text='<%# Eval("PCstatus") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Clinic Name" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" ToolTip="Edit" CausesValidation="false" runat="server" CommandArgument='<%# Eval("patientid") %>'
                                                CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />
                                            <asp:ImageButton ID="btnview" ToolTip="View" CausesValidation="false" runat="server" Height="10px" Width="20px" CommandArgument='<%# Eval("patientid") %>'
                                                CommandName="viewPDetails" ImageUrl="../Images/images.png" />

                                            <asp:ImageButton ID="lbtDelete" ToolTip="Delete" CausesValidation="false" runat="server" CommandName="delete"
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Enquiry?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>

                        <div class="text-left mb-20">
                            <asp:ImageButton ID="btExcel" runat="server" CausesValidation="false" Height="40px"
                                ImageUrl="~/Images/download.jpg" Text="Download" ToolTip="Download" Width="40px"
                                OnClick="btExcel_Click" />
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>

    <div class="page-content" id="Div11" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Patient</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMSG11" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Patient</span>
                        </div>
                        <%-- <div class="actions">
							<div class="btn-group">
								<a class="btn btn-sm green dropdown-toggle" href="javascript:;" data-toggle="dropdown">Actions
												<i class="fa fa-angle-down"></i>
								</a>
								<ul class="dropdown-menu pull-right">
									<li>
										<a href="javascript:;">
											<i class="fa fa-pencil"></i>Edit </a>
									</li>
									<li>
										<a href="javascript:;">
											<i class="fa fa-trash-o"></i>Delete </a>
									</li>
									<li>
										<a href="javascript:;">
											<i class="fa fa-ban"></i>Ban </a>
									</li>
									<li class="divider"></li>
									<li>
										<a href="javascript:;">Make admin </a>
									</li>
								</ul>
							</div>
						</div>--%>
                    </div>

                    <div class="row">



                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-sm-5">
                                    <label>
                                        Clinic Name  <span class="required">*</span></label>
                                    <asp:DropDownList ID="ddlCinicFileUp" class="form-control" runat="server" SelectionMode="Multiple">
                                    </asp:DropDownList>


                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlCinicFileUp" runat="server" ControlToValidate="ddlCinicFileUp" ValidationGroup="a" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Select Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </span>
                                </div>
                                <div class="col-sm-3">
                                </div>
                                <div class="col-sm-4">
                                </div>

                            </div>
                        </div>
                    </div>


                    <div class="row">



                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-sm-5">
                                    <label>
                                        Select Patient file:
                                    </label>

                                    <asp:FileUpload ID="flOptional" runat="server" Height="30px" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="btnOptionalUpload" runat="server" CausesValidation="false" class="btn blue-madison" Text="Upload"
                                        OnClick="btnOptionalUpload_Click" />
                                </div>
                                <div class="col-sm-4">
                                    <asp:Button ID="btndownloadOptional" runat="server" CausesValidation="false" class="btn blue-madison"
                                        Text="Download Blank Sheet" OnClick="btndownloadOptional_Click" />

                                </div>

                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-actions text-center">


                            <asp:Button ID="btnExlCancel" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                OnClick="btbtnExlCancel_Click" CausesValidation="False" />



                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">

        function checkDate(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a future date !");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }




     </script>

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Mobile number already in used.If you wish to add new patient with existing mobile number then click on OK and then SUBMIT.")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

</asp:Content>
