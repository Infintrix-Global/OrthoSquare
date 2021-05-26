<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="OrthoSquare.Employee.EmployeeDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

    <div class="page-content" id="Add" visible="false" runat="server">
        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Employee</span>
                </li>
            </ul>

        </div>

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="Label1" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Employee</span>
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

                                <div class="col-sm-4">
                                    <label>
                                        Clinic Name <span class="required">*</span></label>
                                    <asp:DropDownList ID="ddlclinic" class="form-control" runat="server">
                                    </asp:DropDownList>
                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlclinic" ValidationGroup="a" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Select Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </span>
                                </div>

                            </div>
                        </div>


                    </div>
                    <hr />

                    <div class="tabbable-custom ">
                        <asp:TabContainer ID="TabContactPerson1" class="nav nav-tabs " runat="server" ActiveTabIndex="0">

                            <asp:TabPanel ID="tabPersonal" class="tab-pane" HeaderText="Personal Information " runat="server">
                                <ContentTemplate>

                                    <div class="form-body">
                                        <div class="row">
                                            <div class="col-md-4">

                                                <div class="form-group">
                                                    <label>Employee No.</label>
                                                    <asp:TextBox ID="txtEmpCode" class="form-control" ReadOnly="true"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <%-- <div class="form-group">
                                                          
                                                            <span class="help-block"></span>
                                                            <label for="form_control_1">
                                                                Employee No. <span class="required">*</span>
                                                            </label>
                                                        </div>--%>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label>Designation <span class="required">*</span></label>
                                                    <asp:DropDownList ID="ddlDesignation" class="form-control" runat="server">
                                                    </asp:DropDownList>
                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlDesignation" InitialValue="0" runat="server" ControlToValidate="ddlDesignation" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Registration Date <span class="required">*</span>
                                                    </label>
                                                    <asp:TextBox ID="txtRegDate" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtENqDate_CalendarExtender" runat="server" Enabled="True"
                                                        TargetControlID="txtRegDate">
                                                    </asp:CalendarExtender>

                                                    <span class="help-block"></span>
                                                </div>


                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        First Name <span class="required">*</span>
                                                    </label>
                                                    <asp:TextBox ID="txtFname" class="form-control" placeholder="Enter First Name" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFname" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter First name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ValidationGroup="a"
                                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtFname"
                                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Middle Name 
                                                    </label>
                                                    <asp:TextBox ID="txtMidName" class="form-control" placeholder="Enter Middle Name"
                                                        runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorMidName" runat="server" ControlToValidate="txtMidName"
                                                                    SetFocusOnError="true" ErrorMessage="Please Enter First name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMidName" runat="server"
                                                                    ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtMidName"
                                                                    SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>--%>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Last Name <span class="required">*</span>
                                                    </label>
                                                    <asp:TextBox ID="txtLname" class="form-control" placeholder="Enter Last Name" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredLname" runat="server" ControlToValidate="txtLname" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Last name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorLname" runat="server" ValidationGroup="a"
                                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtLname"
                                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Gender
                                                    </label>
                                                    <asp:RadioButtonList ID="RadGender" runat="server" Width="250px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="Male"> Male </asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <%--  <asp:Button ID="btnSubmit" runat="server" Text="Submit" CausesValidation ="false" 
                                                            class="btn btn-outline green button-next" onclick="btnSubmit_Click" />--%>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        BirthDate
                                                    </label>
                                                    <asp:TextBox ID="txtBirthDate" class="form-control" placeholder="Enter BirthDate"
                                                        runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" OnClientDateSelectionChanged="checkDate"
                                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtBirthDate">
                                                    </asp:CalendarExtender>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Blood Group 
                                                    </label>
                                                    <asp:TextBox ID="txtBloodGroup" class="form-control" placeholder="Enter Blood Group"
                                                        runat="server"></asp:TextBox>


                                                </div>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Nationality 
                                                    </label>
                                                    <asp:DropDownList ID="dllNationality" class="form-control" runat="server">
                                                        <asp:ListItem>Indian</asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:DropDownList>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        User Name  <span class="required">*</span>
                                                    </label>

                                                    <asp:TextBox ID="txtUsername" class="form-control" placeholder="Enter UserName"
                                                        runat="server"></asp:TextBox>
                                                    <span class="help-block">

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsername" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter User name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Password <span class="required">*</span>
                                                    </label>
                                                    <asp:TextBox ID="txtPassword" class="form-control" placeholder="Enter Password"
                                                        runat="server"></asp:TextBox>

                                                    <span class="help-block">

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ValidationGroup="a"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>



                                            <div class="clearfix">
                                            </div>
                                            <%--  <div class="col-xs-12 col-md-12">--%>
                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label>
                                                        Employee Photo</label>
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:FileUpload ID="FuImage1" runat="server" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:Button ID="btnUploadimage" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                        runat="server" Text="Upload Image" OnClick="btnUploadimage_Click" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:Image ID="ImagePhoto1" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                        ImageUrl="~/Images/no-photo.jpg" />
                                                    <asp:Label ID="lbl_filepath1" runat="server" Visible="False"></asp:Label>
                                                </div>
                                            </div>

                                            <%--</div>--%>
                                        </div>


                                        <div class="row">
                                            <div class="form-actions text-center">
                                                <div align="Right">
                                                    <asp:Button ID="BtnNextContact" runat="server" Text="Next" class="btn btn-info btn-sm" ValidationGroup="a" OnClick="BtnNextContact_Click" />
                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel1" class="tab-pane" HeaderText="Contact Details " runat="server">
                                <ContentTemplate>
                                    <div class="form-body">
                                        <div class="row">
                                            &nbsp;&nbsp;&nbsp; <i class=" icon-layers font-red"></i><span class="caption-subject font-red bold uppercase">Current Address </span>
                                            <hr />
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Address  <span class="required">*</span>
                                                    </label>
                                                    <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Enter Address"
                                                        TextMode="MultiLine"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredtxtAddress" runat="server" ControlToValidate="txtAddress" ValidationGroup="C"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Area<span class="required"></span>
                                                    </label>
                                                    <asp:TextBox ID="txtArea" class="form-control" TextMode="MultiLine" placeholder="Enter Area"
                                                        runat="server"></asp:TextBox>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Pin Code <span class="required"></span>
                                                    </label>
                                                    <asp:TextBox ID="txtPincode" class="form-control" MaxLength="6" placeholder="Enter Pin Code"
                                                        runat="server"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPincode" runat="server" ValidationGroup="C"
                                                        ControlToValidate="txtPincode" Display="Dynamic" ErrorMessage="Invalid Pincode"
                                                        ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Country 
                                                    </label>
                                                    <asp:DropDownList ID="ddlCountry1" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                                        class="form-control" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        State 
                                                    </label>
                                                    <asp:DropDownList ID="ddlState" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"
                                                        class="form-control" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        City
                                                    </label>
                                                    <asp:DropDownList ID="ddlCity" class="form-control" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            &nbsp;&nbsp;&nbsp; <i class=" icon-layers font-red"></i><span class="caption-subject font-red bold uppercase">Permanent Address </span>
                                            <hr />
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <asp:CheckBox ID="CheCopy" runat="server" Text="Same as Current Address" AutoPostBack="True"
                                                        OnCheckedChanged="CheCopy_CheckedChanged" />
                                                </div>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Address 
                                                    </label>
                                                    <asp:TextBox ID="txtperAddress" class="form-control" placeholder="Enter Address"
                                                        runat="server" TextMode="MultiLine"></asp:TextBox>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Area<span class="required"></span>
                                                    </label>
                                                    <asp:TextBox ID="txtperArea" class="form-control" placeholder="Enter Area" TextMode="MultiLine"
                                                        runat="server"></asp:TextBox>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Pin Code <span class="required"></span>
                                                    </label>
                                                    <asp:TextBox ID="txtperPincode" class="form-control" MaxLength="6" placeholder="Enter Pin Code"
                                                        runat="server"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorperPincode" runat="server" ValidationGroup="C"
                                                        ControlToValidate="txtperPincode" Display="Dynamic" ErrorMessage="Invalid Pincode"
                                                        ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Country 
                                                    </label>
                                                    <asp:DropDownList ID="ddlPCountry" class="form-control" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlPCountry_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        State 
                                                    </label>
                                                    <asp:DropDownList ID="ddlPState" class="form-control" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlPState_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        City
                                                    </label>
                                                    <asp:DropDownList ID="ddlPCity" class="form-control" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <span class="help-block"></span>
                                                </div>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <hr />
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Mobile No.  <span class="required">*</span>
                                                    </label>
                                                    <asp:TextBox ID="txtMobile" class="form-control" MaxLength="10" placeholder="Enter Mobile" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredMobile" runat="server" ControlToValidate="txtMobile" ValidationGroup="C"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server" ValidationGroup="C"
                                                            Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                            SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Telephone No.
                                                    </label>
                                                    <asp:TextBox ID="txtPerTelephoneNO" MaxLength="10" class="form-control" placeholder="Enter Telephone"
                                                        runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPerTelephoneNO" runat="server" ValidationGroup="C"
                                                            Display="Dynamic" ErrorMessage="Please enter valid Telephone Number" ControlToValidate="txtPerTelephoneNO"
                                                            SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Email 
                                                    </label>
                                                    <asp:TextBox ID="txtEmail" class="form-control" placeholder="Enter Email" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ValidationGroup="C"
                                                            ForeColor="Red" ErrorMessage="Enter Proper Email ID" Display="Dynamic" ControlToValidate="txtEmail"
                                                            SetFocusOnError="True" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4 col-md-offset-5">
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-actions text-center">
                                            <div align="Right">
                                                <asp:Button ID="btnMedical" runat="server" Text="Next" class="btn btn-info btn-sm" OnClick="BtnNextMedical_Click" ValidationGroup="C" />
                                            </div>
                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel2" class="tab-pane" HeaderText="Bank & Other Details " runat="server">
                                <ContentTemplate>
                                    <div class="portlet-body">
                                        <div class="form-body">
                                            <asp:UpdatePanel ID="UpdatePaneltab3" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">
                                                        &nbsp;&nbsp;&nbsp;  <i class=" icon-layers font-red"></i><span class="caption-subject font-red bold uppercase">Bank Details </span>
                                                        <hr />
                                                        <div class="clearfix">
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    Bank Name 
                                                                </label>
                                                                <asp:TextBox ID="txtBankName" class="form-control" placeholder="Enter Bank Name"
                                                                    runat="server"></asp:TextBox>

                                                                <span class="help-block">
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorBankName" runat="server" ControlToValidate="txtBankName"
                                                                            SetFocusOnError="true" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    Branch Name<span class="required"></span>
                                                                </label>
                                                                <asp:TextBox ID="txtBranchName" class="form-control" placeholder="Enter Branch Name"
                                                                    runat="server"></asp:TextBox>

                                                                <span class="help-block"></span>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    IFSC Code<span class="required"></span>
                                                                </label>
                                                                <asp:TextBox ID="txtIFSC_Code" MaxLength="15" class="form-control" placeholder="Ex ASDF0123456"
                                                                    runat="server"></asp:TextBox>

                                                                <span class="help-block">

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                        ControlToValidate="txtIFSC_Code" Display="Dynamic" ErrorMessage="Invalid IFSC Code"
                                                                        ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[^\s]{4}\d{7}$"></asp:RegularExpressionValidator>

                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix">
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    Account Number
                                                                </label>
                                                                <asp:TextBox ID="txtAccountNo" MaxLength="25" class="form-control" placeholder="Enter Account Number"
                                                                    runat="server"></asp:TextBox>

                                                                <span class="help-block">
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorotherPincode" runat="server"
                                                                        ControlToValidate="txtAccountNo" Display="Dynamic" ErrorMessage="Invalid Account Number"
                                                                        ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    Account Holder Name<span class="required"> </span>
                                                                </label>
                                                                <asp:TextBox ID="txtAccountHolderName" class="form-control" placeholder="Enter Account Holder Name"
                                                                    runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <div class="clearfix">
                                                        </div>
                                                        &nbsp;&nbsp;&nbsp; <i class=" icon-layers font-red"></i><span class="caption-subject font-red bold uppercase">Other Details </span>
                                                        <hr />
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    Aadhaar card No. 
                                                                </label>
                                                                <asp:TextBox ID="txtAadhaarcard" class="form-control" placeholder="Enter Aadhaar card No."
                                                                    runat="server"></asp:TextBox>

                                                                <span class="help-block">
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorAdharNo" runat="server"
                                                                        ForeColor="Red" ErrorMessage="InValid Adhar Card No" Display="Dynamic" ControlToValidate="txtAadhaarcard"
                                                                        SetFocusOnError="True" ValidationExpression="^\d{4}\s\d{4}\s\d{4}$">
                                                                    </asp:RegularExpressionValidator>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    Passport No. 
                                                                </label>
                                                                <asp:TextBox ID="txtPassportNo" class="form-control" placeholder="Enter Passport No"
                                                                    runat="server"></asp:TextBox>
                                                                <span class="help-block"></span>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label for="form_control_1">
                                                                    Driving licence No. 
                                                                </label>
                                                                <asp:TextBox ID="txtdrivinglicence" class="form-control" placeholder="Enter Driving licence No."
                                                                    runat="server"></asp:TextBox>
                                                                <span class="help-block"></span>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix">
                                                        </div>
                                                    </div>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>


                                            <div class="col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-sm-3">
                                                        <label>
                                                            Document
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:FileUpload ID="fileDOc" runat="server" />
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Button ID="btnDocupload" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                            runat="server" Text="Upload Image" OnClick="btnDocupload_Click" />
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Image ID="ImgDoc" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                            ImageUrl="~/Images/no-photo.jpg" />
                                                        <asp:Label ID="lblDoc" runat="server" Visible="False"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4 col-md-offset-5">
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-actions text-center">

                                                    <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static"
                                                        OnClick="btnSubmit_Click" />
                                                    <asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server"
                                                        Text="Update" Visible="False" />
                                                    <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                                        CausesValidation="False" />



                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>


                    </div>



                </div>
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
                    <span>Employee</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-settings font-red"></i>
                            <span class="caption-subject font-red sbold uppercase">Employee</span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Employee Name</label>
                                    <asp:TextBox ID="txtNAme" runat="server" class="form-control" placeholder="Employee Name"
                                        ClientIDMode="Static"></asp:TextBox>
                                    <span class="help-block"></span>

                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Mobile No.</label>
                                    <asp:TextBox ID="txtMobiles" runat="server" class="form-control" placeholder="Mobile No."
                                        ClientIDMode="Static"></asp:TextBox>
                                    <span class="help-block"></span>

                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Employee Code</label>
                                    <asp:TextBox ID="txtE_code" runat="server" class="form-control" placeholder="Employee Code"
                                        ClientIDMode="Static"></asp:TextBox>
                                    <span class="help-block"></span>

                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group form-md-line-input ">
                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />


                                </div>
                            </div>
                        </div>


                        <!-- Usage as a class -->
                        <div class="text-right mb-20">


                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />
                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-striped table-bordered table-hover" DataKeyNames="EmployeeID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("EmployeeID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Photo" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" Width="100px" Height="100px" ImageUrl='<%# "~/EmployeeProfile/"+ Eval("EmployeePhoto") %>' runat="server" />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Emp Code" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("EmployeeCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="26%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("MiddleName") +"  "+ Eval("Surname")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile No." ItemStyle-Width="18%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialTypeName" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email ID" ItemStyle-Width="18%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandName" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reg Date" ItemStyle-Width="18%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUOMName" runat="server" Text='<%# Eval("RegistrationDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("EmployeeID") %>'
                                                CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete"
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Employee?');" />
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
                    </div>
                </div>

            </div>

        </div>

    </div>

    <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>
