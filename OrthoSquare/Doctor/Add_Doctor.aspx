<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="Add_Doctor.aspx.cs" Inherits="OrthoSquare.Doctor.Add_Doctor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ajaxtab.css" rel="stylesheet" />

    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload1.ClientID %>").click();
            }
        }
    </script>
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
        function checkDate1(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select future Date!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" id="Add" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Doctor</span>
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
                            <span class="caption-subject bold uppercase">Doctor</span>
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
                                        Clinic Name  <span class="required">*</span></label>
                                    <asp:DropDownList ID="ddlclinic" class="form-control" runat="server" SelectionMode="Multiple">
                                    </asp:DropDownList>


                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlclinic" ValidationGroup="a" InitialValue="0"
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
                    <br />
                    <asp:TabContainer ID="TabContactPerson1" class="nav nav-tabs " runat="server" ActiveTabIndex="0">



                        <asp:TabPanel ID="tabPersonal" class="tab-pane" HeaderText="Personal Information " runat="server">



                            <ContentTemplate>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">

                                            <%--    <div class="col-md-6 ">--%>

                                            <div class="portlet-body form">

                                                <div class="form-body">

                                                    <div class="form-group col-md-6">
                                                        <label>Doctor Type</label>
                                                        <asp:DropDownList ID="ddlDoctorTypeNew" TabIndex="1" runat="server" class="form-control">
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="form-group col-md-6">
                                                        <label>Date</label>
                                                        <asp:TextBox ID="txtDate" class="form-control" TabIndex="2" ReadOnly="true"
                                                            runat="server"></asp:TextBox>
                                                        <span class="help-block"></span>
                                                        <%--<asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                                    TargetControlID="txtDate" Format="dd-MM-yyyy">
                                                                </asp:CalendarExtender>--%>
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="form-group col-md-6">

                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <div class="form-group">

                                                                    <div class="col-sm-3">
                                                                        <label>
                                                                            Title
                                                                        </label>
                                                                        <asp:DropDownList ID="ddlTitla" class="form-control" runat="server">
                                                                            <asp:ListItem Value="Dr.">Dr.</asp:ListItem>
                                                                            <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                                                                            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
                                                                            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
                                                                            <asp:ListItem Value="Miss.">Miss.</asp:ListItem>
                                                                        </asp:DropDownList>

                                                                    </div>
                                                                    <div class="col-sm-9">
                                                                        <label>First Name  <span class="required">*</span></label>
                                                                        <asp:TextBox ID="txtFristName" class="form-control" TabIndex="3"
                                                                            runat="server"></asp:TextBox>
                                                                        <span class="help-block">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldtxtFristName" runat="server" ControlToValidate="txtFristName" ValidationGroup="a"
                                                                                SetFocusOnError="true" ErrorMessage="Please Enter First name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressiontxtFristName" runat="server"
                                                                                ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtFristName"
                                                                                SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                                            </asp:RegularExpressionValidator>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>





                                                    </div>

                                                    <div class="form-group col-md-6">
                                                        <label>Last Name <span class="required">*</span></label>
                                                        <asp:TextBox ID="txtLastName" class="form-control" TabIndex="4"
                                                            runat="server"></asp:TextBox>

                                                        <span class="help-block">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldLastName" runat="server" ControlToValidate="txtLastName" ValidationGroup="a"
                                                                SetFocusOnError="true" ErrorMessage="Please Enter Last name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionLastName" runat="server"
                                                                ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtLastName"
                                                                SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                            </asp:RegularExpressionValidator>
                                                        </span>
                                                    </div>

                                                    <div class="clearfix"></div>



                                                    <div class="form-group col-md-6">
                                                        <label>Date Of Birth</label>
                                                        <asp:TextBox ID="txtBirthDate" class="form-control" TabIndex="5"
                                                            runat="server"></asp:TextBox>
                                                        <asp:CalendarExtender OnClientDateSelectionChanged="checkDate1" ID="txtBDate_CalendarExtender" runat="server" Enabled="True"
                                                            TargetControlID="txtBirthDate" Format="dd-MM-yyyy">
                                                        </asp:CalendarExtender>
                                                    </div>

                                                    <div class="form-group col-md-6">
                                                        <label>Gender</label>
                                                        <asp:RadioButtonList ID="RADGender" runat="server" TabIndex="6" Width="300px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True">Male</asp:ListItem>
                                                            <asp:ListItem>Female</asp:ListItem>

                                                        </asp:RadioButtonList>

                                                    </div>




                                                    <div class="clearfix"></div>

                                                    <div class="form-group col-md-6">
                                                        <label>Address Line 1</label>
                                                        <asp:TextBox ID="txtAddress1" class="form-control" runat="server" TabIndex="7"
                                                            TextMode="MultiLine"></asp:TextBox>
                                                        <%--<span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredtxtAddress" runat="server" ControlToValidate="txtAddress1"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>--%>
                                                    </div>

                                                    <div class="form-group col-md-6">
                                                        <label>Address Line 2</label>
                                                        <asp:TextBox ID="txtAddress2" class="form-control" TextMode="MultiLine" TabIndex="8"
                                                            runat="server"></asp:TextBox>
                                                        <span class="help-block"></span>

                                                    </div>

                                                    <div class="clearfix"></div>




                                                    <div class="form-group col-md-6">
                                                        <label>Country</label>
                                                        <asp:DropDownList ID="ddlCountry" class="form-control" runat="server" TabIndex="9" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="form-group col-md-6">
                                                        <label>State</label>
                                                        <asp:DropDownList ID="ddlState" class="form-control" runat="server" TabIndex="10" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="form-group col-md-6">
                                                        <label>City</label>
                                                        <asp:DropDownList ID="ddlCity" class="form-control" TabIndex="11" runat="server">
                                                        </asp:DropDownList>
                                                    </div>




                                                    <div class="form-group col-md-6">
                                                        <label>Area Pin</label>
                                                        <asp:TextBox ID="txtPinCode" class="form-control" MaxLength="6" TabIndex="12" runat="server"></asp:TextBox>
                                                        <span class="help-block">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorPinCode" runat="server" ControlToValidate="txtPinCode"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter PinCode" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                                                            <%--  <asp:RegularExpressionValidator runat="server" id="rextxtPinCode" controltovalidate="txtPinCode" validationexpression="^[0-9]{6}$" errormessage="Please enter a 6 digit number!" />
                                                            --%>
                                                        </span>
                                                    </div>

                                                    <div class="clearfix"></div>




                                                    <div class="form-group col-md-6">
                                                        <label>
                                                            Mobile No 1. 
                                                     <span class="required">*</span>

                                                        </label>

                                                        <asp:TextBox ID="txtMobileNo1" class="form-control" MaxLength="10" TabIndex="13" runat="server"></asp:TextBox>

                                                        <span class="help-block">
                                                            <asp:RequiredFieldValidator ID="RequiredMobile1" runat="server" ControlToValidate="txtMobileNo1" ValidationGroup="a"
                                                                SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server" ValidationGroup="a"
                                                                Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobileNo1"
                                                                SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </span>


                                                    </div>



                                                    <div class="form-group col-md-6">
                                                        <label>
                                                            Mobile No 2. 
                                                    

                                                        </label>

                                                        <asp:TextBox ID="txtMobileNo2" class="form-control" MaxLength="10" TabIndex="14" runat="server"></asp:TextBox>

                                                        <span class="help-block">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldMobileNo2" runat="server" ControlToValidate="txtMobileNo2"
                                                                SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionMobileNo2" runat="server" ValidationGroup="a"
                                                                Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobileNo2"
                                                                SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </span>

                                                    </div>




                                                    <div class="clearfix"></div>




                                                    <div class="form-group col-md-6">
                                                        <label>Email  <span class="required">*</span></label>

                                                        <asp:TextBox ID="txtEmail" class="form-control" TabIndex="15" runat="server"></asp:TextBox>

                                                        <span class="help-block">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="a"
                                                                SetFocusOnError="true" ErrorMessage="Please Enter Email" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionEmail" runat="server" ValidationGroup="a"
                                                                ForeColor="Red" ErrorMessage="Please enter valid Email" Display="Dynamic" ControlToValidate="txtEmail"
                                                                SetFocusOnError="True" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
                                                            </asp:RegularExpressionValidator>
                                                        </span>
                                                    </div>

                                                    <div class="form-group col-md-6">
                                                        <label>Blood Group</label>

                                                        <asp:TextBox ID="txtBloodGroup" class="form-control" TabIndex="16" runat="server"></asp:TextBox>

                                                    </div>



                                                    <div class="clearfix"></div>

                                                    <div class="form-group col-md-6">
                                                        <label>In Time (HH:MM)  <span class="required">*</span></label>

                                                        <asp:TextBox ID="txtInTime" class="form-control timepicker timepicker-no-seconds" TabIndex="17"
                                                            runat="server"></asp:TextBox>
                                                        <span class="help-block">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorInTime" runat="server" ControlToValidate="txtInTime" ValidationGroup="a"
                                                                SetFocusOnError="true" ErrorMessage="Please Enter InTime" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </div>

                                                    <div class="form-group col-md-6">
                                                        <label>Out Time (HH:MM)  <span class="required">*</span></label>

                                                        <asp:TextBox ID="txtOutTime" class="form-control timepicker timepicker-no-seconds" TabIndex="18"
                                                            runat="server"></asp:TextBox>
                                                        <span class="help-block">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOutTime" runat="server" ControlToValidate="txtOutTime" ValidationGroup="a"
                                                                SetFocusOnError="true" ErrorMessage="Please Enter OutTime" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </div>


                                                    <div class="clearfix"></div>






                                                </div>

                                            </div>

                                            <!-- END CONTENT BODY -->
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="row">
                                    <div class="form-actions text-center">
                                        <div align="Right">
                                            <asp:Button ID="BtnNextContact" runat="server" Text="Next" class="btn btn-info btn-sm" OnClick="BtnNextContact_Click" ValidationGroup="a" />
                                        </div>
                                    </div>


                                </div>

                            </ContentTemplate>

                        </asp:TabPanel>



                        <asp:TabPanel ID="TabPanel1" class="tab-pane" HeaderText="Education" runat="server">
                            <ContentTemplate>
                                 <br />
                                <div class="row">
                                    <div class="col-xs-12">

                                        <div class="form-group">
                                            <div class="col-sm-3">


                                                <label>Degree </label>
                                                <asp:DropDownList ID="ddlDegreeQ" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDegreeQ_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDegreeQ" ValidationGroup="D" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Select Degree" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3">


                                                <label>Board </label>
                                                <asp:TextBox ID="txtBoardName" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <label>Upload </label>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />



                                                <asp:Button ID="btnUpload1" runat="server" Style="display: none" Text="Upload" ValidationGroup="PaperSubmit" OnClick="Upload12111" />
                                                <asp:Label ID="lblImageName" Visible="false" runat="server" Text=""></asp:Label>

                                            </div>
                                            <div class="col-sm-3">


                                                <asp:Image ID="CertificationImage" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                    ImageUrl="~/img/no-photo.jpg" />

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group pull-left">
                                            <asp:Button ID="btnAddDetails" runat="server" ValidationGroup="D" CssClass="btn btn-secondary" Text="Add" OnClick="btnAddDetails_Click" />

                                        </div>
                                    </div>
                                </div>
                                <div id="AddDegree" visible="false" runat="server" class="row">

                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <label>
                                                    Degree</label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtAddDegree" class="form-control" TabIndex="4"
                                                    runat="server"></asp:TextBox>


                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Button ID="btnAddDegree" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                    runat="server" Text="Submit" OnClick="btnAddDegree_Click" />

                                                <asp:Button ID="btnDegreeCancel" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                                    OnClick="btnDegreeCancel_Click" CausesValidation="False" />
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>

                                    </div>


                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <asp:GridView ID="GridQualification" runat="server" class="table table-striped table-bordered table-hover" AutoGenerateColumns="False" ShowFooter="true" OnRowDataBound="GridQualification_DataBound1" OnRowCommand="GridQualification_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.no" ItemStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrno1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Degree" ItemStyle-Width="120px">
                                                    <ItemTemplate>

                                                        <asp:TextBox ID="txt_CertificationName" ReadOnly="true" runat="server" CssClass="form-control" placeholder="Certification Name" Text='<%#Eval("DegreeName") %>'></asp:TextBox>

                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Board Name" ItemStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_boardname" ReadOnly="true" runat="server" CssClass="form-control" Text='<%#Eval("Boardname") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:TemplateField HeaderText="File" ItemStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtFileName" Visible="false" ReadOnly="true" Text='<%#Eval("CertificationImage") %>' CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:Image ID="ImageFileName" Width="100px" Height="100px" ImageUrl='<%# "../QualificationDoc/"+ Eval("CertificationImage") %>' runat="server" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Staus" ItemStyle-Width="10px">

                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LnkCashDelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("DegreeName") %>'
                                                            CommandName="GrdCQDelete" OnClientClick="return confirm('Are you sure you want to delete Qualification ?');">
                                                                                                                            <i class="fa fa-trash fa-lg" ></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>

                                


                                <br />
                                <br />





                                <div class="row">
                                    <div class="col-xs-12">
                                        <label>Speciality </label>
                                        <asp:CheckBoxList ID="ddl_SelectSpeciality1" Width="800px" RepeatColumns="4" RepeatDirection="Vertical" class="mt-checkbox-list" runat="server"></asp:CheckBoxList>

                                        <div class="form-group">
                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                        .
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-actions text-center">
                                        <div align="Right">
                                            <asp:Button ID="btnMedical" runat="server" Text="Next" class="btn btn-info btn-sm" OnClick="BtnNextMedical_Click" CausesValidation="false" />
                                        </div>
                                    </div>

                                </div>


                            </ContentTemplate>
                        </asp:TabPanel>


                        <asp:TabPanel ID="TabPanel2" class="tab-pane" HeaderText="Documents" runat="server">
                            <ContentTemplate>
                                <br />
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-sm-3">
                                                        <label>
                                                            Profile Photo</label>
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
                                                .
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>

                                            <%--                                            <asp:AsyncPostBackTrigger ControlID="btnUploadimage"
                                                EventName="Click" />--%>

                                            <asp:PostBackTrigger ControlID="btnUploadimage"></asp:PostBackTrigger>

                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-6">
                                                <label>Adhar Card No. (0000 0000 0000)</label>
                                                <asp:TextBox ID="txtAdharNo" class="form-control"
                                                    runat="server"></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorAdharNo" runat="server"
                                                    ForeColor="Red" ErrorMessage="InValid Adhar Card No" Display="Dynamic" ControlToValidate="txtAdharNo"
                                                    SetFocusOnError="True" ValidationExpression="^\d{4}\s\d{4}\s\d{4}$">
                                                </asp:RegularExpressionValidator>
                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <label>Adhar Card Image</label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:FileUpload ID="FileAdharCard" runat="server" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Button ID="Buttonadharcard" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                    runat="server" Text="Upload Image" OnClick="btnUploadAdharcard_Click" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Image ID="ImageAdharcard" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                    ImageUrl="~/Images/no-photo.jpg" />
                                                <asp:Label ID="lblAdharcard" runat="server" Visible="False"></asp:Label>
                                            </div>
                                        </div>
                                        .
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">

                                                <label>Pan Card No. <span class="required">*</span></label>
                                                <asp:TextBox ID="txtPanCard" class="form-control"
                                                    runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorpanCard" runat="server" ControlToValidate="txtPanCard"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Pan Card No." ForeColor="Red"></asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatortxtPanCard" runat="server"
                                                    ForeColor="Red" ErrorMessage="InValid PAN Card" Display="Dynamic" ControlToValidate="txtPanCard"
                                                    SetFocusOnError="True" ValidationExpression="[A-Z]{5}\d{4}[A-Z]{1}">
                                                </asp:RegularExpressionValidator>
                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <label>Pan Card Image</label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:FileUpload ID="FilePancard" runat="server" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Button ID="Buttonpancard" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                    runat="server" Text="Upload Image" OnClick="btnUplPancard_Click" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Image ID="Imagepancard" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                    ImageUrl="~/Images/no-photo.jpg" />
                                                <asp:Label ID="lblpancard" runat="server" Visible="False"></asp:Label>
                                            </div>
                                        </div>
                                        .
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">

                                                <label>Registration No. <span class="required">*</span></label>
                                                <asp:TextBox ID="txtRegNo" class="form-control"
                                                    runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRegistrationNo" runat="server" ControlToValidate="txtRegNo"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Registration No." ForeColor="Red"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <label>Certificate Image</label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:FileUpload ID="FileCrtificat" runat="server" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Button ID="ButtonCrtificat" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                    runat="server" Text="Upload Image" OnClick="btnUplCrtificat_Click" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Image ID="ImageCrtificat" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                    ImageUrl="~/Images/no-photo.jpg" />
                                                <asp:Label ID="lblCrtificat" runat="server" Visible="False"></asp:Label>
                                            </div>
                                        </div>
                                        .
                                    </div>

                                </div>





                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">

                                                <label>Indemnity Policy No. <span class="required">*</span></label>
                                                <asp:TextBox ID="txtIdentity" class="form-control"
                                                    runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldIdentityPolicy" runat="server" ControlToValidate="txtIdentity"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Identity Policy No." ForeColor="Red"></asp:RequiredFieldValidator>


                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <label>Indemnity Policy No Image</label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:FileUpload ID="FileUploadPolicy" runat="server" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Button ID="btnPolicy" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                    runat="server" Text="Upload Image" OnClick="btnUplPolicy_Click" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Image ID="ImagePolicy" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                    ImageUrl="~/Images/no-photo.jpg" />
                                                <asp:Label ID="lblPolicy" runat="server" Visible="False"></asp:Label>
                                            </div>
                                        </div>
                                        .
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="form-actions text-center">

                                        <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                                        <asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server" OnClick="btUpdate_Click" Visible="false"
                                            Text="Update" />
                                        <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static" OnClick="btnclear_Click"
                                            CausesValidation="False" />


                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>


                    </asp:TabContainer>


                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>


    <div id="Edit" runat="server" class="page-content">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Doctor</span>
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
                            <span class="caption-subject font-red sbold uppercase">Doctor</span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    
                                    <asp:TextBox ID="txtNAme" runat="server" class="form-control" placeholder="Doctor Name"
                                        ClientIDMode="Static"></asp:TextBox>


                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                  
                                    <asp:TextBox ID="txtMobiles" runat="server" class="form-control" placeholder="Mobile No."
                                        ClientIDMode="Static"></asp:TextBox>
                                    <span class="help-block"></span>

                                </div>
                            </div>

                               <div class="col-sm-3">

                                   
                                    <asp:DropDownList ID="ddlClinicSearch" class="form-control"  AutoPostBack="true"  runat="server" ></asp:DropDownList>

                                       <span class="help-block">
                                   <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClinicSearch" InitialValue="0"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Clinic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                           </span>
                                </div>


                            <div class="col-md-3">
                            

                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />


                              
                            </div>
                        </div>


                        <!-- Usage as a class -->
                        <div class="text-right mb-20">


                            <asp:Button ID="Button11" runat="server" Text="Excel Upload" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddexcelupload_Click" />
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />

                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-striped table-bordered table-hover" DataKeyNames="DoctorID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true" OnRowDataBound="gvShow_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("DoctorID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" Width="70px" Height="75px" ImageUrl='<%# "../EmployeeProfile/"+ Eval("ProfileImageUrl") %>' runat="server" />
                                               <asp:Label ID="lblProfilePic" runat="server" Visible="false" Text='<%# Eval("ProfileImageUrl") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialTypeName" runat="server" Text='<%# Eval("Mobile1") +"</br>" +Eval("Mobile2")  %>'>  </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandName" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsName" runat="server" Text='<%# Eval("LLUserName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("LLPassword") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Reg Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUOMName" runat="server" Text='<%# Eval("RegDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                     <asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" Height="15px" Width="17px" CommandArgument='<%# Eval("DoctorID") %>'
                                                CommandName="EditDocterDetails" ImageUrl="../Images/edit15x15.png" />

                                            <asp:ImageButton ID="btnview" CausesValidation="false" runat="server" Height="15px" CommandArgument='<%# Eval("DoctorID") %>' ToolTip="View"
                                                CommandName="viewDocterDetails" ImageUrl="../Images/view2.png" />



                                            <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete" ToolTip="Delete"
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Doctor?');" />

                                            <asp:ImageButton ID="btnUpdate1" CausesValidation="false" runat="server" CommandArgument='<%# Eval("DoctorID") %>' ToolTip="Edit Time"
                                                CommandName="EditInouttime" ImageUrl="../Images/EditTIme.png" />


                                            <asp:ImageButton ID="ImageButton1" CausesValidation="false" Width="18px" runat="server" CommandArgument='<%# Eval("DoctorID") %>' ToolTip="Add Clinic"
                                                CommandName="DoctorsbyClinic" ImageUrl="../Images/view1.png" />

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


    <div class="page-content" id="Div2" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Doctor</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblmsg1" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Doctor</span>
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
                                    <label>In Time (HH:MM)</label>

                                    <asp:TextBox ID="txtIntimeUpdate" class="form-control timepicker timepicker-no-seconds"
                                        runat="server"></asp:TextBox>




                                </div>
                                <div class="col-sm-4">
                                    <label>Out Time (HH:MM)</label>


                                    <asp:TextBox ID="txtouttimeUpdate" class="form-control timepicker timepicker-no-seconds"
                                        runat="server"></asp:TextBox>




                                </div>
                            </div>
                        </div>

                    </div>
                    <br />

                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btnUpdateIOtime" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnUpdateIOtime_Click" />

                            <asp:Button ID="btnIOCancel" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnIOCancel_Click" />


                        </div>

                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
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
                    <span>Doctor</span>
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
                            <span class="caption-subject bold uppercase">Doctor</span>
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
                                <div class="col-sm-3">
                                    <label>
                                        Clinic:
                                    </label>

                                    <asp:DropDownList ID="ddlUploadClinic" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                </div>
                                <div class="col-sm-3">
                                </div>
                                <div class="col-sm-3">
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">



                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-sm-5">
                                    <label>
                                        Select Doctor file:
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




    <div class="page-content" id="Div111" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Doctor</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblmsg1223" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Doctor</span>
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
                                        Select Clinic:
                                    </label>
                                    <asp:UpdatePanel ID="updatepanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TextBox1" class="form-control " runat="server"></asp:TextBox>
                                            <asp:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                Enabled="True" ExtenderControlID="" TargetControlID="TextBox1" PopupControlID="Panel1"
                                                OffsetY="22">
                                            </asp:PopupControlExtender>
                                            <asp:Panel ID="Panel1" runat="server" Height="300px" Width="256px"
                                                BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                Style="display: none">
                                                <asp:CheckBox ID="cbAll" OnSelectedIndexChanged="cbAll_SelectedIndexChanged" AutoPostBack="True" runat="server" Text="Select All" onclick="CheckAll();" />

                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" BackColor="White" Height="300px" Width="256px"
                                                    DataTextField="holiday_name" DataValueField="holiday_name" AutoPostBack="True" onclick="UnCheckAll();"
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
                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btnDbyCSubmit" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnDbyCSubmit_Click" />

                            <asp:Button ID="BtnDyc" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                OnClick="BtnDycCancel_Click" CausesValidation="False" />



                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>









    <script type="text/javascript">
        $(function () {
            $('[id*=ddlclinic]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lst]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>

     <script type="text/javascript">
     function CheckAll() {
            var count = 0;
            $('#' + '<%=CheckBoxList1.ClientID %>' + '  input:checkbox').each(function () {
                count = count + 1;
            });
            for (i = 0; i < count; i++) {
                if ($('#' + '<%=cbAll.ClientID %>').prop('checked') == true) {
                    if ('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i) {
                        if (('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i).disabled != true)
                            $('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i + ':checkbox').prop('checked', true);
                    }
                }
                else {
                    if ('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i) {
                        if (('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i).disabled != true)
                            $('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i + ':checkbox').prop('checked', false);
                    }
                }
            }
        }



        function UnCheckAll() {
            var flag = 0;
            var count = 0;
            $('#' + '<%=CheckBoxList1.ClientID %>' + '  input:checkbox').each(function () {
                count = count + 1;
            });
            for (i = 0; i < count; i++) {
                if ('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i) {
                    if ($('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i).prop('checked') == true) {
                        flag = flag + 1;
                    }
                }
            }
            if (flag == count)
                $('#' + '<%=cbAll.ClientID %>' + ':checkbox').prop('checked', true);
            else
                $('#' + '<%=cbAll.ClientID %>' + ':checkbox').prop('checked', false);
        }

           </script>



</asp:Content>
